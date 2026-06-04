using EventsForDLC;
using UnityEngine;

public class Event300 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[18];
		text = string.Format(GlobalScript.inst.new_events_text[19]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_events_text[20];
		if (!GlobalScript.inst.gameState.IsFactionLeadeng(0) && GlobalScript.inst.gameState.empires[0].relations >= 800)
		{
			button_text[1] = GlobalScript.inst.new_events_text[21];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[22], 25);
		}
		button_text[2] = GlobalScript.inst.new_events_text[23];
		if (GlobalScript.inst.gameState.IsFactionLeadeng(0))
		{
			button_text[3] = GlobalScript.inst.new_events_text[24];
			return;
		}
		button[3].SetActive(value: false);
		button_text[3] = string.Format(GlobalScript.inst.new_events_text[25]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[18];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[26];
			GlobalScript.inst.gameState.war = 0;
			GlobalScript.inst.gameState.data[39] = 5;
			GlobalScript.inst.gameState.allcountries[11].isOVD = true;
			GlobalScript.inst.gameState.allcountries[11].isSEV = true;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[27];
			GlobalScript.inst.gameState.empires[1].relations -= 200;
			GlobalScript.inst.gameState.war = 0;
			GlobalScript.inst.gameState.data[39] = 1000;
			GlobalScript.inst.gameState.allcountries[11].isSEV = true;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[28];
			break;
		case 3:
			text = GlobalScript.inst.new_events_text[29];
			GlobalScript.inst.gameState.data[39] = 1000;
			GlobalScript.inst.gameState.empires[0].relations = 0;
			GlobalScript.inst.gameState.empires[1].relations = -250;
			GlobalScript.inst.gameState.data[22] -= 200;
			GlobalScript.inst.gameState.data[31] += 50;
			GlobalScript.inst.gameState.data[57] -= 100;
			GlobalScript.inst.gameState.data[6] += 500;
			break;
		}
	}
}
