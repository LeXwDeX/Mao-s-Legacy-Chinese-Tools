using EventsForDLC;
using UnityEngine;

public class Event412 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1274];
		text = string.Format(GlobalScript.inst.new_events_text[1275], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (a.data[8] + a.data[36] >= 200 && a.data[22] >= 250)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1276], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 20f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[776], 25f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[1277];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1274];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1278], "\n");
			a.allcountries[51].cw = true;
			a.data[8] -= 200;
			a.data[22] -= 250;
			for (int i = 0; i < a.allcountries.Length; i++)
			{
				if (a.allcountries[i].isSENTO)
				{
					a.allcountries[i].LeaveSENTO().JoinASEAN();
				}
			}
			a.influencePRC += 50;
			a.empires[0].power += 50;
			a.empires[1].power -= 50;
			a.empires[0].relations += 250;
			a.empires[1].relations -= 250;
			a.allcountries[9].isOVD = true;
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1279], "\n");
		}
	}
}
