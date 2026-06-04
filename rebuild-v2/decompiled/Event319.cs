using EventsForDLC;
using UnityEngine;

public class Event319 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[160];
		text = string.Format(GlobalScript.inst.new_events_text[161]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_events_text[162];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50 && GlobalScript.inst.gameState.data[12] >= 500)
		{
			button_text[1] = GlobalScript.inst.new_events_text[163];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[164], 25);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50 && GlobalScript.inst.gameState.data[29] >= 500)
		{
			button_text[2] = GlobalScript.inst.new_events_text[165];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[166], 25);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50 && GlobalScript.inst.gameState.data[6] >= 500)
		{
			button_text[3] = GlobalScript.inst.new_events_text[167];
			return;
		}
		button[3].SetActive(value: false);
		button_text[3] = string.Format(GlobalScript.inst.new_events_text[168], 25);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[160];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[169];
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[170];
			GlobalScript.inst.gameState.data[12] -= 50;
			GlobalScript.inst.gameState.data[13] += 50;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[171];
			GlobalScript.inst.gameState.data[8] -= 50;
			GlobalScript.inst.gameState.data[13] += 50;
			GlobalScript.inst.gameState.empires[1].relations += 50;
			GlobalScript.inst.gameState.empires[1].power += 5;
			break;
		case 3:
			text = GlobalScript.inst.new_events_text[172];
			GlobalScript.inst.gameState.data[8] -= 50;
			GlobalScript.inst.gameState.data[13] += 50;
			GlobalScript.inst.gameState.empires[0].relations += 50;
			GlobalScript.inst.gameState.empires[0].power += 5;
			break;
		}
	}
}
