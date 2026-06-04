using EventsForDLC;
using UnityEngine;

public class Event318 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[152];
		text = string.Format(GlobalScript.inst.new_events_text[153]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[154];
		if (GlobalScript.inst.gameState.allcountries[44].Gosstroy < 3)
		{
			button_text[1] = GlobalScript.inst.new_events_text[155];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[142]);
		}
		if (GlobalScript.inst.gameState.data[31] >= 700 || (GlobalScript.inst.gameState.data[14] <= 0 && GlobalScript.inst.gameState.data[50] > 27 && GlobalScript.inst.gameState.data[16] > 11))
		{
			button_text[2] = GlobalScript.inst.new_events_text[156];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[142]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[152];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[157];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[158];
			GlobalScript.inst.gameState.data[6] += 100;
			GlobalScript.inst.gameState.data[7] += 100;
			GlobalScript.inst.gameState.empires[0].power -= 100;
			GlobalScript.inst.gameState.empires[0].relations -= 500;
			GlobalScript.inst.gameState.allcountries[44].Gosstroy = 1;
			GlobalScript.inst.gameState.allcountries[44].SubGosstroy = 1;
			GlobalScript.inst.gameState.allcountries[44].name = GlobalScript.inst.new_events_text[815];
			GlobalScript.inst.gameState.allcountries[44].proprc = true;
			GlobalScript.inst.gameState.allcountries[44].Vyshi = false;
			GlobalScript.inst.gameState.data[8] -= 150;
			GlobalScript.inst.gameState.data[9] -= 150;
			GlobalScript.inst.gameState.data[22] -= 150;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[159];
			GlobalScript.inst.gameState.data[6] += 50;
			GlobalScript.inst.gameState.data[7] += 100;
			GlobalScript.inst.gameState.empires[0].power -= 100;
			GlobalScript.inst.gameState.empires[0].relations -= 500;
			GlobalScript.inst.gameState.allcountries[44].Gosstroy = 0;
			GlobalScript.inst.gameState.allcountries[44].SubGosstroy = 9;
			GlobalScript.inst.gameState.allcountries[44].name = GlobalScript.inst.new_events_text[814];
			GlobalScript.inst.gameState.allcountries[44].proprc = true;
			GlobalScript.inst.gameState.allcountries[44].Vyshi = false;
			GlobalScript.inst.gameState.data[8] -= 150;
			GlobalScript.inst.gameState.data[9] -= 150;
			GlobalScript.inst.gameState.data[22] -= 150;
			break;
		}
	}
}
