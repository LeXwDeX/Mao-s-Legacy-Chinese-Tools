using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event371 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[688];
		text = string.Format(GlobalScript.inst.new_events_text[689], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[690];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[688];
		if (result_num == 0)
		{
			text = string.Format(GlobalScript.inst.new_events_text[691], "\n");
			a.Israellost = false;
			a.ingamewars[13] = new War().Name(GlobalScript.inst.new_events_text[692]).Attacker(GlobalScript.inst.new_events_text[693]).Defender(GlobalScript.inst.new_events_text[694])
				.TickTime(12)
				.AttackerInfluence(600)
				.DefenderInfluence(400)
				.SovietSupportDefender.AmericanSupportAttacker.CreateWar;
		}
	}
}
