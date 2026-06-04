#!/usr/bin/env python3
"""
翻译文本验证器
在应用翻译前检查潜在的布局问题
"""
import json
import re

def count_display_width(text):
    """
    计算文本的显示宽度（考虑中文字符宽度）
    - 英文字符、数字、标点 = 1单位
    - 中文字符 = 2单位（通常中文字符宽度是英文的2倍）
    """
    width = 0
    for char in text:
        # 检查是否为中文字符
        if '\u4e00' <= char <= '\u9fff':
            width += 2
        # 检查是否为全角字符
        elif '\u3000' <= char <= '\u303f':
            width += 2
        else:
            width += 1
    return width

def analyze_text_properties(text):
    """
    分析文本属性
    """
    # 统计字符类型
    chinese_chars = len(re.findall(r'[\u4e00-\u9fff]', text))
    english_chars = len(re.findall(r'[a-zA-Z]', text))
    digit_chars = len(re.findall(r'\d', text))
    special_chars = len(re.findall(r'[\W_]', text))
    
    # 计算显示宽度
    display_width = count_display_width(text)
    
    # 检测是否有换行符
    has_newline = '\n' in text
    
    # 检测是否有空格
    space_count = text.count(' ')
    
    return {
        'chinese_chars': chinese_chars,
        'english_chars': english_chars,
        'digit_chars': digit_chars,
        'special_chars': special_chars,
        'total_chars': len(text),
        'display_width': display_width,
        'has_newline': has_newline,
        'space_count': space_count,
        'is_mixed': chinese_chars > 0 and english_chars > 0
    }

def validate_translation(old_text, new_text, file_info=None):
    """
    验证单个翻译的质量
    """
    old_props = analyze_text_properties(old_text)
    new_props = analyze_text_properties(new_text)
    
    # 计算增长率（基于显示宽度）
    if old_props['display_width'] > 0:
        width_growth = (new_props['display_width'] - old_props['display_width']) / old_props['display_width'] * 100
    else:
        width_growth = 0
    
    # 字节增长率（UTF-8）
    old_bytes = len(old_text.encode('utf-8'))
    new_bytes = len(new_text.encode('utf-8'))
    if old_bytes > 0:
        byte_growth = (new_bytes - old_bytes) / old_bytes * 100
    else:
        byte_growth = 0
    
    # 风险标记
    risks = []
    
    # 1. 显示宽度增长过大
    if width_growth > 30:
        risks.append(f"显示宽度增长过大 ({width_growth:.1f}%)")
    
    # 2. 字节增长过大
    if byte_growth > 50:
        risks.append(f"字节增长过大 ({byte_growth:.1f}%)")
    
    # 3. 混合语言可能导致渲染问题
    if old_props['is_mixed'] != new_props['is_mixed']:
        if new_props['is_mixed']:
            risks.append("新增混合中英文（可能导致渲染不一致）")
    elif old_props['is_mixed'] and new_props['is_mixed']:
        # 检查混合比例是否大幅变化
        old_ratio = old_props['chinese_chars'] / (old_props['chinese_chars'] + old_props['english_chars'])
        new_ratio = new_props['chinese_chars'] / (new_props['chinese_chars'] + new_props['english_chars'])
        if abs(old_ratio - new_ratio) > 0.3:
            risks.append(f"中英文比例变化过大 ({old_ratio:.0%} → {new_ratio:.0%})")
    
    # 4. 短文本（UI元素）的特殊检查
    if old_props['total_chars'] < 30:
        if width_growth > 20:
            risks.append(f"短文本宽度增长 ({width_growth:.1f}%) - 可能影响UI布局")
    
    # 5. 检查是否引入了换行符
    if not old_props['has_newline'] and new_props['has_newline']:
        risks.append("新增了换行符（可能导致文本分行）")
    
    return {
        'old_props': old_props,
        'new_props': new_props,
        'width_growth': width_growth,
        'byte_growth': byte_growth,
        'risks': risks,
        'has_risk': len(risks) > 0
    }

def validate_all_translations(log_file='translation_log.json'):
    """
    验证所有翻译
    """
    print("正在读取翻译日志...")
    with open(log_file, 'r', encoding='utf-8') as f:
        log_data = json.load(f)
    
    print(f"总共 {len(log_data['changes'])} 个翻译变更\n")
    
    all_validations = []
    risk_count = 0
    
    for change in log_data['changes']:
        validation = validate_translation(
            change['old'], 
            change['new'],
            {'file': change['file'], 'line': change['line']}
        )
        
        validation['file'] = change['file']
        validation['line'] = change['line']
        validation['old_text'] = change['old']
        validation['new_text'] = change['new']
        
        all_validations.append(validation)
        
        if validation['has_risk']:
            risk_count += 1
    
    # 按风险等级排序
    all_validations.sort(key=lambda x: len(x['risks']), reverse=True)
    
    # 输出报告
    print("=" * 100)
    print(f"验证结果: 共 {risk_count} 个翻译存在潜在风险")
    print("=" * 100)
    
    if risk_count > 0:
        print("\n风险翻译详情:\n")
        
        for i, val in enumerate([v for v in all_validations if v['has_risk']], 1):
            print(f"{i}. [{val['file']}:{val['line']}]")
            print(f"   原文: {val['old_text'][:80]}...")
            print(f"   译文: {val['new_text'][:80]}...")
            print(f"   显示宽度: {val['old_props']['display_width']} → {val['new_props']['display_width']} ({val['width_growth']:+.1f}%)")
            print(f"   字节数: {val['old_props']['total_chars']}字/{len(val['old_text'].encode('utf-8'))}B → {val['new_props']['total_chars']}字/{len(val['new_text'].encode('utf-8'))}B ({val['byte_growth']:+.1f}%)")
            print(f"   字符构成: 中文{val['old_props']['chinese_chars']}→{val['new_props']['chinese_chars']}, 英文{val['old_props']['english_chars']}→{val['new_props']['english_chars']}")
            print(f"   风险:")
            for risk in val['risks']:
                print(f"     ⚠ {risk}")
            print()
    else:
        print("\n✓ 所有翻译均通过验证，未发现高风险问题")
    
    # 保存详细报告
    report = {
        'total_translations': len(all_validations),
        'risk_translations': risk_count,
        'valid_translations': len(all_validations) - risk_count,
        'detailed_validations': all_validations
    }
    
    with open('translation_validation_report.json', 'w', encoding='utf-8') as f:
        json.dump(report, f, ensure_ascii=False, indent=2)
    
    print("\n" + "=" * 100)
    print("详细验证报告已保存到: translation_validation_report.json")
    print("=" * 100)
    
    return report


EVENT_FILE_NAMES = {
    "doneventscript.cs",
    "Results_text.cs",
    "EndingScript.cs",
    "EventScript.cs",
    "EventsCoopScript.cs",
    "EvetnnashScript.cs",
}

EVENT_FILE_PREFIXES = ("Event", "Ending")
EVENT_FILE_DIR_MARKERS = ("/KGEvent/", "/EventsForDLC/", "/ReqEventsDLC02/")
EVENT_TEXT_MARKERS = (
    "Five no", "Five \"no\"", "Five 'no'",
    "<new event>", "<end event>", "<option>", "<result>",
    "event", "Event",
)

def is_event_content(val):
    """DLL 重编译阶段排除事件/结果/结局叙事文本。

这些文本应由 TextAsset / level 管线处理；放进 DLL 重编译会造成换行、对齐、
混合中英和重复汉化问题。
    """
    file_name = val.get('file', '')
    old = val.get('old_text', val.get('old', '')) or ''
    new = val.get('new_text', val.get('new', '')) or ''
    combined = old + "\n" + new

    if file_name in EVENT_FILE_NAMES:
        return True
    if file_name.startswith(EVENT_FILE_PREFIXES):
        return True
    if any(marker in file_name for marker in EVENT_FILE_DIR_MARKERS):
        return True
    if any(marker in combined for marker in EVENT_TEXT_MARKERS):
        return True
    return False

def generate_safe_translation_map(report_file='translation_validation_report.json'):
    """
    生成安全的翻译映射（排除高风险翻译）
    """
    with open(report_file, 'r', encoding='utf-8') as f:
        report = json.load(f)
    
    safe_translations = {}
    excluded = []
    
    for val in report['detailed_validations']:
        event_filtered = is_event_content(val)
        if val['has_risk'] or event_filtered:
            risks = list(val['risks'])
            if event_filtered:
                risks.append('EVENT内容过滤：事件/结果/结局文本交给TextAsset/Level管线处理')
            excluded.append({
                'file': val['file'],
                'line': val['line'],
                'old': val['old_text'],
                'new': val['new_text'],
                'risks': risks
            })
        else:
            safe_translations[val['file'] + ':' + str(val['line'])] = {
                'old': val['old_text'],
                'new': val['new_text']
            }
    
    print(f"\n生成安全翻译映射:")
    print(f"  安全翻译: {len(safe_translations)} 个")
    print(f"  排除的高风险翻译: {len(excluded)} 个")
    
    with open('safe_translations_v2.json', 'w', encoding='utf-8') as f:
        json.dump({
            'safe_count': len(safe_translations),
            'excluded_count': len(excluded),
            'translations': safe_translations,
            'excluded': excluded
        }, f, ensure_ascii=False, indent=2)
    
    print(f"安全翻译映射已保存到: safe_translations_v2.json")
    
    return safe_translations, excluded

if __name__ == '__main__':
    import sys
    
    if len(sys.argv) > 1 and sys.argv[1] == '--generate-safe':
        # 模式1: 生成安全翻译映射
        print("=" * 100)
        print("模式: 生成安全翻译映射")
        print("=" * 100)
        validate_all_translations()
        generate_safe_translation_map()
    else:
        # 模式0: 仅验证
        print("=" * 100)
        print("模式: 翻译验证")
        print("=" * 100)
        validate_all_translations()
        print("\n提示: 使用 --generate-safe 参数生成更安全的翻译映射")
