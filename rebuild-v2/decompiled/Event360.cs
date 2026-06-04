using EventsForDLC;
using UnityEngine;

public class Event360 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[486];
		text = string.Format(GlobalScript.inst.new_events_text[487]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (GlobalScript.inst.gameState.resultOfEvents[353] == 1 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 200)
		{
			button_text[0] = GlobalScript.inst.new_events_text[488];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[489]);
		}
		button_text[1] = GlobalScript.inst.new_events_text[490];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[486];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[491];
			GlobalScript.inst.gameState.data[11] += 40;
			GlobalScript.inst.gameState.data[8] -= 180;
			GlobalScript.inst.gameState.data[6] += 70;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[492];
			break;
		}
	}
}
