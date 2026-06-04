using EventsForDLC;
using UnityEngine;

public class Event336 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[310];
		text = string.Format(GlobalScript.inst.new_events_text[311]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[312];
		button_text[1] = GlobalScript.inst.new_events_text[313];
		button_text[2] = GlobalScript.inst.new_events_text[314];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[310];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[315];
			GlobalScript.inst.gameState.data[11] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[316];
			GlobalScript.inst.gameState.data[8] -= 20;
			GlobalScript.inst.gameState.data[4] += 30;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[12] += 30;
			GlobalScript.inst.gameState.data[11] += 350;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[317];
			GlobalScript.inst.gameState.data[8] -= 50;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[12] += 60;
			GlobalScript.inst.gameState.data[11] += 600;
			break;
		}
	}
}
