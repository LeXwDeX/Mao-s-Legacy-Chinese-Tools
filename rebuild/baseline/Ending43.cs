using System.Collections.Generic;
using System.Linq;
using EndingsDLCDraft;
using UnityEngine;

public class Ending43 : EndingsSecond
{
	private readonly string[] english_labels = new string[19]
	{
		"=== Citizen Information ===", "市民：", "Age: ", "Current Job: ", "Job History: ", "None", " times", "财富：", "/15", "Charisma: ",
		"Intrigue: ", "Children: ", "Primary Trait: ", "Secondary Trait: ", "Tertiary Traits: ", "Date of Birth: ", "Date of Death: ", "变更：", "------------------------"
	};

	private readonly string[] russian_labels = new string[19]
	{
		"=== Информация о гражданах ===", "Гражданин: ", "Возраст: ", "Текущая работа: ", "История работ: ", "Нет", " раз", "Богатство: ", "/15", "Харизма: ",
		"Интриги: ", "Дети: ", "Основная черта: ", "Вторичная черта: ", "Третичные черты: ", "Дата рождения: ", "Дата смерти: ", "Изменения: ", "------------------------"
	};

	private readonly string[] job_english_text = new string[12]
	{
		"Unemployed", "Worker", "Peasant", "Farmer", "小企业主", "公司老板", "Prisoned", "Amnestied", "Underground", "地方党支部书记",
		"地区党支部书记", "重要党员"
	};

	private readonly string[] job_russian_text = new string[12]
	{
		"Безработный", "Рабочий", "Крестьянин", "Фермер", "Малый предприниматель", "Владелец корпорации", "Заключенный", "Амнистированный", "Подпольщик", "Глава местного отделения партии",
		"Глава регионального отделения партии", "Значимый член партии"
	};

	private readonly Dictionary<CitizenManager.PrimaryTrait, (string english, string russian)> primary_trait_translations = new Dictionary<CitizenManager.PrimaryTrait, (string, string)>
	{
		{
			CitizenManager.PrimaryTrait.None,
			("None", "Отсутствует")
		},
		{
			CitizenManager.PrimaryTrait.LeftRadical,
			("左派激进分子", "Левый радикал")
		},
		{
			CitizenManager.PrimaryTrait.Moderate,
			("Moderate", "Умеренный")
		},
		{
			CitizenManager.PrimaryTrait.Reformist,
			("Reformist", "Реформист")
		},
		{
			CitizenManager.PrimaryTrait.Liberal,
			("Liberal", "Либерал")
		}
	};

	private readonly Dictionary<CitizenManager.SecondaryTrait, (string english, string russian)> secondary_trait_translations = new Dictionary<CitizenManager.SecondaryTrait, (string, string)>
	{
		{
			CitizenManager.SecondaryTrait.None,
			("None", "Отсутствует")
		},
		{
			CitizenManager.SecondaryTrait.Firm,
			("Firm", "Твёрдый")
		},
		{
			CitizenManager.SecondaryTrait.Pragmatic,
			("Pragmatic", "Прагматик")
		},
		{
			CitizenManager.SecondaryTrait.Soft,
			("Soft", "Мягкий")
		},
		{
			CitizenManager.SecondaryTrait.Scientist,
			("Scientist", "Учёный")
		}
	};

	private readonly Dictionary<CitizenManager.TertiaryTrait, (string english, string russian)> tertiary_trait_translations = new Dictionary<CitizenManager.TertiaryTrait, (string, string)>
	{
		{
			CitizenManager.TertiaryTrait.None,
			("None", "Отсутствует")
		},
		{
			CitizenManager.TertiaryTrait.Pettytyrant,
			("小暴君", "Самодур")
		},
		{
			CitizenManager.TertiaryTrait.Thrifty,
			("Thrifty", "Экономный")
		},
		{
			CitizenManager.TertiaryTrait.Arrogant,
			("Arrogant", "Надменный")
		},
		{
			CitizenManager.TertiaryTrait.Idol,
			("Idol", "Кумир")
		},
		{
			CitizenManager.TertiaryTrait.Chinophilic,
			("Chinophilic", "Китаефил")
		},
		{
			CitizenManager.TertiaryTrait.Westophilic,
			("Westophilic", "Западник")
		},
		{
			CitizenManager.TertiaryTrait.Schemer,
			("Schemer", "Интриган")
		},
		{
			CitizenManager.TertiaryTrait.Timid,
			("Timid", "Робкий")
		},
		{
			CitizenManager.TertiaryTrait.Peculator,
			("Peculator", "Казнокрад")
		}
	};

	private void Awake()
	{
	}

	public override void TextOfEnding(ref string name, ref string text)
	{
		GlobalScript inst = GlobalScript.inst;
		_ = inst.gameState;
		int num = 2;
		Persona persona = inst.gameState.citizens[num];
		int num2 = PlayerPrefs.GetInt("language", 0);
		bool isEnglish = num2 == 0;
		string[] labels = (isEnglish ? english_labels : russian_labels);
		string text2 = labels[0] + "\n";
		name = labels[0];
		if (persona != null)
		{
			text2 = text2 + labels[1] + persona.name + " " + persona.surname + "\n";
			text2 += $"{labels[2]}{persona.age}\n";
			text2 = text2 + labels[3] + GetJobTranslation(persona.status, isEnglish) + "\n";
			text2 += "\n";
			text2 = text2 + labels[4] + "\n";
			if (persona.jobHistory.Count > 0)
			{
				IEnumerable<string> values = from j in persona.jobHistory
					group j by j into g
					select $"{GetJobTranslation(g.Key, isEnglish)} {g.Count()}{labels[6]}";
				text2 = text2 + string.Join("\n", values) + "\n";
			}
			else
			{
				text2 = text2 + labels[5] + "\n";
			}
			text2 += "\n";
			text2 += $"{labels[7]}{persona.Wealth}{labels[8]}\n";
			text2 += $"{labels[9]}{persona.Charisma}{labels[8]}\n";
			text2 += $"{labels[10]}{persona.Intrigue}{labels[8]}\n";
			text2 += $"{labels[11]}{persona.Children}\n";
			text2 += "\n";
			text2 = text2 + labels[12] + GetPrimaryTraitTranslation(persona.primaryTrait, isEnglish) + "\n";
			text2 = text2 + labels[13] + GetSecondaryTraitTranslation(persona.secondaryTrait, isEnglish) + "\n";
			text2 += labels[14];
			text2 += ((persona.tertiaryTraits.Count > 0) ? string.Join(", ", persona.tertiaryTraits.Select((CitizenManager.TertiaryTrait t) => GetTertiaryTraitTranslation(t, isEnglish))) : labels[5]);
			text2 += "\n\n";
			text2 += $"{labels[15]}{persona.birthDate[0]}.{persona.birthDate[1]}.{persona.birthDate[2]}\n";
			if (persona.isDead)
			{
				text2 += $"{labels[16]}{persona.lastDeathCheck[0]}.{persona.lastDeathCheck[1]}.{persona.lastDeathCheck[2]}\n";
			}
			text2 = text2 + "\n" + labels[17] + "\n";
			text2 += ((persona.changeLog.Count > 0) ? string.Join("\n", persona.changeLog) : labels[5]);
			text2 = text2 + "\n\n" + labels[18] + "\n";
		}
		else
		{
			text2 += (isEnglish ? "No citizen data available.\n" : "Данные о гражданине отсутствуют.\n");
		}
		text = text2.Replace("\n", "|");
		Debug.Log("Ending43 Text:\n" + text);
	}

	private string GetJobTranslation(Job job, bool isEnglish)
	{
		if (!isEnglish)
		{
			return job_russian_text[(int)job];
		}
		return job_english_text[(int)job];
	}

	private string GetPrimaryTraitTranslation(CitizenManager.PrimaryTrait trait, bool isEnglish)
	{
		if (primary_trait_translations.TryGetValue(trait, out (string, string) value))
		{
			if (!isEnglish)
			{
				return value.Item2;
			}
			return value.Item1;
		}
		if (!isEnglish)
		{
			return "Отсутствует";
		}
		return "None";
	}

	private string GetSecondaryTraitTranslation(CitizenManager.SecondaryTrait trait, bool isEnglish)
	{
		if (secondary_trait_translations.TryGetValue(trait, out (string, string) value))
		{
			if (!isEnglish)
			{
				return value.Item2;
			}
			return value.Item1;
		}
		if (!isEnglish)
		{
			return "Отсутствует";
		}
		return "None";
	}

	private string GetTertiaryTraitTranslation(CitizenManager.TertiaryTrait trait, bool isEnglish)
	{
		if (tertiary_trait_translations.TryGetValue(trait, out (string, string) value))
		{
			if (!isEnglish)
			{
				return value.Item2;
			}
			return value.Item1;
		}
		if (!isEnglish)
		{
			return "Отсутствует";
		}
		return "None";
	}
}
