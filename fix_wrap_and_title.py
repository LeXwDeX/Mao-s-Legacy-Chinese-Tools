#!/usr/bin/env python3
"""
fix_wrap_and_title.py
1. 为所有已翻译长字符串（avail>=100）添加智能中文换行
2. 手动添加 "Five "no"" 展示标题翻译（offset=0x1F877B，avail=9）
3. 对底部左侧玩家行动组件的末段文本，使用更紧凑的换行（BOTTOM_BREAK=11）

换行策略（针对 Unity TextMesh 只能在空格处断行的限制）：
  - 句末标点（。！？…）之后：若当前行 >= 10 字符，立即换行
  - 句内标点（，、；：）之后：若当前行 >= CLAUSE_THRESH 字符时换行
  - 硬截断：当前行 >= HARD_BREAK 字符时强制换行（无论标点）
  - 已含 \\n 的字符串：保留现有换行，只补充太长的段落
  - 标签感知：绝不在 <...> 标签内部插入换行（修复 <c\\nolor= 等裸露 bug）
  - 行首禁则：行首禁止出现句末/句内标点（修复 P2 孤立句号行首问题）
  - 底部末段：事件底部左侧组件宽度约11字/行，对已知 offset 单独收紧换行
"""

import json

SENTENCE_END  = set('。！？…')   # 句末，始终断行
CLAUSE_PAUSE  = set('，、；：）"')  # 句内，行长 >= CLAUSE_THRESH 时断行
CLAUSE_THRESH = 18
HARD_BREAK    = 30               # 保底强制断行（中文字符≈英文2倍宽，游戏文本区约70英文字宽）

# 底部左侧玩家行动组件：中心 x≈174，面板左边框 x≈75，有效半宽≈99px≈5.5字→总宽≈11字/行
BOTTOM_BREAK = 11

# 行首禁则字符（不得出现在行首的标点）
NO_LINE_START = set('。！？…，、；：）」』')

# 展示标题白名单：offset → 正确的中文译文
TITLE_OVERRIDES = {
    0x1F877B: '五个\u201c不\u201d',   # Five "no" → 五个"不"（avail=9）
}

# 底部左侧组件末行直接替换：将过长的玩家行动句替换为 ≤BOTTOM_BREAK 字的简化版本。
# 游戏以最后一个 \n 分割，末段路由到底部左侧组件（宽约11字/行）。
# 替换整句而非拆分，可确保主体文本以句号结尾，底部组件显示完整句子。
BOTTOM_LINE_OVERRIDES: dict[int, str] = {
    # 五个"不"事件（avail=1054）：
    # 原句"而你作为新任总理，可以影响这一举措的执行。"（21字）超出组件宽度，
    # 替换为简化版（11字，包含句号，恰好贴合组件宽度）。
    # 原文：As the new Prime Minister, you can influence the execution of this move.
    0x2f4b09: '你可影响此举措的执行。',  # 11字（含句号），适配11字/行的底部组件
}


def _fix_line_start_punct(lines: list) -> list:
    """
    行首禁则修复：将每行行首连续的禁止字符全部移到上一行末尾。
    例："xxxx，\n）。yyyy" → "xxxx，）。\nyyyy"
    注意：每次只检查 i > 0 的行（第一行由调用方通过全局调用保证不越界）。
    """
    result = []
    for i, line in enumerate(lines):
        if i > 0 and line and line[0] in NO_LINE_START:
            # 把行首所有连续禁则字符挂到上一行末
            j = 0
            while j < len(line) and line[j] in NO_LINE_START:
                j += 1
            result[-1] = result[-1] + line[:j]
            rest = line[j:]
            result.append(rest)
        else:
            result.append(line)
    # 过滤因移动产生的空行
    return [l for l in result if l]


def wrap_bottom_segment(seg: str) -> str:
    """
    为底部左侧玩家行动组件显示的末段文本添加紧凑换行。
    使用 BOTTOM_BREAK=11（≈组件宽度）代替普通的 HARD_BREAK=30。
    标签感知、行首禁则逻辑与 wrap_segment 一致。
    """
    if len(seg) <= BOTTOM_BREAK:
        return seg

    lines   = []
    cur     = []
    cur_len = 0
    in_tag  = False

    for ch in seg:
        cur.append(ch)

        if ch == '<':
            in_tag = True
            continue
        if ch == '>' and in_tag:
            in_tag = False
            continue
        if in_tag:
            continue

        cur_len += 1

        break_now = False
        if ch in SENTENCE_END and cur_len >= 6:
            break_now = True
        elif ch in CLAUSE_PAUSE and cur_len >= BOTTOM_BREAK - 2:
            break_now = True
        elif cur_len >= BOTTOM_BREAK:
            break_now = True

        if break_now:
            lines.append(''.join(cur))
            cur     = []
            cur_len = 0

    if cur:
        lines.append(''.join(cur))

    lines = _fix_line_start_punct(lines)
    return '\n'.join(lines)


def wrap_segment(seg: str) -> str:
    """对一个不含 \\n 的中文段落添加换行符（感知 <tag> 边界，不在标签内断行）。"""
    if len(seg) <= CLAUSE_THRESH:
        return seg  # 够短，不需要换行

    lines   = []
    cur     = []
    cur_len = 0        # 仅计可见字符（标签字符不计入行宽）
    in_tag  = False    # 当前是否在 <...> 标签内部

    for ch in seg:
        cur.append(ch)

        # ── 标签边界检测 ──────────────────────────────────────────
        if ch == '<':
            in_tag = True
            continue   # 进入标签，不计长度，不断行
        if ch == '>' and in_tag:
            in_tag = False
            continue   # 闭合 >，不计长度，不断行
        if in_tag:
            continue   # 标签内部字符：不计，不断行

        # ── 可见字符：计长度 + 判断是否断行 ─────────────────────────
        cur_len += 1

        break_now = False
        if ch in SENTENCE_END and cur_len >= 10:
            break_now = True
        elif ch in CLAUSE_PAUSE and cur_len >= CLAUSE_THRESH:
            break_now = True
        elif cur_len >= HARD_BREAK:
            break_now = True

        if break_now:
            lines.append(''.join(cur))
            cur     = []
            cur_len = 0

    if cur:
        lines.append(''.join(cur))

    lines = _fix_line_start_punct(lines)
    return '\n'.join(lines)


def smart_wrap(text: str, avail: int) -> str:
    """对整段中文文本（可能已含部分 \\n）添加智能换行。"""
    # 按已有 \\n 拆段，各段独立处理
    segments = text.split('\n')
    wrapped_segs = [wrap_segment(s) for s in segments]
    result = '\n'.join(wrapped_segs)

    # 全局行首禁则修复（跨原有 \n 分段边界）
    # wrap_segment 内部只修本段，段首（i=0）不处理；这里统一再跑一次
    all_lines = result.split('\n')
    all_lines = _fix_line_start_punct(all_lines)
    result = '\n'.join(all_lines)

    # 安全检查：换行后不能超出可用空间
    if len(result) > avail:
        return text  # 回退，保持原样

    return result


def main():
    with open('dll_strings/translated.json', encoding='utf-8') as f:
        data = json.load(f)

    fixed_wrap   = 0
    fixed_title  = 0
    fixed_bottom = 0

    for k, v in data.items():
        orig  = v.get('text', '')
        zh    = v.get('translated', '')
        avail = v['available_chars']
        off   = v['offset']

        # ── 1. 展示标题白名单 ─────────────────────────────────────
        if off in TITLE_OVERRIDES and orig == TITLE_OVERRIDES[off].replace(
                '\u201c不\u201d', '\u201cno\u201d'):
            v['translated'] = TITLE_OVERRIDES[off]
            fixed_title += 1
            continue

        # 特殊处理：用 "Five "no"" 做键来查找
        if off in TITLE_OVERRIDES:
            v['translated'] = TITLE_OVERRIDES[off]
            fixed_title += 1
            continue

        # ── 2. 换行修复（仅处理已翻译的长字符串）────────────────────
        if not zh or zh == orig:
            continue
        if avail < 100:
            continue

        # 先清除上一轮脚本插入的换行（回到纯译文），再重新断行
        # 保留原文中已有的 \n（对比原文检测）
        if '\n' not in orig:
            zh_clean = zh.replace('\n', '')
        else:
            zh_clean = zh  # 原文本身含 \n，保留

        wrapped = smart_wrap(zh_clean, avail)

        # ── 3. 底部左侧组件末段替换 ──────────────────────────────────────
        # 游戏以最后一个 \n 分割事件文本，将末段路由到底部左侧玩家行动组件。
        # 对于已知超宽末句，直接替换为预定义的简化短句（≤BOTTOM_BREAK字），
        # 确保主体文本以句号结尾，底部组件显示完整句子。
        if off in BOTTOM_LINE_OVERRIDES:
            result_lines = wrapped.split('\n')
            if result_lines:
                new_last = BOTTOM_LINE_OVERRIDES[off]
                candidate = '\n'.join(result_lines[:-1] + [new_last])
                if len(candidate) <= avail:
                    if candidate != wrapped:
                        wrapped = candidate
                        fixed_bottom += 1

        if wrapped != zh:
            v['translated'] = wrapped
            fixed_wrap += 1

    with open('dll_strings/translated.json', 'w', encoding='utf-8') as f:
        json.dump(data, f, ensure_ascii=False, indent=2)

    print(f'✅ 换行修复: {fixed_wrap} 条')
    print(f'✅ 标题翻译: {fixed_title} 条')
    print(f'✅ 底部末段替换: {fixed_bottom} 条')


if __name__ == '__main__':
    main()
