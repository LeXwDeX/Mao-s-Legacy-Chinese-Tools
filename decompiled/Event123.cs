using EventsForDLC;
using UnityEngine;

public class Event123 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[271];
		text = GlobalScript.inst.new_texts[272];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[273];
		button_text[1] = GlobalScript.inst.new_texts[274];
		button_text[2] = GlobalScript.inst.new_texts[275];
		button_text[3] = GlobalScript.inst.new_texts[276];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[271];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[277];
			GlobalScript.inst.gameState.modifies[24].active = true;
			GlobalScript.inst.gameState.data[9] -= 50;
			GlobalScript.inst.gameState.data[4] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[278];
			GlobalScript.inst.gameState.data[1] -= 250;
			GlobalScript.inst.gameState.data[4] -= 25;
			GlobalScript.inst.gameState.modifies[25].active = true;
			GlobalScript.inst.gameState.data[7] -= 5;
			GlobalScript.inst.gameState.empires[1].power -= 25;
			if (GlobalScript.inst.gameState.data[50] < 28)
			{
				GlobalScript.inst.gameState.data[50] = 28;
			}
			break;
		case 2:
			text = GlobalScript.inst.new_texts[279];
			GlobalScript.inst.gameState.data[1] -= 50;
			GlobalScript.inst.gameState.data[3] -= 250;
			GlobalScript.inst.gameState.data[4] -= 25;
			GlobalScript.inst.gameState.modifies[26].active = true;
			if (GlobalScript.inst.gameState.data[17] < 16)
			{
				GlobalScript.inst.gameState.data[17] = 16;
			}
			break;
		case 3:
			text = GlobalScript.inst.new_texts[280];
			GlobalScript.inst.gameState.data[1] -= 250;
			GlobalScript.inst.gameState.data[3] -= 250;
			GlobalScript.inst.gameState.data[22] += 250;
			GlobalScript.inst.gameState.data[7] += 5;
			GlobalScript.inst.gameState.empires[0].relations -= 250;
			GlobalScript.inst.gameState.empires[1].relations -= 250;
			GlobalScript.inst.gameState.modifies[27].active = true;
			break;
		}
	}
}
