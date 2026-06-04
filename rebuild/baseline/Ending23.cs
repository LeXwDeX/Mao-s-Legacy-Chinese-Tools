using EndingsDLCDraft;
using UnityEngine;

public class Ending23 : EndingsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_events_text[1574];
		if (a.allcountries[16].parts[0])
		{
			text = string.Format(GlobalScript.inst.new_events_text[1585], '\n');
		}
		else if (a.allcountries[17].parts[0] && a.allcountries[17].dev > 0 && a.allcountries[17].Gosstroy == 3)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1592], '\n');
		}
		else if (a.allcountries[17].parts[0] && a.allcountries[17].dev > 0 && a.allcountries[17].Gosstroy == 2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1593], '\n', (a.empires[0].power > a.empires[1].power) ? GlobalScript.inst.new_events_text[1596] : GlobalScript.inst.new_events_text[1597]);
		}
		else if (a.allcountries[7].isNATO)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1598], '\n', (a.empires[0].power > a.empires[1].power) ? GlobalScript.inst.new_events_text[1596] : GlobalScript.inst.new_events_text[1597]);
		}
		else if ((GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.allcountries[1].isOVD) || (GlobalScript.inst.gameState.allcountries[5].Torg && !GlobalScript.inst.gameState.allcountries[2].prosov && !GlobalScript.inst.gameState.allcountries[4].prosov && (GlobalScript.inst.gameState.allcountries[1].isOVD || GlobalScript.inst.gameState.allcountries[1].isSEV)))
		{
			text = string.Format(GlobalScript.inst.new_events_text[1594], '\n');
		}
		else if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1595], '\n');
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1594], '\n');
		}
	}
}
