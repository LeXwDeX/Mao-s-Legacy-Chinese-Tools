using EventsForDLC;
using UnityEngine;

public class Event427 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1421];
		text = string.Format(GlobalScript.inst.new_events_text[1422], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 250)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1423], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 25f);
		}
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 250)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1424], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 25f);
		}
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 250)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1425], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[567], 25f);
		}
		button_text[3] = GlobalScript.inst.new_events_text[1426];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1421];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1427], "\n");
			a.data[8] -= 100;
			a.data[9] -= 250;
			a.allcountries[86].Gosstroy = 0;
			a.allcountries[86].SubGosstroy = 9;
			a.allcountries[87].spec -= 5;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1428], "\n");
			a.data[8] -= 100;
			a.data[9] -= 250;
			a.allcountries[86].Gosstroy = 0;
			a.allcountries[86].SubGosstroy = 7;
			a.allcountries[87].spec -= 5;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1429], "\n");
			a.data[8] -= 100;
			a.data[9] -= 250;
			a.allcountries[86].Gosstroy = 2;
			a.allcountries[86].SubGosstroy = 15;
			a.allcountries[87].spec -= 5;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1430], "\n");
			a.allcountries[87].spec += 5;
			break;
		}
	}
}
