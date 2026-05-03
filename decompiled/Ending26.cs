using EndingsDLCDraft;
using UnityEngine;

public class Ending26 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = string.Format(inst.new_texts[840], gameState.allcountries[33].name);
		if (gameState.allcountries[33].EAF)
		{
			text = inst.new_texts[842 + gameState.allcountries[33].Gosstroy];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(175);
			}
		}
		else
		{
			text = inst.new_texts[841];
		}
	}
}
