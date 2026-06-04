using EndingsDLCDraft;
using UnityEngine;

public class Ending18 : EndingsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (a.data[131] == 0)
		{
			name = GlobalScript.inst.new_events_text[1505];
			text = string.Format(GlobalScript.inst.new_events_text[1506], "\n");
			return;
		}
		if (a.data[131] == 1)
		{
			if (a.allcountries[21].Gosstroy == 2)
			{
				name = GlobalScript.inst.new_events_text[1507];
				text = string.Format(GlobalScript.inst.new_events_text[1508], "\n");
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(113);
				}
			}
			else
			{
				name = GlobalScript.inst.new_events_text[1509];
				text = string.Format(GlobalScript.inst.new_events_text[1510], "\n");
			}
			return;
		}
		if (a.data[131] == 2)
		{
			if (a.allcountries[21].Gosstroy == 1)
			{
				name = GlobalScript.inst.new_events_text[1511];
				text = string.Format(GlobalScript.inst.new_events_text[1512], "\n");
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(114);
				}
			}
			else if (a.allcountries[21].Gosstroy == 2)
			{
				name = GlobalScript.inst.new_events_text[1513];
				text = string.Format(GlobalScript.inst.new_events_text[1514], "\n");
			}
			else
			{
				name = GlobalScript.inst.new_events_text[1515];
				text = string.Format(GlobalScript.inst.new_events_text[1516], "\n");
			}
			return;
		}
		if (!a.allcountries[21].isNATO)
		{
			name = GlobalScript.inst.new_events_text[1517];
			text = string.Format(GlobalScript.inst.new_events_text[1518], "\n");
			if (GlobalScript.inst.gameState.iron_and_blood && GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(116);
			}
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
		if (GlobalScript.inst.gameState.empires[1].power <= GlobalScript.inst.gameState.empires[0].power || GlobalScript.inst.gameState.empires[1].power <= GlobalScript.inst.gameState.influencePRC || (a.allcountries[1].Gosstroy == 1 && num > 15) || a.empires[1].now_leader != 6)
		{
			name = GlobalScript.inst.new_events_text[1519];
			text = string.Format(GlobalScript.inst.new_events_text[1520], "\n");
		}
		else
		{
			name = GlobalScript.inst.new_events_text[1519];
			text = string.Format(GlobalScript.inst.new_events_text[1521], "\n");
		}
	}
}
