using System.IO;
using UnityEngine;

public class CreateScript : MonoBehaviour
{
	public GameObject rules;

	public GameObject un;

	public GameObject ach;

	private void Awake()
	{
		if (GameObject.Find("Global(Clone)") == null)
		{
			Object.Instantiate(un);
			GameObject obj = GameObject.Find("Global(Clone)");
			Object.DontDestroyOnLoad(obj);
			obj.GetComponent<GlobalScript>().Init();
		}
		_ = GlobalScript.inst;
		if (GameObject.Find("Ach(Clone)") == null)
		{
			Object.Instantiate(ach);
			Object.DontDestroyOnLoad(GameObject.Find("Ach(Clone)"));
		}
		GlobalScript.inst.gameState.turn_on = true;
		CheckDLC();
	}

	private void CheckDLC()
	{
		try
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer)
			{
				if (File.Exists(Application.dataPath + "\\GR00.txt") && File.Exists(Application.dataPath + "\\GR00.png"))
				{
					GlobalScript.inst.dlc[0] = true;
					rules.SetActive(value: true);
					for (int i = 0; i < GlobalScript.inst.gameState.gamerules.Length; i++)
					{
						if (PlayerPrefs.HasKey("gamerules" + i))
						{
							GlobalScript.inst.gameState.gamerules[i] = PlayerPrefs.GetInt("gamerules" + i);
						}
					}
				}
				else
				{
					rules.SetActive(value: false);
					GlobalScript.inst.dlc[0] = false;
				}
				if (File.Exists(Application.dataPath + "\\BD01.txt") && File.Exists(Application.dataPath + "\\BD01.png"))
				{
					GlobalScript.inst.dlc[1] = true;
				}
				else
				{
					GlobalScript.inst.dlc[1] = false;
				}
				if (File.Exists(Application.dataPath + "\\BD22.txt") && File.Exists(Application.dataPath + "\\BD02.png"))
				{
					GlobalScript.inst.dlc[2] = true;
				}
				else
				{
					GlobalScript.inst.dlc[2] = false;
				}
				if (File.Exists(Application.dataPath + "\\FE0323.txt") && File.Exists(Application.dataPath + "\\070323.png"))
				{
					GlobalScript.inst.dlc[3] = true;
				}
				else
				{
					GlobalScript.inst.dlc[3] = false;
				}
				if (File.Exists(Application.dataPath + "\\NANINO.txt") && File.Exists(Application.dataPath + "\\STRST.png"))
				{
					GlobalScript.inst.dlc[5] = true;
				}
				else
				{
					GlobalScript.inst.dlc[5] = false;
				}
				if (File.Exists(Application.dataPath + "\\NOTTOREAD.txt") && File.Exists(Application.dataPath + "\\NOTOTWATCH.png"))
				{
					GlobalScript.inst.dlc[6] = true;
				}
				else
				{
					GlobalScript.inst.dlc[6] = false;
				}
				if (File.Exists(Application.dataPath + "\\DARETOTHINK.txt") && File.Exists(Application.dataPath + "\\DARETODO.png"))
				{
					GlobalScript.inst.dlc[8] = true;
				}
				else
				{
					GlobalScript.inst.dlc[8] = false;
				}
				return;
			}
			if (File.Exists(Application.dataPath + "/GR00.txt") && File.Exists(Application.dataPath + "/GR00.png"))
			{
				GlobalScript.inst.dlc[0] = true;
				rules.SetActive(value: true);
				for (int j = 0; j < GlobalScript.inst.gameState.gamerules.Length; j++)
				{
					if (PlayerPrefs.HasKey("gamerules" + j))
					{
						GlobalScript.inst.gameState.gamerules[j] = PlayerPrefs.GetInt("gamerules" + j);
					}
				}
			}
			else
			{
				rules.SetActive(value: false);
				GlobalScript.inst.dlc[0] = false;
			}
			if (File.Exists(Application.dataPath + "/BD01.txt") && File.Exists(Application.dataPath + "/BD01.png"))
			{
				GlobalScript.inst.dlc[1] = true;
			}
			else
			{
				GlobalScript.inst.dlc[1] = false;
			}
			if (File.Exists(Application.dataPath + "/BD22.txt") && File.Exists(Application.dataPath + "/BD02.png"))
			{
				GlobalScript.inst.dlc[2] = true;
			}
			else
			{
				GlobalScript.inst.dlc[2] = false;
			}
			if (File.Exists(Application.dataPath + "/FE0323.txt") && File.Exists(Application.dataPath + "/070323.png"))
			{
				GlobalScript.inst.dlc[3] = true;
			}
			else
			{
				GlobalScript.inst.dlc[3] = false;
			}
			if (File.Exists(Application.dataPath + "/NANINO.txt") && File.Exists(Application.dataPath + "/STRST.png"))
			{
				GlobalScript.inst.dlc[5] = true;
			}
			else
			{
				GlobalScript.inst.dlc[5] = false;
			}
			if (File.Exists(Application.dataPath + "/NOTTOREAD.txt") && File.Exists(Application.dataPath + "/NOTOTWATCH.png"))
			{
				GlobalScript.inst.dlc[6] = true;
			}
			else
			{
				GlobalScript.inst.dlc[6] = false;
			}
			if (File.Exists(Application.dataPath + "/DARETOTHINK.txt") && File.Exists(Application.dataPath + "/DARETODO.png"))
			{
				GlobalScript.inst.dlc[8] = true;
			}
			else
			{
				GlobalScript.inst.dlc[8] = false;
			}
		}
		catch
		{
			GlobalScript.inst.dlc[1] = false;
			GlobalScript.inst.dlc[2] = false;
		}
	}
}
