using EventsForDLC;
using UnityEngine;

public class Event420 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1357];
		text = string.Format(GlobalScript.inst.new_events_text[1358], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		int num = 100 - a.allcountries[87].spec;
		num /= 2;
		if (a.data[8] + a.data[36] >= 200 - num && a.data[9] >= 250 - num)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1359], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 20f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 25f);
		}
		if (a.data[8] + a.data[36] >= 200 - num && a.data[9] >= 250 - num)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1360], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 200)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 20f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 25f);
		}
		button_text[2] = GlobalScript.inst.new_events_text[1361];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1357];
		int num = 0;
		int num2 = 0;
		int num3 = 100 - a.allcountries[87].spec;
		num3 /= 2;
		switch (result_num)
		{
		case 0:
			num += 2;
			a.data[8] -= 200 - num3;
			a.data[9] -= 250 - num3;
			break;
		case 1:
			num2 += 2;
			a.data[8] -= 200 - num3;
			a.data[9] -= 250 - num3;
			break;
		}
		if (a.data[131] == 2)
		{
			num += 2;
		}
		else if (a.data[131] != 1)
		{
			num2 = ((a.data[131] != 3) ? (num2 + 1) : (num2 + 2));
		}
		else
		{
			num++;
		}
		if (a.allcountries[45].isNATO)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[85].Gosstroy == 2)
		{
			num++;
		}
		else if (a.allcountries[85].Gosstroy == 0)
		{
			num2++;
		}
		if (a.allcountries[84].Gosstroy == 2)
		{
			num++;
		}
		else if (a.allcountries[84].Gosstroy == 0)
		{
			num2++;
		}
		if (a.allcountries[86].Gosstroy == 2)
		{
			num++;
		}
		else if (a.allcountries[86].Gosstroy == 0)
		{
			num2 += 2;
		}
		if (a.empires[1].power >= a.empires[0].power)
		{
			num += 2;
		}
		else
		{
			num2 += 2;
		}
		if (num >= num2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1362], "\n");
			a.allcountries[87].Gosstroy = 1;
			a.allcountries[87].Vyshi = false;
			a.allcountries[87].SubGosstroy = 1;
			a.allcountries[87].isNATO = false;
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1363], "\n");
			a.allcountries[87].Gosstroy = 0;
			a.allcountries[87].Vyshi = false;
			a.allcountries[87].SubGosstroy = 7;
			a.allcountries[87].isNATO = false;
		}
	}
}
