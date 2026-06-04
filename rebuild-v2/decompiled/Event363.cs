using EventsForDLC;
using UnityEngine;

public class Event363 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[513];
		text = string.Format(GlobalScript.inst.new_events_text[514]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if ((GlobalScript.inst.gameState.resultOfEvents[353] == 0 || GlobalScript.inst.gameState.resultOfEvents[353] == 1) && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 30)
		{
			button_text[0] = GlobalScript.inst.new_events_text[515];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[516]);
		}
		if ((GlobalScript.inst.gameState.resultOfEvents[353] == 0 || GlobalScript.inst.gameState.resultOfEvents[353] == 1) && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 30 && GlobalScript.inst.gameState.data[29] >= 50)
		{
			button_text[1] = GlobalScript.inst.new_events_text[517];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[518]);
		}
		button_text[2] = GlobalScript.inst.new_events_text[519];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[513];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[520];
			GlobalScript.inst.gameState.data[11] += 150;
			GlobalScript.inst.gameState.data[8] -= 20;
			GlobalScript.inst.gameState.data[6] += 10;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[521];
			GlobalScript.inst.gameState.data[11] += 300;
			GlobalScript.inst.gameState.data[8] -= 20;
			GlobalScript.inst.gameState.data[6] += 20;
			GlobalScript.inst.gameState.empires[1].relations += 50;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[522];
			break;
		}
	}
}
