using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Show_diplomacy_data_script : MonoBehaviour
{
	private GlobalScript global1;

	public int num;

	public int plankas;

	private TextMesh text;

	private OkoshkoScript okno;

	public bool olyga;

	public bool reserve;

	public bool ne_nushon;

	public bool gosdolg;

	public bool planka_gosdolg;

	public bool corruption;

	public bool planka;

	public bool red_t;

	public bool warDipWind;

	public GameObject[] playersButtons = new GameObject[5];

	private string name_ru;

	private string name_en;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		text = GetComponent<TextMesh>();
		okno = GetComponent<OkoshkoScript>();
		if (!ne_nushon && !gosdolg && !corruption && !planka && !reserve && !warDipWind)
		{
			name_ru = okno.text;
			name_en = okno.text_en;
			Repaint();
		}
		else if (warDipWind)
		{
			WarDipWindRepaint(GlobalScript.inst);
		}
		else if (gosdolg)
		{
			Repaint_dolg();
		}
		else if (olyga)
		{
			if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
			{
				PlayerShow(show: false);
				PlayerShow(show: true);
			}
			Repaint_olyga();
		}
		else if (planka)
		{
			MakePlankaReady();
		}
		else if (reserve)
		{
			ReserveRepaint();
		}
		else
		{
			Repaint2();
		}
	}

	private void WarDipWindRepaint(GlobalScript a)
	{
		if (num == 22)
		{
			text.text = (((a.gameState.data[num] < 0) ? "-" : "") + Mathf.Abs(a.gameState.data[num] / 10)).ToString() + "." + Mathf.Abs(a.gameState.data[num] % 10);
			okno.text_en = (okno.text = string.Format(a.new_texts[732], '\n', (float)a.gameState.data[22] / 10f, (float)a.gameState.data_old[22] / 10f));
		}
		else if (num == 160)
		{
			text.text = (((a.gameState.data[num] < 0) ? "-" : "") + Mathf.Abs(a.gameState.data[num] / 10)).ToString() + "." + Mathf.Abs(a.gameState.data[num] % 10);
			okno.text_en = (okno.text = string.Format(a.new_texts[733], '\n', (float)a.gameState.data[160] / 10f, (float)a.gameState.data_old[160] / 10f, (float)a.gameState.data[161] / 10f));
		}
		else if (num == 162)
		{
			text.text = (((a.gameState.data[num] < 0) ? "-" : "") + Mathf.Abs(a.gameState.data[num] / 10)).ToString() + "." + Mathf.Abs(a.gameState.data[num] % 10);
			okno.text_en = (okno.text = string.Format(a.new_texts[734], '\n', (float)a.gameState.data[162] / 10f));
		}
		else if (num == 163)
		{
			if (a.gameState.war > 0)
			{
				text.text = $"{(float)a.gameState.data[num] / 10f}%/100%";
			}
			else
			{
				text.text = "-";
			}
			okno.text = (okno.text_en = a.new_texts[800]);
			playersButtons[0].GetComponent<TextMeshPro>().text = a.new_texts[a.gameState.war + 779];
		}
	}

	private void PlayerShow(bool show)
	{
		if (show)
		{
			for (int i = 0; i < global1.gameState.numOfPlayers; i++)
			{
				playersButtons[i].SetActive(value: true);
			}
			return;
		}
		GameObject[] array = playersButtons;
		foreach (GameObject obj in array)
		{
			obj.GetComponent<DoctrinePlayersCoopButtons>().Repaint();
			obj.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (!ne_nushon && !gosdolg && !corruption && !warDipWind)
		{
			Repaint();
		}
		else if (warDipWind)
		{
			WarDipWindRepaint(GlobalScript.inst);
		}
		else if (gosdolg)
		{
			Repaint_dolg();
		}
		else if (corruption)
		{
			Repaint_corrupt();
		}
		else if (olyga)
		{
			Repaint_olyga();
		}
		else if (planka)
		{
			Repaint_planka();
		}
		else if (reserve)
		{
			ReserveRepaint();
		}
		else
		{
			Repaint2();
		}
	}

	public void Repaint2()
	{
		text.text = (((GlobalScript.inst.gameState.data[num] < 0) ? "-" : "") + Mathf.Abs(GlobalScript.inst.gameState.data[num] / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.data[num] % 10);
	}

	public void MakePlankaReady()
	{
		plankas = GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36];
		for (int i = 71; i <= 81; i++)
		{
			plankas += GlobalScript.inst.gameState.data[i];
		}
		plankas /= 6;
		if (GlobalScript.inst.gameState.data[16] > 12)
		{
			plankas -= (GlobalScript.inst.gameState.data[16] - 12) * (plankas / 10);
		}
		Repaint_planka();
	}

	public void Repaint_planka()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			text.text = "Maximum investment:\n" + Mathf.Abs(plankas / 10 + 1) + "." + Mathf.Abs(plankas % 10);
		}
		else
		{
			text.text = "Максимальный вклад:\n" + Mathf.Abs(plankas / 10 + 1) + "." + Mathf.Abs(plankas % 10);
		}
	}

	public void ReserveRepaint()
	{
		int num = 0;
		int num2 = 0;
		if (GlobalScript.inst.gameState.data[21] < 1980)
		{
			if (GlobalScript.inst.gameState.data[16] == 13)
			{
				num2 -= GlobalScript.inst.gameState.data[36] / 400;
				num = ((GlobalScript.inst.gameState.data[36] >= 600) ? (num + 1) : (num - (3 - GlobalScript.inst.gameState.data[36] / 150)));
			}
			else if (GlobalScript.inst.gameState.data[16] >= 14)
			{
				num2 -= GlobalScript.inst.gameState.data[36] / 200;
				num = ((GlobalScript.inst.gameState.data[36] >= 750) ? (num + 1) : (num - (4 - GlobalScript.inst.gameState.data[36] / 150)));
			}
		}
		else if (GlobalScript.inst.gameState.data[16] == 13)
		{
			num2 -= GlobalScript.inst.gameState.data[36] / 600;
			num = ((GlobalScript.inst.gameState.data[36] >= 750) ? (num + 1) : (num - (4 - GlobalScript.inst.gameState.data[36] / 150)));
		}
		else if (GlobalScript.inst.gameState.data[16] == 14)
		{
			num2 -= GlobalScript.inst.gameState.data[36] / 400;
			num = ((GlobalScript.inst.gameState.data[36] >= 1500) ? (num + 3) : (num - (7 - GlobalScript.inst.gameState.data[36] / 150)));
		}
		else if (GlobalScript.inst.gameState.data[16] == 15)
		{
			num2 -= GlobalScript.inst.gameState.data[36] / 200;
			num -= 13 - GlobalScript.inst.gameState.data[36] / 150;
		}
		else if (GlobalScript.inst.gameState.data[16] == 12)
		{
			num2 -= GlobalScript.inst.gameState.data[36] / 200;
			num = ((GlobalScript.inst.gameState.data[36] >= 600) ? (num + 1) : (num - (3 - GlobalScript.inst.gameState.data[36] / 150)));
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (num >= 10)
			{
				text.text = "Influence of the Reserve:\nServices, Ind. and SoL: +" + Mathf.Abs(num / 10) + "." + Mathf.Abs(num % 10);
			}
			else if (num <= -10)
			{
				text.text = "Influence of the Reserve:\nServices, Ind. and SoL: -" + Mathf.Abs(num / 10) + "." + Mathf.Abs(num % 10);
			}
			else if (num < 0)
			{
				text.text = "Influence of the Reserve:\nServices, Ind. and SoL: -0." + Mathf.Abs(num);
			}
			else
			{
				text.text = "Influence of the Reserve:\nServices, Ind. and SoL: +0." + num;
			}
			TextMesh textMesh = text;
			textMesh.text = textMesh.text + "\nCorruption -0." + Mathf.Abs(num2);
			TextMesh textMesh2 = text;
			textMesh2.text = textMesh2.text + "\nYour alliance stability +" + (float)GlobalScript.inst.gameState.data[36] / 1500f;
		}
		else
		{
			if (num >= 10)
			{
				text.text = "Влияние резерва:\nУслуги, Пром., УрЖ: +" + Mathf.Abs(num / 10) + "." + Mathf.Abs(num % 10);
			}
			else if (num <= -10)
			{
				text.text = "Влияние резерва:\nУслуги, Пром., УрЖ: -" + Mathf.Abs(num / 10) + "." + Mathf.Abs(num % 10);
			}
			else if (num < 0)
			{
				text.text = "Влияние резерва:\nУслуги, Пром., УрЖ: -0." + Mathf.Abs(num);
			}
			else
			{
				text.text = "Влияние резерва:\nУслуги, Пром., УрЖ: +0." + num;
			}
			TextMesh textMesh3 = text;
			textMesh3.text = textMesh3.text + "\nКоррупция -0." + Mathf.Abs(num2);
			TextMesh textMesh4 = text;
			textMesh4.text = textMesh4.text + "\nСтабильность альянса +" + (float)GlobalScript.inst.gameState.data[36] / 1500f;
		}
	}

	public void Repaint_olyga()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.data[108] < 18)
			{
				text.text = "No oligarchs\nInfluence: " + GlobalScript.inst.gameState.data[108] + "/100";
			}
			else if (GlobalScript.inst.gameState.data[108] < 36)
			{
				text.text = "Emergence of Oligarchy\nInfluence: " + GlobalScript.inst.gameState.data[108] + "/100";
			}
			else if (GlobalScript.inst.gameState.data[108] < 54)
			{
				text.text = "Medium strength Oligarchy\nInfluence: " + GlobalScript.inst.gameState.data[108] + "/100";
			}
			else if (GlobalScript.inst.gameState.data[108] < 72)
			{
				text.text = "Strong Oligarchy\nInfluence: " + GlobalScript.inst.gameState.data[108] + "/100";
			}
			else
			{
				text.text = "Oligarchy in power\nInfluence: " + GlobalScript.inst.gameState.data[108] + "/100";
			}
		}
		else if (GlobalScript.inst.gameState.data[108] < 18)
		{
			text.text = "Олигархов нет\nВлияние: " + GlobalScript.inst.gameState.data[108] + "/100";
		}
		else if (GlobalScript.inst.gameState.data[108] < 36)
		{
			text.text = "Зарождение олигархии\nВлияние: " + GlobalScript.inst.gameState.data[108] + "/100";
		}
		else if (GlobalScript.inst.gameState.data[108] < 54)
		{
			text.text = "Олигархия средней силы\nВлияние: " + GlobalScript.inst.gameState.data[108] + "/100";
		}
		else if (GlobalScript.inst.gameState.data[108] < 72)
		{
			text.text = "Сильная олигархия\nВлияние: " + GlobalScript.inst.gameState.data[108] + "/100";
		}
		else
		{
			text.text = "Засилье олигархии\nВлияние: " + GlobalScript.inst.gameState.data[108] + "/100";
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}

	public void Repaint_dolg()
	{
		if (!planka_gosdolg)
		{
			int num = GlobalScript.inst.gameState.data[69] / 40;
			if (num <= 0 && GlobalScript.inst.gameState.data[69] > 0)
			{
				num = 1;
			}
			if (GlobalScript.inst.gameState.data[21] >= 1983 && GlobalScript.inst.gameState.data[69] > 0)
			{
				num += 2;
			}
			else if (GlobalScript.inst.gameState.data[21] >= 1980 && GlobalScript.inst.gameState.data[69] > 0)
			{
				num++;
			}
			if (PlayerPrefs.GetInt("language") == 0)
			{
				text.text = "Debt loss:\nBudget -" + Mathf.Abs(num / 10) + "." + Mathf.Abs(num % 10);
			}
			else
			{
				text.text = "Потери от долга:\nБюджет -" + Mathf.Abs(num / 10) + "." + Mathf.Abs(num % 10);
			}
		}
		else
		{
			int num2 = (GlobalScript.inst.gameState.empires[0].relations + GlobalScript.inst.gameState.empires[1].relations) / 5;
			if (PlayerPrefs.GetInt("language") == 0)
			{
				text.text = "Maximum debt:\n" + Mathf.Abs(num2 / 10) + "." + Mathf.Abs(num2 % 10);
			}
			else
			{
				text.text = "Максимальный долг:\n" + Mathf.Abs(num2 / 10) + "." + Mathf.Abs(num2 % 10);
			}
		}
	}

	public void Repaint_corrupt()
	{
		int num = GlobalScript.inst.gameState.data[26] / 10;
		int num2 = GlobalScript.inst.gameState.data[26] / 50;
		if (PlayerPrefs.GetInt("language") == 0)
		{
			text.text = "Losses from corruption\nBudget -" + Mathf.Abs(num / 10) + "." + Mathf.Abs(num % 10) + "\nStandard of living: -" + Mathf.Abs(num2 / 10) + "." + Mathf.Abs(num2 % 10);
		}
		else
		{
			text.text = "Потери от коррупции\nБюджет -" + Mathf.Abs(num / 10) + "." + Mathf.Abs(num % 10) + "\nУровень жизни: -" + Mathf.Abs(num2 / 10) + "." + Mathf.Abs(num2 % 10);
		}
	}

	public void Repaint()
	{
		if (num == 28)
		{
			this.text.text = (((GlobalScript.inst.gameState.empires[0].relations < 0) ? "-" : "") + Mathf.Abs(GlobalScript.inst.gameState.empires[0].relations / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.empires[0].relations % 10);
		}
		else if (num == 29)
		{
			this.text.text = (((GlobalScript.inst.gameState.empires[1].relations < 0) ? "-" : "") + Mathf.Abs(GlobalScript.inst.gameState.empires[1].relations / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.empires[1].relations % 10);
		}
		else if (num == 7)
		{
			this.text.text = (((GlobalScript.inst.gameState.influencePRC < 0) ? "-" : "") + Mathf.Abs(GlobalScript.inst.gameState.influencePRC / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.influencePRC % 10);
		}
		else
		{
			this.text.text = (((GlobalScript.inst.gameState.data[num] < 0) ? "-" : "") + Mathf.Abs(GlobalScript.inst.gameState.data[num] / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.data[num] % 10);
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			string text = name_en + ": " + (((GlobalScript.inst.gameState.data_old[num] < 0) ? "-" : "+") + Mathf.Abs(GlobalScript.inst.gameState.data_old[num] / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.data_old[num] % 10);
			if (num == 69)
			{
				bool flag = !GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.modifies[12].active;
				bool flag2 = (GlobalScript.inst.gameState.science[9] || GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.allcountries[1].isASEAN) && !flag;
				string text2 = (GlobalScript.inst.gameState.science[9] ? "<color=green>science Improved conveyor production</color>" : "<color=red>science Improved conveyor production</color>");
				string text3 = (GlobalScript.inst.gameState.allcountries[1].isSEV ? "<color=green>COMECON</color>" : "<color=red>COMECON</color>");
				string text4 = (GlobalScript.inst.gameState.allcountries[1].isASEAN ? "<color=green>ASEAN</color>" : "<color=red>ASEAN</color>");
				_ = GlobalScript.inst.gameState.allcountries[1].econ;
				string text5 = (flag ? "<color=red>Backward economy</color>" : "<color=green>Backward economy</color>");
				text = text + "\nAvailable if has " + text2 + " or in " + text3 + " or in " + text4 + ".";
				text = text + "\nThe next modificator blocks only when outside economic alliances: " + text5;
				text = text + "\n\nStatus: " + (flag2 ? "<color=green>Available</color>" : "<color=red>Unavailable</color>");
			}
			if (okno.text_en != text)
			{
				okno.text_en = text;
			}
		}
		else
		{
			string text = name_ru + ": " + (((GlobalScript.inst.gameState.data_old[num] < 0) ? "-" : "+") + Mathf.Abs(GlobalScript.inst.gameState.data_old[num] / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.data_old[num] % 10);
			if (num == 69)
			{
				bool flag3 = !GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.modifies[12].active;
				bool flag4 = (GlobalScript.inst.gameState.science[9] || GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.allcountries[1].isASEAN) && !flag3;
				string text6 = (GlobalScript.inst.gameState.science[9] ? "<color=green>наука Улучшенное конвеерное производство</color>" : "<color=red>наука Улучшенное конвеерное производство</color>");
				string text7 = (GlobalScript.inst.gameState.allcountries[1].isSEV ? "<color=green>СЭВ</color>" : "<color=red>СЭВ</color>");
				string text8 = (GlobalScript.inst.gameState.allcountries[1].isASEAN ? "<color=green>ASEAN</color>" : "<color=red>ASEAN</color>");
				_ = GlobalScript.inst.gameState.allcountries[1].econ;
				string text9 = (flag3 ? "<color=red>Отсталая экономика</color>" : "<color=green>Отсталая экономика</color>");
				text = text + "\nДоступно, если есть " + text6 + " или в " + text7 + " или в " + text8 + ".";
				text = text + "\nСледующий модификатор блокирует только вне союзов: " + text9;
				text = text + "\n\nСтатус: " + (flag4 ? "<color=green>Доступно</color>" : "<color=red>Недоступно</color>");
			}
			if (okno.text != text)
			{
				okno.text = text;
			}
		}
		if (num == 6)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				if (GlobalScript.inst.gameState.data[6] > 900)
				{
					okno.text_en += "\n<color=red>Аuthoritarian</color>";
				}
				else if (GlobalScript.inst.gameState.data[6] > 790)
				{
					okno.text_en += "\n<color=red>Conservative</color>";
				}
				else if (GlobalScript.inst.gameState.data[6] > 590)
				{
					okno.text_en += "\n<color=green>Moderate</color>";
				}
				else if (GlobalScript.inst.gameState.data[6] > 390)
				{
					okno.text_en += "\n<color=green>Reformer</color>";
				}
				else if (GlobalScript.inst.gameState.data[6] > 190)
				{
					okno.text_en += "\n<color=yellow>Liberal</color>";
				}
				else
				{
					okno.text_en += "\n<color=yellow>Westernizer</color>";
				}
			}
			else if (GlobalScript.inst.gameState.data[6] > 900)
			{
				okno.text += "\n<color=red>Авторитарист</color>";
			}
			else if (GlobalScript.inst.gameState.data[6] > 790)
			{
				okno.text += "\n<color=red>Консерватор</color>";
			}
			else if (GlobalScript.inst.gameState.data[6] > 590)
			{
				okno.text += "\n<color=green>Умеренный</color>";
			}
			else if (GlobalScript.inst.gameState.data[6] > 390)
			{
				okno.text += "\n<color=green>Реформист</color>";
			}
			else if (GlobalScript.inst.gameState.data[6] > 190)
			{
				okno.text += "\n<color=yellow>Либерал</color>";
			}
			else
			{
				okno.text += "\n<color=yellow>Западник</color>";
			}
		}
		else if (red_t)
		{
			if (GlobalScript.inst.gameState.data[5] < 200)
			{
				this.text.color = Color.red;
			}
			else if (GlobalScript.inst.gameState.data[5] < (GlobalScript.inst.gameState.data[16] - 10) * 100 && GlobalScript.inst.gameState.data[16] > 12)
			{
				this.text.color = Color.red;
			}
			else
			{
				this.text.color = Color.white;
			}
		}
	}
}
