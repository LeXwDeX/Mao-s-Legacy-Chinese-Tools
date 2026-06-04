using EndingsDLCDraft;
using UnityEngine;

public class Ending20 : EndingsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEnding(ref string name, ref string text)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_events_text[1522];
		if (a.allcountries[85].SubGosstroy == 14)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1523], "\n", (a.empires[1].now_leader == 6) ? GlobalScript.inst.new_events_text[1535] : null);
		}
		else if (a.event_done[393])
		{
			text = string.Format(GlobalScript.inst.new_events_text[1524], "\n", (a.empires[1].now_leader == 6) ? GlobalScript.inst.new_events_text[1536] : GlobalScript.inst.new_events_text[1537]);
		}
		else if (a.event_done[394] && a.allcountries[85].SubGosstroy == 5 && !a.event_done[398])
		{
			text = string.Format(GlobalScript.inst.new_events_text[1525], "\n");
		}
		else if (a.allcountries[85].SubGosstroy == 10)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1526], "\n");
		}
		else if (a.event_done[401] && a.resultOfEvents[401] < 3)
		{
			if (a.resultOfEvents[401] == 0)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(124);
				}
				text = string.Format(GlobalScript.inst.new_events_text[1527], "\n");
			}
			else if (a.resultOfEvents[401] == 1)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(125);
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
					text = string.Format(GlobalScript.inst.new_events_text[1528], "\n");
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[1534], "\n");
				}
			}
			else
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(126);
				}
				text = string.Format(GlobalScript.inst.new_events_text[1529], "\n");
			}
		}
		else if (a.event_done[398] && a.resultOfEvents[398] < 3)
		{
			if (a.resultOfEvents[398] == 0)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(128);
				}
				text = string.Format(GlobalScript.inst.new_events_text[1530], "\n");
			}
			else if (a.resultOfEvents[398] == 1)
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(129);
				}
				text = string.Format(GlobalScript.inst.new_events_text[1531], "\n");
				if (GlobalScript.inst.gameState.ingamewars[26].infl2 >= 900 && GlobalScript.inst.gameState.allcountries[99].puppetOf == 85)
				{
					text = string.Format("{1}{0}{2}", "\n", text, GlobalScript.inst.new_events_text[1644]);
					gameObject.GetComponent<achievements>().Set(159);
				}
			}
			else
			{
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(130);
				}
				text = string.Format(GlobalScript.inst.new_events_text[1532], "\n");
			}
		}
		else if (a.event_done[398] || a.event_done[401])
		{
			text = string.Format(GlobalScript.inst.new_events_text[1538], "\n");
		}
		else if ((GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC) || a.empires[1].now_leader != 6)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1533], "\n");
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1539], "\n");
		}
	}
}
