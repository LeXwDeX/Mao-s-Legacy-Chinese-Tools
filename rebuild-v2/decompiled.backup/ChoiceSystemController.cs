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
			}, new string[9] { "Cheat Panel", "Cooperative mode", "US' leaders", "USSR' leaders", "Removing competitors", "Can be appointed", "Politicians leaving", "Influence of politicians", "Infinite Leap Forward" }, new List<string>[9]
			{
				new List<string> { "Off (✓Achievements)", "On (✖Achievements)", "Don't count leadership in events (✖Achievements)" },
				new List<string> { "Off (✓Achievements)", "For two (✖Achievements)", "For three (✖Achievements)", "For four(✖Achievements)", "For five (✖Achievements)" },
				new List<string> { "By World Situation (✓Achievements)", "Random (✖Achievements)", "Assigned by Player (✖Achievements)" },
				new List<string> { "By World Situation (✓Achievements)", "Random (✖Achievements)", "Assigned by Player (✖Achievements)" },
				new List<string> { "Only strong ones (✓Achievements)", "Everyone (✖Achievements)", "Only scheming ones (✖Achievements)", "Nobody (✖Achievements)" },
				new List<string> { "Hierarchy match (✓Achievements)", "All (✖Achievements)" },
				new List<string> { "Standard (✓Achievements)", "Every 5 years (✓Achievements)", "Immortal (✓Achievements)" },
				new List<string> { "Standard (✓Achievements)", "Strengthening the weak (✖Achievements)", "Strengthening the strong (✖Achievements)", "Equal factions (✖Achievements)" },
				new List<string> { "Disabled (✓Achievements)", "Difficulty Mode (✓Achievements)", "Death Mode (✓Achievements)", "Luck Mode (✓Achievements)" }
			}, new List<string>[9]
			{
				new List<string> { "Game in normal mode", "The cheat panel becomes available in the diplomacy window.", "The cheat panel becomes available in the diplomacy window. And in the conditions of the event response options the leading faction is not taken into account." },
				new List<string> { "Game in normal mode", "Rules:|The game is played on a single window. Factions cannot be banned.|Doctrines:|The doctrine option voted on is decided based on the open faction numbers, depending on how the players voted.|Answer options in events:|each player votes for their favourite answer option, the answer option that has a higher total of actual faction numbers based on how the players voted is chosen. ", "Rules:|The game is played on a single window. Factions cannot be banned.|Doctrines:|The doctrine option voted on is decided based on the open faction numbers, depending on how the players voted.|Answer options in events:|each player votes for their favourite answer option, the answer option that has a higher total of actual faction numbers based on how the players voted is chosen.", "Rules:|The game is played on a single window. Factions cannot be banned.|Doctrines:|The doctrine option voted on is decided based on the open faction numbers, depending on how the players voted.|Answer options in events:|each player votes for their favourite answer option, the answer option that has a higher total of actual faction numbers based on how the players voted is chosen.", "Rules:|Each player gets one faction. The game is played on a single window. Factions cannot be banned.|Doctrines:|The doctrine option voted on is decided based on the open faction numbers depending on how the players voted.|Answer options in events:|each player votes for their favourite answer option, the answer option that has a higher total of actual faction numbers based on how the players voted is chosen." },
				new List<string> { "Game in normal mode", "Rulers will be chosen randomly.", "In ruler change events, the player will be able to change rulers themselves." },
				new List<string> { "Game in normal mode", "Rulers will be chosen randomly.", "In ruler change events, the player will be able to change rulers themselves." },
				new List<string> { "Game in normal mode", "All characters prey on each other.", "Only characters with the schemer trait can participate in conspiracies.", "Conspiracies are forbidden" },
				new List<string> { "Game in normal mode", "Any character can be assigned to any position." },
				new List<string> { "Game in normal mode", "Every 5 years, all characters leave and new ones come in.", "Characters can't die of old age and can't get the sick trait." },
				new List<string> { "Game in normal mode", "Weakest 5 characters get a political power boost.", "Strongest 5 characters get a political power boost.", "At the start of the game, the numbers of all factions is equal." },
				new List<string> { "Game in normal mode", "All player stats cannot be higher than 70.0 (but liberalization less than 30)", "All player stats cannot be higher than 50.0 (but liberalization less than 50)", "The player cannot assign politicians to positions, they themselves change each turn randomly." }
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
