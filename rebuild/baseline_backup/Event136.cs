using System;
using EventsForDLC;
using UnityEngine;

public class Event136 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[414];
		text = GlobalScript.inst.new_texts[415];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (GlobalScript.inst.gameState.resultOfEvents[135] <= 1)
		{
			button_text[0] = GlobalScript.inst.new_texts[416];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_texts[417], 5);
		}
		if (GlobalScript.inst.gameState.resultOfEvents[135] == 0)
		{
			button_text[1] = GlobalScript.inst.new_texts[418];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_texts[419], 5);
		}
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[414];
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[82].SubGosstroy = 7;
			GlobalScript.inst.gameState.allcountries[82].proprc = true;
			GlobalScript.inst.gameState.WantToLeave(82);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[420], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[82].SubGosstroy = 6;
			GlobalScript.inst.gameState.allcountries[82].proprc = true;
			GlobalScript.inst.gameState.WantToLeave(82);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[421], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		default:
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[82].level_of_dev -= 5;
			GlobalScript.inst.gameState.allcountries[82].Gosstroy = 0;
			GlobalScript.inst.gameState.allcountries[82].SubGosstroy = 7;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[422], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		}
		GlobalScript.inst.gameState.allcountries[82].next_elections = new DateTime(1984, 11, 25);
	}
}
