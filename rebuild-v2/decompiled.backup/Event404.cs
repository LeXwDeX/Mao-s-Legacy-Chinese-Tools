using EventsForDLC;
using UnityEngine;

public class Event404 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1197];
		text = string.Format(GlobalScript.inst.new_events_text[1191], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[1192];
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 150 && a.allcountries[92].inflNATO >= 50)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1193], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.allcountries[92].inflNATO < 50)
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_events_text[1194];
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1197];
		a.modifies[57].active = true;
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1195], "\n");
			a.allcountries[92].SubGosstroy = 12;
			GlobalScript.inst.gameState.empires[0].power += 10;
			return;
		}
		text = string.Format(GlobalScript.inst.new_events_text[1196], "\n");
		a.data[8] -= 100;
		a.data[9] -= 150;
		a.data[1] -= 600;
		a.allcountries[92].inflNATO = 10;
		Politic[] politics = GlobalScript.inst.gameState.politics;
		foreach (Politic politic in politics)
		{
			if (politic.traits[0] == 0)
			{
				politic.loyality -= 300;
			}
			else if (politic.traits[0] == 1)
			{
				politic.loyality -= 300;
			}
			else
			{
				politic.loyality -= 100;
			}
		}
		a.allcountries[92].based = true;
	}
}
