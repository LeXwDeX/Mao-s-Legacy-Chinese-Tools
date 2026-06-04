using UnityEngine;

public class VoiceChangeScript : MonoBehaviour
{
	public Sprite on;

	public Sprite off;

	public int i;

	public int albumNum = -1;

	public bool random;

	public bool cilicng;

	private GlobalScript global1;

	private void OnMouseEnter()
	{
		if (!cilicng)
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
	}

	private void OnMouseExit()
	{
		if (!cilicng)
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (cilicng && global1.get_to_cycle)
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
	}

	private void OnMouseDown()
	{
		if (albumNum >= 0)
		{
			global1.albumNum = albumNum;
			global1.MusicReset();
		}
		else if (random)
		{
			global1.albumNum = -1;
			global1.MusicReset();
		}
		else if (cilicng)
		{
			global1.get_to_cycle = !global1.get_to_cycle;
			if (global1.get_to_cycle)
			{
				GetComponent<SpriteRenderer>().sprite = on;
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = off;
			}
		}
		else if (global1.now_playing != i)
		{
			global1.zadan_music = true;
			global1.zadan_playing = i;
			global1.MusicReset();
		}
	}
}
