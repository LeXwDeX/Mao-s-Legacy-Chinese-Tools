using EventsForDLC;
using UnityEngine;

public class Event425 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1397];
		text = string.Format(GlobalScript.inst.new_events_text[1398], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (a.data[8] + a.data[36] >= 50 && a.data[9] >= 100)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1399], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 10f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[1380];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1397];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1400], "\n");
			a.data[8] -= 50;
			a.data[9] -= 100;
			a.allcountries[86].Gosstroy = 2;
			a.allcountries[86].SubGosstroy = 3;
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1401], "\n");
		}
	}
}
