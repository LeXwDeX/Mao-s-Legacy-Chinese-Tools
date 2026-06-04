using EventsForDLC;
using UnityEngine;

public class Event301 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[30];
		text = string.Format(GlobalScript.inst.new_events_text[31]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[32];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50 && GlobalScript.inst.gameState.data[12] >= 500)
		{
			button_text[1] = GlobalScript.inst.new_events_text[33];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[34], 25);
		}
		if (GlobalScript.inst.gameState.data[28] >= 700 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 80)
		{
			button_text[2] = GlobalScript.inst.new_events_text[35];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[36]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[30];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[37];
			GlobalScript.inst.gameState.data[1] -= 300;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[38];
			GlobalScript.inst.gameState.data[8] -= 30;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[39];
			GlobalScript.inst.gameState.data[8] -= 60;
			GlobalScript.inst.gameState.empires[0].relations += 120;
			GlobalScript.inst.gameState.empires[1].relations -= 200;
			break;
		}
	}
}
