using System;
using KGEvent;

[Serializable]
public class Decision : IRequesting<Decision>
{
	public string name;

	public string desc;

	public string req;

	public string result;

	public int version;

	public bool condition_and;

	public Func<bool> expression = () => true;

	public Func<bool> condition = () => false;

	public Action active;

	private bool condtition_type;

	public QueryDecisions<Decision> thirdOne;

	public Decision End
	{
		get
		{
			condtition_type = false;
			AddExpr();
			condition_and = false;
			return this;
		}
	}

	public Decision Expr
	{
		get
		{
			condtition_type = true;
			return this;
		}
	}

	public Decision(string name, string desc, int version = 1)
	{
		this.name = name;
		this.desc = desc;
		this.version = version;
		CreateQuery();
	}

	private void CreateQuery()
	{
		thirdOne = new QueryDecisions<Decision>(this);
	}

	public Decision AddReq(string text)
	{
		req = $"{req} {((req == null) ? GlobalScript.inst.new_texts[36] : (condition_and ? GlobalScript.inst.new_texts[18] : GlobalScript.inst.new_texts[19]))} {text}";
		return this;
	}

	public Decision AddResult(string text)
	{
		result = string.Format("{0} {1} {2}", result, (result == null) ? (GlobalScript.inst.new_texts[110] + "|") : "|", text);
		return this;
	}

	private void AddExpr()
	{
		Func<bool> prev = condition;
		Func<bool> expr = expression;
		condition = () => expr() || prev();
		expression = () => true;
	}

	public Decision CreateCondition(Func<bool> condition)
	{
		if (!condtition_type)
		{
			Func<bool> prev = this.condition;
			if (this.condition != null)
			{
				this.condition = () => condition() || prev();
			}
			else
			{
				this.condition = () => condition();
			}
		}
		else
		{
			Func<bool> prev2 = expression;
			expression = () => condition() && prev2();
			condition_and = true;
		}
		return this;
	}

	public Decision CreateActive(Action active)
	{
		this.active = (Action)Delegate.Combine(this.active, active);
		return this;
	}
}
