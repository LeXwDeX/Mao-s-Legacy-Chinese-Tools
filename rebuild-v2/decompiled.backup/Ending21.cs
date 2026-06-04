using EndingsDLCDraft;
using UnityEngine;

public class Ending21 : EndingsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject.Find("Ach(Clone)");
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		if (a.allcountries[8].puppetOf == 84)
		{
			flag2 = true;
		}
		if (a.allcountries[35].puppetOf == 84)
		{
			flag3 = true;
		}
		if (a.allcountries[14].puppetOf == 84)
		{
			flag = true;
		}
		if (flag && flag3 && flag2)
		{
			num = 1542;
		}
		else if (flag && flag3)
		{
			num = 1543;
		}
		else if (flag2 && flag3)
		{
			num = 1544;
		}
		else if (flag && flag2)
		{
			num = 1545;
		}
		else if (flag2)
		{
			num = 1546;
		}
		else if (flag)
		{
			num = 1547;
		}
		else if (flag3)
		{
			num = 1548;
		}
		name = GlobalScript.inst.new_events_text[1540];
		int num2 = 0;
		num2 = (a.allcountries[84].parts[1] ? 1549 : (a.allcountries[84].parts[0] ? 1550 : (a.allcountries[14].parts[1] ? 1551 : (a.allcountries[14].parts[2] ? 1552 : (a.allcountries[14].parts[3] ? 1553 : (a.allcountries[8].parts[0] ? 1554 : (a.allcountries[14].parts[0] ? 1555 : ((!a.allcountries[35].parts[0]) ? 1557 : 1556))))))));
		int num3 = 0;
		num3 = ((a.allcountries[84].parts[4] && a.allcountries[84].SubGosstroy == 9) ? 1558 : ((a.allcountries[84].SubGosstroy == 9) ? 1559 : ((a.allcountries[84].Gosstroy == 2) ? 1560 : ((a.allcountries[84].parts[3] && (a.allcountries[7].parts[0] || a.allcountries[7].parts[2])) ? 1561 : (a.allcountries[84].parts[3] ? 1562 : ((!a.allcountries[7].parts[0] && !a.allcountries[7].parts[2]) ? 1564 : 1563))))));
		text = string.Format(GlobalScript.inst.new_events_text[1541], "\n", (num > 0) ? GlobalScript.inst.new_events_text[num] : null, GlobalScript.inst.new_events_text[num2], GlobalScript.inst.new_events_text[num3]);
	}
}
