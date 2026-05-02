#!/usr/bin/env python3
"""
批量汉化脚本 - Mao's Legacy 1.8.5
将 1.8.5/resources.assets.chinese/ 中所有未汉化行翻译为中文
"""
import os, json, re, time, requests

# ── 配置 ──────────────────────────────────────────────
BASE    = os.path.dirname(os.path.abspath(__file__))
NEW_OR  = os.path.join(BASE, "1.8.5/resources.assets.original")
NEW_CN  = os.path.join(BASE, "1.8.5/resources.assets.chinese")
API_URL = "http://192.168.50.3:18000/v1/chat/completions"
API_KEY = "sk-lexwdex"
MODEL   = "gpt-5.4-nano"
BATCH   = 20   # 每次 API 调用翻译的行数

# ── 跳过的文件（字符集规则，不是游戏文本）───────────────
SKIP_FILES = {
    "LineBreaking Following Characters",
    "LineBreaking Leading Characters",
}

# ── 检测逻辑 ─────────────────────────────────────────
# 纯数字/符号行，无需翻译
SKIP_RE     = re.compile(r'^[\d\s;,.\-_:+*/#@!%^&()=\[\]{}<>|\\~`\'"]*$')
# 含中文字符
HAS_ZH      = re.compile(r'[\u4e00-\u9fff\u3400-\u4dbf]')
# 纯 XML 结构标签行，如 <name>  <end way>  <new event>
TAG_ONLY_RE = re.compile(r'^\s*<[^>]+>\s*$')


def needs_translation(line: str) -> bool:
    s = line.strip()
    if not s:
        return False
    if TAG_ONLY_RE.match(s):
        return False   # 纯结构标签，保留原样
    if SKIP_RE.match(s):
        return False
    return True


# ── 标签保护（防止 AI 翻译 <color=...> 等标签）────────
def protect_tags(text: str):
    tags: list[str] = []
    def repl(m):
        idx = len(tags)
        tags.append(m.group())
        return f'__T{idx}__'
    return re.sub(r'<[^>]+>', repl, text), tags


def restore_tags(text: str, tags: list[str]) -> str:
    for i, tag in enumerate(tags):
        text = text.replace(f'__T{i}__', tag)
    return text


# ── 调用 GPT API 翻译一批文本 ─────────────────────────
def translate_batch(lines: list[str]) -> list[str]:
    protected, all_tags = [], []
    for ln in lines:
        p, tags = protect_tags(ln)
        protected.append(p)
        all_tags.append(tags)

    numbered = "\n".join(f"{i+1}. {l}" for i, l in enumerate(protected))
    prompt = (
        "你是一个历史政治类游戏汉化助手。"
        "游戏背景为冷战时期，涉及中国（中华人民共和国）、法国、苏联等国。\n"
        "请将以下编号的外语文本（俄语或英语）翻译为简明中文。\n\n"
        "翻译规则：\n"
        "1. 严格按「数字. 翻译结果」格式逐行返回，不得合并或跳行\n"
        "2. 占位符（__T0__、__T1__ 等）原样保留，不翻译、不删除\n"
        "3. 分号、换行符、特殊符号保持原有格式\n"
        "4. 人名地名使用惯用中文译名（Мао→毛、Цзян→江、Ширак→希拉克 等）\n"
        "5. 只输出翻译结果，不要解释或附言\n\n"
        f"{numbered}"
    )

    for attempt in range(3):
        try:
            resp = requests.post(
                API_URL,
                headers={"Authorization": f"Bearer {API_KEY}",
                         "Content-Type": "application/json"},
                json={"model": MODEL,
                      "messages": [{"role": "user", "content": prompt}],
                      "temperature": 0.3},
                timeout=90,
            )
            resp.raise_for_status()
            content = resp.json()["choices"][0]["message"]["content"].strip()

            # 解析编号结果
            parsed: dict[int, str] = {}
            for raw_line in content.splitlines():
                m = re.match(r'^(\d+)[.)]\s*(.*)', raw_line.strip())
                if m:
                    parsed[int(m.group(1)) - 1] = m.group(2).strip()

            # 还原标签，fallback 到原文
            result = []
            for i, orig in enumerate(lines):
                zh = parsed.get(i, "")
                if zh:
                    result.append(restore_tags(zh, all_tags[i]))
                else:
                    result.append(orig)   # 解析失败时保留原文
            return result

        except Exception as e:
            print(f"      ⚠ 第 {attempt+1}/3 次失败: {e}")
            time.sleep(3)

    return lines   # 全部失败，返回原文


# ── 处理单个文件 ──────────────────────────────────────
def process_file(filename: str) -> tuple[str, int, int]:
    name = filename.rsplit("-resources.assets-", 1)[0]

    if name in SKIP_FILES:
        return name, 0, 0

    or_path = os.path.join(NEW_OR, filename)
    cn_path = os.path.join(NEW_CN, filename)
    if not os.path.exists(or_path) or not os.path.exists(cn_path):
        return name, 0, 0

    with open(or_path, encoding="utf-8") as f:
        or_data = json.load(f)
    with open(cn_path, encoding="utf-8") as f:
        cn_data = json.load(f)

    or_lines = (or_data.get("m_Script") or "").splitlines()
    cn_lines = (cn_data.get("m_Script") or "").splitlines()

    # 保证行数对齐
    while len(cn_lines) < len(or_lines):
        cn_lines.append(or_lines[len(cn_lines)])

    # 收集需要翻译的行 (索引, 原文)
    to_translate: list[tuple[int, str]] = []
    for i, (orig, zh) in enumerate(zip(or_lines, cn_lines)):
        if not needs_translation(orig.strip()):
            continue
        if HAS_ZH.search(zh):
            continue   # 已有中文，跳过
        if orig.strip() == zh.strip():
            to_translate.append((i, orig.strip()))

    if not to_translate:
        return name, 0, 0

    translated_count = 0
    batches = [to_translate[s:s+BATCH] for s in range(0, len(to_translate), BATCH)]

    for bi, batch in enumerate(batches, 1):
        orig_texts = [t for _, t in batch]
        results    = translate_batch(orig_texts)

        for (idx, _), translated in zip(batch, results):
            if translated and translated != cn_lines[idx].strip():
                # 保留原始行的缩进
                indent = len(cn_lines[idx]) - len(cn_lines[idx].lstrip())
                cn_lines[idx] = " " * indent + translated
                translated_count += 1

        # 每批次后立即写入，防止中断丢失
        cn_data["m_Script"] = "\r\n".join(cn_lines)
        with open(cn_path, "w", encoding="utf-8") as f:
            json.dump(cn_data, f, ensure_ascii=False, indent=2)

        pct = bi / len(batches) * 100
        print(f"      批次 {bi}/{len(batches)} ({pct:.0f}%) 完成", end="\r", flush=True)

    print()   # 换行
    return name, len(to_translate), translated_count


# ── 主流程 ────────────────────────────────────────────
def main():
    files = sorted(f for f in os.listdir(NEW_CN) if f.endswith(".json"))

    total_found  = 0
    total_done   = 0

    print(f"共 {len(files)} 个文件，开始翻译...\n")
    for i, filename in enumerate(files, 1):
        name = filename.rsplit("-resources.assets-", 1)[0]
        print(f"[{i:2}/{len(files)}] {name}", flush=True)

        name, found, done = process_file(filename)
        total_found += found
        total_done  += done

        if found == 0:
            print(f"      → 无需翻译")
        else:
            print(f"      → 翻译完成 {done}/{found} 行")

    print(f"\n{'='*60}")
    print(f"全部完成：翻译 {total_done}/{total_found} 行")
    print(f"文件保存于：{NEW_CN}")


if __name__ == "__main__":
    main()
