using EndingsDLCDraft;
using UnityEngine;

public class Ending37 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = inst.new_texts[993];
		if (gameState.event_done[450] && gameState.resultOfEvents[450] == 0)
		{
			text = inst.new_texts[994];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(194);
			}
		}
		else if (gameState.event_done[450] && gameState.resultOfEvents[450] == 1)
		{
			text = inst.new_texts[995];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(195);
			}
		}
		else if (gameState.event_done[450] && gameState.resultOfEvents[450] == 2)
		{
			text = inst.new_texts[996];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(196);
			}
		}
		else
		{
			text = inst.new_texts[997];
		}
	}
}
