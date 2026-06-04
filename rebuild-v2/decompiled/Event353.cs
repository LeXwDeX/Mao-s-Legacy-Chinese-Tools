using EventsForDLC;
using UnityEngine;

public class Event353 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[428];
		text = string.Format(GlobalScript.inst.new_events_text[429]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 30)
		{
			button_text[0] = GlobalScript.inst.new_events_text[430];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[431]);
		}
		if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50)
		{
			button_text[1] = GlobalScript.inst.new_events_text[432];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[433]);
		}
		button_text[2] = GlobalScript.inst.new_events_text[434];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[428];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[435];
			GlobalScript.inst.gameState.data[8] -= 20;
			GlobalScript.inst.gameState.data[11] += 100;
			GlobalScript.inst.gameState.data[12] += 100;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[436];
			GlobalScript.inst.gameState.data[8] -= 40;
			GlobalScript.inst.gameState.data[11] += 200;
			GlobalScript.inst.gameState.data[12] += 200;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[437];
			GlobalScript.inst.gameState.data[12] += 50;
			break;
		}
	}
}
