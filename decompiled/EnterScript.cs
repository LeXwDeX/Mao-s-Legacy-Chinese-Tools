using UnityEngine;

public class EnterScript : MonoBehaviour
{
	public Sprite on;

	public Sprite off;

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off;
	}
}
