using EventsForDLC;
using UnityEngine;

public class Event335 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[302];
		text = string.Format(GlobalScript.inst.new_events_text[303]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[304];
		button_text[1] = GlobalScript.inst.new_events_text[305];
		button_text[2] = GlobalScript.inst.new_events_text[306];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[302];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[307];
			GlobalScript.inst.gameState.data[1] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[308];
			GlobalScript.inst.gameState.data[8] += 50;
			GlobalScript.inst.gameState.data[4] += 50;
			GlobalScript.inst.gameState.data[3] -= 50;
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.data[13] += 30;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power -= 15;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[309];
			GlobalScript.inst.gameState.data[6] += 50;
			GlobalScript.inst.gameState.data[8] += 20;
			GlobalScript.inst.gameState.data[4] -= 50;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[1] -= 150;
			GlobalScript.inst.gameState.data[16]--;
			break;
		}
	}
}
