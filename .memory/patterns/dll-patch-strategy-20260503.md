# DLL Patch 策略经验（2026-05-03）

## MIN_SAFE_CHARS 阈值调整

最终值：`MIN_SAFE_CHARS = 8`（原100→8）

降低后 patch 条目数：2227条（原约780条），新增1447条 UI 标签/短字符串。

## DENY_OFFSETS（绝对不可翻译）

```python
DENY_OFFSETS = {
    0x355EC5,   # 'Five no'  — 事件查找键（avail=7，低于阈值也会被自动排除）
    0x3569AF,   # 'Mouse Y'  — Unity 输入轴名称
    0x3569BF,   # 'Mouse X'  — Unity 输入轴名称
    0x356CC5,   # 'Sprite [' — Unity 精灵路径前缀，翻译会断绝贴图加载
}
```

**规律**：以 `[` 或 `(` 开头/结尾的字符串通常是内部路径/前缀，不可翻译。

## 底部左侧玩家行动组件（P1修复）

- 游戏以**最后一个 `\n`** 分割事件文本，将末段路由到底部左侧单独组件
- 该组件中心 x≈174，面板左边框 x≈75，有效宽度 ≈ 11 中文字符/行
- **修复策略**：`BOTTOM_LINE_OVERRIDES` dict，对已知 offset 直接替换末行为 ≤11字的简化译文
  - 不要拆分末句（拆分会让主体文本末尾出现悬挂分句）
  - 替换整句，确保主体以句号结尾，底部组件显示完整独立句子
- 已知 offset：`0x2f4b09`（五个"不"事件，avail=1054）
  - 原句 21字："而你作为新任总理，可以影响这一举措的执行。"
  - 替换为 11字："你可影响此举措的执行。"

## 输出文件 MD5

| 版本 | MD5 |
|------|-----|
| 原始备份 | ae620e9e3677d45d42244e67ae523ab4 |
| P2修复部署 | 9f7db47cc071d32e61a7ae613a6ac5b3 |
| 本次部署（MIN_SAFE_CHARS=8+P1修复） | 7e67dcbfed4eb3583977d9e29591a880 |

## ⚠️ 严重教训：Unity 内部标识符误 patch（2026-05-03 回归）

### 问题
降低 MIN_SAFE_CHARS 至8后，误patch了 Unity 内部使用的短字符串，导致 Play 按钮和速度档失效。

### 根因
Unity C# 代码使用这些字符串做运行时查找：
- `Transform.Find("Button (N)")` → 按钮定位
- `Input.GetAxis("Mouse ScrollWheel")` → 鼠标滚轮
- `Animator.SetTrigger("Start Focus")` → 动画触发

### 完整 DENY_OFFSETS（截至2026-05-03）

| Offset | 原文 | avail | 原因 |
|--------|------|-------|------|
| 0x355EC5 | 'Five no' | 7 | 事件查找键 |
| 0x3569AF | 'Mouse Y' | 7 | Unity 输入轴 |
| 0x3569BF | 'Mouse X' | 7 | Unity 输入轴 |
| 0x2D2A6D | 'Mouse ScrollWheel' | 17 | Unity 输入轴 |
| 0x2D5820 | 'Button (0)' | 10 | GameObject.Find 键 |
| 0x2D48C7 | 'Button (2)' | 10 | GameObject.Find 键 |
| 0x35117C | 'Button (4)' | 10 | GameObject.Find 键 |
| 0x1ECF85 | 'Button (5)' | 10 | GameObject.Find 键 |
| 0x1ED009 | 'Text (1)' | 8 | UI 组件名称 |
| 0x1ECFB1 | 'TextIf (0)' | 10 | UI 组件名称 |
| 0x1ECFC7 | 'TextIf (1)' | 10 | UI 组件名称 |
| 0x1ECFDD | 'TextIf (2)' | 10 | UI 组件名称 |
| 0x1ECFF3 | 'TextIf (3)' | 10 | UI 组件名称 |
| 0x183F1F | 'Znach (0)' | 9 | 类型标识符 |
| 0x183F5B | 'Znach (1)' | 9 | 类型标识符 |
| 0x183F6F | 'Znach (2)' | 9 | 类型标识符 |
| 0x183F83 | 'Znach (3)' | 9 | 类型标识符 |
| 0x183F97 | 'Znach (4)' | 9 | 类型标识符 |
| 0x183FAB | 'Znach (5)' | 9 | 类型标识符 |
| 0x195245 | 'Znakc (1)' | 9 | 类型标识符 |
| 0x356CC5 | 'Sprite [' | 8 | Unity 精灵路径前缀 |
| 0x3557CD | 'Start Focus' | 11 | 可能 Animator trigger |

### 识别规则（事后总结）
1. `Button (N)` / `TextIf (N)` / `Text (N)` → Unity 场景对象名，**绝不翻译**
2. `Mouse *` / `Horizontal` / `Vertical` / `Fire*` / `Jump` → Unity Input 轴名，**绝不翻译**
3. `Znach (N)` / `Znakc (N)` → 游戏内部枚举/字典键，**绝不翻译**
4. 以 `[` 结尾的短字符串 → 路径前缀，**绝不翻译**
5. 单个动作动词（如 `Start Focus`）→ 可能是 Animator trigger，**谨慎**

### 修复后 MD5
a46afab662e645a20f06d0149886a4b5
