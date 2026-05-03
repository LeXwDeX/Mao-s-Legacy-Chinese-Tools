using EventsForDLC;
using UnityEngine;

public class Event330 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[266];
		text = string.Format(GlobalScript.inst.new_events_text[267]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[268];
		button_text[1] = GlobalScript.inst.new_events_text[269];
		button_text[2] = GlobalScript.inst.new_events_text[270];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[266];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[271];
			GlobalScript.inst.gameState.data[8] += 10;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[272];
			GlobalScript.inst.gameState.data[8] += 50;
			GlobalScript.inst.gameState.data[7] += 70;
			GlobalScript.inst.gameState.empires[0].power -= 70;
			GlobalScript.inst.gameState.empires[0].relations -= 70;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[273];
			GlobalScript.inst.gameState.data[6] -= 30;
			GlobalScript.inst.gameState.data[7] += 70;
			GlobalScript.inst.gameState.empires[0].power -= 110;
			GlobalScript.inst.gameState.empires[0].relations -= 110;
			break;
		}
	}
}
