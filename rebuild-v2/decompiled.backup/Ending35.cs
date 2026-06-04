using EndingsDLCDraft;
using UnityEngine;

public class Ending35 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = inst.new_texts[963];
		if (gameState.allcountries[27].isMonatchy && gameState.allcountries[4].isMonatchy)
		{
			text = inst.new_texts[966];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(190);
			}
		}
		else if (gameState.event_done[454] && gameState.resultOfEvents[454] == 0)
		{
			text = inst.new_texts[964];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(188);
			}
		}
		else if (gameState.event_done[454] && gameState.resultOfEvents[454] == 1)
		{
			text = inst.new_texts[965];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(189);
			}
		}
		else
		{
			text = inst.new_texts[967];
		}
	}
}
