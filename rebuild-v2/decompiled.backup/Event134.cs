using System;
using EventsForDLC;
using UnityEngine;

public class Event134 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[399];
		text = GlobalScript.inst.new_texts[400];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (GlobalScript.inst.gameState.resultOfEvents[133] == 1 && (GlobalScript.inst.gameState.relres || GlobalScript.inst.gameState.empires[1].relations >= 800))
		{
			button_text[0] = GlobalScript.inst.new_texts[401];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_texts[402], 5);
		}
		if (GlobalScript.inst.gameState.resultOfEvents[133] < 2)
		{
			button_text[1] = GlobalScript.inst.new_texts[403];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_texts[404], 5);
		}
		button_text[2] = GlobalScript.inst.new_texts[340];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[399];
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[74].level_of_unstab -= 5;
			GlobalScript.inst.gameState.allcountries[74].level_of_dev += 10;
			GlobalScript.inst.gameState.allcountries[74].Gosstroy = 1;
			GlobalScript.inst.gameState.allcountries[74].SubGosstroy = 2;
			GlobalScript.inst.gameState.allcountries[74].proprc = true;
			GlobalScript.inst.gameState.WantToLeave(74);
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(91);
			}
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[405], '|', GlobalScript.inst.gameState.allcountries[74].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		case 1:
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.allcountries[74].level_of_unstab -= 15;
			GlobalScript.inst.gameState.allcountries[74].SubGosstroy = 6;
			GlobalScript.inst.gameState.allcountries[74].proprc = true;
			GlobalScript.inst.gameState.WantToLeave(74);
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[406], '|', GlobalScript.inst.gameState.allcountries[74].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		default:
			GlobalScript.inst.gameState.allcountries[74].level_of_unstab -= 20;
			GlobalScript.inst.gameState.allcountries[74].level_of_dev -= 5;
			text = string.Format("{0} <color=red>{2}</color>", GlobalScript.inst.new_texts[407], '|', GlobalScript.inst.gameState.allcountries[74].proprc ? GlobalScript.inst.new_texts[344] : GlobalScript.inst.new_texts[343]);
			break;
		}
		GlobalScript.inst.gameState.allcountries[74].next_elections = new DateTime(1989, 12, 14);
	}
}
