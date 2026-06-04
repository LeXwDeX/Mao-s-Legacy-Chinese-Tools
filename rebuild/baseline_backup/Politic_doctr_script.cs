using UnityEngine;
using UnityEngine.SceneManagement;

public class Politic_doctr_script : MonoBehaviour
{
	private GlobalScript global1;

	public int doctr;

	public bool party_line;

	public bool gosstroy;

	private string text;

	public int hooray;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		text = GlobalScript.inst.gameState.doctr[GlobalScript.inst.gameState.data[doctr]].Replace("|", "\n");
		if (!party_line)
		{
			GetComponent<TextMesh>().text = text;
		}
		else
		{
			GetComponent<TextMesh>().text = GlobalScript.inst.gameState.doctr[GlobalScript.inst.gameState.data[doctr]];
			TextMesh component = GetComponent<TextMesh>();
			component.text = component.text + "\n" + GlobalScript.inst.gameState.doctr[GlobalScript.inst.gameState.data[doctr + 2]];
		}
		ChineseStateSystem();
	}

	private void ChineseStateSystem()
	{
		hooray = GlobalScript.inst.gameState.data[16] - 9 + (GlobalScript.inst.gameState.data[15] - 5) + (GlobalScript.inst.gameState.data[17] - 15) + (GlobalScript.inst.gameState.data[50] - 23) + (GlobalScript.inst.gameState.data[18] + GlobalScript.inst.gameState.data[51] - 48) / 2;
		if (GlobalScript.inst.gameState.data[16] == 11)
		{
			hooray++;
		}
		else if (GlobalScript.inst.gameState.data[16] == 10)
		{
			hooray += 2;
		}
		if ((hooray <= 6 || (hooray <= 7 && GlobalScript.inst.gameState.data[16] <= 11) || (hooray <= 9 && GlobalScript.inst.gameState.modifies[40].active)) && GlobalScript.inst.gameState.data[17] < 18)
		{
			GlobalScript.inst.gameState.data[14] = 0;
		}
		else if (hooray <= 9 && GlobalScript.inst.gameState.data[16] <= 11)
		{
			GlobalScript.inst.gameState.data[14] = 1;
		}
		else if (hooray <= 11)
		{
			GlobalScript.inst.gameState.data[14] = 2;
		}
		else if (hooray <= 15 && GlobalScript.inst.gameState.data[16] > 11)
		{
			GlobalScript.inst.gameState.data[14] = 3;
		}
		else if (hooray <= 20 && GlobalScript.inst.gameState.data[16] > 11)
		{
			GlobalScript.inst.gameState.data[14] = 4;
		}
		else if (GlobalScript.inst.gameState.data[16] > 11)
		{
			GlobalScript.inst.gameState.data[14] = 5;
		}
		else
		{
			GlobalScript.inst.gameState.data[14] = 2;
		}
		if (GlobalScript.inst.gameState.data[15] <= 6 && GlobalScript.inst.gameState.data[16] >= 14 && GlobalScript.inst.gameState.data[17] <= 16 && GlobalScript.inst.gameState.data[18] <= 20 && (GlobalScript.inst.gameState.data[50] <= 24 || GlobalScript.inst.gameState.data[50] >= 29) && (GlobalScript.inst.gameState.data[51] <= 31 || GlobalScript.inst.gameState.data[51] >= 33))
		{
			GlobalScript.inst.gameState.data[14] = 0;
		}
		GlobalScript.inst.gameState.allcountries[1].SubGosstroy = GlobalScript.inst.gameState.ChineseSubGosstroy();
	}

	private void Update()
	{
		text = GlobalScript.inst.gameState.doctr[GlobalScript.inst.gameState.data[doctr]].Replace("|", "\n");
		if (!party_line)
		{
			GetComponent<TextMesh>().text = text;
			return;
		}
		GetComponent<TextMesh>().text = GlobalScript.inst.gameState.doctr[GlobalScript.inst.gameState.data[doctr]];
		TextMesh component = GetComponent<TextMesh>();
		component.text = component.text + "\n" + GlobalScript.inst.gameState.doctr[GlobalScript.inst.gameState.data[doctr + 2]];
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}
}
