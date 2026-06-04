using System;
using System.Linq;
using EventsForDLC;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doneventscript : MonoBehaviour
{
	private GlobalScript global1;

	public int this_otvet;

	public bool nazad;

	public bool first;

	public Sprite navel;

	public Sprite nenavel;

	public Sprite[] stamps = new Sprite[1];

	public TextMesh Name;

	public TextMesh Zaglav;

	public TextMesh PreRes;

	public TextMesh[] otveti = new TextMesh[6];

	public SpriteRenderer this_stamp;

	public GameObject Galkasum;

	public GameObject Nazad;

	public GameObject Vpered;

	public GameObject thisObject;

	public GameObject GalkaCoop;

	public GameObject[] galka_stuk = new GameObject[6];

	public GameObject[] CascadPlayerButtons = new GameObject[6];

	public int kolvo_variant;

	public int summa_3_2;

	private Type MyScriptType = Type.GetType("Event" + GlobalScript.inst.gameState.number_event + ",Assembly-CSharp");

	public GameObject numPlayersAlert;

	private void PlayersCoopButtons()
	{
		if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			for (int i = 0; i < CascadPlayerButtons.Length; i++)
			{
				if (galka_stuk[i] != null && !galka_stuk[i].activeSelf && CascadPlayerButtons[i] != null)
				{
					UnityEngine.Object.Destroy(CascadPlayerButtons[i]);
				}
				else if (galka_stuk[i] != null)
				{
					UnityEngine.Object.Destroy(galka_stuk[i]);
				}
			}
			RepaintPreRes();
			return;
		}
		for (int j = 0; j < CascadPlayerButtons.Length; j++)
		{
			if (CascadPlayerButtons[j] != null)
			{
				UnityEngine.Object.Destroy(CascadPlayerButtons[j]);
			}
		}
	}

	public void RepaintPreRes()
	{
		int coopRes = GetCoopRes();
		if (coopRes >= 0)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				PreRes.text = $"Leading variant:\n№{coopRes + 1}";
			}
			else
			{
				PreRes.text = $"Лидирует вариант:\n№{coopRes + 1}";
			}
		}
		else if (PlayerPrefs.GetInt("language") == 0)
		{
			PreRes.text = "Everyone\nshould vote!";
		}
		else
		{
			PreRes.text = "Все должны\nпроголосовать!";
		}
	}

	private int GetCoopRes()
	{
		float[] array = new float[otveti.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 0f;
		}
		if (GlobalScript.inst.gameState.numOfPlayers < 5)
		{
			if (GlobalScript.inst.gameState.eventVariantsPlayerFor.Take(GlobalScript.inst.gameState.numOfPlayers).Contains(-1))
			{
				return -1;
			}
			for (int j = 0; j < GlobalScript.inst.gameState.factionsPlayerMaster.Length; j++)
			{
				int num = GlobalScript.inst.gameState.factionsPlayerMaster[j];
				array[GlobalScript.inst.gameState.eventVariantsPlayerFor[num]] += GlobalScript.inst.gameState.party_number[j] * 100;
			}
		}
		else
		{
			if (GlobalScript.inst.gameState.eventVariantsPlayerFor.Any((int b) => b < 0))
			{
				return -1;
			}
			for (int num2 = 0; num2 < GlobalScript.inst.gameState.eventVariantsPlayerFor.Length; num2++)
			{
				array[GlobalScript.inst.gameState.eventVariantsPlayerFor[num2]] += GlobalScript.inst.gameState.party_number[num2] * 100;
			}
		}
		return array.ToList().IndexOf(array.Max());
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (GlobalScript.inst.gameState.number_event != 60000)
		{
			GlobalScript.inst.gameState.event_done[GlobalScript.inst.gameState.number_event] = true;
		}
		if (nazad)
		{
			return;
		}
		if (GlobalScript.inst.gameState.number_event >= 120 && thisObject.GetComponent<EventsSecond>() == null)
		{
			thisObject.AddComponent(MyScriptType);
		}
		if (GlobalScript.inst.gameState.data[15] > 7)
		{
			int num = GlobalScript.inst.gameState.party_number[1];
			int num2 = 0;
			for (int i = 0; i < GlobalScript.inst.gameState.is_party_ally.Length; i++)
			{
				if (GlobalScript.inst.gameState.is_party_ally[i] && GlobalScript.inst.gameState.is_party_enabled[i] && i != 1)
				{
					num += GlobalScript.inst.gameState.party_number[i];
				}
			}
			num2 = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4];
			summa_3_2 = num * 100 / num2;
		}
		Azkaban();
		global1.this_stump = UnityEngine.Random.Range(0, 37);
		if (stamps[global1.this_stump] != null)
		{
			this_stamp.sprite = stamps[global1.this_stump];
		}
		if (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] < 1)
		{
			numPlayersAlert.SetActive(value: false);
		}
		else if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				numPlayersAlert.GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.gameState.GetCompassText();
			}
			else
			{
				numPlayersAlert.GetComponent<OkoshkoScript>().text = GlobalScript.inst.gameState.GetCompassText();
			}
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = navel;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = nenavel;
	}

	private void OnMouseDown()
	{
		if (!nazad && !first)
		{
			Name.text = "";
			Zaglav.text = "";
			first = true;
			Nazad.SetActive(value: true);
			Galkasum.SetActive(value: true);
			GalkaCoop.SetActive(value: true);
			string[] fake_text = new string[6];
			if (GlobalScript.inst.gameState.number_event >= 120 && GlobalScript.inst.gameState.number_event != 435 && GlobalScript.inst.gameState.number_event != 436)
			{
				thisObject.GetComponent<EventsSecond>().VariantsOfEvents(ref kolvo_variant, ref fake_text, ref galka_stuk);
			}
			else if (PlayerPrefs.GetInt("language") == 0)
			{
				if (GlobalScript.inst.gameState.number_event == 1)
				{
					kolvo_variant = 3;
					fake_text[0] = "不要干预，等待结果。";
					if (GlobalScript.inst.gameState.data[1] > 500)
					{
						fake_text[1] = "动员公务员去投票。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "党坚决阻止这种公然干预。";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[2] = "伪造选举结果。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "情报部门力量不足。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 3)
				{
					kolvo_variant = 3;
					fake_text[0] = "按毛主席遗愿火化，并建纪念。";
					fake_text[1] = "在天安门广场为毛主席建陵。";
					fake_text[2] = "由丧葬委员会定夺。";
				}
				else if (GlobalScript.inst.gameState.number_event == 4)
				{
					kolvo_variant = 4;
					fake_text[0] = "在大会上展开论战。";
					if (GlobalScript.inst.gameState.data[9] >= 100)
					{
						fake_text[1] = "逮捕阴谋分子！";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "特务部门不会支持我们。";
					}
					if (GlobalScript.inst.gameState.data[22] >= 100)
					{
						fake_text[2] = "召集忠诚军官！";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "军队不会支持我们。";
					}
					if (GlobalScript.inst.gameState.data[3] >= 700)
					{
						fake_text[3] = "向人民呼吁！";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "People do not need another 文化大革命";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 5)
				{
					int num = 99;
					if (GlobalScript.inst.gameState.citizens != null)
					{
						Debug.Log("Поиск граждан");
						for (int i = 0; i < GlobalScript.inst.gameState.citizens.Length; i++)
						{
							Persona persona = GlobalScript.inst.gameState.citizens[i];
							if (persona != null && persona.Wealth >= 9 && (persona.Intrigue >= 7 || persona.Charisma > 7) && persona.status >= Job.LocalPartyBranchChief && !persona.isPolitic && CitizenManager.Instance != null)
							{
								num = i;
							}
						}
					}
					kolvo_variant = 5;
					fake_text[0] = "敢于发声，安定人心。";
					if (num != 99 && GlobalScript.inst.gameState.data[38] == 100 && !GlobalScript.inst.gameState.citizens[num].isLead)
					{
						Debug.Log($"Гражданин {num} может быть возвышен");
						fake_text[1] = "为人民服务的人来领导国家。";
						GlobalScript.inst.gameState.citizens[num].isLead = true;
					}
					else if (GlobalScript.inst.gameState.data[15] != 9 || GlobalScript.inst.gameState.data[17] != 19)
					{
						fake_text[1] = "同意实行民主化。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "再也没有进一步民主化的空间。";
					}
					if (GlobalScript.inst.gameState.data[22] >= 100)
					{
						fake_text[2] = "驱散抗议者。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "军队不会支持我们。";
					}
					if (GlobalScript.inst.gameState.data[3] > 500)
					{
						fake_text[3] = "号召忠于我们的一部分人民来支持。";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "People do not need another 文化大革命";
					}
					if (GlobalScript.inst.gameState.data[9] >= 150)
					{
						fake_text[4] = "由情报部门从内部瓦解抗议。";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "情报机构应付不了。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 6)
				{
					kolvo_variant = 4;
					fake_text[0] = "紧急拨款用于社会项目。";
					if ((GlobalScript.inst.gameState.empires[0].relations >= 500 && !GlobalScript.inst.gameState.allcountries[1].isSEV) || (GlobalScript.inst.gameState.empires[1].relations >= 500 && !GlobalScript.inst.gameState.allcountries[51].Torg && !GlobalScript.inst.gameState.allcountries[1].econ))
					{
						fake_text[1] = "请求外国人道主义援助。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们不能求助。";
					}
					if (GlobalScript.inst.gameState.data[16] >= 13)
					{
						fake_text[2] = "以恩威并施的手段动员工商界解决社会问题。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们动员不了工商界——我们也没有。";
					}
					if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text[3] = "以党和官员的名义搞慈善。";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "党不愿分担。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 7)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[51] != 30 || GlobalScript.inst.gameState.data[6] <= 950)
					{
						fake_text[0] = "由我们出钱搞缓和。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们决不投降！";
					}
					if (GlobalScript.inst.gameState.influencePRC >= 50)
					{
						fake_text[1] = "拿出部分外交立场作为善意表示。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们影响力太弱，限制不了。";
					}
					if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "向帝国主义发射核武！";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "没有人想要核战争。";
					}
					fake_text[3] = "根本不管。";
					if (GlobalScript.inst.dlc[6])
					{
						kolvo_variant = 5;
						if (GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.data[168] >= 50)
						{
							fake_text[4] = "贿赂美国参议员，让此事噤声。";
						}
						else if (!GlobalScript.inst.gameState.modifies[17].active)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "必须实施美国制裁。";
						}
						else
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "需要在瑞士银行存入5.0资金";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 8)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[51] != 30 || GlobalScript.inst.gameState.data[6] <= 950)
					{
						fake_text[0] = "由我们出钱搞缓和。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们决不投降！";
					}
					if (GlobalScript.inst.gameState.influencePRC >= 50)
					{
						fake_text[1] = "拿出部分外交立场作为善意表示。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们影响力太弱，限制不了。";
					}
					if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "向修正主义者发射核武！";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "没有人想要核战争。";
					}
					fake_text[3] = "根本不管。";
					if (GlobalScript.inst.dlc[6])
					{
						kolvo_variant = 5;
						if (GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.data[168] >= 50)
						{
							fake_text[4] = "贿赂美国参议员，让此事噤声。";
						}
						else if (!GlobalScript.inst.gameState.modifies[17].active)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "必须实施美国制裁。";
						}
						else
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "需要在瑞士银行存入5.0资金";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 9)
				{
					kolvo_variant = 3;
					fake_text[0] = "我们无能为力";
					if (GlobalScript.inst.gameState.data[18] < 23)
					{
						fake_text[1] = "给他们更多自治权";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们不能再给更多自治权";
					}
					if (GlobalScript.inst.gameState.data[56] != 4 || GlobalScript.inst.gameState.data[22] >= 100)
					{
						fake_text[2] = "派兵恢复秩序";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "光靠军队碾压不管用";
					}
					if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40 || GlobalScript.inst.gameState.data[36] >= 40 || GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[3] = "搞一场操纵的主权公投";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们既没有手段也没有力量去造假";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 10)
				{
					kolvo_variant = 3;
					fake_text[0] = "我们无能为力";
					if (GlobalScript.inst.gameState.data[18] < 23)
					{
						fake_text[1] = "给他们更多自治权";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们不能再给更多自治权";
					}
					if (GlobalScript.inst.gameState.data[56] != 4 || GlobalScript.inst.gameState.data[22] >= 100)
					{
						fake_text[2] = "派兵恢复秩序";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "光靠军队碾压不管用";
					}
					if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 20 || GlobalScript.inst.gameState.data[36] >= 20 || GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[3] = "搞一场操纵的主权公投";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们既没有手段也没有力量去造假";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 11)
				{
					kolvo_variant = 4;
					fake_text[0] = "紧急拨款用于发展";
					if (GlobalScript.inst.gameState.empires[0].relations >= 60 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
					{
						fake_text[1] = "吸引外资";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "投资者不会来我们这儿";
					}
					if (GlobalScript.inst.gameState.empires[1].relations >= 70 || GlobalScript.inst.gameState.relres)
					{
						fake_text[2] = "向苏联求援";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不需要修正主义者的施舍！";
					}
					if (GlobalScript.inst.gameState.data[13] >= 500)
					{
						fake_text[3] = "以牺牲农业为代价发展";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "农业方面的处境并不太好";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 12)
				{
					kolvo_variant = 4;
					fake_text[0] = "紧急拨款用于发展";
					if (GlobalScript.inst.gameState.empires[0].relations >= 60 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
					{
						fake_text[1] = "吸引外资";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "投资者不会来我们这儿";
					}
					if (GlobalScript.inst.gameState.empires[1].relations >= 70 || GlobalScript.inst.gameState.relres)
					{
						fake_text[2] = "向苏联求援";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不需要修正主义者的施舍！";
					}
					if (GlobalScript.inst.gameState.data[12] >= 500)
					{
						fake_text[3] = "以牺牲工业为代价发展";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "工业方面的处境并不太好";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 13)
				{
					kolvo_variant = 4;
					fake_text[0] = "紧急拨款用于发展";
					if (GlobalScript.inst.gameState.empires[0].relations >= 60 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
					{
						fake_text[1] = "吸引外资";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "投资者不会来我们这儿";
					}
					if (GlobalScript.inst.gameState.empires[1].relations >= 70 || GlobalScript.inst.gameState.relres)
					{
						fake_text[2] = "向苏联求援";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不需要修正主义者的施舍！";
					}
					if (GlobalScript.inst.gameState.data[12] >= 500 || GlobalScript.inst.gameState.data[13] >= 500)
					{
						fake_text[3] = "以牺牲农业为代价发展 and industry";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "农业和工业方面的处境并不太好";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 14)
				{
					kolvo_variant = 4;
					int num2 = 0;
					if (GlobalScript.inst.gameState.data[16] >= 13 && GlobalScript.inst.gameState.data[5] >= 500)
					{
						fake_text[0] = "提高税收，削减社会项目";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "";
						num2++;
					}
					if (GlobalScript.inst.gameState.data[16] >= 14)
					{
						fake_text[1] = "对奢侈品和超级富豪加税";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们没有寡头";
						num2++;
					}
					if (GlobalScript.inst.gameState.data[16] <= 14 && GlobalScript.inst.gameState.data[56] != 0 && (GlobalScript.inst.gameState.data[15] > 7 || GlobalScript.inst.gameState.data[56] != 1))
					{
						fake_text[3] = "对国有企业进行快速私有化";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们无法再进行进一步私有化";
						num2++;
					}
					if (GlobalScript.inst.gameState.empires[0].relations > 500 || (GlobalScript.inst.gameState.empires[1].relations > 500 && GlobalScript.inst.gameState.influencePRC >= 50) || num2 >= 3)
					{
						fake_text[2] = "举借外债";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "没人愿意给我们提供信贷";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 15)
				{
					kolvo_variant = 3;
					fake_text[0] = "不要干预";
					if (GlobalScript.inst.gameState.data[9] >= 30 && GlobalScript.inst.gameState.data[56] != 0)
					{
						fake_text[1] = "罢黜波尔布特，改由胡宁、侯远和凯·山潘三人执掌";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们无法罢黜波尔布特";
					}
					if (GlobalScript.inst.gameState.data[56] != 4)
					{
						fake_text[2] = "支援红色高棉";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不能帮助这位独裁者！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 16)
				{
					kolvo_variant = 3;
					fake_text[0] = "不要干预";
					if (GlobalScript.inst.gameState.data[9] >= 20 || GlobalScript.inst.gameState.allcountries[34].stab == 1)
					{
						fake_text[1] = "支持CPT，并与左派和民主派结成联盟";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们力量不足以支持CPT";
					}
					if (GlobalScript.inst.gameState.data[22] >= 20 && GlobalScript.inst.gameState.data[56] != 4)
					{
						fake_text[2] = "选举见鬼去吧！不如给CPT更多武器搞游击战。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不能再给CPT更多武器";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 17)
				{
					kolvo_variant = 3;
					fake_text[0] = "这不关我们的事";
					if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.data[22] >= 30 && GlobalScript.inst.gameState.data[41] == 100)
					{
						fake_text[1] = "派遣武装的CPT部队协助示威者，并挑起起义";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们力量不足以组织起义";
					}
					fake_text[2] = "谴责泰国的残暴行径";
				}
				else if (GlobalScript.inst.gameState.number_event == 18)
				{
					kolvo_variant = 1;
					if (GlobalScript.inst.gameState.data[82] < 8)
					{
						fake_text[0] = "和平万岁！";
					}
					else
					{
						fake_text[0] = "必读！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 19)
				{
					kolvo_variant = 4;
					fake_text[0] = "随它去，走着看";
					fake_text[1] = "严格执行毛主席的指示";
					fake_text[2] = "严格执行运动，同时在媒体上批判周恩来。";
					fake_text[3] = "温和地破坏这场运动";
				}
				else if (GlobalScript.inst.gameState.number_event == 20)
				{
					kolvo_variant = 3;
					fake_text[0] = "什么也不做。江青和邓小平各自对峙";
					fake_text[1] = "加入对邓小平的迫害";
					fake_text[2] = "为邓小平挺身而出";
				}
				else if (GlobalScript.inst.gameState.number_event == 21)
				{
					kolvo_variant = 3;
					fake_text[0] = "保持沉默，目标不明，别卷进交火";
					fake_text[1] = "严控出版与猜测，避免搅动群众";
					fake_text[2] = "把文章转向批判资本主义道路的改革";
				}
				else if (GlobalScript.inst.gameState.number_event == 22)
				{
					kolvo_variant = 3;
					fake_text[0] = "借助军队和警察驱散抗议";
					fake_text[2] = "号召所有人离开，并封控其余人群直至离散";
					if (GlobalScript.inst.gameState.data[88] >= 0)
					{
						fake_text[1] = "号召大家都走，把剩下的驱散";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "群众不愿走！";
					}
					if (GlobalScript.inst.gameState.data[88] >= 2)
					{
						fake_text[2] = "号召所有人离开，并封控其余人群直至离散";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "群众不愿走！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 23)
				{
					kolvo_variant = 4;
					fake_text[0] = "Allocate funds 来自预算 for restoration (-3.0 from budget)";
					if (GlobalScript.inst.gameState.empires[0].relations >= 600 || GlobalScript.inst.gameState.empires[1].relations >= 600)
					{
						fake_text[1] = "请求外国人道主义援助。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "外国人不会给我们帮助";
					}
					fake_text[2] = "拨款用于地震防护体系的恢复与发展（预算-5.0）";
					fake_text[3] = "让省级行政部门处理";
				}
				else if (GlobalScript.inst.gameState.number_event == 24)
				{
					kolvo_variant = 4;
					fake_text[0] = "We continue the work of Mao, phasing out the 文化大革命";
					if (GlobalScript.inst.gameState.data[84] == 3)
					{
						fake_text[1] = "The 文化大革命 without excesses and the fight against revisionism according to the precepts of Mao!";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "The 文化大革命 has already bothered everyone";
					}
					if (GlobalScript.inst.gameState.data[84] != 3)
					{
						fake_text[2] = "Phase out the 文化大革命, and we need to do something with the economy...";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "";
					}
					if (GlobalScript.inst.gameState.data[84] != 3)
					{
						fake_text[3] = "Let's phase out the 文化大革命 and start developing large-scale reforms with access to the world market";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 25)
				{
					kolvo_variant = 4;
					fake_text[0] = "逮捕四人";
					fake_text[1] = "逮捕王洪文和江青，并与其余激进派寻求妥协";
					fake_text[2] = "妥协并争取激进派的支持";
					fake_text[3] = "不要干预 with the disassembly of the party";
				}
				else if (GlobalScript.inst.gameState.number_event == 26)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 70)
					{
						fake_text[0] = "逮捕四人";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "你们已经没有力量了";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[1] = "只逮捕王洪文和江青";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "你们已经没有力量了";
					}
					fake_text[2] = "放弃斗争，转向权力的渐进交接";
				}
				else if (GlobalScript.inst.gameState.number_event == 27)
				{
					kolvo_variant = 3;
					fake_text[0] = "同意殖民地交接，但保持其广泛自治";
					fake_text[1] = "同意殖民地交接，但保持其有限自治";
					fake_text[2] = "要求殖民地全面并入中华人民共和国，同时保留外国人的财产权";
				}
				else if (GlobalScript.inst.gameState.number_event == 28)
				{
					kolvo_variant = 3;
					fake_text[0] = "不要干预, Suharto and so doomed";
					if (GlobalScript.inst.gameState.data[9] >= 30)
					{
						fake_text[1] = "支持温和的左派反对派";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们力量不够，支持不了左派";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[2] = "帮助共产党地下力量重组";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们将无法恢复共产主义运动";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 29)
				{
					kolvo_variant = 4;
					fake_text[0] = "要求有限的政治放宽";
					fake_text[1] = "要求广泛的政治与经济改革";
					if (GlobalScript.inst.gameState.data[16] >= 13)
					{
						fake_text[2] = "要求为中国公司开放经济特区";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们既不愿、也不能与帝国主义打交道";
					}
					fake_text[3] = "要求尽可能最大的民主化";
				}
				else if (GlobalScript.inst.gameState.number_event == 30)
				{
					kolvo_variant = 3;
					fake_text[0] = "提议在巴勒斯坦部分地区建立阿拉伯国家";
					fake_text[1] = "提议给予阿拉伯人自治，直至危机得到进一步解决";
					fake_text[2] = "提议建立阿拉伯人与犹太人的联合国家";
				}
				else if (GlobalScript.inst.gameState.number_event == 31)
				{
					kolvo_variant = 3;
					fake_text[0] = "不要干预 in the democratic process";
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[1] = "帮助金大中组建反对派联盟";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们没有力量支持他";
					}
					if (GlobalScript.inst.gameState.data[9] >= 60 && GlobalScript.inst.gameState.influencePRC >= 200 && GlobalScript.inst.gameState.data[83] != 2 && GlobalScript.inst.gameState.data[83] != 1)
					{
						fake_text[2] = "帮助金大中，并对朝鲜民主主义人民共和国施压，推动统一";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们没有足够的力量应对这类事件";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 32)
				{
					kolvo_variant = 2;
					fake_text[0] = "观望局势";
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[1] = "为我们的目的利用形势";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们力量不够";
					}
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "煽动反苏言论来帮助压制他们？当真？";
				}
				else if (GlobalScript.inst.gameState.number_event == 33)
				{
					kolvo_variant = 3;
					fake_text[0] = "禁止入内";
					if (GlobalScript.inst.gameState.data[9] >= 60)
					{
						fake_text[1] = "帮助布托";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们帮不了";
					}
					fake_text[2] = "不要干预，和新政府建立关系。";
				}
				else if (GlobalScript.inst.gameState.number_event == 34)
				{
					kolvo_variant = 4;
					fake_text[0] = "谨慎打击改革派";
					fake_text[1] = "只提拔忠诚的保守派";
					fake_text[2] = "打击改革派，为温和保守派清路";
					if (GlobalScript.inst.gameState.data[87] != 1 && GlobalScript.inst.gameState.data[87] != 2)
					{
						fake_text[3] = "我们需要与改革派建立强有力的联盟！";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "你不能和修正主义者谈判！";
					}
					fake_text[4] = "不要打破党内摇摆的平衡";
				}
				else if (GlobalScript.inst.gameState.number_event == 35)
				{
					kolvo_variant = 4;
					fake_text[0] = "什么都不做，给够让步";
					fake_text[1] = " 限制在小范围的公民自由化";
					fake_text[2] = "放松控制，对传统施压";
					if (GlobalScript.inst.gameState.data[56] != 0)
					{
						fake_text[3] = "放松控制，只到对宗教的监督为止";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们不能搞这种自由化！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 36)
				{
					kolvo_variant = 3;
					fake_text[0] = "不，不值得";
					fake_text[1] = "谴责复兴党领导层";
					if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.influencePRC >= 50)
					{
						fake_text[2] = "借助特务力量与政治压力促使各方对话";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们力量不够 and influence";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 37)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] <= 1 && GlobalScript.inst.gameState.allcountries[30].stab == 1) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "无论如何都要支持这些讲话，并煽动推翻萨达特";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "这对埃及事务的干涉太激进了！";
					}
					if (GlobalScript.inst.gameState.data[9] >= 20 && (GlobalScript.inst.gameState.data[56] <= 2 || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "帮助利比亚和叙利亚推翻萨达特";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们真需要这片北非吗？";
					}
					fake_text[2] = "埃及的事与我们无关";
				}
				else if (GlobalScript.inst.gameState.number_event == 38)
				{
					kolvo_variant = 3;
					int num3 = 0;
					if (GlobalScript.inst.gameState.data[87] != 4)
					{
						fake_text[1] = "恢复计划体制（预算-1.0）";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "党要改革，沿着你指引的路走！";
						num3++;
					}
					if (GlobalScript.inst.gameState.data[84] != 3 && GlobalScript.inst.gameState.data[87] != 2 && GlobalScript.inst.gameState.data[87] != 1 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "开始为进一步的大规模改革做准备";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "打倒修正主义！";
						num3++;
					}
					if ((GlobalScript.inst.gameState.data[87] != 2 && GlobalScript.inst.gameState.data[87] != 4) || num3 >= 2)
					{
						fake_text[0] = "别砸掉那些有效的东西";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "旧制度已经寿终正寝！";
						num3++;
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 39)
				{
					kolvo_variant = 3;
					fake_text[0] = "主席" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "亲自领导保守毛派委员会。我们的道路是正确的！";
					fake_text[1] = "我们将把工作交给邓小平和务实的改革派。\n他们会作出均衡评估。";
					if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "同志们，彭真和赵紫阳将揭露一切错误并把它们彻底揭穿！";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "彭真？赵紫阳？这些都是毛主席赶出去的自由派！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 40)
				{
					kolvo_variant = 5;
					if (GlobalScript.inst.gameState.data[56] <= 1)
					{
						fake_text[0] = "让他再坐一坐！";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们再也不能把他关在监狱里了！";
					}
					if (GlobalScript.inst.gameState.data[56] <= 2)
					{
						fake_text[1] = "释放出狱，条件是放弃出家誓愿。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "这对他压力太大了！";
					}
					if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.data[56] != 0 && GlobalScript.inst.gameState.data[56] != 4)
					{
						fake_text[2] = "Release and let go back to Lhasa, but under the supervision of the Ministry of State Security (4 代理网络).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "要么继续关着，要么放他自由。";
					}
					if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "释放良心犯，予以平反！";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "平反？！是毛主席亲自指控他的！";
					}
					if (GlobalScript.inst.gameState.data[9] >= 70 && GlobalScript.inst.gameState.data[56] != 4)
					{
						fake_text[4] = "以心脏病发作为名除掉他，并强迫选举诺布为新的班禅喇嘛。";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "班禅喇嘛应由僧人自己选出！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 41)
				{
					kolvo_variant = 3;
					fake_text[0] = "禁止入内";
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[1] = "支持反对派";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们力量不够";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.data[56] != 0)
					{
						fake_text[2] = "支持英迪拉·甘地";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "支持甘地？甚至把西藏领土都给她？";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 42)
				{
					kolvo_variant = 5;
					fake_text[0] = "不要干预";
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[1] = "支持左翼组织";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们帮不了";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "支持伊斯兰主义者";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "帮宗教狂热分子？没门！";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "支持执政政权";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们绝不支持亲美的沙阿！";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[4] = "支持民主派";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "支持民主派";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 43)
				{
					kolvo_variant = 2;
					fake_text[0] = "不要干预";
					if (GlobalScript.inst.gameState.data[9] >= 30 && (GlobalScript.inst.gameState.allcountries[23].Gosstroy != 0 || GlobalScript.inst.gameState.allcountries[23].EAF))
					{
						fake_text[1] = "不惜一切手段阻止入境进程";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们无能为力";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 44)
				{
					kolvo_variant = 3;
					fake_text[0] = "同意启动改革，并将权力移交给 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2];
					if (GlobalScript.inst.gameState.data[9] >= 150)
					{
						fake_text[1] = "拖延会议，以便在休会间隙由国家安全部力量逮捕改革派";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "对这种事，我们既没有力量，也没有效果";
					}
					if (GlobalScript.inst.gameState.data[87] != 1 && GlobalScript.inst.gameState.data[87] != 2)
					{
						fake_text[2] = "同意他们的要求，以换取保住权力";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "在你发言之后，他们不会配合";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 45)
				{
					kolvo_variant = 1;
					fake_text[0] = "向社会主义市场经济前进！";
				}
				else if (GlobalScript.inst.gameState.number_event == 46)
				{
					kolvo_variant = 4;
					fake_text[0] = "欧洲很远，亚洲更重要";
					if (GlobalScript.inst.gameState.data[9] >= 80)
					{
						fake_text[1] = "组织贝拉·比斯库及其人同我们的特工系统进行支持与协调";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们力量不够";
					}
					if (GlobalScript.inst.gameState.data[9] >= 30 && GlobalScript.inst.gameState.data[22] >= 10)
					{
						fake_text[2] = "协助组织亲华起义";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "匈牙利又要起义？！再想想！";
					}
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "我们帮不了, but with joy we will hide Biszku from the wrath of the revisionists";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "欧洲很远，亚洲更重要";
					}
					if (GlobalScript.inst.dlc[6])
					{
						kolvo_variant = 5;
						if (GlobalScript.inst.gameState.data[9] >= 80)
						{
							fake_text[4] = "在MSZMP队伍里散播混乱，指望在这浑水里摸到鱼。";
						}
						else
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "我们力量不够";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 47)
				{
					kolvo_variant = 3;
					fake_text[0] = "让中共的MSS和人事官来处理这些问题。";
					fake_text[1] = "加入与改革派的争论，并作出你自己的否认。";
					fake_text[2] = "我们的媒体会处理这类低级宣传。";
				}
				else if (GlobalScript.inst.gameState.number_event == 63)
				{
					kolvo_variant = 4;
					fake_text[0] = "不要干预 in Afghan affairs";
					if (GlobalScript.inst.gameState.data[9] >= 30)
					{
						fake_text[1] = "在DRA中支持那些忠于我们的反对派。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们没有那份力量。";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "建立关系，支持哈尔克。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "他们不会合作。";
					}
					if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "建立关系，支持帕尔查姆。";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "他们不会合作。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 48)
				{
					kolvo_variant = 3;
					fake_text[0] = "最好别卷进去。";
					fake_text[1] = "Start a secret rapprochement with the DRA (-2.0 来自预算)";
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[2] = "我们不信任他……最好暗中与苏联就他的更迭达成一致，\n也许新政府会给我们点什么。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "不得与苏联勾结！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 49)
				{
					kolvo_variant = 2;
					fake_text[0] = "这是苏联的事。";
					if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[9] >= 70)
					{
						fake_text[1] = "警告阿明，并给他提供援助。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "没人会让我们插手。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 50)
				{
					kolvo_variant = 4;
					fake_text[0] = "No one. 这不关我们的事";
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[1] = "协助DRA，以换取在与PDPA结成的联盟中纳入毛主义政党。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "苏联不会允许我们如此深地介入。";
					}
					fake_text[2] = "协助DRA。";
					fake_text[3] = "支援毛主义叛乱者。";
					fake_text[4] = "把枪支卖给武装反对派，美国人愿意付钱。";
				}
				else if (GlobalScript.inst.gameState.number_event == 51)
				{
					kolvo_variant = 3;
					fake_text[0] = "不予回应。";
					fake_text[1] = "谴责部队入境。";
					fake_text[2] = "支持部队入境。";
				}
				else if (GlobalScript.inst.gameState.number_event == 53)
				{
					kolvo_variant = 4;
					fake_text[0] = "就让它这样吧。";
					fake_text[1] = "推行家庭联产承包制。";
					if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "推行私人耕作。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们决不把农业交给私人投机商！";
					}
					if (GlobalScript.inst.gameState.data[89] == 0)
					{
						fake_text[3] = "组织集体农场。";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "集体农场——计划经济的遗迹。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 54)
				{
					kolvo_variant = 3;
					fake_text[0] = "把这个问题暂缓。";
					if (GlobalScript.inst.gameState.data[16] > 11)
					{
						fake_text[1] = "打开 SEZ";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "毛主席要被气得在坟墓里翻身！";
					}
					if (GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[16] > 11)
					{
						fake_text[2] = "开放经济特区，并对其余部分企业引入投资。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "毛主席要被气得在坟墓里翻身！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 55)
				{
					kolvo_variant = 3;
					fake_text[0] = "这与我们无关。";
					fake_text[1] = "Send help to Ne Win and establish friendly relations (-3.0 来自预算)";
					if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.allcountries[33].stab == 1)
					{
						fake_text[2] = "帮助共产党人组织党内政变。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们帮不了他们。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 56)
				{
					kolvo_variant = 3;
					fake_text[0] = "我们不会把局势弄得更糟";
					if (!GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.war == 0)
					{
						fake_text[1] = "准备打仗！让越南吃点苦头！";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "一切按计划进行";
					}
					if (!GlobalScript.inst.gameState.event_done[14] && !GlobalScript.inst.gameState.allcountries[11].isSEV)
					{
						fake_text[2] = "举行中越会议并进行谈判";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "他们不会和我们谈";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 57)
				{
					kolvo_variant = 2;
					fake_text[0] = "这与我们无关。";
					if (GlobalScript.inst.gameState.data[9] >= 60 && GlobalScript.inst.gameState.allcountries[44].stab == 1)
					{
						fake_text[1] = "向CPJ提供资金与秘密援助";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "CPJ不会听我们的";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 58)
				{
					kolvo_variant = 1;
					fake_text[0] = "革命结束了";
				}
				else if (GlobalScript.inst.gameState.number_event == 59)
				{
					if (GlobalScript.inst.dlc[3])
					{
						kolvo_variant = 5;
					}
					else
					{
						kolvo_variant = 4;
					}
					fake_text[0] = "无视提案";
					if (!GlobalScript.inst.gameState.allcountries[15].cw && !GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[1] = "建立经济联盟（从预算扣除-15.0）";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We are not ready (-15 来自预算)";
					}
					if (!GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10) && GlobalScript.inst.gameState.war <= 0 && GlobalScript.inst.gameState.relres && !GlobalScript.inst.gameState.allcountries[15].cw && GlobalScript.inst.gameState.data[56] <= 1 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[51].Torg)
					{
						fake_text[2] = "加入经互会";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "不许和修正主义谈判！";
					}
					if (GlobalScript.inst.gameState.war <= 0 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].isOVD && !GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.allcountries[1].Vyshi && !GlobalScript.inst.gameState.allcountries[15].cw)
					{
						fake_text[3] = "加入不结盟运动";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "他们不喜欢你";
					}
					if (GlobalScript.inst.dlc[3])
					{
						if (!GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12) && GlobalScript.inst.gameState.war <= 0 && GlobalScript.inst.gameState.allcountries[1].Gosstroy != 1 && !GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[51].Torg && GlobalScript.inst.gameState.data[52] > 34)
						{
							fake_text[4] = "加入东盟";
						}
						else if (GlobalScript.inst.gameState.relres)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "不应恢复同苏联的关系";
						}
						else if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 1)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "建国不搞社会主义";
						}
						else if (GlobalScript.inst.gameState.data[52] <= 34)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "党的路线要改革，或更自由化";
						}
						else
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "需要同美国建立友谊";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 60)
				{
					kolvo_variant = 2;
					if (GlobalScript.inst.gameState.data[22] >= 300 && GlobalScript.inst.gameState.data[9] >= 100 && !GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						fake_text[0] = "Create a military bloc (-5 来自预算, -30 army forces and -10 代理网络)";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We are not ready (-5 来自预算, -30 army forces and -10 代理网络)";
					}
					fake_text[1] = "什么都不做";
				}
				else if (GlobalScript.inst.gameState.number_event == 61)
				{
					kolvo_variant = 3;
					fake_text[0] = "Restore \"March of the Volunteers\" unchanged (-1 来自预算)";
					if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[1] = "Approve \"The East Is Red\"";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "No recurrence of the 文化大革命!";
					}
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Restore \"March of the Volunteers\", but with a new text (-1 来自预算)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "没必要！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 62)
				{
					kolvo_variant = 5;
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "这是个公平的举措。我们就要这么干！（从预算扣除-3）";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "不许让步！";
					}
					fake_text[1] = "给少数人这么大的荣誉，过分吗？拒绝。";
					if (GlobalScript.inst.gameState.data[56] != 1)
					{
						fake_text[2] = "领土可以归还，但同化不会停止。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "这不符合中共的国家政策！";
					}
					if (GlobalScript.inst.gameState.data[56] != 0 && GlobalScript.inst.gameState.data[56] != 3)
					{
						fake_text[3] = "It makes sense to stop the assimilation, but we will not return the territories (-1 来自预算)";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "这不符合中共的国家政策！";
					}
					if (GlobalScript.inst.gameState.data[50] != 24 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[18] < 23)
					{
						fake_text[4] = "The time has come to seriously address the national issue in small ARs. Stop all the excesses! (-6 来自预算)";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "中国没有民族问题！在五十年代就彻底解决了。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 52)
				{
					kolvo_variant = 4;
					fake_text[0] = "让巴基斯坦自己去处理";
					fake_text[1] = "向巴基斯坦提供援助，巡逻边境并抓捕伊斯兰主义者";
					if (GlobalScript.inst.gameState.ingamewars[5].ussr_place != 1 && !GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[2] = "与美国谈判";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "不许援助反动派！";
					}
					if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 1)
					{
						fake_text[3] = "Why do we need all this? We better organize bases for Afghan Maoist insurgents in Pakistan (-5 来自预算)";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们不能援助DRA的毛主义叛乱者";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 64)
				{
					kolvo_variant = 2;
					fake_text[0] = "不值得我们出力。";
					if (GlobalScript.inst.gameState.data[9] >= 50 && (!GlobalScript.inst.gameState.allcountries[30].prosov || GlobalScript.inst.gameState.relres))
					{
						fake_text[1] = "Assist in the creation of an UAR (-7 来自预算, -5 代理网络)";
					}
					else if (GlobalScript.inst.gameState.data[9] < 50)
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Need 5 代理网络...";
					}
					else if (GlobalScript.inst.gameState.allcountries[30].prosov && !GlobalScript.inst.gameState.relres)
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "同苏联的关系尚未恢复……";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "他们不会同意的……";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 65)
				{
					kolvo_variant = 5;
					int num4 = 0;
					if ((GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))) || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[0] = "Sport is out of politics! We will take part in the Moscow Olympics and send the best athletes! (-4 来自预算)";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						num4++;
						fake_text[0] = "我们不能无视西方的意见。";
					}
					if ((GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[56] != 0))
					{
						fake_text[1] = "我们不宣布抵制，但两届都不理会……";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						num4++;
						fake_text[1] = "两届都不能不理！";
					}
					if (GlobalScript.inst.gameState.data[89] > 0 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "We declare a boycott to the Soviet Games and send the team to the USA (-3 来自预算).";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						num4++;
						fake_text[3] = "去美国？！你们是认真的吗……";
					}
					if (GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[4] = "We revive GANEFO and send invitations to developing countries (-20 来自预算).";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						num4++;
						fake_text[4] = "毛式实验够了！";
					}
					if ((((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[56] != 0) || num4 >= 4)
					{
						fake_text[2] = "Let's declare a boycott, but let our athletes go to Moscow under the Olympic flag (-4 来自预算).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "这不是我们的政策！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 66)
				{
					kolvo_variant = 4;
					fake_text[0] = "表示慰问，仅此而已。";
					if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0) || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[1] = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "亲自率领政府代表团飞往贝尔格莱德。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "不能亲自飞赴修正主义者铁托的葬礼！";
					}
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "派出由国务院秘书长纪鹏飞率领的代表团。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "不派代表团去贝尔格莱德！";
					}
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "铁托死了？那就算了，谁在乎？";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "他死了，我们不能不作反应！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 67)
				{
					kolvo_variant = 5;
					fake_text[0] = "波兰的事与中国无关。你们自己做的事——自己去处理！";
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[1] = "Support the pro-Soviet military led by General Wojciech Witold Jaruzelski (-5 agents, -20 来自预算).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "同苏联的友好条约尚未签署……";
					}
					if (GlobalScript.inst.gameState.allcountries[20].proprc && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "We form a coalition with the Mijal's Communist Party of Poland, Siwak's \"concrete\", the \"PAX\"  group and the \"Grunwald\" society (-15 agents, -30 来自预算).";
					}
					else if (!GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "阿尔巴尼亚应当在我们的势力范围之内……";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "改革派和自由派不应当掌权……";
					}
					if (GlobalScript.inst.gameState.empires[1].relations >= 600 && GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						fake_text[3] = "Let us turn to the 华沙条约组织 countries with a proposal for military intervention (-5 agents, -5 army forces).";
					}
					else if (!GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We should be in the 华沙条约组织...";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "同苏联的关系应当高于60.0……";
					}
					if (GlobalScript.inst.gameState.empires[0].relations >= 600 && GlobalScript.inst.gameState.allcountries[51].Torg && !GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[4] = "Together with the United States support \"Solidarity\" (-10 来自预算, -20 agents)";
					}
					else if (!GlobalScript.inst.gameState.allcountries[51].Torg)
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "我们需要同美国签订友好条约……";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "同美国的关系应当高于60.0……";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 68)
				{
					kolvo_variant = 2;
					fake_text[0] = "让他们自己去处理。";
					if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[22] >= 80)
					{
						fake_text[1] = "Assist the rebels and provoke unrest (-8 army forces, -10 代理网络)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们资源不够。";
						fake_text[2] = "号召各方对话。";
						fake_text[3] = "支持全斗焕的行动。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 69)
				{
					kolvo_variant = 3;
					fake_text[0] = "什么都不做. Different views - a pledge of democracy.";
					int num5 = 0;
					int num6 = 0;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic in politics)
					{
						if (politic.traits[0] == 1 || politic.traits[0] == 2)
						{
							num5 += politic.power;
						}
						else if (politic.traits[0] == 0)
						{
							num6 += politic.power;
						}
					}
					if (GlobalScript.inst.gameState.data[1] >= 650 && num5 > num6)
					{
						fake_text[1] = "在中共全会上打击保守派，扶植积极改革派";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "中共不会让你们只会拼凑人手";
					}
					if (GlobalScript.inst.gameState.data[1] >= 600 && num5 > num6)
					{
						fake_text[2] = "在中共全会上打击保守派";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "中共不会让你们这么轻易就把他们清掉";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 70)
				{
					kolvo_variant = 2;
					int num7 = 0;
					int num8 = 0;
					Politic[] politics = GlobalScript.inst.gameState.politics;
					foreach (Politic politic2 in politics)
					{
						if (politic2.traits[0] == 1 || politic2.traits[0] == 2)
						{
							num7 += politic2.power;
						}
						else if (politic2.traits[0] == 0)
						{
							num8 += politic2.power;
						}
					}
					fake_text[0] = "什么都不做. Different views - a pledge of democracy.";
					if (GlobalScript.inst.gameState.data[1] >= 800 && num8 > num7)
					{
						fake_text[1] = "在中共全会上打击改革派和中间派";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "改革派不会这么轻易认输！";
					}
					if (GlobalScript.inst.gameState.data[1] >= 700 && GlobalScript.inst.gameState.data[90] != 0)
					{
						fake_text[2] = "争取中间派支持，在全会上打击改革派";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "中间派不会跟我们站在一起";
					}
					fake_text[3] = "逮捕改革派头目，发动对其支持者的运动——一切照毛主席的指示！";
				}
				else if (GlobalScript.inst.gameState.number_event == 71)
				{
					kolvo_variant = 3;
					fake_text[0] = "让他们继续党争就行，这对我们目前已足够";
					if (GlobalScript.inst.gameState.influencePRC >= 100 && GlobalScript.inst.gameState.allcountries[19].Torg)
					{
						fake_text[1] = "以停火为代价，让纳萨尔派进入地方政府";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "他们不会和我们谈";
					}
					if (!GlobalScript.inst.gameState.allcountries[19].Torg && GlobalScript.inst.gameState.war == 0 && !GlobalScript.inst.gameState.allcountries[15].cw)
					{
						fake_text[2] = "准备打仗。派兵！";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们现在不是为了拉关系就要开战！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 72)
				{
					kolvo_variant = 3;
					fake_text[0] = "祝你好运，心情愉快";
					if (GlobalScript.inst.gameState.data[91] == 1)
					{
						fake_text[1] = "Support the left wing (-6 agents, -10 来自预算)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "人民党不会听我们的";
					}
					if (GlobalScript.inst.gameState.data[91] == 1)
					{
						fake_text[2] = "Support the right wing (-6 agents, -10 来自预算)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "人民党不会听我们的";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 73)
				{
					kolvo_variant = 4;
					fake_text[0] = "战争是地狱";
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "战争。战争从不改变";
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "战争即和平";
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "要想和平，必须备战";
				}
				else if (GlobalScript.inst.gameState.number_event == 74)
				{
					kolvo_variant = 5;
					if (GlobalScript.inst.gameState.data[90] == 0)
					{
						fake_text[0] = "全体会议批准了这一选项。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "这不可能。";
					}
					if (GlobalScript.inst.gameState.data[90] == 1)
					{
						fake_text[1] = "全体会议批准了这一选项。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "这不可能。";
					}
					if (GlobalScript.inst.gameState.data[90] == 2)
					{
						fake_text[2] = "全体会议批准了这一选项。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "这不可能。";
					}
					fake_text[3] = "你这写的是什么？！立刻把稿子送去修改！";
					if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[4] = "The question of \"Decision\" is removed from the agenda at the request of the Chairman.";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "这件事太重要了，中共不可能把它从议程上拿掉。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 75)
				{
					kolvo_variant = 4;
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "We will condemn the airstrike and offer Hussein to expand cooperation (-8 来自预算).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "萨达姆·侯赛因——专制者、沙文主义者。我们不需要支持他！";
					}
					fake_text[1] = "谁管他？让萨达姆自己去处理他的问题……";
					if (GlobalScript.inst.gameState.data[12] >= 600 && GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "We will help Iraq to resume its nuclear program. Let imperialism tremble! (-15 来自预算, -10 agents).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "给伊拉克原子弹？！你们想发动第三次世界大战？";
					}
					if ((GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "我们将批准空袭，并谴责侯赛因的军国主义和沙文主义。";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们无法为犹太复国主义者所做的一切辩护！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 76)
				{
					kolvo_variant = 4;
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "我们将以外交方式支持科索沃分离主义者，仅此而已。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "这不关我们的事。";
					}
					if (((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						fake_text[1] = "Offer Albania its assistance in the separation of Kosovo from Yugoslavia (-5 agents -5 来自预算).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们为什么要帮助阿尔巴尼亚？";
					}
					fake_text[2] = "不要干预.";
					if (GlobalScript.inst.gameState.data[9] >= 100)
					{
						fake_text[3] = "We will assist the Kosovo separatists with special services and money (-10 agents -10 来自预算).";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们对南斯拉夫的事务不感兴趣。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 77)
				{
					kolvo_variant = 3;
					if (((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[9] >= 80)
					{
						fake_text[0] = "帮助谢胡组织政变（-8名特工）。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们资源不够。";
					}
					fake_text[1] = "这是他们自己的问题。";
					if (GlobalScript.inst.gameState.allcountries[20].proprc || (GlobalScript.inst.gameState.allcountries[20].econ && GlobalScript.inst.gameState.data[60] == 0))
					{
						fake_text[2] = "我们支持霍查。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "他背弃了我们，我们凭什么还支持霍查？";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 78)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.data[22] >= 80 && ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "煽动骚乱，并支持毛主义者（-10名特工，-8军队实力）。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "不值得我们费力。";
					}
					fake_text[1] = "与我们无关。";
					if (GlobalScript.inst.gameState.data[6] < 800 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "马科斯胜利后表示祝贺，并试图建立合作。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不需要同美国傀儡合作。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 79)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.empires[1].relations > 500 && GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[0] = "We will call on the socialist camp to help Romania jointly (-10 来自预算).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "社会主义阵营不会听我们的。";
					}
					fake_text[1] = "让他自己偿还债务，这不是我们的事。";
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Provide material assistance to Romania (-30 来自预算).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "罗马尼亚不值得我们投入。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 80)
				{
					kolvo_variant = 3;
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "Not to bring up the subject of \"cult of personality\" and to hold the Congress in peace.";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "是时候向党讲真话了！";
					}
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || GlobalScript.inst.gameState.data[15] > 7)
					{
						fake_text[1] = "Mention of \"individual errors\" Mao, under the pretext of combating which we begin a cautious departure from him.";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们不能批评毛！";
					}
					if ((GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "我们要借鉴赫鲁晓夫的经验——他做了，我们也要做！";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "你疯了吗，竟敢学赫鲁晓夫？！！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 81)
				{
					kolvo_variant = 5;
					if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0) || (GlobalScript.inst.gameState.data[56] == 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "We will provide Hungary with economic assistance without preconditions (-35 来自预算).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们不富到能资助卡达尔派。";
					}
					if (GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "利用匈牙利人民共和国的种种问题，抹黑市场改革。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "匈牙利的例子并不能证明改革失败。";
					}
					if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "We will offer Hungary economic aid, but in exchange for the rehabilitation of the Bisku Group (-15 来自预算, -8 Agents).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "这对我们几乎没好处。";
					}
					if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "我们将全力支持恢复“比斯库集团”的名誉，\n以换取接管匈牙利国家债务（-45金钱，\n-10名特工）。";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "这对我们来说太激进了！";
					}
					fake_text[4] = "置之不理。";
					if (GlobalScript.inst.dlc[6] && GlobalScript.inst.gameState.resultOfEvents[46] == 4)
					{
						kolvo_variant = 6;
						if (GlobalScript.inst.gameState.data[9] >= 80)
						{
							fake_text[5] = "通过外交渠道，与部分政治局成员达成协议：\n以偿还贷款为交换条件，换取选举波日盖为总书记（-45金钱）。";
						}
						else
						{
							galka_stuk[5].SetActive(value: false);
							fake_text[5] = "我们力量不够";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 82)
				{
					kolvo_variant = 1;
					fake_text[0] = "究竟谁会赢——阿根廷的军事政权，还是衰弱而遥远的英国？";
				}
				else if (GlobalScript.inst.gameState.number_event == 83)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "我们向苏共中央委员会泄露信息，并抹黑库拉科夫（-5名特工）。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "太危险了！";
					}
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[1] = "我们将在媒体上刊发关于库拉科夫的揭露材料（-2金钱）。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们不需要那种东西。";
					}
					fake_text[2] = "我们把这留到未来……";
				}
				else if (GlobalScript.inst.gameState.number_event == 84)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 80 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "车祸——专业人士的选择！（-8名特工）。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "太危险了！";
					}
					fake_text[1] = "我们与白俄罗斯党内成员取得联系，并通过他们向苏斯洛夫递送关于\n马舍罗夫的污点材料（-5金钱）。";
					fake_text[2] = "别管他。";
				}
				else if (GlobalScript.inst.gameState.number_event == 85)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "我们不遗余力地抹黑库纳耶夫，一旦他进入共和国就会引发骚乱（-10名特工）。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "太危险了！";
					}
					if (GlobalScript.inst.gameState.relres && ((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "我们将先发制人，警告他苏共中央即将发动的挑衅（-3名特工）。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们和勃列日涅夫关系不够好，没法让他知道。";
					}
					fake_text[2] = "我们不关心苏联的事务。";
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[3] = "我们的记者将以报道乌兹别克斯坦文艺为名，\n代表使馆调查拉希多夫的活动（-3名特工，\n-3资金）。";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "没人会给我们批准。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 86)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "我们将帮助克格勃头子“去往另一个世界”，\n把这次肾衰当作既成事实。\n乌克兰克格勃会处理这项任务（-10名特工，\n-5资金）。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "太危险了！";
					}
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[1] = "苏斯洛夫和谢尔比茨基召集中央委员会全会，\n并在我们的情报支持下打击安德罗波夫（-7资金）。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们对苏共的影响力不够。";
					}
					fake_text[2] = "太危险了！";
				}
				else if (GlobalScript.inst.gameState.number_event == 87)
				{
					kolvo_variant = 1;
					fake_text[0] = "中东又要打仗了……";
				}
				else if (GlobalScript.inst.gameState.number_event == 88)
				{
					kolvo_variant = 2;
					fake_text[0] = "We congratulate Mugabe on his victory and send him financial aid (-5 来自预算).";
					fake_text[1] = "以后我们可以和他做朋友。";
				}
				else if (GlobalScript.inst.gameState.number_event == 89)
				{
					kolvo_variant = 4;
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.empires[1].leaders[3].support > 0))
					{
						fake_text[0] = "支持安德罗波夫。";
					}
					else if (GlobalScript.inst.gameState.empires[1].leaders[3].support <= 0)
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们对苏共的影响力不够。";
					}
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.empires[1].leaders[1].support != 0))
					{
						fake_text[1] = "支持谢尔比茨基。";
					}
					else if (GlobalScript.inst.gameState.empires[1].leaders[1].support == 0)
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们对苏共的影响力不够。";
					}
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100))
					{
						fake_text[2] = "支持契尔年科。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们对苏共的影响力不够。";
					}
					fake_text[3] = "不要干预 and wait.";
				}
				else if (GlobalScript.inst.gameState.number_event == 90)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[9] >= 40 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "我们将与三合会谈判，争取对他们有利的条件（-4名特工）。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们不能与有组织犯罪谈判！";
					}
					if (GlobalScript.inst.gameState.data[9] >= 30 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "我们可以与黑帮集团进行战术性结盟。但这救不了他们免于清洗（-2名特工）。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "与黑暗势力绝不妥协！";
					}
					fake_text[2] = "我们管这些土匪干什么？";
					if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[16] <= 13 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "是时候对全国南方各省的有组织犯罪发动强有力的打击了！\n（-8名特工）";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "这些人是相当正派的商人，支持改革开放。\n我们没有权利怀疑他们。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 91)
				{
					kolvo_variant = 3;
					fake_text[0] = "谴责朝鲜的恐怖主义";
					fake_text[1] = "谴责韩国的挑衅";
					fake_text[2] = "保持沉默";
				}
				else if (GlobalScript.inst.gameState.number_event == 92)
				{
					kolvo_variant = 5;
					fake_text[0] = "投资工业升级（-1预算）";
					fake_text[1] = "继续加强农业机械化（-1预算）";
					fake_text[2] = "Invest in improving the quality of services (-1 来自预算)";
					fake_text[3] = "Focus the five-year plan on the development of scientific research (-1 来自预算)";
					fake_text[4] = "Direct forces on the uniform development of the economy (-1 来自预算)";
				}
				else if (GlobalScript.inst.gameState.number_event == 93)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[0] = "支持泛希腊社会主义运动（P";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们力量不够";
					}
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[1] = "支持新民主党";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们力量不够";
					}
					fake_text[2] = "禁止入内";
				}
				else if (GlobalScript.inst.gameState.number_event == 94)
				{
					kolvo_variant = 4;
					fake_text[0] = "这是反革命叛乱，叛徒们要为此付出代价！\n把我接到总参谋部……";
					fake_text[1] = "由人民武装警察封锁广场，并设法劝说抗议者散去。";
					fake_text[2] = "退下。让党来决定在这个困难时刻谁配领导国家。";
					fake_text[3] = "满足抗议者的要求。";
				}
				else if (GlobalScript.inst.gameState.number_event == 95)
				{
					kolvo_variant = 4;
					fake_text[0] = "我们摒弃马克思主义—毛泽东主义—邓小平主义，转而支持以中共为样板的欧洲共产主义。";
					fake_text[1] = "依照陈独秀的教诲，回到具有中国特色的社会民主。";
					fake_text[2] = "接受孙中山遗泽的左翼中国民族主义。";
					fake_text[3] = "我们为什么非得服从一些街头恶棍的要求？";
				}
				else if (GlobalScript.inst.gameState.number_event == 96)
				{
					kolvo_variant = 4;
					fake_text[0] = "我们正在为全国人大筹备尽可能限制其他党派的自由选举，\n但其他要求也必须满足。";
					fake_text[1] = "The elections are not so terrible as the bourgeois \"freedoms\". Do without it.";
					fake_text[2] = "选举并没有那么可怕，放任宗教不管才可怕。不要它。";
					fake_text[3] = "如果我们想让人民爱戴我们，就必须满足它的全部要求！";
				}
				else if (GlobalScript.inst.gameState.number_event == 97)
				{
					kolvo_variant = 2;
					fake_text[0] = "我们正在启动大规模推行自动化系统。";
					fake_text[1] = "欲速则不达，让它循序渐进，而不是一口气全上。";
				}
				else if (GlobalScript.inst.gameState.number_event == 98)
				{
					if (!GlobalScript.inst.dlc[3])
					{
						kolvo_variant = 3;
					}
					else
					{
						kolvo_variant = 4;
					}
					if (!GlobalScript.inst.gameState.allcountries[51].Torg)
					{
						fake_text[0] = "承认现政府，并派遣大使。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们不能支持篡权者！";
					}
					fake_text[1] = "无视军事政变。";
					if (GlobalScript.inst.gameState.influencePRC >= 100 && GlobalScript.inst.gameState.data[9] >= 30)
					{
						fake_text[2] = "提供人道主义援助。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们资源不够。 and influence";
					}
					if (GlobalScript.inst.gameState.data[9] >= 70 && GlobalScript.inst.gameState.modifies[41].active)
					{
						fake_text[3] = string.Format(GlobalScript.inst.new_events_text[1288], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
					}
					else if (!GlobalScript.inst.gameState.modifies[41].active)
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = string.Format(GlobalScript.inst.new_events_text[1289], 7f);
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = string.Format(GlobalScript.inst.new_events_text[567], 7f);
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 117)
				{
					kolvo_variant = 3;
					if (!GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[0] = "什么都不做. We were not invited";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们必须走。";
					}
					if (GlobalScript.inst.gameState.relres || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[1] = "派遣中国代表团出席葬礼。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "没人会让我们进去。";
					}
					if (GlobalScript.inst.gameState.relres || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[2] = "我们的领袖将亲自前往向尤里·弗拉基米罗维奇告别。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "你不能亲自去！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 114)
				{
					kolvo_variant = 1;
					fake_text[0] = "我们都在等结果……";
					if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[2] == 2)
					{
						kolvo_variant = 2;
						fake_text[0] = "Carter \ud83e\udecf";
						fake_text[1] = "Raegan \ud83d\udc18";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 99)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "我们将帮助正统派同修正主义作斗争。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们力量不够。";
					}
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[1] = "在社会主义现代化中支持温和改革派。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们力量不够。";
					}
					if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] >= 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "促成亲西方自由派上台。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不能支持他们。";
					}
					fake_text[3] = "远离这里";
				}
				else if (GlobalScript.inst.gameState.number_event == 100)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.influencePRC >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "通过支持反对派来煽动反政府集会。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们力量不够。";
					}
					fake_text[1] = "我们国内也有自己的问题。";
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "拨款支持政府。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不能支持他们。";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 102)
				{
					kolvo_variant = 4;
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
					{
						fake_text[0] = "支持戈尔巴乔夫。";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们对苏共的影响力不够。";
					}
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
					{
						fake_text[1] = "支持罗曼诺夫。";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们对苏共的影响力不够。";
					}
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
					{
						fake_text[2] = "支持格里申。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们对苏共的影响力不够。";
					}
					fake_text[3] = "不要干预 and wait";
				}
				else if (GlobalScript.inst.gameState.number_event == 104)
				{
					kolvo_variant = 3;
					fake_text[0] = "派代表团参加庆典。";
					fake_text[1] = "不派遣。";
					fake_text[2] = "Conduct your own festival for the allied countries (-2 来自预算)";
				}
				else if (GlobalScript.inst.gameState.number_event == 105)
				{
					kolvo_variant = 3;
					fake_text[0] = "什么都不做";
					if ((GlobalScript.inst.gameState.allcountries[15].Torg || GlobalScript.inst.gameState.allcountries[20].Torg) && GlobalScript.inst.gameState.data[9] >= 60)
					{
						fake_text[1] = "Recruit a group of Kosovo Albanians and launch a terrorist attack (-6 代理网络)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们的情报系统应付不了这件事。";
					}
					if (!GlobalScript.inst.gameState.allcountries[20].Torg && !GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						fake_text[2] = "Try to build relationships with the new management (-3 来自预算)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "中阿关系正常";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 106)
				{
					kolvo_variant = 3;
					fake_text[0] = "这不关我们的事";
					if (GlobalScript.inst.gameState.data[9] >= 100)
					{
						fake_text[1] = "策划恐怖袭击，打乱会议";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们的情报系统应付不了这件事。";
					}
					fake_text[2] = "支持组建";
				}
				else if (GlobalScript.inst.gameState.number_event == 109)
				{
					kolvo_variant = 3;
					fake_text[0] = "什么都不做";
					if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.influencePRC >= 200)
					{
						fake_text[1] = "Send military and humanitarian assistance to Somalia (-8 来自预算, -5 代理网络, -5 army strength)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们无法帮助索马里";
					}
					if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.influencePRC >= 200)
					{
						fake_text[2] = "Organize a party coup against Barre (-8 代理网络)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们没有精力被这件事牵扯";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 110)
				{
					kolvo_variant = 4;
					fake_text[0] = "再等几年……或者更久……";
					fake_text[1] = "Announce a course on automation of production and create a commission for its implementation (-10 来自预算)";
					if (GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[2] = "启动自动化，邀请苏联科学家";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "苏联不会帮我们";
					}
					if (GlobalScript.inst.gameState.empires[0].relations >= 600 && GlobalScript.inst.gameState.data[6] <= 800 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.modifies[17].active)
					{
						fake_text[3] = "我们准备开工，西方专家会来帮我们！";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "向西方求助？你们是认真的吗？";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 111)
				{
					kolvo_variant = 4;
					fake_text[0] = "放弃斗争，辞职";
					if (GlobalScript.inst.gameState.data[3] >= 900 && GlobalScript.inst.gameState.data[5] >= 900 && GlobalScript.inst.gameState.modifies[3].active)
					{
						fake_text[1] = "号召群众反对党霸统治";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "人民不需要再来一场新的文化大革命！";
					}
					if (GlobalScript.inst.gameState.data[9] >= 400)
					{
						fake_text[2] = "Arrest conspirators and start persecution against the most proactive partocrats (-40 代理网络)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "国家安全部不会支持我们！";
					}
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "动员忠诚军官对付阴谋分子";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "军官救不了我们";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 112)
				{
					kolvo_variant = 3;
					fake_text[0] = "Allocate funds to develop a protection system (-25 来自预算)";
					if (GlobalScript.inst.gameState.empires[1].relations >= 800 && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.modifies[3].active)
					{
						fake_text[1] = "Fund development and request assistance from specialists from the USSR (-25 来自预算)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "苏联不会帮我们";
					}
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "看来中国还不准备好迎接这种变化，有必要放慢自动化步伐";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们不能放弃我们的成果！";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 113)
				{
					kolvo_variant = 5;
					fake_text[0] = "我们管南斯拉夫干什么？让铁托派自己去处理他们的问题！";
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "We will offer Yugoslavia a restructuring of its debts subject to a rejection of the reform plan (-5 agents, -20 来自预算).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们为什么要重组他们的债务？";
					}
					if (((GlobalScript.inst.gameState.influencePRC >= 150 && GlobalScript.inst.gameState.allcountries[1].isSEV) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.influencePRC >= 250)) && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "我们赞同苏联的提议。";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "我们影响力不够，苏联和南斯拉夫不会听我们的";
					}
					if (GlobalScript.inst.gameState.influencePRC >= 300 && GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "我们将支持由维尔科·卡迪耶维奇和布兰科·马穆拉领导的一伙军人";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "支持军事集团？在南斯拉夫？荒唐！";
					}
					if ((GlobalScript.inst.gameState.influencePRC >= 200 || GlobalScript.inst.gameState.allcountries[51].dev > 0) && GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] >= 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[4] = "批准美国的提议。";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "我们影响力不够，美国和南斯拉夫不会听我们的";
					}
					if (GlobalScript.inst.dlc[6])
					{
						kolvo_variant = 6;
						if (GlobalScript.inst.gameState.influencePRC >= 300 && GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 200)
						{
							fake_text[5] = "提出以部分偿还为条件回购债务义务，以换取在经济领域以优惠条件\n引进中国投资";
						}
						else
						{
							galka_stuk[5].SetActive(value: false);
							fake_text[5] = "我们力量不够";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 115)
				{
					kolvo_variant = 3;
					fake_text[0] = "这不是我们的事";
					if ((GlobalScript.inst.gameState.data[56] >= 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[1] = "与毒贩达成协议（情报网络-1）";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "中国人民并不是为了跟鸦片大亨们称兄道弟才去斗争的";
					}
					fake_text[2] = "协助盟国打击毒贩（情报网络-2，军力-2）";
				}
				else if (GlobalScript.inst.gameState.number_event == 435)
				{
					kolvo_variant = 3;
					fake_text[2] = GlobalScript.inst.new_events_text[1651];
					if (GlobalScript.inst.gameState.data[9] >= 10 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50)
					{
						fake_text[0] = GlobalScript.inst.new_events_text[1649];
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = GlobalScript.inst.new_events_text[1652];
					}
					fake_text[1] = GlobalScript.inst.new_events_text[1650];
				}
				else if (GlobalScript.inst.gameState.number_event == 436)
				{
					kolvo_variant = 3;
					fake_text[0] = GlobalScript.inst.new_events_text[1658];
					fake_text[1] = GlobalScript.inst.new_events_text[1659];
					fake_text[2] = GlobalScript.inst.new_events_text[1660];
				}
				else if (GlobalScript.inst.gameState.number_event == 116)
				{
					kolvo_variant = 3;
					fake_text[0] = "就这样放着吧";
					if (GlobalScript.inst.gameState.data[6] <= 500 && GlobalScript.inst.gameState.empires[0].relations >= 600)
					{
						fake_text[1] = "久盼的统一时刻到了！";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "他们还不准备同意这样的协议";
					}
					fake_text[2] = "相互承认，结束敌对！";
				}
				else if (GlobalScript.inst.gameState.number_event == 103)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.allcountries[1].okb && GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						fake_text[0] = "仅对我们军事同盟成员建立类似申根协议的安排";
					}
					else if (GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						fake_text[0] = "仅对我们军事同盟成员建立类似马德里协议的安排";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们没有军事同盟";
					}
					if (GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						fake_text[1] = "对我们所有同盟成员建立类似申根协议的安排";
					}
					else
					{
						fake_text[1] = "对我们所有同盟成员建立类似马德里协议的安排";
					}
					fake_text[2] = "什么都不做";
				}
				else if (GlobalScript.inst.gameState.number_event == 107)
				{
					kolvo_variant = 5;
					int num9 = (GlobalScript.inst.gameState.data[21] - 1976) * 2 + 1;
					if (GlobalScript.inst.gameState.data[22] >= num9 * 10 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
					{
						fake_text[0] = $"Send troops and return the country to our course ({num9} army strength, -3 来自预算)";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "我们的军队力量和威望不足";
					}
					if (GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
					{
						fake_text[1] = "Organize a coup in favor of forces loyal to us (-10 agents, -3 来自预算)";
					}
					else if (GlobalScript.inst.gameState.data[9] >= 200 && !GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
					{
						fake_text[1] = "Organize a coup in favor of forces loyal to us (-20 agents, -6 来自预算)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "我们的情报系统应付不了这件事。";
					}
					fake_text[2] = "Bind the country economically, allocating financial assistance and a favorable loan (-10 来自预算)";
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[3] = "Do not impede independent politics in exchange for maintaining membership in our bloc (-5 agents, -1 来自预算)";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "我们的情报系统应付不了这件事。";
					}
					fake_text[4] = "我们必须尊重他们的选择";
				}
				else
				{
					kolvo_variant = 1;
					fake_text[0] = "此处无内容";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 1)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не вмешиваться и ожидать итогов";
				if (GlobalScript.inst.gameState.data[1] > 500)
				{
					fake_text[1] = "Пригнать государственных служащих на голосование";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Партия блокирует столь наглое вмешательство";
				}
				if (GlobalScript.inst.gameState.data[9] >= 50)
				{
					fake_text[2] = "Сфальсифицировать итоги";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "У спецслужб не хватит сил";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 3)
			{
				kolvo_variant = 3;
				fake_text[0] = "Кремировать Мао согласно его желанию и построить мемориал";
				fake_text[1] = "Построить для Мао мавзолей на площади Тяньаньмэнь";
				fake_text[2] = "Пусть похоронная комиссия сама решит";
			}
			else if (GlobalScript.inst.gameState.number_event == 4)
			{
				kolvo_variant = 4;
				fake_text[0] = "Вступить в полемику на съезде";
				if (GlobalScript.inst.gameState.data[9] >= 100)
				{
					fake_text[1] = "Арестовать заговорщиков!";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Спецслужбы нас не поддержат";
				}
				if (GlobalScript.inst.gameState.data[22] >= 100)
				{
					fake_text[2] = "Призвать лояльных офицеров!";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Армия нас не поддержит";
				}
				if (GlobalScript.inst.gameState.data[3] >= 700)
				{
					fake_text[3] = "Обратиться к народу!";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Народу не нужна очередная Культурная революция";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 5)
			{
				int num10 = 99;
				if (GlobalScript.inst.gameState.citizens != null)
				{
					Debug.Log("Поиск граждан");
					for (int k = 0; k < GlobalScript.inst.gameState.citizens.Length; k++)
					{
						Persona persona2 = GlobalScript.inst.gameState.citizens[k];
						if (persona2 != null && persona2.Wealth > 9 && (persona2.Intrigue >= 7 || persona2.Charisma > 7) && persona2.status >= Job.LocalPartyBranchChief && !persona2.isPolitic && CitizenManager.Instance != null)
						{
							num10 = k;
						}
					}
				}
				kolvo_variant = 5;
				fake_text[0] = "Выступить и успокоить народ";
				if (num10 != 99 && GlobalScript.inst.gameState.data[38] == 100 && !GlobalScript.inst.gameState.citizens[num10].isLead)
				{
					Debug.Log($"Гражданин {num10} может быть возвышен");
					fake_text[1] = "Человек из народа должен возглавить страну";
					GlobalScript.inst.gameState.citizens[num10].isLead = true;
				}
				else if (GlobalScript.inst.gameState.data[15] != 9 || GlobalScript.inst.gameState.data[17] != 19)
				{
					fake_text[1] = "Согласиться на демократизацию";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Демократизироваться дальше некуда";
				}
				if (GlobalScript.inst.gameState.data[22] >= 100)
				{
					fake_text[2] = "Разогнать протестующих армией";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Армия нас не поддержит";
				}
				if (GlobalScript.inst.gameState.data[3] > 500)
				{
					fake_text[3] = "Призвать лояльную часть народа в поддержку";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Народу не нужна очередная Культурная революция";
				}
				if (GlobalScript.inst.gameState.data[9] >= 150)
				{
					fake_text[4] = "Развалить протест изнутри спецслужбами";
				}
				else
				{
					galka_stuk[4].SetActive(value: false);
					fake_text[4] = "Спецслужбы не справятся";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 6)
			{
				kolvo_variant = 4;
				fake_text[0] = "Срочно выделить деньги на социальные программы";
				if ((GlobalScript.inst.gameState.empires[0].relations >= 500 && !GlobalScript.inst.gameState.allcountries[1].isSEV) || (GlobalScript.inst.gameState.empires[1].relations >= 500 && !GlobalScript.inst.gameState.allcountries[51].Torg && !GlobalScript.inst.gameState.allcountries[1].econ))
				{
					fake_text[1] = "Запросить иностранную гуманитарную помощь";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Помощи ждать неоткуда";
				}
				if (GlobalScript.inst.gameState.data[16] >= 13)
				{
					fake_text[2] = "Методом кнута и пряника призвать бизнес к решению социальных проблем";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Бизнес мы призвать не можем, ибо у нас его нет";
				}
				if (GlobalScript.inst.gameState.data[1] >= 500)
				{
					fake_text[3] = "Устроить благотворительность за счёт партии и чиновников";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Партия не хочет делиться";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 7)
			{
				kolvo_variant = 4;
				if (GlobalScript.inst.gameState.data[51] != 30 || GlobalScript.inst.gameState.data[6] <= 950)
				{
					fake_text[0] = "Организовать разрядку за наш счёт";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Мы не сдадимся!";
				}
				if (GlobalScript.inst.gameState.influencePRC >= 50)
				{
					fake_text[1] = "Сдать часть внешнеполитических позиций в знак доброй воли";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Наше влияние слишком слабо, так что ограничить его мы не можем";
				}
				if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Запустить ядерное оружие по империалистам!";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Никто не хочет ядерной войны";
				}
				fake_text[3] = "Нам всё равно";
				if (GlobalScript.inst.dlc[6])
				{
					kolvo_variant = 5;
					if (GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.data[168] >= 50)
					{
						fake_text[4] = "Подкупить американских сенаторов и замять вопрос";
					}
					else if (!GlobalScript.inst.gameState.modifies[17].active)
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Требуется наличие американских санкций";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Требуется 5.0 денег в Швейцарском банке";
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 8)
			{
				kolvo_variant = 4;
				if (GlobalScript.inst.gameState.data[51] != 30 || GlobalScript.inst.gameState.data[6] <= 950)
				{
					fake_text[0] = "Организовать разрядку за наш счёт";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Мы не сдадимся!";
				}
				if (GlobalScript.inst.gameState.influencePRC >= 50)
				{
					fake_text[1] = "Сдать часть внешнеполитических позиций в знак доброй воли";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Наше влияние слишком слабо, так что ограничить его мы не можем";
				}
				if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Запустить ядерное оружие по ревизионистам!";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Никто не хочет ядерной войны";
				}
				fake_text[3] = "Нам всё равно";
				if (GlobalScript.inst.dlc[6])
				{
					kolvo_variant = 5;
					if (GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.data[168] >= 50)
					{
						fake_text[4] = "Подкупить американских сенаторов и замять вопрос";
					}
					else if (!GlobalScript.inst.gameState.modifies[17].active)
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Требуется наличие американских санкций";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Требуется 5.0 денег в Швейцарском банке";
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 9)
			{
				kolvo_variant = 3;
				fake_text[0] = "Мы ничего не можем сделать";
				if (GlobalScript.inst.gameState.data[18] < 23)
				{
					fake_text[1] = "Дать им больше автономии";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Ещё больше автономии мы дать не можем";
				}
				if (GlobalScript.inst.gameState.data[56] != 4 || GlobalScript.inst.gameState.data[22] >= 100)
				{
					fake_text[2] = "Послать войска для наведения порядка";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Просто задавить их армией не получится";
				}
				if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40 || GlobalScript.inst.gameState.data[36] >= 40 || GlobalScript.inst.gameState.data[9] >= 50)
				{
					fake_text[3] = "Провести сфальсифицированный референдум о суверенитете";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "У нас нет ни средств ни сил на фальсификации";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 10)
			{
				kolvo_variant = 3;
				fake_text[0] = "Мы ничего не можем сделать";
				if (GlobalScript.inst.gameState.data[18] < 23)
				{
					fake_text[1] = "Дать им больше автономии";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Ещё больше автономии мы дать не можем";
				}
				if (GlobalScript.inst.gameState.data[56] != 4 || GlobalScript.inst.gameState.data[22] >= 100)
				{
					fake_text[2] = "Послать войска для наведения порядка";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Просто задавить их армией не получится";
				}
				if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 20 || GlobalScript.inst.gameState.data[36] >= 20 || GlobalScript.inst.gameState.data[9] >= 40)
				{
					fake_text[3] = "Провести сфальсифицированный референдум о суверенитете";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "У нас нет ни средств ни сил на фальсификации";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 11)
			{
				kolvo_variant = 4;
				fake_text[0] = "Срочно выделить деньги на развитие";
				if (GlobalScript.inst.gameState.empires[0].relations >= 600 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
				{
					fake_text[1] = "Привлечь иностранные инвестиции";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Инвесторы к нам не пойдут";
				}
				if (GlobalScript.inst.gameState.empires[1].relations >= 700 || GlobalScript.inst.gameState.relres)
				{
					fake_text[2] = "Запросить помощи у СССР";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Нам не нужны подачки ревизионистов!";
				}
				if (GlobalScript.inst.gameState.data[13] >= 500)
				{
					fake_text[3] = "Форсировать развитие за счёт сельского хозяйства";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Положение в сельском хозяйстве не сильно лучше";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 12)
			{
				kolvo_variant = 4;
				fake_text[0] = "Срочно выделить деньги на развитие";
				if (GlobalScript.inst.gameState.empires[0].relations >= 600 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
				{
					fake_text[1] = "Привлечь иностранные инвестиции";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Инвесторы к нам не пойдут";
				}
				if (GlobalScript.inst.gameState.empires[1].relations >= 700 || GlobalScript.inst.gameState.relres)
				{
					fake_text[2] = "Запросить помощи у СССР";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Нам не нужны подачки ревизионистов!";
				}
				if (GlobalScript.inst.gameState.data[12] >= 500)
				{
					fake_text[3] = "Форсировать развитие за счёт промышленности";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Положение в промышленности не сильно лучше";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 13)
			{
				kolvo_variant = 4;
				fake_text[0] = "Срочно выделить деньги на развитие";
				if (GlobalScript.inst.gameState.empires[0].relations >= 600 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
				{
					fake_text[1] = "Привлечь иностранные инвестиции";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Инвесторы к нам не пойдут";
				}
				if (GlobalScript.inst.gameState.empires[1].relations >= 700 || GlobalScript.inst.gameState.relres)
				{
					fake_text[2] = "Запросить помощи у СССР";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Нам не нужны подачки ревизионистов!";
				}
				if (GlobalScript.inst.gameState.data[12] >= 500 || GlobalScript.inst.gameState.data[13] >= 500)
				{
					fake_text[3] = "Форсировать развитие за счёт промышленности и сельского хозяйства";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Положение в промышленности и сельском хозяйстве не сильно лучше";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 14)
			{
				int num11 = 0;
				kolvo_variant = 4;
				if (GlobalScript.inst.gameState.data[16] >= 13 && GlobalScript.inst.gameState.data[5] >= 500)
				{
					fake_text[0] = "Поднять налоги и сократить социальные программы";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "";
					num11++;
				}
				if (GlobalScript.inst.gameState.data[16] >= 14)
				{
					fake_text[1] = "Поднять налоги на роскошь и для сверхбогатых";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Олигархов у нас нет";
					num11++;
				}
				if (GlobalScript.inst.gameState.data[16] <= 14 && GlobalScript.inst.gameState.data[56] != 0 && (GlobalScript.inst.gameState.data[15] > 7 || GlobalScript.inst.gameState.data[56] != 1))
				{
					fake_text[3] = "Провести быструю приватизацию госпредприятий";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Приватизацию провести не получится";
					num11++;
				}
				if (GlobalScript.inst.gameState.empires[0].relations > 500 || (GlobalScript.inst.gameState.empires[1].relations > 500 && GlobalScript.inst.gameState.influencePRC >= 50) || num11 >= 3)
				{
					fake_text[2] = "Взять иностранный кредит";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Кредит нам не дадут";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 15)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не вмешиваться";
				if (GlobalScript.inst.gameState.data[9] >= 30 && GlobalScript.inst.gameState.data[56] != 0)
				{
					fake_text[1] = "Сместить Пол Пота в пользу тройки Ху Ним, Ху Юн и Кхиеу Сампхан";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Мы не можем смещать Пол Пота";
				}
				if (GlobalScript.inst.gameState.data[56] != 4)
				{
					fake_text[2] = "Помочь Красным кхмерам";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Мы не можем помогать диктатору!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 16)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не вмешиваться";
				if (GlobalScript.inst.gameState.data[9] >= 20 || GlobalScript.inst.gameState.allcountries[34].stab == 1)
				{
					fake_text[1] = "Поддержать КПТ и создать коалицию с левыми и демократами";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит сил на поддержку КПТ";
				}
				if (GlobalScript.inst.gameState.data[22] >= 20 && GlobalScript.inst.gameState.data[56] != 4)
				{
					fake_text[2] = "К чёрту выборы! Лучше вышлем КПТ больше оружия для партизанской войны.";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Отправить КПТ ещё оружия мы не можем";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 17)
			{
				kolvo_variant = 3;
				fake_text[0] = "Это не наше дело";
				if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.data[22] >= 30 && GlobalScript.inst.gameState.data[41] == 100)
				{
					fake_text[1] = "Направить вооружённые части КПТ в помощь демонстрантам и спровоцировать восстание";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит сил на организацию восстания";
				}
				fake_text[2] = "Осудить жестокости Таиланда";
			}
			else if (GlobalScript.inst.gameState.number_event == 18)
			{
				kolvo_variant = 1;
				if (GlobalScript.inst.gameState.data[82] < 8)
				{
					fake_text[0] = "Да здравствует мир!";
				}
				else
				{
					fake_text[0] = "Нужно ознакомиться!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 19)
			{
				kolvo_variant = 4;
				fake_text[0] = "Пусть проходит, как проходит";
				fake_text[1] = "Следить за строгим исполнением указов Мао";
				fake_text[2] = "Следить за строгим исполнением кампании, а также критиковать Чжоу в СМИ.";
				fake_text[3] = "Аккуратно саботировать кампанию";
			}
			else if (GlobalScript.inst.gameState.number_event == 20)
			{
				kolvo_variant = 3;
				fake_text[0] = "А ничего не делать. Цзян Цин и Сяопин друг друга стоят";
				fake_text[1] = "Присоединиться к травле Сяопина";
				fake_text[2] = "Заступиться за Сяопина";
			}
			else if (GlobalScript.inst.gameState.number_event == 21)
			{
				kolvo_variant = 3;
				fake_text[0] = "Ничего не делаем: цели статьи неясны, не лезем под горячую руку";
				fake_text[1] = "Жёстко пресечь публикацию и спекуляции, чтобы не будоражить массы";
				fake_text[2] = "Повернуть статью против каппутистских реформ";
			}
			else if (GlobalScript.inst.gameState.number_event == 22)
			{
				kolvo_variant = 3;
				fake_text[0] = "Разогнать протест с помощью армии и полиции";
				if (GlobalScript.inst.gameState.data[88] >= 0)
				{
					fake_text[1] = "Призвать всех разойтись и разогнать оставшихся";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Народ не хочет уходить";
				}
				if (GlobalScript.inst.gameState.data[88] >= 2)
				{
					fake_text[2] = "Призвать всех разойтись и оцепить оставшихся до тех пор, пока не уйдут";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Народ не хочет уходить";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 23)
			{
				kolvo_variant = 4;
				fake_text[0] = "Выделить средства из бюджета на восстановление (-3.0 из бюджета)";
				if (GlobalScript.inst.gameState.empires[0].relations >= 600 || GlobalScript.inst.gameState.empires[1].relations >= 600)
				{
					fake_text[1] = "Запросить иностранную гуманитарную помощь";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Иностранцы не выделят нам помощь";
				}
				fake_text[2] = "Выделить средства на восстановление и на развитие системы защиты от землетрясений (-5.0 из бюджета)";
				fake_text[3] = "Пусть провинциальная администрация разбирается сама";
			}
			else if (GlobalScript.inst.gameState.number_event == 24)
			{
				kolvo_variant = 4;
				fake_text[0] = "Продолжим дело Мао, свернув Культурную революцию";
				if (GlobalScript.inst.gameState.data[84] == 3)
				{
					fake_text[1] = "Культурная революция без перегибов и борьба с ревизионизмом по заветам Мао!";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Культурная революция уже всем надоела";
				}
				if (GlobalScript.inst.gameState.data[84] != 3)
				{
					fake_text[2] = "Свернём Культурную революцию, и с экономикой что-то делать надо...";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "";
				}
				if (GlobalScript.inst.gameState.data[84] != 3)
				{
					fake_text[3] = "Свернём Культурную революцию и начнём разработку масштабных реформ с выходом на мировой рынок";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 25)
			{
				kolvo_variant = 4;
				fake_text[0] = "Арестовать всех четырех";
				fake_text[1] = "Арестовать Ван Хунвэня и Цзян Цин и найти компромисс с остальными радикалами";
				fake_text[2] = "Пойти на компромисс и заручиться поддержкой радикалов";
				fake_text[3] = "Не вмешиваться в разборки в партии";
			}
			else if (GlobalScript.inst.gameState.number_event == 26)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.data[9] >= 70)
				{
					fake_text[0] = "Арестовать всех четырех";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "У вас уже не хватит сил";
				}
				if (GlobalScript.inst.gameState.data[9] >= 50)
				{
					fake_text[1] = "Арестовать лишь Ван Хунвэня и Цзян Цин";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "У вас уже не хватит сил";
				}
				fake_text[2] = "Отказаться от борьбы и пойти на постепенную передачу власти";
			}
			else if (GlobalScript.inst.gameState.number_event == 27)
			{
				kolvo_variant = 3;
				fake_text[0] = "Договориться о передаче колоний при сохранении их широкой автономии";
				fake_text[1] = "Договориться о передаче колоний при сохранении их ограниченной автономии";
				fake_text[2] = "Потребовать полной интеграции колоний в КНР при сохранении прав собственности иностранцев";
			}
			else if (GlobalScript.inst.gameState.number_event == 28)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не вмешиваться, Сухарто и так обречён";
				if (GlobalScript.inst.gameState.data[9] >= 30)
				{
					fake_text[1] = "Поддержать умеренно-левую оппозицию";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит сил на поддержку левых";
				}
				if (GlobalScript.inst.gameState.data[9] >= 50)
				{
					fake_text[2] = "Помочь коммунистическому подполью вновь организоваться";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Восстановить коммунистическое движение мы не сможем";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 29)
			{
				kolvo_variant = 4;
				fake_text[0] = "Потребовать ограниченной политической либерализации";
				fake_text[1] = "Потребовать широких политических и экономических реформ";
				if (GlobalScript.inst.gameState.data[16] >= 13)
				{
					fake_text[2] = "Потребовать открытия СЭЗ для китайских компаний";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Империализмом мы заниматься не станем и не можем";
				}
				fake_text[3] = "Потребовать максимально возможной демократизации";
			}
			else if (GlobalScript.inst.gameState.number_event == 30)
			{
				kolvo_variant = 3;
				fake_text[0] = "Предложить создание арабского государства на части территорий Палестины";
				fake_text[1] = "Предложить создание автономии для арабов до дальнейшего урегулирования кризиса";
				fake_text[2] = "Предложить создание союзного государства арабов и евреев";
			}
			else if (GlobalScript.inst.gameState.number_event == 31)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не вмешиваться в демократический процесс";
				if (GlobalScript.inst.gameState.data[9] >= 40)
				{
					fake_text[1] = "Помочь Ким Дэ Чжуну собрать коалицию оппозиции";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит сил поддержать его";
				}
				if (GlobalScript.inst.gameState.data[9] >= 60 && GlobalScript.inst.gameState.influencePRC >= 200 && GlobalScript.inst.gameState.data[83] != 2 && GlobalScript.inst.gameState.data[83] != 1)
				{
					fake_text[2] = "Помочь Ким Дэ Чжуну и надавить на КНДР, подтолкнув к объединению";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Нам не хватит сил на такое мероприятие";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 32)
			{
				kolvo_variant = 2;
				fake_text[0] = "Наблюдать за развитием ситуации";
				if (GlobalScript.inst.gameState.data[9] >= 40)
				{
					fake_text[1] = "Воспользоваться ситуацией в наших целях";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит сил";
				}
				galka_stuk[2].SetActive(value: false);
				fake_text[2] = "Спровоцировать антисоветские выступления, чтобы помочь их подавить? Серьёзно?";
			}
			else if (GlobalScript.inst.gameState.number_event == 33)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не вмешиваться";
				if (GlobalScript.inst.gameState.data[9] >= 60)
				{
					fake_text[1] = "Помочь Бхутто";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Помочь мы не можем";
				}
				fake_text[2] = "Не вмешиваться и наладить отношения с новым правительством";
			}
			else if (GlobalScript.inst.gameState.number_event == 34)
			{
				kolvo_variant = 4;
				fake_text[0] = "Осторожно ударить по реформаторам";
				fake_text[1] = "Ограничиться продвижением лояльных консерваторов";
				fake_text[2] = "Ударить по реформаторам, чтобы расчистить путь умеренным-консерваторам";
				if (GlobalScript.inst.gameState.data[87] != 1 && GlobalScript.inst.gameState.data[87] != 2)
				{
					fake_text[3] = "Нам нужен крепкий альянс с реформаторами!";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Вам нельзя договариваться с ревизионистами!";
				}
				fake_text[4] = "Не стоит ломать шаткий баланс в партии";
			}
			else if (GlobalScript.inst.gameState.number_event == 35)
			{
				kolvo_variant = 4;
				fake_text[0] = "Ничего не делать, хватит уступок";
				fake_text[1] = "Ограничиться небольшой гражданской либерализацией";
				fake_text[2] = "Ослабить контроль и прекратить давление на традиции";
				if (GlobalScript.inst.gameState.data[56] != 0)
				{
					fake_text[3] = "Ослабить контроль и перейти лишь к надзору за религией";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Мы не можем идти на такую либерализацию!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 36)
			{
				kolvo_variant = 3;
				fake_text[0] = "Нет, не стоит";
				fake_text[1] = "Осудить руководство Баас";
				if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.influencePRC >= 50)
				{
					fake_text[2] = "С помощью спецслужб и политического давления склонить стороны к диалогу";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "У нас не хватит сил и влияния";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 37)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] <= 1 && GlobalScript.inst.gameState.allcountries[30].stab == 1) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Всеми силами поддержим выступления и спровоцируем свержение Садата";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Это слишком радикальное вмешательство в дела Египта!";
				}
				if (GlobalScript.inst.gameState.data[9] >= 20 && (GlobalScript.inst.gameState.data[56] <= 2 || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[1] = "Помочь Ливии и Сирии свалить Садата";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "А так ли нужна нам эта Северная Африка?";
				}
				fake_text[2] = "Дела Египта нас не волнуют";
			}
			else if (GlobalScript.inst.gameState.number_event == 38)
			{
				kolvo_variant = 3;
				int num12 = 0;
				if (GlobalScript.inst.gameState.data[87] != 4)
				{
					fake_text[1] = "Возродить плановую систему (-1.0 из бюджета)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Партия идёт к реформам, следуя вашим курсом!";
					num12++;
				}
				if (GlobalScript.inst.gameState.data[84] != 3 && GlobalScript.inst.gameState.data[87] != 2 && GlobalScript.inst.gameState.data[87] != 1 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[2] = "Начать подготовку для дальнейших масштабных реформ";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Долой ревизионизм!";
					num12++;
				}
				if ((GlobalScript.inst.gameState.data[87] != 2 && GlobalScript.inst.gameState.data[87] != 4) || num12 >= 2)
				{
					fake_text[0] = "Не стоит ломать то, что работает";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Старая система своё отжила!";
					num12++;
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 39)
			{
				kolvo_variant = 3;
				fake_text[0] = "Председатель " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " лично возглавит комиссию из консервативных маоистов. Наш путь верен!";
				fake_text[1] = "Доверим работу Дэн Сяопину и прагматичным реформаторам. Они дадут взвешенную оценку.";
				if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Товарищи Пэн Чжень и Чжао Цзыян вскроют все ошибки и изобличат их!";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Чжень? Цзыян? Это же либералы, которых Председатель Мао выгнал взашей!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 40)
			{
				kolvo_variant = 5;
				if (GlobalScript.inst.gameState.data[56] <= 1)
				{
					fake_text[0] = "Пусть сидит и дальше!";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Мы не можем удерживать его в тюрьме и дальше!";
				}
				if (GlobalScript.inst.gameState.data[56] <= 2)
				{
					fake_text[1] = "Отпустить из тюрьмы в обмен на отказ от монашеских обетов.";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Это слишком сильное давление на него!";
				}
				if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.data[56] != 0 && GlobalScript.inst.gameState.data[56] != 4)
				{
					fake_text[2] = "Отпустить и позволить вернуться в Лхасу, но под наблюдением МГБ (4 агентурные сети).";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Или пусть сидит в тюрьме, или пусть будет свободен.";
				}
				if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[3] = "Выпустить узника совести и реабилитировать его!";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Реабилитировать?! Да его сам Председатель Мао обвинил!";
				}
				if (GlobalScript.inst.gameState.data[9] >= 70 && GlobalScript.inst.gameState.data[56] != 4)
				{
					fake_text[4] = "Ликвидировать его под видом сердечного приступа и заставить избрать Норбу новым Панчен-Ламой.";
				}
				else
				{
					galka_stuk[4].SetActive(value: false);
					fake_text[4] = "Панчен-Ламу должны выбирать сами монахи!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 41)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не вмешиваться";
				if (GlobalScript.inst.gameState.data[9] >= 50)
				{
					fake_text[1] = "Поддержать оппозицию";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "У нас не хватит сил";
				}
				if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.data[56] != 0)
				{
					fake_text[2] = "Поддержать Индиру Ганди";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Поддержать Ганди? Может ещё и тибетские территории ей отдать?";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 42)
			{
				kolvo_variant = 5;
				fake_text[0] = "Не вмешиваться";
				if (GlobalScript.inst.gameState.data[9] >= 50)
				{
					fake_text[1] = "Поддержать левые организации";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Помочь мы не можем";
				}
				if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[2] = "Поддержать исламистов";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Помогать религиозным фанатикам? Да ни за что!";
				}
				if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[3] = "Поддержать правящий режим";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Мы никогда не поддержим проамериканского шаха!";
				}
				if (GlobalScript.inst.gameState.data[9] >= 50)
				{
					fake_text[4] = "Поддержать демократов";
				}
				else
				{
					galka_stuk[4].SetActive(value: false);
					fake_text[4] = "Помочь мы не можем";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 43)
			{
				kolvo_variant = 2;
				fake_text[0] = "Не вмешиваться";
				if (GlobalScript.inst.gameState.data[9] >= 30 && (GlobalScript.inst.gameState.allcountries[23].Gosstroy != 0 || GlobalScript.inst.gameState.allcountries[23].EAF))
				{
					fake_text[1] = "Всеми средствами остановить процесс вступления";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Мы ничего не можем сделать";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 44)
			{
				kolvo_variant = 3;
				fake_text[0] = "Согласиться начать реформы. " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2] + " получит власть.";
				if (GlobalScript.inst.gameState.data[9] >= 150)
				{
					fake_text[1] = "Затягивать заседание, чтобы в перерыве арестовать реформаторов силами МГБ";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "У нас нет ни сил, ни влияния на такое";
				}
				if (GlobalScript.inst.gameState.data[87] != 1 && GlobalScript.inst.gameState.data[87] != 2)
				{
					fake_text[2] = "Согласиться с их требованиями в обмен на удержание власти";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "После ваших высказываний они не станут сотрудничать";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 45)
			{
				kolvo_variant = 5;
				fake_text[0] = "Вперёд, к социалистическому рынку!";
				fake_text[1] = "Назад пути нет!";
				galka_stuk[1].SetActive(value: false);
				fake_text[2] = "Вы что, догматик?!";
				galka_stuk[2].SetActive(value: false);
				fake_text[3] = "Можем вас в ещё одну банду записать, если вы против.";
				galka_stuk[3].SetActive(value: false);
				fake_text[4] = "Неважно, какого цвета кошка, даже если она собака!";
				galka_stuk[4].SetActive(value: false);
			}
			else if (GlobalScript.inst.gameState.number_event == 46)
			{
				kolvo_variant = 4;
				fake_text[0] = "Европа далеко, Азия нам важнее";
				if (GlobalScript.inst.gameState.data[9] >= 80)
				{
					fake_text[1] = "Организовать поддержку и координацию Белу Биску и его людей с нашими спецслужбами";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "У нас не хватит сил";
				}
				if (GlobalScript.inst.gameState.data[9] >= 30 && GlobalScript.inst.gameState.data[22] >= 10)
				{
					fake_text[2] = "Помочь в организации прокитайского восстания";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Новое восстание в Венгрии?! Одумайтесь!";
				}
				if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[3] = "Мы не можем помочь, но с радостью укроем у себя Биску от гнева ревизионистов";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Европа далеко, Азия нам важнее";
				}
				if (GlobalScript.inst.dlc[6])
				{
					kolvo_variant = 5;
					if (GlobalScript.inst.gameState.data[9] >= 80)
					{
						fake_text[4] = "Посеять хаос в рядах ВСРП надеясь выловить рыбку в этой мутной воде";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "У нас не хватит сил";
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 47)
			{
				kolvo_variant = 3;
				fake_text[0] = "Пусть МГБ и ответственный за кадры в КПК займутся этими проблемами";
				fake_text[1] = "Вступить в полемику с реформаторами и выпустить собственные опровержения";
				fake_text[2] = "Наши СМИ сами разберутся с этой дешёвой пропагандой";
			}
			else if (GlobalScript.inst.gameState.number_event == 63)
			{
				kolvo_variant = 4;
				fake_text[0] = "Не вмешиваться в афганские дела";
				if (GlobalScript.inst.gameState.data[9] >= 30)
				{
					fake_text[1] = "Оказать поддержку лояльной нам оппозиции в ДРА";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "У нас нет сил на такое";
				}
				if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[2] = "Установить отношения и оказывать поддержку Хальк";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Они не станут сотрудничать";
				}
				if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[3] = "Установить отношения и оказывать поддержку Парчам";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Они не станут сотрудничать";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 48)
			{
				kolvo_variant = 3;
				fake_text[0] = "Лучше не будем влезать в эти дела";
				fake_text[1] = "Начать пока негласное сближение с ДРА (-2.0 из бюджета)";
				if (GlobalScript.inst.gameState.relres)
				{
					fake_text[2] = "Не доверяем мы ему... Лучше тайно договоримся с СССР о его смещении, глядишь нам от новой власти что-нибудь перепадёт.";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Никаких сговоров с СССР!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 49)
			{
				kolvo_variant = 2;
				fake_text[0] = "Это дело СССР";
				if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[9] >= 70)
				{
					fake_text[1] = "Предупредить Амина и выслать ему помощь";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Никто не даст нам вмешаться";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 50)
			{
				kolvo_variant = 5;
				fake_text[0] = "Никого. Это не наше дело";
				if (GlobalScript.inst.gameState.relres)
				{
					fake_text[1] = "Оказать помощь ДРА в обмен на включение маоистских партий в альянс с НДПА";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "СССР не даст нам так глубоко вмешаться";
				}
				fake_text[2] = "Оказать помощь ДРА";
				fake_text[3] = "Оказать помощь маоистским повстанцам";
				fake_text[4] = "Продать оружия моджахедам, американцы готовы заплатить";
			}
			else if (GlobalScript.inst.gameState.number_event == 51)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не реагировать";
				fake_text[1] = "Осудить ввод войск";
				fake_text[2] = "Поддержать ввод войск";
			}
			else if (GlobalScript.inst.gameState.number_event == 53)
			{
				kolvo_variant = 4;
				fake_text[0] = "Оставить всё как есть";
				fake_text[1] = "Ввести семейный подряд";
				if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Ввести частное фермерство";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Мы не отдадим сельское хозяйство частникам-спекулянтам!";
				}
				if (GlobalScript.inst.gameState.data[89] == 0)
				{
					fake_text[3] = "Организовать колхозы";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Колхозы - пережиток плана";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 54)
			{
				kolvo_variant = 3;
				fake_text[0] = "Отложить этот вопрос";
				if (GlobalScript.inst.gameState.data[16] > 11)
				{
					fake_text[1] = "Открыть СЭЗ";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Мао от такого в гробу перевернётся!";
				}
				if (GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[16] > 11)
				{
					fake_text[2] = "Открыть СЭЗ и часть остальных предприятий для инвестирования";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Мао от такого в гробу перевернётся!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 55)
			{
				kolvo_variant = 3;
				fake_text[0] = "Нас это не касается";
				fake_text[1] = "Отправить помощь У Не Вину и установить дружеские отношения (-3.0 из бюджета)";
				if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.allcountries[33].stab == 1)
				{
					fake_text[2] = "Помочь коммунистам организовать партийный переворот";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Мы не сможем им помочь";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 56)
			{
				kolvo_variant = 3;
				fake_text[0] = "Не будем обострять ситуацию";
				if (!GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.war == 0)
				{
					fake_text[1] = "Готовьтесь к войне. Преподадим Вьетнаму урок!";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Всё идёт по плану";
				}
				if (!GlobalScript.inst.gameState.event_done[14] && !GlobalScript.inst.gameState.allcountries[11].isSEV)
				{
					fake_text[2] = "Провести встречу и переговоры КНР и Вьетнама";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Они не станут с нами договариваться";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 57)
			{
				kolvo_variant = 2;
				fake_text[0] = "Это нас не касается";
				if (GlobalScript.inst.gameState.data[9] >= 60 && GlobalScript.inst.gameState.allcountries[44].stab == 1)
				{
					fake_text[1] = "Оказать финансовую и агентурную помощь КПЯ";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "КПЯ нас не послушается";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 58)
			{
				kolvo_variant = 1;
				fake_text[0] = "Революция завершилась";
			}
			else if (GlobalScript.inst.gameState.number_event == 59)
			{
				if (GlobalScript.inst.dlc[3])
				{
					kolvo_variant = 5;
				}
				else
				{
					kolvo_variant = 4;
				}
				fake_text[0] = "Проигнорировать предложение";
				if (!GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[1] = "Создать экономический союз (-15.0 из бюджета)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Мы не готовы (-15 из бюджета)";
				}
				if (!GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10) && GlobalScript.inst.gameState.war <= 0 && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[56] <= 1 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					fake_text[2] = "Вступить в СЭВ";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Никаких переговоров с ревизионистами!";
				}
				if (GlobalScript.inst.gameState.war <= 0 && !GlobalScript.inst.gameState.allcountries[1].isOVD && !GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.allcountries[1].Vyshi && !GlobalScript.inst.gameState.allcountries[15].cw)
				{
					fake_text[3] = "Вступить в «Движение Неприсоединения»";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Нас там недолюбливают.";
				}
				if (GlobalScript.inst.dlc[3])
				{
					if (!GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12) && GlobalScript.inst.gameState.war <= 0 && GlobalScript.inst.gameState.allcountries[1].Gosstroy != 1 && !GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[51].Torg && GlobalScript.inst.gameState.data[52] > 34)
					{
						fake_text[4] = "Присоединиться к АСЕАН";
					}
					else if (GlobalScript.inst.gameState.relres)
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Отношения с СССР не должны быть восстановлены";
					}
					else if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 1)
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Госстрой не должен быть социализмом";
					}
					else if (GlobalScript.inst.gameState.data[52] <= 34)
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Линия партии должна быть Реформаторской или либеральнее";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Нужна дружба с США";
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 60)
			{
				kolvo_variant = 2;
				if (GlobalScript.inst.gameState.data[22] >= 300 && GlobalScript.inst.gameState.data[9] >= 100 && !GlobalScript.inst.gameState.allcountries[1].isOVD)
				{
					fake_text[0] = "Создать военный блок (-5 из бюджета, -30 силы армии и -10 агентурных сетей)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Мы не готовы (-5 из бюджета, -30 силы армии и -10 агентурных сетей)";
				}
				fake_text[1] = "Ничего не делать";
			}
			else if (GlobalScript.inst.gameState.number_event == 61)
			{
				kolvo_variant = 3;
				fake_text[0] = "Восстанавливаем \"Марш добровольцев\" без изменений (-1 из бюджета)";
				if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[1] = "Утверждаем гимном \"Алеет Восток\"";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Никаких рецидивов Культурной революции!";
				}
				if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Восстанавливаем \"Марш добровольцев\", но с новым текстом (-1 из бюджета)";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "В этом нет необходимости!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 62)
			{
				kolvo_variant = 5;
				if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[0] = "Это справедливый шаг. Именно так мы и поступим! (-3 из бюджета)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Никаких уступок!";
				}
				fake_text[1] = "Не слишком ли много чести для национального меньшинства? Отказать.";
				if (GlobalScript.inst.gameState.data[56] != 1)
				{
					fake_text[2] = "Территории вернем, но ассимиляцию не прекратим.";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Это не соответствует национальной политике КПК!";
				}
				if (GlobalScript.inst.gameState.data[56] != 0 && GlobalScript.inst.gameState.data[56] != 3)
				{
					fake_text[3] = "Ассимиляцию имеет смысл прекратить, но территории возвращать не будем (-1 из бюджета)";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Это тоже не соответствует национальной политике КПК!";
				}
				if (GlobalScript.inst.gameState.data[50] != 24 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[18] < 23)
				{
					fake_text[4] = "Пришло время всерьез заняться национальным вопросом в малых АР. Выправим все перегибы! (-6 из бюджета)";
				}
				else
				{
					galka_stuk[4].SetActive(value: false);
					fake_text[4] = "Национального вопроса в Китае нет! Он решен в 50-е годы раз и навсегда.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 52)
			{
				kolvo_variant = 4;
				fake_text[0] = "Пусть Пакистан сам разбирается";
				fake_text[1] = "Выслать Пакистану помощь для патруля границы и поимки исламистов";
				if (GlobalScript.inst.gameState.ingamewars[5].ussr_place != 1 && !GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[2] = "Договориться с США";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Никакой помощи реакционерам!";
				}
				if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 1)
				{
					fake_text[3] = "Зачем нам всё это? Лучше организуем в Пакистане базы для афганских повстанцев-маоистов (-5 из бюджета)";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Маоистским партизанам в ДРА уже не помочь";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 64)
			{
				kolvo_variant = 2;
				fake_text[0] = "Это не стоит наших сил";
				if (GlobalScript.inst.gameState.data[9] >= 50 && (!GlobalScript.inst.gameState.allcountries[30].prosov || GlobalScript.inst.gameState.relres))
				{
					fake_text[1] = "Оказать помощь в создании ОАР (-7 из бюджета, -5 агентурных сетей)";
				}
				else if (GlobalScript.inst.gameState.data[9] < 50)
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нужно 5 агентурных сетей...";
				}
				else if (GlobalScript.inst.gameState.allcountries[30].prosov && !GlobalScript.inst.gameState.relres)
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Отношения с СССР не восстановлены...";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Они не пойдут на это...";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 65)
			{
				kolvo_variant = 5;
				int num13 = 0;
				if ((GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))) || GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[0] = "Спорт вне политики! Мы примем участие в московской Олимпиаде и отправим лучших спортсменов! (-4 из бюджета)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					num13++;
					fake_text[0] = "Мы не можем игнорировать мнение Запада";
				}
				if ((GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[56] != 0))
				{
					fake_text[1] = "Бойкота не объявляем, но обе Игры игнорируем...";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					num13++;
					fake_text[1] = "Мы не можем игнорировать обе Игры!";
				}
				if (GlobalScript.inst.gameState.data[89] > 0 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[3] = "Объявляем советским Играм бойкот и отправляем команду в США (-3 из бюджета).";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					num13++;
					fake_text[3] = "Поехать в США?! Вы это серьезно?..";
				}
				if (GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[4] = "Возрождаем GANEFO и отправляем приглашения развивающимся странам (-20 из бюджета).";
				}
				else
				{
					galka_stuk[4].SetActive(value: false);
					num13++;
					fake_text[4] = "Хватит с нас маоистских экспериментов!";
				}
				if ((((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[56] != 0) || num13 >= 4)
				{
					fake_text[2] = "Объявим бойкот, но разрешим нашим спортсменам поехать в Москву под олимпийским флагом (-4 из бюджета).";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Это не соответствует нашей политике!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 66)
			{
				kolvo_variant = 4;
				fake_text[0] = "Выразим свои соболезнования, но не более того.";
				if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0) || GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[1] = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " лично возглавит правительственную делегацию и вылетит в Белград.";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " не может лично лететь на похороны ревизиониста Тито!";
				}
				if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Отправим делегацию во главе с Генеральным секретарем Госсовета Цзи Пэнфэем.";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Никаких делегаций в Белград!";
				}
				if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[3] = "Тито умер? Ну и пусть, нам-то что?";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Мы не можем никак не отреагировать на его смерть!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 67)
			{
				kolvo_variant = 5;
				fake_text[0] = "Дела Польши Китая не касаются. Сами наломали дров - сами и разбирайтесь!";
				if (GlobalScript.inst.gameState.relres)
				{
					fake_text[1] = "Поддержим просоветских военных во главе с генералом Войцехом Витольдом Ярузельским (-5 агентов, -20 из бюджета).";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Договор о дружбе с СССР не подписан...";
				}
				if (GlobalScript.inst.gameState.allcountries[20].proprc && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[2] = "Формируем коалицию из Компартии Мияля, \"бетона\" Сивака, \"ПАКС\" и \"Грюнвальд\", поддерживаем всеми силами (-15 агентов, -30 из бюджета).";
				}
				else if (!GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Албания должна быть в нашей сфере влияния...";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Реформаторы и либералы не должны лидировать...";
				}
				if (GlobalScript.inst.gameState.empires[1].relations >= 600 && GlobalScript.inst.gameState.allcountries[1].isOVD)
				{
					fake_text[3] = "Обратимся к странам ОВД с предложением военного вмешательства (-5 агентов -5 силы армии).";
				}
				else if (!GlobalScript.inst.gameState.allcountries[1].isOVD)
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Мы должны состоять в ОВД...";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Отношения с СССР должны быть выше 60.0...";
				}
				if (GlobalScript.inst.gameState.empires[0].relations >= 600 && GlobalScript.inst.gameState.allcountries[51].Torg && !GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[4] = "Вместе с США поддержим \"Солидарность\" (-10 из бюджета, -20 агентов)";
				}
				else if (!GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					galka_stuk[4].SetActive(value: false);
					fake_text[4] = "Нужен договор о дружбе с США...";
				}
				else
				{
					galka_stuk[4].SetActive(value: false);
					fake_text[4] = "Отношения с США должны быть выше 60.0...";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 68)
			{
				kolvo_variant = 2;
				fake_text[0] = "Пусть сами разбираются";
				if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[22] >= 80)
				{
					fake_text[1] = "Оказать помощь восставшим и спровоцировать волнения (-8 силы армии, -10 агентурных сетей)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "У нас не хватит ресурсов";
					fake_text[2] = "Призвать стороны к диалогу";
					fake_text[3] = "Поддержать действия Чон Ду Хвана";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 69)
			{
				kolvo_variant = 3;
				fake_text[0] = "Ничего не делать. Разные взгляды - залог демократии.";
				int num14 = 0;
				int num15 = 0;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic3 in politics)
				{
					if (politic3.traits[0] == 1 || politic3.traits[0] == 2)
					{
						num14 += politic3.power;
					}
					else if (politic3.traits[0] == 0)
					{
						num15 += politic3.power;
					}
				}
				if (GlobalScript.inst.gameState.data[1] >= 650 && num14 > num15)
				{
					fake_text[1] = "Атаковать консерваторов на пленуме КПК и продвигать активных реформаторов";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "КПК не даст вам так просто перемешать кадры";
				}
				if (GlobalScript.inst.gameState.data[1] >= 600 && num14 > num15)
				{
					fake_text[2] = "Атаковать консерваторов на пленуме КПК";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "КПК не даст вам так просто устранить их";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 70)
			{
				kolvo_variant = 2;
				int num16 = 0;
				int num17 = 0;
				Politic[] politics = GlobalScript.inst.gameState.politics;
				foreach (Politic politic4 in politics)
				{
					if (politic4.traits[0] == 1 || politic4.traits[0] == 2)
					{
						num16 += politic4.power;
					}
					else if (politic4.traits[0] == 0)
					{
						num17 += politic4.power;
					}
				}
				fake_text[0] = "Ничего не делать. Разные взгляды - залог демократии.";
				if (GlobalScript.inst.gameState.data[1] >= 800 && num17 > num16)
				{
					fake_text[1] = "Атаковать реформаторов и умеренных на пленуме КПК";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Реформаторы так просто не сдадутся!";
				}
				if (GlobalScript.inst.gameState.data[1] >= 700 && GlobalScript.inst.gameState.data[90] != 0)
				{
					fake_text[2] = "Заручиться поддержкой части умеренных и атаковать реформаторов на пленуме";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Умеренные не пойдут с нами на соглашение";
				}
				fake_text[3] = "Арестовать лидеров реформаторов и начать кампанию против их сторонников. Всё по заветам Мао!";
			}
			else if (GlobalScript.inst.gameState.number_event == 71)
			{
				kolvo_variant = 3;
				fake_text[0] = "Пусть продолжают партизанить, нам этого пока достаточно";
				if (GlobalScript.inst.gameState.influencePRC >= 100 && GlobalScript.inst.gameState.allcountries[19].Torg)
				{
					fake_text[1] = "Добиться включения наксалитов в местные органы власти в обмен на прекращение вооружённой борьбы";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Они не станут с нами договариваться";
				}
				if (!GlobalScript.inst.gameState.allcountries[19].Torg && GlobalScript.inst.gameState.war == 0 && !GlobalScript.inst.gameState.allcountries[15].cw)
				{
					fake_text[2] = "Готовьтесь к войне. Ввести войска.";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Мы не для того налаживали отношения, чтобы сейчас развязывать войну!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 72)
			{
				kolvo_variant = 3;
				fake_text[0] = "Удачи им и хорошего настроения";
				if (GlobalScript.inst.gameState.data[91] == 1)
				{
					fake_text[1] = "Оказать помощь левому крылу (-6 агентов, -10 из бюджета)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Джаната нас не послушает";
				}
				if (GlobalScript.inst.gameState.data[91] == 1)
				{
					fake_text[2] = "Оказать помощь правому крылу (-6 агентов, -10 из бюджета)";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Джаната нас не послушает";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 73)
			{
				kolvo_variant = 4;
				fake_text[0] = "Война - это ад";
				galka_stuk[1].SetActive(value: false);
				fake_text[1] = "Война, война никогда не меняется";
				galka_stuk[2].SetActive(value: false);
				fake_text[2] = "Война - это мир";
				galka_stuk[3].SetActive(value: false);
				fake_text[3] = "Хочешь мира, готовься к войне";
			}
			else if (GlobalScript.inst.gameState.number_event == 74)
			{
				kolvo_variant = 5;
				if (GlobalScript.inst.gameState.data[90] == 0)
				{
					fake_text[0] = "Пленум одобряет этот вариант";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Это невозможно";
				}
				if (GlobalScript.inst.gameState.data[90] == 1)
				{
					fake_text[1] = "Пленум одобряет этот вариант";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Это невозможно";
				}
				if (GlobalScript.inst.gameState.data[90] == 2)
				{
					fake_text[2] = "Пленум одобряет этот вариант";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Это невозможно";
				}
				fake_text[3] = "Чего вы тут понаписали?! Текст отправить на доработку!";
				if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[4] = "Вопрос о \"Решении\" снимается с повестки дня по просьбе Председателя";
				}
				else
				{
					galka_stuk[4].SetActive(value: false);
					fake_text[4] = "Этот вопрос слишком важен для КПК, чтобы снимать его с повестки.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 75)
			{
				kolvo_variant = 4;
				if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[0] = "Осудим авианалет и предложим Хусейну расширить сотрудничество (-8 из бюджета).";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Саддам Хусейн - авторитарист и шовинист. Нам незачем его поддерживать!";
				}
				fake_text[1] = "А нам-то какое дело? Пускай Саддам сам разбирается...";
				if (GlobalScript.inst.gameState.data[12] >= 600 && GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[2] = "Поможем Ираку возобновить атомную программу. Пусть империализм содрогнется! (-15 из бюджета, -10 агентов)";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Ираку - атомную бомбу?! Вы развязать Третью мировую войну хотите?";
				}
				if ((GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[3] = "Одобрим авианалет и осудим Хусейна за милитаризм и шовинизм.";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Мы не можем оправдать поступок сионистов!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 76)
			{
				kolvo_variant = 4;
				if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[0] = "Дипломатически поддержим косовских сепаратистов, но не более того";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Это не наша проблема";
				}
				if (((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					fake_text[1] = "Предложим Албании свое содействие в отрыве Косово от Югославии (-5 агентов -5 из бюджета)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Зачем нам помогать Албании?";
				}
				fake_text[2] = "Не вмешиваемся";
				if (GlobalScript.inst.gameState.data[9] >= 100)
				{
					fake_text[3] = "Окажем помощь косовским сепаратистам спецслужбами и деньгами (-10 агентов -10 из бюджета)";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Дела Югославии нас не интересуют";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 77)
			{
				kolvo_variant = 3;
				if (((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[9] >= 80)
				{
					fake_text[0] = "Помочь Шеху организовать переворот (-8 агентов)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "У нас не хватит ресурсов";
				}
				fake_text[1] = "Пусть они сами разбираются";
				if (GlobalScript.inst.gameState.allcountries[20].proprc || (GlobalScript.inst.gameState.allcountries[20].econ && GlobalScript.inst.gameState.data[60] == 0))
				{
					fake_text[2] = "Поддержать Ходжу";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Зачем нам поддерживать Ходжу после того, как он от нас отвернулся?";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 78)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.data[22] >= 80 && ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Спровоцировать волнения и поддержать маоистов (-10 агентов, -8 сила армии)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Оно не стоит наших сил";
				}
				fake_text[1] = "Нас это не касается";
				if (GlobalScript.inst.gameState.data[6] < 800 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[2] = "Поздравить Маркоса после его победы и попытаться наладить сотрудничество";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Нам не нужно сотрудничество с американскими марионетками";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 79)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.empires[1].relations > 500 && GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[0] = "Призвать соцлагерь совместными силами помочь Румынии (-10 из бюджета)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Соцлагерь не будет нас слушать";
				}
				fake_text[1] = "Сам набрал долгов - пусть сам и выплачивает";
				if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Оказать материальную помощь Румынии (-30 из бюджета)";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Румыния не стоит таких трат";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 80)
			{
				kolvo_variant = 3;
				if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[0] = "Никакого \"культа личности\" упоминать не будем и проведем съезд мирно.";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Пора сказать партии правду!";
				}
				if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || GlobalScript.inst.gameState.data[15] > 7)
				{
					fake_text[1] = "Вскользь упомянем об \"отдельных ошибках\" Мао, под предлогом борьбы с которыми начнем осторожный отход от него.";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Никакой критики Мао!";
				}
				if ((GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Задействуем опыт Хрущева - там получилось, и у нас получится!";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Вы с ума сошли - действовать, как Хрущев?!!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 81)
			{
				kolvo_variant = 5;
				if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0) || (GlobalScript.inst.gameState.data[56] == 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[0] = "Окажем Венгрии эк. помощь без предварительных условий (-35 из бюджета)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Мы не настолько богаты, чтобы спонсировать кадаристов";
				}
				if (GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[1] = "Используем проблемы ВНР для дискредитации рыночных реформ";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Пример Венгрии - не доказательство провала реформ";
				}
				if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Предложим ВНР эк. помощь, но в обмен на реабилитацию группы Биску (-15 из бюджета, -8 Агентов)";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Вряд ли это нам на пользу";
				}
				if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[3] = "Всеми силами поддержим реабилитацию группы Биску в обмен на принятие на себя венгерского госдолга (-45 Денег, -10 Агентов)";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Это слишком радикально для нас!";
				}
				fake_text[4] = "Проигнорируем это";
				if (GlobalScript.inst.dlc[6] && GlobalScript.inst.gameState.resultOfEvents[46] == 4)
				{
					kolvo_variant = 6;
					if (GlobalScript.inst.gameState.data[9] >= 80)
					{
						fake_text[5] = "Через дипведомства договориться с частью Политбюро на погашение кредита в обмен на избрание Пожгая Генеральным секретарём (-45 Денег)";
					}
					else
					{
						galka_stuk[5].SetActive(value: false);
						fake_text[5] = "У нас не хватит сил";
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 82)
			{
				kolvo_variant = 1;
				fake_text[0] = "Кто победит - военный режим Аргентины или ослабленная и далёкая Британия?";
			}
			else if (GlobalScript.inst.gameState.number_event == 83)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Организуем утечку информации в ЦК КПСС и дискредитируем Кулакова. (-5 Агентов)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Это слишком опасно!";
				}
				if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[1] = "Опубликуем разоблачительные материалы о Кулакове в наших СМИ. (-2 Денег)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам это ни к чему";
				}
				fake_text[2] = "Прибережем это на будущее...";
			}
			else if (GlobalScript.inst.gameState.number_event == 84)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.data[9] >= 80 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Автомобильная катастрофа - выбор профессионалов! (-8 Агентов)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Это слишком опасно!";
				}
				fake_text[1] = "Выходим на контакт с белорусскими партийцами и через них передаем Суслову компромат на Машерова. (-5 Денег)";
				fake_text[2] = "Оставим его в покое.";
			}
			else if (GlobalScript.inst.gameState.number_event == 85)
			{
				kolvo_variant = 4;
				if (GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Используем все усилия для дискредитации Кунаева, как только в республике начнутся беспорядки. (-10 Агентов)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Это слишком опасно!";
				}
				if (GlobalScript.inst.gameState.relres && ((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[1] = "Упредим его и предупредим о готовящихся провокациях ЦК КПСС. (-3 Агентa)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "У нас недостаточно хорошие отношения с Брежневым, чтобы сообщить ему об этом";
				}
				fake_text[2] = "Дела Советов нас не волнуют.";
				if (GlobalScript.inst.gameState.relres)
				{
					fake_text[3] = "Наши журналисты от имени нашего посольства проведут расследование деятельности Рашидова под видом репортажа по искусствам Узбекистана. (-3 агентов, -3 денег)";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Никто не выдаст нам разрешения.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 86)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Поможем главе КГБ уйти в мир иной, списав это на отказ почек. КГБ УССР справится. (-10 Агентов, -5 Денег)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Это слишком опасно!";
				}
				if (GlobalScript.inst.gameState.relres)
				{
					fake_text[1] = "Суслов и Щербицкий созывают Пленум ЦК и атакуют на нем Андропова при нашей информационной поддержке. (-7 Денег)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит влияния на КПСС";
				}
				fake_text[2] = "Это слишком опасно!";
			}
			else if (GlobalScript.inst.gameState.number_event == 87)
			{
				kolvo_variant = 1;
				fake_text[0] = "Ещё одна война на Ближнем Востоке...";
			}
			else if (GlobalScript.inst.gameState.number_event == 88)
			{
				kolvo_variant = 2;
				fake_text[0] = "Поздравим Мугабе с победой и вышлем ему материальную помощь (-5 из бюджета)";
				fake_text[1] = "Подружиться с ним мы всегда успеем";
			}
			else if (GlobalScript.inst.gameState.number_event == 89)
			{
				kolvo_variant = 4;
				if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.empires[1].leaders[3].support > 0))
				{
					fake_text[0] = "Поддержать Андропова";
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[3].support <= 0)
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Нам не хватит влияния на КПСС";
				}
				if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.empires[1].leaders[1].support != 0))
				{
					fake_text[1] = "Поддержать Щербицкого";
				}
				else if (GlobalScript.inst.gameState.empires[1].leaders[1].support == 0)
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит влияния на КПСС";
				}
				if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100))
				{
					fake_text[2] = "Поддержать Черненко";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Нам не хватит влияния на КПСС";
				}
				fake_text[3] = "Не вмешиваться и ждать";
			}
			else if (GlobalScript.inst.gameState.number_event == 90)
			{
				kolvo_variant = 4;
				if (GlobalScript.inst.gameState.data[9] >= 40 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Договоримся с Триадами на выгодных для них условиях. (-4 Агентов)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Мы не можем вести переговоры с ОПГ!";
				}
				if (GlobalScript.inst.gameState.data[9] >= 30 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[1] = "Тактический союз с синдикатами нам не помешает. Но от чистки это их не спасет. (-2 Агентов)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Никаких компромиссов с преступным миром!";
				}
				fake_text[2] = "Какое нам дело до этих бандитов?";
				if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[16] <= 13 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[3] = "По организованной преступности в южных провинциях страны пора нанести мощный удар! (-8 Агентов)";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Это - вполне честные бизнесмены, поддерживающие реформы и открытость. Мы не имеем права их в чем-то подозревать.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 91)
			{
				kolvo_variant = 3;
				fake_text[0] = "Осудить северокорейский терроризм";
				fake_text[1] = "Осудить южнокорейскую провокацию";
				fake_text[2] = "Промолчать";
			}
			else if (GlobalScript.inst.gameState.number_event == 92)
			{
				kolvo_variant = 5;
				fake_text[0] = "Инвестировать в модернизацию промышленности (-1 из бюджета)";
				fake_text[1] = "Продолжить усиленную механизацию сельского хозяйства (-1 из бюджета)";
				fake_text[2] = "Вложить средства в улучшение качества услуг (-1 из бюджета)";
				fake_text[3] = "Ориентировать пятилетку на развитие научных разработок (-1 из бюджета)";
				fake_text[4] = "Направить силы на равномерное развитие экономики (-1 из бюджета)";
			}
			else if (GlobalScript.inst.gameState.number_event == 93)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.data[9] >= 40)
				{
					fake_text[0] = "Поддержать ПАСОК";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Нам не хватит сил";
				}
				if (GlobalScript.inst.gameState.data[9] >= 40)
				{
					fake_text[1] = "Поддержать Новую демократию";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит сил";
				}
				fake_text[2] = "Не вмешиваться";
			}
			else if (GlobalScript.inst.gameState.number_event == 94)
			{
				kolvo_variant = 4;
				fake_text[0] = "Это контрреволюционный мятеж, и предатели за него ответят! Соедините меня с Генштабом...";
				fake_text[1] = "Блокировать площадь Народной милицией и попытаться уговорить митингующих разойтись.";
				fake_text[2] = "Уйти в отставку. Пусть Партия сама решит, кто достоин возглавить страну в это сложное время.";
				fake_text[3] = "Выполнить требования митингующих.";
			}
			else if (GlobalScript.inst.gameState.number_event == 95)
			{
				kolvo_variant = 4;
				fake_text[0] = "Отказываемся от марксизма-маоизма-сяопизма в пользу еврокоммунизма, по образцу КПЯ.";
				fake_text[1] = "Возвращаемся к социал-демократии с китайской спецификой по заветам Чэнь Дусю.";
				fake_text[2] = "Принимаем левый китайский национализм, как завещал великий Сунь Ятсен.";
				fake_text[3] = "Почему это мы должны выполнять требования каких-то уличных хулиганов?";
			}
			else if (GlobalScript.inst.gameState.number_event == 96)
			{
				kolvo_variant = 4;
				fake_text[0] = "Готовим свободные выборы в ВСНП, максимально ограничив другие партии, но другие требования придётся выполнить";
				fake_text[1] = "Не так страшны выборы, как буржуазные \"свободы\". Обойдутся без них.";
				fake_text[2] = "Не так страшны выборы, как оставить религию без присмотра. Обойдутся без неё.";
				fake_text[3] = "Если мы хотим, чтобы народ нас любил, надо выполнить все его требования!";
			}
			else if (GlobalScript.inst.gameState.number_event == 97)
			{
				kolvo_variant = 2;
				fake_text[0] = "Начинаем масштабное внедрение автоматизированных систем";
				fake_text[1] = "Спешка никогда хорошо не заканчивалась, пусть внедряют постепенно и не всё сразу";
			}
			else if (GlobalScript.inst.gameState.number_event == 98)
			{
				if (!GlobalScript.inst.dlc[3])
				{
					kolvo_variant = 3;
				}
				else
				{
					kolvo_variant = 4;
				}
				if (!GlobalScript.inst.gameState.allcountries[51].Torg)
				{
					fake_text[0] = "Признать действующую власть и отправить послов.";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Мы не можем поддерживать узурпаторов!";
				}
				fake_text[1] = "Проигнорировать военный переворот.";
				if (GlobalScript.inst.gameState.influencePRC >= 100 && GlobalScript.inst.gameState.data[9] >= 30)
				{
					fake_text[2] = "Предложить гуманитарную помощь.";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Нам не хватит ресурсов и влияния";
				}
				if (GlobalScript.inst.gameState.data[9] >= 70 && GlobalScript.inst.gameState.modifies[41].active)
				{
					fake_text[3] = string.Format(GlobalScript.inst.new_events_text[1288], GlobalScript.inst.new_events_text[592], GlobalScript.inst.new_events_text[593], GlobalScript.inst.new_events_text[594]);
				}
				else if (!GlobalScript.inst.gameState.modifies[41].active)
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = string.Format(GlobalScript.inst.new_events_text[1289], 7f);
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = string.Format(GlobalScript.inst.new_events_text[567], 7f);
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 114)
			{
				kolvo_variant = 1;
				fake_text[0] = "Мы все затаились в ожидании...";
				if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[2] == 2)
				{
					kolvo_variant = 2;
					fake_text[0] = "Картер \ud83e\udecf";
					fake_text[1] = "Рейган \ud83d\udc18";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 117)
			{
				kolvo_variant = 3;
				if (!GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[0] = "Ничего. Нас в конце концов не приглашали";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Надо ехать";
				}
				if (GlobalScript.inst.gameState.relres || GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[1] = "Послать китайскую делегацию на похороны";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нас никто туда не пустит";
				}
				if (GlobalScript.inst.gameState.relres || GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[2] = "Наш лидер лично отправится попрощаться с Юрием Владимировичем";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Вы не можете ехать лично!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 99)
			{
				kolvo_variant = 4;
				if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Окажем помощь ортодоксам, в борьбе против ревизионизма";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "У нас не хватит сил";
				}
				if (GlobalScript.inst.gameState.data[9] >= 40)
				{
					fake_text[1] = "Поддержим умеренных реформаторов в модернизации социализма";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "У нас не хватит сил";
				}
				if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] >= 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[2] = "Способствовать приходу к власти прозападных либералов";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Мы не можем их поддержать";
				}
				fake_text[3] = "Останемся в стороне";
			}
			else if (GlobalScript.inst.gameState.number_event == 100)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.influencePRC >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[0] = "Спровоцировать антиправительственные митинги, поддержав оппозицию";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "У нас не хватит сил";
				}
				fake_text[1] = "У нас и своих проблем полно.";
				if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Отправить средства в поддержку правительства.";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Мы не можем их поддержать";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 102)
			{
				kolvo_variant = 4;
				if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
				{
					fake_text[0] = "Поддержать Горбачёва";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "Нам не хватит влияния на КПСС";
				}
				if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
				{
					fake_text[1] = "Поддержать Романова";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Нам не хватит влияния на КПСС";
				}
				if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
				{
					fake_text[2] = "Поддержать Гришина";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Нам не хватит влияния на КПСС";
				}
				fake_text[3] = "Не вмешиваться и ждать";
			}
			else if (GlobalScript.inst.gameState.number_event == 104)
			{
				kolvo_variant = 3;
				fake_text[0] = "Отправить делегацию на фестиваль";
				fake_text[1] = "Не отправлять";
				fake_text[2] = "Провести собственный фестиваль для союзных стран (-2 из бюджета)";
			}
			else if (GlobalScript.inst.gameState.number_event == 105)
			{
				kolvo_variant = 3;
				fake_text[0] = "Ничего не делать";
				if ((GlobalScript.inst.gameState.allcountries[15].Torg || GlobalScript.inst.gameState.allcountries[20].Torg) && GlobalScript.inst.gameState.data[9] >= 60)
				{
					fake_text[1] = "Завербовать группу косовских албанцев и устроить теракт (-6 агентурных сетей)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Наша разведка не справится с этим";
				}
				if (!GlobalScript.inst.gameState.allcountries[20].Torg && !GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					fake_text[2] = "Попытаться наладить отношения с новым руководством (-3 из бюджета)";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Китайско-албанские отношения и так в норме";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 106)
			{
				kolvo_variant = 3;
				fake_text[0] = "Нас это не касается";
				if (GlobalScript.inst.gameState.data[9] >= 100)
				{
					fake_text[1] = "Устроить теракт и сорвать конференцию";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Наша разведка не справится с этим";
				}
				fake_text[2] = "Поддержать формирование";
			}
			else if (GlobalScript.inst.gameState.number_event == 109)
			{
				kolvo_variant = 3;
				fake_text[0] = "Ничего не делать";
				if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.influencePRC >= 200)
				{
					fake_text[1] = "Отправить военную и гуманитарную помощь Сомали (-8 из бюджета, -5 агентурных сетей, -5 сила армии)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Мы не можем помочь Сомали";
				}
				if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.influencePRC >= 200)
				{
					fake_text[2] = "Организовать партийный переворот против Барре (-8 агентурных сетей)";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "У нас нет сил отвлекаться на это";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 110)
			{
				kolvo_variant = 4;
				fake_text[0] = "Подождём ещё пару годков... или больше...";
				fake_text[1] = "Объявить о курсе на автоматизацию производства и создать комиссию по её внедрению (-10 из бюджета)";
				if (GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[1].isSEV)
				{
					fake_text[2] = "Начать автоматизацию и пригласить советских учёных";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Советы не станут нам помогать";
				}
				if (GlobalScript.inst.gameState.empires[0].relations >= 600 && GlobalScript.inst.gameState.data[6] <= 800 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.modifies[17].active)
				{
					fake_text[3] = "Принимаемся за работу, западные специалисты нам помогут!";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Просить помощи у Запада? Вы серьёзно?";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 111)
			{
				kolvo_variant = 4;
				fake_text[0] = "Отказаться от борьбы и уйти в отставку";
				if (GlobalScript.inst.gameState.data[3] >= 900 && GlobalScript.inst.gameState.data[5] >= 900 && GlobalScript.inst.gameState.modifies[3].active)
				{
					fake_text[1] = "Призвать народные массы на борьбу с партократией";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Народу не нужна новая культурная революция!";
				}
				if (GlobalScript.inst.gameState.data[9] >= 400)
				{
					fake_text[2] = "Арестовать заговорщиков и начать гонения против самых инициативных партократов (-40 агентурных сетей)";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "МГБ не поддержит нас!";
				}
				if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[3] = "Мобилизовать лояльных офицеров против заговорщиков";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Офицеры не спасут нас";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 112)
			{
				kolvo_variant = 3;
				fake_text[0] = "Выделить средства на разработку системы защиты (-25 из бюджета)";
				if (GlobalScript.inst.gameState.empires[1].relations >= 800 && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.modifies[3].active)
				{
					fake_text[1] = "Профинансировать разработку и запросить помощь специалистов из СССР (-25 из бюджета)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Советы не станут нам помогать";
				}
				if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[2] = "Похоже,  Китай не готов к таким переменам, необходимо замедлить автоматизацию";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Мы не можем отказываться от наших достижений!";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 113)
			{
				kolvo_variant = 5;
				fake_text[0] = "Какое нам дело до Югославии? Пусть титоисты сами разбираются со своими проблемами!";
				if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[1] = "Предложим Югославии реструктуризацию её долгов при условии отказа от плана реформ (-5 агентов, -20 из бюджета).";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Зачем нам реструктуризировать их долги?";
				}
				if (((GlobalScript.inst.gameState.influencePRC >= 150 && GlobalScript.inst.gameState.allcountries[1].isSEV) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.influencePRC >= 250)) && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[2] = "Присоединимся к предложению СССР.";
				}
				else
				{
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "У нас недостаточно влияния, чтобы Советский Союз и Югославия прислушались к нам";
				}
				if (GlobalScript.inst.gameState.influencePRC >= 300 && GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[3] = "Поддержим группу военных во главе с Велько Кадиевичем и Бранко Мамулой";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Поддержать военную хунту? В Югославии-то? Нонсенс!";
				}
				if ((GlobalScript.inst.gameState.influencePRC >= 200 || GlobalScript.inst.gameState.allcountries[51].dev > 0) && GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] >= 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
				{
					fake_text[4] = "Одобрим предложение США.";
				}
				else
				{
					galka_stuk[4].SetActive(value: false);
					fake_text[4] = "У нас недостаточно влияния, чтобы США и Югославия прислушались к нам";
				}
				if (GlobalScript.inst.dlc[6])
				{
					kolvo_variant = 6;
					if (GlobalScript.inst.gameState.influencePRC >= 300 && GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 200)
					{
						fake_text[5] = "Предложить выкуп долговых обязательств с частичным погашением в обмен на допуск китайских инвестиций на льготных условиях в экономику";
					}
					else
					{
						galka_stuk[5].SetActive(value: false);
						fake_text[5] = "Мы недостаточно сильны";
					}
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 115)
			{
				kolvo_variant = 3;
				fake_text[0] = "Это не наше дело";
				if ((GlobalScript.inst.gameState.data[56] >= 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
				{
					fake_text[1] = "Пойти на соглашение с наркоторговцами (-1 агентурная сеть)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Китайский народ не для того боролся с опиумными магнатами, чтобы мы с ними якшались.";
				}
				fake_text[2] = "Помочь союзным странам в борьбе против наркоторговцев (-2 агентурные сети, -2 сила армии)";
			}
			else if (GlobalScript.inst.gameState.number_event == 435)
			{
				kolvo_variant = 3;
				fake_text[2] = GlobalScript.inst.new_events_text[1651];
				if (GlobalScript.inst.gameState.data[9] >= 10 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 50)
				{
					fake_text[0] = GlobalScript.inst.new_events_text[1649];
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = GlobalScript.inst.new_events_text[1652];
				}
				fake_text[1] = GlobalScript.inst.new_events_text[1650];
			}
			else if (GlobalScript.inst.gameState.number_event == 436)
			{
				kolvo_variant = 3;
				fake_text[0] = GlobalScript.inst.new_events_text[1658];
				fake_text[1] = GlobalScript.inst.new_events_text[1659];
				fake_text[2] = GlobalScript.inst.new_events_text[1660];
			}
			else if (GlobalScript.inst.gameState.number_event == 116)
			{
				kolvo_variant = 3;
				fake_text[0] = "Оставим всё как есть";
				if (GlobalScript.inst.gameState.data[6] <= 500 && GlobalScript.inst.gameState.empires[0].relations >= 600)
				{
					fake_text[1] = "Время для долгожданного объединения!";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Они не готовы пойти на такое соглашение";
				}
				fake_text[2] = "Взаимно признаем друг друга и покончим с враждой!";
			}
			else if (GlobalScript.inst.gameState.number_event == 103)
			{
				kolvo_variant = 3;
				if (GlobalScript.inst.gameState.allcountries[1].okb && GlobalScript.inst.gameState.allcountries[0].isEU)
				{
					fake_text[0] = "Учредить аналог Шенгенского соглашения для членов нашего военного альянса (стоит дешевле)";
				}
				else if (GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.allcountries[0].isEU)
				{
					fake_text[0] = "Учредить аналог Мадридского соглашения для членов нашего военного альянса (стоит дешевле)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "У нас нет военного альянса";
				}
				if (GlobalScript.inst.gameState.allcountries[0].isEU)
				{
					fake_text[1] = "Учредить аналог Шенгенского соглашения для членов всех наших альянсов";
				}
				else
				{
					fake_text[1] = "Учредить аналог Шенгенского соглашения для членов всех наших альянсов";
				}
				fake_text[2] = "Ничего не делать";
			}
			else if (GlobalScript.inst.gameState.number_event == 107)
			{
				kolvo_variant = 5;
				int num18 = (GlobalScript.inst.gameState.data[21] - 1976) * 2 + 1;
				if (GlobalScript.inst.gameState.data[22] >= num18 * 10 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
				{
					fake_text[0] = $"Ввести войска и вернуть страну к нашему курсу ({num18} сила армии, -3 из бюджета)";
				}
				else
				{
					galka_stuk[0].SetActive(value: false);
					fake_text[0] = "У нашей армии не хватит сил и полномочий";
				}
				if (GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
				{
					fake_text[1] = "Организовать переворот в пользу лояльных нам сил (-10 агентов, -3 из бюджета)";
				}
				else if (GlobalScript.inst.gameState.data[9] >= 200 && !GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
				{
					fake_text[1] = "Организовать переворот в пользу лояльных нам сил (-20 агентов, -6 из бюджета)";
				}
				else
				{
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "Наша разведка не справится с этим";
				}
				fake_text[2] = "Привязать страну экономически, выделив финансовую помощь и выгодный кредит (-10 из бюджета)";
				if (GlobalScript.inst.gameState.data[9] >= 50)
				{
					fake_text[3] = "Не препятствовать независимой политике в обмен на сохранение членства в нашем блоке (-5 агентов, -1 из бюджета)";
				}
				else
				{
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "Наша разведка не справится с этим";
				}
				fake_text[4] = "Мы должны уважать их выбор";
			}
			else
			{
				kolvo_variant = 1;
				fake_text[0] = "Не готов ответ";
			}
			for (int l = 0; l < 6; l++)
			{
				if (l < kolvo_variant)
				{
					otveti[l].text = Text(fake_text[l], 55);
				}
				else if (galka_stuk[l] != null)
				{
					galka_stuk[l].SetActive(value: false);
					UnityEngine.Object.Destroy(otveti[l]);
				}
			}
			PlayersCoopButtons();
		}
		else if (nazad)
		{
			Azkaban();
		}
		else if (first && GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			int coopRes = GetCoopRes();
			if (coopRes >= 0)
			{
				GlobalScript.inst.gameState.number_otvet = coopRes + 1;
				for (int m = 0; m < GlobalScript.inst.gameState.eventVariantsPlayerFor.Length; m++)
				{
					GlobalScript.inst.gameState.eventVariantsPlayerFor[m] = -1;
				}
				SceneManager.LoadScene("Results");
			}
		}
		else if (first && this_otvet != 0)
		{
			GlobalScript.inst.gameState.number_otvet = this_otvet;
			SceneManager.LoadScene("Results");
		}
	}

	private void Azkaban()
	{
		this_otvet = 0;
		if (nazad)
		{
			Vpered.GetComponent<doneventscript>().this_otvet = 0;
			Vpered.GetComponent<doneventscript>().first = false;
			Vpered.GetComponent<SpriteRenderer>().sprite = nenavel;
			GetComponent<SpriteRenderer>().sprite = nenavel;
		}
		Nazad.SetActive(value: false);
		Galkasum.SetActive(value: false);
		GalkaCoop.SetActive(value: false);
		string text = "";
		string text2 = "";
		if (GlobalScript.inst.gameState.number_event >= 120 && GlobalScript.inst.gameState.number_event != 435 && GlobalScript.inst.gameState.number_event != 436)
		{
			thisObject.GetComponent<EventsSecond>().TextOfEvents(ref text2, ref text);
		}
		else if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.number_event == 3)
			{
				text2 = "掌舵者逝世";
				text = "发生了极其悲惨的事情。\n9月9日0时10分，经过两次转危为安的心脏病发作，\n在他83岁高龄，中国人民伟大领袖和导师毛泽东主席逝世。\n只要全国人民和全党都在悲痛，我们就需要召开治丧委员会，\n决定如何护送主席走完他最后的旅程。";
			}
			else if (GlobalScript.inst.gameState.number_event == 4)
			{
				text2 = "Conspiracy";
				text = "根据最近收到的情报，几位对你统治不满的高级党内人士已达成共识，\n准备在下一次中央委员会会议上罢免你。\n若不想重演1964年那位修正主义的赫鲁晓夫的下场，\n你必须立刻采取行动。";
			}
			else if (GlobalScript.inst.gameState.number_event == 5)
			{
				text2 = "群众不满";
				text = "由于对你的政策不满，民众在全国范围内举行群众集会，\n并开始在广场搭建帐篷营地、散发传单，\n甚至冲击地方政府机关。\n不同的抗议群体对你政府的不满点各不相同，\n但他们都要求对制度进行民主化，以便能够限制你在中国政治中的影\n响。";
			}
			else if (GlobalScript.inst.gameState.number_event == 6)
			{
				text2 = "生活水平偏低";
				text = "你的政策导致全国生活水平急剧崩塌，人民生活在令人作呕的境况中，\n绝大多数连最基本的生活必需品都买不起。\n当然，这就引发了大量抗议，人们要求解决这一局面。\n考虑到士兵们对这种极其恶劣的羁押条件同样不满，\n我们不能指望军队。";
			}
			else if (GlobalScript.inst.gameState.number_event == 7)
			{
				if (GlobalScript.inst.gameState.modifies[17].active)
				{
					GlobalScript.inst.gameState.IsBankAccountFreezed = true;
				}
				text2 = "外交危机";
				text = "我们同美国的关系已降到极其危险的低点。\n他们的宣传已经把中国指控为一切可能与不可能的罪行，\n而我们的情报也报告了五角大楼内部的动荡以及美国在东南亚基地的\n活动。若不想爆发第三次世界大战，我们必须尽快设法扭转局势。";
			}
			else if (GlobalScript.inst.gameState.number_event == 8)
			{
				text2 = "外交危机";
				text = "我们同苏联的关系已降到极其危险的低点。\n他们的宣传已经把中国指控为一切可能与不可能的罪行，\n而我们的情报也报告了苏联总参谋部的动荡以及边境苏军的调动。\n若不想爆发第三次世界大战，我们必须尽快设法扭转局势。";
			}
			else if (GlobalScript.inst.gameState.number_event == 9)
			{
				text2 = "西藏分裂主义";
				text = "Encouraged by liberals and nationalists, residents of the Tibet Autonomous Region took to mass demonstrations for independence and secession from the PRC, which gradually develop into unrest. People demand \"liberation\" from \"the occupation of 1950\" and the majority of ethnic Tibetans support them. However, some are just satisfied with the requirements of greater autonomy than we can take advantage of.";
			}
			else if (GlobalScript.inst.gameState.number_event == 10)
			{
				text2 = "新疆分裂主义";
				text = "Encouraged by liberals and nationalists, residents of the Xinjiang Uygur Autonomous Region took to mass demonstrations for independence and secession from the PRC, which gradually develop into unrest. People demand \"liberation\" from \"the occupation of 1949\" and the majority of ethnic Uighurs support them. However, there is a counterweight to them from the Hanzu, and some of the Uighurs are just satisfied with the requirements of greater autonomy than we can take advantage of.";
			}
			else if (GlobalScript.inst.gameState.number_event == 11)
			{
				text2 = "工业衰退";
				text = "我们的工业正陷入前所未有的衰退——有些工厂停工，\n有些工厂即将关闭，而所有人都在使用落后的设备在干活。";
			}
			else if (GlobalScript.inst.gameState.number_event == 12)
			{
				text2 = "农业衰退";
				text = "我们的农业也陷入前所未有的衰退——即便在大跃进时期也从未出现\n过如此的混乱！";
			}
			else if (GlobalScript.inst.gameState.number_event == 13)
			{
				text2 = "服务业衰退";
				text = "我们的服务业陷入惨重衰退——大多数商店和机构都停摆，\n而仍在运转的那些，其服务质量简直糟透了。";
			}
			else if (GlobalScript.inst.gameState.number_event == 14)
			{
				text2 = "我们没钱，但你们要挺住！";
				text = "我们的预算和储备金太少。\n若继续这样下去，我们很快就无法维持国家的正常运转。";
			}
			else if (GlobalScript.inst.gameState.number_event == 15)
			{
				text2 = "柬越战争";
				text = "在数年间统治民主柬埔寨的波尔布特红色高棉，\n对邻国越南奉行公然的侵略政策，经常袭击边境村庄并大规模屠杀平\n民。看来越南的忍耐也到头了——就在不久前，\n越南军队对柬埔寨发动了全面入侵，以推翻波尔布特政权，\n并以由高棉左派异议人士组成的柬埔寨民族救国阵线作为掩护。\n鉴于波尔布特一直是我们忠实的盟友，帮助他似乎是值得的。\n另一方面，也许可以考虑用更“讲道理”的柬埔寨军方军官来替换这\n位张狂的独裁者。当然，这并不会停止战争，\n但把目标锁定为推翻波尔布特的越南将陷入困境。";
			}
			else if (GlobalScript.inst.gameState.number_event == 16)
			{
				text2 = "泰国选举";
				text = "After the fall of the military junta in 1973 and the transfer of power to the civilian government, Thailand entered the period of \"chaotic democracy\". The victories of the communist forces throughout Indochina contribute to the growth of leftist sentiments, led by the Maoist Communist Party of Thailand, which is engaged in both partisan and legal activities. They are opposed by the right-wing military, landowners and other royalists, which often leads to clashes. Under these conditions, against the backdrop of the outbreak of the crisis of the Thai economy, the democratic Prime Minister Kukrit Pramoj is forced to hold early elections. Maybe this is our chance, if not to lure away, then at least destabilize the bastion of imperialism in Indochina?";
			}
			else if (GlobalScript.inst.gameState.number_event == 17)
			{
				text2 = "泰国局势不稳";
				text = "在社会不稳定以及左右势力持续对峙的背景下，\n泰国王室在9月决定组织把激进右翼将领、\n该国前总理坦农·基蒂卡宗（因1973年的公开演说而被推翻，\n并对血腥镇压负有责任）遣返回国。\n基蒂卡宗本人并不想回到政治舞台，反而希望出家修行，\n但他回国的官方宣布以及他与国王的会面，\n引发了社会中一部分人对右翼的不满。\n普拉莫吉总理辞职，但这一辞职遭到否决；\n一波又一波学生与工会的示威浪潮席卷而来，\n其中一场正在进行的地点是法政大学，而右翼武装分子已经在对那里\n进行突袭。根据我们的情报，军方正在准备对这次示威进行残酷镇压。";
			}
			else if (GlobalScript.inst.gameState.number_event == 18)
			{
				if (GlobalScript.inst.gameState.data[82] > 7)
				{
					text2 = "战争结束了";
					text = "After long and bloody battles, the conflict named \"" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].name_war + "的冲突终于结束了。\n外交部已经把一切安排妥当，现在准备向你快速汇报战争的结果。";
				}
				else
				{
					text2 = "战争结束了";
					text = "After a long and bloody fighting conflict \"" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].name_war + "\"" + "终于告终。";
					text = ((GlobalScript.inst.gameState.data[82] == 6) ? ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 400) ? (text + "最终胜利者是" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + "一方，他们在战争中达成了目标。") : (text + "最终胜利者是" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 + "一方，他们在战争中达成了目标。")) : ((GlobalScript.inst.gameState.data[82] == 2) ? ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 750) ? (text + "最终胜利者是" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + "一方，他们在战争中达成了目标。") : (text + "最终胜利者是" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 + "一方，他们在战争中达成了目标。")) : ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 900 && GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 < 900) ? ((GlobalScript.inst.gameState.data[82] != 2 && GlobalScript.inst.gameState.data[82] != 4) ? (text + "双方都未取得决定性胜利，于是签署了白色停战协议，\n使边界恢复到战前状态。") : (text + "最终胜利者是" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + "一方，他们在战争中达成了目标。")) : (text + "最终胜利者是" + ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 > GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2) ? GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 : GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2) + "一方，他们在战争中达成了目标。"))));
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 19)
			{
				text2 = "Five \"no\"";
				text = "Congratulations on your appointment to the post of Premier of the State Council of the People's Republic of China, 同志Hua Guofeng. As you know, your predecessor was Zhou Enlai, who gained popularity and respect among the people at home and abroad for his honesty and administrative talents. However, he was also an active promoter of economic reforms and promoted reformers in the party, such as his protege Deng Xiaoping. For these reasons, the death of Zhou on January 8, 1976 caused great grief among the people, which dissatisfied Mao and the leadership of the CCP, who reacted very reservedly to his death. Rumor has it Mao Zedong himself set the campaign of Five \"no\" in motion — not to wear mourning bands, not to make wreaths, not to make memorials, not to hold memorial ceremonies and not to hang photos of Zhou Enlai — yet no one is sure, since Mao is now barely reachable because of his bad legs and overall health, and decisions have to be made quickly with no time to wait. And you, as a new prime minister, can influence its execution.";
			}
			else if (GlobalScript.inst.gameState.number_event == 20)
			{
				text2 = "批邓反右！";
				text = "The death of Zhou Enlai seriously affected the position of his protege Deng Xiaoping, who was left without the patronage of the former prime minister. He is now under constant attack by the radicals headed by Mao Zedong’s wife Jiang Qing, and on February 2, Xiaoping was transferred to work in the field of external relations. With the permission of Mao Jiang and her supporters, they managed to launch a campaign \"Criticize Deng and fight with right\" and begin an active persecution of Deng in the media. It is noteworthy that although Mao treats Xiaoping with disbelief, he is not yet participating in his persecution. And what should we do, given that Hua Guofeng has never been on good terms with either Jiang Qing or Xiaoping?";
			}
			else if (GlobalScript.inst.gameState.number_event == 21)
			{
				text2 = "关于周的神秘文章";
				text = "1976年3月25日，上海报纸《文汇报》刊登一篇文章，\n称一位未具名的“周”为“资本主义道路的当权派”。\n有人把它视为对周恩来的身后打击，也有人说矛头指向周荣鑫；\n而邓的“走资本主义道路”则把“恩来谣言”煽得更旺，\n以激起公众的悲愤。文章由上海市委书记张春桥下令刊发，\n同时也对邓及其改革主张进行鞭挞。\n群众还不清楚究竟是哪一位周遭到攻击，\n但情绪正在升温——我们必须决定如何应对。";
			}
			else if (GlobalScript.inst.gameState.number_event == 22)
			{
				text2 = "天安门事件";
				text = "中共多次试图抹黑已故周恩来，结果只引起了群众的不满。\n4月4日，传统的清明纪念日，首都北京的市民携带花圈，\n向天安门广场人民英雄纪念碑缅怀周恩来。\n天黑前约有200万人到访广场，花圈堆成的“山”高达20米。\n就在此时，在毛泽东主持下，中共中央政治局紧急会议召开。\n江青和张春桥主张先通过广播对群众说话，\n把吊唁者与挑衅者分开，必要时再动用武力。\n汪东兴正努力尽量避免暴力。\n责任落在你和北京市市长汪东兴身上——我们将选择哪条路线？";
			}
			else if (GlobalScript.inst.gameState.number_event == 23)
			{
				text2 = "唐山地震";
				text = "7月28日，河北省唐山市在当地时间03:42发生里氏8.2级\n地震，致使全城几乎被夷为平地。\n天津以及位于西面仅140公里的北京也遭到破坏。\n数次余震接连发生，其中最强达7.1级，\n造成更大的伤亡。据初步数据，死亡人数在20万至60万之间。\n上海市地震局负责人张军认为，造成巨大破坏的主要原因是建设过程\n中缺乏必要的抗震防护措施。";
			}
			else if (GlobalScript.inst.gameState.number_event == 24)
			{
				text2 = "变革的风？";
				text = "After 毛泽东逝世, and you finally concentrated power in your hands, it is time to determine the future path of China, because every faction of the CCP sees it in its own way. Conservative Maoists are in favor of continuing Mao’s policies, but without questionable experiments, which means the end of the 文化大革命 and campaigning. The reformers, of course, are in favor of ending the 文化大革命 and large-scale reforms primarily in the economy, in order to improve the Chinese economy after Mao’s failed attempts to intervene in her work. All moderates believe that China needs change, but some will need an end to the 文化大革命 and a small economic reorganization, while others join the reformers demanding deep market reforms. However, the radical Maoists are in no hurry to part with the idea of ??the 文化大革命 and want to continue it, taking into account errors and excesses.";
			}
			else if (GlobalScript.inst.gameState.number_event == 25)
			{
				text2 = "四人帮";
				text = "Now that our Chairman, Mao Zedong, has passed away, the internal party struggle again flared up in the CCP. On the one hand, there are four closest to the Great Helmsman supporters of the line on the continuation of the 文化大革命, but with a course on normalizing relations with the USSR: Jiang Qing is Mao’s spouse and the head of the 文化大革命 Group of the CPC Central Committee, Wang Hongwen is a prominent member, at the tenth party congress, he was actually declared the successor to Mao, Zhang Chunqiao and Yao Wenyuan. On the other hand, the reformers, who are gaining strength, led by the disgraced ideologist of the half-market reforms of the early 70s, Deng Xiaoping, who are in favor of the earliest possible withdrawal of the 文化大革命 and the beginning of large-scale market reforms with the unchanged anti-Soviet course. Moreover, it is the left radicals who are currently the greatest threat to our government, but to neutralize them, it will be necessary to ally with reformers such as Secretary of Defense Ye Jianying. Maybe it's better to negotiate with them and use them to fight reformers?";
			}
			else if (GlobalScript.inst.gameState.number_event == 26)
			{
				text2 = "弱联盟";
				text = "华国锋与激进左派之间那种摇摇欲坠的妥协，\n已经在裂缝里崩开。许多更温和的党内成员对这份协议的直率不满，\n极大削弱了现任主席的地位；他在处理这些问题时的“温和”，\n又可能引发难以预料的后果。\n更何况“四人帮”要求对党内反对派和“修正主义者”采取更果断的\n措施，同时进一步扩大他们的权力，以继续沿着毛的路线前进。\n若继续这样下去，华国锋就不得不越来越多地把权力交给左边。\n汪东兴——8341特种团的负责人，仍对主席忠心耿耿，\n依然准备协助对他们的斗争。\n不过，考虑到左派力量增强，且依靠10月的妥协，\n或许最好的办法是只拿掉最野心勃勃的江青和王洪文，\n而对其余人保留协议？";
			}
			else if (GlobalScript.inst.gameState.number_event == 1)
			{
				text2 = "选举、选举、候选人是……";
				text = "全国人大选举的日子到了。\n既然我们在中国政治中占据主导地位，我们可以在他们的行动上稍加\n干预，让一切照旧。或者就干脆依靠中国人民对我们的信任。";
			}
			else if (GlobalScript.inst.gameState.number_event == 27)
			{
				text2 = "香港和澳门的命运";
				text = "For a long time, the Chinese territories of Hong Kong and Macao were under British and Portuguese colonial control. However, the fascist regime of the \"Estado Novo\" in Portugal was overthrown in 1974, the 99-year lease of Britain adjacent to Hong Kong of the 新领土 is coming to an end, and both countries are under pressure from the 1960 UN Decolonization Declaration, so they are ready to go Compromise, and this is our chance to return what is rightfully ours. Of course, they will never voluntarily hand over the colonies if they are not convinced of the inviolability of the property of their own and foreign citizens, but also try to achieve wide autonomy for the territories of China.";
			}
			else if (GlobalScript.inst.gameState.number_event == 28)
			{
				text2 = "The end of the 亚洲的皮诺切特";
				text = "1965年夺取印尼政权的苏哈托中将，\n立即开始摧毁他的政治对手，尤其是共产党。\n仅在1965—66年间，就有约300万人因“同情共产党”之名\n被杀害。民族少数同样遭殃，包括仍在法律上受到歧视的华人。\n苏哈托的高压统治靠美国支持以及与东南亚国家的有利经济往来维持。\n然而如今我们已把印尼与其大多数伙伴切断，\n使其经济崩溃；国内正爆发积极的抗议运动。\n尽管许多抗议打着左派口号，但显然还不足以引发社会主义革命。";
			}
			else if (GlobalScript.inst.gameState.number_event == 29)
			{
				text2 = "中国帝国主义";
				text = "长期以来，朝鲜民主主义人民共和国一直在背离马克思列宁主义，\n用带有神秘主义与传统主义色彩的“主体思想”取而代之，\n并塑造金日成的个人崇拜。\n与此同时，这一切都伴随着对金日成政治对手的周期性镇压。\n朝鲜经济高度依赖同中国的联系与我们的援助，\n因此我们最近的制裁对它是沉重打击。\n因而我们可以向朝鲜政府提出某些让步要求。\n只是别忘了，苏联也在向朝鲜提供援助……";
			}
			else if (GlobalScript.inst.gameState.number_event == 30)
			{
				text2 = "冲突的终结？";
				text = "自1948年以原英国托管巴勒斯坦领土建立以色列以来，\n当地阿拉伯人口实际上被剥夺了自决权，\n并遭到以色列当局的歧视；他们为摧毁以色列、\n在巴勒斯坦建立阿拉伯国家而斗争，并得到周边阿拉伯国家的支持。\n由此引发了数次阿以战争；巴勒斯坦解放组织对以色列的持续炮击与\n恐怖袭击，以及以色列军队的反击突袭。\n最后一次发生在黎巴嫩，彻底失败，甚至连美国的支持都未获得；\n如今以色列准备就巴勒斯坦人的地位与巴解组织谈判，\n而我们可以充当中间人。";
			}
			else if (GlobalScript.inst.gameState.number_event == 31)
			{
				text2 = "正确的民主";
				text = "光州起义在我们的支持下外溢到周边地区，\n给韩国政府的声誉造成巨大损害；而我们对其经济的近期打击又引发\n了新一轮抗议浪潮。在压力之下，郑斗焕同意举行自由总统选举，\n甚至允许两位著名反对派领袖——金大中和金泳三参选；\n其中金大中尤其对朝鲜民主主义人民共和国持更为温和的立场。\n只要确保他在选举中获胜，并对朝鲜施压，\n我们就能把韩国引向久盼的统一。";
			}
			else if (GlobalScript.inst.gameState.number_event == 32)
			{
				text2 = "乌兰巴托之春？";
				text = "借助我们对蒙古的介入，大规模抗议开始了，\n要求改革，并摆脱一味严守的亲苏政策。\n为了避免重演捷克斯洛伐克的事态、避免苏军入境，\n蒙古人民共和国似乎愿意作出一些让步，\n并进行有限的民主化——类似匈牙利的卡达尔。\n我们可以利用这一点，把亲华人士引入蒙古的政治与媒体，\n从而让他们拥有更……\n独立的外交政策。";
			}
			else if (GlobalScript.inst.gameState.number_event == 33)
			{
				text2 = "眼中的新月";
				text = "祖尔菲卡尔·阿里·布托自1971年起任巴基斯坦总统，\n自1973年起任总理。\n布托奉行伊斯兰社会主义路线，这体现在广泛的社会计划以及对经济\n许多部门的国有化。在外交上，他坚持反帝主义，\n努力同邻国建立友好关系，退出亲美的东南亚条约组织（SEATO）\n和大英联邦，并在第三次印巴战争后成功实现了与印度的缓和。\n然而，1977年3月布托的“巴基斯坦人民党”赢得选举后，\n反对派指控他舞弊，并发起抗议；而布托对抗议进行严厉镇压。\n军方对此并不买账——由穆罕默德·齐亚-乌尔-哈克将军领导，\n并得到美国支持的军方，正在准备军事政变。\n只要阻止它，并为布托建设社会主义提供物质援助，\n我们就能在巴基斯坦牢固巩固我们的立场。";
			}
			else if (GlobalScript.inst.gameState.number_event == 34)
			{
				text2 = "我敌人的敌人";
				text = "After the defeat of the 四人帮, power nominally passed to you, but in fact you have to share it with those who helped you get it - with Minister of Defense Ye Jianying, a staunch reformer who defended Xiaoping during the 文化大革命, and Li Xiannian, more moderate, but also supporting reformers. On the other hand, there are three of your most loyal conservative supporters — Ji Denkui, Wang Dongxing, and Chen Xilian. If you want not to be stoped, you should strike at the reformers and promote your supporters, however, would such arbitrariness cause discontent in the party and would you rather restrict yourself to one of the two? On the other hand, if you are focused on reforms, it will probably be more useful to negotiate with reformers. Although who knows if they will want...";
			}
			else if (GlobalScript.inst.gameState.number_event == 35)
			{
				text2 = "革命的终结";
				text = "After the death of Mao, you took the course of curtailing the 文化大革命, and achieved certain results in this - mass campaigns are no longer observed. However, the repressive grip of the state since the time of 文化大革命 has not yet weakened, and the reformers, together with the people, are now demanding to \"unscrew the nuts\". In addition to civic liberalization, many consider it necessary to also ease the pressure on traditions and religion, which increased many times during the 文化大革命. Some advocate only for the cessation of anti-traditionalist rhetoric with the preservation of state atheism, others propose, according to the Soviet model, to declare nominal freedom of conscience while keeping religious institutions and figures under strict state control. You decide.";
			}
			else if (GlobalScript.inst.gameState.number_event == 36)
			{
				text2 = "联盟崩溃？";
				text = "自1968年以来，在伊拉克“伊拉克进步民族爱国阵线”的框架下，\n执政的阿拉伯复兴社会党与伊拉克共产党之间建立了脆弱的合作关\n系。1972年5月，尽管共产党仍处于非正式地位，\n但其两名代表被正式纳入政府。\n然而，这种合作很快就昙花一现。\n最近，伊拉克复兴党领导层又一次开始对共产党人施加镇压，\n但仍有空间维持一种脆弱的同盟。\n也许我们应该以某种方式介入局势？";
			}
			else if (GlobalScript.inst.gameState.number_event == 37)
			{
				text2 = "埃及帕夏的终结";
				text = "Since 1970, Egypt has been headed by Anwar Sadat. Immediately after he came to power, he began a departure from the policy of Gamal Abdel Nasser and the ideas of pan-Arabism and Arab socialism - during the so-called. \"Corrective Revolution\" almost all Nasser’s associates were arrested, including Vice President Ali Sabri (a supporter of friendship with the USSR and the Communists), in 1971 the United Arab Republic was renamed the Arab Republic of Egypt, which meant a break with the course on pan-Arab integration . And in 1973 began the rapprochement of Egypt with the United States, which was accompanied by a rise in anti-Soviet sentiment and a break with Libya and Syria. In 1975, Sadat attempted to destabilize the ruling Arab Socialist Union (ASU), and this year - an unprecedented case - began negotiations to restore relations with Israel! Liberalization of the economy and the penetration of Egyptian foreign capital into the market led to widespread discontent among the general population, and the war with the once fraternal Libya finally undermined Sadat’s authority. Mass rallies flooded the whole country, demanding the resignation of the president. We can take advantage of this and achieve the return to power of supporters of the socialist course. The USSR and the fraternal Arab countries clearly will not object, but the reaction of the United States will not be so warm...";
			}
			else if (GlobalScript.inst.gameState.number_event == 38)
			{
				text2 = "回归根源";
				text = "20世纪60年代初，为应对“大跃进”的毁灭性后果，\n在中华人民共和国境内，由邓小平和周恩来领导，\n启动了大规模的“自主管理”式经济改革，\n并允许土地私有承包，最终导致中央计划被拆解。\n毛并未干预他们的行动，因为他担心中共多数派的不满——他们仍记\n得大跃进的失败，并且也意识到当时这样做的必要性。\n然而如今大跃进早已远去，也许此刻重新恢复计划，\n会让我们的经济达到新的水平？\n另一方面，改革派仍认为经济还需要进一步改革，\n并希望把它继续推进。";
			}
			else if (GlobalScript.inst.gameState.number_event == 39)
			{
				text2 = "Commission on \"Solution...\"";
				text = "The death of 同志Mao Zedong, the beginning of the inner-party struggle in the CCP and our refusal to continue the course of the so-called \"The Great Proletarian 文化大革命\" caused a strong ferment inside the party. According to the Ministry of Public Security, ideas about the \"wrongness of the ideas of Mao\", \"the fallacy of the CCP’s course\", \"the distortion by Mao Zedong and his surroundings of the history of the country and the party\" and so on are beginning to spread in some party organizations. This runs the risk of splitting the Communist Party and completely eradicating all the successes of China’s socialist development. The Politburo of the CPC Central Committee decided to begin work on a document that will give an official assessment of the entire path that the PRC and the CPC passed under the leadership of Mao Zedong since 1949, for which they form a commission of 50 people. However, it is necessary to decide who will head it, and determine the approximate composition. Remember that your decision will have far-reaching consequences and may lead to a revision of the entire ideological line of the CCP.";
			}
			else if (GlobalScript.inst.gameState.number_event == 40)
			{
				text2 = "班禅喇嘛的命运";
				text = "同志Chairman, a letter from a large group of Tibetan clergy has come to the Central Committee in which they urge you to consider releasing 10th Panchen Lama from prison (Panchen Lama is the second lama after the Dalai Lama in the Gelug school of Tibetan Buddhism - note MSS ). Lobsang Trinley Lhundrub Chokyi Gyaltsen, aka 10th Panchen-Lama, refused to flee with the Kuomintang people to Taiwan in September 1949 and supported the formation of the PRC, later playing an important role in reuniting Tibet with our Motherland. However, he then sharply condemned the Chineseization of the Tibet Autonomous Region, for which he was declared \"the enemy of the Tibetan people\" in 1964, arrested and imprisoned in the Beijing Tsingcheng prison, where he currently resides. We can free him, thereby significantly improving relations with Tibetan monks and the population of the autonomy. But does it make sense? Maybe it is better to eliminate the unreliable lama and get our protege Gyaltsen Norbu elected as Panchen-Lama?";
			}
			else if (GlobalScript.inst.gameState.number_event == 41)
			{
				text2 = "印度选举";
				text = "自1966年以来担任印度总理的、印度国民大会党（INC）\n领袖英迪拉·甘地，在执政期间在社会经济领域推行积极的左翼改革，\n甚至引发了INC分裂以及右翼势力退出。\n她执政期间在经济与反贫困方面取得了相当成效，\n但自1971年以来印度国内实行的紧急状态，\n却正好为来自“人民党”（Janat party）\n的反对派提供了武器；该党指控甘地腐败、\n任人唯亲与专制。基于这些条件，甘地决定组织提前举行议会选举。\n考虑到甘地一贯奉行亲苏、对中华人民共和国不友好的政策，\n并且还与我们友好的巴基斯坦发生冲突——只是最近才在这些问题上\n缓和——那么反对派若获胜，是否会增强我们的影响力？\n人民党把从社会主义者到保守派的不同观点的人团结在一起，\n并没有连贯的纲领，但这也许更便于我们操控。\n只是，如果我们帮助英迪拉，她会记得这份情吗，\n并继续朝着修复我们关系的方向走下去……？";
			}
			else if (GlobalScript.inst.gameState.number_event == 42)
			{
				text2 = "伊朗革命";
				text = "一段时间以来，在“沙阿伊朗”境内爆发抗议，\n矛头指向民众艰难的社会经济处境、沙阿的亲美政策、\n执政精英的猖獗腐败，以及国家对什叶派宗教人士的压迫。\n然而今天，抗议进入了白热化阶段：在库姆，\n警方对反政府示威开枪；这又是由一篇诽谤霍梅尼（什叶派伊斯兰最\n高宗教头衔“阿亚图拉”的称号）的文章引发的——霍梅尼是抗议的\n精神领袖，1964年被驱逐出境。\n此后，伊朗多座城市爆发抗议与罢工。\n诸如“争取自由伊朗运动”和“斗争宗教人士协会”等伊斯兰主义运\n动，是即将到来的革命的推动力量；但也有其他组织在推动推翻沙阿，\n其中最大的包括伊朗民主民族阵线和伊朗马列主义人民党。\n伊朗革命可能会剧烈改变中东力量格局——也许我们该介入？";
			}
			else if (GlobalScript.inst.gameState.number_event == 43)
			{
				text2 = "经互会扩展";
				text = "长期以来，越南试图在我们与苏联之间保持平衡：\n尽管我们与苏联存在分歧，但我们的志愿军曾在对印支的战争中与苏\n方并肩，站在社会主义越南一边作战。\n然而随着战争结束与国家统一，越南逐渐越来越亲苏，\n越来越远离我们。|";
				text = ((GlobalScript.inst.gameState.allcountries[23].Gosstroy == 0 && !GlobalScript.inst.gameState.allcountries[23].EAF) ? (text + "1977年黎德寿赴莫斯科之后，越南与苏联的进一步靠拢开始了，\n前景是加入经互会（CMEA），而他打算“日复一日”地加入。\n我们显然无法阻止这一点，至少因为越南希望争取苏联支持，\n以对付亲华柬埔寨境内的波尔布特。") : (text + "1977年黎德寿赴莫斯科之后，越南与苏联的进一步靠拢开始了，\n前景是加入经互会（CMEA），而他打算“日复一日”地加入。\n然而，国家领导层中的一部分人反对这种对苏联过于热烈的靠拢，\n因为对越南并不存在特殊威胁——尤其是在亚洲、\n波尔布特在柬埔寨被推翻之后。\n于是，这就是我们介入并阻止苏联霸权扩散的机会。"));
			}
			else if (GlobalScript.inst.gameState.number_event == 44)
			{
				text2 = "不管黑猫白猫，抓到老鼠就是好猫……";
				text = "Your desire to pursue a conservative policy that is completely inconsistent with the diminishing strength of your supporters eventually led to widespread dissatisfaction of the CPC’s reformist wing, supported by the moderates. They want your removal from power and require the start of extensive market reforms with the attraction of foreign investment and China's access to the world market, arguing that \"the economy should prevail over the ideology\". That is what their leader  " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2] + "在中共中央委员会现阶段的全体会议上对你说的，\n而在场多数人也表示赞同。\n若你不想丢掉权力，就必须做点什么！";
			}
			else if (GlobalScript.inst.gameState.number_event == 45)
			{
				text2 = "改革开放：开端";
				text = "在宣布市场改革路线之后，我们的经济学家制定了第一轮改革方案，\n并最终提交给中共领导层以供批准。\n方案包括：赋予部分国有企业更大的自主权；\n在其运作中引入市场化方法；并推动小型私营与合作制企业的发展。";
			}
			else if (GlobalScript.inst.gameState.number_event == 46)
			{
				text2 = "新的 1956？";
				text = "Interesting news came from Hungary. Bela Biszku, a conservative communist who actively participated in the suppression of the Hungarian uprising in 1956 and was the Minister of the Interior from 1957 to 1961, and now secretary of the HSWP, always opposed Kadar's economic and political liberal reforms. Realizing that words couldn’t stop him, he made a group of similar conservatives around himself and decided to organize an inner-party coup, asking for support from the head of the KGB, 尤里·安德罗波夫. However, according to our data, Andropov simply \"betrayed\" Biszku's plans to Kadar, which Biszku himself doesn’t know yet. Now we have a chance to help Biszku with our agents and return Hungary to the path of building true socialism. Or you can always try to raise a new uprising in Hungary with the help of small arms supplies and intelligence coordination - this time truly communist and pro-Chinese - then Hungary is guaranteed to be ours! But we must act quickly.";
			}
			else if (GlobalScript.inst.gameState.number_event == 47)
			{
				text2 = "北京之春";
				text = "From the middle of this year, the stormy activity of students and intellectuals began throughout the country, especially in Beijing, which hangs big-character poster (wall newspapers with large hieroglyphs used for propaganda and protest) in the streets and publishes self-made magazines. Big-character poster and the journals oppose the CPC's conservatism, criticize the 文化大革命, call for economic and political liberalization, and express support for the reformers in the CPC, which NAME actively uses. Moreover, in 1977, the reformers themselves actively published in their journals and newspapers under their control critique of our policies, saying that it \"does not agree with Marxism\" that \"the economy should prevail over ideology\" and that \"pragmatism is the only criterion for revealing the truth\", describing the practical advantages of market reforms in their vision.";
			}
			else if (GlobalScript.inst.gameState.number_event == 63)
			{
				text2 = "四月革命";
				text = "紧急消息！4月27日，阿富汗因政权不稳、\n人民贫困与不满——在逮捕左翼反对党PDPA领导人之后——发生\n了此前由PDPA预先策划的军事政变。\n广大民众欢迎这场革命。\nPDPA在努尔·穆罕默德·塔拉基领导下上台后，\n开始建设社会主义，并转向苏联。\n然而，阿富汗的前途仍不明朗：因为PDPA内部仍存在压倒性的“\n喀尔克派”与“帕尔查姆派”分裂——这两派实际上在1966至1\n977年间就作为两个独立政党存在。\n喀尔克派主要由低收入与半无产阶级群体构成，\n在反对活动中侧重非法工作，主张革命斗争；\n如今则试图迅速把国家转向社会主义与无产阶级专政。\n帕尔查姆派在反对时期优先进行合法与议会斗争，\n如今主张渐进的、普遍的民主改革，并总体倾向改革主义，\n认为阿富汗尚不具备建设社会主义的条件。\n与此同时，中共对苏联势力在该地区的扩张深感忧虑。";
			}
			else if (GlobalScript.inst.gameState.number_event == 48)
			{
				text2 = "政变仍在继续";
				text = "After the 四月革命, the PDPA faced many difficulties, and in the rapidly gaining strength of the Khalq party, the struggle between one of the PDDP founders Taraki and his student Amin had already begun. Amin is a supporter of radical politics, an uncompromising struggle against feudal remnants and the harsh suppression of political opponents. At the same time, he, being an ardent Pashtun (the dominant people of Afghanistan - note) nationalist, is largely responsible for sabotaging the national policy of the PDPA and, trying to concentrate power in his own hands, he maintained a split between Khalq and Parcham. Despite the fact that the Soviet leadership repeatedly warned Taraki about Amin's conspiratorial plans, he did not heed until the very last moment. On September 14, during the visit of Amin to Taraki, the first one was attacked (it is not known exactly whether it was real or staged by Amin himself), and on September 16, Amin at the plenum of the People's Democratic Party Central Committee removed Taraki from his duties, having previously isolated him with loyal army units in the residence. It is noteworthy that, although Amin tried to maintain good relations with the USSR, according to our data, he is not at all opposed to establishing close relations with the PRC, and this may be our chance.";
			}
			else if (GlobalScript.inst.gameState.number_event == 49)
			{
				text2 = "反对一切暴君";
				text = "在最近阿明发动政变之后，苏联方面千方百计寻找办法，\n消灭这位粗心的篡权者。\n根据我们的情报，苏联领导层已经同来自PDPA各派的成员建立了\n联系，例如卡尔迈勒、萨尔瓦里和瓦坦贾尔等人——他们因阿明的清\n洗而逃离阿富汗，并准备被用来替代阿明。\n该计划的关键在于：由苏联特种部队对阿明及其忠诚随从进行“中和\n”，而掩护则由苏联军队提供。\n自年初以来，尽管苏联方面不断拒绝，PDPA与阿明本人仍一再坚\n持要求苏军入境。然而看来，在形势压力之下，\n苏联领导层决定改变方案：12月25日，\n第一批苏联部队就已越过边境，任务是保护重要军事设施以及苏阿合\n作的相关目标。现在是我们在阿富汗夺取主动权的机会——如果有可\n能阻止阿明被取代的话。\n不过这只能在同苏联保持良好关系的前提下才能做到，\n否则苏联就会撞上“砖墙”，但也不会把阿富汗交给我们。";
			}
			else if (GlobalScript.inst.gameState.number_event == 50)
			{
				text2 = "诅咒之山，荒野之隅……";
				text = "在最近那些导致阿富汗局势恶化的事件之后，\n长期以来由美国支持的伊斯兰主义者与其他反动势力的起义已进入白\n热化阶段。根据最近通过的计划，苏联应阿富汗民主共和国政府的请\n求向阿富汗派遣军队；这已经在西方引发一波愤慨。\n尽管当地民众起初对苏军相当友好，但对其进行武装袭击的事件日益\n增多。同时，最初仅包括保护重要目标的有限兵力，\n其任务正在逐步扩大，似乎最终将全面卷入战事。\n争夺阿富汗的战斗已经开始，我们必须决定在其中支持谁。";
			}
			else if (GlobalScript.inst.gameState.number_event == 51)
			{
				text2 = "先顶住，然后撤……";
				text = "After the 四月革命, the PDPA faced many difficulties associated with a lack of experience among its members and an abundance of feudal and religious remnants in Afghanistan, however, due to the relative equality of forces between the two factions of PDPA, it was possible to avoid major political conflicts. In particular, the members of both Parcham and Khalq, with the support of the USSR, succeeded in removing Amin from the government and the Central Committee with accusations of violating the principles of collective leadership and Pashtun nationalism. However, the uprisings of the reactionary groups, especially the Islamists, which began at the beginning of the year, are gaining momentum. Some citizens of Pakistan and Iran are joining them, illegally crossing the border, and even the USA manage to somehow drag their weapons and advisers to Afghanistan to help the mujaheddin. Under these conditions, the USSR, at the numerous requests of the Afghan leadership, decided to introduce a small contingent of its troops, which would have to guard important military installations and cities, freeing the forces of the DRA army to fight the rebels. It seems that their large-scale participation in hostilities is not expected, but the West has already condemned it, calling it an invasion.";
			}
			else if (GlobalScript.inst.gameState.number_event == 52)
			{
				text2 = "难缠的邻居";
				text = "From the very beginning of anti-government demonstrations in Afghanistan and the response of the DRA government, many Islamic radicals, terrorists and priests fled to Pakistan, where they teamed up with their local \"colleagues\". Subsequently, after the start of armed riots in Afghanistan, refugees flowed into Pakistan, who were awaited by Islamic terrorist organizations that had formed there. Pakistan itself does not take special measures in relation to them beyond the usual, it seems that Bhutto has enough problems there, but it may be worthwhile to provide him with undercover assistance in order to stop such outrages? On the other hand, the United States is very interested in the possibility of helping the Afghan rebels through Pakistan, and if Bhutto can not agree with the United States in any way, then he could with us. By transporting American weapons and advisers through Pakistan, we could \"cut\" money from Americans and strike at Soviet social-imperialism.";
			}
			else if (GlobalScript.inst.gameState.number_event == 53)
			{
				text2 = "农业改革";
				text = "大跃进期间，几乎全国农业都被组织进农业公社——以对器材和私人\n财物的彻底社会化、土法炼钢的失败实验以及令人作呕的生产率而闻\n名。周恩来改革之后，公社被部分改造、\n部分解散，但在改良版里仍继续运转。\n中共内部不少人认为该改革农业了，但并无共识。\n温和派和改革派主张推行家庭联产承包制，\n意味着在农村培育家庭经营，同时实行强制性的公购。\n另一部分改革派则主张引入“真正的私有耕作”制度。\n我们不得不为创业者拨出贷款，用于必要的采购，\n但改革派保证这些成本在短期内就会回本。\n还有一部分党内人士提议回到“基本路线”，\n按苏联模式组织集体农场体系，以便克服技术落后——因为斯大林不\n是做到了吗？事实是，所需的机械化要钱……";
			}
			else if (GlobalScript.inst.gameState.number_event == 54)
			{
				text2 = "改革开放：投资";
				text = "在既定方针下推进改革开放政策，我们需要吸引外资。\n改革派主张在沿海设立若干个经济特区：\n减税、国家控制尽量少、对外资的其他“放宽”，\n让他们在此建厂并投资合资项目。\n然而，除了设立自由经济区之外，更激进的领导人还主张通过建立合\n资企业制度，把经济全面向外资开放——由外国以分得利润的方式投\n资我们的国有企业。第二种方案的盈利性更高是显而易见的，\n但温和派，甚至一些改革派也批评其过于仓促。";
			}
			else if (GlobalScript.inst.gameState.number_event == 55)
			{
				text2 = "缅甸式通往社会主义的道路";
				text = "After the military coup in 1962, the government in Burma passed over to Ne Win and the Burma Socialist Programme Party headed by him, proclaiming the construction of \"Burmese socialism\". However, this \"socialism\" was characterized by the preservation of the private sector, the cultivation of chauvinistic religious and national prejudices, in fact, a departure to isolation, as well as mass repressions of all opponents of Ne Win. Therefore, the various left-wing forces that had fallen into the party after the start of the open mass recruitment in 1971, began to increasingly oppose Ne Win and his policies. According to our data, mass purges are being prepared in the Burma Socialist Programme Party against the communists and other leftists, and if we had already made contact with Burma, we could change the balance of forces in their favor with the help of our special services. However, we can also provide additional assistance to the leadership of Burma and strengthen our relationship.";
			}
			else if (GlobalScript.inst.gameState.number_event == 56)
			{
				text2 = "要不要给越南一个教训？";
				text = "Recently, neighboring Vietnam is increasingly moving closer to the USSR, and this despite our help in the civil war! In this regard, more and more party members believe that you need to \"teach Vietnam a lesson\". The plan that has been developed by the PLA for some time is simple - under the pretext of occasional clashes at the border, we declare war on it, seize the border areas, destroy the arriving units of the Vietnamese army and move as far as possible into the interior. Such a blow would force their leadership to seriously reconsider its policy towards the PRC and the USSR. However, some of the party members believe that if our relations with Vietnam are not yet so spoiled, then it makes sense to reach an agreement with him, settling our territorial claims and persuading to stop oppressing ethnic Chinese in Vietnam. However, you can do nothing, because a thin world is better than a good war, right?";
			}
			else if (GlobalScript.inst.gameState.number_event == 57)
			{
				text2 = "红日东升";
				text = "日本很快将举行众议院选举。\n鉴于政府不稳和腐败丑闻的背景，日本共产党近年来稳步增势，\n形形色色的中间偏左反对派也同样如此。\n如果我们能对日本共产党施加影响，就可以帮助他们竞选。\n万一他们获胜，我们就能改善同这位历史对手的关系，\n并最终把美国基地赶出日本。";
			}
			else if (GlobalScript.inst.gameState.number_event == 58)
			{
				text2 = "伊朗革命：终局";
				text = "去年一整年，抗议活动席卷伊朗——左翼、\n世俗民主派以及不同程度激进的穆斯林组织，\n都在言行上反对沙阿的权威，组织了多次罢工与罢课。\n|";
			}
			else if (GlobalScript.inst.gameState.number_event == 59)
			{
				text2 = "经济联盟";
				text = "同志主席！鉴于当前国际局势，若干党内成员提议组织我们自己的替\n代方案：对标苏联的经济联盟——经互会（CMEA）\n以及欧洲的共同体（EEC），以继续扩大我们影响的政策，\n并加深与北京忠诚国家之间的贸易与经济联系。\n然而，政治局有些成员认为此举过于仓促、\n过于激进、也过于欠考虑，建议把这件事推迟到更好的时机。\n尽管也许最好的选择是忘掉同苏联的一切纷争，\n加入经互会？";
			}
			else if (GlobalScript.inst.gameState.number_event == 60)
			{
				text2 = "军事联盟";
				text = "在我们经济联盟“顺利成立”之后，部分党内成员提议通过把所有友\n好国家联合成单一军事同盟来巩固成果，\n从而占据一个被欧洲北约和苏联华约军事基地包围的“空档”。\n然而，最务实的党内人士则主张放弃这一倡议，\n理由是我们轻率而激进的行动可能引发新一轮冷战——而且还会多出\n第三个有影响力的力量。\n可中国现在前所未有地强大，多出来的盟友也不会妨碍它，\n对吧？";
			}
			else if (GlobalScript.inst.gameState.number_event == 61)
			{
				text2 = "国歌问题";
				text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "! As you know, the anthem of our country since 1949 has been the \"March of the Volunteers\" Nie Er and Tian Han. However, during the so-called \"文化大革命\" Tian Han was arrested on a false accusation and died in prison, and the popular song \"The East Is Red\", glorifying the late President Mao Zedong, became the de facto anthem. Now, when we stopped the \"文化大革命\" and posthumously rehabilitated Tian Han, as well as normalized the situation in the country, the question arose about state symbols. A large group of party members propose to restore the \"March of the Volunteers\" as an anthem already officially, however, your associates, in principle agreeing with this, believe that the text of the hymn should be changed by adding references to 主席Mao and the CPC. True for both of these options will need money for conversion. At the same time, the radical Maoists remaining in the party wrote to you with a letter in which they proposed to give the status of the hymn \"The East Is Red\"...";
			}
			else if (GlobalScript.inst.gameState.number_event == 62)
			{
				text2 = "成吉思汗的继承者们的问题";
				text = "After the victory over the Kuomintang in 1949, the regions of China inhabited by non-Chinese people gained autonomous status, modeled on the USSR. One of them is Inner Mongolia, where ethnic Mongols live. During the so-called \"文化大革命\" central authorities began to assimilate the Mongolian population by force, which resulted in mass clashes with the Red Guards and the riots of 1967-1969. In 1969, most of the territory of Inner Mongolia was attached to neighboring Chinese provinces in such a way that the number of Mongols in it fell to 600 thousand people and the total population of the autonomous region fell from 13 to 9 million people. Now that the CPC has recognized the fallacy of this policy, representatives of the Council of People’s Representatives of the AR of Inner Mongolia and the Mongols-communists propose to correct Mao’s mistake and restore justice by returning the lands taken from it to AR and ending the assimilation policy. This is clearly not going to please the left wing of the CPC, but it can help to enlist the support of national elites. In addition, the Mongolian People's Republic and the USSR will obviously like this step.";
			}
			else if (GlobalScript.inst.gameState.number_event == 64)
			{
				text2 = "Pan-Arabism";
				text = "The ideas of creating a united state of all Arabs in the Middle East have been in the minds of Arab rulers and intellectuals since the days of the colonial rule of foreigners in these lands. It was reflected in the United Arab Republic, which consisted of Syria and Egypt and existed from 1958 to 1971, however, due to the striving of Egyptian President Nasser, a well-known pan-Arabist, to centralize power in Egypt, Syria withdrew from it in 1961. Subsequently, in 1971, a confederative Federation of Arab Republics from Egypt, Syria and Libya was created. However, there were contradictions between its participants, which consisted primarily in the liberal pro-Western policies that came to power in Egypt after Nasser Sadat. But now, when Sadat is eliminated, and in Egypt, supporters of the old president Nasser came to power, thanks to which the FAR has formally existed until now, and the ideas of merging the Arab states have re-occupied the minds of the ruling circles. Moreover, on July 30, Israel proclaimed Jerusalem \"the eternal and indivisible capital of Israel\", which caused a wave of discontent in the Arab world, giving another reason to unite against a common enemy. Having allocated some material assistance and contributed to the elimination of those dissatisfied with such a development, we could revive the UAR, which would seriously change the balance of power in the Middle East and get a valuable ally. Unless, of course, they will listen to us...";
			}
			else if (GlobalScript.inst.gameState.number_event == 65)
			{
				text2 = "再见了，我们亲爱的米什卡……";
				text = "同志Chairman! On July 19, 1980, the opening of the XXII Summer Olympic Games will take place in Moscow. The Soviet Union struggled to secure the right to host the Olympics and spent enormous funds on its preparation, which had to be withdrawn from other expense items (a large-scale campaign was held to sell Olympic symbols for cost recovery). However, the US leadership has openly declared a boycott of these Games and called on all its allies for this, organizing the so-called «Olympic Boycott Games» (better known as the \"Liberty Bell\") in Philadelphia. A number of party members urge us to follow the American example and boycott the Soviet games by sending a team to the American ones - however this will arouse the anger of the USSR and the misunderstanding of the people. Maybe you should not exacerbate the split and send our athletes to Moscow, despite the political contradictions between our countries? Sport is out of politics, isn't it...";
				if (GlobalScript.inst.gameState.is_party_enabled[0])
				{
					text += "|However, a group of party members, recalling the experience of GANEFO in 1963 (alternative Games of the \"Third World\" countries conducted by Indonesian President Sukarno with our financial aid), suggests that we revive these Games and show the USSR and the USA that we are independent from them in sports.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 66)
			{
				text2 = "而后是铁托——铁托！";
				text = "1980年1月3日，南斯拉夫社会主义联邦共和国的创建者、\n长期领导人，南斯拉夫共产党联盟中央委员会主席、\n元帅约瑟普·布罗兹·铁托在卢布尔雅那临床中心住院，\n检查其腿部血管。经过两次手术并截除左腿后，\n他的病情有所好转，但2月铁托又患上肺炎：\n高烧不退，胃、肠道和肺部出血也导致败血症，\n并在3月进一步加重。\n今天终于迎来结局——在卢布尔雅那临床中心心血管疾病诊所，\n贝尔格莱德时间15时05分，距离他88岁生日仅三天，\n约瑟普·布罗兹·铁托去世。\n葬礼将于5月8日举行，我们需要决定：\n是否有必要派代表团前往贝尔格莱德，还是只发唁电即可？\n尽管我们在意识形态上存在分歧、外交关系也有断层，\n但铁托是反法西斯战争的英雄之一，给予他“记忆的职责”是有道理\n的。苏联和美国已经宣布将派官方政府代表团出席葬礼，\n但美国总统卡特不会去贝尔格莱德……\n也许这位同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "不必亲自前往，而由权限有限的姬鹏飞同志率团即可？";
				if (GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					text += "However, our Albanian allies have already stated that, although they will be happy to restore trade and cultural ties with Yugoslavia, they will never stop criticizing \"the revisionist Tito and Titoism\". If we send a delegation, we may well push them away from us.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 67)
			{
				text2 = "波兰还没死呢？";
				text = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", alarming news comes from Warsaw - on September 6, the 6th Plenum of the Central Committee of the Polish United Workers' Party took place, which decided to resign Edward Gierek who headed the party and the country for 10 years and replace him with a compromise Stanislaw Kania. The country is now in the hardest political and economic crisis, united with the help of the CIA anti-socialist opposition, headed by the so-called \"independent self-governing trade union\" \"Solidarity\", for almost a year now, it has been organizing mass strikes, rallies, processions. The tremendous national debt (almost $ 40 billion), accumulated under the previous leadership of the country, PPR is unable to pay. The situation is clearly out of control of the PUWP, the USSR is already seriously beginning to consider the option of armed intervention in the affairs of Poland, following the example of Czechoslovakia-1968. Now, while the situation in the country is extremely unstable, we have a great opportunity to intervene and, taking advantage of Kania’s indecisiveness, to ensure that nationally oriented forces led by Albin Siwak and Kazimierz Mijal come to power in Poland. However, this will cause great dissatisfaction with the USSR and high costs, so maybe we don’t need this Poland?..";
			}
			else if (GlobalScript.inst.gameState.number_event == 68)
			{
				text2 = "光州起义";
				text = "1979年12月政变之后，春斗焕在韩国夺取政权，\n开始对反对军政府的抗议者进行无情镇压。\n5月17日宣布戒严，5月18日，光州一场反对关闭全南国立大学\n的学生示威遭军队开枪射击。\n此举在城内引发轩然大波的不满，并导致更大规模的骚乱；\n在这期间，叛乱者设法夺取了警察与军用仓库，\n并把军队单位赶出城外。\n根据我们的情报，春斗焕政府正准备由正规军夺取光州。\n只要支持叛乱者使其坚持更久，并调动我们的情报力量在邻近地区煽\n动不满，我们就能对韩国政权造成严重的动摇与不稳定。";
			}
			else if (GlobalScript.inst.gameState.number_event == 69)
			{
				text2 = "又是一个帮派？";
				text = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", thanks to your efforts, we were able to put an end to the remnants of the 文化大革命, and the country is heading towards a bright market future! However, there are still those who disagree with such a development of events and with all their might protest against the conduct of such a policy, disrupting good reforming initiatives. These are predominantly conservative Maoists, headed by four top party members who but resists further reform. By hitting them and their supporters, we could consolidate more power in the hands of the reformers. Moreover, in the places freed from conservatives, it will be possible to promote active supporters of reforms that have gained popularity among the people, and their wards.";
			}
			else if (GlobalScript.inst.gameState.number_event == 70)
			{
				text2 = "周恩来继承人的问题";
				text = "同志" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "，多亏你的努力，我们得以继续朝着毛主席所遗赠的光明共产主义未\n来前进！所有改革派企图动摇我们的制度、\n摧毁社会主义成果、把中国引向资本主义道路的尝试都失败了。\n然而，他们中的许多人仍然拥有足够影响力，\n并继续传播他们的修正主义主张，这件事必须处理。\n你支持者中最激进的那部分人建议：对修正主义者不必客气，\n直接逮捕他们的头目，并发动对改革派的运动；\n但党和人民大概不会批准这种任意妄为，\n所以你可以试着在中共的会议室里把一切解决掉。\n至于我们该如何处置温和派——毛泽东去世后他们大多支持改革派，\n但现在有些人开始犹豫不决……";
			}
			else if (GlobalScript.inst.gameState.number_event == 71)
			{
				text2 = "东方红……";
				text = "Thanks to our support, the Maoist rebels in eastern India, known as the Naxalites, gained considerable influence and some public support in the eastern states. They control large areas, and their constant attacks have become a headache, both for the eastern states and for the central government of India. Some Indian politicians are already thinking about negotiating with them, and we could use this to hold Naxalites in the local governments of the eastern states, mediating at the talks, which would greatly increase our influence on India and provide a relatively loyal left-wing policy in eastern India. This is on condition that the Naxalites and the Indian authorities start talking with us at all. Yes, and the preservation of instability in the eastern regions can give us an opportunity for a maneuver, not so now in the future... However, part of the generals and the party has already matured a plan for this maneuver - they offer to take advantage of the situation and send troops into the territory of 阿鲁纳恰尔邦 we pretend to \"protect the civilian population and restore order\", after which it will be possible without any problems to attach them to the PRC. But it will mean a new border war with India...";
			}
			else if (GlobalScript.inst.gameState.number_event == 72)
			{
				text2 = "救起溺水者";
				text = "1977年印度大选获胜后，“人民党”（Janata）\n——实际上是从社会主义者到民族自由派的各类政党组成的邦联——\n面临重重困难。它原本是为了把英迪拉·甘地及国大党（INC）\n赶下台而团结起来；但如今上台之后，人民党却陷入内部阴谋与勾心\n斗角，实际上使其工作陷于瘫痪。\n照这样下去，1980年1月即将举行的选举必然又会被甘地赢回去，\n从而终结人民党在改善我们同印度关系方面取得的成果。\n而如果我们曾经帮助过反对派，并对其施加影响，\n那么我们就可以帮助他们巩固并保住政权……";
			}
			else if (GlobalScript.inst.gameState.number_event == 73)
			{
				text2 = "伊朗—伊拉克战争";
				text = "伊朗与伊拉克的关系长期紧张，主要源于领土争端——1969年，\n伊朗夺取了1937年协议划给伊拉克的阿拉伯河口（Shatt \nal-Arab）河段；1971年，伊朗又占领了霍尔木兹海峡的\n三座岛屿，而这些岛屿同样被伊拉克声称拥有。\n可是，在伊朗爆发伊斯兰革命并取得胜利之后，\n局势进一步恶化——为了把革命传播到整个穆斯林世界，\n霍梅尼开始向伊拉克积极派遣煽动者和特工，\n并支持伊拉克库尔德人争取独立的斗争。\n对此，且又看到伊朗军队在革命与伊斯兰主义清洗中土崩瓦解，\n萨达姆·侯赛因决定入侵伊朗，以夺取盛产石油的胡齐斯坦省。\n9月22日中午前后，伊拉克军队入侵伊朗，\n遭到顽强抵抗，目前正缓慢推进于伊朗境内。";
			}
			else if (GlobalScript.inst.gameState.number_event == 74)
			{
				text2 = "关于中共历史若干问题的决议";
				text = "那么，同志主席，我们于1976年开始着手的这份重要文件工作已\n经完成。《关于中共党史若干问题的决议》终稿共计2.8万字、\n84页，并用中文、英文、俄文、阿拉伯文和西班牙文印行。\n要对人的活动、思想、历史与社会作出分析，\n揭示最复杂的一整套原因，绝非易事；但这件事终于做成了。\n中共第十一届中央委员会第六次全体会议已准备审议这份文件。";
				if (GlobalScript.inst.gameState.data[90] == 0)
				{
					text += "|In \"Decision\" the path we have followed from 1949 is fully approven and the personality of Mao Zedong is put at the forefront. This should certainly please the people - but the party, endorsing 主席Mao, is unlikely to approve the justification of his excesses...";
				}
				else if (GlobalScript.inst.gameState.data[90] == 1)
				{
					text += "|In \"Decision\" the path we have followed from 1949 is fully approven, but \"everything bad is straighten and everything good is consolidated\", and Mao Zedong is given an assessment\"70% positive на 30% negative\". This will certainly please the Party and the people...";
				}
				else if (GlobalScript.inst.gameState.data[90] == 2)
				{
					text += "|In \"Decision\" the path we have followed from 1949 is  critisized and the personality of Mao Zedong is branded. Individual members of the party will like this, however - I cannot vouch for the consequences if the Plenum approves it...";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 75)
			{
				text2 = "伊拉克原子问题";
				text = "News just came from Iraq, Israeli aviation during operation \"Opera\" struck the \"Tammuz\" reactor, bringing it down. As a result of this strike, the Iraqi atomic program ended. Saddam is now pursuing a very aggressive foreign policy which destabilizes already tense situation in the Middle East. However, we perhaps could help Iraq continue the atomic program, thereby obtaining a useful ally in this strategic region. Although I would not advise on relying on reliabilty of Saddam Husein - he is a well-known supporter of multi-vector policy, that cooperates with the United States, USSR, us and Non-Aligned Movement. It is possible that even its own atomic bomb will not change this...";
			}
			else if (GlobalScript.inst.gameState.number_event == 76)
			{
				text2 = "推倒那个跌倒的人！";
				text = "同志Chairman, urgent news from the SFRY! In the Socialist Autonomous Province of Kosovo, mass riots of the Albanian population began, according to our data, organized by the Albanian special service Sigurimi. Protesters attack administrative buildings, police stations and garrisons of the Yugoslav People’s Army, anti-Serb pogroms began. The leadership of the province and the Union of Communists of Kosovo do not offer serious resistance to the rebels, de facto supporting them. An urgent meeting of the SFRY Presidium was held in Belgrade, which decided on a forceful suppression of the \"counter-revolutionary separatist rebellion\". After the death of Tito, the situation in Yugoslavia began to deteriorate, it seems that the monster of the Versailles Treaty began to collapse. So maybe it makes sense to push him even more into the abyss?";
			}
			else if (GlobalScript.inst.gameState.number_event == 77)
			{
				text2 = "唾沫糊脸、拳头打下巴、子弹打脑袋";
				text = "Our residents pass on interesting information from Albania - it seems there has been a serious split between Albanian leader Enver Hoxha and the second person in the party and the state - Prime Minister Mehmet Shehu. For a long time, he was the closest associate of Hoxha and ensured the stability of the country by the forces of Sigurimi, personally overseeing the suppression of several reactionary uprisings in the mid-1940s and famous for the phrase: \"Who does not agree with our leading role, will get spittle in the face, a punch in the jaw, and if necessary, a bullet in the head\", which even (in a negative context) was quoted at the XXII Congress of the CPSU. However, after what happened at the background of the Khrushchev's de-Stalinization and split between Albania and the Soviet Union and the socialist camp, its economy began to experience difficulties from such isolation. In the PLA, more and more people are inclined to restore relations with the USSR, Yugoslavia and even with Italy, and apparently, Shehu is one of them, and is forced to solve urgent problems of the Albanian economy. More practical and inclined to negotiate than Hoxha, he could be a useful ally.";
				if (!GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					text += "此外，他支持同中华人民共和国结盟，显然会乐于恢复我们被切断的\n关系。";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 78)
			{
				text2 = "永远的总统";
				text = "据我们掌握的情况，菲律宾今年6月将举行首次总统选举。\n自1972年以来，该国一直处于戒严状态——由总统费迪南德·马\n科斯（Ferdinand Marcos）\n宣布，并于1981年1月由他解除。\n马科斯执政时期以猖獗的腐败、任人唯亲和侵犯人权为特征，\n导致反对派活动急剧升温；其中核心之一是菲律宾毛主义共产党（C\nPP）以及由其组建的“全国民主运动”（NDM）。\n他们长期以来一直在进行宣传，并对马科斯政权发动游击战争。\n然而，若能推行基于国家调控的有效经济改革、\n通过戒严压制反对派，并获得美国支持，\n马科斯很可能在即将到来的选举中获胜。\n但我们也有极好的机会破坏他的胜利——借助特工力量并向CPP和\nNDM提供武器，我们就能点燃针对马科斯政权以及这类“闹剧式选\n举”的大规模抗议。可这样做值得吗？\n确实，马科斯在1975年切断同台湾的关系并与中华人民共和国建\n立关系后，周恩来曾承诺中华人民共和国不会干涉菲律宾的政策；\n所以也许还是更好与马科斯合作？";
			}
			else if (GlobalScript.inst.gameState.number_event == 79)
			{
				text2 = "紧缩政策";
				text = "20世纪70年代初，罗马尼亚借助齐奥塞斯库同西方的良好关系，\n积极从国际货币基金组织（IMF）借款；\n但在70年代能源危机之后——这场危机打在罗马尼亚这个石油出口\n大国身上，并以债务把国家拖累得更深——该国经济状况迅速恶化。\n在这种条件下，1970年代后期罗马尼亚的日用消费品价格开始上\n涨；如今齐奥塞斯库决定转向“紧缩政策”，\n其含义是大幅削减进口、扩大出口，把利润用于偿还债务。\n这不可避免地导致对居民用水用电的限制，\n并在许多商品上实行配给制度，综合起来严重损害罗马尼亚的生活水\n平。齐奥塞斯库是苏联社会主义阵营中唯一仍与中国保持良好关系的\n领导人——即便在我们同苏联决裂之后也是如此——所以也许值得帮\n助他挺过这场危机？";
			}
			else if (GlobalScript.inst.gameState.number_event == 80)
			{
				text2 = "中共十二大";
				text = "The next, XII, congress of the Chinese Communist Party begins its work in the Palace of People's Assemblies in Beijing. The congress is attended by 1,600 delegates and 149 candidates for delegates, with the current number of CCPs at 39.65 million. The agenda is usual ... However, now that the VI Plenum of the 11th CPC Central Committee adopted the \"Decision on some questions of the history of the CPC since the founding of the PRC\", in which we indicated the possibility of a course for demaoisation, it may be worth a closed meeting at which to read the report \"On the cult of the personality of Mao Zedong and overcoming its consequences\", prepared in advance by a group of advisers? However, this runs the risk of undermining the CCP’s position very much - maybe it’s just worth mentioning in the Report \"correcting all the wrong \" in Mao’s activities and, under this pretext, start a cautious informal departure from Maoism? Or maybe not touch this question at all?..";
			}
			else if (GlobalScript.inst.gameState.number_event == 81)
			{
				text2 = "匈牙利狂想曲";
				text = "Curious infromation came from Budapest - it seems that glorified in its own time by Khruschev kadarist \"goulash-socialism\" is on the verge of default, literally - Hungary owes the IMF 7.7 billion dollars, which it is not able to pay. According to our economists, the Hungarians have two options - either take new loans from the West and the USSR, or begin full-scale market reforms that will hurt the living standarts of the majority of population. The heads of HSWP won't take the last option, remembering about events of the Prague Spring, so they will likely take new loans. But we take advantage of issues of PRH and offer them our economic assistance - but under condition of the rehabilitation of disgraced stalinist Béla Biszku and his group, which oppose half-market reforms and can become our reliable support in HSWP. However, we can just offer help to the drowning without puting forward political conditions...";
			}
			else if (GlobalScript.inst.gameState.number_event == 82)
			{
				text2 = "福克兰群岛战争";
				text = "The UK is going through hard times recently, losing its once huge influence. The Argentine military junta led by Leopoldo Galtieri decided to use that for \"small victorious war\" .  On April 2, Argentine paratroopers landed on the Falkland Islands belonging to Britain, whose identity had long been challenged by Argentina, almost immediately breaking the resistance of the small British garrison. In response, the British sent their fleets to the islands with the intention of blocking them. It seems that there's a new conflict in the world.";
			}
			else if (GlobalScript.inst.gameState.number_event == 83)
			{
				text2 = "斯塔夫罗波尔农学家之难";
				text = "我们的特工部门设法获得了重要情报。\n据此，苏联农业正面临相当严重的问题，\n而今年的暴雨更是雪上加霜。\n农业方面的负责人、苏共中央书记费奥多尔·库拉科夫（Fedor\n Kulakov）是最可能接替现任苏联领导人列昂尼德·勃列日\n涅夫的人选之一。根据特工获取的情报，\n库拉科夫主张积极研究并把匈牙利和南斯拉夫的经验引入苏联农业（\n即：把集体农场和国营农场的管理下放；\n以家庭承包和单干农场为基础建立农业合作社）。\n我们可以利用这一点，在即将召开的苏共中央全会上对他进行抹黑，\n从而把这位危险的改革派挡出道路……";
			}
			else if (GlobalScript.inst.gameState.number_event == 84)
			{
				text2 = "我们的老游击队员……";
				text = "So, now that Fedor Kulakov has been eliminated, it is time to pay attention to the conservative wing of the CPSU. In it, of course, the brightest figure - Peter Masherov - the First Secretary of the Central Committee of the Communist Party of Belarus. The former partisan commander, Masherov, headed Belarus in 1965 and achieved very significant success in the development of this republic of the USSR — national income increased several times, industrial and agricultural development was active, a number of enterprises were built, including the Azot Chemical Combine , Novopolotsk Chemical Plant \"Polymir\", Gomel Chemical Plant, Berezovskaya State District Power Plant. Thanks to the personal intervention of Masherov, the construction of the subway began in Minsk. The grain yield reached 27 c / ha, and the grain harvest - 7.3 million tons. However, because of his line on renovation of staff, Masherov caused dissatisfaction of many party members, he is in a rather conflicting relationship with the main ideologist of the CPSU, Mikhail Suslov, and was also very close to the disgraced Kulakov. Nevertheless, 列昂尼德·勃列日涅夫 clearly relies on him as a possible successor to the elderly head of the Council of Ministers Kosygin, and the prime minister himself approves of this choice. The MGB has prepared several options for eliminating Masherov from the road.";
			}
			else if (GlobalScript.inst.gameState.number_event == 85)
			{
				text2 = "哈萨克斯坦的德意志自治";
				text = "Our sources in Moscow managed to get interesting information - a commission composed of Y. Andropov, I. Kapitonov, M. Zimyanin, Z. Nuriev, N. Shchelokova, R. Rudenko, M. Georgadze, V. Chebrikova submitted to the Central Committee of the CPSU a proposal for formation of German autonomy in the Kazakh SSR (where 940 thousand Germans were sent here in the 30-40s). However, the leadership of the republic, led by 列昂尼德·勃列日涅夫’s close associate, Dinmukhamed Kunaev, strongly opposes this. As far as we know, they are even ready to organize the riots of the Kazakh population in case that this autonomy is created. Kunaev is one of the most likely candidates for the post of Second Secretary of the CPSU Central Committee in the event of a change in the composition of the Soviet leadership, and his anti-Chinese sentiments are not a secret. It makes sense to take advantage of the situation to overthrow him.\nOn the other hand, some of your advisers ask: Why should we continue to help the Soviet Union to purify themselves when we can simply pit the Brezhnev clique against each other and benefit from it right now?";
			}
			else if (GlobalScript.inst.gameState.number_event == 86)
			{
				text2 = "The end of \"Iron Yuri\"";
				text = "As we know, 列昂尼德·勃列日涅夫 has just traveled to Vienna to negotiate the SALT-2 agreement with US President Carter. Of course, the imperialists will not do any \"strategic offensive arms limitation\", but we are not interested in this - Brezhnev will spend enough time abroad so that we can strike at the all-powerful head of the USSR KGB 尤里·安德罗波夫. He is known as a supporter of the gradual improvement of Soviet-American relations and the conduct of large-scale reforms on the Hungarian model. Now Andropov is beginning to be regarded as the most likely successor to 列昂尼德·勃列日涅夫. So, there are two ways to get him out of the way — either physically eliminating him under the pretext of dying from kidney failure, or trying to “push” the main ideologist of the CPSU, Mikhail Suslov, and the head of the Ukrainian party organization of the CPSU, Vladimir Scherbitsky, who are in extremely bad relations with the head of the Soviet secret police , to the convocation of an emergency plenary session of the Central Committee of the CPSU and the rout of Andropov on it. Headed by Colonel-General Vitaliy Fedorchuk, the Ukrainian KGB submits to Scherbitsky and not at odds with his ally, so the chances of success are quite large.";
			}
			else if (GlobalScript.inst.gameState.number_event == 87)
			{
				text2 = "加利利的和平";
				text = "由于黎巴嫩领导层软弱、1975年以来内战持续不断，\n以及阿拉伯国家的积极援助，巴勒斯坦解放组织得以在黎巴嫩南部部\n署一个打击以色列、且不受政府控制的强点。\n双方反复交火，但看来冲突已进入“热战”阶段。\n6月3日，以色列在伦敦发动暗杀企图（据查，\n实施者是另一个与巴解组织无关的巴勒斯坦组织），\n这成为以色列对黎巴嫩进行大规模轰炸的借口；\n而6月6日，以色列军队越过黎巴嫩边境，\n与巴解组织武装展开战斗。";
			}
			else if (GlobalScript.inst.gameState.number_event == 88)
			{
				text2 = "津巴布韦种族隔离的终结";
				text = "在罗得西亚（亦称津巴布韦）——黑人多数反对白人当局、\n推行种族隔离政策的武装斗争已持续多年——似乎政治出现了转向。\n1979年12月，兰开斯特会议召开，\n达成协议：在停火条件下举行普选并实现平等选举；\n同时由英国殖民当局正式宣布“津巴布韦-罗得西亚”，\n直至对其命运作出进一步决定。\n结果，由ZANU与罗伯特·穆加贝领导的左翼民族主义联盟赢得选\n举；4月18日，改名为津巴布韦的国家宣布独立。\n曾经，我们和苏联一样支持较为温和的ZAPU——也就是如今与Z\nANU在联盟中并肩的伙伴——那么，继续与胜出的左翼政党合作是\n否值得？";
			}
			else if (GlobalScript.inst.gameState.number_event == 89 && GlobalScript.inst.gameState.resultOfEvents[85] >= 3)
			{
				GlobalScript.inst.gameState.empires[1].leaders[3].support = 0;
				GlobalScript.inst.gameState.empires[1].leaders[1].support--;
				GlobalScript.inst.gameState.empires[1].leaders[1].support += ((GlobalScript.inst.gameState.empires[1].leaders[5].support > 0) ? GlobalScript.inst.gameState.empires[1].leaders[5].support : 0);
				GlobalScript.inst.gameState.empires[1].leaders[5].support = 0;
				GlobalScript.inst.gameState.empires[1].leaders[2].support += ((GlobalScript.inst.gameState.empires[1].leaders[4].support > 0) ? GlobalScript.inst.gameState.empires[1].leaders[4].support : 0);
				GlobalScript.inst.gameState.empires[1].leaders[2].support += ((GlobalScript.inst.gameState.empires[1].leaders[6].support > 0) ? GlobalScript.inst.gameState.empires[1].leaders[6].support : 0);
				GlobalScript.inst.gameState.empires[1].leaders[4].support = 0;
				GlobalScript.inst.gameState.empires[1].leaders[6].support = 0;
				text2 = "The 一个时代的结束";
				text = "Breaking news from the USSR! Today the Soviet leadership announced the death of Leonid Ilyich Brezhnev, who led the Soviet Union for more than 20 years. The Soviet leader died of sudden cardiac failure in his sleep on the night of 1 July. In recent years, on the advice of doctors, 列昂尼德·勃列日涅夫 had governed the country for no more than three hours a day and managed to avoid injuries, thanks to which he lived a relatively long life. While the entire Soviet people mourned, an active struggle for power took place in the CPSU, where the main competitors for the post of General Secretary of the CPSU Central Committee are:";
				if (GlobalScript.inst.gameState.empires[1].leaders[1].support > 0)
				{
					text += "|乌克兰共产党负责人弗拉基米尔·谢尔比茨基——忠诚的勃列日涅\n夫主义者，在发展经济、提高乌克兰苏维埃社会主义共和国人民生活\n水平方面取得了巨大成就。";
				}
				text += "|康斯坦丁·切尔年科——苏共中央总书记处（总务部门）\n负责人，保守派党员、经验丰富的组织者；\n有人甚至认为他在观点上带有斯大林主义色彩。\n|如果我们同苏联的关系还不算最糟，那么我们可以支持其中一位候\n选人。当然，这不会从根本上改变局势，\n但在僵持局面下，或许能把天平倾向于对我们方便的那位候选人。";
			}
			else if (GlobalScript.inst.gameState.number_event == 89)
			{
				text2 = "The 一个时代的结束";
				text = "Urgent news from the USSR! Today, the Soviet leadership announced the death of Leonid Ilyich Brezhnev, who led the Soviet Union for almost 20 years. The Soviet leader died on November 10 in a dream from a sudden heart failure. While all the Soviet people were grieving, an active struggle for power unfolded in the CPSU, where the main contenders for the post of General Secretary of the Central Committee of the CPSU are:";
				if (GlobalScript.inst.gameState.empires[1].leaders[3].support > 0)
				{
					text += "|尤里·安德罗波夫——苏联克格勃负责人，\n务实的改革派，积极推动其同僚进行改革，\n如戈尔巴乔夫、利加乔夫和多尔吉赫。";
				}
				if (GlobalScript.inst.gameState.empires[1].leaders[1].support > 0)
				{
					text += "|乌克兰共产党负责人弗拉基米尔·谢尔比茨基——忠诚的勃列日涅\n夫主义者，在发展经济、提高乌克兰苏维埃社会主义共和国人民生活\n水平方面取得了巨大成就。";
				}
				text += "|康斯坦丁·切尔年科——苏共中央总书记处（总务部门）\n负责人，保守派党员、经验丰富的组织者；\n有人甚至认为他在观点上带有斯大林主义色彩。\n|如果我们同苏联的关系还不算最糟，那么我们可以支持其中一位候\n选人。当然，这不会从根本上改变局势，\n但在僵持局面下，或许能把天平倾向于对我们方便的那位候选人。";
			}
			else if (GlobalScript.inst.gameState.number_event == 90)
			{
				text2 = "香港再见，澳门再会？";
				text = "As you know, we managed to reach an agreement on the return of control to China over Hong Kongin 1997 and over Macao in 1999 on the right of very broad autonomy, for which we even created a new territorial unit - \"special administrative region\". However, part of the local big bourgeoisie opposed this agreement and, as it became known to our intelligence services, is preparing a whole series of provocations aimed at disrupting it and preserving the colonial domination of Great Britain and Portugal (in particular, maximally delaying the development of the SAR Basic Laws, holding anti-Chinese rallies and publishing inflammatory materials in the media). In this situation, a number of party members came up with an unexpected proposal - to establish links with the so-called Triads - the 7th most influential Hong Kong crime syndicates, which have powerful links throughout Southeast Asia. We could offer them favorable economic preferences and guarantees of immunity - but on condition that they assist in the reunification of Hong Kong and Macao with homeland. So your solution?";
			}
			else if (GlobalScript.inst.gameState.number_event == 91)
			{
				text2 = "仰光轰炸";
				text = "据我们掌握的情况，今天在缅甸首都发生了一起恐怖袭击，\n其目的在于刺杀韩国总统全斗焕。\n全斗焕本人因爆炸发生后两分钟才到达现场而幸免于难，\n但韩国代表团有17人遇难。\n恐怖分子很快被抓获，经审讯后自称为朝鲜人民军军官。\n朝鲜方面否认与事件有关，但仅凭这类事件的存在，\n就给了我们机会，以新的力量重新点燃朝鲜与韩国之间的对抗。";
			}
			else if (GlobalScript.inst.gameState.number_event == 92)
			{
				text2 = "超额完成是光荣！";
				text = "同志主席！随着新五年计划的实施启动，\n计划委员会的一些专家和经济学家建议，\n为下一个五年确定一个优先发展的部门。\n你需要决定：国家应当对国民经济的哪些领域给予特别关注与投资—\n—工业、农业、服务业，还是科学发展？\n不过，我们也可以有节制地分配资金，同时把力量投向三个部门的改\n善，从而实现更均衡的发展。";
			}
			else if (GlobalScript.inst.gameState.number_event == 93)
			{
				text2 = "民主的故乡";
				text = "In Greece, still recovering from the influence of the Regime of the Colonels deposed in 1974, parliamentary elections are scheduled. After the restoration of democracy in the country there were two dominant parties - the liberal-conservative \"New Democracy\" and the left-wing Social Democrats from PASOK (\"Panhellenic Socialist Movement\"). Since the direction of Greek politics like membership in NATO (which the country actually leave in 1974 due to the Turkish invasion of Cyprus) and in the European Union  is actually being decided, the outcome of these elections can seriously affect the situation in the country.";
			}
			else if (GlobalScript.inst.gameState.number_event == 94)
			{
				if (GlobalScript.inst.gameState.faction_leader[4] >= 200 || GlobalScript.inst.gameState.faction_leader[4] < 0 || GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].traits[0] != 4)
				{
					(Politic, int) tuple = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 4);
					if (tuple.Item1 == null)
					{
						tuple = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 3);
					}
					if (tuple.Item1 == null)
					{
						tuple = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 2);
					}
					if (tuple.Item1 == null)
					{
						tuple = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 1);
					}
					if (tuple.Item1 == null)
					{
						tuple = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 0);
					}
					GlobalScript.inst.gameState.faction_leader[4] = tuple.Item2;
				}
				text2 = "天安门事件。又来？！";
				text = "The policy of large-scale reforms in all spheres of life, the flourishing of corruption, the merging of the CPC with business and the establishment of secret corruption links between the nomenklatura and businessmen caused a significant increase in bourgeois brain liberalization of a considerable part of the Chinese intelligentsia and youth requiring radicalization of reforms and rejection of \"communist contagion\". They formed a movement \"Tuidang\" (literally \"Refusal of the Party\") led by dissident astrophysicist Fang Lizhi, who in the West is called \"Chinese Sakharov\", advocating the announcement of the CPC \"a criminal organization\" and her power removal from power, liberalization and westernization of the country, the fight against corruption and the privileges of the nomenclature. Using the permission to hold mass events, 100 thousand supporters of \"Tuidang\" gathered in Tiananmen Square in Beijing. They demand \"freedom\", \"democracy\", \"fighting corrupt bureaucrats\" and \"resigning corrupt party leadership\", while other dissatisfied with our reforms, including workers, join them every day. The liberal wing of the CPC, which heads " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + "，倾向于同意抗议者的要求，企图借助一波波抗议浪潮上台。\n局势极不稳定，但在骚乱蔓延到其他城市之前，\n仍有机会进行干预……";
			}
			else if (GlobalScript.inst.gameState.number_event == 95)
			{
				text2 = "中共的新开端";
				text = "因此，北京局势被控制住了，国家权力转交给由同志 " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ". On the agenda is the issue of large-scale policy deepening \"reform and opening-up\" and the transition to a Western-style democracy and a free market. However, the movement \"Tuidang\", with which we are now forced to reckon, requires to take into account in the reform project the need to decommunize Chinese society and, of course, the ruling party. In principle, the CPC is so hard to call the \"communist\" party, but now we are invited to abandon Marxism-Leninism completely. So?..";
			}
			else if (GlobalScript.inst.gameState.number_event == 96)
			{
				text2 = "改革！民主！公开！";
				text = "So, the organizational issues are over and now we need to fulfill the promises given to the people about the democratization of China in the Western style. The people demand the cessation of pressure on religion and clergy, the expansion of civil rights and freedoms modeled on Western countries and, most importantly, the dissolution of the \"National Revolution United Front\" and free elections to the NPC and local authorities. And if we cannot avoid the elections, we could make them as free as we need, by the fulfillment of other demands.";
			}
			else if (GlobalScript.inst.gameState.number_event == 97)
			{
				text2 = "Automation?";
				text = "这是我们的重大科学突破——不久前我们还在同经济的全面落后作斗\n争，而现在我们的科学家在开发基于计算机系统的经济计划自动化机\n制方面取得了杰出成就，甚至已经开始研制一种能够对全国企业进行\n自动化规划与协调的系统。\n它距离全面实施仍有很大差距，但如果我们要在经济自动化上取得成\n功，就现在就应该、也必须开始在基层引入其区域系统，\n并实现它们之间的协调。\n然而，许多管理者和党内成员——认为这种引入速度对一个陌生系统\n来说太急——显然并不喜欢……";
			}
			else if (GlobalScript.inst.gameState.number_event == 98)
			{
				text2 = "非洲的“切·格瓦拉”";
				text = "同志Chairman, urgent news from the former French colony of the Upper Volta! Incredibly popular among the people, the former prime minister and concurrently influential military figure Thomas Sankara, arrested several months earlier, overthrew the pro-french president Jean-Baptiste Ouedraogo, who massively closed trade unions and killed oppositionists. Immediately after the military coup, the name of the country was changed from colonial \"Upper Volta\" to \"Burkina Faso\" - \"home of honest people\", all state symbols were completely changed. Now, Thomas Sankara, who adheres to revolutionary anti-imperialist views, announces a policy of building socialism and \"fighting against the counter-revolutionary classes of society\", which in turn makes his position precarious. In order to carry out its revolutionary transformations and \"raise the country from its knees\", Sankara is seeking help from the socialist countries. Perhaps we should recognize the new power and send ambassadors, thereby showing our benevolent intentions. However, also, radical left anti-imperialist views, very close to Mao, with the necessary support, can create us a stable ally in central Africa. Although... it may not be worth it to be so hasty and \"rock the so-unstable boat of revolutions\" on the African continent? ";
			}
			else if (GlobalScript.inst.gameState.number_event == 117)
			{
				text2 = "五年丧葬";
				text = "来自苏联的消息刚刚传来——2月9日，\n苏共中央总书记尤里·安德罗波夫因肾衰竭去世，\n享年69岁。自1983年底起他就病得很重，\n而在克里米亚染上的感冒最终夺走了这位苏联领导人的生命。\n在他的执政期间，安德罗波夫高度重视改善经济状况——发起了维护\n劳动纪律的运动，推出大规模反腐措施，\n主要矛头指向贸易中非法核销造成的缺口。\n同时，安德罗波夫积极提拔年轻的改革派干部，\n并指示戈尔巴乔夫、雷日科夫、阿巴尔金和多尔吉赫，\n着手制定面向苏联的大规模经济改革方案。\n鉴于政治斗争加剧，作为折中方案的切尔年科很可能当选为新总书记。\n并且在2月14日，安德罗波夫的葬礼将举行，\n届时许多国家的代表——包括与苏联结盟的以及其他国家——都打算\n前来。那我们该怎么办？";
			}
			else if (GlobalScript.inst.gameState.number_event == 114)
			{
				text2 = "大象与驴";
				text = "美国总统选举即将举行：现任民主党总统吉米·卡特竞选连任第二任\n期，与雄心勃勃的共和党人罗纳德·里根展开竞争。\n卡特执政期间，试图改善美国人的福利，\n建设更开放的政府，并总体上改革一些美国政府机构。\n外交政策的特点是在对苏对抗与缓和之间寻求平衡。\n然而，卡特的总统任期不幸与油价上涨相重合，\n而相对温和的外交政策又遭到保守派的严厉批评，\n因此共和党赢面很大。\n当然，我们无法介入，只能等待。";
			}
			else if (GlobalScript.inst.gameState.number_event == 99)
			{
				text2 = "黄蝎子";
				text = "同志主席，来自社会主义阿尔及利亚的突发新闻！\n在一次突如其来且迅速恶化的疾病之后，\nPDRA第二任总统、因其隐秘与狡黠而在民间被称为“<b>黄蝎子</b>”的\n胡阿里·布迈丁埃突然去世。\n近十五年左右的执政期间，布迈丁埃把这个落后的法属殖民地变成了\n非洲的工业巨头。如今由于国内缺乏明确继承人，\n在执政党“<b>民族解放阵线</b>”内部，三派正在争夺权力：\n一是正统斯大林主义者，由穆罕默德·萨拉赫·亚希奥维领导，\n且受到工会的热烈支持；他们反对与“<b>修正主义的苏联</b>”结盟。\n二是以查德利·本杰迪德为首的温和改革派：\n主张维持同苏联的友好关系，但引入一些市场改革。\n三是对亲西方外交部长——阿卜杜勒阿齐兹·布特弗利卡——抱有同\n情的自由派。我们若支持其中一派，或许能扩大我们在非洲国家的影\n响力，但值得吗？";
			}
			else if (GlobalScript.inst.gameState.number_event == 100)
			{
				text2 = "GOVERNMENT CRISIS";
				text = "在经历了数不清的政变之后，孟加拉的军方统治相对稳定下来，\n“<b>幕后操盘手</b>”侯赛因·穆罕默德·埃尔沙德得以接任国家总统。\n在右翼威权政权存在的两年里，孟加拉对自由派与社会主义者（主要\n由左翼“<b>人民联盟</b>”代表）展开了全面镇压；\n而该国的主要问题——农民土地短缺以及最高权力层的腐败——仍未\n得到解决。对此，尽管成效不一，针对政府行动的强硬抗议正在全国\n各城市展开，其主要口号是举行提前议会选举。\n我认为，如果我们在财政上支持政府，就能平息这处“<b>东南亚动荡的\n政变温床</b>”，尤其是因为现政府致力于升温同中国的关系。\n但如果我们能更强力地煽动抗议、并把反对力量集中到反对埃尔沙德\n与将军们的阵营，那么更忠于我们的人就可能上台；\n可在这种情况下，世界舆论会怎么看？\n也许干脆不介入更好？";
			}
			else if (GlobalScript.inst.gameState.number_event == 102)
			{
				text2 = "变革的风？";
				text = "来自苏联的紧急消息！\n1985年3月10日19时20分，苏共中央总书记康斯坦丁·乌\n斯季诺维奇·切尔年科因心脏骤停去世。\n人们正在哀悼之际，克里姆林宫走廊里正展开争夺新总书记席位的斗\n争，候选人包括：|米哈伊尔·戈尔巴乔夫——年轻且有前途的党员，\n曾是安德罗波夫团队成员，以改革派观点著称。\n|格里戈里·罗曼诺夫——精力充沛、敢于试验的年轻但经验丰富的\n管理者，曾任列宁格勒州委书记，以铁腕手段确保列宁格勒繁荣与经\n济增长。|最后，维克托·格里申——老一代政治局代表、\n保守派圈子的宠儿，莫斯科市委书记，支持勃列日涅夫在内外事务上\n的政策；这些年他在苏共中央内部盘根错节（包括腐败）。\n|如果我们能选的话，该支持谁？";
			}
			else if (GlobalScript.inst.gameState.number_event == 104)
			{
				text2 = "第十二届世界青年与学生联欢节";
				text = "The 第十二届世界青年与学生联欢节 is due to take place in Moscow soon. Such festivals have been organized by the World Federation of Democratic Youth - an international left-wing youth organization - since 1947 and have always been a vibrant gathering of progressive youth from around the world, and the festivals were aimed at promoting socialism and the fight against imperialism. We are faced with the eternal question - to go or not? After all, the USSR, being the host country and having enormous influence on the WFDY, may not let us in if there are strong disagreements. In this regard, some party members suggest holding their own similar festival, inviting representatives of friendly countries.";
			}
			else if (GlobalScript.inst.gameState.number_event == 105)
			{
				text2 = "阿尔巴尼亚斯大林的终结";
				text = "来自阿尔巴尼亚的有趣消息：4月11日，\n阿尔巴尼亚长期领导人恩维尔·霍查逝世，\n享年76岁。国家正为失去他而悲痛之际，\n拉米兹·阿利亚接任阿尔巴尼亚劳动党（APT）\n中央委员会第一书记一职；长期以来，他被认为是霍查的继承人，\n并在击败梅赫迈特·谢胡集团中发挥了重要作用。\n阿利亚因无条件支持霍查政策的所有转向而深得霍查青睐；\n不过据一些报道，他并不排斥同西方与南斯拉夫建立关系，\n也可能在国内政治上作出某些让步。\n一方面，这可能对我们有利；另一方面，\n结局如何却不得而知。\n因此，如果我们在附近有特工，或许可以对新统治者组织一次恐怖袭\n击。";
			}
			else if (GlobalScript.inst.gameState.number_event == 106)
			{
				text2 = "民主国际";
				text = "In the Angolan city of Jamba, which is the main base of the anti-communist rebel movement UNITA, a conference is being prepared following the results of which the participants want to create the so-called. \"民主国际\" - a coalition of anti-communist rebels from different countries. In addition to UNITA, the conference is attended by representatives of Afghan mujahideen, Nicaraguan contra and Lao Hmong, and American conservatives, such as banker Lewis Lerman (event financier), famous lobbyist and film producer Jack Abramoff (event initiator) and lieutenant colonel Oliver North, are actively participating in the organization. Despite the bright anti-Soviet orientation of the upcoming alliance, it also intersects with the zone of our interests and may cause problems in the future. On the other hand, we can try to use it in the geopolitical struggle with the USSR.";
			}
			else if (GlobalScript.inst.gameState.number_event == 109)
			{
				text2 = "索马里的黄金时代";
				text = "在奥加登战争失败之后，索马里的局势开始迅速恶化。\n西索马里解放阵线遭到惨败，被埃塞俄比亚军队击溃；\n而苏联军事与民用援助的崩塌，严重冲击了索马里经济。\n索马里革命社会主义党逐渐失去人气，贾勒·穆罕默德·西亚德·巴\n雷的政权也变得越来越专制。\n在这种令人沮丧的氛围中，索马里政府试图通过与美国及西方国家加\n强合作来拉开与苏联的距离。\n也许我们向索马里政府尽可能提供援助、\n帮助其稳定局势，就能争取巴雷的支持，\n在东非获得一个有利且忠诚的盟友。\n但这能否挽救SRSP政权？\n——全国范围内正在积极形成武装反对派。\n将军们对巴雷总统的犹豫极为不满；也许只要争取到他们的支持，\n我们就能设法密谋推翻他，让更务实的领导人上台？";
			}
			else if (GlobalScript.inst.gameState.number_event == 110)
			{
				text2 = "自动化是一个自然的过程";
				text = "同志主席！在过去五年里，我们在国民经济运行与科学研究方面取得\n了巨大进展，不能就此停步。\n现在是时候巩固我们的成果，重塑几代人关于完美世界秩序的梦想，\n迈出从社会主义走向共产主义社会的第一步。\n我国最优秀的头脑——数学家与控制论专家——提出建立一套全规模、\n全方位的统一自动化生产计划体系，其基础是苏联数学家维克托·\n格卢什科夫的OGAS设想。\n这样，我们就能通过把绝大多数复杂且昂贵的计算交给计算机来完成，\n从而摆脱计划经济的所有问题与弊端。\n但要实施这样一个浩大工程，需要大量资金与时间；\n而国家机器对激烈变革如同畏火，尤其是那些可能触及他们“<b>占着的\n位置</b>”与既得繁荣的变革。\n选择在你……";
			}
			else if (GlobalScript.inst.gameState.number_event == 111)
			{
				text2 = "向幽冥之光";
				text = "同志主席！在IECS系统部分实施之后，\n政府开始在基层有步骤、有系统地削减国家机构，\n以腾出不必要的熟练劳动力并优化预算。\n这些措施遭到地方官僚的强烈抵制；他们已经把你定为“<b>资产阶级反\n革命</b>”。现在连最高层的党内领导也反对你，\n并已经在准备罢免你。\n我们必须立即采取行动！\n我们要动员广大群众的支持，胜利将属于我们！\n但问题是——他们会支持我们吗？";
			}
			else if (GlobalScript.inst.gameState.number_event == 112)
			{
				text2 = "未知世界的故事";
				text = "同志主席，怪事正在发生！\n全国各行业之间的组织运转失灵。\n基层企业之间的通信中断，粮食向各地区的输送也出现间断，\n商店里的排队人数不断增加。\n管理者保证说，有人从外部对我们的设备实施了计算机攻击。\n情报机构认为，这是我们的外部对手与反对自动化的敌人勾结在一起\n——他们担心我们在世界舞台上的影响力不可避免地增长，\n正试图通过瘫痪IECS来打击我们的经济。\n如果我们不立刻采取行动，这将导致国家崩溃。\n专家建议为我们的计划系统开发专门的防护措施，\n但这需要时间。不过，我们可以请求苏联专家的支持，\n这样就能让设备迅速恢复运行。\n或者……自动化真的只是乌托邦？";
			}
			else if (GlobalScript.inst.gameState.number_event == 113)
			{
				text2 = "南斯拉夫社会主义自治的煎熬";
				text = "同志Chairman, news unpleasant for us comes from Yugoslavia - the so-called \"Kraiger Commission\", headed by former 主席of the Presidium of the SFRY Sergej Kraigher (Slovene by nationality and close associate of the main theorist of Yugoslav \"socialist self-government\" Edvard Kardelj), submitted for consideration Presidium of the SFRY project for large-scale market economic reforms. Yugoslavia after the death of Josip Broz Tito is going through difficult times - the consequences of the separatist rebellion in Kosovo are still not eliminated, dissatisfaction with the Center is growing in Slovenia and Croatia, and nationalist sentiments are growing in Serbia. The 1979 economic crisis added fuel to the fire, forcing the country, which was already soiling in debt, to take additional loans. It seems that Yugoslavia is moving towards the abyss... USSR and the countries of the socialist camp are ready to provide the SFRY with a large financial help in exchange for refusing reform. We can also join the proposal of the Soviet leadership, however, a group of party members offers to reprove the military coup and bring to power the Yugoslav generals, determined to end the policy of \"non-alignment\". On the other hand, the USA also offers the SFRY new loans... So, what will we do in this situation?";
			}
			else if (GlobalScript.inst.gameState.number_event == 115)
			{
				text2 = "金三角";
				text = "同志Chairman, as our special services know, in the mountainous regions of Burma, Laos and Thailand, which have recently become part of our sphere of influence, there is a large network of syndicates involved in the production and marketing of drugs, called the \"金三角\". This network is highly conducive to corruption in these and surrounding countries, and it is also led by a prominent member of the Shan people, who advocate their separation from Burma, Khun Sa. Taking all this into account, part of the party members and the generals offer to assist these countries in conducting investigative and military operations against drug dealers. However, there is another group that rightly claims that over the long years of the civil war, the Shan have not been able to achieve independence from Burma and are unlikely to succeed, corruption in these countries cannot be eliminated by striking a single network of syndicates, and these drugs go mainly to Western countries . In this regard, they offer to help the 金三角 in the organization of protection and marketing of goods, which will help us get money and spoil the life of the West.";
			}
			else if (GlobalScript.inst.gameState.number_event == 435)
			{
				text2 = GlobalScript.inst.new_events_text[1647];
				text = GlobalScript.inst.new_events_text[1648];
			}
			else if (GlobalScript.inst.gameState.number_event == 436)
			{
				text2 = GlobalScript.inst.new_events_text[1656];
				text = GlobalScript.inst.new_events_text[1657];
			}
			else if (GlobalScript.inst.gameState.number_event == 116)
			{
				text2 = "两个中国";
				text = "你们都知道，内战中中共获胜后，国民党逃往台湾岛；\n长期以来，西方社会一直把他们视为中国的合法政府。\n由于美国在台湾设有基地并部署舰队，我们无法收复台湾；\n同样，国民党也无法重新夺回大陆。\n随着时间推移，越来越多国家承认中共的统治，\n尽管无论是共产党还是台湾当局都在形式上并未放弃对全中国的主张。\n当然，我们之间的关系一直很糟；但在最近的放宽政策以及中共对\n权力的垄断结束之后，关系明显变得更温和了。\n现在，两国高层有些人在谈论实现久违的国家统一的可能性。\n然而在这种情况下，台湾将毫无疑问地要求自治；\n我们还需要与美国就其基地地位达成协议；\n而台湾人民在发展出自身文化认同之后，\n会如何影响本已不稳的国内局势，尚不得而知。\n因此，有人建议：我们与台湾相互承认对方为独立国家，\n并建立睦邻关系。再说，在这种安排下，\n美国基地仍将保留，西方公司也免于陷入一堆官僚扯皮——那就不妨\n向美国暗示：年轻的民主需要钱……";
			}
			else if (GlobalScript.inst.gameState.number_event == 103)
			{
				if (GlobalScript.inst.gameState.allcountries[0].isEU)
				{
					text2 = "申根协议";
					text = "Recently, on July 14 in Luxembourg between several European countries the 申根协议 was signed, implying simplification of passport and visa control at the borders between them and outlining a move towards an almost complete rejection of passport control. The Schengen agreement was a continuation of the visa-free regime adopted long ago at the EEC, which prompted your party members to think that we also have our own economic union. The creation of a single visa space, the free movement between the countries of the union and the simplification of border controls should facilitate the cultural exchange between our countries, the development of tourism, and people will like it. The problem is that it will also simplify the life of dissidents and criminals, and indeed, it is unknown which ideas our citizens will get abroad...";
				}
				else
				{
					text2 = "马德里协议";
					text = "Recently, on July 14 in Luxembourg between several European countries the 马德里协议 was signed, implying simplification of passport and visa control at the borders between them and outlining a move towards an almost complete rejection of passport control. The Madrid agreement was a continuation of the visa-free regime adopted at the SU, which prompted your party members to think that we also have our own economic union. The creation of a single visa space, the free movement between the countries of the union and the simplification of border controls should facilitate the cultural exchange between our countries, the development of tourism, and people will like it. The problem is that it will also simplify the life of dissidents and criminals, and indeed, it is unknown which ideas our citizens will get abroad...";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 107)
			{
				text2 = "同盟危机";
				text = "众所周知，我们的共同体是最民主、最平等的……\n这就带来了后果。 " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + "最近一直在奉行越来越独立于我们的政策，\n而那些想在其政治体制中推行某些改革的不忠力量正在获得权力。";
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
				{
					text += "但更糟的是他们在外交上与美国和西方眉来眼去！\n如果继续这样下去，我们就有失去盟友的风险，\n所以我们得做点什么——可做什么？\n我们不想像苏联在捷克斯洛伐克那样的修正主义者。\n或者……？";
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
				{
					text += "但更糟的是他们在外交上与苏联眉来眼去！\n如果继续这样下去，我们就有失去盟友的风险，\n所以我们得做点什么——可做什么？\n我们不想像苏联在捷克斯洛伐克那样的修正主义者。\n或者……？";
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
				{
					text += "|而这一切都发生在我们盟友政府即将宣布“中立政策”的背景之下\n——这意味着一件事：他们想退出我们的军事同盟。";
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].econ)
				{
					text += "而这一切都发生在这样的背景之下：我们的盟友政府正发疯似的砍断\n与我们的一切贸易联系，宣布经济转向——这意味着一件事：\n他们想退出我们的经济联盟。";
				}
			}
			else
			{
				text2 = "Гудбай, Брежнев";
				text = "";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 3)
		{
			text2 = "Смерть кормчего";
			text = "Случилось страшное. После 2 перенесённых инфарктов 9 сентября в 0 ч. 10 мин. на 83-м году жизни скончался великий лидер и учитель китайского народа председатель Мао Цзэдун. Пока весь народ и партия скорбят, нам необходимо созвать похоронную комиссию и решить, как же мы проводим председателя в последний путь.";
		}
		else if (GlobalScript.inst.gameState.number_event == 4)
		{
			text2 = "Заговор";
			text = "По недавно поступившей информации несколько высших партийцев, недовольных вашим правлением, за вашей спиной договорились отстранить вас на следующем съезде ЦК. Нужно срочно что-то предпринять, если вы не хотите повторить судьбу ревизиониста Хрущёва в 1964-м.";
		}
		else if (GlobalScript.inst.gameState.number_event == 5)
		{
			text2 = "Народное недовольство";
			text = "Недовольный вашей политикой народ вышел на массовые митинги по всей стране и начал сооружать палаточные городки на площадях, распространять листовки и даже штурмовать местные госучреждения. Разные группы протестующих недовольны разными аспектами вашего правления, но все они требуют демократизации системы, чтобы иметь возможность ограничить ваше влияние на китайскую политику.";
		}
		else if (GlobalScript.inst.gameState.number_event == 6)
		{
			text2 = "Низкий уровень жизни";
			text = "Ваша политика привела к катастрофическому упадку уровня жизни в стране, люди живут в отвратительных условиях и подавляющему большинству не хватает возможностей приобрести даже предметы первой необходимости. Разумеется, это приводит к многочисленным выступлениям и протестам, где люди требуют разобраться с этой ситуацией. С учётом того, что солдаты также недовольны ужасными условиями содержания, рассчитывать на армию мы не можем.";
		}
		else if (GlobalScript.inst.gameState.number_event == 7)
		{
			if (GlobalScript.inst.gameState.modifies[17].active)
			{
				GlobalScript.inst.gameState.IsBankAccountFreezed = true;
			}
			text2 = "Дипломатический кризис";
			text = "Наши отношения с США достигли критически низкой отметки. Их пропаганда уже обвиняет Китай во всех возможных и невозможных преступлениях, а наша разведка докладывает о суматохе в Пентагоне и активности на американских базах в Юго-Восточной Азии. Нужно срочно как-то исправить ситуацию, если мы не хотим Третьей Мировой.";
		}
		else if (GlobalScript.inst.gameState.number_event == 8)
		{
			text2 = "Дипломатический кризис";
			text = "Наши отношения с СССР достигли критически низкой отметки. Их пропаганда уже обвиняет Китай во всех возможных и невозможных преступлениях, а наша разведка докладывает о суматохе в Генштабе СССР и движении советских войск на границе. Нужно срочно как-то исправить ситуацию, если мы не хотим Третьей Мировой.";
		}
		else if (GlobalScript.inst.gameState.number_event == 9)
		{
			text2 = "Сепаратизм в Тибете";
			text = "Подстрекаемые либералами и националистами, жители Тибетского автономного района вышли на массовые демонстрации за независимость и отделение от КНР, которые постепенно перерастают в беспорядки. Люди требуют \"освобождения\" от \"оккупации 1950-го года\" и большинство этнических тибетцев их поддерживает. Впрочем некоторых пока устраивают и просто требования большей автономии, чем мы можем воспользоваться.";
		}
		else if (GlobalScript.inst.gameState.number_event == 10)
		{
			text2 = "Сепаратизм в Синьцзяне";
			text = "Подстрекаемые либералами и националистами, жители Синьцзян-Уйгурского автономного района вышли на массовые демонстрации за независимость и отделение от КНР, которые постепенно перерастают в беспорядки. Люди требуют \"освобождения\" от \"оккупации 1949-го года\" и большинство этнических уйгуров их поддерживает. Впрочем им существует противовес из ханьцев, да и некоторых уйгуров пока устраивают и просто требования большей автономии, чем мы можем воспользоваться.";
		}
		else if (GlobalScript.inst.gameState.number_event == 11)
		{
			text2 = "Упадок промышленности";
			text = "Наша промышленность находится в невиданном упадке - часть заводов простаивает, часть вот-вот закроется и все работают на устаревшем оборудовании.";
		}
		else if (GlobalScript.inst.gameState.number_event == 12)
		{
			text2 = "Упадок сельского хозяйства";
			text = "Наше сельское хозяйство находится в невиданном упадке - такого беспорядка не было даже во времена большого скачка!";
		}
		else if (GlobalScript.inst.gameState.number_event == 13)
		{
			text2 = "Упадок сферы услуг";
			text = "Наша сфера услуг находится в ужасном упадке - большинство магазинов и заведений не работают, а качество сервиса в работающих просто ужасно.";
		}
		else if (GlobalScript.inst.gameState.number_event == 14)
		{
			text2 = "Денег нет, но вы держитесь!";
			text = "В нашем бюджете и резервном фонде катастрофически мало денег. Если так будет продолжаться дальше, то мы совсем скоро не сможем поддерживать нормальную работу нашего государства.";
		}
		else if (GlobalScript.inst.gameState.number_event == 15)
		{
			text2 = "Кампучийско-вьетнамская война";
			text = "Правящие в Демократической Кампучии Красные кхмеры Пол Пота в течении нескольких лет проводили открыто агрессивную политику в отношении соседнего Вьетнама, часто нападая на приграничные селения и массово убивая мирных жителей. И похоже терпение Вьетнама подошло к концу - совсем недавно вьетнамская армия начала полномасштабное вторжение в Камбоджу для свержения режима Пол Пота, используя Единый фронт национального спасения Кампучии, состоящий из левых кхмерских диссидентов как прикрытие. С учётом того, что Пол Пот всё это время был нашим верным союзником, стоило бы помочь ему. Хотя с другой стороны, возможно стоит заменить обнаглевшего диктатора в пользу более разумных офицеров из армии Кампучии. Войну это, конечно, не остановит, но Вьетнам, поставивший себе целью свержение Пол Пота, окажется в затруднительном положении.";
		}
		else if (GlobalScript.inst.gameState.number_event == 16)
		{
			text2 = "Выборы в Таиланде";
			text = "После падения в 1973 году военной хунты и передачи власти гражданскому правительству Таиланд вступил в период \"хаотичной демократии\". Победы коммунистических сил по всему Индокитаю способствуют росту левых настроений, ведомых маоистской Коммунистической Партией Таиланда, которая занимается как партизанской, так и легальной деятельностью. Им противостоят правые военные, землевладельцы и прочие роялисты, что нередко приводит к столкновениям. В этих условиях на фоне вспыхнувшего кризиса тайской экономики демократический премьер-министр Кыкрит Прамот вынужден провести досрочные выборы. Может это наш шанс если не переманить, то хотя бы дестабилизировать оплот империализма в Индокитае?";
		}
		else if (GlobalScript.inst.gameState.number_event == 17)
		{
			text2 = "Нестабильность в Таиланде";
			text = "На фоне нестабильности в обществе и постоянной конфронтации между левыми и правыми силами королевская семья Таиланда решила в сентябре организовать возвращение в страну радикально-правого генерала Танома Киттикачона, бывшего премьер-министра страны, ответственного за кровавые репрессии и свергнутого общественными выступлениями в 1973. Сам Киттикачон не хочет возвращаться в политику и пожелал принять монашество, однако официальное объявление о его возвращении и его встречи с королём вызвали недовольство части общества правым поворотом. Премьер Прамот подал в отставку, которая, впрочем была отклонена, прокатилась волна студенческих и профсоюзных демонстраций, одна из которых проходит в Таммасатском университете, на который уже совершают налёты праворадикальные боевики. По нашим данным, военные готовят жестокое подавление демонстрации.";
		}
		else if (GlobalScript.inst.gameState.number_event == 18)
		{
			if (GlobalScript.inst.gameState.data[82] > 7)
			{
				text2 = "Война закончилась";
				text = "После долгих и кровопролитных боёв конфликт \"" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].name_war + "\" наконец закончился. Министерство иностранных дел обо всём позаботилось и готово представить вам краткий экскурс об итогах войны.";
			}
			else
			{
				text2 = "Война закончилась";
				text = "После долгих и кровопролитных боёв конфликт \"" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].name_war + "\" наконец закончился.";
				text = ((GlobalScript.inst.gameState.data[82] == 6) ? ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 400) ? (text + " Победителем в итоге вышла сторона " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + ", добившись своих целей в войне.") : (text + " Победителем в итоге вышла сторона " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 + ", добившись своих целей в войне.")) : ((GlobalScript.inst.gameState.data[82] == 2) ? ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 750) ? (text + " Победителем в итоге вышла сторона " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + ", добившись своих целей в войне.") : (text + " Победителем в итоге вышла сторона " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 + ", добившись своих целей в войне.")) : ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 900 && GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 < 900) ? ((GlobalScript.inst.gameState.data[82] != 2 && GlobalScript.inst.gameState.data[82] != 4) ? (text + " Ни одна сторона не добилась решающей победы, так что был подписан белый мир, вернувший границы в довоенное состояние.") : (text + " Победителем в итоге вышла сторона " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + ", добившись своих целей в войне.")) : (text + " Победителем в итоге вышла сторона " + ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 > GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2) ? GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 : GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2) + ", добившись своих целей в войне."))));
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 19)
		{
			text2 = "Пять \"нет\"";
			text = "Поздравляем с назначением на пост Премьера Госсовета КНР, товарищ Хуа Гофэн. Как вам известно, вашим предшественником был Чжоу Эньлай, заслуживший популярность и уважение в народе и за рубежом за свою честность и административные таланты. Однако он также был активным проводником экономических реформ и способствовал продвижению в партии реформаторов, таких как его протеже Дэн Сяопин. По этим причинам смерть Чжоу 8 января 1976 года вызвала большую скорбь у народа, которой остались недовольны Мао и верхушка КПК, очень сдержанно отреагировавшие на его смерть. Ходят слухи, что кампанию Пяти \"нет\" затеял сам Мао Цзэдун — не носить траурные повязки, не ставить венки, не делать мемориалы, не устраивать поминальные церемонии и не вешать фотографии Чжоу Эньлая, — но достоверно этого не знает никто: из-за тяжёлой болезни ног и общего состояния здоровья до него сейчас почти не добраться, а решать нужно быстро, времени ждать нет. И вы, как новый премьер, можете повлиять на её исполнение.";
		}
		else if (GlobalScript.inst.gameState.number_event == 20)
		{
			text2 = "Критикуй Дэна и борись с правыми!";
			text = "Смерть Чжоу Эньлая серьёзно повлияла на положение его протеже Дэн Сяопина, который оставшись без протекции бывшего премьера теперь подвергается постоянным нападкам радикалов, возглавляемых женой Мао Цзэдуна Цзян Цин, а 2 февраля Сяопин был переведён на работу в сфере внешних связей. С разрешения Мао Цзян и её сторонникам удалось развернуть кампанию \"Критикуй Дэна и борись с правыми\" и начать активную травлю Дэна в СМИ. Примечательно, что Мао хоть и относится к Сяопину с недоверием, однако участия в его травле пока не принимает. А что же нам делать, с учётом того, что Хуа Гофэн никогда не был в хороших отношениях ни с Цзян Цин ни с Сяопином?";
		}
		else if (GlobalScript.inst.gameState.number_event == 21)
		{
			text2 = "Туманная статья о «Чжоу»";
			text = "25 марта 1976 года шанхайская «Вэньхуэй бао» публикует статью, где некий «Чжоу» объявлен «каппутистом». Одни уверены, что это посмертный удар по Чжоу Эньлаю, другие считают, что бьют по Чжоу Жунсиню, а версию про Эньлая каппутисты Сяопина разгоняют, подогревая скорбь по премьере. Материал вышел по указанию Чжан Чуньцяо и заодно цепляет самого Дэна и его реформы. Народ не понимает, кого именно травят, но эмоции растут — нужно решить, как реагировать.";
		}
		else if (GlobalScript.inst.gameState.number_event == 22)
		{
			text2 = "Тяньаньмэньский инцидент";
			text = "Многочисленные попытки КПК дискредитировать покойного Чжоу Эньлая вызвали в народе лишь недовольство. 4 апреля, в день традиционного праздника поминовения усопших, горожане Пекина понесли на площадь Тяньаньмэнь к Памятнику народным героям венки в память о Чжоу Эньлае. До наступления ночи на площади побывало около 2 миллионов человек, а гора из венков достигла 20 метров в высоту. По этому случаю было созвано экстренное заседание Политбюро ЦК КПК под председательством Мао Цзэдуна. Цзян Цин и Чжан Чуньцяо предлагают сперва обратиться к людям по радио, отделив скорбящих от провокаторов, и лишь затем при необходимости применить силу. У Дэ старается избежать насилия вовсе. Ответственными сделали вас и мэра Пекина У Дэ — какой курс выберем?";
		}
		else if (GlobalScript.inst.gameState.number_event == 23)
		{
			text2 = "Таншаньское землетрясение";
			text = "28 июля в городе Таншане провинции Хэбэй в 03:42 по местному времени произошло землетрясение магнитудой 8,2 по шкале Рихтера в результате которого город был почти полностью разрушен. Разрушения имели место также и в Тяньцзине и в Пекине, расположенном всего в 140 км к западу. Несколько афтершоков, сильнейший из которых имел магнитуду 7,1, привели к ещё большим жертвам. По предварительным данным погибло от 200 до 600 тыс. человек. По мнению начальника Шанхайского городского сейсмологического управления Чжан Цзюня, основной причиной колоссальных разрушений стало отсутствие необходимых мер сейсмозащиты при строительстве.";
		}
		else if (GlobalScript.inst.gameState.number_event == 24)
		{
			text2 = "Ветер перемен?";
			text = "После того, как Мао умер, а вы наконец сосредоточили власть в своих руках, настало время определить дальнейший путь Китая, ведь каждая фракция КПК видит его по-своему. Консервативные маоисты выступают за продолжение политики Мао, но без сомнительных экспериментов, что означает прекращение Культурной революции и кампанейщины. Реформаторы, разумеется, выступают за прекращение Культурной революции и масштабные реформы прежде всего в экономике, чтобы оздоровить китайскую экономику после провальных попыток Мао вмешаться в её работу. Все умеренные считают, что Китаю нужны перемены, однако некоторым достаточно прекращения Культурной революции и небольшой экономической реорганизации, другие же присоединяются к реформаторам с требованием глубоких рыночных реформ. Впрочем и радикальные маоисты не спешат расставаться с идеей Культурной революции и хотят продолжать её с учётом ошибок и перегибов.";
		}
		else if (GlobalScript.inst.gameState.number_event == 25)
		{
			text2 = "Банда четырех";
			text = "Теперь, когда наш Председатель Мао Цзэдун скончался, в КПК вновь разгорелась внутрипартийная борьба. С одной стороны, стоят четыре наиболее приближенных к Великому Кормчему сторонника линии на продолжение Культурной революции, но при курсе на нормализацию отношений с СССР: Цзян Цин - супруга Мао и глава Группы по делам Культурной революции при ЦК КПК, Ван Хунвэнь - видный партиец, который на X съезде партии фактически был объявлен преемником Мао, Чжан Чуньцяо и Яо Вэньюань. С другой - набирающие силу реформаторы во главе с опальным идеологом полурыночных реформ начала 70-х Дэн Сяопином, которые выступают за скорейшее сворачивание Культурной революции и начало масштабных рыночных реформ при неизменности антисоветского курса. Причём именно леворадикалы в данный момент представляют для нашей власти наибольшую угрозу, однако для их нейтрализации потребуется вступить в союз с реформаторами, такими как министр обороны Е Цзяньин. Может лучше всё же с ними договориться и использовать для борьбы с реформаторами?";
		}
		else if (GlobalScript.inst.gameState.number_event == 26)
		{
			text2 = "Непрочный альянс";
			text = "Шаткий компромисс между Гофэном и леворадикалами трещит по швам. Откровенное недовольство соглашением многих более умеренных партийцев сильно подорвало позиции нынешнего председателя, а его мягкость в решении этих вопросов грозит привести к непредсказуемым последствиям. Более того, четвёрка требует более решительных мер против оппозиции и ревизионистов в партии, а заодно дальнейшего расширения своих полномочий для следования курсу Мао. Если это продолжится и дальше Гофэну придется всё больше и больше передавать власть в руки левых. Ван Дунсин – лидер Отряда 8341, сохраняющий лояльность председателю, все еще готов помочь в борьбе с ними. Хотя, учитывая возросшую, благодаря компромиссу в октябре, силу левых, возможно лучшим решением будет убрать лишь наиболее амбициозных Цзян Цин и Ван Хунвэня, сохранив соглашение с остальными?";
		}
		else if (GlobalScript.inst.gameState.number_event == 1)
		{
			text2 = "Выборы, выборы, кандидаты...";
			text = "Настал день проведения всенародных выборов в ВСНП. И раз уж мы занимаем господствующее положение в китайской политике, то можем немного вмешаться в их проведение, чтобы после них всё так и оставалось. Или же просто положиться на веру в нас китайского народа.";
		}
		else if (GlobalScript.inst.gameState.number_event == 27)
		{
			text2 = "Судьба Гонконга и Макао";
			text = "С давних времён китайские территории Гонконг (Сянган) и Макао (Аомынь) находились под британским и португальским колониальным управлением. Однако фашистский режим \"Нового государства\" в Португалии был свергнут в 1974, 99-летний срок аренды Британией прилегающих к Гонконгу Новых Территорий подходит к концу, да и обе страны находятся под давлением Декларации ООН о деколонизации 1960 года, поэтому они готовы пойти на компромисс, и это наш шанс вернуть то, что наше по праву. Разумеется, они никогда добровольно не передадут колонии, если не будут убеждены в неприкосновенности собственности своих и иностранных граждан, но также попытаются добиться для этих территорий широкой автономии от КНР.";
		}
		else if (GlobalScript.inst.gameState.number_event == 28)
		{
			text2 = "Конец азиатского Пиночета";
			text = "Захвативший власть в Индонезии в 1965 году генерал-майор Сухарто сразу приступил к уничтожению своих политических противников, в особенности коммунистической партии. Только за 1965-66 года по обвинениям в симпатии к коммунистам было убито около 3 миллионов человек. Досталось и национальным меньшинствам, в том числе китайцам, которые до сих законодательно подвергаются дискриминации. Свой репрессивный режим Сухарто удавалось поддерживать за счёт поддержки США и выгодных экономических контактов со странами Юго-Восточной Азии. Однако теперь, когда мы отрезали Индонезию от большинства её партнёров, вызвав коллапс её экономики, в стране идёт активное протестное движение. И хотя многие протесты идут под левыми лозунгами, их явно недостаточно для социалистической революции.";
		}
		else if (GlobalScript.inst.gameState.number_event == 29)
		{
			text2 = "Империализм по-китайски";
			text = "В КНДР уже долгое время идут процессы отхода от марксизма-ленинизма и замены его на самобытную идеологию чучхе с элементами мистицизма и традиционализма и культом личности Ким Ир Сена. Всё это сопровождается периодическими репрессиями против политических противников Ким Ир Сена. Экономика КНДР сильно зависит от контактов с Китаем и нашей помощи, так что наши недавние санкции стали для неё тяжёлым ударом. И поэтому мы можем потребовать от северокорейского правительства определённых уступок. Только не забывайте, что помощь КНДР оказывает также и СССР...";
		}
		else if (GlobalScript.inst.gameState.number_event == 30)
		{
			text2 = "Конец конфликта?";
			text = "С момента создания в 1948 году Израиля на территории бывшей британской Палестины, проживающее там арабское население, фактически лишенное права на самоопределение и подвергающееся дискриминации со стороны израильских властей, боролось за уничтожение Израиля и создание в Палестине арабского государства, в чём их поддерживали соседние арабские страны. Всё это вылилось в несколько арабо-израильских войн, постоянные обстрелы и теракты против Израиля со стороны Организации Освобождения Палестины и ответные рейды израильской армии. Последний из них, в Ливане, закончился полным провалом, даже не получив поддержки из США, и теперь Израиль готов пойти на переговоры с ООП о статусе палестинцев, в которых мы можем выступить посредниками.";
		}
		else if (GlobalScript.inst.gameState.number_event == 31)
		{
			text2 = "Правильная демократия";
			text = "Восстание в Кванджу, благодаря нашей поддержке, перекинувшееся и на соседние регионы нанесло огромный урон репутации южнокорейского правительства, а наш недавний удар по её экономике привёл к новому всплеску протестов, под нажимом которых Чон Ду Хван согласился провести свободные президентские выборы и даже допустить к ним двух известных лидеров оппозиции - Ким Дэ Чжуна и Ким Ён Сама, первый из которых в частности имеет гораздо более миролюбивые взгляды по отношению к КНДР. Обеспечив ему победу на выборах и надавив на КНДР, мы могли бы привести Корею к долгожданному объединению.";
		}
		else if (GlobalScript.inst.gameState.number_event == 32)
		{
			text2 = "Улан-Баторская весна?";
			text = "С помощью нашего вмешательства в Монголии начались масштабные протесты, призывающие к реформам и отходу от строгой просоветской политики. Не желая повторения событий в Чехословакии и ввода советских войск, МНРП, кажется, готова пойти на некоторые уступки и провести ограниченную демократизацию, подобно Кадару в Венгрии. Мы могли бы это использовать для того, чтобы провести в монгольскую политику и СМИ прокитайски настроенных людей, чтобы обеспечить ей более... независимую внешнюю политику.";
		}
		else if (GlobalScript.inst.gameState.number_event == 33)
		{
			text2 = "Полумесяцем в бровь";
			text = "Зульфикар Али Бхутто был президентом Пакистана с 1971 года и премьер-министром с 1973. Бхутто придерживался курса исламского социализма, что нашло отражение в широких социальных программах и национализации многих отраслей экономики. Во внешней политике он придерживался антиимпериализма и старался строить дружеские отношения с соседними странами, вышел из проамериканской СЕАТО и Британского Содружества, сумел провести разрядку с Индией после Третьей индо-пакистанской войны. Однако, после того, как в марте 1977 победу на выборах одержала партия Бхутто - Пакистанская народная партия - оппозиция обвинила его в фальсификациях и начала протесты, которые Бхутто жёстко подавляет. Всё это не нравится армии, которая во главе с генералом Мухаммедом Зия-уль-Хаком и при поддержке США готовит военный переворот. Предотвратив его и выделив Бхутто материальную помощь на строительство социализма, мы могли бы прочно закрепить свои позиции в Пакистане.";
		}
		else if (GlobalScript.inst.gameState.number_event == 34)
		{
			text2 = "Враги моих врагов";
			text = "После разгрома Банды четырёх власть номинально перешла к вам, однако фактически вы вынуждены делить её с теми, кто помог вам её заполучить - с министром обороны Е Цзяньином, убеждённым реформатором, защищавшим Сяопина во время Культурной революции, и Ли Сяньнянем, более умеренным, но также поддерживающим реформаторов. С другой стороны есть три ваших самых верных сторонника из числа консерваторов - Цзи Дэнкуй, Ван Дунсин и Чэнь Силянь. Если вы хотите, чтобы вам не ставили палки в колёса, следует нанести удар по реформаторам и продвинуть своих сторонников, однако, не вызовет ли такое самоуправство недовольства в партии и не лучше ли ограничиться одним из двух? С другой стороны, если вы нацелены на реформы, то, наверно, полезнее будет договориться с реформаторами. Хотя, кто знает, захотят ли они...";
		}
		else if (GlobalScript.inst.gameState.number_event == 35)
		{
			text2 = "Конец революции";
			text = "После смерти Мао вы взяли курс на сворачивание Культурной революции, и добились в этом определённых результатов - массовых кампаний больше не наблюдается. Однако репрессивная хватка государства времён Культурной революции ещё не ослабла, и реформаторы вместе с народом теперь требуют \"открутить гайки\". Помимо гражданской либерализации, многие считают необходимым также ослабить давление на традиции и религию, многократно возросшие во время Культурной революции. Одни выступают лишь за прекращение антитрадиционалистской риторики с сохранением государственного атеизма, другие предлагают по советскому образцу объявить номинальную свободу совести, держа при этом религиозные учреждения и деятелей под чутким государственным контролем. Вам решать.";
		}
		else if (GlobalScript.inst.gameState.number_event == 36)
		{
			text2 = "Крах коалиции?";
			text = "С 1968 года в Ираке между правящей Баас и Иракской коммунистической партией установилось шаткое сотрудничество в рамках Прогрессивного национально-патриотического фронта Ирака. В мае 1972 2 представителя ИКП официально введены в состав правительства, хотя компартия по-прежнему находилась на неофициальном положении. Однако сотрудничество оказалось недолговременным. С недавнего времени руководство Баас в Ираке вновь начало разворачивать репрессии против коммунистов, однако возможности для сохранения непрочной коалиции ещё есть. Возможно нам стоит как-то вмешаться в ситуацию?";
		}
		else if (GlobalScript.inst.gameState.number_event == 37)
		{
			text2 = "Конец египетского паши";
			text = "С 1970 года Египет возглавляет Анвар Садат. Сразу же после своего прихода к власти, он начал отход от политики Гамаля Абдель Насера и идей панарабизма и арабского социализма - в ходе т.н. \"Майской исправительной революции\" были арестованы почти все соратники Насера, включая вице-президента Али Сабри (сторонника дружбы с СССР и коммунистами), в 1971 году Объединенная Арабская республика была переименована в Арабскую республику Египет, что означало разрыв с курсом на панарабскую интеграцию. А с 1973 года началось сближение Египта с США, что сопровождалось ростом антисоветских настроений и разрывом с Ливией и Сирией. В 1975 году Садат предпринял попытки по дестабилизации правящего Арабского социалистического союза (АСС), а в этом году - невиданное дело - начал переговоры об восстановлении отношений с Израилем! Либерализация экономики и проникновение на египетский рынок иностранного капитала привели к массовому недовольству среди широких слоев населения, а война с некогда братской Ливией окончательно подорвала авторитет Садата. Всю страну захлестнули массовые митинги с требованиями отставки президента. Мы можем воспользоваться этим и добиться возвращения к власти сторонников социалистического курса. СССР и братские арабские страны явно не будут возражать, но вот реакция США будет не столь теплой...";
		}
		else if (GlobalScript.inst.gameState.number_event == 38)
		{
			text2 = "Возвращение к истокам";
			text = "В начале 60-х в КНР для того, чтобы справиться с разрушительными последствиями Большого скачка, под началом Дэн Сяопина и Чжоу Эньлая были запущены масштабные экономические реформы на основе самоуправления и возможности частного землевладения, которые в итоге привели к демонтажу централизованного планирования. Мао не мешал их проведению, так как опасался недовольства со стороны большинства в КПК, которое ещё помнило провал Большого скачка, и понимая их необходимость в то время. Однако теперь Большой скачок далеко позади и, может быть, в этот момент возрождение плана позволит нашей экономике выйти на новый уровень? С другой стороны реформаторское крыло по-прежнему считает, что необходимы дальнейшие реформы в экономике и хочет заняться их разработкой.";
		}
		else if (GlobalScript.inst.gameState.number_event == 39)
		{
			text2 = "Комиссия по \"Решению...\"";
			text = "Смерть товарища Мао Цзэдуна, начало внутрипартийной борьбы в КПК и наш отказ от продолжения курса на т.н. \"Великую пролетарскую Культурную революцию\" вызвали сильное брожение внутри партии. По данным Министерства общественной безопасности, в ряде парторганизаций начинают распространятся идеи о \"неправильности маоцзэдунидей\", \"ошибочности курса КПК\", \"искажении Мао Цзэдуном и его окружением истории страны и партии\" и так далее. Это рискует вызвать раскол в Компартии и полностью перечеркнуть все успехи социалистического развития Китая. Политбюро ЦК КПК приняло решение - начать работу над документом, в котором будет дана официальная оценка всему пути, который прошли КНР и КПК под руководством Мао Цзэдуна с 1949 года, для чего сформировать комиссию из 50 человек. Однако надо решить, кто её возглавит, и определить примерный состав. Помните, что ваше решение будет иметь далеко идущие последствия и может привести к пересмотру всей идеологической линии КПК.";
		}
		else if (GlobalScript.inst.gameState.number_event == 40)
		{
			text2 = "Судьба Панчен-Ламы";
			text = "Товарищ Председатель, в ЦК пришло письмо от большой группы тибетского духовенства, в котором они настоятельно просят Вас рассмотреть вопрос об освобождении из тюрьмы Панчен-Ламы X (Панчен-Лама - второй по рангу лама после Далай-ламы в школе Гелуг тибетского буддизма - примечание МГБ). Лобсанг Тринле Лхундруп Чокьи Гьялцен, он же Панчен-Лама X, в сентябре 1949 года отказался бежать с гоминьдановцами на Тайвань и поддержал образование КНР, в дальнейшем сыграв важную роль в воссоединении Тибета с нашей Родиной. Однако затем он резко осудил китаезацию Тибетского автономного района, за что в 1964 году был объявлен \"врагом тибетского народа\", арестован и заключен в пекинскую тюрьму Циньчэн, где и пребывает в настоящий момент. Мы можем освободить его, тем самым существенно улучшив отношения с тибетскими монахами и населением автономии. Но есть ли смысл в этом? Может, лучше ликвидировать ненадежного ламу и добиться избрания Панчен-Ламой нашего ставленника Гьялцэна Норбу?";
		}
		else if (GlobalScript.inst.gameState.number_event == 41)
		{
			text2 = "Индийские выборы";
			text = "Бывшая премьер-министром Индии с 1966 года Индира Ганди, глава ИНК, за время своего правления проводила активные левые реформы в социально-экономической сфере, чем даже спровоцировала раскол в ИНК и выход из него правого крыла. За время её правления были достигнуты значительные успехи в экономике и борьбе с бедностью, однако длящееся в стране с 1971 года чрезвычайное положение играет на руку оппозиции из Джаната парти, которая обвиняет Ганди в коррупции, непотизме и авторитаризме. В этих условиях Ганди решила организовать досрочные парламентские выборы. С учётом того, что Ганди всегда проводила просоветскую и недружественную к КНР политику, а также вступала в конфликты с дружественным нам Пакистаном, лишь недавно пойдя на разрядку в этих вопросах, победа оппозиции могла бы усилить наше влияние. Джаната парти объединяет людей разных взглядов от социалистов до консерваторов и внятной программы не имеет, однако тем проще будет нам ей управлять. Хотя может быть, если мы поможем Индире, то она запомнит это и продолжит движение к восстановлению наших отношений?..";
		}
		else if (GlobalScript.inst.gameState.number_event == 42)
		{
			text2 = "Иранская революция";
			text = "В шахском Иране уже какое-то время идут протесты, направленные против трудного социально-экономического положения народа, проамериканской политики шаха, повальной коррупции правящих элит и притеснений шиитского духовенства со стороны государства. Однако сегодня протесты перешли в горячую фазу, после того как в Куме полицией была расстреляна антиправительственная демонстрация, поводом для которой стала клеветническая статья об аятолле (высший духовный титул шиитского ислама) Хомейни, являющимся духовным лидером протестов и высланном из страны в 1964-м. После этого протесты, забастовки и стачки охватили многие города Ирана. Движущими силами начинающейся революции являются исламистские движения, такие как Движение за свободный Иран и Общество борющегося духовенства, однако на свержение шаха также работают и другие организации, наиболее крупными из которых являются демократический Национальный фронт Ирана и марксистко-ленинская Народная партия Ирана. Революция в Иране способна кардинально изменить расклад сил на Ближнем Востоке, так может нам стоит вмешаться?";
		}
		else if (GlobalScript.inst.gameState.number_event == 43)
		{
			text2 = "Расширение СЭВ";
			text = "Вьетнам долгое время старался балансировать между нами и СССР, ведь несмотря на наши с советами разногласия, наши добровольцы вместе воевали в Индокитайских войнах на стороне социалистического Вьетнама. Впрочем уже с окончанием войны и объединением, Вьетнам постепенно становился всё более просоветским, всё больше отдаляясь от нас.|";
			text = ((GlobalScript.inst.gameState.allcountries[23].Gosstroy == 0 && !GlobalScript.inst.gameState.allcountries[23].EAF) ? (text + "После поездки Ле Зуана в Москву в 1977 наметилось дальнейшее сближение Вьетнама и СССР с перспективой вступления с СЭВ, куда он и собирается вступить со дня на день. Помешать этому мы, видимо, не сможем, не в последнюю очередь из-за того, что Вьетнам хочет заручиться советской поддержкой против Пол Пота в прокитайской Камбодже.") : (text + "После поездки Ле Зуана в Москву в 1977 наметилось дальнейшее сближение Вьетнама и СССР с перспективой вступления с СЭВ, куда он и собирается вступить в ближайшее время. Однако, часть руководства страны выступает против столь ярого сближения с СССР, ведь особых угроз для Вьетнама, особенно после свержения Пол Пота в Камбодже, в Азии сейчас нет. И это наш шанс вмешаться и остановить распространение советской гегемонии."));
		}
		else if (GlobalScript.inst.gameState.number_event == 44)
		{
			text2 = "Неважно, какого цвета кошка...";
			text = "Ваше желание продолжать консервативную политику, совершенно не соответствующее уменьшающейся силе ваших сторонников, привело в итоге к масштабному недовольству реформаторского крыла КПК, поддерживаемого умеренными. Они хотят вашего отстранения от власти и требуют начала обширных рыночных реформ с привлечением иностранных инвестиций и выходом Китая на мировой рынок, аргументируя это тем, что \"экономика должна превалировать над идеологией \". Именно это вам на нынешнем пленуме ЦК КПК говорит их лидер - " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2] + ", с которым соглашается большинство присутствующих. Нужно, что-то делать, если не хотите лишиться власти!";
		}
		else if (GlobalScript.inst.gameState.number_event == 45)
		{
			text2 = "Реформы и открытость: начало";
			text = "После объявления курса на рыночные реформы наши экономисты разрабатывали план первых реформ и наконец представили его, чтобы руководство КПК смогло его утвердить. Он включает в себя расширение прав отдельных госпредприятий, внедрение рыночных методов их работы и поощрение мелкого частного и кооперативного предпринимательства.";
		}
		else if (GlobalScript.inst.gameState.number_event == 46)
		{
			text2 = "Новый 1956-й?";
			text = "Интересные известия пришли из Венгрии. Бела Биску - консервативный коммунист, активно участвовавший в подавлении венгерского восстания в 1956-м и бывший министром внутренних дел с 1957 по 1961, а ныне являющийся секретарём ЦК ВСРП, всегда выступал против экономических и политических либеральных реформ Кадара. Поняв, что словами его не остановить, он сколотил вокруг себя группу таких же консерваторов и решил организовать внутрипартийный переворот, попросив при этом поддержки у главы КГБ Юрия Андропова. Однако, по нашим данным, Андропов попросту \"сдал\" планы Биску Кадару, о чём сам Биску ещё не знает. Сейчас у нас есть шанс помочь Биску своими агентами и вернуть Венгрию на путь построения настоящего социализма. Или же всегда можно с помощью небольших поставок оружия и координации разведки попробовать поднять новое восстание в Венгрии - на сей раз истинно коммунистическое и прокитайское - ведь тогда Венгрия гарантированно будет нашей! Но действовать надо быстро.";
		}
		else if (GlobalScript.inst.gameState.number_event == 47)
		{
			text2 = "Пекинская весна";
			text = "С середины этого года по всей стране и особенно в Пекине началась бурная активность студентов и интеллигенции, которая развешивает дацзыбао (настенные газеты с большими иероглифами, используемые для пропаганды и выражения протеста) по улицам и издаёт самодельные журналы. Дацзыбао и журналы содержат критику против консерватизма КПК, критику Культурной революции, призывают к экономической и политической либерализации и выражают поддержку реформаторам в КПК, чем активно пользуется либеральная фракция. Это притом, что сами реформаторы уже в 1977-м активно выпускали в подконтрольных им журналах и газетах статьи с критикой нашей политики заявляя, что она \"не сходится с марксизмом\", что \"экономика должна превалировать над идеологией \" и что \"прагматизм - единственный критерий для выявления истины\", описывая практические преимущества рыночных реформ в своём видении.";
		}
		else if (GlobalScript.inst.gameState.number_event == 63)
		{
			text2 = "Апрельская революция";
			text = "Срочные новости! 27 апреля в Афганистане в результате нестабильности власти, обнищания и недовольства народа арестом лидеров левой оппозиционной партии НДПА произошёл военный переворот заранее спланированный НДПА. Население в целом приветствовало революцию. Придя к власти, НДПА во главе с Н. М. Тараки начала построение социализма и ориентацию на СССР. Однако, будущее Афганистана ещё туманно, так как в самой НДПА остаётся непреодолённый раскол между фракциями Хальк и Парчам, которые с 1966 по 1977 существовали фактически как 2 независимые партии. Хальк, состоящая преимущественно из малообеспеченных и полупролетарских слоёв, в ходе оппозиционной деятельности фокусировалась на нелегальной работе и выступала за революционную борьбу, а ныне стремится организовать быстрый переход страны к социализму и диктатуре пролетариата. Парчам же, в годы оппозиции отдававшая приоритет легальной и парламентской борьбе, сейчас выступает за постепенные, общедемократические преобразования и в целом склонна к реформизму, считая, что Афганистан не готов к построению социализма. У нас же тем временем КПК серьёзно обеспокоена таким расширением советского влияния в регионе.";
		}
		else if (GlobalScript.inst.gameState.number_event == 48)
		{
			text2 = "Перевороты продолжаются";
			text = "После апрельской революции НДПА столкнулась со многими трудностями, а в стремительно набирающей силу фракции Хальк уже началась борьба между одним из основателей НДПА Тараки и его учеником Амином. Амин является сторонником радикальной политики, бескомпромиссной борьбы с феодальными пережитками и жесткого подавления политических оппонентов. При этом он же, будучи ярым пуштунским (доминирующий народ Афганистана - прим.) националистом, во многом отвественнен за саботаж национальной политики НДПА и он же, стараясь сконцентрировать в своих руках власть, поддерживал раскол между Хальк и Парчам. Несмотря на то, что советское руководство многократно предупреждало Тараки о заговорщицких планах Амина, он так и не прислушался до самого последнего момента. 14 сентября в ходе визита Амина к Тараки на первого было совершено нападение (точно неизвестно, реальное или инсценированное самим Амином), а 16 сентября Амин на пленуме ЦК НДПА отстранил Тараки от его обязанностей, предварительно изолировав его лояльными частями армии в резиденции. Примечательно, что, хоть Амин и старался поддерживать хорошие отношения с СССР, по нашим данным, он совсем не против наладить близкие отношения с КНР и это может быть наш шанс.";
		}
		else if (GlobalScript.inst.gameState.number_event == 49)
		{
			text2 = "Против всех тиранов";
			text = "После недавнего переворота Амина СССР всячески искал способы устранить нерадивого узурпатора. По нашим данным, советское руководство установило контакт с бежавшими из Афганистана из-за чисток Амина членами НДПА из разных фракций, такими как Кармаль, Сарвари и Ватанджар, и готово использовать их для замены Амина. Ключевым пунктом плана является нейтрализация Амина и лояльного ему окружения советским спецназом, прикрытие действий которого должны обеспечить советские войска, которые с начала года настойчиво просила ввести НДПА и лично Амин, несмотря на постоянные отказы СССР. Однако, похоже, что под нажимом обстоятельств советские лидеры решили изменить решение, и первые советские подразделения пересекли границу ещё 25 декабря с задачей взять под охрану важные военные объекты и объекты советско-афганского сотрудничества. Сейчас наш шанс перехватить инициативу в Афганистане, если удастся предотвратить смещение Амина. Однако сделать это можно только при наличии хороших отношений с СССР, иначе он расшибётся, но не отдаст нам Афганистан.";
		}
		else if (GlobalScript.inst.gameState.number_event == 50)
		{
			text2 = "Проклятый горный дикий край...";
			text = "После недавних событий, способствовавших ухудшению обстановки в Афганистане, давно начавшееся восстание исламистов и прочих реакционеров, поддерживаемых США перешло в горячую фазу. СССР же в соответствии с принятым недавно планом вводит в Афганистан войска по просьбе правительства ДРА, что уже вызвало волну негодования на западе. Несмотря на то, что население первоначально встретило советские войска довольно дружелюбно, участились случаи нападения на них боевиков. Вместе с тем задачи ограниченного контингента, изначально включавшие лишь охрану важных объектов, постепенно расширяются и, кажется, в итоге дойдут до полноценного его участия в боевых действиях. Битва за Афганистан началась и надо бы решить, кого мы в ней поддержим.";
		}
		else if (GlobalScript.inst.gameState.number_event == 51)
		{
			text2 = "Постоят и уйдут...";
			text = "После апрельской революции НДПА столкнулась со многими трудностями, связанными с недостатком опыта у её членов и обилием феодально-религиозных пережитков в Афганистане, однако, благодаря относительному равенству сил двух фракций НДПА, удавалось избегать крупных политических конфликтов. В частности членам как Парчам так и Хальк при поддержке СССР удалось удалить Х. Амина из правительства и ЦК с обвинениями в нарушении принципов коллективного руководства и пуштунском национализме. Однако восстания реакционных слоёв, особенно исламистов, начавшиеся ещё в начале года, набирают силу. К ним присоединяются некоторые граждане Пакистана и Ирана, незаконно пересекая границу, и даже США умудряются как-то протащить в Афганистан своё оружие и советников в помощь моджахедам. В этих условиях СССР по многочисленным просьбам афганского руководства решил ввести небольшой контингент своих войск, который должен будет охранять важные военные объекты и города, высвобождая силы армии ДРА для борьбы с повстанцами. Похоже, что масштабного их участия в боевых действиях не предвидится, однако Запад уже осудил это, назвав вторжением.";
		}
		else if (GlobalScript.inst.gameState.number_event == 52)
		{
			text2 = "Непростое соседство";
			text = "С самого начала антиправительственных выступлений в Афганистане и ответных мер правительства ДРА многие исламские радикалы, террористы и священники бежали в Пакистан, где объединились со своими местными \"коллегами\". Впоследствии после начала вооружённых бунтов в Афганистане во всё тот же Пакистан потекли беженцы, которых с распростёртыми объятиями в своих рядах ждали сформировавшиеся там исламские террористические организации. Сам Пакистан не принимает по отношению к ним особых мер сверх обычного, похоже у Бхутто там своих проблем хватает, но может стоит выделить ему агентурную помощь, дабы прекратить подобные безобразия? С другой стороны в возможности помогать афганским повстанцам через Пакистан очень заинтересованы США, и если с США Бхутто ни в каком варианте не будет договариваться, то с нами - вполне. Перевозя американское вооружение и советников через Пакистан мы могли бы \"состричь\" с американцев денег и ударить по советскому социал-империализму.";
		}
		else if (GlobalScript.inst.gameState.number_event == 53)
		{
			text2 = "Реформа сельского хозяйства";
			text = "Во время Большого скачка почти всё сельское хозяйство Китая было организовано в сельскохозяйственные коммуны, прославившиеся тотальным обобществлением инвентаря и личных вещей, провальными экспериментами с кустарной выплавкой стали и отвратительной производительностью. После реформ Чжоу Эньлая коммуны были частью преобразованы, частью распущены, однако в изменённом варианте по прежнему продолжают работу. Многие в КПК считают, что пора уже реформировать сельское хозяйство, однако единого мнения нет. Умеренные и реформаторы предлагают введение системы семейного подряда, подразумевающего создание на селе семейного предпринимательства с обязательными госзакупками. Другая часть реформаторов предлагает ввести систему полноценного частного фермерства. Придётся выделить начинающим предпринимателям кредиты на необходимые закупки, однако реформаторы обещают, что эти затраты уже в краткосрочной перспективе окупятся с лихвой. А часть партии предлагает вернуться к истокам организовать систему коллективных хозяйств по советскому образцу, что позволит преодолеть технологическую отсталость, ведь у Сталина же получилось? Правда на необходимую механизацию нужны деньги...";
		}
		else if (GlobalScript.inst.gameState.number_event == 54)
		{
			text2 = "Реформы и открытость: инвестиции";
			text = "В рамках политики реформ и открытости в соответствии с заявленным курсом нам необходимо заняться привлечением иностранных инвестиций. Реформаторы предлагают создать на побережье несколько специальных экономических зон с налоговыми льготами, минимумом государственного контроля и прочими послаблениями для иностранных инвесторов, где они могли бы строить свои предприятия и вкладываться в совместные проекты. Впрочем, более радикальные деятели предлагают помимо создания СЭЗ полностью открыть экономику для иностранных инвестиций путём создания системы совместных предприятий, при которой иностраны смогу вкладываться в наши государственные предприятия в обмен на часть прибыли. Большая прибыльность второго варианта очевидна, однако умеренные и даже некоторые реформаторы критикуют его за поспешность.";
		}
		else if (GlobalScript.inst.gameState.number_event == 55)
		{
			text2 = "Бирманский путь к социализму";
			text = "После военного переворота в 1962-м власть в Бирме перешла к У Не Вину и возглавляемой им Партии бирманской социалистической программы, провозгласивших построение \"бирманского социализма\". Впрочем этот \"социализм\" характеризовался сохранением частного сектора, взращиванием шовинистских религиозных и национальных предрассудков, фактически уходом в изоляцию а также массовыми репрессиями всех противников Не Вина. Поэтому различные левые силы, попавшие в партию после начала открытого массового набора в 1971, начали всё больше противостоять У Не Вину и его политике. По нашим данным в Партии бирманской социалистической программы готовятся массовые чистки против коммунистов и других левых и, если мы до этого уже шли на контакт с Бирмой, то могли бы с помощью наших спецслужб изменить расклад сил в их пользу. Однако мы также можем оказать руководству Бирмы дополнительную помощь и укрепить наши отношения.";
		}
		else if (GlobalScript.inst.gameState.number_event == 56)
		{
			text2 = "Преподать Вьетнаму урок?";
			text = "В последнее время соседний Вьетнам всё больше сближается с СССР, и это несмотря на нашу помощь ему в гражданской войне! В связи с этим всё больше партийцев считают, что нужно \"преподать Вьетнаму урок\". План, который уже некоторое время разрабатывали в НОАК прост - под предлогом периодически случающихся стычек на границе объявляем ему войну, захватываем приграничные области, уничтожаем прибывающие части вьетнамской армии и по мере возможности продвигаемся вглубь страны. Такой удар вынудит их руководство серьёзно пересмотреть свою политику в отношении КНР и СССР. Впрочем, часть партийцев считает, что если наши отношения с Вьетнамом ещё не настолько испорчены, то имеет смысл договориться с ним, урегулировав наши территориальные претензии и уговорив прекратить притеснения этнических китайцев во Вьетнаме. Однако можно и ничего не делать, ведь худой мир лучше доброй войны, ведь так?";
		}
		else if (GlobalScript.inst.gameState.number_event == 57)
		{
			text2 = "Красное восходящее солнце";
			text = "Вскоре в Японии должны пройти выборы в Палату представителей японского парламента. На фоне нестабильности правительства и коррупционных скандалов Коммунистическая Партия Японии уверенно набирала популярность в последнее время, как и различная левоцентристская оппозиция. Если мы имеем влияние на КПЯ, то могли бы оказать ей помощь в предвыборной агитации. В случае победы, мы смогли бы наладить отношения с нашим историческим противником и наконец выдворить американские базы из Японии.";
		}
		else if (GlobalScript.inst.gameState.number_event == 58)
		{
			text2 = "Иранская революция: финал";
			text = "Весь прошлый год протесты сотрясали Иран - левые, светские демократы и мусульманские организации различной степени радикализма словом и делом выступали против власти шаха, организуя множественные стачки и забастовки.|";
		}
		else if (GlobalScript.inst.gameState.number_event == 59)
		{
			text2 = "Экономический союз";
			text = "Товарищ председатель! В связи со сложившейся ситуацией на международной арене, ряд партийцев предлагает организовать свою альтернативу советскому экономическому альянсу – СЭВ и европейскому - ЕЭС, чтобы продолжить политику расширения нашего влияния и углубить торгово-экономические связи между лояльными Пекину странами. Однако некоторые члены Политбюро считают этот шаг слишком поспешным, радикальным и необдуманным и предлагают отложить это дело до лучших времён. Хотя, возможно, лучшим вариантом будет забыть все распри с Советским Союзом и вступить в Совет экономической взаимопомощи?";
		}
		else if (GlobalScript.inst.gameState.number_event == 60)
		{
			text2 = "Военный альянс";
			text = "После более чем благополучного создания нашего экономического союза, некоторые партийцы предлагают закрепить успех, объединив все дружественные нам страны в единый военный альянс, тем самым заняв свою нишу в окружении военных баз европейского НАТО и советской ОВД. Однако наиболее прагматичные сопартийцы предлагают отказаться от этой инициативы, аргументируя это тем, что наши необдуманные и радикальные действия могут развязать новый виток холодной войны, но уже с третьей влиятельной силой. Впрочем, Китай сейчас силён как никогда, и лишние союзники ему не помешают, не так ли? ";
		}
		else if (GlobalScript.inst.gameState.number_event == 61)
		{
			text2 = "Проблема гимна";
			text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "! Как Вам известно, гимном нашей страны с 1949 года являлся \"Марш добровольцев\" Не Эра-Тянь Ханя. Однако во время т.н. \"Культурной революции\" Тянь Хань был арестован по ложному обвинению и скончался в тюрьме, а гимном де-факто стала популярная в народе песня \"Алеет Восток\", прославляющая покойного Председателя Мао Цзэдуна. Теперь, когда мы прекратили \"Культурную революцию\" и посмертно реабилитировали Тянь Ханя, а также нормализовали ситуацию в стране, встал вопрос о госсимволике. Большая группа партийцев предлагает восстановить \"Марш добровольцев\" в качестве гимна уже официально, однако Ваши соратники, в принципе соглашаясь с этим, считают, что надо изменить текст гимна, добавив туда упоминания Председателя Мао и КПК. Правда для обоих этих вариантов нужны будут деньги на преобразования. В то же время, оставшиеся в партии радикальные маоисты обратились к Вам с письмом, в котором предложили придать статус гимна \"Алеет Восток\"...";
		}
		else if (GlobalScript.inst.gameState.number_event == 62)
		{
			text2 = "Проблемы наследников Чингисхана";
			text = "После победы над Гоминьданом в 1949 году районы Китая, населенные некитайским населением, получили автономный статус, по образцу СССР. Одним из них является Внутренняя Монголия, где проживают этнические монголы. В ходе т.н. \"Культурной революции\" центральные власти начали силовую ассимиляцию монгольского населения, что вылилось в массовые столкновения с хунвэйбинами и беспорядки 1967-1969 годов. В 1969 году большая часть территории Внутренней Монголии была прирезана к соседним китайским провинциям таким образом, что численность монголов в ней упала до 600 тыс. чел., общая численность населения автономного района упала с 13 до 9 млн человек. Теперь, когда КПК признала ошибочность этой политики, представители Совета народных представителей АР Внутренняя Монголия и монголы-коммунисты предлагают исправить ошибку Мао и восстановить справедливость, вернув в состав АР отобранные у него земли и прекратив политику ассимиляции. Это явно не понравится левому крылу КПК, но может помочь заручиться поддержкой национальных элит. Кроме того, МНР и СССР явно понравится такой шаг.";
		}
		else if (GlobalScript.inst.gameState.number_event == 64)
		{
			text2 = "Панарабизм";
			text = "Идеи создания объединённого государства всех арабов на Ближнем Востоке витала в умах арабских правителей и интеллигенции ещё со времён колониального владычества иностранцев в этих землях. Она нашла своё отражение в Объединённой Арабской Республике, состоявшей из Сирии и Египта и существовавшей с 1958 по 1971, однако из-за стремления президента Египта Насера - известного панарабиста - централизовать власть в Египте, Сирия в 1961 году вышла из неё. Впоследствии в 1971 году была создана конфедеративная Федерация Арабских Республик из Египта, Сирии и Ливии. Однако существовали противоречия между её участниками, заключавшиеся прежде всего в либеральной прозападной политике пришедшего к власти в Египте после Насера Садата. Но теперь Садат устранён, а в Египте к власти пришли сторонники старого президента Насера, благодаря чему ФАР формально существует до сих пор, а идеи слияния арабских государств вновь заняли умы правящих кругов. Тем более, 30 июля Израиль провозгласил Иерусалим \"вечной и неделимой столицей Израиля\", чем вызвал волну недовольства в арабском мире, дав ещё один повод к объединению против общего врага. Выделив некоторую материальную помощь и поспособствовав устранению недовольных таким развитием событий, мы могли бы возродить ОАР, чем серьёзно бы изменили баланс сил на Ближнем Востоке и заполучили бы ценного союзника. Если, конечно, они нас послушаются...";
		}
		else if (GlobalScript.inst.gameState.number_event == 65)
		{
			text2 = "До свидания, наш ласковый Мишка...";
			text = "Товарищ Председатель! 19 июля 1980 года в Москве состоится открытие XXII летних Олимпийских игр. Советский Союз с трудом добился права на проведение Олимпиады у себя и потратил на её подготовку громаднейшие средства, которые пришлось изымать из других расходных статей (для возмещения затрат была организована масштабная кампания по продаже олимпийской символики). Однако руководство США уже открыто заявило о бойкоте этих Игр и призвало к этому всех своих союзников, организовав так называемые «Олимпийские игры бойкота» (более известные под названием \"Колокола свободы\") в Филадельфии. Ряд партийцев призывают нас последовать американскому примеру и бойкотировать советские игры, отправив команду на американские - однако это вызовет гнев СССР и непонимание в народе. Может быть, не стоит усугублять раскол и отправить наших спортсменов в Москву, несмотря на существующие между нашими странами политические противоречия? Спорт же вне политики...";
			if (GlobalScript.inst.gameState.is_party_enabled[0])
			{
				text += "|Однако группа партийцев, вспоминая опыт GANEFO 1963 года (проведенных президентом Индонезии доктором Сукарно при нашей фин. помощи альтернативных Игр стран \"третьего мира\"), предлагает нам возродить эти Игры и показать СССР и США, что мы независимы от них и в сфере спорта.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 66)
		{
			text2 = "И после Тита - Тито!";
			text = "3 января 1980 года основатель и многолетний руководитель Социалистической Федеративной Республики Югославия, Председатель ЦК Союза коммунистов Югославии, маршал Иосип Броз Тито был госпитализирован в клинический центр Любляны для проверки кровеносных сосудов в ногах. В результате двух операций и ампутации левой ноги, его состояние несколько улучшилось, но в феврале Тито перенёс пневмонию: высокая температура и кровотечение в желудке, кишечнике и лёгких ещё и привели к сепсису, который усиливался в течение марта. И вот сегодня наступила развязка - в 15:05 по белградскому времени в клинике сердечно-сосудистых заболеваний клинического центра в Любляне, за три дня до своего 88-летия, Иосип Броз Тито скончался. Похороны состоятся 8 мая и нам надо решить - имеет ли смысл отправить в Белград делегацию или стоит ограничиться соболезнованиями? Несмотря на наши идеологические разногласия и разрыв дип. отношений, Тито был одним из героев Антифашистской войны и имеет смысл отдать ему долг памяти. СССР и США уже заявили, что отправят на церемонию похорон официальные правительственные делегации, однако президент США Картер в Белград не поедет... Может, и товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " не должен ехать, отправив во главе делегации Цзи Пэнфэя с ограниченными полномочиями? ";
			if (GlobalScript.inst.gameState.allcountries[20].proprc)
			{
				text += "Однако наши союзники-албанцы уже заявили, что, хотя и будут рады восстановить с Югославией торговые и культурные связи, но критику \"ревизиониста Тито и титоизма\" ни за что не прекратят. Если мы отправим делегацию - то вполне можем оттолкнуть их от нас.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 67)
		{
			text2 = "Ещё Польша не погибла?";
			text = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", из Варшавы приходят тревожные новости - 6 сентября, состоялся VI Пленум ЦК Польской объединенной рабочей партии, принявший решение об отставке возглавлявшего партию и страну 10 лет Эдварда Герека и замены его на компромиссного Станислава Каня. Страна сейчас находится в тяжелейшем политическом и экономическом кризисе, объединенная при помощи ЦРУ антисоциалистическая оппозиция, возглавляемая т.н. \"независимым самоуправляемым профсоюзом\" \"Солидарность\", вот уже почти год как устраивает массовые забастовки, митинги, шествия. Громадный госдолг (почти 40 млрд. долларов), накопленный при прошлых руководствах страны, ПНР не в состоянии выплатить. Ситуация явно вышла из-под контроля ПОРП, СССР уже всерьез начинает рассматривать вариант вооруженного вмешательства в дела Польши по примеру Чехословакии-1968. Сейчас, пока обстановка в стране чрезвычайно нестабильна, у нас есть прекрасная возможность вмешаться и, воспользовавшись нерешительностью Кани, добиться прихода к власти в Польше национально ориентированных сил во главе с Альбином Сиваком и Казимежем Миялем. Однако это вызовет огромное недовольство СССР и большие затраты, так что - быть может, нам и не нужна эта Польша?..";
		}
		else if (GlobalScript.inst.gameState.number_event == 68)
		{
			text2 = "Восстание в Кванджу";
			text = "После путча в декабре 1979 года захвативший власть в Южной Корее Чон Ду Хван начал беспощадное подавление протестующих против военного режима. 17 мая было введено военное положение, а 18 мая студенческую демонстрацию в городе Кванджу против закрытия Национального Университета Чхоннам расстреляли военные. Это вызвало бурю недовольства в городе и повлекло ещё большие беспорядки, в ходе которых восставшим удалось захватить полицейские и военные склады и вытеснить армейские части из города. По нашим данным правительство Чон Ду Хвана готовит захват Кванджу силами регулярной армии. Оказав поддержку восставшим, чтобы они смогли продержаться подольше, и направив силы наших спецслужб на разжигание недовольства в смежных регионах, мы могли бы серьёзно дестабилизировать южнокорейский режим.";
		}
		else if (GlobalScript.inst.gameState.number_event == 69)
		{
			text2 = "Ещё одна банда?";
			text = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", благодаря вашим усилиям, мы смогли покончить с пережитками Культурной революции, а страна вовсю идёт к светлому рыночному будущему! Однако всё ещё остаются те, кто не согласен с таким развитием событий и всеми силами протестуют против проведения подобной политики, срывая благие реформаторские начинания. Это преимущественно консервативные маоисты, возглавялемые четырьмя высшими партийцами, сопротивляющиеся дальнейшим реформам. Ударив по ним и их сторонникам, мы смогли бы сильнее консолидировать власть в руках реформаторов. Более того - на освободившиеся от консерваторов места можно будет продвинуть активных сторонников реформ, снискавших себе популярность в народе, и их подопечных.";
		}
		else if (GlobalScript.inst.gameState.number_event == 70)
		{
			text2 = "Проблемы наследников Чжоу Эньлая";
			text = "Товарищ " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", благодаря вашим усилиям мы смогли продолжить движение в светлое коммунистическое будущее, как завещал председатель Мао! Все попытки реформаторов пошатнуть нашу систему и уничтожить социалистические завоевания, повернув Китай на путь капитализма, провалились. Однако многие из них ещё обладают достаточным влиянием и продолжают продвигать свои ревизионистские идеи, и с этим надо что-то делать. Наиболее радикальные ваши сторонники предлагают не церемониться с ревизионистами и просто арестовать их лидеров и начать кампанию против реформаторов, однако едва ли партия и народ одобрят такое самоуправство, так что можно попробовать решить всё в залах заседаний КПК. И надо решить, как поступить с умеренными - после смерти Мао большинство из них поддержали реформаторов, однако теперь некоторые начинают колебаться...";
		}
		else if (GlobalScript.inst.gameState.number_event == 71)
		{
			text2 = "Алеет восток...";
			text = "Благодаря нашей поддержке маоисты-повстанцы на востоке Индии, известные как наксалиты, обрели значительное влияние и некоторую общественную поддержку в восточных штатах. Они контролируют значительные территории, а их постоянные теракты стали головной болью, как для восточных штатов, так и для центрального правительства Индии. Некоторые индийские политики уже задумываются о переговорах с ними и мы могли бы использовать это для проведения наксалитов в местные органы власти восточных штатов, выступив посредниками на переговорах, что значительно повысило бы наше влияние на Индию и обеспечило бы относительно лояльное левую политику восточной части Индии. Это при условии, что наксалиты и индийские власти вообще станут с нами разговаривать. Да и сохранение нестабильности в восточных регионах может дать нам возможность для манёвра, не сейчас так в будущем... Впрочем у части генералитета и партии уже созрел план этого манёвра - они предлагают воспользоваться ситуацией и ввести войска на территории в штате Аруначал-Прадеш, на которые мы претендуем, для \"защиты мирного населения и восстановления порядка\", после чего можно будет без особых проблем присоединить их к КНР. Впрочем это будет значить новую пограничную войну с Индией...";
		}
		else if (GlobalScript.inst.gameState.number_event == 72)
		{
			text2 = "Спасение утопающих";
			text = "После победы на индийских выборах 1977-го партия Джаната, представляющая из себя фактически конфедерацию различных партий от социалистов до национал-либералов, столкнулась с кучей трудностей. Первоначально объединённая стремлением отстранить от власти Индиру Ганди и ИНК, теперь после прихода к власти Джаната страдает от внутренних интриг, фактически парализовавших её работу. Такими темпами на грядущих выборах в январе 1980-го неизбежно вновь победит Ганди, что поставит крест на достигнутых Джаната успехах в улучшении наших отношений с Индией. И если мы в своё время помогли оппозиции и имеем влияние на неё, то могли бы помочь ей консолидироваться и удержать власть.";
		}
		else if (GlobalScript.inst.gameState.number_event == 73)
		{
			text2 = "Ирано-иракская война";
			text = "Отношения Ирана и Ирака уже долгое время были натянутыми, главным образом из-за территориальных споров - в 1969 году Иран захватил контроль над рекой Шатт-эль-Араб отданной Ираку по соглашению 1937 года, а в 1971 Иран оккупировал три острова в Ормузском проливе, на которые также претендовал Ирак. Однако после победы исламской революции в Иране ситуация обострилась ещё больше - желая распространить революцию на весь мусульманский мир, Хомейни стал активно засылать агитаторов и агентов в Ирак, а также поддерживать борьбу иракских курдов за независимость. В ответ на это, а также видя, что иранская армия ослаблена революцией и чистками исламистов, Саддам Хусейн принял решение о вторжении в Иран с целью захватить богатую нефтью провинцию Хузестан. 22 сентября около полудня иракские войска вторглись в Иран, встречая ожесточённое сопротивление и на данный момент медленно продвигаются по иранской территории.";
		}
		else if (GlobalScript.inst.gameState.number_event == 74)
		{
			text2 = "Решение по некоторым вопросам истории КПК со времени образования КНР";
			text = "Итак, товарищ Председатель, работа над этим важным документом, начатая нами в 1976 году, завершена. Окончательный вариант «Решения по некоторым вопросам истории КПК» насчитывает 28 тыс. знаков, 84 страницы, напечатанные на китайском, английском, русском, арабском и испанском языках. Далеко не просто было дать анализ деятельности человека, идей, истории, общества, раскрыть сложнейший комплекс причин. Но это, наконец, сделано и VI Пленум ЦК КПК 11 созыва готов рассмотреть документ.";
			if (GlobalScript.inst.gameState.data[90] == 0)
			{
				text += "|В \"Решении\" полностью одобряется тот путь, который мы прошли с 1949 года, а личность Мао Цзэдуна ставится во главу угла. Это, безусловно, должно понравиться народу - но вот партия, одобряя Председателя Мао, вряд ли одобрит оправдание его перегибов...";
			}
			else if (GlobalScript.inst.gameState.data[90] == 1)
			{
				text += "|В \"Решении\" одобряется тот путь, который мы прошли с 1949 года, однако \"выправляется все неправильное и закрепляется все правильное\", а Мао Цзэдуну дана оценка \"70% положительного на 30% отрицательного\". Это, безусловно, понравится и партии, и народу...";
			}
			else if (GlobalScript.inst.gameState.data[90] == 2)
			{
				text += "|В \"Решении\" критикуется тот путь, что мы прошли с 1949 года, а личность Мао Цзэдуна заклеймена. Это понравится отдельным членам партии, однако - я не ручаюсь за последствия, если Пленум одобрит это...";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 75)
		{
			text2 = "Проблемы иракского атома";
			text = "Только что пришли сведения из Ирака - израильская авиация в ходе т.н. операции \"Опера\" нанесла удар по реактору \"Таммуз\", выведя его из строя. В результате этого удара иракская атомная программа завершилась, не успев толком начаться. Саддам сейчас ведет очень агрессивную внешнюю политику, что дестабилизирует и без того напряженную обстановку на Ближнем Востоке. Однако, возможно, мы могли бы помочь Ираку продолжить атомную программу, получив тем самым полезного союзника в этом стратегическом регионе. Хотя я не советовал бы полагаться на надежность Саддама Хусейна - он известный сторонник многовекторной политики, который сотрудничает и с США, и с СССР, и с нами, и с Движением неприсоединения. Возможно, что даже собственная атомная бомба это не изменит...";
		}
		else if (GlobalScript.inst.gameState.number_event == 76)
		{
			text2 = "Падающего - подтолкни!";
			text = "Товарищ Председатель, срочные известия из СФРЮ! В Социалистическом автономном крае Косово начались массовые беспорядки албанского населения, по нашим данным, организованные албанской спецслужбой Сигурими. Протестующие нападают на административные здания, милицейские участки и гарнизоны Югославской Народной армии, начались антисербские погромы. Руководство края и Союза коммунистов Косово не оказывают серьезного сопротивления мятежникам, де-факто поддерживая их. В Белграде состоялось срочное заседание Президиума СФРЮ, которое приняло решение о силовом подавлении \"контрреволюционного сепаратистского мятежа\". После смерти Тито, ситуация в Югославии начала ухудшаться, похоже, монстр Версальского договора начал разваливаться. Так, может, имеет смысл подтолкнуть его ещё сильнее в пропасть?";
		}
		else if (GlobalScript.inst.gameState.number_event == 77)
		{
			text2 = "Плевок в лицо, удар в челюсть и пулю в голову";
			text = "Наши резиденты передают интересные сведения из Албании - похоже там наметился серьёзный раскол между албанским лидером Энвером Ходжей и вторым человеком в партии и государстве - премьер-министром Мехметом Шеху. Долгое время он был ближайшим соратником Ходжи и силами Сигурими обеспечивал стабильность страны, лично курируя подавление нескольких антикоммунистических восстаний в середине 1940-х и известный фразой: \"Кто не согласен с нашей руководящей ролью, тот получит плевок в лицо, удар в челюсть, а если надо — то и пулю в голову\", которую даже (в негативном контексте) цитировали на ХХII съезде КПСС. Однако после произошедшего на фоне хрущёвской десталинизации разрыва Албании с СССР и соцлагерем её экономика начала испытывать трудности от подобной изоляции. В АПТ всё больше людей склоняются к восстановлению отношений с СССР, Югославией и даже с Италией, и к ним, по всей, видимости относится и Шеху, который, будучи премьером, вынужден решать насущные задачи албанского хозяйства. Более практичный и склонный к переговорам, чем Ходжа, он мог бы стать полезным союзником.";
			if (!GlobalScript.inst.gameState.allcountries[20].proprc)
			{
				text += " К тому же он является сторонником союза с КНР и явно будет рад восстановить наши разорванные отношения.";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 78)
		{
			text2 = "Вечный президент";
			text = "По нашим сведениям на Филиппинах в июне этого года будут проходить первые за 12 лет президентские выборы. С 1972 года страна находилась в режиме военного положения, введенного президентом Фердинандом Маркосом и снятого им же в январе 1981-го. Время его президентства характеризовалось разгулом коррупции, кумовства и нарушением прав человека, что вызвало резкий рост оппозиционного активизма, одними из двигателей которого стали маоистская Коммунистическая партия Филиппин и сформированное ей Национальное Демократическое Движение, которые уже долгое время ведут агитацию и партизанскую войну против режима Маркоса. Однако эффективные экономические реформы, основанные на государственном регулировании экономики, подавление оппозиции с помощью военного положения и поддержка США по всей видимости принесут ему победу на грядущих выборах. Однако у нас есть отличный шанс подпортить ему триумф - используя спецслужбы и поставки оружия КПФ и НДД мы могли бы разжечь массовые протесты против режима Маркоса и этих карикатурных выборов. Однако стоит ли? Ведь после того как в 1975-м Маркос разорвал отношения с Тайванем и установил их с КНР, Чжоу Эньлай обещал, что КНР не будет вмешиваться в политику Филиппин, так что может лучше развивать сотрудничество с Маркосом?";
		}
		else if (GlobalScript.inst.gameState.number_event == 79)
		{
			text2 = "Режим экономии";
			text = "В начале 70-х годов Румыния, пользуясь хорошими отношениями Чаушеску с Западом, активно брала кредиты у МВФ, однако после энергетического кризиса, 70-х, ударившего по Румынии, как по большому экспортёру нефти, и обрастания страны долгами, экономическая ситуация в стране стремительно ухудшалась. В этих условиях ещё в конце 70-х в Румынии началось повышение цен на потребительские товары, а теперь Чаушеску принял решение перейти к политике жёсткой экономии, подразумевающей значительное сокращение импорта и расширение экспорта с целью направления прибыли на выплату долгов. Это неизбежно повлекло за собой ограничения на потребление воды и электроэнергии для жителей страны, а на многие товары была введена карточная система, что в совокупности больно ударит по уровню жизни в Румынии. Чаушеску являлся единственным правителем советского соцлагеря, поддерживавшим с КНР неплохие отношения, даже несмотря на наш разрыв с СССР, так может стоит помочь ему пережить этот кризис?";
		}
		else if (GlobalScript.inst.gameState.number_event == 80)
		{
			text2 = "XII съезд КПК";
			text = "Очередной, XII, съезд Коммунистической партии Китая начинает свою работу в Дворце народных собраний в Пекине. На съезде присутствуют 1600 делегатов и 149 кандидатов в делегаты при численности КПК на данный момент в 39,65 млн человек. Повестка дня - обычная... Однако теперь, когда VI Пленум ЦК КПК 11 созыва принял \"Решение по некоторым вопросам истории КПК со времени образования КНР\", в котором мы обозначили возможность курса на демаоизацию - может, стоит в конце работы съезда провести закрытое заседание, на котором зачитать доклад \"О культе личности Мао Цзэдуна и преодолении его последствий\", заранее подготовленный группой советников? Однако это рискует очень сильно подорвать позиции КПК - может, стоит просто в Отчетном докладе упомянуть про \"выправление всего неправильного\" в деятельности Мао и под этим предлогом начать осторожный неформальный отход от маоизма? Или вообще не затрагивать этот вопрос?..";
		}
		else if (GlobalScript.inst.gameState.number_event == 81)
		{
			text2 = "Венгерская рапсодия";
			text = "Из Будапешта пришли любопытные сведения - кажется, распиаренный в свое время Хрущевым кадаровский \"гуляш-социализм\" стоит на пороге дефолта, причем в прямом смысле - Венгрия должна МВФ 7,7 млрд. долларов, которые она не в состоянии выплатить. По рассчетам наших экономистов, у венгров есть два выхода - или взять на Западе и у СССР новые кредиты, или начать полномасштабные рыночные реформы, что больно ударит по уровню жизни подавляющего большинства населения страны. На последнее руководители ВСРП не пойдут, помня о событиях \"пражской весны\", поэтому с высокой вероятностью будут взяты новые кредиты. Но мы можем воспользоваться неурядицами ВНР и предложить им свою экономическую помощь - но при условии реабилитации опального сталиниста Бела Биску и его группы, которые выступают против полурыночных реформ и могут стать нашей надежной опорой в ВСРП. Однако можно и не выдвигать политических условий и просто оказать помощь утопающим...";
		}
		else if (GlobalScript.inst.gameState.number_event == 82)
		{
			text2 = "Фолклендская война";
			text = "В последнее время Великобритания переживает не лучшие времена, всё больше теряя некогда огромное влияние. Этим решила воспользоваться аргентинская военная хунта во главе с Леопольдо Галтьери для проведения \"маленькой победоносной войны\". 2 апреля аргентинские десантники высадились на принадлежащих Британии Фолклендских островах, чью принадлежность давно оспаривает Аргентина, почти сразу сломив сопротивление небольшого британского гарнизона. В ответ на это британцы выслали свой флот к островам с намерением блокировать их. Кажется, в мире начинается новый конфликт.";
		}
		else if (GlobalScript.inst.gameState.number_event == 83)
		{
			text2 = "Проблемы ставропольского агронома";
			text = "Нашим спецслужбам удалось получить доступ к важной информации. Согласно ей, в Советском Союзе наблюдаются достаточно серьезные проблемы в сельском хозяйстве, помноженные на бывшие в этом году сильные осадки. Курирующий сельское хозяйство секретарь ЦК КПСС Фёдор Кулаков - один из наиболее вероятных преемников нынешнего советского руководителя Леонида Брежнева. По добытой нашей агентурой информации, Кулаков выступает за активное изучение и внедрение в советское сельское хозяйство опыта Венгрии и Югославии (т.е., децентрализацию управления колхозами и совхозами, создание с/х кооперативов на основе семейного подряда и единоличных фермерских хозяйств). Мы можем использовать это для его дискредитации на предстоящем Пленуме ЦК КПСС и, таким образом, убрать этого опасного реформиста с дороги...";
		}
		else if (GlobalScript.inst.gameState.number_event == 84)
		{
			text2 = "Наш старый партизан...";
			text = "Итак, теперь, когда Фёдор Кулаков устранен, пришло время обратить внимание на консервативное крыло КПСС. В нем, безусловно, наиболее яркая фигура - Петр Машеров - Первый секретарь ЦК Компартии Белоруссии. Бывший партизанский командир, Машеров возглавил Белоруссию в 1965 году и добился очень существенных успехов в развитии этой республики СССР - в несколько раз вырос национальный доход, происходило активное развитие промышленности и сельского хозяйства, был построен ряд предприятий, в том числе гродненский химический комбинат «Азот», Новополоцкий химический комбинат «Полимир», Гомельский химический завод, Березовская ГРЭС. Благодаря личному вмешательству Машерова, в Минске началось строительство метрополитена. Урожайность зерновых достигла 27 ц/га, а сбор зерна — 7,3 миллиона тонн. Однако своей линией на омоложение кадров, Машеров вызвал недовольство многих партийцев, он находится в довольно конфликтных взаимоотношениях с главным идеологом КПСС Михаилом Сусловым, а также был очень близок к опальному Кулакову. Тем не менее, Леонид Брежнев явно делает на него ставку, как на возможного преемника престарелого главы Совмина Косыгина, благо что сам премьер этот выбор одобряет. МГБ подготовило несколько вариантов устранения Машерова с дороги.";
		}
		else if (GlobalScript.inst.gameState.number_event == 85)
		{
			text2 = "Немецкая автономия в Казахстане";
			text = "Нашим источникам в Москве удалось получить интересную информацию - комиссия в составе Ю. Андропова, И. Капитонова, М. Зимянина, З. Нуриева, Н. Щелокова, Р. Руденко, М. Георгадзе, В. Чебрикова внесла в ЦК КПСС предложение об образовании немецкой автономии в Казахской ССР (где проживает 940 тыс. немцев, высланных сюда в 30-40-е годы). Однако руководство республики во главе с близким соратником Леонида Брежнева - Динмухамедом Кунаевым - выступает резко против этого. Насколько нам стало известно, они даже готовы организовать массовые беспорядки казахского населения в случае, если эта автономия будет создана. Кунаев - один из наиболее вероятных кандидатов на пост Второго секретаря ЦК КПСС в случае изменения состава советского руководства, а его антикитайские настроения секретом не являются. Имеет смысл воспользоваться ситуацией для его низвержения.\nС другой стороны некоторые ваши советники вопрошают: а зачем нам и дальше помогать Советскому Союзу очищаться, если мы можем попросту стравить брежневскую клику друг с другом и извлечь в этом выгоду уже сейчас?";
		}
		else if (GlobalScript.inst.gameState.number_event == 86)
		{
			text2 = "Конец \"Железного Юрика\"";
			text = "Как нам стало известно, Леонид Брежнев только что отправился в Вену на переговоры по договору ОСВ-2 с президентом США Картером. Никакого \"ограничения стратегических наступательных вооружений\" империалисты, разумеется, не сделают, но нас интересует не это - Брежнев пробудет за границей достаточно времени, чтобы мы могли нанести удар по всесильному шефу КГБ СССР Юрию Андропову. Он известен, как сторонник постепенного улучшения советско-американских отношений и проведения масштабных реформ по венгерскому образцу. Теперь Андропов начинает рассматриваться, как наиболее вероятный преемник Леонида Брежнева. Итак, есть два способа убрать его с дороги - или физически ликвидировать его под предлогом смерти от отказа почек, или попробовать \"подтолкнуть\" главного идеолога КПСС Михаила Суслова и главу украинской парторганизации КПСС Владимира Щербицкого, которые в крайне плохих отношениях с главой советской охранки, к созыву чрезвычайного Пленума ЦК КПСС и разгроме на нем Андропова. Возглавляемый генерал-полковником Виталием Федорчуком украинский КГБ подчиняется Щербицкому и не в ладах с союзным, поэтому шансы на успех достаточно велики.";
		}
		else if (GlobalScript.inst.gameState.number_event == 87)
		{
			text2 = "Мир Галилее";
			text = "Благодаря слабости ливанского руководства, идущей с 1975 года гражданской войне в Ливане и активной помощи арабских стран, Организация Освобождения Палестины сумела развернуть на неподконтрольном правительству юге Ливана опорный пункт для боевых действий против Израиля. Стороны неоднократно обстреливали друг друга, однако похоже теперь конфликт перешёл в горячую фазу. 3 июня на посла Израиля в Лондоне было совершено покушение (как позже выяснится, ответственным за него была другая палестинская группировка, не имеющая отношения к ООП), что стало предлогом для массированной бомбардировки Ливана Израилем, а уже 6 июня израильская армия перешла границу Ливана и завязала бои с силами ООП.";
		}
		else if (GlobalScript.inst.gameState.number_event == 88)
		{
			text2 = "Конец зимбабвийского апартеида";
			text = "В Родезии (также известной как Зимбабве), где уже много лет идёт вооружённая борьба чернокожего большинства против белых властей, проводящих политику расовой сегрегации, кажется наметился поворот в политике. В декабре 1979-го прошла Ланкастерхаузская конференция, на которой было достигнуто соглашение о проведении всеобщих равных выборов, при условии прекращения огня и формальное провозглашение Зимбабве-Родезии британской колонией до дальнейшего определения её судьбы. В итоге на этих выборах победу одержала возглавляемая ЗАНУ и Робертом Мугабе левонационалистическая коалиция, а 18 апреля была провозглашена независимость страны, переименованной в Зимбабве. В своё время мы, как и СССР, оказывали поддержку более умеренной ЗАПУ - нынешним союзникам ЗАНУ по коалиции - так может стоит продолжить сотрудничество с победившими левыми партиями?";
		}
		else if (GlobalScript.inst.gameState.number_event == 89 && GlobalScript.inst.gameState.resultOfEvents[85] >= 3)
		{
			GlobalScript.inst.gameState.empires[1].leaders[3].support = 0;
			GlobalScript.inst.gameState.empires[1].leaders[1].support--;
			GlobalScript.inst.gameState.empires[1].leaders[1].support += ((GlobalScript.inst.gameState.empires[1].leaders[5].support > 0) ? GlobalScript.inst.gameState.empires[1].leaders[5].support : 0);
			GlobalScript.inst.gameState.empires[1].leaders[5].support = 0;
			GlobalScript.inst.gameState.empires[1].leaders[2].support += ((GlobalScript.inst.gameState.empires[1].leaders[4].support > 0) ? GlobalScript.inst.gameState.empires[1].leaders[4].support : 0);
			GlobalScript.inst.gameState.empires[1].leaders[2].support += ((GlobalScript.inst.gameState.empires[1].leaders[6].support > 0) ? GlobalScript.inst.gameState.empires[1].leaders[6].support : 0);
			GlobalScript.inst.gameState.empires[1].leaders[4].support = 0;
			GlobalScript.inst.gameState.empires[1].leaders[6].support = 0;
			text2 = "Конец эпохи";
			text = "Срочные известия из СССР! Сегодня советское руководство объявило о смерти Леонида Ильича Брежнева, руководившего Советским Союзом больше 20 лет. Советский руководитель скончался в ночь на 1 июля во сне от внезапной остановки сердца. Последние несколько лет Леонид Брежнев управлял страной не более трёх часов в день по советам врачей и избегал травмирования, благодаря чему он прожил достаточно долгую жизнь. Пока весь советский народ скорбит, в КПСС развернулась активная борьба за власть, где главными претендентами на должность генсека ЦК КПСС являются:";
			if (GlobalScript.inst.gameState.empires[1].leaders[1].support > 0)
			{
				text += "|Владимир Щербицкий, глава украинской компартии, верный брежневист, достигший больших успехов в развитии экономики и поднятия уровня жизни в УССР.";
			}
			text += "|Константин Черненко, заведующий Общим отделом ЦК КПСС, консервативный партиец и опытный организатор, которого некоторые за его взгляды считают даже сталинистом. |Если у нас не самые плохие отношения с СССР, то мы могли бы оказать поддержку одному из кандидатов. Разумеется, кардинально ситуацию это не изменит, но при патовой ситуации может склонить чашу весов в пользу удобного нам кандидата.";
		}
		else if (GlobalScript.inst.gameState.number_event == 89)
		{
			text2 = "Конец эпохи";
			text = "Срочные известия из СССР! Сегодня советское руководство объявило о смерти Леонида Ильича Брежнева, руководившего Советским Союзом почти 20 лет. Советский руководитель скончался 10 ноября во сне от внезапной остановки сердца. Пока весь советский народ скорбит, в КПСС развернулась активная борьба за власть, где главными претендентами на должность генсека ЦК КПСС являются:";
			if (GlobalScript.inst.gameState.empires[1].leaders[3].support > 0)
			{
				text += "|Юрий Андропов, глава КГБ СССР, прагматичный реформатор, активно продвигающий сподвижников для реформ, таких как Горбачёв, Лигачёв и Долгих.";
			}
			if (GlobalScript.inst.gameState.empires[1].leaders[1].support > 0)
			{
				text += "|Владимир Щербицкий, глава украинской компартии, верный брежневист, достигший больших успехов в развитии экономики и поднятия уровня жизни в УССР.";
			}
			text += "|Константин Черненко, заведующий Общим отделом ЦК КПСС, консервативный партиец и опытный организатор, которого некоторые за его взгляды считают даже сталинистом. |Если у нас не самые плохие отношения с СССР, то мы могли бы оказать поддержку одному из кандидатов. Разумеется, кардинально ситуацию это не изменит, но при патовой ситуации может склонить чашу весов в пользу удобного нам кандидата.";
		}
		else if (GlobalScript.inst.gameState.number_event == 90)
		{
			text2 = "Гонконг гудбай, Макао аста ла виста?";
			text = "Как Вы знаете, нам удалось достичь соглашения о возвращении Китаю суверенитета над Сянганом (Гонконгом) в 1997 году и над Аомынем (Макао) в 1999 году на праве очень широкой автономии, ради чего мы даже создали новую территориальную единицу - \"специальный административный район\". Однако часть местной крупной буржуазии выступила против этого соглашения и, как стало известно нашим спецслужбам, готовит целый ряд провокаций, направленных на его срыв и сохранение колониального господства Великобритании и Португалии (в частности, максимальное затягивание разработки Основных законов САР, проведение антикитайских митингов и публикация подстрекательских материалов в СМИ). В этой ситуации, ряд партийцев выступили с неожиданным предложением - установить связи с так называемыми Триадами - 7-ю влиятельнейшими гонконгскими преступными синдикатами, имеющими мощные связи во всей Юго-Восточной Азии. Мы могли бы предложить им выгодные экономические преференции и гарантии неприкосновенности - но при условии оказания содействия в воссоединении Гонконга и Макао с Родиной. Итак, Ваше решение?";
		}
		else if (GlobalScript.inst.gameState.number_event == 91)
		{
			text2 = "Рангунский теракт";
			text = "По нашим данным сегодня в столице Бирмы произошёл теракт, целью которого было убийство южнокорейского президента Чон Ду Хвана. Сам Чон Ду Хван уцелел благодаря тому, что прибыл на место на две минуты позже взрыва, но 17 человек из состава южнокорейской делегации были убиты. Террористы вскоре были схвачены и после допросов назвались офицерами северокорейской армии. Сама КНДР свою причастность к инциденту отрицает, но сам факт подобного происшествия даёт нам возможность с новой силой разжечь противостояние КНДР и Южной Кореи.";
		}
		else if (GlobalScript.inst.gameState.number_event == 92)
		{
			text2 = "Перевыполнение – честь!";
			text = "Товарищ председатель! В связи с началом выполнения нового пятилетнего плана, некоторые специалисты и экономисты из комитета по планированию предлагают выбрать приоритетную отрасль развития на следующий пятигодичный период. Вам необходимо решить какая из областей народного хозяйства требует особого внимания и инвестирования со стороны государства – промышленность, сельское хозяйство, услуги или развитие науки? Однако мы также можем размеренно распорядиться средствами и направить силы на улучшение сразу трёх отраслей, что приведёт к их более равномерному развитию.";
		}
		else if (GlobalScript.inst.gameState.number_event == 93)
		{
			text2 = "Родина демократии";
			text = "В Греции, всё ещё оправляющейся от влияния свергнутой в 1974 хунты Чёрных полковников, намечаются парламентские выборы. После восстановления демократии в стране были две доминирующие партии - либерально-консервативная \"Новая демократия\" и левые социал-демократы из ПАСОК (\"Всегреческое социалистическое движение\"). Так как сейчас фактически решается направление греческой политики вроде членства в НАТО (откуда страна фактически вышла в 1974 году из-за вторжения Турции на Кипр) и Евросоюзе, исход этих выборов может серьёзно повлиять на обстановку в стране.";
		}
		else if (GlobalScript.inst.gameState.number_event == 94)
		{
			if (GlobalScript.inst.gameState.faction_leader[4] >= 200 || GlobalScript.inst.gameState.faction_leader[4] < 0 || GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].traits[0] != 4)
			{
				(Politic, int) tuple2 = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 4);
				if (tuple2.Item1 == null)
				{
					tuple2 = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 3);
				}
				if (tuple2.Item1 == null)
				{
					tuple2 = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 2);
				}
				if (tuple2.Item1 == null)
				{
					tuple2 = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 1);
				}
				if (tuple2.Item1 == null)
				{
					tuple2 = GlobalScript.inst.gameState.politics.Select((Politic pol, int i) => (pol: pol, index: i)).FirstOrDefault(((Politic pol, int index) pol) => pol.pol.traits[0] == 0);
				}
				GlobalScript.inst.gameState.faction_leader[4] = tuple2.Item2;
			}
			text2 = "Тяньаньмэньский инцидент. Снова?!";
			text = "Политика широкомасштабных реформ во всех сферах жизни, расцвет коррупции, сращение КПК с бизнесом и установление тайных коррупционных связей между номенклатурой и бизнесменами вызвали значительный рост буржуазной либерализации умов немалой части китайской интеллигенции и молодежи, требующих радикализации реформ и отказа от \"коммунистической заразы\". Они образовали движение \"Туйдан\" (буквально \"Отказ от Партии\") во главе с диссидентом-астрофизиком Фан Личжи, которого на Западе назвают \"китайским Сахаровым\", выступающее за объявление КПК \"преступной организацией\" и её силовое отстранение от власти, либерализацию и вестернизацию страны, борьбу с коррупцией и привелегиями номенклатуры. Пользуясь разрешением на проведение массовых мероприятий, 100 тысяч сторонников \"Туйдана\" собрались на площади Тяньаньмэнь в Пекине. Они требуют \"свободы\", \"демократии\", \"борьбы с продажными чинушами\" и \"ухода в отставку коррумпированного партийного руководства\", при этом к ним с каждым днем присоединяются и другие недовольные нашими реформами, включая рабочих. Либерально настроенное крыло КПК, которое возглавляет " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + ", склонно согласиться с требованиями протестующих, надеясь на волне протестов прийти к власти. Ситуация крайне нестабильная, однако ещё есть возможность вмешаться, пока волнения не перекинулись на другие города...";
		}
		else if (GlobalScript.inst.gameState.number_event == 95)
		{
			text2 = "Новое начало для КПК";
			text = "Итак, ситуация в Пекине взята под контроль и власть в стране перешла к либеральному крылу КПК во главе с товарищем " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ". На повестке дня стоит вопрос широкомасштабного углубления политики \"реформ и открытости\" и перехода к демократии западного образца и свободному рынку. Однако движение \"Туйдан\", с которым мы теперь вынуждены считаться, требует учесть в проекте реформ необходимость декоммунизации китайского общества и, само собой, правящей партии. В принципе, КПК и так тяжело назвать \"коммунистической\" партией, но теперь нам предлагается отказаться от марксизма-ленинизма уже окончательно. Итак?..";
		}
		else if (GlobalScript.inst.gameState.number_event == 96)
		{
			text2 = "Перестройка! Демократия! Гласность!";
			text = "Итак, с организационными вопросами покончено и теперь нам необходимо выполнять данные народу обещания о демократизации Китая по западному образцу. Народ требует прекращения давления на религию и духовенство, расширения гражданских прав и свобод по образцу западных стран и самое главное - роспуска \"Патриотического единого фронта китайского народа\" и свободных выборов в ВСНП и местные органы власти. И если выборов нам уже не избежать, то задобрив граждан выполнением других требований, мы могли бы сделать их настолько свободными, насколько нам это нужно.";
		}
		else if (GlobalScript.inst.gameState.number_event == 97)
		{
			text2 = "Автоматизация?";
			text = "Это наш великий научный прорыв - ещё недавно мы боролись с тотальной отсталостью нашей экономики, а теперь наши учёные добились выдающихся успехов в разработке механизмов автоматизации планирования экономики на основе систем ЭВМ и даже приступили к разработке системы, позволяющей осуществлять автоматизированное планирование и координацию предприятий в масштабах всей страны. До её полного внедрения ещё далеко, но уже сейчас можно и нужно начать внедрение её низовых региональных систем и их координацию, если мы хотим добиться успехов в автоматизации нашей экономики. Впрочем, это явно не понравится многим управленцам и членам партии, считающим такие темпы внедрения незнакомой системы слишком поспешными...";
		}
		else if (GlobalScript.inst.gameState.number_event == 98)
		{
			text2 = "Африканский Че Гевара";
			text = "Товарищ председатель, срочные новости из бывшей французской колонии Верхней Вольты! Невероятно популярный в народе экс-премьер и по совместительству влиятельный военный деятель Тома Санкара, арестованный несколькими месяцами ранее, свергнул профранцзуского президента Жан-Батист Уэдраого, который массово закрывал профсоюзы и убивал оппозиционеров. Сразу же после военного переворота было сменено название страны с колониальной «Верхней Вольты» на «Буркина Фасо»- «родина честных людей», также была полностью изменена вся государственная символика. Теперь, Тома Санкара, придерживающийся революционных антиимпериалистических взглядов, объявляет курс на строительство социализма и «борьбу против контрреволюционных классов общества», что в свою очередь делает его положение шатким. Чтобы осуществить свои революционные преобразования и «поднять страну с колен», Санкара ищет помощи от социалистических стран. Возможно, нам следует признать новую власть и отправить послов, тем самым показав свои доброжелательные намерения. Однако, также, леворадикальные антиимпериалистические взгляды, весьма близкие к Мао, при нужной поддержке могут создать нам стабильного союзника в центральной Африке. Хотя…может быть не стоит быть столь торопливым и «раскачивать и так нестабильную лодку революций» на африканском континенте? ";
		}
		else if (GlobalScript.inst.gameState.number_event == 114)
		{
			text2 = "Слон и осёл";
			text = "Вскоре в США пройдут президентские выборы, на которых действующий президент-демократ Джимми Картер баллотируется на второй срок, соперничая с амбициозным республиканцем Рональдом Рейганом. В ходе своего правления Картер пытался улучшить социальное обеспечение американцев, создать более открытое правительство и в целом реформировать некоторые государственные институты США. Внешняя политика характеризовалась балансом между противостоянием с СССР и разрядкой. Однако президентство Картера неудачно совпало с ростом цен на нефть, а относительно умеренная внешняя политика подвергается жёсткой критике консервативных кругов, поэтому республиканцы имеют все шансы на победу. Вмешаться мы, разумеется, не можем, поэтому нам остаётся только ждать.";
		}
		else if (GlobalScript.inst.gameState.number_event == 117)
		{
			text2 = "Пятилетка похорон";
			text = "Только что пришли новости из СССР - 9 февраля от отказа почек в возрасте 69-ти лет умер Генеральный секретарь ЦК КПСС Юрий Андропов. С конца 1983-го он сильно болел, и подхваченная в Крыму простуда окончательно добила советского руководителя. Во время своего правления Андропов уделял большое внимание улучшению экономической ситуации - была запущена кампания по борьбе за трудовую дисциплину, развёрнуты масштабные антикоррупционные меры, направленные главным образом против порождающих дефицит незаконных списаний в торговле. Вместе с тем Андропов активно продвигал молодые реформаторские кадры и поручил Горбачёву, Рыжкову, Абалкину и Долгих разработать проект масштабной экономической реформы для СССР. Ввиду обострившейся политической борьбы новым генсеком скорее всего изберут компромиссного Черненко. А на 14 февраля назначены похороны Андропова, куда намерены прибыть представители многих стран, как союзных СССР, так и прочих. А что делать нам?";
		}
		else if (GlobalScript.inst.gameState.number_event == 99)
		{
			text2 = "Жёлтый скорпион";
			text = "Товарищ председатель, срочная новость из социалистического Алжира! После неожиданной и быстро протекающей болезни, скоропостижно скончался второй президент АНДР Хуари Бумедьен, которого в народе за скрытность и хитрость именовали «Жёлтым скорпионом». За почти полтора десятилетия своего правления Бумедьен сделал из отсталой французской колонии индустриального гиганта Африки. Теперь, из-за отсутствия в стране института преемства, в правящей партии - «Фронте национального освобождения» за власть борются три фракции: ортодоксальные сталинисты, возглавляемые Мохаммедом Салах Яхьяуи, которого рьяно поддерживают профсоюзы, и который против союза с «ревизионистским СССР», умеренные реформаторы с лидером Шадли Бенджедидом, выступающие за сохранение дружеских отношений с СССР, но за внедрение некоторых рыночных реформ, и либералы, симпатизирующие прозападному министру иностранных дел - Абделю Азизу Бутефлику. Если мы поддержим одну из группировок, то вероятно, сможем расширить наше влияние на африканские страны, однако стоит ли это того?";
		}
		else if (GlobalScript.inst.gameState.number_event == 100)
		{
			text2 = "КРИЗИС ПРАВИТЕЛЬСТВА";
			text = "После несчитанных путчей, власть военных в Бангладеш относительно стабилизировалась, и «серый кардинал» генералитета Хуссейн Мохаммад Эршад смог занять пост президента страны. За два года существования правого авторитарного режима, в Бангладеш были развёрнуты полномасштабные репрессии против либералов и социалистов, представленных, в большинстве своём, левой партией «Авами лиг», а основные коренные проблемы страны: малоземелье крестьян и коррупция в высших эшелонах власти, решены не были. В связи с этим, с переменным успехом, во всех городах страны разворачиваются жёсткие акции протеста против действий правительства, главным лозунгом которых является проведение досрочных выборов в парламент. Я думаю, если мы материально поддержим правительство, то сможем усмирить этот «неспокойный очаг переворотов» в Юго-восточной Азии, тем более действующая власть придерживается курса на потепление отношений с Китаем. Однако если мы сможем с большей силой разжечь протесты и сплотить оппозицию против Эршада и генералитета, то к власти придут более лояльные нам люди, но что подумает мировое сообщество в таком случае? Может лучше вообще не вмешиваться?";
		}
		else if (GlobalScript.inst.gameState.number_event == 102)
		{
			text2 = "Ветер перемен?";
			text = "Срочные известия из СССР! 10 марта 1985 года в 19 часов 20 минут генеральный секретарь Константин Устинович Черненко скончался от остановки сердца. Пока народ скорбит, в коридорах Кремля вовсю разворачивается борьба за место нового генерального секретаря, кандидатами на которое являются: |Михаил Горбачёв - молодой и перспективный партиец, некогда член команды Андропова, известный своими реформаторскими взглядами. |Григорий Романов - энергичный и готовый к экспериментам, молодой, но опытный управленец, бывший глава Ленинградского обкома, железной рукой обеспечивший Ленинграду рост благосостояния и экономики.| И, наконец, Виктор Гришин, представитель старого поколения Политбюро и любимец консервативных кругов, глава Московского горкома, сторонник политики Брежнева во внутренних и внешних делах, за долгие годы обросший связями (в том числе коррупционными) в КПСС. |Кого же нам поддержать, если мы вообще сможем?";
		}
		else if (GlobalScript.inst.gameState.number_event == 104)
		{
			text2 = "ХII Всемирный фестиваль молодёжи и студентов";
			text = "В Москве скоро должен пройти XII Всемирный фестиваль молодёжи и студентов. Подобные фестивали организуются Всемирной федерацией демократической молодёжи - международной левой молодёжной организацией - с 1947 года и всегда являли собой яркое собрание прогрессивной молодёжи со всего мира, а задачами фестивалей ставились пропаганда социализма и борьба с империализмом. Перед нами встаёт извечный вопрос - ехать или нет? Ведь СССР, являясь принимающей стороной и обладая огромным влиянием на ВФДМ, может нас и не пустить в случае сильных разногласий. В связи с этим некоторые партийцы предлагают провести свой аналогичный фестиваль, пригласив представителей дружественных стран.";
		}
		else if (GlobalScript.inst.gameState.number_event == 105)
		{
			text2 = "Конец албанского Сталина";
			text = "Интересные новости из Албании: 11 апреля в возрасте 76 лет скончался бессменный лидер Албании Энвер Ходжа. Пока страна скорбит о своей утрате, на должность Первого секретаря ЦК АПТ вступил Рамиз Алия, долгое время считавшийся преемником Ходжи и сыгравший важную роль в разгроме группы Мехмета Шеху. Алия пользовался благосклонностью Ходжи за безоговорочную поддержку всех поворотов его политики, однако, по некоторым сведениям, он не прочь наладить отношения с Западом и Югославией, а также провести некоторые послабления во внутренней политике. С одной стороны, это может сыграть нам на руку, а с другой - закончиться неизвестно чем. Поэтому мы могли бы организовать теракт против новоявленного правителя, если, конечно, у нас есть агентура поблизости.";
		}
		else if (GlobalScript.inst.gameState.number_event == 106)
		{
			text2 = "Демократический интернационал";
			text = "В ангольском городе Джамба, являющимся главной базой антикоммунистического повстанческого движения УНИТА, готовится конференция по итогам которой участники хотят создать т. н. \"Демократический интернационал\" - коалицию антикоммунистических повстанцев из разных стран. В конференции, помимо УНИТА, участвуют представители афганских моджахедов, никарагуанских контрас и лаосских хмонгов, а в организации принимают активное участие американские консерваторы, такие как банкир Льюис Лерман (финансист мероприятия), известный лоббист и кинопродюсер Джек Абрамофф (инициатор мероприятия) и подполковник Оливер Норт. Несмотря на яркую антисоветскую направленность готовящегося альянса, он также пересекается с зоной наших интересов и может вызвать проблемы в будущем. С другой стороны мы можем и попытаться использовать его в геополитической борьбе с СССР.";
		}
		else if (GlobalScript.inst.gameState.number_event == 109)
		{
			text2 = "Золотой век Сомали";
			text = "После провала огаденской войны, положение в Сомали началось стремительно ухудшаться. Фронт освобождения Западного Сомали потерпел сокрушительное поражение и был разгромлен эфиопской армией, а сворачивание советской военной и гражданской помощи серьёзно ударило по сомалийской экономике. Сомалийская революционная социалистическая партия постепенно начинает утрачивать популярность населения, а режим Мохаммеда Сиад Барре становится всё более авторитарным. В такой удручающей обстановке правительство Сомали пытается дистанцироваться от Советского Союза, перейдя к сотрудничеству с США и западными странами. Возможно, отправив правительству Сомали всевозможную помощь для урегулирования положения в стране, мы сможем заручиться поддержкой Барре и заиметь выгодного и верного союзника в Восточной Африке. Однако спасёт ли это режим СРСП, против которого по всей стране активно формируются отряды вооружённой оппозиции? Нерешительностью президента Барре крайне недоволен генералитет, может быть, заручившись их поддержкой нам удастся совершить против него заговор и привести к власти более прагматичных лидеров?";
		}
		else if (GlobalScript.inst.gameState.number_event == 110)
		{
			text2 = "Автоматизация – естественный процесс";
			text = "Товарищ председатель! За предыдущую пятилетку мы добились крупных успехов в ведении народного хозяйства и научных исследованиях, и мы не должны останавливаться на достигнутом. Пора закрепить наши успехи и воссоздать мечту многих поколений людей о совершенном мироустройстве, сделав первый шаг от социалистического общества к коммунистическому. Лучшие умы нашей страны – математики и кибернетики предлагают создать полномасштабную и всеобъемлющую систему единого автоматизированного планирования производства, взяв за основу своей идеи концепцию ОГАС советского математика Виктора Глушкова. Тем самым мы сможем избавиться от всех проблем и изъянов плановой экономики, передав выполнение большинства сложных и затратных расчетов вычислительным машинам и ЭВМ. Но для реализации такого огромного проекта понадобиться много средств и времени, однако государственный аппарат как огня боится радикальных изменений, тем более таких, которые могут покушаться на их «засиженные места» и благополучие. Выбор за вами…";
		}
		else if (GlobalScript.inst.gameState.number_event == 111)
		{
			text2 = "К призрачному свету";
			text = "Товарищ председатель! После частичного внедрения системы МЭСУ правительство начало постепенное и планомерное сокращение государственного аппарата на низовом уровне для освобождения лишних квалифицированных рабочих рук и оптимизации бюджета. Эти меры встретили жёсткое сопротивление со стороны местной бюрократии, которая уже объявила вас в «буржуазной контрреволюции». Теперь даже высшее партийное руководство настроено против вас и уже готовит ваше смещение. Нужно незамедлительно принять меры! Нам необходимо заручиться поддержкой широких слоёв населения и победа будет за нами! Но вопрос, поддержат ли они нас?";
		}
		else if (GlobalScript.inst.gameState.number_event == 112)
		{
			text2 = "Предания неведомых миров";
			text = "Товарищ председатель, происходят странные вещи! По всей страны межотраслевые организации дают сбои. Сообщения между предприятиями низового уровня нарушены, продовольствие поставляется в регионы с перебоями, растут очереди в магазинах. По заверениям управляющих на наше оборудование была совершена компьютерная атака извне. Спецслужбы предполагают, что это наши внешние противники, сговорившиеся с врагами автоматизации, боясь неминуемого роста нашего влияния на мировой арене, пытаются нанести удар по нашей экономике путём вывода из строя МЭСУ. Если мы немедленно ничего не предпримем, то это обернётся коллапсом для нашей страны. Специалисты предлагают разработать особую защиту для нашей системы планирования, но для этого потребуется некоторое время. Однако мы можем запросить поддержку экспертов из  Советского Союза, что в свою очередь позволит быстрее вернуть аппаратуру в строй. Или же… автоматизация действительно утопия?";
		}
		else if (GlobalScript.inst.gameState.number_event == 113)
		{
			text2 = "Агония югославского социалистического самоуправления";
			text = "Товарищ Председатель, из Югославии приходят неприятные для нас новости - так называемая \"комиссия Крайгера\", возглавляемая бывшим Председателем Президиума СФРЮ Сергеем Крайгером (словеном по национальности и близким соратником главного теоретика югославского \"социалистического самоуправления\" Эдварда Карделя), представила на рассмотрение Президиума СФРЮ проект масштабных рыночных экономических реформ. Югославия после смерти Иосипа Броз Тито переживает тяжелые времена - последствия сепаратистского мятежа в Косово до сих пор не устранены, в Словении и Хорватии растет недовольство Центром, а в Сербии - националистические настроения. Масло в огонь подлил экономический кризис 1979 года, вынудивший и так погрязшую в долгах страну взять дополнительные кредиты. Похоже, Югославия движется к пропасти... СССР и страны соцлагеря готовы предоставить СФРЮ крупную фин. помощь в обмен на отказ от реформ. Мы тоже можем присоединиться к предложению советского руководства, однако группа партийцев предлагает инспирировать военный переворот и привести к власти югославских генералов, настроенных на прекращение политики \"неприсоединения\". С другой стороны, США также предлагают СФРЮ новые кредиты... Итак, что мы предпримем в этой ситуации?";
		}
		else if (GlobalScript.inst.gameState.number_event == 115)
		{
			text2 = "Золотой треугольник";
			text = "Товарищ председатель, как известно нашим спецслужбам, в горных районах Бирмы, Лаоса и Таиланда, которые недавно стали частью нашей сферы влияния, действует крупная сеть синдикатов, занимающихся производством и сбытом наркотиков, называемая \"Золотым треугольником\". Эта сеть сильно способствует коррупции в этих и близлежащих странах, к тому же её возглавляет видный деятель народа шанов, выступающий за их отделение от Бирмы, Кхун Са. Принимая во внимание всё это, часть партийцев и генералитета предлагает оказать этим странам содействие в проведении следственных и войсковых операций против наркоторговцев. Однако есть и другая группа, справедливо заявляющая, что за долгие годы гражданской войны шаны так и не смогли добиться независимости от Бирмы и вряд ли добьются, коррупцию в этих странах ударом по одной сети синдикатов не уничтожить, а наркотики эти идут главным образом в западные страны. В связи с этим они предлагают помочь Золотому треугольнику в организации охраны и сбыта товара, что поможет нам получить деньги и подпортить жизнь западу.";
		}
		else if (GlobalScript.inst.gameState.number_event == 435)
		{
			text2 = GlobalScript.inst.new_events_text[1647];
			text = GlobalScript.inst.new_events_text[1648];
		}
		else if (GlobalScript.inst.gameState.number_event == 436)
		{
			text2 = GlobalScript.inst.new_events_text[1656];
			text = GlobalScript.inst.new_events_text[1657];
		}
		else if (GlobalScript.inst.gameState.number_event == 116)
		{
			text2 = "Два Китая";
			text = "Как вам известно, после победы КПК в гражданской войне остатки Гоминьдана сбежали на остров Тайвань, и долгое время западное сообщество  считало их законным правительством Китая. Из-за американских баз и флота на Тайване мы так и не смогли отбить его, равно как и Гоминьдан не смог вернуть себе материковый Китай, и со временем всё больше стран признали правление КПК, хотя ни коммунистическое ни тайваньское правительство формально не отказывались от претензий на весь Китай. Разумеется, наши отношения всегда были ужасными, однако после недавней либерализации и конца монополии КПК на власть они заметно потеплели. Теперь некоторые люди в верхах обеих стран заговорили о возможности долгожданного воссоединения нации. Однако в этом случае Тайвань однозначно потребует автономию, нам нужно будет договориться с США о статусе их баз, и неизвестно, как жители Тайваня, успевшие развить свою культурную идентичность, повлияют на и так нестабильную ситуацию в стране. Поэтому некоторые предлагают нам с Тайванем взаимно признать друг друга независимыми государствами и наладить добрососедские отношения. И раз уж в этом случае американские базы останутся на месте, а западные компании будут избавлены от кучи бюрократической возни, то неплохо бы намекнуть США, что молодой демократии нужны деньги...";
		}
		else if (GlobalScript.inst.gameState.number_event == 103)
		{
			if (GlobalScript.inst.gameState.allcountries[0].isEU)
			{
				text2 = "Шенгенское соглашение";
				text = "Недавно, 14 июля в Люксембурге между несколькими европейскими странами было подписано Шенгенское соглашение, подразумевающее упрощение паспортно-визового контроля на границах между ними и наметившее движение к фактически полному отказу от паспортного контроля. Шенгенское соглашение натолкнуло ваших сопартийцев на мысль - у нас ведь тоже есть свой экономический союз. Создание единого визового пространства, свободное перемещение между странами союза и упрощение пограничного контроля должно поспособствовать культурному обмену между нашими странами, развитию туризма, да и народу понравится. Проблема в том, что это также упростит жизнь диссидентам и преступникам, да и мало ли каких идей наши граждане за границей наберутся...";
			}
			else
			{
				text2 = "Мадридское соглашение";
				text = "Недавно, 14 июля в Испании между несколькими европейскими странами было подписано Мадридское соглашение, подразумевающее упрощение паспортно-визового контроля на границах между ними и наметившее движение к фактически полному отказу от паспортного контроля. Мадридское соглашение натолкнуло ваших сопартийцев на мысль - у нас ведь тоже есть свой экономический союз. Создание единого визового пространства, свободное перемещение между странами союза и упрощение пограничного контроля должно поспособствовать культурному обмену между нашими странами, развитию туризма, да и народу понравится. Проблема в том, что это также упростит жизнь диссидентам и преступникам, да и мало ли каких идей наши граждане за границей наберутся...";
			}
		}
		else if (GlobalScript.inst.gameState.number_event == 107)
		{
			text2 = "Кризис среди союзников";
			text = "Как всем известно, наше содружество является самым демократичным и равноправным... и это порождает последствия. " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " в последнее время проводит всё более независимую от нас политику, а в их политической системе набирают власть нелояльные нам силы, которые хотят провести некоторые реформы.";
			if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
			{
				text += " Но что ещё хуже так это их дипломатические заигрывания с США и западом! Если так продолжится, то мы рискуем потерять своего союзника, поэтому нужно что-то делать, но что? Мы ведь не хотим поступать как советские ревизионисты в Чехословакии. Или всё-таки..?";
			}
			else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
			{
				text += " Но что ещё хуже так это их дипломатические заигрывания с СССР! Если так продолжится, то мы рискуем потерять своего союзника, поэтому нужно что-то делать, но что? Мы ведь не хотим поступать как советские ревизионисты в Чехословакии. Или всё-таки..?";
			}
			else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
			{
				text += "|И всё это происходит на фоне готовящейся декларации правительства нашего союзника о декларировании политики нейтралитета, что означает одно: они хотят покинуть наш военный альянс.";
			}
			else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].econ)
			{
				text += "|И всё это происходит на фоне того, как правительство нашего союзника лихорадочно сокращает все торговые связи с нами, декларируя переориентацию своей экономики, что означает одно: они хотят покинуть наш экономический альянс.";
			}
		}
		Name.text = Utils.Text(text2, 41);
		Zaglav.text = Utils.Text(text, 81);
	}

	private static string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
