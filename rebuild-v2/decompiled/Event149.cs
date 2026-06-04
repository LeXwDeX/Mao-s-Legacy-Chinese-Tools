using System;
using EventsForDLC;
using UnityEngine;

public class Event149 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[524];
		text = GlobalScript.inst.new_texts[525];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[526];
		button_text[1] = GlobalScript.inst.new_texts[527];
		button_text[2] = GlobalScript.inst.new_texts[528];
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[524];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[3] = true;
		array[1] = true;
		array[8] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(77, array, partiesSup, 2f, 3);
			if (num == 3)
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
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(77, array, partiesSup, 2f, 1);
			if (num == 1)
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
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(77, array, partiesSup, 2f, 8);
			if (num == 8)
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
		GlobalScript.inst.gameState.allcountries[77].next_elections = new DateTime(1985, 12, 9);
		GlobalScript.inst.gameState.allcountries[77].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(77);
		if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 3)
		{
			GlobalScript.inst.gameState.allcountries[77].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[77].level_of_dev -= 5;
			GlobalScript.inst.gameState.empires[1].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[529], '|', GlobalScript.inst.gameState.allcountries[77].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 1)
		{
			GlobalScript.inst.gameState.allcountries[77].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[77].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power += 15;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[530], '|', GlobalScript.inst.gameState.allcountries[77].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[77].SubGosstroy == 8)
		{
			GlobalScript.inst.gameState.allcountries[77].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[77].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power += 15;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[531], '|', GlobalScript.inst.gameState.allcountries[77].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
