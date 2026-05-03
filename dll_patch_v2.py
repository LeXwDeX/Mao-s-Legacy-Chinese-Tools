#!/usr/bin/env python3
"""
dll_patch_v2.py
基于 DLL_PATCH_WHITELIST.json 的精准 DLL patch。

策略：
  - 从白名单加载 1762 条 #US heap 英文字符串
  - 用 API 批量翻译为中文
  - 在 DLL 二进制中原地替换 UTF-16LE 内容
  - 翻译短于原文时用空格填充（保持 blob_length 不变）
  - 翻译超长时截断

#US Heap 字符串格式：
  [compressed_length(1-4B)] [UTF-16LE content] [trailing_byte(0x01)]
  - UTF-16: 中英文均 2 字节/字符，可 1:1 替换

用法：
    uv run python3 dll_patch_v2.py                  # 翻译 + patch
    uv run python3 dll_patch_v2.py --translate-only  # 只翻译不patch
    uv run python3 dll_patch_v2.py --patch-only      # 只patch(需已有翻译文件)
    uv run python3 dll_patch_v2.py --dry-run         # 不实际写入
"""

import json, os, sys, re, time, struct, shutil, argparse
from pathlib import Path
from urllib.request import Request, urlopen
from urllib.error import URLError, HTTPError

# ──────────────────────────────────────────────────────────────────────────────
# 配置
# ──────────────────────────────────────────────────────────────────────────────

WHITELIST_PATH = Path("decompiled/DLL_PATCH_WHITELIST.json")
DLL_ORIGINAL   = Path("1.8.5_Resources/Data/Managed/Assembly-CSharp.dll")
DLL_OUTPUT     = Path("1.8.5_output/Assembly-CSharp.dll")
TRANSLATIONS_CACHE = Path("dll_strings/translations_v2.json")

GAME_DATA = Path(os.path.expanduser(
    "~/Library/Application Support/Steam/steamapps/common/Mao's Legacy/"
    "China.app/Contents/Resources/Data/Managed"))

API_URL  = "http://192.168.50.3:18000/v1/chat/completions"
API_KEY  = "sk-lexwdex"
MODEL    = "gpt-5.4-nano"

# ──────────────────────────────────────────────────────────────────────────────
# API 翻译
# ──────────────────────────────────────────────────────────────────────────────

SYSTEM_PROMPT = """你是一名专业的游戏汉化翻译。你正在翻译冷战策略游戏《毛的遗产》(Mao's Legacy) 的 UI 文本。

翻译规则：
1. 翻译必须简洁，适合游戏 UI 显示
2. 人名使用历史上准确的中文译名（如 Deng Xiaoping = 邓小平）
3. 国家名用标准中文名（如 Soviet Union = 苏联）
4. 政治/经济/军事专业术语准确翻译
5. 保留所有格式符号（|、{0}、{1}、<color=xxx>、</color> 等）
6. 每行的 [ID] 编号必须保留
7. 输入几行就输出几行，行数必须完全一致
8. 翻译长度尽量不超过原文长度（UTF-16下1个汉字=1个英文字母的空间）"""


def call_api(prompt: str, system_msg: str = "", max_retries: int = 3) -> str:
    """调用翻译 API。"""
    messages = []
    if system_msg:
        messages.append({"role": "system", "content": system_msg})
    messages.append({"role": "user", "content": prompt})

    payload = json.dumps({
        "model": MODEL,
        "messages": messages,
        "temperature": 0.1,
        "max_completion_tokens": 16384,
    }).encode("utf-8")

    for attempt in range(max_retries):
        try:
            req = Request(API_URL, data=payload, method="POST")
            req.add_header("Content-Type", "application/json")
            req.add_header("Authorization", f"Bearer {API_KEY}")
            with urlopen(req, timeout=180) as resp:
                result = json.loads(resp.read())
                return result["choices"][0]["message"]["content"]
        except (URLError, HTTPError, KeyError, json.JSONDecodeError) as e:
            print(f"    API 错误 (尝试 {attempt+1}/{max_retries}): {e}", file=sys.stderr)
            if attempt < max_retries - 1:
                time.sleep(2 ** attempt)
    raise RuntimeError("API 调用失败，已达最大重试次数")


def parse_numbered_response(response: str, expected_ids: list[str]) -> dict:
    """解析 [ID] 格式的翻译响应，返回 {id: text}。"""
    result = {}
    for line in response.strip().split("\n"):
        m = re.match(r'\[([^\]]+)\]\s*(.*)', line)
        if m:
            result[m.group(1)] = m.group(2)
    return result


def batch_translate_entries(entries: list[dict], progress_path: Path) -> dict:
    """批量翻译白名单条目，返回 {offset_hex: chinese_text}。
    
    自适应 batch size：按总字符数分批，目标每批 ~8000 字符。
    """
    # 加载已有进度
    translations = {}
    if progress_path.exists():
        try:
            translations = json.load(open(progress_path, encoding="utf-8"))
            print(f"  已有翻译缓存: {len(translations)} 条")
        except (json.JSONDecodeError, KeyError):
            pass

    # 过滤已翻译的
    remaining = [e for e in entries if e["offset"] not in translations]
    if not remaining:
        print(f"  所有 {len(entries)} 条已翻译")
        return translations

    print(f"  待翻译: {len(remaining)} 条")

    # 自适应分批：按总字符数控制
    MAX_CHARS_PER_BATCH = 8000
    batches = []
    current_batch = []
    current_chars = 0

    for entry in remaining:
        text_len = len(entry["text"])
        # 单条超大文本独立成批
        if text_len > MAX_CHARS_PER_BATCH:
            if current_batch:
                batches.append(current_batch)
                current_batch = []
                current_chars = 0
            batches.append([entry])
            continue

        if current_chars + text_len > MAX_CHARS_PER_BATCH:
            batches.append(current_batch)
            current_batch = []
            current_chars = 0

        current_batch.append(entry)
        current_chars += text_len

    if current_batch:
        batches.append(current_batch)

    print(f"  分为 {len(batches)} 批次")

    for batch_idx, batch in enumerate(batches):
        print(f"  批次 {batch_idx+1}/{len(batches)} ({len(batch)} 条, "
              f"~{sum(len(e['text']) for e in batch)} chars)")

        # 构建翻译 prompt
        numbered_lines = []
        for entry in batch:
            # 使用 offset 作为 ID（唯一标识）
            oid = entry["offset"]
            text = entry["text"]
            max_chars = entry["available_chars"]
            numbered_lines.append(f"[{oid}] {text}")

        prompt = (
            "翻译以下游戏 UI 文本为中文。每行 [ID] 是唯一标识，保留不变。"
            "行数必须与输入完全一致。翻译要简洁。\n\n"
            + "\n".join(numbered_lines)
        )

        try:
            response = call_api(prompt, SYSTEM_PROMPT)
            parsed = parse_numbered_response(response, [e["offset"] for e in batch])

            for entry in batch:
                oid = entry["offset"]
                if oid in parsed:
                    translations[oid] = parsed[oid]
                else:
                    # 未翻译，保留原文
                    print(f"    ⚠ 未返回翻译: {oid}")
                    translations[oid] = entry["text"]

        except RuntimeError as e:
            print(f"    ✗ 批次失败: {e}")
            for entry in batch:
                translations[entry["offset"]] = entry["text"]

        # 每批次保存进度
        progress_path.parent.mkdir(parents=True, exist_ok=True)
        with open(progress_path, "w", encoding="utf-8") as f:
            json.dump(translations, f, ensure_ascii=False, indent=2)

        time.sleep(0.3)

    return translations


# ──────────────────────────────────────────────────────────────────────────────
# DLL Patch
# ──────────────────────────────────────────────────────────────────────────────

def read_us_string(data: bytes, offset: int) -> tuple[str, int, int]:
    """读取 #US heap 字符串。
    
    Returns: (text, content_offset, char_count)
    """
    # 读取压缩长度
    b0 = data[offset]
    if b0 < 0x80:
        blob_len = b0
        prefix_len = 1
    elif b0 < 0xC0:
        blob_len = ((b0 & 0x3F) << 8) | data[offset + 1]
        prefix_len = 2
    else:
        blob_len = (((b0 & 0x1F) << 24) | (data[offset+1] << 16) |
                    (data[offset+2] << 8) | data[offset+3])
        prefix_len = 4

    content_offset = offset + prefix_len
    # blob_len = utf16_bytes + trailing_byte
    utf16_len = blob_len - 1
    char_count = utf16_len // 2

    text = data[content_offset:content_offset + utf16_len].decode("utf-16-le", errors="replace")
    return text, content_offset, char_count


def write_us_string(data: bytearray, offset: int, original_text: str,
                    new_text: str) -> bool:
    """在 #US heap 中原地替换字符串。
    
    保持 blob_length 不变，用空格填充。
    Returns: True if successful
    """
    text, content_offset, char_count = read_us_string(data, offset)

    # 验证原文匹配（允许空白差异）
    if text.strip() != original_text.strip():
        return False

    # 截断或填充
    if len(new_text) > char_count:
        new_text = new_text[:char_count]
    elif len(new_text) < char_count:
        new_text = new_text + " " * (char_count - len(new_text))

    # 写入 UTF-16LE
    encoded = new_text.encode("utf-16-le")
    assert len(encoded) == char_count * 2

    data[content_offset:content_offset + len(encoded)] = encoded

    # 设置 trailing byte 为 0x01（含非ASCII字符）
    trailing_offset = content_offset + char_count * 2
    data[trailing_offset] = 0x01

    return True


# ──────────────────────────────────────────────────────────────────────────────
# 主流程
# ──────────────────────────────────────────────────────────────────────────────

def main():
    parser = argparse.ArgumentParser(description="DLL 白名单精准 patch")
    parser.add_argument("--translate-only", action="store_true", help="只翻译不patch")
    parser.add_argument("--patch-only", action="store_true", help="只patch(需已有翻译)")
    parser.add_argument("--dry-run", action="store_true", help="不实际写入文件")
    parser.add_argument("--no-deploy", action="store_true", help="不复制到游戏目录")
    args = parser.parse_args()

    # 加载白名单
    wl = json.load(open(WHITELIST_PATH, encoding="utf-8"))
    entries = wl["whitelist"]
    print(f"白名单: {len(entries)} 条")

    # ── Step 1: 翻译 ──
    if not args.patch_only:
        print("\n═══ 翻译阶段 ═══")
        translations = batch_translate_entries(entries, TRANSLATIONS_CACHE)
        print(f"翻译完成: {len(translations)} 条")

        if args.translate_only:
            return
    else:
        if not TRANSLATIONS_CACHE.exists():
            print(f"✗ 翻译缓存不存在: {TRANSLATIONS_CACHE}")
            sys.exit(1)
        translations = json.load(open(TRANSLATIONS_CACHE, encoding="utf-8"))
        print(f"已加载翻译缓存: {len(translations)} 条")

    # ── Step 2: Patch DLL ──
    print("\n═══ Patch 阶段 ═══")

    if not DLL_ORIGINAL.exists():
        print(f"✗ 原始 DLL 不存在: {DLL_ORIGINAL}")
        sys.exit(1)

    dll_data = bytearray(open(DLL_ORIGINAL, "rb").read())
    print(f"DLL 大小: {len(dll_data):,} bytes")

    patched = 0
    skipped = 0
    truncated = 0
    errors = []

    for entry in entries:
        offset = entry["offset_dec"]
        expected_text = entry["text"]
        max_chars = entry["available_chars"]

        # 获取翻译
        zh_text = translations.get(entry["offset"], expected_text)

        # 跳过未翻译的
        if zh_text == expected_text:
            skipped += 1
            continue

        # 检查是否需要截断
        if len(zh_text) > max_chars:
            zh_text = zh_text[:max_chars]
            truncated += 1

        if args.dry_run:
            patched += 1
            if patched <= 10:
                print(f"  [dry-run] 0x{offset:08x}: {expected_text[:40]}... → {zh_text[:40]}...")
            continue

        # 实际写入
        success = write_us_string(dll_data, offset, expected_text, zh_text)
        if success:
            patched += 1
        else:
            # 验证失败 - 可能offset不对
            actual, _, _ = read_us_string(dll_data, offset)
            errors.append(f"0x{offset:08x}: 期望 {expected_text[:40]}... 实际 {actual[:40]}...")

    print(f"\n结果: {patched} patched, {skipped} skipped, "
          f"{truncated} truncated, {len(errors)} errors")

    if errors:
        print(f"\n⚠ 错误 (前10):")
        for e in errors[:10]:
            print(f"  {e}")

    if args.dry_run:
        print("\n(dry-run 模式，未实际修改文件)")
        return

    # 保存
    DLL_OUTPUT.parent.mkdir(parents=True, exist_ok=True)
    with open(DLL_OUTPUT, "wb") as f:
        f.write(dll_data)
    print(f"\n✓ 输出: {DLL_OUTPUT} ({len(dll_data):,} bytes)")

    # 部署
    if not args.no_deploy and GAME_DATA.exists():
        dest = GAME_DATA / "Assembly-CSharp.dll"
        backup = GAME_DATA / "Assembly-CSharp.dll.bak"
        if not backup.exists() and dest.exists():
            shutil.copy2(dest, backup)
            print(f"  备份: {backup}")
        shutil.copy2(DLL_OUTPUT, dest)
        print(f"  ✓ 已部署到: {dest}")


if __name__ == "__main__":
    main()
