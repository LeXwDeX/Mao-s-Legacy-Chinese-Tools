using UnityEngine;

public class PlayOnTouch : MonoBehaviour
{
	private Total total1;

	public int ontocuh;

	public int onenter;

	public int onexit;

	public bool needtouch;

	public bool needenter;

	public bool needexit;

	private void OnMouseDown()
	{
		if (!needtouch)
		{
			return;
		}
		if (total1 == null)
		{
			total1 = GameObject.Find("Global(Clone)").transform.Find("AudioSource").GetComponent<Total>();
			if (total1 == null)
			{
				return;
			}
		}
		total1.Play(ontocuh);
	}

	private void OnMouseEnter()
	{
		if (!needenter)
		{
			return;
		}
		if (total1 == null)
		{
			total1 = GameObject.Find("Global(Clone)").transform.Find("AudioSource").GetComponent<Total>();
			if (total1 == null)
			{
				return;
			}
		}
		total1.Play(onenter);
	}

	private void OnMouseExit()
	{
		if (!needexit)
		{
			return;
		}
		if (total1 == null)
		{
			total1 = GameObject.Find("Global(Clone)").transform.Find("AudioSource").GetComponent<Total>();
			if (total1 == null)
			{
				return;
			}
		}
		total1.Play(onexit);
	}
}
