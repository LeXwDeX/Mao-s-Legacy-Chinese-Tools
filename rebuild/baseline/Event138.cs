using System;
using EventsForDLC;
using UnityEngine;

public class Event138 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[431];
		text = GlobalScript.inst.new_texts[432];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[433];
		button_text[1] = GlobalScript.inst.new_texts[434];
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[431];
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[79].Gosstroy = 3;
			GlobalScript.inst.gameState.allcountries[79].SubGosstroy = 7;
			GlobalScript.inst.gameState.allcountries[79].proprc = true;
			GlobalScript.inst.gameState.WantToLeave(79);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[435], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 5;
			GlobalScript.inst.gameState.data[9] -= 5;
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[79].Torg = true;
			GlobalScript.inst.gameState.WantToLeave(79);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[436], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		default:
			GlobalScript.inst.gameState.allcountries[79].level_of_unstab -= 15;
			GlobalScript.inst.gameState.WantToLeave(79);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[436], '|', GlobalScript.inst.gameState.allcountries[79].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		}
		GlobalScript.inst.gameState.allcountries[79].next_elections = new DateTime(1983, 2, 6);
	}
}
