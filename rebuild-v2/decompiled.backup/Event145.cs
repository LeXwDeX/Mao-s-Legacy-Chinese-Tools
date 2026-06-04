using System;
using EventsForDLC;
using UnityEngine;

public class Event145 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[487];
		text = GlobalScript.inst.new_texts[488];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[489];
		button_text[1] = GlobalScript.inst.new_texts[490];
		button_text[2] = GlobalScript.inst.new_texts[491];
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[487];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[7] = true;
		array[6] = true;
		array[4] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(75, array, partiesSup, 2f, 7);
			if (num == 7)
			{
				GlobalScript.inst.gameState.allcountries[75].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[75].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(75, array, partiesSup, 2f, 6);
			if (num == 6)
			{
				GlobalScript.inst.gameState.allcountries[75].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[75].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(75, array, partiesSup, 2f, 4);
			if (num == 4)
			{
				GlobalScript.inst.gameState.allcountries[75].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[75].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(75, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[75].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[75].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[75].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[75].next_elections = new DateTime(1982, 5, 30);
		GlobalScript.inst.gameState.allcountries[75].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(75);
		if (GlobalScript.inst.gameState.allcountries[75].SubGosstroy == 7)
		{
			GlobalScript.inst.gameState.allcountries[75].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[0].power += 15;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[492], '|', GlobalScript.inst.gameState.allcountries[75].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[75].SubGosstroy == 6)
		{
			GlobalScript.inst.gameState.allcountries[75].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[75].level_of_dev += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[493], '|', GlobalScript.inst.gameState.allcountries[75].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[75].SubGosstroy == 4)
		{
			GlobalScript.inst.gameState.allcountries[75].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[75].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[494], '|', GlobalScript.inst.gameState.allcountries[75].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
