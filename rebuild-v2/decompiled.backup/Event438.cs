using EventsForDLC;
using UnityEngine;

public class Event438 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1672];
		text = string.Format(GlobalScript.inst.new_events_text[1673], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[9] >= 50)
		{
			button_text[0] = GlobalScript.inst.new_events_text[1674];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		if (a.data[9] >= 25 && a.data[8] >= 25)
		{
			button_text[1] = GlobalScript.inst.new_events_text[1675];
		}
		else if (a.data[9] <= 25)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 2.5f);
		}
		else if (a.data[8] <= 25)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 2.5f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], GlobalScript.inst.new_events_text[567], 2.5f);
		}
		button_text[2] = GlobalScript.inst.new_events_text[1676];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1672];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1677], "/n");
			a.data[9] -= 50;
		}
		if (result_num == 1)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1678], "/n");
			a.data[9] -= 25;
			a.data[8] -= 25;
		}
		if (result_num == 2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1679], "/n");
		}
	}
}
