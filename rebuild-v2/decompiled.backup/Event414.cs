using EventsForDLC;
using UnityEngine;

public class Event414 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1345];
		text = string.Format(GlobalScript.inst.new_events_text[1346], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (a.data[8] + a.data[36] >= 20 && a.data[9] >= 20)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1347], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 20)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 2f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 2f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[1348];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1345];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1349], "\n");
			a.data[9] -= 10;
			a.data[8] -= 20;
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1350], "\n");
			a.allcountries[87].spec += 5;
		}
	}
}
