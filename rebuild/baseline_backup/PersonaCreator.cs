using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonaCreator : MonoBehaviour
{
	[SerializeField]
	private InputField nameInput;

	[SerializeField]
	private InputField surnameInput;

	[SerializeField]
	private Text PointText;

	[SerializeField]
	private Text ageText;

	[SerializeField]
	private Button ageIncreaseButton;

	[SerializeField]
	private Button ageDecreaseButton;

	[SerializeField]
	private Button ageIncreaseButton10;

	[SerializeField]
	private Button ageDecreaseButton10;

	[SerializeField]
	private Text childrenText;

	[SerializeField]
	private Button childrenIncreaseButton;

	[SerializeField]
	private Button childrenDecreaseButton;

	[SerializeField]
	private Text wealthText;

	[SerializeField]
	private Button wealthIncreaseButton;

	[SerializeField]
	private Button wealthDecreaseButton;

	[SerializeField]
	private Text charismaText;

	[SerializeField]
	private Button charismaIncreaseButton;

	[SerializeField]
	private Button charismaDecreaseButton;

	[SerializeField]
	private Text intrigueText;

	[SerializeField]
	private Button intrigueIncreaseButton;

	[SerializeField]
	private Button intrigueDecreaseButton;

	[SerializeField]
	private Dropdown jobDropdown;

	[SerializeField]
	private Button confirmCreateButton;

	[SerializeField]
	private Button closeCreatorPanelButton;

	[SerializeField]
	private GameObject creatorPanel;

	[SerializeField]
	private Dropdown primaryTraitDropdown;

	[SerializeField]
	private Button createCitizenButton1;

	[SerializeField]
	private Button createCitizenButton2;

	[SerializeField]
	private Button createCitizenButton3;

	[SerializeField]
	private Button[] amnestyButtons = new Button[3];

	[SerializeField]
	private Button[] pursueButtons = new Button[3];

	[SerializeField]
	private Button[] financeButtons = new Button[3];

	[SerializeField]
	private Button generatePortraitButton;

	[SerializeField]
	private GameObject previewFaceObj0;

	[SerializeField]
	private GameObject previewFaceObj1;

	private Politic_Face_Renderer previewFaceRenderer0;

	private Politic_Face_Renderer previewFaceRenderer1;

	[SerializeField]
	private GameObject[] statUIPanels = new GameObject[3];

	[SerializeField]
	private Text[] statNameTexts = new Text[3];

	[SerializeField]
	private Text[] statAgeTexts = new Text[3];

	[SerializeField]
	private Text[] statChildrenTexts = new Text[3];

	[SerializeField]
	private Text[] statWealthTexts = new Text[3];

	[SerializeField]
	private Text[] statCharismaTexts = new Text[3];

	[SerializeField]
	private Text[] statIntrigueTexts = new Text[3];

	[SerializeField]
	private Text[] statJobTexts = new Text[3];

	[SerializeField]
	private GameObject[] UIFace = new GameObject[3];

	[SerializeField]
	private GameObject[] deathPanelStat = new GameObject[3];

	[SerializeField]
	private GameObject[] statFaceObjs = new GameObject[6];

	private Politic_Face_Renderer[] statFaceRenderers = new Politic_Face_Renderer[6];

	[SerializeField]
	private Text[] statPrimaryTraitTexts = new Text[3];

	[SerializeField]
	private Text[] statSecondaryTraitTexts = new Text[3];

	[SerializeField]
	private Text[] statTertiaryTraitTexts = new Text[3];

	[SerializeField]
	private Button[] promoteButtons = new Button[3];

	[SerializeField]
	private Button[] moreInfoButtons = new Button[3];

	[SerializeField]
	private Button logNextButton;

	[SerializeField]
	private Button logPrevButton;

	[SerializeField]
	private GameObject logPanel;

	[SerializeField]
	private Text logText;

	[SerializeField]
	private Text NamelogText;

	[SerializeField]
	private Button closeLogPanelButton;

	[SerializeField]
	private GameObject deathPanelInfo;

	[SerializeField]
	private GameObject previewLogFaceObj0;

	[SerializeField]
	private GameObject previewLogFaceObj1;

	private Politic_Face_Renderer previewLogFaceRenderer0;

	private Politic_Face_Renderer previewLogFaceRenderer1;

	private int currentLogPage;

	private int logsPerPage = 10;

	private List<string> currentLogs = new List<string>();

	private GlobalScript globalScript;

	private TranslateScriptDLC translateScript;

	private CitizenManager citizenManager;

	[SerializeField]
	private int availablePoints = 15;

	private int usedPoints;

	private int age = 18;

	private int children;

	private int wealth;

	private int charisma;

	private int intrigue;

	private int currentSlot = -1;

	private byte[] tempFaceParts = new byte[8];

	private byte tempJacket;

	private byte tempFaceType;

	private bool[] isPortraitRendered = new bool[3];

	private List<Job> jobOrder = new List<Job>();

	private void Awake()
	{
		globalScript = UnityEngine.Object.FindObjectOfType<GlobalScript>();
		translateScript = UnityEngine.Object.FindObjectOfType<TranslateScriptDLC>();
		citizenManager = UnityEngine.Object.FindObjectOfType<CitizenManager>();
		creatorPanel.SetActive(value: false);
		if (globalScript.gameState.citizens == null || globalScript.gameState.citizens.Length == 0)
		{
			globalScript.gameState.citizens = new Persona[3];
		}
		previewFaceRenderer0 = previewFaceObj0.GetComponent<Politic_Face_Renderer>();
		previewFaceRenderer1 = previewFaceObj1.GetComponent<Politic_Face_Renderer>();
		previewLogFaceRenderer0 = previewLogFaceObj0.GetComponent<Politic_Face_Renderer>();
		previewLogFaceRenderer1 = previewLogFaceObj1.GetComponent<Politic_Face_Renderer>();
		for (int i = 0; i < 6; i++)
		{
			if (statFaceObjs[i] != null)
			{
				statFaceRenderers[i] = statFaceObjs[i].GetComponent<Politic_Face_Renderer>();
			}
			else
			{
				Debug.LogError($"statFaceObjs[{i}] is not assigned!");
			}
		}
		if (previewFaceRenderer0 == null || previewFaceRenderer1 == null)
		{
			Debug.LogError("Preview face renderers are missing!");
		}
		for (int j = 0; j < 6; j++)
		{
			if (statFaceRenderers[j] == null)
			{
				Debug.LogError($"Stat face renderer for index {j} is missing!");
			}
		}
	}

	private void Start()
	{
		confirmCreateButton.onClick.AddListener(CreatePersona);
		generatePortraitButton.onClick.AddListener(GenerateRandomPortrait);
		createCitizenButton1.onClick.AddListener(delegate
		{
			OpenCreatorPanel(0);
		});
		createCitizenButton2.onClick.AddListener(delegate
		{
			OpenCreatorPanel(1);
		});
		createCitizenButton3.onClick.AddListener(delegate
		{
			OpenCreatorPanel(2);
		});
		ageIncreaseButton.onClick.AddListener(delegate
		{
			UpdateAge(age + 1);
		});
		ageDecreaseButton.onClick.AddListener(delegate
		{
			UpdateAge(age - 1);
		});
		ageIncreaseButton10.onClick.AddListener(delegate
		{
			UpdateAge(age + 10);
		});
		ageDecreaseButton10.onClick.AddListener(delegate
		{
			UpdateAge(age - 10);
		});
		childrenIncreaseButton.onClick.AddListener(delegate
		{
			UpdateChildren(children + 1);
		});
		childrenDecreaseButton.onClick.AddListener(delegate
		{
			UpdateChildren(children - 1);
		});
		wealthIncreaseButton.onClick.AddListener(delegate
		{
			UpdateWealth(wealth + 1);
		});
		wealthDecreaseButton.onClick.AddListener(delegate
		{
			UpdateWealth(wealth - 1);
		});
		charismaIncreaseButton.onClick.AddListener(delegate
		{
			UpdateCharisma(charisma + 1);
		});
		charismaDecreaseButton.onClick.AddListener(delegate
		{
			UpdateCharisma(charisma - 1);
		});
		intrigueIncreaseButton.onClick.AddListener(delegate
		{
			UpdateIntrigue(intrigue + 1);
		});
		intrigueDecreaseButton.onClick.AddListener(delegate
		{
			UpdateIntrigue(intrigue - 1);
		});
		for (int num = 0; num < promoteButtons.Length; num++)
		{
			int slot = num;
			promoteButtons[num].onClick.AddListener(delegate
			{
				PromoteCitizen(slot);
			});
			amnestyButtons[num].onClick.AddListener(delegate
			{
				TryAmnestyCitizen(slot);
			});
			pursueButtons[num].onClick.AddListener(delegate
			{
				TryPursueCitizen(slot);
			});
			financeButtons[num].onClick.AddListener(delegate
			{
				TryFinanceCitizen(slot);
			});
			moreInfoButtons[num].onClick.AddListener(delegate
			{
				ShowLogPanel(slot);
			});
		}
		closeLogPanelButton.onClick.AddListener(delegate
		{
			closeLogPanel();
		});
		closeCreatorPanelButton.onClick.AddListener(delegate
		{
			creatorPanel.SetActive(value: false);
		});
		closeCreatorPanelButton.onClick.AddListener(delegate
		{
			UpdateStatUI();
		});
		logNextButton.onClick.AddListener(delegate
		{
			currentLogPage++;
			UpdateLogText();
		});
		logPrevButton.onClick.AddListener(delegate
		{
			currentLogPage--;
			UpdateLogText();
		});
		InitializeJobDropdown();
		InitializePrimaryTraitDropdown();
		UpdateAllText();
		UpdateStatUI();
	}

	private void closeLogPanel()
	{
		logPanel.SetActive(value: false);
		for (int i = 0; i < 3; i++)
		{
			if (globalScript.gameState.citizens[i] != null)
			{
				statPrimaryTraitTexts[i].gameObject.SetActive(value: false);
				statSecondaryTraitTexts[i].gameObject.SetActive(value: false);
				statTertiaryTraitTexts[i].gameObject.SetActive(value: false);
			}
		}
		UpdateStatUI();
	}

	private void PromoteCitizen(int slot)
	{
		if (citizenManager != null)
		{
			citizenManager.PromoteToPolitic(slot);
		}
	}

	private void InitializeJobDropdown()
	{
		jobDropdown.ClearOptions();
		jobOrder.Clear();
		List<string> list = new List<string>();
		foreach (Job value in Enum.GetValues(typeof(Job)))
		{
			if (value != Job.SignificantPartyMember)
			{
				list.Add(translateScript.GetJobTranslation(value));
				jobOrder.Add(value);
			}
		}
		jobDropdown.AddOptions(list);
	}

	private void InitializePrimaryTraitDropdown()
	{
		primaryTraitDropdown.ClearOptions();
		List<string> list = new List<string>();
		list.Add(translateScript.GetTranslation("Not selected", "Не выбран"));
		foreach (CitizenManager.PrimaryTrait value in Enum.GetValues(typeof(CitizenManager.PrimaryTrait)))
		{
			if (value != CitizenManager.PrimaryTrait.None)
			{
				string traitTranslation = citizenManager.GetTraitTranslation(value);
				list.Add(traitTranslation);
			}
		}
		primaryTraitDropdown.AddOptions(list);
	}

	private void GenerateRandomPortrait()
	{
		tempFaceType = (byte)UnityEngine.Random.Range(0, 2);
		Politic_Face_Renderer politic_Face_Renderer = ((tempFaceType == 0) ? previewFaceRenderer0 : previewFaceRenderer1);
		Sprite[] s_ = politic_Face_Renderer.s_0;
		Sprite[] s_2 = politic_Face_Renderer.s_1;
		Sprite[] s_3 = politic_Face_Renderer.s_2;
		Sprite[] s_4 = politic_Face_Renderer.s_3;
		Sprite[] s_5 = politic_Face_Renderer.s_4;
		Sprite[] s_6 = politic_Face_Renderer.s_5;
		Sprite[] s_7 = politic_Face_Renderer.s_6;
		Sprite[] s_8 = politic_Face_Renderer.s_7;
		Sprite[] jacket = politic_Face_Renderer.jacket;
		if (s_ == null || s_.Length == 0 || jacket == null || jacket.Length == 0)
		{
			Debug.LogError($"Sprite arrays for Face_{tempFaceType} are empty or null!");
			return;
		}
		tempFaceParts = new byte[8];
		tempFaceParts[0] = (byte)UnityEngine.Random.Range(0, s_.Length);
		tempFaceParts[1] = (byte)UnityEngine.Random.Range(0, s_2.Length);
		tempFaceParts[2] = (byte)UnityEngine.Random.Range(0, s_3.Length);
		tempFaceParts[3] = (byte)UnityEngine.Random.Range(0, s_4.Length);
		tempFaceParts[4] = (byte)UnityEngine.Random.Range(0, s_5.Length);
		tempFaceParts[5] = (byte)UnityEngine.Random.Range(0, s_6.Length);
		tempFaceParts[6] = (byte)UnityEngine.Random.Range(0, s_7.Length);
		tempFaceParts[7] = (byte)UnityEngine.Random.Range(0, s_8.Length);
		tempJacket = (byte)UnityEngine.Random.Range(0, jacket.Length);
		previewFaceObj0.SetActive(tempFaceType == 0);
		previewFaceObj1.SetActive(tempFaceType == 1);
		politic_Face_Renderer.Draw(tempFaceParts, tempJacket);
	}

	private void UpdateAllText()
	{
		UpdateAgeText();
		UpdateChildrenText();
		UpdateWealthText();
		UpdateCharismaText();
		UpdateIntrigueText();
		UpdatePoints();
	}

	private void UpdateAge(int newValue)
	{
		age = Mathf.Clamp(newValue, 18, 80);
		UpdateAllText();
	}

	private void UpdateAgeText()
	{
		ageText.text = $"{age}";
		ageDecreaseButton.interactable = age > 18;
		ageIncreaseButton.interactable = age < 80;
	}

	private void UpdateChildren(int newValue)
	{
		children = Mathf.Clamp(newValue, 0, 5);
		UpdateAllText();
	}

	private void UpdateChildrenText()
	{
		childrenText.text = $"{children}";
		childrenDecreaseButton.interactable = children > 0;
		childrenIncreaseButton.interactable = children < 5;
	}

	private void UpdateWealth(int newValue)
	{
		int num = Mathf.Clamp(newValue, 0, availablePoints - charisma - intrigue);
		if (num + charisma + intrigue <= availablePoints)
		{
			wealth = num;
		}
		UpdateAllText();
	}

	private void UpdateWealthText()
	{
		wealthText.text = $"{wealth}";
		wealthDecreaseButton.interactable = wealth > 0;
		wealthIncreaseButton.interactable = wealth < availablePoints - charisma - intrigue;
	}

	private void UpdateCharisma(int newValue)
	{
		int num = Mathf.Clamp(newValue, 0, availablePoints - wealth - intrigue);
		if (wealth + num + intrigue <= availablePoints)
		{
			charisma = num;
		}
		UpdateAllText();
	}

	private void UpdateCharismaText()
	{
		charismaText.text = $"{charisma}";
		charismaDecreaseButton.interactable = charisma > 0;
		charismaIncreaseButton.interactable = charisma < 15 && wealth + charisma + intrigue < availablePoints;
	}

	private void UpdateIntrigue(int newValue)
	{
		int num = Mathf.Clamp(newValue, 0, availablePoints - wealth - charisma);
		if (wealth + charisma + num <= availablePoints)
		{
			intrigue = num;
		}
		UpdateAllText();
	}

	private void UpdateIntrigueText()
	{
		intrigueText.text = $"{intrigue}";
		intrigueDecreaseButton.interactable = intrigue > 0;
		intrigueIncreaseButton.interactable = intrigue < 15 && wealth + charisma + intrigue < availablePoints;
	}

	private void UpdatePoints()
	{
		usedPoints = wealth + charisma + intrigue;
		confirmCreateButton.interactable = usedPoints <= availablePoints;
		int num = availablePoints - usedPoints;
		PointText.text = $"{num}";
	}

	private void OpenCreatorPanel(int slot)
	{
		if (slot < 0 || slot >= 3)
		{
			Debug.LogWarning("Invalid slot index!");
			return;
		}
		if (globalScript.gameState.citizens[slot] != null)
		{
			Debug.LogWarning($"Slot {slot} is already occupied!");
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			if (globalScript.gameState.citizens[i] != null)
			{
				UIFace[i].SetActive(value: false);
			}
		}
		currentSlot = slot;
		creatorPanel.SetActive(value: true);
		ResetCreator();
	}

	private void ResetCreator()
	{
		nameInput.text = "";
		surnameInput.text = "";
		age = 18;
		children = 0;
		wealth = 0;
		charisma = 0;
		intrigue = 0;
		primaryTraitDropdown.value = 0;
		jobDropdown.value = 0;
		UpdateAllText();
		GenerateRandomPortrait();
	}

	private void CreatePersona()
	{
		if (string.IsNullOrEmpty(nameInput.text) || string.IsNullOrEmpty(surnameInput.text))
		{
			Debug.LogWarning("Name and Surname cannot be empty!");
			return;
		}
		if (currentSlot < 0 || currentSlot >= 3)
		{
			Debug.LogWarning("Invalid slot for creation!");
			return;
		}
		Persona persona = new Persona
		{
			name = Capitalize(nameInput.text),
			surname = Capitalize(surnameInput.text),
			age = age,
			Children = children,
			Wealth = wealth,
			Charisma = charisma,
			Intrigue = intrigue,
			status = (Job)jobDropdown.value,
			face_parts = new byte[8],
			jacket = tempJacket,
			face_type = tempFaceType
		};
		for (int i = 0; i < tempFaceParts.Length; i++)
		{
			persona.face_parts[i] = tempFaceParts[i];
		}
		int value = primaryTraitDropdown.value;
		if (value > 0)
		{
			persona.primaryTrait = (CitizenManager.PrimaryTrait)value;
		}
		if (citizenManager != null)
		{
			citizenManager.AddCitizen(persona, currentSlot);
		}
		globalScript.gameState.citizens[currentSlot] = persona;
		isPortraitRendered[currentSlot] = false;
		for (int j = 0; j < 3; j++)
		{
			if (globalScript.gameState.citizens[j] != null)
			{
				UIFace[j].SetActive(value: true);
			}
		}
		UpdateStatUI();
		creatorPanel.SetActive(value: false);
		ResetCreator();
		currentSlot = -1;
	}

	private string Capitalize(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return input;
		}
		input = input.Trim();
		return char.ToUpper(input[0]) + input.Substring(1).ToLower();
	}

	private void ShowLogPanel(int slot)
	{
		if (slot < 0 || slot >= 3 || globalScript.gameState.citizens[slot] == null)
		{
			Debug.LogWarning("Недопустимый слот или гражданин отсутствует!");
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			if (globalScript.gameState.citizens[i] != null)
			{
				UIFace[i].SetActive(value: false);
			}
		}
		Persona persona = globalScript.gameState.citizens[slot];
		statPrimaryTraitTexts[slot].gameObject.SetActive(value: true);
		statSecondaryTraitTexts[slot].gameObject.SetActive(value: true);
		statTertiaryTraitTexts[slot].gameObject.SetActive(value: true);
		currentLogs = persona.changeLog;
		currentLogPage = Mathf.Max(0, Mathf.CeilToInt((float)currentLogs.Count / (float)logsPerPage) - 1);
		UpdateLogText();
		NamelogText.text = persona.name + " " + persona.surname;
		previewLogFaceObj0.SetActive(persona.face_type == 0);
		previewLogFaceObj1.SetActive(persona.face_type == 1);
		if (persona.isDead)
		{
			deathPanelInfo.SetActive(value: true);
		}
		else
		{
			deathPanelInfo.SetActive(value: false);
		}
		((persona.face_type == 0) ? previewLogFaceRenderer0 : previewLogFaceRenderer1).Draw(persona.face_parts, persona.jacket);
		Debug.Log(string.Format("After rendering Slot {0}: face_type={1}, face_parts=[{2}], jacket={3}", slot, persona.face_type, string.Join(",", persona.face_parts), persona.jacket));
		logPanel.SetActive(value: true);
	}

	private void UpdateLogText()
	{
		int num = Mathf.CeilToInt((float)currentLogs.Count / (float)logsPerPage);
		currentLogPage = Mathf.Clamp(currentLogPage, 0, Mathf.Max(num - 1, 0));
		int num2 = currentLogPage * logsPerPage;
		int count = Mathf.Min(logsPerPage, currentLogs.Count - num2);
		List<string> range = currentLogs.GetRange(num2, count);
		logText.text = string.Join("\n", range);
		logPrevButton.interactable = currentLogPage > 0;
		logNextButton.interactable = currentLogPage < num - 1;
	}

	private void TryAmnestyCitizen(int slot)
	{
		if (citizenManager.TryAmnesty(slot))
		{
			UpdateStatUI();
		}
	}

	private void TryPursueCitizen(int slot)
	{
		if (citizenManager.TryPursue(slot))
		{
			UpdateStatUI();
		}
	}

	private void TryFinanceCitizen(int slot)
	{
		if (citizenManager.TryFinanceSupport(slot))
		{
			UpdateStatUI();
		}
	}

	public void UpdateStatUI()
	{
		int num = globalScript.gameState.data[21];
		int num2 = globalScript.gameState.data[9];
		int num3 = globalScript.gameState.data[8];
		for (int i = 0; i < 3; i++)
		{
			if (globalScript.gameState.citizens[i] != null)
			{
				Persona persona = globalScript.gameState.citizens[i];
				Debug.Log(string.Format("Slot {0}: face_type={1}, face_parts=[{2}], jacket={3}", i, persona.face_type, string.Join(",", persona.face_parts), persona.jacket));
				statUIPanels[i].SetActive(value: true);
				statNameTexts[i].text = persona.name + " " + persona.surname;
				statAgeTexts[i].text = $"{persona.age}";
				statChildrenTexts[i].text = $"{persona.Children}";
				statWealthTexts[i].text = $"{persona.Wealth}";
				statCharismaTexts[i].text = $"{persona.Charisma}";
				statIntrigueTexts[i].text = $"{persona.Intrigue}";
				statJobTexts[i].text = translateScript.GetJobTranslation(persona.status) ?? "";
				UIFace[i].SetActive(value: true);
				amnestyButtons[i].interactable = false;
				pursueButtons[i].interactable = false;
				financeButtons[i].interactable = false;
				promoteButtons[i].gameObject.SetActive(persona.status == Job.SignificantPartyMember && !persona.isPolitic && !persona.isDead);
				if (citizenManager != null)
				{
					var (trait, trait2, list) = citizenManager.GetCitizenTraits(i);
					statPrimaryTraitTexts[i].text = citizenManager.GetTraitTranslation(trait);
					statSecondaryTraitTexts[i].text = citizenManager.GetTraitTranslation(trait2);
					statTertiaryTraitTexts[i].text = string.Join(", ", list.ConvertAll((CitizenManager.TertiaryTrait t) => citizenManager.GetTraitTranslation(t)));
				}
				if (persona.isDead)
				{
					deathPanelStat[i].SetActive(value: true);
					amnestyButtons[i].gameObject.SetActive(value: false);
					pursueButtons[i].gameObject.SetActive(value: false);
					financeButtons[i].gameObject.SetActive(value: false);
				}
				else
				{
					bool interactable = persona.status == Job.Prisoned && num2 >= 50 && !persona.isLead;
					bool interactable2 = persona.status != Job.Underground && !persona.hasBeenPursued && num2 >= 10 && !persona.isLead;
					bool interactable3 = false;
					int num4 = persona.lastFinanceSupport[2];
					if (num2 >= 50 && num3 >= 10 && num4 != num && !persona.isLead)
					{
						Debug.Log($"{num4} год, последнй финасовой помоши у {persona.name}. А сейчас {num}");
						interactable3 = true;
					}
					amnestyButtons[i].interactable = interactable;
					pursueButtons[i].interactable = interactable2;
					financeButtons[i].interactable = interactable3;
				}
				if (!isPortraitRendered[i])
				{
					statFaceObjs[i * 2].SetActive(persona.face_type == 0);
					statFaceObjs[i * 2 + 1].SetActive(persona.face_type == 1);
					statFaceRenderers[i * 2 + persona.face_type].Draw(persona.face_parts, persona.jacket);
					Debug.Log(string.Format("After rendering Slot {0}: face_type={1}, face_parts=[{2}], jacket={3}", i, persona.face_type, string.Join(",", persona.face_parts), persona.jacket));
					isPortraitRendered[i] = true;
				}
			}
			else
			{
				statUIPanels[i].SetActive(value: false);
			}
			createCitizenButton1.interactable = globalScript.gameState.citizens[0] == null;
			createCitizenButton2.interactable = globalScript.gameState.citizens[1] == null;
			createCitizenButton3.interactable = globalScript.gameState.citizens[2] == null;
		}
	}
}
