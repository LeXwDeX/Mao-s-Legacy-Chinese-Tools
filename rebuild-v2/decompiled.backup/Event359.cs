using EventsForDLC;
using UnityEngine;

public class Event359 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[472];
		text = string.Format(GlobalScript.inst.new_events_text[473]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (GlobalScript.inst.gameState.resultOfEvents[353] == 1)
		{
			button_text[0] = GlobalScript.inst.new_events_text[474];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[475]);
		}
		button_text[1] = GlobalScript.inst.new_events_text[476];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[472];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[477];
			GlobalScript.inst.gameState.data[11] += 400;
			GlobalScript.inst.gameState.data[6] += 40;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[478];
			GlobalScript.inst.gameState.data[11] += 200;
			GlobalScript.inst.gameState.data[6] += 100;
			break;
		}
	}
}
