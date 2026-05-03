using EventsForDLC;
using UnityEngine;

public class Event452 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[928];
		text = GlobalScript.inst.new_texts[929];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[9] >= 200 && a.allcountries[35].Torg && a.allcountries[37].Torg && a.allcountries[14].Torg)
		{
			button_text[0] = GlobalScript.inst.new_texts[930];
		}
		else if (a.data[9] < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_texts[922];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_texts[932];
		}
		if (a.allcountries[37].Torg)
		{
			button_text[1] = GlobalScript.inst.new_texts[931];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_texts[933];
		}
		button_text[2] = GlobalScript.inst.new_texts[921];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[928];
		GameState gameState = GlobalScript.inst.gameState;
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[934];
			gameState.data[9] -= 200;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[935];
			gameState.data[6] -= 25;
			gameState.data[1] -= 250;
			gameState.influencePRC += 5;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[936];
			break;
		}
	}
}
