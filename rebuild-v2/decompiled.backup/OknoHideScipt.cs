using UnityEngine;

public class OknoHideScipt : MonoBehaviour
{
	public Sprite on;

	public Sprite off;

	public MapChangesScript map1;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Object.Destroy(GameObject.Find("Okoshko(Clone)"));
			OnMouseDown();
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off;
	}

	private void OnMouseDown()
	{
		map1.ShowHideOcno(active: false);
		GetComponent<SpriteRenderer>().sprite = off;
	}
}
