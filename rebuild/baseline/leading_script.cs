using UnityEngine;

public class leading_script : MonoBehaviour
{
	private GlobalScript global1;

	private GameObject pidor;

	public GameObject okno;

	public Camera Cam;

	private void Awake()
	{
		global1 = GlobalScript.inst;
	}

	private void Start()
	{
		Cam = GameObject.Find("主摄像机").GetComponent<Camera>();
	}

	private void OnMouseEnter()
	{
		if (Cam == null)
		{
			Cam = GameObject.Find("主摄像机").GetComponent<Camera>();
		}
		pidor = Object.Instantiate(okno, new Vector3(Cam.ScreenToWorldPoint(Input.mousePosition).x, Cam.ScreenToWorldPoint(Input.mousePosition).y, -9.6f), new Quaternion(0f, 0f, 0f, 0f));
		pidor.transform.Find("Text").GetComponent<TextMesh>().text = "";
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.data[15] > 7)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text = "Constitutional majority: \n";
				if (GlobalScript.inst.gameState.is_konst_max)
				{
					pidor.transform.Find("Text").GetComponent<TextMesh>().text += "<color=red>Yes</color>";
				}
				else
				{
					pidor.transform.Find("Text").GetComponent<TextMesh>().text += "<color=yellow>No</color>";
				}
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += "\nLeading: ";
				if (GlobalScript.inst.gameState.data[56] == 1)
				{
					pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Our alliance\n";
				}
				else
				{
					pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Opposition\n";
				}
				float num = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4] + GlobalScript.inst.gameState.data[106];
				int num2 = 0;
				for (int i = 0; i < GlobalScript.inst.gameState.is_party_enabled.Length; i++)
				{
					if (GlobalScript.inst.gameState.is_party_enabled[i])
					{
						if (i == 3)
						{
							pidor.transform.Find("Text").GetComponent<TextMesh>().text += "\n";
						}
						num2 = (int)((float)GlobalScript.inst.gameState.party_number[i] / num * 100f);
						TextMesh component = pidor.transform.Find("Text").GetComponent<TextMesh>();
						component.text = component.text + GlobalScript.inst.gameState.party_name[i + 5] + ": ";
						TextMesh component2 = pidor.transform.Find("Text").GetComponent<TextMesh>();
						component2.text = component2.text + "<color=yellow>" + num2 + "%; </color>";
					}
				}
				num2 = ((GlobalScript.inst.gameState.data[106] > 0) ? ((int)((float)GlobalScript.inst.gameState.data[106] / num * 100f)) : 0);
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Satisfied: ";
				TextMesh component3 = pidor.transform.Find("Text").GetComponent<TextMesh>();
				component3.text = component3.text + "<color=yellow>" + num2 + "%; </color>";
				return;
			}
			float num3 = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4] + GlobalScript.inst.gameState.data[106];
			int num4 = 0;
			for (int j = 0; j < GlobalScript.inst.gameState.is_party_enabled.Length; j++)
			{
				if (GlobalScript.inst.gameState.is_party_enabled[j])
				{
					if (j == 3)
					{
						pidor.transform.Find("Text").GetComponent<TextMesh>().text += "\n";
					}
					num4 = (int)((float)GlobalScript.inst.gameState.party_number[j] / num3 * 100f);
					TextMesh component4 = pidor.transform.Find("Text").GetComponent<TextMesh>();
					component4.text = component4.text + GlobalScript.inst.gameState.party_name[j] + ": ";
					TextMesh component5 = pidor.transform.Find("Text").GetComponent<TextMesh>();
					component5.text = component5.text + "<color=yellow>" + num4 + "%; </color>";
				}
			}
			num4 = ((GlobalScript.inst.gameState.data[106] > 0) ? ((int)((float)GlobalScript.inst.gameState.data[106] / num3 * 100f)) : 0);
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Satisfied: ";
			TextMesh component6 = pidor.transform.Find("Text").GetComponent<TextMesh>();
			component6.text = component6.text + "<color=yellow>" + num4 + "%; </color>";
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += "\n\nLeading: ";
			if (GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[4])
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Satisfied";
			}
			else if (GlobalScript.inst.gameState.data[56] == 0)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[0];
			}
			else if (GlobalScript.inst.gameState.data[56] == 1)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[1];
			}
			else if (GlobalScript.inst.gameState.data[56] == 2)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[2];
			}
			else if (GlobalScript.inst.gameState.data[56] == 3)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[3];
			}
			else if (GlobalScript.inst.gameState.data[56] == 4)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[4];
			}
			return;
		}
		float num5 = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4] + GlobalScript.inst.gameState.data[106];
		int num6 = 0;
		if (GlobalScript.inst.gameState.data[15] > 7)
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text = "Конституционное большинство: \n";
			if (GlobalScript.inst.gameState.is_konst_max)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += "<color=red>Да</color>";
			}
			else
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += "<color=yellow>Нет</color>";
			}
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += "\nЛидирует: ";
			if (GlobalScript.inst.gameState.data[56] == 1)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Наш союз\n";
			}
			else
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Оппозиция\n";
			}
			for (int k = 0; k < GlobalScript.inst.gameState.is_party_enabled.Length; k++)
			{
				if (GlobalScript.inst.gameState.is_party_enabled[k])
				{
					if (k == 3)
					{
						pidor.transform.Find("Text").GetComponent<TextMesh>().text += "\n";
					}
					num6 = (int)((float)GlobalScript.inst.gameState.party_number[k] / num5 * 100f);
					TextMesh component7 = pidor.transform.Find("Text").GetComponent<TextMesh>();
					component7.text = component7.text + GlobalScript.inst.gameState.party_name[k + 5] + ": ";
					TextMesh component8 = pidor.transform.Find("Text").GetComponent<TextMesh>();
					component8.text = component8.text + "<color=yellow>" + num6 + "%; </color>";
				}
			}
			num6 = ((GlobalScript.inst.gameState.data[106] > 0) ? ((int)((float)GlobalScript.inst.gameState.data[106] / num5 * 100f)) : 0);
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Удовлетворённые: ";
			TextMesh component9 = pidor.transform.Find("Text").GetComponent<TextMesh>();
			component9.text = component9.text + "<color=yellow>" + num6 + "%; </color>";
			return;
		}
		for (int l = 0; l < GlobalScript.inst.gameState.is_party_enabled.Length; l++)
		{
			if (GlobalScript.inst.gameState.is_party_enabled[l])
			{
				if (l == 3)
				{
					pidor.transform.Find("Text").GetComponent<TextMesh>().text += "\n";
				}
				num6 = (int)((float)GlobalScript.inst.gameState.party_number[l] / num5 * 100f);
				TextMesh component10 = pidor.transform.Find("Text").GetComponent<TextMesh>();
				component10.text = component10.text + GlobalScript.inst.gameState.party_name[l] + ": ";
				TextMesh component11 = pidor.transform.Find("Text").GetComponent<TextMesh>();
				component11.text = component11.text + "<color=yellow>" + num6 + "%; </color>";
			}
		}
		num6 = ((GlobalScript.inst.gameState.data[106] > 0) ? ((int)((float)GlobalScript.inst.gameState.data[106] / num5 * 100f)) : 0);
		pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Удовлетворённые: ";
		TextMesh component12 = pidor.transform.Find("Text").GetComponent<TextMesh>();
		component12.text = component12.text + "<color=yellow>" + num6 + "%; </color>";
		pidor.transform.Find("Text").GetComponent<TextMesh>().text += "\n\nЛидирует: ";
		if (GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.data[106] >= GlobalScript.inst.gameState.party_number[4])
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += "Удовлетворённые";
		}
		else if (GlobalScript.inst.gameState.data[56] == 0)
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[0];
		}
		else if (GlobalScript.inst.gameState.data[56] == 1)
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[1];
		}
		else if (GlobalScript.inst.gameState.data[56] == 2)
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[2];
		}
		else if (GlobalScript.inst.gameState.data[56] == 3)
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[3];
		}
		else if (GlobalScript.inst.gameState.data[56] == 4)
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text += GlobalScript.inst.gameState.party_name[4];
		}
	}

	private void OnMouseExit()
	{
		Object.Destroy(pidor);
	}
}
