using EventsForDLC;
using UnityEngine;

public class Event442 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1702];
		text = GlobalScript.inst.new_events_text[1703];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = string.Format(GlobalScript.inst.new_events_text[1704]);
		button_text[1] = string.Format(GlobalScript.inst.new_events_text[1705]);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[1706]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1702];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1707]);
			a.data[8] += 70;
			a.data[3] -= 100;
			a.data[5] -= 100;
		}
		if (result_num == 1)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1708]);
			a.data[8] -= 50;
			a.data[3] += 100;
			a.data[5] += 100;
		}
		if (result_num == 2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1709]);
			a.data[8] -= 50;
			a.data[3] -= 100;
			a.data[5] -= 100;
		}
	}
}
