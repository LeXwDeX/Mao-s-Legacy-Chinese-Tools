using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Savescript : MonoBehaviour
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
			SaveListController.EnsureInstance(this);
		}
	}

	public void OnMouseDown()
	{
		if (!(SaveListController.Instance != null))
		{
			bool flag = number == 5 && GlobalScript.inst.gameState.iron_and_blood;
			PlayerPrefs.SetString("iron" + (number + 10), flag.ToString());
			PlayerPrefs.SetInt("save_diff" + (number + 10), GlobalScript.inst.gameState.diff);
			PlayerPrefs.SetInt("data" + 14 + (number + 10), GlobalScript.inst.gameState.data[14]);
			PlayerPrefs.SetInt("data" + 19 + (number + 10), GlobalScript.inst.gameState.data[19]);
			PlayerPrefs.SetInt("data" + 20 + (number + 10), GlobalScript.inst.gameState.data[20]);
			PlayerPrefs.SetInt("data" + 21 + (number + 10), GlobalScript.inst.gameState.data[21]);
			WriteYugoSave(number);
			if (PlayerPrefs.GetInt("language") == 0)
			{
				Opis.text = "SAVED";
			}
			else
			{
				Opis.text = "СОХРАНЕНО";
			}
		}
	}

	private static string GetSavePath(int num)
	{
		return $"NewData{Path.DirectorySeparatorChar}{num}.save";
	}

	private void WriteYugoSave(int num)
	{
		if (!Directory.Exists("NewData"))
		{
			Directory.CreateDirectory("NewData");
		}
		using FileStream stream = new FileStream(GetSavePath(num), FileMode.Create, FileAccess.Write, FileShare.None, 65536, FileOptions.SequentialScan);
		using BufferedStream bufferedStream = new BufferedStream(stream, 65536);
		Formatter.Serialize(bufferedStream, GlobalScript.inst.gameState);
		bufferedStream.Flush();
	}

	private void OnMouseEnter()
	{
		if (!(SaveListController.Instance != null))
		{
			Opis.text = BuildOpisText(number);
			GetComponent<SpriteRenderer>().sprite = navel;
		}
	}

	private void OnMouseExit()
	{
		if (!(SaveListController.Instance != null))
		{
			GetComponent<SpriteRenderer>().sprite = nenavel;
			Opis.text = "";
		}
	}
}
