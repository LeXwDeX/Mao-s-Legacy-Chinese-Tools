#!/usr/bin/env python3
"""
智能替换 v2：处理实际换行符，只在 C# 字符串字面量中替换文本。
"""
import json
import re
from pathlib import Path

# 读取翻译
print("加载翻译数据...")
with open('dll_strings/translated.json', 'r', encoding='utf-8') as f:
    translations = json.load(f)

# 准备替换映射（原文 -> 译文），过滤掉太短的
replacements = []
for key, entry in translations.items():
    orig_text = entry['text']
    translated = entry.get('translated', '')
    
    # 跳过无效翻译
    if not translated or orig_text == translated or len(orig_text.strip()) < 3:
        continue
    
    # 🔥 关键修复：将实际换行符转换为转义序列
    # C# 字符串字面量中的 \n 是转义字符，但 JSON 解析后变成了实际换行符
    translated_escaped = translated.replace('\n', '\\n').replace('\r', '\\r').replace('\t', '\\t')
    
    replacements.append((orig_text, translated_escaped))

print(f"准备替换: {len(replacements)} 条")

# 正则表达式：匹配 C# 字符串字面量
STRING_PATTERN = re.compile(r'"(?:[^"\\]|\\.)*"')

def process_file(file_path, replacements):
    """处理单个文件"""
    with open(file_path, 'r', encoding='utf-8', errors='ignore') as f:
        content = f.read()
    
    original = content
    
    # 使用正则替换：在匹配到的每个字符串字面量中应用所有替换
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

# 回滚到备份
print("回滚到备份版本...")
import shutil
shutil.rmtree('rebuild/baseline')
shutil.copytree('rebuild/baseline_backup', 'rebuild/baseline')

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
