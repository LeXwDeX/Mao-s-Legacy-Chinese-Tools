using System;
using System.Collections.Generic;
using UnityEngine;

public class CitizenManager : MonoBehaviour
{
	public enum PrimaryTrait
	{
		None,
		LeftRadical,
		Moderate,
		Reformist,
		Liberal
	}

	public enum SecondaryTrait
	{
		None,
		Firm,
		Pragmatic,
		Soft,
		Scientist
	}

	public enum TertiaryTrait
	{
		None,
		Pettytyrant,
		Thrifty,
		Arrogant,
		Idol,
		Chinophilic,
		Westophilic,
		Schemer,
		Timid,
		Peculator
	}

	private class CitizenEvent
	{
		public string EventName { get; set; }

		public int PeriodMonths { get; set; }

		public Action<Persona, int> EventAction { get; set; }

		public int[] NextTriggerDate { get; set; }

		public bool IsChainEvent { get; set; }

		public string ChainId { get; set; }

		public Dictionary<string, object> EventData { get; set; }
	}

	private GlobalScript globalScript;

	private TranslateScriptDLC translateScript;

	private int lastCheckedDay = -1;

	private readonly List<CitizenEvent>[] _citizenEvents = new List<CitizenEvent>[3];

	private TranslateScriptDLC _translateScript;

	public static CitizenManager Instance { get; private set; }

	private TranslateScriptDLC TranslateScript
	{
		get
		{
			TryFindTranslate();
			return _translateScript;
		}
	}

	public static string FormatLog(Persona citizen, string actionRu, string actionEn, int[] date)
	{
		string text = $"{date[2]}.{date[1]:D2}.{date[0]:D2}";
		if (PlayerPrefs.GetInt("language") == 0)
		{
			return text + ": " + citizen.name + " " + citizen.surname + " " + actionEn;
		}
		return text + ": " + citizen.name + " " + citizen.surname + " " + actionRu;
	}

	private void TryFindTranslate()
	{
		if (_translateScript == null)
		{
			_translateScript = UnityEngine.Object.FindObjectOfType<TranslateScriptDLC>();
			if (_translateScript == null)
			{
				Debug.LogWarning("TranslateScriptDLC не найден в сцене!");
			}
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		globalScript = GlobalScript.inst;
		translateScript = UnityEngine.Object.FindObjectOfType<TranslateScriptDLC>();
		if (globalScript == null)
		{
			Debug.LogError("GlobalScript не найден!");
		}
		for (int i = 0; i < _citizenEvents.Length; i++)
		{
			_citizenEvents[i] = new List<CitizenEvent>();
		}
	}

	private void Start()
	{
	}

	public void AddCitizen(Persona citizen, int slot)
	{
		if (slot < 0 || slot >= 3)
		{
			Debug.LogWarning("Недопустимый индекс слота!");
			return;
		}
		int num = globalScript.gameState.data[21];
		int num2 = globalScript.gameState.data[20];
		int num3 = globalScript.gameState.data[19];
		citizen.birthDate = new int[3]
		{
			num3,
			num2,
			num - citizen.age
		};
		citizen.secondaryTrait = SecondaryTrait.None;
		citizen.tertiaryTraits = new List<TertiaryTrait>();
		citizen.jobHistory = new List<Job> { citizen.status };
		globalScript.gameState.citizens[slot] = citizen;
		AssignTraits(slot);
		ScheduleCitizenEvents(slot, citizen);
		PersonaCreator personaCreator = UnityEngine.Object.FindObjectOfType<PersonaCreator>();
		if (personaCreator != null)
		{
			personaCreator.UpdateStatUI();
		}
	}

	private void UpdateAges()
	{
		int num = globalScript.gameState.data[21];
		int num2 = globalScript.gameState.data[20];
		int num3 = globalScript.gameState.data[19];
		for (int i = 0; i < 3; i++)
		{
			Persona persona = globalScript.gameState.citizens[i];
			if (persona == null || persona.isDead)
			{
				continue;
			}
			int num4 = persona.birthDate[2];
			int num5 = persona.birthDate[1];
			int num6 = persona.birthDate[0];
			int num7 = num - num4;
			if (num2 < num5 || (num2 == num5 && num3 < num6))
			{
				num7--;
			}
			if (num7 == persona.age)
			{
				continue;
			}
			persona.age = Mathf.Clamp(num7, 18, 80);
			int[] date = new int[3] { num3, num2, num };
			Debug.Log($"Гражданину исполнилось {num7}/ было {persona.age}");
			persona.changeLog.Add(FormatLog(persona, $"отметил день рождения! Возраст: {persona.age}", $"celebrated birthday! Age: {persona.age}", date));
			if (persona.isPolitic)
			{
				for (int j = 0; j < globalScript.gameState.politics.Length; j++)
				{
					Politic politic = globalScript.gameState.politics[j];
					if (politic != null && politic.isCitizen && globalScript.gameState.names1[politic.name_1] == persona.name && globalScript.gameState.names2[politic.name_2] == persona.surname)
					{
						politic.age = (byte)persona.age;
						Debug.Log($"Возраст обновлён и у политика: {persona.name} {persona.surname} → {persona.age} лет");
						break;
					}
				}
			}
			if (persona.isLead)
			{
				globalScript.gameState.leader.age = (byte)persona.age;
			}
		}
		PersonaCreator personaCreator = UnityEngine.Object.FindObjectOfType<PersonaCreator>();
		if (personaCreator != null)
		{
			personaCreator.UpdateStatUI();
		}
	}

	public void UpdateCitizenJob(int slot, Job newJob)
	{
		if (slot < 0 || slot >= 3 || globalScript.gameState.citizens[slot] == null)
		{
			Debug.LogWarning("Недопустимый слот или гражданин отсутствует!");
			return;
		}
		Persona persona = globalScript.gameState.citizens[slot];
		if (persona.status != newJob)
		{
			persona.status = newJob;
			if (!persona.jobHistory.Contains(newJob))
			{
				persona.jobHistory.Add(newJob);
			}
			PersonaCreator personaCreator = UnityEngine.Object.FindObjectOfType<PersonaCreator>();
			if (personaCreator != null)
			{
				personaCreator.UpdateStatUI();
			}
		}
	}

	private void AssignTraits(int slot)
	{
		if (slot >= 0 && slot < 3 && globalScript.gameState.citizens[slot] != null)
		{
			Persona persona = globalScript.gameState.citizens[slot];
			if (persona.primaryTrait == PrimaryTrait.None)
			{
				persona.secondaryTrait = SecondaryTrait.None;
				persona.tertiaryTraits.Clear();
				AssignPrimaryTrait(persona);
				AssignSecondaryTrait(persona);
				AssignTertiaryTraits(persona);
			}
			else
			{
				AssignSecondaryTrait(persona);
				AssignTertiaryTraits(persona);
			}
		}
	}

	private void AssignPrimaryTrait(Persona citizen)
	{
		List<PrimaryTrait> list = new List<PrimaryTrait>();
		int num = 0;
		if (citizen.Intrigue >= 8)
		{
			num++;
		}
		if (citizen.Wealth <= 3)
		{
			num++;
		}
		if (citizen.Children >= 2)
		{
			num++;
		}
		if (HasJobHistory(citizen, new Job[5]
		{
			Job.Worker,
			Job.Peasant,
			Job.Farmer,
			Job.Underground,
			Job.Unemployed
		}))
		{
			num++;
		}
		if (num >= 2)
		{
			list.Add(PrimaryTrait.LeftRadical);
		}
		int num2 = 0;
		if (citizen.Wealth >= 7)
		{
			num2++;
		}
		if (citizen.Charisma >= 5)
		{
			num2++;
		}
		if (citizen.age <= 40)
		{
			num2++;
		}
		if (HasJobHistory(citizen, new Job[2]
		{
			Job.CorporationOwner,
			Job.SmallBusinessOwner
		}))
		{
			num2++;
		}
		if (num2 >= 2)
		{
			list.Add(PrimaryTrait.Liberal);
		}
		int num3 = 0;
		if (citizen.Charisma >= 7)
		{
			num3++;
		}
		if (citizen.Intrigue >= 6)
		{
			num3++;
		}
		if (citizen.Wealth >= 4)
		{
			num3++;
		}
		if (citizen.age >= 30 && citizen.age <= 50)
		{
			num3++;
		}
		if (HasJobHistory(citizen, new Job[3]
		{
			Job.SmallBusinessOwner,
			Job.LocalPartyBranchChief,
			Job.SignificantPartyMember
		}))
		{
			num3++;
		}
		if (num3 >= 3)
		{
			list.Add(PrimaryTrait.Reformist);
		}
		int num4 = 0;
		if (citizen.age >= 40 && citizen.age <= 60)
		{
			num4++;
		}
		if (citizen.Wealth >= 4 && citizen.Wealth <= 6)
		{
			num4++;
		}
		if (citizen.Charisma >= 4 && citizen.Charisma <= 6)
		{
			num4++;
		}
		if (HasJobHistory(citizen, new Job[4]
		{
			Job.LocalPartyBranchChief,
			Job.RegionalPartyBranchChief,
			Job.Farmer,
			Job.Worker
		}))
		{
			num4++;
		}
		if (num4 >= 3)
		{
			list.Add(PrimaryTrait.Moderate);
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			citizen.primaryTrait = list[index];
		}
		else
		{
			citizen.primaryTrait = PrimaryTrait.Moderate;
		}
	}

	private void AssignSecondaryTrait(Persona citizen)
	{
		List<SecondaryTrait> list = new List<SecondaryTrait>();
		int num = 0;
		if (citizen.Intrigue >= 7)
		{
			num++;
		}
		if (citizen.Charisma <= 4)
		{
			num++;
		}
		if (citizen.age >= 45)
		{
			num++;
		}
		if (citizen.Children >= 3)
		{
			num++;
		}
		if (num >= 3)
		{
			list.Add(SecondaryTrait.Firm);
		}
		int num2 = 0;
		if (citizen.Charisma < 4)
		{
			num2++;
		}
		if (citizen.Intrigue <= 3)
		{
			num2++;
		}
		if (citizen.age <= 40)
		{
			num2++;
		}
		if (citizen.Children <= 1)
		{
			num2++;
		}
		if (num2 >= 2)
		{
			list.Add(SecondaryTrait.Soft);
		}
		int num3 = 0;
		if (citizen.Wealth <= 3)
		{
			num3++;
		}
		if (citizen.Intrigue <= 5)
		{
			num3++;
		}
		if (citizen.Charisma <= 3)
		{
			num3++;
		}
		if (citizen.age >= 40)
		{
			num3++;
		}
		if (citizen.Children <= 1)
		{
			num3++;
		}
		if (num3 >= 3)
		{
			list.Add(SecondaryTrait.Scientist);
		}
		int num4 = 0;
		if (citizen.Intrigue >= 5 && citizen.Intrigue <= 7)
		{
			num4++;
		}
		if (citizen.Wealth >= 4 && citizen.Wealth <= 7)
		{
			num4++;
		}
		if (citizen.age >= 30 && citizen.age <= 55)
		{
			num4++;
		}
		if (citizen.Charisma >= 4 && citizen.Charisma <= 6)
		{
			num4++;
		}
		if (num4 >= 3)
		{
			list.Add(SecondaryTrait.Pragmatic);
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			citizen.secondaryTrait = list[index];
		}
		else
		{
			citizen.secondaryTrait = SecondaryTrait.Pragmatic;
		}
	}

	private void AssignTertiaryTraits(Persona citizen)
	{
		if ((float)citizen.age / 5f + (float)citizen.Intrigue * 1.5f + (float)citizen.status * 0.5f - (float)citizen.Charisma / 2f > 14f)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Pettytyrant);
		}
		if ((float)(10 - citizen.Wealth) + (float)citizen.Children * 1.5f + (float)citizen.age / 10f > 7f)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Thrifty);
		}
		if ((float)citizen.Wealth * 1.5f + (float)citizen.Charisma / 2f + (float)citizen.status - (float)citizen.Children > 12f)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Arrogant);
		}
		if ((float)(citizen.Charisma * 2) + (float)citizen.Wealth / 2f - (float)citizen.Intrigue + (float)((citizen.status > Job.Underground) ? 2 : 0) > 15f)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Idol);
		}
		if ((float)citizen.age / 4f + (float)citizen.Intrigue / 2f + (float)((citizen.status == Job.Farmer || citizen.status == Job.Peasant) ? 4 : 0) + (float)citizen.Children * 0.5f > 10f)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Chinophilic);
		}
		if (citizen.Wealth + citizen.Charisma + ((citizen.status == Job.CorporationOwner || citizen.status == Job.SmallBusinessOwner) ? 4 : 0) - citizen.Intrigue > 13)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Westophilic);
		}
		if ((float)(citizen.Intrigue * 2) + (float)citizen.status / 2f - (float)citizen.Charisma + (float)citizen.Wealth / 2f > 11f)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Schemer);
		}
		if (10 - citizen.Charisma + (10 - citizen.Intrigue) + ((citizen.Children < 2) ? 2 : 0) > 14)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Timid);
		}
		if ((float)citizen.Intrigue * 1.5f + (float)citizen.Wealth + (float)((citizen.status > Job.Underground) ? 2 : 0) > 13f)
		{
			citizen.tertiaryTraits.Add(TertiaryTrait.Peculator);
		}
	}

	private bool HasJobHistory(Persona citizen, Job[] jobs)
	{
		foreach (Job item in jobs)
		{
			if (citizen.jobHistory.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public (PrimaryTrait, SecondaryTrait, List<TertiaryTrait>) GetCitizenTraits(int slot)
	{
		if (slot < 0 || slot >= 3 || globalScript.gameState.citizens[slot] == null)
		{
			Debug.LogWarning("Недопустимый слот или гражданин отсутствует!");
			return (PrimaryTrait.None, SecondaryTrait.None, new List<TertiaryTrait>());
		}
		Persona persona = globalScript.gameState.citizens[slot];
		return (persona.primaryTrait, persona.secondaryTrait, persona.tertiaryTraits);
	}

	public string GetTraitTranslation(PrimaryTrait trait)
	{
		return trait switch
		{
			PrimaryTrait.LeftRadical => translateScript.GetTranslation("Left Radical", "Левый радикал"), 
			PrimaryTrait.Moderate => translateScript.GetTranslation("Moderate", "Умеренный"), 
			PrimaryTrait.Reformist => translateScript.GetTranslation("Reformist", "Реформист"), 
			PrimaryTrait.Liberal => translateScript.GetTranslation("Liberal", "Либерал"), 
			_ => "Отсутствует", 
		};
	}

	public string GetTraitTranslation(SecondaryTrait trait)
	{
		return trait switch
		{
			SecondaryTrait.Firm => translateScript.GetTranslation("Firm", "Твёрдый"), 
			SecondaryTrait.Pragmatic => translateScript.GetTranslation("Pragmatic", "Прагматик"), 
			SecondaryTrait.Soft => translateScript.GetTranslation("Soft", "Мягкий"), 
			SecondaryTrait.Scientist => translateScript.GetTranslation("Scientist", "Учёный"), 
			_ => "Отсутствует", 
		};
	}

	public string GetTraitTranslation(TertiaryTrait trait)
	{
		return trait switch
		{
			TertiaryTrait.Pettytyrant => translateScript.GetTranslation("Petty tyrant", "Самодур"), 
			TertiaryTrait.Thrifty => translateScript.GetTranslation("Thrifty", "Экономный"), 
			TertiaryTrait.Arrogant => translateScript.GetTranslation("Arrogant", "Надменный"), 
			TertiaryTrait.Idol => translateScript.GetTranslation("Idol", "Кумир"), 
			TertiaryTrait.Chinophilic => translateScript.GetTranslation("Chinophilic", "Китаефил"), 
			TertiaryTrait.Westophilic => translateScript.GetTranslation("Westophilic", "Западник"), 
			TertiaryTrait.Schemer => translateScript.GetTranslation("Schemer", "Интриган"), 
			TertiaryTrait.Timid => translateScript.GetTranslation("Timid", "Робкий"), 
			TertiaryTrait.Peculator => translateScript.GetTranslation("Peculator", "Казнокрад"), 
			_ => "Отсутствует", 
		};
	}

	public void PromoteToPolitic(int slot)
	{
		GameObject gameObject = GameObject.Find("Ach(Clone)");
		if (slot < 0 || slot >= 3 || globalScript.gameState.citizens[slot] == null)
		{
			Debug.LogWarning("Недопустимый слот или гражданин отсутствует!");
			return;
		}
		Persona persona = globalScript.gameState.citizens[slot];
		if (persona.status != Job.SignificantPartyMember && !persona.isLead)
		{
			Debug.LogWarning("Гражданин должен быть значимым членом партии для возвышения!");
			return;
		}
		gameObject.GetComponent<achievements>().Set(208);
		Debug.Log("Ачивка Ввести гражданина в политики получена!");
		persona.isPolitic = true;
		Politic politic = null;
		int num = int.MaxValue;
		int num2 = -1;
		for (int i = 0; i < globalScript.gameState.politics.Length; i++)
		{
			if (globalScript.gameState.politics[i] != null && globalScript.gameState.politics[i].power < num && !globalScript.gameState.politics[i].isCitizen)
			{
				num = globalScript.gameState.politics[i].power;
				politic = globalScript.gameState.politics[i];
				num2 = i;
			}
		}
		if (politic == null || num2 == -1)
		{
			Debug.LogWarning("Нет доступных политиков для замены!");
			return;
		}
		Politic politic2 = new Politic
		{
			name_1 = MapNameToIndex(persona.name, globalScript.gameState.names1),
			name_2 = MapNameToIndex(persona.surname, globalScript.gameState.names2),
			age = (byte)persona.age,
			face_type = persona.face_type,
			face_parts = (byte[])persona.face_parts.Clone(),
			jacket = persona.jacket,
			power = politic.power + 10,
			loyality = persona.Charisma * 10,
			loyality_to_other = new int[18],
			traits = ConvertTraitsToPoliticTraits(persona),
			is_sagovor = false,
			is_sleshka = false,
			is_sledstvie = false,
			you_fall = false,
			days_sleshka = 0,
			sled_slej = 0,
			wantedDolzh = (byte)UnityEngine.Random.Range(0, 4),
			in_power = 0,
			autosupport = 0,
			autohound = 0,
			isCitizen = true
		};
		for (int j = 0; j < globalScript.gameState.politics_dolshnost.Length; j++)
		{
			if (globalScript.gameState.politics_dolshnost[j] == num2)
			{
				globalScript.gameState.politics_dolshnost[j] = 200;
			}
		}
		globalScript.gameState.politics[num2] = politic2;
		globalScript.gameState.CalcRel(num2);
		globalScript.gameState.CalcRel2(num2);
		globalScript.gameState.CalcRelLeader(num2);
		PersonaCreator personaCreator = UnityEngine.Object.FindObjectOfType<PersonaCreator>();
		if (personaCreator != null)
		{
			personaCreator.UpdateStatUI();
		}
		Debug.Log($"Гражданин {persona.name} {persona.surname} возвышен до политика с силой {politic2.power}");
		int[] date = CurrentDate();
		persona.changeLog.Add(FormatLog(persona, "был возвышен до политика", "was promoted to politician", date));
	}

	private byte MapNameToIndex(string name, string[] nameList)
	{
		if (nameList == null || nameList.Length == 0)
		{
			Debug.LogWarning("Список имен пуст! Возвращаем случайный индекс.");
			return (byte)UnityEngine.Random.Range(4, 50);
		}
		int num = Array.IndexOf(nameList, name);
		if (num >= 0 && num < 255)
		{
			Debug.Log($"Имя {name} найдено в списке, индекс: {num}");
			return (byte)num;
		}
		List<string> list = new List<string>(nameList);
		list.Add(name);
		if (nameList == globalScript.gameState.names1)
		{
			globalScript.gameState.names1 = list.ToArray();
		}
		else
		{
			globalScript.gameState.names2 = list.ToArray();
		}
		Debug.Log($"Имя {name} добавлено в список, новый индекс: {list.Count - 1}");
		return (byte)(list.Count - 1);
	}

	private byte[] ConvertTraitsToPoliticTraits(Persona citizen)
	{
		byte[] array = new byte[3];
		switch (citizen.primaryTrait)
		{
		case PrimaryTrait.LeftRadical:
			array[0] = 0;
			break;
		case PrimaryTrait.Moderate:
			array[0] = 1;
			break;
		case PrimaryTrait.Reformist:
			array[0] = 2;
			break;
		case PrimaryTrait.Liberal:
			array[0] = 3;
			break;
		default:
			array[0] = 1;
			break;
		}
		switch (citizen.secondaryTrait)
		{
		case SecondaryTrait.Firm:
			array[1] = 4;
			break;
		case SecondaryTrait.Pragmatic:
			array[1] = 5;
			break;
		case SecondaryTrait.Soft:
			array[1] = 6;
			break;
		case SecondaryTrait.Scientist:
			array[1] = 7;
			break;
		default:
			array[1] = 5;
			break;
		}
		if (citizen.tertiaryTraits.Count > 0)
		{
			switch (citizen.tertiaryTraits[0])
			{
			case TertiaryTrait.Pettytyrant:
				array[2] = 10;
				break;
			case TertiaryTrait.Thrifty:
				array[2] = 11;
				break;
			case TertiaryTrait.Arrogant:
				array[2] = 12;
				break;
			case TertiaryTrait.Idol:
				array[2] = 13;
				break;
			case TertiaryTrait.Chinophilic:
				array[2] = 14;
				break;
			case TertiaryTrait.Westophilic:
				array[2] = 15;
				break;
			case TertiaryTrait.Schemer:
				array[2] = 16;
				break;
			case TertiaryTrait.Timid:
				array[2] = 17;
				break;
			case TertiaryTrait.Peculator:
				array[2] = 18;
				break;
			default:
				array[2] = 8;
				break;
			}
		}
		if (globalScript.gameState.gamerules[8] > 0)
		{
			if (array[1] == 7)
			{
				array[1] = 6;
			}
			if (array[2] == 11)
			{
				array[2] = 18;
			}
			else if (array[2] == 13)
			{
				array[2] = 10;
			}
		}
		return array;
	}

	public void CheckForChildren(Persona citizen, int slot)
	{
		if (citizen != null && citizen.age >= 20 && citizen.age <= 80 && citizen.Children < 5)
		{
			float num = 0f;
			if (citizen.age >= 20 && citizen.age <= 30)
			{
				num += 1.2f;
			}
			else if (citizen.age >= 31 && citizen.age <= 40)
			{
				num += 0.9f;
			}
			else if (citizen.age >= 41 && citizen.age <= 50)
			{
				num += 0.5f;
			}
			else if (citizen.age > 50)
			{
				num += 0.1f;
			}
			int num2 = globalScript.gameState.data[5] / 10;
			num = ((num2 >= 0 && num2 <= 30) ? (num + 0.6f) : ((num2 <= 60) ? (num + 0.4f) : ((num2 > 85) ? (num + 0.1f) : (num + 0.2f))));
			int num3 = globalScript.gameState.data[3];
			int num4 = globalScript.gameState.data[4];
			float num5 = (float)(1000 - num3 + num4) / 20f;
			if (num5 > 70f)
			{
				num -= num5 / 100f;
			}
			switch (globalScript.gameState.data[14])
			{
			case 0:
			case 1:
				num += 0.4f;
				break;
			case 2:
			case 3:
				num += 0.2f;
				break;
			case 4:
			case 5:
				num -= 0.1f;
				break;
			}
			if (citizen.status == Job.Unemployed || citizen.status == Job.Peasant || citizen.status == Job.Farmer)
			{
				num += 0.3f;
			}
			else if (citizen.status == Job.CorporationOwner || citizen.status == Job.SignificantPartyMember)
			{
				num -= 0.2f;
			}
			num = ((citizen.Wealth >= 0 && citizen.Wealth <= 2) ? (num + 0.4f) : ((citizen.Wealth > 6) ? (num + 0.2f) : (num + 0.6f)));
			num += (float)citizen.Charisma * 0.05f;
			num = Mathf.Floor(num);
			if (UnityEngine.Random.Range(0f, 100f) < num)
			{
				citizen.Children = Mathf.Min(citizen.Children + 1, 5);
				int[] date = new int[3]
				{
					globalScript.gameState.data[19],
					globalScript.gameState.data[20],
					globalScript.gameState.data[21]
				};
				citizen.changeLog.Add(FormatLog(citizen, $"завёл ребёнка! Теперь детей: {citizen.Children}", $"had a child! Now has {citizen.Children}", date));
				Debug.Log($"{citizen.name} {citizen.surname} завёл ребёнка! Теперь детей: {citizen.Children}");
			}
		}
	}

	public void UpdateCitizenWealth(Persona citizen, int slot)
	{
		if (citizen != null)
		{
			float num = 0f;
			switch (citizen.status)
			{
			case Job.Unemployed:
			case Job.Prisoned:
				num -= 1f;
				break;
			case Job.Amnestied:
			case Job.Underground:
				num -= 0.25f;
				break;
			case Job.Worker:
			case Job.Peasant:
			case Job.Farmer:
				num += 0.25f;
				break;
			case Job.SmallBusinessOwner:
				num += 0.5f;
				break;
			case Job.CorporationOwner:
				num += 1f;
				break;
			case Job.LocalPartyBranchChief:
			case Job.RegionalPartyBranchChief:
				num += 0.75f;
				break;
			case Job.SignificantPartyMember:
				num += 1.25f;
				break;
			}
			int num2 = globalScript.gameState.data[5] / 10;
			if (num2 >= 0 && num2 <= 30)
			{
				num -= 0.5f;
			}
			else if (num2 >= 61 && num2 <= 85)
			{
				num += 0.25f;
			}
			else if (num2 >= 86)
			{
				num += 0.5f;
			}
			switch (globalScript.gameState.data[14])
			{
			case 0:
				num += ((citizen.status == Job.CorporationOwner || citizen.status == Job.SignificantPartyMember) ? 0.25f : (-0.25f));
				break;
			case 1:
				num = ((citizen.status != Job.Peasant && citizen.status != Job.Worker && citizen.status != Job.Farmer && citizen.status != Job.LocalPartyBranchChief && citizen.status != Job.RegionalPartyBranchChief && citizen.status != Job.SignificantPartyMember) ? (num - 0.25f) : (num + 0.25f));
				break;
			case 2:
				num = ((citizen.status != Job.Underground && citizen.status != Job.Amnestied && citizen.status != Job.Peasant && citizen.status != Job.Worker && citizen.status != Job.LocalPartyBranchChief && citizen.status != Job.RegionalPartyBranchChief && citizen.status != Job.SignificantPartyMember) ? (num - 0.25f) : (num + 0.25f));
				break;
			case 3:
				num = ((citizen.status != Job.Peasant && citizen.status != Job.Worker && citizen.status != Job.Farmer && citizen.status != Job.LocalPartyBranchChief && citizen.status != Job.RegionalPartyBranchChief && citizen.status != Job.SignificantPartyMember) ? (num - 0.5f) : (num + 0.5f));
				break;
			case 4:
				num = ((citizen.status != Job.Worker && citizen.status != Job.Farmer && citizen.status != Job.SmallBusinessOwner && citizen.status != Job.CorporationOwner && citizen.status != Job.SignificantPartyMember) ? (num - 0.25f) : (num + 0.25f));
				break;
			case 5:
				num += ((citizen.status == Job.SmallBusinessOwner || citizen.status == Job.CorporationOwner || citizen.status == Job.SignificantPartyMember) ? 0.5f : (-0.5f));
				break;
			}
			int num3 = globalScript.gameState.data[3];
			int num4 = globalScript.gameState.data[4];
			float num5 = (float)(1000 - num3 + num4) / 20f;
			if (num5 <= 30f)
			{
				num += 0.25f;
			}
			else if (num5 >= 71f)
			{
				num -= 0.5f;
			}
			if (citizen.Charisma >= 7)
			{
				num += 0.25f * (float)(citizen.Charisma - 6);
			}
			if (citizen.Intrigue >= 7)
			{
				num += 0.25f * (float)(citizen.Intrigue - 6);
			}
			int wealth = citizen.Wealth;
			citizen.Wealth = Mathf.Clamp(citizen.Wealth + Mathf.FloorToInt(num), 0, 15);
			if (wealth != citizen.Wealth)
			{
				int[] date = new int[3]
				{
					globalScript.gameState.data[19],
					globalScript.gameState.data[20],
					globalScript.gameState.data[21]
				};
				citizen.changeLog.Add(FormatLog(citizen, $"изменил благосостояние с {wealth} до {citizen.Wealth}", $"changed wealth from {wealth} to {citizen.Wealth}", date));
			}
			Debug.Log($"{citizen.name} {citizen.surname} обновил благосостояние: {citizen.Wealth} (изм: {num})");
		}
	}

	public void CheckCareerDegradation(Persona citizen, int slot)
	{
		if (citizen == null)
		{
			return;
		}
		int num = globalScript.gameState.data[3];
		int num2 = globalScript.gameState.data[4];
		float num3 = (float)(1000 - num + num2) / 20f;
		int[] date = new int[3]
		{
			globalScript.gameState.data[19],
			globalScript.gameState.data[20],
			globalScript.gameState.data[21]
		};
		_ = citizen.status;
		Debug.Log($"Недовольство {num3} ");
		bool num4 = citizen.Wealth == 0;
		bool flag = citizen.age >= 50 && citizen.Charisma + citizen.Intrigue < 2;
		if ((num4 || flag) && num3 > 80f)
		{
			int num5 = globalScript.gameState.data[14];
			bool num6 = num5 == 0 || num5 == 1;
			bool flag2 = num5 != 5 && num5 != 4;
			if (num6 && (citizen.status == Job.LocalPartyBranchChief || citizen.status == Job.RegionalPartyBranchChief || citizen.status == Job.SignificantPartyMember || citizen.status == Job.CorporationOwner))
			{
				citizen.status = Job.Prisoned;
				Debug.Log(citizen.name + " " + citizen.surname + " был посажен в тюрьму из-за критической деградации!");
				citizen.changeLog.Add(FormatLog(citizen, "был посажен в тюрьму из-за критической деградации!", "was imprisoned due to critical degradation!", date));
			}
			else if (citizen.status == Job.SmallBusinessOwner || citizen.status == Job.Farmer || citizen.status == Job.Worker)
			{
				citizen.status = Job.Unemployed;
				Debug.Log(citizen.name + " " + citizen.surname + " стал безработным из-за критической деградации!");
				citizen.changeLog.Add(FormatLog(citizen, "стал безработным из-за критической деградации!", "became unemployed due to critical degradation!", date));
			}
			else if (flag2 && citizen.Intrigue >= 7)
			{
				citizen.status = Job.Underground;
				Debug.Log(citizen.name + " " + citizen.surname + " ушёл в подполье из-за критической деградации!");
				citizen.changeLog.Add(FormatLog(citizen, "ушёл в подполье из-за критической деградации!", "went underground due to critical degradation!", date));
			}
		}
	}

	public void CheckSpecialStatuses(Persona citizen, int slot)
	{
		if (citizen != null && !citizen.isPolitic)
		{
			int num = globalScript.gameState.data[14];
			int num2 = globalScript.gameState.data[3];
			int num3 = globalScript.gameState.data[4];
			float num4 = (float)(1000 - num2 + num3) / 20f;
			bool flag = num == 0 || num == 1;
			bool flag2 = citizen.status == Job.Prisoned;
			int[] date = new int[3]
			{
				globalScript.gameState.data[19],
				globalScript.gameState.data[20],
				globalScript.gameState.data[21]
			};
			bool flag3 = flag || (citizen.Intrigue < 4 && (citizen.status == Job.LocalPartyBranchChief || citizen.status == Job.RegionalPartyBranchChief || citizen.status == Job.SignificantPartyMember || citizen.status == Job.SmallBusinessOwner || citizen.status == Job.CorporationOwner)) || (citizen.Wealth > 7 && num4 > 70f);
			if (flag3 && UnityEngine.Random.value < 0.2f && !flag2)
			{
				citizen.status = Job.Prisoned;
				Debug.Log($"{citizen.name} {citizen.surname} попал в тюрьму из-за политической обстановки! Шанс {flag3}%");
				citizen.changeLog.Add(FormatLog(citizen, "попал в тюрьму из-за политической обстановки!", "was imprisoned due to political situation!", date));
			}
			else if (((citizen.Intrigue >= 7 && (num == 1 || num == 2 || num == 3 || num == 0)) || num4 > 80f) && UnityEngine.Random.value < 0.1f && citizen.status != Job.Underground)
			{
				citizen.status = Job.Underground;
				Debug.Log(citizen.name + " " + citizen.surname + " ушёл в подполье из-за политической обстановки!");
				citizen.changeLog.Add(FormatLog(citizen, "ушёл в подполье из-за политической обстановки!", "went underground due to political situation!", date));
			}
			else if (flag2 && (!flag || num4 < 40f) && UnityEngine.Random.value < 0.2f)
			{
				Debug.Log($"{flag2} {flag} {num4} ");
				citizen.status = Job.Amnestied;
				Debug.Log(citizen.name + " " + citizen.surname + " был амнистирован!");
				citizen.changeLog.Add(FormatLog(citizen, "был амнистирован!", "was amnestied!", date));
			}
		}
	}

	public void CheckCareerPromotion(Persona citizen, int slot)
	{
		if (citizen == null)
		{
			return;
		}
		int num = globalScript.gameState.data[14];
		int num2 = globalScript.gameState.data[16];
		int num3 = globalScript.gameState.data[5] / 10;
		int num4 = globalScript.gameState.data[3];
		int num5 = globalScript.gameState.data[4];
		int[] date = new int[3]
		{
			globalScript.gameState.data[19],
			globalScript.gameState.data[20],
			globalScript.gameState.data[21]
		};
		_ = (float)(1000 - num4 + num5) / 20f;
		bool flag = num == 0 || num == 1;
		if (citizen.Wealth < 7 || (citizen.Charisma < 6 && citizen.Intrigue < 6) || citizen.age < 25 || citizen.age > 65)
		{
			return;
		}
		float num6 = 25f;
		if ((num == 2 || num == 3 || num == 1) && (citizen.status == Job.LocalPartyBranchChief || citizen.status == Job.RegionalPartyBranchChief))
		{
			num6 += 10f;
		}
		else if ((num == 4 || num == 5) && (citizen.status == Job.SmallBusinessOwner || citizen.status == Job.CorporationOwner))
		{
			num6 += 10f;
		}
		if (flag)
		{
			num6 += (float)citizen.Charisma / 10f * 10f;
		}
		if (num3 > 50 && (citizen.status == Job.SmallBusinessOwner || citizen.status == Job.CorporationOwner))
		{
			num6 += 10f;
		}
		else if (num3 <= 50 && (citizen.status != Job.SmallBusinessOwner || citizen.status != Job.CorporationOwner))
		{
			num6 += 10f;
		}
		if (citizen.Children >= 4 && citizen.Children <= 5)
		{
			if (citizen.Wealth <= 4)
			{
				if (UnityEngine.Random.value < 0.25f)
				{
					citizen.status = Job.Unemployed;
					Debug.Log(citizen.name + " " + citizen.surname + " потерял работу из-за бедности и большого количества детей!");
					citizen.changeLog.Add(FormatLog(citizen, "потерял работу из-за бедности и большого количества детей!", "lost job due to poverty and many children!", date));
					return;
				}
				num6 -= 10f;
			}
			if (citizen.Charisma >= 7)
			{
				num6 += (float)citizen.Charisma / 10f * 10f;
			}
		}
		if (!(UnityEngine.Random.Range(0f, 100f) < num6))
		{
			return;
		}
		Job status = citizen.status;
		switch (citizen.status)
		{
		case Job.Worker:
		case Job.Peasant:
		case Job.Farmer:
			if (num2 > 10 && num2 != 12)
			{
				citizen.status = Job.SmallBusinessOwner;
			}
			else if (citizen.status != Job.Farmer)
			{
				citizen.status = Job.LocalPartyBranchChief;
			}
			break;
		case Job.SmallBusinessOwner:
			citizen.status = Job.CorporationOwner;
			break;
		case Job.CorporationOwner:
			citizen.status = Job.CorporationOwner;
			break;
		case Job.LocalPartyBranchChief:
			citizen.status = Job.RegionalPartyBranchChief;
			break;
		case Job.RegionalPartyBranchChief:
			citizen.status = Job.SignificantPartyMember;
			break;
		case Job.Underground:
			if (!flag && citizen.Intrigue > 7)
			{
				citizen.status = Job.LocalPartyBranchChief;
			}
			break;
		}
		if (citizen.status != status)
		{
			Debug.Log($"{citizen.name} {citizen.surname} повысился по карьерной лестнице! Новая должность: {citizen.status}");
			citizen.changeLog.Add(FormatLog(citizen, "повысился по карьерной лестнице! Новая должность: " + translateScript.GetJobTranslation(citizen.status), "was promoted! New job: " + translateScript.GetJobTranslation(citizen.status), date));
		}
	}

	public void CheckUnemployedTransitions(Persona citizen, int slot)
	{
		if (citizen == null)
		{
			return;
		}
		int[] date = CurrentDate();
		if (citizen.status == Job.Amnestied)
		{
			if (UnityEngine.Random.value < 0.25f)
			{
				citizen.status = Job.Unemployed;
				citizen.changeLog.Add(FormatLog(citizen, "стал безработным после амнистии", "became unemployed after amnesty", date));
				Debug.Log(citizen.name + " " + citizen.surname + " transitioned from Amnestied to Unemployed");
			}
		}
		else
		{
			if (citizen.status != Job.Unemployed)
			{
				return;
			}
			int num = globalScript.gameState.data[14];
			_ = globalScript.gameState.data[16];
			int num2 = globalScript.gameState.data[5] / 10;
			int num3 = globalScript.gameState.data[3];
			int num4 = globalScript.gameState.data[4];
			float num5 = (float)(1000 - num3 + num4) / 20f;
			bool flag = num == 0 || num == 1 || num == 3;
			if (!(UnityEngine.Random.value > 0.25f))
			{
				List<Job> list = new List<Job>();
				if (citizen.Charisma >= 6 && citizen.age >= 20 && citizen.age <= 40 && num2 > 60)
				{
					list.Add(Job.Worker);
					list.Add(Job.Peasant);
					list.Add(Job.Farmer);
				}
				if (citizen.Intrigue >= 6 && num5 > 50f && flag)
				{
					list.Add(Job.Underground);
				}
				if (citizen.Wealth >= 6 && num2 > 70 && num == 5)
				{
					list.Add(Job.SmallBusinessOwner);
				}
				if (citizen.age > 40 && citizen.Children >= 3 && citizen.Charisma < 4 && citizen.Wealth < 3)
				{
					list.Add(Job.Peasant);
					list.Add(Job.Worker);
				}
				if (citizen.jobHistory.Contains(Job.Amnestied))
				{
					list.Add(Job.LocalPartyBranchChief);
					list.Add(Job.Worker);
				}
				if (num == 1 || num == 3 || num == 2)
				{
					list.Add(Job.Worker);
					list.Add(Job.Peasant);
					list.Add(Job.LocalPartyBranchChief);
				}
				if (list.Count > 0)
				{
					int index = UnityEngine.Random.Range(0, list.Count);
					citizen.status = list[index];
					Debug.Log($"{citizen.name} {citizen.surname} вышел из безработицы и теперь {citizen.status}");
					citizen.changeLog.Add(FormatLog(citizen, "вышел из безработицы и теперь " + translateScript.GetJobTranslation(citizen.status), "left unemployment and became " + translateScript.GetJobTranslation(citizen.status), date));
				}
			}
		}
	}

	public void CheckCareerPathTransitions(Persona citizen, int slot)
	{
		if (citizen == null || citizen.isPolitic)
		{
			return;
		}
		int num = globalScript.gameState.data[14];
		_ = globalScript.gameState.data[16];
		int num2 = globalScript.gameState.data[5] / 10;
		int num3 = globalScript.gameState.data[3];
		int num4 = globalScript.gameState.data[4];
		int[] date = new int[3]
		{
			globalScript.gameState.data[19],
			globalScript.gameState.data[20],
			globalScript.gameState.data[21]
		};
		float num5 = (float)(1000 - num3 + num4) / 20f;
		bool flag = num == 0 || num == 1;
		switch (citizen.status)
		{
		case Job.SmallBusinessOwner:
			if (citizen.Charisma >= 7 && citizen.Intrigue >= 6 && citizen.Wealth >= 6 && (num == 1 || num == 2 || num == 3))
			{
				citizen.status = Job.LocalPartyBranchChief;
				Debug.Log(citizen.name + " " + citizen.surname + " перешёл из бизнеса в партию (LocalPartyBranchChief)");
				citizen.changeLog.Add(FormatLog(citizen, "перешёл из бизнеса и теперь " + translateScript.GetJobTranslation(citizen.status), "switched from business and became " + translateScript.GetJobTranslation(citizen.status), date));
			}
			else if (flag && citizen.Intrigue < 4 && citizen.Charisma < 4 && num5 > 70f)
			{
				citizen.status = Job.Prisoned;
				Debug.Log(citizen.name + " " + citizen.surname + " был арестован как бизнесмен в авторитарном режиме");
				citizen.changeLog.Add(FormatLog(citizen, "был арестован как бизнесмен в авторитарном режиме", "was arrested as a businessman under authoritarian regime", date));
			}
			break;
		case Job.LocalPartyBranchChief:
			if ((num == 5 || num == 4) && citizen.Charisma >= 6 && citizen.Wealth >= 7)
			{
				citizen.status = Job.SmallBusinessOwner;
				Debug.Log(citizen.name + " " + citizen.surname + " перешёл из партии в бизнес (SmallBusinessOwner)");
				citizen.changeLog.Add(FormatLog(citizen, "перешёл из партии и теперь " + translateScript.GetJobTranslation(citizen.status), "switched from party and became " + translateScript.GetJobTranslation(citizen.status), date));
			}
			break;
		case Job.CorporationOwner:
			if ((num == 0 || num == 1 || num == 3) && citizen.Wealth >= 9 && citizen.Charisma >= 6)
			{
				citizen.status = Job.SignificantPartyMember;
				Debug.Log(citizen.name + " " + citizen.surname + " перешёл от корпорации к значимой роли в партии (SignificantPartyMember)");
				citizen.changeLog.Add(FormatLog(citizen, "перешёл от корпорации к " + translateScript.GetJobTranslation(citizen.status), "switched from corporation to " + translateScript.GetJobTranslation(citizen.status), date));
			}
			break;
		case Job.RegionalPartyBranchChief:
			if (num == 5 && num2 > 80 && citizen.Wealth >= 8 && citizen.age < 45)
			{
				citizen.status = Job.CorporationOwner;
				Debug.Log(citizen.name + " " + citizen.surname + " перешёл из регионального партийного начальника в корпорацию (CorporationOwner)");
				citizen.changeLog.Add(FormatLog(citizen, "перешёл из регионального партийного начальника к " + translateScript.GetJobTranslation(citizen.status), "moved from regional party chief to " + translateScript.GetJobTranslation(citizen.status), date));
			}
			break;
		case Job.Underground:
			if (citizen.Intrigue >= 8 && (num == 4 || num == 5 || num5 < 50f))
			{
				citizen.status = Job.LocalPartyBranchChief;
				Debug.Log(citizen.name + " " + citizen.surname + " был реабилитирован и стал LocalPartyBranchChief");
				citizen.changeLog.Add(FormatLog(citizen, "был реабилитирован и стал " + translateScript.GetJobTranslation(citizen.status), "was rehabilitated and became " + translateScript.GetJobTranslation(citizen.status), date));
			}
			break;
		case Job.Worker:
		case Job.Farmer:
			if (num2 > 60 && citizen.Wealth >= 6 && citizen.age < 50 && !flag)
			{
				citizen.status = Job.SmallBusinessOwner;
				Debug.Log(citizen.name + " " + citizen.surname + " перешёл в малый бизнес (SmallBusinessOwner)");
				citizen.changeLog.Add(FormatLog(citizen, "перешёл в " + translateScript.GetJobTranslation(citizen.status), "switched to " + translateScript.GetJobTranslation(citizen.status), date));
			}
			break;
		case Job.Peasant:
			if ((num == 1 || num == 3 || num == 2) && citizen.Wealth >= 4 && citizen.age > 30 && citizen.Children >= 2)
			{
				citizen.status = Job.LocalPartyBranchChief;
				Debug.Log(citizen.name + " " + citizen.surname + " пошёл в местные партийные начальники (LocalPartyBranchChief)");
				citizen.changeLog.Add(FormatLog(citizen, "пошёл в " + translateScript.GetJobTranslation(citizen.status), "went to " + translateScript.GetJobTranslation(citizen.status), date));
			}
			break;
		case Job.SignificantPartyMember:
			if (num5 > 80f && citizen.Intrigue >= 8 && citizen.Charisma < 5 && flag)
			{
				citizen.status = Job.Underground;
				Debug.Log(citizen.name + " " + citizen.surname + " ушёл в подполье из-за репрессий (Underground)");
				citizen.changeLog.Add(FormatLog(citizen, "ушёл в подполье из-за репрессий", "went underground due to repression", date));
			}
			break;
		case Job.Prisoned:
		case Job.Amnestied:
			break;
		}
	}

	public void CheckCitizenDeath(Persona citizen, int slot)
	{
		if (citizen != null)
		{
			int num = globalScript.gameState.data[14];
			int num2 = globalScript.gameState.data[5] / 10;
			int num3 = globalScript.gameState.data[3];
			int num4 = globalScript.gameState.data[4];
			int[] currentDate = new int[3]
			{
				globalScript.gameState.data[19],
				globalScript.gameState.data[20],
				globalScript.gameState.data[21]
			};
			float num5 = (float)(1000 - num3 + num4) / 20f;
			float num6 = 0f;
			Debug.Log($"{num6}% Начальный шанс для {citizen.name} {citizen.surname}, возраст {citizen.age}");
			num6 = ((citizen.age < 40) ? 0.5f : ((citizen.age < 50) ? 1f : ((citizen.age < 60) ? 3f : ((citizen.age < 70) ? 7f : ((citizen.age >= 80) ? 25f : 12f)))));
			Debug.Log($"Базовый шанс по возрасту: {num6}%");
			if (num2 <= 30)
			{
				num6 += 5f;
			}
			else if (num2 <= 60)
			{
				num6 += 2f;
			}
			else if (num2 >= 86)
			{
				num6 -= 1f;
			}
			Debug.Log($"Шанс после Уровня жизни: {num6}%");
			if (num5 >= 80f)
			{
				num6 += 5f;
			}
			else if (num5 >= 50f)
			{
				num6 += 2f;
			}
			Debug.Log($"Шанс после Народные недовольства: {num6}%");
			if (num == 0 && (citizen.Intrigue > 6 || citizen.status == Job.Underground || citizen.status == Job.Amnestied))
			{
				num6 += 4f;
			}
			if ((num == 1 || num == 2) && (citizen.Wealth > 7 || citizen.status == Job.SmallBusinessOwner || citizen.status == Job.CorporationOwner))
			{
				num6 += 4f;
			}
			if (num == 3 && (citizen.Intrigue > 7 || citizen.status == Job.SignificantPartyMember))
			{
				num6 += 2f;
			}
			if (num == 1 && citizen.status == Job.CorporationOwner)
			{
				num6 += 2f;
			}
			if ((num == 4 || num == 5) && (citizen.status == Job.Peasant || citizen.status == Job.Worker))
			{
				num6 += 2f;
			}
			Debug.Log($"Шанс после Госстрой: {num6}%");
			if (citizen.Wealth <= 2)
			{
				num6 += 4f;
			}
			else if (citizen.Wealth >= 3 && citizen.Wealth <= 5)
			{
				num6 += 2f;
			}
			else if (citizen.Wealth >= 9)
			{
				num6 -= 1f;
			}
			Debug.Log($"Шанс после Благосостояние {num6}%");
			if (citizen.Intrigue >= 8)
			{
				num6 += 2f;
			}
			if (citizen.Charisma >= 8)
			{
				num6 -= 2f;
			}
			num6 -= (float)citizen.Children;
			Debug.Log($"Шанс после Личные характеристики {num6}%");
			if (citizen.status == Job.Prisoned)
			{
				num6 += 15f;
			}
			else if (citizen.status == Job.Underground)
			{
				num6 += 10f;
			}
			else if (citizen.status == Job.Amnestied)
			{
				num6 += 4f;
			}
			else if (citizen.status == Job.Worker || citizen.status == Job.Peasant)
			{
				num6 += (float)(num2 * 10) / 1000f;
				Debug.Log($"Шанс смерти у воркера и крестьянина был {num6}% а уровень жизни {num2}");
			}
			else if (citizen.status == Job.LocalPartyBranchChief || citizen.status == Job.RegionalPartyBranchChief || citizen.status == Job.SignificantPartyMember)
			{
				num6 -= 2f;
			}
			Debug.Log($"Шанс после Опасная работа {num6}%");
			num6 = Mathf.Max(num6, 0.1f);
			Debug.Log($"После ограничения мин. 0.1%: {num6}%");
			num6 /= 2f;
			Debug.Log($"После деления на 2: {num6}%");
			if (citizen.age < 30)
			{
				num6 /= 4f;
			}
			if (UnityEngine.Random.Range(0f, 100f) < num6)
			{
				Debug.Log($"{citizen.name} {citizen.surname} умер, возраст {citizen.age}, финальный шанс: {num6}%");
				HandleCitizenDeath(citizen, slot, num6, currentDate);
			}
		}
	}

	private void TryRandomForeignContact(Persona citizen, int slot)
	{
		if (globalScript.gameState.data[14] == 5 && citizen.Charisma > 6 && citizen.Intrigue < 6 && !(UnityEngine.Random.value > 0.03f))
		{
			citizen.Intrigue = Mathf.Min(citizen.Intrigue + 1, 15);
			int[] date = CurrentDate();
			citizen.changeLog.Add(FormatLog(citizen, "познакомился с иностранцем, узнал новое", "met a foreigner, gained new insights", date));
			if (!citizen.tertiaryTraits.Contains(TertiaryTrait.Westophilic) && UnityEngine.Random.value < 0.05f)
			{
				citizen.tertiaryTraits.Add(TertiaryTrait.Westophilic);
				citizen.changeLog.Add(FormatLog(citizen, "проникся западными ценностями", "became sympathetic to western values", date));
			}
		}
	}

	private void StartSurveillanceEvent(Persona citizen, int slot)
	{
		citizen.changeLog.Add(FormatLog(citizen, "стал объектом слежки из-за подозрительно высоких доходов", "became subject to surveillance due to suspiciously high income", CurrentDate()));
		CitizenEvent citizenEvent = _citizenEvents[slot].Find((CitizenEvent e) => e.ChainId == "SurveillanceChain");
		if (citizenEvent != null)
		{
			citizenEvent.EventData["initialWealth"] = citizen.Wealth;
		}
	}

	private void EndSurveillanceEvent(Persona citizen, int slot)
	{
		CitizenEvent citizenEvent = _citizenEvents[slot].Find((CitizenEvent e) => e.ChainId == "SurveillanceChain");
		if (citizenEvent == null || !citizenEvent.EventData.ContainsKey("initialWealth"))
		{
			return;
		}
		int num = (int)citizenEvent.EventData["initialWealth"];
		int wealth = citizen.Wealth;
		if (wealth < num)
		{
			citizen.changeLog.Add(FormatLog(citizen, "слежка прекращена, так как его доходы снизились", "surveillance ended as his income decreased", CurrentDate()));
		}
		else if (wealth > num)
		{
			if (UnityEngine.Random.value < 0.5f)
			{
				if (citizen.isPolitic || citizen.status == Job.SignificantPartyMember || citizen.status == Job.RegionalPartyBranchChief || citizen.status == Job.LocalPartyBranchChief)
				{
					citizen.Wealth = Mathf.Max(citizen.Wealth - 4, 0);
					citizen.changeLog.Add(FormatLog(citizen, "стал фигурантом коррупционного скандала, но смог выкрутиться без серьезных последствий", "became involved in a corruption scandal but was able to get out without serious consequences", CurrentDate()));
				}
				else
				{
					citizen.Wealth = Mathf.Max(citizen.Wealth - 3, 0);
					citizen.status = Job.Prisoned;
					citizen.changeLog.Add(FormatLog(citizen, "был арестован по подозрению в коррупции и потерял часть состояния", "was arrested on corruption charges and lost part of his wealth", CurrentDate()));
				}
			}
			else
			{
				citizen.changeLog.Add(FormatLog(citizen, "слежка завершена без последствий", "surveillance ended without consequences", CurrentDate()));
			}
		}
		_citizenEvents[slot].Remove(citizenEvent);
	}

	public void TriggerSurveillanceChain(int slot)
	{
		Persona persona = globalScript.gameState.citizens[slot];
		if (persona != null && !persona.isDead && !persona.isLead)
		{
			int[] array = CurrentDate();
			CitizenEvent item = new CitizenEvent
			{
				EventName = "StartSurveillance",
				PeriodMonths = 0,
				EventAction = StartSurveillanceEvent,
				NextTriggerDate = array,
				IsChainEvent = true,
				ChainId = "SurveillanceChain",
				EventData = new Dictionary<string, object>()
			};
			CitizenEvent item2 = new CitizenEvent
			{
				EventName = "EndSurveillance",
				PeriodMonths = 6,
				EventAction = EndSurveillanceEvent,
				NextTriggerDate = CalculateNextTriggerDate(array, 6),
				IsChainEvent = true,
				ChainId = "SurveillanceChain",
				EventData = new Dictionary<string, object>()
			};
			_citizenEvents[slot].Add(item);
			_citizenEvents[slot].Add(item2);
		}
	}

	private void CheckIncomeForSurveillance(Persona citizen, int slot)
	{
		CitizenEvent citizenEvent = _citizenEvents[slot].Find((CitizenEvent e) => e.EventName == "CheckIncomeForSurveillance");
		if (citizenEvent != null)
		{
			int num = 0;
			num = ((!citizenEvent.EventData.ContainsKey("lastWealth")) ? citizen.Wealth : ((int)citizenEvent.EventData["lastWealth"]));
			int num2 = citizen.Wealth - num;
			citizenEvent.EventData["lastWealth"] = citizen.Wealth;
			if (num2 > 5 && !_citizenEvents[slot].Exists((CitizenEvent e) => e.ChainId == "SurveillanceChain"))
			{
				TriggerSurveillanceChain(slot);
				Debug.Log($"Сработал триггер слежки для {citizen.name} {citizen.surname}: доход за 3 месяца {num2} > {5}");
			}
		}
	}

	private void PartyPurgeEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[14];
		int num2 = globalScript.gameState.data[3];
		int num3 = globalScript.gameState.data[4];
		float num4 = (float)(1000 - num2 + num3) / 20f;
		int[] date = CurrentDate();
		if ((num != 0 && num != 1 && num != 3) || num4 <= 60f || (citizen.status != Job.LocalPartyBranchChief && citizen.status != Job.RegionalPartyBranchChief && citizen.status != Job.SignificantPartyMember) || (citizen.Intrigue < 6 && citizen.Charisma < 6))
		{
			return;
		}
		float num5 = 0.03f;
		if (UnityEngine.Random.value > num5)
		{
			return;
		}
		float num6 = (citizen.tertiaryTraits.Contains(TertiaryTrait.Schemer) ? 0.7f : 0.5f);
		float num7 = 0.4f;
		float value = UnityEngine.Random.value;
		if (value < num6)
		{
			if (UnityEngine.Random.value < 0.5f)
			{
				citizen.Charisma = Mathf.Min(citizen.Charisma + 1, 10);
			}
			else
			{
				citizen.Intrigue = Mathf.Min(citizen.Intrigue + 1, 10);
			}
			citizen.Wealth = Mathf.Min(citizen.Wealth + 1, 15);
			citizen.changeLog.Add(FormatLog(citizen, "поддержал партийную чистку, укрепив своё положение в партии.", "supported the party purge, strengthening their position.", date));
			Debug.Log(citizen.name + " " + citizen.surname + " успешно поддержал партийную чистку.");
		}
		else if (value < num6 + num7 && !citizen.isPolitic)
		{
			citizen.Wealth = Mathf.Max(citizen.Wealth - 2, 0);
			if (UnityEngine.Random.value < 0.5f)
			{
				citizen.status = Job.Prisoned;
			}
			else
			{
				citizen.status = Job.Underground;
			}
			citizen.changeLog.Add(FormatLog(citizen, "обвинён в саботаже во время чистки и арестован.", "was accused of sabotage during the purge and arrested.", date));
			Debug.Log(citizen.name + " " + citizen.surname + " провалил чистку и был репрессирован.");
		}
		else
		{
			citizen.changeLog.Add(FormatLog(citizen, "уклонился от участия в чистке, сохранив нейтралитет.", "avoided participation in the purge, remaining neutral.", date));
			Debug.Log(citizen.name + " " + citizen.surname + " уклонился от участия в чистке.");
		}
	}

	private void EconomicReformEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[14];
		int num2 = globalScript.gameState.data[4];
		int num3 = globalScript.gameState.data[21];
		bool num4 = num == 4 || num == 5 || num2 > 500;
		bool flag = citizen.status == Job.Worker || citizen.status == Job.Peasant || citizen.status == Job.Farmer || citizen.status == Job.Unemployed;
		bool flag2 = citizen.Wealth >= 4 && citizen.Charisma >= 5;
		bool flag3 = num3 >= 1978;
		if (num4 && flag && flag2 && flag3 && UnityEngine.Random.value < 0.15f)
		{
			float value = UnityEngine.Random.value;
			int[] date = CurrentDate();
			if (value < 0.6f)
			{
				citizen.status = Job.SmallBusinessOwner;
				citizen.Wealth += 2;
				citizen.changeLog.Add(FormatLog(citizen, "воспользовался реформами и открыл малый бизнес.", "took advantage of reforms and started a small business.", date));
			}
			else if (value < 0.9f)
			{
				citizen.Wealth = Mathf.Max(0, citizen.Wealth - 1);
				citizen.changeLog.Add(FormatLog(citizen, "попытался открыть бизнес, но потерпел неудачу.", "tried to start a business but failed.", date));
			}
			else if (num == 0 || num == 1)
			{
				citizen.status = Job.Prisoned;
				citizen.changeLog.Add(FormatLog(citizen, "обвинён в капиталистическом уклоне и арестован.", "was accused of capitalist tendencies and imprisoned.", date));
			}
			else
			{
				citizen.Wealth = Mathf.Max(0, citizen.Wealth - 1);
				citizen.changeLog.Add(FormatLog(citizen, "попытался открыть бизнес, но потерпел неудачу.", "tried to start a business but failed.", date));
			}
		}
	}

	private void RuralCrisisEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[5] / 10;
		int num2 = globalScript.gameState.data[14];
		int[] date = CurrentDate();
		if ((citizen.status != Job.Peasant && citizen.status != Job.Farmer) || num >= 50 || !(UnityEngine.Random.value < 0.1f))
		{
			return;
		}
		float value = UnityEngine.Random.value;
		if (value < 0.5f)
		{
			int wealth = citizen.Wealth;
			citizen.Wealth = Mathf.Max(citizen.Wealth - 2, 0);
			citizen.changeLog.Add(FormatLog(citizen, $"потерял средства к существованию из-за неурожая (было {wealth}, стало {citizen.Wealth})", $"Lost his livelihood due to crop failure (was {wealth}, now {citizen.Wealth})", date));
			if (citizen.Wealth == 0 && UnityEngine.Random.value < 0.5f)
			{
				citizen.status = Job.Unemployed;
				citizen.changeLog.Add(FormatLog(citizen, "стал безработным из-за разорения", "became unemployed due to bankruptcy", date));
			}
		}
		else if (value < 0.8f)
		{
			if (num2 == 2 || num2 == 3)
			{
				citizen.Wealth = Mathf.Min(citizen.Wealth + 1, 15);
				citizen.changeLog.Add(FormatLog(citizen, "получил помощь от государства в условиях кризиса из-за неурожая", "received help from the state during the crisis due to crop failure", date));
			}
		}
		else
		{
			citizen.status = Job.Worker;
			int wealth2 = citizen.Wealth;
			citizen.Wealth = Mathf.Max(citizen.Wealth - 1, 0);
			citizen.changeLog.Add(FormatLog(citizen, $"переехал в город в поисках работы (было {wealth2}, стало {citizen.Wealth})", $"moved to the city in search of work (was {wealth2}, now {citizen.Wealth})", date));
		}
	}

	private void BadDealEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[14];
		if (citizen != null)
		{
			bool flag = citizen.status == Job.SmallBusinessOwner || citizen.status == Job.CorporationOwner;
			if (citizen.Wealth >= 6 && flag && (num == 4 || num == 5) && UnityEngine.Random.value < 0.1f)
			{
				int num2 = UnityEngine.Random.Range(1, 4);
				int wealth = citizen.Wealth;
				citizen.Wealth = Mathf.Max(0, citizen.Wealth - num2);
				int[] date = CurrentDate();
				citizen.changeLog.Add(FormatLog(citizen, $"потерял деньги из-за неудачной сделки с поставщиками (−{num2})", $"lost money due to a bad deal with suppliers (−{num2})", date));
				Debug.Log($"{citizen.name} {citizen.surname} потерял {num2} богатства из-за неудачной сделки ({wealth} → {citizen.Wealth})");
			}
		}
	}

	private void ShadowIncomeEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[14];
		if (citizen != null && !citizen.isDead && !citizen.isLead && citizen.Intrigue >= 7 && citizen.Wealth >= 5 && (num == 0 || num == 1 || num == 3) && UnityEngine.Random.value < 0.15f)
		{
			int num2 = UnityEngine.Random.Range(1, 5);
			citizen.Wealth = Mathf.Clamp(citizen.Wealth + num2, 0, 15);
			int[] date = CurrentDate();
			citizen.changeLog.Add(FormatLog(citizen, $"получил крупный доход через связи в партии (+{num2})", $"received a large income through party connections (+{num2})", date));
			if (UnityEngine.Random.value < 0.3f)
			{
				TriggerSurveillanceChain(slot);
			}
		}
	}

	private void StateContractEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[21];
		int num2 = globalScript.gameState.data[14];
		if (num >= 1978 && num2 == 3 && (citizen.status == Job.SmallBusinessOwner || citizen.status == Job.CorporationOwner) && citizen.Charisma >= 6 && UnityEngine.Random.value < 0.2f)
		{
			int num3 = UnityEngine.Random.Range(1, 3);
			citizen.Wealth = Mathf.Clamp(citizen.Wealth + num3, 0, 15);
			int[] date = CurrentDate();
			citizen.changeLog.Add(FormatLog(citizen, $"подписал выгодный контракт с государственным предприятием (+{num3} к благосостоянию)", $"signed a lucrative contract with a state enterprise (+{num3} wealth)", date));
			Debug.Log($"{citizen.name} {citizen.surname} получил гос. контракт (+{num3} Wealth)");
		}
	}

	private void FamilyScandalEvent(Persona citizen, int slot)
	{
		if (citizen != null && !citizen.isDead && citizen.Children >= 2 && citizen.Wealth >= 7 && citizen.status == Job.SignificantPartyMember && !(UnityEngine.Random.value > 0.05f))
		{
			int[] date = CurrentDate();
			int charisma = citizen.Charisma;
			citizen.Charisma = Mathf.Max(0, citizen.Charisma - 1);
			bool flag = false;
			if (UnityEngine.Random.value < 0.3f)
			{
				int wealth = citizen.Wealth;
				citizen.Wealth = Mathf.Max(0, citizen.Wealth - 1);
				flag = wealth != citizen.Wealth;
			}
			string text = "оказался в центре семейного скандала, что подорвало его авторитет";
			string text2 = "was at the center of a family scandal, which undermined his authority";
			if (flag)
			{
				text += ", и потерял часть состояния";
				text2 += ", and lost part of his wealth";
			}
			citizen.changeLog.Add(FormatLog(citizen, text, text2, date));
			Debug.Log($"{citizen.name} {citizen.surname} попал в семейный скандал: charisma {charisma}->{citizen.Charisma}, wealth {citizen.Wealth}");
		}
	}

	private void RumorOfConspiracyEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[14];
		if (citizen.Intrigue >= 8 && (num == 0 || num == 1) && UnityEngine.Random.value < 0.1f)
		{
			int[] date = CurrentDate();
			citizen.changeLog.Add(FormatLog(citizen, "по слухам, замешан в антиправительственном заговоре, но доказательств нет.", "rumored to be involved in an anti-government conspiracy, but there is no evidence.", date));
			Debug.Log(citizen.name + " " + citizen.surname + ": Слухи о заговоре (но без последствий)");
		}
	}

	private void InvestInProductionEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[14];
		int num2 = globalScript.gameState.data[5] / 10;
		if ((num == 3 || num == 4 || num == 5) && citizen.status == Job.CorporationOwner && citizen.Wealth >= 10 && num2 < 70 && UnityEngine.Random.value < 0.1f)
		{
			citizen.Wealth = Mathf.Max(citizen.Wealth - 2, 0);
			globalScript.gameState.data[5] = 100;
			int[] date = CurrentDate();
			citizen.changeLog.Add(FormatLog(citizen, "инвестировал в местное производство, улучшив жизнь населения.", "invested in local production, improving the population's living standard.", date));
			Debug.Log($"{citizen.name} {citizen.surname} инвестировал в местное производство! Wealth теперь {citizen.Wealth}, уровень жизни {globalScript.gameState.data[5]}");
		}
	}

	private void ForbiddenLiteratureEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[14];
		int num2 = globalScript.gameState.data[17];
		int[] date = CurrentDate();
		bool flag = num == 0 || num == 1 || num == 2;
		bool flag2 = num2 == 16 || num2 == 17;
		bool flag3 = citizen.age <= 40;
		bool flag4 = citizen.Intrigue >= 6;
		if (citizen == null || citizen.isDead || !flag || !flag2 || !flag3 || !flag4 || citizen.isPolitic || UnityEngine.Random.value > 0.05f)
		{
			return;
		}
		if (UnityEngine.Random.value < 0.7f)
		{
			if (!citizen.tertiaryTraits.Contains(TertiaryTrait.Westophilic))
			{
				citizen.tertiaryTraits.Add(TertiaryTrait.Westophilic);
			}
			citizen.changeLog.Add(FormatLog(citizen, "тайно читал западную литературу, проникся новыми идеями.", "secretly read Western literature, inspired by new ideas.", date));
		}
		else
		{
			citizen.status = Job.Prisoned;
			citizen.changeLog.Add(FormatLog(citizen, "пойман за чтением запрещённой литературы!", "сaught reading forbidden literature!", date));
		}
	}

	private void TryCorruptionEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[26];
		_ = globalScript.gameState.data[5] / 10;
		bool num2 = citizen.status == Job.SignificantPartyMember || citizen.status == Job.RegionalPartyBranchChief || citizen.status == Job.CorporationOwner;
		bool flag = citizen.tertiaryTraits.Contains(TertiaryTrait.Peculator) || citizen.tertiaryTraits.Contains(TertiaryTrait.Schemer);
		if (num2 && num >= 60 && citizen.Intrigue >= 6 && flag && !(UnityEngine.Random.value > 0.1f))
		{
			int[] date = CurrentDate();
			if (UnityEngine.Random.value < 0.7f)
			{
				citizen.Wealth += 2;
				globalScript.gameState.data[26] += 5;
				globalScript.gameState.data[5] = Mathf.Max(globalScript.gameState.data[5] - 50, 0);
				citizen.changeLog.Add(FormatLog(citizen, "тайно присвоил государственные средства.", "secretly embezzled state funds.", date));
			}
			else
			{
				globalScript.gameState.data[26] += 3;
				citizen.changeLog.Add(FormatLog(citizen, "тайно присвоил государственные средства", "secretly embezzled state funds.", date));
				TriggerSurveillanceChain(slot);
			}
		}
	}

	private void BribeForPromotionOrProtection(Persona citizen, int slot)
	{
		if (citizen == null || citizen.isPolitic || (citizen.status != Job.LocalPartyBranchChief && citizen.status != Job.RegionalPartyBranchChief) || globalScript.gameState.data[26] < 50 || citizen.Wealth < 5 || citizen.Intrigue < 5 || UnityEngine.Random.value > 0.1f)
		{
			return;
		}
		int[] date = CurrentDate();
		float value = UnityEngine.Random.value;
		if (value < 0.5f)
		{
			_ = citizen.status;
			if (citizen.status == Job.LocalPartyBranchChief)
			{
				citizen.status = Job.RegionalPartyBranchChief;
			}
			else if (citizen.status == Job.RegionalPartyBranchChief)
			{
				citizen.status = Job.SignificantPartyMember;
			}
			citizen.Wealth = -2;
			string text = "заплатил взятку за повышение в партии.";
			string actionEn = "paid a bribe for promotion in the party.";
			citizen.changeLog.Add(FormatLog(citizen, text, actionEn, date));
			Debug.Log(citizen.name + " " + citizen.surname + " " + text);
		}
		else if (value < 0.8f)
		{
			citizen.Wealth = Mathf.Max(citizen.Wealth - 2, 0);
			globalScript.gameState.data[3] = Mathf.Max(globalScript.gameState.data[3] - 5, 0);
			string text = "попытался дать взятку, но был разоблачён.";
			string actionEn = "attempted to bribe but was exposed.";
			citizen.changeLog.Add(FormatLog(citizen, text, actionEn, date));
			Debug.Log(citizen.name + " " + citizen.surname + " " + text);
		}
		else
		{
			citizen.status = Job.Prisoned;
			citizen.Wealth = Mathf.Max(citizen.Wealth - 3, 0);
			globalScript.gameState.data[3] = Mathf.Max(globalScript.gameState.data[3] - 10, 0);
			string text = "арестован за попытку дачи взятки.";
			string actionEn = "was arrested for attempting to bribe.";
			citizen.changeLog.Add(FormatLog(citizen, text, actionEn, date));
			Debug.Log(citizen.name + " " + citizen.surname + " " + text);
		}
	}

	private void ProtestEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[3];
		int num2 = globalScript.gameState.data[4];
		bool num3 = (float)(1000 - num + num2) / 20f > 80f;
		bool flag = citizen.primaryTrait == PrimaryTrait.LeftRadical || citizen.primaryTrait == PrimaryTrait.Liberal || citizen.Intrigue >= 6;
		bool flag2 = citizen.status == Job.Worker || citizen.status == Job.Peasant || citizen.status == Job.Unemployed || citizen.status == Job.Underground;
		if (num3 && flag && flag2 && UnityEngine.Random.value < 0.1f)
		{
			float value = UnityEngine.Random.value;
			int[] date = CurrentDate();
			if (value < 0.5f)
			{
				citizen.status = Job.Prisoned;
				citizen.changeLog.Add(FormatLog(citizen, "был арестован за участие в протестах!", "was arrested for participating in protests!", date));
			}
			else if (value < 0.8f)
			{
				citizen.status = Job.Underground;
				citizen.Intrigue = Mathf.Min(citizen.Intrigue + 1, 10);
				citizen.changeLog.Add(FormatLog(citizen, "ушёл в подполье после участия в протестах.", "went underground after participating in protests.", date));
			}
			else
			{
				citizen.changeLog.Add(FormatLog(citizen, "участвовал в протестах, но избежал последствий.", "participated in protests but avoided consequences.", date));
			}
		}
	}

	private void CheckFalseAccusationEvent(Persona citizen, int slot)
	{
		int num = globalScript.gameState.data[14];
		int num2 = globalScript.gameState.data[17];
		if ((num == 0 || num2 == 16) && citizen.Intrigue < 3 && citizen.Charisma < 4 && !citizen.isPolitic && UnityEngine.Random.value < 0.05f)
		{
			int[] date = CurrentDate();
			if (UnityEngine.Random.value < 0.6f)
			{
				citizen.Charisma = Mathf.Min(citizen.Charisma + 1, 10);
				citizen.changeLog.Add(FormatLog(citizen, "оправдался перед следствием, доказал невиновность.", "was cleared of charges and proved innocence.", date));
			}
			else
			{
				citizen.status = Job.Prisoned;
				citizen.Wealth = Mathf.Max(citizen.Wealth - 1, 0);
				citizen.changeLog.Add(FormatLog(citizen, "попал под арест по ложному обвинению.", "was imprisoned on false charges.", date));
			}
		}
	}

	private void DoubtIdeologyEvent(Persona citizen, int slot)
	{
		if ((citizen.primaryTrait == PrimaryTrait.LeftRadical || citizen.primaryTrait == PrimaryTrait.Reformist) && globalScript.gameState.data[5] < 300 && UnityEngine.Random.value < 0.2f)
		{
			citizen.primaryTrait = PrimaryTrait.Moderate;
			int[] date = CurrentDate();
			citizen.changeLog.Add(FormatLog(citizen, "начал сомневаться в своих убеждениях.", "started to doubt their beliefs.", date));
			Debug.Log(citizen.name + " " + citizen.surname + " начал сомневаться в своих убеждениях и стал умеренным.");
		}
	}

	private void PraiseAtOfficialEvents(Persona citizen, int slot)
	{
		if (citizen.Charisma >= 8 && globalScript.gameState.data[3] >= 700 && !citizen.tertiaryTraits.Contains(TertiaryTrait.Idol) && citizen.status == Job.RegionalPartyBranchChief && !(UnityEngine.Random.value > 0.1f))
		{
			citizen.Wealth = Mathf.Min(citizen.Wealth + 1, 15);
			if (!citizen.tertiaryTraits.Contains(TertiaryTrait.Idol) && UnityEngine.Random.value < 0.3f)
			{
				citizen.tertiaryTraits.Add(TertiaryTrait.Idol);
			}
			int[] date = CurrentDate();
			citizen.changeLog.Add(FormatLog(citizen, "стал любимцем местных властей и народа.", "became a favorite of local authorities and people.", date));
			Debug.Log(citizen.name + " " + citizen.surname + " стал любимцем местных властей и народа!");
		}
	}

	private void ScheduleCitizenEvents(int slot, Persona citizen)
	{
		_citizenEvents[slot].Clear();
		List<(string, int, Action<Persona, int>)> obj = new List<(string, int, Action<Persona, int>)>
		{
			("BadDealEvent", 12, BadDealEvent),
			("FamilyScandalEvent", 12, FamilyScandalEvent),
			("InvestInProductionEvent", 12, InvestInProductionEvent),
			("CheckFalseAccusationEvent", 12, CheckFalseAccusationEvent),
			("PraiseAtOfficialEvents", 12, PraiseAtOfficialEvents),
			("StateContractEvent", 12, StateContractEvent),
			("RumorOfConspiracy", 9, RumorOfConspiracyEvent),
			("CheckForChildren", 9, CheckForChildren),
			("ShadowIncomeEvent", 8, ShadowIncomeEvent),
			("EconomicReformEvent", 8, EconomicReformEvent),
			("DoubtIdeologyEvent", 8, DoubtIdeologyEvent),
			("ForbiddenLiteratureEvent", 7, ForbiddenLiteratureEvent),
			("PartyPurgeEvent", 7, PartyPurgeEvent),
			("ProtestEvent", 7, ProtestEvent),
			("RuralCrisisEvent", 6, RuralCrisisEvent),
			("UpdateCitizenWealth", 6, UpdateCitizenWealth),
			("TryCorruptionEvent", 6, TryCorruptionEvent),
			("BribeForPromotionOrProtection", 6, BribeForPromotionOrProtection),
			("TryRandomForeignContact", 4, TryRandomForeignContact),
			("CheckCareerDegradation", 3, CheckCareerDegradation),
			("CheckSpecialStatuses", 3, CheckSpecialStatuses),
			("CheckCareerPromotion", 3, CheckCareerPromotion),
			("CheckUnemployedTransitions", 3, CheckUnemployedTransitions),
			("CheckCareerPathTransitions", 3, CheckCareerPathTransitions),
			("CheckCitizenDeath", 3, CheckCitizenDeath),
			("CheckIncomeForSurveillance", 3, CheckIncomeForSurveillance)
		};
		int[] currentDate = CurrentDate();
		foreach (var item in obj)
		{
			int[] nextTriggerDate = CalculateNextTriggerDate(currentDate, item.Item2);
			_citizenEvents[slot].Add(new CitizenEvent
			{
				EventName = item.Item1,
				PeriodMonths = item.Item2,
				EventAction = item.Item3,
				NextTriggerDate = nextTriggerDate,
				IsChainEvent = false,
				ChainId = null,
				EventData = new Dictionary<string, object>()
			});
		}
	}

	private void CheckCitizenEvents()
	{
		int num = globalScript.gameState.data[19];
		int num2 = globalScript.gameState.data[20];
		int num3 = globalScript.gameState.data[21];
		int[] array = new int[3] { num, num2, num3 };
		UpdateAges();
		for (int i = 0; i < 3; i++)
		{
			Persona persona = globalScript.gameState.citizens[i];
			if (persona == null || persona.isDead || persona.isLead)
			{
				continue;
			}
			if (_citizenEvents[i].Count != 0)
			{
				_ = _citizenEvents[i].Count;
			}
			else
			{
				ScheduleCitizenEvents(i, persona);
			}
			for (int num4 = _citizenEvents[i].Count - 1; num4 >= 0; num4--)
			{
				CitizenEvent citizenEvent = _citizenEvents[i][num4];
				if (IsSameDate(citizenEvent.NextTriggerDate, array))
				{
					citizenEvent.EventAction?.Invoke(persona, i);
					Debug.Log($"Событие {citizenEvent.EventName} выполнено для {persona.name} {persona.surname} в {array[0]}.{array[1]}.{array[2]}");
					citizenEvent.NextTriggerDate = CalculateNextTriggerDate(array, citizenEvent.PeriodMonths);
					PersonaCreator personaCreator = UnityEngine.Object.FindObjectOfType<PersonaCreator>();
					if (personaCreator != null)
					{
						personaCreator.UpdateStatUI();
					}
				}
			}
		}
	}

	private int[] CalculateNextTriggerDate(int[] currentDate, int periodMonths)
	{
		_ = currentDate[0];
		int num = currentDate[1];
		int num2 = currentDate[2];
		num += periodMonths;
		while (num > 12)
		{
			num -= 12;
			num2++;
		}
		int num3 = UnityEngine.Random.Range(1, 29);
		return new int[3] { num3, num, num2 };
	}

	private bool IsSameDate(int[] date1, int[] date2)
	{
		if (date1[0] == date2[0] && date1[1] == date2[1])
		{
			return date1[2] == date2[2];
		}
		return false;
	}

	private void RemoveCitizen(Persona citizen)
	{
		for (int i = 0; i < globalScript.gameState.citizens.Length; i++)
		{
			if (globalScript.gameState.citizens[i] == citizen)
			{
				globalScript.gameState.citizens[i] = null;
				Debug.Log("Гражданин " + citizen.name + " " + citizen.surname + " удалён из списка.");
				PersonaCreator personaCreator = UnityEngine.Object.FindObjectOfType<PersonaCreator>();
				if (personaCreator != null)
				{
					personaCreator.UpdateStatUI();
				}
				break;
			}
		}
	}

	private void HandleCitizenDeath(Persona citizen, int slot, float deathChance, int[] currentDate)
	{
		Debug.Log($"{citizen.name} {citizen.surname} умер, возраст {citizen.age}, финальный шанс: {deathChance}%");
		citizen.changeLog.Add(FormatLog(citizen, $"скончался на {citizen.age} году жизни. Шанс смерти был {deathChance}%", $"died at the age of {citizen.age}. Death chance was {deathChance}%", currentDate));
		citizen.isDead = true;
		citizen.Intrigue = 0;
		citizen.Charisma = 0;
		citizen.lastDeathCheck = currentDate;
		if (!citizen.isPolitic)
		{
			return;
		}
		for (int i = 0; i < globalScript.gameState.politics.Length; i++)
		{
			Politic politic = globalScript.gameState.politics[i];
			if (politic != null && politic.isCitizen && globalScript.gameState.names1[politic.name_1] == citizen.name && globalScript.gameState.names2[politic.name_2] == citizen.surname)
			{
				globalScript.gameState.KillPerson(i);
				Debug.Log("Политик-гражданин " + citizen.name + " " + citizen.surname + " удалён из списка политиков из-за смерти.");
				break;
			}
		}
	}

	private int MonthsSince(int[] startDate, int[] endDate)
	{
		int num = startDate[2];
		int num2 = startDate[1];
		int num3 = endDate[2];
		int num4 = endDate[1];
		return (num3 - num) * 12 + (num4 - num2);
	}

	public bool TryAmnesty(int slot)
	{
		Persona persona = globalScript.gameState.citizens[slot];
		if (persona == null || persona.status != Job.Prisoned || globalScript.gameState.data[9] < 50)
		{
			return false;
		}
		globalScript.gameState.data[9] -= 50;
		persona.status = Job.Amnestied;
		persona.changeLog.Add(FormatLog(persona, "был амнистирован!", "was amnestied!", CurrentDate()));
		return true;
	}

	public bool TryPursue(int slot)
	{
		Persona persona = globalScript.gameState.citizens[slot];
		if (persona == null || persona.hasBeenPursued || globalScript.gameState.data[9] < 10)
		{
			return false;
		}
		globalScript.gameState.data[9] -= 10;
		persona.hasBeenPursued = true;
		if (persona.isPolitic)
		{
			persona.changeLog.Add(FormatLog(persona, "уклонился от преследования, используя своё влияние", "avoided prosecution using political leverage", CurrentDate()));
		}
		else if (persona.status == Job.Amnestied || persona.status == Job.SignificantPartyMember || persona.status == Job.RegionalPartyBranchChief || persona.status == Job.LocalPartyBranchChief)
		{
			persona.status = Job.Underground;
			persona.changeLog.Add(FormatLog(persona, "стал объектом политического преследования и смог уйти в подполье", "became a target of political persecution and managed to go underground.", CurrentDate()));
		}
		else
		{
			persona.status = Job.Prisoned;
			persona.changeLog.Add(FormatLog(persona, "стал объектом политического преследования и был заключен в тюрьму", "became a target of political persecution and was imprisoned.", CurrentDate()));
		}
		return true;
	}

	public bool TryFinanceSupport(int slot)
	{
		Persona persona = globalScript.gameState.citizens[slot];
		int[] array = CurrentDate();
		if (persona == null || globalScript.gameState.data[9] < 50 || globalScript.gameState.data[8] < 10)
		{
			return false;
		}
		if (persona.lastFinanceSupport[2] == array[2])
		{
			return false;
		}
		globalScript.gameState.data[9] -= 50;
		globalScript.gameState.data[8] -= 10;
		persona.Wealth++;
		persona.lastFinanceSupport = array;
		persona.changeLog.Add(FormatLog(persona, "получил финансовую поддержку от государства", "received financial support from the state", CurrentDate()));
		return true;
	}

	private int[] CurrentDate()
	{
		return new int[3]
		{
			globalScript.gameState.data[19],
			globalScript.gameState.data[20],
			globalScript.gameState.data[21]
		};
	}

	private void FixedUpdate()
	{
		int num = 0;
		if (globalScript != null)
		{
			num = globalScript.gameState.data[19];
		}
		if (num != lastCheckedDay && globalScript != null)
		{
			CheckCitizenEvents();
			lastCheckedDay = num;
		}
	}
}
