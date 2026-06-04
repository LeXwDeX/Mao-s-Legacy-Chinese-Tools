using EventsForDLC;
using UnityEngine;

public class Event380 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[884];
		text = string.Format(GlobalScript.inst.new_events_text[885], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[886];
		button_text[1] = GlobalScript.inst.new_events_text[887];
		button_text[2] = GlobalScript.inst.new_events_text[888];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[884];
		bool flag = false;
		bool flag2 = false;
		if (!a.relres && (a.allcountries[1].SubGosstroy == 16 || GlobalScript.inst.gameState.modifies[6].active))
		{
			GlobalScript.inst.gameState.SOV_PRC_PartiesConnection += 100;
		}
		if (!a.allcountries[20].proprc && a.allcountries[20].Gosstroy != 2)
		{
			a.allcountries[20].isSEV = true;
			a.allcountries[20].isOVD = true;
			a.allcountries[20].prosov = true;
			a.data[7] -= 15;
			a.empires[1].power += 50;
			flag = true;
		}
		if (a.allcountries[15].Gosstroy == 0 && a.allcountries[15].SubGosstroy == 0)
		{
			a.allcountries[15].isSEV = true;
			a.allcountries[15].isOVD = true;
			a.allcountries[15].prosov = true;
			a.data[7] -= 15;
			a.empires[1].power += 50;
			flag2 = true;
		}
		a.empires[1].power += 10;
		switch (result_num)
		{
		case 0:
		{
			text = string.Format(GlobalScript.inst.new_events_text[889], "\n", flag ? GlobalScript.inst.new_events_text[892] : null, flag2 ? GlobalScript.inst.new_events_text[893] : null);
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 0)
				{
					politic.power += 500;
				}
				else if (politic.traits[0] == 1)
				{
					politic.loyality -= 50;
				}
				else if (politic.traits[0] == 2)
				{
					politic.loyality -= 200;
				}
				else
				{
					politic.loyality -= 350;
				}
			}
			if (a.IsFactionLeadeng(0))
			{
				a.data[1] += 300;
			}
			else
			{
				a.data[1] -= 300;
			}
			a.empires[1].relations += 200;
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].relations += 200;
			}
			break;
		}
		case 1:
		{
			text = string.Format(GlobalScript.inst.new_events_text[890], "\n", flag ? GlobalScript.inst.new_events_text[892] : null, flag2 ? GlobalScript.inst.new_events_text[893] : null);
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] == 0)
				{
					politic2.power -= 500;
				}
				else if (politic2.traits[0] == 1)
				{
					politic2.loyality += 50;
				}
				else if (politic2.traits[0] == 2)
				{
					politic2.loyality += 200;
				}
				else
				{
					politic2.loyality += 350;
				}
			}
			if (a.IsFactionLeadeng(0))
			{
				a.data[1] -= 300;
			}
			else
			{
				a.data[1] += 150;
			}
			break;
		}
		default:
			text = string.Format(GlobalScript.inst.new_events_text[891], "\n", flag ? GlobalScript.inst.new_events_text[892] : null, flag2 ? GlobalScript.inst.new_events_text[893] : null);
			if (a.allcountries[1].isSEV)
			{
				a.empires[1].relations += 200;
			}
			break;
		}
	}
}
