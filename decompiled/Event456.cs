using EventsForDLC;
using UnityEngine;

public class Event456 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[1010];
		text = GlobalScript.inst.new_texts[1011];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_texts[1012];
		button_text[1] = GlobalScript.inst.new_texts[1013];
		button_text[2] = GlobalScript.inst.new_texts[1014];
		button_text[3] = GlobalScript.inst.new_texts[1015];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[1010];
		GameState gameState = GlobalScript.inst.gameState;
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_texts[1016];
			gameState.data[8] -= 50;
			gameState.empires[1].relations -= 150;
			gameState.influencePRC += 15;
			gameState.allcountries[16].Gosstroy = 2;
			gameState.allcountries[16].SubGosstroy = 15;
			gameState.allcountries[16].Torg = true;
			break;
		case 1:
			text = GlobalScript.inst.new_texts[1017];
			gameState.data[9] -= 250;
			gameState.data[8] += 50;
			gameState.allcountries[16].Gosstroy = 2;
			gameState.allcountries[16].SubGosstroy = 15;
			gameState.allcountries[16].Torg = true;
			gameState.allcountries[16].prosov = false;
			gameState.allcountries[16].proprc = true;
			gameState.empires[1].relations -= 350;
			gameState.influencePRC -= 15;
			break;
		case 2:
			text = GlobalScript.inst.new_texts[1018];
			gameState.data[9] -= 150;
			gameState.data[8] -= 50;
			gameState.allcountries[16].Gosstroy = 1;
			gameState.allcountries[16].SubGosstroy = 2;
			gameState.allcountries[16].Torg = true;
			gameState.empires[1].relations -= 150;
			gameState.influencePRC -= 15;
			break;
		case 3:
			text = GlobalScript.inst.new_texts[1019];
			gameState.data[1] += 50;
			gameState.empires[1].relations += 50;
			break;
		}
	}
}
