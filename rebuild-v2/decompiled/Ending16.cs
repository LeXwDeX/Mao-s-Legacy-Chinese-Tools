using EndingsDLCDraft;
using UnityEngine;

public class Ending16 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.modifies[40].active)
		{
			name = GlobalScript.inst.new_texts[573];
			text = GlobalScript.inst.new_texts[574];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(108);
			}
		}
		else
		{
			name = GlobalScript.inst.new_texts[573];
			text = GlobalScript.inst.new_texts[575];
		}
	}
}
