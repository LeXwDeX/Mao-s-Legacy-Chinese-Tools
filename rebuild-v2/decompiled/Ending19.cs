using EndingsDLCDraft;
using UnityEngine;

public class Ending19 : EndingsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (a.event_done[420])
		{
			if (a.allcountries[87].Gosstroy == 1)
			{
				name = GlobalScript.inst.new_events_text[1496];
				text = string.Format(GlobalScript.inst.new_events_text[1497], "\n");
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(152);
				}
			}
			else
			{
				name = GlobalScript.inst.new_events_text[1498];
				text = string.Format(GlobalScript.inst.new_events_text[1499], "\n", GlobalScript.inst.new_events_text[1499]);
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(153);
				}
			}
		}
		else
		{
			int num = 0;
			if (a.allcountries[87].isEU && a.allcountries[87].isNATO)
			{
				num = 1502;
			}
			else if (a.allcountries[87].isEU)
			{
				num = 1503;
			}
			else if (a.allcountries[87].isNATO)
			{
				num = 1504;
			}
			name = GlobalScript.inst.new_events_text[1500];
			text = string.Format(GlobalScript.inst.new_events_text[1501], "\n", (num > 0) ? GlobalScript.inst.new_events_text[num] : null);
		}
	}
}
