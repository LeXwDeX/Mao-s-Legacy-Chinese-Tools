using EndingsDLCDraft;
using UnityEngine;

public class Ending22 : EndingsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_events_text[1569];
		if (a.data[147] == 1)
		{
			if (a.modifies[49].active)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(120);
				}
				text = string.Format(GlobalScript.inst.new_events_text[1586], '\n');
				return;
			}
			int num = 0;
			for (int i = 0; i < a.allcountries.Length; i++)
			{
				if (a.allcountries[i].econ)
				{
					num++;
				}
			}
			int num2 = 0;
			num2 = ((GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC && (a.allcountries[1].Gosstroy != 1 || num <= 15) && a.empires[1].now_leader == 6) ? 1600 : 1599);
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(119);
			}
			text = string.Format(GlobalScript.inst.new_events_text[1587], '\n', GlobalScript.inst.new_events_text[num2]);
		}
		else if (a.data[147] == 2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1588], '\n');
		}
		else if (a.data[147] == 3)
		{
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(118);
			}
			text = string.Format(GlobalScript.inst.new_events_text[1589], '\n');
		}
		else if (a.data[147] == 4)
		{
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(117);
			}
			text = string.Format(GlobalScript.inst.new_events_text[1590], '\n');
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1591], '\n');
		}
	}
}
