using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LFKG;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInScript : MonoBehaviour
{
	private const int StreamBufferSize = 65536;

	private static readonly BinaryFormatter Formatter = new BinaryFormatter();

	public int number;

	public GlobalScript global1;

	public TextMesh Opis;

	public Sprite navel;

	public Sprite nenavel;

	public static bool from_string(string str)
	{
		if (str == "True")
		{
			return true;
		}
		return false;
	}

	public static string BuildOpisText(int number, SaveMetadata providedMeta = null)
	{
		bool flag = PlayerPrefs.GetInt("language") != 0;
		SaveMetadata saveMetadata = providedMeta ?? SaveStorage.LoadMetaFile(number);
		bool flag2 = saveMetadata?.iron ?? false;
		string text = ((!flag) ? (flag2 ? "With achievements" : "Without achievements") : (flag2 ? "С достижениями" : "Без достижений"));
		if (saveMetadata != null)
		{
			string[] array = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null)?.doctr;
			int data = saveMetadata.data14;
			int day = saveMetadata.day;
			int month = saveMetadata.month;
			int year = saveMetadata.year;
			int diff = saveMetadata.diff;
			string text2 = ((array != null && data >= 0 && data < array.Length) ? array[data] : "?");
			string text3 = diff switch
			{
				0 => flag ? "Песочница" : "Sandbox", 
				1 => flag ? "Лёгкий" : "Easy", 
				2 => flag ? "Стандарт" : "Normal", 
				3 => flag ? "Тяжёлый" : "Hard", 
				4 => flag ? "Культурная революция" : "Cultural Revolution", 
				_ => diff.ToString(), 
			};
			if (flag)
			{
				text = text + "\nГосстрой: " + text2;
				text = text + "\nДата: " + day + "." + month + "." + year;
				text = text + "\nСложность: " + text3;
				text += "\nДостижения: ";
			}
			else
			{
				text = text + "\nSystem: " + text2;
				text = text + "\nDate: " + day + "." + month + "." + year;
				text = text + "\nDifficulty: " + text3;
				text += "\nAchievements: ";
			}
			if (saveMetadata.iron)
			{
				return text + (flag ? "<color=red>Доступны</color>" : "<color=red>Available</color>");
			}
			return text + (flag ? "<color=red>Недоступны</color>" : "<color=red>Unavailable</color>");
		}
		return text + (flag ? "\nПустой слот" : "\nEmpty Slot");
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (number != 5)
		{
			LoadListController.EnsureInstance(this);
		}
	}

	public void OnMouseDown()
	{
		if (!(LoadListController.Instance != null))
		{
			LoadSlot(number, number == 5, Opis);
		}
	}

	public static void LoadSlot(int slotId, bool ironFlag, TextMesh opis = null)
	{
		GlobalScript.inst.gameState.is_save_bylo = true;
		if (!PlayerPrefs.HasKey("data14" + (slotId + 10)))
		{
			return;
		}
		if (!File.Exists(SaveStorage.GetSavePath(slotId)))
		{
			if (opis != null)
			{
				opis.text = ((PlayerPrefs.GetInt("language") == 0) ? "Save file missing" : "Файл сохранения не найден");
			}
			return;
		}
		LoadYugoSave(slotId);
		if (!ironFlag)
		{
			GlobalScript.inst.gameState.iron_and_blood = false;
		}
		int num = PlayerPrefs.GetInt("language");
		string text = "";
		string[] array = text.Split(':');
		TextAsset textAsset = ((num != 0) ? (Resources.Load($"Part{GlobalScript.inst.gameState.PlayerCountry}_ru") as TextAsset) : (Resources.Load($"Part{GlobalScript.inst.gameState.PlayerCountry}_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split(':');
		text = null;
		int num2 = 0;
		if (num2 < array.Length)
		{
			string[] array2 = array[num2].Split(';');
			for (int i = 0; i < GlobalScript.inst.gameState.party_name.Length; i++)
			{
				GlobalScript.inst.gameState.party_name[i] = array2[i + 1];
			}
		}
		textAsset = ((num != 0) ? (Resources.Load("Doctr_ru") as TextAsset) : (Resources.Load("Doctr_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split(';');
		text = null;
		for (int j = 0; j < array.Length; j++)
		{
			GlobalScript.inst.gameState.doctr[j] = array[j];
		}
		textAsset = ((num != 0) ? (Resources.Load($"polit_names{GlobalScript.inst.gameState.PlayerCountry}_ru") as TextAsset) : (Resources.Load(string.Format($"polit_names{GlobalScript.inst.gameState.PlayerCountry}_en")) as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split('\n');
		text = null;
		GlobalScript.inst.gameState.names1 = new string[array.Length];
		for (int k = 0; k < array.Length; k++)
		{
			GlobalScript.inst.gameState.names1[k] = array[k];
		}
		textAsset = ((num != 0) ? (Resources.Load($"polit_surnames{GlobalScript.inst.gameState.PlayerCountry}_ru") as TextAsset) : (Resources.Load($"polit_surnames{GlobalScript.inst.gameState.PlayerCountry}_en") as TextAsset));
		text = textAsset.text;
		Resources.UnloadAsset(textAsset);
		textAsset = null;
		array = text.Split('\n');
		text = null;
		GlobalScript.inst.gameState.names2 = new string[array.Length];
		for (int l = 0; l < array.Length; l++)
		{
			GlobalScript.inst.gameState.names2[l] = array[l];
		}
		TextAsset textAsset2 = Resources.Load(string.Format("new_texts_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.new_texts = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("new_modify_texts_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.new_modify_texts = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("new_modify_opis_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.new_modify_desc = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("old_modify_text_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.old_modify_texts = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("old_modify_opis_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.old_modify_desc = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("Events_text_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.new_events_text = textAsset2.text.Split('\n');
		textAsset2 = Resources.Load(string.Format("new_focuses_texts_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		FocusReader.CreateDictionary();
		FocusReader.ReadFocuses(textAsset2.text);
		textAsset2 = Resources.Load(string.Format("new_event_text_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		textAsset2 = Resources.Load(string.Format("other_text_{0}", (num == 0) ? "en" : "ru")) as TextAsset;
		GlobalScript.inst.other_text = textAsset2.text.Split('\n');
		GlobalScript.inst.CreateDecisions();
		GlobalScript.inst.CreateDecisions();
		SceneManager.LoadScene("Diplomacy");
	}

	public static void LoadYugoSave(int num)
	{
		SaveMetadata metadataById = SaveStorage.GetMetadataById(num);
		string path = ((metadataById != null) ? SaveStorage.GetSavePath(metadataById) : GetSavePath(num));
		if (!File.Exists(path))
		{
			return;
		}
		using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, FileOptions.SequentialScan);
		using BufferedStream serializationStream = new BufferedStream(stream, 65536);
		GlobalScript.inst.gameState = Formatter.Deserialize(serializationStream) as GameState;
	}

	private static string GetSavePath(int num)
	{
		return $"NewData{Path.DirectorySeparatorChar}{num}.save";
	}

	private void OnMouseEnter()
	{
		if (!(LoadListController.Instance != null))
		{
			Opis.text = BuildOpisText(number);
			GetComponent<SpriteRenderer>().sprite = navel;
		}
	}

	private void OnMouseExit()
	{
		if (!(LoadListController.Instance != null))
		{
			GetComponent<SpriteRenderer>().sprite = nenavel;
			Opis.text = "";
		}
	}
}
