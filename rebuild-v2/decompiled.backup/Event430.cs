using EventsForDLC;
using UnityEngine;

public class Event430 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1438];
		text = string.Format(GlobalScript.inst.new_events_text[1439], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[1440];
		button_text[1] = GlobalScript.inst.new_events_text[1441];
		button_text[2] = GlobalScript.inst.new_events_text[1442];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_events_text[1438];
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		bool flag3 = false;
		if (!a.allcountries[45].isNATO && !a.allcountries[45].isEU && !a.allcountries[45].econ && !a.allcountries[45].isSEV)
		{
			flag = true;
		}
		if (a.allcountries[84].Gosstroy == 2 && !a.allcountries[84].isASEAN && !a.allcountries[84].isNATO && !a.allcountries[84].okb && !a.allcountries[84].isSEV)
		{
			flag2 = true;
		}
		if (flag && flag2)
		{
			num = 1443;
		}
		else if (flag)
		{
			num = 1444;
		}
		else if (flag2)
		{
			num = 1445;
		}
		if (a.allcountries[21].isNATO || a.allcountries[86].isNATO || a.allcountries[85].isNATO)
		{
			flag3 = true;
		}
		if (GlobalScript.inst.gameState.iron_and_blood)
		{
			gameObject.GetComponent<achievements>().Set(127);
		}
		a.allcountries[21].LeaveAlliances();
		a.allcountries[86].LeaveAlliances();
		a.allcountries[85].LeaveAlliances();
		a.allcountries[85].isSocEU = true;
		a.allcountries[21].isSocEU = true;
		a.allcountries[86].isSocEU = true;
		if (flag)
		{
			a.allcountries[45].isSocEU = true;
		}
		if (flag2)
		{
			a.allcountries[84].isSocEU = true;
		}
		a.empires[0].power -= 100;
		text = string.Format(GlobalScript.inst.new_events_text[1447 + result_num], "\n", (num > 0) ? GlobalScript.inst.new_events_text[num] : null, flag3 ? GlobalScript.inst.new_events_text[1446] : null);
		switch (result_num)
		{
		case 0:
		{
			a.empires[0].relations -= 500;
			for (int i = 0; i < a.allcountries.Length; i++)
			{
				if (a.allcountries[i].isSocEU)
				{
					a.allcountries[i].Torg = true;
				}
			}
			break;
		}
		case 1:
			a.empires[0].relations += 300;
			break;
		}
	}
}
