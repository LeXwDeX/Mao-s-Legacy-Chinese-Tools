using UnityEngine;

public class UI_Diplomacy_Script : MonoBehaviour
{
	public bool is_show;

	public GameObject ToShow;

	private SpriteRenderer sp;

	public Color col;

	private void Awake()
	{
		sp = GetComponent<SpriteRenderer>();
	}

	private void OnMouseExit()
	{
		sp.color = Color.white;
	}

	private void OnMouseEnter()
	{
		sp.color = col;
	}

	private void OnMouseDown()
	{
		sp.color = Color.white;
		ToShow.SetActive(is_show);
	}
}
