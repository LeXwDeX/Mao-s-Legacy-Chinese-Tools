using System.Collections.Generic;
using UnityEngine;

public class ChoiceSystemController : MonoBehaviour
{
	public Transform mainWindowTR;

	public Transform mainWindowBL;

	public Transform subWindowTR;

	public Transform subWindowBL;

	public Transform subWindow;

	public ChoiceButton[] mainButtons;

	public ChoiceButton[] subButtons;

	private int selectedChoiceType = -1;

	private int[] currentSelectedChoices;

	private string[] choiceTypeNames;

	private List<string>[] choicesNames;

	private List<string>[] choicesDesc;

	public GlobalScript global1;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (PlayerPrefs.GetInt("language") == 0)
		{
			Set(new int[9]
			{
				PlayerPrefs.GetInt("gamerules0"),
				PlayerPrefs.GetInt("gamerules1"),
				PlayerPrefs.GetInt("gamerules2"),
				PlayerPrefs.GetInt("gamerules3"),
				PlayerPrefs.GetInt("gamerules4"),
				PlayerPrefs.GetInt("gamerules5"),
				PlayerPrefs.GetInt("gamerules6"),
				PlayerPrefs.GetInt("gamerules7"),
				PlayerPrefs.GetInt("gamerules8")
			}, new string[9] { "作弊面板", "合作模式", "美国的领导人", "苏联的领导人", "清除竞争者", "可被任命", "政客出走", "政客的影响力", "无限大跃进" }, new List<string>[9]
			{
				new List<string> { "关（✓成就）", "开（✖成就）", "事件中不计领导力（✖成就）" },
				new List<string> { "关（✓成就）", "为二（✖成就）", "为三（✖成就）", "为四（✖成就）", "为五（✖成就）" },
				new List<string> { "按世界形势（✓成就）", "随机（✖成就）", "由玩家指定（✖成就）" },
				new List<string> { "按世界形势（✓成就）", "随机（✖成就）", "由玩家指定（✖成就）" },
				new List<string> { "只要强者（✓成就）", "人人（✖成就）", "只要耍心机的（✖成就）", "一个不留（✖成就）" },
				new List<string> { "层级匹配（✓成就）", "全部（✖成就）" },
				new List<string> { "标准（✓成就）", "每五年（✓成就）", "不死之身（✓成就）" },
				new List<string> { "标准（✓成就）", "扶弱（✖成就）", "扶强（✖成就）", "派系势均力敌（✖成就）" },
				new List<string> { "禁用（✓成就）", "难度模式（✓成就）", "死亡模式（✓成就）", "运气模式（✓成就）" }
			}, new List<string>[9]
			{
				new List<string> { "以普通模式进行游戏", "在外交窗口中启用作弊面板。", "在外交窗口中启用作弊面板。 And in the conditions of the event response options the leading faction is not taken into account." },
				new List<string> { "以普通模式进行游戏", "规则：|游戏在单一窗口进行。\n派系不可被禁。|教义：|投票选出的教义选项，\n依据各派系公开人数并结合玩家投票结果决定。\n|事件中的回答选项：|每名玩家投票给自己最喜欢的回答选项；\n最终选择“实际派系人数加权总和”更高的回答选项（按玩家投票结\n果计算）。 ", "规则：|游戏在单一窗口进行。\n派系不可被禁。|教义：|投票选出的教义选项，\n依据各派系公开人数并结合玩家投票结果决定。\n|事件中的回答选项：|每名玩家投票给自己最喜欢的回答选项；\n最终选择“实际派系人数加权总和”更高的回答选项（按玩家投票结\n果计算）。", "规则：|游戏在单一窗口进行。\n派系不可被禁。|教义：|投票选出的教义选项，\n依据各派系公开人数并结合玩家投票结果决定。\n|事件中的回答选项：|每名玩家投票给自己最喜欢的回答选项；\n最终选择“实际派系人数加权总和”更高的回答选项（按玩家投票结\n果计算）。", "规则：|每名玩家分配一个派系。\n游戏在单一窗口进行。\n派系不可被禁。|教义：|投票选出的教义选项，\n依据各派系公开人数并结合玩家投票结果决定。\n|事件中的回答选项：|每名玩家投票给自己最喜欢的回答选项；\n最终选择“实际派系人数加权总和”更高的回答选项（按玩家投票结\n果计算）。" },
				new List<string> { "以普通模式进行游戏", "统治者将随机产生。", "在更换统治者事件中，玩家可以自行更换统治者。" },
				new List<string> { "以普通模式进行游戏", "统治者将随机产生。", "在更换统治者事件中，玩家可以自行更换统治者。" },
				new List<string> { "以普通模式进行游戏", "所有角色互相倾轧。", "只有具备“阴谋家”特质的角色才能参与阴谋。", "禁止阴谋" },
				new List<string> { "以普通模式进行游戏", "任何角色都可以被安排到任何职位。" },
				new List<string> { "以普通模式进行游戏", "每5年，所有角色离场并更换为新角色。", "角色不会因年老而死亡，也不会获得“患病”特质。" },
				new List<string> { "以普通模式进行游戏", "最弱的5名角色获得政治影响力提升。", "最强的5名角色获得政治影响力提升。", "游戏开始时，各派系人数相等。" },
				new List<string> { "以普通模式进行游戏", "所有玩家属性不得高于70.0（但“放宽”低于30）", "所有玩家属性不得高于50.0（但“放宽”低于50）", "玩家无法指派政治人物到职位；他们会在每回合随机变动。" }
			});
		}
		else
		{
			Set(new int[9]
			{
				PlayerPrefs.GetInt("gamerules0"),
				PlayerPrefs.GetInt("gamerules1"),
				PlayerPrefs.GetInt("gamerules2"),
				PlayerPrefs.GetInt("gamerules3"),
				PlayerPrefs.GetInt("gamerules4"),
				PlayerPrefs.GetInt("gamerules5"),
				PlayerPrefs.GetInt("gamerules6"),
				PlayerPrefs.GetInt("gamerules7"),
				PlayerPrefs.GetInt("gamerules8")
			}, new string[9] { "Панель читов", "Кооперативный режим", "Правители США", "Правители СССР", "Убирают конкурентов", "Кого можно назначать", "Уход политиков", "Влияние политиков", "Бесконечный скачок" }, new List<string>[9]
			{
				new List<string> { "Выключена (✓Достижения)", "Включена (✖Достижения)", "Без учёта лидерства в событиях (✖Достижения)" },
				new List<string> { "Выключен (✓Достижения)", "На двоих (✖Достижения)", "На троих (✖Достижения)", "На четверых (✖Достижения)", "На пятерых (✖Достижения)" },
				new List<string> { "По ситуации в мире (✓Достижения)", "Случайные (✖Достижения)", "Назначаются игроком (✖Достижения)" },
				new List<string> { "По ситуации в мире (✓Достижения)", "Случайные (✖Достижения)", "Назначаются игроком (✖Достижения)" },
				new List<string> { "Только сильные (✓Достижения)", "Все (✖Достижения)", "Только интриганы (✖Достижения)", "Никто (✖Достижения)" },
				new List<string> { "Соответствие иерархии (✓Достижения)", "Всех (✖Достижения)" },
				new List<string> { "Стандартный (✓Достижения)", "Каждые 5 лет (✓Достижения)", "Бессмертные (✓Достижения)" },
				new List<string> { "Стандартный (✓Достижения)", "Усиление слабых (✖Достижения)", "Усиление сильных (✖Достижения)", "Равные фракции (✖Достижения)" },
				new List<string> { "Режим отключён (✓Достижения)", "Режим усложнения (✓Достижения)", "Режим смерти (✓Достижения)", "Режим везения (✓Достижения)" }
			}, new List<string>[9]
			{
				new List<string> { "Игра в обычном режиме", "Панель с читами становится доступна в окне дипломатии.", "Панель с читами становится доступна в окне дипломатии. А в условиях вариантов ответа событий не учитывается лидирующая фракция." },
				new List<string> { "Игра в обычном режиме", "Правила:|Игра ведётся на одном окне. Фракции невозможно запрещать.|Доктрины:|вариант доктрины выставленный на голосование принимается на основании открытых значений численности фракций в зависимости от того, как проголосовали игроки.|Варианты ответа в событиях:|каждый игрок голосует за понравившейся вариант ответа, выбирается тот вариант ответа, за который в сумме вышло больше реальной численности фракций в зависимости от того, как проголосовали игроки. ", "Правила:|Игра ведётся на одном окне. Фракции невозможно запрещать.|Доктрины:|вариант доктрины выставленный на голосование принимается на основании открытых значений численности фракций в зависимости от того, как проголосовали игроки.|Варианты ответа в событиях:|каждый игрок голосует за понравившейся вариант ответа, выбирается тот вариант ответа, за который в сумме вышло больше реальной численности фракций в зависимости от того, как проголосовали игроки. ", "Правила:|Игра ведётся на одном окне. Фракции невозможно запрещать.|Доктрины:|вариант доктрины выставленный на голосование принимается на основании открытых значений численности фракций в зависимости от того, как проголосовали игроки.|Варианты ответа в событиях:|каждый игрок голосует за понравившейся вариант ответа, выбирается тот вариант ответа, за который в сумме вышло больше реальной численности фракций в зависимости от того, как проголосовали игроки.", "Правила:|Каждому игроку отходит по одной фракции. Игра ведётся на одном окне. Фракции невозможно запрещать.|Доктрины:|вариант доктрины выставленный на голосование принимается на основании открытых значений численности фракций в зависимости от того, как проголосовали игроки.|Варианты ответа в событиях:|каждый игрок голосует за понравившейся вариант ответа, выбирается тот вариант ответа, за который в сумме вышло больше реальной численности фракций в зависимости от того, как проголосовали игроки." },
				new List<string> { "Игра в обычном режиме", "Правители будут выбираться случайно.", "В событиях на смену правителей игрок сможет сам менять их." },
				new List<string> { "Игра в обычном режиме", "Правители будут выбираться случайно.", "В событиях на смену правителей игрок сможет сам менять их." },
				new List<string> { "Игра в обычном режиме", "Все персонажи охотятся друг на друга.", "Только персонажи с чертой интриган могут участвовать в заговорах.", "Заговоры запрещены." },
				new List<string> { "Игра в обычном режиме", "Любой персонаж может быть назначен на любую должность." },
				new List<string> { "Игра в обычном режиме", "Каждые 5 лет все персонажи уходят и приходят новые.", "Персонажи не могут умереть от старости и не могут получить черту заболевшего." },
				new List<string> { "Игра в обычном режиме", "Слабейшие 5 персонажей получают прирост политической силы.", "Сильнейшие 5 персонажей получают прирост политической силы.", "На старте игры численность всех фракций будет одинаковой" },
				new List<string> { "Игра в обычном режиме", "Все показатели игрока не могут быть выше 70.0 (а либерализация ниже 30)", "Все показатели игрока не могут быть выше 50.0 (а либерализация ниже 50)", "Игрок не может назначать политиков на должности, они сами меняются каждый ход случайным образом." }
			});
		}
	}

	public void Set(int[] currentSelectedChoices, string[] choiceTypeNames, List<string>[] choicesNames, List<string>[] choicesDesc)
	{
		this.currentSelectedChoices = currentSelectedChoices;
		this.choicesNames = choicesNames;
		this.choiceTypeNames = choiceTypeNames;
		this.choicesDesc = choicesDesc;
		Repaint();
	}

	private void Repaint()
	{
		subWindow.gameObject.SetActive(selectedChoiceType != -1);
		if (selectedChoiceType != -1)
		{
			for (int i = 0; i < subButtons.Length; i++)
			{
				if (i > choicesNames[selectedChoiceType].Count - 1)
				{
					subButtons[i].gameObject.SetActive(value: false);
					continue;
				}
				subButtons[i].gameObject.SetActive(value: true);
				subButtons[i].ChangeText(choicesNames[selectedChoiceType][i], choicesDesc[selectedChoiceType][i]);
				subButtons[i].ChangeSelected(currentSelectedChoices[selectedChoiceType] == i);
				subButtons[i].transform.localPosition = new Vector3((subWindowTR.localPosition.x + subWindowBL.localPosition.x) * 0.5f, Mathf.Lerp(subWindowTR.localPosition.y, subWindowBL.localPosition.y, (float)i / (float)(choicesNames[selectedChoiceType].Count - 1)), subButtons[i].transform.localPosition.z);
			}
		}
		for (int j = 0; j < mainButtons.Length; j++)
		{
			if (j > choiceTypeNames.Length - 1)
			{
				mainButtons[j].gameObject.SetActive(value: false);
				continue;
			}
			mainButtons[j].gameObject.SetActive(value: true);
			mainButtons[j].ChangeText(choiceTypeNames[j]);
			mainButtons[j].ChangeSelected(selectedChoiceType == j);
			mainButtons[j].transform.localPosition = new Vector3((mainWindowTR.localPosition.x + mainWindowBL.localPosition.x) * 0.5f, Mathf.Lerp(mainWindowTR.localPosition.y, mainWindowBL.localPosition.y, (float)j / (float)(choiceTypeNames.Length - 1)), mainButtons[j].transform.localPosition.z);
		}
	}

	public void ChoiceMade(int choiceType, int choiceValue)
	{
		Debug.Log($"Choice {choiceType} is {choiceValue} now");
	}

	public void CloseSubWindow()
	{
		selectedChoiceType = -1;
		Repaint();
	}

	public void ReceiveButtonPress(int num)
	{
		if (num >= 100)
		{
			num -= 100;
			selectedChoiceType = ((selectedChoiceType == num) ? (-1) : num);
			Repaint();
		}
		else
		{
			currentSelectedChoices[selectedChoiceType] = num;
			GlobalScript.inst.gameState.gamerules[selectedChoiceType] = num;
			PlayerPrefs.SetInt("gamerules" + selectedChoiceType, num);
			ChoiceMade(selectedChoiceType, num);
			Repaint();
		}
	}
}
