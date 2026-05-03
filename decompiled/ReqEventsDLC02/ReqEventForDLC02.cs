namespace ReqEventsDLC02;

public class ReqEventForDLC02
{
	public static bool RequrementsDLC02(ref int this_num_event, GameState a)
	{
		if (a.data[9] >= 0 && !a.event_done[300] && a.event_done[56] && a.resultOfEvents[56] == 1 && a.war == 1)
		{
			this_num_event = 300;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[301] && a.event_done[300] && (a.resultOfEvents[300] == 0 || a.resultOfEvents[300] == 1))
		{
			this_num_event = 301;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[302] && a.event_done[301] && (a.resultOfEvents[300] == 0 || a.resultOfEvents[300] == 1))
		{
			this_num_event = 302;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[303] && a.event_done[300] && a.resultOfEvents[300] == 3)
		{
			this_num_event = 303;
			return true;
		}
		if (a.leader.name_1 == 2 && a.leader.name_2 == 2 && (a.data[1] < 500 || a.data[4] > 500 || a.data[3] < 500 || a.data[5] < 250) && !a.event_done[304] && a.data[21] >= 1979)
		{
			this_num_event = 304;
			return true;
		}
		if (a.NumberOfPolitician(13, 13) >= 0 && a.data[1] <= 850 && (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1) || a.IsFactionLeadeng(2)) && !a.event_done[305] && a.data[21] >= 1981)
		{
			this_num_event = 305;
			return true;
		}
		if (a.NumberOfPolitician(15, 15) >= 0 && a.data[21] >= 1985 && !a.event_done[306])
		{
			this_num_event = 306;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[307] && a.data[21] >= 1983)
		{
			this_num_event = 307;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[308] && a.data[21] >= 1979)
		{
			this_num_event = 308;
			return true;
		}
		if (a.NumberOfPolitician(10, 16) >= 0 && !a.event_done[309] && ((a.data[1] <= 750 && (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1)) && a.data[21] >= 1981) || a.event_done[304]))
		{
			this_num_event = 309;
			return true;
		}
		if (!a.event_done[310] && (a.NumberOfPolitician(10, 16) < 0 || a.event_done[309]))
		{
			this_num_event = 310;
			return true;
		}
		if (a.NumberOfPolitician(17, 17) >= 0 && !a.event_done[311] && ((a.data[1] <= 750 && (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1)) && a.data[21] >= 1981) || a.event_done[310]))
		{
			this_num_event = 311;
			return true;
		}
		if (a.NumberOfPolitician(7, 7) >= 0 && !a.event_done[312] && ((a.data[1] <= 750 && (a.IsFactionLeadeng(0) || a.IsFactionLeadeng(1)) && a.data[21] >= 1981) || a.NumberOfPolitician(17, 17) < 0 || a.event_done[311]))
		{
			this_num_event = 312;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[313] && a.data[19] >= 3 && a.data[20] >= 2 && a.data[21] >= 1984)
		{
			this_num_event = 313;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[314] && a.data[19] >= 1 && !a.allcountries[7].isNATO && a.data[20] >= 9 && a.data[21] >= 1983)
		{
			this_num_event = 314;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[315] && a.data[19] >= 17 && a.data[20] >= 7 && a.data[21] >= 1979)
		{
			this_num_event = 315;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[316] && a.data[19] >= 12 && a.data[20] >= 4 && a.data[21] >= 1980 && a.resultOfEvents[315] == 1)
		{
			this_num_event = 316;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[317] && a.data[19] >= 23 && a.data[20] >= 9 && a.data[21] >= 1981 && (a.resultOfEvents[316] == 1 || a.allcountries[44].Gosstroy < 3))
		{
			this_num_event = 317;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[318] && a.data[19] >= 3 && a.data[20] >= 4 && a.data[21] >= 1982 && a.resultOfEvents[317] == 1)
		{
			this_num_event = 318;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[319] && a.data[19] >= 14 && a.data[20] >= 7 && a.data[21] >= 1980)
		{
			this_num_event = 319;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[320] && a.data[19] >= 19 && a.data[20] >= 10 && a.data[21] >= 1978)
		{
			this_num_event = 320;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[321] && a.data[19] >= 6 && a.data[20] >= 3 && a.data[21] >= 1982)
		{
			this_num_event = 321;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[322] && a.data[5] >= 600 && a.data[19] >= 9 && a.data[20] >= 1 && a.data[21] >= 1980)
		{
			this_num_event = 322;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[323] && a.data[16] >= 13 && a.IsFactionLeadeng(4) && a.data[19] >= 12 && a.data[20] >= 9 && a.data[21] >= 1982)
		{
			this_num_event = 323;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[324] && a.data[19] >= 1 && a.data[20] >= 10 && a.data[21] >= 1979)
		{
			this_num_event = 324;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[325] && a.data[19] >= 23 && a.data[20] >= 6 && a.data[21] >= 1982)
		{
			this_num_event = 325;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[326] && a.data[19] >= 5 && a.data[20] >= 3 && a.data[21] >= 1978)
		{
			this_num_event = 326;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[327] && a.data[19] >= 9 && a.data[20] >= 9 && a.data[21] >= 1980 && a.resultOfEvents[317] < 2)
		{
			this_num_event = 327;
			return true;
		}
		if (a.data[9] >= 0 && a.data[16] > 12 && !a.event_done[331] && a.data[19] >= 27 && a.data[20] >= 10 && a.data[21] >= 1984 && a.data[16] > 12)
		{
			this_num_event = 331;
			return true;
		}
		if (a.data[9] >= 0 && a.SEZ && !a.event_done[333] && a.data[19] >= 24 && a.data[20] >= 8 && a.data[21] >= 1981)
		{
			this_num_event = 333;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[334] && a.data[19] >= 11 && a.data[20] >= 2 && a.data[21] >= 1984 && a.data[16] > 12)
		{
			this_num_event = 334;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[335] && a.data[19] >= 13 && a.data[20] >= 6 && a.data[21] >= 1984 && a.data[16] > 12)
		{
			this_num_event = 335;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[339] && a.data[19] >= 30 && a.data[20] >= 12 && a.data[21] >= 1983)
		{
			this_num_event = 339;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[341] && a.data[19] >= 10 && a.data[20] >= 9 && a.data[21] >= 1980)
		{
			this_num_event = 341;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[342] && a.data[19] >= 20 && a.data[20] >= 7 && a.data[21] >= 1979)
		{
			this_num_event = 342;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[344] && a.data[19] >= 5 && a.data[20] >= 5 && a.data[21] >= 1984)
		{
			this_num_event = 344;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[345] && a.data[19] >= 5 && a.data[20] >= 6 && a.data[21] >= 1984)
		{
			this_num_event = 345;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[346] && a.data[19] >= 11 && a.data[20] >= 6 && a.data[21] >= 1981)
		{
			this_num_event = 346;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[349] && a.data[19] >= 24 && a.data[20] >= 6 && a.data[21] >= 1979)
		{
			this_num_event = 349;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[350] && a.data[19] >= 9 && a.data[20] >= 6 && a.data[21] >= 1979)
		{
			this_num_event = 350;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[352] && a.data[19] >= 12 && a.data[20] >= 4 && a.data[21] >= 1978)
		{
			this_num_event = 352;
			return true;
		}
		if (a.resultOfEvents[352] <= 2 && a.data[9] >= 0 && !a.event_done[353] && a.data[19] >= 12 && a.data[20] >= 6 && a.data[21] >= 1978)
		{
			this_num_event = 353;
			return true;
		}
		if (a.resultOfEvents[353] <= 1 && a.data[9] >= 0 && !a.event_done[354] && a.science[27] && a.data[21] >= 1979)
		{
			this_num_event = 354;
			return true;
		}
		if (a.resultOfEvents[354] <= 1 && a.data[9] >= 0 && !a.event_done[355] && a.science[28] && a.data[21] >= 1979 && a.data[20] >= 6)
		{
			this_num_event = 355;
			return true;
		}
		if (a.resultOfEvents[355] <= 0 && a.data[9] >= 0 && !a.event_done[356] && a.science[30])
		{
			this_num_event = 356;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[357] && a.science[30] && a.event_done[356] && a.resultOfEvents[356] == 0 && (a.resultOfEvents[353] == 0 || a.resultOfEvents[353] == 1))
		{
			this_num_event = 357;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[358] && !a.event_done[359] && a.science[31] && a.data[21] >= 1980 && a.data[20] >= 6)
		{
			this_num_event = 358;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[359] && !a.event_done[358] && a.data[21] >= 1984 && a.data[20] >= 6)
		{
			this_num_event = 359;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[360] && (a.resultOfEvents[361] <= 1 || a.resultOfEvents[358] <= 1 || a.resultOfEvents[359] <= 1) && a.data[21] >= 1985 && a.data[20] >= 6)
		{
			this_num_event = 360;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[361] && a.data[21] >= 1983 && a.data[20] >= 6 && a.science[31])
		{
			this_num_event = 361;
			return true;
		}
		if (a.data[9] >= 0 && a.resultOfEvents[360] <= 0 && !a.event_done[362] && a.data[21] >= 1985 && a.data[20] >= 6 && a.science[31])
		{
			this_num_event = 362;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[363] && a.data[21] >= 1985 && a.data[20] >= 8 && a.science[32] && (a.resultOfEvents[356] == 1 || a.resultOfEvents[357] == 0))
		{
			this_num_event = 363;
			return true;
		}
		if (a.data[9] >= 0 && !a.event_done[364] && a.event_done[363] && a.data[21] >= 1985 && a.data[20] >= 10 && a.science[33])
		{
			this_num_event = 364;
			return true;
		}
		return false;
	}

	public static bool RequrementsDLC03(ref int this_num_event, GameState a)
	{
		if (!a.event_done[365] && a.data[19] > 1 && a.data[20] >= 10 && a.data[21] == 1981)
		{
			this_num_event = 365;
			return true;
		}
		if (!a.event_done[366] && a.data[19] > 20 && a.data[20] >= 4 && a.data[21] == 1977)
		{
			this_num_event = 366;
			return true;
		}
		if (!a.event_done[367] && a.data[19] > 11 && a.data[20] >= 9 && a.data[21] == 1980)
		{
			this_num_event = 367;
			return true;
		}
		if (!a.event_done[368] && ((a.ingamewars[3].is_going && a.data[21] == 1983 && a.data[19] > 14 && a.data[20] >= 11) || (a.ingamewars[28].is_going && a.data[21] >= 1981)) && !a.OAR && !a.allcountries[35].isSEV && !a.allcountries[35].econ)
		{
			this_num_event = 368;
			return true;
		}
		if (!a.event_done[369] && a.allcountries[84].SubGosstroy == 9 && a.data[19] > 1 && a.data[20] >= 2 && a.data[21] == 1984)
		{
			this_num_event = 369;
			return true;
		}
		if (!a.event_done[370] && a.allcountries[84].SubGosstroy == 9 && ((!a.allcountries[35].prosov && !a.allcountries[35].oar && !a.allcountries[35].isOVD && !a.allcountries[35].isSEATO && !a.allcountries[35].Vyshi && !a.allcountries[35].okb) || (!a.allcountries[14].prosov && !a.allcountries[14].isSEATO && !a.allcountries[14].oar && !a.allcountries[14].okb && !a.allcountries[14].isOVD) || (!a.allcountries[8].Vyshi && !a.allcountries[8].isSEATO && !a.allcountries[8].okb && !a.allcountries[8].isOVD)) && !a.ingamewars[9].is_going && a.data[19] > 20 && a.data[20] >= 12 && a.data[21] == 1984)
		{
			this_num_event = 370;
			return true;
		}
		if (!a.event_done[371] && a.Israellost && a.ingamewars[10].is_going && a.allcountries[37].Gosstroy == 3 && !a.allcountries[37].proprc && !a.allcountries[35].Vyshi && a.allcountries[37].dev <= 0)
		{
			this_num_event = 371;
			return true;
		}
		if (a.data[124] == 10)
		{
			this_num_event = 372;
			return true;
		}
		if (!a.event_done[373] && a.allcountries[84].SubGosstroy == 9 && GlobalScript.inst.gameState.allcountries[14].puppetOf == 84 && GlobalScript.inst.gameState.allcountries[8].puppetOf == 84 && GlobalScript.inst.gameState.allcountries[35].puppetOf == 84 && !a.allcountries[84].isNATO && !a.allcountries[84].Vyshi && a.data[20] >= 6 && a.data[21] == 1985)
		{
			this_num_event = 373;
			return true;
		}
		if (a.data[127] == 10)
		{
			this_num_event = 374;
			return true;
		}
		if (!a.event_done[375] && a.empires[1].now_leader == 4 && a.empires[1].power >= 100 && a.empires[0].power <= 100 && a.data[126] > 0 && a.data[124] == 100 && !a.allcountries[84].isNATO && !a.allcountries[1].isSEV)
		{
			this_num_event = 375;
			return true;
		}
		if (!a.event_done[376] && a.data[19] > 23 && a.data[20] >= 7 && a.data[21] == 1977)
		{
			this_num_event = 376;
			return true;
		}
		if (!a.event_done[377] && !a.allcountries[1].isASEAN && a.data[21] >= 1985 && a.data[20] > 3 && !a.allcountries[1].isOVD && !a.allcountries[1].isSEV && a.empires[1].now_leader == 4 && a.empires[1].power > 100 && !a.allcountries[4].prosov && !a.allcountries[5].prosov && !a.allcountries[2].prosov && !a.ingamewars[22].is_going && a.data[133] == 0)
		{
			this_num_event = 377;
			return true;
		}
		if (!a.event_done[378] && a.data[21] >= 1982 && a.data[20] >= 6 && !a.allcountries[10].prosov && !a.allcountries[10].isOVD && !a.allcountries[10].isSEV)
		{
			this_num_event = 378;
			return true;
		}
		if (!a.event_done[379] && a.data[7] > 500 && (a.data[21] > 1983 || (a.data[21] == 1983 && a.data[20] > 3)) && a.data[21] < 1984 && a.empires[1].now_leader == 1 && a.empires[0].now_leader == 1 && a.empires[1].power + a.empires[0].power < 300 && !a.allcountries[1].isOVD && a.allcountries[51].isNATO && !a.allcountries[1].isSEV && !a.allcountries[1].isASEAN && a.allcountries[12].prosov && a.ingamewars[5].is_going && (a.ingamewars[5].diplo_done[1] || a.resultOfEvents[52] == 3 || a.resultOfEvents[50] == 3))
		{
			this_num_event = 379;
			return true;
		}
		if (!a.event_done[380] && a.empires[1].now_leader == 4 && a.data[21] == 1985 && a.data[20] >= 3 && a.data[19] > 15)
		{
			this_num_event = 380;
			return true;
		}
		if (!a.event_done[381] && a.empires[1].now_leader == 7 && a.data[21] == 1985 && a.data[20] >= 1 && a.allcountries[17].isNATO && a.allcountries[17].isEU)
		{
			this_num_event = 381;
			return true;
		}
		if (!a.event_done[382] && a.data[21] == 1981 && a.data[20] >= 6 && a.resultOfEvents[76] == 3 && !a.allcountries[1].isEU && !a.allcountries[1].isNATO && !a.allcountries[1].isSEV && !a.allcountries[1].isOVD)
		{
			this_num_event = 382;
			return true;
		}
		if (!a.event_done[383] && a.data[21] == 1985 && a.allcountries[20].parts[0] && a.data[20] >= 5 && !a.allcountries[45].econ && !a.allcountries[45].isSEV && !a.allcountries[45].isNATO && a.data[60] == 3)
		{
			this_num_event = 383;
			return true;
		}
		if (!a.event_done[384] && a.data[21] == 1981 && a.data[20] >= 2)
		{
			this_num_event = 384;
			return true;
		}
		if (!a.event_done[385] && a.data[21] == 1981 && a.data[20] >= 5 && a.data[19] > 10)
		{
			this_num_event = 385;
			return true;
		}
		if (!a.event_done[386] && a.data[21] == 1978 && a.data[20] >= 6)
		{
			this_num_event = 386;
			return true;
		}
		if (!a.event_done[387] && a.data[21] == 1979 && a.data[20] >= 2 && a.data[19] > 20)
		{
			this_num_event = 387;
			return true;
		}
		if (!a.event_done[388] && a.data[21] == 1985 && !a.allcountries[1].isOVD && !a.allcountries[1].isSEV && a.empires[1].now_leader == 4 && a.empires[1].power >= 250 && a.data[20] > 5 && a.allcountries[9].prosov && a.allcountries[4].prosov && a.allcountries[5].prosov && a.allcountries[6].prosov && !a.ingamewars[22].is_going && a.data[133] == 0)
		{
			this_num_event = 388;
			return true;
		}
		if (!a.event_done[389] && a.data[21] == 1983 && a.data[20] >= 6 && a.data[21] > 15 && a.data[131] == 1)
		{
			this_num_event = 389;
			return true;
		}
		if (!a.event_done[390] && a.data[21] == 1983 && a.data[20] >= 5 && a.data[21] > 1 && a.data[131] == 2)
		{
			this_num_event = 390;
			return true;
		}
		if (!a.event_done[391] && a.data[21] == 1978 && a.data[20] >= 1)
		{
			this_num_event = 391;
			return true;
		}
		if (!a.event_done[392] && a.data[21] == 1978 && a.data[20] >= 3 && a.data[19] > 19 && (a.allcountries[85].inflCh >= 0 || a.allcountries[85].inflNATO >= 0))
		{
			this_num_event = 392;
			return true;
		}
		if (!a.event_done[393] && a.data[21] == 1978 && a.data[20] >= 3 && a.data[19] > 19 && a.allcountries[85].inflCh < 0 && a.allcountries[85].inflNATO < 0)
		{
			this_num_event = 393;
			return true;
		}
		if (!a.event_done[394] && a.data[21] == 1979 && a.data[20] >= 6 && a.data[19] > 20 && (a.allcountries[85].inflCh == 2 || (a.allcountries[85].inflCh == 0 && a.allcountries[85].inflNATO == 0) || a.allcountries[85].inflNATO == 2 || a.allcountries[85].inflCh == 5 || a.allcountries[85].inflNATO == 5))
		{
			this_num_event = 394;
			return true;
		}
		if (!a.event_done[395] && a.data[21] == 1980 && a.data[20] >= 6 && a.data[19] > 10 && a.allcountries[85].inflNATO == 4 && a.allcountries[85].inflCh == 4)
		{
			this_num_event = 395;
			return true;
		}
		if (!a.event_done[396] && a.allcountries[85].based)
		{
			this_num_event = 396;
			return true;
		}
		if (!a.event_done[397] && a.data[21] == 1982 && a.data[20] >= 8 && a.allcountries[85].inflNATO == 3 && a.allcountries[85].inflCh == 3)
		{
			this_num_event = 397;
			return true;
		}
		if (!a.event_done[398] && a.data[21] == 1983 && a.data[20] >= 2 && a.allcountries[85].inflNATO == 10)
		{
			this_num_event = 398;
			return true;
		}
		if (!a.event_done[399] && !a.event_done[401] && !a.event_done[398] && a.data[21] == 1983 && a.data[20] >= 6 && a.data[19] > 15 && !a.allcountries[85].isSocEU && !a.allcountries[85].isSEV && !a.allcountries[85].econ && !a.allcountries[85].prosov && a.allcountries[85].Gosstroy != 1 && a.allcountries[85].Gosstroy != 0 && a.allcountries[85].Gosstroy != 3)
		{
			this_num_event = 399;
			return true;
		}
		if (!a.event_done[400] && a.data[21] == 1984 && a.data[20] >= 6 && a.data[19] > 10 && a.allcountries[85].SubGosstroy == 14)
		{
			this_num_event = 400;
			return true;
		}
		if (!a.event_done[401] && a.data[21] == 1983 && a.data[20] >= 2 && a.allcountries[85].inflCh == 10)
		{
			this_num_event = 401;
			return true;
		}
		if (!a.event_done[402] && a.data[21] == 1984 && a.data[20] >= 11)
		{
			this_num_event = 402;
			return true;
		}
		if (!a.event_done[403] && a.data[21] == 1984 && a.data[20] >= 3)
		{
			this_num_event = 403;
			return true;
		}
		if (!a.event_done[404] && a.data[21] == 1981 && a.data[20] >= 1)
		{
			this_num_event = 404;
			return true;
		}
		if (!a.event_done[405] && a.data[21] == 1979 && a.data[20] >= 5)
		{
			this_num_event = 405;
			return true;
		}
		if (!a.event_done[406] && a.data[21] == 1983 && a.data[20] >= 5 && a.data[19] > 20)
		{
			this_num_event = 406;
			return true;
		}
		if (!a.event_done[407] && a.data[21] > 1983 && a.allcountries[92].Gosstroy == 1 && a.allcountries[1].Gosstroy == 1 && a.allcountries[1].okb && !a.modifies[6].active)
		{
			this_num_event = 407;
			return true;
		}
		if (a.allcountries[1].dev == 1)
		{
			this_num_event = 408;
			return true;
		}
		if (a.allcountries[1].dev == 2)
		{
			this_num_event = 409;
			return true;
		}
		if (a.allcountries[1].isSEV && a.allcountries[7].spec <= 0 && (a.allcountries[1].Gosstroy == 3 || (a.allcountries[1].Gosstroy == 0 && a.data[52] == 37)))
		{
			this_num_event = 410;
			return true;
		}
		if (a.allcountries[1].isASEAN && a.allcountries[51].spec <= 0 && (a.allcountries[1].Gosstroy == 1 || (a.allcountries[1].Gosstroy == 0 && a.data[52] == 34)))
		{
			this_num_event = 411;
			return true;
		}
		if (!a.event_done[412] && !a.allcountries[31].isASEAN && a.allcountries[31].Vyshi && a.allcountries[8].isSENTO && a.allcountries[1].isSEATO && a.data[21] >= 1980 && a.data[20] >= 5)
		{
			this_num_event = 412;
			return true;
		}
		if (!a.event_done[413] && !a.allcountries[51].cw && (!a.allcountries[31].isSENTO || !a.allcountries[8].isSENTO) && a.data[21] >= 1979 && a.data[20] >= 4)
		{
			this_num_event = 413;
			return true;
		}
		if (!a.event_done[414] && a.data[21] == 1976 && a.data[20] >= 4 && a.data[19] >= 20)
		{
			this_num_event = 414;
			return true;
		}
		if (!a.event_done[415] && a.data[21] == 1979 && a.data[20] >= 3 && a.data[19] >= 14)
		{
			this_num_event = 415;
			return true;
		}
		if (!a.event_done[416] && a.data[21] == 1983 && a.data[20] >= 3 && a.data[19] >= 10 && !a.allcountries[48].isSEV && a.empires[0].now_leader == 0)
		{
			this_num_event = 416;
			return true;
		}
		if (!a.event_done[417] && !a.OAR && a.data[21] >= 1981 && a.data[21] < 1983 && a.data[20] >= 3 && (a.allcountries[8].isSEATO || a.allcountries[8].isSENTO || a.allcountries[8].isOVD || a.allcountries[8].okb) && !a.ingamewars[3].is_going && a.allcountries[14].Gosstroy == 0)
		{
			this_num_event = 417;
			return true;
		}
		if (!a.event_done[418] && a.data[21] >= 1981 && a.data[20] >= 5 && !a.ingamewars[28].is_going && !a.allcountries[14].parts[5] && a.modifies[51].active)
		{
			this_num_event = 418;
			return true;
		}
		if (!a.event_done[419] && a.allcountries[87].spec >= 50 && a.allcountries[87].Gosstroy == 2)
		{
			this_num_event = 419;
			return true;
		}
		if (!a.event_done[420] && a.allcountries[87].Gosstroy == 2 && a.data[21] == 1982 && a.data[20] >= 5)
		{
			this_num_event = 420;
			return true;
		}
		if (!a.event_done[421] && !a.allcountries[87].isNATO && !a.allcountries[21].isNATO && !a.allcountries[84].isNATO && !a.allcountries[86].isNATO && !a.allcountries[45].isNATO && !a.allcountries[92].isNATO && !a.allcountries[7].isNATO && a.allcountries[17].dev != 2 && a.allcountries[7].isOVD)
		{
			this_num_event = 421;
			return true;
		}
		if (!a.event_done[422] && !a.allcountries[21].isEU && !a.allcountries[85].isEU && !a.allcountries[86].isEU && !a.allcountries[92].isEU && !a.allcountries[45].isEU)
		{
			this_num_event = 422;
			return true;
		}
		if (!a.event_done[423] && a.data[21] == 1977 && a.data[20] >= 6)
		{
			this_num_event = 423;
			return true;
		}
		if (!a.event_done[424] && a.data[21] == 1978 && a.data[20] >= 11 && a.data[19] > 9)
		{
			this_num_event = 424;
			return true;
		}
		if (!a.event_done[425] && a.data[21] == 1979 && a.data[20] >= 2 && a.data[19] > 1 && a.resultOfEvents[424] == 1)
		{
			this_num_event = 425;
			return true;
		}
		if (!a.event_done[426] && a.resultOfEvents[424] == 0 && a.data[21] == 1979 && a.data[20] >= 2 && a.data[19] > 1 && a.ingamewars[30].is_going)
		{
			this_num_event = 426;
			return true;
		}
		if (!a.event_done[427] && a.resultOfEvents[425] == 1 && a.data[21] == 1981 && a.data[20] >= 2 && a.data[19] > 16)
		{
			this_num_event = 427;
			return true;
		}
		if (!a.event_done[428] && a.allcountries[86].Gosstroy == 3 && a.resultOfEvents[424] == 1 && a.data[21] == 1982 && a.data[20] >= 6 && a.data[19] > 1)
		{
			this_num_event = 428;
			return true;
		}
		if (!a.event_done[429] && a.allcountries[86].isNATO && a.data[21] == 1982 && a.data[20] >= 11 && a.data[19] > 1)
		{
			this_num_event = 429;
			return true;
		}
		if (!a.event_done[430] && a.data[21] == 1983 && a.data[20] >= 5 && a.data[19] > 14 && a.allcountries[86].SubGosstroy == 3 && a.allcountries[85].SubGosstroy == 14 && a.allcountries[21].SubGosstroy == 14)
		{
			this_num_event = 430;
			return true;
		}
		if (!a.event_done[431] && a.data[21] == 1983 && a.data[20] >= 9 && !a.allcountries[86].isSocEU && a.allcountries[86].SubGosstroy == 3 && a.allcountries[0].isEU)
		{
			this_num_event = 431;
			return true;
		}
		if (!a.event_done[432] && a.data[21] >= 1983 && a.data[20] >= 8 && a.resultOfEvents[424] == 0 && a.allcountries[86].SubGosstroy == 6 && !a.ingamewars[30].is_going)
		{
			this_num_event = 432;
			return true;
		}
		if (!a.event_done[433] && a.empires[1].now_leader == 6 && !a.allcountries[2].isOVD && !a.allcountries[5].isOVD && !a.allcountries[4].isOVD && a.allcountries[51].isNATO && a.allcountries[17].dev == 2 && a.allcountries[17].Gosstroy == 3)
		{
			this_num_event = 433;
			return true;
		}
		if (!a.event_done[434] && a.ingamewars[26].is_going && a.ingamewars[26].fortnight_go >= 12 && a.resultOfEvents[398] == 1)
		{
			this_num_event = 434;
			return true;
		}
		return false;
	}

	public static bool RequrementsDLC01(ref int this_num_event, GameState a)
	{
		if (((a.allcountries[73].next_elections.Month <= a.data[20] && a.allcountries[73].next_elections.Year <= a.data[21]) || a.allcountries[73].next_elections.Year < a.data[21]) && (!a.allcountries[73].proprc || a.allcountries[73].Gosstroy == 3) && !a.event_done[126])
		{
			this_num_event = 126;
			return true;
		}
		if (((a.allcountries[73].next_elections.Month <= a.data[20] && a.allcountries[73].next_elections.Year <= a.data[21]) || a.allcountries[73].next_elections.Year < a.data[21]) && (!a.allcountries[73].proprc || a.allcountries[73].Gosstroy == 3) && a.event_done[126] && !a.event_done[127])
		{
			this_num_event = 127;
			return true;
		}
		if (((a.allcountries[71].next_elections.Month <= a.data[20] && a.allcountries[71].next_elections.Year <= a.data[21]) || a.allcountries[71].next_elections.Year < a.data[21]) && (!a.allcountries[71].proprc || a.allcountries[71].Gosstroy == 3) && !a.event_done[128])
		{
			this_num_event = 128;
			return true;
		}
		if (((a.allcountries[71].next_elections.Month <= a.data[20] && a.allcountries[71].next_elections.Year <= a.data[21]) || a.allcountries[71].next_elections.Year < a.data[21]) && (!a.allcountries[71].proprc || a.allcountries[71].Gosstroy == 3) && a.event_done[128] && !a.event_done[129])
		{
			this_num_event = 129;
			return true;
		}
		if (((a.allcountries[72].next_elections.Month <= a.data[20] && a.allcountries[72].next_elections.Year <= a.data[21]) || a.allcountries[72].next_elections.Year < a.data[21]) && (!a.allcountries[72].proprc || a.allcountries[72].Gosstroy == 3) && !a.event_done[130])
		{
			this_num_event = 130;
			return true;
		}
		if (((a.allcountries[72].next_elections.Month <= a.data[20] && a.allcountries[72].next_elections.Year <= a.data[21]) || a.allcountries[72].next_elections.Year < a.data[21]) && (!a.allcountries[72].proprc || a.allcountries[72].Gosstroy == 3) && a.event_done[130] && !a.event_done[131])
		{
			this_num_event = 131;
			return true;
		}
		if (((a.allcountries[72].next_elections.Month <= a.data[20] && a.allcountries[72].next_elections.Year <= a.data[21]) || a.allcountries[72].next_elections.Year < a.data[21]) && (!a.allcountries[72].proprc || a.allcountries[72].Gosstroy == 3) && a.event_done[131] && !a.event_done[132])
		{
			this_num_event = 132;
			return true;
		}
		if (((a.allcountries[74].next_elections.Month <= a.data[20] && a.allcountries[74].next_elections.Year <= a.data[21]) || a.allcountries[74].next_elections.Year < a.data[21]) && (!a.allcountries[74].proprc || a.allcountries[74].Gosstroy == 3) && !a.event_done[133])
		{
			this_num_event = 133;
			return true;
		}
		if (((a.allcountries[74].next_elections.Month <= a.data[20] && a.allcountries[74].next_elections.Year <= a.data[21]) || a.allcountries[74].next_elections.Year < a.data[21]) && (!a.allcountries[74].proprc || a.allcountries[74].Gosstroy == 3) && a.event_done[133] && !a.event_done[134])
		{
			this_num_event = 134;
			return true;
		}
		if (((a.allcountries[82].next_elections.Month <= a.data[20] && a.allcountries[82].next_elections.Year <= a.data[21]) || a.allcountries[82].next_elections.Year < a.data[21]) && (!a.allcountries[82].proprc || a.allcountries[82].Gosstroy == 3) && !a.event_done[135])
		{
			this_num_event = 135;
			return true;
		}
		if (((a.allcountries[82].next_elections.Month <= a.data[20] && a.allcountries[82].next_elections.Year <= a.data[21]) || a.allcountries[82].next_elections.Year < a.data[21]) && (!a.allcountries[82].proprc || a.allcountries[82].Gosstroy == 3) && a.event_done[135] && !a.event_done[136])
		{
			this_num_event = 136;
			return true;
		}
		if (((a.allcountries[82].next_elections.Month <= a.data[20] && a.allcountries[82].next_elections.Year <= a.data[21]) || a.allcountries[82].next_elections.Year < a.data[21]) && (!a.allcountries[82].proprc || a.allcountries[82].Gosstroy == 3) && a.event_done[136] && !a.event_done[137])
		{
			this_num_event = 137;
			return true;
		}
		if (((a.allcountries[79].next_elections.Month <= a.data[20] && a.allcountries[79].next_elections.Year <= a.data[21]) || a.allcountries[79].next_elections.Year < a.data[21]) && (!a.allcountries[79].proprc || a.allcountries[79].Gosstroy == 3) && !a.event_done[138])
		{
			this_num_event = 138;
			return true;
		}
		if (((a.allcountries[79].next_elections.Month <= a.data[20] && a.allcountries[79].next_elections.Year <= a.data[21]) || a.allcountries[79].next_elections.Year < a.data[21]) && (!a.allcountries[79].proprc || a.allcountries[79].Gosstroy == 3) && a.resultOfEvents[138] == 0 && a.event_done[138] && !a.event_done[139])
		{
			this_num_event = 139;
			return true;
		}
		if (((a.allcountries[79].next_elections.Month <= a.data[20] && a.allcountries[79].next_elections.Year <= a.data[21]) || a.allcountries[79].next_elections.Year < a.data[21]) && (!a.allcountries[79].proprc || a.allcountries[79].Gosstroy == 3) && a.resultOfEvents[138] != 0 && a.event_done[138] && !a.event_done[140])
		{
			this_num_event = 140;
			return true;
		}
		if (((a.allcountries[80].next_elections.Month <= a.data[20] && a.allcountries[80].next_elections.Year <= a.data[21]) || a.allcountries[80].next_elections.Year < a.data[21]) && (!a.allcountries[80].proprc || a.allcountries[80].Gosstroy == 3) && !a.event_done[141])
		{
			this_num_event = 141;
			return true;
		}
		if (((a.allcountries[80].next_elections.Month <= a.data[20] && a.allcountries[80].next_elections.Year <= a.data[21]) || a.allcountries[80].next_elections.Year < a.data[21]) && (!a.allcountries[80].proprc || a.allcountries[80].Gosstroy == 3) && a.event_done[141] && !a.event_done[142])
		{
			this_num_event = 142;
			return true;
		}
		if (((a.allcountries[76].next_elections.Month <= a.data[20] && a.allcountries[76].next_elections.Year <= a.data[21]) || a.allcountries[76].next_elections.Year < a.data[21]) && (!a.allcountries[76].proprc || a.allcountries[76].Gosstroy == 3) && !a.event_done[143])
		{
			this_num_event = 143;
			return true;
		}
		if (((a.allcountries[76].next_elections.Month <= a.data[20] && a.allcountries[76].next_elections.Year <= a.data[21]) || a.allcountries[76].next_elections.Year < a.data[21]) && (!a.allcountries[76].proprc || a.allcountries[76].Gosstroy == 3) && a.event_done[143] && !a.event_done[144])
		{
			this_num_event = 144;
			return true;
		}
		if (((a.allcountries[75].next_elections.Month <= a.data[20] && a.allcountries[75].next_elections.Year <= a.data[21]) || a.allcountries[75].next_elections.Year < a.data[21]) && (!a.allcountries[75].proprc || a.allcountries[75].Gosstroy == 3) && !a.event_done[145])
		{
			this_num_event = 145;
			return true;
		}
		if (((a.allcountries[75].next_elections.Month <= a.data[20] && a.allcountries[75].next_elections.Year <= a.data[21]) || a.allcountries[75].next_elections.Year < a.data[21]) && (!a.allcountries[75].proprc || a.allcountries[75].Gosstroy == 3) && a.event_done[145] && !a.event_done[146])
		{
			this_num_event = 146;
			return true;
		}
		if (((a.allcountries[83].next_elections.Month <= a.data[20] && a.allcountries[83].next_elections.Year <= a.data[21]) || a.allcountries[83].next_elections.Year < a.data[21]) && (!a.allcountries[83].proprc || a.allcountries[83].Gosstroy == 3) && !a.event_done[147])
		{
			this_num_event = 147;
			return true;
		}
		if (((a.allcountries[83].next_elections.Month <= a.data[20] && a.allcountries[83].next_elections.Year <= a.data[21]) || a.allcountries[83].next_elections.Year < a.data[21]) && (!a.allcountries[83].proprc || a.allcountries[83].Gosstroy == 3) && a.event_done[147] && !a.event_done[148])
		{
			this_num_event = 148;
			return true;
		}
		if (((a.allcountries[77].next_elections.Month <= a.data[20] && a.allcountries[77].next_elections.Year <= a.data[21]) || a.allcountries[77].next_elections.Year < a.data[21]) && (!a.allcountries[77].proprc || a.allcountries[77].Gosstroy == 3) && !a.event_done[149])
		{
			this_num_event = 149;
			return true;
		}
		if (((a.allcountries[77].next_elections.Month <= a.data[20] && a.allcountries[77].next_elections.Year <= a.data[21]) || a.allcountries[77].next_elections.Year < a.data[21]) && (!a.allcountries[77].proprc || a.allcountries[77].Gosstroy == 3) && a.event_done[149] && !a.event_done[150])
		{
			this_num_event = 150;
			return true;
		}
		if (((a.allcountries[81].next_elections.Month <= a.data[20] && a.allcountries[81].next_elections.Year <= a.data[21]) || a.allcountries[81].next_elections.Year < a.data[21]) && (!a.allcountries[81].proprc || a.allcountries[81].Gosstroy == 3) && !a.event_done[151])
		{
			this_num_event = 151;
			return true;
		}
		return false;
	}

	public static bool RequrementsDLC04(ref int this_num_event, GameState a)
	{
		if (a.data[19] >= 4 && a.data[20] >= 2 && a.data[21] >= 1976 && !a.event_done[437])
		{
			this_num_event = 437;
			return true;
		}
		if (a.data[19] >= 4 && a.data[20] >= 4 && a.data[21] >= 1976 && !a.event_done[438])
		{
			this_num_event = 438;
			return true;
		}
		if (a.data[19] >= 24 && a.data[20] >= 6 && a.data[21] >= 1976 && !a.event_done[439])
		{
			this_num_event = 439;
			return true;
		}
		if (a.data[19] >= 9 && a.data[20] >= 5 && a.data[21] >= 1976 && !a.event_done[440])
		{
			this_num_event = 440;
			return true;
		}
		if (a.data[20] >= 8 && a.data[21] >= 1976 && !a.event_done[441])
		{
			this_num_event = 441;
			return true;
		}
		if (a.data[20] >= 9 && a.data[21] >= 1976 && a.resultOfEvents[437] == 0 && !a.event_done[442])
		{
			this_num_event = 442;
			return true;
		}
		return false;
	}
}
