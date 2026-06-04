using EventsForDLC;
using UnityEngine;

public class Event389 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1043];
		text = string.Format(GlobalScript.inst.new_events_text[1044], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.influencePRC >= 450 && a.data[9] >= 150)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1045], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.influencePRC < 450)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[620], 45f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		if (a.influencePRC >= 450 && a.data[9] >= 150)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1046], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.influencePRC < 450)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[620], 45f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		button_text[2] = GlobalScript.inst.new_events_text[1047];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1043];
		int num = 0;
		if (!a.allcountries[92].isEU)
		{
			num++;
		}
		if (!a.allcountries[85].isEU)
		{
			num++;
		}
		if (!a.allcountries[45].isEU)
		{
			num++;
		}
		if (a.allcountries[51].Torg)
		{
			num--;
		}
		if (a.allcountries[51].dev > 0)
		{
			num--;
		}
		num = ((a.empires[0].now_leader != 1) ? (num - 1) : (num + 1));
		int num2 = 0;
		for (int i = 0; i < a.allcountries.Length; i++)
		{
			if (a.allcountries[i].econ || (a.allcountries[1].isSEV && a.allcountries[i].isSEV))
			{
				num2++;
			}
		}
		if (num2 > 4)
		{
			num++;
		}
		else if (num2 > 9)
		{
			num += 2;
		}
		else if (num2 > 14)
		{
			num += 3;
		}
		num = ((a.data[7] <= a.empires[0].power) ? (num - 1) : (num + 1));
		switch (result_num)
		{
		case 0:
			num -= 2;
			a.data[9] -= 150;
			if (num > 5)
			{
				text = string.Format(GlobalScript.inst.new_events_text[1049], "\n");
				a.allcountries[21].Gosstroy = 2;
				a.allcountries[21].SubGosstroy = 3;
				a.allcountries[21].isEU = false;
				a.empires[0].power -= 30;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[1048], "\n");
				a.allcountries[21].SubGosstroy = 12;
				a.empires[0].power += 30;
			}
			break;
		case 1:
			num++;
			a.data[9] -= 150;
			if (num > 5)
			{
				text = string.Format(GlobalScript.inst.new_events_text[1049], "\n");
				a.allcountries[21].Gosstroy = 2;
				a.allcountries[21].SubGosstroy = 3;
				a.allcountries[21].isEU = false;
				a.empires[0].power -= 30;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[1048], "\n");
				a.allcountries[21].SubGosstroy = 12;
				a.empires[0].power += 30;
			}
			break;
		default:
			if (num > 5)
			{
				text = string.Format(GlobalScript.inst.new_events_text[1049], "\n");
				a.allcountries[21].Gosstroy = 2;
				a.allcountries[21].SubGosstroy = 3;
				a.allcountries[21].isEU = false;
				a.empires[0].power -= 30;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[1048], "\n");
				a.allcountries[21].SubGosstroy = 12;
				a.empires[0].power += 30;
			}
			break;
		}
	}
}
