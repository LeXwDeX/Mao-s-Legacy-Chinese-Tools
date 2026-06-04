using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class SaveListController : MonoBehaviour
{
	[Header("UI")]
	public TextMesh opis;

	[Header("Layout")]
	public float listWidth = 325f;

	public float listHeight = 500f;

	public float entryHeight = 112.5f;

	public float listX = -250f;

	public float listY = 350f;

	[Header("Save Button")]
	public float newButtonXOffset = 45f;

	public float newButtonYOffset = -400f;

	public float newButtonWidth = 400f;

	public float newButtonHeight = 100f;

	public Color newButtonColor = new Color(1f, 0f, 0f, 0.6f);

	public Color newButtonTextColor = Color.white;

	public int newButtonFontSize = 30;

	public string newButtonFontPath = "Fonts/Capture_it";

	public Color newButtonHoverColor = new Color(0.6f, 0f, 0f, 0.75f);

	public Font newButtonFontAsset;

	public string anchorName = "按钮（5）";

	public Vector2 anchorOffset = Vector2.zero;

	public Transform anchor;

	[Header("Iron Toggle")]
	public float ironToggleXOffset = 12f;

	public float ironToggleSize = 36f;

	public float ironToggleLabelOffset = 6f;

	public float ironTogglePadding = 6f;

	public float ironToggleLabelWidth = 240f;

	public int ironToggleLabelFontSize = 20;

	public float ironToggleBackgroundTrimY = 10f;

	public Color ironToggleBackgroundColor = new Color(0f, 0f, 0f, 0.35f);

	public string ironToggleOnLabelEn = "有成就";

	public string ironToggleOnLabelRu = "С достижениями";

	public string ironToggleOffLabelEn = "无成就";

	public string ironToggleOffLabelRu = "Без достижений";

	[Header("Achievement Icon")]
	public string achievementIcon = "Λ";

	public Color achievementIconColor = new Color(0.8f, 0f, 0f, 1f);

	public int achievementIconFontSize = 20;

	public Vector2 achievementIconOffset = Vector2.zero;

	private readonly List<SaveMetadata> items = new List<SaveMetadata>();

	private Vector2 scrollPos;

	private bool renaming;

	private SaveMetadata renameMeta;

	private string renameBuffer = string.Empty;

	private float initialListHeight;

	private Font newButtonFont;

	private Texture2D newButtonNormalTex;

	private Texture2D newButtonHoverTex;

	private Color lastNormalColor;

	private Color lastHoverColor;

	private bool achievementsAvailable;

	private bool hasSpecialSave;

	private GUIStyle achievementIconStyle;

	private GUIStyle itemNameStyle;

	private GUIStyle itemInfoStyle;

	private bool newSaveIronToggle = true;

	private float baseListWidth;

	private float baseListHeight;

	private float baseEntryHeight;

	private float baseListX;

	private float baseListY;

	private float baseNewButtonXOffset;

	private float baseNewButtonYOffset;

	private float baseNewButtonWidth;

	private float baseNewButtonHeight;

	private Vector2 baseAnchorOffset;

	private Texture2D ironToggleBgTex;

	public static SaveListController Instance { get; private set; }

	public static SaveListController EnsureInstance(Savescript source)
	{
		if (Instance != null)
		{
			return Instance;
		}
		GameObject obj = new GameObject("SaveListController");
		SaveListController saveListController = obj.AddComponent<SaveListController>();
		saveListController.opis = source.Opis;
		ParentToBackground(obj.transform, source.transform);
		obj.AddComponent<sizescript>();
		Instance = saveListController;
		return saveListController;
	}

	private void Start()
	{
		Instance = this;
		SaveStorage.EnsureMetadataFile();
		CacheBaseLayout();
		ApplyAspectScale();
		Refresh();
		HideLegacySlots();
		ResolveAnchor();
		initialListHeight = listHeight;
		AdjustListHeight();
		LoadButtonFont();
	}

	private void Refresh()
	{
		items.Clear();
		SaveMetadata[] array = SaveStorage.LoadMetadata()?.items ?? Array.Empty<SaveMetadata>();
		achievementsAvailable = AchievementsAreAvailable();
		hasSpecialSave = false;
		string text = CurrentRunHash();
		SaveMetadata[] array2;
		if (achievementsAvailable && !string.IsNullOrEmpty(text))
		{
			List<SaveMetadata> list = new List<SaveMetadata>();
			List<SaveMetadata> list2 = new List<SaveMetadata>();
			array2 = array;
			foreach (SaveMetadata saveMetadata in array2)
			{
				if (saveMetadata != null)
				{
					if (saveMetadata.iron && string.Equals(saveMetadata.runHash ?? string.Empty, text))
					{
						list.Add(saveMetadata);
					}
					else
					{
						list2.Add(saveMetadata);
					}
				}
			}
			hasSpecialSave = list.Count > 0;
			items.AddRange(list);
			items.AddRange(list2);
			return;
		}
		array2 = array;
		foreach (SaveMetadata saveMetadata2 in array2)
		{
			if (saveMetadata2 != null)
			{
				items.Add(saveMetadata2);
			}
		}
	}

	private static string Loc(string en, string ru)
	{
		if (PlayerPrefs.GetInt("language") != 0)
		{
			return ru;
		}
		return en;
	}

	private static void ParentToBackground(Transform t, Transform fallback)
	{
		GameObject gameObject = GameObject.Find("Background");
		if (gameObject != null)
		{
			t.SetParent(gameObject.transform, worldPositionStays: false);
		}
		else if (fallback != null)
		{
			t.SetParent(fallback.parent, worldPositionStays: false);
		}
	}

	private void HideLegacySlots()
	{
		Savescript[] array = UnityEngine.Object.FindObjectsOfType<Savescript>();
		foreach (Savescript savescript in array)
		{
			if (!(savescript == null))
			{
				DisableRenderersAndColliders(savescript.gameObject);
				if (!(savescript.gameObject != null) || !(savescript.gameObject.name == anchorName))
				{
					savescript.gameObject.SetActive(value: false);
				}
			}
		}
	}

	public void ShowDetails(SaveMetadata meta)
	{
		if (meta != null && !(opis == null))
		{
			opis.text = Savescript.BuildOpisText(meta.id, meta);
		}
	}

	public void ClearDetails()
	{
		if (opis != null)
		{
			opis.text = string.Empty;
		}
	}

	public void SaveToSlot(SaveMetadata meta, bool? forceIron = null, string runHashOverride = null)
	{
		GameState gameState = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null);
		bool flag = gameState?.iron_and_blood ?? false;
		bool flag2 = (forceIron.HasValue ? forceIron.Value : flag);
		string runHash = (flag2 ? (runHashOverride ?? ((gameState != null) ? (gameState.runHash ?? string.Empty) : string.Empty)) : string.Empty);
		meta.iron = flag2;
		meta.runHash = runHash;
		SyncPlayerPrefs(meta);
		SaveStorage.SaveGame(meta, GlobalScript.inst.gameState, meta.iron);
		ShowDetails(meta);
		if (opis != null)
		{
			TextMesh textMesh = opis;
			textMesh.text = textMesh.text + "\n" + Loc("Saved.", "Сохранено.");
		}
	}

	public void CreateAndSaveNew(bool iron = false)
	{
		GameState gameState = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null);
		int num;
		object obj;
		if (gameState != null)
		{
			num = (gameState.iron_and_blood ? 1 : 0);
			if (num != 0)
			{
				obj = ((gameState != null) ? (gameState.runHash ?? string.Empty) : string.Empty);
				goto IL_004a;
			}
		}
		else
		{
			num = 0;
		}
		obj = string.Empty;
		goto IL_004a;
		IL_004a:
		string text = (string)obj;
		bool flag = num != 0 && (!ShowIronToggle(gameState, text) || newSaveIronToggle);
		string text2 = (flag ? text : string.Empty);
		SaveMetadata meta = SaveStorage.CreateNew(string.Empty, flag, text2);
		SaveToSlot(meta, flag, text2);
		Refresh();
	}

	private void SyncPlayerPrefs(SaveMetadata meta)
	{
		if (meta != null)
		{
			GameState gameState = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null);
			if (gameState != null && gameState.data != null && gameState.data.Length >= 22)
			{
				int num = meta.id + 10;
				PlayerPrefs.SetString("iron" + num, meta.iron.ToString());
				PlayerPrefs.SetInt("save_diff" + num, gameState.diff);
				PlayerPrefs.SetInt("data" + 14 + num, gameState.data[14]);
				PlayerPrefs.SetInt("data" + 19 + num, gameState.data[19]);
				PlayerPrefs.SetInt("data" + 20 + num, gameState.data[20]);
				PlayerPrefs.SetInt("data" + 21 + num, gameState.data[21]);
			}
		}
	}

	public void DeleteSlot(SaveMetadata meta)
	{
		SaveStorage.Delete(meta);
		Refresh();
	}

	public void BeginRename(SaveMetadata meta)
	{
		renaming = true;
		renameMeta = meta;
		renameBuffer = meta.name;
	}

	private void ApplyRename()
	{
		if (renameMeta != null)
		{
			string newName = (string.IsNullOrWhiteSpace(renameBuffer) ? renameMeta.name : renameBuffer.Trim());
			renameMeta.name = newName;
			SaveStorage.RenameFiles(renameMeta, newName);
			Refresh();
			renaming = false;
			renameMeta = null;
		}
	}

	private void OnGUI()
	{
		bool flag = PlayerPrefs.GetInt("language") != 0;
		ApplyAspectScale();
		AdjustListHeight();
		Vector2 basePosition = GetBasePosition();
		float x = basePosition.x;
		float y = basePosition.y;
		Rect rect = new Rect(x + newButtonXOffset, y + newButtonYOffset, newButtonWidth, newButtonHeight);
		GameState gameState = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null);
		string text = ((gameState != null) ? (gameState.runHash ?? string.Empty) : string.Empty);
		bool flag2 = ShowIronToggle(gameState, text);
		bool num = !achievementsAvailable || !hasSpecialSave || (flag2 && !newSaveIronToggle);
		bool runHashMode = achievementsAvailable && !string.IsNullOrEmpty(text);
		Color backgroundColor = GUI.backgroundColor;
		Color contentColor = GUI.contentColor;
		if (num)
		{
			GUI.backgroundColor = newButtonColor;
			GUI.contentColor = newButtonTextColor;
			EnsureButtonTextures();
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.button);
			gUIStyle.fontSize = newButtonFontSize;
			gUIStyle.normal.textColor = newButtonTextColor;
			gUIStyle.hover.textColor = newButtonTextColor;
			gUIStyle.active.textColor = newButtonTextColor;
			gUIStyle.normal.background = newButtonNormalTex;
			gUIStyle.hover.background = newButtonHoverTex;
			gUIStyle.active.background = newButtonHoverTex;
			if (newButtonFont != null)
			{
				gUIStyle.font = newButtonFont;
			}
			if (GUI.Button(rect, Loc("新存档", "Новое сохранение"), gUIStyle) || Event.current.keyCode == KeyCode.N)
			{
				CreateAndSaveNew();
			}
			GUI.backgroundColor = backgroundColor;
			GUI.contentColor = contentColor;
		}
		if (flag2)
		{
			DrawIronToggle(rect);
		}
		Rect position = new Rect(x, y, listWidth, listHeight);
		float height = Mathf.Max(listHeight, (float)items.Count * entryHeight + 10f);
		scrollPos = GUI.BeginScrollView(position, scrollPos, new Rect(0f, 0f, listWidth - 20f, height));
		float num2 = 0f;
		bool flag3 = false;
		bool flag4 = Event.current.type == EventType.Repaint || Event.current.type == EventType.MouseMove;
		EnsureItemStyles();
		Vector2 mousePosition = Event.current.mousePosition;
		foreach (SaveMetadata item in items)
		{
			Rect position2 = new Rect(0f, num2, listWidth - 40f, entryHeight - 10f);
			GUI.Box(position2, string.Empty);
			float num3 = 0f;
			if (item.iron)
			{
				EnsureAchievementIconStyle();
				Vector2 vector = achievementIconStyle.CalcSize(new GUIContent(achievementIcon));
				num3 = vector.x + 4f;
				GUI.Label(new Rect(position2.x + 8f + achievementIconOffset.x, position2.y + 4f + achievementIconOffset.y, vector.x, vector.y), achievementIcon, achievementIconStyle);
			}
			GUI.Label(new Rect(position2.x + 8f + num3, position2.y + 4f, position2.width - 16f - num3, 25f), item.name, itemNameStyle);
			GUI.Label(new Rect(position2.x + 8f, position2.y + 30f, position2.width - 16f, 25f), BuildCreatedLabel(item, flag), itemInfoStyle);
			float num4 = 25f;
			float y2 = position2.y + position2.height - (num4 + 6f);
			float num5 = (position2.width - 20f) / 3f;
			float num6 = position2.x + 6f;
			Rect rect2 = new Rect(num6, y2, num5, num4);
			bool num7 = CanSaveSlot(item, runHashMode, text);
			if (num7 && GUI.Button(rect2, flag ? "Сохранить" : "Save"))
			{
				SaveToSlot(item);
			}
			if (!num7)
			{
				rect2 = Rect.zero;
			}
			Rect position3 = new Rect(num6 + num5 + 4f, y2, num5, num4);
			if (GUI.Button(position3, flag ? "Имя" : "Rename"))
			{
				BeginRename(item);
			}
			Rect position4 = new Rect(num6 + 2f * (num5 + 4f), y2, num5, num4);
			if (GUI.Button(position4, flag ? "Удалить" : "Delete"))
			{
				DeleteSlot(item);
				break;
			}
			if (flag4 && (position2.Contains(mousePosition) || (rect2 != Rect.zero && rect2.Contains(mousePosition)) || position3.Contains(mousePosition) || position4.Contains(mousePosition)))
			{
				if (opis != null)
				{
					string text2 = Savescript.BuildOpisText(item.id, item);
					text2 = text2.Replace('|', ' ');
					opis.text = text2;
				}
				flag3 = true;
			}
			num2 += entryHeight;
		}
		GUI.EndScrollView();
		if (flag4 && !flag3 && !renaming)
		{
			ClearDetails();
		}
		if (renaming && renameMeta != null)
		{
			Rect position5 = new Rect(position.xMax + 10f, position.y, 220f, 24f);
			GUI.SetNextControlName("SaveRenameField");
			renameBuffer = GUI.TextField(position5, renameBuffer, 40);
			GUI.FocusControl("SaveRenameField");
			if (GUI.Button(new Rect(position5.x, position5.yMax + 4f, 100f, 24f), Loc("OK", "ОК")) || Event.current.keyCode == KeyCode.Return)
			{
				ApplyRename();
			}
			if (GUI.Button(new Rect(position5.x + 110f, position5.yMax + 4f, 100f, 24f), Loc("Cancel", "Отмена")) || Event.current.keyCode == KeyCode.Escape)
			{
				renaming = false;
				renameMeta = null;
			}
		}
	}

	private string BuildDetails(SaveMetadata meta)
	{
		if (meta == null)
		{
			return string.Empty;
		}
		bool flag = PlayerPrefs.GetInt("language") != 0;
		string text = $"{meta.day}.{meta.month}.{meta.year}";
		string text2 = meta.diff switch
		{
			0 => flag ? "Песочница" : "Sandbox", 
			1 => flag ? "Лёгкий" : "Easy", 
			2 => flag ? "Стандарт" : "Normal", 
			3 => flag ? "Тяжёлый" : "Hard", 
			4 => flag ? "Культурная революция" : "文化大革命", 
			_ => meta.diff.ToString(), 
		};
		int num = PlayerPrefs.GetInt("data14" + (meta.id + 10), -1);
		string text3 = (flag ? "?" : "?");
		string[] doctr = GlobalScript.inst.gameState.doctr;
		if (num >= 0 && doctr != null && num < doctr.Length)
		{
			text3 = doctr[num];
		}
		string text4 = ((!meta.iron) ? (flag ? "<color=red>Достижения: Недоступны</color>" : "<color=red>成就：不可用</color>") : (flag ? "<color=red>С достижениями</color>" : "<color=red>有成就</color>"));
		if (flag)
		{
			return "Имя: " + meta.name + "\nГосстрой: " + text3 + "\nДата: " + text + "\nСложность: " + text2 + "\n" + text4;
		}
		return "Name: " + meta.name + "\nGovernment: " + text3 + "日期：" + text + "\nDifficulty: " + text2 + "\n" + text4;
	}

	private void ResolveAnchor()
	{
		if (anchor == null)
		{
			GameObject gameObject = GameObject.Find(anchorName);
			if (gameObject != null)
			{
				anchor = gameObject.transform;
			}
		}
	}

	private Vector2 GetBasePosition()
	{
		ResolveAnchor();
		if (anchor != null)
		{
			Camera main = Camera.main;
			if (main != null)
			{
				Vector3 vector = main.WorldToScreenPoint(anchor.position);
				return new Vector2(vector.x + anchorOffset.x + listX, (float)Screen.height - vector.y + anchorOffset.y + listY);
			}
		}
		return new Vector2(listX, listY);
	}

	private void AdjustListHeight()
	{
		Camera main = Camera.main;
		if (!(main == null))
		{
			Vector2 basePosition = GetBasePosition();
			float num = Mathf.Max(50f, (float)main.pixelHeight - basePosition.y - 20f);
			listHeight = num;
		}
	}

	private void CacheBaseLayout()
	{
		baseListWidth = listWidth;
		baseListHeight = listHeight;
		baseEntryHeight = entryHeight;
		baseListX = listX;
		baseListY = listY;
		baseNewButtonXOffset = newButtonXOffset;
		baseNewButtonYOffset = newButtonYOffset;
		baseNewButtonWidth = newButtonWidth;
		baseNewButtonHeight = newButtonHeight;
		baseAnchorOffset = anchorOffset;
	}

	private void ApplyAspectScale()
	{
		Camera main = Camera.main;
		if (!(main == null))
		{
			float num = main.aspect / 1.7777778f;
			float num2 = (float)main.pixelHeight / 1080f;
			listWidth = baseListWidth * num;
			listHeight = baseListHeight;
			entryHeight = baseEntryHeight;
			listX = baseListX * num;
			listY = baseListY * num2;
			newButtonXOffset = baseNewButtonXOffset * num;
			newButtonYOffset = baseNewButtonYOffset * num2;
			newButtonWidth = baseNewButtonWidth * num;
			newButtonHeight = baseNewButtonHeight * num2;
			anchorOffset = new Vector2(baseAnchorOffset.x * num, baseAnchorOffset.y * num2);
		}
	}

	private void LoadButtonFont()
	{
		if (newButtonFontAsset != null)
		{
			newButtonFont = newButtonFontAsset;
		}
		else if (!string.IsNullOrEmpty(newButtonFontPath))
		{
			newButtonFont = Resources.Load<Font>(newButtonFontPath);
			if (newButtonFont == null)
			{
				newButtonFont = TryLoadFontVariant("Capture_it") ?? TryLoadFontVariant("捕获它的SDF") ?? FindLoadedFontByName("Capture_it") ?? FindLoadedFontByName("捕获它的SDF");
			}
		}
	}

	private Font TryLoadFontVariant(string fontName)
	{
		Font font = Resources.Load<Font>(fontName);
		if (font != null)
		{
			return font;
		}
		font = Resources.Load<Font>("Fonts/" + fontName);
		if (font != null)
		{
			return font;
		}
		return null;
	}

	private Font FindLoadedFontByName(string fontName)
	{
		if (string.IsNullOrEmpty(fontName))
		{
			return null;
		}
		Font[] array = Resources.FindObjectsOfTypeAll<Font>();
		foreach (Font font in array)
		{
			if (font != null && font.name.Equals(fontName, StringComparison.OrdinalIgnoreCase))
			{
				return font;
			}
		}
		return null;
	}

	private void EnsureButtonTextures()
	{
		if (newButtonNormalTex == null || lastNormalColor != newButtonColor)
		{
			newButtonNormalTex = MakeTex(newButtonColor);
			lastNormalColor = newButtonColor;
		}
		if (newButtonHoverTex == null || lastHoverColor != newButtonHoverColor)
		{
			newButtonHoverTex = MakeTex(newButtonHoverColor);
			lastHoverColor = newButtonHoverColor;
		}
	}

	private void DrawIronToggle(Rect newBtnRect)
	{
		float num = ironToggleSize;
		float num2 = ironTogglePadding;
		string text = (newSaveIronToggle ? Loc(ironToggleOnLabelEn, ironToggleOnLabelRu) : Loc(ironToggleOffLabelEn, ironToggleOffLabelRu));
		GUIStyle gUIStyle = new GUIStyle(GUI.skin.label)
		{
			fontSize = ironToggleLabelFontSize,
			alignment = TextAnchor.MiddleLeft
		};
		if (newButtonFont != null)
		{
			gUIStyle.font = newButtonFont;
		}
		Vector2 vector = gUIStyle.CalcSize(new GUIContent(text));
		float num3 = Mathf.Max(num, vector.y);
		float width = num2 + num + ironToggleLabelOffset + ironToggleLabelWidth + num2;
		float num4 = num3 + num2 * 2f;
		float num5 = Mathf.Max(num3 + num2, num4 - ironToggleBackgroundTrimY);
		float y = newBtnRect.y + (newBtnRect.height - num5) / 2f;
		Rect position = new Rect(newBtnRect.xMax + ironToggleXOffset, y, width, num5);
		if (ironToggleBgTex == null)
		{
			ironToggleBgTex = MakeTex(ironToggleBackgroundColor);
		}
		Color backgroundColor = GUI.backgroundColor;
		GUI.backgroundColor = Color.white;
		GUI.DrawTexture(position, ironToggleBgTex);
		GUI.backgroundColor = backgroundColor;
		Rect position2 = new Rect(position.x + num2, position.y + (position.height - num) / 2f, num, num);
		newSaveIronToggle = GUI.Toggle(position2, newSaveIronToggle, GUIContent.none);
		float num6 = Mathf.Max(vector.y, num);
		GUI.Label(new Rect(position2.xMax + ironToggleLabelOffset, position.y + (position.height - num6) / 2f, ironToggleLabelWidth, num6), text, gUIStyle);
	}

	private Texture2D MakeTex(Color c)
	{
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.SetPixel(0, 0, c);
		texture2D.Apply();
		return texture2D;
	}

	private void DisableRenderersAndColliders(GameObject go)
	{
		if (!(go == null))
		{
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
			Collider[] componentsInChildren2 = go.GetComponentsInChildren<Collider>(includeInactive: true);
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].enabled = false;
			}
		}
	}

	private void EnsureAchievementIconStyle()
	{
		if (achievementIconStyle == null)
		{
			achievementIconStyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = achievementIconFontSize,
				fontStyle = FontStyle.Bold,
				alignment = TextAnchor.UpperLeft
			};
			achievementIconStyle.normal.textColor = achievementIconColor;
			if (newButtonFont != null)
			{
				achievementIconStyle.font = newButtonFont;
			}
		}
	}

	private void EnsureItemStyles()
	{
		if (itemNameStyle == null)
		{
			itemNameStyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = 18,
				fontStyle = FontStyle.Bold,
				alignment = TextAnchor.UpperLeft
			};
		}
		if (itemInfoStyle == null)
		{
			itemInfoStyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = 16,
				alignment = TextAnchor.UpperLeft
			};
		}
	}

	private string BuildCreatedLabel(SaveMetadata meta, bool langRu)
	{
		DateTime dateTime = ParseDate(meta?.createdUtc);
		if (dateTime == DateTime.MinValue)
		{
			dateTime = ParseDate(meta?.updatedUtc);
		}
		if (dateTime == DateTime.MinValue && meta != null)
		{
			try
			{
				string savePath = SaveStorage.GetSavePath(meta);
				if (File.Exists(savePath))
				{
					dateTime = File.GetCreationTime(savePath).ToUniversalTime();
				}
			}
			catch
			{
			}
		}
		if (dateTime == DateTime.MinValue)
		{
			if (!langRu)
			{
				return "创建时间：？";
			}
			return "Создано: ?";
		}
		string text = dateTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
		if (!langRu)
		{
			return "已创建：" + text;
		}
		return "Создано: " + text;
	}

	private DateTime ParseDate(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return DateTime.MinValue;
		}
		if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var result))
		{
			return result;
		}
		return DateTime.MinValue;
	}

	private bool AchievementsAreAvailable()
	{
		return ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null)?.iron_and_blood ?? false;
	}

	private string CurrentRunHash()
	{
		GameState gameState = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null);
		if (gameState == null || gameState.runHash == null)
		{
			return string.Empty;
		}
		return gameState.runHash;
	}

	private bool CanSaveSlot(SaveMetadata meta, bool runHashMode, string runHash)
	{
		if (meta == null)
		{
			return false;
		}
		if (!runHashMode)
		{
			return true;
		}
		if (meta.iron)
		{
			return string.Equals(meta.runHash ?? string.Empty, runHash);
		}
		return false;
	}

	private bool ShowIronToggle(GameState gs, string runHash)
	{
		if (gs != null && gs.iron_and_blood)
		{
			return !string.IsNullOrEmpty(runHash);
		}
		return false;
	}
}
