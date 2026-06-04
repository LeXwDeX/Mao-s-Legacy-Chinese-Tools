using EventsForDLC;
using UnityEngine;

public class Event372 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[698];
		int num = 0;
		if (a.allcountries[35].SubGosstroy == 9)
		{
			num++;
		}
		if (a.allcountries[8].SubGosstroy == 9)
		{
			num++;
		}
		if (a.allcountries[14].SubGosstroy == 9)
		{
			num++;
		}
		text = string.Format(GlobalScript.inst.new_events_text[699], "\n", GlobalScript.inst.new_events_text[702 + num]);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		kolvo_variant = 3;
		button_text[0] = GlobalScript.inst.new_events_text[700];
		button_text[1] = GlobalScript.inst.new_events_text[701];
		button_text[2] = GlobalScript.inst.new_events_text[1012];
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[698];
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		int num = 0;
		if (a.allcountries[35].SubGosstroy == 9 || a.allcountries[35].proprc)
		{
			flag = false;
			num++;
		}
		if (a.allcountries[8].SubGosstroy == 9 || a.allcountries[8].proprc)
		{
			flag3 = false;
			num++;
		}
		if (a.allcountries[14].SubGosstroy == 9 || a.allcountries[14].proprc)
		{
			flag2 = false;
			num++;
		}
		int num2 = 0;
		switch (result_num)
		{
		case 0:
		{
			GlobalScript.inst.gameState.data[143] -= 7;
			a.data[124] = 100;
			if (a.data[128] == 1 && !a.allcountries[14].isOVD && !a.allcountries[8].isOVD && !a.allcountries[14].okb && !a.allcountries[8].okb)
			{
				a.ingamewars[3].is_going = true;
			}
			GameObject gameObject = GameObject.Find("Ach(Clone)");
			if (a.influencePRC >= 800 && num == 3 && !a.allcountries[84].Vyshi && !a.allcountries[84].isNATO)
			{
				text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[707], GlobalScript.inst.new_events_text[708], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
				a.allcountries[84].Gosstroy = 2;
				a.allcountries[84].SubGosstroy = 8;
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(136);
				}
				a.influencePRC += 100;
				a.data[124] = 100;
				a.allcountries[84].parts[1] = true;
				a.allcountries[95].Gosstroy = 2;
				a.allcountries[95].SubGosstroy = 3;
				a.data[143] += 3;
			}
			else if (a.influencePRC >= 600 && num >= 3)
			{
				text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[710], GlobalScript.inst.new_events_text[708], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
				a.allcountries[84].Gosstroy = 2;
				a.allcountries[84].SubGosstroy = 8;
				a.influencePRC += 70;
				if (GlobalScript.inst.gameState.iron_and_blood)
				{
					a.data[124] = 100;
				}
				a.allcountries[14].parts[1] = true;
				a.allcountries[95].Gosstroy = 2;
				a.allcountries[95].SubGosstroy = 3;
				a.data[143] += 3;
			}
			else if (a.influencePRC >= 500 && num >= 2 && flag2)
			{
				a.influencePRC += 50;
				a.data[124] = 100;
				if (flag2 && flag3)
				{
					text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[711], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[708] : GlobalScript.inst.new_events_text[713], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
					a.allcountries[14].parts[2] = true;
					a.allcountries[95].Gosstroy = 2;
					a.allcountries[95].SubGosstroy = 3;
					a.data[143] += 3;
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[712], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[708] : GlobalScript.inst.new_events_text[713], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
					a.allcountries[14].parts[3] = true;
					a.allcountries[95].Gosstroy = 2;
					a.allcountries[95].SubGosstroy = 3;
				}
				if (a.data[126] > 0 && !a.allcountries[84].isNATO)
				{
					a.allcountries[84].Gosstroy = 2;
					a.allcountries[84].SubGosstroy = 8;
				}
			}
			else if (a.influencePRC >= 400 && num >= 1)
			{
				int num7 = Random.Range(0, 4);
				a.influencePRC += 30;
				a.data[124] = 100;
				if (a.data[126] > 0 && !a.allcountries[84].isNATO)
				{
					a.allcountries[84].Gosstroy = 2;
					a.allcountries[84].SubGosstroy = 8;
					a.allcountries[35].puppetOf = -1;
					a.allcountries[8].puppetOf = -1;
					a.allcountries[14].puppetOf = -1;
				}
				if (num >= 1 && num < 3)
				{
					if (a.data[126] > 0 && !a.allcountries[84].isNATO)
					{
						a.allcountries[84].Gosstroy = 2;
						a.allcountries[84].SubGosstroy = 8;
						a.allcountries[35].puppetOf = -1;
						a.allcountries[8].puppetOf = -1;
						a.allcountries[14].puppetOf = -1;
					}
					if (flag2)
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[714], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[708] : GlobalScript.inst.new_events_text[713], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
						a.allcountries[14].parts[0] = true;
						a.data[143] += 3;
					}
					else if (flag3)
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[715], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[708] : GlobalScript.inst.new_events_text[713], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
						a.allcountries[8].parts[0] = true;
					}
					else
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[716], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[708] : GlobalScript.inst.new_events_text[713], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
						a.allcountries[35].parts[0] = true;
					}
				}
				else if (num == 3)
				{
					switch (num7)
					{
					case 1:
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[716], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[708] : GlobalScript.inst.new_events_text[713], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
						a.allcountries[35].parts[0] = true;
						break;
					case 2:
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[714], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[708] : GlobalScript.inst.new_events_text[713], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
						a.allcountries[14].parts[0] = true;
						a.data[143] += 3;
						break;
					default:
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[715], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[708] : GlobalScript.inst.new_events_text[713], (a.data[126] > 0 && !a.allcountries[84].isNATO) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 0) ? GlobalScript.inst.new_events_text[748] : null);
						a.allcountries[8].parts[0] = true;
						break;
					}
				}
				if (flag2 && a.allcountries[84].Gosstroy == 2 && a.allcountries[14].puppetOf == 84)
				{
					a.allcountries[14].Gosstroy = 2;
					a.allcountries[14].Gosstroy = 8;
				}
				if (flag && a.allcountries[84].Gosstroy == 2 && a.allcountries[35].puppetOf == 84)
				{
					a.allcountries[35].Gosstroy = 2;
					a.allcountries[35].Gosstroy = 8;
				}
				if (flag3 && a.allcountries[84].Gosstroy == 2 && a.allcountries[8].puppetOf == 84)
				{
					a.allcountries[8].Gosstroy = 2;
					a.allcountries[8].Gosstroy = 8;
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[717], "\n");
				a.influencePRC -= 100;
				a.data[124] = 1;
				a.data[1] -= 500;
			}
			break;
		}
		case 1:
			a.data[124] = 100;
			GlobalScript.inst.gameState.data[143] -= 5;
			if (num == 3 && !a.allcountries[84].isNATO)
			{
				num2 = 708;
				a.allcountries[84].Gosstroy = 2;
				a.allcountries[84].SubGosstroy = 8;
			}
			else if (a.influencePRC >= 800)
			{
				num2 = 719;
				a.allcountries[84].Gosstroy = 3;
				a.allcountries[84].SubGosstroy = 5;
			}
			else
			{
				num2 = 713;
			}
			if (a.influencePRC >= 600 && num == 3)
			{
				Debug.Log("ДА 1 " + num);
				a.allcountries[35].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
				a.allcountries[35].puppetOf = -1;
				a.allcountries[35].Gosstroy = a.allcountries[1].Gosstroy;
				a.allcountries[35].SubGosstroy = a.allcountries[1].SubGosstroy;
				a.allcountries[8].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
				a.allcountries[8].puppetOf = -1;
				a.allcountries[8].Gosstroy = a.allcountries[1].Gosstroy;
				a.allcountries[8].SubGosstroy = a.allcountries[1].SubGosstroy;
				a.allcountries[14].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
				a.allcountries[14].puppetOf = -1;
				a.allcountries[14].Gosstroy = a.allcountries[1].Gosstroy;
				a.allcountries[14].SubGosstroy = a.allcountries[1].SubGosstroy;
				if (a.data[128] == 1 && !a.allcountries[14].proprc && !a.allcountries[8].proprc)
				{
					a.data[128] = 2;
					a.ingamewars[3].is_going = true;
				}
				text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[720], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
				a.influencePRC += 70;
			}
			else if (a.influencePRC >= 500 && num >= 2)
			{
				a.influencePRC += 50;
				Debug.Log("ДА 2 " + num);
				int num3 = 0;
				int num4 = 0;
				if (num >= 2)
				{
					while (num3 < 3)
					{
						Random.Range(0, 4);
						num3++;
						num4 = num3 switch
						{
							1 => 14, 
							2 => 8, 
							_ => 35, 
						};
						a.allcountries[num4].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
						a.allcountries[num4].puppetOf = -1;
						a.allcountries[num4].Gosstroy = a.allcountries[1].Gosstroy;
						a.allcountries[num4].SubGosstroy = a.allcountries[1].SubGosstroy;
						if (a.data[128] == 1 && !a.allcountries[14].proprc && !a.allcountries[8].proprc)
						{
							a.data[128] = 2;
							a.ingamewars[3].is_going = true;
						}
					}
					Debug.Log("COUNT " + num);
					Debug.Log("COUNT " + num4);
					Debug.Log("COUNT " + num3);
					if (num4 == 1 && num4 == 2)
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[721], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
					}
					else if (num4 == 1 && num4 == 3)
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[722], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
					}
					else
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[723], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
					}
					break;
				}
				Debug.Log("ДА 3" + num);
				if (flag)
				{
					a.allcountries[35].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
					a.allcountries[35].puppetOf = -1;
					a.allcountries[35].Gosstroy = a.allcountries[1].Gosstroy;
					a.allcountries[35].SubGosstroy = a.allcountries[1].SubGosstroy;
				}
				if (flag2)
				{
					a.allcountries[14].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
					a.allcountries[14].puppetOf = -1;
					a.allcountries[14].Gosstroy = a.allcountries[1].Gosstroy;
					a.allcountries[14].SubGosstroy = a.allcountries[1].SubGosstroy;
				}
				if (flag3)
				{
					a.allcountries[8].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
					a.allcountries[8].puppetOf = -1;
					a.allcountries[8].Gosstroy = a.allcountries[1].Gosstroy;
					a.allcountries[8].SubGosstroy = a.allcountries[1].SubGosstroy;
				}
				if (a.data[128] == 1 && !a.allcountries[14].proprc && !a.allcountries[8].proprc)
				{
					a.data[128] = 2;
					a.ingamewars[3].is_going = true;
				}
				if (flag2 && flag3)
				{
					text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[721], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
				}
				else if (flag3 && flag)
				{
					text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[722], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
				}
				else
				{
					text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[723], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
				}
			}
			else if (a.influencePRC >= 400 && num >= 1)
			{
				int num5 = 0;
				int num6 = 0;
				a.influencePRC += 30;
				if (num >= 1)
				{
					Debug.Log("ДА 4 " + num);
					while (num5 < 2)
					{
						Random.Range(0, 4);
						num5++;
						num6 = num5 switch
						{
							1 => 14, 
							2 => 8, 
							_ => 35, 
						};
						a.allcountries[num6].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
						a.allcountries[num6].puppetOf = -1;
						GlobalScript.inst.gameState.allcountries[num6].Gosstroy = GlobalScript.inst.gameState.allcountries[1].Gosstroy;
						a.allcountries[num6].SubGosstroy = a.allcountries[1].SubGosstroy;
						if (a.data[128] == 1 && !a.allcountries[14].proprc && !a.allcountries[8].proprc)
						{
							a.data[128] = 2;
							a.ingamewars[3].is_going = true;
						}
						switch (num6)
						{
						case 1:
							text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[724], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
							break;
						case 2:
							text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[725], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
							break;
						default:
							text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[726], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
							break;
						}
					}
				}
				else
				{
					Debug.Log("ДА 5 " + num);
					if (flag)
					{
						a.allcountries[35].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
						a.allcountries[35].puppetOf = -1;
						a.allcountries[35].Gosstroy = a.allcountries[1].Gosstroy;
						a.allcountries[35].SubGosstroy = a.allcountries[1].SubGosstroy;
					}
					if (flag2)
					{
						a.allcountries[14].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
						a.allcountries[14].puppetOf = -1;
						a.allcountries[14].Gosstroy = a.allcountries[1].Gosstroy;
						a.allcountries[14].SubGosstroy = a.allcountries[1].SubGosstroy;
					}
					if (flag3)
					{
						a.allcountries[8].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
						a.allcountries[8].puppetOf = -1;
						a.allcountries[8].Gosstroy = a.allcountries[1].Gosstroy;
						a.allcountries[8].SubGosstroy = a.allcountries[1].SubGosstroy;
					}
					if (a.data[128] == 1 && !a.allcountries[14].proprc && !a.allcountries[8].proprc)
					{
						a.data[128] = 2;
						a.ingamewars[3].is_going = true;
					}
					if (flag2)
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[724], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
					}
					else if (flag3)
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[725], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
					}
					else
					{
						text = string.Format(GlobalScript.inst.new_events_text[706], "\n", GlobalScript.inst.new_events_text[726], GlobalScript.inst.new_events_text[num2], (a.data[126] > 0) ? GlobalScript.inst.new_events_text[709] : null, (a.data[128] > 1) ? GlobalScript.inst.new_events_text[748] : null);
					}
				}
				if (flag2 && a.allcountries[84].Gosstroy == 2 && a.allcountries[14].puppetOf == 84)
				{
					a.allcountries[14].Gosstroy = 2;
					a.allcountries[14].Gosstroy = 8;
				}
				if (flag && a.allcountries[84].Gosstroy == 2 && a.allcountries[35].puppetOf == 84)
				{
					a.allcountries[35].Gosstroy = 2;
					a.allcountries[35].Gosstroy = 8;
				}
				if (flag3 && a.allcountries[84].Gosstroy == 2 && a.allcountries[8].puppetOf == 84)
				{
					a.allcountries[8].Gosstroy = 2;
					a.allcountries[8].Gosstroy = 8;
				}
			}
			else
			{
				text = string.Format(GlobalScript.inst.new_events_text[717], "\n");
				a.influencePRC -= 100;
				a.data[124] = 1;
				a.data[1] -= 500;
			}
			break;
		default:
			a.data[124] = 1;
			text = string.Format(GlobalScript.inst.new_events_text[718], "\n");
			break;
		}
	}
}
