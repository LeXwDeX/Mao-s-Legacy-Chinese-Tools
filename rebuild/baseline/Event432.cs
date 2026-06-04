using EventsForDLC;
using UnityEngine;

public class Event432 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1454];
		text = string.Format(GlobalScript.inst.new_events_text[1455], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 250)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1456], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
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
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1457], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
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
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1458], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
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
		button_text[3] = GlobalScript.inst.new_events_text[1459];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1454];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		switch (result_num)
		{
		case 0:
			a.data[8] -= 100;
			a.data[9] -= 250;
			num3 += 2;
			break;
		case 1:
			a.data[8] -= 100;
			a.data[9] -= 250;
			a.allcountries[86].Gosstroy = 0;
			a.allcountries[86].SubGosstroy = 7;
			a.allcountries[87].spec -= 5;
			num2 += 2;
			break;
		case 2:
			a.data[8] -= 100;
			a.data[9] -= 250;
			num += 2;
			break;
		}
		if (a.allcountries[86].Gosstroy == 1)
		{
			num3 += 2;
			num2++;
		}
		else if (a.allcountries[86].Gosstroy == 3)
		{
			num += 2;
		}
		if (a.data[131] == 2)
		{
			num3++;
			num2++;
		}
		else if (a.data[131] == 1)
		{
			num2++;
		}
		else
		{
			num += 2;
		}
		if (a.allcountries[45].Gosstroy == 2)
		{
			num2 += 2;
			num3++;
		}
		else if (a.allcountries[45].Gosstroy == 1)
		{
			num3 += 2;
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[92].Gosstroy == 1)
		{
			num3++;
		}
		else if (a.allcountries[92].Gosstroy == 2)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[85].Gosstroy == 3)
		{
			num++;
		}
		else if (a.allcountries[85].Gosstroy == 2)
		{
			num2++;
		}
		else if (a.allcountries[85].Gosstroy == 1)
		{
			num3++;
		}
		num4 = ((num2 >= num3 && num2 >= num) ? 1 : ((num3 < num2 || num3 < num) ? 3 : 2));
		switch (num4)
		{
		case 1:
			a.allcountries[86].Gosstroy = 1;
			a.allcountries[86].SubGosstroy = 1;
			break;
		case 2:
			a.allcountries[86].Gosstroy = 2;
			a.allcountries[86].SubGosstroy = 11;
			a.allcountries[86].name = GlobalScript.inst.new_events_text[1463];
			break;
		default:
			a.allcountries[86].Gosstroy = 3;
			a.allcountries[86].SubGosstroy = 5;
			break;
		}
		text = string.Format(GlobalScript.inst.new_events_text[1459 + num4], "\n");
	}
}
