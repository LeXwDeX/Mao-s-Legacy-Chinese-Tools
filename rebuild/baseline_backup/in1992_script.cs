using UnityEngine;

public class in1992_script : MonoBehaviour
{
	public bool is_left;

	public Sprite navel;

	public Sprite nenavel;

	private GlobalScript global1;

	private TimeScript time1;

	public TextMesh this_text;

	public TextMesh Name;

	public TextMesh End;

	private string fake_text;

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = navel;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = nenavel;
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (is_left)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				time1 = GameObject.Find("Text_time").GetComponent<TimeScript>();
				fake_text = "Comrade!|Further there will be unforgettable and difficult times of bitter achievements and great victories, but we laid the foundation of our bright future right now. However, you are our, similar to the sun, leader and you decide how to proceed:|You can decide to play further - from now to infinity, at any time having the opportunity to finish the game, in order to reshape the world as you see fit. However, then you will not be able to get any achievement, starting with a new date.|Otherwise, you can put an end to all this and, just selecting the right button, finish the game and go to the summary window, where you will draw the line under your many years of work, and also will describe the state of the whole world for years to come. And, most importantly, you can open achievements!|The choice is yours.";
				this_text.text = Text(fake_text, 72);
			}
			else
			{
				time1 = GameObject.Find("Text_time").GetComponent<TimeScript>();
				fake_text = "Товарищ!| Дальше нас ждут незабываемые и тяжелые времена горьких свершений и великих побед, однако фундамент нашего светлого будущего мы заложили уже сейчас. Впрочем, вы - наш солнцеликий руководитель и вам решать, как поступить дальше:|Вы можете решить играть дальше до бесконечности, в любой момент имея возможность закончить игру, дабы перекроить мир так, как вы считаете нужным. Однако, тогда вы не сможете добиться ни одного достижения, начиная с новой даты.|В ином случае вы можете положить всему этому конец и, просто выбрав правую кнопку, закончить игру и перейти к окну итогов, где будет подведена черта под вашей многолетней работой, а также будет описано состояние всего мира на грядущие годы. И, самое главное, вы сможете открыть достижения!|Выбор за вами.";
				this_text.text = Text(fake_text, 72);
			}
		}
	}

	private void OnMouseDown()
	{
		if (is_left)
		{
			time1.Reborn();
			GlobalScript.inst.gameState.iron_and_blood = false;
			return;
		}
		if (GlobalScript.inst.gameState.data[3] < 300 || (GlobalScript.inst.gameState.data[3] < 500 && GlobalScript.inst.gameState.diff == 4))
		{
			GlobalScript.inst.gameState.data[35] = 1;
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
			return;
		}
		if (GlobalScript.inst.gameState.data[1] < 300 || (GlobalScript.inst.gameState.data[1] < 500 && GlobalScript.inst.gameState.diff == 4))
		{
			GlobalScript.inst.gameState.data[35] = 2;
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
			return;
		}
		if (GlobalScript.inst.gameState.allcountries[61].Gosstroy != 1)
		{
			GlobalScript.inst.gameState.allcountries[61].Gosstroy = 3;
			GlobalScript.inst.gameState.allcountries[52].SubGosstroy = 6;
			GlobalScript.inst.gameState.allcountries[61].proprc = false;
			GlobalScript.inst.gameState.empires[0].power += 5;
		}
		if (GlobalScript.inst.gameState.data[67] > 0)
		{
			GlobalScript.inst.gameState.data[62] = 0;
		}
		GlobalScript.inst.gameState.data[35] = 0;
		if (GlobalScript.inst.gameState.empires[1].now_leader == 3)
		{
			GlobalScript.inst.gameState.empires[1].power += 50;
		}
		else if (GlobalScript.inst.gameState.empires[1].now_leader == 5)
		{
			GlobalScript.inst.gameState.empires[1].power -= 50;
		}
		else if (GlobalScript.inst.gameState.empires[1].now_leader == 6)
		{
			if (GlobalScript.inst.gameState.data[66] == 1)
			{
				GlobalScript.inst.gameState.data[66] = 2;
			}
		}
		else if (GlobalScript.inst.gameState.empires[1].now_leader == 4)
		{
			if ((GlobalScript.inst.gameState.relres && GlobalScript.inst.gameState.data[16] == 11) || (GlobalScript.inst.gameState.allcountries[4].Gosstroy == 1 && GlobalScript.inst.gameState.allcountries[4].prosov))
			{
				GlobalScript.inst.gameState.empires[1].power += 100;
			}
			else
			{
				GlobalScript.inst.gameState.empires[1].power += 50;
			}
		}
		GoodEnding();
	}

	private void GoodEnding()
	{
		GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
		GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
	}

	private string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
