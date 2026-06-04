using EndingsDLCDraft;
using UnityEngine;

public class Ending8 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_texts[333];
		if (GlobalScript.inst.gameState.completedDecisions[13])
		{
			text = GlobalScript.inst.new_texts[335];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(85);
			}
		}
		else
		{
			text = GlobalScript.inst.new_texts[334];
		}
	}
}
