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
					fake_text[0] = "Do not interfere and wait for results";
					if (GlobalScript.inst.gameState.data[1] > 500)
					{
						fake_text[1] = "Drive civil servants to the vote";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "The party blocks such brazen intervention";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[2] = "Falsify results";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "The intelligence services do not have enough strength";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 3)
				{
					kolvo_variant = 3;
					fake_text[0] = "Cremate Mao according to his wishes and build a memorial";
					fake_text[1] = "Build Mausoleum on Tiananmen Square for Mao";
					fake_text[2] = "Let the funeral commission decide";
				}
				else if (GlobalScript.inst.gameState.number_event == 4)
				{
					kolvo_variant = 4;
					fake_text[0] = "Start polemic at the congress";
					if (GlobalScript.inst.gameState.data[9] >= 100)
					{
						fake_text[1] = "Arrest conspirators!";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Special services will not support us";
					}
					if (GlobalScript.inst.gameState.data[22] >= 100)
					{
						fake_text[2] = "Call loyal officers!";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Army will not support us";
					}
					if (GlobalScript.inst.gameState.data[3] >= 700)
					{
						fake_text[3] = "Appeal to the people!";
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
					fake_text[0] = "Speak out and calm the people";
					if (num != 99 && GlobalScript.inst.gameState.data[38] == 100 && !GlobalScript.inst.gameState.citizens[num].isLead)
					{
						Debug.Log($"Гражданин {num} может быть возвышен");
						fake_text[1] = "A man of the people should lead the country";
						GlobalScript.inst.gameState.citizens[num].isLead = true;
					}
					else if (GlobalScript.inst.gameState.data[15] != 9 || GlobalScript.inst.gameState.data[17] != 19)
					{
						fake_text[1] = "Agree to democratization";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "there is no place to further democratization";
					}
					if (GlobalScript.inst.gameState.data[22] >= 100)
					{
						fake_text[2] = "Disperse the protesters";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Army will not support us";
					}
					if (GlobalScript.inst.gameState.data[3] > 500)
					{
						fake_text[3] = "Call a loyal part of the people in support";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "People do not need another 文化大革命";
					}
					if (GlobalScript.inst.gameState.data[9] >= 150)
					{
						fake_text[4] = "Break up the protest from the inside by the secret services";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Intelligence agencies can not cope";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 6)
				{
					kolvo_variant = 4;
					fake_text[0] = "Urgently allocate money for social programs";
					if ((GlobalScript.inst.gameState.empires[0].relations >= 500 && !GlobalScript.inst.gameState.allcountries[1].isSEV) || (GlobalScript.inst.gameState.empires[1].relations >= 500 && !GlobalScript.inst.gameState.allcountries[51].Torg && !GlobalScript.inst.gameState.allcountries[1].econ))
					{
						fake_text[1] = "Request foreign humanitarian assistance";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We can't ask for help";
					}
					if (GlobalScript.inst.gameState.data[16] >= 13)
					{
						fake_text[2] = "Call on business by carrot and stick policy to solve social problems";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We can't call on business, we don't have it";
					}
					if (GlobalScript.inst.gameState.data[1] >= 500)
					{
						fake_text[3] = "Arrange charity at the expense of the party and officials";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Party does not want to share";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 7)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[51] != 30 || GlobalScript.inst.gameState.data[6] <= 950)
					{
						fake_text[0] = "Organize detente at our expense";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We will not surrender!";
					}
					if (GlobalScript.inst.gameState.influencePRC >= 50)
					{
						fake_text[1] = "Pass a part of foreign policy positions as a sign of goodwill";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Our influence is too weak, so we cannot limit it";
					}
					if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Launch nukes into imperialists!";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Nobody wants a nuclear war";
					}
					fake_text[3] = "Don't care at all";
					if (GlobalScript.inst.dlc[6])
					{
						kolvo_variant = 5;
						if (GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.data[168] >= 50)
						{
							fake_text[4] = "Bribe U.S. senators to keep the issue quiet";
						}
						else if (!GlobalScript.inst.gameState.modifies[17].active)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "U.S. sanctions are required";
						}
						else
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "Need 5.0 money in the Swiss bank";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 8)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[51] != 30 || GlobalScript.inst.gameState.data[6] <= 950)
					{
						fake_text[0] = "Organize detente at our expense";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We will not surrender!";
					}
					if (GlobalScript.inst.gameState.influencePRC >= 50)
					{
						fake_text[1] = "Pass a part of foreign policy positions as a sign of goodwill";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Our influence is too weak, so we cannot limit it";
					}
					if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Launch nuclear weapons into revisionists!";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Nobody wants a nuclear war";
					}
					fake_text[3] = "Don't care at all";
					if (GlobalScript.inst.dlc[6])
					{
						kolvo_variant = 5;
						if (GlobalScript.inst.gameState.modifies[17].active && GlobalScript.inst.gameState.data[168] >= 50)
						{
							fake_text[4] = "Bribe U.S. senators to keep the issue quiet";
						}
						else if (!GlobalScript.inst.gameState.modifies[17].active)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "U.S. sanctions are required";
						}
						else
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "Need 5.0 money in the Swiss bank";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 9)
				{
					kolvo_variant = 3;
					fake_text[0] = "We can do nothing";
					if (GlobalScript.inst.gameState.data[18] < 23)
					{
						fake_text[1] = "Give them more autonomy";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We cannot give more autonomy";
					}
					if (GlobalScript.inst.gameState.data[56] != 4 || GlobalScript.inst.gameState.data[22] >= 100)
					{
						fake_text[2] = "Send troops to restore order";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Just crush them with army will not work";
					}
					if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 40 || GlobalScript.inst.gameState.data[36] >= 40 || GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[3] = "Conduct a rigged sovereignty referendum";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We have neither the means nor the forces for falsification";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 10)
				{
					kolvo_variant = 3;
					fake_text[0] = "We can do nothing";
					if (GlobalScript.inst.gameState.data[18] < 23)
					{
						fake_text[1] = "Give them more autonomy";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We cannot give more autonomy";
					}
					if (GlobalScript.inst.gameState.data[56] != 4 || GlobalScript.inst.gameState.data[22] >= 100)
					{
						fake_text[2] = "Send troops to restore order";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Just crush them with army will not work";
					}
					if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 20 || GlobalScript.inst.gameState.data[36] >= 20 || GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[3] = "Conduct a rigged sovereignty referendum";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We have neither the means nor the forces for falsification";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 11)
				{
					kolvo_variant = 4;
					fake_text[0] = "Urgently allocate money for development";
					if (GlobalScript.inst.gameState.empires[0].relations >= 60 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
					{
						fake_text[1] = "Attract foreign investment";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Investors will not go to us";
					}
					if (GlobalScript.inst.gameState.empires[1].relations >= 70 || GlobalScript.inst.gameState.relres)
					{
						fake_text[2] = "Request help from the USSR";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We don't need handouts from revisionists!";
					}
					if (GlobalScript.inst.gameState.data[13] >= 500)
					{
						fake_text[3] = "Foster development at the expense of agriculture";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Position in agriculture is not much better";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 12)
				{
					kolvo_variant = 4;
					fake_text[0] = "Urgently allocate money for development";
					if (GlobalScript.inst.gameState.empires[0].relations >= 60 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
					{
						fake_text[1] = "Attract foreign investment";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Investors will not go to us";
					}
					if (GlobalScript.inst.gameState.empires[1].relations >= 70 || GlobalScript.inst.gameState.relres)
					{
						fake_text[2] = "Request help from the USSR";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We don't need handouts from revisionists!";
					}
					if (GlobalScript.inst.gameState.data[12] >= 500)
					{
						fake_text[3] = "Foster development at the expense of industry";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Position in industry is not much better";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 13)
				{
					kolvo_variant = 4;
					fake_text[0] = "Urgently allocate money for development";
					if (GlobalScript.inst.gameState.empires[0].relations >= 60 && (GlobalScript.inst.gameState.data[16] >= 13 || GlobalScript.inst.gameState.SEZ))
					{
						fake_text[1] = "Attract foreign investment";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Investors will not go to us";
					}
					if (GlobalScript.inst.gameState.empires[1].relations >= 70 || GlobalScript.inst.gameState.relres)
					{
						fake_text[2] = "Request help from the USSR";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We don't need handouts from revisionists!";
					}
					if (GlobalScript.inst.gameState.data[12] >= 500 || GlobalScript.inst.gameState.data[13] >= 500)
					{
						fake_text[3] = "Foster development at the expense of agriculture and industry";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Position in agriculture and industry is not much better";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 14)
				{
					kolvo_variant = 4;
					int num2 = 0;
					if (GlobalScript.inst.gameState.data[16] >= 13 && GlobalScript.inst.gameState.data[5] >= 500)
					{
						fake_text[0] = "Raise taxes and cut social programs";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "";
						num2++;
					}
					if (GlobalScript.inst.gameState.data[16] >= 14)
					{
						fake_text[1] = "Raise taxes on luxury and for the super rich";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We have no oligarchs";
						num2++;
					}
					if (GlobalScript.inst.gameState.data[16] <= 14 && GlobalScript.inst.gameState.data[56] != 0 && (GlobalScript.inst.gameState.data[15] > 7 || GlobalScript.inst.gameState.data[56] != 1))
					{
						fake_text[3] = "Conduct rapid privatization of state-owned enterprises";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We can't do further privatization";
						num2++;
					}
					if (GlobalScript.inst.gameState.empires[0].relations > 500 || (GlobalScript.inst.gameState.empires[1].relations > 500 && GlobalScript.inst.gameState.influencePRC >= 50) || num2 >= 3)
					{
						fake_text[2] = "Take a foreign loan";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Nobody wants to get a credit for us";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 15)
				{
					kolvo_variant = 3;
					fake_text[0] = "Do not interfere";
					if (GlobalScript.inst.gameState.data[9] >= 30 && GlobalScript.inst.gameState.data[56] != 0)
					{
						fake_text[1] = "Remove Pol Pot in favor of the trio of Hu Nim, Hou Yuon and Khieu Samphan";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We can't remove Pol Pot";
					}
					if (GlobalScript.inst.gameState.data[56] != 4)
					{
						fake_text[2] = "Help the Khmer Rouge";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We can not help the dictator!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 16)
				{
					kolvo_variant = 3;
					fake_text[0] = "Do not interfere";
					if (GlobalScript.inst.gameState.data[9] >= 20 || GlobalScript.inst.gameState.allcountries[34].stab == 1)
					{
						fake_text[1] = "Support the CPT and create a coalition with the left and the democrats";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough strength to support CPT";
					}
					if (GlobalScript.inst.gameState.data[22] >= 20 && GlobalScript.inst.gameState.data[56] != 4)
					{
						fake_text[2] = "To hell with the election! It is better to send CPT more weapons for guerrilla warfare.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We can not send CPT more weapons";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 17)
				{
					kolvo_variant = 3;
					fake_text[0] = "It's not our business";
					if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.data[22] >= 30 && GlobalScript.inst.gameState.data[41] == 100)
					{
						fake_text[1] = "Send armed CPT units to help demonstrators and provoke an uprising";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough strength to organize the uprising";
					}
					fake_text[2] = "Condemn the cruelty of Thailand";
				}
				else if (GlobalScript.inst.gameState.number_event == 18)
				{
					kolvo_variant = 1;
					if (GlobalScript.inst.gameState.data[82] < 8)
					{
						fake_text[0] = "Long live the peace!";
					}
					else
					{
						fake_text[0] = "A must-read!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 19)
				{
					kolvo_variant = 4;
					fake_text[0] = "Let it pass, how it goes";
					fake_text[1] = "Follow the strict execution of Mao’s decrees";
					fake_text[2] = "Follow the strict execution of the campaign, as well as criticize Zhou in the media.";
					fake_text[3] = "Gently sabotage the campaign";
				}
				else if (GlobalScript.inst.gameState.number_event == 20)
				{
					kolvo_variant = 3;
					fake_text[0] = "Do nothing. 江青 and 小平 each other stand";
					fake_text[1] = "Join 小平's persecution";
					fake_text[2] = "Stand up for 小平";
				}
				else if (GlobalScript.inst.gameState.number_event == 21)
				{
					kolvo_variant = 3;
					fake_text[0] = "Stay quiet, targets unclear, don’t get caught in the crossfire";
					fake_text[1] = "Clamp down on the publication and speculation to avoid stirring the masses";
					fake_text[2] = "Turn the article against capitalist-roadings reforms";
				}
				else if (GlobalScript.inst.gameState.number_event == 22)
				{
					kolvo_variant = 3;
					fake_text[0] = "Disperse protest with the help of the army and police";
					fake_text[2] = "Call everyone to go away and cordon off the rest until they leave";
					if (GlobalScript.inst.gameState.data[88] >= 0)
					{
						fake_text[1] = "Call all to go away and disperse the remaining";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "People don't want to go away!";
					}
					if (GlobalScript.inst.gameState.data[88] >= 2)
					{
						fake_text[2] = "Call everyone to go away and cordon off the rest until they leave";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "People don't want to go away!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 23)
				{
					kolvo_variant = 4;
					fake_text[0] = "Allocate funds from the budget for restoration (-3.0 from budget)";
					if (GlobalScript.inst.gameState.empires[0].relations >= 600 || GlobalScript.inst.gameState.empires[1].relations >= 600)
					{
						fake_text[1] = "Request foreign humanitarian assistance";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Foreigners will not give us help";
					}
					fake_text[2] = "Allocate funds for the restoration and development of the earthquake protection system (-5.0 from budget)";
					fake_text[3] = "Let the provincial administration deal with it";
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
					fake_text[0] = "Arrest all four";
					fake_text[1] = "Arrest 王洪文 and 江青 and find a compromise with the rest of the radicals";
					fake_text[2] = "Compromise and enlist the support of the radicals";
					fake_text[3] = "Do not interfere with the disassembly of the party";
				}
				else if (GlobalScript.inst.gameState.number_event == 26)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 70)
					{
						fake_text[0] = "Arrest all four";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "You already have no strength";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[1] = "Arrest only 王洪文 and 江青";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "You already have no strength";
					}
					fake_text[2] = "Abandon the struggle and go for a gradual transfer of power";
				}
				else if (GlobalScript.inst.gameState.number_event == 27)
				{
					kolvo_variant = 3;
					fake_text[0] = "Agree on the transfer of colonies while maintaining their broad autonomy";
					fake_text[1] = "Agree on the transfer of colonies while maintaining their limited autonomy";
					fake_text[2] = "Require full integration of colonies in the 中华人民共和国 while preserving the property rights of foreigners";
				}
				else if (GlobalScript.inst.gameState.number_event == 28)
				{
					kolvo_variant = 3;
					fake_text[0] = "Do not interfere, Suharto and so doomed";
					if (GlobalScript.inst.gameState.data[9] >= 30)
					{
						fake_text[1] = "Support the moderate left opposition";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough strength to support the left";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[2] = "Help the communist underground to re-organize";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We will not be able to restore the communist movement";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 29)
				{
					kolvo_variant = 4;
					fake_text[0] = "Require limited political liberalization";
					fake_text[1] = "Require broad political and economic reforms";
					if (GlobalScript.inst.gameState.data[16] >= 13)
					{
						fake_text[2] = "Require the opening of the SEZ for Chinese companies";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We will not and can not deal with imperialism";
					}
					fake_text[3] = "Demand the greatest possible democratization";
				}
				else if (GlobalScript.inst.gameState.number_event == 30)
				{
					kolvo_variant = 3;
					fake_text[0] = "Propose the creation of an Arab state in parts of Palestine";
					fake_text[1] = "Propose the creation of autonomy for the Arabs until further resolution of the crisis";
					fake_text[2] = "Propose the creation of a union state of Arabs and Jews";
				}
				else if (GlobalScript.inst.gameState.number_event == 31)
				{
					kolvo_variant = 3;
					fake_text[0] = "Do not interfere in the democratic process";
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[1] = "Help Kim Dae-jung build an opposition coalition";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have the strength to support him";
					}
					if (GlobalScript.inst.gameState.data[9] >= 60 && GlobalScript.inst.gameState.influencePRC >= 200 && GlobalScript.inst.gameState.data[83] != 2 && GlobalScript.inst.gameState.data[83] != 1)
					{
						fake_text[2] = "Help Kim Dae-jung and put pressure on the DPRK, pushing for unification";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We do not have enough strength for such an event";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 32)
				{
					kolvo_variant = 2;
					fake_text[0] = "Watch the situation";
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[1] = "Take advantage of the situation for our purposes";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough strength";
					}
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "Provoke anti-Soviet speeches to help suppress them? Seriously?";
				}
				else if (GlobalScript.inst.gameState.number_event == 33)
				{
					kolvo_variant = 3;
					fake_text[0] = "Keep out";
					if (GlobalScript.inst.gameState.data[9] >= 60)
					{
						fake_text[1] = "Help Bhutto";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We can not help";
					}
					fake_text[2] = "Do not intervene and build relationships with the new government.";
				}
				else if (GlobalScript.inst.gameState.number_event == 34)
				{
					kolvo_variant = 4;
					fake_text[0] = "Carefully strike reformers";
					fake_text[1] = "Only promote loyal conservatives";
					fake_text[2] = "Strike reformers to clear the way for moderate-conservatives";
					if (GlobalScript.inst.gameState.data[87] != 1 && GlobalScript.inst.gameState.data[87] != 2)
					{
						fake_text[3] = "We need a strong alliance with reformers!";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "You can't negotiate with revisionists!";
					}
					fake_text[4] = "Do not break the wobbling balance in the party";
				}
				else if (GlobalScript.inst.gameState.number_event == 35)
				{
					kolvo_variant = 4;
					fake_text[0] = "Do nothing, enough concessions";
					fake_text[1] = " Limit with small civil liberalization";
					fake_text[2] = "Loosen control and put pressure on tradition";
					if (GlobalScript.inst.gameState.data[56] != 0)
					{
						fake_text[3] = "Loosen control and go only to the supervision of religion";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We cannot go for such a liberalization!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 36)
				{
					kolvo_variant = 3;
					fake_text[0] = "No, not worth it";
					fake_text[1] = "Condemn the Baath leadership";
					if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.influencePRC >= 50)
					{
						fake_text[2] = "With the help of special services and political pressure incline the parties to dialogue";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We do not have enough strength and influence";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 37)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] <= 1 && GlobalScript.inst.gameState.allcountries[30].stab == 1) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "By all means we will support the speeches and provoke the overthrow of Sadat";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "This is too radical interference in the affairs of Egypt!";
					}
					if (GlobalScript.inst.gameState.data[9] >= 20 && (GlobalScript.inst.gameState.data[56] <= 2 || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "Help Libya and Syria overthrow Sadat";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Do we really need this North Africa?";
					}
					fake_text[2] = "The affairs of Egypt do not bother us";
				}
				else if (GlobalScript.inst.gameState.number_event == 38)
				{
					kolvo_variant = 3;
					int num3 = 0;
					if (GlobalScript.inst.gameState.data[87] != 4)
					{
						fake_text[1] = "Revive a planned system (-1.0 from budget)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "The party goes to reform, following your course!";
						num3++;
					}
					if (GlobalScript.inst.gameState.data[84] != 3 && GlobalScript.inst.gameState.data[87] != 2 && GlobalScript.inst.gameState.data[87] != 1 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "Start preparing for further large-scale reforms";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Down with revisionism!";
						num3++;
					}
					if ((GlobalScript.inst.gameState.data[87] != 2 && GlobalScript.inst.gameState.data[87] != 4) || num3 >= 2)
					{
						fake_text[0] = "Do not break what works";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "The old system has outlived its!";
						num3++;
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 39)
				{
					kolvo_variant = 3;
					fake_text[0] = "Chairman " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " personally lead the commission of conservative Maoists. Our path is right!";
					fake_text[1] = "We will entrust the work to 邓小平 and pragmatic reformers. They will give a balanced assessment.";
					if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Comrades Peng Zhen and 赵紫阳 will reveal all the mistakes and expose them!";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Zhen? Ziyang? These are liberals whom Chairman Mao expelled!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 40)
				{
					kolvo_variant = 5;
					if (GlobalScript.inst.gameState.data[56] <= 1)
					{
						fake_text[0] = "Let he sit further!";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We can't keep him in prison any longer!";
					}
					if (GlobalScript.inst.gameState.data[56] <= 2)
					{
						fake_text[1] = "Release from prison in exchange for waiving monastic vows.";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "This is too much pressure on him!";
					}
					if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.data[56] != 0 && GlobalScript.inst.gameState.data[56] != 4)
					{
						fake_text[2] = "Release and let go back to Lhasa, but under the supervision of the Ministry of State Security (4 agent networks).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Or let him be in prison, or let him be free.";
					}
					if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "Release the prisoner of conscience and rehabilitate him!";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Rehabilitate?! Chairman Mao himself accused him!";
					}
					if (GlobalScript.inst.gameState.data[9] >= 70 && GlobalScript.inst.gameState.data[56] != 4)
					{
						fake_text[4] = "Eliminate him under the guise of a heart attack and force to elect Norbu as the new Panchen Lama.";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Panchen Lama should be chosen by the monks themselves!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 41)
				{
					kolvo_variant = 3;
					fake_text[0] = "Keep out";
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[1] = "Support the opposition";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough strength";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.data[56] != 0)
					{
						fake_text[2] = "Support Indira Gandhi";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Support Gandhi? Maybe even give her the Tibetan territory?";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 42)
				{
					kolvo_variant = 5;
					fake_text[0] = "Do not interfere";
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[1] = "Support left organizations";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We can not help";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "Support the Islamists";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Help religious fanatics? No way!";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "Support ruling regime";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We will never support the pro-American shah!";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[4] = "Support the democrats";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Support the democrats";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 43)
				{
					kolvo_variant = 2;
					fake_text[0] = "Do not interfere";
					if (GlobalScript.inst.gameState.data[9] >= 30 && (GlobalScript.inst.gameState.allcountries[23].Gosstroy != 0 || GlobalScript.inst.gameState.allcountries[23].EAF))
					{
						fake_text[1] = "By all means stop the entry process";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We can do nothing";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 44)
				{
					kolvo_variant = 3;
					fake_text[0] = "Agree to start reforms and transfer power to " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2];
					if (GlobalScript.inst.gameState.data[9] >= 150)
					{
						fake_text[1] = "Delay the meeting in order to arrest the reformers during the break by the forces of the 国家安全部";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We have neither the strength nor the effect on such";
					}
					if (GlobalScript.inst.gameState.data[87] != 1 && GlobalScript.inst.gameState.data[87] != 2)
					{
						fake_text[2] = "Agree with their demands in exchange for retaining power";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "After your statements, they will not cooperate";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 45)
				{
					kolvo_variant = 1;
					fake_text[0] = "Forward to the socialist market!";
				}
				else if (GlobalScript.inst.gameState.number_event == 46)
				{
					kolvo_variant = 4;
					fake_text[0] = "Europe is far, Asia is more important to us";
					if (GlobalScript.inst.gameState.data[9] >= 80)
					{
						fake_text[1] = "Organize the support and coordination of Bеla Biszku and his people with our special services";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough strength";
					}
					if (GlobalScript.inst.gameState.data[9] >= 30 && GlobalScript.inst.gameState.data[22] >= 10)
					{
						fake_text[2] = "Help in the organization of the pro-Chinese uprising";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "New uprising in Hungary ?! Think again!";
					}
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "We can not help, but with joy we will hide Biszku from the wrath of the revisionists";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Europe is far, Asia is more important to us";
					}
					if (GlobalScript.inst.dlc[6])
					{
						kolvo_variant = 5;
						if (GlobalScript.inst.gameState.data[9] >= 80)
						{
							fake_text[4] = "Sow chaos in the ranks of the MSZMP hoping to catch a fish in these muddy waters.";
						}
						else
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "We do not have enough strength";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 47)
				{
					kolvo_variant = 3;
					fake_text[0] = "Let the 国家安全部 and the Human Resources Officer in the 中共 address these issues";
					fake_text[1] = "Join the controversy with the reformers and make your own denials";
					fake_text[2] = "Our media will deal with this cheap propaganda";
				}
				else if (GlobalScript.inst.gameState.number_event == 63)
				{
					kolvo_variant = 4;
					fake_text[0] = "Do not interfere in Afghan affairs";
					if (GlobalScript.inst.gameState.data[9] >= 30)
					{
						fake_text[1] = "Give support to the opposition loyal to us in the DRA";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We have no strength for that";
					}
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "Establish relationships and support the Khalq";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "They will not cooperate";
					}
					if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "Build relationships and support Parcham";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "They will not cooperate";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 48)
				{
					kolvo_variant = 3;
					fake_text[0] = "It’s better not to get involved";
					fake_text[1] = "Start a secret rapprochement with the DRA (-2.0 from the budget)";
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[2] = "We do not trust him... It is better to secretly agree with the USSR on his displacement, maybe we will get something from the new government.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "No collusion with the USSR!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 49)
				{
					kolvo_variant = 2;
					fake_text[0] = "This is a case of the USSR";
					if (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[9] >= 70)
					{
						fake_text[1] = "Warn Amin and send him help";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "No one will let us intervene";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 50)
				{
					kolvo_variant = 4;
					fake_text[0] = "No one. It's not our business";
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[1] = "Assist the DRA in exchange for the inclusion of Maoist parties in the alliance with the PDPA";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "The USSR will not allow us to intervene so deeply";
					}
					fake_text[2] = "Assist DRA";
					fake_text[3] = "Assist the Maoist rebels";
					fake_text[4] = "Sell guns to armed opposition, americans are willing to pay";
				}
				else if (GlobalScript.inst.gameState.number_event == 51)
				{
					kolvo_variant = 3;
					fake_text[0] = "Not respond";
					fake_text[1] = "Condemn the entry of troops";
					fake_text[2] = "Support the entry of troops";
				}
				else if (GlobalScript.inst.gameState.number_event == 53)
				{
					kolvo_variant = 4;
					fake_text[0] = "Let it be as it is";
					fake_text[1] = "Introduce the family contract";
					if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Introduce private farming";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We will not give agriculture to private speculators!";
					}
					if (GlobalScript.inst.gameState.data[89] == 0)
					{
						fake_text[3] = "Organize collective farms";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Collective farms - a relic of the plan";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 54)
				{
					kolvo_variant = 3;
					fake_text[0] = "Postpone this question";
					if (GlobalScript.inst.gameState.data[16] > 11)
					{
						fake_text[1] = "Open SEZ";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Mao will spin in the grave from such!";
					}
					if (GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[16] > 11)
					{
						fake_text[2] = "Open the SEZ and part of the rest enterprises for investment";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Mao will spin in the grave from such!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 55)
				{
					kolvo_variant = 3;
					fake_text[0] = "This does not concern us";
					fake_text[1] = "Send help to Ne Win and establish friendly relations (-3.0 from the budget)";
					if (GlobalScript.inst.gameState.data[9] >= 40 && GlobalScript.inst.gameState.allcountries[33].stab == 1)
					{
						fake_text[2] = "Help the communists organize a party coup";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We will not be able to help them";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 56)
				{
					kolvo_variant = 3;
					fake_text[0] = "We will not aggravate the situation";
					if (!GlobalScript.inst.gameState.allcountries[1].isSEV && GlobalScript.inst.gameState.war == 0)
					{
						fake_text[1] = "Get ready for war. Let's teach Vietnam a lesson!";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Everything goes as planned";
					}
					if (!GlobalScript.inst.gameState.event_done[14] && !GlobalScript.inst.gameState.allcountries[11].isSEV)
					{
						fake_text[2] = "Hold a meeting and negotiations of 中华人民共和国 and Vietnam";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "They will not negotiate with us";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 57)
				{
					kolvo_variant = 2;
					fake_text[0] = "This does not concern us";
					if (GlobalScript.inst.gameState.data[9] >= 60 && GlobalScript.inst.gameState.allcountries[44].stab == 1)
					{
						fake_text[1] = "Provide financial and undercover assistance to the CPJ";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "CPJ will not listen to us";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 58)
				{
					kolvo_variant = 1;
					fake_text[0] = "Revolution is over";
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
					fake_text[0] = "Ignore proposal";
					if (!GlobalScript.inst.gameState.allcountries[15].cw && !GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[1] = "Create economic union (-15.0 from budget)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We are not ready (-15 from the budget)";
					}
					if (!GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(4) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(10) && GlobalScript.inst.gameState.war <= 0 && GlobalScript.inst.gameState.relres && !GlobalScript.inst.gameState.allcountries[15].cw && GlobalScript.inst.gameState.data[56] <= 1 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[51].Torg)
					{
						fake_text[2] = "Join the CMEA";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "No negotiation with revisionists!";
					}
					if (GlobalScript.inst.gameState.war <= 0 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].isOVD && !GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.allcountries[1].Vyshi && !GlobalScript.inst.gameState.allcountries[15].cw)
					{
						fake_text[3] = "Join in the Non-Alignment Movement";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "They don't like you";
					}
					if (GlobalScript.inst.dlc[3])
					{
						if (!GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(3) && !GlobalScript.inst.gameState.startedDirectWarsNum.ContainsKey(12) && GlobalScript.inst.gameState.war <= 0 && GlobalScript.inst.gameState.allcountries[1].Gosstroy != 1 && !GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[51].Torg && GlobalScript.inst.gameState.data[52] > 34)
						{
							fake_text[4] = "Join the ASEAN";
						}
						else if (GlobalScript.inst.gameState.relres)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "Relations with the USSR should not be restored";
						}
						else if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 1)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "State formation is not to be a socialism";
						}
						else if (GlobalScript.inst.gameState.data[52] <= 34)
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "The party line should be Reform or more liberal";
						}
						else
						{
							galka_stuk[4].SetActive(value: false);
							fake_text[4] = "Need friendship with the US";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 60)
				{
					kolvo_variant = 2;
					if (GlobalScript.inst.gameState.data[22] >= 300 && GlobalScript.inst.gameState.data[9] >= 100 && !GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						fake_text[0] = "Create a military bloc (-5 from the budget, -30 army forces and -10 agent networks)";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We are not ready (-5 from the budget, -30 army forces and -10 agent networks)";
					}
					fake_text[1] = "Do nothing";
				}
				else if (GlobalScript.inst.gameState.number_event == 61)
				{
					kolvo_variant = 3;
					fake_text[0] = "Restore \"March of the Volunteers\" unchanged (-1 from the budget)";
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
						fake_text[2] = "Restore \"March of the Volunteers\", but with a new text (-1 from the budget)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "It is not necessary!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 62)
				{
					kolvo_variant = 5;
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "This is a fair step. That is exactly what we will do! (-3 from budget)";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "No concessions!";
					}
					fake_text[1] = "Is it too much honor for a minority? Refuse.";
					if (GlobalScript.inst.gameState.data[56] != 1)
					{
						fake_text[2] = "Territories will be returned, but assimilation will not be stoped.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "This is not in line with the national politic of the 中共!";
					}
					if (GlobalScript.inst.gameState.data[56] != 0 && GlobalScript.inst.gameState.data[56] != 3)
					{
						fake_text[3] = "It makes sense to stop the assimilation, but we will not return the territories (-1 from the budget)";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "This is not in line with the national politic of the 中共!";
					}
					if (GlobalScript.inst.gameState.data[50] != 24 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[18] < 23)
					{
						fake_text[4] = "The time has come to seriously address the national issue in small ARs. Stop all the excesses! (-6 from the budget)";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "There is no national question in China! It settled in the 50s once and for all.";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 52)
				{
					kolvo_variant = 4;
					fake_text[0] = "Let pakistan handle by himself";
					fake_text[1] = "Send Pakistan assistance to patrol the border and catch the Islamists";
					if (GlobalScript.inst.gameState.ingamewars[5].ussr_place != 1 && !GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[2] = "Negotiate with the USA";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "No help for reactionaries!";
					}
					if (GlobalScript.inst.gameState.ingamewars[5].ussr_place == 1)
					{
						fake_text[3] = "Why do we need all this? We better organize bases for Afghan Maoist insurgents in Pakistan (-5 from the budget)";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We can't help the Maoist insurgents in DRA";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 64)
				{
					kolvo_variant = 2;
					fake_text[0] = "It is not worth our strength";
					if (GlobalScript.inst.gameState.data[9] >= 50 && (!GlobalScript.inst.gameState.allcountries[30].prosov || GlobalScript.inst.gameState.relres))
					{
						fake_text[1] = "Assist in the creation of an UAR (-7 from the budget, -5 agent networks)";
					}
					else if (GlobalScript.inst.gameState.data[9] < 50)
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Need 5 agent networks...";
					}
					else if (GlobalScript.inst.gameState.allcountries[30].prosov && !GlobalScript.inst.gameState.relres)
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Relations with the USSR has not been restored...";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "They won't agree on that...";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 65)
				{
					kolvo_variant = 5;
					int num4 = 0;
					if ((GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))) || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[0] = "Sport is out of politics! We will take part in the Moscow Olympics and send the best athletes! (-4 from the budget)";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						num4++;
						fake_text[0] = "We can not ignore the opinion of the West";
					}
					if ((GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[56] != 0))
					{
						fake_text[1] = "We do not declare boycott, but ignore both Games...";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						num4++;
						fake_text[1] = "We cannot ignore both Games!";
					}
					if (GlobalScript.inst.gameState.data[89] > 0 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "We declare a boycott to the Soviet Games and send the team to the USA (-3 from the budget).";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						num4++;
						fake_text[3] = "Go to the USA?! Are you serious?..";
					}
					if (GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[4] = "We revive GANEFO and send invitations to developing countries (-20 from the budget).";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						num4++;
						fake_text[4] = "Enough of the Maoist experiments!";
					}
					if ((((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[56] != 0) || num4 >= 4)
					{
						fake_text[2] = "Let's declare a boycott, but let our athletes go to Moscow under the Olympic flag (-4 from the budget).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "This is not our policy!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 66)
				{
					kolvo_variant = 4;
					fake_text[0] = "Express our condolences, but no more.";
					if ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0) || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[1] = "Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " personally lead the government delegation and fly to Belgrade.";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " cannot personally fly to the funeral of the revisionist Tito!";
					}
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Send a delegation led by State Council General-Secretary Ji Pengfei.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "No delegations to Belgrade!";
					}
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "Did Tito die? Well, let it be, who cares?";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We cannot fail to respond to his death!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 67)
				{
					kolvo_variant = 5;
					fake_text[0] = "The affairs of Poland are not related to China. Themselves done things - yourself and sort it out!";
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[1] = "Support the pro-Soviet military led by General Wojciech Witold Jaruzelski (-5 agents, -20 from the budget).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "The treaty of friendship with the USSR has not been signed...";
					}
					if (GlobalScript.inst.gameState.allcountries[20].proprc && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "We form a coalition with the Mijal's Communist Party of Poland, Siwak's \"concrete\", the \"PAX\"  group and the \"Grunwald\" society (-15 agents, -30 from the budget).";
					}
					else if (!GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Albania should be in our sphere of influence...";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Reformists and liberals should not lead...";
					}
					if (GlobalScript.inst.gameState.empires[1].relations >= 600 && GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						fake_text[3] = "Let us turn to the Warsaw Pact countries with a proposal for military intervention (-5 agents, -5 army forces).";
					}
					else if (!GlobalScript.inst.gameState.allcountries[1].isOVD)
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We should be in the Warsaw Pact...";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Relations with the USSR should be above 60.0...";
					}
					if (GlobalScript.inst.gameState.empires[0].relations >= 600 && GlobalScript.inst.gameState.allcountries[51].Torg && !GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[4] = "Together with the United States support \"Solidarity\" (-10 from the budget, -20 agents)";
					}
					else if (!GlobalScript.inst.gameState.allcountries[51].Torg)
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "We need a friendship treaty with the US...";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "Relations with the US should be above 60.0...";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 68)
				{
					kolvo_variant = 2;
					fake_text[0] = "Let them deal with it by themselves";
					if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[22] >= 80)
					{
						fake_text[1] = "Assist the rebels and provoke unrest (-8 army forces, -10 agent networks)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough resources";
						fake_text[2] = "Call the parties to dialogue";
						fake_text[3] = "Support the actions of Chun Doo-hwan";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 69)
				{
					kolvo_variant = 3;
					fake_text[0] = "Do nothing. Different views - a pledge of democracy.";
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
						fake_text[1] = "Attack conservatives at the 中共 plenum and promote active reformers";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "中共 will not let you just mix manpower";
					}
					if (GlobalScript.inst.gameState.data[1] >= 600 && num5 > num6)
					{
						fake_text[2] = "Attack conservatives at the 中共 plenum";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "中共 will not let you eliminate them so easily";
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
					fake_text[0] = "Do nothing. Different views - a pledge of democracy.";
					if (GlobalScript.inst.gameState.data[1] >= 800 && num8 > num7)
					{
						fake_text[1] = "Attack reformers and moderates at the 中共 plenum";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Reformers will not give up so easily!";
					}
					if (GlobalScript.inst.gameState.data[1] >= 700 && GlobalScript.inst.gameState.data[90] != 0)
					{
						fake_text[2] = "Enlist the support of the moderates and attack the reformers at the plenum";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Moderates will not agree with us";
					}
					fake_text[3] = "Arrest the leaders of the reformers and start a campaign against their supporters. All by the covenants of Mao!";
				}
				else if (GlobalScript.inst.gameState.number_event == 71)
				{
					kolvo_variant = 3;
					fake_text[0] = "Let them continue to partisan, this is enough for us so far";
					if (GlobalScript.inst.gameState.influencePRC >= 100 && GlobalScript.inst.gameState.allcountries[19].Torg)
					{
						fake_text[1] = "Achieve the inclusion of Naxalites in local government in exchange for the cessation of hostilities";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "They will not negotiate with us";
					}
					if (!GlobalScript.inst.gameState.allcountries[19].Torg && GlobalScript.inst.gameState.war == 0 && !GlobalScript.inst.gameState.allcountries[15].cw)
					{
						fake_text[2] = "Get ready for war. Send troops.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We are not forging relationships to start a war now!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 72)
				{
					kolvo_variant = 3;
					fake_text[0] = "Good luck and good mood";
					if (GlobalScript.inst.gameState.data[91] == 1)
					{
						fake_text[1] = "Support the left wing (-6 agents, -10 from the budget)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Janata will not listen to us";
					}
					if (GlobalScript.inst.gameState.data[91] == 1)
					{
						fake_text[2] = "Support the right wing (-6 agents, -10 from the budget)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Janata will not listen to us";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 73)
				{
					kolvo_variant = 4;
					fake_text[0] = "War is hell";
					galka_stuk[1].SetActive(value: false);
					fake_text[1] = "War. War never changes";
					galka_stuk[2].SetActive(value: false);
					fake_text[2] = "War is peace";
					galka_stuk[3].SetActive(value: false);
					fake_text[3] = "If you want peace, prepare for war";
				}
				else if (GlobalScript.inst.gameState.number_event == 74)
				{
					kolvo_variant = 5;
					if (GlobalScript.inst.gameState.data[90] == 0)
					{
						fake_text[0] = "The plenary approves this option.";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "That isn't possible.";
					}
					if (GlobalScript.inst.gameState.data[90] == 1)
					{
						fake_text[1] = "The plenary approves this option.";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "That isn't possible.";
					}
					if (GlobalScript.inst.gameState.data[90] == 2)
					{
						fake_text[2] = "The plenary approves this option.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "That isn't possible.";
					}
					fake_text[3] = "What did you write here?! Immediately send the text for revision!";
					if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[4] = "The question of \"Decision\" is removed from the agenda at the request of the Chairman.";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "This issue is too important for the 中共 to remove it from the agenda.";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 75)
				{
					kolvo_variant = 4;
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "We will condemn the airstrike and offer Hussein to expand cooperation (-8 from the budget).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "Saddam Hussein - authoritarians, and a chauvinist. We don't need to support him!";
					}
					fake_text[1] = "Who cares? Let Saddam deal with his own problems...";
					if (GlobalScript.inst.gameState.data[12] >= 600 && GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "We will help Iraq to resume its nuclear program. Let imperialism tremble! (-15 from the budget, -10 agents).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Give Iraq an atomic bomb?! You want to start a Third world war?";
					}
					if ((GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "We will approve the airstrike and condemn Hussein for militarism and chauvinism.";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We can't justify what the Zionists did!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 76)
				{
					kolvo_variant = 4;
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "We will diplomatically support the Kosovo separatists, but nothing more.";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "That's not our problem.";
					}
					if (((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						fake_text[1] = "Offer Albania its assistance in the separation of Kosovo from Yugoslavia (-5 agents -5 from the budget).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Why do we need to help Albania?";
					}
					fake_text[2] = "Do not interfere.";
					if (GlobalScript.inst.gameState.data[9] >= 100)
					{
						fake_text[3] = "We will assist the Kosovo separatists with special services and money (-10 agents -10 from the budget).";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "We are not interested in the Affairs of Yugoslavia.";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 77)
				{
					kolvo_variant = 3;
					if (((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)) && GlobalScript.inst.gameState.data[9] >= 80)
					{
						fake_text[0] = "Help Shehu to organize a coup (-8 agents).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We don't have enough resources.";
					}
					fake_text[1] = "This is their own problem.";
					if (GlobalScript.inst.gameState.allcountries[20].proprc || (GlobalScript.inst.gameState.allcountries[20].econ && GlobalScript.inst.gameState.data[60] == 0))
					{
						fake_text[2] = "We support Hoxha.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Why would we support Hoxha after he turned his back on us?";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 78)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.data[22] >= 80 && ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "Provoke unrest and to support the Maoists (-10 agents -8 the strength of the army).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "It's not worth our effort.";
					}
					fake_text[1] = "It's none of our business.";
					if (GlobalScript.inst.gameState.data[6] < 800 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "Congratulate Marcos after his victory and try to establish cooperation.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We don't need cooperation with American puppets.";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 79)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.empires[1].relations > 500 && GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[0] = "We will call on the socialist camp to help Romania jointly (-10 from the budget).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "The socialist camp won't listen to us.";
					}
					fake_text[1] = "Let him pay his debts, that's not our problem.";
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Provide material assistance to Romania (-30 from the budget).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Romania is not worth our efforts.";
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
						fake_text[0] = "It's time to tell the party the truth!";
					}
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || GlobalScript.inst.gameState.data[15] > 7)
					{
						fake_text[1] = "Mention of \"individual errors\" Mao, under the pretext of combating which we begin a cautious departure from him.";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We can't criticize Mao!";
					}
					if ((GlobalScript.inst.gameState.data[56] > 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "We will use the experience of Khrushchev - he did it, and we will!";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Are you crazy to act like Khrushchev?!!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 81)
				{
					kolvo_variant = 5;
					if ((GlobalScript.inst.gameState.data[56] == 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0) || (GlobalScript.inst.gameState.data[56] == 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[0] = "We will provide Hungary with economic assistance without preconditions (-35 from the budget).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We are not rich enough to sponsor kadarists.";
					}
					if (GlobalScript.inst.gameState.data[89] == 0 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "We use the problems of the HPR to discredit market reforms.";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "The example of Hungary is not proof of the failure of reforms.";
					}
					if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "We will offer Hungary economic aid, but in exchange for the rehabilitation of the Bisku Group (-15 from the budget, -8 Agents).";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "It's hardly good for us.";
					}
					if ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "We will fully support the rehabilitation of the Bisku Group in exchange for taking over the Hungarian national debt (-45 Money, -10 Agents).";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "It's too radical for us!";
					}
					fake_text[4] = "Ignore it.";
					if (GlobalScript.inst.dlc[6] && GlobalScript.inst.gameState.resultOfEvents[46] == 4)
					{
						kolvo_variant = 6;
						if (GlobalScript.inst.gameState.data[9] >= 80)
						{
							fake_text[5] = "Through diplomatic offices, agree with part of the 政治局 to repay the loan in exchange for the election of Pozhgay as the General Secretary (-45 Money)";
						}
						else
						{
							galka_stuk[5].SetActive(value: false);
							fake_text[5] = "We don't have enough power";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 82)
				{
					kolvo_variant = 1;
					fake_text[0] = "Who will win - the military regime of Argentina or the weakened and distant Britain?";
				}
				else if (GlobalScript.inst.gameState.number_event == 83)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "We organize a leak of information to the Central Committee of the CPSU and discredit Kulakov (-5 Agents).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "It's too dangerous!";
					}
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[1] = "We will publish revelatory materials about Kulakov in our media (-2 Money).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We don't need that.";
					}
					fake_text[2] = "We'll save that for the future...";
				}
				else if (GlobalScript.inst.gameState.number_event == 84)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 80 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "Car accident - the choice of professionals! (-8 Agents).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "It's too dangerous!";
					}
					fake_text[1] = "We get in touch with the Belarusian party members and through them pass to Suslov dirt on Masherov (-5 Money).";
					fake_text[2] = "Leave him alone.";
				}
				else if (GlobalScript.inst.gameState.number_event == 85)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "We use every effort to discredit Kunaev, once in the Republic will start riots (-10 Agents).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "It's too dangerous!";
					}
					if (GlobalScript.inst.gameState.relres && ((GlobalScript.inst.gameState.data[56] < 4 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "We will pre-empt him and warn him about the impending provocations of the CPSU Central Committee (-3 Agent).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We don't have a good enough relationship with Brezhnev to let him know.";
					}
					fake_text[2] = "We do not care about the Affairs of the Soviets.";
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[3] = "Our journalists, on behalf of our embassy, will investigate Rashidov's activities under the guise of reporting on the arts of Uzbekistan. (-3 agents, -3 money)";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Nobody's gonna give us permission.";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 86)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "We will help the head of the KGB to go to the other world, writing off this kidney failure. Ukrainian KGB will cope with this task (-10 Agents, -5 Money).";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "It's too dangerous!";
					}
					if (GlobalScript.inst.gameState.relres)
					{
						fake_text[1] = "Suslov and Shcherbitsky convene the Plenum of the Central Committee, and attack Andropov with our information support (-7 Money).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We don't have enough influence on the CPSU.";
					}
					fake_text[2] = "It's too dangerous!";
				}
				else if (GlobalScript.inst.gameState.number_event == 87)
				{
					kolvo_variant = 1;
					fake_text[0] = "Another war in the middle East...";
				}
				else if (GlobalScript.inst.gameState.number_event == 88)
				{
					kolvo_variant = 2;
					fake_text[0] = "We congratulate Mugabe on his victory and send him financial aid (-5 from the budget).";
					fake_text[1] = "We can be friends with him later.";
				}
				else if (GlobalScript.inst.gameState.number_event == 89)
				{
					kolvo_variant = 4;
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.empires[1].leaders[3].support > 0))
					{
						fake_text[0] = "Support Andropov.";
					}
					else if (GlobalScript.inst.gameState.empires[1].leaders[3].support <= 0)
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We do not have enough influence on the CPSU.";
					}
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.empires[1].leaders[1].support != 0))
					{
						fake_text[1] = "Support Scherbitsky.";
					}
					else if (GlobalScript.inst.gameState.empires[1].leaders[1].support == 0)
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough influence on the CPSU.";
					}
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 50 && GlobalScript.inst.gameState.data[9] >= 100))
					{
						fake_text[2] = "Support Chernenko.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We do not have enough influence on the CPSU.";
					}
					fake_text[3] = "Do not interfere and wait.";
				}
				else if (GlobalScript.inst.gameState.number_event == 90)
				{
					kolvo_variant = 4;
					if (GlobalScript.inst.gameState.data[9] >= 40 && ((GlobalScript.inst.gameState.data[56] > 1 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "We will negotiate with the Triads on favorable for them terms. (-4 agents)";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We can not negotiate with Organized crime!";
					}
					if (GlobalScript.inst.gameState.data[9] >= 30 && ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "We could use a tactical alliance with syndicates. But it will not save them from purge. (-2 Agents)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "No compromise with the underworld!";
					}
					fake_text[2] = "What do we care about these bandits?";
					if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[16] <= 13 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "It is time to strike a powerful blow against organized crime in the southern provinces of the country! (-8 agents)";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "These are quite honest businessmen supporting reforms and openness. We have no right to suspect them.";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 91)
				{
					kolvo_variant = 3;
					fake_text[0] = "Condemn North Korean terrorism";
					fake_text[1] = "Condemn South Korean provocation";
					fake_text[2] = "Keep silent";
				}
				else if (GlobalScript.inst.gameState.number_event == 92)
				{
					kolvo_variant = 5;
					fake_text[0] = "Invest in industrial upgrading (-1 from budget)";
					fake_text[1] = "Continue enhanced mechanization of agriculture (-1 from budget)";
					fake_text[2] = "Invest in improving the quality of services (-1 from the budget)";
					fake_text[3] = "Focus the five-year plan on the development of scientific research (-1 from the budget)";
					fake_text[4] = "Direct forces on the uniform development of the economy (-1 from the budget)";
				}
				else if (GlobalScript.inst.gameState.number_event == 93)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[0] = "Support PASOK";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We do not have enough strength";
					}
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[1] = "Support New Democracy";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough strength";
					}
					fake_text[2] = "Keep out";
				}
				else if (GlobalScript.inst.gameState.number_event == 94)
				{
					kolvo_variant = 4;
					fake_text[0] = "This is a counter-revolutionary rebellion, and the traitors will answer for it! Connect me with the General Staff...";
					fake_text[1] = "Block the square by the People's Armed Police and try to persuade the protesters to disperse.";
					fake_text[2] = "Retire. Let the Party decide who deserves to lead the country at this difficult time.";
					fake_text[3] = "Fulfill the demands of the protesters.";
				}
				else if (GlobalScript.inst.gameState.number_event == 95)
				{
					kolvo_variant = 4;
					fake_text[0] = "We reject Marxism-Maoism-Xiaopism in favor of European communism, modeled on the CPJ.";
					fake_text[1] = "Returning to the social democracy with Chinese characteristics according to the precepts of Chen Duxiu.";
					fake_text[2] = "Accept left Chinese nationalism, as bequeathed by the great Sun Yat-sen.";
					fake_text[3] = "Why do we have to comply with the requirements of some street bullies?";
				}
				else if (GlobalScript.inst.gameState.number_event == 96)
				{
					kolvo_variant = 4;
					fake_text[0] = "We are preparing free elections in the 全国人大, as much as possible limiting other parties, but other requirements will have to be met";
					fake_text[1] = "The elections are not so terrible as the bourgeois \"freedoms\". Do without it.";
					fake_text[2] = "Elections are not so terrible as leaving religion unattended. Do without it.";
					fake_text[3] = "If we want the people to love us, we must fulfill all of its requirements!";
				}
				else if (GlobalScript.inst.gameState.number_event == 97)
				{
					kolvo_variant = 2;
					fake_text[0] = "We are starting a large-scale implementation of automated systems";
					fake_text[1] = "Haste never ended well, let it be introduced gradually and not all at once";
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
						fake_text[0] = "Recognize the current government and send ambassadors.";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We can not support usurpers!";
					}
					fake_text[1] = "Ignore military coup.";
					if (GlobalScript.inst.gameState.influencePRC >= 100 && GlobalScript.inst.gameState.data[9] >= 30)
					{
						fake_text[2] = "Offer humanitarian aid.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We do not have enough resources and influence";
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
						fake_text[0] = "Do nothing. We were not invited";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We must go";
					}
					if (GlobalScript.inst.gameState.relres || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[1] = "Send Chinese delegation to the funeral";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Nobody will let us in";
					}
					if (GlobalScript.inst.gameState.relres || GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[2] = "Our leader will personally go to say goodbye to Yuri Vladimirovich";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "You cannot go in person!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 114)
				{
					kolvo_variant = 1;
					fake_text[0] = "We all waiting for results...";
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
						fake_text[0] = "We will help the orthodox in the fight against revisionism";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We do not have enough power";
					}
					if (GlobalScript.inst.gameState.data[9] >= 40)
					{
						fake_text[1] = "Support moderate reformers in the modernization of socialism";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough power";
					}
					if (GlobalScript.inst.gameState.data[9] >= 60 && ((GlobalScript.inst.gameState.data[56] >= 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "Facilitate the rise to power of pro-Western liberals";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We cannot support them";
					}
					fake_text[3] = "Stay away";
				}
				else if (GlobalScript.inst.gameState.number_event == 100)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.influencePRC >= 50 && GlobalScript.inst.gameState.data[9] >= 100 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[0] = "Provoke anti-government rallies by supporting the opposition";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We do not have enough power";
					}
					fake_text[1] = "We have our own problems at home.";
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "Send funds to support government.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We cannot support them";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 102)
				{
					kolvo_variant = 4;
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
					{
						fake_text[0] = "Support Gorbachev";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We do not have enough influence on the CPSU";
					}
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
					{
						fake_text[1] = "Support Romanov";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We do not have enough influence on the CPSU";
					}
					if ((GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[3] == 2) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.data[9] >= 100))
					{
						fake_text[2] = "Support Grishin";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We do not have enough influence on the CPSU";
					}
					fake_text[3] = "Do not interfere and wait";
				}
				else if (GlobalScript.inst.gameState.number_event == 104)
				{
					kolvo_variant = 3;
					fake_text[0] = "Send a delegation to the festival";
					fake_text[1] = "Do not send";
					fake_text[2] = "Conduct your own festival for the allied countries (-2 from the budget)";
				}
				else if (GlobalScript.inst.gameState.number_event == 105)
				{
					kolvo_variant = 3;
					fake_text[0] = "Do nothing";
					if ((GlobalScript.inst.gameState.allcountries[15].Torg || GlobalScript.inst.gameState.allcountries[20].Torg) && GlobalScript.inst.gameState.data[9] >= 60)
					{
						fake_text[1] = "Recruit a group of Kosovo Albanians and launch a terrorist attack (-6 agent networks)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Our intelligence will not cope with this";
					}
					if (!GlobalScript.inst.gameState.allcountries[20].Torg && !GlobalScript.inst.gameState.allcountries[20].proprc)
					{
						fake_text[2] = "Try to build relationships with the new management (-3 from the budget)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Sino-Albanian relations are normal";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 106)
				{
					kolvo_variant = 3;
					fake_text[0] = "It doesn't concern us";
					if (GlobalScript.inst.gameState.data[9] >= 100)
					{
						fake_text[1] = "Arrange a terrorist attack and disrupt the conference";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Our intelligence will not cope with this";
					}
					fake_text[2] = "Support the formation";
				}
				else if (GlobalScript.inst.gameState.number_event == 109)
				{
					kolvo_variant = 3;
					fake_text[0] = "Do nothing";
					if (GlobalScript.inst.gameState.data[9] >= 50 && GlobalScript.inst.gameState.influencePRC >= 200)
					{
						fake_text[1] = "Send military and humanitarian assistance to Somalia (-8 from the budget, -5 agent networks, -5 army strength)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "We cannot help Somalia";
					}
					if (GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.influencePRC >= 200)
					{
						fake_text[2] = "Organize a party coup against Barre (-8 agent networks)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We have no strength to be distracted by this";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 110)
				{
					kolvo_variant = 4;
					fake_text[0] = "Let's wait a couple more years... or more...";
					fake_text[1] = "Announce a course on automation of production and create a commission for its implementation (-10 from the budget)";
					if (GlobalScript.inst.gameState.empires[1].relations >= 500 && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.allcountries[1].isSEV)
					{
						fake_text[2] = "Start automation and invite Soviet scientists";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "Soviets will not help us";
					}
					if (GlobalScript.inst.gameState.empires[0].relations >= 600 && GlobalScript.inst.gameState.data[6] <= 800 && !GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.modifies[17].active)
					{
						fake_text[3] = "We are set to work, Western experts will help us!";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Ask for help from the West? Are you seriously?";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 111)
				{
					kolvo_variant = 4;
					fake_text[0] = "Give up the fight and resign";
					if (GlobalScript.inst.gameState.data[3] >= 900 && GlobalScript.inst.gameState.data[5] >= 900 && GlobalScript.inst.gameState.modifies[3].active)
					{
						fake_text[1] = "Call on the masses to fight against partyocracy";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "People do not need a new cultural revolution!";
					}
					if (GlobalScript.inst.gameState.data[9] >= 400)
					{
						fake_text[2] = "Arrest conspirators and start persecution against the most proactive partocrats (-40 agent networks)";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "国家安全部 will not support us!";
					}
					if ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[3] = "Mobilize loyal officers against conspirators";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Officers will not save us";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 112)
				{
					kolvo_variant = 3;
					fake_text[0] = "Allocate funds to develop a protection system (-25 from the budget)";
					if (GlobalScript.inst.gameState.empires[1].relations >= 800 && GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.modifies[3].active)
					{
						fake_text[1] = "Fund development and request assistance from specialists from the USSR (-25 from the budget)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Soviets will not help us";
					}
					if ((GlobalScript.inst.gameState.data[56] > 0 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[2] = "It seems that China is not ready for such changes, it is necessary to slow down automation";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We cannot give up our achievements!";
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 113)
				{
					kolvo_variant = 5;
					fake_text[0] = "What do we care about Yugoslavia? Let the titoists themselves deal with their problems!";
					if (GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[1] = "We will offer Yugoslavia a restructuring of its debts subject to a rejection of the reform plan (-5 agents, -20 from the budget).";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Why do we need to restructure their debts?";
					}
					if (((GlobalScript.inst.gameState.influencePRC >= 150 && GlobalScript.inst.gameState.allcountries[1].isSEV) || (GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.influencePRC >= 250)) && ((GlobalScript.inst.gameState.data[56] < 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[2] = "We join the proposal of the USSR.";
					}
					else
					{
						galka_stuk[2].SetActive(value: false);
						fake_text[2] = "We don’t have enough influence for the Soviet Union and Yugoslavia to listen us";
					}
					if (GlobalScript.inst.gameState.influencePRC >= 300 && GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] < 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[3] = "We will support a group of military men led by Veljko Kadijeviс and Branko Mamula";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Support the military junta? In Yugoslavia? Nonsense!";
					}
					if ((GlobalScript.inst.gameState.influencePRC >= 200 || GlobalScript.inst.gameState.allcountries[51].dev > 0) && GlobalScript.inst.gameState.data[9] >= 50 && ((GlobalScript.inst.gameState.data[56] >= 3 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)))
					{
						fake_text[4] = "Approve the American proposal.";
					}
					else
					{
						galka_stuk[4].SetActive(value: false);
						fake_text[4] = "We don’t have enough influence for the USA and Yugoslavia to listen us";
					}
					if (GlobalScript.inst.dlc[6])
					{
						kolvo_variant = 6;
						if (GlobalScript.inst.gameState.influencePRC >= 300 && GlobalScript.inst.gameState.data[9] >= 80 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 200)
						{
							fake_text[5] = "Offer to repurchase debt obligations with partial repayment in exchange for the admission of Chinese investments on favourable terms in the economy";
						}
						else
						{
							galka_stuk[5].SetActive(value: false);
							fake_text[5] = "We don't have enough strength";
						}
					}
				}
				else if (GlobalScript.inst.gameState.number_event == 115)
				{
					kolvo_variant = 3;
					fake_text[0] = "This is not our business";
					if ((GlobalScript.inst.gameState.data[56] >= 2 && GlobalScript.inst.gameState.data[15] < 8) || (summa_3_2 > 66 && GlobalScript.inst.gameState.data[15] > 7) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[0] > 1) || (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0))
					{
						fake_text[1] = "Go to an agreement with drug dealers (-1 intelligence network)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "The Chinese people did not fight opium magnates so that we would hobnob with them";
					}
					fake_text[2] = "Help allied countries in the fight against drug dealers (-2 intelligence networks, -2 army strength)";
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
					fake_text[0] = "Leave it as it is";
					if (GlobalScript.inst.gameState.data[6] <= 500 && GlobalScript.inst.gameState.empires[0].relations >= 600)
					{
						fake_text[1] = "Time for the long-awaited unification!";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "They are not ready to agree to such an agreement";
					}
					fake_text[2] = "Recognize each other and end hostility!";
				}
				else if (GlobalScript.inst.gameState.number_event == 103)
				{
					kolvo_variant = 3;
					if (GlobalScript.inst.gameState.allcountries[1].okb && GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						fake_text[0] = "Establish an analogue of the Schengen agreement only for members of our military alliance";
					}
					else if (GlobalScript.inst.gameState.allcountries[1].okb && !GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						fake_text[0] = "Establish an analogue of the Madrid agreement only for members of our military alliance";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "We do not have a military alliance";
					}
					if (GlobalScript.inst.gameState.allcountries[0].isEU)
					{
						fake_text[1] = "Establish an analogue of the Schengen agreement for members of all our alliances";
					}
					else
					{
						fake_text[1] = "Establish an analogue of the Madrid agreement for members of all our alliances";
					}
					fake_text[2] = "Do nothing";
				}
				else if (GlobalScript.inst.gameState.number_event == 107)
				{
					kolvo_variant = 5;
					int num9 = (GlobalScript.inst.gameState.data[21] - 1976) * 2 + 1;
					if (GlobalScript.inst.gameState.data[22] >= num9 * 10 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
					{
						fake_text[0] = $"Send troops and return the country to our course ({num9} army strength, -3 from the budget)";
					}
					else
					{
						galka_stuk[0].SetActive(value: false);
						fake_text[0] = "Our army does not have enough strength and authority";
					}
					if (GlobalScript.inst.gameState.data[9] >= 100 && GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
					{
						fake_text[1] = "Organize a coup in favor of forces loyal to us (-10 agents, -3 from the budget)";
					}
					else if (GlobalScript.inst.gameState.data[9] >= 200 && !GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
					{
						fake_text[1] = "Organize a coup in favor of forces loyal to us (-20 agents, -6 from the budget)";
					}
					else
					{
						galka_stuk[1].SetActive(value: false);
						fake_text[1] = "Our intelligence will not cope with this";
					}
					fake_text[2] = "Bind the country economically, allocating financial assistance and a favorable loan (-10 from the budget)";
					if (GlobalScript.inst.gameState.data[9] >= 50)
					{
						fake_text[3] = "Do not impede independent politics in exchange for maintaining membership in our bloc (-5 agents, -1 from the budget)";
					}
					else
					{
						galka_stuk[3].SetActive(value: false);
						fake_text[3] = "Our intelligence will not cope with this";
					}
					fake_text[4] = "We must respect their choice";
				}
				else
				{
					kolvo_variant = 1;
					fake_text[0] = "Nothing here";
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
				text2 = "Death of helmsman";
				text = "A terrible thing happened. After 2 transferred heart attacks on September 9 at 0 h. 10 min. On the 83rd year of life, the great leader and teacher of the Chinese people, Chairman 毛泽东, passed away. As long as all the people and the party are grieving, we need to convene the funeral commission and decide how we are conduct the chairman in his last journey.";
			}
			else if (GlobalScript.inst.gameState.number_event == 4)
			{
				text2 = "Conspiracy";
				text = "According to the recently received information, several senior party members who are dissatisfied with your rule have agreed to remove you at the next congress of the Central Committee. You need to urgently do something if you do not want to repeat the fate of the revisionist Khrushchev in 1964.";
			}
			else if (GlobalScript.inst.gameState.number_event == 5)
			{
				text2 = "Popular discontent";
				text = "Dissatisfied with your politics, people went to mass rallies throughout the country and began to build tent camps in squares, distribute leaflets and even storm local government agencies. Different groups of protesters are dissatisfied with different aspects of your government, but they all require the democratization of the system in order to be able to limit your influence on Chinese politics.";
			}
			else if (GlobalScript.inst.gameState.number_event == 6)
			{
				text2 = "Low standard of living";
				text = "Your policy has led to a catastrophic decline in the standard of living in the country, people live in abominable conditions and the vast majority lack the ability to purchase even basic necessities. Of course, this leads to numerous protestswhere people demand to deal with this situation. Given the fact that the soldiers are also unhappy with the terrible conditions of detention, we can not count on the army.";
			}
			else if (GlobalScript.inst.gameState.number_event == 7)
			{
				if (GlobalScript.inst.gameState.modifies[17].active)
				{
					GlobalScript.inst.gameState.IsBankAccountFreezed = true;
				}
				text2 = "Diplomatic crisis";
				text = "Our relations with the USA have reached a critically low level. Their propaganda already accuses China of all possible and impossible crimes, and our intelligence reports on the turmoil in the Pentagon and activity at American bases in Southeast Asia. We urgently need to somehow correct the situation if we don’t want the Third World War.";
			}
			else if (GlobalScript.inst.gameState.number_event == 8)
			{
				text2 = "Diplomatic crisis";
				text = "Our relations with the USSR have reached a critically low level. Their propaganda already accuses China of all possible and impossible crimes, and our intelligence reports on the turmoil in the General Staff of the USSR and the movement of Soviet troops on the border. We urgently need to somehow correct the situation if we don’t want the Third World War.";
			}
			else if (GlobalScript.inst.gameState.number_event == 9)
			{
				text2 = "Separatism in Tibet";
				text = "Encouraged by liberals and nationalists, residents of the Tibet Autonomous Region took to mass demonstrations for independence and secession from the 中华人民共和国, which gradually develop into unrest. People demand \"liberation\" from \"the occupation of 1950\" and the majority of ethnic Tibetans support them. However, some are just satisfied with the requirements of greater autonomy than we can take advantage of.";
			}
			else if (GlobalScript.inst.gameState.number_event == 10)
			{
				text2 = "Separatism in Xinjiang";
				text = "Encouraged by liberals and nationalists, residents of the Xinjiang Uygur Autonomous Region took to mass demonstrations for independence and secession from the 中华人民共和国, which gradually develop into unrest. People demand \"liberation\" from \"the occupation of 1949\" and the majority of ethnic Uighurs support them. However, there is a counterweight to them from the Hanzu, and some of the Uighurs are just satisfied with the requirements of greater autonomy than we can take advantage of.";
			}
			else if (GlobalScript.inst.gameState.number_event == 11)
			{
				text2 = "The decline of industry";
				text = "Our industry is in an unprecedented decline - some of the plants are idle, some are about to close and everyone is working on outdated equipment.";
			}
			else if (GlobalScript.inst.gameState.number_event == 12)
			{
				text2 = "The decline of agriculture";
				text = "Our agriculture is in unprecedented decline - there was no such disorder even in times of great leap forward!";
			}
			else if (GlobalScript.inst.gameState.number_event == 13)
			{
				text2 = "The decline of service sector";
				text = "Our service sector is in terrible decline - most of the stores and establishments do not work, and the quality of service in the working ones is simply terrible.";
			}
			else if (GlobalScript.inst.gameState.number_event == 14)
			{
				text2 = "We have no money, but you hang in there!";
				text = "There is too little money in our budget and reserve fund. If it continues like this, we soon will not be able to maintain  the normal work of our state.";
			}
			else if (GlobalScript.inst.gameState.number_event == 15)
			{
				text2 = "Cambodian-Vietnamese war";
				text = "For several years, ruling in Democratic Kampuchea, the Red Khmers of Pol Pot pursued an openly aggressive policy towards neighboring Vietnam, often attacking border villages and killing civilians en masse. And it seems that Vietnam’s patience has come to an end - quite recently the Vietnamese army launched a full-scale invasion of Cambodia to overthrow the Pol Pot regime, using the Kampuchean United Front for National Salvation, consisting of Khmer left dissidents as cover. Given that Pol Pot has been our faithful ally all this time, it would be worth helping him. Although on the other hand, it may be worth replacing the brazen dictator in favor of more reasonable officers from the Kampuchea army. This, of course, will not stop the war, but Vietnam, which has set itself the goal of overthrowing Pol Pot, will find itself in a difficult situation.";
			}
			else if (GlobalScript.inst.gameState.number_event == 16)
			{
				text2 = "Elections in Thailand";
				text = "After the fall of the military junta in 1973 and the transfer of power to the civilian government, Thailand entered the period of \"chaotic democracy\". The victories of the communist forces throughout Indochina contribute to the growth of leftist sentiments, led by the Maoist Communist Party of Thailand, which is engaged in both partisan and legal activities. They are opposed by the right-wing military, landowners and other royalists, which often leads to clashes. Under these conditions, against the backdrop of the outbreak of the crisis of the Thai economy, the democratic Prime Minister Kukrit Pramoj is forced to hold early elections. Maybe this is our chance, if not to lure away, then at least destabilize the bastion of imperialism in Indochina?";
			}
			else if (GlobalScript.inst.gameState.number_event == 17)
			{
				text2 = "Instability in Thailand";
				text = "Against the background of social instability and constant confrontation between left and right forces, the royal family of Thailand decided in September to organize the return to the country of the radical right general Thanom Kittikachorn, the country's former prime minister responsible for the bloody repression and overthrown by public speeches in 1973. Kittikachorn himself was not wants to return to politics and wished to take monasticism, but the official announcement of his return and his meeting with the king caused dissatisfaction of a part of society with the right . Premier Pramoj resigned, which, however, was rejected, a wave of student and trade union demonstrations swept through, one of which is taking place at the Thammasat University, to which right-wing militants are already raiding. According to our data, the military are preparing a brutal suppression of the demonstration.";
			}
			else if (GlobalScript.inst.gameState.number_event == 18)
			{
				if (GlobalScript.inst.gameState.data[82] > 7)
				{
					text2 = "War is over";
					text = "After long and bloody battles, the conflict named \"" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].name_war + "\" is finally over. The Ministry of Foreign Affairs has taken care of everything and is now ready to give you a quick overview of the outcome of the war.";
				}
				else
				{
					text2 = "War is over";
					text = "After a long and bloody fighting conflict \"" + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].name_war + "\" finally ended.";
					text = ((GlobalScript.inst.gameState.data[82] == 6) ? ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 400) ? (text + " The winner in the end came " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + " side, having achieved their goals in the war.") : (text + " The winner in the end came " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 + " side, having achieved their goals in the war.")) : ((GlobalScript.inst.gameState.data[82] == 2) ? ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 750) ? (text + " The winner in the end came " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + " side, having achieved their goals in the war.") : (text + " The winner in the end came " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 + " side, having achieved their goals in the war.")) : ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 < 900 && GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2 < 900) ? ((GlobalScript.inst.gameState.data[82] != 2 && GlobalScript.inst.gameState.data[82] != 4) ? (text + " Neither side achieved a decisive victory, so the white peace was signed, returning the borders to the pre-war state.") : (text + " The winner in the end came " + GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2 + " side, having achieved their goals in the war.")) : (text + " The winner in the end came " + ((GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl1 > GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].infl2) ? GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side1 : GlobalScript.inst.gameState.ingamewars[GlobalScript.inst.gameState.data[82]].side2) + " side, having achieved their goals in the war."))));
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 19)
			{
				text2 = "Five \"no\"";
				text = "Congratulations on your appointment to the post of Premier of the State Council of the People's Republic of China, Comrade 华国锋. As you know, your predecessor was 周恩来, who gained popularity and respect among the people at home and abroad for his honesty and administrative talents. However, he was also an active promoter of economic reforms and promoted reformers in the party, such as his protege 邓小平. For these reasons, the death of Zhou on January 8, 1976 caused great grief among the people, which dissatisfied Mao and the leadership of the 中共, who reacted very reservedly to his death. Rumor has it 毛泽东 himself set the campaign of Five \"no\" in motion — not to wear mourning bands, not to make wreaths, not to make memorials, not to hold memorial ceremonies and not to hang photos of 周恩来 — yet no one is sure, since Mao is now barely reachable because of his bad legs and overall health, and decisions have to be made quickly with no time to wait. And you, as a new prime minister, can influence its execution.";
			}
			else if (GlobalScript.inst.gameState.number_event == 20)
			{
				text2 = "Criticize Deng and fight with right!";
				text = "The death of 周恩来 seriously affected the position of his protege 邓小平, who was left without the patronage of the former prime minister. He is now under constant attack by the radicals headed by 毛泽东’s wife 江青, and on February 2, 小平 was transferred to work in the field of external relations. With the permission of Mao Jiang and her supporters, they managed to launch a campaign \"Criticize Deng and fight with right\" and begin an active persecution of Deng in the media. It is noteworthy that although Mao treats 小平 with disbelief, he is not yet participating in his persecution. And what should we do, given that 华国锋 has never been on good terms with either 江青 or 小平?";
			}
			else if (GlobalScript.inst.gameState.number_event == 21)
			{
				text2 = "Mystery article about Zhou";
				text = "On March 25, 1976, the Shanghai newspaper «Wenhuibao» printed an article calling an unnamed Zhou a «capitalist-roader». Some read it as a posthumous strike on 周恩来, others say it targets Zhou Rongxin, while Deng’s capitalist-roadings fan the Enlai rumor to stoke public grief. The text was ordered by Shanghai party chief 张春桥 and also swipes at Deng and his reform ideas. The masses do not yet know which Zhou is under attack, but emotions are rising — we must decide how to respond.";
			}
			else if (GlobalScript.inst.gameState.number_event == 22)
			{
				text2 = "Tiananmen incident";
				text = "Numerous attempts by the 中共 to discredit the late 周恩来 have caused only discontent among the people. On April 4, on the day of the traditional holiday of remembrance of the departed, the citizens of Beijing carried wreaths in memory of 周恩来 to Tiananmen Square to the Monument to the people's heroes. Before nightfall, about 2 million people visited the square, and the mountain of wreaths reached 20 meters in height. On this occasion, an emergency meeting of the 政治局 of the 中共 Central Committee was convened under the chairmanship of 毛泽东. 江青 and 张春桥 propose first to address the people by radio to separate mourners from provocateurs, and only then use force if needed. 吴德 is trying to avoid violence altogether. The responsibility was placed on you and the mayor of Beijing, 吴德; what line will we choose?";
			}
			else if (GlobalScript.inst.gameState.number_event == 23)
			{
				text2 = "Tangshan earthquake";
				text = "On July 28, a magnitude 8.2 earthquake on the Richter scale occurred in the city of Tangshan, Hebei Province, at 03:42 local time, as a result of which the city was almost completely destroyed. The destruction also took place in Tianjin and in Beijing, located just 140 km to the west. Several aftershocks, the strongest of which had a magnitude of 7.1, led to even greater sacrifices. According to preliminary data, from 200 to 600 thousand people died. According to the head of the Shanghai City Seismological Department, Zhang Jun, the main reason for the colossal destruction was the lack of the necessary measures of seismic protection during the construction.";
			}
			else if (GlobalScript.inst.gameState.number_event == 24)
			{
				text2 = "Wind of change?";
				text = "After Mao died, and you finally concentrated power in your hands, it is time to determine the future path of China, because every faction of the 中共 sees it in its own way. Conservative Maoists are in favor of continuing Mao’s policies, but without questionable experiments, which means the end of the 文化大革命 and campaigning. The reformers, of course, are in favor of ending the 文化大革命 and large-scale reforms primarily in the economy, in order to improve the Chinese economy after Mao’s failed attempts to intervene in her work. All moderates believe that China needs change, but some will need an end to the 文化大革命 and a small economic reorganization, while others join the reformers demanding deep market reforms. However, the radical Maoists are in no hurry to part with the idea of ??the 文化大革命 and want to continue it, taking into account errors and excesses.";
			}
			else if (GlobalScript.inst.gameState.number_event == 25)
			{
				text2 = "Gang of four";
				text = "Now that our Chairman, 毛泽东, has passed away, the internal party struggle again flared up in the 中共. On the one hand, there are four closest to the Great Helmsman supporters of the line on the continuation of the 文化大革命, but with a course on normalizing relations with the USSR: 江青 is Mao’s spouse and the head of the 文化大革命 Group of the 中共 Central Committee, 王洪文 is a prominent member, at the tenth party congress, he was actually declared the successor to Mao, 张春桥 and 姚文元. On the other hand, the reformers, who are gaining strength, led by the disgraced ideologist of the half-market reforms of the early 70s, 邓小平, who are in favor of the earliest possible withdrawal of the 文化大革命 and the beginning of large-scale market reforms with the unchanged anti-Soviet course. Moreover, it is the left radicals who are currently the greatest threat to our government, but to neutralize them, it will be necessary to ally with reformers such as Secretary of Defense 叶剑英. Maybe it's better to negotiate with them and use them to fight reformers?";
			}
			else if (GlobalScript.inst.gameState.number_event == 26)
			{
				text2 = "Weak alliance";
				text = "The wobbly compromise between the Guofeng and the radical left is cracking at the seams. Frank dissatisfaction with the agreement of many more moderate party members greatly undermined the position of the current chairman, and his gentleness in resolving these issues threatens to lead to unpredictable consequences. Moreover, the four require more decisive measures against the opposition and revisionists in the party, and at the same time further expanding their powers to follow Mao’s course. If this continues further, Guofeng will have to transfer power to the left more and more. 汪东兴 - the leader of 8341 Special Regiment, who remains loyal to the chairman, is still ready to help in the fight against them. Although, given the increased strength of the left, thanks to the compromise in October, perhaps the best solution would be to remove only the most ambitious 江青 and 王洪文, keeping the agreement with the rest?";
			}
			else if (GlobalScript.inst.gameState.number_event == 1)
			{
				text2 = "Elections, Elections, Candidates are...";
				text = "It is the day of the national elections in the 全国人大. And since we occupy a dominant position in Chinese politics, we can intervene a little in their conduct, so that everything will remain same. Or just rely on the Chinese people’s faith in us.";
			}
			else if (GlobalScript.inst.gameState.number_event == 27)
			{
				text2 = "The fate of Hong Kong and Macau";
				text = "For a long time, the Chinese territories of Hong Kong and Macao were under British and Portuguese colonial control. However, the fascist regime of the \"Estado Novo\" in Portugal was overthrown in 1974, the 99-year lease of Britain adjacent to Hong Kong of the New Territories is coming to an end, and both countries are under pressure from the 1960 UN Decolonization Declaration, so they are ready to go Compromise, and this is our chance to return what is rightfully ours. Of course, they will never voluntarily hand over the colonies if they are not convinced of the inviolability of the property of their own and foreign citizens, but also try to achieve wide autonomy for the territories of China.";
			}
			else if (GlobalScript.inst.gameState.number_event == 28)
			{
				text2 = "The end of the Asian Pinochet";
				text = "Major General Suharto, who seized power in Indonesia in 1965, immediately began to destroy his political opponents, especially the Communist Party. In 1965-66 alone, about 3 million people were killed on charges of sympathy for the Communists. National minorities get this also, including the Chinese, who are still legally discriminated against. Suharto’s repressive regime was maintained through US support and profitable economic contacts with the countries of Southeast Asia. However, now that we have cut off Indonesia from most of its partners, causing a collapse of its economy, an active protest movement is taking place in the country. And although many protests go under the left slogans, they are clearly not enough for a socialist revolution.";
			}
			else if (GlobalScript.inst.gameState.number_event == 29)
			{
				text2 = "Chinese imperialism";
				text = "For a long time, the DPRK has been moving away from Marxism-Leninism and replacing it with the original Juche ideology with elements of mysticism and traditionalism and the personality cult of Kim Il Sung. All this is accompanied by periodic repression against political opponents of Kim Il-sung. The economy of the DPRK depends heavily on contacts with China and our help, so our recent sanctions have been a heavy blow to it. And therefore we can demand certain concessions from the North Korean government. Just do not forget that the USSR also provides assistance to the DPRK...";
			}
			else if (GlobalScript.inst.gameState.number_event == 30)
			{
				text2 = "End of conflict?";
				text = "Since the creation of Israel in 1948 in the territory of the former British Palestine, the Arab population there, actually deprived of the right to self-determination and subjected to discrimination by the Israeli authorities, has fought for the destruction of Israel and the creation of an Arab state in Palestine, in which they were supported by neighboring Arab countries. All this resulted in several Arab-Israeli wars, constant shelling and terrorist attacks against Israel by the Palestine Liberation Organization and the return raids of the Israeli army. The last of them, in Lebanon, ended in complete failure, without even receiving support from the United States, and now Israel is ready to negotiate with the PLO on the status of Palestinians, in which we can act as intermediaries.";
			}
			else if (GlobalScript.inst.gameState.number_event == 31)
			{
				text2 = "Correct democracy";
				text = "The uprising in Gwangju, thanks to our support, spilled over into neighboring regions and caused enormous damage to the reputation of the South Korean government, and our recent blow to its economy led to a new surge of protests, under the pressure of which Jong Doo-hwan agreed to hold free presidential elections and even allow two famous opposition leaders - Kim Dae-jung and Kim Young-sam, the first of whom in particular has much more peaceful views towards the DPRK. By ensuring his victory in the elections and putting pressure on the DPRK, we could lead Korea to the long-awaited unification.";
			}
			else if (GlobalScript.inst.gameState.number_event == 32)
			{
				text2 = "Ulaanbaatar Spring?";
				text = "With the help of our intervention in Mongolia, large-scale protests began, calling for reforms and a departure from strict pro-Soviet policy. Not wanting a repetition of events in Czechoslovakia and the entry of Soviet troops, the MPR seems ready to make some concessions and carry out limited democratization, like Kadar in Hungary. We could use this in order to lead pro-Chinese people to Mongolian politics and the media in order to provide them with a more... independent foreign policy.";
			}
			else if (GlobalScript.inst.gameState.number_event == 33)
			{
				text2 = "Crescent in the eyes";
				text = "Zulfikar Ali Bhutto was the president of Pakistan since 1971 and the prime minister since 1973. Bhutto followed the course of Islamic socialism, which was reflected in broad social programs and the nationalization of many sectors of the economy. In foreign policy, he adhered to anti-imperialism and tried to build friendly relations with neighboring countries, left the pro-American SEATO and the British Commonwealth, and managed to detente with India after the Third Indo-Pakistani war. However, after the Bhutto's Pakistan People’s Party won the election in March 1977, the opposition accused him of fraud and began protests that Bhutto harshly suppresses. All this does not like the army, which, led by General Muhammad Zia-ul-Haq and with the support of the United States, is preparing a military coup. By preventing it and giving Bhutto material assistance for the construction of socialism, we could firmly consolidate our positions in Pakistan.";
			}
			else if (GlobalScript.inst.gameState.number_event == 34)
			{
				text2 = "Enemies of my enemies";
				text = "After the defeat of the Gang of four, power nominally passed to you, but in fact you have to share it with those who helped you get it - with Minister of Defense 叶剑英, a staunch reformer who defended 小平 during the 文化大革命, and 李先念, more moderate, but also supporting reformers. On the other hand, there are three of your most loyal conservative supporters — Ji Denkui, 汪东兴, and Chen Xilian. If you want not to be stoped, you should strike at the reformers and promote your supporters, however, would such arbitrariness cause discontent in the party and would you rather restrict yourself to one of the two? On the other hand, if you are focused on reforms, it will probably be more useful to negotiate with reformers. Although who knows if they will want...";
			}
			else if (GlobalScript.inst.gameState.number_event == 35)
			{
				text2 = "End of revolution";
				text = "After the death of Mao, you took the course of curtailing the 文化大革命, and achieved certain results in this - mass campaigns are no longer observed. However, the repressive grip of the state since the time of 文化大革命 has not yet weakened, and the reformers, together with the people, are now demanding to \"unscrew the nuts\". In addition to civic liberalization, many consider it necessary to also ease the pressure on traditions and religion, which increased many times during the 文化大革命. Some advocate only for the cessation of anti-traditionalist rhetoric with the preservation of state atheism, others propose, according to the Soviet model, to declare nominal freedom of conscience while keeping religious institutions and figures under strict state control. You decide.";
			}
			else if (GlobalScript.inst.gameState.number_event == 36)
			{
				text2 = "Coalition collapse?";
				text = "Since 1968, a precarious cooperation has been established in Iraq between the ruling Ba'ath and the Iraqi Communist Party within the framework of the Progressive National Patriotic Front of Iraq. In May 1972, 2 representatives of the ICP were officially introduced to the government, although the Communist Party was still in an informal position. However, the cooperation turned out to be short-lived. Recently, the Ba'ath leadership in Iraq has once again begun to unleash repression against the Communists, but there is still room for maintaining a fragile coalition. Maybe we should somehow intervene in the situation?";
			}
			else if (GlobalScript.inst.gameState.number_event == 37)
			{
				text2 = "The end of the Egyptian pasha";
				text = "Since 1970, Egypt has been headed by Anwar Sadat. Immediately after he came to power, he began a departure from the policy of Gamal Abdel Nasser and the ideas of pan-Arabism and Arab socialism - during the so-called. \"Corrective Revolution\" almost all Nasser’s associates were arrested, including Vice President Ali Sabri (a supporter of friendship with the USSR and the Communists), in 1971 the United Arab Republic was renamed the Arab Republic of Egypt, which meant a break with the course on pan-Arab integration . And in 1973 began the rapprochement of Egypt with the United States, which was accompanied by a rise in anti-Soviet sentiment and a break with Libya and Syria. In 1975, Sadat attempted to destabilize the ruling Arab Socialist Union (ASU), and this year - an unprecedented case - began negotiations to restore relations with Israel! Liberalization of the economy and the penetration of Egyptian foreign capital into the market led to widespread discontent among the general population, and the war with the once fraternal Libya finally undermined Sadat’s authority. Mass rallies flooded the whole country, demanding the resignation of the president. We can take advantage of this and achieve the return to power of supporters of the socialist course. The USSR and the fraternal Arab countries clearly will not object, but the reaction of the United States will not be so warm...";
			}
			else if (GlobalScript.inst.gameState.number_event == 38)
			{
				text2 = "Back to the roots";
				text = "In the early 1960s, in order to cope with the devastating effects of the 大跃进, in the 中华人民共和国, under the leadership of 邓小平 and 周恩来, large-scale self-government economic reforms and the possibility of private land tenure were launched, which eventually led to the dismantling of central planning. Mao did not interfere with their conduct, as he feared dissatisfaction on the part of the majority in the 中共, who still remembered the failure of the 大跃进, and realizing their necessity at that time. However, now the 大跃进 is far behind and maybe at this moment the revival of the plan will allow our economy to reach a new level? On the other hand, the reform wing still believes that further reforms are needed in the economy and wants to develop them.";
			}
			else if (GlobalScript.inst.gameState.number_event == 39)
			{
				text2 = "Commission on \"Solution...\"";
				text = "The death of Comrade 毛泽东, the beginning of the inner-party struggle in the 中共 and our refusal to continue the course of the so-called \"The Great Proletarian 文化大革命\" caused a strong ferment inside the party. According to the Ministry of Public Security, ideas about the \"wrongness of the ideas of Mao\", \"the fallacy of the 中共’s course\", \"the distortion by 毛泽东 and his surroundings of the history of the country and the party\" and so on are beginning to spread in some party organizations. This runs the risk of splitting the Communist Party and completely eradicating all the successes of China’s socialist development. The 政治局 of the 中共 Central Committee decided to begin work on a document that will give an official assessment of the entire path that the 中华人民共和国 and the 中共 passed under the leadership of 毛泽东 since 1949, for which they form a commission of 50 people. However, it is necessary to decide who will head it, and determine the approximate composition. Remember that your decision will have far-reaching consequences and may lead to a revision of the entire ideological line of the 中共.";
			}
			else if (GlobalScript.inst.gameState.number_event == 40)
			{
				text2 = "The fate of the Panchen Lama";
				text = "Comrade Chairman, a letter from a large group of Tibetan clergy has come to the Central Committee in which they urge you to consider releasing 10th Panchen Lama from prison (Panchen Lama is the second lama after the Dalai Lama in the Gelug school of Tibetan Buddhism - note 国家安全部 ). Lobsang Trinley Lhundrub Chokyi Gyaltsen, aka 10th Panchen-Lama, refused to flee with the Kuomintang people to Taiwan in September 1949 and supported the formation of the 中华人民共和国, later playing an important role in reuniting Tibet with our Motherland. However, he then sharply condemned the Chineseization of the Tibet Autonomous Region, for which he was declared \"the enemy of the Tibetan people\" in 1964, arrested and imprisoned in the Beijing Tsingcheng prison, where he currently resides. We can free him, thereby significantly improving relations with Tibetan monks and the population of the autonomy. But does it make sense? Maybe it is better to eliminate the unreliable lama and get our protege Gyaltsen Norbu elected as Panchen-Lama?";
			}
			else if (GlobalScript.inst.gameState.number_event == 41)
			{
				text2 = "Indian Elections";
				text = "Former Indian Prime Minister since 1966, Indira Gandhi, the head of the INC, during her reign, carried out active leftist reforms in the socio-economic sphere, which even provoked a split in the INC and the exit of the right wing. During her reign, considerable success was achieved in the economy and the fight against poverty, but the state of emergency in the country since 1971 plays into the hands of the opposition from Janat party, which accuses Gandhi of corruption, nepotism and authoritarianism. Under these conditions, Gandhi decided to organize early parliamentary elections. Given that Gandhi has always pursued a pro-Soviet and unfriendly policy towards the 中华人民共和国, and also entered into conflicts with friendly to us Pakistan, only recently having detented in these matters, could an opposition victory strengthen our influence. Janata Party unites people of different views from socialists to conservatives and does not have a coherent program, but the easier it will be for us to manage it. Although it may be, if we help Indira, will she remember this and continue moving towards the restoration of our relationship?..";
			}
			else if (GlobalScript.inst.gameState.number_event == 42)
			{
				text2 = "Iranian revolution";
				text = "For some time now, protests have been taking place in Shah Iran aimed at the difficult socio-economic situation of the people, the Shah’s pro-American policies, the rampant corruption of the ruling elites and the oppression of the Shiite clergy by the state. However, today the protests went into a hot phase after the anti-government demonstration was shot by the police in Qom, which was caused by a slanderous article about Ayatollah (the highest spiritual title of Shiite Islam) Khomeini, the spiritual leader of the protests, who was expelled from the country in 1964. After this, protests and strikes swept many cities in Iran. Islamist movements, such as the Movement for a Free Iran and the Society of Fighting Clergy, are the driving forces of the upcoming revolution, but other organizations also work to overthrow the Shah, the largest of which are the Democratic National Front of Iran and the Marxist-Leninist People’s Party of Iran. The revolution in Iran can dramatically change the balance of power in the Middle East, so maybe we should intervene?";
			}
			else if (GlobalScript.inst.gameState.number_event == 43)
			{
				text2 = "Expansion of the CMEA";
				text = "For a long time, Vietnam tried to balance between us and the USSR, because despite our differences with the Soviets, our volunteers fought together in the Indochinese wars on the side of socialist Vietnam. But already with the end of the war and unification, Vietnam gradually became more and more pro-Soviet, more and more moving away from us.|";
				text = ((GlobalScript.inst.gameState.allcountries[23].Gosstroy == 0 && !GlobalScript.inst.gameState.allcountries[23].EAF) ? (text + "After Le Duan’s trip to Moscow in 1977, a further rapprochement of Vietnam and the USSR began with the prospect of joining the CMEA, which he intends to join from day to day. We apparently can not prevent this, not least because of the fact that Vietnam wants to enlist Soviet support against Pol Pot in pro-Chinese Cambodia.") : (text + "After Le Duan’s trip to Moscow in 1977, a further rapprochement of Vietnam and the USSR began with the prospect of joining the CMEA, which he intends to join from day to day. However, part of the country's leadership opposes such an ardent rapprochement with the USSR, because there are no special threats to Vietnam, especially after the overthrow of Pol Pot in Cambodia, in Asia. And this is our chance to intervene and stop the spread of Soviet hegemony."));
			}
			else if (GlobalScript.inst.gameState.number_event == 44)
			{
				text2 = "It doesn't matter if a cat is black or white...";
				text = "Your desire to pursue a conservative policy that is completely inconsistent with the diminishing strength of your supporters eventually led to widespread dissatisfaction of the 中共’s reformist wing, supported by the moderates. They want your removal from power and require the start of extensive market reforms with the attraction of foreign investment and China's access to the world market, arguing that \"the economy should prevail over the ideology\". That is what their leader  " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[3]].name_2] + " at the current plenum of the 中共 Central Committee says to you, with which the majority of those present agree. Need to do something if you do not want to lose power!";
			}
			else if (GlobalScript.inst.gameState.number_event == 45)
			{
				text2 = "Reform and openness: the beginning";
				text = "After announcing a course on market reforms, our economists developed a plan for the first reforms and finally submitted it so that the 中共 leadership could approve it. It includes the empowerment of individual state-owned enterprises, the introduction of market methods for their work and the promotion of small private and cooperative entrepreneurship.";
			}
			else if (GlobalScript.inst.gameState.number_event == 46)
			{
				text2 = "New 1956?";
				text = "Interesting news came from Hungary. Bela Biszku, a conservative communist who actively participated in the suppression of the Hungarian uprising in 1956 and was the Minister of the Interior from 1957 to 1961, and now secretary of the HSWP, always opposed Kadar's economic and political liberal reforms. Realizing that words couldn’t stop him, he made a group of similar conservatives around himself and decided to organize an inner-party coup, asking for support from the head of the KGB, Yuri Andropov. However, according to our data, Andropov simply \"betrayed\" Biszku's plans to Kadar, which Biszku himself doesn’t know yet. Now we have a chance to help Biszku with our agents and return Hungary to the path of building true socialism. Or you can always try to raise a new uprising in Hungary with the help of small arms supplies and intelligence coordination - this time truly communist and pro-Chinese - then Hungary is guaranteed to be ours! But we must act quickly.";
			}
			else if (GlobalScript.inst.gameState.number_event == 47)
			{
				text2 = "Beijing Spring";
				text = "From the middle of this year, the stormy activity of students and intellectuals began throughout the country, especially in Beijing, which hangs big-character poster (wall newspapers with large hieroglyphs used for propaganda and protest) in the streets and publishes self-made magazines. Big-character poster and the journals oppose the 中共's conservatism, criticize the 文化大革命, call for economic and political liberalization, and express support for the reformers in the 中共, which NAME actively uses. Moreover, in 1977, the reformers themselves actively published in their journals and newspapers under their control critique of our policies, saying that it \"does not agree with Marxism\" that \"the economy should prevail over ideology\" and that \"pragmatism is the only criterion for revealing the truth\", describing the practical advantages of market reforms in their vision.";
			}
			else if (GlobalScript.inst.gameState.number_event == 63)
			{
				text2 = "April revolution";
				text = "Urgent news! On April 27, in Afghanistan, as a result of the instability of power, impoverishment and discontent of the people by the arrest of the leaders of the left opposition party PDPA, a military coup took place beforehand planned by the PDPA. The general public welcomed the revolution. Having come to power, the PDPA, headed by Nur Muhammad Taraki, began the construction of socialism and an orientation toward the USSR. However, the future of Afghanistan is still vague, as in the PDPA itself there remains an overwhelming split between the Khalq and Parcham factions, which actually existed as 2 independent parties from 1966 to 1977. Khalq, consisting mainly of low-income and semi-proletarian groups, in the course of opposition activities focused on illegal work and advocated a revolutionary struggle, and now seeks to organize a quick transition of the country to socialism and the dictatorship of the proletariat. Parcham , which in the years of the opposition gave priority to legal and parliamentary struggle, now stands for gradual, general democratic reforms and generally inclined to reformism, believing that Afghanistan is not ready to build socialism. In the meantime, the 中共 is seriously concerned about the expansion of Soviet influence in the region.";
			}
			else if (GlobalScript.inst.gameState.number_event == 48)
			{
				text2 = "Coups continue";
				text = "After the April revolution, the PDPA faced many difficulties, and in the rapidly gaining strength of the Khalq party, the struggle between one of the PDDP founders Taraki and his student Amin had already begun. Amin is a supporter of radical politics, an uncompromising struggle against feudal remnants and the harsh suppression of political opponents. At the same time, he, being an ardent Pashtun (the dominant people of Afghanistan - note) nationalist, is largely responsible for sabotaging the national policy of the PDPA and, trying to concentrate power in his own hands, he maintained a split between Khalq and Parcham. Despite the fact that the Soviet leadership repeatedly warned Taraki about Amin's conspiratorial plans, he did not heed until the very last moment. On September 14, during the visit of Amin to Taraki, the first one was attacked (it is not known exactly whether it was real or staged by Amin himself), and on September 16, Amin at the plenum of the People's Democratic Party Central Committee removed Taraki from his duties, having previously isolated him with loyal army units in the residence. It is noteworthy that, although Amin tried to maintain good relations with the USSR, according to our data, he is not at all opposed to establishing close relations with the 中华人民共和国, and this may be our chance.";
			}
			else if (GlobalScript.inst.gameState.number_event == 49)
			{
				text2 = "Against all tyrants";
				text = "After the recent Amin's coup, the USSR in every possible way was looking for ways to eliminate the careless usurper. According to our data, the Soviet leadership has established contact with members of the PDPA from various factions, such as Karmal, Sarwari and Watanjar, who fled from Afghanistan because of Amin’s purges and is ready to use them to replace Amin. The key point of the plan is the neutralization of Amin and his loyal entourage by Soviet special forces, whose cover should be provided by Soviet troops, whom, since the beginning of the year, the PDPA and Amin personally have been insistently asked to enter, despite the constant refusals of the USSR. However, it seems that under pressure from the circumstances, the Soviet leaders decided to change the decision and the first Soviet units crossed the border as early as December 25 with the task of protecting important military facilities and objects of Soviet-Afghan cooperation. Now is our chance to seize the initiative in Afghanistan, if it is possible to prevent the displacement of Amin. However, this can be done only with good relations with the USSR, otherwise USSR would run through a brick wall, but not give us Afghanistan.";
			}
			else if (GlobalScript.inst.gameState.number_event == 50)
			{
				text2 = "Cursed Mountain Wild Edge...";
				text = "After the recent events that contributed to the deterioration of the situation in Afghanistan, the long-standing uprising of the Islamists and other reactionaries supported by the United States has entered a hot phase. The USSR, in accordance with the recently adopted plan, introduces troops into Afghanistan at the request of the DRA government, which has already caused a wave of indignation in the west. Despite the fact that the population initially met the Soviet troops quite friendly, the cases of militant attacks on them have become more frequent. At the same time, the tasks of a limited contingent, which initially included only the protection of important objects, are gradually expanding and, it seems, will eventually reach its full participation in hostilities. The battle for Afghanistan has begun and we need to decide who we will support in it.";
			}
			else if (GlobalScript.inst.gameState.number_event == 51)
			{
				text2 = "Just hold and then leave...";
				text = "After the April revolution, the PDPA faced many difficulties associated with a lack of experience among its members and an abundance of feudal and religious remnants in Afghanistan, however, due to the relative equality of forces between the two factions of PDPA, it was possible to avoid major political conflicts. In particular, the members of both Parcham and Khalq, with the support of the USSR, succeeded in removing Amin from the government and the Central Committee with accusations of violating the principles of collective leadership and Pashtun nationalism. However, the uprisings of the reactionary groups, especially the Islamists, which began at the beginning of the year, are gaining momentum. Some citizens of Pakistan and Iran are joining them, illegally crossing the border, and even the USA manage to somehow drag their weapons and advisers to Afghanistan to help the mujaheddin. Under these conditions, the USSR, at the numerous requests of the Afghan leadership, decided to introduce a small contingent of its troops, which would have to guard important military installations and cities, freeing the forces of the DRA army to fight the rebels. It seems that their large-scale participation in hostilities is not expected, but the West has already condemned it, calling it an invasion.";
			}
			else if (GlobalScript.inst.gameState.number_event == 52)
			{
				text2 = "Difficult neighborhood";
				text = "From the very beginning of anti-government demonstrations in Afghanistan and the response of the DRA government, many Islamic radicals, terrorists and priests fled to Pakistan, where they teamed up with their local \"colleagues\". Subsequently, after the start of armed riots in Afghanistan, refugees flowed into Pakistan, who were awaited by Islamic terrorist organizations that had formed there. Pakistan itself does not take special measures in relation to them beyond the usual, it seems that Bhutto has enough problems there, but it may be worthwhile to provide him with undercover assistance in order to stop such outrages? On the other hand, the United States is very interested in the possibility of helping the Afghan rebels through Pakistan, and if Bhutto can not agree with the United States in any way, then he could with us. By transporting American weapons and advisers through Pakistan, we could \"cut\" money from Americans and strike at Soviet social-imperialism.";
			}
			else if (GlobalScript.inst.gameState.number_event == 53)
			{
				text2 = "Agricultural reform";
				text = "During the 大跃进, almost all of China’s agriculture was organized into agricultural communes, renowned for their total socialization of equipment and personal belongings, failed experiments with artisanal steelmaking and disgusting productivity. After the reforms of 周恩来, the communes were partly reformed, partly disbanded, but in a modified version, they still continue to work. Many in the 中共 believe that it is time to reform the agriculture, but there is no consensus. Moderates and reformers propose the introduction of a family contracting system, which implies the creation of family entrepreneurship in the countryside with compulsory public procurement. Another part of the reformers proposes to introduce a system of full-fledged private farming. We will have to allocate loans to start-up entrepreneurs for the necessary purchases, but reformers promise that these costs will pay off more than in the short term. And part of the party proposes to return to basics to organize a system of collective farms on the Soviet model, which will allow to overcome technological backwardness, because Stalin managed to did it? The truth is that the necessary mechanization needs money...";
			}
			else if (GlobalScript.inst.gameState.number_event == 54)
			{
				text2 = "Reforms and openness: investments";
				text = "In the framework of the policy of reforms and openness in accordance with the stated course, we need to engage in attracting foreign investment. Reformers propose to create on the coast several special economic zones with tax breaks, minimum state control and other indulgences for foreign investors, where they could build their enterprises and invest in joint projects. However, in addition to creating a free economic zone, more radical leaders propose to fully open the economy to foreign investment by creating a system of joint ventures, in which foreign countries can invest in our state-owned enterprises in exchange for a portion of the profits. The greater profitability of the second option is obvious, but moderate and even some reformers criticize it for its haste.";
			}
			else if (GlobalScript.inst.gameState.number_event == 55)
			{
				text2 = "Burmese road to socialism";
				text = "After the military coup in 1962, the government in Burma passed over to Ne Win and the Burma Socialist Programme Party headed by him, proclaiming the construction of \"Burmese socialism\". However, this \"socialism\" was characterized by the preservation of the private sector, the cultivation of chauvinistic religious and national prejudices, in fact, a departure to isolation, as well as mass repressions of all opponents of Ne Win. Therefore, the various left-wing forces that had fallen into the party after the start of the open mass recruitment in 1971, began to increasingly oppose Ne Win and his policies. According to our data, mass purges are being prepared in the Burma Socialist Programme Party against the communists and other leftists, and if we had already made contact with Burma, we could change the balance of forces in their favor with the help of our special services. However, we can also provide additional assistance to the leadership of Burma and strengthen our relationship.";
			}
			else if (GlobalScript.inst.gameState.number_event == 56)
			{
				text2 = "Teach Vietnam a lesson?";
				text = "Recently, neighboring Vietnam is increasingly moving closer to the USSR, and this despite our help in the civil war! In this regard, more and more party members believe that you need to \"teach Vietnam a lesson\". The plan that has been developed by the PLA for some time is simple - under the pretext of occasional clashes at the border, we declare war on it, seize the border areas, destroy the arriving units of the Vietnamese army and move as far as possible into the interior. Such a blow would force their leadership to seriously reconsider its policy towards the 中华人民共和国 and the USSR. However, some of the party members believe that if our relations with Vietnam are not yet so spoiled, then it makes sense to reach an agreement with him, settling our territorial claims and persuading to stop oppressing ethnic Chinese in Vietnam. However, you can do nothing, because a thin world is better than a good war, right?";
			}
			else if (GlobalScript.inst.gameState.number_event == 57)
			{
				text2 = "Red rising sun";
				text = "Soon Japan should have elections to the House of Representatives of the Japanese Parliament. Against the background of government instability and corruption scandals, the Communist Party of Japan has steadily gained popularity in recent times, as has the various center-left oppositions. If we have an influence on the CPJ, then we could assist them in campaigning. In case of victory, we could improve relations with our historical adversary and finally expel the American bases from Japan.";
			}
			else if (GlobalScript.inst.gameState.number_event == 58)
			{
				text2 = "Iranian Revolution: Endgame";
				text = "All last year, protests shook Iran - left, secular democrats and Muslim organizations of varying degrees of radicalism opposed the Shah’s authority in word and deed, organizing multiple strikes and strikes.|";
			}
			else if (GlobalScript.inst.gameState.number_event == 59)
			{
				text2 = "Economic union";
				text = "Comrade Chairman! In connection with the current situation in the international arena, a number of party members propose to organize their alternative to the Soviet economic alliance - the CMEA and the European - the EEC to continue the policy of expanding our influence and deepen trade and economic ties between the countries loyal to Beijing. However, some members of the 政治局 consider this step too hasty, radical and thoughtless and suggest that this matter be postponed until better times. Although perhaps the best option would be to forget all the strife with the Soviet Union and join the Council for Mutual Economic Assistance?";
			}
			else if (GlobalScript.inst.gameState.number_event == 60)
			{
				text2 = "Military alliance";
				text = "After more than a happy creation of our economic union, some party members propose to consolidate success by uniting all the countries friendly to us into a single military alliance, thereby occupying a niche surrounded by the military bases of European NATO and the Soviet ATS. However, the most pragmatic party members offer to abandon this initiative, arguing that our thoughtless and radical actions can unleash a new round of the Cold War, but with a third influential force. However, China is now stronger than ever, and the extra allies will not interfere with it, will it? ";
			}
			else if (GlobalScript.inst.gameState.number_event == 61)
			{
				text2 = "Anthem problem";
				text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + "! As you know, the anthem of our country since 1949 has been the \"March of the Volunteers\" Nie Er and Tian Han. However, during the so-called \"文化大革命\" Tian Han was arrested on a false accusation and died in prison, and the popular song \"The East Is Red\", glorifying the late President 毛泽东, became the de facto anthem. Now, when we stopped the \"文化大革命\" and posthumously rehabilitated Tian Han, as well as normalized the situation in the country, the question arose about state symbols. A large group of party members propose to restore the \"March of the Volunteers\" as an anthem already officially, however, your associates, in principle agreeing with this, believe that the text of the hymn should be changed by adding references to Chairman Mao and the 中共. True for both of these options will need money for conversion. At the same time, the radical Maoists remaining in the party wrote to you with a letter in which they proposed to give the status of the hymn \"The East Is Red\"...";
			}
			else if (GlobalScript.inst.gameState.number_event == 62)
			{
				text2 = "The problems of the heirs of Genghis Khan";
				text = "After the victory over the Kuomintang in 1949, the regions of China inhabited by non-Chinese people gained autonomous status, modeled on the USSR. One of them is Inner Mongolia, where ethnic Mongols live. During the so-called \"文化大革命\" central authorities began to assimilate the Mongolian population by force, which resulted in mass clashes with the Red Guards and the riots of 1967-1969. In 1969, most of the territory of Inner Mongolia was attached to neighboring Chinese provinces in such a way that the number of Mongols in it fell to 600 thousand people and the total population of the autonomous region fell from 13 to 9 million people. Now that the 中共 has recognized the fallacy of this policy, representatives of the Council of People’s Representatives of the AR of Inner Mongolia and the Mongols-communists propose to correct Mao’s mistake and restore justice by returning the lands taken from it to AR and ending the assimilation policy. This is clearly not going to please the left wing of the 中共, but it can help to enlist the support of national elites. In addition, the Mongolian People's Republic and the USSR will obviously like this step.";
			}
			else if (GlobalScript.inst.gameState.number_event == 64)
			{
				text2 = "Pan-Arabism";
				text = "The ideas of creating a united state of all Arabs in the Middle East have been in the minds of Arab rulers and intellectuals since the days of the colonial rule of foreigners in these lands. It was reflected in the United Arab Republic, which consisted of Syria and Egypt and existed from 1958 to 1971, however, due to the striving of Egyptian President Nasser, a well-known pan-Arabist, to centralize power in Egypt, Syria withdrew from it in 1961. Subsequently, in 1971, a confederative Federation of Arab Republics from Egypt, Syria and Libya was created. However, there were contradictions between its participants, which consisted primarily in the liberal pro-Western policies that came to power in Egypt after Nasser Sadat. But now, when Sadat is eliminated, and in Egypt, supporters of the old president Nasser came to power, thanks to which the FAR has formally existed until now, and the ideas of merging the Arab states have re-occupied the minds of the ruling circles. Moreover, on July 30, Israel proclaimed Jerusalem \"the eternal and indivisible capital of Israel\", which caused a wave of discontent in the Arab world, giving another reason to unite against a common enemy. Having allocated some material assistance and contributed to the elimination of those dissatisfied with such a development, we could revive the UAR, which would seriously change the balance of power in the Middle East and get a valuable ally. Unless, of course, they will listen to us...";
			}
			else if (GlobalScript.inst.gameState.number_event == 65)
			{
				text2 = "Goodbye, our sweet Mishka...";
				text = "Comrade Chairman! On July 19, 1980, the opening of the XXII Summer Olympic Games will take place in Moscow. The Soviet Union struggled to secure the right to host the Olympics and spent enormous funds on its preparation, which had to be withdrawn from other expense items (a large-scale campaign was held to sell Olympic symbols for cost recovery). However, the US leadership has openly declared a boycott of these Games and called on all its allies for this, organizing the so-called «Olympic Boycott Games» (better known as the \"Liberty Bell\") in Philadelphia. A number of party members urge us to follow the American example and boycott the Soviet games by sending a team to the American ones - however this will arouse the anger of the USSR and the misunderstanding of the people. Maybe you should not exacerbate the split and send our athletes to Moscow, despite the political contradictions between our countries? Sport is out of politics, isn't it...";
				if (GlobalScript.inst.gameState.is_party_enabled[0])
				{
					text += "|However, a group of party members, recalling the experience of GANEFO in 1963 (alternative Games of the \"Third World\" countries conducted by Indonesian President Sukarno with our financial aid), suggests that we revive these Games and show the USSR and the USA that we are independent from them in sports.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 66)
			{
				text2 = "And after Tito - Tito!";
				text = "On January 3, 1980, the founder and long-term leader of the Socialist Federal Republic of Yugoslavia, Chairman of the Central Committee of the Union of Communists of Yugoslavia, Marshal Josip Broz Tito was hospitalized at the Clinical Center of Ljubljana to check the blood vessels in his legs. As a result of two operations and amputation of his left leg, his condition improved somewhat, but in February Tito suffered pneumonia: high fever and bleeding in the stomach, intestines and lungs also led to sepsis, which intensified during March. And today came the denouement - at 15:05 Belgrade time at the clinic for cardiovascular diseases of the clinical center in Ljubljana, three days before his 88th birthday, Josip Broz Tito died. The funeral will take place on May 8th and we need to decide whether it makes sense to send a delegation to Belgrade or is it worth confining to condolences? Despite our ideological differences and the gap in diplomatic relations, Tito was one of the heroes of the Anti-Fascist War and it makes sense to give him a duty of memory. The USSR and the USA have already announced that they will send official government delegations to the funeral, but US President Carter will not go to Belgrade... Maybe the comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + " should not go, sending at the head of the delegation Ji Pengfei with limited powers? ";
				if (GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					text += "However, our Albanian allies have already stated that, although they will be happy to restore trade and cultural ties with Yugoslavia, they will never stop criticizing \"the revisionist Tito and Titoism\". If we send a delegation, we may well push them away from us.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 67)
			{
				text2 = "Poland has not died yet?";
				text = "Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", alarming news comes from Warsaw - on September 6, the 6th Plenum of the Central Committee of the Polish United Workers' Party took place, which decided to resign Edward Gierek who headed the party and the country for 10 years and replace him with a compromise Stanislaw Kania. The country is now in the hardest political and economic crisis, united with the help of the CIA anti-socialist opposition, headed by the so-called \"independent self-governing trade union\" \"Solidarity\", for almost a year now, it has been organizing mass strikes, rallies, processions. The tremendous national debt (almost $ 40 billion), accumulated under the previous leadership of the country, PPR is unable to pay. The situation is clearly out of control of the PUWP, the USSR is already seriously beginning to consider the option of armed intervention in the affairs of Poland, following the example of Czechoslovakia-1968. Now, while the situation in the country is extremely unstable, we have a great opportunity to intervene and, taking advantage of Kania’s indecisiveness, to ensure that nationally oriented forces led by Albin Siwak and Kazimierz Mijal come to power in Poland. However, this will cause great dissatisfaction with the USSR and high costs, so maybe we don’t need this Poland?..";
			}
			else if (GlobalScript.inst.gameState.number_event == 68)
			{
				text2 = "Rise in Gwangju";
				text = "After the coup in December 1979, Chun Doo-hwan seized power in South Korea began a merciless suppression of protesters against the military regime. On May 17, martial law was introduced, and on May 18, a student demonstration in the city of Gwangju against the closure of the Chonnam National University was shot by the military. This caused a storm of discontent in the city and caused even greater unrest, during which the rebels managed to seize police and military depots and push army units out of the city. According to our data, the government of Chun Doo-hwan is preparing to seize Gwangju by the regular army. By supporting the rebels so that they could last longer, and by directing the strength of our intelligence services to incite discontent in adjacent regions, we could seriously destabilize the South Korean regime.";
			}
			else if (GlobalScript.inst.gameState.number_event == 69)
			{
				text2 = "Another gang?";
				text = "Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", thanks to your efforts, we were able to put an end to the remnants of the 文化大革命, and the country is heading towards a bright market future! However, there are still those who disagree with such a development of events and with all their might protest against the conduct of such a policy, disrupting good reforming initiatives. These are predominantly conservative Maoists, headed by four top party members who but resists further reform. By hitting them and their supporters, we could consolidate more power in the hands of the reformers. Moreover, in the places freed from conservatives, it will be possible to promote active supporters of reforms that have gained popularity among the people, and their wards.";
			}
			else if (GlobalScript.inst.gameState.number_event == 70)
			{
				text2 = "The problems of 周恩来's heirs";
				text = "Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ", thanks to your efforts, we were able to continue moving towards a bright communist future, as bequeathed by Chairman Mao! All reformers attempts to shake our system and destroy socialist gains, turning China on the path of capitalism, have failed. However, many of them still have sufficient influence and continue to promote their revisionist ideas, and something needs to be done with this. The most radical of your supporters suggest that they should not stand on ceremony with the revisionists and simply arrest their leaders and start a campaign against the reformers, but the party and the people are unlikely to approve of such arbitrariness, so you can try to solve everything in the CPС meeting rooms. And we must decide what to do with the moderates — after Mao’s death, most of them supported the reformers, but now some are beginning to hesitate...";
			}
			else if (GlobalScript.inst.gameState.number_event == 71)
			{
				text2 = "The East Is Red...";
				text = "Thanks to our support, the Maoist rebels in eastern India, known as the Naxalites, gained considerable influence and some public support in the eastern states. They control large areas, and their constant attacks have become a headache, both for the eastern states and for the central government of India. Some Indian politicians are already thinking about negotiating with them, and we could use this to hold Naxalites in the local governments of the eastern states, mediating at the talks, which would greatly increase our influence on India and provide a relatively loyal left-wing policy in eastern India. This is on condition that the Naxalites and the Indian authorities start talking with us at all. Yes, and the preservation of instability in the eastern regions can give us an opportunity for a maneuver, not so now in the future... However, part of the generals and the party has already matured a plan for this maneuver - they offer to take advantage of the situation and send troops into the territory of Arunachal Pradesh we pretend to \"protect the civilian population and restore order\", after which it will be possible without any problems to attach them to the 中华人民共和国. But it will mean a new border war with India...";
			}
			else if (GlobalScript.inst.gameState.number_event == 72)
			{
				text2 = "Rescue drowning";
				text = "After winning the Indian elections of 1977, Janata party, which is actually a confederation of various parties from socialists to national liberals, faced a lot of difficulties. Originally united by the desire to remove Indira Gandhi and the INC from power, now, after coming to power, Janata suffers from internal intrigues that actually paralyzed her work. At this pace, the upcoming elections in January 1980 will inevitably be won over again by Gandhi, which puts an end to the successes achieved by Janata in improving our relations with India. And if we once helped the opposition and have influence on it, then we could help it to consolidate and retain power..";
			}
			else if (GlobalScript.inst.gameState.number_event == 73)
			{
				text2 = "Iran-Iraq war";
				text = "Relations between Iran and Iraq have been strained for a long time, mainly due to territorial disputes - in 1969, Iran seized control of the Shatt al-Arab river given to Iraq by agreement of 1937, and in 1971 Iran occupied three islands in the Strait of Hormuz which also claimed Iraq. However, after the victory of the Islamic revolution in Iran, the situation worsened even more - wanting to spread the revolution to the entire Muslim world, Khomeini began to actively send agitators and agents to Iraq, as well as to support the struggle of Iraqi Kurds for independence. In response to this, and also seeing that the Iranian army collapsed with revolution and Islamist purges, Saddam Hussein decided to invade Iran in order to seize the oil-rich province of Khuzestan. On September 22, at around noon, Iraqi troops invaded Iran, encountering fierce resistance and are now slowly moving through Iranian territory.";
			}
			else if (GlobalScript.inst.gameState.number_event == 74)
			{
				text2 = "The decision on some questions of the history of the 中共";
				text = "So, comrade Chairman, the work on this important document, which we began in 1976, has been completed. The final version of “Decisions on Some Questions of the History of the 中共” includes 28 thousand characters, 84 pages, printed in Chinese, English, Russian, Arabic and Spanish. It was far from easy to give an analysis of human activity, ideas, history, society, to reveal the most complex set of reasons. But this has finally been done, and the 6th Plenum of the 11th 中共 Central Committee is ready to consider the document.";
				if (GlobalScript.inst.gameState.data[90] == 0)
				{
					text += "|In \"Decision\" the path we have followed from 1949 is fully approven and the personality of 毛泽东 is put at the forefront. This should certainly please the people - but the party, endorsing Chairman Mao, is unlikely to approve the justification of his excesses...";
				}
				else if (GlobalScript.inst.gameState.data[90] == 1)
				{
					text += "|In \"Decision\" the path we have followed from 1949 is fully approven, but \"everything bad is straighten and everything good is consolidated\", and 毛泽东 is given an assessment\"70% positive на 30% negative\". This will certainly please the Party and the people...";
				}
				else if (GlobalScript.inst.gameState.data[90] == 2)
				{
					text += "|In \"Decision\" the path we have followed from 1949 is  critisized and the personality of 毛泽东 is branded. Individual members of the party will like this, however - I cannot vouch for the consequences if the Plenum approves it...";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 75)
			{
				text2 = "Problems of the Iraqi Atom";
				text = "News just came from Iraq, Israeli aviation during operation \"Opera\" struck the \"Tammuz\" reactor, bringing it down. As a result of this strike, the Iraqi atomic program ended. Saddam is now pursuing a very aggressive foreign policy which destabilizes already tense situation in the Middle East. However, we perhaps could help Iraq continue the atomic program, thereby obtaining a useful ally in this strategic region. Although I would not advise on relying on reliabilty of Saddam Husein - he is a well-known supporter of multi-vector policy, that cooperates with the United States, USSR, us and Non-Aligned Movement. It is possible that even its own atomic bomb will not change this...";
			}
			else if (GlobalScript.inst.gameState.number_event == 76)
			{
				text2 = "Push the falling man!";
				text = "Comrade Chairman, urgent news from the SFRY! In the Socialist Autonomous Province of Kosovo, mass riots of the Albanian population began, according to our data, organized by the Albanian special service Sigurimi. Protesters attack administrative buildings, police stations and garrisons of the Yugoslav People’s Army, anti-Serb pogroms began. The leadership of the province and the Union of Communists of Kosovo do not offer serious resistance to the rebels, de facto supporting them. An urgent meeting of the SFRY Presidium was held in Belgrade, which decided on a forceful suppression of the \"counter-revolutionary separatist rebellion\". After the death of Tito, the situation in Yugoslavia began to deteriorate, it seems that the monster of the Versailles Treaty began to collapse. So maybe it makes sense to push him even more into the abyss?";
			}
			else if (GlobalScript.inst.gameState.number_event == 77)
			{
				text2 = "Spittle in the face, punch in the jaw and a bullet in the head";
				text = "Our residents pass on interesting information from Albania - it seems there has been a serious split between Albanian leader Enver Hoxha and the second person in the party and the state - Prime Minister Mehmet Shehu. For a long time, he was the closest associate of Hoxha and ensured the stability of the country by the forces of Sigurimi, personally overseeing the suppression of several reactionary uprisings in the mid-1940s and famous for the phrase: \"Who does not agree with our leading role, will get spittle in the face, a punch in the jaw, and if necessary, a bullet in the head\", which even (in a negative context) was quoted at the XXII Congress of the CPSU. However, after what happened at the background of the Khrushchev's de-Stalinization and split between Albania and the Soviet Union and the socialist camp, its economy began to experience difficulties from such isolation. In the PLA, more and more people are inclined to restore relations with the USSR, Yugoslavia and even with Italy, and apparently, Shehu is one of them, and is forced to solve urgent problems of the Albanian economy. More practical and inclined to negotiate than Hoxha, he could be a useful ally.";
				if (!GlobalScript.inst.gameState.allcountries[20].proprc)
				{
					text += "Besides, he is a supporter of an alliance with the 中华人民共和国 and will clearly be happy to restore our severed relations.";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 78)
			{
				text2 = "Eternal president";
				text = "According to our information, first presidential elections will take place in June of this year in Philippines. Since 1972, the country has been in a state of martial law, that was introduced by president Ferdinand Marcos and removed by him in January of 1981. The time of his presidency was characterized by rampant corruption, nepotism and violation of human rights, which caused a sharp increase in opposition activism, one of the cores of which was maoist Communist Party of the Philippines and the National Democratic Movement formed by it, which have long been campaigning and conducting guerrilla war against the Marcos regime. However, effective economic reforms based on state regulation of the economy, suppression of the opposition through martial law, and US support are likely to bring him victory in the upcoming elections. However, we have an excellent chance to spoil his triumph - using the special services and supplying weapons to the CPP and the NDM, we could kindle mass protests against the Marcos regime and these caricature elections. However, is it worth it? Indeed, after Marcos severed relations with Taiwan in 1975 and established them with the 中华人民共和国, 周恩来 promised that the 中华人民共和国 would not interfere with the policies of the Philippines, so maybe it is better to cooperate with Marcos?";
			}
			else if (GlobalScript.inst.gameState.number_event == 79)
			{
				text2 = "Austerity policy";
				text = "In the early 1970s, Romania, taking advantage of Ceausescu's good relations with the West, actively borrowed money from the IMF, but after the energy crisis of the 1970s, which hit Romania as a large exporter of oil and fouling the country with debts, the economic situation in the country is rapidly getting worse. Under these conditions, prices for consumer goods began to rise in Romania in the late 1970s, and now Ceausescu decided to switch to austerity policy, which implies a significant reduction in imports and expansion of exports in order to channel profits to pay debts. This inevitably entailed restrictions on the consumption of water and electricity for the inhabitants of the country, and a rationing system was introduced on many products, which, in complex, hurt Romania’s standards of living. Ceausescu was the only ruler of the Soviet socialist camp who maintained good relations with China, even despite our break with the USSR, so it might be worth helping him to survive this crisis?";
			}
			else if (GlobalScript.inst.gameState.number_event == 80)
			{
				text2 = "XII Congress of the 中共";
				text = "The next, XII, congress of the Chinese Communist Party begins its work in the Palace of People's Assemblies in Beijing. The congress is attended by 1,600 delegates and 149 candidates for delegates, with the current number of 中共s at 39.65 million. The agenda is usual ... However, now that the VI Plenum of the 11th 中共 Central Committee adopted the \"Decision on some questions of the history of the 中共 since the founding of the 中华人民共和国\", in which we indicated the possibility of a course for demaoisation, it may be worth a closed meeting at which to read the report \"On the cult of the personality of 毛泽东 and overcoming its consequences\", prepared in advance by a group of advisers? However, this runs the risk of undermining the 中共’s position very much - maybe it’s just worth mentioning in the Report \"correcting all the wrong \" in Mao’s activities and, under this pretext, start a cautious informal departure from Maoism? Or maybe not touch this question at all?..";
			}
			else if (GlobalScript.inst.gameState.number_event == 81)
			{
				text2 = "Hungarian Rhapsody";
				text = "Curious infromation came from Budapest - it seems that glorified in its own time by Khruschev kadarist \"goulash-socialism\" is on the verge of default, literally - Hungary owes the IMF 7.7 billion dollars, which it is not able to pay. According to our economists, the Hungarians have two options - either take new loans from the West and the USSR, or begin full-scale market reforms that will hurt the living standarts of the majority of population. The heads of HSWP won't take the last option, remembering about events of the Prague Spring, so they will likely take new loans. But we take advantage of issues of PRH and offer them our economic assistance - but under condition of the rehabilitation of disgraced stalinist Béla Biszku and his group, which oppose half-market reforms and can become our reliable support in HSWP. However, we can just offer help to the drowning without puting forward political conditions...";
			}
			else if (GlobalScript.inst.gameState.number_event == 82)
			{
				text2 = "Falklands War";
				text = "The UK is going through hard times recently, losing its once huge influence. The Argentine military junta led by Leopoldo Galtieri decided to use that for \"small victorious war\" .  On April 2, Argentine paratroopers landed on the Falkland Islands belonging to Britain, whose identity had long been challenged by Argentina, almost immediately breaking the resistance of the small British garrison. In response, the British sent their fleets to the islands with the intention of blocking them. It seems that there's a new conflict in the world.";
			}
			else if (GlobalScript.inst.gameState.number_event == 83)
			{
				text2 = "Problems of Stavropol agronomist";
				text = "Our special services managed to get access to important information. According to it, in the Soviet Union there are quite serious problems in agriculture, multiplied by the heavy rainfall this year. Agricultural secretary Fedor Kulakov, secretary of the CPSU Central Committee, is one of the most likely successors to the current Soviet leader, Leonid Brezhnev. According to the information obtained by our agents, Kulakov is in favor of actively studying and introducing the experience of Hungary and Yugoslavia into Soviet agriculture (i.e., decentralizing the management of collective farms and state farms, creating agricultural cooperatives based on family contracts and sole farms). We can use this to discredit him at the forthcoming Plenum of the Central Committee of the CPSU and, thus, remove this dangerous reformist from the road ...";
			}
			else if (GlobalScript.inst.gameState.number_event == 84)
			{
				text2 = "Our old partisan...";
				text = "So, now that Fedor Kulakov has been eliminated, it is time to pay attention to the conservative wing of the CPSU. In it, of course, the brightest figure - Peter Masherov - the First Secretary of the Central Committee of the Communist Party of Belarus. The former partisan commander, Masherov, headed Belarus in 1965 and achieved very significant success in the development of this republic of the USSR — national income increased several times, industrial and agricultural development was active, a number of enterprises were built, including the Azot Chemical Combine , Novopolotsk Chemical Plant \"Polymir\", Gomel Chemical Plant, Berezovskaya State District Power Plant. Thanks to the personal intervention of Masherov, the construction of the subway began in Minsk. The grain yield reached 27 c / ha, and the grain harvest - 7.3 million tons. However, because of his line on renovation of staff, Masherov caused dissatisfaction of many party members, he is in a rather conflicting relationship with the main ideologist of the CPSU, Mikhail Suslov, and was also very close to the disgraced Kulakov. Nevertheless, Leonid Brezhnev clearly relies on him as a possible successor to the elderly head of the Council of Ministers Kosygin, and the prime minister himself approves of this choice. The MGB has prepared several options for eliminating Masherov from the road.";
			}
			else if (GlobalScript.inst.gameState.number_event == 85)
			{
				text2 = "German autonomy in Kazakhstan";
				text = "Our sources in Moscow managed to get interesting information - a commission composed of Y. Andropov, I. Kapitonov, M. Zimyanin, Z. Nuriev, N. Shchelokova, R. Rudenko, M. Georgadze, V. Chebrikova submitted to the Central Committee of the CPSU a proposal for formation of German autonomy in the Kazakh SSR (where 940 thousand Germans were sent here in the 30-40s). However, the leadership of the republic, led by Leonid Brezhnev’s close associate, Dinmukhamed Kunaev, strongly opposes this. As far as we know, they are even ready to organize the riots of the Kazakh population in case that this autonomy is created. Kunaev is one of the most likely candidates for the post of Second Secretary of the CPSU Central Committee in the event of a change in the composition of the Soviet leadership, and his anti-Chinese sentiments are not a secret. It makes sense to take advantage of the situation to overthrow him.\nOn the other hand, some of your advisers ask: Why should we continue to help the Soviet Union to purify themselves when we can simply pit the Brezhnev clique against each other and benefit from it right now?";
			}
			else if (GlobalScript.inst.gameState.number_event == 86)
			{
				text2 = "The end of \"Iron Yuri\"";
				text = "As we know, Leonid Brezhnev has just traveled to Vienna to negotiate the SALT-2 agreement with US President Carter. Of course, the imperialists will not do any \"strategic offensive arms limitation\", but we are not interested in this - Brezhnev will spend enough time abroad so that we can strike at the all-powerful head of the USSR KGB Yuri Andropov. He is known as a supporter of the gradual improvement of Soviet-American relations and the conduct of large-scale reforms on the Hungarian model. Now Andropov is beginning to be regarded as the most likely successor to Leonid Brezhnev. So, there are two ways to get him out of the way — either physically eliminating him under the pretext of dying from kidney failure, or trying to “push” the main ideologist of the CPSU, Mikhail Suslov, and the head of the Ukrainian party organization of the CPSU, Vladimir Scherbitsky, who are in extremely bad relations with the head of the Soviet secret police , to the convocation of an emergency plenary session of the Central Committee of the CPSU and the rout of Andropov on it. Headed by Colonel-General Vitaliy Fedorchuk, the Ukrainian KGB submits to Scherbitsky and not at odds with his ally, so the chances of success are quite large.";
			}
			else if (GlobalScript.inst.gameState.number_event == 87)
			{
				text2 = "Peace for Galilee";
				text = "Due to the weakness of the Lebanese leadership, continuing  civil war in Lebanon since 1975, and the active assistance of Arab countries, the Palestine Liberation Organization was able to deploy a strong point for fighting against Israel in the south of Lebanon that was not controlled by the government. The sides repeatedly fired at each other, but it seems that now the conflict has entered a hot phase. On June 3, the Israeli assassination attempt was committed in London (as it turned out, another Palestinian group was responsible for it, which has no ties to PLO), which became a pretext for Israel’s massive bombardment of Lebanon, and on June 6 the Israeli army crossed the Lebanese border and tied battles with the forces of the PLO.";
			}
			else if (GlobalScript.inst.gameState.number_event == 88)
			{
				text2 = "The end of Zimbabwe apartheid";
				text = "In Rhodesia (also known as Zimbabwe), where the armed struggle of the black majority against the white authorities, pursuing a policy of racial segregation, has been going on for many years, it seems there has been a turn in politics. In December 1979, the Lancasterhouse Conference was held, at which agreement was reached on holding general equal elections, subject to a cease-fire and the formal proclamation of Zimbabwe-Rhodesia by the British colony until further determination of its fate. As a result, the left-nationalist coalition headed by ZANU and Robert Mugabe won the elections, and on April 18 the independence of the country renamed Zimbabwe was declared. At one time, we, like the USSR, supported the more moderate ZAPU — the current allies of ZANU in coalition — so it might be worth continuing cooperation with the victorious left parties?";
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
				text2 = "The End of an Era";
				text = "Breaking news from the USSR! Today the Soviet leadership announced the death of Leonid Ilyich Brezhnev, who led the Soviet Union for more than 20 years. The Soviet leader died of sudden cardiac failure in his sleep on the night of 1 July. In recent years, on the advice of doctors, Leonid Brezhnev had governed the country for no more than three hours a day and managed to avoid injuries, thanks to which he lived a relatively long life. While the entire Soviet people mourned, an active struggle for power took place in the CPSU, where the main competitors for the post of General Secretary of the CPSU Central Committee are:";
				if (GlobalScript.inst.gameState.empires[1].leaders[1].support > 0)
				{
					text += "|Volodymyr Scherbitsky, head of the Ukrainian Communist Party, a loyal brezhnevist, who has achieved great success in developing the economy and raising the standard of living in the Ukrainian SSR.";
				}
				text += "|Konstantin Chernenko, head of the General Department of the Central Committee of the CPSU, a conservative party member and an experienced organizer, whom some consider even stalinist for his views. |If our relations with the USSR are not the worst, then we could give support to one of the candidates. Of course, this will not fundamentally change the situation, but under a stalemate situation it may tip the balance in favor of a convenient candidate.";
			}
			else if (GlobalScript.inst.gameState.number_event == 89)
			{
				text2 = "The End of an Era";
				text = "Urgent news from the USSR! Today, the Soviet leadership announced the death of Leonid Ilyich Brezhnev, who led the Soviet Union for almost 20 years. The Soviet leader died on November 10 in a dream from a sudden heart failure. While all the Soviet people were grieving, an active struggle for power unfolded in the CPSU, where the main contenders for the post of General Secretary of the Central Committee of the CPSU are:";
				if (GlobalScript.inst.gameState.empires[1].leaders[3].support > 0)
				{
					text += "|Yuri Andropov, head of the KGB of the USSR, a pragmatic reformer, actively promoting his associates for reforms, such as Gorbachev, Ligachev and Dolgikh.";
				}
				if (GlobalScript.inst.gameState.empires[1].leaders[1].support > 0)
				{
					text += "|Volodymyr Scherbitsky, head of the Ukrainian Communist Party, a loyal brezhnevist, who has achieved great success in developing the economy and raising the standard of living in the Ukrainian SSR.";
				}
				text += "|Konstantin Chernenko, head of the General Department of the Central Committee of the CPSU, a conservative party member and an experienced organizer, whom some consider even stalinist for his views. |If our relations with the USSR are not the worst, then we could give support to one of the candidates. Of course, this will not fundamentally change the situation, but under a stalemate situation it may tip the balance in favor of a convenient candidate.";
			}
			else if (GlobalScript.inst.gameState.number_event == 90)
			{
				text2 = "Hong Kong Goodbye, Macao hasta la vista?";
				text = "As you know, we managed to reach an agreement on the return of control to China over Hong Kongin 1997 and over Macao in 1999 on the right of very broad autonomy, for which we even created a new territorial unit - \"special administrative region\". However, part of the local big bourgeoisie opposed this agreement and, as it became known to our intelligence services, is preparing a whole series of provocations aimed at disrupting it and preserving the colonial domination of Great Britain and Portugal (in particular, maximally delaying the development of the SAR Basic Laws, holding anti-Chinese rallies and publishing inflammatory materials in the media). In this situation, a number of party members came up with an unexpected proposal - to establish links with the so-called Triads - the 7th most influential Hong Kong crime syndicates, which have powerful links throughout Southeast Asia. We could offer them favorable economic preferences and guarantees of immunity - but on condition that they assist in the reunification of Hong Kong and Macao with homeland. So your solution?";
			}
			else if (GlobalScript.inst.gameState.number_event == 91)
			{
				text2 = "Rangoon bombing";
				text = "According to our data, today in the capital of Burma there was a terrorist attack, the purpose of which was the assassination of South Korean President Chun Doo-hwan. Chun Doo-hwan himself survived due to the fact that he arrived at the scene two minutes after the explosion, but 17 people from the South Korean delegation were killed. The terrorists were soon captured and, after interrogations, identified themselves as officers of the North Korean army. The DPRK itself denies any involvement in the incident, but the very fact of such an incident gives us the opportunity to rekindle the confrontation between the DPRK and South Korea with a new force.";
			}
			else if (GlobalScript.inst.gameState.number_event == 92)
			{
				text2 = "Overfulfilling is an honor!";
				text = "Comrade Chairman! In connection with the commencement of the implementation of the new five-year plan, some experts and economists from the planning committee suggest choosing a priority development sector for the next five-year period. You need to decide which of the areas of the national economy requires special attention and investment from the state - industry, agriculture, services or the development of science? However, we can also dispose of funds in a measured way and direct our forces towards the improvement of three sectors at once, which will lead to their more equal development.";
			}
			else if (GlobalScript.inst.gameState.number_event == 93)
			{
				text2 = "Homeland of democracy";
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
				text2 = "Tiananmen Incident. Again?!";
				text = "The policy of large-scale reforms in all spheres of life, the flourishing of corruption, the merging of the 中共 with business and the establishment of secret corruption links between the nomenklatura and businessmen caused a significant increase in bourgeois brain liberalization of a considerable part of the Chinese intelligentsia and youth requiring radicalization of reforms and rejection of \"communist contagion\". They formed a movement \"Tuidang\" (literally \"Refusal of the Party\") led by dissident astrophysicist Fang Lizhi, who in the West is called \"Chinese Sakharov\", advocating the announcement of the 中共 \"a criminal organization\" and her power removal from power, liberalization and westernization of the country, the fight against corruption and the privileges of the nomenclature. Using the permission to hold mass events, 100 thousand supporters of \"Tuidang\" gathered in Tiananmen Square in Beijing. They demand \"freedom\", \"democracy\", \"fighting corrupt bureaucrats\" and \"resigning corrupt party leadership\", while other dissatisfied with our reforms, including workers, join them every day. The liberal wing of the 中共, which heads " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[GlobalScript.inst.gameState.faction_leader[4]].name_2] + ", is inclined to agree with the demands of the protesters, hoping to come to power by a wave of protests. The situation is extremely unstable, but there is still an opportunity to intervene, until the unrest spread to other cities...";
			}
			else if (GlobalScript.inst.gameState.number_event == 95)
			{
				text2 = "New beginning for 中共";
				text = "So, the situation in Beijing was brought under control, and the power in the country passed to the liberal wing of the 中共, headed by Comrade " + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2] + ". On the agenda is the issue of large-scale policy deepening \"reform and opening-up\" and the transition to a Western-style democracy and a free market. However, the movement \"Tuidang\", with which we are now forced to reckon, requires to take into account in the reform project the need to decommunize Chinese society and, of course, the ruling party. In principle, the 中共 is so hard to call the \"communist\" party, but now we are invited to abandon Marxism-Leninism completely. So?..";
			}
			else if (GlobalScript.inst.gameState.number_event == 96)
			{
				text2 = "Perestroika! Democracy! Glasnost!";
				text = "So, the organizational issues are over and now we need to fulfill the promises given to the people about the democratization of China in the Western style. The people demand the cessation of pressure on religion and clergy, the expansion of civil rights and freedoms modeled on Western countries and, most importantly, the dissolution of the \"National Revolution United Front\" and free elections to the 全国人大 and local authorities. And if we cannot avoid the elections, we could make them as free as we need, by the fulfillment of other demands.";
			}
			else if (GlobalScript.inst.gameState.number_event == 97)
			{
				text2 = "Automation?";
				text = "This is our great scientific breakthrough - more recently we struggled with the total backwardness of our economy, and now our scientists have achieved outstanding success in developing mechanisms for automating economic planning based on computer systems, and have even begun to develop a system that allows automated planning and coordination of enterprises throughout the whole country. It’s still far from its full implementation, but now we can and should begin to introduce its grassroots regional systems and their coordination if we want to achieve success in automating our economy. However, many managers and members of the party, who consider such rates of introduction of an unfamiliar system too hasty, obviously don’t like it...";
			}
			else if (GlobalScript.inst.gameState.number_event == 98)
			{
				text2 = "African Che Guevara";
				text = "Comrade Chairman, urgent news from the former French colony of the Upper Volta! Incredibly popular among the people, the former prime minister and concurrently influential military figure Thomas Sankara, arrested several months earlier, overthrew the pro-french president Jean-Baptiste Ouedraogo, who massively closed trade unions and killed oppositionists. Immediately after the military coup, the name of the country was changed from colonial \"Upper Volta\" to \"Burkina Faso\" - \"home of honest people\", all state symbols were completely changed. Now, Thomas Sankara, who adheres to revolutionary anti-imperialist views, announces a policy of building socialism and \"fighting against the counter-revolutionary classes of society\", which in turn makes his position precarious. In order to carry out its revolutionary transformations and \"raise the country from its knees\", Sankara is seeking help from the socialist countries. Perhaps we should recognize the new power and send ambassadors, thereby showing our benevolent intentions. However, also, radical left anti-imperialist views, very close to Mao, with the necessary support, can create us a stable ally in central Africa. Although... it may not be worth it to be so hasty and \"rock the so-unstable boat of revolutions\" on the African continent? ";
			}
			else if (GlobalScript.inst.gameState.number_event == 117)
			{
				text2 = "Five years of funeral";
				text = "The news from the USSR has just arrived - on February 9, General Secretary of the CPSU Central Committee Yuri Andropov died of kidney failure at the age of 69. Since the end of 1983, he was very sick, and a cold caught in the Crimea finally finished off the Soviet leader. During his reign, Andropov paid great attention to improving the economic situation - a campaign was launched to fight for labor discipline, large-scale anti-corruption measures were launched, aimed mainly against the deficit of illegal write-offs in trade. At the same time, Andropov actively promoted young reformist cadres and instructed Gorbachev, Ryzhkov, Abalkin and Dolgikh to develop a project for a large-scale economic reform for the USSR. In view of the intensified political struggle, a compromise Chernenko is likely to be elected as the new General Secretary. And on February 14, Andropov’s funeral is scheduled, where representatives of many countries, both allied with the USSR and others, intend to arrive. And what should we do?";
			}
			else if (GlobalScript.inst.gameState.number_event == 114)
			{
				text2 = "Elephant and donkey";
				text = "Presidential elections will soon be held in the United States, in which current Democratic President Jimmy Carter runs for a second term, competing with the ambitious Republican Ronald Reagan. During his reign, Carter tried to improve Americans' welfare, create a more open government, and generally reform some US government institutions. Foreign policy was characterized by a balance between confrontation with the USSR and detente. However, Carter’s presidency coincided unsuccessfully with rising oil prices, and a relatively moderate foreign policy has been harshly criticized by conservative circles, so Republicans have every chance of winning. Of course, we cannot intervene, so we can only wait.";
			}
			else if (GlobalScript.inst.gameState.number_event == 99)
			{
				text2 = "Yellow scorpion";
				text = "Comrade Chairman, Breaking News from Socialist Algeria! After an unexpected and rapidly occurring illness, the second president of the PDRA, Houari Boumediene, who was popularly called the «Yellow Scorpion» for his secrecy and cunning, suddenly died. For almost a decade and a half of his reign, Boumediene made the industrial giant of Africa from the backward French colony. Now, due to the lack of succession in the country, in the ruling party, the «Front for National Liberation», three fraction are fighting for power: orthodox Stalinists, headed by Mohamed Salah Yahiaoui, who are zealously supported by the trade unions, and who are against the alliance with the «revisionist USSR», moderate reformers with leader Chadli Bendjedid, who are in favor of maintaining friendly relations with the USSR, but for introducing some market reforms, and liberals who are sympathetic to the pro-Western Foreign Minister - Abdelaziz Bouteflika. If we support one of the factions, we are likely to be able to expand our influence in African countries, but is it worth it?";
			}
			else if (GlobalScript.inst.gameState.number_event == 100)
			{
				text2 = "政府 CRISIS";
				text = "After uncounted putsch, the power of the military in Bangladesh has relatively stabilized, and the «kingmaker» Hussain Muhammad Ershad was able to take over as president of the country. During the two years of the existence of the right-wing authoritarian regime, full-scale repression was launched in Bangladesh against liberals and socialists, represented, for the most part, by the left-wing «Awami League», and the country's main problems: peasant land shortages and corruption in the highest echelons of power were not resolved. In this regard, with varying success, tough protests against government actions are unfolding in all cities of the country, the main slogan of which is the holding of early parliamentary elections. I think that if we financially support the government, we will be able to pacify this «troubled hotbed of coups» in Southeast Asia, especially as the current government is committed to warming relations with China. However, if we can stoke protests more strongly and rally the opposition against Ershad and the generals, then people more loyal to us will come to power, but what will the world community think in this case? Maybe it's better not to intervene at all?";
			}
			else if (GlobalScript.inst.gameState.number_event == 102)
			{
				text2 = "Wind of change?";
				text = "Urgent news from the USSR! March 10, 1985 at 19 hours 20 minutes, General Secretary Konstantin Ustinovich Chernenko died of cardiac arrest. While the people are mourning, a struggle is unfolding in the corridors of the Kremlin for the place of the new general secretary, the candidates for which are: |Mikhail Gorbachev - a young and promising party member, once a member of Andropov’s team, known for his reformist views. |Grigory Romanov - energetic and ready for experimentation, a young but experienced manager, the former head of the Leningrad Regional Committee, with an iron hand, ensured the growth of prosperity and economy in Leningrad. |And finally, Victor Grishin, a representative of the old generation 政治局 and a favorite of conservative circles, the head of the Moscow City Committee, a supporter of Brezhnev’s policy in internal and external affairs, over the years he has overgrown with connections (including corruption) in the CPSU. |Whom should we support, if we can?";
			}
			else if (GlobalScript.inst.gameState.number_event == 104)
			{
				text2 = "XII World Festival of Youth and Students";
				text = "The XII World Festival of Youth and Students is due to take place in Moscow soon. Such festivals have been organized by the World Federation of Democratic Youth - an international left-wing youth organization - since 1947 and have always been a vibrant gathering of progressive youth from around the world, and the festivals were aimed at promoting socialism and the fight against imperialism. We are faced with the eternal question - to go or not? After all, the USSR, being the host country and having enormous influence on the WFDY, may not let us in if there are strong disagreements. In this regard, some party members suggest holding their own similar festival, inviting representatives of friendly countries.";
			}
			else if (GlobalScript.inst.gameState.number_event == 105)
			{
				text2 = "End of Albanian Stalin";
				text = "Interesting news from Albania: on April 11, at the age of 76, the permanent leader of Albania Enver Hoxha died. While the country is grieving over its loss, Ramiz Alia took over the position of First Secretary of the APT Central Committee, who for a long time was considered the successor of Hoxha and played an important role in the defeat of Mehmet Shehu’s group. Alia enjoyed Hoxha ’s favor for unconditional support of all the turns of his policy, however, according to some reports, he was not averse to establishing relations with the West and Yugoslavia, as well as conducting some concessions in domestic politics. On the one hand, this can play into our hands, and on the other, it’s not known how it will end. Therefore, we could organize a terrorist attack against the new ruler, if, of course, we have agents nearby.";
			}
			else if (GlobalScript.inst.gameState.number_event == 106)
			{
				text2 = "Democratic International";
				text = "In the Angolan city of Jamba, which is the main base of the anti-communist rebel movement UNITA, a conference is being prepared following the results of which the participants want to create the so-called. \"Democratic International\" - a coalition of anti-communist rebels from different countries. In addition to UNITA, the conference is attended by representatives of Afghan mujahideen, Nicaraguan contra and Lao Hmong, and American conservatives, such as banker Lewis Lerman (event financier), famous lobbyist and film producer Jack Abramoff (event initiator) and lieutenant colonel Oliver North, are actively participating in the organization. Despite the bright anti-Soviet orientation of the upcoming alliance, it also intersects with the zone of our interests and may cause problems in the future. On the other hand, we can try to use it in the geopolitical struggle with the USSR.";
			}
			else if (GlobalScript.inst.gameState.number_event == 109)
			{
				text2 = "Somalia's Golden Age";
				text = "After the failure of the Ogaden War, the situation in Somalia began to deteriorate rapidly. The liberation front of Western Somalia suffered a crushing defeat and was defeated by the Ethiopian army, and the collapse of Soviet military and civilian assistance seriously hit the Somali economy. The Somali revolutionary socialist party is gradually beginning to lose popularity, and the regime of Jaalle Mohamed Siad Barre is becoming increasingly authoritarian. In such a depressing atmosphere, the Somali government is trying to distance itself from the Soviet Union by moving to cooperation with the United States and Western countries. Perhaps sending all possible assistance to the Somali government to resolve the situation in the country, we can enlist the support of Barre and get a profitable and loyal ally in East Africa. However, will this save the SRSP regime, against which armed opposition groups are actively forming throughout the country? The generals are extremely dissatisfied with the indecision of President Barre, perhaps, having secured their support, we can manage to conspire against him and bring more pragmatic leaders to power?";
			}
			else if (GlobalScript.inst.gameState.number_event == 110)
			{
				text2 = "Automation is a natural process";
				text = "Comrade Chairman! Over the previous five-year period, we have made great strides in the conduct of the national economy and scientific research, and we should not stop there. It is time to consolidate our successes and recreate the dream of many generations of people about a perfect world order, taking the first step from a socialist to a communist society. The best minds of our country - mathematicians and cybernetics - offer to create a full-scale and comprehensive system of unified automated production planning, taking as their basis the idea of ??the OGAS concept of the Soviet mathematician Viktor Glushkov. Thus, we will be able to get rid of all the problems and flaws of a planned economy by transferring the implementation of most complex and costly calculations to computers. But to implement such a huge project, it will take a lot of money and time, but the state apparatus is afraid of radical changes like fire, especially those that might encroach on their «occupied places» and prosperity. The choice is yours…";
			}
			else if (GlobalScript.inst.gameState.number_event == 111)
			{
				text2 = "To the ghostly light";
				text = "Comrade Chairman! After the partial implementation of the IECS system, the government began a gradual and systematic reduction of the state apparatus at the grassroots level to free unnecessary skilled workers and optimize the budget. These measures have met with stiff resistance from the local bureaucracy, which has already declared you in «bourgeois counter-revolution». Now even the top party leadership is opposed to you and is already preparing your dismissal. We need to take action immediately! We need to enlist the support of wide sections of the population and the victory will be ours! But the question is, will they support us?";
			}
			else if (GlobalScript.inst.gameState.number_event == 112)
			{
				text2 = "Stories of unknown worlds";
				text = "Comrade Chairman, strange things are happening! Intersectoral organizations fail throughout the country. Messages between grassroots enterprises are broken, food is being delivered to regions with interruptions, and queues in stores are growing. According to the assurances of the managers, a computer attack from outside was carried out on our equipment. Intelligence agencies suggest that these are our external opponents, conspiring with the enemies of automation, fearing the inevitable growth of our influence on the world stage, are trying to strike a blow at our economy by disabling IECS. If we do nothing immediately, this will result in a collapse for our country. Specialists suggest developing special protection for our planning system, but this will take some time. However, we can request the support of experts from the Soviet Union, which in turn will allow us to quickly return the equipment to operation. Or... is automation really utopian?";
			}
			else if (GlobalScript.inst.gameState.number_event == 113)
			{
				text2 = "Agony of Yugoslav Socialist Self-Government";
				text = "Comrade Chairman, news unpleasant for us comes from Yugoslavia - the so-called \"Kraiger Commission\", headed by former Chairman of the Presidium of the SFRY Sergej Kraigher (Slovene by nationality and close associate of the main theorist of Yugoslav \"socialist self-government\" Edvard Kardelj), submitted for consideration Presidium of the SFRY project for large-scale market economic reforms. Yugoslavia after the death of Josip Broz Tito is going through difficult times - the consequences of the separatist rebellion in Kosovo are still not eliminated, dissatisfaction with the Center is growing in Slovenia and Croatia, and nationalist sentiments are growing in Serbia. The 1979 economic crisis added fuel to the fire, forcing the country, which was already soiling in debt, to take additional loans. It seems that Yugoslavia is moving towards the abyss... USSR and the countries of the socialist camp are ready to provide the SFRY with a large financial help in exchange for refusing reform. We can also join the proposal of the Soviet leadership, however, a group of party members offers to reprove the military coup and bring to power the Yugoslav generals, determined to end the policy of \"non-alignment\". On the other hand, the USA also offers the SFRY new loans... So, what will we do in this situation?";
			}
			else if (GlobalScript.inst.gameState.number_event == 115)
			{
				text2 = "Golden Triangle";
				text = "Comrade Chairman, as our special services know, in the mountainous regions of Burma, Laos and Thailand, which have recently become part of our sphere of influence, there is a large network of syndicates involved in the production and marketing of drugs, called the \"Golden Triangle\". This network is highly conducive to corruption in these and surrounding countries, and it is also led by a prominent member of the Shan people, who advocate their separation from Burma, Khun Sa. Taking all this into account, part of the party members and the generals offer to assist these countries in conducting investigative and military operations against drug dealers. However, there is another group that rightly claims that over the long years of the civil war, the Shan have not been able to achieve independence from Burma and are unlikely to succeed, corruption in these countries cannot be eliminated by striking a single network of syndicates, and these drugs go mainly to Western countries . In this regard, they offer to help the Golden Triangle in the organization of protection and marketing of goods, which will help us get money and spoil the life of the West.";
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
				text2 = "Two China";
				text = "As you know, after the 中共's victory in the civil war, the Kuomintang fled to the island of Taiwan, and for a long time the western community considered them the legitimate government of China. Because of American bases and the fleet in Taiwan, we were unable to recapture it, just as the Kuomintang could not regain mainland China, and over time, more and more countries recognized the rule of the 中共, although neither the communist nor the Taiwanese government formally refused claims to all of China. Of course, our relations have always been terrible, but after the recent liberalization and the end of the 中共’s monopoly on power, they have become noticeably warmer. Now some people at the top of both countries are talking about the possibility of the long-awaited reunification of the nation. However, in this case, Taiwan will unequivocally demand autonomy, we will need to agree with the United States on the status of their bases, and it is not known how the people of Taiwan, who managed to develop their cultural identity, will affect the already unstable situation in the country. Therefore, some suggest that we with Taiwan mutually recognize each other as independent states and establish good neighborly relations. And since in this case the American bases will remain in place, and Western companies will be spared the heap of bureaucratic fuss, it would be nice to hint the United States that young democracy needs money...";
			}
			else if (GlobalScript.inst.gameState.number_event == 103)
			{
				if (GlobalScript.inst.gameState.allcountries[0].isEU)
				{
					text2 = "Schengen Agreement";
					text = "Recently, on July 14 in Luxembourg between several European countries the Schengen Agreement was signed, implying simplification of passport and visa control at the borders between them and outlining a move towards an almost complete rejection of passport control. The Schengen agreement was a continuation of the visa-free regime adopted long ago at the EEC, which prompted your party members to think that we also have our own economic union. The creation of a single visa space, the free movement between the countries of the union and the simplification of border controls should facilitate the cultural exchange between our countries, the development of tourism, and people will like it. The problem is that it will also simplify the life of dissidents and criminals, and indeed, it is unknown which ideas our citizens will get abroad...";
				}
				else
				{
					text2 = "Madrid Agreement";
					text = "Recently, on July 14 in Luxembourg between several European countries the Madrid Agreement was signed, implying simplification of passport and visa control at the borders between them and outlining a move towards an almost complete rejection of passport control. The Madrid agreement was a continuation of the visa-free regime adopted at the SU, which prompted your party members to think that we also have our own economic union. The creation of a single visa space, the free movement between the countries of the union and the simplification of border controls should facilitate the cultural exchange between our countries, the development of tourism, and people will like it. The problem is that it will also simplify the life of dissidents and criminals, and indeed, it is unknown which ideas our citizens will get abroad...";
				}
			}
			else if (GlobalScript.inst.gameState.number_event == 107)
			{
				text2 = "Allied Crisis";
				text = "As everyone knows, our community is the most democratic and equal... and this gives rise to consequences. " + GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].name + " has recently been pursuing an increasingly independent policy from us, and disloyal forces that want to carry out some reforms are gaining power in their political system.";
				if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].usalliance)
				{
					text += " But even worse is their diplomatic flirting with the United States and the West! If this continues, then we risk losing our ally, so we need to do something, but what? We do not want to act like Soviet revisionists in Czechoslovakia. Or..?";
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].sovalliance)
				{
					text += " But even worse is their diplomatic flirting with the USSR! If this continues, then we risk losing our ally, so we need to do something, but what? We do not want to act like Soviet revisionists in Czechoslovakia. Or..?";
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].okb)
				{
					text += "|And all this happens against the background of the forthcoming declaration of our ally’s government on the declaration of a policy of neutrality, which means one thing: they want to leave our military alliance.";
				}
				else if (GlobalScript.inst.gameState.allcountries[GlobalScript.inst.gameState.data[120]].econ)
				{
					text += "|And all this happens against the background of how the government of our ally is feverishly cutting all trade ties with us, declaring a reorientation of its economy, which means one thing: they want to leave our economic alliance.";
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
