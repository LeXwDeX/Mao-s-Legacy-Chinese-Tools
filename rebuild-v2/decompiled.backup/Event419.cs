using EventsForDLC;
using UnityEngine;

public class Event419 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1351];
		text = string.Format(GlobalScript.inst.new_events_text[1352], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[1353];
		button_text[1] = GlobalScript.inst.new_events_text[1354];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1351];
		a.allcountries[87].spec = 100;
		a.allcountries[87].Gosstroy = 3;
		a.allcountries[87].SubGosstroy = 6;
		a.allcountries[87].Vyshi = true;
		if (result_num == 0)
		{
			a.allcountries[87].Torg = true;
			text = string.Format(GlobalScript.inst.new_events_text[1355], "\n");
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1356], "\n");
		}
	}
}
