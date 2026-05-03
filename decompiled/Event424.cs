using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event424 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1376];
		text = string.Format(GlobalScript.inst.new_events_text[1377], "\n", a.allcountries[86].based ? GlobalScript.inst.new_events_text[1386] : null, a.allcountries[86].based ? GlobalScript.inst.new_events_text[1387] : null);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (a.data[8] + a.data[36] >= 100 && a.data[9] >= 150 && a.allcountries[86].based)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[1378], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (!a.allcountries[86].based)
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_events_text[1379];
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 15f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[1380];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1376];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1381], "\n");
			a.data[8] -= 100;
			a.data[9] -= 150;
			a.ingamewars[30] = new War().Name(GlobalScript.inst.new_events_text[1382]).Attacker(GlobalScript.inst.new_events_text[1383]).Defender(GlobalScript.inst.new_events_text[1384])
				.AttackerInfluence(300)
				.DefenderInfluence(700)
				.CreateWar;
			a.allcountries[87].spec -= 10;
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[1385], "\n");
		}
	}
}
