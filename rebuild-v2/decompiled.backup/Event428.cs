using EventsForDLC;
using UnityEngine;

public class Event428 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1431];
		text = string.Format(GlobalScript.inst.new_events_text[1432], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1433];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1431];
		text = string.Format(GlobalScript.inst.new_events_text[1434], "\n");
		a.allcountries[87].spec += 5;
		a.allcountries[86].isNATO = true;
		a.allcountries[86].Vyshi = true;
		a.empires[0].power += 70;
	}
}
