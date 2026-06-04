using EventsForDLC;
using UnityEngine;

public class Event423 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1372];
		text = string.Format(GlobalScript.inst.new_events_text[1373], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1374];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1372];
		a.allcountries[86].Gosstroy = 3;
		a.allcountries[86].SubGosstroy = 6;
		text = string.Format(GlobalScript.inst.new_events_text[1375], "\n");
	}
}
