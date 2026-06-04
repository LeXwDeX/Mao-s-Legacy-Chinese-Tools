using EventsForDLC;
using UnityEngine;

public class Event341 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[346];
		text = string.Format(GlobalScript.inst.new_events_text[347]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[348];
		button_text[1] = GlobalScript.inst.new_events_text[349];
		button_text[2] = GlobalScript.inst.new_events_text[350];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[346];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[351];
			GlobalScript.inst.gameState.data[4] -= 50;
			GlobalScript.inst.gameState.data[1] += 150;
			GlobalScript.inst.gameState.data[57] -= 150;
			GlobalScript.inst.gameState.data[31] += 300;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[352];
			GlobalScript.inst.gameState.data[3] += 25;
			GlobalScript.inst.gameState.data[57] += 25;
			GlobalScript.inst.gameState.data[31] -= 50;
			GlobalScript.inst.gameState.data[34]++;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[353];
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[57] += 50;
			GlobalScript.inst.gameState.data[31] -= 150;
			GlobalScript.inst.gameState.data[34] += 5;
			GlobalScript.inst.gameState.empires[0].relations -= 150;
			break;
		}
	}
}
