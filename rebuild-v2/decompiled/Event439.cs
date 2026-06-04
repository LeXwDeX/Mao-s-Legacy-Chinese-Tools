using EventsForDLC;
using UnityEngine;

public class Event439 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1680];
		text = string.Format(GlobalScript.inst.new_events_text[1681], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (a.data[9] >= 50)
		{
			button_text[0] = GlobalScript.inst.new_events_text[1682];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[1683];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1680];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1684], "\n");
			a.data[9] -= 50;
			a.allcountries[40].Gosstroy = 0;
			a.allcountries[40].SubGosstroy = 10;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1685], "\n");
			break;
		}
	}
}
