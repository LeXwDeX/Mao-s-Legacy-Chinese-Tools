using UnityEngine;

public class ScienceHappenedScript : MonoBehaviour
{
	public Sprite[] science = new Sprite[10];

	public int this_num = -1;

	public void IsHappened()
	{
		GetComponent<SpriteRenderer>().sprite = science[this_num];
	}
}
