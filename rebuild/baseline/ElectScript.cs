using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectScript : MonoBehaviour
{
	private GlobalScript global1;

	public Sprite on;

	public Sprite off;

	public TextMesh text_part;

	public bool is_alliance;

	public bool military;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (!is_alliance)
		{
			Repaint();
		}
		else
		{
			Reapint_alliance();
		}
	}

	private void OnMouseDown()
	{
		if (is_alliance)
		{
			if (GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].okb && GlobalScript.inst.gameState.event_done[60] && military)
			{
				GlobalScript.inst.gameState.number_event = 60;
				SceneManager.LoadScene("Event");
			}
			else if (!GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].isASEAN && !GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].isOVD && GlobalScript.inst.gameState.event_done[59] && !military)
			{
				GlobalScript.inst.gameState.number_event = 59;
				SceneManager.LoadScene("Event");
			}
		}
		else if (!GlobalScript.inst.gameState.is_elect && GlobalScript.inst.gameState.data[15] > 7)
		{
			GlobalScript.inst.gameState.is_elect = true;
			Repaint();
			GlobalScript.inst.gameState.data[8] -= 10;
			GlobalScript.inst.gameState.number_event = 1;
			GlobalScript.inst.gameState.data[125] = 1;
			SceneManager.LoadScene("Event");
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	private void OnMouseExit()
	{
		if (!GlobalScript.inst.gameState.is_elect && GlobalScript.inst.gameState.data[15] > 7 && !is_alliance)
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
		else if ((!GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].isASEAN && !GlobalScript.inst.gameState.allcountries[1].isOVD && GlobalScript.inst.gameState.event_done[59] && !military) || (GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].okb && GlobalScript.inst.gameState.event_done[60] && military))
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}

	private void Reapint_alliance()
	{
		if ((!GlobalScript.inst.gameState.allcountries[1].isSEV && !GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].isASEAN && !GlobalScript.inst.gameState.allcountries[1].isSEATO && !GlobalScript.inst.gameState.allcountries[1].isOVD && GlobalScript.inst.gameState.event_done[59] && !military) || (GlobalScript.inst.gameState.allcountries[1].econ && !GlobalScript.inst.gameState.allcountries[1].okb && GlobalScript.inst.gameState.event_done[60] && military))
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
	}

	private void Repaint()
	{
		if (GlobalScript.inst.gameState.is_elect || GlobalScript.inst.gameState.data[15] <= 7)
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (GlobalScript.inst.gameState.data[15] > 7)
			{
				text_part.text = "全国人大党团";
			}
			else
			{
				text_part.text = "中共派系";
			}
		}
		else if (GlobalScript.inst.gameState.data[15] > 7)
		{
			text_part.text = "Партийный состав ВСНП";
		}
		else
		{
			text_part.text = "Фракции Коммунистической Партии";
		}
	}
}
