using UnityEngine;

public class Exitscript : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnMouseDown()
	{
		Application.Quit();
	}

	private void OnMouseEnter()
	{
		GetComponent<TextMesh>().color = Color.gray;
	}

	private void OnMouseExit()
	{
		GetComponent<TextMesh>().color = Color.black;
	}
}
