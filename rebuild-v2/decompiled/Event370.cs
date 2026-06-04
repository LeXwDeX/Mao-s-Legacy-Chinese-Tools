using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event370 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		Debug.Log(GlobalScript.inst.new_events_text[644]);
		name = GlobalScript.inst.new_events_text[644];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		if (a.ingamewars[3].is_going)
		{
			num4 = 673;
			a.data[128] = 1;
		}
		if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb && !a.allcountries[35].isOVD)
		{
			num = 670;
			num5++;
		}
		if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
		{
			num2 = 671;
			num5++;
		}
		if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
		{
			num3 = 672;
			num5++;
		}
		text = string.Format(GlobalScript.inst.new_events_text[645], "\n", (num > 0) ? GlobalScript.inst.new_events_text[num] : null, (num2 > 0) ? GlobalScript.inst.new_events_text[num2] : null, (num3 > 0) ? GlobalScript.inst.new_events_text[num3] : null, (num4 > 0) ? GlobalScript.inst.new_events_text[num4] : null, (num5 == 1) ? GlobalScript.inst.new_events_text[674] : GlobalScript.inst.new_events_text[675]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		if (a.data[8] + a.data[36] >= 250 && a.data[9] >= 150 && a.data[22] >= 400)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[646], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 200)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 20f);
		}
		else if (a.data[9] < 150)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[608], 40f);
		}
		if (a.allcountries[51].Torg && a.allcountries[51].dev > 0)
		{
			button_text[1] = GlobalScript.inst.new_events_text[647];
		}
		else if (!a.allcountries[51].Torg)
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_events_text[658];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_events_text[659];
		}
		button_text[2] = GlobalScript.inst.new_events_text[648];
		if ((a.data[66] > 0 || a.data[67] > 0) && a.data[8] + a.data[36] >= 150 && a.data[22] >= 200 && a.data[18] == 20)
		{
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[649], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[66] <= 0 && a.data[67] <= 0)
		{
			button[3].SetActive(value: false);
			button_text[3] = GlobalScript.inst.new_events_text[661];
		}
		else if (a.data[18] == 20)
		{
			button[3].SetActive(value: false);
			button_text[3] = GlobalScript.inst.new_events_text[660];
		}
		else if (a.data[8] + a.data[36] < 200)
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], 15f);
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[608], 20f);
		}
		if (a.data[6] < 800 && a.allcountries[45].isNATO)
		{
			button_text[4] = GlobalScript.inst.new_events_text[650];
		}
		else if (!a.allcountries[45].isNATO)
		{
			button[4].SetActive(value: false);
			button_text[4] = GlobalScript.inst.new_events_text[681];
		}
		else
		{
			button[4].SetActive(value: false);
			button_text[4] = GlobalScript.inst.new_events_text[662];
		}
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[644];
		int num = 0;
		if (a.ingamewars[3].is_going)
		{
			a.ingamewars[3].is_going = false;
		}
		if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb)
		{
			num++;
		}
		if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
		{
			num++;
			a.data[143] += 3;
		}
		if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
		{
			num++;
			a.data[143] += 3;
		}
		switch (result_num)
		{
		case 0:
		{
			text = string.Format(GlobalScript.inst.new_events_text[651], "\n", (num == 1) ? GlobalScript.inst.new_events_text[676] : GlobalScript.inst.new_events_text[677]);
			int num2 = 0;
			if (a.ingamewars[3].is_going)
			{
				num2 = 150;
			}
			a.allcountries[84].Torg = false;
			a.data[6] += 20;
			a.data[4] -= 50;
			a.empires[0].relations -= 300;
			a.empires[1].relations += 100;
			a.data[8] -= 250;
			a.data[9] -= 150;
			a.data[22] -= 400;
			if (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2))
			{
				a.data[1] += 50;
			}
			else
			{
				a.data[1] -= 50;
			}
			if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb)
			{
				a.ingamewars[10] = new War().Name(GlobalScript.inst.new_events_text[663]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[665])
					.AttackerInfluence(500)
					.DefenderInfluence(500)
					.TickTime(12)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
			{
				a.ingamewars[11] = new War().Name(GlobalScript.inst.new_events_text[666]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[667])
					.TickTime(12)
					.AttackerInfluence(500 + num2)
					.DefenderInfluence(500 - num2)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
			{
				a.ingamewars[12] = new War().Name(GlobalScript.inst.new_events_text[668]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[669])
					.TickTime(12)
					.AttackerInfluence(500 + num2)
					.DefenderInfluence(500 - num2)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			return;
		}
		case 1:
		{
			int num7 = 0;
			if (a.ingamewars[3].is_going)
			{
				num7 = 150;
			}
			a.allcountries[84].Torg = false;
			if (a.influencePRC > a.empires[0].power)
			{
				text = string.Format(GlobalScript.inst.new_events_text[652], "\n");
				a.allcountries[84].Vyshi = false;
				a.allcountries[84].isNATO = false;
				a.data[1] += 100;
				a.empires[0].relations -= 100;
				a.empires[1].relations -= 100;
				a.data[6] -= 20;
				a.empires[0].power -= 50;
				a.influencePRC += 20;
				if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb)
				{
					a.ingamewars[10] = new War().Name(GlobalScript.inst.new_events_text[663]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[665])
						.AttackerInfluence(400)
						.DefenderInfluence(600)
						.TickTime(12)
						.SovietSupportDefender.CreateWar;
				}
				if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
				{
					a.ingamewars[11] = new War().Name(GlobalScript.inst.new_events_text[666]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[667])
						.TickTime(12)
						.AttackerInfluence(400 + num7)
						.DefenderInfluence(600 - num7)
						.SovietSupportDefender.CreateWar;
				}
				if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
				{
					a.ingamewars[12] = new War().Name(GlobalScript.inst.new_events_text[668]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[669])
						.TickTime(12)
						.AttackerInfluence(400 + num7)
						.DefenderInfluence(600 - num7)
						.SovietSupportDefender.CreateWar;
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[653], "\n");
				a.data[1] -= 300;
				a.empires[0].relations -= 500;
				a.empires[1].relations -= 100;
				a.data[6] += 20;
				a.empires[0].power += 50;
				a.influencePRC -= 80;
				if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb)
				{
					a.ingamewars[10] = new War().Name(GlobalScript.inst.new_events_text[663]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[665])
						.AttackerInfluence(500)
						.DefenderInfluence(500)
						.TickTime(12)
						.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
				}
				if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
				{
					a.ingamewars[11] = new War().Name(GlobalScript.inst.new_events_text[666]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[667])
						.TickTime(12)
						.AttackerInfluence(500 + num7)
						.DefenderInfluence(500 - num7)
						.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
				}
				if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
				{
					a.ingamewars[12] = new War().Name(GlobalScript.inst.new_events_text[668]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[669])
						.TickTime(12)
						.AttackerInfluence(500 + num7)
						.DefenderInfluence(500 - num7)
						.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
				}
			}
			return;
		}
		case 2:
		{
			text = string.Format(GlobalScript.inst.new_events_text[654], "\n");
			int num8 = 0;
			if (a.ingamewars[3].is_going)
			{
				num8 = 150;
			}
			if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb)
			{
				a.ingamewars[10] = new War().Name(GlobalScript.inst.new_events_text[663]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[665])
					.AttackerInfluence(600)
					.DefenderInfluence(400)
					.TickTime(12)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
			{
				a.ingamewars[11] = new War().Name(GlobalScript.inst.new_events_text[666]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[667])
					.TickTime(12)
					.AttackerInfluence(600 + num8)
					.DefenderInfluence(400 - num8)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
			{
				a.ingamewars[12] = new War().Name(GlobalScript.inst.new_events_text[668]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[669])
					.TickTime(12)
					.AttackerInfluence(600 + num8)
					.DefenderInfluence(400 - num8)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			return;
		}
		case 3:
		{
			a.data[8] -= 150;
			a.data[22] -= 200;
			a.data[1] += 350;
			a.empires[0].relations -= 250;
			a.empires[1].relations -= 250;
			a.influencePRC -= 50;
			a.data[6] += 100;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			if (a.data[66] > 0)
			{
				a.allcountries[70].dev = 100;
				a.allcountries[70].Torg = true;
				a.allcountries[70].EstablishGovernment(Government.ProChina);
				num4++;
			}
			if (a.data[67] > 0)
			{
				a.allcountries[69].dev = 100;
				a.allcountries[69].EstablishGovernment(Government.ProChina);
				a.allcountries[69].Torg = true;
				num3++;
			}
			if (num3 > 0 && num4 > 0)
			{
				num5++;
				num3 = 0;
				num4 = 0;
			}
			text = string.Format(GlobalScript.inst.new_events_text[655], "\n", (num5 > 0) ? GlobalScript.inst.new_events_text[680] : ((num3 > 0) ? GlobalScript.inst.new_events_text[679] : GlobalScript.inst.new_events_text[680]));
			int num6 = 0;
			if (a.ingamewars[3].is_going)
			{
				num6 = 150;
			}
			if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb)
			{
				a.ingamewars[10] = new War().Name(GlobalScript.inst.new_events_text[663]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[665])
					.AttackerInfluence(600)
					.DefenderInfluence(400)
					.TickTime(12)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
			{
				a.ingamewars[11] = new War().Name(GlobalScript.inst.new_events_text[666]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[667])
					.TickTime(12)
					.AttackerInfluence(600 + num6)
					.DefenderInfluence(400 - num6)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
			{
				a.ingamewars[12] = new War().Name(GlobalScript.inst.new_events_text[668]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[669])
					.TickTime(12)
					.AttackerInfluence(600 + num6)
					.DefenderInfluence(400 - num6)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			return;
		}
		}
		int num9 = 0;
		if (a.ingamewars[3].is_going)
		{
			num9 = 150;
		}
		a.allcountries[84].Torg = false;
		if (a.influencePRC > a.empires[0].power + a.empires[1].power || a.influencePRC > 800)
		{
			text = string.Format(GlobalScript.inst.new_events_text[656], "\n");
			a.influencePRC += 50;
			a.data[6] -= 50;
			a.data[1] -= 300;
			a.empires[0].relations -= 100;
			a.empires[1].relations -= 100;
			a.data[126] = 1;
			a.allcountries[84].Vyshi = false;
			a.allcountries[84].isNATO = false;
			if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb)
			{
				a.ingamewars[10] = new War().Name(GlobalScript.inst.new_events_text[663]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[665])
					.AttackerInfluence(300)
					.DefenderInfluence(700)
					.TickTime(12)
					.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			}
			if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
			{
				a.ingamewars[11] = new War().Name(GlobalScript.inst.new_events_text[666]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[667])
					.TickTime(12)
					.AttackerInfluence(300 + num9)
					.DefenderInfluence(700 - num9)
					.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			}
			if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
			{
				a.ingamewars[12] = new War().Name(GlobalScript.inst.new_events_text[668]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[669])
					.TickTime(12)
					.AttackerInfluence(300 + num9)
					.DefenderInfluence(700 - num9)
					.SovietSupportDefender.AmericanSupportDefender.CreateWar;
			}
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[657], "\n");
			a.influencePRC -= 10;
			a.empires[0].power += 50;
			a.empires[1].power += 50;
			a.data[1] -= 300;
			a.empires[0].relations -= 100;
			a.empires[1].relations -= 100;
			if (!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].Vyshi && !a.allcountries[35].okb)
			{
				a.ingamewars[10] = new War().Name(GlobalScript.inst.new_events_text[663]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[665])
					.AttackerInfluence(600)
					.DefenderInfluence(400)
					.TickTime(12)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			if (!a.allcountries[14].prosov && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD)
			{
				a.ingamewars[11] = new War().Name(GlobalScript.inst.new_events_text[666]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[667])
					.TickTime(12)
					.AttackerInfluence(600 + num9)
					.DefenderInfluence(400 - num9)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
			if (!a.allcountries[8].Vyshi && !a.allcountries[8].okb && !a.allcountries[8].isOVD)
			{
				a.ingamewars[12] = new War().Name(GlobalScript.inst.new_events_text[668]).Attacker(GlobalScript.inst.new_events_text[664]).Defender(GlobalScript.inst.new_events_text[669])
					.TickTime(12)
					.AttackerInfluence(600 + num9)
					.DefenderInfluence(400 - num9)
					.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
			}
		}
	}
}
