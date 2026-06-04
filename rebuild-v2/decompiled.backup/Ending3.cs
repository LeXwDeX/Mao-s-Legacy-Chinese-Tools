using EndingsDLCDraft;
using UnityEngine;

public class Ending3 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_texts[263];
		if (GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding != 5)
		{
			text = GlobalScript.inst.new_texts[265 + GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding];
			if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.allcountries[70].numberOfSpecialEnding >= 0)
			{
				gameObject.GetComponent<achievements>().Set(72);
			}
		}
		else
		{
			text = GlobalScript.inst.new_texts[270];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(73);
			}
		}
	}
}
