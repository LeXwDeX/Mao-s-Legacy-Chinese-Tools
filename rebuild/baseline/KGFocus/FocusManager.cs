using System.Collections.Generic;
using MoonSharp.Interpreter;

namespace KGFocus;

[MoonSharpUserData]
public class FocusManager
{
	public static Dictionary<string, FocusTree> all_trees = new Dictionary<string, FocusTree>();

	public static FocusTree CreateTree(string name)
	{
		FocusTree focusTree = new FocusTree();
		all_trees.Add(name, focusTree);
		return focusTree;
	}
}
