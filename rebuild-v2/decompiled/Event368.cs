using EventsForDLC;
using UnityEngine;

public class Event368 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[615];
		text = string.Format(GlobalScript.inst.new_events_text[616], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 50)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[617], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else if (a.data[9] < 50)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[620], 25f);
		}
		if (a.data[8] + a.data[36] >= 50 && a.data[9] >= 150 && (a.influencePRC >= 350 || a.allcountries[51].dev > 0))
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[618], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		else if (a.data[9] < 150)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_events_text[1646];
		}
		button_text[2] = GlobalScript.inst.new_events_text[619];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[615];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[621], "\n");
			a.allcountries[35].EstablishGovernment(Government.ProChina);
			a.allcountries[35].Torg = true;
			a.allcountries[35].Gosstroy = 0;
			a.allcountries[35].SubGosstroy = 10;
			a.empires[1].power -= 20;
			a.influencePRC += 20;
			a.data[6] += 10;
			a.data[8] -= 100;
			a.data[9] -= 50;
			a.data[1] += 100;
			break;
		case 1:
			if (a.influencePRC >= GlobalScript.inst.gameState.empires[1].power)
			{
				text = string.Format(GlobalScript.inst.new_events_text[622], "\n");
				a.allcountries[35].EstablishGovernment(Government.ProAmerican);
				a.allcountries[35].Torg = true;
				a.allcountries[35].Gosstroy = 3;
				a.allcountries[35].SubGosstroy = 5;
				a.empires[1].power -= 20;
				a.empires[0].power += 20;
				a.data[6] -= 10;
				a.data[8] -= 50;
				a.data[9] -= 150;
				a.data[1] += 50;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[623], "\n");
				a.allcountries[35].SubGosstroy = 1;
				a.data[6] -= 10;
				a.data[8] -= 50;
				a.data[9] -= 150;
				a.empires[1].power += 20;
				a.data[1] -= 300;
			}
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[624], "\n");
			a.allcountries[35].Gosstroy = 2;
			GlobalScript.inst.gameState.allcountries[35].SubGosstroy = 15;
			break;
		}
	}
}
