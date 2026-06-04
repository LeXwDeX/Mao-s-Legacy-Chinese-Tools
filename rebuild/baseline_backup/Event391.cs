using EventsForDLC;
using UnityEngine;

public class Event391 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1060];
		text = string.Format(GlobalScript.inst.new_events_text[1061], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		if (a.data[8] + a.data[36] >= 30 && a.data[9] >= 40)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1062], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 4f);
		}
		if (a.data[8] + a.data[36] >= 30 && a.data[9] >= 40)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1063], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 4f);
		}
		if (a.data[8] + a.data[36] >= 60 && a.data[9] >= 80)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1064], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 60)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], 6f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[567], 8f);
		}
		if (a.data[8] + a.data[36] >= 60 && a.data[9] >= 100)
		{
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[1150], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 60)
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], 6f);
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[567], 10f);
		}
		button_text[4] = GlobalScript.inst.new_events_text[1065];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1060];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1066], "\n");
			a.data[9] -= 40;
			a.data[8] -= 30;
			a.data[1] -= 100;
			a.data[6] += 10;
			a.allcountries[85].inflCh = 1;
			a.empires[0].relations -= 50;
			a.empires[1].relations -= 50;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1067], "\n");
			a.data[9] -= 40;
			a.data[8] -= 30;
			a.data[1] -= 100;
			a.data[6] += 10;
			a.allcountries[85].inflNATO = 1;
			a.empires[0].relations -= 50;
			a.empires[1].relations -= 50;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1068], "\n");
			a.data[9] -= 80;
			a.data[8] -= 60;
			a.data[1] -= 100;
			a.data[6] += 10;
			a.allcountries[85].inflCh = 1;
			a.allcountries[85].inflNATO = 1;
			a.empires[0].relations -= 50;
			a.empires[1].relations -= 50;
			break;
		case 3:
			text = string.Format(GlobalScript.inst.new_events_text[1081], "\n");
			a.data[9] -= 100;
			a.data[8] -= 30;
			a.data[1] -= 100;
			a.data[6] -= 10;
			a.allcountries[85].inflCh = -1;
			a.allcountries[85].inflNATO = -1;
			a.empires[0].relations += 50;
			a.empires[1].relations += 50;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1069], "\n");
			break;
		}
	}
}
