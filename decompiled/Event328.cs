using EventsForDLC;
using UnityEngine;

public class Event328 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[251];
		text = string.Format(GlobalScript.inst.new_events_text[252]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[253];
		button_text[1] = GlobalScript.inst.new_events_text[254];
		button_text[2] = GlobalScript.inst.new_events_text[255];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[251];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[256];
			GlobalScript.inst.gameState.party_number[0] += 50;
			GlobalScript.inst.gameState.party_number[1] += 50;
			GlobalScript.inst.gameState.party_number[2] += 25;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[257];
			GlobalScript.inst.gameState.party_number[2] += 25;
			GlobalScript.inst.gameState.party_number[3] += 50;
			GlobalScript.inst.gameState.party_number[4] += 50;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[258];
			break;
		}
	}
}
