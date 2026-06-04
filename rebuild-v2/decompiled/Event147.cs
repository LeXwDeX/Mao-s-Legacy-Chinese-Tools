using System;
using EventsForDLC;
using UnityEngine;

public class Event147 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[507];
		text = GlobalScript.inst.new_texts[508];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[509];
		button_text[1] = GlobalScript.inst.new_texts[510];
		button_text[2] = GlobalScript.inst.new_texts[511];
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[507];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[5] = true;
		array[7] = true;
		array[3] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(83, array, partiesSup, 2f, 5);
			if (num == 5)
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
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(83, array, partiesSup, 2f, 7);
			if (num == 7)
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
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(83, array, partiesSup, 2f, 3);
			if (num == 3)
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
		GlobalScript.inst.gameState.allcountries[83].next_elections = new DateTime(1983, 12, 4);
		GlobalScript.inst.gameState.allcountries[83].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(83);
		if (GlobalScript.inst.gameState.allcountries[83].SubGosstroy == 5)
		{
			GlobalScript.inst.gameState.allcountries[83].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[83].level_of_dev += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[512], '|', GlobalScript.inst.gameState.allcountries[83].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[83].SubGosstroy == 7)
		{
			GlobalScript.inst.gameState.allcountries[83].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[83].level_of_dev -= 5;
			GlobalScript.inst.gameState.empires[0].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[513], '|', GlobalScript.inst.gameState.allcountries[83].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[83].SubGosstroy == 3)
		{
			GlobalScript.inst.gameState.allcountries[83].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[83].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[514], '|', GlobalScript.inst.gameState.allcountries[83].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
