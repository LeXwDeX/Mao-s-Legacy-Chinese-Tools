using EventsForDLC;
using UnityEngine;

public class Event347 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[382];
		text = string.Format(GlobalScript.inst.new_events_text[383]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[384];
		button_text[1] = GlobalScript.inst.new_events_text[385];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[382];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[386];
			GlobalScript.inst.gameState.data[3] -= 20;
			GlobalScript.inst.gameState.data[22] += 10;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[387];
			GlobalScript.inst.gameState.data[3] += 30;
			GlobalScript.inst.gameState.data[12] += 10;
			GlobalScript.inst.gameState.data[22] -= 10;
			break;
		}
	}
}
