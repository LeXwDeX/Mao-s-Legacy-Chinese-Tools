using UnityEngine;

public class ChildScript : MonoBehaviour
{
	public TextMesh text1;

	public Sprite on;

	public Sprite off;

	public int this_number;

	public GlobalScript global1;

	public ChildScript a1;

	public ChildScript a2;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		ChangeColour();
	}

	private void OnMouseDown()
	{
		GlobalScript.inst.gameState.data[3] -= 50 * (GlobalScript.inst.gameState.data[105] - this_number);
		GlobalScript.inst.gameState.data[105] = this_number;
		GlobalScript.inst.gameState.data[8] -= 5 * (4 - this_number);
		ChangeColour();
		a1.ChangeColour();
		a2.ChangeColour();
	}

	public void ChangeColour()
	{
		if (GlobalScript.inst.gameState.data[105] == this_number)
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}

	private void ChangeText()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.data[105] == 0)
			{
				text1.text = "Now: One-child policy";
			}
			else if (GlobalScript.inst.gameState.data[105] == 1)
			{
				text1.text = "Now: Two-child policy";
			}
			else if (GlobalScript.inst.gameState.data[105] == 2)
			{
				text1.text = "Now: Unlimited-child policy";
			}
		}
		else if (GlobalScript.inst.gameState.data[105] == 0)
		{
			text1.text = "Сейчас: Политика одного ребёнка";
		}
		else if (GlobalScript.inst.gameState.data[105] == 1)
		{
			text1.text = "Сейчас: Политика двух детей";
		}
		else if (GlobalScript.inst.gameState.data[105] == 2)
		{
			text1.text = "Сейчас: Нет ограничений на детей";
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	private void OnMouseExit()
	{
		if (GlobalScript.inst.gameState.data[105] != this_number)
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}
}
