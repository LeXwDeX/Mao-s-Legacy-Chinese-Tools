using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event388 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1024];
		text = string.Format(GlobalScript.inst.new_events_text[1025], "\n", Random.Range(8, 95), Random.Range(80, 95), Random.Range(60, 70));
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[1026];
		button_text[1] = GlobalScript.inst.new_events_text[1027];
		if (a.relres && a.influencePRC >= 750 && a.data[22] >= 750 && a.IsFactionLeadeng(0) && !GlobalScript.inst.gameState.ingamewars[22].is_going && GlobalScript.inst.gameState.data[133] == 0)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[807], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (!a.relres && a.influencePRC >= 950 && a.data[22] >= 750)
		{
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[808], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.influencePRC < 750)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[620], 95f);
		}
		else if (a.data[22] < 750)
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[776], 75f);
		}
		else if (GlobalScript.inst.gameState.ingamewars[22].is_going)
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[1037];
		}
		else if (GlobalScript.inst.gameState.data[133] != 0)
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[1038];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_events_text[1031];
		}
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1024];
		for (int i = 0; i < 10; i++)
		{
			if (i == 2 || i == 6 || i == 9)
			{
				a.allcountries[i].prosov = false;
				a.allcountries[i].Torg = false;
				a.allcountries[i].isOVD = false;
				a.allcountries[i].isSEV = false;
			}
		}
		a.empires[1].power += 150;
		if (a.allcountries[7].parts[0])
		{
			a.allcountries[7].parts[2] = true;
			a.allcountries[7].parts[0] = false;
		}
		else
		{
			a.allcountries[7].parts[1] = true;
		}
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1028], "\n");
			return;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1029], "\n");
			a.empires[1].relations -= 500;
			a.empires[0].relations += 100;
			a.data[6] -= 50;
			return;
		}
		text = string.Format(GlobalScript.inst.new_events_text[812], "\n", a.relres ? GlobalScript.inst.new_events_text[809] : null);
		a.relres = false;
		a.empires[1].relations = 0;
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (GlobalScript.inst.gameState.iron_and_blood)
		{
			gameObject.GetComponent<achievements>().Set(142);
		}
		if (!GlobalScript.inst.dlc[5])
		{
			a.ingamewars[22] = new War().Name(GlobalScript.inst.new_events_text[1032]).Attacker(GlobalScript.inst.new_events_text[1033]).Defender(GlobalScript.inst.new_events_text[1034])
				.AttackerInfluence(250)
				.DefenderInfluence(750)
				.TickTime(500)
				.CreateWar;
			if (a.allcountries[51].Torg)
			{
				a.ingamewars[22].usa_place = 0;
			}
		}
		else
		{
			a.war = 18;
			a.startedDirectWarsNum.Add(18, value: false);
			a.data[163] = 250;
		}
		a.data[1] += 300;
		a.data[22] -= 750;
	}
}
