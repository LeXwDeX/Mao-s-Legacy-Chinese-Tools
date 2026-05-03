using EventsForDLC;
using UnityEngine;

public class Event339 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[332];
		text = string.Format(GlobalScript.inst.new_events_text[333]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[334];
		button_text[1] = GlobalScript.inst.new_events_text[335];
		button_text[2] = GlobalScript.inst.new_events_text[336];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[332];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[337];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[338];
			GlobalScript.inst.gameState.data[6] += 15;
			GlobalScript.inst.gameState.data[4] += 15;
			GlobalScript.inst.gameState.data[34] += 3;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[339];
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[11] += 250;
			GlobalScript.inst.gameState.data[8] -= 100;
			GlobalScript.inst.gameState.data[4] += 50;
			GlobalScript.inst.gameState.data[34] += 44;
			break;
		}
	}
}
