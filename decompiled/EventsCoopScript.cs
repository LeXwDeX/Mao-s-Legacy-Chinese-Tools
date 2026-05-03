using UnityEngine;

public class EventsCoopScript : MonoBehaviour
{
	public int playerNum = 1;

	public int variantNum;

	public Sprite choosen;

	public Sprite empty;

	public TextMesh player;

	public doneventscript done1;

	[SerializeField]
	private bool forStartingChoose;

	private void Awake()
	{
		if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			Repaint();
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void Repaint()
	{
		if (playerNum >= GlobalScript.inst.gameState.numOfPlayers)
		{
			base.gameObject.SetActive(value: false);
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			player.text = $"Player №{playerNum + 1}";
		}
		else
		{
			player.text = $"Игрок №{playerNum + 1}";
		}
		if (!forStartingChoose)
		{
			GlobalScript.inst.gameState.eventVariantsPlayerFor[playerNum] = -1;
		}
		else
		{
			GlobalScript.inst.gameState.factionsPlayerMaster[playerNum] = -1;
		}
		ChangeSprite();
	}

	public void OnMouseDown()
	{
		if (!forStartingChoose)
		{
			GlobalScript.inst.gameState.eventVariantsPlayerFor[playerNum] = variantNum;
			done1.RepaintPreRes();
		}
		else
		{
			GlobalScript.inst.gameState.factionsPlayerMaster[variantNum] = playerNum;
		}
		ChangeSprite();
	}

	private void ChangeSprite()
	{
		if ((!forStartingChoose && GlobalScript.inst.gameState.eventVariantsPlayerFor[playerNum] == variantNum) || (forStartingChoose && GlobalScript.inst.gameState.factionsPlayerMaster[variantNum] == playerNum))
		{
			GetComponent<SpriteRenderer>().sprite = choosen;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = empty;
		}
	}

	private void FixedUpdate()
	{
		ChangeSprite();
	}
}
