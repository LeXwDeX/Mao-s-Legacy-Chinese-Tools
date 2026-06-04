using EventsForDLC;
using UnityEngine;

public class Event317 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[146];
		text = string.Format(GlobalScript.inst.new_events_text[147]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[148];
		button_text[1] = GlobalScript.inst.new_events_text[149];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[146];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[150];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[151];
			GlobalScript.inst.gameState.data[3] -= 50;
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.data[57] -= 50;
			GlobalScript.inst.gameState.empires[0].power -= 30;
			break;
		}
	}
}
