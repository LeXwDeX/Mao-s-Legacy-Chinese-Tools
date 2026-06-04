using MoonSharp.Interpreter;

namespace KGWar;

[MoonSharpUserData]
public class WarManager
{
	public static War CreateWar()
	{
		return new War();
	}
}
