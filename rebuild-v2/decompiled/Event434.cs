using EventsForDLC;
using UnityEngine;

public class Event434 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1636];
		text = string.Format(GlobalScript.inst.new_events_text[1637], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[1638];
		button_text[1] = GlobalScript.inst.new_events_text[1639];
		button_text[2] = GlobalScript.inst.new_events_text[1640];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1636];
		GlobalScript.inst.gameState.allcountries[99].puppetOf = 85;
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1641], "\n");
			a.data[6] -= 10;
			a.empires[1].relations += 25;
			GlobalScript.inst.gameState.ingamewars[26].infl2 += 75;
			GlobalScript.inst.gameState.ingamewars[26].infl1 -= 75;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1641], "\n");
			a.data[8] -= 10;
			a.data[22] -= 25;
			a.empires[1].relations += 50;
			GlobalScript.inst.gameState.ingamewars[26].infl2 += 25;
			GlobalScript.inst.gameState.ingamewars[26].infl1 -= 25;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1641], "\n");
			a.data[8] += 5;
			a.empires[1].relations -= 25;
			GlobalScript.inst.gameState.allcountries[99].Torg = true;
			GlobalScript.inst.gameState.ingamewars[26].infl2 += 80;
			GlobalScript.inst.gameState.ingamewars[26].infl1 -= 80;
			break;
		}
	}
}
