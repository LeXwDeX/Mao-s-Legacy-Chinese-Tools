using EndingsDLCDraft;
using UnityEngine;

public class Ending4 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_texts[281];
		if (GlobalScript.inst.gameState.modifies[24].active)
		{
			text = GlobalScript.inst.new_texts[283];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(74);
			}
		}
		else if (GlobalScript.inst.gameState.modifies[25].active)
		{
			text = GlobalScript.inst.new_texts[284];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(75);
			}
		}
		else if (GlobalScript.inst.gameState.modifies[26].active)
		{
			text = GlobalScript.inst.new_texts[285];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(76);
			}
		}
		else if (GlobalScript.inst.gameState.modifies[27].active)
		{
			text = GlobalScript.inst.new_texts[286];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(77);
			}
		}
		else
		{
			text = GlobalScript.inst.new_texts[282];
		}
	}
}
