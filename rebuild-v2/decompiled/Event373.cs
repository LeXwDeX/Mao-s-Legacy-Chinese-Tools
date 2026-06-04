using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event373 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[727];
		text = string.Format(GlobalScript.inst.new_events_text[728], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		button_text[0] = GlobalScript.inst.new_events_text[729];
		button_text[1] = GlobalScript.inst.new_events_text[730];
		button_text[2] = GlobalScript.inst.new_events_text[731];
		if (a.allcountries[51].Torg && a.allcountries[51].dev > 0)
		{
			button_text[3] = GlobalScript.inst.new_events_text[736];
		}
		else if (!a.allcountries[51].Torg)
		{
			button[3].SetActive(value: false);
			button_text[3] = GlobalScript.inst.new_events_text[658];
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = GlobalScript.inst.new_events_text[659];
		}
		if (a.allcountries[92].okb)
		{
			button_text[4] = GlobalScript.inst.new_events_text[739];
			return;
		}
		button[4].SetActive(value: false);
		button_text[4] = GlobalScript.inst.new_events_text[1210];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[727];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[732], "\n");
			a.data[1] -= 250;
			a.empires[0].relations -= 200;
			a.empires[1].relations -= 200;
			a.ingamewars[14] = new War().Name(GlobalScript.inst.new_events_text[742]).Attacker(GlobalScript.inst.new_events_text[743]).Defender(GlobalScript.inst.new_events_text[744])
				.AttackerInfluence(700)
				.DefenderInfluence(300)
				.TickTime(10)
				.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[733], "\n");
			a.empires[0].relations += 200;
			a.empires[1].relations += 200;
			a.ingamewars[14] = new War().Name(GlobalScript.inst.new_events_text[742]).Attacker(GlobalScript.inst.new_events_text[743]).Defender(GlobalScript.inst.new_events_text[744])
				.AttackerInfluence(700)
				.DefenderInfluence(300)
				.TickTime(10)
				.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[734], "\n");
			a.ingamewars[14] = new War().Name(GlobalScript.inst.new_events_text[742]).Attacker(GlobalScript.inst.new_events_text[743]).Defender(GlobalScript.inst.new_events_text[744])
				.AttackerInfluence(700)
				.DefenderInfluence(300)
				.TickTime(10)
				.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			break;
		case 3:
			if (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2))
			{
				a.data[1] -= 250;
			}
			else
			{
				a.data[1] -= 50;
			}
			a.data[6] -= 30;
			if (a.influencePRC > a.empires[0].power)
			{
				text = string.Format(GlobalScript.inst.new_events_text[737], "\n");
				a.empires[0].power += 50;
				a.allcountries[94].isNATO = true;
				a.allcountries[94].EstablishGovernment(Government.ProAmerican);
				a.ingamewars[14] = new War().Name(GlobalScript.inst.new_events_text[742]).Attacker(GlobalScript.inst.new_events_text[743]).Defender(GlobalScript.inst.new_events_text[744])
					.AttackerInfluence(500)
					.DefenderInfluence(500)
					.TickTime(10)
					.AmericanSupportDefender.CreateWar;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[738], "\n");
				a.influencePRC -= 70;
				a.ingamewars[14] = new War().Name(GlobalScript.inst.new_events_text[742]).Attacker(GlobalScript.inst.new_events_text[743]).Defender(GlobalScript.inst.new_events_text[744])
					.AttackerInfluence(700)
					.DefenderInfluence(300)
					.TickTime(10)
					.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			}
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1211], "\n");
			a.influencePRC -= 70;
			a.ingamewars[14] = new War().Name(GlobalScript.inst.new_events_text[742]).Attacker(GlobalScript.inst.new_events_text[743]).Defender(GlobalScript.inst.new_events_text[744])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.TickTime(10)
				.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			break;
		}
	}
}
