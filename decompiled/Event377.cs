using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event377 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[801];
		text = string.Format(GlobalScript.inst.new_events_text[802], "\n", (a.allcountries[9].proprc && !a.allcountries[9].okb && a.data[132] <= 0) ? GlobalScript.inst.new_events_text[803] : GlobalScript.inst.new_events_text[804]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[805];
		button_text[1] = GlobalScript.inst.new_events_text[806];
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
		name = GlobalScript.inst.new_events_text[801];
		a.allcountries[2].EstablishGovernment(Government.ProSoviet);
		a.allcountries[4].EstablishGovernment(Government.ProSoviet);
		a.allcountries[5].EstablishGovernment(Government.ProSoviet);
		if (a.allcountries[9].proprc && !a.allcountries[9].okb && a.data[132] <= 0)
		{
			a.allcountries[9].Gosstroy = a.allcountries[7].Gosstroy;
			a.allcountries[9].EstablishGovernment(Government.ProSoviet);
			a.allcountries[9].SubGosstroy = 16;
			a.influencePRC -= 50;
			a.allcountries[9].Torg = false;
		}
		a.allcountries[2].Gosstroy = a.allcountries[7].Gosstroy;
		a.allcountries[4].Gosstroy = a.allcountries[7].Gosstroy;
		a.allcountries[5].Gosstroy = a.allcountries[7].Gosstroy;
		a.allcountries[2].SubGosstroy = 16;
		a.allcountries[4].SubGosstroy = 16;
		a.allcountries[5].SubGosstroy = 16;
		a.allcountries[2].Torg = false;
		a.allcountries[4].Torg = false;
		a.allcountries[5].Torg = false;
		a.influencePRC -= 150;
		a.empires[1].power += 200;
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[810], "\n", (a.allcountries[9].proprc && !a.allcountries[9].okb && a.data[132] <= 0) ? GlobalScript.inst.new_events_text[813] : null);
			a.data[1] -= 550;
			return;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[811], "\n", (a.allcountries[9].proprc && !a.allcountries[9].okb && a.data[132] <= 0) ? GlobalScript.inst.new_events_text[813] : null);
			a.data[1] -= 250;
			a.empires[1].relations -= 500;
			a.empires[0].relations += 100;
			a.data[6] -= 50;
			return;
		}
		text = string.Format(GlobalScript.inst.new_events_text[812], "\n", a.relres ? GlobalScript.inst.new_events_text[809] : null);
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
		a.allcountries[7].Torg = false;
		a.data[1] += 300;
		a.data[22] -= 750;
	}
}
