using EventsForDLC;
using UnityEngine;

public class Event450 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[984];
		text = GlobalScript.inst.new_texts[985];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[986];
		if (a.allcountries[8].SubGosstroy == 9 && a.ingamewars[4].infl1 < 900)
		{
			button_text[1] = GlobalScript.inst.new_texts[987];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_texts[989];
		}
		button_text[2] = GlobalScript.inst.new_texts[988];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[984];
		GameState gameState = GlobalScript.inst.gameState;
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[990];
			gameState.influencePRC += 5;
			gameState.data[9] -= 80;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[991];
			gameState.influencePRC += 5;
			gameState.data[9] -= 80;
			gameState.allcountries[3].isMonatchy = true;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[992];
			gameState.influencePRC -= 5;
			gameState.data[9] -= 80;
			gameState.allcountries[3].prosov = false;
			gameState.allcountries[3].proprc = true;
			break;
		}
	}
}
