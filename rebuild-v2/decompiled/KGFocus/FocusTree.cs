using System.Collections.Generic;
using MoonSharp.Interpreter;

namespace KGFocus;

[MoonSharpUserData]
public class FocusTree
{
	private int active_layer;

	private List<List<Focus>> layers = new List<List<Focus>>();

	public List<Focus> this[int i] => layers[i];

	public int Count => layers.Count;

	public void AddLayer()
	{
		layers.Add(new List<Focus>());
		active_layer = layers.Count - 1;
	}

	public Focus AddFocus(string name, int tim = 75)
	{
		Focus focus = new Focus(name, tim);
		layers[active_layer].Add(focus);
		return focus;
	}
}
