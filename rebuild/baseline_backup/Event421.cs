using EventsForDLC;
using UnityEngine;

public class Event421 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1364];
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (a.event_done[422] && GlobalScript.inst.gameState.iron_and_blood)
		{
			gameObject.GetComponent<achievements>().Set(141);
		}
		text = string.Format(GlobalScript.inst.new_events_text[1365], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1366];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1364];
		text = string.Format(GlobalScript.inst.new_events_text[1367], "\n");
		a.empires[0].power = 0;
		for (int i = 0; i < a.allcountries.Length; i++)
		{
			if (a.allcountries[i].Vyshi && i != 51)
			{
				a.allcountries[i].Vyshi = false;
			}
			if (!a.allcountries[1].isASEAN)
			{
				a.allcountries[i].isASEAN = false;
			}
			if (!a.allcountries[1].isSEATO)
			{
				a.allcountries[i].isSEATO = false;
			}
			a.allcountries[i].isSENTO = false;
			a.allcountries[i].isNATO = false;
		}
	}
}
