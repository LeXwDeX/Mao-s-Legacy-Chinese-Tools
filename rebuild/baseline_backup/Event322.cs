using EventsForDLC;
using UnityEngine;

public class Event322 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[193];
		text = string.Format(GlobalScript.inst.new_events_text[194]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[195];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 70 && GlobalScript.inst.gameState.data[12] >= 500)
		{
			button_text[1] = GlobalScript.inst.new_events_text[196];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[197]);
		}
		if (GlobalScript.inst.gameState.data[6] >= 700 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 70)
		{
			button_text[2] = GlobalScript.inst.new_events_text[198];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[199]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[193];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[200];
			GlobalScript.inst.gameState.data[5] -= 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[201];
			GlobalScript.inst.gameState.data[8] -= 70;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[5] += 50;
			GlobalScript.inst.gameState.influencePRC += 5;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[202];
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[5] += 50;
			GlobalScript.inst.gameState.empires[0].relations += 50;
			GlobalScript.inst.gameState.empires[0].power += 5;
			break;
		}
	}
}
