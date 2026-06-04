using UnityEngine;

public class MapChangesScript : MonoBehaviour
{
	private int save_speed;

	public GameObject[] speed = new GameObject[4];

	public GameObject[] buttons = new GameObject[4];

	public GameObject[] event_icons = new GameObject[26];

	public Sprite[] znachki = new Sprite[13];

	public Sprite[] sub_znachki = new Sprite[10];

	public GameObject okno;

	private GlobalScript global1;

	public CountryScript[] cont = new CountryScript[56];

	public GameObject[] parts = new GameObject[5];

	public GameObject[] events = new GameObject[1];

	public bool dont_need;

	public void EventWrite(GameState game1)
	{
		for (int i = 0; i < events.Length; i++)
		{
			if (events[i] != null && game1.Events_active[i])
			{
				events[i].SetActive(value: true);
				events[i].GetComponent<EventScript>().Reset(game1.Events_number[i], game1.Events_time[i]);
				game1.Events_active[i] = false;
			}
		}
	}

	public void EventRead()
	{
		for (int i = 0; i < events.Length; i++)
		{
			if (events[i] != null)
			{
				if (events[i].activeSelf)
				{
					GlobalScript.inst.gameState.Events_time[i] = events[i].GetComponent<EventScript>().time;
					GlobalScript.inst.gameState.Events_number[i] = events[i].GetComponent<EventScript>().this_event;
				}
				GlobalScript.inst.gameState.Events_active[i] = events[i].activeSelf;
			}
		}
	}

	public void ShowParts(GameState game1)
	{
		for (int i = 0; i < parts.Length; i++)
		{
			string text = parts[i].name;
			int num = int.Parse(text.Substring(0, 3));
			int num2 = int.Parse(text.Substring(4));
			if (game1.allcountries[num].parts[num2])
			{
				parts[i].SetActive(value: true);
			}
			else
			{
				parts[i].SetActive(value: false);
			}
		}
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
		UpdateMap();
		ShowParts(global1.gameState);
		if (!dont_need)
		{
			EventWrite(global1.gameState);
		}
	}

	public void ShowHideOcno(bool active)
	{
		if (active)
		{
			if (!okno.active)
			{
				save_speed = global1.speed;
			}
			global1.speed = 0;
			okno.transform.Find("文本（0）").GetComponent<TextMesh>().text = null;
			okno.transform.Find("条件触发（1）").GetComponent<TextMesh>().text = null;
			okno.transform.Find("条件触发（2）").GetComponent<TextMesh>().text = null;
			okno.transform.Find("条件触发（3）").GetComponent<TextMesh>().text = null;
			okno.transform.Find("文本（0）").transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			okno.transform.Find("条件触发（1）").transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			okno.transform.Find("条件触发（2）").transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			okno.transform.Find("条件触发（3）").transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			okno.transform.Find("（1）").GetComponent<TextMesh>().text = null;
			if (dont_need)
			{
				okno.transform.Find("Text_opis_country").GetComponent<TextMesh>().text = null;
			}
		}
		else
		{
			global1.speed = save_speed;
		}
		if (!dont_need)
		{
			for (int i = 0; i < 4; i++)
			{
				speed[i].GetComponent<SpeedScript>().Repaint();
			}
		}
		okno.SetActive(active);
	}

	public void UpdateMap()
	{
		for (int i = 0; i < cont.Length; i++)
		{
			if (cont[i] != null)
			{
				cont[i].Repaint_forTimes();
			}
		}
		ShowParts(global1.gameState);
	}
}
