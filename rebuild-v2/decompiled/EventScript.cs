using UnityEngine;
using UnityEngine.SceneManagement;

public class EventScript : MonoBehaviour
{
	public int this_event = -1;

	public Sprite off;

	public Sprite on;

	public Sprite off2;

	public Sprite on2;

	private GlobalScript global1;

	public SpriteRenderer sp;

	private bool is_down = true;

	public float time = 3200f;

	private MapChangesScript map1;

	private void Awake()
	{
		map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		global1 = GlobalScript.inst;
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on2;
		sp.GetComponent<SpriteRenderer>().sprite = on;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off2;
		sp.GetComponent<SpriteRenderer>().sprite = off;
	}

	public void Reset(int event_number)
	{
		if (global1 == null)
		{
			Awake();
		}
		this_event = event_number;
		sp.color = new Color(1f, 1f, 1f, 1f);
		time = 104f;
		is_down = true;
	}

	public void Reset(int event_number, float time_need)
	{
		if (global1 == null)
		{
			Awake();
		}
		this_event = event_number;
		sp.color = new Color(1f, 1f, 1f, 1f);
		time = time_need;
		is_down = true;
	}

	private void OnMouseDown()
	{
		GlobalScript.inst.gameState.number_event = this_event;
		if (this_event != 60000)
		{
			GlobalScript.inst.gameState.event_done[this_event] = true;
		}
		GlobalScript.inst.gameState.is_progorel = false;
		global1.speed = 0;
		base.gameObject.SetActive(value: false);
		map1.EventRead();
		SceneManager.LoadScene("Event");
	}

	private void Update()
	{
		if (global1.speed != 0)
		{
			time -= Time.deltaTime * (float)global1.speed;
			if (time <= 0.1f)
			{
				GlobalScript.inst.gameState.number_event = this_event;
				GlobalScript.inst.gameState.is_progorel = true;
				global1.speed = 0;
				base.gameObject.SetActive(value: false);
				map1.EventRead();
				GlobalScript.inst.gameState.data[9] -= 20;
				GlobalScript.inst.gameState.data[8] -= 5;
				if (this_event != 60000)
				{
					GlobalScript.inst.gameState.event_done[this_event] = true;
				}
				SceneManager.LoadScene("Event");
			}
		}
		if (is_down && sp.color.a > 0.1f)
		{
			sp.color = new Color(1f, 1f, 1f, sp.color.a - 0.01f);
			if (sp.color.a <= 0.1f)
			{
				is_down = false;
			}
		}
		else if (!is_down && sp.color.a < 1f)
		{
			sp.color = new Color(1f, 1f, 1f, sp.color.a + 0.01f);
			if (sp.color.a >= 1f)
			{
				is_down = true;
			}
		}
	}
}
