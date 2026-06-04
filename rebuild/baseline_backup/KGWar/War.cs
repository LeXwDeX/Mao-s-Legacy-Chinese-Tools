using MoonSharp.Interpreter;

namespace KGWar;

[MoonSharpUserData]
public class War
{
	private warinwars target_war;

	public War AmericanSupportAttacker
	{
		get
		{
			target_war.usa_place = 0;
			return this;
		}
	}

	public War AmericanSupportDefender
	{
		get
		{
			target_war.usa_place = 1;
			return this;
		}
	}

	public War SovietSupportAttacker
	{
		get
		{
			target_war.ussr_place = 0;
			return this;
		}
	}

	public War SovietSupportDefender
	{
		get
		{
			target_war.ussr_place = 1;
			return this;
		}
	}

	public warinwars CreateWar => target_war;

	public War()
	{
		target_war = new warinwars();
		target_war.is_going = true;
		target_war.diplo_done[0] = false;
		target_war.diplo_done[1] = false;
		target_war.ussr_place = -1;
		target_war.usa_place = -1;
	}

	public War Name(string name)
	{
		target_war.name_war = name;
		return this;
	}

	public War Attacker(int country)
	{
		target_war.side1 = GlobalScript.inst.gameState.allcountries[country].name;
		return this;
	}

	public War Attacker(string country)
	{
		target_war.side1 = country;
		return this;
	}

	public War Defender(int country)
	{
		target_war.side2 = GlobalScript.inst.gameState.allcountries[country].name;
		return this;
	}

	public War Defender(string country)
	{
		target_war.side2 = country;
		return this;
	}

	public War AttackerInfluence(int value)
	{
		target_war.infl1 = value;
		target_war.infl2 = 1000 - value;
		return this;
	}

	public War DefenderInfluence(int value)
	{
		target_war.infl1 = 1000 - value;
		target_war.infl2 = value;
		return this;
	}

	public War TickTime(int value)
	{
		target_war.fortnight_max = value;
		return this;
	}

	public bool IsGoing()
	{
		return target_war.is_going;
	}

	public War DecleredWar()
	{
		_ = GlobalScript.inst;
		GlobalScript.inst.gameState.AddCells(1, ref GlobalScript.inst.gameState.ingamewars);
		GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.ingamewars.Length - 1] = target_war;
		return this;
	}
}
