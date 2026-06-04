using EventsForDLC;
using UnityEngine;

public class Event311 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[104];
		text = string.Format(GlobalScript.inst.new_events_text[105]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[106];
		button_text[1] = GlobalScript.inst.new_events_text[107];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[104];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[108];
			GlobalScript.inst.gameState.data[4] += 150;
			GlobalScript.inst.gameState.data[22] += 150;
			break;
		case 1:
		{
			text = GlobalScript.inst.new_events_text[109];
			int num = -1;
			for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
			{
				if (GlobalScript.inst.gameState.politics[i].name_1 == 17 && GlobalScript.inst.gameState.politics[i].name_2 == 17)
				{
					num = i;
					break;
				}
			}
			GlobalScript.inst.gameState.data[22] -= 150;
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
