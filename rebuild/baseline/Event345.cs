using EventsForDLC;
using UnityEngine;

public class Event345 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[376];
		text = string.Format(GlobalScript.inst.new_events_text[377]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[378];
		button_text[1] = GlobalScript.inst.new_events_text[379];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[376];
		switch (result_num)
		{
		case 0:
		{
			text = GlobalScript.inst.new_events_text[380];
			GlobalScript.inst.gameState.data[57] += 15;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] == 0)
				{
					politic2.power -= 25;
					politic2.loyality -= 50;
				}
			}
			GlobalScript.inst.gameState.empires[0].relations += 25;
			break;
		}
		case 1:
		{
			text = GlobalScript.inst.new_events_text[381];
			GlobalScript.inst.gameState.data[57] += 15;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 0)
				{
					politic.power += 25;
					politic.loyality += 50;
				}
			}
			GlobalScript.inst.gameState.data[6] += 25;
			break;
		}
		}
	}
}
