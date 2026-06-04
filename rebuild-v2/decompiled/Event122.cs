using EventsForDLC;
using UnityEngine;

public class Event122 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[253];
		text = GlobalScript.inst.new_texts[254];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (GlobalScript.inst.gameState.relres)
		{
			button_text[0] = GlobalScript.inst.new_texts[255];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_texts[258], 25);
		}
		button_text[1] = GlobalScript.inst.new_texts[256];
		if (GlobalScript.inst.gameState.allcountries[51].Torg || GlobalScript.inst.gameState.data[18] >= 22)
		{
			button_text[2] = GlobalScript.inst.new_texts[257];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_texts[259], 5);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[253];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[260];
			GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding = 0;
			GlobalScript.inst.gameState.modifies[21].active = true;
			GlobalScript.inst.gameState.data[22] -= 50;
			GlobalScript.inst.gameState.empires[0].relations -= 250;
			GlobalScript.inst.gameState.empires[1].relations += 500;
			GlobalScript.inst.gameState.empires[1].power += 15;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[261];
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.data[8] -= 25;
			GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding = 1;
			GlobalScript.inst.gameState.modifies[22].active = true;
			GlobalScript.inst.gameState.empires[1].relations -= 250;
			GlobalScript.inst.gameState.data[7] += 5;
			GlobalScript.inst.gameState.empires[1].power -= 25;
			if (GlobalScript.inst.gameState.data[50] < 27)
			{
				GlobalScript.inst.gameState.data[50] += 2;
			}
			break;
		case 2:
			text = GlobalScript.inst.new_texts[262];
			GlobalScript.inst.gameState.data[6] -= 50;
			GlobalScript.inst.gameState.data[9] -= 25;
			GlobalScript.inst.gameState.data[22] -= 250;
			GlobalScript.inst.gameState.data[7] += 5;
			GlobalScript.inst.gameState.empires[0].relations += 500;
			GlobalScript.inst.gameState.empires[0].power += 50;
			GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding = 2;
			GlobalScript.inst.gameState.modifies[23].active = true;
			break;
		}
	}
}
