using UnityEngine;
using UnityEngine.SceneManagement;

public class speechscript : MonoBehaviour
{
	private GlobalScript global1;

	public Sprite on;

	public Sprite off;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		Repaint();
	}

	private void OnMouseDown()
	{
		if (!GlobalScript.inst.gameState.is_speech)
		{
			GlobalScript.inst.gameState.is_speech = true;
			Repaint();
			GlobalScript.inst.gameState.number_event = 1;
			GlobalScript.inst.gameState.event_done[1] = true;
			SceneManager.LoadScene("Event");
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	private void OnMouseExit()
	{
		if (!GlobalScript.inst.gameState.is_speech)
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}

	private void Repaint()
	{
		if (GlobalScript.inst.gameState.is_speech)
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}
}
