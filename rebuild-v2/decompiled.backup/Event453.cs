using EventsForDLC;
using UnityEngine;

public class Event453 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[937];
		text = GlobalScript.inst.new_texts[938];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[168] >= 100 && a.influencePRC >= 300)
		{
			button_text[0] = GlobalScript.inst.new_texts[939];
		}
		else if (a.data[168] < 100)
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_texts[923];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_texts[924];
		}
		if (a.data[9] >= 200)
		{
			button_text[1] = GlobalScript.inst.new_texts[940];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_texts[922];
		}
		button_text[2] = GlobalScript.inst.new_texts[921];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[937];
		GameState gameState = GlobalScript.inst.gameState;
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_texts[941], (gameState.resultOfEvents[46] == 4) ? GlobalScript.inst.new_texts[944] : GlobalScript.inst.new_texts[945]);
			gameState.allcountries[27].Gosstroy = 2;
			gameState.allcountries[27].SubGosstroy = 8;
			gameState.allcountries[27].Torg = true;
			gameState.allcountries[27].proprc = true;
			gameState.allcountries[27].isMonatchy = true;
			gameState.data[168] -= 100;
			gameState.data[169] += 100;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[942];
			gameState.data[9] -= 200;
			gameState.influencePRC += 5;
			gameState.empires[0].power -= 50;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[943];
			gameState.data[1] -= 250;
			break;
		}
	}
}
