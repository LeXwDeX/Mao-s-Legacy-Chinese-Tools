using EndingsDLCDraft;
using UnityEngine;

public class Ending32 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = inst.new_texts[902];
		if (gameState.modifies[66].active)
		{
			text = inst.new_texts[903];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(185);
			}
		}
		else
		{
			text = inst.new_texts[904];
		}
	}
}
