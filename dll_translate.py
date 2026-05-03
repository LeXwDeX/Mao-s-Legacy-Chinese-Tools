#!/usr/bin/env python3
"""
dll_translate.py
读取 dll_strings/original.json，批量调用 LLM 翻译，
输出 dll_strings/translated.json

格式：
  { "0x1F877B": { ...original fields..., "translated": "五个\"不\"" }, ... }

支持断点续跑：已翻译条目直接跳过。

用法：
  uv run python3 dll_translate.py
  uv run python3 dll_translate.py --resume   # 跳过已翻译条目
"""
import json, os, sys, time, re, argparse
from openai import OpenAI

API_URL  = "http://192.168.50.3:18000"
API_KEY  = "sk-lexwdex"
MODEL    = "gpt-5.4-nano"

IN_FILE  = "dll_strings/original.json"
OUT_FILE = "dll_strings/translated.json"

BATCH_SIZE = 40          # 每批条目数
MAX_RETRIES = 3
RETRY_DELAY = 3.0        # 秒

SYSTEM_PROMPT = """你是《毛泽东的遗产》（Mao's Legacy）历史策略游戏的专业翻译。
游戏背景：1976—1986年中国，玩家扮演中共领导人处理内政外交。

翻译规则：
1. 将英文译为简体中文，语言风格贴合中国政治/历史语境
2. 保留 {0}、{1}、{2} 等格式占位符，位置与原文对应
3. 保留 <color=red>、</color>、<b>、</b> 等 Unity 富文本标签
4. 人名使用权威中文译名：
   - Mao Zedong→毛泽东, Deng Xiaoping→邓小平, Zhou Enlai→周恩来
   - Hua Guofeng→华国锋, Jiang Qing→江青, Lin Biao→林彪
   - Zhang Chunqiao→张春桥, Wang Hongwen→王洪文, Yao Wenyuan→姚文元
   - Ye Jianying→叶剑英, Chen Yun→陈云, Li Xiannian→李先念
   - Wang Dongxing→汪东兴, Wu De→吴德, Zhao Ziyang→赵紫阳
   - Hu Yaobang→胡耀邦, Xi Zhongxun→习仲勋
5. 机构名称：CCP→中共, NPC→全国人大, Politburo→政治局
   Gang of Four→四人帮, Cultural Revolution→文化大革命
   Great Leap→大跃进, PRC→中华人民共和国
6. 译文紧凑，避免冗余，保持原文语气（正式/讽刺/紧张均原样体现）
7. 如果字符串看起来像调试输出（含 === / : / 错误信息），直接返回原文

请以 JSON 对象返回，键为原英文（完整原样），值为中文译文。
严格只输出 JSON，不加任何前缀或解释。"""


def build_user_prompt(batch: list[str]) -> str:
    items = json.dumps(batch, ensure_ascii=False, indent=2)
    return f"请翻译以下 {len(batch)} 条英文字符串：\n{items}"


def translate_batch(client: OpenAI, batch: list[str]) -> dict[str, str]:
    for attempt in range(MAX_RETRIES):
        try:
            resp = client.chat.completions.create(
                model=MODEL,
                messages=[
                    {"role": "system", "content": SYSTEM_PROMPT},
                    {"role": "user",   "content": build_user_prompt(batch)},
                ],
                temperature=0.1,
                timeout=120,
            )
            raw = resp.choices[0].message.content.strip()
            # 提取 JSON（防止 LLM 在外面加 markdown 代码块）
            m = re.search(r'\{.*\}', raw, re.DOTALL)
            if not m:
                raise ValueError(f"未找到 JSON 响应: {raw[:200]}")
            result = json.loads(m.group())
            return result
        except Exception as e:
            print(f"  ⚠ 第{attempt+1}次失败: {e}")
            if attempt < MAX_RETRIES - 1:
                time.sleep(RETRY_DELAY * (attempt + 1))
    return {}   # 全部失败，返回空（保留原文）


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--resume", action="store_true", help="跳过已翻译条目")
    args = parser.parse_args()

    with open(IN_FILE, encoding="utf-8") as f:
        originals: dict = json.load(f)

    # 加载已有翻译（断点续跑）
    if args.resume and os.path.exists(OUT_FILE):
        with open(OUT_FILE, encoding="utf-8") as f:
            translated: dict = json.load(f)
        print(f"断点续跑：已有 {len(translated)} 条翻译")
    else:
        translated = {}

    # 只翻译还没有 translated 字段的条目
    pending_keys = [k for k in originals if k not in translated or "translated" not in translated[k]]
    # 先把已有翻译的条目复制过来
    for k, v in originals.items():
        if k in translated and "translated" in translated[k]:
            pass   # 保留
        else:
            translated[k] = dict(v)   # 初始化（无 translated 字段）

    print(f"待翻译: {len(pending_keys)} 条（共 {len(originals)} 条）")

    client = OpenAI(base_url=API_URL + "/v1", api_key=API_KEY)

    # 分批处理
    batch_count = (len(pending_keys) + BATCH_SIZE - 1) // BATCH_SIZE
    done = 0
    failed = 0

    for batch_idx in range(batch_count):
        batch_keys = pending_keys[batch_idx * BATCH_SIZE : (batch_idx + 1) * BATCH_SIZE]
        batch_texts = [originals[k]["text"] for k in batch_keys]

        print(f"  批次 {batch_idx+1}/{batch_count}  ({len(batch_keys)} 条)  ", end="", flush=True)
        t0 = time.time()

        result_map = translate_batch(client, batch_texts)

        elapsed = time.time() - t0
        print(f"{elapsed:.1f}s  命中 {len(result_map)}/{len(batch_keys)}")

        for k, orig_text in zip(batch_keys, batch_texts):
            zh = result_map.get(orig_text, "")
            if zh:
                # 验证长度：中文字符数不能超过 available_chars
                avail = originals[k]["available_chars"]
                if len(zh) > avail:
                    zh = zh[:avail]
                    print(f"    ⚠ 截断 {k}: {len(zh)} → {avail}")
                translated[k]["translated"] = zh
                done += 1
            else:
                # 翻译失败：保留原文
                translated[k]["translated"] = orig_text
                failed += 1

        # 每批完成后立即存盘（防止中途崩溃丢失进度）
        with open(OUT_FILE, "w", encoding="utf-8") as f:
            json.dump(translated, f, ensure_ascii=False, indent=2)

    print(f"\n完成: {done}  失败(保留原文): {failed}")
    print(f"输出: {OUT_FILE}")


if __name__ == "__main__":
    main()
