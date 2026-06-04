using EventsForDLC;
using UnityEngine;

public class Event331 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[274];
		text = string.Format(GlobalScript.inst.new_events_text[275]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[276];
		button_text[1] = GlobalScript.inst.new_events_text[277];
		button_text[2] = GlobalScript.inst.new_events_text[278];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[274];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[279];
			GlobalScript.inst.gameState.data[1] += 50;
			GlobalScript.inst.gameState.data[3] -= 150;
			break;
		case 1:
			text = GlobalScript.inst.new_events_text[280];
			GlobalScript.inst.gameState.data[6] += 100;
			GlobalScript.inst.gameState.data[1] -= 250;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[16]--;
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[281];
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.data[1] += 150;
			GlobalScript.inst.gameState.data[3] -= 250;
			GlobalScript.inst.gameState.empires[0].relations += 50;
			GlobalScript.inst.gameState.data[16] += ((GlobalScript.inst.gameState.data[16] < 15) ? 1 : 0);
			break;
		}
	}
}
