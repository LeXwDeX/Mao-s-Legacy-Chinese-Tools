using System;
using EventsForDLC;
using UnityEngine;

public class Event143 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[471];
		text = GlobalScript.inst.new_texts[472];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[473];
		button_text[1] = GlobalScript.inst.new_texts[474];
		button_text[2] = GlobalScript.inst.new_texts[475];
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[471];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[3] = true;
		array[5] = true;
		array[6] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(76, array, partiesSup, 2f, 3);
			if (num == 3)
			{
				GlobalScript.inst.gameState.allcountries[76].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[76].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(76, array, partiesSup, 2f, 5);
			if (num == 5)
			{
				GlobalScript.inst.gameState.allcountries[76].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[76].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(76, array, partiesSup, 2f, 6);
			if (num == 6)
			{
				GlobalScript.inst.gameState.allcountries[76].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[76].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(76, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[76].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[76].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[76].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[76].next_elections = new DateTime(1984, 1, 29);
		GlobalScript.inst.gameState.allcountries[76].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(76);
		if (GlobalScript.inst.gameState.allcountries[76].SubGosstroy == 3)
		{
			GlobalScript.inst.gameState.allcountries[76].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[76].level_of_dev += 10;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[476], '|', GlobalScript.inst.gameState.allcountries[76].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[76].SubGosstroy == 5)
		{
			GlobalScript.inst.gameState.allcountries[76].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[76].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[477], '|', GlobalScript.inst.gameState.allcountries[76].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[76].SubGosstroy == 6)
		{
			GlobalScript.inst.gameState.allcountries[76].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[478], '|', GlobalScript.inst.gameState.allcountries[76].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
