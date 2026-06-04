using System;
using System.Collections.Generic;
using KGFocus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FocusesScript : MonoBehaviour
{
	private GlobalScript global1;

	public GameObject start;

	public GameObject size_y;

	public GameObject all_focuses;

	public GameObject[] focuses;

	public int country = 1;

	public GameObject focusPrefab;

	public GameObject scroll_here;

	public bool notFocuses;

	public void Awake()
	{
		global1 = GlobalScript.inst;
		if (!notFocuses)
		{
			CreateFurstFocus();
		}
		else
		{
			CreateFurstOther();
		}
		scroll_here.GetComponent<ScrollScript>().MakeThings(focuses[0].transform.position.y, focuses[focuses.Length - 1].transform.position.y);
	}

	public void CreateFurstOther()
	{
		CreateDecisions();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}

	public void CreateFurstFocus()
	{
		CreateCountryFocuses(GlobalScript.inst.gameState.empires[country].active_tree);
	}

	public void CreateCountryFocuses(string name)
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < FocusManager.all_trees[name].Count; i++)
		{
			FocusTree focusTree = FocusManager.all_trees[name];
			Array.Resize(ref focuses, focuses.Length + focusTree[i].Count);
			for (int j = 0; j < focusTree[i].Count; j++)
			{
				List<Focus> list = focusTree[i];
				Focus foc = list[j];
				focuses[focuses.Length - 1 - j] = UnityEngine.Object.Instantiate(focusPrefab, new Vector3(start.transform.position.x + num2 * (float)j, start.transform.position.y - num * (float)i, -3f), Quaternion.identity);
				focuses[focuses.Length - 1 - j].GetComponent<FocusButtoNScript>().ChangeIcon(focuses.Length - 1 - j, country);
				focuses[focuses.Length - 1 - j].GetComponent<FocusButtoNScript>().ChangeText(j, list);
				focuses[focuses.Length - 1 - j].GetComponent<FocusButtoNScript>().AddArrows(j, list);
				focuses[focuses.Length - 1 - j].GetComponent<FocusButtoNScript>().ChangeCondition(country, foc);
				focuses[focuses.Length - 1 - j].transform.parent = all_focuses.transform;
				if (i == 0 && j == 0)
				{
					num = (focuses[focuses.Length - 1].GetComponent<BoxCollider2D>().bounds.max.y - focuses[focuses.Length - 1].GetComponent<BoxCollider2D>().bounds.min.y) * 1.2f;
					num2 = (focuses[focuses.Length - 1].GetComponent<BoxCollider2D>().bounds.max.x - focuses[focuses.Length - 1].GetComponent<BoxCollider2D>().bounds.min.x) * 1.5f;
				}
			}
		}
	}

	public void CreateDecisions()
	{
		GlobalScript.inst.CreateDecisions();
		float num = 0f;
		float num2 = Mathf.Abs(start.transform.position.x) * 1.8f;
		int num3 = GlobalScript.inst.gameState.decisions.Length;
		Array.Resize(ref focuses, num3);
		for (int i = 0; i < num3; i++)
		{
			if (i != 0)
			{
				num = (focuses[i - 1].GetComponent<BoxCollider2D>().bounds.max.y - focuses[i - 1].GetComponent<BoxCollider2D>().bounds.min.y) * 3f;
			}
			focuses[i] = UnityEngine.Object.Instantiate(focusPrefab, new Vector3(start.transform.position.x + num2, start.transform.position.y - num * (float)i, -4f), Quaternion.identity);
			focuses[i].transform.parent = all_focuses.transform;
		}
		int num4 = num3 - 1;
		int num5 = 0;
		int num6 = 0;
		for (int j = 0; j < num3; j++)
		{
			if (GlobalScript.inst.gameState.completedDecisions[j] && GlobalScript.inst.dlc[GlobalScript.inst.gameState.decisions[j].version])
			{
				num6 = num4;
				num4--;
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeIcon(j);
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeText(GlobalScript.inst.gameState.decisions[j]);
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeCondition();
			}
			else if (GlobalScript.inst.gameState.decisions[j].condition() && GlobalScript.inst.dlc[GlobalScript.inst.gameState.decisions[j].version])
			{
				num6 = num5;
				num5++;
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeIcon(j);
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeText(GlobalScript.inst.gameState.decisions[j]);
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeCondition();
			}
		}
		num6 = num5;
		for (int k = 0; k < num3; k++)
		{
			if (!GlobalScript.inst.gameState.decisions[k].condition() && !GlobalScript.inst.gameState.completedDecisions[k] && GlobalScript.inst.dlc[GlobalScript.inst.gameState.decisions[k].version])
			{
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeIcon(k);
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeText(GlobalScript.inst.gameState.decisions[k]);
				focuses[num6].GetComponent<DecisionButtonScript>().ChangeCondition();
				num6++;
			}
		}
		for (int l = num6; l < num3; l++)
		{
			if (!GlobalScript.inst.dlc[GlobalScript.inst.gameState.decisions[l].version])
			{
				focuses[num6].SetActive(value: false);
				num6++;
			}
		}
	}

	public void Repaint()
	{
		GlobalScript.inst.CreateDecisions();
		for (int i = 0; i < focuses.Length; i++)
		{
			focuses[i].GetComponent<DecisionButtonScript>().ChangeCondition();
		}
	}

	public void Repaint(int country)
	{
		this.country = country;
		for (int i = 0; i < focuses.Length; i++)
		{
			UnityEngine.Object.Destroy(focuses[i]);
		}
		focuses = new GameObject[0];
		CreateFurstFocus();
		scroll_here.GetComponent<ScrollScript>().MakeThings(focuses[0].transform.position.y, focuses[focuses.Length - 1].transform.position.y);
	}
}
