using EventsForDLC;
using UnityEngine;

public class Event329 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[258];
		text = string.Format(GlobalScript.inst.new_events_text[259]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[260];
		button_text[1] = GlobalScript.inst.new_events_text[261];
		button_text[2] = GlobalScript.inst.new_events_text[262];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[258];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[263];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[264];
			GlobalScript.inst.gameState.data[3] += 70;
			GlobalScript.inst.gameState.data[8] += 150;
			GlobalScript.inst.gameState.data[12] += 70;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[265];
			GlobalScript.inst.gameState.data[3] -= 30;
			GlobalScript.inst.gameState.data[4] += 150;
			break;
		}
	}
}
