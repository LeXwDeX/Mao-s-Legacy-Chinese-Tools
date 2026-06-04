using EventsForDLC;
using UnityEngine;

public class Event324 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[213];
		text = string.Format(GlobalScript.inst.new_events_text[214]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[215];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 70 && GlobalScript.inst.gameState.data[12] > 60)
		{
			button_text[1] = GlobalScript.inst.new_events_text[216];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[217]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 70 && GlobalScript.inst.gameState.data[12] > 30 && GlobalScript.inst.gameState.data[29] > 600)
		{
			button_text[2] = GlobalScript.inst.new_events_text[218];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[219]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[213];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[220];
			GlobalScript.inst.gameState.data[1] -= 150;
			GlobalScript.inst.gameState.influencePRC -= 5;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[221];
			GlobalScript.inst.gameState.data[8] -= 60;
			GlobalScript.inst.gameState.data[5] += 50;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.influencePRC += 5;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[222];
			GlobalScript.inst.gameState.data[5] += 50;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.empires[1].relations += 60;
			GlobalScript.inst.gameState.empires[1].power += 5;
			break;
		}
	}
}
