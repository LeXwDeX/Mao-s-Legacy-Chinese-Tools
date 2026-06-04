using EventsForDLC;
using UnityEngine;

public class Event441 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1698];
		text = GlobalScript.inst.new_events_text[1699];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = string.Format(GlobalScript.inst.new_events_text[1700]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1698];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1701]);
			a.allcountries[21].isSC = true;
			a.allcountries[53].isSC = true;
			a.allcountries[101].isSC = true;
			a.allcountries[30].isSC = true;
			a.allcountries[8].isSC = true;
		}
	}
}
