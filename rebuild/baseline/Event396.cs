using EventsForDLC;
using KGWar;
using UnityEngine;

public class Event396 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1105];
		text = string.Format(GlobalScript.inst.new_events_text[1106], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1107];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1105];
		text = string.Format(GlobalScript.inst.new_events_text[1108], "\n");
		a.empires[0].power -= 10;
		a.ingamewars[23] = new War().Name(GlobalScript.inst.new_events_text[1109]).Attacker(GlobalScript.inst.new_events_text[1110]).Defender(GlobalScript.inst.new_events_text[1111])
			.AttackerInfluence(200)
			.DefenderInfluence(800)
			.TickTime(30)
			.AmericanSupportDefender.CreateWar;
		if (!a.allcountries[1].isSEV)
		{
			GlobalScript.inst.gameState.ingamewars[23].ussr_place = 1;
		}
	}
}
