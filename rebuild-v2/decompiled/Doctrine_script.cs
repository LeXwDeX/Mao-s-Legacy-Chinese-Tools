using UnityEngine;

public class Doctrine_script : MonoBehaviour
{
	public GlobalScript global1;

	public int this_number;

	public Sprite navel;

	public Sprite nenavel;

	public GameObject[] buttons = new GameObject[6];

	private bool is_active;

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = navel;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = nenavel;
	}

	public void ShowHideOcno()
	{
		for (int i = 0; i < 6; i++)
		{
			buttons[i].SetActive(value: false);
		}
	}

	private void OnMouseDown()
	{
		int num = 0;
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this_number == 16)
			{
				if (!GlobalScript.inst.gameState.completedDecisions[18])
				{
					buttons[0].GetComponent<Doctrine_button_script>().Show("Soviet-type\nstate planned", 10, this_number);
					buttons[1].GetComponent<Doctrine_button_script>().Show("Automation", 11, this_number);
					buttons[2].GetComponent<Doctrine_button_script>().Show("State monopoly\ncapitalism", 12, this_number);
					buttons[3].GetComponent<Doctrine_button_script>().Show("Bird's\ncage", 13, this_number);
					if (!GlobalScript.inst.gameState.completedDecisions[13])
					{
						buttons[4].GetComponent<Doctrine_button_script>().Show("Mixed\neconomy", 14, this_number);
						buttons[5].GetComponent<Doctrine_button_script>().Show("Minimum\nregulation", 15, this_number);
						num = 5;
					}
					else
					{
						num = 3;
					}
				}
				else
				{
					buttons[0].GetComponent<Doctrine_button_script>().Show("State monopoly\ncapitalism", 12, this_number);
					num = 0;
				}
			}
			else if (this_number == 15)
			{
				buttons[0].GetComponent<Doctrine_button_script>().Show("One-party\ndemocracy", 6, this_number);
				buttons[1].GetComponent<Doctrine_button_script>().Show("New\nDemocracy", 7, this_number);
				if (!GlobalScript.inst.gameState.completedDecisions[13] && !GlobalScript.inst.gameState.modifies[24].active && !GlobalScript.inst.gameState.completedDecisions[16])
				{
					buttons[2].GetComponent<Doctrine_button_script>().Show("Limited\nmultiparty", 8, this_number);
					buttons[3].GetComponent<Doctrine_button_script>().Show("Multiparty\ndemocracy", 9, this_number);
					num = 3;
				}
				else
				{
					num = 1;
				}
			}
			else if (this_number == 17)
			{
				buttons[0].GetComponent<Doctrine_button_script>().Show("Fighting\ndissent", 16, this_number);
				if (!GlobalScript.inst.gameState.modifies[26].active)
				{
					buttons[1].GetComponent<Doctrine_button_script>().Show("Limited", 17, this_number);
					buttons[2].GetComponent<Doctrine_button_script>().Show("Small control", 18, this_number);
					buttons[3].GetComponent<Doctrine_button_script>().Show("Full\nliberalization", 19, this_number);
					num = 3;
				}
				else
				{
					num = 0;
				}
			}
			else if (this_number == 18)
			{
				buttons[0].GetComponent<Doctrine_button_script>().Show("Unitarism", 20, this_number);
				buttons[1].GetComponent<Doctrine_button_script>().Show("Federation", 21, this_number);
				buttons[2].GetComponent<Doctrine_button_script>().Show("Confederation", 22, this_number);
				buttons[3].GetComponent<Doctrine_button_script>().Show("Union of\nautonomies", 23, this_number);
				num = 3;
			}
			else if (this_number == 50)
			{
				if (!GlobalScript.inst.gameState.modifies[25].active && !GlobalScript.inst.gameState.completedDecisions[16])
				{
					buttons[0].GetComponent<Doctrine_button_script>().Show("Fight against\ntraditionalism", 24, this_number);
					buttons[1].GetComponent<Doctrine_button_script>().Show("Support\nof atheism", 25, this_number);
					buttons[2].GetComponent<Doctrine_button_script>().Show("Supervision of\nbeliefs", 26, this_number);
					buttons[3].GetComponent<Doctrine_button_script>().Show("Secular state", 27, this_number);
					buttons[4].GetComponent<Doctrine_button_script>().Show("Reliance on\ntraditions", 28, this_number);
					buttons[5].GetComponent<Doctrine_button_script>().Show("Concordat", 29, this_number);
					num = 5;
				}
				else
				{
					buttons[0].GetComponent<Doctrine_button_script>().Show("Reliance on\ntraditions", 28, this_number);
					buttons[1].GetComponent<Doctrine_button_script>().Show("Concordat", 29, this_number);
					num = 1;
				}
			}
			else if (this_number == 51)
			{
				buttons[0].GetComponent<Doctrine_button_script>().Show("Full\nmilitarization", 30, this_number);
				buttons[1].GetComponent<Doctrine_button_script>().Show("Building up", 31, this_number);
				buttons[2].GetComponent<Doctrine_button_script>().Show("Defensive\narmy", 32, this_number);
				buttons[3].GetComponent<Doctrine_button_script>().Show("Contract\narmy", 33, this_number);
				num = 3;
			}
		}
		else if (this_number == 16)
		{
			if (!GlobalScript.inst.gameState.completedDecisions[18])
			{
				buttons[0].GetComponent<Doctrine_button_script>().Show("Государственное\nпланирование", 10, this_number);
				buttons[1].GetComponent<Doctrine_button_script>().Show("Автоматизация", 11, this_number);
				buttons[2].GetComponent<Doctrine_button_script>().Show("Государственный\nмонополизм", 12, this_number);
				buttons[3].GetComponent<Doctrine_button_script>().Show("Птичья\nклетка", 13, this_number);
				if (!GlobalScript.inst.gameState.completedDecisions[13])
				{
					buttons[4].GetComponent<Doctrine_button_script>().Show("Смешанная\nэкономика", 14, this_number);
					buttons[5].GetComponent<Doctrine_button_script>().Show("Минимальное\nрегулирование", 15, this_number);
					num = 5;
				}
				else
				{
					num = 3;
				}
			}
			else
			{
				buttons[0].GetComponent<Doctrine_button_script>().Show("Государственный\nмонополизм", 12, this_number);
				num = 0;
			}
		}
		else if (this_number == 15)
		{
			buttons[0].GetComponent<Doctrine_button_script>().Show("Однопартийная\nдемократия", 6, this_number);
			buttons[1].GetComponent<Doctrine_button_script>().Show("Новая\nдемократия", 7, this_number);
			if (!GlobalScript.inst.gameState.completedDecisions[13] && !GlobalScript.inst.gameState.modifies[24].active && !GlobalScript.inst.gameState.completedDecisions[16])
			{
				buttons[2].GetComponent<Doctrine_button_script>().Show("Контроль над\nпартиями", 8, this_number);
				buttons[3].GetComponent<Doctrine_button_script>().Show("Многопартийная\nдемократия", 9, this_number);
				num = 3;
			}
			else
			{
				num = 1;
			}
		}
		else if (this_number == 17)
		{
			buttons[0].GetComponent<Doctrine_button_script>().Show("Борьба с\nинакомыслием", 16, this_number);
			if (!GlobalScript.inst.gameState.modifies[26].active)
			{
				buttons[1].GetComponent<Doctrine_button_script>().Show("Ограниченные", 17, this_number);
				buttons[2].GetComponent<Doctrine_button_script>().Show("Малый контроль", 18, this_number);
				buttons[3].GetComponent<Doctrine_button_script>().Show("Полная\nлиберализация", 19, this_number);
				num = 3;
			}
			else
			{
				num = 0;
			}
		}
		else if (this_number == 18)
		{
			buttons[0].GetComponent<Doctrine_button_script>().Show("Унитаризм", 20, this_number);
			buttons[1].GetComponent<Doctrine_button_script>().Show("Федерация", 21, this_number);
			buttons[2].GetComponent<Doctrine_button_script>().Show("Конфедерация", 22, this_number);
			buttons[3].GetComponent<Doctrine_button_script>().Show("Союз автономий", 23, this_number);
			num = 3;
		}
		else if (this_number == 50)
		{
			if (!GlobalScript.inst.gameState.modifies[25].active && !GlobalScript.inst.gameState.completedDecisions[16])
			{
				buttons[0].GetComponent<Doctrine_button_script>().Show("Борьба с\nтрадициями", 24, this_number);
				buttons[1].GetComponent<Doctrine_button_script>().Show("Поддержка\nатеизма", 25, this_number);
				buttons[2].GetComponent<Doctrine_button_script>().Show("Надзор за\nверующими", 26, this_number);
				buttons[3].GetComponent<Doctrine_button_script>().Show("Светское\nгосударство", 27, this_number);
				buttons[4].GetComponent<Doctrine_button_script>().Show("Опора на\nтрадиции", 28, this_number);
				buttons[5].GetComponent<Doctrine_button_script>().Show("Конкордат", 29, this_number);
				num = 5;
			}
			else
			{
				buttons[0].GetComponent<Doctrine_button_script>().Show("Опора на\nтрадиции", 28, this_number);
				buttons[1].GetComponent<Doctrine_button_script>().Show("Конкордат", 29, this_number);
				num = 1;
			}
		}
		else if (this_number == 51)
		{
			buttons[0].GetComponent<Doctrine_button_script>().Show("Полная\nмилитаризация", 30, this_number);
			buttons[1].GetComponent<Doctrine_button_script>().Show("Наращивание\nмощи", 31, this_number);
			buttons[2].GetComponent<Doctrine_button_script>().Show("Оборонительная\nармия", 32, this_number);
			buttons[3].GetComponent<Doctrine_button_script>().Show("Контрактная\nармия", 33, this_number);
			num = 3;
		}
		for (int i = 0; i < 6; i++)
		{
			if (i <= num)
			{
				buttons[i].SetActive(value: true);
				buttons[i].GetComponent<Doctrine_button_script>().doctr1 = GetComponent<Doctrine_script>();
			}
			else
			{
				buttons[i].SetActive(value: false);
			}
		}
	}
}
