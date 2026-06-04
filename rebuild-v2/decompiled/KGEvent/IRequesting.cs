using System;

namespace KGEvent;

public interface IRequesting<T>
{
	T CreateCondition(Func<bool> condition);

	T AddReq(string text);

	T AddResult(string text);

	T CreateActive(Action active);
}
