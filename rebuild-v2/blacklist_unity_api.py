#!/usr/bin/env python3
"""
Unity API 参数黑名单
这些字符串不应该被翻译，它们是 Unity 引擎的查找键/参数名。
"""

# GameObject.Find / transform.Find 参数
FIND_PARAMETERS = {
    "Main Camera", "EventSystem", "Canvas", "UI Root",
    "Button", "Text", "Image", "Panel",
    # 从 decompiled/ 中提取的所有 .Find() 调用参数
    "Znach", "Znakc",  # 游戏内部组件名
    "TextIf", "Button",  # UI 组件模板
}

# Input 系统参数
INPUT_PARAMETERS = {
    "Mouse X", "Mouse Y", "Mouse ScrollWheel",
    "Horizontal", "Vertical", "Submit", "Cancel",
    "Fire1", "Fire2", "Fire3", "Jump",
}

# PlayerPrefs 键名
PLAYERPREFS_KEYS = {
    "language", "voice_china", "our_diff_in",
    "SavePosition", "SavePlaceNum",
}

# 事件 ID 和标识符
EVENT_IDENTIFIERS = {
    "Main", "Diplomacy", "Economy", "Event", "Science",
}

# 合并为完整黑名单
BLACKLIST = (
    FIND_PARAMETERS |
    INPUT_PARAMETERS |
    PLAYERPREFS_KEYS |
    EVENT_IDENTIFIERS
)

print(f"黑名单大小: {len(BLACKLIST)} 个字符串")
for item in sorted(BLACKLIST)[:10]:
    print(f"  - {item}")
print("  ...")
