using System.Collections.Generic;
using System.IO;
using KGEvent;
using KGFocus;
using KGWar;
using LEGK;
using LFKG;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using UnityEngine;

namespace Mod;

internal static class Moding
{
	public static List<ModInfo> moddings = new List<ModInfo>();

	public static string mod;

	private static void ReadEventLocal()
	{
		int num = PlayerPrefs.GetInt("language");
		EventReader.ReadEvents(File.ReadAllText(string.Format("mods{0}{1}{0}lang{0}event_{2}.txt", Path.DirectorySeparatorChar, mod, (num == 0) ? "en" : "ru")));
	}

	private static void ReadWayLocal()
	{
		int num = PlayerPrefs.GetInt("language");
		FocusReader.ReadFocuses(File.ReadAllText(string.Format("mods{0}{1}{0}lang{0}way_{2}.txt", Path.DirectorySeparatorChar, mod, (num == 0) ? "en" : "ru")));
	}

	public static void RegisterComponents()
	{
		mod = "test";
		UserData.RegisterAssembly();
		Script script = new Script();
		script.Globals["Event"] = new EventManager();
		script.Globals["War"] = new WarManager();
		script.Globals["Focus"] = new FocusManager();
		script.Globals["Authoritarianism"] = 0;
		script.Globals["Socialism"] = 1;
		script.Globals["Reformism"] = 2;
		script.Globals["Liberalism"] = 3;
		script.Options.ScriptLoader = new FileSystemScriptLoader();
		((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = new string[1] { string.Format("mods{0}{1}{0}?.lua", Path.DirectorySeparatorChar, mod) };
		ReadEventLocal();
		ReadWayLocal();
		script.DoFile(string.Format("mods{0}{1}{0}main.lua", Path.DirectorySeparatorChar, mod));
	}
}
