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
				fake_text = "同志！|接下来还将有令人难忘、艰难的岁月：\n在苦难的成就与伟大的胜利中前进，但我们现在就已经为光明的未来\n打下了基础。可是，你是我们那位如太阳般的领袖，\n你决定下一步怎么走：|你可以决定继续游戏——从现在到永远，\n随时都有机会结束游戏，以便按你所见重塑世界。\n然而，那样你将无法获得任何成就——从新的日期开始。\n|否则，你可以就此终结这一切，只需按下正确的按钮，\n结束游戏并进入总结窗口：在那里，你将为自己多年工作画上句号，\n并且还将描述未来数年整个世界的态势。\n最重要的是，你还能解锁成就！\n|选择权在你。";
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
			GameObject.Find("按钮（4）").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("按钮（4）").GetComponent<EvetnnashScript>().OnMouseDown();
			return;
		}
		if (GlobalScript.inst.gameState.data[1] < 300 || (GlobalScript.inst.gameState.data[1] < 500 && GlobalScript.inst.gameState.diff == 4))
		{
			GlobalScript.inst.gameState.data[35] = 2;
			GameObject.Find("按钮（4）").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("按钮（4）").GetComponent<EvetnnashScript>().OnMouseDown();
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
		GameObject.Find("按钮（4）").GetComponent<EvetnnashScript>().new_scene = "Ending";
		GameObject.Find("按钮（4）").GetComponent<EvetnnashScript>().OnMouseDown();
	}

	private string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
