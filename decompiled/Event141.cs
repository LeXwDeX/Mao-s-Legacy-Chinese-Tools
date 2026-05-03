using System;
using EventsForDLC;
using UnityEngine;

public class Event141 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[453];
		text = GlobalScript.inst.new_texts[454];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[455];
		button_text[1] = GlobalScript.inst.new_texts[456];
		if (GlobalScript.inst.gameState.modifies[6].active && GlobalScript.inst.gameState.data[14] <= 3 && GlobalScript.inst.gameState.data[16] <= 12 && GlobalScript.inst.gameState.influencePRC >= 150)
		{
			button_text[2] = GlobalScript.inst.new_texts[457];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_texts[458];
		}
		button_text[3] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[453];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[5] = true;
		array[3] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(80, array, partiesSup, 2f, 5);
			GlobalScript.inst.gameState.allcountries[80].Gosstroy = 3;
			GlobalScript.inst.gameState.allcountries[80].next_elections = new DateTime(1985, 4, 14);
			if (num == 5)
			{
				GlobalScript.inst.gameState.allcountries[80].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[80].proprc = false;
			}
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[80].Gosstroy = 3;
			GlobalScript.inst.gameState.allcountries[80].next_elections = new DateTime(1985, 4, 14);
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(80, array, partiesSup, 2f, 3);
			if (num == 3)
			{
				GlobalScript.inst.gameState.allcountries[80].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[80].proprc = false;
			}
			break;
		case 2:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = 0;
			break;
		default:
			GlobalScript.inst.gameState.allcountries[80].Gosstroy = 3;
			GlobalScript.inst.gameState.allcountries[80].next_elections = new DateTime(1985, 4, 14);
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(80, array, partiesSup);
			if (num != GlobalScript.inst.gameState.allcountries[80].SubGosstroy)
			{
				GlobalScript.inst.gameState.allcountries[80].proprc = false;
			}
			break;
		}
		GlobalScript.inst.gameState.allcountries[80].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(80);
		if (GlobalScript.inst.gameState.allcountries[80].SubGosstroy == 5)
		{
			GlobalScript.inst.gameState.allcountries[80].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[80].level_of_dev += 5;
			GlobalScript.inst.gameState.empires[0].power += 15;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[459], '|', GlobalScript.inst.gameState.allcountries[80].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[80].SubGosstroy == 3)
		{
			GlobalScript.inst.gameState.allcountries[80].level_of_unstab += 10;
			GlobalScript.inst.gameState.allcountries[80].level_of_dev += 25;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[460], '|', GlobalScript.inst.gameState.allcountries[80].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[72].SubGosstroy < 6 || GlobalScript.inst.gameState.allcountries[73].SubGosstroy < 6 || GlobalScript.inst.gameState.allcountries[74].SubGosstroy < 6)
		{
			GlobalScript.inst.gameState.allcountries[80].Gosstroy = 1;
			GlobalScript.inst.gameState.allcountries[80].proprc = true;
			GlobalScript.inst.gameState.allcountries[80].next_elections = new DateTime(2222, 2, 22);
			GlobalScript.inst.gameState.allcountries[80].level_of_unstab -= 30;
			GlobalScript.inst.gameState.allcountries[80].level_of_dev -= 15;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power -= 15;
			GlobalScript.inst.gameState.influencePRC += 15;
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(94);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[462], '|', GlobalScript.inst.gameState.allcountries[80].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else
		{
			GlobalScript.inst.gameState.allcountries[80].SubGosstroy = 5;
			GlobalScript.inst.gameState.allcountries[80].Gosstroy = 3;
			GlobalScript.inst.gameState.allcountries[80].proprc = false;
			GlobalScript.inst.gameState.allcountries[80].next_elections = new DateTime(1985, 4, 14);
			GlobalScript.inst.gameState.allcountries[80].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[80].level_of_dev -= 5;
			GlobalScript.inst.gameState.empires[0].power += 15;
			GlobalScript.inst.gameState.influencePRC -= 15;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[461], '|', GlobalScript.inst.gameState.allcountries[80].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
