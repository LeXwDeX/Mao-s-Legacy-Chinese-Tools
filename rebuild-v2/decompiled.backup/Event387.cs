using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event387 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1008];
		text = string.Format(GlobalScript.inst.new_events_text[1009], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		if (a.data[9] >= 50 && a.data[22] >= 100)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1010], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[9] < 50)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[776], 10f);
		}
		if (a.data[9] >= 50 && a.data[22] >= 100)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1011], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[9] < 50)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[776], 10f);
		}
		button_text[2] = GlobalScript.inst.new_events_text[1012];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1008];
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1013], "\n");
			a.data[143]++;
			a.ingamewars[21] = new War().Name(GlobalScript.inst.new_events_text[1016]).Attacker(GlobalScript.inst.new_events_text[1017]).Defender(GlobalScript.inst.new_events_text[1018])
				.AttackerInfluence(600)
				.DefenderInfluence(400)
				.TickTime(20)
				.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			a.empires[0].relations += 100;
			a.empires[1].relations -= 100;
			a.data[6] += 10;
			a.data[9] -= 50;
			a.data[22] -= 100;
			break;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1014], "\n");
			a.data[143]++;
			a.ingamewars[21] = new War().Name(GlobalScript.inst.new_events_text[1016]).Attacker(GlobalScript.inst.new_events_text[1017]).Defender(GlobalScript.inst.new_events_text[1018])
				.AttackerInfluence(400)
				.DefenderInfluence(600)
				.TickTime(20)
				.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			a.empires[0].relations -= 100;
			a.empires[1].relations += 100;
			a.data[6] += 10;
			a.data[9] -= 50;
			a.data[22] -= 100;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1015], "\n");
			break;
		}
	}
}
