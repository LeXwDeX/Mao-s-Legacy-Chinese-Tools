using UnityEngine;

public class perehodscript : MonoBehaviour
{
	public Sprite nenavel;

	public Sprite navel;

	public float x;

	public float y;

	private void Start()
	{
	}

	private void OnMouseDown()
	{
		GameObject.Find("主摄像机").transform.position = new Vector3(x, y, -10f);
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
