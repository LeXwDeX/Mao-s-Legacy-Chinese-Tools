using EventsForDLC;
using UnityEngine;

public class Event447 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[869];
		text = GlobalScript.inst.new_texts[870];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[871];
		button_text[1] = GlobalScript.inst.new_texts[872];
		button_text[2] = GlobalScript.inst.new_texts[873];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[869];
		GameState gameState = GlobalScript.inst.gameState;
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[874];
			gameState.allcountries[23].proprc = true;
			gameState.allcountries[23].prosov = false;
			gameState.allcountries[23].Vyshi = false;
			gameState.allcountries[23].Gosstroy = 0;
			gameState.data[1] += 50;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[875];
			gameState.allcountries[23].Gosstroy = 1;
			gameState.allcountries[23].SubGosstroy = 1;
			gameState.allcountries[23].stab = 1;
			gameState.data[9] -= 30;
			gameState.data[8] -= 30;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[876];
			gameState.war = 6;
			gameState.data[163] = 250;
			gameState.empires[1].relations -= 100;
			gameState.empires[0].relations -= 150;
			gameState.data[6] += 100;
			gameState.allcountries[23].proprc = false;
			gameState.allcountries[23].econ = false;
			gameState.allcountries[23].Torg = false;
			gameState.allcountries[23].puppetOf = -1;
			gameState.data[9] -= 30;
			gameState.data[8] -= 30;
			break;
		}
	}
}
