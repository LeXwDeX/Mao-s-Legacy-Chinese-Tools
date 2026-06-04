using EventsForDLC;
using UnityEngine;

public class Event350 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[397];
		text = string.Format(GlobalScript.inst.new_events_text[398]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (GlobalScript.inst.gameState.data[9] >= 50)
		{
			button_text[0] = GlobalScript.inst.new_events_text[399];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[400]);
		}
		button_text[1] = GlobalScript.inst.new_events_text[401];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[397];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[402];
			GlobalScript.inst.gameState.data[9] -= 50;
			GlobalScript.inst.gameState.empires[1].relations -= 200;
			if (!GlobalScript.inst.gameState.science[18])
			{
				GlobalScript.inst.gameState.science[18] = true;
			}
			else if (!GlobalScript.inst.gameState.science[23])
			{
				GlobalScript.inst.gameState.science[23] = true;
			}
			else
			{
				GlobalScript.inst.gameState.data[22] += 100;
			}
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[403];
			break;
		}
	}
}
