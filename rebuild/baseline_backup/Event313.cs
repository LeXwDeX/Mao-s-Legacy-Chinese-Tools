using EventsForDLC;
using UnityEngine;

public class Event313 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[116];
		text = string.Format(GlobalScript.inst.new_events_text[117]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[118];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50)
		{
			button_text[1] = GlobalScript.inst.new_events_text[119];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[120]);
		}
		if (GlobalScript.inst.gameState.data[7] > 10)
		{
			button_text[2] = GlobalScript.inst.new_events_text[121];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[122]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[116];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[123];
			GlobalScript.inst.gameState.data[1] += 150;
			GlobalScript.inst.gameState.data[11] -= 200;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[124];
			GlobalScript.inst.gameState.data[8] -= 30;
			GlobalScript.inst.gameState.data[3] += 20;
			GlobalScript.inst.gameState.data[1] += 150;
			GlobalScript.inst.gameState.data[26] -= 5;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[125];
			GlobalScript.inst.gameState.data[8] -= 70;
			GlobalScript.inst.gameState.data[11] += 300;
			GlobalScript.inst.gameState.data[3] += 20;
			GlobalScript.inst.gameState.data[1] += 150;
			GlobalScript.inst.gameState.data[26] -= 5;
			break;
		}
	}
}
