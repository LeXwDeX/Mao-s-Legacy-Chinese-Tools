using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event383 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[920];
		text = string.Format(GlobalScript.inst.new_events_text[921], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[922];
		if (a.data[9] >= 350)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[923], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 20f);
		}
		if (a.data[8] + a.data[36] >= 250 && a.data[9] >= 150 && a.data[7] >= 700 && (GlobalScript.inst.gameState.modifies[6].active || a.IsFactionLeadeng(0)))
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[924], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (!GlobalScript.inst.gameState.modifies[6].active && !a.IsFactionLeadeng(0))
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[925];
		}
		else if (a.data[7] < 700)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[620], 30f);
		}
		else if (a.data[8] + a.data[36] < 30)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], 25f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[920];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[929], "\n");
			a.ingamewars[19] = new War().Name(GlobalScript.inst.new_events_text[926]).Attacker(GlobalScript.inst.new_events_text[927]).Defender(GlobalScript.inst.new_events_text[928])
				.AttackerInfluence(500)
				.DefenderInfluence(500)
				.TickTime(11)
				.CreateWar;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[930], "\n");
			a.data[6] -= 50;
			a.empires[0].relations += 50;
			a.empires[1].relations += 50;
			a.data[9] -= 350;
			a.allcountries[20].LeaveAlliances();
			a.allcountries[20].proprc = false;
			a.allcountries[20].Torg = false;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[931], "\n");
			a.data[6] += 100;
			a.empires[0].relations -= 250;
			a.empires[1].relations -= 250;
			a.empires[0].power -= 50;
			a.empires[1].power -= 50;
			a.data[8] -= 150;
			a.data[9] -= 250;
			a.ingamewars[19] = new War().Name(GlobalScript.inst.new_events_text[926]).Attacker(GlobalScript.inst.new_events_text[927]).Defender(GlobalScript.inst.new_events_text[928])
				.AttackerInfluence(600)
				.DefenderInfluence(400)
				.TickTime(11)
				.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			break;
		}
	}
}
