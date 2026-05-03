using System;
using EventsForDLC;
using UnityEngine;

public class Event131 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[378];
		text = GlobalScript.inst.new_texts[379];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[380];
		button_text[1] = GlobalScript.inst.new_texts[381];
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[378];
		if (result_num == 0 && GlobalScript.inst.gameState.resultOfEvents[130] == 1)
		{
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[72].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[72].level_of_dev += 5;
			GlobalScript.inst.gameState.allcountries[72].proprc = true;
			GlobalScript.inst.gameState.allcountries[72].SubGosstroy = 4;
			GlobalScript.inst.gameState.WantToLeave(72);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[382], '|', GlobalScript.inst.gameState.allcountries[72].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (result_num == 1 && GlobalScript.inst.gameState.resultOfEvents[130] == 0)
		{
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[72].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[72].level_of_dev -= 5;
			GlobalScript.inst.gameState.allcountries[72].proprc = true;
			GlobalScript.inst.gameState.allcountries[72].SubGosstroy = 5;
			GlobalScript.inst.gameState.WantToLeave(72);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[383], '|', GlobalScript.inst.gameState.allcountries[72].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else
		{
			GlobalScript.inst.gameState.allcountries[72].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[72].proprc = false;
			GlobalScript.inst.gameState.allcountries[72].SubGosstroy = 8;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[384], '|', GlobalScript.inst.gameState.allcountries[72].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		GlobalScript.inst.gameState.allcountries[72].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[72].next_elections = new DateTime(1980, 6, 29);
	}
}
