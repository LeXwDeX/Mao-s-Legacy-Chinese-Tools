using EventsForDLC;
using UnityEngine;

public class Event320 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[173];
		text = string.Format(GlobalScript.inst.new_events_text[174]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[175];
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 150 && GlobalScript.inst.gameState.data[12] >= 500)
		{
			button_text[1] = GlobalScript.inst.new_events_text[176];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[177]);
		}
		if (GlobalScript.inst.gameState.empires[0].relations >= 500 && GlobalScript.inst.gameState.data[12] >= 500)
		{
			button_text[2] = GlobalScript.inst.new_events_text[178];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[179]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[173];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[180];
			GlobalScript.inst.gameState.data[1] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[181];
			GlobalScript.inst.gameState.data[8] -= 150;
			GlobalScript.inst.gameState.influencePRC += 5;
			GlobalScript.inst.gameState.modifies[34].active = true;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[182];
			GlobalScript.inst.gameState.data[69] += 150;
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.influencePRC += 5;
			GlobalScript.inst.gameState.modifies[34].active = true;
			break;
		}
	}
}
