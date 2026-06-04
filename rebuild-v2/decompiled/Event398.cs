using EventsForDLC;
using UnityEngine;

public class Event398 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1121];
		text = string.Format(GlobalScript.inst.new_events_text[1122], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (a.data[8] + a.data[36] >= 50 && a.data[9] >= 80)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1123], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
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
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1124], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
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
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1125], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
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
		name = GlobalScript.inst.new_events_text[1121];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1126], "\n");
			a.allcountries[85].Gosstroy = 2;
			a.allcountries[85].SubGosstroy = 8;
			a.allcountries[85].inflNATO = 11;
			a.data[8] -= 50;
			a.data[9] -= 80;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1127], "\n");
			a.allcountries[85].Gosstroy = 0;
			a.allcountries[85].SubGosstroy = 9;
			a.allcountries[85].inflNATO = 12;
			a.data[8] -= 50;
			a.data[9] -= 80;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1128], "\n");
			a.allcountries[85].SubGosstroy = 5;
			a.allcountries[85].inflNATO = 13;
			a.data[8] -= 50;
			a.data[9] -= 80;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1129], "\n");
			a.allcountries[85].isNATO = true;
			a.allcountries[85].isEU = true;
			a.allcountries[85].Vyshi = true;
			a.allcountries[85].SubGosstroy = 12;
			a.empires[0].power += 70;
			break;
		}
	}
}
