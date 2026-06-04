using UnityEngine;

public class GlobalScript : MonoBehaviour
{
	public bool[] dlc = new bool[5];

	public GameState gameState;

	public string[] other_text;

	public string[] new_texts;

	public string[] new_modify_texts;

	public string[] country_texts;

	public string[] new_modify_desc;

	public string[] old_modify_texts;

	public string[] old_modify_desc;

	public string[] new_focuses_texts;

	public string[] new_focuses_desc;

	public string[] new_events_text;

	public int this_stump = -1;

	public int speed;

	public int voice = 5;

	public int map_type = 1;

	public int autosave;

	public int autosavej;

	public int savePlace = 5;

	public AudioClip[] music = new AudioClip[26];

	public int now_playing;

	public int zadan_playing;

	public int albumNum = -1;

	public bool zadan_music;

	public bool get_to_cycle;

	public bool is_ready_to_play;

	public int bitss = 1;

	public Sprite crisis;

	public static GlobalScript inst;

	public void CreateDecisions()
	{
		bool[] array = null;
		if (gameState.decisions != null)
		{
			array = new bool[gameState.decisions.Length];
			for (int i = 0; i < gameState.decisions.Length; i++)
			{
				array[i] = gameState.completedDecisions[i];
			}
		}
		gameState.decisions = null;
		gameState.decisions = new Decision[41]
		{
			new Decision(new_texts[113], new_texts[131]).Expr.thirdOne.TheyAreOurs(10).thirdOne.HasSomeoneWonInTheWar(0, 0, 10).thirdOne.HasMoney(250).thirdOne.HasAgents(250).thirdOne.AddAgents(-250).thirdOne.AddArmy(-250).thirdOne.StartEvent(120).End,
			new Decision(new_texts[114], new_texts[132]).Expr.thirdOne.TibetIsOurs(yes: true).thirdOne.IsUnitarism(yes: false).thirdOne.IsLiberal(yes: true).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(0, -500).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(1, -500).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(2, -500).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(3, 250).thirdOne.AddRelations(0, 250).thirdOne.AddRelations(1, 250).thirdOne.StartEvent(121).End,
			new Decision(new_texts[115], new_texts[133]).Expr.thirdOne.TibetIsOurs(yes: true).thirdOne.IsUnitarism(yes: true).thirdOne.IsAutoritharian(yes: true).thirdOne.IsRadicalTradition(yes: true).thirdOne.HasArmy(250).thirdOne.TibetMustStay(2).thirdOne.AddRelations(0, -250).thirdOne.AddRelations(1, -250).thirdOne.AddChineseInfluence(-25).thirdOne.AddMoney(-250).thirdOne.AddNationalism(250).thirdOne.AddPopulation(-105).thirdOne.ChangeSpecialEndingForTheCountry(69, 5).End,
			new Decision(new_texts[116], new_texts[134]).Expr.thirdOne.UyghurIsOurs(yes: true).thirdOne.IsUnitarism(yes: false).thirdOne.IsLiberal(yes: true).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(0, -500).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(1, -500).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(2, -500).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(3, 250).thirdOne.AddRelations(0, 250).thirdOne.AddRelations(1, 250).thirdOne.StartEvent(122).End,
			new Decision(new_texts[117], new_texts[135]).Expr.thirdOne.UyghurIsOurs(yes: true).thirdOne.IsUnitarism(yes: true).thirdOne.IsAutoritharian(yes: true).thirdOne.IsRadicalTradition(yes: true).thirdOne.HasArmy(250).thirdOne.UyghurMustStay(4).thirdOne.AddRelations(0, -250).thirdOne.AddRelations(1, -250).thirdOne.AddChineseInfluence(-25).thirdOne.AddMoney(-250).thirdOne.AddNationalism(250).thirdOne.AddPopulation(-250).thirdOne.ChangeSpecialEndingForTheCountry(70, 5).End,
			new Decision(new_texts[118], new_texts[136]).Expr.thirdOne.IsPartyEnabled(yes: false, 0).thirdOne.HasOnePartyMechanic(yes: true).thirdOne.AllLeadersAreDead().thirdOne.StartEvent(123).End,
			new Decision(new_texts[119], new_texts[137]).Expr.thirdOne.HasAutonomyForMacao(yes: true).thirdOne.IsTaiwanAttacked(yes: false).thirdOne.IsInTheOVD(yes: false, 1).thirdOne.IsInTheSEV(yes: false, 1).thirdOne.HasCulturalRevolution(yes: false).thirdOne.HasMaoismus(yes: false).thirdOne.IsDipRepLessThan(yes: true, 500).thirdOne.MakeProChinese(yes: true, 38).thirdOne.MakeProUSA(yes: false, 38).thirdOne.ChangeBotSystem(2, 38).thirdOne.AddChineseInfluence(30).thirdOne.AddSupport(50).thirdOne.AddLiberalization(-50).End,
			new Decision(new_texts[120], new_texts[138]).Expr.thirdOne.TibetIsOurs(yes: true).thirdOne.UyghurIsOurs(yes: true).thirdOne.HasAgents(1500).thirdOne.HasArmy(1500).thirdOne.HasMoney(1500).thirdOne.IsChiSovInfluenceLessThan(yes: false, 500).thirdOne.IsAmericanInfluenceLessThan(yes: true, 100).thirdOne.IsTaiwanAttacked(yes: true).thirdOne.TheyAreOurs(1).thirdOne.HasAnnexedMacao(yes: true).thirdOne.HasAgressiveMilitaryDoctrine(yes: true).thirdOne.AnnexationInfo(7, 38, 1).thirdOne.MakeProUSA(yes: false, 38).thirdOne.AddRelations(0, -1000).thirdOne.AddChineseInfluence(50).thirdOne.AddPopulation(180).thirdOne.AddSupport(50).thirdOne.AddLiberalization(-50).thirdOne.AddAgents(-1500).thirdOne.AddMoney(-1500).thirdOne.AddArmy(-1500).End,
			new Decision(new_texts[121], new_texts[139]).Expr.thirdOne.HasLeftRadicalLeader(yes: true).thirdOne.TheyAreOurs(1).thirdOne.IsMaoPraised(yes: true).thirdOne.IsNotAntiMaoInTheUSSR().thirdOne.AddLiberalization(250).thirdOne.AddPowerToAllPoliticiansInTheFaction(0, 150).thirdOne.AddRelations(1, 250).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(2, -500).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(3, -500).thirdOne.MaoismIsBetter(8).End,
			new Decision(new_texts[122], new_texts[140]).Expr.thirdOne.HasCommunistLeader(yes: true).thirdOne.HasSovietFriendship(yes: false).thirdOne.TheyAreOurs(1).thirdOne.HasEuropeansPuppets().thirdOne.ProChinese(12).thirdOne.ProChinese(8).thirdOne.IsChineseInfluenceLessThan(yes: false, 350).thirdOne.HasGorbachev().thirdOne.IsYearLess(yes: false, 1984).thirdOne.HasMaoismus(yes: true).thirdOne.MakeInWPO(yes: false, 2).thirdOne.MakeInWPO(yes: false, 4).thirdOne.MakeInWPO(yes: false, 5).thirdOne.MakeInSEV(yes: false, 2).thirdOne.MakeInSEV(yes: false, 4).thirdOne.MakeInSEV(yes: false, 5).thirdOne.MakeInOKB(yes: true, 2).thirdOne.MakeInOKB(yes: true, 4).thirdOne.MakeInOKB(yes: true, 5).thirdOne.MakeInEcon(yes: true, 2).thirdOne.MakeInEcon(yes: true, 4).thirdOne.MakeInEcon(yes: true, 5).thirdOne.AddAmericanInfluence(100).thirdOne.AddRelations(0, 250).thirdOne.AddRelations(1, -1000).thirdOne.AddSovietInfluence(-1000).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(0, 500).thirdOne.AddLoyalityToAllPoliticiansInTheFaction(2, 500).thirdOne.MaoismSOVIsBetter(9).End,
			new Decision(new_texts[123], new_texts[141]).Expr.thirdOne.TheyAreOurs(8).thirdOne.TheyAreOurs(31).thirdOne.HasOngoingWar(yes: true, 5).thirdOne.AddAgents(-250).thirdOne.AddArmy(-250).thirdOne.AddRelations(0, -1000).thirdOne.AddChineseInfluence(10).thirdOne.AddNaxalitPower(100).thirdOne.LeaveTheWar(5, 0).End,
			new Decision(new_texts[124], new_texts[142]).Expr.thirdOne.IsPoliticianAlive(16, 16, 1, 5, 11).thirdOne.HasAgents(250).thirdOne.HasCulturalRevolution(yes: false).thirdOne.HasModerateFaction(yes: true).thirdOne.HasModerateLeader(yes: true).thirdOne.AddRelations(0, 250).thirdOne.AddRelations(1, 250).thirdOne.AddAgents(-250).thirdOne.AddLiberalization(250).thirdOne.AddSupport(150).thirdOne.AddStandardOfLiving(50).thirdOne.MakeHimLeader(16, 16, 1, 5, 11).thirdOne.KillTheLeaderOfTheFaction(0).thirdOne.KillTheLeaderOfTheFaction(1).thirdOne.KillTheLeaderOfTheFaction(3).thirdOne.KillTheLeaderOfTheFaction(4).End,
			new Decision(new_texts[125], new_texts[143]).Expr.thirdOne.HasOnePartyMechanic(yes: true).thirdOne.HasAgents(250).thirdOne.IsLiberal(yes: true).thirdOne.IsLeftRadLessThenPercent(5).thirdOne.HasCapitalistEconomy(yes: true).thirdOne.HasOligarchyPowerLess(yes: false, 60).thirdOne.AgreeToOligarchy(12).End,
			new Decision(new_texts[126], new_texts[144]).Expr.thirdOne.HasOnePartyMechanic(yes: true).thirdOne.HasCapitalistEconomy(yes: false).thirdOne.HasSovietFriendship(yes: true).thirdOne.IsYearLess(yes: true, 1984).thirdOne.IsMaoDemaoised(yes: true).thirdOne.HasRealModerateLeader(yes: true).thirdOne.AddRelations(1, 1000).thirdOne.BlockMarket(13).thirdOne.StartEvent(124).End,
			new Decision(new_texts[127], new_texts[145]).Expr.thirdOne.HasAgents(1500).thirdOne.HasMoney(500).thirdOne.HasMaoismus(yes: true).thirdOne.IsDeadJanataInIndia(yes: true).thirdOne.HasNaxalitsPowerLess(yes: false, 799).thirdOne.AddMoney(-500).thirdOne.AddAgents(-1500).thirdOne.AddRelations(0, -1000).thirdOne.AddChineseInfluence(50).thirdOne.StartEvent(125).End,
			new Decision(new_texts[551], new_texts[556], 2).Expr.thirdOne.HasCommunistLeader(yes: false).thirdOne.HasMaoismus(yes: false).thirdOne.HasCulturalRevolution(yes: false).thirdOne.HasCapitalistEconomy(yes: true).thirdOne.CreateNewLeader(32, 47, 3, 4, 14, 52).thirdOne.AddLiberalization(50).thirdOne.AddSupport(50).thirdOne.AddChineseInfluence(1).End,
			new Decision(new_texts[552], new_texts[557], 2).Expr.thirdOne.HasLeader(32, 47, 3, 4, 14).thirdOne.IsAutoritharian(yes: true).thirdOne.IsTraditional(yes: true).thirdOne.HasAgents(1500).thirdOne.HasArmy(1500).thirdOne.BlockFreedom(16).thirdOne.AddNewModify(38).thirdOne.AddAgents(-1500).thirdOne.AddArmy(-1500).End,
			new Decision(new_texts[553], new_texts[558], 2).Expr.thirdOne.IsYearLess(yes: false, 1981).thirdOne.HasChosenInTheEvent(308, 1, 85).thirdOne.HasAgents(500).thirdOne.HasMoney(500).thirdOne.AddAgents(-500).thirdOne.AddMoney(-500).thirdOne.AddNewModify(39).End,
			new Decision(new_texts[554], new_texts[559], 2).Expr.thirdOne.HasLeftRadicalLeader(yes: true).thirdOne.IsFactionBanned(2).thirdOne.IsFactionBanned(3).thirdOne.IsFactionBanned(4).thirdOne.HasChosenInTheEvent(15, 2, 559).thirdOne.HasSomeoneWonInTheWar(1, 0, 23).thirdOne.HasAgents(500).thirdOne.HasMoney(500).thirdOne.AddAgents(-500).thirdOne.AddMoney(-500).thirdOne.AddNewModify(40).thirdOne.BlockForStatemoncap(18).thirdOne.CreateNewLeader(43, 48, 0, 8, 14, (byte)(1942 - gameState.data[21])).End,
			new Decision(new_texts[555], new_texts[560], 2).Expr.thirdOne.HasChosenInTheEvent(62, 4, 560).thirdOne.ProChinese(9).thirdOne.TheyAreOurs(1).thirdOne.HasAgents(500).thirdOne.HasMoney(500).thirdOne.HasSovietFriendship(yes: true).thirdOne.IsUnityLessThan(yes: false, 700).thirdOne.AddPopulation(20).thirdOne.AddSupport(10).thirdOne.AddChineseInfluence(10).thirdOne.AddAgents(-500).thirdOne.AddMoney(-500).thirdOne.GetMongolia(19).End,
			new Decision(new_texts[577], new_texts[578], 3).Expr.thirdOne.IsOARCreated(yes: true).thirdOne.IsOARfull(yes: true).thirdOne.IsNoWars(yes: true).thirdOne.IsYearLess(yes: false, 1983).thirdOne.IsChineseInfluenceLessThan(yes: false, 800).thirdOne.HasMoney(300).thirdOne.QuelleGosstroy(84, 2, yes: true).thirdOne.HasAgents(300).thirdOne.IsRael(yes: true).thirdOne.AddAgents(-300).thirdOne.AddMoney(-300).thirdOne.CreateBigOAR(yes: true).End,
			new Decision(new_texts[589], new_texts[590], 3).Expr.thirdOne.IsChineseInfluenceLessThan(yes: false, 200).thirdOne.IsChinaWarAliance(yes: true).thirdOne.IsScienceDone(19, yes: true).thirdOne.HasMoney(100).thirdOne.AddMoney(-100).thirdOne.OnAgentModif(yes: true).End,
			new Decision(new_texts[629], new_texts[630], 3).Expr.thirdOne.IsChineseInfluenceLessThan(yes: false, 200).thirdOne.IsChinaWarAliance(yes: true).thirdOne.IsScienceDone(23, yes: true).thirdOne.HasMoney(100).thirdOne.AddMoney(-100).thirdOne.OnArmyModif(yes: true).End,
			new Decision(new_texts[632], new_texts[636], 3).Expr.thirdOne.IsInTheSEATO(yes: true, 1).thirdOne.IsInTheSENTO(yes: true, 8).thirdOne.IsInTheSENTO(yes: true, 31).thirdOne.IsYearLess(yes: false, 1980).thirdOne.HasMoney(300).thirdOne.HasArmy(300).thirdOne.AddMoney(-300).thirdOne.AddArmy(-300).thirdOne.AddChineseInfluence(50).thirdOne.AddAmericanInfluence(50).thirdOne.AddSovietInfluence(-50).thirdOne.AddRelations(1, -250).thirdOne.AddRelations(0, 250).thirdOne.MakeInWPO(yes: true, 9).thirdOne.OnSEATO(yes: true).End,
			new Decision(new_texts[641], new_texts[642], 3).Expr.thirdOne.HasAgents(150).thirdOne.IsScienceDone(25, yes: true).thirdOne.Oncein(24, 6, yes: true).thirdOne.DoTimer(24, 6).thirdOne.AddAgents(-150).thirdOne.AddSovietInfluence(-50).End,
			new Decision(new_texts[645], new_texts[646], 3).Expr.thirdOne.HasAgents(150).thirdOne.IsScienceDone(25, yes: true).thirdOne.Oncein(25, 6, yes: true).thirdOne.AddAgents(-150).thirdOne.DoTimer(25, 6).thirdOne.AddAmericanInfluence(-50).End,
			new Decision(new_texts[647], new_texts[648], 3).Expr.thirdOne.IsInTheWP(yes: true, 1).thirdOne.HasAgents(50).thirdOne.HasArmy(150).thirdOne.HasMoney(50).thirdOne.IsScienceDone(19, yes: true).thirdOne.Oncein(26, 6, yes: true).thirdOne.AddAgents(-50).thirdOne.AddArmy(-150).thirdOne.AddMoney(-50).thirdOne.DoTimer(26, 6).thirdOne.AddSovietInfluence(-10).thirdOne.AddinflAlliance(-350, 1).thirdOne.AddinflAlliance(200, 3).End,
			new Decision(new_texts[653], new_texts[654], 3).Expr.thirdOne.IsInTheSEATO(yes: true, 1).thirdOne.HasAgents(50).thirdOne.HasArmy(150).thirdOne.HasMoney(50).thirdOne.IsScienceDone(19, yes: true).thirdOne.Oncein(27, 6, yes: true).thirdOne.AddAgents(-50).thirdOne.AddArmy(-150).thirdOne.AddMoney(-50).thirdOne.DoTimer(27, 6).thirdOne.AddAmericanInfluence(-10).thirdOne.AddinflAlliance(-350, 2).thirdOne.AddinflAlliance(200, 3).End,
			new Decision(new_texts[655], new_texts[656], 3).Expr.thirdOne.HasAgents(200).thirdOne.HasArmy(250).thirdOne.HasMoney(200).thirdOne.IsScienceDone(20, yes: true).thirdOne.IsScienceDone(24, yes: true).thirdOne.Oncein(28, 6, yes: true).thirdOne.AddAgents(-200).thirdOne.AddArmy(-250).thirdOne.AddMoney(-200).thirdOne.DoTimer(28, 6).thirdOne.AddSovietInfluence(-10).thirdOne.AddAllAfrique(-250, 1).thirdOne.AddAllAfrique(100, 3).thirdOne.AddStabilityAfrique(-100).End,
			new Decision(new_texts[657], new_texts[658], 3).Expr.thirdOne.HasAgents(200).thirdOne.HasArmy(250).thirdOne.HasMoney(200).thirdOne.IsScienceDone(20, yes: true).thirdOne.IsScienceDone(24, yes: true).thirdOne.Oncein(29, 6, yes: true).thirdOne.AddAgents(-200).thirdOne.AddArmy(-250).thirdOne.AddMoney(-200).thirdOne.DoTimer(29, 6).thirdOne.AddAmericanInfluence(-10).thirdOne.AddAllAfrique(-250, 2).thirdOne.AddAllAfrique(100, 3).thirdOne.AddStabilityAfrique(-100).End,
			new Decision(new_texts[667], new_texts[669], 3).Expr.thirdOne.HasMoney(50).thirdOne.Oncein(30, 6, yes: true).thirdOne.AddMoney(-50).thirdOne.DoTimer(30, 6).thirdOne.AddChineseInfluence(-10).thirdOne.AddRelations(0, -150).thirdOne.AddRelations(1, -150).thirdOne.AddDiplo(100).End,
			new Decision(new_texts[670], new_texts[671], 3).Expr.thirdOne.HasMoney(50).thirdOne.Oncein(31, 6, yes: true).thirdOne.AddMoney(-50).thirdOne.DoTimer(31, 6).thirdOne.AddChineseInfluence(-10).thirdOne.AddRelations(0, 150).thirdOne.AddRelations(1, 150).thirdOne.AddDiplo(-100).End,
			new Decision(new_texts[672], new_texts[673], 3).Expr.thirdOne.HasMoney(50).thirdOne.Oncein(32, 6, yes: true).thirdOne.DoTimer(32, 6).thirdOne.AddMoney(-50).thirdOne.IsScienceDone(10, yes: true).thirdOne.HasOil(yes: true).thirdOne.IsIndustry(gameState.data[152], yes: true).thirdOne.AddOilPrud(200).End,
			new Decision(new_texts[678], new_texts[679], 3).Expr.thirdOne.HasMoney(100).thirdOne.IsScienceDone(12, yes: true).thirdOne.AddMoney(-100).thirdOne.HasOil(yes: true).thirdOne.IsIndustry(700, yes: true).thirdOne.HasSovietFriendship(yes: true).thirdOne.IsRealtions(700, 1, yes: true).thirdOne.AddOldModify(58).End,
			new Decision(new_texts[682], new_texts[683], 3).Expr.thirdOne.HasMoney(50).thirdOne.Oncein(34, 6, yes: true).thirdOne.DoTimer(34, 6).thirdOne.IsScienceDone(16, yes: true).thirdOne.AddMoney(-50).thirdOne.HasOil(yes: true).thirdOne.IsIndustry(700, yes: true).thirdOne.HasOilEat(200).thirdOne.AddOilEat(-150).End,
			new Decision(new_texts[688], new_texts[689], 3).Expr.thirdOne.HasMoney(100).thirdOne.HasAgents(100).thirdOne.ISCIA(yes: true).thirdOne.HasSovietFriendship(yes: false).thirdOne.IsYearLess(yes: false, 1983).thirdOne.IsChineseInfluenceLessThan(yes: false, 350).thirdOne.IsScienceDone(10, yes: true).thirdOne.HasOil(yes: true).thirdOne.IsIndustry(700, yes: true).thirdOne.ProChinese(33).thirdOne.AddMoney(-100).thirdOne.AddAgents(-100).thirdOne.AddOilPrice(-10).thirdOne.AddSovietInfluence(-200).thirdOne.AddAmericanInfluence(150).thirdOne.AddChineseInfluence(100).thirdOne.IsScienceDone(10, yes: true).thirdOne.HasOil(yes: true).thirdOne.IsIndustry(700, yes: true).End,
			new Decision(new_texts[703], new_texts[704], 2).Expr.thirdOne.IsMaoDead().thirdOne.StartEvent(443).End,
			new Decision(new_texts[900], new_texts[901], 6).Expr.thirdOne.HasOnePartyMechanic(yes: true).thirdOne.IsLeftRadBanned().thirdOne.IsFactionBanned(4).thirdOne.HasMaoismus(yes: false).thirdOne.HasMoney(50).thirdOne.HasAgents(100).thirdOne.AddMoney(-50).thirdOne.AddAgents(-100).thirdOne.AddRelations(0, -50).thirdOne.AddRelations(1, -100).thirdOne.AddDiplo(100).thirdOne.AddOldModify(66).thirdOne.CreateNewLeader(44, 49, 2, 5, 14, (byte)(1938 - gameState.data[21])).End,
			new Decision(new_texts[908], new_texts[909], 6).Expr.thirdOne.BoughtRomanianLoan(yes: false).thirdOne.IsChineseInfluenceLessThan(yes: false, 400).thirdOne.IsRealtions(800, 1, yes: true).thirdOne.IsRealtions(500, 0, yes: false).thirdOne.IsYearLess(yes: false, 1982).thirdOne.IsYearLess(yes: true, 1985).thirdOne.StartEvent(448).End,
			new Decision(new_texts[910], new_texts[911], 6).Expr.thirdOne.IsWendehalsInPower().thirdOne.HasRedGene().thirdOne.HasSomeoneWonInTheWar(0, 0, 10).thirdOne.HasGorbachev().thirdOne.HasMoney(50).thirdOne.HasAgents(50).thirdOne.AddAgents(-50).thirdOne.AddMoney(-50).thirdOne.MakeDDRasPrussia().End,
			new Decision(new_texts[912], new_texts[913], 6).Expr.thirdOne.ProChineseCountriesInSEV(10).thirdOne.IsInTheSEV(yes: true, 1).thirdOne.IsChineseInfluenceLessThan(yes: false, 600).thirdOne.HasGorbachev().thirdOne.StartEvent(450).End
		};
		if (array != null)
		{
			for (int j = 0; j < array.Length; j++)
			{
				gameState.completedDecisions[j] = array[j];
			}
		}
		else if (gameState.completedDecisions.Length != gameState.decisions.Length)
		{
			gameState.completedDecisions = new bool[gameState.decisions.Length];
		}
	}

	public void MusicReset()
	{
		music[now_playing].UnloadAudioData();
		int num = now_playing;
		if (!get_to_cycle)
		{
			while (now_playing == num)
			{
				if (!zadan_music)
				{
					if (albumNum == 0)
					{
						now_playing = Random.Range(0, 10);
					}
					else if (albumNum == 1)
					{
						now_playing = Random.Range(10, 40);
					}
					else if (albumNum == 2)
					{
						now_playing = Random.Range(40, 61);
					}
					else if (albumNum == 3)
					{
						now_playing = Random.Range(61, 78);
					}
					else
					{
						now_playing = Random.Range(0, 40);
					}
				}
				else
				{
					now_playing = zadan_playing;
					zadan_music = false;
				}
			}
		}
		else if (!zadan_music)
		{
			now_playing = num;
		}
		else
		{
			now_playing = zadan_playing;
			zadan_music = false;
		}
		music[now_playing].LoadAudioData();
		is_ready_to_play = true;
		zadan_music = false;
	}

	public void Init()
	{
		inst = this;
		Application.targetFrameRate = 60;
		NewAwake();
	}

	private void NewAwake()
	{
		if (!PlayerPrefs.HasKey("voice_china"))
		{
			PlayerPrefs.SetInt("voice_china", 5);
		}
		if (PlayerPrefs.HasKey("our_diff_in"))
		{
			inst.gameState.diff = PlayerPrefs.GetInt("our_diff_in");
		}
		if (PlayerPrefs.HasKey("SavePosition"))
		{
			autosavej = PlayerPrefs.GetInt("SavePosition");
		}
		if (PlayerPrefs.HasKey("SavePlaceNum"))
		{
			savePlace = PlayerPrefs.GetInt("SavePlaceNum");
		}
		for (int i = 0; i < inst.gameState.politics.Length; i++)
		{
			inst.gameState.politics[i] = new Politic();
		}
		voice = PlayerPrefs.GetInt("voice_china");
		inst.gameState.turn_on = true;
		Application.targetFrameRate = 60;
		string text = "";
		string[] array = text.Split(':');
		TextAsset textAsset = ((PlayerPrefs.GetInt("language") != 0) ? (Resources.Load("Doctr_ru") as TextAsset) : (Resources.Load("Doctr_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split(';');
		text = null;
		for (int j = 0; j < array.Length; j++)
		{
			inst.gameState.doctr[j] = array[j];
		}
	}

	private void FixedUpdate()
	{
		if (GetComponent<AudioSource>().volume != (float)voice / 100f)
		{
			GetComponent<AudioSource>().volume = (float)voice / 100f;
		}
		if (music[now_playing].loadState == AudioDataLoadState.Failed)
		{
			MusicReset();
		}
		else if (is_ready_to_play && music[now_playing].loadState == AudioDataLoadState.Loaded)
		{
			is_ready_to_play = false;
			GetComponent<AudioSource>().PlayOneShot(music[now_playing]);
		}
		else if (!is_ready_to_play && !GetComponent<AudioSource>().isPlaying)
		{
			MusicReset();
		}
	}
}
