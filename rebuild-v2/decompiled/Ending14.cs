using EndingsDLCDraft;
using UnityEngine;

public class Ending14 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.event_done[363])
		{
			if (GlobalScript.inst.gameState.resultOfEvents[363] == 1)
			{
				name = GlobalScript.inst.new_events_text[547];
				text = GlobalScript.inst.new_events_text[548];
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(103);
				}
			}
			else
			{
				name = GlobalScript.inst.new_events_text[557];
				text = GlobalScript.inst.new_events_text[558];
			}
		}
		else
		{
			name = GlobalScript.inst.new_events_text[557];
			text = GlobalScript.inst.new_events_text[558];
		}
	}
}
