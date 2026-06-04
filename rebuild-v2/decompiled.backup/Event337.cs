using EventsForDLC;
using UnityEngine;

public class Event337 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[318];
		text = string.Format(GlobalScript.inst.new_events_text[319]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[320];
		button_text[1] = GlobalScript.inst.new_events_text[321];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[318];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[322];
			GlobalScript.inst.gameState.data[3] -= 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[323];
			GlobalScript.inst.gameState.data[4] += 30;
			break;
		}
	}
}
