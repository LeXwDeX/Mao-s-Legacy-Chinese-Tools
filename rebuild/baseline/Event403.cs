using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event403 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1158];
		text = string.Format(GlobalScript.inst.new_events_text[1159], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		if (a.data[8] + a.data[36] >= 150 && a.data[22] >= 150 && (a.influencePRC >= 600 || a.allcountries[51].dev > 0))
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1160], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 150)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 15f);
		}
		else if (a.influencePRC < 600 && a.allcountries[51].dev <= 0)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[620], 60f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[776], 35f);
		}
		if (a.data[8] + a.data[36] >= 150 && a.data[22] >= 150 && (a.influencePRC >= 200 || a.allcountries[51].dev > 0))
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1161], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 150)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 15f);
		}
		else if (a.influencePRC < 300 && a.allcountries[51].dev <= 0)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[620], 30f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[776], 25f);
		}
		if (a.data[8] + a.data[36] >= 250 && !a.relres && a.empires[1].now_leader != 3 && a.influencePRC >= 500 && a.data[22] >= 100)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1162], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.relres)
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[1164];
		}
		else if (a.empires[1].now_leader == 3)
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[1165];
		}
		else if (a.data[8] + a.data[36] < 250)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[566], 25f);
		}
		else if (a.influencePRC <= 500)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[620], 50f);
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[776], 10f);
		}
		if (a.data[8] + a.data[36] >= 100)
		{
			button_text[3] = GlobalScript.inst.new_events_text[1185];
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		button_text[4] = GlobalScript.inst.new_events_text[1163];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1158];
		switch (result_num)
		{
		case 0:
		{
			int num2 = 0;
			if (a.allcountries[42].parts[0])
			{
				num2 += 150;
			}
			text = string.Format(GlobalScript.inst.new_events_text[1166], "\n");
			a.data[8] -= 150;
			a.data[22] -= 350;
			a.empires[1].relations -= 300;
			a.ingamewars[24] = new War().Name(GlobalScript.inst.new_events_text[1170]).Attacker(GlobalScript.inst.new_events_text[1171]).Defender(GlobalScript.inst.new_events_text[1172])
				.AttackerInfluence(300 + num2)
				.DefenderInfluence(700 - num2)
				.TickTime(20)
				.SovietSupportAttacker.AmericanSupportDefender.CreateWar;
			break;
		}
		case 1:
		{
			int num = 0;
			text = string.Format(GlobalScript.inst.new_events_text[1167], "\n");
			a.data[8] -= 150;
			a.data[22] -= 250;
			a.empires[1].relations -= 300;
			a.allcountries[99].parts[0] = true;
			a.allcountries[100].parts[0] = true;
			a.ingamewars[25] = new War().Name(GlobalScript.inst.new_events_text[1176]).Attacker(GlobalScript.inst.new_events_text[1171]).Defender(GlobalScript.inst.new_events_text[1174])
				.AttackerInfluence(600 + num)
				.DefenderInfluence(400 - num)
				.TickTime(20)
				.SovietSupportAttacker.AmericanSupportDefender.CreateWar;
			a.ingamewars[26] = new War().Name(GlobalScript.inst.new_events_text[1177]).Attacker(GlobalScript.inst.new_events_text[1171]).Defender(GlobalScript.inst.new_events_text[1175])
				.AttackerInfluence(600 + num)
				.DefenderInfluence(400 - num)
				.TickTime(20)
				.SovietSupportAttacker.AmericanSupportDefender.CreateWar;
			break;
		}
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1168], "\n");
			a.data[8] -= 250;
			a.empires[1].power -= 25;
			a.empires[1].relations -= 500;
			a.empires[0].relations -= 200;
			a.influencePRC += 10;
			a.allcountries[41].prosov = false;
			a.allcountries[41].proprc = true;
			a.allcountries[41].Torg = true;
			break;
		case 3:
			text = string.Format(GlobalScript.inst.new_events_text[1186], "\n");
			a.data[8] -= 100;
			a.empires[0].relations += 250;
			a.empires[1].relations += 250;
			a.data[1] -= 100;
			a.data[6] -= 30;
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[1169], "\n");
			break;
		}
	}
}
