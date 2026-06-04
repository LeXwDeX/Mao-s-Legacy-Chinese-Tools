using EventsForDLC;
using UnityEngine;

public class Event454 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[950];
		text = string.Format(GlobalScript.inst.new_texts[951], a.allcountries[27].isMonatchy ? GlobalScript.inst.new_texts[952] : "");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_texts[953];
		button_text[1] = GlobalScript.inst.new_texts[954];
		if (a.allcountries[27].isMonatchy)
		{
			button_text[2] = GlobalScript.inst.new_texts[955];
			return;
		}
		button[2].SetActive(value: false);
		button_text[2] = GlobalScript.inst.new_texts[956];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[937];
		GameState gameState = GlobalScript.inst.gameState;
		gameState.allcountries[4].isMonatchy = false;
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[957];
			gameState.allcountries[4].Gosstroy = 2;
			gameState.allcountries[4].SubGosstroy = 15;
			gameState.allcountries[4].Torg = true;
			gameState.allcountries[4].proprc = true;
			gameState.allcountries[4].isMonatchy = false;
			gameState.allcountries[4].prosov = false;
			gameState.empires[1].relations -= 100;
			gameState.influencePRC += 15;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[958];
			gameState.allcountries[4].Gosstroy = 2;
			gameState.allcountries[4].SubGosstroy = 8;
			gameState.allcountries[4].Torg = true;
			gameState.allcountries[4].proprc = true;
			gameState.allcountries[4].isMonatchy = false;
			gameState.allcountries[4].prosov = false;
			gameState.empires[1].relations -= 100;
			gameState.influencePRC += 15;
			break;
		case 2:
			if ((gameState.allcountries[1].isSEV && gameState.allcountries[1].isOVD) || ((!gameState.event_done[448] || gameState.resultOfEvents[448] == 2) && !gameState.allcountries[5].prosov && !gameState.allcountries[5].isMonatchy && gameState.allcountries[5].proprc && gameState.allcountries[5].isSEV && gameState.allcountries[5].isOVD))
			{
				text = string.Format(GlobalScript.inst.new_texts[960], (gameState.allcountries[1].isSEV && gameState.allcountries[1].isOVD) ? GlobalScript.inst.new_texts[961] : GlobalScript.inst.new_texts[962]);
				gameState.allcountries[27].parts[0] = true;
				gameState.allcountries[4].Gosstroy = 2;
				gameState.allcountries[4].SubGosstroy = 8;
				gameState.allcountries[4].Torg = true;
				gameState.allcountries[4].proprc = false;
				gameState.allcountries[4].isMonatchy = true;
				gameState.allcountries[4].prosov = false;
				gameState.allcountries[27].Torg = true;
				gameState.allcountries[27].proprc = false;
				gameState.allcountries[27].isMonatchy = true;
				gameState.allcountries[27].prosov = false;
				gameState.allcountries[27].isSEV = true;
				gameState.allcountries[4].isOVD = false;
				gameState.empires[1].relations -= 250;
				gameState.influencePRC += 50;
				gameState.allcountries[27].name = GlobalScript.inst.new_texts[968];
				gameState.allcountries[4].name = GlobalScript.inst.new_texts[968];
			}
			else
			{
				text = GlobalScript.inst.new_texts[959];
				gameState.allcountries[4].Gosstroy = 0;
				gameState.allcountries[4].SubGosstroy = 10;
				gameState.allcountries[4].Torg = false;
				gameState.allcountries[4].proprc = false;
				gameState.allcountries[4].isMonatchy = false;
				gameState.allcountries[4].prosov = true;
				gameState.empires[1].power += 50;
				gameState.empires[1].leaders[6].support -= 3;
			}
			break;
		}
	}
}
