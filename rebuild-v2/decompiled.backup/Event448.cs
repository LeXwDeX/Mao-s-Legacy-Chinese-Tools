using EventsForDLC;
using UnityEngine;

public class Event448 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[998];
		text = GlobalScript.inst.new_texts[999];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.allcountries[71].proprc && a.allcountries[73].proprc && a.allcountries[82].proprc)
		{
			button_text[0] = GlobalScript.inst.new_texts[1000];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_texts[1032];
		}
		if (a.data[9] >= 250 && a.ingamewars[0].infl1 >= 900)
		{
			button_text[1] = GlobalScript.inst.new_texts[1001];
		}
		else if (a.data[9] < 250)
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_texts[1003];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_texts[1027];
		}
		button_text[2] = GlobalScript.inst.new_texts[1002];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[998];
		GameState gameState = GlobalScript.inst.gameState;
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[1004];
			gameState.influencePRC += 5;
			gameState.data[8] -= 200;
			gameState.allcountries[5].prosov = false;
			gameState.allcountries[5].proprc = true;
			gameState.allcountries[5].SubGosstroy = 16;
			gameState.allcountries[5].Torg = true;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[1005];
			gameState.influencePRC += 5;
			gameState.data[9] -= 250;
			gameState.data[8] -= 200;
			gameState.allcountries[5].prosov = false;
			gameState.allcountries[5].proprc = true;
			gameState.allcountries[5].Torg = true;
			gameState.allcountries[5].isMonatchy = true;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[1002];
			gameState.completedDecisions[38] = false;
			break;
		}
	}
}
