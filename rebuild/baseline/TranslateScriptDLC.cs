using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TranslateScriptDLC : MonoBehaviour
{
	public string[] english_text = new string[20];

	public string[] russian_text = new string[20];

	public Text[] textText = new Text[20];

	public string[] job_english_text = new string[12]
	{
		"Unemployed", "Worker", "Peasant", "Farmer", "小企业主", "公司老板", "Prisoned", "Amnestied", "Underground", "地方党支部书记",
		"地区党支部书记", "重要党员"
	};

	public string[] job_russian_text = new string[12]
	{
		"Безработный", "Рабочий", "Крестьянин", "Фермер", "Малый предприниматель", "Владелец корпорации", "Заключенный", "Амнистированный", "Подпольщик", "Глава местного отделения партии",
		"Глава регионального отделения партии", "Значимый член партии"
	};

	public bool no_need_russian;

	public bool needEsc;

	private void Start()
	{
		Repaint();
	}

	private void Update()
	{
		if (needEsc && Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}

	public void Repaint()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			for (int i = 0; i < textText.Length; i++)
			{
				textText[i].text = english_text[i].Replace('|', '\n');
			}
		}
		else if (!no_need_russian)
		{
			for (int j = 0; j < textText.Length; j++)
			{
				textText[j].text = russian_text[j].Replace('|', '\n');
			}
		}
	}

	public string GetTranslation(string english, string russian)
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			return english;
		}
		if (!no_need_russian)
		{
			return russian;
		}
		return english;
	}

	public string GetJobTranslation(Job job)
	{
		return GetTranslation(job_english_text[(int)job], job_russian_text[(int)job]);
	}
}
