using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event367 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[574];
		text = string.Format(GlobalScript.inst.new_events_text[575], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		if (GlobalScript.inst.gameState.resultOfEvents[366] == 0 && a.data[8] + a.data[36] >= 250 && a.data[9] >= 150 && a.influencePRC >= 200 && a.data[22] >= 200)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[591], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 250)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 25f);
		}
		else if (a.data[9] < 150)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else if (a.data[22] < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[608], 20f);
		}
		else if (a.influencePRC < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[620], 20f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[595]);
		}
		if (GlobalScript.inst.gameState.resultOfEvents[366] == 1 && a.data[8] + a.data[36] >= 250 && a.data[9] >= 150 && a.influencePRC >= 200)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[599], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593]);
		}
		else if (a.data[8] + a.data[36] < 250)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 25f);
		}
		else if (a.data[9] < 150)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else if (a.influencePRC < 200)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[620], 20f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[595]);
		}
		button_text[2] = GlobalScript.inst.new_events_text[600];
		button_text[3] = GlobalScript.inst.new_events_text[601];
		button_text[4] = GlobalScript.inst.new_events_text[602];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[574];
		a.allcountries[84].Gosstroy = 0;
		a.allcountries[84].SubGosstroy = 7;
		text = string.Format(GlobalScript.inst.new_events_text[603 + result_num], "\n");
		switch (result_num)
		{
		case 0:
			if (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2))
			{
				a.data[1] += 150;
			}
			else
			{
				a.data[1] -= 100;
			}
			a.empires[0].relations -= 200;
			a.empires[1].relations += 100;
			a.empires[0].power -= 20;
			a.data[6] += 20;
			a.data[8] -= 250;
			a.data[9] -= 150;
			a.data[22] -= 200;
			GlobalScript.inst.gameState.ingamewars[8] = new War().Name(GlobalScript.inst.new_events_text[609]).Attacker(GlobalScript.inst.new_events_text[610]).Defender(GlobalScript.inst.new_events_text[611])
				.AttackerInfluence(800)
				.DefenderInfluence(200)
				.TickTime(20)
				.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			break;
		case 1:
			a.allcountries[84].SubGosstroy = 9;
			a.allcountries[87].spec -= 5;
			a.allcountries[84].Torg = true;
			if (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2))
			{
				a.data[1] += 150;
			}
			else
			{
				a.data[1] -= 100;
			}
			a.empires[0].relations -= 200;
			a.empires[1].relations -= 200;
			a.empires[0].power -= 30;
			a.data[6] += 50;
			a.data[8] -= 250;
			a.data[9] -= 150;
			a.data[22] -= 200;
			break;
		case 2:
			a.data[1] -= 50;
			break;
		case 3:
			if (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2))
			{
				a.data[1] -= 150;
			}
			else
			{
				a.data[1] += 100;
			}
			break;
		default:
			if (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2))
			{
				a.data[1] += 150;
			}
			else
			{
				a.data[1] -= 100;
			}
			a.empires[0].relations -= 300;
			a.empires[1].relations += 200;
			a.empires[0].power += 20;
			break;
		}
	}
}
