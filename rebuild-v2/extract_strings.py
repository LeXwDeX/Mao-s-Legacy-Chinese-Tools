#!/usr/bin/env python3
"""
从反编译源码中提取所有字符串字面量并分类。
分类: [API参数 | UI文本 | 标识符 | 日志 | 其他]
"""

import re
import json
from pathlib import Path

def extract_strings_from_file(filepath):
    """提取单个文件中的所有字符串字面量"""
    with open(filepath, 'r', encoding='utf-8', errors='ignore') as f:
        content = f.read()
    
    # 匹配 C# 字符串字面量: "..." 或 @"..."
    pattern = r'(?:"|@")((?:[^"\\]|\\.)*)"'
    matches = re.finditer(pattern, content)
    
    strings = []
    for match in matches:
        string_content = match.group(1)
        position = match.start()
        line_num = content[:position].count('\n') + 1
        
        # 获取上下文（前后 50 字符）
        context_start = max(0, position - 50)
        context_end = min(len(content), match.end() + 50)
        context = content[context_start:context_end]
        
        strings.append({
            'content': string_content,
            'line': line_num,
            'context': context,
            'file': filepath.name
        })
    
    return strings

def classify_string(string_data):
    """分类字符串的用途"""
    content = string_data['content']
    context = string_data['context']
    
    # 黑名单检测
    blacklists = {
        'GameObject.Find', 'transform.Find', 'Input.Get',
        'PlayerPrefs.', 'Debug.Log', 'GetComponent',
        'AddComponent', 'SendMessage'
    }
    
    for api in blacklists:
        if api in context:
            return 'API参数'
    
    # UI 文本检测
    ui_keywords = ['.text', 'Text.text', 'TextMesh.text', 'GetComponent<Text']
    for keyword in ui_keywords:
        if keyword in context:
            return 'UI文本'
    
    # 标识符检测
    id_patterns = [r'^[A-Z][a-zA-Z0-9]*$', r'^[a-z_]+$', r'^[0-9_.]+$']
    for pattern in id_patterns:
        if re.match(pattern, content):
            return '标识符'
    
    # 日志检测
    if 'Debug.' in context or 'Console.' in context:
        return '日志'
    
    return '其他'

def main():
    # 扫描所有 .cs 文件
    cs_files = list(Path('decompiled').rglob('*.cs'))
    print(f"扫描 {len(cs_files)} 个 .cs 文件...")
    
    all_strings = []
    for filepath in cs_files:
        strings = extract_strings_from_file(filepath)
        for s in strings:
            s['category'] = classify_string(s)
        all_strings.extend(strings)
    
    print(f"提取 {len(all_strings)} 个字符串")
    
    # 按类别统计
    categories = {}
    for s in all_strings:
        cat = s['category']
        if cat not in categories:
            categories[cat] = []
        categories[cat].append(s)
    
    print("\n分类统计:")
    for cat, items in sorted(categories.items()):
        print(f"  {cat}: {len(items)}")
    
    # 保存到 JSON
    with open('string_analysis.json', 'w', encoding='utf-8') as f:
        json.dump({
            'total': len(all_strings),
            'categories': {k: len(v) for k, v in categories.items()},
            'samples': {k: v[:5] for k, v in categories.items()}
        }, f, ensure_ascii=False, indent=2)
    
    print("\n分析结果已保存到 string_analysis.json")
    
    # 生成黑名单
    blacklist = set()
    for item in categories.get('API参数', []):
        blacklist.add(item['content'])
    
    for item in categories.get('标识符', []):
        if len(item['content']) < 50:  # 只添加短标识符
            blacklist.add(item['content'])
    
    print(f"\n完整黑名单大小: {len(blacklist)}")
    
    with open('blacklist_full.json', 'w', encoding='utf-8') as f:
        json.dump(sorted(blacklist), f, ensure_ascii=False, indent=2)
    
    print("黑名单已保存到 blacklist_full.json")

if __name__ == '__main__':
    main()
