using System;
using MoonSharp.Interpreter;

namespace KGEvent;

[Serializable]
[MoonSharpUserData]
public class QueryChina<T> where T : IRequesting<T>
{
	private T target;

	private int country = 2;

	public QueryChina(T target)
	{
		this.target = target;
	}

	public T PartySupportMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[1];
		return reference.CreateCondition(condition);
	}

	public T PartySupportLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[1];
		return reference.CreateCondition(condition);
	}

	public T SovietInfluenceMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[2];
		return reference.CreateCondition(condition);
	}

	public T SovietInfluenceLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[2];
		return reference.CreateCondition(condition);
	}

	public T AddSovietInfluence(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[1].power += value;
		};
		return reference.CreateActive(active);
	}

	public T PeopleSupportMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[3];
		return reference.CreateCondition(condition);
	}

	public T PeopleSupportLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[3];
		return reference.CreateCondition(condition);
	}

	public T PeopleLiberalizationMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[4];
		return reference.CreateCondition(condition);
	}

	public T PeopleLiberalizationLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[4];
		return reference.CreateCondition(condition);
	}

	public T StandardLivingMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[5];
		return reference.CreateCondition(condition);
	}

	public T StandardLivingLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[5];
		return reference.CreateCondition(condition);
	}

	public T DiplomaticReputationMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[6];
		return reference.CreateCondition(condition);
	}

	public T DiplomaticReputationLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[6];
		return reference.CreateCondition(condition);
	}

	public T InfluenceMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[7];
		return reference.CreateCondition(condition);
	}

	public T InfluenceLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[7];
		return reference.CreateCondition(condition);
	}

	public T MoneyMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[8];
		return reference.CreateCondition(condition);
	}

	public T MoneyLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[8];
		return reference.CreateCondition(condition);
	}

	public T AgentNetworkMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[9];
		return reference.CreateCondition(condition);
	}

	public T AgentNetworkLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[9];
		return reference.CreateCondition(condition);
	}

	public T AddAgentNetwork(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[9] += value;
		};
		return reference.CreateActive(active);
	}

	public T SciencePointMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[11];
		return reference.CreateCondition(condition);
	}

	public T SciencePointLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[11];
		return reference.CreateCondition(condition);
	}

	public T AddSciencePoint(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[11] += value;
		};
		return reference.CreateActive(active);
	}

	public T IndustryMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[12];
		return reference.CreateCondition(condition);
	}

	public T IndustryLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[12];
		return reference.CreateCondition(condition);
	}

	public T AddIndustry(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[12] += value;
		};
		return reference.CreateActive(active);
	}

	public T AgricultureMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[12];
		return reference.CreateCondition(condition);
	}

	public T AgricultureLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[12];
		return reference.CreateCondition(condition);
	}

	public T AddAgriculture(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[12] += value;
		};
		return reference.CreateActive(active);
	}

	public T IsAuthoritarianism()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[14] == 0;
		return reference.CreateCondition(condition);
	}

	public T EstablishAuthoritarianism()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[14] = 0;
		};
		return reference.CreateActive(active);
	}

	public T IsConservativeSocialism()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[14] == 1;
		return reference.CreateCondition(condition);
	}

	public T EstablishConservativeSocialism()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[14] = 1;
		};
		return reference.CreateActive(active);
	}

	public T IsSocialismWithNationalSpecifics()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[14] == 2;
		return reference.CreateCondition(condition);
	}

	public T EstablishSocialismWithNationalSpecifics()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[14] = 2;
		};
		return reference.CreateActive(active);
	}

	public T IsXiaopism()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[14] == 3;
		return reference.CreateCondition(condition);
	}

	public T EstablishXiaopism()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[14] = 3;
		};
		return reference.CreateActive(active);
	}

	public T IsSocialDemocracy()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[14] == 4;
		return reference.CreateCondition(condition);
	}

	public T EstablishSocialDemocracy()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[14] = 4;
		};
		return reference.CreateActive(active);
	}

	public T IsLiberalism()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[14] == 5;
		return reference.CreateCondition(condition);
	}

	public T EstablishLiberalism()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[14] = 5;
		};
		return reference.CreateActive(active);
	}

	public T IsNoParties()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[15] == 6;
		return reference.CreateCondition(condition);
	}

	public T EstablishNoParties()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[15] = 6;
		};
		return reference.CreateActive(active);
	}

	public T IsPeoplesParty()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[15] == 7;
		return reference.CreateCondition(condition);
	}

	public T EstablishPeoplesParty()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[15] = 7;
		};
		return reference.CreateActive(active);
	}

	public T IsLimitedMultiparty()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[15] == 8;
		return reference.CreateCondition(condition);
	}

	public T EstablishLimitedMultiparty()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[15] = 8;
		};
		return reference.CreateActive(active);
	}

	public T IsFreeMultiparty()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[15] == 9;
		return reference.CreateCondition(condition);
	}

	public T EstablishFreeMultiparty()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[15] = 9;
		};
		return reference.CreateActive(active);
	}

	public T IsLatePlan()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[16] == 10;
		return reference.CreateCondition(condition);
	}

	public T EstablishLatePlan()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[16] = 10;
		};
		return reference.CreateActive(active);
	}

	public T IsAutomatedPlan()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[16] == 11;
		return reference.CreateCondition(condition);
	}

	public T EstablishAutomatedPlan()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[16] = 11;
		};
		return reference.CreateActive(active);
	}

	public T IsMonopolyStateCapitalism()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[16] == 12;
		return reference.CreateCondition(condition);
	}

	public T EstablishMonopolyStateCapitalism()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[16] = 12;
		};
		return reference.CreateActive(active);
	}

	public T IsBirdsCage()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[16] == 13;
		return reference.CreateCondition(condition);
	}

	public T EstablishBirdsCage()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[16] = 13;
		};
		return reference.CreateActive(active);
	}

	public T IsMixed()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[16] == 14;
		return reference.CreateCondition(condition);
	}

	public T EstablishMixed()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[16] = 14;
		};
		return reference.CreateActive(active);
	}

	public T IsMinimumRegulation()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[16] == 15;
		return reference.CreateCondition(condition);
	}

	public T EstablishMinimumRegulation()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[16] = 15;
		};
		return reference.CreateActive(active);
	}

	public T IsTotalControl()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[17] == 16;
		return reference.CreateCondition(condition);
	}

	public T EstablishTotalControl()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[17] = 16;
		};
		return reference.CreateActive(active);
	}

	public T IsFixed()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[17] == 17;
		return reference.CreateCondition(condition);
	}

	public T EstablishFixed()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[17] = 17;
		};
		return reference.CreateActive(active);
	}

	public T IsPluralism()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[17] == 18;
		return reference.CreateCondition(condition);
	}

	public T EstablishPluralism()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[17] = 18;
		};
		return reference.CreateActive(active);
	}

	public T IsFullFree()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[17] == 19;
		return reference.CreateCondition(condition);
	}

	public T EstablishFullFree()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[17] = 19;
		};
		return reference.CreateActive(active);
	}

	public T IsTotalitarianism()
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.data[18] == 20;
		return reference.CreateCondition(condition);
	}

	public T EstablishTotalitarianism()
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[18] = 20;
		};
		return reference.CreateActive(active);
	}

	public T HaveModifer(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.modifies[value].active;
		return reference.CreateCondition(condition);
	}

	public T AddHaveModifer(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.modifies[value].active = true;
		};
		return reference.CreateActive(active);
	}

	public T RemoveHaveModifer(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.modifies[value].active = false;
		};
		return reference.CreateActive(active);
	}

	public T HaveScience(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.science[value];
		return reference.CreateCondition(condition);
	}

	public T AddHaveScience(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.science[value] = true;
		};
		return reference.CreateActive(active);
	}

	public T RemoveHaveScience(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.science[value] = false;
		};
		return reference.CreateActive(active);
	}

	public T AddOpinionRadical(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 0)
				{
					politic.loyality += value;
				}
			}
		};
		return reference.CreateActive(active);
	}

	public T AddOpinionMixed(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 1)
				{
					politic.loyality += value;
				}
			}
		};
		return reference.CreateActive(active);
	}

	public T AddOpinionReformost(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 2)
				{
					politic.loyality += value;
				}
			}
		};
		return reference.CreateActive(active);
	}

	public T AddOpinionLiberals(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			Politic[] politics = GlobalScript.inst.gameState.politics;
			foreach (Politic politic in politics)
			{
				if (politic.traits[0] == 3)
				{
					politic.loyality += value;
				}
			}
		};
		return reference.CreateActive(active);
	}

	public T AddPartySupport(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[1] += value;
		};
		return reference.CreateActive(active);
	}

	public T AddPeopleSupport(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[3] += value;
		};
		return reference.CreateActive(active);
	}

	public T AddPeopleLiberalization(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[4] += value;
		};
		return reference.CreateActive(active);
	}

	public T AddStandardLiving(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[5] += value;
		};
		return reference.CreateActive(active);
	}

	public T AddDiplomaticReputation(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[6] += value;
		};
		return reference.CreateActive(active);
	}

	public T AddInfluence(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[7] += value;
		};
		return reference.CreateActive(active);
	}

	public T AddMoney(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[8] += value;
		};
		return reference.CreateActive(active);
	}

	public T AddMaoWay(int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[88] += value;
		};
		return reference.CreateActive(active);
	}

	public T AddPoliticLoyality(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.politics[politic].loyality += value;
		};
		return reference.CreateActive(active);
	}

	public T AddModifer(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.modifies[value].active = true;
		return reference.CreateCondition(condition);
	}

	public T RemoveModifer(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.modifies[value].active = false;
		return reference.CreateCondition(condition);
	}

	public T AddScience(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.science[value] = true;
		return reference.CreateCondition(condition);
	}

	public T RemoveScience(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => GlobalScript.inst.gameState.science[value] = false;
		return reference.CreateCondition(condition);
	}

	public T StateDebtMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[69];
		return reference.CreateCondition(condition);
	}

	public T StateDebtLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[69];
		return reference.CreateCondition(condition);
	}

	public T AddStateDebt(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[69] += value;
		};
		return reference.CreateActive(active);
	}

	public T ArmyFundingMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[71];
		return reference.CreateCondition(condition);
	}

	public T ArmyFundingLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[71];
		return reference.CreateCondition(condition);
	}

	public T AddArmyFunding(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[71] += value;
		};
		return reference.CreateActive(active);
	}

	public T FinancingMGBMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[72];
		return reference.CreateCondition(condition);
	}

	public T FinancingMGBLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[72];
		return reference.CreateCondition(condition);
	}

	public T AddFinancingMGB(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[72] += value;
		};
		return reference.CreateActive(active);
	}

	public T FinancingScienceMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[73];
		return reference.CreateCondition(condition);
	}

	public T FinancingScienceLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[73];
		return reference.CreateCondition(condition);
	}

	public T AddFinancingScience(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[73] += value;
		};
		return reference.CreateActive(active);
	}

	public T FinancingStateApparatusMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[74];
		return reference.CreateCondition(condition);
	}

	public T FinancingStateApparatusLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[74];
		return reference.CreateCondition(condition);
	}

	public T AddFinancingStateApparatus(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[74] += value;
		};
		return reference.CreateActive(active);
	}

	public T EnvelopeBudgetMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[75];
		return reference.CreateCondition(condition);
	}

	public T EnvelopeBudgetLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[75];
		return reference.CreateCondition(condition);
	}

	public T AddEnvelopeBudget(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[75] += value;
		};
		return reference.CreateActive(active);
	}

	public T FundingPropagandaMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[76];
		return reference.CreateCondition(condition);
	}

	public T FundingPropagandaLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[76];
		return reference.CreateCondition(condition);
	}

	public T AddFundingPropaganda(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[76] += value;
		};
		return reference.CreateActive(active);
	}

	public T FinancingAgriculturalMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[77];
		return reference.CreateCondition(condition);
	}

	public T FinancingAgriculturalLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[77];
		return reference.CreateCondition(condition);
	}

	public T AddFinancingAgricultural(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[77] += value;
		};
		return reference.CreateActive(active);
	}

	public T FinancingIndustryMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[78];
		return reference.CreateCondition(condition);
	}

	public T FinancingIndustryLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[78];
		return reference.CreateCondition(condition);
	}

	public T AddFinancingIndustry(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[78] += value;
		};
		return reference.CreateActive(active);
	}

	public T FinancingServiceSectorMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[79];
		return reference.CreateCondition(condition);
	}

	public T FinancingServiceSectorLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[79];
		return reference.CreateCondition(condition);
	}

	public T AddFinancingServiceSector(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[79] += value;
		};
		return reference.CreateActive(active);
	}

	public T FinancingSocialPolicyMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[80];
		return reference.CreateCondition(condition);
	}

	public T FinancingSocialPolicyLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[80];
		return reference.CreateCondition(condition);
	}

	public T AddFinancingSocialPolicy(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[80] += value;
		};
		return reference.CreateActive(active);
	}

	public T FinancingDiplomaticMissionsMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[81];
		return reference.CreateCondition(condition);
	}

	public T FinancingDiplomaticMissionsLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[81];
		return reference.CreateCondition(condition);
	}

	public T AddFinancingDiplomaticMissions(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[81] += value;
		};
		return reference.CreateActive(active);
	}

	public T ServicesSectorMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[68];
		return reference.CreateCondition(condition);
	}

	public T ServicesSectorLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[68];
		return reference.CreateCondition(condition);
	}

	public T AddServicesSector(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[68] += value;
		};
		return reference.CreateActive(active);
	}

	public T MilitaryEstablishmentMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[51];
		return reference.CreateCondition(condition);
	}

	public T MilitaryEstablishmentLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[51];
		return reference.CreateCondition(condition);
	}

	public T AddMilitaryEstablishment(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[51] += value;
		};
		return reference.CreateActive(active);
	}

	public T RelationsWithUSSRMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[29];
		return reference.CreateCondition(condition);
	}

	public T RelationsWithUSSRLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[29];
		return reference.CreateCondition(condition);
	}

	public T AddRelationsWithUSSR(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[1].relations += value;
		};
		return reference.CreateActive(active);
	}

	public T RelationsWithUSAMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[28];
		return reference.CreateCondition(condition);
	}

	public T RelationsWithUSALess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[28];
		return reference.CreateCondition(condition);
	}

	public T AddRelationsWithUSA(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.empires[0].relations += value;
		};
		return reference.CreateActive(active);
	}

	public T ArmyStrengthMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[22];
		return reference.CreateCondition(condition);
	}

	public T ArmyStrengthLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[22];
		return reference.CreateCondition(condition);
	}

	public T AddArmyStrength(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[22] += value;
		};
		return reference.CreateActive(active);
	}

	public T CorruptionMore(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value < GlobalScript.inst.gameState.data[26];
		return reference.CreateCondition(condition);
	}

	public T CorruptionLess(int value)
	{
		ref T reference = ref target;
		Func<bool> condition = () => value > GlobalScript.inst.gameState.data[26];
		return reference.CreateCondition(condition);
	}

	public T AddCorruption(int politic, int value)
	{
		ref T reference = ref target;
		Action active = delegate
		{
			GlobalScript.inst.gameState.data[26] += value;
		};
		return reference.CreateActive(active);
	}
}
