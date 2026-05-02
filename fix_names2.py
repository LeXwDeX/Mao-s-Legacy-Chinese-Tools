#!/usr/bin/env python3
"""
精确历史名字修正脚本（第二轮）
1. 修正 polit_surnames*  —— 全名→仅给定名
2. 修正 polit_names*_ru  —— 行序错位
3. 清理 "（未在参考表中）"、"（未提供对应译名）" 占位文本
"""
import os, json, re

BASE   = os.path.dirname(os.path.abspath(__file__))
NEW_OR = os.path.join(BASE, "1.8.5/resources.assets.original")
NEW_CN = os.path.join(BASE, "1.8.5/resources.assets.chinese")

# ── 1. 全名 → 给定名 映射 ─────────────────────────────
#   用于 polit_surnames* 文件：GPT 返回了 "华国锋"，实际应只存 "国锋"
FULLNAME_TO_GIVEN = {
    "江青":   "青",    "毛泽东":  "泽东",  "华国锋":  "国锋",
    "王洪文": "洪文",  "张春桥":  "春桥",  "姚文元":  "文元",
    "汪东兴": "东兴",  "李先念":  "先念",  "叶剑英":  "剑英",
    "纪登奎": "登奎",  "陈锡联":  "锡联",  "朱德":    "德",
    "邓小平": "小平",  "赵紫阳":  "紫阳",  "胡耀邦":  "耀邦",
    "乔冠华": "冠华",  "毛远新":  "远新",
    # _ru 版本（相同逻辑）
    "华国锋": "国锋",  "华":      "华",
}

# ── 2. 给定名 精确对照表（原文 → 正确汉字）────────────
#   polit_surnames*_en / *_ru 的完整行映射
GIVEN_NAME_MAP = {
    # 中文政治家给定名
    "Qing":      "青",    "Цин":      "青",
    "Zedong":    "泽东",  "Цзэдун":   "泽东",
    "Guofeng":   "国锋",  "Гофэн":    "国锋",
    "Hongwen":   "洪文",  "Хунвэнь":  "洪文",
    "Chunqiao":  "春桥",  "Чуньцяо":  "春桥",
    "Wenyuan":   "文元",  "Вэньюань": "文元",
    "Dongxing":  "东兴",  "Дунсин":   "东兴",
    "Xiannian":  "先念",  "Сяньнянь": "先念",
    "Jianying":  "剑英",  "Цзяньин":  "剑英",
    "Dengkui":   "登奎",  "Дэнкуй":   "登奎",
    "Xilian":    "锡联",  "Силянь":   "锡联",
    "De":        "德",    "Дэ":       "德",
    "Hua":       "华",    "Хуа":      "华",
    "Xiaoping":  "小平",  "Сяопин":   "小平",
    "Ziyang":    "紫阳",  "Цзыян":    "紫阳",
    "Yaobang":   "耀邦",  "Яобан":    "耀邦",
    "Yun":       "云",    "Юнь":      "云",
    "Zhen":      "珍",    "Чжэнь":    "珍",
    "Guanhua":   "冠华",  "Гуаньхуа": "冠华",
    "Li":        "力",    "Ли":       "力",
    "Wey":       "伟",    "Вэй":      "伟",
    "Min":       "敏",    "Мин":      "敏",
    "Jing":      "静",    "Цзин":     "静",
    "Qiang":     "强",    "Цян":      "强",
    "Lei":       "磊",    "Лей":      "磊",
    "Jun":       "军",    "Цзюнь":    "军",
    "Yong":      "勇",    "Ён":       "勇",
    "Yan":       "颜",    "Ян":       "颜",
    "Jie":       "洁",    "Цзи":      "洁",
    "Juan":      "娟",    "Цзюань":   "娟",
    "Tao":       "涛",    "Тао":      "涛",
    "Chao":      "超",    "Чао":      "超",
    "Xiulan":    "秀兰",  "Сиулянь":  "秀兰",
    "Ping":      "平",    "Пинь":     "平",
    "Gang":      "刚",    "Ган":      "刚",
    "Guiying":   "桂英",  "Гуйин":    "桂英",
    "Xiuying":   "秀英",  "Сиуин":    "秀英",
    "Yang":      "扬",    # 此处 Yang 是给定名（区别于姓杨）
    "Feng":      "峰",    "Фэнг":     "峰",
    "Siliy":     "斯力",  "Силий":    "斯力",
    "Lu":        "路",    "Лю":       "路",
    "Yuanxin":   "远新",  "Юаньсинь": "远新",
    "Fangni":    "方妮",  "Фанъни":   "方妮",
    "Danzhi":    "丹志",  "Даньчжи":  "丹志",
    "Danding":   "丹鼎",  "Даньдин":  "丹鼎",
    "Qingshu":   "青淑",  "Циншу":    "青淑",
    "Kēsītèlièfū": "克斯特列夫", "Кэсытэлефу": "克斯特列夫",
    "Rongji":    "荣基",  "Жунцзи":   "荣基",
    "Lifu":      "礼夫",  "Лифу":     "礼夫",
    "Ye":        "叶",    "Е":        "叶",
    "Xuanning":  "宣宁",  "Сюаньнин": "宣宁",
}

# ── 3. 家族名（姓）精确对照表 ─────────────────────────
#   polit_names*_ru 的正确行序映射（原文→正确汉字）
FAMILY_NAME_MAP_RU = {
    "Цзян":    "江",   "Мао":     "毛",   "Хуа":     "华",
    "Ван":     "王",   "Чжан":    "张",   "Яо":      "姚",
    "Ли":      "李",   "Е":       "叶",   "Цзи":     "纪",
    "Чэнь":    "陈",   "У":       "吴",   "Хуан":    "黄",
    "Дэн":     "邓",   "Чжао":    "赵",   "Ху":      "胡",
    "Цяо":     "乔",   "Ва":      "华",   "Лиу":     "刘",
    "Ян":      "杨",   "Сон":     "宋",   "Пэн":     "彭",
    "Чжоу":    "周",   "Сун":     "孙",   "Ма":      "马",
    "Чжу":     "朱",   "Гуо":     "郭",   "Ме":      "何",
    "Линь":    "林",   "Си":      "谢",   "Тан":     "唐",
    "Фэнг":    "冯",   "Бао":     "鲍",   "Мэн":     "孟",
    "Ва Си Ли": "瓦西里",
    "Сюаньнин": "宣宁",
}

# 垃圾占位符模式（需要清除）
JUNK_RE = re.compile(r'[（(]\s*未(在参考表中|提供对应译名|找到|知道)[^）)]*[）)]')


def clean_junk(text: str) -> str:
    """移除 GPT 输出的注释占位符，返回空串（触发重译）"""
    if JUNK_RE.search(text):
        return ""
    return text


def load_json(path):
    with open(path, encoding="utf-8") as f:
        return json.load(f)

def save_json(path, data):
    with open(path, "w", encoding="utf-8") as f:
        json.dump(data, f, ensure_ascii=False, indent=2)


def fix_surnames_file(filename: str):
    """修正 polit_surnames* 文件：全名→仅给定名，并用精确对照表覆盖"""
    or_path = os.path.join(NEW_OR, filename)
    cn_path = os.path.join(NEW_CN, filename)
    or_data = load_json(or_path)
    cn_data = load_json(cn_path)

    or_lines = (or_data.get("m_Script") or "").splitlines()
    cn_lines = list((cn_data.get("m_Script") or "").splitlines())
    while len(cn_lines) < len(or_lines):
        cn_lines.append(or_lines[len(cn_lines)])

    changed = 0
    for i, (orig, zh) in enumerate(zip(or_lines, cn_lines)):
        orig_s = orig.strip()
        zh_s   = clean_junk(zh.strip())

        # 先用精确对照表覆盖
        correct = GIVEN_NAME_MAP.get(orig_s)
        if correct:
            if cn_lines[i].strip() != correct:
                print(f"  [{i+1:3}] {orig_s:<20} {cn_lines[i].strip():<15} → {correct}")
                cn_lines[i] = correct
                changed += 1
            continue

        # 全名 → 给定名
        if zh_s in FULLNAME_TO_GIVEN:
            fix = FULLNAME_TO_GIVEN[zh_s]
            print(f"  [{i+1:3}] {orig_s:<20} {zh_s:<15} → {fix}")
            cn_lines[i] = fix
            changed += 1
            continue

        # 清理垃圾占位符（保留原文，等 translate_missing 处理）
        if not zh_s:
            cn_lines[i] = orig
            changed += 1

    cn_data["m_Script"] = "\r\n".join(cn_lines)
    save_json(cn_path, cn_data)
    return changed


def fix_family_names_ru(filename: str):
    """修正 polit_names*_ru 文件：按原文精确映射到正确汉字"""
    or_path = os.path.join(NEW_OR, filename)
    cn_path = os.path.join(NEW_CN, filename)
    or_data = load_json(or_path)
    cn_data = load_json(cn_path)

    or_lines = (or_data.get("m_Script") or "").splitlines()
    cn_lines = list((cn_data.get("m_Script") or "").splitlines())
    while len(cn_lines) < len(or_lines):
        cn_lines.append(or_lines[len(cn_lines)])

    changed = 0
    for i, (orig, zh) in enumerate(zip(or_lines, cn_lines)):
        orig_s = orig.strip()
        correct = FAMILY_NAME_MAP_RU.get(orig_s)
        if correct and cn_lines[i].strip() != correct:
            print(f"  [{i+1:3}] {orig_s:<20} {zh.strip():<8} → {correct}")
            cn_lines[i] = correct
            changed += 1

    cn_data["m_Script"] = "\r\n".join(cn_lines)
    save_json(cn_path, cn_data)
    return changed


def main():
    total = 0
    files = sorted(os.listdir(NEW_CN))

    # A. 修正 polit_surnames*
    print("\n=== 修正 polit_surnames（给定名 全名→单名）===")
    for f in files:
        if "polit_surnames" in f and f.endswith(".json"):
            name = f.rsplit("-resources.assets-", 1)[0]
            print(f"\n📄 {name}")
            n = fix_surnames_file(f)
            total += n
            print(f"  → 修正 {n} 行")

    # B. 修正 polit_names*_ru（家族名 行序纠正）
    print("\n=== 修正 polit_names*_ru（家族名 精确映射）===")
    for f in files:
        if "polit_names" in f and "_ru" in f and f.endswith(".json"):
            name = f.rsplit("-resources.assets-", 1)[0]
            print(f"\n📄 {name}")
            n = fix_family_names_ru(f)
            total += n
            print(f"  → 修正 {n} 行")

    print(f"\n{'='*60}")
    print(f"全部修正完成，共 {total} 处")


if __name__ == "__main__":
    main()
