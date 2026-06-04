using System;
using EventsForDLC;
using UnityEngine;

public class Event126 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[337];
		text = GlobalScript.inst.new_texts[336];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[338];
		button_text[1] = GlobalScript.inst.new_texts[339];
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[337];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[7] = true;
		array[5] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(73, array, partiesSup, 2f, 7);
			if (num == 7)
			{
				GlobalScript.inst.gameState.allcountries[73].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[73].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(73, array, partiesSup, 2f, 5);
			if (num == 5)
			{
				GlobalScript.inst.gameState.allcountries[73].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[73].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(73, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[73].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[73].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[73].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[73].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(73);
		GlobalScript.inst.gameState.allcountries[73].next_elections = new DateTime(1985, 1, 15);
		if (GlobalScript.inst.gameState.allcountries[73].SubGosstroy == 7)
		{
			GlobalScript.inst.gameState.allcountries[73].level_of_unstab -= 15;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[341], '|', GlobalScript.inst.gameState.allcountries[73].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[73].SubGosstroy == 5)
		{
			GlobalScript.inst.gameState.allcountries[73].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[73].level_of_dev += 10;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[342], '|', GlobalScript.inst.gameState.allcountries[73].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
