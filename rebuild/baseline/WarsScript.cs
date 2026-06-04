using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarsScript : MonoBehaviour
{
	private GlobalScript global1;

	public GameObject[] wars_here = new GameObject[5];

	public TextMesh[] names_space = new TextMesh[5];

	public TextMesh[] name_side1 = new TextMesh[5];

	public TextMesh[] name_side2 = new TextMesh[5];

	public SpriteRenderer[] side1 = new SpriteRenderer[5];

	public SpriteRenderer[] side2 = new SpriteRenderer[5];

	public SpriteRenderer[] side3 = new SpriteRenderer[5];

	public SpriteRenderer[] side4 = new SpriteRenderer[5];

	public TextMesh[] influence1 = new TextMesh[5];

	public TextMesh[] influence2 = new TextMesh[5];

	public Sprite USA;

	public Sprite USSR;

	public int[] active_wars = new int[0];

	public GameObject warPrefab;

	public GameObject scroll_here;

	public GameObject startPoint;

	public GameObject allWars;

	public GameObject[] playersButtons = new GameObject[5];

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}

	private int LengthOfWars()
	{
		int num = 0;
		warinwars[] ingamewars = GlobalScript.inst.gameState.ingamewars;
		for (int i = 0; i < ingamewars.Length; i++)
		{
			if (ingamewars[i].is_going)
			{
				num++;
			}
		}
		return num;
	}

	private void CreateWars()
	{
		float num = startPoint.transform.position.y * 0.4f;
		float num2 = Mathf.Abs(startPoint.transform.position.x) * 2.1f;
		int num3 = LengthOfWars();
		Array.Resize(ref wars_here, num3);
		Array.Resize(ref names_space, num3);
		Array.Resize(ref name_side1, num3);
		Array.Resize(ref name_side2, num3);
		Array.Resize(ref side1, num3);
		Array.Resize(ref side2, num3);
		Array.Resize(ref side3, num3);
		Array.Resize(ref side4, num3);
		Array.Resize(ref influence1, num3);
		Array.Resize(ref influence2, num3);
		Array.Resize(ref active_wars, num3);
		for (int i = 0; i < num3; i++)
		{
			if (i != 0)
			{
				wars_here[i] = UnityEngine.Object.Instantiate(warPrefab, new Vector3(startPoint.transform.position.x + num2, wars_here[i - 1].transform.position.y - num, -4f), Quaternion.identity);
			}
			else
			{
				wars_here[i] = UnityEngine.Object.Instantiate(warPrefab, new Vector3(startPoint.transform.position.x + num2, num, -4f), Quaternion.identity);
				num = (wars_here[0].GetComponent<BoxCollider2D>().bounds.max.y - wars_here[0].GetComponent<BoxCollider2D>().bounds.min.y) * 1.3f;
			}
			names_space[i] = wars_here[i].transform.GetChild(0).GetComponent<TextMesh>();
			name_side1[i] = wars_here[i].transform.GetChild(1).GetComponent<TextMesh>();
			name_side2[i] = wars_here[i].transform.GetChild(2).GetComponent<TextMesh>();
			side1[i] = wars_here[i].transform.GetChild(3).GetComponent<SpriteRenderer>();
			side2[i] = wars_here[i].transform.GetChild(4).GetComponent<SpriteRenderer>();
			side3[i] = wars_here[i].transform.GetChild(5).GetComponent<SpriteRenderer>();
			side4[i] = wars_here[i].transform.GetChild(6).GetComponent<SpriteRenderer>();
			influence1[i] = wars_here[i].transform.GetChild(7).GetComponent<TextMesh>();
			influence2[i] = wars_here[i].transform.GetChild(8).GetComponent<TextMesh>();
			wars_here[i].name = i.ToString();
			wars_here[i].transform.parent = allWars.transform;
		}
	}

	private void EstablishWarsChar()
	{
		int num = 0;
		for (int i = 0; i < GlobalScript.inst.gameState.ingamewars.Length; i++)
		{
			if (GlobalScript.inst.gameState.ingamewars[i] != null && GlobalScript.inst.gameState.ingamewars[i].is_going)
			{
				active_wars[num] = i;
				num++;
			}
		}
		for (int j = 0; j < wars_here.Length; j++)
		{
			names_space[j].text = GlobalScript.inst.gameState.ingamewars[active_wars[j]].name_war.Replace('|', '\n');
			name_side1[j].text = GlobalScript.inst.gameState.ingamewars[active_wars[j]].side1.Replace('|', '\n');
			name_side2[j].text = GlobalScript.inst.gameState.ingamewars[active_wars[j]].side2.Replace('|', '\n');
			influence1[j].text = ((float)GlobalScript.inst.gameState.ingamewars[active_wars[j]].infl1 / 10f).ToString();
			influence2[j].text = ((float)GlobalScript.inst.gameState.ingamewars[active_wars[j]].infl2 / 10f).ToString();
			if (GlobalScript.inst.gameState.ingamewars[active_wars[j]].usa_place == 0)
			{
				side1[j].sprite = USA;
				if (GlobalScript.inst.gameState.ingamewars[active_wars[j]].ussr_place == 0)
				{
					side3[j].sprite = USSR;
				}
			}
			else if (GlobalScript.inst.gameState.ingamewars[active_wars[j]].ussr_place == 0)
			{
				side1[j].sprite = USSR;
			}
			if (GlobalScript.inst.gameState.ingamewars[active_wars[j]].usa_place == 1)
			{
				side2[j].sprite = USA;
				if (GlobalScript.inst.gameState.ingamewars[active_wars[j]].ussr_place == 1)
				{
					side4[j].sprite = USSR;
				}
			}
			else if (GlobalScript.inst.gameState.ingamewars[active_wars[j]].ussr_place == 1)
			{
				side2[j].sprite = USSR;
			}
		}
	}

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (LengthOfWars() > 0)
		{
			CreateWars();
			EstablishWarsChar();
			scroll_here.GetComponent<ScrollScript>().MakeThings(startPoint.transform.position.y, wars_here[wars_here.Length - 1].transform.position.y);
		}
		else
		{
			scroll_here.SetActive(value: false);
		}
		PlayerRepaint();
	}

	public void PlayerRepaint()
	{
		if (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] <= 0)
		{
			return;
		}
		for (int i = 0; i < playersButtons.Length; i++)
		{
			if (i < global1.gameState.numOfPlayers)
			{
				playersButtons[i].SetActive(value: true);
				playersButtons[i].GetComponent<DoctrinePlayersCoopButtons>().Repaint();
			}
			else
			{
				playersButtons[i].SetActive(value: false);
			}
		}
	}
}
