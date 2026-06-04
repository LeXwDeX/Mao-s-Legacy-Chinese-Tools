using System.Collections.Generic;
using MoonSharp.Interpreter;

namespace KGEvent;

[MoonSharpUserData]
internal class EventManager
{
	private static List<string> completed_events = new List<string>();

	private static List<Event> events = new List<Event>();

	public static Event active_event = null;

	public static void DeleteCompletedEvents()
	{
		foreach (Event @event in events)
		{
			if (completed_events.Contains(@event.desc.name))
			{
				events.Remove(@event);
			}
		}
	}

	public static void LoadEvents(List<string> load_completed_events)
	{
		completed_events = load_completed_events;
		DeleteCompletedEvents();
	}

	public static void DeleteActive()
	{
		completed_events.Add(active_event.desc.name);
		active_event = null;
	}

	public static Event CreateEvent(string name)
	{
		Event obj = new Event(name);
		events.Add(obj);
		return obj;
	}

	public static void AddEvent(Event e)
	{
		events.Add(e);
	}

	public static bool ChekingEvents()
	{
		if (active_event == null)
		{
			foreach (Event @event in events)
			{
				if (@event.condition())
				{
					active_event = @event;
					events.Remove(@event);
					return true;
				}
			}
		}
		return false;
	}
}
