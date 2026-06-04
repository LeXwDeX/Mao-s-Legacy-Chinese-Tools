using EventsForDLC;
using UnityEngine;

public class Event332 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[282];
		text = string.Format(GlobalScript.inst.new_events_text[283]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[284];
		button_text[1] = GlobalScript.inst.new_events_text[285];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[282];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[286];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[287];
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[5] += 50;
			GlobalScript.inst.gameState.data[12] -= 20;
			break;
		}
	}
}
