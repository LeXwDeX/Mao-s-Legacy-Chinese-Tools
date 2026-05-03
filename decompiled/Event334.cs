using EventsForDLC;
using UnityEngine;

public class Event334 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[296];
		text = string.Format(GlobalScript.inst.new_events_text[297]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[298];
		button_text[1] = GlobalScript.inst.new_events_text[299];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[296];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[300];
			GlobalScript.inst.gameState.data[1] += 50;
			GlobalScript.inst.gameState.empires[0].relations -= 150;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[301];
			GlobalScript.inst.gameState.data[8] -= 150;
			GlobalScript.inst.gameState.empires[0].relations += 150;
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.modifies[36].active = true;
			GlobalScript.inst.gameState.data[11] += 50;
			break;
		}
	}
}
