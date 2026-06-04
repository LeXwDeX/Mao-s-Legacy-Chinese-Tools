using EventsForDLC;
using UnityEngine;

public class Event314 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[126];
		text = string.Format(GlobalScript.inst.new_events_text[127]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[128];
		button_text[1] = GlobalScript.inst.new_events_text[129];
		button_text[2] = GlobalScript.inst.new_events_text[130];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[126];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[131];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[132];
			GlobalScript.inst.gameState.empires[1].relations -= 150;
			GlobalScript.inst.gameState.empires[0].relations += 100;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[133];
			GlobalScript.inst.gameState.empires[1].relations += 100;
			GlobalScript.inst.gameState.empires[0].relations -= 150;
			break;
		}
	}
}
