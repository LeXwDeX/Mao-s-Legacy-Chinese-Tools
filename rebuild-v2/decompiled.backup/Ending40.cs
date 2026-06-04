using EndingsDLCDraft;
using UnityEngine;

public class Ending40 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = inst.new_texts[1021];
		if (gameState.event_done[456] && gameState.resultOfEvents[456] == 0)
		{
			text = inst.new_texts[1022];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(199);
			}
		}
		else if (gameState.event_done[456] && gameState.resultOfEvents[456] == 1)
		{
			text = inst.new_texts[1023];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(200);
			}
		}
		else if (gameState.event_done[456] && gameState.resultOfEvents[456] == 2)
		{
			text = inst.new_texts[1024];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(201);
			}
		}
		else
		{
			text = inst.new_texts[1025];
		}
	}
}
