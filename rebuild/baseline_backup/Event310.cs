using EventsForDLC;
using UnityEngine;

public class Event310 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[98];
		text = string.Format(GlobalScript.inst.new_events_text[99]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[100];
		button_text[1] = GlobalScript.inst.new_events_text[101];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[98];
		switch (result_num)
		{
		case 0:
		{
			text = GlobalScript.inst.new_events_text[102];
			GlobalScript.inst.gameState.data[1] -= 150;
			int num2 = 0;
			for (int k = 0; k < GlobalScript.inst.gameState.politics.Length; k++)
			{
				if (GlobalScript.inst.gameState.politics[k].power < GlobalScript.inst.gameState.politics[num2].power)
				{
					num2 = k;
				}
			}
			GlobalScript.inst.gameState.politics[num2].name_1 = 27;
			GlobalScript.inst.gameState.politics[num2].name_2 = 17;
			GlobalScript.inst.gameState.politics[num2].age = (byte)(GlobalScript.inst.gameState.data[21] - 1902);
			GlobalScript.inst.gameState.politics[num2].traits[0] = 1;
			GlobalScript.inst.gameState.politics[num2].traits[1] = 6;
			GlobalScript.inst.gameState.politics[num2].traits[2] = 11;
			GlobalScript.inst.gameState.politics[num2].power = 1500;
			GlobalScript.inst.gameState.politics[num2].loyality = 500;
			break;
		}
		case 1:
		{
			text = GlobalScript.inst.new_events_text[103];
			int num = -1;
			for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
			{
				if (GlobalScript.inst.gameState.politics[i].name_1 == 27 && GlobalScript.inst.gameState.politics[i].name_2 == 17)
				{
					num = i;
					break;
				}
			}
			GlobalScript.inst.gameState.data[22] += 50;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] > 1)
				{
					politic.loyality -= 250;
					politic.power -= 250;
				}
			}
			if (num >= 0)
			{
				GlobalScript.inst.gameState.KillPerson(num);
			}
			break;
		}
		}
	}
}
