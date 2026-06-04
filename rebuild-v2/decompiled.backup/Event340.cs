using EventsForDLC;
using UnityEngine;

public class Event340 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[340];
		text = string.Format(GlobalScript.inst.new_events_text[341]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[342];
		button_text[1] = GlobalScript.inst.new_events_text[343];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[340];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[344];
			GlobalScript.inst.gameState.data[3] += 30;
			GlobalScript.inst.gameState.data[4] += 30;
			GlobalScript.inst.gameState.data[13] -= 30;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[345];
			break;
		}
	}
}
