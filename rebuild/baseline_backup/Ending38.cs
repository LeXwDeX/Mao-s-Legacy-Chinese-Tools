using System.Linq;
using EndingsDLCDraft;
using UnityEngine;

public class Ending38 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = inst.new_texts[1006];
		if (gameState.event_done[448] && gameState.resultOfEvents[448] == 0)
		{
			if ((GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8) && !GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.influencePRC >= 600)
			{
				text = inst.new_texts[1029];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(202);
				}
			}
			else if ((GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8) && !GlobalScript.inst.gameState.allcountries[1].isSEV)
			{
				text = inst.new_texts[1030];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(203);
				}
			}
			else
			{
				text = inst.new_texts[1007];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(197);
				}
			}
		}
		else if (gameState.event_done[448] && gameState.resultOfEvents[448] == 1)
		{
			if (GlobalScript.inst.gameState.allcountries.Count((Country c) => c.isSEV) < 15)
			{
				text = inst.new_texts[1031];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(204);
				}
			}
			else
			{
				text = inst.new_texts[1008];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(198);
				}
			}
		}
		else
		{
			text = inst.new_texts[1009];
		}
	}
}
