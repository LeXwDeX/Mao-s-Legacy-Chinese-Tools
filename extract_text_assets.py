#!/usr/bin/env python3
"""
extract_text_assets.py
从 resources.assets 提取所有 *_en TextAsset 为独立 JSON 文件。

输出目录: text_assets/
每个 TextAsset 输出一个 JSON：
  {
    "asset_name": "new_texts_en",
    "path_id": 315,
    "total_lines": 1099,
    "lines": ["<color=aqua>Jimmy Carter</color>", ...]
  }

同时输出 text_assets/MANIFEST.json 汇总所有文件的元信息。

用法：
    uv run --with UnityPy python3 extract_text_assets.py
"""

import json, os
from datetime import datetime

try:
    import UnityPy
except ImportError:
    raise SystemExit("需要 UnityPy: uv run --with UnityPy python3 extract_text_assets.py")

INPUT   = "1.8.5_Resources/Data/resources.assets"
OUT_DIR = "text_assets"


def main():
    env = UnityPy.load(INPUT)
    os.makedirs(OUT_DIR, exist_ok=True)

    manifest = {
        "generated": datetime.now().isoformat(),
        "source": INPUT,
        "assets": [],
    }

    en_count = 0
    total_lines = 0

    for obj in env.objects:
        if obj.type.name != "TextAsset":
            continue
        data = obj.read()
        name = data.m_Name
        content = (data.m_Script if isinstance(data.m_Script, str)
                   else data.m_Script.decode("utf-8", errors="replace"))

        # 检测换行模式：\r\n 优先，否则 \n
        if "\r\n" in content:
            line_ending = "\r\n"
        else:
            line_ending = "\n"
        lines = content.split(line_ending)
        # strip 每行残留的 \r（防止 \n 分割后残留）
        lines = [l.rstrip("\r") for l in lines]
        # 去掉末尾空元素（文件末尾换行产生的）
        while lines and lines[-1] == "":
            lines.pop()

        entry = {
            "asset_name": name,
            "path_id": obj.path_id,
            "size_bytes": len(content.encode("utf-8")),
            "total_lines": len(lines),
        }

        # 只输出 *_en 文件的详细 JSON（翻译目标）
        # 同时也输出其他 _en 后缀的文件（Country_en, Doctr_en 等）
        is_en = name.endswith("_en") or name.startswith("Part") and name.endswith("_en")
        # 宽泛匹配：所有名字中含 en 且有对应 ru 版本的
        # 但也输出 _ru 文件作为参考

        out_path = os.path.join(OUT_DIR, f"{name}.json")
        record = {
            "asset_name": name,
            "path_id": obj.path_id,
            "total_lines": len(lines),
            "line_ending": repr(line_ending),
            "lines": lines,
        }
        with open(out_path, "w", encoding="utf-8") as f:
            json.dump(record, f, ensure_ascii=False, indent=2)

        if is_en:
            en_count += 1
            total_lines += len(lines)
            entry["translatable"] = True
        else:
            entry["translatable"] = name.endswith("_en")

        manifest["assets"].append(entry)

    # 排序
    manifest["assets"].sort(key=lambda x: x["asset_name"])
    manifest["summary"] = {
        "total_text_assets": len(manifest["assets"]),
        "en_assets": en_count,
        "en_total_lines": total_lines,
    }

    manifest_path = os.path.join(OUT_DIR, "MANIFEST.json")
    with open(manifest_path, "w", encoding="utf-8") as f:
        json.dump(manifest, f, ensure_ascii=False, indent=2)

    print(f"提取完成 → {OUT_DIR}/")
    print(f"  TextAsset 总数: {len(manifest['assets'])}")
    print(f"  *_en 文件数: {en_count}")
    print(f"  *_en 总行数: {total_lines}")
    print()
    print("=== *_en 文件概览 ===")
    for a in manifest["assets"]:
        if a.get("translatable") or a["asset_name"].endswith("_en"):
            print(f"  {a['asset_name']:<35} {a['total_lines']:>5} 行  {a['size_bytes']:>8} B")


if __name__ == "__main__":
    main()
