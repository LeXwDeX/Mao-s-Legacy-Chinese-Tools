using System;
using LEGK;
using MoonSharp.Interpreter;

namespace KGEvent;

[MoonSharpUserData]
public class Event : RequestingMinor<Event>, IRequesting<Event>
{
	private enum TypeCreating
	{
		Event,
		Option
	}

	public EventDesc desc;

	private int amount_options = -1;

	private TypeCreating current_type;

	private bool condtition_type = true;

	public QueryMajor<Event> USSR;

	public QueryMajor<Event> USA;

	public QueryChina<Event> China;

	public Func<bool> condition = () => true;

	public Func<bool>[] option_condition = new Func<bool>[6];

	public Action[] option_active = new Action[6];

	public Action active = delegate
	{
	};

	public Event Or
	{
		get
		{
			condtition_type = false;
			return this;
		}
	}

	public Event And
	{
		get
		{
			condtition_type = true;
			return this;
		}
	}

	public Event NewOption
	{
		get
		{
			amount_options++;
			option_condition[amount_options] = () => true;
			option_active[amount_options] = delegate
			{
			};
			current_type = TypeCreating.Option;
			return this;
		}
	}

	public Event(string name)
	{
		RequestingIniter.CreateQueryMinors(this);
		CreateQueryMajors();
		desc = EventReader.events[name];
	}

	public Event()
	{
		RequestingIniter.CreateQueryMinors(this);
		CreateQueryMajors();
	}

	private void CreateQueryMajors()
	{
		USSR = new QueryMajor<Event>(this, 1);
		USA = new QueryMajor<Event>(this, 0);
		China = new QueryChina<Event>(this);
	}

	public Event AddToPartiesConnection(int num)
	{
		return CreateActive(delegate
		{
			GlobalScript.inst.gameState.SOV_PRC_PartiesConnection += num;
		});
	}

	public void Work()
	{
		if (condition())
		{
			active();
		}
	}

	public Event CreateEvent()
	{
		for (int i = 0; i < amount_options; i++)
		{
		}
		return this;
	}

	public Event AddReq(string text)
	{
		return this;
	}

	public Event AddResult(string text)
	{
		return this;
	}

	public Event CreateCondition(Func<bool> condition)
	{
		if (current_type == TypeCreating.Event)
		{
			Func<bool> prev = this.condition;
			if (prev != null)
			{
				this.condition = delegate
				{
					if (!condtition_type)
					{
						if (!condition())
						{
							return prev();
						}
						return true;
					}
					return condition() && prev();
				};
			}
			else
			{
				this.condition = () => condition();
			}
		}
		else
		{
			Func<bool> prev2 = option_condition[amount_options];
			option_condition[amount_options] = delegate
			{
				if (!condtition_type)
				{
					if (!condition())
					{
						return prev2();
					}
					return true;
				}
				return condition() && prev2();
			};
		}
		return this;
	}

	public Event CreateActive(Action active)
	{
		if (current_type == TypeCreating.Event)
		{
			this.active = (Action)Delegate.Combine(this.active, active);
		}
		else
		{
			ref Action reference = ref option_active[amount_options];
			reference = (Action)Delegate.Combine(reference, active);
		}
		return this;
	}
}
