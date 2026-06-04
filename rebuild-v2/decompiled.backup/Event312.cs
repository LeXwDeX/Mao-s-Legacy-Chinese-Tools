using EventsForDLC;
using UnityEngine;

public class Event312 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[110];
		text = string.Format(GlobalScript.inst.new_events_text[111]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[112];
		button_text[1] = GlobalScript.inst.new_events_text[113];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[110];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[114];
			GlobalScript.inst.gameState.data[1] -= 150;
			break;
		case 1:
		{
			text = GlobalScript.inst.new_events_text[115];
			int num = -1;
			for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
			{
				if (GlobalScript.inst.gameState.politics[i].name_1 == 7 && GlobalScript.inst.gameState.politics[i].name_2 == 7)
				{
					num = i;
					break;
				}
			}
			GlobalScript.inst.gameState.data[1] += 150;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] > 1)
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
