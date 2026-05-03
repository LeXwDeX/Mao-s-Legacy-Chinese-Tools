using System;
using EventsForDLC;
using UnityEngine;

public class Event139 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[437];
		text = GlobalScript.inst.new_texts[438];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[439];
		button_text[1] = GlobalScript.inst.new_texts[440];
		if (GlobalScript.inst.gameState.data[14] <= 3 && GlobalScript.inst.gameState.data[16] <= 12 && GlobalScript.inst.gameState.influencePRC >= 150)
		{
			button_text[2] = GlobalScript.inst.new_texts[442];
		}
		else
		{
			button_text[2] = GlobalScript.inst.new_texts[441];
		}
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[437];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[7] = true;
		array[6] = true;
		if (GlobalScript.inst.gameState.data[14] <= 3 && GlobalScript.inst.gameState.data[16] <= 12 && GlobalScript.inst.gameState.influencePRC >= 150)
		{
			array[3] = true;
		}
		else
		{
			array[4] = true;
		}
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(79, array, partiesSup, 2f, 7);
			if (num == 7)
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(79, array, partiesSup, 2f, 6);
			if (num == 6)
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = ((GlobalScript.inst.gameState.data[14] > 3 || GlobalScript.inst.gameState.data[16] > 12 || GlobalScript.inst.gameState.influencePRC < 150) ? GlobalScript.inst.gameState.GetWinnerInAmerica(79, array, partiesSup, 2f, 4) : GlobalScript.inst.gameState.GetWinnerInAmerica(79, array, partiesSup, 2f, 3));
			if (num == 3 || num == 4)
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(79, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[79].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[79].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[79].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(79);
		GlobalScript.inst.gameState.allcountries[79].next_elections = new DateTime(1989, 11, 26);
		if (GlobalScript.inst.gameState.allcountries[79].SubGosstroy == 7)
		{
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[0].power += 5;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[443], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[79].SubGosstroy == 6)
		{
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[79].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[444], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[79].SubGosstroy == 4)
		{
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[79].level_of_dev += 10;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power += 5;
			GlobalScript.inst.gameState.allcountries[79].Vyshi = false;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[445], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[79].SubGosstroy == 3)
		{
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[79].level_of_dev += 10;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power += 5;
			GlobalScript.inst.gameState.empires[0].relations -= 25;
			GlobalScript.inst.gameState.allcountries[79].Vyshi = false;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(93);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[446], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
