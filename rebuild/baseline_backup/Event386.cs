using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event386 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1023];
		text = string.Format(GlobalScript.inst.new_events_text[1001], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1002];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1023];
		int num = 0;
		a.data[143]++;
		text = string.Format(GlobalScript.inst.new_events_text[1005], "\n");
		if (GlobalScript.inst.gameState.allcountries[13].stab > 0)
		{
			num = 100;
		}
		a.ingamewars[20] = new War().Name(GlobalScript.inst.new_events_text[1023]).Attacker(GlobalScript.inst.new_events_text[1003]).Defender(GlobalScript.inst.new_events_text[1004])
			.AttackerInfluence(500 + num)
			.DefenderInfluence(500 - num)
			.TickTime(100)
			.SovietSupportAttacker.AmericanSupportDefender.CreateWar;
	}
}
