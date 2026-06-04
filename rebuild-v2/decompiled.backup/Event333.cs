using EventsForDLC;
using UnityEngine;

public class Event333 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[288];
		text = string.Format(GlobalScript.inst.new_events_text[289]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[290];
		button_text[1] = GlobalScript.inst.new_events_text[291];
		button_text[2] = GlobalScript.inst.new_events_text[292];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[288];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[293];
			GlobalScript.inst.gameState.empires[0].relations += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[294];
			GlobalScript.inst.gameState.data[8] += 50;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[5] += 50;
			GlobalScript.inst.gameState.empires[0].relations -= 250;
			GlobalScript.inst.gameState.data[6] += 100;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[295];
			GlobalScript.inst.gameState.data[4] += 50;
			GlobalScript.inst.gameState.data[6] -= 100;
			GlobalScript.inst.gameState.empires[0].relations += 150;
			GlobalScript.inst.gameState.data[8] += 50;
			break;
		}
	}
}
