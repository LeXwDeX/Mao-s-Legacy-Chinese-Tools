#!/usr/bin/env python3
"""
历史名字纠错脚本 - Mao's Legacy 1.8.5
对所有 polit_names / polit_surnames / Traits / Politics_leader / Politics_inf
文件进行全量重译，确保使用历史上准确的中文译名。
"""
import os, json, re, time, requests

BASE   = os.path.dirname(os.path.abspath(__file__))
NEW_OR = os.path.join(BASE, "1.8.5/resources.assets.original")
NEW_CN = os.path.join(BASE, "1.8.5/resources.assets.chinese")

API_URL = "http://192.168.50.3:18000/v1/chat/completions"
API_KEY = "sk-lexwdex"
MODEL   = "gpt-5.4-nano"

# ── 历史背景说明（注入每次请求）──────────────────────────
HISTORY_CONTEXT = """
你是冷战时期历史专家，精通以下人物的中文正式译名：

【中国政治家（1970-1990年代）- 姓名对照】
姓（家族名）：
江(Jiang/Цзян)  毛(Mao/Мао)  华(Hua/Хуа)  王(Wang/Ван)  张(Zhang/Чжан)
姚(Yao/Яо)     李(Li/Ли)    叶(Ye/Е)     纪(Ji/Цзи)   陈(Chen/Чэнь)
吴(Wu/У)       黄(Huang/Хуан) 邓(Deng/Дэн) 赵(Zhao/Чжао) 胡(Hu/Ху)
乔(Qiao/Цяо)   刘(Liu/Лиу)   杨(Yang/Ян)  宋(Song/Сон)  彭(Peng/Пэн)
周(Zhou/Чжоу)  孙(Sun/Сун)   马(Ma/Ма)    朱(Zhu/Чжу)  郭(Guo/Гуо)
何(He/Ме)      林(Lin/Линь)  谢(Xie/Си)   唐(Tang/Тан)  冯(Feng/Фэнг)
鲍(Bao/Бао)    孟(Meng/Мэн)  谭(Tan/Тан)  程(Cheng/Чэнь)

名（给定名）- 关键历史人物（必须使用这些准确汉字）：
青(Qing/Цин)           → 江青
泽东(Zedong/Цзэдун)    → 毛泽东
国锋(Guofeng/Гофэн)    → 华国锋  【注意：是"锋"不是"风"】
洪文(Hongwen/Хунвэнь)  → 王洪文  【注意：是"洪"不是"弘"】
春桥(Chunqiao/Чуньцяо) → 张春桥
文元(Wenyuan/Вэньюань) → 姚文元  【注意：是"元"不是"渊"】
东兴(Dongxing/Дунсин)  → 汪东兴
先念(Xiannian/Сяньнянь)→ 李先念  【注意：是"念"不是"年"或"宪念"】
剑英(Jianying/Цзяньин) → 叶剑英  【注意：是"剑"不是"建"】
登奎(Dengkui/Дэнкуй)   → 纪登奎  【注意：是"登奎"不是"邓魁"或"登魁"】
锡联(Xilian/Силянь)    → 陈锡联
德(De/Дэ)              → 朱德
小平(Xiaoping/Сяопин)  → 邓小平
紫阳(Ziyang/Цзыян)     → 赵紫阳  【注意：是"紫阳"不是"资阳"】
耀邦(Yaobang/Яобан)    → 胡耀邦
冠华(Guanhua/Гуаньхуа) → 乔冠华  【注意：是"冠"不是"官"】
国华(Guohua)            → （乔国华等）
元信(Yuanxin/Юаньсинь) → 毛远新（毛泽东侄子）

【法国政治家 - 常用中文译名】
姓：
希拉克(Chirac/Ширак)            德斯坦(d'Estaing/д'Эстен)       密特朗(Mitterrand/Миттеран)
巴尔(Barre/Барр)                 蓬皮杜(Pompidou/Помпиду)        勒庞(Le Pen/Ле Пен)
梅斯梅尔(Messmer/Мессмер)        马歇(Marchais/Марше)             德布雷(Debré/Дебре)
吉沙尔(Guichard/Гишар)           奥尔托利(Ortoli/Ортоли)          阿尔都塞(Althusser/Альтюссер)
舍文曼(Chevènement/Шевенман)     克雷松(Cresson/Крессон)          朱佩(Juppé)
贝雷戈瓦(Bérégovoy/Береговуа)    乔斯潘(Jospin/Лионель)          奥朗德(Hollande/Олланд)
波厄尔(Poher/Поэр)               拉吉耶(Laguiller/Лагийе)        博弗雷(Beaufre)

名（法国人的名）：
雅克(Jacques/Жак)               瓦莱里(Valéry/Жискар)           弗朗索瓦(François/Франсуа)
雷蒙(Raymond/Раймон)             米歇尔(Michel/Мишель)           皮埃尔(Pierre/Пьер)
乔治(Georges/Жорж)               让-马里(Jean-Marie/Жан-Мари)    瓦尔代克(Waldeck/Вальдек)
奥利维耶(Olivier/Оливье)          路易(Louis/Луи)                 让-路易(Jean-Louis/Жан-Луи)
安德烈(André/Андре)               埃德加尔(Edgar/Эдгар)           让(Jean/Жан)
罗贝尔(Robert/Робер)              若埃尔(Joël/Жоэль)              阿兰(Alain/Ален)
罗歇(Roger/Роже)                  路易·德(Louis de/Луи де)

翻译规则：
1. 严格使用上述参考，不得自创汉字
2. 单个名字成分（如 Dengkui、Ширак）只给出对应中文，不加姓氏
3. 格式：「数字. 中文译名」
4. 只输出结果，不解释
"""

# ── 标签保护 ──────────────────────────────────────────
def protect_tags(text: str):
    tags: list[str] = []
    def repl(m):
        idx = len(tags); tags.append(m.group()); return f'__T{idx}__'
    return re.sub(r'<[^>]+>', repl, text), tags

def restore_tags(text: str, tags: list[str]) -> str:
    for i, t in enumerate(tags):
        text = text.replace(f'__T{i}__', t)
    return text

# ── API 调用 ──────────────────────────────────────────
def translate_names(lines: list[str]) -> list[str]:
    """用历史上下文翻译一批名字"""
    protected, all_tags = [], []
    for ln in lines:
        p, tags = protect_tags(ln)
        protected.append(p); all_tags.append(tags)

    numbered = "\n".join(f"{i+1}. {l}" for i, l in enumerate(protected))
    prompt = HISTORY_CONTEXT + "\n\n【待翻译内容】\n" + numbered

    for attempt in range(3):
        try:
            resp = requests.post(
                API_URL,
                headers={"Authorization": f"Bearer {API_KEY}",
                         "Content-Type": "application/json"},
                json={"model": MODEL,
                      "messages": [{"role": "user", "content": prompt}],
                      "temperature": 0.1},   # 低温度，提高确定性
                timeout=90,
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
            print(f"    ⚠ attempt {attempt+1}/3: {e}")
            time.sleep(3)
    return lines

# ── 需要重新翻译的文件 ──────────────────────────────────
# 以下文件全部重译（不管当前是否已有翻译），确保历史准确性
RETRANSLATE_ALL = True   # 对名字文件全量重译

TARGET_PREFIXES = [
    "polit_names",
    "polit_surnames",
    "Traits",
    "Politics_leader",
    "Politics_inf",
    "Part1_en", "Part7_en",
    "Part1_ru", "Part7_ru", "Part21_ru",
    "Country_en",
]

HAS_ZH  = re.compile(r'[\u4e00-\u9fff\u3400-\u4dbf]')
SKIP_RE = re.compile(r'^[\d\s;,.\-_:+*/#@!%^&()=\[\]{}<>|\\~`\'"]*$')


def is_name_file(filename: str) -> bool:
    name = filename.rsplit("-resources.assets-", 1)[0]
    return any(name.startswith(p) or name == p for p in TARGET_PREFIXES)


def process_name_file(filename: str):
    name = filename.rsplit("-resources.assets-", 1)[0]
    or_path = os.path.join(NEW_OR, filename)
    cn_path = os.path.join(NEW_CN, filename)

    with open(or_path, encoding="utf-8") as f: or_d = json.load(f)
    with open(cn_path, encoding="utf-8") as f: cn_d = json.load(f)

    or_lines = (or_d.get("m_Script") or "").splitlines()
    cn_lines = list((cn_d.get("m_Script") or "").splitlines())
    while len(cn_lines) < len(or_lines):
        cn_lines.append(or_lines[len(cn_lines)])

    # 收集所有有意义的行（原文不是纯数字/符号，且原文不是空行）
    to_process: list[tuple[int, str]] = []
    for i, orig in enumerate(or_lines):
        s = orig.strip()
        if not s or SKIP_RE.match(s):
            continue
        to_process.append((i, s))

    if not to_process:
        print(f"  → 无需处理")
        return 0

    BATCH = 30
    total_fixed = 0
    batches = [to_process[s:s+BATCH] for s in range(0, len(to_process), BATCH)]

    for bi, batch in enumerate(batches, 1):
        orig_texts = [t for _, t in batch]
        results    = translate_names(orig_texts)

        for (idx, orig_t), translated in zip(batch, results):
            if translated and translated != cn_lines[idx].strip():
                indent = len(cn_lines[idx]) - len(cn_lines[idx].lstrip())
                old = cn_lines[idx].strip()
                cn_lines[idx] = " " * indent + translated
                total_fixed += 1
                if old != orig_t:   # 旧译文与原文不同（说明之前翻译过，现在修正）
                    print(f"    纠正: {orig_t[:30]} → {old[:20]} → {translated}")
                else:
                    print(f"    新译: {orig_t[:30]} → {translated}")

        cn_d["m_Script"] = "\r\n".join(cn_lines)
        with open(cn_path, "w", encoding="utf-8") as f:
            json.dump(cn_d, f, ensure_ascii=False, indent=2)

        print(f"    批次 {bi}/{len(batches)} 完成", end="\r", flush=True)

    print()
    return total_fixed


# ── 主流程 ────────────────────────────────────────────
def main():
    files = sorted(f for f in os.listdir(NEW_CN)
                   if f.endswith(".json") and is_name_file(f))

    print(f"需要纠错的名字类文件：{len(files)} 个\n")
    total = 0
    for i, filename in enumerate(files, 1):
        name = filename.rsplit("-resources.assets-", 1)[0]
        print(f"[{i:2}/{len(files)}] {name}")
        fixed = process_name_file(filename)
        total += fixed
        print(f"  → 处理 {fixed} 行\n")

    print(f"{'='*60}")
    print(f"全部完成，共修正/新译 {total} 行")


if __name__ == "__main__":
    main()
