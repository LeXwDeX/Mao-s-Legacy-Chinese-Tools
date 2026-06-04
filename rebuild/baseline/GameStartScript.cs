using System;
using System.Collections.Generic;
using Focuses;
using LFKG;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour
{
	public string new_scene;

	public string this_scene;

	private GlobalScript global1;

	private void OnMouseDown()
	{
		if (global1.gameState.PlayerCountry <= 0)
		{
			return;
		}
		int num = PlayerPrefs.GetInt("language");
		for (int i = 0; i < GlobalScript.inst.gameState.science.Length; i++)
		{
			GlobalScript.inst.gameState.science[i] = false;
			GlobalScript.inst.gameState.science_in_progress[i] = false;
			GlobalScript.inst.gameState.science_need_time[i] = 0;
			GlobalScript.inst.gameState.science_time[i] = 0;
		}
		for (int j = 0; j < GlobalScript.inst.gameState.war_active.Length; j++)
		{
			GlobalScript.inst.gameState.war_active[j] = true;
		}
		for (int k = 0; k < GlobalScript.inst.gameState.modifies.Length; k++)
		{
			GlobalScript.inst.gameState.modifies[k].active = false;
		}
		for (int l = 0; l < GlobalScript.inst.gameState.allcountries.Length; l++)
		{
			GlobalScript.inst.gameState.allcountries[l].dev = 0;
			GlobalScript.inst.gameState.allcountries[l].based = false;
			GlobalScript.inst.gameState.allcountries[l].cw = false;
		}
		for (int m = 0; m < GlobalScript.inst.gameState.checking.Length; m++)
		{
			GlobalScript.inst.gameState.checking[m] = false;
		}
		for (int n = 0; n < GlobalScript.inst.gameState.desnull.Length; n++)
		{
			GlobalScript.inst.gameState.desnull[n] = 0;
		}
		for (int num2 = 0; num2 < GlobalScript.inst.gameState.event_done.Length; num2++)
		{
			GlobalScript.inst.gameState.event_done[num2] = false;
		}
		for (int num3 = 0; num3 < GlobalScript.inst.gameState.Events_active.Length; num3++)
		{
			GlobalScript.inst.gameState.Events_active[num3] = false;
		}
		global1.speed = 0;
		for (int num4 = 0; num4 < GlobalScript.inst.gameState.data_old.Length; num4++)
		{
			GlobalScript.inst.gameState.data_old[num4] = 0;
		}
		for (int num5 = 0; num5 < GlobalScript.inst.gameState.ingamewars.Length; num5++)
		{
			GlobalScript.inst.gameState.ingamewars[num5] = new warinwars
			{
				is_going = false
			};
		}
		for (int num6 = 0; num6 < GlobalScript.inst.gameState.science_time.Length; num6++)
		{
			GlobalScript.inst.gameState.science_time[num6] = 0;
		}
		if (global1.gameState.PlayerCountry == 1)
		{
			if (GlobalScript.inst.dlc[3])
			{
				GlobalScript.inst.gameState.modifies[42].active = true;
				GlobalScript.inst.gameState.modifies[50].active = true;
				GlobalScript.inst.gameState.modifies[56].active = true;
				GlobalScript.inst.gameState.OilProd = 850f;
				GlobalScript.inst.gameState.modifies[51].active = true;
			}
			if (GlobalScript.inst.dlc[2])
			{
				GlobalScript.inst.gameState.modifies[63].active = true;
			}
		}
		GlobalScript.inst.gameState.is_elect = true;
		GlobalScript.inst.gameState.is_speech = true;
		GlobalScript.inst.gameState.is_konst_max = true;
		GlobalScript.inst.gameState.is_gkchp = false;
		GlobalScript.inst.gameState.turn_on = false;
		GlobalScript.inst.gameState.relres = false;
		GlobalScript.inst.gameState.BritLost = false;
		GlobalScript.inst.gameState.vietnampeace = false;
		GlobalScript.inst.gameState.war = 0;
		GlobalScript.inst.gameState.iranrev = false;
		GlobalScript.inst.gameState.guns = false;
		GlobalScript.inst.gameState.DRAagree = false;
		GlobalScript.inst.gameState.CBIndia = false;
		GlobalScript.inst.gameState.OAR = false;
		GlobalScript.inst.gameState.Israellost = false;
		GlobalScript.inst.gameState.YugAgree = false;
		GlobalScript.inst.gameState.sanct = false;
		GlobalScript.inst.gameState.donat = false;
		GlobalScript.inst.gameState.ICP = false;
		GlobalScript.inst.gameState.IndOpp = false;
		GlobalScript.inst.gameState.HelpGandi = false;
		GlobalScript.inst.gameState.SovAlb = false;
		GlobalScript.inst.gameState.SEZ = false;
		GlobalScript.inst.gameState.TaiCoup = false;
		GlobalScript.inst.gameState.SKRebel = false;
		GlobalScript.inst.gameState.bad_done = false;
		GlobalScript.inst.gameState.bad_debuff = false;
		GlobalScript.inst.gameState.iron_and_blood = GlobalScript.inst.gameState.diff >= 2;
		GlobalScript.inst.gameState.runHash = (GlobalScript.inst.gameState.iron_and_blood ? SaveStorage.CreateRunHash() : string.Empty);
		GlobalScript.inst.gameState.is_save_bylo = false;
		string text = "";
		TextAsset textAsset = ((num != 0) ? (Resources.Load($"Part{GlobalScript.inst.gameState.PlayerCountry}_ru") as TextAsset) : (Resources.Load($"Part{GlobalScript.inst.gameState.PlayerCountry}_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		string[] array = text.Split(':');
		text = null;
		for (int num7 = 0; num7 < array.Length; num7++)
		{
			string[] array2 = array[num7].Split(';');
			if (array2[0] == global1.gameState.PlayerCountry.ToString())
			{
				for (int num8 = 0; num8 < GlobalScript.inst.gameState.party_name.Length; num8++)
				{
					GlobalScript.inst.gameState.party_name[num8] = array2[num8 + 1];
				}
				break;
			}
		}
		textAsset = ((num != 0) ? (Resources.Load("Doctr_ru") as TextAsset) : (Resources.Load("Doctr_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split(';');
		text = null;
		for (int num9 = 0; num9 < array.Length; num9++)
		{
			GlobalScript.inst.gameState.doctr[num9] = array[num9];
		}
		textAsset = Resources.Load("StartModiefs" + global1.gameState.PlayerCountry) as TextAsset;
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split(',');
		text = null;
		for (int num10 = 0; num10 < array.Length; num10++)
		{
			global1.gameState.modifies[int.Parse(array[num10])].active = true;
		}
		textAsset = Resources.Load("Country_data_" + global1.gameState.PlayerCountry) as TextAsset;
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		text = text.Replace("\n", null);
		array = text.Split(':');
		text = null;
		for (int num11 = 0; num11 < array.Length; num11++)
		{
			string[] array3 = array[num11].Split(';');
			int num12 = int.Parse(array3[0]);
			GlobalScript.inst.gameState.allcountries[num12] = new Country
			{
				isSEV = (array3[1] == "1"),
				isOVD = (array3[2] == "1"),
				Vyshi = (array3[3] == "1"),
				proprc = (array3[4] == "1"),
				prosov = (array3[5] == "1"),
				okb = (array3[6] == "1"),
				econ = (array3[7] == "1"),
				Torg = (array3[8] == "1"),
				usalliance = (array3[9] == "1"),
				sovalliance = (array3[10] == "1"),
				cw = false,
				stab = int.Parse(array3[12]),
				dev = int.Parse(array3[13]),
				sovpower = int.Parse(array3[14]),
				usapower = int.Parse(array3[15]),
				prcpower = int.Parse(array3[16]),
				Gosstroy = int.Parse(array3[17]),
				SubGosstroy = int.Parse(array3[18])
			};
		}
		GlobalScript.inst.gameState.allcountries[49].Vyshi = false;
		DLC00(num);
		textAsset = ((num != 0) ? (Resources.Load($"polit_names{GlobalScript.inst.gameState.PlayerCountry}_ru") as TextAsset) : (Resources.Load(string.Format($"polit_names{GlobalScript.inst.gameState.PlayerCountry}_en")) as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split('\n');
		text = null;
		GlobalScript.inst.gameState.names1 = new string[array.Length];
		for (int num13 = 0; num13 < array.Length; num13++)
		{
			GlobalScript.inst.gameState.names1[num13] = array[num13];
		}
		textAsset = ((num != 0) ? (Resources.Load($"polit_surnames{GlobalScript.inst.gameState.PlayerCountry}_ru") as TextAsset) : (Resources.Load($"polit_surnames{GlobalScript.inst.gameState.PlayerCountry}_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split('\n');
		text = null;
		GlobalScript.inst.gameState.names2 = new string[array.Length];
		for (int num14 = 0; num14 < array.Length; num14++)
		{
			GlobalScript.inst.gameState.names2[num14] = array[num14];
		}
		textAsset = ((num != 0) ? (Resources.Load($"Traits{GlobalScript.inst.gameState.PlayerCountry}_ru") as TextAsset) : (Resources.Load($"Traits{GlobalScript.inst.gameState.PlayerCountry}_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split('\n');
		text = null;
		GlobalScript.inst.gameState.traitsName = new string[array.Length];
		for (int num15 = 0; num15 < array.Length; num15++)
		{
			GlobalScript.inst.gameState.traitsName[num15] = array[num15];
		}
		textAsset = ((num != 0) ? (Resources.Load("Country_ru") as TextAsset) : (Resources.Load("Country_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split('\n');
		text = null;
		GlobalScript.inst.country_texts = new string[array.Length];
		for (int num16 = 0; num16 < array.Length; num16++)
		{
			GlobalScript.inst.gameState.allcountries[num16].name = array[num16];
			GlobalScript.inst.country_texts[num16] = array[num16];
		}
		textAsset = Resources.Load("Data" + global1.gameState.PlayerCountry) as TextAsset;
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		text = text.Replace("\n", null);
		array = text.Split(';');
		text = null;
		for (int num17 = 1; num17 < array.Length; num17++)
		{
			GlobalScript.inst.gameState.data[num17] = int.Parse(array[num17]);
		}
		GlobalScript.inst.gameState.influencePRC = GlobalScript.inst.gameState.data[7];
		textAsset = Resources.Load("Party_data_" + global1.gameState.PlayerCountry) as TextAsset;
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		text = text.Replace("\n", null);
		array = text.Split(':');
		text = null;
		for (int num18 = 0; num18 < array.Length; num18++)
		{
			string[] array4 = array[num18].Split(';');
			GlobalScript.inst.gameState.is_party_enabled[num18] = array4[0] == "1";
			GlobalScript.inst.gameState.is_party_ally[num18] = array4[1] == "1";
			GlobalScript.inst.gameState.party_ideology[num18] = int.Parse(array4[2]);
			GlobalScript.inst.gameState.party_number[num18] = int.Parse(array4[3]);
		}
		textAsset = Resources.Load($"Politics_inf{GlobalScript.inst.gameState.PlayerCountry}") as TextAsset;
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		text = text.Replace("\n", null);
		array = text.Split(';');
		text = null;
		for (int num19 = 0; num19 < array.Length; num19++)
		{
			string[] array5 = array[num19].Split(':');
			GlobalScript.inst.gameState.politics[num19].name_1 = (byte)int.Parse(array5[0]);
			GlobalScript.inst.gameState.politics[num19].name_2 = (byte)int.Parse(array5[1]);
			GlobalScript.inst.gameState.politics[num19].traits[0] = (byte)int.Parse(array5[2]);
			GlobalScript.inst.gameState.politics[num19].traits[1] = (byte)int.Parse(array5[3]);
			GlobalScript.inst.gameState.politics[num19].traits[2] = (byte)int.Parse(array5[4]);
			GlobalScript.inst.gameState.politics[num19].age = (byte)int.Parse(array5[5]);
			GlobalScript.inst.gameState.politics[num19].power = (byte)int.Parse(array5[6]) * 10;
			if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
			{
				GlobalScript.inst.gameState.politics[num19].face_type = 0;
				GlobalScript.inst.gameState.politics[num19].face_parts[0] = (byte)UnityEngine.Random.Range(0, 3);
				GlobalScript.inst.gameState.politics[num19].face_parts[1] = (byte)UnityEngine.Random.Range(0, 6);
				GlobalScript.inst.gameState.politics[num19].face_parts[2] = (byte)UnityEngine.Random.Range(0, 6);
				GlobalScript.inst.gameState.politics[num19].face_parts[3] = 0;
				GlobalScript.inst.gameState.politics[num19].face_parts[4] = (byte)UnityEngine.Random.Range(0, 6);
				GlobalScript.inst.gameState.politics[num19].face_parts[5] = (byte)UnityEngine.Random.Range(0, 3);
				GlobalScript.inst.gameState.politics[num19].face_parts[6] = (byte)UnityEngine.Random.Range(0, 6);
				GlobalScript.inst.gameState.politics[num19].face_parts[7] = 0;
			}
			else
			{
				GlobalScript.inst.gameState.politics[num19].face_type = 1;
				GlobalScript.inst.gameState.politics[num19].face_parts[0] = (byte)UnityEngine.Random.Range(0, 4);
				GlobalScript.inst.gameState.politics[num19].face_parts[1] = (byte)UnityEngine.Random.Range(0, 6);
				GlobalScript.inst.gameState.politics[num19].face_parts[2] = (byte)UnityEngine.Random.Range(0, 6);
				GlobalScript.inst.gameState.politics[num19].face_parts[3] = 0;
				GlobalScript.inst.gameState.politics[num19].face_parts[4] = (byte)UnityEngine.Random.Range(0, 4);
				GlobalScript.inst.gameState.politics[num19].face_parts[5] = (byte)UnityEngine.Random.Range(0, 4);
				GlobalScript.inst.gameState.politics[num19].face_parts[6] = (byte)UnityEngine.Random.Range(0, 5);
				GlobalScript.inst.gameState.politics[num19].face_parts[7] = 0;
			}
			GlobalScript.inst.gameState.politics[num19].is_sledstvie = false;
			GlobalScript.inst.gameState.politics[num19].is_sleshka = false;
			GlobalScript.inst.gameState.politics[num19].sled_slej = 0;
			GlobalScript.inst.gameState.politics[num19].days_sleshka = 0;
		}
		textAsset = Resources.Load($"Politics_leader{GlobalScript.inst.gameState.PlayerCountry}") as TextAsset;
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split(';');
		text = null;
		GlobalScript.inst.gameState.leader.name_1 = (byte)int.Parse(array[0]);
		GlobalScript.inst.gameState.leader.name_2 = (byte)int.Parse(array[1]);
		GlobalScript.inst.gameState.leader.traits[0] = (byte)int.Parse(array[2]);
		GlobalScript.inst.gameState.leader.traits[1] = (byte)int.Parse(array[3]);
		GlobalScript.inst.gameState.leader.traits[2] = (byte)int.Parse(array[4]);
		GlobalScript.inst.gameState.leader.age = (byte)int.Parse(array[5]);
		GlobalScript.inst.gameState.leader.face_type = 1;
		GlobalScript.inst.gameState.leader.face_parts[0] = 0;
		GlobalScript.inst.gameState.leader.face_parts[1] = 1;
		GlobalScript.inst.gameState.leader.face_parts[2] = 5;
		GlobalScript.inst.gameState.leader.face_parts[3] = 0;
		GlobalScript.inst.gameState.leader.face_parts[4] = 3;
		GlobalScript.inst.gameState.leader.face_parts[5] = 1;
		GlobalScript.inst.gameState.leader.face_parts[6] = 4;
		GlobalScript.inst.gameState.leader.face_parts[7] = 0;
		GlobalScript.inst.gameState.leader.jacket = 2;
		GlobalScript.inst.gameState.politics[1].face_type = 1;
		GlobalScript.inst.gameState.politics[1].face_parts[0] = 3;
		GlobalScript.inst.gameState.politics[1].face_parts[1] = 2;
		GlobalScript.inst.gameState.politics[1].face_parts[2] = 3;
		GlobalScript.inst.gameState.politics[1].face_parts[3] = 0;
		GlobalScript.inst.gameState.politics[1].face_parts[4] = 1;
		GlobalScript.inst.gameState.politics[1].face_parts[5] = 3;
		GlobalScript.inst.gameState.politics[1].face_parts[6] = 1;
		GlobalScript.inst.gameState.politics[1].face_parts[7] = 0;
		GlobalScript.inst.gameState.politics[1].jacket = 0;
		GlobalScript.inst.gameState.politics[0].face_type = 1;
		GlobalScript.inst.gameState.politics[0].face_parts[0] = 1;
		GlobalScript.inst.gameState.politics[0].face_parts[1] = 3;
		GlobalScript.inst.gameState.politics[0].face_parts[2] = 3;
		GlobalScript.inst.gameState.politics[0].face_parts[3] = 0;
		GlobalScript.inst.gameState.politics[0].face_parts[4] = 0;
		GlobalScript.inst.gameState.politics[0].face_parts[5] = 0;
		GlobalScript.inst.gameState.politics[0].face_parts[6] = 3;
		GlobalScript.inst.gameState.politics[0].face_parts[7] = 0;
		GlobalScript.inst.gameState.politics[0].power = 99999;
		GlobalScript.inst.gameState.politics[0].jacket = 4;
		GlobalScript.inst.gameState.politics[2].jacket = 4;
		GlobalScript.inst.gameState.politics[3].jacket = 4;
		GlobalScript.inst.gameState.politics[4].jacket = 0;
		GlobalScript.inst.gameState.politics[5].jacket = 0;
		GlobalScript.inst.gameState.politics[6].jacket = 4;
		GlobalScript.inst.gameState.politics[7].jacket = 1;
		GlobalScript.inst.gameState.politics[8].jacket = 4;
		GlobalScript.inst.gameState.politics[9].jacket = 4;
		GlobalScript.inst.gameState.politics[10].jacket = 0;
		GlobalScript.inst.gameState.politics[11].traits[1] = 5;
		GlobalScript.inst.gameState.politics[11].traits[2] = 14;
		GlobalScript.inst.gameState.politics[11].jacket = 3;
		GlobalScript.inst.gameState.politics[12].face_type = 0;
		GlobalScript.inst.gameState.politics[12].face_parts[0] = 1;
		GlobalScript.inst.gameState.politics[12].face_parts[1] = 2;
		GlobalScript.inst.gameState.politics[12].face_parts[2] = 1;
		GlobalScript.inst.gameState.politics[12].face_parts[3] = 0;
		GlobalScript.inst.gameState.politics[12].face_parts[4] = 5;
		GlobalScript.inst.gameState.politics[12].face_parts[5] = 1;
		GlobalScript.inst.gameState.politics[12].face_parts[6] = 2;
		GlobalScript.inst.gameState.politics[12].face_parts[7] = 0;
		GlobalScript.inst.gameState.politics[12].jacket = 4;
		GlobalScript.inst.gameState.politics[13].face_type = 0;
		GlobalScript.inst.gameState.politics[13].face_parts[0] = 1;
		GlobalScript.inst.gameState.politics[13].face_parts[1] = 5;
		GlobalScript.inst.gameState.politics[13].face_parts[2] = 4;
		GlobalScript.inst.gameState.politics[13].face_parts[3] = 0;
		GlobalScript.inst.gameState.politics[13].face_parts[4] = 4;
		GlobalScript.inst.gameState.politics[13].face_parts[5] = 1;
		GlobalScript.inst.gameState.politics[13].face_parts[6] = 5;
		GlobalScript.inst.gameState.politics[13].face_parts[7] = 0;
		GlobalScript.inst.gameState.politics[13].jacket = 3;
		GlobalScript.inst.gameState.politics[14].jacket = 1;
		GlobalScript.inst.gameState.politics[15].jacket = 4;
		GlobalScript.inst.gameState.politics[16].jacket = 4;
		GlobalScript.inst.gameState.politics[17].traits[0] = 1;
		GlobalScript.inst.gameState.politics[17].traits[1] = 4;
		GlobalScript.inst.gameState.politics[17].traits[2] = 15;
		GlobalScript.inst.gameState.politics[17].jacket = 2;
		for (int num20 = 0; num20 < 3; num20++)
		{
			GlobalScript.inst.gameState.p_first[num20] = (byte)num20;
		}
		for (int num21 = 0; num21 < 4; num21++)
		{
			GlobalScript.inst.gameState.p_second[num21] = (byte)(num21 + 3);
		}
		for (int num22 = 0; num22 < 5; num22++)
		{
			GlobalScript.inst.gameState.p_third[num22] = (byte)(num22 + 7);
		}
		for (int num23 = 0; num23 < 6; num23++)
		{
			GlobalScript.inst.gameState.p_forth[num23] = (byte)(num23 + 12);
		}
		for (int num24 = 0; num24 < GlobalScript.inst.gameState.politics.Length; num24++)
		{
			GlobalScript.inst.gameState.CalcRel(num24);
			GlobalScript.inst.gameState.CalcRelLeader(num24);
		}
		GlobalScript.inst.gameState.politics[1].loyality_to_other[0] = 10000;
		GlobalScript.inst.gameState.politics[2].loyality_to_other[0] = 10000;
		GlobalScript.inst.gameState.politics[3].loyality_to_other[0] = 10000;
		GlobalScript.inst.gameState.politics[4].loyality_to_other[0] = 10000;
		GlobalScript.inst.gameState.politics[1].loyality_to_other[2] = 10000;
		GlobalScript.inst.gameState.politics[1].loyality_to_other[3] = 10000;
		GlobalScript.inst.gameState.politics[1].loyality_to_other[4] = 10000;
		GlobalScript.inst.gameState.politics[2].loyality_to_other[1] = 10000;
		GlobalScript.inst.gameState.politics[2].loyality_to_other[3] = 10000;
		GlobalScript.inst.gameState.politics[2].loyality_to_other[4] = 10000;
		GlobalScript.inst.gameState.politics[3].loyality_to_other[2] = 10000;
		GlobalScript.inst.gameState.politics[3].loyality_to_other[1] = 10000;
		GlobalScript.inst.gameState.politics[3].loyality_to_other[4] = 10000;
		GlobalScript.inst.gameState.politics[4].loyality_to_other[2] = 10000;
		GlobalScript.inst.gameState.politics[4].loyality_to_other[3] = 10000;
		GlobalScript.inst.gameState.politics[4].loyality_to_other[1] = 10000;
		GlobalScript.inst.gameState.politics[1].loyality_to_other[12] -= 1000;
		GlobalScript.inst.gameState.politics[0].loyality_to_other[12] += 500;
		GlobalScript.inst.gameState.politics[0].loyality += 500;
		GlobalScript.inst.gameState.politics[5].loyality += 400;
		GlobalScript.inst.gameState.politics[8].loyality += 600;
		GlobalScript.inst.gameState.politics[9].loyality += 800;
		GlobalScript.inst.gameState.politics[10].loyality += 100;
		GlobalScript.inst.gameState.politics[15].traits[0] = 1;
		GlobalScript.inst.gameState.politics_dolshnost[0] = 150;
		GlobalScript.inst.gameState.politics_dolshnost[1] = 0;
		GlobalScript.inst.gameState.politics_dolshnost[2] = 17;
		GlobalScript.inst.gameState.politics_dolshnost[3] = 10;
		GlobalScript.inst.gameState.politics_dolshnost[4] = 9;
		GlobalScript.inst.gameState.politics_dolshnost[5] = 15;
		GlobalScript.inst.gameState.politics_dolshnost[6] = 13;
		GlobalScript.inst.gameState.politics_dolshnost[7] = 3;
		GlobalScript.inst.gameState.politics[0].wantedDolzh = 1;
		GlobalScript.inst.gameState.politics[1].wantedDolzh = 0;
		GlobalScript.inst.gameState.politics[2].wantedDolzh = 0;
		GlobalScript.inst.gameState.politics[3].wantedDolzh = 3;
		GlobalScript.inst.gameState.politics[4].wantedDolzh = 3;
		GlobalScript.inst.gameState.politics[5].wantedDolzh = 1;
		GlobalScript.inst.gameState.politics[6].wantedDolzh = 0;
		GlobalScript.inst.gameState.politics[7].wantedDolzh = 1;
		GlobalScript.inst.gameState.politics[8].wantedDolzh = 0;
		GlobalScript.inst.gameState.politics[9].wantedDolzh = 1;
		GlobalScript.inst.gameState.politics[10].wantedDolzh = 3;
		GlobalScript.inst.gameState.politics[11].wantedDolzh = 2;
		GlobalScript.inst.gameState.politics[12].wantedDolzh = 0;
		GlobalScript.inst.gameState.politics[13].wantedDolzh = 0;
		GlobalScript.inst.gameState.politics[14].wantedDolzh = 0;
		GlobalScript.inst.gameState.politics[15].wantedDolzh = 0;
		GlobalScript.inst.gameState.politics[16].wantedDolzh = 1;
		GlobalScript.inst.gameState.politics[17].wantedDolzh = 2;
		GlobalScript.inst.gameState.faction_leader[0] = 1;
		GlobalScript.inst.gameState.faction_leader[1] = 10;
		GlobalScript.inst.gameState.faction_leader[2] = 15;
		GlobalScript.inst.gameState.faction_leader[3] = 12;
		GlobalScript.inst.gameState.faction_leader[4] = 13;
		GlobalScript.inst.gameState.data[49] = UnityEngine.Random.Range(1, 5);
		GlobalScript.inst.gameState.data[48] = UnityEngine.Random.Range(1, 5);
		GlobalScript.inst.gameState.data[47] = UnityEngine.Random.Range(1, 5);
		if (GlobalScript.inst.gameState.diff == 0)
		{
			GlobalScript.inst.gameState.data[1] = 1000;
			GlobalScript.inst.gameState.data[3] = 1000;
			GlobalScript.inst.gameState.data[4] = 0;
			GlobalScript.inst.gameState.data[8] += 500;
			GlobalScript.inst.gameState.data[11] = 700;
		}
		else if (GlobalScript.inst.gameState.diff == 1)
		{
			GlobalScript.inst.gameState.data[8] += 100;
			GlobalScript.inst.gameState.data[11] = 300;
		}
		else if (GlobalScript.inst.gameState.diff == 3)
		{
			GlobalScript.inst.gameState.data[11] = 0;
		}
		else if (GlobalScript.inst.gameState.diff == 4)
		{
			for (int num25 = 0; num25 < GlobalScript.inst.gameState.politics.Length; num25++)
			{
				if (GlobalScript.inst.gameState.politics[num25].traits[0] == 0)
				{
					GlobalScript.inst.gameState.politics[num25].loyality -= 300;
					GlobalScript.inst.gameState.politics[num25].power += 500;
				}
			}
		}
		GlobalScript.inst.gameState.data[27] = 0;
		GlobalScript.inst.gameState.data[0] = 0;
		GlobalScript.inst.gameState.data[85] = 0;
		GlobalScript.inst.gameState.allcountries[15].Torg = false;
		GlobalScript.inst.gameState.allcountries[92].spec = 0;
		GlobalScript.inst.gameState.allcountries[0].isNATO = true;
		GlobalScript.inst.gameState.allcountries[51].isNATO = true;
		GlobalScript.inst.gameState.allcountries[92].isNATO = true;
		GlobalScript.inst.gameState.allcountries[21].isNATO = true;
		GlobalScript.inst.gameState.allcountries[87].isNATO = true;
		GlobalScript.inst.gameState.allcountries[88].isNATO = true;
		GlobalScript.inst.gameState.allcountries[89].isNATO = true;
		GlobalScript.inst.gameState.allcountries[17].isNATO = true;
		GlobalScript.inst.gameState.allcountries[84].isNATO = true;
		GlobalScript.inst.gameState.allcountries[85].isNATO = true;
		GlobalScript.inst.gameState.allcountries[45].isNATO = true;
		GlobalScript.inst.gameState.allcountries[90].isNATO = true;
		GlobalScript.inst.gameState.allcountries[91].isNATO = true;
		GlobalScript.inst.gameState.allcountries[0].isEU = true;
		GlobalScript.inst.gameState.allcountries[92].isEU = true;
		GlobalScript.inst.gameState.allcountries[21].isEU = true;
		GlobalScript.inst.gameState.allcountries[88].isEU = true;
		GlobalScript.inst.gameState.allcountries[89].isEU = true;
		GlobalScript.inst.gameState.allcountries[17].isEU = true;
		GlobalScript.inst.gameState.allcountries[85].isEU = true;
		GlobalScript.inst.gameState.allcountries[90].isEU = true;
		GlobalScript.inst.gameState.allcountries[29].isEU = true;
		GlobalScript.inst.gameState.allcountries[87].spec = 40;
		GlobalScript.inst.gameState.allcountries[87].inflCh = 10;
		GlobalScript.inst.gameState.allcountries[87].inflNATO = 20;
		if (GlobalScript.inst.dlc[3])
		{
			GlobalScript.inst.gameState.allcountries[50].isASEAN = true;
			GlobalScript.inst.gameState.allcountries[49].isASEAN = true;
			GlobalScript.inst.gameState.allcountries[34].isASEAN = true;
			GlobalScript.inst.gameState.allcountries[47].isASEAN = true;
			GlobalScript.inst.gameState.allcountries[31].isSENTO = true;
			GlobalScript.inst.gameState.allcountries[8].isSENTO = true;
			GlobalScript.inst.gameState.OilEat = (float)GlobalScript.inst.gameState.data[12] * 0.4f + ((GlobalScript.inst.gameState.data[12] >= 500) ? ((float)(GlobalScript.inst.gameState.data[12] - 499) * 0.4f) : 0f) + ((GlobalScript.inst.gameState.data[12] >= 750) ? ((float)(GlobalScript.inst.gameState.data[12] - 749) * 0.4f) : 0f);
			GlobalScript.inst.gameState.OilEat += ((GlobalScript.inst.gameState.data[13] >= 250) ? ((float)(GlobalScript.inst.gameState.data[13] - 249) * 0.35f) : 0f) + ((GlobalScript.inst.gameState.data[13] >= 500) ? ((float)(GlobalScript.inst.gameState.data[13] - 499) * 0.35f) : 0f) + ((GlobalScript.inst.gameState.data[13] >= 750) ? ((float)(GlobalScript.inst.gameState.data[13] - 749) * 0.35f) : 0f);
			GlobalScript.inst.gameState.OilEat += ((GlobalScript.inst.gameState.data[68] >= 500) ? ((float)(GlobalScript.inst.gameState.data[68] - 499) * 0.34f) : 0f) + ((GlobalScript.inst.gameState.data[68] >= 750) ? ((float)(GlobalScript.inst.gameState.data[68] - 749) * 0.34f) : 0f);
			GlobalScript.inst.gameState.OilEat += (float)GlobalScript.inst.gameState.data[22] * 0.5f;
			GlobalScript.inst.gameState.OilEat += (float)GlobalScript.inst.gameState.data[5] * 0.05f;
			GlobalScript.inst.gameState.data[143] = 12;
		}
		if (num == 1)
		{
			GlobalScript.inst.gameState.ingamewars[0].name_war = "Вторая Корейская война";
			GlobalScript.inst.gameState.ingamewars[1].name_war = "Кампучийско-вьетнамский конфликт";
			GlobalScript.inst.gameState.ingamewars[2].name_war = "Тайская гражданская война";
			GlobalScript.inst.gameState.ingamewars[3].name_war = "Ирано-иракская война";
			GlobalScript.inst.gameState.ingamewars[4].name_war = "Ливанская война";
			GlobalScript.inst.gameState.ingamewars[5].name_war = "Афганская война";
			GlobalScript.inst.gameState.ingamewars[6].name_war = "Фолклендская война";
			GlobalScript.inst.gameState.ingamewars[7].name_war = "Гражданская война в Индии";
		}
		else
		{
			GlobalScript.inst.gameState.ingamewars[0].name_war = "第三次朝鲜战争";
			GlobalScript.inst.gameState.ingamewars[1].name_war = "柬埔寨—越南冲突";
			GlobalScript.inst.gameState.ingamewars[2].name_war = "泰国内战";
			GlobalScript.inst.gameState.ingamewars[3].name_war = "两伊战争";
			GlobalScript.inst.gameState.ingamewars[4].name_war = "黎巴嫩战争";
			GlobalScript.inst.gameState.ingamewars[5].name_war = "阿富汗战争";
			GlobalScript.inst.gameState.ingamewars[6].name_war = "福克兰群岛战争";
			GlobalScript.inst.gameState.ingamewars[7].name_war = "印度内战";
		}
		GlobalScript.inst.gameState.data[111] = 0;
		GlobalScript.inst.gameState.data[112] = 0;
		GlobalScript.inst.gameState.data[113] = 0;
		GlobalScript.inst.gameState.data[114] = 0;
		GlobalScript.inst.gameState.data[115] = 0;
		GlobalScript.inst.gameState.data[116] = 0;
		GlobalScript.inst.gameState.data[117] = 0;
		GlobalScript.inst.gameState.data[118] = 0;
		GlobalScript.inst.gameState.data[119] = 0;
		GlobalScript.inst.gameState.data[120] = 0;
		GlobalScript.inst.gameState.data[121] = 0;
		GlobalScript.inst.gameState.data[122] = 0;
		GlobalScript.inst.gameState.data[123] = 0;
		GlobalScript.inst.gameState.data[105] = 2;
		GlobalScript.inst.gameState.data[106] = 0;
		GlobalScript.inst.gameState.data[108] = 0;
		GlobalScript.inst.gameState.data[152] = 350;
		GlobalScript.inst.gameState.allcountries[92].inflNATO = 10;
		GlobalScript.inst.gameState.data[125] = 0;
		GlobalScript.inst.gameState.is_elect = false;
		TextAsset textAsset2 = Resources.Load(string.Format("new_texts_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.new_texts = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("new_modify_texts_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.new_modify_texts = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("new_modify_opis_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.new_modify_desc = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("old_modify_text_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.old_modify_texts = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("old_modify_opis_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.old_modify_desc = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("Events_text_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.new_events_text = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("new_focuses_texts_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		FocusReader.CreateDictionary();
		FocusReader.ReadFocuses(textAsset2.text);
		textAsset2 = Resources.Load(string.Format("new_event_text_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.gameState.SOV_PRC_PartiesConnection = GlobalScript.inst.gameState.data[30];
		GlobalScript.inst.gameState.empires = new Empire[2];
		GlobalScript.inst.gameState.empires[0] = new Empire
		{
			leaders = new Leader[4]
			{
				new Leader(GlobalScript.inst.new_texts[0], 5),
				new Leader(GlobalScript.inst.new_texts[1], 4),
				new Leader(GlobalScript.inst.new_texts[2], 3),
				new Leader(GlobalScript.inst.new_texts[3], 2)
			}
		};
		GlobalScript.inst.gameState.empires[0].modifies = new int[2] { 0, 1 };
		GlobalScript.inst.gameState.empires[0].insiders = new Insider[2]
		{
			new Insider(GlobalScript.inst.new_texts[4], 0),
			new Insider(GlobalScript.inst.new_texts[5], 0)
		};
		GlobalScript.inst.gameState.empires[0].power = GlobalScript.inst.gameState.data[10];
		GlobalScript.inst.gameState.empires[0].relations = GlobalScript.inst.gameState.data[28];
		GlobalScript.inst.gameState.data[96] += 4;
		GlobalScript.inst.gameState.data[95]++;
		GlobalScript.inst.gameState.empires[1] = new Empire
		{
			leaders = new Leader[7]
			{
				new Leader(GlobalScript.inst.new_texts[6], 20),
				new Leader(GlobalScript.inst.new_texts[7], GlobalScript.inst.gameState.data[97] + 3),
				new Leader(GlobalScript.inst.new_texts[8], GlobalScript.inst.gameState.data[95] * 3),
				new Leader(GlobalScript.inst.new_texts[9], GlobalScript.inst.gameState.data[96]),
				new Leader(GlobalScript.inst.new_texts[10], GlobalScript.inst.gameState.data[98]),
				new Leader(GlobalScript.inst.new_texts[11], GlobalScript.inst.gameState.data[99] + 1),
				new Leader(GlobalScript.inst.new_texts[12], GlobalScript.inst.gameState.data[100])
			}
		};
		GlobalScript.inst.gameState.empires[1].modifies = new int[2] { 0, 7 };
		GlobalScript.inst.gameState.empires[1].insiders = new Insider[2]
		{
			new Insider(GlobalScript.inst.new_texts[13], 0),
			new Insider(GlobalScript.inst.new_texts[14], 0)
		};
		GlobalScript.inst.gameState.empires[1].power = GlobalScript.inst.gameState.data[2];
		GlobalScript.inst.gameState.empires[1].relations = GlobalScript.inst.gameState.data[29];
		if (global1.dlc[0])
		{
			DLCm0();
		}
		if (global1.dlc[5])
		{
			DLC05(GlobalScript.inst.gameState);
		}
		if (global1.dlc[6])
		{
			DLC6(GlobalScript.inst.gameState);
		}
		if (global1.dlc[8])
		{
			DLC8(GlobalScript.inst.gameState);
		}
		GlobalScript.inst.gameState.startedDirectWarsNum = new Dictionary<int, bool>();
		for (int num26 = 0; num26 < GlobalScript.inst.gameState.completedDecisions.Length; num26++)
		{
			GlobalScript.inst.gameState.completedDecisions[num26] = false;
		}
		GlobalScript.inst.CreateDecisions();
		GlobalScript.inst.gameState.allcountries[84].parts = new bool[5];
		GlobalScript.inst.gameState.allcountries[14].parts = new bool[6];
		GlobalScript.inst.gameState.allcountries[30].parts = new bool[2];
		GlobalScript.inst.gameState.allcountries[1].parts = new bool[12];
		GlobalScript.inst.gameState.allcountries[7].parts = new bool[3];
		GlobalScript.inst.gameState.allcountries[1].parts[10] = true;
		GlobalScript.inst.gameState.allcountries[20].parts = new bool[2];
		GlobalScript.inst.gameState.allcountries[86].parts = new bool[2];
		GlobalScript.inst.gameState.allcountries[44].parts = new bool[1];
		GlobalScript.inst.gameState.allcountries[27].parts = new bool[1];
		if (GlobalScript.inst.dlc[3])
		{
			GlobalScript.inst.gameState.allcountries[57].africaOff = true;
		}
		SceneManager.LoadScene(new_scene);
	}

	public void DLC00(int lng)
	{
		TextAsset textAsset = Resources.Load(string.Format("other_text_{0}", (lng == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.other_text = textAsset.text.Split('\n');
		TextAsset obj = Resources.Load("South_data") as TextAsset;
		string text = obj.text;
		Resources.UnloadAsset(obj);
		text = text.Replace("\n", null);
		string[] array = text.Split(':');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(';');
			int num = int.Parse(array2[0]);
			GlobalScript.inst.gameState.allcountries[num] = new Country
			{
				isSEV = (array2[1] == "1"),
				isOVD = (array2[2] == "1"),
				Vyshi = (array2[3] == "1"),
				proprc = (array2[4] == "1"),
				prosov = (array2[5] == "1"),
				okb = (array2[6] == "1"),
				econ = (array2[7] == "1"),
				Torg = (array2[8] == "1"),
				usalliance = (array2[9] == "1"),
				sovalliance = (array2[10] == "1"),
				cw = false,
				stab = int.Parse(array2[12]),
				dev = int.Parse(array2[13]),
				sovpower = int.Parse(array2[14]),
				usapower = int.Parse(array2[15]),
				prcpower = int.Parse(array2[16]),
				Gosstroy = int.Parse(array2[17]),
				SubGosstroy = int.Parse(array2[18]),
				level_of_dev = int.Parse(array2[19]),
				level_of_unstab = int.Parse(array2[20]),
				next_elections = new DateTime(int.Parse(array2[23]), int.Parse(array2[22]), int.Parse(array2[21]))
			};
		}
	}

	public void DLCm0()
	{
		if (GlobalScript.inst.gameState.gamerules[0] > 0 || GlobalScript.inst.gameState.gamerules[1] > 0 || GlobalScript.inst.gameState.gamerules[2] > 0 || GlobalScript.inst.gameState.gamerules[3] > 0 || GlobalScript.inst.gameState.gamerules[4] > 0 || GlobalScript.inst.gameState.gamerules[5] > 0 || GlobalScript.inst.gameState.gamerules[7] > 0)
		{
			GlobalScript.inst.gameState.iron_and_blood = false;
		}
		if (GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			GlobalScript.inst.gameState.numOfPlayers = GlobalScript.inst.gameState.gamerules[1] + 1;
			GlobalScript.inst.gameState.factionsPlayerMaster = new int[GlobalScript.inst.gameState.party_number.Length];
			if (GlobalScript.inst.gameState.gamerules[1] == 4)
			{
				for (int i = 0; i < GlobalScript.inst.gameState.factionsPlayerMaster.Length; i++)
				{
					GlobalScript.inst.gameState.factionsPlayerMaster[i] = i;
				}
			}
			else
			{
				new_scene = "ChooseFactionCoop";
			}
			GlobalScript.inst.gameState.is_party_enabled[4] = true;
			GlobalScript.inst.gameState.party_number[4] = GlobalScript.inst.gameState.party_ideology[4];
		}
		if (GlobalScript.inst.gameState.gamerules[7] == 3)
		{
			for (int j = 0; j < GlobalScript.inst.gameState.party_number.Length; j++)
			{
				GlobalScript.inst.gameState.is_party_enabled[j] = true;
				GlobalScript.inst.gameState.party_number[j] = 600;
				GlobalScript.inst.gameState.party_ideology[j] = 600;
			}
		}
		GlobalScript.inst.gameState.factionsPlayerFor = new bool[GlobalScript.inst.gameState.party_number.Length];
		GlobalScript.inst.gameState.playerFor = new bool[GlobalScript.inst.gameState.party_number.Length];
		GlobalScript.inst.gameState.eventVariantsPlayerFor = new int[GlobalScript.inst.gameState.party_number.Length];
		GlobalScript.inst.gameState.factionsPoints = new int[GlobalScript.inst.gameState.party_number.Length];
		GlobalScript.inst.gameState.coopAttacked = false;
		GlobalScript.inst.gameState.congressShutdownYears = 0;
		GlobalScript.inst.gameState.peopleCoalitionYears = 0;
		GlobalScript.inst.gameState.data[159] = 1;
	}

	public void DLC01()
	{
		if (GlobalScript.inst.gameState.gamerules[0] == 1)
		{
			GlobalScript.inst.gameState.empires[1].MakeHistorical();
		}
		else if (GlobalScript.inst.gameState.gamerules[1] > 1)
		{
			if (GlobalScript.inst.gameState.gamerules[0] == 3)
			{
				GlobalScript.inst.gameState.empires[1].MakeAgressive();
			}
			else if (GlobalScript.inst.gameState.gamerules[0] == 4)
			{
				GlobalScript.inst.gameState.empires[1].MakePeaceful();
			}
			else if (GlobalScript.inst.gameState.gamerules[0] == 2)
			{
				GlobalScript.inst.gameState.gamerules[0] = Utils.RandomRangeFromTwoGroups(new int[4] { 1, 2, 3, 5 });
				if (GlobalScript.inst.gameState.gamerules[0] == 1)
				{
					GlobalScript.inst.gameState.empires[1].MakeHistorical();
				}
				else if (GlobalScript.inst.gameState.gamerules[0] == 3)
				{
					GlobalScript.inst.gameState.empires[1].MakeAgressive();
				}
				else
				{
					GlobalScript.inst.gameState.empires[1].MakePeaceful();
				}
			}
		}
		if (GlobalScript.inst.gameState.gamerules[1] == 1)
		{
			GlobalScript.inst.gameState.empires[1].MakeHistorical();
		}
		else if (GlobalScript.inst.gameState.gamerules[0] > 1)
		{
			if (GlobalScript.inst.gameState.gamerules[1] == 3)
			{
				GlobalScript.inst.gameState.empires[1].MakeConservative();
			}
			else if (GlobalScript.inst.gameState.gamerules[1] == 4)
			{
				GlobalScript.inst.gameState.empires[1].MakeReformist();
			}
			else if (GlobalScript.inst.gameState.gamerules[1] == 2)
			{
				GlobalScript.inst.gameState.gamerules[1] = Utils.RandomRangeFromTwoGroups(new int[4] { 1, 2, 3, 5 });
				if (GlobalScript.inst.gameState.gamerules[1] == 1)
				{
					GlobalScript.inst.gameState.empires[1].MakeHistorical();
				}
				else if (GlobalScript.inst.gameState.gamerules[1] == 4)
				{
					GlobalScript.inst.gameState.empires[1].MakeReformist();
				}
				else
				{
					GlobalScript.inst.gameState.empires[1].MakeConservative();
				}
			}
		}
		if (GlobalScript.inst.gameState.gamerules[2] == 1)
		{
			GlobalScript.inst.gameState.empires[0].MakeHistorical();
		}
		else if (GlobalScript.inst.gameState.gamerules[3] > 1)
		{
			if (GlobalScript.inst.gameState.gamerules[2] == 3)
			{
				GlobalScript.inst.gameState.empires[0].MakeAgressive();
			}
			else if (GlobalScript.inst.gameState.gamerules[2] == 4)
			{
				GlobalScript.inst.gameState.empires[0].MakePeaceful();
			}
			else if (GlobalScript.inst.gameState.gamerules[2] == 2)
			{
				GlobalScript.inst.gameState.gamerules[2] = Utils.RandomRangeFromTwoGroups(new int[4] { 1, 2, 3, 5 });
				if (GlobalScript.inst.gameState.gamerules[2] == 1)
				{
					GlobalScript.inst.gameState.empires[0].MakeHistorical();
				}
				else if (GlobalScript.inst.gameState.gamerules[2] == 3)
				{
					GlobalScript.inst.gameState.empires[0].MakeAgressive();
				}
				else
				{
					GlobalScript.inst.gameState.empires[0].MakePeaceful();
				}
			}
		}
		if (GlobalScript.inst.gameState.gamerules[3] == 1)
		{
			GlobalScript.inst.gameState.empires[0].MakeHistorical();
		}
		else if (GlobalScript.inst.gameState.gamerules[2] > 1)
		{
			if (GlobalScript.inst.gameState.gamerules[3] == 3)
			{
				GlobalScript.inst.gameState.empires[0].MakeConservative();
			}
			else if (GlobalScript.inst.gameState.gamerules[3] == 4)
			{
				GlobalScript.inst.gameState.empires[0].MakeReformist();
			}
			else if (GlobalScript.inst.gameState.gamerules[3] == 2)
			{
				GlobalScript.inst.gameState.gamerules[3] = Utils.RandomRangeFromTwoGroups(new int[4] { 1, 2, 3, 5 });
				if (GlobalScript.inst.gameState.gamerules[3] == 1)
				{
					GlobalScript.inst.gameState.empires[0].MakeHistorical();
				}
				else if (GlobalScript.inst.gameState.gamerules[3] == 4)
				{
					GlobalScript.inst.gameState.empires[0].MakeReformist();
				}
				else
				{
					GlobalScript.inst.gameState.empires[0].MakeConservative();
				}
			}
		}
		if (GlobalScript.inst.gameState.ContaintsRange(GlobalScript.inst.gameState.gamerules, (int c) => c > 1))
		{
			GlobalScript.inst.gameState.iron_and_blood = false;
		}
	}

	private void DLC05(GameState a)
	{
		a.data[162] = 50;
		ref int reference = ref a.data[161];
		ref int reference2 = ref a.data[160];
		(reference, reference2) = a.GetSoldiersNumber(a);
	}

	private void DLC6(GameState a)
	{
		a.modifies[65].active = true;
	}

	private void DLC8(GameState a)
	{
		a.citizens = new Persona[0];
	}

	public void CreateFocuses()
	{
		USSRFocuses.Init();
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
	}

	private void OnMouseEnter()
	{
		if (global1.gameState.PlayerCountry != -1)
		{
			GetComponent<TextMesh>().color = Color.gray;
		}
	}

	private void OnMouseExit()
	{
		GetComponent<TextMesh>().color = Color.black;
	}
}
