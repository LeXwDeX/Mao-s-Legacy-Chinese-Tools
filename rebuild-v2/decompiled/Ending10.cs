using EndingsDLCDraft;
using UnityEngine;

public class Ending10 : EndingsSecond
{
	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.event_done[303])
		{
			if (GlobalScript.inst.gameState.resultOfEvents[303] == 0)
			{
				name = GlobalScript.inst.new_events_text[533];
				text = GlobalScript.inst.new_events_text[534];
			}
			else if (GlobalScript.inst.gameState.resultOfEvents[303] == 1)
			{
				name = GlobalScript.inst.new_events_text[535];
				text = GlobalScript.inst.new_events_text[536];
			}
			else
			{
				name = GlobalScript.inst.new_events_text[549];
				text = GlobalScript.inst.new_events_text[550];
			}
		}
		else
		{
			name = GlobalScript.inst.new_events_text[549];
			text = GlobalScript.inst.new_events_text[550];
		}
	}
}
