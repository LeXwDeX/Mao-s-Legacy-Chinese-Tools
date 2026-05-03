using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event417 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1312];
		text = string.Format(GlobalScript.inst.new_events_text[1313], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[690];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1312];
		text = string.Format(GlobalScript.inst.new_events_text[1319], "\n");
		a.allcountries[14].prosov = false;
		a.data[143] += 3;
		a.ingamewars[28] = new War().Name(GlobalScript.inst.new_events_text[1314]).Attacker(GlobalScript.inst.new_events_text[1315]).Defender(GlobalScript.inst.new_events_text[1316])
			.AttackerInfluence(600)
			.DefenderInfluence(400)
			.TickTime(25)
			.SovietSupportDefender.AmericanSupportDefender.CreateWar;
	}
}
