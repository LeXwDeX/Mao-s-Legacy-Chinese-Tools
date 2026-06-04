using UnityEngine;

public class DiffScript : MonoBehaviour
{
	public bool is_right;

	public TextMesh text;

	public TextMesh uch;

	private GlobalScript global1;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		Textotext();
	}

	private void Textotext()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.diff == 0)
			{
				text.text = "Sandbox";
				uch.text = "Achievements: X";
			}
			else if (GlobalScript.inst.gameState.diff == 1)
			{
				text.text = "Easy";
				uch.text = "Achievements: X";
			}
			else if (GlobalScript.inst.gameState.diff == 2)
			{
				text.text = "Normal";
				uch.text = "Achievements: V";
			}
			else if (GlobalScript.inst.gameState.diff == 3)
			{
				text.text = "Hard";
				uch.text = "Achievements: V";
			}
			else if (GlobalScript.inst.gameState.diff == 4)
			{
				text.text = "Cultrevoultion";
				uch.text = "Achievements: V";
			}
		}
		else if (GlobalScript.inst.gameState.diff == 0)
		{
			text.text = "Песочница";
			uch.text = "Достижения: X";
		}
		else if (GlobalScript.inst.gameState.diff == 1)
		{
			text.text = "Лёгкий";
			uch.text = "Достижения: X";
		}
		else if (GlobalScript.inst.gameState.diff == 2)
		{
			text.text = "Стандарт";
			uch.text = "Достижения: V";
		}
		else if (GlobalScript.inst.gameState.diff == 3)
		{
			text.text = "Тяжёлый";
			uch.text = "Достижения: V";
		}
		else if (GlobalScript.inst.gameState.diff == 4)
		{
			text.text = "Культреволюция";
			uch.text = "Достижения: V";
		}
	}

	private void OnMouseDown()
	{
		if (is_right)
		{
			if (GlobalScript.inst.gameState.diff < 4)
			{
				GlobalScript.inst.gameState.diff++;
			}
			else
			{
				GlobalScript.inst.gameState.diff = 0;
			}
		}
		else if (GlobalScript.inst.gameState.diff > 0)
		{
			GlobalScript.inst.gameState.diff--;
		}
		else
		{
			GlobalScript.inst.gameState.diff = 4;
		}
		PlayerPrefs.SetInt("our_diff_in", GlobalScript.inst.gameState.diff);
		Textotext();
	}
}
