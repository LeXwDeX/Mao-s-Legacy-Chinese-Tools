using EventsForDLC;
using UnityEngine;

public class Event392 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1070];
		text = string.Format(GlobalScript.inst.new_events_text[1071], "\n", (a.allcountries[85].inflCh > 0 || a.resultOfEvents[391] == 4) ? GlobalScript.inst.new_events_text[1072] : GlobalScript.inst.new_events_text[1073]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		button_text[0] = GlobalScript.inst.new_events_text[1074];
		if (a.data[9] >= 90 && (a.allcountries[85].inflNATO > 0 || a.allcountries[85].inflCh > 0))
		{
			button_text[1] = string.Format((a.allcountries[85].inflCh > 0 || a.resultOfEvents[391] == 4) ? GlobalScript.inst.new_events_text[1075] : GlobalScript.inst.new_events_text[1076], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.allcountries[85].inflNATO <= 0 && a.allcountries[85].inflCh <= 0)
		{
			button_text[1] = GlobalScript.inst.new_events_text[1082];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 9f);
		}
		button_text[2] = GlobalScript.inst.new_events_text[1079];
		button_text[3] = GlobalScript.inst.new_events_text[1080];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1070];
		switch (result_num)
		{
		case 0:
			text = string.Format((a.allcountries[85].inflCh > 0 || a.resultOfEvents[391] == 4) ? GlobalScript.inst.new_events_text[1077] : GlobalScript.inst.new_events_text[1078], "\n");
			if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO <= 0)
			{
				a.allcountries[85].inflCh = 2;
			}
			else if (a.allcountries[85].inflCh <= 0 && a.allcountries[85].inflNATO > 0)
			{
				a.allcountries[85].inflNATO = 2;
			}
			else if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO > 0)
			{
				a.allcountries[85].inflNATO = 3;
				a.allcountries[85].inflCh = 3;
			}
			a.allcountries[87].spec -= 5;
			break;
		case 1:
			if (a.allcountries[85].inflNATO > 0 || a.allcountries[85].inflCh > 0)
			{
				text = string.Format((a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO > 0) ? GlobalScript.inst.new_events_text[1083] : GlobalScript.inst.new_events_text[1084], "\n");
				if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO <= 0)
				{
					a.allcountries[85].inflCh = 5;
				}
				else if (a.allcountries[85].inflCh <= 0 && a.allcountries[85].inflNATO > 0)
				{
					a.allcountries[85].inflNATO = 5;
				}
				else if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO > 0)
				{
					a.allcountries[85].inflNATO = 4;
					a.allcountries[85].inflCh = 4;
				}
				a.data[9] -= 90;
				a.data[6] -= 20;
				break;
			}
			text = string.Format(GlobalScript.inst.new_events_text[1085], "\n", (a.allcountries[85].inflCh > 0 || a.resultOfEvents[391] == 4) ? GlobalScript.inst.new_events_text[1077] : GlobalScript.inst.new_events_text[1078]);
			if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO <= 0)
			{
				a.allcountries[85].inflCh = 2;
			}
			else if (a.allcountries[85].inflCh <= 0 && a.allcountries[85].inflNATO > 0)
			{
				a.allcountries[85].inflNATO = 2;
			}
			else if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO > 0)
			{
				a.allcountries[85].inflNATO = 3;
				a.allcountries[85].inflCh = 3;
			}
			a.data[6] -= 10;
			a.allcountries[87].spec -= 5;
			a.empires[1].relations += 80;
			a.empires[0].relations += 80;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1086], "\n", (a.allcountries[85].inflCh > 0 || a.resultOfEvents[391] == 4) ? GlobalScript.inst.new_events_text[1077] : GlobalScript.inst.new_events_text[1078]);
			if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO <= 0)
			{
				a.allcountries[85].inflCh = 2;
			}
			else if (a.allcountries[85].inflCh <= 0 && a.allcountries[85].inflNATO > 0)
			{
				a.allcountries[85].inflNATO = 2;
			}
			else if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO > 0)
			{
				a.allcountries[85].inflNATO = 3;
				a.allcountries[85].inflCh = 3;
			}
			a.data[6] += 10;
			a.allcountries[87].spec -= 5;
			a.empires[0].relations -= 150;
			a.empires[0].power -= 15;
			a.empires[1].relations += 50;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1087], "\n", (a.allcountries[85].inflCh > 0 || a.resultOfEvents[391] == 4) ? GlobalScript.inst.new_events_text[1077] : GlobalScript.inst.new_events_text[1078]);
			if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO <= 0)
			{
				a.allcountries[85].inflCh = 2;
			}
			else if (a.allcountries[85].inflCh <= 0 && a.allcountries[85].inflNATO > 0)
			{
				a.allcountries[85].inflNATO = 2;
			}
			else if (a.allcountries[85].inflCh > 0 && a.allcountries[85].inflNATO > 0)
			{
				a.allcountries[85].inflNATO = 3;
				a.allcountries[85].inflCh = 3;
			}
			a.empires[1].relations -= 150;
			a.empires[1].power -= 15;
			a.empires[0].relations += 50;
			a.allcountries[87].spec -= 5;
			break;
		}
	}
}
