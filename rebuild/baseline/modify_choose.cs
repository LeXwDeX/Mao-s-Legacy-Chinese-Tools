using UnityEngine;

public class modify_choose : MonoBehaviour
{
	public GlobalScript global1;

	public Sprite on;

	public Sprite off;

	public int num_this;

	public int num_names;

	public TextMesh Name_1;

	public TextMesh Name_2;

	public TextMesh Name_3;

	public TextMesh Text_1;

	public TextMesh Text_2;

	public TextMesh Text_3;

	private void Awake()
	{
		global1 = GlobalScript.inst;
	}

	private void OnMouseDown()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (num_this == 0)
			{
				num_names = 3;
				int num = GlobalScript.inst.gameState.data[23];
				Name_1.text = "当前数据（以1976年为%）";
				Name_3.text = "参与世界市场";
				Name_2.text = "Difference";
				if (GlobalScript.inst.gameState.modifies[12].active)
				{
					Text_1.text = "Our export:\n" + GlobalScript.inst.gameState.data[23] + "%（-15%）";
					num = GlobalScript.inst.gameState.data[23] - GlobalScript.inst.gameState.data[23] / 6;
				}
				else
				{
					Text_1.text = "Our export:\n" + GlobalScript.inst.gameState.data[23] + "%";
				}
				TextMesh text_ = Text_1;
				text_.text = text_.text + "\nNeed for import:\n" + GlobalScript.inst.gameState.data[24].ToString() + "% (" + GlobalScript.inst.gameState.ImportChange(GlobalScript.inst.gameState) + ")";
				Text_2.text = "% of 1975:\n" + (num - GlobalScript.inst.gameState.data[24]) + "%";
				if (num > GlobalScript.inst.gameState.data[24])
				{
					text_ = Text_2;
					text_.text = text_.text + "\nProfit from deals\n(fortnight): +" + (num - GlobalScript.inst.gameState.data[24]) / 20 + "." + Mathf.Abs((num - GlobalScript.inst.gameState.data[24]) / 2 % 10);
					text_ = Text_2;
					text_.text = text_.text + "\nSupport of the people\n(fortnight): +" + (num - GlobalScript.inst.gameState.data[24]) / 30 + "." + Mathf.Abs((num - GlobalScript.inst.gameState.data[24]) / 3 % 10);
				}
				else
				{
					text_ = Text_2;
					text_.text = text_.text + "\nProfit from deals\n(fortnight): -" + (num - GlobalScript.inst.gameState.data[24]) / 20 + "." + Mathf.Abs((num - GlobalScript.inst.gameState.data[24]) / 2 % 10);
					text_ = Text_2;
					text_.text = text_.text + "\nSupport of the people\n(fortnight): -" + (num - GlobalScript.inst.gameState.data[24]) / 30 + "." + Mathf.Abs((num - GlobalScript.inst.gameState.data[24]) / 3 % 10);
					text_ = Text_2;
					text_.text = text_.text + "\nStandard of living\n(fortnight): -" + (num - GlobalScript.inst.gameState.data[24]) / 40 + "." + Mathf.Abs((num - GlobalScript.inst.gameState.data[24]) / 4 % 10);
				}
				if (GlobalScript.inst.gameState.data[25] <= 4)
				{
					Text_3.text = "Isolation";
					text_ = Text_3;
					text_.text = text_.text + "\nLiberalization (fortnight): -" + (-5 + GlobalScript.inst.gameState.data[25]) / 10 + "." + Mathf.Abs((-5 + GlobalScript.inst.gameState.data[25]) % 10);
					text_ = Text_3;
					text_.text = text_.text + "\nAgents (fortnight): -" + (-5 + GlobalScript.inst.gameState.data[25]) / 10 + "." + Mathf.Abs((-5 + GlobalScript.inst.gameState.data[25]) % 10);
				}
				else if (GlobalScript.inst.gameState.data[25] > 12)
				{
					Text_3.text = "Globalizationя";
					text_ = Text_3;
					text_.text = text_.text + "\nLiberalization (fortnight): +" + (GlobalScript.inst.gameState.data[25] - 12) / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[25] - 12) % 10);
					text_ = Text_3;
					text_.text = text_.text + "\nAgents (fortnight): -" + (GlobalScript.inst.gameState.data[25] - 12) / 20 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[25] - 12) % 20);
				}
				else
				{
					Text_3.text = "收支平衡";
				}
			}
			else if (num_this == 1)
			{
				num_names = 3;
				Name_1.text = "世界影响力";
				Name_2.text = "苏联领导人";
				Name_3.text = "军备竞赛";
				Text_1.text = "\n<color=red>Soviet world influence:</color>\n" + GlobalScript.inst.gameState.empires[1].power / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.empires[1].power % 10);
				TextMesh text_ = Text_1;
				text_.text = text_.text + "\n<color=blue>American world influence:</color>\n" + GlobalScript.inst.gameState.empires[0].power / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.empires[0].power % 10);
				Text_1.text += "\nDetermines the USA and USSR's influence on Africa.";
				if (GlobalScript.inst.gameState.empires[1].now_leader == 0)
				{
					Text_2.text = "列昂尼德·勃列日涅夫";
					Text_2.text += "\nIncreases Soviet spending on Africa;\nIf we haven't restored relations:\nRelations with the USA +0.5\nand -0.2 Unity;";
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 1)
				{
					Text_2.text = "尤里·安德罗波夫";
					Text_2.text += "\nIf we haven't restored relations:\nRelations with the USA +0.5;\nOtherwise:\n+ to the power of reformist politicians";
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 2)
				{
					Text_2.text = "康斯坦丁·切尔年科";
					Text_2.text += "\nRelations with the USSR +0.5;\nIf we've restored relations:\n+ to the power of moderate politicians";
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 3)
				{
					Text_2.text = "弗拉基米尔·谢尔比茨基";
					Text_2.text += "\nIf we haven't restored relations:\nRelations with the USA +0.5\nand -0.2 Unity;\nOtherwise:\nRelations with the USSR +0.5";
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
				{
					Text_2.text = "米哈伊尔·戈尔巴乔夫";
					Text_2.text += "\nReduces Soviet spending on Africa;\nRelations with the USSR +0.5\nand +0.5 Minds Liberalization\nand + to the power of liberal politicians;";
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 5)
				{
					Text_2.text = "维克托·格里申";
					Text_2.text += "\nRelations with the USSR +0.5;\nIf we've restored relations:\n+ to the power of reformist politicians";
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 4)
				{
					Text_2.text = "格里戈里·罗曼诺夫";
					Text_2.text += "\nIf we haven't restored relations:\n-0.5 Agents;\nOtherwise:\nRelations with the USSR +0.5 and +0.5 agents";
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 7)
				{
					Text_2.text = "亚历山大·雅科夫列夫";
				}
				else if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
				{
					Text_2.text = "叶戈尔·利加乔夫";
					Text_2.text += "\nReduces Soviet spending on Africa;\nRelations with the USSR +0.5\nand +0.5 Minds Liberalization;";
				}
				if (GlobalScript.inst.gameState.allcountries[1].okb)
				{
					int num2 = 0;
					int num3 = 0;
					num2 = GlobalScript.inst.gameState.empires[1].power;
					num3 = GlobalScript.inst.gameState.empires[0].power;
					for (int i = 0; i < GlobalScript.inst.gameState.ingamewars.Length; i++)
					{
						if (GlobalScript.inst.gameState.ingamewars[i].is_going)
						{
							num2 -= num2 / 9;
							num3 -= num3 / 9;
						}
					}
					if (GlobalScript.inst.gameState.data[69] > 7)
					{
						num3 += GlobalScript.inst.gameState.data[69] / 7;
					}
					if (GlobalScript.inst.gameState.empires[1].now_leader == 0)
					{
						num2 += 20;
					}
					Text_3.text = "<color=red>与苏联的实力差距：</color>" + (GlobalScript.inst.gameState.data[22] - num2) / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[22] - num2) % 10);
					if (GlobalScript.inst.gameState.data[22] > num2)
					{
						Text_3.text += "\nStability in our african countries +2.5";
						if (GlobalScript.inst.gameState.allcountries[1].okb)
						{
							Text_3.text += "\nStability of regimes in our alliance: +1.0";
						}
					}
					else if (GlobalScript.inst.gameState.data[22] < num2 && GlobalScript.inst.gameState.influencePRC > 0)
					{
						text_ = Text_3;
						text_.text = text_.text + "\nStability of regimes in our alliance: -" + (GlobalScript.inst.gameState.data[22] - num2) / 20 / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[22] - num2) / 20 % 10);
					}
					text_ = Text_3;
					text_.text = text_.text + "\n<color=blue>Difference in power with the USA: </color>" + (GlobalScript.inst.gameState.data[22] - num3) / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[22] - num3) % 10);
					if (GlobalScript.inst.gameState.data[22] > num3)
					{
						Text_3.text += "\nStability in our african countries +2.5";
						if (GlobalScript.inst.gameState.allcountries[1].okb)
						{
							Text_3.text += "\nStability of regimes in our alliance: +1.0";
						}
					}
					else if (GlobalScript.inst.gameState.data[22] < num3 && GlobalScript.inst.gameState.influencePRC > 0)
					{
						text_ = Text_3;
						text_.text = text_.text + "\nStability of regimes in our alliance: -" + (GlobalScript.inst.gameState.data[22] - num3) / 20 / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[22] - num3) / 20 % 10);
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[15].cw)
				{
					Text_3.text = "<color=red>不结盟运动成员</color>";
					Text_3.text += "\nRelations with the USSR (2 weeks): +0.5 (till 70)";
					Text_3.text += "\nRelations with the US (2 weeks): +0.5 (till 70)";
					Text_3.text += "\nMoney from your budget (2 weeks): -0.2";
					if (GlobalScript.inst.gameState.data[6] > 600)
					{
						Text_3.text += "\nInternational reputation (2 weeks): -0.2";
					}
					else if (GlobalScript.inst.gameState.data[6] < 400)
					{
						Text_3.text += "\nInternational reputation (2 weeks): +0.2";
					}
				}
				else
				{
					Text_3.text = "我们不是军备竞赛的成员";
				}
			}
			else if (num_this == 5)
			{
				num_names = 3;
				Name_1.text = "世界观";
				Name_2.text = "特殊影响力";
				Name_3.text = "Population";
				Text_1.text = "Nowadays:";
				TextMesh text_;
				if (GlobalScript.inst.gameState.data[31] > 700)
				{
					text_ = Text_1;
					text_.text = text_.text + "\nHarsh unification\n(" + GlobalScript.inst.gameState.data[31] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[31] % 10) + "/100)";
					Text_2.text = "Liberalization\nfortnight: -" + (GlobalScript.inst.gameState.data[31] - 500) / 100 / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[31] - 500) / 100 % 10);
					text_ = Text_2;
					text_.text = text_.text + "\nSupport of the Party\nfortnight: +" + (GlobalScript.inst.gameState.data[31] - 500) / 100 / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[31] - 500) / 100 % 10);
					text_ = Text_2;
					text_.text = text_.text + "\nAgents (fortnight): +" + (GlobalScript.inst.gameState.data[31] - 500) / 1000 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[31] - 500) / 100 % 10);
					Text_2.text += "\nWorld reputation\nif below 50.0: +0.5";
				}
				else if (GlobalScript.inst.gameState.data[31] >= 400 && GlobalScript.inst.gameState.data[31] <= 700)
				{
					text_ = Text_1;
					text_.text = text_.text + "\nSeveral peoples\n(" + GlobalScript.inst.gameState.data[31] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[31] % 10) + "/100)";
					Text_2.text = "Nothing".ToString();
				}
				else
				{
					text_ = Text_1;
					text_.text = text_.text + "\nMulticulturalism\n(" + GlobalScript.inst.gameState.data[31] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[31] % 10) + "/100)";
					Text_2.text = "Liberalization\nfortnight: +" + (500 - GlobalScript.inst.gameState.data[31]) / 100 / 10 + "." + Mathf.Abs((500 - GlobalScript.inst.gameState.data[31]) / 100 % 10);
					text_ = Text_2;
					text_.text = text_.text + "\nSupport of the Party\nfortnight: +" + (500 - GlobalScript.inst.gameState.data[31]) / 100 / 10 + "." + Mathf.Abs((500 - GlobalScript.inst.gameState.data[31]) / 100 % 10);
					text_ = Text_2;
					text_.text = text_.text + "\nAgents (fortnight): -" + (GlobalScript.inst.gameState.data[31] - 500) / 1000 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[31] - 500) / 100 % 10);
					text_ = Text_2;
					text_.text = text_.text + "\nRelations\nfortnight: +" + (500 - GlobalScript.inst.gameState.data[31]) / 100 / 10 + "." + Mathf.Abs((500 - GlobalScript.inst.gameState.data[31]) / 100 % 10);
				}
				text_ = Text_1;
				text_.text = text_.text + "\n\nChinese unity level:\n(" + GlobalScript.inst.gameState.data[57] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[57] % 10) + "/100)";
				Text_3.text = GlobalScript.inst.gameState.data[34] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[34]) % 10 + "百万（" + (((GlobalScript.inst.gameState.data_old[34] < 0) ? "-" : "+") + Mathf.Abs(GlobalScript.inst.gameState.data_old[34] / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.data_old[34] % 10) + ")";
				int[] array = new int[5] { 0, 0, 0, 0, 0 };
				if (GlobalScript.inst.gameState.data[16] == 11)
				{
					array[0] += GlobalScript.inst.gameState.data[34] / 5000;
				}
				else if (GlobalScript.inst.gameState.data[16] == 10)
				{
					array[0] += GlobalScript.inst.gameState.data[34] / 5000;
				}
				else if (GlobalScript.inst.gameState.data[16] == 13)
				{
					array[3] += Mathf.RoundToInt((float)(GlobalScript.inst.gameState.data[34] - 9037) / 3000f + 1f);
				}
				else if (GlobalScript.inst.gameState.data[16] == 14 && !GlobalScript.inst.gameState.modifies[13].active)
				{
					array[1] -= GlobalScript.inst.gameState.data[34] / 4000;
					array[3] += Mathf.RoundToInt((float)(GlobalScript.inst.gameState.data[34] - 9037) / 2000f + 1f);
				}
				else if (GlobalScript.inst.gameState.data[16] == 15 && !GlobalScript.inst.gameState.modifies[13].active)
				{
					array[1] -= GlobalScript.inst.gameState.data[34] / 4000;
					array[3] += Mathf.RoundToInt((float)(GlobalScript.inst.gameState.data[34] - 9037) / 1000f + 1f);
				}
				if ((GlobalScript.inst.gameState.data[34] - 9307) / 200 > 0)
				{
					array[2] -= (GlobalScript.inst.gameState.data[34] - 9307) / 200;
				}
				if (GlobalScript.inst.gameState.data[51] == 30)
				{
					if (GlobalScript.inst.gameState.data[34] - 9307 > 99)
					{
						array[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 100;
						array[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 100;
					}
				}
				else if (GlobalScript.inst.gameState.data[51] == 31)
				{
					if (GlobalScript.inst.gameState.data[34] - 9307 > 199)
					{
						array[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 200;
						array[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 200;
					}
				}
				else if (GlobalScript.inst.gameState.data[51] == 32)
				{
					if (GlobalScript.inst.gameState.data[34] - 9307 > 299)
					{
						array[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 300;
						array[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 300;
					}
				}
				else if (GlobalScript.inst.gameState.data[51] == 33 && GlobalScript.inst.gameState.data[34] - 9307 > 149)
				{
					if (GlobalScript.inst.gameState.data[5] < 500)
					{
						array[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 150;
						array[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 250;
					}
					else if (GlobalScript.inst.gameState.data[5] < 700)
					{
						array[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 150;
						array[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 300;
					}
					else
					{
						array[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 500;
						array[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 500;
					}
				}
				text_ = Text_3;
				text_.text = text_.text + "\nIndustry: " + (((array[0] < 0) ? "-" : "+") + Mathf.Abs(array[0] / 10)).ToString() + "." + Mathf.Abs(array[0] % 10);
				text_ = Text_3;
				text_.text = text_.text + "; Budget: " + (((array[3] < 0) ? "-" : "+") + Mathf.Abs(array[3] / 10)).ToString() + "." + Mathf.Abs(array[3] % 10);
				text_ = Text_3;
				text_.text = text_.text + "\nAgent networks: " + (((array[2] < 0) ? "-" : "+") + Mathf.Abs(array[2] / 10)).ToString() + "." + Mathf.Abs(array[2] % 10);
				text_ = Text_3;
				text_.text = text_.text + "; Army power: " + (((array[4] < 0) ? "-" : "+") + Mathf.Abs(array[4] / 10)).ToString() + "." + Mathf.Abs(array[4] % 10);
				text_ = Text_3;
				text_.text = text_.text + "\nPeople's support: " + (((array[1] < 0) ? "-" : "+") + Mathf.Abs(array[1] / 10)).ToString() + "." + Mathf.Abs(array[1] % 10);
			}
			else if (num_this == 4)
			{
				num_names = 3;
				Name_1.text = "Iran";
				Name_2.text = "Afghanistan";
				Name_3.text = "美国总统";
				Text_1.text = "Power of monarchists: \n" + GlobalScript.inst.gameState.data[43] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[43] % 10);
				TextMesh text_ = Text_1;
				text_.text = text_.text + "\nPower of leftists: \n" + GlobalScript.inst.gameState.data[42] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[42] % 10);
				text_ = Text_1;
				text_.text = text_.text + "\nPower of islamists: \n" + GlobalScript.inst.gameState.data[45] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[45] % 10);
				text_ = Text_1;
				text_.text = text_.text + "\nPower of liberals: \n" + GlobalScript.inst.gameState.data[44] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[44] % 10);
				Text_2.text = "Power of maoists: \n" + GlobalScript.inst.gameState.data[46] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[46] % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nPower of Khalq: \n" + GlobalScript.inst.gameState.data[48] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[48] % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nPower of Parcham: \n" + GlobalScript.inst.gameState.data[49] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[49] % 10);
				if (GlobalScript.inst.gameState.data[21] < 1977)
				{
					Text_3.text = "杰拉尔德·福特";
				}
				else if (GlobalScript.inst.gameState.data[21] < 1981)
				{
					Text_3.text = "吉米·卡特";
				}
				else if (GlobalScript.inst.gameState.empires[0].now_leader == 1)
				{
					Text_3.text = "吉米·卡特";
				}
				else if (GlobalScript.inst.gameState.empires[0].now_leader == 0)
				{
					Text_3.text = "罗纳德·里根";
				}
				else if (GlobalScript.inst.gameState.empires[0].now_leader == 2)
				{
					Text_3.text = "乔治·H·W·布什";
				}
				else if (GlobalScript.inst.gameState.empires[0].now_leader == 3)
				{
					Text_3.text = "沃尔特·蒙代尔";
				}
				if (GlobalScript.inst.gameState.data[21] >= 1981 && GlobalScript.inst.gameState.empires[0].now_leader <= 0)
				{
					Text_3.text += "\nUS Spending on External Interventions:\n+0.5\nLiberalization of minds:\n+0.5";
				}
				else if (GlobalScript.inst.gameState.empires[0].now_leader == 1 || (GlobalScript.inst.gameState.data[21] >= 1977 && GlobalScript.inst.gameState.data[21] < 1981))
				{
					Text_3.text += "\nRelations with the US:\n+1.0";
				}
				else if (GlobalScript.inst.gameState.empires[0].now_leader == 2)
				{
					Text_3.text += "\nUS Spending on External Interventions:\n+0.5\nRelations with the US: +0.5\nif we are not in alliances";
				}
				else if (GlobalScript.inst.gameState.empires[0].now_leader == 3)
				{
					Text_3.text += "\nImpact from the Maoist button\nin Western Europe - x1.5\nLoans are repaid\nevery 2 months";
				}
			}
			else if (num_this == 2)
			{
				num_names = 3;
				Name_1.text = "China";
				Name_2.text = "Taiwan";
				Name_3.text = "阿鲁纳恰尔邦";
				if (GlobalScript.inst.gameState.data[67] <= 0)
				{
					Text_1.text = "Tibet is part of China\n";
				}
				else if (GlobalScript.inst.gameState.data[67] == 1)
				{
					Text_1.text = "Republic of Tibet - sovereign\n";
				}
				else if (GlobalScript.inst.gameState.data[67] == 2)
				{
					Text_1.text = "Republic of Tibet - sovereign theocracy\n";
				}
				if (GlobalScript.inst.gameState.data[66] <= 0)
				{
					Text_1.text += "Xinjiang is part of China\n";
				}
				else if (GlobalScript.inst.gameState.data[66] == 1)
				{
					Text_1.text += "Xinjiang - soviet puppet\n";
				}
				else if (GlobalScript.inst.gameState.data[66] == 2)
				{
					Text_1.text += "Islamic Republic of Uyguristan - sovereign\n";
				}
				if (GlobalScript.inst.gameState.data[65] <= 0)
				{
					Text_1.text += "Hong Kong and Macau is foreign owned\n";
				}
				else if (GlobalScript.inst.gameState.data[65] == 1)
				{
					Text_1.text += "Hong Kong and Macao - special areas of china\n";
				}
				else if (GlobalScript.inst.gameState.data[65] == 2)
				{
					Text_1.text += "Hong Kong and Macao became part of China\n";
				}
				if (GlobalScript.inst.gameState.allcountries[7].parts[1] || GlobalScript.inst.gameState.allcountries[7].parts[2])
				{
					Text_1.text += "Mongolia is part of the USSR\n";
				}
				else if (GlobalScript.inst.gameState.allcountries[9].prosov && !GlobalScript.inst.gameState.completedDecisions[19])
				{
					Text_1.text += "Mongolia is an independent, pro-Soviet state\n";
				}
				else if (GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19])
				{
					Text_1.text += "Mongolia is an independent pro-Chinese state\n";
				}
				else if (!GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19] && !GlobalScript.inst.gameState.allcountries[9].prosov)
				{
					Text_1.text += "Mongolia is an independent neutral state\n";
				}
				else
				{
					Text_1.text += "Mongolia became part of China\n";
				}
				if (GlobalScript.inst.gameState.data[167] == 0)
				{
					Text_1.text += "Diaoyu Islands - Belongs to Japan\n";
				}
				else if (GlobalScript.inst.gameState.data[167] == 1)
				{
					Text_1.text += "Diaoyu Islands - Belongs to China\n";
				}
				else if (GlobalScript.inst.gameState.data[167] == 2)
				{
					Text_1.text += "Diaoyu Islands - Jointly owned by China and Japan\n";
				}
				if (GlobalScript.inst.gameState.data[64] == 2 || GlobalScript.inst.gameState.completedDecisions[6] || GlobalScript.inst.gameState.completedDecisions[7])
				{
					Text_2.text = "Taiwan - autonomous region of China\n";
				}
				else if (GlobalScript.inst.gameState.data[64] <= 0)
				{
					Text_2.text = "Republic of China is under control of Kuomintang\n(authoritarian, partially recognized)\n";
				}
				else if (GlobalScript.inst.gameState.data[64] == 1)
				{
					Text_2.text = "Republic of Taiwan - sovereign state\n(liberal, recognized by all)\n";
				}
				if (GlobalScript.inst.gameState.data[63] <= 0)
				{
					Text_2.text += "Islands near Taiwan under control\nof Kuomintang.\n";
				}
				else if (GlobalScript.inst.gameState.data[63] == 1)
				{
					Text_2.text += "Islands near Taiwan under control\nof our military.\n";
				}
				if (GlobalScript.inst.gameState.data[62] <= 0)
				{
					Text_3.text = "Under indian control, but wasn't recognized by us\n";
				}
				else if (GlobalScript.inst.gameState.data[62] == 1)
				{
					Text_3.text = "We recognized indian control of these lands\n";
				}
				else if (GlobalScript.inst.gameState.data[62] == 2 || GlobalScript.inst.gameState.data[62] == 3)
				{
					Text_3.text = "We regained control of these lands.\n";
				}
			}
			else if (num_this == 6)
			{
				num_names = 1;
				Name_1.text = "我们的盟友";
				if (GlobalScript.inst.gameState.allcountries[1].econ)
				{
					Text_1.text = "<color=red>国家 - 同盟 - 倾向 - 稳定度</color>";
					for (int j = 0; j < GlobalScript.inst.gameState.allcountries.Length; j++)
					{
						switch (j)
						{
						default:
							if (j < 106 || j >= 109)
							{
								continue;
							}
							break;
						case 8:
						case 11:
						case 12:
						case 14:
						case 19:
						case 22:
						case 23:
						case 31:
						case 32:
						case 33:
						case 34:
						case 35:
						case 43:
						case 46:
						case 47:
						case 48:
						case 49:
						case 50:
						case 52:
						case 53:
						case 54:
						case 55:
						case 56:
						case 57:
						case 58:
						case 59:
						case 60:
						case 61:
						case 62:
						case 63:
						case 64:
						case 65:
						case 66:
						case 67:
						case 68:
						case 96:
						case 97:
							break;
						}
						if (GlobalScript.inst.gameState.allcountries[j].econ && GlobalScript.inst.gameState.allcountries[j].okb)
						{
							TextMesh text_ = Text_1;
							text_.text = text_.text + "\n" + GlobalScript.inst.gameState.allcountries[j].name + " - 双方 - " + (GlobalScript.inst.gameState.allcountries[j].proprc ? "Yes - " : "No - ") + GlobalScript.inst.gameState.allcountries[j].soc_stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[j].soc_stab % 10);
						}
						else if (GlobalScript.inst.gameState.allcountries[j].econ)
						{
							TextMesh text_ = Text_1;
							text_.text = text_.text + "\n" + GlobalScript.inst.gameState.allcountries[j].name + " - 经济 - " + (GlobalScript.inst.gameState.allcountries[j].proprc ? "Yes - " : "No - ") + GlobalScript.inst.gameState.allcountries[j].soc_stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[j].soc_stab % 10);
						}
						else if (GlobalScript.inst.gameState.allcountries[j].okb)
						{
							TextMesh text_ = Text_1;
							text_.text = text_.text + "\n" + GlobalScript.inst.gameState.allcountries[j].name + " - 军事 - " + (GlobalScript.inst.gameState.allcountries[j].proprc ? "Yes - " : "No - ") + GlobalScript.inst.gameState.allcountries[j].soc_stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[j].soc_stab % 10);
						}
					}
				}
				else
				{
					Text_1.text = "我们没有自己的同盟";
				}
			}
		}
		else if (num_this == 0)
		{
			num_names = 3;
			int num4 = GlobalScript.inst.gameState.data[23];
			Name_1.text = "Текущие данные в % от 1976";
			Name_3.text = "Участие в мировом рынке";
			Name_2.text = "Разница";
			if (GlobalScript.inst.gameState.modifies[12].active)
			{
				Text_1.text = "Наш экспорт:\n" + GlobalScript.inst.gameState.data[23] + "%（-15%）";
				num4 = GlobalScript.inst.gameState.data[23] - GlobalScript.inst.gameState.data[23] / 6;
			}
			else
			{
				Text_1.text = "Наш экспорт:\n" + GlobalScript.inst.gameState.data[23] + "%";
			}
			TextMesh text_ = Text_1;
			text_.text = text_.text + "\nНужда в импорте:\n" + GlobalScript.inst.gameState.data[24].ToString() + "% (" + GlobalScript.inst.gameState.ImportChange(GlobalScript.inst.gameState) + ")";
			Text_2.text = "% от 1975:\n" + (num4 - GlobalScript.inst.gameState.data[24]) + "%";
			if (num4 > GlobalScript.inst.gameState.data[24])
			{
				text_ = Text_2;
				text_.text = text_.text + "\nВыручка от сделок\n(в 2 недели): +" + (num4 - GlobalScript.inst.gameState.data[24]) / 20 + "." + Mathf.Abs((num4 - GlobalScript.inst.gameState.data[24]) / 2 % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nУдовлетворение народа\n(в 2 недели): +" + (num4 - GlobalScript.inst.gameState.data[24]) / 30 + "." + Mathf.Abs((num4 - GlobalScript.inst.gameState.data[24]) / 3 % 10);
			}
			else
			{
				text_ = Text_2;
				text_.text = text_.text + "\nВыручка от сделок\n(в 2 недели): -" + (num4 - GlobalScript.inst.gameState.data[24]) / 20 + "." + Mathf.Abs((num4 - GlobalScript.inst.gameState.data[24]) / 2 % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nУдовлетворение народа\n(в 2 недели): -" + (num4 - GlobalScript.inst.gameState.data[24]) / 30 + "." + Mathf.Abs((num4 - GlobalScript.inst.gameState.data[24]) / 3 % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nУровень жизни\n(в 2 недели): -" + (num4 - GlobalScript.inst.gameState.data[24]) / 40 + "." + Mathf.Abs((num4 - GlobalScript.inst.gameState.data[24]) / 4 % 10);
			}
			if (GlobalScript.inst.gameState.data[25] <= 4)
			{
				Text_3.text = "Изоляция";
				text_ = Text_3;
				text_.text = text_.text + "\nЛиберализация (в 2 недели): -" + (-5 + GlobalScript.inst.gameState.data[25]) / 10 + "." + Mathf.Abs((-5 + GlobalScript.inst.gameState.data[25]) % 10);
				text_ = Text_3;
				text_.text = text_.text + "\nАгенты (в 2 недели): -" + (-5 + GlobalScript.inst.gameState.data[25]) / 10 + "." + Mathf.Abs((-5 + GlobalScript.inst.gameState.data[25]) % 10);
			}
			else if (GlobalScript.inst.gameState.data[25] > 12)
			{
				Text_3.text = "Глобализация";
				text_ = Text_3;
				text_.text = text_.text + "\nЛиберализация (в 2 недели): +" + (GlobalScript.inst.gameState.data[25] - 12) / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[25] - 12) % 10);
				text_ = Text_3;
				text_.text = text_.text + "\nАгенты (в 2 недели): -" + (GlobalScript.inst.gameState.data[25] - 12) / 20 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[25] - 12) % 20);
			}
			else
			{
				Text_3.text = "Баланс";
			}
		}
		else if (num_this == 1)
		{
			num_names = 3;
			Name_1.text = "Мировое влияние";
			Name_2.text = "Лидер СССР";
			Name_3.text = "Гонка вооружений";
			Text_1.text = "\n<color=red>Мировое влияние СССР:</color>\n" + GlobalScript.inst.gameState.empires[1].power / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.empires[1].power % 10);
			TextMesh text_ = Text_1;
			text_.text = text_.text + "\n<color=blue>Мировое влияние США:</color>\n" + GlobalScript.inst.gameState.empires[0].power / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.empires[0].power % 10);
			Text_1.text += "\nЭто влияет на силу США и СССР в Африке.";
			if (GlobalScript.inst.gameState.empires[1].now_leader == 0)
			{
				Text_2.text = "Леонид Брежнев";
				Text_2.text += "\nУвеличивает советские траты на Африку;\nЕсли мы не восстановили отношения:\nОтношения с США +0.5\nи -0.2 Единства;";
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 1)
			{
				Text_2.text = "Юрий Андропов";
				Text_2.text += "\nЕсли мы не восстановили отношения:\nОтношения с США +0.5;\nИначе:\n+ к силе политиков-реформистов";
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 2)
			{
				Text_2.text = "Константин Черненко";
				Text_2.text += "\nОтношения с СССР +0.5;\nЕсли мы восстановили отношения:\n+ к силе политиков-умеренных";
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 3)
			{
				Text_2.text = "Владимир Щербицкий";
				Text_2.text += "\nЕсли мы не восстановили отношения:\nОтношения с США +0.5\nи -0.2 Единства;\nИначе:\nОтношения с СССР +0.5";
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
			{
				Text_2.text = "Михаил Горбачёв";
				Text_2.text += "\nСокращает советские траты на Африку;\nОтношения с СССР +0.5\nи +0.5 Либерализация умов\nи + к силе политиков-либералов;";
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 5)
			{
				Text_2.text = "Виктор Гришин";
				Text_2.text += "\nОтношения с СССР +0.5;\nЕсли мы восстановили отношения:\n+ к силе политиков-реформистов";
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 4)
			{
				Text_2.text = "Григорий Романов";
				Text_2.text += "\nЕсли мы не восстановили отношения:\n-0.5 Агентов;\nИначе:\nОтношения с СССР +0.5 и +0.5 агентов";
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 7)
			{
				Text_2.text = "Александр Яковлев";
			}
			else if (GlobalScript.inst.gameState.empires[1].now_leader == 8)
			{
				Text_2.text = "Егор Лигачев";
				Text_2.text += "\nСокращает советские траты на Африку;\nОтношения с СССР +0.5\nи +0.5 Либерализация умов;";
			}
			if (GlobalScript.inst.gameState.allcountries[1].okb)
			{
				int num5 = 0;
				int num6 = 0;
				num5 = GlobalScript.inst.gameState.empires[1].power;
				num6 = GlobalScript.inst.gameState.empires[0].power;
				for (int k = 0; k < GlobalScript.inst.gameState.ingamewars.Length; k++)
				{
					if (GlobalScript.inst.gameState.ingamewars[k].is_going)
					{
						num5 -= num5 / 9;
						num6 -= num6 / 9;
					}
				}
				if (GlobalScript.inst.gameState.data[69] > 7)
				{
					num6 += GlobalScript.inst.gameState.data[69] / 7;
				}
				if (GlobalScript.inst.gameState.empires[1].now_leader == 0)
				{
					num5 += 20;
				}
				Text_3.text = "<color=red>Разница в силе с СССР: </color>" + (GlobalScript.inst.gameState.data[22] - num5) / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[22] - num5) % 10);
				if (GlobalScript.inst.gameState.data[22] > num5)
				{
					Text_3.text += "\nСтабильность в наших африканских странах +2.5";
					if (GlobalScript.inst.gameState.allcountries[1].okb)
					{
						Text_3.text += "\nСтабильность режимов в нашем альянсе: +1.0";
					}
				}
				else if (GlobalScript.inst.gameState.data[22] <= num5 && GlobalScript.inst.gameState.influencePRC > 0)
				{
					text_ = Text_3;
					text_.text = text_.text + "\nСтабильность режимов в нашем альянсе: -" + (GlobalScript.inst.gameState.data[22] - num5) / 20 / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[22] - num5) / 20 % 10);
				}
				text_ = Text_3;
				text_.text = text_.text + "\n<color=blue>Разница в силе с США: </color>" + (GlobalScript.inst.gameState.data[22] - num6) / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[22] - num6) % 10);
				if (GlobalScript.inst.gameState.data[22] > num6)
				{
					Text_3.text += "\nСтабильность в наших африканских странах +2.5";
					if (GlobalScript.inst.gameState.allcountries[1].okb)
					{
						Text_3.text += "\nСтабильность режимов в нашем альянсе: +1.0";
					}
				}
				else if (GlobalScript.inst.gameState.data[22] <= num6 && GlobalScript.inst.gameState.influencePRC > 0)
				{
					text_ = Text_3;
					text_.text = text_.text + "\nСтабильность режимов в нашем альянсе: -" + (GlobalScript.inst.gameState.data[22] - num6) / 20 / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[22] - num6) / 20 % 10);
				}
			}
			else if (GlobalScript.inst.gameState.allcountries[15].cw)
			{
				Text_3.text = "<color=red>Состоим в Движении неприсоединения</color>";
				Text_3.text += "\nОтношения с СССР (2 недели): +0.5 (до 70)";
				Text_3.text += "\nОтношения с США (2 недели): +0.5 (до 70)";
				Text_3.text += "\nДеньги из Бюджета (2 недели): -0.2";
				if (GlobalScript.inst.gameState.data[6] > 600)
				{
					Text_3.text += "\nМеждународная репутация (2 недели): -0.2";
				}
				else if (GlobalScript.inst.gameState.data[6] < 400)
				{
					Text_3.text += "\nМеждународная репутация (2 недели): +0.2";
				}
			}
			else
			{
				Text_3.text = "Мы не участники Гонки вооружений";
			}
		}
		else if (num_this == 5)
		{
			num_names = 3;
			Name_1.text = "Мировоззрение";
			Name_2.text = "Особое влияние";
			Name_3.text = "Количество населения:";
			Text_1.text = "Сейчас:";
			TextMesh text_;
			if (GlobalScript.inst.gameState.data[31] > 700)
			{
				text_ = Text_1;
				text_.text = text_.text + "\nЖёсткая унификация\n(" + GlobalScript.inst.gameState.data[31] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[31] % 10) + "/100)";
				Text_2.text = "Либерализация\nв 2 недели: -" + (GlobalScript.inst.gameState.data[31] - 500) / 100 / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[31] - 500) / 100 % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nПоддержка партии\nв 2 недели: +" + (GlobalScript.inst.gameState.data[31] - 500) / 100 / 10 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[31] - 500) / 100 % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nАгенты (в 2 недели): +" + (GlobalScript.inst.gameState.data[31] - 500) / 1000 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[31] - 500) / 100 % 10);
				Text_2.text += "\nМеждународная репутация\nесли ниже 50.0: +0.5";
			}
			else if (GlobalScript.inst.gameState.data[31] >= 400 && GlobalScript.inst.gameState.data[31] <= 700)
			{
				text_ = Text_1;
				text_.text = text_.text + "\nНесколько народностей\n(" + GlobalScript.inst.gameState.data[31] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[31] % 10) + "/100)";
				Text_2.text = "Отсутствует".ToString();
			}
			else
			{
				text_ = Text_1;
				text_.text = text_.text + "\nМультикультурализм\n(" + GlobalScript.inst.gameState.data[31] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[31] % 10) + "/100)";
				Text_2.text = "Либерализация\nв 2 недели: +" + (500 - GlobalScript.inst.gameState.data[31]) / 100 / 10 + "." + Mathf.Abs((500 - GlobalScript.inst.gameState.data[31]) / 100 % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nПоддержка партии\nв 2 недели: +" + (500 - GlobalScript.inst.gameState.data[31]) / 100 / 10 + "." + Mathf.Abs((500 - GlobalScript.inst.gameState.data[31]) / 100 % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nАгенты (в 2 недели): -" + (GlobalScript.inst.gameState.data[31] - 500) / 1000 + "." + Mathf.Abs((GlobalScript.inst.gameState.data[31] - 500) / 100 % 10);
				text_ = Text_2;
				text_.text = text_.text + "\nОтношения\nв 2 недели: +" + (500 - GlobalScript.inst.gameState.data[31]) / 100 / 10 + "." + Mathf.Abs((500 - GlobalScript.inst.gameState.data[31]) / 100 % 10);
			}
			text_ = Text_1;
			text_.text = text_.text + "\nЕдинство Китая\nУровень:\n(" + GlobalScript.inst.gameState.data[57] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[57] % 10) + "/100)";
			Text_3.text = GlobalScript.inst.gameState.data[34] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[34]) % 10 + " миллионов (" + (((GlobalScript.inst.gameState.data_old[34] < 0) ? "-" : "+") + Mathf.Abs(GlobalScript.inst.gameState.data_old[34] / 10)).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.data_old[34] % 10) + ")";
			int[] array2 = new int[5] { 0, 0, 0, 0, 0 };
			if (GlobalScript.inst.gameState.data[16] == 11)
			{
				array2[0] += GlobalScript.inst.gameState.data[34] / 5000;
			}
			else if (GlobalScript.inst.gameState.data[16] == 10)
			{
				array2[0] += GlobalScript.inst.gameState.data[34] / 5000;
			}
			else if (GlobalScript.inst.gameState.data[16] == 13)
			{
				array2[3] += Mathf.RoundToInt((float)(GlobalScript.inst.gameState.data[34] - 9037) / 3000f + 1f);
			}
			else if (GlobalScript.inst.gameState.data[16] == 14 && !GlobalScript.inst.gameState.modifies[13].active)
			{
				array2[1] -= GlobalScript.inst.gameState.data[34] / 4000;
				array2[3] += Mathf.RoundToInt((float)(GlobalScript.inst.gameState.data[34] - 9037) / 2000f + 1f);
			}
			else if (GlobalScript.inst.gameState.data[16] == 15 && !GlobalScript.inst.gameState.modifies[13].active)
			{
				array2[1] -= GlobalScript.inst.gameState.data[34] / 4000;
				array2[3] += Mathf.RoundToInt((float)(GlobalScript.inst.gameState.data[34] - 9037) / 1000f + 1f);
			}
			if ((GlobalScript.inst.gameState.data[34] - 9307) / 200 > 0)
			{
				array2[2] -= (GlobalScript.inst.gameState.data[34] - 9307) / 200;
			}
			if (GlobalScript.inst.gameState.data[51] == 30)
			{
				if (GlobalScript.inst.gameState.data[34] - 9307 > 99)
				{
					array2[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 100;
					array2[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 100;
				}
			}
			else if (GlobalScript.inst.gameState.data[51] == 31)
			{
				if (GlobalScript.inst.gameState.data[34] - 9307 > 199)
				{
					array2[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 200;
					array2[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 200;
				}
			}
			else if (GlobalScript.inst.gameState.data[51] == 32)
			{
				if (GlobalScript.inst.gameState.data[34] - 9307 > 299)
				{
					array2[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 300;
					array2[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 300;
				}
			}
			else if (GlobalScript.inst.gameState.data[51] == 33 && GlobalScript.inst.gameState.data[34] - 9307 > 149)
			{
				if (GlobalScript.inst.gameState.data[5] < 500)
				{
					array2[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 150;
					array2[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 250;
				}
				else if (GlobalScript.inst.gameState.data[5] < 700)
				{
					array2[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 150;
					array2[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 300;
				}
				else
				{
					array2[3] -= (GlobalScript.inst.gameState.data[34] - 9307) / 500;
					array2[4] += (GlobalScript.inst.gameState.data[34] - 9307) / 500;
				}
			}
			text_ = Text_3;
			text_.text = text_.text + "\nПромышленность: " + (((array2[0] < 0) ? "-" : "+") + Mathf.Abs(array2[0] / 10)).ToString() + "." + Mathf.Abs(array2[0] % 10);
			text_ = Text_3;
			text_.text = text_.text + "; Бюджет: " + (((array2[3] < 0) ? "-" : "+") + Mathf.Abs(array2[3] / 10)).ToString() + "." + Mathf.Abs(array2[3] % 10);
			text_ = Text_3;
			text_.text = text_.text + "\nАгентурные сети: " + (((array2[2] < 0) ? "-" : "+") + Mathf.Abs(array2[2] / 10)).ToString() + "." + Mathf.Abs(array2[2] % 10);
			text_ = Text_3;
			text_.text = text_.text + "; Сила армии: " + (((array2[4] < 0) ? "-" : "+") + Mathf.Abs(array2[4] / 10)).ToString() + "." + Mathf.Abs(array2[4] % 10);
			text_ = Text_3;
			text_.text = text_.text + "\nПоддержка народа: " + (((array2[1] < 0) ? "-" : "+") + Mathf.Abs(array2[1] / 10)).ToString() + "." + Mathf.Abs(array2[1] % 10);
		}
		else if (num_this == 4)
		{
			num_names = 3;
			Name_1.text = "Иран";
			Name_2.text = "Афганистан";
			Name_3.text = "Президент США";
			Text_1.text = "Сила монархистов: \n" + GlobalScript.inst.gameState.data[43] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[43] % 10);
			TextMesh text_ = Text_1;
			text_.text = text_.text + "\nСила левых: \n" + GlobalScript.inst.gameState.data[42] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[42] % 10);
			text_ = Text_1;
			text_.text = text_.text + "\nСила исламистов: \n" + GlobalScript.inst.gameState.data[45] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[45] % 10);
			text_ = Text_1;
			text_.text = text_.text + "\nСила либералов: \n" + GlobalScript.inst.gameState.data[44] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[44] % 10);
			Text_2.text = "Сила маоистов: \n" + GlobalScript.inst.gameState.data[46] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[46] % 10);
			text_ = Text_2;
			text_.text = text_.text + "\nСила Хальк: \n" + GlobalScript.inst.gameState.data[48] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[48] % 10);
			text_ = Text_2;
			text_.text = text_.text + "\nСила Парчам: \n" + GlobalScript.inst.gameState.data[49] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[49] % 10);
			if (GlobalScript.inst.gameState.data[21] < 1977)
			{
				Text_3.text = "Джеральд Форд";
			}
			else if (GlobalScript.inst.gameState.data[21] < 1981)
			{
				Text_3.text = "Джимми Картер";
			}
			else if (GlobalScript.inst.gameState.empires[0].now_leader == 1)
			{
				Text_3.text = "Джимми Картер";
			}
			else if (GlobalScript.inst.gameState.empires[0].now_leader == 0)
			{
				Text_3.text = "Рональд Рейган";
			}
			else if (GlobalScript.inst.gameState.empires[0].now_leader == 2)
			{
				Text_3.text = "Джордж Буш старший";
			}
			else if (GlobalScript.inst.gameState.empires[0].now_leader == 3)
			{
				Text_3.text = "Уолтер Мондейл";
			}
			if (GlobalScript.inst.gameState.data[21] >= 1981 && GlobalScript.inst.gameState.empires[0].now_leader <= 0)
			{
				Text_3.text += "\nТраты США на внешнее вмешательство:\n+0.5\nЛиберализация умов:\n+0.5";
			}
			else if (GlobalScript.inst.gameState.empires[0].now_leader == 1 || (GlobalScript.inst.gameState.data[21] >= 1977 && GlobalScript.inst.gameState.data[21] < 1981))
			{
				Text_3.text += "\nОтношения Китая с США:\n+1.0";
			}
			else if (GlobalScript.inst.gameState.empires[0].now_leader == 2)
			{
				Text_3.text += "\nТраты США на внешнее вмешательство:\n+0.5\nОтношения с США: +0.5\nесли не состоим в альянсах";
			}
			else if (GlobalScript.inst.gameState.empires[0].now_leader == 3)
			{
				Text_3.text += "\nВлияние от кнопки Маоисты\nв Западной Европе - x1.5\nКредиты выплачиваются\nраз в 2 месяца";
			}
		}
		else if (num_this == 2)
		{
			num_names = 3;
			Name_1.text = "Китай";
			Name_2.text = "Тайвань";
			Name_3.text = "Аруначал Прадеш";
			if (GlobalScript.inst.gameState.data[67] <= 0)
			{
				Text_1.text = "Тибет - в составе Китая\n";
			}
			else if (GlobalScript.inst.gameState.data[67] == 1)
			{
				Text_1.text = "Республика Тибет - независимая\n";
			}
			else if (GlobalScript.inst.gameState.data[67] == 2)
			{
				Text_1.text = "Тибет - независимая теократия\n";
			}
			if (GlobalScript.inst.gameState.data[66] <= 0)
			{
				Text_1.text += "Синьцзян - в составе Китая\n";
			}
			else if (GlobalScript.inst.gameState.data[66] == 1)
			{
				Text_1.text += "Синьцзян - советская марионетка\n";
			}
			else if (GlobalScript.inst.gameState.data[66] == 2)
			{
				Text_1.text += "Исламская Республика Уйгуристан - независимая\n";
			}
			if (GlobalScript.inst.gameState.data[65] <= 0)
			{
				Text_1.text += "Гонконг и Макао в иностранном владении\n";
			}
			else if (GlobalScript.inst.gameState.data[65] == 1)
			{
				Text_1.text += "Гонконг и Макао - специальные районы Китая\n";
			}
			else if (GlobalScript.inst.gameState.data[65] == 2)
			{
				Text_1.text += "Гонконг и Макао вошли в состав Китая\n";
			}
			if (GlobalScript.inst.gameState.allcountries[7].parts[1] || GlobalScript.inst.gameState.allcountries[7].parts[2])
			{
				Text_1.text += "Монголия - в составе СССР\n";
			}
			else if (GlobalScript.inst.gameState.allcountries[9].prosov && !GlobalScript.inst.gameState.completedDecisions[19])
			{
				Text_1.text += "Монголия - независимое просоветское государство\n";
			}
			else if (GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19])
			{
				Text_1.text += "Монголия - независимое прокитайское государство\n";
			}
			else if (!GlobalScript.inst.gameState.allcountries[9].proprc && !GlobalScript.inst.gameState.completedDecisions[19] && !GlobalScript.inst.gameState.allcountries[9].prosov)
			{
				Text_1.text += "Монголия - независимое нейтральное государство\n";
			}
			else
			{
				Text_1.text += "Монголия вошла в состав Китая\n";
			}
			if (GlobalScript.inst.gameState.data[167] == 0)
			{
				Text_1.text += "Острова Дяоютай - Принадлежат Японии\n";
			}
			else if (GlobalScript.inst.gameState.data[167] == 1)
			{
				Text_1.text += "Острова Дяоютай - Принадлежат Китаю\n";
			}
			else if (GlobalScript.inst.gameState.data[167] == 2)
			{
				Text_1.text += "Острова Дяоютай - Совместное владение Китая и Японии\n";
			}
			if (GlobalScript.inst.gameState.data[64] == 2 || GlobalScript.inst.gameState.completedDecisions[6] || GlobalScript.inst.gameState.completedDecisions[7])
			{
				Text_2.text = "Тайвань - автономный регион в составе Китая\n";
			}
			else if (GlobalScript.inst.gameState.data[64] <= 0)
			{
				Text_2.text = "Республика Китай под контролем Гоминьдана\n(авторитарная, частично признанная)\n";
			}
			else if (GlobalScript.inst.gameState.data[64] == 1)
			{
				Text_2.text = "Республика Тайвань - суверенное государство\n(либеральное, всеми признанное)\n";
			}
			if (GlobalScript.inst.gameState.data[63] <= 0)
			{
				Text_2.text += "Острова возле Тайваня под контролем\nГоминьдана.\n";
			}
			else if (GlobalScript.inst.gameState.data[63] == 1)
			{
				Text_2.text += "Острова возле Тайваня под контролем\nнаших вооружённых сил.\n";
			}
			if (GlobalScript.inst.gameState.data[62] <= 0)
			{
				Text_3.text = "Контролируется Индией, но непризнано нами\n";
			}
			else if (GlobalScript.inst.gameState.data[62] == 1)
			{
				Text_3.text = "Мы признали контроль земель за Индией\n";
			}
			else if (GlobalScript.inst.gameState.data[62] == 2 || GlobalScript.inst.gameState.data[62] == 3)
			{
				Text_3.text = "Мы восстановили контроль над этими землями\n";
			}
		}
		else if (num_this == 6)
		{
			num_names = 1;
			Name_1.text = "Наши союзники";
			if (GlobalScript.inst.gameState.allcountries[1].econ)
			{
				Text_1.text = "<color=red>Страна - Членство - Консультируются - Стабильность</color>";
				for (int l = 0; l < GlobalScript.inst.gameState.allcountries.Length; l++)
				{
					switch (l)
					{
					default:
						if (l < 106 || l >= 109)
						{
							continue;
						}
						break;
					case 8:
					case 11:
					case 12:
					case 14:
					case 19:
					case 22:
					case 23:
					case 31:
					case 32:
					case 33:
					case 34:
					case 35:
					case 43:
					case 46:
					case 47:
					case 48:
					case 49:
					case 50:
					case 52:
					case 53:
					case 54:
					case 55:
					case 56:
					case 57:
					case 58:
					case 59:
					case 60:
					case 61:
					case 62:
					case 63:
					case 64:
					case 65:
					case 66:
					case 67:
					case 68:
					case 96:
					case 97:
						break;
					}
					if (GlobalScript.inst.gameState.allcountries[l].econ && GlobalScript.inst.gameState.allcountries[l].okb)
					{
						TextMesh text_ = Text_1;
						text_.text = text_.text + "\n" + GlobalScript.inst.gameState.allcountries[l].name + " - Оба - " + (GlobalScript.inst.gameState.allcountries[l].proprc ? "Да - " : "Нет - ") + GlobalScript.inst.gameState.allcountries[l].soc_stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[l].soc_stab % 10);
					}
					else if (GlobalScript.inst.gameState.allcountries[l].econ)
					{
						TextMesh text_ = Text_1;
						text_.text = text_.text + "\n" + GlobalScript.inst.gameState.allcountries[l].name + " - Экономический - " + (GlobalScript.inst.gameState.allcountries[l].proprc ? "Да - " : "Нет - ") + GlobalScript.inst.gameState.allcountries[l].soc_stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[l].soc_stab % 10);
					}
					else if (GlobalScript.inst.gameState.allcountries[l].okb)
					{
						TextMesh text_ = Text_1;
						text_.text = text_.text + "\n" + GlobalScript.inst.gameState.allcountries[l].name + " - Военный - " + (GlobalScript.inst.gameState.allcountries[l].proprc ? "Да - " : "Нет - ") + GlobalScript.inst.gameState.allcountries[l].soc_stab / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.allcountries[l].soc_stab % 10);
					}
				}
			}
			else
			{
				Text_1.text = "У нас нет своего союза";
			}
		}
		if (num_names != 3)
		{
			if (num_names == 2)
			{
				Name_3.text = null;
				Text_3.text = null;
			}
			else if (num_names == 1)
			{
				Name_3.text = null;
				Text_3.text = null;
				Name_2.text = null;
				Text_2.text = null;
			}
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off;
	}

	private string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
