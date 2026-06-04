using EndingsDLCDraft;
using UnityEngine;

public class Ending17 : EndingsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (a.resultOfEvents[424] == 1)
		{
			int num = 0;
			if (a.allcountries[86].isNATO && a.allcountries[86].isNATO)
			{
				num = 1274;
			}
			else if (a.allcountries[86].isNATO)
			{
				num = 1275;
			}
			else if (a.allcountries[86].isEU)
			{
				num = 1276;
			}
			if (a.allcountries[86].SubGosstroy == 3)
			{
				name = GlobalScript.inst.new_events_text[1464];
				text = string.Format(GlobalScript.inst.new_events_text[1465], "\n");
			}
			else if (a.resultOfEvents[427] == 0 && a.event_done[427])
			{
				name = GlobalScript.inst.new_events_text[1466];
				text = string.Format(GlobalScript.inst.new_events_text[1467], "\n");
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(144);
				}
			}
			else if (a.resultOfEvents[427] == 1)
			{
				name = GlobalScript.inst.new_events_text[1468];
				text = string.Format(GlobalScript.inst.new_events_text[1469], "\n");
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(145);
				}
			}
			else if (a.resultOfEvents[427] == 2)
			{
				name = GlobalScript.inst.new_events_text[1470];
				text = string.Format(GlobalScript.inst.new_events_text[1471], "\n");
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(146);
				}
			}
			else if (a.allcountries[86].isNATO)
			{
				name = GlobalScript.inst.new_events_text[1472];
				text = string.Format(GlobalScript.inst.new_events_text[1473], "\n", (num > 0) ? GlobalScript.inst.new_events_text[num] : null);
			}
			else
			{
				name = GlobalScript.inst.new_events_text[1490];
				text = GlobalScript.inst.new_events_text[1491];
			}
			return;
		}
		int num2 = 0;
		if (a.allcountries[109].parts[0] && a.allcountries[110].parts[0])
		{
			num2 = 1487;
		}
		else if (a.allcountries[109].parts[0])
		{
			num2 = 1488;
		}
		else if (a.allcountries[110].parts[0])
		{
			num2 = 1489;
		}
		if (a.allcountries[86].SubGosstroy == 7)
		{
			name = GlobalScript.inst.new_events_text[1477];
			text = string.Format(GlobalScript.inst.new_events_text[1478], "\n", (num2 > 0) ? GlobalScript.inst.new_events_text[num2] : null);
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(147);
			}
		}
		else if (a.allcountries[86].Gosstroy == 1)
		{
			name = GlobalScript.inst.new_events_text[1479];
			text = string.Format(GlobalScript.inst.new_events_text[1480], "\n", (num2 > 0) ? GlobalScript.inst.new_events_text[num2] : null);
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(150);
			}
		}
		else if (a.allcountries[86].SubGosstroy == 11)
		{
			name = GlobalScript.inst.new_events_text[1481];
			text = string.Format(GlobalScript.inst.new_events_text[1482], "\n", (num2 > 0) ? GlobalScript.inst.new_events_text[num2] : null);
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(149);
			}
		}
		else if (a.allcountries[86].SubGosstroy == 5)
		{
			name = GlobalScript.inst.new_events_text[1483];
			text = string.Format(GlobalScript.inst.new_events_text[1484], "\n", (num2 > 0) ? GlobalScript.inst.new_events_text[num2] : null);
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(148);
			}
		}
		else if (a.allcountries[86].SubGosstroy == 15)
		{
			name = GlobalScript.inst.new_events_text[1485];
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				gameObject.GetComponent<achievements>().Set(146);
			}
			text = string.Format(GlobalScript.inst.new_events_text[1486], "\n", (num2 > 0) ? GlobalScript.inst.new_events_text[num2] : null);
		}
		else
		{
			name = GlobalScript.inst.new_events_text[1490];
			text = GlobalScript.inst.new_events_text[1491];
		}
	}
}
