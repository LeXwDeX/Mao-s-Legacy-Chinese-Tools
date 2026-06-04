using EventsForDLC;
using UnityEngine;

public class Event357 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[465];
		text = string.Format(GlobalScript.inst.new_events_text[466]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40)
		{
			button_text[0] = GlobalScript.inst.new_events_text[467];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[468]);
		}
		button_text[1] = GlobalScript.inst.new_events_text[469];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[465];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[470];
			GlobalScript.inst.gameState.data[8] -= 30;
			GlobalScript.inst.gameState.data[11] += 200;
			GlobalScript.inst.gameState.data[6] += 40;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[471];
			break;
		}
	}
}
