using EndingsDLCDraft;
using UnityEngine;

public class Ending13 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.event_done[362])
		{
			if (GlobalScript.inst.gameState.resultOfEvents[362] == 0 || GlobalScript.inst.gameState.resultOfEvents[362] == 1)
			{
				name = GlobalScript.inst.new_events_text[545];
				text = GlobalScript.inst.new_events_text[546];
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(104);
				}
			}
			else
			{
				name = GlobalScript.inst.new_events_text[555];
				text = GlobalScript.inst.new_events_text[556];
			}
		}
		else
		{
			name = GlobalScript.inst.new_events_text[555];
			text = GlobalScript.inst.new_events_text[556];
		}
	}
}
