using EventsForDLC;
using UnityEngine;

public class Event308 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[85];
		text = string.Format(GlobalScript.inst.new_events_text[86]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[87];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] > 50)
		{
			button_text[1] = GlobalScript.inst.new_events_text[88];
			return;
		}
		button[1].SetActive(value: false);
		button_text[1] = string.Format(GlobalScript.inst.new_events_text[122]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[85];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[90];
			GlobalScript.inst.gameState.data[8] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[91];
			GlobalScript.inst.gameState.data[7] += 100;
			GlobalScript.inst.gameState.data[8] -= 30;
			GlobalScript.inst.gameState.party_number[0] += 50;
			break;
		}
	}
}
