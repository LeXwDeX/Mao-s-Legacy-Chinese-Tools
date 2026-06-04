using System;
using System.Linq;
using MoonSharp.Interpreter;
using UnityEngine.SceneManagement;

namespace KGEvent;

[Serializable]
[MoonSharpUserData]
public class QueryDecisions<T> where T : IRequesting<T>
{
	private T target;

	public QueryDecisions(T target)
	{
		this.target = target;
	}

	public T TheyAreOurs(int country)
	{
		Func<bool> func = () => (GlobalScript.inst.gameState.allcountries[country].okb && GlobalScript.inst.gameState.allcountries[country].econ) || (GlobalScript.inst.gameState.allcountries[country].isSEV && GlobalScript.inst.gameState.allcountries[country].isOVD && GlobalScript.inst.gameState.allcountries[1].isOVD) || (GlobalScript.inst.gameState.allcountries[country].isSEATO && GlobalScript.inst.gameState.allcountries[1].isSEATO);
		if (country != 1)
		{
			ref T reference = ref target;
			string text = string.Format("{0} {1}: <color={2}>{3}</color>", GlobalScript.inst.gameState.allcountries[country].name, GlobalScript.inst.new_texts[99], func() ? "lime" : "red", func() ? "✔" : "☓");
			reference.AddReq(text);
		}
		else
		{
			ref T reference2 = ref target;
			string text2 = string.Format("{1}: <color={2}>{3}</color>", GlobalScript.inst.gameState.allcountries[country].name, GlobalScript.inst.new_texts[330], func() ? "lime" : "red", func() ? "✔" : "☓");
			reference2.AddReq(text2);
		}
		return target.CreateCondition(func);
	}

	public T ProChinese(int country)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.allcountries[country].proprc;
		ref T reference = ref target;
		string text = string.Format("{0} {1}: <color={2}>{3}</color>", GlobalScript.inst.gameState.allcountries[country].name, GlobalScript.inst.new_texts[100], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T TibetIsOurs(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[67] > 0) : (GlobalScript.inst.gameState.data[67] <= 0);
		ref T reference = ref target;
		string text = string.Format("{1} {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[101], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T UyghurIsOurs(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[66] > 0) : (GlobalScript.inst.gameState.data[66] <= 0);
		ref T reference = ref target;
		string text = string.Format("{1} {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[102], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasAgents(int num)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.data[9] >= num;
		ref T reference = ref target;
		string text = string.Format("{1} - {0:F1}: <color={2}>{3}</color>", (float)num / 10f, GlobalScript.inst.new_texts[149], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasMoney(int num)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= num;
		ref T reference = ref target;
		string text = string.Format("{1} - {0:F1}: <color={2}>{3}</color>", (float)num / 10f, GlobalScript.inst.new_texts[150], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasRedGene()
	{
		Func<bool> func = () => GlobalScript.inst.gameState.modifies[66].active;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[1020], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasArmy(int num)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.data[22] >= num;
		ref T reference = ref target;
		string text = string.Format("{1} - {0:F1}: <color={2}>{3}</color>", (float)num / 10f, GlobalScript.inst.new_texts[155], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasSomeoneWonInTheWar(int war, int side, int country)
	{
		Func<bool> func = () => (side != 0) ? (GlobalScript.inst.gameState.ingamewars[war].infl2 >= 900) : (GlobalScript.inst.gameState.ingamewars[war].infl1 >= 900);
		ref T reference = ref target;
		string text = string.Format("{0} {1} {2}: <color={3}</color>", GlobalScript.inst.gameState.ingamewars[war].name_war, GlobalScript.inst.new_texts[329], GlobalScript.inst.gameState.allcountries[country].name, func() ? "lime>✔" : "red>☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsUnitarism(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[18] != 20) : (GlobalScript.inst.gameState.data[18] == 20);
		ref T reference = ref target;
		string text = string.Format("{1} {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[151], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasMonarchyInCountry(bool yes, int country)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.allcountries[country].isMonatchy) : GlobalScript.inst.gameState.allcountries[country].isMonatchy;
		ref T reference = ref target;
		string text = string.Format("{1} {4} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[1028], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsLiberal(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (!GlobalScript.inst.gameState.IsFactionLeadeng(4))
				{
					if (GlobalScript.inst.gameState.data[52] >= 36)
					{
						return GlobalScript.inst.gameState.data[54] < 40;
					}
					return true;
				}
				return false;
			}
			return GlobalScript.inst.gameState.IsFactionLeadeng(4) || (GlobalScript.inst.gameState.data[52] >= 36 && GlobalScript.inst.gameState.data[54] >= 40);
		};
		ref T reference = ref target;
		string text = string.Format("{1} {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[152], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsAutoritharian(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (!GlobalScript.inst.gameState.IsFactionLeadeng(0) && !GlobalScript.inst.gameState.IsFactionLeadeng(3))
				{
					if (GlobalScript.inst.gameState.data[15] >= 8)
					{
						return GlobalScript.inst.gameState.data[54] > 38;
					}
					return true;
				}
				return false;
			}
			return GlobalScript.inst.gameState.IsFactionLeadeng(0) || GlobalScript.inst.gameState.IsFactionLeadeng(3) || (GlobalScript.inst.gameState.data[15] >= 8 && GlobalScript.inst.gameState.data[54] <= 38);
		};
		ref T reference = ref target;
		string text = string.Format("{1} {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[153], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsTraditional(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[15] < 28) : (GlobalScript.inst.gameState.data[50] >= 28);
		ref T reference = ref target;
		string text = string.Format("{1} {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[562], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsRadicalTradition(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (GlobalScript.inst.gameState.data[50] > 24)
				{
					return GlobalScript.inst.gameState.data[50] < 29;
				}
				return false;
			}
			return GlobalScript.inst.gameState.data[50] <= 24 || GlobalScript.inst.gameState.data[50] >= 29;
		};
		ref T reference = ref target;
		string text = string.Format("{1} {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[154], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsPartyEnabled(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.is_party_enabled[num]) : GlobalScript.inst.gameState.is_party_enabled[num];
		ref T reference = ref target;
		string text = string.Format("{1} {4} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[156], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.new_texts[191 + num]);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasOnePartyMechanic(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[15] <= 7) : (GlobalScript.inst.gameState.data[15] <= 7);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[157], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsMaoDead()
	{
		Func<bool> func = () => GlobalScript.inst.gameState.data[38] == 100;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[716], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T BoughtRomanianLoan(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (GlobalScript.inst.gameState.resultOfEvents[79] != 2)
				{
					return GlobalScript.inst.gameState.event_done[79];
				}
				return false;
			}
			return GlobalScript.inst.gameState.resultOfEvents[79] == 2 && GlobalScript.inst.gameState.event_done[79];
		};
		ref T reference = ref target;
		string text = string.Format("{0}{3}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[914], func() ? "lime" : "red", func() ? "✔" : "☓", " - " + GlobalScript.inst.new_texts[112]);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsWendehalsInPower()
	{
		Func<bool> func = () => GlobalScript.inst.gameState.resultOfEvents[456] == 1;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[915], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T ProChineseCountriesInSEV(int number)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.allcountries.Where((Country c) => c.isSEV && c.proprc).Count() >= 10;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", string.Format(GlobalScript.inst.new_texts[916], number), func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T AllLeadersAreDead()
	{
		int banda_4 = 0;
		Politic[] politics = GlobalScript.inst.gameState.politics;
		foreach (Politic politic in politics)
		{
			if (politic != null)
			{
				if (politic.traits[0] == 0 && (((politic.name_1 == 0) & (politic.name_2 == 0)) || ((politic.name_1 == 3) & (politic.name_2 == 3)) || (politic.name_1 == 4 && politic.name_2 == 4) || (politic.name_1 == 5 && politic.name_2 == 5)))
				{
					banda_4++;
				}
				else if (politic.name_1 == 2 && politic.name_2 == 2)
				{
					banda_4++;
				}
				else if (politic.name_1 == 13 && politic.name_2 == 13)
				{
					banda_4++;
				}
			}
		}
		Func<bool> func = () => banda_4 <= 0;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[158], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsPoliticianAlive(int name1, int name2, int trait0, int trait1, int trait2)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.FindPerson(name1, name2, trait0, trait1, trait2) >= 0;
		ref T reference = ref target;
		string text = string.Format("{3} {4} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[225], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.names1[name1], GlobalScript.inst.gameState.names2[name2]);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasAutonomyForMacao(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[65] != 1) : (GlobalScript.inst.gameState.data[65] == 1);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[159], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasAnnexedMacao(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[65] != 2) : (GlobalScript.inst.gameState.data[65] == 2);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[166], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsTaiwanAttacked(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.allcountries[38].dev == 0) : (GlobalScript.inst.gameState.allcountries[38].dev != 0);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[160], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsInTheOVD(bool yes, int country)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.allcountries[country].isOVD) : GlobalScript.inst.gameState.allcountries[country].isOVD;
		ref T reference = ref target;
		string text = string.Format("{4} {1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[112] : GlobalScript.inst.new_texts[111], GlobalScript.inst.new_texts[161], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsInTheSEV(bool yes, int country)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.allcountries[country].isSEV) : GlobalScript.inst.gameState.allcountries[country].isSEV;
		ref T reference = ref target;
		string text = string.Format("{4} {1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[112] : GlobalScript.inst.new_texts[111], GlobalScript.inst.new_texts[162], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsInTheASEAN(bool yes, int country)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.allcountries[country].isASEAN) : GlobalScript.inst.gameState.allcountries[country].isASEAN;
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[639], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsInTheWP(bool yes, int country)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.allcountries[country].isOVD) : GlobalScript.inst.gameState.allcountries[country].isOVD;
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[649], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsInTheSEATO(bool yes, int country)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.allcountries[country].isSEATO) : GlobalScript.inst.gameState.allcountries[country].isSEATO;
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[638], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsInTheSENTO(bool yes, int country)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.allcountries[country].isSENTO) : GlobalScript.inst.gameState.allcountries[country].isSENTO;
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[640], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasCulturalRevolution(bool yes)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.modifies[3].active) : GlobalScript.inst.gameState.modifies[3].active;
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[163], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasOil(bool yes)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.modifies[51].active) : GlobalScript.inst.gameState.modifies[51].active;
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[674], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasMaoismus(bool yes)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.modifies[6].active) : GlobalScript.inst.gameState.modifies[6].active;
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[164], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsDipRepLessThan(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[6] > num) : (GlobalScript.inst.gameState.data[6] < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4:F1}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[165], func() ? "lime" : "red", func() ? "✔" : "☓", (float)num / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsUnityLessThan(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[57] >= num) : (GlobalScript.inst.gameState.data[57] < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4:F1}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[568], func() ? "lime" : "red", func() ? "✔" : "☓", (float)num / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsAmericanInfluenceLessThan(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.empires[0].power > num) : (GlobalScript.inst.gameState.empires[0].power < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4:F1}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[167], func() ? "lime" : "red", func() ? "✔" : "☓", (float)num / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsSovietInfluenceLessThan(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.empires[1].power > num) : (GlobalScript.inst.gameState.empires[1].power < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4:F1}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[168], func() ? "lime" : "red", func() ? "✔" : "☓", (float)num / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsChineseInfluenceLessThan(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.influencePRC > num) : (GlobalScript.inst.gameState.influencePRC < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4:F1}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[169], func() ? "lime" : "red", func() ? "✔" : "☓", (float)num / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsChiSovInfluenceLessThan(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.influencePRC + (GlobalScript.inst.gameState.allcountries[1].isOVD ? GlobalScript.inst.gameState.empires[1].power : 0) > num) : (GlobalScript.inst.gameState.influencePRC + (GlobalScript.inst.gameState.allcountries[1].isOVD ? GlobalScript.inst.gameState.empires[1].power : 0) < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4:F1}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[331], func() ? "lime" : "red", func() ? "✔" : "☓", (float)num / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasAgressiveMilitaryDoctrine(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[51] <= 31) : (GlobalScript.inst.gameState.data[51] <= 31);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[170], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasLeader(int name1, int name2, int trait0, int trait1, int trait2)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.leader.traits[2] == trait2 && GlobalScript.inst.gameState.leader.traits[1] == trait1 && GlobalScript.inst.gameState.leader.traits[0] == trait0 && GlobalScript.inst.gameState.leader.name_2 == name2 && GlobalScript.inst.gameState.leader.name_1 == name1;
		ref T reference = ref target;
		string text = string.Format("{0} - {1} {4}: <color={2}>{3}</color>", GlobalScript.inst.new_texts[561], GlobalScript.inst.gameState.names1[name1], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.names2[name2]);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasLeftRadicalLeader(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.leader.traits[0] != 0) : (GlobalScript.inst.gameState.leader.traits[0] == 0);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[171], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsMaoPraised(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (GlobalScript.inst.gameState.event_done[39] && GlobalScript.inst.gameState.modifies[6].active)
				{
					return GlobalScript.inst.gameState.data[90] != 0;
				}
				return true;
			}
			return GlobalScript.inst.gameState.event_done[39] && GlobalScript.inst.gameState.data[90] == 0 && GlobalScript.inst.gameState.modifies[6].active;
		};
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[172], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsNotAntiMaoInTheUSSR()
	{
		Func<bool> func = () => GlobalScript.inst.gameState.empires[1].now_leader != 6 && GlobalScript.inst.gameState.empires[1].now_leader != 5;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[173], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasCommunistLeader(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (GlobalScript.inst.gameState.leader.traits[0] != 0)
				{
					return GlobalScript.inst.gameState.leader.traits[0] != 1;
				}
				return false;
			}
			return GlobalScript.inst.gameState.leader.traits[0] == 0 || GlobalScript.inst.gameState.leader.traits[0] == 1;
		};
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[174], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasSovietFriendship(bool yes)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.relres) : GlobalScript.inst.gameState.relres;
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[175], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasEuropeansPuppets()
	{
		Func<bool> func = () => GlobalScript.inst.gameState.allcountries[2].proprc && GlobalScript.inst.gameState.allcountries[5].proprc && !GlobalScript.inst.gameState.allcountries[4].prosov;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[176], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasGorbachev()
	{
		Func<bool> func = () => GlobalScript.inst.gameState.empires[1].now_leader == 6 || GlobalScript.inst.gameState.empires[1].now_leader == 8;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[177], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsYearLess(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[21] > num) : (GlobalScript.inst.gameState.data[21] < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[178], func() ? "lime" : "red", func() ? "✔" : "☓", num);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasOngoingWar(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? GlobalScript.inst.gameState.ingamewars[num].is_going : GlobalScript.inst.gameState.ingamewars[num].is_going;
		ref T reference = ref target;
		string text = string.Format("{1} \"{4}\" - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[179], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.gameState.ingamewars[num].name_war);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasChosenInTheEvent(int eventNum, int answerNum, int name)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.resultOfEvents[eventNum] == answerNum;
		ref T reference = ref target;
		string text = string.Format("\"{0}\" - {1} {2}: <color={3}>{4}</color>", GlobalScript.inst.new_events_text[name], GlobalScript.inst.new_texts[565], answerNum + 1, func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasModerateFaction(bool yes)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.IsFactionLeadeng(2)) : GlobalScript.inst.gameState.IsFactionLeadeng(2);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[180], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasRealModerateLeader(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.leader.traits[0] != 1) : (GlobalScript.inst.gameState.leader.traits[0] == 1);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[186], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasModerateLeader(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (GlobalScript.inst.gameState.leader.traits[0] != 1)
				{
					return GlobalScript.inst.gameState.leader.traits[0] != 2;
				}
				return false;
			}
			return GlobalScript.inst.gameState.leader.traits[0] == 1 || GlobalScript.inst.gameState.leader.traits[0] == 2;
		};
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[181], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsLeftRadBanned()
	{
		Func<bool> func = () => !GlobalScript.inst.gameState.is_party_enabled[0];
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[182], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsLeftRadLessThenPercent(int percent)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.GetPercentOfFaction(0) * 100f < (float)percent;
		ref T reference = ref target;
		string text = string.Format("{0} < {3}%: <color={1}>{2}</color>", GlobalScript.inst.new_texts[191], func() ? "lime" : "red", func() ? "✔" : "☓", percent);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsFactionBanned(int num)
	{
		Func<bool> func = () => !GlobalScript.inst.gameState.is_party_enabled[num];
		ref T reference = ref target;
		string text = string.Format("{0} - {1}: <color={2}>{3}</color>", GlobalScript.inst.new_texts[566], GlobalScript.inst.new_texts[num + 324], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasCapitalistEconomy(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[16] <= 13) : (GlobalScript.inst.gameState.data[16] > 13);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[183], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasOligarchyPowerLess(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[108] > num) : (GlobalScript.inst.gameState.data[108] < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4:F1}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[184], func() ? "lime" : "red", func() ? "✔" : "☓", num);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsMaoDemaoised(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (!GlobalScript.inst.gameState.modifies[6].active)
				{
					return GlobalScript.inst.gameState.data[90] != 2;
				}
				return true;
			}
			return !GlobalScript.inst.gameState.modifies[6].active && GlobalScript.inst.gameState.data[90] == 2;
		};
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[185], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsDeadJanataInIndia(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (GlobalScript.inst.gameState.data[91] == 1)
				{
					return !GlobalScript.inst.gameState.allcountries[19].prosov;
				}
				return true;
			}
			return GlobalScript.inst.gameState.data[91] == 1 && GlobalScript.inst.gameState.allcountries[19].prosov;
		};
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[187], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T HasNaxalitsPowerLess(bool yes, int num)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[32] > num) : (GlobalScript.inst.gameState.data[32] < num);
		ref T reference = ref target;
		string text = string.Format("{1} {0} {4:F1}: <color={2}>{3}</color>", yes ? "≺" : "≻", GlobalScript.inst.new_texts[188], func() ? "lime" : "red", func() ? "✔" : "☓", (float)num / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T StartEvent(int num)
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[189]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.number_event = num;
			SceneManager.LoadScene("Event");
		};
		return reference2.CreateActive(active);
	}

	public T MakeDDRasPrussia()
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[1019]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[16].Gosstroy = 0;
			GlobalScript.inst.gameState.allcountries[16].SubGosstroy = 10;
			GlobalScript.inst.gameState.allcountries[16].isMonatchy = true;
		};
		return reference2.CreateActive(active);
	}

	public T AddAgents(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[149], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[9] += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddArmy(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[155], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[22] += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddOilPrice(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1}$</color> ({4})", GlobalScript.inst.new_texts[690], (GlobalScript.inst.gameState.data[143] + num > 10) ? (GlobalScript.inst.gameState.data[143] + num) : 10, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "", GlobalScript.inst.new_texts[691]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			if (GlobalScript.inst.gameState.data[143] + num >= 10)
			{
				GlobalScript.inst.gameState.data[143] += num;
			}
			else
			{
				GlobalScript.inst.gameState.data[143] = 10;
			}
		};
		return reference2.CreateActive(active);
	}

	public T AddLoyalityToAllPoliticiansInTheFaction(int faction, int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0} {4}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[190], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "", GlobalScript.inst.new_texts[191 + faction]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic != null && politic.traits[0] == faction)
				{
					politic.loyality += num;
				}
			}
		};
		return reference2.CreateActive(active);
	}

	public T AddRelations(int power, int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0} {4}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[195], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "", GlobalScript.inst.new_texts[32 + power]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[power].relations += num;
		};
		return reference2.CreateActive(active);
	}

	public T TibetMustStay(int num)
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[196]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T AddChineseInfluence(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[197], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.influencePRC += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddOilPrud(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1}</color> ({4} {5})", GlobalScript.inst.new_texts[676], num, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "", GlobalScript.inst.new_texts[677], GlobalScript.inst.gameState.OilProd + (float)num);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.OilProd += num;
			if (GlobalScript.inst.gameState.data[152] < 1000)
			{
				GlobalScript.inst.gameState.data[152] += 50;
				if (GlobalScript.inst.gameState.data[152] > 1000)
				{
					GlobalScript.inst.gameState.data[152] = 950;
				}
			}
		};
		return reference2.CreateActive(active);
	}

	public T AddOilEat(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1}</color> ({4} {5})", GlobalScript.inst.new_texts[684], num, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "", GlobalScript.inst.new_texts[685], (GlobalScript.inst.gameState.OilEat + (float)num > 200f) ? (GlobalScript.inst.gameState.OilEat + (float)num) : 200f);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			if (GlobalScript.inst.gameState.OilEat > 200f)
			{
				GlobalScript.inst.gameState.OilEat += num;
			}
			else
			{
				GlobalScript.inst.gameState.OilEat = 200f;
			}
		};
		return reference2.CreateActive(active);
	}

	public T HasOilEat(int num)
	{
		Func<bool> func = () => GlobalScript.inst.gameState.OilEat >= (float)num;
		ref T reference = ref target;
		string text = string.Format("{1} {0}: <color={2}>{3}</color>", num, GlobalScript.inst.new_texts[686], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T AddMoney(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[198], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[8] += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddDiplo(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[668], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[6] += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddNationalism(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[199], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[31] += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddPopulation(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[200], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[34] += num;
		};
		return reference2.CreateActive(active);
	}

	public T UyghurMustStay(int num)
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[201]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T MakeProChinese(bool yes, int country)
	{
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[202], yes ? "lime" : "red", yes ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].proprc = yes;
		};
		return reference2.CreateActive(active);
	}

	public T ChangeBotSystem(int num, int country)
	{
		ref T reference = ref target;
		string text = string.Format("{2} {0}: <color={1}>{3}</color>", GlobalScript.inst.new_texts[203], "lime", GlobalScript.inst.gameState.allcountries[country].name, GlobalScript.inst.new_texts[204 + num]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].Gosstroy = num;
		};
		return reference2.CreateActive(active);
	}

	public T MakeProUSA(bool yes, int country)
	{
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[208], yes ? "lime" : "red", yes ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].Vyshi = yes;
		};
		return reference2.CreateActive(active);
	}

	public T MakeProSoviet(bool yes, int country)
	{
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[209], yes ? "lime" : "red", yes ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].prosov = yes;
		};
		return reference2.CreateActive(active);
	}

	public T AnnexationInfo(int num, int annexed, int country_by)
	{
		ref T reference = ref target;
		string text = string.Format("<color=lime>{1} {0} {2}</color>", GlobalScript.inst.new_texts[210], GlobalScript.inst.gameState.allcountries[annexed].name, GlobalScript.inst.gameState.allcountries[country_by].name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T AddLiberalization(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[211], (float)num / 10f, (num > 0) ? "red" : "lime", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[4] += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddPowerToAllPoliticiansInTheFaction(int faction, int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0} {4}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[212], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "", GlobalScript.inst.new_texts[191 + faction]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic != null && politic.traits[0] == faction)
				{
					politic.power += num;
				}
			}
		};
		return reference2.CreateActive(active);
	}

	public T MaoismIsBetter(int num)
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[213]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T MakeInWPO(bool yes, int country)
	{
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[214], yes ? "lime" : "red", yes ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].isOVD = yes;
		};
		return reference2.CreateActive(active);
	}

	public T MakeInSEV(bool yes, int country)
	{
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[215], yes ? "lime" : "red", yes ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].isSEV = yes;
		};
		return reference2.CreateActive(active);
	}

	public T MakeInOKB(bool yes, int country)
	{
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[216], yes ? "lime" : "red", yes ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].okb = yes;
		};
		return reference2.CreateActive(active);
	}

	public T MakeInEcon(bool yes, int country)
	{
		ref T reference = ref target;
		string text = string.Format("{3} {0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[217], yes ? "lime" : "red", yes ? "✔" : "☓", GlobalScript.inst.gameState.allcountries[country].name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].econ = yes;
		};
		return reference2.CreateActive(active);
	}

	public T AddAmericanInfluence(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[218], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[0].power += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddSovietInfluence(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[219], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[1].power += num;
		};
		return reference2.CreateActive(active);
	}

	public T MaoismSOVIsBetter(int num)
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[220]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T LeaveTheWar(int war, int power)
	{
		ref T reference = ref target;
		string text = string.Format("<color=lime>{1} {0} \"{2}\"</color>", GlobalScript.inst.new_texts[221], GlobalScript.inst.new_texts[32 + power], GlobalScript.inst.gameState.ingamewars[war].name_war);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			if (power == 0)
			{
				GlobalScript.inst.gameState.ingamewars[war].usa_place = -1;
			}
			else if (power == 1)
			{
				GlobalScript.inst.gameState.ingamewars[war].ussr_place = -1;
			}
		};
		return reference2.CreateActive(active);
	}

	public T AddSupport(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[222], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[3] += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddStandardOfLiving(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[223], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[5] += num;
		};
		return reference2.CreateActive(active);
	}

	public T KillTheLeaderOfTheFaction(int num)
	{
		ref T reference = ref target;
		string text = $"<color=red>{GlobalScript.inst.new_texts[224]} {GlobalScript.inst.new_texts[324 + num]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			if (GlobalScript.inst.gameState.faction_leader[num] < 100)
			{
				GlobalScript.inst.gameState.KillPerson(GlobalScript.inst.gameState.faction_leader[num]);
			}
		};
		return reference2.CreateActive(active);
	}

	public T AgreeToOligarchy(int num)
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[226]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T BlockMarket(int num)
	{
		ref T reference = ref target;
		string text = $"<color=red>{GlobalScript.inst.new_texts[227]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T AddNewModify(int num)
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[564]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.modifies[num].active = true;
		};
		return reference2.CreateActive(active);
	}

	public T AddOldModify(int num)
	{
		ref T reference = ref target;
		string text = $"<color=lime>{GlobalScript.inst.new_texts[564]} «{GlobalScript.inst.old_modify_texts[num]}»</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.modifies[num].active = true;
			if (num == 58)
			{
				GlobalScript.inst.gameState.data[153] = 12;
			}
		};
		return reference2.CreateActive(active);
	}

	public T BlockFreedom(int num)
	{
		ref T reference = ref target;
		string text = $"<color=red>{GlobalScript.inst.new_texts[563]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T BlockForStatemoncap(int num)
	{
		ref T reference = ref target;
		string text = $"<color=red>{GlobalScript.inst.new_texts[567]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[16] = 12;
		};
		return reference2.CreateActive(active);
	}

	public T GetMongolia(int num)
	{
		ref T reference = ref target;
		string text = $"<color=red>{GlobalScript.inst.new_texts[569]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.completedDecisions[num] = true;
		};
		return reference2.CreateActive(active);
	}

	public T ChangeSpecialEndingForTheCountry(int country, int num)
	{
		ref T reference = ref target;
		string text = $"<color=red>{GlobalScript.inst.new_texts[268]}</color>";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[country].numberOfSpecialEnding = num;
		};
		return reference2.CreateActive(active);
	}

	public T MakeHimLeader(int name1, int name2, int trait0, int trait1, int trait2)
	{
		ref T reference = ref target;
		string text = string.Format("<color=lime>{1} {2} {0}</color>", GlobalScript.inst.new_texts[228], GlobalScript.inst.gameState.names1[name1], GlobalScript.inst.gameState.names2[name2]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.MakeNewLeader(GlobalScript.inst.gameState.FindPerson(name1, name2, trait0, trait1, trait2));
		};
		return reference2.CreateActive(active);
	}

	public T CreateNewLeader(byte name1, byte name2, byte trait0, byte trait1, byte trait2, byte age)
	{
		ref T reference = ref target;
		string text = string.Format("<color=lime>{1} {2} {0}</color>", GlobalScript.inst.new_texts[228], GlobalScript.inst.gameState.names1[name1], GlobalScript.inst.gameState.names2[name2]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.leader.name_1 = name1;
			GlobalScript.inst.gameState.leader.name_2 = name2;
			GlobalScript.inst.gameState.leader.traits[0] = trait0;
			GlobalScript.inst.gameState.leader.traits[1] = trait1;
			GlobalScript.inst.gameState.leader.traits[2] = trait2;
			GlobalScript.inst.gameState.leader.age = age;
		};
		return reference2.CreateActive(active);
	}

	public T AddNaxalitPower(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[332], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[32] += num;
		};
		return reference2.CreateActive(active);
	}

	public T IsOARCreated(bool yes)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.OAR) : GlobalScript.inst.gameState.OAR;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[579], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsOARfull(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (GlobalScript.inst.gameState.allcountries[30].oar && GlobalScript.inst.gameState.allcountries[14].oar && GlobalScript.inst.gameState.allcountries[35].oar && GlobalScript.inst.gameState.allcountries[40].oar)
				{
					return !GlobalScript.inst.gameState.allcountries[13].oar;
				}
				return true;
			}
			return GlobalScript.inst.gameState.allcountries[30].oar && GlobalScript.inst.gameState.allcountries[14].oar && GlobalScript.inst.gameState.allcountries[35].oar && GlobalScript.inst.gameState.allcountries[40].oar && GlobalScript.inst.gameState.allcountries[13].oar;
		};
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[580], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T QuelleGosstroy(int country, int gos, bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.allcountries[country].Gosstroy != gos) : (GlobalScript.inst.gameState.allcountries[country].Gosstroy == gos);
		ref T reference = ref target;
		string text = string.Format("{0} {1} - {2}: <color={3}>{4}</color>", GlobalScript.inst.new_texts[585], GlobalScript.inst.gameState.allcountries[country].name, GlobalScript.inst.new_texts[581 + gos], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsRael(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (!GlobalScript.inst.gameState.allcountries[37].Vyshi)
				{
					return !GlobalScript.inst.gameState.allcountries[37].proprc;
				}
				return true;
			}
			return !GlobalScript.inst.gameState.allcountries[37].Vyshi && GlobalScript.inst.gameState.allcountries[37].proprc;
		};
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[588], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsNoWars(bool yes)
	{
		Func<bool> func = delegate
		{
			if (!yes)
			{
				if (!GlobalScript.inst.gameState.ingamewars[3].is_going && !GlobalScript.inst.gameState.ingamewars[4].is_going && !GlobalScript.inst.gameState.ingamewars[8].is_going)
				{
					return GlobalScript.inst.gameState.ingamewars[9].is_going;
				}
				return true;
			}
			return !GlobalScript.inst.gameState.ingamewars[3].is_going && !GlobalScript.inst.gameState.ingamewars[4].is_going && !GlobalScript.inst.gameState.ingamewars[8].is_going && !GlobalScript.inst.gameState.ingamewars[9].is_going;
		};
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[586], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T CreateBigOAR(bool yes)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[587]}";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			for (int i = 0; i < 41; i++)
			{
				if (i == 14 || i == 13 || i == 30 || i == 35 || i == 40)
				{
					GlobalScript.inst.gameState.allcountries[i].prosov = false;
					GlobalScript.inst.gameState.allcountries[i].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[i].proprc = false;
					GlobalScript.inst.gameState.allcountries[i].isSEV = false;
					GlobalScript.inst.gameState.allcountries[i].isOVD = false;
					GlobalScript.inst.gameState.allcountries[i].okb = false;
					GlobalScript.inst.gameState.allcountries[i].econ = false;
					GlobalScript.inst.gameState.allcountries[i].Torg = false;
					GlobalScript.inst.gameState.allcountries[i].oar = false;
				}
			}
			if (GlobalScript.inst.gameState.allcountries[14].parts[4])
			{
				GlobalScript.inst.gameState.allcountries[14].parts[4] = false;
				GlobalScript.inst.gameState.allcountries[30].parts[1] = true;
			}
			else
			{
				GlobalScript.inst.gameState.allcountries[30].parts[0] = true;
			}
			GlobalScript.inst.gameState.allcountries[30].Torg = true;
			GlobalScript.inst.gameState.allcountries[30].proprc = true;
			GlobalScript.inst.gameState.allcountries[30].name = GlobalScript.inst.other_text[6];
			GlobalScript.inst.gameState.allcountries[30].Gosstroy = 2;
			GlobalScript.inst.gameState.allcountries[30].SubGosstroy = 3;
			GlobalScript.inst.gameState.modifies[46].active = true;
			if (GlobalScript.inst.gameState.allcountries[1].okb)
			{
				GlobalScript.inst.gameState.allcountries[30].okb = true;
				GlobalScript.inst.gameState.allcountries[30].econ = true;
			}
			else if (GlobalScript.inst.gameState.allcountries[1].isOVD)
			{
				GlobalScript.inst.gameState.allcountries[30].isOVD = true;
				GlobalScript.inst.gameState.allcountries[30].isSEV = true;
			}
			else if (GlobalScript.inst.gameState.allcountries[1].isSEV)
			{
				GlobalScript.inst.gameState.allcountries[30].isSEV = true;
			}
			else if (GlobalScript.inst.gameState.allcountries[1].econ)
			{
				GlobalScript.inst.gameState.allcountries[30].econ = true;
			}
		};
		return reference2.CreateActive(active);
	}

	public T IsChinaWarAliance(bool yes)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.allcountries[1].okb) : GlobalScript.inst.gameState.allcountries[1].okb;
		ref T reference = ref target;
		string text = string.Format("{0}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[591], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T OnAgentModif(bool yes)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[592]}";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.modifies[47].active = true;
		};
		return reference2.CreateActive(active);
	}

	public T OnArmyModif(bool yes)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[631]}";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.modifies[48].active = true;
		};
		return reference2.CreateActive(active);
	}

	public T OnSEATO(bool yes)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[637]}";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[51].cw = true;
			for (int i = 0; i < GlobalScript.inst.gameState.allcountries.Length; i++)
			{
				if (GlobalScript.inst.gameState.allcountries[i].isSENTO)
				{
					GlobalScript.inst.gameState.allcountries[i].LeaveSENTO().JoinASEAN();
				}
			}
		};
		return reference2.CreateActive(active);
	}

	public T ISCIA(bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.allcountries[51].dev <= 0) : (GlobalScript.inst.gameState.allcountries[51].dev > 0);
		ref T reference = ref target;
		string text = string.Format("{1} - {0}: <color={2}>{3}</color>", yes ? GlobalScript.inst.new_texts[111] : GlobalScript.inst.new_texts[112], GlobalScript.inst.new_texts[687], func() ? "lime" : "red", func() ? "✔" : "☓");
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsScienceDone(int cock, bool yes)
	{
		Func<bool> func = () => (!yes) ? (!GlobalScript.inst.gameState.science[cock]) : GlobalScript.inst.gameState.science[cock];
		ref T reference = ref target;
		string text = string.Format("{0} «{3}» {4}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[627], func() ? "lime" : "red", func() ? "✔" : "☓", GlobalScript.inst.new_texts[593 + cock], GlobalScript.inst.new_texts[628]);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsIndustry(int how, bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.data[12] < how) : (GlobalScript.inst.gameState.data[12] >= how);
		ref T reference = ref target;
		string text = string.Format("{0} {3}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[675], func() ? "lime" : "red", func() ? "✔" : "☓", (float)how / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T IsRealtions(int how, int empire, bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.empires[empire].relations < how) : (GlobalScript.inst.gameState.empires[empire].relations >= how);
		ref T reference = ref target;
		string text = string.Format("{0} {3}: <color={1}>{2}</color>", yes ? GlobalScript.inst.new_texts[680 + empire] : GlobalScript.inst.new_texts[1033 + empire], func() ? "lime" : "red", func() ? "✔" : "☓", (float)how / 10f);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T Oncein(int cock, int month, bool yes)
	{
		Func<bool> func = () => (!yes) ? (GlobalScript.inst.gameState.desnull[cock] > 0) : (GlobalScript.inst.gameState.desnull[cock] <= 0);
		ref T reference = ref target;
		string text = string.Format("{0} {3} {4}: <color={1}>{2}</color>", GlobalScript.inst.new_texts[643], func() ? "lime" : "red", func() ? "✔" : "☓", month, GlobalScript.inst.new_texts[644]);
		reference.AddReq(text);
		return target.CreateCondition(func);
	}

	public T DoTimer(int cock, int month)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[664]} {month} {GlobalScript.inst.new_texts[665]}";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.desnull[cock] = month;
		};
		return reference2.CreateActive(active);
	}

	public T AddinflAlliance(int num, int cum)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[649 + cum], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			if (cum == 1)
			{
				for (int i = 0; i < GlobalScript.inst.gameState.allcountries.Length; i++)
				{
					if (GlobalScript.inst.gameState.allcountries[i].isOVD && (i == 8 || i == 11 || i == 14 || i == 12 || i == 31 || i == 32 || i == 22 || i == 33 || i == 37 || i == 43 || i == 42 || i == 23 || i == 35 || i == 96 || i == 97 || i == 98 || i == 95 || i == 49 || i == 50))
					{
						GlobalScript.inst.gameState.allcountries[i].sovinfl += num;
					}
				}
			}
			else if (cum == 2)
			{
				for (int j = 0; j < GlobalScript.inst.gameState.allcountries.Length; j++)
				{
					if (GlobalScript.inst.gameState.allcountries[j].isSEATO)
					{
						GlobalScript.inst.gameState.allcountries[j].usainfl += num;
					}
				}
			}
			else
			{
				for (int k = 2; k < GlobalScript.inst.gameState.allcountries.Length; k++)
				{
					if (GlobalScript.inst.gameState.allcountries[k].isOVD && GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						if (k == 8 || k == 11 || k == 14 || k == 12 || k == 31 || k == 32 || k == 37 || k == 22 || k == 37 || k == 23 || k == 43 || k == 42 || k == 35 || k == 96 || k == 97 || k == 98 || k == 95 || k == 49 || k == 50)
						{
							GlobalScript.inst.gameState.allcountries[k].prcinfl += num;
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[k].isSEATO)
					{
						GlobalScript.inst.gameState.allcountries[k].prcinfl += num;
					}
				}
			}
		};
		return reference2.CreateActive(active);
	}

	public T AddAllAfrique(int num, int cum)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[658 + cum], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			if (cum == 1)
			{
				for (int i = 53; i < 109; i++)
				{
					if ((i < 69 || i > 105) && !GlobalScript.inst.gameState.allcountries[i].africaOff)
					{
						GlobalScript.inst.gameState.allcountries[i].sovpower += num;
					}
				}
			}
			else if (cum == 2)
			{
				for (int j = 53; j < 109; j++)
				{
					if ((j < 69 || j > 105) && !GlobalScript.inst.gameState.allcountries[j].africaOff)
					{
						GlobalScript.inst.gameState.allcountries[j].usapower += num;
					}
				}
			}
			else if (cum == 3)
			{
				for (int k = 53; k < 109; k++)
				{
					if ((k < 69 || k > 105) && !GlobalScript.inst.gameState.allcountries[k].africaOff)
					{
						GlobalScript.inst.gameState.allcountries[k].prcpower += num;
					}
				}
			}
		};
		return reference2.CreateActive(active);
	}

	public T AddStabilityAfrique(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}: <color={2}>{3}{1:F1}</color>", GlobalScript.inst.new_texts[666], (float)num / 10f, (num > 0) ? "lime" : "red", (num > 0) ? "+" : "");
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			for (int i = 53; i < 109; i++)
			{
				if ((i < 69 || i > 105) && !GlobalScript.inst.gameState.allcountries[i].africaOff)
				{
					GlobalScript.inst.gameState.allcountries[i].stab += num;
				}
			}
		};
		return reference2.CreateActive(active);
	}
}
