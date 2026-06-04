using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveStorage
{
	private const string SavesDirectory = "NewData";

	private const string MetaFileName = "saves.json";

	private const int LegacySlotsCount = 4;

	private const int LegacyOffset = 10;

	private const string MetaExtension = ".smeta";

	private static readonly int[] LegacySlots = new int[4] { 1, 2, 3, 4 };

	private static string MetaPath => Path.Combine("NewData", "saves.json");

	public static void EnsureMetadataFile()
	{
		EnsureDirectory();
		if (!File.Exists(MetaPath))
		{
			SaveMetadataFile(new SaveMetadataList
			{
				items = Array.Empty<SaveMetadata>()
			});
		}
	}

	public static string GetSavePath(SaveMetadata meta)
	{
		string text = (string.IsNullOrWhiteSpace(meta.fileBase) ? meta.id.ToString() : meta.fileBase);
		return Path.Combine("NewData", text + ".save");
	}

	public static string GetSavePath(int id)
	{
		SaveMetadata metadataById = GetMetadataById(id);
		if (metadataById != null)
		{
			return GetSavePath(metadataById);
		}
		return Path.Combine("NewData", $"{id}.save");
	}

	private static string GetMetaPath(SaveMetadata meta)
	{
		string text = (string.IsNullOrWhiteSpace(meta.fileBase) ? meta.id.ToString() : meta.fileBase);
		return Path.Combine("NewData", text + ".smeta");
	}

	public static SaveMetadataList LoadMetadata()
	{
		EnsureDirectory();
		if (!File.Exists(MetaPath))
		{
			SaveMetadataList saveMetadataList = MigrateLegacy();
			SaveMetadataFile(saveMetadataList);
			return saveMetadataList;
		}
		try
		{
			SaveMetadataList saveMetadataList2 = JsonUtility.FromJson<SaveMetadataList>(File.ReadAllText(MetaPath));
			if (saveMetadataList2?.items == null)
			{
				return new SaveMetadataList
				{
					items = Array.Empty<SaveMetadata>()
				};
			}
			SaveMetadata[] items = saveMetadataList2.items;
			foreach (SaveMetadata saveMetadata in items)
			{
				if (saveMetadata != null)
				{
					if (string.IsNullOrWhiteSpace(saveMetadata.fileBase))
					{
						saveMetadata.fileBase = saveMetadata.id.ToString();
					}
					if (saveMetadata.runHash == null)
					{
						saveMetadata.runHash = string.Empty;
					}
				}
			}
			return saveMetadataList2;
		}
		catch (Exception arg)
		{
			Debug.LogError($"Failed to read saves metadata: {arg}");
			return new SaveMetadataList
			{
				items = Array.Empty<SaveMetadata>()
			};
		}
	}

	public static void SaveMetadataFile(SaveMetadataList data)
	{
		EnsureDirectory();
		try
		{
			string contents = JsonUtility.ToJson(data, prettyPrint: true);
			File.WriteAllText(MetaPath, contents);
		}
		catch (Exception arg)
		{
			Debug.LogError($"Failed to write saves metadata: {arg}");
		}
	}

	public static SaveMetadata CreateNew(string name, bool iron, string runHash = "")
	{
		SaveMetadataList saveMetadataList = LoadMetadata();
		int num = NextId(saveMetadataList.items);
		string text = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture);
		string fileBase = MakeFileBase(name, num);
		SaveMetadata saveMetadata = new SaveMetadata
		{
			id = num,
			name = (string.IsNullOrWhiteSpace(name) ? $"Save {num}" : name.Trim()),
			fileBase = fileBase,
			createdUtc = text,
			updatedUtc = text,
			iron = iron,
			runHash = (string.IsNullOrEmpty(runHash) ? string.Empty : runHash)
		};
		List<SaveMetadata> list = new List<SaveMetadata>(saveMetadataList.items) { saveMetadata };
		saveMetadataList.items = list.ToArray();
		SaveMetadataFile(saveMetadataList);
		return saveMetadata;
	}

	public static void UpdateMeta(SaveMetadata meta)
	{
		SaveMetadataList saveMetadataList = LoadMetadata();
		List<SaveMetadata> list = new List<SaveMetadata>(saveMetadataList.items);
		int num = list.FindIndex((SaveMetadata m) => m.id == meta.id);
		if (num >= 0)
		{
			list[num] = meta;
			saveMetadataList.items = list.ToArray();
			SaveMetadataFile(saveMetadataList);
		}
		SaveMetaFile(meta);
	}

	public static void Delete(SaveMetadata meta)
	{
		SaveMetadataList saveMetadataList = LoadMetadata();
		List<SaveMetadata> list = new List<SaveMetadata>(saveMetadataList.items);
		list.RemoveAll((SaveMetadata m) => m.id == meta.id);
		saveMetadataList.items = list.ToArray();
		SaveMetadataFile(saveMetadataList);
		string savePath = GetSavePath(meta);
		if (File.Exists(savePath))
		{
			File.Delete(savePath);
		}
		string metaPath = GetMetaPath(meta);
		if (File.Exists(metaPath))
		{
			File.Delete(metaPath);
		}
		PlayerPrefs.DeleteKey("iron" + (meta.id + 10));
		PlayerPrefs.DeleteKey("save_diff" + (meta.id + 10));
		PlayerPrefs.DeleteKey("data14" + (meta.id + 10));
		PlayerPrefs.DeleteKey("data19" + (meta.id + 10));
		PlayerPrefs.DeleteKey("data20" + (meta.id + 10));
		PlayerPrefs.DeleteKey("data21" + (meta.id + 10));
	}

	public static void SaveGame(SaveMetadata meta, GameState state, bool setIronFlag)
	{
		EnsureDirectory();
		meta.day = state.data[19];
		meta.month = state.data[20];
		meta.year = state.data[21];
		meta.diff = state.diff;
		meta.iron = setIronFlag;
		meta.data14 = state.data[14];
		meta.runHash = ((state != null) ? (state.runHash ?? string.Empty) : string.Empty);
		meta.updatedUtc = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture);
		using (FileStream stream = new FileStream(GetSavePath(meta), FileMode.Create, FileAccess.Write, FileShare.None, 65536, FileOptions.SequentialScan))
		{
			using BufferedStream bufferedStream = new BufferedStream(stream, 65536);
			new BinaryFormatter().Serialize(bufferedStream, state);
			bufferedStream.Flush();
		}
		SaveMetaFile(meta);
		UpdateMeta(meta);
	}

	public static SaveMetadata GetMetadataById(int id)
	{
		SaveMetadataList saveMetadataList = LoadMetadata();
		if (saveMetadataList?.items == null)
		{
			return null;
		}
		SaveMetadata[] items = saveMetadataList.items;
		foreach (SaveMetadata saveMetadata in items)
		{
			if (saveMetadata.id == id)
			{
				return saveMetadata;
			}
		}
		return null;
	}

	public static SaveMetadata LoadMetaFile(int id)
	{
		SaveMetadata metadataById = GetMetadataById(id);
		if (metadataById == null)
		{
			return null;
		}
		string metaPath = GetMetaPath(metadataById);
		if (!File.Exists(metaPath))
		{
			return metadataById;
		}
		try
		{
			SaveMetadata saveMetadata = JsonUtility.FromJson<SaveMetadata>(File.ReadAllText(metaPath));
			if (saveMetadata != null)
			{
				if (string.IsNullOrWhiteSpace(saveMetadata.fileBase))
				{
					saveMetadata.fileBase = metadataById.fileBase;
				}
				if (saveMetadata.runHash == null)
				{
					saveMetadata.runHash = metadataById.runHash ?? string.Empty;
				}
				return saveMetadata;
			}
		}
		catch (Exception arg)
		{
			Debug.LogError($"Failed to read smeta for {id}: {arg}");
		}
		return metadataById;
	}

	public static void RenameFiles(SaveMetadata meta, string newName)
	{
		if (meta == null)
		{
			return;
		}
		string text = (string.IsNullOrWhiteSpace(meta.fileBase) ? meta.id.ToString() : meta.fileBase);
		string text2 = MakeFileBase(newName, meta.id);
		if (text == text2)
		{
			return;
		}
		string text3 = Path.Combine("NewData", text + ".save");
		string text4 = Path.Combine("NewData", text + ".smeta");
		string destFileName = Path.Combine("NewData", text2 + ".save");
		string destFileName2 = Path.Combine("NewData", text2 + ".smeta");
		try
		{
			if (File.Exists(text3))
			{
				File.Move(text3, destFileName);
			}
			if (File.Exists(text4))
			{
				File.Move(text4, destFileName2);
			}
			meta.fileBase = text2;
			SaveMetaFile(meta);
			UpdateMeta(meta);
		}
		catch (Exception arg)
		{
			Debug.LogError($"Failed to rename save files: {arg}");
		}
	}

	private static SaveMetadataList MigrateLegacy()
	{
		List<SaveMetadata> list = new List<SaveMetadata>();
		int[] legacySlots = LegacySlots;
		for (int i = 0; i < legacySlots.Length; i++)
		{
			int num = legacySlots[i];
			int num2 = num + 10;
			bool num3 = PlayerPrefs.HasKey("data14" + num2) || PlayerPrefs.HasKey("save_diff" + num2);
			bool flag = File.Exists(GetSavePath(num));
			if (num3 || flag)
			{
				SaveMetadata saveMetadata = new SaveMetadata
				{
					id = num,
					name = $"Save {num}",
					fileBase = num.ToString(),
					day = PlayerPrefs.GetInt("data19" + num2, 1),
					month = PlayerPrefs.GetInt("data20" + num2, 1),
					year = PlayerPrefs.GetInt("data21" + num2, 1970),
					diff = PlayerPrefs.GetInt("save_diff" + num2, 0),
					iron = false,
					data14 = PlayerPrefs.GetInt("data14" + num2, -1),
					runHash = string.Empty,
					createdUtc = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
					updatedUtc = DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture)
				};
				SaveMetaFile(saveMetadata);
				list.Add(saveMetadata);
			}
		}
		return new SaveMetadataList
		{
			items = list.ToArray()
		};
	}

	private static int NextId(IEnumerable<SaveMetadata> items)
	{
		int num = 0;
		foreach (SaveMetadata item in items)
		{
			if (item.id > num)
			{
				num = item.id;
			}
		}
		return num + 1;
	}

	private static void EnsureDirectory()
	{
		if (!Directory.Exists("NewData"))
		{
			Directory.CreateDirectory("NewData");
		}
	}

	private static string MakeFileBase(string name, int id)
	{
		string text = (string.IsNullOrWhiteSpace(name) ? $"save_{id}" : name.Trim());
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		foreach (char oldChar in invalidFileNameChars)
		{
			text = text.Replace(oldChar, '_');
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = $"save_{id}";
		}
		return text;
	}

	public static string CreateRunHash()
	{
		string text = DateTime.UtcNow.Ticks.ToString("x");
		string text2 = ((uint)UnityEngine.Random.Range(0, int.MaxValue)).ToString("x");
		string text3 = text + text2;
		if (text3.Length < 18)
		{
			return text3.PadRight(18, '0');
		}
		return text3.Substring(0, 18);
	}

	private static void SaveMetaFile(SaveMetadata meta)
	{
		try
		{
			string contents = JsonUtility.ToJson(meta, prettyPrint: true);
			File.WriteAllText(GetMetaPath(meta), contents);
		}
		catch (Exception arg)
		{
			Debug.LogError($"Failed to write smeta for {meta?.id}: {arg}");
		}
	}
}
