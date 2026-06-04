using UnityEngine;

public class EnterColorScript : MonoBehaviour
{
	public Color OnEnter;

	private SpriteRenderer sp;

	private void Start()
	{
		sp = GetComponent<SpriteRenderer>();
	}

	private void OnMouseEnter()
	{
		sp.color = OnEnter;
	}

	private void OnMouseExit()
	{
		sp.color = Color.white;
	}
}
