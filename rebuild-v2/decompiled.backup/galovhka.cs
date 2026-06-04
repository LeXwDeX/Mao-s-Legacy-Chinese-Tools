using UnityEngine;

public class galovhka : MonoBehaviour
{
	public doneventscript Done1;

	public Sprite navel;

	public Sprite nenavel;

	public int this_num;

	public SpriteRenderer[] otveti = new SpriteRenderer[6];

	private void OnMouseDown()
	{
		if (this_num == Done1.this_otvet)
		{
			return;
		}
		Done1.this_otvet = this_num;
		for (int i = 0; i < Done1.kolvo_variant; i++)
		{
			if (otveti[i] != null)
			{
				otveti[i].sprite = nenavel;
			}
		}
		GetComponent<SpriteRenderer>().sprite = navel;
	}

	private void OnMouseEnter()
	{
		if (this_num != Done1.this_otvet)
		{
			GetComponent<SpriteRenderer>().sprite = navel;
		}
	}

	private void OnMouseExit()
	{
		if (this_num != Done1.this_otvet)
		{
			GetComponent<SpriteRenderer>().sprite = nenavel;
		}
	}
}
