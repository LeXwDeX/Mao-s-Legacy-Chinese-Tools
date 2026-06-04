using UnityEngine;
using UnityEngine.SceneManagement;

public class EvetnnashScript : MonoBehaviour
{
	private MapChangesScript map1;

	public string new_scene = "";

	public Sprite navel;

	public Sprite nenavel;

	private void Awake()
	{
		map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
	}

	public void OnMouseDown()
	{
		map1.EventRead();
		SceneManager.LoadSceneAsync(new_scene);
	}

	private void OnMouseEnter()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = navel;
		}
	}

	private void OnMouseExit()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = nenavel;
		}
	}
}
