#!/usr/bin/env python3
"""
patch_textmesh.py
=================
将 sharedassets 中的静态 TextMesh UI 标签汉化：
1. 向 pt-mono / Font1 字体资产注入所需 CJK 字形（来源：Arial Unicode.ttf）
2. 修改 sa15 / sa18 的 TextMesh m_Text 为中文
3. 输出到 1.8.5_output/

字体替换策略：
  - 不替换整个字体，只向原字体注入 22 个 CJK 字形
  - 保持原 ASCII/Cyrillic 字形不变（原游戏其他文字外观不变）

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
from fontTools import subset as ft_subset
from fontTools.merge import Merger
from fontTools.ttLib import TTFont

# ── 配置 ─────────────────────────────────────────────────────────────────────

DATA_DIR    = "1.8.5_Resources/Data"
OUTPUT_DIR  = "1.8.5_output"
CJK_SOURCE  = "/Library/Fonts/Arial Unicode.ttf"

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
    48: "外交人道武器专家右翼改革倾向",   # pt-mono → UI 标签 + sa18
    49: "民族主义者游击队",               # Font1   → 派系名
}

os.makedirs(OUTPUT_DIR, exist_ok=True)

# ── 字体注入工具 ──────────────────────────────────────────────────────────────

def inject_cjk_glyphs(original_ttf_bytes: bytes, cjk_chars: str, cjk_source_path: str) -> bytes:
    """
    向原始 TTF 字节注入指定 CJK 字形。
    策略：
      1. 从 cjk_source 提取最小 CJK subset（仅所需字形）
      2. 用 fonttools.merge.Merger 合并原字体 + CJK 子集
         Merger 会自动处理 glyphOrder / hmtx / cmap 同步
      3. 返回合并后的 TTF 字节
    原字体所有字形保留；冲突时以原字体（第一参数）为准。
    """
    import tempfile, os
    unicodes = sorted(set(ord(c) for c in cjk_chars))

    # Step 1: 从 Arial Unicode 提取 CJK 子集到临时文件
    cjk_font = TTFont(cjk_source_path)
    options = ft_subset.Options()
    options.layout_features     = []
    options.name_IDs            = []
    options.ignore_missing_glyphs = True
    options.drop_tables         = ['GDEF', 'GSUB', 'GPOS', 'kern', 'mort', 'morx',
                                   'feat', 'prop', 'bsln', 'opbd', 'just', 'acnt',
                                   'LTSH', 'VDMX']
    subsetter = ft_subset.Subsetter(options=options)
    subsetter.populate(unicodes=unicodes)
    subsetter.subset(cjk_font)

    with tempfile.NamedTemporaryFile(suffix='_cjk.ttf', delete=False) as f:
        cjk_path = f.name
        cjk_font.save(cjk_path)

    # Step 2: 原始 TTF 写到临时文件
    with tempfile.NamedTemporaryFile(suffix='_orig.ttf', delete=False) as f:
        orig_path = f.name
        f.write(original_ttf_bytes)

    try:
        # 查询原字体 unitsPerEm
        orig_font   = TTFont(orig_path)
        orig_upm    = orig_font['head'].unitsPerEm
        orig_font.close()

        # 验证 CJK 子集包含所需字形
        check_font = TTFont(cjk_path)
        check_cmap = check_font.getBestCmap() or {}
        present = [chr(cp) for cp in unicodes if cp in check_cmap]
        missing = [chr(cp) for cp in unicodes if cp not in check_cmap]
        if missing:
            print(f"  [warn] CJK subset 缺少字形: {missing}")
        print(f"  CJK subset: {len(present)} 字形 / UPM={check_font['head'].unitsPerEm}")

        # 若 UPM 不同，将 CJK 子集缩放到原字体的 UPM（避免 Merger "equal" 断言失败）
        if check_font['head'].unitsPerEm != orig_upm:
            from fontTools.ttLib.scaleUpem import scale_upem
            print(f"  缩放 CJK subset UPM: {check_font['head'].unitsPerEm} → {orig_upm}")
            scale_upem(check_font, orig_upm)
            check_font.save(cjk_path)   # 覆盖原临时文件
        check_font.close()

        # Step 3: Merger 合并（原字体优先：第一参数覆盖第二参数）
        from fontTools.merge import Merger
        merger = Merger()
        merged_font = merger.merge([orig_path, cjk_path])

        # Step 4: 保存
        out_buf = io.BytesIO()
        merged_font.save(out_buf)
        result = out_buf.getvalue()
        print(f"  合并后字体大小: {len(result):,} bytes")
        return result
    finally:
        for p in [orig_path, cjk_path]:
            try: os.unlink(p)
            except: pass


# ── 修改 sharedassets3（字体资产） ────────────────────────────────────────────

def patch_fonts():
    src = f"{DATA_DIR}/sharedassets3.assets"
    dst = f"{OUTPUT_DIR}/sharedassets3.assets"
    print(f"\n[1/2] 修改字体资产: {src}")

    # 直接从原始文件加载（不先 copy2，避免加载残留的损坏文件）
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

        cjk_chars = FONT_CJK_CHARS[pid]
        print(f"  处理字体 pid={pid} ({name})，需注入字形: {cjk_chars}")

        original_bytes = bytes(d['m_FontData'])
        try:
            patched_bytes  = inject_cjk_glyphs(original_bytes, cjk_chars, CJK_SOURCE)
        except Exception as e:
            print(f"  [ERROR] 字形注入失败: {e}")
            import traceback; traceback.print_exc()
            continue

        print(f"  原始大小: {len(original_bytes):,} bytes → 新大小: {len(patched_bytes):,} bytes")
        d['m_FontData'] = list(patched_bytes)
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
