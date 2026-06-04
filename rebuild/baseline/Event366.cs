using EventsForDLC;
using UnityEngine;

public class Event366 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[561];
		text = string.Format(GlobalScript.inst.new_events_text[562], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[9] > 30 && a.data[8] + a.data[36] >= 50)
		{
			button_text[0] = GlobalScript.inst.new_events_text[563];
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 3f);
		}
		if (a.data[9] > 30 && a.data[8] + a.data[36] >= 50)
		{
			button_text[1] = GlobalScript.inst.new_events_text[564];
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 3f);
		}
		button_text[2] = GlobalScript.inst.new_events_text[587];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[561];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[571], "\n");
			a.data[6] += 20;
			a.data[8] -= 50;
			a.data[9] -= 30;
			if (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1))
			{
				a.data[1] += 50;
			}
			else
			{
				a.data[1] -= 50;
			}
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[572], "\n");
			a.data[6] += 20;
			a.data[8] -= 50;
			a.data[9] -= 30;
			if (a.IsFactionLeadeng(0))
			{
				a.data[1] += 50;
			}
			else
			{
				a.data[1] -= 50;
			}
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[573], "\n");
			break;
		}
	}
}
