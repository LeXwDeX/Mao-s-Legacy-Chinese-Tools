using UnityEngine;

public class SpeedScript : MonoBehaviour
{
	public Sprite on;

	public Sprite off;

	public int this_number;

	private GlobalScript global1;

	public SpeedScript[] other;

	private EvetnnashScript goto_economy;

	private int save_speed;

	public bool minus;

	public bool plus;

	private MapChangesScript map1;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		goto_economy = GameObject.Find("按钮（2）").GetComponent<EvetnnashScript>();
		map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		Repaint();
	}

	public void adad(int adashka)
	{
		this_number = adashka;
		OnMouseDown();
		this_number = 0;
	}

	public void Probel()
	{
		if (this_number == 0)
		{
			if (global1.speed != 0)
			{
				save_speed = global1.speed;
				global1.speed = 0;
			}
			else if (save_speed != 0 && GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 0)
			{
				global1.speed = save_speed;
			}
			else if (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 0)
			{
				global1.speed = 4;
			}
			Repaint();
			other[0].Repaint();
			other[1].Repaint();
			other[2].Repaint();
		}
	}

	public void FirstSpeed()
	{
		if (this_number != 0 && (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 0 || GlobalScript.inst.gameState.data[36] + (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36]) >= 0))
		{
			global1.speed = this_number;
			Repaint();
			other[0].Repaint();
			other[1].Repaint();
			other[2].Repaint();
		}
		else if (this_number == 0 && global1.speed != 0)
		{
			save_speed = global1.speed;
			global1.speed = this_number;
			Repaint();
			other[0].Repaint();
			other[1].Repaint();
			other[2].Repaint();
		}
		else if (this_number == 0 && global1.speed == 0 && (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 0 || GlobalScript.inst.gameState.data[36] + (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36]) >= 0))
		{
			if (save_speed != 0)
			{
				global1.speed = save_speed;
			}
			else
			{
				global1.speed = 4;
			}
			Repaint();
			other[0].Repaint();
			other[1].Repaint();
			other[2].Repaint();
		}
		else
		{
			GlobalScript.inst.gameState.data[8] += GlobalScript.inst.gameState.data[36];
			GlobalScript.inst.gameState.data[36] = 0;
			if (GlobalScript.inst.gameState.data[8] < 0)
			{
				global1.speed = 0;
				goto_economy.OnMouseDown();
			}
		}
	}

	public void Repaint()
	{
		if (this_number == 0)
		{
			if (global1.speed != 0)
			{
				GetComponent<SpriteRenderer>().sprite = off;
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = on;
			}
		}
		else if (this_number <= global1.speed)
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}

	public void OnMouseDown()
	{
		if (!map1.okno.active && !minus && !plus)
		{
			if (this_number != 0 && (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 0 || GlobalScript.inst.gameState.data[36] + (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36]) >= 0))
			{
				global1.speed = this_number;
				Repaint();
				other[0].Repaint();
				other[1].Repaint();
				other[2].Repaint();
			}
			else if (this_number == 0 && global1.speed != 0)
			{
				save_speed = global1.speed;
				global1.speed = this_number;
				Repaint();
				other[0].Repaint();
				other[1].Repaint();
				other[2].Repaint();
			}
			else if (this_number == 0 && global1.speed == 0 && (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 0 || GlobalScript.inst.gameState.data[36] + (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36]) >= 0))
			{
				if (save_speed != 0)
				{
					global1.speed = save_speed;
				}
				else
				{
					global1.speed = 4;
				}
				Repaint();
				other[0].Repaint();
				other[1].Repaint();
				other[2].Repaint();
			}
			else
			{
				GlobalScript.inst.gameState.data[8] += GlobalScript.inst.gameState.data[36];
				GlobalScript.inst.gameState.data[36] = 0;
				if (GlobalScript.inst.gameState.data[8] < 0)
				{
					global1.speed = 0;
					goto_economy.OnMouseDown();
				}
			}
		}
		else if (!map1.okno.active && minus)
		{
			if (global1.speed > 4)
			{
				global1.speed -= 6;
				other[0].Repaint();
				other[1].Repaint();
				other[2].Repaint();
			}
			else if (global1.speed <= 4)
			{
				global1.speed = 0;
				other[0].Repaint();
				other[1].Repaint();
				other[2].Repaint();
			}
		}
		else if (!map1.okno.active && plus && (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36] >= 0 || GlobalScript.inst.gameState.data[36] + (GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36]) >= 0))
		{
			if (global1.speed < 16 && global1.speed >= 4)
			{
				global1.speed += 6;
				other[0].Repaint();
				other[1].Repaint();
				other[2].Repaint();
			}
			else if (global1.speed < 4)
			{
				global1.speed = 4;
				other[0].Repaint();
				other[1].Repaint();
				other[2].Repaint();
			}
		}
	}

	private void OnMouseEnter()
	{
		if (!map1.okno.active)
		{
			if (GetComponent<SpriteRenderer>().sprite == on)
			{
				GetComponent<SpriteRenderer>().sprite = off;
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = on;
			}
		}
	}

	private void OnMouseExit()
	{
		if (!map1.okno.active)
		{
			Repaint();
		}
	}
}
