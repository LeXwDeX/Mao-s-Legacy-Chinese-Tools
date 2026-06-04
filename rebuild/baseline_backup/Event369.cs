using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event369 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[625];
		text = string.Format(GlobalScript.inst.new_events_text[626], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (a.relres)
		{
			button_text[0] = GlobalScript.inst.new_events_text[627];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_events_text[632];
		}
		if (a.data[8] + a.data[36] >= 250 && a.data[9] >= 150 && a.data[22] >= 300 && (a.allcountries[35].proprc || a.allcountries[14].proprc || a.allcountries[8].proprc || a.allcountries[8].okb))
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[628], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 200)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 20f);
		}
		else if (a.data[9] < 150)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else if (a.data[22] < 300)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[608], 30f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_events_text[631];
		}
		button_text[2] = GlobalScript.inst.new_events_text[629];
		button_text[3] = GlobalScript.inst.new_events_text[630];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[625];
		switch (result_num)
		{
		case 0:
			if (a.empires[1].power + a.influencePRC > a.empires[0].power)
			{
				text = string.Format(GlobalScript.inst.new_events_text[633], "\n");
				a.empires[1].power += 10;
				a.influencePRC += 10;
				a.empires[0].power -= 20;
				a.data[6] -= 20;
				a.data[4] -= 50;
				a.empires[0].relations -= 100;
				a.empires[1].relations += 100;
				if (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2))
				{
					a.data[1] += 50;
				}
				else
				{
					a.data[1] -= 50;
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[634], "\n");
				a.empires[0].power += 10;
				a.data[1] -= 50;
				a.data[4] += 50;
			}
			break;
		case 1:
		{
			text = string.Format(GlobalScript.inst.new_events_text[635], "\n");
			int num = 0;
			if (a.allcountries[35].proprc)
			{
				num += 5;
			}
			else if (a.allcountries[14].proprc)
			{
				num += 5;
			}
			else if (a.allcountries[8].proprc || a.allcountries[8].okb)
			{
				num += 5;
			}
			a.allcountries[84].Torg = false;
			a.data[6] += 20;
			a.empires[0].relations += 100;
			a.empires[1].relations -= 200;
			a.ingamewars[9] = new War().Name(GlobalScript.inst.new_events_text[638]).Attacker(GlobalScript.inst.new_events_text[639]).Defender(GlobalScript.inst.new_events_text[640])
				.AttackerInfluence(800 - num)
				.DefenderInfluence(200 + num)
				.TickTime(10)
				.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			break;
		}
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[636], "\n");
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[637], "\n");
			a.data[6] -= 50;
			a.data[1] += 50;
			a.empires[0].relations += 100;
			a.empires[1].relations -= 100;
			a.allcountries[84].Torg = false;
			break;
		}
	}
}
