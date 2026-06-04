using System;
using EventsForDLC;
using UnityEngine;

public class Event133 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[392];
		text = GlobalScript.inst.new_texts[393];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[394];
		button_text[1] = GlobalScript.inst.new_texts[395];
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[392];
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[74].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[74].Torg = true;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[396], '|', GlobalScript.inst.gameState.allcountries[74].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[74].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[74].SubGosstroy = 9;
			GlobalScript.inst.gameState.allcountries[74].Torg = false;
			GlobalScript.inst.gameState.allcountries[74].proprc = false;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[397], '|', GlobalScript.inst.gameState.allcountries[74].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		default:
			GlobalScript.inst.gameState.allcountries[74].level_of_unstab -= 15;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[398], '|', GlobalScript.inst.gameState.allcountries[74].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		}
		GlobalScript.inst.gameState.allcountries[74].next_elections = new DateTime(1980, 9, 11);
	}
}
