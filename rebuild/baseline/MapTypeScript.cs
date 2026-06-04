using UnityEngine;

public class MapTypeScript : MonoBehaviour
{
	public MapTypeScript oth1;

	public MapTypeScript oth2;

	public MapTypeScript oth3;

	public Sprite on;

	public Sprite off;

	public int this_type;

	private MapChangesScript map1;

	private SpriteRenderer sp;

	private GlobalScript global1;

	private void Awake()
	{
		map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		sp = GetComponent<SpriteRenderer>();
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		Repaint();
	}

	private void OnMouseDown()
	{
		global1.map_type = this_type;
		map1.UpdateMap();
		oth1.Repaint();
		oth2.Repaint();
		oth3.Repaint();
	}

	public void Repaint()
	{
		if (global1.map_type == this_type && sp.sprite != on)
		{
			sp.sprite = on;
		}
		else if (global1.map_type != this_type && sp.sprite != off)
		{
			sp.sprite = off;
		}
	}

	private void OnMouseEnter()
	{
		sp.sprite = on;
	}

	private void OnMouseExit()
	{
		Repaint();
	}
}
