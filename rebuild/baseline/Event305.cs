using EventsForDLC;
using UnityEngine;

public class Event305 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[63];
		text = string.Format(GlobalScript.inst.new_events_text[64]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[65];
		button_text[1] = GlobalScript.inst.new_events_text[66];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[63];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[67];
			break;
		case 1:
		{
			text = GlobalScript.inst.new_events_text[68];
			int num = -1;
			for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
			{
				if (GlobalScript.inst.gameState.politics[i].name_1 == 13 && GlobalScript.inst.gameState.politics[i].name_2 == 13)
				{
					num = i;
					break;
				}
			}
			if (num > 0)
			{
				GlobalScript.inst.gameState.KillPerson(num);
			}
			break;
		}
		}
	}
}
