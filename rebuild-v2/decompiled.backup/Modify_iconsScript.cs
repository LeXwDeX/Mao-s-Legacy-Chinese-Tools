using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Modify_iconsScript : MonoBehaviour
{
	private GlobalScript global1;

	public GameObject start;

	public GameObject size_y;

	public GameObject all_focuses;

	public GameObject[] focuses;

	public GameObject focusPrefab;

	public GameObject scroll_here;

	public Sprite vkl;

	public Sprite vykl;

	public bool conditionOn = true;

	private void CreateModifies()
	{
		float num = 0f;
		float num2 = Mathf.Abs(start.transform.position.x) * 0.415f;
		List<int> list = new List<int>();
		for (int i = 0; i < GlobalScript.inst.old_modify_texts.Length; i++)
		{
			if (conditionOn)
			{
				if (GlobalScript.inst.gameState.modifies[i].active)
				{
					list.Add(i);
				}
			}
			else if (!GlobalScript.inst.gameState.modifies[i].active)
			{
				list.Add(i);
			}
		}
		Array.Resize(ref focuses, list.Count);
		for (int j = 0; j < list.Count; j++)
		{
			if (j % 3 == 0 && j != 0)
			{
				num = (focuses[j - 1].GetComponent<BoxCollider2D>().bounds.max.y - focuses[j - 1].GetComponent<BoxCollider2D>().bounds.min.y) * 1.1f * (float)(j / 3);
			}
			focuses[j] = UnityEngine.Object.Instantiate(focusPrefab, new Vector3((j % 3 != 0) ? (focuses[j - 1].transform.position.x + num2) : start.transform.position.x, start.transform.position.y - num, -1f), Quaternion.identity);
			focuses[j].transform.parent = all_focuses.transform;
			focuses[j].GetComponent<ModifyButtonScript>().ChangeIcon(list[j], GlobalScript.inst.gameState.modifies[list[j]].active);
			focuses[j].GetComponent<ModifyButtonScript>().ChangeText(list[j], GlobalScript.inst.gameState.modifies[list[j]].active);
		}
	}

	private void DeleteAll()
	{
		for (int i = 0; i < all_focuses.transform.childCount; i++)
		{
			UnityEngine.Object.Destroy(all_focuses.transform.GetChild(i).gameObject);
		}
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
		CreateModifies();
		scroll_here.GetComponent<ScrollScript>().MakeThings(focuses[0].transform.position.y, focuses[focuses.Length - 1].transform.position.y);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}

	private void OnMouseDown()
	{
		if (conditionOn)
		{
			GetComponent<SpriteRenderer>().sprite = vykl;
			conditionOn = false;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = vkl;
			conditionOn = true;
		}
		DeleteAll();
		CreateModifies();
		scroll_here.GetComponent<ScrollScript>().MakeThings(focuses[0].transform.position.y, focuses[focuses.Length - 1].transform.position.y);
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().color = new Color(0.57f, 0.57f, 0.57f);
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
	}
}
