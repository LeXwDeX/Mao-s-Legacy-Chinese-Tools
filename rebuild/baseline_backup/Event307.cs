using EventsForDLC;
using UnityEngine;

public class Event307 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[77];
		text = string.Format(GlobalScript.inst.new_events_text[78]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[79];
		button_text[1] = GlobalScript.inst.new_events_text[80];
		if (GlobalScript.inst.gameState.modifies[3].active)
		{
			button_text[2] = GlobalScript.inst.new_events_text[81];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[79], 5);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[77];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[82];
			GlobalScript.inst.gameState.data[1] += 15;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[83];
			GlobalScript.inst.gameState.data[3] += 100;
			GlobalScript.inst.gameState.data[1] -= 15;
			GlobalScript.inst.gameState.data[4] += 50;
			break;
		case 2:
		{
			text = GlobalScript.inst.new_events_text[84];
			GlobalScript.inst.gameState.party_number[0] += 300;
			GlobalScript.inst.gameState.data[3] -= 300;
			GlobalScript.inst.gameState.data[6] += 100;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] > 0)
				{
					politic.loyality = 0;
					politic.power -= 500;
				}
			}
			GlobalScript.inst.gameState.modifies[32].active = true;
			break;
		}
		}
	}
}
