using EventsForDLC;
using UnityEngine;

public class Event351 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[404];
		text = string.Format(GlobalScript.inst.new_events_text[405]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (GlobalScript.inst.gameState.data[9] >= 20)
		{
			button_text[0] = GlobalScript.inst.new_events_text[406];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[407]);
		}
		if (GlobalScript.inst.gameState.data[9] >= 30)
		{
			button_text[1] = GlobalScript.inst.new_events_text[408];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[409]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 20 && GlobalScript.inst.gameState.data[29] >= 400)
		{
			button_text[2] = GlobalScript.inst.new_events_text[410];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[411]);
		}
		button_text[3] = GlobalScript.inst.new_events_text[412];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[404];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[413];
			GlobalScript.inst.gameState.empires[1].relations -= 70;
			GlobalScript.inst.gameState.data[22] += 100;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[414];
			GlobalScript.inst.gameState.data[22] += 100;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[415];
			GlobalScript.inst.gameState.empires[1].relations += 70;
			GlobalScript.inst.gameState.data[22] += 100;
			GlobalScript.inst.gameState.data[8] -= 10;
			break;
		case 3:
			text = GlobalScript.inst.new_events_text[416];
			break;
		}
	}
}
