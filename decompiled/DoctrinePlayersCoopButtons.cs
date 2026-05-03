using UnityEngine;

public class DoctrinePlayersCoopButtons : MonoBehaviour
{
	public int playerNum = 1;

	public Sprite choosen;

	public Sprite empty;

	public TextMesh player;

	public bool doNotCountFactions;

	public void Repaint()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			player.text = $"Player №{playerNum + 1}";
		}
		else
		{
			player.text = $"Игрок №{playerNum + 1}";
		}
		if (!doNotCountFactions)
		{
			GlobalScript.inst.gameState.factionsPlayerFor[playerNum] = false;
			ChangeSprite();
		}
		else
		{
			GlobalScript.inst.gameState.playerFor[playerNum] = false;
			ChangeSpriteAlter();
		}
	}

	public void OnMouseDown()
	{
		if (!doNotCountFactions)
		{
			if (GlobalScript.inst.gameState.factionsPlayerFor[playerNum])
			{
				GlobalScript.inst.gameState.factionsPlayerFor[playerNum] = false;
			}
			else
			{
				GlobalScript.inst.gameState.factionsPlayerFor[playerNum] = true;
			}
			ChangeSprite();
		}
		else
		{
			if (GlobalScript.inst.gameState.playerFor[playerNum])
			{
				GlobalScript.inst.gameState.playerFor[playerNum] = false;
			}
			else
			{
				GlobalScript.inst.gameState.playerFor[playerNum] = true;
			}
			ChangeSpriteAlter();
		}
	}

	private void ChangeSprite()
	{
		if (GlobalScript.inst.gameState.factionsPlayerFor[playerNum])
		{
			GetComponent<SpriteRenderer>().sprite = choosen;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = empty;
		}
	}

	private void ChangeSpriteAlter()
	{
		if (GlobalScript.inst.gameState.playerFor[playerNum])
		{
			GetComponent<SpriteRenderer>().sprite = choosen;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = empty;
		}
	}
}
