using System;
using EventsForDLC;
using UnityEngine;

public class Event148 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[515];
		text = GlobalScript.inst.new_texts[516];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[517];
		button_text[1] = GlobalScript.inst.new_texts[518];
		if (GlobalScript.inst.gameState.allcountries[83].SubGosstroy == 3)
		{
			button_text[2] = GlobalScript.inst.new_texts[519];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_texts[520], 25);
		}
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[515];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[4] = true;
		array[8] = true;
		if (GlobalScript.inst.gameState.allcountries[83].SubGosstroy == 3)
		{
			array[1] = true;
		}
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(83, array, partiesSup, 2f, 4);
			if (num == 4)
			{
				GlobalScript.inst.gameState.allcountries[83].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[83].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(83, array, partiesSup, 2f, 8);
			if (num == 8)
			{
				GlobalScript.inst.gameState.allcountries[83].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[83].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(83, array, partiesSup, 2f, 1);
			if (num == 1)
			{
				GlobalScript.inst.gameState.allcountries[83].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[83].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(83, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[83].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[83].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[83].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[83].next_elections = new DateTime(1988, 12, 4);
		GlobalScript.inst.gameState.allcountries[83].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(83);
		if (GlobalScript.inst.gameState.allcountries[83].SubGosstroy == 4)
		{
			GlobalScript.inst.gameState.allcountries[83].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[0].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[521], '|', GlobalScript.inst.gameState.allcountries[83].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[83].SubGosstroy == 8)
		{
			GlobalScript.inst.gameState.allcountries[83].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[83].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power += 5;
			GlobalScript.inst.gameState.empires[1].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[522], '|', GlobalScript.inst.gameState.allcountries[83].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[83].SubGosstroy == 1)
		{
			GlobalScript.inst.gameState.allcountries[83].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[83].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power += 5;
			GlobalScript.inst.gameState.allcountries[83].Gosstroy = 2;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(98);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[523], '|', GlobalScript.inst.gameState.allcountries[83].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
