using EventsForDLC;
using UnityEngine;

public class Event356 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[455];
		text = string.Format(GlobalScript.inst.new_events_text[456]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40)
		{
			button_text[0] = GlobalScript.inst.new_events_text[457];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[458]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 70 && GlobalScript.inst.gameState.data[9] >= 20 && (GlobalScript.inst.gameState.resultOfEvents[353] == 0 || GlobalScript.inst.gameState.resultOfEvents[353] == 1))
		{
			button_text[1] = GlobalScript.inst.new_events_text[459];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[460]);
		}
		button_text[2] = GlobalScript.inst.new_events_text[461];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[455];
		if (result_num == 0)
		{
			text = GlobalScript.inst.new_events_text[462];
			GlobalScript.inst.gameState.data[8] -= 30;
			GlobalScript.inst.gameState.data[6] += 10;
		}
		switch (result_num)
		{
		case 1:
			text = GlobalScript.inst.new_events_text[463];
			GlobalScript.inst.gameState.data[8] -= 60;
			GlobalScript.inst.gameState.data[11] += 200;
			GlobalScript.inst.gameState.empires[1].relations -= 25;
			GlobalScript.inst.gameState.data[6] += 40;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[464];
			break;
		}
	}
}
