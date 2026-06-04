using EventsForDLC;
using UnityEngine;

public class Event323 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[203];
		text = string.Format(GlobalScript.inst.new_events_text[204]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[205];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 70 && GlobalScript.inst.gameState.data[16] > 13)
		{
			button_text[1] = GlobalScript.inst.new_events_text[206];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[207]);
		}
		if (GlobalScript.inst.gameState.data[6] >= 700 && GlobalScript.inst.gameState.data[16] > 13 && GlobalScript.inst.gameState.IsFactionLeadeng(4))
		{
			button_text[2] = GlobalScript.inst.new_events_text[208];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[209]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[203];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[210];
			GlobalScript.inst.gameState.data[1] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[211];
			GlobalScript.inst.gameState.data[8] += 25;
			GlobalScript.inst.gameState.data[11] += 50;
			GlobalScript.inst.gameState.data[4] += 50;
			GlobalScript.inst.gameState.data[5] -= 15;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[212];
			GlobalScript.inst.gameState.data[8] += 80;
			GlobalScript.inst.gameState.data[11] += 200;
			GlobalScript.inst.gameState.data[4] += 200;
			GlobalScript.inst.gameState.data[5] -= 250;
			break;
		}
	}
}
