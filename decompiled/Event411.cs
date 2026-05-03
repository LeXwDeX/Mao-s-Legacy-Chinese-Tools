using EventsForDLC;
using UnityEngine;

public class Event411 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1261];
		text = string.Format(GlobalScript.inst.new_events_text[1262], "\n", GlobalScript.inst.new_events_text[1266 + Random.Range(0, 2)]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 6;
		button_text[0] = string.Format(GlobalScript.inst.new_events_text[1263], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214]);
		if (a.data[22] >= 350)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1264], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214]);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[776], 35f);
		}
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[1265], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214]);
		if (a.data[8] + a.data[36] >= 150)
		{
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[1266], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214]);
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], 15f);
		}
		if (a.influencePRC >= 50)
		{
			button_text[4] = string.Format(GlobalScript.inst.new_events_text[1267], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214]);
		}
		else if (a.influencePRC < 50)
		{
			button[4].SetActive(value: false);
			button_text[4] = string.Format(GlobalScript.inst.new_events_text[620], 5f);
		}
		button_text[5] = string.Format(GlobalScript.inst.new_events_text[1254], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594], GlobalScript.inst.new_events_text[1214]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1261];
		switch (result_num)
		{
		case 0:
		{
			text = string.Format(GlobalScript.inst.new_events_text[1268], "\n");
			if (a.data[16] < 15)
			{
				a.data[16]++;
			}
			if (a.data[17] < 19)
			{
				a.data[17]++;
			}
			if (a.data[15] < 9)
			{
				a.data[15]++;
			}
			a.empires[0].power += 25;
			a.empires[0].relations += 100;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] < 2)
				{
					politic2.loyality -= 500;
				}
				else if (politic2.traits[0] == 2)
				{
					politic2.loyality += 100;
				}
				else if (politic2.traits[0] == 3)
				{
					politic2.loyality += 300;
				}
			}
			a.allcountries[51].spec = 7;
			break;
		}
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1269], "\n");
			a.data[22] -= 350;
			a.empires[0].relations -= 150;
			a.empires[0].power -= 30;
			a.allcountries[51].spec = 7;
			break;
		case 2:
		{
			text = string.Format(GlobalScript.inst.new_events_text[1270], "\n");
			a.data[1] -= 450;
			a.empires[0].relations -= 300;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] < 2)
				{
					politic.loyality -= 500;
				}
				else if (politic.traits[0] == 2)
				{
					politic.loyality += 100;
				}
				else if (politic.traits[0] == 3)
				{
					politic.loyality += 300;
				}
			}
			a.allcountries[51].spec = 7;
			break;
		}
		case 3:
			text = string.Format(GlobalScript.inst.new_events_text[1271], "\n");
			a.data[8] -= 150;
			a.empires[1].power -= 20;
			a.empires[0].power += 20;
			a.empires[0].relations += 100;
			a.allcountries[51].spec = 7;
			break;
		case 4:
			text = string.Format(GlobalScript.inst.new_events_text[1272], "\n");
			a.influencePRC -= 50;
			a.empires[0].power += 50;
			a.empires[0].relations += 100;
			a.allcountries[51].spec = 7;
			break;
		case 5:
			text = string.Format(GlobalScript.inst.new_events_text[1273], "\n");
			a.allcountries[51].spec = 7;
			GlobalScript.inst.gameState.data[139] = 5;
			a.data[140] = 2;
			break;
		}
	}
}
