using UnityEngine;

public class Politics_Hide_Script : MonoBehaviour
{
	public Politic_Manager manager;

	private void OnMouseDown()
	{
		manager.Politic_Selected(200);
	}

	private void OnMouseEnter()
	{
		manager.politic_to_display_loyality = 200;
		manager.RepaintOnlyShkal();
	}
}
