using EventsForDLC;
using UnityEngine;

public class Event327 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[245];
		text = string.Format(GlobalScript.inst.new_events_text[246]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[247];
		button_text[1] = GlobalScript.inst.new_events_text[248];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[245];
		switch (result_num)
		{
		case 0:
		{
			text = GlobalScript.inst.new_events_text[249];
			GlobalScript.inst.gameState.party_ideology[0] += 50;
			GlobalScript.inst.gameState.party_ideology[1] += 10;
			GlobalScript.inst.gameState.party_ideology[2] += 5;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] == 0)
				{
					politic2.power += 25;
				}
				else if (politic2.traits[0] > 1)
				{
					politic2.loyality -= 25;
				}
			}
			break;
		}
		case 1:
		{
			text = GlobalScript.inst.new_events_text[250];
			GlobalScript.inst.gameState.party_ideology[2] += 10;
			GlobalScript.inst.gameState.party_ideology[3] += 10;
			GlobalScript.inst.gameState.party_ideology[4] += 50;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 4)
				{
					politic.power += 25;
				}
				else if (politic.traits[0] < 2)
				{
					politic.loyality -= 25;
				}
			}
			break;
		}
		}
	}
}
