using EventsForDLC;
using UnityEngine;

public class Event413 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1280];
		int num = 0;
		num = ((a.allcountries[31].isSENTO || a.allcountries[8].isSENTO) ? ((!a.allcountries[31].isSENTO) ? 1 : 2) : 0);
		text = string.Format(GlobalScript.inst.new_events_text[1281], "\n", GlobalScript.inst.new_events_text[1282 + num]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1285];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1280];
		text = string.Format(GlobalScript.inst.new_events_text[1286], "\n");
		a.empires[0].power -= 30;
		a.empires[1].power += 10;
		GlobalScript.inst.gameState.data[143] -= 5;
		a.allcountries[8].isSENTO = false;
		a.allcountries[31].isSENTO = false;
	}
}
