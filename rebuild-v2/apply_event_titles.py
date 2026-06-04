#!/usr/bin/env python3
"""只恢复 EVENT 短标题翻译，不碰正文。需在 apply_safe_v2.py 之后运行。"""
import json
from pathlib import Path

analysis=json.load(open('event_titles_analysis.json',encoding='utf-8'))
manual={
    'Conspiracy':'阴谋',
    'Pan-Arabism':'泛阿拉伯主义',
    'Automation?':'自动化？',
    'GOVERNMENT CRISIS':'政府危机',
    'Goodbye, Brezhnev':'再见，勃列日涅夫',
}
# map exact raw title -> translation
mapping={}
for r in analysis['titles']:
    text=r['text']
    zh=r.get('translated') or manual.get(text)
    if not zh: continue
    # skip Russian titles; in language=0 path English titles are enough, avoid accidental RU overreach
    if any('А' <= c <= 'я' for c in text):
        continue
    # skip internal key text without display assignment? extracted from title vars only, OK.
    mapping[r['raw']]=zh

print('event title mapping:', len(mapping))
for old, new in list(mapping.items())[:20]:
    print(repr(old),'->',repr(new))

changed=[]
for rel in ['decompiled/doneventscript.cs','decompiled/Results_text.cs','decompiled/EndingScript.cs']:
    p=Path(rel)
    if not p.exists(): continue
    text=p.read_text(encoding='utf-8')
    before=text
    for raw, zh in mapping.items():
        # raw may contain escaped quotes like Five \"no\"; replace inside quoted assignments only by simple literal replacement
        text=text.replace(f'"{raw}"', f'"{zh}"')
    if text != before:
        p.write_text(text,encoding='utf-8')
        changed.append(rel)
        print('✓ changed', rel, 'replacements approx', sum(before.count(f'"{raw}"') for raw in mapping))
print('changed files:', changed)
