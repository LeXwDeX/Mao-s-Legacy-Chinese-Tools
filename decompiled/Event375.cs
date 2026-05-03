using EventsForDLC;
using UnityEngine;

public class Event375 : EventsSecond
{
	private GameState a;

	private void Awake()
	{
		a = GlobalScript.inst.gameState;
	}

	public override void TextOfEvents(ref string name, ref string text)
	{
		name = GlobalScript.inst.new_events_text[765];
		text = string.Format(GlobalScript.inst.new_events_text[766], "\n", (a.allcountries[35].proprc && a.allcountries[35].okb) ? GlobalScript.inst.new_events_text[775] : null);
	}

	public override void VariantsOfEvents(ref int kolvo_variant, ref string[] button_text, ref GameObject[] button)
	{
		if (a.allcountries[35].proprc && a.allcountries[35].okb)
		{
			kolvo_variant = 5;
		}
		else
		{
			kolvo_variant = 4;
		}
		if (a.data[22] >= 500 && a.data[8] + a.data[36] >= 250)
		{
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[767], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (a.data[8] + a.data[36] < 250)
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[566], 25f);
		}
		else
		{
			button[0].SetActive(value: false);
			button_text[0] = string.Format(GlobalScript.inst.new_events_text[776], 50f);
		}
		button_text[1] = string.Format(GlobalScript.inst.new_events_text[768], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		button_text[2] = string.Format(GlobalScript.inst.new_events_text[769], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		if (a.allcountries[35].proprc && a.allcountries[35].okb)
		{
			if (a.data[22] >= 500 && a.data[8] + a.data[36] >= 350)
			{
				button_text[3] = string.Format(GlobalScript.inst.new_events_text[770], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
			}
			else if (a.data[8] + a.data[36] < 350)
			{
				button[3].SetActive(value: false);
				button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], 35f);
			}
			else
			{
				button[3].SetActive(value: false);
				button_text[3] = string.Format(GlobalScript.inst.new_events_text[776], 50f);
			}
			if (a.data[8] + a.data[36] >= 100)
			{
				button_text[4] = string.Format(GlobalScript.inst.new_events_text[771], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
				return;
			}
			button[4].SetActive(value: false);
			button_text[4] = string.Format(GlobalScript.inst.new_events_text[566], 35f);
		}
		else if (a.data[8] + a.data[36] >= 100 && a.data[22] >= 250 && a.allcountries[51].Torg)
		{
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[772], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
		}
		else if (!a.allcountries[51].Torg)
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[658], 10f);
		}
		else if (a.data[8] + a.data[36] < 100)
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[566], 10f);
		}
		else
		{
			button[3].SetActive(value: false);
			button_text[3] = string.Format(GlobalScript.inst.new_events_text[776], 35f);
		}
	}

	public override void ResultsOfEvents(ref string name, ref string text, int result_num)
	{
		name = GlobalScript.inst.new_events_text[765];
		switch (result_num)
		{
		case 0:
		{
			a.data[8] -= 250;
			a.data[22] -= 500;
			int num3 = 0;
			if (a.influencePRC >= 750)
			{
				text = string.Format(GlobalScript.inst.new_events_text[777], "\n", (num3 <= 0) ? null : ((num3 == 1) ? GlobalScript.inst.new_events_text[780] : GlobalScript.inst.new_events_text[781]));
				a.allcountries[84].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
				GlobalScript.inst.gameState.allcountries[84].Gosstroy = GlobalScript.inst.gameState.allcountries[1].Gosstroy;
				GlobalScript.inst.gameState.allcountries[84].SubGosstroy = GlobalScript.inst.gameState.allcountries[1].SubGosstroy;
				a.empires[1].power -= 50;
				a.influencePRC += 80;
				a.data[1] += 300;
				a.empires[1].relations -= 500;
				a.empires[0].relations += 300;
				if (a.relres)
				{
					a.relres = false;
				}
				break;
			}
			text = string.Format(GlobalScript.inst.new_events_text[778], "\n", (num3 <= 0) ? null : ((num3 == 1) ? GlobalScript.inst.new_events_text[780] : GlobalScript.inst.new_events_text[781]));
			a.data[127] = 1;
			a.influencePRC -= 50;
			if (a.allcountries[7].parts[1])
			{
				a.allcountries[7].parts[1] = false;
				a.allcountries[7].parts[2] = true;
			}
			else
			{
				a.allcountries[7].parts[0] = true;
			}
			a.empires[1].power += 100;
			a.empires[1].relations -= 500;
			a.data[1] -= 300;
			if (a.relres)
			{
				a.relres = false;
			}
			break;
		}
		case 1:
		{
			int num4 = 0;
			text = string.Format(GlobalScript.inst.new_events_text[779], "\n", (num4 <= 0) ? null : ((num4 == 1) ? GlobalScript.inst.new_events_text[780] : GlobalScript.inst.new_events_text[781]));
			if (a.allcountries[7].parts[1])
			{
				a.allcountries[7].parts[1] = false;
				a.allcountries[7].parts[2] = true;
			}
			else
			{
				a.allcountries[7].parts[0] = true;
			}
			a.data[6] += 100;
			a.empires[1].power += 100;
			a.empires[1].relations += 300;
			a.empires[0].relations -= 500;
			a.data[1] -= 300;
			break;
		}
		case 2:
			text = string.Format(GlobalScript.inst.new_events_text[782], "\n");
			a.data[1] -= 300;
			a.empires[1].power += 100;
			if (a.allcountries[7].parts[1])
			{
				a.allcountries[7].parts[1] = false;
				a.allcountries[7].parts[2] = true;
			}
			else
			{
				a.allcountries[7].parts[0] = true;
			}
			break;
		case 3:
		case 4:
			if (a.allcountries[35].proprc && a.allcountries[35].okb)
			{
				switch (result_num)
				{
				case 3:
				{
					a.data[8] -= 350;
					a.data[22] -= 500;
					int num2 = 0;
					if (a.influencePRC > 500 && a.allcountries[35].proprc && a.allcountries[35].okb)
					{
						num2 = 1;
						a.allcountries[84].parts[3] = true;
						a.data[6] += 50;
						a.data[1] += 100;
						a.empires[0].relations -= 150;
					}
					else
					{
						a.data[1] -= 100;
						num2 = 2;
						a.data[6] += 50;
						a.empires[0].relations -= 150;
					}
					if (a.influencePRC >= 750)
					{
						text = string.Format(GlobalScript.inst.new_events_text[777], "\n", (num2 <= 0) ? null : ((num2 == 1) ? GlobalScript.inst.new_events_text[780] : GlobalScript.inst.new_events_text[781]));
						a.allcountries[84].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
						GlobalScript.inst.gameState.allcountries[84].Gosstroy = GlobalScript.inst.gameState.allcountries[1].Gosstroy;
						GlobalScript.inst.gameState.allcountries[84].SubGosstroy = GlobalScript.inst.gameState.allcountries[1].SubGosstroy;
						a.empires[1].power -= 50;
						a.data[1] += 300;
						a.empires[1].relations -= 500;
						a.empires[0].relations += 300;
						if (a.relres)
						{
							a.relres = false;
						}
						break;
					}
					text = string.Format(GlobalScript.inst.new_events_text[778], "\n", (num2 <= 0) ? null : ((num2 == 1) ? GlobalScript.inst.new_events_text[780] : GlobalScript.inst.new_events_text[781]));
					a.data[127] = 1;
					a.influencePRC -= 50;
					if (a.allcountries[7].parts[1])
					{
						a.allcountries[7].parts[1] = false;
						a.allcountries[7].parts[2] = true;
					}
					else
					{
						a.allcountries[7].parts[0] = true;
					}
					a.empires[1].relations -= 500;
					a.data[1] -= 300;
					if (a.relres)
					{
						a.relres = false;
					}
					break;
				}
				case 4:
				{
					if (a.allcountries[7].parts[1])
					{
						a.allcountries[7].parts[1] = false;
						a.allcountries[7].parts[2] = true;
					}
					else
					{
						a.allcountries[7].parts[0] = true;
					}
					a.data[6] += 100;
					a.empires[1].power += 100;
					a.empires[1].relations += 300;
					a.empires[0].relations -= 500;
					int num = 0;
					if (a.influencePRC > 500 && a.allcountries[35].proprc && a.allcountries[35].okb)
					{
						num = 1;
						a.allcountries[84].parts[3] = true;
						a.data[6] += 50;
						a.data[1] += 100;
						a.empires[0].relations -= 150;
					}
					else
					{
						a.data[1] -= 100;
						num = 2;
						a.data[6] += 50;
						a.empires[0].relations -= 150;
					}
					text = string.Format(GlobalScript.inst.new_events_text[777], "\n", (num <= 0) ? null : ((num == 1) ? GlobalScript.inst.new_events_text[780] : GlobalScript.inst.new_events_text[781]));
					break;
				}
				}
			}
			else
			{
				if (result_num != 3)
				{
					break;
				}
				text = string.Format(GlobalScript.inst.new_events_text[783], "\n");
				a.data[8] -= 100;
				a.data[22] -= 250;
				if (a.influencePRC + a.empires[0].power >= 750)
				{
					text = string.Format(GlobalScript.inst.new_events_text[782], "\n");
					a.allcountries[84].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
					GlobalScript.inst.gameState.allcountries[84].Gosstroy = GlobalScript.inst.gameState.allcountries[1].Gosstroy;
					GlobalScript.inst.gameState.allcountries[84].SubGosstroy = GlobalScript.inst.gameState.allcountries[1].SubGosstroy;
					a.empires[1].power -= 50;
					a.influencePRC += 80;
					a.data[1] += 300;
					a.empires[1].relations -= 500;
					a.empires[0].relations += 300;
					if (a.relres)
					{
						a.relres = false;
					}
					break;
				}
				text = string.Format(GlobalScript.inst.new_events_text[783], "\n");
				a.data[127] = 1;
				a.influencePRC -= 50;
				if (a.allcountries[7].parts[1])
				{
					a.allcountries[7].parts[1] = false;
					a.allcountries[7].parts[2] = true;
				}
				else
				{
					a.allcountries[7].parts[0] = true;
				}
				a.empires[1].power += 100;
				a.empires[1].relations -= 500;
				a.data[1] -= 300;
				if (a.relres)
				{
					a.relres = false;
				}
			}
			break;
		}
	}
}
