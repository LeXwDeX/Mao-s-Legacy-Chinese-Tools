# AGENTS.md — OpenCode Agent Instructions

## Project Overview

**Chinese localization (汉化) for Mao's Legacy (毛泽东的遗产)** — a Unity historical strategy game.
- **Game install path**: `C:\Program Files (x86)\Steam\steamapps\common\Mao's Legacy\`
- **Source data path**: `1.8.5_Resources/Data/` (软链到 `China_Data/`，实际在 `C:\...\Mao's Legacy\China_Data\`)
- **Output directory**: `1.8.5_output/` (23 patched files)
- **Game version**: 1.8.5
- **CJK Font**: LXGW WenKai Mono v1.522 (`fonts/LXGWWenKaiMono-Regular.ttf`, 24.4 MB)

This repo is NOT the game itself. It is the **tooling** that extracts text from the game, translates it via LLM, and patches it back into the game binaries. There are **two independent localization pipelines** that must both succeed:

1. **解包汉化 (TextAsset pipeline)** — JSON text files extracted from `resources.assets`, translated, injected back
2. **DLL汉化 (DLL pipeline)** — hardcoded C# strings in `Assembly-CSharp.dll`, extracted, translated, binary-patched

## 软链前提 (每次开新会话必看)

仓库里的 `1.8.5_Resources/Data` 是**软链**指向 Windows 游戏安装目录的 `China_Data/`：
```
1.8.5_Resources/Data  →  /mnt/c/Program Files (x86)/Steam/steamapps/common/Mao's Legacy/China_Data/
```

如果软链丢失（如换机器/重装 WSL），需要重建：
```bash
mkdir -p 1.8.5_Resources
ln -s "/mnt/c/Program Files (x86)/Steam/steamapps/common/Mao's Legacy/China_Data" 1.8.5_Resources/Data
```

如果软链不存在，所有 patch 脚本会因找不到源文件而失败。

## 格式硬约束 — 违反必崩，不可恢复

| 约束 | 说明 | 涉及脚本 |
|------|------|----------|
| **DLL blob 尺寸精确保留** | UTF-16LE 编码 + 空格填充必须恰好占满 `available_chars × 2` 字节。多一字节或少一字节 = DLL 损坏 | `dll_patch.py` |
| **Level 文件字符串对齐** | Unity level 格式: `[4字节LE长度][UTF-8内容][零填充到4字节对齐]`。patched block 字节数必须 == 原始 block 字节数 | `patch_levels.py` |
| **换行符保留** | `resources.assets` 使用 `\r\n`，inject/repack 必须原样还原。`\n` vs `\r\n` 不匹配可导致游戏文本不显示 | `inject_text_assets.py`, `repack.py` |
| **标签完整性** | Unity 富文本标签 `<color=red>` `</color>` `<b>` 和格式占位符 `{0}` `{1}` 必须原样存活 | 所有翻译脚本 |
| **CJK 断行规则** | Unity TextMesh 只在空格处断行。中文无空格，`fix_wrap_and_title.py` 实现标点感知断行。绝不在 `<...>` 标签内断行 | `fix_wrap_and_title.py` |

## Run Commands

```bash
# Web UI (Flask, port 5000) — entry point is app.py, NOT main.py
python app.py

# DLL string pipeline (must run in order):
uv run python3 extract_dll_strings.py   # extract from decompiled/ C# source
uv run python3 dll_translate.py          # LLM batch translate → dll_strings/translated.json
uv run python3 fix_wrap_and_title.py     # post-process: CJK line-wrapping + title overrides
uv run python3 dll_patch.py             # binary patch Assembly-CSharp.dll → 1.8.5_output/

# TextAsset pipeline (requires UnityPy):
uv run --with UnityPy python3 extract_text_assets.py  # extract *_en.json from resources.assets
uv run --with UnityPy python3 inject_text_assets.py   # write *_zh.json back → 1.8.5_output/

# Level / TextMesh patching:
uv run python3 patch_levels.py           # patch MonoBehaviour strings in level files
uv run --with UnityPy python3 patch_textmesh.py  # inject CJK glyphs + patch TextMesh labels

# Legacy repack (v1 pipeline, for 1.7.9.2 only):
uv run --with UnityPy python3 repack.py
```

**No test suite, no linter, no CI.** Verify by inspecting output files in `1.8.5_output/`.

## Environment Setup

- Copy `.env.example` → `.env`, fill OpenAI-compatible API URL + key
- `requirements.txt` only lists flask/cors/dotenv (web UI). Other scripts need: `UnityPy`, `fontTools`, `openai` — run via `uv run --with <pkg>`
- **No `main.py` exists** — `app.py` is the Flask entry point (README is inaccurate)

## Architecture — Three Parallel Pipelines

### Pipeline A: Web UI (`app.py`)
Flask app for manual JSON file translation. Upload UABEA-exported JSON → view/edit lines → download. Uses `/gpt_translate` for single-line LLM calls with tag protection (`<...>` → placeholder → restore).

### Pipeline B: DLL Strings (`extract_dll_strings.py` → `dll_translate.py` → `dll_patch.py`)
Extracts hardcoded English strings from decompiled C# in `decompiled/`, batch-translates via LLM, patches `Assembly-CSharp.dll` binary in-place using UTF-16LE encoding.

### Pipeline C: TextAssets (`extract_text_assets.py` → manual → `inject_text_assets.py`)
Extracts `*_en` JSON TextAssets from `resources.assets`, translate to `*_zh.json`, inject back via UnityPy.

**Plus**: `patch_levels.py` (level file MonoBehaviour patching) and `patch_textmesh.py` (font glyph injection + TextMesh label patching).

## 1.8.5 汉化状态 (截至 2026-06-03 收尾)

### Output 文件清单 (23 个，全部已生成)

| 文件 | 大小 | 产出脚本 |
|------|------|----------|
| `Assembly-CSharp.dll` | 3.4 MB | `dll_patch.py` |
| `resources.assets` | 10.0 MB | `inject_text_assets.py` |
| `level2/3/5/6/7/8/9/11/12/13/14/15/16/17/20/21/23/24` | 18 files (原 7) | `patch_levels.py` |
| `sharedassets3.assets` | **48 MB** | `patch_textmesh.py` (完整字体替换) |
| `sharedassets15.assets` | 25 KB | `patch_textmesh.py` (TextMesh) |
| `sharedassets18.assets` | 6.9 KB | `patch_textmesh.py` (TextMesh) |

字节级验证: **18 level + DLL 全部与源字节一致** (in-place patch 无偏移)。

### DLL 汉化状态 — ✅ 完成

| 指标 | 数值 |
|------|------|
| 提取条目 (original.json) | 2189 |
| 翻译条目 (translated.json) | 2238 (含手动追加 49 条) |
| 实际写入 DLL | **2212** |
| DENY_OFFSETS 拦截 (正确) | 22 |
| APPROVED_OFFSETS 放行 | 4 (含新增 3 条 MIN_SAFE 短文本) |
| 未翻译 (translated==text) | 4 (格式串/占位符, 无需翻译) |

**DLL 翻译覆盖率: 2212/2234 ≈ 99%** — 完成。

### TextAsset (解包汉化) 状态 — ✅ 完成

- 23 个 `_en.json` 文件全部有对应 `_zh.json` ✅
- 全部 23 个文件行数一致 ✅
- **P0 结构错位已修复** (new_event_text_zh 69行全部对齐, new_focuses_texts_zh 349行全部对齐)
- **P0 西藏/Syria 空白段落已补译** (Events_text 616 行 1588 字符, new_texts 269 行 897 字符)
- **P1 短标签已翻译** (Still developing/That's enough/Victory 等)

### Level 文件 patch 状态 — ✅ 完成

18 个 level 全部加入 `patch_levels.py` TARGET_LEVELS:

| 新增 Level | 面板类型 | Patch 条目数 |
|-----------|---------|------------|
| `level2` | 主菜单 | 8 (Settings/Load/Exit/Authors/New Game/Tutorial/Game Rules/Chosen country) |
| `level5` | 音乐机 | 44 (UI 标签 + 歌名) |
| `level11` | 统计/外交 | 11 (indicators) |
| `level12` | 存档槽 | 5 (slot 标签) |
| `level13` | 读档槽 | 5 |
| `level14` | 政治派系管理 | 46 (任命按钮/区域/特质) |
| `level16` | 经济面板 | 11 (budget/relations/...) |
| `level17` | **教程** (高价值) | 31 段落 |
| `level20` | 设置窗 | 1 (System) |
| `level21` | 南美地图 | 28 |
| `level24` | 多人大厅 | 38 |

翻译字典: `translations_dict.json` (集中双语表) + `level_translations.py` + `level_translations_level17.py`。

### TextMesh / 字体状态 — ✅ 完成

- **`patch_textmesh.py` 改用 LXGW WenKai Mono 完整替换** (不再是"注入字形"),
  避免 Merger 兼容性问题 (LXGW 的 vhea/vmtx/meta 与原字体冲突)
- 字体资产 `sharedassets3.assets` 从 375 KB 膨胀到 **48 MB** (包含完整 24.4 MB LXGW TTF)
- 视觉风格变化: 所有 UI 字体都变为 LXGW WenKai Mono (等宽, 楷体风), 对全中文化合适
- `FONT_CJK_CHARS` 字典保留用于记录 (实际已不再使用, 整体替换不需要)
- 11 条 TextMesh 文本 patch (sharedassets15/18) 保留原方案 (pid 定位替换)

### ⚠️ 仍未完成项 (超出汉化范围)

| 项 | 优先级 | 状态 | 说明 |
|----|--------|------|------|
| 经济面板数值精度 (`-0.03333334`) | P1 | ❌ | 需改 C# `.ToString()` → `ToString("F2")`, **需 DLL IL 重写**, 超出翻译范围 |
| 短行左对齐 (TextMesh 渲染器设置) | P1 | ❌ | 需调查 Unity TextMesh 组件, **修改游戏 prefab**, 超出翻译范围 |
| 5 首歌跳过翻译 | P2 | ⚠️ | 字典值字节数超过 blk 约束 (Anthem of PRC/CPC 等) |
| 2 个多行组合标签跳过 | P2 | ⚠️ | `Capital\|North\|West\|South\|East` 等超出 |

### ISSUES.md Bug 修复状态

| Bug | 优先级 | 状态 |
|-----|--------|------|
| P0-A: 富文本标签被换行切断 | P0 | ✅ 已修复 — `fix_wrap_and_title.py` in_tag 状态机 |
| P0-B: 短字符串未翻译 | P0 | ✅ 已修复 — MIN_SAFE_CHARS 降至 8, APPROVED_OFFSETS 扩展到 4 |
| P0-C: 经济面板数值精度 | P0 | ❌ 超出汉化范围 |
| P1: 短行左对齐 | P1 | ❌ 超出汉化范围 |
| P2: 孤立句号行首 | P2 | ✅ 已修复 — NO_LINE_START 禁则集 |

## Critical Constraints — Do Not Violate

1. **DLL binary patching must preserve exact blob size.** UTF-16LE content + space padding must fill exactly `available_chars * 2` bytes. One byte off = corrupted DLL.
2. **`DENY_OFFSETS`** (`dll_patch.py`) are **forbidden to translate** — these are Unity lookup keys (`Input.GetAxis`, `Transform.Find`, `GameObject.Find`). Translating them breaks the game silently.
3. **`MIN_SAFE_CHARS`** — strings shorter than this threshold are skipped by default (likely internal identifiers). Only bypass for entries in `APPROVED_OFFSETS`.
4. **Line ending preservation** — `resources.assets` uses `\r\n`. The inject/repack scripts must reproduce exactly; a `\n` vs `\r\n` mismatch can break game text display.
5. **Tag protection** — Unity rich text tags (`<color=red>`, `</color>`, `<b>`) and format placeholders (`{0}`, `{1}`) must survive translation intact. The web UI does this via placeholder substitution; `dll_translate.py` relies on the LLM prompt.
6. **CJK line wrapping** — Unity TextMesh only breaks at spaces. Chinese text has no spaces, so `fix_wrap_and_title.py` implements custom wrapping with punctuation-aware breakpoints. Never break inside `<...>` tags.
7. **Font 整体替换** — `patch_textmesh.py` 用 LXGW WenKai Mono 整体替换游戏的 pt-mono/Font1 字体 (不再做最小注入，避免 Merger 兼容性问题)。`sharedassets3.assets` 会从 375 KB 膨胀到 48 MB，这是预期行为。
8. **Level string alignment** — Unity level string format: `[4-byte LE length][UTF-8 content][zero-pad to 4-byte aligned]`. Patched block must be byte-identical in size to original.
9. **翻译字典集中维护** — 所有 UI 标签翻译优先查 `translations_dict.json`; level 翻译在 `level_translations.py` / `level_translations_level17.py`; 避免同一术语在不同地方翻译不一致。

## Key Directories

| Directory | Purpose |
|-----------|---------|
| `decompiled/` | Decompiled C# source from game DLLs (input for DLL extraction) |
| `dll_strings/` | `original.json` → `translated.json` pipeline artifacts |
| `text_assets/` | Extracted JSON TextAssets (`*_en`, `*_ru`, `*_zh` variants) |
| `1.8.5_Resources/Data` | **软链** → `China_Data/` (游戏源数据) |
| `1.8.5_output/` | All patched output files (23 个) — copy to game dir to deploy |
| `fonts/` | CJK 字体源 (LXGW WenKai Mono v1.522) |
| `1.8.5/` | Split `resources.assets` (`.original/` + `.chinese/` for v1 pipeline) |
| `1.7.9.2/` | Legacy v1 pipeline data (old game version, 1.7.9.2) |
| `static/js/` | Frontend JS for the web UI |
| `feedback/` | User testing feedback (screenshots + issue tracking) |
| `.task_state/` | 任务台账 (task_plan.md + progress.md) |
