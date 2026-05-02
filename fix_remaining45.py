#!/usr/bin/env python3
"""
修复剩余45行未翻译内容
1. 恢复 other_text_ru 中被置空的 # 行
2. 翻译缩写：SRK / RDFEP / PFLE / NRLP（Events_text_en, other_text_en）
3. 用 API 翻译长文本空行（new_texts_en, other_text_ru <color>行）
4. 跳过已正确保留的：WPO / CSO / none / НФОЭ / ФОЭ
"""
import os, json, re, time, requests

BASE    = os.path.dirname(os.path.abspath(__file__))
ORIG    = os.path.join(BASE, "1.8.5/resources.assets.original")
CN      = os.path.join(BASE, "1.8.5/resources.assets.chinese")
API_URL = "http://192.168.50.3:18000/v1/chat/completions"
API_KEY = "sk-lexwdex"
MODEL   = "gpt-5.4-nano"

# ── 标签保护 ──────────────────────────────────────────
def protect_tags(text: str):
    tags: list[str] = []
    def repl(m):
        idx = len(tags)
        tags.append(m.group())
        return f'__T{idx}__'
    return re.sub(r'<[^>]+>', repl, text), tags

def restore_tags(text: str, tags: list[str]) -> str:
    for i, tag in enumerate(tags):
        text = text.replace(f'__T{i}__', tag)
    return text

# ── API 批量翻译 ──────────────────────────────────────
def translate_batch(lines: list[str], context_hint: str = "") -> list[str]:
    protected, all_tags = [], []
    for ln in lines:
        p, tags = protect_tags(ln)
        protected.append(p)
        all_tags.append(tags)

    numbered = "\n".join(f"{i+1}. {l}" for i, l in enumerate(protected))
    prompt = (
        "你是冷战历史政治类游戏汉化助手。游戏背景涉及中华人民共和国、法国、苏联等国。\n"
        f"背景提示：{context_hint}\n\n"
        "请将以下编号的外语文本（英语或俄语）翻译为简明中文。\n\n"
        "翻译规则：\n"
        "1. 严格按「数字. 翻译结果」格式逐行返回，不得合并或跳行\n"
        "2. 占位符（__T0__ 等）和 {0} {1} 占位符原样保留\n"
        "3. 人名地名使用惯用中文译名\n"
        "4. 只输出翻译结果，不解释\n\n"
        f"{numbered}"
    )

    for attempt in range(3):
        try:
            resp = requests.post(
                API_URL,
                headers={"Authorization": f"Bearer {API_KEY}",
                         "Content-Type": "application/json"},
                json={"model": MODEL,
                      "messages": [{"role": "user", "content": prompt}],
                      "temperature": 0.3},
                timeout=120,
            )
            resp.raise_for_status()
            content = resp.json()["choices"][0]["message"]["content"].strip()
            parsed: dict[int, str] = {}
            for raw_line in content.splitlines():
                m = re.match(r'^(\d+)[.)]\s*(.*)', raw_line.strip())
                if m:
                    parsed[int(m.group(1)) - 1] = m.group(2).strip()
            result = []
            for i, orig in enumerate(lines):
                zh = parsed.get(i, "")
                if zh:
                    result.append(restore_tags(zh, all_tags[i]))
                else:
                    result.append(orig)
            return result
        except Exception as e:
            print(f"  ⚠ 第{attempt+1}/3次失败: {e}")
            time.sleep(3)
    return lines


def load_file(fn):
    with open(os.path.join(ORIG, fn)) as f:
        od = json.load(f)
    with open(os.path.join(CN, fn)) as f:
        cd = json.load(f)
    return od, cd

def save_file(fn, cd):
    with open(os.path.join(CN, fn), "w", encoding="utf-8") as f:
        json.dump(cd, f, ensure_ascii=False, indent=2)


# ════════════════════════════════════════════════════════
# 1. other_text_ru — 恢复 # 并翻译 <color> 行
# ════════════════════════════════════════════════════════
def fix_other_text_ru():
    fn = "other_text_ru-resources.assets-320.json"
    od, cd = load_file(fn)
    ol = od["m_Script"].splitlines()
    cl = cd["m_Script"].splitlines()

    # 1a 恢复被置空的 # 行
    hash_restored = 0
    for i, line in enumerate(ol):
        if line.strip() == '#' and i < len(cl) and not cl[i].strip():
            cl[i] = '#'
            hash_restored += 1

    # 1b 收集需翻译的 <color> 行（原始非空，汉化为空）
    to_translate: list[tuple[int, str]] = []
    for i, line in enumerate(ol):
        s = line.strip()
        if s and s != '#' and i < len(cl) and not cl[i].strip():
            to_translate.append((i, s))

    translated = 0
    if to_translate:
        texts  = [t for _, t in to_translate]
        results = translate_batch(texts,
            context_hint="包含 <color=green/red> 标签的一次性效果说明行，如「进口需求 -3」「外债 +14」")
        for (idx, orig), zh in zip(to_translate, results):
            if zh and zh != orig:
                cl[idx] = zh
                translated += 1

    cd["m_Script"] = "\r\n".join(cl)
    save_file(fn, cd)
    print(f"other_text_ru: # 恢复 {hash_restored} 行，翻译 {translated}/{len(to_translate)} 行")


# ════════════════════════════════════════════════════════
# 2. Events_text_en — 翻译缩写（SRK / RDFEP / PFLE / NRLP）
#    WPO / CSO 保持不变（已一致使用英文缩写）
# ════════════════════════════════════════════════════════
ABBREV_TRANSLATIONS = {
    # Korean alternate state names
    "SRK":   "朝鲜社会主义共和国",
    # Ethiopian/Eritrean factions
    "RDFEP": "埃塞俄比亚人民革命民主阵线",
    "PFLE":  "厄立特里亚人民解放阵线",
    # Laotian party
    "NRLP":  "老挝民族革命解放党",
}

def fix_events_text_en():
    fn = "Events_text_en-resources.assets-331.json"
    od, cd = load_file(fn)
    cl = cd["m_Script"].splitlines()
    ol = od["m_Script"].splitlines()
    count = 0
    for i, line in enumerate(ol):
        s = line.strip()
        if s in ABBREV_TRANSLATIONS and i < len(cl):
            cn_s = cl[i].strip()
            if cn_s == s:  # 未翻译（等于原文）
                indent = len(line) - len(line.lstrip())
                cl[i] = " " * indent + ABBREV_TRANSLATIONS[s]
                count += 1
    cd["m_Script"] = "\r\n".join(cl)
    save_file(fn, cd)
    print(f"Events_text_en: 翻译缩写 {count} 行")


# ════════════════════════════════════════════════════════
# 3. other_text_en — 翻译 PFLE
# ════════════════════════════════════════════════════════
def fix_other_text_en():
    fn = "other_text_en-resources.assets-323.json"
    od, cd = load_file(fn)
    cl = cd["m_Script"].splitlines()
    ol = od["m_Script"].splitlines()
    count = 0
    for i, line in enumerate(ol):
        s = line.strip()
        if s in ABBREV_TRANSLATIONS and i < len(cl):
            cn_s = cl[i].strip()
            if cn_s == s:
                indent = len(line) - len(line.lstrip())
                cl[i] = " " * indent + ABBREV_TRANSLATIONS[s]
                count += 1
    cd["m_Script"] = "\r\n".join(cl)
    save_file(fn, cd)
    print(f"other_text_en: 翻译缩写 {count} 行")


# ════════════════════════════════════════════════════════
# 4. new_texts_en — 翻译空行（Align + 长文本）
#    CSO / WPO 保持不变
# ════════════════════════════════════════════════════════
# Align 是 UI 按钮标签
ALIGN_TRANSLATION = "对齐"

def fix_new_texts_en():
    fn = "new_texts_en-resources.assets-315.json"
    od, cd = load_file(fn)
    ol = od["m_Script"].splitlines()
    cl = cd["m_Script"].splitlines()

    # 找到所有原始非空但汉化为空的行
    to_translate: list[tuple[int, str]] = []
    for i, line in enumerate(ol):
        s = line.strip()
        if s and i < len(cl) and not cl[i].strip():
            to_translate.append((i, s))

    if not to_translate:
        print("new_texts_en: 无需翻译")
        return

    translated = 0
    # 分批：先处理 Align（手动），再 API 翻译其余
    manual_done = 0
    api_batch: list[tuple[int, str]] = []

    for idx, orig in to_translate:
        if orig == "Align":
            indent = len(ol[idx]) - len(ol[idx].lstrip())
            cl[idx] = " " * indent + ALIGN_TRANSLATION
            manual_done += 1
        else:
            api_batch.append((idx, orig))

    if api_batch:
        texts   = [t for _, t in api_batch]
        results = translate_batch(texts,
            context_hint="冷战政治游戏文本，涉及柬埔寨英萨利、罗马尼亚齐奥塞斯库、铁托主义等历史事件")
        for (idx, orig), zh in zip(api_batch, results):
            if zh and zh != orig:
                indent = len(ol[idx]) - len(ol[idx].lstrip())
                cl[idx] = " " * indent + zh
                translated += 1

    cd["m_Script"] = "\r\n".join(cl)
    save_file(fn, cd)
    print(f"new_texts_en: 手动翻译 {manual_done} 行，API翻译 {translated}/{len(api_batch)} 行")


# ════════════════════════════════════════════════════════
# 主流程
# ════════════════════════════════════════════════════════
def main():
    print("开始修复剩余45行...")
    print()
    fix_other_text_ru()
    fix_events_text_en()
    fix_other_text_en()
    fix_new_texts_en()
    print()
    print("完成！")


if __name__ == "__main__":
    main()
