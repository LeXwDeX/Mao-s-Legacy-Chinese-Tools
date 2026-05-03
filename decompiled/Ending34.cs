using EndingsDLCDraft;
using UnityEngine;

public class Ending34 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = inst.new_texts[946];
		if (gameState.resultOfEvents[453] == 0 && gameState.allcountries[27].isMonatchy && gameState.allcountries[4].isMonatchy)
		{
			text = inst.new_texts[947];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(190);
			}
		}
		else if (gameState.event_done[453] && gameState.resultOfEvents[453] == 0)
		{
			text = inst.new_texts[948];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(187);
			}
		}
		else
		{
			text = inst.new_texts[949];
		}
	}
}
