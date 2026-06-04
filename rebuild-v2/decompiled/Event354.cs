using EventsForDLC;
using UnityEngine;

public class Event354 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[438];
		text = string.Format(GlobalScript.inst.new_events_text[439]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 30)
		{
			button_text[0] = GlobalScript.inst.new_events_text[440];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[441]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50 && (GlobalScript.inst.gameState.resultOfEvents[353] == 0 || GlobalScript.inst.gameState.resultOfEvents[353] == 1))
		{
			button_text[1] = GlobalScript.inst.new_events_text[442];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[443]);
		}
		button_text[2] = GlobalScript.inst.new_events_text[444];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[438];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[445];
			GlobalScript.inst.gameState.data[8] -= 20;
			GlobalScript.inst.gameState.data[11] += 100;
			GlobalScript.inst.gameState.data[12] += 100;
			GlobalScript.inst.gameState.data[22] += 100;
			GlobalScript.inst.gameState.data[5] += 100;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[446];
			GlobalScript.inst.gameState.data[8] -= 40;
			GlobalScript.inst.gameState.data[11] += 300;
			GlobalScript.inst.gameState.data[12] += 100;
			GlobalScript.inst.gameState.data[22] += 100;
			GlobalScript.inst.gameState.data[5] += 100;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[447];
			GlobalScript.inst.gameState.data[4] += 40;
			GlobalScript.inst.gameState.data[11] += 300;
			GlobalScript.inst.gameState.data[12] += 100;
			GlobalScript.inst.gameState.data[22] += 100;
			GlobalScript.inst.gameState.data[5] += 100;
			break;
		}
	}
}
