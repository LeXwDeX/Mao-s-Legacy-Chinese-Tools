using UnityEngine;

public class DecisionButtonScript : MonoBehaviour
{
	public TextMesh text;

	public OkoshkoScript okno1;

	public int num = -1;

	public Sprite ready;

	public Sprite done;

	public Sprite unready;

	public Sprite on;

	public Sprite off;

	public SpriteRenderer focus_sprite;

	public SpriteRenderer background_sprite;

	private Decision dec;

	public void ChangeText(Decision dec)
	{
		this.dec = dec;
		text.text = Text($"{dec.name}\n{dec.desc}", 60);
		okno1.needAutoText = true;
		okno1.text = (okno1.text_en = string.Format("{0}|{2} {3}", dec.req, GlobalScript.inst.new_texts[109], "", dec.result));
	}

	public void ChangeIcon(int num)
	{
		this.num = num;
		focus_sprite.sprite = Resources.Load<Sprite>($"decision_sp\\D{num}");
	}

	public void ChangeCondition()
	{
		if (GlobalScript.inst.gameState.completedDecisions[num])
		{
			background_sprite.sprite = done;
		}
		else if (!dec.condition())
		{
			background_sprite.sprite = unready;
		}
		else
		{
			background_sprite.sprite = ready;
		}
	}

	public void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on;
	}

	public void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off;
	}

	public void OnMouseDown()
	{
		if (background_sprite.sprite == ready)
		{
			dec.active();
			GlobalScript.inst.gameState.completedDecisions[num] = true;
			GameObject.Find("Back").GetComponent<FocusesScript>().Repaint();
		}
	}

	private static string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
