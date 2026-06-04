using EventsForDLC;
using UnityEngine;

public class Event397 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1114];
		text = string.Format(GlobalScript.inst.new_events_text[1116], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 100)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1117], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 10f);
		}
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 100)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1118], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 10f);
		}
		button_text[2] = GlobalScript.inst.new_events_text[1102];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1114];
		int num = 0;
		int num2 = 0;
		switch (result_num)
		{
		case 0:
			a.data[9] -= 100;
			a.data[8] -= 100;
			num += 2;
			break;
		case 1:
			a.data[9] -= 100;
			a.data[8] -= 100;
			num2 += 2;
			break;
		}
		if (a.allcountries[45].Gosstroy == 2)
		{
			num++;
		}
		if (a.resultOfEvents[49] == 1)
		{
			num++;
		}
		if (a.allcountries[21].SubGosstroy == 14)
		{
			num++;
		}
		if (a.allcountries[86].SubGosstroy == 14)
		{
			num++;
		}
		if (a.empires[1].power > a.empires[0].power)
		{
			num += 2;
		}
		if (a.resultOfEvents[67] == 3)
		{
			num--;
		}
		if (a.resultOfEvents[46] == 2)
		{
			num--;
		}
		if (a.data[131] == 3)
		{
			num2++;
		}
		if (a.allcountries[84].SubGosstroy == 9)
		{
			num2 += 2;
		}
		if (a.allcountries[84].SubGosstroy == 7)
		{
			num2++;
		}
		if (a.influencePRC > a.empires[0].power + a.empires[1].power)
		{
			num2++;
		}
		if (a.allcountries[86].Gosstroy == 0)
		{
			num2++;
		}
		if (a.allcountries[87].Gosstroy == 0)
		{
			num2++;
		}
		a.empires[0].power -= 50;
		a.allcountries[87].spec -= 15;
		if (num >= num2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1119], "\n");
			a.allcountries[85].isNATO = false;
			a.allcountries[85].isEU = false;
			a.allcountries[85].Vyshi = false;
			a.allcountries[85].inflCh = 10;
			a.empires[1].power += 30;
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1120], "\n");
			a.allcountries[85].inflNATO = 10;
			a.allcountries[85].isNATO = false;
			a.allcountries[85].isEU = false;
			a.allcountries[85].Vyshi = false;
		}
	}
}
