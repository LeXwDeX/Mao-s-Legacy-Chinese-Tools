using UnityEngine;

public class SwitchEndingScript : MonoBehaviour
{
	public GameObject all_switchers;

	private GameObject[] switcher;

	public int num = -1;

	public Sprite on_1;

	public Sprite off_1;

	private GlobalScript global1;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (GlobalScript.inst.gameState.data[35] > 0 || (num != 0 && !global1.dlc[num]))
		{
			Object.Destroy(base.gameObject);
			return;
		}
		switcher = new GameObject[all_switchers.transform.childCount];
		for (int i = 0; i < switcher.Length; i++)
		{
			switcher[i] = all_switchers.transform.GetChild(i).gameObject;
		}
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on_1;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off_1;
	}

	private void OnMouseDown()
	{
		GameObject[] array = switcher;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		switcher[num].SetActive(value: true);
	}
}
