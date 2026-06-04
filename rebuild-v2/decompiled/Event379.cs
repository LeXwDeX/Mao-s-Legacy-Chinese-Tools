using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event379 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[855];
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.iron_and_blood)
		{
			gameObject.GetComponent<achievements>().Set(138);
		}
		text = string.Format(GlobalScript.inst.new_events_text[856], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[857];
		button_text[1] = GlobalScript.inst.new_events_text[858];
		if ((a.allcountries[2].proprc || !a.allcountries[4].prosov || a.allcountries[5].proprc || a.allcountries[3].dev > 0) && a.data[22] >= 400 && a.data[8] + a.data[36] >= 200 && a.data[9] >= 150)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[859], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], 20f);
		}
		else if (a.data[9] < 150)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[776], 40f);
		}
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[855];
		a.data[1] -= 600;
		if (a.allcountries[9].proprc)
		{
			a.allcountries[9].proprc = false;
			a.allcountries[9].isNATO = true;
			a.allcountries[9].okb = false;
			a.allcountries[9].econ = false;
		}
		switch (result_num)
		{
		case 0:
		{
			text = string.Format(GlobalScript.inst.new_events_text[860], "\n", (a.allcountries[15].SubGosstroy == 0 && !a.allcountries[15].isSEV && (a.allcountries[1].Gosstroy == 1 || a.allcountries[1].SubGosstroy == 0)) ? GlobalScript.inst.new_events_text[880] : null);
			for (int i = 0; i < 18; i++)
			{
				if (a.allcountries[i].proprc)
				{
					a.data[7] -= 80;
				}
				if (a.allcountries[i].isOVD)
				{
					a.allcountries[i].LeaveWP().EstablishGovernment(Government.ProSoviet).JoinNATO();
					a.allcountries[i].Gosstroy = a.allcountries[7].Gosstroy;
					a.allcountries[i].SubGosstroy = a.allcountries[7].SubGosstroy;
				}
			}
			for (int j = 0; j < a.allcountries.Length; j++)
			{
				if (a.allcountries[j].Vyshi || a.allcountries[j].isNATO)
				{
					a.allcountries[j].Torg = false;
				}
			}
			a.empires[0].power += 150;
			a.empires[1].power += 150;
			a.empires[0].relations -= 600;
			a.empires[1].relations -= 600;
			if (a.allcountries[15].SubGosstroy == 0 && !a.allcountries[15].isSEV && (a.allcountries[1].Gosstroy == 1 || a.allcountries[1].SubGosstroy == 0))
			{
				a.allcountries[15].proprc = true;
			}
			return;
		}
		case 1:
		{
			text = string.Format(GlobalScript.inst.new_events_text[861], "\n", (a.allcountries[15].SubGosstroy == 0 && !a.allcountries[15].isSEV && (a.allcountries[1].Gosstroy == 1 || a.allcountries[1].SubGosstroy == 0)) ? GlobalScript.inst.new_events_text[880] : null);
			for (int k = 0; k < 18; k++)
			{
				if (a.allcountries[k].proprc)
				{
					a.data[7] -= 80;
				}
				if (a.allcountries[k].isOVD)
				{
					a.allcountries[k].LeaveWP().EstablishGovernment(Government.ProSoviet).JoinNATO();
					a.allcountries[k].Gosstroy = a.allcountries[7].Gosstroy;
					a.allcountries[k].SubGosstroy = a.allcountries[7].SubGosstroy;
				}
			}
			for (int l = 0; l < a.allcountries.Length; l++)
			{
				if (a.allcountries[l].Vyshi || a.allcountries[l].isNATO)
				{
					a.allcountries[l].Torg = false;
				}
			}
			a.empires[0].power += 150;
			a.empires[1].power += 150;
			a.empires[0].relations -= 700;
			a.empires[1].relations -= 700;
			if (a.allcountries[15].SubGosstroy == 0 && !a.allcountries[15].isSEV && (a.allcountries[1].Gosstroy == 1 || a.allcountries[1].SubGosstroy == 0))
			{
				a.allcountries[15].proprc = true;
			}
			return;
		}
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		string text2 = "";
		for (int m = 0; m < a.allcountries.Length; m++)
		{
			if (a.allcountries[m].okb)
			{
				num++;
			}
		}
		a.relres = false;
		a.allcountries[51].Torg = false;
		a.allcountries[51].dev = 0;
		if (a.allcountries[2].proprc)
		{
			num2++;
			num3++;
			num4 = 1;
		}
		if (!a.allcountries[4].prosov)
		{
			num2++;
			num3++;
			num6 = 1;
		}
		if (a.allcountries[5].proprc)
		{
			num2++;
			num3++;
			num5 = 1;
		}
		if (a.allcountries[20].proprc)
		{
			num2++;
		}
		if (a.allcountries[3].dev > 0)
		{
			num2++;
			num3++;
		}
		a.empires[0].relations -= 700;
		a.empires[1].relations -= 700;
		Debug.Log(num2);
		int num7 = 0;
		if (num2 == 5 && num > 10 && a.allcountries[30].oar && !a.allcountries[30].prosov && a.allcountries[15].SubGosstroy == 0 && !a.allcountries[15].isSEV && (a.allcountries[1].Gosstroy == 1 || a.allcountries[1].SubGosstroy == 0))
		{
			a.ingamewars[17] = new War().Name(GlobalScript.inst.new_events_text[864]).Attacker(GlobalScript.inst.new_events_text[865]).Defender(GlobalScript.inst.new_events_text[866])
				.AttackerInfluence(60 * num2)
				.DefenderInfluence(1000 - 60 * num2)
				.TickTime(20)
				.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			for (int n = 0; n < 18; n++)
			{
				if (a.allcountries[n].isOVD && (n != 2 || num4 <= 0) && (n != 5 || num5 <= 0) && (n != 4 || num6 <= 0))
				{
					a.allcountries[n].LeaveWP().EstablishGovernment(Government.ProSoviet).JoinNATO();
					a.allcountries[n].Gosstroy = a.allcountries[7].Gosstroy;
					a.allcountries[n].SubGosstroy = a.allcountries[7].SubGosstroy;
				}
			}
			for (int num8 = 0; num8 < a.allcountries.Length; num8++)
			{
				if (a.allcountries[num8].Vyshi || a.allcountries[num8].isNATO)
				{
					a.allcountries[num8].Torg = false;
				}
			}
			if (a.allcountries[2].proprc)
			{
				a.allcountries[2].LeaveNATO();
				a.allcountries[2].isSEV = false;
				a.allcountries[2].Torg = true;
				text2 += GlobalScript.inst.new_events_text[872];
				text2 += "\n";
			}
			if (!a.allcountries[4].prosov)
			{
				a.allcountries[4].LeaveNATO();
				a.allcountries[4].isSEV = false;
				a.allcountries[4].Torg = true;
				text2 += GlobalScript.inst.new_events_text[873];
				text2 += "\n";
			}
			if (a.allcountries[5].proprc)
			{
				a.allcountries[5].LeaveNATO();
				a.allcountries[5].Torg = true;
				a.allcountries[5].isSEV = false;
				text2 += GlobalScript.inst.new_events_text[874];
				text2 += "\n";
			}
			if (a.allcountries[3].dev > 0)
			{
				a.allcountries[3].parts[0] = true;
				a.allcountries[98].Torg = true;
				a.allcountries[3].name = GlobalScript.inst.new_events_text[879];
				a.allcountries[98].isOVD = true;
				text2 += GlobalScript.inst.new_events_text[875];
				text2 += "\n";
			}
			a.allcountries[15].proprc = true;
			text = string.Format(GlobalScript.inst.new_events_text[862], "\n", num3, text2);
			return;
		}
		if (num2 >= 5)
		{
			num7++;
		}
		if (num > 10)
		{
			num7++;
		}
		if (a.allcountries[30].oar && !a.allcountries[30].prosov)
		{
			num7++;
		}
		if (a.allcountries[15].SubGosstroy == 0 && !a.allcountries[15].isSEV)
		{
			num7++;
		}
		if (a.allcountries[1].Gosstroy == 1 || a.allcountries[1].SubGosstroy == 0)
		{
			num7++;
		}
		if (a.allcountries[2].proprc)
		{
			text2 += GlobalScript.inst.new_events_text[876];
			text2 += "\n";
		}
		a.relres = false;
		a.allcountries[51].Torg = false;
		a.allcountries[51].dev = 0;
		if (!a.allcountries[4].prosov)
		{
			text2 += GlobalScript.inst.new_events_text[877];
			text2 += "\n";
		}
		if (a.allcountries[5].proprc)
		{
			text2 += GlobalScript.inst.new_events_text[878];
			text2 += "\n";
		}
		for (int num9 = 0; num9 < 18; num9++)
		{
			if (a.allcountries[num9].proprc)
			{
				a.data[7] -= 80;
			}
			if (a.allcountries[num9].isOVD)
			{
				a.allcountries[num9].LeaveWP().EstablishGovernment(Government.ProSoviet).JoinNATO();
				a.allcountries[num9].Gosstroy = a.allcountries[7].Gosstroy;
				a.allcountries[num9].SubGosstroy = a.allcountries[7].SubGosstroy;
			}
		}
		for (int num10 = 0; num10 < a.allcountries.Length; num10++)
		{
			if (a.allcountries[num10].Vyshi || a.allcountries[num10].isNATO)
			{
				a.allcountries[num10].Torg = false;
			}
		}
		if (a.allcountries[15].SubGosstroy == 0 && !a.allcountries[15].isSEV && (a.allcountries[1].Gosstroy == 1 || a.allcountries[1].SubGosstroy == 0))
		{
			a.allcountries[15].proprc = true;
		}
		text = string.Format(GlobalScript.inst.new_events_text[863], "\n", num3, text2, (a.allcountries[15].SubGosstroy == 0 && !a.allcountries[15].isSEV && (a.allcountries[1].Gosstroy == 1 || a.allcountries[1].SubGosstroy == 0)) ? GlobalScript.inst.new_events_text[880] : null, num7);
	}
}
