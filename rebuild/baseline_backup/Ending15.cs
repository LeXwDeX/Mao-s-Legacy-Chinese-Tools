using EndingsDLCDraft;
using UnityEngine;

public class Ending15 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.modifies[38].active)
		{
			name = GlobalScript.inst.new_texts[570];
			text = GlobalScript.inst.new_texts[571];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(107);
			}
		}
		else
		{
			name = GlobalScript.inst.new_texts[570];
			text = GlobalScript.inst.new_texts[572];
		}
	}
}
