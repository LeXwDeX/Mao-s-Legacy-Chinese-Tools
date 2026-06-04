using UnityEngine;

public class CascadScrupt : MonoBehaviour
{
	public Sprite on;

	public Sprite off;

	private bool turn_on;

	public bool menu = true;

	public GameObject Cascad;

	public GameObject PostExit;

	public GlobalScript global1;

	public SpeedScript[] other;

	private void Awake()
	{
		global1 = GlobalScript.inst;
	}

	private void OnMouseDown()
	{
		if (!turn_on)
		{
			global1.speed = 0;
			other[0].Repaint();
			other[1].Repaint();
			other[2].Repaint();
			other[3].Repaint();
			Cascad.SetActive(value: true);
		}
		else
		{
			Cascad.SetActive(value: false);
		}
		if (menu)
		{
			if (GlobalScript.inst.gameState.data[21] >= 1986 && !turn_on)
			{
				PostExit.SetActive(value: true);
			}
			else if (GlobalScript.inst.gameState.data[21] >= 1986 && turn_on)
			{
				PostExit.SetActive(value: false);
			}
		}
		turn_on = !turn_on;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnMouseDown();
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off;
	}
}
