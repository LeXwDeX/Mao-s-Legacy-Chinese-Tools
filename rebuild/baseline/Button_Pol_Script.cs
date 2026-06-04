using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Button_Pol_Script : MonoBehaviour
{
	public TextMesh text;

	public Politic_Manager manager;

	public BeurocratsScript bear1;

	public BeurocratsScript bear2;

	private GameObject achieves;

	private GameState a;

	private GlobalScript global1;

	public byte num;

	private bool enbaled;

	private bool ready;

	private OkoshkoScript okoshko;

	private SpriteRenderer spriteRenderer;

	private const int TextNeedMoney05 = 1073;

	private const int TextAutosupportCost = 1074;

	private const int TextHelmsman = 1075;

	private const int TextUnderInvestigation = 1076;

	private const int TextAutohoundCost = 1077;

	private const int TextNotFirmThriftyChinophilic = 1078;

	private const int TextNeedFiveSwiss = 1079;

	private const int TextNeedMoneyTwoAgents = 1080;

	private const int TextWaitForEvent = 1081;

	private const int TextHatedByTwo = 1082;

	private const int TextBudgetValue = 1083;

	private const int TextAgentsValue = 1084;

	private const int TextArmyValue = 1085;

	private const int TextResourcesValue = 1086;

	private const int TextTwoAgents = 1087;

	private const int TextUnderSpy = 1088;

	private const int TextThreeAgents = 1089;

	private const int TextAlreadyAppointed = 1090;

	private const int TextHierarchyMatch = 1091;

	private const int TextYesYouCan = 1092;

	private const int TextAgentsAndMoney = 1093;

	private const int TextIsCitizen = 1094;

	private const int TextCompareCitizens = 1095;

	private const int TextExiledForReeducation = 1096;

	private const int TextCitizenRulerAchievement = 1097;

	private string GetText(int id)
	{
		EnsureInitialized();
		if (!(global1 != null) || global1.new_texts == null)
		{
			return string.Empty;
		}
		return global1.new_texts[id].Replace("\\n", "\n");
	}

	private string FormatText(int id, object arg)
	{
		return string.Format(GetText(id), arg);
	}

	private void EnsureInitialized()
	{
		if (global1 == null)
		{
			global1 = GlobalScript.inst;
		}
		if (a == null && global1 != null)
		{
			a = global1.gameState;
		}
		if (okoshko == null)
		{
			okoshko = GetComponent<OkoshkoScript>();
		}
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
	}

	private void NeedToUpEn()
	{
		EnsureInitialized();
		OkoshkoScript okoshkoScript = okoshko ?? (okoshko = GetComponent<OkoshkoScript>());
		if (this.num == 0)
		{
			okoshkoScript.text_en = GetText(1073);
		}
		else if (this.num == 15)
		{
			okoshkoScript.text_en = GetText(1074);
		}
		else if (this.num == 16)
		{
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text_en = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else
			{
				okoshkoScript.text_en = GetText(1077);
			}
		}
		else if (this.num == 17)
		{
			if ((a.politics[manager.selected_politic].traits[1] == 4 || a.politics[manager.selected_politic].traits[2] == 14 || a.politics[manager.selected_politic].traits[2] == 11) && a.politics[manager.selected_politic].traits[2] != 18)
			{
				okoshkoScript.text_en = GetText(1078);
			}
			else
			{
				okoshkoScript.text_en = GetText(1079);
			}
		}
		else if (this.num == 1)
		{
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text_en = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else
			{
				okoshkoScript.text_en = GetText(1080);
			}
		}
		else if (this.num == 2)
		{
			int num = a.politics[manager.selected_politic].power / 10 / 10;
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text_en = GetText(1075);
			}
			else if ((manager.selected_politic <= 5 || manager.selected_politic == 7 || (manager.selected_politic >= 11 && manager.selected_politic <= 15) || manager.selected_politic == 17) && (!a.event_done[25] || a.data[84] == 3 || (manager.selected_politic >= 12 && manager.selected_politic <= 15)) && (!a.event_done[26] || (a.leader.name_1 == 0 && manager.selected_politic != 1)) && a.data[21] < 1978 && (!a.event_done[25] || a.data[84] != 3 || (manager.selected_politic >= 1 && manager.selected_politic <= 4)))
			{
				okoshkoScript.text_en = GetText(1081);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics.Count((Politic p) => p.loyality_to_other[manager.selected_politic] < 500) <= 2)
			{
				okoshkoScript.text_en = GetText(1082);
			}
			else if (a.data[8] >= num)
			{
				okoshkoScript.text_en = FormatText(1083, num);
			}
			else if (a.data[9] >= num)
			{
				okoshkoScript.text_en = FormatText(1084, num);
			}
			else if (a.data[22] >= num)
			{
				okoshkoScript.text_en = FormatText(1085, num);
			}
			else
			{
				okoshkoScript.text_en = FormatText(1086, num);
			}
		}
		else if (this.num == 3)
		{
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text_en = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else
			{
				okoshkoScript.text_en = GetText(1087);
			}
		}
		else if (this.num == 4)
		{
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text_en = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics[manager.selected_politic].is_sleshka)
			{
				okoshkoScript.text_en = GetText(1088);
			}
			else
			{
				okoshkoScript.text_en = GetText(1089);
			}
		}
		else if (this.num == 5)
		{
			if (a.data[38] != 100)
			{
				okoshkoScript.text_en = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics_dolshnost[1] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
		else if (this.num == 6)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics_dolshnost[2] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
		else if (this.num == 7)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics_dolshnost[0] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
		else if (this.num == 8)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics_dolshnost[3] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
		else if (this.num == 9)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics_dolshnost[4] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
		else if (this.num == 10)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics_dolshnost[6] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
		else if (this.num == 11)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics_dolshnost[5] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
		else if (this.num == 12)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.politics_dolshnost[7] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
		else if (this.num == 13)
		{
			if (a.politics_dolshnost[7] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else
			{
				okoshkoScript.text_en = GetText(1092);
			}
		}
		else if (this.num == 14)
		{
			if (a.data[38] != 100)
			{
				okoshkoScript.text_en = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text_en = GetText(1076);
			}
			else if (a.faction_leader[0] == manager.selected_politic || a.faction_leader[1] == manager.selected_politic || a.faction_leader[2] == manager.selected_politic || a.faction_leader[3] == manager.selected_politic || a.faction_leader[4] == manager.selected_politic)
			{
				okoshkoScript.text_en = GetText(1090);
			}
			else if (a.data[8] < 100 || a.data[9] < 100)
			{
				okoshkoScript.text_en = GetText(1093);
			}
			else
			{
				okoshkoScript.text_en = GetText(1091);
			}
		}
	}

	private void NeedToUp()
	{
		EnsureInitialized();
		OkoshkoScript okoshkoScript = okoshko ?? (okoshko = GetComponent<OkoshkoScript>());
		if (this.num == 0)
		{
			okoshkoScript.text = GetText(1073);
		}
		else if (this.num == 15)
		{
			okoshkoScript.text = GetText(1074);
		}
		else if (this.num == 16)
		{
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else
			{
				okoshkoScript.text = GetText(1077);
			}
		}
		else if (this.num == 17)
		{
			if ((a.politics[manager.selected_politic].traits[1] == 4 || a.politics[manager.selected_politic].traits[2] == 14 || a.politics[manager.selected_politic].traits[2] == 11) && a.politics[manager.selected_politic].traits[2] != 18)
			{
				okoshkoScript.text = GetText(1078);
			}
			else
			{
				okoshkoScript.text = GetText(1079);
			}
		}
		else if (this.num == 1)
		{
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else
			{
				okoshkoScript.text = GetText(1080);
			}
		}
		else if (this.num == 2)
		{
			int num = a.politics[manager.selected_politic].power / 10 / 10;
			if (num <= 10)
			{
				num = 10;
			}
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text = GetText(1075);
			}
			else if ((manager.selected_politic <= 5 || manager.selected_politic == 7 || (manager.selected_politic >= 11 && manager.selected_politic <= 15) || manager.selected_politic == 17) && (!a.event_done[25] || a.data[84] == 3 || (manager.selected_politic >= 12 && manager.selected_politic <= 15)) && (!a.event_done[26] || (a.leader.name_1 == 0 && manager.selected_politic != 1)) && a.data[21] < 1978 && (!a.event_done[25] || a.data[84] != 3 || (manager.selected_politic >= 1 && manager.selected_politic <= 4)))
			{
				okoshkoScript.text = GetText(1081);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics.Count((Politic p) => p.loyality_to_other[manager.selected_politic] < 500) <= 2)
			{
				okoshkoScript.text = GetText(1082);
			}
			else if (a.data[8] >= num)
			{
				okoshkoScript.text = FormatText(1083, num);
			}
			else if (a.data[9] >= num)
			{
				okoshkoScript.text = FormatText(1084, num);
			}
			else if (a.data[22] >= num)
			{
				okoshkoScript.text = FormatText(1085, num);
			}
			else
			{
				okoshkoScript.text = FormatText(1086, num);
			}
		}
		else if (this.num == 3)
		{
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else
			{
				okoshkoScript.text = GetText(1087);
			}
		}
		else if (this.num == 4)
		{
			if (a.data[38] != 100 && manager.selected_politic == 0)
			{
				okoshkoScript.text = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics[manager.selected_politic].is_sleshka)
			{
				okoshkoScript.text = GetText(1088);
			}
			else
			{
				okoshkoScript.text = GetText(1089);
			}
		}
		else if (this.num == 5)
		{
			if (a.data[38] != 100)
			{
				okoshkoScript.text = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics_dolshnost[1] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
		else if (this.num == 6)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics_dolshnost[2] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
		else if (this.num == 7)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics_dolshnost[0] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
		else if (this.num == 8)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics_dolshnost[3] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
		else if (this.num == 9)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics_dolshnost[4] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
		else if (this.num == 10)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics_dolshnost[6] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
		else if (this.num == 11)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics_dolshnost[5] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
		else if (this.num == 12)
		{
			if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.politics_dolshnost[7] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
		else if (this.num == 13)
		{
			okoshkoScript.text = GetText(1092);
		}
		else if (this.num == 14)
		{
			if (a.data[38] != 100)
			{
				okoshkoScript.text = GetText(1075);
			}
			else if (a.politics[manager.selected_politic].is_sledstvie)
			{
				okoshkoScript.text = GetText(1076);
			}
			else if (a.faction_leader[0] == manager.selected_politic || a.faction_leader[1] == manager.selected_politic || a.faction_leader[2] == manager.selected_politic || a.faction_leader[3] == manager.selected_politic || a.faction_leader[4] == manager.selected_politic)
			{
				okoshkoScript.text = GetText(1090);
			}
			else if (a.data[8] < 100 || a.data[9] < 100)
			{
				okoshkoScript.text = GetText(1093);
			}
			else
			{
				okoshkoScript.text = GetText(1091);
			}
		}
	}

	private void FixedUpdate()
	{
		EnsureInitialized();
		if (GlobalScript.inst.dlc[0] && a.gamerules[1] > 0 && ((num >= 5 && num <= 12) || num == 2 || num == 17))
		{
			if (a.GetSecondReqForPlayers() && !ready)
			{
				ready = true;
				Repaint();
			}
			else if (!a.GetSecondReqForPlayers() && ready)
			{
				ready = false;
				Repaint();
			}
		}
	}

	public void Repaint()
	{
		EnsureInitialized();
		if (a.gamerules[8] == 3 && this.num >= 5 && this.num <= 12)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		if (achieves == null)
		{
			achieves = GameObject.Find("Ach(Clone)");
		}
		int num = 1;
		for (int i = 0; i < a.p_forth.Length; i++)
		{
			if (a.p_forth[i] == manager.selected_politic)
			{
				num = 4;
				break;
			}
		}
		for (int j = 0; j < a.p_third.Length; j++)
		{
			if (a.p_third[j] == manager.selected_politic)
			{
				num = 3;
				break;
			}
		}
		switch (this.num)
		{
		case 0:
			enbaled = a.data[8] + a.data[36] >= 1 && a.data[9] >= 5 && !a.politics[manager.selected_politic].is_sledstvie;
			break;
		case 1:
			enbaled = a.data[8] + a.data[36] >= 1 && a.data[9] >= 20 && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2) && (a.data[38] == 100 || manager.selected_politic != 0);
			break;
		case 15:
			enbaled = a.politics[manager.selected_politic].autosupport == 10 || (a.data[8] + a.data[36] >= 1 && a.data[9] >= 5 && !a.politics[manager.selected_politic].is_sledstvie);
			base.gameObject.transform.GetChild(0).GetComponent<TextMesh>().color = new Color(0.04f, a.politics[manager.selected_politic].autosupport, 0f);
			break;
		case 16:
			enbaled = a.politics[manager.selected_politic].autohound == 10 || (a.data[8] + a.data[36] >= 1 && a.data[9] >= 20 && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2) && (a.data[38] == 100 || manager.selected_politic != 0));
			base.gameObject.transform.GetChild(0).GetComponent<TextMesh>().color = new Color(0.04f, a.politics[manager.selected_politic].autohound, 0f);
			break;
		case 2:
		{
			int num2 = a.politics[manager.selected_politic].power / 10 / 10;
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics.Count((Politic p) => p.loyality_to_other[manager.selected_politic] < 500) >= 3 && a.data[8] >= num2 && a.data[9] >= num2 && a.data[22] >= num2 && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2) && ((manager.selected_politic > 5 && manager.selected_politic != 7 && (manager.selected_politic < 11 || manager.selected_politic > 15) && manager.selected_politic != 17) || (a.event_done[25] && a.data[84] != 3 && (manager.selected_politic < 12 || manager.selected_politic > 15)) || (a.event_done[26] && (a.leader.name_1 != 0 || manager.selected_politic == 1)) || a.data[21] >= 1978 || (a.event_done[25] && a.data[84] == 3 && (manager.selected_politic < 1 || manager.selected_politic > 4))) && (a.data[38] == 100 || manager.selected_politic != 0);
			break;
		}
		case 3:
			enbaled = a.data[9] >= 20 && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2) && (a.data[38] == 100 || manager.selected_politic != 0);
			break;
		case 4:
			enbaled = a.data[9] >= 30 && !a.politics[manager.selected_politic].is_sledstvie && !a.politics[manager.selected_politic].is_sleshka && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2) && (a.data[38] == 100 || manager.selected_politic != 0);
			break;
		case 5:
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics_dolshnost[1] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && (num <= 2 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2) && a.data[38] == 100;
			break;
		case 6:
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics_dolshnost[2] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && (num <= 2 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2);
			break;
		case 7:
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics_dolshnost[0] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && (num <= 2 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2);
			break;
		case 8:
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics_dolshnost[3] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2);
			break;
		case 9:
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics_dolshnost[4] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2);
			break;
		case 10:
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics_dolshnost[6] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2);
			break;
		case 11:
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics_dolshnost[5] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2);
			break;
		case 12:
			enbaled = (!GlobalScript.inst.dlc[0] || a.gamerules[1] < 1 || a.GetSecondReqForPlayers()) && a.politics_dolshnost[7] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && (num <= 3 || (a.politics[manager.selected_politic].loyality >= 700 && a.gamerules[5] == 1) || a.gamerules[5] == 2);
			break;
		case 13:
			enbaled = a.politics_dolshnost[1] != manager.selected_politic && manager.selected_politic == 150 && a.data[38] == 100;
			break;
		case 14:
			enbaled = a.data[8] + a.data[36] >= 100 && a.data[9] >= 100 && a.faction_leader[0] != manager.selected_politic && a.faction_leader[1] != manager.selected_politic && a.faction_leader[2] != manager.selected_politic && a.faction_leader[3] != manager.selected_politic && a.faction_leader[4] != manager.selected_politic && !a.politics[manager.selected_politic].is_sledstvie && num <= 2 && a.data[38] == 100;
			break;
		case 17:
			enbaled = !a.IsBankAccountFreezed && ((a.politics[manager.selected_politic].traits[1] != 4 && a.politics[manager.selected_politic].traits[2] != 14 && a.politics[manager.selected_politic].traits[2] != 11) || a.politics[manager.selected_politic].traits[2] == 18) && a.data[168] >= 50;
			break;
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			NeedToUpEn();
		}
		else
		{
			NeedToUp();
		}
		if (enbaled)
		{
			spriteRenderer.color = Color.white;
		}
		else
		{
			spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f, 1f);
		}
	}

	private void OnMouseDown()
	{
		if (enbaled)
		{
			if (this.num == 0)
			{
				a.data[8]--;
				a.data[1] -= 20;
				a.data[9] -= 5;
				a.politics[manager.selected_politic].power += (a.data[21] - 1976) * 5;
				a.politics[manager.selected_politic].loyality += 50;
				a.politics[manager.selected_politic].power += Mathf.Abs(a.politics[manager.selected_politic].power / 10);
			}
			else if (this.num == 1)
			{
				a.data[8]--;
				a.data[1] -= 20;
				a.data[9] -= 20;
				a.politics[manager.selected_politic].loyality -= 50;
				a.politics[manager.selected_politic].power -= (a.data[21] - 1976) * 5;
				a.politics[manager.selected_politic].power -= Mathf.Abs(a.politics[manager.selected_politic].power / 10);
			}
			else if (this.num == 15)
			{
				if (a.politics[manager.selected_politic].autosupport == 0)
				{
					a.politics[manager.selected_politic].autosupport = 10;
				}
				else
				{
					a.politics[manager.selected_politic].autosupport = 0;
				}
				base.gameObject.transform.GetChild(0).GetComponent<TextMesh>().color = new Color(0.04f, a.politics[manager.selected_politic].autosupport, 0f);
			}
			else if (this.num == 16)
			{
				if (a.politics[manager.selected_politic].autohound == 0)
				{
					a.politics[manager.selected_politic].autohound = 10;
				}
				else
				{
					a.politics[manager.selected_politic].autohound = 0;
				}
				base.gameObject.transform.GetChild(0).GetComponent<TextMesh>().color = new Color(0.04f, a.politics[manager.selected_politic].autohound, 0f);
			}
			else if (this.num == 2)
			{
				int num = a.politics[manager.selected_politic].power / 10 / 10;
				if (num <= 10)
				{
					num = 10;
				}
				a.data[22] -= num;
				a.data[8] -= num;
				a.data[9] -= num;
				a.data[4] += 100;
				if (a.faction_leader[0] == manager.selected_politic || a.faction_leader[1] == manager.selected_politic || a.faction_leader[2] == manager.selected_politic || a.faction_leader[3] == manager.selected_politic || a.faction_leader[4] == manager.selected_politic)
				{
					Politic[] politics = a.politics;
					foreach (Politic politic in politics)
					{
						if (politic.traits[0] == a.politics[manager.selected_politic].traits[0])
						{
							politic.loyality -= 300;
						}
					}
				}
				else
				{
					Politic[] politics = a.politics;
					foreach (Politic politic2 in politics)
					{
						if (politic2.traits[0] == a.politics[manager.selected_politic].traits[0])
						{
							politic2.loyality -= 5;
						}
					}
				}
				a.data[110]++;
				if (a.iron_and_blood && a.data[110] >= 44)
				{
					achieves.GetComponent<achievements>().Set(24);
				}
				if (a.politics_dolshnost[0] == manager.selected_politic)
				{
					a.data[114] = 9;
				}
				if (a.politics_dolshnost[1] == manager.selected_politic)
				{
					a.data[115] = 9;
				}
				if (a.politics_dolshnost[2] == manager.selected_politic)
				{
					a.data[116] = 9;
				}
				if (a.citizens != null)
				{
					Politic politic3 = a.politics[manager.selected_politic];
					Debug.Log(string.Format(GetText(1094), politic3.isCitizen));
					if (politic3.isCitizen)
					{
						string text = a.names1[politic3.name_1];
						string text2 = a.names2[politic3.name_2];
						Persona[] citizens = a.citizens;
						foreach (Persona persona in citizens)
						{
							Debug.Log(string.Format(GetText(1095), persona.name, persona.surname, text, text2));
							if (persona != null && persona.name == text && persona.surname == text2)
							{
								int[] date = new int[3]
								{
									a.data[19],
									a.data[20],
									a.data[21]
								};
								string text3 = CitizenManager.FormatLog(persona, GetText(1096), GetText(1096), date);
								persona.changeLog.Add(text3);
								Debug.Log(text3);
								persona.status = Job.Prisoned;
								persona.isPolitic = false;
							}
						}
					}
				}
				a.KillPerson(manager.selected_politic);
				manager.ResetPolitics();
			}
			else if (this.num == 3)
			{
				a.politics[manager.selected_politic].is_sledstvie = true;
				a.politics[manager.selected_politic].sled_slej = 0;
				a.data[9] -= 20;
				if (a.faction_leader[0] == manager.selected_politic || a.faction_leader[1] == manager.selected_politic || a.faction_leader[2] == manager.selected_politic || a.faction_leader[3] == manager.selected_politic || a.faction_leader[4] == manager.selected_politic)
				{
					Politic[] politics = a.politics;
					foreach (Politic politic4 in politics)
					{
						if (politic4.traits[0] == a.politics[manager.selected_politic].traits[0])
						{
							politic4.loyality -= 1000;
						}
					}
				}
				else
				{
					Politic[] politics = a.politics;
					foreach (Politic politic5 in politics)
					{
						if (politic5.traits[0] == a.politics[manager.selected_politic].traits[0])
						{
							politic5.loyality -= 100;
						}
					}
				}
				a.politics[manager.selected_politic].loyality -= 2000;
			}
			else if (this.num == 4)
			{
				a.politics[manager.selected_politic].is_sleshka = true;
				a.politics[manager.selected_politic].days_sleshka = 0;
				a.data[9] -= 30;
			}
			else if (this.num == 13)
			{
				if (a.politics_dolshnost[1] < 100)
				{
					a.politics[a.politics_dolshnost[1]].loyality -= 1000;
					a.politics[a.politics_dolshnost[1]].loyality_to_other[manager.selected_politic] -= 500;
				}
				a.politics_dolshnost[1] = manager.selected_politic;
				for (int j = 3; j < a.politics_dolshnost.Length; j++)
				{
					if (a.politics_dolshnost[j] == manager.selected_politic)
					{
						a.politics_dolshnost[j] = 200;
					}
				}
			}
			else if (this.num == 5)
			{
				if (a.politics_dolshnost[1] < 100)
				{
					a.politics[a.politics_dolshnost[1]].loyality -= 700 + ((a.politics[a.politics_dolshnost[1]].wantedDolzh == 1) ? 400 : 0);
					a.politics[a.politics_dolshnost[1]].loyality_to_other[manager.selected_politic] -= 300 + ((a.politics[a.politics_dolshnost[1]].wantedDolzh == 1) ? 400 : 0);
				}
				a.politics_dolshnost[1] = manager.selected_politic;
				a.politics[manager.selected_politic].loyality += 350;
				if (a.politics[manager.selected_politic].wantedDolzh == 1)
				{
					a.politics[manager.selected_politic].loyality += 250;
				}
				if (a.politics_dolshnost[2] == manager.selected_politic)
				{
					a.politics_dolshnost[2] = 200;
				}
				for (int k = 3; k < a.politics_dolshnost.Length; k++)
				{
					if (a.politics_dolshnost[k] == manager.selected_politic)
					{
						a.politics_dolshnost[k] = 200;
					}
				}
				if (a.politics[manager.selected_politic].isCitizen)
				{
					achieves.GetComponent<achievements>().Set(209);
				}
			}
			else if (this.num == 6)
			{
				if (a.politics_dolshnost[2] < 100)
				{
					a.politics[a.politics_dolshnost[2]].loyality -= 600 + ((a.politics[a.politics_dolshnost[2]].wantedDolzh == 2) ? 400 : 0);
					a.politics[a.politics_dolshnost[2]].loyality_to_other[manager.selected_politic] -= 250 + ((a.politics[a.politics_dolshnost[2]].wantedDolzh == 2) ? 400 : 0);
				}
				a.politics_dolshnost[2] = manager.selected_politic;
				a.politics[manager.selected_politic].loyality += 350;
				if (a.politics[manager.selected_politic].wantedDolzh == 2)
				{
					a.politics[manager.selected_politic].loyality += 250;
				}
				if (a.politics_dolshnost[1] == manager.selected_politic)
				{
					a.politics_dolshnost[1] = 200;
				}
				for (int l = 3; l < a.politics_dolshnost.Length; l++)
				{
					if (a.politics_dolshnost[l] == manager.selected_politic)
					{
						a.politics_dolshnost[l] = 200;
					}
				}
				if (a.politics[manager.selected_politic].isCitizen)
				{
					achieves.GetComponent<achievements>().Set(209);
				}
			}
			else if (this.num == 7)
			{
				if (a.politics_dolshnost[0] < 100)
				{
					a.politics[a.politics_dolshnost[0]].loyality -= 800 + ((a.politics[a.politics_dolshnost[0]].wantedDolzh == 0) ? 400 : 0);
					a.politics[a.politics_dolshnost[0]].loyality_to_other[manager.selected_politic] -= 400 + ((a.politics[a.politics_dolshnost[0]].wantedDolzh == 0) ? 400 : 0);
				}
				a.politics_dolshnost[0] = manager.selected_politic;
				a.politics[manager.selected_politic].loyality += 400;
				if (a.politics[manager.selected_politic].wantedDolzh == 0)
				{
					a.politics[manager.selected_politic].loyality += 250;
				}
				for (int m = 1; m < a.politics_dolshnost.Length; m++)
				{
					if (a.politics_dolshnost[m] == manager.selected_politic)
					{
						a.politics_dolshnost[m] = 200;
					}
				}
				if (a.politics[manager.selected_politic].isCitizen)
				{
					achieves.GetComponent<achievements>().Set(209);
				}
			}
			else if (this.num == 8)
			{
				if (a.politics_dolshnost[3] < 100)
				{
					a.politics[a.politics_dolshnost[3]].loyality -= 250 + ((a.politics[a.politics_dolshnost[3]].wantedDolzh == 3) ? 400 : 0);
					a.politics[a.politics_dolshnost[3]].loyality_to_other[manager.selected_politic] -= 50 + ((a.politics[a.politics_dolshnost[3]].wantedDolzh == 3) ? 400 : 0);
				}
				for (int n = 3; n < a.politics_dolshnost.Length; n++)
				{
					if (a.politics_dolshnost[n] == manager.selected_politic)
					{
						a.politics_dolshnost[n] = 200;
					}
				}
				a.politics_dolshnost[3] = manager.selected_politic;
				a.politics[manager.selected_politic].loyality += 300;
				if (a.politics[manager.selected_politic].wantedDolzh == 3)
				{
					a.politics[manager.selected_politic].loyality += 250;
				}
			}
			else if (this.num == 9)
			{
				if (a.politics_dolshnost[4] < 100)
				{
					a.politics[a.politics_dolshnost[4]].loyality -= 150 + ((a.politics[a.politics_dolshnost[4]].wantedDolzh == 4) ? 400 : 0);
				}
				for (int num2 = 3; num2 < a.politics_dolshnost.Length; num2++)
				{
					if (a.politics_dolshnost[num2] == manager.selected_politic)
					{
						a.politics_dolshnost[num2] = 200;
					}
				}
				a.politics_dolshnost[4] = manager.selected_politic;
				a.politics[manager.selected_politic].loyality += 250;
				if (a.politics[manager.selected_politic].wantedDolzh == 4)
				{
					a.politics[manager.selected_politic].loyality += 250;
				}
			}
			else if (this.num == 10)
			{
				if (a.politics_dolshnost[6] != 200 && a.politics_dolshnost[6] != 150)
				{
					a.politics[a.politics_dolshnost[6]].loyality -= 150 + ((a.politics[a.politics_dolshnost[6]].wantedDolzh == 6) ? 400 : 0);
				}
				for (int num3 = 3; num3 < a.politics_dolshnost.Length; num3++)
				{
					if (a.politics_dolshnost[num3] == manager.selected_politic)
					{
						a.politics_dolshnost[num3] = 200;
					}
				}
				a.politics_dolshnost[6] = manager.selected_politic;
				a.politics[manager.selected_politic].loyality += 250;
				if (a.politics[manager.selected_politic].wantedDolzh == 6)
				{
					a.politics[manager.selected_politic].loyality += 250;
				}
			}
			else if (this.num == 11)
			{
				if (a.politics_dolshnost[5] != 200 && a.politics_dolshnost[5] != 150)
				{
					a.politics[a.politics_dolshnost[5]].loyality -= 150 + ((a.politics[a.politics_dolshnost[5]].wantedDolzh == 5) ? 400 : 0);
				}
				for (int num4 = 3; num4 < a.politics_dolshnost.Length; num4++)
				{
					if (a.politics_dolshnost[num4] == manager.selected_politic)
					{
						a.politics_dolshnost[num4] = 200;
					}
				}
				a.politics_dolshnost[5] = manager.selected_politic;
				a.politics[manager.selected_politic].loyality += 250;
				if (a.politics[manager.selected_politic].wantedDolzh == 5)
				{
					a.politics[manager.selected_politic].loyality += 250;
				}
			}
			else if (this.num == 12)
			{
				if (a.politics_dolshnost[7] != 200 && a.politics_dolshnost[7] != 150)
				{
					a.politics[a.politics_dolshnost[7]].loyality -= 150 + ((a.politics[a.politics_dolshnost[7]].wantedDolzh == 7) ? 400 : 0);
				}
				for (int num5 = 3; num5 < a.politics_dolshnost.Length; num5++)
				{
					if (a.politics_dolshnost[num5] == manager.selected_politic)
					{
						a.politics_dolshnost[num5] = 200;
					}
				}
				a.politics_dolshnost[7] = manager.selected_politic;
				a.politics[manager.selected_politic].loyality += 250;
				if (a.politics[manager.selected_politic].wantedDolzh == 7)
				{
					a.politics[manager.selected_politic].loyality += 250;
				}
			}
			else if (this.num == 14)
			{
				if (a.politics[manager.selected_politic].isCitizen)
				{
					achieves.GetComponent<achievements>().Set(210);
				}
				Debug.Log(global1.new_texts[1097]);
				if (a.politics[manager.selected_politic].traits[0] > 0)
				{
					a.politics[a.faction_leader[a.politics[manager.selected_politic].traits[0] + 1]].loyality -= 1000;
					a.politics[a.faction_leader[a.politics[manager.selected_politic].traits[0] + 1]].loyality_to_other[manager.selected_politic] -= 500;
					a.faction_leader[a.politics[manager.selected_politic].traits[0] + 1] = manager.selected_politic;
				}
				else
				{
					a.politics[a.faction_leader[a.politics[manager.selected_politic].traits[0]]].loyality -= 1000;
					a.politics[a.faction_leader[a.politics[manager.selected_politic].traits[0]]].loyality_to_other[manager.selected_politic] -= 500;
					a.faction_leader[a.politics[manager.selected_politic].traits[0]] = manager.selected_politic;
				}
				Politic[] politics = a.politics;
				foreach (Politic politic6 in politics)
				{
					if (politic6.traits[0] == a.politics[manager.selected_politic].traits[0])
					{
						politic6.loyality -= 100;
					}
				}
				a.politics[manager.selected_politic].loyality += 400;
			}
			else if (this.num == 17)
			{
				a.data[168] -= 50;
				a.politics[manager.selected_politic].loyality += 100;
				Debug.LogError(a.politics[manager.selected_politic].loyality);
			}
			a.BalancePolitic(new List<byte>());
			manager.ResetPolitics();
			(okoshko ?? (okoshko = GetComponent<OkoshkoScript>())).OnMouseExit();
			manager.Politic_Selected(200);
			manager.RepaintData();
			bear1.Repaint();
			bear2.Repaint();
		}
		manager.CoopRepaint();
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
		a = global1.gameState;
		okoshko = GetComponent<OkoshkoScript>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
}
