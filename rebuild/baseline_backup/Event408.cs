using EventsForDLC;
using UnityEngine;

public class Event408 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1212];
		text = string.Format(GlobalScript.inst.new_events_text[1213], "\n");
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
			num3 = 100;
		}
		else if (num < 14)
		{
			num2 = 50;
			num3 = 200;
		}
		else
		{
			num2 = 70;
			num3 = 300;
		}
		if (a.data[8] + a.data[36] >= num)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1215], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214], num, (float)(num * 15) / 10f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], (float)num / 10f);
		}
		if (a.influencePRC >= num2)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1216], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214], (float)num2 / 10f, (float)(num * 15) / 10f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1219], (float)num2 / 10f);
		}
		if (!a.relres && a.data[8] + a.data[36] >= num3)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1217], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214], (float)num2 / 10f, (float)num3 / 10f);
		}
		else if (a.relres)
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[586];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], (float)num3 / 10f);
		}
		if (a.data[64] < 1 && !a.allcountries[51].Torg && a.data[8] + a.data[36] >= num3)
		{
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[1218], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214], (float)num2 / 10f, (float)num3 / 10f);
		}
		else if (a.allcountries[51].Torg)
		{
			button[3].SetActive(value: false);
			button_text[3] = GlobalScript.inst.new_events_text[1220];
		}
		else if (a.data[64] > 0)
		{
			button[3].SetActive(value: false);
			button_text[3] = GlobalScript.inst.new_events_text[1221];
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], (float)num3 / 10f);
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
			num3 = 100;
		}
		else if (num < 14)
		{
			num2 = 50;
			num3 = 200;
		}
		else
		{
			num2 = 70;
			num3 = 300;
		}
		name = GlobalScript.inst.new_events_text[1212];
		a.allcountries[1].dev = 0;
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1222], "\n", num, (float)(num * 15) / 10f);
			a.data[8] -= num * 10;
			a.data[22] += num * 15;
			a.allcountries[1].inflNATO = 1;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1223], "\n", (float)(num * 15) / 10f);
			a.allcountries[1].inflNATO = 1;
			a.data[22] += num * 15;
			a.influencePRC -= num2;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1224], "\n");
			a.allcountries[1].inflNATO = 1;
			a.data[8] -= num3;
			a.empires[1].relations -= 250;
			a.empires[1].power -= num2;
			break;
		case 3:
			text = string.Format(GlobalScript.inst.new_events_text[1225], "\n");
			a.allcountries[1].inflNATO = 1;
			a.data[8] -= num3;
			a.empires[0].relations -= 250;
			a.empires[0].power -= num2;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1226], "\n");
			break;
		}
	}
}
