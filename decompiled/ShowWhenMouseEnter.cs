using UnityEngine;

public class ShowWhenMouseEnter : MonoBehaviour
{
	public GameObject obj;

	private SpriteRenderer rend;

	public Politic_Manager manager;

	private Politic_Script parent;

	private Material mat;

	public string ru;

	public string en;

	private void Awake()
	{
		parent = base.transform.parent.GetComponent<Politic_Script>();
		rend = GetComponent<SpriteRenderer>();
		mat = rend.material;
		if (PlayerPrefs.GetInt("language") == 0)
		{
			obj.transform.Find("Text").GetComponent<TextMesh>().text = en.Replace('|', '\n');
		}
		else
		{
			obj.transform.Find("Text").GetComponent<TextMesh>().text = ru.Replace('|', '\n');
		}
	}

	private void OnMouseEnter()
	{
		parent.ToDisp();
		obj.SetActive(value: true);
		rend.color = new Color(1f, 1f, 1f, 1f);
		mat.SetFloat("_M", 1f);
	}

	private void OnMouseExit()
	{
		obj.SetActive(value: false);
		parent.RepaintShkal();
	}
}
