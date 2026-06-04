using EventsForDLC;
using UnityEngine;

public class Event302 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[40];
		text = string.Format(GlobalScript.inst.new_events_text[41]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[42];
		if (GlobalScript.inst.gameState.party_number[0] > 10)
		{
			button_text[1] = GlobalScript.inst.new_events_text[43];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[44]);
		}
		if (GlobalScript.inst.gameState.party_number[4] > 10)
		{
			button_text[2] = GlobalScript.inst.new_events_text[45];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[46]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[40];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[47];
			GlobalScript.inst.gameState.data[1] -= 100;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[48];
			GlobalScript.inst.gameState.party_number[0] = 0;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[49];
			GlobalScript.inst.gameState.party_number[4] = 0;
			break;
		}
	}
}
