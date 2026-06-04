using EventsForDLC;
using UnityEngine;

public class Event364 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[523];
		text = string.Format(GlobalScript.inst.new_events_text[524]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50)
		{
			button_text[0] = GlobalScript.inst.new_events_text[525];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[526]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 100)
		{
			button_text[1] = GlobalScript.inst.new_events_text[527];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[528]);
		}
		button_text[2] = GlobalScript.inst.new_events_text[529];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[523];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[530];
			GlobalScript.inst.gameState.data[11] += 25;
			GlobalScript.inst.gameState.data[8] -= 50;
			GlobalScript.inst.gameState.data[143] += 5;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[531];
			GlobalScript.inst.gameState.data[11] += 100;
			GlobalScript.inst.gameState.data[8] -= 100;
			GlobalScript.inst.gameState.data[6] += 50;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[532];
			break;
		}
	}
}
