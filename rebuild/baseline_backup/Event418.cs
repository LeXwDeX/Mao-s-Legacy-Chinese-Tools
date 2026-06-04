using EventsForDLC;
using UnityEngine;

public class Event418 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1339];
		text = string.Format(GlobalScript.inst.new_events_text[1340], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1341];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1339];
		text = string.Format(GlobalScript.inst.new_events_text[1342], "\n");
		a.allcountries[36].isOil = true;
		a.allcountries[101].isOil = true;
		a.allcountries[102].isOil = true;
		a.allcountries[103].isOil = true;
		a.allcountries[105].isOil = true;
	}
}
