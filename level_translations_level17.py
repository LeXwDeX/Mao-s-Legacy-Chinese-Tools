"""
level_translations_level17.py — Level17 教程翻译 (31 段长文本)。

**硬约束**: padded_block(zh_utf8_bytes) == padded_block(eng_utf8_bytes)
即中文 UTF-8 字节数对齐到4字节后，必须与英文原文完全一致。

策略: 中文翻译较短 (zh_utf8 < blk) 时用 ASCII 空格填充到精确 blk 大小。
"""

import math


def _pb(n_bytes: int) -> int:
    """Unity 字符串内容区对齐到4字节后的大小（不含4字节长度前缀）。"""
    return math.ceil(n_bytes / 4) * 4


def _pad(zh: str, target_blk: int) -> str:
    """将中文翻译用 ASCII 空格填充到指定 blk 大小。"""
    zh_bytes = zh.encode("utf-8")
    padding = target_blk - len(zh_bytes)
    if padding < 0:
        raise ValueError(f"zh '{zh}' ({len(zh_bytes)}B) exceeds blk={target_blk}")
    return zh + (" " * padding)


# ──────────────────────────────────────────────────────────────────────────────
# level17: 游戏教程 (Tutorial)
# 31 段英文教程文本，按 level17 文件内出现顺序排列
# ──────────────────────────────────────────────────────────────────────────────
LEVEL17_PATCHES: list[tuple[str, str]] = [

    # @0x0050f0 blk=132 (129B EN → 102B ZH → blk=132)
    (
        "Greetings, casual wanderer! Welcome to \u201cMao\u2019s Legacy\u201d!"
        " In this tutorial we will explain all the main mechanics of the game.",

        _pad("各位旅人好！欢迎来到《毛泽东的遗产》！本教程将讲解游戏所有主要机制。", 132),
    ),

    # @0x005178 blk=368 (368B EN → 217B ZH → blk=368)
    (
        "In the upper left corner, you can see the date and the speed counters"
        " (for how fast you want the game to be), Mao\u2019s Legacy is a Real-Time"
        " game, therefore, you have to click one of the counters under the date to"
        " set the speed of the game. Pressing the pause button, you can stop the"
        " game in any moment of time. You can also use the \u201cSpace\u201d key"
        " to pause the game. ",

        _pad("左上角可以看到日期和游戏速度控制。《毛泽东的遗产》是即时制游戏，"
             "点击日期下方的速度按钮可调节游戏速度。按暂停键可随时暂停游戏，"
             "也可按空格键暂停。 ", 368),
    ),

    # @0x0052ec blk=196 (194B EN → 151B ZH → blk=196)
    (
        "This is the diplomacy screen, which opens if you click most countries,"
        " with it you can see what diplomatic actions are available for each"
        " country, and what is necessary for the action to occur. ",

        _pad("这是外交界面，点击大多数国家即可打开。在此可以查看每个国家可用的"
             "外交行动，以及触发该行动所需的条件。 ", 196),
    ),

    # @0x0053b4 blk=220 (218B EN → 179B ZH → blk=220)
    (
        "It is also important to mention that not all countries in the game are"
        " shown on the map, 4 countries \u2013 Indonesia, Malaysia, Rhodesia"
        " and the United States of America can be found if you press the arrow"
        " on the right. ",

        _pad("需要注意的是，并非所有国家都显示在主地图上。印度尼西亚、马来西亚、"
             "罗得西亚和美利坚合众国这4个国家，需点击右侧箭头查看。 ", 220),
    ),

    # @0x005494 blk=264 (262B EN → 217B ZH → blk=264)
    (
        "There are multiple modes of the world\u2019s map, the first one being"
        " the Regime mode; it shows all the different government systems of the"
        " countries. There are four different regimes \u2013 Socialist (Red),"
        " Reformist (Green), Liberal (Blue) and Authoritarian (Gray). ",

        _pad("世界地图有多种显示模式。首先是政体模式，展示各国不同的政治制度。"
             "共有四种政体：社会主义（红色）、改革派（绿色）、自由派（蓝色）"
             "和威权制（灰色）。 ", 264),
    ),

    # @0x0055a0 blk=256 (253B EN → 193B ZH → blk=256)
    (
        "The next mode is Influence, which shows allegiance to certain forces"
        " of the Cold War and can be of four types \u2013 pro-Soviet,"
        " pro-Chinese, pro-American and Neutral. Because of influence, you can"
        " have different relations and interactions with countries. ",

        _pad("其次是影响力模式，展示各国在冷战中的阵营归属，分为亲苏、亲华、"
             "亲美和中立四类。基于影响力差异，你与各国的关系和互动也会有所不同。 ", 256),
    ),

    # @0x0056a4 blk=108 (105B EN → 76B ZH → blk=108)
    (
        "After that comes the military map, which shows membership in"
        " different military alliances or neutrality. ",

        _pad("接着是军事地图，显示各国加入的军事同盟或中立状态。 ", 108),
    ),

    # @0x005714 blk=224 (222B EN → 182B ZH → blk=224)
    (
        "And finally the Trade map, which demonstrates the economic ties with"
        " other countries (in green \u2013 close trade, in red \u2013 member"
        " of CMEA, in blue \u2013 allies of the USA, purple/light blue"
        " \u2013 close non \u2013 block trading). ",

        _pad("最后是贸易地图，展示与其他国家的经济联系：绿色为密切贸易，"
             "红色为经互会成员，蓝色为美国盟友，紫色/浅蓝色为非集团密切贸易。 ", 224),
    ),

    # @0x0057f8 blk=208 (207B EN → 147B ZH → blk=208)
    (
        "From time to time, events will appear which will show up at the top"
        " in the form of a flickering envelope. When you click it, you will"
        " go to the event and will be in power to choose from any option"
        " available.",

        _pad("游戏中会不时出现事件，以闪烁信封的图标显示在顶部。点击后进入"
             "事件界面，你可以从可用选项中做出选择。", 208),
    ),

    # @0x0058cc blk=160 (158B EN → 106B ZH → blk=160)
    (
        "We took care of you in advance, so after an event has been activated"
        " the game automatically pauses and will stay like that until you turn"
        " the speed on again. ",

        _pad("为了方便玩家，事件触发后游戏会自动暂停，直到你重新调整速度后"
             "才会继续。 ", 160),
    ),

    # @0x005970 blk=292 (290B EN → 174B ZH → blk=292)
    (
        "Please direct your attention to the top half of the diplomacy window;"
        " here you can see the indicators of the situation in the country,"
        " and which change once every two weeks. When placing your cursor on"
        " them, you can find out what they mean and how have they changed"
        " during the last 14 day. ",

        _pad("请注意外交界面上半部分，这里显示国家各项指标，每两周更新一次。"
             "将鼠标悬停在指标上，可查看其含义及过去14天的变化情况。 ", 292),
    ),

    # @0x005a98 blk=100 (100B EN → 81B ZH → blk=100)
    (
        "Below the indicators, we have the tabs for going to other screens."
        " Let\u2019s start from the doctrines.",

        _pad("指标下方是切换到其他界面的标签。我们先从意识形态开始。", 100),
    ),

    # @0x005b00 blk=240 (240B EN → 150B ZH → blk=240)
    (
        "Here you can see the current type of government of the country and"
        " the policy of the ruling party. When you look at the left side of"
        " the window, you can see and change the different doctrines of the"
        " country, depending on the current policy.",

        _pad("这里显示当前国家的政体类型和执政党政策。窗口左侧可查看和更改"
             "国家的各项意识形态，具体取决于当前政策。", 240),
    ),

    # @0x005bf4 blk=148 (148B EN → 117B ZH → blk=148)
    (
        "In the middle of the screen are the different fractions, which can be"
        " banned or supported, and from them depends which doctrines can be"
        " implemented.",

        _pad("屏幕中间是不同的派系，可以禁止或支持它们，而可实施的意识形态"
             "取决于派系的动向。", 148),
    ),

    # @0x005c8c blk=108 (105B EN → 88B ZH → blk=108)
    (
        "We also have the efficiency of army indicator, and if you place your"
        " mouse on it you can see its growth. ",

        _pad("此处还有军队战斗力指标，将鼠标悬停其上可查看详细增长数据。 ", 108),
    ),

    # @0x005cfc blk=28 (28B EN → 24B ZH → blk=28)
    (
        "Let\u2019s look at the economy.",

        _pad("接下来看看经济。", 28),
    ),

    # @0x005d1c blk=568 (568B EN → 304B ZH → blk=568)
    (
        "Here you can see the division of the budget of your country and if"
        " needed, change it according to your needs. Each of the subdivisions"
        " has influence on different in-game indicators, for example,"
        " investment in the MGB \u2013 increases the growth of the intelligence"
        " services, and investments into International Aid, increases the power"
        " of revolutionaries in third-world countries. But don\u2019t overdo it"
        " and be careful \u2013 wrong investment into different areas can lead"
        " to the growth of corruption, the indicator of which you can see in"
        " the top right corner of the screen. ",

        _pad("这里可以查看和调整国家预算分配。每个子项都影响不同的游戏指标，"
             "例如投资国家安全部可提升情报机构效率，投资国际援助可增强第三世界"
             "国家革命力量。但要谨慎——不当投资会导致腐败增长，"
             "腐败指标显示在屏幕右上角。 ", 568),
    ),

    # @0x005f58 blk=376 (373B EN → 198B ZH → blk=376)
    (
        "Also, on the top are the indicators of the three main branches of the"
        " economy \u2013 production, Agriculture and the services sector. When"
        " you place your cursor there, you can see the growth of the branches"
        " during the past 14 days. It is important to mention here that the"
        " development of these branches is influenced by investments, doctrines"
        " and the technologies researched. ",

        _pad("顶部还有三大经济部门指标：工业、农业和服务业。将鼠标悬停可查看"
             "过去14天的增长情况。这些部门的发展受投资、意识形态和已研究科技"
             "的影响。 ", 376),
    ),

    # @0x0060d4 blk=604 (604B EN → 340B ZH → blk=604)
    (
        "On the right side of the window, you can see your government debt"
        " \u2013 you can pay it or take loan more money using the keys next to"
        " the indicator. Below the indicator of government debt there is"
        " information about potential investments, losses from corruption and"
        " other facts. Please direct your attention to the little pig at the"
        " bottom \u2013 this is the Gold reserve of the country, where you can"
        " place money, and it will be extracted from there if there is a"
        " deficit. We suggest investing extra money there, because when the"
        " budget is large, its growth deteriorates and you will lose part of"
        " your money. ",

        _pad("窗口右侧显示国债信息，可通过旁边的按钮偿还或借贷。国债指标下方有"
             "潜在投资、腐败损失等信息。注意底部的小猪存钱罐——这是国家黄金储备，"
             "可存入资金，赤字时会自动提取。建议将多余资金投入储备，因为预算过多时"
             "增速会下降并造成资金损失。 ", 604),
    ),

    # @0x006334 blk=32 (32B EN → 27B ZH → blk=32)
    (
        "It\u2019s time for the Science tab.",

        _pad("接下来是科技标签。", 32),
    ),

    # @0x006358 blk=556 (555B EN → 337B ZH → blk=556)
    (
        "Science is divided into three branches \u2013 agriculture, production"
        " and military research. You can only study one scientific research at"
        " a time. When the third technology in a branch is studied, a choice"
        " lies ahead of you. It depends from you what route you will take, for"
        " agriculture \u2013 this is the development of extensive or intensive"
        " technologies, for production it is automatisation or machinery"
        " update, military technology \u2013 army or intelligence services."
        " Also, no one is limiting you, so you can study both branches of"
        " research at the same time. ",

        _pad("科技分为三个方向：农业、工业和军事研究。同一时间只能研究一项科技。"
             "当某个方向研究到第三项科技时，将面临路线选择。农业可选粗放型或"
             "集约型技术，工业可选自动化或设备更新，军事可选陆军或情报机构。"
             "当然也可以同时研究不同方向的科技。 ", 556),
    ),

    # @0x006588 blk=28 (25B EN → 24B ZH → blk=28)
    (
        "Now for the overview tab.",

        _pad("现在看总览标签。", 28),
    ),

    # @0x0065a8 blk=296 (296B EN → 178B ZH → blk=296)
    (
        "Here you can see information about economic growth, situations in the"
        " world and the domestic indicators of countries. On the right side"
        " there is a table of Game modifiers, which activate and deactivate"
        " depending on the policies and doctrines of the country, and from the"
        " technologies researched. ",

        _pad("这里展示经济增长、世界局势和各国国内指标信息。右侧是游戏修正表，"
             "根据国家政策和意识形态以及已研究的科技自动启用或停用。 ", 296),
    ),

    # @0x0066d4 blk=68 (68B EN → 57B ZH → blk=68)
    (
        "Let\u2019s continue and go to the most interesting tab"
        " \u2013 Politicians.",

        _pad("接下来进入最有趣的部分——政治家标签。", 68),
    ),

    # @0x00671c blk=380 (380B EN → 253B ZH → blk=380)
    (
        "In front of you is the top government hierarchy of the PRC, on the"
        " top of which is the character of the player. When placing your"
        " cursor on any of the politicians, on the indicator bar next to his"
        " portrait you will see his relations with other politicians and with"
        " you. It is also important to note that each politician has his own"
        " traits and affiliation with a certain fraction. ",

        _pad("这里展示中华人民共和国的最高政府层级，玩家角色位于最顶端。"
             "将鼠标悬停在政治家上，其肖像旁的指标条会显示他与其他政治家"
             "及你的关系。每位政治家都有自己的性格特质和派系归属。 ", 380),
    ),

    # @0x00689c blk=500 (498B EN → 298B ZH → blk=500)
    (
        "On the left side of the portrait of the character you are playing as,"
        " you will see the positions in the government \u2013 Government,"
        " Military Council, and the Ministry of Foreign Affairs. Below that"
        " are the heads of regions, which the player can appoint depending on"
        " his preferences. Politicians can influence the indicators of the"
        " country, for example the ones with the trait \u201cChina Expert\u201d"
        " increases the unity of China, and a politician with the trait"
        " \u201cEconomical\u201d adds money to the budget.",

        _pad("玩家角色肖像左侧是政府职位：政府、军事委员会和外交部。下方是各地区"
             "负责人，玩家可按偏好任命。政治家会影响国家指标，例如具有"
             "\u201c中国通\u201d特质的政治家可提升国家统一度，具有\u201c节俭\u201d"
             "特质的政治家可为预算增加资金。", 500),
    ),

    # @0x006a94 blk=312 (311B EN → 166B ZH → blk=312)
    (
        "When you click on any politician, a window with information about him"
        " appears \u2013 his position in the government, his age and his"
        " influence. You can also place him on any position in the government"
        " which follows the hierarchy, support him, begin pressuring him, or"
        " even do an assassination attempt on his life. ",

        _pad("点击政治家会弹出信息窗口，显示其政府职位、年龄和影响力。"
             "你可以按层级任命政府职位、支持他、施压，甚至进行暗杀。 ", 312),
    ),

    # @0x006bd0 blk=32 (30B EN → 24B ZH → blk=32)
    (
        "Now for the last tab \u2013 Wars.",

        _pad("最后是战争标签。", 32),
    ),

    # @0x006bf4 blk=680 (680B EN → 449B ZH → blk=680)
    (
        "From time to time, you will get events about the start of different"
        " military conflicts, in which you can support one of the two sides,"
        " for example by sending humanitarian aid, military aid or"
        " Intelligence services aid and by diplomatic support. Each of the"
        " options requires spending \u2013 of money, army power or of the"
        " Intelligence services power. But your actions are limited by the"
        " \u201cPoints of Influence\u201d, the growth of which depends on the"
        " influence of the PRC and the investments into International aid. 1"
        " point of influence equals 1 click on any type of support, except"
        " for diplomatic support, which is available to be used only once and"
        " it doesn\u2019t require any spending. ",

        _pad("游戏中会不时出现军事冲突事件，你可以支持冲突中的一方，例如提供"
             "人道主义援助、军事援助、情报支援或外交支持。每种选项都需要消耗资金、"
             "军力或情报力量。但你的行动受\u201c干预点数\u201d限制，其增长取决于"
             "中华人民共和国的影响力和国际援助投资。1点干预点数等于1次支援行动，"
             "外交支持除外——它只能使用一次且不消耗任何资源。 ", 680),
    ),

    # @0x006ea0 blk=152 (149B EN → 102B ZH → blk=152)
    (
        "On this the tutorial is concluded. Comrade, I hope that you can bring"
        " China into a bright and prosperous future! Best of luck to you"
        " during gameplay!",

        _pad("教程到此结束。同志，希望你能带领中国走向光明繁荣的未来！"
             "祝游戏愉快！", 152),
    ),

    # @0x006f3c blk=132 (132B EN → 112B ZH → blk=132)
    (
        "Are you here again, casual wanderer? Welcome to \u201cMao\u2019s"
        " Legacy\u201d! Sure, I can explain all the main mechanics of the game"
        " again. ",

        _pad("旅人又回来了？欢迎来到《毛泽东的遗产》！我来再为你讲解一遍"
             "游戏的主要机制。 ", 132),
    ),
]
