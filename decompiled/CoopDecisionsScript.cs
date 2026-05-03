using UnityEngine;

public class CoopDecisionsScript : MonoBehaviour
{
	private GlobalScript global1;

	public int this_number;

	public Sprite on;

	public Sprite off;

	public Doctrine_script doctr1;

	public GameObject[] playersButtons = new GameObject[5];

	private void Awake()
	{
		global1 = GlobalScript.inst;
		Repaint();
	}

	public void Repaint()
	{
		if (!global1.dlc[0] || global1.gameState.gamerules[1] < 1)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		if ((this_number == 0 && global1.gameState.congressShutdownYears > 0) || (this_number == 1 && global1.gameState.peopleCoalitionYears > 0))
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
		PlayerShow(show: true);
		PlayerShow(show: false);
	}

	private void OnMouseEnter()
	{
		if ((this_number == 0 && global1.gameState.congressShutdownYears > 0) || (this_number == 1 && global1.gameState.peopleCoalitionYears > 0))
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = off;
			PlayerShow(show: true);
		}
		GlobalScript.inst.gameState.GetSecondReqForPlayers();
		if (this_number == 0)
		{
			GetComponent<OkoshkoScript>().text = "Запретить возможность увеличивать и сокращать численность фракций вручную и голосованием на 1 год|<color=yellow>Число депутатов от фракций каждого игрока За > остальных</color>|<color=" + ((global1.gameState.congressShutdownYears > 0) ? $"red>Сейчас {global1.gameState.congressShutdownYears - 1} год из 4х" : "green>Доступно только 1 раз в 4 года") + "</color>";
			GetComponent<OkoshkoScript>().text_en = "Prohibit the ability to increase and decrease the number of factions manually and by voting for 1 year|<color=yellow>Number of deputies from factions of each player For > others</color>|<color=" + ((global1.gameState.congressShutdownYears > 0) ? $"red>Now is the {global1.gameState.congressShutdownYears - 1} year of 4" : "green>Available only once every 4 years") + "</color>";
		}
		else if (this_number == 1)
		{
			GetComponent<OkoshkoScript>().text = "Перераспределить депутатов в равном количестве|<color=yellow>Число депутатов от фракций каждого игрока За > остальных</color>|<color=" + ((global1.gameState.peopleCoalitionYears > 0) ? $"red>Прошло {global1.gameState.peopleCoalitionYears - 1} год из 4х" : "green>Доступно только 1 раз в 4 года") + "</color>";
			GetComponent<OkoshkoScript>().text_en = "Redistribute deputies in equal numbers|<color=yellow>Number of deputies from factions of each player For > others</color>|<color=" + ((global1.gameState.peopleCoalitionYears > 0) ? $"red>Now is the {global1.gameState.peopleCoalitionYears - 1} year of 4" : "green>Available only once every 4 years") + "</color>";
		}
	}

	private void OnMouseExit()
	{
		if ((this_number == 0 && global1.gameState.congressShutdownYears > 0) || (this_number == 1 && global1.gameState.peopleCoalitionYears > 0))
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}

	private void PlayerShow(bool show)
	{
		if (show)
		{
			for (int i = 0; i < global1.gameState.numOfPlayers; i++)
			{
				playersButtons[i].SetActive(value: true);
			}
			return;
		}
		GameObject[] array = playersButtons;
		foreach (GameObject obj in array)
		{
			obj.GetComponent<DoctrinePlayersCoopButtons>().Repaint();
			obj.SetActive(value: false);
		}
	}

	private void OnMouseDown()
	{
		bool secondReqForPlayers = GlobalScript.inst.gameState.GetSecondReqForPlayers();
		if (this_number == 0 && global1.gameState.congressShutdownYears <= 0 && secondReqForPlayers)
		{
			global1.gameState.congressShutdownYears = 1;
		}
		else if (this_number == 1 && global1.gameState.peopleCoalitionYears <= 0 && secondReqForPlayers)
		{
			for (int i = 0; i < GlobalScript.inst.gameState.party_number.Length; i++)
			{
				GlobalScript.inst.gameState.is_party_enabled[i] = true;
				GlobalScript.inst.gameState.party_number[i] = 600;
				GlobalScript.inst.gameState.party_ideology[i] = 600;
			}
			GlobalScript.inst.gameState.data[106] = 0;
			global1.gameState.peopleCoalitionYears = 1;
		}
		PlayerShow(show: false);
		Repaint();
		doctr1.ShowHideOcno();
		GameObject.Find("Kr").GetComponent<Crushok_politic>().Repaint();
	}
}
