#!/usr/bin/env python3
"""从 decompiled.backup 还原干净源码，只应用 safe_translations_v2.json 中无风险的真实改动。"""
import json, shutil
from pathlib import Path

ROOT = Path('.')
SRC = ROOT / 'decompiled'
BACKUP = ROOT / 'decompiled.backup'
SAFE = ROOT / 'safe_translations_v2.json'

print('=== 恢复干净源码 ===')
if SRC.exists():
    shutil.rmtree(SRC)
shutil.copytree(BACKUP, SRC)
print('✓ decompiled <- decompiled.backup')

with open(SAFE, encoding='utf-8') as f:
    data = json.load(f)

items = [(k,v) for k,v in data['translations'].items() if v['old'] != v['new']]
print(f'真实安全改动: {len(items)}')

applied = 0
failed = []
for key, val in items:
    file, line_s = key.rsplit(':', 1)
    line_no = int(line_s)
    path = SRC / file
    if not path.exists():
        failed.append((key, 'file not found'))
        continue
    lines = path.read_text(encoding='utf-8').splitlines(keepends=True)
    if line_no < 1 or line_no > len(lines):
        failed.append((key, 'line out of range'))
        continue
    old, new = val['old'], val['new']
    idx = line_no - 1
    if old not in lines[idx]:
        failed.append((key, 'old text not found on line'))
        continue
    lines[idx] = lines[idx].replace(old, new)
    path.write_text(''.join(lines), encoding='utf-8')
    applied += 1
    print(f'✓ {key}: {old!r} -> {new!r}')

print(f'\n应用成功: {applied}')
print(f'应用失败: {len(failed)}')
if failed:
    for x in failed:
        print('FAIL', x)
    raise SystemExit(1)
