using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoopStartScript : MonoBehaviour
{
	[SerializeField]
	private Sprite choosen;

	[SerializeField]
	private Sprite empty;

	[SerializeField]
	private TextMesh player;

	[SerializeField]
	private string new_scene;

	private void Awake()
	{
		Repaint();
	}

	private bool TrueCheck()
	{
		if (GlobalScript.inst.gameState.factionsPlayerMaster.Contains(-1))
		{
			return false;
		}
		for (int i = 0; i < GlobalScript.inst.gameState.numOfPlayers; i++)
		{
			if (!GlobalScript.inst.gameState.factionsPlayerMaster.Contains(i))
			{
				return false;
			}
		}
		return true;
	}

	private void Repaint()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (!TrueCheck())
			{
				player.text = "<color=red>未满足启动条件</color>";
			}
			else
			{
				player.text = "<color=green>准备开局！</color>";
			}
		}
		else if (!TrueCheck())
		{
			player.text = "<color=red>Не выполнены условия для старта</color>";
		}
		else
		{
			player.text = "<color=green>Можно начинать!</color>";
		}
	}

	private void OnMouseDown()
	{
		if (TrueCheck())
		{
			SceneManager.LoadScene(new_scene);
		}
	}

	private void FixedUpdate()
	{
		Repaint();
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = choosen;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = empty;
	}
}
