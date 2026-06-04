using EventsForDLC;
using UnityEngine;

public class Event409 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1227];
		text = string.Format(GlobalScript.inst.new_events_text[1228], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		int num = 0;
		for (int i = 0; i < GlobalScript.inst.gameState.allcountries.Length; i++)
		{
			if (GlobalScript.inst.gameState.allcountries[i].okb)
			{
				num++;
			}
		}
		int num2 = 0;
		int num3 = 0;
		if (num < 7)
		{
			num2 = 30;
			num3 = 120;
		}
		else if (num < 14)
		{
			num2 = 50;
			num3 = 70;
		}
		else
		{
			num2 = 70;
			num3 = 50;
		}
		if (a.data[8] + a.data[36] >= num)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1229], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214], num, (float)(num * 15) / 10f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], (float)num / 10f);
		}
		if (a.data[9] >= num2)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1230], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214], (float)num2 / 10f, (float)(num * 15) / 10f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], (float)num2 / 10f);
		}
		if (!a.relres && a.data[9] >= num3)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1231], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214], (float)num2 / 10f, (float)num3 / 10f);
		}
		else if (a.relres)
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[586];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[567], (float)num3 / 10f);
		}
		if (!a.allcountries[51].Torg && a.data[9] >= num3)
		{
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[1232], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214], (float)num2 / 10f, (float)num3 / 10f);
		}
		else if (a.allcountries[51].Torg)
		{
			button[3].SetActive(value: false);
			button_text[3] = GlobalScript.inst.new_events_text[1220];
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[567], (float)num3 / 10f);
		}
		button_text[4] = GlobalScript.inst.new_events_text[1207];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		int num = 0;
		for (int i = 0; i < GlobalScript.inst.gameState.allcountries.Length; i++)
		{
			if (GlobalScript.inst.gameState.allcountries[i].okb)
			{
				num++;
			}
		}
		int num2 = 0;
		int num3 = 0;
		if (num < 7)
		{
			num2 = 30;
			num3 = 120;
		}
		else if (num < 14)
		{
			num2 = 50;
			num3 = 70;
		}
		else
		{
			num2 = 70;
			num3 = 50;
		}
		name = GlobalScript.inst.new_events_text[1212];
		a.allcountries[1].dev = 0;
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1233], "\n", num, (float)(num * 15) / 10f);
			a.data[8] -= num * 10;
			a.data[9] += num * 15;
			a.allcountries[1].inflCh = 1;
			break;
		case 1:
		{
			string text2 = "";
			for (int j = 0; j < a.allcountries.Length; j++)
			{
				if (a.allcountries[j].okb && a.allcountries[j].soc_stab < 800)
				{
					a.allcountries[j].soc_stab = 1000;
					text2 = text2 + a.allcountries[j].name + ",";
					a.allcountries[j].EstablishGovernment(Government.ProChina);
				}
			}
			text = string.Format(GlobalScript.inst.new_events_text[1234], "\n", text2);
			a.allcountries[1].inflCh = 1;
			a.data[9] -= num2;
			break;
		}
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1235], "\n");
			a.allcountries[1].inflCh = 1;
			a.data[9] -= num3;
			a.empires[1].relations -= 100;
			a.data[11] += 300;
			a.empires[1].power -= 10;
			break;
		case 3:
			text = string.Format(GlobalScript.inst.new_events_text[1236], "\n");
			a.allcountries[0].inflCh = 1;
			a.data[9] -= num3;
			a.empires[0].relations -= 100;
			a.data[11] += 300;
			a.empires[0].power -= 10;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1226], "\n");
			break;
		}
	}
}
