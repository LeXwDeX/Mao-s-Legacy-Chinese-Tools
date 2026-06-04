using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class GameState
{
	public Modifiers[] modifies = new Modifiers[250];

	public int influencePRC;

	public int SOV_PRC_PartiesConnection;

	public Empire[] empires;

	[NonSerialized]
	public Decision[] decisions;

	public bool[] completedDecisions;

	public Country[] allcountries = new Country[99];

	public bool[] science = new bool[34];

	public int war;

	public Politic[] politics = new Politic[18];

	public Persona[] citizens = new Persona[0];

	public Politic leader = new Politic();

	public bool[] event_done = new bool[1000];

	public int[] party_number = new int[5];

	public int[] party_ideology = new int[5];

	public bool[] is_party_enabled = new bool[5];

	public bool relres;

	public bool VasilyisGay;

	public warinwars[] ingamewars = new warinwars[50];

	public int number_event = -1;

	public int[] resultOfEvents = new int[1000];

	public int[] faction_leader = new int[5];

	public byte[] p_first = new byte[3];

	public byte[] p_second = new byte[4];

	public byte[] p_third = new byte[5];

	public byte[] p_forth = new byte[6];

	public byte[] politics_dolshnost = new byte[8];

	public int[] gamerules = new int[20];

	public string[] names1;

	public string[] names2;

	public string[] traitsName;

	public bool iron_and_blood;

	public int[] data = new int[150];

	public bool rev_done;

	public int[] Events_number = new int[200];

	public float[] Events_time = new float[200];

	public bool[] Events_active = new bool[200];

	public bool[] war_active = new bool[5];

	public int[] desnull = new int[50];

	public bool bad_done;

	public bool bad_debuff;

	public int number_otvet = -1;

	public float OilProd;

	public float OilEat;

	public bool is_progorel;

	public bool achivki_sosut;

	public int diff = 2;

	public bool is_save_bylo;

	public string runHash = string.Empty;

	public bool is_elect;

	public bool is_speech;

	public bool is_konst_max = true;

	public bool turn_on;

	public bool is_gkchp;

	public bool bylo;

	public bool neizucheno = true;

	public string[] party_name = new string[15];

	public bool[] is_party_ally = new bool[5];

	public bool BritLost;

	public bool vietnampeace;

	public bool iranrev;

	public bool guns;

	public bool DRAagree;

	public bool CBIndia;

	public bool OAR;

	public bool Israellost;

	public bool YugAgree;

	public bool sanct;

	public bool donat;

	public bool ICP;

	public bool IndOpp;

	public bool HelpGandi;

	public bool SovAlb;

	public bool SEZ;

	public bool TaiCoup;

	public bool SKRebel;

	public bool[] checking = new bool[5];

	public string[] doctr = new string[42];

	public bool[] science_in_progress = new bool[34];

	public int[] science_time = new int[34];

	public int[] science_need_time = new int[34];

	public int[] data_old = new int[200];

	public int PlayerCountry = 1;

	public int numOfPlayers = 1;

	public bool[] factionsPlayerFor;

	public bool[] playerFor;

	public int[] eventVariantsPlayerFor;

	public int[] factionsPlayerMaster;

	public int[] factionsPoints;

	public bool coopAttacked;

	public int congressShutdownYears;

	public int peopleCoalitionYears;

	public Dictionary<int, bool> startedDirectWarsNum;

	public bool IsBankAccountFreezed;

	public (int reservists, int divisions) GetSoldiersNumber(GameState a)
	{
		float num = (float)a.data[34] / 10f;
		float num2 = ((a.data[51] == 33) ? 3 : (a.data[51] - 29));
		float num3 = num / 2f + num / num2;
		return (reservists: (int)num, divisions: (int)num3);
	}

	public (int reservists, int divisions) AddSoldiersNumber(GameState a, float num)
	{
		float num2 = num / 10f;
		float num3 = ((a.data[51] == 33) ? 3 : (a.data[51] - 29));
		float num4 = num2 / 2f + num2 / num3;
		return (reservists: (int)num2, divisions: (int)num4);
	}

	public int ImportChange(GameState global1)
	{
		float num = (float)global1.data[5] * 2f / 1000f * (float)global1.data[34] - (float)global1.data[12] / 1000f * (float)global1.data[34];
		float num2 = (float)global1.data[5] / 1000f * (float)global1.data[34] - (float)global1.data[13] * 2f / 1000f * (float)global1.data[34];
		float num3 = (float)global1.data[5] / 1000f * (float)global1.data[34] - (float)global1.data[68] / 1000f * (float)global1.data[34];
		float num4 = (float)global1.data[36] / 10000f * (float)global1.data[34];
		return (int)((num + num4 + num2 + num3) / 1000f);
	}

	public float GetPercentOfFaction(int num)
	{
		float num2 = party_number.Sum();
		return (float)party_number[num] / num2;
	}

	public string GetCompassText()
	{
		float[] array = party_number.Select((int n, int index) => GetPercentOfFaction(index)).ToArray();
		if (PlayerPrefs.GetInt("language") != 0)
		{
			return string.Format(arg1: (GlobalScript.inst.gameState.numOfPlayers >= 5) ? $"<color=red>Игрок 1:</color>|Маоисты: {array[0] * 100f: ##.#}% (Очков: {factionsPoints[0]})|<color=red>Игрок 2:</color>|Консерваторы: {array[1] * 100f: ##.#}% (Очков: {factionsPoints[1]})|<color=red>Игрок 3:</color>|Умеренные: {array[2] * 100f: ##.#}% (Очков: {factionsPoints[2]})|<color=red>Игрок 4:</color>|Реформаторы {array[3] * 100f: ##.#}% (Очков: {factionsPoints[3]})|<color=red>Игрок 5:</color>|Либералы {array[4] * 100f: ##.#}% (Очков: {factionsPoints[4]})" : $"Маоисты: {array[0] * 100f: ##.#}% <color=red>(Игрок №{factionsPlayerMaster[0] + 1})</color> (Очков: {factionsPoints[0]})|Консерваторы: {array[1] * 100f: ##.#}% <color=red>(Игрок №{factionsPlayerMaster[1] + 1})</color> (Очков: {factionsPoints[1]})|Умеренные: {array[2] * 100f: ##.#}% <color=red>(Игрок №{factionsPlayerMaster[2] + 1})</color> (Очков: {factionsPoints[2]})|Реформаторы {array[3] * 100f: ##.#}% <color=red>(Игрок №{factionsPlayerMaster[3] + 1})</color> (Очков: {factionsPoints[3]})|Либералы {array[4] * 100f: ##.#}% <color=red>(Игрок №{factionsPlayerMaster[4] + 1})</color> (Очков: {factionsPoints[4]})", format: "<color=yellow>Количество игроков:</color>|{0}|<color=yellow>Деление на фракции:</color>|{1}", arg0: numOfPlayers);
		}
		return string.Format(arg1: (GlobalScript.inst.gameState.numOfPlayers >= 5) ? $"<color=red>Player 1:</color>|Maoists: {array[0] * 100f: ##.#}% (Points: {factionsPoints[0]})|<color=red>Player 2:</color>|Conservatives: {array[1] * 100f: ##.#}% (Points: {factionsPoints[1]})|<color=red>Player 3:</color>|Moderates: {array[2] * 100f: ##.#}% (Points: {factionsPoints[2]})|<color=red>Player 4:</color>|Reformists: {array[3] * 100f: ##.#}% (Points: {factionsPoints[3]})|<color=red>Player 5:</color>|Liberals: {array[4] * 100f: ##.#}% (Points: {factionsPoints[4]})" : $"Maoists: {array[0] * 100f: ##.#}% <color=red>(Player №{factionsPlayerMaster[0] + 1})</color> (Points: {factionsPoints[0]})|Conservatives: {array[1] * 100f: ##.#}% <color=red>(Player №{factionsPlayerMaster[1] + 1})</color> (Points: {factionsPoints[1]})|Moderates: {array[2] * 100f: ##.#}% <color=red>(Player №{factionsPlayerMaster[2] + 1})</color> (Points: {factionsPoints[2]})|Reformists: {array[3] * 100f: ##.#}% <color=red>(Player №{factionsPlayerMaster[3] + 1})</color> (Points: {factionsPoints[3]})|Liberals: {array[4] * 100f: ##.#}% <color=red>(Player №{factionsPlayerMaster[4] + 1})</color> (Points: {factionsPoints[4]})", format: "<color=yellow>Number of Players:</color>|{0}|<color=yellow>Factions division:</color>|{1}", arg0: numOfPlayers);
	}

	public bool GetSecondReqForPlayers()
	{
		int num = 0;
		int num2 = 0;
		if (GlobalScript.inst.gameState.numOfPlayers < 5)
		{
			for (int i = 0; i < factionsPlayerMaster.Length; i++)
			{
				if (factionsPlayerFor[factionsPlayerMaster[i]])
				{
					num += GlobalScript.inst.gameState.party_number[i];
				}
				else
				{
					num2 += GlobalScript.inst.gameState.party_number[i];
				}
			}
		}
		else if (GlobalScript.inst.gameState.numOfPlayers == 5)
		{
			for (int j = 0; j < GlobalScript.inst.gameState.factionsPlayerFor.Length; j++)
			{
				if (GlobalScript.inst.gameState.factionsPlayerFor[j])
				{
					num += GlobalScript.inst.gameState.party_number[j];
				}
				else
				{
					num2 += GlobalScript.inst.gameState.party_number[j];
				}
			}
		}
		return num > num2;
	}

	public bool WarCheck(int num)
	{
		if ((GlobalScript.inst.gameState.ingamewars[num].fortnight_go >= GlobalScript.inst.gameState.ingamewars[num].fortnight_max || GlobalScript.inst.gameState.ingamewars[num].infl1 >= 1000 || GlobalScript.inst.gameState.ingamewars[num].infl2 >= 1000) && GlobalScript.inst.gameState.ingamewars[num].is_going && GlobalScript.inst.gameState.data[82] < 0)
		{
			return true;
		}
		return false;
	}

	public bool WarResult(ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		Debug.Log("СОМАЛИИИИИИИИИИИИИИИИ-1");
		if (GlobalScript.inst.gameState.data[82] == 0)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
			{
				if (GlobalScript.inst.gameState.allcountries[10].Gosstroy == 3 && GlobalScript.inst.gameState.allcountries[46].Gosstroy == 0)
				{
					GlobalScript.inst.gameState.data[157] = 1;
				}
				GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[838];
				if (!GlobalScript.inst.gameState.allcountries[1].isSEATO)
				{
					GlobalScript.inst.gameState.allcountries[10].parts[0] = true;
					GlobalScript.inst.gameState.influencePRC += 50;
					GlobalScript.inst.gameState.empires[0].power -= 40;
					GlobalScript.inst.gameState.data[83] = 1;
				}
				else
				{
					GlobalScript.inst.gameState.allcountries[10].parts[0] = true;
					GlobalScript.inst.gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.empires[0].power -= 10;
					GlobalScript.inst.gameState.data[83] = 1;
					GlobalScript.inst.gameState.empires[1].power += 60;
				}
				text = string.Format(GlobalScript.inst.new_events_text[1611], "\n");
			}
			else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 900)
			{
				GlobalScript.inst.gameState.allcountries[46].name = GlobalScript.inst.new_events_text[1645];
				if (!GlobalScript.inst.gameState.allcountries[1].isSEATO)
				{
					GlobalScript.inst.gameState.allcountries[46].parts[0] = true;
					GlobalScript.inst.gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.empires[1].power -= 20;
					GlobalScript.inst.gameState.empires[0].power += 50;
					GlobalScript.inst.gameState.data[83] = 2;
				}
				else
				{
					GlobalScript.inst.gameState.allcountries[46].parts[0] = true;
					GlobalScript.inst.gameState.influencePRC += 20;
					GlobalScript.inst.gameState.empires[1].power -= 40;
					GlobalScript.inst.gameState.empires[0].power += 50;
					GlobalScript.inst.gameState.data[83] = 2;
				}
				text = string.Format(GlobalScript.inst.new_events_text[1612], "\n");
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[1634], "\n");
			}
		}
		else if (GlobalScript.inst.gameState.data[82] == 1)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
			{
				GlobalScript.inst.gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[1] += 100;
				GlobalScript.inst.gameState.empires[1].power -= 20;
				text = string.Format(GlobalScript.inst.new_events_text[1614], "\n");
			}
			else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 900)
			{
				GlobalScript.inst.gameState.allcountries[23].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[23].SubGosstroy = 1;
				GlobalScript.inst.gameState.allcountries[23].puppetOf = 11;
				GlobalScript.inst.gameState.allcountries[23].prosov = true;
				GlobalScript.inst.gameState.allcountries[23].proprc = false;
				GlobalScript.inst.gameState.allcountries[23].Torg = false;
				GlobalScript.inst.gameState.allcountries[23].econ = false;
				GlobalScript.inst.gameState.allcountries[23].okb = false;
				GlobalScript.inst.gameState.influencePRC -= 30;
				GlobalScript.inst.gameState.empires[1].power += 10;
				text = string.Format(GlobalScript.inst.new_events_text[1613], "\n");
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[1634], "\n");
			}
		}
		else if (GlobalScript.inst.gameState.data[82] == 2)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 750 || GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 750)
			{
				GlobalScript.inst.gameState.allcountries[34].Torg = true;
				GlobalScript.inst.gameState.allcountries[34].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[34].SubGosstroy = 1;
				GlobalScript.inst.gameState.allcountries[34].LeaveASEAN();
				GlobalScript.inst.gameState.allcountries[34].proprc = true;
				GlobalScript.inst.gameState.allcountries[34].Vyshi = false;
				GlobalScript.inst.gameState.influencePRC += 20;
				GlobalScript.inst.gameState.empires[0].power -= 20;
				text = string.Format(GlobalScript.inst.new_events_text[1615], "\n");
			}
			else
			{
				GlobalScript.inst.gameState.influencePRC -= 10;
				text = string.Format(GlobalScript.inst.new_events_text[1616], "\n");
			}
		}
		else if (GlobalScript.inst.gameState.data[82] == 3)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
			{
				GlobalScript.inst.gameState.empires[1].power += 10;
				GlobalScript.inst.gameState.allcountries[14].parts[4] = true;
				text = string.Format(GlobalScript.inst.new_events_text[1617], "\n");
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[14].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 9;
				GlobalScript.inst.gameState.allcountries[14].Torg = false;
				GlobalScript.inst.gameState.allcountries[14].prosov = false;
				GlobalScript.inst.gameState.allcountries[14].puppetOf = 8;
				GlobalScript.inst.gameState.data[117] = 9;
				text = string.Format(GlobalScript.inst.new_events_text[1618], "\n");
			}
		}
		else if (GlobalScript.inst.gameState.data[82] == 4)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
			{
				GlobalScript.inst.gameState.empires[1].power -= 10;
				GlobalScript.inst.gameState.empires[0].power += 20;
				GlobalScript.inst.gameState.allcountries[93].puppetOf = 37;
				text = string.Format(GlobalScript.inst.new_events_text[1619], "\n");
			}
			else
			{
				GlobalScript.inst.gameState.empires[1].power += 10;
				GlobalScript.inst.gameState.empires[0].power -= 20;
				GlobalScript.inst.gameState.Israellost = true;
				text = string.Format(GlobalScript.inst.new_events_text[1620], "\n");
			}
		}
		else if (GlobalScript.inst.gameState.data[82] == 5)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
			{
				if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 0)
				{
					GlobalScript.inst.gameState.empires[1].power += 50;
					text = string.Format(GlobalScript.inst.new_events_text[1624], "\n");
				}
				else if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 1)
				{
					GlobalScript.inst.gameState.allcountries[12].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 1;
					GlobalScript.inst.gameState.allcountries[12].prosov = false;
					GlobalScript.inst.gameState.allcountries[12].proprc = true;
					GlobalScript.inst.gameState.allcountries[12].Torg = true;
					GlobalScript.inst.gameState.influencePRC += 100;
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						gameObject.GetComponent<achievements>().Set(54);
					}
					text = string.Format(GlobalScript.inst.new_events_text[1625], "\n");
				}
			}
			else if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 0)
			{
				GlobalScript.inst.gameState.allcountries[12].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 13;
				GlobalScript.inst.gameState.allcountries[12].prosov = false;
				GlobalScript.inst.gameState.allcountries[12].proprc = false;
				GlobalScript.inst.gameState.allcountries[12].Torg = false;
				GlobalScript.inst.gameState.empires[1].power -= 30;
				text = string.Format(GlobalScript.inst.new_events_text[1626], "\n");
			}
			else if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 1)
			{
				GlobalScript.inst.gameState.ingamewars[5].name_war = GlobalScript.inst.new_events_text[1621];
				GlobalScript.inst.gameState.ingamewars[5].is_going = true;
				GlobalScript.inst.gameState.ingamewars[5].side1 = GlobalScript.inst.new_events_text[1622];
				GlobalScript.inst.gameState.ingamewars[5].side2 = GlobalScript.inst.new_events_text[1623];
				GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
				GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[5].infl1 = 650;
				GlobalScript.inst.gameState.ingamewars[5].infl2 = 350;
				if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
				{
					GlobalScript.inst.gameState.ingamewars[5].infl1 -= 100;
					GlobalScript.inst.gameState.ingamewars[5].infl2 += 100;
				}
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					GlobalScript.inst.gameState.ingamewars[5].infl1 -= 50;
					GlobalScript.inst.gameState.ingamewars[5].infl2 += 50;
				}
				if (GlobalScript.inst.gameState.data[107] == 9)
				{
					GlobalScript.inst.gameState.ingamewars[5].infl1 += 25;
					GlobalScript.inst.gameState.ingamewars[5].infl2 -= 25;
				}
				text = string.Format(GlobalScript.inst.new_events_text[1627], "\n");
			}
		}
		else if (GlobalScript.inst.gameState.data[82] == 6)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 400)
			{
				GlobalScript.inst.gameState.BritLost = true;
				GlobalScript.inst.gameState.empires[0].power -= 20;
				text = string.Format(GlobalScript.inst.new_events_text[1628], "\n");
			}
			else
			{
				GlobalScript.inst.gameState.empires[0].power += 20;
				text = string.Format(GlobalScript.inst.new_events_text[1629], "\n");
			}
		}
		else if (GlobalScript.inst.gameState.data[82] == 7)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
			{
				if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 0)
				{
					GlobalScript.inst.gameState.allcountries[19].JoinAllOurAlliances(yes: true);
					GlobalScript.inst.gameState.allcountries[19].proprc = true;
					GlobalScript.inst.gameState.allcountries[19].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[19].SubGosstroy = 1;
					GlobalScript.inst.gameState.allcountries[19].Torg = true;
					text = string.Format(GlobalScript.inst.new_events_text[1630], "\n");
				}
				else if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 1)
				{
					GlobalScript.inst.gameState.allcountries[19].isSEV = false;
					GlobalScript.inst.gameState.allcountries[19].isOVD = false;
					GlobalScript.inst.gameState.allcountries[19].okb = false;
					GlobalScript.inst.gameState.allcountries[19].econ = false;
					GlobalScript.inst.gameState.allcountries[19].proprc = false;
					GlobalScript.inst.gameState.allcountries[19].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[19].SubGosstroy = 15;
					GlobalScript.inst.gameState.allcountries[19].Torg = false;
					GlobalScript.inst.gameState.allcountries[19].prosov = true;
					text = string.Format(GlobalScript.inst.new_events_text[1632], "\n");
				}
			}
			else if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 1)
			{
				GlobalScript.inst.gameState.allcountries[19].JoinAllOurAlliances(yes: true);
				GlobalScript.inst.gameState.allcountries[19].proprc = true;
				GlobalScript.inst.gameState.allcountries[19].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[19].SubGosstroy = 1;
				GlobalScript.inst.gameState.allcountries[19].Torg = true;
				text = string.Format(GlobalScript.inst.new_events_text[1631], "\n");
			}
			else if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 0)
			{
				GlobalScript.inst.gameState.allcountries[19].isSEV = false;
				GlobalScript.inst.gameState.allcountries[19].isOVD = false;
				GlobalScript.inst.gameState.allcountries[19].okb = false;
				GlobalScript.inst.gameState.allcountries[19].econ = false;
				GlobalScript.inst.gameState.allcountries[19].proprc = false;
				GlobalScript.inst.gameState.allcountries[19].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[19].SubGosstroy = 0;
				GlobalScript.inst.gameState.allcountries[19].Torg = false;
				GlobalScript.inst.gameState.allcountries[19].Vyshi = true;
				text = string.Format(GlobalScript.inst.new_events_text[1633], "\n");
			}
		}
		if (GlobalScript.inst.gameState.data[82] == 8)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 500)
			{
				text = string.Format(GlobalScript.inst.new_events_text[612], "\n");
			}
			else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 800)
			{
				GlobalScript.inst.gameState.allcountries[84].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[84].SubGosstroy = 3;
				GlobalScript.inst.gameState.allcountries[84].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[84].isNATO = false;
				GlobalScript.inst.gameState.empires[0].power -= 50;
				GlobalScript.inst.gameState.allcountries[87].spec -= 5;
				text = string.Format(GlobalScript.inst.new_events_text[613], "\n");
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[84].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[84].SubGosstroy = 4;
				text = string.Format(GlobalScript.inst.new_events_text[614], "\n");
			}
			GlobalScript.inst.gameState.data[82] = -10;
			return true;
		}
		if (GlobalScript.inst.gameState.data[82] == 9)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 600)
			{
				text = string.Format(GlobalScript.inst.new_events_text[641], "\n");
			}
			else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 800)
			{
				text = string.Format(GlobalScript.inst.new_events_text[642], "\n");
				GlobalScript.inst.gameState.empires[0].power -= 50;
				GlobalScript.inst.gameState.allcountries[84].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[84].SubGosstroy = 4;
				GlobalScript.inst.gameState.influencePRC += 30;
				GlobalScript.inst.gameState.allcountries[84].parts[0] = true;
				GlobalScript.inst.gameState.allcountries[95].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[95].SubGosstroy = 1;
				GlobalScript.inst.gameState.allcountries[95].EstablishGovernment(Government.ProChina);
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[643], "\n");
				GlobalScript.inst.gameState.allcountries[84].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[84].SubGosstroy = 4;
			}
			GlobalScript.inst.gameState.data[82] = -10;
			return true;
		}
		if (GlobalScript.inst.gameState.data[82] == 10)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 700)
			{
				text = string.Format(GlobalScript.inst.new_events_text[682], "\n");
				GlobalScript.inst.gameState.allcountries[35].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[35].SubGosstroy = 9;
				GlobalScript.inst.gameState.allcountries[35].puppetOf = 84;
				GlobalScript.inst.gameState.allcountries[35].LeaveAlliances();
				if (GlobalScript.inst.gameState.allcountries[84].Vyshi)
				{
					GlobalScript.inst.gameState.allcountries[35].EstablishGovernment(Government.ProAmerican);
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[683], "\n");
				GlobalScript.inst.gameState.data[124]++;
			}
			GlobalScript.inst.gameState.data[82] = -10;
			return true;
		}
		if (GlobalScript.inst.gameState.data[82] == 11)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 700)
			{
				text = string.Format(GlobalScript.inst.new_events_text[684], "\n");
				GlobalScript.inst.gameState.allcountries[14].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 9;
				GlobalScript.inst.gameState.data[117] = 0;
				GlobalScript.inst.gameState.allcountries[14].puppetOf = 84;
				GlobalScript.inst.gameState.allcountries[14].LeaveAlliances();
				if (GlobalScript.inst.gameState.allcountries[14].Vyshi)
				{
					GlobalScript.inst.gameState.allcountries[14].EstablishGovernment(Government.ProAmerican);
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[685], "\n");
				GlobalScript.inst.gameState.data[124]++;
			}
			GlobalScript.inst.gameState.data[82] = -10;
			return true;
		}
		if (GlobalScript.inst.gameState.data[82] == 12)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 700)
			{
				text = string.Format(GlobalScript.inst.new_events_text[686], "\n");
				GlobalScript.inst.gameState.allcountries[8].Gosstroy = 0;
				GlobalScript.inst.gameState.data[117] = 0;
				GlobalScript.inst.gameState.allcountries[8].SubGosstroy = 9;
				GlobalScript.inst.gameState.allcountries[8].puppetOf = 84;
				GlobalScript.inst.gameState.allcountries[8].LeaveAlliances();
				if (GlobalScript.inst.gameState.allcountries[8].Vyshi)
				{
					GlobalScript.inst.gameState.allcountries[8].EstablishGovernment(Government.ProAmerican);
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[687], "\n");
				GlobalScript.inst.gameState.data[124]++;
			}
			GlobalScript.inst.gameState.data[82] = -10;
			return true;
		}
		if (GlobalScript.inst.gameState.data[82] == 13)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 700)
			{
				text = string.Format(GlobalScript.inst.new_events_text[695], "\n");
				GlobalScript.inst.gameState.allcountries[93].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[93].SubGosstroy = 7;
				GlobalScript.inst.gameState.allcountries[93].puppetOf = 37;
			}
			else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 500)
			{
				text = string.Format(GlobalScript.inst.new_events_text[696], "\n");
				GlobalScript.inst.gameState.empires[0].power -= 50;
				GlobalScript.inst.gameState.allcountries[37].Gosstroy = 0;
				GlobalScript.inst.gameState.Israellost = true;
				GlobalScript.inst.gameState.allcountries[37].SubGosstroy = 9;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[697], "\n");
				GlobalScript.inst.gameState.Israellost = true;
				GlobalScript.inst.gameState.allcountries[93].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[93].SubGosstroy = 3;
			}
			GlobalScript.inst.gameState.data[82] = -10;
			return true;
		}
		if (GlobalScript.inst.gameState.data[82] == 14)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 700)
			{
				int num = (byte)UnityEngine.Random.Range(60, 95);
				text = string.Format(GlobalScript.inst.new_events_text[745], "\n", num);
				GlobalScript.inst.gameState.allcountries[94].name = GlobalScript.inst.new_events_text[735];
				GlobalScript.inst.gameState.allcountries[94].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[94].SubGosstroy = 9;
				GlobalScript.inst.gameState.allcountries[84].parts[4] = true;
				if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.allcountries[14].puppetOf == 84 && GlobalScript.inst.gameState.allcountries[8].puppetOf == 84 && GlobalScript.inst.gameState.allcountries[35].puppetOf == 84)
				{
					gameObject.GetComponent<achievements>().Set(134);
				}
				GlobalScript.inst.gameState.allcountries[94].LeaveAlliances();
			}
			else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 500)
			{
				GlobalScript.inst.gameState.data[127] = 1;
				GlobalScript.inst.gameState.data[129] = 1;
				text = string.Format(GlobalScript.inst.new_events_text[746], "\n");
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[747], "\n");
			}
			GlobalScript.inst.gameState.data[82] = -10;
			return true;
		}
		if (GlobalScript.inst.gameState.data[82] == 15)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 850)
			{
				text = string.Format(GlobalScript.inst.new_events_text[796], "\n");
				GlobalScript.inst.gameState.allcountries[42].EstablishGovernment(Government.ProChina);
				GlobalScript.inst.gameState.allcountries[42].Torg = true;
				GlobalScript.inst.gameState.influencePRC += 10;
				GlobalScript.inst.gameState.allcountries[42].parts[0] = true;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[797], "\n");
				GlobalScript.inst.gameState.allcountries[42].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[42].SubGosstroy = 10;
				GlobalScript.inst.gameState.empires[1].power += 20;
			}
			GlobalScript.inst.gameState.data[82] = -10;
			return true;
		}
		if (GlobalScript.inst.gameState.data[82] == 16)
		{
			if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
			{
				int num2 = 0;
				GlobalScript.inst.gameState.data[158] = 1;
				GlobalScript.inst.gameState.empires[1].power -= 50;
				GlobalScript.inst.gameState.data[7] += 50;
				GlobalScript.inst.gameState.allcountries[10].Gosstroy = GlobalScript.inst.gameState.allcountries[1].Gosstroy;
				GlobalScript.inst.gameState.allcountries[10].SubGosstroy = GlobalScript.inst.gameState.ChineseSubGosstroy();
				GlobalScript.inst.gameState.allcountries[10].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
				if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 0)
				{
					GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[840];
					num2 = 1;
				}
				else if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 1)
				{
					GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[841];
					num2 = 2;
				}
				else if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 2)
				{
					GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[842];
					num2 = 3;
				}
				else
				{
					GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[843];
					num2 = 4;
				}
				if (GlobalScript.inst.gameState.allcountries[10].SubGosstroy == 18)
				{
					GlobalScript.inst.gameState.empires[1].relations += 120;
					GlobalScript.inst.gameState.empires[0].relations -= 120;
				}
				if (GlobalScript.inst.gameState.allcountries[10].SubGosstroy < 18)
				{
					text = string.Format(GlobalScript.inst.new_events_text[844], "\n", GlobalScript.inst.new_events_text[845 + num2], GlobalScript.inst.new_events_text[849 + num2], GlobalScript.inst.new_events_text[983 + GlobalScript.inst.gameState.allcountries[10].SubGosstroy]);
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[844], "\n", GlobalScript.inst.new_events_text[845 + num2], GlobalScript.inst.new_events_text[849 + num2], GlobalScript.inst.new_events_text[1187]);
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[845], "\n");
				GlobalScript.inst.gameState.empires[1].power += 70;
				GlobalScript.inst.gameState.data[8] -= 500;
				GlobalScript.inst.gameState.data[22] -= 500;
				GlobalScript.inst.gameState.data[7] -= 100;
				Politic[] array = GlobalScript.inst.gameState.politics;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].loyality -= 750;
				}
			}
		}
		else
		{
			if (GlobalScript.inst.gameState.data[82] == 17)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 850)
				{
					GlobalScript.inst.gameState.empires[1].power -= 100;
					GlobalScript.inst.gameState.empires[0].power -= 100;
					GlobalScript.inst.gameState.influencePRC += 150;
					GlobalScript.inst.gameState.allcountries[15].Torg = true;
					text = string.Format(GlobalScript.inst.new_events_text[882], "\n");
				}
				else
				{
					for (int j = 0; j < GlobalScript.inst.gameState.allcountries.Length; j++)
					{
						if (GlobalScript.inst.gameState.allcountries[j].isOVD)
						{
							GlobalScript.inst.gameState.allcountries[j].LeaveWP().EstablishGovernment(Government.ProSoviet).JoinNATO()
								.JoinComecon();
							GlobalScript.inst.gameState.influencePRC -= 200;
							GlobalScript.inst.gameState.allcountries[j].Torg = false;
							GlobalScript.inst.gameState.allcountries[j].Gosstroy = GlobalScript.inst.gameState.allcountries[7].Gosstroy;
							GlobalScript.inst.gameState.allcountries[j].SubGosstroy = GlobalScript.inst.gameState.allcountries[7].SubGosstroy;
						}
					}
					GlobalScript.inst.gameState.allcountries[3].parts[0] = false;
					GlobalScript.inst.gameState.allcountries[3].name = GlobalScript.inst.new_events_text[881];
					Politic[] array = GlobalScript.inst.gameState.politics;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].loyality -= 400;
					}
					text = string.Format(GlobalScript.inst.new_events_text[883], "\n");
				}
				GlobalScript.inst.gameState.data[82] = -10;
				return true;
			}
			if (GlobalScript.inst.gameState.data[82] == 18)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[918], "\n");
					GlobalScript.inst.gameState.data[7] += 50;
					GlobalScript.inst.gameState.allcountries[20].parts[0] = true;
					GlobalScript.inst.gameState.allcountries[15].Vyshi = true;
					GlobalScript.inst.gameState.allcountries[15].JoinEU();
					GlobalScript.inst.gameState.allcountries[15].SubGosstroy = 14;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[919], "\n");
					GlobalScript.inst.gameState.allcountries[20].SubGosstroy = GlobalScript.inst.gameState.allcountries[15].SubGosstroy;
					GlobalScript.inst.gameState.allcountries[20].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[20].puppetOf = 15;
					GlobalScript.inst.gameState.allcountries[20].LeaveAlliances();
					GlobalScript.inst.gameState.allcountries[20].proprc = false;
					GlobalScript.inst.gameState.data[7] -= 50;
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 19)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[932], "\n");
					if (GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						GlobalScript.inst.gameState.data[7] -= 100;
					}
					GlobalScript.inst.gameState.allcountries[20].parts[1] = true;
					GlobalScript.inst.gameState.allcountries[20].parts[0] = false;
					GlobalScript.inst.gameState.allcountries[20].LeaveAlliances();
					GlobalScript.inst.gameState.allcountries[20].proprc = false;
					GlobalScript.inst.gameState.allcountries[20].Torg = false;
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						gameObject.GetComponent<achievements>().Set(133);
					}
					GlobalScript.inst.gameState.allcountries[20].name = GlobalScript.inst.new_events_text[935];
					GlobalScript.inst.gameState.allcountries[20].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[20].SubGosstroy = 10;
					GlobalScript.inst.gameState.allcountries[45].Torg = false;
					GlobalScript.inst.gameState.allcountries[45].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[45].SubGosstroy = 0;
				}
				else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 700)
				{
					text = string.Format(GlobalScript.inst.new_events_text[933], "\n");
					GlobalScript.inst.gameState.allcountries[20].LeaveAlliances();
					GlobalScript.inst.gameState.allcountries[20].proprc = false;
					GlobalScript.inst.gameState.allcountries[20].Torg = false;
					GlobalScript.inst.gameState.allcountries[20].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[20].SubGosstroy = 10;
					GlobalScript.inst.gameState.allcountries[45].isNATO = true;
					GlobalScript.inst.gameState.allcountries[45].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[45].Gosstroy = 5;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[934], "\n");
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 20)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1006], "\n");
					GlobalScript.inst.gameState.allcountries[13].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[13].SubGosstroy = 10;
					GlobalScript.inst.gameState.allcountries[13].parts[0] = true;
					GlobalScript.inst.gameState.allcountries[57].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[57].puppetOf = 13;
					GlobalScript.inst.gameState.allcountries[57].SubGosstroy = 10;
					GlobalScript.inst.gameState.data[132] = 1;
				}
				else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 600)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1007], "\n");
					GlobalScript.inst.gameState.data[132] = 2;
					GlobalScript.inst.gameState.allcountries[57].Gosstroy = 0;
					GlobalScript.inst.gameState.data[143] -= 3;
					GlobalScript.inst.gameState.allcountries[57].SubGosstroy = 7;
					GlobalScript.inst.gameState.allcountries[57].Vyshi = true;
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 21)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1020], "\n");
					GlobalScript.inst.gameState.allcountries[25].parts[0] = true;
					GlobalScript.inst.gameState.allcountries[25].name = GlobalScript.inst.new_events_text[1019];
					GlobalScript.inst.gameState.allcountries[25].Torg = true;
					GlobalScript.inst.gameState.allcountries[24].prosov = false;
					GlobalScript.inst.gameState.empires[1].power -= 25;
					GlobalScript.inst.gameState.empires[0].power += 25;
				}
				else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1021], "\n");
					GlobalScript.inst.gameState.allcountries[24].parts[0] = true;
					GlobalScript.inst.gameState.allcountries[24].Torg = true;
					GlobalScript.inst.gameState.allcountries[24].name = GlobalScript.inst.new_events_text[1019];
					GlobalScript.inst.gameState.allcountries[25].Vyshi = false;
					GlobalScript.inst.gameState.empires[0].power -= 25;
					GlobalScript.inst.gameState.empires[1].power += 25;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1022], "\n");
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 22)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1035], "\n");
					GlobalScript.inst.gameState.data[133] = 1;
					GlobalScript.inst.gameState.empires[1].relations = 0;
					GlobalScript.inst.gameState.empires[1].power -= 100;
					GlobalScript.inst.gameState.data[7] += 100;
					GlobalScript.inst.gameState.data[2] += 150;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1036], "\n");
					GlobalScript.inst.gameState.data[133] = 3;
					GlobalScript.inst.gameState.empires[1].power += 100;
					GlobalScript.inst.gameState.empires[1].relations = 0;
					GlobalScript.inst.gameState.data[2] -= 600;
					GlobalScript.inst.gameState.data[3] += 900;
					GlobalScript.inst.gameState.data[7] -= 100;
					Politic[] array = GlobalScript.inst.gameState.politics;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].loyality -= 750;
					}
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 23)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1112], "\n");
					GlobalScript.inst.gameState.data[7] += 50;
					GlobalScript.inst.gameState.empires[0].power -= 50;
					GlobalScript.inst.gameState.allcountries[85].name = GlobalScript.inst.new_events_text[1115];
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						gameObject.GetComponent<achievements>().Set(123);
					}
					GlobalScript.inst.gameState.allcountries[87].spec -= 20;
					GlobalScript.inst.gameState.allcountries[85].LeaveAlliances();
					GlobalScript.inst.gameState.allcountries[85].EstablishGovernment(Government.ProChina);
					GlobalScript.inst.gameState.allcountries[85].Torg = true;
					GlobalScript.inst.gameState.allcountries[85].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[85].SubGosstroy = 10;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1113], "\n");
					GlobalScript.inst.gameState.empires[0].power += 50;
					GlobalScript.inst.gameState.data[7] -= 50;
					GlobalScript.inst.gameState.allcountries[85].SubGosstroy = 5;
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 24)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1179], "\n");
					GlobalScript.inst.gameState.allcountries[41].EstablishGovernment(Government.ProChina);
					GlobalScript.inst.gameState.allcountries[41].Torg = true;
					GlobalScript.inst.gameState.allcountries[41].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[41].SubGosstroy = 15;
					GlobalScript.inst.gameState.allcountries[41].inflCh = 500;
					GlobalScript.inst.gameState.allcountries[41].inflNATO = 500;
					GlobalScript.inst.gameState.allcountries[41].name = GlobalScript.inst.new_events_text[1180];
					GlobalScript.inst.gameState.influencePRC += 15;
					GlobalScript.inst.gameState.empires[1].power -= 15;
					GlobalScript.inst.gameState.allcountries[41].soc_stab = 1000;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1178], "\n");
					GlobalScript.inst.gameState.influencePRC -= 15;
					GlobalScript.inst.gameState.empires[1].power += 30;
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 25)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1182], "\n");
					if (GlobalScript.inst.gameState.allcountries[99].parts[0] && GlobalScript.inst.gameState.allcountries[42].parts[0] && GlobalScript.inst.gameState.iron_and_blood)
					{
						gameObject.GetComponent<achievements>().Set(143);
					}
					GlobalScript.inst.gameState.allcountries[100].EstablishGovernment(Government.ProChina);
					GlobalScript.inst.gameState.allcountries[100].Torg = true;
					GlobalScript.inst.gameState.allcountries[100].spec = 1;
					GlobalScript.inst.gameState.allcountries[100].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[100].SubGosstroy = 15;
					GlobalScript.inst.gameState.allcountries[100].soc_stab = 1000;
					GlobalScript.inst.gameState.allcountries[100].inflCh = 500;
					GlobalScript.inst.gameState.allcountries[100].inflNATO = 500;
					GlobalScript.inst.gameState.influencePRC += 5;
					GlobalScript.inst.gameState.empires[1].power -= 5;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1181], "\n");
					GlobalScript.inst.gameState.allcountries[100].parts[0] = false;
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 26)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1184], "\n");
					if (GlobalScript.inst.gameState.allcountries[100].parts[0] && GlobalScript.inst.gameState.allcountries[42].parts[0] && GlobalScript.inst.gameState.iron_and_blood)
					{
						gameObject.GetComponent<achievements>().Set(143);
					}
					GlobalScript.inst.gameState.allcountries[99].Torg = true;
					GlobalScript.inst.gameState.allcountries[99].spec = 1;
					GlobalScript.inst.gameState.allcountries[99].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[99].SubGosstroy = 15;
					if (!GlobalScript.inst.gameState.event_done[434])
					{
						GlobalScript.inst.gameState.allcountries[99].inflCh = 500;
						GlobalScript.inst.gameState.allcountries[99].soc_stab = 1000;
						GlobalScript.inst.gameState.allcountries[99].inflNATO = 500;
						GlobalScript.inst.gameState.allcountries[99].EstablishGovernment(Government.ProChina);
					}
					if (!GlobalScript.inst.gameState.event_done[434] || (GlobalScript.inst.gameState.event_done[434] && GlobalScript.inst.gameState.resultOfEvents[434] >= 2))
					{
						GlobalScript.inst.gameState.influencePRC += 15;
					}
					GlobalScript.inst.gameState.empires[1].power -= 15;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1183], "\n");
					GlobalScript.inst.gameState.allcountries[99].parts[0] = false;
					GlobalScript.inst.gameState.allcountries[99].puppetOf = -1;
					if (GlobalScript.inst.gameState.event_done[434] && GlobalScript.inst.gameState.resultOfEvents[434] == 1)
					{
						GlobalScript.inst.gameState.allcountries[41].Torg = true;
					}
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 27)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 500)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1240], "\n");
					GlobalScript.inst.gameState.empires[1].power += 50;
					GlobalScript.inst.gameState.allcountries[22].isSEV = true;
					GlobalScript.inst.gameState.empires[0].power -= 10;
					GlobalScript.inst.gameState.influencePRC -= 10;
				}
				else
				{
					GlobalScript.inst.gameState.allcountries[22].Torg = true;
					GlobalScript.inst.gameState.empires[0].power -= 30;
					if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power)
					{
						GlobalScript.inst.gameState.influencePRC += 30;
						GlobalScript.inst.gameState.allcountries[22].EstablishGovernment(Government.ProChina);
						GlobalScript.inst.gameState.allcountries[22].Gosstroy = GlobalScript.inst.gameState.allcountries[1].Gosstroy;
						GlobalScript.inst.gameState.allcountries[22].SubGosstroy = GlobalScript.inst.gameState.allcountries[1].SubGosstroy;
					}
					else
					{
						GlobalScript.inst.gameState.empires[0].power += 30;
						GlobalScript.inst.gameState.allcountries[22].EstablishGovernment(Government.ProAmerican);
						GlobalScript.inst.gameState.allcountries[22].Gosstroy = GlobalScript.inst.gameState.allcountries[51].Gosstroy;
						GlobalScript.inst.gameState.allcountries[22].SubGosstroy = GlobalScript.inst.gameState.allcountries[51].SubGosstroy;
					}
					text = string.Format(GlobalScript.inst.new_events_text[1241], "\n", GlobalScript.inst.gameState.allcountries[22].proprc ? GlobalScript.inst.new_events_text[1242] : GlobalScript.inst.new_events_text[1243]);
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 28)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 800)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1317], "\n");
					GlobalScript.inst.gameState.allcountries[14].parts[5] = true;
					GlobalScript.inst.gameState.allcountries[36].Torg = false;
					GlobalScript.inst.gameState.allcountries[36].LeaveAlliances();
					GlobalScript.inst.gameState.allcountries[36].isOil = false;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1318], "\n");
					GlobalScript.inst.gameState.allcountries[36].Torg = false;
					GlobalScript.inst.gameState.allcountries[36].cw = true;
					GlobalScript.inst.gameState.allcountries[14].dev = 1;
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 29)
			{
				GlobalScript.inst.gameState.allcountries[36].cw = false;
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					GlobalScript.inst.gameState.allcountries[14].LeaveAlliances();
					int num3 = 0;
					if (GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[1].power)
						{
							num3 = 1;
							text = string.Format(GlobalScript.inst.new_events_text[1327], "\n", GlobalScript.inst.new_events_text[1335 + num3]);
							GlobalScript.inst.gameState.allcountries[14].EstablishGovernment(Government.ProChina).JoinAllOurAlliances(yes: true).EstablishGosstroy(1);
							GlobalScript.inst.gameState.allcountries[14].Torg = true;
							GlobalScript.inst.gameState.influencePRC += 50;
							GlobalScript.inst.gameState.allcountries[14].soc_stab = 1000;
						}
						else
						{
							num3 = 2;
							text = string.Format(GlobalScript.inst.new_events_text[1327], "\n", GlobalScript.inst.new_events_text[1335 + num3]);
							GlobalScript.inst.gameState.allcountries[14].EstablishGovernment(Government.ProSoviet).JoinAllOurAlliances(yes: true).EstablishGosstroy(7);
							GlobalScript.inst.gameState.allcountries[14].Torg = true;
							GlobalScript.inst.gameState.empires[1].power += 50;
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
					{
						if (GlobalScript.inst.gameState.influencePRC >= GlobalScript.inst.gameState.empires[0].power)
						{
							num3 = 1;
							text = string.Format(GlobalScript.inst.new_events_text[1328], "\n", GlobalScript.inst.new_events_text[1335 + num3]);
							GlobalScript.inst.gameState.allcountries[14].EstablishGovernment(Government.ProChina).JoinAllOurAlliances(yes: true).EstablishGosstroy(1);
							GlobalScript.inst.gameState.allcountries[14].Torg = true;
							GlobalScript.inst.gameState.influencePRC += 50;
							GlobalScript.inst.gameState.allcountries[14].soc_stab = 1000;
						}
						else
						{
							num3 = 3;
							text = string.Format(GlobalScript.inst.new_events_text[1328], "\n", GlobalScript.inst.new_events_text[1335 + num3]);
							GlobalScript.inst.gameState.allcountries[14].EstablishGovernment(Government.ProAmerican).JoinAllOurAlliances(yes: true).EstablishGosstroy(51);
							GlobalScript.inst.gameState.allcountries[14].Torg = true;
							GlobalScript.inst.gameState.empires[0].power += 50;
						}
					}
					else
					{
						num3 = 1;
						text = string.Format(GlobalScript.inst.new_events_text[1329], "\n", GlobalScript.inst.new_events_text[1335 + num3]);
						GlobalScript.inst.gameState.allcountries[14].EstablishGovernment(Government.ProChina).JoinAllOurAlliances(yes: true).EstablishGosstroy(1);
						GlobalScript.inst.gameState.allcountries[14].soc_stab = 1000;
						GlobalScript.inst.gameState.allcountries[14].Torg = true;
						GlobalScript.inst.gameState.influencePRC += 50;
					}
					GlobalScript.inst.gameState.allcountries[14].dev = 1;
				}
				else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 500)
				{
					GlobalScript.inst.gameState.influencePRC -= 50;
					if (GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						text = string.Format(GlobalScript.inst.new_events_text[1330], "\n");
					}
					else if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
					{
						text = string.Format(GlobalScript.inst.new_events_text[1331], "\n");
					}
					else
					{
						text = string.Format(GlobalScript.inst.new_events_text[1332], "\n");
					}
				}
				else
				{
					GlobalScript.inst.gameState.influencePRC -= 30;
					if (GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						text = string.Format(GlobalScript.inst.new_events_text[1333], "\n");
					}
					else if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
					{
						text = string.Format(GlobalScript.inst.new_events_text[1334], "\n");
					}
					else
					{
						text = string.Format(GlobalScript.inst.new_events_text[1335], "\n");
					}
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 30)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 800)
				{
					bool flag = false;
					bool flag2 = false;
					if (GlobalScript.inst.gameState.ingamewars[31].is_going || GlobalScript.inst.gameState.allcountries[86].parts[0])
					{
						flag = true;
					}
					if (GlobalScript.inst.gameState.ingamewars[32].is_going || GlobalScript.inst.gameState.allcountries[86].parts[1])
					{
						flag2 = true;
					}
					int num4 = 0;
					if (flag && flag2)
					{
						num4 = 1393;
					}
					else if (flag)
					{
						num4 = 1394;
					}
					else if (flag2)
					{
						num4 = 1395;
					}
					GlobalScript.inst.gameState.ingamewars[31].is_going = false;
					GlobalScript.inst.gameState.ingamewars[32].is_going = false;
					text = string.Format(GlobalScript.inst.new_events_text[1388], "\n", (num4 > 0) ? GlobalScript.inst.new_events_text[num4] : null);
					GlobalScript.inst.gameState.allcountries[86].name = GlobalScript.inst.new_events_text[1391];
				}
				else if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 >= 800)
				{
					bool flag3 = false;
					bool flag4 = false;
					if (GlobalScript.inst.gameState.ingamewars[31].is_going || GlobalScript.inst.gameState.allcountries[86].parts[0])
					{
						flag3 = true;
					}
					if (GlobalScript.inst.gameState.ingamewars[32].is_going || GlobalScript.inst.gameState.allcountries[86].parts[1])
					{
						flag4 = true;
					}
					gameObject.GetComponent<achievements>().Set(151);
					text = string.Format(GlobalScript.inst.new_events_text[1389], "\n", (flag3 || flag4) ? GlobalScript.inst.new_events_text[1396] : null);
					if (GlobalScript.inst.gameState.ingamewars[31].is_going)
					{
						GlobalScript.inst.gameState.ingamewars[31].is_going = false;
						GlobalScript.inst.gameState.allcountries[86].parts[0] = false;
					}
					if (GlobalScript.inst.gameState.ingamewars[32].is_going)
					{
						GlobalScript.inst.gameState.ingamewars[32].is_going = false;
						GlobalScript.inst.gameState.allcountries[86].parts[1] = false;
					}
					GlobalScript.inst.gameState.allcountries[86].name = GlobalScript.inst.new_events_text[1392];
					GlobalScript.inst.gameState.allcountries[86].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[86].SubGosstroy = 7;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1390], "\n");
					GlobalScript.inst.gameState.allcountries[86].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[86].SubGosstroy = 14;
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 31)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					text = string.Format(GlobalScript.inst.new_events_text[1417], "\n");
					if (GlobalScript.inst.gameState.allcountries[86].parts[1] && !GlobalScript.inst.gameState.ingamewars[32].is_going && GlobalScript.inst.gameState.iron_and_blood)
					{
						gameObject.GetComponent<achievements>().Set(151);
					}
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1418], "\n");
					GlobalScript.inst.gameState.allcountries[86].parts[0] = false;
				}
			}
			else if (GlobalScript.inst.gameState.data[82] == 32)
			{
				if (GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 >= 900)
				{
					if (GlobalScript.inst.gameState.allcountries[86].parts[0] && !GlobalScript.inst.gameState.ingamewars[31].is_going)
					{
						gameObject.GetComponent<achievements>().Set(151);
					}
					text = string.Format(GlobalScript.inst.new_events_text[1419], "\n");
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1420], "\n");
					GlobalScript.inst.gameState.allcountries[86].parts[1] = false;
				}
			}
		}
		return false;
	}

	public void FixSubs()
	{
		for (int i = 0; i < GlobalScript.inst.gameState.allcountries.Length; i++)
		{
			if (i < 71 || i > 83)
			{
				if (GlobalScript.inst.gameState.allcountries[i].Gosstroy != 0 && (GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 0 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 7 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 9 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 10 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 13 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 17))
				{
					GlobalScript.inst.gameState.allcountries[i].Gosstroy = 0;
				}
				else if (GlobalScript.inst.gameState.allcountries[i].Gosstroy != 1 && (GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 1 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 2 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 16 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 18))
				{
					GlobalScript.inst.gameState.allcountries[i].Gosstroy = 1;
				}
				else if (GlobalScript.inst.gameState.allcountries[i].Gosstroy != 2 && (GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 3 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 8 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 11 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 15 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 14))
				{
					GlobalScript.inst.gameState.allcountries[i].Gosstroy = 2;
				}
				else if (GlobalScript.inst.gameState.allcountries[i].Gosstroy != 3 && (GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 4 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 5 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 6 || GlobalScript.inst.gameState.allcountries[i].SubGosstroy == 12))
				{
					GlobalScript.inst.gameState.allcountries[i].Gosstroy = 3;
				}
			}
		}
	}

	public void FixAlliances()
	{
		for (int i = 0; i < GlobalScript.inst.gameState.allcountries.Length; i++)
		{
			if (GlobalScript.inst.gameState.allcountries[i].isSEV)
			{
				GlobalScript.inst.gameState.allcountries[i].econ = false;
				GlobalScript.inst.gameState.allcountries[i].isEU = false;
				GlobalScript.inst.gameState.allcountries[i].isSocEU = false;
				GlobalScript.inst.gameState.allcountries[i].isASEAN = false;
			}
			else if (GlobalScript.inst.gameState.allcountries[i].econ)
			{
				GlobalScript.inst.gameState.allcountries[i].isSEV = false;
				GlobalScript.inst.gameState.allcountries[i].isEU = false;
				GlobalScript.inst.gameState.allcountries[i].isSocEU = false;
				GlobalScript.inst.gameState.allcountries[i].isASEAN = false;
			}
			else if (GlobalScript.inst.gameState.allcountries[i].isEU)
			{
				GlobalScript.inst.gameState.allcountries[i].isSEV = false;
				GlobalScript.inst.gameState.allcountries[i].econ = false;
				GlobalScript.inst.gameState.allcountries[i].isSocEU = false;
				GlobalScript.inst.gameState.allcountries[i].isASEAN = false;
			}
			else if (GlobalScript.inst.gameState.allcountries[i].isSocEU)
			{
				GlobalScript.inst.gameState.allcountries[i].isSEV = false;
				GlobalScript.inst.gameState.allcountries[i].econ = false;
				GlobalScript.inst.gameState.allcountries[i].isEU = false;
				GlobalScript.inst.gameState.allcountries[i].isASEAN = false;
			}
			else if (GlobalScript.inst.gameState.allcountries[i].isASEAN)
			{
				GlobalScript.inst.gameState.allcountries[i].isSEV = false;
				GlobalScript.inst.gameState.allcountries[i].econ = false;
				GlobalScript.inst.gameState.allcountries[i].isEU = false;
				GlobalScript.inst.gameState.allcountries[i].isSocEU = false;
			}
			if (GlobalScript.inst.gameState.allcountries[i].isOVD)
			{
				GlobalScript.inst.gameState.allcountries[i].okb = false;
				GlobalScript.inst.gameState.allcountries[i].isNATO = false;
				GlobalScript.inst.gameState.allcountries[i].isSEATO = false;
				GlobalScript.inst.gameState.allcountries[i].isSENTO = false;
			}
			else if (GlobalScript.inst.gameState.allcountries[i].okb)
			{
				GlobalScript.inst.gameState.allcountries[i].isOVD = false;
				GlobalScript.inst.gameState.allcountries[i].isNATO = false;
				GlobalScript.inst.gameState.allcountries[i].isSEATO = false;
				GlobalScript.inst.gameState.allcountries[i].isSENTO = false;
			}
			else if (GlobalScript.inst.gameState.allcountries[i].isNATO)
			{
				GlobalScript.inst.gameState.allcountries[i].okb = false;
				GlobalScript.inst.gameState.allcountries[i].isOVD = false;
				GlobalScript.inst.gameState.allcountries[i].isSEATO = false;
				GlobalScript.inst.gameState.allcountries[i].isSENTO = false;
			}
			else if (GlobalScript.inst.gameState.allcountries[i].isSEATO)
			{
				GlobalScript.inst.gameState.allcountries[i].isOVD = false;
				GlobalScript.inst.gameState.allcountries[i].isNATO = false;
				GlobalScript.inst.gameState.allcountries[i].okb = false;
				GlobalScript.inst.gameState.allcountries[i].isSENTO = false;
			}
			else if (GlobalScript.inst.gameState.allcountries[i].isSENTO)
			{
				GlobalScript.inst.gameState.allcountries[i].isOVD = false;
				GlobalScript.inst.gameState.allcountries[i].isNATO = false;
				GlobalScript.inst.gameState.allcountries[i].isSEATO = false;
				GlobalScript.inst.gameState.allcountries[i].okb = false;
			}
		}
	}

	public int ChineseSubGosstroy()
	{
		if (allcountries[1].Gosstroy == 0)
		{
			if (modifies[40].active)
			{
				return 17;
			}
			if (data[14] <= 2 && data[16] < 13 && data[6] >= 700 && data[15] < 8 && modifies[6].active)
			{
				return 0;
			}
			if (data[16] >= 13 && data[31] >= 700 && !modifies[6].active)
			{
				return 9;
			}
			if (data[16] <= 13 && data[31] >= 700 && (modifies[6].active || modifies[3].active))
			{
				return 10;
			}
			if (data[16] >= 13 && !modifies[6].active)
			{
				return 7;
			}
			return 13;
		}
		if (allcountries[1].Gosstroy == 1)
		{
			if (GlobalScript.inst.gameState.modifies[49].active)
			{
				return 18;
			}
			if (data[16] < 13 && data[14] == 1 && data[17] >= 17 && !modifies[6].active)
			{
				return 2;
			}
			if (data[14] == 1)
			{
				return 16;
			}
			return 1;
		}
		if (allcountries[1].Gosstroy == 2)
		{
			if (data[14] >= 2 && data[16] >= 13 && data[6] <= 700 && data[15] >= 8 && data[17] >= 18 && !allcountries[1].isOVD)
			{
				return 14;
			}
			if (data[14] <= 3 && data[16] >= 12 && data[16] <= 13 && data[6] >= 300 && data[18] > 21)
			{
				return 11;
			}
			if (data[14] <= 3 && data[16] <= 14 && data[6] >= 500 && data[16] > 11 && data[31] >= 700)
			{
				return 8;
			}
			if (data[14] <= 3 && data[16] <= 13 && data[17] > 17)
			{
				return 3;
			}
			return 15;
		}
		if (allcountries[1].Gosstroy == 3)
		{
			if (data[16] <= 13 && data[6] >= 500)
			{
				return 4;
			}
			if ((data[15] <= 8 && data[17] <= 18) || data[31] >= 700)
			{
				return 12;
			}
			if (data[16] > 13 && data[6] < 700)
			{
				return 6;
			}
			return 5;
		}
		return 13;
	}

	public int AfricanSubGosstroy(int Gosstroy)
	{
		int num = 0;
		switch (Gosstroy)
		{
		case 0:
			switch (UnityEngine.Random.Range(0, 6))
			{
			case 0:
				return 0;
			case 1:
				return 7;
			case 2:
				return 9;
			case 3:
				return 10;
			case 4:
				return 13;
			case 5:
				return 17;
			}
			break;
		case 1:
			switch (UnityEngine.Random.Range(0, 3))
			{
			case 0:
				return 1;
			case 1:
				return 2;
			case 2:
				return 16;
			}
			break;
		case 2:
			switch (UnityEngine.Random.Range(0, 5))
			{
			case 0:
				return 3;
			case 1:
				return 8;
			case 2:
				return 11;
			case 3:
				return 14;
			case 4:
				return 15;
			}
			break;
		case 3:
			switch (UnityEngine.Random.Range(0, 4))
			{
			case 0:
				return 4;
			case 1:
				return 5;
			case 2:
				return 6;
			case 3:
				return 12;
			}
			break;
		}
		return 13;
	}

	public int FindPerson(int name1, int name2, int trait0, int trait1, int trait2)
	{
		int result = -1;
		for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
		{
			if (GlobalScript.inst.gameState.politics[i] != null && GlobalScript.inst.gameState.politics[i].name_1 == name1 && GlobalScript.inst.gameState.politics[i].name_2 == name2 && GlobalScript.inst.gameState.politics[i].traits[0] == trait0 && GlobalScript.inst.gameState.politics[i].traits[1] == trait1 && GlobalScript.inst.gameState.politics[i].traits[2] == trait2)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public float ChangeOfKilling(int politic)
	{
		float num = 0.5f;
		num = ((GlobalScript.inst.gameState.data[9] + GlobalScript.inst.gameState.data[1] + GlobalScript.inst.gameState.data[22] < GlobalScript.inst.gameState.politics[politic].power) ? (num - 0.05f) : (num + 0.05f));
		if (GlobalScript.inst.gameState.data[9] + GlobalScript.inst.gameState.data[1] >= GlobalScript.inst.gameState.politics[politic].power)
		{
			num += 0.05f;
		}
		num = ((SummOfLoyalityOfPoliticans() > 900) ? (num + 0.15f) : ((SummOfLoyalityOfPoliticans() > 800) ? (num + 0.12f) : ((SummOfLoyalityOfPoliticans() > 700) ? (num + 0.1f) : ((SummOfLoyalityOfPoliticans() > 600) ? (num + 0.07f) : ((SummOfLoyalityOfPoliticans() <= 500) ? (num - 0.05f) : (num + 0.05f))))));
		if (GlobalScript.inst.gameState.data[1] > 800)
		{
			num += 0.05f;
		}
		else if (GlobalScript.inst.gameState.data[1] < 700)
		{
			num -= 0.05f;
		}
		if (GlobalScript.inst.gameState.politics[politic].is_sledstvie)
		{
			num += 0.1f;
		}
		return num;
	}

	public int SummOfLoyalityOfPoliticans()
	{
		int num = 0;
		Politic[] array = GlobalScript.inst.gameState.politics;
		foreach (Politic politic in array)
		{
			num += politic.loyality;
		}
		return num / GlobalScript.inst.gameState.politics.Length;
	}

	public void MakeNewLeader(int is_him)
	{
		int[] array = new int[16]
		{
			GlobalScript.inst.gameState.leader.name_1,
			GlobalScript.inst.gameState.leader.name_2,
			GlobalScript.inst.gameState.leader.traits[0],
			GlobalScript.inst.gameState.leader.traits[1],
			GlobalScript.inst.gameState.leader.traits[2],
			GlobalScript.inst.gameState.leader.age,
			GlobalScript.inst.gameState.leader.face_type,
			GlobalScript.inst.gameState.leader.face_parts[0],
			GlobalScript.inst.gameState.leader.face_parts[1],
			GlobalScript.inst.gameState.leader.face_parts[2],
			GlobalScript.inst.gameState.leader.face_parts[3],
			GlobalScript.inst.gameState.leader.face_parts[4],
			GlobalScript.inst.gameState.leader.face_parts[5],
			GlobalScript.inst.gameState.leader.face_parts[6],
			GlobalScript.inst.gameState.leader.face_parts[7],
			GlobalScript.inst.gameState.leader.jacket
		};
		GlobalScript.inst.gameState.leader.name_1 = GlobalScript.inst.gameState.politics[is_him].name_1;
		GlobalScript.inst.gameState.leader.name_2 = GlobalScript.inst.gameState.politics[is_him].name_2;
		GlobalScript.inst.gameState.leader.traits[0] = GlobalScript.inst.gameState.politics[is_him].traits[0];
		GlobalScript.inst.gameState.leader.traits[1] = GlobalScript.inst.gameState.politics[is_him].traits[1];
		GlobalScript.inst.gameState.leader.traits[2] = GlobalScript.inst.gameState.politics[is_him].traits[2];
		GlobalScript.inst.gameState.leader.age = GlobalScript.inst.gameState.politics[is_him].age;
		GlobalScript.inst.gameState.leader.face_type = GlobalScript.inst.gameState.politics[is_him].face_type;
		GlobalScript.inst.gameState.leader.face_parts[0] = GlobalScript.inst.gameState.politics[is_him].face_parts[0];
		GlobalScript.inst.gameState.leader.face_parts[1] = GlobalScript.inst.gameState.politics[is_him].face_parts[1];
		GlobalScript.inst.gameState.leader.face_parts[2] = GlobalScript.inst.gameState.politics[is_him].face_parts[2];
		GlobalScript.inst.gameState.leader.face_parts[3] = GlobalScript.inst.gameState.politics[is_him].face_parts[3];
		GlobalScript.inst.gameState.leader.face_parts[4] = GlobalScript.inst.gameState.politics[is_him].face_parts[4];
		GlobalScript.inst.gameState.leader.face_parts[5] = GlobalScript.inst.gameState.politics[is_him].face_parts[5];
		GlobalScript.inst.gameState.leader.face_parts[6] = GlobalScript.inst.gameState.politics[is_him].face_parts[6];
		GlobalScript.inst.gameState.leader.face_parts[7] = GlobalScript.inst.gameState.politics[is_him].face_parts[7];
		GlobalScript.inst.gameState.leader.jacket = GlobalScript.inst.gameState.politics[is_him].jacket;
		GlobalScript.inst.gameState.politics[is_him].name_1 = (byte)array[0];
		GlobalScript.inst.gameState.politics[is_him].name_2 = (byte)array[1];
		GlobalScript.inst.gameState.politics[is_him].traits[0] = (byte)array[2];
		GlobalScript.inst.gameState.politics[is_him].traits[1] = (byte)array[3];
		GlobalScript.inst.gameState.politics[is_him].traits[2] = (byte)array[4];
		GlobalScript.inst.gameState.politics[is_him].age = (byte)array[5];
		GlobalScript.inst.gameState.politics[is_him].face_type = (byte)array[6];
		GlobalScript.inst.gameState.politics[is_him].face_parts[0] = (byte)array[7];
		GlobalScript.inst.gameState.politics[is_him].face_parts[1] = (byte)array[8];
		GlobalScript.inst.gameState.politics[is_him].face_parts[2] = (byte)array[9];
		GlobalScript.inst.gameState.politics[is_him].face_parts[3] = (byte)array[10];
		GlobalScript.inst.gameState.politics[is_him].face_parts[4] = (byte)array[11];
		GlobalScript.inst.gameState.politics[is_him].face_parts[5] = (byte)array[12];
		GlobalScript.inst.gameState.politics[is_him].face_parts[6] = (byte)array[13];
		GlobalScript.inst.gameState.politics[is_him].face_parts[7] = (byte)array[14];
		GlobalScript.inst.gameState.politics[is_him].jacket = (byte)array[15];
	}

	public void KillPerson(int number)
	{
		for (int i = 0; i < p_first.Length; i++)
		{
			if (p_first[i] == number)
			{
				p_first[i] = 200;
				break;
			}
		}
		for (int j = 0; j < p_second.Length; j++)
		{
			if (p_second[j] == number)
			{
				p_second[j] = 200;
				break;
			}
		}
		for (int k = 0; k < p_third.Length; k++)
		{
			if (p_third[k] == number)
			{
				p_third[k] = 200;
				break;
			}
		}
		for (int l = 0; l < p_forth.Length; l++)
		{
			if (p_forth[l] == number)
			{
				p_forth[l] = 200;
				break;
			}
		}
		for (int m = 0; m < politics_dolshnost.Length; m++)
		{
			if (politics_dolshnost[m] == number)
			{
				politics_dolshnost[m] = 200;
			}
		}
		for (int n = 0; n < GlobalScript.inst.gameState.faction_leader.Length; n++)
		{
			if (GlobalScript.inst.gameState.faction_leader[n] == number)
			{
				GlobalScript.inst.gameState.faction_leader[n] = 200;
			}
		}
		BalancePolitic(new List<byte> { (byte)number });
	}

	public void CalcRelLeader(int num)
	{
		int num2 = 100;
		if (GlobalScript.inst.gameState.data[52] == 34)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
			{
				num2 += 250;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
			{
				num2 += 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
			{
				num2 -= 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
			{
				num2 -= 150;
			}
		}
		else if (GlobalScript.inst.gameState.data[52] == 35)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
			{
				num2 += 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
			{
				num2 += 250;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
			{
				num2 += 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
			{
				num2 -= 100;
			}
		}
		else if (GlobalScript.inst.gameState.data[52] == 36)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
			{
				num2 -= 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
			{
				num2 += 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
			{
				num2 += 250;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
			{
				num2 += 50;
			}
		}
		else if (GlobalScript.inst.gameState.data[52] == 37)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
			{
				num2 -= 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
			{
				num2 += 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
			{
				num2 += 250;
			}
		}
		if (GlobalScript.inst.gameState.data[54] == 38)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
			{
				num2 += 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
			{
				num2 -= 200;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
			{
				num2 += 250;
			}
		}
		else if (GlobalScript.inst.gameState.data[54] == 39)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
			{
				num2 += 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
			{
				num2 -= 50;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
			{
				num2 -= 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
			{
				num2 += 50;
			}
		}
		else if (GlobalScript.inst.gameState.data[54] == 40)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
			{
				num2 -= 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
			{
				num2 += 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
			{
				num2 += 150;
			}
		}
		else if (GlobalScript.inst.gameState.data[54] == 41)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
			{
				num2 -= 50;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
			{
				num2 += 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
			{
				num2 += 100;
			}
		}
		if (GlobalScript.inst.gameState.data[14] == 0)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[1] == 4)
			{
				num2 += 250;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 6)
			{
				num2 -= 150;
			}
		}
		else if (GlobalScript.inst.gameState.data[14] == 1)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[1] == 4)
			{
				num2 += 250;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 5)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 7)
			{
				num2 -= 150;
			}
		}
		else if (GlobalScript.inst.gameState.data[14] == 2)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[1] == 4)
			{
				num2 += 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 5)
			{
				num2 += 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 7)
			{
				num2 -= 100;
			}
		}
		else if (GlobalScript.inst.gameState.data[14] == 3)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[1] == 4)
			{
				num2 += 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 5)
			{
				num2 += 250;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 7)
			{
				num2 -= 100;
			}
		}
		else if (GlobalScript.inst.gameState.data[14] == 4)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[1] == 4)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 6)
			{
				num2 += 200;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 5)
			{
				num2 += 50;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 7)
			{
				num2 += 100;
			}
		}
		else if (GlobalScript.inst.gameState.data[14] == 5)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[1] == 4)
			{
				num2 -= 250;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 6)
			{
				num2 += 300;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 5)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[1] == 7)
			{
				num2 += 250;
			}
		}
		if (GlobalScript.inst.gameState.leader.traits[0] == GlobalScript.inst.gameState.politics[num].traits[0])
		{
			num2 += 300;
		}
		if (GlobalScript.inst.gameState.leader.traits[1] == 4)
		{
			num2 = ((GlobalScript.inst.gameState.politics[num].traits[1] == 6) ? (num2 - 150) : ((GlobalScript.inst.gameState.politics[num].traits[1] != 4) ? (num2 - 100) : (num2 + 100)));
		}
		else if (GlobalScript.inst.gameState.leader.traits[1] == 6)
		{
			num2 = ((GlobalScript.inst.gameState.politics[num].traits[1] == 4) ? (num2 - 200) : ((GlobalScript.inst.gameState.politics[num].traits[1] != 6) ? (num2 + 100) : (num2 + 100)));
		}
		else if (GlobalScript.inst.gameState.leader.traits[1] == 5 && GlobalScript.inst.gameState.politics[num].traits[1] != 5)
		{
			num2 += 100;
		}
		else if (GlobalScript.inst.gameState.leader.traits[1] == 7 && GlobalScript.inst.gameState.politics[num].traits[1] == 6)
		{
			num2 += 50;
		}
		if (GlobalScript.inst.gameState.leader.traits[2] == 8)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[2] == 9)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[2] == 8)
			{
				num2 += 100;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[2] == 10)
			{
				num2 += 50;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[2] == 14)
			{
				num2 += 50;
			}
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 9)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[2] == 16)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[2] != 9)
			{
				num2 += 50;
			}
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 10)
		{
			num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] == 12) ? (num2 + 50) : ((GlobalScript.inst.gameState.politics[num].traits[2] != 10) ? (num2 - 100) : (num2 + 300)));
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 11)
		{
			num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] == 10) ? (num2 - 100) : ((GlobalScript.inst.gameState.politics[num].traits[2] != 12) ? (num2 + 100) : (num2 - 100)));
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 12)
		{
			num2 -= 50;
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 13)
		{
			num2 += 100;
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 14)
		{
			num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] == 15) ? (num2 - 200) : ((GlobalScript.inst.gameState.politics[num].traits[2] != 14) ? (num2 + 50) : (num2 + 150)));
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 15)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[2] == 15)
			{
				num2 += 200;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[2] == 14)
			{
				num2 -= 200;
			}
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 16)
		{
			if (GlobalScript.inst.gameState.politics[num].traits[2] == 9)
			{
				num2 -= 150;
			}
			else if (GlobalScript.inst.gameState.politics[num].traits[2] == 14)
			{
				num2 += 50;
			}
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 17)
		{
			num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] == 8) ? (num2 - 150) : ((GlobalScript.inst.gameState.politics[num].traits[2] != 17) ? (num2 - 50) : (num2 + 300)));
		}
		else if (GlobalScript.inst.gameState.leader.traits[2] == 18)
		{
			num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] != 11) ? (num2 + 10) : (num2 - 200));
		}
		GlobalScript.inst.gameState.politics[num].loyality = num2;
	}

	public void CalcRel(int num)
	{
		for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
		{
			if (i != num)
			{
				int num2 = 0;
				if (GlobalScript.inst.gameState.politics[i].traits[0] == GlobalScript.inst.gameState.politics[num].traits[0])
				{
					num2 += 500;
				}
				if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
				{
					if (GlobalScript.inst.gameState.politics[i].traits[0] == 1)
					{
						num2 += 50;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[0] == 2)
					{
						num2 -= 150;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[0] == 3)
					{
						num2 -= 300;
					}
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
				{
					if (GlobalScript.inst.gameState.politics[i].traits[0] == 0)
					{
						num2 += 50;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[0] == 2)
					{
						num2 -= 50;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[0] == 3)
					{
						num2 -= 150;
					}
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
				{
					if (GlobalScript.inst.gameState.politics[i].traits[0] == 0)
					{
						num2 -= 150;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[0] == 1)
					{
						num2 += 50;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[0] == 3)
					{
						num2 += 100;
					}
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
				{
					if (GlobalScript.inst.gameState.politics[i].traits[0] == 0)
					{
						num2 -= 300;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[0] == 1)
					{
						num2 -= 150;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[0] == 2)
					{
						num2 += 100;
					}
				}
				if (GlobalScript.inst.gameState.politics[num].traits[1] == 4)
				{
					num2 = ((GlobalScript.inst.gameState.politics[i].traits[1] == 6) ? (num2 - 250) : ((GlobalScript.inst.gameState.politics[i].traits[1] != 4) ? (num2 - 100) : (num2 + 100)));
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[1] == 6)
				{
					num2 = ((GlobalScript.inst.gameState.politics[i].traits[1] == 4) ? (num2 - 300) : ((GlobalScript.inst.gameState.politics[i].traits[1] != 6) ? (num2 + 100) : (num2 + 100)));
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[1] == 5 && GlobalScript.inst.gameState.politics[i].traits[1] != 5)
				{
					num2 += 100;
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[1] == 7 && GlobalScript.inst.gameState.politics[i].traits[1] == 6)
				{
					num2 += 50;
				}
				if (GlobalScript.inst.gameState.politics[num].traits[2] == 8)
				{
					if (GlobalScript.inst.gameState.politics[i].traits[2] == 9)
					{
						num2 -= 250;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[2] == 8)
					{
						num2 += 100;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[2] == 10)
					{
						num2 += 50;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[2] == 14)
					{
						num2 += 50;
					}
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 9)
				{
					if (GlobalScript.inst.gameState.politics[i].traits[2] == 16)
					{
						num2 -= 250;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[2] != 9)
					{
						num2 += 50;
					}
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 10)
				{
					num2 = ((GlobalScript.inst.gameState.politics[i].traits[2] == 12) ? (num2 + 50) : ((GlobalScript.inst.gameState.politics[i].traits[2] != 10) ? (num2 - 100) : (num2 + 300)));
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 11)
				{
					num2 = ((GlobalScript.inst.gameState.politics[i].traits[2] == 10) ? (num2 - 100) : ((GlobalScript.inst.gameState.politics[i].traits[2] != 12) ? (num2 + 100) : (num2 - 100)));
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 12)
				{
					num2 -= 50;
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 13)
				{
					num2 += 100;
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 14)
				{
					num2 = ((GlobalScript.inst.gameState.politics[i].traits[2] == 15) ? (num2 - 300) : ((GlobalScript.inst.gameState.politics[i].traits[2] != 14) ? (num2 + 50) : (num2 + 150)));
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 15)
				{
					if (GlobalScript.inst.gameState.politics[i].traits[2] == 15)
					{
						num2 += 200;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[2] == 14)
					{
						num2 -= 300;
					}
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 16)
				{
					if (GlobalScript.inst.gameState.politics[i].traits[2] == 9)
					{
						num2 -= 250;
					}
					else if (GlobalScript.inst.gameState.politics[i].traits[2] == 14)
					{
						num2 += 50;
					}
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 17)
				{
					num2 = ((GlobalScript.inst.gameState.politics[i].traits[2] == 8) ? (num2 - 250) : ((GlobalScript.inst.gameState.politics[i].traits[2] != 17) ? (num2 - 50) : (num2 + 300)));
				}
				else if (GlobalScript.inst.gameState.politics[num].traits[2] == 18)
				{
					num2 = ((GlobalScript.inst.gameState.politics[i].traits[2] != 11) ? (num2 + 10) : (num2 - 300));
				}
				if (GlobalScript.inst.gameState.politics_dolshnost[0] == num)
				{
					if (GlobalScript.inst.gameState.politics[i].wantedDolzh == 0)
					{
						num2 -= 400;
					}
				}
				else if (GlobalScript.inst.gameState.politics_dolshnost[1] == num || GlobalScript.inst.gameState.politics_dolshnost[2] == num)
				{
					if (GlobalScript.inst.gameState.politics_dolshnost[0] != i && (GlobalScript.inst.gameState.politics[i].wantedDolzh == 1 || GlobalScript.inst.gameState.politics[i].wantedDolzh == 2))
					{
						num2 -= 400;
					}
				}
				else if ((GlobalScript.inst.gameState.politics_dolshnost[3] == num || GlobalScript.inst.gameState.politics_dolshnost[4] == num || GlobalScript.inst.gameState.politics_dolshnost[5] == num || GlobalScript.inst.gameState.politics_dolshnost[6] == num || GlobalScript.inst.gameState.politics_dolshnost[7] == num) && GlobalScript.inst.gameState.politics_dolshnost[0] != i && GlobalScript.inst.gameState.politics_dolshnost[1] != i && GlobalScript.inst.gameState.politics_dolshnost[2] != i && GlobalScript.inst.gameState.politics[i].wantedDolzh >= 3)
				{
					num2 -= 400;
				}
				GlobalScript.inst.gameState.politics[i].loyality_to_other[num] = num2;
			}
			else
			{
				GlobalScript.inst.gameState.politics[i].loyality_to_other[i] = 1000;
			}
		}
	}

	public void CalcRel2(int num)
	{
		for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
		{
			if (i != num)
			{
				int num2 = 0;
				if (GlobalScript.inst.gameState.politics[num].traits[0] == GlobalScript.inst.gameState.politics[i].traits[0])
				{
					num2 += 500;
				}
				if (GlobalScript.inst.gameState.politics[i].traits[0] == 0)
				{
					if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
					{
						num2 += 50;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
					{
						num2 -= 150;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
					{
						num2 -= 300;
					}
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[0] == 1)
				{
					if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
					{
						num2 += 50;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
					{
						num2 -= 50;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
					{
						num2 -= 150;
					}
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[0] == 2)
				{
					if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
					{
						num2 -= 150;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
					{
						num2 += 50;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[0] == 3)
					{
						num2 += 100;
					}
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[0] == 3)
				{
					if (GlobalScript.inst.gameState.politics[num].traits[0] == 0)
					{
						num2 -= 300;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[0] == 1)
					{
						num2 -= 150;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[0] == 2)
					{
						num2 += 100;
					}
				}
				if (GlobalScript.inst.gameState.politics[i].traits[1] == 4)
				{
					num2 = ((GlobalScript.inst.gameState.politics[num].traits[1] == 5) ? (num2 - 250) : ((GlobalScript.inst.gameState.politics[num].traits[1] != 4) ? (num2 - 100) : (num2 + 100)));
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[1] == 5)
				{
					num2 = ((GlobalScript.inst.gameState.politics[num].traits[1] == 4) ? (num2 - 300) : ((GlobalScript.inst.gameState.politics[num].traits[1] != 5) ? (num2 + 100) : (num2 + 100)));
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[1] == 6 && GlobalScript.inst.gameState.politics[num].traits[1] != 6)
				{
					num2 += 100;
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[1] == 7 && GlobalScript.inst.gameState.politics[num].traits[1] == 6)
				{
					num2 += 50;
				}
				if (GlobalScript.inst.gameState.politics[i].traits[2] == 8)
				{
					if (GlobalScript.inst.gameState.politics[num].traits[2] == 9)
					{
						num2 -= 250;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[2] == 8)
					{
						num2 += 100;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[2] == 10)
					{
						num2 += 50;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[2] == 14)
					{
						num2 += 50;
					}
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 9)
				{
					if (GlobalScript.inst.gameState.politics[num].traits[2] == 16)
					{
						num2 -= 250;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[2] != 9)
					{
						num2 += 50;
					}
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 10)
				{
					num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] == 12) ? (num2 + 50) : ((GlobalScript.inst.gameState.politics[num].traits[2] != 10) ? (num2 - 100) : (num2 + 300)));
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 11)
				{
					num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] == 10) ? (num2 - 100) : ((GlobalScript.inst.gameState.politics[num].traits[2] != 12) ? (num2 + 100) : (num2 - 100)));
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 12)
				{
					num2 -= 50;
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 13)
				{
					num2 += 100;
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 14)
				{
					num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] == 15) ? (num2 - 300) : ((GlobalScript.inst.gameState.politics[num].traits[2] != 14) ? (num2 + 50) : (num2 + 150)));
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 15)
				{
					if (GlobalScript.inst.gameState.politics[num].traits[2] == 15)
					{
						num2 += 200;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[2] == 14)
					{
						num2 -= 300;
					}
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 16)
				{
					if (GlobalScript.inst.gameState.politics[num].traits[2] == 9)
					{
						num2 -= 250;
					}
					else if (GlobalScript.inst.gameState.politics[num].traits[2] == 14)
					{
						num2 += 50;
					}
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 17)
				{
					num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] == 8) ? (num2 - 250) : ((GlobalScript.inst.gameState.politics[num].traits[2] != 17) ? (num2 - 50) : (num2 + 300)));
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[2] == 18)
				{
					num2 = ((GlobalScript.inst.gameState.politics[num].traits[2] != 11) ? (num2 + 10) : (num2 - 300));
				}
				if (GlobalScript.inst.gameState.politics_dolshnost[0] == i)
				{
					if (GlobalScript.inst.gameState.politics[num].wantedDolzh == 0)
					{
						num2 -= 400;
					}
				}
				else if (GlobalScript.inst.gameState.politics_dolshnost[1] == i || GlobalScript.inst.gameState.politics_dolshnost[2] == i)
				{
					if (GlobalScript.inst.gameState.politics_dolshnost[0] != num && (GlobalScript.inst.gameState.politics[num].wantedDolzh == 1 || GlobalScript.inst.gameState.politics[num].wantedDolzh == 2))
					{
						num2 -= 400;
					}
				}
				else if ((GlobalScript.inst.gameState.politics_dolshnost[3] == i || GlobalScript.inst.gameState.politics_dolshnost[4] == i || GlobalScript.inst.gameState.politics_dolshnost[5] == i || GlobalScript.inst.gameState.politics_dolshnost[6] == i || GlobalScript.inst.gameState.politics_dolshnost[7] == i) && GlobalScript.inst.gameState.politics_dolshnost[0] != num && GlobalScript.inst.gameState.politics_dolshnost[1] != num && GlobalScript.inst.gameState.politics_dolshnost[2] != num && GlobalScript.inst.gameState.politics[num].wantedDolzh >= 3)
				{
					num2 -= 400;
				}
				GlobalScript.inst.gameState.politics[num].loyality_to_other[i] = num2;
			}
			else
			{
				GlobalScript.inst.gameState.politics[i].loyality_to_other[i] = 1000;
			}
		}
	}

	public int NumberOfPolitician(int name_1, int name_2)
	{
		for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
		{
			if (GlobalScript.inst.gameState.politics[i].name_1 == 13 && GlobalScript.inst.gameState.politics[i].name_2 == 13)
			{
				return i;
			}
		}
		return -1;
	}

	public void GeneratePolitic(Politic pol)
	{
		pol.name_1 = (byte)UnityEngine.Random.Range(4, GlobalScript.inst.gameState.names1.Length - 1);
		pol.name_2 = (byte)UnityEngine.Random.Range(16, GlobalScript.inst.gameState.names2.Length - 1);
		pol.power = UnityEngine.Random.Range(1, 100);
		pol.loyality = 0;
		pol.traits[0] = 5;
		bool[] array = new bool[4];
		for (int i = 0; i < pol.loyality_to_other.Length; i++)
		{
			pol.loyality_to_other[i] = 0;
			if (GlobalScript.inst.gameState.politics[i] != null)
			{
				if (GlobalScript.inst.gameState.politics[i].traits[0] == 0 && !array[0])
				{
					array[0] = true;
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[0] == 1 && !array[1])
				{
					array[1] = true;
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[0] == 2 && !array[2])
				{
					array[2] = true;
				}
				else if (GlobalScript.inst.gameState.politics[i].traits[0] == 3 && !array[3])
				{
					array[3] = true;
				}
			}
		}
		pol.is_sagovor = false;
		pol.is_sledstvie = false;
		pol.is_sleshka = false;
		pol.autohound = 0;
		pol.autosupport = 0;
		pol.days_sleshka = 0;
		pol.wantedDolzh = UnityEngine.Random.Range(0, 4);
		pol.age = (byte)UnityEngine.Random.Range(50, 80);
		if (pol.age < 50)
		{
			pol.age = 50;
		}
		if (GlobalScript.inst.gameState.data[15] <= 7)
		{
			float num = 0f;
			for (int j = 0; j < party_ideology.Length; j++)
			{
				num += (float)party_ideology[j];
			}
			float num2 = (float)party_ideology[0] / num * 100f;
			float num3 = (float)party_ideology[1] / num * 100f;
			float num4 = (float)party_ideology[2] / num * 100f;
			float num5 = (float)party_ideology[3] / num * 100f;
			float num6 = (float)party_ideology[4] / num * 100f;
			Debug.Log(num2.ToString());
			Debug.Log(num3.ToString());
			Debug.Log(num4.ToString());
			Debug.Log(num5.ToString());
			Debug.Log(num6.ToString());
			int num7 = UnityEngine.Random.Range(0, 100);
			if ((float)num7 <= num2)
			{
				pol.traits[0] = 0;
			}
			else if ((float)num7 > num2 && (float)num7 <= num2 + num3)
			{
				pol.traits[0] = 1;
			}
			else if ((float)num7 > num2 + num3 && (float)num7 <= num2 + num3 + num4)
			{
				pol.traits[0] = 1;
			}
			else if ((float)num7 > num2 + num3 + num4 && (float)num7 <= num2 + num3 + num4 + num5)
			{
				pol.traits[0] = 2;
			}
			else
			{
				pol.traits[0] = 3;
			}
		}
		else
		{
			int num8 = GlobalScript.inst.gameState.data[52] - 33;
			int num9 = GlobalScript.inst.gameState.data[54] - 37;
			int num10 = num8 + num9;
			num10 += UnityEngine.Random.Range(-2, 3);
			if (num10 <= 2)
			{
				pol.traits[0] = 0;
			}
			else if (num10 <= 4)
			{
				pol.traits[0] = 1;
			}
			else if (num10 <= 6)
			{
				pol.traits[0] = 2;
			}
			else
			{
				pol.traits[0] = 3;
			}
		}
		if (!array[3])
		{
			pol.traits[0] = 3;
		}
		else if (!array[2])
		{
			pol.traits[0] = 2;
		}
		else if (!array[1])
		{
			pol.traits[0] = 1;
		}
		else if (!array[0])
		{
			pol.traits[0] = 0;
		}
		pol.traits[1] = (byte)UnityEngine.Random.Range(4, 8);
		pol.traits[2] = (byte)UnityEngine.Random.Range(8, 19);
		if (gamerules[8] > 0)
		{
			if (pol.traits[1] == 7)
			{
				pol.traits[1] = 6;
			}
			if (pol.traits[2] == 11)
			{
				pol.traits[2] = 18;
			}
			else if (pol.traits[2] == 13)
			{
				pol.traits[2] = 10;
			}
		}
		if (GlobalScript.inst.gameState.data[57] < 500)
		{
			if (UnityEngine.Random.Range(0, 50) % 6 == 0)
			{
				pol.traits[2] = 16;
			}
			else if (UnityEngine.Random.Range(0, 50) % 6 == 0)
			{
				pol.traits[2] = 12;
			}
		}
		if (UnityEngine.Random.Range(0, 730) == 22)
		{
			pol.name_1 = 42;
			pol.name_2 = 46;
			pol.age = 22;
			pol.traits[0] = 1;
			pol.traits[1] = 7;
			pol.traits[2] = 11;
		}
		if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
		{
			pol.face_type = 0;
			pol.face_parts[0] = (byte)UnityEngine.Random.Range(0, 3);
			pol.face_parts[1] = (byte)UnityEngine.Random.Range(0, 6);
			pol.face_parts[2] = (byte)UnityEngine.Random.Range(0, 6);
			pol.face_parts[3] = (byte)UnityEngine.Random.Range(0, 4);
			pol.face_parts[4] = (byte)UnityEngine.Random.Range(0, 6);
			pol.face_parts[5] = (byte)UnityEngine.Random.Range(0, 3);
			pol.face_parts[6] = (byte)UnityEngine.Random.Range(0, 6);
			pol.face_parts[7] = (byte)UnityEngine.Random.Range(0, 3);
		}
		else
		{
			pol.face_type = 1;
			pol.face_parts[0] = (byte)UnityEngine.Random.Range(0, 4);
			pol.face_parts[1] = (byte)UnityEngine.Random.Range(0, 6);
			pol.face_parts[2] = (byte)UnityEngine.Random.Range(0, 6);
			pol.face_parts[3] = (byte)UnityEngine.Random.Range(0, 3);
			pol.face_parts[4] = (byte)UnityEngine.Random.Range(0, 4);
			pol.face_parts[5] = (byte)UnityEngine.Random.Range(0, 4);
			pol.face_parts[6] = (byte)UnityEngine.Random.Range(0, 5);
			pol.face_parts[7] = (byte)UnityEngine.Random.Range(0, 4);
		}
		if (pol.traits[0] == 0)
		{
			switch (UnityEngine.Random.Range(0, 3))
			{
			case 0:
				pol.jacket = 0;
				break;
			case 1:
				pol.jacket = 2;
				break;
			default:
				pol.jacket = 4;
				break;
			}
		}
		else if (pol.traits[0] == 1)
		{
			pol.jacket = (byte)UnityEngine.Random.Range(2, 5);
		}
		else if (pol.traits[0] == 2)
		{
			pol.jacket = (byte)UnityEngine.Random.Range(1, 5);
		}
		else if (pol.traits[0] == 3)
		{
			if (UnityEngine.Random.Range(0, 2) == 0)
			{
				pol.jacket = 1;
			}
			else
			{
				pol.jacket = 3;
			}
		}
	}

	public void BalancePolitic(List<byte> politics_to_generate)
	{
		if (politics_to_generate.Count() > 0)
		{
			Stack<byte> stack = new Stack<byte>();
			foreach (byte item in politics_to_generate)
			{
				Politic politic = GlobalScript.inst.gameState.politics[item];
				politic.isCitizen = false;
				politic.name_1 = byte.MaxValue;
				politic.name_2 = byte.MaxValue;
				politic.face_type = 0;
				politic.jacket = 0;
				politic.face_parts = new byte[8];
				GeneratePolitic(politic);
				stack.Push(item);
			}
			for (int i = 0; i < p_first.Length; i++)
			{
				if (p_first[i] == 200)
				{
					p_first[i] = stack.Pop();
				}
			}
			for (int j = 0; j < p_second.Length; j++)
			{
				if (p_second[j] == 200)
				{
					p_second[j] = stack.Pop();
				}
			}
			for (int k = 0; k < p_third.Length; k++)
			{
				if (p_third[k] == 200)
				{
					p_third[k] = stack.Pop();
				}
			}
			for (int l = 0; l < p_forth.Length; l++)
			{
				if (p_forth[l] == 200)
				{
					p_forth[l] = stack.Pop();
				}
			}
		}
		using (IEnumerator<int> enumerator2 = (from p in Enumerable.Range(0, 18)
			orderby GlobalScript.inst.gameState.politics[p].power descending
			select p).GetEnumerator())
		{
			for (int num = 0; num < p_first.Length; num++)
			{
				enumerator2.MoveNext();
				p_first[num] = (byte)enumerator2.Current;
			}
			for (int num2 = 0; num2 < p_second.Length; num2++)
			{
				enumerator2.MoveNext();
				p_second[num2] = (byte)enumerator2.Current;
			}
			for (int num3 = 0; num3 < p_third.Length; num3++)
			{
				enumerator2.MoveNext();
				p_third[num3] = (byte)enumerator2.Current;
			}
			for (int num4 = 0; num4 < p_forth.Length; num4++)
			{
				enumerator2.MoveNext();
				p_forth[num4] = (byte)enumerator2.Current;
			}
		}
		if (politics_to_generate.Count() <= 0)
		{
			return;
		}
		foreach (byte item2 in politics_to_generate)
		{
			CalcRel(item2);
			CalcRel2(item2);
			CalcRelLeader(item2);
		}
	}

	public bool IsFactionLeadeng(int num)
	{
		float num2 = 0f;
		if (GlobalScript.inst.gameState.data[15] > 7)
		{
			int num3 = GlobalScript.inst.gameState.party_number[1];
			int num4 = 0;
			for (int i = 0; i < GlobalScript.inst.gameState.is_party_ally.Length; i++)
			{
				if (GlobalScript.inst.gameState.is_party_ally[i] && GlobalScript.inst.gameState.is_party_enabled[i] && i != 1)
				{
					num3 += GlobalScript.inst.gameState.party_number[i];
				}
			}
			num4 = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4];
			num2 = num3 * 100 / num4;
		}
		if (num != data[56] && (!(num2 > 66f) || GlobalScript.inst.gameState.data[15] <= 7) && (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[0] <= 1))
		{
			if (GlobalScript.inst.dlc[0])
			{
				return GlobalScript.inst.gameState.gamerules[1] > 0;
			}
			return false;
		}
		return true;
	}

	public void CounterRevolution(int selected_country)
	{
		if (!allcountries[selected_country].Vyshi && !allcountries[selected_country].econ && !allcountries[selected_country].isSEV && allcountries[selected_country].Gosstroy != 3 && allcountries[selected_country].proprc && allcountries[selected_country].level_of_dev - allcountries[selected_country].level_of_unstab < 0)
		{
			allcountries[selected_country].Torg = false;
			allcountries[selected_country].proprc = false;
			allcountries[selected_country].Gosstroy = UnityEngine.Random.Range(0, 4);
			if (allcountries[selected_country].Gosstroy == 1 || allcountries[selected_country].Gosstroy == 2)
			{
				allcountries[selected_country].SubGosstroy = UnityEngine.Random.Range(1, 10);
			}
			else
			{
				allcountries[selected_country].SubGosstroy = UnityEngine.Random.Range(4, 10);
			}
			if (allcountries[selected_country].SubGosstroy > 3)
			{
				UnityEngine.Random.Range(0, 6);
			}
			else
			{
				UnityEngine.Random.Range(2, 6);
			}
			allcountries[selected_country].level_of_unstab -= 20;
		}
	}

	public void WantToLeave(int selected_country)
	{
		bool flag = true;
		if (allcountries[selected_country].SubGosstroy == 0)
		{
			if (data[14] > 2 || data[16] >= 13 || data[6] < 700 || data[15] >= 8)
			{
				flag = false;
			}
		}
		else if ((allcountries[selected_country].SubGosstroy >= 1 && allcountries[selected_country].SubGosstroy <= 3) || allcountries[selected_country].SubGosstroy == 8)
		{
			if (data[14] > 3 || data[16] > 13 || data[6] < 500)
			{
				flag = false;
			}
		}
		else if (allcountries[selected_country].SubGosstroy >= 4 && allcountries[selected_country].SubGosstroy <= 6)
		{
			if (data[14] < 2 || data[16] < 13 || data[6] > 700 || data[15] < 8 || data[17] < 18 || allcountries[1].isOVD)
			{
				flag = false;
			}
		}
		else if (allcountries[selected_country].SubGosstroy >= 7 && (data[14] == 1 || data[16] <= 11 || data[6] < 300 || allcountries[1].isSEV))
		{
			flag = false;
		}
		if (allcountries[selected_country].proprc)
		{
			allcountries[selected_country].Torg = flag;
			allcountries[selected_country].proprc = flag;
			if (allcountries[selected_country].Vyshi)
			{
				allcountries[selected_country].Vyshi = !flag;
			}
		}
	}

	public int GetSubGosstory()
	{
		if (data[14] <= 2 && data[16] < 13 && data[6] >= 700 && data[15] < 8)
		{
			return 0;
		}
		if (data[14] <= 3 && data[16] <= 13 && data[6] >= 500)
		{
			return UnityEngine.Random.Range(1, 4);
		}
		if (data[14] >= 2 && data[16] >= 13 && data[6] <= 700 && data[15] >= 8 && data[17] >= 18 && !allcountries[1].isOVD)
		{
			return UnityEngine.Random.Range(4, 7);
		}
		if (!allcountries[1].isSEV)
		{
			return 7;
		}
		return 8;
	}

	public void WhatToDevelop(int selected_country)
	{
		int num = Mathf.Abs(4 - allcountries[selected_country].SubGosstroy);
		if (allcountries[selected_country].level_of_unstab > (6 - num) * 20)
		{
			allcountries[selected_country].level_of_unstab -= allcountries[selected_country].level_of_unstab / 25;
			allcountries[selected_country].level_of_dev--;
		}
		else
		{
			allcountries[selected_country].level_of_unstab += ((6 - num) * 20 - allcountries[selected_country].level_of_unstab) / 5;
			allcountries[selected_country].level_of_dev++;
		}
		if (allcountries[selected_country].level_of_unstab > 100)
		{
			allcountries[selected_country].level_of_unstab = 100;
		}
		else if (allcountries[selected_country].level_of_unstab < 0)
		{
			allcountries[selected_country].level_of_unstab = 0;
		}
		else if (allcountries[selected_country].level_of_unstab < 10)
		{
			allcountries[selected_country].level_of_unstab++;
		}
		if (allcountries[selected_country].level_of_dev > 100)
		{
			allcountries[selected_country].level_of_dev = 100;
		}
		else if (allcountries[selected_country].level_of_dev < 0)
		{
			allcountries[selected_country].level_of_dev = 0;
		}
		else if (allcountries[selected_country].level_of_dev > 90)
		{
			allcountries[selected_country].level_of_dev--;
		}
		allcountries[selected_country].level_of_unstab -= allcountries[selected_country].Gosstroy;
	}

	public void AmericanHelp(int selected_country)
	{
		if (allcountries[selected_country].Vyshi)
		{
			allcountries[selected_country].level_of_unstab -= empires[0].power / 28;
		}
		else if (!allcountries[selected_country].proprc && !allcountries[selected_country].prosov)
		{
			allcountries[selected_country].level_of_unstab -= empires[0].power / 40;
		}
		else
		{
			allcountries[selected_country].level_of_unstab += empires[0].power / 66;
		}
	}

	public int GetWinnerInAmerica(int country, bool[] ideoParties, float[] partiesSup, float coef = 0f, int party = -1)
	{
		if (ideoParties[allcountries[country].SubGosstroy])
		{
			partiesSup[allcountries[country].SubGosstroy] -= allcountries[country].level_of_unstab;
			partiesSup[allcountries[country].SubGosstroy] += allcountries[country].level_of_dev;
		}
		if (allcountries[country].SubGosstroy - 1 >= 0 && ideoParties[allcountries[country].SubGosstroy - 1])
		{
			partiesSup[allcountries[country].SubGosstroy - 1] -= allcountries[country].level_of_unstab / 4;
			partiesSup[allcountries[country].SubGosstroy - 1] += allcountries[country].level_of_dev / 2;
		}
		if (allcountries[country].SubGosstroy + 1 <= 9 && ideoParties[allcountries[country].SubGosstroy + 1])
		{
			partiesSup[allcountries[country].SubGosstroy + 1] -= allcountries[country].level_of_unstab / 4;
			partiesSup[allcountries[country].SubGosstroy + 1] += allcountries[country].level_of_dev / 2;
		}
		if (!ideoParties[allcountries[country].SubGosstroy])
		{
			if (allcountries[country].SubGosstroy >= 1 && allcountries[country].SubGosstroy <= 3)
			{
				if (ideoParties[1])
				{
					partiesSup[1] -= allcountries[country].level_of_unstab / 4;
					partiesSup[1] += allcountries[country].level_of_dev / 2;
				}
				else if (ideoParties[2])
				{
					partiesSup[2] -= allcountries[country].level_of_unstab / 4;
					partiesSup[2] += allcountries[country].level_of_dev / 2;
				}
				else if (ideoParties[3])
				{
					partiesSup[3] -= allcountries[country].level_of_unstab / 4;
					partiesSup[3] += allcountries[country].level_of_dev / 2;
				}
			}
			else if (allcountries[country].SubGosstroy >= 4 && allcountries[country].SubGosstroy <= 6)
			{
				if (ideoParties[4])
				{
					partiesSup[4] -= allcountries[country].level_of_unstab / 4;
					partiesSup[4] += allcountries[country].level_of_dev / 2;
				}
				else if (ideoParties[5])
				{
					partiesSup[5] -= allcountries[country].level_of_unstab / 4;
					partiesSup[5] += allcountries[country].level_of_dev / 2;
				}
				else if (ideoParties[6])
				{
					partiesSup[6] -= allcountries[country].level_of_unstab / 4;
					partiesSup[6] += allcountries[country].level_of_dev / 2;
				}
			}
		}
		if (allcountries[country].SubGosstroy <= 3)
		{
			if (ideoParties[9 - allcountries[country].SubGosstroy])
			{
				partiesSup[9 - allcountries[country].SubGosstroy] += allcountries[country].level_of_unstab;
				partiesSup[9 - allcountries[country].SubGosstroy] -= allcountries[country].level_of_dev;
			}
			else if (ideoParties[5])
			{
				partiesSup[5] += allcountries[country].level_of_unstab;
				partiesSup[5] -= allcountries[country].level_of_dev;
			}
			else if (ideoParties[4])
			{
				partiesSup[4] -= allcountries[country].level_of_unstab / 2;
				partiesSup[4] += allcountries[country].level_of_dev / 2;
			}
			if (8 - allcountries[country].SubGosstroy >= 0 && ideoParties[8 - allcountries[country].SubGosstroy])
			{
				partiesSup[8 - allcountries[country].SubGosstroy] += allcountries[country].level_of_unstab / 2;
				partiesSup[8 - allcountries[country].SubGosstroy] -= allcountries[country].level_of_dev / 4;
			}
			if (10 - allcountries[country].SubGosstroy <= 9 && ideoParties[allcountries[country].SubGosstroy])
			{
				partiesSup[10 - allcountries[country].SubGosstroy] += allcountries[country].level_of_unstab / 2;
				partiesSup[10 - allcountries[country].SubGosstroy] -= allcountries[country].level_of_dev / 4;
			}
		}
		else if (allcountries[country].SubGosstroy >= 6)
		{
			if (ideoParties[9 - allcountries[country].SubGosstroy])
			{
				partiesSup[9 - allcountries[country].SubGosstroy] += allcountries[country].level_of_unstab;
				partiesSup[9 - allcountries[country].SubGosstroy] -= allcountries[country].level_of_dev;
			}
			else if (ideoParties[4])
			{
				partiesSup[4] += allcountries[country].level_of_unstab;
				partiesSup[4] -= allcountries[country].level_of_dev;
			}
			else if (ideoParties[5])
			{
				partiesSup[5] -= allcountries[country].level_of_unstab / 2;
				partiesSup[5] += allcountries[country].level_of_dev / 2;
			}
			if (8 - allcountries[country].SubGosstroy >= 0 && ideoParties[8 - allcountries[country].SubGosstroy])
			{
				partiesSup[8 - allcountries[country].SubGosstroy] += allcountries[country].level_of_unstab / 2;
				partiesSup[8 - allcountries[country].SubGosstroy] -= allcountries[country].level_of_dev / 4;
			}
			if (10 - allcountries[country].SubGosstroy <= 9 && ideoParties[10 - allcountries[country].SubGosstroy])
			{
				partiesSup[10 - allcountries[country].SubGosstroy] += allcountries[country].level_of_unstab / 2;
				partiesSup[10 - allcountries[country].SubGosstroy] -= allcountries[country].level_of_dev / 4;
			}
		}
		else if (allcountries[country].SubGosstroy == 4)
		{
			if (ideoParties[0])
			{
				partiesSup[0] += allcountries[country].level_of_unstab / 2;
				partiesSup[0] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[1])
			{
				partiesSup[1] += allcountries[country].level_of_unstab / 2;
				partiesSup[1] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[2])
			{
				partiesSup[2] += allcountries[country].level_of_unstab / 2;
				partiesSup[2] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[6])
			{
				partiesSup[6] += allcountries[country].level_of_unstab / 2;
				partiesSup[6] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[7])
			{
				partiesSup[7] += allcountries[country].level_of_unstab / 2;
				partiesSup[7] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[8])
			{
				partiesSup[8] += allcountries[country].level_of_unstab / 2;
				partiesSup[8] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[9])
			{
				partiesSup[9] += allcountries[country].level_of_unstab / 2;
				partiesSup[9] -= allcountries[country].level_of_dev / 4;
			}
		}
		else if (allcountries[country].SubGosstroy == 5)
		{
			if (ideoParties[0])
			{
				partiesSup[0] += allcountries[country].level_of_unstab / 2;
				partiesSup[0] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[1])
			{
				partiesSup[1] += allcountries[country].level_of_unstab / 2;
				partiesSup[1] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[2])
			{
				partiesSup[2] += allcountries[country].level_of_unstab / 2;
				partiesSup[2] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[3])
			{
				partiesSup[6] += allcountries[country].level_of_unstab / 2;
				partiesSup[6] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[7])
			{
				partiesSup[7] += allcountries[country].level_of_unstab / 2;
				partiesSup[7] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[8])
			{
				partiesSup[8] += allcountries[country].level_of_unstab / 2;
				partiesSup[8] -= allcountries[country].level_of_dev / 4;
			}
			if (ideoParties[9])
			{
				partiesSup[9] += allcountries[country].level_of_unstab / 2;
				partiesSup[9] -= allcountries[country].level_of_dev / 4;
			}
		}
		if (coef > 0f)
		{
			coef *= 3f;
			if (partiesSup[party] > 1f)
			{
				partiesSup[party] *= coef;
			}
			else
			{
				partiesSup[party] += coef;
			}
		}
		for (int i = 0; i < partiesSup.Length; i++)
		{
			if (ideoParties[i])
			{
				partiesSup[i] += 100f;
			}
			Debug.Log(i + "." + partiesSup[i]);
		}
		return Array.IndexOf(partiesSup, partiesSup.Max());
	}

	public int AddCells<T>(int cells, ref T[] wars)
	{
		int num = wars.Length + cells;
		Array.Resize(ref wars, num);
		return num;
	}

	public void SetCells<T>(int cells, ref T[] wars)
	{
		Array.Resize(ref wars, cells);
	}

	public void DeleteArrayElement(int num, ref int[] massive)
	{
		int num2 = FindIndexArray(num, ref massive);
		if (num2 >= 0)
		{
			massive[num2] = massive[massive.Length - 1];
			Array.Resize(ref massive, massive.Length - 1);
		}
	}

	public void AddArrayElement(int num, ref int[] massive)
	{
		Array.Resize(ref massive, massive.Length + 1);
		massive[massive.Length - 1] = num;
	}

	public int FindIndexArray(int num, ref int[] massive)
	{
		for (int i = 0; i < massive.Length; i++)
		{
			if (massive[i] == num)
			{
				return i;
			}
		}
		return -1;
	}

	public bool ContaintsRange<T>(T[] array, Func<T, bool> func1)
	{
		foreach (T arg in array)
		{
			if (func1(arg))
			{
				return true;
			}
		}
		return false;
	}
}
