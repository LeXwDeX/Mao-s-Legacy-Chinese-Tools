using System;

[Serializable]
public class Country
{
	public string name = "";

	public int numberOfSpecialEnding = -1;

	public bool isSEV;

	public bool isOVD;

	public bool Vyshi;

	public bool isNATO;

	public bool isEU;

	public bool isSocEU;

	public bool isASEAN;

	public bool isOil;

	public bool isSC;

	public bool isSENTO;

	public bool isSEATO;

	public bool proprc;

	public bool prosov;

	public bool profre;

	public bool dota;

	public bool okb;

	public bool econ;

	public bool fez;

	public bool sto;

	public bool oar;

	public bool Torg;

	public bool usalliance;

	public bool sovalliance;

	public bool frealliance;

	public bool cw;

	public bool perevorot;

	public int soc_stab;

	public int stab;

	public int dev;

	public int sovpower;

	public int usapower;

	public int prcpower;

	public int frepower;

	public int Gosstroy;

	public int spec;

	public int sovinfl;

	public int prcinfl;

	public int usainfl;

	public int freinf1;

	public int inflCh;

	public int inflNATO;

	public bool based;

	public bool EAF;

	public int puppetOf = -1;

	public int SubGosstroy = -1;

	public bool isMonatchy;

	public bool africaOff;

	public DateTime next_elections = new DateTime(2222, 2, 22);

	public int level_of_dev;

	public int level_of_unstab;

	public bool[] parts = new bool[1];

	public Country EstablishGovernment(Government government_type)
	{
		switch (government_type)
		{
		case Government.ProAmerican:
			proprc = false;
			prosov = false;
			Vyshi = true;
			break;
		case Government.ProSoviet:
			proprc = false;
			prosov = true;
			Vyshi = false;
			break;
		case Government.ProChina:
			proprc = true;
			prosov = false;
			Vyshi = false;
			break;
		case Government.ProFrance:
			proprc = false;
			prosov = false;
			Vyshi = false;
			profre = true;
			break;
		default:
			proprc = false;
			prosov = false;
			Vyshi = false;
			profre = false;
			break;
		}
		return this;
	}

	public Country EstablishGosstroy(int state)
	{
		Gosstroy = GlobalScript.inst.gameState.allcountries[state].Gosstroy;
		SubGosstroy = GlobalScript.inst.gameState.allcountries[state].SubGosstroy;
		return this;
	}

	public Country JoinAllOurAlliances(bool yes)
	{
		if (GlobalScript.inst.gameState.allcountries[1].okb)
		{
			okb = yes;
		}
		else if (GlobalScript.inst.gameState.allcountries[1].isOVD)
		{
			isOVD = yes;
		}
		else if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
		{
			isSEATO = yes;
		}
		if (GlobalScript.inst.gameState.allcountries[1].econ)
		{
			econ = yes;
		}
		else if (GlobalScript.inst.gameState.allcountries[1].isSEV)
		{
			isSEV = yes;
		}
		else if (GlobalScript.inst.gameState.allcountries[1].isASEAN)
		{
			isASEAN = yes;
		}
		return this;
	}

	public Country LeaveAlliances()
	{
		okb = false;
		econ = false;
		isSEV = false;
		isOVD = false;
		isNATO = false;
		isEU = false;
		isSocEU = false;
		prosov = false;
		profre = false;
		Vyshi = false;
		proprc = false;
		isASEAN = false;
		isSEATO = false;
		Torg = false;
		isSENTO = false;
		fez = false;
		sto = false;
		isSC = false;
		return this;
	}

	public Country JoinOurEconomicAlliance(bool yes)
	{
		if (GlobalScript.inst.gameState.allcountries[1].econ)
		{
			econ = yes;
		}
		else if (GlobalScript.inst.gameState.allcountries[1].isSEV)
		{
			isSEV = yes;
		}
		return this;
	}

	public Country JoinOAR()
	{
		oar = true;
		return this;
	}

	public Country LeaveOAR()
	{
		oar = false;
		return this;
	}

	public Country JoinNATO()
	{
		isNATO = true;
		return this;
	}

	public Country LeaveNATO()
	{
		isNATO = false;
		return this;
	}

	public Country JoinASEAN()
	{
		isASEAN = true;
		return this;
	}

	public Country LeaveASEAN()
	{
		isASEAN = false;
		return this;
	}

	public Country JoinSEATO()
	{
		isSEATO = true;
		return this;
	}

	public Country LeaveSEATO()
	{
		isSEATO = false;
		return this;
	}

	public Country JoinSENTO()
	{
		isSENTO = true;
		return this;
	}

	public Country LeaveSENTO()
	{
		isSENTO = false;
		return this;
	}

	public Country JoinEU()
	{
		isEU = true;
		return this;
	}

	public Country LeaveEU()
	{
		isEU = false;
		return this;
	}

	public Country JoinOKB()
	{
		okb = true;
		return this;
	}

	public Country LeaveOKB()
	{
		okb = false;
		return this;
	}

	public Country JoinECON()
	{
		econ = true;
		return this;
	}

	public Country LeaveECON()
	{
		econ = false;
		return this;
	}

	public Country JoinComecon()
	{
		isSEV = true;
		return this;
	}

	public Country LeaveComecon()
	{
		isSEV = false;
		return this;
	}

	public Country JoinWP()
	{
		isOVD = true;
		return this;
	}

	public Country LeaveWP()
	{
		isOVD = false;
		return this;
	}

	public Country JoinFEZ()
	{
		fez = true;
		return this;
	}

	public Country JoinSTO()
	{
		sto = true;
		return this;
	}

	public Country LeaveFEZ()
	{
		fez = false;
		return this;
	}

	public Country LeaveSTO()
	{
		sto = false;
		return this;
	}

	public Country JoinSC()
	{
		isSC = true;
		return this;
	}

	public Country LeaveSC()
	{
		isSC = false;
		return this;
	}

	public Country AddAmericanInfluence(int num)
	{
		usapower += num;
		return this;
	}

	public Country AddSovietInfluence(int num)
	{
		sovpower += num;
		return this;
	}

	public Country AddChineseInfluence(int num)
	{
		prcpower += num;
		return this;
	}

	public Country AddFrannceInfluence(int num)
	{
		frepower += num;
		return this;
	}

	public Country SetSystem(int type_system)
	{
		Gosstroy = type_system;
		return this;
	}

	public Country AddStability(int num)
	{
		stab += num;
		return this;
	}

	public Country AddEconomicPotential(int num)
	{
		dev = num;
		return this;
	}

	public bool IsInTheSameMilitaryAllianceWith(Country toCompare)
	{
		if (okb && okb == toCompare.okb && !isOVD && !isSEATO)
		{
			return true;
		}
		if (isOVD && isOVD == toCompare.isOVD && !okb && !isSEATO)
		{
			return true;
		}
		if (isSEATO && isSEATO == toCompare.isSEATO && !okb && !isOVD)
		{
			return true;
		}
		return false;
	}

	public bool IsInTheSameEconomicAllianceWith(Country toCompare)
	{
		if (isSEV && isSEV == toCompare.isSEV && !econ && !isASEAN)
		{
			return true;
		}
		if (econ && econ == toCompare.econ && !isSEV && !isASEAN)
		{
			return true;
		}
		if (isASEAN && isASEAN == toCompare.isASEAN && !econ && !isSEV)
		{
			return true;
		}
		return false;
	}

	public bool IsInTheForeignAlliances()
	{
		if (isSEV || isOVD || isNATO || isSEATO || isSENTO || isSC)
		{
			return true;
		}
		return false;
	}

	public Country ILoveSuckCocks()
	{
		if (GlobalScript.inst.gameState.data[130] == 1 && GlobalScript.inst.gameState.data[62] >= 2 && (GlobalScript.inst.gameState.data[64] == 2 || GlobalScript.inst.gameState.completedDecisions[7]))
		{
			for (int i = 0; i < 11; i++)
			{
				if (i < 7 || i > 9)
				{
					GlobalScript.inst.gameState.allcountries[1].parts[i] = false;
				}
			}
			GlobalScript.inst.gameState.allcountries[1].parts[0] = true;
		}
		else if (GlobalScript.inst.gameState.data[130] == 1 && (GlobalScript.inst.gameState.data[62] == 2 || GlobalScript.inst.gameState.data[62] == 3))
		{
			for (int j = 0; j < 11; j++)
			{
				if (j < 7 || j > 9)
				{
					GlobalScript.inst.gameState.allcountries[1].parts[j] = false;
				}
			}
			GlobalScript.inst.gameState.allcountries[1].parts[2] = true;
		}
		else if (GlobalScript.inst.gameState.data[62] >= 2 && (GlobalScript.inst.gameState.data[64] == 2 || GlobalScript.inst.gameState.completedDecisions[7]))
		{
			for (int k = 0; k < 11; k++)
			{
				if (k < 7 || k > 9)
				{
					GlobalScript.inst.gameState.allcountries[1].parts[k] = false;
				}
			}
			GlobalScript.inst.gameState.allcountries[1].parts[6] = true;
		}
		else if (GlobalScript.inst.gameState.data[130] == 1 && (GlobalScript.inst.gameState.data[64] == 2 || GlobalScript.inst.gameState.completedDecisions[7]))
		{
			for (int l = 0; l < 11; l++)
			{
				if (l < 7 || l > 9)
				{
					GlobalScript.inst.gameState.allcountries[1].parts[l] = false;
				}
			}
			GlobalScript.inst.gameState.allcountries[1].parts[3] = true;
		}
		else if (GlobalScript.inst.gameState.data[130] == 1)
		{
			for (int m = 0; m < 11; m++)
			{
				if (m < 7 || m > 9)
				{
					GlobalScript.inst.gameState.allcountries[1].parts[m] = false;
				}
			}
			GlobalScript.inst.gameState.allcountries[1].parts[4] = true;
		}
		else if (GlobalScript.inst.gameState.data[64] == 2 || GlobalScript.inst.gameState.completedDecisions[7])
		{
			for (int n = 0; n < 11; n++)
			{
				if (n < 7 || n > 9)
				{
					GlobalScript.inst.gameState.allcountries[1].parts[n] = false;
				}
			}
			GlobalScript.inst.gameState.allcountries[1].parts[5] = true;
		}
		else if (GlobalScript.inst.gameState.data[62] >= 2)
		{
			for (int num = 0; num < 11; num++)
			{
				if (num < 7 || num > 9)
				{
					GlobalScript.inst.gameState.allcountries[1].parts[num] = false;
				}
			}
			GlobalScript.inst.gameState.allcountries[1].parts[1] = true;
		}
		else
		{
			for (int num2 = 0; num2 < 11; num2++)
			{
				if (num2 < 7 || num2 > 9)
				{
					GlobalScript.inst.gameState.allcountries[1].parts[num2] = false;
				}
			}
			GlobalScript.inst.gameState.allcountries[1].parts[10] = true;
		}
		return this;
	}
}
