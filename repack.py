#!/usr/bin/env python3
"""
repack.py
将 1.8.5/resources.assets.chinese/ 中的汉化 JSON 回写进
1.8.5_Resources/Data/resources.assets，输出到 1.8.5_output/ 目录。

关键：按原始文件的换行符格式（\r\n 或 \n）还原，避免游戏解析失败。

用法：
    uv run --with UnityPy repack.py
"""
import os, json, sys
import UnityPy

SRC    = "1.8.5_Resources/Data/resources.assets"
ZH_DIR = "1.8.5/resources.assets.chinese"
ORIG_DIR = "1.8.5/resources.assets.original"
OUT    = "1.8.5_output"

def detect_line_ending(script: str) -> str:
    """检测字符串使用的换行符（\r\n 或 \n）"""
    if "\r\n" in script:
        return "\r\n"
    return "\n"

def normalize_line_ending(script: str, target: str) -> str:
    """将 script 的换行符统一为 target（\r\n 或 \n）"""
    # 先统一成 \n，再按目标格式输出
    unified = script.replace("\r\n", "\n")
    if target == "\r\n":
        return unified.replace("\n", "\r\n")
    return unified

def main():
    if not os.path.exists(SRC):
        print(f"❌ 找不到原始文件：{SRC}")
        sys.exit(1)
    if not os.path.isdir(ZH_DIR):
        print(f"❌ 找不到汉化目录：{ZH_DIR}")
        sys.exit(1)
    if not os.path.isdir(ORIG_DIR):
        print(f"❌ 找不到原始 JSON 目录：{ORIG_DIR}")
        sys.exit(1)

    # ── 1. 读取汉化 JSON，构建 path_id → m_Script 映射 ──
    zh_map: dict[int, str] = {}
    for fname in os.listdir(ZH_DIR):
        if not fname.endswith(".json"):
            continue
        parts = fname.rsplit("-", 1)
        if len(parts) != 2:
            continue
        try:
            pid = int(parts[1].replace(".json", ""))
        except ValueError:
            continue
        with open(os.path.join(ZH_DIR, fname), encoding="utf-8") as f:
            d = json.load(f)
        zh_map[pid] = d.get("m_Script") or ""

    print(f"✅ 读取汉化文件：{len(zh_map)} 个")

    # ── 2. 读取原始 JSON，构建 path_id → 换行符格式 映射 ──
    orig_eol: dict[int, str] = {}
    for fname in os.listdir(ORIG_DIR):
        if not fname.endswith(".json"):
            continue
        parts = fname.rsplit("-", 1)
        if len(parts) != 2:
            continue
        try:
            pid = int(parts[1].replace(".json", ""))
        except ValueError:
            continue
        with open(os.path.join(ORIG_DIR, fname), encoding="utf-8") as f:
            d = json.load(f)
        orig_eol[pid] = detect_line_ending(d.get("m_Script") or "")

    crlf_count = sum(1 for v in orig_eol.values() if v == "\r\n")
    print(f"✅ 检测原始换行符：{crlf_count} 个文件使用 \\r\\n，"
          f"{len(orig_eol) - crlf_count} 个使用 \\n")

    # ── 3. 加载原始 resources.assets ──
    print(f"📦 加载：{SRC} …")
    env = UnityPy.load(SRC)
    all_text = [o for o in env.objects if o.type.name == "TextAsset"]
    print(f"   TextAsset 总数：{len(all_text)}")

    # ── 4. 逐个替换 m_Script，并还原原始换行符格式 ──
    modified = 0
    skipped  = 0
    eol_fixed = 0
    for obj in all_text:
        if obj.path_id not in zh_map:
            print(f"  ⚠ path_id={obj.path_id} 无对应汉化文件，跳过")
            skipped += 1
            continue
        data = obj.read()
        new_script = zh_map[obj.path_id]

        # 按原始换行符格式还原
        target_eol = orig_eol.get(obj.path_id, "\n")
        new_script_normalized = normalize_line_ending(new_script, target_eol)
        if new_script_normalized != new_script:
            eol_fixed += 1

        if data.m_Script == new_script_normalized:
            continue          # 内容未变，不标记为 dirty
        data.m_Script = new_script_normalized
        data.save()
        modified += 1

    print(f"   修改：{modified} 个 | 跳过：{skipped} 个 | 换行符还原：{eol_fixed} 个")

    # ── 5. 写出 ──
    os.makedirs(OUT, exist_ok=True)
    out_file = os.path.join(OUT, "resources.assets")
    print(f"💾 写出：{out_file} …")
    env.save(pack="none", out_path=OUT)

    size_mb = os.path.getsize(out_file) / 1024 / 1024
    print(f"✅ 完成！文件大小：{size_mb:.1f} MB → {out_file}")

if __name__ == "__main__":
    main()
