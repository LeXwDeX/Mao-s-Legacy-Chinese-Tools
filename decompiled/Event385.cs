using EventsForDLC;
using UnityEngine;

public class Event385 : EventsSecond
{
	private GameState a;

	private int[] press = new int[4];

	private int res1;

	private int res2;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[950];
		a.allcountries[21].inflNATO = 0;
		a.allcountries[21].inflCh = 0;
		if (a.resultOfEvents[384] == 1)
		{
			press[0]++;
		}
		if (a.data[49] > a.data[48])
		{
			press[0] += 2;
		}
		if (a.resultOfEvents[49] == 1)
		{
			press[0]++;
		}
		if (a.resultOfEvents[50] == 3)
		{
			press[0]--;
		}
		if (a.resultOfEvents[67] == 3)
		{
			press[0]--;
		}
		if (a.allcountries[4].Gosstroy == 1)
		{
			press[0]--;
		}
		if (a.allcountries[45].Gosstroy == 2)
		{
			press[0]++;
		}
		if (a.allcountries[8].Gosstroy == 1)
		{
			press[0]++;
		}
		if (a.allcountries[1].isOVD)
		{
			press[0]++;
		}
		if (a.allcountries[1].isSEV)
		{
			press[0]++;
		}
		if (a.empires[1].power > a.empires[0].power)
		{
			press[0]++;
		}
		if (a.empires[1].power > a.data[7])
		{
			press[0]++;
		}
		if (a.modifies[16].active)
		{
			press[0]++;
		}
		if (a.resultOfEvents[384] == 2)
		{
			press[1]++;
		}
		if (a.data[132] == 2)
		{
			press[1]++;
		}
		if (a.allcountries[51].dev > 0)
		{
			press[1]++;
		}
		if (a.allcountries[1].isSEATO)
		{
			press[1]++;
		}
		if (a.allcountries[1].isASEAN)
		{
			press[1]++;
		}
		if (a.resultOfEvents[50] == 4 || a.resultOfEvents[52] == 2)
		{
			press[1]++;
		}
		if (a.allcountries[1].okb)
		{
			press[1]++;
		}
		if (a.allcountries[8].Vyshi && a.allcountries[8].Gosstroy == 0)
		{
			press[1]++;
		}
		if (!a.allcountries[12].proprc && a.allcountries[12].Gosstroy == 0)
		{
			press[1]++;
		}
		if (a.empires[0].power > a.empires[1].power)
		{
			press[1]++;
		}
		if (a.empires[0].power > a.data[7])
		{
			press[1]++;
		}
		if (a.modifies[17].active)
		{
			press[1]++;
		}
		if (a.resultOfEvents[46] == 2)
		{
			press[1]--;
		}
		if (a.influencePRC > a.empires[0].power && a.influencePRC > a.empires[1].power)
		{
			press[2]++;
		}
		if (a.resultOfEvents[384] == 3)
		{
			press[2]++;
		}
		if (a.allcountries[15].cw)
		{
			press[2]++;
		}
		if (a.allcountries[8].Gosstroy == 3)
		{
			press[2]++;
		}
		if (a.modifies[3].active)
		{
			press[2]++;
		}
		if (a.allcountries[86].SubGosstroy == 15)
		{
			press[2]++;
		}
		if (a.allcountries[87].Gosstroy == 2)
		{
			press[2]++;
		}
		if (a.allcountries[11].proprc)
		{
			press[2]++;
		}
		if (a.allcountries[23].proprc)
		{
			press[2]++;
		}
		if (a.empires[0].relations < 500)
		{
			press[2]++;
		}
		if (a.allcountries[1].econ && a.allcountries[1].okb)
		{
			press[2]++;
		}
		if (a.allcountries[1].isSEV || a.allcountries[1].isASEAN)
		{
			press[2]--;
		}
		if (a.allcountries[4].Gosstroy == 2)
		{
			press[3]++;
		}
		if (a.resultOfEvents[384] == 0 && a.event_done[384])
		{
			press[3]++;
		}
		if (a.allcountries[8].Gosstroy == 0 && a.allcountries[8].SubGosstroy == 9)
		{
			press[3]++;
		}
		if (!a.allcountries[1].okb && !a.allcountries[1].isOVD && !a.allcountries[1].isSEATO)
		{
			press[3]++;
		}
		if (a.ingamewars[5].is_going)
		{
			press[3]++;
		}
		if (a.allcountries[51].SubGosstroy == 12)
		{
			press[3]++;
		}
		if (a.allcountries[85].SubGosstroy == 6)
		{
			press[3]++;
		}
		if (a.allcountries[87].SubGosstroy == 6)
		{
			press[3]++;
		}
		if (a.allcountries[86].SubGosstroy == 6)
		{
			press[3]++;
		}
		if (a.allcountries[30].Gosstroy == 3)
		{
			press[3]++;
		}
		if (a.ingamewars[3].is_going)
		{
			press[3]++;
		}
		if (a.allcountries[1].Gosstroy == 2)
		{
			press[3]++;
		}
		Debug.Log("Марше " + press[0]);
		Debug.Log("Миттеран " + press[3]);
		Debug.Log("Жискар " + press[1]);
		Debug.Log("Ширак " + press[2]);
		if (press[0] >= press[1] && press[0] >= press[2] && press[0] >= press[3])
		{
			a.allcountries[21].inflCh = 2;
		}
		else if (press[1] >= press[0] && press[1] >= press[2] && press[1] >= press[3])
		{
			a.allcountries[21].inflCh = 0;
		}
		else if (press[2] >= press[0] && press[2] >= press[1] && press[2] >= press[3])
		{
			a.allcountries[21].inflCh = 3;
		}
		else
		{
			a.allcountries[21].inflCh = 1;
		}
		if (a.allcountries[21].inflCh == 0)
		{
			if (press[0] >= press[2] && press[0] >= press[3])
			{
				a.allcountries[21].inflNATO = 2;
			}
			else if (press[2] >= press[3] && press[2] >= press[0])
			{
				a.allcountries[21].inflNATO = 3;
			}
			else
			{
				a.allcountries[21].inflNATO = 1;
			}
		}
		else if (a.allcountries[21].inflCh == 1)
		{
			if (press[0] >= press[2] && press[0] >= press[1])
			{
				a.allcountries[21].inflNATO = 2;
			}
			else if (press[2] >= press[1] && press[2] >= press[0])
			{
				a.allcountries[21].inflNATO = 3;
			}
			else
			{
				a.allcountries[21].inflNATO = 0;
			}
		}
		else if (a.allcountries[21].inflCh == 2)
		{
			if (press[2] >= press[1] && press[2] >= press[3])
			{
				a.allcountries[21].inflNATO = 3;
			}
			else if (press[3] >= press[1] && press[3] >= press[2])
			{
				a.allcountries[21].inflNATO = 1;
			}
			else
			{
				a.allcountries[21].inflNATO = 0;
			}
		}
		else if (press[0] >= press[1] && press[0] >= press[2])
		{
			a.allcountries[21].inflNATO = 2;
		}
		else if (press[3] >= press[1] && press[3] >= press[0])
		{
			a.allcountries[21].inflNATO = 1;
		}
		else
		{
			a.allcountries[21].inflNATO = 0;
		}
		if (res1 < 10)
		{
			res1 = Random.Range(28, 35);
		}
		if (res2 < 10)
		{
			res2 = Random.Range(20, 27);
		}
		Debug.Log("Первый" + a.allcountries[21].inflCh);
		Debug.Log("Второй" + a.allcountries[21].inflNATO);
		text = string.Format(GlobalScript.inst.new_events_text[951], "\n", GlobalScript.inst.new_events_text[956 + a.allcountries[21].inflCh], GlobalScript.inst.new_events_text[956 + a.allcountries[21].inflNATO], res1, res2);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 2;
		if (a.data[9] >= 100 && a.data[8] + a.data[36] >= 50)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[960 + a.allcountries[21].inflCh], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 50)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[567], 5f);
		}
		button_text[1] = GlobalScript.inst.new_events_text[944];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		name = GlobalScript.inst.new_events_text[950];
		a.modifies[56].active = false;
		if (result_num == 0)
		{
			if (a.allcountries[21].inflNATO == 0)
			{
				press[1] += 2;
			}
			else if (a.allcountries[21].inflNATO == 1)
			{
				press[3] += 2;
			}
			else if (a.allcountries[21].inflNATO == 2)
			{
				press[0] += 2;
			}
			else
			{
				press[2] += 2;
			}
			int num = 0;
			num = ((press[0] >= press[1] && press[0] >= press[2] && press[0] >= press[3]) ? 2 : ((press[1] < press[0] || press[1] < press[2] || press[1] < press[3]) ? ((press[2] < press[0] || press[2] < press[1] || press[2] < press[3]) ? 1 : 3) : 0));
			Debug.Log("Мама твоя" + num);
			Debug.Log("Мама твоя - през ху" + a.allcountries[21].inflCh);
			a.data[131] = num;
			text = string.Format(GlobalScript.inst.new_events_text[964], "\n", GlobalScript.inst.new_events_text[952 + a.allcountries[21].inflCh], GlobalScript.inst.new_events_text[977 + a.allcountries[21].inflCh], GlobalScript.inst.new_events_text[965 + a.allcountries[21].inflCh], GlobalScript.inst.new_events_text[969 + a.allcountries[21].inflNATO], GlobalScript.inst.new_events_text[969 + a.allcountries[21].inflCh], GlobalScript.inst.new_events_text[973 + a.allcountries[21].inflNATO], GlobalScript.inst.new_events_text[973 + a.allcountries[21].inflCh], GlobalScript.inst.new_events_text[956 + num], GlobalScript.inst.new_events_text[1039 + num]);
			switch (num)
			{
			case 0:
				a.allcountries[21].Vyshi = true;
				a.empires[0].power += 50;
				a.data[131] = 0;
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(115);
				}
				a.allcountries[87].spec += 10;
				break;
			case 1:
				a.allcountries[21].SubGosstroy = 4;
				GlobalScript.inst.gameState.modifies[42].active = false;
				GlobalScript.inst.gameState.modifies[43].active = true;
				a.data[131] = 1;
				a.allcountries[87].spec += 5;
				break;
			case 2:
				a.allcountries[21].SubGosstroy = 14;
				a.allcountries[21].Gosstroy = 2;
				GlobalScript.inst.gameState.modifies[42].active = false;
				GlobalScript.inst.gameState.modifies[44].active = true;
				a.data[131] = 2;
				a.allcountries[87].spec -= 10;
				break;
			default:
				a.allcountries[21].SubGosstroy = 5;
				GlobalScript.inst.gameState.modifies[42].active = false;
				GlobalScript.inst.gameState.modifies[45].active = true;
				a.data[131] = 3;
				a.allcountries[87].spec -= 10;
				break;
			}
		}
		else
		{
			text = string.Format(GlobalScript.inst.new_events_text[981], "\n", GlobalScript.inst.new_events_text[956 + a.allcountries[21].inflCh], GlobalScript.inst.new_events_text[1039 + a.allcountries[21].inflCh]);
			a.data[131] = a.allcountries[21].inflCh;
			if (a.allcountries[21].inflCh == 0)
			{
				a.allcountries[21].Vyshi = true;
				a.empires[0].power += 50;
				gameObject.GetComponent<achievements>().Set(115);
				a.data[131] = 0;
			}
			else if (a.allcountries[21].inflCh == 1)
			{
				a.allcountries[21].SubGosstroy = 4;
				GlobalScript.inst.gameState.modifies[42].active = false;
				GlobalScript.inst.gameState.modifies[43].active = true;
				a.data[131] = 1;
			}
			else if (a.allcountries[21].inflCh == 2)
			{
				a.allcountries[21].SubGosstroy = 14;
				a.allcountries[21].Gosstroy = 2;
				GlobalScript.inst.gameState.modifies[42].active = false;
				GlobalScript.inst.gameState.modifies[44].active = true;
				a.data[131] = 2;
			}
			else
			{
				a.allcountries[21].SubGosstroy = 5;
				GlobalScript.inst.gameState.modifies[42].active = false;
				GlobalScript.inst.gameState.modifies[45].active = true;
				a.data[131] = 3;
			}
		}
	}
}
