using EventsForDLC;
using UnityEngine;

public class Event374 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[749];
		text = string.Format(GlobalScript.inst.new_events_text[750], "\n");
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 5;
		button_text[0] = GlobalScript.inst.new_events_text[751];
		button_text[1] = GlobalScript.inst.new_events_text[752];
		button_text[2] = GlobalScript.inst.new_events_text[753];
		button_text[3] = GlobalScript.inst.new_events_text[754];
		button_text[4] = GlobalScript.inst.new_events_text[755];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_events_text[749];
		switch (result_num)
		{
		case 0:
			if (a.influencePRC >= 500 && !a.allcountries[45].isNATO && !a.allcountries[94].isNATO && !a.allcountries[84].isNATO)
			{
				text = string.Format(GlobalScript.inst.new_events_text[756], "\n");
				a.data[127] = 100;
				a.allcountries[94].name = GlobalScript.inst.new_events_text[762];
				a.allcountries[94].SubGosstroy = 4;
				a.allcountries[94].Torg = true;
				a.allcountries[94].parts[0] = true;
				a.data[7] += 30;
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(135);
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[761], "\n");
				a.data[127] = 1;
				a.influencePRC -= 50;
			}
			break;
		case 1:
			if (a.influencePRC >= 650 && a.data[129] > 0)
			{
				text = string.Format(GlobalScript.inst.new_events_text[757], "\n");
				a.data[127] = 100;
				a.allcountries[94].name = GlobalScript.inst.new_events_text[763];
				a.allcountries[94].Gosstroy = a.allcountries[45].Gosstroy;
				a.allcountries[45].parts[0] = true;
				a.data[7] += 10;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[761], "\n");
				a.data[127] = 1;
				a.influencePRC -= 50;
			}
			break;
		case 2:
			if (a.influencePRC >= 750 && !a.allcountries[45].isNATO && !a.allcountries[94].isNATO && a.data[129] <= 0)
			{
				text = string.Format(GlobalScript.inst.new_events_text[758], "\n");
				a.data[127] = 100;
				a.allcountries[94].name = GlobalScript.inst.new_events_text[735];
				a.allcountries[94].Gosstroy = a.allcountries[84].Gosstroy;
				a.allcountries[84].parts[4] = true;
				a.data[7] += 10;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[761], "\n");
				a.data[127] = 1;
				a.influencePRC -= 50;
			}
			break;
		case 3:
			if (a.influencePRC >= 500 && ((a.allcountries[94].isNATO && !a.allcountries[84].isNATO) || a.data[129] > 0))
			{
				text = string.Format(GlobalScript.inst.new_events_text[759], "\n");
				a.data[127] = 100;
				a.allcountries[94].name = GlobalScript.inst.new_events_text[764];
				a.allcountries[94].SubGosstroy = 4;
				a.data[7] += 10;
				a.allcountries[94].Torg = true;
				a.allcountries[94].parts[0] = true;
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[761], "\n");
				a.data[127] = 1;
				a.influencePRC -= 50;
			}
			break;
		default:
			text = string.Format(GlobalScript.inst.new_events_text[760], "\n");
			a.data[127] = 1;
			break;
		}
	}
}
