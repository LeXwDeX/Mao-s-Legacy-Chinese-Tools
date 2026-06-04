#!/usr/bin/env python3
"""
智能替换 v3：只替换不含 " 字符的翻译（避免破坏字符串字面量结构）
"""
import json
import re
import shutil
from pathlib import Path

# 读取翻译
print("加载翻译数据...")
with open('dll_strings/translated.json', 'r', encoding='utf-8') as f:
    translations = json.load(f)

# 准备替换映射，过滤掉含有 " 的（这些会破坏字符串字面量）
replacements = []
skipped_quote = 0
for key, entry in translations.items():
    orig_text = entry['text']
    translated = entry.get('translated', '')
    
    if not translated or orig_text == translated or len(orig_text.strip()) < 3:
        continue
    
    # 跳过含引号的（这些会破坏字符串字面量结构）
    if '"' in orig_text or '"' in translated:
        skipped_quote += 1
        continue
    
    # 转义实际换行符
    translated_escaped = translated.replace('\n', '\\n').replace('\r', '\\r').replace('\t', '\\t')
    replacements.append((orig_text, translated_escaped))

print(f"准备替换: {len(replacements)} 条")
print(f"跳过 (含 \") : {skipped_quote} 条")

# 回滚到备份
print("回滚到备份版本...")
shutil.rmtree('rebuild/baseline')
shutil.copytree('rebuild/baseline_backup', 'rebuild/baseline')

# 正则表达式
STRING_PATTERN = re.compile(r'"(?:[^"\\]|\\.)*"')

def process_file(file_path, replacements):
    with open(file_path, 'r', encoding='utf-8', errors='ignore') as f:
        content = f.read()
    
    original = content
    
    for orig, trans in replacements:
        def replacer(match):
            full = match.group(0)
            if orig in full:
                return full.replace(orig, trans)
            return full
        content = STRING_PATTERN.sub(replacer, content)
    
    if content != original:
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(content)
        return True
    return False

# 处理所有 .cs 文件
cs_files = list(Path('rebuild/baseline').rglob('*.cs'))
modified_count = 0

print(f"处理 {len(cs_files)} 个文件...")

for i, file_path in enumerate(cs_files):
    if process_file(file_path, replacements):
        modified_count += 1
    if (i + 1) % 100 == 0:
        print(f"  进度: {i+1}/{len(cs_files)}")

print(f"\n完成!")
print(f"修改了 {modified_count} 个文件")
