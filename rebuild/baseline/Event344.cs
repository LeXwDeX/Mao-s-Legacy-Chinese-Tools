using EventsForDLC;
using UnityEngine;

public class Event344 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[366];
		text = string.Format(GlobalScript.inst.new_events_text[367]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_events_text[368];
		button_text[1] = GlobalScript.inst.new_events_text[369];
		button_text[2] = GlobalScript.inst.new_events_text[370];
		button_text[3] = GlobalScript.inst.new_events_text[371];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[366];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[372];
			GlobalScript.inst.gameState.data[51] = 33;
			GlobalScript.inst.gameState.data[1] -= 150;
			GlobalScript.inst.gameState.data[8] -= 50;
			GlobalScript.inst.gameState.data[3] += 30;
			GlobalScript.inst.gameState.data[22] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[373];
			GlobalScript.inst.gameState.data[51] = 32;
			GlobalScript.inst.gameState.data[1] -= 50;
			GlobalScript.inst.gameState.data[8] -= 20;
			GlobalScript.inst.gameState.data[3] -= 25;
			GlobalScript.inst.gameState.data[22] += 50;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[374];
			GlobalScript.inst.gameState.data[51] = 31;
			GlobalScript.inst.gameState.data[1] += 50;
			GlobalScript.inst.gameState.data[8] -= 5;
			GlobalScript.inst.gameState.data[3] -= 50;
			GlobalScript.inst.gameState.data[22] += 50;
			break;
		case 3:
			text = GlobalScript.inst.new_events_text[375];
			GlobalScript.inst.gameState.data[51] = 30;
			GlobalScript.inst.gameState.data[1] += 150;
			GlobalScript.inst.gameState.data[3] -= 75;
			GlobalScript.inst.gameState.data[22] += 50;
			break;
		}
	}
}
