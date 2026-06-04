using EventsForDLC;
using UnityEngine;

public class Event455 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[969];
		text = GlobalScript.inst.new_texts[970];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[971];
		if (a.resultOfEvents[76] == 3 && (a.resultOfEvents[66] == 2 || a.resultOfEvents[66] == 1))
		{
			button_text[1] = GlobalScript.inst.new_texts[972];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_texts[974];
		}
		if (a.resultOfEvents[76] == 3)
		{
			button_text[2] = GlobalScript.inst.new_texts[973];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_texts[975];
		}
		if (a.allcountries[1].SubGosstroy <= 3 || a.allcountries[1].SubGosstroy == 11 || a.allcountries[1].SubGosstroy >= 14)
		{
			button_text[3] = GlobalScript.inst.new_texts[1035];
			return;
		}
		button[3].SetActive(value: false);
		button_text[3] = GlobalScript.inst.new_texts[1036];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[971];
		GameState gameState = GlobalScript.inst.gameState;
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[976];
			gameState.data[9] -= 80;
			gameState.empires[0].relations -= 50;
			gameState.influencePRC -= 5;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[977];
			gameState.data[9] -= 80;
			gameState.data[8] -= 50;
			gameState.empires[0].relations -= 50;
			gameState.influencePRC -= 5;
			gameState.allcountries[15].isMonatchy = true;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[978];
			gameState.data[9] -= 80;
			gameState.data[8] -= 50;
			gameState.empires[0].relations -= 50;
			gameState.influencePRC -= 5;
			break;
		case 3:
			text = GlobalScript.inst.new_texts[1037];
			gameState.data[9] -= 80;
			gameState.empires[0].relations -= 50;
			gameState.influencePRC -= 5;
			break;
		}
	}
}
