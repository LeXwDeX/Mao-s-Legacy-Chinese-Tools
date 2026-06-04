using EventsForDLC;
using UnityEngine;

public class Event416 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1299];
		text = string.Format(GlobalScript.inst.new_events_text[1300], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 150)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1301], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 15f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		if (a.data[8] + a.data[36] >= 50 && a.data[9] >= 100)
		{
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1302], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[566], 5f);
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[567], 10f);
		}
		button_text[2] = GlobalScript.inst.new_events_text[1295];
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 150 && a.allcountries[51].dev > 0)
		{
			button_text[3] = GlobalScript.inst.new_events_text[1303];
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], 15f);
		}
		else if (a.data[9] < 150)
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = GlobalScript.inst.new_events_text[659];
		}
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1299];
		Politic[] politics;
		switch (result_num)
		{
		case 0:
			text = string.Format(GlobalScript.inst.new_events_text[1304], "\n");
			a.data[8] -= 100;
			a.data[9] -= 150;
			a.allcountries[48].Gosstroy = 0;
			a.allcountries[48].SubGosstroy = 0;
			a.allcountries[48].EstablishGovernment(Government.ProChina);
			a.allcountries[48].Torg = true;
			a.empires[1].power -= 10;
			a.influencePRC += 20;
			a.empires[1].relations -= 100;
			a.empires[0].relations -= 100;
			politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2.traits[0] == 0)
				{
					politic2.loyality += 300;
				}
				else if (politic2.traits[0] == 1)
				{
					politic2.loyality += 10;
				}
				else
				{
					politic2.loyality -= 50;
				}
			}
			return;
		case 1:
			text = string.Format(GlobalScript.inst.new_events_text[1305], "\n");
			a.data[8] -= 50;
			a.data[9] -= 100;
			a.empires[1].power += 10;
			a.empires[1].relations -= 150;
			a.empires[0].relations += 100;
			a.allcountries[48].Torg = true;
			politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 0)
				{
					politic.loyality -= 200;
				}
				else if (politic.traits[0] == 1)
				{
					politic.loyality += 100;
				}
				else
				{
					politic.loyality -= 50;
				}
			}
			return;
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[1306], "\n");
			a.allcountries[48].Torg = false;
			a.allcountries[48].Gosstroy = 3;
			a.allcountries[48].SubGosstroy = 12;
			a.empires[1].power -= 10;
			a.empires[0].power += 20;
			a.allcountries[48].EstablishGovernment(Government.ProAmerican);
			return;
		}
		text = string.Format(GlobalScript.inst.new_events_text[1307], "\n");
		a.empires[1].power -= 20;
		a.data[8] -= 100;
		a.data[9] -= 150;
		a.empires[1].relations -= 250;
		if (a.influencePRC > a.empires[0].power)
		{
			a.allcountries[48].EstablishGovernment(Government.ProChina);
			a.influencePRC += 20;
			a.allcountries[48].Torg = true;
			a.allcountries[48].Gosstroy = a.allcountries[1].Gosstroy;
			a.allcountries[48].SubGosstroy = a.allcountries[1].SubGosstroy;
		}
		else
		{
			a.allcountries[48].EstablishGovernment(Government.ProAmerican);
			a.influencePRC += 20;
			a.allcountries[48].Torg = true;
			a.allcountries[48].Gosstroy = 3;
			a.allcountries[48].SubGosstroy = 12;
			a.allcountries[48].Gosstroy = 3;
			a.allcountries[48].SubGosstroy = 12;
		}
		politics = GlobalScript.inst.gameState.politics;
		foreach (Politic politic3 in politics)
		{
			if (politic3.traits[0] == 0)
			{
				politic3.loyality -= 300;
			}
			else if (politic3.traits[0] == 1)
			{
				politic3.loyality -= 100;
			}
			else
			{
				politic3.loyality += 300;
			}
		}
	}
}
