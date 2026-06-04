using EndingsDLCDraft;
using UnityEngine;

public class Ending5 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_texts[287];
		if (GlobalScript.inst.gameState.completedDecisions[6])
		{
			if (GlobalScript.inst.gameState.allcountries[1].isSEV || GlobalScript.inst.gameState.empires[0].relations < 500 || GlobalScript.inst.gameState.data[6] > 500)
			{
				text = GlobalScript.inst.new_texts[289];
				return;
			}
			text = GlobalScript.inst.new_texts[290];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(66);
			}
		}
		else if (GlobalScript.inst.gameState.completedDecisions[7])
		{
			name = GlobalScript.inst.new_texts[291];
			text = GlobalScript.inst.new_texts[292];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(78);
			}
		}
		else
		{
			text = GlobalScript.inst.new_texts[288];
		}
	}
}
