#!/usr/bin/env python3
"""
dll_extract.py  v2
从 Assembly-CSharp.dll 的 #US heap 提取英文游戏文本。
输出 dll_strings/original.json

过滤策略（排除技术/调试字符串，保留玩家可见文本）：
  ✓ 字符数 >= 10
  ✓ ASCII 可打印字符占比 >= 70%（排除俄文/中文）
  ✓ 含至少 1 个空格
  ✗ 排除：以 ": " / ":\n" 结尾（调试标签）
  ✗ 排除：包含 "===" / "---" / ">>>" （分隔符/调试）
  ✗ 排除：以 "Text:" / "text:" 结尾（编号调试标签）
  ✗ 排除：Unity/C# 内部字符串（含 "UnityEngine." / "Assembly-" / "System."）
  ✗ 排除：纯格式模板（去掉占位符后 < 8 字符）
  ✗ 排除：看起来像文件路径或 URL

用法：
  uv run python3 dll_extract.py
"""
import struct, json, os, re

DLL = "/Users/lex/Library/Application Support/Steam/steamapps/common/Mao's Legacy/China.app/Contents/Resources/Data/Managed/Assembly-CSharp.dll"
OUT_DIR = "dll_strings"


def find_us_heap(data: bytes) -> tuple[int, int]:
    bsjb = data.find(b"BSJB")
    if bsjb < 0:
        raise RuntimeError("Not a .NET assembly")
    ver_len = struct.unpack_from("<I", data, bsjb + 12)[0]
    ver_len = (ver_len + 3) & ~3
    stream_count = struct.unpack_from("<H", data, bsjb + 16 + ver_len + 2)[0]
    pos = bsjb + 16 + ver_len + 4
    for _ in range(stream_count):
        s_off = struct.unpack_from("<I", data, pos)[0]
        s_sz  = struct.unpack_from("<I", data, pos + 4)[0]
        name_end = data.index(b'\x00', pos + 8)
        name = data[pos + 8:name_end].decode("ascii")
        name_len = ((name_end - (pos + 8) + 4) & ~3)
        pos += 8 + name_len
        if name == "#US":
            return bsjb + s_off, s_sz
    raise RuntimeError("#US heap not found")


def iter_us_strings(data: bytes, heap_abs: int, heap_size: int):
    p = 1
    while p < heap_size:
        abs_off = heap_abs + p
        b0 = data[abs_off]
        if b0 == 0:
            p += 1
            continue
        if b0 & 0x80 == 0:
            length = b0;           hs = 1
        elif b0 & 0xC0 == 0x80:
            length = ((b0 & 0x3F) << 8) | data[abs_off + 1]; hs = 2
        else:
            length = ((b0 & 0x1F) << 24) | (data[abs_off+1] << 16) | \
                     (data[abs_off+2] << 8) | data[abs_off+3];     hs = 4

        if length <= 0 or abs_off + hs + length > heap_abs + heap_size:
            p += 1
            continue
        content_len = length - 1
        if content_len % 2 != 0:
            p += hs + length
            continue
        raw = data[abs_off + hs : abs_off + hs + content_len]
        try:
            text = raw.decode("utf-16-le")
        except Exception:
            p += hs + length
            continue
        yield abs_off, hs, length, text
        p += hs + length


_PRINTABLE_ASCII = set(range(0x20, 0x7F)) | {0x09, 0x0A, 0x0D}

# 技术字符串排除模式
_TECH_PATTERNS = [
    r'UnityEngine\.',
    r'Assembly-',
    r'System\.',
    r'Microsoft\.',
    r'Mono\.',
    r'NullReferenceException',
    r'ArgumentException',
    r'^[A-Za-z0-9_]+\.[A-Za-z0-9_]+$',   # 单个点分标识符
    r'\.cs:',                               # 代码文件引用
]
_TECH_RE = re.compile('|'.join(_TECH_PATTERNS))

# 调试标签模式（结尾是冒号+空格/换行，或以 === 包围）
_DEBUG_PATTERNS = [
    r'===',
    r'---',
    r'>>>',
    r'<<<',
    r':\s*$',           # 以冒号结尾
    r'Text:\s*\n',      # "EndingXX Text:\n"
    r'^\s*\[',          # [DEBUG] 风格
]
_DEBUG_RE = re.compile('|'.join(_DEBUG_PATTERNS))


def is_game_text(text: str) -> bool:
    # 最小长度
    if len(text) < 10:
        return False
    # 必须有空格（排除单词标识符）
    if ' ' not in text:
        return False
    # ASCII 可打印字符占比 >= 70%
    ascii_count = sum(1 for c in text if ord(c) in _PRINTABLE_ASCII)
    if ascii_count / len(text) < 0.70:
        return False
    # 排除技术字符串
    if _TECH_RE.search(text):
        return False
    # 排除调试字符串
    if _DEBUG_RE.search(text):
        return False
    # 排除纯格式模板（去掉占位符后无实质内容）
    stripped = re.sub(r'\{[^}]*\}|<[^>]+>', '', text).strip()
    if len(stripped) < 8:
        return False
    # 必须包含至少一个小写字母（排除全大写常量）
    if not re.search(r'[a-z]', text):
        return False
    # 排除看起来像 key=value 对
    if re.fullmatch(r'[A-Za-z_][A-Za-z0-9_]*\s*=\s*\S+', text.strip()):
        return False
    return True


def main():
    os.makedirs(OUT_DIR, exist_ok=True)
    print(f"读取 DLL …")
    with open(DLL, "rb") as f:
        data = f.read()
    heap_abs, heap_size = find_us_heap(data)
    print(f"#US heap 0x{heap_abs:X}, 大小 0x{heap_size:X}")

    results: dict = {}
    total = 0
    for abs_off, hs, length, text in iter_us_strings(data, heap_abs, heap_size):
        total += 1
        if is_game_text(text):
            key = f"0x{abs_off:08X}"
            results[key] = {
                "offset": abs_off,
                "length": length,
                "header_size": hs,
                "available_chars": (length - 1) // 2,
                "text": text
            }

    out_path = os.path.join(OUT_DIR, "original.json")
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(results, f, ensure_ascii=False, indent=2)

    kept = len(results)
    total_chars = sum(v["available_chars"] for v in results.values())
    print(f"扫描总数: {total:,}  保留: {kept:,}  总字符: {total_chars:,}")
    print(f"输出: {out_path}")


if __name__ == "__main__":
    main()
