#!/usr/bin/env python3
"""
dll_patch.py
读取 dll_strings/translated.json，将中文译文 in-place 写入 Assembly-CSharp.dll。

策略：
  - 每条字符串的 available_chars = (length - 1) // 2
  - 将中文译文编码为 UTF-16LE，不足部分用 U+0020（空格）填充
  - 超长则截断（translate 步骤已保证不超长）
  - terminal byte 设为 0x01（HasHighChars = True，因为含 CJK）
  - 只修改有 translated 字段且 translated != text 的条目

输入：
  Assembly-CSharp.dll（游戏目录）
输出：
  1.8.5_output/Assembly-CSharp.dll（patched 副本，不修改原文件）

用法：
  uv run python3 dll_patch.py
  uv run python3 dll_patch.py --deploy   # 同时部署到游戏目录
"""
import json, os, shutil, struct, argparse

SRC_DLL  = "1.8.5_Resources/Data/Managed/Assembly-CSharp.dll"   # 原始备份
OUT_DIR  = "1.8.5_output"
OUT_DLL  = os.path.join(OUT_DIR, "Assembly-CSharp.dll")
TRANS_FILE = "dll_strings/translated.json"

DEPLOY_PATH = "/Users/lex/Library/Application Support/Steam/steamapps/common/Mao's Legacy/China.app/Contents/Resources/Data/Managed/Assembly-CSharp.dll"


MIN_SAFE_CHARS = 8   # 只翻译 avail >= 8 的条目，排除极短的内部标识符

# 绝对禁止翻译的偏移量（游戏代码用作查找键或内部标识符的字符串）
DENY_OFFSETS: set[int] = {
    # ── Unity 输入轴名称（Input.GetAxis / Input.GetButton 第一参数）──────────
    0x355EC5,   # 'Five no'          (avail=7)  — 事件查找键
    0x3569AF,   # 'Mouse Y'          (avail=7)  — Unity 输入轴名
    0x3569BF,   # 'Mouse X'          (avail=7)  — Unity 输入轴名
    0x2D2A6D,   # 'Mouse ScrollWheel'(avail=17) — Unity 输入轴名（滚轮缩放）

    # ── Unity GameObject 名称（Transform.Find / GameObject.Find 参数）────────
    # Play 按钮和速度档按钮在场景中以 "Button (N)" 命名，
    # C# 代码通过 transform.Find("Button (0)") 等方式定位它们。
    0x2D5820,   # 'Button (0)'       (avail=10)
    0x2D48C7,   # 'Button (2)'       (avail=10)
    0x35117C,   # 'Button (4)'       (avail=10)
    0x1ECF85,   # 'Button (5)'       (avail=10)

    # ── Unity UI 组件名称（同 GameObject.Find 模式）────────────────────────
    0x1ED009,   # 'Text (1)'         (avail=8)
    0x1ECFB1,   # 'TextIf (0)'       (avail=10)
    0x1ECFC7,   # 'TextIf (1)'       (avail=10)
    0x1ECFDD,   # 'TextIf (2)'       (avail=10)
    0x1ECFF3,   # 'TextIf (3)'       (avail=10)

    # ── 游戏内部类型标识符（Znach/Znakc 系列）──────────────────────────────
    # 极可能作为字典键或枚举字符串被 C# 代码直接比较
    0x183F1F,   # 'Znach (0)'        (avail=9)
    0x183F5B,   # 'Znach (1)'        (avail=9)
    0x183F6F,   # 'Znach (2)'        (avail=9)
    0x183F83,   # 'Znach (3)'        (avail=9)
    0x183F97,   # 'Znach (4)'        (avail=9)
    0x183FAB,   # 'Znach (5)'        (avail=9)
    0x195245,   # 'Znakc (1)'        (avail=9)

    # ── 其他可疑内部名称 ────────────────────────────────────────────────────
    0x356CC5,   # 'Sprite ['         (avail=8)  — Unity 精灵路径前缀
    0x3557CD,   # 'Start Focus'      (avail=11) — 可能是 Animator.SetTrigger 参数
    0x2D27FD,   # 'Capture_it SDF'   (avail=14) — Resources.Load 字体资源键
}

# 经人工确认的短字符串白名单：这些 offset 对应的是展示用文本（非查找键），
# 允许绕过 MIN_SAFE_CHARS 限制（目前 MIN_SAFE_CHARS 已降至 8，此白名单保留备用）。
APPROVED_OFFSETS: set[int] = {
    0x1F877B,   # 'Five "no"' (avail=9) → 五个"不"  展示标题，紧邻正文描述块
    0x1ECAB9,   # '\nDate: '  (avail=7) → 日期：     展示用日期标签
    0x2D41B0,   # ' or in '   (avail=7) → 或者在     展示用连词
    0x355813,   # 'New old'   (avail=7) → 新的旧物   展示用名词短语
    # ── 外交/学说/战争按钮（动态 TextMesh 文本）──────────────────────────────
    0x1937C8,   # 'CMEA'    (avail=4) → 经互会    外交按钮
    0x1937FE,   # 'Support' (avail=7) → 援助      外交按钮
    0x193820,   # 'Trade'   (avail=5) → 贸易      外交按钮
    0x19382C,   # 'Union'   (avail=5) → 联合      外交按钮
    0x19384A,   # 'Unrests' (avail=7) → 动乱      外交按钮
    0x19385A,   # 'Coup'    (avail=4) → 政变      外交按钮
    0x193878,   # 'War'     (avail=3) → 战争      外交按钮
    0x193880,   # 'Weapons' (avail=7) → 军火      外交按钮
    0x1A2AC5,   # 'Limited' (avail=7) → 有限      学说按钮
    0x2C3C53,   # 'HUM.'    (avail=4) → 人道      战争按钮
    0x2C3C5D,   # 'SPEC.'   (avail=5) → 专家      战争按钮
    0x2C3C69,   # 'WEAP.'   (avail=5) → 军火      战争按钮
    0x2C3C75,   # 'DIPL.'   (avail=5) → 外交      战争按钮
    # ── 存档/读档难度名与提示（Savescript/LoadInScript/DiffScript 共用）───────
    0x1941F6,   # 'Sandbox' (avail=7) → 沙盒      难度名
    0x194226,   # 'Easy'    (avail=4) → 简单      难度名
    0x194230,   # 'Normal'  (avail=6) → 标准      难度名
    0x19425E,   # 'Hard'    (avail=4) → 困难      难度名
    0x2C0ACA,   # 'Saved.'  (avail=6) → 已保存    存档提示
}


def patch_dll(data: bytearray, entries: dict) -> tuple[int, int]:
    patched = 0
    skipped = 0

    for key, v in entries.items():
        orig_text  = v.get("text", "")
        zh_text    = v.get("translated", "")
        abs_off    = v["offset"]
        hs         = v["header_size"]
        length     = v["length"]
        avail      = v["available_chars"]

        # 跳过未翻译或与原文相同的条目
        if not zh_text or zh_text == orig_text:
            skipped += 1
            continue

        # 安全策略一：明确禁止翻译的偏移量（查找键/内部标识符）
        if abs_off in DENY_OFFSETS:
            skipped += 1
            continue

        # 安全策略二：avail 过短且不在白名单内的字符串跳过
        if avail < MIN_SAFE_CHARS and abs_off not in APPROVED_OFFSETS:
            skipped += 1
            continue

        # 确保不超出可用空间
        if len(zh_text) > avail:
            zh_text = zh_text[:avail]

        # 编码为 UTF-16LE
        encoded = zh_text.encode("utf-16-le")
        # 填充空格至恰好 avail * 2 字节
        total_content_bytes = avail * 2
        padding_bytes = total_content_bytes - len(encoded)
        assert padding_bytes >= 0, f"padding < 0 for {key}"
        content = encoded + b"\x20\x00" * (padding_bytes // 2)
        if padding_bytes % 2:
            content += b"\x00"   # 不应出现，但防御性处理

        assert len(content) == total_content_bytes, \
            f"content length mismatch: {len(content)} != {total_content_bytes}"

        # 写入：content + terminal byte 0x01（HasHighChars）
        write_start = abs_off + hs
        write_end   = write_start + length

        # 验证当前内容匹配原文（防止偏移计算错误）
        existing_raw = bytes(data[write_start : write_start + avail * 2])
        try:
            existing_text = existing_raw.decode("utf-16-le")
        except Exception:
            existing_text = ""

        if existing_text.rstrip() != orig_text.rstrip():
            # 偏移不匹配，跳过以防损坏 DLL
            print(f"  ⚠ 偏移校验失败 {key}: 期望 {repr(orig_text[:40])} 实际 {repr(existing_text[:40])}")
            skipped += 1
            continue

        data[write_start : write_start + avail * 2] = content
        data[write_start + avail * 2] = 0x01   # terminal byte = HasHighChars

        patched += 1

    return patched, skipped


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--deploy", action="store_true", help="同时部署 DLL 到游戏目录")
    args = parser.parse_args()

    os.makedirs(OUT_DIR, exist_ok=True)

    print(f"读取翻译: {TRANS_FILE}")
    with open(TRANS_FILE, encoding="utf-8") as f:
        entries: dict = json.load(f)

    to_patch = sum(1 for v in entries.values()
                   if v.get("translated") and v["translated"] != v["text"])
    print(f"需 patch 条目: {to_patch}")

    print(f"读取 DLL …")
    with open(SRC_DLL, "rb") as f:
        data = bytearray(f.read())

    print(f"开始 patch …")
    patched, skipped = patch_dll(data, entries)
    print(f"  已 patch: {patched}  跳过: {skipped}")

    # 写出 patched DLL
    print(f"写出: {OUT_DLL}")
    with open(OUT_DLL, "wb") as f:
        f.write(data)

    # 校验
    import hashlib
    orig_md5 = hashlib.md5(open(SRC_DLL, "rb").read()).hexdigest()
    out_md5  = hashlib.md5(bytes(data)).hexdigest()
    print(f"原始 MD5: {orig_md5}")
    print(f"输出 MD5: {out_md5}")

    if args.deploy:
        shutil.copy2(OUT_DLL, DEPLOY_PATH)
        print(f"✅ 已部署到: {DEPLOY_PATH}")
    else:
        print(f"提示: 加 --deploy 参数自动部署到游戏目录")


if __name__ == "__main__":
    main()
