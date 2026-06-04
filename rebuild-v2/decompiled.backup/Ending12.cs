using EndingsDLCDraft;
using UnityEngine;

public class Ending12 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.event_done[360])
		{
			if (GlobalScript.inst.gameState.resultOfEvents[360] == 0)
			{
				name = GlobalScript.inst.new_events_text[541];
				text = GlobalScript.inst.new_events_text[542];
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(102);
				}
			}
			else if (GlobalScript.inst.gameState.resultOfEvents[360] == 1)
			{
				name = GlobalScript.inst.new_events_text[543];
				text = GlobalScript.inst.new_events_text[544];
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(102);
				}
			}
			else
			{
				name = GlobalScript.inst.new_events_text[553];
				text = GlobalScript.inst.new_events_text[554];
			}
		}
		else
		{
			name = GlobalScript.inst.new_events_text[553];
			text = GlobalScript.inst.new_events_text[554];
		}
	}
}
