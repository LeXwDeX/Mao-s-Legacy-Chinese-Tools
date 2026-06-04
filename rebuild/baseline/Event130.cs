using System;
using EventsForDLC;
using UnityEngine;

public class Event130 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[372];
		text = GlobalScript.inst.new_texts[373];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[374];
		button_text[1] = GlobalScript.inst.new_texts[375];
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[372];
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[72].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[72].level_of_dev -= 10;
			GlobalScript.inst.gameState.allcountries[72].Torg = true;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[376], '|', GlobalScript.inst.gameState.allcountries[72].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		case 1:
			GlobalScript.inst.gameState.allcountries[72].Torg = true;
			GlobalScript.inst.gameState.allcountries[72].level_of_unstab -= 15;
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[377], '|', GlobalScript.inst.gameState.allcountries[72].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		default:
			GlobalScript.inst.gameState.allcountries[72].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[72].level_of_dev -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[376], '|', GlobalScript.inst.gameState.allcountries[72].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		}
		GlobalScript.inst.gameState.allcountries[72].Gosstroy = 3;
		GlobalScript.inst.gameState.allcountries[72].SubGosstroy = 7;
		GlobalScript.inst.gameState.allcountries[72].next_elections = new DateTime(1979, 7, 1);
	}
}
