using System;
using MoonSharp.Interpreter;

namespace KGEvent;

[Serializable]
[MoonSharpUserData]
public class QueryMajor<T> where T : IRequesting<T>
{
	private int country;

	private T target;

	public QueryMajor(T target, int country)
	{
		this.country = country;
		this.target = target;
	}

	public T Historical()
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[20]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].historical;
		return reference2.CreateCondition(condition);
	}

	public T NotHistorical()
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[25]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => !GlobalScript.inst.gameState.empires[country].historical;
		return reference2.CreateCondition(condition);
	}

	public T Agressive()
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[21]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].agressive && !GlobalScript.inst.gameState.empires[country].historical;
		return reference2.CreateCondition(condition);
	}

	public T NotAgressive()
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[22]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => !GlobalScript.inst.gameState.empires[country].agressive && !GlobalScript.inst.gameState.empires[country].historical;
		return reference2.CreateCondition(condition);
	}

	public T Reformost()
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[23]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].reformist && !GlobalScript.inst.gameState.empires[country].historical;
		return reference2.CreateCondition(condition);
	}

	public T Conservative()
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[24]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => !GlobalScript.inst.gameState.empires[country].reformist && !GlobalScript.inst.gameState.empires[country].historical;
		return reference2.CreateCondition(condition);
	}

	public T RightStrongerLeft()
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[47]} {GlobalScript.inst.new_texts[32 + country]} {GlobalScript.inst.new_texts[45]} {GlobalScript.inst.new_texts[40]} {GlobalScript.inst.new_texts[44]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].insiders[1].influence > GlobalScript.inst.gameState.empires[country].insiders[0].influence;
		return reference2.CreateCondition(condition);
	}

	public T LeftStrongerRight()
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[47]} {GlobalScript.inst.new_texts[32 + country]} {GlobalScript.inst.new_texts[44]} {GlobalScript.inst.new_texts[40]} {GlobalScript.inst.new_texts[45]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].insiders[1].influence > GlobalScript.inst.gameState.empires[country].insiders[0].influence;
		return reference2.CreateCondition(condition);
	}

	public T Weaker(int against)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[32 + country]} {GlobalScript.inst.new_texts[26]} {GlobalScript.inst.new_texts[32 + against]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => ((country < 2) ? GlobalScript.inst.gameState.empires[country].power : GlobalScript.inst.gameState.influencePRC) < ((against < 2) ? GlobalScript.inst.gameState.empires[against].power : GlobalScript.inst.gameState.influencePRC);
		return reference2.CreateCondition(condition);
	}

	public T Stronger(int against)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[32 + country]} {GlobalScript.inst.new_texts[27]} {GlobalScript.inst.new_texts[32 + against]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => ((country < 2) ? GlobalScript.inst.gameState.empires[country].power : GlobalScript.inst.gameState.influencePRC) > ((against < 2) ? GlobalScript.inst.gameState.empires[against].power : GlobalScript.inst.gameState.influencePRC);
		return reference2.CreateCondition(condition);
	}

	public T Reigns(int Reign)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[32 + country]} {GlobalScript.inst.new_texts[27]} {GlobalScript.inst.new_texts[32 + Reign]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].now_leader == Reign;
		return reference2.CreateCondition(condition);
	}

	public T PoliticianPowerMore(int politic, int num)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[39]} {GlobalScript.inst.gameState.empires[country].leaders[politic].leader_name} {GlobalScript.inst.new_texts[40]} {num}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].leaders[politic].support > num;
		return reference2.CreateCondition(condition);
	}

	public T PoliticianPowerLess(int politic, int num)
	{
		ref T reference = ref target;
		string text = $"{GlobalScript.inst.new_texts[39]} {GlobalScript.inst.gameState.empires[country].leaders[politic].leader_name} {GlobalScript.inst.new_texts[41]} {num}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].leaders[politic].support < num;
		return reference2.CreateCondition(condition);
	}

	public T RightEqual(int num)
	{
		ref T reference = ref target;
		string text = $"{num} {GlobalScript.inst.new_texts[43]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].insiders[0].influence == num;
		return reference2.CreateCondition(condition);
	}

	public T LeftEqual(int num)
	{
		ref T reference = ref target;
		string text = $"{num} {GlobalScript.inst.new_texts[44]}";
		reference.AddReq(text);
		ref T reference2 = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.empires[country].insiders[1].influence == num;
		return reference2.CreateCondition(condition);
	}

	public T AddModify(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}{1}", "+", GlobalScript.inst.new_modify_texts[num]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.AddArrayElement(num, ref GlobalScript.inst.gameState.empires[country].modifies);
		};
		return reference2.CreateActive(active);
	}

	public T RemoveModify(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}{1}", "-", GlobalScript.inst.new_modify_texts[num]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.DeleteArrayElement(num, ref GlobalScript.inst.gameState.empires[country].modifies);
		};
		return reference2.CreateActive(active);
	}

	public T AddToRight(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}{1} {2}", (num >= 0) ? "+" : "", num, GlobalScript.inst.new_texts[28]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[country].insiders[0].influence += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddToLeft(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}{1} {2}", (num >= 0) ? "+" : "", num, GlobalScript.inst.new_texts[30]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[country].insiders[1].influence += num;
		};
		return reference2.CreateActive(active);
	}

	public T AddToPolitician(int politic, int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}{1} {2}", (num >= 0) ? "+" : "", num, GlobalScript.inst.gameState.empires[country].leaders[politic].leader_name);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[country].leaders[politic].support += num;
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

	public T AddInfluence(int num)
	{
		ref T reference = ref target;
		string text = string.Format("{0}{1} {2} {3}", (num >= 0) ? "+" : "", num, GlobalScript.inst.new_texts[31], GlobalScript.inst.new_texts[country + 32]);
		reference.AddResult(text);
		if (country < 2)
		{
			ref T reference2 = ref target;
			Action active = delegate
			{
				GlobalScript.inst.gameState.empires[country].power += num;
			};
			return reference2.CreateActive(active);
		}
		ref T reference3 = ref target;
		Action active2 = delegate
		{
			GlobalScript.inst.gameState.influencePRC += num;
		};
		return reference3.CreateActive(active2);
	}

	public T SetRuler(int ruler)
	{
		ref T reference = ref target;
		string text = string.Format("{0}{1} {2} {3}", (ruler >= 0) ? "+" : "", ruler, GlobalScript.inst.new_texts[31], GlobalScript.inst.new_texts[country + 32]);
		reference.AddResult(text);
		ref T reference2 = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[country].now_leader = ruler;
		};
		return reference2.CreateActive(active);
	}

	public T ChangeTree(string name)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[country].active_tree = name;
		};
		return reference.CreateActive(active);
	}
}
