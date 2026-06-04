using EventsForDLC;
using UnityEngine;

public class Event433 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1492];
		text = string.Format(GlobalScript.inst.new_events_text[1493], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 1;
		button_text[0] = GlobalScript.inst.new_events_text[1494];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1492];
		text = string.Format(GlobalScript.inst.new_events_text[1495], "\n");
		for (int i = 0; i < a.allcountries.Length; i++)
		{
			if (a.allcountries[i].isOVD)
			{
				a.allcountries[i].isOVD = false;
			}
		}
		a.empires[1].power -= 350;
		a.empires[0].power += 100;
		a.influencePRC += 100;
	}
}
