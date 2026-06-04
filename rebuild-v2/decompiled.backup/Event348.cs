using EventsForDLC;
using UnityEngine;

public class Event348 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[388];
		text = string.Format(GlobalScript.inst.new_events_text[389]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 80 && GlobalScript.inst.gameState.data[12] >= 500)
		{
			button_text[0] = GlobalScript.inst.new_events_text[390];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[391], 25);
		}
		button_text[1] = GlobalScript.inst.new_events_text[392];
		button_text[2] = GlobalScript.inst.new_events_text[393];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[388];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[394];
			GlobalScript.inst.gameState.data[8] -= 70;
			GlobalScript.inst.gameState.data[22] += 100;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[395];
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[396];
			GlobalScript.inst.gameState.data[3] += 30;
			GlobalScript.inst.gameState.data[4] += 10;
			break;
		}
	}
}
