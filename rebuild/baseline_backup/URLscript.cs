using UnityEngine;

public class URLscript : MonoBehaviour
{
	public string url;

	public bool needSprite;

	public Sprite started;

	public Sprite downed;

	private void OnMouseDown()
	{
		Application.OpenURL(url);
	}

	private void OnMouseEnter()
	{
		if (needSprite)
		{
			GetComponent<SpriteRenderer>().sprite = downed;
		}
	}

	private void OnMouseExit()
	{
		if (needSprite)
		{
			GetComponent<SpriteRenderer>().sprite = started;
		}
	}
}
