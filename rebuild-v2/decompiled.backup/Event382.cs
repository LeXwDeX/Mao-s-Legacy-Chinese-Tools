using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event382 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[908];
		text = string.Format(GlobalScript.inst.new_events_text[909], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (a.influencePRC >= 300 && a.data[8] + a.data[36] >= 200 && a.data[9] >= 200)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[901], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 20f);
		}
		else if (a.data[9] < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 20f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[620], 30f);
		}
		if (a.allcountries[20].proprc && a.data[8] + a.data[36] >= 30 && a.data[9] >= 30)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[902], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else if (a.data[9] < 30)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 3f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_events_text[905];
		}
		if (a.influencePRC >= 300 && a.data[8] + a.data[36] >= 150 && a.data[9] >= 300 && a.allcountries[1].econ && (a.relres || a.allcountries[51].Torg))
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[903], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (!a.allcountries[1].econ)
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[906];
		}
		else if (a.influencePRC < 300)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[620], 30f);
		}
		else if (a.data[8] + a.data[36] < 150)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], 15f);
		}
		else if (a.data[9] < 300)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[567], 30f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[907];
		}
		button_text[3] = GlobalScript.inst.new_events_text[904];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[908];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[910], "\n");
			a.ingamewars[18] = new War().Name(GlobalScript.inst.new_events_text[911]).Attacker(GlobalScript.inst.new_events_text[912]).Defender(GlobalScript.inst.new_events_text[913])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.TickTime(20)
				.AmericanSupportDefender.CreateWar;
			a.empires[0].relations -= 100;
			a.data[6] += 50;
			a.data[1] += 50;
			a.data[8] -= 200;
			a.data[9] -= 200;
			break;
		case 1:
			if (a.data[7] >= 300)
			{
				text = string.Format(GlobalScript.inst.new_events_text[914], "\n");
				a.data[6] -= 50;
				a.empires[1].relations -= 50;
				a.empires[0].relations += 100;
				a.data[9] -= 30;
				a.data[8] -= 30;
				a.data[7] += 10;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[915], "\n");
				a.data[6] -= 50;
				a.empires[1].relations -= 150;
				a.empires[0].relations -= 150;
				a.data[8] -= 30;
				a.data[9] -= 30;
				a.data[7] -= 10;
				a.ingamewars[18] = new War().Name(GlobalScript.inst.new_events_text[911]).Attacker(GlobalScript.inst.new_events_text[912]).Defender(GlobalScript.inst.new_events_text[913])
					.AttackerInfluence(200)
					.DefenderInfluence(800)
					.TickTime(4)
					.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			}
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[916], "\n");
			a.allcountries[5].isOVD = false;
			a.allcountries[5].proprc = true;
			a.allcountries[20].proprc = true;
			a.data[7] += 50;
			a.empires[1].power -= 100;
			a.empires[0].power -= 100;
			a.data[9] -= 300;
			a.data[8] -= 150;
			a.data[6] += 100;
			GlobalScript.inst.gameState.allcountries[20].spec = 1;
			a.empires[0].relations -= 200;
			a.empires[1].relations -= 200;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[917], "\n");
			break;
		}
	}
}
