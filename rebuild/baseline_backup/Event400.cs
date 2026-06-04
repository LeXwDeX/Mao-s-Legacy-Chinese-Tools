using EventsForDLC;
using UnityEngine;

public class Event400 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1133];
		text = string.Format(GlobalScript.inst.new_events_text[1134], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = string.Format(GlobalScript.inst.new_events_text[1135], "\n", a.names1[a.politics[a.politics_dolshnost[2]].name_1], a.names2[a.politics[a.politics_dolshnost[2]].name_2]);
		button_text[1] = GlobalScript.inst.new_events_text[1136];
		button_text[2] = GlobalScript.inst.new_events_text[1137];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1133];
		switch (result_num)
		{
		case 0:
		{
			text = string.Format(GlobalScript.inst.new_events_text[1138], "\n", a.names1[a.politics[a.politics_dolshnost[2]].name_1], a.names2[a.politics[a.politics_dolshnost[2]].name_2]);
			a.data[6] -= 10;
			a.empires[0].relations -= 150;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] == 0)
				{
					politic2.power -= 200;
				}
				else if (politic2.traits[0] > 1)
				{
					politic2.loyality += 200;
				}
			}
			if (a.IsFactionLeadeng(0))
			{
				a.data[1] -= 300;
			}
			else
			{
				a.data[1] += 200;
			}
			break;
		}
		case 1:
		{
			text = string.Format(GlobalScript.inst.new_events_text[1139], "\n");
			a.empires[0].relations -= 50;
			a.data[6] -= 5;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 0)
				{
					politic.power -= 100;
				}
				else if (politic.traits[0] > 1)
				{
					politic.loyality += 100;
				}
			}
			if (a.IsFactionLeadeng(0))
			{
				a.data[1] -= 200;
			}
			else
			{
				a.data[1] += 100;
			}
			break;
		}
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1140], "\n");
			break;
		}
	}
}
