using EventsForDLC;
using UnityEngine;

public class Event120 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[235];
		text = GlobalScript.inst.new_texts[234];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[230];
		if (GlobalScript.inst.gameState.data[9] >= 250 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 250)
		{
			button_text[1] = GlobalScript.inst.new_texts[231];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_texts[236], 25);
		}
		button_text[2] = GlobalScript.inst.new_texts[232];
		if (GlobalScript.inst.gameState.data[9] >= 50 && !GlobalScript.inst.gameState.modifies[6].active && !GlobalScript.inst.gameState.modifies[3].active)
		{
			button_text[3] = GlobalScript.inst.new_texts[233];
			return;
		}
		button[3].SetActive(value: false);
		button_text[3] = string.Format(GlobalScript.inst.new_texts[237], 5);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[235];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[238];
			GlobalScript.inst.gameState.allcountries[10].numberOfSpecialEnding = 0;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[239];
			GlobalScript.inst.gameState.data[9] -= 250;
			GlobalScript.inst.gameState.data[8] -= 250;
			GlobalScript.inst.gameState.data[7] += 5;
			GlobalScript.inst.gameState.allcountries[10].numberOfSpecialEnding = 1;
			GlobalScript.inst.gameState.allcountries[10].JoinAllOurAlliances(yes: true);
			break;
		case 2:
			text = GlobalScript.inst.new_texts[240];
			GlobalScript.inst.gameState.data[6] += 50;
			GlobalScript.inst.gameState.allcountries[10].numberOfSpecialEnding = 2;
			break;
		case 3:
			text = GlobalScript.inst.new_texts[241];
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.data[9] -= 50;
			GlobalScript.inst.gameState.allcountries[10].numberOfSpecialEnding = 3;
			GlobalScript.inst.gameState.allcountries[10].JoinOurEconomicAlliance(yes: true);
			break;
		}
	}
}
