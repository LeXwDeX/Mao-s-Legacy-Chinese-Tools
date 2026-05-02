#!/usr/bin/env python3
"""
修复 XML 结构文件中的两类格式破坏问题：

1. 标签行尾部空格丢失：
   原始: '    <name> '  →  汉化: '    <name>'  ← WRONG，需还原
2. none 关键字错误翻译：
   原始: '        none' →  汉化: '        无' ← WRONG，需还原

受影响文件：
- new_event_text_en   (9处标签+1处none)
- new_focuses_texts_en (34处标签+24处none+缺1行末空行)
- new_focuses_texts_ru (7处none)
"""
import os, json

BASE     = os.path.dirname(os.path.abspath(__file__))
ORIG_DIR = os.path.join(BASE, "1.8.5/resources.assets.original")
CN_DIR   = os.path.join(BASE, "1.8.5/resources.assets.chinese")

TARGETS = [
    "new_event_text_en-resources.assets-271.json",
    "new_focuses_texts_en-resources.assets-291.json",
    "new_focuses_texts_ru-resources.assets-313.json",
]


def is_structural(line: str) -> bool:
    """是否为应当与原始完全一致的行（XML 标签 或 none 关键字）"""
    s = line.strip()
    if s.startswith('<'):   # 任何 XML 标签行
        return True
    if s == 'none':         # <icon> 块下的游戏引擎关键字
        return True
    return False


def fix_file(fn: str) -> dict:
    orig_path = os.path.join(ORIG_DIR, fn)
    cn_path   = os.path.join(CN_DIR,   fn)

    with open(orig_path, encoding="utf-8") as f:
        od = json.load(f)
    with open(cn_path,  encoding="utf-8") as f:
        cd = json.load(f)

    ol = od["m_Script"].splitlines()
    cl = cd["m_Script"].splitlines()

    # 保证行数至少与原始一致
    while len(cl) < len(ol):
        cl.append("")

    fixed_tags  = 0
    fixed_none  = 0
    added_lines = 0

    for i, orig_line in enumerate(ol):
        if is_structural(orig_line):
            if cl[i] != orig_line:
                s = orig_line.strip()
                if s == 'none' and cl[i].strip() == '无':
                    fixed_none += 1
                else:
                    fixed_tags += 1
                cl[i] = orig_line  # 直接还原为原始行（含尾部空格）

    # 还原末尾空行（如原始以空行结尾而汉化没有）
    if ol and not ol[-1].strip() and cl and cl[-1].strip():
        cl.append("")
        added_lines += 1

    cd["m_Script"] = "\r\n".join(cl)
    with open(cn_path, "w", encoding="utf-8") as f:
        json.dump(cd, f, ensure_ascii=False, indent=2)

    return {
        "fixed_tags":  fixed_tags,
        "fixed_none":  fixed_none,
        "added_lines": added_lines,
        "orig_lines":  len(ol),
        "cn_lines":    len(cl),
    }


def main():
    print("修复 XML 结构问题...\n")
    total_tags = total_none = 0

    for fn in TARGETS:
        name = fn.rsplit("-resources.assets-", 1)[0]
        r = fix_file(fn)
        total_tags += r["fixed_tags"]
        total_none += r["fixed_none"]
        print(f"  {name}:")
        print(f"    标签行还原: {r['fixed_tags']:2d}  |  none还原: {r['fixed_none']:2d}  "
              f"|  末尾空行: {r['added_lines']}  "
              f"|  行数: {r['orig_lines']} → {r['cn_lines']}")

    print(f"\n合计: 标签行 {total_tags} 处，none {total_none} 处")
    print("\n完成！")


if __name__ == "__main__":
    main()
