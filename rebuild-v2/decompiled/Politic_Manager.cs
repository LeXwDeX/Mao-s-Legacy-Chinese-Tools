using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Politic_Manager : MonoBehaviour
{
	public Politic_Show_Data[] data;

	private GlobalScript global1;

	private GameState state;

	private static readonly StringBuilder SharedSb = new StringBuilder(512);

	public string[] traits_ru = new string[20];

	public string[] traits_en = new string[20];

	public string[] first_names = new string[0];

	public string[] second_names = new string[0];

	public Politic_Script[] first = new Politic_Script[3];

	public Politic_Script[] second = new Politic_Script[4];

	public Politic_Script[] third = new Politic_Script[5];

	public Politic_Script[] forth = new Politic_Script[6];

	public Button_Pol_Script[] buttons = new Button_Pol_Script[14];

	public TextMesh t_zagovor;

	public TextMesh[] traits = new TextMesh[3];

	public TextMesh name_pol;

	public GameObject buttons_obj;

	public GameObject button_lead_obj;

	public byte selected_politic = 200;

	public byte politic_to_display_loyality = 200;

	public Sprite[] stateDolzh = new Sprite[4];

	public GameObject[] playersButtons = new GameObject[5];

	public void Awake()
	{
		global1 = GlobalScript.inst;
		state = global1.gameState;
		first_names = state.names1;
		second_names = state.names2;
		traits_ru = (traits_en = state.traitsName);
		GameObject.Find("Bearu(0)").GetComponent<BeurocratsScript>().Repaint();
		GameObject.Find("Bearu(1)").GetComponent<BeurocratsScript>().Repaint();
		CoopRepaint();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}

	public void RepaintData()
	{
		Politic_Show_Data[] array = data;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Repaint();
		}
		CoopRepaint();
	}

	public void CoopRepaint()
	{
		if (!GlobalScript.inst.dlc[6])
		{
			buttons[16].gameObject.SetActive(value: false);
		}
		if (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] <= 0)
		{
			return;
		}
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

	public void Politic_Selected(byte num)
	{
		selected_politic = num;
		if (num != 200 && num != 150)
		{
			buttons_obj.SetActive(value: true);
			button_lead_obj.SetActive(value: false);
			Button_Pol_Script[] array = buttons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Repaint();
			}
			GameState gameState = state;
			Politic politic = gameState.politics[num];
			bool num2 = PlayerPrefs.GetInt("language") != 0;
			name_pol.text = $"{first_names[politic.name_1]} {second_names[politic.name_2]} ({politic.age})";
			StringBuilder sharedSb = SharedSb;
			sharedSb.Length = 0;
			if (!num2)
			{
				for (int j = 0; j < traits.Length; j++)
				{
					traits[j].text = traits_en[politic.traits[j]];
				}
				if (gameState.faction_leader[0] == num)
				{
					sharedSb.Append(global1.new_texts[1045]);
				}
				else if (gameState.faction_leader[1] == num)
				{
					sharedSb.Append(global1.new_texts[1046]);
				}
				else if (gameState.faction_leader[2] == num)
				{
					sharedSb.Append(global1.new_texts[1047]);
				}
				else if (gameState.faction_leader[3] == num)
				{
					sharedSb.Append(global1.new_texts[1048]);
				}
				else if (gameState.faction_leader[4] == num)
				{
					sharedSb.Append(global1.new_texts[1049]);
				}
				sharedSb.Append(global1.new_texts[1050]);
				if (gameState.politics_dolshnost[0] == num)
				{
					sharedSb.Append(global1.new_texts[1051]);
				}
				if (gameState.politics_dolshnost[1] == num)
				{
					sharedSb.Append(global1.new_texts[1052]);
				}
				if (gameState.politics_dolshnost[2] == num)
				{
					sharedSb.Append(global1.new_texts[1053]);
				}
				sharedSb.Append(global1.new_texts[1054]);
				if (gameState.politics_dolshnost[3] == num)
				{
					sharedSb.Append(global1.new_texts[1055]);
				}
				if (gameState.politics_dolshnost[4] == num)
				{
					sharedSb.Append(global1.new_texts[1056]);
				}
				if (gameState.politics_dolshnost[5] == num)
				{
					sharedSb.Append(global1.new_texts[1057]);
				}
				if (gameState.politics_dolshnost[6] == num)
				{
					sharedSb.Append(global1.new_texts[1058]);
				}
				if (gameState.politics_dolshnost[7] == num)
				{
					sharedSb.Append(global1.new_texts[1059]);
				}
				sharedSb.Append('|');
				if (politic.is_sledstvie)
				{
					sharedSb.Append(string.Format(global1.new_texts[1060], 7 - politic.sled_slej));
				}
				else
				{
					sharedSb.Append(global1.new_texts[1061]);
				}
				sharedSb.Append('|');
				if (politic.is_sleshka)
				{
					sharedSb.Append(string.Format(global1.new_texts[1062], politic.days_sleshka, gameState.ChangeOfKilling(num) * 100f));
				}
				else
				{
					sharedSb.Append(global1.new_texts[1063]);
				}
				sharedSb.Append('|');
				if (politic.power <= 250)
				{
					sharedSb.Append(global1.new_texts[1064]);
				}
				else if (politic.power <= 500)
				{
					sharedSb.Append(global1.new_texts[1065]);
				}
				else if (politic.power <= 700)
				{
					sharedSb.Append(global1.new_texts[1066]);
				}
				else
				{
					sharedSb.Append(global1.new_texts[1067]);
				}
				sharedSb.Append('|');
				if (politic.you_fall)
				{
					sharedSb.Append(global1.new_texts[1068]);
				}
				if (politic.is_sleshka)
				{
					if (politic.is_sagovor)
					{
						sharedSb.Append(global1.new_texts[1069]);
					}
					if (((politic.loyality < 450 && politic.traits[2] == 16) || politic.you_fall || (politic.loyality < 300 && politic.traits[2] != 9) || (politic.loyality < 150 && politic.traits[2] == 9)) && politic.traits[2] != 17 && politic.traits[2] != 19 && !politic.is_sledstvie)
					{
						sharedSb.Append(global1.new_texts[1070]);
					}
				}
			}
			else
			{
				for (int k = 0; k < traits.Length; k++)
				{
					traits[k].text = traits_ru[politic.traits[k]];
				}
				if (gameState.faction_leader[0] == num)
				{
					sharedSb.Append(global1.new_texts[1045]);
				}
				else if (gameState.faction_leader[1] == num)
				{
					sharedSb.Append(global1.new_texts[1046]);
				}
				else if (gameState.faction_leader[2] == num)
				{
					sharedSb.Append(global1.new_texts[1047]);
				}
				else if (gameState.faction_leader[3] == num)
				{
					sharedSb.Append(global1.new_texts[1048]);
				}
				else if (gameState.faction_leader[4] == num)
				{
					sharedSb.Append(global1.new_texts[1049]);
				}
				sharedSb.Append(global1.new_texts[1050]);
				if (gameState.politics_dolshnost[0] == num)
				{
					sharedSb.Append(global1.new_texts[1051]);
				}
				if (gameState.politics_dolshnost[1] == num)
				{
					sharedSb.Append(global1.new_texts[1052]);
				}
				if (gameState.politics_dolshnost[2] == num)
				{
					sharedSb.Append(global1.new_texts[1053]);
				}
				sharedSb.Append(global1.new_texts[1054]);
				if (gameState.politics_dolshnost[3] == num)
				{
					sharedSb.Append(global1.new_texts[1055]);
				}
				if (gameState.politics_dolshnost[4] == num)
				{
					sharedSb.Append(global1.new_texts[1056]);
				}
				if (gameState.politics_dolshnost[5] == num)
				{
					sharedSb.Append(global1.new_texts[1057]);
				}
				if (gameState.politics_dolshnost[6] == num)
				{
					sharedSb.Append(global1.new_texts[1058]);
				}
				if (gameState.politics_dolshnost[7] == num)
				{
					sharedSb.Append(global1.new_texts[1059]);
				}
				sharedSb.Append('|');
				if (politic.is_sledstvie)
				{
					sharedSb.Append(string.Format(global1.new_texts[1060], 7 - politic.sled_slej));
				}
				else
				{
					sharedSb.Append(global1.new_texts[1061]);
				}
				sharedSb.Append('|');
				if (politic.is_sleshka)
				{
					sharedSb.Append(string.Format(global1.new_texts[1062], politic.days_sleshka, gameState.ChangeOfKilling(num) * 100f));
				}
				else
				{
					sharedSb.Append(global1.new_texts[1063]);
				}
				sharedSb.Append('|');
				if (politic.power <= 250)
				{
					sharedSb.Append(global1.new_texts[1064]);
				}
				else if (politic.power <= 500)
				{
					sharedSb.Append(global1.new_texts[1065]);
				}
				else if (politic.power <= 700)
				{
					sharedSb.Append(global1.new_texts[1066]);
				}
				else
				{
					sharedSb.Append(global1.new_texts[1067]);
				}
				sharedSb.Append('|');
				if (politic.you_fall)
				{
					sharedSb.Append(global1.new_texts[1068]);
				}
				if (politic.is_sleshka)
				{
					if (politic.is_sagovor)
					{
						sharedSb.Append(global1.new_texts[1069]);
					}
					if (((politic.loyality < 450 && politic.traits[2] == 16) || politic.you_fall || (politic.loyality < 300 && politic.traits[2] != 9) || (politic.loyality < 150 && politic.traits[2] == 9)) && politic.traits[2] != 17 && politic.traits[2] != 19 && !politic.is_sledstvie)
					{
						sharedSb.Append(global1.new_texts[1070]);
					}
				}
			}
			string text = sharedSb.ToString();
			t_zagovor.text = Text(text, 30);
		}
		else if (num == 150)
		{
			buttons_obj.SetActive(value: false);
			GameState gameState2 = state;
			name_pol.text = $"{first_names[gameState2.leader.name_1]} {second_names[gameState2.leader.name_2]}";
			StringBuilder sharedSb2 = SharedSb;
			sharedSb2.Length = 0;
			if (PlayerPrefs.GetInt("language") == 0)
			{
				for (int l = 0; l < traits.Length; l++)
				{
					traits[l].text = traits_en[gameState2.leader.traits[l]];
				}
				sharedSb2.Append(global1.new_texts[1071]);
				sharedSb2.Append(global1.new_texts[1050]);
				if (gameState2.politics_dolshnost[0] == num)
				{
					sharedSb2.Append(global1.new_texts[1051]);
				}
				if (gameState2.politics_dolshnost[1] == num)
				{
					sharedSb2.Append(global1.new_texts[1052]);
				}
				if (gameState2.politics_dolshnost[2] == num)
				{
					sharedSb2.Append(global1.new_texts[1053]);
				}
				sharedSb2.Append(global1.new_texts[1054]);
				if (gameState2.politics_dolshnost[3] == num)
				{
					sharedSb2.Append(global1.new_texts[1055]);
				}
				if (gameState2.politics_dolshnost[4] == num)
				{
					sharedSb2.Append(global1.new_texts[1056]);
				}
				if (gameState2.politics_dolshnost[5] == num)
				{
					sharedSb2.Append(global1.new_texts[1057]);
				}
				if (gameState2.politics_dolshnost[6] == num)
				{
					sharedSb2.Append(global1.new_texts[1058]);
				}
				if (gameState2.politics_dolshnost[7] == num)
				{
					sharedSb2.Append(global1.new_texts[1059]);
				}
			}
			else
			{
				sharedSb2.Append(global1.new_texts[1071]);
				for (int m = 0; m < traits.Length; m++)
				{
					traits[m].text = traits_ru[gameState2.leader.traits[m]];
				}
				sharedSb2.Append(global1.new_texts[1050]);
				if (gameState2.politics_dolshnost[0] == num)
				{
					sharedSb2.Append(global1.new_texts[1051]);
				}
				if (gameState2.politics_dolshnost[1] == num)
				{
					sharedSb2.Append(global1.new_texts[1052]);
				}
				if (gameState2.politics_dolshnost[2] == num)
				{
					sharedSb2.Append(global1.new_texts[1053]);
				}
				sharedSb2.Append(global1.new_texts[1054]);
				if (gameState2.politics_dolshnost[3] == num)
				{
					sharedSb2.Append(global1.new_texts[1055]);
				}
				if (gameState2.politics_dolshnost[4] == num)
				{
					sharedSb2.Append(global1.new_texts[1056]);
				}
				if (gameState2.politics_dolshnost[5] == num)
				{
					sharedSb2.Append(global1.new_texts[1057]);
				}
				if (gameState2.politics_dolshnost[6] == num)
				{
					sharedSb2.Append(global1.new_texts[1058]);
				}
				if (gameState2.politics_dolshnost[7] == num)
				{
					sharedSb2.Append(global1.new_texts[1059]);
				}
			}
			string text2 = sharedSb2.ToString();
			t_zagovor.text = Text(text2, 30);
		}
		else
		{
			buttons_obj.SetActive(value: false);
			button_lead_obj.SetActive(value: false);
			name_pol.text = null;
			for (int n = 0; n < traits.Length; n++)
			{
				traits[n].text = null;
			}
			t_zagovor.text = null;
		}
		CoopRepaint();
	}

	public void ResetPolitics()
	{
		for (int i = 0; i < forth.Length; i++)
		{
			forth[i].this_number = GlobalScript.inst.gameState.p_forth[i];
		}
		for (int j = 0; j < third.Length; j++)
		{
			third[j].this_number = GlobalScript.inst.gameState.p_third[j];
		}
		for (int k = 0; k < second.Length; k++)
		{
			second[k].this_number = GlobalScript.inst.gameState.p_second[k];
		}
		for (int l = 0; l < first.Length; l++)
		{
			first[l].this_number = GlobalScript.inst.gameState.p_first[l];
		}
		RepaintAll();
	}

	private void Start()
	{
		global1 = GlobalScript.inst;
		ResetPolitics();
	}

	public void RepaintAll()
	{
		for (int i = 0; i < forth.Length; i++)
		{
			forth[i].Repaint();
		}
		for (int j = 0; j < third.Length; j++)
		{
			third[j].Repaint();
		}
		for (int k = 0; k < second.Length; k++)
		{
			second[k].Repaint();
		}
		for (int l = 0; l < first.Length; l++)
		{
			first[l].Repaint();
		}
	}

	public void RepaintOnlyShkal()
	{
		for (int i = 0; i < forth.Length; i++)
		{
			forth[i].RepaintShkal();
		}
		for (int j = 0; j < third.Length; j++)
		{
			third[j].RepaintShkal();
		}
		for (int k = 0; k < second.Length; k++)
		{
			second[k].RepaintShkal();
		}
		for (int l = 0; l < first.Length; l++)
		{
			first[l].RepaintShkal();
		}
	}

	private string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
