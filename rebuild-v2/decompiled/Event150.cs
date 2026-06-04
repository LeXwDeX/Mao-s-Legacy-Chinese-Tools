using System;
using EventsForDLC;
using UnityEngine;

public class Event150 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[532];
		text = GlobalScript.inst.new_texts[533];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[534];
		if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy != 1)
		{
			button_text[1] = GlobalScript.inst.new_texts[535];
		}
		else
		{
			button_text[1] = GlobalScript.inst.new_texts[536];
		}
		if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 8)
		{
			button_text[2] = GlobalScript.inst.new_texts[537];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_texts[538];
		}
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[532];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[7] = true;
		if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy != 1)
		{
			array[1] = true;
		}
		else
		{
			array[8] = true;
		}
		if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 8)
		{
			array[9] = true;
		}
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(77, array, partiesSup, 2f, 7);
			if (num == 7)
			{
				GlobalScript.inst.gameState.allcountries[77].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[77].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 1) ? GlobalScript.inst.gameState.GetWinnerInAmerica(77, array, partiesSup, 2f, 8) : GlobalScript.inst.gameState.GetWinnerInAmerica(77, array, partiesSup, 2f, 1));
			if (num == 1 || num == 8)
			{
				GlobalScript.inst.gameState.allcountries[77].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[77].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(77, array, partiesSup, 2f, 9);
			if (num == 9)
			{
				GlobalScript.inst.gameState.allcountries[77].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[77].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(77, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[77].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[77].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[77].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[77].next_elections = new DateTime(1992, 12, 5);
		GlobalScript.inst.gameState.allcountries[77].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(77);
		if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 7)
		{
			GlobalScript.inst.gameState.allcountries[77].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[1].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[539], '|', GlobalScript.inst.gameState.allcountries[77].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 1)
		{
			GlobalScript.inst.gameState.allcountries[77].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[77].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power += 15;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[540], '|', GlobalScript.inst.gameState.allcountries[77].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 8)
		{
			GlobalScript.inst.gameState.allcountries[77].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[77].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power += 15;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(99);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[541], '|', GlobalScript.inst.gameState.allcountries[77].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 9)
		{
			GlobalScript.inst.gameState.allcountries[77].Gosstroy = 0;
			GlobalScript.inst.gameState.allcountries[77].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[77].level_of_dev -= 5;
			GlobalScript.inst.gameState.empires[0].power += 15;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(100);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[542], '|', GlobalScript.inst.gameState.allcountries[77].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
