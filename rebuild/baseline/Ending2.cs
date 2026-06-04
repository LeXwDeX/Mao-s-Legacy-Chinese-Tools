using EndingsDLCDraft;
using UnityEngine;

public class Ending2 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding > 10)
		{
			GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = -1;
		}
		name = GlobalScript.inst.new_texts[248];
		if (GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding != 5)
		{
			text = GlobalScript.inst.new_texts[250 + GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding];
			if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding >= 0)
			{
				gameObject.GetComponent<achievements>().Set(70);
			}
		}
		else
		{
			text = GlobalScript.inst.new_texts[269];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(71);
			}
		}
	}
}
