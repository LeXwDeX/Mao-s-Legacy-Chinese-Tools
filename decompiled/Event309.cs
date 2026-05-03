using EventsForDLC;
using UnityEngine;

public class Event309 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[92];
		text = string.Format(GlobalScript.inst.new_events_text[93]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[94];
		button_text[1] = GlobalScript.inst.new_events_text[95];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[92];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[96];
			GlobalScript.inst.gameState.data[1] -= 250;
			break;
		case 1:
		{
			text = GlobalScript.inst.new_events_text[97];
			int num = -1;
			for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
			{
				if (GlobalScript.inst.gameState.politics[i].name_1 == 10 && GlobalScript.inst.gameState.politics[i].name_2 == 16)
				{
					num = i;
					break;
				}
				if (GlobalScript.inst.gameState.politics[i].name_1 == 16 && GlobalScript.inst.gameState.politics[i].name_2 == 16)
				{
					num = i;
					break;
				}
				if (GlobalScript.inst.gameState.politics[i].name_1 == 24 && GlobalScript.inst.gameState.politics[i].name_2 == 16)
				{
					num = i;
					break;
				}
			}
			GlobalScript.inst.gameState.data[8] -= 50;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] > 0)
				{
					politic.loyality -= 250;
					politic.power -= 250;
				}
			}
			if (num >= 0)
			{
				GlobalScript.inst.gameState.KillPerson(num);
			}
			break;
		}
		}
	}
}
