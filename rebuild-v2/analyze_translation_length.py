#!/usr/bin/env python3
"""
分析翻译长度变化，找出可能导致UI布局问题的翻译
"""
import json

# 读取翻译日志
with open('translation_log.json', 'r', encoding='utf-8') as f:
    log_data = json.load(f)

# 分析每个翻译的长度变化
analysis = []

for change in log_data['changes']:
    old_text = change['old']
    new_text = change['new']
    
    # 计算字符数
    old_len = len(old_text)
    new_len = len(new_text)
    
    # 计算字节数（UTF-8）
    old_bytes = len(old_text.encode('utf-8'))
    new_bytes = len(new_text.encode('utf-8'))
    
    # 计算增长率和增长量
    if old_len > 0:
        growth_rate = (new_len - old_len) / old_len * 100
    else:
        growth_rate = 0
    
    growth_diff = new_len - old_len
    bytes_diff = new_bytes - old_bytes
    
    analysis.append({
        'file': change['file'],
        'line': change['line'],
        'old_text': old_text,
        'new_text': new_text,
        'old_len': old_len,
        'new_len': new_len,
        'growth_rate': growth_rate,
        'growth_diff': growth_diff,
        'old_bytes': old_bytes,
        'new_bytes': new_bytes,
        'bytes_diff': bytes_diff
    })

# 按增长率排序
analysis.sort(key=lambda x: x['growth_rate'], reverse=True)

# 输出分析结果
print(f"总共分析了 {len(analysis)} 个翻译变更\n")
print("=" * 100)
print("增长率最高的20个翻译:")
print("=" * 100)

for i, item in enumerate(analysis[:20], 1):
    print(f"\n{i}. [{item['file']}:{item['line']}]")
    print(f"   增长率: {item['growth_rate']:.1f}%")
    print(f"   长度变化: {item['old_len']} → {item['new_len']} (差: {item['growth_diff']:+d})")
    print(f"   字节变化: {item['old_bytes']} → {item['new_bytes']}B (差: {item['bytes_diff']:+d}B)")
    print(f"   原文: {item['old_text'][:80]}...")
    print(f"   译文: {item['new_text'][:80]}...")

# 统计信息
print("\n" + "=" * 100)
print("统计信息:")
print("=" * 100)

# 增长率分布
growth_increased = sum(1 for a in analysis if a['growth_rate'] > 0)
growth_decreased = sum(1 for a in analysis if a['growth_rate'] < 0)
growth_same = sum(1 for a in analysis if a['growth_rate'] == 0)

print(f"\n增长率分布:")
print(f"  增加的翻译: {growth_increased} ({growth_increased/len(analysis)*100:.1f}%)")
print(f"  减少的翻译: {growth_decreased} ({growth_decreased/len(analysis)*100:.1f}%)")
print(f"  不变的翻译: {growth_same} ({growth_same/len(analysis)*100:.1f}%)")

# 平均增长率
avg_growth = sum(a['growth_rate'] for a in analysis) / len(analysis)
print(f"\n平均增长率: {avg_growth:.1f}%")

# 最大增长率
max_growth = max(a['growth_rate'] for a in analysis)
print(f"最大增长率: {max_growth:.1f}%")

# UI文本分析（短文本更可能影响布局）
print("\n" + "=" * 100)
print("短文本翻译分析（原文长度 < 50字符，可能影响UI布局）:")
print("=" * 100)

short_texts = [a for a in analysis if a['old_len'] < 50 and a['growth_rate'] > 20]
short_texts.sort(key=lambda x: x['growth_rate'], reverse=True)

print(f"\n发现 {len(short_texts)} 个短文本翻译增长率 > 20%")

for i, item in enumerate(short_texts[:15], 1):
    print(f"\n{i}. [{item['file']}:{item['line']}]")
    print(f"   增长率: {item['growth_rate']:.1f}%")
    print(f"   长度: {item['old_len']} → {item['new_len']} (差: {item['growth_diff']:+d})")
    print(f"   字节: {item['old_bytes']} → {item['new_bytes']}B")
    print(f"   原文: {item['old_text']}")
    print(f"   译文: {item['new_text']}")

# 按文件分组统计
print("\n" + "=" * 100)
print("按文件分组统计:")
print("=" * 100)

file_stats = {}
for a in analysis:
    if a['file'] not in file_stats:
        file_stats[a['file']] = {
            'count': 0,
            'avg_growth': 0,
            'max_growth': 0,
            'total_growth': 0
        }
    
    file_stats[a['file']]['count'] += 1
    file_stats[a['file']]['total_growth'] += a['growth_rate']
    file_stats[a['file']]['max_growth'] = max(file_stats[a['file']]['max_growth'], a['growth_rate'])

for file in file_stats:
    file_stats[file]['avg_growth'] = file_stats[file]['total_growth'] / file_stats[file]['count']

# 按最大增长率排序
file_stats_sorted = sorted(file_stats.items(), key=lambda x: x[1]['max_growth'], reverse=True)

for file, stats in file_stats_sorted[:10]:
    print(f"\n{file}:")
    print(f"  修改数: {stats['count']}")
    print(f"  平均增长率: {stats['avg_growth']:.1f}%")
    print(f"  最大增长率: {stats['max_growth']:.1f}%")

# 保存详细报告
with open('translation_length_analysis.json', 'w', encoding='utf-8') as f:
    json.dump({
        'total_changes': len(analysis),
        'statistics': {
            'avg_growth_rate': avg_growth,
            'max_growth_rate': max_growth,
            'growth_increased': growth_increased,
            'growth_decreased': growth_decreased,
            'growth_same': growth_same
        },
        'short_texts_high_growth': short_texts,
        'detailed_analysis': analysis
    }, f, ensure_ascii=False, indent=2)

print("\n" + "=" * 100)
print("详细报告已保存到: translation_length_analysis.json")
print("=" * 100)
