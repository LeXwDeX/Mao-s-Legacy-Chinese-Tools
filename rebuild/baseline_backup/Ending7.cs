using EndingsDLCDraft;
using UnityEngine;

public class Ending7 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_texts[316];
		if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding >= 0 && GlobalScript.inst.gameState.ingamewars[7].is_going)
		{
			text = GlobalScript.inst.new_texts[318];
		}
		else if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 0 && !GlobalScript.inst.gameState.ingamewars[7].is_going && GlobalScript.inst.gameState.ingamewars[7].infl1 >= 1000)
		{
			text = GlobalScript.inst.new_texts[319];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(80);
			}
		}
		else if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 0 && !GlobalScript.inst.gameState.ingamewars[7].is_going && GlobalScript.inst.gameState.ingamewars[7].infl2 >= 1000)
		{
			text = GlobalScript.inst.new_texts[320];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(81);
			}
		}
		else if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 1 && !GlobalScript.inst.gameState.ingamewars[7].is_going && GlobalScript.inst.gameState.ingamewars[7].infl1 >= 1000)
		{
			text = GlobalScript.inst.new_texts[321];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(82);
			}
		}
		else if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 1 && !GlobalScript.inst.gameState.ingamewars[7].is_going && GlobalScript.inst.gameState.ingamewars[7].infl2 >= 1000)
		{
			text = GlobalScript.inst.new_texts[322];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(83);
			}
		}
		else if (GlobalScript.inst.gameState.allcountries[19].numberOfSpecialEnding == 2)
		{
			text = GlobalScript.inst.new_texts[323];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(84);
			}
		}
		else
		{
			text = GlobalScript.inst.new_texts[317];
		}
	}
}
