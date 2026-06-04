using EventsForDLC;
using UnityEngine;

public class Event443 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[703];
		text = GlobalScript.inst.new_texts[705];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		if (GlobalScript.inst.gameState.modifies[63].level == 0)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_texts[712]);
		}
		else if (GlobalScript.inst.gameState.data[16] <= 11 || GlobalScript.inst.gameState.data[16] >= 14)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_texts[713]);
		}
		else
		{
			button_text[0] = string.Format(GlobalScript.inst.new_texts[706]);
		}
		if (GlobalScript.inst.gameState.modifies[63].level == 1)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_texts[712]);
		}
		else if (GlobalScript.inst.gameState.data[16] <= 11 || GlobalScript.inst.gameState.data[16] >= 14)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_texts[713]);
		}
		else
		{
			button_text[1] = string.Format(GlobalScript.inst.new_texts[707]);
		}
		if (GlobalScript.inst.gameState.modifies[63].level == 1)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_texts[712]);
		}
		else if (GlobalScript.inst.gameState.data[16] <= 12)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_texts[713]);
		}
		else
		{
			button_text[2] = string.Format(GlobalScript.inst.new_texts[708]);
		}
		button_text[3] = string.Format(GlobalScript.inst.new_texts[709]);
		button_text[4] = string.Format(GlobalScript.inst.new_texts[710]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[703];
		text = string.Format(GlobalScript.inst.new_texts[714]);
		GlobalScript.inst.gameState.completedDecisions[36] = true;
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.modifies[63].level = 0;
			a.data[1] += 50;
			break;
		case 1:
		{
			GlobalScript.inst.gameState.modifies[63].level = 1;
			a.data[1] -= 50;
			a.data[6] -= 30;
			a.empires[0].relations += 50;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] == 0)
				{
					politic2.loyality -= 100;
				}
				else if (politic2.traits[0] >= 2)
				{
					politic2.power += 100;
				}
			}
			break;
		}
		case 2:
		{
			GlobalScript.inst.gameState.modifies[63].level = 2;
			a.data[4] += 25;
			a.data[1] -= 50;
			a.data[6] -= 30;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 0)
				{
					politic.loyality -= 100;
				}
				else if (politic.traits[0] >= 2)
				{
					politic.power += 100;
				}
			}
			break;
		}
		case 3:
			GlobalScript.inst.gameState.modifies[63].active = false;
			GlobalScript.inst.gameState.data[4] += 250;
			GlobalScript.inst.gameState.empires[0].relations -= 250;
			break;
		case 4:
			GlobalScript.inst.gameState.completedDecisions[36] = false;
			break;
		}
	}
}
