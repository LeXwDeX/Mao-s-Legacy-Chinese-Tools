#!/usr/bin/env python3
"""
优化版：扫描 rebuild/ 目录中的 .cs 文件，统计 translated.json 中的翻译能找到多少。
用批量匹配提升性能。
"""
import json
from pathlib import Path

# 读取翻译
print("加载翻译数据...")
with open('dll_strings/translated.json', 'r', encoding='utf-8') as f:
    translations = json.load(f)

# 提取有效翻译 (过滤掉太短的)
valid_translations = []
for key, entry in translations.items():
    orig_text = entry['text'].strip()
    if len(orig_text) >= 3:
        valid_translations.append((key, orig_text, entry.get('translated', '')))

print(f"有效翻译: {len(valid_translations)} 条")

# 一次性读取所有 .cs 文件
print("读取 .cs 文件...")
cs_files = list(Path('rebuild/baseline').rglob('*.cs'))
all_code = ""
file_map = []
current_pos = 0

for cs_file in cs_files:
    content = cs_file.read_text(encoding='utf-8', errors='ignore')
    all_code += content + "\n"
    file_map.append((current_pos, current_pos + len(content), str(cs_file)))
    current_pos += len(content) + 1

print(f"总代码量: {len(all_code)} 字符 ({len(all_code)//1024} KB)")
print(f"文件数: {len(cs_files)}")

# 批量匹配
print("匹配中...")
found = 0
not_found = 0
examples = []

for key, orig_text, translated in valid_translations:
    pos = all_code.find(orig_text)
    if pos >= 0:
        found += 1
        if len(examples) < 5:
            # 找到对应文件
            for start, end, path in file_map:
                if start <= pos < end:
                    examples.append((orig_text, path))
                    break
    else:
        not_found += 1

total = found + not_found
print(f"\n统计结果:")
print(f"  找到: {found} ({100*found/total:.1f}%)")
print(f"  未找到: {not_found} ({100*not_found/total:.1f}%)")
print(f"  总计: {total}")

print(f"\n示例（前5个）:")
for orig, path in examples:
    print(f"  '{orig[:80]}{'...' if len(orig)>80 else ''}'")
    print(f"    -> {path}")
