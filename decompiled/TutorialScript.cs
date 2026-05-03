using UnityEngine;

public class TutorialScript : MonoBehaviour
{
	public TextMesh text_this;

	public string fake_text;

	public string[] text_russ = new string[31];

	public string[] text_engs = new string[31];

	public Sprite[] rus_s = new Sprite[22];

	public Sprite[] eng_s = new Sprite[22];

	public SpriteRenderer Back;

	public Sprite navel;

	public Sprite nenavel;

	public int now_go;

	public int sprite_now;

	private void Awake()
	{
		now_go--;
		sprite_now--;
		OnMouseDown();
	}

	private void OnMouseEnter()
	{
		base.gameObject.GetComponent<SpriteRenderer>().sprite = navel;
	}

	private void OnMouseExit()
	{
		base.gameObject.GetComponent<SpriteRenderer>().sprite = nenavel;
	}

	private void OnMouseDown()
	{
		if (now_go == 29)
		{
			now_go = -2;
		}
		else if (now_go == -2)
		{
			now_go = 1;
		}
		else
		{
			now_go++;
		}
		if (now_go == 29)
		{
			sprite_now = 0;
		}
		else if (now_go == 0 || (now_go >= 2 && now_go <= 10) || (now_go >= 12 && now_go <= 14) || (now_go >= 16 && now_go <= 18) || now_go == 20 || now_go == 22 || (now_go >= 24 && now_go <= 26) || now_go == 28)
		{
			sprite_now++;
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (now_go >= 0)
			{
				fake_text = text_engs[now_go];
			}
			else
			{
				fake_text = text_engs[30];
			}
			if (now_go <= 0 || (now_go >= 2 && now_go <= 10) || (now_go >= 12 && now_go <= 14) || (now_go >= 16 && now_go <= 18) || now_go == 20 || now_go == 22 || (now_go >= 24 && now_go <= 26) || now_go == 28)
			{
				Back.sprite = eng_s[sprite_now];
			}
		}
		else
		{
			if (now_go >= 0)
			{
				fake_text = text_russ[now_go];
			}
			else
			{
				fake_text = text_russ[30];
			}
			if (now_go <= 0 || (now_go >= 2 && now_go <= 10) || (now_go >= 12 && now_go <= 14) || (now_go >= 16 && now_go <= 18) || now_go == 20 || now_go == 22 || (now_go >= 24 && now_go <= 26) || now_go == 28)
			{
				Back.sprite = rus_s[sprite_now];
			}
		}
		text_this.text = Text(fake_text, 48);
	}

	private string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
