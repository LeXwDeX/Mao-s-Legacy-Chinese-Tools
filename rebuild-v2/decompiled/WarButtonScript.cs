using UnityEngine;

public class WarButtonScript : MonoBehaviour
{
	private GlobalScript global1;

	private GameState gs;

	public WarsScript warsc;

	public Sprite navel;

	public Sprite nenavel;

	public int war_number;

	public int this_number;

	public int our_wars;

	public new bool enabled;

	public TextMesh place_1;

	public TextMesh place_2;

	public GameObject[] otherButtons = new GameObject[7];

	private SpriteRenderer spriteRenderer;

	private TextMesh buttonLabel;

	private bool ready;

	private void Start()
	{
		global1 = GlobalScript.inst;
		gs = global1.gameState;
		warsc = GameObject.Find("WarScriptBack").GetComponent<WarsScript>();
		war_number = int.Parse(base.transform.parent.name);
		spriteRenderer = GetComponent<SpriteRenderer>();
		buttonLabel = base.transform.Find("Text").GetComponent<TextMesh>();
		CheckButtonAvailable();
	}

	private void FixedUpdate()
	{
		if (global1.dlc[0] && gs.gamerules[1] > 0 && (this_number == 3 || this_number == 7))
		{
			if (gs.GetSecondReqForPlayers() && !ready)
			{
				ready = true;
				CheckButtonAvailable();
			}
			else if (!gs.GetSecondReqForPlayers() && ready)
			{
				ready = false;
				CheckButtonAvailable();
			}
		}
	}

	private void ShowCoopPlayerButton(ref bool enabled)
	{
		if (!global1.dlc[0] || gs.gamerules[1] <= 0)
		{
			return;
		}
		warinwars warinwars2 = gs.ingamewars[our_wars];
		if (!warinwars2.diplo_done[0] && !warinwars2.diplo_done[1])
		{
			if (this_number != 3 && this_number != 7)
			{
				enabled = false;
			}
			else if (!gs.GetSecondReqForPlayers())
			{
				enabled = false;
			}
			else if (gs.GetSecondReqForPlayers())
			{
				enabled = true;
			}
		}
		else if (warinwars2.diplo_done[0])
		{
			if ((this_number > 3 && this_number < 7) || this_number == 3)
			{
				enabled = false;
			}
			else if (this_number == 7)
			{
				if (!gs.GetSecondReqForPlayers())
				{
					enabled = false;
				}
				else if (gs.GetSecondReqForPlayers())
				{
					enabled = true;
				}
			}
		}
		else
		{
			if (!warinwars2.diplo_done[1])
			{
				return;
			}
			if (this_number < 3 || this_number == 7)
			{
				enabled = false;
			}
			else if (this_number == 3)
			{
				if (!gs.GetSecondReqForPlayers())
				{
					enabled = false;
				}
				else if (gs.GetSecondReqForPlayers())
				{
					enabled = true;
				}
			}
		}
	}

	public void CheckOthers()
	{
		GameObject[] array = otherButtons;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<WarButtonScript>().CheckButtonAvailable();
		}
	}

	private void CheckButtonAvailable()
	{
		GameState gameState = gs;
		if (our_wars < 0)
		{
			our_wars = warsc.active_wars[war_number];
		}
		else
		{
			place_1.text = ((float)gameState.ingamewars[our_wars].infl1 / 10f).ToString();
			place_2.text = ((float)gameState.ingamewars[our_wars].infl2 / 10f).ToString();
		}
		warinwars warinwars2 = gameState.ingamewars[our_wars];
		if (this_number == 0)
		{
			enabled = gameState.data[0] >= 10 && gameState.data[8] + gameState.data[36] >= 20 && warinwars2.infl1 < 1000 && warinwars2.infl2 > 0;
		}
		else if (this_number == 1)
		{
			enabled = gameState.data[0] >= 10 && gameState.data[9] >= 20 && warinwars2.infl1 < 1000 && warinwars2.infl2 > 0;
		}
		else if (this_number == 2)
		{
			enabled = gameState.data[0] >= 10 && gameState.data[22] >= 30 && warinwars2.infl1 < 1000 && warinwars2.infl2 > 0;
		}
		else if (this_number == 3)
		{
			enabled = our_wars != 22 && our_wars != 16 && !warinwars2.diplo_done[0] && !warinwars2.diplo_done[1] && warinwars2.infl1 < 1000 && warinwars2.infl2 > 0;
		}
		else if (this_number == 4)
		{
			enabled = our_wars != 22 && our_wars != 29 && our_wars != 16 && gameState.data[0] >= 10 && gameState.data[9] >= 20 && warinwars2.infl2 < 1000 && warinwars2.infl1 > 0;
		}
		else if (this_number == 5)
		{
			enabled = our_wars != 22 && our_wars != 29 && our_wars != 16 && gameState.data[0] >= 10 && gameState.data[8] + gameState.data[36] >= 20 && warinwars2.infl2 < 1000 && warinwars2.infl1 > 0;
		}
		else if (this_number == 6)
		{
			enabled = our_wars != 22 && our_wars != 29 && our_wars != 16 && gameState.data[0] >= 10 && gameState.data[22] >= 30 && warinwars2.infl2 < 1000 && warinwars2.infl1 > 0;
		}
		else if (this_number == 7)
		{
			enabled = our_wars != 22 && our_wars != 29 && our_wars != 16 && !warinwars2.diplo_done[1] && !warinwars2.diplo_done[0] && warinwars2.infl2 < 1000 && warinwars2.infl1 > 0;
		}
		ShowCoopPlayerButton(ref enabled);
		if (!enabled)
		{
			spriteRenderer.sprite = navel;
		}
		else
		{
			spriteRenderer.sprite = nenavel;
		}
		if (warinwars2.infl1 > 1000)
		{
			warinwars2.infl1 = 1000;
		}
		else if (warinwars2.infl1 < 0)
		{
			warinwars2.infl1 = 0;
		}
		if (warinwars2.infl2 > 1000)
		{
			warinwars2.infl2 = 1000;
		}
		else if (warinwars2.infl2 < 0)
		{
			warinwars2.infl2 = 0;
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this_number == 0 || this_number == 5)
			{
				buttonLabel.text = "HUM.";
			}
			else if (this_number == 1 || this_number == 4)
			{
				buttonLabel.text = "SPEC.";
			}
			else if (this_number == 2 || this_number == 6)
			{
				buttonLabel.text = "WEAP.";
			}
			else if (this_number == 3 || this_number == 7)
			{
				buttonLabel.text = "DIPL.";
			}
		}
	}

	private void OnMouseDown()
	{
		CheckButtonAvailable();
		if (this_number == 0 && enabled)
		{
			GlobalScript.inst.gameState.data[8] -= 20;
			if (GlobalScript.inst.gameState.ingamewars[our_wars].usa_place == 1)
			{
				GlobalScript.inst.gameState.empires[0].relations -= 5;
			}
			if (GlobalScript.inst.gameState.ingamewars[our_wars].ussr_place == 1)
			{
				GlobalScript.inst.gameState.empires[1].relations -= 5;
			}
			GlobalScript.inst.gameState.ingamewars[our_wars].infl1 += 20;
			GlobalScript.inst.gameState.ingamewars[our_wars].infl2 -= 20;
			GlobalScript.inst.gameState.data[0] -= 10;
		}
		else if (this_number == 1 && enabled)
		{
			GlobalScript.inst.gameState.data[9] -= 30;
			if (GlobalScript.inst.gameState.ingamewars[our_wars].usa_place == 1)
			{
				GlobalScript.inst.gameState.empires[0].relations -= 5;
			}
			if (GlobalScript.inst.gameState.ingamewars[our_wars].ussr_place == 1)
			{
				GlobalScript.inst.gameState.empires[1].relations -= 5;
			}
			if (GlobalScript.inst.gameState.science[24])
			{
				GlobalScript.inst.gameState.ingamewars[our_wars].infl1 += 40;
				GlobalScript.inst.gameState.ingamewars[our_wars].infl2 -= 40;
			}
			else
			{
				GlobalScript.inst.gameState.ingamewars[our_wars].infl1 += 30;
				GlobalScript.inst.gameState.ingamewars[our_wars].infl2 -= 30;
			}
			GlobalScript.inst.gameState.data[0] -= 10;
		}
		else if (this_number == 2 && enabled)
		{
			GlobalScript.inst.gameState.data[22] -= 30;
			GlobalScript.inst.gameState.data[8] += 3;
			if (GlobalScript.inst.gameState.ingamewars[our_wars].usa_place == 1)
			{
				GlobalScript.inst.gameState.empires[0].relations -= 5;
			}
			if (GlobalScript.inst.gameState.ingamewars[our_wars].ussr_place == 1)
			{
				GlobalScript.inst.gameState.empires[1].relations -= 5;
			}
			if (GlobalScript.inst.gameState.science[23])
			{
				GlobalScript.inst.gameState.ingamewars[our_wars].infl1 += 40;
				GlobalScript.inst.gameState.ingamewars[our_wars].infl2 -= 40;
			}
			else
			{
				GlobalScript.inst.gameState.ingamewars[our_wars].infl1 += 30;
				GlobalScript.inst.gameState.ingamewars[our_wars].infl2 -= 30;
			}
			GlobalScript.inst.gameState.data[0] -= 10;
		}
		else if (this_number == 3 && enabled)
		{
			if (GlobalScript.inst.gameState.ingamewars[our_wars].usa_place == 0)
			{
				GlobalScript.inst.gameState.empires[0].relations += 30;
			}
			if (GlobalScript.inst.gameState.ingamewars[our_wars].ussr_place == 0)
			{
				GlobalScript.inst.gameState.empires[1].relations += 30;
			}
			GlobalScript.inst.gameState.ingamewars[our_wars].infl1 += 80;
			GlobalScript.inst.gameState.ingamewars[our_wars].infl2 -= 80;
			GlobalScript.inst.gameState.ingamewars[our_wars].diplo_done[0] = true;
			GlobalScript.inst.gameState.ingamewars[our_wars].diplo_done[1] = false;
			warsc.PlayerRepaint();
		}
		else if (this_number == 7 && enabled)
		{
			if (GlobalScript.inst.gameState.ingamewars[our_wars].usa_place == 1)
			{
				GlobalScript.inst.gameState.empires[0].relations += 30;
			}
			if (GlobalScript.inst.gameState.ingamewars[our_wars].ussr_place == 1)
			{
				GlobalScript.inst.gameState.empires[1].relations += 30;
			}
			GlobalScript.inst.gameState.ingamewars[our_wars].infl2 += 80;
			GlobalScript.inst.gameState.ingamewars[our_wars].infl1 -= 80;
			GlobalScript.inst.gameState.ingamewars[our_wars].diplo_done[1] = true;
			GlobalScript.inst.gameState.ingamewars[our_wars].diplo_done[0] = false;
			warsc.PlayerRepaint();
		}
		else if (this_number == 6 && enabled)
		{
			GlobalScript.inst.gameState.data[22] -= 30;
			GlobalScript.inst.gameState.data[8]++;
			if (GlobalScript.inst.gameState.ingamewars[our_wars].usa_place == 0)
			{
				GlobalScript.inst.gameState.empires[0].relations -= 5;
			}
			if (GlobalScript.inst.gameState.ingamewars[our_wars].ussr_place == 0)
			{
				GlobalScript.inst.gameState.empires[1].relations -= 5;
			}
			if (GlobalScript.inst.gameState.science[23])
			{
				GlobalScript.inst.gameState.ingamewars[our_wars].infl2 += 40;
				GlobalScript.inst.gameState.ingamewars[our_wars].infl1 -= 40;
			}
			else
			{
				GlobalScript.inst.gameState.ingamewars[our_wars].infl2 += 30;
				GlobalScript.inst.gameState.ingamewars[our_wars].infl1 -= 30;
			}
			GlobalScript.inst.gameState.data[0] -= 10;
		}
		else if (this_number == 4 && enabled)
		{
			GlobalScript.inst.gameState.data[9] -= 30;
			if (GlobalScript.inst.gameState.ingamewars[our_wars].usa_place == 0)
			{
				GlobalScript.inst.gameState.empires[0].relations -= 5;
			}
			if (GlobalScript.inst.gameState.ingamewars[our_wars].ussr_place == 0)
			{
				GlobalScript.inst.gameState.empires[1].relations -= 5;
			}
			if (GlobalScript.inst.gameState.science[24])
			{
				GlobalScript.inst.gameState.ingamewars[our_wars].infl2 += 40;
				GlobalScript.inst.gameState.ingamewars[our_wars].infl1 -= 40;
			}
			else
			{
				GlobalScript.inst.gameState.ingamewars[our_wars].infl2 += 30;
				GlobalScript.inst.gameState.ingamewars[our_wars].infl1 -= 30;
			}
			GlobalScript.inst.gameState.data[0] -= 10;
		}
		else if (this_number == 5 && enabled)
		{
			GlobalScript.inst.gameState.data[8] -= 20;
			if (GlobalScript.inst.gameState.ingamewars[our_wars].usa_place == 0)
			{
				GlobalScript.inst.gameState.empires[0].relations -= 5;
			}
			if (GlobalScript.inst.gameState.ingamewars[our_wars].ussr_place == 0)
			{
				GlobalScript.inst.gameState.empires[1].relations -= 5;
			}
			GlobalScript.inst.gameState.ingamewars[our_wars].infl2 += 20;
			GlobalScript.inst.gameState.ingamewars[our_wars].infl1 -= 20;
			GlobalScript.inst.gameState.data[0] -= 10;
		}
		CheckButtonAvailable();
		CheckOthers();
	}

	private void OnMouseEnter()
	{
		spriteRenderer.sprite = navel;
	}

	private void OnMouseExit()
	{
		if (enabled)
		{
			spriteRenderer.sprite = nenavel;
		}
	}
}
