using UnityEngine;
using UnityEngine.SceneManagement;

public class Science_Script : MonoBehaviour
{
	public Politic_Show_Data data_sh;

	public GlobalScript global1;

	public int number;

	public int number_zavisimost;

	public int days;

	public int money;

	public int data;

	public int working = -1;

	public bool is_working_here;

	public SpriteRenderer galka;

	public SpriteRenderer shkala;

	public TextMesh text;

	private Material shkala_mat;

	public string name_ru;

	public string name_en;

	public string desc_ru;

	public string desc_en;

	public GameObject Plashka;

	public GameObject scienceForDlc02;

	public TextMesh T1;

	public TextMesh T2;

	public TextMesh T3;

	public GameObject[] playersButtons = new GameObject[5];

	public Sprite yes;

	public Sprite no;

	private void Update()
	{
		if (number == 0 && Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}

	private void Awake()
	{
		CheckToDestroy();
		global1 = GlobalScript.inst;
		if (GlobalScript.inst.gameState.science_need_time[number] != days)
		{
			GlobalScript.inst.gameState.science_need_time[number] = days;
		}
		shkala_mat = shkala.material;
		text.text = data.ToString();
		Repaint();
		for (int i = 0; i < GlobalScript.inst.gameState.science_in_progress.Length; i++)
		{
			if (GlobalScript.inst.gameState.science_in_progress[i] && !GlobalScript.inst.gameState.science[i])
			{
				working = i;
				Debug.Log(working.ToString());
			}
			else if (i == working && GlobalScript.inst.gameState.science[i])
			{
				working = -1;
				Debug.Log(working.ToString());
			}
		}
	}

	private void CheckToDestroy()
	{
		if (!GlobalScript.inst.dlc[2] && number == 27)
		{
			Object.Destroy(scienceForDlc02);
		}
	}

	private void Repaint()
	{
		if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			for (int i = 0; i < playersButtons.Length; i++)
			{
				if (i < global1.gameState.numOfPlayers)
				{
					playersButtons[i].SetActive(value: true);
					playersButtons[i].GetComponent<DoctrinePlayersCoopButtons>().Repaint();
				}
				else
				{
					playersButtons[i].SetActive(value: false);
				}
			}
		}
		text.text = data.ToString();
		if (number_zavisimost == -1 || GlobalScript.inst.gameState.science[number_zavisimost])
		{
			galka.sprite = yes;
		}
		else
		{
			galka.sprite = no;
		}
		if (GlobalScript.inst.gameState.science_time[number] > 0)
		{
			float num = 0f;
			num = (float)GlobalScript.inst.gameState.science_time[number] / (float)days;
			if (num > 0f)
			{
				shkala_mat.SetFloat("_M", num);
			}
			else
			{
				shkala_mat.SetFloat("_M", 0f);
			}
		}
		else
		{
			shkala_mat.SetFloat("_M", 0f);
		}
	}

	private void OnMouseEnter()
	{
		Plashka.SetActive(value: true);
		RepaintPlashka();
	}

	private bool GetSecondReqForPlayers()
	{
		return GlobalScript.inst.gameState.GetSecondReqForPlayers();
	}

	private void RepaintPlashka()
	{
		bool secondReqForPlayers = GetSecondReqForPlayers();
		T1.text = GlobalScript.inst.new_texts[593 + number];
		T3.text = Text(string.Format("{0}{1}{2}{1}{3}", GlobalScript.inst.other_text[356 + number], '\n', GlobalScript.inst.other_text[390 + number], (!GlobalScript.inst.other_text[564 + number].Contains("#")) ? GlobalScript.inst.other_text[564 + number] : null), 99);
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.science[number])
			{
				T2.text = $"<color=red>{(float)money / 10f}</color> money | <color=green> Researched </color>";
			}
			else if (number == 17 && GlobalScript.inst.gameState.data[118] == 0)
			{
				T2.text = string.Format("<color=red>我们尚未宣布全面自动化 </color>", (float)money / 10f, GlobalScript.inst.gameState.science_time[number], days);
			}
			else if (GlobalScript.inst.gameState.science_in_progress[number])
			{
				T2.text = $"<color=red>{(float)money / 10f}</color> money | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} science points | <color=green> In progress... </color>";
			}
			else if (working != -1)
			{
				T2.text = $"<color=red>{(float)money / 10f}</color> money | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} science points | <color=red> One per time </color>";
			}
			else if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0 && !secondReqForPlayers)
			{
				T2.text = $"<color=red>{(float)money / 10f}</color> money | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} science points |<color=red> >50% of deputies to voted FOR</color>";
			}
			else if (GlobalScript.inst.gameState.data[21] >= data && (number_zavisimost == -1 || GlobalScript.inst.gameState.science[number_zavisimost]) && working == -1)
			{
				T2.text = $"<color=red>{(float)money / 10f}</color> money | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} science points | <color=red> Available </color>";
			}
			else if (GlobalScript.inst.gameState.data[21] < data && (number_zavisimost == -1 || GlobalScript.inst.gameState.science[number_zavisimost]) && working == -1)
			{
				T2.text = $"<color=red>{(float)money / 10f}</color> money | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} science points | <color=red> Penalty: +{days * (data - GlobalScript.inst.gameState.data[21]) - GlobalScript.inst.gameState.data[20] * (days / 12)} science points </color>";
			}
			else
			{
				T2.text = $"<color=red>{(float)money / 10f}</color> money | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} science points | <color=red> Not available </color>";
			}
			return;
		}
		int[] array = new int[40];
		if (GlobalScript.inst.gameState.modifies[51].active)
		{
			array[2] = 1;
			array[3] = 1;
			array[6] = 1;
			array[8] = 1;
			array[7] = 1;
			array[10] = 1;
			array[11] = 1;
			array[13] = 1;
			array[14] = 1;
		}
		if (GlobalScript.inst.gameState.science[number])
		{
			T2.text = $"<color=red>{(float)money / 10f}</color> денег | <color=green> Исследовано </color>";
		}
		else if (number == 17 && GlobalScript.inst.gameState.data[118] == 0)
		{
			T2.text = string.Format("<color=red> Мы ещё не заявили о полномасштабной автоматизации </color>", (float)money / 10f, GlobalScript.inst.gameState.science_time[number], days);
		}
		else if (GlobalScript.inst.gameState.science_in_progress[number])
		{
			T2.text = $"<color=red>{(float)money / 10f}</color> денег | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} очков науки | <color=green> В прогрессе... </color>";
		}
		else if (working != -1)
		{
			T2.text = $"<color=red>{(float)money / 10f}</color> денег | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} очков науки | <color=red> Один за раз </color>";
		}
		else if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0 && !secondReqForPlayers)
		{
			T2.text = $"<color=red>{(float)money / 10f}</color> денег | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} очков науки |<color=red> >50% депутатов должны быть ЗА</color>";
		}
		else if (GlobalScript.inst.gameState.data[21] >= data && (number_zavisimost == -1 || GlobalScript.inst.gameState.science[number_zavisimost]) && working == -1)
		{
			T2.text = $"<color=red>{(float)money / 10f}</color> денег | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} очков науки | <color=red> Доступно </color>";
		}
		else if (GlobalScript.inst.gameState.data[21] < data && (number_zavisimost == -1 || GlobalScript.inst.gameState.science[number_zavisimost]) && working == -1)
		{
			T2.text = $"<color=red>{(float)money / 10f}</color> денег | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} очков науки | <color=red> Штраф: +{days * (data - GlobalScript.inst.gameState.data[21]) - GlobalScript.inst.gameState.data[20] * (days / 12)} очков науки </color>";
		}
		else
		{
			T2.text = $"<color=red>{(float)money / 10f}</color> денег | <color=blue>{GlobalScript.inst.gameState.science_time[number]}</color>/{days} очков науки | <color=red> Не доступно </color>";
		}
	}

	private void OnMouseExit()
	{
		Plashka.SetActive(value: false);
	}

	private void OnMouseDown()
	{
		for (int i = 0; i < GlobalScript.inst.gameState.science_in_progress.Length; i++)
		{
			if (GlobalScript.inst.gameState.science_in_progress[i] && !GlobalScript.inst.gameState.science[i])
			{
				working = i;
				Debug.Log(working.ToString());
			}
			else if (i == working && GlobalScript.inst.gameState.science[i])
			{
				working = -1;
				Debug.Log(working.ToString());
			}
		}
		if (((number == 17 && GlobalScript.inst.gameState.data[118] != 0) || number != 17) && !GlobalScript.inst.gameState.science_in_progress[number] && working == -1 && !GlobalScript.inst.gameState.science[number] && GlobalScript.inst.gameState.science_time[number] <= 0)
		{
			if ((number_zavisimost == -1 || GlobalScript.inst.gameState.science[number_zavisimost]) && (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] < 1 || (GetSecondReqForPlayers() && GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
			{
				GlobalScript.inst.gameState.science_time[number] += GlobalScript.inst.gameState.data[11];
				if (GlobalScript.inst.gameState.data[21] < data)
				{
					GlobalScript.inst.gameState.science_time[number] -= days * (data - GlobalScript.inst.gameState.data[21]) - GlobalScript.inst.gameState.data[20] * (days / 12);
				}
				GlobalScript.inst.gameState.data[11] = 0;
				GlobalScript.inst.gameState.science_in_progress[number] = true;
				Repaint();
				RepaintPlashka();
				GlobalScript.inst.gameState.data[8] -= money;
				GlobalScript.inst.gameState.leader.is_sleshka = false;
			}
		}
		else
		{
			RepaintPlashka();
		}
		data_sh.Repaint();
	}

	private static string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
