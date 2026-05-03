using EventsForDLC;
using UnityEngine;

public class Event399 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1130];
		text = string.Format(GlobalScript.inst.new_events_text[1131], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1090];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1130];
		text = string.Format(GlobalScript.inst.new_events_text[1132], "\n");
		a.allcountries[85].Gosstroy = 3;
		a.allcountries[85].SubGosstroy = 6;
		a.empires[0].power += 30;
		a.data[7] -= 10;
	}
}
