using EventsForDLC;
using UnityEngine;

public class Event451 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[917];
		text = GlobalScript.inst.new_texts[918];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[9] >= 200 && a.data[168] >= 200 && a.influencePRC >= 100)
		{
			button_text[0] = GlobalScript.inst.new_texts[919];
		}
		else if (a.data[9] < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_texts[922];
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
			button_text[1] = GlobalScript.inst.new_texts[920];
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
		name = GlobalScript.inst.new_texts[917];
		GameState gameState = GlobalScript.inst.gameState;
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[925];
			gameState.data[168] -= 200;
			gameState.data[169] += 200;
			gameState.data[9] -= 200;
			gameState.influencePRC -= 5;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[926];
			gameState.data[9] -= 200;
			gameState.influencePRC += 5;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[927];
			break;
		}
	}
}
