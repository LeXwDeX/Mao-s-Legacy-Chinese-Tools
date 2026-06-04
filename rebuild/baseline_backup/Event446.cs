using EventsForDLC;
using UnityEngine;

public class Event446 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_texts[724];
		text = GlobalScript.inst.new_texts[725];
		if (GlobalScript.inst.gameState.empires[1].leaders[3].support > 0)
		{
			text += GlobalScript.inst.new_texts[726];
		}
		if (GlobalScript.inst.gameState.empires[1].leaders[1].support > 0)
		{
			text += GlobalScript.inst.new_texts[727];
		}
		text += GlobalScript.inst.new_texts[728];
		if (GlobalScript.inst.gameState.data[89] <= 0)
		{
			GlobalScript.inst.gameState.empires[1].leaders[3].support--;
		}
		if (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power)
		{
			GlobalScript.inst.gameState.empires[1].leaders[2].support++;
		}
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 4;
		if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.empires[1].leaders[3].support > 0))
		{
			button_text[0] = GlobalScript.inst.new_texts[717];
		}
		else if (GlobalScript.inst.gameState.empires[1].leaders[3].support <= 0)
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_texts[718];
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = GlobalScript.inst.new_texts[719];
		}
		if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.empires[1].leaders[1].support != 0))
		{
			button_text[1] = GlobalScript.inst.new_texts[720];
		}
		else if (GlobalScript.inst.gameState.empires[1].leaders[1].support <= 0)
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_texts[721];
		}
		else
		{
			button[1].SetActive(value: false);
			button_text[1] = GlobalScript.inst.new_texts[719];
		}
		if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
		{
			button_text[2] = GlobalScript.inst.new_texts[722];
		}
		else
		{
			button[2].SetActive(value: false);
			button_text[2] = GlobalScript.inst.new_texts[719];
		}
		button_text[3] = GlobalScript.inst.new_texts[723];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_texts[724];
		switch (result_num)
		{
		case 0:
			GlobalScript.inst.gameState.empires[1].leaders[3].support += 2;
			GlobalScript.inst.gameState.data[9] -= 100;
			break;
		case 1:
			GlobalScript.inst.gameState.empires[1].leaders[1].support += 2;
			GlobalScript.inst.gameState.data[9] -= 100;
			break;
		case 2:
			GlobalScript.inst.gameState.empires[1].leaders[3].support += 2;
			GlobalScript.inst.gameState.data[9] -= 100;
			break;
		}
		if (GlobalScript.inst.gameState.empires[1].leaders[3].support >= GlobalScript.inst.gameState.empires[1].leaders[2].support && GlobalScript.inst.gameState.empires[1].leaders[3].support >= GlobalScript.inst.gameState.empires[1].leaders[1].support)
		{
			GlobalScript.inst.gameState.empires[1].leaders[3].support += 2;
			GlobalScript.inst.gameState.empires[1].leaders[4].support++;
			GlobalScript.inst.gameState.empires[1].leaders[6].support++;
			text = GlobalScript.inst.new_texts[729];
		}
		else if (GlobalScript.inst.gameState.empires[1].leaders[1].support >= GlobalScript.inst.gameState.empires[1].leaders[2].support && GlobalScript.inst.gameState.empires[1].leaders[1].support >= GlobalScript.inst.gameState.empires[1].leaders[3].support)
		{
			GlobalScript.inst.gameState.empires[1].leaders[3].support -= 10;
			GlobalScript.inst.gameState.empires[1].leaders[6].support--;
			text = GlobalScript.inst.new_texts[730];
		}
		else
		{
			GlobalScript.inst.gameState.empires[1].leaders[3].support -= 5;
			GlobalScript.inst.gameState.empires[1].leaders[2].support++;
			text = GlobalScript.inst.new_texts[731];
		}
	}
}
