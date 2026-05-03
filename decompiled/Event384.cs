using EventsForDLC;
using UnityEngine;

public class Event384 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[936];
		text = string.Format(GlobalScript.inst.new_events_text[937], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		if (a.data[9] >= 50 && a.data[8] + a.data[36] >= 30)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[939], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		if (a.data[9] >= 50 && a.data[8] + a.data[36] >= 30)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[940], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		if (a.data[9] >= 50 && a.data[8] + a.data[36] >= 30)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[941], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		if (a.data[9] >= 50 && a.data[8] + a.data[36] >= 30)
		{
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[942], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		button_text[4] = GlobalScript.inst.new_events_text[943];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[936];
		if (result_num < 4)
		{
			a.data[9] -= 50;
			a.data[8] -= 30;
		}
		text = string.Format(GlobalScript.inst.new_events_text[945 + result_num], "\n");
	}
}
