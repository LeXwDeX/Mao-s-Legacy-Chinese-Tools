using EventsForDLC;
using UnityEngine;

public class Event394 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1092];
		if (a.allcountries[85].inflCh == 5 || a.allcountries[85].inflNATO == 5)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1093], "\n");
		}
		else if (a.allcountries[85].inflNATO == 2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1094], "\n");
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1095], "\n");
		}
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1090];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_events_text[1092];
		if (a.allcountries[85].inflCh == 5 || a.allcountries[85].inflNATO == 5)
		{
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(122);
			}
			text = string.Format(GlobalScript.inst.new_events_text[1096], "\n");
			a.allcountries[85].isNATO = false;
			a.allcountries[85].SubGosstroy = 5;
			a.allcountries[85].Vyshi = false;
			a.empires[0].power -= 20;
		}
		else if (a.allcountries[85].inflNATO == 2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1097], "\n");
			a.empires[0].power -= 10;
			a.empires[1].power += 10;
			a.allcountries[85].Vyshi = false;
			a.allcountries[85].isEU = false;
			a.allcountries[85].Gosstroy = 2;
			a.allcountries[87].spec -= 10;
			a.allcountries[85].SubGosstroy = 14;
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1098], "\n");
			a.empires[0].power += 25;
		}
	}
}
