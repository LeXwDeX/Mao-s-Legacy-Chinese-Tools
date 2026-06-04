using EndingsDLCDraft;
using UnityEngine;

public class Ending31 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = string.Format(inst.new_texts[840], gameState.allcountries[44].name);
		if (gameState.allcountries[44].EAF)
		{
			text = string.Format(inst.new_texts[862], inst.new_texts[863 + gameState.allcountries[44].Gosstroy]);
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(180);
			}
		}
		else
		{
			text = inst.new_texts[841];
		}
	}
}
