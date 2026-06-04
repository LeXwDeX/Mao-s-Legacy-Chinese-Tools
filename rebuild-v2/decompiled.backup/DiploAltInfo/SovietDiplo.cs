using KGEvent;
using UnityEngine;

namespace DiploAltInfo;

public class SovietDiplo
{
	public static void CountryButtons(MinorCountries this_number, MapChangesScript map1)
	{
		switch (this_number)
		{
		case MinorCountries.Afghanistan:
			map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[37], 0);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 1);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 2);
			break;
		case MinorCountries.Iran:
			map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 3);
			break;
		default:
			map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[37], 0);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[38], 3);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[80], 2);
			break;
		case MinorCountries.USSR:
		case MinorCountries.Sudan:
		case MinorCountries.Morocco:
		case MinorCountries.Tunisia:
		case MinorCountries.Niger:
		case MinorCountries.Mali:
		case MinorCountries.Mauritania:
		case MinorCountries.Nigeria:
		case MinorCountries.Benin:
		case MinorCountries.Ghana:
		case MinorCountries.CoteDIvoire:
		case MinorCountries.CAR:
		case MinorCountries.Cameroon:
		case MinorCountries.Liberia:
		case MinorCountries.Guinea:
			break;
		}
		if (this_number == MinorCountries.Sudan || this_number == MinorCountries.Niger || this_number == MinorCountries.Mali || this_number == MinorCountries.Mauritania || this_number == MinorCountries.Tunisia || this_number == MinorCountries.Morocco || this_number == MinorCountries.CAR || this_number == MinorCountries.Cameroon || this_number == MinorCountries.Nigeria || this_number == MinorCountries.Benin || this_number == MinorCountries.Ghana || this_number == MinorCountries.CoteDIvoire || this_number == MinorCountries.Liberia || this_number == MinorCountries.Guinea)
		{
			map1.buttons[0].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[277], 4);
			map1.buttons[1].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[519], 6);
			map1.buttons[3].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[520], 8);
			map1.buttons[2].GetComponent<DiploButtonScript>().Show(GlobalScript.inst.other_text[26], 7);
		}
	}

	public static void ButtonsReq(int this_type, ref string this_opis, ref int number_uslovie, ref bool[] uslovie_bool, ref string[] uslovie_text, MinorCountries selected_country)
	{
		_ = GlobalScript.inst.gameState;
		switch (this_type)
		{
		case 0:
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.other_text[488]);
			if (GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy == 0)
			{
				uslovie_bool[0] = GlobalScript.inst.gameState.data[6] > 390 && GlobalScript.inst.gameState.data[6] < 800;
				uslovie_text[0] = string.Format(GlobalScript.inst.other_text[487], ">", "39", "<", "80");
			}
			else if (GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy == 1)
			{
				uslovie_bool[0] = GlobalScript.inst.gameState.data[6] > 690;
				uslovie_text[0] = string.Format(GlobalScript.inst.other_text[486], ">", "69");
			}
			else if (GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy == 2)
			{
				uslovie_bool[0] = GlobalScript.inst.gameState.data[6] > 390 && GlobalScript.inst.gameState.data[6] < 850;
				uslovie_text[0] = string.Format(GlobalScript.inst.other_text[487], ">", "39", "<", "85");
			}
			else if (GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy == 3)
			{
				uslovie_bool[0] = GlobalScript.inst.gameState.data[6] < 500;
				uslovie_text[0] = string.Format(GlobalScript.inst.other_text[486], "<", "50");
			}
			uslovie_bool[1] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].Torg;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[489]);
			uslovie_bool[2] = GlobalScript.inst.gameState.data[12] >= 500;
			uslovie_text[2] = string.Format(GlobalScript.inst.other_text[45]);
			break;
		case 1:
			number_uslovie = 3;
			this_opis = string.Format(GlobalScript.inst.other_text[81]);
			uslovie_bool[0] = GlobalScript.inst.gameState.allcountries[(int)selected_country].Torg;
			uslovie_text[0] = string.Format(GlobalScript.inst.other_text[46]);
			uslovie_bool[1] = GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy == 1 && GlobalScript.inst.gameState.allcountries[(int)selected_country].prosov;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[490]);
			uslovie_bool[2] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].isSEV && !GlobalScript.inst.gameState.allcountries[(int)selected_country].econ && !GlobalScript.inst.gameState.allcountries[(int)selected_country].isASEAN;
			uslovie_text[2] = string.Format(GlobalScript.inst.other_text[88]);
			break;
		case 2:
			number_uslovie = 4;
			this_opis = string.Format(GlobalScript.inst.other_text[82]);
			uslovie_bool[0] = GlobalScript.inst.gameState.allcountries[(int)selected_country].isSEV;
			uslovie_text[0] = string.Format(GlobalScript.inst.other_text[494]);
			uslovie_bool[1] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].isOVD && !GlobalScript.inst.gameState.allcountries[(int)selected_country].isNATO && !GlobalScript.inst.gameState.allcountries[(int)selected_country].oar;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[51]);
			uslovie_bool[2] = GlobalScript.inst.gameState.data[22] >= 20;
			uslovie_text[2] = string.Format(GlobalScript.inst.other_text[492], "2");
			uslovie_bool[3] = GlobalScript.inst.gameState.data[6] > 790;
			uslovie_text[3] = string.Format(GlobalScript.inst.other_text[486], ">", "79");
			break;
		case 3:
			number_uslovie = 2;
			this_opis = string.Format(GlobalScript.inst.other_text[81]);
			uslovie_bool[0] = GlobalScript.inst.gameState.allcountries[(int)selected_country].Torg;
			uslovie_text[0] = string.Format(GlobalScript.inst.other_text[46]);
			uslovie_bool[1] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].isSEV && !GlobalScript.inst.gameState.allcountries[(int)selected_country].econ && !GlobalScript.inst.gameState.allcountries[(int)selected_country].isASEAN && !GlobalScript.inst.gameState.allcountries[(int)selected_country].isEU && !GlobalScript.inst.gameState.allcountries[(int)selected_country].isOil;
			uslovie_text[1] = string.Format(GlobalScript.inst.other_text[491]);
			if (GlobalScript.inst.gameState.allcountries[(int)selected_country].Vyshi)
			{
				number_uslovie = 3;
				uslovie_bool[2] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].Vyshi;
				uslovie_text[2] = string.Format(GlobalScript.inst.other_text[91]);
			}
			else if (GlobalScript.inst.gameState.allcountries[(int)selected_country].proprc && !GlobalScript.inst.gameState.allcountries[1].isSEV)
			{
				number_uslovie = 3;
				uslovie_bool[2] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].proprc;
				uslovie_text[2] = string.Format(GlobalScript.inst.other_text[493]);
			}
			break;
		case 4:
			number_uslovie = 4;
			if (GlobalScript.inst.gameState.allcountries[(int)selected_country].proprc)
			{
				this_opis = "Финансировать режим";
				uslovie_bool[2] = GlobalScript.inst.gameState.allcountries[(int)selected_country].stab < 1200;
				uslovie_text[2] = "Стабильность менее 100";
				this_opis = this_opis + "|Стабильность: " + GlobalScript.inst.gameState.allcountries[(int)selected_country].stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[(int)selected_country].stab % 10);
				uslovie_bool[0] = GlobalScript.inst.gameState.data[9] >= 100;
				uslovie_text[0] = "10 агентурных сетей";
				uslovie_bool[1] = GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40;
				uslovie_text[1] = "4 миллиона в бюджете";
				uslovie_bool[3] = GlobalScript.inst.gameState.data[22] >= 80;
				uslovie_text[3] = "8 военных группы";
			}
			else
			{
				this_opis = "Поддержать просоветские силы";
				uslovie_bool[2] = GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower < 1200;
				uslovie_text[2] = "Просоветские силы менее 100";
				this_opis = this_opis + "|сила просоветских: " + GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower % 10);
				uslovie_bool[0] = GlobalScript.inst.gameState.data[9] >= 80;
				uslovie_text[0] = "8 агентурных сетей";
				uslovie_bool[1] = GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40;
				uslovie_text[1] = "4 миллиона в бюджете";
				uslovie_bool[3] = GlobalScript.inst.gameState.data[22] >= 100;
				uslovie_text[3] = "10 военных групп";
			}
			break;
		case 5:
			this_opis = "Организовать союз с просоветскими силами";
			this_opis = this_opis + "|сила просоветских: " + GlobalScript.inst.gameState.allcountries[(int)selected_country].sovpower / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[(int)selected_country].sovpower % 10);
			number_uslovie = 4;
			uslovie_bool[0] = GlobalScript.inst.gameState.data[9] >= 20;
			uslovie_text[0] = "2 агентурные сети";
			uslovie_bool[1] = GlobalScript.inst.gameState.data[6] > 690;
			uslovie_text[1] = "Дипрепутация больше 69";
			uslovie_bool[2] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance && !GlobalScript.inst.gameState.allcountries[(int)selected_country].sovalliance;
			uslovie_text[2] = "Нет союза";
			uslovie_bool[3] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].prosov && !GlobalScript.inst.gameState.allcountries[(int)selected_country].proprc;
			uslovie_text[3] = "Страна не просоветская и не прокитайская";
			break;
		case 6:
			this_opis = "Организовать союз с проамериканскими силами";
			this_opis = this_opis + "|сила американских: " + GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower % 10);
			number_uslovie = 4;
			uslovie_bool[0] = GlobalScript.inst.gameState.data[9] >= 20;
			uslovie_text[0] = "2 агентурные сети";
			uslovie_bool[1] = GlobalScript.inst.gameState.data[6] < 500;
			uslovie_text[1] = "Дипрепутация меньше 50";
			uslovie_bool[2] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance && !GlobalScript.inst.gameState.allcountries[(int)selected_country].sovalliance;
			uslovie_text[2] = "Нет союза";
			uslovie_bool[3] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].Vyshi && !GlobalScript.inst.gameState.allcountries[(int)selected_country].proprc;
			uslovie_text[3] = "Страна не проамериканская и не прокитайская";
			break;
		case 7:
			this_opis = "Разжечь волнения, дабы свергнуть правительство";
			this_opis = this_opis + "|Стабильность: " + GlobalScript.inst.gameState.allcountries[(int)selected_country].stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[(int)selected_country].stab % 10);
			number_uslovie = 2;
			uslovie_bool[0] = GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower > 300;
			uslovie_text[0] = "Просоветские силы больше 30";
			uslovie_bool[1] = !GlobalScript.inst.gameState.allcountries[(int)selected_country].prosov;
			uslovie_text[1] = "Страна не просоветская";
			break;
		case 8:
			if (!GlobalScript.inst.gameState.allcountries[(int)selected_country].Torg)
			{
				this_opis = "Начать добычу ресурсов с эксклюзивными правами";
			}
			else
			{
				this_opis = "Прекратить добычу ресурсов с эксклюзивными правами";
			}
			this_opis = this_opis + "|Стабильность: " + GlobalScript.inst.gameState.allcountries[(int)selected_country].stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[(int)selected_country].stab % 10);
			number_uslovie = 1;
			uslovie_bool[0] = GlobalScript.inst.gameState.allcountries[(int)selected_country].prosov;
			uslovie_text[0] = "Страна просоветская";
			break;
		}
	}

	public static void ButtonsResult(int this_type, MinorCountries selected_country)
	{
		if (this_type == 0)
		{
			GlobalScript.inst.gameState.allcountries[(int)selected_country].Torg = true;
		}
		if (this_type == 1)
		{
			GlobalScript.inst.gameState.allcountries[(int)selected_country].isSEV = true;
		}
		if (this_type == 2)
		{
			GlobalScript.inst.gameState.allcountries[(int)selected_country].isOVD = true;
		}
		if (this_type == 3)
		{
			GlobalScript.inst.gameState.allcountries[(int)selected_country].isSEV = true;
		}
		if (this_type == 4)
		{
			if (GlobalScript.inst.gameState.allcountries[(int)selected_country].prosov)
			{
				GlobalScript.inst.gameState.data[9] -= 100;
				GlobalScript.inst.gameState.data[8] -= 40;
				GlobalScript.inst.gameState.data[22] -= 80;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].stab += 200;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].dev += 80;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower -= 200;
				if (GlobalScript.inst.gameState.allcountries[(int)selected_country].stab > 1000)
				{
					GlobalScript.inst.gameState.allcountries[(int)selected_country].stab = 1000;
				}
				if (GlobalScript.inst.gameState.allcountries[(int)selected_country].dev > 1000)
				{
					GlobalScript.inst.gameState.allcountries[(int)selected_country].dev = 1000;
				}
				if (GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower < 0)
				{
					GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower = 0;
				}
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower += 200;
				if (GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower > 1000)
				{
					GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower = 1000;
				}
				GlobalScript.inst.gameState.data[9] -= 80;
				GlobalScript.inst.gameState.data[8] -= 40;
				GlobalScript.inst.gameState.data[22] -= 100;
			}
		}
		GlobalScript.inst.gameState.allcountries[(int)selected_country].sovalliance = true;
		GlobalScript.inst.gameState.data[9] -= 20;
		switch (this_type)
		{
		case 6:
			GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance = true;
			GlobalScript.inst.gameState.data[9] -= 20;
			break;
		case 7:
			if (GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance)
			{
				GlobalScript.inst.gameState.allcountries[(int)selected_country].stab -= GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower + GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower + 100;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[(int)selected_country].stab -= GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower + 100;
			}
			if (GlobalScript.inst.gameState.allcountries[(int)selected_country].stab < -200)
			{
				if (GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance && GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower > GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower)
				{
					GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].SubGosstroy = GlobalScript.inst.gameState.AfricanSubGosstroy(GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy);
					GlobalScript.inst.gameState.allcountries[(int)selected_country].Vyshi = true;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].prosov = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].stab = 100;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].dev -= 200;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].sovpower = (GlobalScript.inst.gameState.allcountries[(int)selected_country].sovpower + 1) / 2;
					GlobalScript.inst.gameState.empires[0].power += 10;
				}
				else if (GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance)
				{
					GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].prosov = true;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].SubGosstroy = GlobalScript.inst.gameState.AfricanSubGosstroy(GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy);
					GlobalScript.inst.gameState.allcountries[(int)selected_country].proprc = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].stab = 100;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].dev -= 200;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower = (GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower + 1) / 2;
					GlobalScript.inst.gameState.empires[0].power += 5;
					GlobalScript.inst.gameState.influencePRC += 5;
				}
				else
				{
					GlobalScript.inst.gameState.allcountries[(int)selected_country].Gosstroy = GlobalScript.inst.gameState.allcountries[1].Gosstroy;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].prosov = true;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].SubGosstroy = GlobalScript.inst.gameState.ChineseSubGosstroy();
					GlobalScript.inst.gameState.allcountries[(int)selected_country].proprc = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].Vyshi = false;
					GlobalScript.inst.gameState.influencePRC += 5;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].stab = 100;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].dev -= 200;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].sovalliance = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].usalliance = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower = (GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower + 1) / 2;
				}
			}
			else if (GlobalScript.inst.gameState.allcountries[(int)selected_country].stab >= -200 && GlobalScript.inst.gameState.allcountries[(int)selected_country].stab <= 100)
			{
				GlobalScript.inst.gameState.allcountries[(int)selected_country].stab = 0;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].dev -= 400;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower = 100;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].usapower = 100;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].sovpower = 100;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[(int)selected_country].stab -= 200;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].dev -= 100;
				GlobalScript.inst.gameState.allcountries[(int)selected_country].prcpower = 0;
			}
			break;
		case 8:
			if (!GlobalScript.inst.gameState.allcountries[(int)selected_country].Torg)
			{
				GlobalScript.inst.gameState.allcountries[(int)selected_country].Torg = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[(int)selected_country].Torg = false;
			}
			break;
		}
	}
}
