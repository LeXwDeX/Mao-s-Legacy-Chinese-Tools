using EventsForDLC;
using UnityEngine;

public class Event315 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[134];
		text = string.Format(GlobalScript.inst.new_events_text[135]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[136];
		button_text[1] = GlobalScript.inst.new_events_text[137];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[134];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[138];
			GlobalScript.inst.gameState.data[1] += 5;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[139];
			GlobalScript.inst.gameState.data[5] -= 300;
			GlobalScript.inst.gameState.data[8] += 50;
			GlobalScript.inst.gameState.data[13] += 25;
			GlobalScript.inst.gameState.data[12] += 25;
			break;
		}
	}
}
