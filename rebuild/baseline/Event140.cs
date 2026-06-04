using System;
using EventsForDLC;
using UnityEngine;

public class Event140 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[447];
		text = GlobalScript.inst.new_texts[448];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[449];
		button_text[1] = GlobalScript.inst.new_texts[450];
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[447];
		bool[] array = new bool[10];
		float[] partiesSup = new float[array.Length];
		array[7] = true;
		array[9] = true;
		int num = -1;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			num = GlobalScript.inst.gameState.GetWinnerInAmerica(79, array, partiesSup, 3f, 7);
			GlobalScript.inst.gameState.allcountries[79].Gosstroy = 3;
			if (num == 4)
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
			GlobalScript.inst.gameState.allcountries[79].Gosstroy = 3;
			num = ((GlobalScript.inst.gameState.resultOfEvents[138] != 1) ? GlobalScript.inst.gameState.GetWinnerInAmerica(79, array, partiesSup, 1.5f, 9) : GlobalScript.inst.gameState.GetWinnerInAmerica(79, array, partiesSup, 2f, 9));
			if (num == 9)
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[79].proprc = false;
			}
			break;
		default:
			num = GlobalScript.inst.gameState.allcountries[79].SubGosstroy;
			break;
		}
		GlobalScript.inst.gameState.allcountries[79].SubGosstroy = num;
		GlobalScript.inst.gameState.WantToLeave(79);
		GlobalScript.inst.gameState.allcountries[79].next_elections = new DateTime(1989, 5, 1);
		if (GlobalScript.inst.gameState.allcountries[79].SubGosstroy == 7)
		{
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 15;
			GlobalScript.inst.gameState.empires[0].power += 5;
			GlobalScript.inst.gameState.empires[1].power -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[451], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[79].SubGosstroy == 9)
		{
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 30;
			GlobalScript.inst.gameState.allcountries[79].level_of_dev -= 15;
			GlobalScript.inst.gameState.empires[0].power -= 15;
			GlobalScript.inst.gameState.empires[1].power -= 15;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[452], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else
		{
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[79].level_of_dev -= 5;
			GlobalScript.inst.gameState.empires[0].power += 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[453], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
