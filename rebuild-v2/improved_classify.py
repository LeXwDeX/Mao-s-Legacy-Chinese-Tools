"""
改进的字符串分类器
修复误分类问题
"""
import re
import json
from pathlib import Path

def extract_strings_from_file(filepath):
    """提取单个文件中的所有字符串字面量，包含更长的上下文"""
    with open(filepath, 'r', encoding='utf-8', errors='ignore') as f:
        content = f.read()
    
    pattern = r'(?:"|@")((?:[^"\\]|\\.)*)"'
    matches = list(re.finditer(pattern, content))
    
    strings = []
    for match in matches:
        string_content = match.group(1)
        position = match.start()
        match_end = match.end()
        line_num = content[:position].count('\n') + 1
        
        # 获取前后 300 字符的上下文
        context_start = max(0, position - 300)
        context_end = min(len(content), match_end + 300)
        context = content[context_start:context_end]
        
        strings.append({
            'content': string_content,
            'line': line_num,
            'context': context,
            'file': filepath.name,
            'position': position
        })
    
    return strings

def classify_string(string_data):
    """改进的分类器"""
    content = string_data['content'].strip()
    context = string_data['context']
    
    # 跳过空字符串和纯空格
    if not content or len(content) < 2:
        return '空字符串'
    
    # 检查上下文中的代码模式
    context_before = context[:len(context)//2]  # 匹配前的上下文
    context_after = context[len(context)//2:]   # 匹配后的上下文
    
    # 1. UI 文本检测（最优先，避免被 API 误分类）
    ui_patterns = [
        r'\.text\s*=\s*["\']',  # .text = "XXX"
        r'TextMesh\.text',
        r'SetActiveText\s*\(',
        r'\["text"\]\s*=\s*["\']',
        r'GetComponent<[^>]*Text[^>]*>\s*\(\)\s*\.\s*text\s*=',
    ]
    
    for pattern in ui_patterns:
        if re.search(pattern, context_before + '[STRING]' + context_after):
            # 确保字符串在赋值的右侧
            match_pos = (context_before + '[STRING]').find('[STRING]')
            assignment_match = re.search(r'\.text\s*=\s*$', context_before[match_pos-50:match_pos])
            if assignment_match or '.text = ' in context_before[-100:]:
                return 'UI文本'
    
    # 2. API 参数检测（更精确的上下文匹配）
    api_patterns = [
        # GameObject.Find("XXX")
        (r'GameObject\.Find\s*\(\s*"$', 'GameObject.Find'),
        # transform.Find("XXX")
        (r'transform\.Find\s*\(\s*"$', 'transform.Find'),
        # Input.GetXXX("XXX")
        (r'Input\.Get\w+\s*\(\s*"$', 'Input.Get'),
        # PlayerPrefs 键名（第一个参数）
        (r'PlayerPrefs\.\w+\s*\(\s*"$', 'PlayerPrefs.Key'),
    ]
    
    for pattern, label in api_patterns:
        if re.search(pattern, context_before):
            return f'API参数({label})'
    
    # 3. PlayerPrefs 值（不应该翻译）
    prefs_value_pattern = r'PlayerPrefs\.\w+\s*\([^,]+,\s*"$'
    if re.search(prefs_value_pattern, context_before):
        return 'PlayerPrefs.Value'
    
    # 4. Debug.Log（不应该翻译）
    if 'Debug.Log' in context_before or 'Debug.LogWarning' in context_before:
        return '日志'
    
    # 5. 标识符检测
    if len(content) < 50:
        id_patterns = [
            r'^[A-Z][a-zA-Z0-9]*$',  # 驼峰
            r'^[a-z_][a-z0-9_]*$',   # 下划线
            r'^[0-9_.]+$',           # 数字
        ]
        for pattern in id_patterns:
            if re.match(pattern, content):
                return '标识符'
    
    # 6. 其他（默认）
    return '其他'

# 运行扫描
cs_files = list(Path('decompiled').rglob('*.cs'))
all_strings = []

for filepath in cs_files:
    strings = extract_strings_from_file(filepath)
    for s in strings:
        s['category'] = classify_string(s)
    all_strings.extend(strings)

# 统计
categories = {}
for s in all_strings:
    cat = s['category']
    if cat not in categories:
        categories[cat] = []
    categories[cat].append(s)

print("=== 改进后的分类统计 ===")
for cat, items in sorted(categories.items(), key=lambda x: len(x[1]), reverse=True):
    print(f"{cat}: {len(items)}")

print("\n=== 各类别样本 ===")
for cat in sorted(categories.keys()):
    items = categories[cat]
    print(f"\n{cat} (共 {len(items)} 个):")
    for i, item in enumerate(items[:15], 1):
        content = item['content'][:80]
        print(f"  {i}. {content}")

# 保存结果
with open('improved_analysis.json', 'w', encoding='utf-8') as f:
    json.dump({
        'total': len(all_strings),
        'by_category': {cat: len(items) for cat, items in categories.items()},
        'all_strings': all_strings
    }, f, ensure_ascii=False, indent=2)

print(f"\n改进后的分析已保存到 improved_analysis.json")
