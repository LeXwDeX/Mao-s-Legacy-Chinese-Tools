using System;
using EventsForDLC;
using UnityEngine;

public class Event129 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[361];
		text = GlobalScript.inst.new_texts[362];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		button_text[0] = GlobalScript.inst.new_texts[363];
		button_text[1] = GlobalScript.inst.new_texts[364];
		button_text[2] = GlobalScript.inst.new_texts[365];
		if (GlobalScript.inst.gameState.allcountries[71].Gosstroy == 3)
		{
			button_text[3] = GlobalScript.inst.new_texts[366];
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_texts[367], 5);
		}
		button_text[4] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[361];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[4] = true;
		array[5] = true;
		array[3] = true;
		array[1] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.allcountries[71].Gosstroy != 3) ? GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup, 1.5f, 4) : GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup, 2f, 4));
			if (num == 4)
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.allcountries[71].Gosstroy != 3) ? GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup, 1.5f, 5) : GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup, 2f, 5));
			if (num == 5)
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.allcountries[71].Gosstroy != 3) ? GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup, 1.5f, 3) : GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup, 2f, 3));
			if (num == 3)
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = false;
			}
			break;
		case 3:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.allcountries[71].Gosstroy != 3) ? GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup, 1.5f, 1) : GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup, 2f, 1));
			if (num == 1)
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(71, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[71].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[71].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[71].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[71].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(71);
		GlobalScript.inst.gameState.allcountries[71].next_elections = new DateTime(1989, 7, 8);
		if (GlobalScript.inst.gameState.allcountries[71].SubGosstroy == 4)
		{
			GlobalScript.inst.gameState.allcountries[71].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[71].level_of_dev -= 5;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[368], '|', GlobalScript.inst.gameState.allcountries[71].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[71].SubGosstroy == 5)
		{
			GlobalScript.inst.gameState.allcountries[71].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[369], '|', GlobalScript.inst.gameState.allcountries[71].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[71].SubGosstroy == 3)
		{
			GlobalScript.inst.gameState.allcountries[71].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[71].level_of_dev += 10;
			GlobalScript.inst.gameState.empires[0].power -= 10;
			GlobalScript.inst.gameState.allcountries[71].Vyshi = false;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[370], '|', GlobalScript.inst.gameState.allcountries[71].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[71].SubGosstroy == 1)
		{
			GlobalScript.inst.gameState.allcountries[71].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[71].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power += 5;
			GlobalScript.inst.gameState.allcountries[71].Vyshi = false;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(89);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[371], '|', GlobalScript.inst.gameState.allcountries[71].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
