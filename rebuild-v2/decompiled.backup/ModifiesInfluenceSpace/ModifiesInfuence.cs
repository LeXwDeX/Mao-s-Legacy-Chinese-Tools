using System.Collections.Generic;
using System.Linq;

namespace ModifiesInfluenceSpace;

public class ModifiesInfuence
{
	public static void ModifiesChanges(int ch_support, int ch_lib)
	{
		GameState gameState = GlobalScript.inst.gameState;
		if (gameState.modifies[64].active)
		{
			int num = gameState.startedDirectWarsNum.Where((KeyValuePair<int, bool> w) => w.Value).Count();
			num -= gameState.startedDirectWarsNum.Where((KeyValuePair<int, bool> w) => (w.Key <= 2 || w.Key == 7 || w.Key == 10 || w.Key == 13 || w.Key == 15) && w.Value).Count();
			gameState.data[34] += num * 2;
			gameState.data[22] += num * 5 * 2;
			gameState.data[162] += num * 2;
			gameState.data[8] += num * 5 * 2;
			gameState.empires[0].relations -= num * 2;
			gameState.empires[1].relations -= num * 2;
		}
		else if (gameState.allcountries.Count((Country cou) => cou.EAF) >= 2)
		{
			gameState.modifies[64].active = true;
		}
		if (gameState.modifies[65].active)
		{
			if ((gameState.allcountries[1].isOVD && gameState.empires[0].relations < 400) || gameState.empires[0].relations < 200)
			{
				gameState.IsBankAccountFreezed = true;
			}
			if (gameState.war <= 0 && !gameState.ingamewars[0].is_going && (((gameState.allcountries[1].isASEAN || gameState.allcountries[1].isSENTO || gameState.allcountries[1].isSEATO) && !gameState.modifies[17].active) || (gameState.allcountries[21].isSC && gameState.allcountries[85].isSC && (gameState.allcountries[92].isSC || gameState.allcountries[21].SubGosstroy == 18)) || (gameState.empires[0].relations > 400 && gameState.data[6] < 800)))
			{
				gameState.IsBankAccountFreezed = false;
			}
		}
		if (gameState.modifies[66].active)
		{
			if (gameState.data[1] > 700)
			{
				gameState.data[1] = 700;
			}
			if (gameState.data[26] < 100)
			{
				gameState.data[26] = 100;
			}
			bool flag = false;
			warinwars[] ingamewars = gameState.ingamewars;
			for (int num2 = 0; num2 < ingamewars.Length; num2++)
			{
				if (ingamewars[num2].is_going)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				gameState.data[0] += 2;
			}
			gameState.data[4] += 2;
			gameState.data[31] += 2;
			gameState.data[22] += 5;
			gameState.data[9] += 5;
			gameState.is_party_enabled[0] = false;
			gameState.is_party_enabled[4] = false;
		}
		if (gameState.modifies[0].active)
		{
			if (gameState.science[10])
			{
				gameState.modifies[0].active = false;
			}
			gameState.data[12] -= 5;
		}
		if (gameState.modifies[18].active)
		{
			if (gameState.science[10])
			{
				gameState.modifies[0].active = false;
			}
			gameState.data[12] -= 5;
		}
		if (gameState.modifies[1].active && gameState.science[11])
		{
			gameState.modifies[1].active = false;
		}
		if (gameState.modifies[2].active)
		{
			if (gameState.data[108] < 72)
			{
				gameState.modifies[2].active = false;
			}
			gameState.data[3] -= 10;
			gameState.data[4] += 20;
			gameState.data[5] -= 10;
			gameState.data[9] -= 2;
		}
		else if (gameState.data[108] >= 72)
		{
			gameState.modifies[2].active = true;
		}
		if (gameState.modifies[3].active)
		{
			if (gameState.data[14] >= 4 || gameState.data[16] >= 14 || gameState.data[17] > 18 || gameState.data[50] > 26)
			{
				gameState.modifies[3].active = false;
				gameState.data[4] += 200;
				gameState.data[3] += 100;
				gameState.data[1] -= 250;
				gameState.data[6] -= 10;
				Politic[] politics = gameState.politics;
				foreach (Politic politic in politics)
				{
					if (politic.traits[0] == 0)
					{
						politic.loyality -= 100;
					}
					else if (politic.traits[0] > 1)
					{
						politic.loyality += 100;
					}
				}
			}
			gameState.data[8] += 6;
			gameState.data[9] += 2;
			gameState.data[22] += 5;
			if (gameState.data[38] >= 100)
			{
				gameState.data[3] += 5;
				gameState.data[4] += 10;
				gameState.data[5] -= 5;
				gameState.empires[0].relations -= 5;
			}
		}
		if (gameState.modifies[5].active)
		{
			gameState.data[3] -= 2;
			gameState.data[4] += 10;
			gameState.data[8] += 2;
		}
		if (gameState.modifies[6].active)
		{
			gameState.data[1] += 5;
			gameState.data[4] -= 2;
			gameState.data[57]++;
			gameState.empires[0].relations -= 2;
			gameState.empires[1].relations -= 4;
			gameState.data[6] += 2;
		}
		if (gameState.modifies[7].active)
		{
			if (gameState.data[26] > 200)
			{
				gameState.data[26]--;
			}
			if (gameState.data[4] > 800)
			{
				gameState.data[4] -= 3;
			}
			if (gameState.empires[0].relations < 400)
			{
				gameState.empires[0].relations += gameState.empires[0].relations / 100;
			}
			if (gameState.data[12] < 500)
			{
				gameState.data[12] += 3;
			}
			else if (gameState.data[68] < 500)
			{
				gameState.data[68] += 3;
			}
			if (gameState.data[57] <= 400)
			{
				gameState.data[57] += 3;
			}
			if (gameState.data[14] != 3 || gameState.leader.traits[1] != 5 || gameState.leader.traits[0] == 0 || gameState.data[89] < 3 || gameState.allcountries[1].isSEV || gameState.allcountries[1].isOVD || gameState.allcountries[1].okb)
			{
				gameState.modifies[7].active = false;
			}
		}
		else if (gameState.data[14] == 3 && gameState.leader.traits[1] == 5 && gameState.leader.traits[0] > 0 && gameState.data[89] >= 3 && !gameState.allcountries[1].isSEV && !gameState.allcountries[1].isOVD && !gameState.allcountries[1].okb)
		{
			gameState.modifies[7].active = true;
		}
		if (gameState.modifies[8].active)
		{
			if (!gameState.allcountries[1].econ)
			{
				gameState.modifies[8].active = false;
			}
			gameState.empires[0].relations += 2;
			gameState.empires[1].relations += 2;
			gameState.data[4] -= 10;
			if (gameState.allcountries[1].okb)
			{
				gameState.data[22] += gameState.allcountries.Where((Country c) => c.okb).Count() * 2;
			}
		}
		else if (gameState.allcountries[1].econ)
		{
			gameState.modifies[8].active = true;
		}
		if (gameState.modifies[9].active)
		{
			if (gameState.data[66] <= 0)
			{
				gameState.modifies[9].active = false;
			}
			gameState.data[57] -= 10;
			if (gameState.data[3] - ch_support > 0)
			{
				gameState.data[3] -= (gameState.data[3] - ch_support) / 2;
			}
			if (ch_lib - gameState.data[4] > 0)
			{
				gameState.data[4] += (ch_lib - gameState.data[4]) / 2;
			}
		}
		else if (gameState.data[66] > 0)
		{
			gameState.modifies[9].active = true;
		}
		if (gameState.modifies[10].active)
		{
			if (gameState.data[67] <= 0)
			{
				gameState.modifies[10].active = false;
			}
			gameState.data[57] -= 10;
			if (gameState.data[3] - ch_support > 0)
			{
				gameState.data[3] -= (gameState.data[3] - ch_support) / 4;
			}
			if (ch_lib - gameState.data[4] > 0)
			{
				gameState.data[4] += (ch_lib - gameState.data[4]) / 4;
			}
		}
		else if (gameState.data[67] > 0)
		{
			gameState.modifies[10].active = true;
		}
		if (gameState.modifies[11].active)
		{
			gameState.data[12] += 20;
			gameState.data[68] += 20;
			gameState.data[13] += 20;
			gameState.data[8] += 20;
			gameState.data[1] -= 50;
			gameState.data[5] += 2;
			gameState.data[26] -= 3;
			if (gameState.data[16] != 11)
			{
				gameState.modifies[11].active = false;
				gameState.data[1] += 500;
				gameState.data[9] -= 500;
				gameState.data[8] -= 500;
			}
		}
		else if (gameState.data[16] == 11)
		{
			gameState.modifies[11].active = true;
			gameState.data[8] -= 50;
			gameState.data[1] = 0;
			Politic[] politics = gameState.politics;
			foreach (Politic politic2 in politics)
			{
				if (politic2 != null)
				{
					politic2.loyality -= 500;
				}
			}
		}
		if (gameState.modifies[12].active)
		{
			if ((gameState.data[12] + gameState.data[13] + gameState.data[68] - gameState.data[26]) / 3 >= 500 || gameState.data[21] < 1980 || gameState.data[16] >= 14)
			{
				gameState.modifies[12].active = false;
			}
			gameState.data[9] -= 10;
			gameState.data[57] -= 3;
		}
		else if ((gameState.data[12] + gameState.data[13] + gameState.data[68] - gameState.data[26]) / 3 < 500 && gameState.data[21] >= 1980 && gameState.data[16] < 14)
		{
			gameState.modifies[12].active = true;
		}
		if (gameState.modifies[13].active)
		{
			if (gameState.data[16] < 13 || gameState.data[5] < 500 || (gameState.data[68] < 700 && gameState.data[5] < 700))
			{
				gameState.modifies[13].active = false;
			}
			if (gameState.data[16] == 13)
			{
				gameState.data[8] += gameState.data[5] / 500;
				gameState.data[68] += 2;
			}
			else if (gameState.data[16] == 14)
			{
				gameState.data[8] += gameState.data[5] / 330;
				gameState.data[68] += 4;
			}
			else if (gameState.data[16] == 15)
			{
				gameState.data[8] += gameState.data[5] / 250;
				gameState.data[68] += 3;
			}
		}
		else if (gameState.data[16] >= 13 && (gameState.data[5] >= 700 || (gameState.data[68] >= 700 && gameState.data[5] > 500)))
		{
			gameState.modifies[13].active = true;
		}
		if (gameState.modifies[14].active && (gameState.politics[12].name_1 != 13 || gameState.politics[12].name_2 != 13 || gameState.politics[12].traits[0] != 2 || gameState.politics[12].traits[1] != 5 || gameState.politics[12].traits[2] != 11))
		{
			gameState.modifies[14].active = false;
		}
		if (gameState.modifies[15].active)
		{
			if (gameState.data[13] > 700)
			{
				gameState.data[13] = 700;
			}
			if (gameState.science[2])
			{
				gameState.modifies[15].active = false;
			}
		}
		if (gameState.modifies[16].active)
		{
			if (gameState.empires[1].relations >= 500)
			{
				gameState.modifies[16].active = false;
			}
			else
			{
				gameState.data[8] -= (500 - gameState.empires[1].relations) / 50;
				gameState.data[9] -= (500 - gameState.empires[1].relations) / 100;
			}
		}
		if (gameState.modifies[17].active)
		{
			if (gameState.empires[0].relations >= 500)
			{
				gameState.modifies[17].active = false;
			}
			else
			{
				gameState.data[8] -= (500 - gameState.empires[0].relations) / 50;
				gameState.data[9] -= (500 - gameState.empires[0].relations) / 100;
			}
		}
		if (gameState.modifies[18].active)
		{
			gameState.data[4] += 2;
			gameState.data[9] += 2;
		}
		else if (gameState.modifies[19].active)
		{
			gameState.data[57] -= 2;
			gameState.empires[0].relations += 5;
			gameState.data[4] += 2;
			gameState.data[8] += 2;
		}
		else if (gameState.modifies[20].active)
		{
			gameState.empires[0].relations -= 5;
			gameState.empires[1].relations += 2;
			gameState.data[22] -= 2;
			gameState.data[8] += 2;
		}
		if (gameState.modifies[21].active)
		{
			gameState.empires[1].relations += 2;
			gameState.empires[0].relations -= 2;
			gameState.data[22] -= 2;
			gameState.data[11] += 5;
		}
		else if (gameState.modifies[22].active)
		{
			gameState.data[4] += 2;
			gameState.empires[1].relations -= 5;
			gameState.data[9] += 2;
			gameState.data[57] += 2;
		}
		else if (gameState.modifies[23].active)
		{
			gameState.empires[0].relations += 5;
			gameState.data[57] -= 2;
			gameState.data[4] += 2;
			gameState.data[8] += 2;
		}
		if (gameState.modifies[24].active)
		{
			gameState.data[1] += 2;
			gameState.data[4] += 2;
			gameState.data[8] += 2;
		}
		else if (gameState.modifies[25].active)
		{
			gameState.data[11] += 2;
			gameState.data[3] -= 2;
			gameState.data[4] -= 2;
			gameState.data[26] -= 2;
			gameState.data[8] -= 3;
		}
		else if (gameState.modifies[26].active)
		{
			gameState.data[1] += 5;
			gameState.data[3] -= 5;
			gameState.data[4] -= 5;
			gameState.data[26] -= 5;
			gameState.data[5] -= 5;
		}
		else if (gameState.modifies[27].active)
		{
			gameState.data[22] += 5;
			gameState.data[3] -= 2;
			gameState.data[26] -= 2;
			gameState.data[8] -= 2;
		}
		if (gameState.modifies[28].active)
		{
			gameState.party_ideology[0]++;
			gameState.data[4] -= 2;
			gameState.data[22] -= 2;
			gameState.data[9] += 2;
			Politic[] politics = gameState.politics;
			foreach (Politic politic3 in politics)
			{
				if (politic3.traits[0] == 0)
				{
					politic3.power += 10;
				}
			}
			if (gameState.data[17] != 16 || gameState.data[15] != 6)
			{
				gameState.modifies[28].active = false;
			}
		}
		else if (gameState.modifies[29].active)
		{
			gameState.party_ideology[0]--;
			gameState.party_ideology[3]--;
			gameState.party_ideology[4]--;
			gameState.data[68] += 2;
			gameState.data[12] += 2;
			gameState.data[5] += 5;
			Politic[] politics = gameState.politics;
			foreach (Politic politic4 in politics)
			{
				if (politic4.traits[0] != 1)
				{
					politic4.power -= 5;
				}
			}
			if (gameState.data[15] > 7)
			{
				gameState.modifies[29].active = false;
			}
		}
		else if (gameState.modifies[30].active)
		{
			gameState.party_ideology[3]++;
			gameState.data[8] += 5;
			gameState.data[6] -= 2;
			gameState.empires[0].relations += 5;
			Politic[] politics = gameState.politics;
			foreach (Politic politic5 in politics)
			{
				if (politic5.traits[0] == 2)
				{
					politic5.power += 10;
				}
			}
			if (gameState.data[16] < 13)
			{
				gameState.modifies[30].active = false;
			}
		}
		else if (gameState.modifies[31].active)
		{
			gameState.party_ideology[4]++;
			gameState.empires[0].relations += 5;
			Politic[] politics = gameState.politics;
			foreach (Politic politic6 in politics)
			{
				if (politic6.traits[0] == 3)
				{
					politic6.power += 10;
				}
			}
			gameState.data[22] -= 2;
			gameState.data[108] -= 2;
			gameState.data[6] -= 2;
			if (gameState.data[16] < 14 || gameState.data[17] < 17)
			{
				gameState.modifies[31].active = false;
			}
		}
		if (gameState.modifies[32].active)
		{
			gameState.data[3] -= 5;
			gameState.data[4] -= 5;
			gameState.data[9] += 2;
			gameState.data[22] += 2;
			Politic[] politics = gameState.politics;
			foreach (Politic politic7 in politics)
			{
				if (politic7.traits[0] == 0)
				{
					politic7.power += 10;
				}
				else
				{
					politic7.power -= 5;
				}
			}
		}
		if (gameState.modifies[33].active)
		{
			gameState.data[3] += 2;
			gameState.data[5] += 2;
			gameState.data[12] -= 2;
			gameState.data[68] += 2;
			gameState.data[22] -= 5;
		}
		if (gameState.modifies[34].active)
		{
			gameState.data[8] -= 5;
			gameState.data[13] += 7;
			gameState.data[5] += 5;
			gameState.data[68] += 5;
			gameState.data[57] += 2;
		}
		if (gameState.modifies[35].active)
		{
			gameState.data[12] += 5;
			gameState.data[5] += 5;
			gameState.data[57] += 2;
		}
		if (gameState.modifies[36].active)
		{
			gameState.data[11] += 5;
			gameState.empires[0].power += 5;
			gameState.empires[1].power += 5;
		}
		if (gameState.modifies[37].active)
		{
			gameState.empires[0].relations -= 2;
			gameState.data[13] += 2;
			gameState.data[5] += 5;
			gameState.data[4] += 5;
		}
		if (gameState.modifies[38].active)
		{
			gameState.data[1] += 5;
			gameState.data[6]++;
			gameState.data[31]++;
			if (gameState.leader.name_1 != 32 || gameState.leader.name_2 != 47)
			{
				gameState.modifies[38].active = false;
			}
		}
		if (gameState.modifies[39].active)
		{
			if (gameState.empires[0].relations < 150)
			{
				gameState.empires[0].relations = 150;
			}
			gameState.empires[0].power -= 5;
			gameState.empires[1].relations -= 5;
			gameState.data[36] += 5;
		}
		if (gameState.modifies[40].active)
		{
			if (gameState.data[12] > 150)
			{
				gameState.data[12] = 150;
			}
			if (gameState.data[22] > 2000)
			{
				gameState.data[22] = 2000;
			}
			gameState.party_ideology[3] = 0;
			gameState.data[31] += 5;
			gameState.data[57] += 5;
			gameState.data[13] += 2;
			gameState.data[68] += 2;
			gameState.data[1] -= 5;
			gameState.data[26] -= 5;
		}
		if (gameState.modifies[41].active)
		{
			gameState.party_ideology[3]++;
			gameState.data[9] += 10;
			gameState.empires[0].power++;
			gameState.party_ideology[4]++;
			Politic[] politics = gameState.politics;
			foreach (Politic politic8 in politics)
			{
				if (politic8.traits[0] == 2)
				{
					politic8.power += 10;
				}
				if (politic8.traits[0] == 3)
				{
					politic8.power += 10;
				}
			}
		}
		if (gameState.modifies[42].active)
		{
			if (gameState.data[54] > 39 && !gameState.modifies[17].active && gameState.allcountries[21].Torg)
			{
				gameState.empires[0].relations += 4;
				gameState.data[8] += 2;
				gameState.data[6]--;
			}
			gameState.empires[0].power++;
		}
		if (gameState.modifies[43].active && gameState.allcountries[21].Torg && !gameState.allcountries[1].isSEATO && !gameState.allcountries[1].okb && !gameState.allcountries[1].isOVD && (gameState.allcountries[1].Gosstroy == 2 || gameState.allcountries[1].Gosstroy == 3))
		{
			gameState.data[8] += 3;
			gameState.data[11] += 4;
		}
		if (gameState.modifies[44].active)
		{
			if (gameState.allcountries[21].Torg && gameState.data[52] < 36 && !gameState.modifies[16].active)
			{
				gameState.empires[1].relations += 4;
				gameState.data[8] += 2;
				gameState.data[11] += 2;
			}
			gameState.empires[1].power++;
		}
		if (gameState.modifies[44].active && gameState.allcountries[21].Torg && gameState.allcountries[1].okb && gameState.influencePRC >= 500)
		{
			gameState.data[0] += 5;
			gameState.data[8] += 2;
			gameState.empires[0].relations -= 3;
			gameState.empires[1].relations -= 3;
			gameState.empires[0].power--;
			gameState.empires[1].power--;
		}
		if (gameState.modifies[46].active)
		{
			gameState.data[8] += 6;
			gameState.data[22] += 5;
			gameState.data[9] += 5;
			gameState.empires[0].relations -= 5;
			gameState.empires[1].relations -= 5;
			gameState.empires[0].power--;
			gameState.empires[1].power--;
		}
		else if (gameState.modifies[47].active)
		{
			int num3 = 0;
			for (int num4 = 0; num4 < gameState.allcountries.Length; num4++)
			{
				if (gameState.allcountries[num4].okb)
				{
					num3++;
				}
			}
			if (num3 < 7)
			{
				gameState.data[8] -= 10;
			}
			else if (num3 < 14)
			{
				gameState.data[8] -= 20;
			}
			else
			{
				gameState.data[8] -= 30;
			}
			gameState.data[9] += num3 * 2;
		}
		else if (gameState.modifies[48].active)
		{
			int num5 = 0;
			for (int num6 = 0; num6 < gameState.allcountries.Length; num6++)
			{
				if (gameState.allcountries[num6].okb)
				{
					num5++;
				}
			}
			if (num5 < 7)
			{
				gameState.data[8] -= 10;
			}
			else if (num5 < 14)
			{
				gameState.data[8] -= 20;
			}
			else
			{
				gameState.data[8] -= 30;
			}
			gameState.data[22] += num5;
		}
		if (gameState.modifies[49].active)
		{
			gameState.data[0] += 30;
			gameState.data[9] += 20;
			gameState.empires[0].relations -= 20;
			gameState.empires[1].relations -= 20;
		}
		if (gameState.modifies[51].active)
		{
			gameState.OilEat = (float)gameState.data[12] * 0.4f + ((gameState.data[12] >= 500) ? ((float)(gameState.data[12] - 499) * 0.4f) : 0f) + ((gameState.data[12] >= 750) ? ((float)(gameState.data[12] - 749) * 0.4f) : 0f);
			gameState.OilEat += ((gameState.data[13] >= 250) ? ((float)(gameState.data[13] - 249) * 0.35f) : 0f) + ((gameState.data[13] >= 500) ? ((float)(gameState.data[13] - 499) * 0.35f) : 0f) + ((gameState.data[13] >= 750) ? ((float)(gameState.data[13] - 749) * 0.35f) : 0f);
			gameState.OilEat += ((gameState.data[68] >= 500) ? ((float)(gameState.data[68] - 499) * 0.34f) : 0f) + ((gameState.data[68] >= 750) ? ((float)(gameState.data[68] - 749) * 0.34f) : 0f);
			gameState.OilEat += (float)gameState.data[22] * 0.1f;
			gameState.OilEat += (float)gameState.data[5] * 0.05f;
			if (gameState.science[2])
			{
				gameState.OilEat += 35f;
			}
			if (gameState.science[3])
			{
				gameState.OilEat += 30f;
			}
			if (gameState.science[6])
			{
				gameState.OilEat += 20f;
			}
			if (gameState.science[7])
			{
				gameState.OilEat += 40f;
			}
			if (gameState.science[8])
			{
				gameState.OilEat += 25f;
			}
			if (gameState.science[10])
			{
				gameState.OilEat -= 20f;
			}
			if (gameState.science[11])
			{
				gameState.OilEat -= 35f;
			}
			if (gameState.science[13])
			{
				gameState.OilEat -= 60f;
			}
			if (gameState.science[14])
			{
				gameState.OilEat -= 60f;
			}
			float num7 = gameState.data[143];
			if (gameState.modifies[58].active && !gameState.modifies[16].active && gameState.data[153] <= 0)
			{
				num7 -= 15f;
			}
			if (gameState.allcountries[14].proprc)
			{
				num7 -= 1f;
			}
			if (gameState.allcountries[8].proprc)
			{
				num7 -= 1f;
			}
			if (gameState.allcountries[35].proprc)
			{
				num7 -= 1f;
			}
			if (gameState.allcountries[40].proprc)
			{
				num7 -= 1f;
			}
			if (gameState.allcountries[30].proprc)
			{
				num7 -= 1f;
			}
			if (gameState.allcountries[83].proprc)
			{
				num7 -= 1f;
			}
			if (num7 < 10f)
			{
				num7 = 10f;
			}
			float num8 = num7 * 7.7f * (gameState.OilEat - gameState.OilProd) / 10000f;
			gameState.data[8] -= (int)num8;
			if (gameState.data[143] - 50 > 0)
			{
				gameState.empires[0].power -= (gameState.data[143] - 10) / 3;
				gameState.empires[1].power += (gameState.data[143] - 10) / 3;
			}
			else if (gameState.data[143] - 20 > 0 && gameState.data[143] - 50 <= 0)
			{
				gameState.empires[0].power += (gameState.data[143] - 10) / 3;
				gameState.empires[1].power += (gameState.data[143] - 10) / 3;
			}
			else if (gameState.data[21] < 1980)
			{
				gameState.empires[0].power += (gameState.data[143] - 10) / 2;
				gameState.empires[1].power -= (gameState.data[143] - 10) / 2;
			}
			else
			{
				gameState.empires[0].power += gameState.data[143] - 10;
				gameState.empires[1].power -= (gameState.data[143] - 10) * 2;
			}
		}
		if (gameState.modifies[53].active)
		{
			gameState.party_ideology[0]++;
			gameState.party_ideology[2]++;
			gameState.data[9] += 10;
			gameState.empires[1].power++;
			Politic[] politics = gameState.politics;
			foreach (Politic politic9 in politics)
			{
				if (politic9.traits[0] == 0)
				{
					politic9.power += 10;
				}
				if (politic9.traits[0] == 1)
				{
					politic9.power += 10;
				}
			}
		}
		if (gameState.modifies[58].active && gameState.empires[1].relations >= 500 && gameState.data[153] > 0)
		{
			gameState.data[153]--;
			gameState.data[8] -= 5;
		}
		if (gameState.modifies[59].active)
		{
			if (gameState.data[16] == 11 || gameState.data[16] == 15)
			{
				gameState.modifies[59].active = false;
			}
			else if (gameState.data[16] == 10)
			{
				gameState.data[3] += 3;
				gameState.data[4] -= 2;
				gameState.data[5] += 3;
				gameState.data[13] -= 3;
			}
			else if (gameState.data[16] == 12 || gameState.data[16] == 13)
			{
				gameState.data[5] += 5;
				gameState.data[13] += 5;
				gameState.data[12] -= 5;
			}
			else
			{
				gameState.data[5] += 5;
				gameState.data[8] += 5;
				gameState.data[13] -= 5;
			}
		}
		else if (gameState.modifies[60].active)
		{
			if (gameState.data[16] == 14 || gameState.data[16] == 15)
			{
				gameState.modifies[60].active = false;
			}
			else if (gameState.data[16] <= 11)
			{
				gameState.data[3] -= 3;
				gameState.data[4] += 3;
				gameState.data[8] += 5;
			}
			else
			{
				gameState.data[3] -= 6;
				gameState.data[4] += 6;
				gameState.data[8] += 10;
			}
		}
		else if (gameState.modifies[61].active)
		{
			if (gameState.data[16] == 11 || gameState.data[16] == 15)
			{
				gameState.modifies[61].active = false;
			}
			else if (gameState.data[16] == 10)
			{
				gameState.data[3] += 3;
				gameState.data[8] -= 5;
				gameState.data[5] += 3;
				gameState.data[13] += 5;
			}
			else if (gameState.data[16] == 12 || gameState.data[16] == 13)
			{
				gameState.data[5] += 5;
				gameState.data[13] += 5;
				gameState.data[4] += 5;
			}
			else
			{
				gameState.data[5] += 5;
				gameState.data[8] -= 10;
				gameState.data[13] += 5;
			}
		}
		else if (gameState.modifies[62].active)
		{
			if (gameState.data[16] == 10 || gameState.data[16] == 11)
			{
				gameState.modifies[62].active = false;
			}
			else if (gameState.data[16] == 12 || gameState.data[16] == 13)
			{
				gameState.data[5] += 5;
				gameState.data[13] += 5;
				gameState.data[8] -= 10;
			}
			else
			{
				gameState.data[5] -= 5;
				gameState.data[8] += 5;
				gameState.data[13] += 5;
			}
		}
		if (!gameState.modifies[63].active)
		{
			return;
		}
		switch (gameState.modifies[63].level)
		{
		case 0:
			if (gameState.data[16] >= 13)
			{
				gameState.modifies[63].active = false;
				gameState.data[4] += 250;
				gameState.data[3] -= 250;
			}
			else
			{
				gameState.data[4] -= 10;
				gameState.data[3] += 5;
				gameState.data[8] -= 5;
			}
			break;
		case 1:
			if (gameState.data[16] <= 11 || gameState.data[16] >= 14)
			{
				gameState.modifies[63].active = false;
				gameState.data[4] += 250;
				gameState.empires[0].relations -= 250;
			}
			else
			{
				gameState.data[68] += 5;
				gameState.empires[0].relations += 5;
				gameState.data[8] -= 5;
			}
			break;
		default:
			if (gameState.data[16] <= 12)
			{
				gameState.modifies[63].active = false;
				gameState.data[4] += 250;
				gameState.data[3] -= 250;
			}
			else
			{
				gameState.data[68] += 5;
				gameState.data[5] += 5;
				gameState.data[8] -= 5;
			}
			break;
		}
	}
}
