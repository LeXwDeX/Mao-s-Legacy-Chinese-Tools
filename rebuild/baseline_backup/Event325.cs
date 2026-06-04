using EventsForDLC;
using UnityEngine;

public class Event325 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[223];
		text = string.Format(GlobalScript.inst.new_events_text[224]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[225];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40 && GlobalScript.inst.gameState.data[12] > 60)
		{
			button_text[1] = GlobalScript.inst.new_events_text[226];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[227]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 110 && GlobalScript.inst.gameState.data[12] > 80)
		{
			button_text[2] = GlobalScript.inst.new_events_text[228];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[229]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[223];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[230];
			GlobalScript.inst.gameState.data[1] -= 150;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[231];
			GlobalScript.inst.gameState.data[8] -= 30;
			GlobalScript.inst.gameState.data[1] += 50;
			GlobalScript.inst.gameState.data[7] += 5;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[232];
			GlobalScript.inst.gameState.data[1] += 50;
			GlobalScript.inst.gameState.data[7] += 5;
			GlobalScript.inst.gameState.data[8] -= 100;
			GlobalScript.inst.gameState.modifies[35].active = true;
			break;
		}
	}
}
