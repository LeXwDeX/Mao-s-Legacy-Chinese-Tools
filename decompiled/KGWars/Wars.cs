using KGWar;

namespace KGWars;

internal static class Wars
{
	public static War O = new War().Name("Война за Огаден").Attacker("Сомали").Defender("Эфиопия")
		.AttackerInfluence(300)
		.DefenderInfluence(750)
		.SovietSupportDefender;
}
