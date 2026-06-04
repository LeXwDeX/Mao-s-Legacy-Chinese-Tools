using EventsForDLC;
using UnityEngine;

public class Event343 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[360];
		text = string.Format(GlobalScript.inst.new_events_text[361]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[362];
		button_text[1] = GlobalScript.inst.new_events_text[363];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[360];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[364];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[365];
			GlobalScript.inst.gameState.data[4] += 30;
			GlobalScript.inst.gameState.data[5] += 30;
			break;
		}
	}
}
