using UnityEngine;

public class Plusmisnus_script : MonoBehaviour
{
	private GlobalScript global1;

	public bool minus;

	public bool gosdolg;

	public bool reserv;

	public bool payment;

	public bool cheat;

	public bool fleet;

	public bool war;

	public int this_number;

	public Sprite on;

	public Sprite off;

	public int planka;

	public int planka2;

	public Show_diplomacy_data_script planka_check;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (this_number == 159)
		{
			base.gameObject.transform.parent.gameObject.SetActive(value: false);
		}
		else if (!cheat && !fleet)
		{
			planka_check = GameObject.Find("planka_dolg(clone)").GetComponent<Show_diplomacy_data_script>();
			if (gosdolg)
			{
				planka = (GlobalScript.inst.gameState.empires[0].relations + GlobalScript.inst.gameState.empires[1].relations) / 5;
			}
			if (!gosdolg && !reserv)
			{
				CheckPlanka();
			}
		}
		else
		{
			if (!fleet)
			{
				return;
			}
			if (!war)
			{
				if (!minus)
				{
					GetComponent<OkoshkoScript>().text = (GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.new_texts[735]);
				}
				else
				{
					GetComponent<OkoshkoScript>().text = (GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.new_texts[736]);
				}
			}
			else if (!minus)
			{
				GetComponent<OkoshkoScript>().text = (GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.new_texts[801]);
			}
			else
			{
				GetComponent<OkoshkoScript>().text = (GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.new_texts[802]);
			}
		}
	}

	private void CheckPlanka()
	{
		planka2 = GlobalScript.inst.gameState.data[8] + GlobalScript.inst.gameState.data[36];
		for (int i = 71; i <= 81; i++)
		{
			planka2 += GlobalScript.inst.gameState.data[i];
		}
		if (GlobalScript.inst.gameState.data[16] > 12)
		{
			planka2 -= (GlobalScript.inst.gameState.data[16] - 12) * (planka2 / 10);
		}
	}

	private void OnMouseDown()
	{
		if (gosdolg && !minus && !IsGosdolgAvailable())
		{
			return;
		}
		if (!cheat)
		{
			if (!fleet)
			{
				CheckPlanka();
				if (!gosdolg && !reserv)
				{
					if (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] < 1 || GlobalScript.inst.gameState.GetSecondReqForPlayers())
					{
						if (minus)
						{
							if (Input.GetKey(KeyCode.LeftShift))
							{
								if (GlobalScript.inst.gameState.data[this_number] >= 50)
								{
									GlobalScript.inst.gameState.data[this_number] -= 50;
									GlobalScript.inst.gameState.data[8] += 50;
									if (payment)
									{
										GlobalScript.inst.gameState.data[1] -= 200;
									}
								}
							}
							else if (Input.GetKey(KeyCode.LeftControl))
							{
								if (GlobalScript.inst.gameState.data[this_number] >= 100)
								{
									GlobalScript.inst.gameState.data[this_number] -= 100;
									GlobalScript.inst.gameState.data[8] += 100;
									if (payment)
									{
										GlobalScript.inst.gameState.data[1] -= 400;
									}
								}
							}
							else if (GlobalScript.inst.gameState.data[this_number] >= 10)
							{
								GlobalScript.inst.gameState.data[this_number] -= 10;
								GlobalScript.inst.gameState.data[8] += 10;
								if (payment)
								{
									GlobalScript.inst.gameState.data[1] -= 40;
								}
							}
							CheckPlanka();
						}
						else if (!minus)
						{
							if (Input.GetKey(KeyCode.LeftShift))
							{
								if (GlobalScript.inst.gameState.data[8] >= 50 && GlobalScript.inst.gameState.data[this_number] + 50 <= planka2 / 6)
								{
									GlobalScript.inst.gameState.data[this_number] += 50;
									GlobalScript.inst.gameState.data[8] -= 50;
								}
							}
							else if (Input.GetKey(KeyCode.LeftControl))
							{
								if (GlobalScript.inst.gameState.data[8] >= 100 && GlobalScript.inst.gameState.data[this_number] + 100 <= planka2 / 6)
								{
									GlobalScript.inst.gameState.data[this_number] += 100;
									GlobalScript.inst.gameState.data[8] -= 100;
								}
							}
							else if (GlobalScript.inst.gameState.data[8] >= 10 && GlobalScript.inst.gameState.data[this_number] <= planka2 / 6)
							{
								GlobalScript.inst.gameState.data[this_number] += 10;
								GlobalScript.inst.gameState.data[8] -= 10;
							}
							CheckPlanka();
						}
					}
				}
				else if (reserv)
				{
					if (!minus)
					{
						if (Input.GetKey(KeyCode.LeftShift))
						{
							if (GlobalScript.inst.gameState.data[8] >= 50)
							{
								GlobalScript.inst.gameState.data[this_number] += 50;
								GlobalScript.inst.gameState.data[8] -= 50;
							}
						}
						else if (Input.GetKey(KeyCode.LeftControl))
						{
							if (GlobalScript.inst.gameState.data[8] >= 100)
							{
								GlobalScript.inst.gameState.data[this_number] += 100;
								GlobalScript.inst.gameState.data[8] -= 100;
							}
						}
						else if (GlobalScript.inst.gameState.data[8] >= 10)
						{
							GlobalScript.inst.gameState.data[this_number] += 10;
							GlobalScript.inst.gameState.data[8] -= 10;
						}
					}
					else if (minus)
					{
						if (Input.GetKey(KeyCode.LeftShift))
						{
							if (GlobalScript.inst.gameState.data[this_number] >= 50)
							{
								GlobalScript.inst.gameState.data[this_number] -= 50;
								GlobalScript.inst.gameState.data[8] += 50;
								GlobalScript.inst.gameState.data[1] -= 50;
								GlobalScript.inst.gameState.data[3] -= 50;
							}
						}
						else if (Input.GetKey(KeyCode.LeftControl))
						{
							if (GlobalScript.inst.gameState.data[this_number] >= 100)
							{
								GlobalScript.inst.gameState.data[this_number] -= 100;
								GlobalScript.inst.gameState.data[8] += 100;
								GlobalScript.inst.gameState.data[1] -= 100;
								GlobalScript.inst.gameState.data[3] -= 100;
							}
						}
						else if (GlobalScript.inst.gameState.data[this_number] >= 10)
						{
							GlobalScript.inst.gameState.data[this_number] -= 10;
							GlobalScript.inst.gameState.data[8] += 10;
							GlobalScript.inst.gameState.data[1] -= 10;
							GlobalScript.inst.gameState.data[3] -= 10;
						}
					}
				}
				else if (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] < 1 || GlobalScript.inst.gameState.GetSecondReqForPlayers())
				{
					if (minus && GlobalScript.inst.gameState.data[this_number] >= 10)
					{
						GlobalScript.inst.gameState.data[this_number] -= 10;
						if (GlobalScript.inst.gameState.diff < 2)
						{
							GlobalScript.inst.gameState.data[8] -= 10;
						}
						else if (GlobalScript.inst.gameState.diff == 3)
						{
							GlobalScript.inst.gameState.data[8] -= 30;
						}
						else
						{
							GlobalScript.inst.gameState.data[8] -= 20;
						}
						GlobalScript.inst.gameState.data[1] += 10;
						planka = (GlobalScript.inst.gameState.empires[0].relations + GlobalScript.inst.gameState.empires[1].relations) / 5;
					}
					else if (minus && GlobalScript.inst.gameState.data[this_number] > 0)
					{
						if (GlobalScript.inst.gameState.diff < 2)
						{
							GlobalScript.inst.gameState.data[8] -= GlobalScript.inst.gameState.data[this_number];
						}
						else if (GlobalScript.inst.gameState.diff == 3)
						{
							GlobalScript.inst.gameState.data[8] -= GlobalScript.inst.gameState.data[this_number] * 3;
						}
						else
						{
							GlobalScript.inst.gameState.data[8] -= GlobalScript.inst.gameState.data[this_number] * 2;
						}
						GlobalScript.inst.gameState.data[this_number] = 0;
						GlobalScript.inst.gameState.data[1] += 5;
						planka = (GlobalScript.inst.gameState.empires[0].relations + GlobalScript.inst.gameState.empires[1].relations) / 5;
					}
					else if (!minus && GlobalScript.inst.gameState.data[this_number] < planka)
					{
						GlobalScript.inst.gameState.data[this_number] += 10;
						GlobalScript.inst.gameState.data[8] += 10;
						GlobalScript.inst.gameState.data[1] -= 10;
						GlobalScript.inst.gameState.data[4] += 25;
						planka = (GlobalScript.inst.gameState.empires[0].relations + GlobalScript.inst.gameState.empires[1].relations) / 5;
					}
				}
				planka_check.MakePlankaReady();
				return;
			}
			GlobalScript inst = GlobalScript.inst;
			if (!war)
			{
				if (!minus)
				{
					if (inst.gameState.data[160] >= 10 && inst.gameState.data[22] >= 500 && inst.gameState.data[8] + inst.gameState.data[36] >= 250)
					{
						inst.gameState.data[160] -= 10;
						inst.gameState.data[22] -= 500;
						inst.gameState.data[162] += 500;
						inst.gameState.data[8] -= 250;
					}
				}
				else if (inst.gameState.data[162] >= 10)
				{
					inst.gameState.data[162] -= 10;
					inst.gameState.data[160] += 10;
					inst.gameState.data[22] += 50;
				}
			}
			else if (!minus)
			{
				int[] array = new int[9]
				{
					(inst.gameState.data[165] == 0) ? 25 : ((inst.gameState.data[165] == 1) ? 75 : 25),
					(inst.gameState.data[165] == 0) ? 50 : 5,
					(inst.gameState.data[166] == 0) ? 5 : 0,
					(inst.gameState.data[165] == 2) ? 5 : ((inst.gameState.data[166] != 0) ? 5 : 0),
					(inst.gameState.data[165] == 2) ? 5 : ((inst.gameState.data[166] != 0) ? 5 : 0),
					(inst.gameState.data[165] == 2) ? 5 : ((inst.gameState.data[166] == 2) ? (-5) : 0),
					(inst.gameState.data[165] == 2) ? 25 : 0,
					(inst.gameState.data[166] == 2) ? 5 : 0,
					(inst.gameState.data[166] == 2) ? 1 : 0
				};
				if (inst.gameState.data[22] >= array[0] && inst.gameState.data[160] >= array[1] && inst.gameState.data[163] < 1000)
				{
					inst.gameState.data[22] -= array[0];
					inst.gameState.data[160] -= array[1];
					inst.gameState.data[164] += array[1];
					inst.gameState.data[8] -= array[2];
					inst.gameState.data[3] -= array[3];
					inst.gameState.data[4] += array[4];
					inst.gameState.data[1] -= array[5];
					inst.gameState.empires[0].relations -= array[6];
					inst.gameState.empires[1].relations -= array[6];
					inst.gameState.data[9] -= array[7];
					inst.gameState.data[57] += array[8];
					inst.gameState.data[163] += 50;
				}
			}
			else if (inst.gameState.data[163] < 1000 && inst.gameState.data[163] > 15)
			{
				inst.gameState.data[22] += 5;
				inst.gameState.data[160]++;
				inst.gameState.data[164]--;
				inst.gameState.data[163] -= 15;
			}
		}
		else if (Input.GetKey(KeyCode.LeftShift))
		{
			CheatMethod(40);
		}
		else if (Input.GetKey(KeyCode.LeftControl))
		{
			CheatMethod(90);
		}
		else
		{
			CheatMethod();
		}
	}

	private void CheatMethod(int plus = 0)
	{
		GlobalScript.inst.gameState.data[7] = GlobalScript.inst.gameState.influencePRC;
		GlobalScript.inst.gameState.data[this_number] += (minus ? (-(10 + plus)) : (10 + plus));
		GlobalScript.inst.gameState.influencePRC = GlobalScript.inst.gameState.data[7];
	}

	private void OnMouseEnter()
	{
		bool flag = IsGosdolgAvailable();
		if (!fleet)
		{
			CheckPlanka();
			if ((!gosdolg && minus) || (!gosdolg && !minus && GlobalScript.inst.gameState.data[this_number] <= planka2 / 6) || (gosdolg && minus) || (gosdolg && GlobalScript.inst.gameState.data[this_number] <= planka && flag))
			{
				GetComponent<SpriteRenderer>().sprite = on;
			}
		}
		else
		{
			GetComponent<SpriteRenderer>().color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (!fleet)
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
		else
		{
			GetComponent<SpriteRenderer>().color = Color.white;
		}
	}

	private bool IsGosdolgAvailable()
	{
		if (!gosdolg)
		{
			return true;
		}
		GameState gameState = GlobalScript.inst.gameState;
		if (!gameState.allcountries[1].econ && !gameState.allcountries[1].isSEV && gameState.modifies[12].active)
		{
			return false;
		}
		if (!gameState.science[9] && !gameState.allcountries[1].isSEV)
		{
			return gameState.allcountries[1].isASEAN;
		}
		return true;
	}
}
