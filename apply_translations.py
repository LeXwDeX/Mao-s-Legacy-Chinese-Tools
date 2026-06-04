#!/usr/bin/env python3
"""
批量替换 rebuild/baseline/ 中的英文字符串为中文翻译。
"""
import json
from pathlib import Path
import shutil

# 读取翻译
print("加载翻译数据...")
with open('dll_strings/translated.json', 'r', encoding='utf-8') as f:
    translations = json.load(f)

# 准备替换：提取有效翻译
replacements = []
for key, entry in translations.items():
    orig_text = entry['text']
    translated = entry.get('translated', '')
    
    # 跳过无效翻译
    if not translated or orig_text == translated:
        continue
    
    # 跳过太短的字符串
    if len(orig_text.strip()) < 3:
        continue
    
    replacements.append((orig_text, translated))

print(f"准备替换: {len(replacements)} 条")

# 备份原始文件
backup_dir = Path('rebuild/baseline_backup')
if not backup_dir.exists():
    print("创建备份...")
    shutil.copytree('rebuild/baseline', backup_dir)

# 读取所有 .cs 文件并替换
cs_files = list(Path('rebuild/baseline').rglob('*.cs'))
total_replacements = 0
modified_files = 0

print(f"处理 {len(cs_files)} 个 .cs 文件...")

for i, cs_file in enumerate(cs_files):
    if (i + 1) % 50 == 0:
        print(f"  进度: {i+1}/{len(cs_files)}")
    
    content = cs_file.read_text(encoding='utf-8', errors='ignore')
    original_content = content
    file_replacements = 0
    
    # 对每个翻译对做替换
    for orig_text, translated in replacements:
        count = content.count(orig_text)
        if count > 0:
            content = content.replace(orig_text, translated)
            file_replacements += count
    
    # 如果文件被修改，写回
    if content != original_content:
        cs_file.write_text(content, encoding='utf-8')
        total_replacements += file_replacements
        modified_files += 1

print(f"\n替换完成:")
print(f"  修改文件: {modified_files}")
print(f"  总替换次数: {total_replacements}")
print(f"  平均每个文件: {total_replacements/max(modified_files,1):.1f} 次")
