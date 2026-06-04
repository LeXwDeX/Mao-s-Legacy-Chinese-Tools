using EventsForDLC;
using UnityEngine;

public class Event125 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[302];
		text = GlobalScript.inst.new_texts[303];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[304];
		button_text[1] = GlobalScript.inst.new_texts[305];
		if (GlobalScript.inst.gameState.data[22] >= 250 && (GlobalScript.inst.gameState.influencePRC >= 350 || GlobalScript.inst.gameState.influencePRC >= 350) && GlobalScript.inst.gameState.allcountries[1].isSEV)
		{
			button_text[2] = GlobalScript.inst.new_texts[306];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_texts[307], 25);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[302];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[308];
			GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding = 0;
			GlobalScript.inst.gameState.allcountries[19].proprc = false;
			GlobalScript.inst.gameState.allcountries[19].prosov = false;
			GlobalScript.inst.gameState.allcountries[19].Vyshi = false;
			GlobalScript.inst.gameState.allcountries[19].Torg = false;
			GlobalScript.inst.gameState.ingamewars[7].name_war = GlobalScript.inst.new_texts[311];
			GlobalScript.inst.gameState.ingamewars[7].is_going = true;
			GlobalScript.inst.gameState.ingamewars[7].side1 = string.Format(GlobalScript.inst.new_texts[312], '|');
			GlobalScript.inst.gameState.ingamewars[7].side2 = string.Format(GlobalScript.inst.new_texts[313], '|');
			GlobalScript.inst.gameState.ingamewars[7].usa_place = 1;
			GlobalScript.inst.gameState.ingamewars[7].ussr_place = 0;
			GlobalScript.inst.gameState.ingamewars[7].infl1 = 400;
			GlobalScript.inst.gameState.ingamewars[7].infl2 = 600;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[309];
			GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding = 1;
			GlobalScript.inst.gameState.allcountries[19].proprc = false;
			GlobalScript.inst.gameState.allcountries[19].prosov = false;
			GlobalScript.inst.gameState.allcountries[19].Vyshi = false;
			GlobalScript.inst.gameState.allcountries[19].Torg = false;
			GlobalScript.inst.gameState.ingamewars[7].name_war = GlobalScript.inst.new_texts[311];
			GlobalScript.inst.gameState.ingamewars[7].is_going = true;
			GlobalScript.inst.gameState.ingamewars[7].side1 = string.Format(GlobalScript.inst.new_texts[314], '|');
			GlobalScript.inst.gameState.ingamewars[7].side2 = string.Format(GlobalScript.inst.new_texts[315], '|');
			GlobalScript.inst.gameState.ingamewars[7].usa_place = 0;
			GlobalScript.inst.gameState.ingamewars[7].ussr_place = 0;
			GlobalScript.inst.gameState.ingamewars[7].infl1 = 400;
			GlobalScript.inst.gameState.ingamewars[7].infl2 = 600;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[310];
			GlobalScript.inst.gameState.influencePRC += 30;
			GlobalScript.inst.gameState.empires[1].power += 30;
			GlobalScript.inst.gameState.allcountries[19].JoinAllOurAlliances(yes: true);
			GlobalScript.inst.gameState.allcountries[19].proprc = false;
			GlobalScript.inst.gameState.allcountries[19].prosov = false;
			GlobalScript.inst.gameState.allcountries[19].Vyshi = false;
			GlobalScript.inst.gameState.allcountries[19].Gosstroy = 1;
			GlobalScript.inst.gameState.allcountries[19].SubGosstroy = 1;
			GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding = 2;
			break;
		}
	}
}
