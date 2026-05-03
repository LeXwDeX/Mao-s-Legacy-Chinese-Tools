#!/usr/bin/env python3
"""
inject_text_assets.py
将翻译后的 *_zh.json 写回 resources.assets，替换对应 *_en TextAsset 的内容。

策略：
  - 保持 asset_name 不变（游戏按 "new_texts_en" 名加载，不能改名）
  - 仅替换 m_Script（文本内容），保留原始 path_id
  - 保留原始换行符格式（\r\n 或 \n）

用法：
    uv run --with UnityPy python3 inject_text_assets.py
    uv run --with UnityPy python3 inject_text_assets.py --dry-run  # 只检查不写入
"""

import json, os, sys, shutil
from pathlib import Path
from datetime import datetime

try:
    import UnityPy
except ImportError:
    raise SystemExit("需要 UnityPy: uv run --with UnityPy python3 inject_text_assets.py")

INPUT_ASSETS = Path("1.8.5_Resources/Data/resources.assets")
ZH_DIR       = Path("text_assets")
OUTPUT_DIR   = Path("1.8.5_output")
OUTPUT_FILE  = OUTPUT_DIR / "resources.assets"

# 游戏安装目录
GAME_DATA    = Path(os.path.expanduser(
    "~/Library/Application Support/Steam/steamapps/common/Mao's Legacy/China.app/Contents/Resources/Data"))


def load_zh_translations() -> dict:
    """加载所有 *_zh.json 翻译文件，返回 {en_asset_name: zh_data}。"""
    translations = {}
    for f in sorted(ZH_DIR.glob("*_zh.json")):
        if f.name.startswith("."):
            continue
        data = json.loads(f.read_text(encoding="utf-8"))
        source_name = data.get("source", f.stem.replace("_zh", "_en"))
        translations[source_name] = data
    return translations


def main():
    import argparse
    parser = argparse.ArgumentParser(description="注入翻译到 resources.assets")
    parser.add_argument("--dry-run", action="store_true", help="只检查，不实际写入")
    parser.add_argument("--no-deploy", action="store_true", help="不复制到游戏目录")
    args = parser.parse_args()

    # 加载翻译
    translations = load_zh_translations()
    print(f"已加载翻译文件: {len(translations)} 个")
    for name in sorted(translations):
        print(f"  {name}: {translations[name]['total_lines']} 行")
    print()

    if not INPUT_ASSETS.exists():
        print(f"✗ 源文件不存在: {INPUT_ASSETS}")
        sys.exit(1)

    # 加载资产
    env = UnityPy.load(str(INPUT_ASSETS))
    injected = 0
    skipped = 0
    errors = []

    for obj in env.objects:
        if obj.type.name != "TextAsset":
            continue
        data = obj.read()
        name = data.m_Name

        if name not in translations:
            continue

        zh = translations[name]
        zh_lines = zh["lines"]

        # 确定原始换行符
        original_script = (data.m_Script if isinstance(data.m_Script, str)
                          else data.m_Script.decode("utf-8", errors="replace"))
        if "\r\n" in original_script:
            line_ending = "\r\n"
        else:
            line_ending = "\n"

        # 验证行数
        original_lines = original_script.split(line_ending)
        # 去掉末尾空元素
        while original_lines and original_lines[-1] == "":
            original_lines.pop()

        if len(zh_lines) != len(original_lines):
            errors.append(f"{name}: 行数不匹配 (原文{len(original_lines)} vs 翻译{len(zh_lines)})")
            continue

        # 构建新内容
        new_content = line_ending.join(zh_lines)
        # 如果原始内容以换行结尾，新内容也以换行结尾
        if original_script.endswith(line_ending):
            new_content += line_ending

        if args.dry_run:
            old_size = len(original_script.encode("utf-8"))
            new_size = len(new_content.encode("utf-8"))
            print(f"  [dry-run] {name}: {old_size}B → {new_size}B ({new_size-old_size:+d})")
            injected += 1
            continue

        # 写入
        data.m_Script = new_content
        data.save()
        injected += 1

        old_size = len(original_script.encode("utf-8"))
        new_size = len(new_content.encode("utf-8"))
        print(f"  ✓ {name}: {old_size}B → {new_size}B ({new_size-old_size:+d})")

    print()
    if errors:
        print(f"⚠ 错误 ({len(errors)}):")
        for e in errors:
            print(f"  {e}")
        print()

    print(f"注入结果: {injected} 成功, {len(errors)} 错误")

    if args.dry_run:
        print("\n(dry-run 模式，未实际修改文件)")
        return

    # 保存修改后的资产
    OUTPUT_DIR.mkdir(parents=True, exist_ok=True)
    with open(OUTPUT_FILE, "wb") as f:
        f.write(env.file.save())
    print(f"\n✓ 输出: {OUTPUT_FILE} ({OUTPUT_FILE.stat().st_size:,} bytes)")

    # 部署到游戏目录
    if not args.no_deploy and GAME_DATA.exists():
        dest = GAME_DATA / "resources.assets"
        # 备份
        backup = GAME_DATA / "resources.assets.bak"
        if not backup.exists() and dest.exists():
            shutil.copy2(dest, backup)
            print(f"  备份: {backup}")
        shutil.copy2(OUTPUT_FILE, dest)
        print(f"  ✓ 已部署到: {dest}")
    elif not GAME_DATA.exists():
        print(f"\n游戏目录不存在: {GAME_DATA}")
        print("请手动复制输出文件到游戏 Data/ 目录")


if __name__ == "__main__":
    main()
