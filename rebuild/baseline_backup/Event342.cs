using EventsForDLC;
using UnityEngine;

public class Event342 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[354];
		text = string.Format(GlobalScript.inst.new_events_text[355]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[356];
		button_text[1] = GlobalScript.inst.new_events_text[357];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[354];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[358];
			GlobalScript.inst.gameState.data[6] += 150;
			GlobalScript.inst.gameState.empires[0].relations -= 250;
			GlobalScript.inst.gameState.empires[1].relations -= 300;
			GlobalScript.inst.gameState.data[1] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[359];
			GlobalScript.inst.gameState.data[4] += 50;
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.empires[0].relations += 50;
			GlobalScript.inst.gameState.empires[1].relations += 50;
			GlobalScript.inst.gameState.modifies[37].active = true;
			break;
		}
	}
}
