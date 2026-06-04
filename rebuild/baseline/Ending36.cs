using EndingsDLCDraft;
using UnityEngine;

public class Ending36 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		GlobalScript inst = GlobalScript.inst;
		GameState gameState = inst.gameState;
		name = inst.new_texts[979];
		if (gameState.event_done[455] && gameState.resultOfEvents[455] == 0)
		{
			text = inst.new_texts[980];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(191);
			}
		}
		else if (gameState.allcountries[15].isMonatchy && gameState.resultOfEvents[455] == 1)
		{
			text = inst.new_texts[981];
			if ((GlobalScript.inst.gameState.empires[1].now_leader == 6 && ((GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[1].econ && GlobalScript.inst.gameState.allcountries[1].okb) || (GlobalScript.inst.gameState.allcountries[5].Torg && !GlobalScript.inst.gameState.allcountries[2].prosov && !GlobalScript.inst.gameState.allcountries[4].prosov && (GlobalScript.inst.gameState.allcountries[1].econ || GlobalScript.inst.gameState.allcountries[1].okb)))) || (gameState.allcountries[1].isOVD && gameState.influencePRC >= 600) || gameState.completedDecisions[9])
			{
				text += inst.new_texts[1038];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(192);
				}
			}
			else
			{
				text += inst.new_texts[1039];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(205);
				}
			}
		}
		else if (gameState.event_done[455] && gameState.resultOfEvents[455] == 2)
		{
			text = inst.new_texts[982];
			if (gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(193);
			}
		}
		else if (gameState.event_done[455] && gameState.resultOfEvents[455] == 3)
		{
			text = inst.new_texts[1040];
			if ((GlobalScript.inst.gameState.empires[1].now_leader == 6 && ((GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[1].econ && GlobalScript.inst.gameState.allcountries[1].okb) || (GlobalScript.inst.gameState.allcountries[5].Torg && !GlobalScript.inst.gameState.allcountries[2].prosov && !GlobalScript.inst.gameState.allcountries[4].prosov && (GlobalScript.inst.gameState.allcountries[1].econ || GlobalScript.inst.gameState.allcountries[1].okb)))) || (gameState.allcountries[1].isOVD && gameState.influencePRC >= 600) || gameState.completedDecisions[9])
			{
				text += inst.new_texts[1041];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(206);
				}
			}
			else
			{
				text += inst.new_texts[1042];
				if (gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(207);
				}
			}
		}
		else
		{
			text = inst.new_texts[983];
		}
	}
}
