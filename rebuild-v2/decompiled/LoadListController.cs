using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class LoadListController : MonoBehaviour
{
	public TextMesh opis;

	[Header("Layout")]
	public float listWidth = 325f;

	public float listHeight = 500f;

	public float entryHeight = 112.5f;

	public float listX = -250f;

	public float listY = 350f;

	public string anchorName = "Button (5)";

	public Vector2 anchorOffset = Vector2.zero;

	public Transform anchor;

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

	private bool achievementsAvailable;

	private GUIStyle achievementIconStyle;

	private GUIStyle itemNameStyle;

	private GUIStyle itemInfoStyle;

	private float baseListWidth;

	private float baseListHeight;

	private float baseEntryHeight;

	private float baseListX;

	private float baseListY;

	private Vector2 baseAnchorOffset;

	public static LoadListController Instance { get; private set; }

	public static LoadListController EnsureInstance(LoadInScript source)
	{
		if (Instance != null)
		{
			return Instance;
		}
		GameObject obj = new GameObject("LoadListController");
		LoadListController loadListController = obj.AddComponent<LoadListController>();
		loadListController.opis = source.Opis;
		ParentToBackground(obj.transform, source.transform);
		obj.AddComponent<sizescript>();
		Instance = loadListController;
		return loadListController;
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
	}

	private void Refresh()
	{
		items.Clear();
		SaveMetadata[] obj = SaveStorage.LoadMetadata()?.items ?? Array.Empty<SaveMetadata>();
		bool flag = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null)?.turn_on ?? false;
		achievementsAvailable = !flag && AchievementsAreAvailable();
		SaveMetadata[] array = obj;
		foreach (SaveMetadata saveMetadata in array)
		{
			if (saveMetadata != null)
			{
				items.Add(saveMetadata);
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

	private void HideLegacySlots()
	{
		LoadInScript[] array = UnityEngine.Object.FindObjectsOfType<LoadInScript>();
		foreach (LoadInScript loadInScript in array)
		{
			if (!(loadInScript == null))
			{
				DisableRenderersAndColliders(loadInScript.gameObject);
				if (!(loadInScript.gameObject != null) || !(loadInScript.gameObject.name == anchorName))
				{
					loadInScript.gameObject.SetActive(value: false);
				}
			}
		}
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

	public void ShowDetails(SaveMetadata meta)
	{
		if (meta != null && !(opis == null))
		{
			opis.text = LoadInScript.BuildOpisText(meta.id, meta);
		}
	}

	public void ClearDetails()
	{
		if (opis != null)
		{
			opis.text = string.Empty;
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
		Rect position = new Rect(x, y, listWidth, listHeight);
		float height = Mathf.Max(listHeight, (float)items.Count * entryHeight + 10f);
		scrollPos = GUI.BeginScrollView(position, scrollPos, new Rect(0f, 0f, listWidth - 20f, height));
		float num = 0f;
		bool flag2 = Event.current.type == EventType.Repaint || Event.current.type == EventType.MouseMove;
		EnsureItemStyles();
		Vector2 mousePosition = Event.current.mousePosition;
		foreach (SaveMetadata item in items)
		{
			Rect position2 = new Rect(0f, num, listWidth - 40f, entryHeight - 10f);
			GUI.Box(position2, string.Empty);
			float num2 = 0f;
			if (item.iron)
			{
				EnsureAchievementIconStyle();
				Vector2 vector = achievementIconStyle.CalcSize(new GUIContent(achievementIcon));
				num2 = vector.x + 4f;
				GUI.Label(new Rect(position2.x + 8f + achievementIconOffset.x, position2.y + 4f + achievementIconOffset.y, vector.x, vector.y), achievementIcon, achievementIconStyle);
			}
			GUI.Label(new Rect(position2.x + 8f + num2, position2.y + 4f, position2.width - 16f - num2, 25f), item.name, itemNameStyle);
			GUI.Label(new Rect(position2.x + 8f, position2.y + 30f, position2.width - 16f, 25f), BuildCreatedLabel(item, flag), itemInfoStyle);
			float num3 = 25f;
			float y2 = position2.y + position2.height - (num3 + 6f);
			float num4 = (position2.width - 20f) / 3f;
			float num5 = position2.x + 6f;
			Rect position3 = new Rect(num5, y2, num4, num3);
			if (GUI.Button(position3, flag ? "Загрузить" : "Load"))
			{
				LoadInScript.LoadSlot(item.id, item.iron);
			}
			Rect position4 = new Rect(num5 + num4 + 4f, y2, num4, num3);
			if (GUI.Button(position4, flag ? "Имя" : "Rename"))
			{
				BeginRename(item);
			}
			Rect position5 = new Rect(num5 + 2f * (num4 + 4f), y2, num4, num3);
			if (GUI.Button(position5, flag ? "Удалить" : "Delete"))
			{
				SaveStorage.Delete(item);
				Refresh();
				break;
			}
			if (flag2 && (position2.Contains(mousePosition) || position3.Contains(mousePosition) || position4.Contains(mousePosition) || position5.Contains(mousePosition)) && opis != null)
			{
				string text = LoadInScript.BuildOpisText(item.id, item);
				text = text.Replace('|', ' ');
				opis.text = text;
			}
			num += entryHeight;
		}
		GUI.EndScrollView();
		if (renaming && renameMeta != null)
		{
			Rect position6 = new Rect(position.xMax + 10f, position.y, 220f, 24f);
			GUI.SetNextControlName("LoadRenameField");
			renameBuffer = GUI.TextField(position6, renameBuffer, 40);
			GUI.FocusControl("LoadRenameField");
			if (GUI.Button(new Rect(position6.x, position6.yMax + 4f, 100f, 24f), Loc("OK", "ОК")) || Event.current.keyCode == KeyCode.Return)
			{
				ApplyRename();
			}
			if (GUI.Button(new Rect(position6.x + 110f, position6.yMax + 4f, 100f, 24f), Loc("Cancel", "Отмена")) || Event.current.keyCode == KeyCode.Escape)
			{
				renaming = false;
				renameMeta = null;
			}
		}
	}

	private void BeginRename(SaveMetadata meta)
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
		string text4 = ((!meta.iron) ? (flag ? "<color=red>Достижения: Недоступны</color>" : "<color=red>Achievements: Unavailable</color>") : (flag ? "<color=red>С достижениями</color>" : "<color=red>With achievements</color>"));
		if (flag)
		{
			return "Имя: " + meta.name + "\nГосстрой: " + text3 + "\nДата: " + text + "\nСложность: " + text2 + "\n" + text4;
		}
		return "Name: " + meta.name + "\nGovernment: " + text3 + "\nDate: " + text + "\nDifficulty: " + text2 + "\n" + text4;
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
			anchorOffset = new Vector2(baseAnchorOffset.x * num, baseAnchorOffset.y * num2);
		}
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
				return "Created: ?";
			}
			return "Создано: ?";
		}
		string text = dateTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
		if (!langRu)
		{
			return "Created: " + text;
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
}
