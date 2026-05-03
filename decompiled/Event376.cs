using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event376 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[785];
		text = string.Format(GlobalScript.inst.new_events_text[786], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[22] >= 50 && a.data[8] + a.data[36] >= 30)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[787], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[776], 5f);
		}
		if (a.data[22] >= 50 && a.data[8] + a.data[36] >= 30)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[788], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 3f);
		}
		else if (a.data[9] < 150)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[776], 5f);
		}
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[789], "\n");
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[785];
		a.allcountries[42].prosov = false;
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[790], "\n");
			a.data[6] += 10;
			a.data[8] -= 30;
			a.data[22] -= 30;
			a.empires[1].power += 10;
			a.empires[1].relations += 120;
			a.empires[0].relations -= 150;
			GlobalScript.inst.gameState.SOV_PRC_PartiesConnection += 20;
			a.data[1] += 100;
			GlobalScript.inst.gameState.allcountries[41].Torg = true;
			a.ingamewars[15] = new War().Name(GlobalScript.inst.new_events_text[793]).Attacker(GlobalScript.inst.new_events_text[794]).Defender(GlobalScript.inst.new_events_text[795])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.TickTime(16)
				.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[791], "\n");
			a.data[6] += 10;
			a.data[8] -= 30;
			a.data[22] -= 30;
			a.empires[0].power += 10;
			a.empires[0].relations += 120;
			a.empires[1].relations -= 150;
			GlobalScript.inst.gameState.SOV_PRC_PartiesConnection -= 20;
			a.data[1] += 100;
			a.allcountries[42].Torg = true;
			a.ingamewars[15] = new War().Name(GlobalScript.inst.new_events_text[793]).Attacker(GlobalScript.inst.new_events_text[794]).Defender(GlobalScript.inst.new_events_text[795])
				.AttackerInfluence(550)
				.DefenderInfluence(450)
				.TickTime(16)
				.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[792], "\n");
			a.ingamewars[15] = new War().Name(GlobalScript.inst.new_events_text[793]).Attacker(GlobalScript.inst.new_events_text[794]).Defender(GlobalScript.inst.new_events_text[795])
				.AttackerInfluence(400)
				.DefenderInfluence(600)
				.TickTime(16)
				.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			break;
		}
	}
}
