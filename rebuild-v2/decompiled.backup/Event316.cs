using EventsForDLC;
using UnityEngine;

public class Event316 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[140];
		text = string.Format(GlobalScript.inst.new_events_text[141]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[142];
		button_text[1] = GlobalScript.inst.new_events_text[143];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[140];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[144];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[145];
			GlobalScript.inst.gameState.data[7] += 30;
			GlobalScript.inst.gameState.empires[0].power -= 50;
			break;
		}
	}
}
