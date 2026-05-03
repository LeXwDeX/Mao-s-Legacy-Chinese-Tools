using EndingsDLCDraft;
using UnityEngine;

public class Ending25 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		if (gameState.startedDirectWarsNum.ContainsKey(10) && !gameState.startedDirectWarsNum.ContainsKey(11))
		{
			name = inst.new_texts[831];
			text = inst.new_texts[837];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(173);
			}
		}
		else if (gameState.startedDirectWarsNum.ContainsKey(10) && gameState.startedDirectWarsNum.ContainsKey(11))
		{
			name = inst.new_texts[832];
			text = inst.new_texts[838];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(174);
			}
		}
		else
		{
			name = inst.new_texts[836];
			text = inst.new_texts[839];
		}
	}
}
