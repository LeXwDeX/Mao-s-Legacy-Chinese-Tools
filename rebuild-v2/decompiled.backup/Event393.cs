using EventsForDLC;
using UnityEngine;

public class Event393 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1088];
		text = string.Format(GlobalScript.inst.new_events_text[1089], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1090];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.iron_and_blood)
		{
			gameObject.GetComponent<achievements>().Set(121);
		}
		name = GlobalScript.inst.new_events_text[1088];
		text = string.Format(GlobalScript.inst.new_events_text[1091], "\n");
		a.empires[0].power -= 15;
		a.empires[1].power -= 15;
		a.allcountries[87].spec += 10;
		a.allcountries[85].SubGosstroy = 4;
		a.allcountries[85].Vyshi = false;
	}
}
