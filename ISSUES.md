# 汉化问题文档（全截图汇总）

生成日期：2026-05-03  
截图来源：feedback/ 目录（已全部分析完毕并删除）

---

## P0：富文本标签裸露渲染（DOCTRINES 面板，截图 10.59.04）

**现象**：DOCTRINES 面板底部描述区，`<color=red>`、`<color=blue>`、`</color>` 等富文本标签未被解析，直接以原始字符串渲染到界面上，与中文内容混排，完全破坏可读性。示例：
```
<color=re改进的流水线生产  资金  |  <c
olor=blue>0</color>/500  科学点数
```
- `<color=re` 被截断（换行位置切断了标签）
- 标签与中文内容穿插，无法阅读

**根因假设**：翻译时对含颜色标签的字符串进行了换行重断，导致标签字符串被硬断开。

**修复方向**：
1. 在 `dll_patch.py` / `fix_wrap_and_title.py` 中，对含 `<color=` 标签的字符串，**禁止在标签内部插入换行**；
2. 换行算法需感知标签边界，仅在标签外部的文字内容处断行。

---

## P0：大量短字符串未翻译（全面板，多张截图）

**现象**：`MIN_SAFE_CHARS=100` 导致所有短于 100 字符的字符串被跳过，涵盖游戏绝大多数 UI 标签。

### 导航栏标签（所有面板顶部均可见，曝光率最高）
| 英文 | 建议译文 |
|------|---------|
| `WORLD MAP` | `世界地图` |
| `ECONOMY` | `经济` |
| `SCIENCE` | `科技` |
| `DOCTRINES` | `主义` |
| `POLITICS` | `政治` |
| `WARS` | `战争` |
| `TRADE` | `贸易` |
| `INFLUENCE` | `影响力` |
| `TERRITORIES` | `领土` |
| `SITUATIONS` | `局势` |
| `UNITY` | `统一` |
| `ALLIES` | `盟友` |
| `VIEW` | `视图` |（地图模式专用）

### 右侧快捷按钮（主地图界面，截图 10.59.17）
| 英文 | 建议译文 |
|------|---------|
| `GOVERNMENT` | `政府` |
| `INFLUENCE` | `影响力` |
| `MILITARY` | `军事` |
| `ECONOMY` | `经济` |

### 经济面板标签（截图 10.59.10）
| 英文 | 建议译文 |
|------|---------|
| `INDUSTRY` | `工业` |
| `AGRICULTURE` | `农业` |
| `SERVICES` | `服务业` |
| `CORRUPTION` | `腐败` |
| `ARMY` | `军队` |
| `MSS` | `国家安全部` |
| `SCIENCE` | `科技` |
| `STATE MECHANISM` | `国家机器` |
| `ENVELOPS FOR PARTY MEMBERS` | `党员红包`（原文拼写错误：ENVELOPS→ENVELOPES）|
| `PROPAGANDA` | `宣传` |
| `WELFARE` | `福利` |
| `DIPMISSIONS` | `外交使团`（原文拼写错误：DIPMISSIONS→DIPLOMATIC MISSIONS）|
| `GOLD RESERVE` | `黄金储备` |
| `DEBT LOSS: BUDGET -X` | `债务损耗：预算 -X` |
| `MAXIMUM DEBT: X` | `最大债务：X` |
| `LOSSES FROM CORRUPTION BUDGET -X STANDARD OF LIVING: -X` | `腐败损耗：预算 -X 生活水平：-X` |
| `MAXIMUM INVESTMENT: X` | `最大投资：X` |
| `INFLUENCE OF THE RESERVE: ...` | `储备影响：...` |
| `NO OLIGARCHS INFLUENCE: 0/100` | `无寡头影响：0/100` |

### DOCTRINES 面板标签（截图 10.59.04）
| 英文 | 建议译文 |
|------|---------|
| `Science points` | `科技点数` |

### INFLUENCE 面板标签（截图 10.58.32，已删除，历史记录）
| 英文 | 建议译文 |
|------|---------|
| `WORLD VIEW` | `世界观` |
| `NOWADAYS: SEVERAL PEOPLES` | `当前：数个民族` |
| `CHINESE UNITY LEVEL` | `中国统一水平` |
| `SPECIAL INFLUENCE` | `特殊影响力` |
| `NOTHING` | `无` |
| `POPULATION` | `人口` |

### ALLIES 面板标签（截图 10.58.36，已删除，历史记录）
| 英文 | 建议译文 |
|------|---------|
| `OUR ALLIES` | `我们的盟友` |
| `WE DON'T HAVE OUR OWN ALLIANCE` | `我们没有自己的联盟` |

### WORLD MAP 工具提示（截图 10.58.40，已删除，历史记录）
| 英文 | 建议译文 |
|------|---------|
| `FROM DIPMISSIONS AND INFLUENCE` | `来自外交使团和影响力` |
| `2 WEEKS: : +0.0` | `2周：+0.0` |
| `Intervention points` | `干预点数` |

**修复方向**：降低 `MIN_SAFE_CHARS` 阈值（如改为 10），或将上述所有偏移量加入 `APPROVED_OFFSETS` 白名单，重新跑 `dll_patch.py`。

---

## P0：经济面板数值格式化问题（截图 10.59.10）

**现象**：右侧财政信息栏中 `YOUR ALLIANCE STABILITY -0.03333334`，浮点数未格式化，精度过高，应限制为 2 位小数。

**注意**：这可能是游戏原始代码的问题，非翻译导致，修复需改 DLL 中的格式化逻辑或翻译字符串中的数值占位符。

---

## P1：短行顶着左边框（系统性对齐问题，截图1 + 截图4，已删除）

**现象**：部分中文行顶着左边框渲染，没有左边距，看起来对齐错误。

**根因假设**：游戏文本渲染器可能对短行（比宽度阈值短）采用了不同的对齐模式（如左对齐而非居中）。

**修复方向**：调查 TextMesh Pro 渲染器设置，或在每行文本前补充空格padding（低风险方案）。

---

## P2：孤立句号行首（中文断行标点外挂，截图1，已删除）

**现象**：换行后句号 `。` 出现在下一行行首，违反中文排版规范。

**修复方向**：在 `fix_wrap_and_title.py` 的换行算法中加入"行尾标点回挂"逻辑：若预计断行后下一行首字符为标点，则将断点前移一格。

---

## 已知原文拼写错误（不修复，翻译时意译）

| 原文 | 实际含义 |
|------|---------|
| `ENVELOPS FOR PARTY MEMBERS` | 党员福利/红包（ENVELOPES 拼写错误）|
| `DIPMISSIONS` | 外交使团（DIPLOMATIC MISSIONS 缩写不规范）|

---

## 修复优先级顺序

1. **P0-A** 富文本标签裸露：修复 `fix_wrap_and_title.py` 换行算法，感知 `<color=...>` 标签边界
2. **P0-B** 短字符串未翻译：降低 `MIN_SAFE_CHARS` 或扩展白名单，重新 patch DLL
3. **P0-C** 经济面板数值格式化：调查是否可在翻译层修复
4. **P1** 短行顶左边框：调查 TextMesh 渲染对齐
5. **P2** 孤立句号行首：`fix_wrap_and_title.py` 加标点回挂逻辑
