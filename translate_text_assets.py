#!/usr/bin/env python3
"""
translate_text_assets.py
批量翻译所有 *_en TextAsset 文件，输出 *_zh JSON。

翻译策略：
  - 人名/国家名：查表精准翻译
  - XML格式文件：保留标签结构，只翻译文本内容
  - 大文本文件：API批量翻译，保留HTML颜色标签
  - ;分隔符文件：按段翻译
  - 短标签文件：逐行翻译

用法：
    uv run python3 translate_text_assets.py
    uv run python3 translate_text_assets.py --file new_texts_en   # 只翻译指定文件
    uv run python3 translate_text_assets.py --resume               # 跳过已翻译的文件
"""

import json, os, re, time, argparse, sys
from pathlib import Path
from urllib.request import Request, urlopen
from urllib.error import URLError, HTTPError

IN_DIR  = Path("text_assets")
OUT_DIR = Path("text_assets")   # 输出 *_zh.json 到同一目录

API_URL  = "http://192.168.50.3:18000/v1/chat/completions"
API_KEY  = "sk-lexwdex"
MODEL    = "gpt-5.4-nano"


# ──────────────────────────────────────────────────────────────────────────────
# 人名查表
# ──────────────────────────────────────────────────────────────────────────────

# 中国政治人物姓名（姓 → 中文）
CN_NAMES = {
    "Jiang": "江", "Mao": "毛", "Hua": "华", "Wang": "王", "Zhang": "张",
    "Yao": "姚", "Li": "李", "Ye": "叶", "Ji": "纪", "Cheng": "陈",
    "Wu": "吴", "Huang": "黄", "Deng": "邓", "Zhao": "赵", "Hu": "胡",
    "Peng": "彭", "Xi": "习", "Wen": "温", "Zhu": "朱", "Liu": "刘",
    "Lin": "林", "Chen": "陈", "Zhou": "周", "Xu": "徐", "He": "贺",
    "Luo": "罗", "Song": "宋", "Xie": "谢", "Tan": "谭", "Bo": "薄",
    "Wan": "万", "Yang": "杨", "Qiao": "乔", "Tian": "田", "Wei": "魏",
    "Guo": "郭", "Wa": "瓦", "Sun": "孙", "Ma": "马", "Tang": "唐",
    "Feng": "冯", "Bao": "鲍", "Meng": "孟",
    "Wǎxīlǐ": "瓦西里", "Xuanning": "宣宁",
}
CN_SURNAMES = {
    "Qing": "青", "Zedong": "泽东", "Guofeng": "国锋", "Hongwen": "洪文",
    "Chunqiao": "春桥", "Wenyuan": "文元", "Dongxing": "东兴",
    "Xiannian": "先念", "Jianying": "剑英", "Dengkui": "登奎",
    "Xilian": "锡联", "De": "德", "Hua": "华", "Xiaoping": "小平",
    "Ziyang": "紫阳", "Yaobang": "耀邦", "Jintao": "锦涛",
    "Zemin": "泽民", "Jinping": "近平", "Jiabao": "家宝",
    "Rongji": "镕基", "Peng": "鹏", "Biao": "彪", "Shaoqi": "少奇",
    "Enlai": "恩来", "Zhongxun": "仲勋", "Dehuai": "德怀",
    "Zhen": "真", "Qinglin": "庆林", "Zhenhuan": "镇寰",
    "Ping": "平", "Yili": "一力", "Zhiqiang": "志强",
    "Xilai": "熙来", "Li": "里", "Shi": "石", "Jingqing": "景清",
    # 补充缺失的中文名字
    "Yun": "云", "Guanhua": "冠华", "Wey": "维", "Min": "敏",
    "Jing": "静", "Qiang": "强", "Lei": "蕾", "Jun": "军",
    "Yong": "永", "Yan": "燕", "Jie": "洁", "Juan": "娟",
    "Tao": "涛", "Chao": "超", "Xiulan": "秀兰", "Gang": "刚",
    "Guiying": "桂英", "Xiuying": "秀英", "Yang": "洋", "Feng": "凤",
    "Siliy": "西利", "Lu": "路", "Yuanxin": "远新", "Fangni": "芳妮",
    "Danzhi": "丹芝", "Danding": "丹定", "Qingshu": "庆树",
    "Kēsītèlièfū": "科斯特列夫", "Lifu": "立夫", "Ye": "业",
}

# 苏联人物全名映射
SOVIET_NAMES = {
    "Leonid Brezhnev": "列昂尼德·勃列日涅夫",
    "Vladimir Shcherbitsky": "弗拉基米尔·谢尔比茨基",
    "Konstantin Chernenko": "康斯坦丁·契尔年科",
    "Yuri Andropov": "尤里·安德罗波夫",
    "Grigory Romanov": "格里戈里·罗曼诺夫",
    "Viktor Grishin": "维克托·格里申",
    "Mikhail Gorbachev": "米哈伊尔·戈尔巴乔夫",
}

# 美国人物全名映射
US_NAMES = {
    "Jimmy Carter": "吉米·卡特",
    "Ronald Reagan": "罗纳德·里根",
    "G. Bush Sr.": "老布什",
    "Walter Mondale": "沃尔特·蒙代尔",
    "Bill Clinton": "比尔·克林顿",
    "George W. Bush": "乔治·W·布什",
    "Al Gore": "阿尔·戈尔",
    "John Kerry": "约翰·克里",
    "Barack Obama": "贝拉克·奥巴马",
    "John McCain": "约翰·麦凯恩",
    "Mitt Romney": "米特·罗姆尼",
    "Hillary Clinton": "希拉里·克林顿",
    "Donald Trump": "唐纳德·特朗普",
    "Joe Biden": "乔·拜登",
}

# 其他人物映射
OTHER_NAMES = {
    "Honecker": "昂纳克", "Mielke": "米尔克", "Krenz": "克伦茨", "Gysi": "居西",
    "Muammar Gaddafi": "穆阿迈尔·卡扎菲", "Gaddafi": "卡扎菲",
    "Margaret Thatcher": "玛格丽特·撒切尔", "Thatcher": "撒切尔",
    "Fidel Castro": "菲德尔·卡斯特罗", "Castro": "卡斯特罗",
    "Kim Il-sung": "金日成", "Kim Jong-il": "金正日",
    "Dalai Lama": "达赖喇嘛", "Panchen Lama": "班禅喇嘛",
    "Ho Chi Minh": "胡志明", "Pol Pot": "波尔布特",
}

# 国家名映射
COUNTRY_MAP = {
    "Luxemburg": "卢森堡", "China": "中国", "Poland": "波兰",
    "Czechoslovakia": "捷克斯洛伐克", "Hungary": "匈牙利", "Romania": "罗马尼亚",
    "Bulgaria": "保加利亚", "Soviet Union": "苏联", "Iran": "伊朗",
    "Mongolia": "蒙古", "North Korea": "朝鲜", "Vietnam": "越南",
    "Afghanistan": "阿富汗", "Libya": "利比亚", "Iraq": "伊拉克",
    "Yugoslavia": "南斯拉夫", "GDR": "东德", "FRG": "西德",
    "Western Sahara": "西撒哈拉", "India": "印度", "Cuba": "古巴",
    "France": "法国", "South Korea": "韩国", "Japan": "日本",
    "USA": "美国", "United Kingdom": "英国", "Portugal": "葡萄牙",
    "Spain": "西班牙", "Italy": "意大利", "Greece": "希腊",
    "Turkey": "土耳其", "Egypt": "埃及", "Israel": "以色列",
    "Saudi Arabia": "沙特阿拉伯", "Pakistan": "巴基斯坦",
    "Indonesia": "印度尼西亚", "Australia": "澳大利亚",
    "Canada": "加拿大", "Mexico": "墨西哥", "Brazil": "巴西",
    "Argentina": "阿根廷", "Chile": "智利", "Venezuela": "委内瑞拉",
    "Colombia": "哥伦比亚", "Peru": "秘鲁", "Nigeria": "尼日利亚",
    "South Africa": "南非", "Kenya": "肯尼亚", "Ethiopia": "埃塞俄比亚",
    "Tanzania": "坦桑尼亚", "Angola": "安哥拉", "Mozambique": "莫桑比克",
    "Congo": "刚果", "Zaire": "扎伊尔", "Syria": "叙利亚",
    "Jordan": "约旦", "Lebanon": "黎巴嫩", "Kuwait": "科威特",
    "Yemen": "也门", "Oman": "阿曼", "UAE": "阿联酋",
    "Bangladesh": "孟加拉国", "Myanmar": "缅甸", "Thailand": "泰国",
    "Malaysia": "马来西亚", "Singapore": "新加坡", "Philippines": "菲律宾",
    "Taiwan": "台湾", "Hong Kong": "香港", "Macau": "澳门",
    "Tibet": "西藏", "Xinjiang": "新疆",
    "Cambodia": "柬埔寨", "Laos": "老挝", "Nepal": "尼泊尔",
    "Sri Lanka": "斯里兰卡", "New Zealand": "新西兰",
    "Netherlands": "荷兰", "Belgium": "比利时", "Switzerland": "瑞士",
    "Austria": "奥地利", "Sweden": "瑞典", "Norway": "挪威",
    "Denmark": "丹麦", "Finland": "芬兰", "Ireland": "爱尔兰",
    "Iceland": "冰岛",
    "Czech Republic": "捷克共和国", "Slovakia": "斯洛伐克",
    "Slovenia": "斯洛文尼亚", "Croatia": "克罗地亚",
    "Bosnia": "波斯尼亚", "Serbia": "塞尔维亚",
    "North Macedonia": "北马其顿", "Albania": "阿尔巴尼亚",
    "Lithuania": "立陶宛", "Latvia": "拉脱维亚", "Estonia": "爱沙尼亚",
    "Ukraine": "乌克兰", "Belarus": "白俄罗斯", "Georgia": "格鲁吉亚",
    "Armenia": "亚美尼亚", "Azerbaijan": "阿塞拜疆",
    "Kazakhstan": "哈萨克斯坦", "Uzbekistan": "乌兹别克斯坦",
    "Turkmenistan": "土库曼斯坦", "Tajikistan": "塔吉克斯坦",
    "Kyrgyzstan": "吉尔吉斯斯坦", "Moldova": "摩尔多瓦",
    "Russia": "俄罗斯", "Russian Federation": "俄罗斯联邦",
    "Unified Germany": "统一的德国",
    "DPRK": "朝鲜", "RK": "韩国", "PRC": "中华人民共和国",
    "USSR": "苏联",
    # 补充未覆盖的国家名
    "Kampuchea": "柬埔寨", "South Yemen": "南也门", "North Yemen": "北也门",
    "Burma": "缅甸", "Burma ": "缅甸",
    "Algeria": "阿尔及利亚", "Somalia": "索马里",
    "Grenada": "格林纳达", "Sudan": "苏丹", "Morocco": "摩洛哥",
    "Tunisia": "突尼斯", "Niger": "尼日尔", "Chad": "乍得",
    "Mali": "马里", "Mauritania": "毛里塔尼亚",
    "Upper Volta": "上沃尔特", "Benin": "贝宁", "Ghana": "加纳",
    "Côte d'Ivoire": "科特迪瓦", "CAR": "中非共和国",
    "Cameroon": "喀麦隆", "Liberia": "利比里亚", "Guinea": "几内亚",
    "Uyghuristan": "东突厥斯坦",
    "Bolivia": "玻利维亚", "Ecuador": "厄瓜多尔",
    "Guyana": "圭亚那", "Guiana": "法属圭亚那",
    "Paraguay": "巴拉圭", "Suriname": "苏里南", "Uruguay": "乌拉圭",
    "Holland": "荷兰", "Great Britain": "英国",
    "Divided Cyprus": "塞浦路斯（分裂）", "Kurdistan": "库尔德斯坦",
    "Bhutan": "不丹", "Eritrea": "厄立特里亚", "Eritrea ": "厄立特里亚",
    "Tigray": "提格雷",
    "Qatar": "卡塔尔", "Jordania": "约旦",
    "Djibouti": "吉布提", "Sierra Leone": "塞拉利昂",
    "Togo": "多哥", "Basque Country": "巴斯克地区",
    "Catalonia": "加泰罗尼亚", "Ainu Utari": "阿伊努族",
}

ALL_NAMES = {**SOVIET_NAMES, **US_NAMES, **OTHER_NAMES}


def translate_name_in_color_tag(text: str) -> str:
    """翻译 <color=xxx>PersonName</color> 格式的行。"""
    def repl(m):
        tag_open = m.group(1)
        name = m.group(2)
        tag_close = m.group(3)
        zh_name = ALL_NAMES.get(name, None)
        if zh_name is None:
            # 尝试部分匹配
            for en, zh in ALL_NAMES.items():
                if en in name:
                    zh_name = name.replace(en, zh)
                    break
        if zh_name is None:
            zh_name = name  # 保留原文
        return f"{tag_open}{zh_name}{tag_close}"

    return re.sub(r"(<color=[^>]+>)(.*?)(</color>)", repl, text)


# ──────────────────────────────────────────────────────────────────────────────
# API 翻译
# ──────────────────────────────────────────────────────────────────────────────

def call_api(prompt: str, system_msg: str = "", max_retries: int = 3) -> str:
    """调用翻译 API。"""
    messages = []
    if system_msg:
        messages.append({"role": "system", "content": system_msg})
    messages.append({"role": "user", "content": prompt})

    payload = json.dumps({
        "model": MODEL,
        "messages": messages,
        "temperature": 0.1,
        "max_completion_tokens": 16384,
    }).encode("utf-8")

    for attempt in range(max_retries):
        try:
            req = Request(API_URL, data=payload, method="POST")
            req.add_header("Content-Type", "application/json")
            req.add_header("Authorization", f"Bearer {API_KEY}")
            with urlopen(req, timeout=120) as resp:
                result = json.loads(resp.read())
                return result["choices"][0]["message"]["content"]
        except (URLError, HTTPError, KeyError, json.JSONDecodeError) as e:
            print(f"    API 错误 (尝试 {attempt+1}/{max_retries}): {e}", file=sys.stderr)
            if attempt < max_retries - 1:
                time.sleep(2 ** attempt)
    raise RuntimeError("API 调用失败，已达最大重试次数")


SYSTEM_PROMPT_GAME = """你是一名专业的游戏汉化翻译。你正在翻译一个冷战时期策略游戏《毛的遗产》（Mao's Legacy）。

翻译规则：
1. 保留所有 HTML 标签（<color=xxx>, </color>, <b>, </b> 等），不翻译标签属性
2. 保留所有格式符号：| 表示换行，; 表示分隔符，{0} {1} 等占位符
3. 人名必须使用历史上准确的中文译名（如 Deng Xiaoping = 邓小平，Mao Zedong = 毛泽东）
4. 国家名使用标准中文名（如 Soviet Union = 苏联，GDR = 东德）
5. 政治/经济专业术语准确翻译
6. "none" 不翻译（游戏引擎关键字）
7. 数字和数学符号保留原样
8. 翻译要简洁，适合游戏 UI 显示
9. 一行英文对应一行中文，行数必须完全相同"""

SYSTEM_PROMPT_XML = """你是一名专业的游戏汉化翻译。你正在翻译一个冷战时期策略游戏《毛的遗产》的事件/焦点定义文件。

翻译规则：
1. XML 标签（<new event>, <name>, <title>, <desc>, <icon>, <option>, <result>, <locked>, <titleresult>, <endevent> 以及 <new way>, <endway> 等）绝对不能修改，包括尾部空格
2. 只翻译标签之间的文本内容
3. "none" 在 <icon> 块下不翻译（游戏引擎关键字）
4. \\r\\n 换行符必须保留
5. 人名使用历史上准确的中文译名
6. 一行英文对应一行中文，行数必须完全相同"""


def batch_translate(lines: list[str], system_prompt: str,
                    batch_size: int = 50, file_name: str = "",
                    progress_path: str = "") -> list[str]:
    """分批翻译文本行，支持断点续翻。
    
    如果 progress_path 非空，每批次完成后保存进度到该文件。
    启动时如果进度文件存在，自动加载已翻译的部分。
    """
    total = len(lines)
    
    # 加载已有进度
    start_idx = 0
    result = []
    if progress_path and os.path.exists(progress_path):
        try:
            with open(progress_path, "r", encoding="utf-8") as f:
                progress = json.load(f)
            result = progress.get("translated", [])
            start_idx = len(result)
            if start_idx > 0:
                print(f"  [{file_name}] 恢复进度: 已翻译 {start_idx}/{total} 行")
        except (json.JSONDecodeError, KeyError):
            pass
    
    if start_idx >= total:
        return result[:total]

    for i in range(start_idx, total, batch_size):
        batch = lines[i:i + batch_size]
        batch_num = i // batch_size + 1
        total_batches = (total + batch_size - 1) // batch_size
        print(f"  [{file_name}] 批次 {batch_num}/{total_batches} ({len(batch)}行)")

        # 空行和纯格式行不需要翻译
        needs_translation = any(
            l.strip() and not re.match(r'^[\s|;{}\d<>/=\-+.,#]*$', l.strip())
            for l in batch
        )

        if not needs_translation:
            result.extend(batch)
        else:
            numbered = "\n".join(f"[{i+j}] {line}" for j, line in enumerate(batch))
            prompt = f"翻译以下游戏文本为中文。每行前面的 [N] 是行号，请保留行号格式。行数必须与输入完全一致。\n\n{numbered}"

            response = call_api(prompt, system_prompt)

            # 解析响应
            translated = parse_numbered_response(response, len(batch), i)
            if len(translated) != len(batch):
                print(f"    ⚠ 行数不匹配: 期望{len(batch)}，得到{len(translated)}，使用原文补齐")
                while len(translated) < len(batch):
                    translated.append(batch[len(translated)])
                translated = translated[:len(batch)]

            result.extend(translated)
        
        # 保存进度
        if progress_path:
            with open(progress_path, "w", encoding="utf-8") as f:
                json.dump({"translated": result, "total": total}, f, ensure_ascii=False)
        
        time.sleep(0.3)  # 避免 rate limit

    return result


def parse_numbered_response(response: str, expected: int, offset: int) -> list[str]:
    """解析 [N] 格式的翻译响应。"""
    lines = response.strip().split("\n")
    result = {}

    for line in lines:
        m = re.match(r'\[(\d+)\]\s*(.*)', line)
        if m:
            idx = int(m.group(1))
            text = m.group(2)
            result[idx] = text

    # 按序号排列
    output = []
    for i in range(offset, offset + expected):
        output.append(result.get(i, ""))

    return output


# ──────────────────────────────────────────────────────────────────────────────
# 文件翻译策略
# ──────────────────────────────────────────────────────────────────────────────

def translate_country(lines: list[str]) -> list[str]:
    """国家名：查表翻译。"""
    return [COUNTRY_MAP.get(l.strip(), l) for l in lines]


def translate_polit_names(lines: list[str], name_map: dict) -> list[str]:
    """人物姓/名：查表翻译。"""
    return [name_map.get(l.strip(), l) for l in lines]


def translate_semicolon_file(lines: list[str], file_name: str) -> list[str]:
    """分号分隔的单行文件：整体送API翻译。
    
    这些文件含政党名、意识形态名、政治人物描述等，
    查表覆盖率不足，直接送API翻译更准确。
    """
    # 将;替换为换行，方便API逐段翻译
    all_parts = []
    for line in lines:
        parts = line.split(";")
        all_parts.extend(parts)
    
    # 构建编号格式送API
    numbered = "\n".join(f"[{i}] {p}" for i, p in enumerate(all_parts))
    prompt = f"""翻译以下游戏文本为中文。这是一个冷战策略游戏《毛的遗产》中的政治术语和人物描述。
每行前面的 [N] 是行号，请保留行号格式。行数必须与输入完全一致。
| 表示游戏内换行符，保留不变。
纯数字行保持不变。

{numbered}"""
    
    response = call_api(prompt, SYSTEM_PROMPT_GAME)
    translated_parts = parse_numbered_response(response, len(all_parts), 0)
    
    # 重新拼回;分隔格式
    result = []
    idx = 0
    for line in lines:
        parts = line.split(";")
        translated_line_parts = []
        for _ in parts:
            if idx < len(translated_parts):
                translated_line_parts.append(translated_parts[idx])
            idx += 1
        result.append(";".join(translated_line_parts))
    
    return result


def translate_new_texts(lines: list[str]) -> list[str]:
    """new_texts_en：先处理颜色标签中的人名，再API翻译。"""
    preprocessed = []
    for line in lines:
        if "<color=" in line:
            line = translate_name_in_color_tag(line)
        preprocessed.append(line)

    return batch_translate(preprocessed, SYSTEM_PROMPT_GAME,
                           batch_size=40, file_name="new_texts_en",
                           progress_path="text_assets/.progress_new_texts_en.json")


def translate_events_text(lines: list[str]) -> list[str]:
    """Events_text_en：长段叙事文本，直接API翻译。"""
    return batch_translate(lines, SYSTEM_PROMPT_GAME,
                           batch_size=30, file_name="Events_text_en",
                           progress_path="text_assets/.progress_Events_text_en.json")


def translate_other_text(lines: list[str]) -> list[str]:
    """other_text_en：UI标签和分类名。"""
    return batch_translate(lines, SYSTEM_PROMPT_GAME,
                           batch_size=60, file_name="other_text_en",
                           progress_path="text_assets/.progress_other_text_en.json")


def translate_xml_file(lines: list[str], file_name: str) -> list[str]:
    """XML格式文件（事件/焦点定义）。"""
    return batch_translate(lines, SYSTEM_PROMPT_XML,
                           batch_size=40, file_name=file_name)


def translate_modifier_text(lines: list[str], file_name: str) -> list[str]:
    """修改器名称/描述。"""
    return batch_translate(lines, SYSTEM_PROMPT_GAME,
                           batch_size=60, file_name=file_name)


def translate_traits(lines: list[str], file_name: str) -> list[str]:
    """性格特征。"""
    return batch_translate(lines, SYSTEM_PROMPT_GAME,
                           batch_size=60, file_name=file_name)


# ──────────────────────────────────────────────────────────────────────────────
# 主流程
# ──────────────────────────────────────────────────────────────────────────────

# 每个 *_en 文件对应的翻译函数
TRANSLATE_DISPATCH = {
    "Country_en": lambda lines: translate_country(lines),
    "polit_names1_en": lambda lines: translate_polit_names(lines, CN_NAMES),
    "polit_surnames1_en": lambda lines: translate_polit_names(lines, CN_SURNAMES),
    "polit_names7_en": lambda lines: translate_modifier_text(lines, "polit_names7_en"),     # 苏联姓→API
    "polit_surnames7_en": lambda lines: translate_modifier_text(lines, "polit_surnames7_en"),
    "polit_names21_en": lambda lines: translate_modifier_text(lines, "polit_names21_en"),    # 法国姓→API
    "polit_surnames21_en": lambda lines: translate_modifier_text(lines, "polit_surnames21_en"),
    "new_texts_en": translate_new_texts,
    "Events_text_en": translate_events_text,
    "other_text_en": translate_other_text,
    "new_event_text_en": lambda lines: translate_xml_file(lines, "new_event_text_en"),
    "new_focuses_texts_en": lambda lines: translate_xml_file(lines, "new_focuses_texts_en"),
    "new_modify_texts_en": lambda lines: translate_modifier_text(lines, "new_modify_texts_en"),
    "new_modify_opis_en": lambda lines: translate_modifier_text(lines, "new_modify_opis_en"),
    "old_modify_text_en": lambda lines: translate_modifier_text(lines, "old_modify_text_en"),
    "old_modify_opis_en": lambda lines: translate_modifier_text(lines, "old_modify_opis_en"),
    "Traits1_en": lambda lines: translate_traits(lines, "Traits1_en"),
    "Traits21_en": lambda lines: translate_traits(lines, "Traits21_en"),
    "Traits7_en": lambda lines: translate_traits(lines, "Traits7_en"),
}

# ;分隔符文件列表
SEMICOLON_FILES = ["Doctr_en", "Opis_en", "Part1_en", "Part7_en"]


def translate_file(name: str, lines: list[str]) -> list[str]:
    """翻译单个文件。"""
    if name in TRANSLATE_DISPATCH:
        return TRANSLATE_DISPATCH[name](lines)
    elif name in SEMICOLON_FILES:
        return translate_semicolon_file(lines, name)
    else:
        # 兜底：API翻译
        return batch_translate(lines, SYSTEM_PROMPT_GAME, batch_size=60, file_name=name)


def main():
    parser = argparse.ArgumentParser(description="翻译所有 *_en TextAsset")
    parser.add_argument("--file", help="只翻译指定文件（如 new_texts_en）")
    parser.add_argument("--resume", action="store_true", help="跳过已翻译的文件")
    args = parser.parse_args()

    manifest = json.load(open(IN_DIR / "MANIFEST.json"))
    en_assets = [a for a in manifest["assets"]
                 if a["asset_name"].endswith("_en") or a.get("translatable")]

    if args.file:
        en_assets = [a for a in en_assets if a["asset_name"] == args.file]
        if not en_assets:
            print(f"未找到文件: {args.file}")
            return

    print(f"待翻译文件: {len(en_assets)} 个")
    print()

    for asset in en_assets:
        name = asset["asset_name"]
        zh_name = name.replace("_en", "_zh")
        out_path = OUT_DIR / f"{zh_name}.json"

        if args.resume and out_path.exists():
            print(f"[skip] {name} (已存在)")
            continue

        in_path = IN_DIR / f"{name}.json"
        data = json.load(open(in_path, encoding="utf-8"))
        lines = data["lines"]

        print(f"[翻译] {name} ({len(lines)} 行)")

        try:
            translated = translate_file(name, lines)

            # 验证行数一致
            if len(translated) != len(lines):
                print(f"  ⚠ 行数不匹配: 原文{len(lines)}行 vs 译文{len(translated)}行")
                # 补齐或截断
                while len(translated) < len(lines):
                    translated.append(lines[len(translated)])
                translated = translated[:len(lines)]

            out_data = {
                "asset_name": zh_name,
                "source": name,
                "path_id": data["path_id"],
                "total_lines": len(translated),
                "line_ending": data.get("line_ending", repr("\n")),
                "lines": translated,
            }
            with open(out_path, "w", encoding="utf-8") as f:
                json.dump(out_data, f, ensure_ascii=False, indent=2)
            print(f"  ✓ {zh_name}.json ({len(translated)} 行)")

        except Exception as e:
            print(f"  ✗ 错误: {e}")
            import traceback
            traceback.print_exc()

    print("\n翻译完成。")


if __name__ == "__main__":
    main()
