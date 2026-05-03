using UnityEngine;

public class Party_zapret : MonoBehaviour
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
		if (global1.gameState.congressShutdownYears == 1)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			Repaint();
		}
	}

	public void Repaint()
	{
		if (!global1.dlc[0] || global1.gameState.gamerules[1] < 1)
		{
			if (this_number == 1)
			{
				Object.Destroy(base.gameObject);
			}
			else if (global1.gameState.is_party_enabled[this_number])
			{
				GetComponent<SpriteRenderer>().sprite = on;
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = off;
			}
		}
		else
		{
			if (global1.gameState.coopAttacked)
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
	}

	private void OnMouseEnter()
	{
		if (!global1.dlc[0] || global1.gameState.gamerules[1] < 1)
		{
			if (GlobalScript.inst.gameState.is_party_enabled[this_number] && GlobalScript.inst.gameState.data[53] < 4 && GlobalScript.inst.gameState.data[15] > 7 && this_number == 1)
			{
				GetComponent<SpriteRenderer>().sprite = on;
				GetComponent<OkoshkoScript>().text = "Наша партия";
			}
			else if (GlobalScript.inst.gameState.is_party_enabled[this_number] && GlobalScript.inst.gameState.data[53] < 4 && GlobalScript.inst.gameState.data[1] > 0)
			{
				GetComponent<SpriteRenderer>().sprite = off;
				GetComponent<OkoshkoScript>().text = "Запретить";
			}
			else if (!GlobalScript.inst.gameState.is_party_enabled[this_number])
			{
				GetComponent<SpriteRenderer>().sprite = on;
				GetComponent<OkoshkoScript>().text = "Разрешить";
			}
		}
		else
		{
			if (global1.gameState.coopAttacked)
			{
				GetComponent<SpriteRenderer>().sprite = on;
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = off;
				PlayerShow(show: true);
			}
			GetComponent<OkoshkoScript>().text = "Сократить численность фракции на 15%|<color=yellow>Требуется голоса более 50% игроков (не численности фракций)</color>|<color=" + (global1.gameState.coopAttacked ? "red>Ждите следующего года" : "green>Доступно только 1 раз в год") + "</color>";
			GetComponent<OkoshkoScript>().text_en = "Reduce faction strength by 15%|<color=yellow>Requires votes from more than 50% of players (not faction numbers)</color>|<color=" + (global1.gameState.coopAttacked ? "red>Wait for the next year" : "green>Available only once per year") + "</color>";
		}
	}

	private void OnMouseExit()
	{
		if (!global1.dlc[0] || global1.gameState.gamerules[1] < 1)
		{
			if (GlobalScript.inst.gameState.is_party_enabled[this_number])
			{
				GetComponent<SpriteRenderer>().sprite = on;
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = off;
			}
		}
		else if (global1.gameState.coopAttacked)
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
		if (!global1.dlc[0] || global1.gameState.gamerules[1] < 1)
		{
			if (GlobalScript.inst.gameState.is_party_enabled[this_number] && GlobalScript.inst.gameState.data[1] > 0 && GlobalScript.inst.gameState.data[53] < 4 && (GlobalScript.inst.gameState.data[15] <= 7 || GlobalScript.inst.gameState.data[15] <= 7 || (GlobalScript.inst.gameState.data[15] > 7 && this_number != 1)))
			{
				float num = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4];
				int num2 = (int)((float)(GlobalScript.inst.gameState.party_number[this_number] * 100) / num);
				GlobalScript.inst.gameState.data[53]++;
				if (GlobalScript.inst.gameState.data[15] > 7)
				{
					if (GlobalScript.inst.gameState.is_party_ally[this_number])
					{
						GlobalScript.inst.gameState.data[1] -= 250;
						GlobalScript.inst.gameState.data[6] += 30;
					}
					else
					{
						GlobalScript.inst.gameState.data[6] += 10;
					}
					GlobalScript.inst.gameState.data[3] -= num2 * 20;
					GlobalScript.inst.gameState.data[4] += num2 * 30;
					if (GlobalScript.inst.gameState.data[53] >= 4)
					{
						GlobalScript.inst.gameState.data[15] = 6;
						for (int i = 0; i < GlobalScript.inst.gameState.is_party_ally.Length; i++)
						{
							if (GlobalScript.inst.gameState.is_party_ally[i] && i != 1)
							{
								GlobalScript.inst.gameState.is_party_ally[i] = false;
							}
							if (!GlobalScript.inst.gameState.is_party_enabled[i])
							{
								GlobalScript.inst.gameState.is_party_enabled[i] = true;
								if (GlobalScript.inst.gameState.party_number[i] <= 5)
								{
									int num3 = Random.Range(0, 10);
									GlobalScript.inst.gameState.party_number[i] = 10 + num3;
									GlobalScript.inst.gameState.party_ideology[i] = GlobalScript.inst.gameState.party_number[i];
								}
							}
							GlobalScript.inst.gameState.is_party_enabled[4] = false;
							GlobalScript.inst.gameState.party_number[4] = 0;
							GlobalScript.inst.gameState.party_number[3] += GlobalScript.inst.gameState.party_ideology[4];
							GlobalScript.inst.gameState.data[53] = 0;
						}
						GameObject.Find("Kr").GetComponent<Crushok_politic>().Repaint();
						for (int j = 1; j <= 5; j++)
						{
							GameObject.Find("Parties (" + j + ")").transform.Find("Text").GetComponent<Politic_party_name_show>().Repaint();
							GameObject.Find("Parties (" + j + ")").transform.Find("Znack").GetComponent<Party_ally_script>().Repaint();
							GameObject.Find("Parties (" + j + ")").transform.Find("Znakc (1)").GetComponent<Party_zapret>().Repaint();
						}
					}
				}
				else
				{
					GlobalScript.inst.gameState.data[4] += num2 * 20;
					GlobalScript.inst.gameState.data[1] -= num2 * 30;
					if (GlobalScript.inst.gameState.party_ideology[this_number] > 0)
					{
						if (this_number + 1 < GlobalScript.inst.gameState.is_party_enabled.Length)
						{
							for (int k = this_number + 1; k < GlobalScript.inst.gameState.is_party_enabled.Length; k++)
							{
								if (GlobalScript.inst.gameState.is_party_enabled[k])
								{
									GlobalScript.inst.gameState.party_number[k] += GlobalScript.inst.gameState.party_ideology[this_number];
									break;
								}
							}
						}
						else
						{
							for (int num4 = this_number - 1; num4 > 0; num4--)
							{
								if (GlobalScript.inst.gameState.is_party_enabled[num4])
								{
									GlobalScript.inst.gameState.party_number[num4] += GlobalScript.inst.gameState.party_ideology[this_number];
									break;
								}
							}
						}
					}
				}
				GlobalScript.inst.gameState.is_party_enabled[this_number] = false;
				GlobalScript.inst.gameState.party_number[this_number] = 0;
				GlobalScript.inst.gameState.is_party_ally[this_number] = false;
				if (GlobalScript.inst.gameState.data[15] <= 7)
				{
					if (GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 0;
					}
					else if (GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 1;
					}
					else if (GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 2;
					}
					else if (GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 3;
					}
					else if (GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 4;
					}
				}
				else
				{
					int num5 = GlobalScript.inst.gameState.party_number[1];
					for (int l = 0; l < GlobalScript.inst.gameState.is_party_ally.Length; l++)
					{
						if (GlobalScript.inst.gameState.is_party_ally[l] && GlobalScript.inst.gameState.is_party_enabled[l] && l != 1)
						{
							num5 += GlobalScript.inst.gameState.party_number[l];
						}
					}
					if (num5 >= GlobalScript.inst.gameState.party_number[0] && num5 >= GlobalScript.inst.gameState.party_number[2] && num5 >= GlobalScript.inst.gameState.party_number[3] && num5 >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 1;
					}
					else if (!GlobalScript.inst.gameState.is_party_ally[0] && GlobalScript.inst.gameState.is_party_enabled[0] && num5 <= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 0;
					}
					else if (!GlobalScript.inst.gameState.is_party_ally[2] && GlobalScript.inst.gameState.is_party_enabled[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[0] && num5 <= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 2;
					}
					else if (!GlobalScript.inst.gameState.is_party_ally[3] && GlobalScript.inst.gameState.is_party_enabled[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[2] && num5 <= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 3;
					}
					else if (!GlobalScript.inst.gameState.is_party_ally[4] && GlobalScript.inst.gameState.is_party_enabled[4] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[3] && num5 <= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 4;
					}
				}
				Repaint();
			}
			else if (!GlobalScript.inst.gameState.is_party_enabled[this_number] && (GlobalScript.inst.gameState.data[15] <= 7 || GlobalScript.inst.gameState.data[15] <= 7 || (GlobalScript.inst.gameState.data[15] > 7 && this_number != 1)))
			{
				if (GlobalScript.inst.gameState.modifies[66].active && (this_number == 0 || this_number == 4))
				{
					return;
				}
				if (GlobalScript.inst.gameState.data[15] > 7)
				{
					GlobalScript.inst.gameState.data[3] += 40;
					GlobalScript.inst.gameState.data[4] += 60;
				}
				else
				{
					GlobalScript.inst.gameState.data[1] -= 150;
					if (GlobalScript.inst.gameState.party_ideology[this_number] > 0)
					{
						if (this_number + 1 < GlobalScript.inst.gameState.is_party_enabled.Length)
						{
							for (int m = this_number + 1; m < GlobalScript.inst.gameState.is_party_enabled.Length; m++)
							{
								if (GlobalScript.inst.gameState.is_party_enabled[m])
								{
									GlobalScript.inst.gameState.party_number[m] -= GlobalScript.inst.gameState.party_ideology[this_number];
									if (GlobalScript.inst.gameState.party_number[m] < GlobalScript.inst.gameState.party_ideology[m])
									{
										GlobalScript.inst.gameState.party_number[m] = GlobalScript.inst.gameState.party_ideology[m];
									}
									break;
								}
							}
						}
						else
						{
							for (int num6 = this_number - 1; num6 > 0; num6--)
							{
								if (GlobalScript.inst.gameState.is_party_enabled[num6])
								{
									GlobalScript.inst.gameState.party_number[num6] -= GlobalScript.inst.gameState.party_ideology[this_number];
									if (GlobalScript.inst.gameState.party_number[num6] < GlobalScript.inst.gameState.party_ideology[num6])
									{
										GlobalScript.inst.gameState.party_number[num6] = GlobalScript.inst.gameState.party_ideology[num6];
									}
									break;
								}
							}
						}
					}
				}
				GlobalScript.inst.gameState.data[53]--;
				GlobalScript.inst.gameState.is_party_enabled[this_number] = true;
				if (GlobalScript.inst.gameState.party_ideology[this_number] > 0 && GlobalScript.inst.gameState.data[15] <= 7)
				{
					GlobalScript.inst.gameState.party_number[this_number] = GlobalScript.inst.gameState.party_ideology[this_number];
				}
				else
				{
					GlobalScript.inst.gameState.party_number[this_number] = 0;
				}
				if (GlobalScript.inst.gameState.data[15] <= 7)
				{
					if (GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 0;
					}
					else if (GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[1] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 1;
					}
					else if (GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 2;
					}
					else if (GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 3;
					}
					else if (GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[1] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] <= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 4;
					}
				}
				else
				{
					int num7 = GlobalScript.inst.gameState.party_number[1];
					for (int n = 0; n < GlobalScript.inst.gameState.is_party_ally.Length; n++)
					{
						if (GlobalScript.inst.gameState.is_party_ally[n] && GlobalScript.inst.gameState.is_party_enabled[n] && n != 1)
						{
							num7 += GlobalScript.inst.gameState.party_number[n];
						}
					}
					if (num7 >= GlobalScript.inst.gameState.party_number[0] && num7 >= GlobalScript.inst.gameState.party_number[2] && num7 >= GlobalScript.inst.gameState.party_number[3] && num7 >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 1;
					}
					else if (!GlobalScript.inst.gameState.is_party_ally[0] && GlobalScript.inst.gameState.is_party_enabled[0] && num7 <= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[0] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 0;
					}
					else if (!GlobalScript.inst.gameState.is_party_ally[2] && GlobalScript.inst.gameState.is_party_enabled[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[0] && num7 <= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[2] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 2;
					}
					else if (!GlobalScript.inst.gameState.is_party_ally[3] && GlobalScript.inst.gameState.is_party_enabled[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[2] && num7 <= GlobalScript.inst.gameState.party_number[3] && GlobalScript.inst.gameState.party_number[3] >= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 3;
					}
					else if (!GlobalScript.inst.gameState.is_party_ally[4] && GlobalScript.inst.gameState.is_party_enabled[4] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[0] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[2] && GlobalScript.inst.gameState.party_number[4] >= GlobalScript.inst.gameState.party_number[3] && num7 <= GlobalScript.inst.gameState.party_number[4])
					{
						GlobalScript.inst.gameState.data[56] = 4;
					}
				}
				Repaint();
			}
		}
		else
		{
			if (!global1.gameState.coopAttacked && global1.gameState.congressShutdownYears != 1)
			{
				int num8 = 0;
				bool[] playerFor = global1.gameState.playerFor;
				for (int num9 = 0; num9 < playerFor.Length; num9++)
				{
					if (playerFor[num9])
					{
						num8++;
					}
				}
				if (num8 >= global1.gameState.numOfPlayers / 2)
				{
					int num10 = GlobalScript.inst.gameState.party_number[this_number] * 75 / 100;
					GlobalScript.inst.gameState.party_number[this_number] = num10;
					GlobalScript.inst.gameState.party_ideology[this_number] = num10;
					global1.gameState.coopAttacked = true;
				}
			}
			PlayerShow(show: false);
			Repaint();
		}
		doctr1.ShowHideOcno();
		GameObject.Find("Kr").GetComponent<Crushok_politic>().Repaint();
	}
}
