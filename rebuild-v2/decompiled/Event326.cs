using EventsForDLC;
using UnityEngine;

public class Event326 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[233];
		text = string.Format(GlobalScript.inst.new_events_text[234]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		if (GlobalScript.inst.gameState.data[56] <= 1)
		{
			button_text[0] = GlobalScript.inst.new_events_text[235];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_texts[191]);
		}
		if (GlobalScript.inst.gameState.data[56] == 1 || GlobalScript.inst.gameState.data[56] == 2)
		{
			button_text[1] = GlobalScript.inst.new_events_text[236];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_texts[192]);
		}
		if (GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 3)
		{
			button_text[2] = GlobalScript.inst.new_events_text[237];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_texts[193]);
		}
		if (GlobalScript.inst.gameState.data[56] == 4)
		{
			button_text[3] = GlobalScript.inst.new_events_text[238];
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_texts[194]);
		}
		button_text[4] = GlobalScript.inst.new_events_text[239];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[233];
		switch (result_num)
		{
		case 0:
		{
			text = GlobalScript.inst.new_events_text[240];
			GlobalScript.inst.gameState.party_number[0] += 50;
			GlobalScript.inst.gameState.data[6] += 50;
			GlobalScript.inst.gameState.data[7]++;
			GlobalScript.inst.gameState.modifies[28].active = true;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] > 0)
				{
					politic.loyality = 0;
					politic.power -= 500;
				}
			}
			GlobalScript.inst.gameState.data[17] = 16;
			GlobalScript.inst.gameState.data[15] = 6;
			break;
		}
		case 1:
			text = GlobalScript.inst.new_events_text[241];
			GlobalScript.inst.gameState.party_number[1] += 50;
			GlobalScript.inst.gameState.party_number[2] += 50;
			GlobalScript.inst.gameState.data[3] += 25;
			GlobalScript.inst.gameState.data[4] += 15;
			GlobalScript.inst.gameState.data[17] += ((GlobalScript.inst.gameState.data[17] <= 18) ? 1 : (-1));
			GlobalScript.inst.gameState.data[15] -= ((GlobalScript.inst.gameState.data[15] > 7) ? (-1) : 0);
			GlobalScript.inst.gameState.modifies[29].active = true;
			if (GlobalScript.inst.gameState.data[15] > 7)
			{
				GlobalScript.inst.gameState.data[15] = 7;
			}
			break;
		case 2:
			text = GlobalScript.inst.new_events_text[242];
			GlobalScript.inst.gameState.party_number[2] += 50;
			GlobalScript.inst.gameState.party_number[3] += 50;
			GlobalScript.inst.gameState.data[4] += 15;
			GlobalScript.inst.gameState.data[17] += ((GlobalScript.inst.gameState.data[17] < 18) ? 1 : 0);
			GlobalScript.inst.gameState.data[16] += ((GlobalScript.inst.gameState.data[16] < 15) ? 1 : 0);
			GlobalScript.inst.gameState.data[6] -= 100;
			GlobalScript.inst.gameState.modifies[30].active = true;
			GlobalScript.inst.gameState.data[89] = 2;
			if (GlobalScript.inst.gameState.data[16] == 11)
			{
				GlobalScript.inst.gameState.data[16] = 12;
			}
			else if (GlobalScript.inst.gameState.data[16] < 13)
			{
				GlobalScript.inst.gameState.data[16] = 13;
			}
			break;
		case 3:
			text = GlobalScript.inst.new_events_text[243];
			GlobalScript.inst.gameState.party_number[4] += 50;
			GlobalScript.inst.gameState.data[16] += ((GlobalScript.inst.gameState.data[16] < 15) ? 1 : 0);
			GlobalScript.inst.gameState.data[15] += ((GlobalScript.inst.gameState.data[15] < 8) ? 1 : 0);
			GlobalScript.inst.gameState.data[6] -= 250;
			GlobalScript.inst.gameState.data[4] += 50;
			GlobalScript.inst.gameState.data[3] += 50;
			GlobalScript.inst.gameState.data[1] -= 50;
			GlobalScript.inst.gameState.modifies[31].active = true;
			GlobalScript.inst.gameState.data[89] = 2;
			if (GlobalScript.inst.gameState.data[16] < 14)
			{
				GlobalScript.inst.gameState.data[16] = 14;
			}
			if (GlobalScript.inst.gameState.data[17] < 17)
			{
				GlobalScript.inst.gameState.data[17] = 17;
			}
			break;
		case 4:
			text = GlobalScript.inst.new_events_text[244];
			GlobalScript.inst.gameState.data[1] += 50;
			break;
		}
	}
}
