using EventsForDLC;
using UnityEngine;

public class Event338 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[324];
		text = string.Format(GlobalScript.inst.new_events_text[325]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[326];
		button_text[1] = GlobalScript.inst.new_events_text[327];
		button_text[2] = GlobalScript.inst.new_events_text[328];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[324];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[329];
			GlobalScript.inst.gameState.data[7] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[330];
			GlobalScript.inst.gameState.data[1] += 30;
			break;
		case 2:
		{
			text = GlobalScript.inst.new_events_text[331];
			GlobalScript.inst.gameState.data[1] -= 30;
			GlobalScript.inst.gameState.data[4] += 30;
			for (int i = 0; i < GlobalScript.inst.gameState.is_party_enabled.Length; i++)
			{
				GlobalScript.inst.gameState.is_party_enabled[i] = true;
			}
			break;
		}
		}
	}
}
