using EventsForDLC;
using UnityEngine;

public class Event402 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1151];
		if (a.empires[0].now_leader == 1)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1153], "\n");
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1152], "\n");
		}
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1154];
		if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[2] == 2)
		{
			kolvo_variant = 2;
			button_text[0] = "美国需要新的领导！";
			button_text[1] = "看清我的嘴唇——不加新税！";
		}
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1151];
		int num = 0;
		int num2 = 0;
		if (GlobalScript.inst.gameState.empires[0].now_leader == 0)
		{
			num += 7;
		}
		if (a.empires[0].power > a.empires[1].power)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.empires[0].power > a.influencePRC)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[1].Gosstroy == 3)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[85].isNATO)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[92].isNATO)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[21].isNATO)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[84].isNATO)
		{
			num2++;
		}
		else
		{
			num++;
		}
		if (a.allcountries[1].isSEV)
		{
			num2--;
		}
		else
		{
			num++;
		}
		if (a.allcountries[1].isOVD)
		{
			num2--;
		}
		else
		{
			num++;
		}
		if (a.allcountries[15].cw)
		{
			num2++;
		}
		if (a.empires[1].now_leader == 3)
		{
			num2++;
		}
		if (a.allcountries[51].isASEAN)
		{
			num2++;
		}
		if (GlobalScript.inst.gameState.ingamewars[5].is_going)
		{
			num++;
		}
		if (a.resultOfEvents[67] == 3)
		{
			num++;
		}
		if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
		{
			num2++;
		}
		if (GlobalScript.inst.dlc[0])
		{
			if (GlobalScript.inst.gameState.gamerules[2] == 1)
			{
				num2 += Random.Range(-10, 10);
				num += Random.Range(-10, 10);
			}
			else if (GlobalScript.inst.gameState.gamerules[2] == 2)
			{
				if (result_num == 0)
				{
					num2 += 100;
				}
				else
				{
					num += 100;
				}
			}
		}
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if ((a.empires[0].now_leader == 0 && (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[2] != 2)) || (!a.allcountries[7].isNATO && num >= num2))
		{
			GlobalScript.inst.gameState.data[143] -= 5;
			if (a.empires[0].now_leader == 1)
			{
				a.empires[0].now_leader = 2;
			}
			a.allcountries[51].SubGosstroy = 12;
			if (a.empires[0].now_leader == 0)
			{
				text = string.Format(GlobalScript.inst.new_events_text[1155], "\n");
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[1156], "\n");
			}
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1157], "\n");
			a.empires[0].now_leader = 3;
			GlobalScript.inst.gameState.data[143] += 3;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(137);
			}
		}
	}
}
