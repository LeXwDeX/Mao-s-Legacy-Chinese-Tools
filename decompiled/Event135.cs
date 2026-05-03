using System;
using EventsForDLC;
using UnityEngine;

public class Event135 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[408];
		text = GlobalScript.inst.new_texts[409];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[410];
		button_text[1] = GlobalScript.inst.new_texts[411];
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[408];
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.allcountries[82].next_elections = new DateTime(1980, 10, 12);
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 10;
			GlobalScript.inst.gameState.allcountries[82].level_of_dev += 5;
			GlobalScript.inst.gameState.allcountries[82].SubGosstroy = 7;
			GlobalScript.inst.gameState.allcountries[82].proprc = true;
			GlobalScript.inst.gameState.WantToLeave(82);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[412], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		case 1:
			GlobalScript.inst.gameState.allcountries[82].next_elections = new DateTime(1981, 9, 1);
			GlobalScript.inst.gameState.data[8] -= 5;
			GlobalScript.inst.gameState.data[9] -= 5;
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[82].Torg = true;
			GlobalScript.inst.gameState.WantToLeave(82);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[413], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		default:
			GlobalScript.inst.gameState.allcountries[82].next_elections = new DateTime(1981, 9, 1);
			GlobalScript.inst.gameState.allcountries[82].level_of_unstab -= 15;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[413], '|', GlobalScript.inst.gameState.allcountries[82].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		}
	}
}
