using EventsForDLC;
using UnityEngine;

public class Event437 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1664];
		text = string.Format(GlobalScript.inst.new_events_text[1665], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[1666];
		button_text[1] = GlobalScript.inst.new_events_text[1667];
		button_text[2] = GlobalScript.inst.new_events_text[1668];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1664];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1669], "\n");
			a.data[1] -= 100;
			a.data[3] -= 100;
			a.data[4] += 50;
		}
		if (result_num == 1)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1670], "\n");
			a.data[1] += 100;
			a.data[3] += 100;
			a.data[4] -= 50;
		}
		if (result_num == 2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1671], "\n");
			a.data[1] -= 50;
			a.data[3] -= 100;
			a.data[4] += 100;
		}
	}
}
