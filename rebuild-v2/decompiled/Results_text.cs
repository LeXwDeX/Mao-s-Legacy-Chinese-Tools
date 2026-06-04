using System;
using EventsForDLC;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Results_text : MonoBehaviour
{
	private GlobalScript global1;

	public Sprite navel;

	public Sprite nenavel;

	public Sprite[] stamps = new Sprite[1];

	public TextMesh Name;

	public TextMesh Zaglav;

	public SpriteRenderer this_stamp;

	public GameObject achieves;

	public GameObject thisObject;

	public string load_scene_after_click = "Diplomacy";

	public float[] party_change = new float[5];

	private Type MyScriptType = Type.GetType("Event" + GlobalScript.inst.gameState.number_event + ",Assembly-CSharp");

	private void Awake()
	{
		global1 = GlobalScript.inst;
		achieves = GameObject.Find("Ach(Clone)");
		GlobalScript.inst.gameState.resultOfEvents[GlobalScript.inst.gameState.number_event] = GlobalScript.inst.gameState.number_otvet - 1;
		if (GlobalScript.inst.gameState.number_event >= 120 && thisObject.GetComponent<EventsSecond>() == null)
		{
			thisObject.AddComponent(MyScriptType);
		}
		Azkaban();
	}

	private void OnMouseDown()
	{
		global1.this_stump = -1;
		SceneManager.LoadScene(load_scene_after_click);
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = navel;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = nenavel;
	}

	private void Azkaban()
	{
		string text = "";
		string text2 = "";
		if (!GlobalScript.inst.gameState.is_party_enabled[1])
		{
			GlobalScript.inst.gameState.is_party_enabled[1] = true;
		}
		if (GlobalScript.inst.gameState.number_event >= 120 && GlobalScript.inst.gameState.number_event != 435 && GlobalScript.inst.gameState.number_event != 436)
		{
			thisObject.GetComponent<EventsSecond>().ResultsOfEvents(ref text2, ref text, GlobalScript.inst.gameState.number_otvet - 1);
			Pereraschyot();
		}
		else if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.number_event == 1)
			{
				GlobalScript.inst.gameState.data[106] = 0;
				text2 = "选举、选举、候选人是……";
				float[] array = new float[5]
				{
					0f,
					(GlobalScript.inst.gameState.data[3] * 2 - GlobalScript.inst.gameState.data[4] / 2 + GlobalScript.inst.gameState.data[5] / 2) / 10,
					0f,
					0f,
					0f
				};
				if (GlobalScript.inst.gameState.is_party_enabled[0])
				{
					array[0] = (1000 - GlobalScript.inst.gameState.data[3] - GlobalScript.inst.gameState.data[4] / 2) / 10;
					if (GlobalScript.inst.gameState.data[67] > 0)
					{
						array[0] += 10f;
					}
					if (GlobalScript.inst.gameState.data[66] > 0)
					{
						array[0] += 10f;
					}
					if (GlobalScript.inst.gameState.data[5] <= 500)
					{
						array[0] += (1000 - GlobalScript.inst.gameState.data[5]) / 20;
					}
					if (GlobalScript.inst.gameState.empires[1].relations <= 600)
					{
						array[0] += (1000 - GlobalScript.inst.gameState.empires[1].relations) / 100;
					}
				}
				else
				{
					array[0] = 0f;
				}
				if (GlobalScript.inst.gameState.is_party_enabled[2])
				{
					array[2] = (1000 - GlobalScript.inst.gameState.data[3] + GlobalScript.inst.gameState.data[4] / 2 + GlobalScript.inst.gameState.data[31] / 10) / 10;
					if (GlobalScript.inst.gameState.data[67] > 0)
					{
						array[2] += 10f;
					}
					if (GlobalScript.inst.gameState.data[66] > 0)
					{
						array[2] += 10f;
					}
					if (GlobalScript.inst.gameState.empires[1].relations <= 600)
					{
						array[2] += (1000 - GlobalScript.inst.gameState.empires[1].relations) / 100;
					}
				}
				else
				{
					array[2] = 0f;
				}
				if (GlobalScript.inst.gameState.is_party_enabled[3])
				{
					array[3] = (1000 - GlobalScript.inst.gameState.data[3] + GlobalScript.inst.gameState.data[4] / 2 + (GlobalScript.inst.gameState.data[31] - GlobalScript.inst.gameState.data[3] / 2)) / 10;
					if (GlobalScript.inst.gameState.data[67] > 0)
					{
						array[3] += 10f;
					}
					if (GlobalScript.inst.gameState.data[66] > 0)
					{
						array[3] += 10f;
					}
					if (GlobalScript.inst.gameState.data[18] != 21)
					{
						array[3] += (700 - GlobalScript.inst.gameState.data[3]) / 10;
					}
					if (GlobalScript.inst.gameState.empires[0].relations <= 600)
					{
						array[3] += (1000 - GlobalScript.inst.gameState.empires[0].relations) / 100;
					}
				}
				else
				{
					array[3] = 0f;
				}
				if (GlobalScript.inst.gameState.is_party_enabled[4])
				{
					array[4] = (1000 - GlobalScript.inst.gameState.data[3] + GlobalScript.inst.gameState.data[4] / 2) / 10;
					if (GlobalScript.inst.gameState.empires[0].relations <= 600)
					{
						array[3] += (1000 - GlobalScript.inst.gameState.empires[0].relations) / 100;
					}
				}
				else
				{
					array[4] = 0f;
				}
				GlobalScript.inst.gameState.data[125] = 1;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					int num = 0;
					float[] array2 = new float[5];
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] < 0f)
						{
							array[i] = 1f;
						}
						num += (int)array[i];
					}
					int num2 = 0;
					for (int j = 0; j < GlobalScript.inst.gameState.party_number.Length; j++)
					{
						Debug.Log(array[j].ToString());
					}
					GlobalScript.inst.gameState.party_number[1] = (int)(3000f * (array[1] / (float)num));
					for (int k = 0; k < GlobalScript.inst.gameState.party_number.Length; k++)
					{
						array2[k] = 3000f * (array[k] / (float)num);
						GlobalScript.inst.gameState.party_number[k] = (int)array2[k];
						GlobalScript.inst.gameState.party_ideology[k] = (int)array2[k];
						if (k == 1)
						{
							num2 += (int)array2[k];
						}
						else if (GlobalScript.inst.gameState.is_party_ally[k])
						{
							num2 += (int)array2[k];
							if (GlobalScript.inst.gameState.party_number[k] >= GlobalScript.inst.gameState.party_number[1])
							{
								GlobalScript.inst.gameState.is_party_ally[k] = false;
							}
						}
					}
					if (GlobalScript.inst.gameState.party_number[1] > 1500)
					{
						text = "我们以摧枯拉朽的结果获胜，夺得全国人大多数席位，\n并向中国和全世界证明：是人民承认我们是他们的统治者！";
						GlobalScript.inst.gameState.data[3] += 10;
						GlobalScript.inst.gameState.data[4] -= 20;
						GlobalScript.inst.gameState.data[1] += 50;
					}
					else if (num2 > 1500)
					{
						text = "我们各党派的联盟赢得了全国人大选举，\n并向中国和全世界证明：是人民承认我们是他们的统治者！";
					}
					else
					{
						text = "我们不但失去了多数席位，甚至连全国人大50%的席位都占不够了！\n真是耻辱！";
						GlobalScript.inst.gameState.data[35] = 5;
						load_scene_after_click = "Ending";
					}
					text += "|Election results:";
					for (int l = 0; l < GlobalScript.inst.gameState.party_number.Length; l++)
					{
						if (GlobalScript.inst.gameState.is_party_enabled[l])
						{
							text = text + "|" + GlobalScript.inst.gameState.party_name[l + 5] + ": " + GlobalScript.inst.gameState.party_number[l] + "席，共3000席";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "凭借奖金、发放与裁员降级的威胁，我们终于让公务员走进投票站，\n为我们的党投票。但人们会很久都记得这种赤裸裸的骗局。";
					array[1] += GlobalScript.inst.gameState.data[1] / 10;
					int num3 = 0;
					float[] array3 = new float[5];
					for (int m = 0; m < array.Length; m++)
					{
						if (array[m] < 0f)
						{
							array[m] = 1f;
						}
						num3 += (int)array[m];
					}
					int num4 = 0;
					GlobalScript.inst.gameState.party_number[1] = (int)(3000f * (array[1] / (float)num3));
					for (int n = 0; n < GlobalScript.inst.gameState.party_number.Length; n++)
					{
						array3[n] = 3000f * (array[n] / (float)num3);
						GlobalScript.inst.gameState.party_number[n] = (int)array3[n];
						GlobalScript.inst.gameState.party_ideology[n] = (int)array3[n];
						if (n == 1)
						{
							num4 += (int)array3[n];
						}
						else if (GlobalScript.inst.gameState.is_party_ally[n])
						{
							num4 += (int)array3[n];
							if (GlobalScript.inst.gameState.party_number[n] >= GlobalScript.inst.gameState.party_number[1])
							{
								GlobalScript.inst.gameState.is_party_ally[n] = false;
							}
						}
					}
					if (GlobalScript.inst.gameState.party_number[1] > 1500)
					{
						text = "我们以摧枯拉朽的结果获胜，夺得全国人大多数席位，\n并向中国和全世界证明：是人民承认我们是他们的统治者！";
						GlobalScript.inst.gameState.data[3] += 10;
						GlobalScript.inst.gameState.data[4] -= 20;
						GlobalScript.inst.gameState.data[1] += 50;
					}
					else if (num4 > 1500)
					{
						text = "我们各党派的联盟赢得了全国人大选举，\n并向中国和全世界证明：是人民承认我们是他们的统治者！";
					}
					else
					{
						text = "我们不但失去了多数席位，甚至连全国人大50%的席位都占不够了！\n真是耻辱！";
						GlobalScript.inst.gameState.data[35] = 5;
						load_scene_after_click = "Ending";
					}
					text += "|Election results:";
					for (int num5 = 0; num5 < GlobalScript.inst.gameState.party_number.Length; num5++)
					{
						if (GlobalScript.inst.gameState.is_party_enabled[num5])
						{
							text = text + "|" + GlobalScript.inst.gameState.party_name[num5 + 5] + ": " + GlobalScript.inst.gameState.party_number[num5] + " мест из 3000";
						}
					}
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[6] += 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "特务机关为我们安排席位干得很出色。只是他们也累坏了。";
					if (GlobalScript.inst.gameState.data[9] < 100)
					{
						array[1] += GlobalScript.inst.gameState.data[9] * 2;
						GlobalScript.inst.gameState.data[9] = 0;
					}
					else
					{
						array[1] += 200f;
						GlobalScript.inst.gameState.data[9] -= 100;
					}
					int num6 = 0;
					float[] array4 = new float[5];
					for (int num7 = 0; num7 < array.Length; num7++)
					{
						if (array[num7] < 0f)
						{
							array[num7] = 1f;
						}
						num6 += (int)array[num7];
					}
					int num8 = 0;
					GlobalScript.inst.gameState.party_number[1] = (int)(3000f * (array[1] / (float)num6));
					for (int num9 = 0; num9 < GlobalScript.inst.gameState.party_number.Length; num9++)
					{
						array4[num9] = 3000f * (array[num9] / (float)num6);
						GlobalScript.inst.gameState.party_number[num9] = (int)array4[num9];
						GlobalScript.inst.gameState.party_ideology[num9] = (int)array4[num9];
						if (num9 == 1)
						{
							num8 += (int)array4[num9];
						}
						else if (GlobalScript.inst.gameState.is_party_ally[num9])
						{
							num8 += (int)array4[num9];
							if (GlobalScript.inst.gameState.party_number[num9] >= GlobalScript.inst.gameState.party_number[1])
							{
								GlobalScript.inst.gameState.is_party_ally[num9] = false;
							}
						}
					}
					if (GlobalScript.inst.gameState.party_number[1] > 1500)
					{
						text = "我们以摧枯拉朽的结果获胜，夺得全国人大多数席位，\n并向中国和全世界证明：是人民承认我们是他们的统治者！";
						GlobalScript.inst.gameState.data[3] += 10;
						GlobalScript.inst.gameState.data[4] -= 20;
						GlobalScript.inst.gameState.data[1] += 50;
					}
					else if (num8 > 1500)
					{
						text = "我们各党派的联盟赢得了全国人大选举，\n并向中国和全世界证明：是人民承认我们是他们的统治者！";
					}
					else
					{
						text = "我们不但失去了多数席位，甚至连全国人大50%的席位都占不够了！\n真是耻辱！";
						GlobalScript.inst.gameState.data[35] = 5;
						load_scene_after_click = "Ending";
					}
					text += "|Election results:";
					for (int num10 = 0; num10 < GlobalScript.inst.gameState.party_number.Length; num10++)
					{
						if (GlobalScript.inst.gameState.is_party_enabled[num10])
						{
							text = text + "|" + GlobalScript.inst.gameState.party_name[num10 + 5] + ": " + GlobalScript.inst.gameState.party_number[num10] + " мест из 3000";
						}
					}
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 150;
					GlobalScript.inst.gameState.data[4] += 30;
					GlobalScript.inst.gameState.data[22] -= 10;
					GlobalScript.inst.gameState.data[31] -= 10;
					GlobalScript.inst.gameState.empires[0].money = 24;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 3)
			{
				text2 = "掌舵者逝世";
				GlobalScript.inst.gameState.data[38] = 100;
				GlobalScript.inst.gameState.politics[0].name_1 = 1;
				GlobalScript.inst.gameState.politics[0].name_2 = 41;
				GlobalScript.inst.gameState.politics[0].age = 35;
				GlobalScript.inst.gameState.politics[0].traits[0] = 0;
				GlobalScript.inst.gameState.politics[0].traits[1] = 4;
				GlobalScript.inst.gameState.politics[0].traits[2] = 14;
				GlobalScript.inst.gameState.politics_dolshnost[1] = 150;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "毛主席逝世的消息宣布后，遗体安放在人民大会堂一周，\n供大家向主席告别，全国哀悼。\n许多中国人前来向这位伟大领袖和老师作最后的告别。\n到期后，按毛主席遗愿将遗体火化；三分钟的默哀之后，\n在天安门广场由华国锋作告别讲话，骨灰坛被封入一座专门在同一广\n场修建的纪念碑中。";
					GlobalScript.inst.gameState.data[4] -= 50;
					GlobalScript.inst.gameState.data[3] += 20;
					Politic politic = GlobalScript.inst.gameState.politics[4];
					politic.loyality -= 400;
					politic = GlobalScript.inst.gameState.politics[1];
					politic.loyality -= 400;
					politic = GlobalScript.inst.gameState.politics[2];
					politic.loyality -= 400;
					politic = GlobalScript.inst.gameState.politics[3];
					politic.loyality -= 400;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "毛主席逝世的消息宣布后，遗体安放在人民大会堂一周，\n供大家向主席告别，全国哀悼。\n许多中国人前来向这位伟大领袖和老师作最后的告别。\n到期后，毛主席遗体被送往医院，采用专门研制的技术进行防腐处理。\n三分钟默哀之后，在天安门广场由华国锋作告别讲话，\n主席安息于由华国锋特别下令修建在同一广场的陵墓之中。";
					GlobalScript.inst.gameState.data[4] -= 70;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[1] += 40;
					GlobalScript.inst.gameState.data[8] -= 10;
					Politic politic = GlobalScript.inst.gameState.politics[4];
					politic.loyality -= 300;
					politic = GlobalScript.inst.gameState.politics[1];
					politic.loyality -= 300;
					politic = GlobalScript.inst.gameState.politics[2];
					politic.loyality -= 300;
					politic = GlobalScript.inst.gameState.politics[3];
					politic.loyality -= 300;
					GlobalScript.inst.gameState.data[104] = 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "华国锋决定不直接参与丧事的组织，这一点并未被人忽视。\n毛主席逝世的消息宣布后，遗体安放在人民大会堂一周，\n供大家向主席告别，全国哀悼。\n许多中国人前来向这位伟大领袖和老师作最后的告别。\n到期后，毛主席遗体被送往医院，采用专门研制的技术进行防腐处理。\n三分钟默哀之后，在天安门广场由华国锋作告别讲话，\n主席安息于由丧事委员会特别下令修建在同一广场的陵墓之中。";
					GlobalScript.inst.gameState.data[4] -= 70;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[1] -= 40;
					Politic politic = GlobalScript.inst.gameState.politics[4];
					politic.loyality -= 500;
					politic = GlobalScript.inst.gameState.politics[1];
					politic.loyality -= 500;
					politic = GlobalScript.inst.gameState.politics[2];
					politic.loyality -= 500;
					politic = GlobalScript.inst.gameState.politics[3];
					politic.loyality -= 500;
					GlobalScript.inst.gameState.data[104] = 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 4)
			{
				text2 = "阴谋";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					int num11 = 0;
					for (int num12 = 0; num12 < GlobalScript.inst.gameState.politics.Length; num12++)
					{
						if (GlobalScript.inst.gameState.politics[num12].loyality > 600)
						{
							num11++;
						}
					}
					if (GlobalScript.inst.gameState.data[1] > 500 && num11 >= 4)
					{
						text = "在阴谋者还没来得及提出指控之前，你就以批判和反指控向他们发起\n攻击。大会上大多数人站在你这边，阴谋者只得退却。";
						GlobalScript.inst.gameState.data[1] += 50;
						Politic[] politics = GlobalScript.inst.gameState.politics;
						foreach (Politic politic2 in politics)
						{
							if (((politic2.loyality < 300 && politic2.traits[2] == 16) || politic2.you_fall || (politic2.loyality < 150 && politic2.traits[2] != 9) || (politic2.loyality < 50 && politic2.traits[2] == 9)) && politic2.traits[2] != 17 && politic2.traits[2] != 19 && !politic2.is_sledstvie)
							{
								Politic politic = politic2;
								politic.power -= 100;
								politic = politic2;
								politic.loyality -= 100;
								politic2.is_sledstvie = true;
								politic2.sled_slej = 1;
							}
						}
					}
					else
					{
						text = "在阴谋者还没来得及提出指控之前，你就以批判和反指控向他们发起\n攻击。然而你显然缺乏足够的威信，而大多数党员早已厌倦了你的统\n治。大会上多数人支持阴谋者，你被撤职、\n开除出中央委员会，并被打发到遥远而无权的岗位上。";
						GlobalScript.inst.gameState.data[1] = 0;
						GlobalScript.inst.gameState.data[3] = 0;
						GlobalScript.inst.gameState.data[35] = 2;
						load_scene_after_click = "Ending";
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "在大会开始之前，你忠诚的秘密情报人员就已压制了赶来的阴谋者，\n并把他们送进拘留设施。\n大会上，你对他们进行“隔空批判”，得到了与会代表的支持。\n但要摆脱高级党内人物，可没那么容易……";
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[9] -= 100;
					if (GlobalScript.inst.gameState.data[1] <= 300 + GlobalScript.inst.gameState.data[4] / 5 - (GlobalScript.inst.gameState.data[3] - 500) / 5)
					{
						GlobalScript.inst.gameState.data[1] += 400;
					}
					else
					{
						GlobalScript.inst.gameState.data[1] += 50;
					}
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic3 in politics)
					{
						if (((politic3.loyality < 300 && politic3.traits[2] == 16) || politic3.you_fall || (politic3.loyality < 150 && politic3.traits[2] != 9) || (politic3.loyality < 50 && politic3.traits[2] == 9)) && politic3.traits[2] != 17 && politic3.traits[2] != 19 && !politic3.is_sledstvie)
						{
							Politic politic = politic3;
							politic.power -= 100;
							politic = politic3;
							politic.loyality -= 200;
							politic3.is_sledstvie = true;
							politic3.sled_slej = 1;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在大会开始之前，你忠诚的军官就已压制了赶来的阴谋者，\n并在枪口威逼下把他们押往军中监狱。\n大会上，在武装士兵在场的情况下，你对他们进行“隔空批判”，\n得到了与会代表的支持。\n但要摆脱高级党内人物，可没那么容易……";
					GlobalScript.inst.gameState.data[3] -= 80;
					if (GlobalScript.inst.gameState.data[1] <= 300 + GlobalScript.inst.gameState.data[4] / 5 - (GlobalScript.inst.gameState.data[3] - 500) / 5)
					{
						GlobalScript.inst.gameState.data[1] += 400;
					}
					else
					{
						GlobalScript.inst.gameState.data[1] += 50;
					}
					GlobalScript.inst.gameState.data[22] -= 100;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic4 in politics)
					{
						if (((politic4.loyality < 300 && politic4.traits[2] == 16) || politic4.you_fall || (politic4.loyality < 150 && politic4.traits[2] != 9) || (politic4.loyality < 50 && politic4.traits[2] == 9)) && politic4.traits[2] != 17 && politic4.traits[2] != 19 && !politic4.is_sledstvie)
						{
							Politic politic = politic4;
							politic.power -= 100;
							politic = politic4;
							politic.loyality -= 300;
							politic4.is_sledstvie = true;
							politic4.sled_slej = 1;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "在大会开始之前，你就通过媒体向人民发出号召，\n要求支持你、保卫你权力的“成果”。\n你忠诚的群众举行大规模集会声援，并开始冲击对手所控制的部门。\n阴谋者意识到自己不得人心，于是退却；\n最后一届大会也就稳固了你的权力。\n但人民早已对类似的文化大革命感到厌倦。";
					if (GlobalScript.inst.gameState.data[1] <= 300 + GlobalScript.inst.gameState.data[4] / 5 - (GlobalScript.inst.gameState.data[3] - 500) / 5)
					{
						GlobalScript.inst.gameState.data[1] += 400;
					}
					else
					{
						GlobalScript.inst.gameState.data[1] += 50;
					}
					GlobalScript.inst.gameState.data[3] -= 200;
					GlobalScript.inst.gameState.data[5] -= 70;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic5 in politics)
					{
						if (((politic5.loyality < 300 && politic5.traits[2] == 16) || politic5.you_fall || (politic5.loyality < 150 && politic5.traits[2] != 9) || (politic5.loyality < 50 && politic5.traits[2] == 9)) && politic5.traits[2] != 17 && politic5.traits[2] != 19 && !politic5.is_sledstvie)
						{
							Politic politic = politic5;
							politic.power -= 100;
							politic = politic5;
							politic.loyality -= 100;
							politic5.is_sledstvie = true;
							politic5.sled_slej = 1;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 5)
			{
				text2 = "群众不满";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					if (GlobalScript.inst.gameState.data[3] > 700 && GlobalScript.inst.gameState.data[1] >= 500)
					{
						text = "你亲自向北京的抗议者讲话，并通过全国广播。\n你承诺将尽一切努力改变政策，兼顾所有公民的利益，\n并建立真正民主的机制（不过，你并不急着去落实）。\n看来你已经成功说服了人民，抗议活动正在慢慢降温。";
						GlobalScript.inst.gameState.data[3] -= 150;
						GlobalScript.inst.gameState.data[4] -= 150;
						GlobalScript.inst.gameState.data[1] -= 100;
						if (!GlobalScript.inst.gameState.is_party_enabled[1])
						{
							GlobalScript.inst.gameState.is_party_enabled[1] = true;
						}
						if (GlobalScript.inst.gameState.data[15] >= 6 && GlobalScript.inst.gameState.data[15] <= 7)
						{
							int num14 = 0;
							for (int num15 = 0; num15 < GlobalScript.inst.gameState.is_party_ally.Length; num15++)
							{
								if (GlobalScript.inst.gameState.party_ideology[num15] <= 0)
								{
									GlobalScript.inst.gameState.party_ideology[num15] = 0;
								}
								if (GlobalScript.inst.gameState.is_party_ally[num15] && num15 != 1)
								{
									GlobalScript.inst.gameState.is_party_ally[num15] = false;
								}
								if (GlobalScript.inst.gameState.is_party_enabled[num15] && num15 != 1 && GlobalScript.inst.gameState.party_number[num15] > 0)
								{
									num14 += GlobalScript.inst.gameState.party_number[num15] / 2;
									GlobalScript.inst.gameState.party_number[num15] -= GlobalScript.inst.gameState.party_number[num15] / 2;
									GlobalScript.inst.gameState.party_ideology[num15] -= GlobalScript.inst.gameState.party_number[num15] / 2;
									num14 += GlobalScript.inst.gameState.party_number[num15] / 4;
									GlobalScript.inst.gameState.party_number[num15] -= GlobalScript.inst.gameState.party_number[num15] / 4;
									GlobalScript.inst.gameState.party_ideology[num15] -= GlobalScript.inst.gameState.party_number[num15] / 4;
								}
								else if (!GlobalScript.inst.gameState.is_party_enabled[num15])
								{
									GlobalScript.inst.gameState.is_party_enabled[num15] = true;
								}
								GlobalScript.inst.gameState.data[53] = 0;
							}
							GlobalScript.inst.gameState.party_number[1] += num14;
							GlobalScript.inst.gameState.party_ideology[1] += num14;
							GlobalScript.inst.gameState.data[125] = 0;
						}
						else if (GlobalScript.inst.gameState.data[15] < 9)
						{
							GlobalScript.inst.gameState.data[15]++;
						}
						else if (GlobalScript.inst.gameState.data[17] < 19)
						{
							GlobalScript.inst.gameState.data[17]++;
						}
					}
					else
					{
						text = "你亲自向北京的抗议者讲话，并通过全国广播。\n你承诺将尽一切努力改变政策，兼顾所有公民的利益，\n并建立真正民主的机制（不过，你并不急着去落实）。\n然而，人民早已厌倦你的空话，听了也毫无热情，\n要求你辞职。党终于对你彻底失望，紧急组织你的撤职与逮捕，\n并组建新政府，直到大选前继续领导国家——而你则坐在拘留中心里。";
						GlobalScript.inst.gameState.data[1] = 0;
						GlobalScript.inst.gameState.data[3] = 0;
						GlobalScript.inst.gameState.data[35] = 1;
						load_scene_after_click = "Ending";
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "军队接到命令后，驾驶装甲车开上城市街头，\n强行驱散抗议。双方都有伤亡。\n当然，这种行动早已遭到世界上几乎所有国家的谴责。";
					GlobalScript.inst.gameState.data[4] -= 150;
					GlobalScript.inst.gameState.data[22] -= 100;
					GlobalScript.inst.gameState.data[6] += 50;
					GlobalScript.inst.gameState.data[113] = 9;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic6 in politics)
					{
						if (politic6.traits[0] == 3)
						{
							Politic politic = politic6;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "你通过媒体向同情你的人发出呼吁，要求他们帮助保卫你“夺取的成\n果”，抵御由美国和苏联资助的叛徒。\n对方立刻组织大规模集会声援，常常演变为与抗议者的冲突，\n并导致后者被捕。街头战斗的尘埃落定、\n抗议者四散逃离之后，你的支持者向天安门进发。";
					GlobalScript.inst.gameState.data[4] -= 200;
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.data[3] -= 300;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic7 in politics)
					{
						if (politic7.traits[0] == 3 || politic7.traits[0] == 2)
						{
							Politic politic = politic7;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					bool flag = false;
					int num16 = 99;
					Debug.Log($"Длина массива citizens: {GlobalScript.inst.gameState.citizens.Length}");
					for (int num17 = 0; num17 < GlobalScript.inst.gameState.citizens.Length; num17++)
					{
						Persona persona = GlobalScript.inst.gameState.citizens[num17];
						if (persona == null)
						{
							Debug.LogWarning($"Гражданин {num17} равен null");
							continue;
						}
						Debug.Log($"Гражданин {persona.isLead} citizen.isLead");
						Debug.Log($"Гражданин {persona.isPolitic} citizen.isPolitic");
						if (persona.isLead && !persona.isPolitic)
						{
							flag = true;
							num16 = num17;
						}
					}
					for (int num18 = 0; num18 < GlobalScript.inst.gameState.citizens.Length; num18++)
					{
						Persona persona2 = GlobalScript.inst.gameState.citizens[num18];
						if (persona2 == null)
						{
							Debug.LogWarning($"Гражданин {num18} равен null");
						}
						else if (persona2.isLead && persona2.isPolitic && flag)
						{
							persona2.isLead = false;
						}
					}
					text = (flag ? "你亲自对北京的抗议者讲话，讲话在全国播出。\n你承诺竭尽全力改革政策，考虑所有公民的利益。\n然而，人民对你的承诺已感疲惫，既不买账，\n也不热情接受，反而要求你辞职。\n面对日益增长的不满，你作出一个出人意料的决定：\n按抗议者的要求，提名一位“来自人民”的领袖。\n你推出了一名候选人——一位魅力型政治家，\n其仕途建立在说服民众、赢得群众信任的能力之上。\n你的决定暂时平息了抗议，却在党内造成分裂，\n动摇了团结。新领袖能否守住权力，还是说你的决定只是把危机延后\n了？" : "你亲自同北京的抗议者对话，并在全国播出。\n你承诺竭尽全力改变政策，兼顾所有公民的利益，\n还要建立真正民主的机制——即将开始运转。\n人民备受鼓舞，但与此同时，批评的洪流也借着新获得的自由奔涌而\n出。");
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[6] -= 50;
					if (GlobalScript.inst.gameState.data[15] != 9)
					{
						GlobalScript.inst.gameState.data[15] = 9;
					}
					else
					{
						GlobalScript.inst.gameState.data[17] = 19;
					}
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic8 in politics)
					{
						Politic politic = politic8;
						politic.loyality -= 100;
					}
					if (flag)
					{
						CitizenManager.Instance.PromoteToPolitic(num16);
						Persona persona3 = GlobalScript.inst.gameState.citizens[num16];
						for (int num19 = 0; num19 < GlobalScript.inst.gameState.politics.Length; num19++)
						{
							Politic politic9 = GlobalScript.inst.gameState.politics[num19];
							if (politic9 != null && politic9.isCitizen && GlobalScript.inst.gameState.names1[politic9.name_1] == GlobalScript.inst.gameState.citizens[num16].name && GlobalScript.inst.gameState.names2[politic9.name_2] == GlobalScript.inst.gameState.citizens[num16].surname)
							{
								GlobalScript.inst.gameState.MakeNewLeader(num19);
							}
						}
						int[] date = new int[3]
						{
							GlobalScript.inst.gameState.data[19],
							GlobalScript.inst.gameState.data[20],
							GlobalScript.inst.gameState.data[21]
						};
						string item = CitizenManager.FormatLog(GlobalScript.inst.gameState.citizens[num16], "стал правителем.", "成为领袖。", date);
						persona3.changeLog.Add(item);
						GlobalScript.inst.gameState.data[1] = 0;
						achieves.GetComponent<achievements>().Set(211);
						achieves.GetComponent<achievements>().Set(210);
						Debug.Log("Ачивка Гражданин стал правителем И Гражданин пришёл к власти в результате волнений. Получена.");
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "国安系统照例忙活——收买一个、清除一个，\n各种组织和人物从内部瓦解、为我们利益服务的“力量”也开始积极\n加入抗议。反对派自相残杀，抗议变成毫无策略的聚会，\n很快就偃旗息鼓了。";
					GlobalScript.inst.gameState.data[9] -= 150;
					GlobalScript.inst.gameState.data[4] -= 150;
					GlobalScript.inst.gameState.data[3] += 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 6)
			{
				text2 = "生活水平偏低";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "财政预算中大笔资金被紧急拨付到社会项目、\n住房建设以及救助贫困。\n社会问题正逐步开始得到解决，人民也感到满意";
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[8] -= 100;
					GlobalScript.inst.gameState.data[5] = 300;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们请求外援的人道主义援助，援助已被提供。\n来自不同国家以及联合国的志愿者分发食物，\n并以无偿方式为民众修建住房。\n然而，这样的行动让我们的人民和国际社会都看清：\n我们自己无法应对这些事，这极大损害了我们的威信。";
					GlobalScript.inst.gameState.data[4] += 200;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 100;
					GlobalScript.inst.gameState.data[5] = 300;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "通过完善劳动法规、政府命令、福利待遇以及司空见惯的强制手段，\n我们终于迫使我们的商人向人民提供社会支持，\n改善劳动条件和住房条件。\n然而，他们并不太愿意把自己的财富与人民分享，\n并正积极动用最高层的关系对你施压。";
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[1] -= 500;
					GlobalScript.inst.gameState.data[5] = 300;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic10 in politics)
					{
						if (politic10.traits[0] == 3 || politic10.traits[0] == 2)
						{
							Politic politic = politic10;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "在特别党代会上，你向上层说明了形势的严峻，\n并决定拨款满足党内社会需要，同时“自愿—被迫”吸引党员干部参\n加慈善活动。当然，这提高了生活水平，\n但党内并不满足。";
					GlobalScript.inst.gameState.data[1] = 0;
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[5] = 300;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic11 in politics)
					{
						Politic politic = politic11;
						politic.loyality -= 300;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 7)
			{
				text2 = "外交危机";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们紧急组织了中美两国外长的盛大会晤，\n并邀请美方代表团在中国进行豪华参观——各类节庆和活动正在筹备，\n以展示我们的和平姿态。\n缓和取得成功，紧张局势随之缓解。";
					GlobalScript.inst.gameState.empires[0].relations = 400;
					if (GlobalScript.inst.gameState.data[6] > 600)
					{
						GlobalScript.inst.gameState.data[6] -= GlobalScript.inst.gameState.data[6] / 50;
					}
					GlobalScript.inst.gameState.data[8] -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们放弃了部分外交主张，减少了对其他国家“忠诚反对派”的支持，\n总体上也降低了中国政治的干预主义程度。\n美国外交部对此作出了积极评估，紧张局势下降。\n也就是承认了我们的影响力。";
					GlobalScript.inst.gameState.empires[0].relations = 400;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 50;
					GlobalScript.inst.gameState.data[22] -= 50;
					GlobalScript.inst.gameState.data[9] -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "紧张局势加剧。";
					GlobalScript.inst.gameState.data[35] = 3;
					load_scene_after_click = "Ending";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "紧张局势加剧。";
					if (!GlobalScript.inst.gameState.modifies[17].active)
					{
						GlobalScript.inst.gameState.data[22] -= 50;
						GlobalScript.inst.gameState.data[9] -= 50;
						GlobalScript.inst.gameState.modifies[17].active = true;
						GlobalScript.inst.gameState.data[111]++;
					}
					if (GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.allcountries[1].isASEAN && GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.data[139] <= 0)
					{
						GlobalScript.inst.gameState.data[139] = 5;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "我们紧急组织了中美两国外长的盛大会晤，\n并邀请美方代表团在中国进行豪华参观——各类节庆和活动正在筹备，\n以展示我们的和平姿态。\n缓和取得成功，紧张局势随之缓解。";
					GlobalScript.inst.gameState.empires[0].relations = 400;
					GlobalScript.inst.gameState.data[168] -= 50;
					if (GlobalScript.inst.gameState.data[6] > 700)
					{
						GlobalScript.inst.gameState.data[6] -= 30;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 8)
			{
				text2 = "外交危机";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们紧急组织了中苏两国外长的盛大会晤，\n并邀请苏方代表团在中国进行豪华参观——各类节庆和活动正在筹备，\n以展示我们的和平姿态。\n缓和取得成功，紧张局势随之缓解。";
					GlobalScript.inst.gameState.empires[1].relations = 400;
					if (GlobalScript.inst.gameState.data[6] > 600)
					{
						GlobalScript.inst.gameState.data[6] -= GlobalScript.inst.gameState.data[6] / 20;
					}
					GlobalScript.inst.gameState.data[8] -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们放弃了部分外交主张，减少了对其他国家“忠诚反对派”的支持，\n总体上也降低了中国政治的干预主义程度。\n苏联外交部对此作出了积极评估，紧张局势下降。\n也就是承认了我们的影响力。";
					GlobalScript.inst.gameState.empires[1].relations = 400;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 50;
					GlobalScript.inst.gameState.data[22] -= 50;
					GlobalScript.inst.gameState.data[9] -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					GlobalScript.inst.gameState.data[35] = 3;
					load_scene_after_click = "Ending";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "紧张局势加剧。";
					if (!GlobalScript.inst.gameState.modifies[16].active)
					{
						GlobalScript.inst.gameState.data[22] -= 50;
						GlobalScript.inst.gameState.data[9] -= 50;
						GlobalScript.inst.gameState.modifies[16].active = true;
						GlobalScript.inst.gameState.data[111]++;
					}
					if (GlobalScript.inst.gameState.modifies[16].active && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.data[139] <= 0)
					{
						GlobalScript.inst.gameState.data[139] = 5;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "我们紧急组织了中苏两国外长的盛大会晤，\n并邀请苏方代表团在中国进行豪华参观——各类节庆和活动正在筹备，\n以展示我们的和平姿态。\n缓和取得成功，紧张局势随之缓解。";
					GlobalScript.inst.gameState.empires[1].relations = 400;
					GlobalScript.inst.gameState.data[168] -= 50;
					if (GlobalScript.inst.gameState.data[6] > 700)
					{
						GlobalScript.inst.gameState.data[6] -= 30;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 9)
			{
				text2 = "西藏分裂主义";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "西藏自治区正式宣布在1950年边界内独立。\n这将给我们造成沉重打击，也将为苏联和美国提供绝佳机会。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 250;
					GlobalScript.inst.gameState.data[34] -= 31;
					GlobalScript.inst.gameState.data[13] -= 50;
					GlobalScript.inst.gameState.data[12] -= 10;
					GlobalScript.inst.gameState.data[57] -= 50;
					GlobalScript.inst.gameState.data[1] -= 200;
					GlobalScript.inst.gameState.data[3] -= 200;
					GlobalScript.inst.gameState.data[34] -= 31;
					GlobalScript.inst.gameState.allcountries[69].dev = 0;
					if (GlobalScript.inst.gameState.data[14] <= 3)
					{
						GlobalScript.inst.gameState.data[67] = 1;
						if (GlobalScript.inst.gameState.data[62] == 2)
						{
							GlobalScript.inst.gameState.allcountries[1].parts[8] = true;
						}
						else
						{
							GlobalScript.inst.gameState.allcountries[1].parts[7] = true;
						}
						GlobalScript.inst.gameState.allcountries[69].Gosstroy = 3;
						GlobalScript.inst.gameState.allcountries[69].SubGosstroy = 6;
					}
					else
					{
						GlobalScript.inst.gameState.data[67] = 2;
						if (GlobalScript.inst.gameState.data[62] == 2)
						{
							GlobalScript.inst.gameState.allcountries[1].parts[8] = true;
						}
						else
						{
							GlobalScript.inst.gameState.allcountries[1].parts[7] = true;
						}
					}
					GlobalScript.inst.gameState.allcountries[69].prosov = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们进一步扩大了地方当局的权力和西藏自治权。\n看起来多数民众是满意的，但这也给激进分子提供了更多推动分裂的\n机会，其他民族边缘地区也在考虑更大的独立。";
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[57] -= 20;
					GlobalScript.inst.gameState.data[1] -= 200;
					GlobalScript.inst.gameState.data[18]++;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "忠于我们的人民解放军部队进入西藏，迅速恢复秩序。\n但民族主义者和反对派不会忘记这一点。";
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[57] += 30;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[22] -= 100;
					GlobalScript.inst.gameState.data[6] += 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "我们组织了一场全民公决，当然，大多数人投票赞成保留西藏现状。\n那些不满的民族主义者和其他激进分子走上街头，\n声称存在造假，但在失去以往支持之后，\n这些抗议已不再构成严重威胁。";
					GlobalScript.inst.gameState.data[4] += 30;
					GlobalScript.inst.gameState.data[57] += 20;
					GlobalScript.inst.gameState.data[3] -= 20;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[8] -= 40;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 10)
			{
				text2 = "新疆分裂主义";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "新疆维吾尔自治区正式宣布独立。\n这将给我们造成沉重打击，也将为苏联和美国提供绝佳机会。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 250;
					GlobalScript.inst.gameState.data[34] -= 218;
					GlobalScript.inst.gameState.data[13] -= 50;
					GlobalScript.inst.gameState.data[12] -= 10;
					GlobalScript.inst.gameState.data[57] -= 50;
					GlobalScript.inst.gameState.data[1] -= 200;
					GlobalScript.inst.gameState.data[3] -= 200;
					GlobalScript.inst.gameState.data[34] -= 218;
					GlobalScript.inst.gameState.allcountries[70].dev = 0;
					if (!GlobalScript.inst.gameState.allcountries[12].proprc && !GlobalScript.inst.gameState.ingamewars[5].is_going && GlobalScript.inst.gameState.allcountries[12].Gosstroy != 0)
					{
						GlobalScript.inst.gameState.data[66] = 1;
						GlobalScript.inst.gameState.allcountries[1].parts[9] = true;
						GlobalScript.inst.gameState.allcountries[70].Gosstroy = 1;
						GlobalScript.inst.gameState.allcountries[70].SubGosstroy = 1;
						GlobalScript.inst.gameState.allcountries[70].prosov = true;
					}
					else
					{
						GlobalScript.inst.gameState.data[66] = 2;
						GlobalScript.inst.gameState.allcountries[1].parts[9] = true;
						GlobalScript.inst.gameState.allcountries[70].prosov = false;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们进一步扩大了地方当局的权力和新疆维吾尔自治权。\n看起来多数民众是满意的，但这也给激进分子提供了更多推动分裂的\n机会，其他民族边缘地区也在考虑更大的独立。";
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[57] -= 20;
					GlobalScript.inst.gameState.data[1] -= 200;
					GlobalScript.inst.gameState.data[18]++;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "忠于我们的人民解放军部队进入新疆，迅速恢复秩序。\n但民族主义者和反对派不会忘记这一点。";
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[57] += 30;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[22] -= 100;
					GlobalScript.inst.gameState.data[6] += 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "我们组织了一场全民公决，当然，大多数人投票赞成保留新疆现状。\n那些不满的民族主义者和其他激进分子走上街头，\n声称存在造假，但在失去以往支持之后，\n这些抗议已不再构成严重威胁。";
					GlobalScript.inst.gameState.data[4] += 30;
					GlobalScript.inst.gameState.data[57] += 20;
					GlobalScript.inst.gameState.data[3] -= 20;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[8] -= 40;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 11)
			{
				text2 = "工业衰退";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "财政预算中大笔资金被紧急拨付用于工业现代化、\n引进进口技术，并吸纳该领域专家参与。\n问题开始得到解决";
					GlobalScript.inst.gameState.data[12] += 100;
					GlobalScript.inst.gameState.data[8] -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们吸引外资的运动大获成功！\n现在，外国人自己出钱出力建厂、改造、\n现代化我们的工厂，连一分钱预算都不用。\n不错，为此需要压低最低工资、降低生产安全要求以及劳动立法的其\n他要求——不过没关系，受苦的还是人民。";
					GlobalScript.inst.gameState.data[12] += 100;
					GlobalScript.inst.gameState.data[5] -= 50;
					GlobalScript.inst.gameState.data[4] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "苏联同意像从前那样帮助我们进行工业现代化。\n然而，他并不太喜欢无偿分发专家和机器，\n我们对苏联也因此产生了一定依赖。";
					GlobalScript.inst.gameState.data[12] += 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic12 in politics)
					{
						if (politic12.traits[0] == 3 || politic12.traits[0] == 2)
						{
							Politic politic = politic12;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "通过重新分配预算资金以及企业收入，我们把农业的力量导向工业发\n展。这帮助了工业，但农业遭受了沉重打击。";
					GlobalScript.inst.gameState.data[12] += 100;
					GlobalScript.inst.gameState.data[13] -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 12)
			{
				text2 = "农业衰退";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "财政预算中大笔资金被紧急拨付用于农业现代化、\n引进进口技术，并吸纳该领域专家参与。\n问题开始得到解决";
					GlobalScript.inst.gameState.data[13] += 100;
					GlobalScript.inst.gameState.data[8] -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们吸引外资的运动大获成功！\n现在，外国人自己出钱出力建造并改造、\n现代化我们的农场，连一分钱预算都不用。\n不错，为此需要压低最低工资、降低生产安全要求以及劳动立法的其\n他要求——不过没关系，受苦的还是人民。";
					GlobalScript.inst.gameState.data[13] += 100;
					GlobalScript.inst.gameState.data[5] -= 50;
					GlobalScript.inst.gameState.data[4] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "苏联同意像从前那样帮助我们发展农业。\n然而，他并不太喜欢无偿分发专家和机器，\n我们对苏联也因此产生了一定依赖。";
					GlobalScript.inst.gameState.data[13] += 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic13 in politics)
					{
						if (politic13.traits[0] == 3 || politic13.traits[0] == 2)
						{
							Politic politic = politic13;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "通过重新分配预算资金以及企业收入，我们把工业的力量导向农业发\n展。这帮助了农业，但工业遭受了沉重打击。";
					GlobalScript.inst.gameState.data[13] += 100;
					GlobalScript.inst.gameState.data[12] -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 13)
			{
				text2 = "服务业衰退";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "财政预算中大笔资金被紧急拨付用于服务业现代化、\n引进进口技术，并吸纳该领域专家参与。\n问题开始得到解决";
					GlobalScript.inst.gameState.data[68] += 100;
					GlobalScript.inst.gameState.data[8] -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们吸引外资的运动大获成功！\n现在，外国人自己出钱出力建造并改造、\n现代化我们的商店和餐馆，连一分钱预算都不用。\n不错，为此需要压低最低工资、降低生产安全要求以及劳动立法的其\n他要求——不过没关系，受苦的还是人民。";
					GlobalScript.inst.gameState.data[68] += 100;
					GlobalScript.inst.gameState.data[5] -= 50;
					GlobalScript.inst.gameState.data[4] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "苏联同意像从前那样帮助我们发展服务业。\n然而，他并不太喜欢无偿分发专家和机器，\n我们对苏联也因此产生了一定依赖。";
					GlobalScript.inst.gameState.data[68] += 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic14 in politics)
					{
						if (politic14.traits[0] == 3 || politic14.traits[0] == 2)
						{
							Politic politic = politic14;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "通过重新分配预算资金以及企业收入，把工农业的力量引导到服务业\n发展上。服务业因此受益，但工农业却遭到重创。";
					GlobalScript.inst.gameState.data[13] -= 100;
					GlobalScript.inst.gameState.data[12] -= 100;
					GlobalScript.inst.gameState.data[68] += 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 14)
			{
				text2 = "我们没钱，但你们要挺住！";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "提高税费，压缩对群众的社会项目。\n当然，这有助于补充财政，但群众并不高兴。";
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[8] += 100;
					GlobalScript.inst.gameState.data[5] -= 300;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "提高奢侈品和超高收入的税负，使得在不伤害普通民众的情况下补充\n财政成为可能。但寡头们凭借势力，向群众宣称国家“掠夺守法的企\n业家”，并动用党内影响力的杠杆对你施压。";
					GlobalScript.inst.gameState.data[8] += 100;
					GlobalScript.inst.gameState.data[1] -= 500;
					GlobalScript.inst.gameState.data[4] += 300;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					GlobalScript.inst.gameState.data[108] -= 5;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "举借外债，确实有助于补充预算，却对我们的影响力造成负面影响。\n是的，而且你们还得还……";
					GlobalScript.inst.gameState.data[8] += 100;
					GlobalScript.inst.gameState.data[69] += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "许多国有企业被卖给私人，当然打击了生活水平、\n扰乱了我们的经济机制，但它确实有助于补充财政。";
					GlobalScript.inst.gameState.data[5] -= 100;
					GlobalScript.inst.gameState.data[8] += 100;
					GlobalScript.inst.gameState.data[12] -= 50;
					GlobalScript.inst.gameState.data[13] -= 50;
					GlobalScript.inst.gameState.data[68] -= 50;
					GlobalScript.inst.gameState.data[108] += 20;
					if (GlobalScript.inst.gameState.data[16] <= 12)
					{
						GlobalScript.inst.gameState.data[16] = 13;
					}
					else if (GlobalScript.inst.gameState.data[16] <= 14)
					{
						GlobalScript.inst.gameState.data[16]++;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 15)
			{
				text2 = "柬越战争";
				GlobalScript.inst.gameState.ingamewars[1].name_war = "柬越战争";
				GlobalScript.inst.gameState.ingamewars[1].is_going = true;
				GlobalScript.inst.gameState.ingamewars[1].side1 = "Kampuchea";
				GlobalScript.inst.gameState.ingamewars[1].side2 = "Vietnam";
				GlobalScript.inst.gameState.ingamewars[1].ussr_place = 1;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们决定不介入这场冲突。\n当然，波尔布特和红色高棉领导层对此非常不满，\n但看来他们也活不长——越军推进很快，\n而柬埔寨军队正在大规模逃亡。\n看来波尔布特政权的垮台只是时间问题。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.ingamewars[1].infl1 = 300;
					GlobalScript.inst.gameState.ingamewars[1].infl2 = 700;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们与柬埔寨军队内部的左派反对派取得联系，\n组织了对波尔布特的架空与逮捕。\n临时革命委员会已上台，但尚未把柬埔寨从波尔布特所带来的混乱中\n拉出来。看到波尔布特已完蛋，军队对越军的抵抗更积极，\n而越南本身也不那么果断了，因为这次战役的主要目标已经达成。\n只是柬埔寨的新领导层仍然忠于中国。";
					GlobalScript.inst.gameState.data[9] -= 30;
					GlobalScript.inst.gameState.ingamewars[1].infl1 = 450;
					GlobalScript.inst.gameState.ingamewars[1].infl2 = 550;
					GlobalScript.inst.gameState.allcountries[23].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[23].SubGosstroy = 1;
					party_change[2] = 1f;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "我们向老盟友波尔布特提供了援助，但这是否足够他也不得而知。\n越军推进顺利，柬埔寨士兵正在积极逃亡，\n而波尔布特政权并不得到民众支持。\n越南和苏联对我们的行动仍然不满，恐怕会继续加强合作，\n从而对我们不利。";
					GlobalScript.inst.gameState.data[22] -= 50;
					GlobalScript.inst.gameState.data[8] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GlobalScript.inst.gameState.ingamewars[1].infl1 = 400;
					GlobalScript.inst.gameState.ingamewars[1].infl2 = 600;
					party_change[0] = 1f;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 16)
			{
				text2 = "泰国选举";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "1976年的竞选活动伴随着血腥的街头冲突，\n约有30人丧生。森尼·巴莫吉的民主党——比库立·巴莫吉的社会\n行动党更偏右——获得最多选票。\n右翼民族党领袖蓬波尔·阿迪雷沙恩出任副总理。\n左翼激进派的影响力明显下降。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 5;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们设法对CPT提供了相当的支持，并通过终止对军事基地的党派\n袭击，与各类温和左翼活动分子达成联盟，\n同时也使同社会行动党与民主党的关系有所回暖。\n1976年的竞选活动伴随着血腥的街头冲突。\n结果，首相库立·巴莫吉的社会行动党获得最多选票，\n必须与民主党和CPT组成联合政府。\n政府中的王党派与军官对左翼力量的增强不满，\n局势正在升温。";
					GlobalScript.inst.gameState.data[9] -= 20;
					GlobalScript.inst.gameState.data[8] -= 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 5;
					GlobalScript.inst.gameState.data[41] = 100;
					party_change[0] = 0.5f;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "不理会选举，我们向CPT的游击队增送武器，\n他们继续以新力量袭扰军事据点。\n不过看来，这样CPT恐怕难以控制足够多的国土。\n1976年的竞选活动伴随着血腥的街头冲突，\n约有30人丧生。森尼·巴莫吉的民主党——比库立·巴莫吉的社会\n行动党更偏右——获得最多选票。\n右翼民族党领袖蓬波尔·阿迪雷沙恩出任副总理。";
					GlobalScript.inst.gameState.data[22] -= 20;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					party_change[2] = 1f;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 17)
			{
				text2 = "泰国局势不稳";
				GlobalScript.inst.gameState.TaiCoup = true;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "10月6日，警力与右翼武装一起突破到大学范围内，\n尽管学生愿意投降，仍开始屠杀。\n据多方消息，死亡人数可能超过100人。\n同日傍晚，极右翼武装联合军方强迫总理普拉莫吉辞职。\n在国王支持下，政府再次转向军事政变集团，\n结束为期三年的民主时期。\n泰国再次进入镇压时代，而CPT仅在该国北部保留了党派行动。";
					GlobalScript.inst.gameState.allcountries[34].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[34].SubGosstroy = 7;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 5;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏我们的支持以及特工部门的努力，CPT的武装分子进入塔玛萨\n特大学，并与学生一起同右翼武装展开战斗，\n结果却由赶到“右边”的警察决定。\n然而此时，冲突与示威已在曼谷各处发生，\n为了镇压，军队和警察被投入行动。\n普拉莫吉总理被军方逮捕。\n这种残酷与混乱的开端令社会震惊，并迫使许多学生、\n工会活动分子和工人进入CPT的组织体系；\n而CPT则借助混乱，从该国北部发动全面攻势。";
					GlobalScript.inst.gameState.data[9] -= 40;
					GlobalScript.inst.gameState.data[22] -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GlobalScript.inst.gameState.allcountries[34].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[34].SubGosstroy = 7;
					party_change[0] = 1f;
					GlobalScript.inst.gameState.ingamewars[2].name_war = "泰国内战";
					GlobalScript.inst.gameState.ingamewars[2].is_going = true;
					GlobalScript.inst.gameState.ingamewars[2].side1 = "Communists";
					GlobalScript.inst.gameState.ingamewars[2].side2 = "Loyalists";
					GlobalScript.inst.gameState.ingamewars[2].usa_place = 1;
					GlobalScript.inst.gameState.ingamewars[2].ussr_place = 0;
					GlobalScript.inst.gameState.ingamewars[2].infl1 = 300;
					GlobalScript.inst.gameState.ingamewars[2].infl2 = 700;
					if (GlobalScript.inst.gameState.allcountries[34].stab == 1)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[2];
						warinwars2.infl1 += 50;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[2];
						warinwars2.infl2 -= 50;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "10月6日，警力与右翼武装一起突破到大学范围内，\n尽管学生愿意投降，仍开始屠杀。\n据多方消息，死亡人数可能超过100人。\n同日傍晚，极右翼武装联合军方强迫总理普拉莫吉辞职。\n在国王支持下，政府再次转向军事政变集团，\n结束为期三年的民主时期。\n泰国再次进入镇压时代，而CPT仅在该国北部保留了党派行动。\n我们正式谴责军事政变集团的残暴，并向CPT追加支持，\n但恐怕改变不了什么。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 5;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.allcountries[34].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[34].SubGosstroy = 7;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 18)
			{
				text2 = "战争结束了";
				text = "又一场战争结束了。";
				GlobalScript.inst.gameState.data[0] = 0;
				GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].is_going = false;
				GlobalScript.inst.gameState.WarResult(ref text);
				GlobalScript.inst.gameState.data[82] = -10;
			}
			else if (GlobalScript.inst.gameState.number_event == 19)
			{
				text2 = "五个“不”";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "传言说是毛泽东本人亲自发动了“五不”运动，\n虽然没人敢肯定——他因病重几乎联系不上，\n决策又必须迅速作出。\n运动期间，政府和警察人员拆除临时纪念物，\n撕掉标注周恩来功绩的海报。\n持续的抹黑宣传，以及禁止公开悼念逝者，\n引发了群众对毛泽东和最高层的不满，尤其是对他的妻子江青。";
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[88]++;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "传言说是毛泽东本人亲自发动了“五不”运动，\n虽然没人敢肯定——他因病重几乎联系不上，\n决策又必须迅速作出。\n作为国务院总理、同时也是公安部长，你亲自盯着运动的严格执行。\n运动期间，政府和警察人员拆除临时纪念物，\n撕掉标注周恩来功绩的海报。\n持续的抹黑宣传，以及禁止公开悼念逝者，\n引发了群众对毛泽东和最高层的广泛不满，\n尤其是对他的妻子江青以及接班人华国锋。";
					GlobalScript.inst.gameState.data[3] -= 70;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[6] += 10;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic15 in politics)
					{
						if (politic15.traits[0] == 0)
						{
							Politic politic = politic15;
							politic.loyality += 70;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "传言说是毛泽东本人亲自发动了“五不”运动，\n虽然没人敢肯定——他因病重几乎联系不上，\n决策又必须迅速作出。\n作为国务院总理、同时也是公安部长，你亲自盯着运动的严格执行，\n并负责在报纸上刊发对周恩来的批判；然而这对早已厌倦“文化大革\n命精神”式批判的人们并没有什么效果。\n运动期间，政府和警察人员拆除临时纪念物，\n撕掉标注周恩来功绩的海报。\n持续的抹黑宣传，以及禁止公开悼念逝者，\n引发了群众对毛泽东和最高层的广泛不满，\n尤其是对他的妻子江青以及接班人华国锋。";
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.data[88]--;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic16 in politics)
					{
						if (politic16.traits[0] == 0)
						{
							Politic politic = politic16;
							politic.loyality += 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "传言说是毛泽东本人亲自发动了“五不”运动，\n虽然没人敢肯定——他因病重几乎联系不上，\n决策又必须迅速作出。\n作为国务院总理、同时也是公安部长，你尽可能地缓和了运动的影响。\n运动期间，政府和警察人员拆除临时纪念物，\n撕掉标注周恩来功绩的海报。\n持续的抹黑宣传，以及禁止公开悼念逝者，\n确实引发了群众对最高层的广泛不满，尤其是对他的妻子江青；\n不过多亏你在暗中破坏运动，这种不满没有超出合理限度。";
					GlobalScript.inst.gameState.data[3] -= 10;
					GlobalScript.inst.gameState.data[88] += 2;
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[6] -= 10;
					Politic politic = GlobalScript.inst.gameState.politics[12];
					politic.loyality += 200;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic17 in politics)
					{
						if (politic17.traits[0] == 0)
						{
							politic = politic17;
							politic.loyality -= 70;
						}
						else if (politic17.traits[0] >= 1)
						{
							politic = politic17;
							politic.loyality += 50;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 20)
			{
				text2 = "批邓反右！";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在江青集团控制的媒体上，对邓小平及其思想的积极迫害开始了。\n邓小平被撤去一切职务，党籍卡却留在他手里，\n这几个月他被关在家里，等待命运。\n像江青集团的任何行动一样，这次也没有在群众中引起同情；\n在群众眼里，小平因与深受欢迎的周恩来关系密切、\n并试图借助市场乃至资本主义工具把中国从“大跃进”的灾难后果中\n拉出来而受到尊敬。3月3日毛泽东发出指示，\n确认文化大革命的合法性，并指出邓小平是国内问题；\n随后，各省党委也很快加入对小平的批判。";
					GlobalScript.inst.gameState.data[3] -= 20;
					GlobalScript.inst.gameState.data[4] += 40;
					Politic politic = GlobalScript.inst.gameState.politics[12];
					politic.power -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "在江青集团控制的媒体上，对邓小平及其思想的积极迫害开始了。\n新任总理华国锋也加入迫害，称邓的改革思想会把中国引向资本主义\n奴役。邓小平被撤去所有职务，但保留党籍，\n被迫进入强制隐居。像江青集团的任何行动一样，\n这次也没有在群众中引起同情；在群众眼里，\n小平因与深受欢迎的周恩来关系密切、并试图借助市场乃至资本主义\n工具把中国从“大跃进”的灾难后果中拉出来而受到尊敬。\n3月3日毛泽东发出指示，确认文化大革命的合法性，\n并指出邓小平是国内问题；随后，各省党委也很快加入对小平的批判。";
					GlobalScript.inst.gameState.data[1] += 80;
					GlobalScript.inst.gameState.data[3] -= 20;
					GlobalScript.inst.gameState.data[88]--;
					GlobalScript.inst.gameState.data[4] += 30;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic18 in politics)
					{
						if (politic18.traits[0] == 0)
						{
							politic = politic18;
							politic.loyality += 50;
						}
						else if (politic18.traits[0] == 2)
						{
							politic = politic18;
							politic.loyality -= 100;
						}
					}
					politic = GlobalScript.inst.gameState.politics[12];
					politic.power -= 130;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在江青集团控制的媒体上，对邓小平及其思想的积极迫害开始了。\n然而你为他辩护，认为小平犯过错误但承认了错误，\n帮助中国发展；如今却在形式上仍保留党籍的情况下被撤去一切职务。\n这在党内最高层引起不满，但在群众中却引起共鸣；\n在群众眼里，小平因与深受欢迎的周恩来关系密切、\n并试图借助市场乃至资本主义工具把中国从“大跃进”的灾难后果中\n拉出来而受到尊敬。3月3日毛泽东发出指示，\n确认文化大革命的合法性，并指出邓小平是国内问题；\n随后，各省党委也加入对小平的批判。";
					GlobalScript.inst.gameState.data[3] += 20;
					GlobalScript.inst.gameState.data[1] -= 70;
					GlobalScript.inst.gameState.data[88]++;
					GlobalScript.inst.gameState.data[4] += 50;
					Politic politic = GlobalScript.inst.gameState.politics[12];
					politic.loyality += 200;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic19 in politics)
					{
						if (politic19.traits[0] == 0)
						{
							politic = politic19;
							politic.loyality -= 100;
						}
						else if (politic19.traits[0] == 3)
						{
							politic = politic19;
							politic.loyality += 50;
						}
						else if (politic19.traits[0] > 0)
						{
							politic = politic19;
							politic.loyality += 100;
						}
					}
					politic = GlobalScript.inst.gameState.politics[12];
					politic.power -= 80;
					politic = GlobalScript.inst.gameState.politics[12];
					politic.loyality += 250;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 21)
			{
				text2 = "神秘文章与老鬼";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "一篇不明不白的文章引发了谣言：有人说它攻击周恩来，\n也有人低声说它针对周荣鑫；还有人说，\n邓的“资本主义道路”把对恩来的提法夸大其词，\n借此煽动对“倒下的英雄”的悲痛。\n目标不明、火气又大，我们选择低头不惹事，\n免得落到挥下的屠刀之下。\n即便如此，消息还是传开了，长江沿岸各城——尤其南京——抗议之\n火迅速燃起，如今即便我们消极应对，也正传到北京。";
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[4] += 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "文章的具体指向仍然扑朔迷离：有人看出是在影射周恩来，\n也有人坚持说是周荣鑫，并认为邓的“资本主义道路”炒作所谓“恩\n来侮辱”，以激起群众情绪。\n我们强力抓文本、掐断任何猜测，避免给群众送上“烈士”。\n严控确实减缓了扩散；抗议仍然爆发，但规模被控制在一定范围内。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[3] -= 30;
					GlobalScript.inst.gameState.data[4] += 30;
					GlobalScript.inst.gameState.data[88] += 2;
					Politic politic = GlobalScript.inst.gameState.politics[12];
					politic.loyality += 200;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic20 in politics)
					{
						if (politic20.traits[0] == 0)
						{
							politic = politic20;
							politic.loyality -= 70;
						}
						else if (politic20.traits[0] > 0 && politic20.traits[0] < 3)
						{
							politic = politic20;
							politic.loyality += 50;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "由于文章的目的不明——有人说是恩来，\n有人说是周荣鑫——你把它包装成“资本主义道路改革的危险”的证\n据，并把它推到上海之外。\n党内觉得这条路子不错，群众却不买账。\n抗议在互相竞争的谣言推动下席卷长江沿岸各城，\n首当其冲的是南京；而在我们的放大之下，\n也传到了北京。就目前而言，局势仍在可控范围内。";
					GlobalScript.inst.gameState.data[3] -= 80;
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[88]--;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic21 in politics)
					{
						if (politic21.traits[0] == 0)
						{
							Politic politic = politic21;
							politic.loyality += 100;
						}
						else if (politic21.traits[0] > 0 && politic21.traits[0] < 3)
						{
							Politic politic = politic21;
							politic.loyality -= 70;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 22)
			{
				text2 = "天安门事件";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "按照江青、张春桥的路线，我们先用广播号召把悼念者与挑衅者分开，\n然后出动北京市公安与北京卫戍部队清场。\n发生了冲突和殴打，但没有人被杀；约一百人被拘留，\n随后大多数很快获释。\n天安门的事件被官方定性为反革命事件，\n并把责任推给邓小平。\n根据毛泽东的提议，政治局正式撤销邓小平的一切职务，\n同时保留其在中共的党籍。\n邓本人现由老战友、广州军区司令员徐世友保护，\n在广州。";
					GlobalScript.inst.gameState.data[3] -= 250;
					GlobalScript.inst.gameState.data[4] -= 200;
					GlobalScript.inst.gameState.data[6] += 60;
					GlobalScript.inst.gameState.data[1] += 100;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic22 in politics)
					{
						if (politic22.traits[0] == 0)
						{
							politic = politic22;
							politic.loyality += 100;
						}
						else if (politic22.traits[0] > 0)
						{
							politic = politic22;
							politic.loyality -= 100;
						}
					}
					politic = GlobalScript.inst.gameState.politics[12];
					politic.power -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "晚上六点半，吴德通过扩音器呼吁群众散去。\n许多人离开了，也有些人留下。\n到了夜里，市公安和北京卫戍部队驱散了剩余的抗议人群。\n没有人死亡；约一百人被拘留，随后大多数获释。\n接下来的几天，广场仍由军警控制。\n天安门的事件被官方定性为反革命事件，\n并把责任推给邓小平。\n根据毛泽东的提议，政治局在保留邓小平中共党籍的同时，\n撤销其一切职务。邓现在在广州，由老战友、\n广州军区司令员徐世友保护。";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[4] -= 150;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic23 in politics)
					{
						if (politic23.traits[0] == 0)
						{
							politic = politic23;
							politic.loyality += 50;
						}
					}
					politic = GlobalScript.inst.gameState.politics[12];
					politic.power -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "晚上六点半，吴德通过扩音器呼吁群众回家。\n许多人离开了，但也有些人留下。\n到了夜里，警察和北京卫戍部队清理了广场。\n没有人被杀；大约一百人被拘留，随后大多数获释。\n接下来的几天，广场仍处于军警控制之下。\n天安门的事件被官方定性为反革命事件，\n并把责任推给邓小平。\n根据毛泽东的提议，政治局在保留邓小平中共党籍的同时，\n撤销其一切职务。邓现在在广州，由老战友、\n广州军区司令员徐世友保护。";
					GlobalScript.inst.gameState.data[4] -= 100;
					GlobalScript.inst.gameState.data[1] -= 50;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic24 in politics)
					{
						if (politic24.traits[0] == 0)
						{
							politic = politic24;
							politic.loyality += 50;
						}
					}
					politic = GlobalScript.inst.gameState.politics[12];
					politic.power -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 23)
			{
				text2 = "唐山地震";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "中华人民共和国预算资金立即拨付，用于开展救援与恢复工作，\n从而减轻了地震的影响。\n今天的唐山地震，结果成为继1556年陕西地震之后，\n历史上伤亡人数第二多的一次地震。";
					GlobalScript.inst.gameState.data[3] += 30;
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[8] -= 30;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "国际社会与慈善机构在评估灾害规模后，\n决定以无偿贷款和志愿者援助的形式向我们提供帮助，\n从而减轻了地震的影响。\n今天的唐山地震，结果成为继1556年陕西地震之后，\n历史上伤亡人数第二多的一次地震。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 5;
					GlobalScript.inst.gameState.data[4] += 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "中华人民共和国预算资金立即拨付，用于开展救援和恢复工作，\n从而减轻了地震的影响。\n今天的唐山地震，结果竟成为继1556年陕西地震之后、\n历史上受害者人数第二多的地震。\n另拨经费用于对危险地区建设抗震建筑，\n并对现有建筑的适用性进行了大量测试，\n暴露出种种违规。我们希望今后能借此避免如此多的伤亡。";
					GlobalScript.inst.gameState.data[5] += 50;
					GlobalScript.inst.gameState.data[3] += 30;
					GlobalScript.inst.gameState.data[1] += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 5;
					GlobalScript.inst.gameState.data[8] -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "中央对河北省的问题充耳不闻，这当然使得消除地震后果困难重重，\n也引起了民众的不满，但地方政府总算是应付过去了。\n今天的唐山地震，结果竟成为继1556年陕西地震之后、\n历史上受害者人数第二多的地震。";
					GlobalScript.inst.gameState.data[5] -= 50;
					GlobalScript.inst.gameState.data[3] -= 40;
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[4] += 30;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 24)
			{
				text2 = "变革的风？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "你和汪东兴炮制了“两个凡是”的口号——“凡是毛主席作出的决策，\n我们都坚决维护；凡是毛主席发出的指示，\n我们都一以贯之地遵循”——以此为新领导层“正名”。\n如今你把它更多包装成个人的荣誉准则，\n而不是僵硬的路线，同时又悄悄掐灭那场久已衰微的文化大革命最后\n的余火，倒也讨得了人心。\n可即便如此，守着保守的毛主义仍会在国内外以及中共改革圈里引起\n不安。";
					GlobalScript.inst.gameState.data[3] += 20;
					GlobalScript.inst.gameState.data[4] += 100;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GlobalScript.inst.gameState.modifies[3].active = false;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic25 in politics)
					{
						if (politic25.traits[0] == 0)
						{
							Politic politic = politic25;
							politic.loyality += 100;
						}
						else if (politic25.traits[0] == 2)
						{
							Politic politic = politic25;
							politic.loyality -= 100;
						}
						else if (politic25.traits[0] == 1)
						{
							Politic politic = politic25;
							politic.loyality += 50;
						}
					}
					party_change[0] = 3f;
					party_change[1] = 5f;
					GlobalScript.inst.gameState.data[87] = 1;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "你和汪东兴依靠忠于激进派的力量，把你们自己的“两个凡是”公式\n抬升为必须遵守的“铁律”——“凡是毛主席作出的决策，\n我们都坚决维护；凡是毛主席发出的指示，\n我们都一以贯之地遵循”——以此稳固你们的权威。\n你们宣称要毫不妥协地反对修正主义，忠于毛和文化大革命，\n并试图用“从过去错误中吸取的教训”把它重新点燃。\n一波镇压打向修正主义者，另一波反抗则从厌倦了文化大革命再度转\n向的人群中涌起。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[6] += 100;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic26 in politics)
					{
						if (politic26.traits[0] == 0)
						{
							Politic politic = politic26;
							politic.loyality += 100;
						}
						else if (politic26.traits[0] > 0)
						{
							Politic politic = politic26;
							politic.loyality -= 200;
							politic = politic26;
							politic.power -= 100;
						}
					}
					party_change[0] = 8f;
					party_change[1] = 3f;
					GlobalScript.inst.gameState.data[87] = 2;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "你和汪东兴提醒干部们“两个凡是”出自你们之手，\n以此为权力交接“站台”。\n你们把它包装成荣誉守则而非硬邦邦的路线，\n同时宣布文化大革命的任务已经完成，准备清算其最后的残余。\n你还强调要调整和实现经济现代化，却尚未说明具体路径。\n改革者在悬念中等待，人民则期待改进。";
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[4] += 80;
					GlobalScript.inst.gameState.modifies[3].active = false;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic27 in politics)
					{
						if (politic27.traits[0] == 0)
						{
							Politic politic = politic27;
							politic.loyality -= 20;
						}
						else if (politic27.traits[0] < 3)
						{
							Politic politic = politic27;
							politic.loyality += 100;
						}
					}
					party_change[2] = 8f;
					party_change[3] = 3f;
					GlobalScript.inst.gameState.data[87] = 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "你和汪东兴把“两个凡是”——你们自己的那套公式——宣称为严格\n必须遵守的“硬线”，以巩固你们的授权，\n同时又宣布要迅速拆除文化大革命的残余。\n与此同时，你们谈到进一步的市场改革以及逐步面向世界市场的开放，\n提拔像赵紫阳这样的老牌改革者，并让邓小平重回副总理岗位。\n人民期待更好的日子，尽管保守派对这些决定怒目而视。";
					GlobalScript.inst.gameState.data[3] += 80;
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.modifies[3].active = false;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic28 in politics)
					{
						if (politic28.traits[0] == 0)
						{
							Politic politic = politic28;
							politic.loyality -= 100;
						}
						else if (politic28.traits[0] > 1)
						{
							Politic politic = politic28;
							politic.loyality += 100;
						}
					}
					party_change[2] = 3f;
					party_change[3] = 8f;
					party_change[4] = 3f;
					GlobalScript.inst.gameState.data[87] = 4;
					if (GlobalScript.inst.gameState.modifies[59].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = true;
						GlobalScript.inst.gameState.modifies[62].active = false;
					}
					else if (GlobalScript.inst.gameState.modifies[60].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = true;
						GlobalScript.inst.gameState.modifies[62].active = false;
					}
					else if (GlobalScript.inst.gameState.modifies[61].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = false;
						GlobalScript.inst.gameState.modifies[62].active = true;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 25)
			{
				text2 = "四人帮";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在争取了第8341特种团以及最高将领的支持后，\n华国锋召集了政治局的非常会议，当场逮捕了激进派的主要头目。\n此后，一波又一波对忠于激进派的官员的抓捕席卷北京和上海，\n几乎没有遭到抵抗。新闻界随即发动大规模运动，\n声讨那些阴谋者——早已被称为“<b>四人帮</b>”——并把他们归咎于文化\n大革命造成的众多受害者，以及毛泽东逝世后企图夺权。\n人民——和大多数党员一样——总体上如释重负地接受了激进派的失\n败，并逐渐表达出希望国内政策有所缓和的愿望。";
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[1] += 100;
					GlobalScript.inst.gameState.data[6] -= 30;
					GlobalScript.inst.gameState.data[84] = 1;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic29 in politics)
					{
						if (politic29.traits[0] == 0)
						{
							politic = politic29;
							politic.loyality -= 50;
						}
						else if (politic29.traits[0] == 2)
						{
							politic = politic29;
							politic.loyality += 50;
						}
						else if (politic29.traits[0] == 1)
						{
							politic = politic29;
							politic.loyality += 50;
						}
					}
					party_change[1] = 2.5f;
					party_change[2] = 1.5f;
					party_change[3] = 1.5f;
					GlobalScript.inst.gameState.KillPerson(0);
					GlobalScript.inst.gameState.KillPerson(1);
					GlobalScript.inst.gameState.KillPerson(2);
					GlobalScript.inst.gameState.KillPerson(3);
					GlobalScript.inst.gameState.KillPerson(4);
					GlobalScript.inst.gameState.KillPerson(17);
					politic = GlobalScript.inst.gameState.politics[6];
					politic.power += 100;
					politic = GlobalScript.inst.gameState.politics[7];
					politic.power += 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "华国锋不愿冒险，决定只逮捕代表对当局最大威胁的王洪文和江青。\n这发生在一次专门召开的政治局会议上。\n与此同时，姚文元和张春桥被“安排”进入政府，\n以换取对现任统治者的忠诚。\n左派的地位被削弱了，但并未削弱到可以完全无视他们的程度——尽\n管他们现在也别想再做夺权的美梦。\n舆论战随即展开，矛头指向江青和王洪文，\n指控他们企图夺权、以及在文化大革命时期的种种过火。\n总体而言，人民和大多数党员都如释重负地接受了他们的倒台，\n尽管不少人仍为“仍有一些激进分子掌权”而感到紧张，\n并认为阴谋者不过是“<b>替罪羊</b>”。";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.data[84] = 2;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic30 in politics)
					{
						if (politic30.traits[0] == 0)
						{
							politic = politic30;
							politic.loyality -= 20;
						}
						else if (politic30.traits[0] == 2)
						{
							politic = politic30;
							politic.loyality += 50;
						}
						else if (politic30.traits[0] == 1)
						{
							politic = politic30;
							politic.loyality += 70;
						}
					}
					party_change[1] = 2f;
					party_change[2] = 1f;
					party_change[3] = 1f;
					GlobalScript.inst.gameState.KillPerson(1);
					GlobalScript.inst.gameState.KillPerson(2);
					politic = GlobalScript.inst.gameState.politics[6];
					politic.power += 100;
					politic = GlobalScript.inst.gameState.politics[7];
					politic.power += 100;
					if (GlobalScript.inst.gameState.politics_dolshnost[2] < 50)
					{
						politic = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[2]];
						politic.loyality -= 200;
					}
					GlobalScript.inst.gameState.politics_dolshnost[2] = 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "毛泽东逝世后，改革派影响力不断扩大，\n不仅吓着了华国锋，也吓着王-张-江-姚集团，\n于是新任中华人民共和国主席决定与他们“结盟”。\n谈判长期由毛远新（毛泽东的侄子）居中斡旋。\n可最终还是达成了协议——作为支持的交换，\n王-张-江-姚集团提出条件：撤掉中华人民共和国国防部长、\n叶剑英元帅的职务，并将中共中央军委主席与中华人民共和国外交部\n长的职位转交给她。华国锋同志同意了这些条件。\n中共中央军委由王洪文担任负责人，姚文元出任外长，\n担任北京军区司令的陈锡联则出任国防部长。\n在中共中央政治局会议上，邓小平再次遭到攻击，\n重新喊回口号：“批邓、反击右倾翻案风，\n反对修正正确决定”。\n“小平”的影响力又开始回落，尤其是他的“<b>守护天使</b>”简宁离开了\n人民解放军的指挥岗位……\n然而，人民和大多数党员对这种荒唐的联盟并不满意，\n这也预示着文化大革命将继续。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[4] += 250;
					GlobalScript.inst.gameState.data[84] = 3;
					GlobalScript.inst.gameState.data[6] += 50;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic31 in politics)
					{
						if (politic31 != null)
						{
							if (politic31.traits[0] == 0)
							{
								politic = politic31;
								politic.loyality += 200;
							}
							else if (politic31.traits[0] < 3)
							{
								politic = politic31;
								politic.loyality -= 100;
							}
						}
					}
					party_change[0] = 2.5f;
					party_change[1] = 1.5f;
					GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.1f);
					politic = GlobalScript.inst.gameState.politics[7];
					politic.power -= 100;
					politic = GlobalScript.inst.gameState.politics[12];
					politic.power -= 100;
					politic = GlobalScript.inst.gameState.politics[9];
					politic.power += 100;
					if (GlobalScript.inst.gameState.politics_dolshnost[2] < 50)
					{
						politic = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[2]];
						politic.loyality -= 200;
					}
					GlobalScript.inst.gameState.politics_dolshnost[2] = 4;
					if (GlobalScript.inst.gameState.politics_dolshnost[1] < 50)
					{
						politic = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[1]];
						politic.loyality -= 200;
					}
					GlobalScript.inst.gameState.politics_dolshnost[1] = 150;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "Well...";
					GlobalScript.inst.gameState.data[35] = 2;
					load_scene_after_click = "Ending";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 26)
			{
				text2 = "弱联盟";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在争取了第8341特种团以及最高将领的支持后，\n华国锋召集了政治局的非常会议，当场逮捕了激进派的主要头目。\n此后，随着激进派影响力的上升，虽然也难免出现一些过火，\n但一波又一波对忠于激进派官员的抓捕仍席卷北京和上海。\n新闻界随即发动大规模运动，声讨那些阴谋者——早已被称为“<b>四人\n帮</b>”——并把他们归咎于文化大革命造成的众多受害者，\n以及毛泽东逝世后企图夺权。\n人民——和大多数党员一样——总体上如释重负地接受了激进派的失\n败，尽管考虑到此前曾与他们结过盟，这些行动并未给华国锋带来太\n多声望。";
					GlobalScript.inst.gameState.data[3] += 40;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[6] -= 30;
					GlobalScript.inst.gameState.data[9] -= 70;
					GlobalScript.inst.gameState.data[84] = 1;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic32 in politics)
					{
						if (politic32.traits[0] == 0)
						{
							politic = politic32;
							politic.loyality -= 100;
						}
						else if (politic32.traits[0] == 2)
						{
							politic = politic32;
							politic.loyality += 50;
						}
						else if (politic32.traits[0] == 1)
						{
							politic = politic32;
							politic.loyality += 50;
						}
					}
					party_change[1] = 2.5f;
					party_change[2] = 1.5f;
					party_change[3] = 1.5f;
					GlobalScript.inst.gameState.KillPerson(1);
					GlobalScript.inst.gameState.KillPerson(2);
					GlobalScript.inst.gameState.KillPerson(3);
					GlobalScript.inst.gameState.KillPerson(4);
					politic = GlobalScript.inst.gameState.politics[6];
					politic.power += 100;
					politic = GlobalScript.inst.gameState.politics[5];
					politic.power += 400;
					politic = GlobalScript.inst.gameState.politics[7];
					politic.power += 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "华国锋不愿冒险，决定只逮捕代表对当局最大威胁的王洪文和江青。\n这发生在一次专门召开的政治局会议上。\n与此同时，姚文元和张春桥被“安排”获得进一步升迁，\n以换取对现任统治者的忠诚。\n左派的地位被削弱了，但并未削弱到可以完全无视他们的程度——尽\n管他们现在也别想再做夺权的美梦。\n舆论战随即展开，矛头指向江青和王洪文，\n指控他们企图夺权、以及在文化大革命时期的种种过火。\n总体而言，人民和大多数党员都如释重负地接受了他们的倒台，\n尽管不少人仍为“仍有一些激进分子掌权”而感到紧张，\n并认为阴谋者不过是“<b>替罪羊</b>”，尤其因为华国锋此前已经向他们让\n过步，因此这一决定对他的声望提升并不明显。";
					GlobalScript.inst.gameState.data[1] += 20;
					GlobalScript.inst.gameState.data[3] += 20;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[84] = 2;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic33 in politics)
					{
						if (politic33.traits[0] == 0)
						{
							politic = politic33;
							politic.loyality -= 50;
						}
						else if (politic33.traits[0] == 2)
						{
							politic = politic33;
							politic.loyality += 50;
						}
						else if (politic33.traits[0] == 1)
						{
							politic = politic33;
							politic.loyality += 50;
						}
					}
					party_change[1] = 2f;
					party_change[2] = 1f;
					party_change[3] = 1f;
					GlobalScript.inst.gameState.KillPerson(1);
					GlobalScript.inst.gameState.KillPerson(2);
					politic = GlobalScript.inst.gameState.politics[3];
					politic.power += 100;
					politic = GlobalScript.inst.gameState.politics[4];
					politic.power += 100;
					if (GlobalScript.inst.gameState.politics_dolshnost[2] < 100)
					{
						politic = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[2]];
						politic.loyality -= 200;
					}
					GlobalScript.inst.gameState.politics_dolshnost[2] = 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "担心与日益壮大的激进派公开翻脸，华国锋又作出进一步让步，\n等于放开他们的手去打击反对者，而他们正积极利用这一点，\n包括把“国防”——也就是华国锋——从权力上挤下去；\n他每天都在失去控制。\n照这样下去，王洪文就会逐渐成为新的事实上的国家首脑，\n依靠其同伙运作。然而他们仍记得自己的胜利要归功于谁，\n所以华国锋也许暂时不必担心遭到清算，\n但他的仕途终点只是时间问题。\n所有这些变化在党内和人民中引起了恐惧与不满，\n大家现在都在等待文化大革命的下一轮。";
					GlobalScript.inst.gameState.data[1] -= 200;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[6] += 100;
					int[] array5 = new int[16]
					{
						GlobalScript.inst.gameState.leader.name_1,
						GlobalScript.inst.gameState.leader.name_2,
						GlobalScript.inst.gameState.leader.traits[0],
						GlobalScript.inst.gameState.leader.traits[1],
						GlobalScript.inst.gameState.leader.traits[2],
						GlobalScript.inst.gameState.leader.age,
						GlobalScript.inst.gameState.leader.face_type,
						GlobalScript.inst.gameState.leader.face_parts[0],
						GlobalScript.inst.gameState.leader.face_parts[1],
						GlobalScript.inst.gameState.leader.face_parts[2],
						GlobalScript.inst.gameState.leader.face_parts[3],
						GlobalScript.inst.gameState.leader.face_parts[4],
						GlobalScript.inst.gameState.leader.face_parts[5],
						GlobalScript.inst.gameState.leader.face_parts[6],
						GlobalScript.inst.gameState.leader.face_parts[7],
						GlobalScript.inst.gameState.leader.jacket
					};
					GlobalScript.inst.gameState.leader.name_1 = GlobalScript.inst.gameState.politics[2].name_1;
					GlobalScript.inst.gameState.leader.name_2 = GlobalScript.inst.gameState.politics[2].name_2;
					GlobalScript.inst.gameState.leader.traits[0] = GlobalScript.inst.gameState.politics[2].traits[0];
					GlobalScript.inst.gameState.leader.traits[1] = GlobalScript.inst.gameState.politics[2].traits[1];
					GlobalScript.inst.gameState.leader.traits[2] = GlobalScript.inst.gameState.politics[2].traits[2];
					GlobalScript.inst.gameState.leader.age = GlobalScript.inst.gameState.politics[2].age;
					GlobalScript.inst.gameState.leader.face_type = GlobalScript.inst.gameState.politics[2].face_type;
					GlobalScript.inst.gameState.leader.face_parts[0] = GlobalScript.inst.gameState.politics[2].face_parts[0];
					GlobalScript.inst.gameState.leader.face_parts[1] = GlobalScript.inst.gameState.politics[2].face_parts[1];
					GlobalScript.inst.gameState.leader.face_parts[2] = GlobalScript.inst.gameState.politics[2].face_parts[2];
					GlobalScript.inst.gameState.leader.face_parts[3] = GlobalScript.inst.gameState.politics[2].face_parts[3];
					GlobalScript.inst.gameState.leader.face_parts[4] = GlobalScript.inst.gameState.politics[2].face_parts[4];
					GlobalScript.inst.gameState.leader.face_parts[5] = GlobalScript.inst.gameState.politics[2].face_parts[5];
					GlobalScript.inst.gameState.leader.face_parts[6] = GlobalScript.inst.gameState.politics[2].face_parts[6];
					GlobalScript.inst.gameState.leader.face_parts[7] = GlobalScript.inst.gameState.politics[2].face_parts[7];
					GlobalScript.inst.gameState.leader.jacket = GlobalScript.inst.gameState.politics[2].jacket;
					GlobalScript.inst.gameState.politics[2].name_1 = (byte)array5[0];
					GlobalScript.inst.gameState.politics[2].name_2 = (byte)array5[1];
					GlobalScript.inst.gameState.politics[2].traits[0] = (byte)array5[2];
					GlobalScript.inst.gameState.politics[2].traits[1] = (byte)array5[3];
					GlobalScript.inst.gameState.politics[2].traits[2] = (byte)array5[4];
					GlobalScript.inst.gameState.politics[2].age = (byte)array5[5];
					GlobalScript.inst.gameState.politics[2].face_type = (byte)array5[6];
					GlobalScript.inst.gameState.politics[2].face_parts[0] = (byte)array5[7];
					GlobalScript.inst.gameState.politics[2].face_parts[1] = (byte)array5[8];
					GlobalScript.inst.gameState.politics[2].face_parts[2] = (byte)array5[9];
					GlobalScript.inst.gameState.politics[2].face_parts[3] = (byte)array5[10];
					GlobalScript.inst.gameState.politics[2].face_parts[4] = (byte)array5[11];
					GlobalScript.inst.gameState.politics[2].face_parts[5] = (byte)array5[12];
					GlobalScript.inst.gameState.politics[2].face_parts[6] = (byte)array5[13];
					GlobalScript.inst.gameState.politics[2].face_parts[7] = (byte)array5[14];
					GlobalScript.inst.gameState.politics[2].jacket = (byte)array5[15];
					GlobalScript.inst.gameState.faction_leader[0] = 1;
					GlobalScript.inst.gameState.faction_leader[1] = 2;
					int[] array6 = new int[8];
					for (int num20 = 0; num20 < GlobalScript.inst.gameState.politics_dolshnost.Length; num20++)
					{
						if (GlobalScript.inst.gameState.politics_dolshnost[num20] == 150)
						{
							GlobalScript.inst.gameState.politics_dolshnost[num20] = 2;
						}
						else if (GlobalScript.inst.gameState.politics_dolshnost[num20] == 2)
						{
							array6[num20] = 150;
						}
					}
					for (int num21 = 0; num21 < array6.Length; num21++)
					{
						if (array6[num21] == 150)
						{
							GlobalScript.inst.gameState.politics_dolshnost[num21] = 150;
						}
					}
					for (int num22 = 0; num22 < GlobalScript.inst.gameState.politics.Length; num22++)
					{
						GlobalScript.inst.gameState.CalcRel(num22);
						GlobalScript.inst.gameState.CalcRel2(num22);
						GlobalScript.inst.gameState.CalcRelLeader(num22);
					}
					Politic politic = GlobalScript.inst.gameState.politics[1];
					politic.power += 500;
					politic = GlobalScript.inst.gameState.politics[3];
					politic.power += 500;
					politic = GlobalScript.inst.gameState.politics[4];
					politic.power += 500;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic34 in politics)
					{
						if (politic34.traits[0] == 0)
						{
							politic = politic34;
							politic.loyality += 200;
							politic = politic34;
							politic.power += 100;
						}
						else if (politic34.traits[0] == 2)
						{
							politic = politic34;
							politic.loyality -= 100;
							politic = politic34;
							politic.power -= 100;
						}
						else if (politic34.traits[0] == 1)
						{
							politic = politic34;
							politic.loyality -= 100;
						}
					}
					party_change[0] = 2.5f;
					party_change[1] = 1f;
					GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.15f);
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 27)
			{
				text2 = "香港和澳门的命运";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "经过长期谈判，你终于与英国和葡萄牙的代表签署了协议：\n香港将于1997年在新界租约期满的同时移交中华人民共和国，\n澳门则于1999年移交。\n两处旧殖民地都将获得广泛的自治权，保留对法律和经济领域的控制\n权，而中华人民共和国中央政府只处理国防和外交事务。\n当然，这会导致权力集中在地方工商精英手中，\n但这并不重要，因为我们久盼的与兄弟的团聚很快就要实现了！";
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[1] += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[65] = 1;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if ((GlobalScript.inst.gameState.data[6] <= 60 || GlobalScript.inst.gameState.influencePRC >= 150) && GlobalScript.inst.gameState.empires[0].relations >= 800)
					{
						text = "经过长期谈判，你终于与英国和葡萄牙的代表签署了协议：\n香港将于1997年在新界租约期满的同时移交中华人民共和国，\n澳门则于1999年移交。\n两处旧殖民地将获得有限的自治权，同时保留对经济以及部分法律领\n域的控制。行政权力将由地方选举机构与中共的监督机构共同分担。\n这是我们的外交胜利！";
						GlobalScript.inst.gameState.data[3] += 100;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 50;
						GlobalScript.inst.gameState.data[1] += 100;
						GlobalScript.inst.gameState.data[65] = 1;
					}
					else
					{
						text = "经过长期谈判，英国和葡萄牙放弃了我们的条件，\n称其“不可接受”，这使党和人民都大为沮丧。\n看来殖民地移交的问题将被无限期地拖延。\n至少，新界的英国方面仍准备在这种条件下于1997年归还。";
						GlobalScript.inst.gameState.data[3] -= 50;
						GlobalScript.inst.gameState.data[4] += 50;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 30;
						GlobalScript.inst.gameState.data[1] -= 100;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					if ((GlobalScript.inst.gameState.data[6] <= 50 || GlobalScript.inst.gameState.influencePRC >= 250) && GlobalScript.inst.gameState.empires[0].relations >= 800)
					{
						text = "经过长期谈判，你终于与英国和葡萄牙的代表签署了协议：\n香港将于1997年在新界租约期满的同时移交中华人民共和国，\n澳门则于1999年移交。\n两处旧殖民地将完全纳入中华人民共和国的控制，\n仅保留部分地方自治要素。\n外国国民的私有财产将继续在已设立的特别经济区框架内运作，\n而在殖民地移交之时，中国将从英国和葡萄牙“赎买”行政机构。\n人民和党都在庆祝我们这场巨大的外交胜利！";
						GlobalScript.inst.gameState.data[3] += 120;
						GlobalScript.inst.gameState.data[1] += 200;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 100;
						GlobalScript.inst.gameState.data[65] = 2;
					}
					else
					{
						text = "经过长期谈判，英国和葡萄牙放弃了我们的条件，\n称其“不可接受”，这使党和人民都大为沮丧。\n看来殖民地移交的问题将被无限期地拖延。\n至少，新界的英国方面仍准备在这种条件下于1997年归还。";
						GlobalScript.inst.gameState.data[3] -= 50;
						GlobalScript.inst.gameState.data[4] += 50;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 30;
						GlobalScript.inst.gameState.data[1] -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 28)
			{
				text2 = "亚洲皮诺切特的终结";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "由于无法应对抗议浪潮，苏哈托辞职，把权力交给副总统。\n副总统放宽了政体，举行自由选举，并启动了更独立的外交政策。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 20;
					GlobalScript.inst.gameState.allcountries[50].Vyshi = false;
					if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
					{
						GlobalScript.inst.gameState.allcountries[50].isASEAN = false;
					}
					GlobalScript.inst.gameState.allcountries[50].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[50].SubGosstroy = 6;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "Б由于无法应对抗议浪潮，苏哈托辞职。\n尽管执政精英竭尽全力，但在抗议过程中，\n在我们的支持下，一个温和的左翼政党成立，\n沿着首任总统苏加诺的道路前进，并在随后选举中获胜。\n经济重组从把社会主义治理的要素引入其中开始，\n同时还要对参与苏哈托暴政的人进行审判。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 40;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.allcountries[50].Vyshi = false;
					if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
					{
						GlobalScript.inst.gameState.allcountries[50].isASEAN = false;
					}
					GlobalScript.inst.gameState.allcountries[50].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[50].Torg = true;
					GlobalScript.inst.gameState.allcountries[50].SubGosstroy = 3;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic35 in politics)
					{
						if (politic35.traits[0] <= 2)
						{
							Politic politic = politic35;
							politic.loyality += 70;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "由于无法应对抗议浪潮，苏哈托辞职。\n多亏我们在印尼的支持，在60年代遭到几乎彻底的摧毁之后，\n印尼共产党得以重新组建，并能够在以抗议者为代价的情况下迅速补\n充队伍，还能对政府设施发动许多游击袭击。\n所有这些，再加上我们的施压，迫使印尼政府允许共产党参加选举；\n在我们积极介入之下，共产党赢得选举，\n并与民主党组成联合政府。\n印尼由此开始了一个新时代。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 40;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.allcountries[50].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[50].isASEAN = false;
					GlobalScript.inst.gameState.allcountries[50].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[50].SubGosstroy = 1;
					GlobalScript.inst.gameState.allcountries[50].Torg = true;
					GlobalScript.inst.gameState.allcountries[50].proprc = true;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic36 in politics)
					{
						if (politic36.traits[0] <= 1)
						{
							Politic politic = politic36;
							politic.loyality += 100;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 29)
			{
				text2 = "中国帝国主义";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "金日成不想面对严重的经济问题，尽管如此，\n他还是同意了我们的要求：放松党国控制，\n对过去遭受迫害者进行部分平反，并且与日本和韩国展开了有限接触。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 70;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic37 in politics)
					{
						if (politic37.traits[0] <= 1)
						{
							Politic politic = politic37;
							politic.loyality -= 50;
						}
						else
						{
							Politic politic = politic37;
							politic.loyality += 50;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[1].power)
					{
						text = "金日成原本不愿向我们让步，想以完全倒向苏联来换取他们的援助；\n但事实证明，我们的影响力更大，他又不愿与我们走向对抗，\n于是同意了我们的要求。\n朝鲜民主主义人民共和国已经展开大规模改革——放松了党国控制，\n媒体上引入了大量宣传与自由；经济改革也开始推进，\n基础是引入成本核算与自主管理。\n日本、韩国和美国对这一切都给予了积极评价，\n美国总统还指出中国在争取世界民主的斗争中作出了杰出贡献。";
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations += 100;
						empire = GlobalScript.inst.gameState.empires[1];
						empire.relations -= 100;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.power += 30;
						Politic[] politics = GlobalScript.inst.gameState.politics;
						foreach (Politic politic38 in politics)
						{
							if (politic38.traits[0] <= 1)
							{
								Politic politic = politic38;
								politic.loyality -= 100;
							}
							else
							{
								Politic politic = politic38;
								politic.loyality += 100;
							}
						}
						GlobalScript.inst.gameState.allcountries[10].Gosstroy = 2;
						GlobalScript.inst.gameState.allcountries[10].SubGosstroy = 8;
					}
					else
					{
						text = "金日成不愿屈从我们的要求，便向苏联求援。\n苏联欣然增加物资援助，并派出一小支部队进驻朝鲜民主主义人民共\n和国作为基地。此前对中国和苏联保持中立的朝鲜，\n如今已坚定地进入苏联势力范围。";
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power += 20;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 20;
						GlobalScript.inst.gameState.data[1] -= 100;
						GlobalScript.inst.gameState.allcountries[10].prosov = true;
						GlobalScript.inst.gameState.allcountries[10].proprc = false;
						GlobalScript.inst.gameState.allcountries[10].Torg = false;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "金日成不想面对严重的经济问题，尽管如此，\n他还是同意了我们的要求，并授权开设特别经济区，\n允许外国企业经营，同时中国方面也将获得优惠待遇。\n我们的企业家对此非常满意，我们也已经期待获得新的利润。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[8] += 40;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic39 in politics)
					{
						if (politic39.traits[0] >= 1)
						{
							Politic politic = politic39;
							politic.loyality += 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "金日成不愿屈从我们的要求，便向苏联求援。\n苏联欣然增加物资援助，并派出一小支部队进驻朝鲜民主主义人民共\n和国作为基地。此前对中国和苏联保持中立的朝鲜，\n如今已坚定地进入苏联势力范围。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 20;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.allcountries[10].prosov = true;
					GlobalScript.inst.gameState.allcountries[10].proprc = false;
					GlobalScript.inst.gameState.allcountries[10].Torg = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 30)
			{
				text2 = "冲突的终结？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					if (GlobalScript.inst.gameState.influencePRC >= 150)
					{
						text = "会谈之后，巴勒斯坦解放组织（PLO）\n领导人亚西尔·阿拉法特同意摒弃恐怖主义的斗争方式，\n谴责恐怖分子，并承认以色列的存在权；\n作为回应，以色列同意在约旦河西岸、加沙地带以及东耶路撒冷的大\n部分地区，逐步建立巴勒斯坦国（至于后者的问题仍在激烈争论中），\n并逐步从这些地区撤出以色列军队。\n许多激进的阿拉伯组织称这类协议为背叛，\n并决定继续斗争，直到以色列被彻底摧毁为止。\n然而，这对阿拉伯世界而言是一场重大胜利，\n意味着阿拉伯世界与以色列关系正常化的开端。";
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.relations += 100;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 50;
						GlobalScript.inst.gameState.data[85] = 2;
						GlobalScript.inst.gameState.allcountries[37].Vyshi = false;
					}
					else
					{
						text = "尽管我们竭尽全力，双方仍无法达成妥协，\n我们的提案被拒绝，谈判破裂。\n看来新一轮暴力很快就要开始了。";
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 100;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 20;
						GlobalScript.inst.gameState.data[1] -= 100;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "会谈之后，巴勒斯坦解放组织（PLO）\n领导人亚西尔·阿拉法特同意摒弃恐怖主义的斗争方式，\n谴责恐怖分子，并承认以色列的存在权；\n作为回应，以色列同意在约旦河西岸和加沙地带建立巴勒斯坦民族行\n政机构，该机构将成为巴勒斯坦自治的自我管理机构，\n直到对巴勒斯坦境内阿拉伯人的地位作出最终决定——该决定应在5\n年内做出。许多激进的阿拉伯组织称这类协议为背叛，\n并决定继续斗争，直到以色列被彻底摧毁为止。\n然而，我们希望这些协议最终能促成冲突的解决。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					GlobalScript.inst.gameState.data[85] = 1;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					if (GlobalScript.inst.gameState.influencePRC >= 200 && GlobalScript.inst.gameState.OAR)
					{
						text = "会谈之后，巴勒斯坦解放组织（PLO）\n领导人亚西尔·阿拉法特同意摒弃恐怖主义的斗争方式，\n谴责恐怖分子，并承认以色列的存在权。\n然而后续发展完全出人意料——双方同意建立巴勒斯坦与以色列的“\n<b>联邦国家</b>”，实行共同军队、双语文书，\n发展地方自治，并在外交政策上实行必然的中立。\n激进派中的一部分当然称之为背叛，但也有其他人决定停止恐怖袭击。\n当然，新国家的建立将困难重重，更多冲突仍有待解决，\n但仅仅是作出建立决定，就表明迈向久盼和平的重大一步。";
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 30;
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 50;
						empire = GlobalScript.inst.gameState.empires[1];
						empire.relations += 100;
						GlobalScript.inst.gameState.data[85] = 3;
						GlobalScript.inst.gameState.allcountries[37].Vyshi = false;
						GlobalScript.inst.gameState.allcountries[37].proprc = true;
						if (PlayerPrefs.GetInt("language") == 0)
						{
							GlobalScript.inst.gameState.allcountries[37].name = "联邦国家";
						}
						else
						{
							GlobalScript.inst.gameState.allcountries[37].name = "Союзное Гос-во";
						}
					}
					else
					{
						text = "尽管我们竭尽全力，双方仍无法达成妥协，\n我们的提案被拒绝，谈判破裂。\n看来新一轮暴力很快就要开始了。";
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 100;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 20;
						GlobalScript.inst.gameState.data[1] -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 31)
			{
				text2 = "正确的民主";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在首届自由选举中，利用反对派分裂的局面获胜者是卢泰愚——旧军\n政府的支持者。他在全斗焕人气下滑之后，\n及时与旧势力撇清关系。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.allcountries[46].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[46].SubGosstroy = 5;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏我们的帮助，金大中成功把反对力量凝聚到自己周围，\n从而在选举中获胜。韩国将迎来大规模的民主改革，\n对北方的强硬言辞也已开始松动。\n两韩关系预计将明显升温，但看来还不会走到统一。";
					GlobalScript.inst.gameState.data[9] -= 40;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 5;
					GlobalScript.inst.gameState.allcountries[46].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[46].SubGosstroy = 6;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "多亏我们的帮助，金大中成功把反对力量凝聚到自己周围，\n从而在选举中获胜。韩国将迎来大规模的民主改革，\n对北方的强硬言辞也已开始松动。\n与此同时，在我们的压力下，朝鲜也与其南方邻国以及日本展开和平\n接触，最终促成了两韩领导人在平壤举行的历史性会晤。\n在久盼的缓和之外，双方还决定把朝鲜半岛逐步统一为一个中立的邦\n联：由各方共同解决外交与国防问题，同时保持内部独立。\n而驻韩美军也将很快启航回国。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 250;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.data[9] -= 60;
					GlobalScript.inst.gameState.allcountries[46].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[46].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[46].SubGosstroy = 8;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 32)
			{
				text2 = "乌兰巴托之春？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在抗议者的压力下，蒙古人民革命党作出了一些让步，\n驱散了其中最激进的部分。\n对新闻审查以及对持不同政见者和宗教的压制大幅放松。\n尽管外交政策变得更加独立，但主要而言，\n蒙古仍然倾向于苏联。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "在抗议者的压力下，马来西亚人民党（MPR）\n作出了一些让步，驱散了其中最激进的部分。\n对新闻审查以及对持不同政见者和宗教的压制大幅放松。\n正因如此，我们得以在蒙古的媒体中开展工作，\n并在社会与政治生活中推动那些主张采取更独立的对外政策、\n尤其是建立同中国关系的人士。";
					GlobalScript.inst.gameState.data[9] -= 40;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 5;
					GlobalScript.inst.gameState.allcountries[9].prosov = false;
					GlobalScript.inst.gameState.allcountries[9].SubGosstroy = 1;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 33)
			{
				text2 = "眼中的新月";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "7月4日午夜左右，齐亚·乌尔·哈克将军命令驻拉瓦尔品第的第1\n11旅包围所有主要的联邦政府建筑、警察局以及国民议会。\n随后，他下令警方逮捕祖勒菲卡尔·布托以及巴基斯坦人民党部长们\n和其他领导人。齐亚在国家电视台向全国发表讲话时表示，\n巴基斯坦国民议会和各省议会已被解散，\n巴基斯坦宪法不再有效。\n新的政府将着手推进巴基斯坦的伊斯兰化，\n并恢复亲美的外交政策。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 30;
					GlobalScript.inst.gameState.data[4] += 30;
					GlobalScript.inst.gameState.allcountries[31].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[31].SubGosstroy = 7;
					GlobalScript.inst.gameState.allcountries[31].Vyshi = true;
					GlobalScript.inst.gameState.allcountries[31].proprc = false;
					GlobalScript.inst.gameState.allcountries[31].Torg = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏了我们的警告，布托得以躲过叛军，\n并部署忠诚部队与他们对抗。\n与此同时，摩萨德（MSS）的特种部队也赶来支援，\n协助他们击退叛军，并俘获了政变的头目。\n齐亚-乌尔-哈克将军因叛国罪被处决。\n由于我们提供的物资援助以及在镇压抗议者斗争中的帮助，\n国内局势得以恢复正常。\n布托继续推进建设伊斯兰社会主义的进程，\n逐步在经济中引入越来越多的社会主义做法。\n与此同时，中印关系也出现了轻微缓和。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[9] -= 60;
					GlobalScript.inst.gameState.data[8] -= 30;
					GlobalScript.inst.gameState.allcountries[31].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[31].SubGosstroy = 3;
					GlobalScript.inst.gameState.allcountries[31].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[31].proprc = true;
					GlobalScript.inst.gameState.party_ideology[4] -= (int)((float)GlobalScript.inst.gameState.party_ideology[4] * 0.25f);
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "7月4日午夜左右，齐亚·乌尔·哈克将军命令第111旅从拉瓦尔\n品第出发，包围所有主要的联邦政府建筑、\n警察局以及国民议会。\n随后，他下令警察逮捕祖勒菲卡尔·布托以及巴基斯坦人民党部长和\n其他领导人。齐亚在国家电视台向全国发表讲话时表示，\n巴基斯坦国民议会和各省议会已被解散，\n巴基斯坦宪法不再有效。\n新的政府将着手对巴基斯坦进行伊斯兰化，\n并恢复亲美的外交政策；这并不妨碍我们与他们保持密切且互利的关\n系。";
					GlobalScript.inst.gameState.data[4] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
					GlobalScript.inst.gameState.allcountries[31].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[31].SubGosstroy = 7;
					GlobalScript.inst.gameState.allcountries[31].Vyshi = true;
					GlobalScript.inst.gameState.allcountries[31].proprc = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 34)
			{
				text2 = "我敌人的敌人";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在中共中央政治局下一次会议上，郭芬同志批评改革派中的一些成员，\n在推进国内政治与经济变革的必要性上过于急躁，\n并且还敦促他们共同解决所有迫切问题，\n以防止党内分裂，避免重演苏联赫鲁晓夫的“主观随意性错误”。\n忠于保守立场的同志支持我们的主张“不要把不和带进党内”，\n然而，倾向自由化的一翼仍继续坚持加速经济改革；\n不过，他们在维持党内民主的必要性上仍同意向我们作出让步。\n与此同时，媒体上阅读会议记录的民众，\n对这场人们翘首以盼、似乎在“江青集团”被击败之后已经开始的变\n革却被放慢，仍然感到不满。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.5f);
					GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.15f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic40 in politics)
					{
						if (politic40.traits[0] == 2)
						{
							politic = politic40;
							politic.loyality -= 100;
						}
						else if (politic40.traits[0] == 0)
						{
							politic = politic40;
							politic.loyality += 100;
						}
					}
					politic = GlobalScript.inst.gameState.politics[7];
					politic.power -= 100;
					politic = GlobalScript.inst.gameState.politics[6];
					politic.power -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "你并不想让你本已艰难的处境进一步松动，\n因此你不敢与改革派中最有影响力的代表展开公开对抗，\n而只是着力提拔温和保守翼中忠诚的成员，\n以防止鲁莽的改革。与此同时，改革派反过来指责主席，\n企图分裂党，并计划从不代表广大人民利益的忠诚人士中另立自己的\n“江青式四人帮”。然而，这些指控并没有进一步发展。";
					GlobalScript.inst.gameState.data[1] -= 100;
					party_change[1] = 4f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic41 in politics)
					{
						if (politic41.traits[0] == 0)
						{
							politic = politic41;
							politic.loyality += 100;
						}
					}
					politic = GlobalScript.inst.gameState.politics[5];
					politic.power += 100;
					politic = GlobalScript.inst.gameState.politics[8];
					politic.power += 100;
					politic = GlobalScript.inst.gameState.politics[9];
					politic.power += 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在争取到一支相对保守的多数支持之后，\n你在中共中央党校（中央委员会）下一次代表大会上批评了改革派的\n主张，并凭借你在公安部的影响力，开始有力地干预各类不那么显赫\n的改革派人士的仕途，同时在中间偏保守派中提拔起你自己的人。\n那些受你批评波及的人当然不满，党内的改革派阵营也同样不满。\n但你的地位却得到了显著加强。";
					GlobalScript.inst.gameState.data[1] -= 150;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[6] += 20;
					party_change[1] = 4f;
					GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.1f);
					GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.15f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					Politic politic;
					foreach (Politic politic42 in politics)
					{
						if (politic42.traits[0] == 2)
						{
							politic = politic42;
							politic.loyality -= 200;
						}
						else if (politic42.traits[0] == 0)
						{
							politic = politic42;
							politic.loyality += 150;
						}
					}
					politic = GlobalScript.inst.gameState.politics[6];
					politic.power -= 150;
					politic = GlobalScript.inst.gameState.politics[7];
					politic.power -= 150;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "在下一次政治局会议上，同志郭峰表示，\n有必要继续执行既定的社会经济变革方针，\n并且还设法与李先念、叶剑英就联合努力、\n建立某种温和改革派联盟达成了协商。\n利用他们所拥有的行动自由，改革派已经在党内积极推举自己的人选，\n并以适当的观点加以推动，例如邓小平、\n赵紫阳。人民在察觉到改革运动之后，期待它们朝着更好的方向改变；\n然而，党内保守派对这种局面并不满意。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[4] += 80;
					GlobalScript.inst.gameState.data[6] -= 20;
					party_change[3] = 5f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic43 in politics)
					{
						if (politic43.traits[0] == 2)
						{
							Politic politic = politic43;
							politic.loyality += 200;
							politic = politic43;
							politic.power += 120;
						}
						else if (politic43.traits[0] == 3)
						{
							Politic politic = politic43;
							politic.power += 70;
						}
						else if (politic43.traits[0] == 0)
						{
							Politic politic = politic43;
							politic.loyality -= 200;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "在政治局以及中共其他各部门中，改革—自由派的情绪正在迅速增长，\n这令那些旧保守派极为愤怒：他们担心自己会失去职位和昔日的影\n响力，也担心中国会滑向修正主义。\n权力仍在你手中，但还能维持多久？";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[4] += 30;
					party_change[3] = 2f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic44 in politics)
					{
						if (politic44.traits[0] >= 2)
						{
							Politic politic = politic44;
							politic.power += 70;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 35)
			{
				text2 = "革命的终结";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "尽管文化大革命已经彻底结束，似乎并没有进一步走向自由化的动向。\n民众和改革派都感到失望。";
					GlobalScript.inst.gameState.data[4] += 40;
					GlobalScript.inst.gameState.data[3] -= 60;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic45 in politics)
					{
						if (politic45.traits[0] >= 1)
						{
							Politic politic = politic45;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "作为继续纠正“文化大革命”过激现象的一部分，\n中国的高压控制逐步被略微放松。\n人民和改革派对此感到满意，但如果会发生什么意外……";
					GlobalScript.inst.gameState.data[3] += 60;
					GlobalScript.inst.gameState.data[4] += 20;
					GlobalScript.inst.gameState.data[57] -= 30;
					if (GlobalScript.inst.gameState.data[17] < 17)
					{
						GlobalScript.inst.gameState.data[17] = 17;
					}
					GlobalScript.inst.gameState.data[6] -= 20;
					party_change[3] = 1.5f;
					party_change[2] = 2f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic46 in politics)
					{
						if (politic46.traits[0] >= 1)
						{
							Politic politic = politic46;
							politic.loyality += 50;
							politic = politic46;
							politic.power += 30;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "作为继续纠正“文化大革命”过激现象的一部分，\n中国的高压控制被逐步略微放松，同时针对传统主义的积极斗争也被\n停止了，这意味着对宗教的压力有所减轻，\n但仍然存在。尽管如此，国家无神论并没有消失。\n尽管有一些地下的反国家布道活动来自牧师，\n但总体而言，人们是满意的。\n希望这不会引发问题。";
					GlobalScript.inst.gameState.data[3] += 70;
					GlobalScript.inst.gameState.data[4] += 40;
					GlobalScript.inst.gameState.data[6] -= 30;
					if (GlobalScript.inst.gameState.data[17] < 17)
					{
						GlobalScript.inst.gameState.data[17] = 17;
					}
					if (GlobalScript.inst.gameState.data[50] < 25)
					{
						GlobalScript.inst.gameState.data[50] = 25;
					}
					party_change[3] = 1.5f;
					party_change[2] = 2f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic47 in politics)
					{
						if (politic47.traits[0] >= 1)
						{
							Politic politic = politic47;
							politic.loyality += 80;
							politic = politic47;
							politic.power += 30;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "作为继续纠正“文化大革命”过激行为的一部分，\n中国逐步略微放松了镇压性的控制；同时，\n针对传统主义的积极斗争也被停止，并在维持国家在无神论方向上的\n方针以及对宗教机构的控制的前提下，批准了良心自由。\n尽管有些来自教士的反国家布道——往往很快就被压制——但总体而\n言，民众是满意的。我们希望这不会引发中华人民共和国各族人民之\n间的问题与冲突。";
					GlobalScript.inst.gameState.data[3] += 90;
					GlobalScript.inst.gameState.data[4] += 60;
					GlobalScript.inst.gameState.data[6] -= 40;
					if (GlobalScript.inst.gameState.data[17] < 17)
					{
						GlobalScript.inst.gameState.data[17] = 17;
					}
					if (GlobalScript.inst.gameState.data[50] < 26)
					{
						GlobalScript.inst.gameState.data[50] = 26;
					}
					party_change[3] = 1.5f;
					party_change[2] = 2f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic48 in politics)
					{
						if (politic48.traits[0] >= 1)
						{
							Politic politic = politic48;
							politic.loyality += 80;
							politic = politic48;
							politic.power += 50;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 36)
			{
				text2 = "联盟崩溃？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在遭受了一段时间的折磨，并且多次尝试与复兴党领导层建立关系却\n始终未果之后，伊拉克共产党最终决定决裂。\n1979年4月，共产党部长退出政府；\n共产党停止参与全国阵线。\n1979年5月，伊拉克共产党领导层决定退出PNPF，\n转入非法状态。";
					GlobalScript.inst.gameState.allcountries[14].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们本来预料到的谴责，果然只会导致同伊拉克关系的进一步恶化，\n并对共产党人实施更严厉的镇压。\n由于长期遭受打击却始终未能同复兴党领导层建立关系，\n伊共最终决定决裂。1979年4月，共产党部长从政府中撤出；\n共产党停止参加“民族阵线”。\n1979年5月，伊共领导层决定退出PNPF，\n转入非法状态。";
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.allcountries[14].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 10;
					GlobalScript.inst.gameState.allcountries[14].Torg = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "我们对双方施加的非正式政治压力，得到了情报机构收集到的妥协性\n信息的支撑，以及针对复兴党的小规模抗议，\n终于结出了果实。复兴党人停止了镇压，\n并宣布他们与伊斯兰共产党（ICP）之间的坚定同盟；\n而ICP也确认了自己加入人民民族阵线（PNPF），\n拒绝煽动反政府行动，并拒绝要求废除紧急状态。\n很显然，这些漂亮话背后只有一场隐藏的较量，\n以及同盟关系那摇摇欲坠的相似性；但在一段时间内，\n这样的联合仍将维持下去。";
					GlobalScript.inst.gameState.data[1] += 70;
					GlobalScript.inst.gameState.data[4] -= 30;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.ICP = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 37)
			{
				text2 = "埃及帕夏的终结";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们决定积极介入局势并支持动乱。\n通过秘密渠道，许多武器落入示威者手中，\n他们立刻将这些武器用于对警察的攻击。\n在开罗以及其他一些城市，真正的街头巷战爆发，\n双方都造成了大量人员伤亡。\n萨达特试图争取美国和以色列的支持，但这反而使他与ASU的三个\n派系以及军队指挥部彻底对立——他们从未忘记1973年的失败。\n萨达特在遭到刺杀企图后逃往开罗的美国大使馆，\n并寻求政治庇护。在示威者与军队指挥部之间进行谈判后，\n决定将权力移交给由前副总统阿里·萨布里领导的民族团结政府。\n萨布里开始扭转资本主义改革，恢复ASU的统一，\n切断与美国和以色列的一切联系，并已开始与苏联、\n中国、利比亚、叙利亚、伊拉克以及其他社会主义国家恢复外交关系\n的谈判。新总统还宣布埃及愿意参与泛阿拉伯与泛非洲的整合项目，\n这为我们组建一个由阿拉伯国家组成的广泛邦联、\n以对抗美国及其在中东的傀儡，打开了颇具吸引力的前景。";
					GlobalScript.inst.gameState.data[1] += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 150;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 80;
					GlobalScript.inst.gameState.data[9] -= 60;
					GlobalScript.inst.gameState.data[8] -= 40;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					GlobalScript.inst.gameState.allcountries[30].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[30].SubGosstroy = 15;
					GlobalScript.inst.gameState.allcountries[30].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[30].Torg = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.allcountries[13].Torg || GlobalScript.inst.gameState.allcountries[30].stab == 1)
					{
						text = "我们不敢直接干预，于是转而从利比亚和叙利亚下手，\n由他们各自去处理萨达特的问题。\n利比亚“人民群众国”的秘密组织与叙利亚军事情报机构，\n在我方国家安全部（MSS）的协助下，\n并在苏联克格勃的秘密批准之下，已经联手制定了一项消除埃及总统\n的计划。10月25日，安瓦尔·萨达特在开罗塔里尔广场向埃及抗\n议者讲话时，被一名利比亚狙击手击毙。\n借助仍存的纳赛尔主义支持者的支持，被赦免的阿里·萨布里成为埃\n及新总统，但已故霍斯尼·穆巴拉克的同僚则出任他的总理。\n阿联拒绝深化改革，关闭其中最激进的部分，\n并逐步与阿拉伯国家恢复正常关系。\n萨布里已经重新与苏联就恢复军事技术合作展开谈判，\n因此该国的路线再次向左转——但并不是朝我们的方向……";
						GlobalScript.inst.gameState.data[1] += 20;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power += 20;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						empire = GlobalScript.inst.gameState.empires[1];
						empire.relations += 50;
						GlobalScript.inst.gameState.data[9] -= 20;
						GlobalScript.inst.gameState.data[8] -= 20;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.power -= 20;
						GlobalScript.inst.gameState.allcountries[30].Gosstroy = 2;
						GlobalScript.inst.gameState.allcountries[30].SubGosstroy = 3;
						GlobalScript.inst.gameState.allcountries[30].prosov = true;
						GlobalScript.inst.gameState.allcountries[30].Vyshi = false;
					}
					else
					{
						text = "由于不敢直接干预，我们转而从另一条路入手，\n通过利比亚和叙利亚来行动，让它们各自对萨达特采取行动。\n利比亚“人民群众国”的秘密组织与叙利亚军事情报机构，\n在我方MSS的协助下，并在苏联克格勃的秘密批准下，\n联手制定了一项消灭埃及总统的计划。\n10月25日，安瓦尔·萨达特在开罗解放广场向埃及抗议者讲话时，\n被一名利比亚狙击手击毙。\n埃及新总统是他的同僚胡斯尼·穆巴拉克，\n他放弃了正在加深的改革进程，转而推行多方向的外交政策，\n尽管在措辞上仍保留反苏的基调。\n埃及与其阿拉伯邻国之间的关系逐步走向正常化。";
						GlobalScript.inst.gameState.data[9] -= 20;
						GlobalScript.inst.gameState.data[8] -= 20;
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.power -= 10;
						GlobalScript.inst.gameState.allcountries[30].Vyshi = false;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "安瓦尔·萨达特向抗议者作出了多项让步，\n承诺向贫困者增加对CPG的补贴，并开始重新武装埃及军队、\n使其训练达到北约标准，以便“没有人能够利用我们的弱点”。\n这使他得以稳定国内局势。\n据预计，萨达特将访问以色列，并最终恢复与以色列的关系……";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 38)
			{
				text2 = "回归根源";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "中国的经济持续稳步增长，但它要多久才能见效？拭目以待。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "在中共中央政治局下一次会议上，决定恢复苏联式的计划体制——在\n60年代曾被强行否定。\n成立了计划委员会，该委员会应尽快制定国家经济发展的五年战略。\n当然，改革派对撤回周的改革不满，民众对恢复旧体制也产生了疑虑；\n同时还必须拨出用于改造与建立官僚体系的资金。";
					GlobalScript.inst.gameState.data[8] -= 10;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[3] -= 40;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 70;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.data[16] = 10;
					party_change[0] = 2.5f;
					party_change[1] = 2.5f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic49 in politics)
					{
						if (politic49.traits[0] == 0)
						{
							Politic politic = politic49;
							politic.loyality += 100;
						}
						else if (politic49.traits[0] == 1)
						{
							Politic politic = politic49;
							politic.loyality -= 30;
						}
						else if (politic49.traits[0] == 2)
						{
							Politic politic = politic49;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "根据此前所宣告的改变社会经济生活的方针，\n你与最杰出的改革人物一道，成立了一个特别委员会，\n并开始制定未来经济改革的方案，以继续周恩来的工作。\n党（准确说是党内的右翼与温和派）正期待委员会的决定，\n而迄今仅有零星传闻传到的那部分民众，\n则在等待向好的变化。";
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.data[4] += 20;
					GlobalScript.inst.gameState.data[3] += 30;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 70;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 80;
					party_change[2] = 4.5f;
					party_change[3] = 4.5f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic50 in politics)
					{
						if (politic50.traits[0] == 2)
						{
							Politic politic = politic50;
							politic.loyality += 150;
							politic = politic50;
							politic.power += 100;
						}
						else if (politic50.traits[0] == 1)
						{
							Politic politic = politic50;
							politic.loyality += 70;
							politic = politic50;
							politic.power += 50;
						}
						else if (politic50.traits[0] == 0)
						{
							Politic politic = politic50;
							politic.loyality -= 170;
							politic = politic50;
							politic.power -= 100;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 39)
			{
				text2 = "“决议……”委员会";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "决定亲自担任起草《中华人民共和国成立以来我党历史若干问题的决\n议》的委员会负责人，并任命“文化大革命”的主要思想家之一" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[0]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[0]].name_2] + "作为他的副手。委员会的评估重点放在“伟大争论”以来毛泽东的工\n作。对毛本人性格的评价是正面的，但也提到了右倾与左倾两方面的\n过火行为，不过这些在他的活动中并不具有根本性。\n该文件开始呈现出另一种“文化大革命”时期的毛主义小册子的样式，\n尽管它对其进行了批评……";
					GlobalScript.inst.gameState.data[1] += 80;
					GlobalScript.inst.gameState.data[3] += 20;
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.data[90] = 0;
					party_change[0] = 1.5f;
					party_change[1] = 1.5f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic51 in politics)
					{
						if (politic51.traits[0] == 0)
						{
							Politic politic = politic51;
							politic.loyality += 100;
							politic = politic51;
							politic.power += 30;
						}
						else if (politic51.traits[0] == 1)
						{
							Politic politic = politic51;
							politic.loyality += 60;
							politic = politic51;
							politic.power += 20;
						}
						else if (politic51.traits[0] == 2)
						{
							Politic politic = politic51;
							politic.loyality += 50;
						}
						else if (politic51.traits[0] == 3)
						{
							Politic politic = politic51;
							politic.loyality -= 100;
							politic = politic51;
							politic.power -= 30;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "根据政治局的决定，委员会由老牌改革思想家邓小平担任负责人。\n他任命同僚胡耀邦为副手。\n尽管两人都遭受过“文化大革命”的打击，\n但他们仍设法超越对毛泽东的怨恨，对他的那段时期作出了相对公允\n的评价。毛泽东本人也得到了同样的评价：\n在他关于《无产阶级专政的历史经验》《关于无产阶级专政的历史经\n验的再探讨》以及《论斯大林问题》等文章中，\n他对斯大林的判断是——“功过斯大林七三开”，\n而所有主要的失败（如“大跃进”）则被归咎于晚年的林彪和康生，\n正是他们给了毛主席“错误的建议”。\n邓小平还就这份文本向编辑们作了九次修改意见（“不好”“需要加\n工”“太冗长”“太悲伤”等）。\n也许，我们的选择完全猜中了，而《中华人民共和国成立以来我党历\n史若干问题的决议》将会保持平衡，并能作为为了光明未来而重新思\n考我们过去的第一步……";
					GlobalScript.inst.gameState.data[1] += 100;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[6] -= 30;
					GlobalScript.inst.gameState.data[90] = 1;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 20;
					party_change[0] = 1.5f;
					party_change[1] = 1.5f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic52 in politics)
					{
						if (politic52.traits[0] == 0)
						{
							Politic politic = politic52;
							politic.loyality += 50;
							politic = politic52;
							politic.power += 10;
						}
						else if (politic52.traits[0] == 1)
						{
							Politic politic = politic52;
							politic.loyality += 100;
							politic = politic52;
							politic.power += 40;
						}
						else if (politic52.traits[0] == 3)
						{
							Politic politic = politic52;
							politic.loyality += 60;
						}
						else if (politic52.traits[0] == 2)
						{
							Politic politic = politic52;
							politic.loyality += 80;
							politic = politic52;
							politic.power += 30;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "华国锋尽管遭到中共内右翼与左翼两方面的反对，\n仍任命持自由主义观点、已被打入冷宫的彭真为委员会负责人。\n他任命赵紫阳为副手，而赵紫阳的观点与他也并不太不同。\n两人都在“文化大革命”期间遭受了严重影响，\n如今也并不太掩饰想要为自己的遭遇讨回公道的愿望。\n由他们编写的这份文件，将中国历史中的社会主义时期评为：\n“毛泽东的封建法西斯式独裁时期——他制造大规模恐怖，\n摧毁像刘少奇、彭德怀这样的正直共产党员，\n并通过在中华人民共和国建立个人崇拜而使党完全屈从于他的意志。\n”文件还主张“回到源头，回到马克思、\n列宁、陈独秀和王明，摒弃反马克思的毛泽东个人崇拜，\n并为建设中国光明的社会主义未来而对他们的极权主义过去加以定性\n”。我认为，这份对1956年赫鲁晓夫“秘密报告”的中国式抄本，\n恐怕不会让普通党员和民众都买账……";
					if (GlobalScript.inst.gameState.data[104] == 10)
					{
						text += "|文件通过后的当晚，毛被从陵墓中移走；\n次日，陵墓建筑被拆毁。\n陵墓旧址将兴建陈独秀纪念馆——中共中央局第一书记，\n曾被指控优柔寡断，后来又站到了托洛茨基主义反对派一边。";
						if (GlobalScript.inst.gameState.iron_and_blood)
						{
							achieves.GetComponent<achievements>().Set(9);
						}
						GlobalScript.inst.gameState.data[104] = 9;
					}
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[6] -= 60;
					GlobalScript.inst.gameState.data[90] = 2;
					party_change[3] = 1.5f;
					party_change[4] = 1f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic53 in politics)
					{
						if (politic53.traits[0] == 0)
						{
							Politic politic = politic53;
							politic.loyality -= 150;
						}
						else if (politic53.traits[0] == 1)
						{
							Politic politic = politic53;
							politic.loyality -= 100;
						}
						else if (politic53.traits[0] == 2)
						{
							Politic politic = politic53;
							politic.loyality += 50;
						}
						else if (politic53.traits[0] == 3)
						{
							Politic politic = politic53;
							politic.loyality += 150;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 40)
			{
				text2 = "班禅喇嘛的命运";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "这封信离开你时附带了如下决议：“第十世班禅喇嘛在藏族和中国人\n民面前的功绩是巨大的，但他对西藏与中国国际友谊所造成的打击更\n为巨大。他的释放时机不当且危险。\n”1979年3月，中国异议人士魏京生发表了一封信，\n谴责班禅喇嘛在金城监狱的囚禁条件；之后他被转送到拉萨，\n并将防范措施改为居家监禁。\n然而，第十世班禅喇嘛直到1989年1月28日去世，\n也从未获得自由……";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[6] += 5;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.data[50] <= 25)
					{
						text = "却吉坚赞断然拒绝履行这一条件，理由是我国对藏传佛教僧侣的态度\n极其压迫。好吧，这是他的选择——让他在金城待到尘世生命的尽头……";
						GlobalScript.inst.gameState.data[1] += 50;
						GlobalScript.inst.gameState.data[3] -= 60;
						GlobalScript.inst.gameState.data[6] += 10;
						GlobalScript.inst.gameState.data[57] -= 50;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 10;
					}
					else
					{
						text = "却吉坚赞同意了这一条件，并请求调到同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "……总体上，他赞同我国关于藏传佛教僧俗的政策，\n并保证不再参与宗教活动。\n获释后，他赴中国，结婚嫁给军人李杰；\n1982年他被彻底平反，并获准返回拉萨。\n他甚至还当选为西藏自治区全国人大代表。";
						GlobalScript.inst.gameState.data[3] += 60;
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations += 50;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						GlobalScript.inst.gameState.data[57] += 40;
						GlobalScript.inst.gameState.data[6] -= 20;
						GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 33;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "这封信随你们的决议一并送出：“第十世班禅喇嘛在羁押中已足够时\n间，足以反思其行为与过失。\n我同意尽快释放他并允许其返回西藏，但须置于观察之下。\n”回到拉萨后，确吉坚赞将1959年塔尔寺（塔什伦布寺）\n遭毁时被毁坏的前任班禅喇嘛遗骨重新安葬；\n但总体上他表现得很安分，也没有去接触逃亡的第十四世达赖喇嘛或\n其支持者。因此，1983年对他的观察被拍成了片。\n班禅喇嘛获赦，受到人民、西方以及藏人流亡群体的普遍欢迎。";
					GlobalScript.inst.gameState.data[3] += 80;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[57] += 40;
					GlobalScript.inst.gameState.data[9] -= 40;
					GlobalScript.inst.gameState.data[6] -= 20;
					GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 33;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					if (GlobalScript.inst.gameState.data[50] >= 26 && GlobalScript.inst.gameState.data[3] >= 700)
					{
						text = "回到拉萨后，第十世班禅喇嘛正式宣布：\n他对中国当局没有任何怨言；他所受的惩罚是公平且极其重要的一课，\n使他更接近觉悟。他承担起1959年塔什伦布寺遭毁时被毁坏的\n前任班禅喇嘛遗骨的重新安葬工作，积极参加慈善活动；\n并在苏联领导层同意下访问了卡尔梅克、\n布里亚特和图瓦等自治苏维埃社会主义共和国，\n帮助建立西藏自治区与这些自治共和国之间的文化联系。\n人民与国际社会都感到满意。";
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						GlobalScript.inst.gameState.data[3] += 120;
						GlobalScript.inst.gameState.data[6] -= 20;
						GlobalScript.inst.gameState.data[57] += 40;
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations += 120;
						empire = GlobalScript.inst.gameState.empires[1];
						empire.relations += 50;
						GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 33;
					}
					else
					{
						text = "第十世班禅喇嘛从未原谅他所遭受的那一切。\n回到拉萨的当即，他就开始发表煽动性言论（例如：\n“当然，获释带来了发展，但为这发展付出的代价大于收益”），\n并着手与达赖喇嘛的支持者建立联系，\n向世界共同体发出信息，批评中国以及尤其是西藏自治区的局势。\n最后，当最高人民法院作出逮捕班禅喇嘛的裁决时，\n他逃往不丹；随后又转到印度，成为所谓“藏人流亡政府”的一员。\n印度领导层拒绝把他交给我们，因此藏族分裂势力阵营如今又补充了\n一位极其重要的人物。\n这显然对我们不利……";
						GlobalScript.inst.gameState.data[3] -= 100;
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 100;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 20;
						GlobalScript.inst.gameState.data[57] -= 100;
						GlobalScript.inst.gameState.data[6] += 20;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "1977年10月28日，金城监狱的看守发现班禅喇嘛X倒在牢房\n地上，已无生命迹象。\n同日早晨，借口注射“补品”，实则给他注射了一种特殊毒药，\n引发心肌梗死。尽管《西藏日报》（西藏人民代表大会机关报）\n刊登了官方通告，称死因是心脏病发作，\n但相信的人并不多。自治区方面早已公开说：\n“班禅喇嘛因不同意中国吞并西藏而被中共中央情报部门（MSS）\n杀害”……由我们批准任命的寻找新班禅喇嘛委员会负责人，\n暗中与逃亡的达赖喇嘛保持联系，而达赖喇嘛并未躲过中共中央情报\n部门的注意。仁波切被捕，随后由桑臣·罗桑坚赞顶替；\n他是达赖喇嘛与已故班禅喇嘛的共同政治对手。\n他达成了我们所需要的结果——11月11日宣布了新的第十一世班\n禅喇嘛。诺布说：“佛教向国家和社会作出庄严誓言：\n保卫国家、为人民的利益而工作。\n中国社会是佛教信仰的有利环境。\n”他还称赞前任对“加强国家统一、增进人民团结所作出的杰出贡献\n”。然而，第十四世达赖喇嘛及其所谓“藏人流亡政府”却宣称新任\n第十一世班禅喇嘛只是“藏地的一名小孩”。\n我们只好把他送进国家孤儿院……\n藏传僧侣破坏新班禅喇嘛的活动，并支持达赖喇嘛的任命者；\n分裂情绪在他们中间蔓延……";
					GlobalScript.inst.gameState.data[1] += 100;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.data[57] -= 30;
					GlobalScript.inst.gameState.data[9] -= 70;
					GlobalScript.inst.gameState.data[8] -= 40;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.data[3] -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 41)
			{
				text2 = "印度选举";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "由于甘地与印度国民大会党（INC）的声望下跌，\n再加上在民众眼中反对紧急状态的斗争使他们与印度反抗英国殖民统\n治的自由斗士“同气相连”，人民党（Janata）\n得以绕开INC。莫拉尔吉·德赛成为新任总理。\n他组建的政府恢复了同中华人民共和国的外交关系，\n改善了同巴基斯坦的关系，并在世界舞台上为印度的核政策辩护。\n成立了一个法庭调查紧急状态期间的滥权行为，\n但却未能把甘地送上法庭追究责任。\n然而，在新的执政党内部，关于国家未来发展方向，\n其成员之间已经出现了积极的分裂。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[91] = 2;
					GlobalScript.inst.gameState.allcountries[19].Torg = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "由于甘地与INC的声望下跌，再加上我们积极的支持，\n以及在民众眼中反对紧急状态的斗争使他们与印度反抗英国殖民统治\n的自由斗士“同气相连”，人民党（Janata）\n得以绕开INC。莫拉尔吉·德赛成为新任总理。\n他组建的政府恢复了同中华人民共和国的外交关系，\n改善了同巴基斯坦的关系，并在世界舞台上为印度的核政策辩护。\n成立了一个法庭调查紧急状态期间的滥权行为，\n但却未能把甘地送上法庭追究责任。\n然而，在新的执政党内部，关于国家未来发展方向，\n其成员之间已经出现了积极的分裂。\n我们希望同人民党保持良好关系，能让我们把它从崩溃边缘挽救回来。";
					GlobalScript.inst.gameState.data[1] += 70;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[91] = 1;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 70;
					GlobalScript.inst.gameState.data[8] -= 30;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.allcountries[19].Torg = true;
					GlobalScript.inst.gameState.allcountries[19].prosov = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "尽管过去曾与我们有过分歧，甘地仍心怀感激地接受了我们的帮助—\n—正是因为这份帮助，INC才得以绕开反对派并赢得胜利。\n英迪拉·甘地继续担任总理；尽管我们之间仍有明显紧张，\n且领土争端尚未解决，但印度与中国的外交关系已得以恢复。\n希望INC能够继续进一步缓和，而苏联不会阻挠。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[91] = 3;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 20;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 30;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 42)
			{
				text2 = "伊朗革命";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "伊朗的抗议与罢工在没有我们参与的情况下仍在继续。";
					GlobalScript.inst.gameState.iranrev = true;
					GlobalScript.inst.gameState.allcountries[8].dev = 4;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们得以同伊朗的图德党以及其他较小的共产党、\n毛主义和左翼民族主义组织建立联系，并就由我们方面提供支持达成\n一致。第一步已经迈出，但我们不能忘记要定期向他们再提供新的帮\n助。";
					GlobalScript.inst.gameState.data[42] += 70;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.iranrev = true;
					GlobalScript.inst.gameState.allcountries[8].dev = 1;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "我们得以同伊朗的伊斯兰运动建立联系，\n甚至在巴黎还与霍梅尼本人取得了接触。\n话虽如此，他们未必对这样的“靠山”感到高兴，\n但显然他们认为我们比苏联、美国和国王（沙阿）\n更“次要的恶”。第一步已经迈出，但我们不能忘记要定期向他们再\n提供新的帮助。";
					GlobalScript.inst.gameState.iranrev = true;
					GlobalScript.inst.gameState.data[45] += 70;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.allcountries[8].dev = 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "我们得以同统治王朝巴列维以及沙阿穆罕默德·礼萨·巴列维建立联\n系；他们欣然接受我们在打击反对派斗争中的帮助。\n我们的特工目前正与伊朗秘密警察萨瓦克（SAVAK）\n一道，致力于揭露反对派网络并抓捕其成员。\n第一步已经迈出，但我们不能忘记要定期向沙阿再提供新的帮助。";
					GlobalScript.inst.gameState.iranrev = true;
					GlobalScript.inst.gameState.data[43] += 70;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.allcountries[8].dev = 0;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "我们成功同民族阵线以及其他民主组织（包括伊斯兰民主派）\n建立了联系，并与他们达成协议：由我们提供援助。\n第一步已经迈出，但我们不能忘记要定期向他们再提供新的帮助。";
					GlobalScript.inst.gameState.iranrev = true;
					GlobalScript.inst.gameState.data[44] += 70;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[6] -= 20;
					GlobalScript.inst.gameState.allcountries[8].dev = 2;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 43)
			{
				text2 = "经互会扩展";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "1978年11月，越南加入经互会（CMEA），\n导致我们之间关系进一步恶化。\n中共内部反越情绪正在积极酝酿成熟。\n希望这不会引发大规模冲突。";
					GlobalScript.inst.gameState.data[1] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 30;
					GlobalScript.inst.gameState.allcountries[11].isSEV = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们的介入以及动员越南内部主张更温和路线的支持者，\n最终迫使黎笋与越南共产党（CPV）领导层将原定加入经互会的计\n划无限期推迟，并转而奉行更平衡的外交政策。\n当然，苏联并不高兴，但至少在一段时间内，\n它帮助我们避免越南与苏联进一步靠拢。";
					GlobalScript.inst.gameState.data[1] += 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 70;
					GlobalScript.inst.gameState.data[9] -= 30;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 44)
			{
				text2 = "不管黑猫白猫，抓到老鼠就是好猫……";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在中共中央委员会当前全体会议上，几乎全票赞成（少数保守派几乎\n没有什么权力），宣布启动市场改革，并通过所谓“改革开放”政策，\n意味着中国将进入世界市场，并按市场原则重组经济。\n尽管名义上国家仍由 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "，实际上现在几乎所有权力都掌握在 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2] + "手中——他已准备好带领国家走向光明的市场未来。";
					GlobalScript.inst.gameState.data[1] += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[89] = 1;
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[3] += 60;
					GlobalScript.inst.gameState.data[6] -= 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					int[] array7 = new int[16]
					{
						GlobalScript.inst.gameState.leader.name_1,
						GlobalScript.inst.gameState.leader.name_2,
						GlobalScript.inst.gameState.leader.traits[0],
						GlobalScript.inst.gameState.leader.traits[1],
						GlobalScript.inst.gameState.leader.traits[2],
						GlobalScript.inst.gameState.leader.age,
						GlobalScript.inst.gameState.leader.face_type,
						GlobalScript.inst.gameState.leader.face_parts[0],
						GlobalScript.inst.gameState.leader.face_parts[1],
						GlobalScript.inst.gameState.leader.face_parts[2],
						GlobalScript.inst.gameState.leader.face_parts[3],
						GlobalScript.inst.gameState.leader.face_parts[4],
						GlobalScript.inst.gameState.leader.face_parts[5],
						GlobalScript.inst.gameState.leader.face_parts[6],
						GlobalScript.inst.gameState.leader.face_parts[7],
						GlobalScript.inst.gameState.leader.jacket
					};
					GlobalScript.inst.gameState.leader.name_1 = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1;
					GlobalScript.inst.gameState.leader.name_2 = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2;
					GlobalScript.inst.gameState.leader.traits[0] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[0];
					GlobalScript.inst.gameState.leader.traits[1] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[1];
					GlobalScript.inst.gameState.leader.traits[2] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[2];
					GlobalScript.inst.gameState.leader.age = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].age;
					GlobalScript.inst.gameState.leader.face_type = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_type;
					GlobalScript.inst.gameState.leader.face_parts[0] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[0];
					GlobalScript.inst.gameState.leader.face_parts[1] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[1];
					GlobalScript.inst.gameState.leader.face_parts[2] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[2];
					GlobalScript.inst.gameState.leader.face_parts[3] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[3];
					GlobalScript.inst.gameState.leader.face_parts[4] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[4];
					GlobalScript.inst.gameState.leader.face_parts[5] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[5];
					GlobalScript.inst.gameState.leader.face_parts[6] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[6];
					GlobalScript.inst.gameState.leader.face_parts[7] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[7];
					GlobalScript.inst.gameState.leader.jacket = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].jacket;
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1 = (byte)array7[0];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2 = (byte)array7[1];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[0] = (byte)array7[2];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[1] = (byte)array7[3];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[2] = (byte)array7[4];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].age = (byte)array7[5];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_type = (byte)array7[6];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[0] = (byte)array7[7];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[1] = (byte)array7[8];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[2] = (byte)array7[9];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[3] = (byte)array7[10];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[4] = (byte)array7[11];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[5] = (byte)array7[12];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[6] = (byte)array7[13];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[7] = (byte)array7[14];
					GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].jacket = (byte)array7[15];
					GlobalScript.inst.gameState.faction_leader[3] = 200;
					int[] array8 = new int[8];
					for (int num23 = 0; num23 < GlobalScript.inst.gameState.politics_dolshnost.Length; num23++)
					{
						if (GlobalScript.inst.gameState.politics_dolshnost[num23] == 150)
						{
							GlobalScript.inst.gameState.politics_dolshnost[num23] = (byte)GlobalScript.inst.gameState.faction_leader[3];
						}
						else if (GlobalScript.inst.gameState.politics_dolshnost[num23] == (byte)GlobalScript.inst.gameState.faction_leader[3])
						{
							array8[num23] = 150;
						}
					}
					for (int num24 = 0; num24 < array8.Length; num24++)
					{
						if (array8[num24] == 150)
						{
							GlobalScript.inst.gameState.politics_dolshnost[num24] = 150;
						}
					}
					for (int num25 = 0; num25 < GlobalScript.inst.gameState.politics.Length; num25++)
					{
						GlobalScript.inst.gameState.CalcRel(num25);
						GlobalScript.inst.gameState.CalcRel2(num25);
						GlobalScript.inst.gameState.CalcRelLeader(num25);
					}
					party_change[2] = 3f;
					party_change[3] = 4f;
					party_change[4] = 2.5f;
					GlobalScript.inst.gameState.party_ideology[0] -= (int)((float)GlobalScript.inst.gameState.party_ideology[0] * 0.15f);
					GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.15f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic54 in politics)
					{
						if (politic54.traits[0] == 0)
						{
							Politic politic = politic54;
							politic.power -= 200;
						}
						else if (politic54.traits[0] == 1)
						{
							Politic politic = politic54;
							politic.power += 100;
						}
						else if (politic54.traits[0] == 2)
						{
							Politic politic = politic54;
							politic.power += 200;
						}
						else if (politic54.traits[0] == 3)
						{
							Politic politic = politic54;
							politic.power += 80;
						}
					}
					if (GlobalScript.inst.gameState.modifies[59].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = true;
						GlobalScript.inst.gameState.modifies[62].active = false;
					}
					else if (GlobalScript.inst.gameState.modifies[60].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = true;
						GlobalScript.inst.gameState.modifies[62].active = false;
					}
					else if (GlobalScript.inst.gameState.modifies[61].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = false;
						GlobalScript.inst.gameState.modifies[62].active = true;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "就在你以花言巧语拖延会议之际，中共中央情报部门（MSS）\n的人员赶到大楼，逮捕了大多数改革派。\n随后，一股以追捕改革派为目标的逮捕浪潮、\n宣传攻势与人事更替席卷全国。" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2] + "他本人如今也被拘押了，但你仍凭借坚持自己的政策而保住了权力，\n尽管这在党内和人民中引起了广泛不满。";
					GlobalScript.inst.gameState.data[1] -= 150;
					GlobalScript.inst.gameState.data[3] -= 120;
					GlobalScript.inst.gameState.data[9] -= 150;
					GlobalScript.inst.gameState.data[4] += 150;
					GlobalScript.inst.gameState.data[6] += 30;
					GlobalScript.inst.gameState.KillPerson(GlobalScript.inst.gameState.faction_leader[3]);
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在中共中央委员会当前全体会议上，在你的支持下并获得几乎全票赞\n成（少数保守派几乎没有什么权力），宣布启动市场改革，\n并通过所谓“改革开放”政策，意味着中国将进入世界市场，\n并按市场原则重组经济。" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "他却仍设法保住了权力——因为他此前并未明显表示反对改革，\n并且及时转到了改革派一边。\n不过，在改革进程中，他还能继续保住吗？";
					GlobalScript.inst.gameState.data[1] += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[89] = 1;
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[3] += 60;
					GlobalScript.inst.gameState.data[6] -= 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					party_change[2] = 3f;
					party_change[3] = 4f;
					party_change[4] = 2.5f;
					GlobalScript.inst.gameState.party_ideology[0] -= (int)((float)GlobalScript.inst.gameState.party_ideology[0] * 0.15f);
					GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.15f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic55 in politics)
					{
						if (politic55.traits[0] == 0)
						{
							Politic politic = politic55;
							politic.power -= 200;
							politic = politic55;
							politic.loyality -= 500;
						}
						else if (politic55.traits[0] == 1)
						{
							Politic politic = politic55;
							politic.power += 100;
							politic = politic55;
							politic.loyality -= 100;
						}
						else if (politic55.traits[0] == 2)
						{
							Politic politic = politic55;
							politic.power += 200;
							politic = politic55;
							politic.loyality += 200;
						}
						else if (politic55.traits[0] == 3)
						{
							Politic politic = politic55;
							politic.power += 80;
							politic = politic55;
							politic.loyality += 70;
						}
					}
					if (GlobalScript.inst.gameState.modifies[59].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = true;
						GlobalScript.inst.gameState.modifies[62].active = false;
					}
					else if (GlobalScript.inst.gameState.modifies[60].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = true;
						GlobalScript.inst.gameState.modifies[62].active = false;
					}
					else if (GlobalScript.inst.gameState.modifies[61].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = false;
						GlobalScript.inst.gameState.modifies[62].active = true;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 45)
			{
				text2 = "改革开放：开端";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "决定削弱中央政府在国有企业管理中的作用，\n鼓励地方在这方面的主动性，积极引入市场化经营方式，\n并扩大私营与合作企业的权利。\n|对这项政策的不满，出乎意料地来自某些人：\n在阿尔巴尼亚，霍查（恩维尔·霍查）尖锐批评我们的政策是修正主\n义、背离马克思主义，并与我们断绝一切联系。\n好吧，他想坐在孤立里——这是他的权利。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[4] += 50;
					if (GlobalScript.inst.gameState.data[16] == 10)
					{
						GlobalScript.inst.gameState.data[16] = 12;
					}
					else if (GlobalScript.inst.gameState.data[16] <= 14)
					{
						GlobalScript.inst.gameState.data[16]++;
					}
					GlobalScript.inst.gameState.data[89] = 2;
					GlobalScript.inst.gameState.data[92] += 20;
					GlobalScript.inst.gameState.data[6] -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					GlobalScript.inst.gameState.allcountries[20].Torg = false;
					GlobalScript.inst.gameState.allcountries[20].proprc = false;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic56 in politics)
					{
						if (politic56.traits[0] == 1)
						{
							Politic politic = politic56;
							politic.power += 50;
						}
						else if (politic56.traits[0] == 2)
						{
							Politic politic = politic56;
							politic.power += 100;
						}
						else if (politic56.traits[0] == 3)
						{
							Politic politic = politic56;
							politic.power += 50;
						}
					}
					if (GlobalScript.inst.gameState.modifies[59].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = true;
						GlobalScript.inst.gameState.modifies[62].active = false;
					}
					else if (GlobalScript.inst.gameState.modifies[60].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = true;
						GlobalScript.inst.gameState.modifies[62].active = false;
					}
					else if (GlobalScript.inst.gameState.modifies[61].active)
					{
						GlobalScript.inst.gameState.modifies[59].active = false;
						GlobalScript.inst.gameState.modifies[60].active = false;
						GlobalScript.inst.gameState.modifies[61].active = false;
						GlobalScript.inst.gameState.modifies[62].active = true;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 46)
			{
				text2 = "新的 1956？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们对匈牙利的事态没有作出反应。\n卡达尔（卡达尔）对比兹库（比斯库）及其支持者发动了打击。\n看来他们——连比兹库本人——很快就要等着辞职了，\n而卡达尔将提拔年轻改革派顶上。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏我们情报部门的及时协助，比兹库意识到安德罗波夫出卖了他；\n在我们特工的帮助下，他紧急改动政变计划，\n并几乎立刻采取行动：通过工人民兵把卡达尔支持者隔离起来，\n并召开了匈牙利社会主义工人党（HSWP）\n中央委员会的非常代表大会。\n在会上，向卡达尔提醒他曾与伊姆雷·纳吉合作、\n并在1956年起义初期给予支持；同时也指出他背离马克思主义原\n则、以及国家外债不断增长。\n卡达尔被撤去所有职务，并被开除出HSWP。\n贝拉·比兹库成为新的总书记；他开始把经济拉回中央计划体制，\n开始清洗“卡达尔式”的改革派，并且开始奉行更独立的外交政策—\n—已经与我们签订了几份颇有用的合同。\n当然，苏联并不高兴，但在明白匈牙利一切都已平静之后，\n只能作些干巴巴的评论。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[9] -= 80;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 300;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support--;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.allcountries[4].Torg = true;
					GlobalScript.inst.gameState.allcountries[4].prosov = false;
					GlobalScript.inst.gameState.allcountries[4].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[4].SubGosstroy = 16;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "多亏我们提供的行动情报与支持，比兹库得以迅速聚拢一批保守派共\n产党人、斯大林主义者、民族主义者以及其他对卡达尔政策不满的人，\n并把他的支持者带上街头示威；同时在工人警察的协助下，\n控制行政大楼，逮捕卡达尔及其支持者。\n然而，这场街头表演并未就此停止。\n察觉自己权力的不稳，比兹库随后试图安抚那些示威者——而反苏势\n力已开始加入其中——再转而利用他们为自己所用。\n苏联向布达佩斯发出一轮又一轮呼吁，要求恢复国内秩序、\n恢复法制。但在厌倦了无果的谈判、并看到比兹库越来越倾向于接受\n来自中国的直接支持，且有可能退出华沙条约的情况下，\n苏联派兵进入匈牙利：逮捕了失败的政变者，\n释放了原领导层，并安抚了民众。\n苏联领导层决定不再冒险，便没有把卡达尔再推回总书记岗位（他因\n健康原因退下），而是扶植亲苏的温和派亚诺什·帕普（János\n Pápp）上台；他开始把匈牙利拉回苏联式计划体制，\n并切断同西方的联系，奉行日益亲苏的政策。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 15;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 150;
					GlobalScript.inst.gameState.data[9] -= 30;
					GlobalScript.inst.gameState.data[22] -= 10;
					GlobalScript.inst.gameState.data[6] += 40;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support -= 2;
					GlobalScript.inst.gameState.data[112]++;
					GlobalScript.inst.gameState.allcountries[4].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[4].SubGosstroy = 16;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "由于我们告诉他安德罗波夫的背叛，比兹库意识到在匈牙利，\n自己最多也不过是被迫辞职，并被禁止批评卡达尔路线。\n他决定利用我们的提议：携同家人以及愿意追随他的支持者逃往中国。\n在我们媒体上，他开始广泛批判匈牙利，\n甚至有时也批判苏联的修正主义。\n这使我们的人民有所思考，并在世界左翼运动的眼中扩大了我们的影\n响力，但也破坏了我们与苏联本就不算最好的关系。\n在匈牙利，年轻改革派继续在卡达尔的支持下顶替离去的保守派。";
					GlobalScript.inst.gameState.data[1] += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 80;
					GlobalScript.inst.gameState.data[6] += 20;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GlobalScript.inst.gameState.data[4] -= 40;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "由于我们已告知他安德罗波夫的背叛，比斯库意识到在匈牙利，\n自己最多也就是被撤职，并被禁止批评卡达尔路线；\n因此他决定不作任何准备、极端仓促地发动先发制人的政变。\n结果，由比斯库集团组织的MSZMP非常代表大会引发了数股力量\n之间的对抗，“党内铁板一块、步调一致”的外观随之崩塌。\n于是，尽管比斯库集团及他本人都因派别活动而在多数票表决中被开\n除出党，我们以及许多其他不受苏联影响控制的共产党报纸，\n还是设法刊登了关于大会上所发生事情的文章。\n后果是：卡达尔被迫为全党的丢脸承担责任，\n并促成了权力向一位在他看来前途可期的年轻共产党人卡罗伊·格罗\n什（Károly Grosz）移交。\n格罗什上台后由于权威不足，试图组建面向温和、\n渐进改革的MSZMP集体领导。\n党内著名改革派伊姆雷·波兹加伊（Imre Pozsgay）\n出任宣传思想书记。在不正式攻击意识形态根基的前提下，\n波兹加伊逐步放松意识形态控制，允许一些公开讨论与倡议，\n从而赢得了人气，主要是在知识分子中间。\n同时，卡罗伊·格罗什本人也积极投入到对经济问题的斗争；\n为此，匈牙利加入了国际货币基金组织（IMF）\n（为再争取一笔贷款，尽管莫斯科提出抗议，\n匈牙利仍成为第一个加入IMF的经互会国家），\n并对小型企业以及国家与外国公司之间的合资企业予以合法化。\n匈牙利开始走上新的道路……";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 5;
					GlobalScript.inst.gameState.data[9] -= 80;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 150;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support++;
					GlobalScript.inst.gameState.allcountries[4].Torg = true;
					GlobalScript.inst.gameState.allcountries[4].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[4].SubGosstroy = 15;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 47)
			{
				text2 = "北京之春";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "一如既往，中央情报部门（MS）和警察开始撕毁大字报，\n并搜查地下“萨米兹达特”（samizdat）；\n中共又掀起了一轮对改革派的清洗（不过由于改革派在许多中共机\n构中占据主导，这次并不那么顺利）。\n人民与改革派都不满，但抗议浪潮已经停了。\n希望现在不满者不会转向更激进的行动。";
					GlobalScript.inst.gameState.data[1] -= 80;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[3] -= 80;
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.05f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic57 in politics)
					{
						if (politic57.traits[0] == 2)
						{
							Politic politic = politic57;
							politic.power -= 100;
							politic = politic57;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "由我们控制的媒体积极发表文章，反驳改革派的论点；\n而在中共会议室里，左右两派之间的争论又一次燃起。\n当然，改革派也用新的文章和杂志作出回应。\n群众带着兴趣关注你们的争论；尽管由于改革派的民粹主义，\n大多数同情站在他们一边，但你们的立场也同样有支持者。\n然而，这样广泛地讨论政治问题（自“百花齐放”运动以来第一次）\n增强了人民对民主变革必然性的信心。\n谁知道最后会变成什么样……";
					GlobalScript.inst.gameState.data[1] += 30;
					GlobalScript.inst.gameState.data[4] += 80;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[6] -= 10;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic58 in politics)
					{
						if (politic58.traits[0] == 2)
						{
							Politic politic = politic58;
							politic.power += 50;
							politic = politic58;
							politic.loyality += 50;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "你这边没有什么特别反应。\n左右两派的争斗大多还局限在中共会议室的墙内；\n我们的媒体继续为你们摇旗呐喊，批评改革派及其支持者的那些论点\n（看来媒体也并不怎么灵）；学生们则继续张贴大字报。\n好吧，至少还看不到大规模的不满。";
					GlobalScript.inst.gameState.data[1] -= 80;
					GlobalScript.inst.gameState.data[4] += 120;
					GlobalScript.inst.gameState.data[3] -= 60;
					party_change[3] = 1f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic59 in politics)
					{
						if (politic59.traits[0] == 2)
						{
							Politic politic = politic59;
							politic.power += 150;
							politic = politic59;
							politic.loyality += 50;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 63)
			{
				text2 = "四月革命";
				GlobalScript.inst.gameState.allcountries[12].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 1;
				GlobalScript.inst.gameState.allcountries[12].prosov = true;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们没有回应“四月革命”以及PDPA（阿富汗人民民主党）\n内部的事态。当然，党对这种消极被动很不满意。\n在阿富汗民主共和国（DRA）里，革命中获得权力的“哈勒克派”\n（Khalqists）正积极试图从“帕尔查姆派”（Parch\nam）手中夺取一部分权力。";
					GlobalScript.inst.gameState.data[1] -= 80;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 30;
					GlobalScript.inst.gameState.data[46] = 10;
					GlobalScript.inst.gameState.data[48] = 150;
					GlobalScript.inst.gameState.data[49] = 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "鉴于对苏联影响力这种扩张的不满，中共领导层决定对阿富汗境内那\n些忠于中华人民共和国的反对派提供力所能及的支持。\n武器与秘密援助被送往毛主义者、左翼反对派、\n温和派伊斯兰主义者以及其他反对力量。\n希望这能遏制苏联的扩张。";
					GlobalScript.inst.gameState.data[1] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 30;
					GlobalScript.inst.gameState.data[9] -= 30;
					GlobalScript.inst.gameState.data[46] = 40;
					GlobalScript.inst.gameState.data[48] = 150;
					GlobalScript.inst.gameState.data[49] = 100;
					GlobalScript.inst.gameState.data[6] -= 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "经过长期争论，决定同阿富汗新政府建立关系，\n尤其是同PDPA中的<color=red>喀尔克</color>派建立关系。\n结果比我们想的更简单，因为PDPA并未卷入苏中争论，\n而且上台后名义上宣称奉行不结盟政策。\n<color=red>喀尔克</color>派感激我们的支持，显然还在利用其日益增长的力量向<color=red>帕尔查\n姆</color>施压，并在DRA争取对权力的垄断。";
					GlobalScript.inst.gameState.data[1] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 30;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[46] = 10;
					GlobalScript.inst.gameState.data[48] = 180;
					GlobalScript.inst.gameState.data[49] = 100;
					GlobalScript.inst.gameState.data[6] += 20;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "经过长期争论，决定同阿富汗新政府建立关系，\n尤其是同PDPA中的<color=red>帕尔查姆</color>派建立关系。\n结果比我们想的更简单，因为PDPA并未卷入苏中争论，\n而且上台后名义上宣称奉行不结盟政策。\n多亏我们的支持，<color=red>帕尔查姆</color>得以克服来自<color=red>喀尔克</color>日益加大的压力。\n尤其是<color=red>帕尔查姆</color>派，联合部分<color=red>喀尔克</color>派，\n已经能够放慢塔拉基亲密盟友哈菲祖拉·阿明的上升之路——而他又\n不被党所信任。";
					GlobalScript.inst.gameState.data[1] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 30;
					GlobalScript.inst.gameState.data[9] -= 60;
					GlobalScript.inst.gameState.data[46] = 10;
					GlobalScript.inst.gameState.data[48] = 140;
					GlobalScript.inst.gameState.data[49] = 140;
					GlobalScript.inst.gameState.data[6] += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 48)
			{
				text2 = "政变仍在继续";
				GlobalScript.inst.gameState.allcountries[12].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 10;
				GlobalScript.inst.gameState.allcountries[12].Vyshi = false;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "阿明上台后，对其现有及潜在的政治对手发动了广泛镇压。\n尽管其宣称要“摧毁封建主”，但在“摧毁”的名义下，\n遭殃的并不只是他们。\n苏联似乎对这次政变不满，尽管它假装一切都好。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "阿明上台后，对其现有及潜在的政治对手发动了广泛镇压。\n尽管其宣称要“摧毁封建主”，但在“摧毁”的名义下，\n遭殃的并不只是他们。\n苏联似乎对这次政变不满，尽管它假装一切都好。\n我们的秘密使节和特工部门与阿明建立了联系——他对获得新的盟友\n非常高兴。然而与此同时，他又开始向我们索要对阿富汗的物质援助。";
					GlobalScript.inst.gameState.data[8] -= 20;
					GlobalScript.inst.gameState.data[6] += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在继续同苏联的“伟大友谊”同时，并不太信任阿明，" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "尽管中央委员会个别成员提出抗议，仍决定同苏联进行秘密磋商，\n讨论阿明政权对DRA的危险性以及需要将其除掉。\n苏联领导层对这种“干掉”潜在盟友的意愿感到十分惊讶——看起来\n也并不完全信任我们，但总体上还是很高兴。\n我们将等待这些事件的进一步发展。\n阿明上台后，对其现有及潜在的政治对手发动了广泛镇压。\n尽管其宣称要“摧毁封建主”，但在“摧毁”的名义下，\n遭殃的并不只是他们。\n苏联似乎对这次政变不满，尽管它假装一切都好。\n我们的秘密使节和特工部门与阿明建立了联系——他对获得新的盟友\n非常高兴。然而与此同时，他又开始向我们索要对阿富汗的物质援助。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[49] = 110;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 70;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 40;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 49)
			{
				text2 = "反对一切暴君";
				GlobalScript.inst.gameState.allcountries[12].Vyshi = false;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					if (GlobalScript.inst.gameState.data[49] > 150)
					{
						text = "12月27日晚，苏联方面先封锁了喀布尔驻军部分兵力，\n并夺取了总参谋部大楼。\n随后，苏联克格勃特种部队与军队对阿明住所发起突袭——阿明在突\n袭中身亡（尽管命令是要活捉）。\n在苏联支持下，阿富汗由<color=red>阿萨杜拉·萨尔瓦里</color>出任领导——他是<color=red>喀尔\n克</color>派成员，曾任阿富汗特工部门负责人，\n曾遭阿明的镇压。总体而言，尽管有少数忠于阿明的军队部队抵抗，\n但他的更替进行得毫无障碍。\n与此同时，苏军的进入与部署仍在继续。";
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power += 10;
						GlobalScript.inst.gameState.data[48] = 150;
						GlobalScript.inst.gameState.data[107] = 9;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 20;
						GlobalScript.inst.gameState.data[49] = 100;
						GlobalScript.inst.gameState.allcountries[12].Gosstroy = 1;
						GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 1;
					}
					else
					{
						text = "12月27日晚，苏联方面先封锁了喀布尔驻军部分兵力，\n并夺取了总参谋部大楼。\n随后，苏联克格勃特种部队与军队对阿明住所发起突袭——阿明在突\n袭中身亡（尽管命令是要活捉）。\n在苏联支持下，阿富汗由<color=red>巴布拉克·卡尔迈勒</color>出任领导——他是<color=red>帕尔\n查姆</color>派的创始人和长期领导者，也是阿明的老对手。\n总体而言，尽管有少数忠于阿明的军队部队抵抗，\n但他的更替进行得毫无障碍。\n与此同时，苏军的进入与部署仍在继续。";
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power += 10;
						GlobalScript.inst.gameState.data[48] = 100;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 20;
						GlobalScript.inst.gameState.data[49] = 150;
						GlobalScript.inst.gameState.allcountries[12].Gosstroy = 1;
						GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 1;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏我们及时的警告，阿明设法让其忠诚部队进入战备状态；\n而他本人则离开住所，躲到喀布尔郊外避难。\n苏联甚至在行动一开始就意识到他的计划失败了，\n于是召回了特种部队。\n只有依靠我们与阿富汗外交官的努力，以及阿明刻意装作若无其事、\n名义上也不改变政策，才避免了一场重大的国际丑闻。\n当然，苏联仍然不快，并开始迅速减少对阿富汗的援助。\n苏军的进入也被放慢了，他们的任务同样被拖延。\n看来他们最终会连同苏联专家一起撤走——这样在内战初期，\n我们就得把对阿富汗的一切援助都扛起来。\n与此同时，阿明同中华人民共和国签订了一系列条约，\n并邀请此前一直处于反对地位的毛主义者以有利条件加入PDPA，\n把他们纳入政府。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
					GlobalScript.inst.gameState.data[9] -= 70;
					GlobalScript.inst.gameState.data[46] = 100;
					GlobalScript.inst.gameState.data[49] = 180;
					GlobalScript.inst.gameState.data[6] += 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 400;
					GlobalScript.inst.gameState.allcountries[12].prosov = false;
					GlobalScript.inst.gameState.allcountries[12].proprc = true;
					GlobalScript.inst.gameState.ingamewars[5].name_war = "阿富汗内战";
					GlobalScript.inst.gameState.ingamewars[5].is_going = true;
					GlobalScript.inst.gameState.ingamewars[5].side1 = "DRA";
					GlobalScript.inst.gameState.ingamewars[5].side2 = "Mujahideen";
					GlobalScript.inst.gameState.ingamewars[5].ussr_place = -1;
					GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
					GlobalScript.inst.gameState.ingamewars[5].infl1 = 500;
					GlobalScript.inst.gameState.ingamewars[5].infl2 = 500;
					if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 100;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 100;
					}
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 50;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 50;
					}
					if (GlobalScript.inst.gameState.data[107] == 9)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 += 25;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 -= 25;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 50)
			{
				text2 = "诅咒之山，荒野之隅……";
				GlobalScript.inst.gameState.allcountries[12].Vyshi = false;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们决定不介入阿富汗事务。\n与此同时，国内内战正打得如火如荼，结局谁也无法预料。";
					GlobalScript.inst.gameState.ingamewars[5].name_war = "阿富汗内战";
					GlobalScript.inst.gameState.ingamewars[5].is_going = true;
					GlobalScript.inst.gameState.ingamewars[5].side1 = "DRA";
					GlobalScript.inst.gameState.ingamewars[5].side2 = "Mujahideen";
					GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
					GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
					GlobalScript.inst.gameState.ingamewars[5].infl1 = 750;
					GlobalScript.inst.gameState.ingamewars[5].infl2 = 250;
					if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 100;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 100;
					}
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 50;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 50;
					}
					if (GlobalScript.inst.gameState.data[107] == 9)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 += 25;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 -= 25;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏我们同苏联的关系，我们得以同DRA进行谈判。\n作为我们支持的交换，他们停止对此前处于反对地位的毛主义者的迫\n害，并与他们结成“进步力量联盟”，共同对抗伊斯兰主义与美国帝\n国主义——前提是毛主义者自己放下武器（他们虽不情愿，\n但还是同意了）。这就是我们的外交胜利！\n与此同时，国内内战正打得如火如荼，结局谁也无法预料。";
					GlobalScript.inst.gameState.data[1] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[46] = 80;
					GlobalScript.inst.gameState.data[6] += 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 250;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.ingamewars[5].name_war = "阿富汗内战";
					GlobalScript.inst.gameState.ingamewars[5].is_going = true;
					GlobalScript.inst.gameState.ingamewars[5].side1 = "DRA";
					GlobalScript.inst.gameState.ingamewars[5].side2 = "Mujahideen";
					GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
					GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
					GlobalScript.inst.gameState.ingamewars[5].infl1 = 770;
					GlobalScript.inst.gameState.ingamewars[5].infl2 = 230;
					gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 30;
					if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 100;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 100;
					}
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 50;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 50;
					}
					if (GlobalScript.inst.gameState.data[107] == 9)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 += 25;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 -= 25;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在政治局经过长期讨论时，个别党内成员固执地反对支持亲苏的DR\nA政权，同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "仍然力排众议，推行支持DRA的战略（至少在口头上），\n他们对此当然并不介意。\n与此同时，国内内战正打得如火如荼，结局谁也无法预料。";
					GlobalScript.inst.gameState.data[1] -= 70;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
					GlobalScript.inst.gameState.data[6] += 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 300;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GlobalScript.inst.gameState.ingamewars[5].name_war = "阿富汗内战";
					GlobalScript.inst.gameState.ingamewars[5].is_going = true;
					GlobalScript.inst.gameState.ingamewars[5].side1 = "DRA";
					GlobalScript.inst.gameState.ingamewars[5].side2 = "Mujahideen";
					GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
					GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
					GlobalScript.inst.gameState.ingamewars[5].infl1 = 760;
					GlobalScript.inst.gameState.ingamewars[5].infl2 = 240;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 20;
					if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 100;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 100;
					}
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 50;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 50;
					}
					if (GlobalScript.inst.gameState.data[107] == 9)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 += 25;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 -= 25;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "担心苏联势力扩张，我们决定支持阿富汗的毛主义组织，\n参与其对DRA与伊斯兰主义者的武装斗争。\n当然，苏联和美国都不喜欢这一点；而阿富汗的毛主义者也并不算什\n么特别强大的力量，所以我们将投入不少力量去支援他们……\n与此同时，国内内战正打得如火如荼，\n结局谁也无法预料。";
					GlobalScript.inst.gameState.data[1] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 30;
					GlobalScript.inst.gameState.data[6] += 30;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 150;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 150;
					GlobalScript.inst.gameState.ingamewars[5].name_war = "阿富汗毛主义者起义";
					GlobalScript.inst.gameState.ingamewars[5].is_going = true;
					GlobalScript.inst.gameState.ingamewars[5].side1 = "Maoists";
					GlobalScript.inst.gameState.ingamewars[5].side2 = "Other";
					GlobalScript.inst.gameState.ingamewars[5].ussr_place = 1;
					GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
					GlobalScript.inst.gameState.ingamewars[5].infl1 = 50;
					GlobalScript.inst.gameState.ingamewars[5].infl2 = 950;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "后来，美中峰会竟以“发展贸易与经济合作”为借口出乎意料地迅速\n举行，但其目标完全不同。\n在闭门谈判中，美方代表团向中国提出一份合同：\n购买武器，并将其跨过中国边境运往邻近的阿富汗，\n以支持圣战者对抗苏联的侵略，并对傀儡DRA政权给予沉重打击。\n中方接受了美方提议，首批武器运送计划在未来三个月内部署；\n不过，我们从中只会获益——我们的成本将由新的战略盟友来承担。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 30;
					GlobalScript.inst.gameState.ingamewars[5].name_war = "阿富汗内战";
					GlobalScript.inst.gameState.ingamewars[5].is_going = true;
					GlobalScript.inst.gameState.ingamewars[5].side1 = "DRA";
					GlobalScript.inst.gameState.ingamewars[5].side2 = "Mujahideen";
					GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
					GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
					GlobalScript.inst.gameState.ingamewars[5].infl1 = 700;
					GlobalScript.inst.gameState.ingamewars[5].infl2 = 300;
					GlobalScript.inst.gameState.data[8] += 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 200;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 200;
					if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 100;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 100;
					}
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 -= 50;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 += 50;
					}
					if (GlobalScript.inst.gameState.data[107] == 9)
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 += 25;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 -= 25;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 51)
			{
				text2 = "先顶住，然后撤……";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在释放部分兵力、并在苏联顾问与航空力量的帮助下，\nDRA对伊斯兰主义者发动了相对成功的军事行动。\n至于未来能否取得胜利，现在还为时过早；\n但在美国无法直接进入阿富汗的情况下，\nDRA确实占据明显优势。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "在加入西方外交官的发言之后，我们也谴责苏军进入阿富汗，\n称其是对主权国家事务的粗暴干涉。\n西方领导人支持我们的表态，但苏联领导层没有回应。\n与此同时，在释放部分兵力、并在苏联顾问与航空力量的帮助下，\nDRA对伊斯兰主义者发动了相对成功的军事行动。\n至于未来能否取得胜利，现在还为时过早；\n但在美国无法直接进入阿富汗的情况下，\nDRA确实占据明显优势。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 80;
					GlobalScript.inst.gameState.data[6] -= 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "与全世界对“入侵”的舆论相反，我们决定支持苏军的进入——因为\n它的目的在于确保阿富汗的和平与稳定，\n并且依据《苏阿友好条约》完全具有合法性。\n当然，在西方，我们被称为血腥政权的同谋；\n但苏联对我们的支持表示感谢。";
					GlobalScript.inst.gameState.data[1] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 110;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 52)
			{
				text2 = "难处的邻里……";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "一切照旧。巴基斯坦当局压制激进宣讲，\n并不允许武器通过边境检查站携带入境，\n但他们既没有力量，也没有意愿——或者两者都没有。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们向布托做了再明显不过的暗示：是时候制止边境上猖獗的恐怖分\n子了；同时派出我们的特工和军队协助。\n于是，中巴双方开始行动：巡逻边境、追踪激进伊斯兰主义团体。\n我必须说，这次行动取得了成功——伊斯兰主义者根本没想到巴基斯\n坦会有如此强硬的反应，几乎是被打了个措手不及。\n其余的则躲了起来，现在也无法再以同样效率运作。\n祝你们挖边境下的地道好运。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GlobalScript.inst.gameState.data[6] += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GlobalScript.inst.gameState.data[9] -= 40;
					GlobalScript.inst.gameState.data[22] -= 50;
					if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 1)
					{
						GlobalScript.inst.gameState.data[94] = 1;
					}
					else
					{
						warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl1 += 100;
						warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
						warinwars2.infl2 -= 100;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在与美国达成默契协议，并说服布托不要阻挠我们之后，\n我们开始把美制武器与顾问运往巴基斯坦—阿富汗边境，\n再转交给圣战者；他们随后以“半合法”的方式越过边境，\n进入阿富汗。这极大地帮助了反对DRA的阿富汗反叛者；\n而反过来，作为“中介服务费”，美国的钱也会流进我们的口袋。";
					GlobalScript.inst.gameState.data[8] += 30;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					GlobalScript.inst.gameState.data[6] -= 10;
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 80;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 80;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 120;
					GlobalScript.inst.gameState.data[94] = 2;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "继续援助阿富汗的毛主义叛乱者，我们把伊斯兰主义者赶离边境，\n为毛主义者组织训练营和补给中心——如今我们在这里向他们提供武\n器并派遣教官，这极大地帮助了这些反叛者。\n巴基斯坦当局也同意让人员与武器得以不受阻碍地送往阿富汗。\n当然，为了建立这种基础设施，我们得掏钱；\n为补给而动用军队也要付出代价；苏联和美国对此都不满意。";
					GlobalScript.inst.gameState.data[8] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					GlobalScript.inst.gameState.data[22] -= 100;
					GlobalScript.inst.gameState.data[6] += 30;
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 += 10;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 -= 10;
					GlobalScript.inst.gameState.data[94] = 3;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 53)
			{
				text2 = "农业改革";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "决定不去打破已经在运转的东西。\n问题只有一个：它运转得极其糟——农业形势并不理想，\n这反过来损害了人民的生活水平与满意度。";
					GlobalScript.inst.gameState.data[1] -= 80;
					GlobalScript.inst.gameState.data[13] -= 100;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[3] -= 70;
					GlobalScript.inst.gameState.data[5] -= 50;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic60 in politics)
					{
						Politic politic = politic60;
						politic.loyality -= 100;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "决定解散人民公社，把土地分给独立的家庭农场；\n家庭农场必须按固定价格向国家出售规定的收成。\n这推动了我们经济的增长，增加了粮食供应，\n人民也很喜欢。";
					GlobalScript.inst.gameState.data[1] -= 150;
					GlobalScript.inst.gameState.data[13] += 50;
					GlobalScript.inst.gameState.data[92] += 10;
					GlobalScript.inst.gameState.data[4] += 30;
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.data[5] += 50;
					party_change[2] = 0.8f;
					party_change[3] = 0.8f;
					GlobalScript.inst.gameState.data[26] += 15;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic61 in politics)
					{
						if (politic61.traits[0] == 1)
						{
							Politic politic = politic61;
							politic.power += 120;
							politic = politic61;
							politic.loyality += 100;
						}
						else if (politic61.traits[0] == 2)
						{
							Politic politic = politic61;
							politic.power += 120;
							politic = politic61;
							politic.loyality += 100;
						}
					}
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在与政治局保守派、甚至较为温和的部分进行长期讨论后，\n改革派终于说服中共用“私有土地承包”取代公社。\n新农户获得贷款，用于购买机械和设备；\n同时他们也被要求向国家出售部分农作物，\n其余部分则可在市场上按自由价格出售。\n这使得提高生产率、并通过向年轻的私有者征收税费来补充财政成为\n可能；但并非党内所有人都对这一决定感到满意。\n新的私有者已经开始投机炒作价格，而人民则在等待进一步改革。";
					GlobalScript.inst.gameState.data[1] -= 70;
					GlobalScript.inst.gameState.data[92] += 30;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[3] += 70;
					GlobalScript.inst.gameState.data[6] -= 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 30;
					GlobalScript.inst.gameState.data[8] += 40;
					GlobalScript.inst.gameState.data[57] -= 30;
					GlobalScript.inst.gameState.data[26] += 30;
					party_change[2] = 0.3f;
					party_change[3] = 1f;
					party_change[4] += 0.8f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic62 in politics)
					{
						if (politic62.traits[0] == 0)
						{
							Politic politic = politic62;
							politic.power -= 100;
							politic = politic62;
							politic.loyality -= 250;
						}
						else if (politic62.traits[0] == 2)
						{
							Politic politic = politic62;
							politic.power += 150;
							politic = politic62;
							politic.loyality += 100;
						}
						else if (politic62.traits[0] == 3)
						{
							Politic politic = politic62;
							politic.power += 150;
							politic = politic62;
							politic.loyality += 200;
						}
					}
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = false;
					GlobalScript.inst.gameState.modifies[62].active = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "决定恢复斯大林式的集体农场做法——我们不需要搞什么特别的集体\n化；大多数集体农场都是在对公社进行改组的基础上建立起来的。\n如今我们的农业由林林总总、由国家控制的合作社构成：\n它们被要求以固定价格向国家出售部分收成，\n其余部分则可在市场上以更自由的价格出售。\n大规模兴建并配备机耕站的工作也开始了——机耕站将为集体农场提\n供设备。最终，这帮助我们克服了技术落后，\n并在未来有望带来生产率增长；不过，为这些事情，\n我们得掏钱。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[8] -= 50;
					GlobalScript.inst.gameState.data[3] += 70;
					GlobalScript.inst.gameState.data[5] += 30;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.data[13] += 50;
					if (!GlobalScript.inst.gameState.science[0])
					{
						GlobalScript.inst.gameState.science[0] = true;
					}
					else if (!GlobalScript.inst.gameState.science[1])
					{
						GlobalScript.inst.gameState.science[1] = true;
					}
					else if (!GlobalScript.inst.gameState.science[2])
					{
						GlobalScript.inst.gameState.science[2] = true;
					}
					GlobalScript.inst.gameState.modifies[15].active = false;
					GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.09f);
					GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.5f);
					GlobalScript.inst.gameState.party_ideology[4] -= (int)((float)GlobalScript.inst.gameState.party_ideology[4] * 0.24f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic63 in politics)
					{
						if (politic63.traits[0] == 0)
						{
							Politic politic = politic63;
							politic.power += 120;
							politic = politic63;
							politic.loyality += 150;
						}
						else if (politic63.traits[0] == 1)
						{
							Politic politic = politic63;
							politic.power -= 80;
							politic = politic63;
							politic.loyality -= 100;
						}
						else if (politic63.traits[0] == 2)
						{
							Politic politic = politic63;
							politic.power -= 100;
							politic = politic63;
							politic.loyality -= 150;
						}
						else if (politic63.traits[0] == 3)
						{
							Politic politic = politic63;
							politic.power -= 150;
							politic = politic63;
							politic.loyality -= 200;
						}
					}
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = true;
					GlobalScript.inst.gameState.modifies[61].active = false;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 54)
			{
				text2 = "改革开放：投资";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "尽管不断有抗议与指责，称其是在拖慢改革，" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "仍然决定暂时把投资问题推迟，“以便我们能就此问题拿出最佳方案\n”。";
					GlobalScript.inst.gameState.data[1] -= 150;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[4] += 80;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic64 in politics)
					{
						if (politic64.traits[0] == 1)
						{
							Politic politic = politic64;
							politic.loyality -= 200;
						}
						else if (politic64.traits[0] == 2)
						{
							Politic politic = politic64;
							politic.loyality -= 200;
						}
						else if (politic64.traits[0] == 3)
						{
							Politic politic = politic64;
							politic.loyality -= 200;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "宣布将逐步开放部分沿海城市以吸引外资。\n广东省的深圳、珠海和汕头，以及福建省的厦门（福建省）\n将很快设立经济特区；整个海南省也将被改造为经济特区。\n美国和西欧国家对此决定表示热烈欢迎，\n大型西方企业的负责人也同样表示欢迎。";
					GlobalScript.inst.gameState.data[89] = 3;
					GlobalScript.inst.gameState.data[8] += 30;
					GlobalScript.inst.gameState.data[92] += 10;
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[6] -= 20;
					GlobalScript.inst.gameState.data[57] -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					party_change[2] = 0.8f;
					party_change[3] = 0.8f;
					GlobalScript.inst.gameState.SEZ = true;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic65 in politics)
					{
						if (politic65.traits[0] == 1)
						{
							Politic politic = politic65;
							politic.power += 120;
							politic = politic65;
							politic.loyality += 100;
						}
						else if (politic65.traits[0] == 2)
						{
							Politic politic = politic65;
							politic.power += 120;
							politic = politic65;
							politic.loyality += 150;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "尽管有些改革派与温和派提出抗议，最终还是决定全面向外资开放中\n国经济。按照计划，广东省的深圳、珠海和汕头，\n以及福建省的厦门（福建省）将很快设立经济特区；\n同时，整个海南省也将被改造为经济特区。\n与此同时，在合资计划下，绝大多数国有企业也向外资开放。\n尽管外资公司只能在经济特区内直接开展业务，\n但已经可以谈论外资将迅速、迅猛渗透进我们经济的迫在眉睫——因\n为西方已经以极大热情投入到我们的转变之中。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[92] += 20;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[3] += 30;
					GlobalScript.inst.gameState.data[6] -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 150;
					GlobalScript.inst.gameState.data[8] += 50;
					GlobalScript.inst.gameState.data[89] = 3;
					GlobalScript.inst.gameState.data[57] -= 70;
					party_change[3] = 0.5f;
					party_change[4] = 0.8f;
					GlobalScript.inst.gameState.SEZ = true;
					GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.09f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic66 in politics)
					{
						if (politic66.traits[0] == 0)
						{
							Politic politic = politic66;
							politic.power -= 100;
							politic = politic66;
							politic.loyality -= 250;
						}
						else if (politic66.traits[0] == 1)
						{
							Politic politic = politic66;
							politic.power -= 50;
							politic = politic66;
							politic.loyality -= 80;
						}
						else if (politic66.traits[0] == 2)
						{
							Politic politic = politic66;
							politic.power += 100;
							politic = politic66;
							politic.loyality += 50;
						}
						else if (politic66.traits[0] == 3)
						{
							Politic politic = politic66;
							politic.power += 150;
							politic = politic66;
							politic.loyality += 200;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 55)
			{
				text2 = "缅甸式通往社会主义的道路";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在缅甸社会主义纲领党（BSPP）内部，\n对共产党人及其同情者进行了大规模清洗，\n进一步巩固了吴奈温的统治。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "中方与缅方代表举行了会谈，签署了一系列条约，\n并明确了关系发展的方向。\n我们还追加拨付援助，用于恢复缅甸经济。\n与此同时，BSPP内部对共产党人及其同情者又进行了大规模清洗，\n进一步巩固了吴奈温的统治。";
					GlobalScript.inst.gameState.data[8] -= 30;
					GlobalScript.inst.gameState.data[6] += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					GlobalScript.inst.gameState.allcountries[33].Torg = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "多亏情报部门的介入，BSPP的左翼得以组织一次党内政变。\n我们的特工力量成功阻止了忠于吴奈温的军队插手。\n前独裁者本人被指控违反民主集中制原则，\n被关押后不久便以离奇方式死亡。\n新政府开始推行大规模社会主义改革，并通过同包括中华人民共和国\n在内的社会主义国家建立友好关系，寻找摆脱孤立的出路。";
					GlobalScript.inst.gameState.data[9] -= 40;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.data[8] -= 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 80;
					GlobalScript.inst.gameState.allcountries[33].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[33].SubGosstroy = 1;
					GlobalScript.inst.gameState.allcountries[33].Torg = true;
					GlobalScript.inst.gameState.allcountries[33].proprc = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 56)
			{
				text2 = "要不要给越南一个教训？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "你总算安抚住了中共（CPC），尽管并非没有怨气。\n一切照旧，越南继续向苏联靠拢。";
					GlobalScript.inst.gameState.data[1] -= 150;
					GlobalScript.inst.gameState.vietnampeace = true;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "决定准备对越南的入侵。\n2月17日4时30分，解放军部队越过边境，\n经过激烈战斗，攻占边境地区，瓦解了越南的抵抗。\n然而，已恢复的越南军队正转为猛烈反击。\n我们希望有足够的力量完成计划。";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.war = 1;
					GlobalScript.inst.gameState.data[39] = 200;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 200;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.data[163] = 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在同一批反苏倾向的党内成员反复争论之后，\n你仍然设法组织派遣中国代表团赴越南。\n谈判结果，我们不得不放弃对部分越南岛屿的主张，\n但最终争取到结束对越南华人的压迫，并获得将其迁往中国的权利；\n同时理顺关系，签署了若干贸易与政治条约。\n尽管越南仍把重心放在苏联方面，但我们同它的关系已显著改善，\n合作前景也大幅提升。\n苏联对我们试图同社会主义阵营建立关系的努力也表现出浓厚兴趣。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.vietnampeace = true;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 200;
					GlobalScript.inst.gameState.allcountries[11].Torg = true;
					gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 40;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 57)
			{
				text2 = "红日东升";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "结果，自民党（LDP）得以保住政权，\n得票率达44%，并利用反对派分裂的局面。\n首相大平正芳继续推行日本的自由—亲西方路线。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏及时铲除宫本健治（Kenji Miyamoto），\n共产党（CPJ）喜气洋洋地重新回到北京的掌控之下，\n并接受了我们的援助。\n凭借我们的资金支持，他们得以建立一套高效的选前攻势；\n而我们的情报部门则向自民党塞入足以致命的丑闻材料，\n破坏其演说。结果，CPJ得以创纪录地拿下31%的支持率，\n并与社会党、佛教公明党以及各个中间偏左的反对党组成联合政府。\n不久，自民党官员因腐败与滥用职权而被提起刑事案件；\n在广泛的民意支持下，国会通过法律，要求日本退出与美国及北约（\nNATO）的军事条约，并逐步撤出美国在日本的基地。";
					GlobalScript.inst.gameState.data[1] += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 150;
					GlobalScript.inst.gameState.data[8] -= 40;
					GlobalScript.inst.gameState.data[9] -= 60;
					GlobalScript.inst.gameState.allcountries[44].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[44].SubGosstroy = 8;
					GlobalScript.inst.gameState.allcountries[44].Vyshi = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 58)
			{
				text2 = "伊朗革命：终局";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					if (GlobalScript.inst.gameState.data[42] > GlobalScript.inst.gameState.data[43] && GlobalScript.inst.gameState.data[42] > GlobalScript.inst.gameState.data[44] && GlobalScript.inst.gameState.data[42] > GlobalScript.inst.gameState.data[45])
					{
						text = "他们终于达成目标：1月，沙阿及其家人逃离该国，\n把权力交给来自温和反对派的总理沙普尔·巴赫蒂亚尔（Shapo\nur Bakhtiar）；而巴赫蒂亚尔本人很快就被工人抗议浪\n潮推翻。在城市工人和军队单位的支持下，\n由各党派与运动组成的左翼联盟乘着“建立社会公正国家”的承诺热\n潮上台。霍梅尼从流亡中返回伊朗，试图由忠诚的武装分子组织起义，\n但很快被捕，支持他的运动也随之被瓦解。\n新政府宣布要建设带有伊斯兰特色的社会主义（与通常模式相比，\n只是在宗教政策上更为温和），然而看来，\n成立后的革命委员会首要任务将是消灭对革命结局不满的伊斯兰与民\n主反对派。";
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.power -= 10;
						GlobalScript.inst.gameState.allcountries[8].Gosstroy = 1;
						GlobalScript.inst.gameState.allcountries[8].SubGosstroy = 1;
						GlobalScript.inst.gameState.allcountries[8].Vyshi = false;
						GlobalScript.inst.gameState.allcountries[8].isSENTO = false;
						GlobalScript.inst.gameState.allcountries[8].isASEAN = false;
						if (GlobalScript.inst.gameState.allcountries[8].dev == 1)
						{
							GlobalScript.inst.gameState.data[143] += 10;
						}
						GlobalScript.inst.gameState.allcountries[8].Torg = true;
					}
					else if (GlobalScript.inst.gameState.data[43] > GlobalScript.inst.gameState.data[42] && GlobalScript.inst.gameState.data[43] > GlobalScript.inst.gameState.data[44] && GlobalScript.inst.gameState.data[43] > GlobalScript.inst.gameState.data[45])
					{
						text = "然而，在我们与美国对巴列维（Pahlavi）\n的积极支持下，萨瓦克（SAVAK）和军队成功镇压了示威，\n打掉了主要反对派领袖，瓦解了其队伍。\n巴黎也曾对霍梅尼本人发动暗杀企图，他幸存下来，\n但被迫隐入地下，至今尚未显露。\n可如今，最激进的抗议者已被击败，沙阿作出让步——组建了新政府，\n收紧对穆斯林宗教人士的控制、审查与镇压规模有所减轻，\n并举行了对最高层腐败官员的示范性逮捕。";
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.power += 10;
						if (GlobalScript.inst.gameState.allcountries[8].dev == 0)
						{
							GlobalScript.inst.gameState.allcountries[8].Torg = true;
						}
						GlobalScript.inst.gameState.data[143] -= 7;
					}
					else if (GlobalScript.inst.gameState.data[44] > GlobalScript.inst.gameState.data[42] && GlobalScript.inst.gameState.data[44] > GlobalScript.inst.gameState.data[43] && GlobalScript.inst.gameState.data[44] > GlobalScript.inst.gameState.data[45])
					{
						text = "他们终于达成目标：1月，沙阿及其家人逃离该国，\n把权力交给来自温和反对派的总理沙普尔·巴赫蒂亚尔（Shapo\nur Bakhtiar）。\n巴赫蒂亚尔开始起草新宪法，并在拒绝组建“民族团结政府”的抗议\n者要求下举行自由选举。\n选举胜出的是由伊朗民族阵线（Iranian National\n Front）领导的民主联盟；随后，\n该联盟成功压制了由霍梅尼领导的伊斯兰激进派的行动，\n并对那些对这一结果不满的伊斯兰主义者与激进左翼展开谨慎清洗。\n新成立的政府宣布忠于伊斯兰与民主原则，\n目标是以凯末尔土耳其模式推动国家发展，\n同时奉行多方向的外交政策。";
						GlobalScript.inst.gameState.allcountries[8].Gosstroy = 3;
						GlobalScript.inst.gameState.allcountries[8].SubGosstroy = 5;
						GlobalScript.inst.gameState.allcountries[8].Vyshi = false;
						if (GlobalScript.inst.gameState.allcountries[8].dev == 2)
						{
							GlobalScript.inst.gameState.allcountries[8].Torg = true;
						}
						GlobalScript.inst.gameState.data[143] -= 5;
					}
					else
					{
						text = "他们终于达成目标：1月，沙阿及其家人逃离该国，\n把权力交给来自温和反对派的总理沙普尔·巴赫蒂亚尔（Shapo\nur Bakhtiar）。\n巴赫蒂亚尔开始起草新宪法，并邀请被打入冷宫的阿亚图拉·霍梅尼\n回国——而他很快就为此付出了代价。\n霍梅尼并不打算与新政府合作，在众多支持者的帮助下组织了新的起\n义，并迅速蔓延到德黑兰。\n警方站在暴乱者一边，军方将领宣布中立，\n结果巴赫蒂亚尔逃离该国。\n霍梅尼的新政府宣布伊朗为伊斯兰共和国，\n并对昨天的盟友发动残酷镇压。";
						GlobalScript.inst.gameState.allcountries[8].Vyshi = false;
						GlobalScript.inst.gameState.allcountries[8].SubGosstroy = 9;
						GlobalScript.inst.gameState.allcountries[8].isSENTO = false;
						GlobalScript.inst.gameState.allcountries[8].isASEAN = false;
						if (GlobalScript.inst.gameState.allcountries[8].dev == 3)
						{
							GlobalScript.inst.gameState.allcountries[8].Torg = true;
						}
						GlobalScript.inst.gameState.data[143] += 10;
					}
					GlobalScript.inst.gameState.iranrev = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 59)
			{
				text2 = "经济联盟";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "什么也没发生，咱们希望这只是往好的方向发展。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "今天，在中华人民共和国的倡议下，北京召开了一次闭门经济会议，\n会议通过决议，成立经济合作组织（ECO）。\n该组织的宗旨是扩大中国友好国家之间的贸易与经济联系。\n新联盟的创始成员是中国";
					GlobalScript.inst.gameState.data[1] += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 30;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GlobalScript.inst.gameState.data[3] += 80;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[8] -= 150;
					GlobalScript.inst.gameState.allcountries[1].econ = true;
					GlobalScript.inst.gameState.allcountries[1].soc_stab = 1000;
					for (int num26 = 7; num26 < GlobalScript.inst.gameState.allcountries.Length; num26++)
					{
						if ((num26 < 53 || num26 > 103) && num26 != 52 && num26 != 35 && num26 != 40 && num26 != 30 && num26 != 14 && num26 != 13 && num26 != 36 && num26 != 16 && num26 != 3 && num26 != 5 && num26 != 15 && num26 != 27 && num26 != 106 && num26 != 107 && num26 != 108 && GlobalScript.inst.gameState.allcountries[num26].proprc && !GlobalScript.inst.gameState.allcountries[num26].Vyshi && !GlobalScript.inst.gameState.allcountries[num26].prosov)
						{
							GlobalScript.inst.gameState.allcountries[num26].soc_stab = 1000;
							text = text + ", " + GlobalScript.inst.gameState.allcountries[num26].name;
							GlobalScript.inst.gameState.allcountries[num26].econ = true;
						}
					}
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic67 in politics)
					{
						if (politic67.traits[0] == 0)
						{
							Politic politic = politic67;
							politic.loyality += 100;
						}
						else if (politic67.traits[0] == 1)
						{
							Politic politic = politic67;
							politic.loyality += 100;
						}
						else if (politic67.traits[0] == 2)
						{
							Politic politic = politic67;
							politic.loyality += 100;
						}
						else if (politic67.traits[0] == 3)
						{
							Politic politic = politic67;
							politic.loyality += 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "延续“重置同苏联关系”的路线，中国申请加入互助经济委员会（C\nMEA）。按设想，这一举措应当恢复并扩大在“苏中分裂”期间被\n切断的中华人民共和国与社会主义国家之间的经济联系。\n为此，CMEA召开了特别会议，结果中国以正式成员身份被接纳为\n该组织的成员。最激进的党内分子“怀着敌意迈出了这一步”，\n称之为“纵容苏联修正主义”，但如今我们同苏联的关系比以往任何\n时候都更好。至于美国就不能这么说了——他们对我国外交政策向新\n方向转变显然不满。然而，如今社会主义阵营比以往任何时候都更强\n大。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 200;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 200;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 30;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.allcountries[1].stab = 1;
					GlobalScript.inst.gameState.allcountries[1].isSEV = true;
					if (GlobalScript.inst.gameState.data[60] == 0)
					{
						GlobalScript.inst.gameState.allcountries[20].proprc = false;
						GlobalScript.inst.gameState.allcountries[20].econ = false;
						GlobalScript.inst.gameState.allcountries[20].Torg = false;
						GlobalScript.inst.gameState.allcountries[20].okb = false;
					}
					GlobalScript.inst.gameState.allcountries[52].proprc = false;
					GlobalScript.inst.gameState.allcountries[52].econ = false;
					GlobalScript.inst.gameState.allcountries[52].okb = false;
					Country[] allcountries = GlobalScript.inst.gameState.allcountries;
					foreach (Country country in allcountries)
					{
						if (country.econ && (country.prosov || country.sovalliance || country.proprc || country.Gosstroy == 1 || (country.Gosstroy == 2 && !country.usalliance && !country.Vyshi)))
						{
							country.econ = false;
							country.isSEV = true;
						}
						else
						{
							country.econ = false;
						}
					}
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic68 in politics)
					{
						if (politic68.traits[0] == 2)
						{
							Politic politic = politic68;
							politic.loyality -= 200;
						}
						else if (politic68.traits[0] == 3)
						{
							Politic politic = politic68;
							politic.loyality -= 200;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "中国政府申请加入“不结盟运动”，毫无疑问，\n中国在多数票表决中被接纳进入该组织。\n现在，如果我们想用军事手段解决任何冲突，\n就会遭到谴责并被逐出该组织。\n战略中立将使我们在苏联与美国之间周旋，\n从两大超级强权那里获得种种优惠——不过这对我们只有好处。";
					GlobalScript.inst.gameState.data[1] -= 300;
					GlobalScript.inst.gameState.data[8] -= 20;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.allcountries[15].cw = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "中国政府申请加入“东南亚国家联盟”（ASEAN），\n并在毫无争议的情况下以多数票接纳中国进入该组织。\n中国加入ASEAN应当有助于改善中国同邻国以及西方阵营的关系。\n由于有一个并不完全属于东南亚的国家加入，\n联盟名称中又增加了新的缩写“亚洲国家联盟”（AAN）。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 350;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 350;
					GlobalScript.inst.gameState.allcountries[1].JoinASEAN();
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 60)
			{
				text2 = "军事联盟";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "今天在上海签署了关于成立集体安全联盟（CRA）\n的协议。该军事—政治组织将中国的所有盟国统一为一个单一军事集\n团。集体安全联盟（CSA）的目的，是建立针对其他军事联盟——\n华沙条约组织与北约（NATO）——的共同集体防护体系。\n新成立组织的成员包括中华人民共和国";
					GlobalScript.inst.gameState.data[1] += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 200;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 200;
					GlobalScript.inst.gameState.data[3] += 80;
					GlobalScript.inst.gameState.data[8] -= 50;
					GlobalScript.inst.gameState.data[9] -= 100;
					GlobalScript.inst.gameState.data[22] -= 300;
					GlobalScript.inst.gameState.allcountries[15].cw = false;
					GlobalScript.inst.gameState.allcountries[1].okb = true;
					for (int num27 = 7; num27 < GlobalScript.inst.gameState.allcountries.Length; num27++)
					{
						if ((!GlobalScript.inst.gameState.allcountries[num27].proprc && !GlobalScript.inst.gameState.allcountries[num27].econ) || num27 == 52 || num27 == 30)
						{
							continue;
						}
						switch (num27)
						{
						case 3:
						case 5:
						case 13:
						case 14:
						case 15:
						case 16:
						case 27:
						case 30:
						case 35:
						case 36:
						case 40:
						case 45:
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
						case 69:
						case 70:
						case 71:
						case 72:
						case 73:
						case 74:
						case 75:
						case 76:
						case 77:
						case 78:
						case 79:
						case 80:
						case 81:
						case 82:
						case 83:
						case 84:
						case 85:
						case 86:
						case 87:
						case 88:
						case 89:
						case 90:
						case 91:
						case 92:
						case 93:
						case 94:
						case 95:
						case 96:
						case 97:
						case 98:
						case 99:
						case 100:
						case 101:
						case 102:
						case 103:
						case 106:
						case 107:
						case 108:
							continue;
						}
						if (!GlobalScript.inst.gameState.allcountries[num27].Vyshi && !GlobalScript.inst.gameState.allcountries[num27].prosov)
						{
							if (GlobalScript.inst.gameState.allcountries[num27].soc_stab <= 0)
							{
								GlobalScript.inst.gameState.allcountries[num27].soc_stab = 1000;
							}
							text = text + ", " + GlobalScript.inst.gameState.allcountries[num27].name;
							GlobalScript.inst.gameState.allcountries[num27].okb = true;
							if (GlobalScript.inst.gameState.allcountries[num27].isSEV)
							{
								GlobalScript.inst.gameState.allcountries[num27].isSEV = false;
								GlobalScript.inst.gameState.allcountries[num27].econ = true;
							}
						}
					}
					text += "。苏联与美国对中国影响力的扩张作出消极反应，\n称这个新集团是“国际紧张局势缓和的障碍”，\n是“和平共处的破坏者”。\n与此同时，党和人民则满怀热情与敬佩地看待中华人民共和国威望的\n提升。看来国际舞台上出现了第三股力量——希望这只是往好的方向\n发展。";
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic69 in politics)
					{
						if (politic69.traits[0] == 0)
						{
							Politic politic = politic69;
							politic.loyality += 100;
						}
						else if (politic69.traits[0] == 1)
						{
							Politic politic = politic69;
							politic.loyality += 100;
						}
						else if (politic69.traits[0] == 2)
						{
							Politic politic = politic69;
							politic.loyality += 100;
						}
						else if (politic69.traits[0] == 3)
						{
							Politic politic = politic69;
							politic.loyality += 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "中国继续不参加军事联盟。世界和平——至上。";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 61)
			{
				text2 = "国歌问题";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "全国人大常委会关于恢复《义勇军进行曲》的决议通过广播宣读，\n作为中华人民共和国的国歌。\n同时通过了规范国歌使用的法律（每天广播电视开播时奏响国歌，\n中华人民共和国国旗在国歌声中升起，全国人大会议和中共代表大会\n开始工作等）。党很满意，人民也一样。";
					GlobalScript.inst.gameState.data[8] -= 10;
					GlobalScript.inst.gameState.data[3] += 20;
					GlobalScript.inst.gameState.data[1] += 70;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic70 in politics)
					{
						if (politic70.traits[0] == 1)
						{
							Politic politic = politic70;
							politic.power += 50;
						}
						else if (politic70.traits[0] == 2)
						{
							Politic politic = politic70;
							politic.power += 50;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "今天，“北京广播电台”（Radio Peking）\n像10年前那样，以歌曲《东方红》开播；\n随后宣读了全国人大常委会关于将其批准为中华人民共和国国歌的决\n议。总体上，人民很高兴，但党内成员对这一决定却表示不理解，\n指责我们犯了“极左偏差”，并“试图悄悄重新评价文化大革命”。\n苏联和美国也不高兴，只是选择不表态。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[6] += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GlobalScript.inst.gameState.data[3] += 40;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic71 in politics)
					{
						if (politic71.traits[0] == 0)
						{
							Politic politic = politic71;
							politic.power += 50;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "今天，“北京广播电台”（Radio Peking）\n的播音以《义勇军进行曲》开头，但歌词做了修改，\n加入了“伟大的共产党”“共产主义的明天”以及“毛泽东旗帜”。\n在这一版本上，它被批准为中华人民共和国国歌。\n此举在党内引起了一些不满，尽管总体上人民接受了新词。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[6] += 5;
					GlobalScript.inst.gameState.data[8] -= 10;
					GlobalScript.inst.gameState.data[3] += 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 62)
			{
				text2 = "成吉思汗的继承者们的问题";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "今天，全国人大常委会与中共中央联合作出决定：\n1969年移交给中华人民共和国邻省的内蒙古全部地区，\n全部归还。对蒙古人的同化政策也随之停止，\n保证保护其民族文化、传统生活方式与民族经济。\n成吉思汗陵、王昭君墓、乌丹寺以及五塔寺重新对外开放参观，\n传统那达慕节日得以恢复，蒙古文报纸《内蒙古之报》（Namen\ngu zhibao）开始出版发行。\n此举在自治区内受到热烈欢迎，并得到蒙古人民共和国的支持；\n在其背后，还有苏联的认可——他们批准了我们民族政策的调整。\n只是，党内左翼的看法大不相同，我们的预算也被迫承担额外开支。";
					GlobalScript.inst.gameState.data[1] -= 80;
					GlobalScript.inst.gameState.data[57] += 50;
					GlobalScript.inst.gameState.data[4] += 20;
					GlobalScript.inst.gameState.data[3] += 60;
					GlobalScript.inst.gameState.data[6] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 30;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GlobalScript.inst.gameState.data[92] += 10;
					GlobalScript.inst.gameState.data[8] -= 30;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "中央当局对内蒙古问题毫无兴趣。\n自治区内蒙古人的同化仍在继续，越来越多的中国移民涌入自治地区，\n他们很快就会成为该地区人口的多数。\n局势正在恶化，具有蒙古族背景的异议分子正积极试图引起美国与苏\n联的注意。";
					GlobalScript.inst.gameState.data[1] -= 20;
					GlobalScript.inst.gameState.data[57] -= 150;
					GlobalScript.inst.gameState.data[3] -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "经过长时间犹豫，作出一个“半决定”：\n把1969年挑选出来的地区归还内蒙古，\n但民族政策不作改变。\n总体上，这一决定得到了中性回应，尽管它在民族主义党内成员中引\n起了一些不满；同时，蒙古人民共和国也指责我们“对蒙古族人口实\n施种族灭绝”，并试图引起苏联的注意……";
					GlobalScript.inst.gameState.data[1] += 10;
					GlobalScript.inst.gameState.data[57] += 10;
					GlobalScript.inst.gameState.data[4] += 30;
					GlobalScript.inst.gameState.data[3] += 20;
					GlobalScript.inst.gameState.data[6] -= 5;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "经过长时间犹豫，作出一个“半决定”：\n停止对自治区蒙古族人口的同化政策，但不把1969年被夺走的地\n区重新纳入其版图。成吉思汗陵、王昭君墓、\n乌丹寺以及五塔寺重新对外开放参观，传统那达慕节日得以恢复，\n蒙古文报纸《内蒙古之报》（Namengu zhibao）\n开始出版发行。此决定受到赞同欢迎，尽管我们的预算不得不承担额\n外开支。";
					GlobalScript.inst.gameState.data[1] += 30;
					GlobalScript.inst.gameState.data[8] -= 10;
					GlobalScript.inst.gameState.data[3] += 30;
					GlobalScript.inst.gameState.data[6] -= 5;
					GlobalScript.inst.gameState.data[57] += 30;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "主席" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "在被揭露的内蒙古真实情况震惊之后，决定更深入地研究民族问题，\n并亲自走访全部3个小型自治区——内蒙古、\n广西壮族自治区与宁夏回族自治区。\n经过与这些地区的党和苏维埃领导层进行一系列会谈，\n以及与少数民族代表（蒙古族、壮族与回族）\n交流后，同志主席带着深思回到北京，进而通过了《中华人民共和国\n民族政策纲要》，以取代1952年《在中华人民共和国实行区域民\n族自治的基本原则》中带有民族主义性质的内容。\n根据《纲要》，自治区获得更广泛的权利；\n国家承诺保护少数民族的民族文化、传统生活方式与民族经济，\n增加少数民族语言的文献与出版发行量，\n并在所有机关与高校为少数民族分配名额。\n另一个重要决定也作出——不仅苏维埃当局，\n连中共的地区自治委员会也应由少数民族代表担任负责人。\n所有这些，使你得以赢得民族精英的真诚支持（希望他们在发生什么\n事时不会忘记这一姿态），也获得苏联与美国的认可——但同时也激\n怒了保守派党内成员……";
					GlobalScript.inst.gameState.data[1] -= 150;
					GlobalScript.inst.gameState.data[8] -= 60;
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[6] -= 20;
					GlobalScript.inst.gameState.data[57] -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 80;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 150;
					GlobalScript.inst.gameState.data[92] += 30;
					GlobalScript.inst.gameState.data[18]++;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 73)
			{
				text2 = "伊朗—伊拉克战争";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "战争正在升级，看来伊朗并不打算轻易认输。\n美国和苏联都口头呼吁和平，但实际上两者都在支持伊拉克，\n因为伊斯兰伊朗对双方都不方便。";
					GlobalScript.inst.gameState.ingamewars[3].name_war = "伊朗—伊拉克战争";
					GlobalScript.inst.gameState.ingamewars[3].is_going = true;
					GlobalScript.inst.gameState.ingamewars[3].side1 = "Iraq";
					GlobalScript.inst.gameState.ingamewars[3].side2 = "Iran";
					GlobalScript.inst.gameState.ingamewars[3].ussr_place = 0;
					GlobalScript.inst.gameState.ingamewars[3].usa_place = 0;
					GlobalScript.inst.gameState.ingamewars[3].infl1 = 500;
					GlobalScript.inst.gameState.ingamewars[3].infl2 = 500;
					GlobalScript.inst.gameState.data[143] += 6;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 64)
			{
				text2 = "泛阿拉伯主义";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "什么也没发生。阿拉伯国家仍相对分裂，\n这反而给亲美的以色列带来优势。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏情报部门的介入，反对联盟的多数势力很快偃旗息鼓；\n而我们愿意在阿拉伯国家统一问题上居中调停，\n并为发展共同国家形态提供无偿援助，最终促成了谈判协议。\n8月，埃及、利比亚与叙利亚在开罗举行了一次具有历史意义的会议；\n会后决定组建一个邦联制的阿拉伯联合共和国，\n实行共同货币与军队，共同解决外交政策问题，\n并为进一步的经济与政治一体化铺路。\n新国家宣称忠于阿拉伯社会主义原则，强调继续建立全体阿拉伯人的\n单一国家的必要性，这令以色列兴奋不已——以色列随即向美国请求\n追加军事援助。苏联欢迎阿联（UAR）\n的成立，但美国对中东出现这样一个强有力、\n足以挑战其霸权的对手却并不满意。";
					GlobalScript.inst.gameState.data[8] -= 70;
					GlobalScript.inst.gameState.data[9] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 80;
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.data[57] -= 30;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 70;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[143] += 5;
					GlobalScript.inst.gameState.allcountries[30].oar = true;
					GlobalScript.inst.gameState.OAR = true;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					party_change[2] = 0.24f;
					party_change[3] = 0.24f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic72 in politics)
					{
						if (politic72.traits[0] == 1)
						{
							Politic politic = politic72;
							politic.power += 120;
							politic = politic72;
							politic.loyality += 100;
						}
						else if (politic72.traits[0] == 2)
						{
							Politic politic = politic72;
							politic.power += 120;
							politic = politic72;
							politic.loyality += 100;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 65)
			{
				text2 = "再见了，我们亲爱的米什卡……";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "他拒绝了抵制莫斯科奥运会的提议，称之为“美国的挑衅”。\n他亲自给列昂尼德·伊里奇·勃列日涅夫打电话，\n说“中方绝不会参加美国的抵制，并将派出代表队赴莫斯科”，\n同时还祝苏联运动员好运。\n被感动的苏联领导人则表示希望能亲自会见同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "在开幕式上会面，并祝中国代表队取得成功。\n最终，63个国家宣布抵制——美国及其卫星国，\n队伍包括 ";
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						text += "Iran, ";
					}
					text += "莫桑比克和卡塔尔拒绝参加比赛，而英国、\n法国、意大利和西班牙等国政府则被授权由各自的奥委会决定是否派\n运动员赴莫斯科（毕竟他们也派了队伍）。\n开幕式上，国际奥委会主席迈克尔·莫里斯在把发言权交给列昂尼\n德·勃列日涅夫之前，特别感谢那些在抵制情况下仍自发前来参赛的\n运动员。中国代表队获得第3名，输给苏联和德意志民主共和国，\n赢得35枚金牌、30枚银牌和38枚铜牌，\n并创造了数项纪录。这届奥运会载入史册，\n因其闭幕式组织得最得当、最令人难忘——当比赛的吉祥物米什卡飞\n向阿·帕赫穆托娃和N·多布罗涅拉沃夫演唱的《再见吧，\n莫斯科！》时，许多人（甚至外国人）都忍不住落泪——太有力量、\n太有氛围了。闭幕式上，升起的不是将举办下一届奥运会的美国国旗，\n而是洛杉矶市旗，这暗示苏联将撤回这次抵制……";
					GlobalScript.inst.gameState.data[1] += 150;
					GlobalScript.inst.gameState.data[3] += 80;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 20;
					GlobalScript.inst.gameState.data[6] -= 20;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 250;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[8] -= 40;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "当苏联和美国在国际奥委会里互相威胁、\n互相抱怨时，中国——出乎所有人意料——干脆两届奥运会都置之不\n理。面对国际奥委会对中国运动员为何缺席莫斯科而感到完全困惑，\n华国锋和中华人民共和国奥委会负责人钟世桐以中国财政困难为由，\n表示这使我们无法参加比赛。\n看来我们在那里的解释引起了强烈怀疑，\n但我们还是收到了一纸正式警告——抵制洛杉矶的比赛将自动剥夺我\n们在国际奥委会的成员资格。\n群众也不明白，为什么国家领导层没有回应这些比赛。\n最终，63个国家宣布抵制——美国及其卫星国，\n队伍包括 ";
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						text += "Iran, ";
					}
					text += "莫桑比克和卡塔尔拒绝参加比赛，而英国、\n法国、意大利和西班牙等国政府则被授权由各自的奥委会决定是否派\n运动员赴莫斯科（毕竟他们也派了队伍）。\n开幕式上，国际奥委会主席迈克尔·莫里斯在把发言权交给列昂尼\n德·勃列日涅夫之前，特别感谢那些在抵制情况下仍自发前来参赛的\n运动员。这届奥运会载入史册，因其闭幕式组织得最得当、\n最令人难忘——当比赛的吉祥物米什卡飞向阿·帕赫穆托娃和N·多\n布罗涅拉沃夫演唱的《再见吧，莫斯科！\n》时，许多人（甚至外国人）都忍不住落泪——太有力量、\n太有氛围了。闭幕式上，升起的不是将举办下一届奥运会的美国国旗，\n而是洛杉矶市旗，这暗示苏联将撤回这次抵制……";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[3] -= 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 150;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "中国加入了美国对莫斯科奥运会的抵制，\n虽然并非没有犹豫——中国奥委会刚刚在国际奥委会完成注册，\n如今就完全不宜去破坏同它的关系。\n因此，华国锋让钟世桐自行决定是否派队赴莫斯科。\n他在与国际奥委会以及美国、意大利、法国、\n西班牙和英国奥委会等方面磋商后，批准以国际奥委会的名义派遣中\n国代表队赴莫斯科。最终，63个国家宣布抵制——美国及其卫星国，\n队伍包括 ";
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						text += "Iran, ";
					}
					text += "莫桑比克和卡塔尔拒绝参加比赛，而英国、\n法国、意大利和西班牙等国政府则被授权由各自的奥委会决定是否派\n运动员赴莫斯科（毕竟他们也派了队伍）。\n开幕式上，国际奥委会主席迈克尔·莫里斯在把发言权交给列昂尼\n德·勃列日涅夫之前，特别感谢那些在抵制情况下仍自发前来参赛的\n运动员。这届奥运会载入史册，因其闭幕式组织得最得当、\n最令人难忘——当比赛的吉祥物米什卡飞向阿·帕赫穆托娃和N·多\n布罗涅拉沃夫演唱的《再见吧，莫斯科！\n》时，许多人（甚至外国人）都忍不住落泪——太有力量、\n太有氛围了。闭幕式上，升起的不是将举办下一届奥运会的美国国旗，\n而是洛杉矶市旗，这暗示苏联将撤回这次抵制……\n | 我们也派出了队伍参加费城的“替代奥运会”，\n在那里获得了5枚金牌、1枚银牌和4枚铜牌。";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[3] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 80;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.data[8] -= 40;
					GlobalScript.inst.gameState.data[4] += 60;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "中国加入了美国对莫斯科奥运会的抵制，\n虽然并非没有犹豫——中国奥委会刚刚在国际奥委会完成注册，\n如今就完全不宜去破坏同它的关系。\n然而，华国锋决定派中国代表队赴费城参加美国的“替代”赛事“自\n由钟”。不同意这一决定的中华人民共和国奥委会负责人钟世桐被开\n除出中共并撤职，改由更忠诚的李梦华接替。\n我们的队伍获得第3名，输给美国和德国，\n拿到5枚金牌、1枚银牌和4枚铜牌。\n最终，63个国家宣布抵制——美国及其卫星国，\n队伍包括 ";
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						text += "Iran, ";
					}
					text += "莫桑比克和卡塔尔拒绝参加比赛，而英国、\n法国、意大利和西班牙等国政府则被授权由各自的奥委会决定是否派\n运动员赴莫斯科（毕竟他们也派了队伍）。\n开幕式上，国际奥委会主席迈克尔·莫里斯在把发言权交给列昂尼\n德·勃列日涅夫之前，特别感谢那些在抵制情况下仍自发前来参赛的\n运动员。这届奥运会载入史册，因其闭幕式组织得最得当、\n最令人难忘——当比赛的吉祥物米什卡飞向阿·帕赫穆托娃和N·多\n布罗涅拉沃夫演唱的《再见吧，莫斯科！\n》时，许多人（甚至外国人）都忍不住落泪——太有力量、\n太有氛围了。闭幕式上，升起的不是将举办下一届奥运会的美国国旗，\n而是洛杉矶市旗，这暗示苏联将撤回这次抵制……";
					GlobalScript.inst.gameState.data[1] += 70;
					GlobalScript.inst.gameState.data[3] += 30;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 200;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 200;
					GlobalScript.inst.gameState.data[4] += 60;
					GlobalScript.inst.gameState.data[8] -= 30;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "党的成员们的想法得到了华国锋和中华人民共和国奥委会负责人钟世\n桐的支持。我们决定重办“新兴力量运动会”。\n全国人大常委会决定于11月在宁波市举办，\n并向“第二世界”和“第三世界”的国家发出邀请。";
					if (GlobalScript.inst.gameState.data[6] >= 85)
					{
						text += "不幸的是，只有16个实行军政府或准军事政权的非洲国家同意参加。\n当然，我们的队伍将夺得第一名——但会完全没意思！";
					}
					else if (GlobalScript.inst.gameState.data[6] >= 65 && GlobalScript.inst.gameState.data[6] < 85)
					{
						text += "几乎不结盟运动的所有国家（包括南斯拉夫）\n都同意参加。比赛看起来会既有趣又紧张……";
					}
					else if (GlobalScript.inst.gameState.data[6] < 65)
					{
						text += "令我们大为惊讶的是，我们发出邀请的所有国家都同意参加新的运动\n会——而且，苏联和美国的奥委会还与中华人民共和国奥委会取得联\n系，表示愿意让他们的运动员参赛（当然不是最高层级，\n但也算……）。比赛将非常紧张，我们的运动员应该开始训练了……";
					}
					text += "最终，63个国家宣布抵制——美国及其卫星国，队伍包括 ";
					if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
					{
						text += "Iran, ";
					}
					text += "莫桑比克和卡塔尔拒绝参加比赛，而英国、\n法国、意大利和西班牙等国政府则被授权由各自的奥委会决定是否派\n运动员赴莫斯科（毕竟他们也派了队伍）。\n开幕式上，国际奥委会主席迈克尔·莫里斯在把发言权交给列昂尼\n德·勃列日涅夫之前，特别感谢那些在抵制情况下仍自发前来参赛的\n运动员。这届奥运会载入史册，因其闭幕式组织得最得当、\n最令人难忘——当比赛的吉祥物米什卡飞向阿·帕赫穆托娃和N·多\n布罗涅拉沃夫演唱的《再见吧，莫斯科！\n》时，许多人（甚至外国人）都忍不住落泪——太有力量、\n太有氛围了。闭幕式上，升起的不是将举办下一届奥运会的美国国旗，\n而是洛杉矶市旗，这暗示苏联将撤回这次抵制……";
					GlobalScript.inst.gameState.data[1] += 200;
					GlobalScript.inst.gameState.data[3] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[8] -= 200;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 66)
			{
				text2 = "而后是铁托——铁托！";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "发来一封信，向南斯拉夫社会主义联邦共和国（SFRY）\n主席团、南斯拉夫共产党（LCY）中央委员会以及南斯拉夫全体人\n民，因国家元首、铁托元帅的逝世表示深切哀悼，\n并表示希望恢复“友好关系、经济与文化关系”。\n这封信刊登在《Borba》报上。\n七天哀悼结束后，我们收到了SFRY主席团的正式答复，\n信中对我们的慰问表示感谢。\n然而，这并未改变中南关系的状况。";
					GlobalScript.inst.gameState.data[6] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 20;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "5月7日，200多支外国代表团抵达SFRY议会，\n向铁托元帅告别。5月8日上午8时，追悼活动结束。\n5月8日12时，在由SFRY主席团成员以及LCY中央委员会主\n席团成员组成的仪仗队之后，南斯拉夫人民军（YNA）\n的8名海军上将和将军抬着装有约瑟普·布罗兹·铁托遗体的灵柩前\n行。LCY中央委员会主席斯捷潘·多龙斯基发表了纪念铁托的讲话，\n随后队伍沿着米洛什亲王街和十月革命大道前往25五月博物馆。\n最后一场讲话由SFRY主席团主席拉扎尔·科利舍夫斯基在“鲜花\n之家”以及为外国政要准备的看台前作出。\n下午3点后，在《国际歌》的旋律中，灵柩被移入“鲜花之家”，\n从此约瑟普·布罗兹·铁托将安息于此。\n | 中华人民共和国代表团由 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "和季鹏飞与南斯拉夫新领导层举行会谈，\n期间就恢复外交、经济和文化关系达成协议。\n预计半年后拉扎尔·科利舍夫斯基将回访北京。\n然而，党内已经找到了对我们改善同SFRY关系政策不满的人，\n有人甚至已经把这位同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "比作赫鲁晓夫……";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[6] -= 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.allcountries[15].Torg = true;
					if (GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						text += "但正如预料的那样，阿尔巴尼亚领导层立刻指责我们“修正主义”，\n并与中华人民共和国断绝外交关系，把我们所有顾问赶出该国，\n同时拒绝偿还我们借给他们的贷款。\n什么样的人……？";
						GlobalScript.inst.gameState.allcountries[20].Torg = false;
						GlobalScript.inst.gameState.allcountries[20].proprc = false;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "5月7日，200多支外国代表团抵达SFRY议会，\n向铁托元帅告别。5月8日上午8时，追悼活动结束。\n5月8日12时，在由SFRY主席团成员以及LCY中央委员会主\n席团成员组成的仪仗队之后，南斯拉夫人民军（YNA）\n的8名海军上将和将军抬着装有约瑟普·布罗兹·铁托遗体的灵柩前\n行。LCY中央委员会主席斯捷潘·多龙斯基发表了纪念铁托的讲话，\n随后队伍沿着米洛什亲王街和十月革命大道前往25五月博物馆。\n最后一场讲话由SFRY主席团主席拉扎尔·科利舍夫斯基在“鲜花\n之家”以及为外国政要准备的看台前作出。\n下午3点后，在《国际歌》的旋律中，灵柩被移入“鲜花之家”，\n从此约瑟普·布罗兹·铁托将安息于此。\n南斯拉夫新领导层对恢复同中华人民共和国的关系表现出兴趣，\n但季鹏飞同志以权限不足为由拒绝进行任何谈判。\n“也许以后某一天……\n但不是现在”，他对拉扎尔·科利舍夫斯基说。\n然而，党内有人对我们的代表团从贝尔格莱德空手而归感到不满……";
					GlobalScript.inst.gameState.data[1] -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 30;
					GlobalScript.inst.gameState.data[6] -= 15;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 30;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "中国领导层对铁托的逝世没有作出回应，\n甚至连慰问都没有表示。\n这不仅在南斯拉夫引起震惊，也在全世界引起震动。\n针对塔纽格通讯社询问此事原因，同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "答道：“无可奉告……”";
					GlobalScript.inst.gameState.data[6] += 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 67)
			{
				text2 = "波兰还没死呢？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "中国领导层对波兰的事态没有回应，除了一篇《人民日报》和《红旗\n》杂志的联合社论，呼吁交战双方“为波兰社会主义和人民民主的未\n来找到一个折中解决方案”。\n这一立场得到了苏联和波兰本身的认可。\n | 在这种情况下，军队承担了国家命运的全部责任。\n国防部长、波兰人民共和国（NDP）总参将雅鲁泽尔斯基将军争取\n到苏联的支持，并保证苏联不会进行军事干预，\n于1981年12月13日成立“民族拯救军事委员会”，\n并宣布在NDP全境实行戒严。\n波兰军队、安全委员会以及ZOMO（民兵的特种部队）\n的果断行动，连同“团结”这一全部资产和波兰统一工人党（PUW\nP）领导层都被拘押，国家秩序或多或少得以恢复。\n雅鲁泽尔斯基宣布“新的社会主义路线”，\n并开始按匈牙利模式进行经济改革。\n然而，关键问题并未解决，日后必将显现出来……";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.allcountries[2].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 10;
					GlobalScript.inst.gameState.allcountries[2].Torg = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们认识到，在当前局势下，只有波兰军队才能在某种程度上左右局\n势、阻止迫在眉睫的反革命。\n因此，我们联系了由波兰国防部长雅鲁泽尔斯基将军领导的指挥部。\n事实证明，我们并不是唯一要求他恢复秩序的人——苏联也施加了压\n力，但雅鲁泽尔斯基仍犹豫不决。\n最终，他作出了决定——但明确要求苏联和中华人民共和国不要介入\n这一进程。得到我们的保证后，1980年12月13日，\n波兰将军们成立“民族拯救军事委员会”，\n并在波兰全境实行戒严。\n波兰军队、安全委员会和ZOMO（民兵特种部队）\n的果断行动，使“团结”这一全部力量以及波兰统一工人党（PUW\nP）领导层都被关押，国家秩序或多或少得以恢复。\n国家一切权力转交给武装力量最高委员会，\n这立刻引发了“建立军事独裁”的指责，\n美国也已经呼吁对“雅鲁泽尔斯基的苏联军事集团”进行斗争。\n中华人民共和国和苏联还向NDP提供了大额无息贷款，\n用于偿还国债。看来局势正在好转，而波兰的例子也给我们党上了一\n课……";
					GlobalScript.inst.gameState.data[1] += 200;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GlobalScript.inst.gameState.data[8] -= 200;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[4] -= 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GlobalScript.inst.gameState.allcountries[2].Gosstroy = 0;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 150;
					GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "国家安全部（MSS）特工通过卡齐米日·米贾尔的地下共产党，\n接触到波兰统一工人党（PUWP）中“混凝土派”的头目阿尔宾·\n西瓦克。他憎恨“团结”，并多次要求对其动用武器。\n凭借他在民族天主教团体“PAX”和右翼民族主义社团“格伦瓦尔\n德”的关系，西瓦克很快就促成了他们同意与“混凝土派”和CPP\n结成联盟。12月2日，在PUWP中央委员会与国务委员会的联合\n会议上，前国家元首爱德华·吉莱克被撤职。\n但就在此后不久，西瓦克同志就要求立即召开议会（Sejm），\n并在全国宣布戒严。\n国务委员会试图抵抗，但随后ORMO武装人员闯入会议室。\n两个月内，国内出现了“微型内战”的事实局面；\n但波兰安全力量支持了政变，从而确保了联盟的胜利。\nPUWP被解散，CPP被合法化，“团结”几乎被摧毁，\n其右翼进入“民族统一阵线”。\n波兰新领导层已经宣布实行“带有波兰民族特征的社会主义”的路线，\n并表示要与我们更靠近。\n苏联十分恼怒，但在波兰领导人表示“波兰无论如何都不打算退出华\n沙条约和经互会，并赞成按照睦邻友好与合作的方针发展苏波关系”\n之后，才稍稍冷静下来，并在事实上承认了变化。";
					GlobalScript.inst.gameState.data[1] += 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 30;
					GlobalScript.inst.gameState.data[8] -= 300;
					GlobalScript.inst.gameState.data[9] -= 150;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 30;
					GlobalScript.inst.gameState.data[6] += 100;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 200;
					GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 0;
					GlobalScript.inst.gameState.allcountries[2].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[2].prosov = false;
					GlobalScript.inst.gameState.allcountries[2].Torg = true;
					GlobalScript.inst.gameState.allcountries[2].proprc = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "吉莱克辞职的消息给你留下了非常负面的印象。\n23点时，你召见苏联大使，并要求他亲自向列昂尼德·伊里奇·勃\n列日涅夫同志转达如下内容：“在这一时刻，\n检验波兰社会主义命运的责任性考验，检验中共以及盟国兄弟党、\n所有社会主义国家，不能采取旁观者的立场。\n波兰发生的事情不仅是波兰人的内部事务。\n今天夜里，我们将向华沙条约国家的所有领导人发出紧急呼吁，\n要求他们采取有力的共同军事行动，以防止波兰社会主义的崩溃。\n中华人民共和国和中共的领导层相信，社会主义波兰仍然可以被挽救。\n为了社会主义事业，必须、也能够阻止帝国主义。\n”";
					if (GlobalScript.inst.gameState.empires[1].relations >= 800)
					{
						text = "我们的呼吁得到了德意志民主共和国（GDR）\n领导层、捷克斯洛伐克领导层的支持，随后也得到了苏联领导层的支\n持。军事入侵计划由苏联最高苏维埃总参谋长、\n元帅N.V.奥加尔科夫传达给波兰副总参谋长、\n将军T.胡帕洛夫斯基。\n该计划规定将苏联、东德和捷克斯洛伐克部队引入波兰境内。\n波兰军队则留在军营中。\n入侵兵力由15个苏联师、2个德国师和1个捷克斯洛伐克师组成。\n对路线和部队集结地域进行了侦察，其中波兰方面代表积极参与。\n行动包括：来自捷克斯洛伐克人民军——西部军区司令部和两个集团\n军司令部；来自GDR国家人民军——两个集团军司令部；\n来自苏联军队——国家民航司令部、其两个集团军司令部以及北方兵\n团司令部。 |1980年12月9日，\n苏联武装力量北方兵团的部队，联合GDR国家人民军和捷克斯洛伐\n克人民军的部队进入波兰境内，并迅速向该国的要害城市推进。\n波兰军队的一部分没有进行任何抵抗。\n“团结”转入地下，PUWP领导层被逮捕并押往苏联。\n由雅鲁泽尔斯基将军领导的波兰人民共和国（PPR）\n新领导层宣布实行“新的社会主义路线”，\n即在苏联部队监督下，在马克思主义框架内进行改革。\n美国则陷入疯狂，正大肆指责苏联和我们在波兰建立军事独裁。\n”";
						GlobalScript.inst.gameState.data[1] += 100;
						GlobalScript.inst.gameState.data[22] -= 50;
						GlobalScript.inst.gameState.data[9] -= 50;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						GlobalScript.inst.gameState.data[6] += 200;
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.power -= 10;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 150;
						empire = GlobalScript.inst.gameState.empires[1];
						empire.relations += 150;
						GlobalScript.inst.gameState.data[112]++;
					}
					else
					{
						text = "不幸的是，苏联领导层，随后是华沙条约其他国家的领导层，\n并未决定动用部队来恢复秩序，而是支持波兰军方，\n并批准其自行采取行动。\nNDP国防部长雅鲁泽尔斯基将军成立“民族拯救军事委员会”，\n并于1981年12月13日宣布在NDP全境实行戒严。\n波兰军队、安全委员会和ZOMO（民兵特种部队）\n的果断行动，使“团结”这一全部力量以及PUWP领导层都被拘押，\n国家秩序或多或少得以恢复。\n雅鲁泽尔斯基宣布“新的社会主义路线”，\n并开始按匈牙利模式进行经济改革。\n然而，关键问题并未解决，日后必将显现出来……";
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						GlobalScript.inst.gameState.data[6] += 200;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 20;
						GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 1;
						GlobalScript.inst.gameState.allcountries[2].Gosstroy = 0;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					if (GlobalScript.inst.gameState.empires[0].relations >= 80 && GlobalScript.inst.gameState.allcountries[51].stab == 1)
					{
						text = "我们与中央情报局（CIA）取得联系，\n并就联合行动达成协议。\n但局势出现了意外转折——在骚乱加剧的背景下，\n斯坦尼斯瓦夫·卡尼亚在与军队指挥部秘密磋商后，\n竟然意外宣布辞去所有职务。\nPUWP中央委员会第一书记由改革派支持者、\n与波兰国防部长雅鲁泽尔斯基将军关系密切的米耶奇斯瓦夫·拉科夫\n斯基担任。拉科夫斯基凭借其在“团结”中的关系与瓦文萨取得联系，\n并提出对双方都有利的折中方案——“团结”被正式合法化，\n但拒绝争夺政权，转而进入议会；它将在新政府中获得若干内阁席位，\n并参与起草一揽子改革。\n他同意了。拉科夫斯基宣布“新的社会主义路线”理念，\n意味着将效仿匈牙利和南斯拉夫进行非常广泛的改革。\n“团结”领导层支持这些改革，并宣布停止示威和罢工。\n局势正在慢慢走向正常，尽管苏联对这种意外“出局”反应极为强烈\n地怀疑；而如果拉科夫斯基在改革过程中失去对局势的控制，\n那么波兰将迎来它的1968年……";
						GlobalScript.inst.gameState.data[1] += 50;
						GlobalScript.inst.gameState.data[3] += 20;
						GlobalScript.inst.gameState.data[4] += 80;
						GlobalScript.inst.gameState.data[8] -= 100;
						GlobalScript.inst.gameState.data[4] += 80;
						GlobalScript.inst.gameState.data[9] -= 200;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 30;
						GlobalScript.inst.gameState.data[6] -= 50;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.relations += 150;
						empire = GlobalScript.inst.gameState.empires[1];
						empire.relations -= 50;
						GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 3;
						GlobalScript.inst.gameState.allcountries[2].Gosstroy = 2;
					}
					else
					{
						text = "不幸的是，尽管我们支持美国破坏波兰局势的努力，\n但并未能取得积极成果。\n起初一切都按计划进行——12月，“团结”在广大群众的支持下发\n动政变，成功夺取了华沙的政府区。\n但随后发生了意外——斯坦尼斯瓦夫·卡尼亚逃往比亚韦斯托克，\n并向华沙条约的波兰共产党（PCC）请求军事援助。\n1980年12月9日，苏联武装力量北方兵团的部队，\n联合GDR国家人民军和捷克斯洛伐克人民军的部队进入波兰境内，\n并迅速向该国要害城市推进。\n波兰军队的一部分要么加入了他们，要么保持中立。\n“团结”实际上被摧毁，莱赫·瓦文萨几乎才得以逃到华沙的美国使\n馆。由雅鲁泽尔斯基将军领导的波兰人民共和国（PPR）\n新领导层宣布实行“新的社会主义路线”，\n即在苏联部队监督下，在马克思主义框架内实施改革……";
						GlobalScript.inst.gameState.data[9] -= 200;
						GlobalScript.inst.gameState.data[8] -= 100;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 10;
						GlobalScript.inst.gameState.data[6] -= 50;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 300;
						GlobalScript.inst.gameState.data[1] -= 100;
						GlobalScript.inst.gameState.data[4] += 80;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 68)
			{
				text2 = "光州起义";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "5月27日，作为五个师的一部分，韩国空军和陆军部队突入市中心，\n仅用90分钟便将其占领。\n根据不同估算，被杀害的平民人数从数百到数千不等。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "多亏我们提供武器，并在韩国军队的部署中制造混乱、\n实施破坏，针对光州的进攻变成了一场漫长而血腥的战斗。\n更何况，在（多亏我们的特工）得知正在发生的屠杀之后，\n韩国其他城市和地区的人们也纷纷出来抗议，\n演变为与军队和警察的公开冲突，夺取行政大楼和军械库。\n最终，军队还是设法占领了光州，对反叛者进行残酷镇压，\n其余最大的起义也不知怎的被压了下去。\n然而，各地的抗议仍在继续，权力集团全斗焕政府的稳定摇摇欲坠。";
					GlobalScript.inst.gameState.data[22] -= 80;
					GlobalScript.inst.gameState.data[9] -= 80;
					GlobalScript.inst.gameState.data[6] += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					GlobalScript.inst.gameState.SKRebel = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "我们呼吁韩国当局与光州起义者进行谈判、\n寻求折中。这些表态得到了起义者本身的支持，\n但由于美国（除了一些支持我们表态的政客外）\n并未对抗议者以及通过和平方式解决冲突表示任何支持，\n我们的呼吁被当局无视。\n5月27日，作为五个师的一部分，韩国空军和陆军部队突入市中心，\n仅用90分钟便将其占领。\n根据不同估算，被杀害的平民人数从数百到数千不等。";
					GlobalScript.inst.gameState.data[6] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在韩国军队用90分钟攻占城市、对起义进行残酷镇压之后，\n我们表示支持全斗焕的行动，称这种强硬措施是对起义者所策划的混\n乱所能作出的唯一恰当回应。\n韩国政府对我们的支持表示感谢，但不少国家，\n尤其是社会主义阵营，对此极为不满。";
					GlobalScript.inst.gameState.data[6] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 80;
					party_change[4] = 0.25f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic73 in politics)
					{
						if (politic73.traits[0] == 3)
						{
							Politic politic = politic73;
							politic.power += 100;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 69)
			{
				text2 = "又是一个帮派？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "保守派继续把持岗位，破坏你的改革，并与人民和中共作对。\n而改革派自己也对你的消极不满。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[3] -= 70;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic74 in politics)
					{
						if (politic74.traits[0] == 0)
						{
							Politic politic = politic74;
							politic.power += 100;
						}
						else if (politic74.traits[0] == 1)
						{
							Politic politic = politic74;
							politic.loyality -= 150;
						}
						else if (politic74.traits[0] == 2)
						{
							Politic politic = politic74;
							politic.loyality -= 150;
						}
						else if (politic74.traits[0] == 3)
						{
							Politic politic = politic74;
							politic.loyality -= 150;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "2月召开的中共第V次中央全会（五届？）\n上，王东兴、纪登奎、陈希连和吴德因“左倾”而遭到批评；\n他们被指控参与了文化大革命的镇压，并被称为“‘四人帮’的小帮\n”。全会结果是，这四人全部被撤出党政岗位，\n失去任何影响力。那些在基层紧跟他们的保守派也遭遇同样的下场。\n他们的位置已经被你忠诚的支持者——改革派——以及他们所推举的\n人所占据。";
					GlobalScript.inst.gameState.data[1] += 80;
					GlobalScript.inst.gameState.data[92] += 20;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[6] -= 30;
					GlobalScript.inst.gameState.is_party_enabled[0] = false;
					GlobalScript.inst.gameState.is_party_ally[0] = false;
					GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.45f);
					GlobalScript.inst.gameState.is_party_enabled[4] = true;
					party_change[3] = 0.45f;
					party_change[4] = 0.24f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic75 in politics)
					{
						if (politic75.traits[0] == 0)
						{
							Politic politic = politic75;
							politic.power -= 200;
							politic = politic75;
							politic.loyality -= 250;
						}
						else if (politic75.traits[0] == 1)
						{
							Politic politic = politic75;
							politic.power += 80;
						}
						else if (politic75.traits[0] == 2)
						{
							Politic politic = politic75;
							politic.power += 100;
						}
						else if (politic75.traits[0] == 3)
						{
							Politic politic = politic75;
							politic.power += 150;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "二月召开的中共十一届五中全会（V Plenum）\n上，汪东兴、纪登奎、陈希然（Chen Xilian）\n和吴德因“极左倾向”遭到批判，被指控参与了文化大革命的镇压，\n并被称为“小四人帮”。\n全会结果是四人全部被撤销党政职务，失去任何影响力。\n那些在基层死抱着他们不放的保守派，也遭遇同样下场。";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[92] += 10;
					GlobalScript.inst.gameState.data[4] += 30;
					GlobalScript.inst.gameState.data[6] -= 15;
					GlobalScript.inst.gameState.is_party_enabled[0] = false;
					GlobalScript.inst.gameState.is_party_ally[0] = false;
					GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.45f);
					party_change[3] = 0.45f;
					party_change[4] = 0.15f;
					party_change[2] = 0.27f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic76 in politics)
					{
						if (politic76.traits[0] == 0)
						{
							Politic politic = politic76;
							politic.power -= 350;
							politic = politic76;
							politic.loyality -= 300;
						}
						else if (politic76.traits[0] == 1)
						{
							Politic politic = politic76;
							politic.power += 100;
						}
						else if (politic76.traits[0] == 2)
						{
							Politic politic = politic76;
							politic.power += 120;
						}
						else if (politic76.traits[0] == 3)
						{
							Politic politic = politic76;
							politic.power += 80;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 70)
			{
				text2 = "周恩来继承人的问题";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "改革派继续把持岗位，破坏你的事业，也损害你在人民和中共中的声\n誉。而左翼本身也对你的消极不满。";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[4] += 100;
					party_change[3] = 0.25f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic77 in politics)
					{
						if (politic77.traits[0] == 0)
						{
							Politic politic = politic77;
							politic.loyality -= 100;
						}
						else if (politic77.traits[0] == 2)
						{
							Politic politic = politic77;
							politic.power += 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "二月召开的中共十一届五中全会（5th Plenum）\n上，邓小平、叶剑英、赵紫阳等“老改革派”因其修正主义立场、\n鼓吹资产阶级自由化、背叛毛泽东思想而遭到严厉批判。\n尽管讨论激烈，但在全会结果公布后，改革派以及部分中间派被撤销\n党政职务，失去任何影响力。\n那些在基层为他们遮护的改革派，也遭遇同样下场。";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[4] -= 50;
					GlobalScript.inst.gameState.data[6] += 40;
					if (GlobalScript.inst.gameState.modifies[14].active)
					{
						GlobalScript.inst.gameState.KillPerson(12);
						GlobalScript.inst.gameState.modifies[14].active = false;
					}
					party_change[1] = 0.45f;
					party_change[0] = 0.3f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic78 in politics)
					{
						if (politic78.traits[0] == 0)
						{
							Politic politic = politic78;
							politic.power += 150;
						}
						else if (politic78.traits[0] == 1)
						{
							Politic politic = politic78;
							politic.power -= 150;
							politic = politic78;
							politic.loyality -= 200;
						}
						else if (politic78.traits[0] == 2)
						{
							Politic politic = politic78;
							politic.power -= 350;
							politic = politic78;
							politic.loyality -= 200;
						}
						else if (politic78.traits[0] == 3)
						{
							Politic politic = politic78;
							politic.power -= 250;
							politic = politic78;
							politic.loyality -= 200;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "二月召开的中共十一届五中全会（5th Plenum）\n上，邓小平、叶剑英、赵紫阳等“老改革派”因其修正主义立场、\n鼓吹资产阶级自由化、背叛毛泽东思想而遭到严厉批判。\n更有甚者，这些指控甚至也“照顾”了曾与改革派同一阵线的中间派\n——因为你做了他们梦寐以求的事：把文化大革命“定型”，\n并重新评价毛。结果是改革派被撤销党政职务，\n失去任何影响力。那些在基层为他们遮护的改革派，\n也遭遇同样下场。";
					GlobalScript.inst.gameState.data[1] += 80;
					GlobalScript.inst.gameState.data[4] -= 50;
					GlobalScript.inst.gameState.data[6] += 30;
					if (GlobalScript.inst.gameState.modifies[14].active)
					{
						GlobalScript.inst.gameState.KillPerson(12);
						GlobalScript.inst.gameState.modifies[14].active = false;
					}
					party_change[0] = 0.3f;
					party_change[1] = 0.45f;
					party_change[2] = 0.24f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic79 in politics)
					{
						if (politic79.traits[0] == 2)
						{
							Politic politic = politic79;
							politic.power -= 350;
							politic = politic79;
							politic.loyality -= 200;
						}
						else if (politic79.traits[0] == 3)
						{
							Politic politic = politic79;
							politic.power -= 250;
							politic = politic79;
							politic.loyality -= 200;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "奉你的命令，改革派头目被以莫须有的罪名逮捕，\n并被永久逐出政治舞台。\n之后，在我们控制的媒体积极配合下，开始对改革主义思想及被镇压\n的改革派支持者进行抹黑，党内也随之开始清除他们。\n人民和党内人士都不高兴，认为这不过是文化大革命的重演，\n但我们总算除掉了对手。";
					GlobalScript.inst.gameState.data[1] -= 200;
					GlobalScript.inst.gameState.data[4] += 150;
					GlobalScript.inst.gameState.data[3] -= 200;
					GlobalScript.inst.gameState.data[6] += 50;
					if (GlobalScript.inst.gameState.modifies[14].active)
					{
						GlobalScript.inst.gameState.KillPerson(12);
						GlobalScript.inst.gameState.modifies[14].active = false;
					}
					party_change[0] = 0.3f;
					party_change[1] = 0.45f;
					GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.09f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic80 in politics)
					{
						if (politic80.traits[0] == 0)
						{
							Politic politic = politic80;
							politic.power += 150;
						}
						else if (politic80.traits[0] == 1)
						{
							Politic politic = politic80;
							politic.power -= 50;
							politic = politic80;
							politic.loyality -= 30;
						}
						else if (politic80.traits[0] == 2)
						{
							Politic politic = politic80;
							politic.power -= 350;
							politic = politic80;
							politic.loyality -= 30;
						}
						else if (politic80.traits[0] == 3)
						{
							Politic politic = politic80;
							politic.power -= 250;
							politic = politic80;
							politic.loyality -= 300;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 71)
			{
				text2 = "东方红……";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "一切照旧，人民解放游击队（Naxalites）\n继续发动袭击，印度政府时而得手、时而失手，\n试图遏制他们。但谁知道呢，也许有一天他们会派上用场——因为他\n们也活动在我们“假装”不去管的那些地区……";
					GlobalScript.inst.gameState.CBIndia = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "经过长期争论与犹豫，印度政府最终还是同意在我们的斡旋下与人民\n解放游击队（Naxalites）谈判。\n谈判结果极其不易，他们才换取到在地方政府和自治机构中的席位（\n少数地方甚至拿下多数），并承认他们为合法政治力量。\n固然也有一些部队和团体已把这称作背叛，\n但我们在乎这些恐怖分子吗？\n我们在印度东部的影响力已大为增强。";
					GlobalScript.inst.gameState.data[1] += 80;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[6] -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "解放军部队相对迅速地击溃了第一道边防，\n但随后却陷入了印度方面自上次边境战争以来就组织得很好的工事。\n看来这场战争会比我们想象的更久、更血腥……\n与此同时，全世界已经在冷眼旁观，要求我们立刻坐到谈判桌前。";
					GlobalScript.inst.gameState.data[1] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 150;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 250;
					GlobalScript.inst.gameState.data[6] += 50;
					GlobalScript.inst.gameState.war = 2;
					GlobalScript.inst.gameState.data[40] = 200;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 72)
			{
				text2 = "救起溺水者";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = ((GlobalScript.inst.gameState.data[91] != 1) ? "最终，在党内争斗与阴谋的压力下，人民党领袖莫拉尔吉·德赛辞去\n总理职务。由他接任的查兰·辛格很可能撑到1980年选举，\n之后甘地又将取而代之。" : "人民党（Janata Party）在民众中极受欢迎，\n所有分析人士都预测他们将取代国大党（INC），\n成为国家数十年的主要政党；但最终，\n在党内争斗与阴谋的压力下，人民党领袖莫拉尔吉·德赛（Mora\nrji Desai）辞去总理职务，联盟本身也随之瓦解，\n造成全国性的重大政治真空。\n他的继任者查兰·辛格（Charan Singh）\n很可能执政到1980年选举之后——届时预计由国大党、\n左翼人民党和共产党组成的混合联盟将获胜，\n之后甘地（Gandhi）可能再次上台。");
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.allcountries[19].Torg = false;
					GlobalScript.inst.gameState.allcountries[19].prosov = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们的外交人员成功说服人民党领袖莫拉尔吉·德赛，\n接受左翼提出的要求——主要是禁止“双重党籍”：\n在人民党及其他政党之间的双重任职，主要针对各自党内的右翼代表。\n结果是他们中的大多数选择留在本党，\n并被逐出人民党；而德赛则在左翼支持下保住了总理职位。\n明确了政治取向后，人民党正在推行以发展生产、\n反贫困为主的左翼政策，为此我们不得不以低利率向印度提供贷款。\n看来该党已在人民眼中“翻案”，在即将到来的选举中大有机会。";
					GlobalScript.inst.gameState.data[1] += 80;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 80;
					GlobalScript.inst.gameState.data[9] -= 60;
					GlobalScript.inst.gameState.data[8] -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "我们的外交人员成功说服人民党领袖莫拉尔吉·德赛，\n拒绝左翼提出的要求——主要是关于禁止“双重党籍”：\n在人民党及其他政党之间的双重任职，主要针对各自党内的右翼代表。\n结果是左翼大多数因分裂和违反集体领导原则而被排除在外，\n而德赛则在右翼支持下保住了总理职位。\n明确了自己的政治取向后，人民党现在推行以吸引外资、\n建立“真正的民主”为主的右翼自由化政策，\n为此我们不得不以低利率向印度提供贷款。\n看来该党已在人民眼中“翻案”，在即将到来的选举中大有机会。";
					GlobalScript.inst.gameState.data[1] += 80;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 80;
					GlobalScript.inst.gameState.data[9] -= 60;
					GlobalScript.inst.gameState.data[8] -= 100;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
					GlobalScript.inst.gameState.allcountries[19].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[19].SubGosstroy = 5;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 74)
			{
				text2 = "关于中共历史若干问题的决议";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "1981年6月27日至29日，北京召开中共十一届六中全会。\n出席全会的有中共中央委员195人、候补委员114人，\n以及53名列席人员。\n全会的议程是：审议并通过《中华人民共和国成立以来中共历史若干\n问题的决议》。全会一致通过《中华人民共和国成立以来中共历史若\n干问题的决议》，从马克思主义立场——辩证唯物主义和历史唯物主\n义的立场——正确总结了中华人民共和国成立后32年中党的历史上\n最重要的事件，分析了错误的主观因素和社会原因，\n对伟大领袖和导师毛泽东同志在中国革命史上的地位作出了公正评价，\n充分论证了毛泽东思想作为我党指导思想的重大意义。\n《决议》确认了建设现代化社会主义强国道路的正确性，\n并指明了我国社会主义事业发展的进一步方向以及党的工作。";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[3] += 80;
					GlobalScript.inst.gameState.data[4] -= 100;
					GlobalScript.inst.gameState.data[92] -= 20;
					GlobalScript.inst.gameState.data[6] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					party_change[0] = 0.24f;
					party_change[1] = 0.24f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic81 in politics)
					{
						if (politic81.traits[0] == 0)
						{
							Politic politic = politic81;
							politic.power += 100;
							politic = politic81;
							politic.loyality += 150;
						}
						else if (politic81.traits[0] == 1)
						{
							Politic politic = politic81;
							politic.power -= 50;
							politic = politic81;
							politic.loyality -= 50;
						}
						else if (politic81.traits[0] == 2)
						{
							Politic politic = politic81;
							politic.power -= 100;
							politic = politic81;
							politic.loyality -= 100;
						}
						else if (politic81.traits[0] == 3)
						{
							Politic politic = politic81;
							politic.power -= 150;
							politic = politic81;
							politic.loyality -= 150;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "1981年6月27日至29日，北京召开中共十一届六中全会。\n出席全会的有中共中央委员195人、候补委员114人，\n以及53名列席人员。\n全会的议程是：审议并通过《中华人民共和国成立以来中共历史若干\n问题的决议》。全会一致通过《我国建国以来党的历史若干问题的决\n议》，从马克思主义立场——辩证唯物主义和历史唯物主义的立场—\n—正确总结了中华人民共和国成立后32年中党的历史上最重要的事\n件，尤其是“文化大革命”，科学分析了党在这些事件中指导思想的\n正确与错误，分析了错误的主观因素和社会原因，\n对毛泽东同志作为伟大领袖和导师在中国革命史上的地位作出公正评\n价，充分论证了毛泽东思想作为我党指导思想的重大意义。";
					GlobalScript.inst.gameState.data[1] += 100;
					GlobalScript.inst.gameState.data[3] += 80;
					GlobalScript.inst.gameState.data[92] += 10;
					GlobalScript.inst.gameState.data[4] -= 50;
					GlobalScript.inst.gameState.data[6] -= 30;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					party_change[2] = 0.15f;
					party_change[3] = 0.21f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic82 in politics)
					{
						if (politic82.traits[0] == 0)
						{
							Politic politic = politic82;
							politic.loyality += 100;
						}
						else if (politic82.traits[0] == 1)
						{
							Politic politic = politic82;
							politic.power += 100;
							politic = politic82;
							politic.loyality += 100;
						}
						else if (politic82.traits[0] == 2)
						{
							Politic politic = politic82;
							politic.power += 100;
							politic = politic82;
							politic.loyality += 100;
						}
						else if (politic82.traits[0] == 3)
						{
							Politic politic = politic82;
							politic.loyality += 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "1981年6月27日至29日，北京召开中共第十一届中央委员会\n第六次全体会议。出席会议的有中共中央委员195人、\n中共中央候补委员114人，以及53名列席人员。\n全会的议程是：审议并通过《中华人民共和国成立以来我党历史若干\n问题的决议》。“关于中华人民共和国成立以来我党历史若干问题的\n决议”引发了极其严重的争论，并以少数票通过。\n该决议以马克思主义立场、以辩证唯物主义和历史唯物主义的立场，\n总结了中华人民共和国成立后32年我党历史上最重要的事件，\n尤其是“文化大革命”，批判了在这些事件过程中党在指导思想上的\n一切错误，分析了毛泽东的主观因素以及错误的社会原因，\n对毛泽东在中国革命史上的地位作出了相对公允的评价——称其为“\n东方的专制暴君”；同时充分论证了马克思-恩格斯-列宁思想作为\n我党指导思想的重大意义，并否定了毛泽东的反马克思主义观点。";
					GlobalScript.inst.gameState.data[1] -= 150;
					GlobalScript.inst.gameState.data[3] -= 150;
					GlobalScript.inst.gameState.data[57] -= 200;
					GlobalScript.inst.gameState.data[92] += 40;
					GlobalScript.inst.gameState.data[4] += 250;
					GlobalScript.inst.gameState.data[6] -= 60;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 250;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 30;
					gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 50;
					party_change[4] = 0.3f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic83 in politics)
					{
						if (politic83.traits[0] == 0)
						{
							Politic politic = politic83;
							politic.loyality -= 300;
						}
						else if (politic83.traits[0] == 1)
						{
							Politic politic = politic83;
							politic.loyality -= 300;
						}
						else if (politic83.traits[0] == 2)
						{
							Politic politic = politic83;
							politic.loyality -= 300;
						}
						else if (politic83.traits[0] == 3)
						{
							Politic politic = politic83;
							politic.loyality += 150;
						}
					}
					GlobalScript.inst.gameState.number_event = 4;
					load_scene_after_click = "Event";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "1981年6月27日至29日，北京召开中共第十一届中央委员会\n第六次全体会议。出席会议的有中共中央委员195人、\n中共中央候补委员114人，以及53名列席人员。\n全会的议程是：审议并通过《中华人民共和国成立以来我党历史若干\n问题的决议》。全会审议了这份《决议》，\n认为其“准备不足且相当错误”，于是将其送交委员会修改。";
					if (GlobalScript.inst.gameState.data[56] < 2)
					{
						text += "起草机构对文稿中的偏差进行了修正，强调毛主席在中国革命和国家\n发展中的领导作用，同时指出右和左两方面的偏差。\n该版本被全会通过。";
						GlobalScript.inst.gameState.data[1] += 20;
						GlobalScript.inst.gameState.data[3] += 50;
						GlobalScript.inst.gameState.data[92] -= 20;
						GlobalScript.inst.gameState.data[4] -= 60;
						GlobalScript.inst.gameState.data[90] = 0;
						GlobalScript.inst.gameState.data[6] += 40;
						party_change[0] = 0.24f;
						party_change[1] = 0.24f;
						Politic[] politics = GlobalScript.inst.gameState.politics;
						foreach (Politic politic84 in politics)
						{
							if (politic84.traits[0] == 0)
							{
								Politic politic = politic84;
								politic.power += 100;
								politic = politic84;
								politic.loyality += 150;
							}
							else if (politic84.traits[0] == 1)
							{
								Politic politic = politic84;
								politic.power -= 50;
								politic = politic84;
								politic.loyality -= 50;
							}
							else if (politic84.traits[0] == 2)
							{
								Politic politic = politic84;
								politic.power -= 100;
								politic = politic84;
								politic.loyality -= 100;
							}
							else if (politic84.traits[0] == 3)
							{
								Politic politic = politic84;
								politic.power -= 150;
								politic = politic84;
								politic.loyality -= 200;
							}
						}
					}
					else if (GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 1)
					{
						text += "起草机构对文稿中的偏差进行了修正，遵循“纠正一切错误、\n发扬一切正确”的原则，对40—70年代作出相对均衡的评价。\n该方案被全会通过。";
						GlobalScript.inst.gameState.data[1] += 80;
						GlobalScript.inst.gameState.data[3] += 40;
						GlobalScript.inst.gameState.data[90] = 1;
						GlobalScript.inst.gameState.data[92] += 10;
						GlobalScript.inst.gameState.data[4] -= 50;
						GlobalScript.inst.gameState.data[6] -= 20;
						party_change[2] = 0.15f;
						party_change[3] = 0.21f;
						Politic[] politics = GlobalScript.inst.gameState.politics;
						foreach (Politic politic85 in politics)
						{
							if (politic85.traits[0] == 0)
							{
								Politic politic = politic85;
								politic.loyality += 100;
							}
							else if (politic85.traits[0] == 1)
							{
								Politic politic = politic85;
								politic.power += 100;
								politic = politic85;
								politic.loyality += 100;
							}
							else if (politic85.traits[0] == 2)
							{
								Politic politic = politic85;
								politic.power += 100;
								politic = politic85;
								politic.loyality += 100;
							}
							else if (politic85.traits[0] == 3)
							{
								Politic politic = politic85;
								politic.loyality += 100;
							}
						}
					}
					else if (GlobalScript.inst.gameState.data[56] > 2)
					{
						text += "起草机构对文稿中的偏差进行了修正，重点引用赫鲁晓夫1956年\n的“秘密报告”，以及西方情报机构的文件和苏联出版物，\n揭露毛泽东及其领导时期。\n该方案被全会通过。";
						GlobalScript.inst.gameState.data[1] -= 100;
						GlobalScript.inst.gameState.data[3] -= 150;
						GlobalScript.inst.gameState.data[90] = 2;
						GlobalScript.inst.gameState.data[57] -= 200;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 30;
						GlobalScript.inst.gameState.data[92] += 40;
						GlobalScript.inst.gameState.data[4] += 200;
						GlobalScript.inst.gameState.data[6] -= 50;
						party_change[4] = 0.3f;
						Politic[] politics = GlobalScript.inst.gameState.politics;
						foreach (Politic politic86 in politics)
						{
							if (politic86.traits[0] == 0)
							{
								Politic politic = politic86;
								politic.loyality -= 300;
							}
							else if (politic86.traits[0] == 1)
							{
								Politic politic = politic86;
								politic.loyality -= 300;
							}
							else if (politic86.traits[0] == 2)
							{
								Politic politic = politic86;
								politic.loyality -= 300;
							}
							else if (politic86.traits[0] == 3)
							{
								Politic politic = politic86;
								politic.loyality += 150;
							}
						}
						GlobalScript.inst.gameState.number_event = 4;
						load_scene_after_click = "Event";
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "1981年6月27日至28日，北京召开中共十一届六中全会。\n出席全会的有中共中央委员195人、候补委员114人，\n以及53名列席人员。\n全会的议程是：审议并通过《中华人民共和国成立以来我党历史若干\n问题的决议》。应中共主席的要求，该议题从议程中撤下，\n理由是“过时且不重要”。\n全会正在完成其工作。";
					GlobalScript.inst.gameState.data[1] -= 70;
					GlobalScript.inst.gameState.data[3] -= 30;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[4] += 70;
					GlobalScript.inst.gameState.data[90] = 3;
					GlobalScript.inst.gameState.data[8] -= 200;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic87 in politics)
					{
						Politic politic = politic87;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 75)
			{
				text2 = "伊拉克原子问题";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "空袭发生后不久，萨达姆·侯赛因在伊拉克部长会议紧急会议上发表\n慷慨激昂的讲话，他说：“今天对‘塔穆兹’反应堆所打的这一击，\n对我们来说并不突然。\n当然，它会让人痛，因为它是革命的一个丰硕成果——我们长期在政\n治、科学和经济上都非常重视它……\n这并不是因为他们害怕伊拉克的原子弹——正如特拉维夫那伙人的\n头目所说——而是因为他们害怕科学、社会、\n经济、政治的均衡而紧凑的发展，这种发展是严肃地为了建设一个新\n的伊拉克……我们没有站队，所以我们将推迟所有借口，\n因为这一击是打在我们身上……\n你们明白为什么会有战争——不仅仅是为了打击伊拉克的核反应堆，\n而是为了阻止伊拉克的崛起……\n你们也明白为什么战争还会继续……\n”我们全力支持萨达姆，并谴责“来自以色列的美国雇佣军匪徒袭\n击”，同时建议向伊拉克提供经济与军事援助，\n侯赛因对此欣然同意。\n尽管伊拉克继续奉行多方向的外交政策，\n在不削弱与苏联和美国合作的同时，仍对我们这边有某种倾斜……\n中东的美国盟友勃然大怒，但美国本身却出奇地冷静……";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[8] -= 80;
					GlobalScript.inst.gameState.data[6] += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GlobalScript.inst.gameState.allcountries[14].Torg = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "空袭发生后不久，萨达姆·侯赛因在伊拉克部长会议紧急会议上发表\n慷慨激昂的讲话，他说：“今天对‘塔穆兹’反应堆所打的这一击，\n对我们来说并不突然。\n当然，它会让人痛，因为它是革命的一个丰硕成果——我们长期在政\n治、科学和经济上都非常重视它……\n这并不是因为他们害怕伊拉克的原子弹——正如特拉维夫那伙人的\n头目所说——而是因为他们害怕科学、社会、\n经济、政治的均衡而紧凑的发展，这种发展是严肃地为了建设一个新\n的伊拉克……”伊拉克向联合国申诉，要求谴责以色列的行动，\n而萨达姆同时得到两大超级大国——苏联和美国——的支持。\n安理会要求以色列赔偿，并在未来停止此类行动。\n以色列国内，许多反对派议员在西蒙·佩雷斯（Shimon Pe\nres）带领下批评政府决定。\n然而国防部长阿里埃尔·沙龙（Ariel Sharon）\n对批评作出坚定回应：“我们军事政策的一个组成要素，\n就是坚决阻止敌对国家获得核武器。\n因此，我们必须在萌芽阶段消除这种威胁。\n”据我们掌握的情况，伊拉克已增加从苏联和美国购买武器的数量，\n走上对军队进行质的换装之路。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "空袭发生后不久，萨达姆·侯赛因在部长会议紧急会议上发表慷慨激\n昂的讲话，他说：“今天对‘塔穆兹’反应堆所打的这一击，\n对我们来说并不突然。\n当然，它会让人痛，因为它是革命的一个丰硕成果——我们长期在政\n治、科学和经济上都非常重视它……\n这并不是因为他们害怕伊拉克的原子弹——正如特拉维夫那伙人的\n头目所说——而是因为他们害怕科学、社会、\n经济、政治的均衡而紧凑的发展，这种发展是严肃地为了建设一个新\n的伊拉克……我们没有站队，所以我们将推迟所有借口，\n因为这一击是打在我们身上……\n”同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "决定帮助伊拉克恢复核计划，萨达姆对此欣然同意。\n在以七月革命命名的核中心（图韦塔伊萨沙漠）\n里，中国工人到来，并很快把CNP-200核反应堆运抵（与此同\n时，“摩萨德”企图炸毁我们运输该设备的船只的行动被挫败）。\n据我们的科学家称，核武器研制正如火如荼：\n到1988年伊拉克将拥有3枚原子弹，\n1995年则将达到5枚。\n以色列勃然大怒，指责“汉族沙文主义者”在“世界霸权”，\n但苏联和美国尚未对此作出回应。";
					if (GlobalScript.inst.gameState.influencePRC >= 500)
					{
						text += "既然伊拉克可能拥有自己的核武器，萨达姆·侯赛因便发动大规模运\n动，口号是“把帝国主义从我们这里抢走的一切都夺回来”，\n以及“清除民族中的敌人和犹太复国主义者”。\n伊拉克加紧军事化，并开始切断外交关系，\n走向国际孤立……";
						GlobalScript.inst.gameState.data[1] += 80;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 10;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.power -= 10;
						GlobalScript.inst.gameState.data[6] += 80;
						GlobalScript.inst.gameState.data[8] -= 150;
						GlobalScript.inst.gameState.data[9] -= 100;
						GlobalScript.inst.gameState.data[143] += 2;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						GlobalScript.inst.gameState.allcountries[14].Gosstroy = 0;
						GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 10;
						GlobalScript.inst.gameState.allcountries[14].prosov = false;
						GlobalScript.inst.gameState.allcountries[14].Torg = true;
					}
					else
					{
						text += "伊拉克的核计划引起了国际原子能机构（IAEA）\n的关注。它指控伊拉克违反《不扩散核武器条约》（NPT），\n并要求伊拉克只能在国际组织监管下从事和平利用核能。\n由于苏联和美国支持这一要求，侯赛因被迫同意。\n然而，启动和平计划也同样失败——12月1日，\n以色列空军实施第二次空袭，反应堆被彻底摧毁。\n出于担心失去权力，他决定转向我们这边。";
						GlobalScript.inst.gameState.data[1] += 50;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 10;
						GlobalScript.inst.gameState.data[6] += 80;
						GlobalScript.inst.gameState.data[8] -= 150;
						GlobalScript.inst.gameState.data[9] -= 100;
						GlobalScript.inst.gameState.allcountries[14].prosov = false;
						GlobalScript.inst.gameState.allcountries[14].Torg = true;
						GlobalScript.inst.gameState.allcountries[14].proprc = true;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "我们完全赞同以色列对“塔穆兹”反应堆的空袭，\n并谴责侯赛因的军国主义路线、泛阿拉伯沙文主义以及对库尔德少数\n民族的压制。这在党和人民中造成了严重误解——他们并不指望在多\n年批评以色列政策之后，会出现如此公开的支持。\n作为回应，伊拉克部长会议发表公报，指控中国“支持来自特拉维夫\n的犹太复国主义匪帮”，并决定断绝外交关系。\n我们的使馆被强行逐出巴格达；与此同时，\n伊拉克增加了从苏联和美国购买武器的数量，\n走上对军队进行质的换装之路。\n看来中东又要爆发新战争了……";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[6] -= 40;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[4] += 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 150;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					GlobalScript.inst.gameState.allcountries[14].Torg = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 76)
			{
				text2 = "推倒那个跌倒的人！";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "中华人民共和国外交部发表公报，正式表示支持科索沃示威者“为其\n正当民主权利而进行的抗议”。\n这引起南斯拉夫的强烈愤怒：它指责中国干涉其内政；\n而其不结盟运动则指责中国搞“毛主义霸权”。\n苏联和美国对此置之不理，主要是因为南斯拉夫社会主义联邦共和国\n（SFRY）采取“独立”立场，不属于任何阵营。\n科索沃实施紧急状态，部分南斯拉夫人民军（JNA）\n进入当地，到4月3日已镇压了所有抗议并恢复了省内秩序。\n还发现阿尔巴尼亚介入的证据。\n对分裂分子的“大清洗”随即开始。";
					GlobalScript.inst.gameState.data[6] += 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = ((!GlobalScript.inst.dlc[3]) ? string.Format(GlobalScript.inst.new_events_text[900], "\n") : "在政治局闭门会议上，决定利用南斯拉夫的麻烦局势，\n向科索沃分裂分子提供全面援助。\n作为“转运点”，我们决定使用驻贝尔格莱德的中国使馆。\n科索沃分裂分子从我们这里获得武器和资金后，\n便能够组织对部分JNA和民兵的武装抵抗。\n普里什蒂纳（Pristina）爆发了最真实的街头巷战，\n南斯拉夫军队积极使用炮火和飞机，导致城市被毁。\n“普里什蒂纳正在燃烧！\n”的报道传遍世界，给SFRY的国际声望造成重创。\n尽管叛乱仍在6月前被压下，但要恢复该地区需要巨额资金，\n而南斯拉夫根本拿不出来。\n|1981年4月，在SFRY主席团会议以及联邦维护宪法秩序委\n员会上，L.科利舍夫斯基（L. Kolishevsky）\n说：“我们必须充分认识到这种论断的谬误与极端反动性——塞尔维\n亚越弱，科索沃（或我们任何其他共和国）\n越强。以及这种论断——在塞尔维亚内部，\n科索沃自治越小，塞尔维亚越强。\n也可以说，塞尔维亚弱——南斯拉夫强。\n”民族主义者开始在国内巩固其立场……");
					GlobalScript.inst.gameState.data[8] -= 100;
					GlobalScript.inst.gameState.data[9] -= 100;
					GlobalScript.inst.gameState.data[86] -= 4;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们驻地拉那（Tirana）的大使前往同志恩维尔·霍查（En\nver Hoxha）和拉米兹·阿利亚（Ramiz Alia，\n西古里米（Sigurimi）党内负责人），\n向他们提出我们的建议。";
					text += "他们同意我们的援助。\n中国国家安全部（MSS）的一批工作人员已抵达阿尔巴尼亚，\n并迅速与西古里米建立合作。\n结果是，尽管JNA设法压制了叛乱，却没能彻底平息该省。\n我们可以在那里再次煽动骚乱。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
					GlobalScript.inst.gameState.data[86] -= 2;
					GlobalScript.inst.gameState.data[8] -= 50;
					GlobalScript.inst.gameState.data[9] -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "科索沃实施紧急状态，部分JNA进入当地，\n到4月3日已镇压了所有抗议并恢复了省内秩序。";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 77)
			{
				text2 = "唾沫糊脸、拳头打下巴、子弹打脑袋";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "谢胡（Shehu）凭借手中的国家机器和西古里米（Siguri\nmi），动员起自己的支持者，把霍查孤立起来，\n随后又召开了人民军（PLA）中央委员会的非常大会。\n他在会上宣布：由于医疗原因，第一书记在一段时间内将无法履行职\n责。对手们最多只能交出党内和政府中的职位，\n但许多人最终要么被关进西古里米监狱，\n要么死于离奇的境况。\n不久又宣布霍查因病情加重而死亡；之后，\n谢胡要拿到人民军中央委员会第一书记的职位并不困难。\n他已经开始与南斯拉夫、苏联以及社会主义阵营国家进行谨慎谈判—\n—看起来他们欢迎这种领导层更替，尽管阿尔巴尼亚的国内政策并没\n有太大变化。";
					if (!GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						text += "谢胡恢复同中国的关系更快，建立贸易，\n并邀请我们的顾问到该国。";
					}
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[9] -= 80;
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.data[60] = 1;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.allcountries[20].Torg = true;
					GlobalScript.inst.gameState.allcountries[20].proprc = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "结果，谢胡与霍查的关系继续恶化。\n1981年12月18日宣布谢胡自杀，\n随后他被指控为美国、苏联和南斯拉夫从事叛国与间谍活动。\n作为总理，他被缺乏主动性、忠诚的阿迪尔·查尔卡尼所取代。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.allcountries[20].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[20].SubGosstroy = 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "结果，谢胡与霍查的关系继续恶化。\n1981年12月18日宣布谢胡自杀，\n随后他被指控为美国、苏联和南斯拉夫从事叛国与间谍活动。\n作为总理，他被缺乏主动性、忠诚的阿迪尔·查尔卡尼所取代。\n整个期间，我们支持霍查的行动，并欢迎阿尔巴尼亚从“间谍谢胡”\n手中获得解放，为此我们收到了地拉那方面的感谢。";
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.allcountries[20].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[20].SubGosstroy = 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 78)
			{
				text2 = "永远的总统";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在我们特工部门的协助以及武器供应下，\n菲律宾共产党（CPP）和民族民主运动（NDM）\n得以展开大规模煽动与抗议，并伴随游击活动的骤然升温。\n很快，这些不满又被其他政治力量和普通民众所加入。\n当然，抗议很快遭到警方严厉镇压，游击攻势也被军队遏制，\n但看来我们已经对马科斯政权造成了严重打击——他显然没料到中国\n会如此突然、如此大胆地插手。\n最终，他还是设法赢得总统选举，获得52%的选票，\n但他在行动上将不得不更加谨慎，而共产党的影响力也显著上升。\n也许在进一步帮助他们之后，我们仍将看到菲律宾革命的胜利……";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[9] -= 100;
					GlobalScript.inst.gameState.data[6] += 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GlobalScript.inst.gameState.data[37] += 300;
					GlobalScript.inst.gameState.allcountries[47].Torg = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "结果，马科斯最终赢得总统选举，拿下了惊人的88%选票。\n看来菲律宾正在等待他政策的延续。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在马科斯以压倒性88%选票赢得总统选举后，\n我们向他表示祝贺，并表达希望两国进一步走近——这种关系始于1\n975年。马科斯很乐意利用我们的提议，\n但许多菲律宾毛派团体称之为背叛，共产党影响力也因此有所下降。";
					GlobalScript.inst.gameState.data[6] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					GlobalScript.inst.gameState.data[37] -= 200;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
					GlobalScript.inst.gameState.allcountries[47].Torg = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 79)
			{
				text2 = "紧缩政策";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "他亲自打电话给勃列日涅夫，表示罗马尼亚的局势直接威胁到在罗马\n尼亚建设社会主义的事业以及整个苏联阵营的稳定，\n因此其解决必须覆盖整个社会主义阵营。\n苏联领导人支持我们的设想，于是召集了经互会（CMEA）\n特别会议，决定以无偿的货币援助形式，\n向罗马尼亚提供偿债援助，并给予罗马尼亚对经互会的优惠进出口条\n件（当然，主要费用由我们和苏联承担）。\n齐奥塞斯库感谢我们及经互会其他成员的帮助，\n并已宣布对紧缩体制作出调整，旨在缓和它。\n当然，即便是小规模的紧缩措施也让罗马尼亚市民不满，\n但这对齐奥塞斯库来说并非难以应付。\n按我们的估算，以这种速度，他将在80年代末在不对经济与生活水\n平造成严重后果的情况下还清债务。";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[8] -= 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 150;
					GlobalScript.inst.gameState.allcountries[5].Torg = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "尽管这些措施“有利可图”，但它们已经导致罗马尼亚经济增长放缓、\n生活水平下降，引发罗马尼亚民众的普遍不满。\n齐奥塞斯库目前还能应付得了，但谁知道结局会怎样……";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "借助我们同罗马尼亚的良好关系，我们向齐奥塞斯库提供了大规模财\n政援助，以减轻债务负担，他欣然接受。\n我们不得不付出不少代价，但最终他宣布对紧缩体制作出调整，\n旨在缓和它。当然，即便是小规模的紧缩措施也让罗马尼亚市民不满，\n但这对齐奥塞斯库来说仍算不上什么。\n与此同时，他利用进口机会来扩大同我们的贸易。";
					GlobalScript.inst.gameState.data[6] += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GlobalScript.inst.gameState.data[8] -= 300;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.allcountries[5].Torg = true;
					GlobalScript.inst.gameState.allcountries[5].proprc = true;
					GlobalScript.inst.gameState.allcountries[5].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[5].SubGosstroy = 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 80)
			{
				text2 = "中共十二大";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在大会上 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "提出党的目标是清除社会主义制度中的“右”和“左”的过火现象。\n他尖锐反对那些主张把现行制度彻底推倒、\n并按西方模式重建国家的人。\n在对党章的修订过程中，确认将预备期延长至5年，\n政治局候补委员的任职经历延长至8年。\n新当选的中共中央委员会由210名委员和138名候补委员组成。";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[6] += 5;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "在中共十二大中央委员会工作报告中，同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "重点阐述了中共十一届中央委员会第六次全体会议的成果，\n以及通过《建国以来中共党史若干问题的决议》。\n其中“以全部责任”对本党自1949年以来的道路、\n社会主义建设中的成就与失误，以及毛泽东同志在其中所处的位置—\n—“由于各种因素，造成或允许造成这些失误”——进行了研究与总\n结。大会一结束，媒体就减少对毛泽东的提及；\n他的多部著作（《小红书》《论十大关系》《关于国际共产主义运动\n总路线的争论》）逐步从图书馆撤下，并停止再版；\n“必须学习毛泽东思想”改为“自愿学习”。\n尽管毛泽东在中国和中共的历史中并未被一笔勾销，\n对他的批评仍然很可能坐牢，但他的作用被压缩为苏联的弗拉基米尔\n·列宁那样——某种“革命的好祖父和领袖”——仅此而已。";
					GlobalScript.inst.gameState.data[1] += 80;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[6] -= 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GlobalScript.inst.gameState.data[57] -= 80;
					GlobalScript.inst.gameState.modifies[6].active = false;
					GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.05f);
					GlobalScript.inst.gameState.party_ideology[0] -= (int)((float)GlobalScript.inst.gameState.party_ideology[0] * 0.1f);
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic88 in politics)
					{
						if (politic88.traits[0] == 0)
						{
							Politic politic = politic88;
							politic.loyality -= 200;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在中共十二大最后一天，同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "要求代表们再留下开一次会——这次是闭门会议。\n在会上，他默读了文件《论毛泽东个人崇拜及其后果的克服》。\n文件指控这位中国的奠基者“歪曲马克思列宁主义，\n建立个人崇拜并对政治对手实行群众恐怖，\n歪曲社会主义法制，支持林彪集团”等等。\n代表们带着沉闷的情绪进入会场，在没有讨论的情况下接受了报告。\n随后，这份文件在各级共产党组织中传阅，\n引起震动与抵触。拆除毛泽东的纪念碑、\n从图书馆和书店撤下他的著作与肖像开始进行，\n媒体还刊发了关于“伟大舵手”的揭露材料。\n苏联和美国对我们揭穿毛的个人崇拜表示认可，\n但数以百万计的不满者开始抵抗。\n“退党”（“Tugan”）运动广泛传播（大规模退出中共，\n常伴随公开焚毁党员证），而西方的毛派运动也接连指责我们“赫鲁\n晓夫式修正主义”和“背叛”。\n我们在国内外的立场都遭到严重削弱；如果有人企图发动政变，\n那没有了意识形态支撑的党显然不会替你挡灾……";
					GlobalScript.inst.gameState.data[1] -= 300;
					GlobalScript.inst.gameState.data[3] -= 450;
					GlobalScript.inst.gameState.data[6] -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 150;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 300;
					GlobalScript.inst.gameState.data[57] -= 450;
					GlobalScript.inst.gameState.data[4] += 400;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 300;
					party_change[3] = 0.15f;
					party_change[4] = 0.6f;
					GlobalScript.inst.gameState.modifies[6].active = false;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic89 in politics)
					{
						if (politic89.traits[0] == 0)
						{
							Politic politic = politic89;
							politic.loyality -= 600;
						}
						else if (politic89.traits[0] == 1)
						{
							Politic politic = politic89;
							politic.loyality -= 400;
						}
						else if (politic89.traits[0] == 2)
						{
							Politic politic = politic89;
							politic.loyality -= 300;
						}
						else if (politic89.traits[0] == 3)
						{
							Politic politic = politic89;
							politic.loyality += 200;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 81)
			{
				text2 = "匈牙利狂想曲";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "你亲自打电话给亚诺什·卡达尔，告知全国人大常委会决定以极低利\n率向匈牙利提供35亿美元贷款。\n这样一来，匈牙利得以避免违约，不必再去借新的贷款。\n卡达尔作为匈牙利人民共和国国务委员会主席，\n代表匈牙利人民向中国人民表达了巨大的感谢，\n但苏联和美国对此并不高兴，媒体已经在写“中国产业在欧洲的经济\n扩张”。";
					GlobalScript.inst.gameState.data[8] -= 300;
					GlobalScript.inst.gameState.data[6] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 80;
					GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "中央委员会的宣传思想部门授权大量印发批判匈牙利局势的材料。\n《“古拉什社会主义”》被宣布为“假装的市场审计”；\n卡达尔被追忆其在1956年反革命政变中的参与，\n并得到伊姆雷·纳吉集团的支持；匈牙利社会主义工人党（HSWP）\n被称为“愚蠢的马克思主义社会叛徒党”；\n匈牙利的社会主义制度则被说成“用美国钱财装饰起来的”。\n据此得出结论：所有市场改革都是修正主义，\n通向经济深渊。党和人民并不接受这种本就相当乏味的宣传再度加码；\n匈牙利向我们提出了坚决抗议，而这也得到了苏联的支持。\n我想这并不是我们想要的……";
					GlobalScript.inst.gameState.data[1] -= 50;
					GlobalScript.inst.gameState.data[4] -= 20;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[6] += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 30;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 80;
					GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "今天早晨，中国驻布达佩斯大使拜会亚诺什·卡达尔，\n并代表我们提出一笔无息35亿美元贷款。\n卡达尔本来准备立刻答应，但大使随后的一番话让他清醒过来——作\n为贷款的交换，匈牙利社会主义工人党（HSWP）\n中央委员会政治局应当为贝拉·比斯库集团平反，\n使他们重返党内并恢复职务，并让贝拉进入他们的队伍。\n此举引发匈牙利领导人的强烈抗议。\n经过一番冗长的口舌交锋，最终只达成了折中方案——比斯库的若干\n同僚被吸纳进中央委员会，匈牙利获得15亿美元贷款。\n这样一来，匈牙利得以避免立刻违约，但仍不得不向国际货币基金组\n织（IMF）再借一笔新贷款。\n多亏了我们，HSWP内部现在出现了左翼反对派，\n但要完成最终登记还需要很长时间……\n此外，苏联对我们干涉其势力范围极为不满。";
					GlobalScript.inst.gameState.data[8] -= 150;
					GlobalScript.inst.gameState.data[9] -= 80;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "他在北京召见匈牙利人民共和国驻华大使，\n并交给他一封写给亚诺什·卡达尔的信：\n信中提出由匈牙利人民共和国把对中国的国家债务接下，\n以避免违约，并发放一笔无息45亿美元贷款——但作为交换条件，\n是为贝拉·比斯库集团平反，并将比斯库吸纳进匈牙利社会主义工人\n党（HSWP）中央委员会政治局。\n同时，我们的特工还煽动“工人警察”部队（HSWP的准军事组织，\n其中存在某些左翼保守情绪）的骚乱，\n并向匈牙利改革的首席意识形态负责人——莱斯·内尔绍（莱斯·内\n尔绍是有经验的社会民主党人，曾在伊姆雷·纳吉政府中担任部长）\n泼脏水。卡达尔意识到拒绝帮助中国可能引发新的1956年，\n只得被迫同意。在我们的帮助下，贝拉·比斯库很快组织起左翼反对\n派，格尔舒不得不退出政治。\n看来HSWP内部又将出现新的分裂，而这只能靠“活着的卡达尔”\n暂时压住……|在左翼反对派的压力下，\n并希望至少保住党外部的统一，卡达尔宣布匈牙利的“多维向”外交\n政策，开始同我们建立文化与贸易关系。\n苏联和美国勃然大怒，而我们在欧洲的影响力也得到了加强。\n不过，我们现在必须履行匈牙利的债务义务……";
					GlobalScript.inst.gameState.data[8] -= 450;
					GlobalScript.inst.gameState.data[9] -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support--;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 200;
					GlobalScript.inst.gameState.allcountries[4].prosov = false;
					GlobalScript.inst.gameState.allcountries[4].Torg = true;
					GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "我们丝毫没有干涉匈牙利的事务。\n该国通过向IMF再借新贷款，得以避免违约，\n只是把负面趋势拖延了——拖延了很久，\n以至于我们无法再对其施加影响。\n|“与此同时，据匈牙利同志所说，匈牙利应当深化其参与国际合作，\n以免去发明那些早已在其他国家被发现的东西。\n”";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 6)
				{
					text = "通过幕后与政治局的某些成员进行谈判，\n我们终于说服他们：只有在中国的帮助下，\n他们才能从由卡达尔政府与格罗什政府共同挖出的债务深坑中爬出来。\n最终，他们同意我们的提议：召开紧急党代会、\n批判格罗什，以便用伊姆雷·波兹盖取代卡罗伊·格罗什。\n结果，亚诺什·卡达尔从名义上的MSZMP主席位置上退下，\n卡罗伊·格罗什接替了他的位置。\n真正掌控国家的人变成了总书记伊姆雷·波兹盖——他明白自己的位\n置欠了谁的情，也清楚匈牙利的债务义务握在谁的手里。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 250;
					GlobalScript.inst.gameState.allcountries[4].isMonatchy = true;
					GlobalScript.inst.gameState.allcountries[4].Torg = true;
					GlobalScript.inst.gameState.allcountries[4].proprc = true;
					GlobalScript.inst.gameState.data[9] -= 80;
					GlobalScript.inst.gameState.data[8] -= 450;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 82)
			{
				text2 = "福克兰群岛战争";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "4月3日，联合国安理会通过第502号决议，\n要求阿根廷军队撤出群岛。\n但尽管如此，似乎没有人相信英国会赢。\n也许我们应该帮助阿根廷——即便那里有残酷的反共独裁者——再一\n次打击殖民主义？";
					GlobalScript.inst.gameState.ingamewars[6].name_war = "福克兰群岛战争";
					GlobalScript.inst.gameState.ingamewars[6].is_going = true;
					GlobalScript.inst.gameState.ingamewars[6].side1 = "Argentina";
					GlobalScript.inst.gameState.ingamewars[6].side2 = "The UK";
					GlobalScript.inst.gameState.ingamewars[6].ussr_place = -1;
					GlobalScript.inst.gameState.ingamewars[6].usa_place = 1;
					GlobalScript.inst.gameState.ingamewars[6].infl1 = 400;
					GlobalScript.inst.gameState.ingamewars[6].infl2 = 600;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 83)
			{
				text2 = "斯塔夫罗波尔农学家之难";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "《人民报》今天刊出一篇文章《苏共中央政治局的改革者》，\n文中把费奥多尔·库拉科夫称为“马克思主义的分权派、\n铁托式的‘共产党’，是整个国际共产主义与工人运动的危险敌人”。\n文章特别强调：库拉科夫很可能在列昂尼德·勃列日涅夫去世后领\n导苏联。与此同时，我们的特工部门也在苏共中央内部安排了关于库\n拉科夫改革野心的“泄密”。\n在苏共中央七月（1977年）全会上，\n费奥多尔·库拉科夫遭到批判，并被剥夺全部职务。\n他患有急性胃病，导致神经系统衰弱；1977年7月17日晚，\n他突然死于心脏麻痹。\n就这样，我们大大削弱了苏共中央的改革派力量……";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[9] -= 50;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support--;
					GlobalScript.inst.gameState.data[149] = 1;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.empires[1].relations >= 500)
					{
						text = "我们在媒体上组织了一场大规模抹黑库拉科夫的运动。\n他被贴上“贪腐分子、官僚、铁托式、（逗号处原文有缺漏）\n野心家、机会主义者、苏共中央和中共最凶恶的敌人、\n披着羊皮的狼”等标签。\n主席同志在一次讲话中还简短提到：如果“像费奥多尔·库拉科夫这\n样的人将领导苏联——我们就不必跟他们谈任何事情，\n因为他们对我们、对中国共产党、对中国人民怀有偏见”。\n这引起了苏共中央的强烈怀疑。\n库拉科夫被召到党内监察委员会，接受委员会负责人阿尔维德·佩尔\n舍的谈话。他与拥有至高权力的克格勃头子尤里·安德罗波夫联手，\n得以突破政治局关于任命库拉科夫为摩尔达维亚共产党中央委员会第\n一书记的决定——实际上是“光荣流放”。\n库拉科夫的提名人已经开始从岗位上被撤下，\n并调到更低的位置。于是，他不再是障碍……";
						GlobalScript.inst.gameState.data[1] += 50;
						GlobalScript.inst.gameState.data[8] -= 20;
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
						leader.support--;
						GlobalScript.inst.gameState.data[149] = 1;
					}
					else
					{
						text = "我们在媒体上组织了一场大规模抹黑库拉科夫的运动。\n他被贴上“贪腐分子、官僚、铁托式、（逗号处原文有缺漏）\n野心家、机会主义者、苏共中央和中共最凶恶的敌人、\n披着羊皮的狼”等标签。\n主席同志在一次讲话中还简短提到：如果“像费奥多尔·库拉科夫这\n样的人将领导苏联——我们就不必跟他们谈任何事情，\n因为他们对我们、对中国共产党、对中国人民怀有偏见”。\n然而，库拉科夫得知此事后并没有按我们的计划失去理智，\n而是在苏共中央全会上作了一篇慷慨激昂的发言：\n他指控中国“散布对列宁主义中央委员会的诽谤、\n毛主义霸权、企图分裂苏共中央并建立一个替代的毛主义‘假党’，\n在苏联进行悄无声息的反革命，并占领西伯利亚和远东”。\n凭借他那种粗糙的谎言，他吓住了包括勃列日涅夫在内的多数政治局\n成员，并为自己洗清了嫌疑。";
						GlobalScript.inst.gameState.data[8] -= 20;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "什么也没有发生。库拉科夫继续占着岗位，\n向党内最高层的改革派靠拢——由他在斯塔夫罗波尔地区的盟友米哈\n伊尔·戈尔巴乔夫领衔。";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 84)
			{
				text2 = "我们的老游击队员……";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "14时35分，彼得·马谢罗夫乘坐GAZ-13“海鸥”轿车离开\n白俄罗斯共产党（CPB）中央委员会大楼，\n前往日尔季诺市。驾驶员是60岁的E·扎伊采夫。\n马谢罗夫坐在驾驶员旁边，后排是安全官员中校V·F·切斯诺科夫。\n与既有指示相反，并没有配备相应涂装和警灯闪烁的GAI警车护\n送；而是一辆白色“伏尔加”，装有警报扩音装置，\n但没有闪灯。在“莫斯科—明斯克”公路上，\n靠近斯莫列维奇市附近的通往家禽农场的转弯处，\n“海鸥”被一辆装满土豆的自卸卡车GAZ-SAZ-53B撞上，\n卡车由司机N·普斯托维特驾驶。\n无人幸免——马谢罗夫、他的司机和警卫当场死亡，\n卡车司机则因失血过多在前往医院途中死亡。\n苏联总检察院进行了调查，排除了犯罪的故意性质。\n克格勃对此不认同，坚持认为有外国情报机构参与。\n在检察机关（得到内务部支持）与克格勃的冲突过程中，\n马谢罗夫过度的改革倾向被揭露出来，迫使克格勃让步，\n并使安德罗波夫在党内机关中的影响力有所下降。";
					GlobalScript.inst.gameState.data[9] -= 80;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support -= 2;
					GlobalScript.inst.gameState.data[149] = 2;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.empires[1].relations >= 500)
					{
						text = "我们的特工同季霍恩·基谢廖夫取得联系——他是白俄罗斯苏维埃社\n会主义共和国（BSSR）部长会议主席；\n同时也与对马谢罗夫政策不满的白俄罗斯党内成员结成了同盟——并\n向他提供了关于马谢罗夫的“脏料”（例如：\n他赞同柯西金的经济改革，并要求建立一种能够刺激企业经济利益的\n计划体系。原因在于他希望逐步摆脱经济管理中的行政命令方式。\n此外，马谢罗夫还主导让BSSR定期就国民经济各类问题举办研讨\n会，而这些并未得到苏共中央的同意）。\n基谢廖夫身兼苏联部长会议副主席，便与米哈伊尔·苏斯洛夫会面，\n并把这些信息转交给他。\n马谢罗夫被召到莫斯科，遭到批判，被剥夺职务并被打发到离休岗位。";
						GlobalScript.inst.gameState.data[8] -= 50;
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
						leader.support--;
						GlobalScript.inst.gameState.data[149] = 2;
					}
					else
					{
						text = "我们的特工同季霍恩·基谢廖夫取得联系——他是白俄罗斯苏维埃社\n会主义共和国（BSSR）部长会议主席；\n同时也与对马谢罗夫政策不满的白俄罗斯党内成员结成了同盟——并\n向他提供了关于马谢罗夫的“脏料”（例如：\n他赞同柯西金的经济改革，并要求建立一种能够刺激企业经济利益的\n计划体系。原因在于他希望逐步摆脱经济管理中的行政命令方式。\n此外，马谢罗夫还主导让BSSR定期就国民经济各类问题举办研讨\n会，而这些并未得到苏共中央的同意）。\n然而，他不敢把这些材料交给苏斯洛夫，\n结果马谢罗夫仍然留任。";
						GlobalScript.inst.gameState.data[8] -= 50;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "14时35分，彼得·马谢罗夫乘坐GAZ-13“海鸥”轿车离开\n白俄罗斯共产党（CPB）中央委员会大楼，\n前往日尔季诺市。驾驶员是60岁的E·扎伊采夫。\n马谢罗夫坐在驾驶员旁边，后排是安全官员中校V·F·切斯诺科夫。\n与既有指示相反，并没有配备相应涂装和警灯闪烁的GAI警车护\n送；而是一辆白色“伏尔加”，装有警报扩音装置，\n但没有闪灯。在“莫斯科—明斯克”公路上，\n靠近斯莫列维奇市附近的通往家禽农场的转弯处，\n“海鸥”被一辆装满土豆的自卸卡车GAZ-SAZ-53B撞上，\n卡车由司机N·普斯托维特驾驶。\n无人幸免——马谢罗夫、他的司机和警卫当场死亡，\n卡车司机则因失血过多在前往医院途中死亡。\n苏联总检察院会同苏联克格勃进行了调查，\n排除了犯罪的故意性质。\n调查小组认定：装土豆卡车的司机应负主要责任。";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 85)
			{
				text2 = "哈萨克斯坦的德意志自治";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "6月16日，齐林诺格勒、科克切塔夫和卡拉干达三地爆发了哈萨克\n族民众针对给予德意志少数民族自治权的群众抗议。\n抗议者举着写有“我们的土地对每个人都是统一的、\n不可分割的！”的标语，并高喊“反对在埃尔门套设立德意志自治州！\n”。第一次抗议后三天，在齐林诺格勒郊外，\n来自周边各条街道的人群再次集结，要求回答“哈萨克人在自己的土\n地上将遭遇怎样的命运？\n”以及“自治又将如何？\n”等问题。哈萨克苏维埃社会主义共和国的领导层和执法机构暗中支\n持示威者，并未阻止在宿舍区散发号召参加抗议集会的传单。\n我们利用了这一点，并正式公开了这一事实，\n指控库奈耶夫“新法西斯主义”和“违反列宁民族政策原则”。\n通过MSS（国家安全机构）还汇总了大量与其随从有关、\n涉嫌腐败的“妥协材料”。\n12月16日，在创纪录的哈萨克斯坦中央委员会全体会议上（仅持\n续18分钟），丁穆哈迈德·库奈耶夫被撤去哈萨克斯坦中央委员会\n第一书记职务并办理退休。\n由技术官僚贝肯·阿希莫夫当选为哈萨克苏维埃社会主义共和国部长\n会议主席。";
					GlobalScript.inst.gameState.data[9] -= 100;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support--;
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[149] = 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.empires[1].relations >= 500)
					{
						text = "我们紧急向苏共中央送交了关于哈萨克苏维埃社会主义共和国即将发\n生的动乱的全部情报，并指出这牵涉到该共和国的整个党内精英。\n我们的警告被采纳了：因此在6月16日，\n齐林诺格勒、科克切塔夫和卡拉干达部署了苏联内务部内卫部队的单\n位，阻止了示威活动。\n库奈耶夫被召到莫斯科；在与阿尔维德·佩尔舍和米哈伊尔·苏斯洛\n夫会谈后，他写下声明，要求因“健康状况”解除其所有职务。";
						GlobalScript.inst.gameState.data[9] -= 30;
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
						leader.support--;
						GlobalScript.inst.gameState.data[149] = 3;
					}
					else
					{
						text = "我们紧急向苏共中央送交了关于哈萨克苏维埃社会主义共和国即将发\n生的动乱的全部情报，并指出这牵涉到该共和国的整个党内精英。\n然而，我们的警告被置之不理。\n6月16日，齐林诺格勒、科克切塔夫和卡拉干达三地爆发了哈萨克\n族民众针对给予德意志少数民族自治权的群众抗议。\n抗议者举着写有“我们的土地对每个人都是统一的、\n不可分割的！”的标语，并高喊“反对在埃尔门套设立德意志自治州！\n”。结果，当局同意了示威者的要求，\n并宣布：哈萨克斯坦的德意志自治问题已彻底从议程中取消。";
						GlobalScript.inst.gameState.data[9] -= 30;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "6月16日，在采利诺格勒、科克切塔夫和卡拉干达三座城市，\n哈萨克族群众开始了针对给予德意志少数民族自治权的群众性抗议。\n抗议者举着写有“我们的土地，归全体所有，\n统一而不可分割！”的标语，并高喊口号：\n“反对在厄尔门套设立德意志自治区！\n”结果，当局同意了示威者的要求，并宣布：\n哈萨克斯坦的德意志自治问题已被彻底从议程中撤下。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "我们的调查揭露了乌兹别克斯坦第一书记拉希多夫团队的严重失职：\n通过伪造石块和瓦砾来虚报棉花收购/产量指标、\n猖獗的任人唯亲，以及用公羊和汽车行贿。\n部分同伙在莫斯科检查期间把黄金藏在家中。\n包括照片、匿名采访和统计材料在内的证据，\n已通过我方使馆提交给苏联部长会议。\n为揭露拉希多夫，我们把这些信息通过中国报纸广为散布，\n甚至传到“自由欧洲电台”和“美国之音”。\n这使苏联领导层失去了掩盖案件的机会。\n调查结果导致苏联各加盟共和国普遍开展大规模检查，\n并在数个国家出现了党内的典型开除处分。\n拉希多夫被撤换后，年轻且经验丰富的工业组织者阿基尔·萨利莫夫\n出任中共乌兹别克加盟共和国（CPUz）\n新的第一书记。在摩尔达维亚，第一书记伊万·博迪乌尔因重大诈骗\n案被发现后以失职为由遭到撤职；他在农业—工业综合体中的“摩尔\n达维亚经验”被认定为无效。\n然而并未出现特别的人事大调整，原部长会议主席谢苗·格罗斯乌接\n过领导权。阿塞拜疆的腐败和任人唯亲导致阿利耶夫及阿塞拜疆苏维\n埃社会主义共和国各部部长和克格勃负责人辞职。\n取而代之的是由阿卜杜拉赫曼·韦齐罗夫领导的阿塞拜疆共产党人—\n—他曾被阿利耶夫以“驻外大使”名义送去政治流放。\n如今他们试图借助“软实力”来调整国家机关的运转。\n由穆哈梅德纳扎尔·加普罗夫担任的土库曼苏维埃社会主义共和国领\n导层因腐败和挪用公款被停职并开除。\n前外交部长、地质以及天然气与石油生产方面的专家纳扎尔·苏尤莫\n夫出任领导，并开始把经济重新导向天然气与石油工业的发展。\nRSFSR加盟共和国内部开展了审计，\n而围绕苏联领导问题的全球讨论反倒对我们有利。";
					GlobalScript.inst.gameState.data[8] -= 30;
					GlobalScript.inst.gameState.data[9] -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 300;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 30;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 86)
			{
				text2 = "“铁腕尤里”的终结";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "当勃列日涅夫动身前往维也纳会谈时，饱受长期折磨的肾病又发作的\n尤里·安德罗波夫则去克里米亚治病。\n然而这是一趟“单程票”——在克里米亚，\n他受了风寒，最终病情恶化：他得了蜂窝织炎（纤维组织的化脓性炎\n症），全身状况急剧下滑。\n手术虽然成功，但术后伤口不愈。\n身体极度虚弱，已无法抵抗中毒。\n安德罗波夫陷入昏迷，之后再也没有醒来。\n1979年7月9日，苏联克格勃主席去世。\n知情人士说：“安德罗波夫不必去谢尔比茨基的农场。\n他也有他的骄傲和他的克格勃。\n”苏联统一克格勃的新负责人是谢苗·茨维贡，\n他开始在“办公室”里搞大规模清洗；而原安德罗波夫系的人被大量\n替换为来自乌克兰苏维埃社会主义共和国克格勃的工作人员。\n这进一步巩固了弗拉基米尔·谢尔比茨基的影响力——如今他已成了\n列昂尼德·勃列日涅夫的事实上的唯一接班人。\n对我们来说……这样也好……";
					GlobalScript.inst.gameState.data[9] -= 100;
					GlobalScript.inst.gameState.data[8] -= 50;
					GlobalScript.inst.gameState.empires[1].leaders[3].support = -100;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[1];
					leader.support += 10;
					GlobalScript.inst.gameState.data[1] += 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.empires[1].relations >= 400)
					{
						text = "维也纳传来消息：列昂尼德·勃列日涅夫抵达奥地利首都——苏联克\n格勃第八总局奉委员会第一副主席谢苗·茨维贡之命，\n切断了政府通信，从而使总书记与来自苏联的情报完全隔绝。\n与此同时，在克格勃内部反对派的帮助下，\n米哈伊尔·苏斯洛夫和弗拉基米尔·谢尔比茨基迅速召集紧急中央委\n员会全会。在会上，尤里·安德罗波夫被指控“把克格勃变成私人店\n铺、准备反政府政变、与美国中央情报局及以色列情报机构勾连、\n诬陷费奥多尔·库拉科夫和彼得·马舍罗夫”等等。\n我们迅速组织对全会的信息支援，借助刊发关于安德罗波夫的“揭密\n材料”给火上浇油。克格勃头目试图抵抗，\n但在弗拉基米尔·谢尔比茨基的发言中——他直接指控安德罗波夫准\n备谋杀勃列日涅夫——对方这才意识到自己已经输了。\n全会通过决议：撤销安德罗波夫所有职务，\n将其开除出党并逮捕。\n苏联克格勃新主席是乌克兰克格勃负责人维塔利·费多尔丘克，\n他开始对安德罗波夫系人员进行大规模清洗，\n并用经验证的共和国党委工作人员替换他们。\n也许我们在苏联最危险的敌人，如今已被彻底中和……";
						GlobalScript.inst.gameState.data[8] -= 70;
						GlobalScript.inst.gameState.empires[1].leaders[3].support = -100;
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[1];
						leader.support += 10;
					}
					else
					{
						text = "维也纳传来消息：列昂尼德·勃列日涅夫抵达奥地利首都——苏联克\n格勃第八总局奉委员会第一副主席谢苗·茨维贡之命切断政府通信，\n使总书记与来自苏联的情报完全隔绝。\n与此同时，在克格勃内部反对派的帮助下，\n米哈伊尔·苏斯洛夫和弗拉基米尔·谢尔比茨基迅速召集紧急中央委\n员会全会。在会上，尤里·安德罗波夫被指控“把克格勃变成私人店\n铺、准备反政府政变、与美国中央情报局及以色列情报机构勾连、\n诬陷费奥多尔·库拉科夫和彼得·马舍罗夫”等等。\n我们迅速组织对全会的信息支援，借助刊发关于安德罗波夫的“揭密\n材料”给火上浇油。然而，安德罗波夫稳住阵脚，\n依靠其在共产党中央委员会中的支持者以及忠诚的安全部门人员，\n宣布苏斯洛夫和谢尔比茨基为“第二个反党集团”，\n把全会变成对他们的“审判”。\n结果是：苏斯洛夫和谢尔比茨基被开除出苏共，\n安德罗波夫则乘势上台——他成为苏共第二书记，\n并成为列昂尼德·勃列日涅夫的事实接班人。\n勃列日涅夫已被告知一切，并支持他的行动。";
						GlobalScript.inst.gameState.data[8] -= 70;
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
						leader.support += 2;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "什么也没有发生。尤里·安德罗波夫逐步清除克格勃中的对手，\n加强苏共中央委员会的影响力，成为列昂尼德·勃列日涅夫的事实接\n班人，并推动像叶戈尔·利加乔夫、米哈伊尔·戈尔巴乔夫和弗拉基\n米尔·多尔吉赫这样的改革派党内人士。";
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support += 2;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 87)
			{
				text2 = "加利利的和平";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "以色列宣布启动代号“加利利的和平”行动。\n根据以色列代表的说法，该行动目的在于消灭巴解组织（PLO）\n的据点，并在黎巴嫩南部建立非军事区。\n以色列表示不会袭击驻黎巴嫩的叙利亚武装力量集团；\n叙利亚本身也克制地没有交火。\n但考虑到叙利亚控制了黎巴嫩相当大的一部分地区，\n双方与以色列国防军（IDF）之间的冲突似乎只是时间问题。\n值得注意的是，传统上支持以色列的美国反应相当克制，\n并没有特别欣赏它的“维和”冲动。";
					GlobalScript.inst.gameState.ingamewars[4].name_war = "黎巴嫩战争";
					GlobalScript.inst.gameState.ingamewars[4].is_going = true;
					GlobalScript.inst.gameState.ingamewars[4].side1 = "Israeil";
					GlobalScript.inst.gameState.ingamewars[4].side2 = "PLO";
					GlobalScript.inst.gameState.ingamewars[4].ussr_place = 1;
					GlobalScript.inst.gameState.ingamewars[4].usa_place = 0;
					GlobalScript.inst.gameState.ingamewars[4].infl1 = 650;
					GlobalScript.inst.gameState.ingamewars[4].infl2 = 350;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 88)
			{
				GlobalScript.inst.gameState.allcountries[52].SubGosstroy = 10;
				text2 = "津巴布韦种族隔离的终结";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们已同穆加贝政府建立外交关系，并表示愿意发展中津之间的紧密\n合作；以物质援助来强化我们的善意。\n穆加贝欣然接受，并表示准备进行全面合作。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.data[8] -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 15;
					GlobalScript.inst.gameState.allcountries[52].proprc = true;
					GlobalScript.inst.gameState.allcountries[52].Torg = true;
					GlobalScript.inst.gameState.allcountries[52].name = GlobalScript.inst.new_events_text[799];
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们与新政府的互动仅限于建立外交关系。\n没有发生什么特别的事。";
					GlobalScript.inst.gameState.allcountries[52].name = GlobalScript.inst.new_events_text[799];
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 89)
			{
				text2 = "一个时代的结束";
				int num28 = -1;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "";
					num28 = 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "";
					num28 = 1;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "";
					num28 = 2;
				}
				if (num28 >= 0)
				{
					if (GlobalScript.inst.gameState.gamerules[3] == 2)
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num28];
						leader.support += 200;
					}
					else
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num28];
						leader.support += 2;
						GlobalScript.inst.gameState.data[9] -= 100;
					}
					if (GlobalScript.inst.gameState.relres)
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num28];
						leader.support++;
					}
					if (GlobalScript.inst.gameState.allcountries[7].Torg || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num28];
						leader.support++;
					}
					if (GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num28];
						leader.support++;
					}
				}
				if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 1)
				{
					Leader[] leaders = GlobalScript.inst.gameState.empires[1].leaders;
					foreach (Leader leader2 in leaders)
					{
						Leader leader = leader2;
						leader.support += UnityEngine.Random.Range(-10, 11);
					}
				}
				if (GlobalScript.inst.gameState.empires[1].leaders[2].support >= GlobalScript.inst.gameState.empires[1].leaders[3].support && GlobalScript.inst.gameState.empires[1].leaders[2].support >= GlobalScript.inst.gameState.empires[1].leaders[1].support)
				{
					text = "结果，康斯坦丁·切尔年科当选为苏共中央委员会总书记。\n许多人认为他是个便于折中的人物，能够让联盟避免大规模变动与动\n荡，看来他也将满足他们的期待。";
					GlobalScript.inst.gameState.empires[1].now_leader = 2;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
					leader.support++;
					leader = GlobalScript.inst.gameState.empires[1].leaders[5];
					leader.support++;
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[1].support >= GlobalScript.inst.gameState.empires[1].leaders[2].support && GlobalScript.inst.gameState.empires[1].leaders[1].support >= GlobalScript.inst.gameState.empires[1].leaders[3].support)
				{
					text = "结果，弗拉基米尔·谢尔比茨基当选为苏共中央委员会总书记。\n这并不意外——在苏斯洛夫的支持和勃列日涅夫的信任下，\n他除掉了安德罗波夫，成为该职位的主要竞争者。\n看来苏联还将等待几年的稳定。";
					GlobalScript.inst.gameState.empires[1].now_leader = 3;
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[3].support >= GlobalScript.inst.gameState.empires[1].leaders[2].support && GlobalScript.inst.gameState.empires[1].leaders[3].support >= GlobalScript.inst.gameState.empires[1].leaders[1].support)
				{
					text = "结果，尤里·安德罗波夫当选为苏共中央委员会总书记。\n在克格勃领导的岁月里，他把巨大的权力集中于手中，\n正是凭借这股力量他赢得了这场斗争。\n许多人认为他是务实而强硬的统治者——而这正是苏联如今所必需的。";
					GlobalScript.inst.gameState.empires[1].now_leader = 1;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support += 2;
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[2].support >= GlobalScript.inst.gameState.empires[1].leaders[3].support)
				{
					text = "结果，康斯坦丁·切尔年科当选为苏共中央委员会总书记。\n许多人认为他是个便于折中的人物，能够让联盟避免大规模变动与动\n荡，看来他也将满足他们的期待。";
					GlobalScript.inst.gameState.empires[1].now_leader = 2;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
					leader.support++;
					leader = GlobalScript.inst.gameState.empires[1].leaders[5];
					leader.support++;
				}
				else
				{
					text = "结果，尤里·安德罗波夫当选为苏共中央委员会总书记。\n在克格勃领导的岁月里，他把巨大的权力集中于手中，\n正是凭借这股力量他赢得了这场斗争。\n许多人认为他是务实而强硬的统治者——而这正是苏联如今所必需的。";
					GlobalScript.inst.gameState.empires[1].now_leader = 1;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support += 2;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 90)
			{
				text2 = "香港再见，澳门再会？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在特工部门、国有企业以及亲华游说组织的帮助下，\n我们得以同三大“青帮”集团——“14K”“新义安”和“和胜和\n”建立联系。他们从我们这里获得了关于其成员与资产不可侵犯的保\n证，并得到一项在我国经济中进行高收益投资的提议（尤其是麻黄草\n生产），条件极为优厚。\n三大帮派的头目早已准备把核心转移到美国，\n对我们的提议表示同意。\n他们开始在我国南方省份大举投资，并利用影响力去中和反对中国统\n一者的行动（例如，批评性材料从媒体上消失；\n在腐败警察的默许下，所有抗议都被青帮成员迅速驱散；\n还有一批商人从香港和澳门移民）。\n因此，我们如今既有帮派的支持，也迎来了犯罪世界与腐败势力日益\n增长的影响。";
					GlobalScript.inst.gameState.data[9] -= 40;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[8] += 100;
					GlobalScript.inst.gameState.data[26] += 150;
					GlobalScript.inst.gameState.modifies[5].active = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.data[6] > 300 && GlobalScript.inst.gameState.data[14] < 3)
					{
						text = "我们已同三大“青帮”集团——“14K”“新义安”和“和胜和”\n建立联系。他们从我们这里获得了关于其成员与资产不可侵犯的保证，\n但这些条件并不符合他们管理层的口味。\n谈判最终无果而终，不过在中间情报部门（MSS）\n的帮助下，这件事本身还是泄露到了香港和澳门的媒体上，\n吓坏了当地不满者。许多人决定不冒险，\n选择了移民。可以说这是我们的一部分成功，\n尽管在1997年之后，我们仍得认真对付这些青帮。";
						GlobalScript.inst.gameState.data[9] -= 20;
						GlobalScript.inst.gameState.data[3] -= 50;
						GlobalScript.inst.gameState.data[6] += 20;
					}
					else
					{
						text = "我们已同三大“青帮”集团——“14K”“新义安”和“和胜和”\n建立联系。他们从我们这里获得了关于其成员与资产不可侵犯的保证，\n并得到了他们领导层的同意。\n他们利用影响力去中和反对中国统一者的行动（例如，\n批评性材料从媒体上消失；在腐败警察的默许下，\n所有抗议都被青帮成员迅速驱散；还有一批商人从香港和澳门移民）。\n然而，MSS不允许青帮在我国南方省份站稳脚跟；\n在1997年之后，我们将对他们展开系统性的斗争。";
						GlobalScript.inst.gameState.data[9] -= 20;
						GlobalScript.inst.gameState.data[3] -= 50;
						GlobalScript.inst.gameState.data[6] += 20;
						GlobalScript.inst.gameState.data[26] += 80;
						GlobalScript.inst.gameState.data[8] += 50;
						GlobalScript.inst.gameState.modifies[5].active = true;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "彻底拒绝与香港犯罪集团进行任何谈判。\n此后，在香港和澳门发生了一系列反华事件，\n一场系统性的运动开始抹黑关于将其移交给中国的协议，\n最终以大规模的暴乱以及英国和葡萄牙议会决定拒绝批准该协议而告\n终。";
					GlobalScript.inst.gameState.data[65] = 0;
					if (GlobalScript.inst.gameState.allcountries[51].Torg || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						text += "不过，我们的朋友对他们施加了压力，并促使英方与葡方履行其义务。\n香港与澳门将按既定安排分别于1997年和1999年回归。";
						GlobalScript.inst.gameState.data[65] = 1;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "“要么共产党战胜腐败，要么腐败战胜共产党”——同志主席在政治\n局会议上宣告。中华人民共和国公安部和中共中央纪律检查委员会已\n启动大规模行动，打击紧邻香港与澳门的中国南方省份以及最近新开\n放的经济特区中的腐败精英。\n数百名各级干部被撤职，数千人被开除出党，\n数以百万计从国家窃取的资金被没收；成都市市长陈希同（“中国格\n里申”）因从群众手中偷走数十亿元并为自己建造豪华别墅，\n被判处枪决。这彻底打乱了所有腐败分子的体系，\n使我们得以在一定程度上扭转局面，并切断我方精英与澳门、\n香港同行之间的腐败联系。\n后者“以防万一”移民。";
					GlobalScript.inst.gameState.data[8] += 40;
					GlobalScript.inst.gameState.data[9] -= 80;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[26] -= 150;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 91)
			{
				text2 = "仰光轰炸";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "针对这些事件，整个“文明世界”都爆发出对朝鲜民主主义人民共和\n国（DPRK）的愤怒发言。\n我们没有发表官方声明，但《人民日报》上刊登了一篇对朝鲜恐怖手\n段进行严厉谴责的文章。\n与此同时，在两朝边境，双方都发生了数起武装挑衅……";
					GlobalScript.inst.gameState.data[6] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "针对这些事件，整个“文明世界”都爆发出对朝鲜民主主义人民共和\n国（DPRK）的愤怒发言。\n我们完全支持朝鲜方面的立场，称这起事件是南朝鲜的挑衅并予以谴\n责。与此同时，在两朝边境，双方都发生了数起武装挑衅……";
					GlobalScript.inst.gameState.data[6] += 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 80;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "针对这些事件，整个“文明世界”都爆发出对朝鲜民主主义人民共和\n国（DPRK）的愤怒发言。\n与此同时，在两朝边境，双方都发生了数起武装挑衅……";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 92)
			{
				text2 = "超额完成是光荣！";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "中国政府决定追加资金，用于轻重工业现代化，\n提高产品质量并更新设备。\n新的五年计划的主要方向是发展工业。";
					GlobalScript.inst.gameState.data[102] = 1;
					GlobalScript.inst.gameState.data[8] -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "中国政府决定拨款用于农业机械化以及引进新技术。\n新的五年计划的主要优先事项宣布为农业。";
					GlobalScript.inst.gameState.data[102] = 2;
					GlobalScript.inst.gameState.data[8] -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "中国政府决定提高服务业的服务质量，并从预算中追加拨款。\n五年计划的首要目标被宣布为服务业现代化。";
					GlobalScript.inst.gameState.data[102] = 3;
					GlobalScript.inst.gameState.data[8] -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "中国政府公布了本五年计划的经济发展方案，\n指出必须加快科学技术进步，并引入管理国民经济的新方法。\n新的五年计划的优先领域成为科学。";
					GlobalScript.inst.gameState.data[102] = 4;
					GlobalScript.inst.gameState.data[8] -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "尽管国家计划委员会提出了建议，中国政府仍宣布必须实现国民经济\n各部门的均衡发展，并从国家预算中追加拨款";
					GlobalScript.inst.gameState.data[102] = 5;
					GlobalScript.inst.gameState.data[8] -= 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 93)
			{
				text2 = "民主的故乡";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们的特工部门协助PASOK开展竞选活动，\n并积极破坏“新民主党”的竞选。\n与此同时，他们还成功促成由PASOK、\n希腊共产党（CPG）及其他左翼政党组成的左翼联盟。\n结果，左翼联盟赢得选举，组建了该国历史上第一个社会主义政府。\n在我们和苏联的支持下，它完成了希腊正式退出北约的进程，\n并阻止了欧洲一体化进程";
					GlobalScript.inst.gameState.data[6] += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.allcountries[45].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[45].SubGosstroy = 3;
					GlobalScript.inst.gameState.allcountries[45].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[45].isNATO = false;
					Country country2 = GlobalScript.inst.gameState.allcountries[87];
					country2.spec -= 5;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 50;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们的特工部门协助“新民主党”开展竞选，\n并积极破坏PASOK的竞选。\n他们还设法促成一些小型右翼政党加入“新民主党”领导的联盟，\n从而共同使其在选举中获胜。\n新政府打算继续推进旨在确保希腊加入欧洲共同体（EEC）\n的经济改革，并恢复该国在北约中的活动。";
					GlobalScript.inst.gameState.data[6] -= 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 80;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
					Country country2 = GlobalScript.inst.gameState.allcountries[87];
					country2.spec += 5;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "结果，“新民主党”以微弱优势赢得选举。\n新政府打算继续推进旨在确保希腊加入欧洲共同体（EEC）\n的经济改革，并恢复该国在北约中的活动。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 94)
			{
				text2 = "天安门事件。又来？！";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在中共中央政治局紧急会议上，所发生的事件被定性为“受美国和台\n湾特务指使的反革命暴乱”，随后以多数票决定强行镇压。\n根据解放军总参谋长杨德志将军的命令，\n部队在北京增援了坦克和装甲运兵车，但当他们推进到广场时，\n遭遇路障以及手持“莫洛托夫鸡尾酒”的暴徒顽强抵抗。\n在装甲车辆的支援下，路障被冲破；随后，\n部分解放军击溃了抗议者的主要营地并清理了天安门广场，\n对工人和学生宿舍的搜查/清剿行动又持续了数天。\n于是局势被控制住了。\n“退党”（Tuidang）运动被取缔，" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + "他和他的支持者被撤职并逐出中共，打击改革开放的反对者的逮捕行\n动开始，方励之逃往美国。\n西方国家宣称我们的政权是“血腥暴政”，\n苏联及其盟友却保持沉默。\n有组织的抗议运动被镇压，不满者纷纷潜伏地下。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 150;
					GlobalScript.inst.gameState.data[57] -= 150;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[4] -= 250;
					GlobalScript.inst.gameState.data[6] += 80;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (GlobalScript.inst.gameState.data[3] >= 600 && GlobalScript.inst.gameState.data[4] < 500)
					{
						text = "为防止抢劫，北京市市长下令将人民武装警察的加固装甲运兵车部队\n开进城内，封锁天安门广场，并把抗议者从相邻街道驱赶出去（同时\n在被“莫洛托夫鸡尾酒”点燃的技术装备上遭受重大损失）。\n随后，主席同志亲自对示威者讲话，劝其散去。\n相当一部分人离开了广场，剩下的则被警察以催泪瓦斯和鸣枪驱散。\n首都秩序恢复了，但骚乱却蔓延到上海、\n宁波以及其他数座城市……";
						GlobalScript.inst.gameState.data[4] += 250;
						GlobalScript.inst.gameState.data[3] -= 100;
						GlobalScript.inst.gameState.data[57] -= 250;
					}
					else
					{
						text = "为防止抢劫，北京市市长下令将人民武装警察的加固装甲运兵车部队\n开进城内，封锁天安门广场，并把抗议者从相邻街道驱赶出去（同时\n在被“莫洛托夫鸡尾酒”点燃的技术装备上遭受重大损失）。\n人群用口哨和叫喊声迎接主席，迫使他仓促退却。\n中共中央政治局紧急会议决定：向示威者作出让步，\n并让党的领导层辞职。\nСomrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + "成为新的总书记，宣告实行深化改革、在全国范围内大规模推进民主\n化的政策。大多数示威者散去，对此感到满意；\n其余的则被人民武装警察驱逐。\n中国正在等待变化……";
						GlobalScript.inst.gameState.data[3] += 90;
						GlobalScript.inst.gameState.data[6] -= 50;
						GlobalScript.inst.gameState.data[57] -= 350;
						GlobalScript.inst.gameState.data[107] = 1;
						GlobalScript.inst.gameState.data[4] += 100;
						int[] array9 = new int[16]
						{
							GlobalScript.inst.gameState.leader.name_1,
							GlobalScript.inst.gameState.leader.name_2,
							GlobalScript.inst.gameState.leader.traits[0],
							GlobalScript.inst.gameState.leader.traits[1],
							GlobalScript.inst.gameState.leader.traits[2],
							GlobalScript.inst.gameState.leader.age,
							GlobalScript.inst.gameState.leader.face_type,
							GlobalScript.inst.gameState.leader.face_parts[0],
							GlobalScript.inst.gameState.leader.face_parts[1],
							GlobalScript.inst.gameState.leader.face_parts[2],
							GlobalScript.inst.gameState.leader.face_parts[3],
							GlobalScript.inst.gameState.leader.face_parts[4],
							GlobalScript.inst.gameState.leader.face_parts[5],
							GlobalScript.inst.gameState.leader.face_parts[6],
							GlobalScript.inst.gameState.leader.face_parts[7],
							GlobalScript.inst.gameState.leader.jacket
						};
						int num29 = GlobalScript.inst.gameState.faction_leader[4];
						Politic politic90 = GlobalScript.inst.gameState.politics[num29];
						if (GlobalScript.inst.gameState.citizens != null)
						{
							Persona[] citizens = GlobalScript.inst.gameState.citizens;
							foreach (Persona persona4 in citizens)
							{
								if (persona4.isLead)
								{
									persona4.isLead = false;
								}
							}
						}
						if (politic90.isCitizen)
						{
							achieves.GetComponent<achievements>().Set(210);
							string text3 = GlobalScript.inst.gameState.names1[politic90.name_1];
							string text4 = GlobalScript.inst.gameState.names2[politic90.name_2];
							Persona[] citizens = GlobalScript.inst.gameState.citizens;
							foreach (Persona persona5 in citizens)
							{
								if (persona5 != null && persona5.name == text3 && persona5.surname == text4)
								{
									persona5.isLead = true;
									int[] date2 = new int[3]
									{
										GlobalScript.inst.gameState.data[19],
										GlobalScript.inst.gameState.data[20],
										GlobalScript.inst.gameState.data[21]
									};
									string text5 = CitizenManager.FormatLog(persona5, "стал правителем.", "成为领袖。", date2);
									persona5.changeLog.Add(text5);
									Debug.Log(text5);
								}
							}
						}
						politic90.face_parts = (byte[])politic90.face_parts.Clone();
						GlobalScript.inst.gameState.leader.name_1 = politic90.name_1;
						GlobalScript.inst.gameState.leader.name_2 = politic90.name_2;
						GlobalScript.inst.gameState.leader.traits[0] = politic90.traits[0];
						GlobalScript.inst.gameState.leader.traits[1] = politic90.traits[1];
						GlobalScript.inst.gameState.leader.traits[2] = politic90.traits[2];
						GlobalScript.inst.gameState.leader.age = politic90.age;
						GlobalScript.inst.gameState.leader.face_type = politic90.face_type;
						for (int num30 = 0; num30 < 8; num30++)
						{
							GlobalScript.inst.gameState.leader.face_parts[num30] = politic90.face_parts[num30];
						}
						GlobalScript.inst.gameState.leader.jacket = politic90.jacket;
						politic90.name_1 = (byte)array9[0];
						politic90.name_2 = (byte)array9[1];
						politic90.traits[0] = (byte)array9[2];
						politic90.traits[1] = (byte)array9[3];
						politic90.traits[2] = (byte)array9[4];
						politic90.age = (byte)array9[5];
						politic90.face_type = (byte)array9[6];
						for (int num31 = 0; num31 < 8; num31++)
						{
							politic90.face_parts[num31] = (byte)array9[7 + num31];
						}
						politic90.jacket = (byte)array9[15];
						politic90.isCitizen = false;
						int[] array10 = new int[8];
						for (int num32 = 0; num32 < GlobalScript.inst.gameState.politics_dolshnost.Length; num32++)
						{
							if (GlobalScript.inst.gameState.politics_dolshnost[num32] == 150)
							{
								GlobalScript.inst.gameState.politics_dolshnost[num32] = (byte)GlobalScript.inst.gameState.faction_leader[4];
							}
							else if (GlobalScript.inst.gameState.politics_dolshnost[num32] == (byte)GlobalScript.inst.gameState.faction_leader[4])
							{
								array10[num32] = 150;
							}
						}
						for (int num33 = 0; num33 < array10.Length; num33++)
						{
							if (array10[num33] == 150)
							{
								GlobalScript.inst.gameState.politics_dolshnost[num33] = 150;
							}
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "中共中央政治局紧急会议上爆发激烈争论——保守派主张动用武力（\n尤其是王震大力主张），自由派想要作出让步，\n改革派则犹豫不决。最终，自由派得逞——中共全体领导层辞职。\nСomrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + "成为新的总书记，宣告实行深化改革、在全国范围内大规模推进民主\n化的政策。大多数示威者散去，对此感到满意；\n其余的则被人民武装警察驱逐。\n中国正在等待变化……";
					GlobalScript.inst.gameState.data[3] += 90;
					GlobalScript.inst.gameState.data[6] -= 50;
					GlobalScript.inst.gameState.data[57] -= 350;
					GlobalScript.inst.gameState.data[107] = 1;
					GlobalScript.inst.gameState.data[4] += 100;
					int[] array11 = new int[16]
					{
						GlobalScript.inst.gameState.leader.name_1,
						GlobalScript.inst.gameState.leader.name_2,
						GlobalScript.inst.gameState.leader.traits[0],
						GlobalScript.inst.gameState.leader.traits[1],
						GlobalScript.inst.gameState.leader.traits[2],
						GlobalScript.inst.gameState.leader.age,
						GlobalScript.inst.gameState.leader.face_type,
						GlobalScript.inst.gameState.leader.face_parts[0],
						GlobalScript.inst.gameState.leader.face_parts[1],
						GlobalScript.inst.gameState.leader.face_parts[2],
						GlobalScript.inst.gameState.leader.face_parts[3],
						GlobalScript.inst.gameState.leader.face_parts[4],
						GlobalScript.inst.gameState.leader.face_parts[5],
						GlobalScript.inst.gameState.leader.face_parts[6],
						GlobalScript.inst.gameState.leader.face_parts[7],
						GlobalScript.inst.gameState.leader.jacket
					};
					int num34 = GlobalScript.inst.gameState.faction_leader[4];
					Politic politic91 = GlobalScript.inst.gameState.politics[num34];
					if (GlobalScript.inst.gameState.citizens != null)
					{
						Persona[] citizens = GlobalScript.inst.gameState.citizens;
						foreach (Persona persona6 in citizens)
						{
							if (persona6.isLead)
							{
								persona6.isLead = false;
							}
						}
					}
					if (politic91.isCitizen)
					{
						achieves.GetComponent<achievements>().Set(210);
						string text6 = GlobalScript.inst.gameState.names1[politic91.name_1];
						string text7 = GlobalScript.inst.gameState.names2[politic91.name_2];
						Persona[] citizens = GlobalScript.inst.gameState.citizens;
						foreach (Persona persona7 in citizens)
						{
							if (persona7 != null && persona7.name == text6 && persona7.surname == text7)
							{
								persona7.isLead = true;
								int[] date3 = new int[3]
								{
									GlobalScript.inst.gameState.data[19],
									GlobalScript.inst.gameState.data[20],
									GlobalScript.inst.gameState.data[21]
								};
								string text8 = CitizenManager.FormatLog(persona7, "стал правителем.", "成为领袖。", date3);
								persona7.changeLog.Add(text8);
								Debug.Log(text8);
							}
						}
					}
					politic91.face_parts = (byte[])politic91.face_parts.Clone();
					GlobalScript.inst.gameState.leader.name_1 = politic91.name_1;
					GlobalScript.inst.gameState.leader.name_2 = politic91.name_2;
					GlobalScript.inst.gameState.leader.traits[0] = politic91.traits[0];
					GlobalScript.inst.gameState.leader.traits[1] = politic91.traits[1];
					GlobalScript.inst.gameState.leader.traits[2] = politic91.traits[2];
					GlobalScript.inst.gameState.leader.age = politic91.age;
					GlobalScript.inst.gameState.leader.face_type = politic91.face_type;
					for (int num35 = 0; num35 < 8; num35++)
					{
						GlobalScript.inst.gameState.leader.face_parts[num35] = politic91.face_parts[num35];
					}
					GlobalScript.inst.gameState.leader.jacket = politic91.jacket;
					politic91.name_1 = (byte)array11[0];
					politic91.name_2 = (byte)array11[1];
					politic91.traits[0] = (byte)array11[2];
					politic91.traits[1] = (byte)array11[3];
					politic91.traits[2] = (byte)array11[4];
					politic91.age = (byte)array11[5];
					politic91.face_type = (byte)array11[6];
					for (int num36 = 0; num36 < 8; num36++)
					{
						politic91.face_parts[num36] = (byte)array11[7 + num36];
					}
					politic91.jacket = (byte)array11[15];
					politic91.isCitizen = false;
					int[] array12 = new int[8];
					for (int num37 = 0; num37 < GlobalScript.inst.gameState.politics_dolshnost.Length; num37++)
					{
						if (GlobalScript.inst.gameState.politics_dolshnost[num37] == 150)
						{
							GlobalScript.inst.gameState.politics_dolshnost[num37] = (byte)GlobalScript.inst.gameState.faction_leader[4];
						}
						else if (GlobalScript.inst.gameState.politics_dolshnost[num37] == (byte)GlobalScript.inst.gameState.faction_leader[4])
						{
							array12[num37] = 150;
						}
					}
					for (int num38 = 0; num38 < array12.Length; num38++)
					{
						if (array12[num38] == 150)
						{
							GlobalScript.inst.gameState.politics_dolshnost[num38] = 150;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + "成为新的总书记，宣告实行深化改革、在全国范围内大规模推进民主\n化的政策。然而，“退党”运动认为这正是国家领导层软弱的证明，\n于是组织全国范围的大规模示威，最终以政府辞职告终，\n中国进入过渡时期。共产党在国内失去政权，\n其命运显然岌岌可危……";
					GlobalScript.inst.gameState.data[4] = 1000;
					int[] array13 = new int[16]
					{
						GlobalScript.inst.gameState.leader.name_1,
						GlobalScript.inst.gameState.leader.name_2,
						GlobalScript.inst.gameState.leader.traits[0],
						GlobalScript.inst.gameState.leader.traits[1],
						GlobalScript.inst.gameState.leader.traits[2],
						GlobalScript.inst.gameState.leader.age,
						GlobalScript.inst.gameState.leader.face_type,
						GlobalScript.inst.gameState.leader.face_parts[0],
						GlobalScript.inst.gameState.leader.face_parts[1],
						GlobalScript.inst.gameState.leader.face_parts[2],
						GlobalScript.inst.gameState.leader.face_parts[3],
						GlobalScript.inst.gameState.leader.face_parts[4],
						GlobalScript.inst.gameState.leader.face_parts[5],
						GlobalScript.inst.gameState.leader.face_parts[6],
						GlobalScript.inst.gameState.leader.face_parts[7],
						GlobalScript.inst.gameState.leader.jacket
					};
					int num39 = GlobalScript.inst.gameState.faction_leader[4];
					Politic politic92 = GlobalScript.inst.gameState.politics[num39];
					if (GlobalScript.inst.gameState.citizens != null)
					{
						Persona[] citizens = GlobalScript.inst.gameState.citizens;
						foreach (Persona persona8 in citizens)
						{
							if (persona8.isLead)
							{
								persona8.isLead = false;
							}
						}
					}
					if (politic92.isCitizen)
					{
						achieves.GetComponent<achievements>().Set(210);
						string text9 = GlobalScript.inst.gameState.names1[politic92.name_1];
						string text10 = GlobalScript.inst.gameState.names2[politic92.name_2];
						Persona[] citizens = GlobalScript.inst.gameState.citizens;
						foreach (Persona persona9 in citizens)
						{
							if (persona9 != null && persona9.name == text9 && persona9.surname == text10)
							{
								persona9.isLead = true;
								int[] date4 = new int[3]
								{
									GlobalScript.inst.gameState.data[19],
									GlobalScript.inst.gameState.data[20],
									GlobalScript.inst.gameState.data[21]
								};
								string text11 = CitizenManager.FormatLog(persona9, "стал правителем.", "成为领袖。", date4);
								persona9.changeLog.Add(text11);
								Debug.Log(text11);
							}
						}
					}
					politic92.face_parts = (byte[])politic92.face_parts.Clone();
					GlobalScript.inst.gameState.leader.name_1 = politic92.name_1;
					GlobalScript.inst.gameState.leader.name_2 = politic92.name_2;
					GlobalScript.inst.gameState.leader.traits[0] = politic92.traits[0];
					GlobalScript.inst.gameState.leader.traits[1] = politic92.traits[1];
					GlobalScript.inst.gameState.leader.traits[2] = politic92.traits[2];
					GlobalScript.inst.gameState.leader.age = politic92.age;
					GlobalScript.inst.gameState.leader.face_type = politic92.face_type;
					for (int num40 = 0; num40 < 8; num40++)
					{
						GlobalScript.inst.gameState.leader.face_parts[num40] = politic92.face_parts[num40];
					}
					GlobalScript.inst.gameState.leader.jacket = politic92.jacket;
					politic92.name_1 = (byte)array13[0];
					politic92.name_2 = (byte)array13[1];
					politic92.traits[0] = (byte)array13[2];
					politic92.traits[1] = (byte)array13[3];
					politic92.traits[2] = (byte)array13[4];
					politic92.age = (byte)array13[5];
					politic92.face_type = (byte)array13[6];
					for (int num41 = 0; num41 < 8; num41++)
					{
						politic92.face_parts[num41] = (byte)array13[7 + num41];
					}
					politic92.jacket = (byte)array13[15];
					politic92.isCitizen = false;
					GlobalScript.inst.gameState.data[1] = 0;
					GlobalScript.inst.gameState.data[3] = 0;
					GlobalScript.inst.gameState.data[35] = 1;
					load_scene_after_click = "Ending";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 95)
			{
				text2 = "中共的新开端";
				GlobalScript.inst.gameState.modifies[6].active = false;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在中共中央的非常全会上，经过多数票表决，\n决定放弃马克思列宁主义、毛主义和小平主义，\n转而支持以法国、意大利、西班牙和日本共产党为样板的现代欧洲共\n产主义。中共的纲领文件作出了相应修改。\n这在最保守的党阀群体中引起一定不满，\n但总体上党接受了新的意识形态，认识到必须进行变革。";
					GlobalScript.inst.gameState.data[1] -= 150;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[57] -= 50;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[6] -= 30;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic93 in politics)
					{
						if (politic93 != null)
						{
							if (politic93.traits[0] == 0)
							{
								Politic politic = politic93;
								politic.loyality -= 400;
							}
							else if (politic93.traits[0] == 3)
							{
								Politic politic = politic93;
								politic.loyality += 300;
							}
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "在中共中央的非常全会上，经过长期争论，\n决定回到陈独秀和张国焘的主张，承认党的社会民主党性质。\n中共的纲领文件作出了相应修改。\n这引起党阀中保守派的强烈不满，中共内部出现分裂的某种危险。\n时间会告诉你们是否做了正确的事……";
					GlobalScript.inst.gameState.data[1] -= 300;
					GlobalScript.inst.gameState.data[3] += 80;
					GlobalScript.inst.gameState.data[57] -= 50;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[6] -= 50;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic94 in politics)
					{
						if (politic94 != null)
						{
							if (politic94.traits[0] == 0)
							{
								Politic politic = politic94;
								politic.loyality -= 500;
							}
							else if (politic94.traits[0] == 1)
							{
								Politic politic = politic94;
								politic.loyality -= 300;
							}
							else if (politic94.traits[0] == 3)
							{
								Politic politic = politic94;
								politic.loyality += 500;
							}
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在中共中央的非常全会上，一批党员占了上风，\n主张回到中国革命运动的源头——孙中山及其“人民三民主义”的第\n二版（反对封建主义和资本主义、国家与社会制度的民主化、\n改善工人生活并限制垄断资本）。\n中共的纲领文件作出了相应修改。\n中共开始与国民党革命委员会以及深受群众欢迎的左翼民族主义团体\n趋同，但这却引起党员们明显反对。";
					GlobalScript.inst.gameState.data[1] -= 250;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[4] -= 80;
					GlobalScript.inst.gameState.data[6] -= 10;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic95 in politics)
					{
						if (politic95 != null)
						{
							if (politic95.traits[0] == 0)
							{
								Politic politic = politic95;
								politic.loyality -= 400;
							}
							else if (politic95.traits[0] == 1)
							{
								Politic politic = politic95;
								politic.loyality -= 100;
							}
							else if (politic95.traits[0] == 2)
							{
								Politic politic = politic95;
								politic.loyality += 100;
							}
							else if (politic95.traits[0] == 3)
							{
								Politic politic = politic95;
								politic.loyality += 400;
							}
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "在中共中央的非常全会上，主张保留马克思主义—毛主义—小平主义\n者获胜。“退党”运动势头增强，正积极攻击中共；\n党正在失去群众支持，且在各领域的力量也逐渐失势。\n看来在新中国里它恐怕没有立足之地……";
					GlobalScript.inst.gameState.data[4] += 500;
					GlobalScript.inst.gameState.data[3] -= 500;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 96)
			{
				text2 = "改革！民主！公开！";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "“民族革命统一战线”被解散，我们开始着手制定选举立法——当然\n是为了我们的利益。选举制度被设计成：\n让同情我们的群体占据优势；我们已经禁止了所有能够被禁止的政党，\n而其他政党则必须跨越重重官僚障碍才能获得参选资格。\n与此同时，过去那种血腥审查与控制的最后残余，\n也被新的宣传与自由冲刷殆尽。";
					GlobalScript.inst.gameState.data[15] = 8;
					GlobalScript.inst.gameState.data[50] = 27;
					GlobalScript.inst.gameState.data[57] -= 80;
					if (GlobalScript.inst.gameState.data[17] < 19)
					{
						GlobalScript.inst.gameState.data[17]++;
					}
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.data[3] += 30;
					GlobalScript.inst.gameState.data[4] += 80;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "“民族革命统一战线”被解散，我们开始制定选举立法——世界上最\n自由、最诚实的选举！\n另一方面，即将到来的自由选举带来的狂喜情绪，\n让我们得以避免大规模“拧螺丝”，尽管就物种而言，\n宗教压力还是得有所放松。";
					GlobalScript.inst.gameState.data[15] = 9;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[57] -= 50;
					GlobalScript.inst.gameState.data[50] = 27;
					GlobalScript.inst.gameState.data[4] += 80;
					GlobalScript.inst.gameState.data[6] -= 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "“民族革命统一战线”被解散，我们开始制定选举立法——世界上最\n自由、最诚实的选举！\n另一方面，即将到来的自由选举带来的狂喜以及国家控制的减弱，\n使我们得以让宗教政策几乎不变——是的，\n法律上简化了宗教事务的管理，但实际上，\n神职人员和寺庙仍在国家安全部（MSS）\n和地方行政的控制之下。";
					GlobalScript.inst.gameState.data[15] = 9;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[57] -= 70;
					if (GlobalScript.inst.gameState.data[17] < 19)
					{
						GlobalScript.inst.gameState.data[17]++;
					}
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[6] -= 20;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "当前领导人对任何放慢改组与民主化的提议都予以严厉批评。\n“民族革命统一战线”被解散，我们开始制定选举立法——世界上最\n自由、最诚实的选举！\n与此同时，公共生活各方面的民主化也开始了，\n不仅停留在口头上，更落实在行动中。\n人民当然高兴，但能高兴多久？……";
					GlobalScript.inst.gameState.data[15] = 9;
					GlobalScript.inst.gameState.data[3] += 80;
					GlobalScript.inst.gameState.data[57] -= 120;
					if (GlobalScript.inst.gameState.data[17] < 19)
					{
						GlobalScript.inst.gameState.data[17]++;
					}
					GlobalScript.inst.gameState.data[4] += 120;
					GlobalScript.inst.gameState.data[6] -= 40;
					GlobalScript.inst.gameState.data[50] = 27;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 97)
			{
				text2 = "自动化？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "在全国范围内大规模实现经济规划自动化的运动已经启动：\n各地区的计算机中心正在积极建设并投入运行，\n它们之间的协调也在逐步建立。\n统计部门已经预测：生产力将显著提高、\n供给将得到改善，但并非党内所有人都对你们的创新感到满意。";
					GlobalScript.inst.gameState.data[1] = 0;
					GlobalScript.inst.gameState.data[8] -= 50;
					GlobalScript.inst.gameState.data[16] = 11;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic96 in politics)
					{
						if (politic96 != null)
						{
							Politic politic = politic96;
							politic.loyality -= 500;
						}
					}
					GlobalScript.inst.gameState.modifies[11].active = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "会议强调，需要循序渐进、谨慎引入这种新技术。\n基层规划部门的自动化推进极其缓慢，正被官僚们压制。\n照这样下去，所期望的生产力增长短期内难以实现。";
				}
				else
				{
					text = GlobalScript.inst.new_events_text[1290];
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GlobalScript.inst.gameState.allcountries[61].puppetOf = 21;
					GlobalScript.inst.gameState.data[9] -= 70;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					GlobalScript.inst.gameState.allcountries[61].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 6;
					GlobalScript.inst.gameState.allcountries[61].Torg = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 98)
			{
				GlobalScript.inst.gameState.data[103] = 15;
				text2 = "非洲的“切·格瓦拉”";
				GlobalScript.inst.gameState.allcountries[61].name = GlobalScript.inst.new_events_text[800];
				GlobalScript.inst.gameState.allcountries[61].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 3;
				GlobalScript.inst.gameState.allcountries[61].Torg = false;
				GlobalScript.inst.gameState.allcountries[61].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[61].proprc = false;
				GlobalScript.inst.gameState.allcountries[61].prosov = false;
				GlobalScript.inst.gameState.allcountries[61].dev = 500;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "布基纳法索政府接见了我们的使节，正式关系已经建立。\n现在，桑卡拉开始推行他激进的改造计划。\n计划包括：消除饥饿，建立免费教育与医疗体系，\n打击流行病与腐败，对儿童进行大规模接种。\n由于其反帝立场，布基纳法索领导人愈发卷入“不结盟运动”，\n始终是殖民主义与新殖民主义的尖锐批评者，\n亦批判西方强国及新自由主义色彩的国际经济组织所提供的“人道援\n助”，认为这是一种新殖民主义形式。\n为实现社会的激进转型目标，桑卡拉建立了威权政权，\n取缔了一些政治组织和自由媒体，认为它们会威胁他的计划——不过\n这并未动摇他作为“人民解放者”的人气”。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 80;
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.allcountries[61].Torg = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们没有对眼下几乎每天都在发生的又一次军事政变作出反应。\n根据国际组织的数据，布基纳法索正在展开针对国家机器与一批企业\n家的大规模镇压，这正是“极权政权”的典型做法。\n好在我们并未卷入其中。";
					GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 10;
					GlobalScript.inst.gameState.allcountries[61].Gosstroy = 0;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "中国代表团抵达瓦加杜古，去会见中国人民的新朋友。\n我们提供了粮食和军事援助。\n托马斯·桑卡拉在一场庄严的晚宴上，因我们的友好而深受感动，\n向我们表达了真挚的感谢之词：“在中国朋友的帮助下，\n帝国主义的暴政将随着这个千年一起进入过去，\n所有人都将生活在平等与自由的社会里！\n”如今，桑卡拉在我们的支持下，仿照中国在经济领域开始激进试验，\n宣称从封建主义向社会主义的革命性过渡，\n绕开资本主义，以便得到人民的热烈欢迎。\n现在，政府的主要任务变成了推进工业化、\n建设机械化农业合作社，发展教育、基础设施与医疗。\n同时，多亏了我们的特工，反对派不再关心桑卡拉，\n这使他的权力得以稳定。\n法国则开始寻找推翻他的办法，并把布基纳法索拉回到其影响轨道，\n对桑卡拉的改革表达了强烈不满。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GlobalScript.inst.gameState.data[8] -= 50;
					GlobalScript.inst.gameState.data[9] -= 30;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 2;
					GlobalScript.inst.gameState.allcountries[61].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[61].Torg = true;
					GlobalScript.inst.gameState.allcountries[61].proprc = true;
				}
				else
				{
					text = GlobalScript.inst.new_events_text[1290];
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GlobalScript.inst.gameState.allcountries[61].puppetOf = 21;
					GlobalScript.inst.gameState.data[9] -= 70;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					GlobalScript.inst.gameState.allcountries[61].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 7;
					GlobalScript.inst.gameState.allcountries[61].Torg = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 117)
			{
				if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 1)
				{
					Leader[] leaders = GlobalScript.inst.gameState.empires[1].leaders;
					foreach (Leader leader3 in leaders)
					{
						Leader leader = leader3;
						leader.support += UnityEngine.Random.Range(-10, 11);
					}
				}
				text2 = "五年丧葬";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "安德罗波夫的葬礼于1984年2月14日12时在莫斯科红场克里\n姆林宫墙外举行。许多国家的国家元首和政府首脑。";
					GlobalScript.inst.gameState.empires[1].now_leader = 2;
					if (GlobalScript.inst.gameState.relres)
					{
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.relations -= 100;
					}
					if (GlobalScript.inst.gameState.allcountries[7].isNATO)
					{
						GlobalScript.inst.gameState.empires[1].now_leader = 7;
						text += "|出乎意料的是，亚历山大·雅科夫列夫——以正统马克思主义者的\n名声著称，并在上个十年文化领域积极反对民族主义的人——成为苏\n共中央总书记。由于他在加拿大的外交经验，\n他与西方政治精英中的部分人士建立了牢固而持久的联系，\n这些人或许能够帮助推进苏联的“对西方缓和”路线。\n对最高层政府职位的新任命，人们大可期待。\n众所周知，经济学家列昂尼德·阿巴尔金正在竞逐苏联政府首脑一职，\n而最高苏维埃主席团也可能由米哈伊尔·戈尔巴乔夫出任。";
					}
					else
					{
						GlobalScript.inst.gameState.empires[1].now_leader = 2;
						text += "|如预期所示，康斯坦丁·切尔年科当选总书记。\n不过鉴于他的年纪，他不会在这个位置上久留。";
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "苏联对我们的慰问表示感谢，并接见了中国代表团。\n安德罗波夫的葬礼于1984年2月14日12时在莫斯科红场克里\n姆林宫墙外举行。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GlobalScript.inst.gameState.empires[1].now_leader = 2;
					if (GlobalScript.inst.gameState.allcountries[7].isNATO)
					{
						GlobalScript.inst.gameState.empires[1].now_leader = 7;
						text += "|出乎意料的是，亚历山大·雅科夫列夫——以正统马克思主义者的\n名声著称，并在上个十年文化领域积极反对民族主义的人——成为苏\n共中央总书记。由于他在加拿大的外交经验，\n他与西方政治精英中的部分人士建立了牢固而持久的联系，\n这些人或许能够帮助推进苏联的“对西方缓和”路线。\n对最高层政府职位的新任命，人们大可期待。\n众所周知，经济学家列昂尼德·阿巴尔金正在竞逐苏联政府首脑一职，\n而最高苏维埃主席团也可能由米哈伊尔·戈尔巴乔夫出任。";
					}
					else
					{
						GlobalScript.inst.gameState.empires[1].now_leader = 2;
						text += "|如预期所示，康斯坦丁·切尔年科当选总书记。\n不过鉴于他的年纪，他不会在这个位置上久留。";
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "我们的领导人亲自率领中国代表团，并在苏联受到热情接待。\n安德罗波夫的葬礼于1984年2月14日12时在莫斯科红场克里\n姆林宫墙外举行。许多国家的国家元首和政府首脑。";
					GlobalScript.inst.gameState.empires[1].now_leader = 2;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 150;
					if (GlobalScript.inst.gameState.allcountries[7].isNATO)
					{
						GlobalScript.inst.gameState.empires[1].now_leader = 7;
						text += "|出乎意料的是，亚历山大·雅科夫列夫——以正统马克思主义者的\n名声著称，并在上个十年文化领域积极反对民族主义的人——成为苏\n共中央总书记。由于他在加拿大的外交经验，\n他与西方政治精英中的部分人士建立了牢固而持久的联系，\n这些人或许能够帮助推进苏联的“对西方缓和”路线。\n对最高层政府职位的新任命，人们大可期待。\n众所周知，经济学家列昂尼德·阿巴尔金正在竞逐苏联政府首脑一职，\n而最高苏维埃主席团也可能由米哈伊尔·戈尔巴乔夫出任。";
					}
					else
					{
						GlobalScript.inst.gameState.empires[1].now_leader = 2;
						text += "|如预期所示，康斯坦丁·切尔年科当选总书记。\n不过鉴于他的年纪，他不会在这个位置上久留。";
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 114)
			{
				text2 = "大象与驴";
				int num42 = 0;
				int num43 = 0;
				if (GlobalScript.inst.gameState.empires[0].power > GlobalScript.inst.gameState.empires[1].power)
				{
					num43++;
				}
				else
				{
					num42++;
				}
				if (GlobalScript.inst.gameState.empires[0].power > GlobalScript.inst.gameState.influencePRC)
				{
					num43++;
				}
				else
				{
					num42++;
				}
				if (GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[1].power)
				{
					num43++;
				}
				else
				{
					num42++;
				}
				if (GlobalScript.inst.gameState.OAR)
				{
					num42++;
				}
				if (GlobalScript.inst.gameState.allcountries[15].cw)
				{
					num43++;
				}
				if (GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					num43++;
				}
				if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
				{
					num43++;
				}
				if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
				{
					num43++;
				}
				if (GlobalScript.inst.gameState.resultOfEvents[46] == 2)
				{
					num42++;
				}
				if (GlobalScript.inst.gameState.ingamewars[5].is_going)
				{
					num42++;
				}
				if (GlobalScript.inst.gameState.allcountries[84].Gosstroy == 0)
				{
					num42++;
				}
				else
				{
					num43++;
				}
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 3 || GlobalScript.inst.gameState.allcountries[8].Vyshi)
				{
					num43++;
				}
				else
				{
					num42++;
				}
				if (global1.dlc[0])
				{
					if (GlobalScript.inst.gameState.gamerules[2] == 1)
					{
						num43 += UnityEngine.Random.Range(-10, 10);
						num42 += UnityEngine.Random.Range(-10, 10);
					}
					else if (GlobalScript.inst.gameState.gamerules[2] == 2)
					{
						if (GlobalScript.inst.gameState.number_otvet == 1)
						{
							num43 += 100;
						}
						else
						{
							num42 += 100;
						}
					}
				}
				if (num43 >= num42)
				{
					text = "选举之后，卡特仍设法保住了权力。\n他得以获益的关键因素在于：尽管遭到保守派批评，\n中间路线的外交政策总体上表现不错。\n美国正在等待民主党再执政4年。";
					GlobalScript.inst.gameState.data[143] += 2;
					GlobalScript.inst.gameState.empires[0].now_leader = 1;
				}
				else
				{
					text = "由于选举结果，卡特被里根击败。\n经济危机与外交政策失利影响了美国人的情绪，\n他们更愿意追随共和党的民粹口号。\n如今，在里根的领导下，美国正等待与苏联进行新一轮积极对抗。";
					GlobalScript.inst.gameState.empires[0].now_leader = 0;
					GlobalScript.inst.gameState.data[143] -= 2;
					GlobalScript.inst.gameState.allcountries[51].SubGosstroy = 12;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 99)
			{
				text2 = "黄蝎子";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "多亏我们的支持，正统斯大林主义者领袖穆罕默德·亚希奥维得以打\n击右派反对派；民族解放阵线（NLF）\n的紧急代表大会任命他为总书记，阿尔及利亚全国人民议会又任命他\n为代总统。1979年2月8日提前举行选举，\n然而在一党制与无竞争选举的情况下，结果早已在事先知晓。\n国内开始迫害“反动阶级”，而前任推动工业化的路线继续延续。\n新政府宣布：外交政策方向转为亲华，并邀请我们签署一份极其有利\n的贸易合同。苏联对“中方干预阿尔及利亚内政”作出了消极反应。";
					GlobalScript.inst.gameState.data[9] -= 60;
					GlobalScript.inst.gameState.data[6] += 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 30;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					GlobalScript.inst.gameState.allcountries[40].prosov = false;
					GlobalScript.inst.gameState.allcountries[40].proprc = true;
					GlobalScript.inst.gameState.allcountries[40].Torg = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们支持恰德利·本杰迪德以及民族解放阵线的改革派。\n结果是：一批最活跃的斯大林主义者被逮捕，\n其余人不得不投票支持本杰迪德；亲西方的自由派布特弗利卡被撤下\n外交部长职务，调到次要岗位。\nNLF的紧急代表大会任命本杰迪德为总书记，\n全国人民议会任命他为阿尔及利亚代总统。\n1979年2月8日提前举行选举，但在一党制与无竞争选举下，\n结果早已在事先知晓。\n国家正准备全面改革，以扶持单一农民与小工商业，\n这将有助于摆脱国家对经济过度的影响。\n总统感谢我们的支持，并向我们提供一份有利的贸易合同；\n与美国不同，苏联对中国援助阿尔及利亚的态度是积极的。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					GlobalScript.inst.gameState.data[9] -= 40;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 30;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.allcountries[40].Torg = true;
					GlobalScript.inst.gameState.allcountries[40].Gosstroy = 2;
					GlobalScript.inst.gameState.data[143]++;
					GlobalScript.inst.gameState.allcountries[40].SubGosstroy = 15;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在我们特工的帮助下，自由派外交部长布特弗利卡打击了党内的内部\n反对力量；NLF的紧急代表大会选举他为总书记，\n全国人民议会任命他为阿尔及利亚代总统。\n由于新的全球政治改革以及国家新宪法的制定，\n选举被无限期推迟。总统宣布：经济方向调整，\n并向混合市场体制过渡。\n取消了对外资与中型企业的禁令，不盈利企业的私有化开始推进。\n新政府宣布在外交政策领域与西方国家开展深入合作，\n这引起了苏联的不满，却得到了美国和北约的积极回应。\n布特弗利卡感谢我们的支持，并向我们提供了一份极其有利的合同。";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 30;
					GlobalScript.inst.gameState.data[9] -= 60;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 300;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 30;
					GlobalScript.inst.gameState.allcountries[40].Torg = true;
					GlobalScript.inst.gameState.allcountries[40].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[40].SubGosstroy = 6;
					GlobalScript.inst.gameState.allcountries[40].prosov = false;
					GlobalScript.inst.gameState.allcountries[40].Vyshi = true;
					GlobalScript.inst.gameState.data[143] -= 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "NLF的紧急代表大会任命改革派领袖恰德利·本杰迪德为“折中”\n总书记，全国人民议会任命他为阿尔及利亚代总统。\n1979年2月8日提前举行选举，但在一党制与无竞争选举下，\n结果早已在事先知晓。\n阿尔及利亚开始推行极其温和的改革，然而这却谁也无法取悦。";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 104)
			{
				text2 = "第十二届世界青年与学生联欢节";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					if ((GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 350) || GlobalScript.inst.gameState.empires[1].now_leader == 6)
					{
						text = "我们的申请获得批准。\n我们派出由青年组织成员组成的代表团，\n以及中国最优秀的学生和中国共产主义青年团成员赴莫斯科。\n联欢节的政治议程包括：建立新的国际经济秩序，\n讨论对落后与发展中国家的经济援助问题，\n反贫困与反失业，并提出环境议题。\n联欢节举办了大量群众团体与业余团体的演唱会，\n展出了艺术家与摄影师的作品。\n大家对活动都很满意，我们派代表团前去并未白费——更重要的是，\n这促进了我们同苏联乃至资本主义国家的关系改善。";
						GlobalScript.inst.gameState.data[4] += 20;
						GlobalScript.inst.gameState.data[3] += 80;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC += 10;
						GlobalScript.inst.gameState.data[1] += 50;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.relations += 100;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.relations += 50;
					}
					else
					{
						text = "与我们关系不佳的苏联决定借助其在世界青年与学生联欢节（WFD\nY）中的关系，并利用东道主地位，结果我们参与的申请被拒绝。\n不过，不仅我们，其他一些国家以及左翼运动也对此表示不满。";
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 10;
						GameState gameState = GlobalScript.inst.gameState;
						gameState.influencePRC -= 10;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "该节庆的政治议程包括建立新的国际经济秩序，\n讨论对落后和发展中国家的经济援助问题，\n开展反贫困与反失业斗争，并提出环境议题。\n节日期间举办了大量流行乐队与业余团体的演出，\n以及艺术家和摄影师的展览。\n对我们来说，什么也没发生——因为我们决定不派代表团。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在莫斯科举行第十二届世界青年与学生节期间，\n我们决定突出对苏联的独立性，于是在北京组织了我们自己的“世界\n进步青年节”。前往莫斯科的，是那些与中国结盟的国家代表，\n以及因种种原因未派代表团的国家代表。\n总体而言，我们的人对这次活动感到满意，\n同盟关系也进一步加强了，但国际左翼运动对此却充满不信任。";
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[3] += 40;
					GlobalScript.inst.gameState.data[1] += 150;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 150;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					GlobalScript.inst.gameState.data[8] -= 20;
					Country[] allcountries = GlobalScript.inst.gameState.allcountries;
					foreach (Country country3 in allcountries)
					{
						if (country3.okb)
						{
							Country country2 = country3;
							country2.soc_stab += 100;
							if (country3.usalliance)
							{
								country3.usalliance = false;
								GlobalScript.inst.gameState.data[9] -= 30;
								GlobalScript.inst.gameState.data[8] -= 50;
							}
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 106)
			{
				text2 = "民主国际";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "结果，民主国际成立了。\n至于这是否会在行动上帮助反共叛乱者，\n目前仍难说，但这件事意义重大，并有助于美国影响力的增长——美\n国正积极支持这一组织。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们先是紧急促成了安哥拉境内我方特工与邻国之间的协作，\n又秘密劝说苏联以及亲苏的安哥拉当局配合，\n于是得以在贾姆巴组织一系列恐怖袭击。\n遗憾的是，UNITA领导人乔纳斯·萨维姆比以及美国的幕后操盘\n者并未受伤；但我们成功清除了非正式“反政府武装”头目阿道尔福\n·卡莱罗、著名圣战组织代表阿卜杜勒·拉希姆·瓦达克，\n以及蒙族（苗族）运动领袖帕·高·赫。\n除联盟土崩瓦解外，许多世界反共名流的死亡也沉重打击了美国影响\n力，并帮助了苏联。于是，所有主要指控都飞向了他——不过，\n美国人怀疑我们参与了其中。";
					GlobalScript.inst.gameState.data[9] -= 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 30;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 200;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "我们支持民主国际的组建，并支持其宣称随时准备在全世界对抗苏联\n的侵略。其参与者对这番表态的理解不尽相同，\n但总体反应积极；美国人也同样如此——他们从中获益最多。\n至于我们能得到什么，目前仍不清楚，但苏联的影响力确实下降了。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 120;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 30;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
					Country[] allcountries = GlobalScript.inst.gameState.allcountries;
					foreach (Country country4 in allcountries)
					{
						if (country4.okb || country4.econ)
						{
							Country country2 = country4;
							country2.soc_stab += 50;
							if (country4.sovalliance)
							{
								country4.sovalliance = false;
								GlobalScript.inst.gameState.data[9] -= 30;
								GlobalScript.inst.gameState.data[8] -= 50;
							}
						}
						else if (country4.dev > 100 && country4.stab > 100 && country4.prosov)
						{
							Country country2 = country4;
							country2.stab -= 150;
							country2 = country4;
							country2.dev -= 50;
						}
						else if ((country4.dev > 50 || country4.stab > 50) && country4.Vyshi)
						{
							Country country2 = country4;
							country2.stab += 150;
							country2 = country4;
							country2.dev -= 100;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 103)
			{
				text2 = "申根协议";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "我们联盟各国的会议在上海举行，最终签署了所谓《上海协议》。\n该协议意味着在我们各国之间建立统一的签证空间，\n并简化护照与签证管控，甚至展望彻底取消对外国护照的需求。\n协议开始逐步见效，民众也感到满意——只是从此便开始沉迷外来文\n化，并对我们的国家原则产生怀疑。\n现在，罪犯和异议分子将更容易从中国逃离，\n走私者也更容易把货物走私到我们这里。\n但我们各国之间的联系进一步加强，旅游收入也将补充我们的预算。";
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[3] += 80;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[26] += 30;
					GlobalScript.inst.gameState.data[8] += 30;
					Country[] allcountries = GlobalScript.inst.gameState.allcountries;
					foreach (Country country5 in allcountries)
					{
						if (country5.okb)
						{
							Country country2 = country5;
							country2.soc_stab += 200;
							GlobalScript.inst.gameState.data[8] -= 5;
							if (!country5.proprc && !country5.sovalliance && !country5.usalliance)
							{
								country5.proprc = true;
								GlobalScript.inst.gameState.data[8] -= 20;
							}
							else if (!country5.proprc && (country5.sovalliance || country5.usalliance))
							{
								country5.sovalliance = false;
								country5.usalliance = false;
								GlobalScript.inst.gameState.data[8] -= 30;
							}
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们联盟各国的会议在上海举行，最终签署了所谓《上海协议》。\n该协议意味着在我们各国之间建立统一的签证空间，\n并简化护照与签证管控，甚至展望彻底取消对外国护照的需求。\n协议开始逐步见效，民众也感到满意——只是从此便开始沉迷外来文\n化，并对我们的国家原则产生怀疑。\n现在，罪犯和异议分子将更容易从中国逃离，\n走私者也更容易把货物走私到我们这里。\n但我们各国之间的联系进一步加强，旅游收入也将补充我们的预算。";
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[3] += 80;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[26] += 30;
					GlobalScript.inst.gameState.data[8] += 30;
					Country[] allcountries = GlobalScript.inst.gameState.allcountries;
					foreach (Country country6 in allcountries)
					{
						if (country6.okb || country6.econ)
						{
							Country country2 = country6;
							country2.soc_stab += 200;
							GlobalScript.inst.gameState.data[8] -= 5;
							if (!country6.proprc && !country6.sovalliance && !country6.usalliance)
							{
								country6.proprc = true;
								GlobalScript.inst.gameState.data[8] -= 20;
							}
							else if (!country6.proprc && (country6.sovalliance || country6.usalliance))
							{
								country6.sovalliance = false;
								country6.usalliance = false;
								GlobalScript.inst.gameState.data[8] -= 30;
							}
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "什么也没发生。";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 107)
			{
				text2 = "同盟危机";
				int num44 = (GlobalScript.inst.gameState.data[21] - 1976) * 2 + 1;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "借着演习的名义，我军进入该国，迅速解除其军队武装，\n逮捕政府并镇压不满。\n新政府获得财政援助，以巩固其忠诚。\n " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " 又回到我们这边了，但我们的外交声誉仍然差强人意。";
					GlobalScript.inst.gameState.data[22] -= num44 * 10;
					GlobalScript.inst.gameState.data[8] -= 30;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 1000;
					Country[] allcountries = GlobalScript.inst.gameState.allcountries;
					foreach (Country country7 in allcountries)
					{
						if (country7.okb || country7.econ)
						{
							Country country2 = country7;
							country2.soc_stab -= 50;
						}
					}
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
					{
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 150;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance = false;
						GlobalScript.inst.gameState.data[6] += 30;
					}
					else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
					{
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.relations -= 150;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance = false;
						GlobalScript.inst.gameState.data[6] -= 30;
					}
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].proprc = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "通过幕后阴谋、秘密暗杀，以及动员那些仍忠于我们的政界人士和军\n方力量，我们成功组织了一场政变，支持那些愿意继续与我们合作的\n人。新政府获得财政援助，以巩固其忠诚。\n " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " 又回到我们这边了，但其他国家起了疑心，并表达不满";
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 1000;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
					{
						GlobalScript.inst.gameState.data[9] -= 100;
						GlobalScript.inst.gameState.data[8] -= 30;
					}
					else
					{
						GlobalScript.inst.gameState.data[9] -= 200;
						GlobalScript.inst.gameState.data[8] -= 60;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].proprc = true;
					}
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
					{
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.relations -= 100;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance = false;
						GlobalScript.inst.gameState.data[6] += 10;
					}
					else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
					{
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.relations -= 100;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance = false;
						GlobalScript.inst.gameState.data[6] -= 10;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "决定不采取激烈手段，而是安抚该国，同时在经济上把它绑到我们这\n边。这迫使支持独立的人放弃仓促计划，\n而支持与中国友好的力量则获得了额外权力。\n " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " 又回到我们这边了，我们也成功避免了任何外交问题；\n只是支持独立路线的人并未消失。";
					GlobalScript.inst.gameState.data[8] -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 1000;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
					{
						if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 3)
						{
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 2;
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 15;
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 1)
					{
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 2;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 15;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "决定不采取激烈措施，只是向该国领导层提出加入我们阵营的保证，\n同时保留其推行独立外交政策的能力。\n经过长期谈判与犹豫，他们终于同意了。\n " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " 仍在我们的联盟之内，但正积极同其他国家建立新联系——这也许\n会在未来反噬我们。";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
					{
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.power += 30;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance = false;
						GlobalScript.inst.gameState.data[6] -= 30;
						empire = GlobalScript.inst.gameState.empires[0];
						empire.relations += 50;
						if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 3)
						{
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 1;
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 15;
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
					{
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power += 30;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance = false;
						GlobalScript.inst.gameState.data[6] += 30;
						empire = GlobalScript.inst.gameState.empires[1];
						empire.relations += 50;
						if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 1)
						{
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 2;
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 15;
						}
					}
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[8] -= 10;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 500;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "结果，由于我们这边没有遭遇任何阻力，\n该国决定退出我们的阵营，并已经在建立新的联系。\n比起社会帝国主义还要好！";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
					{
						Empire empire = GlobalScript.inst.gameState.empires[0];
						empire.power += 50;
						if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 3)
						{
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 3;
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 12;
						}
					}
					else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
					{
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power += 50;
						if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 1)
						{
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 1;
							GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 1;
						}
					}
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].proprc = false;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
					{
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 1000;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb = false;
					}
					else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].econ)
					{
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 0;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].econ = false;
					}
				}
				GlobalScript.inst.gameState.data[120] = -1;
			}
			else if (GlobalScript.inst.gameState.number_event == 100)
			{
				text2 = "政府危机";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "多亏我方特工部门的协同工作，随着日益加剧的金融危机，\n孟加拉国首都几家最大的工厂里散布了“将要裁员、\n工资将被削减”的谣言。\n就在第二天，整个城市便因罢工以及工人与武装警察之间的冲突而瘫\n痪，部分地区还传出了枪声。\n然而在舆论压力与动乱不断升级之下，总统不得不宣布提前举行议会\n选举；而在我们不无帮助的情况下，左翼联盟赢得选举，\n谢赫·哈西娜·瓦兹德成为新任总理。\n新政府宣布启动社会经济改革，并扩大中国与孟加拉国之间的贸易。\n国际社会总体上忽视了换届，但美国怀疑我们参与了这起事件。";
					GlobalScript.inst.gameState.data[9] -= 100;
					GlobalScript.inst.gameState.data[6] += 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 70;
					GlobalScript.inst.gameState.allcountries[32].proprc = true;
					GlobalScript.inst.gameState.allcountries[32].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[32].Torg = true;
					GlobalScript.inst.gameState.allcountries[32].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[32].SubGosstroy = 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "孟加拉国政府继续掌控局势，及时镇压罢工。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "埃尔沙德总统感谢我们的帮助，并建议就“扩大贸易与经济合作”在\n中国与孟加拉国之间举行峰会。\n在谈判中，两国关系得以恢复；中国正式承认孟加拉国脱离巴基斯坦\n的独立，并签署了新的贸易合同。";
					GlobalScript.inst.gameState.data[8] -= 80;
					GlobalScript.inst.gameState.allcountries[32].Torg = true;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 70;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 105)
			{
				text2 = "阿尔巴尼亚斯大林的终结";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "如预料所示，拉米兹·阿利亚并没有“打破那些运转得如此良好的东\n西”。党对公共生活各领域的全面、绝对监督仍被维持，\n正统斯大林主义派继续主导阿尔巴尼亚劳动党（PPSH）。\n然而政权毕竟还是经历了一些微不足道的变化：\n大规模镇压很快被压缩，神职人员的逮捕停止了，\n对异议的镇压也变得“更有分寸”。\n而尽管阿利亚并无计划恢复与苏联的积极关系，\n但阿尔巴尼亚外交政策向更开放方向转动的趋势，\n已经开始显现。";
					GlobalScript.inst.gameState.allcountries[20].proprc = false;
					GlobalScript.inst.gameState.data[60] = 2;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "从地拉那传来绝对意想不到的消息！\n在这看似最稳固的意识形态国家，竟发生了恐怖袭击——而且规模何\n等惊人！现任总书记、霍查的继承人拉米兹·阿利亚，\n在他原定访问首都一座工厂期间被彻底暗杀。\n尽管围在国家领导人身边的警卫十分警惕，\n恐怖袭击者仍设法连发数枪精准射击，其中一枪直接击中肺部。\n阿利亚在前往医院的途中就已去世。\n为压制可能出现的群众骚乱，成立了霍查派领导人的三人执政——霍\n查—丘科—查姆卡尼。\n通过这名恐怖袭击者，特工部门还设法接触到一整批科索沃阿尔巴尼\n亚人，据称他们正密谋对付政治局其他成员。\n此次事件引发了国家内党内清洗与镇压的新一轮。\n霍查主义再次得胜，阿尔巴尼亚继续被孤立。";
					GlobalScript.inst.gameState.data[9] -= 60;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 5;
					GlobalScript.inst.gameState.data[60] = 3;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "中国领导人向阿尔巴尼亚外交部发去唁电，\n暗示要“重启”中阿关系。\n一周后，拉米兹·阿利亚对中华人民共和国进行了外交访问；\n“中阿友好条约”重新签署；作为两国和解的标志，\n中国还向阿尔巴尼亚提供了长期、坚实的贷款。\n ";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 15;
					GlobalScript.inst.gameState.allcountries[20].Torg = true;
					GlobalScript.inst.gameState.allcountries[20].proprc = true;
					GlobalScript.inst.gameState.data[60] = 2;
					GlobalScript.inst.gameState.data[1] += 100;
					GlobalScript.inst.gameState.data[8] -= 30;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 80;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 109)
			{
				text2 = "索马里的黄金时代";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "索马里局势继续恶化，穆罕默德·西亚德·巴雷正在扩大与美国的军\n事合作。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 30;
					GlobalScript.inst.gameState.allcountries[42].prosov = false;
					GlobalScript.inst.gameState.allcountries[42].Vyshi = true;
					GlobalScript.inst.gameState.allcountries[42].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[42].SubGosstroy = 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们向穆罕默德·西亚德·巴雷政权提供了人道与军事援助，\n使索马里得以从奥加登战争的毁灭性影响中恢复。\n于是，政府对武装反对派发动了大规模攻势，\n从而巩固了SRSP政权。\n巴雷作为国家领导人，感谢中国所提供的支持，\n并已宣布扩大两国间的合作。";
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[22] -= 50;
					GlobalScript.inst.gameState.data[8] -= 80;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 70;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 70;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[6] += 30;
					GlobalScript.inst.gameState.allcountries[42].prosov = false;
					GlobalScript.inst.gameState.allcountries[42].proprc = true;
					GlobalScript.inst.gameState.allcountries[42].Torg = true;
					GlobalScript.inst.gameState.allcountries[42].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[42].SubGosstroy = 10;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "多亏我方特工部门的支持，颇具影响力的军方人物穆罕默德·阿里·\n萨马塔尔与将领们密谋后，向穆罕默德·西亚德·巴雷提出最后通牒，\n要求总统立即辞职。\n结果，在军方压力之下，索马里领导人被迫下台。\n总统职位由“折中”的外交部长阿卜迪拉赫曼·贾马·巴雷接任，\n而他的行动实际上受最高将领控制。\n索马里与埃塞俄比亚达成停火，放弃任何领土主张；\n同时该国政府恢复了与苏联的关系——这段关系在奥加登冲突期间被\n打断。新政府加入不结盟运动，宣称实行军事中立，\n但索马里正越来越靠近其他阿拉伯国家。\n索马里政府没有忘记我们的支持，邀请我们扩大两国间的贸易合作。";
					GlobalScript.inst.gameState.data[9] -= 80;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 5;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 5;
					GlobalScript.inst.gameState.data[6] -= 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					GlobalScript.inst.gameState.allcountries[42].prosov = false;
					GlobalScript.inst.gameState.allcountries[42].Torg = true;
					GlobalScript.inst.gameState.allcountries[42].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[42].SubGosstroy = 15;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 102)
			{
				text2 = "变革的风？";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2)
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
						leader.support += 200;
					}
					else
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
						leader.support += 3;
						GlobalScript.inst.gameState.data[9] -= 100;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2)
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
						leader.support += 200;
					}
					else
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
						leader.support += 3;
						GlobalScript.inst.gameState.data[9] -= 100;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2)
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[5];
						leader.support += 200;
					}
					else
					{
						Leader leader = GlobalScript.inst.gameState.empires[1].leaders[5];
						leader.support += 3;
						GlobalScript.inst.gameState.data[9] -= 100;
					}
				}
				if (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
					leader.support += 2;
				}
				if (GlobalScript.inst.gameState.allcountries[15].Gosstroy == 0 && GlobalScript.inst.gameState.allcountries[15].SubGosstroy == 0)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support--;
				}
				if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 1)
				{
					Leader[] leaders = GlobalScript.inst.gameState.empires[1].leaders;
					foreach (Leader leader4 in leaders)
					{
						Leader leader = leader4;
						leader.support += UnityEngine.Random.Range(-10, 11);
					}
				}
				if (GlobalScript.inst.gameState.empires[1].leaders[6].support >= GlobalScript.inst.gameState.empires[1].leaders[5].support && GlobalScript.inst.gameState.empires[1].leaders[6].support >= GlobalScript.inst.gameState.empires[1].leaders[4].support)
				{
					if (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power + 200 && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC + 200)
					{
						text = "结果，中共中央现任书记叶戈尔·利加乔夫当选为苏共中央总书记。\n他设法争取到了温和派党员的支持，首先是安德烈·葛罗米柯，\n并提出自己的候选资格；按照老布尔什维克传统，\n该提名获得一致通过。";
						GlobalScript.inst.gameState.empires[1].now_leader = 8;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 100;
					}
					else
					{
						text = "结果，米哈伊尔·戈尔巴乔夫当选为苏共中央委员会总书记。\n他以惊人的速度组织了大会，并通过军用航空确保政治局成员到场，\n却对对手罗曼诺夫只字未提。\n在葛罗米柯与温和派的支持下，他以极小的票差带领共产党前进。\n苏联接下来会怎样？";
						GlobalScript.inst.gameState.empires[1].now_leader = 6;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 250;
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[4].support >= GlobalScript.inst.gameState.empires[1].leaders[5].support && GlobalScript.inst.gameState.empires[1].leaders[4].support >= GlobalScript.inst.gameState.empires[1].leaders[6].support)
				{
					text = "结果，格里戈里·罗曼诺夫当选为苏共中央委员会总书记。\n他在得知切尔年科去世后，立刻飞往莫斯科，\n在那里成功集结了保守派与温和派的力量。\n苏联将迎来有趣的时代。";
					GlobalScript.inst.gameState.empires[1].now_leader = 4;
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[5].support + 1 > GlobalScript.inst.gameState.empires[1].leaders[4].support && GlobalScript.inst.gameState.empires[1].leaders[5].support + 1 > GlobalScript.inst.gameState.empires[1].leaders[6].support)
				{
					text = "结果，维克托·格里申当选为苏共中央委员会总书记。\n在保守多数派的支持下——他们早已秘密商定格里申的当选，\n并挫败戈尔巴乔夫的计划——他顺利接掌苏共中央。\n苏联还将迎来数年“勃列日涅夫式稳定”。";
					GlobalScript.inst.gameState.empires[1].now_leader = 5;
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[6].support > GlobalScript.inst.gameState.empires[1].leaders[4].support)
				{
					if (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power + 200 && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC + 200)
					{
						text = "结果，中共中央现任书记叶戈尔·利加乔夫当选为苏共中央总书记。\n他设法争取到了温和派党员的支持，首先是安德烈·葛罗米柯，\n并提出自己的候选资格；按照老布尔什维克传统，\n该提名获得一致通过。";
						GlobalScript.inst.gameState.empires[1].now_leader = 8;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 100;
					}
					else
					{
						text = "尽管争论不断，最终米哈伊尔·戈尔巴乔夫当选为苏共中央委员会总\n书记。他以惊人的速度组织了大会，并通过军用航空确保政治局成员\n到场，却对对手罗曼诺夫只字未提。\n在葛罗米柯与温和派的支持下，他以极小的票差带领共产党前进。\n苏联接下来会怎样？";
						GlobalScript.inst.gameState.empires[1].now_leader = 6;
						Empire empire = GlobalScript.inst.gameState.empires[1];
						empire.power -= 250;
					}
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[6].support < GlobalScript.inst.gameState.empires[1].leaders[4].support)
				{
					text = "尽管争论不断，最终格里戈里·罗曼诺夫当选为苏共中央委员会总书\n记。他在得知切尔年科去世后，立刻飞往莫斯科，\n在那里成功集结了保守派与温和派的力量。\n苏联将迎来有趣的时代。";
					GlobalScript.inst.gameState.empires[1].now_leader = 4;
				}
				else
				{
					text = "尽管争论不断，最终维克托·格里申当选为苏共中央委员会总书记。\n在保守多数派的支持下——他们早已秘密商定格里申的当选，\n并挫败戈尔巴乔夫的计划——他顺利接掌苏共中央。\n苏联还将迎来数年“勃列日涅夫式稳定”。";
					GlobalScript.inst.gameState.empires[1].now_leader = 5;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 110)
			{
				text2 = "自动化是一个自然的过程";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "社会主义经济目前仍在稳定运转……";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "向主席致敬！向中共致敬！\n这一天将载入中国史册，成为“伟大突破”的日子。\n我们敬爱的领袖宣布，我国将开始重大变革——中华人民共和国将走\n上全面自动化的轨道，并实现全国所有计划与生产的计算机化；\n同时宣布成立“自动化经济管理中心”，\n该中心即将开始工作。\n新工程的代号为IECS——“跨部门电子控制系统”。\n如今，全国范围内关于仓促推行这些措施的“热烈”讨论已经燃起，\n部分党内政客还宣称改革具有“反马克思主义性质”。\n然而工程已经启动，难道没有什么能阻止我国不可避免的变革，\n对吧？";
					GlobalScript.inst.gameState.data[8] -= 100;
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[4] += 100;
					GlobalScript.inst.gameState.data[1] -= 600;
					GlobalScript.inst.gameState.data[118] = 1;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "向主席致敬！向中共致敬！\n这一天将载入中国史册，作为“伟大突破”的日子。\n我们敬爱的领袖宣布，我国将开始重大变革——中华人民共和国将走\n上全面自动化、全国所有计划与生产的计算机化之路；\n并宣布成立“自动化经济管理中心”，该中心即将开始工作。\n新项目的代号为IECS——“跨部门电子控制系统”。\n此外，得益于我们同苏联人民的密切友谊，\n我们向苏联请求合格的援助，如今，由院士阿纳托利·基托夫率领的\n代表团已抵达中国。与此同时，中国国内关于这些措施引入过于仓促\n的“激烈”讨论也燃起了火花，部分党内政客宣称“改革具有反马克\n思主义性质”。然而，项目已经启动，谁也阻止不了我国不可避免的\n变革，对吧？";
					GlobalScript.inst.gameState.data[8] -= 80;
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[4] += 120;
					GlobalScript.inst.gameState.data[1] -= 600;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GlobalScript.inst.gameState.data[118] = 1;
					GlobalScript.inst.gameState.data[73] += 300;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "向主席致敬！向中共致敬！\n这一天将载入中国史册，作为“伟大突破”的日子。\n我们敬爱的领袖宣布，我国将开始重大变革——中华人民共和国将走\n上全面自动化、全国所有计划与生产的计算机化之路；\n并宣布成立“自动化经济管理中心”，该中心即将开始工作。\n新项目的代号为IECS——“跨部门电子控制系统”。\n另外，凭借我们同西方国家的友好关系，\n我们得以邀请由斯塔福德·比尔率领的欧洲数学科学家代表团——他\n此前因开发智利的“赛博辛”而声名鹊起。\n如今，中国国内关于这些措施引入过于仓促的“激烈”讨论也燃起了\n火花，部分党内政客宣称“改革具有反马克思主义性质”。\n然而，项目已经启动，谁也阻止不了我国不可避免的变革，\n对吧？";
					GlobalScript.inst.gameState.data[8] -= 80;
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[4] += 150;
					GlobalScript.inst.gameState.data[1] -= 600;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					GlobalScript.inst.gameState.data[118] = 1;
					GlobalScript.inst.gameState.data[73] += 300;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 111)
			{
				text2 = "向幽冥之光";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "变革在逼近";
					GlobalScript.inst.gameState.data[35] = 6;
					load_scene_after_click = "Ending";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "今天，全国各报刊登了《致人民的呼吁》一文。\n文中，同志主席号召每一位热爱祖国与党、\n对中国命运不漠不关的公民，去抵制那些再次抬头的“资产阶级帮凶\n”和“党内派别的修正主义者”。\n受鼓舞的群众在天安门广场集会，支持政府与同志主席的行动。\n结果，超过30万人涌向全国的主广场，\n高喊口号，要求继续向反动阶级进行文化大革命。\n迫于群众愤怒的压力，阴谋者不得不辞去职务，\n而地方党棍也被迫收敛了热情。\n这是我们人民的伟大胜利！\n向主席致敬！向中共致敬！";
					GlobalScript.inst.gameState.data[6] += 70;
					GlobalScript.inst.gameState.data[3] += 100;
					GlobalScript.inst.gameState.data[1] -= 400;
					int num45 = 0;
					for (int num46 = 0; num46 < GlobalScript.inst.gameState.politics.Length; num46++)
					{
						if (GlobalScript.inst.gameState.politics[num46].loyality < 300 && num45 < 3)
						{
							GlobalScript.inst.gameState.KillPerson(num46);
							num45++;
						}
						else if (num45 >= 3)
						{
							break;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "多亏我们特工的协同工作，反对我们自动化政策的权力高层人物已被\n撤离一切岗位，即将接受公正审判。\n与此同时，在基层又发动了肃贪运动，动摇了数以万计党务人员的地\n位——他们曾公开反对中共所推行的路线。\n对我们敬爱的领袖的对手所进行的政治打击，\n引起了其余党务人员的不满；出于个人安全的考虑，\n他们不得不把怨气藏起来。\n尽管如此，这仍是我们的宏大胜利！\n向主席致敬！向中共致敬！";
					GlobalScript.inst.gameState.data[9] -= 400;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[6] += 50;
					GlobalScript.inst.gameState.data[1] -= 500;
					int num47 = 0;
					for (int num48 = 0; num48 < GlobalScript.inst.gameState.politics.Length; num48++)
					{
						if (GlobalScript.inst.gameState.politics[num48].loyality < 300 && num47 < 3)
						{
							GlobalScript.inst.gameState.KillPerson(num48);
							num47++;
						}
						else if (num47 >= 3)
						{
							break;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "第二天，忠诚的军队开进北京，阴谋者被逮捕并接受审判。\n首都实行宵禁，城市街道由军队单位控制，\n局势似乎正在逐步趋于稳定。\n最积极的党棍被撤职，其余人则不得不把对同志所推行路线的激烈批\n评按下去……" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "……尽管如此，工人阶级的敌人已经被打败——这就是我们的宏大胜\n利！向主席致敬！向中共致敬！";
					GlobalScript.inst.gameState.data[22] -= 300;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[1] -= 500;
					GlobalScript.inst.gameState.data[6] += 50;
					int num49 = 0;
					for (int num50 = 0; num50 < GlobalScript.inst.gameState.politics.Length; num50++)
					{
						if (GlobalScript.inst.gameState.politics[num50].loyality < 300 && num49 < 3)
						{
							GlobalScript.inst.gameState.KillPerson(num50);
							num49++;
						}
						else if (num49 >= 3)
						{
							break;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 112)
			{
				text2 = "未知世界的故事";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "政府紧急拨款，用于开发一套保护IECS免受外部攻击的系统，\n该系统的工作代号为“中华大防线”。\n预计该防护将在8个月内完成并投入使用，\n但就目前而言，我们的经济日子不会好过。";
					GlobalScript.inst.gameState.data[8] -= 250;
					GlobalScript.inst.gameState.data[3] -= 150;
					GlobalScript.inst.gameState.data[4] += 300;
					GlobalScript.inst.gameState.data[1] -= 300;
					GlobalScript.inst.gameState.data[5] -= 100;
					GlobalScript.inst.gameState.data[12] -= 200;
					GlobalScript.inst.gameState.data[13] -= 200;
					GlobalScript.inst.gameState.data[68] -= 200;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "政府紧急拨款，用于开发一套保护IECS免受外部攻击的系统，\n该系统的工作代号为“中华大防线”。\n此外，我们还请求苏联派遣专家与工程师，\n帮助我们迅速消除系统中的漏洞并恢复运行。\n预计该防护将在6个月内完成并投入使用，\n但就目前而言，我们的经济日子不会好过。";
					GlobalScript.inst.gameState.data[8] -= 250;
					GlobalScript.inst.gameState.data[3] -= 150;
					GlobalScript.inst.gameState.data[4] += 300;
					GlobalScript.inst.gameState.data[1] -= 300;
					GlobalScript.inst.gameState.data[5] -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "中国政府发布了关于《自动化问题及其解决办法》的法令，\n指出在计划的计算机化与自动化方面过于仓促，\n以及中国经济对过快、过于激进的变革缺乏准备——尤其是在这种偏\n向技术官僚路线的情况下。\nIECS项目被改组为“生产自动化控制司”，\n其主要任务不再是建立一套统一的计算机化系统。\n至于结果如何，时间自会说明。";
					GlobalScript.inst.gameState.data[8] -= 250;
					GlobalScript.inst.gameState.data[3] -= 300;
					GlobalScript.inst.gameState.data[4] += 500;
					GlobalScript.inst.gameState.data[16] = 10;
					GlobalScript.inst.gameState.data[5] -= 100;
					GlobalScript.inst.gameState.data[12] -= 200;
					GlobalScript.inst.gameState.data[13] -= 200;
					GlobalScript.inst.gameState.data[68] -= 200;
					GlobalScript.inst.gameState.modifies[11].active = false;
					GlobalScript.inst.gameState.data[16] = 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 113)
			{
				text2 = "南斯拉夫社会主义自治的煎熬";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "无论是塞尔维亚人彼得尔·斯坦博利奇，\n还是在SFRY主席团主席一职上接替他的克罗地亚人米卡·斯皮利\n亚克，都不敢执行委员会提出的改革。\nSFRY又向IMF和苏联追加借款，这只会暂时延长南斯拉夫经济\n的痛苦……";
					GlobalScript.inst.gameState.data[86]--;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "我们主席亲自致电塞尔维亚的彼得尔·斯坦博利奇、\n克罗地亚的米尔卡·普拉宁茨以及斯洛文尼亚的米特亚·里比契奇，\n把我们的提案转交给他们：以拒绝改革为交换，\n重组南斯拉夫的公共债务。\n突然间才明白，南斯拉夫人自己都不清楚到底欠了谁、\n欠了多少——债务积累得太多了。\n我们不得不在联合国为SFRY斡旋，并动用MSS的能力，\n至少对IMF和IBER施加压力，促使其确定债务数额。\n最终，放贷方开出“最终账单”——年息8%，\n总计530亿美元，并同意注销其余部分。\n我们将以协议担保方身份支付其中一部分资金；\n其余部分由南斯拉夫自行承担。\n南斯拉夫领导层感谢我们拯救他们免于经济崩溃；\nSFRY已经与我们签订了新的、颇有利润的贸易合同，\n并在其各共和国与我们自治地区之间建立文化联系。\n只是，南斯拉夫免于金融崩溃的“救命恩情”，\n显然并未给我们的经济带来好处……";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.data[8] -= 200;
					GlobalScript.inst.gameState.data[86] += 2;
					if (!GlobalScript.inst.gameState.allcountries[15].Torg)
					{
						GlobalScript.inst.gameState.allcountries[15].Torg = true;
					}
					else
					{
						GlobalScript.inst.gameState.data[9] += 30;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "华沙条约组织成员国的领导层对“克拉伊赫尔委员会”的工作极为警\n惕，并提出：只要南斯拉夫拒绝执行其提出的改革，\n就给予其巨额财政援助。\n我们也支持了这一提议。\n南斯拉夫领导层担心自己会在经济上彻底依赖苏联与中国，\n于是礼貌地拒绝了援助——但“克拉伊赫尔委员会”还是被解散，\n部分成员被开除出南斯拉夫共产党联盟，\n谢尔盖·克拉伊赫尔也被退职。\n然而在此之后，南斯拉夫扩大了其参与经互会活动的程度，\n并申请以正式成员身份加入该委员会。\n与经互会成员国的合作确实使南斯拉夫经济得以焕发生机，\n但债务迟早还是得偿还……";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 200;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					GlobalScript.inst.gameState.data[6] -= 10;
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[86]++;
					GlobalScript.inst.gameState.allcountries[15].isSEV = true;
					if (!GlobalScript.inst.gameState.allcountries[15].Torg)
					{
						GlobalScript.inst.gameState.allcountries[15].Torg = true;
					}
					else
					{
						GlobalScript.inst.gameState.data[9] += 30;
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 4)
				{
					text = "“克拉伊赫尔委员会”的工作以及“军费将首先削减”的消息，\n引发了YPA军官们的强烈不满。\n我们决定借此机会支持那些不满者，推动他们公开发声。\n3月1日，YPA的第252装甲旅、第1无产阶级机械化师以及第\n453机械化旅叛乱，并迅速占领贝尔格莱德。\n军事反情报力量逮捕了国家全部领导层以及南斯拉夫共产党联盟。\n政权转交给“南斯拉夫人民国防军事委员会”，\n由将军维尔科·卡迪耶维奇（南斯拉夫人）\n和海军上将布兰科·马穆拉（斯洛文尼亚人，\n统一南斯拉夫的支持者）领导。\n他们宣称“忠于马克思-恩格斯-列宁事业与同志铁托”，\n并“毫不妥协地打击敌人和叛徒，保卫南斯拉夫各民族与各族人民的\n兄弟情谊与团结”。在取代已解散的UKY之后，\n成立了“共产主义者联盟——南斯拉夫运动”，\n其中全部领导层也同样落入军方手中。\n南斯拉夫宣布停止“非结盟”政策，退出不结盟运动，\n并转向社会主义阵营，“由苏联与中国共同领导”，\n同时拒绝偿还全部债务。\n美国已经表态不会对此置之不理，而在斯洛文尼亚，\n分离主义情绪也显著上升……";
					GlobalScript.inst.gameState.data[9] -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[6] += 30;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 30;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 250;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 200;
					GlobalScript.inst.gameState.data[86] += 2;
					if (!GlobalScript.inst.gameState.allcountries[15].Torg)
					{
						GlobalScript.inst.gameState.allcountries[15].Torg = true;
					}
					else
					{
						GlobalScript.inst.gameState.data[9] += 30;
					}
					GlobalScript.inst.gameState.allcountries[15].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[15].SubGosstroy = 0;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 5)
				{
					text = "美国一旦得知委员会的工作，南斯拉夫就收到一份提议：\n在对其有利的条件下获得新贷款——但前提是必须批准一揽子市场化\n改革。我们支持了这一点，并通过非正式渠道向SFRY领导层建议\n同意：彼得尔·斯坦博利奇（塞尔维亚人）\n提前辞去SFRY主席团主席职务，米尔卡·普拉宁茨（克罗地亚人）\n也辞去SFRY总理职务。\n改革支持者米卡·斯皮利亚克和安特·马尔科维奇（两人均为克罗地\n亚人）接替了他们，开始执行委员会制定的方案。\n国有资产私有化启动，zadrugas（集体农业合作组织）\n终于被取消，允许农耕；并在杜布罗夫尼克与斯普利特开设自由经济\n区。只是，联邦基金的清算引发了欠发达共和国与自治地区的强烈不\n满；YNA司令部对军费大幅削减感到愤怒；\n而斯洛文尼亚与克罗地亚转向完全成本核算，\n则导致民族主义与分离主义急剧升温……";
					GlobalScript.inst.gameState.data[9] -= 50;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 20;
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[6] -= 30;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 200;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 250;
					GlobalScript.inst.gameState.data[86] -= 3;
					GlobalScript.inst.gameState.allcountries[15].Vyshi = true;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 6)
				{
					text = "南斯拉夫处境极其艰难，被迫推行严厉的紧缩政策，\n导致贫困化，甚至连必需的食品与燃料都出现短缺。\n于是我们出手了。通过与总理米尔卡·普拉宁茨的紧急谈判，\n我们达成协议：以购买南斯拉夫债券并对其进行部分重组为交换条件，\n让我们的企业以优惠条件进入南斯拉夫市场。\n长期来看，这种渗透将使我们得以谨慎介入该国的国内政治。";
					GlobalScript.inst.gameState.data[9] -= 80;
					GlobalScript.inst.gameState.data[8] -= 200;
					GlobalScript.inst.gameState.allcountries[15].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[15].Torg = true;
					GlobalScript.inst.gameState.allcountries[15].proprc = true;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 15;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 115)
			{
				text2 = "金三角";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "一切照旧。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "尽管有些坚持原则的党内成员在得知协议后提出抗议，\n我们仍然成功与坤沙达成合作——他认为，\n拒绝这种帮助不如不拒绝。\n如今，MSS特工与解放军人员参与鸦片产业的安保，\n并协助将毒品走私到西方；而在我们的坚持下，\n绝大多数“货物”如今都流向那里。\n西方海洛因销量的暴涨，并没有以最好的方式影响其经济与民众健康，\n反而要求这些国家的警方投入更多精力——这又需要更多预算资金。\n掸邦分裂势力对缅甸政府军又发动了新行动，\n虽然并未取得太多成效。\n由于我们把保密工作做得周全，我们也没有什么可供官方拿出来的“\n证据”，但缅甸当局仍然心里有数，减少与我们的周转；\n而我们一些地方官员与牵涉其中的军官也决定加入这门“赚钱的生意\n”。但愿我们的利润能抵消这一切。";
					GlobalScript.inst.gameState.data[8] += 70;
					GlobalScript.inst.gameState.data[9] -= 10;
					GlobalScript.inst.gameState.data[26] += 40;
					GlobalScript.inst.gameState.data[1] -= 150;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GlobalScript.inst.gameState.allcountries[33].Torg = true;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic97 in politics)
					{
						if (politic97.traits[0] == 0)
						{
							Politic politic = politic97;
							politic.loyality -= 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "在我们同中华人民共和国、老挝、缅甸与泰国代表的会晤中，\n会议通过了一项联合打击东南亚有组织犯罪的方案。\n中国MSS的工作人员与上述国家的执法机构共同开展了大量调查，\n揭露了毒贩与政府官员之间错综复杂的关系，\n也查明了一些贩运路线。\n与此同时，这也使我们得以更准确地掌握犯罪集团的据点位置，\n并在盟军与解放军的协助下成功实施了数次突袭。\n当然，金三角仍远未被彻底击败，但这些措施已大大加难毒贩的日常\n生计，也让我们的伙伴更轻松——他们为此真诚地向我们致谢；\n而缅甸在掸邦分裂势力衰退后最为宽慰，\n终于勾勒出其对外政策的亲华方向。";
					GlobalScript.inst.gameState.data[9] -= 20;
					GlobalScript.inst.gameState.data[22] -= 20;
					GlobalScript.inst.gameState.data[26] -= 20;
					GlobalScript.inst.gameState.allcountries[33].proprc = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 435)
			{
				text2 = GlobalScript.inst.new_events_text[1647];
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = GlobalScript.inst.new_events_text[1653];
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support--;
					leader = GlobalScript.inst.gameState.empires[1].leaders[4];
					leader.support--;
					leader = GlobalScript.inst.gameState.empires[1].leaders[1];
					leader.support--;
					leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support -= 2;
					GlobalScript.inst.gameState.data[8] -= 50;
					GlobalScript.inst.gameState.data[9] -= 100;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = GlobalScript.inst.new_events_text[1654];
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support++;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 5;
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = GlobalScript.inst.new_events_text[1655];
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 436)
			{
				text2 = GlobalScript.inst.new_events_text[1656];
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[2];
				leader.support++;
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = GlobalScript.inst.new_events_text[1661];
					GlobalScript.inst.gameState.data[8] -= 5;
					GlobalScript.inst.gameState.data[3] += 25;
					GlobalScript.inst.gameState.data[4] -= 25;
					GlobalScript.inst.gameState.data[5] += 25;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection += 5;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic98 in politics)
					{
						if (politic98.traits[0] == 0)
						{
							Politic politic = politic98;
							politic.loyality -= 100;
						}
						else
						{
							Politic politic = politic98;
							politic.loyality += 50;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = GlobalScript.inst.new_events_text[1662];
					GlobalScript.inst.gameState.data[1] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.SOV_PRC_PartiesConnection -= 5;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic99 in politics)
					{
						if (politic99.traits[0] == 0)
						{
							Politic politic = politic99;
							politic.loyality += 100;
							politic = politic99;
							politic.power += 25;
						}
						else
						{
							Politic politic = politic99;
							politic.loyality -= 50;
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = GlobalScript.inst.new_events_text[1663];
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 116)
			{
				text2 = "两个中国";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "一切照旧。";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "今天，由我方领袖率领的中国代表团对台北进行了具有历史意义的访\n问。在闭门谈判中，双方决定成立一个委员会，\n制定关于台湾与大陆逐步实现重新统一的原则。\n当然，外资所有者将保留其全部权利；台湾省将获得长期的广泛经济\n与政治自治。所有与美国军队相关的事项，\n将由已签订的条约来确定，之后其驻留问题将由统一政府作出决定。\n尽管这一切目前仍停留在纸面上，还需要在充分考虑双方利益的前提\n下进行细化落实；而台湾回归中国大家庭的时间表尚未确定，\n但我们的民众对这一消息热烈接受，边境管控也显著放松。\n正因如此，来自台湾的自由化思潮更容易渗透进来；\n美国人也担心其在岛上的影响力，但我们的人民却非常高兴。";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 70;
					GlobalScript.inst.gameState.data[4] += 80;
					GlobalScript.inst.gameState.data[3] += 120;
					GlobalScript.inst.gameState.allcountries[38].proprc = true;
					GlobalScript.inst.gameState.allcountries[38].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[38].SubGosstroy = 5;
					GlobalScript.inst.gameState.data[64] = 2;
					GlobalScript.inst.gameState.allcountries[1].ILoveSuckCocks();
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "今天，由我方领袖率领的中国代表团对台北进行了具有历史意义的访\n问。在谈判过程中，双方决定相互承认。\n自此以后，中华人民共和国与“台湾共和国”（在协议条款下，\n将中华民国更名为此）将作为两个独立国家并存。\n这也结束了多年来关于领土与合法政府的争议，\n使我们的关系提升到新的水平。\n美国欢迎我们的举动，并为支持我们的政策提供了可观的财政援助。\n然而，仍有不少人不满：两個中国似乎将永远分裂下去。";
					GlobalScript.inst.gameState.data[8] += 70;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					GlobalScript.inst.gameState.data[3] -= 80;
					GlobalScript.inst.gameState.data[4] += 50;
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.allcountries[38].Torg = true;
					GlobalScript.inst.gameState.allcountries[38].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[38].SubGosstroy = 5;
					GlobalScript.inst.gameState.data[64] = 1;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 5)
			{
				text2 = "Ответ Живкова";
				if (GlobalScript.inst.gameState.number_otvet == 1)
				{
					text = "";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 2)
				{
					text = "";
				}
				else if (GlobalScript.inst.gameState.number_otvet == 3)
				{
					text = "";
				}
			}
			else
			{
				text2 = "此处无内容";
				text = "此处无内容";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 1)
		{
			GlobalScript.inst.gameState.data[106] = 0;
			text2 = "Выборы, выборы, кандидаты...";
			float[] array14 = new float[5]
			{
				0f,
				(GlobalScript.inst.gameState.data[3] * 2 - GlobalScript.inst.gameState.data[4] / 2 + GlobalScript.inst.gameState.data[5] / 2) / 10,
				0f,
				0f,
				0f
			};
			if (GlobalScript.inst.gameState.is_party_enabled[0])
			{
				array14[0] = (1000 - GlobalScript.inst.gameState.data[3] - GlobalScript.inst.gameState.data[4] / 2) / 10;
				if (GlobalScript.inst.gameState.data[67] > 0)
				{
					array14[0] += 10f;
				}
				if (GlobalScript.inst.gameState.data[66] > 0)
				{
					array14[0] += 10f;
				}
				if (GlobalScript.inst.gameState.data[5] <= 500)
				{
					array14[0] += (1000 - GlobalScript.inst.gameState.data[5]) / 20;
				}
				if (GlobalScript.inst.gameState.empires[1].relations <= 600)
				{
					array14[0] += (1000 - GlobalScript.inst.gameState.empires[1].relations) / 100;
				}
			}
			else
			{
				array14[0] = 0f;
			}
			if (GlobalScript.inst.gameState.is_party_enabled[2])
			{
				array14[2] = (1000 - GlobalScript.inst.gameState.data[3] + GlobalScript.inst.gameState.data[4] / 2 + GlobalScript.inst.gameState.data[31] / 10) / 10;
				if (GlobalScript.inst.gameState.data[67] > 0)
				{
					array14[2] += 10f;
				}
				if (GlobalScript.inst.gameState.data[66] > 0)
				{
					array14[2] += 10f;
				}
				if (GlobalScript.inst.gameState.empires[1].relations <= 600)
				{
					array14[2] += (1000 - GlobalScript.inst.gameState.empires[1].relations) / 100;
				}
			}
			else
			{
				array14[2] = 0f;
			}
			if (GlobalScript.inst.gameState.is_party_enabled[3])
			{
				array14[3] = (1000 - GlobalScript.inst.gameState.data[3] + GlobalScript.inst.gameState.data[4] / 2 + (GlobalScript.inst.gameState.data[31] - GlobalScript.inst.gameState.data[3] / 2)) / 10;
				if (GlobalScript.inst.gameState.data[67] > 0)
				{
					array14[3] += 10f;
				}
				if (GlobalScript.inst.gameState.data[66] > 0)
				{
					array14[3] += 10f;
				}
				if (GlobalScript.inst.gameState.data[18] != 21)
				{
					array14[3] += (700 - GlobalScript.inst.gameState.data[3]) / 10;
				}
				if (GlobalScript.inst.gameState.empires[0].relations <= 600)
				{
					array14[3] += (1000 - GlobalScript.inst.gameState.empires[0].relations) / 100;
				}
			}
			else
			{
				array14[3] = 0f;
			}
			if (GlobalScript.inst.gameState.is_party_enabled[4])
			{
				array14[4] = (1000 - GlobalScript.inst.gameState.data[3] + GlobalScript.inst.gameState.data[4] / 2) / 10;
				if (GlobalScript.inst.gameState.empires[0].relations <= 600)
				{
					array14[3] += (1000 - GlobalScript.inst.gameState.empires[0].relations) / 100;
				}
			}
			else
			{
				array14[4] = 0f;
			}
			GlobalScript.inst.gameState.data[125] = 1;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				int num51 = 0;
				float[] array15 = new float[5];
				for (int num52 = 0; num52 < array14.Length; num52++)
				{
					if (array14[num52] < 0f)
					{
						array14[num52] = 1f;
					}
					num51 += (int)array14[num52];
				}
				int num53 = 0;
				GlobalScript.inst.gameState.party_number[1] = (int)(3000f * (array14[1] / (float)num51));
				for (int num54 = 0; num54 < GlobalScript.inst.gameState.party_number.Length; num54++)
				{
					array15[num54] = 3000f * (array14[num54] / (float)num51);
					GlobalScript.inst.gameState.party_number[num54] = (int)array15[num54];
					GlobalScript.inst.gameState.party_ideology[num54] = (int)array15[num54];
					if (num54 == 1)
					{
						num53 += (int)array15[num54];
					}
					else if (GlobalScript.inst.gameState.is_party_ally[num54])
					{
						num53 += (int)array15[num54];
						if (GlobalScript.inst.gameState.party_number[num54] >= GlobalScript.inst.gameState.party_number[1])
						{
							GlobalScript.inst.gameState.is_party_ally[num54] = false;
						}
					}
				}
				if (GlobalScript.inst.gameState.party_number[1] > 1500)
				{
					text = "Мы победили с разгромным результатом, заняв большинство мест в ВСНП и доказав Китаю и всему миру, что именно нас народ признаёт своими правителями!";
					GlobalScript.inst.gameState.data[3] += 10;
					GlobalScript.inst.gameState.data[4] -= 20;
					GlobalScript.inst.gameState.data[1] += 50;
				}
				else if (num53 > 1500)
				{
					text = "Наш альянс партий победил на выборах в ВСНП и доказал Китаю и всему миру, что именно нас народ признаёт своими правителями!";
				}
				else
				{
					text = "Мы утратили не то что большинство, мы теперь не занимаем даже 50% мест в ВСНП! Это позор!";
					GlobalScript.inst.gameState.data[35] = 5;
					load_scene_after_click = "Ending";
				}
				text += "|Результаты выборов:";
				for (int num55 = 0; num55 < GlobalScript.inst.gameState.party_number.Length; num55++)
				{
					if (GlobalScript.inst.gameState.is_party_enabled[num55])
					{
						text = text + "|" + GlobalScript.inst.gameState.party_name[num55 + 5] + ": " + GlobalScript.inst.gameState.party_number[num55] + " мест из 3000";
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "С помощью обещания премий, выплат и угроз увольнений и понижений нам удалось заставить госслужащих прийти на голосование и проголосовать за нашу партию. Впрочем народ надолго запомнит столь открытое жульничество.";
				array14[1] += GlobalScript.inst.gameState.data[1] / 10;
				int num56 = 0;
				float[] array16 = new float[5];
				for (int num57 = 0; num57 < array14.Length; num57++)
				{
					if (array14[num57] < 0f)
					{
						array14[num57] = 1f;
					}
					num56 += (int)array14[num57];
				}
				int num58 = 0;
				GlobalScript.inst.gameState.party_number[1] = (int)(3000f * (array14[1] / (float)num56));
				for (int num59 = 0; num59 < GlobalScript.inst.gameState.party_number.Length; num59++)
				{
					array16[num59] = 3000f * (array14[num59] / (float)num56);
					GlobalScript.inst.gameState.party_number[num59] = (int)array16[num59];
					GlobalScript.inst.gameState.party_ideology[num59] = (int)array16[num59];
					if (num59 == 1)
					{
						num58 += (int)array16[num59];
					}
					else if (GlobalScript.inst.gameState.is_party_ally[num59])
					{
						num58 += (int)array16[num59];
						if (GlobalScript.inst.gameState.party_number[num59] >= GlobalScript.inst.gameState.party_number[1])
						{
							GlobalScript.inst.gameState.is_party_ally[num59] = false;
						}
					}
				}
				if (GlobalScript.inst.gameState.party_number[1] > 1500)
				{
					text = "Мы победили с разгромным результатом, заняв большинство мест в ВСНП и доказав Китаю и всему миру, что именно нас народ признаёт своими правителями!";
					GlobalScript.inst.gameState.data[3] += 10;
					GlobalScript.inst.gameState.data[4] -= 20;
					GlobalScript.inst.gameState.data[1] += 50;
				}
				else if (num58 > 1500)
				{
					text = "Наш альянс партий победил на выборах в ВСНП и доказавл Китаю и всему миру, что именно нас народ признаёт своими правителями!";
				}
				else
				{
					text = "Мы утратили не то что большинство, мы теперь не занимаем даже 50% мест в ВСНП! Это позор!";
					GlobalScript.inst.gameState.data[35] = 5;
					load_scene_after_click = "Ending";
				}
				text += "|Результаты выборов:";
				for (int num60 = 0; num60 < GlobalScript.inst.gameState.party_number.Length; num60++)
				{
					if (GlobalScript.inst.gameState.is_party_enabled[num60])
					{
						text = text + "|" + GlobalScript.inst.gameState.party_name[num60 + 5] + ": " + GlobalScript.inst.gameState.party_number[num60] + " мест из 3000";
					}
				}
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[6] += 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Спецслужбы отлично поработали, добывая нам места. Только очень измотались.";
				if (GlobalScript.inst.gameState.data[9] < 100)
				{
					array14[1] += GlobalScript.inst.gameState.data[9] * 2;
					GlobalScript.inst.gameState.data[9] = 0;
				}
				else
				{
					array14[1] += 200f;
					GlobalScript.inst.gameState.data[9] -= 100;
				}
				int num61 = 0;
				float[] array17 = new float[5];
				for (int num62 = 0; num62 < array14.Length; num62++)
				{
					if (array14[num62] < 0f)
					{
						array14[num62] = 1f;
					}
					num61 += (int)array14[num62];
				}
				int num63 = 0;
				GlobalScript.inst.gameState.party_number[1] = (int)(3000f * (array14[1] / (float)num61));
				for (int num64 = 0; num64 < GlobalScript.inst.gameState.party_number.Length; num64++)
				{
					array17[num64] = 3000f * (array14[num64] / (float)num61);
					GlobalScript.inst.gameState.party_number[num64] = (int)array17[num64];
					GlobalScript.inst.gameState.party_ideology[num64] = (int)array17[num64];
					if (num64 == 1)
					{
						num63 += (int)array17[num64];
					}
					else if (GlobalScript.inst.gameState.is_party_ally[num64])
					{
						num63 += (int)array17[num64];
						if (GlobalScript.inst.gameState.party_number[num64] >= GlobalScript.inst.gameState.party_number[1])
						{
							GlobalScript.inst.gameState.is_party_ally[num64] = false;
						}
					}
				}
				if (GlobalScript.inst.gameState.party_number[1] > 1500)
				{
					text = "Мы победили с разгромным результатом, заняв большинство мест в ВСНП и доказав Китаю и всему миру, что именно нас народ признаёт своими правителями!";
					GlobalScript.inst.gameState.data[3] += 10;
					GlobalScript.inst.gameState.data[4] -= 20;
					GlobalScript.inst.gameState.data[1] += 50;
				}
				else if (num63 > 1500)
				{
					text = "Наш альянс партий победил на выборах в ВСНП и доказавл Китаю и всему миру, что именно нас народ признаёт своими правителями!";
				}
				else
				{
					text = "Мы утратили не то что большинство, мы теперь не занимаем даже 50% мест в ВСНП! Это позор!";
					GlobalScript.inst.gameState.data[35] = 5;
					load_scene_after_click = "Ending";
				}
				text += "|Результаты выборов:";
				for (int num65 = 0; num65 < GlobalScript.inst.gameState.party_number.Length; num65++)
				{
					if (GlobalScript.inst.gameState.is_party_enabled[num65])
					{
						text = text + "|" + GlobalScript.inst.gameState.party_name[num65 + 5] + ": " + GlobalScript.inst.gameState.party_number[num65] + " мест из 3000";
					}
				}
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 150;
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.data[22] -= 10;
				GlobalScript.inst.gameState.data[31] -= 10;
				GlobalScript.inst.gameState.empires[0].money = 24;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 3)
		{
			text2 = "Смерть кормчего";
			GlobalScript.inst.gameState.data[38] = 100;
			GlobalScript.inst.gameState.politics[0].name_1 = 1;
			GlobalScript.inst.gameState.politics[0].name_2 = 41;
			GlobalScript.inst.gameState.politics[0].age = 35;
			GlobalScript.inst.gameState.politics[0].traits[0] = 0;
			GlobalScript.inst.gameState.politics[0].traits[1] = 4;
			GlobalScript.inst.gameState.politics[0].traits[2] = 14;
			GlobalScript.inst.gameState.politics_dolshnost[1] = 150;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "После того как о смерти Мао было объявлено, его тело на неделю было положено в Дом народных собраний, чтобы каждый желающий мог попрощаться с председателем, по всей стране был объявлен траур. Многие жители Китая пришли отдать последние почести их великому лидеру и учителю. По истечении срока тело Мао было кремировано, согласно его желанию, а урна с прахом после трёх минут молчания и прощальной речи Хуа Гофэна на площади Тяньаньмэнь была замурована в специально построенный на этой же площади монумент.";
				GlobalScript.inst.gameState.data[4] -= 50;
				GlobalScript.inst.gameState.data[3] += 20;
				Politic politic = GlobalScript.inst.gameState.politics[4];
				politic.loyality -= 400;
				politic = GlobalScript.inst.gameState.politics[1];
				politic.loyality -= 400;
				politic = GlobalScript.inst.gameState.politics[2];
				politic.loyality -= 400;
				politic = GlobalScript.inst.gameState.politics[3];
				politic.loyality -= 400;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "После того как о смерти Мао было объявлено, его тело на неделю было положено в Дом народных собраний, чтобы каждый желающий мог попрощаться с председателем, по всей стране был объявлен траур. Многие жители Китая пришли отдать последние почести их великому лидеру и учителю. По истечении срока тело Мао было отвезено в больницу и забальзамировано по специально разработанной методике. После трёх минут молчания и прощальной речи Хуа Гофэна на площади Тяньаньмэнь председатель упокоился в сооружённом на этой же площади по специальному распоряжению Гофэна мавзолее.";
				GlobalScript.inst.gameState.data[4] -= 70;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[1] += 40;
				GlobalScript.inst.gameState.data[8] -= 10;
				Politic politic = GlobalScript.inst.gameState.politics[4];
				politic.loyality -= 300;
				politic = GlobalScript.inst.gameState.politics[1];
				politic.loyality -= 300;
				politic = GlobalScript.inst.gameState.politics[2];
				politic.loyality -= 300;
				politic = GlobalScript.inst.gameState.politics[3];
				politic.loyality -= 300;
				GlobalScript.inst.gameState.data[104] = 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Гофэн решил напрямую не участвовать в организации похорон, что не осталось незамеченным. После того как о смерти Мао было объявлено, его тело на неделю было положено в Дом народных собраний, чтобы каждый желающий мог попрощаться с председателем, по всей стране был объявлен траур. Многие жители Китая пришли отдать последние почести их великому лидеру и учителю. По истечении срока тело Мао было отвезено в больницу и забальзамировано по специально разработанной методике. После трёх минут молчания и прощальной речи Хуа Гофэна на площади Тяньаньмэнь председатель упокоился в сооружённом на этой же площади по специальному распоряжению похоронной комиссии мавзолее.";
				GlobalScript.inst.gameState.data[4] -= 70;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[1] -= 40;
				Politic politic = GlobalScript.inst.gameState.politics[4];
				politic.loyality -= 500;
				politic = GlobalScript.inst.gameState.politics[1];
				politic.loyality -= 500;
				politic = GlobalScript.inst.gameState.politics[2];
				politic.loyality -= 500;
				politic = GlobalScript.inst.gameState.politics[3];
				politic.loyality -= 500;
				GlobalScript.inst.gameState.data[104] = 10;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 4)
		{
			text2 = "Заговор";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				int num66 = 0;
				for (int num67 = 0; num67 < GlobalScript.inst.gameState.politics.Length; num67++)
				{
					if (GlobalScript.inst.gameState.politics[num67].loyality > 600)
					{
						num66++;
					}
				}
				if (GlobalScript.inst.gameState.data[1] > 500 && num66 >= 4)
				{
					text = "Прежде, чем заговорщики успели озвучить свои обвинения, вы обрушились на них с критикой и встречными обвинениями. Большинство присутствующих на съезде поддержало вас и заговорщикам пришлось отступить.";
					GlobalScript.inst.gameState.data[1] += 50;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic100 in politics)
					{
						if (((politic100.loyality < 300 && politic100.traits[2] == 16) || politic100.you_fall || (politic100.loyality < 150 && politic100.traits[2] != 9) || (politic100.loyality < 50 && politic100.traits[2] == 9)) && politic100.traits[2] != 17 && politic100.traits[2] != 19 && !politic100.is_sledstvie)
						{
							Politic politic = politic100;
							politic.power -= 100;
							politic = politic100;
							politic.loyality -= 100;
							politic100.is_sledstvie = true;
							politic100.sled_slej = 1;
						}
					}
				}
				else
				{
					text = "Прежде, чем заговорщики успели озвучить свои обвинения, вы обрушились на них с критикой и встречными обвинениями. Однако, убедительности вам явно не хватило, да и большинство партийцев устало от вашего правления. Большинство присутствующих на съезде поддержало заговорщиков, а вы были смещены с поста, исключены из ЦК и отправлены на далёкую безвластную должность.";
					GlobalScript.inst.gameState.data[1] = 0;
					GlobalScript.inst.gameState.data[3] = 0;
					GlobalScript.inst.gameState.data[35] = 2;
					load_scene_after_click = "Ending";
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Ещё до начала съезда верные вам агенты спецслужб скрутили прибывших заговорщиков и отправили их в следственные изоляторы. На съезде вы заочно раскритиковали их, что было поддержано делегатами. Впрочем от высоких партийцев не так то просто избавиться...";
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[9] -= 100;
				if (GlobalScript.inst.gameState.data[1] <= 300 + GlobalScript.inst.gameState.data[4] / 5 - (GlobalScript.inst.gameState.data[3] - 500) / 5)
				{
					GlobalScript.inst.gameState.data[1] += 400;
				}
				else
				{
					GlobalScript.inst.gameState.data[1] += 50;
				}
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic101 in politics)
				{
					if (((politic101.loyality < 300 && politic101.traits[2] == 16) || politic101.you_fall || (politic101.loyality < 150 && politic101.traits[2] != 9) || (politic101.loyality < 50 && politic101.traits[2] == 9)) && politic101.traits[2] != 17 && politic101.traits[2] != 19 && !politic101.is_sledstvie)
					{
						Politic politic = politic101;
						politic.power -= 100;
						politic = politic101;
						politic.loyality -= 200;
						politic101.is_sledstvie = true;
						politic101.sled_slej = 1;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Ещё до начала съезда верные вам офицеры скрутили прибывших заговорщиков и под дулами автоматов отконвоировали их в военные тюрьмы. На съезде в присутствии вооружённых солдат вы заочно раскритиковали заговорщиков, что, конечно, было поддержано делегатами. Впрочем от высоких партийцев не так то просто избавиться...";
				GlobalScript.inst.gameState.data[3] -= 80;
				if (GlobalScript.inst.gameState.data[1] <= 300 + GlobalScript.inst.gameState.data[4] / 5 - (GlobalScript.inst.gameState.data[3] - 500) / 5)
				{
					GlobalScript.inst.gameState.data[1] += 400;
				}
				else
				{
					GlobalScript.inst.gameState.data[1] += 50;
				}
				GlobalScript.inst.gameState.data[22] -= 100;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic102 in politics)
				{
					if (((politic102.loyality < 300 && politic102.traits[2] == 16) || politic102.you_fall || (politic102.loyality < 150 && politic102.traits[2] != 9) || (politic102.loyality < 50 && politic102.traits[2] == 9)) && politic102.traits[2] != 17 && politic102.traits[2] != 19 && !politic102.is_sledstvie)
					{
						Politic politic = politic102;
						politic.power -= 100;
						politic = politic102;
						politic.loyality -= 300;
						politic102.is_sledstvie = true;
						politic102.sled_slej = 1;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Ещё до начала съезда вы обратились через СМИ к народу с призывом поддержать вас и защитить завоевания вашей власти. Преданный вам народ вышел на массовые демонстрации в вашу поддержку и начал штурмовать подконтрольные вашим противникам ведомства. Осознав свою непопулярность, заговорщики отступили, а прошедший съезд закрепил вашу власть. Впрочем народ уже порядком устал от подобных Культурных революций.";
				if (GlobalScript.inst.gameState.data[1] <= 300 + GlobalScript.inst.gameState.data[4] / 5 - (GlobalScript.inst.gameState.data[3] - 500) / 5)
				{
					GlobalScript.inst.gameState.data[1] += 400;
				}
				else
				{
					GlobalScript.inst.gameState.data[1] += 50;
				}
				GlobalScript.inst.gameState.data[3] -= 200;
				GlobalScript.inst.gameState.data[5] -= 70;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic103 in politics)
				{
					if (((politic103.loyality < 300 && politic103.traits[2] == 16) || politic103.you_fall || (politic103.loyality < 150 && politic103.traits[2] != 9) || (politic103.loyality < 50 && politic103.traits[2] == 9)) && politic103.traits[2] != 17 && politic103.traits[2] != 19 && !politic103.is_sledstvie)
					{
						Politic politic = politic103;
						politic.power -= 100;
						politic = politic103;
						politic.loyality -= 100;
						politic103.is_sledstvie = true;
						politic103.sled_slej = 1;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 5)
		{
			text2 = "Народное недовольство";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				if (GlobalScript.inst.gameState.data[3] > 700 && GlobalScript.inst.gameState.data[1] >= 500)
				{
					text = "Вы лично выступили перед протестующими в Пекине, что было транслировано по всей стране. Вы пообещали приложить все усилия для изменения политики и учёта интересов всех граждан, а также создания механизмов реальной демократии (которые вы, впрочем, не спешите внедрять). Кажется, убедить народ вам удалось, протесты потихоньку спадают.";
					GlobalScript.inst.gameState.data[3] -= 150;
					GlobalScript.inst.gameState.data[4] -= 150;
					GlobalScript.inst.gameState.data[1] -= 100;
					if (!GlobalScript.inst.gameState.is_party_enabled[1])
					{
						GlobalScript.inst.gameState.is_party_enabled[1] = true;
					}
					if (GlobalScript.inst.gameState.data[15] >= 6 && GlobalScript.inst.gameState.data[15] <= 7)
					{
						int num68 = 0;
						for (int num69 = 0; num69 < GlobalScript.inst.gameState.is_party_ally.Length; num69++)
						{
							if (GlobalScript.inst.gameState.party_ideology[num69] < 0)
							{
								GlobalScript.inst.gameState.party_ideology[num69] = 0;
							}
							if (GlobalScript.inst.gameState.is_party_ally[num69] && num69 != 1)
							{
								GlobalScript.inst.gameState.is_party_ally[num69] = false;
							}
							if (GlobalScript.inst.gameState.is_party_enabled[num69] && num69 != 1 && GlobalScript.inst.gameState.party_number[num69] > 0)
							{
								num68 += GlobalScript.inst.gameState.party_number[num69] / 2;
								GlobalScript.inst.gameState.party_number[num69] -= GlobalScript.inst.gameState.party_number[num69] / 2;
								GlobalScript.inst.gameState.party_ideology[num69] -= GlobalScript.inst.gameState.party_number[num69] / 2;
								num68 += GlobalScript.inst.gameState.party_number[num69] / 4;
								GlobalScript.inst.gameState.party_number[num69] -= GlobalScript.inst.gameState.party_number[num69] / 4;
								GlobalScript.inst.gameState.party_ideology[num69] -= GlobalScript.inst.gameState.party_number[num69] / 4;
							}
							else if (!GlobalScript.inst.gameState.is_party_enabled[num69])
							{
								GlobalScript.inst.gameState.is_party_enabled[num69] = true;
							}
							GlobalScript.inst.gameState.data[53] = 0;
						}
						GlobalScript.inst.gameState.party_number[1] += num68;
						GlobalScript.inst.gameState.party_ideology[1] += num68;
						GlobalScript.inst.gameState.data[125] = 0;
					}
					else if (GlobalScript.inst.gameState.data[15] < 9)
					{
						GlobalScript.inst.gameState.data[15]++;
					}
					else if (GlobalScript.inst.gameState.data[17] < 19)
					{
						GlobalScript.inst.gameState.data[17]++;
					}
				}
				else
				{
					text = "Вы лично выступили перед протестующими в Пекине, что было транслировано по всей стране. Вы пообещали приложить все усилия для изменения политики и учёта интересов всех граждан, а также создания механизмов реальной демократии (которые вы, впрочем, не спешите внедрять). Тем не менее, народ, уставший от ваших обещаний, воспринял их без энтузиазма и потребовал вашей отставки. Окончательно разочаровавшись в вас, партия срочно организовала ваше смещение и арест и сформировала новое правительство, которое будет руководить страной до всеобщих выборов, пока вы сидите в следственном изоляторе.";
					GlobalScript.inst.gameState.data[1] = 0;
					GlobalScript.inst.gameState.data[3] = 0;
					GlobalScript.inst.gameState.data[35] = 1;
					load_scene_after_click = "Ending";
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Армия, получив приказ, вывела бронетехнику на улицы городов и жёстко разогнала протест. Были замечены жертвы с обеих сторон. Подобные действия, разумеется уже были осуждены почти всеми странами мира.";
				GlobalScript.inst.gameState.data[4] -= 150;
				GlobalScript.inst.gameState.data[22] -= 100;
				GlobalScript.inst.gameState.data[6] += 50;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic104 in politics)
				{
					if (politic104.traits[0] == 3)
					{
						Politic politic = politic104;
						politic.loyality -= 100;
					}
				}
				GlobalScript.inst.gameState.data[113] = 9;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Через СМИ вы обратились к сочувствующим вам людям с призывом помочь защитить ваши завоевания от предателей, финансируемых США и СССР. Они тут же вышли на массовые митинги в вашу поддержку, которые зачастую заканчивались столкновениями с протестующими и их арестами. Когда пыль уличных сражений улеглась, а протестующие разбежались, ваши сторонники провели победный марш на Тяньаньмэне.";
				GlobalScript.inst.gameState.data[4] -= 200;
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.data[3] -= 300;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic105 in politics)
				{
					if (politic105.traits[0] == 3 || politic105.traits[0] == 2)
					{
						Politic politic = politic105;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				bool flag2 = false;
				int num70 = 99;
				for (int num71 = 0; num71 < GlobalScript.inst.gameState.citizens.Length; num71++)
				{
					Persona persona10 = GlobalScript.inst.gameState.citizens[num71];
					if (persona10 == null)
					{
						Debug.LogWarning($"Гражданин {num71} равен null");
					}
					else if (persona10.isLead && !persona10.isPolitic)
					{
						flag2 = true;
						num70 = num71;
					}
				}
				for (int num72 = 0; num72 < GlobalScript.inst.gameState.citizens.Length; num72++)
				{
					Persona persona11 = GlobalScript.inst.gameState.citizens[num72];
					if (persona11 == null)
					{
						Debug.LogWarning($"Гражданин {num72} равен null");
					}
					else if (persona11.isLead && persona11.isPolitic && flag2)
					{
						persona11.isLead = false;
					}
				}
				text = (flag2 ? "Вы лично выступили перед протестующими в Пекине, что было транслировано по всей стране. Вы пообещали приложить все усилия для изменения политики и учёта интересов всех граждан. Тем не менее, народ, уставший от ваших обещаний, воспринял их без энтузиазма и потребовал вашей отставки. В ответ на нарастающий гул недовольства вы приняли неожиданное решение: выдвинуть на пост лидера страны человека из народа, как того требовали протестующие. Вы представили кандидата — харизматичного политика, чья карьера выстроена на умении убеждать и завоёвывать доверие масс. Ваше решение временно утихомирило протесты, но вызвало раскол в партии, подорвав её единство. Сможет ли новый лидер удержать власть, или ваше решение лишь отсрочило кризис?" : "Вы лично выступили перед протестующими в Пекине, что было транслировано по всей стране. Вы пообещали приложить все усилия для изменения политики и учёта интересов всех граждан, а также создания механизмов реальной демократии, которые вот-вот начнут работу. Народ воодушевлён, но вместе с этим через новообретённые свободы пошёл и поток критики");
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[6] -= 50;
				if (GlobalScript.inst.gameState.data[15] != 9)
				{
					GlobalScript.inst.gameState.data[15] = 9;
				}
				else
				{
					GlobalScript.inst.gameState.data[17] = 19;
				}
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic106 in politics)
				{
					Politic politic = politic106;
					politic.loyality -= 100;
				}
				if (flag2)
				{
					CitizenManager.Instance.PromoteToPolitic(num70);
					for (int num73 = 0; num73 < GlobalScript.inst.gameState.politics.Length; num73++)
					{
						Politic politic107 = GlobalScript.inst.gameState.politics[num73];
						if (politic107 != null && politic107.isCitizen && GlobalScript.inst.gameState.names1[politic107.name_1] == GlobalScript.inst.gameState.citizens[num70].name && GlobalScript.inst.gameState.names2[politic107.name_2] == GlobalScript.inst.gameState.citizens[num70].surname)
						{
							GlobalScript.inst.gameState.MakeNewLeader(num73);
						}
					}
					int[] date5 = new int[3]
					{
						GlobalScript.inst.gameState.data[19],
						GlobalScript.inst.gameState.data[20],
						GlobalScript.inst.gameState.data[21]
					};
					string text12 = CitizenManager.FormatLog(GlobalScript.inst.gameState.citizens[num70], "стал правителем.", "成为领袖。", date5);
					GlobalScript.inst.gameState.citizens[num70].changeLog.Add(text12);
					Debug.Log(text12);
					GlobalScript.inst.gameState.data[1] = 0;
					achieves.GetComponent<achievements>().Set(211);
					achieves.GetComponent<achievements>().Set(210);
					Debug.Log("Ачивка Гражданин стал правителем И Гражданин пришёл к власти в результате волнений. Получена.");
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "МГБ занялось привычным делом - кого-то подкупили, кого-то устранили, а в протест стали активно вливаться всевозможные организации и люди, разлагающие его изнутри в наших интересах. Оппозиция сражается сама с собой, протест превратился в сборище без какой-либо стратегии и вскоре иссяк.";
				GlobalScript.inst.gameState.data[9] -= 150;
				GlobalScript.inst.gameState.data[4] -= 150;
				GlobalScript.inst.gameState.data[3] += 100;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 6)
		{
			text2 = "Низкий уровень жизни";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Большие средства из бюджета были срочно выделены на социальные программы, жилищные застройки и на помощь малоимущим. Социальные проблемы постепенно начинают решаться и народ доволен";
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[8] -= 100;
				GlobalScript.inst.gameState.data[5] = 300;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы запросили иностранную гуманитарную помощь, которую нам согласились выделить. Добровольцы из разных стран и из ООН раздают продовольствие, а также занимаются застройкой жилья для людей на безвозмездных условиях. Впрочем подобные действия показали как нашему народу, так и мировому сообществу, что своими силами мы с подобным справиться не можем, что сильно подрывает наш престиж.";
				GlobalScript.inst.gameState.data[4] += 200;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 100;
				GlobalScript.inst.gameState.data[5] = 300;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Путём развития трудового законодательства, государственных заказов, льгот и банального принуждения мы сумели заставить наших бизнесменов оказать народу социальную поддержку, улучшить рабочие и жилищные условия. Впрочем, они не особо рады делиться своими богатствами с народом и активно используют связи в верхах, чтобы оказать на вас давление.";
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[1] -= 500;
				GlobalScript.inst.gameState.data[5] = 300;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic108 in politics)
				{
					if (politic108.traits[0] == 3 || politic108.traits[0] == 2)
					{
						Politic politic = politic108;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Выступив на чрезвычайном съезде партии, вы разъяснили верхушке всю тяжесть ситуации приняли решение о выделении средств партии на социальные нужды и в добровольно-принудительном порядке привлекли партийцев и чиновников к участию в благотворительных акциях. Уровень жизни это, конечно, подняло, но вот партия осталась недовольна.";
				GlobalScript.inst.gameState.data[1] = 0;
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[5] = 300;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic109 in politics)
				{
					Politic politic = politic109;
					politic.loyality -= 300;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 7)
		{
			text2 = "Дипломатический кризис";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Нами срочно была организована пышная встреча министров иностранных дел Китая и США, а американская делегация была приглашена на роскошное турне по Китаю, где как раз готовятся всевозможные фестивали и мероприятия, показывающие нашу миролюбивость. Разрядка удалась, напряжённость спала.";
				GlobalScript.inst.gameState.empires[0].relations = 400;
				if (GlobalScript.inst.gameState.data[6] > 600)
				{
					GlobalScript.inst.gameState.data[6] -= GlobalScript.inst.gameState.data[6] / 50;
				}
				GlobalScript.inst.gameState.data[8] -= 100;
				if (GlobalScript.inst.gameState.data[6] > 700)
				{
					GlobalScript.inst.gameState.data[6] -= 30;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы отказались от части внешнеполитических претензий, снизили поддержку лояльной оппозиции в других странах и в целом уменьшили градус интервенционизма китайской политики. Это было положительно воспринято МИД США, напряжённость снизилась. Как и наше влияние.";
				GlobalScript.inst.gameState.empires[0].relations = 400;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 50;
				GlobalScript.inst.gameState.data[22] -= 50;
				GlobalScript.inst.gameState.data[9] -= 50;
				if (GlobalScript.inst.gameState.data[6] > 700)
				{
					GlobalScript.inst.gameState.data[6] -= 50;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Напряжение нарастает.";
				GlobalScript.inst.gameState.data[35] = 3;
				load_scene_after_click = "Ending";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Напряжение нарастает.";
				if (!GlobalScript.inst.gameState.modifies[17].active)
				{
					GlobalScript.inst.gameState.data[22] -= 50;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.modifies[17].active = true;
					GlobalScript.inst.gameState.data[111]++;
					GlobalScript.inst.gameState.data[6] += 100;
				}
				if (GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.allcountries[1].isASEAN && GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.data[139] <= 0)
				{
					GlobalScript.inst.gameState.data[139] = 5;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Нами срочно была организована пышная встреча министров иностранных дел Китая и США, а американская делегация была приглашена на роскошное турне по Китаю, где как раз готовятся всевозможные фестивали и мероприятия, показывающие нашу миролюбивость. Разрядка удалась, напряжённость спала.";
				GlobalScript.inst.gameState.empires[0].relations = 400;
				GlobalScript.inst.gameState.data[168] -= 50;
				if (GlobalScript.inst.gameState.data[6] > 700)
				{
					GlobalScript.inst.gameState.data[6] -= 30;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 8)
		{
			text2 = "Дипломатический кризис";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Нами срочно была организована пышная встреча министров иностранных дел Китая и СССР, а советская делегация была приглашена на роскошное турне по Китаю, где как раз готовятся всевозможные фестивали и мероприятия, показывающие нашу миролюбивость. Разрядка удалась, напряжённость спала.";
				GlobalScript.inst.gameState.empires[1].relations = 400;
				if (GlobalScript.inst.gameState.data[6] > 600)
				{
					GlobalScript.inst.gameState.data[6] -= GlobalScript.inst.gameState.data[6] / 20;
				}
				GlobalScript.inst.gameState.data[8] -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы отказались от части внешнеполитических претензий, снизили поддержку лояльной оппозиции в других странах и в целом уменьшили градус интервенционизма китайской политики. Это было положительно воспринято МИД СССР, напряжённость снизилась. Как и наше влияние.";
				GlobalScript.inst.gameState.empires[1].relations = 400;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 50;
				GlobalScript.inst.gameState.data[22] -= 50;
				GlobalScript.inst.gameState.data[9] -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				GlobalScript.inst.gameState.data[35] = 3;
				load_scene_after_click = "Ending";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Напряжение нарастает.";
				if (!GlobalScript.inst.gameState.modifies[16].active)
				{
					GlobalScript.inst.gameState.data[22] -= 50;
					GlobalScript.inst.gameState.data[9] -= 50;
					GlobalScript.inst.gameState.modifies[16].active = true;
					GlobalScript.inst.gameState.data[111]++;
				}
				if (GlobalScript.inst.gameState.modifies[16].active && GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.dlc[3] && GlobalScript.inst.gameState.data[139] <= 0)
				{
					GlobalScript.inst.gameState.data[139] = 5;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Нами срочно была организована пышная встреча министров иностранных дел Китая и СССР, а советская делегация была приглашена на роскошное турне по Китаю, где как раз готовятся всевозможные фестивали и мероприятия, показывающие нашу миролюбивость. Разрядка удалась, напряжённость спала.";
				GlobalScript.inst.gameState.empires[1].relations = 400;
				GlobalScript.inst.gameState.data[168] -= 50;
				if (GlobalScript.inst.gameState.data[6] > 700)
				{
					GlobalScript.inst.gameState.data[6] -= 30;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 9)
		{
			text2 = "Сепаратизм в Тибете";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Тибетский автономный район официально объявил о своей независимости в границах 1950-го года. Это станет большим ударом для нас и большой возможностью для СССР и США.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 250;
				GlobalScript.inst.gameState.data[34] -= 31;
				GlobalScript.inst.gameState.data[13] -= 50;
				GlobalScript.inst.gameState.data[12] -= 10;
				GlobalScript.inst.gameState.data[57] -= 50;
				GlobalScript.inst.gameState.data[1] -= 200;
				GlobalScript.inst.gameState.data[3] -= 200;
				GlobalScript.inst.gameState.data[34] -= 31;
				GlobalScript.inst.gameState.allcountries[69].dev = 0;
				if (GlobalScript.inst.gameState.data[14] <= 3)
				{
					GlobalScript.inst.gameState.data[67] = 1;
					if (GlobalScript.inst.gameState.data[62] == 2)
					{
						GlobalScript.inst.gameState.allcountries[1].parts[8] = true;
					}
					else
					{
						GlobalScript.inst.gameState.allcountries[1].parts[7] = true;
					}
					GlobalScript.inst.gameState.allcountries[69].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[69].SubGosstroy = 6;
				}
				else
				{
					GlobalScript.inst.gameState.data[67] = 2;
					if (GlobalScript.inst.gameState.data[62] == 2)
					{
						GlobalScript.inst.gameState.allcountries[1].parts[8] = true;
					}
					else
					{
						GlobalScript.inst.gameState.allcountries[1].parts[7] = true;
					}
				}
				GlobalScript.inst.gameState.allcountries[69].prosov = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы ещё сильнее расширили полномочия местных органов власти и права тибетской автономии. Кажется, большинство населения это устроило, но это даёт радикалам больше возможностей для пропаганды сепаратизма, да и другие национальные окраины задумываются о большей независимости.";
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[57] -= 20;
				GlobalScript.inst.gameState.data[1] -= 200;
				GlobalScript.inst.gameState.data[18]++;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Лояльные части НОАК вошли в Тибет и быстро восстановили порядок. Впрочем националисты и оппозиция этого не забудут.";
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[57] += 30;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[22] -= 100;
				GlobalScript.inst.gameState.data[6] += 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Нами был организован референдум, на котором большинство, конечно же, проголосовало за сохранение статуса Тибета. Недовольные националисты и прочие радикалы вышли на улицы, заявляя о фальсификации, но без былой поддержки эти протесты уже не представляют серьёзной угрозы.";
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.data[57] += 20;
				GlobalScript.inst.gameState.data[3] -= 20;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[8] -= 40;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 10)
		{
			text2 = "Сепаратизм в Синьцзяне";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Синьцзян-Уйгурский автономный район официально объявил о своей независимости. Это станет большим ударом для нас и большой возможностью для СССР и США.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 250;
				GlobalScript.inst.gameState.data[34] -= 218;
				GlobalScript.inst.gameState.data[13] -= 50;
				GlobalScript.inst.gameState.data[12] -= 10;
				GlobalScript.inst.gameState.data[57] -= 50;
				GlobalScript.inst.gameState.data[1] -= 200;
				GlobalScript.inst.gameState.data[3] -= 200;
				GlobalScript.inst.gameState.data[34] -= 218;
				GlobalScript.inst.gameState.allcountries[70].dev = 0;
				if (!GlobalScript.inst.gameState.allcountries[12].proprc && !GlobalScript.inst.gameState.ingamewars[5].is_going && GlobalScript.inst.gameState.allcountries[12].Gosstroy != 0)
				{
					GlobalScript.inst.gameState.data[66] = 1;
					GlobalScript.inst.gameState.allcountries[1].parts[9] = true;
					GlobalScript.inst.gameState.allcountries[70].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[70].SubGosstroy = 1;
					GlobalScript.inst.gameState.allcountries[70].prosov = true;
				}
				else
				{
					GlobalScript.inst.gameState.data[66] = 2;
					GlobalScript.inst.gameState.allcountries[1].parts[9] = true;
					GlobalScript.inst.gameState.allcountries[70].prosov = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы ещё сильнее расширили полномочия местных органов власти и права синьцзян-уйгурской автономии. Кажется, большинство населения это устроило, но это даёт радикалам больше возможностей для пропаганды сепаратизма, да и другие национальные окраины задумываются о большей независимости.";
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[57] -= 20;
				GlobalScript.inst.gameState.data[1] -= 200;
				GlobalScript.inst.gameState.data[18]++;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Лояльные части НОАК вошли в Синьцзян и быстро восстановили порядок. Впрочем националисты и оппозиция этого не забудут.";
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[57] += 30;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[22] -= 100;
				GlobalScript.inst.gameState.data[6] += 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Нами был организован референдум, на котором большинство, конечно же, проголосовало за сохранение статуса Синьцзяна. Недовольные националисты и прочие радикалы вышли на улицы, заявляя о фальсификации, но без былой поддержки эти протесты уже не представляют серьёзной угрозы.";
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.data[57] += 20;
				GlobalScript.inst.gameState.data[3] -= 20;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[8] -= 40;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 11)
		{
			text2 = "Упадок промышленности";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Большие средства из бюджета были срочно выделены на модернизацию промышленности, закупку импортных технологий и привлечение специалистов в эту сферу. Проблема начинает решаться";
				GlobalScript.inst.gameState.data[12] += 100;
				GlobalScript.inst.gameState.data[8] -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наша кампания по привлечению иностранных инвестиций завершилась большим успехом! Иностранцы теперь сами построят и модернизируют нам заводы без единого юаня из нашего бюджета. Правда для этого пришлось снизить минимальную зарплату, требования к безопасности производства и другие требования трудового законодательства, но ничего, народ потерпит.";
				GlobalScript.inst.gameState.data[12] += 100;
				GlobalScript.inst.gameState.data[5] -= 50;
				GlobalScript.inst.gameState.data[4] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Советский Союз согласился, как в былые времена помочь нам с модернизацией промышленности. Впрочем, раздавать специалистов и станки за просто так ему не особо нравится, да и мы попали от СССР в некоторую зависимость.";
				GlobalScript.inst.gameState.data[12] += 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic110 in politics)
				{
					if (politic110.traits[0] == 3 || politic110.traits[0] == 2)
					{
						Politic politic = politic110;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Методом перераспределения средств бюджета и выручки от предприятий мы смогли направить мощность сельского хозяйства на развитие промышленности. Промышленности это помогло, а вот сельское хозяйство испытало большой удар.";
				GlobalScript.inst.gameState.data[12] += 100;
				GlobalScript.inst.gameState.data[13] -= 100;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 12)
		{
			text2 = "Упадок сельского хозяйства";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Большие средства из бюджета были срочно выделены на модернизацию сельского хозяйства, закупку импортных технологий и привлечение специалистов в эту сферу. Проблема начинает решаться";
				GlobalScript.inst.gameState.data[13] += 100;
				GlobalScript.inst.gameState.data[8] -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наша кампания по привлечению иностранных инвестиций завершилась большим успехом! Иностранцы теперь сами построят и модернизируют нам фермы без единого юаня из нашего бюджета. Правда для этого пришлось снизить минимальную зарплату, требования к безопасности производства и другие требования трудового законодательства, но ничего, народ потерпит.";
				GlobalScript.inst.gameState.data[13] += 100;
				GlobalScript.inst.gameState.data[5] -= 50;
				GlobalScript.inst.gameState.data[4] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Советский Союз согласился, как в былые времена помочь нам с подъёмом сельского хозяйства. Впрочем, раздавать специалистов и технику за просто так ему не особо нравится, да и мы попали от СССР в некоторую зависимость.";
				GlobalScript.inst.gameState.data[13] += 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic111 in politics)
				{
					if (politic111.traits[0] == 3 || politic111.traits[0] == 2)
					{
						Politic politic = politic111;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Методом перераспределения средств бюджета и выручки от предприятий мы смогли направить мощность промышленности на развитие сельского хозяйства. Сельскому хозяйству это помогло, а вот промышленность испытала большой удар.";
				GlobalScript.inst.gameState.data[13] += 100;
				GlobalScript.inst.gameState.data[12] -= 100;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 13)
		{
			text2 = "Упадок сферы услуг";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Большие средства из бюджета были срочно выделены на модернизацию сферы услуг, закупку импортных технологий и привлечение специалистов в эту сферу. Проблема начинает решаться";
				GlobalScript.inst.gameState.data[68] += 100;
				GlobalScript.inst.gameState.data[8] -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наша кампания по привлечению иностранных инвестиций завершилась большим успехом! Иностранцы теперь сами построят и модернизируют нам магазины и рестораны без единого юаня из нашего бюджета. Правда для этого пришлось снизить минимальную зарплату, требования к безопасности работы и другие требования трудового законодательства, но ничего, народ потерпит.";
				GlobalScript.inst.gameState.data[68] += 100;
				GlobalScript.inst.gameState.data[5] -= 50;
				GlobalScript.inst.gameState.data[4] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Советский Союз согласился помочь нам с развитием сферы услуг. Впрочем, раздавать специалистов и оборудование за просто так ему не особо нравится, да и мы попали от СССР в некоторую зависимость.";
				GlobalScript.inst.gameState.data[68] += 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic112 in politics)
				{
					if (politic112.traits[0] == 3 || politic112.traits[0] == 2)
					{
						Politic politic = politic112;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Методом перераспределения средств бюджета и выручки от предприятий мы смогли направить мощность промышленности и сельского хозяйства на развитие сферы услуг. Сфере услуг это помогло, а вот промышленность и сельское хозяйство испытали большой удар.";
				GlobalScript.inst.gameState.data[13] -= 100;
				GlobalScript.inst.gameState.data[12] -= 100;
				GlobalScript.inst.gameState.data[68] += 100;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 14)
		{
			text2 = "Денег нет, но вы держитесь!";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Были подняты налоги и сборы, а также сокращены социальные программы для населения. Пополнить бюджет это, конечно, помогло, но вот народ недоволен.";
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[8] += 100;
				GlobalScript.inst.gameState.data[5] -= 300;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Были подняты налоги на роскошь и сверхбогатство, что позволило пополнить бюджет, не задев при этом простой народ. Впрочем олигархи, используя свои силы, рассказывают народу, как государство \"обирает честных предпринимателей\" и используют рычаги влияния в партии для давления на вас.";
				GlobalScript.inst.gameState.data[8] += 100;
				GlobalScript.inst.gameState.data[1] -= 500;
				GlobalScript.inst.gameState.data[4] += 300;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				GlobalScript.inst.gameState.data[108] -= 5;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Иностранный кредит был взят, что помогло пополнить бюджет, но негативно сказалось на нашем влиянии. Да и надо его ещё выплачивать...";
				GlobalScript.inst.gameState.data[8] += 100;
				GlobalScript.inst.gameState.data[69] += 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Многие государственные предприятия были проданы в частные руки, что конечно же ударило по уровню жизни и нарушило механизм работы нашей экономики, но зато помогло пополнить бюджет.";
				GlobalScript.inst.gameState.data[5] -= 100;
				GlobalScript.inst.gameState.data[8] += 100;
				GlobalScript.inst.gameState.data[12] -= 50;
				GlobalScript.inst.gameState.data[13] -= 50;
				GlobalScript.inst.gameState.data[68] -= 50;
				GlobalScript.inst.gameState.data[108] += 20;
				if (GlobalScript.inst.gameState.data[16] <= 12)
				{
					GlobalScript.inst.gameState.data[16] = 13;
				}
				else if (GlobalScript.inst.gameState.data[16] <= 14)
				{
					GlobalScript.inst.gameState.data[16]++;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 15)
		{
			text2 = "Кампучийско-вьетнамская война";
			GlobalScript.inst.gameState.ingamewars[1].name_war = "Кампучийско-вьетнамский конфликт";
			GlobalScript.inst.gameState.ingamewars[1].is_going = true;
			GlobalScript.inst.gameState.ingamewars[1].side1 = "Кампучия";
			GlobalScript.inst.gameState.ingamewars[1].side2 = "Вьетнам";
			GlobalScript.inst.gameState.ingamewars[1].ussr_place = 1;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Мы решили не вмешиваться в конфликт. Пол Пот и руководство Красных кхмеров, конечно же, очень недовольны этим, однако не похоже, что они долго проживут - вьетнамские войска быстро продвигаются, а кампучийские солдаты массово дезертируют. Похоже, падение режима Пол Пота - лишь вопрос времени.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				GlobalScript.inst.gameState.ingamewars[1].infl1 = 300;
				GlobalScript.inst.gameState.ingamewars[1].infl2 = 700;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Выйдя на контакт с левой оппозицией внутри кампучиской армии, мы смогли организовать смещение и арест Пол Пота. К власти пришёл Временный Революционный Совет, которому ещё предстоит вытаскивать Камбоджу из хаоса, в который её вверг Пол Пот. Видя, что с Пол Потом покончено, армия активнее сопротивляется вьетнамцам, да и сам Вьетнам уже не настолько решителен, ведь основная цель похода оказалась выполнена. Вот только новое руководство Камбоджи по-прежнему лояльно Китаю.";
				GlobalScript.inst.gameState.data[9] -= 30;
				GlobalScript.inst.gameState.ingamewars[1].infl1 = 450;
				GlobalScript.inst.gameState.ingamewars[1].infl2 = 550;
				GlobalScript.inst.gameState.allcountries[23].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[23].SubGosstroy = 1;
				party_change[2] = 1f;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Мы направили помощь нашему старому союзнику Пол Поту, однако неизвестно, хватит ли ему этого. Вьетнамская армия успешно продвигается, а кампучийские солдаты активно дезертируют, да и народа режим Пол Пота поддержкой не пользуется. Вьетнам и СССР остались недовольны нашими действиями и скорее всего продолжат укреплять своё сотрудничество нам в ущерб.";
				GlobalScript.inst.gameState.data[22] -= 50;
				GlobalScript.inst.gameState.data[8] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GlobalScript.inst.gameState.ingamewars[1].infl1 = 400;
				GlobalScript.inst.gameState.ingamewars[1].infl2 = 600;
				party_change[0] = 1f;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 16)
		{
			text2 = "Выборы в Таиланде";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Предвыборная кампания 1976 года сопровождалась кровопролитными уличными столкновениями. Погибли около 30 человек. Демократическая партия Сени Прамота — несколько более правая по сравнению с Партией социального действия Кыкрита Прамота — получила наибольшее число голосов. Заместителем премьер-министра стал лидер правоконсервативной Национальной партии Праман Адирексан. Леворадикалы заметно утратили влияние.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 5;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Нам удалось оказать существенную поддержку КПТ и добиться союза с различными умеренно левыми активистами и некоторого потепления отношений с Партией социального действия и Демократической партией в обмен на прекращение партизанских налётов на военные базы. Предвыборная кампания 1976 года сопровождалась кровопролитными уличными столкновениями. В итоге наибольшее число голосов получила Партия социального действия премьера Кыкрита Прамота, которому пришлось формировать коалицию с Демократической партией и КПТ. Роялисты в правительстве и офицеры недовольны усилением левых, обстановка накаляется.";
				GlobalScript.inst.gameState.data[9] -= 20;
				GlobalScript.inst.gameState.data[8] -= 10;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 5;
				GlobalScript.inst.gameState.data[41] = 100;
				party_change[0] = 0.5f;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Проигнорировав выборы, мы направили ещё оружия партизанам из КПТ, которые продолжают с новыми силами совершать налёты на военные объекты. Впрочем, не похоже, что КПТ сумеет взять под контроль достаточную часть страны таким образом. Предвыборная кампания 1976 года сопровождалась кровопролитными уличными столкновениями. Погибли около 30 человек. Демократическая партия Сени Прамота — несколько более правая по сравнению с Партией социального действия Кыкрита Прамота — получила наибольшее число голосов. Заместителем премьер-министра стал лидер правоконсервативной Национальной партии Праман Адирексан.";
				GlobalScript.inst.gameState.data[22] -= 20;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				party_change[0] = 1f;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 17)
		{
			text2 = "Нестабильность в Таиланде";
			GlobalScript.inst.gameState.TaiCoup = true;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "6 октября полицейские силы вместе с правыми боевиками прорвались на территорию университета и, несмотря на готовность студентов сдаться, начали расправу. По разным данным количество погибших может достигать более 100 человек. Вечером того же дня ультраправые боевики вместе с военными силой заставили премьера Прамота уйти в отставку. Власть при поддержке короля вновь перешла к военной хунте, заканчивая трёхлетний период демократии. Таиланд вновь вступил в эпоху репрессий, а от КПТ остались только партизанские операции на севере страны.";
				GlobalScript.inst.gameState.allcountries[34].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[34].SubGosstroy = 7;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 5;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря нашей поддержке и усилиям спецслужб вооружённые боевики КПТ вышли к Таммасатскому университету и вместе со студентами завязали бой с правыми боевиками, исход которого решила лишь прибывшая на помощь правым полиция. Однако к этому времени уже по всему Бангкоку шли столкновения и демонстрации, на подавление которых были брошены армия и полиция. Премьер-министр Прамот был арестован военными. Эта жестокость и начавшийся хаос ввергли общество в шок и заставили многих студентов, профсоюзных активистов и рабочих пойти в ячейки КПТ, которая, воспользовавшись хаосом, начала полномасштабное наступление с севера страны.";
				GlobalScript.inst.gameState.data[9] -= 40;
				GlobalScript.inst.gameState.data[22] -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GlobalScript.inst.gameState.allcountries[34].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[34].SubGosstroy = 7;
				party_change[0] = 1f;
				GlobalScript.inst.gameState.ingamewars[2].name_war = "Тайская гражданская война";
				GlobalScript.inst.gameState.ingamewars[2].is_going = true;
				GlobalScript.inst.gameState.ingamewars[2].side1 = "Коммунисты";
				GlobalScript.inst.gameState.ingamewars[2].side2 = "Лоялисты";
				GlobalScript.inst.gameState.ingamewars[2].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[2].ussr_place = 0;
				GlobalScript.inst.gameState.ingamewars[2].infl1 = 300;
				GlobalScript.inst.gameState.ingamewars[2].infl2 = 700;
				if (GlobalScript.inst.gameState.allcountries[34].stab == 1)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[2];
					warinwars2.infl1 += 50;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[2];
					warinwars2.infl2 -= 50;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "6 октября полицейские силы вместе с правыми боевиками прорвались на территорию университета и, несмотря на готовность студентов сдаться, начали расправу. По разным данным количество погибших может достигать более 100 человек. Вечером того же дня ультраправые боевики вместе с военными силой заставили премьера Прамота уйти в отставку. Власть при поддержке короля вновь перешла к военной хунте, заканчивая трёхлетний период демократии. Таиланд вновь вступил в эпоху репрессий, а от КПТ остались только партизанские операции на севере страны. Мы официально осудили жестокости военной хунты и выслали дополнительную поддержку КПТ, однако это вряд ли что-то изменит.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 5;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.allcountries[34].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[34].SubGosstroy = 7;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 18)
		{
			text2 = "Война закончилась";
			text = "Ещё одна война закончилась.";
			GlobalScript.inst.gameState.data[0] = 0;
			GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].is_going = false;
			GlobalScript.inst.gameState.WarResult(ref text);
		}
		else if (GlobalScript.inst.gameState.number_event == 19)
		{
			text2 = "Пять \"нет\"";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Ходили слухи, что кампанию Пяти \"нет\" запустил сам Мао Цзэдун, но уверенности ни у кого не было: из-за тяжёлой болезни ног и общего здоровья до него почти не достучаться, а решать приходилось быстро. В рамках кампании государственные и полицейские служащие убирали самодельные мемориалы и срывали плакаты, отмечающие достижения Чжоу Эньлая. Постоянная пропаганда, направленная на очернение Чжоу, и запреты на открытое поминовение покойного вызвали в народе массовое недовольство Мао Цзэдуном и верхушкой партии, в особенности его женой Цзян Цин.";
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[88]++;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Ходили слухи, что кампанию Пяти \"нет\" запустил сам Мао Цзэдун, но уверенности ни у кого не было: из-за тяжёлой болезни ног и общего здоровья до него почти не достучаться, а решать приходилось быстро. Будучи Премьером Госсовета, а также министром общественной безопасности, вы лично следили за строгим исполнением кампании. В рамках кампании государственные и полицейские служащие убирали самодельные мемориалы и срывали плакаты, отмечающие достижения Чжоу Эньлая. Постоянная пропаганда, направленная на очернение Чжоу, и запреты на открытое поминовение покойного вызвали в народе массовое недовольство Мао Цзэдуном и верхушкой партии, в особенности его женой Цзян Цин и преемником Хуа Гофэном.";
				GlobalScript.inst.gameState.data[3] -= 70;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[6] += 10;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic113 in politics)
				{
					if (politic113.traits[0] == 0)
					{
						Politic politic = politic113;
						politic.loyality += 70;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Ходили слухи, что кампанию Пяти \"нет\" запустил сам Мао Цзэдун, но уверенности ни у кого не было: из-за тяжёлой болезни ног и общего здоровья до него почти не достучаться, а решать приходилось быстро. Будучи Премьером Госсовета, а также министром общественной безопасности, вы лично следили за строгим исполнением кампании и отвечали за публикации в газетах критики Чжоу Эньлая, которые однако не возымели эффекта на народ, уже уставший от критики в духе Культурной революции. В рамках кампании государственные и полицейские служащие убирали самодельные мемориалы и срывали плакаты, отмечающие достижения Чжоу Эньлая. Постоянная пропаганда, направленная на очернение Чжоу, и запреты на открытое поминовение покойного вызвали в народе массовое недовольство Мао Цзэдуном и верхушкой партии, в особенности его женой Цзян Цин и преемником Хуа Гофэном.";
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[6] += 10;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic114 in politics)
				{
					if (politic114.traits[0] == 0)
					{
						Politic politic = politic114;
						politic.loyality += 100;
					}
				}
				GlobalScript.inst.gameState.data[88]--;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Ходили слухи, что кампанию Пяти \"нет\" запустил сам Мао Цзэдун, но уверенности ни у кого не было: из-за тяжёлой болезни ног и общего здоровья до него почти не достучаться, а решать приходилось быстро. Будучи Премьером Госсовета, а также министром общественной безопасности, вы смогли, насколько это возможно, смягчить эффект кампании. В рамках кампании государственные и полицейские служащие убирали самодельные мемориалы и срывали плакаты, отмечающие достижения Чжоу Эньлая. Постоянная пропаганда, направленная на очернение Чжоу, и запреты на открытое поминовение покойного вызвали в народе недовольство верхушкой партии, в особенности Цзян Цин, однако, благодаря вашим усилиям по саботажу кампании, недовольство пока не выходит за разумные пределы.";
				GlobalScript.inst.gameState.data[3] -= 10;
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[88] += 2;
				Politic politic = GlobalScript.inst.gameState.politics[12];
				politic.loyality += 200;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic115 in politics)
				{
					if (politic115.traits[0] == 0)
					{
						politic = politic115;
						politic.loyality -= 70;
					}
					else if (politic115.traits[0] >= 1)
					{
						politic = politic115;
						politic.loyality += 50;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 20)
		{
			text2 = "Критикуй Дэна и борись с правыми!";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "В СМИ, подконтрольных группе Цзян Цин, началась активная травля Дэн Сяопина и его идей. Сяопина сняли со всех постов, оставив ему только партийный билет, и он проводит эти месяцы в фактическом затворе. Как и любая акция группы Цзян Цин, эта не вызвала никакого сочувствия в народе, где Сяопина уважают за связь с популярным Чжоу Эньлаем и за попытку вывести страну из провальных последствий Большого скачка через использование рыночных и даже капиталистических инструментов. К критике Сяопина присоединились также провинциальные партийные комитеты вскоре после того, как 3 марта Мао издаёт директиву, где подтверждает легитимность Культурной революции и отмечает, что Дэн Сяопин является внутренней проблемой страны.";
				GlobalScript.inst.gameState.data[3] -= 20;
				GlobalScript.inst.gameState.data[4] += 40;
				Politic politic = GlobalScript.inst.gameState.politics[12];
				politic.power -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В СМИ, подконтрольных группе Цзян Цин, началась активная травля Дэн Сяопина и его идей. К травле также присоединился и новый Премьер Хуа Гофэн, заявляя, что реформаторские идеи Дэна ведут Китай к капиталистическому рабству. Сяопина сняли со всех постов, но членство в партии сохранили, отправив его фактически в вынужденный затвор. Как и любая акция группы Цзян Цин, эта не вызвала сочувствия в народе, где Сяопина уважают за связь с популярным Чжоу Эньлаем и за попытку вывести страну из провальных последствий Большого скачка через использование рыночных и даже капиталистических инструментов. К критике Сяопина присоединились также провинциальные партийные комитеты вскоре после того, как 3 марта Мао издаёт директиву, где подтверждает легитимность Культурной революции и отмечает, что Дэн Сяопин является внутренней проблемой страны.";
				GlobalScript.inst.gameState.data[1] += 80;
				GlobalScript.inst.gameState.data[3] -= 20;
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.data[88]--;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic116 in politics)
				{
					if (politic116.traits[0] == 0)
					{
						politic = politic116;
						politic.loyality += 50;
					}
					else if (politic116.traits[0] == 2)
					{
						politic = politic116;
						politic.loyality -= 100;
					}
				}
				politic = GlobalScript.inst.gameState.politics[12];
				politic.power -= 130;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В СМИ, подконтрольных группе Цзян Цин, началась активная травля Дэн Сяопина и его идей. Вы, однако, заступились за него, утверждая, что Сяопин совершал ошибки, признал их, помог развитию КНР, и теперь его снимают со всех постов, оставляя только членство в партии. Это вызвало недовольство среди верхушки партии, но понравилось народу, где Сяопина уважают за связь с популярным Чжоу Эньлаем и за попытку вывести страну из провальных последствий Большого скачка через использование рыночных и даже капиталистических инструментов. Впрочем, выступления в поддержку Сяопина вам пришлось прекратить после того, как 3 марта Мао издал директиву, где подтвердил легитимность Культурной революции и отметил, что Дэн Сяопин является внутренней проблемой страны, после чего к критике Сяопина присоединились также провинциальные партийные комитеты.";
				GlobalScript.inst.gameState.data[3] += 20;
				GlobalScript.inst.gameState.data[1] -= 70;
				GlobalScript.inst.gameState.data[4] += 50;
				Politic politic = GlobalScript.inst.gameState.politics[12];
				politic.loyality += 200;
				GlobalScript.inst.gameState.data[88]++;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic117 in politics)
				{
					if (politic117.traits[0] == 0)
					{
						politic = politic117;
						politic.loyality -= 100;
					}
					else if (politic117.traits[0] == 3)
					{
						politic = politic117;
						politic.loyality += 50;
					}
					else if (politic117.traits[0] > 0)
					{
						politic = politic117;
						politic.loyality += 100;
					}
				}
				politic = GlobalScript.inst.gameState.politics[12];
				politic.power -= 80;
				politic = GlobalScript.inst.gameState.politics[12];
				politic.loyality += 250;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 21)
		{
			text2 = "Таинственная статья и старые тени";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Неясно, против кого направлена статья: одни уверяют, что против Чжоу Эньлая, другие говорят, что бьют по Чжоу Жунсиню, а рассказы об «оскорблении Эньлая» раздул каппутистский лагерь Сяопина, чтобы разогреть массы. Мы решили не лезть под горячую руку: тихо отсидеться, пока неясно, кого завтра назначат виновным. Но слухи уже полетели, протесты вспыхнули в городах долины Янцзы, особенно в Нанкине, и докатились до Пекина.";
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[4] += 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Точная цель статьи так и не прояснилась: одни видят выпад против Чжоу Эньлая, другие уверяют, что речь о Чжоу Жунсине, а версию про Эньлая каппутисты Сяопина раздули, чтобы воспламенить народ. Мы жёстко изъяли текст и пресекли любые спекуляции, чтобы не будоражить массы. Распространение замедлилось; протесты вспыхнули, но без угрожающего размаха.";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[3] -= 30;
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.data[88] += 2;
				Politic politic = GlobalScript.inst.gameState.politics[12];
				politic.loyality += 200;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic118 in politics)
				{
					if (politic118.traits[0] == 0)
					{
						politic = politic118;
						politic.loyality -= 70;
					}
					else if (politic118.traits[0] > 0 && politic118.traits[0] < 3)
					{
						politic = politic118;
						politic.loyality += 50;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "При том что одни уверяли: статья бьёт по Чжоу Эньлаю, другие — что по Чжоу Жунсине, вы обернули её против каппутистских реформ и растиражировали за пределы Шанхая. Партии такой поворот понравился, народу — нет. Протесты, подпитанные конкурирующими слухами, разрослись по городам долины Янцзы, прежде всего в Нанкине, и благодаря нашей активной публикации докатились и до Пекина. Пока ситуацию удаётся держать под контролем.";
				GlobalScript.inst.gameState.data[3] -= 80;
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[88]--;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic119 in politics)
				{
					if (politic119.traits[0] == 0)
					{
						Politic politic = politic119;
						politic.loyality += 100;
					}
					else if (politic119.traits[0] > 0 && politic119.traits[0] < 3)
					{
						Politic politic = politic119;
						politic.loyality -= 70;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 22)
		{
			text2 = "Тяньаньмэньский инцидент";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "По линии Цзян Цин и Чжан Чуньцяо мы сначала обратились к людям по радио, стараясь отделить скорбящих от провокаторов, а затем ввели на площадь городскую полицию и войска Пекинского гарнизона. Были стычки и избиения, но погибших нет; задержали около сотни человек, большинство вскоре отпустили. События на Тяньаньмэнь официально объявлены контрреволюционным инцидентом, ответственность возложена на Дэн Сяопина. По предложению Мао Цзэдуна Политбюро формально отстранило Дэн Сяопина со всех постов, сохранив за ним партийный билет. Сам Дэн сейчас в Гуанчжоу под защитой своего давнего соратника, командующего Гуанчжоуским военным округом Сюй Шию.";
				GlobalScript.inst.gameState.data[3] -= 250;
				GlobalScript.inst.gameState.data[4] -= 200;
				GlobalScript.inst.gameState.data[6] += 60;
				GlobalScript.inst.gameState.data[1] += 100;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic120 in politics)
				{
					if (politic120.traits[0] == 0)
					{
						politic = politic120;
						politic.loyality += 100;
					}
					else if (politic120.traits[0] > 0)
					{
						politic = politic120;
						politic.loyality -= 100;
					}
				}
				politic = GlobalScript.inst.gameState.politics[12];
				politic.power -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В половине седьмого вечера У Дэ через громкоговорители попросил толпу разойтись. Многие ушли, часть осталась. Ночью на площадь зашли полиция и войска Пекинского гарнизона и очистили её. Погибших нет; задержали около сотни человек, большинство позже отпустили. В последующие дни площадь оставалась под военно-полицейским контролем. События на Тяньаньмэнь официально объявлены контрреволюционным инцидентом, ответственность возложена на Дэн Сяопина. По предложению Мао Цзэдуна Политбюро отстранило Дэн Сяопина со всех постов, сохранив за ним партийный билет. Сам Дэн находится в Гуанчжоу под защитой своего давнего соратника, командующего Гуанчжоуским военным округом Сюй Шию.";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[4] -= 150;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic121 in politics)
				{
					if (politic121.traits[0] == 0)
					{
						politic = politic121;
						politic.loyality += 50;
					}
				}
				politic = GlobalScript.inst.gameState.politics[12];
				politic.power -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В половине седьмого вечера У Дэ через громкоговорители обратился к толпе с призывом разойтись. Многие ушли, часть осталась. Ночью городская полиция и войска Пекинского гарнизона оцепили оставшихся и разогнали их. Погибших нет; задержали около сотни человек, большинство позже отпустили. Протест удалось подавить с минимальным применением силы. События на Тяньаньмэнь официально объявлены контрреволюционным инцидентом, ответственность возложена на Дэн Сяопина. По предложению Мао Цзэдуна Политбюро отстранило Дэн Сяопина со всех постов, однако сохранило за ним членство в КПК. Сам Дэн Сяопин находится в Гуанчжоу под защитой своего старого соратника, командующего Гуанчжоуским военным округом Сюй Шию.";
				GlobalScript.inst.gameState.data[4] -= 100;
				GlobalScript.inst.gameState.data[1] -= 50;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic122 in politics)
				{
					if (politic122.traits[0] == 0)
					{
						politic = politic122;
						politic.loyality += 50;
					}
				}
				politic = GlobalScript.inst.gameState.politics[12];
				politic.power -= 100;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 23)
		{
			text2 = "Таншаньское землетрясение";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Из бюджета КНР были срочно выделены средства на проведение спасательных и восстановительных работ, что позволило смягчить последствия землетрясения. Землетрясение в Таншане на сегодняшний момент оказалось вторым в истории по количеству жертв после землетрясения в Шэньси в 1556 году.";
				GlobalScript.inst.gameState.data[3] += 30;
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[8] -= 30;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мировое сообщество и благотворительные организации, оценив масштабы катастрофы согласилось выделить нам помощь в виде безвозмездных кредитов и помощи волонтёров, что позволило смягчить последствия землетрясения. Землетрясение в Таншане на сегодняшний момент оказалось вторым в истории по количеству жертв после землетрясения в Шэньси в 1556 году.";
				GlobalScript.inst.gameState.data[1] -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 5;
				GlobalScript.inst.gameState.data[4] += 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Из бюджета КНР были срочно выделены средства на проведение спасательных и восстановительных работ, что позволило смягчить последствия землетрясения. Землетрясение в Таншане на сегодняшний момент оказалось вторым в истории по количеству жертв после землетрясения в Шэньси в 1556 году. Также было выделено дополнительное финансирование для строительства сейсмоустойчивых зданий в опасных регионах и проведены многочисленные проверки на пригодность нынешних зданий, выявившие многочисленные нарушения. Надеемся, в будущем это поможет избежать столь больших жертв. ";
				GlobalScript.inst.gameState.data[5] += 50;
				GlobalScript.inst.gameState.data[3] += 30;
				GlobalScript.inst.gameState.data[1] += 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 5;
				GlobalScript.inst.gameState.data[8] -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Центр остался глух к проблемам провинции Хэбэй, что конечно затруднило ликвидацию последствий землетрясения и породило недовольство в народе, но кое-как местная администрация справляется. Землетрясение в Таншане на сегодняшний момент оказалось вторым в истории по количеству жертв после землетрясения в Шэньси в 1556 году.";
				GlobalScript.inst.gameState.data[5] -= 50;
				GlobalScript.inst.gameState.data[3] -= 40;
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[4] += 30;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 24)
		{
			text2 = "Ветер перемен?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Вы вместе с Ван Дунсином сформулировали лозунг \"Двух абсолютов\" — \"Абсолютно все решения, вынесенные Председателем Мао Цзэдуном, мы должны стойко защищать, абсолютно все указания, данные Председателем Мао Цзэдуном, мы должны неизменно соблюдать\" — чтобы легитимизировать новую власть. Теперь вы подаете его скорее как личный кодекс чести, а не жесткую линию, одновременно гася последние очаги давно затухающей Культурной революции, что радует народ. Однако приверженность консервативному маоизму всё же вызывает недовольство и у части общества, и за рубежом, и в реформаторских кругах КПК.";
				GlobalScript.inst.gameState.data[3] += 20;
				GlobalScript.inst.gameState.data[4] += 100;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GlobalScript.inst.gameState.modifies[3].active = false;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic123 in politics)
				{
					if (politic123.traits[0] == 0)
					{
						Politic politic = politic123;
						politic.loyality += 100;
					}
					else if (politic123.traits[0] == 2)
					{
						Politic politic = politic123;
						politic.loyality -= 100;
					}
					else if (politic123.traits[0] == 1)
					{
						Politic politic = politic123;
						politic.loyality += 50;
					}
				}
				party_change[0] = 3f;
				party_change[1] = 5f;
				GlobalScript.inst.gameState.data[87] = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Опираясь на лояльных радикалов, вы и Ван Дунсин возвели придуманную вами формулу \"Двух абсолютов\" — \"Абсолютно все решения, вынесенные Председателем Мао Цзэдуном, мы должны стойко защищать, абсолютно все указания, данные Председателем Мао Цзэдуном, мы должны неизменно соблюдать\" — в обязательную генеральную линию, подкрепляя свой мандат. Вы объявили бескомпромиссную борьбу с ревизионизмом и верность Мао и Культурной революции, пытаясь вновь разжечь её пламя с оглядкой на прежние ошибки. По стране прокатилась волна репрессий против ревизионистов и волна протестов тех, кого новый виток Культурной революции возмутил.";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[6] += 100;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic124 in politics)
				{
					if (politic124.traits[0] == 0)
					{
						Politic politic = politic124;
						politic.loyality += 100;
					}
					else if (politic124.traits[0] > 0)
					{
						Politic politic = politic124;
						politic.loyality -= 200;
						politic = politic124;
						politic.power -= 100;
					}
				}
				party_change[0] = 8f;
				party_change[1] = 3f;
				GlobalScript.inst.gameState.data[87] = 2;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Вы с Ван Дунсином напомнили кадрам, что именно вами сформулированы \"Два абсолюта\", используем их как кодекс чести, а не жесткую линию, и объявили задачи Культурной революции выполненными, приступив к ликвидации её последних очагов. Одновременно вы подчеркнули необходимость реорганизации и модернизации экономики, не раскрывая деталей. Реформаторы затаились в ожидании, народ ждёт перемен к лучшему.";
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[4] += 80;
				GlobalScript.inst.gameState.modifies[3].active = false;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic125 in politics)
				{
					if (politic125.traits[0] == 0)
					{
						Politic politic = politic125;
						politic.loyality -= 20;
					}
					else if (politic125.traits[0] < 3)
					{
						Politic politic = politic125;
						politic.loyality += 100;
					}
				}
				party_change[2] = 8f;
				party_change[3] = 3f;
				GlobalScript.inst.gameState.data[87] = 3;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Вы и Ван Дунсин подчеркнули, что придуманные вами \"Два абсолюта\" остаются строгой обязательной линией, укрепляющей ваш мандат, и одновременно объявили о скорейшем сворачивании остатков Культурной революции. Параллельно вы заговорили о дальнейших рыночных реформах и постепенном выходе на мировой рынок, начали продвигать старых реформаторов, таких как Чжао Цзыян, и вернули из опалы Дэн Сяопина на пост вице-премьера. Народ ждёт перемен к лучшему, но консервативная часть партии недовольна.";
				GlobalScript.inst.gameState.data[3] += 80;
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.modifies[3].active = false;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic126 in politics)
				{
					if (politic126.traits[0] == 0)
					{
						Politic politic = politic126;
						politic.loyality -= 100;
					}
					else if (politic126.traits[0] > 1)
					{
						Politic politic = politic126;
						politic.loyality += 100;
					}
				}
				party_change[2] = 3f;
				party_change[3] = 8f;
				party_change[4] = 3f;
				GlobalScript.inst.gameState.data[87] = 4;
				if (GlobalScript.inst.gameState.modifies[59].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.modifies[60].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.modifies[61].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = false;
					GlobalScript.inst.gameState.modifies[62].active = true;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 25)
		{
			text2 = "Банда четырех";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Заручившись поддержкой Отряда 8341, а также высшего генералитета, Хуа Гофэн созвал Чрезвычайный съезд Политбюро, прямо на котором и произошел арест лидеров радикальной фракции. Вслед за этим волна арестов лояльных четверке функционеров прокатилась по Пекину и Шанхаю, практически не вызвав никакого сопротивления. В прессе развернулась масштабная кампания по осуждению заговорщиков, которых уже окрестили «Бандой Четырех», на которую теперь возлагали вину за многочисленных жертв Культурной Революции, а также попытке захвата власти после смерти Мао. Народ, как и большая часть партийцев, в целом с облегчением восприняли разгром радикалов и понемногу выражают надежду на смягчение внутренней политики.";
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[1] += 100;
				GlobalScript.inst.gameState.data[6] -= 30;
				GlobalScript.inst.gameState.data[84] = 1;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic127 in politics)
				{
					if (politic127.traits[0] == 0)
					{
						politic = politic127;
						politic.loyality -= 50;
					}
					else if (politic127.traits[0] == 2)
					{
						politic = politic127;
						politic.loyality += 50;
					}
					else if (politic127.traits[0] == 1)
					{
						politic = politic127;
						politic.loyality += 50;
					}
				}
				party_change[1] = 2.5f;
				party_change[2] = 1.5f;
				party_change[3] = 1.5f;
				GlobalScript.inst.gameState.KillPerson(0);
				GlobalScript.inst.gameState.KillPerson(1);
				GlobalScript.inst.gameState.KillPerson(2);
				GlobalScript.inst.gameState.KillPerson(3);
				GlobalScript.inst.gameState.KillPerson(4);
				GlobalScript.inst.gameState.KillPerson(17);
				politic = GlobalScript.inst.gameState.politics[6];
				politic.power += 100;
				politic = GlobalScript.inst.gameState.politics[7];
				politic.power += 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Не желая рисковать, Хуа Гофэн решил арестовать лишь Ван Хунвэня и Цзян Цин, которые представляли наибольшую угрозу для власти. Это и произошло на специально созванном заседании Политбюро. Вместе с тем Яо Вэньюаню и Чжан Чуньцяо были предложены места в правительстве в обмен на лояльность нынешнему правителю. Позиции левой фракции оказались подорваны, но не настолько значительно, чтобы полностью сбрасывать их со счетов, хотя о захвате власти им теперь можно не мечтать. Против Цзян Цин и Ван Хунвэня началась активная кампания в прессе, которых теперь обвиняли в попытке захвата власти и перегибах во времена Культурной Революции. В целом народ и большая часть партийцев приняла их падение с облегчением, хотя многих и напрягает то, что некоторые радикалы остались у власти и считают заговорщиков лишь «козлами отпущения».";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[84] = 2;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic128 in politics)
				{
					if (politic128.traits[0] == 0)
					{
						politic = politic128;
						politic.loyality -= 20;
					}
					else if (politic128.traits[0] == 2)
					{
						politic = politic128;
						politic.loyality += 50;
					}
					else if (politic128.traits[0] == 1)
					{
						politic = politic128;
						politic.loyality += 70;
					}
				}
				party_change[1] = 2f;
				party_change[2] = 1f;
				party_change[3] = 1f;
				GlobalScript.inst.gameState.KillPerson(1);
				GlobalScript.inst.gameState.KillPerson(2);
				politic = GlobalScript.inst.gameState.politics[6];
				politic.power += 100;
				politic = GlobalScript.inst.gameState.politics[7];
				politic.power += 100;
				if (GlobalScript.inst.gameState.politics_dolshnost[2] < 50)
				{
					politic = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[2]];
					politic.loyality -= 200;
				}
				GlobalScript.inst.gameState.politics_dolshnost[2] = 3;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Рост влияния реформаторов на волне смерти Мао напугал не только Гофэна, но и группу Ван — Чжан — Цзян — Яо, поэтому новый Председатель КНР решил объединить усилия с ними. Переговоры шли при посредничестве Мао Юаньсиня (племянника Мао Цзэдуна) и достаточно долго. Однако нам удалось достичь соглашения - в обмен на поддержку, группа Ван — Чжан — Цзян — Яо потребовала: снятия с поста министра обороны КНР маршала Е Цзяньина, передачу ей постов председателя Военного совета ЦК КПК и Министра иностранных дел КНР. Товарищ Гофэн согласился с этими условиями. Военный совет ЦК КПК возглавил Ван Хунвэнь, министром иностранных дел стал Яо Вэньюань, а министром обороны - командующий Пекинским военным округом НОАК генерал Чэнь Силянь. На заседании Политбюро ЦК КПК был вновь атакован Дэн Сяопин, в обращение вернулся лозунг \"Критикуем Дэна и выступаем против течения правого уклона, направленного на пересмотр правильных решений\". Влияние Сяопина вновь пошло на убыль, особенно благодаря уходу его \"ангела-хранителя\" Цзяньина с командных постов в НОАК... Народ и большая часть партии, впрочем, недовольны таким странным альянсом, предвещающим продолжение Культурной революции.";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[4] += 250;
				GlobalScript.inst.gameState.data[84] = 3;
				GlobalScript.inst.gameState.data[6] += 50;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic129 in politics)
				{
					if (politic129 != null)
					{
						if (politic129.traits[0] == 0)
						{
							politic = politic129;
							politic.loyality += 200;
						}
						else if (politic129.traits[0] < 3)
						{
							politic = politic129;
							politic.loyality -= 100;
						}
					}
				}
				party_change[0] = 2.5f;
				party_change[1] = 1.5f;
				GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.1f);
				politic = GlobalScript.inst.gameState.politics[7];
				politic.power -= 100;
				politic = GlobalScript.inst.gameState.politics[12];
				politic.power -= 100;
				politic = GlobalScript.inst.gameState.politics[9];
				politic.power += 100;
				if (GlobalScript.inst.gameState.politics_dolshnost[2] < 50)
				{
					politic = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[2]];
					politic.loyality -= 200;
				}
				GlobalScript.inst.gameState.politics_dolshnost[2] = 4;
				if (GlobalScript.inst.gameState.politics_dolshnost[1] < 50)
				{
					politic = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[1]];
					politic.loyality -= 200;
				}
				GlobalScript.inst.gameState.politics_dolshnost[1] = 150;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Что ж...";
				GlobalScript.inst.gameState.data[35] = 2;
				load_scene_after_click = "Ending";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 26)
		{
			text2 = "Непрочный альянс";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Заручившись поддержкой Отряда 8341, а также высшего генералитета, Хуа Гофэн созвал Чрезвычайный съезд Политбюро, прямо на котором и произошел арест лидеров радикальной фракции. Вслед за этим волна арестов лояльных четверке функционеров прокатилась по Пекину и Шанхаю, хотя не обошлось и без некоторых эксцессов, учитывая возросшее влияние радикалов. В прессе развернулась масштабная кампания по осуждению заговорщиков, которых уже окрестили «Бандой Четырех», на которую теперь возлагали вину за многочисленных жертв Культурной Революции, а также попытке захвата власти после смерти Мао. Народ, как и большая часть партийцев, в целом с облегчением восприняли разгром радикалов, хотя учитывая прошлый альянс ними, эти действия не сильно прибавили Гофэну популярности";
				GlobalScript.inst.gameState.data[3] += 40;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[6] -= 30;
				GlobalScript.inst.gameState.data[9] -= 70;
				GlobalScript.inst.gameState.data[84] = 1;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic130 in politics)
				{
					if (politic130.traits[0] == 0)
					{
						politic = politic130;
						politic.loyality -= 100;
					}
					else if (politic130.traits[0] == 2)
					{
						politic = politic130;
						politic.loyality += 50;
					}
					else if (politic130.traits[0] == 1)
					{
						politic = politic130;
						politic.loyality += 50;
					}
				}
				party_change[1] = 2.5f;
				party_change[2] = 1.5f;
				party_change[3] = 1.5f;
				GlobalScript.inst.gameState.KillPerson(1);
				GlobalScript.inst.gameState.KillPerson(2);
				GlobalScript.inst.gameState.KillPerson(3);
				GlobalScript.inst.gameState.KillPerson(4);
				politic = GlobalScript.inst.gameState.politics[6];
				politic.power += 100;
				politic = GlobalScript.inst.gameState.politics[5];
				politic.power += 400;
				politic = GlobalScript.inst.gameState.politics[7];
				politic.power += 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Не желая рисковать, Хуа Гофэн решил арестовать лишь Ван Хунвэня и Цзян Цин, которые представляли наибольшую угрозу для власти. Это и произошло на специально созванном заседании Политбюро. Вместе с тем Яо Вэньюаню и Чжан Чуньцяо было предложено дальнейшее продвижение наверх в обмен на лояльность нынешнему правителю. Позиции левой фракции оказались подорваны, но не настолько значительно, чтобы полностью сбрасывать их со счетов, хотя о захвате власти им теперь можно не мечтать. Против Цзян Цин и Ван Хунвэня началась активная кампания в прессе, которых теперь обвиняли в попытке захвата власти и перегибах во времена Культурной Революции. В целом народ и большая часть партийцев приняла их падение с облегчением, хотя многих и напрягает то, что некоторые радикалы остались у власти и считают заговорщиков лишь «козлами отпущения», тем более, что Гофэн и до этого шел им на уступки, поэтому такое решение не сильно прибавит ему популярности. ";
				GlobalScript.inst.gameState.data[1] += 20;
				GlobalScript.inst.gameState.data[3] += 20;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[84] = 2;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic131 in politics)
				{
					if (politic131.traits[0] == 0)
					{
						politic = politic131;
						politic.loyality -= 50;
					}
					else if (politic131.traits[0] == 2)
					{
						politic = politic131;
						politic.loyality += 50;
					}
					else if (politic131.traits[0] == 1)
					{
						politic = politic131;
						politic.loyality += 50;
					}
				}
				party_change[1] = 2f;
				party_change[2] = 1f;
				party_change[3] = 1f;
				GlobalScript.inst.gameState.KillPerson(1);
				GlobalScript.inst.gameState.KillPerson(2);
				politic = GlobalScript.inst.gameState.politics[3];
				politic.power += 100;
				politic = GlobalScript.inst.gameState.politics[4];
				politic.power += 100;
				if (GlobalScript.inst.gameState.politics_dolshnost[2] < 100)
				{
					politic = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.politics_dolshnost[2]];
					politic.loyality -= 200;
				}
				GlobalScript.inst.gameState.politics_dolshnost[2] = 3;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Опасаясь идти на открытый конфликт с все более усиливающимися радикалами, Гофэн пошел на очередные уступки, по сути развязав им руки для борьбы с оппозицией, чем они активно пользуются, в том числе и для отстранения Гофэна от власти, которую он теряет с каждым днём. Такими темпами новым фактическим главой государства становится Ван Хунвэнь, опирающийся на своих соратников. Впрочем они ещё помнят, кому обязаны своим триумфом, так что Гофэн может пока не опасаться преследований, однако закат его карьеры - лишь вопрос времени. Все эти перестановки вызвали страх и недовольство в партии и народе, которые теперь ожидают нового витка Культурной революции.";
				GlobalScript.inst.gameState.data[1] -= 200;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[6] += 100;
				int[] array18 = new int[16]
				{
					GlobalScript.inst.gameState.leader.name_1,
					GlobalScript.inst.gameState.leader.name_2,
					GlobalScript.inst.gameState.leader.traits[0],
					GlobalScript.inst.gameState.leader.traits[1],
					GlobalScript.inst.gameState.leader.traits[2],
					GlobalScript.inst.gameState.leader.age,
					GlobalScript.inst.gameState.leader.face_type,
					GlobalScript.inst.gameState.leader.face_parts[0],
					GlobalScript.inst.gameState.leader.face_parts[1],
					GlobalScript.inst.gameState.leader.face_parts[2],
					GlobalScript.inst.gameState.leader.face_parts[3],
					GlobalScript.inst.gameState.leader.face_parts[4],
					GlobalScript.inst.gameState.leader.face_parts[5],
					GlobalScript.inst.gameState.leader.face_parts[6],
					GlobalScript.inst.gameState.leader.face_parts[7],
					GlobalScript.inst.gameState.leader.jacket
				};
				GlobalScript.inst.gameState.leader.name_1 = GlobalScript.inst.gameState.politics[2].name_1;
				GlobalScript.inst.gameState.leader.name_2 = GlobalScript.inst.gameState.politics[2].name_2;
				GlobalScript.inst.gameState.leader.traits[0] = GlobalScript.inst.gameState.politics[2].traits[0];
				GlobalScript.inst.gameState.leader.traits[1] = GlobalScript.inst.gameState.politics[2].traits[1];
				GlobalScript.inst.gameState.leader.traits[2] = GlobalScript.inst.gameState.politics[2].traits[2];
				GlobalScript.inst.gameState.leader.age = GlobalScript.inst.gameState.politics[2].age;
				GlobalScript.inst.gameState.leader.face_type = GlobalScript.inst.gameState.politics[2].face_type;
				GlobalScript.inst.gameState.leader.face_parts[0] = GlobalScript.inst.gameState.politics[2].face_parts[0];
				GlobalScript.inst.gameState.leader.face_parts[1] = GlobalScript.inst.gameState.politics[2].face_parts[1];
				GlobalScript.inst.gameState.leader.face_parts[2] = GlobalScript.inst.gameState.politics[2].face_parts[2];
				GlobalScript.inst.gameState.leader.face_parts[3] = GlobalScript.inst.gameState.politics[2].face_parts[3];
				GlobalScript.inst.gameState.leader.face_parts[4] = GlobalScript.inst.gameState.politics[2].face_parts[4];
				GlobalScript.inst.gameState.leader.face_parts[5] = GlobalScript.inst.gameState.politics[2].face_parts[5];
				GlobalScript.inst.gameState.leader.face_parts[6] = GlobalScript.inst.gameState.politics[2].face_parts[6];
				GlobalScript.inst.gameState.leader.face_parts[7] = GlobalScript.inst.gameState.politics[2].face_parts[7];
				GlobalScript.inst.gameState.leader.jacket = GlobalScript.inst.gameState.politics[2].jacket;
				GlobalScript.inst.gameState.politics[2].name_1 = (byte)array18[0];
				GlobalScript.inst.gameState.politics[2].name_2 = (byte)array18[1];
				GlobalScript.inst.gameState.politics[2].traits[0] = (byte)array18[2];
				GlobalScript.inst.gameState.politics[2].traits[1] = (byte)array18[3];
				GlobalScript.inst.gameState.politics[2].traits[2] = (byte)array18[4];
				GlobalScript.inst.gameState.politics[2].age = (byte)array18[5];
				GlobalScript.inst.gameState.politics[2].face_type = (byte)array18[6];
				GlobalScript.inst.gameState.politics[2].face_parts[0] = (byte)array18[7];
				GlobalScript.inst.gameState.politics[2].face_parts[1] = (byte)array18[8];
				GlobalScript.inst.gameState.politics[2].face_parts[2] = (byte)array18[9];
				GlobalScript.inst.gameState.politics[2].face_parts[3] = (byte)array18[10];
				GlobalScript.inst.gameState.politics[2].face_parts[4] = (byte)array18[11];
				GlobalScript.inst.gameState.politics[2].face_parts[5] = (byte)array18[12];
				GlobalScript.inst.gameState.politics[2].face_parts[6] = (byte)array18[13];
				GlobalScript.inst.gameState.politics[2].face_parts[7] = (byte)array18[14];
				GlobalScript.inst.gameState.politics[2].jacket = (byte)array18[15];
				GlobalScript.inst.gameState.faction_leader[0] = 1;
				GlobalScript.inst.gameState.faction_leader[1] = 2;
				int[] array19 = new int[8];
				for (int num74 = 0; num74 < GlobalScript.inst.gameState.politics_dolshnost.Length; num74++)
				{
					if (GlobalScript.inst.gameState.politics_dolshnost[num74] == 150)
					{
						GlobalScript.inst.gameState.politics_dolshnost[num74] = 2;
					}
					else if (GlobalScript.inst.gameState.politics_dolshnost[num74] == 2)
					{
						array19[num74] = 150;
					}
				}
				for (int num75 = 0; num75 < array19.Length; num75++)
				{
					if (array19[num75] == 150)
					{
						GlobalScript.inst.gameState.politics_dolshnost[num75] = 150;
					}
				}
				for (int num76 = 0; num76 < GlobalScript.inst.gameState.politics.Length; num76++)
				{
					GlobalScript.inst.gameState.CalcRel(num76);
					GlobalScript.inst.gameState.CalcRel2(num76);
					GlobalScript.inst.gameState.CalcRelLeader(num76);
				}
				Politic politic = GlobalScript.inst.gameState.politics[1];
				politic.power += 500;
				politic = GlobalScript.inst.gameState.politics[3];
				politic.power += 500;
				politic = GlobalScript.inst.gameState.politics[4];
				politic.power += 500;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic132 in politics)
				{
					if (politic132.traits[0] == 0)
					{
						politic = politic132;
						politic.loyality += 200;
						politic = politic132;
						politic.power += 100;
					}
					else if (politic132.traits[0] == 2)
					{
						politic = politic132;
						politic.loyality -= 100;
						politic = politic132;
						politic.power -= 100;
					}
					else if (politic132.traits[0] == 1)
					{
						politic = politic132;
						politic.loyality -= 100;
					}
				}
				party_change[0] = 2.5f;
				party_change[1] = 1f;
				GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.15f);
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 27)
		{
			text2 = "Судьба Гонконга и Макао";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "После долгих переговоров вы наконец подписали с представителями Британии и Португалии соглашения, согласно которым Гонконг будет передан Китаю в 1997 году одновременно с окончанием срока аренды Новых Территорий, а Макао - в 1999 году. Обе бывшие колонии получат широкую автономию, сохранив за собой контроль над правовой и экономической сферами, в то время как центральное правительство КНР будет заниматься лишь вопросами обороны и внешней политики. Разумеется, это приведёт к концентрации власти в руках местных деловых элит, но это не так важно, ведь долгожданное воссоединение с нашими братьями состоится совсем скоро!";
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[1] += 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[65] = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if ((GlobalScript.inst.gameState.data[6] <= 600 || GlobalScript.inst.gameState.influencePRC >= 150) && GlobalScript.inst.gameState.empires[0].relations >= 800)
				{
					text = "После долгих переговоров вы наконец подписали с представителями Британии и Португалии соглашения, согласно которым Гонконг будет передан Китаю в 1997 году одновременно с окончанием срока аренды Новых Территорий, а Макао - в 1999 году. Обе бывшие колонии получат ограниченную автономию, сохранив контроль над экономической и, частично, правовой сферой. Полномочия управления будут разделены между местной выборной администрацией и курирующими органами КПК. Это наша дипломатическая победа!";
					GlobalScript.inst.gameState.data[3] += 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 50;
					GlobalScript.inst.gameState.data[1] += 100;
					GlobalScript.inst.gameState.data[65] = 1;
				}
				else
				{
					text = "После долгих переговоров британцы и португальцы отказались от наших условий, назвав их неприемлемыми, что вызвало большое разочарование в партии и народе. Кажется, вопрос о передаче колоний откладывается на неопределённый срок. Хотя бы Новые Территории Британия по-прежнему готова вернуть в 1997 году на таких условиях.";
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[4] += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 30;
					GlobalScript.inst.gameState.data[1] -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				if ((GlobalScript.inst.gameState.data[6] <= 500 || GlobalScript.inst.gameState.influencePRC >= 250) && GlobalScript.inst.gameState.empires[0].relations >= 800)
				{
					text = "После долгих переговоров вы наконец подписали с представителями Британии и Португалии соглашения, согласно которым Гонконг будет передан Китаю в 1997 году одновременно с окончанием срока аренды Новых Территорий, а Макао - в 1999 году. Обе бывшие колонии полностью перейдут под управление КНР, сохранив лишь некоторые элементы местного самоуправления. Частная собственность иностранных граждан продолжит работу в рамках созданных Специальных экономических зон, а административные учреждения будут выкуплены Китаем у Британии и Португалии к моменту передачи колоний. Народ и партия празднуют нашу огромную дипломатическую победу!";
					GlobalScript.inst.gameState.data[3] += 120;
					GlobalScript.inst.gameState.data[1] += 200;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 100;
					GlobalScript.inst.gameState.data[65] = 2;
				}
				else
				{
					text = "После долгих переговоров британцы и португальцы отказались от наших условий, назвав их неприемлемыми, что вызвало большое разочарование в партии и народе. Кажется, вопрос о передаче колоний откладывается на неопределённый срок. Хотя бы Новые Территории Британия по-прежнему готова вернуть в 1997 году на таких условиях.";
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[4] += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 30;
					GlobalScript.inst.gameState.data[1] -= 100;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 28)
		{
			text2 = "Конец азиатского Пиночета";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Будучи не в силах справиться с протестами, Сухарто ушёл в отставку, передав правление вице-президенту, который пошёл на либерализацию режима и проведение свободных выборов и положил начало более независимой внешней политике.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 20;
				GlobalScript.inst.gameState.allcountries[50].Vyshi = false;
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					GlobalScript.inst.gameState.allcountries[50].isASEAN = false;
				}
				GlobalScript.inst.gameState.allcountries[50].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[50].SubGosstroy = 6;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Будучи не в силах справиться с протестами, Сухарто ушёл в отставку. Несмотря на все усилия правящей верхушки, в ходе протестов при нашей поддержке сформировалась умеренно-левая партия, придерживающаяся курса первого президента Сукарно, которая и победила на последующих выборах. Начинается перестройка экономики с внедрением в неё элементов социалистического управления, а также трибунал над причастными к тирании Сухарто.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 40;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.allcountries[50].Vyshi = false;
				if (!GlobalScript.inst.gameState.allcountries[1].isASEAN)
				{
					GlobalScript.inst.gameState.allcountries[50].isASEAN = false;
				}
				GlobalScript.inst.gameState.allcountries[50].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[50].SubGosstroy = 3;
				GlobalScript.inst.gameState.allcountries[50].Torg = true;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic133 in politics)
				{
					if (politic133.traits[0] <= 2)
					{
						Politic politic = politic133;
						politic.loyality += 70;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Будучи не в силах справиться с протестами, Сухарто ушёл в отставку. Благодаря нашей поддержке в Индонезии после почти полного уничтожения в 60-е вновь сформировалась коммунистическая партия, которая смогла неплохо пополнить свои ряды за счёт протестующих и сумела провести множество партизанских атак на правительственные объекты. Всё это вместе с нашим давлением вынудило индонезийское правительство допустить коммунистическую партию до выборов на которых она, при нашем активном вмешательстве победила, сформировав коалицию с демократами. Для Индонезии началась новая эпоха.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 40;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.allcountries[50].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[50].LeaveAlliances();
				GlobalScript.inst.gameState.allcountries[50].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[50].SubGosstroy = 1;
				GlobalScript.inst.gameState.allcountries[50].Torg = true;
				GlobalScript.inst.gameState.allcountries[50].proprc = true;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic134 in politics)
				{
					if (politic134.traits[0] <= 1)
					{
						Politic politic = politic134;
						politic.loyality += 100;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 29)
		{
			text2 = "Империализм по-китайски";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Не желая встречаться с серьёзными экономическими проблемами, Ким Ир Сен всё-таки согласился на наши требования и пошёл на смягчение партийно-государственного контроля и частичные реабилитации попавших под прошлые репрессии, а также пошёл на частичное налаживание контактов с Японией и Южной Кореей.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.allcountries[10].Torg = true;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 70;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic135 in politics)
				{
					if (politic135.traits[0] <= 1)
					{
						Politic politic = politic135;
						politic.loyality -= 50;
					}
					else
					{
						Politic politic = politic135;
						politic.loyality += 50;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[1].power)
				{
					text = "Не желая идти нам на уступки, Ким Ир Сен первоначально хотел полностью переметнуться на сторону СССР в обмен на помощь от него, однако мы оказались гораздо влиятельнее и, не желая идти с нами на конфронтацию, он согласился на наши требования. В КНДР прошли масштабные реформы - смягчён партийно-государственный контроль, введена большая гласность и свобода в СМИ, в экономике же начались реформы, основанные на введении хозрасчёта и самоуправления. Всё это было положительно оценено Японией, Южной Кореей и США, чей президент отметил выдающийся вклад Китая в борьбу за мировую демократию.";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 100;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 30;
					GlobalScript.inst.gameState.allcountries[10].Torg = true;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic136 in politics)
					{
						if (politic136.traits[0] <= 1)
						{
							Politic politic = politic136;
							politic.loyality -= 100;
						}
						else
						{
							Politic politic = politic136;
							politic.loyality += 100;
						}
					}
					GlobalScript.inst.gameState.allcountries[10].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[10].SubGosstroy = 8;
				}
				else
				{
					text = "Не желая прогибаться под наши требования, Ким Ир Сен обратился за помощью к Советскому Союзу, который с радостью увеличил поставки материальной помощи и отправил в КНДР небольшой контингент войск на базирование. КНДР, до этого сохранявшая нейтралитет в отношении Китая и СССР, теперь прочно вошла в советскую сферу.";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 20;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.allcountries[10].prosov = true;
					GlobalScript.inst.gameState.allcountries[10].proprc = false;
					GlobalScript.inst.gameState.allcountries[10].Torg = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Не желая встречаться с серьёзными экономическими проблемами, Ким Ир Сен всё-таки согласился на наши требования и санкционировал открытие специальных экономических зон, где могли бы действовать иностранные предприятия, а китайские получат также и льготные условия. Наши предприниматели очень довольны и мы уже предвкушаем получение новых прибылей.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.data[8] += 40;
				GlobalScript.inst.gameState.allcountries[10].Torg = true;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic137 in politics)
				{
					if (politic137.traits[0] >= 1)
					{
						Politic politic = politic137;
						politic.loyality += 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Не желая прогибаться под наши требования, Ким Ир Сен обратился за помощью к Советскому Союзу, который с радостью увеличил поставки материальной помощи и отправил в КНДР небольшой контингент войск на базирование. КНДР, до этого сохранявшая нейтралитет в отношении Китая и СССР, теперь прочно вошла в советскую сферу.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 20;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.allcountries[10].prosov = true;
				GlobalScript.inst.gameState.allcountries[10].proprc = false;
				GlobalScript.inst.gameState.allcountries[10].Torg = false;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 30)
		{
			text2 = "Конец конфликта?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				if (GlobalScript.inst.gameState.influencePRC >= 150)
				{
					text = "По итогам переговоров Ясир Арафат, лидер ООП, согласился на отказ от террористических методов борьбы, осуждение террористов и на признание за Израилем права на существование, а Израиль в свою очередь согласился на поэтапное создание Государства Палестины на территориях Западного берега реки Иордан, Сектора Газа и большей части Восточного Иерусалима (хотя вопрос о последнем всё ещё остается предметом острых споров) и постепенный вывод израильской армии с этих территорий. Многие радикальные арабские группировки назвали такие соглашения предательством и приняли решение продолжать борьбу до полного уничтожения Израиля. Однако это грандиозная победа для арабского мира, которая может положить начало нормализации отношений между арабским миром и Израилем.";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					GlobalScript.inst.gameState.data[85] = 2;
					GlobalScript.inst.gameState.allcountries[37].Vyshi = false;
				}
				else
				{
					text = "Несмотря на все наши усилия, стороны так и не смогли прийти к компромиссу, наше предложение отвергли, а переговоры провалились. Кажется, вскоре начнётся новый виток насилия.";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[1] -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "По итогам переговоров Ясир Арафат, лидер ООП, согласился на отказ от террористических методов борьбы, осуждение террористов и на признание за Израилем права на существование, а Израиль в свою очередь согласился на создание Палестинской Национальной Администрации на базе Западного берега реки Иордан и Сектора Газа, которая стала бы органом самоуправления палестинской автономии до окончательного решения по статусу арабов в Палестине, которое должно быть принято через 5 лет. Многие радикальные арабские группировки назвали такие соглашения предательством и приняли решение продолжать борьбу до полного уничтожения Израиля. Впрочем, мы надеемся, что эти соглашения приведут в итоге к урегулированию конфликта.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 50;
				GlobalScript.inst.gameState.data[85] = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				if (GlobalScript.inst.gameState.influencePRC >= 200 && GlobalScript.inst.gameState.OAR)
				{
					text = "По итогам переговоров Ясир Арафат, лидер ООП, согласился на отказ от террористических методов борьбы, осуждение террористов и на признание за Израилем права на существование. Однако дальнейшее стало полной неожиданностью - стороны пришли к соглашению о создании Союзного Государства Палестины и Израиля, с общей армией, двуязычным делопроизводством, развитым местным самоуправлением и обязательным нейтралитетом внешней политики. Часть радикальных группировок, конечно, назвали это предательством, однако другие решили всё же приостановить террористические атаки. Разумеется, создание нового государства будет проходить со скрипом, и решить предстоит ещё множество конфликтов, однако само решение о его создании говорит о серьёзном шаге в сторону долгожданного мира.";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 30;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 50;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					GlobalScript.inst.gameState.data[85] = 3;
					GlobalScript.inst.gameState.allcountries[37].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[37].proprc = true;
					if (PlayerPrefs.GetInt("language") == 0)
					{
						GlobalScript.inst.gameState.allcountries[37].name = "联邦国家";
					}
					else
					{
						GlobalScript.inst.gameState.allcountries[37].name = "Союзное Гос-во";
					}
				}
				else
				{
					text = "Несмотря на все наши усилия, стороны так и не смогли прийти к компромиссу, наше предложение отвергли, а переговоры провалились. Кажется, вскоре начнётся новый виток насилия.";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[1] -= 100;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 31)
		{
			text2 = "Правильная демократия";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Победу на первых свободных выборах, сыграв на раздробленности оппозиции, одержал Ро Дэ У, сторонник старого военного режима, успевший вовремя от него отмежеваться после падения популярности Чон Ду Хвана.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				GlobalScript.inst.gameState.allcountries[46].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[46].SubGosstroy = 5;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря нашей помощи, Ким Дэ Чжуну удалось сплотить оппозицию вокруг себя, что и привело его к победе на выборах. Южную Корею ожидают масштабные демократические реформы, а риторика в отношении Северной уже была смягчена. Намечается значительное потепление в отношениях двух Корей, но, кажется, до объединения дело не дойдёт.";
				GlobalScript.inst.gameState.data[9] -= 40;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 5;
				GlobalScript.inst.gameState.allcountries[46].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[46].SubGosstroy = 6;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Благодаря нашей помощи, Ким Дэ Чжуну удалось сплотить оппозицию вокруг себя, что и привело его к победе на выборах. Южную Корею ожидают масштабные демократические реформы, а риторика в отношении Северной уже была смягчена. Также и сам Север под нашим давлением пошла на мирные контакты с южным соседом и Японией, что в итоге привело к исторической встрече лидеров двух Корей в Пхеньяне, где помимо долгожданной разрядки было решено поэтапно объединить Корею в нейтральную конфедерацию, где стороны совместно решали бы вопросы внешней политики и обороны, сохранив при этом внутренюю самостоятельность. А американским частям из Республики Кореи скоро придётся плыть домой.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 250;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[6] += 10;
				GlobalScript.inst.gameState.data[9] -= 60;
				GlobalScript.inst.gameState.allcountries[46].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[46].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[46].SubGosstroy = 8;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 32)
		{
			text2 = "Улан-Баторская весна?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Под нажимом протестующих МНРП пошла на некоторые уступки, разогнав при этом самых радикальных из них. Была сильно смягчена цензура и давление на диссидентов и религию. Внешняя политика хоть и стала более независимой, но в основном Монголия по-прежнему ориентирвана на СССР.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Под нажимом протестующих МНРП пошла на некоторые уступки, разогнав при этом самых радикальных из них. Была сильно смягчена цензура и давление на диссидентов и религию. Именно благодаря этому, мы сумели провести в монгольские СМИ и общественно-политическую жизнь личностей, выступающих за более независимую от СССР внешюю политику и, в частности, налаживание отношений с Китаем.";
				GlobalScript.inst.gameState.data[9] -= 40;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 5;
				GlobalScript.inst.gameState.allcountries[9].prosov = false;
				GlobalScript.inst.gameState.allcountries[9].SubGosstroy = 1;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 33)
		{
			text2 = "Полумесяцем в бровь";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Около полуночи 4 июля генерал Зия-уль-Хак приказал 111-й бригаде из Равалпинди окружить все основные федеральные правительственные здания, полицейские участки и Национальную ассамблею. После этого он приказал полиции арестовать Зульфикара Бхутто, министров и других руководителей из Пакистанской народной партии. В обращении к населению по национальному телевидению, генерал Зия заявил, что Национальная ассамблея Пакистана и провинциальные ассамблеи были распущены, а Конституция Пакистана перестала действовать. Новое правительство взяло курс на исламизацию Пакистана и вновь вернулось к проамериканской внешней политике.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 30;
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.allcountries[31].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[31].SubGosstroy = 7;
				GlobalScript.inst.gameState.allcountries[31].Vyshi = true;
				GlobalScript.inst.gameState.allcountries[31].proprc = false;
				GlobalScript.inst.gameState.allcountries[31].Torg = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря нашему предупреждению Бхутто сумел укрыться от мятежников и выставить против них лояльные части, которые вместе с прибывшим им на помощь спецназом МГБ остановили мятежников и провели захват лидеров путча. Генерал Зия-уль-Хак был казнён за измену, а положение в стране, благодаря нашей материальной помощи и помощи в борьбе с протестующими, удалось нормализовать. Бхутто продолжил курс на строительство исламского социализма, внедряя всё больше социалистических методов в экономику. В отношениях с Индией также намечается небольшое потепление.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[9] -= 60;
				GlobalScript.inst.gameState.data[8] -= 30;
				GlobalScript.inst.gameState.allcountries[31].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[31].SubGosstroy = 3;
				GlobalScript.inst.gameState.allcountries[31].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[31].isSENTO = false;
				GlobalScript.inst.gameState.allcountries[31].proprc = true;
				GlobalScript.inst.gameState.party_ideology[4] -= (int)((float)GlobalScript.inst.gameState.party_ideology[4] * 0.25f);
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Около полуночи 4 июля генерал Зия-уль-Хак приказал 111-й бригаде из Равалпинди окружить все основные федеральные правительственные здания, полицейские участки и Национальную ассамблею. После этого он приказал полиции арестовать Зульфикара Бхутто, министров и других руководителей из Пакистанской народной партии. В обращении к населению по национальному телевидению, генерал Зия заявил, что Национальная ассамблея Пакистана и провинциальные ассамблеи были распущены, а Конституция Пакистана перестала действовать. Новое правительство взяло курс на исламизацию Пакистана и вновь вернулось к проамериканской внешней политике, что не помешало нам сохранить с ним близкие и взаимовыгодные отношения.";
				GlobalScript.inst.gameState.data[4] += 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 50;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
				GlobalScript.inst.gameState.allcountries[31].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[31].SubGosstroy = 7;
				GlobalScript.inst.gameState.allcountries[31].Vyshi = true;
				GlobalScript.inst.gameState.allcountries[31].proprc = false;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 34)
		{
			text2 = "Враги моих врагов";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "На очередном заседании политбюро ЦК КПК товарищ Гофэн подверг критике некоторых членов фракции реформаторов за чрезмерную поспешность в необходимости внутриполитических и экономических изменений, а также призвал решать все назревшие проблемы коллегиально, чтобы не допустить раскола в партии и «волюнтаристских ошибок» Хрущёва в СССР. Лояльные консерваторы поддержали наше предложение «не вносить раздор в партию», однако, либерально-настроенное крыло всё ещё продолжает настаивать на ускорении экономических реформ, но всё же соглашается идти нам на уступки по необходимости поддержания внутрипартийной демократии. В тот же момент, народ, прочитавший стенограммы заседания в СМИ, остался недоволен замедлением долгожданных перемен, которые, казалось, уже начались после разгрома «Банды четырёх».";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.5f);
				GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.15f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic138 in politics)
				{
					if (politic138.traits[0] == 2)
					{
						politic = politic138;
						politic.loyality -= 100;
					}
					else if (politic138.traits[0] == 0)
					{
						politic = politic138;
						politic.loyality += 100;
					}
				}
				politic = GlobalScript.inst.gameState.politics[7];
				politic.power -= 100;
				politic = GlobalScript.inst.gameState.politics[6];
				politic.power -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Не желая расшатывать своё и так непростое положение, вы не решились вступать в открытое противостояние с самыми влиятельными представителями реформаторов, а только ограничились продвижением лояльных ему членов умеренно-консервативного крыла для того, чтобы не допустить необдуманных губительных реформ. Реформаторы, в свою очередь, обвиняют товарища председателя в попытке расколоть партию и планах создать свою «банду четырёх», из лояльных ему людей, не представляющих интересы широких слоёв населения. Однако дальше обвинений дело пока не пошло.";
				GlobalScript.inst.gameState.data[1] -= 100;
				party_change[1] = 4f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic139 in politics)
				{
					if (politic139.traits[0] == 0)
					{
						politic = politic139;
						politic.loyality += 100;
					}
				}
				politic = GlobalScript.inst.gameState.politics[5];
				politic.power += 100;
				politic = GlobalScript.inst.gameState.politics[8];
				politic.power += 100;
				politic = GlobalScript.inst.gameState.politics[9];
				politic.power += 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Заручившись поддержкой умеренно-консервативного большинства, вы на очередном съезде ЦК КПК раскритиковали позиции реформаторов и, используя своё влияние в Министерстве общественной безопасности, начали активно мешать карьере разных менее именитых сторонников реформ и продвигать наверх своих людей из числа умеренных консерваторов. Народ, до которого докатилась ваша критика, остался, конечно, недоволен, как и реформаторское крыло партии. Но зато ваши позиции существенно окрепли.";
				GlobalScript.inst.gameState.data[1] -= 150;
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[6] += 20;
				party_change[1] = 4f;
				GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.1f);
				GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.15f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				Politic politic;
				foreach (Politic politic140 in politics)
				{
					if (politic140.traits[0] == 2)
					{
						politic = politic140;
						politic.loyality -= 200;
					}
					else if (politic140.traits[0] == 0)
					{
						politic = politic140;
						politic.loyality += 150;
					}
				}
				politic = GlobalScript.inst.gameState.politics[6];
				politic.power -= 150;
				politic = GlobalScript.inst.gameState.politics[7];
				politic.power -= 150;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "На очередном заседании политбюро товарищ Гофэн заявил о необходимости продолжения намеченного курса социально-экономических изменений, а также сумел в кулуарах договориться с Ли Сяньнянем и Е Цзяньином об объединении усилий и созданию своеобразного умеренно-реформаторского альянса. Пользуясь свободой действий, реформаторы уже активно продвигают в партии своих людей соответствующих взглядов, таких как Дэн Сяопин и Чжао Цзыян. Народ же, замечая движение к реформам, ожидает от них перемен к лучшему, впрочем, консервативная часть партии недовольна таким положением дел.";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[4] += 80;
				GlobalScript.inst.gameState.data[6] -= 20;
				party_change[3] = 5f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic141 in politics)
				{
					if (politic141.traits[0] == 2)
					{
						Politic politic = politic141;
						politic.loyality += 200;
						politic = politic141;
						politic.power += 120;
					}
					else if (politic141.traits[0] == 3)
					{
						Politic politic = politic141;
						politic.power += 70;
					}
					else if (politic141.traits[0] == 0)
					{
						Politic politic = politic141;
						politic.loyality -= 200;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "В политбюро и остальной КПК стремительно растут реформаторски-либеральные настроения, что очень злит старых консерваторов, которые боятся потерять свои позиции и прежнее влияние, а также падения Китая в пучину ревизионизма. Власть всё ещё в ваших руках, но надолго ли?";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[4] += 30;
				party_change[3] = 2f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic142 in politics)
				{
					if (politic142.traits[0] >= 2)
					{
						Politic politic = politic142;
						politic.power += 70;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 35)
		{
			text2 = "Конец революции";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Несмотря на завершившееся сворачивание Культурной революции, дальнейшего движения к либерализации, похоже не будет. Народ и реформаторское крыло разочарованы.";
				GlobalScript.inst.gameState.data[4] += 40;
				GlobalScript.inst.gameState.data[3] -= 60;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic143 in politics)
				{
					if (politic143.traits[0] >= 1)
					{
						Politic politic = politic143;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В рамках продолжения борьбы с перегибами Культурной революции репрессивный контроль в Китае постепенно был немного снижен. Народ и реформаторы довольны, но как бы чего не вышло...";
				GlobalScript.inst.gameState.data[3] += 60;
				GlobalScript.inst.gameState.data[4] += 20;
				GlobalScript.inst.gameState.data[57] -= 30;
				if (GlobalScript.inst.gameState.data[17] < 17)
				{
					GlobalScript.inst.gameState.data[17] = 17;
				}
				GlobalScript.inst.gameState.data[6] -= 20;
				party_change[3] = 1.5f;
				party_change[2] = 2f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic144 in politics)
				{
					if (politic144.traits[0] >= 1)
					{
						Politic politic = politic144;
						politic.loyality += 50;
						politic = politic144;
						politic.power += 30;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В рамках продолжения борьбы с перегибами Культурной революции репрессивный контроль в Китае постепенно был немного снижен, а также была прекращена активная борьба с традиционализмом, что ознаменовало небольшое, но снижение давления на религию. Государственный атеизм, впрочем, никуда не делся. Несмотря на некоторые подпольные антигосударственные проповеди священнослужителей, народ, в целом, доволен. Надеемся, это не приведёт к проблемам.";
				GlobalScript.inst.gameState.data[3] += 70;
				GlobalScript.inst.gameState.data[4] += 40;
				GlobalScript.inst.gameState.data[6] -= 30;
				if (GlobalScript.inst.gameState.data[17] < 17)
				{
					GlobalScript.inst.gameState.data[17] = 17;
				}
				if (GlobalScript.inst.gameState.data[50] < 25)
				{
					GlobalScript.inst.gameState.data[50] = 25;
				}
				party_change[3] = 1.5f;
				party_change[2] = 2f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic145 in politics)
				{
					if (politic145.traits[0] >= 1)
					{
						Politic politic = politic145;
						politic.loyality += 80;
						politic = politic145;
						politic.power += 30;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "В рамках продолжения борьбы с перегибами Культурной революции репрессивный контроль в Китае постепенно был немного снижен, а также была прекращена активная борьба с традиционализмом и утверждена свобода совести при сохранении государственного курса на атеизм и его контроля за религиозными учреждениями. Несмотря на некоторые антигосударственные проповеди священнослужителей, которые, зачастую быстро пресекаются, народ, в целом, доволен. Надеемся, это не приведёт к проблемам и столкновениям народов КНР.";
				GlobalScript.inst.gameState.data[3] += 90;
				GlobalScript.inst.gameState.data[4] += 60;
				GlobalScript.inst.gameState.data[6] -= 40;
				if (GlobalScript.inst.gameState.data[17] < 17)
				{
					GlobalScript.inst.gameState.data[17] = 17;
				}
				if (GlobalScript.inst.gameState.data[50] < 26)
				{
					GlobalScript.inst.gameState.data[50] = 26;
				}
				party_change[3] = 1.5f;
				party_change[2] = 2f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic146 in politics)
				{
					if (politic146.traits[0] >= 1)
					{
						Politic politic = politic146;
						politic.loyality += 80;
						politic = politic146;
						politic.power += 50;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 36)
		{
			text2 = "Крах коалиции?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Потерпев какое-то время и безуспешно попытавшись наладить отношения с баасистским руководством, ИКП в конечном итоге приняло решение о разрыве. В апреле 1979 министры-коммунисты вышли из правительства, компартия прекратила своё участие в Национальном фронте. В мае 1979 руководство ИКП приняло решение о выходе из ПНПФ и переходе на нелегальное положение.";
				GlobalScript.inst.gameState.allcountries[14].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наше осуждение ожидаемо привело лишь к обострению отношений с Ираком и к дальнейшим репрессиям против коммунистов. Потерпев какое-то время и безуспешно попытавшись наладить отношения с баасистским руководством, ИКП в конечном итоге приняло решение о разрыве. В апреле 1979 министры-коммунисты вышли из правительства, компартия прекратила своё участие в Национальном фронте. В мае 1979 руководство ИКП приняло решение о выходе из ПНПФ и переходе на нелегальное положение.";
				GlobalScript.inst.gameState.data[6] += 10;
				GlobalScript.inst.gameState.allcountries[14].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 10;
				GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 10;
				GlobalScript.inst.gameState.allcountries[14].Torg = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Наше неофициальное политическое давление на обе стороны, подкреплённое собранным спецслужбами компроматом и спровоцированными небольшими протестами против Баас, в итоге принесло плоды. Баасисты прекратили репрессии и заявили о своём твёрдом союзе с ИКП, которая также подтвердила своё членство в ПНПФ, отказавшись от антиправительственной агитации и требований отмены чрезвычайного положения. Понятно, что за этими красивыми словами скрывается лишь подковёрная борьба и шаткое подобие альянса, но какое-то время такая коалиция ещё продержится.";
				GlobalScript.inst.gameState.data[1] += 70;
				GlobalScript.inst.gameState.data[4] -= 30;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.ICP = true;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 37)
		{
			text2 = "Конец египетского паши";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Мы решили активно вмешаться в ситуацию и поддержать волнения. По тайным каналам в руки демонстрантов попало много оружия, которое те сразу же пустили в ход против полиции. В Каире и ряде других городов начались настоящие уличные бои, в результате которых погибло много людей с обеих сторон. Садат пытался заручиться поддержкой США и Израиля, но это настроило против него все три фракции АСС и командование армии, не забывших поражение 1973 года. После предпринятой попытки покушения на него, Садат бежал в американское посольство в Каире и запросил политическое убежище. После переговоров между демонстрантами и армейским командованием, было принято решение передать власть правительству национального единства во главе с бывшим вице-президентом Али Сабри. Он начал откат капиталистических реформ, восстановил единство АСС, разорвал все связи с США и Израилем и уже начал переговоры об восстановлении дипотношений с СССР, Китаем, Ливией, Сирией, Ираком и другими социалистическими странами. Новый президент также объявил о готовности Египта к участию в панарабских и панафриканских интеграционных проектах, что открывает для нас интересные перспективы по формированию широкой конфедерации арабских стран против США и их марионеток на Ближнем Востоке.";
				GlobalScript.inst.gameState.data[1] += 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 150;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 80;
				GlobalScript.inst.gameState.data[9] -= 60;
				GlobalScript.inst.gameState.data[8] -= 40;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 10;
				GlobalScript.inst.gameState.allcountries[30].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[30].SubGosstroy = 15;
				GlobalScript.inst.gameState.allcountries[30].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[30].Torg = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.allcountries[13].Torg || GlobalScript.inst.gameState.allcountries[30].stab == 1)
				{
					text = "Не решившись на прямое вмешательство, мы пошли другим путем и стали действовать через Ливию и Сирию, имеющих свои счеты к Садату. Секретная организация Ливийской Джамахирии и Военная разведка Сирии при помощи нашего МГБ и с негласного одобрения советского КГБ объединили усилия в разработке плана ликвидации египетского президента. 25 октября Анвар Садат был убит ливийским снайпером во время выступления перед митингующими египтянами на площади Тахрир в Каире. При поддержке уцелевших сторонников насеризма, новым президентом Египта стал амнистированный Али Сабри, однако премьером при нем стал соратник покойного Хосни Мубарак. АРЕ отказывается от углубления реформ, сворачивает наиболее радикальные из них и постепенно нормализует отношения с арабскими странами. Сабри уже возобновил переговоры с СССР об восстановлении военно-технического сотрудничества, так что курс страны вновь качнулся влево - но не в нашу сторону...";
					GlobalScript.inst.gameState.data[1] += 20;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 20;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.data[9] -= 20;
					GlobalScript.inst.gameState.data[8] -= 20;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 20;
					GlobalScript.inst.gameState.allcountries[30].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[30].SubGosstroy = 3;
					GlobalScript.inst.gameState.allcountries[30].prosov = true;
					GlobalScript.inst.gameState.allcountries[30].Vyshi = false;
				}
				else
				{
					text = "Не решившись на прямое вмешательство, мы пошли другим путем и стали действовать через Ливию и Сирию, имеющих свои счеты к Садату. Секретная организация Ливийской Джамахирии и Военная разведка Сирии при помощи нашего МГБ и с негласного одобрения советского КГБ объединили усилия в разработке плана ликвидации египетского президента. 25 октября Анвар Садат был убит ливийским снайпером во время выступления перед митингующими египтянами на площади Тахрир в Каире. Новым президентом Египта стал его соратник Хосни Мубарак, который отказался от углубления реформ и взял курс на многовекторную внешнюю политику, правда, с сохранением антисоветского оттенка. Постепенно нормализуются отношения между АРЕ и его арабскими соседями.";
					GlobalScript.inst.gameState.data[9] -= 20;
					GlobalScript.inst.gameState.data[8] -= 20;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					GlobalScript.inst.gameState.allcountries[30].Vyshi = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Анвар Садат пошел на ряд уступок митингующим, пообещав повысить субсидии на ТНП малоимущим и начать перевооружение египетской армии и её обучение по стандартам НАТО, чтобы \"больше никто не мог воспользоваться нашими слабостями\". Это позволило ему стабилизировать обстановку в стране. Ожидается визит Садата в Израиль и окончательное восстановление отношений с ним...";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 38)
		{
			text2 = "Возвращение к истокам";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Экономика КНР продолжает постепенный рост, но как скоро он принесёт свои плоды? Поживём - увидим.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "На очередном заседании Политбюро ЦК КПК было принято решение о восстановлении плановой системы советского образца, вынужденно отвергнутой в 60-е, был создан Плановый комитет, который вскоре должен принять пятилетнюю стратегию развития народного хозяйства. Разумеется реформаторы недовольны откатом реформ Чжоу, народ с сомнением отнёсся к восстановлению старой системы, да и средства на преобразования и создание бюрократии пришлось выделить.";
				GlobalScript.inst.gameState.data[8] -= 10;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[3] -= 40;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 70;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GlobalScript.inst.gameState.data[16] = 10;
				party_change[0] = 2.5f;
				party_change[1] = 2.5f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic147 in politics)
				{
					if (politic147.traits[0] == 0)
					{
						Politic politic = politic147;
						politic.loyality += 100;
					}
					else if (politic147.traits[0] == 1)
					{
						Politic politic = politic147;
						politic.loyality -= 30;
					}
					else if (politic147.traits[0] == 2)
					{
						Politic politic = politic147;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В соответствии с провозглашённым ранее курсом на изменение общественно-экономической жизни, вы вместе с наиболее видными реформаторскими фигурами сформировали специальную комиссию и начали разработку программы будущих экономических реформ, которые должны продолжить дело Чжоу Эньлая. Партия (точнее только её правое и умеренное крыло) с нетерпением ждёт решений комиссии, а часть народа, до которой долетели пока лишь отрывочные слухи, ожидает перемен к лучшему.";
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[4] += 20;
				GlobalScript.inst.gameState.data[3] += 30;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 70;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 80;
				party_change[2] = 4.5f;
				party_change[3] = 4.5f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic148 in politics)
				{
					if (politic148.traits[0] == 2)
					{
						Politic politic = politic148;
						politic.loyality += 150;
						politic = politic148;
						politic.power += 100;
					}
					else if (politic148.traits[0] == 1)
					{
						Politic politic = politic148;
						politic.loyality += 70;
						politic = politic148;
						politic.power += 50;
					}
					else if (politic148.traits[0] == 0)
					{
						Politic politic = politic148;
						politic.loyality -= 170;
						politic = politic148;
						politic.power -= 100;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 39)
		{
			text2 = "Комиссия по \"Решению...\"";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "  принял решение - лично возглавить комиссию по составлению \"Решения по некоторым вопросам истории КПК со времени образования КНР\", а своим заместителем назначил одного из главных идеологов \"Культурной революции\" - " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[0]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[0]].name_2] + ". В своей оценке, комиссия ориентируется на работы Мао Цзэдуна времен \"Великой полемики\". Личность самого Мао оценивается положительно, однако упоминаются перегибы как правого, так и левого толка, не носящие, однако, принципиального значения в его деятельности. Документ начинает приобретать вид очередного маоистского памфлета времен \"Культурной революции\", хотя и критикует её...";
				GlobalScript.inst.gameState.data[1] += 80;
				GlobalScript.inst.gameState.data[3] += 20;
				GlobalScript.inst.gameState.data[6] += 10;
				GlobalScript.inst.gameState.data[90] = 0;
				party_change[0] = 1.5f;
				party_change[1] = 1.5f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic149 in politics)
				{
					if (politic149.traits[0] == 0)
					{
						Politic politic = politic149;
						politic.loyality += 100;
						politic = politic149;
						politic.power += 30;
					}
					else if (politic149.traits[0] == 1)
					{
						Politic politic = politic149;
						politic.loyality += 60;
						politic = politic149;
						politic.power += 20;
					}
					else if (politic149.traits[0] == 2)
					{
						Politic politic = politic149;
						politic.loyality += 50;
					}
					else if (politic149.traits[0] == 3)
					{
						Politic politic = politic149;
						politic.loyality -= 100;
						politic = politic149;
						politic.power -= 30;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В соответствии с решением Политбюро, комиссию возглавил старый идеолог реформ Дэн Сяопин. Своим заместителем он назначил своего единомышленника Ху Яобана. Хотя оба пострадали от \"Культурной революции\", они, тем не менее, смогли подняться выше обиды на Мао Цзэдуна и непредвзято оценили его период. Сам Мао получил ту же оценку, которую в своих статьях \"Об историческом опыте диктатуры пролетариата\", \"Ещё раз об историческом опыте диктатуры пролетариата\" и \"К вопросу о Сталине\" он дал Сталину - \"Заслуги и ошибки Сталина находятся в соотношении 70 к 30\", при этом все основные провалы (вроде \"Большого скачка\") свалены на покойных Линь Бяо и Кан Шэна, дававших \"неправильные советы\" Председателю Мао. Дэн Сяопин девять раз делал замечания редакторам по поводу текста («нехорошо», «нужно переработать», «слишком объемно», «слишком грустно» и т. п.). Пожалуй, мы полностью угадали с выбором и \"Решение по некоторым вопросам истории КПК со времени образования КНР\" будет взвешенным и может послужить первым шагом к переосмыслению нашего прошлого ради светлого будущего... ";
				GlobalScript.inst.gameState.data[1] += 100;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[6] -= 30;
				GlobalScript.inst.gameState.data[90] = 1;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 20;
				party_change[0] = 1.5f;
				party_change[1] = 1.5f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic150 in politics)
				{
					if (politic150.traits[0] == 0)
					{
						Politic politic = politic150;
						politic.loyality += 50;
						politic = politic150;
						politic.power += 10;
					}
					else if (politic150.traits[0] == 1)
					{
						Politic politic = politic150;
						politic.loyality += 100;
						politic = politic150;
						politic.power += 40;
					}
					else if (politic150.traits[0] == 3)
					{
						Politic politic = politic150;
						politic.loyality += 60;
					}
					else if (politic150.traits[0] == 2)
					{
						Politic politic = politic150;
						politic.loyality += 80;
						politic = politic150;
						politic.power += 30;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Хуа Гофэн, несмотря на возражения со стороны как правого, так и левого крыла КПК, назначил во главе комиссии опального партийца либеральных взглядов Пэн Чженя. Тот назначил своим заместителем Чжао Цзыяна, чьи взгляды не слишком отличались от его. Оба серьезно пострадали в ходе \"Культурной революции\" и теперь особо не скрывали желания отыграться за пережитое. Документ, составленный ими, оценивает социалистический период истории Китая как \"время феодально-фашистской диктатуры Мао Цзэдуна, который произвел массовый террор, уничтожил честных коммунистов, таких как Лю Шаоци и Пэн Дэхуай, и полностью подчинил партию своей воли, установив в КНР культ личности\". Он рекомендует \"вернуться к истокам, к Марксу, Ленину, Чэнь Дусю и Ван Мину, отвергнуть антимарксистский культ личности Мао Цзэдуна и заклеймить свое тоталитарное прошлое ради строительства светлого социалистического будущего Китая\". Что-то я не думаю, что эта китайская копия хрущевского \"секретного доклада\" 1956 года понравится как рядовым партийцам, так и народу...";
				if (GlobalScript.inst.gameState.data[104] == 10)
				{
					text += "|В ночь после принятия документа, Мао был вынесен из Мавзолея, а на следующий день здание было подвергнуто сносу. На месте Мавзолея будет построен музей Чэнь Дусю, первого Генерального Секретаря ЦК КПК, обвинённого в нерешительности и, позже, ушедшего на сторону троцкистской оппозиции. ";
					GlobalScript.inst.gameState.data[104] = 9;
					if (GlobalScript.inst.gameState.iron_and_blood)
					{
						achieves.GetComponent<achievements>().Set(9);
					}
				}
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[6] -= 60;
				GlobalScript.inst.gameState.data[90] = 2;
				party_change[3] = 1.5f;
				party_change[4] = 1f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic151 in politics)
				{
					if (politic151.traits[0] == 0)
					{
						Politic politic = politic151;
						politic.loyality -= 150;
					}
					else if (politic151.traits[0] == 1)
					{
						Politic politic = politic151;
						politic.loyality -= 100;
					}
					else if (politic151.traits[0] == 2)
					{
						Politic politic = politic151;
						politic.loyality += 50;
					}
					else if (politic151.traits[0] == 3)
					{
						Politic politic = politic151;
						politic.loyality += 150;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 40)
		{
			text2 = "Судьба Панчен-Ламы";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "От вас письмо ушло со следующей резолюцией: \"Заслуги Панчен-Ламы X перед тибетским и китайским народами велики, однако нанесенный им удар по интернациональной дружбе Тибета и Китая ещё более велик. Его освобождение несвоевременно и опасно\". В марте 1979 года китайский диссидент Вэй Цзиншэн опубликовал письмо с осуждением условий содержания Панчен-Ламы в тюрьме Циньчэн, после чего он был перевезен в Лхасу с изменением меры пресечения на домашний арест. Однако на свободу до своей смерти 28 января 1989 года Панчен-Лама X так и не вышел...";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[6] += 5;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.data[50] <= 25)
				{
					text = "Чокьи Гьялцен наотрез отказался от выполнения этого условия, сославшись на крайне репрессивный характер отношения нашего государства к тибетскому духовенству. Что-ж, это его выбор - пускай остается в Циньчэне до скончанья своего земного бытия...";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[3] -= 60;
					GlobalScript.inst.gameState.data[6] += 10;
					GlobalScript.inst.gameState.data[57] -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
				}
				else
				{
					text = "Чокьи Гьялцен согласился с этим условием, попросив передать товарищу " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", что, в целом, одобряет политику нашего государства в отношении тибетского духовенства и обязуется больше не принимать участия в духовной жизни. После освобождения, он отправился в путешествие по Китаю, женился на военнослужащей Ли Цзе, а в 1982 году был полностью реабилитирован и получил разрешение на возвращение в Лхасу. Его даже избрали депутатом ВСНП от Тибетского АР.";
					GlobalScript.inst.gameState.data[3] += 60;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[57] += 40;
					GlobalScript.inst.gameState.data[6] -= 20;
					GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 33;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "От вас письмо ушло со следующей резолюцией: \"Панчен-Лама X провел в заключении достаточно времени, чтобы обдумать и осмыслить свои поступки и ошибки. Я согласен с тем, чтобы отпустить его в ближайшее время и позволить вернуться в Тибет, однако следует установить за ним наблюдение\". По возвращению в Лхасу, Чокьи Гьялцен занялся перезахоронением останков предыдущих Панчен-лам из могил, которые были разрушены во время уничтожения монастыря Ташилунпо в 1959 году, однако, в целом, вел себя тихо и на контакт с беглым Далай-Ламой XIV или его сторонниками выйти не пытался. Поэтому в 1983 году наблюдение за ним было снято. Помилование Панчен-Ламы было доброжелательно воспринято народом, Западом и тибетской эмиграцией.";
				GlobalScript.inst.gameState.data[3] += 80;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.data[57] += 40;
				GlobalScript.inst.gameState.data[9] -= 40;
				GlobalScript.inst.gameState.data[6] -= 20;
				GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 33;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				if (GlobalScript.inst.gameState.data[50] >= 26 && GlobalScript.inst.gameState.data[3] >= 700)
				{
					text = "По возвращению в Лхасу, Панчен-Лама X официально объявил, что не имеет никаких претензий к властям Китая и что понесенное им наказание было справедливым и очень важным уроком для него, который ещё сильнее приблизил его к просветлению. Он занялся перезахоронением останков предыдущих Панчен-лам из могил, которые были разрушены во время уничтожения монастыря Ташилунпо в 1959 году, активно участвовал в благотворительной деятельности, посетил (с согласия советского руководства) с визитом Калмыцкую, Бурятскую и Тувинскую АССР, где способствовал установлению культурных связей Тибетского АР с этими автономными республиками. Народ и международная общественность довольны.";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[3] += 120;
					GlobalScript.inst.gameState.data[6] -= 20;
					GlobalScript.inst.gameState.data[57] += 40;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 120;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					GlobalScript.inst.gameState.allcountries[69].numberOfSpecialEnding = 33;
				}
				else
				{
					text = "Панчен-Лама X так и не простил китайским властям нанесенной ему обиды. Сразу по возвращению в Лхасу, он начал выступать с подстрекательскими речами (например: \"Благодаря освобождению, безусловно, имело место развитие, но цена, заплаченная за это развитие, была больше, чем выгоды\"), налаживать связи со сторонниками Далай-Ламы, отправлять послания к мировой общественности с критикой положения дел в Китае и Тибетском АР в частности. Наконец, когда Верховный Народный Суд вынес решение об аресте Панчен-Ламы, тот бежал в Бутан, откуда перебрался в Индию и вошел в состав сформированного Далай-Ламой XIV т.н. \"Тибетского правительства в изгнании\". Выдавать его нам руководство Индии отказалось, так что теперь лагерь тибетских сепаратистов пополнился крайне важной фигурой. На пользу нам это явно не обернется...";
					GlobalScript.inst.gameState.data[3] -= 100;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 20;
					GlobalScript.inst.gameState.data[57] -= 100;
					GlobalScript.inst.gameState.data[6] += 20;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "28 октября 1977 года охрана тюрьмы Циньчэн обнаружила Панчен-Ламу X на полу его камеры без признаков жизни. Утром того же дня под видом укола тонизирующего вещества ему был введен специальный яд, который спровоцировал инфаркт миокарда. Хотя газета \"Сицзан жибао\" (орган Тибетского Совета народных представителей) опубликовала официальное коммюнике, в котором причиной смерти был назван сердечный приступ, в это мало кто поверил. В автономии уже открыто говорят, что \"Панчен-Лама был убит МГБ за несогласие с китайской аннексией Тибета\"... Назначенный с нашего одобрения глава комитета по розыску нового Панчен-ламы Чадрела Ринпоче тайно поддерживал контакты с беглым Далай-Ламой, что не укрылось от внимания МГБ. Ринпоче был арестован и заменен Сенченем Лобсаном Гьялценом, который был политическим противником как Далай-Ламы, так и покойного Панчен-Ламы. Он добился нужного нам исхода - 11 ноября был объявлен новый Панчен-Лама XI. \"Буддизм дал торжественную клятву государству и обществу защищать страну и трудиться на благо народа, — заявил Норбу. — Китайское общество является благоприятной средой для буддийской веры\". Он также вознес хвалу своему предшественнику за \"выдающийся вклад в укрепление единства страны и солидарности ее народа\". Однако Далай-Лама XIV и его т.н. \"Тибетское правительство в изгнании\" объявили новым Панчен-Ламой XI некоего младенца с территории Тибета. Нам пришлось отправить его в государственный приют... Тибетское духовенство саботирует деятельность нового Панчен-Ламы и поддерживает назначенца Далай-Ламы, среди монахов распространяются сепаратистские настроения... ";
				GlobalScript.inst.gameState.data[1] += 100;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				GlobalScript.inst.gameState.data[57] -= 30;
				GlobalScript.inst.gameState.data[9] -= 70;
				GlobalScript.inst.gameState.data[8] -= 40;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.data[3] -= 100;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 41)
		{
			text2 = "Индийские выборы";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Благодаря падению популярности Ганди и ИНК, а также тому, что борьба с чрезвычайным положением в глазах населения роднила их с борцами за свободу Индии от британского господства, Джаната парти удалось обойти ИНК. Морарджи Десаи стал новым премьер-министром. Сформированное им правительство восстановило дипломатические отношения с КНР, улучшило отношения с Пакистаном и отстаивало на мировой арене индийскую ядерную политику. Был создан трибунал для расследования злоупотреблений во время чрезвычайного положения, которому, однако, не удалось привлечь к ответственности Ганди. Однако в новой правящей партии уже активно проявляется раскол между её членами по поводу дальнейшего вектора развития страны.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.data[91] = 2;
				GlobalScript.inst.gameState.allcountries[19].Torg = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря падению популярности Ганди и ИНК, нашей активной поддержке а также тому, что борьба с чрезвычайным положением в глазах населения роднила их с борцами за свободу Индии от британского господства, Джаната парти удалось обойти ИНК. Морарджи Десаи стал новым премьер-министром. Сформированное им правительство восстановило дипломатические отношения с КНР, улучшило отношения с Пакистаном и отстаивало на мировой арене индийскую ядерную политику. Был создан трибунал для расследования злоупотреблений во время чрезвычайного положения, которому, однако, не удалось привлечь к ответственности Ганди. Однако в новой правящей партии уже активно проявляется раскол между её членами по поводу дальнейшего вектора развития страны. Надеемся, что наши хорошие отношения с Джаната парти позволят нам спасти её от краха.";
				GlobalScript.inst.gameState.data[1] += 70;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[91] = 1;
				GlobalScript.inst.gameState.data[8] -= 30;
				GlobalScript.inst.gameState.data[9] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 70;
				GlobalScript.inst.gameState.allcountries[19].Torg = true;
				GlobalScript.inst.gameState.allcountries[19].prosov = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Несмотря на прошлые разногласия с нами, Ганди с благодарностью приняла нашу помощь, только благодаря которой ИНК и удалось обойти оппозицию и победить. Индира Ганди продолжила быть премьер-министром, дипломатические отношения Индии и КНР были восстановлены, хотя между нами всё ещё наблюдается заметная напряжённость, да и территориальные споры не урегулированы. Будем надеятся, ИНК пойдёт на дальнейшее сближение и СССР ему не воспрепятствует.";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[91] = 3;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 20;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 30;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 42)
		{
			text2 = "Иранская революция";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Протесты и забастовки в Иране продолжаются без нашего участия.";
				GlobalScript.inst.gameState.iranrev = true;
				GlobalScript.inst.gameState.allcountries[8].dev = 4;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы сумели наладить контакты с НПИ и другими менее крупными коммунистическими, маоистскими и левонационалистическими организациями, договорившись о поддержке с нашей стороны. Первый шаг сделан, однако надо не забывать периодически отправлять им новую помощь.";
				GlobalScript.inst.gameState.data[42] += 70;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.iranrev = true;
				GlobalScript.inst.gameState.allcountries[8].dev = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Мы сумели наладить контакты с исламскими движениями в Иране и даже с самим Хомейни в Париже. Не сказать, что они обрадовались таким покровителям, однако, по всей видимости, посчитали нас меньшим злом, чем СССР, США и шах. Первый шаг сделан, однако надо не забывать периодически отправлять им новую помощь.";
				GlobalScript.inst.gameState.iranrev = true;
				GlobalScript.inst.gameState.data[45] += 70;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.allcountries[8].dev = 3;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Мы сумели наладить контакты с правящей династией Пехлеви и шахом Мохамедом Резой Пехлеви, которые с радостью приняли нашу помощь в борьбе с оппозицией. Наши агенты теперь вместе с иранской тайной полицией САВАК занимаются раскрытием оппозиционных сетей и отловом их членов. Первый шаг сделан, однако надо не забывать периодически отправлять шаху новую помощь.";
				GlobalScript.inst.gameState.iranrev = true;
				GlobalScript.inst.gameState.data[43] += 70;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.allcountries[8].dev = 0;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Мы сумели наладить контакты с Национальным фронтом и другими демократическими организациями (в том числе исламскими демократами) и договорились с ними о предоставлении нашей помощи. Первый шаг сделан, однако надо не забывать периодически отправлять им новую помощь.";
				GlobalScript.inst.gameState.iranrev = true;
				GlobalScript.inst.gameState.data[44] += 70;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[6] -= 20;
				GlobalScript.inst.gameState.allcountries[8].dev = 2;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 43)
		{
			text2 = "Расширение СЭВ";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "В ноябре 1978 Вьетнам вступил в СЭВ, что привело к ещё большему ухудшению наших отношений. В КПК уже активно зреют антивьетнамские настроения. Будем надеяться, это не выльется в масштабный конфликт.";
				GlobalScript.inst.gameState.data[1] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 30;
				GlobalScript.inst.gameState.allcountries[11].isSEV = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наше вмешательство и мобилизация сторонников более умеренного курса во Вьетнаме в итоге вынудила Ле Зуана и руководство КПВ отложить запланированное вступление в СЭВ на неопределённый срок и проводить более сбалансированную внешнюю политику. Советский Союз, конечно, не обрадовался, но это помогло нам хотя бы на время избежать дальнейшего сближения Вьетнама с СССР.";
				GlobalScript.inst.gameState.data[1] += 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 70;
				GlobalScript.inst.gameState.data[9] -= 30;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 44)
		{
			text2 = "Неважно, какого цвета кошка...";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "На нынешнем пленуме ЦК КПК при почти всеобщем одобрении (немногочисленные консерваторы почти не оказали сопротивления) было объявлено о начале рыночных реформ и была утверждена т.н. \"Политика реформ и открытости\", подразумевающая выход Китая на мировой рынок и перестройку экономики на рыночных принципах. Несмотря на то, что номинально страну ещё возглавляет  " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", фактически всей полнотой власти теперь обладает  " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2] + ", который готов вести страну в светлое рыночное будущее.";
				GlobalScript.inst.gameState.data[1] += 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				GlobalScript.inst.gameState.data[89] = 1;
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[3] += 60;
				GlobalScript.inst.gameState.data[6] -= 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				int[] array20 = new int[16]
				{
					GlobalScript.inst.gameState.leader.name_1,
					GlobalScript.inst.gameState.leader.name_2,
					GlobalScript.inst.gameState.leader.traits[0],
					GlobalScript.inst.gameState.leader.traits[1],
					GlobalScript.inst.gameState.leader.traits[2],
					GlobalScript.inst.gameState.leader.age,
					GlobalScript.inst.gameState.leader.face_type,
					GlobalScript.inst.gameState.leader.face_parts[0],
					GlobalScript.inst.gameState.leader.face_parts[1],
					GlobalScript.inst.gameState.leader.face_parts[2],
					GlobalScript.inst.gameState.leader.face_parts[3],
					GlobalScript.inst.gameState.leader.face_parts[4],
					GlobalScript.inst.gameState.leader.face_parts[5],
					GlobalScript.inst.gameState.leader.face_parts[6],
					GlobalScript.inst.gameState.leader.face_parts[7],
					GlobalScript.inst.gameState.leader.jacket
				};
				GlobalScript.inst.gameState.leader.name_1 = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1;
				GlobalScript.inst.gameState.leader.name_2 = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2;
				GlobalScript.inst.gameState.leader.traits[0] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[0];
				GlobalScript.inst.gameState.leader.traits[1] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[1];
				GlobalScript.inst.gameState.leader.traits[2] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[2];
				GlobalScript.inst.gameState.leader.age = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].age;
				GlobalScript.inst.gameState.leader.face_type = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_type;
				GlobalScript.inst.gameState.leader.face_parts[0] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[0];
				GlobalScript.inst.gameState.leader.face_parts[1] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[1];
				GlobalScript.inst.gameState.leader.face_parts[2] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[2];
				GlobalScript.inst.gameState.leader.face_parts[3] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[3];
				GlobalScript.inst.gameState.leader.face_parts[4] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[4];
				GlobalScript.inst.gameState.leader.face_parts[5] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[5];
				GlobalScript.inst.gameState.leader.face_parts[6] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[6];
				GlobalScript.inst.gameState.leader.face_parts[7] = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[7];
				GlobalScript.inst.gameState.leader.jacket = GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].jacket;
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1 = (byte)array20[0];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2 = (byte)array20[1];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[0] = (byte)array20[2];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[1] = (byte)array20[3];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].traits[2] = (byte)array20[4];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].age = (byte)array20[5];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_type = (byte)array20[6];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[0] = (byte)array20[7];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[1] = (byte)array20[8];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[2] = (byte)array20[9];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[3] = (byte)array20[10];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[4] = (byte)array20[11];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[5] = (byte)array20[12];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[6] = (byte)array20[13];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].face_parts[7] = (byte)array20[14];
				GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].jacket = (byte)array20[15];
				GlobalScript.inst.gameState.faction_leader[3] = 200;
				int[] array21 = new int[8];
				for (int num77 = 0; num77 < GlobalScript.inst.gameState.politics_dolshnost.Length; num77++)
				{
					if (GlobalScript.inst.gameState.politics_dolshnost[num77] == 150)
					{
						GlobalScript.inst.gameState.politics_dolshnost[num77] = (byte)GlobalScript.inst.gameState.faction_leader[3];
					}
					else if (GlobalScript.inst.gameState.politics_dolshnost[num77] == (byte)GlobalScript.inst.gameState.faction_leader[3])
					{
						array21[num77] = 150;
					}
				}
				for (int num78 = 0; num78 < array21.Length; num78++)
				{
					if (array21[num78] == 150)
					{
						GlobalScript.inst.gameState.politics_dolshnost[num78] = 150;
					}
				}
				for (int num79 = 0; num79 < GlobalScript.inst.gameState.politics.Length; num79++)
				{
					GlobalScript.inst.gameState.CalcRel(num79);
					GlobalScript.inst.gameState.CalcRel2(num79);
					GlobalScript.inst.gameState.CalcRelLeader(num79);
				}
				party_change[2] = 3f;
				party_change[3] = 4f;
				party_change[4] = 2.5f;
				GlobalScript.inst.gameState.party_ideology[0] -= (int)((float)GlobalScript.inst.gameState.party_ideology[0] * 0.15f);
				GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.15f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic152 in politics)
				{
					if (politic152.traits[0] == 0)
					{
						Politic politic = politic152;
						politic.power -= 200;
					}
					else if (politic152.traits[0] == 1)
					{
						Politic politic = politic152;
						politic.power += 100;
					}
					else if (politic152.traits[0] == 2)
					{
						Politic politic = politic152;
						politic.power += 200;
					}
					else if (politic152.traits[0] == 3)
					{
						Politic politic = politic152;
						politic.power += 80;
					}
				}
				if (GlobalScript.inst.gameState.modifies[59].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.modifies[60].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.modifies[61].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = false;
					GlobalScript.inst.gameState.modifies[62].active = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Пока вы своей демагогией затягивали заседание, в здание прибыли сотрудники МГБ, которые арестовали большинство участников-реформаторов. Вслед за этим по Китаю прокатилась волна арестов, пропаганды и кадровых перестановок, направленных на травлю реформаторов. Сам " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2] + " сейчас находится под арестом, а власть вам всё же удалось удержать, отстояв свою политику, хотя это и вызвало массовые недовольства в партии и народе.";
				GlobalScript.inst.gameState.data[1] -= 150;
				GlobalScript.inst.gameState.data[3] -= 120;
				GlobalScript.inst.gameState.data[9] -= 150;
				GlobalScript.inst.gameState.data[4] += 150;
				GlobalScript.inst.gameState.data[6] += 30;
				GlobalScript.inst.gameState.KillPerson(GlobalScript.inst.gameState.faction_leader[3]);
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "На нынешнем пленуме ЦК КПК при вашей поддержке и почти всеобщем одобрении (немногочисленные консерваторы почти не оказали сопротивления) было объявлено о начале рыночных реформ и была утверждена т.н. \"Политика реформ и открытости\", подразумевающая выход Китая на мировой рынок и перестройку экономики на рыночных принципах. " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " всё же сумел удержать власть, благодаря тому, что ранее не высказывался очевидным образом против реформ и вовремя перешёл на сторону реформаторов. Однако, сможет ли он дальше её удерживать в ходе реформ?";
				GlobalScript.inst.gameState.data[1] += 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				GlobalScript.inst.gameState.data[89] = 1;
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[3] += 60;
				GlobalScript.inst.gameState.data[6] -= 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				party_change[2] = 3f;
				party_change[3] = 4f;
				party_change[4] = 2.5f;
				GlobalScript.inst.gameState.party_ideology[0] -= (int)((float)GlobalScript.inst.gameState.party_ideology[0] * 0.15f);
				GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.15f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic153 in politics)
				{
					if (politic153.traits[0] == 0)
					{
						Politic politic = politic153;
						politic.power -= 200;
						politic = politic153;
						politic.loyality -= 500;
					}
					else if (politic153.traits[0] == 1)
					{
						Politic politic = politic153;
						politic.power += 100;
						politic = politic153;
						politic.loyality -= 100;
					}
					else if (politic153.traits[0] == 2)
					{
						Politic politic = politic153;
						politic.power += 200;
						politic = politic153;
						politic.loyality += 200;
					}
					else if (politic153.traits[0] == 3)
					{
						Politic politic = politic153;
						politic.power += 80;
						politic = politic153;
						politic.loyality += 70;
					}
				}
				if (GlobalScript.inst.gameState.modifies[59].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.modifies[60].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.modifies[61].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = false;
					GlobalScript.inst.gameState.modifies[62].active = true;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 45)
		{
			text2 = "Реформы и открытость: начало";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = " Было принято решение о снижении роли центрального правительства в управлении госпредприятиями, поощрении местной инициативы на них, активном внедрении рыночных методов хозяйствования и расширении прав частных и кооперативных предприятий.|Недовольство подобной политикой пришло, откуда не ждали: в Албании Энвер Ходжа резко раскритиковал нашу политику за ревизионизм и отход от марксизма, оборвав все свзяи с нами. Что ж, хочет сидеть в изоляции - его право.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				GlobalScript.inst.gameState.data[4] += 50;
				if (GlobalScript.inst.gameState.data[16] == 10)
				{
					GlobalScript.inst.gameState.data[16] = 12;
				}
				else if (GlobalScript.inst.gameState.data[16] <= 14)
				{
					GlobalScript.inst.gameState.data[16]++;
				}
				GlobalScript.inst.gameState.data[89] = 2;
				GlobalScript.inst.gameState.data[92] += 20;
				GlobalScript.inst.gameState.data[6] -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				GlobalScript.inst.gameState.allcountries[20].Torg = false;
				GlobalScript.inst.gameState.allcountries[20].proprc = false;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic154 in politics)
				{
					if (politic154.traits[0] == 1)
					{
						Politic politic = politic154;
						politic.power += 50;
					}
					else if (politic154.traits[0] == 2)
					{
						Politic politic = politic154;
						politic.power += 100;
					}
					else if (politic154.traits[0] == 3)
					{
						Politic politic = politic154;
						politic.power += 50;
					}
				}
				if (GlobalScript.inst.gameState.modifies[59].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.modifies[60].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = true;
					GlobalScript.inst.gameState.modifies[62].active = false;
				}
				else if (GlobalScript.inst.gameState.modifies[61].active)
				{
					GlobalScript.inst.gameState.modifies[59].active = false;
					GlobalScript.inst.gameState.modifies[60].active = false;
					GlobalScript.inst.gameState.modifies[61].active = false;
					GlobalScript.inst.gameState.modifies[62].active = true;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 46)
		{
			text2 = "Новый 1956-й?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Мы никак не отреагировали на венгерские события. Кадар перешёл в наступление на Биску и его сторонников. Кажется их и самого Биску скоро ждёт отставка, а на их место Кадар будет продвигать молодых реформаторов.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря своевременной помощи наших спецслужб, Биску понял, что Андропов его предал, и в срочном порядке при помощи наших агентов изменил планы переворота и выступил практически моментально, изолировав сторонников Кадара силами Рабочей Милиции и проведя внеочередной съезд ЦК ВСРП, где Кадару припомнили его сотрудничество с Имре Надем и первоначальную поддержку восстания 1956-го, а также отход от принципов марксизма и растущий внешний долг страны. Кадар был снят со всех постов и исключён из ВСРП, новым генсеком стал Бела Биску, который начал возвращение экономики в русло центрального планирования, начал чистки против кадаристских реформаторов и также начал проводить более независимую внешнюю политику, уже заключив с нами несколько полезных договоров. СССР, конечно не обрадовался, но поняв, что в Венгрии всё спокойно, ограничился сухими комментариями.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[9] -= 80;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 300;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
				leader.support--;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.allcountries[4].Torg = true;
				GlobalScript.inst.gameState.allcountries[4].prosov = false;
				GlobalScript.inst.gameState.allcountries[4].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[4].SubGosstroy = 16;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Благодаря нашей оперативной информации и поддержке, Биску сумел быстро собрать вокруг себя консервативных коммунистов, сталинистов, националистов и прочих недовольных политикой Кадара и вывел своих сторонников на уличные демонстрации, одновременно с помощью Рабочей Милиции захватив контроль над административными зданиями и арестовав Кадара и его сторонников. Однако на этом уличные выступления не прекратились. Ощущая нестабильность своей власти Биску пытался то утихомирить демонстрантов, к которым уже начали присоединяться и антисоветские элементы, то использовать их в своих интересах. СССР же бомбардировал Будапешт призывами навести в стране порядок и восстановить законность. Однако, устав от бесплодных переговоров и видя, что Биску всё больше склоняется на получения прямой поддержки Китая с возможностью выхода из ОВД, СССР ввёл в Венгрию войска, которые арестовали неудавшихся путчистов, освободили прежнее руководство и успокоили народ. Решив больше не рисковать, советское руководство не стало возвращать Кадара на пост генсека (он ушёл на пенсию по состоянию здоровья), а поставило туда просоветского умеренного Яноша Папа, который начал возвращение советской плановой системы и сокращение связей с Западом, проводя всё более просоветскую политику.";
				GlobalScript.inst.gameState.data[1] -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 15;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 150;
				GlobalScript.inst.gameState.data[9] -= 30;
				GlobalScript.inst.gameState.data[22] -= 10;
				GlobalScript.inst.gameState.data[6] += 40;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 10;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
				leader.support -= 2;
				GlobalScript.inst.gameState.data[112]++;
				GlobalScript.inst.gameState.allcountries[4].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[4].SubGosstroy = 16;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Благодаря тому, что мы сообщили ему о предательстве Андропова, Биску понял, что в Венгрии его ждёт в лучшем случае отставка с запретом на критику курса Кадара. Он решил воспользоваться нашим предложением и вместе с семьёй и пожелавшими последовать за ним сторонниками бежал в Китай, где начал широко критиковать венгерский и даже иногда советский ревизионизм в наших СМИ. Это заставило наш народ задуматься и увеличило наше влияние в глазах мирового левого движения, но подпортило наши и без того не лучшие отношения с СССР. В Венгрии же на место ушедших консерваторов продолжают приходить молодые реформаторы при поддержке Кадара.";
				GlobalScript.inst.gameState.data[1] += 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 80;
				GlobalScript.inst.gameState.data[6] += 20;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
				GlobalScript.inst.gameState.data[4] -= 40;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Благодаря тому, что мы сообщили ему о предательстве Андропова, Биску понял, что в Венгрии его ждёт в лучшем случае отставка с запретом на критику курса Кадара, поэтому он решил осуществить превентивный переворот без какой-либо подготовки и в крайней спешке. В итоге на чрезвычайном съезде ВСРП организованном группой Биску произошла конфронтация нескольких сторон, а фасад монолитности и единогласия партии рухнул. В итоге, несмотря на то, что большинством голосов группа Биску и он сам были исключены из партии за фракционализм, но мы и многие другие газеты коммунистических партий неподконтрольных советскому влиянию успели напечатать статьи о творившемся на съезде. Вследствие этого Кадар был вынужден взять на себя вину в случившемся позоре для целой партии и поспособствовал передаче власти перспективному, по его мнению, молодому коммунисту Карой Гросу. Придя к власти и не имея достаточного веса Грос пытается сформировать коллективное руководство ВСРП нацеленное на умеренные постепенные реформы. Секретарём по идеологии становится видный партийный реформатор Имре Пожгаи. Формально не посягая на идеологические основы, Пожгаи постепенно смягчал идеологический контроль, допускал некоторые общественные дискуссии и инициативы и этим завоёвывал популярность, прежде всего в интеллигентской среде. В то же время сам Карой Грос активно занялся борьбой с экономическими проблемами и для этого Венгрия вступила в МВФ (ради очередного кредита, несмотря на протесты Москвы, став первой страной СЭВ вступившей в МВФ), были легализованы малый бизнес и совместные предприятия государства и иностранных корпораций. Венгрия начала идти новым курсом...";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 5;
				GlobalScript.inst.gameState.data[9] -= 80;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 150;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
				leader.support++;
				GlobalScript.inst.gameState.allcountries[4].Torg = true;
				GlobalScript.inst.gameState.allcountries[4].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[4].SubGosstroy = 15;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 47)
		{
			text2 = "Пекинская весна";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "МГБ и полиция по старинке начали срывать дацзыбао и выискивать подпольные \"самиздаты\", а в КПК вновь прошла волна чисток от реформаторов (которая впрочем прошла не так гладко из-за засилья самих реформаторов во многих структурах КПК). Народ и реформаторы само собой недовольны, но волна выражения протестов прекратилась. Надеемся, теперь недовольные не перейдут к более радикальным действиям.";
				GlobalScript.inst.gameState.data[1] -= 80;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[3] -= 80;
				GlobalScript.inst.gameState.data[6] += 10;
				GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.05f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic155 in politics)
				{
					if (politic155.traits[0] == 2)
					{
						Politic politic = politic155;
						politic.power -= 100;
						politic = politic155;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Подконтрольные нам СМИ занялись активным выпуском наших статей, опровергающих тезисы реформаторов, а в залах заседаний КПК вновь разгорелись споры между левым и правым крылом. Разумеется реформаторы также ответили выпуском новых статей и журналов. Население с интересом следило за вашей полемикой, и хотя из-за популизма реформаторов симпатии большинства остались на их стороне, у вашей позиции также нашлись свои сторонники. Впрочем сам факт подобного широкого обсуждения политических вопросов (впервые со времён кампании \"Ста цветов\") укрепил уверенность народа в неотвратимости демократических перемен. Кто знает, чем это обернётся...";
				GlobalScript.inst.gameState.data[1] += 30;
				GlobalScript.inst.gameState.data[4] += 80;
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[6] -= 10;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic156 in politics)
				{
					if (politic156.traits[0] == 2)
					{
						Politic politic = politic156;
						politic.power += 50;
						politic = politic156;
						politic.loyality += 50;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Особой реакции с вашей стороны не последовало. Перепалки между левым и правым крылом по большей части не выходят за стены залов заседаний КПК, наши СМИ продолжают выступать в вашу поддержку и критиковать реформаторов и тезисы их сторонников (получается у них не особо хорошо), а студенты продолжают развешивать дацзыбао. Что ж, хотя бы масштабного недовольства не видно.";
				GlobalScript.inst.gameState.data[1] -= 80;
				GlobalScript.inst.gameState.data[4] += 120;
				GlobalScript.inst.gameState.data[3] -= 60;
				party_change[3] = 1f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic157 in politics)
				{
					if (politic157.traits[0] == 2)
					{
						Politic politic = politic157;
						politic.power += 150;
						politic = politic157;
						politic.loyality += 50;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 53)
		{
			text2 = "Реформа сельского хозяйства";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Было решено не ломать то, что и так работает. Проблема лишь в том, что работает оно крайне плохо - ситуация в сельском хозяйстве не лучшая, что пагубно сказывается на уровне жизни населения и его довольстве.";
				GlobalScript.inst.gameState.data[1] -= 80;
				GlobalScript.inst.gameState.data[13] -= 100;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[3] -= 70;
				GlobalScript.inst.gameState.data[5] -= 50;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic158 in politics)
				{
					Politic politic = politic158;
					politic.loyality -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Было решено распустить коммуны и распределить землю между независимыми семейными хозяйствами, которые обязаны будут продавать государству указанный объём урожая по фиксированным ценам. Это подстегнуло рост нашей экономики, способствовало увеличению продовольственных поставок, да и народу понравилось.";
				GlobalScript.inst.gameState.data[1] -= 150;
				GlobalScript.inst.gameState.data[13] += 50;
				GlobalScript.inst.gameState.data[92] += 10;
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[5] += 50;
				party_change[2] = 0.8f;
				party_change[3] = 0.8f;
				GlobalScript.inst.gameState.data[26] += 15;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic159 in politics)
				{
					if (politic159.traits[0] == 1)
					{
						Politic politic = politic159;
						politic.power += 120;
						politic = politic159;
						politic.loyality += 100;
					}
					else if (politic159.traits[0] == 2)
					{
						Politic politic = politic159;
						politic.power += 120;
						politic = politic159;
						politic.loyality += 100;
					}
				}
				GlobalScript.inst.gameState.modifies[59].active = false;
				GlobalScript.inst.gameState.modifies[60].active = false;
				GlobalScript.inst.gameState.modifies[61].active = true;
				GlobalScript.inst.gameState.modifies[62].active = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "После долгих споров с консервативной и даже умеренной частью Политбюро реформаторам всё же удалось убедить КПК ввести частное землевладение взамен распускающихся коммун. Новым фермерам были выданы кредиты на закупку техники и инвентаря, а также они были обязаны продавать часть урожая государству, оставшееся же могут продавать по свободным ценам на рынках. Это позволило улучшить производительность и пополнить казну за счёт налогов и сборов с молодых частников, но не все в партии довольны таким решением, да и новые частники уже начинают спекулировать на ценах, а народ ждёт продолжения реформ.";
				GlobalScript.inst.gameState.data[1] -= 70;
				GlobalScript.inst.gameState.data[92] += 30;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[3] += 70;
				GlobalScript.inst.gameState.data[6] -= 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 30;
				GlobalScript.inst.gameState.data[8] += 40;
				GlobalScript.inst.gameState.data[57] -= 30;
				party_change[2] = 0.3f;
				party_change[3] = 1f;
				GlobalScript.inst.gameState.data[26] += 30;
				party_change[4] += 0.8f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic160 in politics)
				{
					if (politic160.traits[0] == 0)
					{
						Politic politic = politic160;
						politic.power -= 100;
						politic = politic160;
						politic.loyality -= 250;
					}
					else if (politic160.traits[0] == 2)
					{
						Politic politic = politic160;
						politic.power += 150;
						politic = politic160;
						politic.loyality += 100;
					}
					else if (politic160.traits[0] == 3)
					{
						Politic politic = politic160;
						politic.power += 150;
						politic = politic160;
						politic.loyality += 200;
					}
				}
				GlobalScript.inst.gameState.modifies[59].active = false;
				GlobalScript.inst.gameState.modifies[60].active = false;
				GlobalScript.inst.gameState.modifies[61].active = false;
				GlobalScript.inst.gameState.modifies[62].active = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Было решено вспомнить сталинскую практику коллективных хозяйств, благо особой коллективизации проводить нам не надо - большинство колхозов были созданы на базе реорганизованных коммун. Теперь наше сельское хозяйство состоит из множества подконтрольных государству артелей, которые обязаны продавать ему часть урожая по установленным ценам, а остатки могут по более свободным ценам продавать на рынках. Началась также массовая постройка и оснащение машинно-тракторных станций, которые должны будут обеспечить колхозы техникой. Это в итоге помогло нам преодолеть техническую отсталость и в перспективе сулит рост производительности, однако на эти мероприятия пришлось раскошелиться.";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[8] -= 50;
				GlobalScript.inst.gameState.data[13] += 50;
				GlobalScript.inst.gameState.data[3] += 70;
				GlobalScript.inst.gameState.data[5] += 30;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				if (!GlobalScript.inst.gameState.science[0])
				{
					GlobalScript.inst.gameState.science[0] = true;
				}
				else if (!GlobalScript.inst.gameState.science[1])
				{
					GlobalScript.inst.gameState.science[1] = true;
				}
				else if (!GlobalScript.inst.gameState.science[2])
				{
					GlobalScript.inst.gameState.science[2] = true;
				}
				GlobalScript.inst.gameState.modifies[15].active = false;
				GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.09f);
				GlobalScript.inst.gameState.party_ideology[3] -= (int)((float)GlobalScript.inst.gameState.party_ideology[3] * 0.5f);
				GlobalScript.inst.gameState.party_ideology[4] -= (int)((float)GlobalScript.inst.gameState.party_ideology[4] * 0.24f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic161 in politics)
				{
					if (politic161.traits[0] == 0)
					{
						Politic politic = politic161;
						politic.power += 120;
						politic = politic161;
						politic.loyality += 150;
					}
					else if (politic161.traits[0] == 1)
					{
						Politic politic = politic161;
						politic.power -= 80;
						politic = politic161;
						politic.loyality -= 100;
					}
					else if (politic161.traits[0] == 2)
					{
						Politic politic = politic161;
						politic.power -= 100;
						politic = politic161;
						politic.loyality -= 150;
					}
					else if (politic161.traits[0] == 3)
					{
						Politic politic = politic161;
						politic.power -= 150;
						politic = politic161;
						politic.loyality -= 200;
					}
				}
				GlobalScript.inst.gameState.modifies[59].active = false;
				GlobalScript.inst.gameState.modifies[60].active = true;
				GlobalScript.inst.gameState.modifies[61].active = false;
				GlobalScript.inst.gameState.modifies[62].active = false;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 54)
		{
			text2 = "Реформы и открытость: инвестиции";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Несмотря на многочисленные протесты и обвинения в торможении реформ, " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " всё же решил пока отложить вопрос инвестиций \"дабы лучше и качественнее проработать решения по этому вопросу\". ";
				GlobalScript.inst.gameState.data[1] -= 150;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[4] += 80;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic162 in politics)
				{
					if (politic162.traits[0] == 1)
					{
						Politic politic = politic162;
						politic.loyality -= 200;
					}
					else if (politic162.traits[0] == 2)
					{
						Politic politic = politic162;
						politic.loyality -= 200;
					}
					else if (politic162.traits[0] == 3)
					{
						Politic politic = politic162;
						politic.loyality -= 200;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Было заявлено о постепенном открытии некоторых городов на побережье для зарубежных инвестиций. Специальные экономические зоны вскоре будут открыты в Шэньчжэне, Чжухае и Шаньтоу в провинции Гуандун и в Сямыне (провинция Фуцзянь), а также вся провинция Хайнань будет превращена в специальную экономическую зону. США и страны Западной Европы горячо приветствовали это решение, как и главы крупных западных компаний.";
				GlobalScript.inst.gameState.data[89] = 3;
				GlobalScript.inst.gameState.data[8] += 30;
				GlobalScript.inst.gameState.data[92] += 10;
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[6] -= 20;
				GlobalScript.inst.gameState.data[57] -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				party_change[2] = 0.8f;
				party_change[3] = 0.8f;
				GlobalScript.inst.gameState.SEZ = true;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic163 in politics)
				{
					if (politic163.traits[0] == 1)
					{
						Politic politic = politic163;
						politic.power += 120;
						politic = politic163;
						politic.loyality += 100;
					}
					else if (politic163.traits[0] == 2)
					{
						Politic politic = politic163;
						politic.power += 120;
						politic = politic163;
						politic.loyality += 150;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Несмотря на протесты части реформаторов и умеренных в итоге было принято решение о полном открытии китайской экономики для иностранных инвестиций. В соответствии с планом специальные экономические зоны вскоре будут открыты в Шэньчжэне, Чжухае и Шаньтоу в провинции Гуандун и в Сямыне (провинция Фуцзянь), а также вся провинция Хайнань будет превращена в специальную экономическую зону. Вместе с этим большинство государственных предприятий также открываются для зарубежного финансирования по плану создания совместных предприятий. И хотя непосредственно разворачивать свою деятельность иностранные компании могут только в СЭЗ, уже можно говорить о скором быстром проникновении иностранного капитала в нашу экономику, ведь Запад уже с большим энтузиазмом воспринял наши преобразования.";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[92] += 20;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[3] += 30;
				GlobalScript.inst.gameState.data[6] -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 150;
				GlobalScript.inst.gameState.data[8] += 50;
				GlobalScript.inst.gameState.data[89] = 3;
				GlobalScript.inst.gameState.data[57] -= 70;
				GlobalScript.inst.gameState.SEZ = true;
				party_change[3] = 0.5f;
				party_change[4] = 0.8f;
				GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.09f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic164 in politics)
				{
					if (politic164.traits[0] == 0)
					{
						Politic politic = politic164;
						politic.power -= 100;
						politic = politic164;
						politic.loyality -= 250;
					}
					else if (politic164.traits[0] == 1)
					{
						Politic politic = politic164;
						politic.power -= 50;
						politic = politic164;
						politic.loyality -= 80;
					}
					else if (politic164.traits[0] == 2)
					{
						Politic politic = politic164;
						politic.power += 100;
						politic = politic164;
						politic.loyality += 50;
					}
					else if (politic164.traits[0] == 3)
					{
						Politic politic = politic164;
						politic.power += 150;
						politic = politic164;
						politic.loyality += 200;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 55)
		{
			text2 = "Бирманский путь к социализму";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "В БПСП прошли массовые чистки против коммунистов и сочувствующих, что ещё больше укрепило режим У Не Вина.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Прошла встреча представителей КНР и Бирмы, где был подписан ряд договоров и намечен вектор развития отношений. Нами также была выделена дополнительная помощь на восстановление бирманской экономики. Тем временем в БПСП прошли массовые чистки против коммунистов и сочувствующих, что ещё больше укрепило режим У Не Вина.";
				GlobalScript.inst.gameState.data[8] -= 30;
				GlobalScript.inst.gameState.data[6] += 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				GlobalScript.inst.gameState.allcountries[33].Torg = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Благодаря вмешательству наших спецслужб левому крылу БПСП удалось организовать внутрипартийный переворот. Наши же спецслужбы сумели не допустить вмешательства лояльной У Не Вину армии. Сам же бывший диктатор был обвинён в нарушении принципов демократического централизма, заключён в тюрьму и вскоре таинственным образом скончался. Новое правительство начало масштабные социалистические реформы и выход из изоляции через построение дружеских отношений с социалистическими странами, включая КНР.";
				GlobalScript.inst.gameState.data[9] -= 40;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.data[8] -= 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 80;
				GlobalScript.inst.gameState.allcountries[33].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[33].SubGosstroy = 1;
				GlobalScript.inst.gameState.allcountries[33].Torg = true;
				GlobalScript.inst.gameState.allcountries[33].proprc = true;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 56)
		{
			text2 = "Преподать Вьетнаму урок?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Вам удалось утихомирить КПК, хоть и не без недовольства. Всё идёт как было, а Вьетнам продолжает сближение с СССР.";
				GlobalScript.inst.gameState.data[1] -= 150;
				GlobalScript.inst.gameState.vietnampeace = true;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Было принято решение о подготовке вторжения во Вьетнам. 17 февраля в 4:30 подразделения НОАК перешли границу и после тяжёлых боёв захватили приграничные районы, сломив вьетнамское сопротивление. Однако оправившиеся вьетнамские войска теперь переходят в яростные контратаки. Надеемся, у нас хватит сил для выполнения нашего плана.";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.war = 1;
				GlobalScript.inst.gameState.data[39] = 200;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 200;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.data[163] = 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "После многочисленных споров с антисоветски настроенными партийцами вам всё же удалось организовать отправку китайской делегации во Вьетнам. По итогам переговоров нам пришлось отказаться от претензий на некоторые Вьетнамские острова, но удалось добиться прекращения притеснений вьетнамских китайцев с правом свободной эмиграции их в Китай, урегулирования отношений и подписания нескольких торгово-политических договоров. Хотя Вьетнам по-прежнему ориентируется на СССР, наши отношения с ним значительно улучшились, а перспективы сотрудничества - значительно возросли. СССР также с интересом воспринял наши попытки налаживания отношений с соцлагерем.";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.vietnampeace = true;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 200;
				GlobalScript.inst.gameState.allcountries[11].Torg = true;
				gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 40;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 57)
		{
			text2 = "Красное восходящее солнце";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "В итоге ЛДПЯ удалось удержать своё правление, набрав 44% голосов и сыграв на раздробленности оппозиции. Премьер-министр Масаёси Охира продолжил либерально-западнический курс Японии.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря своевременному устранению Кендзи Миямото вернувшаяся под контроль Пекина КПЯ с радостью приняла нашу помощь. Благодаря нашим финансам она смогла наладить эффективную предвыборную агитацию, а наши спецслужбы занялись вбросом компромата на ЛДПЯ и срывом их выступлений. В итоге КПЯ удалось набрать рекордные 31% и сформировать коалицию с социалистами, буддистской Комэйто и различными левоцентристскими оппозиционными партиями. Вскоре были открыты уголовные дела на деятелей ЛДПЯ по обвинениям в коррупции и злоупотреблениях, а также при широкой народной поддержке был принят закон о выходе Японии из военных договоров с США и НАТО и постепенном выводе американских баз из страны.";
				GlobalScript.inst.gameState.data[1] += 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 150;
				GlobalScript.inst.gameState.data[8] -= 40;
				GlobalScript.inst.gameState.data[9] -= 60;
				GlobalScript.inst.gameState.allcountries[44].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[44].SubGosstroy = 8;
				GlobalScript.inst.gameState.allcountries[44].Vyshi = false;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 58)
		{
			text2 = "Иранская революция: финал";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				if (GlobalScript.inst.gameState.data[42] > GlobalScript.inst.gameState.data[43] && GlobalScript.inst.gameState.data[42] > GlobalScript.inst.gameState.data[44] && GlobalScript.inst.gameState.data[42] > GlobalScript.inst.gameState.data[45])
				{
					text = "И им удалось добиться своего: в январе шах вместе с семьёй бежал из страны, передав власть премьер-министру Шапуру Бахтияру из умеренной оппозиции, который сам вскоре был свергнут рабочими протестами. К власти, при поддержке городских рабочих и части военных на волне популярности обещаний о создании социально справедливого государства пришла левая коалиция из различных партий и движений. Вернувшийся в Иран из ссылки Хомейни попытался силами лояльных боевиков устроить восстание, но был быстро схвачен, а поддерживающие его движения - разогнаны. Новая власть объявила о построении социализма с исламской спецификой (от обычного отличающегося лишь мягкой религиозной политикой), однако, похоже, первой задачей сформированнного Революционного совета станет уничтожение исламской и демократической оппозиции, недовольной итогами революции.";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					GlobalScript.inst.gameState.allcountries[8].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[8].SubGosstroy = 1;
					GlobalScript.inst.gameState.allcountries[8].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[8].isSENTO = false;
					GlobalScript.inst.gameState.allcountries[8].isASEAN = false;
					if (GlobalScript.inst.gameState.allcountries[8].dev == 1)
					{
						GlobalScript.inst.gameState.allcountries[8].Torg = true;
					}
					GlobalScript.inst.gameState.data[143] += 10;
				}
				else if (GlobalScript.inst.gameState.data[43] > GlobalScript.inst.gameState.data[42] && GlobalScript.inst.gameState.data[43] > GlobalScript.inst.gameState.data[44] && GlobalScript.inst.gameState.data[43] > GlobalScript.inst.gameState.data[45])
				{
					text = "Однако при нашей и американской активной поддержке Пехлеви удалось силами САВАК и армии подавить выступления, уничтожив главных лидеров оппозиции и внеся разлад в её ряды. На самого Хомейни в Париже было совершено покушение, которое он пережил, но вынужден был залечь на дно и пока не давал о себе знать. Впрочем, теперь, когда самые радикальные протестующие были разгромлены, шах пошёл на уступки - было сформировано новое правительство, уменьшен контроль за мусульманскими священниками, смягчена цензура, уменьшен размах репрессий и проведены показательные аресты коррупционеров из высших эшелонов власти.";
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 10;
					GlobalScript.inst.gameState.allcountries[8].dev = 0;
					if (GlobalScript.inst.gameState.allcountries[8].dev == 0)
					{
						GlobalScript.inst.gameState.allcountries[8].Torg = true;
					}
					GlobalScript.inst.gameState.data[143] -= 7;
				}
				else if (GlobalScript.inst.gameState.data[44] > GlobalScript.inst.gameState.data[42] && GlobalScript.inst.gameState.data[44] > GlobalScript.inst.gameState.data[43] && GlobalScript.inst.gameState.data[44] > GlobalScript.inst.gameState.data[45])
				{
					text = "И им удалось добиться своего: в январе шах вместе с семьёй бежал из страны, передав власть премьер-министру Шапуру Бахтияру из умеренной оппозиции, который приступил к разработке новой конституции и по требованию протестующих, отказавшихся от создания правительства \"национального единства\" провёл свободные выборы, на которых победу одержала, возглавляемая Национальным фронтом Ирана, демократическая коалиция, которая затем успешно подавила выступление исламских радикалов во главе с Хомейни и начала осторожную чистку против исламистов и радикальных левых, недовольных таким итогом. Сформированное новое правительство объявило о своей верности принципам ислама и демократии и нацелилось на развитие страны по образцу кемалистской Турции, проводя при этом многовекторную внешнюю политику.";
					GlobalScript.inst.gameState.allcountries[8].Gosstroy = 3;
					GlobalScript.inst.gameState.allcountries[8].SubGosstroy = 5;
					GlobalScript.inst.gameState.allcountries[8].Vyshi = false;
					if (GlobalScript.inst.gameState.allcountries[8].dev == 2)
					{
						GlobalScript.inst.gameState.allcountries[8].Torg = true;
					}
					GlobalScript.inst.gameState.data[143] -= 5;
				}
				else
				{
					text = "И им удалось добиться своего: в январе шах вместе с семьёй бежал из страны, передав власть премьер-министру Шапуру Бахтияру из умеренной оппозиции, который приступил к разработке новой конституции и пригласил в страну опального аятоллу Хомейни, за что вскоре и поплатился. Не собиравшийся сотрудничать с новым правительством Хомейни с помощью своих многочисленных сторонников организовал новое восстание, быстро охватившее Тегеран. Полиция перешла на сторону бунтовщиков, а генералы объявили нейтралитет, в результате чего Бахтияр бежал из страны. Новое правительство Хомейни провозгласило Иран исламской республикой и развернуло жестокие репрессии против вчерашних союзников.";
					GlobalScript.inst.gameState.allcountries[8].Vyshi = false;
					GlobalScript.inst.gameState.allcountries[8].isSENTO = false;
					GlobalScript.inst.gameState.allcountries[8].SubGosstroy = 9;
					if (GlobalScript.inst.gameState.allcountries[8].dev == 3)
					{
						GlobalScript.inst.gameState.allcountries[8].Torg = true;
					}
					GlobalScript.inst.gameState.data[143] += 10;
				}
				GlobalScript.inst.gameState.iranrev = false;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 59)
		{
			text2 = "Экономический союз";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "И ничего не произошло, надеюсь, это только к лучшему.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Сегодня, по инициативе КНР, в Пекине было созвано закрытое экономическое совещание, которое приняло постановление об учреждении Организации экономического сотрудничества (ОЭС), цель которого - расширение торгово-экономических контактов между дружескими Китаю странами. Членами-основателями нового альянса стали Китай";
				GlobalScript.inst.gameState.data[1] += 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 30;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GlobalScript.inst.gameState.data[3] += 80;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[8] -= 150;
				GlobalScript.inst.gameState.allcountries[1].econ = true;
				GlobalScript.inst.gameState.allcountries[1].soc_stab = 1000;
				for (int num80 = 7; num80 < GlobalScript.inst.gameState.allcountries.Length; num80++)
				{
					if ((num80 < 53 || num80 > 103) && num80 != 52 && num80 != 35 && num80 != 40 && num80 != 30 && num80 != 14 && num80 != 13 && num80 != 36 && num80 != 16 && num80 != 3 && num80 != 5 && num80 != 15 && num80 != 27 && num80 != 106 && num80 != 107 && num80 != 108 && GlobalScript.inst.gameState.allcountries[num80].proprc && !GlobalScript.inst.gameState.allcountries[num80].Vyshi && !GlobalScript.inst.gameState.allcountries[num80].prosov)
					{
						GlobalScript.inst.gameState.allcountries[num80].soc_stab = 1000;
						text = text + ", " + GlobalScript.inst.gameState.allcountries[num80].name;
						GlobalScript.inst.gameState.allcountries[num80].econ = true;
					}
				}
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic165 in politics)
				{
					if (politic165.traits[0] == 0)
					{
						Politic politic = politic165;
						politic.loyality += 100;
					}
					else if (politic165.traits[0] == 1)
					{
						Politic politic = politic165;
						politic.loyality += 100;
					}
					else if (politic165.traits[0] == 2)
					{
						Politic politic = politic165;
						politic.loyality += 100;
					}
					else if (politic165.traits[0] == 3)
					{
						Politic politic = politic165;
						politic.loyality += 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Продолжая линию на «перезагрузку отношений с СССР», Китай подал заявку на членство в Совет экономический взаимопомощи. Данная инициатива, по задумке, должна возродить и приумножить экономические контакты между КНР и странами социализма, которые были разорваны во время «советско-китайского раскола». Специально для этого была созвана внеочередная сессия СЭВ, в результате которой, Китай был принят в союз, как полноправный член организации. Наиболее радикальные партийцы «восприняли этот шаг в штыки», назвав «потакательством советским ревизионистам», однако, сейчас наши отношения с СССР стали лучше, чем когда-либо. Чего не скажешь о США, которые остались недовольны сменой вектора нашей внешней политики. Впрочем, сейчас социалистический лагерь силён как никогда прежде.";
				GlobalScript.inst.gameState.data[1] -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 200;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 200;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 30;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.allcountries[1].isSEV = true;
				GlobalScript.inst.gameState.allcountries[1].stab = 1;
				GlobalScript.inst.gameState.allcountries[1].stab = 1;
				if (GlobalScript.inst.gameState.data[60] == 0)
				{
					GlobalScript.inst.gameState.allcountries[20].proprc = false;
					GlobalScript.inst.gameState.allcountries[20].econ = false;
					GlobalScript.inst.gameState.allcountries[20].Torg = false;
					GlobalScript.inst.gameState.allcountries[20].okb = false;
				}
				GlobalScript.inst.gameState.allcountries[52].proprc = false;
				GlobalScript.inst.gameState.allcountries[52].econ = false;
				GlobalScript.inst.gameState.allcountries[52].okb = false;
				Country[] allcountries = GlobalScript.inst.gameState.allcountries;
				foreach (Country country8 in allcountries)
				{
					if (country8.econ && (country8.prosov || country8.sovalliance || country8.proprc || country8.Gosstroy == 1 || (country8.Gosstroy == 2 && !country8.usalliance && !country8.Vyshi)))
					{
						country8.econ = false;
						country8.isSEV = true;
					}
					else
					{
						country8.econ = false;
					}
				}
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic166 in politics)
				{
					if (politic166.traits[0] == 2)
					{
						Politic politic = politic166;
						politic.loyality -= 200;
					}
					else if (politic166.traits[0] == 3)
					{
						Politic politic = politic166;
						politic.loyality -= 200;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Правительство Китая подало заявку на членство в «Движении неприсоединения» и безо всяких вопросов Китай был принят в организацию большинство голосов. Теперь, если нам заблагорассудиться решить какой-либо конфликт военным путём, мы будем осуждены и изгнаны из организации. Стратегический нейтралитет позволит нам лавировать между Советским союзом и США, получая преференции от обеих сверхдержав, что нам, впрочем, только на руку.";
				GlobalScript.inst.gameState.data[1] -= 300;
				GlobalScript.inst.gameState.data[8] -= 20;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				GlobalScript.inst.gameState.allcountries[15].cw = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Правительство Китая подало заявку на членство в «Ассоциация государств Юго-Восточной Азии», и безо всяких вопросов Китай был принят в организацию большинством голосов. Вступление Китая в АСЕАН должно улучшить отношения Китая с соседними странами и Западным блоком. В связи с присоединением страны, которая не находится полностью в Юго-Восточной Азии в название союза было добавлена новая аббревиатура - «Ассоциация Азиатских государств» (ААН).";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 350;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 350;
				GlobalScript.inst.gameState.allcountries[1].JoinASEAN();
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 60)
		{
			text2 = "Военный альянс";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Сегодня в Шанхае был подписан договор о создании Альянса Коллективной безопасности (АКБ) – военно-политической организации, объединившей все союзнические Китаю страны в единый военный блок. Целью АКБ является создание общей системы коллегиальной защиты от других военных альянсов – ОВД и НАТО. Членами новообразованной организации стали КНР";
				GlobalScript.inst.gameState.data[1] += 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 200;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 200;
				GlobalScript.inst.gameState.data[3] += 80;
				GlobalScript.inst.gameState.data[8] -= 50;
				GlobalScript.inst.gameState.data[9] -= 100;
				GlobalScript.inst.gameState.data[22] -= 300;
				GlobalScript.inst.gameState.allcountries[15].cw = false;
				GlobalScript.inst.gameState.allcountries[1].okb = true;
				for (int num81 = 7; num81 < GlobalScript.inst.gameState.allcountries.Length; num81++)
				{
					if (!GlobalScript.inst.gameState.allcountries[num81].proprc && !GlobalScript.inst.gameState.allcountries[num81].econ)
					{
						continue;
					}
					switch (num81)
					{
					case 3:
					case 5:
					case 13:
					case 14:
					case 15:
					case 16:
					case 27:
					case 30:
					case 35:
					case 36:
					case 40:
					case 45:
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
					case 69:
					case 70:
					case 71:
					case 72:
					case 73:
					case 74:
					case 75:
					case 76:
					case 77:
					case 78:
					case 79:
					case 80:
					case 81:
					case 82:
					case 83:
					case 84:
					case 85:
					case 86:
					case 87:
					case 88:
					case 89:
					case 90:
					case 91:
					case 92:
					case 93:
					case 94:
					case 95:
					case 96:
					case 97:
					case 98:
					case 99:
					case 100:
					case 101:
					case 102:
					case 103:
					case 106:
					case 107:
					case 108:
						continue;
					}
					if (!GlobalScript.inst.gameState.allcountries[num81].Vyshi && !GlobalScript.inst.gameState.allcountries[num81].prosov)
					{
						if (GlobalScript.inst.gameState.allcountries[num81].soc_stab <= 0)
						{
							GlobalScript.inst.gameState.allcountries[num81].soc_stab = 1000;
						}
						text = text + ", " + GlobalScript.inst.gameState.allcountries[num81].name;
						GlobalScript.inst.gameState.allcountries[num81].okb = true;
						if (GlobalScript.inst.gameState.allcountries[num81].isSEV)
						{
							GlobalScript.inst.gameState.allcountries[num81].isSEV = false;
							GlobalScript.inst.gameState.allcountries[num81].econ = true;
						}
					}
				}
				text += ". СССР и США отрицательно отнеслись к расширению влияния Китая, назвав новый блок «препятствием для разрядки международной напряжённости» и «разрушителем мирного сосуществования». В свою очередь, партия и народ восприняли рост престижа КНР с восторгом и восхищением. Кажется, на международной арене появляется третья сила, надеюсь это только к лучшему.";
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic167 in politics)
				{
					if (politic167.traits[0] == 0)
					{
						Politic politic = politic167;
						politic.loyality += 100;
					}
					else if (politic167.traits[0] == 1)
					{
						Politic politic = politic167;
						politic.loyality += 100;
					}
					else if (politic167.traits[0] == 2)
					{
						Politic politic = politic167;
						politic.loyality += 100;
					}
					else if (politic167.traits[0] == 3)
					{
						Politic politic = politic167;
						politic.loyality += 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Китай продолжает находиться вне военных альянсов. Мир на Земле – превыше всего.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 61)
		{
			text2 = "Проблема гимна";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "По радио было зачитано Постановление ПК ВСНП об восстановлении \"Марша добровольцев\" в качестве гимна КНР. Одновременно был принят Закон, регулирующий использование гимна (им каждый день начинается вещание радио и телевидения, под звуки гимна поднимается Государственный флаг КНР, начинают свою работу Сессия ВСНП и Съезд КПК и т.д.). Партия довольна, как и народ.";
				GlobalScript.inst.gameState.data[8] -= 10;
				GlobalScript.inst.gameState.data[3] += 20;
				GlobalScript.inst.gameState.data[1] += 70;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic168 in politics)
				{
					if (politic168.traits[0] == 1)
					{
						Politic politic = politic168;
						politic.power += 50;
					}
					else if (politic168.traits[0] == 2)
					{
						Politic politic = politic168;
						politic.power += 50;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Сегодня \"Радио Пекина\" начало вещание, как и 10 лет назад, с песни \"Алеет Восток\", после чего было зачитано Постановление ПК ВСНП об утверждении её гимном КНР. Народ, в целом, очень доволен, однако партийцы встретили это решение непониманием и обвиняют нас в \"леворадикальном уклоне\" и \"попытке ползучей переоценки Культурной революции\". СССР и США также недовольны, но предпочли об этом не заявлять.";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[6] += 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GlobalScript.inst.gameState.data[3] += 40;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic169 in politics)
				{
					if (politic169.traits[0] == 0)
					{
						Politic politic = politic169;
						politic.power += 50;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Сегодня вещание \"Радио Пекина\" началось с \"Марша добровольцев\", однако с измененным текстом, в котором воспевается \"великая Компартия\", \"коммунистическое будущее\" и \"знамя Мао Цзэдуна\". В таком варианте, он был утвержден гимном КНР. Это вызвало определенное недовольство в партии, хотя народ, в целом, новые слова принял.";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[6] += 5;
				GlobalScript.inst.gameState.data[8] -= 10;
				GlobalScript.inst.gameState.data[3] += 10;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 62)
		{
			text2 = "Проблемы наследников Чингисхана";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Сегодня вышло совместное решение ПК ВСНП и ЦК КПК, согласно которому все территории АР Внутренняя Монголия, переданные в 1969 году в состав соседних провинций КНР, возвращаются в его состав. Также прекращается политика ассимиляции монголов, гарантируется защита их национальной культуры, традиционного уклада жизни и народного хозяйства. Снова открыты для посещения мавзолей Чингисхана, гробница Ван Чжаоцзюнь, монастырь У Дан и храм Пяти Пагод, возрожден традиционный фестиваль Надом, возобновлен выпуск газеты \"Нэймэнгу жибао\" на монгольском языке. Также было решено, что райком КПК впредь будут возглавлять не китайцы (хань), а монголы. Этот шаг был с воодушевлением встречен в автономном районе и поддержан Монгольской Народной республикой, а за ней - и Советским Союзом, который одобрил изменения в нашей национальной политике. Правда, левое крыло партии считает совсем иначе, да и наш бюджет вынужден взять на себя дополнительные траты.";
				GlobalScript.inst.gameState.data[1] -= 80;
				GlobalScript.inst.gameState.data[57] += 50;
				GlobalScript.inst.gameState.data[4] += 20;
				GlobalScript.inst.gameState.data[3] += 60;
				GlobalScript.inst.gameState.data[6] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 30;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
				GlobalScript.inst.gameState.data[92] += 10;
				GlobalScript.inst.gameState.data[8] -= 30;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Центральные власти не проявили интереса к проблеме Внутренней Монголии. В АР продолжается ассимиляция монгол, в автономию приезжает все больше китайских переселенцев, которые совсем скоро станут большинством её населения. Ситуация ухудшается, а диссиденты монгольского происхождения активно пытаются привлечь внимание США и Советского Союза.";
				GlobalScript.inst.gameState.data[1] -= 20;
				GlobalScript.inst.gameState.data[57] -= 150;
				GlobalScript.inst.gameState.data[3] -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "После долгого колебания, было принято половинчатое решение - возвратить в состав АР Внутренняя Монголия отобранные в 1969 году территории, однако национальную политику оставить без изменений. Это решение было, в целом, встречено нейтрально, хотя и вызвало определенное недовольство среди националистически настроенных партийцев, а также Монгольской Народной республики, обвинившей нас в \"геноциде монгольского населения\" и пытающейся привлечь внимание Советского Союза...";
				GlobalScript.inst.gameState.data[1] += 10;
				GlobalScript.inst.gameState.data[57] += 10;
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.data[3] += 20;
				GlobalScript.inst.gameState.data[6] -= 5;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "После долгого колебания, было принято половинчатое решение - прекратить политику ассимиляции монгольского населения автономии, но не возвращать в её состав территории, изъятые в 1969 году. Снова открыты для посещения мавзолей Чингисхана, гробница Ван Чжаоцзюнь, монастырь У Дан и храм Пяти Пагод, возрожден традиционный фестиваль Надом, возобновлен выпуск газеты \"Нэймэнгу жибао\" на монгольском языке. Это решение было встречено с одобрением, хотя наш бюджет и вынужден понести дополнительные расходы.";
				GlobalScript.inst.gameState.data[1] += 30;
				GlobalScript.inst.gameState.data[8] -= 10;
				GlobalScript.inst.gameState.data[3] += 30;
				GlobalScript.inst.gameState.data[6] -= 5;
				GlobalScript.inst.gameState.data[57] += 30;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Председатель " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", пораженный открывшейся правдой о состоянии дел во Внутренней Монголии, решил более углубленно заняться национальным вопросом и лично посетил все 3 малые автономные района - Внутреннюю Монголию, Гуанси-Чжуанский АР и Нинся-Хуэйский АР. После ряда встреч с партийным и советским руководством этих районов, а также представителями национальных меньшинств (монголами, чжуанами и хуэйцзу), товарищ Председатель возвратился в Пекин в глубоком раздумии, результатом чего стало принятие \"Концепции национальной политики КНР\", которая заменила собой националистические по характеру \"Основные принципы осуществления районной национальной автономии в КНР\" 1952 года. В соответствии с \"Концепцией\", автономные районы получали более широкие права, государство обязалось защищать национальную культуру национальных меньшинств, традиционный уклад жизни и народного хозяйства, увеличить объем издания литературы и печати на национальных языках, выделить квоты для национальных меньшинств во всех органах власти и ВУЗ-ах. Также было принято важное решение - не только советские органы, но и районные автономные комитеты КПК должны возглавлять представители национальных меньшинств. Все это позволило Вам получить искреннюю поддержку национальных элит (надеемся, они не забудут этот жест в случае чего), одобрение СССР и США - но и бешенство консервативно настроенных партийцев...";
				GlobalScript.inst.gameState.data[1] -= 150;
				GlobalScript.inst.gameState.data[8] -= 60;
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[6] -= 20;
				GlobalScript.inst.gameState.data[57] -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 80;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 150;
				GlobalScript.inst.gameState.data[92] += 30;
				GlobalScript.inst.gameState.data[18]++;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 63)
		{
			text2 = "Апрельская революция";
			GlobalScript.inst.gameState.allcountries[12].Gosstroy = 1;
			GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 1;
			GlobalScript.inst.gameState.allcountries[12].prosov = true;
			GlobalScript.inst.gameState.allcountries[12].Vyshi = false;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Мы никак не отреагировали на апрельскую революцию и события в НДПА. Партия, само собой, недовольна такой пассивностью. В ДРА же халькисты, завоевавшие авторитет в ходе революции активно пытаются отобрать у Парчам её долю власти.";
				GlobalScript.inst.gameState.data[1] -= 80;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 30;
				GlobalScript.inst.gameState.data[46] = 10;
				GlobalScript.inst.gameState.data[48] = 150;
				GlobalScript.inst.gameState.data[49] = 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Недовольствуясь таким расширением советского влияния руководство КПК приняло решение оказать посильную поддержку лояльной КНР оппозиции в Афганистане. Партии оружия и агентурная помощь были направлены маоистам, левой оппозиции, умеренным исламистам и прочим оппозиционным силам. Будем надеяться, это сдержит советскую экспансию.";
				GlobalScript.inst.gameState.data[1] += 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 30;
				GlobalScript.inst.gameState.data[9] -= 30;
				GlobalScript.inst.gameState.data[46] = 40;
				GlobalScript.inst.gameState.data[48] = 150;
				GlobalScript.inst.gameState.data[49] = 100;
				GlobalScript.inst.gameState.data[6] -= 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "После долгих споров было решено наладить отношения с новым правительством Афганистана и в особенности с фракцией Хальк в НДПА. Это оказалось проще, чем мы думали, ведь НДПА не принимала участия в советско-китайской полемике и после прихода к власти номинально провозгласила курс на неприсоединение. Халькисты оценили оказанную им поддержку и, по всей видимости используют свою растущую власть для давления на Парчам и для получени монополии на власть в ДРА.";
				GlobalScript.inst.gameState.data[1] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 30;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[46] = 10;
				GlobalScript.inst.gameState.data[48] = 180;
				GlobalScript.inst.gameState.data[49] = 100;
				GlobalScript.inst.gameState.data[6] += 20;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "После долгих споров было решено наладить отношения с новым правительством Афганистана и в особенности с фракцией Парчам в НДПА. Это оказалось проще, чем мы думали, ведь НДПА не принимала участия в советско-китайской полемике и после прихода к власти номинально провозгласила курс на неприсоединение. Благодаря нашей поддержке Парчам удаётся пока преодолевать растущее давление со стороны Хальк, в частности парчамисты совместно с некоторыми халькистами сумели затормозить продвижение по карьерной лестнице Хафизуллы Амина, близкого соратника Тараки, не пользующегося, однако, большим доверием в партии.";
				GlobalScript.inst.gameState.data[1] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 30;
				GlobalScript.inst.gameState.data[9] -= 60;
				GlobalScript.inst.gameState.data[46] = 10;
				GlobalScript.inst.gameState.data[48] = 140;
				GlobalScript.inst.gameState.data[49] = 140;
				GlobalScript.inst.gameState.data[6] += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 48)
		{
			GlobalScript.inst.gameState.allcountries[12].Vyshi = false;
			text2 = "Перевороты продолжаются";
			GlobalScript.inst.gameState.allcountries[12].Gosstroy = 0;
			GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 10;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Придя к власти, Амин развернул масштабные репрессии как против своих нынешних и потенциальных политических оппонентов. Несмотря на заявленный курс на \"уничтожение феодалов\" под горячую руку из населения попали далеко не только они. СССР, похоже, остался недоволен переворотом, хоть и делает вид, что всё нормально.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Придя к власти, Амин развернул масштабные репрессии как против своих нынешних и потенциальных политических оппонентов. Несмотря на заявленный курс на \"уничтожение феодалов\" под горячую руку из населения попали далеко не только они. СССР, похоже, остался недоволен переворотом, хоть и делает вид, что всё нормально. Наши тайные послы и спецслужбы наладили контакты с Амином, который был очень доволен приобретением новых союзников. Впрочем, вместе с тем на нас же он начал сваливать заботы по оказанию материальной помощи Афганистану.";
				GlobalScript.inst.gameState.data[8] -= 20;
				GlobalScript.inst.gameState.data[6] += 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Продолжая нашу большую дружбу с СССР и не особо доверяя Амину, " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " решил, несмотря на протесты отдельных членов ЦК, провести негласные переговоры с СССР по поводу опасности режима Амина для ДРА и необходимости его скорого смещения. Советское руководство очень удивилось такой готовности \"слить\" потенциального союзника и, кажется, не вполне доверяет нам, но в целом очень обрадовалось. Будем ждать дальнейшего развития этих событий. Придя к власти, Амин развернул масштабные репрессии как против своих нынешних и потенциальных политических оппонентов. Несмотря на заявленный курс на \"уничтожение феодалов\" под горячую руку из населения попали далеко не только они. СССР остался недоволен переворотом, хоть и делает вид, что всё нормально.";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[49] = 110;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 70;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 40;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 49)
		{
			text2 = "Против всех тиранов";
			GlobalScript.inst.gameState.allcountries[12].Vyshi = false;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				if (GlobalScript.inst.gameState.data[49] > 150)
				{
					text = "Вечером 27 декабря, предварительно блокировав части кабульского гарнизона и захватив здания Генерального штаба, СССР силами спецподразделений КГБ и армии провёл штурм резиденции Амина, в ходе которого он и погиб (хотя предписывалось взять его живым). При поддержке СССР Афганистан возглавил Асадулла Сарвари, член фракции Хальк и бывший начальник афганских спецслужб, попавший под репрессии Амина. В целом, несмотря на сопротивление отдельных лояльных Амину частей армии, его смещение прошло без проблем. Тем временем ввод и размещение советских войск и продолжается.";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[107] = 9;
					GlobalScript.inst.gameState.data[48] = 150;
					GlobalScript.inst.gameState.data[49] = 100;
					GlobalScript.inst.gameState.allcountries[12].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 1;
				}
				else
				{
					text = "Вечером 27 декабря, предварительно блокировав части кабульского гарнизона и захватив здания Генерального штаба, СССР силами спецподразделений КГБ и армии провёл штурм резиденции Амина, в ходе которого он и погиб (хотя предписывалось взять его живым). При поддержке СССР Афганистан возглавил Бабрак Кармаль, основатель и бессменный лидер фракции Парчам и давний противник Амина. В целом, несмотря на сопротивление отдельных лояльных Амину частей армии, его смещение прошло без проблем. Тем временем ввод и размещение советских войск и продолжается.";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 20;
					GlobalScript.inst.gameState.data[48] = 100;
					GlobalScript.inst.gameState.data[49] = 150;
					GlobalScript.inst.gameState.allcountries[12].Gosstroy = 1;
					GlobalScript.inst.gameState.allcountries[12].SubGosstroy = 1;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря нашему своевременному предупреждению Амин сумел привести лояльные ему части в боевую готовность, а сам покинул резиденцию и укрылся на окраинах Кабула. СССР ещё на первых порах операции понял, что его план провалился, и отозвал спецназ. Лишь благодаря усилиям наших и афганских дипломатов, а также Амина, который старательно делал вид, что ничего не произошло и номинально не изменил политику, удалось избежать крупного международного скандала. Хотя СССР, само собой, всё равно недоволен и начинает стремительно сокращать помощь Афганистану. Ввод советских войск также был замедлен, как и сокращены их задачи. Кажется, со временем они будут полностью выведены вместе с советскими специалистами, так что всю помощь Афганистану в начинающейся гражданской войне нам придётся взять на себя. Тем временем Амин заключил с КНР ряд договоров, а также пригласил маоистов, до недавнего времени находившихся в оппозиции, вступит в НДПА на выгодных условиях и кооптировал их в правительство.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
				GlobalScript.inst.gameState.data[9] -= 70;
				GlobalScript.inst.gameState.data[46] = 100;
				GlobalScript.inst.gameState.data[49] = 180;
				GlobalScript.inst.gameState.data[6] += 50;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 400;
				GlobalScript.inst.gameState.allcountries[12].prosov = false;
				GlobalScript.inst.gameState.allcountries[12].proprc = true;
				GlobalScript.inst.gameState.ingamewars[5].name_war = "Афганская гражданская война";
				GlobalScript.inst.gameState.ingamewars[5].is_going = true;
				GlobalScript.inst.gameState.ingamewars[5].side1 = "ДРА";
				GlobalScript.inst.gameState.ingamewars[5].side2 = "Моджахеды";
				GlobalScript.inst.gameState.ingamewars[5].ussr_place = -1;
				GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[5].infl1 = 500;
				GlobalScript.inst.gameState.ingamewars[5].infl2 = 500;
				if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 100;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 100;
				}
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 50;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 50;
				}
				if (GlobalScript.inst.gameState.data[107] == 9)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 += 25;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 -= 25;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 50)
		{
			text2 = "Проклятый горный дикий край...";
			GlobalScript.inst.gameState.allcountries[12].Vyshi = false;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Мы решили не влезать в афганские дела. В стране тем временем полным ходом разгорается гражданская война, исход которой не может предугадать никто.";
				GlobalScript.inst.gameState.ingamewars[5].name_war = "Афганская гражданская война";
				GlobalScript.inst.gameState.ingamewars[5].is_going = true;
				GlobalScript.inst.gameState.ingamewars[5].side1 = "ДРА";
				GlobalScript.inst.gameState.ingamewars[5].side2 = "Моджахеды";
				GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
				GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[5].infl1 = 750;
				GlobalScript.inst.gameState.ingamewars[5].infl2 = 250;
				if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 100;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 100;
				}
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 50;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 50;
				}
				if (GlobalScript.inst.gameState.data[107] == 9)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 += 25;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 -= 25;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря нашим связям с СССР мы сумели договориться с ДРА. В обмен на нашу поддержку она прекращает преследование маоистов, которые до этого находились в оппозиции, и формирует с ними альянс прогрессивных сил для борьбы с исламизмом и американским империализмом, при условии, что сами маоисты сложат оружие (они нехотя, но согласились). Это наша дипломатическая победа! В стране тем временем полным ходом разгорается гражданская война, исход которой не может предугадать никто.";
				GlobalScript.inst.gameState.data[1] += 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.data[46] = 80;
				GlobalScript.inst.gameState.data[6] += 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 250;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GlobalScript.inst.gameState.ingamewars[5].name_war = "Афганская гражданская война";
				GlobalScript.inst.gameState.ingamewars[5].is_going = true;
				GlobalScript.inst.gameState.ingamewars[5].side1 = "ДРА";
				GlobalScript.inst.gameState.ingamewars[5].side2 = "Моджахеды";
				GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
				GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[5].infl1 = 770;
				GlobalScript.inst.gameState.ingamewars[5].infl2 = 230;
				gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 30;
				if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 100;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 100;
				}
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 50;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 50;
				}
				if (GlobalScript.inst.gameState.data[107] == 9)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 += 25;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 -= 25;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "После долгих обсуждений в Политбюро, где отдельные партийцы упорно протестовали против поддержки просоветского режима ДРА, товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " всё-таки продавил стратегию поддержки ДРА (хотя бы на словах), против которой она определённо не возражала. В стране тем временем полным ходом разгорается гражданская война, исход которой не может предугадать никто.";
				GlobalScript.inst.gameState.data[1] -= 200;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
				GlobalScript.inst.gameState.data[6] += 10;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 300;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
				GlobalScript.inst.gameState.ingamewars[5].name_war = "Афганская гражданская война";
				GlobalScript.inst.gameState.ingamewars[5].is_going = true;
				GlobalScript.inst.gameState.ingamewars[5].side1 = "ДРА";
				GlobalScript.inst.gameState.ingamewars[5].side2 = "Моджахеды";
				GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
				GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[5].infl1 = 760;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 20;
				GlobalScript.inst.gameState.ingamewars[5].infl2 = 240;
				if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 100;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 100;
				}
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 50;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 50;
				}
				if (GlobalScript.inst.gameState.data[107] == 9)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 += 25;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 -= 25;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Опасаясь расширения влияния СССР, мы решили оказать поддержку маоистским организациям Афганистана в их вооружённой борьбе как против ДРА, так и исламистов. Это, естественно, не понравилось ни СССР, ни США, да и афганские маоисты не представляют из себя особо грозной силы, так что на их поддержку уйдёт очень много наших сил... В стране тем временем полным ходом разгорается гражданская война, исход которой не может предугадать никто.";
				GlobalScript.inst.gameState.data[1] += 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 30;
				GlobalScript.inst.gameState.data[6] += 30;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 150;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 150;
				GlobalScript.inst.gameState.ingamewars[5].name_war = "Афганское восстание маоистов";
				GlobalScript.inst.gameState.ingamewars[5].is_going = true;
				GlobalScript.inst.gameState.ingamewars[5].side1 = "Маоисты";
				GlobalScript.inst.gameState.ingamewars[5].side2 = "Остальные";
				GlobalScript.inst.gameState.ingamewars[5].ussr_place = 1;
				GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[5].infl1 = 50;
				GlobalScript.inst.gameState.ingamewars[5].infl2 = 950;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Вскоре, неожиданно быстро состоялся саммит между Соединёнными Штатами и КНР под предлогом «развития торгово-экономического сотрудничества», однако его цель была совершенно иная. На закрытых переговорах , делегация от США предложила Китаю контракт о покупке оружия и его отправке через китайскую границу в соседний Афганистан, чтобы поддержать оппозиционных моджахедов против советской агрессии и нанести серьёзный удар по марионеточному режиму ДРА. Китайская сторона приняла предложение США, первые поставки вооружения планируется развернуть в ближайшие три месяца, впрочем, нам от этого только выгода, все затраты покроет наш новый стратегический союзник.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 30;
				GlobalScript.inst.gameState.ingamewars[5].name_war = "Афганская гражданская война";
				GlobalScript.inst.gameState.ingamewars[5].is_going = true;
				GlobalScript.inst.gameState.ingamewars[5].side1 = "ДРА";
				GlobalScript.inst.gameState.ingamewars[5].side2 = "Моджахеды";
				GlobalScript.inst.gameState.ingamewars[5].ussr_place = 0;
				GlobalScript.inst.gameState.ingamewars[5].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[5].infl1 = 700;
				GlobalScript.inst.gameState.ingamewars[5].infl2 = 300;
				GlobalScript.inst.gameState.data[8] += 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 200;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 200;
				if (GlobalScript.inst.gameState.allcountries[31].Vyshi)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 100;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 100;
				}
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 -= 50;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 += 50;
				}
				if (GlobalScript.inst.gameState.data[107] == 9)
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 += 25;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 -= 25;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 51)
		{
			text2 = "Постоят и уйдут...";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "С высвобождением части своих сил и при помощи советских советников и авиации ДРА развернула относительно успешные боевые действия против исламистов. Пока рано делать прогнозы о будущей победе, однако в отсутствии прямого доступа США к Афганистану у ДРА есть серьёзное преимущество.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Присоединившись к выступлениям западных дипломатов мы также осудили ввод советских войск в Афганистан, назвав это грубым вмешательством в дела суверенного государства. Западные лидеры поддержали наше заявление, советское же руководство никак не отреагировало. С высвобождением части своих сил и при помощи советских советников и авиации ДРА развернула относительно успешные боевые действия против исламистов. Пока рано делать прогнозы о будущей победе, однако в отсутствии прямого доступа США к Афганистану у ДРА есть серьёзное преимущество.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 80;
				GlobalScript.inst.gameState.data[6] -= 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Вопреки раздающимся со всего мира голосам о \"вторжении\" мы решили поддержать ввод советских войск, так как он направлен на обеспечение мира и стабильности в Афганистане и абсолютно правомерен согласно Советско-афганскому договору о дружбе. На западе нас, само собой, обозвали пособниками кровавых режимов, зато СССР поблагодарил за поддержку.";
				GlobalScript.inst.gameState.data[1] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 110;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 52)
		{
			text2 = "Непростое соседство";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Всё идёт как и шло. Пакистанские власти пресекают у себя радикальные проповеди и не дают провозить оружие через КПП на границе, однако на большее у них нет то ли сил, то ли желания, то ли и того и другого.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Прозрачно намекнув Бхутто, что разгул террористов на границе пора прекращать, и выслав ему в помощь своих агентов и военных, мы совместно с Пакистаном начали операции по патрулированию границы и выслеживанию радикальных исламистских групп. Надо сказать, что она увенчалась успехом - исламисты не ожидали столь жёсткой реакции от Пакистана и были застигнуты почти врасплох. Оставшиеся же попрятались и теперь не могут работать с прежней эффективностью. Удачи им в рытье тоннелей под границей.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GlobalScript.inst.gameState.data[6] += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
				GlobalScript.inst.gameState.data[9] -= 40;
				GlobalScript.inst.gameState.data[22] -= 50;
				if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 1)
				{
					GlobalScript.inst.gameState.data[94] = 1;
				}
				else
				{
					warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl1 += 100;
					warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
					warinwars2.infl2 -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Заключив негласное соглашение с США и убедив Бхутто нам не препятствовать мы начали провозить к пакистанско-афганской границе американское оружие и советников, передавая их там моджахедам, которые затем полулегально пересекали границу, отправляясь в Афганистан. Это  существенно помогает афганским повстанцам против ДРА, а нам в свою очередь за \"посреднические услуги\" в карманы идут американские деньги.";
				GlobalScript.inst.gameState.data[8] += 30;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				GlobalScript.inst.gameState.data[6] -= 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 120;
				warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
				warinwars2.infl1 -= 80;
				warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
				warinwars2.infl2 += 80;
				GlobalScript.inst.gameState.data[94] = 2;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Продолжая свою помощь маоистским повстанцам в Афганистане, мы отогнав с границы исламистов, организовали там тренировочные лагеря и пункты снабжения для маоистов, куда мы теперь поставляем оружие и отправляем инструкторов, чем очень помогаем этим повстанцам. С пакистанскими властями также удалось договориться о беспрепятственной отправке людей и оружия в Афганистан. Естественно, на создание такой инфраструктуры пришлось раскошелиться, равно как и напрячь армию для поставок, да и недовольны и СССР и США.";
				GlobalScript.inst.gameState.data[8] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
				GlobalScript.inst.gameState.data[22] -= 100;
				GlobalScript.inst.gameState.data[6] += 30;
				warinwars warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
				warinwars2.infl1 += 10;
				warinwars2 = GlobalScript.inst.gameState.ingamewars[5];
				warinwars2.infl2 -= 10;
				GlobalScript.inst.gameState.data[94] = 3;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 64)
		{
			text2 = "Панарабизм";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Ничего не произошло. Арабские государства остаются относительно разрозненными, чем дают преимущество проамериканскому Израилю.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря вмешательству нашей разведки большинство противников объединения быстро поутихли, а наша готовность выступить посредником в объединении арабских стран и выдать им безвозмездную помощь для развития совместной государственности в итоге привели к согласию на переговоры. В августе в Каире прошла историческая конференция Египта, Ливии и Сирии, по итогам которой было решено сформировать конфедеративную Объединённую Арабскую Республику с общей валютой, армией, совместным решением внешнеполитических вопросов и перспективами дальнейшей экономической и политической интеграции. Новое государство заявило о своей верности принципам арабского социализма и о необходимости продолжения формирования единого государства всех арабов, чем здорово взбудоражило Израиль, который запросил у США дополнительной военной помощи. СССР приветствовал создание ОАР, а вот США остались недовольны появлением на Ближнем Востоке столь мощного противника их гегемонии.";
				GlobalScript.inst.gameState.data[8] -= 70;
				GlobalScript.inst.gameState.data[9] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 80;
				GlobalScript.inst.gameState.data[6] += 10;
				GlobalScript.inst.gameState.data[57] -= 30;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 70;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.OAR = true;
				GlobalScript.inst.gameState.data[143] += 5;
				GlobalScript.inst.gameState.allcountries[30].oar = true;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 10;
				party_change[2] = 0.24f;
				party_change[3] = 0.24f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic170 in politics)
				{
					if (politic170.traits[0] == 1)
					{
						Politic politic = politic170;
						politic.power += 120;
						politic = politic170;
						politic.loyality += 100;
					}
					else if (politic170.traits[0] == 2)
					{
						Politic politic = politic170;
						politic.power += 120;
						politic = politic170;
						politic.loyality += 100;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 65)
		{
			text2 = "До свидания, наш ласковый Мишка...";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " отверг предложение о бойкоте московской Олимпиады, назвав его \"американской провокацией\". Он лично позвонил Леониду Ильичу Брежневу и сообщил, что \"Китай ни в коем случае не будет присоединяться к американскому бойкоту и отправит в Москву свою команду\", а также пожелал удачи советским спортсменам. Растроганный советский руководитель в ответ выразил желание лично встретиться с товарищем " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " на церемонии открытия и  пожелал успехов китайской команде. В конечном итоге, бойкот объявили 63 государства – США и их сателлиты, командам ";
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					text += "Ирана, ";
				}
				text += "Мозамбика и Катара в участии в играх отказали, а правительства Англии, Франции, Италии и Испании предоставили право решать, посылать спортсменов в Москву или нет, своим олимпийским комитетам (всё-таки они отправили свои команды). На церемонии открытия, президент МОК Моррис Килланин, прежде чем передать слово Леониду Брежневу, особо поблагодарил тех спортсменов, которые приехали в инициативном порядке, несмотря на бойкот. Команда КНР заняла 3-е место, уступив СССР и ГДР, выиграв 35 золотых, 30 серебряных и 38 бронзовых медалей, а также установив несколько рекордов. Эти игры вошли в историю, как Олимпиада с наиболее грамотно организованной и запоминающейся церемонией закрытия – когда символ игр – Мишка – поднялся ввысь под песню А. Пахмутовой и Н. Добронравова «До свиданья, Москва!», многие (даже иностранцы) не смогли сдержать слез – настолько это было мощно и атмосферно. На церемонии закрытия вместо флага США (страны, где будет проведена следующая Олимпиада) был поднят флаг города Лос-Анджелес, что намекало на то, что СССР ещё припомнит этот бойкот...";
				GlobalScript.inst.gameState.data[1] += 150;
				GlobalScript.inst.gameState.data[3] += 80;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 20;
				GlobalScript.inst.gameState.data[6] -= 20;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 250;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.data[8] -= 40;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В то время, как СССР и США обменивались угрозами и жаловались друг на друга в МОК, Китай - совершенно неожиданно для всех - просто проигнорировал обе Олимпиады. В ответ на полный недоумения запрос МОК о причинах отсутствия китайских спортсменов в Москве, Хуа Гофэн и глава Олимпийского комитета КНР Чжун Шитун сослались на сложное финансовое положение Китая, не позволившее ему принять участие в Играх. Кажется, наши объяснения вызвали там сильное сомнение, но мы получили официальное предупреждение - бойкот игр в Лос-Анджелесе автоматически лишает нас членства в МОК. Народ также не понимает, почему руководство страны никак не отреагировало на Игры. В конечном итоге, бойкот объявили 63 государства – США и их сателлиты, командам ";
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					text += "Ирана, ";
				}
				text += "Мозамбика и Катара в участии в играх отказали, а правительства Англии, Франции, Италии и Испании предоставили право решать, посылать спортсменов в Москву или нет, своим олимпийским комитетам (всё-таки они отправили свои команды). На церемонии открытия, президент МОК Моррис Килланин, прежде чем передать слово Леониду Брежневу, особо поблагодарил тех спортсменов, которые приехали в инициативном порядке, несмотря на бойкот. Эти игры вошли в историю, как Олимпиада с наиболее грамотно организованной и запоминающейся церемонией закрытия – когда символ игр – Мишка – поднялся ввысь под песню А. Пахмутовой и Н. Добронравова «До свиданья, Москва!», многие (даже иностранцы) не смогли сдержать слез – настолько это было мощно и атмосферно. На церемонии закрытия вместо флага США (страны, где будет проведена следующая Олимпиада) был поднят флаг города Лос-Анджелес, что намекало на то, что СССР ещё припомнит этот бойкот...";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[3] -= 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 150;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Китай присоединился к американскому бойкоту Олимпийских игр в Москве, хотя и не без колебания - Олимпийский комитет КНР только-только получил регистрацию в МОК и сейчас совсем нежелательно бы портить с ним отношения. Поэтому Хуа Гофэн предложил его главе Чжун Шитуну самостоятельно принять решение - отправлять ли в Москву команду или нет. Тот, после консультаций с МОК и НОК США, Италии, Франции, Испании и Британской ОА, дал добро на отправку команды КНР в Москву под флагом МОК. В конечном итоге, бойкот объявили 63 государства – США и их сателлиты, командам ";
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					text += "Ирана, ";
				}
				text += "Мозамбика и Катара в участии в играх отказали, а правительства Англии, Франции, Италии и Испании предоставили право решать, посылать спортсменов в Москву или нет, своим олимпийским комитетам (всё-таки они отправили свои команды). На церемонии открытия, президент МОК Моррис Килланин, прежде чем передать слово Леониду Брежневу, особо поблагодарил тех спортсменов, которые приехали в инициативном порядке, несмотря на бойкот. Эти игры вошли в историю, как Олимпиада с наиболее грамотно организованной и запоминающейся церемонией закрытия – когда символ игр – Мишка – поднялся ввысь под песню А. Пахмутовой и Н. Добронравова «До свиданья, Москва!», многие (даже иностранцы) не смогли сдержать слез – настолько это было мощно и атмосферно. На церемонии закрытия вместо флага США (страны, где будет проведена следующая Олимпиада) был поднят флаг города Лос-Анджелес, что намекало на то, что СССР ещё припомнит этот бойкот... | Мы также отправили свою команду на альтернативные Игры в Филадельфию, где получили 5 золотых, 1 серебряную и 4 бронзовых медалей.";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[3] += 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 80;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				GlobalScript.inst.gameState.data[8] -= 40;
				GlobalScript.inst.gameState.data[4] += 60;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Китай присоединился к американскому бойкоту Олимпийских игр в Москве, хотя и не без колебания - Олимпийский комитет КНР только-только получил регистрацию в МОК и сейчас совсем нежелательно бы портить с ним отношения. Тем не менее, мы приняли решение об отправке команды КНР в Филадельфию на американские \"альтернативные\" соревнования \"Колокола свободы\". Несогласный с этим глава ОК КНР Чжун Шитун был исключен из КПК и снят с должности, его заменил более лояльный Ли Мэнхуа. Наша команда заняла 3-е место, уступив США и ФРГ, получив 5 золотых, 1 серебряную и 4 бронзовых медалей. В конечном итоге, бойкот объявили 63 государства – США и их сателлиты, командам ";
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					text += "Ирана, ";
				}
				text += "Мозамбика и Катара в участии в играх отказали, а правительства Англии, Франции, Италии и Испании предоставили право решать, посылать спортсменов в Москву или нет, своим олимпийским комитетам (всё-таки они отправили свои команды). На церемонии открытия, президент МОК Моррис Килланин, прежде чем передать слово Леониду Брежневу, особо поблагодарил тех спортсменов, которые приехали в инициативном порядке, несмотря на бойкот. Эти игры вошли в историю, как Олимпиада с наиболее грамотно организованной и запоминающейся церемонией закрытия – когда символ игр – Мишка – поднялся ввысь под песню А. Пахмутовой и Н. Добронравова «До свиданья, Москва!», многие (даже иностранцы) не смогли сдержать слез – настолько это было мощно и атмосферно. На церемонии закрытия вместо флага США (страны, где будет проведена следующая Олимпиада) был поднят флаг города Лос-Анджелес, что намекало на то, что СССР ещё припомнит этот бойкот...";
				GlobalScript.inst.gameState.data[1] += 70;
				GlobalScript.inst.gameState.data[3] += 30;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 200;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 200;
				GlobalScript.inst.gameState.data[4] += 60;
				GlobalScript.inst.gameState.data[8] -= 30;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Идея партийцев нашла поддержку как Хуа Гофэна, так и главы Олимпийского комитета КНР Чжун Шитуна. Мы решили возродить \"Игры новых развивающихся сил\" (англ. Games of the New Emerging Forces - GANEFO). Постоянный комитет ВСНП принял решение о проведении Игр в ноябре в городе Нинбо и разослал приглашения странам \"второго\" и \"третьего\" миров. ";
				if (GlobalScript.inst.gameState.data[6] >= 85)
				{
					text += "К сожалению, принять участие согласились лишь 16 стран Африки с военными и полувоенными режимами. Наша сборная, само собой, займет первое место - но это же будет совершенно неинтересно! ";
				}
				else if (GlobalScript.inst.gameState.data[6] >= 65 && GlobalScript.inst.gameState.data[6] < 85)
				{
					text += "Принять участие согласились почти все страны, входящие в Движение неприсоединения, включая Югославию. Игры обещают быть интересными и напряженными!.. ";
				}
				else if (GlobalScript.inst.gameState.data[6] < 65)
				{
					text += "К нашему великому удивлению, принять участие в новых Играх согласились все страны, которым мы направили приглашения - более того, НОК СССР и США вышли на контакт с ОК КНР на предмет участия и их спортсменов (конечно, не первого уровня, но, тем не менее...). Игры будут очень напряженными, нашим спортсменам пора начинать подготовку... ";
				}
				text += " В конечном итоге, бойкот объявили 63 государства – США и их сателлиты, командам ";
				if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 0)
				{
					text += "Ирана, ";
				}
				text += "Мозамбика и Катара в участии в играх отказали, а правительства Англии, Франции, Италии и Испании предоставили право решать, посылать спортсменов в Москву или нет, своим олимпийским комитетам (всё-таки они отправили свои команды). На церемонии открытия, президент МОК Моррис Килланин, прежде чем передать слово Леониду Брежневу, особо поблагодарил тех спортсменов, которые приехали в инициативном порядке, несмотря на бойкот. Эти игры вошли в историю, как Олимпиада с наиболее грамотно организованной и запоминающейся церемонией закрытия – когда символ игр – Мишка – поднялся ввысь под песню А. Пахмутовой и Н. Добронравова «До свиданья, Москва!», многие (даже иностранцы) не смогли сдержать слез – настолько это было мощно и атмосферно. На церемонии закрытия вместо флага США (страны, где будет проведена следующая Олимпиада) был поднят флаг города Лос-Анджелес, что намекало на то, что СССР ещё припомнит этот бойкот...";
				GlobalScript.inst.gameState.data[1] += 200;
				GlobalScript.inst.gameState.data[3] += 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[8] -= 200;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 66)
		{
			text2 = "И после Тита - Тито!";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " отправил письмо, в котором выразил глубокие соболезнования Президиуму СФРЮ, ЦК СКЮ, всем народам и народностям Югославии в связи со смертью главы государства, маршала Тито, и выразил надежду на восстановление \"доброжелательных отношений, экономических и культурных связей\". Письмо было опубликовано в газете \"Борба\", а по окончанию семидневнего траура мы получили официальный ответ от Президиума СФРЮ, в котором нас поблагодарили за соболезнования. Однако на состоянии китайско-югославских отношений это никак не отразилось. ";
				GlobalScript.inst.gameState.data[6] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 20;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "7 мая более 200 иностранных делегаций прибыло в здание Скупщины СФРЮ, чтобы проститься с маршалом Тито. Панихида закончилась 8 мая в 8:00 утра. В 12:00 8 мая после почётного караула, состоявшего из членов Президиума СФРЮ и Президиума ЦК СКЮ, гроб с телом Иосипа Броза Тито понесли 8 адмиралов и генералов ЮНА. Председатель ЦК СКЮ Стеван Дороньский выступил с речью в память о Тито, после чего колонна двинулась по улице князя Милоша и бульвару Октябрьской революции вплоть до Музея 25 мая. Последнюю речь произнёс Председатель Президиума СФРЮ Лазар Колишевский перед Домом цветов и трибунами, предназначенными для иностранных государственных деятелей. Под звуки «Интернационала» после 15:00 гроб ввезли в Дом цветов, где отныне и упокоился Иосип Броз Тито. |Делегация КНР, которую возглавили " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " и Цзи Пэнфэй провела переговоры с новым руководством Югославии, в ходе которых были достигнуты договоренности об восстановлении дипломатических, экономических и культурных отношений. Ожидается ответный визит Лазара Колишевского в Пекин через полгода. Однако в партии уже нашлись недовольные нашим курсом на улучшение отношений с СФРЮ, а кое-кто уже сравнил товарища " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " с Хрущевым...";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[6] -= 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GlobalScript.inst.gameState.allcountries[15].Torg = true;
				if (GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					text += "Но, как и следовало ожидать, руководство Албании тут же обвинило нас в \"ревизионизме\" и разорвало дип. отношения с КНР, выпроводив из страны всех наших советников и отказавшись платить по кредитам, которые мы им давали. Ну что за люди?..";
					GlobalScript.inst.gameState.allcountries[20].Torg = false;
					GlobalScript.inst.gameState.allcountries[20].proprc = false;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "7 мая более 200 иностранных делегаций прибыло в здание Скупщины СФРЮ, чтобы проститься с маршалом Тито. Панихида закончилась 8 мая в 8:00 утра. В 12:00 8 мая после почётного караула, состоявшего из членов Президиума СФРЮ и Президиума ЦК СКЮ, гроб с телом Иосипа Броза Тито понесли 8 адмиралов и генералов ЮНА. Председатель ЦК СКЮ Стеван Дороньский выступил с речью в память о Тито, после чего колонна двинулась по улице князя Милоша и бульвару Октябрьской революции вплоть до Музея 25 мая. Последнюю речь произнёс Председатель Президиума СФРЮ Лазар Колишевский перед Домом цветов и трибунами, предназначенными для иностранных государственных деятелей. Под звуки «Интернационала» после 15:00 гроб ввезли в Дом цветов, где отныне и упокоился Иосип Броз Тито. |Новое руководство Югославии проявило интерес к восстановлению отношений с КНР, но товарищ Цзи Пэнфэй отказался вести какие-либо переговоры, сославшись на отсутствие у него соответствующих полномочий. \"Возможно, что когда-нибудь потом... но не сейчас\" - сказал он Лазару Колишевскому. Однако в партии нашлись недовольные тем, что наша делегация вернулась из Белграда с пустыми руками...";
				GlobalScript.inst.gameState.data[1] -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 30;
				GlobalScript.inst.gameState.data[6] -= 15;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 30;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Китайское руководство никак не отреагировало на смерть Тито, даже не выразило сополезнований. Это вызвало удивление не только в Югославии, но и во всем мире. На вопрос агенства ТАНЮГ об причинах этого, товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " ответил: \"Без комментариев...\"";
				GlobalScript.inst.gameState.data[6] += 10;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 67)
		{
			text2 = "Ещё Польша не погибла?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Китайское руководство никак не отреагировало на события в Польше, за исключением совместной редакционной статьи газеты \"Жэньминь Жибао\" и журнала \"Хунци\", в которой содержался призыв к враждующим сторонам \"найти компромиссное решение ради социалистического и народно-демократического будущего Польши\". Такая позиция нашла одобрение как СССР, так и самой Польши.|В сложившейся ситуации, всю ответственность за судьбу страны на себя взяла армия. Заручившись поддержкой СССР и гарантией его военного невмешательства, министр национальной обороны ПНР генерал Войцех Ярузельский создал Военный совет национального спасения и 13 декабря 1981 года объявил о вводе на всей территории ПНР режима военного положения. Решительными действиями Войска Польского, СБ и ЗОМО (спецподразделения Гражданской милиции), весь актив \"Солидарности\" и руководство ПОРП были интернированы и порядок в стране более-менее восстановлен. Объявив \"новую линию социализма\", Ярузельский начал экономические реформы по образцу венгерских. Однако кардинальные проблемы решены так и не были, что позже обязательно даст о себе знать...";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GlobalScript.inst.gameState.allcountries[2].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 10;
				GlobalScript.inst.gameState.allcountries[2].Torg = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Понимая, что в сложившейся ситуации только Войско Польское может хоть как-то повлиять на ситуацию и остановить надвигающуюся контрреволюцию, мы вышли на контакт с его командованием во главе с министром национальной обороны ПНР генералом Войцехом Ярузельским. Как выяснилось, не мы одни потребовали от него наведения порядка - СССР тоже оказывал давление, но Ярузельский колебался. Наконец, он решился - но категорически потребовал от СССР и КНР не вмешиваться в процесс. Получив наши гарантии, 13 декабря 1980 года польские генералы создали Военный совет национального спасения и ввели на всей территории ПНР режим военного положения. Решительными действиями Войска Польского, СБ и ЗОМО (спецподразделения Гражданской милиции), весь актив \"Солидарности\" и руководство ПОРП были интернированы и порядок в стране более-менее восстановлен. Вся власть в стране перешла к ВСНС, что тут же вызвало обвинения в \"установлении военной диктатуры\", а США уже призвали к борьбе с \"советской военной хунтой Ярузельского\". КНР и СССР также выдали ПНР крупные беспроцентные кредиты на погашение госдолга. Кажется, ситуация восстанавливается, а польский пример кое-чему научил и нашу партию...";
				GlobalScript.inst.gameState.data[1] += 200;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
				GlobalScript.inst.gameState.data[8] -= 200;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[4] -= 10;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GlobalScript.inst.gameState.allcountries[2].Gosstroy = 0;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 150;
				GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Агентура МГБ через подпольную Коммунистическую партию Польши Казимежа Мияля вышла на главу фракции \"бетона\" в ПОРП Альбина Сивака - ненавидящего \"Солидарность\" и уже не раз требовавшего пустить в ход оружие против нее. Через свои связи в национал-католической группе \"ПАКС\" и правонационалистическом обществе \"Грюнвальд\", Сивак быстро добился их согласия на коалицию с \"бетоном\" и КПП. Наша агентура развернула широкую работу в Фронте единства народа, Добровольном резерве Гражданской милиции (ORMO), а также среди правого крыла \"Солидарности\". 2 декабря на совместном заседании ЦК ПОРП и Государственного совета ПНР бывший глава страны Эдвард Герек был выведен из ЦК ПОРП и Госсовета. Но сразу после этого товарищ Сивак выступил с требованием немедленного созыва Сейма и объявления в стране военного положения. Госсовет попытался сопротивляться, но тогда в зал заседаний ворвались бойцы ORMO. В течении двух месяцев в стране де-факто шла гражданская война в миниатюре, но силовые структуры ПНР поддержали переворот и, тем самым, обеспечили победу коалиции. ПОРП была распущена, КПП легализована, \"Солидарность\" фактически уничтожена, а её правое крыло вошло в Фронт единства народа. Новое руководство Польши уже объявило о курсе на \"социализм с польской национальной спецификой\" и на сближение с нами. СССР в бешенстве, но, после заявления польских руководителей, что \"ПНР ни в коем случае не собирается выходить из ОВД и СЭВ и выступает за развитие советско-польских отношений в русле добрососедства и сотрудничества\", несколько успокоился и де-факто признал сложившиеся изменения. Будем надеяться, что все националисты, с которыми КПП пришлось вступить в союз для достижения успеха, не заведут в итоге Польшу не в то русло...";
				GlobalScript.inst.gameState.data[1] += 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 30;
				GlobalScript.inst.gameState.data[8] -= 300;
				GlobalScript.inst.gameState.data[9] -= 150;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 30;
				GlobalScript.inst.gameState.data[6] += 100;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 200;
				GlobalScript.inst.gameState.allcountries[2].Torg = true;
				GlobalScript.inst.gameState.allcountries[2].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 0;
				GlobalScript.inst.gameState.allcountries[2].prosov = false;
				GlobalScript.inst.gameState.allcountries[2].proprc = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Известие об отставке Герека произвело на вас очень негативное впечатление. В 23 часа вы вызвали советского посла и попросили передать лично товарищу Леониду Ильичу Брежневу следующее: \"В этот час ответственных испытаний для судеб социализма в Польше, Компартия Китая, братские партии союзных государств, все соцстраны не могут занять позицию стороннего наблюдателя. То, что происходит в Польше - это не только внутреннее дело поляков. Сегодня же ночью мы обратимся ко всем руководителям государств Варшавского договора с настоятельным призывом предпринять энергичные совместные военные усилия с тем, чтобы не допустить краха социализма в Польше. Руководство КНР и КПК уверено, что социалистическую Польшу еще можно спасти. Можно и нужно предотвратить тяжелейший удар империализма по делу социализма\".";
				if (GlobalScript.inst.gameState.empires[1].relations >= 800)
				{
					text = "Наш призыв нашел поддержку руководства ГДР, ЧССР, а затем и руководства СССР. План военного вторжения был передан начальником Генерального штаба ВС СССР маршалом Н.В. Огарковым заместителю польского генштаба генералу Т. Хупаловскому. Планом предусматривался ввод советских, восточногерманских и чехословацких войск на польскую территорию. Польские войска должны были оставаться в казармах. В состав войск вторжения вошли 15 советских дивизий, 2 немецких и 1 чехословацкая. Была проведена рекогносцировка маршрутов выдвижения и районов сосредоточения войск, в которой активное участие принимали и польские представители. К операции привлекались: от Чехословацкой народной армии – штаб Западного военного округа и два армейских штаба; от Национальной народной армии ГДР – два армейских штаба; от Советской Армии – штаб ГСВГ, два ее армейских штаба и штаб Северной группы войск (СГВ). |9 декабря 1980 года части Северной группы войск ВС СССР совместно с подразделениями Национальной народной армии ГДР и Чехословацкой народной армии вошли на территорию Польши и начали быстрое продвижение к ключевым городам страны. Части Войска Польского не оказали никакого сопротивления. \"Солидарность\" ушла в подполье, руководство ПОРП было арестовано и вывезено в СССР. Новое руководство ПНР во главе с генералом Войцехом Ярузельским объявило курс на \"новую линию социализма\", предусматривающую проведение реформ в рамках марксизма под присмотром советских войск. США в бешенстве и вовсю обвиняют СССР и нас в установлении в Польше \"военной диктатуры\".";
					GlobalScript.inst.gameState.data[1] += 100;
					GlobalScript.inst.gameState.data[22] -= 50;
					GlobalScript.inst.gameState.data[9] -= 50;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[6] += 200;
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 150;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 150;
					GlobalScript.inst.gameState.data[112]++;
				}
				else
				{
					text = "К сожалению, советское руководство, а за ним и руководство остальных стран ОВД, так и не решилось на использование войск для наведения порядка, однако поддержало польских военных и дало санкцию на самостоятельные действия. Министр национальной обороны ПНР генерал Войцех Ярузельский создал Военный совет национального спасения и 13 декабря 1981 года объявил о вводе на всей территории ПНР режима военного положения. Решительными действиями Войска Польского, СБ и ЗОМО (спецподразделения Гражданской милиции), весь актив \"Солидарности\" и руководство ПОРП были интернированы и порядок в стране более-менее восстановлен. Объявив \"новую линию социализма\", Ярузельский начал экономические реформы по образцу венгерских. Однако кардинальные проблемы решены так и не были, что позже обязательно даст о себе знать...";
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[6] += 200;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 20;
					GlobalScript.inst.gameState.allcountries[2].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				if (GlobalScript.inst.gameState.empires[0].relations >= 80 && GlobalScript.inst.gameState.allcountries[51].dev == 1)
				{
					text = "Мы вошли в контакт с ЦРУ и достигли договоренностей об совместных действиях. Но ситуация приняла неожиданный оборот - на волне усилившихся беспорядков, Станислав Каня, после тайных консультаций с командованием армии, неожиданно объявил об уходе в отставку со всех постов. Первым Секретарем ЦК ПОРП стал сторонник реформ Мечислав Раковский, близкий к министру национальной обороны ПНР генералу Войцеху Ярузельскому. Через свои связи в \"Солидарности\", Раковский вышел на контакт с Валенсой и предложил выгодный обеим сторонам компромисс - \"Солидарность\" официально легализуется, но отказывается от силовой борьбы и переходит к парламентской, она получит несколько портфелей в новом правительстве и допуск к разработке проекта широких реформ. Тот согласился. Раковский объявил о концепции \"новой линии социализма\", подразумевающей очень широкие реформы по примеру Венгрии и Югославии. Руководство \"Солидарности\" поддержало эти реформы и объявило об прекращении манифестаций и забастовок. Ситуация потихоньку нормализуется, несмотря на то, что СССР отнесся к такому неожиданному \"выходу\" с очень сильным подозрением, и если Раковский в ходе реформ потеряет контроль над ситуацией, то Польшу ждёт свой 1968-й...";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[3] += 20;
					GlobalScript.inst.gameState.data[4] += 80;
					GlobalScript.inst.gameState.data[8] -= 100;
					GlobalScript.inst.gameState.data[4] += 80;
					GlobalScript.inst.gameState.data[9] -= 200;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 30;
					GlobalScript.inst.gameState.data[6] -= 50;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 150;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 50;
					GlobalScript.inst.gameState.allcountries[2].SubGosstroy = 3;
					GlobalScript.inst.gameState.allcountries[2].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[2].prosov = false;
					GlobalScript.inst.gameState.allcountries[2].Torg = true;
				}
				else
				{
					text = "К сожалению, даже несмотря на то, что мы поддержали усилия США по дестабилизации ситуации в Польше, добиться положительных итогов так и не получилось. Сначала все шло по плану - в декабре \"Солидарность\" предприняла попытку государственного переворота при поддержке широких масс народа и смогла захватить правительственный квартал в Варшаве. Но затем произошло неожиданное - Станислав Каня бежал в Белосток и обратился к ПКК ОВД за военной помощью. 9 декабря 1980 года части Северной группы войск ВС СССР совместно с подразделениями Национальной народной армии ГДР и Чехословацкой народной армии вошли на территорию Польши и начали быстрое продвижение к ключевым городам страны. Части Войска Польского либо примкнули к ним, либо остались в нейтралитете. \"Солидарность\" фактически была уничтожена, а Лех Валенса едва успел бежать в американское посольство в Варшаве. Новое руководство ПНР во главе с генералом Войцехом Ярузельским объявило курс на \"новую линию социализма\", предусматривающую проведение реформ в рамках марксизма под присмотром советских войск...";
					GlobalScript.inst.gameState.data[9] -= 200;
					GlobalScript.inst.gameState.data[8] -= 100;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 300;
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[4] += 80;
					GlobalScript.inst.gameState.data[6] -= 50;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 68)
		{
			text2 = "Восстание в Кванджу";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "27 мая авиация и армейские части Южной Кореи в составе пяти дивизий ворвались в центр города и всего за 90 минут захватили его. Количество убитых мирных жителей по разным оценкам составляет от нескольких сотен до нескольких тысяч.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Благодаря нашим поставкам оружия и внесению беспорядка в планы южнокорейской армии и диверсий, штурм Кванджу приобрёл долгий и кровопролитный характер. Более того, узнав (благодаря нашим же агентам) о происходящей бойне, люди из других городов и регионов Южной Кореи тоже вышли на протесты, переходящие в открытые столкновения с армией и полицией, захваты административных зданий и складов оружия. В конечном итоге армии удалось захватить Кванджу, жестоко расправившись с восставшими, а остальные самые крупные мятежи были кое-как подавлены. Однако протесты в разных городах продолжаются до сих пор и стабильность правительства Чон Ду Хвана висит на волоске.";
				GlobalScript.inst.gameState.data[22] -= 80;
				GlobalScript.inst.gameState.data[9] -= 80;
				GlobalScript.inst.gameState.data[6] += 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 10;
				GlobalScript.inst.gameState.SKRebel = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Мы призвали южнокорейские власти и восставший Кванджу к переговорам и нахождению компромисса. Эти заявления были поддержаны самими восставшими, однако из-за того, что США (за исключением некоторых политиков, поддержавших наше заявление) не выразили никакой поддержки протестующим и мирному урегулированию конфликта, наш призыв был проигнорирован властями. 27 мая авиация и армейские части Южной Кореи в составе пяти дивизий ворвались в центр города и всего за 90 минут захватили его. Количество убитых мирных жителей по разным оценкам составляет от нескольких сотен до нескольких тысяч.";
				GlobalScript.inst.gameState.data[6] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "После того, как южнокорейская армия за 90 минут захватила город, жестоко подавив восстание, мы выразили поддержку действиям Чон Ду Хвана, заявив, что подобные жёсткие меры были единственным адекватным ответом на устроенный восставшими хаос. Правительство Южной Кореи поблагодарило нас за поддержку, зато немало стран, в особенности соцлагерь, восприняли это с крайним неодобрением.";
				GlobalScript.inst.gameState.data[6] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 80;
				party_change[4] = 0.25f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic171 in politics)
				{
					if (politic171.traits[0] == 3)
					{
						Politic politic = politic171;
						politic.power += 100;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 69)
		{
			text2 = "Ещё одна банда?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Консерваторы продолжают занимать свои посты, подрывая ваши реформы и репутацию в народе и КПК. Да и сами реформаторы недовольны вашей пассивностью.";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[3] -= 70;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic172 in politics)
				{
					if (politic172.traits[0] == 0)
					{
						Politic politic = politic172;
						politic.power += 100;
					}
					else if (politic172.traits[0] == 1)
					{
						Politic politic = politic172;
						politic.loyality -= 150;
					}
					else if (politic172.traits[0] == 2)
					{
						Politic politic = politic172;
						politic.loyality -= 150;
					}
					else if (politic172.traits[0] == 3)
					{
						Politic politic = politic172;
						politic.loyality -= 150;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "На V пленуме ЦК КПК в феврале Ван Дунсин, Цзи Дэнкуй, Чэнь Силянь и У Дэ были раскритикованы за \"ультралевые тенденции\", они были обвинены в участии в репрессиях Культурной революции и наречены \"Малой бандой четырёх\". По итогам пленума все четверо были сняты с партийных и правительственных постов, лишившись всякого влияния. Та же участь постигла и цеплявшихся за них консерваторов в низших эшелонах. Их места уже занимают ваши преданные сторонники-реформаторы, и продвигаемые ими люди.";
				GlobalScript.inst.gameState.data[1] += 80;
				GlobalScript.inst.gameState.data[92] += 20;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[6] -= 30;
				GlobalScript.inst.gameState.is_party_enabled[0] = false;
				GlobalScript.inst.gameState.is_party_ally[0] = false;
				GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.45f);
				GlobalScript.inst.gameState.is_party_enabled[4] = true;
				party_change[3] = 0.45f;
				party_change[4] = 0.24f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic173 in politics)
				{
					if (politic173.traits[0] == 0)
					{
						Politic politic = politic173;
						politic.power -= 200;
						politic = politic173;
						politic.loyality -= 250;
					}
					else if (politic173.traits[0] == 1)
					{
						Politic politic = politic173;
						politic.power += 80;
					}
					else if (politic173.traits[0] == 2)
					{
						Politic politic = politic173;
						politic.power += 100;
					}
					else if (politic173.traits[0] == 3)
					{
						Politic politic = politic173;
						politic.power += 150;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "На V пленуме ЦК КПК в феврале Ван Дунсин, Цзи Дэнкуй, Чэнь Силянь и У Дэ были раскритикованы за \"ультралевые тенденции\", они были обвинены в участии в репрессиях Культурной революции и наречены \"Малой бандой четырёх\". По итогам пленума все четверо были сняты с партийных и правительственных постов, лишившись всякого влияния. Та же участь постигла и цеплявшихся за них консерваторов в низших эшелонах.";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[92] += 10;
				GlobalScript.inst.gameState.data[4] += 30;
				GlobalScript.inst.gameState.data[6] -= 15;
				GlobalScript.inst.gameState.is_party_enabled[0] = false;
				GlobalScript.inst.gameState.is_party_ally[0] = false;
				GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.45f);
				party_change[3] = 0.45f;
				party_change[4] = 0.15f;
				party_change[2] = 0.27f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic174 in politics)
				{
					if (politic174.traits[0] == 0)
					{
						Politic politic = politic174;
						politic.power -= 350;
						politic = politic174;
						politic.loyality -= 300;
					}
					else if (politic174.traits[0] == 1)
					{
						Politic politic = politic174;
						politic.power += 100;
					}
					else if (politic174.traits[0] == 2)
					{
						Politic politic = politic174;
						politic.power += 120;
					}
					else if (politic174.traits[0] == 3)
					{
						Politic politic = politic174;
						politic.power += 80;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 70)
		{
			text2 = "Проблемы наследников Чжоу Эньлая";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Реформаторы продолжают занимать свои посты, подрывая ваши начинания и репутацию в народе и КПК. Да и само левое крыло недовольно вашей пассивностью.";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[4] += 100;
				party_change[3] = 0.25f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic175 in politics)
				{
					if (politic175.traits[0] == 0)
					{
						Politic politic = politic175;
						politic.loyality -= 100;
					}
					else if (politic175.traits[0] == 2)
					{
						Politic politic = politic175;
						politic.power += 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "На V пленуме ЦК КПК в феврале старые реформаторы, умеренные и их лидеры, такие как Дэн Сяопин, Е Цзяньин, Чжао Цзыян и Ли Сяньнянь подверглись жёсткой критике за ревизионистские позиции, стремление к буржуазной либерализации и предательство идей Мао. Несмотря на жаркие дискуссии, по итогам пленума реформаторы и некоторые умеренные были сняты с партийных и правительственных постов, лишившись всякого влияния. Та же участь постигла и покрываемых ими реформаторов в низших эшелонах.";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[4] -= 50;
				GlobalScript.inst.gameState.data[6] += 40;
				if (GlobalScript.inst.gameState.modifies[14].active)
				{
					GlobalScript.inst.gameState.KillPerson(12);
					GlobalScript.inst.gameState.modifies[14].active = false;
				}
				party_change[1] = 0.45f;
				party_change[0] = 0.3f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic176 in politics)
				{
					if (politic176.traits[0] == 0)
					{
						Politic politic = politic176;
						politic.power += 150;
					}
					else if (politic176.traits[0] == 1)
					{
						Politic politic = politic176;
						politic.power -= 150;
						politic = politic176;
						politic.loyality -= 200;
					}
					else if (politic176.traits[0] == 2)
					{
						Politic politic = politic176;
						politic.power -= 350;
						politic = politic176;
						politic.loyality -= 200;
					}
					else if (politic176.traits[0] == 3)
					{
						Politic politic = politic176;
						politic.power -= 250;
						politic = politic176;
						politic.loyality -= 200;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "На V пленуме ЦК КПК в феврале старые реформаторы, такие как Дэн Сяопин, Е Цзяньин и Чжао Цзыян, подверглись жёсткой критике за ревизионистские позиции, стремление к буржуазной либерализации и предательство идей Мао. Причём эти обвинения поддержали даже некогда солидарные с реформаторами умеренные, благодаря тому, что вы провели столь желаемые ими свёртывание Культурной революции и переоценку Мао. По итогам пленума реформаторы были сняты с партийных и правительственных постов, лишившись всякого влияния. Та же участь постигла и покрываемых ими реформаторов в низших эшелонах.";
				GlobalScript.inst.gameState.data[1] += 80;
				GlobalScript.inst.gameState.data[4] -= 50;
				GlobalScript.inst.gameState.data[6] += 30;
				if (GlobalScript.inst.gameState.modifies[14].active)
				{
					GlobalScript.inst.gameState.KillPerson(12);
					GlobalScript.inst.gameState.modifies[14].active = false;
				}
				party_change[0] = 0.3f;
				party_change[1] = 0.45f;
				party_change[2] = 0.24f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic177 in politics)
				{
					if (politic177.traits[0] == 2)
					{
						Politic politic = politic177;
						politic.power -= 350;
						politic = politic177;
						politic.loyality -= 200;
					}
					else if (politic177.traits[0] == 3)
					{
						Politic politic = politic177;
						politic.power -= 250;
						politic = politic177;
						politic.loyality -= 200;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "По вашему распоряжение лидеры реформаторов были арестованы по сфабрикованным обвинениям и надолго выведены из политики. После этого при активном участии подконтрольных нам СМИ началась дискредитация реформаторских идей и сторонников репрессированных реформаторов, вместе с чем началась и чистка партии от них. Народ и партия само собой недовольны и считают это повторением событий Культурной революции, но от наших противников мы избавились.";
				GlobalScript.inst.gameState.data[1] -= 200;
				GlobalScript.inst.gameState.data[4] += 150;
				GlobalScript.inst.gameState.data[3] -= 200;
				GlobalScript.inst.gameState.data[6] += 50;
				if (GlobalScript.inst.gameState.modifies[14].active)
				{
					GlobalScript.inst.gameState.KillPerson(12);
					GlobalScript.inst.gameState.modifies[14].active = false;
				}
				party_change[0] = 0.3f;
				party_change[1] = 0.45f;
				GlobalScript.inst.gameState.party_ideology[2] -= (int)((float)GlobalScript.inst.gameState.party_ideology[2] * 0.09f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic178 in politics)
				{
					if (politic178.traits[0] == 0)
					{
						Politic politic = politic178;
						politic.power += 150;
					}
					else if (politic178.traits[0] == 1)
					{
						Politic politic = politic178;
						politic.power -= 50;
						politic = politic178;
						politic.loyality -= 30;
					}
					else if (politic178.traits[0] == 2)
					{
						Politic politic = politic178;
						politic.power -= 350;
						politic = politic178;
						politic.loyality -= 30;
					}
					else if (politic178.traits[0] == 3)
					{
						Politic politic = politic178;
						politic.power -= 250;
						politic = politic178;
						politic.loyality -= 300;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 71)
		{
			text2 = "Алеет восток...";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Ничего не изменилось, наксалиты продолжают свои теракты, а индийское правительство с переменным успехом пытается их сдержать. Но кто знает, может однажды они нам пригодятся, ведь действуют они в том числе и на территориях, на которые мы претендуем...";
				GlobalScript.inst.gameState.CBIndia = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "После долгих споров и колебаний правительство Индии всё же согласилось на переговоры с наксалитами при нашем посредничестве. С большим трудом по итогам переговоров удалось добиться перехода наксалитов к мирной борьбе в обмен на места в местных правительствах и органах самоуправления (в нескольких им удалось даже получить большинство) и признания их как легальной политической силы. Разумеется, некоторые отряды и группировки уже назвали это предательством, но какое нам дело до этих террористов? Наше влияние на востоке Индии значительно укрепилось.";
				GlobalScript.inst.gameState.data[1] += 80;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.data[6] -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Частям НОАК удалось относительно быстро сломить оборону первых пограничных частей, однако дальше они упёрлись в хорошо организованные со времён последней нашей пограничной войны индийские укрепления. Кажется, война будет дольше и кровопролитнее, чем мы думали... Тем временем весь мир уже косо смотрит на нас и требует немедленно сесть за стол переговоров.";
				GlobalScript.inst.gameState.data[1] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 150;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 250;
				GlobalScript.inst.gameState.data[6] += 50;
				GlobalScript.inst.gameState.war = 2;
				GlobalScript.inst.gameState.data[40] = 200;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 72)
		{
			text2 = "Спасение утопающих";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = ((GlobalScript.inst.gameState.data[91] != 1) ? "В конечном итоге под давлением внутренних склок и интриг лидер Джаната Морарджи Десаи ушёл в отставку с поста премьер-министра. Сменивший его Чаран Сингх по всей видимости продержится ровно до выборов 1980-го, после чего его вновь сменит Ганди." : "Коалиция Джаната была крайне популярна в народе, все аналитики предсказывали, что они займут место ИНК и на десятилетия станут главной партией страны, но в конечном итоге под давлением внутренних склок и интриг лидер Джаната Морарджи Десаи ушёл в отставку с поста премьер-министра, а сама коалиция распалась, вызвав большой политический вакуум в стране. Сменивший его Чаран Сингх по всей видимости продержится ровно до выборов 1980-го, где предсказывают победу разношёрстной коалиции ИНК, левой Джанаты и Коммунистической партии, после чего к власти возможно снова придёт Ганди.");
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				GlobalScript.inst.gameState.allcountries[19].Torg = false;
				GlobalScript.inst.gameState.allcountries[19].prosov = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Нашим дипломатам удалось убедить лидера Джаната Морарджи Десаи в необходимости принять требования левого крыла, касающиеся в первую очередь запрета на двойное членство - в Джаната и других партиях, направленное главным образом против представителей правого крыла, состоящих и в своих партиях. В итоге большинство из них предпочли свои партии и были исключены из Джаната, а Десаи сохранил пост премьер-министра при поддержке левого крыла. Определившись со своей политической ориентацией, Джаната теперь реализует левую политику, направленную главным образом на развитие производства и борьбу с бедностью, на что нам пришлось выделить Индии кредит по низкой ставке. Кажется теперь партия реабилитировалась в глазах народа и имеет все шансы на грядущих выборах.";
				GlobalScript.inst.gameState.data[1] += 80;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 80;
				GlobalScript.inst.gameState.data[9] -= 60;
				GlobalScript.inst.gameState.data[8] -= 100;
				GlobalScript.inst.gameState.allcountries[19].Torg = true;
				GlobalScript.inst.gameState.allcountries[19].SubGosstroy = 8;
				GlobalScript.inst.gameState.data[62] = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Нашим дипломатам удалось убедить лидера Джаната Морарджи Десаи в необходимости дать отпор требованиям левого крыла, касающихся в первую очередь запрета на двойное членство - в Джаната и других партиях, направленных главным образом против представителей правого крыла, состоящих и в своих партиях. В итоге большая часть левого крыла была исключена за раскольничество и нарушение принципов коллективного руководства, а Десаи сохранил пост премьер-министра при поддержке правого крыла. Определившись со своей политической ориентацией, Джаната теперь реализует праволиберальную политику, направленную главным образом на привлечение иностранных инвестиций и формирование \"подлинной демократии\", на что нам пришлось выделить Индии кредит по низкой ставке. Кажется теперь партия реабилитировалась в глазах народа и имеет все шансы на грядущих выборах.";
				GlobalScript.inst.gameState.data[1] += 80;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 80;
				GlobalScript.inst.gameState.data[9] -= 60;
				GlobalScript.inst.gameState.data[8] -= 100;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
				GlobalScript.inst.gameState.allcountries[19].Torg = true;
				GlobalScript.inst.gameState.allcountries[19].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[19].SubGosstroy = 5;
				GlobalScript.inst.gameState.data[62] = 1;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 73)
		{
			text2 = "Ирано-иракская война";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Война набирает обороты и, кажется, Иран не собирается так просто сдаваться. США и СССР выступили с дежурными призывами к миру, но фактически оба поддержали Ирак, так как исламский Иран неудобен всем.";
				GlobalScript.inst.gameState.ingamewars[3].name_war = "Ирано-иракская война";
				GlobalScript.inst.gameState.ingamewars[3].is_going = true;
				GlobalScript.inst.gameState.ingamewars[3].side1 = "Ирак";
				GlobalScript.inst.gameState.ingamewars[3].side2 = "Иран";
				GlobalScript.inst.gameState.ingamewars[3].ussr_place = 0;
				GlobalScript.inst.gameState.ingamewars[3].usa_place = 0;
				GlobalScript.inst.gameState.ingamewars[3].infl1 = 500;
				GlobalScript.inst.gameState.ingamewars[3].infl2 = 500;
				GlobalScript.inst.gameState.data[143] += 6;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 74)
		{
			text2 = "Решение по некоторым вопросам истории КПК со времени образования КНР";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "С 27 по 29 июня 1981 года в Пекине проходил 6-й Пленум Центрального Комитета Коммунистической партии Китая 11-го созыва, на котором присутствовало 195 членов ЦК КПК и 114 кандидатов в члены ЦК КПК, а также 53 приглашенных лица. В повестке дня Пленума было: рассмотрение и принятие \"Решения по некоторым вопросам истории нашей партии со времени образования КНР\". Единогласно принятое пленумом «Решение по некоторым вопросам истории нашей партии со времени образования КНР» с марксистской позиции — позиции диалектического и исторического материализма правильно подвело итоги важнейшим событиям в истории партии за 32 года после образования КНР, проанализировало субъективные факторы и социальные причины возникновения ошибок, дало справедливую оценку места великого вождя и мудрого учителя, товарища Мао Цзэдуна, в истории китайской революции, в полной мере обосновало великое значение идей Мао Цзэдуна как руководящих идей нашей партии. «Решение» подтвердило правильность пути строительства современной социалистической державы, а также указало дальнейшее направление развития дела социализма в нашей стране и работы партии.";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[3] += 80;
				GlobalScript.inst.gameState.data[4] -= 100;
				GlobalScript.inst.gameState.data[92] -= 20;
				GlobalScript.inst.gameState.data[6] += 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
				party_change[0] = 0.24f;
				party_change[1] = 0.24f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic179 in politics)
				{
					if (politic179.traits[0] == 0)
					{
						Politic politic = politic179;
						politic.power += 100;
						politic = politic179;
						politic.loyality += 150;
					}
					else if (politic179.traits[0] == 1)
					{
						Politic politic = politic179;
						politic.power -= 50;
						politic = politic179;
						politic.loyality -= 50;
					}
					else if (politic179.traits[0] == 2)
					{
						Politic politic = politic179;
						politic.power -= 100;
						politic = politic179;
						politic.loyality -= 100;
					}
					else if (politic179.traits[0] == 3)
					{
						Politic politic = politic179;
						politic.power -= 150;
						politic = politic179;
						politic.loyality -= 150;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "С 27 по 29 июня 1981 года в Пекине проходил 6-й Пленум Центрального Комитета Коммунистической партии Китая 11-го созыва, на котором присутствовало 195 членов ЦК КПК и 114 кандидатов в члены ЦК КПК, а также 53 приглашенных лица. В повестке дня Пленума было: рассмотрение и принятие \"Решения по некоторым вопросам истории нашей партии со времени образования КНР\". Единогласно принятое пленумом «Решение по некоторым вопросам истории нашей партии со времени образования КНР» с марксистской позиции — позиции диалектического и исторического материализма правильно подвело итоги важнейшим событиям в истории партии за 32 года после образования КНР, и в особенности «культурной революции», научно проанализировало правильное и ошибочное в руководящих идеях партии в ходе этих событий, проанализировало субъективные факторы и социальные причины возникновения ошибок, дало справедливую оценку места великого вождя и учителя товарища Мао Цзэдуна в истории китайской революции, в полной мере обосновало великое значение идей Мао Цзэдуна как руководящих идей нашей партии.";
				GlobalScript.inst.gameState.data[1] += 100;
				GlobalScript.inst.gameState.data[3] += 80;
				GlobalScript.inst.gameState.data[92] += 10;
				GlobalScript.inst.gameState.data[4] -= 50;
				GlobalScript.inst.gameState.data[6] -= 30;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				party_change[2] = 0.15f;
				party_change[3] = 0.21f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic180 in politics)
				{
					if (politic180.traits[0] == 0)
					{
						Politic politic = politic180;
						politic.loyality += 100;
					}
					else if (politic180.traits[0] == 1)
					{
						Politic politic = politic180;
						politic.power += 100;
						politic = politic180;
						politic.loyality += 100;
					}
					else if (politic180.traits[0] == 2)
					{
						Politic politic = politic180;
						politic.power += 100;
						politic = politic180;
						politic.loyality += 100;
					}
					else if (politic180.traits[0] == 3)
					{
						Politic politic = politic180;
						politic.loyality += 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "С 27 по 29 июня 1981 года в Пекине проходил 6-й Пленум Центрального Комитета Коммунистической партии Китая 11-го созыва, на котором присутствовало 195 членов ЦК КПК и 114 кандидатов в члены ЦК КПК, а также 53 приглашенных лица. В повестке дня Пленума было: рассмотрение и принятие \"Решения по некоторым вопросам истории нашей партии со времени образования КНР\". «Решение по некоторым вопросам истории нашей партии со времени образования КНР» вызвало чрезвычайно серьезные споры и было принято с незначительным большинством голосов. Оно с марксистской позиции — позиции диалектического и исторического материализма подвело итоги важнейшим событиям в истории партии за 32 года после образования КНР, и в особенности «культурной революции», раскритиковало все ошибочное в руководящих идеях партии в ходе этих событий, проанализировало субъективные факторы Мао Цзэдуна и социальные причины возникновения ошибок, дало справедливую оценку места Мао Цзэдуна в истории китайской революции - места \"восточного деспота и тирана\", в полной мере обосновало великое значение идей Маркса-Энгельса-Ленина как руководящих идей нашей партии и отвергло антимарксистские взгляды Мао Цзэдуна.";
				GlobalScript.inst.gameState.data[1] -= 150;
				GlobalScript.inst.gameState.data[3] -= 150;
				GlobalScript.inst.gameState.data[57] -= 200;
				GlobalScript.inst.gameState.data[92] += 40;
				GlobalScript.inst.gameState.data[4] += 250;
				GlobalScript.inst.gameState.data[6] -= 60;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 250;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 30;
				gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 50;
				party_change[4] = 0.3f;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic181 in politics)
				{
					if (politic181.traits[0] == 0)
					{
						Politic politic = politic181;
						politic.loyality -= 300;
					}
					else if (politic181.traits[0] == 1)
					{
						Politic politic = politic181;
						politic.loyality -= 300;
					}
					else if (politic181.traits[0] == 2)
					{
						Politic politic = politic181;
						politic.loyality -= 300;
					}
					else if (politic181.traits[0] == 3)
					{
						Politic politic = politic181;
						politic.loyality += 150;
					}
				}
				GlobalScript.inst.gameState.number_event = 4;
				load_scene_after_click = "Event";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "С 27 по 29 июня 1981 года в Пекине проходил 6-й Пленум Центрального Комитета Коммунистической партии Китая 11-го созыва, на котором присутствовало 195 членов ЦК КПК и 114 кандидатов в члены ЦК КПК, а также 53 приглашенных лица. В повестке дня Пленума было: рассмотрение и принятие \"Решения по некоторым вопросам истории нашей партии со времени образования КНР\". Пленум рассмотрел \"Решение\" и счел его \"недостаточно подготовленным и достаточно ошибочным\", отправив на доработку комиссии.";
				if (GlobalScript.inst.gameState.data[56] < 2)
				{
					text += "Комиссия исправила перегибы в тексте, выделив руководящую роль Председателя Мао в китайской революции и развитии страны, однако указав на перегибы как правого, так и левого толка. Такой вариант был принят Пленумом.";
					GlobalScript.inst.gameState.data[1] += 20;
					GlobalScript.inst.gameState.data[3] += 50;
					GlobalScript.inst.gameState.data[92] -= 20;
					GlobalScript.inst.gameState.data[4] -= 60;
					GlobalScript.inst.gameState.data[90] = 0;
					GlobalScript.inst.gameState.data[6] += 40;
					party_change[0] = 0.24f;
					party_change[1] = 0.24f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic182 in politics)
					{
						if (politic182.traits[0] == 0)
						{
							Politic politic = politic182;
							politic.power += 100;
							politic = politic182;
							politic.loyality += 150;
						}
						else if (politic182.traits[0] == 1)
						{
							Politic politic = politic182;
							politic.power -= 50;
							politic = politic182;
							politic.loyality -= 50;
						}
						else if (politic182.traits[0] == 2)
						{
							Politic politic = politic182;
							politic.power -= 100;
							politic = politic182;
							politic.loyality -= 100;
						}
						else if (politic182.traits[0] == 3)
						{
							Politic politic = politic182;
							politic.power -= 150;
							politic = politic182;
							politic.loyality -= 200;
						}
					}
				}
				else if (GlobalScript.inst.gameState.data[56] == 2 || GlobalScript.inst.gameState.data[56] == 1)
				{
					text += "Комиссия исправила перегибы в тексте, руководствуясь принципом \"выправления всего неправильного и закрепления всего правильного\", дав взвешенную оценку периоду 40-70-х годов. Такой вариант был принят Пленумом.";
					GlobalScript.inst.gameState.data[1] += 80;
					GlobalScript.inst.gameState.data[3] += 40;
					GlobalScript.inst.gameState.data[90] = 1;
					GlobalScript.inst.gameState.data[92] += 10;
					GlobalScript.inst.gameState.data[4] -= 50;
					GlobalScript.inst.gameState.data[6] -= 20;
					party_change[2] = 0.15f;
					party_change[3] = 0.21f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic183 in politics)
					{
						if (politic183.traits[0] == 0)
						{
							Politic politic = politic183;
							politic.loyality += 100;
						}
						else if (politic183.traits[0] == 1)
						{
							Politic politic = politic183;
							politic.power += 100;
							politic = politic183;
							politic.loyality += 100;
						}
						else if (politic183.traits[0] == 2)
						{
							Politic politic = politic183;
							politic.power += 100;
							politic = politic183;
							politic.loyality += 100;
						}
						else if (politic183.traits[0] == 3)
						{
							Politic politic = politic183;
							politic.loyality += 100;
						}
					}
				}
				else if (GlobalScript.inst.gameState.data[56] > 2)
				{
					text += "Комиссия исправила перегибы в тексте, ориентируясь на \"секретный доклад\" Хрущева 1956 года, а также документы западных спецслужб и советские публикации, изобличающие Мао Цзэдуна и его время. Такой вариант был принят Пленумом.";
					GlobalScript.inst.gameState.data[1] -= 100;
					GlobalScript.inst.gameState.data[3] -= 150;
					GlobalScript.inst.gameState.data[90] = 2;
					GlobalScript.inst.gameState.data[57] -= 200;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 30;
					GlobalScript.inst.gameState.data[92] += 40;
					GlobalScript.inst.gameState.data[4] += 200;
					GlobalScript.inst.gameState.data[6] -= 50;
					party_change[4] = 0.3f;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic184 in politics)
					{
						if (politic184.traits[0] == 0)
						{
							Politic politic = politic184;
							politic.loyality -= 300;
						}
						else if (politic184.traits[0] == 1)
						{
							Politic politic = politic184;
							politic.loyality -= 300;
						}
						else if (politic184.traits[0] == 2)
						{
							Politic politic = politic184;
							politic.loyality -= 300;
						}
						else if (politic184.traits[0] == 3)
						{
							Politic politic = politic184;
							politic.loyality += 150;
						}
					}
					GlobalScript.inst.gameState.number_event = 4;
					load_scene_after_click = "Event";
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "С 27 по 28 июня 1981 года в Пекине проходил 6-й Пленум Центрального Комитета Коммунистической партии Китая 11-го созыва, на котором присутствовало 195 членов ЦК КПК и 114 кандидатов в члены ЦК КПК, а также 53 приглашенных лица. В повестке дня Пленума было: рассмотрение и принятие \"Решения по некоторым вопросам истории нашей партии со времени образования КНР\". По просьбе Председателя ЦК КПК, вопрос был снят с повестки дня по причине \"устарелости и маловажности\". Пленум завершает свою работу.";
				GlobalScript.inst.gameState.data[1] -= 70;
				GlobalScript.inst.gameState.data[3] -= 30;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				GlobalScript.inst.gameState.data[4] += 70;
				GlobalScript.inst.gameState.data[90] = 3;
				GlobalScript.inst.gameState.data[8] -= 200;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic185 in politics)
				{
					Politic politic = politic185;
					politic.loyality -= 100;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 75)
		{
			text2 = "Проблемы иракского атома";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Сразу после авианалета Саддам Хусейн выступил на экстренном заседании Совета Министров Ирака с яркой речью, в которой заявил: \"Удар, который был нанесен сегодня по реактору \"Таммуз\", не был для нас внезапным. Но, естественно, становится больно, потому что это один из добрых плодов революции, о котором мы долгое время много заботились политически, научно и экономически... Все это не потому, что они боятся иракской атомной бомбы, как говорит главарь банды, находящейся в Тель-Авиве, а потому что они боятся научного, социального, экономического, политического, уравновешенного и компактного развития, которое серьезно направлено к цели построения нового Ирака... Международная сторона у нас отсутствует, поэтому отложим все оправдания, потому что удар был нанесен против нас... Вы понимаете, почему возникла война - не только потому, чтобы направить удар по иракскому атомному реактору, а чтобы остановить иракский подъем..., и понимаете, почему война будет продолжаться...\". Мы полностью поддержали Саддама и осудили \"бандитское нападение американских наймитов из Израиля\", а также предложили Ираку экономическую и военную помощь, на что Хусейн с радостью согласился. Хотя Ирак и продолжает вести многовекторную внешнюю политику, не сокращая сотрудничество с СССР и США, но определенный крен в нашу сторону наметился... Американские союзники на Ближнем Востоке в бешенстве, но сами США отреагировали на удивление спокойно...";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[8] -= 80;
				GlobalScript.inst.gameState.data[6] += 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GlobalScript.inst.gameState.allcountries[14].Torg = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Сразу после авианалета Саддам Хусейн выступил на экстренном заседании Совета Министров Ирака с яркой речью, в которой заявил: \"Удар, который был нанесен сегодня по реактору \"Таммуз\", не был для нас внезапным. Но, естественно, становится больно, потому что это один из добрых плодов революции, о котором мы долгое время много заботились политически, научно и экономически... Все это не потому, что они боятся иракской атомной бомбы, как говорит главарь банды, находящейся в Тель-Авиве, а потому что они боятся научного, социального, экономического, политического, уравновешенного и компактного развития, которое серьезно направлено к цели построения нового Ирака\". Ирак обратился в ООН, требуя осудить действия Израиля, причем Саддама поддержали обе сверхдержавы - СССР и США. Совет Безопасности потребовал от Израиля выплатить компенсацию и воздержаться от подобных акций в будущем. В самом Израиле многие из членов оппозиции, и во главе их Шимон Перес, критиковали решение правительства. Однако министр обороны Ариэль Шарон твердо ответил на критику: \"Составным элементом нашей военной политики является твердое намерение предотвратить доступ вражеских государств к ядерному оружию. Поэтому мы должны ликвидировать эту угрозу в зародыше\". По нашим данным, Ирак увеличил закупки оружия в СССР и США, взяв курс на качественное переоснащение своей армии.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Сразу после авианалета Саддам Хусейн выступил на экстренном заседании Совета Министров Ирака с яркой речью, в которой заявил: \"Удар, который был нанесен сегодня по реактору \"Таммуз\", не был для нас внезапным. Все это не потому, что они боятся иракской атомной бомбы, как говорит главарь банды, находящейся в Тель-Авиве, а потому что они боятся научного, социального, экономического, политического, уравновешенного и компактного развития, которое серьезно направлено к цели построения нового Ирака...\". Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " решил воспользоваться сложившейся ситуацией. Мы предложили Ираку свою помощь в возобновлении атомной программы, на что Саддам с радостью согласился. В ядерном центре имени Июльской революции (пустыня Тхувайтха) появились китайские работники, а вскоре туда был доставлен и атомный реактор CNP-200 (при этом была предотвращена попытка агентов \"Моссада\" взорвать корабль, на котором мы его транспортировали). Работы над атомным оружием идут полным ходом, по рассчетам наших ученых, к 1988 году у Ирака будет 3 атомных бомбы, а в 1995 году - уже 5. Израиль в бешенстве и вовсю обвиняет \"великоханьских шовинистов\" в \"мировом гегемонизме\", но вот СССР и США никак пока не отреагировали на это...";
				GlobalScript.inst.gameState.allcountries[14].Torg = true;
				if (GlobalScript.inst.gameState.influencePRC >= 500)
				{
					text += " Теперь, когда у Ирака может появиться собственное атомное оружие, Саддам Хусейн начал масштабную кампанию по \"возвращению всего отобранного империалистами\" и \"очищению нации от врагов и засланцев сионистов\". Ирак усиленно милитаризируется и начинает сокращать дипломатические связи, уходя в международную изоляцию...";
					GlobalScript.inst.gameState.data[1] += 80;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.power -= 10;
					GlobalScript.inst.gameState.data[6] += 80;
					GlobalScript.inst.gameState.data[8] -= 150;
					GlobalScript.inst.gameState.data[9] -= 100;
					GlobalScript.inst.gameState.data[143] += 2;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.allcountries[14].Gosstroy = 0;
					GlobalScript.inst.gameState.allcountries[14].SubGosstroy = 10;
					GlobalScript.inst.gameState.allcountries[14].prosov = false;
				}
				else
				{
					text += " Иракская атомная программа привлекла внимание МАГАТЭ. Она обвинила Ирак в нарушении ДНЯО и потребовала вести работы только по мирному атому под контролем международных организаций. Так как СССР и США поддержали это требование, Хусейн был вынужден согласиться. Однако начать мирную программу также не удалось - 1 декабря ВВС Израиля совершили повторный авианалет и реактор был полностью уничтожен. Из-за страха потери власти Саддам решил перейти на нашу сторону.";
					GlobalScript.inst.gameState.data[1] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GlobalScript.inst.gameState.data[6] += 80;
					GlobalScript.inst.gameState.data[8] -= 150;
					GlobalScript.inst.gameState.data[9] -= 100;
					GlobalScript.inst.gameState.allcountries[14].prosov = false;
					GlobalScript.inst.gameState.allcountries[14].Torg = true;
					GlobalScript.inst.gameState.allcountries[14].proprc = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Мы полностью одобрили израильский авиаудар по реактору \"Таммуз\" и осудили Саддама Хусейна за его курс на милитаризм, великоарабский шовинизм и подавление курдского нацменьшинства. Это вызвало откровенное непонимание в партии и народе, не ожидавших столь открытой поддержки Израиля после стольких лет критики его политики. В ответ, Совет Министров Ирака выпустил коммюнике, в котором обвинил Китай в \"поддержке банды сионистов из Тель-Авива\" и принял решение о разрыве дипломатических отношений. Наше посольство было силой выдворено из Багдада, а Ирак увеличил закупки оружия в СССР и США, взяв курс на качественное переоснащение своей армии. Похоже, на Ближнем Востоке зажигается пламя новой войны...";
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[6] -= 40;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				GlobalScript.inst.gameState.data[4] += 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 150;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 50;
				GlobalScript.inst.gameState.allcountries[14].Torg = false;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 76)
		{
			text2 = "Падающего - подтолкни!";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Министерство иностранных дел КНР выпустило коммюнике, в котором официально выразило поддержку \"протестующим за свои законные демократические права\" косовским демонстрантам. Это вызвало резкое возмущение Югославии, обвинившей Китай во вмешательстве в свои внутренние дела, и возглавляемого ею Движения неприсоединения, которое обвинило Китай в \"маоистском гегемонизме\". СССР и США проигнорировали это, во-многом из-за \"самостоятельной\" позиции СФРЮ, так и не вошедшей ни в один из лагерей. В Косово было введено чрезвычайное положение и туда вошли части ЮНА, которые к 3 апреля подавили все выступления и восстановили в крае порядок. Были найдены доказательства вмешательства Албании. Начата массовая чистка сепаратистов.";
				GlobalScript.inst.gameState.data[6] += 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = ((!GlobalScript.inst.dlc[3]) ? string.Format(GlobalScript.inst.new_events_text[900], "\n") : "На закрытом заседании Политбюро ЦК КПК было решено воспользоваться проблемами Югославии и оказать полномасштабную помощь косовским сепаратистам. В качестве \"передаточного пункта\" решено использовать посольство КНР в Белграде. Получив от нас оружие и деньги, косовские сепаратисты смогли организовать вооруженное сопротивление частям ЮНА и Народной милиции. В Приштине начались самые настоящие уличные бои, в которых югославские военные активно применяли артиллерию и авиацию, в результате чего город был разрушен. Репортажи \"Приштина горит!\" разошлись по всему миру, что нанесло сильный удар по международному престижу СФРЮ, И, хотя мятеж все-таки к июню удалось подавить, на восстановление края нужны огромные средства, которых у Югославии нет. |В апреле 1981 года на заседании Президиума СФРЮ и Союзного совета по защите конституционного порядка, Л. Колишевский заявил: \"Мы должны до конца осознавать ошибочность и крайнюю реакционность тезиса – чем слабее Сербия, тем сильнее Косово (или какая-либо другая наша республика). Также, как и тезис – чем меньше автономность Косово в составе Сербии, тем сильнее Сербия. Это можно сказать и о тезисе – слабая Сербия – сильная Югославия\". В стране начинают усиливаться позиции националистов...");
				GlobalScript.inst.gameState.data[8] -= 100;
				GlobalScript.inst.gameState.data[9] -= 100;
				GlobalScript.inst.gameState.data[86] -= 4;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наш посол в Тиране прибыл к товарищам Энверу Ходжа и Рамизу Алия (партийному куратору Сигурими), передав им наше предложение. ";
				text += "Они согласились на нашу помощь. В Албанию прибыла группа сотрудников МГБ КНР, которая быстро наладила взаимодействие с Сигурими. В результате, хотя ЮНА и удалось подавить мятеж, полностью утихомирить край так и не получилось. Мы сможем потом ещё раз инспирировать там беспорядки.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 10;
				GlobalScript.inst.gameState.data[86] -= 2;
				GlobalScript.inst.gameState.data[8] -= 50;
				GlobalScript.inst.gameState.data[9] -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В Косово было введено чрезвычайное положение и туда вошли части ЮНА, которые к 3 апреля подавили все выступления и восстановили в крае порядок.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 77)
		{
			text2 = "Плевок в лицо, удар в челюсть и пулю в голову";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Используя находящиеся у него в руках госаппарат и Сигурими, Шеху сумел мобилизовать своих сторонников и изолировать Ходжу после чего провёл внеочередной съезд ЦК АПТ, где заявил, что 1-й секретарь по состоянию здоровья какое-то время не сможет исполнять свои обязанности. Его противникам же пришлось в лучшем случае расстаться со своими местами в партии и правительстве, однако многие из них попросту угодили в тюрьмы Сигурими или же скончались при странных обстоятельствах. А вскоре было объявлено и о смерти Ходжи от обострившейся болезни, после чего Шеху не составило труда получить пост 1-го секретаря ЦК АПТ. Он уже начал пока осторожные переговоры с Югославией, СССР и странами соцлагеря, которые похоже сами рады такой смене руководства, хотя во внутренней политике Албании ничего особо не изменилось.";
				if (!GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					text += " А с КНР Шеху восстановил отношения значительно быстрее, уже наладив торговлю и пригласив в страну наших советников.";
				}
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[9] -= 80;
				GlobalScript.inst.gameState.data[6] += 10;
				GlobalScript.inst.gameState.data[60] = 1;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GlobalScript.inst.gameState.allcountries[20].Torg = true;
				GlobalScript.inst.gameState.allcountries[20].proprc = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В итоге отношения между Шеху и Ходжей продолжили обостряться, а 18 декабря 1981-го было объявлено о самоубийстве Шеху, после чего он был заочно обвинён в измене и шпионаже в пользу США, СССР и Югославии. На посту премьер-министра его сменил безынициативный и лояльный Адиль Чарчани.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				GlobalScript.inst.gameState.allcountries[20].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[20].SubGosstroy = 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В итоге отношения между Шеху и Ходжей продолжили обостряться, а 18 декабря 1981-го было объявлено о самоубийстве Шеху, после чего он был заочно обвинён в измене и шпионаже в пользу США, СССР и Югославии. На посту премьер-министра его сменил безынициативный и лояльный Адиль Чарчани. Мы всё это время поддерживали действия Ходжи и приветствовали избавление Албании от шпиона Шеху, за что получили благодарности из Тираны.";
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.allcountries[20].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[20].SubGosstroy = 10;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 78)
		{
			text2 = "Вечный президент";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "С помощью наших спецслужб и поставок нашего оружия КПФ и НДД смогли развернуть масштабную агитацию и протесты, сопровождавшиеся всплеском активности партизан. К этим недовольствам вскоре присоединились и другие политические силы и простые граждане. Разумеется, протесты вскоре были жёстко подавлены полицией, а партизанское наступление удалось сдержать армией, однако, похоже, мы нанесли серьёзный удар режиму Маркоса, не ожидавшему столь внезапного и наглого вмешательства КНР. В конечном итоге ему удалось выиграть президентские выборы, набрав 52% голосов, однако в своих действиях ему теперь придётся быть осторожнее, да и влияние КПФ заметно выросло. Возможно, помогая им и дальше, мы всё таки увидим победу филиппинской революции...";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[9] -= 100;
				GlobalScript.inst.gameState.data[6] += 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GlobalScript.inst.gameState.data[37] += 300;
				GlobalScript.inst.gameState.allcountries[47].Torg = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В итоге Маркосу удалось выиграть президентские выборы, набрав разгромные 88% голосов. Похоже Филиппины ждёт продолжение его политики.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "После того как Маркосу удалось выиграть президентские выборы, набрав разгромные 88% голосов, мы поздравили его с победой и выразили надежду на дальнейшее сближение наших стран, начатое ещё в 1975 году. Маркос был рад воспользоваться нашим предложением, а вот многие группы филиппинских маоистов назвали это предательством, да и влияние КПФ несколько упало.";
				GlobalScript.inst.gameState.data[6] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 50;
				GlobalScript.inst.gameState.data[37] -= 200;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
				GlobalScript.inst.gameState.allcountries[47].Torg = true;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 79)
		{
			text2 = "Режим экономии";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " лично позвонил Брежневу и заявил, что ситуация в Румынии напрямую угрожает делу строительства социализма в Румынии и стабильности всего соцлагеря, а потому в её решении должен участвовать и весь соцлагерь. Советский руководитель поддержал нашу идею, в результате чего было созвано внеочередное заседание СЭВ, где было решено предоставить Румынии помощь для выплаты долгов в виде безвозмездной денежной помощи и льготных условий импорта-экспорта для Румынии в СЭВ (основные издержки, разумеется, понесли мы и Советский Союз). Чаушеску поблагодарил нас и остальных членов СЭВ за помощь и уже объявил о корректировке режима экономии, направленной на его смягчение. Разумеется даже небольшие меры экономии вызвали недовольство румынских граждан, но ничего, с чем не мог бы справиться Чаушеску. По нашим подсчётам, такими темпами он сможет выплатить долги к концу 80-х без серьёзных последствий для экономики и уровня жизни";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[8] -= 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 150;
				GlobalScript.inst.gameState.allcountries[5].Torg = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Несмотря на прибыльность данных мер, они уже вызвали спад роста румынской экономики и падение уровня жизни, что вызывает массовые недовольства румынского населения. Чаушеску пока неплохо с ними справляется, но кто знает, чем это кончится...";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Пользуясь нашими хорошими отношениями с Румынией, мы предложили Чаушеску масштабную материальную помощь для облегчения бремени выплаты долгов, которую он с радостью принял. Нам пришлось изрядно раскошелиться, но в итоге он объявил о корректировке режима экономии, направленной на его смягчение. Разумеется даже небольшие меры экономии вызвали недовольство румынских граждан, но ничего, с чем не мог бы справиться Чаушеску. А появившиеся возможности для импорта он использовал для расширения торговли с нами.";
				GlobalScript.inst.gameState.data[6] += 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GlobalScript.inst.gameState.data[8] -= 300;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.allcountries[5].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[5].SubGosstroy = 10;
				GlobalScript.inst.gameState.allcountries[5].Torg = true;
				GlobalScript.inst.gameState.allcountries[5].proprc = true;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 80)
		{
			text2 = "XII съезд КПК";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "На съезде " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " провозгласил целью партии очищение социалистической системы от правых и левых перегибов. Он резко выступил против тех, кто требовал до основания сломать существующую систему и перестроить страну по западному образцу. В ходе изменений в Уставе было закреплено увеличение кандидатского стажа до 5 лет, а стажа кандидата в члены Политбюро - до 8 лет. В состав вновь избранного ЦК КПК вошли 210 членов и 138 кандидатов в члены ЦК КПК.";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[6] += 5;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В Отчетном докладе ЦК КПК съезду, товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " сделал основной акцент на итогах VI Пленума ЦК КПК 11 созыва и принятии \"Решения по некоторым вопросам истории КПК со времени образования КНР\", в котором \"со всей ответственностью был изучен и обобщен путь нашей партии с 1949 года, успехи и ошибки, допущенные в социалистическом строительстве, а также место товарища Мао Цзэдуна, который, в силу различных факторов, допустил или позволил допустить эти ошибки\". Сразу же после съезда, в СМИ сократилось упоминание Мао Цзэдуна, ряд его работ (\"Маленькая красная книжица\", \"О десяти важнейших взаимоотношениях\", \"Полемика о генеральной линии международного коммунистического движения\") был постепенно изъят из библиотек, а также прекращено их переиздание, обязательное изучение \"маоцзэдунидей\" было изменено на факультативное. Хотя Мао Цзэдун никоим образом не вычеркнут из истории КНР и КПК, а за его критику вполне можно угодить в тюрьму, но его роль сведена к роли Владимира Ильича Ленина в СССР - эдакого \"доброго дедушки и лидера Революции\" - и не более того.";
				GlobalScript.inst.gameState.data[1] += 80;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[6] -= 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
				GlobalScript.inst.gameState.data[57] -= 80;
				GlobalScript.inst.gameState.modifies[6].active = false;
				GlobalScript.inst.gameState.party_ideology[1] -= (int)((float)GlobalScript.inst.gameState.party_ideology[1] * 0.05f);
				GlobalScript.inst.gameState.party_ideology[0] -= (int)((float)GlobalScript.inst.gameState.party_ideology[0] * 0.1f);
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic186 in politics)
				{
					if (politic186.traits[0] == 0)
					{
						Politic politic = politic186;
						politic.loyality -= 200;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В последний день работы XII съезда КПК, товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " попросил делегатов остаться на ещё одно заседание - закрытое. На этом заседании он в полной тишине зачитал доклад \"О культе личности Мао Цзэдуна и преодолении его последствий\", в котором основатель КНР был обвинен в \"извращении марксизма-ленинизма, установлении культа личности, массовом терроре, борьбе с политическими противниками, искажении социалистической законности, поддержке группы Линь Бяо\" и т.д. Делегаты расходились в подавленном состоянии, приняв доклад без его обсуждения. В дальнейшем, он был прочитан во всех парторганизациях КПК, вызвав шок и отторжение. Начался снос памятников Мао Цзэдуну, изъятие из библиотек и книготорговли его произведений и портретов, в СМИ публикуются разоблачительные материалы о \"Великом Кормчем\". СССР и США одобрили наше развенчание культа личности Мао, однако миллионы недовольных начинают сопротивляться. Широкую популярность получило движение \"Туйдан\" (массовый выход из КПК, зачастую сопровождаемый публичным уничтожением партбилета), а маоистские движения на Западе одно за другим обвиняют нас в \"хрущевском ревизионизме\" и \"предательстве\". Наши позиции серьезно подорваны и внутри страны, и вне её, а оставшаяся без идеологической опоры партия явно не станет Вас защищать, если вдруг произойдет попытка переворота...";
				GlobalScript.inst.gameState.data[1] -= 300;
				GlobalScript.inst.gameState.data[3] -= 450;
				GlobalScript.inst.gameState.data[6] -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 150;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 300;
				GlobalScript.inst.gameState.data[57] -= 450;
				GlobalScript.inst.gameState.data[4] += 400;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 300;
				party_change[3] = 0.15f;
				party_change[4] = 0.6f;
				GlobalScript.inst.gameState.modifies[6].active = false;
				GlobalScript.inst.gameState.modifies[6].active = false;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic187 in politics)
				{
					if (politic187.traits[0] == 0)
					{
						Politic politic = politic187;
						politic.loyality -= 600;
					}
					else if (politic187.traits[0] == 1)
					{
						Politic politic = politic187;
						politic.loyality -= 400;
					}
					else if (politic187.traits[0] == 2)
					{
						Politic politic = politic187;
						politic.loyality -= 300;
					}
					else if (politic187.traits[0] == 3)
					{
						Politic politic = politic187;
						politic.loyality += 200;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 81)
		{
			text2 = "Венгерская рапсодия";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Вы лично позвонили Яношу Кадару и сообщили о решении Постоянного комитета Всекитайского совета народных представителей - выделить Венгрии кредит в размере 3,5 млрд. долларов по очень низкой процентной ставке. Это позволило стране избежать дефолта и не прибегнуть к новым займам. Кадар, как глава Государственного совета ВНР, выразил китайскому народу огромную благодарность от имени всего венгерского народа, но вот СССР и США не в восторге от этого, а их пресса уже вовсю пишет о \"китайской экономической экспансии в Европе\".";
				GlobalScript.inst.gameState.data[8] -= 300;
				GlobalScript.inst.gameState.data[6] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 80;
				GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Идеологический отдел ЦК КПК санкционировал печать большого количества критических материалов об положении дел в Венгрии. \"Гуляш-социализм\" был объявлен \"дутой рыночной ревизией\", Кадару припомнили его участие в контрреволюционном путче 1956 года и поддержку группы Имре Надя, ВСРП окрестили \"лжемарксистской партией социал-ренегатов\", а социалистический строй в Венгрии - \"построенной на американские деньги декорацией\". Исходя из всего этого, делался вывод, что все рыночные реформы - это ревизионизм и путь в экономическую пропасть. Партия и народ не приняли новой раскрутки уже порядком надоевшей пропаганды, а Венгрия прямо вырзила нам категорический протест, в чем её поддержал СССР. Кажется, мы не совсем этого хотели...";
				GlobalScript.inst.gameState.data[1] -= 50;
				GlobalScript.inst.gameState.data[4] -= 20;
				GlobalScript.inst.gameState.data[3] -= 50;
				GlobalScript.inst.gameState.data[6] += 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 30;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 80;
				GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Сегодня утром посол КНР в Будапеште прибыл к Яношу Кадару и от нашего имени предложил беспроцентный кредит в размере 3,5 млрд. долларов. Кадар был готов согласиться сразу же, но последующие слова посла его отрезвили - в обмен на кредит, Политбюро ЦК ВСРП должно реабилитировать группу Бела Биску, восстановив их в партии и на должностях, а самого Белу кооптировать в свои ряды. Это вызвало резкий протест венгерского руководителя и, в результате долгой словесной перепалки, удалось достичь лишь компромисса - ряд соратников Биску кооптируются в ЦК, а Венгрия получает кредит в 1,5 млрд. долларов. Это позволило стране избежать немедленного дефолта, но все-таки пришлось взять новый займ у МВФ. Благодаря нам, теперь в ВСРП появилась левая оппозиция, но ей понадобится много времени на окончательное оформление... Помимо этого, СССР очень недоволен нашим вмешательством в свою сферу влияния.";
				GlobalScript.inst.gameState.data[8] -= 150;
				GlobalScript.inst.gameState.data[9] -= 80;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
				GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Хуа Гофэн вызвал посла ВНР в Пекине и передал ему письмо к Яношу Кадару, в котором предложил взять госдолг ВНР на Китай для избежания дефолта и выдать беспроцентный кредит в 4,5 млрд. долларов - но в обмен на реабилитацию группы Бела Биску и кооптацию самого Биску в Политбюро ЦК ВСРП. Одновременно наша агентура спровоцировала брожение в подразделениях \"Рабочей милиции\" (парамилитарной организации ВСРП, в которой были сильны левоконсервативные настроения), а также вбросила компромат на главного идеолога венгерских реформ - Режё Ньерша (который являлся социал-демократом со стажем и был министром в правительстве Имре Надя). Поняв, что отказ от помощи Китая может спровоцировать новый 1956 год, Кадар был вынужден согласиться. Бела Биску с нашей помощью достаточно оперативно организовал левую оппозицию, а Ньершу пришлось уйти из политики. Похоже, в ВСРП назревает раскол, сдерживает который пока только лишь живой Кадар... |Под давлением левой оппозиции и желая сохранить хотя бы внешнее единство партии, Кадар объявил о \"многовекторности\" внешней политики Венгрии и начал налаживать с нами культурные и торговые связи. СССР и США в бешенстве, а мы несколько укрепили свое влияние в Европе. Правда, нам теперь придется выполнить венгерские долговые обязательства...";
				GlobalScript.inst.gameState.data[8] -= 450;
				GlobalScript.inst.gameState.data[9] -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
				leader.support--;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 200;
				GlobalScript.inst.gameState.allcountries[4].prosov = false;
				GlobalScript.inst.gameState.allcountries[4].Torg = true;
				GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Мы не стали никак вмешиваться в дела Венгрии. Стране удалось избежать дефолта, взяв новые займы у МВФ, что лишь отсрочило негативные тенденции - но на достаточно долгий срок, чтобы мы не могли на это повлиять. |\"Одновременно, как считают венгерские товарищи, следует углублять участие Венгрии в международной кооперации, с тем, чтобы не изобретать то, что уже давно открыли в других странах\".";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
				GlobalScript.inst.gameState.allcountries[27].isMonatchy = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 6)
			{
				text = "Договорившись с определённой частью Политбюро кулуарно, мы смогли убедить их, что только с китайской помощью они смогут выкарабкаться из долговой ямы, созданной совместно как правительством Яноша Кадара, так и Кароя Гроса. В итоге они согласились с нашим предложением сменить Кароя Гроса на Имре Пожгая проведя чрезвычайный съезд партии и раскритиковав Гроса. В итоге Янош Кадар ушёл на пенсию с номинального поста Председателя ВСРП, а его место занял Карой Грос. Реальным же правителем страны стал Генеральный Секретарь Имре Пожгай, понимающий кому обязан своим положением и осознающий в чьих руках находятся долговые обязательства Венгрии.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 250;
				GlobalScript.inst.gameState.allcountries[4].isMonatchy = true;
				GlobalScript.inst.gameState.allcountries[4].Torg = true;
				GlobalScript.inst.gameState.allcountries[4].proprc = true;
				GlobalScript.inst.gameState.data[9] -= 80;
				GlobalScript.inst.gameState.data[8] -= 450;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 82)
		{
			text2 = "Фолклендская война";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "3 апреля Совбезом ООН была принята резолюция 502, требующая вывести с островов аргентинские войска, но, несмотря на это, в победу Британии, кажется, никто не верит. Но может стоит помочь Аргентине, хоть там и сидят жестокие антикоммунистические диктаторы, чтобы ещё раз ударить по колониализму?";
				GlobalScript.inst.gameState.ingamewars[6].name_war = "Фолклендская война";
				GlobalScript.inst.gameState.ingamewars[6].is_going = true;
				GlobalScript.inst.gameState.ingamewars[6].side1 = "Аргентина";
				GlobalScript.inst.gameState.ingamewars[6].side2 = "Британия";
				GlobalScript.inst.gameState.ingamewars[6].ussr_place = -1;
				GlobalScript.inst.gameState.ingamewars[6].usa_place = 1;
				GlobalScript.inst.gameState.ingamewars[6].infl1 = 400;
				GlobalScript.inst.gameState.ingamewars[6].infl2 = 600;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 83)
		{
			text2 = "Проблемы ставропольского агронома";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Сегодняшний номер \"Жэньминь Жибао\" вышел с редакционной статьей \"Реформатор в Политбюро ЦК КПСС\", в которой Фёдор Кулаков был назван \"лжемарксистом-самоуправленцем, титовским \"коммунистом\", опасным врагом всего международного коммунистического и рабочего движения\". Особый упор в статье был сделан на то, что Кулаков может с высокой вероятностью возглавить СССР после смерти Леонида Брежнева. Одновременно наши спецслужбы организовали утечку информации об реформистских устремлениях Кулакова в ЦК КПСС. На Июльском (1977) Пленуме ЦК КПСС, Фёдор Кулаков был подвергнут критике и лишен всех занимаемых постов. От пережитого у него обострилась болезнь желудка, вызвавшая ослабление нервной системы, и в ночь на 17 июля 1977 года он скоропостижно скончался от паралича сердца. Таким образом, мы сильно ослабили реформистское крыло КПСС...";
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[9] -= 50;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
				leader.support--;
				GlobalScript.inst.gameState.data[149] = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.empires[1].relations >= 500)
				{
					text = "Мы организовали масштабную кампанию по очернению Кулакова в СМИ. Он был заклеймен, как \"коррупционер, бюрократ, титовец, лжекоммунист, карьерист, приспособленец, злейший враг КПСС и КПК, волк в овечьей шкуре\" и т.д. Товарищ Председатель в одном из выступлений мимоходом обмолвился, что, если \"такие люди, как Фёдор Кулаков, возглавят Советский Союз - нам с ними не о чем будет разговаривать, так как они настроены против нас, против Коммунистической партии Китая, против китайского народа\". Это вызвало в ЦК КПСС сильное подозрение, Кулаков был вызван в Комитет партийного контроля для беседы с его главой Арвидом Пельше. Тот, объединив усилия с всесильным шефом КГБ Юрием Андроповым, смог пробить через Политбюро решение об назначении Кулакова на пост Первого секретаря ЦК Компартии Молдавии - фактически, в почетную ссылку. Выдвиженцев Кулакова уже начали снимать с постов и переводить на более низкие должности. Таким образом, он нам больше не помеха...";
					GlobalScript.inst.gameState.data[1] += 50;
					GlobalScript.inst.gameState.data[8] -= 20;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support--;
					GlobalScript.inst.gameState.data[149] = 1;
				}
				else
				{
					text = "Мы организовали масштабную кампанию по очернению Кулакова в СМИ. Он был заклеймен, как \"коррупционер, бюрократ, титовец, лжекоммунист, карьерист, приспособленец, злейший враг КПСС и КПК, волк в овечьей шкуре\" и т.д. Товарищ Председатель в одном из выступлений мимоходом обмолвился, что, если \"такие люди, как Фёдор Кулаков, возглавят Советский Союз - нам с ними не о чем будет разговаривать, так как они настроены против нас, против Коммунистической партии Китая, против китайского народа\". Однако Кулаков, узнав об этом, не растерялся, как мы планировали, а выступил на Пленуме ЦК КПСС с яркой речью, в которой обвинил Китай в \"распространении клеветы на ленинский Центральный Комитет, маоистском гегемонизме, стремлении расколоть КПСС и создать альтернативную маоистскую \"лжекомпартию\", провести тихую контрреволюцию в Советском Союзе и оккупировать Сибирь и Дальний Восток\". Этой примитивной ложью он смог запугать большинство членов Политбюро, включая Брежнева, и обелить себя.";
					GlobalScript.inst.gameState.data[8] -= 20;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "И ничего не произошло. Кулаков продолжает занимать свой пост, продвигая наверх реформистски настроенных партийцев во главе со своим соратником по Ставрополью - Михаилом Горбачёвым.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 84)
		{
			text2 = "Наш старый партизан...";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "В 14:35 Петр Машеров выехал от здания ЦК КПБ в сторону города Жодино на автомобиле ГАЗ-13 «Чайка», управлял которым 60-летний водитель Е. Зайцев. Машеров сидел рядом с водителем, сзади — офицер охраны майор В.Ф. Чесноков. Вопреки существующим инструкциям, впереди шла не машина ГАИ с соответствующей раскраской и мигалками, а белая «Волга» с сигнально-громкоговорящей установкой, но без мигалок. У поворота на птицефабрику рядом с городом Смолевичи на трассе \"Москва-Минск\" в \"Чайку\" врезался гружённый картошкой самосвал ГАЗ-САЗ-53Б под управлением водителя Н. Пустовита. Никто не уцелел - Машеров, его водитель и охранник погибли на месте, водитель самосвала - скончался от большой потери крови по пути в больницу. Генеральной прокуратурой СССР было проведено расследование, которое исключило умышленный характер преступления. КГБ был несогласен с этим и настаивал на причастность к этому иностранных спецслужб. В ходе конфликта между Прокуратурой (при поддержке МВД) и КГБ вскрылись факты чрезмерной реформистской наклонности Машерова, из-за чего КГБ пришлось уступить, а Андропов потерял некоторое влияние в партаппарате.";
				GlobalScript.inst.gameState.data[9] -= 80;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
				leader.support -= 2;
				GlobalScript.inst.gameState.data[149] = 2;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.empires[1].relations >= 500)
				{
					text = "Наши агенты вышли на контакт с Тихоном Киселевым - Председателем Совмина БССР, вокруг которого объединились недовольные политикой Машерова белорусские партийцы - и передали ему компромат на Машерова (в частности, тот одобрял «косыгинскую» экономическую реформу и требовал разработать систему планирования, которая бы стимулировала экономическую заинтересованность предприятий. Причина была в его стремлении постепенно уйти от административно-командных методов управления экономикой. Также, по инициативе Машерова, в БССР регулярно проводились семинары по различным проблемам народного хозяйства, не согласованные с ЦК КПСС). Киселев, являясь одновременно и заместителем Председателя Совета Министров СССР, добился встречи с Михаилом Сусловым и передал ему эту информацию. Машеров был вызван в Москву и подвергнут \"пропесочке\", лишен должности и отправлен на пенсию.";
					GlobalScript.inst.gameState.data[8] -= 50;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support--;
					GlobalScript.inst.gameState.data[149] = 2;
				}
				else
				{
					text = "Наши агенты вышли на контакт с Тихоном Киселевым - Председателем Совмина БССР, вокруг которого объединились недовольные политикой Машерова белорусские партийцы - и передали ему компромат на Машерова (в частности, тот одобрял «косыгинскую» экономическую реформу и требовал разработать систему планирования, которая бы стимулировала экономическую заинтересованность предприятий. Причина была в его стремлении постепенно уйти от административно-командных методов управления экономикой. Также, по инициативе Машерова, в БССР регулярно проводились семинары по различным проблемам народного хозяйства, не согласованные с ЦК КПСС). Однако тот не рискнул передавать его Суслову, в результате чего Машеров остался на посту.";
					GlobalScript.inst.gameState.data[8] -= 50;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В 14:35 Петр Машеров выехал от здания ЦК КПБ в сторону города Жодино на автомобиле ГАЗ-13 «Чайка», управлял которым 60-летний водитель Е. Зайцев. Машеров сидел рядом с водителем, сзади — офицер охраны майор В.Ф. Чесноков. Вопреки существующим инструкциям, впереди шла не машина ГАИ с соответствующей раскраской и мигалками, а белая «Волга» с сигнально-громкоговорящей установкой, но без мигалок. У поворота на птицефабрику рядом с городом Смолевичи на трассе \"Москва-Минск\" в \"Чайку\" врезался гружённый картошкой самосвал ГАЗ-САЗ-53Б под управлением водителя Н. Пустовита. Никто не уцелел - Машеров, его водитель и охранник погибли на месте, водитель самосвала - скончался от большой потери крови по пути в больницу. Генеральной прокуратурой СССР, совместно с КГБ СССР, было проведено расследование, которое исключило умышленный характер преступления. Следственная группа пришла к выводу, что виноват водитель картофелевоза.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 85)
		{
			text2 = "Немецкая автономия в Казахстане";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "16 июня в городах Целиноград, Кокчетав и Караганда начались массовые выступления казахского населения против предоставления немецкому меньшинству автономии. Демонстранты несли транспаранты с надписями: «Наша земля для всех едина и неделима!» и скандировали лозунги: «Нет немецкому автономному району в Ерментау!». Спустя три дня после первого митинга, на одной из окраинных площадей Целинограда со всех окрестных улиц вновь собрались толпы, требуя ответа на вопросы: «Какая судьба ждёт казахов на своей земле?» и «Что будет с автономией?». Руководство и силовые структуры Казахской ССР негласно поддерживали демонстрантов и не препятствовали распространению по общежитиям листовок с призывом выйти на митинг протеста. Мы воспользовались этим и официально предали гласности этот факт, обвинив Кунаева в \"неофашизме\" и \"нарушении ленинских принципов национальной политики\". По линии МГБ был также слит компромат на большое количество лиц из его окружения, подозреваемых в коррупции. 16 декабря в ходе рекордно короткого пленума ЦК КП Казахстана, длившегося всего 18 минут, Динмухамед Кунаев был снят с поста Первого секретаря ЦК КП Казахстана и отправлен на пенсию. На его место был избран Председатель Совета Министров Казахской ССР технократ Байкен Ашимов.";
				GlobalScript.inst.gameState.data[9] -= 100;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
				leader.support--;
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[149] = 3;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.empires[1].relations >= 500)
				{
					text = "Мы срочно отправили в ЦК КПСС всю полученную информацию о готовящихся выступлениях в Казахской ССР, указав на причастность к этому всей партийной верхушки республики. Наше предупреждение было принято к сведению, поэтому 16 июня в Целиноград, Кокчетав и Караганду были введены подразделения Внутренних войск МВД СССР, что воспрепятствовало демонстрациям. Кунаева вызвали в Москву, где после беседы с Арвидом Пельше и Михаилом Сусловым он написал заявление с просьбой освободить его со всех постов в связи с \"состоянием здоровья\".";
					GlobalScript.inst.gameState.data[9] -= 30;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support--;
					GlobalScript.inst.gameState.data[149] = 3;
				}
				else
				{
					text = "Мы срочно отправили в ЦК КПСС всю полученную информацию о готовящихся выступлениях в Казахской ССР, указав на причастность к этому всей партийной верхушки республики. Однако наше предупреждение было проигнорировано. 16 июня в городах Целиноград, Кокчетав и Караганда начались массовые выступления казахского населения против предоставления немецкому меньшинству автономии. Демонстранты несли транспаранты с надписями: «Наша земля для всех едина и неделима!» и скандировали лозунги: «Нет немецкому автономному району в Ерментау!». В итоге власти согласились с требованиями демонстрантов и объявили, что вопрос о немецкой автономии в Казахстане полностью снят с повестки дня.";
					GlobalScript.inst.gameState.data[9] -= 30;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "16 июня в городах Целиноград, Кокчетав и Караганда начались массовые выступления казахского населения против предоставления немецкому меньшинству автономии. Демонстранты несли транспаранты с надписями: «Наша земля для всех едина и неделима!» и скандировали лозунги: «Нет немецкому автономному району в Ерментау!». В итоге власти согласились с требованиями демонстрантов и объявили, что вопрос о немецкой автономии в Казахстане полностью снят с повестки дня.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Наши журналисты раскопали информацию о деятельности команды 1 секретаря Рашидова в Узбекистане: огромные приписки в планы сбора хлопка, поддельные материалы из камней и щебня, распространённое кумовство и взятки в виде баранов и автомобилей. Некоторые его друзья даже хранили золото кувшинами, чтобы скрыть его от темных дехкан во время проверок из Москвы. Фотографии, анонимные интервью и статистическая документация были переданы посольством представителям Совета Министров СССР. Мы распространили эту информацию через статьи в наших китайских газетах, которые затем попали на Запад, включая Радио Свобода и Голос Америки. Это лишило советских руководителей возможности замять дело и вызвало ноту негодования от СССР. В результате проведённых расследований в Советском Союзе прошли массовые проверки по всем республикам и показательные исключения из партии прошлись по нескольким странам. Вместо Рашидова молодой (по советским меркам) Акил Салимов стал новым 1 секретарём ЦК КПУз, имея опыт в организации промышленности и кадровой работе. За халатность одиозный 1 секретарь ЦК КП Молдавии Иван Бодюл был отправлен на пенсию, его \"молдавский опыт\" в агропромышленных комплексах признан неэффективным, а тихий и исполнительный Семён Гроссу, бывший председатель Совета министров, возглавил страну. Коррупция и кумовство привели к отставке 1 секретаря ЦК КП Азербайджана Гейдара Алиева и руководителей министерств и КГБ Азербайджанской ССР. Новыми лидерами стали противники Алиева во главе с Абдурахманом Везировым, возвращённым из политической ссылки. В Туркменской ССР Мухамедназар Гапуров был отстранён и исключён за коррупцию и приписки, а Назар Суюмов, опытный специалист в области геологии и добычи газа и нефти, стал новым лидером, ориентируя экономику на развитие газовой и нефтяной отрасли. Проверки не ограничивались советскими республиками и затронули даже республики в составе РСФСР. Это вызвало громкие обсуждения проблем в СССР по всему миру, что в конечном итоге принесло нам пользу.";
				GlobalScript.inst.gameState.data[8] -= 30;
				GlobalScript.inst.gameState.data[9] -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 300;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 30;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 86)
		{
			text2 = "Конец \"Железного Юрика\"";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Пока Брежнев уехал на переговоры в Вену, Юрий Андропов, у которого произошло обострение давно мучавшей его болезни почек, отправился на лечение в Крым. Однако это оказалось путешествие в один конец - в Крыму он простудился и окончательно слёг — у него развилась флегмона (гнойное воспаление клетчатки) и произошло резкое ухудшение общего состояния здоровья. Операция прошла успешно, но послеоперационная рана не заживала. Организм был очень слаб и не мог бороться с интоксикацией. Андропов впал в кому, из которой так и не вышел. 9 июля 1979 года Председатель КГБ СССР скончался. Знающие люди говорили, что \"не надо было Андропову ехать в хозяйство Щербицкого. У того ведь тоже есть гордость и свое КГБ\". Новым главой союзного КГБ стал Семен Цвигун, который начал в \"конторе\" массовые чистки, причем на место снятых андроповских кадров в массовом порядке пришли работники из КГБ УССР. Это усиливает влияние Владимира Щербицкого, который теперь стал де-факто единственным преемником Леонида Брежнева. Это нас вполне устраивает...";
				GlobalScript.inst.gameState.data[9] -= 100;
				GlobalScript.inst.gameState.data[8] -= 50;
				GlobalScript.inst.gameState.empires[1].leaders[3].support = -100;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[1];
				leader.support += 10;
				GlobalScript.inst.gameState.data[1] += 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.empires[1].relations >= 400)
				{
					text = "Как только из Вены пришло известие о прибытии Леонида Брежнева в столицу Австрии - 8-е Главное управление КГБ СССР по приказу первого заместителя Председателя Комитета генерала Семена Цвигуна отключило правительственную связь, таким образом полностью изолировав генсека от информации из СССР. Тем временем, при помощи оппозиции в КГБ Михаил Суслов и Владимир Щербицкий феноменально быстро созвали чрезвычайный Пленум ЦК КПСС, на котором Юрий Андропов был обвинен в \"превращении КГБ в личную лавочку, подготовке антиправительственного переворота, связи с ЦРУ США и спецслужбами Израиля, оклеветании Фёдора Кулакова и Петра Машерова\" и т.д. Мы оперативно организовали информационное сопровождение Пленума, подливая масла в огонь публикациями \"разоблачительных материалов\" об Андропове. Ошарашенный глава КГБ пытался сопротивляться, но после выступления Владимира Щербицкого, прямо обвинившего Андропова в подготовке убийства Брежнева, понял, что проиграл. Пленум принял решение об снятии Андропова со всех постов, исключении его из партии и аресте. Новым Председателем КГБ СССР стал глава украинского КГБ Виталий Федорчук, который начал массовые чистки андроповских кадров и замену их проверенными работниками республиканских Комитетов. Пожалуй, самый опасный наш противник в СССР теперь окончательно нейтрализован...";
					GlobalScript.inst.gameState.data[8] -= 70;
					GlobalScript.inst.gameState.empires[1].leaders[3].support = -100;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[1];
					leader.support += 10;
				}
				else
				{
					text = "Как только из Вены пришло известие о прибытии Леонида Брежнева в столицу Австрии, при помощи оппозиции в КГБ Михаил Суслов и Владимир Щербицкий феноменально быстро созвали чрезвычайный Пленум ЦК КПСС, на котором Юрий Андропов был обвинен в \"превращении КГБ в личную лавочку, подготовке антиправительственного переворота, связи с ЦРУ США и спецслужбами Израиля, оклеветании Фёдора Кулакова и Петра Машерова\" и т.д. Мы оперативно организовали информационное сопровождение Пленума, подливая масла в огонь публикациями \"разоблачительных материалов\" об Андропове. Однако Андропов не растерялся и, опираясь на своих сторонников в ЦК КПСС и лояльных ему чекистов, объявил Суслова и Щербицкого \"второй антипартийной группой\", превратив Пленум в суд над ними. Итогом этого стало исключение Суслова и Щербицкого из КПСС и возвышение Андропова, ставшего Вторым секретарем ЦК КПСС и фактическим преемником Леонида Брежнева, который был обо всем уведомлен и поддержал его действия.";
					GlobalScript.inst.gameState.data[8] -= 70;
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
					leader.support += 2;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "И ничего не произошло. Юрий Андропов постепенно вычищает из КГБ своих противников и укрепляет влияние в ЦК КПСС, становясь фактическим преемником Леонида Брежнева и продвигая реформистски настроенных партийцев, таких как Егор Лигачёв, Михаил Горбачёв и Владимир Долгих.";
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
				leader.support += 2;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 87)
		{
			text2 = "Мир Галилее";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Израиль объявил о начале операции \"Мир Галилее\", целью которой, по словам израильских представителей, является ликвидация баз ООП и создание демилитаризованной зоны на юге Ливана. Израиль объявил о том, что не собирается атаковать группы вооружённых сил Сирии в Ливане, и сама Сирия пока воздерживается от боевых действий, однако с учётом того, что сирийцы контролируют огромную часть Ливана, столкновение между ними и силами ЦАХАЛа кажется лишь вопросом времени. Примечательно, что США, традиционно поддерживавшие Израиль, отреагировали довольно сдержанно и особо не оценили его \"миротворческих\" порывов.";
				GlobalScript.inst.gameState.ingamewars[4].name_war = "Ливанская война";
				GlobalScript.inst.gameState.ingamewars[4].is_going = true;
				GlobalScript.inst.gameState.ingamewars[4].side1 = "Израиль";
				GlobalScript.inst.gameState.ingamewars[4].side2 = "ООП";
				GlobalScript.inst.gameState.ingamewars[4].ussr_place = 1;
				GlobalScript.inst.gameState.ingamewars[4].usa_place = 0;
				GlobalScript.inst.gameState.ingamewars[4].infl1 = 650;
				GlobalScript.inst.gameState.ingamewars[4].infl2 = 350;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 88)
		{
			text2 = "Конец зимбабвийского апартеида";
			GlobalScript.inst.gameState.allcountries[52].SubGosstroy = 10;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Мы установили дипломатические отношения с правительством Мугабе и заявили о намерении развивать тесное сотрудничество между Китаем и Зимбабве, подкрепив свои добрые намерения материальной помощью, которую Мугабе с радостью принял, заявив о готовности к всестороннему сотрудничеству";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GlobalScript.inst.gameState.data[8] -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 15;
				GlobalScript.inst.gameState.allcountries[52].proprc = true;
				GlobalScript.inst.gameState.allcountries[52].Torg = true;
				GlobalScript.inst.gameState.allcountries[52].name = GlobalScript.inst.new_events_text[799];
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наше взаимодействие с новым правительством ограничилось установлением дипломатических отношений. Ничего особого не произошло.";
				GlobalScript.inst.gameState.allcountries[52].name = GlobalScript.inst.new_events_text[799];
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 89)
		{
			text2 = "Конец эпохи";
			int num82 = -1;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "";
				num82 = 3;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "";
				num82 = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "";
				num82 = 2;
			}
			if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 1)
			{
				Leader[] leaders = GlobalScript.inst.gameState.empires[1].leaders;
				foreach (Leader leader5 in leaders)
				{
					Leader leader = leader5;
					leader.support += UnityEngine.Random.Range(-10, 11);
				}
			}
			if (num82 >= 0)
			{
				if (GlobalScript.inst.gameState.gamerules[3] == 2)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num82];
					leader.support += 200;
				}
				else
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num82];
					leader.support += 2;
					GlobalScript.inst.gameState.data[9] -= 100;
				}
				if (GlobalScript.inst.gameState.relres)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num82];
					leader.support++;
				}
				if (GlobalScript.inst.gameState.allcountries[7].Torg || GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num82];
					leader.support++;
				}
				if (GlobalScript.inst.gameState.allcountries[1].isOVD)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[num82];
					leader.support++;
				}
			}
			if (GlobalScript.inst.gameState.empires[1].leaders[2].support >= GlobalScript.inst.gameState.empires[1].leaders[3].support && GlobalScript.inst.gameState.empires[1].leaders[2].support >= GlobalScript.inst.gameState.empires[1].leaders[1].support)
			{
				text = "В итоге Генеральным секретарём ЦК КПСС был избран Константин Черненко. Многие увидели в нём удобную компромиссную фигуру, которая позволит Союзу избежать масштабных перемен и потрясений и похоже он оправдает их ожидания.";
				GlobalScript.inst.gameState.empires[1].now_leader = 2;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
				leader.support++;
				leader = GlobalScript.inst.gameState.empires[1].leaders[5];
				leader.support++;
			}
			else if (GlobalScript.inst.gameState.empires[1].leaders[1].support >= GlobalScript.inst.gameState.empires[1].leaders[2].support && GlobalScript.inst.gameState.empires[1].leaders[1].support >= GlobalScript.inst.gameState.empires[1].leaders[3].support)
			{
				text = "В итоге Генеральным секретарём ЦК КПСС был избран Владимир Щербицкий. Это и неудивительно - устранив Андропова, заручившись поддержкой Суслова и доверием Брежнева, тот стал главным претендентом на эту должность. Кажется СССР ждёт ещё несколько лет стабильности.";
				GlobalScript.inst.gameState.empires[1].now_leader = 3;
			}
			else if (GlobalScript.inst.gameState.empires[1].leaders[3].support >= GlobalScript.inst.gameState.empires[1].leaders[2].support && GlobalScript.inst.gameState.empires[1].leaders[3].support >= GlobalScript.inst.gameState.empires[1].leaders[1].support)
			{
				text = "В итоге Генеральным секретарём ЦК КПСС был избран Юрий Андропов. За годы руководства КГБ он сосредоточил в своих руках огромную власть, позволившую ему победить в этой борьбе, да и многие увидели в нём прагматичного и жёсткого правителя, столь необходимого Советскому Союзу сейчас.";
				GlobalScript.inst.gameState.empires[1].now_leader = 1;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
				leader.support += 2;
			}
			else if (GlobalScript.inst.gameState.empires[1].leaders[2].support >= GlobalScript.inst.gameState.empires[1].leaders[3].support)
			{
				text = "В итоге Генеральным секретарём ЦК КПСС был избран Константин Черненко. Многие увидели в нём удобную компромиссную фигуру, которая позволит Союзу избежать масштабных перемен и потрясений и похоже он оправдает их ожидания.";
				GlobalScript.inst.gameState.empires[1].now_leader = 2;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
				leader.support++;
				leader = GlobalScript.inst.gameState.empires[1].leaders[5];
				leader.support++;
			}
			else
			{
				text = "В итоге Генеральным секретарём ЦК КПСС был избран Юрий Андропов. За годы руководства КГБ он сосредоточил в своих руках огромную власть, позволившую ему победить в этой борьбе, да и многие увидели в нём прагматичного и жёсткого правителя, столь необходимого Советскому Союзу сейчас.";
				GlobalScript.inst.gameState.empires[1].now_leader = 1;
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
				leader.support += 2;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 90)
		{
			text2 = "Гонконг гудбай, Макао ате а виста?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "С помощью спецслужб, госкомпаний и прокитайских лоббистских организаций нам удалось установить контакты с тремя крупнейшими синдикатами Триад - «14 К», «Хэшэнхэ» и «Фуисин». Они получили от нас гарантии неприкосновенности их членов и активов и предложение об выгодном инвестировании своих капиталов в экономику страны (в частности, в производство эфедры) на крайне льготных условиях. Руководители Триад, уже собиравшиеся перенести свои центры в США, согласились на наше предложение. Они начинают вкладывать крупные инвестиции в наши южные провинции, а также используют свое влияние для нейтрализации действий противников воссоединения Китая (в частности, из СМИ исчезли критические материалы, все протесты оперативно разгоняются членами Триад при попустительстве коррумпированной полиции, а ряд бизнесменов эмигрировали из Гонконга и Макао). Таким образом, мы теперь имеем поддержку синдикатов, но также рост влияния криминального мира и коррупции.";
				GlobalScript.inst.gameState.data[9] -= 40;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[8] += 100;
				GlobalScript.inst.gameState.data[26] += 150;
				GlobalScript.inst.gameState.modifies[5].active = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.data[6] > 300 && GlobalScript.inst.gameState.data[14] < 3)
				{
					text = "Мы установили контакты с тремя крупнейшими синдикатами Триад - «14 К», «Хэшэнхэ» и «Фуисин». Они получили от нас гарантии неприкосновенности их членов и активов, однако их руководителей эти условия не устроили. Переговоры закончились ничем, однако сам их факт, не без помощи МГБ просочившийся в СМИ Гонконга и Макао, сильно напугал местных недовольных, многие из которых, решив не рисковать, эмигрировали. Можно считать это нашим частичным успехом, хотя после 1997 года с Триадами придется бороться всерьез.";
					GlobalScript.inst.gameState.data[9] -= 20;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[6] += 20;
				}
				else
				{
					text = "Мы установили контакты с тремя крупнейшими синдикатами Триад - «14 К», «Хэшэнхэ» и «Фуисин». Они получили от нас гарантии неприкосновенности их членов и активов, с которыми их руководители согласились. Они используют свое влияние для нейтрализации действий противников воссоединения Китая (в частности, из СМИ исчезли критические материалы, все протесты оперативно разгоняются членами Триад при попустительстве коррумпированной полиции, а ряд бизнесменов эмигрировали из Гонконга и Макао). Тем не менее, МГБ не дает Триадам закрепиться в южных провинциях страны, а после 1997 года мы начнем с ними уже планомерную борьбу.";
					GlobalScript.inst.gameState.data[9] -= 20;
					GlobalScript.inst.gameState.data[3] -= 50;
					GlobalScript.inst.gameState.data[6] += 20;
					GlobalScript.inst.gameState.data[26] += 80;
					GlobalScript.inst.gameState.data[8] += 50;
					GlobalScript.inst.gameState.modifies[5].active = true;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " наотрез отказался от каких-либо переговоров с преступными синдикатами Гонконга. После серии антикитайских инцидентов, в Гонконге и Макао началась планомерная кампания по дискредитации соглашения об их передачи в состав Китая, которая завершилась массовыми погромами и решением английского и португальского парламентов об отказе в ратификации соглашения.";
				GlobalScript.inst.gameState.data[65] = 0;
				if (GlobalScript.inst.gameState.allcountries[51].Torg || GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					text += "Однако наши друзья оказали давление на них и смогли добиться выполнения английской и португальской стороной своих обязательств. Гонконг и Макао будут возвращены, как и установлено, в 1997 и 1999 году соответственно.";
					GlobalScript.inst.gameState.data[65] = 1;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "«Или Компартия победит коррупцию, или коррупция победит Компартию» — провозгласил товарищ Председатель на заседании Политбюро. Министерство общественной безопасности КНР и Центральная комиссия КПК по проверке дисциплины начали широкомасштабную кампанию по борьбе с коррумпированными элитами в южных провинциях КНР, примыкающих к Гонконгу и Макао, а также недавно открытым СЭЗ. Со своих постов сняты сотни функционеров всех уровней, тысячи человек исключены из КПК, конфискованы миллионы украденных у государства юаней, а мэр Чэнду Чэнь Ситун (\"китайский Гришин\"), укравший у народа несколько миллиардов юаней и построивший себе роскошную виллу, был приговорен к расстрелу. Это полностью дезорганизовало все коррумпированные элементы, что позволило несколько выправить ситуацию и разорвать уже начатые было коррупционные контакты наших элит со своими сянганскими и аомынскими коллегами. Последние же \"на всякий случай\" эмигрируют.";
				GlobalScript.inst.gameState.data[8] += 40;
				GlobalScript.inst.gameState.data[9] -= 80;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[26] -= 150;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 91)
		{
			text2 = "Рангунский теракт";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "В ответ на эти события весь \"цивилизованный мир\" разразился гневными речами в адрес КНДР. Официальных заявлений мы давать не стали, но в \"Жэньминь жибао\" была опубликована статья с резким осуждением террористических методов КНДР. На границе двух Корей тем временем прошло несколько вооружённых провокаций с обеих сторон...";
				GlobalScript.inst.gameState.data[6] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В ответ на эти события весь \"цивилизованный мир\" разразился гневными речами в адрес КНДР. Мы же полностью поддержали северокорейскую позицию, назвав случившееся провокацией Южной Кореи и осудив её. На границе двух Корей тем временем прошло несколько вооружённых провокаций с обеих сторон...";
				GlobalScript.inst.gameState.data[6] += 20;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 80;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В ответ на эти события весь \"цивилизованный мир\" разразился гневными речами в адрес КНДР. На границе двух Корей тем временем прошло несколько вооружённых провокаций с обеих сторон...";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 92)
		{
			text2 = "Перевыполнение – честь!";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Китайским правительством было принято решение выделить дополнительные средства на модернизацию лёгкой и тяжёлой промышленности, улучшению качества выпускаемой продукции и обновлению оборудования. Основным вектором нового пятилетнего плана стало развитие промышленности.";
				GlobalScript.inst.gameState.data[102] = 1;
				GlobalScript.inst.gameState.data[8] -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Китайским правительством было принято решение о выделение средств на механизацию и внедрение новых технологий в сферу сельского хозяйства. Главным приоритетом нового пятилетнего плана было объявлено сельское хозяйство.";
				GlobalScript.inst.gameState.data[102] = 2;
				GlobalScript.inst.gameState.data[8] -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Китайским правительством было принято решение об улучшении качества сервиса в области сферы услуг, на что были выделены дополнительные средства из бюджета. Первостепенной задачей пятилетнего плана была провозглашена модернизация сферы услуг.";
				GlobalScript.inst.gameState.data[102] = 3;
				GlobalScript.inst.gameState.data[8] -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Правительство Китая обнародовало программу экономического развития на нынешний пятилетний план, в которой указывается необходимость ускорения научно-технического прогресса и внедрения новых методов управления народным хозяйством. Приоритетной отраслью нового пятигодичного плана стала наука.";
				GlobalScript.inst.gameState.data[102] = 4;
				GlobalScript.inst.gameState.data[8] -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Несмотря на предложения Госплана, правительство Китая заявило о необходимости равномерного развития всех отраслей народного хозяйства, на что и были выделены дополнительные средства из бюджета страны";
				GlobalScript.inst.gameState.data[102] = 5;
				GlobalScript.inst.gameState.data[8] -= 10;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 93)
		{
			text2 = "Родина демократии";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Наши спецслужбы оказали ПАСОК помощь в проведении их агитационной кампании и активно срывали кампанию Новой демократии. Также с их помощью удалось сформировать коалицию левых сил из ПАСОК, КПГ и прочих левых партий. В итоге на выборах победила левая коалиция, сформировав первое в истории страны социалистическое правительство. При нашей и советской поддержке оно завершило формальный выход Греции из НАТО и остановило процессы евроинтеграции";
				GlobalScript.inst.gameState.data[6] += 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GlobalScript.inst.gameState.allcountries[45].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[45].SubGosstroy = 3;
				GlobalScript.inst.gameState.allcountries[45].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[45].isNATO = false;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 50;
				Country country2 = GlobalScript.inst.gameState.allcountries[87];
				country2.spec -= 5;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наши спецслужбы оказали Новой демократии помощь в проведении их агитационной кампании и активно срывали кампанию ПАСОК. Им также удалось добиться присоединения к коалиции с Новой демократией некоторых мелких правых партий, что в совокупности и привело их к победе на выборах. Новое правительство намерено провести дальнейшие реформы экономики, направленные на обеспечение членства Греции в ЕЭС, и восстановить деятельность страны в НАТО.";
				GlobalScript.inst.gameState.data[6] -= 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 80;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
				Country country2 = GlobalScript.inst.gameState.allcountries[87];
				country2.spec += 5;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "В итоге на выборах с небольшим перевесом победила Новая демократия. Новое правительство намерено провести дальнейшие реформы экономики, направленные на обеспечение членства Греции в ЕЭС, и восстановить деятельность страны в НАТО.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 94)
		{
			text2 = "Тяньаньмэньский инцидент. Снова?!";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "На экстренном заседании Политбюро ЦК КПК происходящие события были объявлены \"контрреволюционным мятежом, инспирированным американскими и тайваньскими спецслужбами\", после чего большинством голосов было принято решение о его силовом подавлении. По приказу начальника Генштаба НОАК, генерала Ян Дэчжи, в Пекин были введены войска, усиленные танками и бронетранспортерами, однако при продвижении к площади они натолкнулись на баррикады и упорное сопротивление вооруженных \"коктейлями Молотова\" бандитов. При поддержке бронетехники баррикады были прорваны, после чего части НОАК разгромили основной лагерь протестующих и зачистили площадь Таньаньмэнь, ещё несколько дней продолжалась зачистка рабочих и студенческих кварталов. Таким образом, ситуация была взята под контроль. Движение \"Туйдан\" было объявлено вне закона, " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + " и его сторонники, поддержавшие его, были сняты с постов и исключны из КПК, начались аресты противников политики реформ и открытости, а Фан Личжи бежал в США. Западные страны объявили наш режим \"кровавой тиранией\", СССР и его союзники же промолчали. Организованное протестное движение было подавлено, недовольные уходят в подполье.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 150;
				GlobalScript.inst.gameState.data[57] -= 150;
				GlobalScript.inst.gameState.data[3] -= 100;
				GlobalScript.inst.gameState.data[4] -= 250;
				GlobalScript.inst.gameState.data[6] += 80;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (GlobalScript.inst.gameState.data[3] >= 600 && GlobalScript.inst.gameState.data[4] < 500)
				{
					text = "Опасаясь мародерства, мэр Пекина приказал ввести в город усиленные бронетехникой подразделения Народной милиции, которые оцепили площадь Тяньаньмэнь и вытеснили митингующих с прилегающих улиц (при этом понеся крупные потери в технике, сожженой \"коктейлями Молотова\"). После чего товарищ Председатель лично выступил перед демонстрантами, уговаривая их разойтись. Значительная часть их покинула площадь, остальные были разогнаны милиционерами слезоточивым газом и холостыми выстрелами. Порядок в столице восстановлен, однако волнения перекинулись на Шанхай, Нинбо и ряд других городов...";
					GlobalScript.inst.gameState.data[4] += 250;
					GlobalScript.inst.gameState.data[3] -= 100;
					GlobalScript.inst.gameState.data[57] -= 250;
				}
				else
				{
					text = "Опасаясь мародерства, мэр Пекина приказал ввести в город усиленные бронетехникой подразделения Народной милиции, которые оцепили площадь Тяньаньмэнь и вытеснили митингующих с прилегающих улиц (при этом понеся крупные потери в технике, сожженой \"коктейлями Молотова\"). После чего товарищ Председатель лично выступил перед демонстрантами, уговаривая их разойтись. Толпа встретила Председателя свистом и криками, из-за чего ему пришлось спешно ретироваться. На экстренном заседании Политбюро ЦК КПК было принято решение - пойти на уступки демонстрантам и отправить руководство партии в отставку. Новым Генеральным секретарем стал товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + ", который провозгласил курс на углубление реформ и широкомасштабную демократизацию страны. Большая часть митингующих разошлась, удовлетворенная этим, остальных арестовали милиционеры. Китай ждут перемены...";
					GlobalScript.inst.gameState.data[3] += 90;
					GlobalScript.inst.gameState.data[6] -= 50;
					GlobalScript.inst.gameState.data[57] -= 350;
					GlobalScript.inst.gameState.data[107] = 1;
					GlobalScript.inst.gameState.data[4] += 100;
					int[] array22 = new int[16]
					{
						GlobalScript.inst.gameState.leader.name_1,
						GlobalScript.inst.gameState.leader.name_2,
						GlobalScript.inst.gameState.leader.traits[0],
						GlobalScript.inst.gameState.leader.traits[1],
						GlobalScript.inst.gameState.leader.traits[2],
						GlobalScript.inst.gameState.leader.age,
						GlobalScript.inst.gameState.leader.face_type,
						GlobalScript.inst.gameState.leader.face_parts[0],
						GlobalScript.inst.gameState.leader.face_parts[1],
						GlobalScript.inst.gameState.leader.face_parts[2],
						GlobalScript.inst.gameState.leader.face_parts[3],
						GlobalScript.inst.gameState.leader.face_parts[4],
						GlobalScript.inst.gameState.leader.face_parts[5],
						GlobalScript.inst.gameState.leader.face_parts[6],
						GlobalScript.inst.gameState.leader.face_parts[7],
						GlobalScript.inst.gameState.leader.jacket
					};
					int num83 = GlobalScript.inst.gameState.faction_leader[4];
					Politic politic188 = GlobalScript.inst.gameState.politics[num83];
					if (GlobalScript.inst.gameState.citizens != null)
					{
						Persona[] citizens = GlobalScript.inst.gameState.citizens;
						foreach (Persona persona12 in citizens)
						{
							if (persona12.isLead)
							{
								persona12.isLead = false;
							}
						}
					}
					if (politic188.isCitizen)
					{
						achieves.GetComponent<achievements>().Set(210);
						string text13 = GlobalScript.inst.gameState.names1[politic188.name_1];
						string text14 = GlobalScript.inst.gameState.names2[politic188.name_2];
						Persona[] citizens = GlobalScript.inst.gameState.citizens;
						foreach (Persona persona13 in citizens)
						{
							if (persona13 != null && persona13.name == text13 && persona13.surname == text14)
							{
								persona13.isLead = true;
								int[] date6 = new int[3]
								{
									GlobalScript.inst.gameState.data[19],
									GlobalScript.inst.gameState.data[20],
									GlobalScript.inst.gameState.data[21]
								};
								string text15 = CitizenManager.FormatLog(persona13, "стал правителем.", "成为领袖。", date6);
								persona13.changeLog.Add(text15);
								Debug.Log(text15);
							}
						}
					}
					politic188.face_parts = (byte[])politic188.face_parts.Clone();
					GlobalScript.inst.gameState.leader.name_1 = politic188.name_1;
					GlobalScript.inst.gameState.leader.name_2 = politic188.name_2;
					GlobalScript.inst.gameState.leader.traits[0] = politic188.traits[0];
					GlobalScript.inst.gameState.leader.traits[1] = politic188.traits[1];
					GlobalScript.inst.gameState.leader.traits[2] = politic188.traits[2];
					GlobalScript.inst.gameState.leader.age = politic188.age;
					GlobalScript.inst.gameState.leader.face_type = politic188.face_type;
					for (int num84 = 0; num84 < 8; num84++)
					{
						GlobalScript.inst.gameState.leader.face_parts[num84] = politic188.face_parts[num84];
					}
					GlobalScript.inst.gameState.leader.jacket = politic188.jacket;
					politic188.name_1 = (byte)array22[0];
					politic188.name_2 = (byte)array22[1];
					politic188.traits[0] = (byte)array22[2];
					politic188.traits[1] = (byte)array22[3];
					politic188.traits[2] = (byte)array22[4];
					politic188.age = (byte)array22[5];
					politic188.face_type = (byte)array22[6];
					for (int num85 = 0; num85 < 8; num85++)
					{
						politic188.face_parts[num85] = (byte)array22[7 + num85];
					}
					politic188.jacket = (byte)array22[15];
					politic188.isCitizen = false;
					int[] array23 = new int[8];
					for (int num86 = 0; num86 < GlobalScript.inst.gameState.politics_dolshnost.Length; num86++)
					{
						if (GlobalScript.inst.gameState.politics_dolshnost[num86] == 150)
						{
							GlobalScript.inst.gameState.politics_dolshnost[num86] = (byte)GlobalScript.inst.gameState.faction_leader[4];
						}
						else if (GlobalScript.inst.gameState.politics_dolshnost[num86] == (byte)GlobalScript.inst.gameState.faction_leader[4])
						{
							array23[num86] = 150;
						}
					}
					for (int num87 = 0; num87 < array23.Length; num87++)
					{
						if (array23[num87] == 150)
						{
							GlobalScript.inst.gameState.politics_dolshnost[num87] = 150;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "На экстренном заседании Политбюро ЦК КПК разгорелись бурные споры - консервативное крыло требовало применить силу (особенно твердо за это выступал генерал Ван Чжэнь), либеральное крыло - пойти на уступки, реформаторское крыло же колебалось. В конце-концов, либералы добились своего - все руководство КПК ушло в отставку. Новым Генеральным секретарем стал товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + ", который провозгласил курс на углубление реформ и широкомасштабную демократизацию страны. Большая часть митингующих разошлась, удовлетворенная этим, остальных вытеснила с площади Народная милиция. Китай ждут перемены...";
				GlobalScript.inst.gameState.data[3] += 90;
				GlobalScript.inst.gameState.data[6] -= 50;
				GlobalScript.inst.gameState.data[57] -= 350;
				GlobalScript.inst.gameState.data[107] = 1;
				GlobalScript.inst.gameState.data[4] += 100;
				int[] array24 = new int[16]
				{
					GlobalScript.inst.gameState.leader.name_1,
					GlobalScript.inst.gameState.leader.name_2,
					GlobalScript.inst.gameState.leader.traits[0],
					GlobalScript.inst.gameState.leader.traits[1],
					GlobalScript.inst.gameState.leader.traits[2],
					GlobalScript.inst.gameState.leader.age,
					GlobalScript.inst.gameState.leader.face_type,
					GlobalScript.inst.gameState.leader.face_parts[0],
					GlobalScript.inst.gameState.leader.face_parts[1],
					GlobalScript.inst.gameState.leader.face_parts[2],
					GlobalScript.inst.gameState.leader.face_parts[3],
					GlobalScript.inst.gameState.leader.face_parts[4],
					GlobalScript.inst.gameState.leader.face_parts[5],
					GlobalScript.inst.gameState.leader.face_parts[6],
					GlobalScript.inst.gameState.leader.face_parts[7],
					GlobalScript.inst.gameState.leader.jacket
				};
				int num88 = GlobalScript.inst.gameState.faction_leader[4];
				Politic politic189 = GlobalScript.inst.gameState.politics[num88];
				if (GlobalScript.inst.gameState.citizens != null)
				{
					Persona[] citizens = GlobalScript.inst.gameState.citizens;
					foreach (Persona persona14 in citizens)
					{
						if (persona14.isLead)
						{
							persona14.isLead = false;
						}
					}
				}
				if (politic189.isCitizen)
				{
					achieves.GetComponent<achievements>().Set(210);
					string text16 = GlobalScript.inst.gameState.names1[politic189.name_1];
					string text17 = GlobalScript.inst.gameState.names2[politic189.name_2];
					Persona[] citizens = GlobalScript.inst.gameState.citizens;
					foreach (Persona persona15 in citizens)
					{
						if (persona15 != null && persona15.name == text16 && persona15.surname == text17)
						{
							persona15.isLead = true;
							int[] date7 = new int[3]
							{
								GlobalScript.inst.gameState.data[19],
								GlobalScript.inst.gameState.data[20],
								GlobalScript.inst.gameState.data[21]
							};
							string text18 = CitizenManager.FormatLog(persona15, "стал правителем.", "成为领袖。", date7);
							persona15.changeLog.Add(text18);
							Debug.Log(text18);
						}
					}
				}
				politic189.face_parts = (byte[])politic189.face_parts.Clone();
				GlobalScript.inst.gameState.leader.name_1 = politic189.name_1;
				GlobalScript.inst.gameState.leader.name_2 = politic189.name_2;
				GlobalScript.inst.gameState.leader.traits[0] = politic189.traits[0];
				GlobalScript.inst.gameState.leader.traits[1] = politic189.traits[1];
				GlobalScript.inst.gameState.leader.traits[2] = politic189.traits[2];
				GlobalScript.inst.gameState.leader.age = politic189.age;
				GlobalScript.inst.gameState.leader.face_type = politic189.face_type;
				for (int num89 = 0; num89 < 8; num89++)
				{
					GlobalScript.inst.gameState.leader.face_parts[num89] = politic189.face_parts[num89];
				}
				GlobalScript.inst.gameState.leader.jacket = politic189.jacket;
				politic189.name_1 = (byte)array24[0];
				politic189.name_2 = (byte)array24[1];
				politic189.traits[0] = (byte)array24[2];
				politic189.traits[1] = (byte)array24[3];
				politic189.traits[2] = (byte)array24[4];
				politic189.age = (byte)array24[5];
				politic189.face_type = (byte)array24[6];
				for (int num90 = 0; num90 < 8; num90++)
				{
					politic189.face_parts[num90] = (byte)array24[7 + num90];
				}
				politic189.jacket = (byte)array24[15];
				int[] array25 = new int[8];
				for (int num91 = 0; num91 < GlobalScript.inst.gameState.politics_dolshnost.Length; num91++)
				{
					if (GlobalScript.inst.gameState.politics_dolshnost[num91] == 150)
					{
						GlobalScript.inst.gameState.politics_dolshnost[num91] = (byte)GlobalScript.inst.gameState.faction_leader[4];
					}
					else if (GlobalScript.inst.gameState.politics_dolshnost[num91] == (byte)GlobalScript.inst.gameState.faction_leader[4])
					{
						array25[num91] = 150;
					}
				}
				for (int num92 = 0; num92 < array25.Length; num92++)
				{
					if (array25[num92] == 150)
					{
						GlobalScript.inst.gameState.politics_dolshnost[num92] = 150;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Новым Генеральным секретарем стал товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + ", который провозгласил курс на углубление реформ и широкомасштабную демократизацию страны. Однако движение \"Туйдан\" сочло это доказательством слабости руководства страны и организовало масштабные демонстрации по всей территории страны, закончившиеся отставкой правительства и вступлением Китая в переходный период. Коммунистическая партия теряет власть в стране и её судьба явно под угрозой...";
				GlobalScript.inst.gameState.data[4] = 1000;
				int[] array26 = new int[16]
				{
					GlobalScript.inst.gameState.leader.name_1,
					GlobalScript.inst.gameState.leader.name_2,
					GlobalScript.inst.gameState.leader.traits[0],
					GlobalScript.inst.gameState.leader.traits[1],
					GlobalScript.inst.gameState.leader.traits[2],
					GlobalScript.inst.gameState.leader.age,
					GlobalScript.inst.gameState.leader.face_type,
					GlobalScript.inst.gameState.leader.face_parts[0],
					GlobalScript.inst.gameState.leader.face_parts[1],
					GlobalScript.inst.gameState.leader.face_parts[2],
					GlobalScript.inst.gameState.leader.face_parts[3],
					GlobalScript.inst.gameState.leader.face_parts[4],
					GlobalScript.inst.gameState.leader.face_parts[5],
					GlobalScript.inst.gameState.leader.face_parts[6],
					GlobalScript.inst.gameState.leader.face_parts[7],
					GlobalScript.inst.gameState.leader.jacket
				};
				int num93 = GlobalScript.inst.gameState.faction_leader[4];
				Politic politic190 = GlobalScript.inst.gameState.politics[num93];
				if (GlobalScript.inst.gameState.citizens != null)
				{
					Persona[] citizens = GlobalScript.inst.gameState.citizens;
					foreach (Persona persona16 in citizens)
					{
						if (persona16.isLead)
						{
							persona16.isLead = false;
						}
					}
				}
				if (politic190.isCitizen)
				{
					achieves.GetComponent<achievements>().Set(210);
					string text19 = GlobalScript.inst.gameState.names1[politic190.name_1];
					string text20 = GlobalScript.inst.gameState.names2[politic190.name_2];
					Persona[] citizens = GlobalScript.inst.gameState.citizens;
					foreach (Persona persona17 in citizens)
					{
						if (persona17 != null && persona17.name == text19 && persona17.surname == text20)
						{
							persona17.isLead = true;
							int[] date8 = new int[3]
							{
								GlobalScript.inst.gameState.data[19],
								GlobalScript.inst.gameState.data[20],
								GlobalScript.inst.gameState.data[21]
							};
							string text21 = CitizenManager.FormatLog(persona17, "стал правителем.", "成为领袖。", date8);
							persona17.changeLog.Add(text21);
							Debug.Log(text21);
						}
					}
				}
				politic190.face_parts = (byte[])politic190.face_parts.Clone();
				GlobalScript.inst.gameState.leader.name_1 = politic190.name_1;
				GlobalScript.inst.gameState.leader.name_2 = politic190.name_2;
				GlobalScript.inst.gameState.leader.traits[0] = politic190.traits[0];
				GlobalScript.inst.gameState.leader.traits[1] = politic190.traits[1];
				GlobalScript.inst.gameState.leader.traits[2] = politic190.traits[2];
				GlobalScript.inst.gameState.leader.age = politic190.age;
				GlobalScript.inst.gameState.leader.face_type = politic190.face_type;
				for (int num94 = 0; num94 < 8; num94++)
				{
					GlobalScript.inst.gameState.leader.face_parts[num94] = politic190.face_parts[num94];
				}
				GlobalScript.inst.gameState.leader.jacket = politic190.jacket;
				politic190.name_1 = (byte)array26[0];
				politic190.name_2 = (byte)array26[1];
				politic190.traits[0] = (byte)array26[2];
				politic190.traits[1] = (byte)array26[3];
				politic190.traits[2] = (byte)array26[4];
				politic190.age = (byte)array26[5];
				politic190.face_type = (byte)array26[6];
				for (int num95 = 0; num95 < 8; num95++)
				{
					politic190.face_parts[num95] = (byte)array26[7 + num95];
				}
				politic190.jacket = (byte)array26[15];
				GlobalScript.inst.gameState.data[1] = 0;
				GlobalScript.inst.gameState.data[3] = 0;
				GlobalScript.inst.gameState.data[35] = 1;
				load_scene_after_click = "Ending";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 95)
		{
			text2 = "Новое начало для КПК";
			GlobalScript.inst.gameState.modifies[6].active = false;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "На чрезвычайном Пленуме ЦК КПК большинством голосов было принято решение об отказе от марксизма-ленинизма, маоизма и сяопизма в пользу новомодного еврокоммунизма, по образцу французской, итальянской, испанской и японской компартий. Соответствующие изменения были внесены в программные документы КПК. Это вызывает определенное недовольство наиболее консервативной части партократов, но в целом партия приняла новую идеологию, осознавая необходимость перемен.";
				GlobalScript.inst.gameState.data[1] -= 150;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[57] -= 50;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[6] -= 30;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic191 in politics)
				{
					if (politic191 != null)
					{
						if (politic191.traits[0] == 0)
						{
							Politic politic = politic191;
							politic.loyality -= 400;
						}
						else if (politic191.traits[0] == 3)
						{
							Politic politic = politic191;
							politic.loyality += 300;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "На чрезвычайном Пленуме ЦК КПК, после долгих споров, было решено вернуться к заветам Чэнь Дусю и Чжан Готао и признать социал-демократический характер партии. Соответствующие изменения были внесены в программные документы КПК. Это вызывает сильное недовольство консервативной части партократов, есть определенная опасность раскола КПК. Время покажет, правильно ли Вы поступили...";
				GlobalScript.inst.gameState.data[1] -= 300;
				GlobalScript.inst.gameState.data[3] += 80;
				GlobalScript.inst.gameState.data[57] -= 50;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[6] -= 50;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic192 in politics)
				{
					if (politic192 != null)
					{
						if (politic192.traits[0] == 0)
						{
							Politic politic = politic192;
							politic.loyality -= 500;
						}
						else if (politic192.traits[0] == 1)
						{
							Politic politic = politic192;
							politic.loyality -= 300;
						}
						else if (politic192.traits[0] == 3)
						{
							Politic politic = politic192;
							politic.loyality += 500;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "На чрезвычайном Пленуме ЦК КПК верх одержала группа партийцев, которая предложила возвратиться к истокам китайского революционного движения - к Сунь Ятсену и второму варианту его \"Трех народных принципов\" (борьба с феодализмом и капитализмом, демократизация государственной и общественной системы, улучшение жизни рабочих и ограничение монополистического капитала). Соответствующие изменения были внесены в программные документы КПК. Началось сближение КПК с Революционным комитетом Гоминьдана и левонационалистическими группировками, что нравится народу, но вызывает явное неодобрение партийцев.";
				GlobalScript.inst.gameState.data[1] -= 250;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[4] -= 80;
				GlobalScript.inst.gameState.data[6] -= 10;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic193 in politics)
				{
					if (politic193 != null)
					{
						if (politic193.traits[0] == 0)
						{
							Politic politic = politic193;
							politic.loyality -= 400;
						}
						else if (politic193.traits[0] == 1)
						{
							Politic politic = politic193;
							politic.loyality -= 100;
						}
						else if (politic193.traits[0] == 2)
						{
							Politic politic = politic193;
							politic.loyality += 100;
						}
						else if (politic193.traits[0] == 3)
						{
							Politic politic = politic193;
							politic.loyality += 400;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "На чрезвычайном Пленуме ЦК КПК победили сторонники сохранения марксизма-маоизма-сяопизма. Движение \"Туйдан\" набирает силу и активно нападает на КПК, партия теряет поддержку населения, а за ней и власть на местах. Кажется, в новом Китае для нее не останется места...";
				GlobalScript.inst.gameState.data[4] += 500;
				GlobalScript.inst.gameState.data[3] -= 500;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 96)
		{
			text2 = "Перестройка! Демократия! Гласность!";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "\"Патриотический единый фронт китайского народа\" был распущен, а мы начали создание избирательного законодательства, в наших интересах, разумеется. Избирательная система устроена так, чтобы обеспечить симпатизирующим нам группам преимущество, все партии, какие возможно было запретить, мы запретили, а другим для допуска к выборам необходимо будет преодолеть множество бюрократических барьеров. Тем временем последние остатки кровавой цензуры и контроля прошлого Китая вымываются новой гласностью и свободой.";
				GlobalScript.inst.gameState.data[15] = 8;
				GlobalScript.inst.gameState.data[50] = 27;
				GlobalScript.inst.gameState.data[57] -= 80;
				if (GlobalScript.inst.gameState.data[17] < 19)
				{
					GlobalScript.inst.gameState.data[17]++;
				}
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[3] += 30;
				GlobalScript.inst.gameState.data[4] += 80;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "\"Патриотический единый фронт китайского народа\" был распущен, а мы начали создание избирательного законодательства, самого свободного и честного в мире! С другой стороны эйфория от предстоящих свободных выборов позволила нам избежать масштабного \"откручивания гаек\", хотя для вида давление на религию и пришлось ослабить.";
				GlobalScript.inst.gameState.data[15] = 9;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[57] -= 50;
				GlobalScript.inst.gameState.data[50] = 27;
				GlobalScript.inst.gameState.data[4] += 80;
				GlobalScript.inst.gameState.data[6] -= 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "\"Патриотический единый фронт китайского народа\" был распущен, а мы начали создание избирательного законодательства, самого свободного и честного в мире! С другой стороны эйфория от предстоящих свободных выборов и снижения государственного контроля позволила нам сохранить нашу политику в области религии почти неизменной - да, юридически отправление религиозных служб было упрощено, но фактически священники и храмы всё ещё находятся под контролем МГБ и местной администрации.";
				GlobalScript.inst.gameState.data[15] = 9;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[57] -= 70;
				if (GlobalScript.inst.gameState.data[17] < 19)
				{
					GlobalScript.inst.gameState.data[17]++;
				}
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[6] -= 20;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Все предложения затормозить перестройку и демократизацию были жёстко раскритикованы нынешним лидером. \"Патриотический единый фронт китайского народа\" был распущен, а мы начали создание избирательного законодательства, самого свободного и честного в мире! Одновременно была начата демократизация всех сторон общественной жизни - не только на словах, но и на деле. Народ, конечно, доволен, но надолго ли?..";
				GlobalScript.inst.gameState.data[15] = 9;
				GlobalScript.inst.gameState.data[3] += 80;
				GlobalScript.inst.gameState.data[57] -= 120;
				if (GlobalScript.inst.gameState.data[17] < 19)
				{
					GlobalScript.inst.gameState.data[17]++;
				}
				GlobalScript.inst.gameState.data[4] += 120;
				GlobalScript.inst.gameState.data[6] -= 40;
				GlobalScript.inst.gameState.data[50] = 27;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 97)
		{
			text2 = "Автоматизация?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Была начата кампания по масштабной автоматизации планирования нашей экономики, активно строятся и включаются в работу региональные вычислительные центры, постепенно налаживается координация между ними. Отдел статистики уже прогнозирует нам серьёзное повышение производительности и улучшение снабжения, но не все в партии рады вашим нововведениям";
				GlobalScript.inst.gameState.data[1] = 0;
				GlobalScript.inst.gameState.data[8] -= 50;
				GlobalScript.inst.gameState.data[16] = 11;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic194 in politics)
				{
					if (politic194 != null)
					{
						Politic politic = politic194;
						politic.loyality -= 400;
					}
				}
				GlobalScript.inst.gameState.modifies[11].active = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Было заявлено о необходимости постепенного и осторожного внедрения столь новой технологии. Автоматизация низовых отделов планирования проходит крайне медленно и давится бюрократами. Такими темпами желаемого роста производительности мы достигнем не скоро.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 98)
		{
			GlobalScript.inst.gameState.data[103] = 15;
			text2 = "Африканский Че Гевара";
			GlobalScript.inst.gameState.allcountries[61].name = GlobalScript.inst.new_events_text[800];
			GlobalScript.inst.gameState.allcountries[61].Gosstroy = 2;
			GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 3;
			GlobalScript.inst.gameState.allcountries[61].Torg = false;
			GlobalScript.inst.gameState.allcountries[61].Vyshi = false;
			GlobalScript.inst.gameState.allcountries[61].proprc = false;
			GlobalScript.inst.gameState.allcountries[61].prosov = false;
			GlobalScript.inst.gameState.allcountries[61].dev = 500;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Правительство Буркина-Фасо приняло наших послов, и официальные отношения были установлены. Теперь Санкара начинает свою программу радикальных преобразований. В его планах: устранение голода, создание системы бесплатного образования и здравоохранения, борьба с эпидемиями и коррупцией, массовая вакцинация детей. Из-за своих антиимпериалистических взглядов, лидер Буркина-Фасо всё сильнее вовлекается в «Движение неприсоединения», оставаясь резким критиком колониализма и неоколониализма, «гуманитарной помощи» от западных держав и международных экономических организаций неолиберального толка, рассматривая её как форму неоколониализма. Для достижения цели радикальной трансформации общества Санкара установил авторитарный режим, запретил ряд политических организаций и свободные СМИ, которые считал угрозой своим планам, что, впрочем, нисколько не ударила по его популярности «народного освободителя». ";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 80;
				GlobalScript.inst.gameState.data[6] += 10;
				GlobalScript.inst.gameState.allcountries[61].Torg = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы никак не отреагировали на очередной военный переворот, которые сейчас случаются, чуть ли не каждый день. По данным международных организаций, в Буркина-Фасо разворачиваются свойственные «тоталитарным режимам» массовые репрессии государственного аппарата и ряда предпринимателей. Хорошо, что мы к этому не причастны.";
				GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 10;
				GlobalScript.inst.gameState.allcountries[61].Gosstroy = 0;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Делегация из КНР прибыла в Уагадугу на встречу с новым другом китайского народа. Нами была предложена продовольственная и военная помощь. Восхищенный нашей дружелюбностью Тома Санкара, во время торжественного ужина, выразил нам слова истинной благодарности: «С помощью наших китайских друзей, империалистическая тирания уйдёт в прошлое вместе с этим тысячелетием, и все люди будут жить в обществе равенства и свободы!». Теперь, по аналогии с Китаем, и с нашей поддержкой, Санкара начинает радикальные эксперименты в экономике, заявив о революционном переходе от феодализма к социализму, минуя капитализм, что было встречено с восторгом в народе. Теперь главной задачей правительства стали индустриализация и строительство механизированных сельхозкооперативов, развитие образования, инфраструктуры и медицины. Также, благодаря нашим агентам, оппозиция больше не волнует Санкару, что позволило его власти стабилизироваться. Сильное недовольство реформами Санкара выразила Франция, которая начинает искать способы его свержения и возвращения Буркина-Фасо в орбиту своего влияния.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				GlobalScript.inst.gameState.data[8] -= 50;
				GlobalScript.inst.gameState.data[9] -= 30;
				GlobalScript.inst.gameState.data[6] += 20;
				GlobalScript.inst.gameState.allcountries[61].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 2;
				GlobalScript.inst.gameState.allcountries[61].Torg = true;
				GlobalScript.inst.gameState.allcountries[61].proprc = true;
			}
			else
			{
				text = GlobalScript.inst.new_events_text[1290];
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
				GlobalScript.inst.gameState.allcountries[61].puppetOf = 21;
				GlobalScript.inst.gameState.data[9] -= 70;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				GlobalScript.inst.gameState.allcountries[61].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[61].SubGosstroy = 7;
				GlobalScript.inst.gameState.allcountries[61].Torg = true;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 114)
		{
			text2 = "Слон и осёл";
			int num96 = 0;
			int num97 = 0;
			if (GlobalScript.inst.gameState.empires[0].power > GlobalScript.inst.gameState.empires[1].power)
			{
				num97++;
			}
			else
			{
				num96++;
			}
			if (GlobalScript.inst.gameState.empires[0].power > GlobalScript.inst.gameState.influencePRC)
			{
				num97++;
			}
			else
			{
				num96++;
			}
			if (GlobalScript.inst.gameState.influencePRC > GlobalScript.inst.gameState.empires[1].power)
			{
				num97++;
			}
			else
			{
				num96++;
			}
			if (GlobalScript.inst.gameState.OAR)
			{
				num96++;
			}
			if (GlobalScript.inst.gameState.allcountries[15].cw)
			{
				num97++;
			}
			if (GlobalScript.inst.gameState.allcountries[1].isASEAN)
			{
				num97++;
			}
			if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
			{
				num97++;
			}
			if (GlobalScript.inst.gameState.allcountries[1].isSEATO)
			{
				num97++;
			}
			if (GlobalScript.inst.gameState.resultOfEvents[46] == 2)
			{
				num96++;
			}
			if (GlobalScript.inst.gameState.ingamewars[5].is_going)
			{
				num96++;
			}
			if (GlobalScript.inst.gameState.allcountries[84].Gosstroy == 0)
			{
				num96++;
			}
			else
			{
				num97++;
			}
			if (GlobalScript.inst.gameState.allcountries[8].Gosstroy == 3 || GlobalScript.inst.gameState.allcountries[8].Vyshi)
			{
				num97++;
			}
			else
			{
				num96++;
			}
			if (global1.dlc[0])
			{
				if (GlobalScript.inst.gameState.gamerules[2] == 1)
				{
					num97 += UnityEngine.Random.Range(-10, 10);
					num96 += UnityEngine.Random.Range(-10, 10);
				}
				else if (GlobalScript.inst.gameState.gamerules[2] == 2)
				{
					if (GlobalScript.inst.gameState.number_otvet == 1)
					{
						num97 += 100;
					}
					else
					{
						num96 += 100;
					}
				}
			}
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				if (num97 >= num96)
				{
					text = "По итогам выборов Картеру всё же удалось удержать власть. Ключевым фактором его выигрыша стало то, что умеренная внешняя политика в целом показала себя хорошо, несмотря на критику консерваторов. США ждут ещё 4 года правления демократов.";
					GlobalScript.inst.gameState.empires[0].now_leader = 1;
					GlobalScript.inst.gameState.data[143] += 2;
				}
				else
				{
					text = "По итогам выборов Картер потерпел поражение от Рейгана. Экономический кризис и внешнеполитические неудачи отразились на настроениях американцев, которые предпочли пойти за популистскими лозунгами республиканцев. Теперь же под руководством Рейгана США ждёт новый виток активного противостояния с СССР.";
					GlobalScript.inst.gameState.empires[0].now_leader = 0;
					GlobalScript.inst.gameState.allcountries[51].SubGosstroy = 12;
					GlobalScript.inst.gameState.data[143] -= 2;
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 117)
		{
			if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 1)
			{
				Leader[] leaders = GlobalScript.inst.gameState.empires[1].leaders;
				foreach (Leader leader6 in leaders)
				{
					Leader leader = leader6;
					leader.support += UnityEngine.Random.Range(-10, 11);
				}
			}
			text2 = "Пятилетка похорон";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Похороны Андропова состоялись в 12:00 14 февраля 1984 года у Кремлёвской стены на Красной площади Москвы. На траурную церемонию прощания прилетели главы государств и правительств многих стран.";
				if (GlobalScript.inst.gameState.relres)
				{
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
				}
				if (GlobalScript.inst.gameState.allcountries[7].isNATO)
				{
					GlobalScript.inst.gameState.empires[1].now_leader = 7;
					text += "|Вопреки ожиданиям генеральным секретарём ЦК КПСС стал Александр Яковлев - человек, имеющий репутацию ортодоксального марксиста, активный проводник кампании против национализма в культуре начала предыдущего десятилетия. Благодаря своему опыту дипломатической работы в Канаде, он обзавёлся сильными и прочными связями с определенной частью западной политической элиты, которые вполне могут помочь в проведении \"курса СССР на сближение с Западом\". Вполне можно ожидать и новых назначений на высшие государственные посты. Как нам известно, на пост главы советского правительства метит экономист Леонид Абалкин, а президиум Верховного Совета вполне может возглавить Михаил Горбачёв.";
				}
				else
				{
					GlobalScript.inst.gameState.empires[1].now_leader = 2;
					text += "| Генеральным секретарём, как и ожидалось, был избран Константин Черненко. Впрочем, учитывая его возраст, пробудет он в этой должности недолго.";
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "СССР поблагодарил нас за соболезнования и принял китайскую делегацию. Похороны Андропова состоялись в 12:00 14 февраля 1984 года у Кремлёвской стены на Красной площади Москвы. Помимо нашей делегации на траурную церемонию прощания прилетели главы государств и правительств многих стран.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
				GlobalScript.inst.gameState.empires[1].now_leader = 2;
				if (GlobalScript.inst.gameState.allcountries[7].isNATO)
				{
					GlobalScript.inst.gameState.empires[1].now_leader = 7;
					text += "|Вопреки ожиданиям генеральным секретарём ЦК КПСС стал Александр Яковлев - человек, имеющий репутацию ортодоксального марксиста, активный проводник кампании против национализма в культуре начала предыдущего десятилетия. Благодаря своему опыту дипломатической работы в Канаде, он обзавёлся сильными и прочными связями с определенной частью западной политической элиты, которые вполне могут помочь в проведении \"курса СССР на сближение с Западом\". Вполне можно ожидать и новых назначений на высшие государственные посты. Как нам известно, на пост главы советского правительства метит экономист Леонид Абалкин, а президиум Верховного Совета вполне может возглавить Михаил Горбачёв.";
				}
				else
				{
					GlobalScript.inst.gameState.empires[1].now_leader = 2;
					text += "| Генеральным секретарём, как и ожидалось, был избран Константин Черненко. Впрочем, учитывая его возраст, пробудет он в этой должности недолго.";
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Наш лидер лично возглавил китайскую делегацию и был тепло принят в СССР. Похороны Андропова состоялись в 12:00 14 февраля 1984 года у Кремлёвской стены на Красной площади Москвы. Помимо вас на траурную церемонию прощания прилетели главы государств и правительств многих стран.";
				GlobalScript.inst.gameState.empires[1].now_leader = 2;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 150;
				if (GlobalScript.inst.gameState.allcountries[7].isNATO)
				{
					GlobalScript.inst.gameState.empires[1].now_leader = 7;
					text += "|Вопреки ожиданиям генеральным секретарём ЦК КПСС стал Александр Яковлев - человек, имеющий репутацию ортодоксального марксиста, активный проводник кампании против национализма в культуре начала предыдущего десятилетия. Благодаря своему опыту дипломатической работы в Канаде, он обзавёлся сильными и прочными связями с определенной частью западной политической элиты, которые вполне могут помочь в проведении \"курса СССР на сближение с Западом\". Вполне можно ожидать и новых назначений на высшие государственные посты. Как нам известно, на пост главы советского правительства метит экономист Леонид Абалкин, а президиум Верховного Совета вполне может возглавить Михаил Горбачёв.";
				}
				else
				{
					GlobalScript.inst.gameState.empires[1].now_leader = 2;
					text += "| Генеральным секретарём, как и ожидалось, был избран Константин Черненко. Впрочем, учитывая его возраст, пробудет он в этой должности недолго.";
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 99)
		{
			text2 = "Жёлтый скорпион";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Благодаря нашей поддержке, лидер ортодоксальных сталинистов Мохаммед Яхьяуи смог расправиться с правой оппозицией и экстренный съезд ФНО назначил его генеральным секретарём, а Национальное народное собрание назначило его исполняющим обязанности президента Алжира, досрочные выборы назначены на 8 февраля 1979, впрочем, при однопартийной системе и безальтернативных выборах результат известен заранее. В стране начинается преследование «реакционных классов» и продолжается курс предшественника на индустриализацию. Новое правительство заявило о смене вектора внешней политики на прокитайскую и предложило нам подписать весьма выгодный торговый контракт. Советский Союз отрицательно отреагировал «на вмешательство Китая во внутренние дела Алжира»";
				GlobalScript.inst.gameState.data[9] -= 60;
				GlobalScript.inst.gameState.data[6] += 10;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 30;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 100;
				GlobalScript.inst.gameState.allcountries[40].prosov = false;
				GlobalScript.inst.gameState.allcountries[40].proprc = true;
				GlobalScript.inst.gameState.allcountries[40].Torg = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы поддержали Шадли Бенджедида и реформаторское крыло Фронта национального освобождения, в результате этого ряд наиболее активных сталинистов был арестован, оставшимся же пришлось проголосовать за Бенджедида, а прозападный либерал Бутефлик был снят с должности министра иностранных дел и передвинут на второстепенные роли. Экстренный съезд ФНО назначил Бенджедида генеральным секретарем, а Национальное народное собрание назначило его исполняющим обязанности президента Алжира, досрочные выборы назначены на 8 февраля 1979, впрочем, при однопартийной системе и безальтернативных выборах результат известен заранее. В стране готовятся полномасштабные реформы по поддержке единоличного крестьянства и малого предпринимательства, что поможет избавиться от излишнего влияния государства на экономику. Президент поблагодарил нас за поддержку и предложил нам выгодный торговый контракт, а Советский союз позитивно воспринял китайскую помощь Алжиру, в отличие от США.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 10;
				GlobalScript.inst.gameState.data[9] -= 40;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 30;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GlobalScript.inst.gameState.allcountries[40].Torg = true;
				GlobalScript.inst.gameState.allcountries[40].Gosstroy = 2;
				GlobalScript.inst.gameState.data[143]++;
				GlobalScript.inst.gameState.allcountries[40].SubGosstroy = 15;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "С помощью наших агентов, либеральный министр иностранных дел Бутефлик расправился с внутренней оппозицией в партии, и экстренный съезд ФНО избрал его генеральным секретарём, Национальное народное собрание назначило его исполняющим обязанности президента Алжира. Выборы перенесены на неопределённый срок, в связи с новой глобальной политической реформой и созданием новой конституции страны. Президент заявил о смене вектора экономики и переходе к смешанной рыночной системе. Был снят запрет на иностранные инвестиции и среднее предпринимательство, началась приватизация убыточных предприятий. Новое правительство объявило о начале углублённого сотрудничества со странами Запада в области внешней политики, что вызвало недовольство СССР, и было позитивно воспринято США и НАТО. Бутефлик поблагодарил нас за поддержку и предложил весьма выгодный контракт.";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 30;
				GlobalScript.inst.gameState.data[9] -= 60;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 300;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 30;
				GlobalScript.inst.gameState.allcountries[40].Torg = true;
				GlobalScript.inst.gameState.allcountries[40].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[40].SubGosstroy = 6;
				GlobalScript.inst.gameState.allcountries[40].prosov = false;
				GlobalScript.inst.gameState.allcountries[40].Vyshi = true;
				GlobalScript.inst.gameState.data[143] -= 3;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Экстренный съезд ФНО назначил «компромиссным» генеральным секретарём лидера реформаторов Шадли Бенджедида, Национальное народное собрание назначило его исполняющим обязанности президента Алжира, досрочные выборы назначены на 8 февраля 1979, впрочем, при однопартийной системе и безальтернативных выборах результат известен заранее. В Алжире начинаются крайне умеренные реформы, которые, впрочем, не могут угодить никому.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 100)
		{
			text2 = "КРИЗИС ПРАВИТЕЛЬСТВА";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Благодаря слаженной работе наших спецслужб, на нескольких из крупнейших заводов столицы Бангладеш были распущены слухи о предстоящих сокращениях рабочих мест и заработной платы, в связи с нарастающим финансовым кризисом. На следующий же день, весь город был парализован стачками и столкновениями рабочих с вооружённой полицией, в некоторых районах были слышны выстрелы. Тем не менее, из-за общественного давления и нарастающих беспорядков, президенту пришлось объявить о проведении досрочных парламентских выборов, на которых, не без нашей помощи, победила коалиция левых, а новым премьер-министром страны стала Шейх Хасина Вазед. Новое правительство объявило о начале социально-экономических реформ и расширении торговли между Китаем и Бангладеш. Мировое сообщество, в целом, проигнорировало смену власти, однако США подозревают нас в причастности к случившемуся.";
				GlobalScript.inst.gameState.data[9] -= 100;
				GlobalScript.inst.gameState.data[6] += 10;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 70;
				GlobalScript.inst.gameState.allcountries[32].Torg = true;
				GlobalScript.inst.gameState.allcountries[32].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[32].SubGosstroy = 3;
				GlobalScript.inst.gameState.allcountries[32].proprc = true;
				GlobalScript.inst.gameState.allcountries[32].Vyshi = false;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Правительство Бангладеш продолжает контролировать обстановку, своевременно подавляя забастовки.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Президент Эршад поблагодарил нас за помощь и предложил провести саммит между КНР и Бангладеш о «расширении торгово-экономического сотрудничества». На переговорах были восстановлены отношения между нашими странами, а Китай официально признал независимость Бангладеш от Пакистана, также были подписаны новые торговые контракты.";
				GlobalScript.inst.gameState.data[8] -= 80;
				GlobalScript.inst.gameState.allcountries[32].Torg = true;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 70;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 105)
		{
			text2 = "Конец албанского Сталина";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Рамиз Алия, как и ожидалось, не «стал ломать то, что и так прекрасно работает». Полный и абсолютный надзор партии над всеми сферами общественной жизни не был затронут, а ортодоксальное сталинистское крыло продолжило доминировать в АПТ. Однако режим всё же претерпел некоторые несущественные изменения: массовые репрессии быстро свернулись, аресты священнослужителей прекратились, а подавление инакомыслия приобрело «более точечный характер». И, несмотря на то, что Алия пока не планирует возобновлять активных отношений с Советами, начинает чувствоваться крен внешней политики Албании в пользу большей открытости.";
				GlobalScript.inst.gameState.allcountries[20].proprc = false;
				GlobalScript.inst.gameState.data[60] = 2;
				GlobalScript.inst.gameState.allcountries[20].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[20].SubGosstroy = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Совершенно неожиданные новости из Тираны! В самой, казалось бы, непоколебимой в идеологическом плане стране произошёл теракт, да ещё каких масштабов! На Рамиза Алия, действующего генерального секретаря и преемника Ходжи, было совершенно покушение во время его планового визита на один из заводов столицы. Несмотря на бдительную охрану, окружавшую лидера страны, террористу-рабочему удалось совершить несколько метких выстрелов, один из которых попал прямо в лёгкое. По пути в больницу Алия скончался. Чтобы пресечь народные волнения, в связи с этими событиями, власть перешла к ортодоксальным ходжаистам, создавшим триумвират Ходжа-Чуко-Чамкани. Через террориста-рабочего, спецслужбам удалось выйти на целую группировку косовских албанцев, якобы готовивших заговор и против других членов Политбюро. Данный инцидент стал поводом к новому витку партийных чисток и репрессий в государстве. Ходжаизм вновь восторжествовал, Албания продолжает оставаться в изоляции.";
				GlobalScript.inst.gameState.data[9] -= 60;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 5;
				GlobalScript.inst.gameState.data[60] = 3;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Лидер КНР отправил в МИД Албании телеграмму соболезнования, предложив «перезапустить» отношения между Китаем и Албанией. Через неделю Рамиз Алия посетил КНР с дипломатическим визитом, был вновь подписан «договор о китайско-албанской дружбе», а Китай выдал Албании солидный кредит на долгосрочный период в знак примирения между нашими странами. ";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 15;
				GlobalScript.inst.gameState.allcountries[20].Torg = true;
				GlobalScript.inst.gameState.allcountries[20].proprc = true;
				GlobalScript.inst.gameState.data[60] = 2;
				GlobalScript.inst.gameState.data[1] += 100;
				GlobalScript.inst.gameState.data[8] -= 30;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 80;
				GlobalScript.inst.gameState.allcountries[20].Gosstroy = 1;
				GlobalScript.inst.gameState.allcountries[20].SubGosstroy = 1;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 109)
		{
			text2 = "Золотой век Сомали";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Положение в Сомали продолжает ухудшаться, а Моххамед Сиад Барре всё сильнее расширяет военное сотрудничество с Соединёнными штатами.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 30;
				GlobalScript.inst.gameState.allcountries[42].prosov = false;
				GlobalScript.inst.gameState.allcountries[42].Vyshi = true;
				GlobalScript.inst.gameState.allcountries[42].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[42].SubGosstroy = 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Мы отправили гуманитарную и военную поддержку режиму Мохаммеда Сиад Барре, что позволило Сомали оправиться от разрушительных последствий огаденской войны. В итоге правительство начало широкомасштабное наступление на вооружённую оппозицию, тем самым укрепив режим СРСП. Лидер страны Барре поблагодарил Китай за предоставленную поддержку и уже заявил о расширении сотрудничества между нашими странами.";
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[22] -= 50;
				GlobalScript.inst.gameState.data[8] -= 80;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 70;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 70;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[6] += 30;
				GlobalScript.inst.gameState.allcountries[42].prosov = false;
				GlobalScript.inst.gameState.allcountries[42].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[42].proprc = true;
				GlobalScript.inst.gameState.allcountries[42].Torg = true;
				GlobalScript.inst.gameState.allcountries[42].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[42].SubGosstroy = 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Благодаря поддержке наших спецслужб, влиятельный военный Мухаммед Али Самантар, сговорившись с генералитетом, предъявил Мохаммеду Сиад Барре ультиматум, по которому президент страны должен в немедленном порядке сложить с себя полномочия. В итоге, лидер Сомали, под давлением военных, был вынужден подать в отставку. Пост президента занял компромиссный министр иностранных дел Абдирахман Джама Барре, действия которого де-факто контролируются верхушкой генералитета. Сомали заключил перемирие c Эфиопией, отказавшись от любых территориальных претензий, а также правительство страны восстановило отношения с Советским союзом, разорванные во время Огаденского конфликта. Новая власть объявила о военном нейтралитете, присоединившись к Движению неприсоединения, однако Сомали всё сильнее сближается с другими арабскими странами. Не забыв о нашей поддержке, правительство Сомали предложило нам расширить торговое сотрудничество между нашими странами.";
				GlobalScript.inst.gameState.data[9] -= 80;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 5;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 5;
				GlobalScript.inst.gameState.data[6] -= 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				GlobalScript.inst.gameState.allcountries[42].prosov = false;
				GlobalScript.inst.gameState.allcountries[42].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[42].Torg = true;
				GlobalScript.inst.gameState.allcountries[42].Gosstroy = 2;
				GlobalScript.inst.gameState.allcountries[42].SubGosstroy = 15;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 102)
		{
			text2 = "Ветер перемен?";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support += 200;
				}
				else
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
					leader.support += 3;
					GlobalScript.inst.gameState.data[9] -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
					leader.support += 200;
				}
				else
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
					leader.support += 3;
					GlobalScript.inst.gameState.data[9] -= 100;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2)
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[5];
					leader.support += 200;
				}
				else
				{
					Leader leader = GlobalScript.inst.gameState.empires[1].leaders[5];
					leader.support += 3;
					GlobalScript.inst.gameState.data[9] -= 100;
				}
			}
			if (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power)
			{
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[4];
				leader.support += 2;
			}
			if (GlobalScript.inst.gameState.allcountries[15].Gosstroy == 0 && GlobalScript.inst.gameState.allcountries[15].SubGosstroy == 0)
			{
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
				leader.support--;
			}
			if (global1.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 1)
			{
				Leader[] leaders = GlobalScript.inst.gameState.empires[1].leaders;
				foreach (Leader leader7 in leaders)
				{
					Leader leader = leader7;
					leader.support += UnityEngine.Random.Range(-10, 11);
				}
			}
			if (GlobalScript.inst.gameState.empires[1].leaders[6].support >= GlobalScript.inst.gameState.empires[1].leaders[5].support && GlobalScript.inst.gameState.empires[1].leaders[6].support >= GlobalScript.inst.gameState.empires[1].leaders[4].support)
			{
				if (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power + 200 && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC + 200)
				{
					text = "В итоге Генеральным секретарём ЦК КПСС был избран действующий секретарь ЦК Егор Лигачев. Ему удалось заручиться поддержкой умеренных партийцев, прежде всего, Андрея Громыко, и выдвинуть свою кандидатуру, которую, по старой большевистской традиции, одобрили единогласно.";
					GlobalScript.inst.gameState.empires[1].now_leader = 8;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 100;
				}
				else
				{
					text = "В итоге Генеральным секретарём ЦК КПСС был избран Михаил Горбачёв. Он феноменально быстро организовал съезд и обеспечил доставку членов Политбюро силами военной авиации, разумеется ничего не сказав своему противнику Романову. Заручившись поддержкой Громыко и умеренных, тот смог с минимальным перевесом голосов возглавить КПСС. Что же ожидает Советский Союз?";
					GlobalScript.inst.gameState.empires[1].now_leader = 6;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 250;
				}
			}
			else if (GlobalScript.inst.gameState.empires[1].leaders[4].support >= GlobalScript.inst.gameState.empires[1].leaders[5].support && GlobalScript.inst.gameState.empires[1].leaders[4].support >= GlobalScript.inst.gameState.empires[1].leaders[6].support)
			{
				text = "В итоге Генеральным секретарём ЦК КПСС был избран Григорий Романов, который, узнав о смерти Черненко, срочно прилетел в Москву, где сумел сплотить вокруг себя консервативные и умеренные круги. Советский Союз ждут интересные времена.";
				GlobalScript.inst.gameState.empires[1].now_leader = 4;
			}
			else if (GlobalScript.inst.gameState.empires[1].leaders[5].support + 1 > GlobalScript.inst.gameState.empires[1].leaders[4].support && GlobalScript.inst.gameState.empires[1].leaders[5].support + 1 > GlobalScript.inst.gameState.empires[1].leaders[6].support)
			{
				text = "В итоге Генеральным секретарём ЦК КПСС был избран Виктор Гришин. Заручившись поддержкой консервативного большинства, давно негласно договорившегося об избрании Гришина, и сорвав планы Горбачёва, тот сумел без проблем возглавить КПСС. Советский Союз ожидает ещё несколько лет брежневской стабильности.";
				GlobalScript.inst.gameState.empires[1].now_leader = 5;
			}
			else if (GlobalScript.inst.gameState.empires[1].leaders[6].support > GlobalScript.inst.gameState.empires[1].leaders[4].support)
			{
				if (GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.empires[0].power + 200 && GlobalScript.inst.gameState.empires[1].power > GlobalScript.inst.gameState.influencePRC + 200)
				{
					text = "В итоге Генеральным секретарём ЦК КПСС был избран действующий секретарь ЦК Егор Лигачев. Ему удалось заручиться поддержкой умеренных партийцев, прежде всего, Андрея Громыко, и выдвинуть свою кандидатуру, которую, по старой большевистской традиции, одобрили единогласно.";
					GlobalScript.inst.gameState.empires[1].now_leader = 8;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 100;
				}
				else
				{
					text = "Несмотря на многочисленные прения, в итоге Генеральным секретарём ЦК КПСС был избран Михаил Горбачёв. Он феноменально быстро организовал съезд и обеспечил доставку членов Политбюро силами военной авиации, разумеется ничего не сказав своему противнику Романову. Заручившись поддержкой Громыко и умеренных, тот смог с минимальным перевесом голосов возглавить КПСС. Что же ожидает Советский Союз?";
					GlobalScript.inst.gameState.empires[1].now_leader = 6;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 250;
				}
			}
			else if (GlobalScript.inst.gameState.empires[1].leaders[6].support < GlobalScript.inst.gameState.empires[1].leaders[4].support)
			{
				text = "Несмотря на многочисленные прения, в итоге Генеральным секретарём ЦК КПСС был избран Григорий Романов, который, узнав о смерти Черненко, срочно прилетел в Москву, где сумел сплотить вокруг себя консервативные и умеренные круги. Советский Союз ждут интересные времена.";
				GlobalScript.inst.gameState.empires[1].now_leader = 4;
			}
			else
			{
				text = "Несмотря на многочисленные прения, в итоге Генеральным секретарём ЦК КПСС был избран Виктор Гришин. Заручившись поддержкой консервативного большинства, давно негласно договорившегося об избрании Гришина, и сорвав планы Горбачёва, тот сумел без проблем возглавить КПСС. Советский Союз ожидает ещё несколько лет брежневской стабильности.";
				GlobalScript.inst.gameState.empires[1].now_leader = 5;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 104)
		{
			text2 = "ХII Всемирный фестиваль молодёжи и студентов";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				if ((GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 350) || GlobalScript.inst.gameState.empires[1].now_leader == 6)
				{
					text = "Наша заявка на участие была принята. Делегация из членов наших организаций по работе с молодёжью и лучших китайских студентов и членов Коммунистического союза молодёжи Китая была отправлена в Москву. В политическую программу фестиваля входили вопросы установления нового международного экономического порядка, обсуждение проблемы экономической помощи отсталым и развивающимся странам, борьба с нищетой и безработицей, поднимались проблемы охраны окружающей среды. На фестивале проводились многочисленные концерты популярных групп и самодеятельных коллективов, выставки художников и фотографов. Все остались довольны мероприятием и мы не прогадали, отправив туда делегацию, тем более это поспособствовало улучшению наших отношений не только с СССР, но и с капиталистическими странами.";
					GlobalScript.inst.gameState.data[4] += 20;
					GlobalScript.inst.gameState.data[3] += 80;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC += 10;
					GlobalScript.inst.gameState.data[1] += 50;
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 100;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
				}
				else
				{
					text = "Находящийся с нами в плохих отношениях СССР решил напрячь свои связи в ВФДМ и использовать свою позицию принимающей страны, в результате наша заявка на участие была отклонена. Впрочем подобным остались недовольны не только мы, но и некоторые другие страны и левые движения.";
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power -= 10;
					GameState gameState = GlobalScript.inst.gameState;
					gameState.influencePRC -= 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В политическую программу фестиваля входили вопросы установления нового международного экономического порядка, обсуждение проблемы экономической помощи отсталым и развивающимся странам, борьба с нищетой и безработицей, поднимались проблемы охраны окружающей среды. На фестивале проводились многочисленные концерты популярных групп и самодеятельных коллективов, выставки художников и фотографов. Для нас же ничего не произошло, так как делегацию мы решили не отправлять.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Пока в Москве проходил ХII Всемирный фестиваль молодёжи и студентов, мы решили подчеркнуть свою независимость от СССР и организовали в Пекине собственный \"Фестиваль прогрессивной молодёжи мира\", куда приехали представители союзных Китаю стран и тех, которые по тем или иным причинам не послали делегацию в Москву. В целом наш народ остался доволен проведённым мероприятием, а наши связи с союзниками укрепились, но вот международное левое движение поглядывает на всё это с недоверием.";
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[3] += 40;
				GlobalScript.inst.gameState.data[1] += 150;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 150;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 50;
				GlobalScript.inst.gameState.data[8] -= 20;
				Country[] allcountries = GlobalScript.inst.gameState.allcountries;
				foreach (Country country9 in allcountries)
				{
					if (country9.okb)
					{
						Country country2 = country9;
						country2.soc_stab += 100;
						if (country9.usalliance)
						{
							country9.usalliance = false;
							GlobalScript.inst.gameState.data[9] -= 30;
							GlobalScript.inst.gameState.data[8] -= 50;
						}
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 107)
		{
			text2 = "Кризис среди союзников";
			int num98 = (GlobalScript.inst.gameState.data[21] - 1976) * 2 + 1;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Под видом учений наши войска вошли в страну, быстро разоружив их армию, арестовав правительство и подавив недовольство. Новому правительству для закрепления лояльности была выделена финансовая помощь. " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " снова с нами, но наша дипломатическая репутация оставляет желать лучшего.";
				GlobalScript.inst.gameState.data[22] -= num98 * 10;
				GlobalScript.inst.gameState.data[8] -= 30;
				GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 1000;
				Country[] allcountries = GlobalScript.inst.gameState.allcountries;
				foreach (Country country10 in allcountries)
				{
					if (country10.okb || country10.econ)
					{
						Country country2 = country10;
						country2.soc_stab -= 50;
					}
				}
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
				{
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 150;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance = false;
					GlobalScript.inst.gameState.data[6] += 30;
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
				{
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 150;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance = false;
					GlobalScript.inst.gameState.data[6] -= 30;
				}
				GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].proprc = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Путём закулисных интриг, тайных убийств и мобилизации оставшихся верными нам политиков и военных нам удалось организовать переворот в пользу тех, кто готов и дальше с нами сотрудничать. Новому правительству для закрепления лояльности была выделена финансовая помощь. " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " снова с нами, но другие страны что-то подозревают и высказывают своё недовольство";
				GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 1000;
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
				{
					GlobalScript.inst.gameState.data[9] -= 100;
					GlobalScript.inst.gameState.data[8] -= 30;
				}
				else
				{
					GlobalScript.inst.gameState.data[9] -= 200;
					GlobalScript.inst.gameState.data[8] -= 60;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].proprc = true;
				}
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
				{
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.relations -= 100;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance = false;
					GlobalScript.inst.gameState.data[6] += 10;
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
				{
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.relations -= 100;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance = false;
					GlobalScript.inst.gameState.data[6] -= 10;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Было решено не прибегать к радикальным мерам, а задобрить страну и заодно экономически привязать её к нам. Это помогло заставить сторонников независимости отказаться от поспешных планов, а сторонники дружбы с Китаем обрели дополнительную власть. " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " снова с нами и нам удалось избежать каких-либо дипломатических проблем, вот только сторонники независимой политики никуда не исчезли.";
				GlobalScript.inst.gameState.data[8] -= 100;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 1000;
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
				{
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 3)
					{
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 2;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 15;
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 1)
				{
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 2;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 15;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Было решено не прибегать к радикальным мерам, а только потребовать от руководства страны гарантий членства в нашем блоке, при сохранении возможности проводить независимую внешнюю политику. После долгих переговоров и колебаний они, наконец, согласились." + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " всё ещё в нашем альянсе, но активно наращивает новые контакты с другими странами, и это может нам выйти боком в будущем.";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 10;
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
				{
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 30;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance = false;
					GlobalScript.inst.gameState.data[6] -= 30;
					empire = GlobalScript.inst.gameState.empires[0];
					empire.relations += 50;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 3)
					{
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 2;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 15;
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
				{
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 30;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance = false;
					GlobalScript.inst.gameState.data[6] += 30;
					empire = GlobalScript.inst.gameState.empires[1];
					empire.relations += 50;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 1)
					{
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 2;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 15;
					}
				}
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[8] -= 10;
				GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 500;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "В итоге, не встретив какого-либо сопротивления с нашей стороны страна приняла решение выйти из нашего блока и уже налаживает новые контакты. Зато не социал-империализм!";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC -= 20;
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
				{
					Empire empire = GlobalScript.inst.gameState.empires[0];
					empire.power += 50;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 3)
					{
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 3;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 12;
					}
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
				{
					Empire empire = GlobalScript.inst.gameState.empires[1];
					empire.power += 50;
					if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 0 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy != 1)
					{
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].Gosstroy = 1;
						GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].SubGosstroy = 1;
					}
				}
				GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].proprc = false;
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
				{
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 1000;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb = false;
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].econ)
				{
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].soc_stab = 0;
					GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].econ = false;
				}
			}
			GlobalScript.inst.gameState.data[120] = -1;
		}
		else if (GlobalScript.inst.gameState.number_event == 103)
		{
			text2 = "Шенгенское соглашение";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "В Шанхае прошла конференция между странами нашего союза, закончившаяся подписанием т.н. Шанхайского соглашения, подразумевающего создание единого визового пространства между нашими странами и упрощение паспортно визового контроля с перспективой полного отказа от необходимости наличия заграничных паспортов. Соглашение постепенно начинает работать и народ доволен, вот только вместе с этим он начинает увлекаться заграничной культурой и ставить под сомнение наши государственные устои. Преступникам и диссидентам теперь станет проще сбежать из Китая, а контрабандистам - протащить к нам свои товары. Зато связи между нашими странами ещё больше укрепились, а прибыль от туризма пополнит наш бюджет.";
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[3] += 80;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.data[26] += 30;
				GlobalScript.inst.gameState.data[8] += 30;
				Country[] allcountries = GlobalScript.inst.gameState.allcountries;
				foreach (Country country11 in allcountries)
				{
					if (country11.okb)
					{
						Country country2 = country11;
						country2.soc_stab += 200;
						GlobalScript.inst.gameState.data[8] -= 5;
						if (!country11.proprc && !country11.sovalliance && !country11.usalliance)
						{
							country11.proprc = true;
							GlobalScript.inst.gameState.data[8] -= 20;
						}
						else if (!country11.proprc && (country11.sovalliance || country11.usalliance))
						{
							country11.sovalliance = false;
							country11.usalliance = false;
							GlobalScript.inst.gameState.data[8] -= 30;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "В Шанхае прошла конференция между странами нашего союза, закончившаяся подписанием т.н. Шанхайского соглашения, подразумевающего создание единого визового пространства между нашими странами и упрощение паспортно визового контроля с перспективой полного отказа от необходимости наличия заграничных паспортов. Соглашение постепенно начинает работать и народ доволен, вот только вместе с этим он начинает увлекаться заграничной культурой и ставить под сомнение наши государственные устои. Преступникам и диссидентам теперь станет проще сбежать из Китая, а контрабандистам - протащить к нам свои товары. Зато связи между нашими странами ещё больше укрепились, а прибыль от туризма пополнит наш бюджет.";
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[3] += 80;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				GlobalScript.inst.gameState.data[26] += 30;
				GlobalScript.inst.gameState.data[8] += 30;
				Country[] allcountries = GlobalScript.inst.gameState.allcountries;
				foreach (Country country12 in allcountries)
				{
					if (country12.okb || country12.econ)
					{
						Country country2 = country12;
						country2.soc_stab += 200;
						GlobalScript.inst.gameState.data[8] -= 5;
						if (!country12.proprc && !country12.sovalliance && !country12.usalliance)
						{
							country12.proprc = true;
							GlobalScript.inst.gameState.data[8] -= 20;
						}
						else if (!country12.proprc && (country12.sovalliance || country12.usalliance))
						{
							country12.sovalliance = false;
							country12.usalliance = false;
							GlobalScript.inst.gameState.data[8] -= 30;
						}
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Ничего не произошло.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 106)
		{
			text2 = "Демократический интернационал";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "В итоге Демократический интернационал был учреждён. Пока сложно говорить о том, поможет ли это антикоммунистическим повстанцам в их действиях, однако данное событие является знаковым и способствует росту влияния США, которые активно поддерживают данное формирование.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Сумев в срочном порядке наладить взаимодействие нашей агентуры в Анголе и приграничных странах, а также негласно склонив СССР и власти просоветской Анголы к сотрудничеству, мы смогли организовать серию терактов в Джамбе. К сожалению лидер УНИТА Жонас Савимби и американские кукловоды не пострадали, однако нам удалось ликвидировать неформального лидера контрас Адольфо Калеро, видного представителя моджахедов Абдула Рахима Вардака и лидера хмонгского движения Па Као Хэ. Помимо срыва коалиции, смерть многих видных лиц мирового антикоммунизма серьёзно ударила по американскому влиянию и помогла СССР. Именно поэтому все основные обвинения полетели в его адрес, однако и о нашем участии американцы что-то подозревают.";
				GlobalScript.inst.gameState.data[9] -= 100;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 30;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 10;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 200;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Мы поддержали формирование Демократического интернационала и его готовность бороться с советской агрессией по всему миру. Его участники по разному восприняли это заявление, но в целом отнеслись положительно, как и американцы, которые и извлекли из него наибольшую выгоду. Наша же выгода пока неясна, однако советское влияние определённо снизилось.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 120;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 30;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
				Country[] allcountries = GlobalScript.inst.gameState.allcountries;
				foreach (Country country13 in allcountries)
				{
					if (country13.okb || country13.econ)
					{
						Country country2 = country13;
						country2.soc_stab += 50;
						if (country13.sovalliance)
						{
							country13.sovalliance = false;
							GlobalScript.inst.gameState.data[9] -= 30;
							GlobalScript.inst.gameState.data[8] -= 50;
						}
					}
					else if (country13.dev > 100 && country13.stab > 100 && country13.prosov)
					{
						Country country2 = country13;
						country2.stab -= 150;
						country2 = country13;
						country2.dev -= 50;
					}
					else if ((country13.dev > 50 || country13.stab > 50) && country13.Vyshi)
					{
						Country country2 = country13;
						country2.stab += 150;
						country2 = country13;
						country2.dev -= 100;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 110)
		{
			text2 = "Автоматизация – естественный процесс";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Социалистическая экономика продолжает стабильно функционировать, до поры до времени…";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Слава председателю! Слава КПК! Этот день войдёт в историю Китая, как день «Великого перелома». Наш Дорогой Лидер объявил о начале крупных перемен в нашей стране – переходу КНР на рельсы полномасштабной автоматизации и компьютеризации всего планирования и производства в стране, а также заявил о создании «Центра по автоматизированному управлению экономикой», который вот-вот должен начать свою работу. Новый проект получил рабочее название МЭСУ – «Межотраслевая электронная система управления». Теперь в стране разгорелись «жаркие» дискуссии по поводу поспешности введения этих мер, а некоторые политики-партийцы заявляют об «антимарксистском характере реформ». Однако старт проекту был дан и уже ничего не остановит неминуемые перемены в стране, не так ли?";
				GlobalScript.inst.gameState.data[8] -= 100;
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[4] += 100;
				GlobalScript.inst.gameState.data[1] -= 600;
				GlobalScript.inst.gameState.data[118] = 1;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Слава председателю! Слава КПК! Этот день войдёт в историю Китая, как день «Великого перелома». Наш Дорогой Лидер объявил о начале крупных перемен в нашей стране – переходу КНР на рельсы полномасштабной автоматизации и компьютеризации всего планирования и производства в стране, а также заявил о создании «Центра по автоматизированному управлению экономикой», который вот-вот должен начать свою работу. Новый проект получил рабочее название МЭСУ – «Межотраслевая электронная система управления». Также, благодаря нашей близкой дружбе с советским народом, мы запросили квалифицированную помощь  из СССР, и теперь в Китай приехала делегация во главе с академиком Анатолием Китовым. В Китае тем временем разгорелись жаркие дискуссии по поводу поспешности введения данных мер, а некоторые партийцы уже заявляют об «антимарксистском характере реформ». Однако старт проекту был дан и уже ничего не остановит неминуемые перемены в стране, не так ли?";
				GlobalScript.inst.gameState.data[8] -= 80;
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[4] += 120;
				GlobalScript.inst.gameState.data[1] -= 600;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 100;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 100;
				GlobalScript.inst.gameState.data[118] = 1;
				GlobalScript.inst.gameState.data[73] += 300;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Слава председателю! Слава КПК! Этот день войдёт в историю Китая, как день «Великого перелома». Наш Дорогой Лидер объявил о начале крупных перемен в нашей стране – переходу КНР на рельсы полномасштабной автоматизации и компьютеризации всего планирования и производства в стране, а также заявил о создании «Центра по автоматизированному управлению экономикой», который вот-вот должен начать свою работу. Новый проект получил рабочее название МЭСУ. – «Межотраслевая электронная система управления». К тому же, благодаря нашим тёплым отношениям с западными странами, мы смогли пригласить делегацию европейских учёных-математиков во главе со Стаффордом Биром, который до этого прославился разработкой чилийского «Киберсина». Теперь в стране разгорелись «жаркие» дискуссии по поводу поспешности введения этих мер, а некоторые политики-партийцы заявляют об «антимарксистском характере реформ». Однако старт проекту был дан и уже ничего не остановит неминуемые перемены в стране, не так ли?";
				GlobalScript.inst.gameState.data[8] -= 80;
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[4] += 150;
				GlobalScript.inst.gameState.data[1] -= 600;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 50;
				GlobalScript.inst.gameState.data[118] = 1;
				GlobalScript.inst.gameState.data[73] += 300;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 111)
		{
			text2 = "К призрачному свету";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Изменения грядут...";
				GlobalScript.inst.gameState.data[35] = 6;
				load_scene_after_click = "Ending";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Сегодня во всех газетах страны вышла статья «Воззвание к народу», в которой Товарищ Председатель призывает каждого гражданина, любящего свою родину и партию, тем, кому не безразлична судьба Китая, оказать сопротивление вновь поднявшим голову «пособникам буржуазии» и «ревизионистам-партократам». Вдохновлённые народные массы собрались на митинги на площади Тяньаньмэнь в поддержку действий правительства и товарища председателя. В итоге на главную площадь страны пришло свыше 300 тысяч человек, скандирующих лозунги о  продолжении культурной революции  против реакционных классов. Под давлением общественного гнева заговорщикам пришлось подать в отставку со своих постов, а местные партократы усмирили свой пыл. Это великая победа нашего народа! Слава председателю! Слава КПК!";
				GlobalScript.inst.gameState.data[6] += 70;
				GlobalScript.inst.gameState.data[3] += 100;
				GlobalScript.inst.gameState.data[1] -= 400;
				int num99 = 0;
				for (int num100 = 0; num100 < GlobalScript.inst.gameState.politics.Length; num100++)
				{
					if (GlobalScript.inst.gameState.politics[num100].loyality < 300 && num99 < 3)
					{
						GlobalScript.inst.gameState.KillPerson(num100);
						num99++;
					}
					else if (num99 >= 3)
					{
						break;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Благодаря слаженной работе наших агентов, противники нашей политики автоматизации в высших эшелонах власти были сняты со всех постов и вот-вот будут преданы справедливому суду. На местах, в свою очередь, была начата кампания по искоренению коррупции, пошатнувшая положение нескольких десятков тысяч партработников, которые высказывались против политики, проводимой Коммунистической партией. Политические репрессии против противников Нашего Дорогого Лидера вызвали недовольство остальных партийных работников, которым, по соображениям личной безопасности, пришлось скрыть свою обиду. Тем не менее, это наша грандиозная победа! Слава председателю! Слава КПК!";
				GlobalScript.inst.gameState.data[9] -= 400;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[6] += 50;
				GlobalScript.inst.gameState.data[1] -= 500;
				int num101 = 0;
				for (int num102 = 0; num102 < GlobalScript.inst.gameState.politics.Length; num102++)
				{
					if (GlobalScript.inst.gameState.politics[num102].loyality < 300 && num101 < 3)
					{
						GlobalScript.inst.gameState.KillPerson(num102);
						num101++;
					}
					else if (num101 >= 3)
					{
						break;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "На следующий день лояльные военные дивизии вошли в Пекин, заговорщики были арестованы и преданы суду. В столице был установлен комендантский час, улицы города контролируются военными частями, кажется обстановка постепенно стабилизируется. Самые инициативные партократы подверглись увольнениям, а остальным пришлось усмирить свой шквал критики в сторону проводимой товарищем " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " политики. Тем не менее, враги  рабочего класса повержены, это наша грандиозная победа! Слава председателю! Слава КПК!";
				GlobalScript.inst.gameState.data[22] -= 300;
				GlobalScript.inst.gameState.data[3] += 50;
				GlobalScript.inst.gameState.data[1] -= 500;
				GlobalScript.inst.gameState.data[6] += 50;
				int num103 = 0;
				for (int num104 = 0; num104 < GlobalScript.inst.gameState.politics.Length; num104++)
				{
					if (GlobalScript.inst.gameState.politics[num104].loyality < 300 && num103 < 3)
					{
						GlobalScript.inst.gameState.KillPerson(num104);
						num103++;
					}
					else if (num103 >= 3)
					{
						break;
					}
				}
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 112)
		{
			text2 = "Предания неведомых миров";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Правительство в срочном порядке выделило средства на разработку системы защиты МЭСУ от внешних атак, которая получила рабочее название «Великая китайская стена». Предполагается, что защита будет готова и введена через 8 месяцев, а пока что нашей экономике будет нелегко.";
				GlobalScript.inst.gameState.data[8] -= 250;
				GlobalScript.inst.gameState.data[3] -= 150;
				GlobalScript.inst.gameState.data[4] += 300;
				GlobalScript.inst.gameState.data[1] -= 300;
				GlobalScript.inst.gameState.data[5] -= 100;
				GlobalScript.inst.gameState.data[12] -= 200;
				GlobalScript.inst.gameState.data[13] -= 200;
				GlobalScript.inst.gameState.data[68] -= 200;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Китайское правительство выделило деньги на разработку системы защиты МЭСУ от внешних атак, которая получила рабочее название «Великая китайская стена». К тому же, мы запросили помощь специалистов и инженеров из СССР, которые помогут нам скорее уничтожить уязвимые места в нашей системе и вернуть её в строй. Предполагается, что защита будет готова и введена через 6 месяцев, а пока что нашей экономике будет нелегко.";
				GlobalScript.inst.gameState.data[8] -= 250;
				GlobalScript.inst.gameState.data[3] -= 150;
				GlobalScript.inst.gameState.data[4] += 300;
				GlobalScript.inst.gameState.data[1] -= 300;
				GlobalScript.inst.gameState.data[5] -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Китайским правительством был выпущен декрет о «Проблемах автоматизации и их путях решения», в котором говорится о чрезмерной поспешности в компьютеризации и автоматизации планирования и неготовности экономики Китая к слишком быстрым и радикальным изменениям, тем более в такой технократический уклон. Проект МЭСУ был реорганизованным в «Отдел по управлению автоматизацией производства», главной  задачей которого уже не является создание единой компьютеризованной системы. Что из этого получится, покажет время.";
				GlobalScript.inst.gameState.data[8] -= 250;
				GlobalScript.inst.gameState.data[3] -= 300;
				GlobalScript.inst.gameState.data[4] += 500;
				GlobalScript.inst.gameState.data[16] = 10;
				GlobalScript.inst.gameState.data[5] -= 100;
				GlobalScript.inst.gameState.data[12] -= 200;
				GlobalScript.inst.gameState.data[13] -= 200;
				GlobalScript.inst.gameState.data[68] -= 200;
				GlobalScript.inst.gameState.modifies[11].active = false;
				GlobalScript.inst.gameState.data[16] = 10;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 113)
		{
			text2 = "Агония югославского социалистического самоуправления";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Ни Петар Стамболич (серб), ни сменивший его на посту Председателя Президиума СФРЮ Мика Шпиляк (хорват) так и не рискнули на проведение предложенных комиссией реформ. СФРЮ взяла дополнительные кредиты у МВФ и СССР, что лишь продлит агонию югославской экономики на какое-то время...";
				GlobalScript.inst.gameState.data[86]--;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Наш Председатель лично позвонил Петару Стамболичу (сербу), Милке Планинцу (хорвату) и Мите Рибичичу (словену), передав им наше предложение о реструктуризации госдолга Югославии в обмен на отказ от реформ. Неожиданно выяснилось, что югославы сами точно не знают, кому и сколько они должны - столько долгов понабрала Югославия. Нам пришлось заступиться за СФРЮ в ООН и использовать возможности МГБ, чтобы хоть как-то надавить на МВФ и МБЭР по вопросу определения размера задолженности. Наконец, кредиторы выставили окончательный счет - 53 млрд. долларов под 8% годовых, согласившись списать все остальное. Часть этих средств выплатим мы, как гарант соглашения, все остальное Югославия выплатит самостоятельно. Югославское руководство благодарит нас за спасение от экономического краха, СФРЮ уже заключила с нами новые выгодные торговые контракты и налаживает культурные связи между своими республиками и нашими автономными районами. Правда, нашей экономики спасение Югославии от финансового краха явно на пользу не пошло...";
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[9] -= 50;
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[8] -= 200;
				GlobalScript.inst.gameState.data[86] += 2;
				if (!GlobalScript.inst.gameState.allcountries[15].Torg)
				{
					GlobalScript.inst.gameState.allcountries[15].Torg = true;
				}
				else
				{
					GlobalScript.inst.gameState.data[9] += 30;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Руководство стран-членов ОВД было очень встревожено работой \"комиссии Крайгера\" и предложило Югославии крупную финансовую помощь в обмен на отказ от реализации предложенных ею реформ. Мы также поддержали это предложение. Опасаясь попасть в полную экономическую зависимость от СССР и Китая, руководство Югославии вежливо отказалось от помощи - однако \"комиссия Крайгера\" была расформирована, часть её членов исключили из Союза коммунистов Югославии, а сам Сергей Крайгер был отправлен на пенсию. Однако после этого Югославия расширила свое участие в деятельности СЭВ и подала заявку на вход в состав Совета на правах полноправного члена. Кооперация со странами-членами СЭВ позволила оживить экономику Югославии, однако рано или поздно по долгам все равно придется платить...";
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 200;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 50;
				GlobalScript.inst.gameState.data[6] -= 10;
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[86]++;
				GlobalScript.inst.gameState.allcountries[15].isSEV = true;
				if (!GlobalScript.inst.gameState.allcountries[15].Torg)
				{
					GlobalScript.inst.gameState.allcountries[15].Torg = true;
				}
				else
				{
					GlobalScript.inst.gameState.data[9] += 30;
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 4)
			{
				text = "Работа \"комиссии Крайгера\" и новости о том, что первыми под сокращение пойдут военные расходы, вызвали сильное недовольство среди офицерского состава Югославской народной армии. Мы решили воспользоваться этим и поддержать недовольных, подтолкнув их к открытому выступлению. 1 марта 252-я бронетанковая бригада, 1-я Пролетарская механизированная дивизия и 453-я механизированная бригада ЮНА подняли мятеж и быстро заняли Белград. Силами военной контрразведки было арестовано все руководство страны и Союза коммунистов Югославии. Власть перешла к Военному совету защиты народа Югославии во главе с генералом Велько Кадиевичем (югославом) и адмиралом Бранко Мамулой (словеном-сторонником единой Югославии), которые заявили о \"верности делу Маркса-Энгельса-Ленина и товарища Тито\" и \"бескомпромиссной борьбе с врагами и предателями, защите братства и единства народов и народностей Югославии\". Вместо расформированного СКЮ был создан Союз коммунистов - движение за Югославию (СК-ПЮ), в котором все руководство также перешло в руки военных. Югославия заявила о прекращении политики \"неприсоединения\", выходе из Движения неприсоединения и об ориентации на социалистичесий лагерь, \"равно возглавляемый СССР и Китаем\", а также об отказе от выплаты всех долгов. США уже заявили, что не оставят это без ответа, а в Словении наблюдается значительный рост сепаратистских настроений...";
				GlobalScript.inst.gameState.data[9] -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 20;
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[6] += 30;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power += 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.power -= 30;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 250;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 200;
				GlobalScript.inst.gameState.data[86] += 2;
				if (!GlobalScript.inst.gameState.allcountries[15].Torg)
				{
					GlobalScript.inst.gameState.allcountries[15].Torg = true;
				}
				else
				{
					GlobalScript.inst.gameState.data[9] += 30;
				}
				GlobalScript.inst.gameState.allcountries[15].Gosstroy = 0;
				GlobalScript.inst.gameState.allcountries[15].SubGosstroy = 0;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 5)
			{
				text = "Как только в США стало известно о работе комиссии, Югославия получила предложение об получении новых кредитов на выгодных для нее условиях - но только при одобрении пакета рыночных реформ. После того, как мы поддержали его и по неофициальным каналам посоветовали руководству СФРЮ согласится - Петар Стамболич (серб) досрочно ушел в отставку с поста Председателя Президиума СФРЮ, а Милка Планинц (хорват) - с поста премьера СФРЮ. Их заменили сторонники реформ Мика Шпиляк и Анте Маркович (оба - хорваты), которые начали реализацию проекта, разработанного комиссией. Началась приватизация госсобственности, окончательно ликвидированы задруги и разрешено фермерское хозяйство, а в Дубровнике и Сплите открыты СЭЗ. Правда, ликвидация Фонда федерации вызвала резкое недовольство слаборазвитых республик и автономных краев, командование ЮНА возмущено резким сокращением военных расходов, а перевод Словении и Хорватии на полный хозрасчет привел к резкому всплеску национализма и сепаратизма...";
				GlobalScript.inst.gameState.data[9] -= 50;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.power += 20;
				GlobalScript.inst.gameState.data[1] += 50;
				GlobalScript.inst.gameState.data[6] -= 30;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 20;
				empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 200;
				empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 250;
				GlobalScript.inst.gameState.data[86] -= 3;
				GlobalScript.inst.gameState.allcountries[15].Vyshi = true;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 6)
			{
				text = "Югославия находилась в очень тяжёлом положении и вынуждена была ввести жесточайшую экономию всего, что привело к обнищанию и дефициту даже продуктов первой необходимости и топлива. И тут явились мы. Проведя экстренные переговоры с премьер-министром Милка Планинц мы смогли договориться о выкупе югославских долговых облигаций и их частичной реструктуризации в обмен на доступ наших предприятий на льготных условиях к югославскому рынку. Подобное проникновение на югославский рынок в долгосрочной перспективе позволит нам осторожно вмешиваться во внутреннюю политику страны.";
				GlobalScript.inst.gameState.data[9] -= 80;
				GlobalScript.inst.gameState.data[8] -= 200;
				GlobalScript.inst.gameState.allcountries[15].Vyshi = false;
				GlobalScript.inst.gameState.allcountries[15].Torg = true;
				GlobalScript.inst.gameState.allcountries[15].proprc = true;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.influencePRC += 5;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 115)
		{
			text2 = "Золотой треугольник";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Всё идёт как и шло.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Несмотря на протесты узнавших о соглашении принципиальных партийцев, мы всё же смогли добиться сотрудничества с Кхун Са, который решил, что от такой помощи лучше не отказываться. Теперь агенты МГБ и служащие НОАК занимаются охраной опиумных промыслов и помогают в переправке наркотиков на запад, куда по нашему настоянию теперь идёт абсолютное большинство \"товара\". Всплеск продаж героина на западе не лучшим образом сказывается на его экономике и здоровье населения и требует от полиции этих стран большего напряжения сил, на что идёт больше бюджетных денег. Шанские сепаратисты с новой силой развернули действия против правительственных войск Бирмы, хотя и не добились больших успехов. Так как мы позаботились о секретности, то официально предъявить нам нечего, но власти Бирмы всё равно догадываются и сокращают с нами товарооборот, а часть наших местных чиновников и задействованных офицеров тоже решила приобщиться к выгодному бизнесу. Будем надеятся, наша прибыль компенсирует это.";
				GlobalScript.inst.gameState.data[8] += 70;
				GlobalScript.inst.gameState.data[9] -= 10;
				GlobalScript.inst.gameState.data[26] += 40;
				GlobalScript.inst.gameState.data[1] -= 150;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.power -= 10;
				GlobalScript.inst.gameState.allcountries[33].Torg = true;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic195 in politics)
				{
					if (politic195.traits[0] == 0)
					{
						Politic politic = politic195;
						politic.loyality -= 100;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "На организованной нами встрече представителей КНР, Лаоса, Бирмы и Таиланда была принята программа по совместной борьбе с организованной преступностью в Юго-восточной Азии. Сотрудники китайского МГБ совместно с правоохранительными органами этих стран провели множество расследований, выявив многочисленные связи наркоторговцев с государственными служащими и раскрыв некоторые пути сбыта. Это также позволило более точно установить местонахождение центров синдикатов и провести несколько успешных рейдов с помощью армий союзных стран и НОАК. Разумеется, до полного разгрома Золотого треугольника ещё далеко, но эти меры серьёзно осложнили жизнь наркоторговцам и облегчили её нашим партнёрам, за что они нас сердечно поблагодарили, а Бирма, испытавшая наибольшее облегчение из-за спада шанского сепаратизма, окончательно обозначила прокитайский вектор своей внешней политики.";
				GlobalScript.inst.gameState.data[9] -= 20;
				GlobalScript.inst.gameState.data[22] -= 20;
				GlobalScript.inst.gameState.data[26] -= 20;
				GlobalScript.inst.gameState.allcountries[33].proprc = true;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 435)
		{
			text2 = GlobalScript.inst.new_events_text[1647];
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = GlobalScript.inst.new_events_text[1653];
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[6];
				leader.support--;
				leader = GlobalScript.inst.gameState.empires[1].leaders[4];
				leader.support--;
				leader = GlobalScript.inst.gameState.empires[1].leaders[1];
				leader.support--;
				leader = GlobalScript.inst.gameState.empires[1].leaders[3];
				leader.support -= 2;
				GlobalScript.inst.gameState.data[8] -= 50;
				GlobalScript.inst.gameState.data[9] -= 100;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = GlobalScript.inst.new_events_text[1654];
				Leader leader = GlobalScript.inst.gameState.empires[1].leaders[3];
				leader.support++;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations += 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 5;
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = GlobalScript.inst.new_events_text[1655];
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 436)
		{
			text2 = GlobalScript.inst.new_events_text[1656];
			Leader leader = GlobalScript.inst.gameState.empires[1].leaders[2];
			leader.support++;
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = GlobalScript.inst.new_events_text[1661];
				GlobalScript.inst.gameState.data[8] -= 5;
				GlobalScript.inst.gameState.data[3] += 25;
				GlobalScript.inst.gameState.data[4] -= 25;
				GlobalScript.inst.gameState.data[5] += 25;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection += 5;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic196 in politics)
				{
					if (politic196.traits[0] == 0)
					{
						Politic politic = politic196;
						politic.loyality += 100;
						politic = politic196;
						politic.power += 25;
					}
					else
					{
						Politic politic = politic196;
						politic.loyality += 50;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = GlobalScript.inst.new_events_text[1662];
				GlobalScript.inst.gameState.data[1] += 50;
				Empire empire = GlobalScript.inst.gameState.empires[1];
				empire.relations -= 50;
				GameState gameState = GlobalScript.inst.gameState;
				gameState.SOV_PRC_PartiesConnection -= 5;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic197 in politics)
				{
					if (politic197.traits[0] == 0)
					{
						Politic politic = politic197;
						politic.loyality += 150;
					}
					else
					{
						Politic politic = politic197;
						politic.loyality -= 50;
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = GlobalScript.inst.new_events_text[1663];
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 116)
		{
			text2 = "Два Китая";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "Всё идёт как и шло.";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "Сегодня Наш Лидер во главе китайской делегации посетил Тайбэй с историческим визитом, в ходе которого на закрытых переговорах было принято решение о формировании комиссии по выработке принципов постепенной реинтеграции Тайваня и материкового Китая. Разумеется, иностранные собственники сохранят все свои права, а провинция Тайвань получит широкую экономическую и политическую автономию на долгий срок. Всё, что связано с  американскими военными будет определяться уже заключёнными договорами, по истечении срока которых вопрос об их пребывании будет решён уже объединённым правительством. И хотя пока всё это только на бумаге и нуждается в масштабной проработке с учётом обоюдных интересов, а сроки возвращения Тайваня в лоно Китая не определены, наше население с энтузиазмом восприняло эту новость, а пограничный контроль был значительно ослаблен. В результате всего этого либеральным идеям стало значительно проще проникать к нам с Тайваня, да и американцы опасаются за своё влияние на острове, однако наш народ очень доволен.";
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations -= 70;
				GlobalScript.inst.gameState.data[4] += 80;
				GlobalScript.inst.gameState.data[3] += 120;
				GlobalScript.inst.gameState.allcountries[38].proprc = true;
				GlobalScript.inst.gameState.allcountries[38].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[38].SubGosstroy = 5;
				GlobalScript.inst.gameState.data[64] = 2;
				GlobalScript.inst.gameState.allcountries[1].ILoveSuckCocks();
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "Сегодня Наш Лидер во главе китайской делегации посетил Тайбэй с историческим визитом, в ходе которого на переговорах стороны приняли решение взаимно признать друг друга. Отныне КНР и Республика Тайвань (в которую по условиям соглашения была переименована Китайская Республика) будут существовать как два независимых государства. Это также положило конец многолетним спорам о территориях и законном правительстве, что вывело наши отношения на новый уровень. США приветствовали наш шаг и в качестве поддержки нашей политики выделили нам значительную финансовую помощь. Впрочем, многие остались недовольны тем, что два Китая так и остались разделены, по всей видимости, навсегда.";
				GlobalScript.inst.gameState.data[8] += 70;
				Empire empire = GlobalScript.inst.gameState.empires[0];
				empire.relations += 100;
				GlobalScript.inst.gameState.data[3] -= 80;
				GlobalScript.inst.gameState.data[4] += 50;
				GlobalScript.inst.gameState.data[1] -= 100;
				GlobalScript.inst.gameState.allcountries[38].Torg = true;
				GlobalScript.inst.gameState.allcountries[38].Gosstroy = 3;
				GlobalScript.inst.gameState.allcountries[38].SubGosstroy = 5;
				GlobalScript.inst.gameState.data[64] = 1;
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 5)
		{
			text2 = "Ответ Живкова";
			if (GlobalScript.inst.gameState.number_otvet == 1)
			{
				text = "";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 2)
			{
				text = "";
			}
			else if (GlobalScript.inst.gameState.number_otvet == 3)
			{
				text = "";
			}
		}
		else
		{
			text2 = "Не готово";
			text = "Не готов ответ";
		}
		if (stamps[global1.this_stump] != null)
		{
			this_stamp.sprite = stamps[global1.this_stump];
		}
		else
		{
			global1.this_stump = UnityEngine.Random.Range(0, 37);
			if (stamps[global1.this_stump] != null)
			{
				this_stamp.sprite = stamps[global1.this_stump];
			}
		}
		Pereraschyot();
		Name.text = Utils.Text(text2, 41);
		Zaglav.text = Utils.Text(text, 81);
	}

	private void Pereraschyot()
	{
		if (GlobalScript.inst.gameState.iron_and_blood)
		{
			if (GlobalScript.inst.gameState.data[111] >= 7)
			{
				achieves.GetComponent<achievements>().Set(25);
			}
			if (GlobalScript.inst.gameState.data[112] >= 2)
			{
				achieves.GetComponent<achievements>().Set(27);
			}
		}
		float num = 0f;
		for (int i = 0; i < GlobalScript.inst.gameState.party_ideology.Length; i++)
		{
			num += (float)GlobalScript.inst.gameState.party_ideology[i];
		}
		for (int j = 0; j < GlobalScript.inst.gameState.party_ideology.Length; j++)
		{
			GlobalScript.inst.gameState.party_ideology[j] += (int)(num / (num / 100f) * party_change[j]);
		}
		int[] array = new int[GlobalScript.inst.gameState.party_ideology.Length];
		if (GlobalScript.inst.gameState.data[15] <= 7)
		{
			for (int k = 0; k < GlobalScript.inst.gameState.party_number.Length; k++)
			{
				if (GlobalScript.inst.gameState.party_ideology[k] > 0 && !GlobalScript.inst.gameState.is_party_enabled[k])
				{
					if (k + 1 < GlobalScript.inst.gameState.is_party_enabled.Length)
					{
						for (int l = k + 1; l < GlobalScript.inst.gameState.is_party_enabled.Length; l++)
						{
							if (GlobalScript.inst.gameState.is_party_enabled[l])
							{
								array[l] = GlobalScript.inst.gameState.party_ideology[k];
								break;
							}
						}
						continue;
					}
					for (int num2 = k - 1; num2 > 0; num2--)
					{
						if (GlobalScript.inst.gameState.is_party_enabled[num2])
						{
							GlobalScript.inst.gameState.party_number[num2] += GlobalScript.inst.gameState.party_ideology[k];
							break;
						}
					}
				}
				else if (GlobalScript.inst.gameState.party_ideology[k] > 0 && GlobalScript.inst.gameState.is_party_enabled[k])
				{
					GlobalScript.inst.gameState.party_number[k] = GlobalScript.inst.gameState.party_ideology[k] + array[k];
				}
				else if (GlobalScript.inst.gameState.party_ideology[k] < 0)
				{
					GlobalScript.inst.gameState.party_ideology[k] = 0;
				}
			}
		}
		if (GlobalScript.inst.gameState.data[15] <= 7)
		{
			if (GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 0;
			}
			else if (GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 1;
			}
			else if (GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 2;
			}
			else if (GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 3;
			}
			else if (GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[4])
			{
				GlobalScript.inst.gameState.data[56] = 4;
			}
			return;
		}
		int num3 = GlobalScript.inst.gameState.party_number[1];
		for (int m = 0; m < GlobalScript.inst.gameState.is_party_ally.Length; m++)
		{
			if (GlobalScript.inst.gameState.is_party_ally[m] && GlobalScript.inst.gameState.is_party_enabled[m] && m != 1)
			{
				num3 += GlobalScript.inst.gameState.party_number[m];
			}
		}
		if (num3 >= GlobalScript.inst.gameState.party_number[0] && num3 >= GlobalScript.inst.gameState.party_number[2] && num3 >= GlobalScript.inst.gameState.party_number[3] && num3 >= GlobalScript.inst.gameState.party_number[4])
		{
			GlobalScript.inst.gameState.data[56] = 1;
		}
		else if (!GlobalScript.inst.gameState.is_party_ally[0] && GlobalScript.inst.gameState.is_party_enabled[0] && num3 <= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[4])
		{
			GlobalScript.inst.gameState.data[56] = 0;
		}
		else if (!GlobalScript.inst.gameState.is_party_ally[2] && GlobalScript.inst.gameState.is_party_enabled[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[0] && num3 <= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[4])
		{
			GlobalScript.inst.gameState.data[56] = 2;
		}
		else if (!GlobalScript.inst.gameState.is_party_ally[3] && GlobalScript.inst.gameState.is_party_enabled[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[2] && num3 <= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[4])
		{
			GlobalScript.inst.gameState.data[56] = 3;
		}
		else if (!GlobalScript.inst.gameState.is_party_ally[4] && GlobalScript.inst.gameState.is_party_enabled[4] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[3] && num3 <= GlobalScript.inst.gameState.party_number[4])
		{
			GlobalScript.inst.gameState.data[56] = 4;
		}
		int num4 = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4];
		if (num3 * 100 / num4 > 66)
		{
			GlobalScript.inst.gameState.is_konst_max = true;
		}
		else
		{
			GlobalScript.inst.gameState.is_konst_max = false;
		}
	}

	private string Text(string text, float col)
	{
		int num = 0;
		string text2 = "";
		text = text.Replace('\n', '|');
		text = text.Replace("<color=green>", "♔");
		text = text.Replace("<color=red>", "♕");
		text = text.Replace("<color=yellow>", "♖");
		text = text.Replace("<color=brown>", "♗");
		text = text.Replace("<color=fuchsia>", "♘");
		text = text.Replace("<color=lime>", "♙");
		text = text.Replace("<color=cyan>", "♚");
		text = text.Replace("<color=orange>", "♛");
		text = text.Replace("</color>", "♜");
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == char.Parse("|"))
			{
				num = 0;
				text2 += "\n";
			}
			else if ((float)num >= col)
			{
				if (text[i] == char.Parse(" "))
				{
					num = 0;
					text2 += "\n";
					continue;
				}
				text2 += text[i];
				for (int num2 = i; num2 >= 0; num2--)
				{
					if (text2[num2] == char.Parse(" "))
					{
						text2 = text2.Substring(0, num2) + "\n" + text2.Substring(num2 + 1, text2.Length - 1 - (num2 + 1) + 1);
						num = text2.Length - 1 - (num2 + 1) + 1;
						break;
					}
				}
			}
			else
			{
				text2 += text[i];
				num++;
			}
		}
		text2 = text2.Replace("♔", "<color=green>");
		text2 = text2.Replace("♕", "<color=red>");
		text2 = text2.Replace("♖", "<color=yellow>");
		text2 = text2.Replace("♗", "<color=brown>");
		text2 = text2.Replace("♘", "<color=fuchsia>");
		text2 = text2.Replace("♙", "<color=lime>");
		text2 = text2.Replace("♚", "<color=cyan>");
		text2 = text2.Replace("♛", "<color=orange>");
		return text2.Replace("♜", "</color>");
	}
}
