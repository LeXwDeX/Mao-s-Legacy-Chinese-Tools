using EventsForDLC;
using UnityEngine;

public class Event355 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[448];
		text = string.Format(GlobalScript.inst.new_events_text[449]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40)
		{
			button_text[0] = GlobalScript.inst.new_events_text[450];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[451]);
		}
		button_text[1] = GlobalScript.inst.new_events_text[452];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[448];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[453];
			GlobalScript.inst.gameState.data[8] -= 20;
			GlobalScript.inst.gameState.data[11] += 100;
			GlobalScript.inst.gameState.data[12] += 100;
			GlobalScript.inst.gameState.data[22] += 200;
			GlobalScript.inst.gameState.data[6] += 100;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[454];
			break;
		}
	}
}
