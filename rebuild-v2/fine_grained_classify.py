"""
细粒度分类器 - 深入分析"其他"类别
"""
import re
import json
from pathlib import Path

def extract_strings_with_context(filepath):
    """提取字符串和完整上下文"""
    with open(filepath, 'r', encoding='utf-8', errors='ignore') as f:
        lines = f.readlines()
    
    strings = []
    for i, line in enumerate(lines):
        # 提取字符串字面量
        for match in re.finditer(r'"([^"]*)"', line):
            string_content = match.group(1)
            # 获取前后 5 行的上下文
            start = max(0, i - 5)
            end = min(len(lines), i + 6)
            context = ''.join(lines[start:end])
            
            strings.append({
                'content': string_content,
                'context': context,
                'file': filepath.name,
                'line_num': i + 1
            })
    
    return strings

def classify_fine_grained(string_data):
    """细粒度分类"""
    content = string_data['content'].strip()
    context = string_data['context']
    
    # 1. 空字符串和纯符号
    if not content or len(content) < 2:
        return 'empty'
    if re.match(r'^[\s\n\t\-_=|]+$', content):
        return 'symbol_only'
    
    # 2. 标识符和键名
    if re.match(r'^[a-z_]+$', content) and len(content) < 30:
        if content in ['language', 'voice_china', 'gamerules0', 'gamerules1', 'gamerules2', 
                       'gamerules3', 'gamerules4', 'gamerules5', 'gamerules6', 'gamerules8']:
            return 'prefs_key'
        return 'identifier'
    
    # 3. GameObject/Transform 查找参数
    if re.search(r'GameObject\.Find\s*\(\s*"' + re.escape(content) + r'"\s*\)', context):
        return 'gameobject_find_param'
    if re.search(r'transform\.Find\s*\(\s*"' + re.escape(content) + r'"\s*\)', context):
        return 'transform_find_param'
    
    # 4. Input 系统参数
    if re.search(r'Input\.Get\w+\s*\(\s*"' + re.escape(content) + r'"\s*\)', context):
        return 'input_param'
    
    # 5. PlayerPrefs 值（注意区分键名和值）
    # 键名模式: PlayerPrefs.GetInt("xxx")
    if re.search(r'PlayerPrefs\.\w+\s*\(\s*"' + re.escape(content) + r'"\s*[\),]', context):
        return 'prefs_key'
    # 值模式: PlayerPrefs.SetString("key", "value") 中的 value
    if re.search(r'PlayerPrefs\.Set\w+\s*\([^,]+,\s*"' + re.escape(content) + r'"\s*\)', context):
        return 'prefs_value'
    
    # 6. UI 文本（包含 HTML 标签或直接赋值给 text）
    if re.search(r'<size=|<color=|<b>|<i>|</size>|</color>|</b>|</i>', content):
        return 'ui_text_rich'
    if re.search(r'\.text\s*=\s*"' + re.escape(content) + r'"\s*;', context):
        return 'ui_text_assign'
    if re.search(r'GetComponent<[^>]*Text[^>]*>', context) and len(content) > 5:
        return 'ui_text_component'
    
    # 7. Debug 日志
    if 'Debug.Log' in context and len(content) > 10:
        return 'debug_log'
    
    # 8. URL 和文件路径
    if re.search(r'https?://|\.com|\.ru|\.txt|\.png|\.jpg', content):
        return 'url_or_path'
    
    # 9. 游戏内长文本
    if len(content) > 50 and re.search(r'[A-Za-zА-Яа-я]{3,}', content):
        return 'game_text_long'
    
    # 10. 游戏中的短标签/名称
    if 3 < len(content) < 50 and re.search(r'[A-Z][a-z]+|[А-Я][а-я]+', content):
        return 'game_label'
    
    # 11. 格式化字符串
    if re.search(r'\{[0-9]+\}|\{[a-z]+\}', content):
        return 'format_string'
    
    # 12. 数字
    if re.match(r'^[\d\.\-]+$', content):
        return 'number'
    
    return 'other'

# 扫描所有文件
all_strings = []
for cs_file in Path('decompiled').rglob('*.cs'):
    all_strings.extend(extract_strings_with_context(cs_file))

print(f"总共提取 {len(all_strings)} 个字符串\n")

# 分类
categories = {}
for s in all_strings:
    cat = classify_fine_grained(s)
    s['category'] = cat
    if cat not in categories:
        categories[cat] = []
    categories[cat].append(s)

# 输出统计
print("=== 细粒度分类统计 ===")
for cat in sorted(categories.keys()):
    count = len(categories[cat])
    if count > 0:
        print(f"{cat:30} {count:5} 个")

total_classified = sum(len(v) for k, v in categories.items() if k != 'other')
total_other = len(categories.get('other', []))
print(f"\n已分类: {total_classified}")
print(f"未分类: {total_other}")

# 显示各类别样本
print("\n=== 各类别样本 ===")
for cat in sorted(categories.keys()):
    if len(categories[cat]) > 0:
        print(f"\n【{cat}】({len(categories[cat])} 个)")
        samples = categories[cat][:10]
        for i, s in enumerate(samples, 1):
            content = s['content'][:80].replace('\n', '\\n')
            print(f"  {i:2}. {content}")

# 保存结果
with open('fine_grained_analysis.json', 'w', encoding='utf-8') as f:
    json.dump({
        'total': len(all_strings),
        'by_category': {k: len(v) for k, v in categories.items()},
        'categories': categories
    }, f, ensure_ascii=False, indent=2)

print(f"\n已保存到 fine_grained_analysis.json")
