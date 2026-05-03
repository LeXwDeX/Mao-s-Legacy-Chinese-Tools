using EventsForDLC;
using UnityEngine;

public class Event407 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1204];
		text = string.Format(GlobalScript.inst.new_events_text[1205], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (a.data[8] + a.data[36] >= 300 && a.data[9] >= 300)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1206], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 300)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 30f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 30f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[1207];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1204];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1208], "\n");
			a.allcountries[92].proprc = true;
			a.allcountries[92].okb = true;
			a.allcountries[92].econ = true;
			a.allcountries[92].Torg = true;
			a.data[8] -= 300;
			a.data[9] -= 300;
			a.influencePRC += 50;
			a.empires[0].relations -= 250;
			a.empires[1].relations -= 250;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			for (int i = 0; i < politics.Length; i++)
			{
				politics[i].loyality -= 500;
			}
			a.data[1] -= 600;
			GlobalScript.inst.gameState.modifies[49].active = true;
			a.allcountries[51].Torg = false;
			a.allcountries[1].SubGosstroy = a.ChineseSubGosstroy();
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1209], "\n");
		}
	}
}
