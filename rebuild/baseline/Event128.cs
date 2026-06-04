using System;
using EventsForDLC;
using UnityEngine;

public class Event128 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[355];
		text = GlobalScript.inst.new_texts[356];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[357];
		button_text[1] = GlobalScript.inst.new_texts[358];
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[355];
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 5;
			GlobalScript.inst.gameState.data[9] -= 5;
			GlobalScript.inst.gameState.allcountries[71].Torg = true;
			GlobalScript.inst.gameState.allcountries[71].Gosstroy = 0;
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[71].Gosstroy = 3;
			break;
		default:
			GlobalScript.inst.gameState.allcountries[71].proprc = false;
			GlobalScript.inst.gameState.allcountries[71].Gosstroy = 0;
			break;
		}
		GlobalScript.inst.gameState.allcountries[71].SubGosstroy = 7;
		GlobalScript.inst.gameState.WantToLeave(71);
		GlobalScript.inst.gameState.allcountries[71].next_elections = new DateTime(1983, 10, 30);
		if (GlobalScript.inst.gameState.allcountries[71].Gosstroy == 0)
		{
			GlobalScript.inst.gameState.allcountries[71].level_of_unstab -= 30;
			GlobalScript.inst.gameState.allcountries[71].level_of_dev -= 15;
			text = string.Format("{0}", GlobalScript.inst.new_texts[359], '|', GlobalScript.inst.gameState.allcountries[73].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
		else if (GlobalScript.inst.gameState.allcountries[71].Gosstroy == 3)
		{
			GlobalScript.inst.gameState.allcountries[71].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[71].Vyshi = false;
			GlobalScript.inst.gameState.empires[0].power -= 5;
			text = string.Format("{0}", GlobalScript.inst.new_texts[360], '|', GlobalScript.inst.gameState.allcountries[73].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
		}
	}
}
