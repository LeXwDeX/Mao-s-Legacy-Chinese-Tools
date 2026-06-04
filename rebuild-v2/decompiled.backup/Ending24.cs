using System.Collections.Generic;
using System.Linq;
using EndingsDLCDraft;
using UnityEngine;

public class Ending24 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		if (gameState.startedDirectWarsNum.Where((KeyValuePair<int, bool> w) => w.Value).Count() - gameState.startedDirectWarsNum.Where((KeyValuePair<int, bool> w) => (w.Key <= 2 || w.Key == 7 || w.Key == 10 || w.Key == 13 || w.Key == 15) && w.Value).Count() > 9)
		{
			name = inst.new_texts[827];
			text = inst.new_texts[833];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(171);
				if (gameState.allcountries.Where((Country c) => c.EAF).Count() >= 11)
				{
					gameObject.GetComponent<achievements>().Set(170);
				}
				IEnumerable<Country> source = gameState.allcountries.Where((Country c) => c.EAF);
				if (!source.Any((Country c) => c.Gosstroy != 0))
				{
					gameObject.GetComponent<achievements>().Set(181);
				}
				else if (!source.Any((Country c) => c.Gosstroy != 1))
				{
					gameObject.GetComponent<achievements>().Set(182);
				}
				else if (!source.Any((Country c) => c.Gosstroy != 2))
				{
					gameObject.GetComponent<achievements>().Set(183);
				}
				else if (!source.Any((Country c) => c.Gosstroy != 3))
				{
					gameObject.GetComponent<achievements>().Set(184);
				}
			}
		}
		else if (gameState.allcountries.Where((Country c) => c.EAF).Count() >= 11)
		{
			name = inst.new_texts[828];
			text = inst.new_texts[834];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(170);
				IEnumerable<Country> source2 = gameState.allcountries.Where((Country c) => c.EAF);
				if (!source2.Any((Country c) => c.Gosstroy != 0))
				{
					gameObject.GetComponent<achievements>().Set(181);
				}
				else if (!source2.Any((Country c) => c.Gosstroy != 1))
				{
					gameObject.GetComponent<achievements>().Set(182);
				}
				else if (!source2.Any((Country c) => c.Gosstroy != 2))
				{
					gameObject.GetComponent<achievements>().Set(183);
				}
				else if (!source2.Any((Country c) => c.Gosstroy != 3))
				{
					gameObject.GetComponent<achievements>().Set(184);
				}
			}
		}
		else
		{
			name = inst.new_texts[829];
			text = inst.new_texts[835];
		}
	}
}
