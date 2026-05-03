using UnityEngine;

public class ChangeDataButtonScript : MonoBehaviour
{
	[SerializeField]
	private int number;

	[SerializeField]
	private int value;

	[SerializeField]
	private int startTextLine;

	[SerializeField]
	private bool wasChosen;

	[SerializeField]
	private Color32 onEnter;

	[SerializeField]
	private Color32 chosen;

	[SerializeField]
	private ChangeDataButtonScript[] otherButtons;

	private GlobalScript global1;

	private GameState gameState;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		gameState = GlobalScript.inst.gameState;
		SetOkoshkoText();
		if (gameState.data[number] == value)
		{
			wasChosen = true;
			GetComponent<SpriteRenderer>().color = chosen;
		}
	}

	private void SetOkoshkoText()
	{
		GetComponent<OkoshkoScript>().text = (GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.new_texts[startTextLine + value]);
	}

	public void Chose(bool yes)
	{
		if (yes)
		{
			gameState.data[number] = value;
			wasChosen = true;
			GetComponent<SpriteRenderer>().color = chosen;
		}
		else
		{
			wasChosen = false;
			GetComponent<SpriteRenderer>().color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		Chose(yes: true);
		ChangeDataButtonScript[] array = otherButtons;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Chose(yes: false);
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().color = onEnter;
	}

	private void OnMouseExit()
	{
		if (wasChosen)
		{
			GetComponent<SpriteRenderer>().color = chosen;
		}
		else
		{
			GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}
