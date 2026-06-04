using EventsForDLC;
using UnityEngine;

public class Event401 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1141];
		text = string.Format(GlobalScript.inst.new_events_text[1142], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (a.data[8] + a.data[36] >= 50 && a.data[9] >= 80)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1143], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 8f);
		}
		if (a.data[8] + a.data[36] >= 50 && a.data[9] >= 80)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1144], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 8f);
		}
		if (a.data[8] + a.data[36] >= 50 && a.data[9] >= 80)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1145], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[567], 8f);
		}
		button_text[3] = GlobalScript.inst.new_events_text[1102];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1141];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1146], "\n");
			a.allcountries[85].Gosstroy = 1;
			a.allcountries[85].SubGosstroy = 2;
			a.allcountries[85].inflCh = 11;
			a.allcountries[85].prosov = true;
			a.data[8] -= 50;
			a.data[9] -= 80;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1147], "\n");
			a.allcountries[85].Gosstroy = 2;
			a.allcountries[85].SubGosstroy = 3;
			a.allcountries[85].inflCh = 12;
			a.data[8] -= 50;
			a.data[9] -= 80;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1148], "\n");
			a.allcountries[85].Gosstroy = 3;
			a.allcountries[85].SubGosstroy = 4;
			a.allcountries[85].inflCh = 13;
			a.data[8] -= 50;
			a.data[9] -= 80;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1149], "\n");
			a.allcountries[85].isNATO = true;
			a.allcountries[85].isEU = true;
			a.allcountries[85].Vyshi = true;
			a.allcountries[85].SubGosstroy = 12;
			a.empires[0].power += 70;
			break;
		}
	}
}
