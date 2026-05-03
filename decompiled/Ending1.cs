using EndingsDLCDraft;
using UnityEngine;

public class Ending1 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_texts[242];
		text = GlobalScript.inst.new_texts[244 + GlobalScript.inst.gameState.allcountries[10].numberOfSpecialEnding];
		if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.allcountries[10].numberOfSpecialEnding >= 0)
		{
			gameObject.GetComponent<achievements>().Set(69);
		}
	}
}
