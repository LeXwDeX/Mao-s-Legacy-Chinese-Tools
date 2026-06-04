using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event426 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1402];
		text = string.Format(GlobalScript.inst.new_events_text[1403], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 50 && a.data[22] >= 150)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1404], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
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
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[776], 15f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[1405];
		button_text[2] = GlobalScript.inst.new_events_text[1406];
		button_text[3] = GlobalScript.inst.new_events_text[1407];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1402];
		a.allcountries[109].Gosstroy = 0;
		a.allcountries[109].SubGosstroy = 10;
		a.allcountries[86].parts[0] = true;
		a.allcountries[86].parts[1] = true;
		a.allcountries[110].Gosstroy = 2;
		a.allcountries[110].SubGosstroy = 15;
		a.allcountries[109].soc_stab = 1000;
		a.allcountries[109].stab = 1000;
		a.allcountries[110].stab = 1000;
		a.allcountries[110].soc_stab = 1000;
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1413], "\n");
			a.data[8] -= 100;
			a.data[9] -= 50;
			a.data[22] -= 200;
			a.empires[0].relations -= 250;
			a.empires[1].relations -= 250;
			a.ingamewars[31] = new War().Name(GlobalScript.inst.new_events_text[1408]).Attacker(GlobalScript.inst.new_events_text[1409]).Defender(GlobalScript.inst.new_events_text[1410])
				.AttackerInfluence(500)
				.DefenderInfluence(500)
				.CreateWar;
			a.ingamewars[32] = new War().Name(GlobalScript.inst.new_events_text[1411]).Attacker(GlobalScript.inst.new_events_text[1412]).Defender(GlobalScript.inst.new_events_text[1410])
				.AttackerInfluence(500)
				.DefenderInfluence(500)
				.CreateWar;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1414], "\n");
			a.empires[0].relations -= 150;
			a.empires[1].relations -= 150;
			a.ingamewars[31] = new War().Name(GlobalScript.inst.new_events_text[1408]).Attacker(GlobalScript.inst.new_events_text[1409]).Defender(GlobalScript.inst.new_events_text[1410])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.CreateWar;
			a.ingamewars[32] = new War().Name(GlobalScript.inst.new_events_text[1411]).Attacker(GlobalScript.inst.new_events_text[1412]).Defender(GlobalScript.inst.new_events_text[1410])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.CreateWar;
			break;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1415], "\n");
			a.empires[0].relations += 150;
			a.empires[1].relations += 150;
			a.ingamewars[31] = new War().Name(GlobalScript.inst.new_events_text[1408]).Attacker(GlobalScript.inst.new_events_text[1409]).Defender(GlobalScript.inst.new_events_text[1410])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.CreateWar;
			a.ingamewars[32] = new War().Name(GlobalScript.inst.new_events_text[1411]).Attacker(GlobalScript.inst.new_events_text[1412]).Defender(GlobalScript.inst.new_events_text[1410])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.CreateWar;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1416], "\n");
			a.ingamewars[31] = new War().Name(GlobalScript.inst.new_events_text[1408]).Attacker(GlobalScript.inst.new_events_text[1409]).Defender(GlobalScript.inst.new_events_text[1410])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.CreateWar;
			a.ingamewars[32] = new War().Name(GlobalScript.inst.new_events_text[1411]).Attacker(GlobalScript.inst.new_events_text[1412]).Defender(GlobalScript.inst.new_events_text[1410])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.CreateWar;
			break;
		}
	}
}
