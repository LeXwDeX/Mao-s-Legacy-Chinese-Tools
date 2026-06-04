using EndingsDLCDraft;
using UnityEngine;

public class Ending33 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = inst.new_texts[905];
		if (gameState.allcountries[27].isMonatchy && gameState.allcountries[4].isMonatchy && gameState.allcountries[3].isMonatchy && gameState.allcountries[16].isMonatchy && gameState.allcountries[5].isMonatchy && gameState.allcountries[15].isMonatchy)
		{
			text = inst.new_texts[906];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(186);
			}
		}
		else
		{
			text = inst.new_texts[907];
		}
	}
}
