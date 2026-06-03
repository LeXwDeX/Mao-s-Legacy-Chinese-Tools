"""
level_translations.py — Level 文件翻译字典，按 level 组织。

翻译来源: translations_dict.json (集中字典，确保翻译一致性)

**硬约束**: padded_block(zh_utf8_bytes) == padded_block(eng_utf8_bytes)
即中文 UTF-8 字节数对齐到4字节后，必须与英文原文完全一致。

实现策略:
- 字典翻译能正好填满 blk: 直接使用
- 字典翻译较短 (zh_utf8 < blk): 用 ASCII 空格填充到精确 blk 大小
- blk=4 (仅 3B 内容空间): 使用单字缩写
- 组合标签超长 (zh > blk): 跳过该条目
"""

import math


def padded_block(n_bytes: int) -> int:
    """Unity 字符串内容区对齐到4字节后的大小（不含4字节长度前缀）。"""
    return math.ceil(n_bytes / 4) * 4


def _pad_zh(zh: str, target_blk: int) -> str:
    """将中文翻译填充到指定 blk 大小，不足部分用 ASCII 空格补齐。"""
    zh_bytes = zh.encode("utf-8")
    padding = target_blk - len(zh_bytes)
    if padding < 0:
        raise ValueError(f"zh '{zh}' ({len(zh_bytes)}B) exceeds blk={target_blk}")
    return zh + (" " * padding)


# ──────────────────────────────────────────────────────────────────────────────
# level2: 主菜单
# ──────────────────────────────────────────────────────────────────────────────
LEVEL2_PATCHES: list[tuple[str, str]] = [
    ("Settings",     "设置"),                                   # 8B→6B+2spc,  blk=8
    ("Load",         "载"),                                     # 4B→3B,       blk=4 (单字)
    ("Exit",         "退"),                                     # 4B→3B,       blk=4
    ("Authors",      "作者"),                                   # 7B→6B+2spc,   blk=8
    ("New Game",     "新游"),                                   # 8B→6B+2spc,   blk=8
    ("Tutorial",     "教程"),                                   # 8B→6B+2spc,   blk=8
    ("Game Rules",   "游戏规则"),                                # 10B→12B,       blk=12
    ("Chosen country", _pad_zh("所选国家", 16)),                 # 14B→12B+4spc,  blk=16
]

# ──────────────────────────────────────────────────────────────────────────────
# level5: 音乐机 (Music Jukebox)
# ──────────────────────────────────────────────────────────────────────────────
LEVEL5_PATCHES: list[tuple[str, str]] = [
    # UI 控件
    ("Difficulty",   _pad_zh("难度", 12)),                       # 10B→6B+6spc,   blk=12
    ("Autosave",     "自存"),                                    # 8B→6B+2spc,    blk=8
    ("Slot for autosaves", _pad_zh("自动存档槽|1", 20)),          # 18B→18B+2spc,  blk=20
    ("Randomize",    _pad_zh("随机", 12)),                       # 9B→6B+6spc,    blk=12
    ("New music",    "新音乐"),                                  # 9B→9B+3spc,    blk=12
    ("Autoplay of the same track", _pad_zh("重放同一曲目", 28)),   # 26B→18B+10spc, blk=28
    ("Traditional music",  _pad_zh("传统音乐", 20)),              # 17B→12B+8spc,  blk=20
    ("Latin American communist music", _pad_zh("拉美共产主义音乐", 32)),  # 30B→24B+8spc, blk=32
    ("Automation",   "自动化"),                                  # 10B→9B+3spc,   blk=12
    # 歌曲 (按 level 文件中出现顺序)
    ("Songs of Hua Guofeng times",  _pad_zh("华国锋时代之歌曲", 28)),              # 26B→21B+7spc,  blk=28
    ("Death of the Helmsman",       "舵手逝世之歌曲"),              # 21B→21B+3spc,  blk=24
    ("Liberalization",              _pad_zh("自由化", 16)),         # 14B→9B+7spc,   blk=16
    ("Changes",                     _pad_zh("变", 8)),                         # 7B→3B+5spc,    blk=8  (单字)
    ("Modernization",               _pad_zh("现代化", 16)),         # 13B→9B+7spc,   blk=16
    ("Daily routine",               _pad_zh("日常生活", 16)),                    # 13B→12B+4spc,  blk=16
    ("Tiananmen",                   "天安门"),                      # 9B→9B+3spc,    blk=12
    ("Ceremony",                    "典礼"),                       # 8B→6B+2spc,    blk=8
    ("Movement",                    "运动"),                       # 8B→6B+2spc,    blk=8
    ("Raid evening",                _pad_zh("夜袭", 12)),           # 12B→6B+6spc,   blk=12
    # SKIP: "Anthem of PRC" (13B,blk=16) — zh "中华人民共和国国歌" 27B 超出
    # SKIP: "Anthem of CPC" (13B,blk=16) — zh "中国共产党党歌" 21B 超出
    ("Cantata about Stalin",        "斯大林大合唱"),                   # 20B→18B+2spc, blk=20
    # SKIP: "March of PLA" (12B,blk=12) — zh "解放军进行曲" 18B 超出
    ("We are strong workers",       "我们是坚强工人"),                 # 21B→21B+3spc, blk=24
    ("About Long March ",           _pad_zh("关于长征", 20)),                     # 17B→12B+8spc, blk=20
    ("About Mao Zedong ",           _pad_zh("关于毛泽东", 20)),                    # 17B→12B+8spc, blk=20
    ("Twinkle",                     _pad_zh("闪", 8)),                          # 7B→3B+5spc,   blk=8  (单字)
    ("Nightingales",                _pad_zh("夜莺", 12)),            # 12B→6B+6spc,  blk=12
    # SKIP: "no China without CPC" (20B,blk=20) — zh exceeds block (30B)
    ("Dedicated to Chairman|Mao Zedong",  _pad_zh("献给|毛主席", 32)),            # 32B→15B+17spc, blk=32 (|保留)
    ("Sailing the sea|depends on the helmsman",
     _pad_zh("大海航行|靠舵手", 40)),                                             # 39B→21B+19spc, blk=40 (|保留)
    ("To love Chairman Mao",        _pad_zh("热爱毛主席", 20)),      # 20B→12B+8spc,  blk=20
    ("People around the world|love Chairman Mao",
     _pad_zh("全世界人民|热爱毛主席", 44)),                                         # 41B→30B+14spc, blk=44
    ("March of the|Red Army Women", _pad_zh("红色娘子军进行曲", 28)),               # 27B→24B+4spc,  blk=28
    ("We are the heirs|of communism", _pad_zh("我们是共产主义接班人", 32)),               # 29B→21B+11spc, blk=32
    ("The East Is Red",             _pad_zh("东方红", 16)),           # 15B→9B+7spc,   blk=16
    ("Always sing about|Chairman Mao", _pad_zh("永远歌唱毛主席", 32)),             # 30B→24B+8spc,  blk=32
    ("Mao's thought|shines forever", "毛主席思想|永放光芒"),           # 28B→27B+1spc,  blk=28
    ("Partisans song",              _pad_zh("游击队之歌", 16)),       # 14B→15B+1spc,  blk=16
    # SKIP: "Son of CYLK" (11B,blk=12) — zh exceeds block (15B)
    ("Oil industry song",           _pad_zh("石油之歌", 20)),          # 17B→12B+8spc,  blk=20
    ("Approach of war",             _pad_zh("战争临近", 16)),                      # 15B→12B+4spc,  blk=16
    ("Shooting the landowner",      _pad_zh("枪毙地主", 24)),          # 22B→12B+12spc, blk=24
    ("Revolutionaries|are always young", _pad_zh("革命者永远年轻", 32)),           # 32B→27B+5spc,  blk=32
    ("Liuyang River",               _pad_zh("浏阳河", 16)),           # 13B→9B+7spc,   blk=16
    ("Follow Chairman|Mao",         _pad_zh("跟着|毛主席", 20)),       # 19B→18B+2spc,  blk=20
    ("I'm a soldier",               _pad_zh("我是一个兵", 16)),        # 13B→15B+1spc,  blk=16
    ("THE GREAT HELMSMan",          _pad_zh("伟大的舵手", 20)),        # 18B→15B+5spc,  blk=20
]

# ──────────────────────────────────────────────────────────────────────────────
# level11: 统计/外交面板 (indicators 子集)
# ──────────────────────────────────────────────────────────────────────────────
LEVEL11_PATCHES: list[tuple[str, str]] = [
    ("Budget",                  "预算"),                                  # 6B→6B+2spc,  blk=8
    ("Relations with the USA",  _pad_zh("对美关系", 24)),                   # 22B→12B+12spc, blk=24
    ("Relations with the USSR", _pad_zh("对苏关系", 24)),                   # 23B→12B+12spc, blk=24
    ("Support of the party",    _pad_zh("党内支持", 20)),                   # 20B→12B+8spc,  blk=20
    ("Support of the people",   _pad_zh("人民支持", 24)),                   # 21B→12B+12spc, blk=24
    ("Liberalisation of minds", _pad_zh("思想解放", 24)),                   # 23B→12B+12spc, blk=24
    ("Standart of living",      _pad_zh("生活水平", 20)),                   # 18B→12B+8spc,  blk=20
    ("Global influence",        _pad_zh("全球影响力", 16)),                                 # 16B→12B+4spc,  blk=16
    ("International reputation", _pad_zh("国际声望", 24)),                  # 24B→12B+12spc, blk=24
    ("Agent networks",          _pad_zh("情报网", 16)),                     # 14B→9B+7spc,   blk=16
    ("Stamps",                  "邮票"),                                   # 6B→6B+2spc,  blk=8
]

# ──────────────────────────────────────────────────────────────────────────────
# level12: 存档槽 (Save Slots)
# ──────────────────────────────────────────────────────────────────────────────
LEVEL12_PATCHES: list[tuple[str, str]] = [
    ("Without achievements|Slot #1", _pad_zh("无成就|存档槽 1", 28)),       # 28B→21B+7spc, blk=28
    ("Without achievements|Slot #2", _pad_zh("无成就|存档槽 2", 28)),       # 28B→21B+7spc, blk=28
    ("Without achievements|Slot #3", _pad_zh("无成就|存档槽 3", 28)),       # 28B→21B+7spc, blk=28
    ("Without achievements|Slot #4", _pad_zh("无成就|存档槽 4", 28)),       # 28B→21B+7spc, blk=28
    ("Slot|with achievements",       _pad_zh("存档|含成就", 24)),            # 22B→19B+5spc, blk=24
]

# ──────────────────────────────────────────────────────────────────────────────
# level13: 读档槽 (Load Slots) — 与 level12 相同
# ──────────────────────────────────────────────────────────────────────────────
LEVEL13_PATCHES: list[tuple[str, str]] = [
    ("Without achievements|Slot #1", _pad_zh("无成就|存档槽 1", 28)),       # 同上
    ("Without achievements|Slot #2", _pad_zh("无成就|存档槽 2", 28)),
    ("Without achievements|Slot #3", _pad_zh("无成就|存档槽 3", 28)),
    ("Without achievements|Slot #4", _pad_zh("无成就|存档槽 4", 28)),
    ("Slot|with achievements",       _pad_zh("存档|含成就", 24)),
]

# ──────────────────────────────────────────────────────────────────────────────
# level14: 政治派系 (Political Factions, ~34 entries)
# ──────────────────────────────────────────────────────────────────────────────
LEVEL14_PATCHES: list[tuple[str, str]] = [
    # 操作按钮 (| 分隔符保留)
    ("Assign as the|faction leader", _pad_zh("任命为|派系领袖", 28)),       # 28B→24B+4spc, blk=28
    ("Assign to|the CMC",           _pad_zh("任命|中央军", 20)),            # 17B→15B+5spc, blk=20
    ("Assign to|the Capital",       _pad_zh("任命至|首都", 24)),             # 21B→15B+9spc, blk=24
    ("Assign to|the North",         _pad_zh("任命|北方", 20)),              # 19B→12B+8spc, blk=20
    ("Assign to|the South",         _pad_zh("任命|南方", 20)),              # 19B→12B+8spc, blk=20
    ("Assign to|the East",          _pad_zh("任命|东方", 20)),              # 18B→12B+8spc, blk=20
    ("Assign to|the West",          _pad_zh("任命|西方", 20)),              # 18B→12B+8spc, blk=20
    ("Assign to|the MFA",           _pad_zh("任命|外交部", 20)),             # 17B→15B+5spc, blk=20
    ("Assign to|the Premier",       _pad_zh("任命|总理", 24)),              # 21B→12B+12spc, blk=24
    ("Open the|investigation",      _pad_zh("展开|调查行动", 24)),           # 22B→21B+3spc, blk=24
    ("Send for|reeducation",        _pad_zh("送去|再教育", 20)),             # 20B→15B+5spc, blk=20
    # 属性标签
    ("Loyality to us or|to other politicians",
     _pad_zh("忠于我们|还是其他政客", 40)),                                   # 38B→33B+7spc, blk=40
    ("Capital",       "首都"),                                                 # 7B→6B+2spc,   blk=8
    ("North",         "北方"),                                                 # 5B→6B+2spc,   blk=8
    ("West",          "西"),                                                   # 4B→3B,        blk=4 (单字)
    ("South",         "南方"),                                                 # 5B→6B+2spc,   blk=8
    ("East",          "东"),                                                   # 4B→3B,        blk=4
    ("Premier",       "总理"),                                                 # 7B→6B+2spc,   blk=8
    ("CMC",           "党"),                                                   # 3B→3B,        blk=4 (单字缩写)
    ("MFA",           "外"),                                                   # 3B→3B,        blk=4
    # 性格特质 (blk=8: 2字+2spc, blk=12: ≤4字+pad)
    ("Arrogant",      "傲慢"),                                                 # 8B→6B+2spc,  blk=8
    ("Peaceful",      "和平"),                                                 # 8B→6B+2spc,  blk=8
    ("Pragmatist",    _pad_zh("务实", 12)),                                    # 10B→6B+6spc, blk=12
    ("Reformist",     "改革派"),                                               # 9B→9B+3spc,  blk=12
    ("Scientist",     "科学家"),                                               # 9B→9B+3spc,  blk=12
    ("Moderate",      "温和"),                                                 # 8B→6B+2spc,  blk=8
    ("Peculator",     _pad_zh("贪腐", 12)),                                    # 9B→6B+6spc,  blk=12
    ("Petty tyrant",  "小暴君"),                                               # 12B→9B+3spc, blk=12
    ("Leftradical",   "左倾激进"),                                             # 11B→12B,     blk=12
    ("Chinophilic",   _pad_zh("亲华", 12)),                                    # 11B→6B+6spc, blk=12
    ("Westophilic",   _pad_zh("亲西", 12)),                                    # 11B→6B+6spc, blk=12
    ("Autosupport",   _pad_zh("亲信", 12)),                                    # 11B→6B+6spc, blk=12
    ("Autohound",     _pad_zh("猎犬", 12)),                                    # 9B→6B+6spc,  blk=12
    # 行动按钮
    ("Support",       "支持"),                                                 # 7B→6B+2spc,  blk=8
    ("Bribe",         "贿赂"),                                                 # 5B→6B+2spc,  blk=8
    ("Hound",         "追踪"),                                                 # 5B→6B+2spc,  blk=8
    # 注: "Capital|North|West|South|East" (29B→blk=32) 字典值超长, 跳过
    # 注: "Premier|CMC|MFA" (15B→blk=16) 字典值超长, 跳过
]

# ──────────────────────────────────────────────────────────────────────────────
# level16: 经济面板
# ──────────────────────────────────────────────────────────────────────────────
LEVEL16_PATCHES: list[tuple[str, str]] = [
    ("Budget",                  "预算"),                                      # 6B→6B+2spc,  blk=8
    ("Back",                    "返"),                                        # 4B→3B,       blk=4
    ("Relations with the USA",  _pad_zh("对美关系", 24)),                       # 22B→12B+12spc, blk=24
    ("Relations with the USSR", _pad_zh("对苏关系", 24)),                       # 23B→12B+12spc, blk=24
    ("Support of the party",    _pad_zh("党内支持", 20)),                       # 20B→12B+8spc,  blk=20
    ("Support of the people",   _pad_zh("人民支持", 24)),                       # 21B→12B+12spc, blk=24
    ("Liberalisation of minds", _pad_zh("思想解放", 24)),                       # 23B→12B+12spc, blk=24
    ("Standart of living",      _pad_zh("生活水平", 20)),                       # 18B→12B+8spc,  blk=20
    ("Global influence",        _pad_zh("全球影响力", 16)),                                     # 16B→12B+4spc,  blk=16
    ("International reputation", _pad_zh("国际声望", 24)),                      # 24B→12B+12spc, blk=24
    ("Agent networks",          _pad_zh("情报网", 16)),                         # 14B→9B+7spc,   blk=16
]

# ──────────────────────────────────────────────────────────────────────────────
# level20: 系统设置窗口 (仅 1 条)
# ──────────────────────────────────────────────────────────────────────────────
LEVEL20_PATCHES: list[tuple[str, str]] = [
    ("System", "系统"),                                                        # 6B→6B+2spc,  blk=8
]

# ──────────────────────────────────────────────────────────────────────────────
# level21: 南美地图
# 注: 导航标签 (World Map/Economy/.../View) 由 patch_levels.py 的 GLOBAL_PATCHES 提供，
#     此处仅补充 level-specific 标签。共 17 条。
# ──────────────────────────────────────────────────────────────────────────────
LEVEL21_PATCHES: list[tuple[str, str]] = [
    ("Settings",     "设置"),                                                   # 8B→6B+2spc,  blk=8
    ("Budget",       "预算"),                                                   # 6B→6B+2spc,  blk=8
    ("Government",   _pad_zh("政府", 12)),                                      # 10B→6B+2spc, blk=8
    ("Influence",    "影响力"),                                                 # 9B→9B+3spc,  blk=12
    ("Military",     "军事"),                                                   # 8B→6B+2spc,  blk=8
    ("Decisions",    _pad_zh("决议", 12)),                                      # 9B→6B+6spc,  blk=12
    ("Save",         "存"),                                                     # 4B→3B,       blk=4
    ("Eurasian Map", "欧亚地图"),                                               # 12B→12B,     blk=12
    ("Relations with the USA",   _pad_zh("对美关系", 24)),                       # 22B→12B+12spc, blk=24
    ("Relations with the USSR",  _pad_zh("对苏关系", 24)),                       # 23B→12B+12spc, blk=24
    ("Support of the party",     _pad_zh("党内支持", 20)),                       # 20B→12B+8spc,  blk=20
    ("Support of the people",    _pad_zh("人民支持", 24)),                       # 21B→12B+12spc, blk=24
    ("Liberalisation of minds",  _pad_zh("思想解放", 24)),                       # 23B→12B+12spc, blk=24
    ("Standart of living",       _pad_zh("生活水平", 20)),                       # 18B→12B+8spc,  blk=20
    ("Global influence",         _pad_zh("全球影响力", 16)),                                     # 16B→12B+4spc,  blk=16
    ("International reputation", _pad_zh("国际声望", 24)),                       # 24B→12B+12spc, blk=24
    ("Agent networks",           _pad_zh("情报网", 16)),                         # 14B→9B+7spc,   blk=16
]

# ──────────────────────────────────────────────────────────────────────────────
# level24: 多人大厅
# ──────────────────────────────────────────────────────────────────────────────
LEVEL24_PATCHES: list[tuple[str, str]] = [
    ("Player #1",                _pad_zh("玩家 1", 12)),                       # 9B→7B+5spc,    blk=12
    ("Support of the party",     _pad_zh("党内支持", 20)),                       # 20B→12B+8spc,  blk=20
    ("Support of the people",    _pad_zh("人民支持", 24)),                       # 21B→12B+12spc, blk=24
    ("Standart of living",       _pad_zh("生活水平", 20)),                       # 18B→12B+8spc,  blk=20
    ("Diplomacy",                _pad_zh("外交", 12)),                          # 9B→6B+6spc,    blk=12
    ("International reputation", _pad_zh("国际声望", 24)),                       # 24B→12B+12spc, blk=24
    ("Relations with the USSR",  _pad_zh("对苏关系", 24)),                       # 23B→12B+12spc, blk=24
    ("Relations with the USA",   _pad_zh("对美关系", 24)),                       # 22B→12B+12spc, blk=24
    ("Liberalisation of minds",  _pad_zh("思想解放", 24)),                       # 23B→12B+12spc, blk=24
    ("Global influence",         _pad_zh("全球影响力", 16)),                                     # 16B→12B+4spc,  blk=16
    ("Budget",                   "预算"),                                       # 6B→6B+2spc,    blk=8
    ("Agent networks",           _pad_zh("情报网", 16)),                         # 14B→9B+7spc,   blk=16
    ("Choose your factions!",    _pad_zh("选择你的派系", 24)),                    # 21B→18B+6spc,  blk=24
    ("Each player should have at least 1 faction.|"
     "Players can't have the same faction at the asme time.",
     _pad_zh("每位玩家至少拥有1个派系。|"
             "玩家不能同时拥有相同的派系。", 100)),                               # 97B→79B+21spc, blk=100
]

# ──────────────────────────────────────────────────────────────────────────────
# 按 level 名索引的映射表
# ──────────────────────────────────────────────────────────────────────────────
ALL_LEVEL_PATCHES: dict[str, list[tuple[str, str]]] = {
    "level2":  LEVEL2_PATCHES,
    "level5":  LEVEL5_PATCHES,
    "level11": LEVEL11_PATCHES,
    "level12": LEVEL12_PATCHES,
    "level13": LEVEL13_PATCHES,
    "level14": LEVEL14_PATCHES,
    "level16": LEVEL16_PATCHES,
    "level20": LEVEL20_PATCHES,
    "level21": LEVEL21_PATCHES,
    "level24": LEVEL24_PATCHES,
}

# ──────────────────────────────────────────────────────────────────────────────
# 新增 OFFSET_EXCLUDES (路由键偏移 — 不可翻译)
# ──────────────────────────────────────────────────────────────────────────────
NEW_OFFSET_EXCLUDES: dict[str, set[int]] = {
    "level2": {
        0x4470,   # Settings + Main 路由键
        0x4678,   # GameRules (no space) + Main 路由键
        0x46e8,   # Tutorial + Main
        0x4750,   # Load + Main
        0x47b8,   # Authors + Main
        0x4820,   # Diplomacy + Main
    },
    "level12": {
        0x2a90,   # Diplomacy + Main
    },
    "level13": {
        0x2a78,   # Load + Main
    },
    "level14": {
        0x4b0a8,  # Diplomacy + Main
    },
    "level21": {
        0x13cc0,  # Economy + Main (Economy 在其他位置为 nav tab)
    },
}
