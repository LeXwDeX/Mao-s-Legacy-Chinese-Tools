using EndingsDLCDraft;
using UnityEngine;

public class Ending11 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.event_done[318])
		{
			if (GlobalScript.inst.gameState.allcountries[44].EAF)
			{
				text = string.Format(GlobalScript.inst.new_texts[862], GlobalScript.inst.new_texts[863 + GlobalScript.inst.gameState.allcountries[44].Gosstroy]);
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(180);
				}
			}
			else if (GlobalScript.inst.gameState.resultOfEvents[318] == 1)
			{
				name = GlobalScript.inst.new_events_text[537];
				text = GlobalScript.inst.new_events_text[538];
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(105);
				}
			}
			else if (GlobalScript.inst.gameState.resultOfEvents[318] == 2)
			{
				name = GlobalScript.inst.new_events_text[539];
				text = GlobalScript.inst.new_events_text[540];
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(106);
				}
			}
			else
			{
				name = GlobalScript.inst.new_events_text[551];
				text = GlobalScript.inst.new_events_text[552];
			}
		}
		else
		{
			name = GlobalScript.inst.new_events_text[551];
			text = GlobalScript.inst.new_events_text[552];
		}
	}
}
