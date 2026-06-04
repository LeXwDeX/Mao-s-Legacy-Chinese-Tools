#!/usr/bin/env python3
import json,re
from pathlib import Path

# load existing translations from dll_strings/translated.json and translations_dict.json
root=Path('..')
trans={}
try:
    d=json.load(open(root/'dll_strings/translated.json',encoding='utf-8'))
    for k,v in d.items():
        t=v.get('text','')
        z=v.get('translated','')
        if t and z and t!=z:
            trans[t]=z
except Exception as e:
    print('warn translated.json',e)
try:
    d=json.load(open(root/'translations_dict.json',encoding='utf-8'))
    for section,items in d.items():
        if isinstance(items,dict):
            for k,v in items.items():
                trans[k]=v
                trans[k.title()]=v
                trans[k.upper()]=v
except Exception as e:
    print('warn translations_dict',e)

files=[Path('decompiled.backup/doneventscript.cs'), Path('decompiled.backup/Results_text.cs'), Path('decompiled.backup/EndingScript.cs')]
pat=re.compile(r'\b(text2|Name\.text|title|Title)\s*=\s*"((?:[^"\\]|\\.)*)"\s*;')
# Focus on direct event title vars; not every Name.text assignment.
results=[]
seen=set()
for f in files:
    if not f.exists(): continue
    for i,line in enumerate(f.read_text(encoding='utf-8',errors='ignore').splitlines(),1):
        m=pat.search(line)
        if not m: continue
        var,raw=m.groups()
        # decode common escapes for lookup, keep raw for replacement
        text=raw.replace('\\"','"').replace('\\n','\n')
        # skip obvious long body accidentally assigned to title
        if len(text)>80: continue
        # skip empty/symbol/debug-ish
        if not text.strip() or text.strip() in {'-', '\\n'}: continue
        key=(str(f),i,raw)
        if key in seen: continue
        seen.add(key)
        zh=trans.get(text) or trans.get(raw)
        results.append({'file':str(f).replace('decompiled.backup/',''), 'line':i, 'var':var, 'raw':raw, 'text':text, 'translated':zh or '', 'has_translation': bool(zh)})

# classify: internal key if no spaces and referenced by CreateEvent? We only extracted display vars, so mostly display.
# Save and print summary.
out={'total':len(results),'with_translation':sum(r['has_translation'] for r in results),'without_translation':sum(not r['has_translation'] for r in results),'titles':results}
json.dump(out,open('event_titles_analysis.json','w',encoding='utf-8'),ensure_ascii=False,indent=2)
print('total',out['total'],'with',out['with_translation'],'without',out['without_translation'])
print('\nWITH TRANSLATION examples:')
for r in [x for x in results if x['has_translation']][:30]:
    print(f"{r['file']}:{r['line']} {r['text']!r} -> {r['translated']!r}")
print('\nWITHOUT TRANSLATION examples:')
for r in [x for x in results if not x['has_translation']][:80]:
    print(f"{r['file']}:{r['line']} {r['text']!r}")
