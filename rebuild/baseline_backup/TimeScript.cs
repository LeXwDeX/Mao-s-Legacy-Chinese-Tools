using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using KGFocus;
using ModifiesInfluenceSpace;
using ReqEventsDLC02;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
	public GameObject ending;

	public bool is_showed;

	private int save_speed;

	private int this_num_event;

	private int this_num_place;

	private GlobalScript global1;

	private GameState global2;

	public float now_time;

	public EvetnnashScript goto_economy;

	private SpeedScript goto_pause;

	public GameObject dlc_button;

	public GameObject dlc_button2;

	public GameObject numPlayersAlert;

	public GameObject isAchievementsActive;

	public GameObject isAchievementsDeactive;

	public GameObject warSpecialWindow;

	public GameObject citizenDlcButton;

	public GameObject[] alarmIcons = new GameObject[6];

	public GameObject probel;

	public GameObject firstS;

	public GameObject secondS;

	public GameObject thirdS;

	public SpriteRenderer[] crisis = new SpriteRenderer[8];

	public TextMesh[] crisis_color = new TextMesh[8];

	public TextMesh thisText;

	public bool vybory;

	private GameObject achieves;

	public GameObject crisis_show;

	private bool donedone;

	public at_war_script[] re_war = new at_war_script[11];

	public Savescript Autosavej;

	public LoadInScript Autoloadej;

	public int ch_support;

	public int ch_profit;

	public int ch_lib;

	private bool event44;

	private MapChangesScript map1;

	public GameObject[] events = new GameObject[26];

	public void Awake()
	{
		global2 = GlobalScript.inst.gameState;
		map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		global1 = GlobalScript.inst;
		goto_pause = GameObject.Find("Button (0)").GetComponent<SpeedScript>();
		achieves = GameObject.Find("Ach(Clone)");
		Repaint(need_to_pluse: false);
		for (int i = 0; i < re_war.Length; i++)
		{
			re_war[i].Repaint();
		}
		AlarmIconChange();
		if (!global1.dlc[0] || global2.gamerules[0] < 1)
		{
			dlc_button.SetActive(value: false);
		}
		if (!global1.dlc[1] && !global1.dlc[3])
		{
			dlc_button2.SetActive(value: false);
		}
		if (!global1.dlc[5])
		{
			warSpecialWindow.SetActive(value: false);
		}
		if (!global1.dlc[8])
		{
			citizenDlcButton.SetActive(value: false);
		}
		if (!global1.dlc[0] || global2.gamerules[1] < 1)
		{
			numPlayersAlert.SetActive(value: false);
		}
		else if (global1.dlc[0] && global2.gamerules[1] > 0)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				numPlayersAlert.GetComponent<OkoshkoScript>().text_en = global2.GetCompassText();
			}
			else
			{
				numPlayersAlert.GetComponent<OkoshkoScript>().text = global2.GetCompassText();
			}
		}
		if (global2.iron_and_blood)
		{
			isAchievementsActive.SetActive(value: true);
			isAchievementsDeactive.SetActive(value: false);
		}
		else
		{
			isAchievementsActive.SetActive(value: false);
			isAchievementsDeactive.SetActive(value: true);
		}
	}

	private void AlarmIconChange()
	{
		for (int i = 0; i < global2.politics_dolshnost.Length; i++)
		{
			if (global2.politics_dolshnost[i] == 200)
			{
				alarmIcons[2].SetActive(value: true);
				break;
			}
		}
		if (global2.leader.is_sagovor || global2.data[1] - 70 <= 300 + global2.data[4] / 5 - (global2.data[3] - 500) / 5)
		{
			alarmIcons[1].SetActive(value: true);
		}
		if (global2.leader.is_sleshka)
		{
			alarmIcons[0].SetActive(value: true);
		}
		if ((global2.modifies[16].active && global2.allcountries[1].isSEV && GlobalScript.inst.dlc[3]) || (global2.data[139] > 0 && global2.data[140] > 0))
		{
			alarmIcons[3].GetComponent<OkoshkoScript>().text_en = (alarmIcons[3].GetComponent<OkoshkoScript>().text = string.Format(GlobalScript.inst.other_text[250], global2.data[139]));
			alarmIcons[3].SetActive(value: true);
		}
		else
		{
			alarmIcons[3].SetActive(value: false);
		}
		if ((global2.modifies[17].active && global2.allcountries[1].isASEAN && GlobalScript.inst.dlc[3]) || (global2.data[139] > 0 && global2.data[140] > 0))
		{
			alarmIcons[4].GetComponent<OkoshkoScript>().text_en = (alarmIcons[4].GetComponent<OkoshkoScript>().text = string.Format(GlobalScript.inst.other_text[251], global2.data[139]));
			alarmIcons[4].SetActive(value: true);
			Debug.Log("ХУЙ ХУЙ ХУЙ");
		}
		else
		{
			alarmIcons[4].SetActive(value: false);
		}
		if (global2.data[141] > 0 && GlobalScript.inst.dlc[3] && (global2.allcountries[1].isOVD || global2.allcountries[1].isSEATO))
		{
			alarmIcons[5].GetComponent<OkoshkoScript>().text_en = (alarmIcons[5].GetComponent<OkoshkoScript>().text = string.Format(global2.allcountries[1].isOVD ? GlobalScript.inst.other_text[290] : GlobalScript.inst.other_text[291], global2.allcountries[global2.data[141]].name, global2.data[142]));
			alarmIcons[5].SetActive(value: true);
		}
		else
		{
			alarmIcons[5].SetActive(value: false);
		}
		if (global2.war > 0)
		{
			alarmIcons[6].SetActive(value: true);
		}
		else
		{
			alarmIcons[6].SetActive(value: false);
		}
	}

	private void AutoSaveMethod()
	{
		GameState gameState = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null);
		if (gameState == null)
		{
			return;
		}
		bool iron_and_blood = gameState.iron_and_blood;
		string text = (iron_and_blood ? (gameState.runHash ?? string.Empty) : string.Empty);
		if (iron_and_blood && string.IsNullOrEmpty(text))
		{
			text = (gameState.runHash = SaveStorage.CreateRunHash());
		}
		SaveMetadata[] array = SaveStorage.LoadMetadata()?.items ?? Array.Empty<SaveMetadata>();
		SaveMetadata saveMetadata = null;
		if (iron_and_blood && !string.IsNullOrEmpty(text))
		{
			SaveMetadata[] array2 = array;
			foreach (SaveMetadata saveMetadata2 in array2)
			{
				if (saveMetadata2 != null && saveMetadata2.iron && string.Equals(saveMetadata2.runHash ?? string.Empty, text))
				{
					saveMetadata = saveMetadata2;
					break;
				}
			}
		}
		if (!iron_and_blood)
		{
			saveMetadata = SaveStorage.CreateNew(BuildAutoSaveName(gameState), iron: false, string.Empty);
			SaveStorage.SaveGame(saveMetadata, gameState, setIronFlag: false);
			SyncPlayerPrefs(saveMetadata, gameState);
		}
		else if (saveMetadata != null)
		{
			SaveStorage.SaveGame(saveMetadata, gameState, setIronFlag: true);
			SyncPlayerPrefs(saveMetadata, gameState);
		}
		else
		{
			saveMetadata = SaveStorage.CreateNew(BuildIronAutoName(array), iron: true, text);
			SaveStorage.SaveGame(saveMetadata, gameState, setIronFlag: true);
			SyncPlayerPrefs(saveMetadata, gameState);
		}
		thisText.text = GlobalScript.inst.new_texts[662];
	}

	private void AutoLoadMethod()
	{
		GameState gameState = ((GlobalScript.inst != null) ? GlobalScript.inst.gameState : null);
		bool flag = PlayerPrefs.GetInt("language") != 0;
		string text = (flag ? "Нет доступного сейва" : "No save available");
		string text2 = ((GlobalScript.inst != null && GlobalScript.inst.new_texts != null && GlobalScript.inst.new_texts.Length > 663) ? GlobalScript.inst.new_texts[663] : (flag ? "Загружено" : "Loaded"));
		if (gameState == null)
		{
			thisText.text = text;
			return;
		}
		bool iron_and_blood = gameState.iron_and_blood;
		string text3 = (iron_and_blood ? (gameState.runHash ?? string.Empty) : string.Empty);
		SaveMetadata[] array = SaveStorage.LoadMetadata()?.items ?? Array.Empty<SaveMetadata>();
		if (iron_and_blood)
		{
			if (string.IsNullOrEmpty(text3))
			{
				thisText.text = text;
				return;
			}
			SaveMetadata saveMetadata = null;
			SaveMetadata[] array2 = array;
			foreach (SaveMetadata saveMetadata2 in array2)
			{
				if (saveMetadata2 != null && saveMetadata2.iron && string.Equals(saveMetadata2.runHash ?? string.Empty, text3))
				{
					saveMetadata = saveMetadata2;
					break;
				}
			}
			if (saveMetadata == null)
			{
				thisText.text = text;
				return;
			}
			LoadInScript.LoadSlot(saveMetadata.id, saveMetadata.iron);
			thisText.text = text2;
		}
		else
		{
			SaveMetadata saveMetadata3 = FindLatestNonIron(array);
			if (saveMetadata3 == null)
			{
				thisText.text = text;
				return;
			}
			LoadInScript.LoadSlot(saveMetadata3.id, saveMetadata3.iron);
			thisText.text = text2;
		}
	}

	private string BuildAutoSaveName(GameState gs)
	{
		if (gs == null || gs.data == null || gs.data.Length < 22)
		{
			return "AutoSave";
		}
		return $"AutoSave_{gs.data[21]:0000}-{gs.data[20]:00}-{gs.data[19]:00}";
	}

	private string BuildIronAutoName(IEnumerable<SaveMetadata> items)
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (SaveMetadata item in items)
		{
			if (item != null && !string.IsNullOrEmpty(item.name))
			{
				hashSet.Add(item.name);
			}
		}
		int num = 0;
		string text;
		while (true)
		{
			text = $"Save_Iron_And_blood_{num}";
			if (!hashSet.Contains(text))
			{
				break;
			}
			num++;
		}
		return text;
	}

	private SaveMetadata FindLatestNonIron(IEnumerable<SaveMetadata> items)
	{
		SaveMetadata result = null;
		DateTime dateTime = DateTime.MinValue;
		foreach (SaveMetadata item in items)
		{
			if (item != null && !item.iron)
			{
				DateTime dateTime2 = ParseMetaTime(item);
				if (dateTime2 > dateTime)
				{
					dateTime = dateTime2;
					result = item;
				}
			}
		}
		return result;
	}

	private void SyncPlayerPrefs(SaveMetadata meta, GameState gs)
	{
		if (meta != null && gs != null && gs.data != null && gs.data.Length >= 22)
		{
			int num = meta.id + 10;
			PlayerPrefs.SetString("iron" + num, meta.iron.ToString());
			PlayerPrefs.SetInt("save_diff" + num, gs.diff);
			PlayerPrefs.SetInt("data" + 14 + num, gs.data[14]);
			PlayerPrefs.SetInt("data" + 19 + num, gs.data[19]);
			PlayerPrefs.SetInt("data" + 20 + num, gs.data[20]);
			PlayerPrefs.SetInt("data" + 21 + num, gs.data[21]);
		}
	}

	private DateTime ParseMetaTime(SaveMetadata meta)
	{
		if (meta != null && !string.IsNullOrEmpty(meta.updatedUtc) && DateTime.TryParse(meta.updatedUtc, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var result))
		{
			return result;
		}
		try
		{
			string savePath = SaveStorage.GetSavePath(meta);
			if (File.Exists(savePath))
			{
				return File.GetLastWriteTimeUtc(savePath);
			}
		}
		catch
		{
		}
		return DateTime.MinValue;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !is_showed)
		{
			probel.GetComponent<SpeedScript>().Probel();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1) && !is_showed)
		{
			firstS.GetComponent<SpeedScript>().FirstSpeed();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) && !is_showed)
		{
			secondS.GetComponent<SpeedScript>().FirstSpeed();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) && !is_showed)
		{
			thirdS.GetComponent<SpeedScript>().FirstSpeed();
		}
		else if (Input.GetKeyDown(KeyCode.F5) && !is_showed)
		{
			AutoSaveMethod();
		}
		else if (Input.GetKeyDown(KeyCode.F9) && !is_showed)
		{
			AutoLoadMethod();
		}
		now_time += (float)global1.speed * Time.deltaTime;
		if (now_time >= 8f)
		{
			now_time = 0f;
			Repaint(need_to_pluse: true);
			KumihaRepaint();
		}
	}

	private void KumihaRepaint()
	{
		global2.data[28] = global2.empires[0].relations;
		global2.data[29] = global2.empires[1].relations;
		global2.data[7] = global2.influencePRC;
	}

	public void Reborn()
	{
		if (!is_showed)
		{
			ending.SetActive(value: true);
			is_showed = true;
			save_speed = global1.speed;
			global1.speed = 0;
		}
		else
		{
			is_showed = false;
			ending.SetActive(value: false);
		}
	}

	private void Reelect(int event_n)
	{
		if (event_n == 2)
		{
			vybory = false;
			global2.is_elect = true;
		}
		global1.speed = 0;
		global2.event_done[event_n] = true;
		global2.number_event = event_n;
		SceneManager.LoadScene("Event");
	}

	private void ToEnding(int ending_n)
	{
		global1.speed = 0;
		global2.data[35] = ending_n;
		SceneManager.LoadScene("Ending");
	}

	private void PlotPlayer()
	{
		if (global2.data[38] < 100)
		{
			return;
		}
		for (int i = 0; i < global2.politics.Length; i++)
		{
			if (global2.politics.Where((Politic pol) => ((pol.loyality < 300 && pol.traits[2] == 16) || pol.you_fall || (pol.loyality < 150 && pol.traits[2] != 9) || (pol.loyality < 50 && pol.traits[2] == 9)) && pol.traits[2] != 17 && pol.traits[2] != 19 && !pol.is_sledstvie).Sum((Politic pol) => pol.power) / 5 > global2.data[1])
			{
				Reelect(4);
			}
		}
	}

	private void PlotPlayerCause()
	{
		for (int i = 0; i < global2.politics.Length; i++)
		{
			if (global2.politics.Where((Politic pol) => ((pol.loyality < 300 && pol.traits[2] == 16) || pol.you_fall || (pol.loyality < 150 && pol.traits[2] != 9) || (pol.loyality < 50 && pol.traits[2] == 9)) && pol.traits[2] != 17 && pol.traits[2] != 19 && !pol.is_sledstvie).Sum((Politic pol) => pol.power) / 5 > global2.data[1] / 4 * 3)
			{
				alarmIcons[1].SetActive(value: true);
				global2.leader.is_sagovor = true;
			}
			else
			{
				alarmIcons[1].SetActive(value: false);
				global2.leader.is_sagovor = false;
			}
		}
	}

	private void PlotPolitics()
	{
		if (global2.data[38] < 100 || global2.gamerules[4] == 3)
		{
			return;
		}
		int i;
		for (i = 0; i < global2.politics.Length; i++)
		{
			if (global2.politics[i].power <= 250 && global2.gamerules[4] != 1 && (global2.gamerules[4] != 2 || global2.politics[i].traits[2] != 16))
			{
				continue;
			}
			double num = 0.0;
			if (!global1.dlc[0] || global2.gamerules[4] < 2)
			{
				num = global2.politics.Where((Politic pol) => ((pol.loyality_to_other[i] < 450 && pol.traits[2] == 16) || (pol.loyality_to_other[i] < 300 && pol.traits[2] != 9) || (pol.loyality_to_other[i] < 150 && pol.traits[2] == 9)) && pol.traits[2] != 17 && pol.traits[2] != 19 && !pol.is_sledstvie).Sum((Politic pol) => pol.power);
			}
			else if (global1.dlc[0] && global2.gamerules[4] == 2)
			{
				num = global2.politics.Where((Politic pol) => pol.traits[2] == 16 && !pol.is_sledstvie).Sum((Politic pol) => pol.power);
			}
			double num2 = 3.0;
			if (global2.politics[i].traits[2] == 14 || global2.politics[i].traits[2] == 13)
			{
				num2 = 5.0;
			}
			else if (global2.politics[i].traits[2] == 12 || global2.politics[i].traits[1] == 6)
			{
				num2 = 2.0;
			}
			if (global2.politics_dolshnost[0] == i)
			{
				num2 += 2.0;
			}
			if (global2.politics_dolshnost[1] == i)
			{
				num2 += 1.0;
			}
			if (global2.politics_dolshnost[2] == i)
			{
				num2 += 1.0;
			}
			if (num > num2 * (double)global2.politics[i].power)
			{
				global2.politics[i].is_sagovor = true;
				if (UnityEngine.Random.Range(0, 11) <= global2.data[57] / 100 || UnityEngine.Random.Range(0, 22) <= global2.data[57] / 50 || UnityEngine.Random.Range(0, 44) <= global2.data[57] / 25)
				{
					continue;
				}
				if (num > num2 * 4.0 * (double)global2.politics[i].power && ((i > 5 && i != 7 && (i < 11 || i > 15) && i != 17) || (global2.event_done[25] && global2.data[84] != 3 && (i < 12 || i > 15)) || (global2.event_done[26] && (global2.leader.name_1 != 0 || i == 1)) || global2.data[21] >= 1978 || (global2.event_done[25] && global2.data[84] == 3 && (i < 1 || i > 4))))
				{
					if (global2.politics_dolshnost[0] != i && global2.politics_dolshnost[1] != i && global2.politics_dolshnost[2] != i)
					{
						Debug.Log("УБИТ");
						global2.KillPerson(i);
						continue;
					}
					Debug.Log("СНЯТ С ПОСТА");
					if (global2.politics_dolshnost[0] == i)
					{
						global2.politics_dolshnost[0] = 200;
					}
					if (global2.politics_dolshnost[1] == i)
					{
						global2.politics_dolshnost[1] = 200;
					}
					if (global2.politics_dolshnost[2] == i)
					{
						global2.politics_dolshnost[2] = 200;
					}
					global2.politics[i].power = 100;
				}
				else
				{
					Debug.Log("ПОНИЖЕН");
					global2.politics[i].power -= global2.politics[i].power / 10;
				}
			}
			else
			{
				global2.politics[i].is_sagovor = false;
			}
		}
	}

	private void DeathPolitics()
	{
		for (int i = 0; i < global2.politics.Length; i++)
		{
			if (global2.politics[i].age >= (byte)UnityEngine.Random.Range(91, 95) && (!global1.dlc[0] || (global1.dlc[0] && global2.gamerules[6] != 2)) && global2.data[38] >= 100)
			{
				global2.KillPerson(i);
			}
			else if (((global2.politics[i].age >= (byte)UnityEngine.Random.Range(80, 84) && global2.politics[i].traits[0] != 2) || (global2.politics[i].age >= (byte)UnityEngine.Random.Range(85, 89) && global2.politics[i].traits[0] == 2)) && global2.politics[i].traits[2] != 19 && (!global1.dlc[0] || (global1.dlc[0] && global2.gamerules[6] != 2)) && global2.data[38] >= 100)
			{
				global2.politics[i].traits[2] = 19;
			}
			if (global1.dlc[0] && global2.gamerules[6] == 1)
			{
				if (global2.data[19] == 1 && global2.data[20] == 1)
				{
					global2.politics[i].in_power++;
				}
				if (global2.politics[i].in_power >= 5)
				{
					global2.KillPerson(i);
				}
			}
		}
	}

	private void Repaint(bool need_to_pluse)
	{
		if (need_to_pluse)
		{
			if (global2.data[8] < 0)
			{
				if (global2.data[36] + (global2.data[8] + global2.data[36]) >= 0)
				{
					global2.data[36] += global2.data[8];
					global2.data[8] = 0;
				}
				else
				{
					global2.data[8] += global2.data[36];
					global2.data[36] = 0;
					if (global2.data[8] < 0)
					{
						global1.speed = 0;
						goto_economy.OnMouseDown();
					}
				}
			}
			bool flag = false;
			for (int i = 0; i < global2.politics_dolshnost.Length; i++)
			{
				if (global2.politics_dolshnost[i] == 200)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				alarmIcons[2].SetActive(value: true);
			}
			else
			{
				alarmIcons[2].SetActive(value: false);
			}
			_ = global2.data[34];
			int[] array = new int[global2.data_old.Length];
			for (int j = 1; j < global2.data_old.Length; j++)
			{
				array[j] = global2.data[j];
			}
			array[28] = global2.empires[0].relations;
			array[29] = global2.empires[1].relations;
			array[7] = global2.influencePRC;
			thisText.text = null;
			if (is_showed)
			{
				save_speed = global1.speed;
				global1.speed = 0;
			}
			global2.data[19]++;
			if ((global2.data[20] == 2 && global2.data[19] == 29 && ((global2.data[21] % 4 != 0 && global2.data[21] % 400 != 0) || global2.data[21] % 100 == 0)) || (global2.data[20] == 2 && global2.data[19] == 30 && ((global2.data[21] % 4 == 0 && global2.data[21] % 100 != 0) || global2.data[21] % 400 == 0)) || (global2.data[19] == 31 && (global2.data[20] == 4 || global2.data[20] == 6 || global2.data[20] == 9 || global2.data[20] == 11)) || (global2.data[19] == 32 && (global2.data[20] == 1 || global2.data[20] == 3 || global2.data[20] == 5 || global2.data[20] == 7 || global2.data[20] == 8 || global2.data[20] == 10 || global2.data[20] == 12)))
			{
				global2.data[19] = 1;
				global2.data[20]++;
				global2.bylo = false;
			}
			if (global2.data[20] == 13)
			{
				global2.data[20] = 1;
				global2.data[21]++;
				global2.data[119] = UnityEngine.Random.Range(1, 7);
				global2.data[121] = UnityEngine.Random.Range(7, 13);
				for (int k = 0; k < global2.politics.Length; k++)
				{
					if (!global2.politics[k].isCitizen)
					{
						Politic politic = global2.politics[k];
						politic.age++;
					}
				}
				if (global2.data[15] > 7)
				{
					global2.data[125]++;
				}
				global2.is_elect = false;
				global2.data[24] += global2.ImportChange(global2);
				if (global2.data[24] < 10)
				{
					global2.data[24] = 10;
				}
				if (global2.diff == 4)
				{
					global2.data[24]++;
				}
				if (global2.data[106] > 1 && (global2.data[15] == 8 || global2.data[15] == 7))
				{
					global2.data[106] = global2.data[106] / 2;
				}
			}
			WorldWarsDone();
			for (int l = 2; l < global2.allcountries.Length; l++)
			{
				if (global2.allcountries[l].EAF)
				{
					global2.allcountries[l].LeaveAlliances();
					global2.allcountries[l].Gosstroy = global2.allcountries[1].Gosstroy;
					global2.allcountries[l].SubGosstroy = global2.allcountries[1].SubGosstroy;
					global2.allcountries[l].econ = global2.allcountries[1].econ;
					global2.allcountries[l].okb = global2.allcountries[1].okb;
					global2.allcountries[l].isASEAN = global2.allcountries[1].isASEAN;
					global2.allcountries[l].isSEV = global2.allcountries[1].isSEV;
					global2.allcountries[l].isSEATO = global2.allcountries[1].isSEATO;
					global2.allcountries[l].isSENTO = global2.allcountries[1].isSENTO;
					global2.allcountries[l].puppetOf = 1;
					global2.allcountries[l].proprc = true;
				}
				if (global2.allcountries[l].proprc)
				{
					global2.allcountries[l].prosov = false;
					global2.allcountries[l].Vyshi = false;
				}
			}
			if (global2.data[19] == 1 && global2.data[20] == 1 && global2.data[21] == 1986)
			{
				Debug.Log("it just works");
				Reborn();
			}
			else if (global2.data[19] == 1 && global2.data[20] == 1 && global2.data[21] == 1980)
			{
				if (global2.iron_and_blood)
				{
					if (global2.data[34] >= 10000)
					{
						achieves.GetComponent<achievements>().Set(63);
					}
					if (global2.data[12] >= 700 && global2.data[13] >= 700 && global2.data[68] >= 700)
					{
						achieves.GetComponent<achievements>().Set(62);
					}
				}
			}
			else if (global2.data[19] == 1 && global2.data[20] == 1 && global2.data[21] == 1983)
			{
				Leader leader = global2.empires[1].leaders[5];
				leader.support++;
			}
			else if (global2.data[19] == 1 && global2.data[20] == 3 && global2.data[21] == 1977)
			{
				Leader leader = global2.empires[1].leaders[6];
				leader.support++;
			}
			else if (global2.data[19] == 1 && global2.data[20] == 11 && global2.data[21] == 1978)
			{
				Leader leader = global2.empires[1].leaders[6];
				leader.support++;
			}
			if (global2.data[34] < 6671)
			{
				ToEnding(4);
			}
			if (global2.data[15] > 7 && global2.data[19] == 1 && global2.data[20] == 10 && (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] <= 0))
			{
				vybory = true;
				global2.is_elect = true;
				Reelect(1);
			}
			if (global2.allcountries[12].isSEV && global2.allcountries[12].Vyshi)
			{
				global2.allcountries[12].Vyshi = false;
			}
			if (global2.data[21] >= 1978 && !global2.event_done[44])
			{
				int num = 0;
				int num2 = 0;
				for (int m = 0; m < global2.politics.Length; m++)
				{
					if (global2.politics[m].traits[0] == 2)
					{
						num += global2.politics[m].power;
					}
					else if (global2.politics[m].traits[0] == 0)
					{
						num2 += global2.politics[m].power;
					}
				}
				if (num >= num2)
				{
					event44 = true;
				}
			}
			if (global2.data[19] == 1 && (global2.data[20] == 1 || global2.data[20] == 7) && global1.dlc[0] && global1.gameState.gamerules[1] > 0)
			{
				IEnumerable<(int, int)> source = GlobalScript.inst.gameState.party_number.Select((int p, int index) => (Key: index, Value: p));
				IEnumerable<(int, int)> source2 = source.OrderBy<(int, int), int>(((int Key, int Value) n) => n.Value).Take(3);
				IEnumerable<(int, int)> source3 = source.OrderByDescending<(int, int), int>(((int Key, int Value) n) => n.Value).Take(3);
				int item = source3.ElementAt(0).Item1;
				global1.gameState.factionsPoints[source3.ElementAt(0).Item1] += global1.gameState.data[3] / 100;
				global1.gameState.factionsPoints[source3.ElementAt(1).Item1] += global1.gameState.data[3] / 100;
				global1.gameState.factionsPoints[source3.ElementAt(0).Item1] += global1.gameState.data[5] / 100;
				global1.gameState.factionsPoints[source3.ElementAt(1).Item1] += global1.gameState.data[5] / 100;
				global1.gameState.factionsPoints[source3.ElementAt(2).Item1] += global1.gameState.data[5] / 100;
				global1.gameState.factionsPoints[source2.ElementAt(0).Item1] += global1.gameState.data[4] / 100;
				global1.gameState.factionsPoints[source2.ElementAt(1).Item1] += global1.gameState.data[4] / 100;
				global1.gameState.factionsPoints[source2.ElementAt(0).Item1] += 10 - global1.gameState.data[3] / 100;
				global1.gameState.factionsPoints[source2.ElementAt(1).Item1] += 10 - global1.gameState.data[3] / 100;
				global1.gameState.factionsPoints[source2.ElementAt(2).Item1] += 10 - global1.gameState.data[3] / 100;
				for (int num3 = 0; num3 < global1.gameState.factionsPoints.Length; num3++)
				{
					if (num3 != item)
					{
						global1.gameState.factionsPoints[num3] += global1.gameState.data[1] / 100;
					}
				}
			}
			if (global2.data[19] == 1 && global2.data[20] == 1)
			{
				global2.allcountries[1].dev = 0;
				global2.allcountries[92].spec = 0;
				if (global2.congressShutdownYears > 4)
				{
					global2.congressShutdownYears = 0;
				}
				else if (global2.congressShutdownYears > 0)
				{
					GameState gameState = global2;
					gameState.congressShutdownYears++;
				}
				if (global2.peopleCoalitionYears > 4)
				{
					global2.peopleCoalitionYears = 0;
				}
				else if (global2.peopleCoalitionYears > 0)
				{
					GameState gameState = global2;
					gameState.peopleCoalitionYears++;
				}
				global1.gameState.coopAttacked = false;
				if (global2.data[21] != 1976)
				{
					Country country = global2.allcountries[87];
					country.spec += 5;
				}
				global2.allcountries[1].inflNATO = 0;
				global2.allcountries[1].inflCh = 0;
				global2.allcountries[1].based = false;
				global2.allcountries[87].based = false;
				if (global2.data[21] == 1986)
				{
					if (global2.allcountries[86].Gosstroy == 3 && !global2.allcountries[0].isEU)
					{
						global2.allcountries[86].JoinEU();
					}
					if (global2.allcountries[87].Gosstroy == 3 && !global2.allcountries[0].isEU)
					{
						global2.allcountries[87].JoinEU();
					}
				}
				if (global2.allcountries[1].isSEATO)
				{
					for (int num4 = 0; num4 < global2.allcountries.Length; num4++)
					{
						if (global2.allcountries[num4].isSEATO)
						{
							global2.allcountries[1].cw = false;
						}
					}
				}
				for (int num5 = 0; num5 < global2.allcountries.Length; num5++)
				{
					global2.allcountries[num5].perevorot = false;
				}
				global2.allcountries[11].stab = 0;
				global2.allcountries[19].stab = 0;
				global2.allcountries[12].stab = 0;
				global2.allcountries[21].stab = 0;
				global2.allcountries[47].stab = 0;
				global2.allcountries[51].stab = 0;
				global2.allcountries[19].prcpower = 0;
				global2.war_active[0] = false;
				global2.war_active[1] = false;
				GlobalScript.inst.gameState.data[106] /= 10;
				GlobalScript.inst.gameState.party_number[0] /= 10;
				GlobalScript.inst.gameState.party_number[1] /= 10;
				GlobalScript.inst.gameState.party_number[2] /= 10;
				GlobalScript.inst.gameState.party_number[3] /= 10;
				GlobalScript.inst.gameState.party_number[4] /= 10;
			}
			if (global2.data[60] == 0 && global2.allcountries[20].proprc && (global2.data[14] > 3 || global2.data[15] > 7 || global2.data[16] > 13 || global2.data[50] > 28 || global2.data[54] > 40 || global2.data[52] > 36))
			{
				global2.allcountries[20].proprc = false;
				global2.allcountries[20].Torg = false;
				global2.allcountries[20].econ = false;
				global2.allcountries[20].okb = false;
			}
			if (global2.data[60] == 0 && !global2.allcountries[20].proprc && (global2.allcountries[20].econ || global2.allcountries[20].okb))
			{
				global2.allcountries[20].econ = false;
				global2.allcountries[20].okb = false;
			}
			global2.data[25] = 0;
			global2.data[23] = global2.data[70];
			for (int num6 = 0; num6 < global2.allcountries.Length; num6++)
			{
				if (global2.allcountries[num6].isSEV && global2.allcountries[1].isSEV)
				{
					global2.data[25]++;
					if (global2.allcountries[num6].Gosstroy > 0)
					{
						global2.data[23] += 2 + (3 - global2.allcountries[num6].Gosstroy);
					}
					else
					{
						global2.data[23] += 3;
					}
				}
				else if (global2.allcountries[num6].econ && global2.allcountries[1].econ)
				{
					global2.data[25]++;
					if (global2.allcountries[num6].Gosstroy > 0)
					{
						global2.data[23] += 2 + (3 - global2.allcountries[num6].Gosstroy);
					}
					else
					{
						global2.data[23] += 3;
					}
				}
				else if (global2.allcountries[num6].isASEAN && global2.allcountries[1].isASEAN)
				{
					global2.data[25]++;
					if (global2.allcountries[num6].Gosstroy == 0 || global2.allcountries[num6].Gosstroy == 2)
					{
						global2.data[23] += 2;
					}
					else if (global2.allcountries[num6].Gosstroy == 3)
					{
						global2.data[23] += 3;
					}
				}
				else if (global2.allcountries[num6].proprc)
				{
					global2.data[25]++;
					global2.data[23] += 2;
				}
				else if (global2.allcountries[num6].Torg)
				{
					global2.data[25]++;
					global2.data[23]++;
				}
			}
			if (global2.data[15] > 7 && global2.data[125] == 4)
			{
				global2.data[125] = 0;
			}
			if (global2.data[37] >= 1000 && !global2.allcountries[47].proprc)
			{
				global2.allcountries[47].proprc = true;
				global2.allcountries[47].Gosstroy = 1;
				global2.allcountries[47].isASEAN = false;
				global2.allcountries[47].SubGosstroy = 1;
				global2.allcountries[47].Vyshi = false;
			}
			AfricanBotSupport();
			if (global2.empires[0].relations <= 500 && global2.allcountries[51].Torg)
			{
				global2.allcountries[51].Torg = false;
			}
			if (global2.empires[1].relations <= 500 && global2.relres)
			{
				global2.relres = false;
			}
			int[] array2 = new int[5];
			int[] array3 = new int[5];
			int num7 = 0;
			int num8 = 200;
			if (global2.faction_leader[0] == 200 || global2.faction_leader[1] == 200 || global2.faction_leader[2] == 200 || global2.faction_leader[3] == 200 || global2.faction_leader[4] == 200)
			{
				array2[0] = 0;
				array2[1] = 0;
				array2[2] = 0;
				array2[3] = 0;
				array2[4] = 0;
				array3[0] = 200;
				array3[1] = 200;
				array3[2] = 200;
				array3[3] = 200;
				array3[4] = 200;
			}
			for (int num9 = 0; num9 < global2.politics.Length; num9++)
			{
				if (global2.faction_leader[0] == 200 && global2.politics[num9].traits[0] == 0 && global2.politics[num9].power > array2[0])
				{
					array2[0] = global2.politics[num9].power;
					array3[0] = num9;
				}
				if (global2.faction_leader[1] == 200 && (global2.politics[num9].traits[0] == 0 || global2.politics[num9].traits[0] == 1))
				{
					if (global2.politics[num9].power > array2[0])
					{
						array2[1] = global2.politics[num9].power;
						array3[1] = num9;
					}
					else if (global2.politics[num9].power > num7)
					{
						num7 = global2.politics[num9].power;
						num8 = num9;
					}
				}
				if (global2.faction_leader[2] == 200 && global2.politics[num9].traits[0] == 1 && global2.politics[num9].power > array2[0])
				{
					array2[2] = global2.politics[num9].power;
					array3[2] = num9;
				}
				if (global2.faction_leader[3] == 200 && global2.politics[num9].traits[0] == 2 && global2.politics[num9].power > array2[0])
				{
					array2[3] = global2.politics[num9].power;
					array3[3] = num9;
				}
				if (global2.faction_leader[4] == 200 && global2.politics[num9].traits[0] == 3 && global2.politics[num9].power > array2[0])
				{
					array2[4] = global2.politics[num9].power;
					array3[4] = num9;
				}
			}
			if (global2.faction_leader[0] == 200)
			{
				global2.faction_leader[0] = array3[0];
			}
			if (global2.faction_leader[0] == 200)
			{
				if (array3[1] != global2.faction_leader[0])
				{
					global2.faction_leader[1] = array3[1];
				}
				else
				{
					global2.faction_leader[1] = num8;
				}
			}
			if (global2.faction_leader[2] == 200)
			{
				global2.faction_leader[2] = array3[2];
			}
			if (global2.faction_leader[3] == 200)
			{
				global2.faction_leader[3] = array3[3];
			}
			if (global2.faction_leader[4] == 200)
			{
				global2.faction_leader[4] = array3[4];
			}
			int[] array4 = new int[global2.party_ideology.Length];
			global2.data[53] = 0;
			for (int num10 = 0; num10 < global2.party_number.Length; num10++)
			{
				if (!global2.is_party_enabled[num10])
				{
					global2.data[53]++;
				}
			}
			if (global2.data[15] > 7 && global2.data[53] >= 4)
			{
				global2.data[15] = 6;
			}
			if (global2.data[15] <= 7)
			{
				for (int num11 = 0; num11 < global2.party_number.Length; num11++)
				{
					if (global2.party_ideology[num11] > 0 && !global2.is_party_enabled[num11])
					{
						if (num11 + 1 < global2.is_party_enabled.Length)
						{
							for (int num12 = num11 + 1; num12 < global2.is_party_enabled.Length; num12++)
							{
								if (global2.is_party_enabled[num12])
								{
									array4[num12] = global2.party_ideology[num11];
									break;
								}
							}
							continue;
						}
						for (int num13 = num11 - 1; num13 > 0; num13--)
						{
							if (global2.is_party_enabled[num13])
							{
								global2.party_number[num13] += global2.party_ideology[num11];
								break;
							}
						}
					}
					else if (global2.party_ideology[num11] > 0 && global2.is_party_enabled[num11])
					{
						global2.party_number[num11] = global2.party_ideology[num11] + array4[num11];
					}
					else if (global2.party_ideology[num11] < 0)
					{
						global2.party_ideology[num11] = 0;
					}
				}
			}
			if (global2.data[15] <= 7)
			{
				if (global2.party_number[0] >= global2.party_number[1] && global2.party_number[0] >= global2.party_number[2] && global2.party_number[0] >= global2.party_number[3] && global2.party_number[0] >= global2.party_number[4])
				{
					global2.data[56] = 0;
				}
				else if (global2.party_number[0] <= global2.party_number[1] && global2.party_number[1] >= global2.party_number[2] && global2.party_number[1] >= global2.party_number[3] && global2.party_number[1] >= global2.party_number[4])
				{
					global2.data[56] = 1;
				}
				else if (global2.party_number[2] >= global2.party_number[1] && global2.party_number[0] <= global2.party_number[2] && global2.party_number[2] >= global2.party_number[3] && global2.party_number[2] >= global2.party_number[4])
				{
					global2.data[56] = 2;
				}
				else if (global2.party_number[3] >= global2.party_number[1] && global2.party_number[3] >= global2.party_number[2] && global2.party_number[0] <= global2.party_number[3] && global2.party_number[3] >= global2.party_number[4])
				{
					global2.data[56] = 3;
				}
				else if (global2.party_number[4] >= global2.party_number[1] && global2.party_number[4] >= global2.party_number[2] && global2.party_number[4] >= global2.party_number[3] && global2.party_number[0] <= global2.party_number[4])
				{
					global2.data[56] = 4;
				}
			}
			else
			{
				int num14 = global2.party_number[1];
				for (int num15 = 0; num15 < global2.is_party_ally.Length; num15++)
				{
					if (global2.is_party_ally[num15] && global2.is_party_enabled[num15] && num15 != 1)
					{
						num14 += global2.party_number[num15];
					}
				}
				if (num14 >= global2.party_number[0] && num14 >= global2.party_number[2] && num14 >= global2.party_number[3] && num14 >= global2.party_number[4])
				{
					global2.data[56] = 1;
				}
				else if (!global2.is_party_ally[0] && global2.is_party_enabled[0] && num14 <= global2.party_number[0] && global2.party_number[0] >= global2.party_number[2] && global2.party_number[0] >= global2.party_number[3] && global2.party_number[0] >= global2.party_number[4])
				{
					global2.data[56] = 0;
				}
				else if (!global2.is_party_ally[2] && global2.is_party_enabled[2] && global2.party_number[2] >= global2.party_number[0] && num14 <= global2.party_number[2] && global2.party_number[2] >= global2.party_number[3] && global2.party_number[2] >= global2.party_number[4])
				{
					global2.data[56] = 2;
				}
				else if (!global2.is_party_ally[3] && global2.is_party_enabled[3] && global2.party_number[3] >= global2.party_number[0] && global2.party_number[3] >= global2.party_number[2] && num14 <= global2.party_number[3] && global2.party_number[3] >= global2.party_number[4])
				{
					global2.data[56] = 3;
				}
				else if (!global2.is_party_ally[4] && global2.is_party_enabled[4] && global2.party_number[4] >= global2.party_number[0] && global2.party_number[4] >= global2.party_number[2] && global2.party_number[4] >= global2.party_number[3] && num14 <= global2.party_number[4])
				{
					global2.data[56] = 4;
				}
				int num16 = global2.party_number[0] + global2.party_number[1] + global2.party_number[2] + global2.party_number[3] + global2.party_number[4];
				int num17 = num14 * 100 / num16;
				if (num17 > 66)
				{
					global2.is_konst_max = true;
				}
				else
				{
					global2.is_konst_max = false;
				}
			}
			if (global2.data[33] <= 250)
			{
				global2.data[52] = 34;
			}
			else if (global2.data[33] <= 500)
			{
				global2.data[52] = 35;
			}
			else if (global2.data[33] <= 750)
			{
				global2.data[52] = 36;
			}
			else
			{
				global2.data[52] = 37;
			}
			if (global2.data[55] <= 250)
			{
				global2.data[54] = 38;
			}
			else if (global2.data[55] <= 500)
			{
				global2.data[54] = 39;
			}
			else if (global2.data[55] <= 750)
			{
				global2.data[54] = 40;
			}
			else
			{
				global2.data[54] = 41;
			}
			int num18 = global2.data[16] - 9 + (global2.data[15] - 5) + (global2.data[17] - 15) + (global2.data[50] - 23) + (global2.data[18] + global2.data[51] - 48) / 2;
			if (global2.data[16] == 11)
			{
				num18++;
			}
			else if (global2.data[16] == 10)
			{
				num18 += 2;
			}
			if (global2.data[15] <= 6 && global2.data[16] >= 14 && global2.data[17] <= 16 && global2.data[18] <= 21 && (global2.data[50] <= 24 || global2.data[50] >= 28) && (global2.data[51] <= 31 || global2.data[51] >= 33))
			{
				global2.data[14] = 0;
				global2.allcountries[1].Gosstroy = 0;
			}
			else if ((num18 <= 6 || (num18 <= 7 && global2.data[16] <= 11) || (num18 <= 9 && global2.modifies[40].active)) && global2.data[17] < 18)
			{
				global2.data[14] = 0;
				global2.allcountries[1].Gosstroy = 0;
			}
			else if (num18 <= 9 && global2.data[16] <= 11)
			{
				global2.data[14] = 1;
				global2.allcountries[1].Gosstroy = 1;
			}
			else if (num18 <= 11)
			{
				global2.data[14] = 2;
				global2.allcountries[1].Gosstroy = 1;
			}
			else if (num18 <= 15 && global2.data[16] > 11)
			{
				global2.data[14] = 3;
				global2.allcountries[1].Gosstroy = 2;
			}
			else if (num18 <= 20 && global2.data[16] > 11)
			{
				global2.data[14] = 4;
				global2.allcountries[1].Gosstroy = 3;
			}
			else if (global2.data[16] > 11)
			{
				global2.data[14] = 5;
				global2.allcountries[1].Gosstroy = 3;
			}
			else
			{
				global2.data[14] = 2;
				global2.allcountries[1].Gosstroy = 2;
			}
			global2.allcountries[1].SubGosstroy = global2.ChineseSubGosstroy();
			PlotPlayerCause();
			if (global2.data[1] <= 300 + global2.data[4] / 5 - (global2.data[3] - 500) / 5)
			{
				Reelect(4);
			}
			global2.data[11] += global2.data[73] / 50;
			if (global2.data[16] <= 12 && global2.event_done[92])
			{
				if (global2.data[102] == 1)
				{
					global2.data[11]--;
				}
				else if (global2.data[102] == 2)
				{
					global2.data[11]--;
				}
				else if (global2.data[102] == 3)
				{
					global2.data[11]--;
				}
				else if (global2.data[102] == 4)
				{
					global2.data[11]++;
				}
			}
			if (global2.data[19] == 1 && global2.data[20] % 3 == 0)
			{
				global2.allcountries[8].stab = 0;
				global2.allcountries[7].dev = 0;
			}
			if (global2.data[19] == 1 && (global2.data[20] == global2.data[119] || global2.data[20] == global2.data[121]))
			{
				global2.bad_done = false;
			}
			if (global2.data[19] == 1)
			{
				global2.bad_debuff = false;
				int num19 = global2.data[34];
				int num20 = global2.data[160];
				int num21 = global2.data[161];
				global2.data[169] = 0;
				if (global2.gamerules[8] == 3)
				{
					for (int num22 = 0; num22 < global2.politics_dolshnost.Length; num22++)
					{
						global2.politics_dolshnost[num22] = 200;
					}
					for (int num23 = 0; num23 < global2.politics_dolshnost.Length; num23++)
					{
						IEnumerable<(int, Politic)> source4 = from p in global2.politics.Select((Politic p, int item2) => (Key: item2, Value: p))
							where !global2.politics_dolshnost.Any((byte pos) => pos == p.Key)
							select p;
						global2.politics_dolshnost[num23] = (byte)source4.ElementAt(UnityEngine.Random.Range(0, source4.Count())).Item1;
					}
				}
				for (int num24 = 0; num24 < global2.desnull.Length; num24++)
				{
					if (global2.desnull[num24] > 0)
					{
						global2.desnull[num24]--;
					}
					if ((num24 == 24 || num24 == 25 || num24 == 26 || num24 == 27 || num24 == 28 || num24 == 29 || num24 == 30 || num24 == 31 || num24 == 32 || num24 == 34) && global2.desnull[num24] <= 0 && global2.completedDecisions[num24])
					{
						global2.completedDecisions[num24] = false;
					}
				}
				if (global2.allcountries[1].isOVD && global2.allcountries[1].isSEATO)
				{
					global2.data[141] = 0;
					global2.data[142] = 0;
				}
				if (global2.data[144] > 0)
				{
					global2.data[144]--;
				}
				if (global2.data[145] > 0)
				{
					global2.data[145]--;
				}
				if (global2.data[142] > 0)
				{
					global2.data[142]--;
				}
				if (global2.data[150] > 0)
				{
					global2.data[150]--;
				}
				if (global2.data[151] > 0)
				{
					global2.data[151]--;
				}
				if (global2.empires[1].money >= 200 && global2.data[150] <= 0 && global2.empires[1].power - 200 >= global2.empires[0].power && global2.empires[1].power - 200 >= global2.influencePRC && global2.data[143] < 50)
				{
					global2.data[143]++;
					Empire empire = global2.empires[1];
					empire.money -= 200;
					global2.data[150] = 6;
				}
				if (global2.empires[0].money >= 200 && global2.data[151] <= 0 && global2.empires[0].power - 200 >= global2.empires[1].power && global2.empires[0].power - 200 >= global2.influencePRC && global2.data[143] > 10)
				{
					global2.data[143]--;
					Empire empire = global2.empires[0];
					empire.money -= 200;
					global2.data[151] = 6;
				}
				if (global2.allcountries[36].sovinfl > 0)
				{
					Country country = global2.allcountries[36];
					country.sovinfl--;
				}
				if (global2.allcountries[36].usainfl > 0)
				{
					Country country = global2.allcountries[36];
					country.usainfl--;
				}
				if (global2.allcountries[36].prcinfl > 0)
				{
					Country country = global2.allcountries[36];
					country.prcinfl--;
				}
				for (int num25 = 101; num25 < 107; num25++)
				{
					if (global2.allcountries[num25].inflCh >= 1000 && !global2.allcountries[num25].proprc)
					{
						global2.allcountries[num25].proprc = true;
					}
				}
				if (global2.allcountries[36].inflCh >= 1000 && !global2.allcountries[36].proprc)
				{
					global2.allcountries[36].proprc = true;
				}
				for (int num26 = 101; num26 < 107; num26++)
				{
					if (global2.allcountries[num26].sovinfl > 0)
					{
						Country country = global2.allcountries[num26];
						country.sovinfl--;
					}
					if (global2.allcountries[num26].usainfl > 0)
					{
						Country country = global2.allcountries[num26];
						country.usainfl--;
					}
					if (global2.allcountries[num26].prcinfl > 0)
					{
						Country country = global2.allcountries[num26];
						country.prcinfl--;
					}
				}
				if (global2.allcountries[36].inflNATO > 0)
				{
					Country country = global2.allcountries[36];
					country.inflNATO--;
				}
				if (global2.event_done[418])
				{
					int num27 = 0;
					int num28 = 0;
					int num29 = 0;
					Country country;
					if (global2.empires[0].money >= 250)
					{
						if (global2.allcountries[14].Vyshi)
						{
							num27 += 5;
						}
						if (global2.allcountries[8].Vyshi)
						{
							num27 += 5;
						}
						if (global2.allcountries[30].Vyshi)
						{
							num27 += 5;
						}
						if (global2.allcountries[37].Vyshi)
						{
							num27 += 5;
						}
						if (global2.allcountries[35].Vyshi)
						{
							num27 += 5;
						}
						if (global2.allcountries[40].Vyshi)
						{
							num27 += 5;
						}
						if (global2.allcountries[36].proprc)
						{
							if (global2.empires[0].money >= 300)
							{
								num27 += global2.empires[0].power / 25;
								country = global2.allcountries[36];
								country.inflCh -= num27;
								Empire empire = global2.empires[0];
								empire.money -= 300;
							}
						}
						else if (!global2.allcountries[36].proprc && global2.allcountries[36].inflCh > 200)
						{
							num27 += global2.empires[0].power / 15;
							country = global2.allcountries[36];
							country.inflCh -= num27;
							Empire empire = global2.empires[0];
							empire.money -= 250;
						}
						for (int num30 = 101; num30 < 107; num30++)
						{
							if (global2.allcountries[num30].proprc)
							{
								if (global2.empires[0].money >= 300)
								{
									num27 += global2.empires[0].power / 25;
									country = global2.allcountries[num30];
									country.inflCh -= num27;
									Empire empire = global2.empires[0];
									empire.money -= 300;
								}
							}
							else if (!global2.allcountries[num30].proprc && global2.allcountries[num30].inflCh > 200)
							{
								num27 += global2.empires[0].power / 15;
								country = global2.allcountries[num30];
								country.inflCh -= num27;
								Empire empire = global2.empires[0];
								empire.money -= 250;
							}
						}
					}
					if (global2.empires[1].money >= 250)
					{
						if (global2.allcountries[14].prosov)
						{
							num28 += 5;
						}
						if (global2.allcountries[8].prosov)
						{
							num28 += 5;
						}
						if (global2.allcountries[30].prosov)
						{
							num28 += 5;
						}
						if (global2.allcountries[37].prosov)
						{
							num28 += 5;
						}
						if (global2.allcountries[35].prosov)
						{
							num28 += 5;
						}
						if (global2.allcountries[40].prosov)
						{
							num28 += 5;
						}
						if (global2.allcountries[36].proprc)
						{
							if (global2.empires[1].money >= 300)
							{
								num28 += global2.empires[1].power / 25;
								country = global2.allcountries[36];
								country.inflCh -= num28;
								Empire empire = global2.empires[1];
								empire.money -= 300;
							}
						}
						else if (!global2.allcountries[36].proprc && global2.allcountries[36].inflCh > 200)
						{
							num28 += global2.empires[1].power / 15;
							country = global2.allcountries[36];
							country.inflCh -= num28;
							Empire empire = global2.empires[1];
							empire.money -= 250;
						}
						for (int num31 = 101; num31 < 107; num31++)
						{
							if (global2.allcountries[num31].proprc)
							{
								if (global2.empires[1].money >= 300)
								{
									num28 += global2.empires[1].power / 25;
									country = global2.allcountries[num31];
									country.inflCh -= num28;
									Empire empire = global2.empires[1];
									empire.money -= 300;
								}
							}
							else if (!global2.allcountries[num31].proprc && global2.allcountries[num31].inflCh > 200)
							{
								num28 += global2.empires[1].power / 15;
								country = global2.allcountries[num31];
								country.inflCh -= num28;
								Empire empire = global2.empires[1];
								empire.money -= 250;
							}
						}
					}
					if (global2.allcountries[14].proprc)
					{
						num29 += 15;
					}
					if (global2.allcountries[8].proprc)
					{
						num29 += 15;
					}
					if (global2.allcountries[30].proprc)
					{
						num29 += 15;
					}
					if (global2.allcountries[37].proprc)
					{
						num29 += 15;
					}
					if (global2.allcountries[35].proprc)
					{
						num29 += 15;
					}
					if (global2.allcountries[40].proprc)
					{
						num29 += 15;
					}
					if (global2.allcountries[14].econ)
					{
						num29 += 5;
					}
					if (global2.allcountries[8].econ)
					{
						num29 += 5;
					}
					if (global2.allcountries[30].econ)
					{
						num29 += 5;
					}
					if (global2.allcountries[37].econ)
					{
						num29 += 5;
					}
					if (global2.allcountries[35].econ)
					{
						num29 += 5;
					}
					if (global2.allcountries[40].econ)
					{
						num29 += 5;
					}
					for (int num32 = 101; num32 < 107; num32++)
					{
						country = global2.allcountries[num32];
						country.inflCh += num29;
					}
					country = global2.allcountries[36];
					country.inflCh += num29;
					for (int num33 = 101; num33 < 107; num33++)
					{
						if (global2.allcountries[num33].inflCh > 1000)
						{
							global2.allcountries[num33].inflCh = 1000;
						}
						else if (global2.allcountries[num33].inflCh < 0)
						{
							global2.allcountries[num33].inflCh = 0;
						}
					}
					if (global2.allcountries[36].inflCh > 1000)
					{
						global2.allcountries[36].inflCh = 1000;
					}
					else if (global2.allcountries[36].inflCh < 0)
					{
						global2.allcountries[36].inflCh = 0;
					}
					for (int num34 = 101; num34 < 107; num34++)
					{
						if (global2.allcountries[num34].proprc && global2.allcountries[num34].inflCh < 250)
						{
							global2.allcountries[num34].proprc = false;
						}
					}
					if (global2.allcountries[36].proprc && global2.allcountries[36].inflCh < 250)
					{
						global2.allcountries[36].proprc = false;
					}
				}
				if (global2.data[146] > 0)
				{
					global2.data[8] -= global2.data[146];
					global2.data[9] -= global2.data[146];
					global2.data[22] -= global2.data[146];
					for (int num35 = 0; num35 < global2.allcountries.Length; num35++)
					{
						if (global2.allcountries[num35].dota)
						{
							Country country;
							if (global2.allcountries[1].isOVD)
							{
								country = global2.allcountries[num35];
								country.sovinfl -= 10;
							}
							else
							{
								country = global2.allcountries[num35];
								country.usainfl -= 10;
							}
							country = global2.allcountries[num35];
							country.prcinfl += 5;
						}
					}
				}
				if (global2.allcountries[92].spec > 1)
				{
					global2.allcountries[92].spec = 1;
				}
				if (global2.data[21] == 1981 && global2.data[20] == 1 && global2.allcountries[45].Gosstroy == 3)
				{
					global2.allcountries[45].isEU = true;
					Empire empire = global2.empires[0];
					empire.power += 10;
				}
				if (global2.allcountries[51].spec > 0)
				{
					Country country = global2.allcountries[51];
					country.spec--;
				}
				if (global2.allcountries[7].spec > 0)
				{
					Country country = global2.allcountries[7];
					country.spec--;
				}
				if (!global2.allcountries[1].parts[0] && !global2.allcountries[1].parts[1] && !global2.allcountries[1].parts[2] && !global2.allcountries[1].parts[3] && !global2.allcountries[1].parts[4] && !global2.allcountries[1].parts[5] && !global2.allcountries[1].parts[6] && !global2.allcountries[1].parts[7] && !global2.allcountries[1].parts[8] && !global2.allcountries[1].parts[9] && !global2.allcountries[1].parts[10])
				{
					global2.allcountries[1].ILoveSuckCocks();
				}
				if (global2.data[21] == 1979 && global2.data[20] == 5 && !GlobalScript.inst.dlc[3])
				{
					Empire empire = global2.empires[0];
					empire.power += 10;
					global2.allcountries[92].SubGosstroy = 12;
				}
				if (global2.data[6] >= 850 || global2.data[131] == 1 || global2.data[131] == 2 || !global2.allcountries[30].Vyshi || global2.allcountries[8].Gosstroy == 1 || global2.allcountries[8].SubGosstroy == 9 || global2.allcountries[1].isSEV)
				{
					global2.modifies[41].active = false;
				}
				if (global2.allcountries[1].Gosstroy != 1 || global2.allcountries[1].isASEAN || !global2.relres)
				{
					global2.modifies[53].active = false;
					global2.allcountries[16].Torg = false;
				}
				if (!global2.allcountries[1].isSEV)
				{
					for (int num36 = 2; num36 < 7; num36++)
					{
						if (global2.allcountries[num36].prosov)
						{
							global2.allcountries[num36].Torg = false;
						}
					}
				}
				if (global2.allcountries[16].Torg && !global2.allcountries[1].isSEV)
				{
					global2.allcountries[16].Torg = false;
				}
				if (global2.allcountries[92].Gosstroy == 1 || global2.allcountries[92].SubGosstroy == 3)
				{
					global2.allcountries[31].isSENTO = false;
					global2.allcountries[8].isSENTO = false;
				}
				if (GlobalScript.inst.dlc[3] && !global2.ingamewars[20].is_going && global2.allcountries[57].puppetOf < 0 && global2.data[21] > 1978)
				{
					global2.allcountries[57].africaOff = false;
				}
				if (global2.data[139] > 0)
				{
					global2.data[139]--;
				}
				if (((!global2.modifies[16].active && global2.allcountries[1].isSEV && global2.data[140] <= 0) || (!global2.modifies[17].active && global2.allcountries[1].isASEAN && global2.data[140] <= 0) || (global2.data[140] == 1 && global2.allcountries[1].isSEV && global2.allcountries[1].Gosstroy != 3 && global2.data[52] != 37) || (global2.data[140] == 2 && global2.allcountries[1].isASEAN && global2.allcountries[1].Gosstroy != 1 && global2.data[52] != 34)) && global2.data[139] > 0)
				{
					global2.data[139] = 0;
				}
				if (global2.data[139] <= 0 && ((global2.allcountries[1].isSEV && global2.modifies[16].active && global2.data[140] <= 0) || (global2.allcountries[1].isASEAN && global2.modifies[17].active && global2.data[140] <= 0) || global2.data[140] > 0))
				{
					Debug.Log("Вас выгнали!");
					if (global2.allcountries[1].isASEAN)
					{
						Empire empire = global2.empires[0];
						empire.relations -= 300;
					}
					else
					{
						Empire empire = global2.empires[1];
						empire.relations -= 300;
						global2.allcountries[7].Torg = false;
					}
					global2.data[140] = 0;
					if (global2.data[135] > 0)
					{
						global2.modifies[47].active = true;
						global2.data[135] = 0;
					}
					if (global2.data[136] > 0)
					{
						global2.modifies[48].active = true;
						global2.data[136] = 0;
					}
					global2.data[139] = 0;
					global2.allcountries[7].spec = 0;
					global2.allcountries[51].spec = 0;
					for (int num37 = 2; num37 < global2.allcountries.Length; num37++)
					{
						if (global2.allcountries[num37].proprc)
						{
							if (global2.allcountries[1].isASEAN)
							{
								global2.allcountries[num37].LeaveASEAN().LeaveSEATO();
								Empire empire = global2.empires[0];
								empire.power -= 5;
							}
							else
							{
								global2.allcountries[num37].LeaveWP().LeaveComecon();
								Empire empire = global2.empires[1];
								empire.power -= 5;
							}
						}
					}
					if (global2.data[137] > 0)
					{
						for (int num38 = 0; num38 < global2.allcountries.Length; num38++)
						{
							global2.data[137] = 0;
							if (global2.allcountries[num38].proprc)
							{
								global2.allcountries[num38].JoinECON();
							}
						}
					}
					if (global2.data[138] > 0)
					{
						for (int num39 = 0; num39 < global2.allcountries.Length; num39++)
						{
							global2.data[138] = 0;
							if (global2.allcountries[num39].proprc)
							{
								global2.allcountries[num39].JoinOKB();
							}
						}
					}
					global2.allcountries[1].LeaveWP().LeaveASEAN().LeaveComecon()
						.LeaveSEATO();
				}
				if (global2.data[21] == 1983 && global2.data[20] == 6 && !GlobalScript.inst.dlc[3])
				{
					Empire empire = global2.empires[0];
					empire.power += 10;
					global2.allcountries[21].SubGosstroy = 12;
				}
				if (!global2.allcountries[44].EAF)
				{
					if (global2.allcountries[44].Gosstroy == 0 && global2.allcountries[44].SubGosstroy == 9)
					{
						global2.allcountries[44].name = GlobalScript.inst.new_events_text[814];
					}
					else if (global2.allcountries[44].Gosstroy == 1)
					{
						global2.allcountries[44].name = GlobalScript.inst.new_events_text[815];
					}
					else
					{
						global2.allcountries[44].name = GlobalScript.inst.new_events_text[871];
					}
				}
				if (global2.allcountries[7].isNATO)
				{
					for (int num40 = 0; num40 < global2.ingamewars.Length; num40++)
					{
						if (global2.ingamewars[num40].is_going && num40 != 5)
						{
							if (global2.ingamewars[num40].diplo_done[0])
							{
								global2.ingamewars[num40].usa_place = 1;
								global2.ingamewars[num40].ussr_place = 1;
							}
							else if (global2.ingamewars[num40].diplo_done[1])
							{
								global2.ingamewars[num40].usa_place = 0;
								global2.ingamewars[num40].ussr_place = 0;
							}
						}
					}
				}
				if (global2.data[21] > 1976 && !GlobalScript.inst.dlc[3])
				{
					global2.allcountries[87].SubGosstroy = 6;
					global2.allcountries[87].Gosstroy = 3;
					global2.allcountries[86].SubGosstroy = 5;
					global2.allcountries[86].Gosstroy = 3;
				}
				if (GlobalScript.inst.dlc[3] && global2.allcountries[84].SubGosstroy == 7 && global2.data[21] == 1984)
				{
					global2.allcountries[84].SubGosstroy = 6;
					global2.allcountries[84].Gosstroy = 3;
				}
				if (global2.OAR)
				{
					if ((global2.allcountries[14].okb || global2.allcountries[14].isOVD || global2.allcountries[14].isNATO) && global2.allcountries[14].oar)
					{
						global2.allcountries[14].oar = true;
						global2.allcountries[14].okb = false;
						global2.allcountries[14].isOVD = false;
						global2.allcountries[14].isNATO = false;
					}
					if ((global2.allcountries[35].okb || global2.allcountries[35].isOVD || global2.allcountries[35].isNATO) && global2.allcountries[35].oar)
					{
						global2.allcountries[35].oar = true;
						global2.allcountries[35].okb = false;
						global2.allcountries[35].isOVD = false;
						global2.allcountries[35].isNATO = false;
					}
					if ((global2.allcountries[40].okb || global2.allcountries[40].isOVD || global2.allcountries[40].isNATO) && global2.allcountries[40].oar)
					{
						global2.allcountries[40].oar = true;
						global2.allcountries[40].okb = false;
						global2.allcountries[40].isOVD = false;
						global2.allcountries[40].isNATO = false;
					}
					if ((global2.allcountries[30].okb || global2.allcountries[30].isOVD || global2.allcountries[30].isNATO) && global2.allcountries[30].oar)
					{
						global2.allcountries[30].oar = true;
						global2.allcountries[30].okb = false;
						global2.allcountries[30].isOVD = false;
						global2.allcountries[30].isNATO = false;
					}
					if ((global2.allcountries[13].okb || global2.allcountries[13].isOVD || global2.allcountries[13].isNATO) && global2.allcountries[13].oar)
					{
						global2.allcountries[13].oar = true;
						global2.allcountries[13].okb = false;
						global2.allcountries[13].isOVD = false;
						global2.allcountries[13].isNATO = false;
					}
				}
				if (global2.data[21] == 1982 && global2.data[20] == 5 && global2.allcountries[86].SubGosstroy == 5 && !GlobalScript.inst.dlc[3])
				{
					global2.allcountries[86].isNATO = true;
				}
				if (!global2.allcountries[44].EAF)
				{
					if (global2.allcountries[44].SubGosstroy == 9)
					{
						global2.allcountries[44].name = GlobalScript.inst.new_events_text[814];
					}
					if (global2.allcountries[44].Gosstroy == 1)
					{
						global2.allcountries[44].name = GlobalScript.inst.new_events_text[815];
					}
				}
				if (global2.allcountries[84].SubGosstroy == 9 && !global2.allcountries[84].Vyshi && !global2.allcountries[84].isNATO && !global2.allcountries[84].proprc && !global2.allcountries[14].proprc && !global2.allcountries[8].proprc && !global2.allcountries[35].proprc && !global2.allcountries[94].proprc && global2.allcountries[35].SubGosstroy == 9 && global2.allcountries[14].SubGosstroy == 9 && global2.allcountries[8].SubGosstroy == 9 && global2.allcountries[94].SubGosstroy == 9)
				{
					global2.allcountries[84].name = GlobalScript.inst.new_events_text[784];
				}
				DaysInSouthAmerica();
				if (global2.data[16] > 13)
				{
					if (global2.data[16] == 14 && global2.data[21] < 1980)
					{
						global2.data[108] += 5;
					}
					else if (global2.data[16] == 14)
					{
						global2.data[108]++;
					}
					else if (global2.data[16] == 15 && global2.data[21] < 1980)
					{
						global2.data[108] += 10;
					}
					else if (global2.data[16] == 15)
					{
						global2.data[108] += 4;
					}
					if (global2.data[15] <= 7)
					{
						global2.data[108] += 2;
					}
					else if (global2.data[15] == 8)
					{
						global2.data[108]++;
					}
					else if (global2.data[15] == 9)
					{
						global2.data[108]--;
					}
					if (global2.data[17] <= 16)
					{
						global2.data[108] += 2;
					}
					else if (global2.data[17] == 17)
					{
						global2.data[108]++;
					}
					else if (global2.data[17] == 19)
					{
						global2.data[108]--;
					}
					if (global2.data[18] == 21)
					{
						global2.data[108]++;
					}
					else if (global2.data[18] == 22)
					{
						global2.data[108] += 2;
					}
					else if (global2.data[18] == 23)
					{
						global2.data[108] += 3;
					}
					if (global2.data[50] == 24)
					{
						global2.data[108]++;
					}
					else if (global2.data[50] == 25)
					{
						global2.data[108]--;
					}
					else if (global2.data[50] == 28)
					{
						global2.data[108]++;
					}
					else if (global2.data[50] == 29)
					{
						global2.data[108] += 3;
					}
					if (global2.data[51] == 30)
					{
						global2.data[108] += 2;
					}
					else if (global2.data[51] == 31)
					{
						global2.data[108]++;
					}
					if (global2.modifies[7].active)
					{
						global2.data[108]--;
					}
					if (global2.modifies[13].active)
					{
						global2.data[108] -= 2;
					}
					if (global2.modifies[5].active)
					{
						global2.data[108] += 3;
					}
				}
				else if (global2.data[16] == 13)
				{
					if (global2.data[16] == 13 && global2.data[21] < 1980)
					{
						global2.data[108]++;
					}
					if (global2.data[15] == 9)
					{
						global2.data[108]--;
					}
					if (global2.data[17] == 19)
					{
						global2.data[108]--;
					}
					if (global2.data[18] == 21)
					{
						global2.data[108]++;
					}
					else if (global2.data[18] == 22)
					{
						global2.data[108] += 2;
					}
					else if (global2.data[18] == 23)
					{
						global2.data[108] += 3;
					}
					if (global2.data[50] == 24)
					{
						global2.data[108]++;
					}
					else if (global2.data[50] == 25)
					{
						global2.data[108]--;
					}
					else if (global2.data[50] == 28)
					{
						global2.data[108]++;
					}
					else if (global2.data[50] == 29)
					{
						global2.data[108] += 3;
					}
					if (global2.modifies[7].active)
					{
						global2.data[108]--;
					}
					if (global2.modifies[13].active)
					{
						global2.data[108] -= 2;
					}
					if (global2.modifies[5].active)
					{
						global2.data[108] += 3;
					}
				}
				else if (global2.data[16] == 12)
				{
					if (global2.data[108] > 50)
					{
						global2.data[1] -= (global2.data[108] - 50) * 10;
						Empire empire = global2.empires[0];
						empire.relations -= (global2.data[108] - 50) * 5;
						global2.data[5] += (global2.data[108] - 50) * 5;
						global2.data[6] += (global2.data[108] - 50) * 5;
						global2.data[9] -= (global2.data[108] - 50) * 5;
						global2.data[108] = 50;
					}
					if (global2.data[15] == 9)
					{
						global2.data[108]--;
					}
					if (global2.data[17] == 19)
					{
						global2.data[108]--;
					}
					if (global2.data[50] == 24)
					{
						global2.data[108]++;
					}
					else if (global2.data[50] == 25)
					{
						global2.data[108]--;
					}
					else if (global2.data[50] == 28)
					{
						global2.data[108]++;
					}
					else if (global2.data[50] == 29)
					{
						global2.data[108] += 3;
					}
					global2.data[108] -= 3;
					if (global2.modifies[5].active)
					{
						global2.data[108] += 3;
					}
				}
				else if (global2.data[108] > 0)
				{
					global2.data[1] -= global2.data[108] * 10;
					Empire empire = global2.empires[0];
					empire.relations -= global2.data[108] * 5;
					global2.data[5] += global2.data[108] * 5;
					global2.data[6] += global2.data[108] * 5;
					global2.data[9] -= global2.data[108] * 5;
					global2.data[108] = 0;
				}
				if (global2.data[89] == 2 && !global2.event_done[54])
				{
					global2.data[28]++;
				}
				if (global2.data[20] == 7 && global2.data[21] == 1983 && global2.allcountries[2].Gosstroy == 0 && global2.allcountries[2].prosov)
				{
					global2.allcountries[2].Gosstroy = 1;
					global2.allcountries[2].SubGosstroy = 1;
				}
				if (global2.war == 2 && !global1.dlc[5])
				{
					if (global2.data[40] >= 1000)
					{
						GameState gameState = global2;
						gameState.influencePRC += 10;
						global2.data[62] = 2;
						global2.allcountries[1].ILoveSuckCocks();
						global2.data[34] += 434;
						global2.war = 0;
					}
					global2.data[34] -= 2;
					if (global2.data[40] >= 50)
					{
						global2.data[40] -= 50;
					}
					else if (global2.influencePRC >= 20)
					{
						GameState gameState = global2;
						gameState.influencePRC -= 20;
					}
					if (global2.data[40] <= 0)
					{
						GameState gameState = global2;
						gameState.influencePRC -= 20;
						global2.war = 0;
					}
				}
				global2.allcountries[39].dev = 0;
				global2.allcountries[11].stab = 0;
				global2.allcountries[19].stab = 0;
				global2.allcountries[19].prcpower = 0;
				if (global2.iranrev && global2.data[45] <= 960)
				{
					global2.data[45] += 30;
					global2.data[42] += global2.empires[1].power / 25;
					global2.data[44] += global2.empires[0].power / 25;
				}
				for (int num41 = 0; num41 < global2.politics.Length; num41++)
				{
					if (global2.politics[num41].is_sledstvie && global2.politics[num41].sled_slej < 7)
					{
						Politic politic = global2.politics[num41];
						politic.sled_slej++;
					}
					else if (global2.politics[num41].sled_slej >= 7)
					{
						global2.politics[num41].sled_slej = 0;
						global2.politics[num41].is_sledstvie = false;
					}
					if (global2.politics[num41].is_sleshka && global2.politics[num41].days_sleshka < 7)
					{
						Politic politic = global2.politics[num41];
						politic.days_sleshka++;
					}
					else if (global2.politics[num41].days_sleshka >= 7)
					{
						global2.politics[num41].days_sleshka = 0;
						global2.politics[num41].is_sleshka = false;
					}
					if (global2.politics[num41].autosupport == 10)
					{
						global2.data[8]--;
						global2.data[1] -= 20;
						global2.data[9] -= 5;
						Politic politic = global2.politics[num41];
						politic.power += (1976 - global2.data[21]) * 5;
						politic = global2.politics[num41];
						politic.loyality += 50;
						politic = global2.politics[num41];
						politic.power += global2.politics[num41].power / 10;
					}
					else if (global2.politics[num41].autohound == 10)
					{
						global2.data[8]--;
						global2.data[1] -= 20;
						global2.data[9] -= 20;
						Politic politic = global2.politics[num41];
						politic.loyality -= 250;
						politic = global2.politics[num41];
						politic.power -= (1976 - global2.data[21]) * 5;
						if (global2.politics[num41].power >= 10)
						{
							politic = global2.politics[num41];
							politic.power -= global2.politics[num41].power / 10;
						}
					}
					if (global2.politics_dolshnost[4] == num41 || global2.politics_dolshnost[5] == num41 || global2.politics_dolshnost[6] == num41 || global2.politics_dolshnost[7] == num41)
					{
						Politic politic = global2.politics[num41];
						politic.power += 10;
					}
					else if (global2.politics_dolshnost[3] == num41)
					{
						Politic politic = global2.politics[num41];
						politic.power += 15;
					}
					else if (global2.politics_dolshnost[2] == num41 || global2.politics_dolshnost[1] == num41 || global2.politics_dolshnost[0] == num41)
					{
						Politic politic = global2.politics[num41];
						politic.power += 20;
					}
					else if (global2.politics[num41].traits[2] == 18)
					{
						Politic politic = global2.politics[num41];
						politic.power += 4;
					}
					else if (global2.politics[num41].traits[2] == 19)
					{
						Politic politic = global2.politics[num41];
						politic.power -= 20;
					}
					else if (global2.politics[num41].traits[2] == 16)
					{
						Politic politic = global2.politics[num41];
						politic.power++;
						politic = global2.politics[num41];
						politic.power += global2.data[26] / 50;
					}
					else
					{
						Politic politic = global2.politics[num41];
						politic.power++;
					}
					if (global2.data[21] > 1977)
					{
						Politic politic = global2.politics[num41];
						politic.power += (1976 - global2.data[21]) / 2;
					}
				}
				AfricanCoups();
				if (global2.data[19] == 1 && (global2.data[20] == 7 || global2.data[20] == 1))
				{
					global2.event_done[5] = false;
					global2.event_done[7] = false;
					global2.event_done[8] = false;
					global2.event_done[9] = false;
					global2.event_done[10] = false;
				}
				if (global2.allcountries[39].dev == 1)
				{
					global2.allcountries[39].dev = 0;
				}
				if (global2.data[13] < 250)
				{
					global2.data[34] -= 15;
				}
				else if (global2.data[13] < 410)
				{
					global2.data[34] -= 8;
				}
				if (global2.data[68] < 250)
				{
					global2.data[34] -= 4;
				}
				if (global2.data[12] < 250)
				{
					global2.data[34] -= 8;
				}
				else if (global2.data[12] < 410)
				{
					global2.data[34] -= 4;
				}
				if (global2.data[17] == 18)
				{
					global2.data[34] -= 4;
				}
				else if (global2.data[17] == 19)
				{
					global2.data[34] -= 9;
				}
				if (global2.data[50] == 28)
				{
					global2.data[34] += global2.data[105];
				}
				else if (global2.data[50] == 29)
				{
					global2.data[34] += 2 * global2.data[105];
				}
				if (global2.data[16] == 11)
				{
					global2.data[12] += global2.data[34] / 5000;
				}
				else if (global2.data[16] == 10)
				{
					global2.data[12] += global2.data[34] / 5000;
				}
				else if (global2.data[16] == 14 && !global2.modifies[13].active)
				{
					global2.data[3] -= global2.data[34] / 4000;
				}
				else if (global2.data[16] == 15 && !global2.modifies[13].active)
				{
					global2.data[3] -= global2.data[34] / 4000;
				}
				global2.data[34] += global2.data[5] / 60 * global2.data[105];
				if (global2.data[14] <= 0 && global2.data[5] <= 500)
				{
					global2.data[34] += 6 * global2.data[105];
				}
				else if (global2.data[14] <= 3 && global2.data[5] <= 400)
				{
					global2.data[34] += 2 * global2.data[105];
				}
				else if (global2.data[14] == 4 && global2.data[5] >= 850)
				{
					global2.data[34] -= 11;
				}
				else if (global2.data[14] == 4 && global2.data[5] >= 650)
				{
					global2.data[34] -= 9;
				}
				else if (global2.data[14] == 5 && global2.data[5] >= 850)
				{
					global2.data[34] -= 13;
				}
				else if (global2.data[14] == 5 && global2.data[5] >= 650)
				{
					global2.data[34] -= 11;
				}
				global2.data_old[34] = global2.data[34] - num19;
				if (global1.dlc[5])
				{
					(int, int) tuple = global2.AddSoldiersNumber(global2, global2.data_old[34]);
					global2.data[161] += tuple.Item1;
					global2.data[160] += tuple.Item2;
					int num42 = global2.GetSoldiersNumber(global2).reservists - global2.data[161];
					global2.data[160] += global2.AddSoldiersNumber(global2, num42).divisions;
				}
				global2.data_old[160] = global2.data[160] - num20;
				global2.data_old[161] = global2.data[161] - num21;
			}
			if (global2.data[19] % 7 == 0)
			{
				for (int num43 = 0; num43 < global2.politics.Length; num43++)
				{
					if (global2.politics[num43].is_sledstvie && global2.politics[num43].sled_slej < 7)
					{
						Politic politic = global2.politics[num43];
						politic.power -= 5;
					}
					else if (global2.politics[num43].power > 1000)
					{
						global2.politics[num43].power = 1000;
					}
				}
				if (global2.data[117] == 9 && global2.allcountries[14].proprc)
				{
					global2.data[117] = 0;
				}
				if (global2.data[15] <= 7)
				{
					for (int num44 = 0; num44 < global2.is_party_enabled.Length; num44++)
					{
						if (global2.is_party_ally[num44] && GlobalScript.inst.gameState.data[15] <= 7)
						{
							global2.party_ideology[num44] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 100;
							global2.data[8]--;
							global2.data[9] -= 2;
						}
					}
				}
				for (int num45 = 0; num45 < global2.allcountries.Length; num45++)
				{
					if (global2.allcountries[num45].puppetOf >= 0 && !global2.allcountries[num45].EAF)
					{
						if (global2.allcountries[global2.allcountries[num45].puppetOf].Vyshi)
						{
							global2.allcountries[num45].EstablishGovernment(Government.ProAmerican);
							global2.allcountries[num45].Gosstroy = global2.allcountries[global2.allcountries[num45].puppetOf].Gosstroy;
							global2.allcountries[num45].Gosstroy = global2.allcountries[global2.allcountries[num45].puppetOf].SubGosstroy;
						}
						else if (global2.allcountries[global2.allcountries[num45].puppetOf].prosov)
						{
							global2.allcountries[num45].EstablishGovernment(Government.ProSoviet);
							global2.allcountries[num45].Gosstroy = global2.allcountries[global2.allcountries[num45].puppetOf].Gosstroy;
							global2.allcountries[num45].Gosstroy = global2.allcountries[global2.allcountries[num45].puppetOf].SubGosstroy;
						}
						else if (global2.allcountries[global2.allcountries[num45].puppetOf].proprc)
						{
							global2.allcountries[num45].EstablishGovernment(Government.ProChina);
							global2.allcountries[num45].Gosstroy = global2.allcountries[global2.allcountries[num45].puppetOf].Gosstroy;
							global2.allcountries[num45].Gosstroy = global2.allcountries[global2.allcountries[num45].puppetOf].SubGosstroy;
						}
						else
						{
							global2.allcountries[num45].EstablishGovernment(Government.ProNeuthral);
							global2.allcountries[num45].Gosstroy = global2.allcountries[global2.allcountries[num45].puppetOf].Gosstroy;
							global2.allcountries[num45].Gosstroy = global2.allcountries[global2.allcountries[num45].puppetOf].SubGosstroy;
						}
					}
				}
			}
			if (global2.data[19] % 14 == 0)
			{
				GameObject gameObject = GameObject.Find("Ach(Clone)");
				ch_support = global2.data[3];
				ch_profit = global2.data[8];
				ch_lib = global2.data[4];
				int[] array5 = new int[global2.data_old.Length];
				for (int num46 = 0; num46 < global2.data_old.Length; num46++)
				{
					if (num46 != 34 && num46 != 160 && num46 != 161)
					{
						array5[num46] = global2.data[num46];
					}
				}
				array5[28] = global2.empires[0].relations;
				array5[29] = global2.empires[1].relations;
				array5[7] = global2.influencePRC;
				GlobalScript.inst.gameState.FixSubs();
				GlobalScript.inst.gameState.FixAlliances();
				if (global2.data[131] == 1 && global2.allcountries[44].SubGosstroy == 9 && global2.allcountries[86].SubGosstroy == 9 && global2.allcountries[85].SubGosstroy == 9 && global2.allcountries[87].SubGosstroy == 7 && GlobalScript.inst.gameState.iron_and_blood)
				{
					gameObject.GetComponent<achievements>().Set(131);
				}
				for (int num47 = 0; num47 < global2.allcountries.Length; num47++)
				{
					if (((num47 >= 53 && num47 < 69) || (num47 > 105 && num47 < 109) || global2.allcountries[num47].econ) && global2.allcountries[num47].proprc && global2.allcountries[num47].stab != 0 && global2.allcountries[num47].dev != 0 && global2.allcountries[num47].prcpower != 0 && global2.allcountries[num47].Torg)
					{
						Country country = global2.allcountries[num47];
						country.stab -= 2;
						country = global2.allcountries[num47];
						country.dev--;
					}
				}
				if (!global2.allcountries[51].isNATO)
				{
					global2.empires[0].power = 0;
				}
				if ((global2.data[64] == 2 || global2.completedDecisions[7]) && global2.allcountries[51].cw && global2.data[157] > 0)
				{
					gameObject.GetComponent<achievements>().Set(155);
				}
				if (global2.data[143] <= 10 && global2.modifies[51].active)
				{
					gameObject.GetComponent<achievements>().Set(158);
				}
				if (global2.data[143] >= 60 && global2.modifies[51].active)
				{
					gameObject.GetComponent<achievements>().Set(157);
				}
				if (global2.allcountries[36].proprc && global2.allcountries[101].proprc && global2.allcountries[102].proprc && global2.allcountries[103].proprc && global2.allcountries[105].proprc)
				{
					gameObject.GetComponent<achievements>().Set(156);
				}
				if (global2.data[143] < 10)
				{
					global2.data[143] = 10;
				}
				if (global2.data[143] > 60)
				{
					global2.data[143] = 60;
				}
				if (global2.allcountries[87].spec > 100)
				{
					global2.allcountries[87].spec = 100;
				}
				else if (global2.allcountries[87].spec < 0)
				{
					global2.allcountries[87].spec = 0;
				}
				if (global2.allcountries[17].parts[0] || global2.allcountries[7].isNATO)
				{
					global2.modifies[53].active = false;
				}
				global2.data[0] += global2.data[81] / 50;
				bool flag2 = false;
				warinwars[] ingamewars = global2.ingamewars;
				foreach (warinwars warinwars2 in ingamewars)
				{
					if (warinwars2.is_going)
					{
						flag2 = true;
						break;
					}
				}
				if (global2.data[146] > 0)
				{
					global2.modifies[52].active = true;
				}
				else if (global2.data[146] <= 0 || (!global2.allcountries[1].isOVD && !global2.allcountries[1].isSEATO))
				{
					global2.modifies[52].active = false;
					for (int num49 = 0; num49 < global2.allcountries.Length; num49++)
					{
						global2.allcountries[num49].dota = false;
					}
				}
				if (global2.allcountries[7].isNATO && !global2.ingamewars[17].is_going)
				{
					int num50 = (global2.empires[0].power + global2.empires[1].power) / 10;
					for (int num51 = 0; num51 < 10; num51++)
					{
						if (!global2.allcountries[num51].okb && global2.allcountries[num51].isOVD && global2.allcountries[num51].Vyshi && !global2.allcountries[num51].prosov && global2.allcountries[num51].inflNATO < 1000 && (num51 == 2 || num51 == 4 || num51 == 6 || num51 == 98))
						{
							Country country = global2.allcountries[num51];
							country.inflNATO += num50;
							country = global2.allcountries[num51];
							country.inflCh -= num50;
							if (!global2.allcountries[num51].econ)
							{
								country = global2.allcountries[num51];
								country.inflNATO += 50;
								country = global2.allcountries[num51];
								country.inflCh -= 50;
							}
							else if (!global2.allcountries[num51].based)
							{
								country = global2.allcountries[num51];
								country.inflNATO += 30;
								country = global2.allcountries[num51];
								country.inflCh -= 30;
							}
							else if (!global2.allcountries[num51].okb)
							{
								country = global2.allcountries[num51];
								country.inflNATO += 10;
								country = global2.allcountries[num51];
								country.inflCh -= 10;
							}
						}
						if (global2.allcountries[num51].inflNATO < 1000 || global2.allcountries[num51].isNATO || (num51 != 2 && num51 != 4 && num51 != 6 && num51 != 98))
						{
							continue;
						}
						global2.allcountries[num51].isOVD = false;
						global2.allcountries[num51].based = false;
						global2.allcountries[num51].econ = false;
						global2.allcountries[num51].proprc = false;
						global2.allcountries[num51].isNATO = true;
						global2.allcountries[num51].Torg = false;
						if (global2.empires[0].power >= global2.empires[1].power)
						{
							global2.allcountries[num51].isEU = true;
							global2.allcountries[num51].Vyshi = true;
							global2.allcountries[num51].Gosstroy = global2.allcountries[51].Gosstroy;
							global2.allcountries[num51].SubGosstroy = global2.allcountries[51].SubGosstroy;
							continue;
						}
						if (global2.allcountries[7].isEU)
						{
							global2.allcountries[num51].isEU = true;
						}
						else
						{
							global2.allcountries[num51].isSEV = true;
						}
						global2.allcountries[num51].prosov = true;
						global2.allcountries[num51].Gosstroy = global2.allcountries[7].Gosstroy;
						global2.allcountries[num51].SubGosstroy = global2.allcountries[7].SubGosstroy;
					}
				}
				if (((global2.allcountries[47].isSEV && global2.allcountries[1].isSEV) || (global2.allcountries[47].isSEATO && global2.allcountries[1].isSEATO) || (global2.allcountries[47].econ && global2.allcountries[1].econ)) && global2.data[37] < 1000)
				{
					global2.data[37] = 0;
				}
				Empire empire;
				if (global2.allcountries[1].isOVD || global2.allcountries[1].isSEATO)
				{
					int num52 = 0;
					int num53 = global2.influencePRC / 100 * 2;
					int num54 = global2.empires[1].power / 100;
					int num55 = global2.empires[0].power / 100;
					for (int num56 = 0; num56 < global2.allcountries.Length; num56++)
					{
						if (global2.allcountries[num56].proprc && num56 != 1)
						{
							num52++;
						}
						if (global2.allcountries[num56].sovinfl < 0)
						{
							global2.allcountries[num56].sovinfl = 0;
						}
						if (global2.allcountries[num56].prcinfl < 0)
						{
							global2.allcountries[num56].prcinfl = 0;
						}
						if (global2.allcountries[num56].usainfl < 0)
						{
							global2.allcountries[num56].usainfl = 0;
						}
						if (global2.allcountries[num56].sovinfl > 1000)
						{
							global2.allcountries[num56].sovinfl = 1000;
						}
						if (global2.allcountries[num56].prcinfl > 1000)
						{
							global2.allcountries[num56].prcinfl = 1000;
						}
						if (global2.allcountries[num56].usainfl > 1000)
						{
							global2.allcountries[num56].usainfl = 1000;
						}
					}
					if (global2.allcountries[1].isOVD)
					{
						int num57 = 0;
						for (int num58 = 0; num58 < global2.allcountries.Length; num58++)
						{
							if (global2.allcountries[num58].prosov && num58 != 7)
							{
								num57++;
							}
						}
						for (int num59 = 0; num59 < global2.allcountries.Length; num59++)
						{
							if (global2.allcountries[num59].isOVD && (num59 == 8 || num59 == 11 || num59 == 14 || num59 == 12 || num59 == 31 || num59 == 32 || num59 == 22 || num59 == 43 || num59 == 42 || num59 == 23 || num59 == 33 || num59 == 35 || num59 == 96 || num59 == 97 || num59 == 98 || num59 == 95 || num59 == 49 || num59 == 50))
							{
								Country country = global2.allcountries[num59];
								country.sovinfl += num54;
								country = global2.allcountries[num59];
								country.sovinfl += num57 / 2;
								if (global2.empires[1].now_leader == 4)
								{
									country = global2.allcountries[num59];
									country.sovinfl += 10;
								}
								if (global2.empires[1].now_leader == 3)
								{
									country = global2.allcountries[num59];
									country.sovinfl += 5;
								}
								if (global2.allcountries[num59].Gosstroy != global2.allcountries[7].Gosstroy)
								{
									country = global2.allcountries[num59];
									country.sovinfl += 2;
								}
								if (global2.allcountries[num59].SubGosstroy != global2.allcountries[7].SubGosstroy)
								{
									country = global2.allcountries[num59];
									country.sovinfl++;
								}
								country = global2.allcountries[num59];
								country.prcinfl += num53;
								country = global2.allcountries[num59];
								country.prcinfl += num52 / 2;
								country = global2.allcountries[num59];
								country.prcinfl += global2.data[81] / 10 / 5 * 3;
								if (global2.allcountries[num59].Gosstroy != global2.allcountries[1].Gosstroy)
								{
									country = global2.allcountries[num59];
									country.prcinfl += 2;
								}
								if (global2.allcountries[num59].SubGosstroy != global2.allcountries[1].SubGosstroy)
								{
									country = global2.allcountries[num59];
									country.prcinfl++;
								}
							}
						}
					}
					else
					{
						int num60 = 0;
						for (int num61 = 0; num61 < global2.allcountries.Length; num61++)
						{
							if (global2.allcountries[num61].Vyshi && num61 != 51)
							{
								num60++;
							}
						}
						for (int num62 = 0; num62 < global2.allcountries.Length; num62++)
						{
							if (global2.allcountries[num62].isSEATO)
							{
								Country country = global2.allcountries[num62];
								country.usainfl += num55;
								country = global2.allcountries[num62];
								country.usainfl += num60 / 2;
								if (global2.empires[0].now_leader == 0 || global2.empires[0].now_leader == 2)
								{
									country = global2.allcountries[num62];
									country.usainfl += 10;
								}
								if (global2.modifies[41].active)
								{
									country = global2.allcountries[num62];
									country.usainfl -= 5;
								}
								if (global2.allcountries[num62].Gosstroy != global2.allcountries[51].Gosstroy)
								{
									country = global2.allcountries[num62];
									country.sovinfl += 2;
								}
								if (global2.allcountries[num62].SubGosstroy != global2.allcountries[51].SubGosstroy)
								{
									country = global2.allcountries[num62];
									country.sovinfl++;
								}
								country = global2.allcountries[num62];
								country.prcinfl += num53;
								country = global2.allcountries[num62];
								country.prcinfl += num52 / 2;
								country = global2.allcountries[num62];
								country.prcinfl += global2.data[81] / 10 / 5 * 2;
								if (global2.allcountries[num62].Gosstroy != global2.allcountries[1].Gosstroy)
								{
									country = global2.allcountries[num62];
									country.prcinfl += 2;
								}
								if (global2.allcountries[num62].SubGosstroy != global2.allcountries[1].SubGosstroy)
								{
									country = global2.allcountries[num62];
									country.prcinfl++;
								}
							}
						}
					}
					if (global2.empires[1].money >= 250 && global2.allcountries[1].isOVD && GlobalScript.inst.dlc[3] && global2.data[142] <= 0 && global2.data[144] <= 0)
					{
						for (int num63 = 8; num63 < global2.allcountries.Length; num63++)
						{
							if (global2.allcountries[num63].sovinfl >= 800 && global2.data[141] <= 0 && !global2.allcountries[num63].prosov && num63 != 9)
							{
								global2.data[141] = num63;
								global2.data[142] = 4;
								global2.data[144] = 8;
							}
						}
					}
					if (global2.empires[0].money >= 250 && global2.allcountries[1].isSEATO && GlobalScript.inst.dlc[3] && global2.data[142] <= 0 && global2.data[145] <= 0)
					{
						for (int num64 = 8; num64 < global2.allcountries.Length; num64++)
						{
							if (global2.allcountries[num64].usainfl >= 800 && global2.data[141] <= 0 && !global2.allcountries[num64].Vyshi)
							{
								global2.data[141] = num64;
								global2.data[142] = 4;
								global2.data[145] = 8;
							}
						}
					}
					if ((global2.data[141] > 0) & (global2.data[142] <= 0))
					{
						if (global2.allcountries[1].isOVD)
						{
							empire = global2.empires[1];
							empire.money -= 250;
							empire = global2.empires[1];
							empire.power += 10;
							global2.allcountries[global2.data[141]].EstablishGovernment(Government.ProSoviet);
							global2.allcountries[global2.data[141]].Gosstroy = global2.allcountries[7].Gosstroy;
							global2.allcountries[global2.data[141]].SubGosstroy = global2.allcountries[7].SubGosstroy;
							global2.allcountries[global2.data[141]].sovinfl = 500;
							global2.allcountries[global2.data[141]].prcinfl = 0;
							global2.data[141] = 0;
						}
						else
						{
							empire = global2.empires[0];
							empire.money -= 250;
							empire = global2.empires[0];
							empire.power += 10;
							global2.allcountries[global2.data[141]].EstablishGovernment(Government.ProAmerican);
							global2.allcountries[global2.data[141]].Gosstroy = global2.allcountries[51].Gosstroy;
							global2.allcountries[global2.data[141]].SubGosstroy = global2.allcountries[51].SubGosstroy;
							global2.allcountries[global2.data[141]].usainfl = 500;
							global2.allcountries[global2.data[141]].prcinfl = 0;
							global2.data[141] = 0;
						}
					}
					if (global2.data[141] > 0)
					{
						if (global2.allcountries[1].isOVD && (global2.allcountries[global2.data[141]].sovinfl <= 700 || global2.empires[1].money < 250))
						{
							global2.data[141] = 0;
							global2.data[142] = 0;
						}
						if (global2.allcountries[1].isSEATO && (global2.allcountries[global2.data[141]].usainfl <= 700 || global2.empires[0].money < 250))
						{
							global2.data[141] = 0;
							global2.data[142] = 0;
						}
					}
				}
				for (int num65 = 2; num65 < global2.allcountries.Length; num65++)
				{
					if (global2.allcountries[num65].isASEAN && (global2.allcountries[num65].prosov || global2.allcountries[num65].Gosstroy == 1))
					{
						global2.allcountries[num65].LeaveASEAN().LeaveSEATO();
					}
				}
				if ((global2.allcountries[8].isSEATO || global2.allcountries[8].isASEAN) && global2.allcountries[8].SubGosstroy == 9)
				{
					global2.allcountries[8].LeaveASEAN().LeaveASEAN();
				}
				if (flag2)
				{
					global2.data[0] += global2.influencePRC / 12;
				}
				if (global2.data[16] <= 12)
				{
					if (global2.data[102] == 1)
					{
						global2.data[12] += 3;
					}
					else if (global2.data[102] == 2)
					{
						global2.data[13] += 3;
					}
					else if (global2.data[102] == 3)
					{
						global2.data[68] += 3;
					}
					else if (global2.data[102] == 4)
					{
						global2.data[12]--;
						global2.data[13]--;
						global2.data[68]--;
					}
					else if (global2.data[102] == 5)
					{
						global2.data[12]++;
						global2.data[13]++;
						global2.data[68]++;
					}
				}
				if (global2.data[5] > (global2.data[12] + global2.data[13] + global2.data[68] - global2.data[26]) / 3 + 20)
				{
					global2.data[5] -= ((global2.data[12] + global2.data[13] + global2.data[68] - global2.data[26]) / 3 + 20) / 10;
				}
				if (global2.allcountries[15].cw)
				{
					if (global2.empires[1].relations < 700)
					{
						empire = global2.empires[1];
						empire.relations += 5;
					}
					if (global2.empires[0].relations < 700)
					{
						empire = global2.empires[0];
						empire.relations += 5;
					}
					global2.data[8] -= 2;
					if (global2.data[6] > 600)
					{
						global2.data[6] -= 2;
					}
					else if (global2.data[6] < 400)
					{
						global2.data[6] += 2;
					}
				}
				if (global2.data[14] >= 4 && global2.data[16] >= 14)
				{
					global2.data[26]--;
				}
				if (global2.allcountries[85].inflCh == 6)
				{
					if (global2.data[134] <= 1000 && global2.data[134] > 0)
					{
						global2.data[134] -= 50;
					}
					if (global2.data[134] > 1000)
					{
						global2.data[134] = 1000;
					}
					if (global2.data[134] < 0)
					{
						global2.data[134] = 0;
					}
				}
				if (global2.data[21] < 1980)
				{
					if (global2.data[16] == 13)
					{
						global2.data[26] -= global2.data[36] / 400;
						if (global2.data[36] < 600)
						{
							global2.data[5] -= 3 - global2.data[36] / 150;
							global2.data[68] -= 3 - global2.data[36] / 150;
							global2.data[12] -= 3 - global2.data[36] / 150;
						}
						else
						{
							global2.data[5]++;
							global2.data[68]++;
							global2.data[12]++;
						}
					}
					else if (global2.data[16] >= 14)
					{
						global2.data[26] -= global2.data[36] / 200;
						if (global2.data[36] < 750)
						{
							global2.data[5] -= 4 - global2.data[36] / 150;
							global2.data[68] -= 4 - global2.data[36] / 150;
							global2.data[12] -= 4 - global2.data[36] / 150;
						}
						else
						{
							global2.data[5]++;
							global2.data[68]++;
							global2.data[12]++;
						}
					}
				}
				else if (global2.data[16] == 13)
				{
					global2.data[26] -= global2.data[36] / 600;
					if (global2.data[36] < 750)
					{
						global2.data[5] -= 4 - global2.data[36] / 150;
						global2.data[68] -= 4 - global2.data[36] / 150;
						global2.data[12] -= 4 - global2.data[36] / 150;
					}
					else
					{
						global2.data[5]++;
						global2.data[68]++;
						global2.data[12]++;
					}
				}
				else if (global2.data[16] == 14)
				{
					global2.data[26] -= global2.data[36] / 400;
					if (global2.data[36] < 1500)
					{
						global2.data[5] -= 7 - global2.data[36] / 150;
						global2.data[68] -= 7 - global2.data[36] / 150;
						global2.data[12] -= 7 - global2.data[36] / 150;
					}
					else
					{
						global2.data[5] += 3;
						global2.data[68] += 3;
						global2.data[12] += 3;
					}
				}
				else if (global2.data[16] == 15)
				{
					global2.data[26] -= global2.data[36] / 200;
					global2.data[5] -= 13 - global2.data[36] / 150;
					global2.data[68] -= 13 - global2.data[36] / 150;
					global2.data[12] -= 13 - global2.data[36] / 150;
				}
				else if (global2.data[16] == 12)
				{
					global2.data[26] -= global2.data[36] / 200;
					if (global2.data[36] < 600)
					{
						global2.data[5] -= 3 - global2.data[36] / 150;
						global2.data[68] -= 3 - global2.data[36] / 150;
						global2.data[12] -= 3 - global2.data[36] / 150;
					}
					else
					{
						global2.data[5]++;
						global2.data[68]++;
						global2.data[12]++;
					}
				}
				int num66 = UnityEngine.Random.Range(-10, 30);
				int num67 = 0;
				for (int num68 = 0; num68 < global2.allcountries.Length; num68++)
				{
					int num69;
					switch (num68)
					{
					default:
						num69 = ((num68 >= 106 && num68 < 109) ? 1 : 0);
						break;
					case 8:
					case 11:
					case 12:
					case 14:
					case 19:
					case 22:
					case 23:
					case 31:
					case 32:
					case 33:
					case 34:
					case 35:
					case 43:
					case 46:
					case 47:
					case 48:
					case 49:
					case 50:
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
					case 96:
					case 97:
						num69 = 1;
						break;
					}
					bool flag3 = (byte)num69 != 0;
					if (global2.allcountries[num68].econ && !flag3)
					{
						global2.allcountries[num68].soc_stab = 1000;
					}
					else
					{
						if ((num68 >= 53 && num68 < 69) || num68 == 1 || num68 == 20 || num68 == 45 || num68 == 10 || (num68 == 30 && global2.OAR) || ((num68 == 14 || num68 == 35 || num68 == 13) && global2.allcountries[num68].dev == 1) || (!global2.allcountries[num68].econ && !global2.allcountries[num68].okb))
						{
							continue;
						}
						num67++;
						Country country;
						if (global2.data[22] < global2.empires[1].money)
						{
							country = global2.allcountries[num68];
							country.soc_stab += (global2.data[22] - global2.empires[1].money) / 20;
						}
						else if (global2.data[22] > global2.empires[1].money && global2.allcountries[1].okb)
						{
							country = global2.allcountries[num68];
							country.soc_stab += 10;
						}
						if (global2.data[22] < global2.empires[0].money)
						{
							country = global2.allcountries[num68];
							country.soc_stab += (global2.data[22] - global2.empires[0].money) / 20;
						}
						else if (global2.data[22] > global2.empires[0].money && global2.allcountries[1].okb)
						{
							country = global2.allcountries[num68];
							country.soc_stab += 10;
						}
						if (global2.allcountries[num68].soc_stab > 1000)
						{
							global2.allcountries[num68].soc_stab = 1000;
						}
						if (global2.allcountries[num68].prosov)
						{
							global2.allcountries[num68].prosov = false;
							global2.allcountries[num68].proprc = false;
						}
						country = global2.allcountries[num68];
						country.soc_stab += global2.data[36] / 150;
						if (global2.allcountries[num68].soc_stab > 250 && (num68 < 71 || num68 >= 84))
						{
							if (global2.allcountries[num68].usalliance || global2.allcountries[num68].sovalliance)
							{
								country = global2.allcountries[num68];
								country.soc_stab -= 25;
								country = global2.allcountries[num68];
								country.soc_stab -= (global2.allcountries[num68].usalliance ? (global2.empires[0].power / 60) : (global2.empires[1].power / 60));
								country = global2.allcountries[num68];
								country.soc_stab -= global2.allcountries[num68].soc_stab / 60;
							}
							else
							{
								if (num68 < num66)
								{
									continue;
								}
								int num70 = 0;
								num70 = ((global2.empires[1].power <= global2.empires[0].power) ? global2.empires[0].power : global2.empires[1].power);
								if (((num68 >= 53 && num68 < 69) || global2.allcountries[num68].econ) && !global2.bad_done && UnityEngine.Random.Range(num70, 1500 - global2.allcountries[num68].soc_stab) > global2.influencePRC)
								{
									if (UnityEngine.Random.Range(num70, 1000) > global2.influencePRC)
									{
										int num71 = 4;
										if (global2.influencePRC > global2.empires[1].power)
										{
											num71--;
										}
										if (global2.influencePRC > global2.empires[0].power)
										{
											num71--;
										}
										if (global2.influencePRC > global2.empires[1].power / 2)
										{
											num71--;
										}
										if (global2.influencePRC > global2.empires[0].power / 2)
										{
											num71--;
										}
										if (!global2.allcountries[num68].proprc && num71 <= 2)
										{
											num71 = 2;
										}
										if (global2.allcountries[num68].soc_stab < 500 && num71 <= 2)
										{
											num71 = 2;
										}
										else if (global2.allcountries[num68].soc_stab < 500)
										{
											num71++;
										}
										Debug.Log("ra " + num71 + "i " + num68);
										global2.allcountries[num68].proprc = false;
										if (UnityEngine.Random.Range(num71, 7) > 4)
										{
											if (global2.empires[0].power >= global2.empires[1].power)
											{
												if (UnityEngine.Random.Range(0, 3) > 1)
												{
													global2.allcountries[num68].usalliance = true;
												}
												else
												{
													global2.allcountries[num68].sovalliance = true;
												}
											}
											else if (UnityEngine.Random.Range(0, 3) > 1)
											{
												global2.allcountries[num68].sovalliance = true;
											}
											else
											{
												global2.allcountries[num68].usalliance = true;
											}
										}
										global2.bad_done = true;
									}
									else if (global2.allcountries[num68].proprc)
									{
										global2.bad_done = true;
										global2.allcountries[num68].proprc = false;
									}
								}
								else if (!global2.bad_debuff && UnityEngine.Random.Range(num70, 2000 - global2.allcountries[num68].soc_stab) > global2.influencePRC)
								{
									global2.bad_debuff = true;
									country = global2.allcountries[num68];
									country.soc_stab -= 200;
									if (!global2.allcountries[num68].proprc)
									{
										country = global2.allcountries[num68];
										country.soc_stab += 50;
									}
								}
							}
						}
						else if (global2.allcountries[num68].soc_stab <= 250 && global2.data[120] <= 0 && num68 >= num66)
						{
							global2.data[120] = num68;
						}
					}
				}
				if (num67 < 1)
				{
					global2.allcountries[1].econ = false;
					global2.allcountries[1].okb = false;
				}
				if (global2.allcountries[69].cw)
				{
					global2.data[8] -= 10;
					if (global2.allcountries[69].dev <= 30 || (global2.allcountries[69].dev <= 60 && global2.allcountries[69].Torg) || (global2.allcountries[69].proprc && global2.allcountries[69].dev <= 100))
					{
						Country country = global2.allcountries[69];
						country.dev += 4;
					}
				}
				if (global2.allcountries[70].cw)
				{
					global2.data[8] -= 10;
					if (global2.allcountries[70].dev <= 30 || (global2.allcountries[70].dev <= 60 && global2.allcountries[70].Torg) || (global2.allcountries[70].proprc && global2.allcountries[70].dev <= 100))
					{
						Country country = global2.allcountries[70];
						country.dev += 4;
					}
				}
				if (global2.war == 1 && !global1.dlc[5])
				{
					global2.data[39] -= 25;
					global2.data[34]--;
				}
				if (global2.data[39] >= 1000 && global2.war == 1 && !global1.dlc[5])
				{
					global2.allcountries[11].prosov = false;
					global2.allcountries[11].proprc = true;
					global2.allcountries[11].isSEV = false;
					global2.allcountries[11].Gosstroy = global2.allcountries[1].Gosstroy;
					global2.allcountries[11].SubGosstroy = global2.allcountries[1].SubGosstroy;
					global2.allcountries[23].prosov = false;
					global2.allcountries[23].proprc = true;
					global2.allcountries[23].isSEV = false;
					global2.allcountries[23].puppetOf = -1;
					global2.allcountries[23].Gosstroy = global2.allcountries[1].Gosstroy;
					global2.allcountries[23].SubGosstroy = global2.allcountries[1].SubGosstroy;
					global2.war = 0;
					global2.data[39] = 0;
				}
				else if (global2.data[39] <= 0 && global2.war == 1 && !global1.dlc[5])
				{
					GameState gameState = global2;
					gameState.influencePRC -= 100;
					global2.war = 0;
					global2.data[39] = 0;
				}
				if (global1.dlc[5])
				{
					DirectWars(global2);
				}
				if (global2.modifies[12].active)
				{
					int num72 = global2.data[23];
					global2.data[23] -= num72 / 6;
				}
				if (global2.data[23] > global2.data[24])
				{
					global2.data[8] += (global2.data[23] - global2.data[24]) / 2;
					global2.data[3] += (global2.data[23] - global2.data[24]) / 3;
				}
				else
				{
					global2.data[8] -= (global2.data[23] - global2.data[24]) / 2;
					global2.data[3] -= (global2.data[23] - global2.data[24]) / 3;
					global2.data[5] -= (global2.data[23] - global2.data[24]) / 4;
				}
				if (global2.data[25] <= 4)
				{
					global2.data[4] -= -5 + global2.data[25];
					global2.data[9] -= -5 + global2.data[25];
				}
				else if (global2.data[25] > 12)
				{
					global2.data[4] += global2.data[25] - 12;
					global2.data[9] -= global2.data[25] - 12;
				}
				if (global2.data[31] > 700)
				{
					global2.data[5] -= (global2.data[31] - 500) / 100;
					global2.data[1] += (global2.data[31] - 500) / 100;
					global2.data[9] += (global2.data[31] - 500) / 100;
					if (global2.data[6] < 500)
					{
						global2.data[6] += 5;
					}
				}
				else if (global2.data[31] < 400 || global2.data[31] > 700)
				{
					global2.data[4] += (500 - global2.data[31]) / 100;
					global2.data[1] += (500 - global2.data[31]) / 100;
					global2.data[9] -= (global2.data[31] - 500) / 100;
					empire = global2.empires[0];
					empire.relations += (500 - global2.data[31]) / 100;
					empire = global2.empires[1];
					empire.relations += (500 - global2.data[31]) / 100;
				}
				Country[] allcountries = global2.allcountries;
				foreach (Country country2 in allcountries)
				{
					if (country2.isOVD)
					{
						empire = global2.empires[1];
						empire.power += 8;
					}
					else if (country2.isSEV)
					{
						empire = global2.empires[1];
						empire.power += 5;
					}
					else if (country2.prosov)
					{
						empire = global2.empires[1];
						empire.power += 2;
					}
					else if (country2.isNATO)
					{
						empire = global2.empires[0];
						empire.power += 5;
					}
					else if (country2.isEU)
					{
						empire = global2.empires[0];
						empire.power += 3;
					}
					else if (country2.Vyshi)
					{
						empire = global2.empires[0];
						empire.power++;
					}
				}
				empire = global2.empires[1];
				empire.power -= global2.influencePRC / 15;
				empire = global2.empires[0];
				empire.power -= global2.influencePRC / 15;
				empire = global2.empires[1];
				empire.power -= global2.empires[1].power / 9;
				empire = global2.empires[0];
				empire.power -= global2.empires[0].power / 9;
				global2.empires[1].money = global2.empires[1].power;
				global2.empires[0].money = global2.empires[0].power;
				for (int num73 = 0; num73 < global2.ingamewars.Length; num73++)
				{
					if (!global2.ingamewars[num73].is_going)
					{
						continue;
					}
					empire = global2.empires[0];
					empire.money -= global2.empires[0].money / 9;
					empire = global2.empires[1];
					empire.money -= global2.empires[1].money / 9;
					if (global2.ingamewars[num73].diplo_done[0])
					{
						if (global2.ingamewars[num73].usa_place == 0)
						{
							empire = global2.empires[0];
							empire.relations += 2;
							empire = global2.empires[1];
							empire.relations--;
						}
						if (global2.ingamewars[num73].ussr_place == 0)
						{
							empire = global2.empires[1];
							empire.relations += 2;
							empire = global2.empires[0];
							empire.relations--;
						}
					}
					else if (global2.ingamewars[num73].diplo_done[1])
					{
						if (global2.ingamewars[num73].usa_place == 1)
						{
							empire = global2.empires[0];
							empire.relations += 2;
							empire = global2.empires[1];
							empire.relations--;
						}
						if (global2.ingamewars[num73].ussr_place == 1)
						{
							empire = global2.empires[1];
							empire.relations += 2;
							empire = global2.empires[0];
							empire.relations--;
						}
					}
				}
				if (global2.data[69] > 7)
				{
					empire = global2.empires[0];
					empire.money += global2.data[69] / 7;
				}
				if (!global1.dlc[0])
				{
					if (global2.empires[1].now_leader == 0)
					{
						empire = global2.empires[1];
						empire.money += 20;
						if (!global2.relres && !global2.allcountries[1].isSEV)
						{
							empire = global2.empires[0];
							empire.relations += 5;
							global2.data[57] -= 2;
						}
					}
					else if (global2.empires[1].now_leader == 1)
					{
						if (!global2.relres && !global2.allcountries[1].isSEV)
						{
							empire = global2.empires[0];
							empire.relations += 5;
						}
						else
						{
							Politic[] politics = GlobalScript.inst.gameState.politics;
							foreach (Politic politic2 in politics)
							{
								if (politic2.traits[0] == 2)
								{
									Politic politic = politic2;
									politic.power += 5;
								}
							}
						}
					}
					else if (global2.empires[1].now_leader == 2)
					{
						empire = global2.empires[1];
						empire.relations += 5;
						if (global2.relres || global2.allcountries[1].isSEV)
						{
							Politic[] politics = GlobalScript.inst.gameState.politics;
							foreach (Politic politic3 in politics)
							{
								if (politic3.traits[0] == 1)
								{
									Politic politic = politic3;
									politic.power += 5;
								}
							}
						}
					}
					else if (global2.empires[1].now_leader == 3)
					{
						if (!global2.relres && !global2.allcountries[1].isSEV)
						{
							empire = global2.empires[0];
							empire.relations += 5;
							global2.data[57] -= 2;
						}
						else
						{
							empire = global2.empires[1];
							empire.relations += 5;
						}
					}
					else if (global2.empires[1].now_leader == 6)
					{
						empire = global2.empires[1];
						empire.money -= 20;
						empire = global2.empires[1];
						empire.relations += 5;
						global2.data[4] += 5;
						Politic[] politics = GlobalScript.inst.gameState.politics;
						foreach (Politic politic4 in politics)
						{
							if (politic4.traits[0] == 3)
							{
								Politic politic = politic4;
								politic.power += 5;
							}
						}
					}
					else if (global2.empires[1].now_leader == 5)
					{
						empire = global2.empires[1];
						empire.relations += 5;
						if (global2.relres || global2.allcountries[1].isSEV)
						{
							Politic[] politics = GlobalScript.inst.gameState.politics;
							foreach (Politic politic5 in politics)
							{
								if (politic5.traits[0] == 2)
								{
									Politic politic = politic5;
									politic.power += 5;
								}
							}
						}
					}
					else if (global2.empires[1].now_leader == 4)
					{
						if (!global2.relres && !global2.allcountries[1].isSEV)
						{
							global2.data[9] -= 5;
						}
						else
						{
							empire = global2.empires[1];
							empire.relations += 5;
							global2.data[9] += 5;
						}
					}
					else if (global2.empires[1].now_leader == 8)
					{
						empire = global2.empires[1];
						empire.money -= 20;
						empire = global2.empires[1];
						empire.relations += 5;
						global2.data[4] += 5;
					}
					if (global2.data[21] >= 1981 && global2.empires[0].now_leader <= 0)
					{
						empire = global2.empires[0];
						empire.money += 5;
						global2.data[4] += 5;
					}
					else if (global2.empires[0].now_leader == 1 || (global2.data[21] >= 1977 && global2.data[21] < 1981))
					{
						empire = global2.empires[0];
						empire.relations += 10;
					}
					else if (global2.empires[0].now_leader == 2)
					{
						empire = global2.empires[0];
						empire.money += 5;
						if (!global2.allcountries[2].isOVD && !global2.allcountries[2].okb)
						{
							empire = global2.empires[0];
							empire.relations += 5;
						}
					}
					else if (global2.empires[0].now_leader != 3)
					{
					}
				}
				else
				{
					EmpireModifiesChanges(global2.empires[0], 0);
					EmpireModifiesChanges(global2.empires[1], 1);
				}
				WorldWarsInfluenceChanges();
				if (global2.allcountries[51].dev == 1)
				{
					if (global2.empires[0].relations < 800 || global2.data[6] > 600)
					{
						global2.allcountries[51].dev = 0;
						global2.data[4] += 200;
						empire = global2.empires[1];
						empire.power += 20;
					}
					else
					{
						global2.data[9] += 10;
						global2.data[4] -= 5;
					}
				}
				if ((global2.data[34] - 9307) / 200 > 0)
				{
					global2.data[9] -= (global2.data[34] - 9307) / 200;
				}
				if (global2.data[16] == 11)
				{
					global2.data[8]++;
					global2.data[4] -= 2;
					global2.data[5] += 4;
					global2.data[12] += 2;
					global2.data[26] -= 5;
					if (global2.data[52] > 34)
					{
						global2.data[33] -= 50;
					}
				}
				else if (global2.data[16] == 10)
				{
					global2.data[5] += 2;
					global2.data[4]++;
					global2.data[68]--;
					global2.data[12]++;
					global2.data[26]++;
					if (global2.data[52] > 34)
					{
						global2.data[33] -= 50;
					}
				}
				else if (global2.data[16] == 12)
				{
					global2.data[13]++;
					global2.data[8]++;
					global2.data[68]++;
					global2.data[5] -= 2;
					global2.data[4] -= 2;
					global2.data[26]++;
					if (global2.data[54] < 40)
					{
						global2.data[26]++;
					}
					if (global2.data[52] > 35)
					{
						global2.data[33] -= 20;
					}
					else if (global2.data[52] < 35)
					{
						global2.data[33] += 30;
					}
				}
				else if (global2.data[16] == 13)
				{
					global2.data[8] += 2;
					global2.data[68]++;
					global2.data[5] -= 4;
					global2.data[4]++;
					global2.data[26]++;
					if (global2.data[54] < 40)
					{
						global2.data[26] += 2;
					}
					if (global2.data[52] > 36)
					{
						global2.data[33] -= 40;
					}
					else if (global2.data[52] < 36)
					{
						global2.data[33] += 30;
					}
				}
				else if (global2.data[16] == 14)
				{
					global2.data[8] += 2;
					global2.data[68] += 2;
					global2.data[5] -= 5;
					global2.data[4] += 2;
					global2.data[12]--;
					global2.data[26] += 2;
					if (global2.data[54] < 40)
					{
						global2.data[26] += 4;
					}
					if (global2.data[52] < 37)
					{
						global2.data[33] += 40;
					}
				}
				else if (global2.data[16] == 15)
				{
					global2.data[13]--;
					global2.data[68] += 3;
					global2.data[5] -= 7;
					global2.data[4] += 4;
					global2.data[12] -= 2;
					global2.data[26] += 2;
					if (global2.data[54] < 40)
					{
						global2.data[26] += 5;
					}
					if (global2.data[52] < 37)
					{
						global2.data[33] += 50;
					}
				}
				if (global2.data[15] == 6)
				{
					if (global2.data[54] > 38)
					{
						global2.data[55] -= 10;
					}
				}
				else if (global2.data[15] == 7)
				{
					if (global2.data[54] > 39)
					{
						global2.data[55] -= 20;
					}
					else if (global2.data[54] < 39)
					{
						global2.data[55] += 20;
					}
				}
				else if (global2.data[15] == 8)
				{
					if (global2.data[54] > 40)
					{
						global2.data[55] -= 20;
					}
					else if (global2.data[54] < 40)
					{
						global2.data[55] += 20;
					}
				}
				else if (global2.data[15] == 9 && global2.data[54] < 41)
				{
					global2.data[55] += 30;
				}
				if (global2.data[17] == 16)
				{
					if (global2.data[54] > 38)
					{
						global2.data[55] -= 10;
					}
				}
				else if (global2.data[17] == 17)
				{
					if (global2.data[54] > 39)
					{
						global2.data[55] -= 20;
					}
					else if (global2.data[54] < 39)
					{
						global2.data[55] += 20;
					}
				}
				else if (global2.data[17] == 18)
				{
					if (global2.data[54] > 40)
					{
						global2.data[55] -= 20;
					}
					else if (global2.data[54] < 40)
					{
						global2.data[55] += 20;
					}
				}
				else if (global2.data[17] == 19 && global2.data[54] < 41)
				{
					global2.data[55] += 30;
				}
				if (global2.data[50] == 24)
				{
					if (global2.data[54] > 38)
					{
						global2.data[55] -= 15;
					}
				}
				else if (global2.data[50] == 25)
				{
					if (global2.data[54] > 38)
					{
						global2.data[55] -= 15;
					}
				}
				else if (global2.data[50] == 28)
				{
					if (global2.data[54] < 40)
					{
						global2.data[55] += 10;
					}
				}
				else if (global2.data[50] == 29 && global2.data[54] > 39)
				{
					global2.data[55] -= 15;
				}
				if (global2.data[18] == 20)
				{
					global2.data[8]--;
					global2.data[3] -= 2;
					global2.data[4] -= 4;
					global2.data[57]++;
					if (global2.data[54] > 39)
					{
						global2.data[55] -= 10;
					}
				}
				else if (global2.data[18] == 21)
				{
					global2.data[1] -= 2;
					global2.data[4]--;
					if (global2.data[54] < 40)
					{
						global2.data[55] += 20;
					}
				}
				else if (global2.data[18] == 22)
				{
					global2.data[1] -= 3;
					global2.data[3]--;
					global2.data[4] += 2;
					global2.data[57] -= 2;
					if (global2.data[54] > 40)
					{
						global2.data[55] -= 20;
					}
					else if (global2.data[54] < 40)
					{
						global2.data[55] += 20;
					}
				}
				else if (global2.data[18] == 23)
				{
					global2.data[57] -= 4;
					global2.data[4] += 5;
					global2.data[3] -= 2;
					global2.data[1] -= 5;
					if (global2.data[54] < 41)
					{
						global2.data[55] += 30;
					}
				}
				if (global2.data[51] == 30)
				{
					if (global2.data[34] - 9307 > 99)
					{
						global2.data[8] -= (global2.data[34] - 9307) / 100;
						global2.data[22] += (global2.data[34] - 9307) / 100;
					}
					if (global2.data[54] > 38)
					{
						global2.data[55] -= 10;
					}
				}
				else if (global2.data[51] == 31)
				{
					if (global2.data[34] - 9307 > 199)
					{
						global2.data[8] -= (global2.data[34] - 9307) / 200;
						global2.data[22] += (global2.data[34] - 9307) / 200;
					}
				}
				else if (global2.data[51] == 32)
				{
					if (global2.data[34] - 9307 > 299)
					{
						global2.data[8] -= (global2.data[34] - 9307) / 300;
						global2.data[22] += (global2.data[34] - 9307) / 300;
					}
				}
				else if (global2.data[51] == 33)
				{
					if (global2.data[34] - 9307 > 149)
					{
						if (global2.data[5] < 500)
						{
							global2.data[8] -= (global2.data[34] - 9307) / 150;
							global2.data[22] += (global2.data[34] - 9307) / 250;
						}
						else if (global2.data[5] < 700)
						{
							global2.data[8] -= (global2.data[34] - 9307) / 150;
							global2.data[22] += (global2.data[34] - 9307) / 300;
						}
						else
						{
							global2.data[8] -= (global2.data[34] - 9307) / 500;
							global2.data[22] += (global2.data[34] - 9307) / 500;
						}
					}
					if (global2.data[54] < 40)
					{
						global2.data[55] += 10;
					}
					if (global2.data[52] < 36)
					{
						global2.data[33] += 10;
					}
				}
				if (global2.data[20] == 11 && global2.data[21] == 1977 && global2.allcountries[32].prosov)
				{
					global2.allcountries[32].prosov = false;
				}
				if (global1.dlc[0])
				{
					if (global2.gamerules[8] == 1)
					{
						if (global2.data[1] > 700)
						{
							global2.data[1] = 700;
						}
						if (global2.data[3] > 700)
						{
							global2.data[3] = 700;
						}
						if (global2.data[4] < 300)
						{
							global2.data[4] = 300;
						}
						if (global2.data[5] > 700)
						{
							global2.data[5] = 700;
						}
						if (global2.data[8] > 700)
						{
							global2.data[8] = 700;
						}
						if (global2.data[9] > 700)
						{
							global2.data[9] = 700;
						}
					}
					else if (global2.gamerules[8] == 2)
					{
						if (global2.data[1] > 500)
						{
							global2.data[1] = 500;
						}
						if (global2.data[3] > 500)
						{
							global2.data[3] = 500;
						}
						if (global2.data[4] < 500)
						{
							global2.data[4] = 500;
						}
						if (global2.data[5] > 500)
						{
							global2.data[5] = 500;
						}
						if (global2.data[8] > 500)
						{
							global2.data[8] = 500;
						}
						if (global2.data[9] > 500)
						{
							global2.data[9] = 500;
						}
					}
					if (global2.gamerules[7] == 1)
					{
						IEnumerable<(int, Politic)> enumerable = (from p in global2.politics.Select((Politic p, int item2) => (Key: item2, Value: p))
							orderby p.Key
							select p).Take(5);
						foreach (var item2 in enumerable)
						{
							Politic politic = global2.politics[item2.Item1];
							politic.power += 25 * (global2.data[21] - 1976);
						}
					}
					else if (global2.gamerules[7] == 2)
					{
						IEnumerable<(int, Politic)> enumerable2 = (from p in global2.politics.Select((Politic p, int item2) => (Key: item2, Value: p))
							orderby p.Key descending
							select p).Take(5);
						foreach (var item3 in enumerable2)
						{
							Politic politic = global2.politics[item3.Item1];
							politic.power += 25 * (global2.data[21] - 1976);
						}
					}
					if (global1.dlc[0] && global1.gameState.gamerules[1] > 0)
					{
						for (int num74 = 0; num74 < global2.is_party_enabled.Length; num74++)
						{
							global2.is_party_enabled[num74] = true;
							global2.party_number[num74] = global2.party_ideology[num74];
							if (GlobalScript.inst.gameState.data[15] > 7)
							{
								global2.is_party_ally[num74] = true;
							}
						}
					}
				}
				for (int num75 = 0; num75 < global2.politics.Length; num75++)
				{
					if (global2.modifies[14].active)
					{
						if (global2.politics[num75].traits[0] == 2)
						{
							Politic politic = global2.politics[num75];
							politic.power += 10;
						}
						else if (global2.politics[num75].traits[0] == 3 && global2.faction_leader[4] != num75)
						{
							Politic politic = global2.politics[num75];
							politic.power += 5;
						}
					}
					if (global2.faction_leader[0] == num75)
					{
						Politic politic = global2.politics[num75];
						politic.power += 20;
					}
					else if (global2.faction_leader[1] == num75)
					{
						Politic politic = global2.politics[num75];
						politic.power += 20;
					}
					else if (global2.faction_leader[2] == num75)
					{
						Politic politic = global2.politics[num75];
						politic.power += 20;
					}
					else if (global2.faction_leader[3] == num75)
					{
						Politic politic = global2.politics[num75];
						politic.power += 20;
					}
					else if (global2.faction_leader[4] == num75)
					{
						Politic politic = global2.politics[num75];
						politic.power += 20;
					}
					if (global2.politics_dolshnost[3] == num75 || global2.politics_dolshnost[4] == num75 || global2.politics_dolshnost[5] == num75 || global2.politics_dolshnost[6] == num75 || global2.politics_dolshnost[7] == num75)
					{
						if (global2.politics[num75].traits[0] == 0)
						{
							global2.data[5]--;
							empire = global2.empires[1];
							empire.relations += 2;
							if (global2.data[56] != 0)
							{
								global2.data[1] -= 2;
							}
							global2.data[68]--;
						}
						else if (global2.politics[num75].traits[0] == 1)
						{
							global2.data[5]++;
							global2.data[4]++;
							if (global2.data[56] != 1 && global2.data[56] != 2)
							{
								global2.data[1]--;
							}
							global2.data[1] += 2;
						}
						else if (global2.politics[num75].traits[0] == 2)
						{
							global2.data[5] -= 2;
							global2.data[4] += 2;
							if (global2.data[56] != 3)
							{
								global2.data[1]--;
							}
							global2.data[1] += 5;
						}
						else if (global2.politics[num75].traits[0] == 3)
						{
							global2.data[5] -= 5;
							global2.data[4] += 7;
							if (global2.data[56] != 4)
							{
								global2.data[1]--;
							}
							global2.data[1] += 10;
							global2.data[8]++;
						}
						if (global2.politics[num75].traits[1] == 4)
						{
							global2.data[26]--;
							global2.data[4] -= 5;
							global2.data[1] -= 2;
						}
						else if (global2.politics[num75].traits[1] == 5)
						{
							global2.data[1] += 2;
						}
						else if (global2.politics[num75].traits[1] == 6)
						{
							global2.data[26]++;
							global2.data[4] += 5;
							global2.data[1] += 5;
						}
						else if (global2.politics[num75].traits[1] == 7)
						{
							global2.data[11] += 2;
						}
						if (global2.politics[num75].traits[2] == 8)
						{
							global2.data[4] -= 10;
							global2.data[1] -= 5;
						}
						else if (global2.politics[num75].traits[2] == 9)
						{
							global2.data[4] += 2;
							global2.data[1] += 2;
						}
						else if (global2.politics[num75].traits[2] == 10)
						{
							global2.data[1] -= 2;
						}
						else if (global2.politics[num75].traits[2] == 11)
						{
							global2.data[8]++;
						}
						else if (global2.politics[num75].traits[2] == 12)
						{
							global2.data[4] += 3;
							global2.data[1] -= 5;
						}
						else if (global2.politics[num75].traits[2] == 13)
						{
							global2.data[1] += 5;
						}
						else if (global2.politics[num75].traits[2] == 14)
						{
							global2.data[4] += 3;
							global2.data[31] += 5;
						}
						else if (global2.politics[num75].traits[2] == 15)
						{
							global2.data[4] += 3;
							global2.data[31] -= 5;
						}
						else if (global2.politics[num75].traits[2] == 16)
						{
							global2.data[1] += 2;
						}
						else if (global2.politics[num75].traits[2] == 17)
						{
							global2.data[4] += 2;
						}
						else if (global2.politics[num75].traits[2] == 18)
						{
							global2.data[26] += 2;
							global2.data[1] += 5;
							global2.data[8]--;
						}
						else if (global2.politics[num75].traits[2] == 19)
						{
							global2.data[4] += 2;
						}
					}
					if (global2.politics_dolshnost[2] == num75)
					{
						if (global2.politics[num75].traits[0] == 0)
						{
							empire = global2.empires[1];
							empire.relations += 12;
							empire = global2.empires[0];
							empire.relations -= 16;
							if (global2.data[6] < 700)
							{
								global2.data[6] += 2;
							}
							else if (global2.data[6] < 900)
							{
								global2.data[6]++;
							}
							global2.party_ideology[0] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 666;
							global2.party_ideology[1] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 1000;
						}
						else if (global2.politics[num75].traits[0] == 1)
						{
							empire = global2.empires[1];
							empire.relations += 5;
							empire = global2.empires[0];
							empire.relations -= 6;
							if (global2.data[6] < 500)
							{
								global2.data[6] += 2;
							}
							else if (global2.data[6] < 700)
							{
								global2.data[6]++;
							}
							else if (global2.data[6] > 900)
							{
								global2.data[6]--;
							}
							global2.party_ideology[2] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
							global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 666;
							global2.party_ideology[1] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 2000;
						}
						else if (global2.politics[num75].traits[0] == 2)
						{
							empire = global2.empires[1];
							empire.relations -= 3;
							empire = global2.empires[0];
							empire.relations += 5;
							if (global2.data[6] < 300)
							{
								global2.data[6]++;
							}
							else if (global2.data[6] > 700)
							{
								global2.data[6] -= 2;
							}
							else if (global2.data[6] > 500)
							{
								global2.data[6]--;
							}
							global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 666;
							global2.party_ideology[4] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 666;
						}
						else if (global2.politics[num75].traits[0] == 3)
						{
							empire = global2.empires[1];
							empire.relations -= 10;
							empire = global2.empires[0];
							empire.relations += 12;
							if (global2.data[6] > 700)
							{
								global2.data[6] -= 3;
							}
							else if (global2.data[6] > 500)
							{
								global2.data[6] -= 2;
							}
							else if (global2.data[6] > 300)
							{
								global2.data[6]--;
							}
							global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 666;
							global2.party_ideology[4] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 666;
						}
						if (global2.politics[num75].traits[1] == 4)
						{
							empire = global2.empires[1];
							empire.relations -= 3;
							empire = global2.empires[0];
							empire.relations -= 3;
						}
						else if (global2.politics[num75].traits[1] == 5)
						{
							empire = global2.empires[1];
							empire.relations += 3;
							empire = global2.empires[0];
							empire.relations += 3;
							if (global2.data[6] < 700)
							{
								global2.data[6]++;
							}
							else if (global2.data[6] > 700)
							{
								global2.data[6]--;
							}
						}
						else if (global2.politics[num75].traits[1] == 6)
						{
							empire = global2.empires[1];
							empire.relations += 4;
							empire = global2.empires[0];
							empire.relations += 4;
							if (global2.data[6] > 600)
							{
								global2.data[6]--;
							}
						}
						else if (global2.politics[num75].traits[1] == 7)
						{
							global2.data[11] += 2;
						}
						if (global2.politics[num75].traits[2] == 8)
						{
							empire = global2.empires[1];
							empire.relations -= 3;
							empire = global2.empires[0];
							empire.relations -= 3;
							if (global2.data[6] < 500)
							{
								global2.data[6] += 2;
							}
							else if (global2.data[6] < 700)
							{
								global2.data[6]++;
							}
						}
						else if (global2.politics[num75].traits[2] == 9)
						{
							empire = global2.empires[1];
							empire.relations += 2;
							empire = global2.empires[0];
							empire.relations += 2;
							if (global2.data[6] > 700)
							{
								global2.data[6]--;
							}
						}
						else if (global2.politics[num75].traits[2] == 10)
						{
							empire = global2.empires[1];
							empire.relations -= 3;
							empire = global2.empires[0];
							empire.relations -= 3;
							global2.data[6]++;
						}
						else if (global2.politics[num75].traits[2] == 11)
						{
							global2.data[8]++;
							empire = global2.empires[1];
							empire.relations--;
							empire = global2.empires[0];
							empire.relations--;
						}
						else if (global2.politics[num75].traits[2] == 12)
						{
							empire = global2.empires[1];
							empire.relations--;
							empire = global2.empires[0];
							empire.relations--;
							global2.data[6]++;
						}
						else if (global2.politics[num75].traits[2] == 13)
						{
							global2.data[1] += 3;
						}
						else if (global2.politics[num75].traits[2] == 14)
						{
							empire = global2.empires[1];
							empire.relations -= 3;
							empire = global2.empires[0];
							empire.relations -= 3;
							if (global2.data[6] < 500)
							{
								global2.data[6] += 2;
							}
							else if (global2.data[6] < 800)
							{
								global2.data[6]++;
							}
							else if (global2.data[6] > 900)
							{
								global2.data[6]--;
							}
						}
						else if (global2.politics[num75].traits[2] == 15)
						{
							empire = global2.empires[1];
							empire.relations -= 6;
							empire = global2.empires[0];
							empire.relations += 6;
							global2.data[6]--;
						}
						else if (global2.politics[num75].traits[2] == 16)
						{
							empire = global2.empires[1];
							empire.relations += 2;
							empire = global2.empires[0];
							empire.relations += 2;
						}
						else if (global2.politics[num75].traits[2] != 17)
						{
							if (global2.politics[num75].traits[2] == 18)
							{
								global2.data[8]--;
							}
							else if (global2.politics[num75].traits[2] == 19)
							{
								empire = global2.empires[0];
								empire.relations -= 2;
								empire = global2.empires[1];
								empire.relations -= 2;
							}
						}
					}
					if (global2.politics_dolshnost[1] == num75)
					{
						if (global2.politics[num75].traits[0] == 0)
						{
							global2.data[5] += 6;
							empire = global2.empires[1];
							empire.relations += 5;
							if (global2.data[56] != 0)
							{
								global2.data[1] -= 3;
							}
							global2.data[1] -= 3;
							global2.data[68]--;
							global2.party_ideology[0] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
							global2.party_ideology[1] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 500;
						}
						else if (global2.politics[num75].traits[0] == 1)
						{
							global2.data[5] += 2;
							global2.data[4] += 3;
							if (global2.data[56] != 1 && global2.data[56] != 2)
							{
								global2.data[1]--;
							}
							global2.data[1] += 5;
							global2.party_ideology[2] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 222;
							global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
							global2.party_ideology[1] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 1000;
						}
						else if (global2.politics[num75].traits[0] == 2)
						{
							global2.data[5] -= 3;
							global2.data[4] += 5;
							if (global2.data[56] != 3)
							{
								global2.data[1]--;
							}
							global2.data[1] += 7;
							global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 222;
							global2.party_ideology[4] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
						}
						else if (global2.politics[num75].traits[0] == 3)
						{
							global2.data[5] -= 7;
							global2.data[4] += 5;
							if (global2.data[56] != 4)
							{
								global2.data[1]--;
							}
							global2.data[1] += 5;
							global2.data[8] += 2;
							global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
							global2.party_ideology[4] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 222;
						}
						if (global2.politics[num75].traits[1] == 4)
						{
							global2.data[26]--;
							global2.data[4] -= 7;
							global2.data[1] -= 3;
						}
						else if (global2.politics[num75].traits[1] == 5)
						{
							global2.data[1] += 3;
						}
						else if (global2.politics[num75].traits[1] == 6)
						{
							global2.data[26]++;
							global2.data[4] += 7;
							global2.data[1] += 7;
						}
						else if (global2.politics[num75].traits[1] == 7)
						{
							global2.data[11] += 3;
						}
						if (global2.politics[num75].traits[2] == 8)
						{
							global2.data[4] -= 15;
							global2.data[1] -= 7;
						}
						else if (global2.politics[num75].traits[2] == 9)
						{
							global2.data[4] += 2;
							global2.data[1] += 3;
						}
						else if (global2.politics[num75].traits[2] == 10)
						{
							global2.data[1] -= 3;
						}
						else if (global2.politics[num75].traits[2] == 11)
						{
							global2.data[8]++;
						}
						else if (global2.politics[num75].traits[2] == 12)
						{
							global2.data[4] += 3;
							global2.data[1] -= 7;
						}
						else if (global2.politics[num75].traits[2] == 13)
						{
							global2.data[1] += 7;
						}
						else if (global2.politics[num75].traits[2] == 14)
						{
							global2.data[4] += 3;
							global2.data[31] += 7;
						}
						else if (global2.politics[num75].traits[2] == 15)
						{
							global2.data[4] += 3;
							global2.data[31] -= 7;
						}
						else if (global2.politics[num75].traits[2] == 16)
						{
							global2.data[1] += 3;
						}
						else if (global2.politics[num75].traits[2] == 17)
						{
							global2.data[4] += 2;
						}
						else if (global2.politics[num75].traits[2] == 18)
						{
							global2.data[26] += 3;
							global2.data[1] += 7;
							global2.data[8]--;
						}
						else if (global2.politics[num75].traits[2] == 19)
						{
							global2.data[1]++;
							global2.data[22]--;
						}
					}
					if (global2.politics_dolshnost[0] != num75)
					{
						continue;
					}
					if (global2.politics[num75].traits[0] == 0)
					{
						global2.data[5] += 6;
						empire = global2.empires[1];
						empire.relations += 5;
						if (global2.data[56] != 0)
						{
							global2.data[1] -= 3;
						}
						global2.data[1] -= 3;
						global2.data[68]--;
						global2.party_ideology[0] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
						global2.party_ideology[1] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 500;
					}
					else if (global2.politics[num75].traits[0] == 1)
					{
						global2.data[5] += 2;
						global2.data[4] += 5;
						if (global2.data[56] != 1 && global2.data[56] != 2)
						{
							global2.data[1]--;
						}
						global2.data[1] += 5;
						global2.party_ideology[2] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 222;
						global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
						global2.party_ideology[1] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 1000;
					}
					else if (global2.politics[num75].traits[0] == 2)
					{
						global2.data[5] -= 5;
						global2.data[4] += 5;
						if (global2.data[56] != 3)
						{
							global2.data[1]--;
						}
						global2.data[1] += 10;
						global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 222;
						global2.party_ideology[4] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
					}
					else if (global2.politics[num75].traits[0] == 3)
					{
						global2.data[5] -= 10;
						global2.data[4] += 15;
						if (global2.data[56] != 4)
						{
							global2.data[1] -= 2;
						}
						global2.data[1] += 20;
						global2.data[8] += 3;
						global2.party_ideology[3] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 333;
						global2.party_ideology[4] += (global2.party_ideology[0] + global2.party_ideology[1] + global2.party_ideology[2] + global2.party_ideology[3] + global2.party_ideology[4]) / 222;
					}
					if (global2.politics[num75].traits[1] == 4)
					{
						global2.data[26]--;
						global2.data[4] -= 10;
						global2.data[1] -= 5;
					}
					else if (global2.politics[num75].traits[1] == 5)
					{
						global2.data[1] += 5;
					}
					else if (global2.politics[num75].traits[1] == 6)
					{
						global2.data[26]++;
						global2.data[4] += 10;
						global2.data[1] += 10;
					}
					else if (global2.politics[num75].traits[1] == 7)
					{
						global2.data[11] += 5;
					}
					if (global2.politics[num75].traits[2] == 8)
					{
						global2.data[4] -= 15;
						global2.data[1] -= 10;
					}
					else if (global2.politics[num75].traits[2] == 9)
					{
						global2.data[4] += 3;
						global2.data[1] += 5;
					}
					else if (global2.politics[num75].traits[2] == 10)
					{
						global2.data[1] -= 5;
					}
					else if (global2.politics[num75].traits[2] == 11)
					{
						global2.data[8]++;
					}
					else if (global2.politics[num75].traits[2] == 12)
					{
						global2.data[4] += 5;
						global2.data[1] -= 10;
					}
					else if (global2.politics[num75].traits[2] == 13)
					{
						global2.data[1] += 10;
					}
					else if (global2.politics[num75].traits[2] == 14)
					{
						global2.data[4] += 5;
						global2.data[31] += 10;
					}
					else if (global2.politics[num75].traits[2] == 15)
					{
						global2.data[4] += 5;
						global2.data[31] -= 10;
					}
					else if (global2.politics[num75].traits[2] == 16)
					{
						global2.data[1] += 5;
					}
					else if (global2.politics[num75].traits[2] == 17)
					{
						global2.data[4] += 3;
					}
					else if (global2.politics[num75].traits[2] == 18)
					{
						global2.data[26] += 5;
						global2.data[1] += 10;
						global2.data[8]--;
					}
					else if (global2.politics[num75].traits[2] == 19)
					{
						global2.data[4] += 2;
						global2.data[1] += 2;
						global2.data[22]--;
						empire = global2.empires[0];
						empire.relations--;
						empire = global2.empires[1];
						empire.relations--;
						global2.data[8]--;
					}
					if (global2.politics[num75].traits[0] == 0)
					{
						empire = global2.empires[1];
						empire.relations += 12;
						empire = global2.empires[0];
						empire.relations -= 16;
					}
					else if (global2.politics[num75].traits[0] == 1)
					{
						empire = global2.empires[1];
						empire.relations += 5;
						empire = global2.empires[0];
						empire.relations -= 6;
					}
					else if (global2.politics[num75].traits[0] == 2)
					{
						empire = global2.empires[1];
						empire.relations -= 3;
						empire = global2.empires[0];
						empire.relations += 5;
						global2.data[6]--;
					}
					else if (global2.politics[num75].traits[0] == 3)
					{
						empire = global2.empires[1];
						empire.relations -= 10;
						empire = global2.empires[0];
						empire.relations += 12;
						global2.data[6]--;
					}
					if (global2.politics[num75].traits[1] == 4)
					{
						empire = global2.empires[1];
						empire.relations -= 3;
						empire = global2.empires[0];
						empire.relations -= 3;
					}
					else if (global2.politics[num75].traits[1] == 5)
					{
						empire = global2.empires[1];
						empire.relations += 3;
						empire = global2.empires[0];
						empire.relations += 3;
					}
					else if (global2.politics[num75].traits[1] == 6)
					{
						empire = global2.empires[1];
						empire.relations += 4;
						empire = global2.empires[0];
						empire.relations += 4;
						if (global2.data[6] > 600)
						{
							global2.data[6]--;
						}
					}
					else if (global2.politics[num75].traits[1] == 7)
					{
						global2.data[11] += 2;
					}
					if (global2.politics[num75].traits[2] == 8)
					{
						empire = global2.empires[1];
						empire.relations -= 3;
						empire = global2.empires[0];
						empire.relations -= 3;
						global2.data[6] += global2.data[6] / 166;
					}
					else if (global2.politics[num75].traits[2] == 9)
					{
						empire = global2.empires[1];
						empire.relations += 2;
						empire = global2.empires[0];
						empire.relations += 2;
					}
					else if (global2.politics[num75].traits[2] == 10)
					{
						empire = global2.empires[1];
						empire.relations -= 3;
						empire = global2.empires[0];
						empire.relations -= 3;
					}
					else if (global2.politics[num75].traits[2] == 11)
					{
						global2.data[8]++;
						empire = global2.empires[1];
						empire.relations--;
						empire = global2.empires[0];
						empire.relations--;
					}
					else if (global2.politics[num75].traits[2] == 12)
					{
						empire = global2.empires[1];
						empire.relations--;
						empire = global2.empires[0];
						empire.relations--;
					}
					else if (global2.politics[num75].traits[2] == 13)
					{
						global2.data[1] += 3;
					}
					else if (global2.politics[num75].traits[2] == 14)
					{
						empire = global2.empires[1];
						empire.relations -= 3;
						empire = global2.empires[0];
						empire.relations -= 3;
						global2.data[6] += global2.data[6] / 200;
					}
					else if (global2.politics[num75].traits[2] == 15)
					{
						empire = global2.empires[1];
						empire.relations -= 6;
						empire = global2.empires[0];
						empire.relations += 6;
						global2.data[6] -= global2.data[6] / 166;
					}
					else if (global2.politics[num75].traits[2] == 16)
					{
						empire = global2.empires[1];
						empire.relations += 2;
						empire = global2.empires[0];
						empire.relations += 2;
					}
					else if (global2.politics[num75].traits[2] != 17)
					{
						if (global2.politics[num75].traits[2] == 18)
						{
							global2.data[8]--;
							global2.data[26]++;
						}
						else if (global2.politics[num75].traits[2] == 19)
						{
							empire = global2.empires[0];
							empire.relations -= 2;
							empire = global2.empires[1];
							empire.relations -= 2;
						}
					}
					if (global2.politics[num75].traits[0] == 0)
					{
						global2.data[5]--;
						empire = global2.empires[1];
						empire.relations += 2;
						if (global2.data[56] != 0)
						{
							global2.data[1] -= 3;
						}
						global2.data[68]--;
					}
					else if (global2.politics[num75].traits[0] == 1)
					{
						global2.data[5]++;
						global2.data[4] += 2;
						if (global2.data[56] != 1 && global2.data[56] != 2)
						{
							global2.data[1]--;
						}
						global2.data[1] += 2;
					}
					else if (global2.politics[num75].traits[0] == 2)
					{
						global2.data[5] -= 2;
						global2.data[4] += 3;
						if (global2.data[56] != 3)
						{
							global2.data[1]--;
						}
						global2.data[1] += 5;
					}
					else if (global2.politics[num75].traits[0] == 3)
					{
						global2.data[5] -= 5;
						global2.data[4] += 7;
						if (global2.data[56] != 4)
						{
							global2.data[1]--;
						}
						global2.data[1] += 10;
						global2.data[8]++;
					}
					if (global2.politics[num75].traits[1] == 4)
					{
						global2.data[26]--;
						global2.data[4] -= 5;
						global2.data[1] -= 2;
					}
					else if (global2.politics[num75].traits[1] == 5)
					{
						global2.data[1] += 2;
					}
					else if (global2.politics[num75].traits[1] == 6)
					{
						global2.data[26]++;
						global2.data[4] += 5;
						global2.data[1] += 5;
					}
					else if (global2.politics[num75].traits[1] == 7)
					{
						global2.data[11] += 2;
					}
					if (global2.politics[num75].traits[2] == 8)
					{
						global2.data[4] -= 10;
						global2.data[1] -= 5;
					}
					else if (global2.politics[num75].traits[2] == 9)
					{
						global2.data[4] += 2;
						global2.data[1] += 2;
					}
					else if (global2.politics[num75].traits[2] == 10)
					{
						global2.data[1] -= 2;
					}
					else if (global2.politics[num75].traits[2] == 11)
					{
						global2.data[8]++;
					}
					else if (global2.politics[num75].traits[2] == 12)
					{
						global2.data[4] += 3;
						global2.data[1] -= 5;
					}
					else if (global2.politics[num75].traits[2] == 13)
					{
						global2.data[1] += 5;
					}
					else if (global2.politics[num75].traits[2] == 14)
					{
						global2.data[4] += 3;
						global2.data[31] += 5;
					}
					else if (global2.politics[num75].traits[2] == 15)
					{
						global2.data[4] += 5;
						global2.data[31] -= 5;
					}
					else if (global2.politics[num75].traits[2] == 16)
					{
						global2.data[1] += 2;
					}
					else if (global2.politics[num75].traits[2] == 17)
					{
						global2.data[4] += 2;
					}
					else if (global2.politics[num75].traits[2] == 18)
					{
						global2.data[26] += 2;
						global2.data[1] += 5;
						global2.data[8]--;
					}
					else if (global2.politics[num75].traits[2] == 19)
					{
						global2.data[4] += 2;
					}
				}
				if (global2.science[0])
				{
					global2.data[5] += 2;
					global2.data[13]++;
				}
				if (global2.science[1])
				{
					global2.data[13] += 2;
				}
				if (global2.science[2])
				{
					global2.data[5]++;
					global2.data[13]++;
					global2.data[8]++;
				}
				if (global2.science[3])
				{
					global2.data[5] += 2;
					global2.data[13]++;
				}
				if (global2.science[4])
				{
					global2.data[5] += 4;
					global2.data[11] += 5;
				}
				if (global2.science[5])
				{
					global2.data[5] += 2;
					global2.data[11] += 10;
				}
				if (global2.science[6])
				{
					global2.data[5] += 2;
					global2.data[13]++;
				}
				if (global2.science[7])
				{
					global2.data[5] += 2;
					global2.data[8]++;
				}
				if (global2.science[8])
				{
					global2.data[13] += 2;
				}
				if (global2.science[9])
				{
					global2.data[8]++;
					global2.data[12] += 2;
				}
				if (global2.science[10])
				{
					global2.data[8]++;
					global2.data[22] += 4;
					global2.data[12] += 2;
				}
				if (global2.science[11])
				{
					global2.data[5] += 2;
				}
				if (global2.science[12])
				{
					global2.data[8] += 2;
					global2.data[12]++;
				}
				if (global2.science[13])
				{
					global2.data[5] += 3;
				}
				if (global2.science[14])
				{
					global2.data[5] += 2;
					global2.data[8]++;
					global2.data[12] += 2;
				}
				if (global2.science[15])
				{
					global2.data[5] += 2;
					global2.data[8] += 2;
					global2.data[12]++;
					global2.data[13]++;
				}
				if (global2.science[16])
				{
					global2.data[8] += 2;
					global2.data[5] += 3;
					global2.data[11] += 5;
					global2.data[57] += 4;
				}
				if (global2.science[17])
				{
					global2.data[5] += 3;
					global2.data[8] += 3;
				}
				if (global2.science[18])
				{
					global2.data[22] += 2;
				}
				if (global2.science[19])
				{
					global2.data[9] += 3;
					global2.data[4] -= 3;
				}
				if (global2.science[20])
				{
					global2.data[9] += 2;
					global2.data[4] -= 2;
					global2.data[3] += 2;
				}
				if (global2.science[21])
				{
					global2.data[22] += 2;
					global2.data[1] += 3;
					global2.data[3]++;
				}
				if (global2.science[22])
				{
					global2.data[3] += 2;
					global2.data[4] -= 2;
					global2.data[1] += 2;
				}
				if (global2.science[23])
				{
					global2.data[22] += 4;
				}
				if (global2.science[24])
				{
					global2.data[22] += 4;
					global2.data[4] -= 2;
				}
				if (global2.science[25])
				{
					global2.data[9] += 2;
					global2.data[4] -= 2;
					global2.data[1] += 3;
				}
				if (global2.science[26])
				{
					global2.data[22] += 4;
					global2.data[4] -= 2;
				}
				if (global2.science[27])
				{
					global2.data[8] += 2;
					global2.data[5] += 2;
					global2.data[3] += 2;
				}
				if (global2.science[28])
				{
					global2.data[22] += 5;
					global2.data[9] += 5;
				}
				if (global2.science[29])
				{
					global2.data[22] += 10;
					empire = global2.empires[0];
					empire.relations -= 5;
					empire = global2.empires[1];
					empire.relations -= 5;
				}
				if (global2.science[30])
				{
					global2.data[3] += 3;
					empire = global2.empires[0];
					empire.power--;
					empire = global2.empires[1];
					empire.relations--;
				}
				if (global2.science[31])
				{
					global2.data[22] += 5;
					global2.data[11] += 5;
				}
				if (global2.science[32])
				{
					global2.data[13] += 5;
					global2.data[5] += 5;
				}
				if (global2.science[33])
				{
					global2.data[22] += 5;
					global2.data[12] += 5;
					empire = global2.empires[0];
					empire.relations -= 5;
					empire = global2.empires[1];
					empire.relations -= 5;
				}
				InfluenceFromInvestments();
				MutualRelationsChange();
				if (global2.data[5] < 200)
				{
					global2.modifies[4].active = true;
					global2.data[4] += 2;
					global2.data[57] -= 3;
					global2.data[12] -= (250 - global2.data[5]) / 40;
				}
				else if (global2.data[5] < (global2.data[16] - 10) * 100 && global2.data[16] > 12)
				{
					global2.modifies[4].active = true;
					global2.data[12] -= ((global2.data[16] - 10) * 100 - global2.data[5]) / 40;
					global2.data[26]++;
					global2.data[57] -= 3;
				}
				else
				{
					global2.modifies[4].active = false;
				}
				if (global2.data[16] <= 11)
				{
					if (global2.data[21] < 1980)
					{
						global2.data[4] += (1000 - global2.data[5]) / 50;
					}
					else
					{
						global2.data[4] += (1000 - global2.data[5]) / 40;
					}
				}
				else if (global2.data[16] == 12)
				{
					if (global2.data[21] < 1980)
					{
						global2.data[4] += (1000 - global2.data[5]) / 70;
					}
					else
					{
						global2.data[4] += (1000 - global2.data[5]) / 60;
					}
				}
				if (global2.data[12] < 250)
				{
					global2.data[12] -= 2;
					global2.data[1] -= 10;
					global2.data[5] -= 5;
					global2.data[22] -= 5;
				}
				else if (global2.data[12] < 410)
				{
					global2.data[12] -= 3;
					global2.data[1] -= 5;
					global2.data[5] -= 2;
					global2.data[22] -= 2;
				}
				else if (global2.data[12] < 610)
				{
					global2.data[12] -= 15;
					global2.data[1]--;
				}
				else if (global2.data[12] < 710)
				{
					global2.data[12] -= 22;
				}
				else if (global2.data[12] < 810)
				{
					global2.data[12] -= 28;
				}
				else
				{
					global2.data[12] -= 40;
					global2.data[9] += 5;
				}
				if (global2.data[16] < 13)
				{
					if (global2.data[13] < 300)
					{
						global2.data[12] -= 4;
					}
					else if (global2.data[13] < 500)
					{
						global2.data[12] -= 2;
					}
				}
				global2.data[8] += global2.data[12] / 50;
				if (global2.data[68] < 250)
				{
					global2.data[68]--;
					global2.data[1] -= 10;
					global2.data[5] -= 5;
				}
				else if (global2.data[68] < 410)
				{
					global2.data[68] -= 3;
					global2.data[1] -= 5;
					global2.data[5] -= 2;
				}
				else if (global2.data[68] < 610)
				{
					global2.data[68] -= 15;
					global2.data[1]--;
				}
				else if (global2.data[68] < 710)
				{
					global2.data[68] -= 22;
				}
				else if (global2.data[68] < 810)
				{
					global2.data[68] -= 28;
				}
				else
				{
					global2.data[68] -= 40;
					global2.data[5] += 5;
				}
				if (global2.data[16] < 13)
				{
					if (global2.data[13] < 300)
					{
						global2.data[68] -= 5;
					}
					else if (global2.data[13] < 500)
					{
						global2.data[68] -= 2;
					}
				}
				global2.data[8] += global2.data[68] / 50;
				if (global2.data[13] < 250)
				{
					global2.data[13] -= 2;
					global2.data[1] -= 10;
					global2.data[5] -= 5;
				}
				else if (global2.data[13] < 410)
				{
					global2.data[13] -= 9;
					global2.data[1] -= 5;
					global2.data[5] -= 2;
				}
				else if (global2.data[13] < 610)
				{
					global2.data[13] -= 15;
					global2.data[1]--;
				}
				else if (global2.data[13] < 710)
				{
					global2.data[13] -= 22;
				}
				else if (global2.data[13] < 810)
				{
					global2.data[13] -= 28;
				}
				else
				{
					global2.data[13] -= 40;
					global2.data[22] += 5;
				}
				global2.data[8] += global2.data[13] / 100;
				if (global2.empires[0].now_leader != 3 || (global2.empires[0].now_leader == 3 && global2.data[20] % 2 == 0))
				{
					if (global2.data[69] / 40 <= 0 && global2.data[69] > 0)
					{
						global2.data[8]--;
						if (global2.data[21] >= 1983)
						{
							global2.data[8] -= 2;
						}
						else if (global2.data[21] >= 1980)
						{
							global2.data[8]--;
						}
						if (global2.data[69] > 10)
						{
							global2.data[69]--;
						}
						if (global2.allcountries[1].isSEV)
						{
							empire = global2.empires[1];
							empire.relations -= 2;
						}
					}
					else if (global2.data[69] > 0)
					{
						global2.data[8] -= global2.data[69] / 40;
						if (global2.data[21] >= 1983)
						{
							global2.data[8]--;
						}
						else if (global2.data[21] >= 1983)
						{
							global2.data[8] -= 2;
						}
						if (global2.allcountries[1].isSEV)
						{
							empire = global2.empires[1];
							empire.relations -= global2.data[69] / 20;
						}
						if (global2.data[69] > 10)
						{
							global2.data[69] -= global2.data[69] / 40 / 2 + 1;
						}
					}
				}
				else if (global2.empires[0].now_leader == 3)
				{
					if (global2.data[69] / 40 <= 0 && global2.data[69] > 0)
					{
						if (global2.data[69] > 10)
						{
							global2.data[69]--;
						}
						if (global2.allcountries[1].isSEV)
						{
							empire = global2.empires[1];
							empire.relations -= 2;
						}
					}
					else if (global2.data[69] > 0)
					{
						if (global2.allcountries[1].isSEV)
						{
							empire = global2.empires[1];
							empire.relations -= global2.data[69] / 20;
						}
						if (global2.data[69] > 10)
						{
							global2.data[69] -= global2.data[69] / 40 / 2 + 1;
						}
					}
				}
				bool flag4 = false;
				for (int num76 = 0; num76 < global2.science_in_progress.Length; num76++)
				{
					if (global2.science_in_progress[num76] && global2.science_time[num76] < global2.science_need_time[num76] && !global2.science[num76])
					{
						flag4 = true;
						if (global2.science_time[num76] + global2.data[11] <= global2.science_need_time[num76])
						{
							global2.science_time[num76] += global2.data[11];
							global2.data[11] = 0;
						}
						else
						{
							global2.science_time[num76] += global2.science_need_time[num76] - global2.science_time[num76];
							global2.data[11] -= global2.science_need_time[num76] - global2.science_time[num76];
						}
					}
					else if (global2.science_time[num76] >= global2.science_need_time[num76] && global2.science_in_progress[num76] && !global2.science[num76])
					{
						global2.science_in_progress[num76] = false;
						global2.science[num76] = true;
						switch (num76)
						{
						case 0:
							global2.data[24] -= 3;
							break;
						case 1:
							global2.data[24] -= 2;
							break;
						case 2:
						{
							GameState gameState = global2;
							gameState.influencePRC += 10;
							break;
						}
						case 3:
							global2.data[24] -= 3;
							break;
						case 4:
							global2.data[24] -= 2;
							break;
						case 7:
							global2.data[24] -= 2;
							break;
						case 9:
							global2.data[69] += 140;
							break;
						case 10:
						{
							global2.data[24] -= 2;
							GameState gameState = global2;
							gameState.influencePRC += 5;
							break;
						}
						case 12:
							global2.data[24] -= 2;
							break;
						case 13:
							global2.data[24] -= 2;
							break;
						case 14:
							global2.data[24] -= 2;
							break;
						case 23:
						{
							GameState gameState = global2;
							gameState.influencePRC += 5;
							break;
						}
						case 28:
							global2.data[24] -= 2;
							break;
						case 30:
						{
							GameState gameState = global2;
							gameState.influencePRC += 10;
							break;
						}
						case 31:
						{
							GameState gameState = global2;
							gameState.influencePRC += 5;
							break;
						}
						case 32:
						{
							GameState gameState = global2;
							gameState.influencePRC += 5;
							break;
						}
						case 33:
						{
							GameState gameState = global2;
							gameState.influencePRC += 10;
							break;
						}
						}
					}
					else if (global2.science_time[num76] < global2.science_need_time[num76] && global2.science[num76])
					{
						global2.science_time[num76] = global2.science_need_time[num76];
					}
				}
				if (!flag4)
				{
					alarmIcons[0].SetActive(value: true);
					global2.leader.is_sleshka = true;
				}
				else
				{
					alarmIcons[0].SetActive(value: false);
					global2.leader.is_sleshka = false;
				}
				if (global2.data[11] > 300 && !flag4)
				{
					global2.data[11] = 300;
				}
				if (global2.diff == 0)
				{
					global2.data[1] += 5;
					global2.data[3] += 5;
					global2.data[4] -= 5;
					global2.data[5] += 5;
					global2.data[8] += 50;
					global2.data[9] += 50;
					if (global2.data[26] > 200)
					{
						global2.data[26] -= 30;
					}
					else if (global2.data[26] > 100)
					{
						global2.data[26] -= 20;
					}
					else
					{
						global2.data[26] -= 10;
					}
				}
				else if (global2.diff == 1)
				{
					global2.data[1] += 3;
					global2.data[3] += 3;
					global2.data[4] -= 3;
					global2.data[5] += 3;
					global2.data[8] += 3;
					global2.data[9] += 3;
				}
				else if (global2.diff == 2)
				{
					if (global2.data[26] < 50)
					{
						global2.data[26] += 8;
					}
					else if (global2.data[26] < 100)
					{
						global2.data[26] += 5;
					}
				}
				else if (global2.diff == 3)
				{
					global2.data[1] -= 6;
					global2.data[3] -= 7;
					global2.data[4] += 7;
					global2.data[5] -= 7;
					global2.data[8] -= 7;
					global2.data[9] -= 7;
					if (global2.data[26] < 50)
					{
						global2.data[26] += 10;
					}
					else if (global2.data[26] < 100)
					{
						global2.data[26] += 6;
					}
					else
					{
						global2.data[26]++;
					}
				}
				else if (global2.diff == 4)
				{
					global2.data[1] -= global2.data[14] * 3;
					global2.data[3] -= global2.data[14] * 3;
					empire = global2.empires[0];
					empire.relations -= 5;
					empire = global2.empires[1];
					empire.relations -= 5;
					if (global2.data[38] == 100)
					{
						for (int num77 = 0; num77 < global2.politics.Length; num77++)
						{
							if (global2.politics[num77].traits[0] == 0)
							{
								Politic politic = global2.politics[num77];
								politic.power += 50;
							}
							else
							{
								Politic politic = global2.politics[num77];
								politic.loyality -= 10;
							}
						}
					}
				}
				if (global2.data[31] >= 700)
				{
					global2.data[31] -= array5[31] / 40;
				}
				if (global2.data[57] >= 700)
				{
					global2.data[57] -= array5[57] / 40;
				}
				for (int num78 = 0; num78 < global2.politics_dolshnost.Length; num78++)
				{
					if (global2.politics_dolshnost[num78] == 200)
					{
						global2.data[1] -= 5;
						global2.data[4] += 5;
						global2.data[8]--;
						global2.data[9] -= 5;
					}
				}
				DeathPolitics();
				PlotPolitics();
				PlotPlayer();
				if (global2.PlayerCountry == 1)
				{
					ModifiesInfuence.ModifiesChanges(ch_support, ch_lib);
				}
				else if (global2.PlayerCountry == 21)
				{
					FranceModifiesInfuence.ModifiesChanges(ch_support, ch_lib);
				}
				else
				{
					SovietModifiesInfuence.ModifiesChanges(ch_support, ch_lib);
				}
				if (global2.data[8] - ch_profit > 35)
				{
					if (global2.data[8] - ch_profit > 35)
					{
						global2.data[8] -= (global2.data[8] - ch_profit) / 4;
					}
					else if (global2.data[8] - ch_profit > 50)
					{
						global2.data[8] -= (global2.data[8] - ch_profit) / 3;
					}
					else if (global2.data[8] - ch_profit > 75)
					{
						global2.data[8] -= (global2.data[8] - ch_profit) / 2;
					}
					global2.data[8] -= global2.data[8] / 20;
				}
				if (global2.data[16] == 13)
				{
					global2.data[8] += Mathf.RoundToInt((float)(global2.data[34] - 9037) / 3000f + 1f);
				}
				else if (global2.data[16] == 14)
				{
					global2.data[8] += Mathf.RoundToInt((float)(global2.data[34] - 9037) / 2000f + 1f);
				}
				else if (global2.data[16] == 15)
				{
					global2.data[8] += Mathf.RoundToInt((float)(global2.data[34] - 9037) / 1000f + 1f);
				}
				for (int num79 = 0; num79 < global2.data_old.Length; num79++)
				{
					if (num79 != 34 && num79 != 160 && num79 != 161)
					{
						global2.data_old[num79] = global2.data[num79] - array5[num79];
					}
				}
				global2.data_old[28] = global2.empires[0].relations - array5[28];
				global2.data_old[29] = global2.empires[1].relations - array5[29];
				global2.data_old[7] = global2.influencePRC - array5[7];
				GameState gameState2 = global2;
				List<byte> politics_to_generate = new List<byte>();
				gameState2.BalancePolitic(politics_to_generate);
			}
			if (global2.PlayerCountry == 1)
			{
				EventsRequirements();
			}
			if (global2.iron_and_blood && global2.data[113] == 9 && global2.data[114] == 9 && global2.data[115] == 9 && global2.data[116] == 9)
			{
				achieves.GetComponent<achievements>().Set(28);
			}
			if (global2.leader.name_1 == 2 && global2.leader.name_2 == 2)
			{
				global2.checking[0] = true;
			}
			else if (global2.leader.name_1 == 13 && global2.leader.name_2 == 13)
			{
				global2.checking[1] = true;
			}
			else if (global2.leader.traits[0] == 1 && global2.leader.name_2 == 16)
			{
				global2.checking[2] = true;
			}
			else if (global2.leader.traits[0] == 3)
			{
				global2.checking[4] = true;
			}
			else if (global2.event_done[124])
			{
				global2.checking[3] = true;
			}
			if (global2.event_done[92] && global2.data[21] == 1981 && global2.data[19] == 1 && global2.data[20] == 1)
			{
				global2.event_done[92] = false;
			}
			if (global2.data[103] != 15 && global2.data[21] == 1981 && global2.data[19] == UnityEngine.Random.Range(1, 30) && global2.data[20] == 11)
			{
				global2.data[103] = 15;
				global2.allcountries[61].dev = 100;
				global2.allcountries[61].prcpower = 0;
				global2.allcountries[61].sovpower = 0;
				global2.allcountries[61].usapower = 0;
				global2.allcountries[61].stab = 1000;
				global2.allcountries[61].Gosstroy = 0;
				global2.allcountries[61].SubGosstroy = 7;
			}
			if (global2.completedDecisions[12])
			{
				if (global2.data[108] > 70)
				{
					global2.data[108] = 70;
				}
				else if (global2.data[108] < 40)
				{
					global2.data[108] = 40;
				}
			}
			AlarmIconChange();
			BoundsOfVariables();
			for (int num80 = 0; num80 < re_war.Length; num80++)
			{
				re_war[num80].Repaint();
			}
			map1.UpdateMap();
			if (global1.autosavej > 0)
			{
				if (global1.autosavej == 1 && global2.data[19] == 1)
				{
					AutoSaveMethod();
				}
				else if (global1.autosavej == 2 && global2.data[19] == 1 && global2.data[20] % 6 == 0)
				{
					AutoSaveMethod();
				}
			}
		}
		GetComponent<TextMesh>().text = global2.data[19] + "." + global2.data[20] + "." + global2.data[21];
	}

	private void DaysInSouthAmerica()
	{
		for (int i = 71; i < 84; i++)
		{
			global2.WhatToDevelop(i);
			global2.WantToLeave(i);
			if (global2.data[20] == 6 || global2.data[20] == 12)
			{
				global2.AmericanHelp(i);
			}
		}
	}

	private void EmpireModifiesChanges(Empire empires, int num)
	{
		int[] modifies = empires.modifies;
		for (int i = 0; i < modifies.Length; i++)
		{
			switch (modifies[i])
			{
			case 0:
				empires.relations += 5;
				if (num == 1)
				{
					if (global2.empires[0].relations > 900 && empires.relations > 500)
					{
						empires.relations -= 30;
					}
					else if (global2.empires[0].relations > 800 && empires.relations > 400)
					{
						empires.relations -= 20;
					}
					else if (global2.empires[0].relations >= 750 && empires.relations > 300)
					{
						empires.relations -= 10;
					}
				}
				else if (global2.empires[1].relations > 800 && empires.relations > 500)
				{
					empires.relations -= 30;
				}
				else if (global2.empires[1].relations >= 750 && empires.relations > 350)
				{
					empires.relations -= 20;
				}
				else if (global2.empires[1].relations >= 750)
				{
					empires.relations -= 10;
				}
				break;
			case 2:
				empires.money += 5;
				empires.power++;
				break;
			case 7:
				empires.money += 20;
				break;
			}
		}
	}

	private void BoundsOfVariables()
	{
		if (global2.data[12] > 1000 && !global2.modifies[1].active)
		{
			global2.data[12] = 1000;
		}
		else if (global2.data[12] > 500 && global2.modifies[1].active)
		{
			global2.data[12] = 500;
		}
		if (global2.data[13] > 1000)
		{
			global2.data[13] = 1000;
		}
		if (global2.data[68] > 1000)
		{
			global2.data[68] = 1000;
		}
		if (global2.data[3] > 1000)
		{
			global2.data[3] = 1000;
		}
		if (global2.data[4] > 1000)
		{
			global2.data[4] = 1000;
		}
		if (global2.data[1] > 1000)
		{
			global2.data[1] = 1000;
		}
		if (global2.empires[0].relations > 1000)
		{
			global2.empires[0].relations = 1000;
		}
		else if (global2.empires[0].relations < 0)
		{
			global2.empires[0].relations = 0;
		}
		if (global2.empires[1].relations > 1000)
		{
			global2.empires[1].relations = 1000;
		}
		else if (global2.empires[1].relations < 0)
		{
			global2.empires[1].relations = 0;
		}
		if (global2.data[4] < 0)
		{
			global2.data[4] = 0;
		}
		if (global2.data[26] < 0)
		{
			global2.data[26] = 0;
		}
		if (global2.data[5] < 0)
		{
			global2.data[5] = 0;
		}
		else if (global2.data[5] > 1000)
		{
			global2.data[5] = 1000;
		}
		if (global2.influencePRC < 0)
		{
			global2.influencePRC = 0;
		}
		else if (global2.influencePRC > 1000)
		{
			global2.influencePRC = 1000;
		}
		if (global2.empires[1].power < 0)
		{
			global2.empires[1].power = 0;
		}
		else if (global2.empires[1].power > 1000)
		{
			global2.empires[1].power = 1000;
		}
		if (global2.empires[0].power < 0)
		{
			global2.empires[0].power = 0;
		}
		else if (global2.empires[0].power > 1000)
		{
			global2.empires[0].power = 1000;
		}
		if (global2.data[108] < 0)
		{
			global2.data[108] = 0;
		}
		else if (global2.data[108] > 100)
		{
			global2.data[108] = 100;
		}
		if (global2.data[6] < -50)
		{
			global2.data[6] = -50;
		}
		else if (global2.data[6] > 1100)
		{
			global2.data[6] = 1100;
		}
	}

	private void AfricanBotSupport()
	{
		for (int i = 53; i < 109; i++)
		{
			if ((i >= 69 && i <= 105) || global2.allcountries[i].africaOff)
			{
				continue;
			}
			if (global2.allcountries[i].proprc)
			{
				if (global2.allcountries[i].stab < 1000)
				{
					global2.allcountries[i].stab += ((!global2.science[32]) ? (global2.data[81] / 3) : (global2.data[81] / 2));
				}
				if (global2.allcountries[i].usapower > 0)
				{
					global2.allcountries[i].usapower -= ((!global2.science[32]) ? (global2.data[81] / 3) : (global2.data[81] / 2));
				}
				if (global2.allcountries[i].sovpower > 0)
				{
					global2.allcountries[i].sovpower -= ((!global2.science[32]) ? (global2.data[81] / 3) : (global2.data[81] / 2));
				}
				if (global2.data[22] > global2.empires[1].money && global2.allcountries[i].stab < 1000)
				{
					global2.allcountries[i].stab += 25;
				}
				if (global2.data[22] > global2.empires[0].money && global2.allcountries[i].stab < 1000)
				{
					global2.allcountries[i].stab += 25;
				}
			}
			else if (global2.data[81] < 50 && global2.allcountries[i].prcpower >= 500 && !global2.science[32])
			{
				global2.allcountries[i].prcpower -= 60 - global2.data[81];
			}
		}
		int[] array = new int[5];
		int[] array2 = new int[5];
		array[0] = 0;
		array[1] = 0;
		array[2] = 0;
		array[3] = 0;
		array[4] = 0;
		array2[0] = 0;
		array2[1] = 0;
		array2[2] = 0;
		array2[3] = 0;
		array2[4] = 0;
		int num = UnityEngine.Random.Range(53, 69);
		if (num - 53 < global2.allcountries.Length - num)
		{
			for (int num2 = global2.allcountries.Length - 1; num2 >= num; num2--)
			{
				if (!global2.allcountries[num2].africaOff && (global2.data[103] != 15 || num2 != 61) && num2 != 69 && num2 != 70)
				{
					if (global2.allcountries[num2].prosov && array2[0] == 0 && global2.allcountries[num2].stab < 500)
					{
						array2[0] = num2;
					}
					else if (global2.allcountries[num2].prosov && array2[4] == 0 && global2.allcountries[num2].stab < 500)
					{
						array2[4] = num2;
					}
					else if (global2.allcountries[num2].Vyshi && array2[1] == 0 && global2.allcountries[num2].sovpower < 1000 - global2.empires[1].power / 2)
					{
						array2[1] = num2;
					}
					else if (global2.allcountries[num2].proprc && array2[2] == 0 && global2.allcountries[num2].sovpower < 1000 - global2.empires[1].power / 2)
					{
						array2[2] = num2;
					}
					else if (!global2.allcountries[num2].proprc && !global2.allcountries[num2].Vyshi && !global2.allcountries[num2].prosov && array2[3] == 0 && global2.allcountries[num2].sovpower < 1000 - global2.empires[1].power / 2)
					{
						array2[3] = num2;
					}
					else if (global2.allcountries[num2].Vyshi && array[0] == 0 && global2.allcountries[num2].stab < 500)
					{
						array[0] = num2;
					}
					else if (global2.allcountries[num2].Vyshi && array[4] == 0 && global2.allcountries[num2].stab < 500)
					{
						array[4] = num2;
					}
					else if (global2.allcountries[num2].prosov && array[1] == 0 && global2.allcountries[num2].usapower < 1000 - global2.empires[0].power / 2)
					{
						array[1] = num2;
					}
					else if (global2.allcountries[num2].proprc && array[2] == 0 && global2.allcountries[num2].usapower < 1000 - global2.empires[0].power / 2)
					{
						array[2] = num2;
					}
					else if (!global2.allcountries[num2].proprc && !global2.allcountries[num2].Vyshi && !global2.allcountries[num2].prosov && array[3] == 0 && global2.allcountries[num2].usapower < 1000 - global2.empires[0].power / 2)
					{
						array[3] = num2;
					}
				}
			}
		}
		else
		{
			for (int j = 53; j <= num; j++)
			{
				if ((global2.data[103] != 15 || j != 61) && j != 69 && j != 70 && !global2.allcountries[j].africaOff)
				{
					if (global2.allcountries[j].prosov && array2[0] == 0 && global2.allcountries[j].stab < 500)
					{
						array2[0] = j;
					}
					else if (global2.allcountries[j].prosov && array2[4] == 0 && global2.allcountries[j].stab < 500)
					{
						array2[4] = j;
					}
					else if (global2.allcountries[j].Vyshi && array2[1] == 0 && global2.allcountries[j].sovpower < 1000 - global2.empires[1].power / 2)
					{
						array2[1] = j;
					}
					else if (global2.allcountries[j].proprc && array2[2] == 0 && global2.allcountries[j].sovpower < 1000 - global2.empires[1].power / 2)
					{
						array2[2] = j;
					}
					else if (!global2.allcountries[j].proprc && !global2.allcountries[j].Vyshi && !global2.allcountries[j].prosov && array2[3] == 0 && global2.allcountries[j].sovpower < 1000 - global2.empires[1].power / 2)
					{
						array2[3] = j;
					}
					else if (global2.allcountries[j].Vyshi && array[0] == 0 && global2.allcountries[j].stab < 500)
					{
						array[0] = j;
					}
					else if (global2.allcountries[j].Vyshi && array[4] == 0 && global2.allcountries[j].stab < 500)
					{
						array[4] = j;
					}
					else if (global2.allcountries[j].prosov && array[1] == 0 && global2.allcountries[j].usapower < 1000 - global2.empires[0].power / 2)
					{
						array[1] = j;
					}
					else if (global2.allcountries[j].proprc && array[2] == 0 && global2.allcountries[j].usapower < 1000 - global2.empires[0].power / 2)
					{
						array[2] = j;
					}
					else if (!global2.allcountries[j].proprc && !global2.allcountries[j].Vyshi && !global2.allcountries[j].prosov && array[3] == 0 && global2.allcountries[j].usapower < 1000 - global2.empires[0].power / 2)
					{
						array[3] = j;
					}
				}
			}
		}
		if (array2[0] > 0 && global2.empires[1].money >= 200)
		{
			global2.allcountries[array2[0]].stab += 100;
			global2.allcountries[array2[0]].dev += 100;
			if (global2.allcountries[array2[0]].usapower >= 50)
			{
				global2.allcountries[array2[0]].usapower -= 50;
			}
			if (global2.allcountries[array2[0]].prcpower >= 50)
			{
				global2.allcountries[array2[0]].prcpower -= 50;
			}
			global2.empires[1].money -= 200;
		}
		if (array2[4] > 0 && global2.empires[1].money >= 200)
		{
			global2.allcountries[array2[4]].stab += 100;
			global2.allcountries[array2[4]].dev += 100;
			if (global2.allcountries[array2[4]].usapower >= 50)
			{
				global2.allcountries[array2[4]].usapower -= 50;
			}
			if (global2.allcountries[array2[4]].prcpower >= 50)
			{
				global2.allcountries[array2[4]].prcpower -= 50;
			}
			global2.empires[1].money -= 200;
		}
		if (array2[1] > 0 && global2.empires[1].money >= 100)
		{
			global2.allcountries[array2[1]].sovpower += 100;
			global2.empires[1].money -= 100;
		}
		if (array2[3] > 0 && global2.empires[1].money >= 50)
		{
			global2.allcountries[array2[3]].sovpower += 50;
			global2.empires[1].money -= 50;
		}
		if (array2[2] > 0 && global2.empires[1].money >= 100)
		{
			global2.allcountries[array2[2]].sovpower += 100;
			global2.empires[1].money -= 100;
		}
		if (array[0] > 0 && global2.empires[0].money >= 200)
		{
			global2.allcountries[array[0]].stab += 100;
			global2.allcountries[array[0]].dev += 100;
			if (global2.allcountries[array[0]].sovpower >= 50)
			{
				global2.allcountries[array[0]].sovpower -= 50;
			}
			if (global2.allcountries[array[0]].prcpower >= 50)
			{
				global2.allcountries[array[0]].prcpower -= 50;
			}
			global2.empires[0].money -= 200;
		}
		if (array[4] > 0 && global2.empires[0].money >= 200)
		{
			global2.allcountries[array[4]].stab += 100;
			global2.allcountries[array[4]].dev += 100;
			if (global2.allcountries[array[4]].sovpower >= 50)
			{
				global2.allcountries[array[4]].sovpower -= 50;
			}
			if (global2.allcountries[array[4]].prcpower >= 50)
			{
				global2.allcountries[array[4]].prcpower -= 50;
			}
			global2.empires[0].money -= 200;
		}
		if (array[1] > 0 && global2.empires[0].money >= 100)
		{
			global2.allcountries[array[1]].usapower += 100;
			global2.empires[0].money -= 100;
		}
		if (array[3] > 0 && global2.empires[0].money >= 100)
		{
			global2.allcountries[array[3]].usapower += 50;
			global2.empires[0].money -= 50;
		}
		if (array[2] > 0 && global2.empires[0].money >= 100)
		{
			global2.allcountries[array[2]].usapower += 100;
			global2.empires[0].money -= 100;
		}
	}

	private void AfricanCoups()
	{
		int num = 0;
		for (int i = 53; i < 109; i++)
		{
			num = 0;
			if ((i >= 69 && i <= 105) || global2.allcountries[i].africaOff || (global2.data[103] == 15 && i == 61) || i == 69 || i == 70)
			{
				continue;
			}
			if (!global2.allcountries[i].Vyshi && global2.allcountries[i].Gosstroy != 3 && !global2.allcountries[i].prosov && !global2.allcountries[i].proprc && global2.allcountries[i].sovpower > 300 && global2.allcountries[i].sovpower >= global2.allcountries[i].usapower)
			{
				num = UnityEngine.Random.Range(80, 100);
				if (num >= 50 && num <= global2.allcountries[i].sovpower / 10)
				{
					global2.allcountries[i].prosov = true;
					global2.allcountries[i].Torg = false;
					global2.empires[1].power++;
				}
			}
			else if (!global2.allcountries[i].Vyshi && global2.allcountries[i].Gosstroy != 1 && !global2.allcountries[i].prosov && !global2.allcountries[i].proprc && global2.allcountries[i].usapower > 300 && global2.allcountries[i].sovpower < global2.allcountries[i].usapower)
			{
				num = UnityEngine.Random.Range(80, 100);
				Debug.Log(num + " " + i + " " + global2.allcountries[i].usapower / 10);
				if (num >= 50 && num <= global2.allcountries[i].usapower / 10)
				{
					global2.allcountries[i].Vyshi = true;
					global2.allcountries[i].Torg = false;
					global2.empires[0].power++;
				}
			}
			else if (!global2.allcountries[i].prosov && global2.allcountries[i].sovpower > 300 && global2.allcountries[i].sovpower >= global2.allcountries[i].usapower)
			{
				global2.allcountries[i].stab -= global2.allcountries[i].sovpower;
				if ((global2.allcountries[i].stab < -200 && global2.allcountries[i].proprc) || global2.allcountries[i].stab < -300 || (global2.allcountries[i].stab < -200 && global2.allcountries[i].Vyshi && global2.empires[1].power > global2.empires[0].power))
				{
					if (global2.allcountries[i].Vyshi)
					{
						global2.empires[0].power -= 5;
						global2.allcountries[i].Vyshi = false;
					}
					if (global2.allcountries[i].proprc)
					{
						global2.influencePRC -= 5;
						global2.allcountries[i].proprc = false;
					}
					global2.allcountries[i].Gosstroy = UnityEngine.Random.Range(0, 3);
					global2.allcountries[i].SubGosstroy = global2.AfricanSubGosstroy(global2.allcountries[i].Gosstroy);
					global2.allcountries[i].prosov = true;
					global2.allcountries[i].Torg = false;
					global2.allcountries[i].stab = 100;
					global2.allcountries[i].dev -= 200;
					global2.allcountries[i].usapower -= global2.allcountries[i].usapower / 2;
					global2.allcountries[i].prcpower -= global2.allcountries[i].prcpower / 2;
					global2.empires[1].power += 5;
				}
			}
			else
			{
				if (global2.allcountries[i].Vyshi || global2.allcountries[i].usapower <= 300 || global2.allcountries[i].sovpower >= global2.allcountries[i].usapower)
				{
					continue;
				}
				global2.allcountries[i].stab -= global2.allcountries[i].usapower;
				if ((global2.allcountries[i].stab < -200 && global2.allcountries[i].proprc) || global2.allcountries[i].stab < -300 || (global2.allcountries[i].stab < -200 && global2.allcountries[i].prosov && global2.empires[0].power > global2.empires[1].power))
				{
					if (global2.allcountries[i].prosov)
					{
						global2.empires[1].power -= 5;
						global2.allcountries[i].prosov = false;
					}
					if (global2.allcountries[i].proprc)
					{
						global2.influencePRC -= 5;
						global2.allcountries[i].proprc = false;
					}
					global2.allcountries[i].Gosstroy = UnityEngine.Random.Range(0, 3);
					if (global2.allcountries[i].Gosstroy == 1)
					{
						global2.allcountries[i].Gosstroy = 3;
					}
					global2.allcountries[i].SubGosstroy = global2.AfricanSubGosstroy(global2.allcountries[i].Gosstroy);
					global2.allcountries[i].Vyshi = true;
					global2.allcountries[i].stab = 100;
					global2.allcountries[i].Torg = false;
					global2.allcountries[i].dev -= 200;
					global2.allcountries[i].sovpower -= global2.allcountries[i].sovpower / 2;
					global2.allcountries[i].prcpower -= global2.allcountries[i].prcpower / 2;
					global2.empires[0].power += 5;
				}
			}
		}
	}

	private void WorldWarsDone()
	{
		if ((global2.ingamewars[1].fortnight_go >= 72 || global2.ingamewars[1].infl1 >= 1000 || global2.ingamewars[1].infl2 >= 1000) && global2.ingamewars[1].is_going && global2.data[82] < 0)
		{
			Debug.Log("Свершилось1");
			global2.data[82] = 1;
			Reelect(18);
		}
		else if ((global2.ingamewars[2].fortnight_go >= 96 || global2.ingamewars[2].infl1 >= 1000 || global2.ingamewars[2].infl2 >= 1000) && global2.ingamewars[2].is_going && global2.data[82] < 0)
		{
			Debug.Log("Свершилось2");
			global2.data[82] = 2;
			Reelect(18);
		}
		else if ((global2.ingamewars[3].fortnight_go >= 192 || global2.ingamewars[3].infl1 >= 1000 || global2.ingamewars[3].infl2 >= 1000) && global2.ingamewars[3].is_going && global2.data[82] < 0)
		{
			Debug.Log("Свершилось3");
			global2.data[82] = 3;
			Reelect(18);
		}
		else if ((global2.ingamewars[5].infl1 >= 1000 || global2.ingamewars[5].infl2 >= 1000) && global2.ingamewars[5].is_going && global2.data[82] < 0)
		{
			Debug.Log("Свершилось5");
			global2.data[82] = 5;
			Reelect(18);
		}
		else if ((global2.ingamewars[4].fortnight_go >= 24 || global2.ingamewars[4].infl1 >= 1000 || global2.ingamewars[4].infl2 >= 1000) && global2.ingamewars[4].is_going && global2.data[82] < 0)
		{
			Debug.Log("Свершилось4");
			global2.data[82] = 4;
			Reelect(18);
		}
		else if ((global2.ingamewars[6].fortnight_go >= 24 || global2.ingamewars[6].infl1 >= 1000 || global2.ingamewars[6].infl2 >= 1000) && global2.ingamewars[6].is_going && global2.data[82] < 0)
		{
			Debug.Log("Свершилось6");
			global2.data[82] = 6;
			Reelect(18);
		}
		else if ((global2.ingamewars[0].fortnight_go >= 48 || global2.ingamewars[0].infl1 >= 1000 || global2.ingamewars[0].infl2 >= 1000) && global2.ingamewars[0].is_going && global2.data[82] < 0)
		{
			Debug.Log("Свершилось0");
			global2.data[82] = 0;
			Reelect(18);
		}
		else if (global2.WarCheck(7))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 7;
			Reelect(18);
		}
		else if (global2.WarCheck(8) && global2.data[82] < 0 && (global2.ingamewars[8].infl1 >= 1000 || global2.ingamewars[8].infl2 >= 1000 || global2.ingamewars[8].fortnight_go >= 20))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 8;
			Reelect(18);
		}
		else if (global2.WarCheck(9) && global2.data[82] < 0 && (global2.ingamewars[9].infl1 >= 1000 || global2.ingamewars[9].infl2 >= 1000 || global2.ingamewars[9].fortnight_go >= 12))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 9;
			Reelect(18);
		}
		else if (global2.WarCheck(10) && global2.data[82] < 0 && (global2.ingamewars[10].infl1 >= 1000 || global2.ingamewars[10].infl2 >= 1000 || global2.ingamewars[10].fortnight_go >= 12))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 10;
			Reelect(18);
		}
		else if (global2.WarCheck(11) && global2.data[82] < 0 && (global2.ingamewars[11].infl1 >= 1000 || global2.ingamewars[11].infl2 >= 1000 || global2.ingamewars[11].fortnight_go >= 10))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 11;
			Reelect(18);
		}
		else if (global2.WarCheck(12) && global2.data[82] < 0 && (global2.ingamewars[12].infl1 >= 1000 || global2.ingamewars[12].infl2 >= 1000 || global2.ingamewars[12].fortnight_go >= 12))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 12;
			Reelect(18);
		}
		else if (global2.WarCheck(13) && global2.data[82] < 0 && (global2.ingamewars[13].infl1 >= 1000 || global2.ingamewars[13].infl2 >= 1000 || global2.ingamewars[13].fortnight_go >= 12))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 13;
			Reelect(18);
		}
		else if (global2.WarCheck(14) && global2.data[82] < 0 && (global2.ingamewars[14].infl1 >= 1000 || global2.ingamewars[14].infl2 >= 1000 || global2.ingamewars[14].fortnight_go >= 10))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 14;
			Reelect(18);
		}
		else if (global2.WarCheck(15) && global2.data[82] < 0 && (global2.ingamewars[15].infl1 >= 1000 || global2.ingamewars[15].infl2 >= 1000 || global2.ingamewars[15].fortnight_go >= 16))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 15;
			Reelect(18);
		}
		else if (global2.WarCheck(16) && global2.data[82] < 0 && (global2.ingamewars[16].infl1 >= 1000 || global2.ingamewars[16].infl2 >= 1000))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 16;
			Reelect(18);
		}
		else if (global2.WarCheck(17) && global2.data[82] < 0 && (global2.ingamewars[17].infl1 >= 1000 || global2.ingamewars[17].infl2 >= 1000 || global2.ingamewars[17].fortnight_go >= 20 || (global2.data[20] == 1 && global2.data[21] == 1984)))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 17;
			Reelect(18);
		}
		else if (global2.WarCheck(18) && global2.data[82] < 0 && (global2.ingamewars[18].infl1 >= 1000 || global2.ingamewars[18].infl2 >= 1000 || (global2.ingamewars[18].fortnight_go >= 20 && global2.resultOfEvents[382] == 0) || (global2.resultOfEvents[382] == 1 && global2.ingamewars[18].fortnight_go >= 8)))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 18;
			Reelect(18);
		}
		else if (global2.WarCheck(19) && global2.data[82] < 0 && (global2.ingamewars[19].infl1 >= 1000 || global2.ingamewars[19].infl2 >= 1000 || global2.ingamewars[19].fortnight_go >= 11))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 19;
			Reelect(18);
		}
		else if (global2.WarCheck(20) && global2.data[82] < 0 && (global2.ingamewars[20].infl1 >= 1000 || global2.ingamewars[20].infl2 >= 1000))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 20;
			Reelect(18);
		}
		else if (global2.WarCheck(21) && global2.data[82] < 0 && (global2.ingamewars[21].infl1 >= 1000 || global2.ingamewars[21].infl2 >= 1000 || global2.ingamewars[21].fortnight_go >= 20))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 21;
			Reelect(18);
		}
		else if (global2.WarCheck(22) && global2.data[82] < 0 && (global2.ingamewars[22].infl1 >= 1000 || global2.ingamewars[22].infl2 >= 1000))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 22;
			Reelect(18);
		}
		else if (global2.WarCheck(23) && global2.data[82] < 0 && (global2.ingamewars[23].infl1 >= 1000 || global2.ingamewars[23].infl2 >= 1000 || global2.ingamewars[23].fortnight_go >= 30))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 23;
			Reelect(18);
		}
		else if (global2.WarCheck(24) && global2.data[82] < 0 && (global2.ingamewars[24].infl1 >= 1000 || global2.ingamewars[24].infl2 >= 1000))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 24;
			Reelect(18);
		}
		else if (global2.WarCheck(25) && global2.data[82] < 0 && (global2.ingamewars[25].infl1 >= 1000 || global2.ingamewars[25].infl2 >= 1000 || global2.ingamewars[25].fortnight_go >= 20))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 25;
			Reelect(18);
		}
		else if (global2.WarCheck(26) && global2.data[82] < 0 && (global2.ingamewars[26].infl1 >= 1000 || global2.ingamewars[26].infl2 >= 1000 || global2.ingamewars[26].fortnight_go >= 20))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 26;
			Reelect(18);
		}
		else if (global2.WarCheck(27) && global2.data[82] < 0 && (global2.ingamewars[27].infl1 >= 1000 || global2.ingamewars[27].infl2 >= 1000 || global2.ingamewars[27].fortnight_go >= 30))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 27;
			Reelect(18);
		}
		else if (global2.WarCheck(28) && global2.data[82] < 0 && (global2.ingamewars[28].infl1 >= 1000 || global2.ingamewars[28].infl2 >= 1000 || global2.ingamewars[28].fortnight_go >= 25))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 28;
			Reelect(18);
		}
		else if (global2.WarCheck(29) && global2.data[82] < 0 && (global2.ingamewars[29].infl1 >= 1000 || global2.ingamewars[29].infl2 >= 1000 || global2.ingamewars[29].fortnight_go >= 15))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 29;
			Reelect(18);
		}
		else if (global2.WarCheck(30) && global2.data[82] < 0 && (global2.ingamewars[30].infl1 >= 1000 || global2.ingamewars[30].infl2 >= 1000 || global2.data[21] == 1983))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 30;
			Reelect(18);
		}
		else if (global2.WarCheck(31) && global2.data[82] < 0 && (global2.ingamewars[31].infl1 >= 1000 || global2.ingamewars[31].infl2 >= 1000))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 31;
			Reelect(18);
		}
		else if (global2.WarCheck(32) && global2.data[82] < 0 && (global2.ingamewars[32].infl1 >= 1000 || global2.ingamewars[32].infl2 >= 1000))
		{
			Debug.Log("Свершилось7");
			global2.data[82] = 32;
			Reelect(18);
		}
		else
		{
			global2.data[82] = -10;
		}
	}

	private void WorldWarsInfluenceChanges()
	{
		if (global2.ingamewars[1].is_going)
		{
			global2.ingamewars[1].fortnight_go++;
			if (global2.ingamewars[1].infl1 >= 1000 || global2.ingamewars[1].infl2 <= 0)
			{
				global2.ingamewars[1].infl1 = 1000;
				global2.ingamewars[1].infl2 = 0;
			}
			else if (global2.ingamewars[1].infl2 >= 1000 || global2.ingamewars[1].infl1 <= 0)
			{
				global2.ingamewars[1].infl2 = 1000;
				global2.ingamewars[1].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[1].infl1 < 1000)
				{
					global2.ingamewars[1].infl1 -= 15;
				}
				if (global2.ingamewars[1].infl2 > 0)
				{
					global2.ingamewars[1].infl2 += 15;
				}
			}
		}
		if (global2.ingamewars[0].is_going)
		{
			global2.ingamewars[0].fortnight_go++;
			if (global2.ingamewars[0].infl1 >= 1000 || global2.ingamewars[0].infl2 <= 0)
			{
				global2.ingamewars[0].infl1 = 1000;
				global2.ingamewars[0].infl2 = 0;
			}
			else if (global2.ingamewars[0].infl2 >= 1000 || global2.ingamewars[0].infl1 <= 0)
			{
				global2.ingamewars[0].infl2 = 1000;
				global2.ingamewars[0].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[0].infl1 < 1000)
				{
					global2.ingamewars[0].infl1 -= 7;
				}
				if (global2.ingamewars[0].infl2 > 0)
				{
					global2.ingamewars[0].infl2 += 7;
				}
				if (!global2.allcountries[10].proprc)
				{
					global2.ingamewars[0].infl1 -= 2;
					global2.ingamewars[0].infl2 += 2;
				}
			}
		}
		if (global2.ingamewars[7].is_going)
		{
			global2.ingamewars[7].fortnight_go++;
			if (global2.ingamewars[7].infl1 >= 1000 || global2.ingamewars[7].infl2 <= 0)
			{
				global2.ingamewars[7].infl1 = 1000;
				global2.ingamewars[7].infl2 = 0;
			}
			else if (global2.ingamewars[7].infl2 >= 1000 || global2.ingamewars[7].infl1 <= 0)
			{
				global2.ingamewars[7].infl2 = 1000;
				global2.ingamewars[7].infl1 = 0;
			}
			else if (global2.allcountries[19].numberOfSpecialEnding == 0)
			{
				if (global2.ingamewars[7].infl1 < 1000)
				{
					global2.ingamewars[7].infl1 -= 3;
				}
				if (global2.ingamewars[7].infl2 > 0)
				{
					global2.ingamewars[7].infl2 += 3;
				}
			}
			else if (global2.allcountries[19].numberOfSpecialEnding == 1)
			{
				if (global2.ingamewars[7].infl2 < 1000)
				{
					global2.ingamewars[7].infl2 -= 3;
				}
				if (global2.ingamewars[7].infl1 > 0)
				{
					global2.ingamewars[7].infl1 += 3;
				}
			}
		}
		if (global2.ingamewars[8].is_going)
		{
			global2.ingamewars[8].fortnight_go++;
			if (global2.ingamewars[8].infl1 >= 1000 || global2.ingamewars[8].infl2 <= 0)
			{
				global2.ingamewars[8].infl1 = 1000;
				global2.ingamewars[8].infl2 = 0;
			}
			else if (global2.ingamewars[8].infl2 >= 1000 || global2.ingamewars[8].infl1 <= 0)
			{
				global2.ingamewars[8].infl2 = 1000;
				global2.ingamewars[8].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[8].infl1 > 0)
				{
					global2.ingamewars[8].infl1 += 8;
				}
				if (global2.ingamewars[8].infl2 < 1000)
				{
					global2.ingamewars[8].infl2 -= 8;
				}
			}
		}
		if (global2.ingamewars[9].is_going)
		{
			global2.ingamewars[9].fortnight_go++;
			if (global2.ingamewars[9].infl1 >= 1000 || global2.ingamewars[9].infl2 <= 0)
			{
				global2.ingamewars[9].infl1 = 1000;
				global2.ingamewars[9].infl2 = 0;
			}
			else if (global2.ingamewars[9].infl2 >= 1000 || global2.ingamewars[9].infl1 <= 0)
			{
				global2.ingamewars[9].infl2 = 1000;
				global2.ingamewars[9].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[9].infl1 > 0)
				{
					global2.ingamewars[9].infl1 += 5;
				}
				if (global2.ingamewars[9].infl2 < 1000)
				{
					global2.ingamewars[9].infl2 -= 5;
				}
			}
		}
		if (global2.ingamewars[10].is_going)
		{
			global2.ingamewars[10].fortnight_go++;
			if (global2.ingamewars[10].infl1 >= 1000 || global2.ingamewars[10].infl2 <= 0)
			{
				global2.ingamewars[10].infl1 = 1000;
				global2.ingamewars[10].infl2 = 0;
			}
			else if (global2.ingamewars[10].infl2 >= 1000 || global2.ingamewars[10].infl1 <= 0)
			{
				global2.ingamewars[10].infl2 = 1000;
				global2.ingamewars[10].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[10].infl1 > 0)
				{
					if (global2.ingamewars[10].usa_place == 0 || global2.allcountries[84].isNATO)
					{
						global2.ingamewars[10].infl1 += 20;
					}
					else
					{
						global2.ingamewars[10].infl1 += 5;
					}
				}
				if (global2.ingamewars[10].infl2 < 1000)
				{
					if (global2.ingamewars[10].usa_place == 0 || global2.allcountries[84].isNATO)
					{
						global2.ingamewars[10].infl2 -= 20;
					}
					else
					{
						global2.ingamewars[10].infl2 -= 5;
					}
				}
			}
		}
		if (global2.ingamewars[11].is_going)
		{
			global2.ingamewars[11].fortnight_go++;
			if (global2.ingamewars[11].infl1 >= 1000 || global2.ingamewars[11].infl2 <= 0)
			{
				global2.ingamewars[11].infl1 = 1000;
				global2.ingamewars[11].infl2 = 0;
			}
			else if (global2.ingamewars[11].infl2 >= 1000 || global2.ingamewars[11].infl1 <= 0)
			{
				global2.ingamewars[11].infl2 = 1000;
				global2.ingamewars[11].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[11].infl1 > 0)
				{
					if (global2.ingamewars[11].usa_place == 0 || global2.allcountries[84].isNATO)
					{
						global2.ingamewars[11].infl1 += 20;
					}
					else
					{
						global2.ingamewars[11].infl1 += 5;
					}
				}
				if (global2.ingamewars[11].infl2 < 1000)
				{
					if (global2.ingamewars[11].usa_place == 0 || global2.allcountries[84].isNATO)
					{
						global2.ingamewars[11].infl2 -= 20;
					}
					else
					{
						global2.ingamewars[11].infl2 -= 5;
					}
				}
			}
		}
		if (global2.ingamewars[12].is_going)
		{
			global2.ingamewars[12].fortnight_go++;
			if (global2.ingamewars[12].infl1 >= 1000 || global2.ingamewars[12].infl2 <= 0)
			{
				global2.ingamewars[12].infl1 = 1000;
				global2.ingamewars[12].infl2 = 0;
			}
			else if (global2.ingamewars[12].infl2 >= 1000 || global2.ingamewars[12].infl1 <= 0)
			{
				global2.ingamewars[12].infl2 = 1000;
				global2.ingamewars[12].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[12].infl1 > 0)
				{
					if (global2.ingamewars[12].usa_place == 0 || global2.allcountries[84].isNATO)
					{
						global2.ingamewars[12].infl1 += 20;
					}
					else
					{
						global2.ingamewars[12].infl1 += 5;
					}
				}
				if (global2.ingamewars[12].infl2 < 1000)
				{
					if (global2.ingamewars[12].usa_place == 0 || global2.allcountries[84].isNATO)
					{
						global2.ingamewars[12].infl2 -= 20;
					}
					else
					{
						global2.ingamewars[12].infl2 -= 5;
					}
				}
			}
		}
		if (global2.ingamewars[13].is_going)
		{
			global2.ingamewars[13].fortnight_go++;
			if (global2.ingamewars[13].infl1 >= 1000 || global2.ingamewars[13].infl2 <= 0)
			{
				global2.ingamewars[13].infl1 = 1000;
				global2.ingamewars[13].infl2 = 0;
			}
			else if (global2.ingamewars[13].infl2 >= 1000 || global2.ingamewars[13].infl1 <= 0)
			{
				global2.ingamewars[13].infl2 = 1000;
				global2.ingamewars[13].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[13].infl1 > 0)
				{
					global2.ingamewars[13].infl1 += 20;
				}
				if (global2.ingamewars[13].infl2 < 1000)
				{
					global2.ingamewars[13].infl2 -= 20;
				}
			}
		}
		if (global2.ingamewars[14].is_going)
		{
			global2.ingamewars[14].fortnight_go++;
			if (global2.ingamewars[14].infl1 >= 1000 || global2.ingamewars[14].infl2 <= 0)
			{
				global2.ingamewars[14].infl1 = 1000;
				global2.ingamewars[14].infl2 = 0;
			}
			else if (global2.ingamewars[14].infl2 >= 1000 || global2.ingamewars[14].infl1 <= 0)
			{
				global2.ingamewars[14].infl2 = 1000;
				global2.ingamewars[14].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[14].ussr_place != 1)
				{
					if (global2.ingamewars[14].infl1 > 0)
					{
						global2.ingamewars[14].infl1 += 5;
					}
					if (global2.ingamewars[14].infl2 < 1000)
					{
						global2.ingamewars[14].infl2 -= 5;
					}
				}
				else
				{
					if (global2.ingamewars[14].infl1 > 0)
					{
						global2.ingamewars[14].infl1 -= 5;
					}
					if (global2.ingamewars[14].infl2 < 1000)
					{
						global2.ingamewars[14].infl2 += 5;
					}
				}
				if (global2.allcountries[94].isNATO)
				{
					if (global2.ingamewars[14].infl1 > 0)
					{
						global2.ingamewars[14].infl1 -= 5;
					}
					if (global2.ingamewars[14].infl2 < 1000)
					{
						global2.ingamewars[14].infl2 += 7;
					}
				}
				else
				{
					if (global2.ingamewars[14].infl1 > 0)
					{
						global2.ingamewars[14].infl1 += 4;
					}
					if (global2.ingamewars[14].infl2 < 1000)
					{
						global2.ingamewars[14].infl2 -= 4;
					}
				}
				if (global2.ingamewars[14].infl1 > 0)
				{
					global2.ingamewars[14].infl1 += 7;
				}
				if (global2.ingamewars[14].infl2 < 1000)
				{
					global2.ingamewars[14].infl2 -= 7;
				}
			}
		}
		if (global2.ingamewars[15].is_going)
		{
			global2.ingamewars[15].fortnight_go++;
			if (global2.ingamewars[15].infl1 >= 1000 || global2.ingamewars[15].infl2 <= 0)
			{
				global2.ingamewars[15].infl1 = 1000;
				global2.ingamewars[15].infl2 = 0;
			}
			else if (global2.ingamewars[15].infl2 >= 1000 || global2.ingamewars[15].infl1 <= 0)
			{
				global2.ingamewars[15].infl2 = 1000;
				global2.ingamewars[15].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[15].infl1 > 0)
				{
					global2.ingamewars[15].infl1 -= 3;
				}
				if (global2.ingamewars[15].infl2 < 1000)
				{
					global2.ingamewars[15].infl2 += 3;
				}
			}
		}
		if (global2.ingamewars[16].is_going)
		{
			global2.ingamewars[16].fortnight_go++;
			if (global2.ingamewars[16].infl1 >= 1000 || global2.ingamewars[16].infl2 <= 0)
			{
				global2.ingamewars[16].infl1 = 1000;
				global2.ingamewars[16].infl2 = 0;
			}
			else if (global2.ingamewars[16].infl2 >= 1000 || global2.ingamewars[16].infl1 <= 0)
			{
				global2.ingamewars[16].infl2 = 1000;
				global2.ingamewars[16].infl1 = 0;
			}
			else
			{
				int num = 0;
				if (global2.guns)
				{
					num = 3;
				}
				if (global2.ingamewars[16].infl2 < 1000)
				{
					global2.ingamewars[16].infl2 += 7;
					global2.ingamewars[16].infl2 += num;
					global2.ingamewars[16].infl1 -= 7;
					global2.ingamewars[16].infl1 -= num;
				}
			}
		}
		if (global2.ingamewars[17].is_going)
		{
			global2.ingamewars[17].fortnight_go++;
			if (global2.ingamewars[17].infl1 >= 1000 || global2.ingamewars[17].infl2 <= 0)
			{
				global2.ingamewars[17].infl1 = 1000;
				global2.ingamewars[17].infl2 = 0;
			}
			else if (global2.ingamewars[17].infl2 >= 1000 || global2.ingamewars[17].infl1 <= 0)
			{
				global2.ingamewars[17].infl2 = 1000;
				global2.ingamewars[17].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[15].infl1 > 0)
				{
					global2.ingamewars[15].infl1 -= 8;
				}
				if (global2.ingamewars[15].infl2 < 1000)
				{
					global2.ingamewars[15].infl2 += 8;
				}
			}
		}
		if (global2.ingamewars[18].is_going)
		{
			global2.ingamewars[18].fortnight_go++;
			if (global2.ingamewars[18].infl1 >= 1000 || global2.ingamewars[18].infl2 <= 0)
			{
				global2.ingamewars[18].infl1 = 1000;
				global2.ingamewars[18].infl2 = 0;
			}
			else if (global2.ingamewars[18].infl2 >= 1000 || global2.ingamewars[18].infl1 <= 0)
			{
				global2.ingamewars[18].infl2 = 1000;
				global2.ingamewars[18].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[18].infl1 > 0 && global2.resultOfEvents[382] == 0)
				{
					global2.ingamewars[18].infl1 -= 15;
				}
				else
				{
					global2.ingamewars[18].infl1 -= 25;
				}
				if (global2.ingamewars[18].infl2 < 1000 && global2.resultOfEvents[382] == 1)
				{
					global2.ingamewars[18].infl2 += 15;
				}
				else
				{
					global2.ingamewars[18].infl2 += 25;
				}
			}
		}
		if (global2.ingamewars[19].is_going)
		{
			global2.ingamewars[19].fortnight_go++;
			if (global2.ingamewars[19].infl1 >= 1000 || global2.ingamewars[19].infl2 <= 0)
			{
				global2.ingamewars[19].infl1 = 1000;
				global2.ingamewars[19].infl2 = 0;
			}
			else if (global2.ingamewars[19].infl2 >= 1000 || global2.ingamewars[19].infl1 <= 0)
			{
				global2.ingamewars[19].infl2 = 1000;
				global2.ingamewars[19].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[19].infl1 > 0 && global2.ingamewars[19].usa_place == 1 && global2.ingamewars[19].ussr_place == 1)
				{
					global2.ingamewars[19].infl1 -= 25;
				}
				else
				{
					global2.ingamewars[19].infl1 -= 2;
				}
				if (global2.ingamewars[19].infl2 < 1000 && global2.ingamewars[19].usa_place == 1 && global2.ingamewars[19].ussr_place == 1)
				{
					global2.ingamewars[19].infl2 += 25;
				}
				else
				{
					global2.ingamewars[19].infl2 += 2;
				}
			}
		}
		if (global2.ingamewars[20].is_going)
		{
			global2.ingamewars[20].fortnight_go++;
			if (global2.ingamewars[20].infl1 >= 1000 || global2.ingamewars[20].infl2 <= 0)
			{
				global2.ingamewars[20].infl1 = 1000;
				global2.ingamewars[20].infl2 = 0;
			}
			else if (global2.ingamewars[20].infl2 >= 1000 || global2.ingamewars[20].infl1 <= 0)
			{
				global2.ingamewars[20].infl2 = 1000;
				global2.ingamewars[20].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[20].infl1 > 0)
				{
					global2.ingamewars[20].infl1++;
				}
				if (global2.ingamewars[20].infl2 < 1000)
				{
					global2.ingamewars[20].infl2--;
				}
			}
		}
		if (global2.ingamewars[21].is_going)
		{
			global2.ingamewars[21].fortnight_go++;
			if (global2.ingamewars[21].infl1 >= 1000 || global2.ingamewars[21].infl2 <= 0)
			{
				global2.ingamewars[21].infl1 = 1000;
				global2.ingamewars[21].infl2 = 0;
			}
			else if (global2.ingamewars[21].infl2 >= 1000 || global2.ingamewars[21].infl1 <= 0)
			{
				global2.ingamewars[21].infl2 = 1000;
				global2.ingamewars[21].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[21].infl1 > 0)
				{
					global2.ingamewars[21].infl1 -= 5;
				}
				if (global2.ingamewars[21].infl2 < 1000)
				{
					global2.ingamewars[21].infl2 += 5;
				}
			}
		}
		if (global2.ingamewars[22].is_going)
		{
			global2.ingamewars[22].fortnight_go++;
			if (global2.ingamewars[22].infl1 >= 1000 || global2.ingamewars[22].infl2 <= 0)
			{
				global2.ingamewars[22].infl1 = 1000;
				global2.ingamewars[22].infl2 = 0;
			}
			else if (global2.ingamewars[22].infl2 >= 1000 || global2.ingamewars[22].infl1 <= 0)
			{
				global2.ingamewars[22].infl2 = 1000;
				global2.ingamewars[22].infl1 = 0;
			}
			else if (global2.ingamewars[22].infl2 < 1000)
			{
				if (global2.ingamewars[22].usa_place == 0)
				{
					global2.ingamewars[22].infl2 += 15;
					global2.ingamewars[22].infl1 -= 15;
				}
				else
				{
					global2.ingamewars[22].infl2 += 25;
					global2.ingamewars[22].infl1 -= 25;
				}
			}
		}
		if (global2.ingamewars[23].is_going)
		{
			global2.ingamewars[23].fortnight_go++;
			if (global2.ingamewars[23].infl1 >= 1000 || global2.ingamewars[23].infl2 <= 0)
			{
				global2.ingamewars[23].infl1 = 1000;
				global2.ingamewars[23].infl2 = 0;
			}
			else if (global2.ingamewars[23].infl2 >= 1000 || global2.ingamewars[23].infl1 <= 0)
			{
				global2.ingamewars[23].infl2 = 1000;
				global2.ingamewars[23].infl1 = 0;
			}
			else if (global2.ingamewars[23].infl2 < 1000)
			{
				if (global2.ingamewars[23].ussr_place == 1)
				{
					global2.ingamewars[23].infl2 += 20;
					global2.ingamewars[23].infl1 -= 20;
				}
				else
				{
					global2.ingamewars[23].infl2 += 15;
					global2.ingamewars[23].infl1 -= 15;
				}
			}
		}
		if (global2.ingamewars[24].is_going)
		{
			global2.ingamewars[24].fortnight_go++;
			if (global2.ingamewars[24].infl1 >= 1000 || global2.ingamewars[24].infl2 <= 0)
			{
				global2.ingamewars[24].infl1 = 1000;
				global2.ingamewars[24].infl2 = 0;
			}
			else if (global2.ingamewars[24].infl2 >= 1000 || global2.ingamewars[24].infl1 <= 0)
			{
				global2.ingamewars[24].infl2 = 1000;
				global2.ingamewars[24].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[24].infl1 > 0)
				{
					global2.ingamewars[24].infl1 += 5;
				}
				if (global2.ingamewars[24].infl2 < 1000)
				{
					global2.ingamewars[24].infl2 -= 5;
				}
			}
		}
		if (global2.ingamewars[25].is_going)
		{
			global2.ingamewars[25].fortnight_go++;
			if (global2.ingamewars[25].infl1 >= 1000 || global2.ingamewars[25].infl2 <= 0)
			{
				global2.ingamewars[25].infl1 = 1000;
				global2.ingamewars[25].infl2 = 0;
			}
			else if (global2.ingamewars[25].infl2 >= 1000 || global2.ingamewars[25].infl1 <= 0)
			{
				global2.ingamewars[25].infl2 = 1000;
				global2.ingamewars[25].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[25].infl1 > 0)
				{
					global2.ingamewars[25].infl1 += 5;
				}
				if (global2.ingamewars[25].infl2 < 1000)
				{
					global2.ingamewars[25].infl2 -= 5;
				}
			}
		}
		if (global2.ingamewars[26].is_going)
		{
			global2.ingamewars[26].fortnight_go++;
			if (global2.ingamewars[26].infl1 >= 1000 || global2.ingamewars[26].infl2 <= 0)
			{
				global2.ingamewars[26].infl1 = 1000;
				global2.ingamewars[26].infl2 = 0;
			}
			else if (global2.ingamewars[26].infl2 >= 1000 || global2.ingamewars[26].infl1 <= 0)
			{
				global2.ingamewars[26].infl2 = 1000;
				global2.ingamewars[26].infl1 = 0;
			}
			else if (global2.event_done[434])
			{
				if (global2.ingamewars[26].infl1 > 2)
				{
					global2.ingamewars[26].infl1 += 2;
				}
				if (global2.ingamewars[26].infl2 < 999)
				{
					global2.ingamewars[26].infl2 -= 2;
				}
			}
			else
			{
				if (global2.ingamewars[26].infl1 > 5)
				{
					global2.ingamewars[26].infl1 += 5;
				}
				if (global2.ingamewars[26].infl2 < 996)
				{
					global2.ingamewars[26].infl2 -= 5;
				}
			}
		}
		if (global2.ingamewars[27].is_going)
		{
			global2.ingamewars[27].fortnight_go++;
			if (global2.ingamewars[27].infl1 >= 1000 || global2.ingamewars[27].infl2 <= 0)
			{
				global2.ingamewars[27].infl1 = 1000;
				global2.ingamewars[27].infl2 = 0;
			}
			else if (global2.ingamewars[27].infl2 >= 1000 || global2.ingamewars[27].infl1 <= 0)
			{
				global2.ingamewars[27].infl2 = 1000;
				global2.ingamewars[27].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[27].infl1 > 0)
				{
					global2.ingamewars[27].infl1 += 5;
				}
				if (global2.ingamewars[27].infl2 < 1000)
				{
					global2.ingamewars[27].infl2 -= 5;
				}
			}
		}
		if (global2.ingamewars[28].is_going)
		{
			global2.ingamewars[28].fortnight_go++;
			if (global2.ingamewars[28].infl1 >= 1000 || global2.ingamewars[28].infl2 <= 0)
			{
				global2.ingamewars[28].infl1 = 1000;
				global2.ingamewars[28].infl2 = 0;
			}
			else if (global2.ingamewars[28].infl2 >= 1000 || global2.ingamewars[28].infl1 <= 0)
			{
				global2.ingamewars[28].infl2 = 1000;
				global2.ingamewars[28].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[28].infl1 > 0)
				{
					global2.ingamewars[28].infl1 -= 5;
				}
				if (global2.ingamewars[28].infl2 < 1000)
				{
					global2.ingamewars[28].infl2 += 5;
				}
			}
		}
		if (global2.ingamewars[29].is_going)
		{
			global2.ingamewars[29].fortnight_go++;
			if (global2.ingamewars[29].infl1 >= 1000 || global2.ingamewars[29].infl2 <= 0)
			{
				global2.ingamewars[29].infl1 = 1000;
				global2.ingamewars[29].infl2 = 0;
			}
			else if (global2.ingamewars[29].infl2 >= 1000 || global2.ingamewars[29].infl1 <= 0)
			{
				global2.ingamewars[29].infl2 = 1000;
				global2.ingamewars[29].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[29].infl1 > 0)
				{
					global2.ingamewars[29].infl1 -= 10;
				}
				if (global2.ingamewars[29].infl2 < 1000)
				{
					global2.ingamewars[29].infl2 += 10;
				}
				if (global2.ingamewars[29].ussr_place == 1 && global2.ingamewars[29].usa_place == 1)
				{
					if (global2.ingamewars[29].infl1 > 0)
					{
						global2.ingamewars[29].infl1 -= 20;
					}
					if (global2.ingamewars[29].infl2 < 1000)
					{
						global2.ingamewars[29].infl2 += 20;
					}
				}
			}
		}
		if (global2.ingamewars[30].is_going)
		{
			global2.ingamewars[30].fortnight_go++;
			if (global2.ingamewars[30].infl1 >= 1000 || global2.ingamewars[30].infl2 <= 0)
			{
				global2.ingamewars[30].infl1 = 1000;
				global2.ingamewars[30].infl2 = 0;
			}
			else if (global2.ingamewars[30].infl2 >= 1000 || global2.ingamewars[30].infl1 <= 0)
			{
				global2.ingamewars[30].infl2 = 1000;
				global2.ingamewars[30].infl1 = 0;
			}
			else if (global2.ingamewars[30].infl1 > 900)
			{
				global2.ingamewars[30].infl1 -= 50;
				global2.ingamewars[30].infl2 += 50;
			}
			else if (global2.ingamewars[30].infl1 > 800)
			{
				global2.ingamewars[30].infl1 -= 30;
				global2.ingamewars[30].infl2 += 30;
			}
			else if (global2.ingamewars[30].infl1 > 700)
			{
				global2.ingamewars[30].infl1 -= 20;
				global2.ingamewars[30].infl2 += 20;
			}
			else if (global2.ingamewars[30].infl1 > 600)
			{
				global2.ingamewars[30].infl1 -= 10;
				global2.ingamewars[30].infl2 += 10;
			}
			else if (global2.ingamewars[30].infl2 > 900)
			{
				global2.ingamewars[30].infl2 -= 50;
				global2.ingamewars[30].infl1 += 50;
			}
			else if (global2.ingamewars[30].infl2 > 800)
			{
				global2.ingamewars[30].infl2 -= 30;
				global2.ingamewars[30].infl1 += 30;
			}
			else if (global2.ingamewars[30].infl2 > 700)
			{
				global2.ingamewars[30].infl2 -= 20;
				global2.ingamewars[30].infl1 += 20;
			}
			else if (global2.ingamewars[30].infl2 > 600)
			{
				global2.ingamewars[30].infl2 -= 10;
				global2.ingamewars[30].infl1 += 10;
			}
			else
			{
				if (global2.ingamewars[30].infl1 < 1000)
				{
					global2.ingamewars[30].infl1 -= 5;
				}
				if (global2.ingamewars[30].infl2 < 1000)
				{
					global2.ingamewars[30].infl2 += 5;
				}
			}
		}
		if (global2.ingamewars[31].is_going)
		{
			global2.ingamewars[31].fortnight_go++;
			if (global2.ingamewars[31].infl1 >= 1000 || global2.ingamewars[31].infl2 <= 0)
			{
				global2.ingamewars[31].infl1 = 1000;
				global2.ingamewars[31].infl2 = 0;
			}
			else if (global2.ingamewars[31].infl2 >= 1000 || global2.ingamewars[31].infl1 <= 0)
			{
				global2.ingamewars[31].infl2 = 1000;
				global2.ingamewars[31].infl1 = 0;
			}
			else if (global2.ingamewars[30].is_going)
			{
				if (global2.ingamewars[31].infl1 > 0)
				{
					global2.ingamewars[31].infl1 -= 5;
				}
				if (global2.ingamewars[31].infl2 < 1000)
				{
					global2.ingamewars[31].infl2 += 5;
				}
			}
			else
			{
				if (global2.ingamewars[31].infl1 > 0)
				{
					global2.ingamewars[31].infl1 -= 15;
				}
				if (global2.ingamewars[31].infl2 < 1000)
				{
					global2.ingamewars[31].infl2 += 15;
				}
			}
		}
		if (global2.ingamewars[32].is_going)
		{
			global2.ingamewars[32].fortnight_go++;
			if (global2.ingamewars[32].infl1 >= 1000 || global2.ingamewars[32].infl2 <= 0)
			{
				global2.ingamewars[32].infl1 = 1000;
				global2.ingamewars[32].infl2 = 0;
			}
			else if (global2.ingamewars[32].infl2 >= 1000 || global2.ingamewars[32].infl1 <= 0)
			{
				global2.ingamewars[32].infl2 = 1000;
				global2.ingamewars[32].infl1 = 0;
			}
			else if (global2.ingamewars[30].is_going)
			{
				if (global2.ingamewars[32].infl1 > 0)
				{
					global2.ingamewars[32].infl1 -= 5;
				}
				if (global2.ingamewars[32].infl2 < 1000)
				{
					global2.ingamewars[32].infl2 += 5;
				}
			}
			else
			{
				if (global2.ingamewars[32].infl1 > 0)
				{
					global2.ingamewars[32].infl1 -= 15;
				}
				if (global2.ingamewars[32].infl2 < 1000)
				{
					global2.ingamewars[32].infl2 += 15;
				}
			}
		}
		if (global2.allcountries[7].isNATO)
		{
			for (int i = 0; i < global2.ingamewars.Length; i++)
			{
				if (global2.ingamewars[i].is_going && global2.ingamewars[i].infl1 <= 1000 && global2.ingamewars[i].infl2 <= 1000 && i != 5)
				{
					if (global2.ingamewars[i].usa_place == 1 && global2.ingamewars[i].ussr_place == 1)
					{
						global2.ingamewars[i].infl2 += 25;
						global2.ingamewars[i].infl1 -= 25;
					}
					else if (global2.ingamewars[i].usa_place == 0 && global2.ingamewars[i].ussr_place == 0)
					{
						global2.ingamewars[i].infl2 -= 25;
						global2.ingamewars[i].infl1 += 25;
					}
				}
			}
		}
		if (global2.ingamewars[4].is_going)
		{
			global2.ingamewars[4].fortnight_go++;
			if (global2.ingamewars[4].infl1 >= 1000 || global2.ingamewars[4].infl2 <= 0)
			{
				global2.ingamewars[4].infl1 = 1000;
				global2.ingamewars[4].infl2 = 0;
			}
			else if (global2.ingamewars[4].infl2 >= 1000 || global2.ingamewars[4].infl1 <= 0)
			{
				global2.ingamewars[4].infl2 = 1000;
				global2.ingamewars[4].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[4].infl1 > 0)
				{
					global2.ingamewars[4].infl1 += 5;
				}
				if (global2.ingamewars[4].infl2 < 1000)
				{
					global2.ingamewars[4].infl2 -= 5;
				}
			}
		}
		if (global2.ingamewars[6].is_going)
		{
			global2.ingamewars[6].fortnight_go++;
			if (global2.ingamewars[6].infl1 >= 1000 || global2.ingamewars[6].infl2 <= 0)
			{
				global2.ingamewars[6].infl1 = 1000;
				global2.ingamewars[6].infl2 = 0;
			}
			else if (global2.ingamewars[6].infl2 >= 1000 || global2.ingamewars[6].infl1 <= 0)
			{
				global2.ingamewars[6].infl2 = 1000;
				global2.ingamewars[6].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[6].infl1 < 1000)
				{
					global2.ingamewars[6].infl1 -= 10;
				}
				if (global2.ingamewars[6].infl2 > 0)
				{
					global2.ingamewars[6].infl2 += 10;
				}
			}
		}
		if (global2.ingamewars[2].is_going)
		{
			global2.ingamewars[2].fortnight_go++;
			if (global2.ingamewars[2].infl1 >= 1000 || global2.ingamewars[2].infl2 <= 0)
			{
				global2.ingamewars[2].infl1 = 1000;
				global2.ingamewars[2].infl2 = 0;
			}
			else if (global2.ingamewars[2].infl2 >= 1000 || global2.ingamewars[2].infl1 <= 0)
			{
				global2.ingamewars[2].infl2 = 1000;
				global2.ingamewars[2].infl1 = 0;
			}
			else
			{
				if (global2.ingamewars[2].infl1 < 1000)
				{
					global2.ingamewars[2].infl1 -= 5;
				}
				if (global2.ingamewars[2].infl1 > 0)
				{
					global2.ingamewars[2].infl2 += 5;
				}
			}
		}
		if (global2.ingamewars[3].is_going)
		{
			global2.ingamewars[3].fortnight_go++;
			if (global2.ingamewars[3].infl1 >= 1000 || global2.ingamewars[3].infl2 <= 0)
			{
				global2.ingamewars[3].infl1 = 1000;
				global2.ingamewars[3].infl2 = 0;
			}
			else if (global2.ingamewars[3].infl2 >= 1000 || global2.ingamewars[3].infl1 <= 0)
			{
				global2.ingamewars[3].infl2 = 1000;
				global2.ingamewars[3].infl1 = 0;
			}
			else if (global2.data[21] < 1982)
			{
				if (global2.ingamewars[3].infl1 < 1000)
				{
					global2.ingamewars[3].infl1--;
				}
				if (global2.ingamewars[3].infl2 > 0)
				{
					global2.ingamewars[3].infl2++;
				}
			}
			else
			{
				if (global2.ingamewars[3].infl1 > 0)
				{
					global2.ingamewars[3].infl1++;
				}
				if (global2.ingamewars[3].infl2 < 1000)
				{
					global2.ingamewars[3].infl2--;
				}
			}
		}
		if (!global2.ingamewars[5].is_going)
		{
			return;
		}
		global2.ingamewars[5].fortnight_go++;
		if (global2.ingamewars[5].infl1 >= 1000 || global2.ingamewars[5].infl2 <= 0)
		{
			global2.ingamewars[5].infl1 = 1000;
			global2.ingamewars[5].infl2 = 0;
			return;
		}
		if (global2.ingamewars[5].infl2 >= 1000 || global2.ingamewars[5].infl1 <= 0)
		{
			global2.ingamewars[5].infl2 = 1000;
			global2.ingamewars[5].infl1 = 0;
			return;
		}
		if (global2.ingamewars[5].infl1 < 1000)
		{
			global2.ingamewars[5].infl1--;
		}
		if (global2.ingamewars[5].infl2 > 0)
		{
			global2.ingamewars[5].infl2++;
		}
		if (global2.ingamewars[5].ussr_place == 1)
		{
			if (global2.ingamewars[5].infl1 < 1000)
			{
				global2.ingamewars[5].infl1 -= 50;
			}
			if (global2.ingamewars[5].infl2 > 0)
			{
				global2.ingamewars[5].infl2 += 50;
			}
			if (global2.data[94] == 1)
			{
				if (global2.ingamewars[5].infl1 > 0)
				{
					global2.ingamewars[5].infl1 += 4;
				}
				if (global2.ingamewars[5].infl2 < 1000)
				{
					global2.ingamewars[5].infl2 -= 4;
				}
			}
			else if (global2.data[94] == 3)
			{
				if (global2.ingamewars[5].infl1 > 0)
				{
					global2.ingamewars[5].infl1 += 6;
				}
				if (global2.ingamewars[5].infl2 < 1000)
				{
					global2.ingamewars[5].infl2 -= 6;
				}
			}
		}
		else if (global2.data[94] == 2)
		{
			if (global2.ingamewars[5].infl1 < 1000)
			{
				global2.ingamewars[5].infl1 -= 2;
			}
			if (global2.ingamewars[5].infl2 > 0)
			{
				global2.ingamewars[5].infl2 += 2;
			}
		}
		else if (global2.completedDecisions[10])
		{
			if (global2.ingamewars[5].infl1 < 1000)
			{
				global2.ingamewars[5].infl1 += 50;
			}
			if (global2.ingamewars[5].infl2 > 0)
			{
				global2.ingamewars[5].infl2 -= 50;
			}
		}
	}

	public static string GetCountryName(GlobalScript g1, Country cou)
	{
		if (cou.EAF)
		{
			return g1.new_texts[826] + "<br>" + cou.name;
		}
		return cou.name;
	}

	private void DirectWars(GameState a)
	{
		if (a.war <= 0)
		{
			return;
		}
		if (a.data[163] >= 1000)
		{
			try
			{
				a.startedDirectWarsNum[a.war] = true;
			}
			catch (Exception innerException)
			{
				throw new Exception("Номера нет в словаре войн", innerException);
			}
			if (a.war == 1)
			{
				global2.allcountries[11].prosov = false;
				global2.allcountries[11].proprc = true;
				global2.allcountries[11].isSEV = false;
				global2.allcountries[11].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[11].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[23].prosov = false;
				global2.allcountries[23].proprc = true;
				global2.allcountries[23].isSEV = false;
				global2.allcountries[23].puppetOf = -1;
				global2.allcountries[23].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[23].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.data[39] = 0;
				if (GlobalScript.inst.gameState.ingamewars[1].is_going)
				{
					GlobalScript.inst.gameState.ingamewars[1].infl1 = 1000;
					GlobalScript.inst.gameState.ingamewars[1].is_going = false;
				}
			}
			else if (a.war == 2)
			{
				global2.influencePRC += 10;
				global2.data[62] = 2;
				global2.allcountries[1].ILoveSuckCocks();
				global2.data[34] += 434;
				global2.data[40] = 0;
			}
			else if (a.war == 3)
			{
				global2.influencePRC -= 50;
				global2.allcountries[44].puppetOf = 1;
				global2.allcountries[44].EAF = true;
				global2.allcountries[44].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[44].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[44].proprc = true;
				global2.allcountries[44].Vyshi = false;
				global2.allcountries[44].prosov = false;
				global2.empires[0].relations = 0;
				global2.allcountries[111].puppetOf = 1;
				global2.allcountries[111].EAF = true;
				global2.allcountries[111].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[111].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[111].JoinAllOurAlliances(yes: true);
				global2.allcountries[111].proprc = true;
				global2.allcountries[111].Vyshi = false;
				global2.allcountries[111].prosov = false;
				a.allcountries[44].parts[0] = true;
				a.data[167] = 1;
			}
			else if (a.war == 4)
			{
				global2.influencePRC -= 15;
				global2.allcountries[11].puppetOf = 1;
				global2.allcountries[11].EAF = true;
				global2.allcountries[11].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[11].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[11].proprc = true;
				global2.allcountries[11].Vyshi = false;
				global2.allcountries[11].prosov = false;
				global2.empires[1].relations = 0;
			}
			else if (a.war == 5)
			{
				global2.influencePRC -= 5;
				global2.allcountries[22].puppetOf = 1;
				global2.allcountries[22].EAF = true;
				global2.allcountries[22].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[22].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[22].proprc = true;
				global2.allcountries[22].Vyshi = false;
				global2.allcountries[22].prosov = false;
				global2.empires[1].relations -= 250;
			}
			else if (a.war == 6)
			{
				global2.influencePRC += 5;
				global2.allcountries[23].puppetOf = 1;
				global2.allcountries[23].EAF = true;
				global2.allcountries[23].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[23].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[23].proprc = true;
				global2.allcountries[23].Vyshi = false;
				global2.allcountries[23].prosov = false;
				global2.empires[0].relations -= 50;
				global2.empires[1].relations -= 50;
			}
			else if (a.war == 7)
			{
				global2.influencePRC += 15;
				global2.allcountries[34].puppetOf = 1;
				global2.allcountries[34].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[34].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[34].proprc = true;
				global2.allcountries[34].Vyshi = false;
				global2.allcountries[34].prosov = false;
				global2.allcountries[34].JoinAllOurAlliances(yes: true);
				global2.empires[0].relations -= 300;
			}
			else if (a.war == 8)
			{
				global2.influencePRC -= 15;
				global2.allcountries[34].puppetOf = 1;
				global2.allcountries[34].EAF = true;
				global2.allcountries[34].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[34].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[34].proprc = true;
				global2.allcountries[34].Vyshi = false;
				global2.allcountries[34].prosov = false;
				global2.empires[0].relations -= 500;
			}
			else if (a.war == 9)
			{
				global2.influencePRC += 5;
				global2.allcountries[33].puppetOf = 1;
				global2.allcountries[33].EAF = true;
				global2.allcountries[33].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[33].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[33].proprc = true;
				global2.allcountries[33].Vyshi = false;
				global2.allcountries[33].prosov = false;
				global2.empires[0].relations -= 50;
				global2.empires[1].relations -= 50;
			}
			else if (a.war == 10)
			{
				global2.influencePRC += 25;
				global2.data[1] += 500;
				global2.data[3] += 150;
				global2.data[4] -= 150;
				global2.empires[0].relations += 150;
				global2.empires[1].relations = 500;
			}
			else if (a.war == 11)
			{
				global2.influencePRC += 25;
				global2.data[1] += 500;
				global2.data[3] += 150;
				global2.data[4] -= 150;
				global2.empires[0].relations = 0;
				global2.empires[1].relations = 0;
				global2.OilProd += 50f;
				a.allcountries[1].parts[11] = true;
			}
			else if (a.war == 12)
			{
				global2.influencePRC += 5;
				global2.allcountries[52].puppetOf = 1;
				global2.allcountries[52].EAF = true;
				global2.allcountries[52].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[52].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[52].proprc = true;
				global2.allcountries[52].Vyshi = false;
				global2.allcountries[52].prosov = false;
				global2.empires[0].relations = 0;
			}
			else if (a.war == 13)
			{
				global2.influencePRC += 25;
				global2.data[1] += 150;
				global2.data[3] += 150;
				global2.data[4] -= 150;
				global2.empires[0].relations += 250;
				global2.empires[1].relations += 50;
			}
			else if (a.war == 14)
			{
				global2.influencePRC += 5;
				global2.allcountries[43].puppetOf = 1;
				global2.allcountries[43].EAF = true;
				global2.allcountries[43].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[43].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[43].proprc = true;
				global2.allcountries[43].Vyshi = false;
				global2.allcountries[43].prosov = false;
				global2.allcountries[97].puppetOf = 1;
				global2.allcountries[97].EAF = true;
				global2.allcountries[97].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[97].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[97].proprc = true;
				global2.allcountries[97].Vyshi = false;
				global2.allcountries[97].prosov = false;
				global2.empires[0].relations -= 50;
				global2.empires[1].relations -= 50;
			}
			else if (a.war == 15)
			{
				global2.influencePRC += 15;
				global2.allcountries[47].puppetOf = 1;
				global2.allcountries[47].Gosstroy = global2.allcountries[1].Gosstroy;
				global2.allcountries[47].SubGosstroy = global2.allcountries[1].SubGosstroy;
				global2.allcountries[47].proprc = true;
				global2.allcountries[47].Vyshi = false;
				global2.allcountries[47].prosov = false;
				global2.allcountries[47].JoinAllOurAlliances(yes: true);
				global2.empires[0].relations = 0;
			}
			else if (a.war == 16)
			{
				global2.influencePRC -= 5;
				global2.data[1] += 500;
				global2.data[3] += 150;
				global2.data[4] -= 150;
				global2.empires[0].relations -= 500;
				global2.OilProd += 50f;
			}
			else if (a.war == 17)
			{
				GlobalScript.inst.gameState.data[158] = 1;
				GlobalScript.inst.gameState.allcountries[10].Gosstroy = GlobalScript.inst.gameState.allcountries[1].Gosstroy;
				GlobalScript.inst.gameState.allcountries[10].SubGosstroy = GlobalScript.inst.gameState.ChineseSubGosstroy();
				GlobalScript.inst.gameState.allcountries[10].JoinAllOurAlliances(yes: true).EstablishGovernment(Government.ProChina);
				global2.allcountries[10].puppetOf = 1;
				global2.allcountries[10].EAF = true;
				if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 0)
				{
					GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[840];
				}
				else if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 1)
				{
					GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[841];
				}
				else if (GlobalScript.inst.gameState.allcountries[1].Gosstroy == 2)
				{
					GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[842];
				}
				else
				{
					GlobalScript.inst.gameState.allcountries[10].name = GlobalScript.inst.new_events_text[843];
				}
				GlobalScript.inst.gameState.data[82] = 16;
				GlobalScript.inst.gameState.ingamewars[16].infl1 = 1000;
				GlobalScript.inst.gameState.ingamewars[16].infl2 = 0;
				Reelect(18);
			}
			else if (a.war == 18)
			{
				GlobalScript.inst.gameState.data[82] = 22;
				GlobalScript.inst.gameState.ingamewars[22].infl1 = 1000;
				GlobalScript.inst.gameState.ingamewars[22].infl2 = 0;
				Reelect(18);
			}
			global2.war = 0;
			global2.data[163] = 0;
			global2.data[160] += global2.data[164] * 90 / 100;
			global2.data[164] = 0;
			for (int i = 2; i < global2.allcountries.Length; i++)
			{
				if (global2.allcountries[i].EAF)
				{
					global2.allcountries[i].LeaveAlliances();
					global2.allcountries[i].Gosstroy = global2.allcountries[1].Gosstroy;
					global2.allcountries[i].SubGosstroy = global2.allcountries[1].SubGosstroy;
					global2.allcountries[i].econ = global2.allcountries[1].econ;
					global2.allcountries[i].okb = global2.allcountries[1].okb;
					global2.allcountries[i].isASEAN = global2.allcountries[1].isASEAN;
					global2.allcountries[i].isSEV = global2.allcountries[1].isSEV;
					global2.allcountries[i].isSEATO = global2.allcountries[1].isSEATO;
					global2.allcountries[i].isSENTO = global2.allcountries[1].isSENTO;
					global2.allcountries[i].puppetOf = 1;
					global2.allcountries[i].proprc = true;
				}
				if (global2.allcountries[i].proprc)
				{
					global2.allcountries[i].prosov = false;
					global2.allcountries[i].Vyshi = false;
				}
			}
		}
		else if (a.data[163] <= 0)
		{
			if (a.war == 1)
			{
				global2.influencePRC -= 100;
				global2.data[39] = 0;
			}
			else if (a.war == 2)
			{
				global2.influencePRC -= 20;
				global2.data[40] = 0;
			}
			else if (a.war == 17)
			{
				GlobalScript.inst.gameState.data[82] = 16;
				GlobalScript.inst.gameState.ingamewars[16].infl1 = 0;
				GlobalScript.inst.gameState.ingamewars[16].infl2 = 1000;
				Reelect(18);
			}
			else if (a.war == 18)
			{
				GlobalScript.inst.gameState.data[82] = 22;
				GlobalScript.inst.gameState.ingamewars[22].infl1 = 0;
				GlobalScript.inst.gameState.ingamewars[22].infl2 = 1000;
				Reelect(18);
			}
			else
			{
				global2.influencePRC -= 50;
				global2.data[1] -= 500;
				global2.data[3] -= 250;
				global2.data[4] += 250;
				global2.empires[0].relations += 150;
				global2.empires[1].relations -= 150;
				if (a.war == 3)
				{
					a.data[167] = 0;
				}
			}
			global2.data[160] += global2.data[164] * 70 / 100;
			global2.data[164] = 0;
			global2.war = 0;
			global2.data[163] = 0;
		}
		else
		{
			global2.data[163] -= 50;
			global2.data[34]--;
		}
	}

	private void InfluenceFromInvestments()
	{
		float num = 1f - (float)(100 - global2.data[12]) / 100f / 4f;
		float num2 = ((float)global2.data[71] - (float)(global2.data[21] - 1976 + 6) * 10f) / 10f * num;
		global2.data[22] += (int)num2;
		if (global2.data[71] < 80 && global2.data[5] < 500)
		{
			global2.data[5] -= (90 - global2.data[71]) / 20;
		}
		if (global2.data[71] < 80)
		{
			global2.data[12] -= (90 - global2.data[71]) / 20;
		}
		global2.data[57] += global2.data[71] / 150;
		global2.data[57] += global2.data[76] / 150;
		if (global2.data[76] < 50)
		{
			global2.data[57] -= (50 - global2.data[76]) / 20;
		}
		global2.data[4] -= global2.data[71] / 80;
		global2.data[26] += global2.data[71] / 50;
		global2.data[12] += global2.data[71] / 90;
		if (global2.data[5] < 500)
		{
			global2.data[5] += global2.data[71] / 50;
		}
		global2.data[9] += global2.data[72] / 10;
		global2.data[4] -= global2.data[72] / 50 + global2.data[72] / 90 * 2 + global2.data[72] / 100 * 2;
		global2.data[3] -= global2.data[72] / 90 * 2 + global2.data[72] / 100;
		global2.data[1] -= global2.data[72] / 90 * 2 + global2.data[72] / 100;
		if (global2.data[5] < 500)
		{
			global2.data[5] += global2.data[72] / 80;
		}
		if (global2.data[72] >= global2.data[9] && global2.data[72] <= 150)
		{
			global2.data[26] -= global2.data[72] / 50 + global2.data[72] / 100;
		}
		else if (global2.data[9] > 0 && global2.data[9] <= 150 && global2.data[72] <= 150)
		{
			global2.data[26] -= global2.data[9] / 50 + global2.data[72] / 100;
		}
		else if (global2.data[9] > 0 && global2.data[9] <= 150 && global2.data[72] > 150)
		{
			global2.data[26] -= global2.data[9] / 50 + 1;
		}
		else if (global2.data[72] > 150)
		{
			global2.data[26] -= 4;
		}
		global2.data[26] += global2.data[73] / 50;
		global2.data[26] -= global2.data[74] / 20;
		global2.data[1] += global2.data[74] / 25;
		global2.data[5] += global2.data[74] / 70;
		global2.data[26] += global2.data[75] / 25;
		global2.data[1] += (global2.data[75] - 61) / 5;
		global2.data[26] -= global2.data[76] / 100;
		global2.data[57] += global2.data[76] / 150;
		global2.data[26] += global2.data[76] / 150;
		global2.data[4] -= global2.data[76] / 100;
		global2.data[3] += (global2.data[76] - 70) / 10;
		if (global2.data[76] < 50)
		{
			global2.data[26] += (50 - global2.data[76]) / 20;
			global2.data[3] -= (50 - global2.data[76]) / 20;
		}
		global2.data[26] += global2.data[77] / 80;
		global2.data[13] += global2.data[77] / 15;
		global2.data[5] += global2.data[77] / 100;
		if (global2.data[77] < 40)
		{
			global2.data[13] += (global2.data[77] - 40) / 10;
		}
		global2.data[26] += global2.data[78] / 80;
		global2.data[12] += global2.data[78] / 10;
		global2.data[5] += global2.data[78] / 80;
		if (global2.data[78] < 70)
		{
			global2.data[12] += (global2.data[78] - 70) / 10;
		}
		global2.data[26] += global2.data[79] / 50;
		global2.data[68] += global2.data[79] / 10;
		global2.data[5] += global2.data[79] / 40;
		if (global2.data[79] < 40)
		{
			global2.data[68] += (global2.data[79] - 40) / 10;
		}
		global2.data[5] += (global2.data[80] - 40) / 5;
		if (global2.data[16] < 13)
		{
			global2.data[26] += global2.data[80] / 80;
		}
		else
		{
			global2.data[26] += global2.data[80] / 50;
		}
		global2.data[3] += global2.data[80] / 80;
		if (global2.data[81] < 60 && global2.data[81] > 0)
		{
			global2.data[6]--;
		}
		else if (global2.data[81] <= 0)
		{
			global2.data[6] -= 2;
		}
		global2.data[8] -= global2.data[26] / 10;
		global2.data[5] -= global2.data[26] / 50;
	}

	private void MutualRelationsChange()
	{
		if (global2.allcountries[1].isOVD && global2.empires[0].relations > 650)
		{
			global2.empires[0].relations += ((!global2.science[32]) ? (global2.data[81] / 45) : (global2.data[81] / 40));
		}
		else if ((global2.allcountries[1].isSEV || global2.allcountries[1].okb) && global2.empires[0].relations > 650)
		{
			global2.empires[0].relations += ((!global2.science[32]) ? (global2.data[81] / 40) : (global2.data[81] / 35));
		}
		else if (global2.empires[1].relations > 750 && !global2.modifies[17].active)
		{
			global2.empires[0].relations += ((!global2.science[32]) ? (global2.data[81] / 30) : (global2.data[81] / 25));
		}
		else if (global2.empires[0].relations < 200 && global2.modifies[17].active)
		{
			global2.empires[0].relations += ((!global2.science[32]) ? (global2.data[81] / 15) : (global2.data[81] / 10));
		}
		else if (global2.empires[0].relations < 400)
		{
			global2.empires[0].relations += ((!global2.science[32]) ? (global2.data[81] / 20) : (global2.data[81] / 15));
		}
		else
		{
			global2.empires[0].relations += ((!global2.science[32]) ? (global2.data[81] / 25) : (global2.data[81] / 20));
		}
		if ((global2.allcountries[1].Vyshi || global2.allcountries[51].dev == 1) && global2.empires[1].relations > 650)
		{
			global2.empires[1].relations += ((!global2.science[32]) ? (global2.data[81] / 45) : (global2.data[81] / 40));
		}
		else if ((global2.allcountries[51].Torg || global2.allcountries[1].okb) && global2.empires[1].relations > 650)
		{
			global2.empires[1].relations += ((!global2.science[32]) ? (global2.data[81] / 40) : (global2.data[81] / 35));
		}
		else if (global2.empires[0].relations > 750 && !global2.modifies[17].active)
		{
			global2.empires[1].relations += ((!global2.science[32]) ? (global2.data[81] / 30) : (global2.data[81] / 25));
		}
		else if (global2.empires[1].relations < 200 && global2.modifies[17].active)
		{
			global2.empires[1].relations += ((!global2.science[32]) ? (global2.data[81] / 15) : (global2.data[81] / 10));
		}
		else if (global2.empires[1].relations < 400)
		{
			global2.empires[1].relations += ((!global2.science[32]) ? (global2.data[81] / 20) : (global2.data[81] / 15));
		}
		else
		{
			global2.empires[1].relations += ((!global2.science[32]) ? (global2.data[81] / 25) : (global2.data[81] / 20));
		}
		if (!global1.dlc[0])
		{
			if (global2.empires[0].relations > 900 && global2.empires[1].relations > 500)
			{
				global2.empires[1].relations -= 30;
			}
			else if (global2.empires[0].relations > 800 && global2.empires[1].relations > 400)
			{
				global2.empires[1].relations -= 20;
			}
			else if (global2.empires[0].relations > 700 && global2.empires[1].relations > 300)
			{
				global2.empires[1].relations -= 10;
			}
			else if (global2.empires[0].relations > 650)
			{
				global2.empires[1].relations -= 5;
			}
			if (global2.empires[1].relations > 800 && global2.empires[0].relations > 500)
			{
				global2.empires[0].relations -= 30;
			}
			else if (global2.empires[1].relations > 650 && global2.empires[0].relations > 350)
			{
				global2.empires[0].relations -= 20;
			}
			else if (global2.empires[1].relations > 650)
			{
				global2.empires[0].relations -= 10;
			}
		}
		else
		{
			if (global2.empires[0].relations < 750 && global2.empires[0].relations > 700 && global2.empires[1].relations > 300)
			{
				global2.empires[1].relations -= 10;
			}
			else if (global2.empires[0].relations > 650)
			{
				global2.empires[1].relations -= 5;
			}
			if (global2.empires[1].relations < 750 && global2.empires[1].relations > 650 && global2.empires[0].relations > 350)
			{
				global2.empires[0].relations -= 20;
			}
			else if (global2.empires[1].relations < 750 && global2.empires[1].relations > 650)
			{
				global2.empires[0].relations -= 10;
			}
		}
		if (global2.empires[0].relations < 700)
		{
			global2.empires[0].relations += global2.data[69] / 20;
		}
	}

	private void EventsRequirements()
	{
		if (((global2.data[19] >= 9 && global2.data[20] >= 9 && global2.data[21] >= 1976) || global2.data[20] >= 10) && !global2.event_done[3] && !events[0].activeSelf)
		{
			this_num_event = 3;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 4 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && global2.data[16] >= 10 && !global2.event_done[38] && !events[0].activeSelf)
		{
			this_num_event = 38;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if ((global2.data[3] - global2.data[4] < -50 || global2.data[3] < 100 || global2.data[4] >= 1200) && !global2.event_done[5] && !events[0].activeSelf)
		{
			this_num_event = 5;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[5] < 100 && !events[0].activeSelf)
		{
			this_num_event = 6;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.empires[0].relations <= 0 && !events[0].activeSelf && !global2.event_done[7])
		{
			this_num_event = 7;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.empires[1].relations <= 0 && !events[0].activeSelf && !global2.event_done[8])
		{
			this_num_event = 8;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[57] <= 300 && !global2.completedDecisions[4] && !global2.completedDecisions[3] && global2.data[66] == 0 && !events[0].activeSelf && !global2.event_done[10])
		{
			this_num_event = 10;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[57] <= 400 && !global2.completedDecisions[2] && !global2.completedDecisions[1] && global2.data[67] == 0 && !events[0].activeSelf && !global2.event_done[9])
		{
			this_num_event = 9;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[12] <= 0 && !events[0].activeSelf)
		{
			this_num_event = 11;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[13] <= 0 && !events[0].activeSelf)
		{
			this_num_event = 12;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[68] <= 0 && !events[0].activeSelf)
		{
			this_num_event = 13;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[8] + global2.data[81] + global2.data[80] + global2.data[79] + global2.data[78] + global2.data[77] + global2.data[76] + global2.data[75] + global2.data[74] + global2.data[73] + global2.data[72] + global2.data[71] < 800 && global2.data[8] < 300 && !events[0].activeSelf)
		{
			this_num_event = 14;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.allcountries[23].Gosstroy == 0 && !global2.allcountries[23].EAF && (global2.allcountries[23].econ || global2.allcountries[23].proprc || global2.allcountries[23].puppetOf == 1) && !global2.event_done[15] && ((global2.data[20] >= 12 && global2.data[21] >= 1976) || global2.data[21] == 1977) && !events[0].activeSelf)
		{
			this_num_event = 15;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[435] && !events[0].activeSelf)
		{
			this_num_event = 435;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 10 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[436] && !events[0].activeSelf)
		{
			this_num_event = 436;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 4 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && !global2.event_done[16] && !events[0].activeSelf)
		{
			this_num_event = 16;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 10 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && !global2.event_done[17] && !events[0].activeSelf)
		{
			this_num_event = 17;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && !global2.event_done[19] && !events[0].activeSelf)
		{
			this_num_event = 19;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && global2.event_done[19] && !global2.event_done[20] && !events[0].activeSelf)
		{
			this_num_event = 20;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 4 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && !global2.event_done[21] && !events[0].activeSelf)
		{
			this_num_event = 21;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 5 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && !global2.event_done[22] && !events[0].activeSelf)
		{
			this_num_event = 22;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 8 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && !global2.event_done[23] && !events[0].activeSelf)
		{
			this_num_event = 23;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 12 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && !global2.event_done[24] && !events[0].activeSelf)
		{
			this_num_event = 24;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 10 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && !global2.event_done[25] && !events[0].activeSelf)
		{
			this_num_event = 25;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 11 && global2.data[21] >= 1976) || global2.data[21] >= 1977) && global2.data[84] == 3 && !global2.event_done[26] && !events[0].activeSelf)
		{
			this_num_event = 26;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 7 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[33] && !events[0].activeSelf)
		{
			this_num_event = 33;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && global2.data[84] != 3 && !global2.event_done[34] && !events[0].activeSelf)
		{
			this_num_event = 34;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 5 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.modifies[3].active && global2.data[8] != 2 && !global2.event_done[35] && !events[0].activeSelf)
		{
			this_num_event = 35;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 12 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[36] && !events[0].activeSelf)
		{
			this_num_event = 36;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 22 && global2.data[20] >= 9 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[37] && !events[0].activeSelf)
		{
			this_num_event = 37;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 3 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && global2.data[87] != 2 && !global2.event_done[39] && !events[0].activeSelf)
		{
			this_num_event = 39;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 22 && global2.data[20] >= 10 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && global2.data[50] != 28 && !global2.event_done[40] && !events[0].activeSelf)
		{
			this_num_event = 40;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 3 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[41] && !events[0].activeSelf)
		{
			this_num_event = 41;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[15] > 7 && global2.data[125] <= 0 && (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] <= 0) && !events[0].activeSelf)
		{
			this_num_event = 1;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 8 && global2.data[20] >= 1 && global2.data[21] >= 1978) || global2.data[21] >= 1979) && !global2.event_done[42] && !events[0].activeSelf)
		{
			this_num_event = 42;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 11 && global2.data[21] >= 1978) || global2.data[21] >= 1979) && !global2.event_done[43] && !events[0].activeSelf)
		{
			this_num_event = 43;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[21] >= 1978 && global2.data[89] == 0 && event44 && !global2.event_done[44] && !events[0].activeSelf)
		{
			this_num_event = 44;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1978) || global2.data[21] >= 1979) && global2.data[89] == 1 && !global2.event_done[45] && !events[0].activeSelf)
		{
			this_num_event = 45;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 11 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[46] && !events[0].activeSelf)
		{
			this_num_event = 46;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 6 && global2.data[21] >= 1978) || global2.data[21] >= 1979) && global2.data[89] == 0 && !global2.event_done[47] && !events[0].activeSelf)
		{
			this_num_event = 47;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 5 && global2.data[21] >= 1978) || global2.data[21] >= 1979) && !global2.event_done[63] && !events[0].activeSelf)
		{
			this_num_event = 63;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 16 && global2.data[20] >= 9 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && global2.data[48] > global2.data[49] && !global2.event_done[48] && !events[0].activeSelf)
		{
			this_num_event = 48;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && global2.allcountries[12].Gosstroy == 0 && !global2.allcountries[12].econ && !global2.event_done[49] && !events[0].activeSelf)
		{
			this_num_event = 49;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && global2.event_done[49] && global2.allcountries[12].Gosstroy == 1 && !global2.allcountries[12].econ && !global2.event_done[50] && !events[0].activeSelf)
		{
			this_num_event = 50;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && global2.allcountries[8].Gosstroy != 0 && !global2.allcountries[31].Vyshi && !global2.allcountries[8].Vyshi && global2.data[48] == global2.data[49] && !global2.event_done[49] && !global2.event_done[51] && !events[0].activeSelf)
		{
			this_num_event = 51;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && global2.ingamewars[5].is_going && global2.allcountries[31].proprc && !global2.event_done[52] && !events[0].activeSelf)
		{
			this_num_event = 52;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && !global2.event_done[53] && !events[0].activeSelf)
		{
			this_num_event = 53;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && !global2.event_done[53] && !events[0].activeSelf)
		{
			this_num_event = 53;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.event_done[53] && global2.data[16] > 11 && !global2.event_done[54] && !events[0].activeSelf)
		{
			this_num_event = 54;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 11 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.allcountries[33].proprc && !global2.event_done[55] && !events[0].activeSelf)
		{
			this_num_event = 55;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && !global2.event_done[56] && !events[0].activeSelf)
		{
			this_num_event = 56;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 10 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && !global2.event_done[57] && !events[0].activeSelf && !global2.allcountries[1].isASEAN)
		{
			this_num_event = 57;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && !global2.event_done[58] && !events[0].activeSelf)
		{
			this_num_event = 58;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 5 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && (global2.allcountries[23].proprc || global2.allcountries[34].proprc || global2.allcountries[20].proprc || global2.allcountries[31].proprc) && !global2.event_done[59] && !events[0].activeSelf && !global2.allcountries[1].isASEAN)
		{
			this_num_event = 59;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 6 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && global2.allcountries[1].econ && !global2.event_done[60] && !events[0].activeSelf)
		{
			this_num_event = 60;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1978) || global2.data[21] >= 1979) && global2.data[82] != 2 && !global2.event_done[61] && !events[0].activeSelf)
		{
			this_num_event = 61;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 8 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && global2.data[82] != 2 && !global2.event_done[62] && !events[0].activeSelf)
		{
			this_num_event = 62;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 8 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && !global2.allcountries[1].isASEAN && global2.allcountries[30].Gosstroy == 2 && !global2.event_done[64] && !events[0].activeSelf)
		{
			this_num_event = 64;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && !global2.event_done[65] && !events[0].activeSelf)
		{
			this_num_event = 65;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 5 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && !global2.event_done[66] && !events[0].activeSelf)
		{
			this_num_event = 66;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 10 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && !global2.event_done[67] && !events[0].activeSelf)
		{
			this_num_event = 67;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 15 && global2.data[20] >= 8 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && !global2.event_done[68] && !events[0].activeSelf)
		{
			this_num_event = 68;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && global2.data[89] > 0 && !global2.event_done[69] && !events[0].activeSelf)
		{
			this_num_event = 69;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && global2.data[89] == 0 && global2.modifies[14].active && !global2.event_done[70] && !events[0].activeSelf)
		{
			this_num_event = 70;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[32] >= 500 && !global2.event_done[71] && !events[0].activeSelf)
		{
			this_num_event = 71;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 7 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && global2.data[91] >= 1 && global2.data[91] <= 2 && !global2.event_done[72] && !events[0].activeSelf)
		{
			this_num_event = 72;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 15 && global2.data[20] >= 9 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && !global2.allcountries[8].Vyshi && !global2.allcountries[8].okb && !global2.allcountries[8].isSEV && global2.allcountries[8].puppetOf <= 0 && global2.allcountries[14].puppetOf <= 0 && !global2.allcountries[8].econ && global2.allcountries[8].Gosstroy == 0 && !global2.event_done[73] && !events[0].activeSelf)
		{
			this_num_event = 73;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 7 && global2.data[21] >= 1981) || global2.data[21] >= 1982) && global2.event_done[39] && !global2.event_done[74] && !events[0].activeSelf)
		{
			this_num_event = 74;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 8 && global2.data[21] >= 1981) || global2.data[21] >= 1982) && (global2.data[117] != 9 || global2.allcountries[8].Vyshi || global2.allcountries[8].Gosstroy != 0) && global2.allcountries[14].dev == 0 && !global2.event_done[75] && !events[0].activeSelf)
		{
			this_num_event = 75;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 3 && global2.data[21] >= 1981) || global2.data[21] >= 1982) && !global2.allcountries[15].Torg && global2.data[60] == 0 && !global2.event_done[76] && !events[0].activeSelf)
		{
			this_num_event = 76;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 11 && global2.data[21] >= 1981) || global2.data[21] >= 1982) && global2.data[60] < 1 && global2.allcountries[20].SubGosstroy != 11 && !global2.allcountries[20].econ && !global2.event_done[77] && !events[0].activeSelf)
		{
			this_num_event = 77;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 6 && global2.data[21] >= 1981) || global2.data[21] >= 1982) && !global2.allcountries[1].isASEAN && !global2.allcountries[47].okb && !global2.allcountries[47].isSEV && !global2.allcountries[47].econ && global2.allcountries[47].Gosstroy == 0 && !global2.event_done[78] && !events[0].activeSelf)
		{
			this_num_event = 78;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 9 && global2.data[21] >= 1981) || global2.data[21] >= 1982) && (global2.allcountries[8].dev != 0 || !global2.allcountries[8].Vyshi || global2.allcountries[8].Gosstroy != 0) && !global2.event_done[79] && !events[0].activeSelf)
		{
			this_num_event = 79;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 9 && global2.data[21] >= 1982) || global2.data[21] >= 1983) && (global2.data[90] == 1 || global2.data[90] == 2) && !global2.event_done[80] && !events[0].activeSelf)
		{
			this_num_event = 80;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 4 && global2.data[21] >= 1982) || global2.data[21] >= 1983) && global2.allcountries[4].Gosstroy == 2 && (global2.allcountries[20].proprc || global2.relres) && !global2.event_done[81] && !events[0].activeSelf)
		{
			this_num_event = 81;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 2 && global2.data[20] >= 4 && global2.data[21] >= 1982) || global2.data[21] >= 1983) && (global2.allcountries[71].Gosstroy == 0 || global2.allcountries[71].SubGosstroy == 0 || global2.allcountries[71].SubGosstroy >= 7) && !global2.event_done[82] && !events[0].activeSelf)
		{
			this_num_event = 82;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 4 && global2.data[20] >= 7 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[83] && !events[0].activeSelf)
		{
			this_num_event = 83;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 4 && global2.data[20] >= 10 && global2.data[21] >= 1978) || global2.data[21] >= 1979) && global2.empires[1].now_leader == 0 && (global2.resultOfEvents[83] == 0 || global2.data[149] == 1) && !global2.event_done[84] && !events[0].activeSelf)
		{
			this_num_event = 84;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 6 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && global2.empires[1].now_leader == 0 && (global2.resultOfEvents[84] == 0 || global2.data[149] == 2) && !global2.event_done[85] && !events[0].activeSelf)
		{
			this_num_event = 85;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 7 && global2.data[21] >= 1979) || global2.data[21] >= 1980) && global2.empires[1].now_leader == 0 && (global2.resultOfEvents[85] == 0 || global2.data[149] == 3) && !global2.event_done[86] && !events[0].activeSelf)
		{
			this_num_event = 86;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 6 && global2.data[20] >= 6 && global2.data[21] >= 1982) || global2.data[21] >= 1983) && !global2.event_done[87] && !events[0].activeSelf)
		{
			this_num_event = 87;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 1 && global2.data[21] >= 1982) || global2.data[21] >= 1983) && !global2.event_done[446] && !events[0].activeSelf)
		{
			this_num_event = 446;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.gameState.resultOfEvents[85] >= 3 && ((global2.data[19] >= 1 && global2.data[20] >= 7 && global2.data[21] >= 1984) || global2.data[21] >= 1985) && !global2.event_done[89] && !events[0].activeSelf)
		{
			this_num_event = 89;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.gameState.resultOfEvents[85] < 3 && ((global2.data[19] >= 10 && global2.data[20] >= 11 && global2.data[21] >= 1982) || global2.data[21] >= 1983) && !global2.event_done[89] && !events[0].activeSelf)
		{
			this_num_event = 89;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 12 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && global2.data[65] == 1 && !global2.event_done[90] && !events[0].activeSelf)
		{
			this_num_event = 90;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 9 && global2.data[20] >= 10 && global2.data[21] >= 1983) || global2.data[21] >= 1984) && global2.allcountries[46].Gosstroy == 0 && !global2.event_done[91] && !events[0].activeSelf)
		{
			this_num_event = 91;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[16] <= 11 && !global2.event_done[92] && !events[0].activeSelf)
		{
			this_num_event = 92;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 11 && global2.data[21] >= 1977) || global2.data[21] >= 1978) && !global2.event_done[93] && !events[0].activeSelf)
		{
			this_num_event = 93;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[92] >= 90 && global2.data[21] >= 1983 && !global2.event_done[94] && !events[0].activeSelf)
		{
			this_num_event = 94;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[107] == 1 && !global2.event_done[95] && global2.event_done[94] && !events[0].activeSelf)
		{
			this_num_event = 95;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[107] == 1 && !global2.event_done[96] && global2.event_done[95] && !events[0].activeSelf)
		{
			this_num_event = 96;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.science[17] && global2.data[16] == 10 && !global2.event_done[97] && !events[0].activeSelf)
		{
			this_num_event = 97;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 8 && global2.data[21] >= 1983) || global2.data[21] >= 1984) && !global2.event_done[98] && !events[0].activeSelf)
		{
			this_num_event = 98;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 11 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && !global2.event_done[114] && !events[0].activeSelf)
		{
			this_num_event = 114;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 9 && global2.data[20] >= 2 && global2.data[21] >= 1984) || global2.data[21] >= 1985) && global2.empires[1].now_leader == 1 && global2.empires[1].now_leader != 7 && !global2.event_done[117] && !events[0].activeSelf)
		{
			this_num_event = 117;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 10 && global2.data[20] >= 12 && global2.data[21] >= 1978) || global2.data[21] >= 1979) && !global2.event_done[99] && !events[0].activeSelf)
		{
			this_num_event = 99;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 10 && global2.data[20] >= 12 && global2.data[21] >= 1983) || global2.data[21] >= 1984) && !global2.event_done[100] && !events[0].activeSelf)
		{
			this_num_event = 100;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.gameState.resultOfEvents[85] < 3 && ((global2.data[19] >= 10 && global2.data[20] >= 3 && global2.data[21] >= 1985) || global2.data[21] >= 1986) && (global2.empires[1].now_leader == 1 || global2.empires[1].now_leader == 2) && global2.empires[1].now_leader != 7 && !global2.event_done[102] && !events[0].activeSelf)
		{
			this_num_event = 102;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 7 && global2.data[21] >= 1985) || global2.data[21] >= 1986) && !global2.event_done[104] && !events[0].activeSelf)
		{
			this_num_event = 104;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[19] >= 13 && global2.data[20] >= 4 && global2.data[21] >= 1985) || global2.data[21] >= 1986) && global2.data[60] == 0 && global2.allcountries[20].SubGosstroy != 11 && !global2.event_done[105] && !events[0].activeSelf)
		{
			this_num_event = 105;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 6 && global2.data[21] >= 1985) || global2.data[21] >= 1986) && !global2.event_done[106] && !global2.allcountries[7].isNATO && global2.allcountries[51].isNATO && !events[0].activeSelf)
		{
			this_num_event = 106;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if ((((global2.data[20] >= 6 && global2.data[21] >= 1980) || global2.data[21] >= 1981) && !global2.event_done[109] && !events[0].activeSelf && !GlobalScript.inst.dlc[3]) || (!global2.event_done[109] && !events[0].activeSelf && GlobalScript.inst.dlc[3] && !global2.allcountries[42].parts[0] && ((global2.data[20] >= 6 && global2.data[21] >= 1980) || global2.data[21] >= 1981)))
		{
			this_num_event = 109;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 2 && global2.data[21] >= 1983) || global2.data[21] >= 1984) && !global2.allcountries[15].isEU && global2.allcountries[15].SubGosstroy == 11 && global2.allcountries[20].SubGosstroy != 11 && !global2.event_done[113] && !events[0].activeSelf)
		{
			this_num_event = 113;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[21] >= 1982 && global2.allcountries[33].Torg && global2.allcountries[34].Torg && global2.allcountries[22].Torg && !global2.event_done[115] && !events[0].activeSelf)
		{
			this_num_event = 115;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[21] >= 1985 && global2.data[107] == 1 && !global2.event_done[116] && global2.allcountries[38].dev == 0 && global2.event_done[95] && global2.event_done[96] && !events[0].activeSelf && global2.data[64] <= 0 && !global2.completedDecisions[6] && !global2.completedDecisions[7])
		{
			this_num_event = 116;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[21] >= 1980 && !global2.modifies[12].active && global2.science[15] && global2.data[16] <= 11 && !global2.event_done[110] && !events[0].activeSelf)
		{
			this_num_event = 110;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.science[15] && global2.data[21] >= 1983 && global2.modifies[11].active && !global2.event_done[111] && !events[0].activeSelf)
		{
			this_num_event = 111;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.modifies[11].active && global2.allcountries[1].okb && global2.data[21] >= 1984 && !global2.event_done[112] && global2.event_done[110] && global2.event_done[111] && global2.event_done[97] && !events[0].activeSelf)
		{
			this_num_event = 112;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (((global2.data[20] >= 7 && global2.data[21] >= 1985) || global2.data[21] >= 1986) && (global2.allcountries[0].isEU || (global2.allcountries[21].isSocEU && !global2.allcountries[0].isEU)) && global2.allcountries[1].econ && !global2.event_done[103] && !events[0].activeSelf)
		{
			this_num_event = 103;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (global2.data[120] > 0 && global2.allcountries[1].econ && !events[0].activeSelf)
		{
			this_num_event = 107;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.dlc[5] && !global2.event_done[447] && global2.data[20] >= 10 && global2.data[21] >= 1976 && !events[0].activeSelf)
		{
			this_num_event = 447;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.dlc[6] && !global2.event_done[451] && global2.event_done[452] && global2.resultOfEvents[452] == 0 && global2.data[20] >= 4 && global2.data[21] >= 1979 && !events[0].activeSelf)
		{
			this_num_event = 451;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.dlc[6] && !global2.event_done[452] && global2.data[20] >= 1 && global2.data[21] >= 1979 && !events[0].activeSelf)
		{
			this_num_event = 452;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.dlc[6] && !global2.event_done[453] && global2.event_done[451] && global2.resultOfEvents[451] == 0 && global2.data[20] >= 1 && global2.data[21] >= 1980 && !events[0].activeSelf)
		{
			this_num_event = 453;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.dlc[6] && !global2.event_done[454] && global2.event_done[452] && global2.allcountries[4].isMonatchy && !events[0].activeSelf)
		{
			this_num_event = 454;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.dlc[6] && global2.allcountries[20].spec != 1 && global2.allcountries[20].puppetOf != 15 && !global2.allcountries[15].Vyshi && !global2.event_done[455] && global2.resultOfEvents[113] == 5 && global2.data[20] >= 4 && global2.data[21] >= 1984 && !events[0].activeSelf)
		{
			this_num_event = 455;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (GlobalScript.inst.dlc[6] && global2.event_done[67] && global2.resultOfEvents[67] != 0 && global2.resultOfEvents[67] != 4 && global2.allcountries[1].isSEV && !global2.event_done[456] && global2.data[21] == 1980 && !events[0].activeSelf)
		{
			this_num_event = 456;
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (!events[0].activeSelf && GlobalScript.inst.dlc[7] && ReqEventForDLC05.RequrementsDLC07(ref this_num_event, global2))
		{
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (!events[0].activeSelf && GlobalScript.inst.dlc[4] && ReqEventForDLC02.RequrementsDLC04(ref this_num_event, global2))
		{
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (!events[0].activeSelf && GlobalScript.inst.dlc[2] && ReqEventForDLC02.RequrementsDLC02(ref this_num_event, global2))
		{
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (!events[0].activeSelf && GlobalScript.inst.dlc[3] && ReqEventForDLC02.RequrementsDLC03(ref this_num_event, global2))
		{
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
		else if (!events[0].activeSelf && GlobalScript.inst.dlc[1] && ReqEventForDLC02.RequrementsDLC01(ref this_num_event, global2))
		{
			events[0].GetComponent<EventScript>().Reset(this_num_event);
			events[0].SetActive(value: true);
		}
	}

	public void FocusesResearching()
	{
		Empire[] empires = global2.empires;
		for (int i = 1; i < empires.Length; i++)
		{
			if (empires[i].now_focus > -1)
			{
				if (FocusManager.all_trees[empires[i].active_tree][empires[i].now_layer][empires[i].now_focus].overtime >= FocusManager.all_trees[empires[i].active_tree][empires[i].now_layer][empires[i].now_focus].time)
				{
					FocusManager.all_trees[empires[i].active_tree][empires[i].now_layer][empires[i].now_focus].active();
					empires[i].now_focus = -1;
					empires[i].now_layer++;
				}
				else
				{
					FocusManager.all_trees[empires[i].active_tree][empires[i].now_layer][empires[i].now_focus].overtime++;
				}
			}
			else
			{
				FocusesAIMethod(i);
			}
		}
	}

	private void FocusesAIMethod(int country)
	{
		List<int> list = new List<int>();
		Empire[] empires = global2.empires;
		for (int i = 0; i < FocusManager.all_trees[empires[country].active_tree][global2.empires[country].now_layer].Count; i++)
		{
			Debug.Log($"{FocusManager.all_trees[empires[country].active_tree][global2.empires[country].now_layer][i]}");
			if (FocusManager.all_trees[empires[country].active_tree][global2.empires[country].now_layer][i].condition())
			{
				list.Add(i);
				FocusManager.all_trees[empires[country].active_tree][global2.empires[country].now_layer][i].blocked = true;
			}
			else
			{
				FocusManager.all_trees[empires[country].active_tree][global2.empires[country].now_layer][i].blocked = true;
			}
		}
		if (list.Count > 1)
		{
			global2.empires[country].now_focus = list[UnityEngine.Random.Range(0, list.Count)];
			FocusManager.all_trees[empires[country].active_tree][global2.empires[country].now_layer][global2.empires[country].now_focus].blocked = false;
		}
		else if (list.Count == 1)
		{
			global2.empires[country].now_focus = list[0];
			FocusManager.all_trees[empires[country].active_tree][global2.empires[country].now_layer][list[0]].blocked = false;
		}
		Debug.Log("СЕЙЧАС ИЗУЧАЕТ: " + global2.empires[country].now_focus);
	}
}
