using System.Collections.Generic;
using System.Linq;
using EndingsDLCDraft;
using UnityEngine;

public class Ending6 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_texts[293];
		if (GlobalScript.inst.gameState.completedDecisions[9] && GlobalScript.inst.gameState.empires[1].now_leader == 6 && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC)
		{
			text = GlobalScript.inst.new_texts[294];
		}
		else if (GlobalScript.inst.gameState.completedDecisions[9] && GlobalScript.inst.gameState.empires[1].now_leader == 6 && !GlobalScript.inst.gameState.startedDirectWarsNum.Any((KeyValuePair<int, bool> k) => k.Key == 10 && k.Value))
		{
			text = GlobalScript.inst.new_texts[295];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(79);
			}
		}
		else
		{
			text = GlobalScript.inst.new_texts[296];
		}
	}
}
