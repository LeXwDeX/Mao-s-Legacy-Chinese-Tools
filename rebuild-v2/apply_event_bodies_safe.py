#!/usr/bin/env python3
"""EVENT 标题+正文安全替换。

只处理 C# 普通字符串字面量：解析字面量内容 -> 用 dll_strings/translated.json 精确匹配 -> 重新转义写回。
避免粗暴 replace 导致 \" / \n / 中文引号破坏 C# 语法。
"""
import json
import shutil
from pathlib import Path

ROOT = Path('..')
TARGETS = [
    Path('decompiled/doneventscript.cs'),
    Path('decompiled/Results_text.cs'),
    Path('decompiled/EndingScript.cs'),
]

# 不应替换的内部 key / 特殊项
DENY_TEXTS = {
    'Five no',             # KGEvent.CreateEvent key
    'Main', 'Diplomacy', 'Economy', 'Science', 'Event',
    'Mouse X', 'Mouse Y', 'Mouse ScrollWheel',
}

# 读取 DLL 翻译表
raw = json.load(open(ROOT / 'dll_strings/translated.json', encoding='utf-8'))
trans = {}
for k, v in raw.items():
    old = v.get('text', '')
    new = v.get('translated', '')
    if not old or not new or old == new:
        continue
    if old in DENY_TEXTS:
        continue
    # 保留标题和正文，不按长度过滤；只做精确匹配
    trans[old] = new

# 手动补全 / 覆盖 EVENT 英文短标题
trans.update({
    'Conspiracy': '阴谋',
    'Pan-Arabism': '泛阿拉伯主义',
    'Automation?': '自动化？',
    'GOVERNMENT CRISIS': '政府危机',
    'Five "no"': '五个“不”',
})

_SIMPLE_ESC = {
    'n': '\n',
    'r': '\r',
    't': '\t',
    '"': '"',
    "'": "'",
    '\\': '\\',
    '0': '\0',
}

def csharp_unescape(s: str) -> str:
    out = []
    i = 0
    while i < len(s):
        c = s[i]
        if c != '\\' or i + 1 >= len(s):
            out.append(c)
            i += 1
            continue
        nxt = s[i + 1]
        if nxt in _SIMPLE_ESC:
            out.append(_SIMPLE_ESC[nxt])
            i += 2
        else:
            # 保守：未知转义保持原样，避免误破坏
            out.append('\\' + nxt)
            i += 2
    return ''.join(out)

def csharp_escape(s: str) -> str:
    return (s
        .replace('\\', '\\\\')
        .replace('"', '\\"')
        .replace('\r', '\\r')
        .replace('\n', '\\n')
        .replace('\t', '\\t'))

def find_literals(line: str):
    """返回 (start,end,raw_inside)，只处理普通字符串。"""
    res = []
    i = 0
    while i < len(line):
        if line[i] != '"':
            i += 1
            continue
        start = i
        i += 1
        buf = []
        while i < len(line):
            if line[i] == '\\' and i + 1 < len(line):
                buf.append(line[i:i+2])
                i += 2
                continue
            if line[i] == '"':
                end = i + 1
                res.append((start, end, ''.join(buf)))
                i = end
                break
            buf.append(line[i])
            i += 1
        else:
            break
    return res

def should_skip_file_context(path: Path, line: str, decoded: str) -> bool:
    # 避免 Find / Input / PlayerPrefs / Debug 参数
    bad_context = ['GameObject.Find(', '.Find(', 'Input.Get', 'PlayerPrefs.', 'Debug.Log']
    if any(x in line for x in bad_context):
        return True
    if decoded in DENY_TEXTS:
        return True
    return False

# 从干净源码恢复
print('=== 恢复干净源码 ===')
if Path('decompiled').exists():
    shutil.rmtree('decompiled')
shutil.copytree('decompiled.backup', 'decompiled')
print('✓ decompiled <- decompiled.backup')

# 先应用此前低风险项（不依赖 apply_safe_v2，直接在同一机制中完成）
# trans 已包含 Cultural Revolution / or in / New old 等，精确匹配即可。

changes = []
for path in TARGETS + [Path('decompiled/LoadInScript.cs'), Path('decompiled/LoadListController.cs'), Path('decompiled/SaveListController.cs'), Path('decompiled/Savescript.cs'), Path('decompiled/Show_diplomacy_data_script.cs'), Path('decompiled/Focuses/USSRFocuses.cs')]:
    if not path.exists():
        continue
    lines = path.read_text(encoding='utf-8').splitlines(keepends=True)
    new_lines = []
    for ln, line in enumerate(lines, 1):
        literals = find_literals(line)
        if not literals:
            new_lines.append(line)
            continue
        new_line = line
        # 逆序替换保持索引
        for start, end, raw_inside in reversed(literals):
            decoded = csharp_unescape(raw_inside)
            if should_skip_file_context(path, line, decoded):
                continue
            if decoded not in trans:
                continue
            zh = trans[decoded]
            escaped = csharp_escape(zh)
            new_line = new_line[:start+1] + escaped + new_line[end-1:]
            changes.append({'file': str(path), 'line': ln, 'old': decoded[:120], 'new': zh[:120]})
        new_lines.append(new_line)
    path.write_text(''.join(new_lines), encoding='utf-8')

print('应用替换数:', len(changes))
by_file = {}
for c in changes:
    by_file[c['file']] = by_file.get(c['file'], 0) + 1
for f, n in sorted(by_file.items()):
    print(f'  {f}: {n}')

json.dump({'count': len(changes), 'changes': changes}, open('event_body_apply_log.json', 'w', encoding='utf-8'), ensure_ascii=False, indent=2)
print('日志: event_body_apply_log.json')
