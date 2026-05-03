using EventsForDLC;
using UnityEngine;

public class Event440 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[1686];
		text = GlobalScript.inst.new_events_text[1687];
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		button[0].SetActive(value: false);
		button_text[0] = string.Format(GlobalScript.inst.new_events_text[1688]);
		if (GlobalScript.inst.gameState.resultOfEvents[437] == 1)
		{
			button_text[1] = GlobalScript.inst.new_events_text[1689];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = string.Format(GlobalScript.inst.new_events_text[1690]);
		}
		if (GlobalScript.inst.gameState.resultOfEvents[437] == 0)
		{
			button_text[2] = GlobalScript.inst.new_events_text[1691];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = string.Format(GlobalScript.inst.new_events_text[1692]);
		}
		button[3].SetActive(value: false);
		button_text[3] = string.Format(GlobalScript.inst.new_events_text[1693]);
		button_text[4] = GlobalScript.inst.new_events_text[1694];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[1686];
		if (result_num == 1)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1695]);
			a.data[28] -= 100;
			a.data[6] += 50;
			a.data[1] += 100;
			a.data[54] += 40;
			a.data[16] += 14;
		}
		if (result_num == 2)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1696]);
			a.data[6] -= 50;
			a.data[1] += 100;
			a.data[17] += 19;
		}
		if (result_num == 4)
		{
			text = string.Format(GlobalScript.inst.new_events_text[1697]);
		}
		a.data[1] -= 100;
	}
}
