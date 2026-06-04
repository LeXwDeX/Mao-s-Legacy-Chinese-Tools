using System;
using EventsForDLC;
using UnityEngine;

public class Event137 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[423];
		text = GlobalScript.inst.new_texts[424];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[425];
		button_text[1] = GlobalScript.inst.new_texts[426];
		button_text[2] = GlobalScript.inst.new_texts[427];
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[423];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[4] = true;
		array[8] = true;
		array[3] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.resultOfEvents[136] > 1) ? GlobalScript.inst.gameState.GetWinnerInAmerica(82, array, partiesSup, 1.5f, 4) : GlobalScript.inst.gameState.GetWinnerInAmerica(82, array, partiesSup, 2f, 4));
			if (num == 4)
			{
				GlobalScript.inst.gameState.allcountries[82].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[82].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.resultOfEvents[136] > 1) ? GlobalScript.inst.gameState.GetWinnerInAmerica(82, array, partiesSup, 1.5f, 8) : GlobalScript.inst.gameState.GetWinnerInAmerica(82, array, partiesSup, 2f, 8));
			if (num == 8)
			{
				GlobalScript.inst.gameState.allcountries[82].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[82].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.resultOfEvents[136] != 1) ? GlobalScript.inst.gameState.GetWinnerInAmerica(82, array, partiesSup, 1.5f, 3) : GlobalScript.inst.gameState.GetWinnerInAmerica(82, array, partiesSup, 2f, 3));
			if (num == 3)
			{
				GlobalScript.inst.gameState.allcountries[82].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[82].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(82, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[82].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[82].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[82].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[82].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(82);
		GlobalScript.inst.gameState.allcountries[82].next_elections = new DateTime(1989, 11, 26);
		if (GlobalScript.inst.gameState.allcountries[82].SubGosstroy == 4)
		{
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[0].power += 5;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[428], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[82].SubGosstroy == 8)
		{
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[82].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(92);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[429], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[82].SubGosstroy == 3)
		{
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[82].level_of_dev += 10;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power += 5;
			GlobalScript.inst.gameState.allcountries[82].Vyshi = false;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[430], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
