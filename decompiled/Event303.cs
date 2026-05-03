using EventsForDLC;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event303 : EventsSecond
{
	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[50];
		text = string.Format(GlobalScript.inst.new_events_text[51]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		button_text[0] = GlobalScript.inst.new_events_text[52];
		if (GlobalScript.inst.gameState.data[9] >= 150)
		{
			button_text[1] = GlobalScript.inst.new_events_text[53];
			return;
		}
		button[1].SetActive(value: false);
		button_text[1] = string.Format(GlobalScript.inst.new_events_text[54]);
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[50];
		switch (result_num)
		{
		case 0:
			text = GlobalScript.inst.new_events_text[55];
			GlobalScript.inst.gameState.data[35] = 7;
			SceneManager.LoadScene("Ending");
			break;
		case 1:
		{
			text = GlobalScript.inst.new_events_text[56];
			GlobalScript.inst.gameState.party_ideology[0] = 0;
			GlobalScript.inst.gameState.data[5] -= 150;
			GlobalScript.inst.gameState.data[6] -= 600;
			GlobalScript.inst.gameState.data[7] -= 300;
			GlobalScript.inst.gameState.data[8] -= 150;
			GlobalScript.inst.gameState.data[12] -= 500;
			GlobalScript.inst.gameState.empires[0].relations -= 500;
			GlobalScript.inst.gameState.data[22] -= 500;
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 0)
				{
					politic.loyality -= 250;
					politic.power -= 250;
				}
			}
			if (GlobalScript.inst.gameState.iron_and_blood)
			{
				GameObject.Find("Ach(Clone)").GetComponent<achievements>().Set(112);
			}
			break;
		}
		}
	}
}
