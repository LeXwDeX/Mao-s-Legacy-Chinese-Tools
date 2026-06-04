using EventsForDLC;
using UnityEngine;

public class Event406 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1198];
		text = string.Format(GlobalScript.inst.new_events_text[1199], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1192];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1198];
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		if (GlobalScript.inst.gameState.empires[0].now_leader == 1)
		{
			num++;
		}
		if (a.data[65] > 0)
		{
			flag2 = true;
		}
		if (GlobalScript.inst.gameState.BritLost)
		{
			flag = true;
		}
		if (a.resultOfEvents[46] != 2 && a.resultOfEvents[67] != 3 && !a.ingamewars[5].is_going)
		{
			num++;
		}
		int num2 = 0;
		if (a.allcountries[21].Gosstroy == 2 || a.allcountries[21].Gosstroy == 1)
		{
			num2++;
		}
		if (a.allcountries[85].Gosstroy == 2 || a.allcountries[85].Gosstroy == 1)
		{
			num2++;
		}
		if (a.allcountries[86].Gosstroy == 2 || a.allcountries[86].Gosstroy == 1)
		{
			num2++;
		}
		if (a.allcountries[87].Gosstroy == 2 || a.allcountries[87].Gosstroy == 1)
		{
			num2++;
		}
		if (a.allcountries[85].Gosstroy == 0)
		{
			num2++;
		}
		if (a.allcountries[86].Gosstroy == 0)
		{
			num2++;
		}
		if (a.allcountries[87].Gosstroy == 0)
		{
			num2++;
		}
		if (num2 > 1)
		{
			num++;
		}
		a.modifies[57].active = false;
		if (flag && num >= 3 && flag2 && a.allcountries[92].based)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1200], "\n");
			a.allcountries[92].Gosstroy = 1;
			a.allcountries[92].SubGosstroy = 18;
			a.allcountries[92].LeaveAlliances();
			a.allcountries[92].EstablishGovernment(Government.ProNeuthral);
			a.data[147] = 1;
			a.empires[0].power -= 80;
		}
		else if (a.allcountries[92].based && flag && flag2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1287], "\n");
			a.allcountries[92].Gosstroy = 3;
			a.allcountries[92].SubGosstroy = 5;
			a.data[147] = 2;
		}
		else if (flag && flag2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1201], "\n", a.allcountries[86].isSocEU ? GlobalScript.inst.new_events_text[1453] : null);
			a.allcountries[92].Gosstroy = 2;
			a.allcountries[92].SubGosstroy = 3;
			a.allcountries[92].isEU = false;
			a.empires[0].power -= 50;
			a.allcountries[92].EstablishGovernment(Government.ProNeuthral);
			a.data[147] = 3;
			if (a.allcountries[86].isSocEU)
			{
				a.allcountries[92].isSocEU = true;
				a.allcountries[92].isNATO = false;
			}
		}
		else if (flag || flag2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1202], "\n");
			a.allcountries[92].Gosstroy = 2;
			a.allcountries[92].SubGosstroy = 8;
			a.data[147] = 4;
			a.empires[0].power -= 20;
			a.allcountries[92].EstablishGovernment(Government.ProNeuthral);
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1203], "\n");
			a.data[147] = 5;
			a.empires[0].power += 50;
		}
	}
}
