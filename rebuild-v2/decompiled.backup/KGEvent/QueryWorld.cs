using System;
using KGWar;
using MoonSharp.Interpreter;

namespace KGEvent;

[Serializable]
[MoonSharpUserData]
public class QueryWorld<T> where T : IRequesting<T>
{
	private T target;

	public QueryWorld(T target)
	{
		this.target = target;
	}

	public T WarIsGoing(War war)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[95]} {war.CreateWar.name_war}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => war.IsGoing();
		return reference2.CreateCondition(condition);
	}

	public T EconIsExist()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.allcountries[1].econ;
		return reference.CreateCondition(condition);
	}

	public T OkbIsExist()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.allcountries[1].okb;
		return reference.CreateCondition(condition);
	}

	public T EconIsNotExist()
	{
		ref T reference = ref target;
		Func<bool> condition = () => !GlobalScript.inst.gameState.allcountries[1].econ;
		return reference.CreateCondition(condition);
	}

	public T OkbIsNotExist()
	{
		ref T reference = ref target;
		Func<bool> condition = () => !GlobalScript.inst.gameState.allcountries[1].okb;
		return reference.CreateCondition(condition);
	}

	public T BeforeDay(int day)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[90]} {day} {GlobalScript.inst.new_texts[91]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[19] > day;
		return reference2.CreateCondition(condition);
	}

	public T AfterDay(int day)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[90]} {day} {GlobalScript.inst.new_texts[91]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[19] < day;
		return reference2.CreateCondition(condition);
	}

	public T IsMonth(int month)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[20] == month;
		return reference.CreateCondition(condition);
	}

	public T BeforeMonth(int month)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[20] > month;
		return reference.CreateCondition(condition);
	}

	public T AfterMonth(int month)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[20] < month;
		return reference.CreateCondition(condition);
	}

	public T IsYear(int year)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[21] == year;
		return reference.CreateCondition(condition);
	}

	public T BeforeYear(int year)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[21] > year;
		return reference.CreateCondition(condition);
	}

	public T AfterYear(int year)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[21] < year;
		return reference.CreateCondition(condition);
	}

	public T BeforeDate(int day, int month, int year)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[21] < year || (GlobalScript.inst.gameState.data[21] == year && (GlobalScript.inst.gameState.data[20] < month || (GlobalScript.inst.gameState.data[20] == month && GlobalScript.inst.gameState.data[19] < day)));
		return reference.CreateCondition(condition);
	}

	public T AfterDate(int day, int month, int year)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[21] > year || (GlobalScript.inst.gameState.data[21] == year && (GlobalScript.inst.gameState.data[20] > month || (GlobalScript.inst.gameState.data[20] == month && GlobalScript.inst.gameState.data[19] > day)));
		return reference.CreateCondition(condition);
	}

	public T DecleredWar(War war)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[89]} {war.CreateWar.name_war}";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			war.DecleredWar();
		};
		return reference2.CreateActive(active);
	}

	public T AddToPartiesConnection(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}{1} {2}", (num >= 0) ? "+" : "", num, GlobalScript.inst.new_texts[42]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.SOV_PRC_PartiesConnection += num;
		};
		return reference2.CreateActive(active);
	}

	public T WarEnds(War war)
	{
		ref T reference = ref target;
		string text = $"{war.CreateWar.name_war} {GlobalScript.inst.new_texts[96]}";
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			war.CreateWar.is_going = false;
		};
		return reference2.CreateActive(active);
	}

	public T CreateEcon()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[1].econ = true;
		};
		return reference.CreateActive(active);
	}

	public T CreateOkb()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.allcountries[1].okb = true;
		};
		return reference.CreateActive(active);
	}

	public T AddEvent(Event e)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			EventManager.AddEvent(e);
		};
		return reference.CreateActive(active);
	}
}
