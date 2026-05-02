#!/usr/bin/env python3
"""
repack.py
将 1.8.5/resources.assets.chinese/ 中的汉化 JSON 回写进
1.8.5_Resources/Data/resources.assets，输出到 1.8.5_output/ 目录。

用法：
    uv run --with UnityPy repack.py
"""
import os, json, sys
import UnityPy

SRC    = "1.8.5_Resources/Data/resources.assets"
ZH_DIR = "1.8.5/resources.assets.chinese"
OUT    = "1.8.5_output"

def main():
    if not os.path.exists(SRC):
        print(f"❌ 找不到原始文件：{SRC}")
        sys.exit(1)
    if not os.path.isdir(ZH_DIR):
        print(f"❌ 找不到汉化目录：{ZH_DIR}")
        sys.exit(1)

    # ── 1. 读取所有汉化 JSON，构建 path_id → m_Script 映射 ──
    zh_map: dict[int, str] = {}
    for fname in os.listdir(ZH_DIR):
        if not fname.endswith(".json"):
            continue
        # 文件名格式：{m_Name}-resources.assets-{path_id}.json
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

    # ── 2. 加载原始 resources.assets ──
    print(f"📦 加载：{SRC} …")
    env = UnityPy.load(SRC)
    all_text = [o for o in env.objects if o.type.name == "TextAsset"]
    print(f"   TextAsset 总数：{len(all_text)}")

    # ── 3. 逐个替换 m_Script ──
    modified = 0
    skipped  = 0
    for obj in all_text:
        if obj.path_id not in zh_map:
            print(f"  ⚠ path_id={obj.path_id} 无对应汉化文件，跳过")
            skipped += 1
            continue
        data = obj.read()
        new_script = zh_map[obj.path_id]
        if data.m_Script == new_script:
            continue          # 内容未变，不标记为 dirty
        data.m_Script = new_script
        data.save()
        modified += 1

    print(f"   修改：{modified} 个 | 跳过：{skipped} 个")

    # ── 4. 写出 ──
    os.makedirs(OUT, exist_ok=True)
    out_file = os.path.join(OUT, "resources.assets")
    print(f"💾 写出：{out_file} …")
    env.save(pack="none", out_path=OUT)

    size_mb = os.path.getsize(out_file) / 1024 / 1024
    print(f"✅ 完成！文件大小：{size_mb:.1f} MB → {out_file}")

if __name__ == "__main__":
    main()
