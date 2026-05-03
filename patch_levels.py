#!/usr/bin/env python3
"""
patch_levels.py
对 Unity level 文件做 in-place 二进制 patch，替换 MonoBehaviour 序列化字符串。

字符串格式：[4字节LE长度][UTF-8内容][零填充到4字节对齐]
约束：padded_block_size(zh_utf8) == padded_block_size(orig_utf8)
    （文件中每个字符串条目的总字节数必须不变，否则后续数据偏移全部错位）

用法：
    uv run python3 patch_levels.py            # 只输出到 1.8.5_output/
    uv run python3 patch_levels.py --dry-run  # 仅显示将替换哪些字符串
    uv run python3 patch_levels.py --deploy   # 同时部署到游戏目录
"""

import math, struct, shutil, os, argparse

INPUT_DIR  = "1.8.5_Resources/Data"
OUTPUT_DIR = "1.8.5_output"
DEPLOY_DIR = (
    "/Users/lex/Library/Application Support/Steam/steamapps/common/"
    "Mao's Legacy/China.app/Contents/Resources/Data"
)


def padded_block(n_bytes: int) -> int:
    """Unity 字符串内容区对齐到4字节后的大小（不含4字节长度前缀）。"""
    return math.ceil(n_bytes / 4) * 4


def find_and_patch(data: bytearray, eng: str, zh: str,
                   dry_run: bool = False,
                   exclude_offsets: set | None = None) -> list[int]:
    """
    搜索 data 中所有 [4B-LE-len][utf8-content][zero-pad] 的出现，
    替换为中文等价字符串。返回所有已替换的偏移列表。

    安全校验：
    1. 模式匹配（length前缀 + 内容）
    2. 后续零填充吻合
    3. padded_block(zh) == padded_block(eng)

    exclude_offsets：跳过这些源文件偏移（面板路由键等不可翻译位置）。
    """
    eng_b = eng.encode("utf-8")
    zh_b  = zh.encode("utf-8")
    eng_pb = padded_block(len(eng_b))
    zh_pb  = padded_block(len(zh_b))

    if eng_pb != zh_pb:
        raise ValueError(
            f"Block size mismatch for '{eng}' (blk={eng_pb}) "
            f"→ '{zh}' (blk={zh_pb}). 请修正译文长度。"
        )

    search_pattern = struct.pack("<I", len(eng_b)) + eng_b
    patched_offsets: list[int] = []
    start = 0

    while True:
        idx = data.find(search_pattern, start)
        if idx == -1:
            break

        # 跳过路由键等不可翻译位置
        if exclude_offsets and idx in exclude_offsets:
            start = idx + 1
            continue

        # 验证后续确实是零填充（防止误命中非字符串区域）
        pad_count = eng_pb - len(eng_b)
        if pad_count > 0:
            actual_pad = bytes(data[idx + 4 + len(eng_b):
                                    idx + 4 + eng_pb])
            if actual_pad != bytes(pad_count):
                start = idx + 1
                continue

        # ── 执行替换 ─────────────────────────────────────────────
        if not dry_run:
            new_len_bytes = struct.pack("<I", len(zh_b))
            new_content   = zh_b + bytes(zh_pb - len(zh_b))   # 内容 + 零填充
            data[idx: idx + 4 + eng_pb] = new_len_bytes + new_content

        patched_offsets.append(idx)
        start = idx + 4 + eng_pb  # 跳过刚处理的条目，防止重叠匹配

    return patched_offsets


# ──────────────────────────────────────────────────────────────────────────────
# 翻译表
# ──────────────────────────────────────────────────────────────────────────────

# 导航标签（适用于所有 target level 文件）
# 字节约束：padded_block(zh) == padded_block(eng)，已全部验证通过
GLOBAL_PATCHES: list[tuple[str, str]] = [
    ("World Map",   "世界地图"),   # 9B→12B, blk=12
    ("Economy",     "经济"),       # 7B→6B,  blk=8
    ("Science",     "科技"),       # 7B→6B,  blk=8
    ("Doctrines",   "意识形态"),   # 9B→12B, blk=12
    ("Politics",    "政治"),       # 8B→6B,  blk=8
    ("Wars",        "战"),         # 4B→3B,  blk=4
    ("Trade",       "贸易"),       # 5B→6B,  blk=8
    ("Influence",   "影响力"),     # 9B→9B,  blk=12
    ("Territories", "所辖领土"),   # 11B→12B,blk=12
    ("Situations",  "局势状况"),   # 10B→12B,blk=12
    ("Unity",       "统一"),       # 5B→6B,  blk=8
    ("Allies",      "盟友"),       # 6B→6B,  blk=8
    ("View",        "视"),         # 4B→3B,  blk=4
]

# 文件专属翻译（只写入指定 level 文件）
FILE_PATCHES: dict[str, list[tuple[str, str]]] = {
    "level6": [
        ("Government",               "政府机构"),     # 10B→12B, blk=12
        ("Military",                 "军事"),          # 8B→6B,   blk=8
        ("Continue",                 "继续"),          # 8B→6B,   blk=8
        ("End the game",             "结束游戏"),      # 12B→12B, blk=12
        ("It's time for our Future", "是时候规划未来了"), # 24B→24B, blk=24
        ("Finish",                   "完成"),          # 6B→6B,   blk=8
        ("Load",                     "载"),            # 4B→3B,   blk=4
        ("Citizens",                 "公民"),          # 8B→6B,   blk=8
    ],
    "level9": [
        ("Industry",                     "工业"),        # 8B→6B,  blk=8
        ("Agriculture",                  "农业发展"),    # 11B→12B,blk=12
        ("Services",                     "服务"),        # 8B→6B,  blk=8
        ("Corruption",                   "腐败程度"),    # 10B→12B,blk=12
        ("Army",                         "军"),          # 4B→3B,  blk=4
        ("MSS",                          "局"),          # 3B→3B,  blk=4
        ("State mechanism",              "国家行政部"),  # 15B→15B,blk=16
        ("Envelops for|party members",   "党员信封|福利费用"), # 26B→25B,blk=28
        ("Propaganda",                   "宣传活动"),    # 10B→12B,blk=12
        ("Welfare",                      "福利"),        # 7B→6B,  blk=8
    ],
    "level23": [
        ("Industry",            "工业"),         # 8B→6B,  blk=8
        ("Agriculture",         "农业发展"),     # 11B→12B,blk=12
        ("Services",            "服务"),         # 8B→6B,  blk=8
        ("Army",                "军"),           # 4B→3B,  blk=4
        ("Agents",              "特工"),         # 6B→6B,  blk=8
        ("Sci points",          "科技点"),       # 10B→9B, blk=12
        ("Corruption",          "腐败程度"),     # 10B→12B,blk=12
        ("Party|Loyalty",       "政党|忠诚度"),  # 13B→16B,blk=16
        ("People's|Loyalty",    "人民|忠诚度"),  # 16B→16B,blk=16
        ("Our influence",       "我们的影响"),   # 13B→15B,blk=16
        ("Dipreputation",       "外交声誉值"),   # 13B→15B,blk=16
        ("Money",               "资金"),         # 5B→6B,  blk=8
    ],
    "level15": [
        ("Intervention|points", "干预行动点数"),  # 19B→18B,blk=20
    ],
    "level8": [
        ("Science points", "科学技术点"),  # 14B→15B,blk=16（DOCTRINES面板）
    ],
}

# 排除特定（文件, 英文字符串）对——避免命中场景层级名等非显示字符串
EXCLUDES: set[tuple[str, str]] = {
    ("level6", "Army"),   # 0xbd40：GameObject组件名，非UI显示标签
}

# 排除特定源文件偏移——面板路由键与显示标签同名但不可翻译
# C# 代码通过 Panel["Economy"]["Main"] 查找面板，路由键翻译后会导致面板无法打开
# 偏移为 1.8.5_Resources/Data/ 源文件中 4字节长度前缀的位置
OFFSET_EXCLUDES: dict[str, set] = {
    "level3":  {0x182d0, 0x18798},   # Economy+Main, Science+Main 路由键
    "level7":  {0x99f0,  0x8a38},    # Economy+Main, Science+Main 路由键
    "level9":  {0x1aa88},            # Science+Main 路由键
    "level15": {0x89d8,  0x91c0},    # Economy+Main, Science+Main 路由键
    "level23": {0x15808},            # Science+Main 路由键
}

# 处理的 level 文件列表
TARGET_LEVELS = ["level3", "level6", "level7", "level8", "level9", "level15", "level23"]


def build_patch_plan(level_name: str) -> list[tuple[str, str]]:
    """返回该 level 文件应执行的 (eng, zh) 列表，已去除 EXCLUDES。"""
    plan = list(GLOBAL_PATCHES)
    plan += FILE_PATCHES.get(level_name, [])
    return [(e, z) for e, z in plan
            if (level_name, e) not in EXCLUDES]


def process_level(level_name: str, dry_run: bool, verbose: bool) -> int:
    src_path = os.path.join(INPUT_DIR, level_name)
    dst_path = os.path.join(OUTPUT_DIR, level_name)

    if not os.path.exists(src_path):
        print(f"  ⚠ 未找到源文件: {src_path}")
        return 0

    with open(src_path, "rb") as f:
        data = bytearray(f.read())

    total_patched = 0
    plan = build_patch_plan(level_name)
    offset_excludes = OFFSET_EXCLUDES.get(level_name, set())

    for eng, zh in plan:
        offsets = find_and_patch(data, eng, zh, dry_run=dry_run,
                                 exclude_offsets=offset_excludes)
        if offsets:
            total_patched += len(offsets)
            if verbose or dry_run:
                for off in offsets:
                    action = "会替换" if dry_run else "已替换"
                    print(f"    {action} @{off:#010x}: {eng!r:35} → {zh!r}")
        # 没找到的字符串静默跳过（该 level 文件可能不含此字符串）

    if not dry_run:
        os.makedirs(OUTPUT_DIR, exist_ok=True)
        with open(dst_path, "wb") as f:
            f.write(data)

    return total_patched


def main():
    parser = argparse.ArgumentParser(description="Patch level 文件字符串为中文")
    parser.add_argument("--dry-run", action="store_true",
                        help="仅显示将替换的内容，不写文件")
    parser.add_argument("--deploy", action="store_true",
                        help="同时部署到游戏目录")
    parser.add_argument("--verbose", "-v", action="store_true",
                        help="显示所有替换详情（非 dry-run 模式下）")
    args = parser.parse_args()

    if args.dry_run:
        print("=== DRY RUN 模式（不写文件）===\n")

    grand_total = 0
    for lv in TARGET_LEVELS:
        n = process_level(lv, dry_run=args.dry_run, verbose=args.verbose)
        status = f"{n} 处替换"
        print(f"{'[dry]' if args.dry_run else '[done]'} {lv:<10} {status}")
        grand_total += n

    print(f"\n{'预计' if args.dry_run else '合计'} {grand_total} 处字符串替换")

    if args.deploy and not args.dry_run:
        if not os.path.isdir(DEPLOY_DIR):
            print(f"\n⚠ 游戏目录不存在: {DEPLOY_DIR}")
            return
        deployed = 0
        for lv in TARGET_LEVELS:
            src = os.path.join(OUTPUT_DIR, lv)
            dst = os.path.join(DEPLOY_DIR, lv)
            if os.path.exists(src):
                shutil.copy2(src, dst)
                deployed += 1
        print(f"✅ 已部署 {deployed} 个 level 文件到游戏目录")


if __name__ == "__main__":
    main()
