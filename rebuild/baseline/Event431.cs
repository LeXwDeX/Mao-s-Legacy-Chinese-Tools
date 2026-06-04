using EventsForDLC;
using UnityEngine;

public class Event431 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1450];
		text = string.Format(GlobalScript.inst.new_events_text[1451], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1380];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1450];
		text = string.Format(GlobalScript.inst.new_events_text[1452], "\n");
		a.allcountries[86].Gosstroy = 3;
		a.allcountries[86].SubGosstroy = 12;
		a.allcountries[86].isEU = true;
	}
}
