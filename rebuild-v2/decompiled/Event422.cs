using EventsForDLC;
using UnityEngine;

public class Event422 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1368];
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (a.event_done[421] && GlobalScript.inst.gameState.iron_and_blood)
		{
			gameObject.GetComponent<achievements>().Set(141);
		}
		text = string.Format(GlobalScript.inst.new_events_text[1369], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1370];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1368];
		text = string.Format(GlobalScript.inst.new_events_text[1371], "\n");
		a.empires[0].power = 0;
		for (int i = 0; i < a.allcountries.Length; i++)
		{
			a.allcountries[i].isEU = false;
		}
	}
}
