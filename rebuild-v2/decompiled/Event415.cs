using EventsForDLC;
using UnityEngine;

public class Event415 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1291];
		text = string.Format(GlobalScript.inst.new_events_text[1292], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[8] + a.data[36] >= 50)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1293], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[1294];
		button_text[2] = GlobalScript.inst.new_events_text[1295];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1291];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1296], "\n");
			a.data[8] -= 50;
			a.allcountries[48].Gosstroy = 1;
			a.allcountries[48].SubGosstroy = 1;
			a.allcountries[48].EstablishGovernment(Government.ProSoviet);
			a.allcountries[48].Torg = true;
			a.empires[1].power += 20;
			a.empires[1].relations += 150;
			a.empires[0].relations -= 100;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1297], "\n");
			a.allcountries[48].Gosstroy = 1;
			a.allcountries[48].SubGosstroy = 1;
			a.allcountries[48].EstablishGovernment(Government.ProSoviet);
			a.empires[1].power += 20;
			a.empires[1].relations -= 150;
			a.empires[0].relations += 100;
			a.allcountries[48].Torg = false;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1298], "\n");
			a.allcountries[48].Gosstroy = 1;
			a.allcountries[48].SubGosstroy = 1;
			a.allcountries[48].EstablishGovernment(Government.ProSoviet);
			a.empires[1].power += 20;
			break;
		}
	}
}
