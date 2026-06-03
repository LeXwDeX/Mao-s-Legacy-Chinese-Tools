#!/usr/bin/env python3
"""
patch_textmesh.py
=================
将 sharedassets 中的静态 TextMesh UI 标签汉化：
1. 向 pt-mono / Font1 字体资产注入所需 CJK 字形（来源：Arial Unicode.ttf）
2. 修改 sa15 / sa18 的 TextMesh m_Text 为中文
3. 输出到 1.8.5_output/

字体注入策略：
  - 不替换整个字体，只向原字体注入所需 CJK 字形（来源：LXGW WenKai Mono v1.522，开源）
  - 保持原 ASCII/Cyrillic 字形不变（原游戏其他文字外观不变）
  - LXGW 字体文件：fonts/LXGWWenKaiMono-Regular.ttf

翻译映射（可在此修改）:
  ДИПЛ          → 外交
  ГУМАН         → 人道
  ОРУЖИЕ        → 武器
  СПЕЦЫ         → 专家
  Националисты  → 民族主义者
  Партизаны     → 游击队
  Стремление к правым реформам → 右翼改革倾向
"""

import io
import os
import shutil
import sys

import UnityPy

# ── 配置 ─────────────────────────────────────────────────────────────────────

DATA_DIR    = "1.8.5_Resources/Data"
OUTPUT_DIR  = "1.8.5_output"
CJK_SOURCE  = "fonts/LXGWWenKaiMono-Regular.ttf"

# (文件名, path_id, 新中文文本)
TEXTMESH_PATCHES = [
    ("sharedassets15.assets", 111, "民族主义者"),
    ("sharedassets15.assets", 112, "游击队"),
    ("sharedassets15.assets", 115, "外交"),
    ("sharedassets15.assets", 116, "人道"),
    ("sharedassets15.assets", 117, "武器"),
    ("sharedassets15.assets", 118, "专家"),
    ("sharedassets15.assets", 119, "专家"),
    ("sharedassets15.assets", 120, "外交"),
    ("sharedassets15.assets", 121, "武器"),
    ("sharedassets15.assets", 122, "人道"),
    ("sharedassets18.assets", 24,  "右翼改革倾向"),
]

# 需要注入 CJK 字形的字体（sa3 内）
# {path_id: 该字体 TextMesh 所需的汉字集合}
FONT_CJK_CHARS = {
    # pt-mono: UI 标签 + sa18 文本 + level17 教程常用字
    48: (
        "外交人道武器专家右翼改革倾向"  # 原 12 字
        "预算工业农业服务业腐败军队部宣传福利使团储备"
        "债务损耗生活平科技主义世界影响"
        "任命调查再教育派领袖中央军委首都北南东西方"
        "监控民点详拨款特赦追捕名姓政立场魅子女权谋"
        "入狱地下业已"
    ),
    # Font1: 派系名 + level21/24 阵营
    49: (
        "民族主义者游击队"  # 原 8 字
        "毛主义保守温和派自由改革激进亲华亲西"
    ),
}

os.makedirs(OUTPUT_DIR, exist_ok=True)


# ── 修改 sharedassets3（字体资产） ────────────────────────────────────────────

def patch_fonts():
    """
    将游戏字体资产整体替换为 LXGW WenKai Mono（避免 Merger 兼容性问题）。
    视觉风格会变化，但 CJK/ASCII/Cyrillic 全覆盖，对全中文化项目更合适。
    """
    src = f"{DATA_DIR}/sharedassets3.assets"
    dst = f"{OUTPUT_DIR}/sharedassets3.assets"
    print(f"\n[1/2] 替换字体资产: {src}")
    print(f"  字体源: {CJK_SOURCE}")

    if not os.path.exists(CJK_SOURCE):
        print(f"  [ERROR] 字体源不存在: {CJK_SOURCE}")
        return

    replacement_bytes = open(CJK_SOURCE, "rb").read()
    print(f"  替换字体大小: {len(replacement_bytes):,} bytes")

    env = UnityPy.load(src)

    modified = False
    for obj in env.objects:
        if obj.type.name != "Font":
            continue
        data = obj.read()
        d    = data.__dict__
        pid  = obj.path_id
        name = d.get('m_Name', '?')

        if pid not in FONT_CJK_CHARS:
            continue

        print(f"  替换字体 pid={pid} ({name}) → LXGW WenKai Mono")

        d['m_FontData'] = list(replacement_bytes)
        data.save()
        modified = True

    if modified:
        env.save(pack="none", out_path=OUTPUT_DIR)
        print(f"  ✓ 已写出: {dst}")
    else:
        print(f"  [warn] 未找到目标字体资产（pid={list(FONT_CJK_CHARS.keys())}），跳过")


# ── 修改 TextMesh 文本 ────────────────────────────────────────────────────────

def patch_textmesh_texts():
    print(f"\n[2/2] 修改 TextMesh 文本")

    # 按文件分组
    by_file: dict[str, list] = {}
    for fname, pid, text in TEXTMESH_PATCHES:
        by_file.setdefault(fname, []).append((pid, text))

    for fname, patches in by_file.items():
        src = f"{DATA_DIR}/{fname}"
        dst = f"{OUTPUT_DIR}/{fname}"
        print(f"\n  文件: {fname}")

        if not os.path.exists(src):
            print(f"  [warn] 文件不存在: {src}，跳过")
            continue

        # 直接从原始文件加载（不先 copy2）
        env = UnityPy.load(src)

        pid_map = {pid: text for pid, text in patches}
        modified = False
        for obj in env.objects:
            if obj.type.name != "TextMesh":
                continue
            if obj.path_id not in pid_map:
                continue
            data = obj.read()
            d    = data.__dict__
            old  = d.get('m_Text', '')
            new  = pid_map[obj.path_id]
            print(f"    pid={obj.path_id}: {repr(old)} → {repr(new)}")
            d['m_Text'] = new
            data.save()
            modified = True

        if modified:
            env.save(pack="none", out_path=OUTPUT_DIR)
            print(f"  ✓ 已写出: {dst}")
        else:
            print(f"  [warn] 未找到目标 TextMesh，跳过")


# ── 主入口 ────────────────────────────────────────────────────────────────────

if __name__ == "__main__":
    print("=" * 60)
    print("patch_textmesh.py — TextMesh 汉化 + 字体 CJK 注入")
    print("=" * 60)
    patch_fonts()
    patch_textmesh_texts()
    print("\n✓ 完成。输出目录:", OUTPUT_DIR)
    print("  需要复制的文件:")
    print("    sharedassets3.assets  → 游戏Data/")
    print("    sharedassets15.assets → 游戏Data/")
    print("    sharedassets18.assets → 游戏Data/")
