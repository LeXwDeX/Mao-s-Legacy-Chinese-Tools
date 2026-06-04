using EventsForDLC;
using UnityEngine;

public class Event390 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1050];
		if (a.data[155] <= 0)
		{
			a.data[155] = Random.Range(31, 40);
		}
		if (a.data[156] <= 0)
		{
			a.data[156] = Random.Range(20, 25);
		}
		text = string.Format(GlobalScript.inst.new_events_text[1051], "\n", a.data[155], a.data[156], (a.empires[1].now_leader == 1) ? GlobalScript.inst.new_events_text[1052] : ((a.empires[1].now_leader == 2) ? GlobalScript.inst.new_events_text[1053] : GlobalScript.inst.new_events_text[1054]));
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.influencePRC >= 500 && a.data[9] >= 150 && a.data[8] + a.data[36] >= 350 && (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2)))
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1052], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.influencePRC < 500)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[620], 50f);
		}
		else if (a.data[8] + a.data[36] < 350)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 35f);
		}
		else if (a.data[9] < 150)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_events_text[1054];
		}
		if (a.allcountries[1].isSEV)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1053], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_events_text[579];
		}
		button_text[2] = GlobalScript.inst.new_events_text[1047];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1043];
		int num = 0;
		if (a.allcountries[84].Gosstroy == 2)
		{
			num++;
		}
		if (!a.allcountries[85].isEU)
		{
			num++;
		}
		if (!a.allcountries[86].isEU)
		{
			num++;
		}
		if (!a.allcountries[87].isEU)
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
		if (a.empires[1].now_leader == 3)
		{
			num++;
		}
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
			num += 2;
			a.data[9] -= 150;
			a.data[8] -= 350;
			Debug.Log("za " + num);
			if (num >= 7)
			{
				text = string.Format(GlobalScript.inst.new_events_text[1055], "\n");
				a.allcountries[21].isEU = false;
				a.allcountries[21].isNATO = false;
				a.allcountries[21].Gosstroy = 1;
				a.allcountries[21].SubGosstroy = 2;
				a.empires[0].power -= 80;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[1056], "\n");
				a.allcountries[21].Gosstroy = 3;
				a.allcountries[21].SubGosstroy = 5;
				a.empires[0].power += 50;
			}
			break;
		case 1:
			num++;
			Debug.Log("za " + num);
			if (num >= 6)
			{
				text = string.Format(GlobalScript.inst.new_events_text[1057], "\n");
				a.allcountries[21].isEU = false;
				a.empires[0].power -= 50;
				a.empires[1].power += 30;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[1058], "\n");
				a.allcountries[21].Gosstroy = 3;
				a.allcountries[21].SubGosstroy = 5;
				a.empires[0].power += 50;
			}
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1059], "\n");
			a.allcountries[21].Gosstroy = 3;
			a.allcountries[21].SubGosstroy = 5;
			a.empires[0].power += 50;
			break;
		}
	}
}
