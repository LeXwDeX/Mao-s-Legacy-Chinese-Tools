using System;
using EventsForDLC;
using UnityEngine;

public class Event151 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[543];
		text = GlobalScript.inst.new_texts[544];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[545];
		button_text[1] = GlobalScript.inst.new_texts[546];
		button_text[2] = GlobalScript.inst.new_texts[547];
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[543];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[1] = true;
		array[8] = true;
		array[9] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(81, array, partiesSup, 4f, 1);
			if (num == 1)
			{
				GlobalScript.inst.gameState.allcountries[81].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[81].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(81, array, partiesSup, 2f, 8);
			if (num == 8)
			{
				GlobalScript.inst.gameState.allcountries[81].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[81].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(81, array, partiesSup, 4f, 9);
			if (num == 9)
			{
				GlobalScript.inst.gameState.allcountries[81].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[81].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(81, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[81].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[81].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[81].Gosstroy = 0;
		GlobalScript.inst.gameState.allcountries[81].next_elections = new DateTime(2222, 2, 22);
		GlobalScript.inst.gameState.allcountries[81].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(81);
		if (GlobalScript.inst.gameState.allcountries[81].SubGosstroy == 1)
		{
			GlobalScript.inst.gameState.allcountries[81].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[1].power += 5;
			GlobalScript.inst.gameState.empires[0].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[548], '|', GlobalScript.inst.gameState.allcountries[81].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[81].SubGosstroy == 8)
		{
			GlobalScript.inst.gameState.allcountries[81].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[81].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			GlobalScript.inst.gameState.empires[1].power += 5;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(101);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[549], '|', GlobalScript.inst.gameState.allcountries[81].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[81].SubGosstroy == 9)
		{
			GlobalScript.inst.gameState.allcountries[81].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[0].power += 15;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[550], '|', GlobalScript.inst.gameState.allcountries[81].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
