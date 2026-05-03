using EventsForDLC;
using UnityEngine;

public class Event121 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[0];
		text = GlobalScript.inst.new_events_text[1];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		int num = 0;
		if (GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding == 33)
		{
			button_text[0] = GlobalScript.inst.new_events_text[2];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[5], 25);
			num++;
		}
		if (GlobalScript.inst.gameState.data[6] <= 400 && !GlobalScript.inst.gameState.modifies[6].active && !GlobalScript.inst.gameState.modifies[3].active)
		{
			button_text[1] = GlobalScript.inst.new_events_text[3];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[6], 25);
			num++;
		}
		if (GlobalScript.inst.gameState.allcountries[7].Torg || GlobalScript.inst.gameState.allcountries[1].isSEV || num >= 2)
		{
			button_text[2] = GlobalScript.inst.new_events_text[4];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[7], 5);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[0];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[8];
			GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 0;
			GlobalScript.inst.gameState.modifies[18].active = true;
			return;
		case 1:
			text = GlobalScript.inst.new_events_text[9];
			GlobalScript.inst.gameState.data[9] -= 50;
			GlobalScript.inst.gameState.data[31] -= 250;
			GlobalScript.inst.gameState.data[7] += 15;
			GlobalScript.inst.gameState.empires[0].relations += 500;
			GlobalScript.inst.gameState.empires[0].power += 25;
			GlobalScript.inst.gameState.modifies[19].active = true;
			GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 1;
			return;
		}
		if (GlobalScript.inst.gameState.data[21] < 1982)
		{
			text = GlobalScript.inst.new_events_text[10];
			GlobalScript.inst.gameState.empires[1].power += 25;
			GlobalScript.inst.gameState.data[5] += 25;
		}
		else
		{
			text = GlobalScript.inst.new_events_text[11];
			GlobalScript.inst.gameState.empires[1].power += 50;
			GlobalScript.inst.gameState.data[7] += 5;
		}
		GlobalScript.inst.gameState.data[22] -= 50;
		GlobalScript.inst.gameState.data[31] -= 50;
		GlobalScript.inst.gameState.data[9] += 25;
		GlobalScript.inst.gameState.empires[0].relations -= 250;
		GlobalScript.inst.gameState.empires[1].relations += 500;
		GlobalScript.inst.gameState.modifies[20].active = true;
		GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 2;
	}
}
