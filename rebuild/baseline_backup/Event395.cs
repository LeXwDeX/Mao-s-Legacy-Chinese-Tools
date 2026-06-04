using EventsForDLC;
using UnityEngine;

public class Event395 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1099];
		text = string.Format(GlobalScript.inst.new_events_text[1100], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (a.influencePRC >= 300 && a.data[9] >= 150 && a.data[8] + a.data[36] >= 100 && a.modifies[6].active)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1101], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.influencePRC < 300)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[620], 30f);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else if (a.data[9] < 150)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_events_text[825];
		}
		button_text[1] = GlobalScript.inst.new_events_text[1102];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1099];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1103], "\n");
			a.allcountries[85].inflCh = 6;
			a.data[9] -= 150;
			a.data[8] -= 100;
			a.allcountries[85].Torg = false;
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1104], "\n");
		}
	}
}
