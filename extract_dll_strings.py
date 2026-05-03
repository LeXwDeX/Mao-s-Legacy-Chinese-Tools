#!/usr/bin/env python3
"""
extract_dll_strings.py
从反编译 C# 源码中提取硬编码 UI 字符串（language==0 分支内的字面量）。
输出结构化 JSON，用于后续精准 DLL patch。
"""
import re, json, os, ast
from pathlib import Path

DECOMPILED = Path("decompiled")
OUT = Path("dll_strings/hardcoded_ui_strings.json")

# 匹配 C# 字符串字面量（含插值字符串中的片段）
STRING_RE = re.compile(r'"((?:[^"\\]|\\.)*)"')

# 跳过明显是内部名/无需翻译的字符串
SKIP_PATTERNS = [
    r'^\s*$',            # 空字符串
    r'^[A-Z][a-zA-Z]+$', # 单驼峰词（可能是类名）
    r'^\d',              # 数字开头
    r'<color=',          # 颜色标签（不单独翻译）
    r'^_',               # 下划线开头（可能是内部键）
    r'^Main$|^Diplomacy$|^Event$|^Economy$|^Science$',  # 场景名
    r'^\{[0-9]\}',       # 格式占位符
]

def should_skip(s):
    for p in SKIP_PATTERNS:
        if re.search(p, s):
            return True
    return False

def extract_strings_from_file(path):
    """提取 language==0 分支内的所有字符串字面量。"""
    src = path.read_text(encoding="utf-8", errors="replace")
    results = []
    
    # 找 if (PlayerPrefs.GetInt("language") == 0) 块
    # 用简单行扫描方式：找 language == 0 后的 { ... } 块
    in_en_block = 0
    brace_depth = 0
    in_en_section = False
    current_method = ""
    
    lines = src.splitlines()
    for i, line in enumerate(lines):
        # 记录当前方法名
        m = re.search(r'(?:private|public|protected|void|string|int|bool)\s+\w+\s*\(', line)
        if m:
            current_method = line.strip()[:60]
        
        # 检测 language == 0 条件
        if re.search(r'language.*==\s*0|GetInt\("language"\)\s*==\s*0', line):
            in_en_section = True
            brace_depth = 0
            continue
        
        if in_en_section:
            brace_depth += line.count('{') - line.count('}')
            if brace_depth < 0:
                in_en_section = False
                continue
            # 提取此行的字符串字面量
            for s in STRING_RE.findall(line):
                s_clean = s.strip()
                if len(s_clean) >= 3 and not should_skip(s_clean):
                    results.append({
                        "file": path.name,
                        "method": current_method,
                        "line": i + 1,
                        "english": s_clean,
                    })
    return results

def main():
    all_strings = []
    cs_files = sorted(DECOMPILED.glob("*.cs"))
    cs_files += sorted(DECOMPILED.rglob("**/*.cs"))
    seen_files = set()
    
    for f in cs_files:
        if f in seen_files:
            continue
        seen_files.add(f)
        
        src = f.read_text(encoding="utf-8", errors="replace")
        if 'language' not in src or ('== 0' not in src and '!= 0' not in src):
            continue
        
        strings = extract_strings_from_file(f)
        all_strings.extend(strings)
    
    # 去重（相同 english 文本），保留所有来源位置
    by_text = {}
    for item in all_strings:
        t = item["english"]
        if t not in by_text:
            by_text[t] = {"english": t, "sources": [], "chinese": ""}
        by_text[t]["sources"].append({
            "file": item["file"],
            "method": item["method"],
            "line": item["line"],
        })
    
    result = sorted(by_text.values(), key=lambda x: x["english"])
    
    OUT.parent.mkdir(exist_ok=True)
    OUT.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")
    print(f"提取完成：{len(result)} 条唯一字符串 → {OUT}")
    
    # 按文件统计
    from collections import Counter
    file_counts = Counter(s["file"] for item in result for s in item["sources"])
    print("\n各文件字符串数：")
    for fname, cnt in file_counts.most_common(20):
        print(f"  {fname:<45} {cnt:3d}")

if __name__ == "__main__":
    main()
