using EventsForDLC;
using UnityEngine;

public class Event352 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[417];
		text = string.Format(GlobalScript.inst.new_events_text[418]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 30)
		{
			button_text[0] = GlobalScript.inst.new_events_text[419];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[420]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50)
		{
			button_text[1] = GlobalScript.inst.new_events_text[421];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[420]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 70)
		{
			button_text[2] = GlobalScript.inst.new_events_text[422];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[420]);
		}
		button_text[3] = GlobalScript.inst.new_events_text[423];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[404];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[424];
			GlobalScript.inst.gameState.data[8] -= 20;
			GlobalScript.inst.gameState.data[11] += 100;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[425];
			GlobalScript.inst.gameState.data[8] -= 40;
			GlobalScript.inst.gameState.data[22] += 100;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[426];
			GlobalScript.inst.gameState.data[11] += 100;
			GlobalScript.inst.gameState.data[22] += 100;
			GlobalScript.inst.gameState.data[8] -= 60;
			break;
		case 3:
			text = GlobalScript.inst.new_events_text[427];
			break;
		}
	}
}
