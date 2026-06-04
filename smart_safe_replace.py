#!/usr/bin/env python3
"""
智能替换脚本 - 只在C#字符串字面量中替换文本（跳过含未转义引号的翻译）
"""
import json
import re
import sys
from pathlib import Path

def escape_csharp_string(text):
    """转义C#字符串中的特殊字符"""
    # 首先还原转义序列（因为JSON解析时已经处理了）
    text = text.replace('\n', '\\n')
    text = text.replace('\r', '\\r')
    text = text.replace('\t', '\\t')
    # 转义双引号
    text = text.replace('"', '\\"')
    # 转义反斜杠（但保留已经转义的序列）
    text = re.sub(r'\\(?![nrt"\\])', r'\\\\', text)
    return text

def replace_safe(text, orig, trans):
    """安全替换：只替换不在字符串字面量中的文本"""
    result = []
    i = 0
    while i < len(text):
        # 检测字符串字面量开始
        if text[i] == '"':
            # 找到字符串开始
            result.append('"')
            i += 1
            # 收集字符串内容直到结束
            string_content = []
            while i < len(text):
                if text[i] == '\\' and i + 1 < len(text):
                    # 转义字符，保留两个字符
                    string_content.append(text[i:i+2])
                    i += 2
                elif text[i] == '"':
                    # 字符串结束
                    break
                else:
                    string_content.append(text[i])
                    i += 1
            
            # 现在处理字符串内容 - 只替换不包含裸引号的翻译
            content = ''.join(string_content)
            
            # 检查原文是否包含未转义的引号
            if '"' not in orig:
                # 安全替换
                content = content.replace(orig, trans)
            
            result.append(content)
            
            # 添加结束的引号
            if i < len(text):
                result.append('"')
                i += 1
        else:
            result.append(text[i])
            i += 1
    
    return ''.join(result)

def main():
    # 读取翻译文件
    with open('dll_strings/translated.json', 'r', encoding='utf-8') as f:
        translations = json.load(f)
    
    # 准备替换列表
    replacements = []
    skipped = 0
    for offset, entry in translations.items():
        orig = entry['text']
        trans = entry.get('translated', '')
        
        # 跳过空翻译或相同翻译
        if not trans or orig == trans:
            continue
        
        # 跳过太短的文本
        if len(orig.strip()) < 3:
            continue
        
        # 转义译文中的特殊字符
        trans_escaped = escape_csharp_string(trans)
        
        # 检查原文是否包含未转义的双引号
        if '"' in orig and '\\"' not in orig:
            # 原文包含未转义的引号，这条会导致问题，跳过
            skipped += 1
            continue
        
        replacements.append((orig, trans_escaped))
    
    print(f"准备替换: {len(replacements)} 条翻译 (跳过 {skipped} 条有问题的)")
    
    # 处理所有 .cs 文件
    cs_files = list(Path('rebuild/baseline').rglob('*.cs'))
    modified_count = 0
    
    print(f"处理 {len(cs_files)} 个文件...")
    
    for file_path in cs_files:
        try:
            content = file_path.read_text(encoding='utf-8')
            original = content
            
            # 应用所有替换
            for orig, trans in replacements:
                content = replace_safe(content, orig, trans)
            
            # 如果修改了，写回文件
            if content != original:
                file_path.write_text(content, encoding='utf-8')
                modified_count += 1
                print(f"  修改: {file_path.name}")
        
        except Exception as e:
            print(f"  错误处理 {file_path}: {e}", file=sys.stderr)
    
    print(f"\n完成! 修改了 {modified_count} 个文件")

if __name__ == '__main__':
    main()
