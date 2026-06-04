using System;
using System.Collections.Generic;
using System.Linq;
using DiploAltInfo;
using KGEvent;
using KGWar;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiploButtonScript : MonoBehaviour
{
	public Sprite usl_off;

	public Sprite usl_on;

	private bool is_active;

	private GameState a;

	public GameObject opis;

	public GameObject[] uslovie = new GameObject[4];

	private bool[] uslovie_bool = new bool[4];

	private int number_uslovie;

	private string[] uslovie_text = new string[4];

	private string this_opis;

	public GlobalScript global1;

	private MapChangesScript map1;

	public Sprite on;

	public Sprite off;

	private int this_type = -1;

	private GameObject achieves;

	public int selected_country = -1;

	public int selectedWar = -1;

	public void Awake()
	{
		global1 = GlobalScript.inst;
		a = GlobalScript.inst.gameState;
		map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		achieves = GameObject.Find("Ach(Clone)");
		if (selectedWar >= 0)
		{
			GetComponentInChildren<TextMesh>().text = GlobalScript.inst.new_texts[selectedWar + 737];
		}
	}

	public void Hide()
	{
		base.transform.Find("Text").GetComponent<TextMesh>().text = null;
		is_active = false;
		GetComponent<SpriteRenderer>().sprite = null;
	}

	public void Show(string text, int number)
	{
		is_active = true;
		this_type = number;
		GetComponent<SpriteRenderer>().sprite = off;
		base.transform.Find("Text").GetComponent<TextMesh>().text = text;
		if (a.PlayerCountry == 1)
		{
			ChineseInfo();
		}
		else if (a.PlayerCountry == 21)
		{
			FrenchDiplo.ButtonsReq(this_type, ref this_opis, ref number_uslovie, ref uslovie_bool, ref uslovie_text, (MinorCountries)selected_country);
		}
		else
		{
			SovietDiplo.ButtonsReq(this_type, ref this_opis, ref number_uslovie, ref uslovie_bool, ref uslovie_text, (MinorCountries)selected_country);
		}
	}

	private void ChineseInfo()
	{
		if (selectedWar >= 0)
		{
			number_uslovie = 2;
			int num = selectedWar + 1;
			this_opis = string.Format(global1.new_texts[selectedWar + 757], '\n');
			if (!a.startedDirectWarsNum.ContainsKey(num) && a.influencePRC >= 150 && !a.allcountries[1].IsInTheForeignAlliances() && !a.allcountries[15].cw && !a.allcountries[selected_country].IsInTheSameEconomicAllianceWith(a.allcountries[1]) && !a.allcountries[selected_country].IsInTheSameMilitaryAllianceWith(a.allcountries[1]) && !a.allcountries[selected_country].proprc)
			{
				switch (num)
				{
				case 1:
					uslovie_bool[0] = a.event_done[56] && a.event_done[43];
					uslovie_text[0] = global1.new_texts[803];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				case 2:
					uslovie_bool[0] = a.CBIndia;
					uslovie_text[0] = global1.new_texts[809];
					uslovie_bool[1] = !a.allcountries[selected_country].Torg;
					uslovie_text[1] = global1.new_texts[811];
					break;
				case 3:
					uslovie_bool[0] = a.allcountries[47].IsInTheSameMilitaryAllianceWith(a.allcountries[1]) && a.allcountries[10].IsInTheSameMilitaryAllianceWith(a.allcountries[1]) && (GlobalScript.inst.gameState.ingamewars[0].infl1 >= 900 || a.data[83] == 1);
					uslovie_text[0] = global1.new_texts[777];
					uslovie_bool[1] = a.data[162] >= 5000 && a.war == 0;
					uslovie_text[1] = global1.new_texts[778];
					break;
				case 4:
					uslovie_bool[0] = a.event_done[56] && a.event_done[43];
					uslovie_text[0] = global1.new_texts[812];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				case 5:
					uslovie_bool[0] = a.allcountries[11].okb || a.allcountries[34].okb || a.allcountries[11].proprc || a.allcountries[34].proprc || a.allcountries[11].EAF || a.allcountries[34].EAF;
					uslovie_text[0] = global1.new_texts[813];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				case 6:
					uslovie_bool[0] = a.allcountries[11].okb || a.allcountries[34].okb || a.allcountries[11].proprc || a.allcountries[34].proprc || a.allcountries[11].EAF || a.allcountries[34].EAF;
					uslovie_text[0] = global1.new_texts[813];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				case 7:
					uslovie_bool[0] = !a.allcountries[selected_country].IsInTheForeignAlliances() && a.event_done[17] && !a.ingamewars[2].is_going;
					uslovie_text[0] = global1.new_texts[814];
					uslovie_bool[1] = a.data[22] >= 3000 && a.war == 0;
					uslovie_text[1] = global1.new_texts[815];
					break;
				case 8:
					uslovie_bool[0] = (a.allcountries[33].proprc || a.allcountries[33].EAF || a.allcountries[33].okb) && (a.allcountries[22].proprc || a.allcountries[22].EAF || a.allcountries[22].okb) && !a.ingamewars[2].is_going;
					uslovie_text[0] = global1.new_texts[816];
					uslovie_bool[1] = a.data[22] >= 3000 && a.war == 0;
					uslovie_text[1] = global1.new_texts[815];
					break;
				case 9:
					uslovie_bool[0] = a.allcountries[19].Torg || a.allcountries[19].proprc || a.allcountries[19].okb || a.allcountries[19].EAF;
					uslovie_text[0] = global1.new_texts[817];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				case 10:
					uslovie_bool[0] = a.completedDecisions[9];
					uslovie_text[0] = global1.new_texts[818];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				case 11:
					uslovie_bool[0] = a.allcountries[44].EAF && a.startedDirectWarsNum.Any((KeyValuePair<int, bool> i) => i.Key == 10 && i.Value);
					uslovie_text[0] = global1.new_texts[819];
					uslovie_bool[1] = a.data[162] >= 5000 && a.war == 0;
					uslovie_text[1] = global1.new_texts[778];
					break;
				case 12:
					uslovie_bool[0] = a.allcountries[49].IsInTheSameMilitaryAllianceWith(a.allcountries[1]) && a.allcountries[50].IsInTheSameMilitaryAllianceWith(a.allcountries[1]);
					uslovie_text[0] = global1.new_texts[820];
					uslovie_bool[1] = a.data[162] >= 500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[821];
					break;
				case 13:
					uslovie_bool[0] = a.ingamewars[5].is_going;
					uslovie_text[0] = global1.new_texts[822];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				case 14:
					uslovie_bool[0] = a.allcountries[19].Torg || a.allcountries[19].proprc || a.allcountries[19].okb || a.allcountries[19].EAF;
					uslovie_text[0] = global1.new_texts[817];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				case 15:
					uslovie_bool[0] = !a.allcountries[selected_country].IsInTheForeignAlliances() && (a.data[64] == 2 || a.completedDecisions[6] || a.completedDecisions[7] || a.allcountries[38].proprc) && a.data[65] > 0;
					uslovie_text[0] = global1.new_texts[823];
					uslovie_bool[1] = a.data[162] >= 500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[821];
					break;
				case 16:
					uslovie_bool[0] = !a.allcountries[selected_country].IsInTheForeignAlliances() && (a.data[64] == 2 || a.completedDecisions[6] || a.completedDecisions[7] || a.allcountries[38].proprc || a.data[65] > 0);
					uslovie_text[0] = global1.new_texts[824];
					uslovie_bool[1] = a.data[162] >= 500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[821];
					break;
				case 17:
					uslovie_bool[0] = !a.allcountries[selected_country].IsInTheForeignAlliances() && a.event_done[378];
					uslovie_text[0] = global1.new_texts[877];
					uslovie_bool[1] = a.data[22] >= 2500 && a.war == 0;
					uslovie_text[1] = global1.new_texts[804];
					break;
				}
			}
			else if (a.allcountries[selected_country].IsInTheSameEconomicAllianceWith(a.allcountries[1]) || a.allcountries[selected_country].IsInTheSameMilitaryAllianceWith(a.allcountries[1]) || a.allcountries[selected_country].proprc)
			{
				uslovie_bool[0] = !a.allcountries[selected_country].IsInTheSameEconomicAllianceWith(a.allcountries[1]) && !a.allcountries[selected_country].IsInTheSameMilitaryAllianceWith(a.allcountries[1]);
				uslovie_text[0] = global1.new_texts[807];
				uslovie_bool[1] = !a.allcountries[selected_country].proprc;
				uslovie_text[1] = global1.new_texts[808];
			}
			else if (a.influencePRC < 150)
			{
				uslovie_bool[0] = a.influencePRC >= 150;
				uslovie_text[0] = global1.new_texts[825];
				uslovie_bool[1] = !a.allcountries[selected_country].proprc;
				uslovie_text[1] = global1.new_texts[808];
			}
			else
			{
				uslovie_bool[0] = !a.startedDirectWarsNum.ContainsKey(num);
				uslovie_text[0] = global1.new_texts[805];
				uslovie_bool[1] = !a.allcountries[1].IsInTheForeignAlliances() && !a.allcountries[15].cw;
				uslovie_text[1] = global1.new_texts[806];
			}
		}
		else if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this_type == 2)
			{
				this_opis = "启动行动，夺取香港和澳门";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[65] == 0;
				uslovie_text[0] = "香港和澳门不属于我们";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = "预算至少500万";
				uslovie_bool[2] = a.data[22] >= 100;
				uslovie_text[2] = "军事实力至少10";
				uslovie_bool[3] = a.BritLost;
				uslovie_text[3] = "英国在福克兰战争中失利";
			}
			else if (this_type == 1)
			{
				this_opis = "支持毛主义组织";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 50 && a.data[8] + a.data[36] >= 30;
				uslovie_text[0] = "至少5个特工网络，预算至少300万";
				uslovie_bool[1] = a.modifies[6].active;
				uslovie_text[1] = "我们以毛主义者为荣！";
				uslovie_bool[2] = a.data[6] > 750;
				uslovie_text[2] = "外交声望超过75";
				if (selected_country == 92 || selected_country == 21 || selected_country == 17)
				{
					if (a.empires[0].power < 50)
					{
						uslovie_bool[3] = a.empires[0].power >= 50;
						uslovie_text[3] = "西欧：太难";
					}
					else
					{
						uslovie_bool[3] = !a.war_active[0];
						uslovie_text[3] = "西欧：每年";
					}
				}
				else if (a.empires[1].power < 50)
				{
					uslovie_bool[3] = a.empires[1].power >= 50;
					uslovie_text[3] = "东欧：太难";
				}
				else
				{
					uslovie_bool[3] = !a.war_active[1];
					uslovie_text[3] = "东欧：每年";
				}
			}
			else if (this_type == 3)
			{
				this_opis = "与英国和葡萄牙就香港和澳门的移交进行谈判";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 20;
				uslovie_text[0] = "至少2个特工网络";
				uslovie_bool[1] = a.data[21] >= 1980;
				uslovie_text[1] = "不早于1980年";
				if (!GlobalScript.inst.dlc[3])
				{
					uslovie_bool[2] = a.data[6] < 700;
					uslovie_text[2] = "外交声望低于70";
				}
				else
				{
					uslovie_bool[2] = a.data[6] < 700 && a.allcountries[87].Gosstroy != 0;
					uslovie_text[2] = GlobalScript.inst.other_text[309];
				}
				uslovie_bool[3] = a.allcountries[0].dev == 0;
				uslovie_text[3] = "尚未谈判";
			}
			else if (this_type == 4)
			{
				if (a.data[21] < 1979 || (a.data[20] < 4 && a.data[21] == 1979))
				{
					this_opis = "延长友好协议";
				}
				else
				{
					this_opis = "恢复关系";
				}
				number_uslovie = 4;
				uslovie_bool[0] = a.data[21] >= 1979;
				uslovie_text[0] = "不早于1979年";
				if (a.data[21] < 1979 || (a.data[20] < 4 && a.data[21] == 1979))
				{
					if (a.leader.traits[0] == 0 && a.leader.traits[1] == 4 && a.leader.traits[2] == 8)
					{
						uslovie_bool[1] = a.data[1] >= 900 && a.SOV_PRC_PartiesConnection >= 100;
						uslovie_text[1] = "党的支持至少90，通信体系已恢复（至少10）";
					}
					else
					{
						uslovie_bool[1] = a.data[1] >= 700 && a.SOV_PRC_PartiesConnection >= 200;
						uslovie_text[1] = "党的支持至少70，通信体系已恢复（至少20）";
					}
				}
				else
				{
					uslovie_bool[1] = a.data[1] >= 900 && a.SOV_PRC_PartiesConnection >= 250;
					uslovie_text[1] = "党的支持至少90，通信体系已恢复（至少25）";
				}
				uslovie_bool[2] = a.vietnampeace;
				uslovie_text[2] = "未挑起与越南的战争";
				if (!a.relres)
				{
					uslovie_bool[3] = a.empires[1].relations >= 700;
					uslovie_text[3] = "关系至少70";
				}
				else
				{
					uslovie_bool[3] = !a.relres;
					uslovie_text[3] = "尚未恢复关系";
				}
			}
			else if (this_type == 5)
			{
				this_opis = "加入经互会";
				number_uslovie = 4;
				if (!a.relres)
				{
					uslovie_bool[0] = a.relres;
					uslovie_text[0] = "关系恢复";
				}
				else
				{
					uslovie_bool[0] = !a.modifies[6].active || a.influencePRC < 300;
					uslovie_text[0] = "我们没有毛主义，或我们的影响力低于30.0";
				}
				uslovie_bool[1] = !a.allcountries[51].Torg;
				uslovie_text[1] = "与美国没有密切联系";
				uslovie_bool[2] = a.data[6] > 690;
				uslovie_text[2] = "外交声望超过69";
				if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10))
				{
					uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10);
					uslovie_text[2] = "未袭击其盟友";
				}
				else if (!a.allcountries[1].isSEV)
				{
					uslovie_bool[3] = a.war <= 0;
					uslovie_text[3] = "我们未处于战争状态";
				}
				else
				{
					uslovie_bool[3] = !a.allcountries[1].isSEV;
					uslovie_text[3] = "尚未加入";
				}
			}
			else if (this_type == 74)
			{
				this_opis = "成为经互会观察员";
				number_uslovie = 3;
				uslovie_bool[0] = a.relres;
				uslovie_text[0] = "关系恢复";
				uslovie_bool[1] = !a.allcountries[51].Torg;
				uslovie_text[1] = "与美国没有密切联系";
				uslovie_bool[2] = a.data[6] > 600;
				uslovie_text[2] = "外交声望超过60";
			}
			else if (this_type == 6)
			{
				this_opis = "Join the 华沙条约组织";
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[1].isSEV;
				uslovie_text[0] = "已加入经互会";
				uslovie_bool[1] = a.data[6] > 690;
				uslovie_text[1] = "外交声望超过69";
				if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10))
				{
					uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10);
					uslovie_text[2] = "未袭击其盟友";
				}
				else if (!a.allcountries[1].isOVD)
				{
					uslovie_bool[2] = a.war <= 0;
					uslovie_text[2] = "我们未处于战争状态";
				}
				else
				{
					uslovie_bool[2] = !a.allcountries[1].isOVD;
					uslovie_text[2] = "尚未加入";
				}
				uslovie_bool[3] = !a.allcountries[15].cw;
				uslovie_text[3] = "不在不结盟运动中";
			}
			else if (this_type == 7)
			{
				this_opis = "Restoring destroyed communication structures|Restored: " + a.SOV_PRC_PartiesConnection / 10 + "." + Mathf.Abs(a.SOV_PRC_PartiesConnection % 10);
				number_uslovie = 3;
				uslovie_bool[0] = a.data[9] >= a.SOV_PRC_PartiesConnection / 2;
				uslovie_text[0] = "至少" + a.SOV_PRC_PartiesConnection / 20 + "." + Mathf.Abs(a.SOV_PRC_PartiesConnection / 2 % 10) + " 代理网络";
				uslovie_bool[1] = a.data[8] + a.data[36] >= a.SOV_PRC_PartiesConnection / 4;
				uslovie_text[1] = "In the budget:  " + a.SOV_PRC_PartiesConnection / 40 + "." + Mathf.Abs(a.SOV_PRC_PartiesConnection / 4 % 10);
				uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
				uslovie_text[2] = "每三个月一次";
			}
			else if (this_type == 8)
			{
				this_opis = "支持伊朗革命中的指定力量";
				number_uslovie = 4;
				if (a.allcountries[selected_country].dev == 0 && a.data[43] < 1000)
				{
					uslovie_bool[0] = a.data[9] >= 90;
					uslovie_text[0] = "至少9 代理网络";
				}
				else if (a.allcountries[selected_country].dev == 1 && a.data[42] < 1000)
				{
					uslovie_bool[0] = a.data[9] >= 90;
					uslovie_text[0] = "至少9 代理网络";
				}
				else if (a.allcountries[selected_country].dev == 2 && a.data[44] < 1000)
				{
					uslovie_bool[0] = a.data[9] >= 90;
					uslovie_text[0] = "至少9 代理网络";
				}
				else if (a.data[45] < 1000)
				{
					uslovie_bool[0] = a.data[9] >= 90;
					uslovie_text[0] = "至少9 代理网络";
				}
				else
				{
					uslovie_bool[0] = a.data[9] < -5000;
					uslovie_text[0] = "他们需要一些帮助";
				}
				uslovie_bool[1] = a.data[8] + a.data[36] >= 60;
				uslovie_text[1] = "预算600万";
				uslovie_bool[2] = a.allcountries[selected_country].stab == 0 && a.allcountries[8].dev != 4;
				uslovie_text[2] = "每3个月";
				uslovie_bool[3] = a.iranrev;
				uslovie_text[3] = "抗议开始了，革命却没有结束";
			}
			else if (this_type == 9)
			{
				if (selected_country == 104)
				{
					this_opis = "建立外交关系并开展深度贸易";
				}
				else
				{
					this_opis = "开始深度贸易";
				}
				number_uslovie = 3;
				if (a.allcountries[selected_country].Gosstroy == 0)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 800;
					uslovie_text[0] = "外交声望在39到80之间";
				}
				else if (a.allcountries[selected_country].Gosstroy == 1)
				{
					uslovie_bool[0] = a.data[6] > 690;
					uslovie_text[0] = "外交声望超过69";
				}
				else if (a.allcountries[selected_country].Gosstroy == 2)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
					uslovie_text[0] = "外交声望在39到85之间";
				}
				else
				{
					uslovie_bool[0] = a.data[6] < 500;
					uslovie_text[0] = "外交声望低于50";
				}
				if (selected_country == 34 && a.ingamewars[2].is_going)
				{
					uslovie_bool[1] = !a.ingamewars[2].is_going;
					uslovie_text[1] = "没有内战";
				}
				else if (selected_country == 109 && a.ingamewars[31].is_going)
				{
					uslovie_bool[1] = !a.ingamewars[31].is_going;
					uslovie_text[1] = "没有内战";
				}
				else if (selected_country == 110 && a.ingamewars[32].is_going)
				{
					uslovie_bool[1] = !a.ingamewars[32].is_going;
					uslovie_text[1] = "没有内战";
				}
				else
				{
					uslovie_bool[1] = !a.allcountries[selected_country].Torg;
					uslovie_text[1] = "未开展贸易";
				}
				if (a.allcountries[selected_country].proprc && a.allcountries[selected_country].SubGosstroy == 17)
				{
					uslovie_bool[2] = a.data[12] < 300;
					uslovie_text[2] = "工业水平低于30";
				}
				else if (a.allcountries[selected_country].proprc)
				{
					uslovie_bool[2] = a.data[12] >= 300;
					uslovie_text[2] = "工业水平不低于30";
				}
				else if (selected_country == 92 || selected_country == 85 || (selected_country > 87 && selected_country < 92) || selected_country == 0)
				{
					uslovie_bool[2] = a.data[12] >= 700;
					uslovie_text[2] = "工业水平不低于70";
				}
				else
				{
					uslovie_bool[2] = a.data[12] >= 500;
					uslovie_text[2] = "工业水平不低于50";
				}
				if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[7].isNATO;
					uslovie_text[3] = GlobalScript.inst.other_text[105];
				}
			}
			else if (this_type == 10)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 3;
				if (selected_country != 35 && selected_country != 14)
				{
					uslovie_bool[0] = a.allcountries[selected_country].Torg || a.allcountries[selected_country].proprc;
					uslovie_text[0] = "开展贸易，或倾向亲华";
				}
				else
				{
					uslovie_bool[0] = a.allcountries[selected_country].proprc;
					uslovie_text[0] = "在中国影响之下";
				}
				if (selected_country == 48 && a.allcountries[48].proprc)
				{
					uslovie_bool[1] = a.allcountries[1].isSEV;
					uslovie_text[1] = "中国在经互会中";
				}
				else
				{
					uslovie_bool[1] = a.allcountries[1].isSEV || a.allcountries[1].econ;
					uslovie_text[1] = "Union founded or 中国在经互会中";
				}
				uslovie_bool[2] = !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isASEAN;
				uslovie_text[2] = "他们不是经济联盟成员";
				if ((a.allcountries[selected_country].Vyshi && selected_country != 48) || (a.allcountries[selected_country].usalliance && selected_country != 48))
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[selected_country].Vyshi && !a.allcountries[selected_country].usalliance;
					uslovie_text[3] = "该国不受美国影响";
				}
				else if (((a.allcountries[selected_country].prosov && selected_country != 48) || (a.allcountries[selected_country].sovalliance && selected_country != 48)) && !a.allcountries[1].isSEV)
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].sovalliance;
					uslovie_text[3] = "该国不受美国影响SR";
				}
				else if (a.allcountries[selected_country].oar)
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[selected_country].oar;
					uslovie_text[3] = GlobalScript.inst.other_text[104];
				}
				else if (selected_country == 8 && (a.ingamewars[3].is_going || a.ingamewars[5].is_going))
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.ingamewars[3].is_going && !a.ingamewars[5].is_going;
					uslovie_text[3] = "伊朗未处于战争状态，阿富汗也未处于战争状态";
				}
				else if (selected_country == 8)
				{
					if (a.allcountries[selected_country].Gosstroy == 0)
					{
						uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 800;
						uslovie_text[0] = "外交声望在39到80之间";
					}
					else if (a.allcountries[selected_country].Gosstroy == 1)
					{
						uslovie_bool[0] = a.data[6] > 690;
						uslovie_text[0] = "外交声望超过69";
					}
					else if (a.allcountries[selected_country].Gosstroy == 2)
					{
						uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
						uslovie_text[0] = "外交声望在39到85之间";
					}
					else
					{
						uslovie_bool[0] = a.data[6] < 500;
						uslovie_text[0] = "外交声望低于50";
					}
				}
				else if (selected_country == 104)
				{
					number_uslovie = 4;
					uslovie_bool[3] = GlobalScript.inst.gameState.data[85] == 3;
					uslovie_text[3] = "Created \"Union state\"";
				}
			}
			else if (this_type == 11)
			{
				this_opis = "为温和改革煽动骚乱";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 100;
				uslovie_text[0] = "至少10 代理网络";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = "预算500万";
				uslovie_bool[2] = a.empires[1].now_leader > 0;
				uslovie_text[2] = "勃列日涅夫逝世";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "尚未煽动骚乱";
			}
			else if (this_type == 12)
			{
				this_opis = "在党内煽动政变，支持亲华势力";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 100 && a.data[8] + a.data[36] >= 80;
				uslovie_text[0] = "至少10 代理网络 and 预算800万";
				uslovie_bool[1] = a.data[6] > 690;
				uslovie_text[1] = "外交声望超过69";
				uslovie_bool[2] = a.allcountries[selected_country].stab != 0;
				uslovie_text[2] = "已煽动骚乱";
				uslovie_bool[3] = !a.allcountries[selected_country].proprc;
				uslovie_text[3] = "尚未煽动政变";
			}
			else if (this_type == 13)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 4;
				if (GlobalScript.inst.dlc[3])
				{
					uslovie_bool[0] = a.allcountries[selected_country].inflCh <= 0 && a.guns && a.allcountries[selected_country].inflNATO <= 0;
					uslovie_text[0] = GlobalScript.inst.other_text[102];
				}
				else
				{
					uslovie_bool[0] = a.allcountries[selected_country].inflCh <= 0 && a.guns;
					uslovie_text[0] = "运送武器，但未实施制裁";
				}
				uslovie_bool[1] = a.allcountries[1].isSEV || a.allcountries[1].econ;
				uslovie_text[1] = "Union founded or 中国在经互会中";
				uslovie_bool[2] = !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].econ;
				uslovie_text[2] = "他们不是经济联盟成员";
				if (a.allcountries[selected_country].Gosstroy <= 1)
				{
					uslovie_bool[3] = a.data[6] > 890;
					uslovie_text[3] = "外交声誉高于89";
				}
				else
				{
					uslovie_bool[3] = a.data[6] > 490 && a.data[6] < 890;
					uslovie_text[3] = "外交声誉在49到89之间";
				}
			}
			else if (this_type == 14)
			{
				this_opis = "实施制裁";
				if (!GlobalScript.inst.dlc[3])
				{
					number_uslovie = 2;
				}
				else
				{
					number_uslovie = 3;
				}
				uslovie_bool[0] = a.allcountries[selected_country].inflCh <= 0;
				uslovie_text[0] = "不实施制裁";
				uslovie_bool[1] = a.data[6] < 500;
				uslovie_text[1] = "外交声望低于50";
				if (GlobalScript.inst.dlc[3])
				{
					uslovie_bool[2] = a.allcountries[10].dev <= 0;
					uslovie_text[2] = GlobalScript.inst.other_text[101];
				}
			}
			else if (this_type == 15)
			{
				this_opis = "煽动新的朝鲜战争";
				number_uslovie = 4;
				uslovie_bool[0] = a.guns && a.data[9] >= 100 && a.data[8] + a.data[36] >= 50;
				uslovie_text[0] = "Sent a weapon, there are 10 代理网络 and 5 million in the budget";
				if (!a.allcountries[1].isASEAN)
				{
					if (GlobalScript.inst.dlc[3])
					{
						uslovie_bool[1] = a.event_done[91] && a.allcountries[46].Gosstroy == 0 && a.allcountries[10].dev <= 0;
						uslovie_text[1] = GlobalScript.inst.other_text[103];
					}
					else
					{
						uslovie_bool[1] = a.event_done[91] && a.allcountries[46].Gosstroy == 0;
						uslovie_text[1] = "发生了对全斗焕的暗杀企图";
					}
				}
				else
				{
					uslovie_bool[1] = a.event_done[91];
					uslovie_text[1] = "发生了对全斗焕的暗杀企图";
				}
				uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
				uslovie_text[2] = "未煽动战争";
				uslovie_bool[3] = a.data[6] > 790;
				uslovie_text[3] = "外交声誉高于79";
			}
			else if (this_type == 16)
			{
				this_opis = "运送武器和专家";
				if (!GlobalScript.inst.dlc[3])
				{
					number_uslovie = 3;
				}
				else
				{
					number_uslovie = 4;
				}
				uslovie_bool[0] = !a.guns;
				uslovie_text[0] = "未运送武器";
				uslovie_bool[1] = a.data[22] >= 50;
				uslovie_text[1] = "军事实力至少5";
				uslovie_bool[2] = a.data[8] + a.data[36] >= 20;
				uslovie_text[2] = "预算200万";
				if (GlobalScript.inst.dlc[3])
				{
					uslovie_bool[3] = a.allcountries[10].dev <= 0;
					uslovie_text[3] = GlobalScript.inst.other_text[101];
				}
			}
			else if (this_type == 17)
			{
				this_opis = "开始深度贸易";
				number_uslovie = 3;
				if (!a.allcountries[selected_country].proprc)
				{
					uslovie_bool[0] = a.vietnampeace;
					uslovie_text[0] = "未与越南开战";
				}
				else
				{
					uslovie_bool[0] = a.allcountries[selected_country].proprc;
					uslovie_text[0] = "越南受中国影响";
				}
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "未开展贸易";
				uslovie_bool[2] = a.data[6] > 690 || a.allcountries[selected_country].proprc;
				uslovie_text[2] = "外交声望超过69 or Vietnam is pro-chinese";
				if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[7].isNATO;
					uslovie_text[3] = GlobalScript.inst.other_text[105];
				}
			}
			else if (this_type == 18)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 3;
				uslovie_bool[0] = !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].econ;
				uslovie_text[0] = "越南不在我们的联盟中，也不在经互会（CMEA）内";
				uslovie_bool[1] = a.allcountries[selected_country].Torg;
				uslovie_text[1] = "开展贸易";
				uslovie_bool[2] = a.allcountries[1].econ || a.allcountries[1].isSEV;
				uslovie_text[2] = "联盟已成立，或我们在经互会（COMECON）内";
				if (a.allcountries[selected_country].Vyshi)
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[selected_country].Vyshi;
					uslovie_text[3] = "该国不受美国影响";
				}
			}
			else if (this_type == 19)
			{
				this_opis = "邀请加入军事同盟";
				number_uslovie = 4;
				uslovie_bool[1] = a.data[22] >= 20;
				uslovie_text[1] = "军事实力至少2";
				uslovie_bool[3] = a.data[6] > 790;
				uslovie_text[3] = "外交声誉高于79";
				if (selected_country != 40)
				{
					uslovie_bool[0] = a.allcountries[selected_country].isSEV || a.allcountries[selected_country].econ;
					uslovie_text[0] = "他们在经互会（CMEA）或经互会（OEC）内";
				}
				else
				{
					uslovie_bool[0] = (a.allcountries[selected_country].isSEV || a.allcountries[selected_country].econ) && !a.allcountries[selected_country].oar;
					uslovie_text[0] = "他们在经互会（CMEA）或经互会（OEC）内, but not in the UAR";
				}
				if (!a.allcountries[selected_country].oar)
				{
					uslovie_bool[2] = a.allcountries[selected_country].IsInTheSameEconomicAllianceWith(a.allcountries[1]) && ((!a.allcountries[selected_country].isOVD && a.allcountries[1].isOVD && !a.allcountries[selected_country].isSEATO) || (!a.allcountries[selected_country].okb && a.allcountries[1].okb && !a.allcountries[selected_country].isOVD && !a.allcountries[selected_country].isSEATO));
					uslovie_text[2] = "他们不在军事同盟中，CSA已成立，或中国在WPO内";
				}
				else
				{
					uslovie_bool[2] = !a.allcountries[selected_country].oar;
					uslovie_text[2] = GlobalScript.inst.other_text[104];
				}
			}
			else if (this_type == 20)
			{
				if (selected_country == 11)
				{
					this_opis = "Send PLA reinforcements to the war|Strenth of our forces: " + a.data[39] / 10 + "." + Mathf.Abs(a.data[39] % 10);
				}
				else if (selected_country == 19)
				{
					this_opis = "Send PLA reinforcements to the war|Strenth of our forces: " + a.data[40] / 10 + "." + Mathf.Abs(a.data[40] % 10);
				}
				number_uslovie = 3;
				uslovie_bool[0] = a.war == 1;
				uslovie_text[0] = "正在发生战争";
				uslovie_bool[1] = a.data[22] >= 70;
				uslovie_text[1] = "军事实力至少7";
				uslovie_bool[2] = a.allcountries[selected_country].stab == 0;
				uslovie_text[2] = "本月未派遣";
			}
			else if (this_type == 21)
			{
				this_opis = "在和平夺权斗争中支持所选力量";
				number_uslovie = 4;
				uslovie_bool[0] = a.DRAagree;
				uslovie_text[0] = "与越南民主共和国（DRA）和苏联达成一致";
				uslovie_bool[1] = a.data[9] >= 40;
				uslovie_text[1] = "至少4 代理网络";
				uslovie_bool[2] = a.data[8] + a.data[36] >= 30;
				uslovie_text[2] = "预算300万";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "今年未获支持";
			}
			else if (this_type == 68)
			{
				this_opis = "接纳进入经互会";
				number_uslovie = 4;
				uslovie_bool[0] = !a.ingamewars[5].is_going;
				uslovie_text[0] = "该国未陷入内战";
				uslovie_bool[1] = a.allcountries[selected_country].proprc || (a.allcountries[1].isSEV && a.allcountries[selected_country].prosov);
				uslovie_text[1] = "Afghanistan pro-Chinese or pro-Soviet and 中国在经互会中";
				uslovie_bool[2] = a.allcountries[selected_country].Torg && (a.allcountries[1].econ || a.allcountries[1].isSEV);
				uslovie_text[2] = "贸易与工会";
				uslovie_bool[3] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].isASEAN;
				uslovie_text[3] = "他们不是经济联盟成员";
			}
			else if (this_type == 22)
			{
				this_opis = "汇款援助卡扎菲";
				number_uslovie = 2;
				uslovie_bool[0] = a.allcountries[selected_country].stab == 0;
				uslovie_text[0] = "尚未汇款";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = "预算500万";
			}
			else if (this_type == 23)
			{
				this_opis = "开始积极贸易";
				number_uslovie = 3;
				uslovie_bool[0] = !a.allcountries[selected_country].Torg;
				uslovie_text[0] = "未开展贸易";
				uslovie_bool[1] = a.data[6] > 590;
				uslovie_text[1] = "外交声誉超过59";
				uslovie_bool[2] = a.allcountries[selected_country].stab == 1;
				uslovie_text[2] = "已向卡扎菲汇款";
			}
			else if (this_type == 150)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 3;
				uslovie_bool[0] = a.allcountries[selected_country].Torg;
				uslovie_text[0] = "开展贸易";
				uslovie_bool[1] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
				uslovie_text[1] = "他们不是经济联盟成员";
				uslovie_bool[2] = a.allcountries[1].econ || a.allcountries[1].isSEV;
				uslovie_text[2] = "Union founded or 中国在经互会中";
				if (GlobalScript.inst.dlc[3])
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.ingamewars[20].is_going;
					uslovie_text[3] = GlobalScript.inst.other_text[489];
				}
			}
			else if (this_type == 67)
			{
				this_opis = "就该国加入阿联共和国进行谈判";
				number_uslovie = 2;
				uslovie_bool[0] = a.OAR;
				uslovie_text[0] = "阿联共和国成立";
				uslovie_bool[1] = !a.allcountries[selected_country].oar;
				uslovie_text[1] = "该国不在阿联共和国内";
				if (selected_country == 14)
				{
					number_uslovie = 3;
					uslovie_bool[2] = a.allcountries[14].puppetOf != 8;
					uslovie_text[2] = GlobalScript.inst.other_text[116];
				}
				if (selected_country == 13 && GlobalScript.inst.dlc[3])
				{
					number_uslovie = 3;
					uslovie_bool[2] = a.data[132] == 2;
					uslovie_text[2] = GlobalScript.inst.other_text[115];
				}
			}
			else if (this_type == 24)
			{
				this_opis = "开始深度贸易";
				number_uslovie = 3;
				if (a.allcountries[selected_country].Gosstroy == 0)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 800;
					uslovie_text[0] = "外交声望在39到80之间";
				}
				else if (a.allcountries[selected_country].Gosstroy == 1)
				{
					uslovie_bool[0] = a.data[6] > 690;
					uslovie_text[0] = "外交声望超过69";
				}
				else if (a.allcountries[selected_country].Gosstroy == 2)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
					uslovie_text[0] = "外交声望在39到85之间";
				}
				else
				{
					uslovie_bool[0] = a.data[6] < 500;
					uslovie_text[0] = "外交声望低于50";
				}
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "未开展贸易";
				uslovie_bool[2] = a.data[12] >= 700;
				uslovie_text[2] = "工业水平不低于70";
				if (selected_country == 52)
				{
					number_uslovie = 4;
					uslovie_bool[3] = a.allcountries[52].stab <= 0;
					uslovie_text[3] = GlobalScript.inst.other_text[473];
				}
				if (selected_country == 14)
				{
					number_uslovie = 4;
					uslovie_bool[3] = a.allcountries[14].puppetOf != 8;
					uslovie_text[3] = "并非伊朗的傀儡";
				}
				else if (((selected_country >= 2 && selected_country <= 6) || selected_country == 16) && a.allcountries[1].isSEV)
				{
					number_uslovie = 4;
					uslovie_bool[3] = a.allcountries[1].isSEV;
					uslovie_text[3] = "中国是经互会成员";
				}
				else if ((selected_country >= 2 && selected_country <= 6) || selected_country == 16)
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[selected_country].prosov;
					uslovie_text[3] = "不受苏联影响";
				}
			}
			else if (this_type == 50)
			{
				this_opis = "开始深度贸易";
				number_uslovie = 3;
				if (a.allcountries[selected_country].Gosstroy == 0)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 800;
					uslovie_text[0] = "外交声望在39到80之间";
				}
				else if (a.allcountries[selected_country].Gosstroy == 1)
				{
					uslovie_bool[0] = a.data[6] > 690;
					uslovie_text[0] = "外交声望超过69";
				}
				else if (a.allcountries[selected_country].Gosstroy == 2)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
					uslovie_text[0] = "外交声望在39到85之间";
				}
				else
				{
					uslovie_bool[0] = a.data[6] < 500;
					uslovie_text[0] = "外交声望低于50";
				}
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "未开展贸易";
				uslovie_bool[2] = a.data[12] >= 700;
				uslovie_text[2] = "工业水平不低于70";
				if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[7].isNATO;
					uslovie_text[3] = GlobalScript.inst.other_text[105];
				}
			}
			else if (this_type == 69)
			{
				this_opis = "与共产党建立联系并支持他们";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[6] > 790;
				uslovie_text[0] = "外交声誉高于79";
				uslovie_bool[1] = a.data[9] >= 30;
				uslovie_text[1] = "至少3 代理网络";
				uslovie_bool[2] = a.event_done[3];
				uslovie_text[2] = "萨达姆开始镇压共产党人";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "未予支持";
			}
			else if (this_type == 25)
			{
				this_opis = "就该国加入阿联共和国进行谈判";
				number_uslovie = 4;
				uslovie_bool[0] = a.OAR;
				uslovie_text[0] = "阿联共和国成立";
				uslovie_bool[1] = !a.allcountries[selected_country].oar && !a.allcountries[selected_country].isNATO && !a.allcountries[selected_country].okb && !a.allcountries[selected_country].isOVD;
				uslovie_text[1] = "This 该国不在阿联共和国内 and nor in any military alliances";
				uslovie_bool[2] = a.allcountries[14].Gosstroy != 0;
				uslovie_text[2] = "国家体制并非专制";
				if (a.allcountries[14].Vyshi)
				{
					uslovie_bool[3] = !a.allcountries[14].Vyshi;
					uslovie_text[3] = "该国不受美国影响";
				}
				else if (a.allcountries[8].Gosstroy == 0)
				{
					uslovie_bool[3] = a.allcountries[8].SubGosstroy != 9;
					uslovie_text[3] = "伊朗不在伊斯兰主义者之下";
				}
				else
				{
					uslovie_bool[3] = a.data[117] != 9;
					uslovie_text[3] = "并非伊朗的傀儡";
				}
			}
			else if (this_type == 26)
			{
				this_opis = "签署友好协议";
				number_uslovie = 3;
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 900;
				uslovie_text[0] = "外交声誉在39到90之间";
				uslovie_bool[1] = (a.data[20] >= 5 && a.data[21] >= 1980) || a.data[21] >= 1981;
				uslovie_text[1] = "铁托死了";
				uslovie_bool[2] = !a.allcountries[selected_country].Torg;
				uslovie_text[2] = "尚未签署";
			}
			else if (this_type == 75)
			{
				this_opis = "向美国人出售技术";
				number_uslovie = 3;
				uslovie_bool[0] = a.data[11] >= 100;
				uslovie_text[0] = "我们有10点科技值";
				uslovie_bool[1] = a.data[56] != 0;
				uslovie_text[1] = "不属于左翼激进派";
				uslovie_bool[2] = a.empires[0].power < 600;
				uslovie_text[2] = "美国的世界影响力低于60";
			}
			else if (this_type == 81)
			{
				this_opis = "出售美国技术";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[11] >= 100;
				uslovie_text[0] = "我们有10点科技值";
				uslovie_bool[1] = a.allcountries[1].isSEV || a.allcountries[7].Torg;
				uslovie_text[1] = "观察员或完全进入经互会";
				uslovie_bool[2] = a.empires[1].power < 600;
				uslovie_text[2] = "苏联的世界影响力低于60";
				uslovie_bool[3] = a.allcountries[51].Torg;
				uslovie_text[3] = "与美国签署友好协议";
			}
			else if (this_type == 76)
			{
				this_opis = "启动经济优惠与贷款政策";
				number_uslovie = 2;
				uslovie_bool[0] = a.data[36] >= 200;
				uslovie_text[0] = "储备 - 20";
				uslovie_bool[1] = !a.allcountries[selected_country].cw;
				uslovie_text[1] = "政策尚未启动";
			}
			else if (this_type == 77)
			{
				this_opis = "对国民党政府进行无血政变式清除";
				this_opis = this_opis + "|Our influence: " + a.allcountries[selected_country].dev + "%";
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].cw;
				uslovie_text[0] = "经济牵制";
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "未被清除";
				uslovie_bool[2] = a.allcountries[selected_country].dev >= 30;
				uslovie_text[2] = "我们的影响力：30";
				uslovie_bool[3] = a.data[9] >= 80;
				uslovie_text[3] = "特工网络 - 8";
			}
			else if (this_type == 78)
			{
				this_opis = "建立军事基地以保护其主权";
				this_opis = this_opis + "|Our influence: " + a.allcountries[selected_country].dev + "%";
				number_uslovie = 4;
				uslovie_bool[0] = !a.allcountries[selected_country].proprc;
				uslovie_text[0] = "没有任何基地";
				uslovie_bool[1] = a.allcountries[selected_country].Torg;
				uslovie_text[1] = "国民党政府已被清除";
				uslovie_bool[2] = a.allcountries[selected_country].dev >= 60;
				uslovie_text[2] = "我们的影响力：60";
				uslovie_bool[3] = a.data[9] >= 60 && a.data[22] >= 100;
				uslovie_text[3] = "特工网络 - 6，军事实力 - 10";
			}
			else if (this_type == 79)
			{
				this_opis = "就加入中华人民共和国进行全民公投";
				this_opis = this_opis + "|Our influence: " + a.allcountries[selected_country].dev + "%";
				number_uslovie = 3;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = "我们在这里有军事基地";
				uslovie_bool[1] = a.allcountries[selected_country].dev >= 100;
				uslovie_text[1] = "我们的影响力：100";
				uslovie_bool[2] = a.data[9] >= 80;
				uslovie_text[2] = "特工网络 - 8";
			}
			else if (this_type == 80)
			{
				this_opis = "按我们的模式调整其国家制度";
				this_opis = this_opis + "|They will gain this State System: " + GlobalScript.inst.other_text[(a.ChineseSubGosstroy() < 10) ? (a.ChineseSubGosstroy() + 13) : (a.ChineseSubGosstroy() + 82)];
				number_uslovie = 4;
				if (a.allcountries[1].okb)
				{
					uslovie_bool[0] = a.allcountries[selected_country].SubGosstroy != a.ChineseSubGosstroy();
					uslovie_text[0] = "我们有不同的国家制度";
				}
				else
				{
					uslovie_bool[0] = a.allcountries[1].okb;
					uslovie_text[0] = "我们有自己的军事同盟";
				}
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = "预算：5";
				uslovie_bool[2] = a.data[9] >= 50;
				uslovie_text[2] = "特工网络：5";
				uslovie_bool[3] = a.data[22] >= 50;
				uslovie_text[3] = "军事实力：5";
			}
			else if (this_type == 27)
			{
				this_opis = "与共产党建立联系并支持他们";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[6] > 590;
				uslovie_text[0] = "外交声誉超过59";
				uslovie_bool[1] = a.data[9] >= 40;
				uslovie_text[1] = "至少4 代理网络";
				uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
				uslovie_text[2] = "未予支持";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 1;
				uslovie_text[3] = "签署了合同";
			}
			else if (this_type == 72)
			{
				this_opis = "加入不结盟运动";
				number_uslovie = 4;
				uslovie_bool[0] = !a.allcountries[1].isOVD && !a.allcountries[1].okb && !a.allcountries[1].isSEATO;
				uslovie_text[0] = "我们不在任何同盟中";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 20;
				uslovie_text[1] = "预算200万";
				uslovie_bool[2] = !a.allcountries[15].cw;
				uslovie_text[2] = "我们目前不在不结盟运动中";
				uslovie_bool[3] = a.war <= 0;
				uslovie_text[3] = "我们没有处于战争状态";
			}
			else if (this_type == 73)
			{
				this_opis = "退出不结盟运动";
				number_uslovie = 3;
				uslovie_bool[0] = a.data[1] > 750;
				uslovie_text[0] = "党的支持率超过75.0";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = "预算500万";
				uslovie_bool[2] = a.allcountries[15].cw;
				uslovie_text[2] = "我们现在在不结盟运动中";
			}
			else if (this_type == 28)
			{
				this_opis = "Support the rebels in the east|Maoist power: " + a.data[32] / 10 + "." + Mathf.Abs(a.data[32] % 10);
				number_uslovie = 4;
				uslovie_bool[0] = a.data[6] > 790;
				uslovie_text[0] = "外交声誉高于79";
				uslovie_bool[1] = a.data[9] >= 30 && a.data[22] >= 30;
				uslovie_text[1] = "至少3 代理网络 and army strength";
				uslovie_bool[2] = !a.allcountries[selected_country].Torg;
				uslovie_text[2] = "尚未建立关系";
				if (a.data[32] <= 500 || GlobalScript.inst.dlc[1])
				{
					uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
					uslovie_text[3] = "未予支持 this month";
				}
				else
				{
					uslovie_bool[3] = a.allcountries[selected_country].stab == 0 && a.data[32] <= 500;
					uslovie_text[3] = "尚未达到其最大能力";
				}
			}
			else if (this_type == 29)
			{
				this_opis = "实现关系正常化";
				number_uslovie = 4;
				uslovie_bool[0] = (a.data[91] == 1 || a.data[91] == 2 || a.data[91] == 3) && (!a.allcountries[31].Torg || a.allcountries[31].Gosstroy == 2 || a.allcountries[31].Gosstroy == 1);
				uslovie_text[0] = "帮助过英迪拉，但与巴基斯坦或布托（巴基斯坦总理）并无友谊";
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "尚未建立关系";
				uslovie_bool[2] = a.allcountries[selected_country].dev == 0 && a.war == 0 && a.data[62] < 2;
				uslovie_text[2] = "没有发动战争";
				uslovie_bool[3] = a.data[62] == 0;
				uslovie_text[3] = "领土争端尚未解决";
			}
			else if (this_type == 30)
			{
				this_opis = "为争议领土发动新的边境战争";
				number_uslovie = 4;
				uslovie_bool[0] = a.CBIndia;
				uslovie_text[0] = "存在战争的理由";
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "尚未建立关系";
				uslovie_bool[2] = a.allcountries[selected_country].dev == 0 && a.war == 0 && a.data[62] < 2;
				uslovie_text[2] = "尚未发动战争";
				uslovie_bool[3] = !a.allcountries[15].cw;
				uslovie_text[3] = "不在不结盟运动中";
			}
			else if (this_type == 89)
			{
				this_opis = "用阿鲁纳恰尔邦换取现金投资";
				number_uslovie = 3;
				uslovie_bool[0] = a.influencePRC >= 500;
				uslovie_text[0] = "中国影响力至少50.0";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 250;
				uslovie_text[1] = "预算中的资金至少25.0";
				uslovie_bool[2] = a.CBIndia;
				uslovie_text[2] = "仍有未解决的领土争端";
			}
			else if (this_type == 71)
			{
				if (selected_country == 11)
				{
					this_opis = "Send PLA reinforcements to the war|Strenth of our forces: " + a.data[39] / 10 + "." + Mathf.Abs(a.data[39] % 10);
				}
				else if (selected_country == 19)
				{
					this_opis = "Send PLA reinforcements to the war|Strenth of our forces: " + a.data[40] / 10 + "." + Mathf.Abs(a.data[40] % 10);
				}
				number_uslovie = 3;
				uslovie_bool[0] = a.war == 2;
				uslovie_text[0] = "正在发生战争 with India";
				uslovie_bool[1] = a.data[22] >= 70;
				uslovie_text[1] = "军事实力至少7";
				uslovie_bool[2] = a.allcountries[selected_country].prcpower == 0;
				uslovie_text[2] = "尚未汇款 this month";
			}
			else if (this_type == 31)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 3;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = "阿尔巴尼亚亲华";
				uslovie_bool[1] = a.allcountries[1].econ || (a.allcountries[1].isSEV && a.SovAlb);
				uslovie_text[1] = "Union founded or 中国在经互会中 and Soviet-Albanian relations restored";
				uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
				uslovie_text[2] = "他们不是经济联盟成员";
				if (a.allcountries[selected_country].Vyshi)
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[selected_country].Vyshi;
					uslovie_text[3] = "该国不受美国影响";
				}
			}
			else if (this_type == 32)
			{
				this_opis = "促使恢复与苏联的关系";
				number_uslovie = 4;
				uslovie_bool[0] = a.relres;
				uslovie_text[0] = "苏中关系恢复";
				uslovie_bool[1] = a.data[6] > 790 || a.allcountries[7].Torg;
				uslovie_text[1] = "外交声誉高于79 OR we are an observer in the CMEA";
				uslovie_bool[2] = a.data[60] > 0;
				uslovie_text[2] = "霍查已死或被架空";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "双方关系尚未恢复";
			}
			else if (this_type == 33)
			{
				this_opis = "签署友好协议";
				number_uslovie = 2;
				uslovie_bool[0] = a.data[6] < 800;
				uslovie_text[0] = "外交声望低于80";
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "尚未签署";
				if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
				{
					number_uslovie = 3;
					uslovie_bool[2] = !a.allcountries[7].isNATO;
					uslovie_text[2] = GlobalScript.inst.other_text[105];
				}
			}
			else if (this_type == 34)
			{
				this_opis = "邀请外资投资者";
				number_uslovie = 3;
				if (a.allcountries[21].Gosstroy == 1 && selected_country == 21)
				{
					uslovie_bool[0] = a.data[6] >= 600;
					uslovie_text[0] = "外交声望高于60";
				}
				else
				{
					uslovie_bool[0] = a.data[6] < 600;
					uslovie_text[0] = "外交声望低于60";
				}
				if (a.allcountries[21].Gosstroy == 1 && selected_country == 21)
				{
					uslovie_bool[1] = a.data[16] < 13 || a.SEZ;
					uslovie_text[1] = "Economy - \"State monopolism\" and more socialist or opened FEZ";
				}
				else
				{
					uslovie_bool[1] = a.data[16] >= 13 || a.SEZ;
					uslovie_text[1] = "Economy - \"bird-cage\" and more liberal or opened the SEZ";
				}
				uslovie_bool[2] = a.allcountries[selected_country].stab == 0;
				uslovie_text[2] = "今年未吸引到";
			}
			else if (this_type == 35)
			{
				this_opis = "建立密切友谊";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[6] > 690;
				uslovie_text[0] = "外交声望超过69";
				uslovie_bool[1] = a.data[9] >= 30;
				uslovie_text[1] = "至少3 代理网络";
				if (!a.allcountries[11].proprc)
				{
					uslovie_bool[2] = a.allcountries[11].Torg && a.vietnampeace;
					uslovie_text[2] = "未挑起与越南的战争，并与其开展贸易";
				}
				else
				{
					uslovie_bool[2] = a.allcountries[11].proprc && a.allcountries[34].proprc && a.allcountries[23].proprc;
					uslovie_text[2] = "越南、柬埔寨（高棉）和泰国亲华";
				}
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "尚未趋同";
			}
			else if (this_type == 36)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = "老挝亲华";
				uslovie_bool[1] = a.allcountries[selected_country].Torg;
				uslovie_text[1] = "开展贸易";
				uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
				uslovie_text[2] = "他们不是经济联盟成员";
				uslovie_bool[3] = a.allcountries[1].econ || a.allcountries[1].isSEV;
				uslovie_text[3] = "Union founded or 中国在经互会中";
			}
			else if (this_type == 37)
			{
				this_opis = "组织由胡宁、侯宥恩和凯乌·桑潘三人领导的兵变，\n逮捕并推翻波尔布特";
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = "柬埔寨（高棉）亲华";
				uslovie_bool[1] = a.data[38] == 100;
				uslovie_text[1] = "毛泽东逝世";
				uslovie_bool[2] = a.allcountries[selected_country].stab == 0 && a.allcountries[selected_country].Gosstroy != 1;
				uslovie_text[2] = "未予支持";
				uslovie_bool[3] = a.data[8] + a.data[9] >= 30;
				uslovie_text[3] = "代理网络与资金不少于3";
			}
			else if (this_type == 38)
			{
				this_opis = "支持纳赛尔旧总统的拥护者";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[6] > 690;
				uslovie_text[0] = "外交声望超过69";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = "预算500万";
				uslovie_bool[2] = !a.event_done[37];
				uslovie_text[2] = "趁我们还能做到";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "未予支持";
			}
			else if (this_type == 39)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].Torg;
				uslovie_text[0] = "开展贸易";
				uslovie_bool[1] = a.OAR;
				uslovie_text[1] = "阿联共和国成立";
				uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
				uslovie_text[2] = "他们不是经济联盟成员";
				uslovie_bool[3] = a.allcountries[1].econ || a.allcountries[1].isSEV;
				uslovie_text[3] = "Union founded or 中国在经互会中";
			}
			else if (this_type == 40)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 4;
				uslovie_bool[0] = !a.allcountries[selected_country].Vyshi;
				uslovie_text[0] = "巴基斯坦并不亲美";
				uslovie_bool[1] = !a.allcountries[19].Torg || a.allcountries[selected_country].proprc;
				uslovie_text[1] = "未与印度或布托——首相——实现关系正常化";
				uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].isASEAN;
				uslovie_text[2] = "他们不是经济联盟成员";
				uslovie_bool[3] = a.allcountries[1].econ || a.allcountries[1].isSEV;
				uslovie_text[3] = "Union founded or 中国在经互会中";
			}
			else if (this_type == 41)
			{
				this_opis = "加入军事同盟";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[22] >= 20;
				uslovie_text[0] = "军事实力至少2";
				uslovie_bool[1] = (a.allcountries[selected_country].econ || a.allcountries[selected_country].isSEV) && (a.allcountries[1].okb || a.allcountries[1].isOVD);
				uslovie_text[1] = "巴基斯坦是经济联盟成员，同盟已形成，或我们在华沙条约组织（WP）内";
				uslovie_bool[2] = !a.allcountries[selected_country].okb && !a.allcountries[selected_country].isOVD && !a.allcountries[selected_country].isSEATO && !a.allcountries[selected_country].isSENTO;
				uslovie_text[2] = "他们不在军事同盟中";
				uslovie_bool[3] = a.allcountries[selected_country].econ || a.allcountries[selected_country].isSEV;
				uslovie_text[3] = "他们是经济联盟成员";
			}
			else if (this_type == 42)
			{
				this_opis = "拨付经济复苏援助";
				number_uslovie = 2;
				uslovie_bool[0] = a.data[8] + a.data[36] >= 80;
				uslovie_text[0] = "预算800万";
				uslovie_bool[1] = a.allcountries[selected_country].stab == 0;
				uslovie_text[1] = "尚未汇款 help";
			}
			else if (this_type == 43)
			{
				this_opis = "支持泰国共产党人";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 40;
				uslovie_text[0] = "至少4 代理网络";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 20;
				uslovie_text[1] = "预算200万";
				uslovie_bool[2] = !a.TaiCoup;
				uslovie_text[2] = "泰国政变尚未成真";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "未予支持";
			}
			else if (this_type == 44)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 4;
				if (selected_country == 52)
				{
					uslovie_bool[0] = a.allcountries[selected_country].spec > 0;
					uslovie_text[0] = GlobalScript.inst.other_text[474];
				}
				else
				{
					uslovie_bool[0] = a.allcountries[selected_country].Gosstroy == 1;
					uslovie_text[0] = "共产党胜利";
				}
				uslovie_bool[1] = a.allcountries[selected_country].Torg;
				uslovie_text[1] = "开展贸易";
				uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
				uslovie_text[2] = "他们不是经济联盟成员";
				uslovie_bool[3] = a.allcountries[1].econ || a.allcountries[1].isSEV;
				uslovie_text[3] = "Union founded or 中国在经互会中";
			}
			else if (this_type == 45)
			{
				this_opis = "就该国加入阿联共和国进行谈判";
				if (selected_country != 40 && selected_country != 35)
				{
					number_uslovie = 2;
				}
				else
				{
					number_uslovie = 4;
				}
				uslovie_bool[0] = a.OAR;
				uslovie_text[0] = "阿联共和国成立";
				uslovie_bool[1] = !a.allcountries[selected_country].oar;
				uslovie_text[1] = "该国不在阿联共和国内";
				if (selected_country == 40 || selected_country == 35)
				{
					uslovie_bool[2] = !a.allcountries[selected_country].Vyshi;
					uslovie_text[2] = GlobalScript.inst.other_text[91];
					uslovie_bool[3] = !a.allcountries[selected_country].isOVD && !a.allcountries[selected_country].okb;
					uslovie_text[3] = GlobalScript.inst.other_text[322];
				}
			}
			else if (this_type == 46)
			{
				this_opis = "在我们的斡旋下谈判巴勒斯坦的地位";
				number_uslovie = 2;
				uslovie_bool[0] = a.Israellost;
				uslovie_text[0] = "以色列在黎巴嫩战争中失利";
				uslovie_bool[1] = a.allcountries[selected_country].dev == 0;
				uslovie_text[1] = "尚未谈判";
			}
			else if (this_type == 47)
			{
				this_opis = "谈判以实现关系正常化";
				number_uslovie = 3;
				uslovie_bool[0] = a.data[6] < 550;
				uslovie_text[0] = "外交声誉低于55";
				uslovie_bool[1] = a.allcountries[51].Torg;
				uslovie_text[1] = "与美国存在合同";
				uslovie_bool[2] = !a.allcountries[selected_country].Torg;
				uslovie_text[2] = "尚未谈判";
			}
			else if (this_type == 48)
			{
				this_opis = "开始解放边境诸岛";
				number_uslovie = 3;
				uslovie_bool[0] = a.data[22] >= 500;
				uslovie_text[0] = "军事实力至少50";
				uslovie_bool[1] = !a.allcountries[51].Torg;
				uslovie_text[1] = "尚未实现关系正常化";
				uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
				uslovie_text[2] = "尚未安排入侵";
			}
			else if (this_type == 49)
			{
				this_opis = "把钱转入中共秘密账户";
				number_uslovie = 2;
				if (!a.allcountries[selected_country].proprc)
				{
					uslovie_bool[0] = a.data[8] + a.data[36] >= 100;
					uslovie_text[0] = "预算1000万";
				}
				else
				{
					uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
					uslovie_text[0] = "预算500万";
				}
				uslovie_bool[1] = a.allcountries[39].dev == 0;
				uslovie_text[1] = "每月一次";
				if (GlobalScript.inst.dlc[6])
				{
					number_uslovie = 3;
					uslovie_bool[2] = !a.IsBankAccountFreezed;
					uslovie_text[2] = GlobalScript.inst.new_texts[895];
				}
			}
			else if (this_type == 51)
			{
				this_opis = "消灭宫本健治并夺回对JCP的控制权";
				number_uslovie = 3;
				uslovie_bool[0] = a.data[9] >= 50;
				uslovie_text[0] = "至少5 代理网络";
				uslovie_bool[1] = a.data[6] >= 690;
				uslovie_text[1] = "外交声望超过69";
				uslovie_bool[2] = a.allcountries[selected_country].stab == 0;
				uslovie_text[2] = "尚未清除";
			}
			else if (this_type == 52)
			{
				this_opis = "开始深度贸易";
				number_uslovie = 3;
				if (a.allcountries[selected_country].Gosstroy == 1)
				{
					uslovie_bool[0] = a.data[6] >= 800;
					uslovie_text[0] = "外交声誉不低于80";
				}
				else if (a.allcountries[selected_country].Gosstroy <= 2)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
					uslovie_text[0] = "外交声望在39到85之间";
				}
				else if (a.allcountries[selected_country].Gosstroy == 3)
				{
					uslovie_bool[0] = a.data[6] < 500;
					uslovie_text[0] = "外交声望低于50";
				}
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "未开展贸易";
				uslovie_bool[2] = a.data[12] >= 800;
				uslovie_text[2] = "工业不低于80";
				if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[7].isNATO;
					uslovie_text[3] = GlobalScript.inst.other_text[105];
				}
			}
			else if (this_type == 53)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 3;
				if (selected_country != 94 && selected_country != 95 && selected_country != 84 && selected_country != 14 && selected_country != 35)
				{
					uslovie_bool[0] = a.allcountries[selected_country].Torg && a.allcountries[selected_country].Gosstroy <= 2;
					uslovie_text[0] = "开展贸易 and pro-chinese coalition in power";
				}
				else
				{
					uslovie_bool[0] = a.allcountries[selected_country].Torg;
					uslovie_text[0] = "开展贸易 ";
				}
				if (selected_country == 27 || selected_country == 39 || selected_country == 88 || selected_country == 0 || selected_country == 29 || selected_country == 89 || selected_country == 90 || selected_country == 91 || selected_country == 28 || (selected_country == 26 && !a.allcountries[26].prosov))
				{
					uslovie_bool[0] = a.allcountries[selected_country].cw;
					uslovie_text[0] = "支持其中一个派系";
				}
				uslovie_bool[1] = a.allcountries[1].econ || a.allcountries[1].isSEV;
				uslovie_text[1] = "Union founded or 中国在经互会中";
				uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
				uslovie_text[2] = "他们不是经济联盟成员";
				if (selected_country == 94)
				{
					number_uslovie = 4;
					uslovie_bool[3] = a.allcountries[selected_country].SubGosstroy == 4;
					uslovie_text[3] = GlobalScript.inst.other_text[118];
				}
				if (selected_country == 14 || selected_country == 35)
				{
					number_uslovie = 4;
					uslovie_bool[3] = a.allcountries[selected_country].Gosstroy == 1 || a.allcountries[selected_country].proprc;
					uslovie_text[3] = GlobalScript.inst.other_text[313];
				}
				if (a.allcountries[selected_country].Vyshi)
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[selected_country].Vyshi;
					uslovie_text[3] = "该国不受美国影响";
				}
			}
			else if (this_type == 54)
			{
				this_opis = "接纳进入经济联盟";
				number_uslovie = 3;
				uslovie_bool[0] = a.allcountries[selected_country].Gosstroy == 2;
				uslovie_text[0] = "左翼联盟掌权";
				uslovie_bool[1] = a.allcountries[1].econ || a.allcountries[1].isSEV;
				uslovie_text[1] = "Union founded or 中国在经互会中";
				uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
				uslovie_text[2] = "他们不是经济联盟成员";
				if (a.allcountries[selected_country].Vyshi)
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[selected_country].Vyshi;
					uslovie_text[3] = "该国不受美国影响";
				}
			}
			else if (this_type == 55)
			{
				this_opis = "施加经济与政治压力";
				number_uslovie = 4;
				uslovie_bool[0] = (a.allcountries[11].econ && a.allcountries[34].econ && a.allcountries[47].econ) || (a.allcountries[11].isSEV && a.allcountries[34].isSEV && a.allcountries[47].isSEV) || (a.allcountries[11].isASEAN && a.allcountries[34].isASEAN && a.allcountries[47].isASEAN);
				uslovie_text[0] = "越南、泰国和菲律宾与我们同盟";
				uslovie_bool[1] = a.data[9] >= 40;
				uslovie_text[1] = "至少4 代理网络";
				uslovie_bool[2] = a.SKRebel;
				uslovie_text[2] = "支持光州起义";
				if (a.ingamewars[0].is_going)
				{
					uslovie_bool[3] = !a.ingamewars[0].is_going;
					uslovie_text[3] = "该国未处于战争状态";
				}
				else
				{
					uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
					uslovie_text[3] = "尚未施加";
				}
			}
			else if (this_type == 56)
			{
				this_opis = "Support the Maoists.|Maoist power: " + a.data[37] / 10 + "." + Mathf.Abs(a.data[37] % 10);
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 40;
				uslovie_text[0] = "至少4 代理网络";
				uslovie_bool[1] = a.data[22] >= 30;
				uslovie_text[1] = "军事实力至少3";
				uslovie_bool[2] = a.data[6] >= 750;
				uslovie_text[2] = "外交声望超过75";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0 && a.data[37] < 1000;
				uslovie_text[3] = "未予支持 this year";
			}
			else if (this_type == 57)
			{
				this_opis = "助燃反种族隔离的抗议升级";
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 100;
				uslovie_text[0] = "至少9 代理网络";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 100;
				uslovie_text[1] = "预算1000万";
				uslovie_bool[2] = a.data[21] >= 1980;
				uslovie_text[2] = "不早于1980年";
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "尚未助燃";
			}
			else if (this_type == 58)
			{
				this_opis = "实施制裁 on the right-wing dictatorship";
				number_uslovie = 3;
				if (selected_country == 52)
				{
					uslovie_bool[0] = (a.allcountries[47].econ && a.allcountries[50].econ && a.allcountries[49].econ) || (a.allcountries[47].isSEV && a.allcountries[50].isSEV && a.allcountries[49].isSEV) || (a.allcountries[11].isASEAN && a.allcountries[34].isASEAN && a.allcountries[49].isASEAN);
					uslovie_text[0] = "印尼、菲律宾和马来西亚同属一个经济联盟";
				}
				else
				{
					uslovie_bool[0] = (a.allcountries[11].econ && a.allcountries[34].econ && a.allcountries[49].econ) || (a.allcountries[11].isSEV && a.allcountries[34].isSEV && a.allcountries[49].isSEV) || (a.allcountries[11].isASEAN && a.allcountries[34].isASEAN && a.allcountries[49].isASEAN);
					uslovie_text[0] = "越南、泰国和马来西亚同属一个经济联盟";
				}
				if (selected_country == 52)
				{
					uslovie_bool[1] = a.data[8] + a.data[36] >= 80;
					uslovie_text[1] = "预算800万";
				}
				else
				{
					uslovie_bool[1] = a.data[8] + a.data[36] >= 40;
					uslovie_text[1] = "预算400万";
				}
				uslovie_bool[2] = a.allcountries[selected_country].stab == 0;
				uslovie_text[2] = "尚未施压";
				if (selected_country == 52)
				{
					number_uslovie = 4;
					uslovie_bool[3] = a.influencePRC >= 700 && ((a.allcountries[1].isSEV && !a.allcountries[52].isSEV) || (a.allcountries[1].econ && !a.allcountries[52].econ) || (a.allcountries[1].isASEAN && !a.allcountries[52].isASEAN));
					uslovie_text[3] = GlobalScript.inst.other_text[467];
				}
			}
			else if (this_type == 60)
			{
				this_opis = "签署友好合作协议";
				number_uslovie = 3;
				uslovie_bool[0] = a.empires[0].relations > 700;
				uslovie_text[0] = "同美国关系高于70";
				uslovie_bool[1] = a.data[6] < 500;
				uslovie_text[1] = "外交声望低于50";
				if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
				{
					uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12);
					uslovie_text[2] = "未袭击其盟友";
				}
				else if (!a.allcountries[selected_country].Torg)
				{
					uslovie_bool[2] = a.war <= 0;
					uslovie_text[2] = "我们未处于战争状态";
				}
				else
				{
					uslovie_bool[2] = !a.allcountries[selected_country].Torg;
					uslovie_text[2] = "尚未签署";
				}
			}
			else if (this_type == 61)
			{
				this_opis = "开始与美国中央情报局合作";
				number_uslovie = 3;
				uslovie_bool[0] = a.empires[0].relations > 800;
				uslovie_text[0] = "同美国关系高于80";
				uslovie_bool[1] = a.data[6] < 600;
				uslovie_text[1] = "外交声望低于60";
				if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
				{
					uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12);
					uslovie_text[2] = "未袭击其盟友";
				}
				else if (a.allcountries[selected_country].dev == 0)
				{
					uslovie_bool[2] = a.war <= 0;
					uslovie_text[2] = "我们未处于战争状态";
				}
				else
				{
					uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
					uslovie_text[2] = "尚未合作";
				}
			}
			else if (this_type == 62)
			{
				number_uslovie = 4;
				if (a.allcountries[selected_country].proprc)
				{
					this_opis = "资助该政权";
					uslovie_bool[2] = a.allcountries[selected_country].stab < 1000;
					uslovie_text[2] = "稳定度低于100";
					this_opis = this_opis + "|Stability: " + a.allcountries[selected_country].stab / 10 + "." + Mathf.Abs(a.allcountries[selected_country].stab % 10);
					uslovie_bool[0] = a.data[9] >= 100;
					uslovie_text[0] = "至少10 代理网络";
					uslovie_bool[1] = a.data[8] + a.data[36] >= 40;
					uslovie_text[1] = "预算400万";
					uslovie_bool[3] = a.data[22] >= 80;
					uslovie_text[3] = "8个军团";
				}
				else
				{
					this_opis = "支持亲华势力";
					uslovie_bool[2] = a.allcountries[selected_country].prcpower < 1000;
					uslovie_text[2] = "亲华势力实力低于100";
					this_opis = this_opis + "|pro-chinese power: " + a.allcountries[selected_country].prcpower / 10 + "." + Mathf.Abs(a.allcountries[selected_country].prcpower % 10);
					uslovie_bool[0] = a.data[9] >= 80;
					uslovie_text[0] = "至少8 代理网络";
					uslovie_bool[1] = a.data[8] + a.data[36] >= 40;
					uslovie_text[1] = "预算400万";
					uslovie_bool[3] = a.data[22] >= 100;
					uslovie_text[3] = "10个军团";
				}
			}
			else if (this_type == 63)
			{
				this_opis = "组织与亲苏势力的联盟";
				this_opis = this_opis + "|power of pro-soviet: " + a.allcountries[selected_country].sovpower / 10 + "." + Mathf.Abs(a.allcountries[selected_country].sovpower % 10);
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 20;
				uslovie_text[0] = "至少2个特工网络";
				uslovie_bool[1] = a.data[6] > 690;
				uslovie_text[1] = "外交声望超过69";
				uslovie_bool[2] = !a.allcountries[selected_country].usalliance && !a.allcountries[selected_country].sovalliance;
				uslovie_text[2] = "不结盟";
				uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].proprc;
				uslovie_text[3] = "该国既不亲苏也不亲华";
			}
			else if (this_type == 64)
			{
				this_opis = "组织与亲美势力的联盟";
				this_opis = this_opis + "|power of pro-american: " + a.allcountries[selected_country].usapower / 10 + "." + Mathf.Abs(a.allcountries[selected_country].usapower % 10);
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 20;
				uslovie_text[0] = "至少2个特工网络";
				uslovie_bool[1] = a.data[6] < 500;
				uslovie_text[1] = "外交声望低于50";
				uslovie_bool[2] = !a.allcountries[selected_country].usalliance && !a.allcountries[selected_country].sovalliance;
				uslovie_text[2] = "不结盟";
				uslovie_bool[3] = !a.allcountries[selected_country].Vyshi && !a.allcountries[selected_country].proprc;
				uslovie_text[3] = "该国既不亲美也不亲华";
			}
			else if (this_type == 65)
			{
				this_opis = "煽动动乱以推翻政府";
				number_uslovie = 2;
				uslovie_bool[0] = a.allcountries[selected_country].prcpower > 300;
				uslovie_text[0] = "亲华势力超过30";
				uslovie_bool[1] = !a.allcountries[selected_country].proprc;
				uslovie_text[1] = "该国不亲华";
			}
			else if (this_type == 66)
			{
				if (!a.allcountries[selected_country].Torg)
				{
					this_opis = "启动资源开采（独家权利）";
				}
				else
				{
					this_opis = "停止资源开采（独家权利）";
				}
				this_opis = this_opis + "|Stability: " + a.allcountries[selected_country].stab / 10 + "." + Mathf.Abs(a.allcountries[selected_country].stab % 10);
				number_uslovie = 1;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = "该国亲华";
			}
			else if (this_type == 70)
			{
				this_opis = "支持ZAPU";
				number_uslovie = 3;
				uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
				uslovie_text[0] = "预算500万";
				uslovie_bool[1] = a.event_done[88];
				uslovie_text[1] = "ZAPU赢得选举";
				uslovie_bool[2] = !a.allcountries[selected_country].Torg;
				uslovie_text[2] = "未予支持";
			}
			else if (this_type == 82)
			{
				this_opis = GlobalScript.inst.other_text[29];
				number_uslovie = 3;
				uslovie_bool[0] = a.allcountries[selected_country].level_of_unstab - a.allcountries[selected_country].level_of_dev > 0;
				uslovie_text[0] = GlobalScript.inst.other_text[33];
				uslovie_bool[1] = !a.allcountries[selected_country].proprc;
				uslovie_text[1] = GlobalScript.inst.other_text[34];
				uslovie_bool[2] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50 && a.data[22] >= 50;
				uslovie_text[2] = GlobalScript.inst.other_text[35];
			}
			else if (this_type == 83)
			{
				this_opis = GlobalScript.inst.other_text[30];
				number_uslovie = 3;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = GlobalScript.inst.other_text[39];
				uslovie_bool[1] = a.allcountries[selected_country].Gosstroy == 2;
				uslovie_text[1] = GlobalScript.inst.other_text[40];
				uslovie_bool[2] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50 && a.data[22] >= 50;
				uslovie_text[2] = GlobalScript.inst.other_text[35];
			}
			else if (this_type == 84)
			{
				this_opis = GlobalScript.inst.other_text[31];
				number_uslovie = 3;
				uslovie_bool[0] = a.science[19];
				uslovie_text[0] = GlobalScript.inst.other_text[42];
				uslovie_bool[1] = !a.allcountries[selected_country].proprc;
				uslovie_text[1] = GlobalScript.inst.other_text[34];
				uslovie_bool[2] = a.data[8] + a.data[36] >= 20 && a.data[9] >= 20 && a.data[22] >= 20;
				uslovie_text[2] = GlobalScript.inst.other_text[53];
			}
			else if (this_type == 85)
			{
				this_opis = GlobalScript.inst.other_text[32];
				number_uslovie = 3;
				uslovie_bool[0] = a.science[20];
				uslovie_text[0] = GlobalScript.inst.other_text[43];
				uslovie_bool[1] = !a.allcountries[selected_country].proprc;
				uslovie_text[1] = GlobalScript.inst.other_text[34];
				uslovie_bool[2] = a.data[8] + a.data[36] >= 20 && a.data[9] >= 20 && a.data[22] >= 20;
				uslovie_text[2] = GlobalScript.inst.other_text[53];
			}
			else if (this_type == 86)
			{
				this_opis = GlobalScript.inst.other_text[47];
				number_uslovie = 3;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = GlobalScript.inst.other_text[39];
				uslovie_bool[1] = a.allcountries[selected_country].Torg;
				uslovie_text[1] = GlobalScript.inst.other_text[46];
				uslovie_bool[2] = a.data[8] + a.data[36] >= 35 && a.data[9] >= 35 && a.data[22] >= 35;
				uslovie_text[2] = GlobalScript.inst.other_text[41];
			}
			else if (this_type == 87)
			{
				this_opis = GlobalScript.inst.other_text[48];
				number_uslovie = 3;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = GlobalScript.inst.other_text[39];
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = GlobalScript.inst.other_text[44];
				uslovie_bool[2] = a.data[12] >= 500 && a.data[13] >= 500;
				uslovie_text[2] = GlobalScript.inst.other_text[45];
			}
			else if (this_type == 88)
			{
				this_opis = GlobalScript.inst.other_text[49];
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = GlobalScript.inst.other_text[39];
				uslovie_bool[1] = a.allcountries[selected_country].Torg;
				uslovie_text[1] = GlobalScript.inst.other_text[46];
				uslovie_bool[2] = a.influencePRC >= 150 && a.allcountries[selected_country].level_of_dev - a.allcountries[selected_country].level_of_unstab >= 30;
				uslovie_text[2] = GlobalScript.inst.other_text[50];
				uslovie_bool[3] = (a.allcountries[1].econ || a.allcountries[1].isSEV) && !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
				uslovie_text[3] = ((a.allcountries[1].econ || a.allcountries[1].isSEV) ? GlobalScript.inst.other_text[51] : GlobalScript.inst.other_text[52]);
			}
			else if (this_type == 91)
			{
				this_opis = GlobalScript.inst.other_text[58];
				number_uslovie = 4;
				uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
				uslovie_text[0] = string.Format(GlobalScript.inst.other_text[60], 5);
				uslovie_bool[1] = a.data[9] >= 30;
				uslovie_text[1] = string.Format(GlobalScript.inst.other_text[61], 3);
				if (!a.event_done[366])
				{
					uslovie_bool[2] = (a.data[20] > 4 && a.data[21] >= 1977) || a.data[21] > 1977;
					uslovie_text[2] = GlobalScript.inst.other_text[62];
				}
				else
				{
					uslovie_bool[2] = !a.event_done[367];
					uslovie_text[2] = GlobalScript.inst.other_text[63];
				}
				if (!a.event_done[366])
				{
					uslovie_bool[3] = !a.event_done[366];
					uslovie_text[3] = GlobalScript.inst.other_text[64];
				}
				else
				{
					uslovie_bool[3] = a.resultOfEvents[366] != 0 && a.resultOfEvents[366] != 1;
					uslovie_text[3] = GlobalScript.inst.other_text[64];
				}
			}
			else if (this_type == 92)
			{
				this_opis = GlobalScript.inst.other_text[59];
				number_uslovie = 4;
				uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
				uslovie_text[0] = string.Format(GlobalScript.inst.other_text[60], 5);
				uslovie_bool[1] = a.data[9] >= 30;
				uslovie_text[1] = string.Format(GlobalScript.inst.other_text[61], 3);
				if (!a.event_done[366])
				{
					uslovie_bool[2] = (a.data[20] > 4 && a.data[21] >= 1977) || a.data[21] > 1977;
					uslovie_text[2] = GlobalScript.inst.other_text[62];
				}
				else
				{
					uslovie_bool[2] = !a.event_done[367];
					uslovie_text[2] = GlobalScript.inst.other_text[63];
				}
				if (!a.event_done[366])
				{
					uslovie_bool[3] = !a.event_done[366];
					uslovie_text[3] = GlobalScript.inst.other_text[64];
				}
				else
				{
					uslovie_bool[3] = a.resultOfEvents[366] != 0 && a.resultOfEvents[366] != 1;
					uslovie_text[3] = GlobalScript.inst.other_text[64];
				}
			}
			else if (this_type == 93)
			{
				this_opis = "开始深度贸易";
				number_uslovie = 4;
				if (a.allcountries[selected_country].Gosstroy == 1)
				{
					uslovie_bool[0] = a.data[6] >= 800;
					uslovie_text[0] = "外交声誉不低于80";
				}
				else if (a.allcountries[selected_country].Gosstroy <= 2)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
					uslovie_text[0] = "外交声望在39到85之间";
				}
				else
				{
					uslovie_bool[0] = a.data[6] < 500;
					uslovie_text[0] = "外交声望低于50";
				}
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "未开展贸易";
				uslovie_bool[2] = a.data[12] >= 500;
				uslovie_text[2] = "工业水平不低于50";
				uslovie_bool[3] = a.Israellost;
				uslovie_text[3] = "以色列在黎巴嫩战争中失利";
			}
			else if (this_type == 94)
			{
				this_opis = GlobalScript.inst.other_text[66];
				number_uslovie = 2;
				uslovie_bool[0] = a.data[124] >= 1;
				uslovie_text[0] = GlobalScript.inst.other_text[67];
				uslovie_bool[1] = a.data[124] != 100;
				uslovie_text[1] = GlobalScript.inst.other_text[68];
			}
			else if (this_type == 95)
			{
				this_opis = GlobalScript.inst.other_text[69];
				number_uslovie = 3;
				uslovie_bool[0] = a.data[127] >= 1 || a.allcountries[84].Gosstroy == 2;
				uslovie_text[0] = GlobalScript.inst.other_text[70];
				uslovie_bool[1] = a.data[127] != 100;
				uslovie_text[1] = GlobalScript.inst.other_text[68];
				uslovie_bool[2] = a.data[21] >= 1983;
				uslovie_text[2] = GlobalScript.inst.other_text[71];
				uslovie_bool[3] = !a.ingamewars[8].is_going;
				uslovie_text[3] = GlobalScript.inst.other_text[72];
			}
			else if (this_type == 96)
			{
				this_opis = "开始深度贸易";
				number_uslovie = 3;
				number_uslovie = 3;
				uslovie_bool[0] = !a.allcountries[selected_country].Torg;
				uslovie_text[0] = "未开展贸易";
				uslovie_bool[1] = a.data[12] >= 500;
				uslovie_text[1] = "工业水平不低于50";
				uslovie_bool[2] = !a.ingamewars[8].is_going;
				uslovie_text[2] = GlobalScript.inst.other_text[72];
			}
			else if (this_type == 97)
			{
				this_opis = GlobalScript.inst.other_text[74];
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[19].proprc && ((a.allcountries[19].okb && a.allcountries[19].econ) || (a.allcountries[19].isSEV && a.allcountries[19].isOVD) || a.allcountries[19].isNATO);
				uslovie_text[0] = GlobalScript.inst.other_text[75];
				uslovie_bool[1] = a.influencePRC > 600;
				uslovie_text[1] = GlobalScript.inst.other_text[76];
				uslovie_bool[2] = a.data[8] + a.data[36] >= 200 && a.data[9] >= 200;
				uslovie_text[2] = GlobalScript.inst.other_text[77];
				uslovie_bool[3] = !a.allcountries[selected_country].proprc;
				uslovie_text[3] = GlobalScript.inst.other_text[78];
			}
			else if (this_type == 98)
			{
				this_opis = GlobalScript.inst.other_text[81];
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].Torg;
				uslovie_text[0] = GlobalScript.inst.other_text[83];
				uslovie_bool[1] = a.influencePRC > 700;
				uslovie_text[1] = GlobalScript.inst.other_text[86];
				uslovie_bool[2] = a.allcountries[1].isSEV || a.allcountries[1].econ;
				uslovie_text[2] = GlobalScript.inst.other_text[84];
				uslovie_bool[3] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].isASEAN;
				uslovie_text[3] = GlobalScript.inst.other_text[88];
			}
			else if (this_type == 99)
			{
				this_opis = GlobalScript.inst.other_text[82];
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].isSEV || a.allcountries[selected_country].econ;
				uslovie_text[0] = GlobalScript.inst.other_text[90];
				uslovie_bool[1] = a.influencePRC > 800;
				uslovie_text[1] = GlobalScript.inst.other_text[87];
				uslovie_bool[2] = a.allcountries[1].isSEV || a.allcountries[1].econ || a.allcountries[1].isNATO;
				uslovie_text[2] = GlobalScript.inst.other_text[84];
				uslovie_bool[3] = !a.allcountries[selected_country].okb && !a.allcountries[selected_country].isSEATO && !a.allcountries[selected_country].isOVD;
				uslovie_text[3] = GlobalScript.inst.other_text[89];
			}
			else if (this_type == 100)
			{
				number_uslovie = 3;
				this_opis = GlobalScript.inst.other_text[107];
				uslovie_bool[0] = a.influencePRC >= 700;
				uslovie_text[0] = GlobalScript.inst.other_text[86];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 150 && a.data[9] >= 150;
				uslovie_text[1] = GlobalScript.inst.other_text[108];
				uslovie_bool[2] = a.allcountries[selected_country].dev <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[109];
				if (a.allcountries[7].isNATO)
				{
					number_uslovie = 4;
					uslovie_bool[3] = !a.allcountries[7].isNATO;
					uslovie_text[3] = GlobalScript.inst.other_text[105];
				}
			}
			else if (this_type == 101)
			{
				number_uslovie = 4;
				this_opis = GlobalScript.inst.other_text[81];
				uslovie_bool[0] = a.allcountries[selected_country].based;
				uslovie_text[0] = GlobalScript.inst.other_text[169];
				uslovie_bool[1] = a.allcountries[selected_country].Torg;
				uslovie_text[1] = GlobalScript.inst.other_text[83];
				uslovie_bool[2] = !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].econ;
				uslovie_text[2] = GlobalScript.inst.other_text[88];
				uslovie_bool[3] = a.allcountries[1].isSEV || a.allcountries[1].econ;
				uslovie_text[3] = GlobalScript.inst.other_text[84];
			}
			else if (this_type == 102)
			{
				this_opis = "开始深度贸易";
				number_uslovie = 4;
				if (a.allcountries[selected_country].Gosstroy == 1)
				{
					uslovie_bool[0] = a.data[6] >= 690;
					uslovie_text[0] = "外交声望超过69";
				}
				else if (a.allcountries[selected_country].Gosstroy <= 2)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
					uslovie_text[0] = "外交声望在39到85之间";
				}
				else if (a.allcountries[selected_country].Gosstroy == 3)
				{
					uslovie_bool[0] = a.data[6] < 500;
					uslovie_text[0] = "外交声望低于50";
				}
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "未开展贸易";
				uslovie_bool[2] = a.data[12] >= 500;
				uslovie_text[2] = "工业水平不低于50";
				uslovie_bool[3] = a.allcountries[selected_country].parts[0];
				uslovie_text[3] = GlobalScript.inst.other_text[117];
			}
			else if (this_type == 103)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[122], GlobalScript.inst.other_text[123], (float)a.allcountries[selected_country].inflCh / 10f, GlobalScript.inst.other_text[124], (float)a.allcountries[selected_country].inflNATO / 10f, '\n');
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].inflCh < 1000;
				uslovie_text[0] = GlobalScript.inst.other_text[127];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 100;
				uslovie_text[1] = GlobalScript.inst.other_text[128];
				uslovie_bool[2] = a.data[9] >= 50;
				uslovie_text[2] = GlobalScript.inst.other_text[129];
				uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi;
				uslovie_text[3] = GlobalScript.inst.other_text[130];
			}
			else if (this_type == 104)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[126], GlobalScript.inst.other_text[123], (float)a.allcountries[selected_country].inflCh / 10f, GlobalScript.inst.other_text[124], (float)a.allcountries[selected_country].inflNATO / 10f, '\n');
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].inflCh >= 350;
				uslovie_text[0] = GlobalScript.inst.other_text[125];
				uslovie_bool[1] = !a.allcountries[selected_country].econ;
				uslovie_text[1] = GlobalScript.inst.other_text[88];
				uslovie_bool[2] = a.allcountries[selected_country].Torg;
				uslovie_text[2] = GlobalScript.inst.other_text[83];
				uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi;
				uslovie_text[3] = GlobalScript.inst.other_text[130];
			}
			else if (this_type == 105)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[132], GlobalScript.inst.other_text[123], (float)a.allcountries[selected_country].inflCh / 10f, GlobalScript.inst.other_text[124], (float)a.allcountries[selected_country].inflNATO / 10f, '\n');
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].inflCh >= 600;
				uslovie_text[0] = GlobalScript.inst.other_text[133];
				uslovie_bool[1] = !a.allcountries[selected_country].based && a.allcountries[selected_country].econ;
				uslovie_text[1] = GlobalScript.inst.other_text[134];
				uslovie_bool[2] = a.data[22] >= 250;
				uslovie_text[2] = GlobalScript.inst.other_text[135];
				uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi;
				uslovie_text[3] = GlobalScript.inst.other_text[130];
			}
			else if (this_type == 106)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[136], GlobalScript.inst.other_text[123], (float)a.allcountries[selected_country].inflCh / 10f, GlobalScript.inst.other_text[124], (float)a.allcountries[selected_country].inflNATO / 10f, '\n');
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].inflCh >= 900;
				uslovie_text[0] = GlobalScript.inst.other_text[138];
				uslovie_bool[1] = a.allcountries[selected_country].based && !a.allcountries[selected_country].okb;
				uslovie_text[1] = GlobalScript.inst.other_text[137];
				uslovie_bool[2] = a.data[7] > a.empires[0].power + a.empires[1].power;
				uslovie_text[2] = GlobalScript.inst.other_text[139];
				uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi;
				uslovie_text[3] = GlobalScript.inst.other_text[130];
			}
			else if (this_type == 107)
			{
				if (!a.modifies[41].active)
				{
					this_opis = GlobalScript.inst.other_text[141];
					number_uslovie = 4;
					uslovie_bool[0] = a.data[6] < 600 && a.data[21] > 1979;
					uslovie_text[0] = GlobalScript.inst.other_text[142];
					uslovie_bool[1] = a.allcountries[30].Vyshi && (a.allcountries[8].Gosstroy == 3 || a.allcountries[8].Vyshi);
					uslovie_text[1] = GlobalScript.inst.other_text[143];
					uslovie_bool[2] = !a.allcountries[1].isSEV && a.science[19];
					uslovie_text[2] = GlobalScript.inst.other_text[144];
					uslovie_bool[3] = (a.data[131] == 0 || a.data[131] == 3) && !a.modifies[41].active;
					uslovie_text[3] = GlobalScript.inst.other_text[145];
				}
				else
				{
					this_opis = GlobalScript.inst.other_text[146];
					number_uslovie = 1;
					uslovie_bool[0] = a.modifies[41].active;
					uslovie_text[0] = GlobalScript.inst.other_text[147];
				}
			}
			else if (this_type == 108)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[152], '\n', (float)a.data[134] / 10f);
				number_uslovie = 4;
				uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
				uslovie_text[0] = string.Format(GlobalScript.inst.other_text[60], 5);
				uslovie_bool[1] = a.data[22] >= 50;
				uslovie_text[1] = string.Format(GlobalScript.inst.other_text[156], 5);
				uslovie_bool[2] = a.data[134] < 1000 && a.data[134] >= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[150];
				uslovie_bool[3] = !a.event_done[396];
				uslovie_text[3] = GlobalScript.inst.other_text[303];
			}
			else if (this_type == 109)
			{
				this_opis = GlobalScript.inst.other_text[153];
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 150;
				uslovie_text[0] = string.Format(GlobalScript.inst.other_text[60], 15);
				uslovie_bool[1] = a.data[22] >= 150;
				uslovie_text[1] = string.Format(GlobalScript.inst.other_text[156], 15);
				uslovie_bool[2] = a.data[134] >= 1000;
				uslovie_text[2] = GlobalScript.inst.other_text[155];
				uslovie_bool[3] = !a.event_done[396] && a.empires[0].power + a.empires[1].power < 350;
				uslovie_text[3] = GlobalScript.inst.other_text[151];
			}
			else if (this_type == 110)
			{
				number_uslovie = 4;
				if (selected_country == 41)
				{
					this_opis = string.Format(GlobalScript.inst.other_text[159], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
				}
				else if (selected_country == 99)
				{
					this_opis = string.Format(GlobalScript.inst.other_text[167], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
				}
				else if (selected_country == 100)
				{
					this_opis = string.Format(GlobalScript.inst.other_text[163], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
				}
				uslovie_bool[0] = a.allcountries[selected_country].inflCh < 1000;
				uslovie_text[0] = GlobalScript.inst.other_text[170];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = GlobalScript.inst.other_text[171];
				uslovie_bool[2] = a.data[22] >= 50;
				uslovie_text[2] = GlobalScript.inst.other_text[172];
				uslovie_bool[3] = !a.allcountries[selected_country].based;
				uslovie_text[3] = GlobalScript.inst.other_text[173];
			}
			else if (this_type == 111)
			{
				number_uslovie = 4;
				if (selected_country == 41)
				{
					this_opis = string.Format(GlobalScript.inst.other_text[160], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
				}
				else if (selected_country == 99)
				{
					this_opis = string.Format(GlobalScript.inst.other_text[168], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
				}
				else if (selected_country == 100)
				{
					this_opis = string.Format(GlobalScript.inst.other_text[164], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
				}
				uslovie_bool[0] = a.allcountries[selected_country].inflNATO < 1000;
				uslovie_text[0] = GlobalScript.inst.other_text[174];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = GlobalScript.inst.other_text[171];
				uslovie_bool[2] = a.data[22] >= 50;
				uslovie_text[2] = GlobalScript.inst.other_text[172];
				uslovie_bool[3] = !a.allcountries[selected_country].based;
				uslovie_text[3] = GlobalScript.inst.other_text[173];
			}
			else if (this_type == 112)
			{
				number_uslovie = 3;
				this_opis = GlobalScript.inst.other_text[82];
				uslovie_bool[0] = a.allcountries[selected_country].isSEV || a.allcountries[selected_country].econ;
				uslovie_text[0] = GlobalScript.inst.other_text[90];
				uslovie_bool[1] = a.allcountries[selected_country].Torg && a.allcountries[selected_country].proprc;
				uslovie_text[1] = GlobalScript.inst.other_text[175];
				uslovie_bool[2] = !a.allcountries[selected_country].okb && !a.allcountries[selected_country].isOVD && (a.allcountries[1].isOVD || a.allcountries[1].okb);
				uslovie_text[2] = GlobalScript.inst.other_text[85];
			}
			else if (this_type == 113)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[177], '\n', a.allcountries[selected_country].inflNATO);
				uslovie_bool[0] = a.data[8] + a.data[36] >= 30 && a.data[9] >= 30;
				uslovie_text[0] = GlobalScript.inst.other_text[178];
				uslovie_bool[1] = !a.modifies[3].active;
				uslovie_text[1] = GlobalScript.inst.other_text[179];
				uslovie_bool[2] = a.allcountries[selected_country].spec <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[180];
				uslovie_bool[3] = a.data[21] < 1981;
				uslovie_text[3] = GlobalScript.inst.other_text[181];
			}
			else if (this_type == 114)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.other_text[185], '\n');
				uslovie_bool[0] = a.modifies[48].active;
				uslovie_text[0] = GlobalScript.inst.other_text[187];
				uslovie_bool[1] = a.allcountries[1].inflNATO <= 0;
				uslovie_text[1] = GlobalScript.inst.other_text[180];
				uslovie_bool[2] = a.allcountries[1].dev <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[189];
			}
			else if (this_type == 115)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.other_text[186], '\n');
				uslovie_bool[0] = a.modifies[47].active;
				uslovie_text[0] = GlobalScript.inst.other_text[188];
				uslovie_bool[1] = a.allcountries[1].inflCh <= 0;
				uslovie_text[1] = GlobalScript.inst.other_text[180];
				uslovie_bool[2] = a.allcountries[1].dev <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[189];
			}
			else if (this_type == 116)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[325], '\n');
				uslovie_bool[0] = a.influencePRC + a.empires[0].power >= a.empires[1].power || a.influencePRC >= 1000;
				uslovie_text[0] = GlobalScript.inst.other_text[326];
				uslovie_bool[1] = !a.allcountries[2].isOVD && !a.allcountries[5].isOVD && !a.allcountries[4].isOVD;
				uslovie_text[1] = GlobalScript.inst.other_text[327];
				uslovie_bool[2] = a.empires[1].now_leader == 6;
				uslovie_text[2] = GlobalScript.inst.other_text[328];
				uslovie_bool[3] = a.allcountries[17].dev <= 0;
				uslovie_text[3] = GlobalScript.inst.other_text[194];
			}
			else if (this_type == 117)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[196], '\n');
				uslovie_bool[0] = a.allcountries[1].Gosstroy != 1 && a.data[52] > 34;
				uslovie_text[0] = GlobalScript.inst.other_text[197];
				uslovie_bool[1] = !a.allcountries[1].isSEV && !a.allcountries[1].econ;
				uslovie_text[1] = GlobalScript.inst.other_text[198];
				if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
				{
					uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12);
					uslovie_text[2] = "未袭击其盟友";
				}
				else if (!a.allcountries[1].isASEAN)
				{
					uslovie_bool[2] = a.war <= 0;
					uslovie_text[2] = "我们未处于战争状态";
				}
				else
				{
					uslovie_bool[2] = !a.allcountries[1].isASEAN;
					uslovie_text[2] = GlobalScript.inst.other_text[199];
				}
				uslovie_bool[3] = a.data[21] > 1978;
				uslovie_text[3] = GlobalScript.inst.other_text[200];
			}
			else if (this_type == 118)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.other_text[202], '\n');
				uslovie_bool[0] = a.allcountries[1].isASEAN;
				uslovie_text[0] = GlobalScript.inst.other_text[203];
				uslovie_bool[1] = !a.allcountries[15].cw;
				uslovie_text[1] = GlobalScript.inst.other_text[204];
				if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
				{
					uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12);
					uslovie_text[2] = "未袭击其盟友";
				}
				else if (!a.allcountries[1].isSEATO)
				{
					uslovie_bool[2] = a.war <= 0;
					uslovie_text[2] = "我们未处于战争状态";
				}
				else
				{
					uslovie_bool[2] = !a.allcountries[1].isSEATO;
					uslovie_text[2] = GlobalScript.inst.other_text[199];
				}
			}
			else if (this_type == 119)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[206], '\n');
				uslovie_bool[0] = a.allcountries[1].isASEAN;
				uslovie_text[0] = GlobalScript.inst.other_text[203];
				uslovie_bool[1] = !a.allcountries[selected_country].prosov;
				uslovie_text[1] = GlobalScript.inst.other_text[207];
				uslovie_bool[2] = !a.allcountries[selected_country].isASEAN && !a.allcountries[selected_country].isSEV;
				uslovie_text[2] = GlobalScript.inst.other_text[208];
				if (selected_country != 38)
				{
					uslovie_bool[3] = a.allcountries[selected_country].Gosstroy != 1;
					uslovie_text[3] = GlobalScript.inst.other_text[209];
				}
				else
				{
					uslovie_bool[3] = a.data[64] == 1 || a.completedDecisions[6];
					uslovie_text[3] = GlobalScript.inst.other_text[233];
				}
			}
			else if (this_type == 120)
			{
				number_uslovie = 3;
				if (!a.allcountries[51].cw)
				{
					this_opis = string.Format(GlobalScript.inst.other_text[210], '\n');
				}
				else
				{
					this_opis = string.Format(GlobalScript.inst.other_text[211], '\n');
				}
				uslovie_bool[0] = a.allcountries[1].isASEAN;
				if (!a.allcountries[51].cw)
				{
					uslovie_text[0] = GlobalScript.inst.other_text[212];
				}
				else
				{
					uslovie_text[0] = GlobalScript.inst.other_text[213];
				}
				uslovie_bool[1] = a.allcountries[selected_country].isASEAN;
				uslovie_text[1] = GlobalScript.inst.other_text[214];
				uslovie_bool[2] = !a.allcountries[selected_country].isSEATO && !a.allcountries[selected_country].isOVD;
				uslovie_text[2] = GlobalScript.inst.other_text[215];
				if (selected_country == 8 || selected_country == 12 || selected_country == 14 || selected_country == 35 || selected_country == 36 || selected_country == 31 || selected_country == 37 || selected_country == 25 || selected_country == 104)
				{
					number_uslovie = 4;
					uslovie_bool[3] = a.allcountries[51].cw;
					uslovie_text[3] = GlobalScript.inst.other_text[216];
				}
			}
			else if (this_type == 121)
			{
				if (selected_country == 24)
				{
					this_opis = GlobalScript.inst.other_text[218];
				}
				else
				{
					this_opis = GlobalScript.inst.other_text[206];
				}
				number_uslovie = 4;
				uslovie_bool[0] = a.allcountries[selected_country].Torg;
				uslovie_text[0] = GlobalScript.inst.other_text[83];
				if (selected_country == 24)
				{
					uslovie_bool[1] = a.allcountries[1].isSEV || a.allcountries[selected_country].proprc;
					uslovie_text[1] = GlobalScript.inst.other_text[220];
				}
				else
				{
					uslovie_bool[1] = a.allcountries[1].isASEAN;
					uslovie_text[1] = GlobalScript.inst.other_text[203];
				}
				uslovie_bool[2] = !a.allcountries[selected_country].isASEAN && !a.allcountries[selected_country].isSEV;
				uslovie_text[2] = GlobalScript.inst.other_text[88];
				uslovie_bool[3] = a.allcountries[selected_country].parts[0];
				uslovie_text[3] = GlobalScript.inst.other_text[219];
			}
			else if (this_type == 122)
			{
				this_opis = GlobalScript.inst.other_text[221];
				number_uslovie = 3;
				uslovie_bool[0] = a.data[9] >= 100 && a.data[8] + a.data[36] >= 300;
				uslovie_text[0] = GlobalScript.inst.other_text[222];
				uslovie_bool[1] = a.event_done[91] && a.allcountries[46].Gosstroy == 0;
				uslovie_text[1] = GlobalScript.inst.other_text[223];
				uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
				uslovie_text[2] = GlobalScript.inst.other_text[224];
			}
			else if (this_type == 123)
			{
				this_opis = GlobalScript.inst.other_text[227];
				number_uslovie = 4;
				uslovie_bool[0] = a.data[9] >= 50 && a.data[8] + a.data[36] >= 30;
				uslovie_text[0] = GlobalScript.inst.other_text[228];
				uslovie_bool[1] = !a.modifies[6].active;
				uslovie_text[1] = GlobalScript.inst.other_text[229];
				uslovie_bool[2] = a.data[6] <= 750;
				uslovie_text[2] = GlobalScript.inst.other_text[230];
				if (a.empires[1].power < 50)
				{
					uslovie_bool[3] = a.empires[1].power >= 50;
					uslovie_text[3] = GlobalScript.inst.other_text[231];
				}
				else
				{
					uslovie_bool[3] = !a.war_active[1];
					uslovie_text[3] = GlobalScript.inst.other_text[232];
				}
			}
			else if (this_type == 124)
			{
				number_uslovie = 2;
				this_opis = GlobalScript.inst.other_text[235];
				uslovie_bool[0] = a.allcountries[1].isSEV || a.allcountries[1].isASEAN;
				uslovie_text[0] = GlobalScript.inst.other_text[236];
				uslovie_bool[1] = !a.allcountries[1].based;
				uslovie_text[1] = GlobalScript.inst.other_text[237];
			}
			else if (this_type == 125)
			{
				number_uslovie = 4;
				if (a.allcountries[1].isSEATO)
				{
					this_opis = GlobalScript.inst.other_text[239];
				}
				else
				{
					this_opis = GlobalScript.inst.other_text[252];
				}
				uslovie_bool[0] = a.allcountries[selected_country].prcinfl >= 800;
				uslovie_text[0] = GlobalScript.inst.other_text[284];
				uslovie_bool[1] = a.data[9] >= 100 && a.data[8] + a.data[36] >= 50;
				uslovie_text[1] = GlobalScript.inst.other_text[241];
				if (a.allcountries[1].isSEATO)
				{
					uslovie_bool[2] = a.empires[0].relations >= 700;
					uslovie_text[2] = GlobalScript.inst.other_text[242];
				}
				else
				{
					uslovie_bool[2] = a.empires[1].relations >= 700;
					uslovie_text[2] = GlobalScript.inst.other_text[253];
				}
				uslovie_bool[3] = !a.allcountries[selected_country].perevorot;
				uslovie_text[3] = GlobalScript.inst.other_text[237];
			}
			else if (this_type == 126)
			{
				number_uslovie = 4;
				this_opis = GlobalScript.inst.other_text[245];
				uslovie_bool[0] = a.allcountries[11].isSEATO && a.allcountries[34].isSEATO && a.allcountries[23].isSEATO;
				uslovie_text[0] = GlobalScript.inst.other_text[246];
				uslovie_bool[1] = a.influencePRC + a.empires[0].power >= a.empires[1].power;
				uslovie_text[1] = GlobalScript.inst.other_text[247];
				uslovie_bool[2] = a.data[8] + a.data[36] >= 100 && a.data[9] >= 100 && a.data[2] >= 250;
				uslovie_text[2] = GlobalScript.inst.other_text[248];
				uslovie_bool[3] = !a.allcountries[selected_country].cw;
				uslovie_text[3] = GlobalScript.inst.other_text[249];
			}
			else if (this_type == 127)
			{
				number_uslovie = 4;
				this_opis = GlobalScript.inst.other_text[257];
				uslovie_bool[0] = a.data[131] == 3;
				uslovie_text[0] = GlobalScript.inst.other_text[258];
				uslovie_bool[1] = a.influencePRC >= a.empires[0].power;
				uslovie_text[1] = GlobalScript.inst.other_text[259];
				uslovie_bool[2] = !a.allcountries[85].isNATO && !a.allcountries[45].isNATO && !a.allcountries[87].isNATO && !a.allcountries[85].isEU && !a.allcountries[45].isEU && !a.allcountries[87].isEU;
				uslovie_text[2] = GlobalScript.inst.other_text[260];
				uslovie_bool[3] = a.allcountries[21].isNATO;
				uslovie_text[3] = GlobalScript.inst.other_text[261];
			}
			else if (this_type == 128)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[264], '\n', a.allcountries[87].spec);
				uslovie_bool[0] = a.allcountries[87].spec < 100;
				uslovie_text[0] = GlobalScript.inst.other_text[266];
				uslovie_bool[1] = a.data[8] + a.data[36] >= a.allcountries[87].inflCh && a.data[9] >= a.allcountries[87].inflNATO;
				uslovie_text[1] = string.Format(GlobalScript.inst.other_text[267], (float)a.allcountries[87].inflNATO / 10f, (float)a.allcountries[87].inflCh / 10f);
				uslovie_bool[2] = a.allcountries[87].Gosstroy != 3;
				uslovie_text[2] = GlobalScript.inst.other_text[269];
				if (!a.event_done[414])
				{
					uslovie_bool[3] = a.event_done[414];
					uslovie_text[3] = GlobalScript.inst.other_text[268];
				}
				else
				{
					uslovie_bool[3] = a.data[21] < 1982 && !a.allcountries[87].based;
					uslovie_text[3] = GlobalScript.inst.other_text[265];
				}
			}
			else if (this_type == 129)
			{
				number_uslovie = 4;
				this_opis = GlobalScript.inst.other_text[271];
				uslovie_bool[0] = (a.allcountries[1].econ && a.allcountries[11].econ && a.allcountries[34].econ && a.allcountries[47].econ) || (a.allcountries[1].isSEV && a.allcountries[11].isSEV && a.allcountries[34].isSEV && a.allcountries[47].isSEV) || (a.allcountries[1].isASEAN && a.allcountries[11].isASEAN && a.allcountries[34].isASEAN && a.allcountries[47].isASEAN);
				uslovie_text[0] = GlobalScript.inst.other_text[272];
				uslovie_bool[1] = !a.allcountries[1].isASEAN;
				uslovie_text[1] = GlobalScript.inst.other_text[273];
				uslovie_bool[2] = a.allcountries[49].isASEAN;
				uslovie_text[2] = GlobalScript.inst.other_text[274];
				if (!a.allcountries[1].isSEV)
				{
					uslovie_bool[3] = a.influencePRC >= 300 && a.data[8] + a.data[36] >= 150;
					uslovie_text[3] = GlobalScript.inst.other_text[275];
				}
				else
				{
					uslovie_bool[3] = a.influencePRC + a.empires[1].power >= 300 && a.data[8] + a.data[36] >= 150;
					uslovie_text[3] = GlobalScript.inst.other_text[276];
				}
			}
			else if (this_type == 130)
			{
				number_uslovie = 3;
				if (a.allcountries[selected_country].sovinfl > 1000)
				{
					a.allcountries[selected_country].sovinfl = 1000;
				}
				if (a.allcountries[selected_country].sovinfl < 0)
				{
					a.allcountries[selected_country].sovinfl = 0;
				}
				if (a.allcountries[selected_country].prcinfl > 1000)
				{
					a.allcountries[selected_country].prcinfl = 1000;
				}
				if (a.allcountries[selected_country].prcinfl < 0)
				{
					a.allcountries[selected_country].prcinfl = 0;
				}
				this_opis = string.Format(GlobalScript.inst.other_text[278], '\n', (float)a.allcountries[selected_country].sovinfl / 10f, (float)a.allcountries[selected_country].prcinfl / 10f);
				uslovie_bool[0] = a.allcountries[selected_country].prosov || (!a.allcountries[selected_country].proprc && !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi);
				uslovie_text[0] = GlobalScript.inst.other_text[279];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50 && a.data[22] >= 80;
				uslovie_text[1] = GlobalScript.inst.other_text[280];
				uslovie_bool[2] = a.allcountries[selected_country].prcinfl < 1000;
				uslovie_text[2] = GlobalScript.inst.other_text[281];
			}
			else if (this_type == 131)
			{
				number_uslovie = 3;
				if (a.allcountries[selected_country].usainfl > 1000)
				{
					a.allcountries[selected_country].usainfl = 1000;
				}
				if (a.allcountries[selected_country].usainfl < 0)
				{
					a.allcountries[selected_country].usainfl = 0;
				}
				if (a.allcountries[selected_country].prcinfl > 1000)
				{
					a.allcountries[selected_country].prcinfl = 1000;
				}
				if (a.allcountries[selected_country].prcinfl < 0)
				{
					a.allcountries[selected_country].prcinfl = 0;
				}
				this_opis = string.Format(GlobalScript.inst.other_text[282], '\n', (float)a.allcountries[selected_country].usainfl / 10f, (float)a.allcountries[selected_country].prcinfl / 10f);
				uslovie_bool[0] = a.allcountries[selected_country].Vyshi || (!a.allcountries[selected_country].proprc && !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi);
				uslovie_text[0] = GlobalScript.inst.other_text[283];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50 && a.data[22] >= 80;
				uslovie_text[1] = GlobalScript.inst.other_text[280];
				uslovie_bool[2] = a.allcountries[selected_country].prcinfl < 1000;
				uslovie_text[2] = GlobalScript.inst.other_text[281];
			}
			else if (this_type == 132)
			{
				number_uslovie = 3;
				this_opis = GlobalScript.inst.other_text[286];
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = GlobalScript.inst.other_text[287];
				uslovie_bool[1] = a.allcountries[selected_country].SubGosstroy != a.allcountries[1].SubGosstroy;
				uslovie_text[1] = GlobalScript.inst.other_text[288];
				uslovie_bool[2] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50;
				uslovie_text[2] = GlobalScript.inst.other_text[289];
			}
			else if (this_type == 133)
			{
				number_uslovie = 4;
				this_opis = GlobalScript.inst.other_text[294];
				uslovie_bool[0] = a.allcountries[36].cw && a.allcountries[14].puppetOf <= 0;
				uslovie_text[0] = GlobalScript.inst.other_text[295];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 250 && a.data[9] >= 150 && a.data[22] >= 350;
				uslovie_text[1] = GlobalScript.inst.other_text[296];
				if (a.allcountries[1].okb)
				{
					uslovie_bool[2] = a.influencePRC >= a.empires[0].power + a.empires[1].power;
					uslovie_text[2] = GlobalScript.inst.other_text[297];
				}
				else if (a.allcountries[1].isOVD)
				{
					uslovie_bool[2] = a.influencePRC + a.empires[1].power >= a.empires[0].power;
					uslovie_text[2] = GlobalScript.inst.other_text[300];
				}
				else if (a.allcountries[1].isSEATO)
				{
					uslovie_bool[2] = a.influencePRC + a.empires[0].power >= a.empires[1].power;
					uslovie_text[2] = GlobalScript.inst.other_text[301];
				}
				else
				{
					uslovie_bool[2] = a.allcountries[1].okb || a.allcountries[1].isSEATO || a.allcountries[1].isOVD;
					uslovie_text[2] = GlobalScript.inst.other_text[302];
				}
				uslovie_bool[3] = !a.allcountries[14].cw;
				uslovie_text[3] = GlobalScript.inst.other_text[298];
			}
			else if (this_type == 134)
			{
				if (!a.allcountries[selected_country].dota)
				{
					number_uslovie = 2;
					this_opis = string.Format("{0}{1}{3}:{2}; {5}: {4}", GlobalScript.inst.other_text[304], '\n', a.allcountries[1].isSEATO ? ((float)a.allcountries[selected_country].usainfl / 10f) : ((float)a.allcountries[selected_country].sovinfl / 10f), a.allcountries[1].isSEATO ? GlobalScript.inst.new_texts[167] : GlobalScript.inst.new_texts[168], (float)a.allcountries[selected_country].prcinfl / 10f, GlobalScript.inst.new_events_text[1214]);
					uslovie_bool[0] = a.allcountries[selected_country].proprc;
					uslovie_text[0] = GlobalScript.inst.other_text[287];
					uslovie_bool[1] = !a.allcountries[selected_country].dota;
					uslovie_text[1] = GlobalScript.inst.other_text[305];
				}
				else
				{
					number_uslovie = 1;
					this_opis = string.Format("{0}{1}{3}: {2}; {5}: {4}", GlobalScript.inst.other_text[306], '\n', a.allcountries[1].isSEATO ? ((float)a.allcountries[selected_country].usainfl / 10f) : ((float)a.allcountries[selected_country].sovinfl), a.allcountries[1].isSEATO ? GlobalScript.inst.new_texts[167] : GlobalScript.inst.new_texts[168], (float)a.allcountries[selected_country].prcinfl / 10f, GlobalScript.inst.new_events_text[1214]);
					uslovie_bool[0] = a.allcountries[selected_country].proprc;
					uslovie_text[0] = GlobalScript.inst.other_text[307];
				}
			}
			else if (this_type == 135)
			{
				if (!a.modifies[53].active)
				{
					this_opis = GlobalScript.inst.other_text[311];
					number_uslovie = 4;
					uslovie_bool[0] = a.relres;
					uslovie_text[0] = GlobalScript.inst.other_text[312];
					uslovie_bool[1] = a.allcountries[1].Gosstroy == 1 || a.allcountries[1].proprc;
					uslovie_text[1] = GlobalScript.inst.other_text[313];
					uslovie_bool[2] = !a.allcountries[1].isASEAN && a.science[19];
					uslovie_text[2] = GlobalScript.inst.other_text[315];
					uslovie_bool[3] = !a.modifies[41].active;
					uslovie_text[3] = GlobalScript.inst.other_text[314];
				}
				else
				{
					this_opis = GlobalScript.inst.other_text[316];
					number_uslovie = 1;
					uslovie_bool[0] = a.modifies[53].active;
					uslovie_text[0] = GlobalScript.inst.other_text[317];
				}
			}
			else if (this_type == 136)
			{
				this_opis = GlobalScript.inst.other_text[318];
				number_uslovie = 3;
				uslovie_bool[0] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50;
				uslovie_text[0] = GlobalScript.inst.other_text[319];
				uslovie_bool[1] = a.data[21] < 1978 || (a.data[21] == 1978 && a.data[20] < 11);
				uslovie_text[1] = GlobalScript.inst.other_text[320];
				uslovie_bool[2] = !a.allcountries[86].based;
				uslovie_text[2] = GlobalScript.inst.other_text[321];
			}
			else if (this_type == 137)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[330], '\n');
				uslovie_bool[0] = a.influencePRC >= a.empires[0].power + a.empires[1].power;
				uslovie_text[0] = GlobalScript.inst.other_text[331];
				uslovie_bool[1] = !a.modifies[17].active && !a.modifies[16].active && a.empires[0].relations >= 900 && a.empires[1].relations >= 900;
				uslovie_text[1] = GlobalScript.inst.other_text[332];
				uslovie_bool[2] = (a.empires[1].now_leader == 6 && a.empires[0].now_leader == 3) || a.allcountries[21].isSocEU;
				uslovie_text[2] = GlobalScript.inst.other_text[333];
				uslovie_bool[3] = a.allcountries[17].dev <= 0;
				uslovie_text[3] = GlobalScript.inst.other_text[194];
			}
			else if (this_type == 138)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[335], '\n');
				int num2 = 0;
				if (a.allcountries[21].Gosstroy == 1)
				{
					num2++;
				}
				if (a.allcountries[85].Gosstroy == 1)
				{
					num2++;
				}
				if (a.allcountries[86].Gosstroy == 1)
				{
					num2++;
				}
				if (a.allcountries[87].Gosstroy == 1)
				{
					num2++;
				}
				if (a.allcountries[92].Gosstroy == 1)
				{
					num2++;
				}
				uslovie_bool[0] = num2 >= 3;
				uslovie_text[0] = GlobalScript.inst.other_text[336];
				uslovie_bool[1] = a.relres;
				uslovie_text[1] = GlobalScript.inst.other_text[337];
				uslovie_bool[2] = !a.allcountries[17].isNATO && !a.allcountries[17].isEU;
				uslovie_text[2] = GlobalScript.inst.other_text[338];
				uslovie_bool[3] = a.allcountries[17].dev <= 0;
				uslovie_text[3] = GlobalScript.inst.other_text[194];
			}
			else if (this_type == 139)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.other_text[427], '\n');
				uslovie_bool[0] = a.influencePRC >= a.empires[0].power + a.empires[1].power || a.influencePRC >= 800;
				uslovie_text[0] = GlobalScript.inst.other_text[428];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 150;
				uslovie_text[1] = GlobalScript.inst.other_text[429];
				uslovie_bool[2] = a.allcountries[18].spec <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[430];
			}
			else if (this_type == 140)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.other_text[431], '\n');
				uslovie_bool[0] = a.influencePRC >= a.empires[0].power + a.empires[1].power || a.influencePRC >= 800;
				uslovie_text[0] = GlobalScript.inst.other_text[428];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 150;
				uslovie_text[1] = GlobalScript.inst.other_text[429];
				uslovie_bool[2] = a.allcountries[18].spec <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[430];
			}
			else if (this_type == 141)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.other_text[432], '\n');
				uslovie_bool[0] = a.influencePRC >= a.empires[0].power + a.empires[1].power || a.influencePRC >= 800;
				uslovie_text[0] = GlobalScript.inst.other_text[428];
				uslovie_bool[1] = a.data[8] + a.data[36] >= 150;
				uslovie_text[1] = GlobalScript.inst.other_text[429];
				uslovie_bool[2] = a.allcountries[18].spec <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[430];
			}
			else if (this_type == 142)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[448], '\n', GlobalScript.inst.gameState.allcountries[selected_country].name, (float)GlobalScript.inst.gameState.allcountries[selected_country].inflCh / 10f);
				uslovie_bool[0] = a.data[22] >= 50;
				uslovie_text[0] = GlobalScript.inst.other_text[449];
				uslovie_bool[1] = a.allcountries[selected_country].sovinfl <= 0;
				uslovie_text[1] = GlobalScript.inst.other_text[450];
				uslovie_bool[2] = a.allcountries[selected_country].inflCh < 1000;
				uslovie_text[2] = GlobalScript.inst.other_text[452];
				uslovie_bool[3] = a.event_done[418];
				uslovie_text[3] = GlobalScript.inst.other_text[451];
			}
			else if (this_type == 143)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[453], '\n', GlobalScript.inst.gameState.allcountries[selected_country].name, (float)GlobalScript.inst.gameState.allcountries[selected_country].inflCh / 10f);
				uslovie_bool[0] = a.data[9] >= 50;
				uslovie_text[0] = GlobalScript.inst.other_text[454];
				uslovie_bool[1] = a.allcountries[selected_country].usainfl <= 0;
				uslovie_text[1] = GlobalScript.inst.other_text[450];
				uslovie_bool[2] = a.allcountries[selected_country].inflCh < 1000;
				uslovie_text[2] = GlobalScript.inst.other_text[452];
				uslovie_bool[3] = a.event_done[418];
				uslovie_text[3] = GlobalScript.inst.other_text[451];
			}
			else if (this_type == 144)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[455], '\n', GlobalScript.inst.gameState.allcountries[selected_country].name, (float)GlobalScript.inst.gameState.allcountries[selected_country].inflCh / 10f);
				uslovie_bool[0] = a.data[8] + a.data[36] >= 30;
				uslovie_text[0] = GlobalScript.inst.other_text[456];
				uslovie_bool[1] = a.allcountries[selected_country].prcinfl <= 0;
				uslovie_text[1] = GlobalScript.inst.other_text[450];
				uslovie_bool[2] = a.allcountries[selected_country].inflCh < 1000;
				uslovie_text[2] = GlobalScript.inst.other_text[452];
				uslovie_bool[3] = a.event_done[418];
				uslovie_text[3] = GlobalScript.inst.other_text[451];
			}
			else if (this_type == 145)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[460], '\n', (a.data[143] + 5 <= 60) ? (a.data[143] + 5) : 60);
				int num3 = 0;
				for (int num4 = 101; num4 < 107; num4++)
				{
					if (a.allcountries[num4].proprc)
					{
						num3++;
					}
				}
				if (a.allcountries[36].proprc)
				{
					num3++;
				}
				uslovie_bool[0] = num3 >= 3;
				uslovie_text[0] = GlobalScript.inst.other_text[461];
				uslovie_bool[1] = a.data[9] >= 50;
				uslovie_text[1] = GlobalScript.inst.other_text[454];
				uslovie_bool[2] = a.allcountries[36].inflNATO <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[450];
				uslovie_bool[3] = a.data[143] < 60;
				uslovie_text[3] = GlobalScript.inst.other_text[462];
			}
			else if (this_type == 146)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[463], '\n', (a.data[143] - 5 >= 10) ? (a.data[143] - 5) : 10);
				int num5 = 0;
				for (int num6 = 101; num6 < 107; num6++)
				{
					if (a.allcountries[num6].proprc)
					{
						num5++;
					}
				}
				if (a.allcountries[36].proprc)
				{
					num5++;
				}
				uslovie_bool[0] = num5 >= 3;
				uslovie_text[0] = GlobalScript.inst.other_text[461];
				uslovie_bool[1] = a.data[9] >= 50;
				uslovie_text[1] = GlobalScript.inst.other_text[454];
				uslovie_bool[2] = a.allcountries[36].inflNATO <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[450];
				uslovie_bool[3] = a.data[143] > 10;
				uslovie_text[3] = GlobalScript.inst.other_text[464];
			}
			else if (this_type == 147)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[468], '\n');
				uslovie_bool[0] = a.data[8] + a.data[36] >= 100;
				uslovie_text[0] = GlobalScript.inst.other_text[469];
				uslovie_bool[1] = a.data[9] >= 50 && a.data[22] >= 100;
				uslovie_text[1] = GlobalScript.inst.other_text[470];
				uslovie_bool[2] = a.allcountries[selected_country].stab > 0;
				uslovie_text[2] = GlobalScript.inst.other_text[471];
				uslovie_bool[3] = a.allcountries[selected_country].spec <= 0;
				uslovie_text[3] = GlobalScript.inst.other_text[472];
			}
			else if (this_type == 148)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[479], '\n');
				uslovie_bool[0] = a.data[8] + a.data[36] >= 200;
				uslovie_text[0] = GlobalScript.inst.other_text[481];
				uslovie_bool[1] = a.data[9] >= 200;
				uslovie_text[1] = GlobalScript.inst.other_text[482];
				uslovie_bool[2] = !a.allcountries[0].isNATO && !a.allcountries[0].isEU;
				uslovie_text[2] = GlobalScript.inst.other_text[483];
				uslovie_bool[3] = !a.allcountries[selected_country].cw;
				uslovie_text[3] = GlobalScript.inst.other_text[484];
			}
			else if (this_type == 149)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[480], '\n');
				uslovie_bool[0] = a.data[8] + a.data[36] >= 200;
				uslovie_text[0] = GlobalScript.inst.other_text[481];
				uslovie_bool[1] = a.data[9] >= 200;
				uslovie_text[1] = GlobalScript.inst.other_text[482];
				uslovie_bool[2] = !a.allcountries[0].isNATO && !a.allcountries[0].isEU;
				uslovie_text[2] = GlobalScript.inst.other_text[483];
				uslovie_bool[3] = !a.allcountries[selected_country].cw;
				uslovie_text[3] = GlobalScript.inst.other_text[484];
			}
			else if (this_type == 151)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[486], '\n');
				uslovie_bool[0] = a.data[8] + a.data[36] >= 200 && a.data[9] >= 200;
				uslovie_text[0] = GlobalScript.inst.other_text[77];
				uslovie_bool[1] = a.allcountries[45].econ && a.allcountries[15].econ && a.allcountries[5].econ;
				uslovie_text[1] = GlobalScript.inst.other_text[487];
				uslovie_bool[2] = !a.allcountries[6].isOVD;
				uslovie_text[2] = GlobalScript.inst.other_text[488];
				uslovie_bool[3] = a.allcountries[6].Gosstroy == 1;
				uslovie_text[3] = GlobalScript.inst.other_text[313];
			}
			else if (this_type == 152)
			{
				number_uslovie = 4;
				this_opis = string.Format(GlobalScript.inst.other_text[486], '\n');
				uslovie_bool[0] = a.data[8] + a.data[36] >= 200 && a.data[9] >= 200;
				uslovie_text[0] = GlobalScript.inst.other_text[77];
				uslovie_bool[1] = a.allcountries[45].econ && a.allcountries[15].econ && a.allcountries[5].econ;
				uslovie_text[1] = GlobalScript.inst.other_text[487];
				uslovie_bool[2] = !a.allcountries[3].isOVD;
				uslovie_text[2] = GlobalScript.inst.other_text[488];
				uslovie_bool[3] = a.allcountries[3].Gosstroy == 1;
				uslovie_text[3] = GlobalScript.inst.other_text[313];
			}
			else if (this_type == 153)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.new_texts[884], '\n');
				uslovie_bool[0] = a.allcountries[selected_country].Gosstroy == 0 || a.allcountries[selected_country].puppetOf == 1;
				uslovie_text[0] = GlobalScript.inst.new_texts[886];
				uslovie_bool[1] = a.allcountries[selected_country].proprc;
				uslovie_text[1] = GlobalScript.inst.new_texts[887];
				uslovie_bool[2] = a.data[167] <= 0;
				uslovie_text[2] = GlobalScript.inst.new_texts[890];
			}
			else if (this_type == 154)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.new_texts[885], '\n');
				uslovie_bool[0] = a.allcountries[selected_country].Gosstroy == 0 || a.allcountries[selected_country].Gosstroy == 1 || a.allcountries[selected_country].puppetOf == 1;
				uslovie_text[0] = GlobalScript.inst.new_texts[888];
				uslovie_bool[1] = a.allcountries[selected_country].proprc || a.allcountries[selected_country].okb;
				uslovie_text[1] = GlobalScript.inst.new_texts[889];
				uslovie_bool[2] = a.data[167] <= 0;
				uslovie_text[2] = GlobalScript.inst.new_texts[890];
			}
			else if (this_type == 155)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.new_texts[893], '\n');
				uslovie_bool[0] = a.data[168] >= 100;
				uslovie_text[0] = GlobalScript.inst.new_texts[896];
				uslovie_bool[1] = a.data[169] <= (a.data[168] + a.data[169]) / 4;
				uslovie_text[1] = GlobalScript.inst.new_texts[897];
				uslovie_bool[2] = !a.IsBankAccountFreezed;
				uslovie_text[2] = GlobalScript.inst.new_texts[895];
			}
			else if (this_type == 156)
			{
				number_uslovie = 3;
				this_opis = string.Format(GlobalScript.inst.new_texts[894], '\n');
				uslovie_bool[0] = a.data[168] >= 100;
				uslovie_text[0] = GlobalScript.inst.new_texts[896];
				uslovie_bool[1] = a.data[169] <= (a.data[168] + a.data[169]) / 4;
				uslovie_text[1] = GlobalScript.inst.new_texts[897];
				uslovie_bool[2] = !a.IsBankAccountFreezed;
				uslovie_text[2] = GlobalScript.inst.new_texts[895];
			}
		}
		else if (this_type == 2)
		{
			this_opis = "Начать операцию по захвату Гонконга и Макао";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[65] == 0;
			uslovie_text[0] = "Территории в иностранном владении";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = "В бюджете не менее 5 миллионов";
			uslovie_bool[2] = a.data[22] >= 100;
			uslovie_text[2] = "Сила армии не менее 10";
			uslovie_bool[3] = a.BritLost;
			uslovie_text[3] = "Британия проиграла Фолклендскую войну";
		}
		else if (this_type == 1)
		{
			this_opis = "Поддержать маоистские организации";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 50 && a.data[8] + a.data[36] >= 30;
			uslovie_text[0] = "Не менее 5 агентурных сетей и 3 миллионов в бюджете";
			uslovie_bool[1] = a.modifies[6].active;
			uslovie_text[1] = "Мы - гордые маоисты";
			uslovie_bool[2] = a.data[6] > 750;
			uslovie_text[2] = "Дипрепутация больше 75";
			if (selected_country == 92 || selected_country == 21 || selected_country == 17)
			{
				if (a.empires[0].power < 50)
				{
					uslovie_bool[3] = a.empires[0].power >= 50;
					uslovie_text[3] = "Западная Европа: Слишком сложно";
				}
				else
				{
					uslovie_bool[3] = !a.war_active[0];
					uslovie_text[3] = "Западная Европа: Ежегодно";
				}
			}
			else if (a.empires[1].power < 50)
			{
				uslovie_bool[3] = a.empires[1].power >= 50;
				uslovie_text[3] = "Восточная Европа: Слишком сложно";
			}
			else
			{
				uslovie_bool[3] = !a.war_active[1];
				uslovie_text[3] = "Восточная Европа: Ежегодно";
			}
		}
		else if (this_type == 3)
		{
			this_opis = "Провести переговоры с Британией и Португалией о передаче Гонконга и Макао";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 20;
			uslovie_text[0] = "Не менее 2 агентурных сетей";
			uslovie_bool[1] = a.data[21] >= 1980;
			uslovie_text[1] = "Не раньше 1980 года";
			if (!GlobalScript.inst.dlc[3])
			{
				uslovie_bool[2] = a.data[6] < 700;
				uslovie_text[2] = "Дипрепутация меньше 70 ";
			}
			else
			{
				uslovie_bool[2] = a.data[6] < 700 && a.allcountries[87].Gosstroy != 0;
				uslovie_text[2] = GlobalScript.inst.other_text[309];
			}
			uslovie_bool[3] = a.allcountries[0].dev == 0;
			uslovie_text[3] = "Не провели переговоры";
		}
		else if (this_type == 4)
		{
			if (a.data[21] < 1979 || (a.data[20] < 4 && a.data[21] == 1979))
			{
				this_opis = "Продлить договор о дружбе";
			}
			else
			{
				this_opis = "Восстановить дружеские отношения";
			}
			number_uslovie = 4;
			uslovie_bool[0] = a.data[21] >= 1979;
			uslovie_text[0] = "Не раньше 1979 года";
			if (a.data[21] < 1979 || (a.data[20] < 4 && a.data[21] == 1979))
			{
				if (a.leader.traits[0] == 0 && a.leader.traits[1] == 4 && a.leader.traits[2] == 8)
				{
					uslovie_bool[1] = a.data[1] >= 900 && a.SOV_PRC_PartiesConnection >= 100;
					uslovie_text[1] = "Поддержка Партии не менее 90 и структуры связи восстановлены (не менее 10)";
				}
				else
				{
					uslovie_bool[1] = a.data[1] >= 700 && a.SOV_PRC_PartiesConnection >= 200;
					uslovie_text[1] = "Поддержка Партии не менее 70 и структуры связи восстановлены (не менее 20)";
				}
			}
			else
			{
				uslovie_bool[1] = a.data[1] >= 900 && a.SOV_PRC_PartiesConnection >= 250;
				uslovie_text[1] = "Поддержка Партии не менее 90 и структуры связи восстановлены (не менее 25)";
			}
			uslovie_bool[2] = a.vietnampeace;
			uslovie_text[2] = "Не спровоцировали войну с Вьетнамом";
			if (!a.relres)
			{
				uslovie_bool[3] = a.empires[1].relations >= 700;
				uslovie_text[3] = "Отношения не менее 70";
			}
			else
			{
				uslovie_bool[3] = !a.relres;
				uslovie_text[3] = "Не восстановили отношения";
			}
		}
		else if (this_type == 5)
		{
			this_opis = "Вступить в СЭВ";
			number_uslovie = 4;
			if (!a.relres)
			{
				uslovie_bool[0] = a.relres;
				uslovie_text[0] = "Отношения восстановлены";
			}
			else
			{
				uslovie_bool[0] = !a.modifies[6].active || a.influencePRC < 300;
				uslovie_text[0] = "Мы не маоисты ИЛИ наше влияние меньше 30.0";
			}
			uslovie_bool[1] = !a.allcountries[51].Torg;
			uslovie_text[1] = "Нет тесных связей с США ";
			uslovie_bool[2] = a.data[6] > 690;
			uslovie_text[2] = "Дипрепутация выше 69";
			if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10))
			{
				uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10);
				uslovie_text[2] = "Не атаковали их союзников";
			}
			else if (!a.allcountries[1].isSEV)
			{
				uslovie_bool[3] = a.war <= 0;
				uslovie_text[3] = "Мы не воюем";
			}
			else
			{
				uslovie_bool[3] = !a.allcountries[1].isSEV;
				uslovie_text[3] = "Не вступили";
			}
		}
		else if (this_type == 74)
		{
			this_opis = "Стать наблюдателем в СЭВ";
			number_uslovie = 3;
			uslovie_bool[0] = a.relres;
			uslovie_text[0] = "Отношения восстановлены";
			uslovie_bool[1] = !a.allcountries[51].Torg;
			uslovie_text[1] = "Нет тесных связей с США ";
			uslovie_bool[2] = a.data[6] > 600;
			uslovie_text[2] = "Дипрепутация выше 60";
		}
		else if (this_type == 6)
		{
			this_opis = "Вступить в ОВД";
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[1].isSEV;
			uslovie_text[0] = "Вступили в СЭВ";
			uslovie_bool[1] = a.data[6] > 690;
			uslovie_text[1] = "Дипрепутация выше 69";
			if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10))
			{
				uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10);
				uslovie_text[2] = "Не атаковали их союзников";
			}
			else if (!a.allcountries[1].isOVD)
			{
				uslovie_bool[2] = a.war <= 0;
				uslovie_text[2] = "Мы не воюем";
			}
			else
			{
				uslovie_bool[2] = !a.allcountries[1].isOVD;
				uslovie_text[2] = "Не вступили";
			}
			uslovie_bool[3] = !a.allcountries[15].cw;
			uslovie_text[3] = "Не в Движении неприсоединения";
		}
		else if (this_type == 7)
		{
			this_opis = "Восстановление разрушенных структур связи|Восстановлено: " + a.SOV_PRC_PartiesConnection / 10 + "." + Mathf.Abs(a.SOV_PRC_PartiesConnection % 10);
			number_uslovie = 3;
			uslovie_bool[0] = a.data[9] >= a.SOV_PRC_PartiesConnection / 2;
			uslovie_text[0] = "Необходимо " + a.SOV_PRC_PartiesConnection / 20 + "." + Mathf.Abs(a.SOV_PRC_PartiesConnection / 2 % 10) + " агентурные сети";
			uslovie_bool[1] = a.data[8] + a.data[36] >= a.SOV_PRC_PartiesConnection / 4;
			uslovie_text[1] = "В бюджете: " + a.SOV_PRC_PartiesConnection / 40 + "." + Mathf.Abs(a.SOV_PRC_PartiesConnection / 4 % 10);
			uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
			uslovie_text[2] = "Каждый квартал";
		}
		else if (this_type == 8)
		{
			this_opis = "Поддержать выбранную силу в иранской революции";
			number_uslovie = 4;
			if (a.allcountries[selected_country].dev == 0 && a.data[43] < 1000)
			{
				uslovie_bool[0] = a.data[9] >= 60;
				uslovie_text[0] = "Необходимо 6 агентурных сетей";
			}
			else if (a.allcountries[selected_country].dev == 1 && a.data[42] < 1000)
			{
				uslovie_bool[0] = a.data[9] >= 60;
				uslovie_text[0] = "Необходимо 6 агентурных сетей";
			}
			else if (a.allcountries[selected_country].dev == 2 && a.data[44] < 1000)
			{
				uslovie_bool[0] = a.data[9] >= 60;
				uslovie_text[0] = "Необходимо 6 агентурных сетей";
			}
			else if (a.data[45] < 1000)
			{
				uslovie_bool[0] = a.data[9] >= 60;
				uslovie_text[0] = "Необходимо 6 агентурных сетей";
			}
			else
			{
				uslovie_bool[0] = a.data[9] <= -5000;
				uslovie_text[0] = "Нужна помощь";
			}
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = "5 миллионов в бюджете";
			uslovie_bool[2] = a.allcountries[selected_country].stab == 0 && a.allcountries[8].dev != 4;
			uslovie_text[2] = "Каждые 3 месяца";
			uslovie_bool[3] = a.iranrev;
			uslovie_text[3] = "Протесты начались и революция не завершилась";
		}
		else if (this_type == 9)
		{
			if (selected_country == 104)
			{
				this_opis = "Установить дипломатические отношения и начать углублённую торговлю";
			}
			else
			{
				this_opis = "Начать углублённую торговлю";
			}
			number_uslovie = 3;
			if (a.allcountries[selected_country].Gosstroy == 0)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 800;
				uslovie_text[0] = "Дипрепутация между 39 и 80";
			}
			else if (a.allcountries[selected_country].Gosstroy == 1)
			{
				uslovie_bool[0] = a.data[6] > 690;
				uslovie_text[0] = "Дипрепутация больше 69";
			}
			else if (a.allcountries[selected_country].Gosstroy == 2)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
				uslovie_text[0] = "Дипрепутация между 39 и 85";
			}
			else
			{
				uslovie_bool[0] = a.data[6] < 500;
				uslovie_text[0] = "Дипрепутация меньше 50";
			}
			if (selected_country == 34 && a.ingamewars[2].is_going)
			{
				uslovie_bool[1] = !a.ingamewars[2].is_going;
				uslovie_text[1] = "Нет гражданской войны";
			}
			else if (selected_country == 109 && a.ingamewars[31].is_going)
			{
				uslovie_bool[1] = !a.ingamewars[31].is_going;
				uslovie_text[1] = "Нет гражданской войны";
			}
			else if (selected_country == 110 && a.ingamewars[32].is_going)
			{
				uslovie_bool[1] = !a.ingamewars[32].is_going;
				uslovie_text[1] = "Нет гражданской войны";
			}
			else
			{
				uslovie_bool[1] = !a.allcountries[selected_country].Torg;
				uslovie_text[1] = "Торговля не ведётся";
			}
			if (a.allcountries[selected_country].proprc && a.allcountries[selected_country].SubGosstroy == 17)
			{
				uslovie_bool[2] = a.data[12] < 300;
				uslovie_text[2] = "Промышленность ниже 30";
			}
			else if (a.allcountries[selected_country].proprc)
			{
				uslovie_bool[2] = a.data[12] >= 300;
				uslovie_text[2] = "Промышленность не ниже 30";
			}
			else if (selected_country == 92 || selected_country == 85 || (selected_country > 87 && selected_country < 92) || selected_country == 0)
			{
				uslovie_bool[2] = a.data[12] >= 700;
				uslovie_text[2] = "Промышленность не ниже 70";
			}
			else
			{
				uslovie_bool[2] = a.data[12] >= 500;
				uslovie_text[2] = "Промышленность не ниже 50";
			}
			if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[7].isNATO;
				uslovie_text[3] = GlobalScript.inst.other_text[105];
			}
		}
		else if (this_type == 10)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 3;
			if (selected_country != 35 && selected_country != 14)
			{
				uslovie_bool[0] = a.allcountries[selected_country].Torg || a.allcountries[selected_country].proprc;
				uslovie_text[0] = "Идёт торговля или прокитайский";
			}
			else
			{
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = "Страна под влиянием КНР";
			}
			if (selected_country == 48 && a.allcountries[48].prosov)
			{
				uslovie_bool[1] = a.allcountries[1].isSEV;
				uslovie_text[1] = "Китай в СЭВ";
			}
			else
			{
				uslovie_bool[1] = a.allcountries[1].isSEV || a.allcountries[1].econ;
				uslovie_text[1] = "Союз основан или Китай в СЭВ";
			}
			uslovie_bool[2] = !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isASEAN;
			uslovie_text[2] = "Они не состоят в экономическом союзе";
			if ((a.allcountries[selected_country].Vyshi && selected_country != 48) || (a.allcountries[selected_country].usalliance && selected_country != 48))
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[selected_country].Vyshi && !a.allcountries[selected_country].usalliance;
				uslovie_text[3] = "Страна не под влиянием США";
			}
			else if (((a.allcountries[selected_country].prosov && selected_country != 48) || (a.allcountries[selected_country].sovalliance && selected_country != 48)) && !a.allcountries[1].isSEV)
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].sovalliance;
				uslovie_text[3] = "Страна не под влиянием СССР";
			}
			else if (selected_country == 8 && (a.ingamewars[3].is_going || a.ingamewars[5].is_going))
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.ingamewars[3].is_going && !a.ingamewars[5].is_going;
				uslovie_text[3] = "Не воюет и нет войны в Афганистане";
			}
			else if (selected_country == 8)
			{
				if (a.allcountries[selected_country].Gosstroy == 0)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 800;
					uslovie_text[0] = "Дипрепутация между 39 и 80";
				}
				else if (a.allcountries[selected_country].Gosstroy == 1)
				{
					uslovie_bool[0] = a.data[6] > 690;
					uslovie_text[0] = "Дипрепутация больше 69";
				}
				else if (a.allcountries[selected_country].Gosstroy == 2)
				{
					uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
					uslovie_text[0] = "Дипрепутация между 39 и 85";
				}
				else
				{
					uslovie_bool[0] = a.data[6] < 500;
					uslovie_text[0] = "Дипрепутация меньше 50";
				}
			}
			else if (selected_country == 104)
			{
				number_uslovie = 4;
				uslovie_bool[3] = GlobalScript.inst.gameState.data[85] == 3;
				uslovie_text[3] = "Создано \"Союзное государство\"";
			}
		}
		else if (this_type == 11)
		{
			this_opis = "Спровоцировать волнения за умеренные реформы";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 100;
			uslovie_text[0] = "10 агентурных сетей";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = "5 миллионов в бюджете";
			uslovie_bool[2] = a.empires[1].now_leader > 0;
			uslovie_text[2] = "Брежнев умер";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
			uslovie_text[3] = "Волнения не спровоцированы";
		}
		else if (this_type == 12)
		{
			this_opis = "Спровоцировать переворот в партии в пользу прокитайских сил";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 100 && a.data[8] + a.data[36] >= 80;
			uslovie_text[0] = "10 агентурных сетей и 8 миллионов в бюджете";
			uslovie_bool[1] = a.data[6] > 690;
			uslovie_text[1] = "Дипрепутация выше 69";
			uslovie_bool[2] = a.allcountries[selected_country].stab != 0;
			uslovie_text[2] = "Волнения спровоцированы";
			uslovie_bool[3] = !a.allcountries[selected_country].proprc;
			uslovie_text[3] = "Переворот не осуществлён";
		}
		else if (this_type == 13)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 4;
			if (GlobalScript.inst.dlc[3])
			{
				uslovie_bool[0] = a.allcountries[selected_country].inflCh <= 0 && a.guns && a.allcountries[selected_country].inflNATO <= 0;
				uslovie_text[0] = GlobalScript.inst.other_text[102];
			}
			else
			{
				uslovie_bool[0] = a.allcountries[selected_country].inflCh == 0 && a.guns;
				uslovie_text[0] = "Отправили оружие и не наложили санкции";
			}
			uslovie_bool[1] = a.allcountries[1].isSEV || a.allcountries[1].econ;
			uslovie_text[1] = "Союз основан или Китай в СЭВ";
			uslovie_bool[2] = !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].econ;
			uslovie_text[2] = "Они не состоят в экономическом союзе";
			if (a.allcountries[selected_country].Gosstroy <= 1)
			{
				uslovie_bool[3] = a.data[6] > 890;
				uslovie_text[3] = "Дипрепутация больше 89";
			}
			else
			{
				uslovie_bool[3] = a.data[6] > 490 && a.data[6] < 890;
				uslovie_text[3] = "Дипрепутация между 49 и 89";
			}
		}
		else if (this_type == 14)
		{
			this_opis = "Наложить санкции";
			if (!GlobalScript.inst.dlc[3])
			{
				number_uslovie = 2;
			}
			else
			{
				number_uslovie = 3;
			}
			uslovie_bool[0] = a.allcountries[selected_country].inflCh <= 0;
			uslovie_text[0] = "Не накладывали санкции";
			uslovie_bool[1] = a.data[6] < 500;
			uslovie_text[1] = "Дипрепутация ниже 50";
			if (GlobalScript.inst.dlc[3])
			{
				uslovie_bool[2] = a.allcountries[10].dev <= 0;
				uslovie_text[2] = GlobalScript.inst.other_text[101];
			}
		}
		else if (this_type == 15)
		{
			this_opis = "Спровоцировать новую корейскую войну";
			number_uslovie = 4;
			uslovie_bool[0] = a.guns && a.data[9] >= 100 && a.data[8] + a.data[36] >= 50;
			uslovie_text[0] = "Отправили оружие, есть 10 агентурных сетей и 5 миллионов в бюджете";
			if (!a.allcountries[1].isASEAN)
			{
				if (GlobalScript.inst.dlc[3])
				{
					uslovie_bool[1] = a.event_done[91] && a.allcountries[46].Gosstroy == 0 && a.allcountries[10].dev <= 0;
					uslovie_text[1] = GlobalScript.inst.other_text[103];
				}
				else
				{
					uslovie_bool[1] = a.event_done[91] && a.allcountries[46].Gosstroy == 0;
					uslovie_text[1] = "Покушение на Чон Ду Хвана состоялось";
				}
			}
			else
			{
				uslovie_bool[1] = a.event_done[91];
				uslovie_text[1] = "Покушение на Чон Ду Хвана состоялось";
			}
			uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
			uslovie_text[2] = "Война не спровоцирована";
			uslovie_bool[3] = a.data[6] > 790;
			uslovie_text[3] = "Дипрепутация больше 79";
		}
		else if (this_type == 16)
		{
			this_opis = "Направить вооружение и специалистов";
			if (!GlobalScript.inst.dlc[3])
			{
				number_uslovie = 3;
			}
			else
			{
				number_uslovie = 4;
			}
			uslovie_bool[0] = !a.guns;
			uslovie_text[0] = "Не отправили оружие";
			uslovie_bool[1] = a.data[22] >= 50;
			uslovie_text[1] = "Сила армии не менее 5";
			uslovie_bool[2] = a.data[8] + a.data[36] >= 20;
			uslovie_text[2] = "2 миллиона в бюджете";
			if (GlobalScript.inst.dlc[3])
			{
				uslovie_bool[3] = a.allcountries[10].dev <= 0;
				uslovie_text[3] = GlobalScript.inst.other_text[101];
			}
		}
		else if (this_type == 17)
		{
			this_opis = "Начать углублённую торговлю";
			number_uslovie = 3;
			if (!a.allcountries[selected_country].proprc)
			{
				uslovie_bool[0] = a.vietnampeace;
				uslovie_text[0] = "Не начинали войну с Вьетнамом";
			}
			else
			{
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = "Вьетнам - под влиянием КНР";
			}
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Торговля не ведётся";
			uslovie_bool[2] = a.data[6] > 690 || a.allcountries[selected_country].proprc;
			uslovie_text[2] = "Дипрепутация больше 69 или Вьетнам прокитайский";
			if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[7].isNATO;
				uslovie_text[3] = GlobalScript.inst.other_text[105];
			}
		}
		else if (this_type == 18)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 3;
			uslovie_bool[0] = !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].econ;
			uslovie_text[0] = "Вьетнам не в нашем союзе и не в СЭВ";
			uslovie_bool[1] = a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Торговля ведётся";
			uslovie_bool[2] = a.allcountries[1].econ || a.allcountries[1].isSEV;
			uslovie_text[2] = "Союз основан или мы в СЭВ";
			if (a.allcountries[selected_country].Vyshi)
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[selected_country].Vyshi;
				uslovie_text[3] = "Страна не под влиянием США";
			}
		}
		else if (this_type == 19)
		{
			this_opis = "Принять в военный альянс";
			number_uslovie = 4;
			if (selected_country != 40)
			{
				uslovie_bool[0] = a.allcountries[selected_country].isSEV || a.allcountries[selected_country].econ;
				uslovie_text[0] = "Они в ОЭС или в СЭВ";
			}
			else
			{
				uslovie_bool[0] = (a.allcountries[selected_country].isSEV || a.allcountries[selected_country].econ) && !a.allcountries[selected_country].oar;
				uslovie_text[0] = "Они в ОЭС или в СЭВ и не в ОАР";
			}
			uslovie_bool[1] = a.data[22] >= 20;
			uslovie_text[1] = "Сила армии не менее 2";
			if (!a.allcountries[selected_country].oar)
			{
				uslovie_bool[2] = a.allcountries[selected_country].IsInTheSameEconomicAllianceWith(a.allcountries[1]) && ((!a.allcountries[selected_country].isOVD && a.allcountries[1].isOVD && !a.allcountries[selected_country].isSEATO) || (!a.allcountries[selected_country].okb && a.allcountries[1].okb && !a.allcountries[selected_country].isOVD && !a.allcountries[selected_country].isSEATO));
				uslovie_text[2] = "Они не в альянсе, АКБ основан или Китай в ОВД";
			}
			else
			{
				uslovie_bool[2] = !a.allcountries[selected_country].oar;
				uslovie_text[2] = GlobalScript.inst.other_text[104];
			}
			uslovie_bool[3] = a.data[6] > 790;
			uslovie_text[3] = "Дипрепутация больше 79";
		}
		else if (this_type == 20)
		{
			if (selected_country == 11)
			{
				this_opis = "Направить подкрепления НОАК на войну|Сила наступления: " + a.data[39] / 10 + "." + Mathf.Abs(a.data[39] % 10);
			}
			else if (selected_country == 19)
			{
				this_opis = "Направить подкрепления НОАК на войну|Сила наступления: " + a.data[40] / 10 + "." + Mathf.Abs(a.data[40] % 10);
			}
			number_uslovie = 3;
			uslovie_bool[0] = a.war == 1;
			uslovie_text[0] = "Идёт война";
			uslovie_bool[1] = a.data[22] >= 70;
			uslovie_text[1] = "Сила армии не менее 7";
			uslovie_bool[2] = a.allcountries[selected_country].stab == 0;
			uslovie_text[2] = "Не отправляли в этом месяце";
		}
		else if (this_type == 21)
		{
			this_opis = "Поддержать выбранную силу в мирной борьбе за власть";
			number_uslovie = 4;
			uslovie_bool[0] = a.DRAagree;
			uslovie_text[0] = "Договорились с ДРА и СССР";
			uslovie_bool[1] = a.data[9] >= 40;
			uslovie_text[1] = "Не менее 4 агентурных сетей";
			uslovie_bool[2] = a.data[8] + a.data[36] >= 30;
			uslovie_text[2] = "3 миллиона в бюджете";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
			uslovie_text[3] = "Не поддержали в этом году";
		}
		else if (this_type == 68)
		{
			this_opis = "Принять в СЭВ";
			number_uslovie = 4;
			uslovie_bool[0] = !a.ingamewars[5].is_going;
			uslovie_text[0] = "Не идёт гражданская война";
			uslovie_bool[1] = a.allcountries[selected_country].proprc || (a.allcountries[1].isSEV && a.allcountries[selected_country].prosov);
			uslovie_text[1] = "Афганистан прокитайский или просоветский и Китай в СЭВ";
			uslovie_bool[2] = a.allcountries[selected_country].Torg && (a.allcountries[1].econ || a.allcountries[1].isSEV);
			uslovie_text[2] = "Торгуем и в союзе";
			uslovie_bool[3] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].isASEAN;
			uslovie_text[3] = "Они не в экономическом союзе";
		}
		else if (this_type == 22)
		{
			this_opis = "Отправить деньги в помощь Каддафи";
			number_uslovie = 2;
			uslovie_bool[0] = a.allcountries[selected_country].stab == 0;
			uslovie_text[0] = "Не отправляли";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = "5 миллионов в бюджете";
		}
		else if (this_type == 23)
		{
			this_opis = "Начать активную торговлю";
			number_uslovie = 3;
			uslovie_bool[0] = !a.allcountries[selected_country].Torg;
			uslovie_text[0] = "Торговля не ведётся";
			uslovie_bool[1] = a.data[6] > 590;
			uslovie_text[1] = "Дипрепутация больше 59";
			uslovie_bool[2] = a.allcountries[selected_country].stab == 1;
			uslovie_text[2] = "Отправили деньги Каддафи";
		}
		else if (this_type == 150)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 3;
			uslovie_bool[0] = a.allcountries[selected_country].Torg;
			uslovie_text[0] = "Идёт торговля";
			uslovie_bool[1] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
			uslovie_text[1] = "Они не в экономическом союзе";
			uslovie_bool[2] = a.allcountries[1].econ || a.allcountries[1].isSEV;
			uslovie_text[2] = "Союз основан или Китай в СЭВ";
			if (GlobalScript.inst.dlc[3])
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.ingamewars[20].is_going;
				uslovie_text[3] = GlobalScript.inst.other_text[563];
			}
		}
		else if (this_type == 67)
		{
			this_opis = "Провести переговоры о вступлении страны в ОАР";
			number_uslovie = 2;
			uslovie_bool[0] = a.OAR;
			uslovie_text[0] = "ОАР основана";
			uslovie_bool[1] = !a.allcountries[selected_country].oar;
			uslovie_text[1] = "Страна не в ОАР";
			if (selected_country == 14)
			{
				number_uslovie = 3;
				uslovie_bool[2] = a.allcountries[14].puppetOf != 8;
				uslovie_text[2] = GlobalScript.inst.other_text[116];
			}
			if (selected_country == 13 && GlobalScript.inst.dlc[3])
			{
				number_uslovie = 3;
				uslovie_bool[2] = a.data[132] == 2;
				uslovie_text[2] = GlobalScript.inst.other_text[115];
			}
		}
		else if (this_type == 24)
		{
			this_opis = "Начать углублённую торговлю";
			number_uslovie = 3;
			if (a.allcountries[selected_country].Gosstroy == 0)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 800;
				uslovie_text[0] = "Дипрепутация между 39 и 80";
			}
			else if (a.allcountries[selected_country].Gosstroy == 1)
			{
				uslovie_bool[0] = a.data[6] > 690;
				uslovie_text[0] = "Дипрепутация больше 69";
			}
			else if (a.allcountries[selected_country].Gosstroy == 2)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
				uslovie_text[0] = "Дипрепутация между 39 и 85";
			}
			else
			{
				uslovie_bool[0] = a.data[6] < 500;
				uslovie_text[0] = "Дипрепутация меньше 50";
			}
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Торговля не ведётся";
			uslovie_bool[2] = a.data[12] >= 700;
			uslovie_text[2] = "Промышленность не ниже 70";
			if (selected_country == 52)
			{
				number_uslovie = 4;
				uslovie_bool[3] = a.allcountries[52].stab <= 0;
				uslovie_text[3] = GlobalScript.inst.other_text[473];
			}
			if (selected_country == 14)
			{
				number_uslovie = 4;
				uslovie_bool[3] = a.allcountries[14].puppetOf != 8;
				uslovie_text[3] = "Ирак не марионетка Ирана";
			}
			else if (((selected_country >= 2 && selected_country <= 6) || selected_country == 16) && a.allcountries[1].isSEV)
			{
				number_uslovie = 4;
				uslovie_bool[3] = a.allcountries[1].isSEV;
				uslovie_text[3] = "Китай состоит в СЭВ";
			}
			else if ((selected_country >= 2 && selected_country <= 6) || selected_country == 16)
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[selected_country].prosov;
				uslovie_text[3] = "Страна не под советским влиянием";
			}
		}
		else if (this_type == 50)
		{
			this_opis = "Начать углублённую торговлю";
			number_uslovie = 3;
			if (a.allcountries[selected_country].Gosstroy == 0)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 800;
				uslovie_text[0] = "Дипрепутация между 39 и 80";
			}
			else if (a.allcountries[selected_country].Gosstroy == 1)
			{
				uslovie_bool[0] = a.data[6] > 690;
				uslovie_text[0] = "Дипрепутация больше 69";
			}
			else if (a.allcountries[selected_country].Gosstroy == 2)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
				uslovie_text[0] = "Дипрепутация между 39 и 85";
			}
			else
			{
				uslovie_bool[0] = a.data[6] < 500;
				uslovie_text[0] = "Дипрепутация меньше 50";
			}
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Торговля не ведётся";
			uslovie_bool[2] = a.data[12] >= 700;
			uslovie_text[2] = "Промышленность не ниже 70";
			if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[7].isNATO;
				uslovie_text[3] = GlobalScript.inst.other_text[105];
			}
		}
		else if (this_type == 69)
		{
			this_opis = "Установить связи с коммунистами и поддержать их";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[6] > 790;
			uslovie_text[0] = "Дипрепутация больше 79";
			uslovie_bool[1] = a.data[9] >= 30;
			uslovie_text[1] = "Не менее 3 агентурных сетей";
			uslovie_bool[2] = a.event_done[3];
			uslovie_text[2] = "Саддам начал репрессии против коммунистов";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
			uslovie_text[3] = "Не поддержали";
		}
		else if (this_type == 25)
		{
			this_opis = "Провести переговоры о вступлении страны в ОАР";
			number_uslovie = 4;
			uslovie_bool[0] = a.OAR;
			uslovie_text[0] = "ОАР основана";
			uslovie_bool[1] = !a.allcountries[selected_country].oar && !a.allcountries[selected_country].isSEATO && !a.allcountries[selected_country].isNATO && !a.allcountries[selected_country].isNATO && !a.allcountries[selected_country].okb && !a.allcountries[selected_country].isOVD;
			uslovie_text[1] = "Страна не в ОАР и не состоит в военных блоках";
			uslovie_bool[2] = a.allcountries[14].Gosstroy != 0;
			uslovie_text[2] = "Государственный строй - не авторитаризм";
			if (a.allcountries[14].Vyshi)
			{
				uslovie_bool[3] = !a.allcountries[14].Vyshi;
				uslovie_text[3] = "Страна не под влиянием США";
			}
			else if (a.allcountries[8].Gosstroy == 0)
			{
				uslovie_bool[3] = a.allcountries[8].SubGosstroy != 9;
				uslovie_text[3] = "Иран не под исламистами";
			}
			else
			{
				uslovie_bool[3] = a.allcountries[14].puppetOf != 8;
				uslovie_text[3] = "Ирак не марионетка Ирана";
			}
		}
		else if (this_type == 26)
		{
			this_opis = "Подписать договор о дружбе";
			number_uslovie = 3;
			uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 900;
			uslovie_text[0] = "Дипрепутация между 39 и 90";
			uslovie_bool[1] = (a.data[20] >= 5 && a.data[21] >= 1980) || a.data[21] >= 1981;
			uslovie_text[1] = "Тито умер";
			uslovie_bool[2] = !a.allcountries[selected_country].Torg;
			uslovie_text[2] = "Не подписали";
		}
		else if (this_type == 75)
		{
			this_opis = "Продать технологии американцам";
			number_uslovie = 3;
			uslovie_bool[0] = a.data[11] >= 100;
			uslovie_text[0] = "Есть 10 очков науки";
			uslovie_bool[1] = a.data[56] != 0;
			uslovie_text[1] = "Не леворадикалы";
			uslovie_bool[2] = a.empires[0].power < 600;
			uslovie_text[2] = "Мировое влияние США менее 60";
		}
		else if (this_type == 81)
		{
			this_opis = "Продать американские технологии";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[11] >= 100;
			uslovie_text[0] = "Есть 10 очков науки";
			uslovie_bool[1] = a.allcountries[1].isSEV || a.allcountries[7].Torg;
			uslovie_text[1] = "Наблюдатель или член СЭВ";
			uslovie_bool[2] = a.empires[1].power < 600;
			uslovie_text[2] = "Мировое влияние СССР менее 60";
			uslovie_bool[3] = a.allcountries[51].Torg;
			uslovie_text[3] = "Подписан договор о дружбе с США";
		}
		else if (this_type == 76)
		{
			this_opis = "Начать политику экономических преференций и кредитования";
			number_uslovie = 2;
			uslovie_bool[0] = a.data[36] >= 200;
			uslovie_text[0] = "Резерв не менее 20";
			uslovie_bool[1] = !a.allcountries[selected_country].cw;
			uslovie_text[1] = "Не начали";
		}
		else if (this_type == 77)
		{
			this_opis = "Осуществить бескровное смещение правительства националистов";
			this_opis = this_opis + "|Влияние на страну: " + a.allcountries[selected_country].dev + "%";
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].cw;
			uslovie_text[0] = "Привязали экономически";
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Не сместили";
			uslovie_bool[2] = a.allcountries[selected_country].dev >= 30;
			uslovie_text[2] = "Влияние: 30";
			uslovie_bool[3] = a.data[9] >= 80;
			uslovie_text[3] = "Агентурных сетей не менее 8";
		}
		else if (this_type == 78)
		{
			this_opis = "Разместить военную базу для защиты их суверенитета";
			this_opis = this_opis + "|Влияние на страну: " + a.allcountries[selected_country].dev + "%";
			number_uslovie = 4;
			uslovie_bool[0] = !a.allcountries[selected_country].proprc;
			uslovie_text[0] = "Нет военной базы";
			uslovie_bool[1] = a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Сместили националистов";
			uslovie_bool[2] = a.allcountries[selected_country].dev >= 60;
			uslovie_text[2] = "Влияние: 60";
			uslovie_bool[3] = a.data[9] >= 60 && a.data[22] >= 100;
			uslovie_text[3] = "Агентурных сетей - 6 и сила армии 10";
		}
		else if (this_type == 79)
		{
			this_opis = "Провести референдум о вхождении страны в состав КНР";
			this_opis = this_opis + "|Влияние на страну: " + a.allcountries[selected_country].dev + "%";
			number_uslovie = 3;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = "Есть военная база";
			uslovie_bool[1] = a.allcountries[selected_country].dev >= 100;
			uslovie_text[1] = "Влияние: 100";
			uslovie_bool[2] = a.data[9] >= 80;
			uslovie_text[2] = "Агентурных сетей - 8";
		}
		else if (this_type == 80)
		{
			this_opis = "Склонить к смене системы по нашему образцу";
			this_opis = this_opis + "|Они получат Государственный строй: " + GlobalScript.inst.other_text[(a.ChineseSubGosstroy() < 10) ? (a.ChineseSubGosstroy() + 13) : (a.ChineseSubGosstroy() + 82)];
			number_uslovie = 4;
			if (a.allcountries[1].okb)
			{
				uslovie_bool[0] = a.allcountries[selected_country].SubGosstroy != a.ChineseSubGosstroy();
				uslovie_text[0] = "У нас разные госстрои";
			}
			else
			{
				uslovie_bool[0] = a.allcountries[1].okb;
				uslovie_text[0] = "У нас есть свой собственный военный союз";
			}
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = "Бюджет: 5";
			uslovie_bool[2] = a.data[9] >= 50;
			uslovie_text[2] = "Агентурных сетей: 5";
			uslovie_bool[3] = a.data[22] >= 50;
			uslovie_text[3] = "Сила армии: 5";
		}
		else if (this_type == 27)
		{
			this_opis = "Установить связи с коммунистами и поддержать их";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[6] > 590;
			uslovie_text[0] = "Дипрепутация больше 59";
			uslovie_bool[1] = a.data[9] >= 40;
			uslovie_text[1] = "Не менее 4 агентурных сетей";
			uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
			uslovie_text[2] = "Не поддержали";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 1 || a.allcountries[selected_country].Torg;
			uslovie_text[3] = "Подписали договор";
		}
		else if (this_type == 72)
		{
			this_opis = "Вступить в Движение неприсоединения";
			number_uslovie = 4;
			uslovie_bool[0] = !a.allcountries[1].isOVD && !a.allcountries[1].okb && !a.allcountries[1].isSEATO;
			uslovie_text[0] = "Не состоим в альянсах";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 20;
			uslovie_text[1] = "2 миллиона в бюджете";
			uslovie_bool[2] = !a.allcountries[15].cw;
			uslovie_text[2] = "Мы не в Движении сейчас";
			uslovie_bool[3] = a.war <= 0;
			uslovie_text[3] = "Не ведём войн";
		}
		else if (this_type == 73)
		{
			this_opis = "Выйти из Движения неприсоединения";
			number_uslovie = 3;
			uslovie_bool[0] = a.data[1] > 750;
			uslovie_text[0] = "Поддержка Партии больше чем 75.0";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = "5 миллионов в бюджете";
			uslovie_bool[2] = a.allcountries[15].cw;
			uslovie_text[2] = "Мы состоим в Движении";
		}
		else if (this_type == 28)
		{
			this_opis = "Поддержать повстанцев на востоке|Сила маоистов: " + a.data[32] / 10 + "." + Mathf.Abs(a.data[32] % 10);
			number_uslovie = 4;
			uslovie_bool[0] = a.data[6] > 790;
			uslovie_text[0] = "Дипрепутация больше 79";
			uslovie_bool[1] = a.data[9] >= 30 && a.data[22] >= 30;
			uslovie_text[1] = "Не менее 3 агентурных сетей и силы армии";
			uslovie_bool[2] = !a.allcountries[selected_country].Torg;
			uslovie_text[2] = "Не наладили отношения";
			if (a.data[32] <= 500 || GlobalScript.inst.dlc[1])
			{
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "Не поддерживали в этом месяце";
			}
			else
			{
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0 && a.data[32] <= 500;
				uslovie_text[3] = "Не достигли их максимума возможностей";
			}
		}
		else if (this_type == 29)
		{
			this_opis = "Нормализовать отношения";
			number_uslovie = 4;
			uslovie_bool[0] = (a.data[91] == 1 || a.data[91] == 2 || a.data[91] == 3) && (!a.allcountries[31].Torg || a.allcountries[31].Gosstroy == 2 || a.allcountries[31].Gosstroy == 1);
			uslovie_text[0] = "Помогли Индире, нет дружбы с Пакистаном или Бхутто - премьер Пакистана";
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Не наладили отношения";
			uslovie_bool[2] = a.allcountries[selected_country].dev == 0 && a.war == 0 && a.data[62] < 2;
			uslovie_text[2] = "Не начинали войну";
			uslovie_bool[3] = a.data[62] == 0;
			uslovie_text[3] = "Территориальный спор не урегулирован";
		}
		else if (this_type == 30)
		{
			this_opis = "Начать новую пограничную войну за спорные территории";
			number_uslovie = 4;
			uslovie_bool[0] = a.CBIndia;
			uslovie_text[0] = "Есть повод для войны";
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Не наладили отношения";
			uslovie_bool[2] = a.allcountries[selected_country].dev == 0 && a.war == 0 && a.data[62] < 2;
			uslovie_text[2] = "Не начинали войну";
			uslovie_bool[3] = !a.allcountries[15].cw;
			uslovie_text[3] = "Не в Движении неприсоединения";
		}
		else if (this_type == 89)
		{
			this_opis = "Обменять Аруначал Прадеш на денежные инвестиции";
			number_uslovie = 3;
			uslovie_bool[0] = a.influencePRC >= 500;
			uslovie_text[0] = "Влияние КНР не менее 50.0";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 250;
			uslovie_text[1] = "Денег в бюджете не менее 25.0";
			uslovie_bool[2] = a.CBIndia;
			uslovie_text[2] = "Есть нерешённый территориальный вопрос";
		}
		else if (this_type == 71)
		{
			if (selected_country == 11)
			{
				this_opis = "Направить подкрепления НОАК на войну|Сила наступления: " + a.data[39] / 10 + "." + Mathf.Abs(a.data[39] % 10);
			}
			else if (selected_country == 19)
			{
				this_opis = "Направить подкрепления НОАК на войну|Сила наступления: " + a.data[40] / 10 + "." + Mathf.Abs(a.data[40] % 10);
			}
			number_uslovie = 3;
			uslovie_bool[0] = a.war == 2;
			uslovie_text[0] = "Идёт война с Индией";
			uslovie_bool[1] = a.data[22] >= 70;
			uslovie_text[1] = "Сила армии не менее 7";
			uslovie_bool[2] = a.allcountries[selected_country].prcpower == 0;
			uslovie_text[2] = "Не отправляли в этом месяце";
		}
		else if (this_type == 31)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 3;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = "Албания прокитайская";
			uslovie_bool[1] = a.allcountries[1].econ || (a.allcountries[1].isSEV && a.SovAlb);
			uslovie_text[1] = "Союз основан или Китай в СЭВ и советско-албанские отношения восстановлены";
			uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
			uslovie_text[2] = "Они не в экономическом союзе";
			if (a.allcountries[selected_country].Vyshi)
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[selected_country].Vyshi;
				uslovie_text[3] = "Страна не под влиянием США";
			}
		}
		else if (this_type == 32)
		{
			this_opis = "Склонить к восстановлению отношений с СССР";
			number_uslovie = 4;
			uslovie_bool[0] = a.relres;
			uslovie_text[0] = "Советско-китайские отношения восстановлены";
			uslovie_bool[1] = a.data[6] > 790 || a.allcountries[7].Torg;
			uslovie_text[1] = "Дипрепутация больше 79 ИЛИ мы - наблюдатель в СЭВ";
			uslovie_bool[2] = a.data[60] > 0;
			uslovie_text[2] = "Ходжа умер или смещён";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
			uslovie_text[3] = "Их отношения не восстановлены";
		}
		else if (this_type == 33)
		{
			this_opis = "Подписать договор о дружбе";
			number_uslovie = 2;
			uslovie_bool[0] = a.data[6] < 800;
			uslovie_text[0] = "Дипрепутация меньше 80";
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Не подписали";
			if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
			{
				number_uslovie = 3;
				uslovie_bool[2] = !a.allcountries[7].isNATO;
				uslovie_text[2] = GlobalScript.inst.other_text[105];
			}
		}
		else if (this_type == 34)
		{
			this_opis = "Пригласить иностранных инвесторов";
			number_uslovie = 3;
			if (a.allcountries[21].Gosstroy == 1 && selected_country == 21)
			{
				uslovie_bool[0] = a.data[6] >= 600;
				uslovie_text[0] = "Дипрепутация больше 60";
			}
			else
			{
				uslovie_bool[0] = a.data[6] < 600;
				uslovie_text[0] = "Дипрепутация меньше 60";
			}
			if (a.allcountries[21].Gosstroy == 1 && selected_country == 21)
			{
				uslovie_bool[1] = a.data[16] < 13 || a.SEZ;
				uslovie_text[1] = "Экономика - \"Государственный монополизм\" и социалистичней или открыли СЭЗ";
			}
			else
			{
				uslovie_bool[1] = a.data[16] >= 13 || a.SEZ;
				uslovie_text[1] = "Экономика - \"птичья клетка\" и либеральнее или открыли СЭЗ";
			}
			uslovie_bool[2] = a.allcountries[selected_country].stab == 0;
			uslovie_text[2] = "Не привлекали в этом году";
		}
		else if (this_type == 35)
		{
			this_opis = "Установить близкие дружеские отношения";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[6] > 690;
			uslovie_text[0] = "Дипрепутация больше 69";
			uslovie_bool[1] = a.data[9] >= 30;
			uslovie_text[1] = "Не менее 3 агентурных сетей";
			if (!a.allcountries[11].proprc)
			{
				uslovie_bool[2] = a.allcountries[11].Torg && a.vietnampeace;
				uslovie_text[2] = "Не спровоцировали войну с Вьетнамом и ведём с ним торговлю";
			}
			else
			{
				uslovie_bool[2] = a.allcountries[11].proprc && a.allcountries[34].proprc && a.allcountries[23].proprc;
				uslovie_text[2] = "Вьетнам, Кампучия и Таиланд - прокитайские";
			}
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
			uslovie_text[3] = "Не сближались";
		}
		else if (this_type == 36)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = "Лаос прокитайский";
			uslovie_bool[1] = a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Идёт торговля";
			uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
			uslovie_text[2] = "Они не в экономическом союзе";
			uslovie_bool[3] = a.allcountries[1].econ || a.allcountries[1].isSEV;
			uslovie_text[3] = "Союз основан или Китай в СЭВ";
		}
		else if (this_type == 37)
		{
			this_opis = "Организовать мятеж во главе с тройкой Ху Ним, Ху Юн и Кхиеу Сампхан с целью ареста и свержения Пол Пота";
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = "Кампучия прокитайская";
			uslovie_bool[1] = a.data[38] == 100;
			uslovie_text[1] = "Мао умер";
			uslovie_bool[2] = a.allcountries[selected_country].stab == 0 && a.allcountries[selected_country].Gosstroy != 1;
			uslovie_text[2] = "Не поддерживали мятеж";
			uslovie_bool[3] = a.data[8] + a.data[9] >= 30;
			uslovie_text[3] = "Агентурных сетей и денег в бюджете не менее 3";
		}
		else if (this_type == 38)
		{
			this_opis = "Поддержать сторонников старого президента Насера";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[6] > 690;
			uslovie_text[0] = "Дипрепутация больше 69";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = "5 миллионов в бюджете";
			uslovie_bool[2] = !a.event_done[37];
			uslovie_text[2] = "Пока ещё можно";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
			uslovie_text[3] = "Не поддержали";
		}
		else if (this_type == 39)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].Torg;
			uslovie_text[0] = "Идёт торговля";
			uslovie_bool[1] = a.OAR;
			uslovie_text[1] = "ОАР основана";
			uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
			uslovie_text[2] = "Они не в экономическом союзе";
			uslovie_bool[3] = a.allcountries[1].econ || a.allcountries[1].isSEV;
			uslovie_text[3] = "Союз основан или Китай в СЭВ";
		}
		else if (this_type == 40)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 4;
			uslovie_bool[0] = !a.allcountries[selected_country].Vyshi;
			uslovie_text[0] = "Пакистан не проамериканский";
			uslovie_bool[1] = !a.allcountries[19].Torg || a.allcountries[selected_country].proprc;
			uslovie_text[1] = "Не нормализовали отношения с Индией или Бхутто - премьер";
			uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].isASEAN;
			uslovie_text[2] = "Они не в экономическом союзе";
			uslovie_bool[3] = a.allcountries[1].econ || a.allcountries[1].isSEV;
			uslovie_text[3] = "Союз основан или Китай в СЭВ";
		}
		else if (this_type == 41)
		{
			this_opis = "Принять в военный альянс";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[22] >= 20;
			uslovie_text[0] = "Сила армии не менее 2";
			uslovie_bool[1] = (a.allcountries[selected_country].econ || a.allcountries[selected_country].isSEV) && (a.allcountries[1].okb || a.allcountries[1].isOVD);
			uslovie_text[1] = "Пакистан в экономическом союзе, альянс основан или мы в ОВД";
			uslovie_bool[2] = !a.allcountries[selected_country].okb && !a.allcountries[selected_country].isOVD && !a.allcountries[selected_country].isSEATO && !a.allcountries[selected_country].isSENTO;
			uslovie_text[2] = "Они не в военном союзе";
			uslovie_bool[3] = a.allcountries[selected_country].econ || a.allcountries[selected_country].isSEV;
			uslovie_text[3] = "Они в экономическом союзе";
		}
		else if (this_type == 42)
		{
			this_opis = "Выделить помощь для восстановления экономики";
			number_uslovie = 2;
			uslovie_bool[0] = a.data[8] + a.data[36] >= 80;
			uslovie_text[0] = "8 миллионов в бюджете";
			uslovie_bool[1] = a.allcountries[selected_country].stab == 0;
			uslovie_text[1] = "Не направляли помощь";
		}
		else if (this_type == 43)
		{
			this_opis = "Поддержать тайских коммунистов";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 40;
			uslovie_text[0] = "4 агентурные сети";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 20;
			uslovie_text[1] = "2 миллиона в бюджете";
			uslovie_bool[2] = !a.TaiCoup;
			uslovie_text[2] = "Переворот в Таиланде ещё не осуществился";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
			uslovie_text[3] = "Не поддержали";
		}
		else if (this_type == 44)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 4;
			if (selected_country == 52)
			{
				uslovie_bool[0] = a.allcountries[selected_country].spec > 0;
				uslovie_text[0] = GlobalScript.inst.other_text[474];
			}
			else
			{
				uslovie_bool[0] = a.allcountries[selected_country].Gosstroy == 1;
				uslovie_text[0] = "Коммунисты победили";
			}
			uslovie_bool[1] = a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Идёт торговля";
			uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
			uslovie_text[2] = "Они не в экономическом союзе";
			uslovie_bool[3] = a.allcountries[1].econ || a.allcountries[1].isSEV;
			uslovie_text[3] = "Союз основан или Китай в СЭВ";
		}
		else if (this_type == 45)
		{
			this_opis = "Провести переговоры о вступлении страны в ОАР";
			if (selected_country != 40 && selected_country != 35)
			{
				number_uslovie = 2;
			}
			else
			{
				number_uslovie = 4;
			}
			uslovie_bool[0] = a.OAR;
			uslovie_text[0] = "ОАР основана";
			uslovie_bool[1] = !a.allcountries[selected_country].oar;
			uslovie_text[1] = "Страна не в ОАР";
			if (selected_country == 40 || selected_country == 35)
			{
				uslovie_bool[2] = !a.allcountries[selected_country].Vyshi;
				uslovie_text[2] = GlobalScript.inst.other_text[91];
				uslovie_bool[3] = !a.allcountries[selected_country].isOVD && !a.allcountries[selected_country].okb;
				uslovie_text[3] = GlobalScript.inst.other_text[322];
			}
		}
		else if (this_type == 46)
		{
			this_opis = "Провести переговоры о статусе палестинцев при нашем посредничестве";
			number_uslovie = 2;
			uslovie_bool[0] = a.Israellost;
			uslovie_text[0] = "Израиль проиграл ливанскую войну";
			uslovie_bool[1] = a.allcountries[selected_country].dev == 0;
			uslovie_text[1] = "Переговоры не проводились";
		}
		else if (this_type == 47)
		{
			this_opis = "Провести переговоры с целью нормализации отношений";
			number_uslovie = 3;
			uslovie_bool[0] = a.data[6] < 550;
			uslovie_text[0] = "Дипрепутация ниже 55";
			uslovie_bool[1] = a.allcountries[51].Torg;
			uslovie_text[1] = "Есть договор с США";
			uslovie_bool[2] = !a.allcountries[selected_country].Torg;
			uslovie_text[2] = "Не проводили переговоры";
		}
		else if (this_type == 48)
		{
			this_opis = "Начать освобождение приграничных островов";
			number_uslovie = 3;
			uslovie_bool[0] = a.data[22] >= 500;
			uslovie_text[0] = "Сила армии не менее 50";
			uslovie_bool[1] = !a.allcountries[51].Torg;
			uslovie_text[1] = "Не нормализовали отношения";
			uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
			uslovie_text[2] = "Не устраивали вторжение";
		}
		else if (this_type == 49)
		{
			this_opis = "Положить деньги на тайный счёт КПК";
			number_uslovie = 2;
			if (!a.allcountries[selected_country].proprc)
			{
				uslovie_bool[0] = a.data[8] + a.data[36] >= 100;
				uslovie_text[0] = "10 миллионов в бюджете";
			}
			else
			{
				uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
				uslovie_text[0] = "5 миллионов в бюджете";
			}
			uslovie_bool[1] = a.allcountries[39].dev == 0;
			uslovie_text[1] = "Раз в месяц";
			if (GlobalScript.inst.dlc[6])
			{
				number_uslovie = 3;
				uslovie_bool[2] = !a.IsBankAccountFreezed;
				uslovie_text[2] = GlobalScript.inst.new_texts[895];
			}
		}
		else if (this_type == 51)
		{
			this_opis = "Устранить Кендзи Миямото и вернуть контроль над КПЯ";
			number_uslovie = 3;
			uslovie_bool[0] = a.data[9] >= 50;
			uslovie_text[0] = "5 агентурных сетей";
			uslovie_bool[1] = a.data[6] >= 690;
			uslovie_text[1] = "Дипрепутация больше 69";
			uslovie_bool[2] = a.allcountries[selected_country].stab == 0;
			uslovie_text[2] = "Не устранили";
		}
		else if (this_type == 52)
		{
			this_opis = "Начать углублённую торговлю";
			number_uslovie = 3;
			if (a.allcountries[selected_country].Gosstroy == 1)
			{
				uslovie_bool[0] = a.data[6] >= 800;
				uslovie_text[0] = "Дипрепутация не ниже 80";
			}
			else if (a.allcountries[selected_country].Gosstroy <= 2)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
				uslovie_text[0] = "Дипрепутация между 39 и 85";
			}
			else if (a.allcountries[selected_country].Gosstroy == 3)
			{
				uslovie_bool[0] = a.data[6] < 500;
				uslovie_text[0] = "Дипрепутация меньше 50";
			}
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Торговля не ведётся";
			uslovie_bool[2] = a.data[12] >= 800;
			uslovie_text[2] = "Промышленность не ниже 80";
			if (a.allcountries[7].isNATO && (a.allcountries[selected_country].Vyshi || a.allcountries[selected_country].prosov || a.allcountries[selected_country].isNATO))
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[7].isNATO;
				uslovie_text[3] = GlobalScript.inst.other_text[105];
			}
		}
		else if (this_type == 53)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 3;
			if (selected_country != 94 && selected_country != 95 && selected_country != 84 && selected_country != 14 && selected_country != 35)
			{
				uslovie_bool[0] = a.allcountries[selected_country].Torg && a.allcountries[selected_country].Gosstroy <= 2;
				uslovie_text[0] = "Идёт торговля и прокитайские силы у власти";
			}
			else
			{
				uslovie_bool[0] = a.allcountries[selected_country].Torg;
				uslovie_text[0] = "Идёт торговля";
			}
			if (selected_country == 27 || selected_country == 39 || selected_country == 88 || selected_country == 29 || selected_country == 89 || selected_country == 0 || selected_country == 90 || selected_country == 91 || selected_country == 28 || (selected_country == 26 && !a.allcountries[26].prosov))
			{
				uslovie_bool[0] = a.allcountries[selected_country].cw;
				uslovie_text[0] = "Поддержали одну из фракций";
			}
			uslovie_bool[1] = a.allcountries[1].econ || a.allcountries[1].isSEV;
			uslovie_text[1] = "Союз основан или Китай в СЭВ";
			uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
			uslovie_text[2] = "Они не в экономическом союзе";
			if (selected_country == 94)
			{
				number_uslovie = 4;
				uslovie_bool[3] = a.allcountries[selected_country].SubGosstroy == 4;
				uslovie_text[3] = GlobalScript.inst.other_text[118];
			}
			if (selected_country == 14 || selected_country == 35)
			{
				number_uslovie = 4;
				uslovie_bool[3] = a.allcountries[selected_country].Gosstroy == 1 || a.allcountries[selected_country].proprc;
				uslovie_text[3] = GlobalScript.inst.other_text[313];
			}
			if (a.allcountries[selected_country].Vyshi)
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[selected_country].Vyshi;
				uslovie_text[3] = "Страна не под влиянием США";
			}
		}
		else if (this_type == 54)
		{
			this_opis = "Принять в экономический союз";
			number_uslovie = 3;
			uslovie_bool[0] = a.allcountries[selected_country].Gosstroy == 2;
			uslovie_text[0] = "Левая коалиция у власти";
			uslovie_bool[1] = a.allcountries[1].econ || a.allcountries[1].isSEV;
			uslovie_text[1] = "Союз основан или Китай в СЭВ";
			uslovie_bool[2] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
			uslovie_text[2] = "Они не в экономическом союзе";
			if (a.allcountries[selected_country].Vyshi)
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[selected_country].Vyshi;
				uslovie_text[3] = "Страна не под влиянием США";
			}
		}
		else if (this_type == 55)
		{
			this_opis = "Оказать экономическое и политическое давление";
			number_uslovie = 4;
			uslovie_bool[0] = (a.allcountries[11].econ && a.allcountries[34].econ && a.allcountries[47].econ) || (a.allcountries[11].isSEV && a.allcountries[34].isSEV && a.allcountries[47].isSEV) || (a.allcountries[11].isASEAN && a.allcountries[34].isASEAN && a.allcountries[47].isASEAN);
			uslovie_text[0] = "Вьетнам, Таиланд и Филиппины в том же альянсе, что и мы";
			uslovie_bool[1] = a.data[9] >= 40;
			uslovie_text[1] = "Не менее 4 агентурных сетей";
			uslovie_bool[2] = a.SKRebel;
			uslovie_text[2] = "Поддержали восстание в Кванджу";
			if (a.ingamewars[0].is_going)
			{
				uslovie_bool[3] = !a.ingamewars[0].is_going;
				uslovie_text[3] = "Страна не в войне";
			}
			else
			{
				uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
				uslovie_text[3] = "Не оказывали давление";
			}
		}
		else if (this_type == 56)
		{
			this_opis = "Поддержать маоистов.|Сила маоистов: " + a.data[37] / 10 + "." + Mathf.Abs(a.data[37] % 10);
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 40;
			uslovie_text[0] = "4 агентурные сети";
			uslovie_bool[1] = a.data[22] >= 30;
			uslovie_text[1] = "Сила армии не менее 3";
			uslovie_bool[2] = a.data[6] >= 750;
			uslovie_text[2] = "Дипрепутация больше 75";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0 && a.data[37] < 1000;
			uslovie_text[3] = "Не поддержали в этом году";
		}
		else if (this_type == 57)
		{
			this_opis = "Разжечь усиленные протесты против апартеида";
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 100;
			uslovie_text[0] = "9 агентурных сетей";
			uslovie_bool[1] = a.data[8] + a.data[36] >= 100;
			uslovie_text[1] = "10 миллионов в бюджете";
			uslovie_bool[2] = a.data[21] >= 1980;
			uslovie_text[2] = "Не раньше 1980 года";
			uslovie_bool[3] = a.allcountries[selected_country].stab == 0;
			uslovie_text[3] = "Не разожгли протесты";
		}
		else if (this_type == 58)
		{
			this_opis = "Наложить санкции на правую диктатуру";
			number_uslovie = 3;
			if (selected_country == 52)
			{
				uslovie_bool[0] = (a.allcountries[47].econ && a.allcountries[50].econ && a.allcountries[49].econ) || (a.allcountries[47].isSEV && a.allcountries[50].isSEV && a.allcountries[49].isSEV) || (a.allcountries[11].isASEAN && a.allcountries[34].isASEAN && a.allcountries[49].isASEAN);
				uslovie_text[0] = "Индонезия, Филиппины и Малайзия в одном экономическом союзе с нами";
			}
			else
			{
				uslovie_bool[0] = (a.allcountries[11].econ && a.allcountries[34].econ && a.allcountries[49].econ) || (a.allcountries[11].isSEV && a.allcountries[34].isSEV && a.allcountries[49].isSEV) || (a.allcountries[11].isASEAN && a.allcountries[34].isASEAN && a.allcountries[49].isASEAN);
				uslovie_text[0] = "Вьетнам, Таиланд и Малайзия в одном экономическом союзе с нами";
			}
			if (selected_country == 52)
			{
				uslovie_bool[1] = a.data[8] + a.data[36] >= 80;
				uslovie_text[1] = "Не менее 8 миллионов";
			}
			else
			{
				uslovie_bool[1] = a.data[8] + a.data[36] >= 40;
				uslovie_text[1] = "Не менее 4 миллионов";
			}
			uslovie_bool[2] = a.allcountries[selected_country].stab == 0;
			uslovie_text[2] = "Не оказывали давление";
			if (selected_country == 52)
			{
				number_uslovie = 4;
				uslovie_bool[3] = a.influencePRC >= 700 && ((a.allcountries[1].isSEV && !a.allcountries[52].isSEV) || (a.allcountries[1].econ && !a.allcountries[52].econ) || (a.allcountries[1].isASEAN && !a.allcountries[52].isASEAN));
				uslovie_text[3] = GlobalScript.inst.other_text[467];
			}
		}
		else if (this_type == 60)
		{
			this_opis = "Подписать договор о дружбе и сотрудничестве";
			number_uslovie = 3;
			uslovie_bool[0] = a.empires[0].relations > 700;
			uslovie_text[0] = "Отношения с США больше 70";
			uslovie_bool[1] = a.data[6] < 500;
			uslovie_text[1] = "Дипрепутация меньше 50";
			if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
			{
				uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12);
				uslovie_text[2] = "Не атаковали их союзников";
			}
			else if (!a.allcountries[selected_country].Torg)
			{
				uslovie_bool[2] = a.war <= 0;
				uslovie_text[2] = "Мы не воюем";
			}
			else
			{
				uslovie_bool[2] = !a.allcountries[selected_country].Torg;
				uslovie_text[2] = "Не подписали";
			}
		}
		else if (this_type == 61)
		{
			this_opis = "Начать сотрудничество с ЦРУ";
			number_uslovie = 3;
			uslovie_bool[0] = a.empires[0].relations > 800;
			uslovie_text[0] = "Отношения с США больше 80";
			uslovie_bool[1] = a.data[6] < 600;
			uslovie_text[1] = "Дипрепутация меньше 60";
			if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
			{
				uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12);
				uslovie_text[2] = "Не атаковали их союзников";
			}
			else if (a.allcountries[selected_country].dev == 0)
			{
				uslovie_bool[2] = a.war <= 0;
				uslovie_text[2] = "Мы не воюем";
			}
			else
			{
				uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
				uslovie_text[2] = "Не начали сотрудничество";
			}
		}
		else if (this_type == 62)
		{
			number_uslovie = 4;
			if (a.allcountries[selected_country].proprc)
			{
				this_opis = "Финансировать режим";
				uslovie_bool[2] = a.allcountries[selected_country].stab < 1200;
				uslovie_text[2] = "Стабильность менее 100";
				this_opis = this_opis + "|Стабильность: " + a.allcountries[selected_country].stab / 10 + "." + Mathf.Abs(a.allcountries[selected_country].stab % 10);
				uslovie_bool[0] = a.data[9] >= 100;
				uslovie_text[0] = "10 агентурных сетей";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 40;
				uslovie_text[1] = "4 миллиона в бюджете";
				uslovie_bool[3] = a.data[22] >= 80;
				uslovie_text[3] = "8 военных группы";
			}
			else
			{
				this_opis = "Поддержать прокитайские силы";
				uslovie_bool[2] = a.allcountries[selected_country].prcpower < 1200;
				uslovie_text[2] = "Прокитайские силы менее 100";
				this_opis = this_opis + "|сила прокитайских: " + a.allcountries[selected_country].prcpower / 10 + "." + Mathf.Abs(a.allcountries[selected_country].prcpower % 10);
				uslovie_bool[0] = a.data[9] >= 80;
				uslovie_text[0] = "8 агентурных сетей";
				uslovie_bool[1] = a.data[8] + a.data[36] >= 40;
				uslovie_text[1] = "4 миллиона в бюджете";
				uslovie_bool[3] = a.data[22] >= 100;
				uslovie_text[3] = "10 военных групп";
			}
		}
		else if (this_type == 63)
		{
			this_opis = "Организовать союз с просоветскими силами";
			this_opis = this_opis + "|сила просоветских: " + a.allcountries[selected_country].sovpower / 10 + "." + Mathf.Abs(a.allcountries[selected_country].sovpower % 10);
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 20;
			uslovie_text[0] = "2 агентурные сети";
			uslovie_bool[1] = a.data[6] > 690;
			uslovie_text[1] = "Дипрепутация больше 69";
			uslovie_bool[2] = !a.allcountries[selected_country].usalliance && !a.allcountries[selected_country].sovalliance;
			uslovie_text[2] = "Нет союза";
			uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].proprc;
			uslovie_text[3] = "Страна не просоветская и не прокитайская";
		}
		else if (this_type == 64)
		{
			this_opis = "Организовать союз с проамериканскими силами";
			this_opis = this_opis + "|сила американских: " + a.allcountries[selected_country].usapower / 10 + "." + Mathf.Abs(a.allcountries[selected_country].usapower % 10);
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 20;
			uslovie_text[0] = "2 агентурные сети";
			uslovie_bool[1] = a.data[6] < 500;
			uslovie_text[1] = "Дипрепутация меньше 50";
			uslovie_bool[2] = !a.allcountries[selected_country].usalliance && !a.allcountries[selected_country].sovalliance;
			uslovie_text[2] = "Нет союза";
			uslovie_bool[3] = !a.allcountries[selected_country].Vyshi && !a.allcountries[selected_country].proprc;
			uslovie_text[3] = "Страна не проамериканская и не прокитайская";
		}
		else if (this_type == 65)
		{
			this_opis = "Разжечь волнения, дабы свергнуть правительство";
			this_opis = this_opis + "|Стабильность: " + a.allcountries[selected_country].stab / 10 + "." + Mathf.Abs(a.allcountries[selected_country].stab % 10);
			number_uslovie = 2;
			uslovie_bool[0] = a.allcountries[selected_country].prcpower > 300;
			uslovie_text[0] = "Прокитайские силы больше 30";
			uslovie_bool[1] = !a.allcountries[selected_country].proprc;
			uslovie_text[1] = "Страна не прокитайская";
		}
		else if (this_type == 66)
		{
			if (!a.allcountries[selected_country].Torg)
			{
				this_opis = "Начать добычу ресурсов с эксклюзивными правами";
			}
			else
			{
				this_opis = "Прекратить добычу ресурсов с эксклюзивными правами";
			}
			this_opis = this_opis + "|Стабильность: " + a.allcountries[selected_country].stab / 10 + "." + Mathf.Abs(a.allcountries[selected_country].stab % 10);
			number_uslovie = 1;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = "Страна прокитайская";
		}
		else if (this_type == 70)
		{
			this_opis = "Оказать помощь ЗАНУ";
			number_uslovie = 3;
			uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
			uslovie_text[0] = "5 миллионов в бюджете";
			uslovie_bool[1] = a.event_done[88];
			uslovie_text[1] = "ЗАНУ победила на выборах";
			uslovie_bool[2] = !a.allcountries[selected_country].Torg;
			uslovie_text[2] = "Не оказали помощь";
		}
		else if (this_type == 82)
		{
			this_opis = GlobalScript.inst.other_text[29];
			number_uslovie = 3;
			uslovie_bool[0] = a.allcountries[selected_country].level_of_unstab - a.allcountries[selected_country].level_of_dev > 0;
			uslovie_text[0] = GlobalScript.inst.other_text[33];
			uslovie_bool[1] = !a.allcountries[selected_country].proprc;
			uslovie_text[1] = GlobalScript.inst.other_text[34];
			uslovie_bool[2] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50 && a.data[22] >= 50;
			uslovie_text[2] = GlobalScript.inst.other_text[35];
		}
		else if (this_type == 83)
		{
			this_opis = GlobalScript.inst.other_text[30];
			number_uslovie = 3;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = GlobalScript.inst.other_text[39];
			uslovie_bool[1] = a.allcountries[selected_country].Gosstroy == 2;
			uslovie_text[1] = GlobalScript.inst.other_text[40];
			uslovie_bool[2] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50 && a.data[22] >= 50;
			uslovie_text[2] = GlobalScript.inst.other_text[35];
		}
		else if (this_type == 84)
		{
			this_opis = GlobalScript.inst.other_text[31];
			number_uslovie = 3;
			uslovie_bool[0] = a.science[19];
			uslovie_text[0] = GlobalScript.inst.other_text[42];
			uslovie_bool[1] = !a.allcountries[selected_country].proprc;
			uslovie_text[1] = GlobalScript.inst.other_text[34];
			uslovie_bool[2] = a.data[8] + a.data[36] >= 20 && a.data[9] >= 20 && a.data[22] >= 20;
			uslovie_text[2] = GlobalScript.inst.other_text[53];
		}
		else if (this_type == 85)
		{
			this_opis = GlobalScript.inst.other_text[32];
			number_uslovie = 3;
			uslovie_bool[0] = a.science[20];
			uslovie_text[0] = GlobalScript.inst.other_text[43];
			uslovie_bool[1] = !a.allcountries[selected_country].proprc;
			uslovie_text[1] = GlobalScript.inst.other_text[34];
			uslovie_bool[2] = a.data[8] + a.data[36] >= 20 && a.data[9] >= 20 && a.data[22] >= 20;
			uslovie_text[2] = GlobalScript.inst.other_text[53];
		}
		else if (this_type == 86)
		{
			this_opis = GlobalScript.inst.other_text[47];
			number_uslovie = 3;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = GlobalScript.inst.other_text[39];
			uslovie_bool[1] = a.allcountries[selected_country].Torg;
			uslovie_text[1] = GlobalScript.inst.other_text[46];
			uslovie_bool[2] = a.data[8] + a.data[36] >= 35 && a.data[9] >= 35 && a.data[22] >= 35;
			uslovie_text[2] = GlobalScript.inst.other_text[41];
		}
		else if (this_type == 87)
		{
			this_opis = GlobalScript.inst.other_text[48];
			number_uslovie = 3;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = GlobalScript.inst.other_text[39];
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = GlobalScript.inst.other_text[44];
			uslovie_bool[2] = a.data[12] >= 500 && a.data[13] >= 500;
			uslovie_text[2] = GlobalScript.inst.other_text[45];
		}
		else if (this_type == 88)
		{
			this_opis = GlobalScript.inst.other_text[49];
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = GlobalScript.inst.other_text[39];
			uslovie_bool[1] = a.allcountries[selected_country].Torg;
			uslovie_text[1] = GlobalScript.inst.other_text[46];
			uslovie_bool[2] = a.influencePRC >= 150 && a.allcountries[selected_country].level_of_dev - a.allcountries[selected_country].level_of_unstab >= 30;
			uslovie_text[2] = GlobalScript.inst.other_text[50];
			uslovie_bool[3] = (a.allcountries[1].econ || a.allcountries[1].isSEV) && !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV;
			uslovie_text[3] = ((a.allcountries[1].econ || a.allcountries[1].isSEV) ? GlobalScript.inst.other_text[51] : GlobalScript.inst.other_text[52]);
		}
		else if (this_type == 91)
		{
			this_opis = GlobalScript.inst.other_text[58];
			number_uslovie = 4;
			uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
			uslovie_text[0] = string.Format(GlobalScript.inst.other_text[60], 5);
			uslovie_bool[1] = a.data[9] >= 30;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[61], 3);
			if (!a.event_done[366])
			{
				uslovie_bool[2] = (a.data[20] > 4 && a.data[21] >= 1977) || a.data[21] > 1977;
				uslovie_text[2] = GlobalScript.inst.other_text[62];
			}
			else
			{
				uslovie_bool[2] = !a.event_done[367];
				uslovie_text[2] = GlobalScript.inst.other_text[63];
			}
			if (!a.event_done[366])
			{
				uslovie_bool[3] = !a.event_done[366];
				uslovie_text[3] = GlobalScript.inst.other_text[64];
			}
			else
			{
				uslovie_bool[3] = a.resultOfEvents[366] != 0 && a.resultOfEvents[366] != 1;
				uslovie_text[3] = GlobalScript.inst.other_text[64];
			}
		}
		else if (this_type == 92)
		{
			this_opis = GlobalScript.inst.other_text[59];
			number_uslovie = 4;
			uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
			uslovie_text[0] = string.Format(GlobalScript.inst.other_text[60], 5);
			uslovie_bool[1] = a.data[9] >= 30;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[61], 3);
			if (!a.event_done[366])
			{
				uslovie_bool[2] = (a.data[20] > 4 && a.data[21] >= 1977) || a.data[21] > 1977;
				uslovie_text[2] = GlobalScript.inst.other_text[62];
			}
			else
			{
				uslovie_bool[2] = !a.event_done[367];
				uslovie_text[2] = GlobalScript.inst.other_text[63];
			}
			if (!a.event_done[366])
			{
				uslovie_bool[3] = !a.event_done[366];
				uslovie_text[3] = GlobalScript.inst.other_text[64];
			}
			else
			{
				uslovie_bool[3] = a.resultOfEvents[366] != 0 && a.resultOfEvents[366] != 1;
				uslovie_text[3] = GlobalScript.inst.other_text[64];
			}
		}
		else if (this_type == 93)
		{
			this_opis = "Начать углублённую торговлю";
			number_uslovie = 4;
			if (a.allcountries[selected_country].Gosstroy == 1)
			{
				uslovie_bool[0] = a.data[6] >= 800;
				uslovie_text[0] = "Дипрепутация не ниже 80";
			}
			else if (a.allcountries[selected_country].Gosstroy <= 2)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
				uslovie_text[0] = "Дипрепутация между 39 и 85";
			}
			else
			{
				uslovie_bool[0] = a.data[6] < 500;
				uslovie_text[0] = "Дипрепутация меньше 50";
			}
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Торговля не ведётся";
			uslovie_bool[2] = a.data[12] >= 500;
			uslovie_text[2] = "Промышленность не ниже 50";
			uslovie_bool[3] = a.Israellost;
			uslovie_text[3] = "Израиль проиграл Ливанскую войну";
		}
		else if (this_type == 94)
		{
			this_opis = GlobalScript.inst.other_text[66];
			number_uslovie = 2;
			uslovie_bool[0] = a.data[124] >= 1;
			uslovie_text[0] = GlobalScript.inst.other_text[67];
			uslovie_bool[1] = a.data[124] != 100;
			uslovie_text[1] = GlobalScript.inst.other_text[68];
		}
		else if (this_type == 95)
		{
			this_opis = GlobalScript.inst.other_text[69];
			number_uslovie = 3;
			uslovie_bool[0] = a.data[127] >= 1 || a.allcountries[84].Gosstroy == 2;
			uslovie_text[0] = GlobalScript.inst.other_text[70];
			uslovie_bool[1] = a.data[127] != 100;
			uslovie_text[1] = GlobalScript.inst.other_text[68];
			uslovie_bool[2] = a.data[21] >= 1983;
			uslovie_text[2] = GlobalScript.inst.other_text[71];
		}
		else if (this_type == 96)
		{
			this_opis = "Начать углублённую торговлю";
			number_uslovie = 3;
			uslovie_bool[0] = !a.allcountries[selected_country].Torg;
			uslovie_text[0] = "Торговля не ведётся";
			uslovie_bool[1] = a.data[12] >= 500;
			uslovie_text[1] = "Промышленность не ниже 50";
			uslovie_bool[2] = !a.ingamewars[8].is_going;
			uslovie_text[2] = GlobalScript.inst.other_text[72];
		}
		else if (this_type == 97)
		{
			this_opis = GlobalScript.inst.other_text[74];
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[19].proprc && ((a.allcountries[19].okb && a.allcountries[19].econ) || (a.allcountries[19].isSEV && a.allcountries[19].isOVD) || a.allcountries[19].isNATO);
			uslovie_text[0] = GlobalScript.inst.other_text[75];
			uslovie_bool[1] = a.influencePRC > 600;
			uslovie_text[1] = GlobalScript.inst.other_text[76];
			uslovie_bool[2] = a.data[8] + a.data[36] >= 200 && a.data[9] >= 200;
			uslovie_text[2] = GlobalScript.inst.other_text[77];
			uslovie_bool[3] = !a.allcountries[selected_country].proprc;
			uslovie_text[3] = GlobalScript.inst.other_text[78];
		}
		else if (this_type == 98)
		{
			this_opis = GlobalScript.inst.other_text[81];
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].Torg;
			uslovie_text[0] = GlobalScript.inst.other_text[83];
			uslovie_bool[1] = a.influencePRC > 700;
			uslovie_text[1] = GlobalScript.inst.other_text[86];
			uslovie_bool[2] = a.allcountries[1].isSEV || a.allcountries[1].econ;
			uslovie_text[2] = GlobalScript.inst.other_text[84];
			uslovie_bool[3] = !a.allcountries[selected_country].econ && !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].isASEAN;
			uslovie_text[3] = GlobalScript.inst.other_text[88];
		}
		else if (this_type == 99)
		{
			this_opis = GlobalScript.inst.other_text[82];
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].isSEV || a.allcountries[selected_country].econ;
			uslovie_text[0] = GlobalScript.inst.other_text[90];
			uslovie_bool[1] = a.influencePRC > 800;
			uslovie_text[1] = GlobalScript.inst.other_text[87];
			uslovie_bool[2] = a.allcountries[1].isSEV || a.allcountries[1].econ || a.allcountries[1].isNATO;
			uslovie_text[2] = GlobalScript.inst.other_text[84];
			uslovie_bool[3] = !a.allcountries[selected_country].okb && !a.allcountries[selected_country].isSEATO && !a.allcountries[selected_country].isOVD;
			uslovie_text[3] = GlobalScript.inst.other_text[89];
		}
		else if (this_type == 100)
		{
			number_uslovie = 3;
			this_opis = GlobalScript.inst.other_text[107];
			uslovie_bool[0] = a.influencePRC >= 700;
			uslovie_text[0] = GlobalScript.inst.other_text[86];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 150 && a.data[9] >= 150;
			uslovie_text[1] = GlobalScript.inst.other_text[108];
			uslovie_bool[2] = a.allcountries[selected_country].dev <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[109];
			if (a.allcountries[7].isNATO)
			{
				number_uslovie = 4;
				uslovie_bool[3] = !a.allcountries[7].isNATO;
				uslovie_text[3] = GlobalScript.inst.other_text[105];
			}
		}
		else if (this_type == 101)
		{
			number_uslovie = 4;
			this_opis = GlobalScript.inst.other_text[81];
			uslovie_bool[0] = a.allcountries[selected_country].based;
			uslovie_text[0] = GlobalScript.inst.other_text[169];
			uslovie_bool[1] = a.allcountries[selected_country].Torg;
			uslovie_text[1] = GlobalScript.inst.other_text[83];
			uslovie_bool[2] = !a.allcountries[selected_country].isSEV && !a.allcountries[selected_country].econ;
			uslovie_text[2] = GlobalScript.inst.other_text[88];
			uslovie_bool[3] = a.allcountries[1].isSEV || a.allcountries[1].econ;
			uslovie_text[3] = GlobalScript.inst.other_text[84];
		}
		else if (this_type == 102)
		{
			this_opis = "Начать углублённую торговлю";
			number_uslovie = 4;
			if (a.allcountries[selected_country].Gosstroy == 1)
			{
				uslovie_bool[0] = a.data[6] >= 690;
				uslovie_text[0] = "Дипрепутация больше 69";
			}
			else if (a.allcountries[selected_country].Gosstroy <= 2)
			{
				uslovie_bool[0] = a.data[6] > 390 && a.data[6] < 850;
				uslovie_text[0] = "Дипрепутация между 39 и 85";
			}
			else if (a.allcountries[selected_country].Gosstroy == 3)
			{
				uslovie_bool[0] = a.data[6] < 500;
				uslovie_text[0] = "Дипрепутация меньше 50";
			}
			uslovie_bool[1] = !a.allcountries[selected_country].Torg;
			uslovie_text[1] = "Торговля не ведётся";
			uslovie_bool[2] = a.data[12] >= 500;
			uslovie_text[2] = "Промышленность не ниже 50";
			uslovie_bool[3] = a.allcountries[selected_country].parts[0];
			uslovie_text[3] = GlobalScript.inst.other_text[117];
		}
		else if (this_type == 103)
		{
			this_opis = string.Format(GlobalScript.inst.other_text[122], GlobalScript.inst.other_text[123], (float)a.allcountries[selected_country].inflCh / 10f, GlobalScript.inst.other_text[124], (float)a.allcountries[selected_country].inflNATO / 10f, '\n');
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].inflCh < 1000;
			uslovie_text[0] = GlobalScript.inst.other_text[127];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 100;
			uslovie_text[1] = GlobalScript.inst.other_text[128];
			uslovie_bool[2] = a.data[9] >= 50;
			uslovie_text[2] = GlobalScript.inst.other_text[129];
			uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi;
			uslovie_text[3] = GlobalScript.inst.other_text[130];
		}
		else if (this_type == 104)
		{
			this_opis = string.Format(GlobalScript.inst.other_text[126], GlobalScript.inst.other_text[123], (float)a.allcountries[selected_country].inflCh / 10f, GlobalScript.inst.other_text[124], (float)a.allcountries[selected_country].inflNATO / 10f, '\n');
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].inflCh >= 350;
			uslovie_text[0] = GlobalScript.inst.other_text[125];
			uslovie_bool[1] = !a.allcountries[selected_country].econ;
			uslovie_text[1] = GlobalScript.inst.other_text[88];
			uslovie_bool[2] = a.allcountries[selected_country].Torg;
			uslovie_text[2] = GlobalScript.inst.other_text[83];
			uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi;
			uslovie_text[3] = GlobalScript.inst.other_text[130];
		}
		else if (this_type == 105)
		{
			this_opis = string.Format(GlobalScript.inst.other_text[132], GlobalScript.inst.other_text[123], (float)a.allcountries[selected_country].inflCh / 10f, GlobalScript.inst.other_text[124], (float)a.allcountries[selected_country].inflNATO / 10f, '\n');
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].inflCh >= 600;
			uslovie_text[0] = GlobalScript.inst.other_text[133];
			uslovie_bool[1] = !a.allcountries[selected_country].based && a.allcountries[selected_country].econ;
			uslovie_text[1] = GlobalScript.inst.other_text[134];
			uslovie_bool[2] = a.data[22] >= 250;
			uslovie_text[2] = GlobalScript.inst.other_text[135];
			uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi;
			uslovie_text[3] = GlobalScript.inst.other_text[130];
		}
		else if (this_type == 106)
		{
			this_opis = string.Format(GlobalScript.inst.other_text[136], GlobalScript.inst.other_text[123], (float)a.allcountries[selected_country].inflCh / 10f, GlobalScript.inst.other_text[124], (float)a.allcountries[selected_country].inflNATO / 10f, '\n');
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].inflCh >= 900;
			uslovie_text[0] = GlobalScript.inst.other_text[138];
			uslovie_bool[1] = a.allcountries[selected_country].based && !a.allcountries[selected_country].okb;
			uslovie_text[1] = GlobalScript.inst.other_text[137];
			uslovie_bool[2] = a.data[7] > a.empires[0].power + a.empires[1].power;
			uslovie_text[2] = GlobalScript.inst.other_text[139];
			uslovie_bool[3] = !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi;
			uslovie_text[3] = GlobalScript.inst.other_text[130];
		}
		else if (this_type == 107)
		{
			if (!a.modifies[41].active)
			{
				this_opis = GlobalScript.inst.other_text[141];
				number_uslovie = 4;
				uslovie_bool[0] = a.data[6] < 600 && a.data[21] > 1979;
				uslovie_text[0] = GlobalScript.inst.other_text[142];
				uslovie_bool[1] = a.allcountries[30].Vyshi && (a.allcountries[8].Gosstroy == 3 || a.allcountries[8].Vyshi);
				uslovie_text[1] = GlobalScript.inst.other_text[143];
				uslovie_bool[2] = !a.allcountries[1].isSEV && a.science[19];
				uslovie_text[2] = GlobalScript.inst.other_text[144];
				uslovie_bool[3] = (a.data[131] == 0 || a.data[131] == 3) && !a.modifies[41].active;
				uslovie_text[3] = GlobalScript.inst.other_text[145];
			}
			else
			{
				this_opis = GlobalScript.inst.other_text[146];
				number_uslovie = 1;
				uslovie_bool[0] = a.modifies[41].active;
				uslovie_text[0] = GlobalScript.inst.other_text[147];
			}
		}
		else if (this_type == 108)
		{
			this_opis = string.Format(GlobalScript.inst.other_text[152], '\n', (float)a.data[134] / 10f);
			number_uslovie = 4;
			uslovie_bool[0] = a.data[8] + a.data[36] >= 50;
			uslovie_text[0] = string.Format(GlobalScript.inst.other_text[60], 5);
			uslovie_bool[1] = a.data[22] >= 50;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[156], 5);
			uslovie_bool[2] = a.data[134] < 1000 && a.data[134] >= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[150];
			uslovie_bool[3] = !a.event_done[396];
			uslovie_text[3] = GlobalScript.inst.other_text[303];
		}
		else if (this_type == 109)
		{
			this_opis = GlobalScript.inst.other_text[153];
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 150;
			uslovie_text[0] = string.Format(GlobalScript.inst.other_text[60], 15);
			uslovie_bool[1] = a.data[22] >= 150;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[156], 15);
			uslovie_bool[2] = a.data[134] >= 1000;
			uslovie_text[2] = GlobalScript.inst.other_text[155];
			uslovie_bool[3] = !a.event_done[396] && a.empires[0].power + a.empires[1].power < 350;
			uslovie_text[3] = GlobalScript.inst.other_text[151];
		}
		else if (this_type == 110)
		{
			number_uslovie = 4;
			if (selected_country == 41)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[159], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
			}
			else if (selected_country == 99)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[167], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
			}
			else if (selected_country == 100)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[163], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
			}
			uslovie_bool[0] = a.allcountries[selected_country].inflCh < 1000;
			uslovie_text[0] = GlobalScript.inst.other_text[170];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = GlobalScript.inst.other_text[171];
			uslovie_bool[2] = a.data[22] >= 50;
			uslovie_text[2] = GlobalScript.inst.other_text[172];
			uslovie_bool[3] = !a.allcountries[selected_country].based;
			uslovie_text[3] = GlobalScript.inst.other_text[173];
		}
		else if (this_type == 111)
		{
			number_uslovie = 4;
			if (selected_country == 41)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[160], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
			}
			else if (selected_country == 99)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[168], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
			}
			else if (selected_country == 100)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[164], '\n', (float)a.allcountries[selected_country].inflCh / 10f, (float)a.allcountries[selected_country].inflNATO / 10f);
			}
			uslovie_bool[0] = a.allcountries[selected_country].inflNATO < 1000;
			uslovie_text[0] = GlobalScript.inst.other_text[174];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = GlobalScript.inst.other_text[171];
			uslovie_bool[2] = a.data[22] >= 50;
			uslovie_text[2] = GlobalScript.inst.other_text[172];
			uslovie_bool[3] = !a.allcountries[selected_country].based;
			uslovie_text[3] = GlobalScript.inst.other_text[173];
		}
		else if (this_type == 112)
		{
			number_uslovie = 3;
			this_opis = GlobalScript.inst.other_text[82];
			uslovie_bool[0] = a.allcountries[selected_country].isSEV || a.allcountries[selected_country].econ;
			uslovie_text[0] = GlobalScript.inst.other_text[90];
			uslovie_bool[1] = a.allcountries[selected_country].Torg && a.allcountries[selected_country].proprc;
			uslovie_text[1] = GlobalScript.inst.other_text[175];
			uslovie_bool[2] = !a.allcountries[selected_country].okb && !a.allcountries[selected_country].isOVD && (a.allcountries[1].isOVD || a.allcountries[1].okb);
			uslovie_text[2] = GlobalScript.inst.other_text[85];
		}
		else if (this_type == 113)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[177], '\n', a.allcountries[selected_country].inflNATO);
			uslovie_bool[0] = a.data[8] + a.data[36] >= 30 && a.data[9] >= 30;
			uslovie_text[0] = GlobalScript.inst.other_text[178];
			uslovie_bool[1] = !a.modifies[3].active;
			uslovie_text[1] = GlobalScript.inst.other_text[179];
			uslovie_bool[2] = a.allcountries[selected_country].spec <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[180];
			uslovie_bool[3] = a.data[21] < 1981;
			uslovie_text[3] = GlobalScript.inst.other_text[181];
		}
		else if (this_type == 114)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.other_text[185], '\n');
			uslovie_bool[0] = a.modifies[48].active;
			uslovie_text[0] = GlobalScript.inst.other_text[187];
			uslovie_bool[1] = a.allcountries[1].inflNATO <= 0;
			uslovie_text[1] = GlobalScript.inst.other_text[180];
			uslovie_bool[2] = a.allcountries[1].dev <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[189];
		}
		else if (this_type == 115)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.other_text[186], '\n');
			uslovie_bool[0] = a.modifies[47].active;
			uslovie_text[0] = GlobalScript.inst.other_text[188];
			uslovie_bool[1] = a.allcountries[1].inflCh <= 0;
			uslovie_text[1] = GlobalScript.inst.other_text[180];
			uslovie_bool[2] = a.allcountries[1].dev <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[189];
		}
		else if (this_type == 116)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[325], '\n');
			uslovie_bool[0] = a.influencePRC + a.empires[0].power >= a.empires[1].power || a.influencePRC >= 1000;
			uslovie_text[0] = GlobalScript.inst.other_text[326];
			uslovie_bool[1] = !a.allcountries[2].isOVD && !a.allcountries[5].isOVD && !a.allcountries[4].isOVD;
			uslovie_text[1] = GlobalScript.inst.other_text[327];
			uslovie_bool[2] = a.empires[1].now_leader == 6;
			uslovie_text[2] = GlobalScript.inst.other_text[328];
			uslovie_bool[3] = a.allcountries[17].dev <= 0;
			uslovie_text[3] = GlobalScript.inst.other_text[194];
		}
		else if (this_type == 117)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[196], '\n');
			uslovie_bool[0] = a.allcountries[1].Gosstroy != 1 && a.data[52] > 34;
			uslovie_text[0] = GlobalScript.inst.other_text[197];
			uslovie_bool[1] = !a.allcountries[1].isSEV && !a.allcountries[1].econ;
			uslovie_text[1] = GlobalScript.inst.other_text[198];
			if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
			{
				uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12);
				uslovie_text[2] = "Не атаковали их союзника";
			}
			else if (!a.allcountries[1].isASEAN)
			{
				uslovie_bool[2] = a.war <= 0;
				uslovie_text[2] = "Мы не воюем";
			}
			else
			{
				uslovie_bool[2] = !a.allcountries[1].isASEAN;
				uslovie_text[2] = GlobalScript.inst.other_text[199];
			}
			uslovie_bool[3] = a.data[21] > 1978;
			uslovie_text[3] = GlobalScript.inst.other_text[200];
		}
		else if (this_type == 118)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.other_text[202], '\n');
			uslovie_bool[0] = a.allcountries[1].isASEAN;
			uslovie_text[0] = GlobalScript.inst.other_text[203];
			uslovie_bool[1] = !a.allcountries[15].cw;
			uslovie_text[1] = GlobalScript.inst.other_text[204];
			if (GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) || GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12))
			{
				uslovie_bool[2] = !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12);
				uslovie_text[2] = "Не атаковали их союзника";
			}
			else if (!a.allcountries[1].isSEATO)
			{
				uslovie_bool[2] = a.war <= 0;
				uslovie_text[2] = "Мы не воюем";
			}
			else
			{
				uslovie_bool[2] = !a.allcountries[1].isSEATO;
				uslovie_text[2] = GlobalScript.inst.other_text[199];
			}
		}
		else if (this_type == 119)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[206], '\n');
			uslovie_bool[0] = a.allcountries[1].isASEAN;
			uslovie_text[0] = GlobalScript.inst.other_text[203];
			uslovie_bool[1] = !a.allcountries[selected_country].prosov;
			uslovie_text[1] = GlobalScript.inst.other_text[207];
			uslovie_bool[2] = !a.allcountries[selected_country].isASEAN && !a.allcountries[selected_country].isSEV;
			uslovie_text[2] = GlobalScript.inst.other_text[208];
			if (selected_country != 38)
			{
				uslovie_bool[3] = a.allcountries[selected_country].Gosstroy != 1;
				uslovie_text[3] = GlobalScript.inst.other_text[209];
			}
			else
			{
				uslovie_bool[3] = a.data[64] == 1 || a.completedDecisions[6];
				uslovie_text[3] = GlobalScript.inst.other_text[233];
			}
		}
		else if (this_type == 120)
		{
			number_uslovie = 3;
			if (!a.allcountries[51].cw)
			{
				this_opis = string.Format(GlobalScript.inst.other_text[210], '\n');
			}
			else
			{
				this_opis = string.Format(GlobalScript.inst.other_text[211], '\n');
			}
			uslovie_bool[0] = a.allcountries[1].isASEAN;
			if (!a.allcountries[51].cw)
			{
				uslovie_text[0] = GlobalScript.inst.other_text[212];
			}
			else
			{
				uslovie_text[0] = GlobalScript.inst.other_text[213];
			}
			uslovie_bool[1] = a.allcountries[selected_country].isASEAN;
			uslovie_text[1] = GlobalScript.inst.other_text[214];
			uslovie_bool[2] = !a.allcountries[selected_country].isSEATO && !a.allcountries[selected_country].isOVD;
			uslovie_text[2] = GlobalScript.inst.other_text[215];
			if (selected_country == 8 || selected_country == 12 || selected_country == 14 || selected_country == 35 || selected_country == 31 || selected_country == 37 || selected_country == 36 || selected_country == 25 || selected_country == 104)
			{
				number_uslovie = 4;
				uslovie_bool[3] = a.allcountries[51].cw;
				uslovie_text[3] = GlobalScript.inst.other_text[216];
			}
		}
		else if (this_type == 121)
		{
			if (selected_country == 24)
			{
				this_opis = GlobalScript.inst.other_text[218];
			}
			else
			{
				this_opis = GlobalScript.inst.other_text[206];
			}
			number_uslovie = 4;
			uslovie_bool[0] = a.allcountries[selected_country].Torg;
			uslovie_text[0] = GlobalScript.inst.other_text[83];
			if (selected_country == 24)
			{
				uslovie_bool[1] = a.allcountries[1].isSEV;
				uslovie_text[1] = GlobalScript.inst.other_text[220];
			}
			else
			{
				uslovie_bool[1] = a.allcountries[1].isASEAN;
				uslovie_text[1] = GlobalScript.inst.other_text[203];
			}
			uslovie_bool[2] = !a.allcountries[selected_country].isASEAN && !a.allcountries[selected_country].isSEV;
			uslovie_text[2] = GlobalScript.inst.other_text[88];
			uslovie_bool[3] = a.allcountries[selected_country].parts[0];
			uslovie_text[3] = GlobalScript.inst.other_text[219];
		}
		else if (this_type == 122)
		{
			this_opis = GlobalScript.inst.other_text[221];
			number_uslovie = 3;
			uslovie_bool[0] = a.data[9] >= 100 && a.data[8] + a.data[36] >= 300;
			uslovie_text[0] = GlobalScript.inst.other_text[222];
			uslovie_bool[1] = a.event_done[91] && a.allcountries[46].Gosstroy == 0;
			uslovie_text[1] = GlobalScript.inst.other_text[223];
			uslovie_bool[2] = a.allcountries[selected_country].dev == 0;
			uslovie_text[2] = GlobalScript.inst.other_text[224];
		}
		else if (this_type == 123)
		{
			this_opis = GlobalScript.inst.other_text[227];
			number_uslovie = 4;
			uslovie_bool[0] = a.data[9] >= 50 && a.data[8] + a.data[36] >= 30;
			uslovie_text[0] = GlobalScript.inst.other_text[228];
			uslovie_bool[1] = !a.modifies[6].active;
			uslovie_text[1] = GlobalScript.inst.other_text[229];
			uslovie_bool[2] = a.data[6] <= 750;
			uslovie_text[2] = GlobalScript.inst.other_text[230];
			if (a.empires[1].power < 50)
			{
				uslovie_bool[3] = a.empires[1].power >= 50;
				uslovie_text[3] = GlobalScript.inst.other_text[231];
			}
			else
			{
				uslovie_bool[3] = !a.war_active[1];
				uslovie_text[3] = GlobalScript.inst.other_text[232];
			}
		}
		else if (this_type == 124)
		{
			number_uslovie = 2;
			this_opis = GlobalScript.inst.other_text[235];
			uslovie_bool[0] = a.allcountries[1].isSEV || a.allcountries[1].isASEAN;
			uslovie_text[0] = GlobalScript.inst.other_text[236];
			uslovie_bool[1] = !a.allcountries[1].based;
			uslovie_text[1] = GlobalScript.inst.other_text[237];
		}
		else if (this_type == 125)
		{
			number_uslovie = 4;
			if (a.allcountries[1].isSEATO)
			{
				this_opis = GlobalScript.inst.other_text[239];
			}
			else
			{
				this_opis = GlobalScript.inst.other_text[252];
			}
			uslovie_bool[0] = a.allcountries[selected_country].prcinfl >= 800;
			uslovie_text[0] = GlobalScript.inst.other_text[284];
			uslovie_bool[1] = a.data[9] >= 100 && a.data[8] + a.data[36] >= 50;
			uslovie_text[1] = GlobalScript.inst.other_text[241];
			if (a.allcountries[1].isSEATO)
			{
				uslovie_bool[2] = a.empires[0].relations >= 700;
				uslovie_text[2] = GlobalScript.inst.other_text[242];
			}
			else
			{
				uslovie_bool[2] = a.empires[1].relations >= 700;
				uslovie_text[2] = GlobalScript.inst.other_text[253];
			}
			uslovie_bool[3] = !a.allcountries[selected_country].perevorot;
			uslovie_text[3] = GlobalScript.inst.other_text[237];
		}
		else if (this_type == 126)
		{
			number_uslovie = 4;
			this_opis = GlobalScript.inst.other_text[245];
			uslovie_bool[0] = a.allcountries[11].isSEATO && a.allcountries[34].isSEATO && a.allcountries[23].isSEATO;
			uslovie_text[0] = GlobalScript.inst.other_text[246];
			uslovie_bool[1] = a.influencePRC + a.empires[0].power >= a.empires[1].power;
			uslovie_text[1] = GlobalScript.inst.other_text[247];
			uslovie_bool[2] = a.data[8] + a.data[36] >= 100 && a.data[9] >= 100 && a.data[2] >= 250;
			uslovie_text[2] = GlobalScript.inst.other_text[248];
			uslovie_bool[3] = !a.allcountries[selected_country].cw;
			uslovie_text[3] = GlobalScript.inst.other_text[249];
		}
		else if (this_type == 127)
		{
			number_uslovie = 4;
			this_opis = GlobalScript.inst.other_text[257];
			uslovie_bool[0] = a.data[131] == 3;
			uslovie_text[0] = GlobalScript.inst.other_text[258];
			uslovie_bool[1] = a.influencePRC >= a.empires[0].power;
			uslovie_text[1] = GlobalScript.inst.other_text[259];
			uslovie_bool[2] = !a.allcountries[85].isNATO && !a.allcountries[45].isNATO && !a.allcountries[87].isNATO && !a.allcountries[85].isEU && !a.allcountries[45].isEU && !a.allcountries[87].isEU;
			uslovie_text[2] = GlobalScript.inst.other_text[260];
			uslovie_bool[3] = a.allcountries[21].isNATO;
			uslovie_text[3] = GlobalScript.inst.other_text[261];
		}
		else if (this_type == 128)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[264], '\n', a.allcountries[87].spec);
			uslovie_bool[0] = a.allcountries[87].spec < 100;
			uslovie_text[0] = GlobalScript.inst.other_text[266];
			uslovie_bool[1] = a.data[8] + a.data[36] >= a.allcountries[87].inflCh && a.data[9] >= a.allcountries[87].inflNATO;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[267], (float)a.allcountries[87].inflNATO / 10f, (float)a.allcountries[87].inflCh / 10f);
			uslovie_bool[2] = a.allcountries[87].Gosstroy != 3;
			uslovie_text[2] = GlobalScript.inst.other_text[269];
			if (!a.event_done[414])
			{
				uslovie_bool[3] = a.event_done[414];
				uslovie_text[3] = GlobalScript.inst.other_text[268];
			}
			else
			{
				uslovie_bool[3] = a.data[21] < 1982 && !a.allcountries[87].based;
				uslovie_text[3] = GlobalScript.inst.other_text[265];
			}
		}
		else if (this_type == 129)
		{
			number_uslovie = 4;
			this_opis = GlobalScript.inst.other_text[271];
			uslovie_bool[0] = (a.allcountries[1].econ && a.allcountries[11].econ && a.allcountries[34].econ && a.allcountries[47].econ) || (a.allcountries[1].isSEV && a.allcountries[11].isSEV && a.allcountries[34].isSEV && a.allcountries[47].isSEV) || (a.allcountries[1].isASEAN && a.allcountries[11].isASEAN && a.allcountries[34].isASEAN && a.allcountries[47].isASEAN);
			uslovie_text[0] = GlobalScript.inst.other_text[272];
			uslovie_bool[1] = !a.allcountries[1].isASEAN;
			uslovie_text[1] = GlobalScript.inst.other_text[273];
			uslovie_bool[2] = a.allcountries[49].isASEAN;
			uslovie_text[2] = GlobalScript.inst.other_text[274];
			if (!a.allcountries[1].isSEV)
			{
				uslovie_bool[3] = a.influencePRC >= 300 && a.data[8] + a.data[36] >= 150;
				uslovie_text[3] = GlobalScript.inst.other_text[275];
			}
			else
			{
				uslovie_bool[3] = a.influencePRC + a.empires[1].power >= 300 && a.data[8] + a.data[36] >= 150;
				uslovie_text[3] = GlobalScript.inst.other_text[276];
			}
		}
		else if (this_type == 130)
		{
			number_uslovie = 3;
			if (a.allcountries[selected_country].sovinfl > 1000)
			{
				a.allcountries[selected_country].sovinfl = 1000;
			}
			if (a.allcountries[selected_country].sovinfl < 0)
			{
				a.allcountries[selected_country].sovinfl = 0;
			}
			if (a.allcountries[selected_country].prcinfl > 1000)
			{
				a.allcountries[selected_country].prcinfl = 1000;
			}
			if (a.allcountries[selected_country].prcinfl < 0)
			{
				a.allcountries[selected_country].prcinfl = 0;
			}
			this_opis = string.Format(GlobalScript.inst.other_text[278], '\n', (float)a.allcountries[selected_country].sovinfl / 10f, (float)a.allcountries[selected_country].prcinfl / 10f);
			uslovie_bool[0] = a.allcountries[selected_country].prosov || (!a.allcountries[selected_country].proprc && !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi);
			uslovie_text[0] = GlobalScript.inst.other_text[279];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50 && a.data[22] >= 80;
			uslovie_text[1] = GlobalScript.inst.other_text[280];
			uslovie_bool[2] = a.allcountries[selected_country].prcinfl < 1000;
			uslovie_text[2] = GlobalScript.inst.other_text[281];
		}
		else if (this_type == 131)
		{
			number_uslovie = 3;
			if (a.allcountries[selected_country].usainfl > 1000)
			{
				a.allcountries[selected_country].usainfl = 1000;
			}
			if (a.allcountries[selected_country].usainfl < 0)
			{
				a.allcountries[selected_country].usainfl = 0;
			}
			if (a.allcountries[selected_country].prcinfl > 1000)
			{
				a.allcountries[selected_country].prcinfl = 1000;
			}
			if (a.allcountries[selected_country].prcinfl < 0)
			{
				a.allcountries[selected_country].prcinfl = 0;
			}
			this_opis = string.Format(GlobalScript.inst.other_text[282], '\n', (float)a.allcountries[selected_country].usainfl / 10f, (float)a.allcountries[selected_country].prcinfl / 10f);
			uslovie_bool[0] = a.allcountries[selected_country].Vyshi || (!a.allcountries[selected_country].proprc && !a.allcountries[selected_country].prosov && !a.allcountries[selected_country].Vyshi);
			uslovie_text[0] = GlobalScript.inst.other_text[283];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50 && a.data[22] >= 80;
			uslovie_text[1] = GlobalScript.inst.other_text[280];
			uslovie_bool[2] = a.allcountries[selected_country].prcinfl < 1000;
			uslovie_text[2] = GlobalScript.inst.other_text[281];
		}
		else if (this_type == 132)
		{
			number_uslovie = 3;
			this_opis = GlobalScript.inst.other_text[286];
			uslovie_bool[0] = a.allcountries[selected_country].proprc;
			uslovie_text[0] = GlobalScript.inst.other_text[287];
			uslovie_bool[1] = a.allcountries[selected_country].SubGosstroy != a.allcountries[1].SubGosstroy;
			uslovie_text[1] = GlobalScript.inst.other_text[288];
			uslovie_bool[2] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50;
			uslovie_text[2] = GlobalScript.inst.other_text[289];
		}
		else if (this_type == 133)
		{
			number_uslovie = 4;
			this_opis = GlobalScript.inst.other_text[294];
			uslovie_bool[0] = a.allcountries[36].cw && a.allcountries[14].puppetOf <= 0;
			uslovie_text[0] = GlobalScript.inst.other_text[295];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 250 && a.data[9] >= 150 && a.data[22] >= 350;
			uslovie_text[1] = GlobalScript.inst.other_text[296];
			if (a.allcountries[1].okb)
			{
				uslovie_bool[2] = a.influencePRC >= a.empires[0].power + a.empires[1].power;
				uslovie_text[2] = GlobalScript.inst.other_text[297];
			}
			else if (a.allcountries[1].isOVD)
			{
				uslovie_bool[2] = a.influencePRC + a.empires[1].power >= a.empires[0].power;
				uslovie_text[2] = GlobalScript.inst.other_text[300];
			}
			else if (a.allcountries[1].isSEATO)
			{
				uslovie_bool[2] = a.influencePRC + a.empires[0].power >= a.empires[1].power;
				uslovie_text[2] = GlobalScript.inst.other_text[301];
			}
			else
			{
				uslovie_bool[2] = a.allcountries[1].okb || a.allcountries[1].isSEATO || a.allcountries[1].isOVD;
				uslovie_text[2] = GlobalScript.inst.other_text[302];
			}
			uslovie_bool[3] = !a.allcountries[14].cw;
			uslovie_text[3] = GlobalScript.inst.other_text[298];
		}
		else if (this_type == 134)
		{
			if (a.allcountries[selected_country].usainfl > 1000)
			{
				a.allcountries[selected_country].usainfl = 1000;
			}
			if (a.allcountries[selected_country].prcinfl > 1000)
			{
				a.allcountries[selected_country].prcinfl = 1000;
			}
			if (a.allcountries[selected_country].sovinfl > 1000)
			{
				a.allcountries[selected_country].sovinfl = 1000;
			}
			if (a.allcountries[selected_country].usainfl < 0)
			{
				a.allcountries[selected_country].usainfl = 0;
			}
			if (a.allcountries[selected_country].prcinfl < 0)
			{
				a.allcountries[selected_country].prcinfl = 0;
			}
			if (a.allcountries[selected_country].sovinfl < 0)
			{
				a.allcountries[selected_country].sovinfl = 0;
			}
			if (!a.allcountries[selected_country].dota)
			{
				number_uslovie = 2;
				this_opis = string.Format("{0}{1}{3}: {2}; {5}: {4}", GlobalScript.inst.other_text[304], '\n', a.allcountries[1].isSEATO ? ((float)a.allcountries[selected_country].usainfl / 10f) : ((float)a.allcountries[selected_country].sovinfl / 10f), a.allcountries[1].isSEATO ? GlobalScript.inst.new_texts[167] : GlobalScript.inst.new_texts[168], (float)a.allcountries[selected_country].prcinfl / 10f, GlobalScript.inst.new_events_text[1214]);
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = GlobalScript.inst.other_text[287];
				uslovie_bool[1] = !a.allcountries[selected_country].dota;
				uslovie_text[1] = GlobalScript.inst.other_text[305];
			}
			else
			{
				number_uslovie = 1;
				this_opis = string.Format("{0}{1}{3}:{2}; {5}: {4}", GlobalScript.inst.other_text[306], '\n', a.allcountries[1].isSEATO ? ((float)a.allcountries[selected_country].usainfl / 10f) : ((float)a.allcountries[selected_country].sovinfl), a.allcountries[1].isSEATO ? GlobalScript.inst.new_texts[167] : GlobalScript.inst.new_texts[168], (float)a.allcountries[selected_country].prcinfl / 10f, GlobalScript.inst.new_events_text[1214]);
				uslovie_bool[0] = a.allcountries[selected_country].proprc;
				uslovie_text[0] = GlobalScript.inst.other_text[307];
			}
		}
		else if (this_type == 135)
		{
			if (!a.modifies[53].active)
			{
				this_opis = GlobalScript.inst.other_text[311];
				number_uslovie = 4;
				uslovie_bool[0] = a.relres;
				uslovie_text[0] = GlobalScript.inst.other_text[312];
				uslovie_bool[1] = a.allcountries[1].Gosstroy == 1 || a.allcountries[1].proprc;
				uslovie_text[1] = GlobalScript.inst.other_text[313];
				uslovie_bool[2] = !a.allcountries[1].isASEAN && a.science[19];
				uslovie_text[2] = GlobalScript.inst.other_text[315];
				uslovie_bool[3] = !a.modifies[41].active;
				uslovie_text[3] = GlobalScript.inst.other_text[314];
			}
			else
			{
				this_opis = GlobalScript.inst.other_text[316];
				number_uslovie = 1;
				uslovie_bool[0] = a.modifies[53].active;
				uslovie_text[0] = GlobalScript.inst.other_text[317];
			}
		}
		else if (this_type == 136)
		{
			this_opis = GlobalScript.inst.other_text[318];
			number_uslovie = 3;
			uslovie_bool[0] = a.data[8] + a.data[36] >= 50 && a.data[9] >= 50;
			uslovie_text[0] = GlobalScript.inst.other_text[319];
			uslovie_bool[1] = a.data[21] < 1978 || (a.data[21] == 1978 && a.data[20] < 11);
			uslovie_text[1] = GlobalScript.inst.other_text[320];
			uslovie_bool[2] = !a.allcountries[86].based;
			uslovie_text[2] = GlobalScript.inst.other_text[321];
		}
		else if (this_type == 137)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[330], '\n');
			uslovie_bool[0] = a.influencePRC >= a.empires[0].power + a.empires[1].power;
			uslovie_text[0] = GlobalScript.inst.other_text[331];
			uslovie_bool[1] = !a.modifies[17].active && !a.modifies[16].active && a.empires[0].relations >= 900 && a.empires[1].relations >= 900;
			uslovie_text[1] = GlobalScript.inst.other_text[332];
			uslovie_bool[2] = (a.empires[1].now_leader == 6 && a.empires[0].now_leader == 3) || a.allcountries[21].isSocEU;
			uslovie_text[2] = GlobalScript.inst.other_text[333];
			uslovie_bool[3] = a.allcountries[17].dev <= 0;
			uslovie_text[3] = GlobalScript.inst.other_text[194];
		}
		else if (this_type == 138)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[335], '\n');
			int num7 = 0;
			if (a.allcountries[21].Gosstroy == 1)
			{
				num7++;
			}
			if (a.allcountries[85].Gosstroy == 1)
			{
				num7++;
			}
			if (a.allcountries[86].Gosstroy == 1)
			{
				num7++;
			}
			if (a.allcountries[87].Gosstroy == 1)
			{
				num7++;
			}
			if (a.allcountries[92].Gosstroy == 1)
			{
				num7++;
			}
			uslovie_bool[0] = num7 >= 3;
			uslovie_text[0] = GlobalScript.inst.other_text[336];
			uslovie_bool[1] = a.relres;
			uslovie_text[1] = GlobalScript.inst.other_text[337];
			uslovie_bool[2] = !a.allcountries[17].isNATO && !a.allcountries[17].isEU;
			uslovie_text[2] = GlobalScript.inst.other_text[338];
			uslovie_bool[3] = a.allcountries[17].dev <= 0;
			uslovie_text[3] = GlobalScript.inst.other_text[194];
		}
		else if (this_type == 139)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.other_text[427], '\n');
			uslovie_bool[0] = a.influencePRC >= a.empires[0].power + a.empires[1].power || a.influencePRC >= 800;
			uslovie_text[0] = GlobalScript.inst.other_text[428];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 150;
			uslovie_text[1] = GlobalScript.inst.other_text[429];
			uslovie_bool[2] = a.allcountries[18].spec <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[430];
		}
		else if (this_type == 140)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.other_text[431], '\n');
			uslovie_bool[0] = a.influencePRC >= a.empires[0].power + a.empires[1].power || a.influencePRC >= 800;
			uslovie_text[0] = GlobalScript.inst.other_text[428];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 150;
			uslovie_text[1] = GlobalScript.inst.other_text[429];
			uslovie_bool[2] = a.allcountries[18].spec <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[430];
		}
		else if (this_type == 141)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.other_text[432], '\n');
			uslovie_bool[0] = a.influencePRC >= a.empires[0].power + a.empires[1].power || a.influencePRC >= 800;
			uslovie_text[0] = GlobalScript.inst.other_text[428];
			uslovie_bool[1] = a.data[8] + a.data[36] >= 150;
			uslovie_text[1] = GlobalScript.inst.other_text[429];
			uslovie_bool[2] = a.allcountries[18].spec <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[430];
		}
		else if (this_type == 142)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[448], '\n', GlobalScript.inst.gameState.allcountries[selected_country].name, (float)GlobalScript.inst.gameState.allcountries[selected_country].inflCh / 10f);
			uslovie_bool[0] = a.data[22] >= 50;
			uslovie_text[0] = GlobalScript.inst.other_text[449];
			uslovie_bool[1] = a.allcountries[selected_country].sovinfl <= 0;
			uslovie_text[1] = GlobalScript.inst.other_text[450];
			uslovie_bool[2] = a.allcountries[selected_country].inflCh < 1000;
			uslovie_text[2] = GlobalScript.inst.other_text[452];
			uslovie_bool[3] = a.event_done[418];
			uslovie_text[3] = GlobalScript.inst.other_text[451];
		}
		else if (this_type == 143)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[453], '\n', GlobalScript.inst.gameState.allcountries[selected_country].name, (float)GlobalScript.inst.gameState.allcountries[selected_country].inflCh / 10f);
			uslovie_bool[0] = a.data[9] >= 50;
			uslovie_text[0] = GlobalScript.inst.other_text[454];
			uslovie_bool[1] = a.allcountries[selected_country].usainfl <= 0;
			uslovie_text[1] = GlobalScript.inst.other_text[450];
			uslovie_bool[2] = a.allcountries[selected_country].inflCh < 1000;
			uslovie_text[2] = GlobalScript.inst.other_text[452];
			uslovie_bool[3] = a.event_done[418];
			uslovie_text[3] = GlobalScript.inst.other_text[451];
		}
		else if (this_type == 144)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[455], '\n', GlobalScript.inst.gameState.allcountries[selected_country].name, (float)GlobalScript.inst.gameState.allcountries[selected_country].inflCh / 10f);
			uslovie_bool[0] = a.data[8] + a.data[36] >= 30;
			uslovie_text[0] = GlobalScript.inst.other_text[456];
			uslovie_bool[1] = a.allcountries[selected_country].prcinfl <= 0;
			uslovie_text[1] = GlobalScript.inst.other_text[450];
			uslovie_bool[2] = a.allcountries[selected_country].inflCh < 1000;
			uslovie_text[2] = GlobalScript.inst.other_text[452];
			uslovie_bool[3] = a.event_done[418];
			uslovie_text[3] = GlobalScript.inst.other_text[451];
		}
		else if (this_type == 145)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[460], '\n', (a.data[143] + 5 <= 60) ? (a.data[143] + 5) : 60);
			int num8 = 0;
			for (int num9 = 101; num9 < 107; num9++)
			{
				if (a.allcountries[num9].proprc)
				{
					num8++;
				}
			}
			if (a.allcountries[36].proprc)
			{
				num8++;
			}
			uslovie_bool[0] = num8 >= 3;
			uslovie_text[0] = GlobalScript.inst.other_text[461];
			uslovie_bool[1] = a.data[9] >= 50;
			uslovie_text[1] = GlobalScript.inst.other_text[454];
			uslovie_bool[2] = a.allcountries[36].inflNATO <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[450];
			uslovie_bool[3] = a.data[143] < 60;
			uslovie_text[3] = GlobalScript.inst.other_text[462];
		}
		else if (this_type == 146)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[463], '\n', (a.data[143] - 5 >= 10) ? (a.data[143] - 5) : 10);
			int num10 = 0;
			for (int num11 = 101; num11 < 107; num11++)
			{
				if (a.allcountries[num11].proprc)
				{
					num10++;
				}
			}
			if (a.allcountries[36].proprc)
			{
				num10++;
			}
			uslovie_bool[0] = num10 >= 3;
			uslovie_text[0] = GlobalScript.inst.other_text[461];
			uslovie_bool[1] = a.data[9] >= 50;
			uslovie_text[1] = GlobalScript.inst.other_text[454];
			uslovie_bool[2] = a.allcountries[36].inflNATO <= 0;
			uslovie_text[2] = GlobalScript.inst.other_text[450];
			uslovie_bool[3] = a.data[143] > 10;
			uslovie_text[3] = GlobalScript.inst.other_text[464];
		}
		else if (this_type == 147)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[468], '\n');
			uslovie_bool[0] = a.data[8] + a.data[36] >= 100;
			uslovie_text[0] = GlobalScript.inst.other_text[469];
			uslovie_bool[1] = a.data[9] >= 50 && a.data[22] >= 100;
			uslovie_text[1] = GlobalScript.inst.other_text[470];
			uslovie_bool[2] = a.allcountries[selected_country].stab > 0;
			uslovie_text[2] = GlobalScript.inst.other_text[471];
			uslovie_bool[3] = a.allcountries[selected_country].spec <= 0;
			uslovie_text[3] = GlobalScript.inst.other_text[472];
		}
		else if (this_type == 148)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[479], '\n');
			uslovie_bool[0] = a.data[8] + a.data[36] >= 200;
			uslovie_text[0] = GlobalScript.inst.other_text[481];
			uslovie_bool[1] = a.data[9] >= 200;
			uslovie_text[1] = GlobalScript.inst.other_text[482];
			uslovie_bool[2] = !a.allcountries[0].isNATO && !a.allcountries[0].isEU;
			uslovie_text[2] = GlobalScript.inst.other_text[483];
			uslovie_bool[3] = !a.allcountries[selected_country].cw;
			uslovie_text[3] = GlobalScript.inst.other_text[484];
		}
		else if (this_type == 149)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[480], '\n');
			uslovie_bool[0] = a.data[8] + a.data[36] >= 200;
			uslovie_text[0] = GlobalScript.inst.other_text[481];
			uslovie_bool[1] = a.data[9] >= 200;
			uslovie_text[1] = GlobalScript.inst.other_text[482];
			uslovie_bool[2] = !a.allcountries[0].isNATO && !a.allcountries[0].isEU;
			uslovie_text[2] = GlobalScript.inst.other_text[483];
			uslovie_bool[3] = !a.allcountries[selected_country].cw;
			uslovie_text[3] = GlobalScript.inst.other_text[484];
		}
		else if (this_type == 151)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[560], '\n');
			uslovie_bool[0] = a.data[8] + a.data[36] >= 200 && a.data[9] >= 200;
			uslovie_text[0] = GlobalScript.inst.other_text[77];
			uslovie_bool[1] = a.allcountries[45].econ && a.allcountries[15].econ && a.allcountries[5].econ;
			uslovie_text[1] = GlobalScript.inst.other_text[561];
			uslovie_bool[2] = !a.allcountries[6].isOVD;
			uslovie_text[2] = GlobalScript.inst.other_text[562];
			uslovie_bool[3] = a.allcountries[6].Gosstroy == 1;
			uslovie_text[3] = GlobalScript.inst.other_text[313];
		}
		else if (this_type == 152)
		{
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[560], '\n');
			uslovie_bool[0] = a.data[8] + a.data[36] >= 200 && a.data[9] >= 200;
			uslovie_text[0] = GlobalScript.inst.other_text[77];
			uslovie_bool[1] = a.allcountries[45].econ && a.allcountries[15].econ && a.allcountries[5].econ;
			uslovie_text[1] = GlobalScript.inst.other_text[561];
			uslovie_bool[2] = !a.allcountries[3].isOVD;
			uslovie_text[2] = GlobalScript.inst.other_text[562];
			uslovie_bool[3] = a.allcountries[3].Gosstroy == 1;
			uslovie_text[3] = GlobalScript.inst.other_text[313];
		}
		else if (this_type == 153)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.new_texts[884], '\n');
			uslovie_bool[0] = a.allcountries[selected_country].Gosstroy == 0 || a.allcountries[selected_country].puppetOf == 1;
			uslovie_text[0] = GlobalScript.inst.new_texts[886];
			uslovie_bool[1] = a.allcountries[selected_country].proprc;
			uslovie_text[1] = GlobalScript.inst.new_texts[887];
			uslovie_bool[2] = a.data[167] <= 0;
			uslovie_text[2] = GlobalScript.inst.new_texts[890];
		}
		else if (this_type == 154)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.new_texts[885], '\n');
			uslovie_bool[0] = a.allcountries[selected_country].Gosstroy == 0 || a.allcountries[selected_country].Gosstroy == 1 || a.allcountries[selected_country].puppetOf == 1;
			uslovie_text[0] = GlobalScript.inst.new_texts[888];
			uslovie_bool[1] = a.allcountries[selected_country].proprc || a.allcountries[selected_country].okb;
			uslovie_text[1] = GlobalScript.inst.new_texts[889];
			uslovie_bool[2] = a.data[167] <= 0;
			uslovie_text[2] = GlobalScript.inst.new_texts[890];
		}
		else if (this_type == 155)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.new_texts[893], '\n');
			uslovie_bool[0] = a.data[168] >= 100;
			uslovie_text[0] = GlobalScript.inst.new_texts[896];
			uslovie_bool[1] = a.data[169] <= (a.data[168] + a.data[169]) / 4;
			uslovie_text[1] = GlobalScript.inst.new_texts[897];
			uslovie_bool[2] = !a.IsBankAccountFreezed;
			uslovie_text[2] = GlobalScript.inst.new_texts[895];
		}
		else if (this_type == 156)
		{
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.new_texts[894], '\n');
			uslovie_bool[0] = a.data[168] >= 100;
			uslovie_text[0] = GlobalScript.inst.new_texts[896];
			uslovie_bool[1] = a.data[169] <= (a.data[168] + a.data[169]) / 4;
			uslovie_text[1] = GlobalScript.inst.new_texts[897];
			uslovie_bool[2] = !a.IsBankAccountFreezed;
			uslovie_text[2] = GlobalScript.inst.new_texts[895];
		}
	}

	private void OnMouseDown()
	{
		GameObject.Find("Ach(Clone)");
		if ((is_active || selectedWar >= 0) && (number_uslovie == 0 || (number_uslovie == 1 && uslovie_bool[0]) || (number_uslovie == 2 && uslovie_bool[0] && uslovie_bool[1]) || (number_uslovie == 3 && uslovie_bool[0] && uslovie_bool[1] && uslovie_bool[2]) || (number_uslovie == 4 && uslovie_bool[0] && uslovie_bool[1] && uslovie_bool[2] && uslovie_bool[3])))
		{
			if (a.PlayerCountry == 1)
			{
				SelectedEffectChina();
			}
			else if (a.PlayerCountry == 21)
			{
				FrenchDiplo.ButtonsResult(this_type, (MinorCountries)selected_country);
			}
			else
			{
				SovietDiplo.ButtonsResult(this_type, (MinorCountries)selected_country);
			}
			map1.UpdateMap();
			map1.ShowHideOcno(active: false);
		}
	}

	private void SelectedEffectChina()
	{
		if (selectedWar >= 0)
		{
			int num = selectedWar + 1;
			a.war = num;
			a.startedDirectWarsNum.Add(num, value: false);
			switch (num)
			{
			case 1:
				a.data[163] = 200;
				a.data[1] += 50;
				a.empires[1].relations -= 200;
				a.data[6] += 20;
				a.data[22] -= 2500;
				break;
			case 2:
				a.data[163] = a.data[32] / 2;
				a.empires[1].relations -= 100;
				a.empires[0].relations -= 50;
				a.allcountries[selected_country].dev = 1;
				break;
			case 3:
				a.data[163] = 10;
				a.empires[1].relations -= 250;
				a.empires[0].relations = 0;
				a.data[162] -= 5000;
				a.data[6] += 500;
				a.IsBankAccountFreezed = true;
				break;
			case 4:
				a.data[163] = 50;
				if (a.allcountries[22].proprc)
				{
					a.data[163] += 50;
				}
				if (a.allcountries[23].proprc)
				{
					a.data[163] += 50;
				}
				a.empires[1].relations -= 500;
				a.empires[0].relations -= 250;
				a.data[22] -= 2500;
				a.data[6] += 100;
				break;
			case 5:
				a.data[163] = 250;
				a.empires[1].relations -= 100;
				a.empires[0].relations -= 100;
				a.data[22] -= 2500;
				a.data[6] += 100;
				break;
			case 6:
				a.data[163] = 250;
				a.empires[1].relations -= 100;
				a.empires[0].relations -= 150;
				a.data[22] -= 2500;
				a.data[6] += 100;
				break;
			case 7:
				a.data[163] = 50;
				if (a.allcountries[22].proprc)
				{
					a.data[163] += 50;
				}
				if (a.allcountries[33].proprc)
				{
					a.data[163] += 50;
				}
				a.empires[0].relations -= 250;
				a.data[22] -= 3000;
				a.data[6] += 100;
				a.IsBankAccountFreezed = true;
				break;
			case 8:
				a.data[163] = 50;
				if (a.allcountries[22].proprc)
				{
					a.data[163] += 50;
				}
				if (a.allcountries[33].proprc)
				{
					a.data[163] += 50;
				}
				a.empires[1].relations -= 250;
				a.empires[0].relations -= 500;
				a.data[22] -= 3000;
				a.data[6] += 200;
				a.IsBankAccountFreezed = true;
				break;
			case 9:
				a.data[163] = 50;
				if (a.allcountries[19].IsInTheSameMilitaryAllianceWith(a.allcountries[1]))
				{
					a.data[163] += 150;
				}
				if (a.allcountries[34].proprc)
				{
					a.data[163] += 50;
				}
				a.empires[1].relations -= 250;
				a.empires[0].relations -= 250;
				a.data[22] -= 2500;
				a.data[6] += 100;
				break;
			case 10:
				a.data[163] = 50;
				a.empires[1].relations = 0;
				a.empires[0].relations += 250;
				a.data[22] -= 2500;
				a.data[6] -= 100;
				break;
			case 11:
				a.data[163] = 10;
				a.empires[1].relations = 0;
				a.empires[0].relations -= 250;
				a.data[162] -= 5000;
				a.data[6] += 500;
				break;
			case 12:
				a.data[163] = 500;
				a.empires[1].relations -= 50;
				a.empires[0].relations -= 250;
				a.data[162] -= 500;
				a.data[6] += 100;
				break;
			case 13:
				a.data[163] = 250;
				a.empires[1].relations += 50;
				a.empires[0].relations -= 25;
				a.data[22] -= 2500;
				a.data[6]++;
				break;
			case 14:
				a.data[163] = 250;
				if (a.allcountries[19].IsInTheSameMilitaryAllianceWith(a.allcountries[1]))
				{
					a.data[163] += 150;
				}
				a.empires[1].relations -= 150;
				a.empires[0].relations -= 150;
				a.data[22] -= 2500;
				a.data[6] += 50;
				break;
			case 15:
				a.data[163] = 50;
				if (a.allcountries[44].proprc)
				{
					a.data[163] += 50;
				}
				if (a.allcountries[38].proprc)
				{
					a.data[163] += 50;
				}
				a.empires[0].relations = 0;
				a.data[162] -= 500;
				a.data[6] += 150;
				a.IsBankAccountFreezed = true;
				break;
			case 16:
				a.data[163] = 250;
				if (a.allcountries[44].proprc)
				{
					a.data[163] += 50;
				}
				if (a.allcountries[38].proprc)
				{
					a.data[163] += 50;
				}
				a.empires[0].relations -= 250;
				a.data[162] -= 500;
				a.data[6] += 10;
				a.IsBankAccountFreezed = true;
				break;
			case 17:
			{
				a.data[163] = 250;
				a.data[22] -= 2500;
				a.data[6] += 70;
				a.data[1] -= 300;
				a.empires[0].relations -= 250;
				a.empires[1].relations -= 250;
				a.allcountries[10].Torg = false;
				a.empires[1].power += 20;
				a.allcountries[10].LeaveAlliances().EstablishGovernment(Government.ProSoviet);
				a.allcountries[10].inflNATO = 1;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic in politics)
				{
					if (politic.traits[0] == 0)
					{
						politic.power -= 300;
					}
					else if (politic.traits[0] == 1)
					{
						politic.loyality += 250;
					}
					else
					{
						politic.loyality -= 100;
					}
				}
				break;
			}
			}
		}
		else if (this_type == 2)
		{
			a.empires[0].relations -= 500;
			a.empires[0].power -= 70;
			a.data[22] -= 100;
			a.data[8] -= 50;
			a.data[65] = 2;
			a.data[6] += 500;
			a.data[34] += 45;
			a.allcountries[92].Torg = false;
			a.allcountries[87].Torg = false;
			a.allcountries[0].stab = 1;
			if (a.iron_and_blood && a.data[63] == 1)
			{
				achieves.GetComponent<achievements>().Set(11);
			}
		}
		else if (this_type == 1)
		{
			if (selected_country == 92 || selected_country == 21 || selected_country == 17)
			{
				if (a.empires[0].now_leader == 3)
				{
					a.empires[0].power -= 75;
				}
				else
				{
					a.empires[0].power -= 50;
				}
				a.empires[0].relations -= 200;
				a.war_active[0] = true;
				if (a.completedDecisions[8])
				{
					a.influencePRC += 10;
				}
			}
			else
			{
				a.empires[1].power -= 50;
				a.empires[1].relations -= 200;
				a.war_active[1] = true;
				if (a.completedDecisions[9])
				{
					a.influencePRC += 25;
				}
			}
			a.data[9] -= 50;
			a.data[8] -= 30;
			a.data[22] -= 50;
		}
		else if (this_type == 3)
		{
			a.data[9] -= 20;
			a.data[8] -= 20;
			a.allcountries[0].dev = 1;
			GlobalScript.inst.speed = 0;
			a.number_event = 27;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 4)
		{
			a.empires[1].relations += 50;
			a.empires[0].relations -= 50;
			a.relres = true;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 5)
		{
			a.data[1] -= 100;
			a.influencePRC -= 30;
			a.empires[1].relations += 200;
			a.empires[0].relations -= 200;
			a.empires[1].power += 30;
			a.data[4] += 100;
			a.modifies[47].active = false;
			a.modifies[48].active = false;
			if (a.allcountries[1].econ)
			{
				a.data[137] = 1;
			}
			a.allcountries[selected_country].Torg = true;
			a.allcountries[1].isSEV = true;
			if (a.data[60] == 0)
			{
				a.allcountries[20].proprc = false;
				a.allcountries[20].econ = false;
				a.allcountries[20].Torg = false;
				a.allcountries[20].okb = false;
			}
			a.ingamewars[1].infl2 = 1500;
			a.allcountries[52].proprc = false;
			a.allcountries[52].econ = false;
			if (!a.allcountries[16].Torg && a.modifies[53].active)
			{
				a.allcountries[16].Torg = true;
			}
			a.allcountries[52].okb = false;
			a.allcountries[52].usalliance = false;
			a.allcountries[52].sovalliance = false;
			Country[] allcountries = a.allcountries;
			foreach (Country country in allcountries)
			{
				if (country.econ && (country.prosov || country.sovalliance || country.proprc || country.Gosstroy == 1 || (country.Gosstroy == 2 && !country.usalliance && !country.Vyshi)))
				{
					country.econ = false;
					country.isSEV = true;
				}
				else
				{
					country.econ = false;
				}
			}
			Politic[] politics = a.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] == 2)
				{
					politic2.loyality -= 250;
				}
				else if (politic2.traits[0] == 1)
				{
					politic2.loyality -= 250;
				}
				else if (politic2.traits[0] == 0)
				{
					politic2.loyality -= 250;
				}
			}
		}
		else if (this_type == 74)
		{
			a.allcountries[selected_country].Torg = true;
			a.empires[0].relations -= 50;
			a.empires[1].relations += 50;
		}
		else if (this_type == 6)
		{
			a.empires[0].relations -= 200;
			a.empires[1].relations += 150;
			a.empires[1].power += 30;
			a.data[6] += 200;
			a.data[143] += 5;
			a.influencePRC -= 50;
			if (a.modifies[47].active)
			{
				a.modifies[47].active = false;
				a.data[135] = 1;
			}
			if (a.modifies[48].active)
			{
				a.modifies[48].active = false;
				a.data[136] = 1;
			}
			if (a.allcountries[1].okb)
			{
				a.data[138] = 1;
			}
			a.allcountries[1].isOVD = true;
			Country[] allcountries = a.allcountries;
			foreach (Country country2 in allcountries)
			{
				if (country2.okb && (country2.prosov || country2.sovalliance || country2.proprc || country2.Gosstroy == 1 || (country2.Gosstroy == 2 && !country2.usalliance && !country2.Vyshi)))
				{
					country2.okb = false;
					country2.isOVD = true;
				}
				else
				{
					country2.okb = false;
				}
			}
			for (int j = 0; j < a.allcountries.Length; j++)
			{
				if (a.allcountries[j].isOVD && (j == 8 || j == 11 || j == 14 || j == 12 || j == 31 || j == 43 || j == 37 || j == 42 || j == 22 || j == 23 || j == 35 || j == 96 || j == 97 || j == 98 || j == 95 || j == 49 || j == 50))
				{
					if (a.allcountries[j].proprc)
					{
						a.allcountries[j].prcinfl = 500;
					}
					else if (a.allcountries[j].prosov)
					{
						a.allcountries[j].sovinfl = 500;
					}
				}
			}
			if (a.data[60] == 0)
			{
				a.allcountries[20].proprc = false;
				a.allcountries[20].econ = false;
				a.allcountries[20].Torg = false;
				a.allcountries[20].okb = false;
			}
		}
		else if (this_type == 7)
		{
			a.data[9] -= a.SOV_PRC_PartiesConnection / 2;
			a.data[8] -= a.SOV_PRC_PartiesConnection / 4;
			a.SOV_PRC_PartiesConnection += 30;
			a.empires[1].relations += 50;
			a.allcountries[selected_country].dev = 1;
		}
		else if (this_type == 8)
		{
			if (a.allcountries[selected_country].dev == 0)
			{
				a.data[43] += 120;
			}
			else if (a.allcountries[selected_country].dev == 1)
			{
				a.data[42] += 120;
			}
			else if (a.allcountries[selected_country].dev == 2)
			{
				a.data[44] += 120;
			}
			else
			{
				a.data[45] += 120;
			}
			a.data[9] -= 60;
			a.data[8] -= 50;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 9)
		{
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 10)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.data[3] += 20;
				a.influencePRC += 20;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
				a.data[1] += 30;
			}
		}
		else if (this_type == 11)
		{
			a.empires[1].relations -= 100;
			a.data[9] -= 100;
			a.data[8] -= 50;
			a.allcountries[selected_country].stab = 1;
			GlobalScript.inst.speed = 0;
			a.number_event = 32;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 12)
		{
			a.empires[1].relations -= 50;
			a.empires[1].power -= 200;
			a.influencePRC += 20;
			a.data[9] -= 100;
			a.data[8] -= 80;
			a.allcountries[9].prosov = false;
			a.allcountries[9].proprc = true;
		}
		else if (this_type == 13)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 10;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 14)
		{
			a.allcountries[selected_country].inflCh = 1;
			GlobalScript.inst.speed = 0;
			a.number_event = 29;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 15)
		{
			a.allcountries[selected_country].dev = 1;
			a.data[9] -= 100;
			a.data[8] -= 50;
			a.data[6] += 100;
			if (PlayerPrefs.GetInt("language") == 0)
			{
				a.ingamewars[0].name_war = "第二次朝鲜战争";
				a.ingamewars[0].is_going = true;
				a.ingamewars[0].side1 = "DPRK";
				a.ingamewars[0].side2 = "RK";
				a.IsBankAccountFreezed = true;
			}
			else
			{
				a.ingamewars[0].name_war = "Вторая Корейская война";
				a.ingamewars[0].is_going = true;
				a.ingamewars[0].side1 = "КНДР";
				a.ingamewars[0].side2 = "РК";
				a.IsBankAccountFreezed = true;
			}
			if (!a.allcountries[10].proprc)
			{
				a.ingamewars[0].ussr_place = 0;
			}
			else
			{
				a.ingamewars[0].ussr_place = -1;
			}
			a.ingamewars[0].usa_place = 1;
			a.ingamewars[0].infl1 = 600;
			a.ingamewars[0].infl2 = 400;
		}
		else if (this_type == 16)
		{
			a.guns = true;
			a.data[22] -= 50;
			a.data[8] -= 20;
			a.data[6] += 50;
		}
		else if (this_type == 17)
		{
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 18)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 20;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 19)
		{
			if (a.allcountries[1].isOVD)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isOVD = true;
				if (a.allcountries[selected_country].proprc)
				{
					a.allcountries[selected_country].prcinfl = 500;
				}
				else if (a.allcountries[selected_country].prosov)
				{
					a.allcountries[selected_country].sovinfl = 500;
				}
			}
			else
			{
				a.influencePRC += 20;
				a.allcountries[selected_country].okb = true;
				if (a.allcountries[selected_country].soc_stab <= 0)
				{
					a.allcountries[selected_country].soc_stab = 1000;
				}
			}
		}
		else if (this_type == 20)
		{
			a.data[39] += 100;
			a.data[22] -= 50;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 21)
		{
			if (a.allcountries[selected_country].dev == 0)
			{
				a.data[46] += 100;
			}
			else if (a.allcountries[selected_country].dev == 1)
			{
				a.data[57] += 100;
			}
			else if (a.allcountries[selected_country].dev == 2)
			{
				a.empires[1].now_leader += 100;
			}
			else
			{
				a.data[60] += 100;
			}
			a.data[9] -= 40;
			a.data[8] -= 30;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 68)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 20;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 22)
		{
			a.allcountries[selected_country].stab = 1;
			a.data[8] -= 50;
		}
		else if (this_type == 23)
		{
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 67)
		{
			a.allcountries[selected_country].oar = true;
			a.influencePRC += 10;
		}
		else if (this_type == 24)
		{
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 69)
		{
			a.data[9] -= 30;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 25)
		{
			a.allcountries[selected_country].oar = true;
			a.influencePRC += 10;
		}
		else if (this_type == 26)
		{
			a.allcountries[selected_country].stab = 1;
			a.influencePRC += 10;
			if (a.data[60] == 0)
			{
				a.allcountries[20].proprc = false;
				a.allcountries[20].econ = false;
				a.allcountries[20].Torg = false;
				a.allcountries[20].okb = false;
			}
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 76)
		{
			a.allcountries[selected_country].cw = true;
		}
		else if (this_type == 77)
		{
			a.allcountries[selected_country].Torg = true;
			a.data[9] -= 80;
		}
		else if (this_type == 78)
		{
			a.allcountries[selected_country].proprc = true;
			a.data[9] -= 60;
			a.data[22] -= 100;
		}
		else if (this_type == 79)
		{
			a.allcountries[selected_country].Gosstroy = 0;
			a.allcountries[selected_country].cw = false;
			a.allcountries[selected_country].Torg = false;
			a.allcountries[selected_country].proprc = false;
			a.allcountries[selected_country].prosov = false;
			a.allcountries[selected_country].Vyshi = false;
			a.allcountries[selected_country].dev = 0;
			a.data[57] += 200;
			a.data[9] -= 80;
			a.influencePRC += 10;
			if (selected_country == 70)
			{
				a.event_done[10] = false;
				a.data[66] = 0;
				a.allcountries[1].parts[9] = false;
			}
			else if (selected_country == 69)
			{
				a.event_done[9] = false;
				a.data[67] = 0;
				a.allcountries[1].parts[7] = false;
				a.allcountries[1].parts[8] = false;
			}
		}
		else if (this_type == 80)
		{
			a.allcountries[selected_country].soc_stab += 250;
			if (!a.allcountries[selected_country].usalliance && !a.allcountries[selected_country].sovalliance)
			{
				a.allcountries[selected_country].usalliance = false;
				a.allcountries[selected_country].sovalliance = false;
				a.allcountries[selected_country].soc_stab -= 500;
			}
			a.allcountries[selected_country].proprc = true;
			a.allcountries[selected_country].puppetOf = -1;
			a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[selected_country].SubGosstroy = a.ChineseSubGosstroy();
			a.data[8] -= 50;
			a.data[9] -= 50;
			a.data[22] -= 50;
			if (selected_country == 14 || selected_country == 8)
			{
				a.data[117] = 0;
			}
		}
		else if (this_type == 75)
		{
			a.data[11] -= 100;
			a.data[1] -= 50;
			a.data[8] += 4;
			a.empires[0].power += 2;
			a.empires[1].relations -= 10;
		}
		else if (this_type == 81)
		{
			a.data[11] -= 100;
			a.data[1] -= 50;
			a.data[8] += 5;
			a.empires[1].power += 2;
			a.empires[0].relations -= 25;
		}
		else if (this_type == 27)
		{
			a.data[9] -= 40;
			a.data[86]++;
			a.allcountries[selected_country].dev = 1;
		}
		else if (this_type == 72)
		{
			a.data[1] -= 300;
			a.data[8] -= 20;
			a.influencePRC -= 20;
			a.allcountries[selected_country].cw = true;
		}
		else if (this_type == 73)
		{
			a.data[1] -= 300;
			a.data[8] -= 50;
			if (a.data[6] >= 600)
			{
				a.empires[0].relations -= 300;
			}
			else if (a.data[6] <= 600)
			{
				a.empires[1].relations -= 300;
			}
			if (a.data[6] >= 500)
			{
				a.data[6] += 200;
			}
			else
			{
				a.data[6] -= 200;
			}
			a.allcountries[selected_country].cw = false;
		}
		else if (this_type == 28)
		{
			a.data[32] += 100;
			a.empires[1].relations -= 50;
			a.data[22] -= 30;
			a.data[9] -= 30;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 29)
		{
			a.allcountries[selected_country].Torg = true;
			a.data[62] = 1;
		}
		else if (this_type == 30)
		{
			a.war = 2;
			a.empires[1].relations -= 100;
			a.empires[0].relations -= 50;
			a.allcountries[selected_country].dev = 1;
		}
		else if (this_type == 89)
		{
			a.CBIndia = false;
			a.data[62] = 3;
			a.allcountries[1].ILoveSuckCocks();
			a.data[8] -= 250;
			map1.UpdateMap();
		}
		else if (this_type == 31)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 20;
				a.data[3] += 20;
				a.data[1] += 30;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 32)
		{
			a.SovAlb = true;
			a.empires[1].relations += 50;
			a.empires[1].power += 5;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 33)
		{
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 34)
		{
			a.data[8] += 50;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 35)
		{
			a.influencePRC += 10;
			a.data[9] -= 30;
			a.allcountries[selected_country].stab = 1;
			a.allcountries[selected_country].proprc = true;
		}
		else if (this_type == 36)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 20;
				a.data[3] += 20;
				a.data[1] += 30;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 37)
		{
			a.allcountries[selected_country].Gosstroy = 1;
			a.allcountries[selected_country].SubGosstroy = 1;
			a.allcountries[selected_country].stab = 1;
			a.data[9] -= 30;
			a.data[8] -= 30;
		}
		else if (this_type == 50)
		{
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 38)
		{
			a.data[8] -= 50;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 39)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 20;
				a.data[3] += 20;
				a.data[1] += 30;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 71)
		{
			a.data[40] += 100;
			a.data[22] -= 50;
			a.allcountries[selected_country].prcpower = 1;
		}
		else if (this_type == 40)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.empires[0].relations -= 50;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 20;
				a.data[3] += 20;
				a.data[1] += 30;
				a.empires[0].relations -= 50;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 41)
		{
			if (a.allcountries[1].isOVD)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isOVD = true;
				return;
			}
			a.influencePRC += 20;
			a.allcountries[selected_country].okb = true;
			if (a.allcountries[selected_country].soc_stab <= 0)
			{
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 42)
		{
			a.data[8] -= 80;
			a.influencePRC += 10;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 43)
		{
			a.data[9] -= 40;
			a.data[8] -= 20;
			a.data[41] = 100;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 44)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 20;
				a.data[3] += 20;
				a.data[1] += 30;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 45)
		{
			a.allcountries[selected_country].oar = true;
			a.influencePRC += 10;
		}
		else if (this_type == 46)
		{
			a.allcountries[selected_country].dev = 1;
			GlobalScript.inst.speed = 0;
			a.number_event = 30;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 47)
		{
			a.empires[0].relations += 200;
			a.influencePRC -= 10;
			a.empires[0].power += 10;
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 48)
		{
			a.data[22] -= 500;
			a.empires[0].relations = 0;
			a.empires[0].power -= 50;
			a.data[4] -= 500;
			a.influencePRC += 50;
			a.data[3] += 100;
			a.data[1] += 200;
			a.data[6] += 200;
			a.data[63] = 1;
			if (a.iron_and_blood && a.data[65] == 2)
			{
				Debug.Log(achieves);
				achieves.GetComponent<achievements>().Set(11);
			}
			a.allcountries[selected_country].dev = 1;
		}
		else if (this_type == 49)
		{
			if (!a.allcountries[selected_country].proprc)
			{
				a.data[1] += 200;
			}
			else
			{
				a.data[1] += 400;
			}
			a.data[8] -= 100;
			a.allcountries[39].dev = 1;
			a.data[26] += 10;
			a.data[6] -= 10;
			a.data[168] += 100;
		}
		else if (this_type == 51)
		{
			a.empires[0].relations -= 50;
			a.data[9] -= 50;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 52)
		{
			a.data[1] -= 50;
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 53)
		{
			a.influencePRC += 30;
			a.data[1] += 50;
			a.allcountries[selected_country].stab = 1000;
			a.allcountries[selected_country].soc_stab = 1000;
			if (a.allcountries[1].isSEV)
			{
				a.allcountries[selected_country].isSEV = true;
				return;
			}
			a.allcountries[selected_country].econ = true;
			a.allcountries[selected_country].soc_stab = 1000;
		}
		else if (this_type == 54)
		{
			a.allcountries[selected_country].stab = 1000;
			a.allcountries[selected_country].soc_stab = 1000;
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.influencePRC += 20;
				a.data[3] += 20;
				a.data[1] += 30;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
			}
		}
		else if (this_type == 55)
		{
			a.data[9] -= 40;
			a.empires[0].relations -= 100;
			a.allcountries[selected_country].stab = 1;
			GlobalScript.inst.speed = 0;
			a.number_event = 31;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 56)
		{
			a.data[6] += 10;
			a.data[9] -= 40;
			a.data[22] -= 30;
			a.data[37] += 100;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 57)
		{
			a.data[9] -= 100;
			a.data[8] -= 100;
			a.allcountries[selected_country].stab = 1;
		}
		else if (this_type == 58)
		{
			if (selected_country == 52)
			{
				a.data[8] -= 80;
				a.allcountries[selected_country].stab = 1;
				a.allcountries[selected_country].Torg = false;
				a.empires[0].relations -= 150;
				a.empires[0].power += 50;
				a.allcountries[selected_country].Vyshi = true;
			}
			else
			{
				a.data[8] -= 40;
				a.empires[0].relations -= 50;
				a.allcountries[selected_country].stab = 1;
				GlobalScript.inst.speed = 0;
				a.number_event = 28;
				SceneManager.LoadScene("Event");
			}
		}
		else if (this_type == 60)
		{
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 61)
		{
			a.influencePRC -= 50;
			a.empires[1].power -= 20;
			a.empires[0].power += 50;
			a.allcountries[selected_country].dev = 1;
		}
		else if (this_type == 62)
		{
			if (a.allcountries[selected_country].proprc)
			{
				a.data[9] -= 100;
				a.data[8] -= 40;
				a.data[22] -= 80;
				a.allcountries[selected_country].stab += 200;
				a.allcountries[selected_country].dev += 80;
				a.allcountries[selected_country].usapower -= 200;
				a.allcountries[selected_country].sovpower -= 200;
				if (a.allcountries[selected_country].stab > 1000)
				{
					a.allcountries[selected_country].stab = 1000;
				}
				if (a.allcountries[selected_country].dev > 1000)
				{
					a.allcountries[selected_country].dev = 1000;
				}
				if (a.allcountries[selected_country].usapower < 0)
				{
					a.allcountries[selected_country].usapower = 0;
				}
				if (a.allcountries[selected_country].sovpower < 0)
				{
					a.allcountries[selected_country].sovpower = 0;
				}
			}
			else
			{
				a.allcountries[selected_country].prcpower += 200;
				if (a.allcountries[selected_country].prcpower > 1000)
				{
					a.allcountries[selected_country].prcpower = 1000;
				}
				a.data[9] -= 80;
				a.data[8] -= 40;
				a.data[22] -= 100;
			}
		}
		else if (this_type == 63)
		{
			a.allcountries[selected_country].sovalliance = true;
			a.data[9] -= 20;
		}
		else if (this_type == 64)
		{
			a.allcountries[selected_country].usalliance = true;
			a.data[9] -= 20;
		}
		else if (this_type == 65)
		{
			if (a.allcountries[selected_country].usalliance)
			{
				a.allcountries[selected_country].stab -= a.allcountries[selected_country].prcpower + a.allcountries[selected_country].usapower + 100;
			}
			else if (a.allcountries[selected_country].sovalliance)
			{
				a.allcountries[selected_country].stab -= a.allcountries[selected_country].prcpower + a.allcountries[selected_country].sovpower + 100;
			}
			else
			{
				a.allcountries[selected_country].stab -= a.allcountries[selected_country].prcpower + 100;
			}
			if (a.allcountries[selected_country].stab < -200)
			{
				if (a.allcountries[selected_country].usalliance && a.allcountries[selected_country].usapower > a.allcountries[selected_country].prcpower)
				{
					a.allcountries[selected_country].Gosstroy = 3;
					a.allcountries[selected_country].SubGosstroy = a.AfricanSubGosstroy(a.allcountries[selected_country].Gosstroy);
					a.allcountries[selected_country].Vyshi = true;
					a.allcountries[selected_country].prosov = false;
					a.allcountries[selected_country].stab = 100;
					a.allcountries[selected_country].dev -= 200;
					a.allcountries[selected_country].usalliance = false;
					a.allcountries[selected_country].sovpower = (a.allcountries[selected_country].sovpower + 1) / 2;
					a.empires[0].power += 10;
				}
				else if (a.allcountries[selected_country].sovalliance && a.allcountries[selected_country].sovpower > a.allcountries[selected_country].prcpower)
				{
					a.allcountries[selected_country].Gosstroy = 1;
					a.allcountries[selected_country].SubGosstroy = a.AfricanSubGosstroy(a.allcountries[selected_country].Gosstroy);
					a.allcountries[selected_country].prosov = true;
					a.allcountries[selected_country].Vyshi = false;
					a.allcountries[selected_country].stab = 100;
					a.allcountries[selected_country].dev -= 200;
					a.allcountries[selected_country].sovalliance = false;
					a.allcountries[selected_country].usapower = (a.allcountries[selected_country].usapower + 1) / 2;
					a.empires[1].power += 10;
				}
				else if (a.allcountries[selected_country].usalliance)
				{
					a.allcountries[selected_country].Gosstroy = 3;
					a.allcountries[selected_country].proprc = true;
					a.allcountries[selected_country].SubGosstroy = a.AfricanSubGosstroy(a.allcountries[selected_country].Gosstroy);
					a.allcountries[selected_country].prosov = false;
					a.allcountries[selected_country].Vyshi = false;
					a.allcountries[selected_country].stab = 100;
					a.allcountries[selected_country].dev -= 200;
					a.allcountries[selected_country].usalliance = false;
					a.allcountries[selected_country].usapower = (a.allcountries[selected_country].usapower + 1) / 2;
					a.allcountries[selected_country].sovpower = (a.allcountries[selected_country].sovpower + 1) / 2;
					a.empires[0].power += 5;
					a.influencePRC += 5;
				}
				else if (a.allcountries[selected_country].sovalliance)
				{
					a.allcountries[selected_country].Gosstroy = 1;
					a.allcountries[selected_country].proprc = true;
					a.allcountries[selected_country].SubGosstroy = a.AfricanSubGosstroy(a.allcountries[selected_country].Gosstroy);
					a.allcountries[selected_country].prosov = false;
					a.allcountries[selected_country].Vyshi = false;
					a.allcountries[selected_country].stab = 100;
					a.allcountries[selected_country].dev -= 200;
					a.allcountries[selected_country].sovalliance = false;
					a.allcountries[selected_country].usapower = (a.allcountries[selected_country].usapower + 1) / 2;
					a.allcountries[selected_country].sovpower = (a.allcountries[selected_country].sovpower + 1) / 2;
					a.empires[1].power += 5;
					a.influencePRC += 5;
				}
				else
				{
					a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
					a.allcountries[selected_country].proprc = true;
					a.allcountries[selected_country].SubGosstroy = a.ChineseSubGosstroy();
					a.allcountries[selected_country].prosov = false;
					a.allcountries[selected_country].Vyshi = false;
					a.influencePRC += 5;
					a.allcountries[selected_country].stab = 100;
					a.allcountries[selected_country].dev -= 200;
					a.allcountries[selected_country].sovalliance = false;
					a.allcountries[selected_country].usalliance = false;
					a.allcountries[selected_country].Vyshi = false;
					a.allcountries[selected_country].prosov = false;
					a.allcountries[selected_country].usapower = (a.allcountries[selected_country].usapower + 1) / 2;
					a.allcountries[selected_country].sovpower = (a.allcountries[selected_country].sovpower + 1) / 2;
				}
			}
			else if (a.allcountries[selected_country].stab >= -200 && a.allcountries[selected_country].stab <= 100)
			{
				a.allcountries[selected_country].stab = 0;
				a.allcountries[selected_country].dev -= 400;
				a.allcountries[selected_country].prcpower = 100;
				a.allcountries[selected_country].usapower = 100;
				a.allcountries[selected_country].sovpower = 100;
			}
			else
			{
				a.allcountries[selected_country].stab -= 200;
				a.allcountries[selected_country].dev -= 100;
				a.allcountries[selected_country].prcpower = 0;
			}
		}
		else if (this_type == 66)
		{
			if (!a.allcountries[selected_country].Torg)
			{
				a.allcountries[selected_country].Torg = true;
			}
			else
			{
				a.allcountries[selected_country].Torg = false;
			}
		}
		else if (this_type == 82)
		{
			if (a.allcountries[selected_country].Vyshi)
			{
				a.empires[0].power -= 10;
				a.empires[0].relations -= 150;
			}
			else if (a.allcountries[selected_country].prosov)
			{
				a.empires[1].power -= 10;
				a.empires[1].relations -= 150;
			}
			a.allcountries[selected_country].Vyshi = false;
			a.allcountries[selected_country].prosov = false;
			a.allcountries[selected_country].proprc = true;
			a.data[8] -= 50;
			a.data[9] -= 50;
			a.data[22] -= 50;
			a.influencePRC += 5;
			a.empires[0].power -= 10;
			a.empires[0].relations -= 250;
			a.rev_done = true;
			a.allcountries[selected_country].SubGosstroy = a.GetSubGosstory();
			a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[selected_country].next_elections = new DateTime(2222, 2, 22);
		}
		else if (this_type == 83)
		{
			if (a.allcountries[selected_country].Vyshi)
			{
				a.empires[0].power -= 10;
				a.empires[0].relations -= 150;
			}
			else if (a.allcountries[selected_country].prosov)
			{
				a.empires[1].power -= 10;
				a.empires[1].relations -= 150;
			}
			a.allcountries[selected_country].Vyshi = false;
			a.allcountries[selected_country].prosov = false;
			a.allcountries[selected_country].proprc = true;
			a.allcountries[selected_country].Torg = true;
			a.data[8] -= 50;
			a.data[9] -= 50;
			a.data[22] -= 50;
			a.influencePRC += 5;
			a.empires[0].power -= 10;
			a.empires[0].relations -= 250;
			a.allcountries[selected_country].SubGosstroy = a.GetSubGosstory();
			a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[selected_country].next_elections = new DateTime(2222, 2, 22);
		}
		else if (this_type == 84)
		{
			if (a.allcountries[selected_country].Vyshi)
			{
				a.empires[0].relations -= 10;
			}
			else if (a.allcountries[selected_country].prosov)
			{
				a.empires[1].relations -= 10;
			}
			a.allcountries[selected_country].level_of_unstab += 10;
			a.data[8] -= 20;
			a.data[9] -= 20;
			a.data[22] -= 20;
		}
		else if (this_type == 85)
		{
			if (a.allcountries[selected_country].Vyshi)
			{
				a.empires[0].relations -= 10;
			}
			else if (a.allcountries[selected_country].prosov)
			{
				a.empires[1].relations -= 10;
			}
			a.allcountries[selected_country].level_of_dev -= 10;
			a.data[8] -= 20;
			a.data[9] -= 20;
			a.data[22] -= 20;
		}
		else if (this_type == 86)
		{
			a.empires[0].relations -= 15;
			a.allcountries[selected_country].level_of_unstab -= 10;
			a.allcountries[selected_country].level_of_dev += 10;
			a.data[8] -= 35;
			a.data[9] -= 35;
			a.data[22] -= 35;
		}
		else if (this_type == 87)
		{
			a.empires[0].relations -= 15;
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 88)
		{
			if (a.allcountries[1].isSEV || a.allcountries[1].econ)
			{
				a.empires[0].relations -= 250;
				a.allcountries[selected_country].isSEV = a.allcountries[1].isSEV;
				a.allcountries[selected_country].econ = a.allcountries[1].econ;
				a.influencePRC += 5;
			}
		}
		else if (this_type == 91)
		{
			a.data[6] += 20;
			a.data[8] -= 50;
			a.data[9] -= 30;
			a.resultOfEvents[366] = 0;
		}
		else if (this_type == 92)
		{
			a.data[6] += 2;
			a.data[8] -= 50;
			a.data[9] -= 30;
			a.resultOfEvents[366] = 1;
		}
		else if (this_type == 93)
		{
			a.allcountries[93].Torg = true;
		}
		else if (this_type == 94)
		{
			a.data[124] = 10;
			GlobalScript.inst.speed = 0;
			a.number_event = 372;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 95)
		{
			a.data[127] = 10;
			GlobalScript.inst.speed = 0;
			a.number_event = 374;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 96)
		{
			a.allcountries[95].Torg = true;
		}
		else if (this_type == 97)
		{
			a.allcountries[selected_country].Torg = true;
			a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
			a.data[8] -= 200;
			a.data[9] -= 200;
			a.influencePRC += 10;
			a.data[6] += 10;
			a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[selected_country].SubGosstroy = a.ChineseSubGosstroy();
		}
		else if (this_type == 98)
		{
			if (a.allcountries[1].econ)
			{
				a.allcountries[selected_country].econ = true;
			}
			else
			{
				a.allcountries[selected_country].isSEV = true;
			}
			a.influencePRC += 5;
		}
		else if (this_type == 99)
		{
			if (a.allcountries[1].okb)
			{
				a.allcountries[selected_country].okb = true;
			}
			else if (a.allcountries[1].isNATO)
			{
				a.allcountries[selected_country].isNATO = true;
			}
			else
			{
				a.allcountries[selected_country].isOVD = true;
			}
			a.influencePRC += 5;
			a.allcountries[selected_country].soc_stab = 900;
		}
		else if (this_type == 100)
		{
			a.data[8] -= 150;
			a.data[9] -= 150;
			a.allcountries[selected_country].dev = 1;
		}
		else if (this_type == 101)
		{
			if (a.allcountries[1].econ)
			{
				a.allcountries[selected_country].econ = true;
			}
			else
			{
				a.allcountries[selected_country].isSEV = true;
			}
		}
		else if (this_type == 102)
		{
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 103)
		{
			a.empires[0].relations -= 20;
			a.empires[1].relations -= 20;
			a.allcountries[selected_country].inflCh += 150;
			a.allcountries[selected_country].inflNATO -= 150;
			if (a.allcountries[selected_country].inflNATO < 0)
			{
				a.allcountries[selected_country].inflNATO = 0;
			}
			a.data[8] -= 100;
			a.data[9] -= 50;
		}
		else if (this_type == 104)
		{
			a.empires[0].relations -= 200;
			a.empires[1].relations -= 200;
			a.data[7] += 10;
			a.allcountries[selected_country].econ = true;
		}
		else if (this_type == 105)
		{
			a.empires[0].relations -= 400;
			a.empires[1].relations -= 400;
			a.data[7] += 15;
			a.allcountries[selected_country].proprc = true;
			a.allcountries[selected_country].based = true;
			a.data[22] -= 250;
		}
		else if (this_type == 106)
		{
			a.empires[0].relations -= 500;
			a.empires[1].relations -= 500;
			a.allcountries[selected_country].okb = true;
			a.allcountries[selected_country].isOVD = false;
			a.data[7] += 30;
		}
		else if (this_type == 107)
		{
			if (!a.modifies[41].active)
			{
				a.modifies[41].active = true;
			}
			else
			{
				a.modifies[41].active = false;
			}
		}
		else if (this_type == 108)
		{
			a.data[22] -= 50;
			a.data[8] -= 50;
			a.data[134] += 150;
			if (a.data[134] > 1000)
			{
				a.data[134] = 1000;
			}
		}
		else if (this_type == 109)
		{
			GlobalScript.inst.speed = 0;
			a.data[9] -= 150;
			a.data[8] -= 150;
			a.allcountries[85].based = true;
			a.number_event = 396;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 110)
		{
			a.data[8] -= 50;
			a.data[22] -= 50;
			a.allcountries[selected_country].inflCh += 100;
			a.allcountries[selected_country].inflNATO -= 100;
			if (a.allcountries[selected_country].inflCh >= 1000)
			{
				a.allcountries[selected_country].based = true;
				if (selected_country == 41)
				{
					a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
					a.allcountries[selected_country].Gosstroy = 1;
					a.allcountries[selected_country].SubGosstroy = 2;
				}
				else if (selected_country == 99)
				{
					a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
					a.allcountries[selected_country].Gosstroy = 0;
					a.allcountries[selected_country].SubGosstroy = 10;
				}
				else if (selected_country == 100)
				{
					a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
					a.allcountries[selected_country].Gosstroy = 1;
					a.allcountries[selected_country].SubGosstroy = 1;
				}
			}
		}
		else if (this_type == 111)
		{
			a.data[8] -= 50;
			a.data[22] -= 50;
			a.allcountries[selected_country].inflNATO += 100;
			a.allcountries[selected_country].inflCh -= 100;
			if (a.allcountries[selected_country].inflNATO >= 1000)
			{
				a.allcountries[selected_country].based = true;
				if (selected_country == 41)
				{
					a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
					a.allcountries[selected_country].Gosstroy = 3;
					a.allcountries[selected_country].SubGosstroy = 6;
				}
				else if (selected_country == 99)
				{
					a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
					a.allcountries[selected_country].Gosstroy = 0;
					a.allcountries[selected_country].SubGosstroy = 7;
				}
				else if (selected_country == 100)
				{
					a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
					a.allcountries[selected_country].Gosstroy = 3;
					a.allcountries[selected_country].SubGosstroy = 5;
				}
			}
		}
		else if (this_type == 112)
		{
			if (a.allcountries[1].okb)
			{
				a.allcountries[selected_country].okb = true;
				a.data[7] += 30;
			}
			else
			{
				a.allcountries[selected_country].isOVD = true;
				a.data[7] += 30;
			}
		}
		else if (this_type == 113)
		{
			a.allcountries[92].inflNATO += 10;
			a.data[8] -= 30;
			a.data[9] -= 30;
			a.allcountries[92].spec = 1;
		}
		else if (this_type == 114)
		{
			a.allcountries[selected_country].dev = 1;
			a.number_event = 408;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 115)
		{
			a.allcountries[selected_country].dev = 1;
			a.number_event = 409;
			SceneManager.LoadScene("Event");
		}
		else if (this_type == 116)
		{
			a.allcountries[17].parts[0] = true;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				achieves.GetComponent<achievements>().Set(132);
			}
			a.empires[0].power += 100;
			a.empires[1].power -= 100;
			a.modifies[53].active = false;
			a.allcountries[16].LeaveAlliances();
			a.allcountries[17].Torg = true;
			a.allcountries[17].dev = 2;
		}
		else if (this_type == 117)
		{
			a.influencePRC -= 20;
			a.empires[0].power += 100;
			a.empires[1].relations -= 350;
			a.empires[0].relations += 350;
			if (a.allcountries[1].econ)
			{
				a.data[137] = 1;
			}
			for (int k = 0; k < a.allcountries.Length; k++)
			{
				if (a.allcountries[k].econ)
				{
					a.allcountries[k].econ = false;
					a.allcountries[k].isASEAN = true;
					a.empires[0].power += 10;
					a.influencePRC += 5;
				}
			}
			a.allcountries[1].JoinASEAN();
		}
		else if (this_type == 118)
		{
			a.influencePRC -= 20;
			a.empires[0].power += 100;
			a.data[143] += 5;
			a.empires[1].relations -= 500;
			a.empires[0].relations += 350;
			if (a.modifies[47].active)
			{
				a.modifies[47].active = false;
				a.data[135] = 1;
			}
			if (a.modifies[48].active)
			{
				a.modifies[48].active = false;
				a.data[136] = 1;
			}
			if (a.allcountries[1].okb)
			{
				a.data[138] = 1;
			}
			for (int l = 0; l < a.allcountries.Length; l++)
			{
				if (a.allcountries[l].okb)
				{
					a.allcountries[l].okb = false;
					a.allcountries[l].isSEATO = true;
					a.empires[0].power += 10;
					a.influencePRC += 5;
				}
				if (a.allcountries[l].proprc)
				{
					a.allcountries[l].prcinfl = 500;
				}
				else if (a.allcountries[l].Vyshi)
				{
					a.allcountries[l].usainfl = 500;
				}
			}
			a.allcountries[1].JoinSEATO();
		}
		else if (this_type == 119)
		{
			a.empires[0].power += 10;
			a.influencePRC += 5;
			a.empires[0].relations += 50;
			a.allcountries[selected_country].isASEAN = true;
			a.allcountries[selected_country].Torg = true;
		}
		else if (this_type == 120)
		{
			a.empires[0].power += 10;
			a.influencePRC += 5;
			if (selected_country == 47)
			{
				a.data[37] = 0;
			}
			a.empires[0].relations += 50;
			a.allcountries[selected_country].isSENTO = false;
			a.allcountries[selected_country].isSEATO = true;
			if (a.allcountries[selected_country].proprc)
			{
				a.allcountries[selected_country].prcinfl = 500;
			}
			else if (a.allcountries[selected_country].Vyshi)
			{
				a.allcountries[selected_country].usainfl = 500;
			}
		}
		else if (this_type == 121)
		{
			if (selected_country == 24)
			{
				a.empires[1].power += 10;
				a.empires[1].relations += 50;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.empires[0].power += 10;
				a.empires[0].relations += 50;
				a.allcountries[selected_country].isASEAN = true;
			}
		}
		else if (this_type == 122)
		{
			a.allcountries[selected_country].dev = 1;
			a.data[9] -= 100;
			a.data[8] -= 50;
			a.data[6] += 100;
			if (PlayerPrefs.GetInt("language") == 0)
			{
				a.ingamewars[0].name_war = "第二次朝鲜战争";
				a.ingamewars[0].is_going = true;
				a.ingamewars[0].side1 = "DPRK";
				a.ingamewars[0].side2 = "RK";
				a.IsBankAccountFreezed = true;
			}
			else
			{
				a.ingamewars[0].name_war = "Вторая Корейская война";
				a.ingamewars[0].is_going = true;
				a.ingamewars[0].side1 = "КНДР";
				a.ingamewars[0].side2 = "РК";
				a.IsBankAccountFreezed = true;
			}
			if (!a.allcountries[10].proprc)
			{
				a.ingamewars[0].ussr_place = 0;
			}
			else
			{
				a.ingamewars[0].ussr_place = -1;
			}
			a.ingamewars[0].usa_place = 1;
			a.ingamewars[0].infl1 = 400;
			a.ingamewars[0].infl2 = 600;
		}
		else if (this_type == 123)
		{
			a.empires[1].power -= 50;
			a.empires[1].relations -= 200;
			a.war_active[1] = true;
			if (a.completedDecisions[9])
			{
				a.influencePRC += 25;
			}
			a.data[9] -= 50;
			a.data[8] -= 30;
			a.data[22] -= 50;
		}
		else if (this_type == 124)
		{
			a.allcountries[1].based = true;
			if (a.allcountries[1].isASEAN)
			{
				a.empires[0].relations -= 300;
			}
			else
			{
				a.empires[1].relations -= 300;
				a.allcountries[7].Torg = false;
			}
			a.allcountries[7].spec = 0;
			a.data[143] -= 5;
			a.allcountries[51].spec = 0;
			a.data[140] = 0;
			if (a.data[135] > 0)
			{
				a.modifies[47].active = true;
				a.data[135] = 0;
			}
			if (a.data[136] > 0)
			{
				a.modifies[48].active = true;
				a.data[136] = 0;
			}
			a.data[139] = 0;
			for (int m = 2; m < a.allcountries.Length; m++)
			{
				if (a.allcountries[m].proprc && m != 2 && m != 5 && m != 9)
				{
					if (a.allcountries[1].isASEAN)
					{
						a.allcountries[m].LeaveASEAN().LeaveSEATO();
						a.empires[0].power -= 5;
					}
					else
					{
						a.allcountries[m].LeaveWP().LeaveComecon();
						a.empires[1].power -= 5;
					}
				}
			}
			if (a.data[137] > 0)
			{
				for (int n = 0; n < a.allcountries.Length; n++)
				{
					if (n != 2 && n != 5 && n != 9)
					{
						a.data[137] = 0;
						if (a.allcountries[n].proprc && n != 2 && n != 5 && n != 9)
						{
							a.allcountries[n].JoinECON();
						}
					}
				}
			}
			if (a.data[138] > 0)
			{
				for (int num2 = 0; num2 < a.allcountries.Length; num2++)
				{
					if (num2 != 2 && num2 != 5 && num2 != 9)
					{
						a.data[138] = 0;
						if (a.allcountries[num2].proprc)
						{
							a.allcountries[num2].JoinOKB();
						}
					}
				}
			}
			a.allcountries[1].LeaveWP().LeaveASEAN().LeaveComecon()
				.LeaveSEATO();
		}
		else if (this_type == 125)
		{
			a.data[8] -= 50;
			a.data[9] -= 100;
			a.allcountries[selected_country].perevorot = true;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			num3 += a.allcountries[selected_country].sovinfl / 100;
			num4 += a.allcountries[selected_country].usainfl / 100;
			num5 += a.allcountries[selected_country].prcinfl / 100;
			num3 += a.empires[1].power / 100;
			num4 += a.empires[0].power / 100;
			num5 += a.influencePRC / 100;
			if (a.allcountries[1].isSEATO)
			{
				if (num5 >= num4)
				{
					if (!a.allcountries[selected_country].proprc)
					{
						a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
						a.influencePRC += 5;
					}
					a.empires[0].power -= 5;
					a.allcountries[selected_country].usainfl = 0;
					a.allcountries[selected_country].prcinfl = 500;
					a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
					a.allcountries[selected_country].SubGosstroy = a.allcountries[1].SubGosstroy;
				}
				else
				{
					if (!a.allcountries[selected_country].Vyshi)
					{
						a.allcountries[selected_country].EstablishGovernment(Government.ProAmerican);
						a.empires[0].power += 5;
					}
					a.allcountries[selected_country].usainfl = 500;
					a.allcountries[selected_country].prcinfl = 0;
					a.allcountries[selected_country].Gosstroy = a.allcountries[51].Gosstroy;
					a.allcountries[selected_country].SubGosstroy = a.allcountries[51].SubGosstroy;
				}
			}
			else if (num5 >= num3)
			{
				if (!a.allcountries[selected_country].proprc)
				{
					a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
					a.influencePRC += 5;
				}
				a.empires[1].power -= 5;
				a.allcountries[selected_country].sovinfl = 0;
				a.allcountries[selected_country].prcinfl = 500;
				a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
				a.allcountries[selected_country].SubGosstroy = a.allcountries[1].SubGosstroy;
			}
			else
			{
				if (!a.allcountries[selected_country].prosov)
				{
					a.allcountries[selected_country].EstablishGovernment(Government.ProSoviet);
				}
				a.allcountries[selected_country].sovinfl = 500;
				a.allcountries[selected_country].prcinfl = 0;
				a.empires[1].power += 5;
				a.allcountries[selected_country].Gosstroy = a.allcountries[7].Gosstroy;
				a.allcountries[selected_country].SubGosstroy = a.allcountries[7].SubGosstroy;
			}
		}
		else if (this_type == 126)
		{
			a.data[8] -= 100;
			a.data[9] -= 100;
			a.data[22] -= 100;
			a.allcountries[22].cw = true;
			a.empires[1].relations -= 250;
			a.ingamewars[27] = new War().Name(GlobalScript.inst.new_events_text[1237]).Attacker(GlobalScript.inst.new_events_text[1238]).Defender(GlobalScript.inst.new_events_text[1239])
				.AttackerInfluence(700)
				.DefenderInfluence(300)
				.TickTime(30)
				.SovietSupportAttacker.AmericanSupportDefender.CreateWar;
		}
		else if (this_type == 127)
		{
			a.empires[0].power -= 70;
			a.allcountries[21].isNATO = false;
			a.allcountries[21].isEU = false;
		}
		else if (this_type == 128)
		{
			a.data[8] -= a.allcountries[87].inflNATO;
			a.data[9] -= a.allcountries[87].inflCh;
			a.allcountries[87].based = true;
			a.allcountries[87].spec -= 10;
			a.allcountries[87].inflCh += 20;
			a.allcountries[87].inflNATO += 20;
		}
		else if (this_type == 129)
		{
			a.allcountries[49].isASEAN = false;
			a.data[8] -= 150;
			if (a.allcountries[1].isSEV)
			{
				if (a.empires[1].power > a.influencePRC)
				{
					a.allcountries[49].prosov = true;
					a.empires[1].power += 40;
					a.allcountries[49].Gosstroy = a.allcountries[7].Gosstroy;
					a.allcountries[49].SubGosstroy = a.allcountries[7].SubGosstroy;
				}
				else
				{
					a.allcountries[49].proprc = true;
					a.influencePRC += 40;
					a.allcountries[49].Gosstroy = a.allcountries[1].Gosstroy;
					a.allcountries[49].SubGosstroy = a.allcountries[1].SubGosstroy;
				}
			}
			else
			{
				a.allcountries[49].proprc = true;
				a.influencePRC += 40;
				a.allcountries[49].Gosstroy = a.allcountries[1].Gosstroy;
				a.allcountries[49].SubGosstroy = a.allcountries[1].SubGosstroy;
			}
		}
		else if (this_type == 130)
		{
			a.data[8] -= 50;
			a.data[9] -= 50;
			a.empires[1].relations -= 10;
			a.data[22] -= 80;
			a.allcountries[selected_country].prcinfl += 200;
			a.allcountries[selected_country].sovinfl -= 400;
			if (a.allcountries[selected_country].prcinfl > 1000)
			{
				a.allcountries[selected_country].prcinfl = 1000;
			}
		}
		else if (this_type == 131)
		{
			a.data[8] -= 50;
			a.data[9] -= 50;
			a.empires[0].relations -= 10;
			a.data[22] -= 80;
			a.allcountries[selected_country].prcinfl += 200;
			if (a.allcountries[selected_country].prcinfl > 1000)
			{
				a.allcountries[selected_country].prcinfl = 1000;
			}
			a.allcountries[selected_country].usainfl -= 400;
		}
		else if (this_type == 132)
		{
			a.data[8] -= 50;
			a.data[9] -= 50;
			if (a.allcountries[1].isSEATO)
			{
				a.empires[0].relations -= 50;
			}
			else
			{
				a.empires[1].relations -= 50;
			}
			a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[selected_country].SubGosstroy = a.allcountries[1].SubGosstroy;
		}
		else if (this_type == 133)
		{
			a.data[8] -= 250;
			a.data[9] -= 150;
			a.data[22] -= 350;
			a.allcountries[14].cw = true;
			int num6 = 0;
			if (a.allcountries[1].isOVD)
			{
				if (a.allcountries[30].Gosstroy != 3)
				{
					num6 += 50;
				}
				if (a.allcountries[35].proprc || a.allcountries[35].prosov)
				{
					num6 += 50;
				}
				if (a.allcountries[8].isOVD)
				{
					num6 += 50;
				}
				if (a.allcountries[37].isOVD)
				{
					num6 += 50;
				}
				a.empires[0].relations -= 350;
				a.ingamewars[29] = new War().Name(GlobalScript.inst.new_events_text[1320]).Attacker(GlobalScript.inst.new_events_text[1321]).Defender(GlobalScript.inst.new_events_text[1322])
					.AttackerInfluence(500 + num6)
					.DefenderInfluence(500 - num6)
					.SovietSupportAttacker.AmericanSupportDefender.CreateWar;
				return;
			}
			if (a.allcountries[1].isSEATO)
			{
				a.empires[1].relations -= 350;
				if (a.allcountries[30].Gosstroy == 3)
				{
					num6 += 50;
				}
				if (a.allcountries[35].proprc || a.allcountries[35].Vyshi)
				{
					num6 += 50;
				}
				if (a.allcountries[8].isSEATO)
				{
					num6 += 50;
				}
				if (a.allcountries[37].isSEATO)
				{
					num6 += 50;
				}
				a.ingamewars[29] = new War().Name(GlobalScript.inst.new_events_text[1323]).Attacker(GlobalScript.inst.new_events_text[1324]).Defender(GlobalScript.inst.new_events_text[1322])
					.AttackerInfluence(500 + num6)
					.DefenderInfluence(500 - num6)
					.AmericanSupportAttacker.SovietSupportDefender.CreateWar;
				return;
			}
			a.empires[0].relations -= 350;
			a.empires[1].relations -= 350;
			if (a.allcountries[30].Gosstroy == 2)
			{
				num6 += 50;
			}
			if (a.allcountries[35].proprc)
			{
				num6 += 50;
			}
			if (a.allcountries[8].okb)
			{
				num6 += 50;
			}
			if (a.allcountries[37].okb)
			{
				num6 += 50;
			}
			num6 -= 150;
			a.ingamewars[29] = new War().Name(GlobalScript.inst.new_events_text[1325]).Attacker(GlobalScript.inst.new_events_text[1326]).Defender(GlobalScript.inst.new_events_text[1322])
				.AttackerInfluence(500 + num6)
				.DefenderInfluence(500 - num6)
				.TickTime(15)
				.AmericanSupportDefender.SovietSupportDefender.CreateWar;
		}
		else if (this_type == 134)
		{
			if (!a.allcountries[selected_country].dota)
			{
				a.allcountries[selected_country].dota = true;
				a.data[146]++;
			}
			else
			{
				a.allcountries[selected_country].dota = false;
				a.data[146]--;
			}
		}
		else if (this_type == 70)
		{
			a.data[8] -= 50;
			a.allcountries[selected_country].Torg = true;
			a.allcountries[selected_country].proprc = true;
			a.empires[0].power -= 20;
			a.influencePRC += 10;
		}
		else if (this_type == 135)
		{
			if (!a.modifies[53].active)
			{
				a.modifies[53].active = true;
				if (a.allcountries[1].isSEV)
				{
					a.allcountries[16].Torg = true;
				}
			}
			else
			{
				a.modifies[53].active = false;
				a.allcountries[16].Torg = false;
			}
		}
		else if (this_type == 136)
		{
			a.data[8] -= 50;
			a.data[9] -= 50;
			a.allcountries[86].based = true;
		}
		else if (this_type == 137)
		{
			a.allcountries[17].parts[0] = true;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				achieves.GetComponent<achievements>().Set(132);
			}
			a.allcountries[17].Gosstroy = 2;
			a.allcountries[17].SubGosstroy = 15;
			a.allcountries[17].LeaveAlliances();
			a.allcountries[16].LeaveAlliances();
			a.allcountries[17].name = GlobalScript.inst.new_events_text[898];
			a.empires[0].power -= 100;
			a.empires[1].power -= 100;
			a.modifies[53].active = false;
			a.allcountries[17].dev = 1;
			a.allcountries[17].Torg = true;
		}
		else if (this_type == 138)
		{
			a.allcountries[16].parts[0] = true;
			a.allcountries[17].LeaveAlliances();
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				achieves.GetComponent<achievements>().Set(132);
			}
			a.empires[0].power -= 100;
			a.empires[1].power += 100;
			a.allcountries[17].dev = 3;
			a.allcountries[16].Torg = true;
		}
		else if (this_type == 139)
		{
			a.allcountries[18].Torg = true;
			a.allcountries[18].spec = 1;
			a.allcountries[18].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[18].SubGosstroy = a.allcountries[1].SubGosstroy;
			a.allcountries[18].name = GlobalScript.inst.other_text[424];
			a.influencePRC += 20;
			a.empires[0].relations -= 150;
			a.empires[1].relations -= 150;
			a.allcountries[18].proprc = true;
			if (a.allcountries[1].isSEV)
			{
				a.allcountries[18].isSEV = true;
			}
			else if (a.allcountries[1].econ)
			{
				a.allcountries[18].econ = true;
			}
		}
		else if (this_type == 140)
		{
			a.allcountries[54].africaOff = true;
			a.allcountries[54].Torg = true;
			a.allcountries[18].spec = 1;
			a.allcountries[54].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[54].SubGosstroy = a.allcountries[1].SubGosstroy;
			a.influencePRC += 20;
			a.empires[0].relations -= 150;
			a.empires[1].relations -= 150;
			a.allcountries[54].proprc = true;
			a.allcountries[54].parts[0] = true;
			if (a.allcountries[1].isSEV)
			{
				a.allcountries[54].isSEV = true;
			}
			else if (a.allcountries[1].econ)
			{
				a.allcountries[54].econ = true;
			}
		}
		else if (this_type == 141)
		{
			a.allcountries[59].africaOff = true;
			a.allcountries[59].Torg = true;
			a.allcountries[18].spec = 1;
			a.allcountries[59].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[59].SubGosstroy = a.allcountries[1].SubGosstroy;
			a.influencePRC += 20;
			a.empires[0].relations -= 150;
			a.empires[1].relations -= 150;
			a.allcountries[59].proprc = true;
			a.allcountries[59].parts[0] = true;
			if (a.allcountries[1].isSEV)
			{
				a.allcountries[59].isSEV = true;
			}
			else if (a.allcountries[1].econ)
			{
				a.allcountries[59].econ = true;
			}
		}
		else if (this_type > 141 && this_type < 145)
		{
			if (this_type == 142)
			{
				a.data[22] -= 50;
				a.allcountries[selected_country].sovinfl = 3;
			}
			else if (this_type == 143)
			{
				a.data[9] -= 50;
				a.allcountries[selected_country].usainfl = 3;
			}
			else
			{
				a.data[8] -= 30;
				a.allcountries[selected_country].prcinfl = 3;
			}
			a.allcountries[selected_country].inflCh += 200;
			if (a.allcountries[selected_country].inflCh > 1000)
			{
				a.allcountries[selected_country].inflCh = 1000;
			}
			if (a.allcountries[selected_country].inflCh >= 1000)
			{
				a.influencePRC += 10;
				a.empires[0].relations -= 100;
				a.empires[1].relations -= 100;
				a.allcountries[selected_country].proprc = true;
			}
		}
		else if (this_type > 144 && this_type < 147)
		{
			a.data[9] -= 50;
			a.influencePRC -= 5;
			a.allcountries[36].inflNATO = 3;
			if (this_type == 145)
			{
				if (a.data[143] + 5 <= 60)
				{
					a.data[143] += 5;
				}
				else
				{
					a.data[143] = 60;
				}
				a.empires[1].relations += 50;
				a.empires[0].relations -= 50;
			}
			else
			{
				if (a.data[143] - 5 >= 10)
				{
					a.data[143] -= 5;
				}
				else
				{
					a.data[143] = 10;
				}
				a.empires[1].relations -= 50;
				a.empires[0].relations += 50;
			}
		}
		else if (this_type == 147)
		{
			a.data[9] -= 50;
			a.data[8] -= 100;
			a.data[22] -= 100;
			a.influencePRC += 80;
			a.allcountries[selected_country].EstablishGovernment(Government.ProChina);
			a.allcountries[selected_country].Torg = true;
			a.allcountries[selected_country].stab = 0;
			a.allcountries[selected_country].spec = 1;
			a.allcountries[selected_country].Gosstroy = 2;
			a.allcountries[selected_country].SubGosstroy = 15;
			a.empires[0].relations -= 300;
			a.empires[0].power -= 30;
		}
		else if (this_type == 148)
		{
			a.allcountries[selected_country].proprc = true;
			a.allcountries[selected_country].Torg = true;
			if (a.allcountries[1].Gosstroy != 2)
			{
				a.allcountries[selected_country].Gosstroy = 2;
				a.allcountries[selected_country].SubGosstroy = 3;
			}
			else
			{
				a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
				a.allcountries[selected_country].SubGosstroy = a.allcountries[1].SubGosstroy;
			}
			a.allcountries[selected_country].cw = true;
			a.influencePRC += 20;
			a.data[8] -= 200;
			a.data[9] -= 200;
		}
		else if (this_type == 149)
		{
			a.allcountries[selected_country].proprc = true;
			a.allcountries[selected_country].cw = true;
			a.allcountries[selected_country].Torg = true;
			if (a.allcountries[1].Gosstroy != 3)
			{
				a.allcountries[selected_country].Gosstroy = 3;
				a.allcountries[selected_country].SubGosstroy = 5;
			}
			else
			{
				a.allcountries[selected_country].Gosstroy = a.allcountries[1].Gosstroy;
				a.allcountries[selected_country].SubGosstroy = a.allcountries[1].SubGosstroy;
			}
			a.influencePRC += 20;
			a.data[8] -= 200;
			a.data[9] -= 200;
		}
		else if (this_type == 150)
		{
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].power += 20;
				a.influencePRC += 10;
				a.allcountries[selected_country].isSEV = true;
			}
			else
			{
				a.data[3] += 20;
				a.influencePRC += 20;
				a.allcountries[selected_country].econ = true;
				a.allcountries[selected_country].soc_stab = 1000;
				a.data[1] += 30;
			}
		}
		else if (this_type == 151)
		{
			a.allcountries[selected_country].prosov = false;
			a.allcountries[selected_country].proprc = true;
			a.allcountries[selected_country].isNATO = false;
			a.allcountries[selected_country].Torg = true;
			a.allcountries[selected_country].isSEV = false;
			a.allcountries[selected_country].okb = true;
			a.allcountries[selected_country].econ = true;
			a.data[9] -= 200;
			a.data[8] -= 200;
			a.influencePRC += 50;
			a.empires[0].relations -= 100;
			a.empires[1].relations -= 100;
			a.empires[0].power -= 100;
		}
		else if (this_type == 152)
		{
			a.allcountries[selected_country].prosov = false;
			a.allcountries[selected_country].proprc = true;
			a.allcountries[selected_country].isNATO = false;
			a.allcountries[selected_country].Torg = true;
			a.allcountries[selected_country].isSEV = false;
			a.allcountries[selected_country].okb = true;
			a.allcountries[selected_country].econ = true;
			a.data[9] -= 200;
			a.data[8] -= 200;
			a.influencePRC += 50;
			a.empires[0].relations -= 100;
			a.empires[1].relations -= 100;
			a.empires[0].power -= 100;
		}
		else if (this_type == 153)
		{
			a.data[167] = 1;
			a.data[9] -= 50;
			a.data[6] += 20;
			a.data[1] += 50;
			a.data[3] += 15;
			a.empires[1].relations -= 50;
		}
		else if (this_type == 154)
		{
			a.data[167] = 2;
			a.data[9] -= 50;
			a.data[6] -= 20;
			a.influencePRC += 5;
			a.empires[1].relations -= 50;
		}
		else if (this_type == 155)
		{
			a.data[8] += 100;
			a.data[168] -= 100;
			a.data[169] -= 100;
			a.empires[0].relations -= 50;
			if (!a.allcountries[selected_country].proprc)
			{
				a.data[1] -= 200;
			}
			else
			{
				a.data[1] -= 400;
			}
			a.data[6] += 10;
		}
		else if (this_type == 156)
		{
			a.data[8] += 50;
			a.data[168] -= 100;
			a.data[169] -= 50;
			a.empires[0].relations -= 10;
			if (!a.allcountries[selected_country].proprc)
			{
				a.data[1] -= 100;
			}
			else
			{
				a.data[1] -= 200;
			}
			a.data[6] -= 5;
		}
	}

	private void OnMouseEnter()
	{
		if (!is_active && selectedWar < 0)
		{
			return;
		}
		if (selectedWar >= 0)
		{
			ChineseInfo();
		}
		GetComponent<SpriteRenderer>().sprite = on;
		opis.GetComponent<TextMesh>().text = Utils.Text(this_opis, 80);
		for (int i = 0; i < number_uslovie; i++)
		{
			uslovie[i].GetComponent<TextMesh>().text = Utils.Text(uslovie_text[i], 33);
			if (uslovie_bool[i])
			{
				uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = usl_on;
			}
			else
			{
				uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = usl_off;
			}
		}
	}

	private void OnMouseExit()
	{
		if (is_active)
		{
			GetComponent<SpriteRenderer>().sprite = off;
			opis.GetComponent<TextMesh>().text = null;
			for (int i = 0; i < 4; i++)
			{
				uslovie[i].GetComponent<TextMesh>().text = null;
				uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			}
		}
		else if (selectedWar >= 0)
		{
			GetComponent<SpriteRenderer>().sprite = off;
			opis.GetComponent<TextMesh>().text = null;
			for (int j = 0; j < 2; j++)
			{
				uslovie[j].GetComponent<TextMesh>().text = null;
				uslovie[j].transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			}
		}
	}

	private static string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
