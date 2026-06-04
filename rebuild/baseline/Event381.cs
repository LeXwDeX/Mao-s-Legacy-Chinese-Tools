using EventsForDLC;
using UnityEngine;

public class Event381 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		if (a.allcountries[87].isNATO)
		{
			name = GlobalScript.inst.new_events_text[894];
		}
		else
		{
			name = GlobalScript.inst.new_events_text[895];
		}
		text = string.Format(GlobalScript.inst.new_events_text[896], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[897];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (a.allcountries[87].isNATO)
		{
			name = GlobalScript.inst.new_events_text[894];
		}
		else
		{
			name = GlobalScript.inst.new_events_text[895];
		}
		text = string.Format(GlobalScript.inst.new_events_text[899], "\n");
		for (int i = 0; i < a.allcountries.Length; i++)
		{
			if (a.allcountries[i].isSEV)
			{
				a.allcountries[i].LeaveComecon().JoinEU();
				a.allcountries[i].Gosstroy = 2;
				a.allcountries[i].SubGosstroy = 15;
			}
		}
		a.allcountries[7].Gosstroy = 2;
		a.allcountries[7].SubGosstroy = 3;
		if (GlobalScript.inst.gameState.iron_and_blood)
		{
			gameObject.GetComponent<achievements>().Set(132);
		}
		a.allcountries[17].parts[0] = true;
		a.allcountries[17].name = GlobalScript.inst.new_events_text[898];
		a.allcountries[17].Vyshi = false;
		a.allcountries[17].Gosstroy = 2;
		a.allcountries[17].SubGosstroy = 3;
	}
}
