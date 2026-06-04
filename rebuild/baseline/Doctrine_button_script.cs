using UnityEngine;

public class Doctrine_button_script : MonoBehaviour
{
	public Sprite usl_off;

	public Sprite usl_on;

	private bool is_active;

	public TextMesh opisannya;

	private string fake_text;

	public GameObject[] uslovie = new GameObject[4];

	public GameObject[] playersButtons = new GameObject[5];

	private bool[] uslovie_bool = new bool[4];

	private int number_uslovie;

	private string[] uslovie_text = new string[4];

	public GlobalScript global1;

	public Doctrine_script doctr1;

	public Sprite on;

	public Sprite off;

	private int this_type = -1;

	private int this_number;

	private int number;

	private int summa;

	private int summa_3_2;

	private int player_numbeer;

	private bool neutral_leading;

	public int selected_country = -1;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			PlayerShow(show: false);
			PlayerShow(show: true);
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

	private void UpdateSecondReqForPlayers(bool en)
	{
		if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			bool secondReqForPlayers = GlobalScript.inst.gameState.GetSecondReqForPlayers();
			if (en)
			{
				uslovie_bool[2] = secondReqForPlayers;
				uslovie_text[2] = "Number of deputies from factions\n of each player For > others";
			}
			else
			{
				uslovie_bool[2] = secondReqForPlayers;
				uslovie_text[2] = "Число депутатов от фракций\n каждого игрока За > остальных";
			}
		}
	}

	public void Show(string text, int number_clone, int this_number_clone)
	{
		if (global1 == null)
		{
			global1 = GlobalScript.inst;
		}
		this_number = this_number_clone;
		number = number_clone;
		this_type = number_clone;
		GetComponent<SpriteRenderer>().sprite = off;
		base.transform.Find("Text").GetComponent<TextMesh>().text = text;
		if ((GlobalScript.inst.gameState.data[15] <= 7 || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[4])
		{
			neutral_leading = true;
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			number_uslovie = 4;
			uslovie_bool[0] = GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 50;
			uslovie_text[0] = "Money in the budget: " + Mathf.Abs((number - GlobalScript.inst.gameState.data[this_number]) * 5);
			uslovie_bool[1] = GlobalScript.inst.gameState.data[1] >= Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 300;
			uslovie_text[1] = "Party support is greater than: " + Mathf.Abs((number - GlobalScript.inst.gameState.data[this_number]) * 30);
			if (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] < 1)
			{
				if (GlobalScript.inst.gameState.data[15] <= 7 && !neutral_leading)
				{
					if (number == 10)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1) && GlobalScript.inst.gameState.data[15] != 7;
						uslovie_text[2] = "激进左派/保守派领先 + not \"New Democracy\"";
					}
					else if (number == 11)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.event_done[111] && GlobalScript.inst.gameState.science[17] && GlobalScript.inst.gameState.data[15] != 7;
						uslovie_text[2] = "OGAS已完成调研，毫无抵触 + not \"New Democracy\"";
					}
					else if (number == 12)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2;
						uslovie_text[2] = "保守派/温和派领先";
					}
					else if (number == 13)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
						uslovie_text[2] = "温和派/改革派领先";
					}
					else if (number == 14)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "改革派/自由派领先";
					}
					else if (number == 15)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 4 && GlobalScript.inst.gameState.data[15] != 7;
						uslovie_text[2] = "自由派领先 + not \"New Democracy\"";
					}
					else if (number == 6)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0;
						uslovie_text[2] = "激进左派领先";
					}
					else if (number == 7)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2;
						uslovie_text[2] = "保守派/温和派领先";
					}
					else if (number == 8)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3;
						uslovie_text[2] = "改革派领先";
					}
					else if (number == 9)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "自由派领先";
					}
					else if (number == 16)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1;
						uslovie_text[2] = "激进左派/保守派领先";
					}
					else if (number == 17)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
						uslovie_text[2] = "激进左派/保守派/温和派/改革派领先";
					}
					else if (number == 18)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "温和派/改革派/自由派领先";
					}
					else if (number == 19)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "改革派/自由派领先";
					}
					else if (number == 20)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
						uslovie_text[2] = "激进左派/保守派/温和派/改革派领先";
					}
					else if (number == 21)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
						uslovie_text[2] = "温和派/改革派领先";
					}
					else if (number == 22)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "改革派/自由派领先";
					}
					else if (number == 23)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "自由派领先";
					}
					else if (number == 24)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0;
						uslovie_text[2] = "激进左派领先";
					}
					else if (number == 25)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1;
						uslovie_text[2] = "激进左派/保守派领先";
					}
					else if (number == 26)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
						uslovie_text[2] = "保守派/温和派/改革派领先";
					}
					else if (number == 27)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "温和派/改革派/自由派领先";
					}
					else if (number == 28)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "改革派/自由派领先";
					}
					else if (number == 29)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 4 || (GlobalScript.inst.gameState.data[14] == 0 && GlobalScript.inst.gameState.data[31] >= 700);
						uslovie_text[2] = "自由派领先/Authoritarianism plus high nationalism";
					}
					else if (number == 30)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0;
						uslovie_text[2] = "激进左派领先";
					}
					else if (number == 31)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2;
						uslovie_text[2] = "激进左派/保守派/温和派领先";
					}
					else if (number == 32)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
						uslovie_text[2] = "温和派/改革派领先";
					}
					else if (number == 33)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
						uslovie_text[2] = "改革派/自由派领先";
					}
				}
				else if (GlobalScript.inst.gameState.data[15] <= 7)
				{
					uslovie_bool[2] = !neutral_leading;
					uslovie_text[2] = "满足派不掌舵";
				}
				else
				{
					player_numbeer = GlobalScript.inst.gameState.party_number[1];
					for (int i = 0; i < GlobalScript.inst.gameState.is_party_ally.Length; i++)
					{
						if (GlobalScript.inst.gameState.is_party_ally[i] && GlobalScript.inst.gameState.is_party_enabled[i] && i != 1)
						{
							player_numbeer += GlobalScript.inst.gameState.party_number[i];
						}
					}
					summa = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4] + GlobalScript.inst.gameState.data[106];
					summa_3_2 = player_numbeer * 100 / summa;
					if (number == 10)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[52] == 34 && summa_3_2 > 66;
						uslovie_text[2] = "路线：社会主义与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 11)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.event_done[111] && GlobalScript.inst.gameState.science[17];
						uslovie_text[2] = "OGAS已完成调研，毫无抵触";
					}
					else if (number == 12)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[52] == 34 || GlobalScript.inst.gameState.data[52] == 35) && summa_3_2 > 66;
						uslovie_text[2] = "路线：社会主义/改革派与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 13)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[52] == 35 || GlobalScript.inst.gameState.data[52] == 36) && summa_3_2 > 66;
						uslovie_text[2] = "路线：改革派/务实派与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 14)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[52] == 36 || GlobalScript.inst.gameState.data[52] == 37) && summa_3_2 > 66;
						uslovie_text[2] = "路线：务实派/市场化与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 15)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[52] == 37 && summa_3_2 > 66;
						uslovie_text[2] = "路线：市场化与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 6)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
						uslovie_text[2] = "路线：威权/强硬与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 7)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40) && summa_3_2 > 66;
						uslovie_text[2] = "路线：强硬/强硬与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 8)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
						uslovie_text[2] = "路线：温和/民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 9)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 41 && summa_3_2 > 66;
						uslovie_text[2] = "路线：民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 16)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
						uslovie_text[2] = "路线：威权/强硬与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 17)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40) && summa_3_2 > 66;
						uslovie_text[2] = "路线：强硬/强硬与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 18)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 40 && summa_3_2 > 66;
						uslovie_text[2] = "路线：温和与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 19)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 41 && summa_3_2 > 66;
						uslovie_text[2] = "路线：民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 20)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
						uslovie_text[2] = "路线：威权/强硬与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 21)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
						uslovie_text[2] = "路线：强硬/温和/民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 22)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
						uslovie_text[2] = "路线：温和/民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 23)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 41 && summa_3_2 > 66;
						uslovie_text[2] = "路线：民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 24)
					{
						uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 38 && summa_3_2 > 66;
						uslovie_text[2] = "路线：威权与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 25)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
						uslovie_text[2] = "路线：威权/强硬与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 26)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40) && summa_3_2 > 66;
						uslovie_text[2] = "路线：强硬/强硬与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 27)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
						uslovie_text[2] = "路线：温和/民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 28)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
						uslovie_text[2] = "路线：强硬/民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 29)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && (GlobalScript.inst.gameState.data[52] == 36 || GlobalScript.inst.gameState.data[52] == 37) && summa_3_2 > 66;
						uslovie_text[2] = "路线：威权/强硬与 Pragmatic/Market and ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 30)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
						uslovie_text[2] = "路线：威权/强硬与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 31)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
						uslovie_text[2] = "路线：威权/民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 32)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
						uslovie_text[2] = "路线：温和/民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
					else if (number == 33)
					{
						uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
						uslovie_text[2] = "路线：强硬/温和/民主与 ";
						uslovie_text[2] += "我们的联盟在全国人大席位超过66%";
					}
				}
			}
			else if (neutral_leading)
			{
				uslovie_bool[2] = !neutral_leading;
				uslovie_text[2] = "满足派不掌舵";
			}
			else
			{
				UpdateSecondReqForPlayers(en: true);
				PlayerShow(show: true);
			}
			if (GlobalScript.inst.gameState.data[38] >= 100)
			{
				uslovie_bool[3] = GlobalScript.inst.gameState.data[this_number] != number;
				uslovie_text[3] = "尚未建立";
			}
			else
			{
				uslovie_bool[3] = GlobalScript.inst.gameState.data[38] >= 100;
				uslovie_text[3] = "毛主席死了，起锚！";
			}
			return;
		}
		number_uslovie = 4;
		uslovie_bool[0] = GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 50;
		uslovie_text[0] = "Денег в бюджете: " + Mathf.Abs((number - GlobalScript.inst.gameState.data[this_number]) * 5);
		uslovie_bool[1] = GlobalScript.inst.gameState.data[1] >= Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 300;
		uslovie_text[1] = "Поддержка в Партии больше, чем: " + Mathf.Abs((number - GlobalScript.inst.gameState.data[this_number]) * 30);
		if (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] < 1)
		{
			if (GlobalScript.inst.gameState.data[15] <= 7 && !neutral_leading)
			{
				if (number == 10)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1) && GlobalScript.inst.gameState.data[15] != 7;
					uslovie_text[2] = "Леворадикалы/консерваторы лидируют + не \"Новая демократия\"";
				}
				else if (number == 11)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.event_done[111] && GlobalScript.inst.gameState.science[17] && GlobalScript.inst.gameState.data[15] != 7;
					uslovie_text[2] = "ОГАС изучен и никто не сопротивляется + не \"Новая демократия\"";
				}
				else if (number == 12)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2;
					uslovie_text[2] = "Консерваторы/умеренные лидируют";
				}
				else if (number == 13)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
					uslovie_text[2] = "Умеренные/реформаторы лидируют";
				}
				else if (number == 14)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Реформаторы/либералы лидируют";
				}
				else if (number == 15)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 4 && GlobalScript.inst.gameState.data[15] != 7;
					uslovie_text[2] = "Либералы лидируют + не \"Новая демократия\"";
				}
				else if (number == 6)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0;
					uslovie_text[2] = "Леворадикалы лидируют";
				}
				else if (number == 7)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2;
					uslovie_text[2] = "Консерваторы/умеренные лидируют";
				}
				else if (number == 8)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3;
					uslovie_text[2] = "Реформаторы лидируют";
				}
				else if (number == 9)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Либералы лидируют";
				}
				else if (number == 16)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1;
					uslovie_text[2] = "Леворадикалы/консерваторы лидируют";
				}
				else if (number == 17)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
					uslovie_text[2] = "Леворадикалы/консерваторы/ умеренные/реформаторы лидируют";
				}
				else if (number == 18)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Умеренные/реформаторы/ либералы лидируют";
				}
				else if (number == 19)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Реформаторы/либералы лидируют";
				}
				else if (number == 20)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
					uslovie_text[2] = "Леворадикалы/умеренные/ консерваторы/реформаторы лидируют";
				}
				else if (number == 21)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
					uslovie_text[2] = "Умеренные/реформаторы лидируют";
				}
				else if (number == 22)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Реформаторы/либералы лидируют";
				}
				else if (number == 23)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Либералы лидируют";
				}
				else if (number == 24)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0;
					uslovie_text[2] = "Леворадикалы лидируют";
				}
				else if (number == 25)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1;
					uslovie_text[2] = "Леворадикалы/консерваторы лидируют";
				}
				else if (number == 26)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
					uslovie_text[2] = "Консерваторы/умеренные/ реформаторы лидируют";
				}
				else if (number == 27)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Умеренные/реформаторы/либералы лидируют";
				}
				else if (number == 28)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Реформаторы/либералы лидируют";
				}
				else if (number == 29)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 4 || (GlobalScript.inst.gameState.data[14] == 0 && GlobalScript.inst.gameState.data[31] >= 700);
					uslovie_text[2] = "Либералы лидируют/Авторитаризм плюс высокий национализм";
				}
				else if (number == 30)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0;
					uslovie_text[2] = "Леворадикалы лидируют";
				}
				else if (number == 31)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 0 || GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2;
					uslovie_text[2] = "Леворадикалы/консерваторы/ умеренные лидируют";
				}
				else if (number == 32)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3;
					uslovie_text[2] = "Умеренные/реформаторы лидируют";
				}
				else if (number == 33)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[56] == 3 || GlobalScript.inst.gameState.data[56] == 4;
					uslovie_text[2] = "Реформаторы/либералы лидируют";
				}
			}
			else if (GlobalScript.inst.gameState.data[15] <= 7)
			{
				uslovie_bool[2] = !neutral_leading;
				uslovie_text[2] = "Удовлетворённые не лидируют";
			}
			else
			{
				player_numbeer = GlobalScript.inst.gameState.party_number[1];
				for (int j = 0; j < GlobalScript.inst.gameState.is_party_ally.Length; j++)
				{
					if (GlobalScript.inst.gameState.is_party_ally[j] && GlobalScript.inst.gameState.is_party_enabled[j] && j != 1)
					{
						player_numbeer += GlobalScript.inst.gameState.party_number[j];
					}
				}
				summa = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4] + GlobalScript.inst.gameState.data[106];
				summa_3_2 = player_numbeer * 100 / summa;
				if (number == 10)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[52] == 34 && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Социалистическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 11)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.event_done[111] && GlobalScript.inst.gameState.science[17];
					uslovie_text[2] = "ОГАС изучен и никто не сопротивляется";
				}
				else if (number == 12)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[52] == 34 || GlobalScript.inst.gameState.data[52] == 35) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Социалистическая/Реформаторская и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 13)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[52] == 35 || GlobalScript.inst.gameState.data[52] == 36) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Реформаторская/Прагматичная и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 14)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[52] == 36 || GlobalScript.inst.gameState.data[52] == 37) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Прагматичная/Рыночная и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 15)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[52] == 37 && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Рыночная и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 6)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Авторитарная/Жёсткая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 7)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Жёсткая/Мягкая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 8)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Мягкая/Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 9)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 41 && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 16)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Авторитарная/Жёсткая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 17)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Жёсткая/Мягкая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 18)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 40 && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Мягкая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 19)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 41 && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 20)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Авторитарная/Жёсткая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 21)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Жёсткая/Мягкая /Демократическая  и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 22)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Мягкая/Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 23)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 41 && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 24)
				{
					uslovie_bool[2] = GlobalScript.inst.gameState.data[54] == 38 && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Авторитарная и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 25)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Авторитарная/Жёсткая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 26)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Жёсткая/Мягкая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 27)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Мягкая/Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 28)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Жёсткая/Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 29)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && (GlobalScript.inst.gameState.data[52] == 36 || GlobalScript.inst.gameState.data[52] == 37) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Авторитарная/Жёсткая и Прагматичная/Рыночная и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 30)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 39) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Авторитарная/Жёсткая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 31)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 38 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Авторитарная/Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 32)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Мягкая/Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
				else if (number == 33)
				{
					uslovie_bool[2] = (GlobalScript.inst.gameState.data[54] == 39 || GlobalScript.inst.gameState.data[54] == 40 || GlobalScript.inst.gameState.data[54] == 41) && summa_3_2 > 66;
					uslovie_text[2] = "Линия партии: Жёсткая/Мягкая/Демократическая и ";
					uslovie_text[2] += "Наш альянс имеет более 66% мест в ВСНП";
				}
			}
		}
		else if (neutral_leading)
		{
			uslovie_bool[2] = !neutral_leading;
			uslovie_text[2] = "Удовлетворённые не лидируют";
		}
		else
		{
			UpdateSecondReqForPlayers(en: false);
			PlayerShow(show: true);
		}
		if (GlobalScript.inst.gameState.data[38] >= 100)
		{
			uslovie_bool[3] = GlobalScript.inst.gameState.data[this_number] != number;
			uslovie_text[3] = "Не установлена";
		}
		else
		{
			uslovie_bool[3] = GlobalScript.inst.gameState.data[38] >= 100;
			uslovie_text[3] = "Мао мёртв, отдать швартовы!";
		}
	}

	private void OnMouseDown()
	{
		if (number_uslovie != 0 && (number_uslovie != 1 || !uslovie_bool[0]) && (number_uslovie != 2 || !uslovie_bool[0] || !uslovie_bool[1]) && (number_uslovie != 3 || !uslovie_bool[0] || !uslovie_bool[1] || !uslovie_bool[2]) && (number_uslovie != 4 || !uslovie_bool[0] || !uslovie_bool[1] || !uslovie_bool[2] || !uslovie_bool[3]))
		{
			return;
		}
		if (this_number == 16)
		{
			GlobalScript.inst.gameState.data[5] -= Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 50;
			if (GlobalScript.inst.gameState.data[this_number] <= 12 && number >= 13 && GlobalScript.inst.gameState.data[89] < 2)
			{
				GlobalScript.inst.gameState.data[89] = 2;
			}
			else if (GlobalScript.inst.gameState.data[this_number] <= 12 && number >= 13 && GlobalScript.inst.gameState.data[60] < 1)
			{
				GlobalScript.inst.gameState.allcountries[20].Torg = false;
				GlobalScript.inst.gameState.allcountries[20].proprc = false;
			}
		}
		if (this_number == 15)
		{
			if (GlobalScript.inst.gameState.data[this_number] >= 6 && GlobalScript.inst.gameState.data[this_number] <= 7 && number >= 8 && number <= 9)
			{
				int num = 0;
				for (int i = 0; i < GlobalScript.inst.gameState.is_party_ally.Length; i++)
				{
					if (GlobalScript.inst.gameState.is_party_ally[i] && i != 1)
					{
						GlobalScript.inst.gameState.is_party_ally[i] = false;
					}
					if (GlobalScript.inst.gameState.party_ideology[i] < 0)
					{
						GlobalScript.inst.gameState.party_ideology[i] = 0;
					}
					if (GlobalScript.inst.gameState.is_party_enabled[i] && i != 1 && GlobalScript.inst.gameState.party_number[i] > 0)
					{
						num += GlobalScript.inst.gameState.party_number[i] / 2;
						GlobalScript.inst.gameState.party_number[i] -= GlobalScript.inst.gameState.party_number[i] / 2;
						GlobalScript.inst.gameState.party_ideology[i] -= GlobalScript.inst.gameState.party_number[i] / 2;
						num += GlobalScript.inst.gameState.party_number[i] / 4;
						GlobalScript.inst.gameState.party_number[i] -= GlobalScript.inst.gameState.party_number[i] / 4;
						GlobalScript.inst.gameState.party_ideology[i] -= GlobalScript.inst.gameState.party_number[i] / 4;
					}
					else if (!GlobalScript.inst.gameState.is_party_enabled[i])
					{
						GlobalScript.inst.gameState.is_party_enabled[i] = true;
					}
					GlobalScript.inst.gameState.data[53] = 0;
				}
				GlobalScript.inst.gameState.party_number[1] += num;
				GlobalScript.inst.gameState.party_ideology[1] += num;
				GlobalScript.inst.gameState.data[125] = 0;
			}
			else if (GlobalScript.inst.gameState.data[this_number] >= 8 && GlobalScript.inst.gameState.data[this_number] <= 9 && number >= 6 && number <= 7)
			{
				for (int j = 0; j < GlobalScript.inst.gameState.is_party_ally.Length; j++)
				{
					if (GlobalScript.inst.gameState.is_party_ally[j] && j != 1)
					{
						GlobalScript.inst.gameState.is_party_ally[j] = false;
					}
					if (!GlobalScript.inst.gameState.is_party_enabled[j])
					{
						GlobalScript.inst.gameState.is_party_enabled[j] = true;
						if (GlobalScript.inst.gameState.party_number[j] <= 5)
						{
							int num2 = Random.Range(0, 10);
							GlobalScript.inst.gameState.party_number[j] = 10 + num2;
							GlobalScript.inst.gameState.party_ideology[j] = GlobalScript.inst.gameState.party_number[j];
						}
					}
					else
					{
						GlobalScript.inst.gameState.party_number[j] = GlobalScript.inst.gameState.party_ideology[j];
					}
				}
				GlobalScript.inst.gameState.is_party_enabled[4] = false;
				GlobalScript.inst.gameState.party_number[4] = 0;
				GlobalScript.inst.gameState.party_number[3] += GlobalScript.inst.gameState.party_ideology[4];
				GlobalScript.inst.gameState.data[53] = 0;
			}
		}
		GlobalScript.inst.gameState.data[8] -= Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 50;
		if (this_number == 15)
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 0)
				{
					politic.loyality += (GlobalScript.inst.gameState.data[15] - number) * 150;
				}
				else if (politic.traits[0] <= 2 && number >= 7)
				{
					politic.loyality += (GlobalScript.inst.gameState.data[15] - number) * 150;
				}
				else if (politic.traits[0] <= 2 && number <= 7)
				{
					politic.loyality += (number - GlobalScript.inst.gameState.data[15]) * 150;
				}
				else
				{
					politic.loyality += (number - GlobalScript.inst.gameState.data[15]) * 150;
				}
			}
		}
		if (this_number == 16)
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] == 0)
				{
					politic2.loyality += (GlobalScript.inst.gameState.data[16] - number) * 150;
				}
				else if (politic2.traits[0] == 1 && number >= 13)
				{
					politic2.loyality += (GlobalScript.inst.gameState.data[16] - number) * 150;
				}
				else if (politic2.traits[0] == 1 && number <= 13)
				{
					politic2.loyality += (number - GlobalScript.inst.gameState.data[16]) * 150;
				}
				else
				{
					politic2.loyality += (number - GlobalScript.inst.gameState.data[16]) * 150;
				}
			}
		}
		if (this_number == 17)
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic3 in politics)
			{
				if (politic3.traits[0] == 0)
				{
					politic3.loyality += (GlobalScript.inst.gameState.data[17] - number) * 50;
				}
				else if (politic3.traits[0] == 1 && number >= 18)
				{
					politic3.loyality += (GlobalScript.inst.gameState.data[17] - number) * 50;
				}
				else if (politic3.traits[0] == 1 && number <= 18)
				{
					politic3.loyality += (number - GlobalScript.inst.gameState.data[17]) * 50;
				}
				else
				{
					politic3.loyality += (number - GlobalScript.inst.gameState.data[17]) * 50;
				}
			}
		}
		if (this_number == 18)
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic4 in politics)
			{
				if (politic4.traits[0] == 0 || politic4.traits[0] == 2)
				{
					politic4.loyality += (GlobalScript.inst.gameState.data[18] - number) * 50;
				}
				else if (politic4.traits[0] == 1 && number >= 21)
				{
					politic4.loyality += (GlobalScript.inst.gameState.data[18] - number) * 50;
				}
				else if (politic4.traits[0] == 1 && number <= 21)
				{
					politic4.loyality += (number - GlobalScript.inst.gameState.data[18]) * 50;
				}
				else
				{
					politic4.loyality += (number - GlobalScript.inst.gameState.data[18]) * 50;
				}
			}
		}
		if (this_number == 50)
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic5 in politics)
			{
				if (politic5.traits[0] == 0 || politic5.traits[0] == 2)
				{
					politic5.loyality += (GlobalScript.inst.gameState.data[50] - number) * 50;
				}
				else if (politic5.traits[0] == 1 && number >= 27)
				{
					politic5.loyality += (GlobalScript.inst.gameState.data[50] - number) * 50;
				}
				else if (politic5.traits[0] == 1 && number <= 27)
				{
					politic5.loyality += (number - GlobalScript.inst.gameState.data[50]) * 50;
				}
				else
				{
					politic5.loyality += (number - GlobalScript.inst.gameState.data[50]) * 50;
				}
			}
		}
		if (this_number == 51)
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic6 in politics)
			{
				if (politic6.traits[0] == 0 || politic6.traits[0] == 2)
				{
					politic6.loyality += (GlobalScript.inst.gameState.data[51] - number) * 50;
				}
				else if (politic6.traits[0] == 1 && number >= 32)
				{
					politic6.loyality += (GlobalScript.inst.gameState.data[51] - number) * 50;
				}
				else if (politic6.traits[0] == 1 && number <= 32)
				{
					politic6.loyality += (number - GlobalScript.inst.gameState.data[51]) * 50;
				}
				else
				{
					politic6.loyality += (number - GlobalScript.inst.gameState.data[51]) * 50;
				}
			}
		}
		if (this_number == 15)
		{
			if (GlobalScript.inst.gameState.data[this_number] < number)
			{
				GlobalScript.inst.gameState.data[6] -= (number - GlobalScript.inst.gameState.data[this_number]) * 60;
				GlobalScript.inst.gameState.data[55] += (number - GlobalScript.inst.gameState.data[this_number]) * 100;
			}
			else if (GlobalScript.inst.gameState.data[this_number] > number)
			{
				GlobalScript.inst.gameState.data[6] -= (number - GlobalScript.inst.gameState.data[this_number]) * 60;
				GlobalScript.inst.gameState.data[55] += (number - GlobalScript.inst.gameState.data[this_number]) * 100;
			}
		}
		else if (this_number == 16)
		{
			if (GlobalScript.inst.gameState.data[this_number] < number)
			{
				GlobalScript.inst.gameState.data[6] -= (number - GlobalScript.inst.gameState.data[this_number]) * 40;
				GlobalScript.inst.gameState.data[33] += (number - GlobalScript.inst.gameState.data[this_number]) * 100;
			}
			else if (GlobalScript.inst.gameState.data[this_number] > number)
			{
				GlobalScript.inst.gameState.data[6] -= (number - GlobalScript.inst.gameState.data[this_number]) * 40;
				GlobalScript.inst.gameState.data[33] += (number - GlobalScript.inst.gameState.data[this_number]) * 100;
			}
		}
		else if (GlobalScript.inst.gameState.data[this_number] < number)
		{
			GlobalScript.inst.gameState.data[6] -= (number - GlobalScript.inst.gameState.data[this_number]) * 20;
			GlobalScript.inst.gameState.data[55] += (number - GlobalScript.inst.gameState.data[this_number]) * 50;
		}
		else if (GlobalScript.inst.gameState.data[this_number] > number)
		{
			GlobalScript.inst.gameState.data[6] -= (number - GlobalScript.inst.gameState.data[this_number]) * 20;
			GlobalScript.inst.gameState.data[55] += (number - GlobalScript.inst.gameState.data[this_number]) * 50;
		}
		if (GlobalScript.inst.gameState.data[33] <= 250)
		{
			GlobalScript.inst.gameState.data[52] = 34;
		}
		else if (GlobalScript.inst.gameState.data[33] <= 500)
		{
			GlobalScript.inst.gameState.data[52] = 35;
		}
		else if (GlobalScript.inst.gameState.data[33] <= 750)
		{
			GlobalScript.inst.gameState.data[52] = 36;
		}
		else
		{
			GlobalScript.inst.gameState.data[52] = 37;
		}
		if (GlobalScript.inst.gameState.data[55] <= 250)
		{
			GlobalScript.inst.gameState.data[54] = 38;
		}
		else if (GlobalScript.inst.gameState.data[55] <= 500)
		{
			GlobalScript.inst.gameState.data[54] = 39;
		}
		else if (GlobalScript.inst.gameState.data[55] <= 750)
		{
			GlobalScript.inst.gameState.data[54] = 40;
		}
		else
		{
			GlobalScript.inst.gameState.data[54] = 41;
		}
		if (GlobalScript.inst.gameState.data[15] < 8)
		{
			GlobalScript.inst.gameState.data[1] -= Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 30;
			GlobalScript.inst.gameState.data[4] += Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 10;
		}
		else
		{
			GlobalScript.inst.gameState.data[4] += Mathf.Abs(number - GlobalScript.inst.gameState.data[this_number]) * 20;
		}
		if (this_number != 51)
		{
			GlobalScript.inst.gameState.data[92] += (number - GlobalScript.inst.gameState.data[this_number]) * 15;
		}
		GlobalScript.inst.gameState.data[this_number] = number;
		int num3 = GlobalScript.inst.gameState.data[16] - 9 + (GlobalScript.inst.gameState.data[15] - 5) + (GlobalScript.inst.gameState.data[17] - 15) + (GlobalScript.inst.gameState.data[50] - 23) + (GlobalScript.inst.gameState.data[18] + GlobalScript.inst.gameState.data[51] - 48) / 2;
		if (GlobalScript.inst.gameState.data[16] == 11)
		{
			num3++;
		}
		else if (GlobalScript.inst.gameState.data[16] == 10)
		{
			num3 += 2;
		}
		if ((num3 <= 6 || (num3 <= 7 && GlobalScript.inst.gameState.data[16] <= 11) || (num3 <= 9 && GlobalScript.inst.gameState.modifies[40].active)) && GlobalScript.inst.gameState.data[17] < 18)
		{
			GlobalScript.inst.gameState.data[14] = 0;
		}
		else if (num3 <= 9 && GlobalScript.inst.gameState.data[16] <= 11)
		{
			GlobalScript.inst.gameState.data[14] = 1;
		}
		else if (num3 <= 11)
		{
			GlobalScript.inst.gameState.data[14] = 2;
		}
		else if (num3 <= 15 && GlobalScript.inst.gameState.data[16] > 11)
		{
			GlobalScript.inst.gameState.data[14] = 3;
		}
		else if (num3 <= 20 && GlobalScript.inst.gameState.data[16] > 11)
		{
			GlobalScript.inst.gameState.data[14] = 4;
		}
		else if (GlobalScript.inst.gameState.data[16] > 11)
		{
			GlobalScript.inst.gameState.data[14] = 5;
		}
		else
		{
			GlobalScript.inst.gameState.data[14] = 2;
		}
		if (GlobalScript.inst.gameState.data[15] <= 6 && GlobalScript.inst.gameState.data[16] >= 14 && GlobalScript.inst.gameState.data[17] <= 16 && GlobalScript.inst.gameState.data[18] <= 20 && (GlobalScript.inst.gameState.data[50] <= 24 || GlobalScript.inst.gameState.data[50] >= 29) && (GlobalScript.inst.gameState.data[51] <= 31 || GlobalScript.inst.gameState.data[51] >= 33))
		{
			GlobalScript.inst.gameState.data[14] = 0;
		}
		GlobalScript.inst.gameState.allcountries[1].SubGosstroy = GlobalScript.inst.gameState.ChineseSubGosstroy();
		if (GlobalScript.inst.gameState.data[15] <= 7)
		{
			GlobalScript.inst.gameState.data[106] += GlobalScript.inst.gameState.party_ideology[GlobalScript.inst.gameState.data[56]] / 4;
			if (GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 0;
			}
			else if (GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 1;
			}
			else if (GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 2;
			}
			else if (GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 3;
			}
			else if (GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 4;
			}
		}
		else
		{
			GlobalScript.inst.gameState.data[106] += GlobalScript.inst.gameState.party_number[1] / 4;
			int num4 = GlobalScript.inst.gameState.party_number[1];
			for (int l = 0; l < GlobalScript.inst.gameState.is_party_ally.Length; l++)
			{
				if (GlobalScript.inst.gameState.is_party_ally[l] && GlobalScript.inst.gameState.is_party_enabled[l] && l != 1)
				{
					num4 += GlobalScript.inst.gameState.party_number[l];
				}
			}
			if (num4 >= GlobalScript.inst.gameState.party_number[0] && num4 >= GlobalScript.inst.gameState.party_number[2] && num4 >= GlobalScript.inst.gameState.party_number[3] && num4 >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 1;
			}
			else if (!GlobalScript.inst.gameState.is_party_ally[0] && GlobalScript.inst.gameState.is_party_enabled[0] && num4 <= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 0;
			}
			else if (!GlobalScript.inst.gameState.is_party_ally[2] && GlobalScript.inst.gameState.is_party_enabled[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[0] && num4 <= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 2;
			}
			else if (!GlobalScript.inst.gameState.is_party_ally[3] && GlobalScript.inst.gameState.is_party_enabled[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[2] && num4 <= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 3;
			}
			else if (!GlobalScript.inst.gameState.is_party_ally[4] && GlobalScript.inst.gameState.is_party_enabled[4] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[3] && num4 <= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 4;
			}
		}
		GameObject.Find("Kr").GetComponent<Crushok_politic>().Repaint();
		for (int m = 1; m <= 5; m++)
		{
			GameObject.Find("派系（）" + m + ")").transform.Find("Text").GetComponent<Politic_party_name_show>().Repaint();
			GameObject.Find("派系（）" + m + ")").transform.Find("Znack").GetComponent<Party_ally_script>().Repaint();
			if (m != 1)
			{
				GameObject.Find("派系（）" + m + ")").transform.Find("Znakc（1）").GetComponent<Party_zapret>().Repaint();
			}
		}
		for (int n = 0; n < 4; n++)
		{
			uslovie[n].GetComponent<TextMesh>().text = null;
			uslovie[n].transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			uslovie[n].transform.Find("If (1)").GetComponent<SpriteRenderer>().sprite = null;
		}
		PlayerShow(show: false);
		doctr1.ShowHideOcno();
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
		if (PlayerPrefs.GetInt("language") == 0)
		{
			UpdateSecondReqForPlayers(en: true);
			if (number == 10)
			{
				fake_text = "照着苏联来。国家对经济实行全面控制，\n经济按五年计划运行。";
			}
			else if (number == 11)
			{
				fake_text = "把控制权交给计算机……\n这是个前景可观、但风险极大的主意：\n能壮大经济，却会剥夺你来自官僚体系的支持。";
			}
			else if (number == 12)
			{
				fake_text = "允许企业自治、支持民间主动性，不会损害社会主义——因为国家仍\n是唯一的垄断者。";
			}
			else if (number == 13)
			{
				fake_text = "市场这只鸟，必须在国家的社会主义笼子里长大！";
			}
			else if (number == 14)
			{
				fake_text = "把经济的一部分交给私人也无妨。\n主要资产仍由国家掌握。";
			}
			else if (number == 15)
			{
				fake_text = "我们承认指令控制体系效率低下，把经济管理交给私人所有者。\n市场来管我们！";
			}
			else if (number == 6)
			{
				fake_text = "只有把人民从封建枷锁中解放出来的共产党，才有存在的权利！";
			}
			else if (number == 7)
			{
				fake_text = "我们的党是社会的领导力量，是进步与繁荣的先锋队。";
			}
			else if (number == 8)
			{
				fake_text = "允许其他党派存在，但其组建与经费来源受到严格监管。";
			}
			else if (number == 9)
			{
				fake_text = "照西方那套——各党平等，彼此竞争选票。";
			}
			else if (number == 16)
			{
				fake_text = "坚决制止任何与党的路线不一致的观点！";
			}
			else if (number == 17)
			{
				fake_text = "我们将尊重普遍承认的权利与自由，同时不惜一切手段捍卫我们的理\n想与价值。";
			}
			else if (number == 18)
			{
				fake_text = "只要不违法，任何观点都有存在的权利。";
			}
			else if (number == 19)
			{
				fake_text = "绝对的自由、透明与多元终于胜利了！中国终于摆脱教条！";
			}
			else if (number == 20)
			{
				fake_text = "中国领土完整不可分割。\n各族人民只享有文化自治的权利。";
			}
			else if (number == 21)
			{
				fake_text = "中国是由各省与自治体组成的联邦。\n它们享有平等权利，并拥有各自的管理机构；\n在其之上只有全国性的机构。";
			}
			else if (number == 22)
			{
				fake_text = "我们必须承认错误，找到各方统一的新路。\n由平等主体组成的邦联，是最简单的解决办法。";
			}
			else if (number == 23)
			{
				fake_text = "在超国家机构领导下的若干国家军事—政治与经济联盟。";
			}
			else if (number == 24)
			{
				fake_text = "批判孔夫子和林彪！毛主席就是这么说的！";
			}
			else if (number == 25)
			{
				fake_text = "宗教是人民的鸦片！";
			}
			else if (number == 26)
			{
				fake_text = "人民有信仰自由。然而，国家将确保宗教不被用来对抗国家。";
			}
			else if (number == 27)
			{
				fake_text = "我们并不反对宗教。只是政教分离，国家不干涉教会事务。";
			}
			else if (number == 28)
			{
				fake_text = "中国是一个有着悠久历史的伟大国家。\n尊重过去、依靠过去，我们建设未来！";
			}
			else if (number == 29)
			{
				fake_text = "教会与国家并非对立面。\n它们有共同目标，而共同目标带来共同利益……";
			}
			else if (number == 30)
			{
				fake_text = "每个中国人都是战士！一旦战争爆发，全体人民将奋起保卫祖国！";
			}
			else if (number == 31)
			{
				fake_text = "我们的军队对这样一个大国来说仍然不够强大。\n必须尽快加强！";
			}
			else if (number == 32)
			{
				fake_text = "我们不想打仗，但我们要自卫。\n因此，有必要维持一支足以保卫中国领土的军队。";
			}
			else if (number == 33)
			{
				fake_text = "全世界都开始向职业军队转型。\n我们不能落后——让我们的军队规模不大，\n但要非常强大。";
			}
		}
		else
		{
			UpdateSecondReqForPlayers(en: false);
			if (number == 10)
			{
				fake_text = "Как в Советском Союзе. Государство полностью контролирует экономику, которая работает согласно 5-ти летнему плану.";
			}
			else if (number == 11)
			{
				fake_text = "Внедрение ЭВМ и передача им управления... Перспективная, но очень рискованная идея, которая укрепит экономику, но лишит вас поддержки бюрократии.";
			}
			else if (number == 12)
			{
				fake_text = "Разрешение самоуправления предприятий и поддержка частной инициативы не повредят социализму - ведь государство остается единственной монополией.";
			}
			else if (number == 13)
			{
				fake_text = "Птица рынка должна расти в социалистической клетке государства!";
			}
			else if (number == 14)
			{
				fake_text = "Ничего страшного не будет, если передать частным лицам часть экономики. Основные активы останутся у государства.";
			}
			else if (number == 15)
			{
				fake_text = "Мы признаём неэффективность административно-командной системы и передаём управление экономикой в руки хозяина-частника. Рынок отрегулирует!";
			}
			else if (number == 6)
			{
				fake_text = "Только освободившая народ от феодализма Коммунистическая партия имеет право на существование!";
			}
			else if (number == 7)
			{
				fake_text = "Наша партия - руководящая сила общества, авангард прогресса и процветания.";
			}
			else if (number == 8)
			{
				fake_text = "Дозволяется существование других партий. Однако их создание и финансирование жёстко регулируется.";
			}
			else if (number == 9)
			{
				fake_text = "Всё как на Западе - все партии равны и должны бороться за голоса друг с другом.";
			}
			else if (number == 16)
			{
				fake_text = "Решительно пресекать любую точку зрения, несовпадающую с линией Партии!";
			}
			else if (number == 17)
			{
				fake_text = "Мы будем соблюдать общепризнанные права и свободы, защищая наши идеалы и ценности любыми доступными методами.";
			}
			else if (number == 18)
			{
				fake_text = "Право на существование имеет всякая точка зрения, если она не нарушает закон.";
			}
			else if (number == 19)
			{
				fake_text = "Абсолютная свобода, гласность и плюрализм, наконец-то, восторжествовали! Китай отныне свободен от догм!";
			}
			else if (number == 20)
			{
				fake_text = "Вся территория Китая едина и неделима. Народности имеют право лишь на культурную автономию.";
			}
			else if (number == 21)
			{
				fake_text = "Китай - федерация провинций и автономий. Они имеют равные права и собственные органы управления, выше которых только общекитайские.";
			}
			else if (number == 22)
			{
				fake_text = "Учтя свои ошибки, мы найдём новую форму объединения всех национальных образований. Конфедерация равноправных субъектов - самое простое решение";
			}
			else if (number == 23)
			{
				fake_text = "Военно-политический и экономический союз нескольких государств под руководством надгосударственных органов.";
			}
			else if (number == 24)
			{
				fake_text = "Критикуйте Конфуция и Линь Бяо! Так завещал сам Председатель Мао!";
			}
			else if (number == 25)
			{
				fake_text = "Религия - опиум для народа!";
			}
			else if (number == 26)
			{
				fake_text = "Люди вольны верить. Однако государство проконтролирует, чтобы религия не использовалась против него.";
			}
			else if (number == 27)
			{
				fake_text = "Мы вовсе не против религии. Однако Церковь у нас отделена от государства, а государство не вмешивается в дела Церкви.";
			}
			else if (number == 28)
			{
				fake_text = "Китай - великая страна с древней историей. Уважая наше прошлое и опираясь на него, мы строим наше будущее!";
			}
			else if (number == 29)
			{
				fake_text = "Церковь и государство - не антагонисты. У них общая цель, а общность цели вызывает и общность интересов...";
			}
			else if (number == 30)
			{
				fake_text = "Каждый китаец - солдат! В случае войны, весь народ поднимется на защиту Родины!";
			}
			else if (number == 31)
			{
				fake_text = "Наша армия все ещё недостаточно сильная для такой большой страны. Надо усилить её как можно быстрее!";
			}
			else if (number == 32)
			{
				fake_text = "Мы войны не хотим, но себя защитим. Поэтому необходимо поддерживать достаточную для обороны территории Китая армию.";
			}
			else if (number == 33)
			{
				fake_text = "Весь мир начинает переход на профессиональную армию. Мы не должны отставать - пусть наша армия будет небольшая, но очень сильная.";
			}
		}
		opisannya.text = Text(fake_text, 33);
		for (int i = 0; i < number_uslovie; i++)
		{
			uslovie[i].GetComponent<TextMesh>().text = Text(uslovie_text[i], 30);
			if (uslovie_bool[i])
			{
				uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = usl_on;
				uslovie[i].transform.Find("If (1)").GetComponent<SpriteRenderer>().sprite = usl_on;
			}
			else
			{
				uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = usl_off;
				uslovie[i].transform.Find("If (1)").GetComponent<SpriteRenderer>().sprite = usl_off;
			}
		}
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off;
		for (int i = 0; i < 4; i++)
		{
			uslovie[i].GetComponent<TextMesh>().text = null;
			uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			uslovie[i].transform.Find("If (1)").GetComponent<SpriteRenderer>().sprite = null;
		}
		opisannya.text = "";
	}

	private static string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
