using System.Collections.Generic;
using UnityEngine;

public class FocusButtoNScript : MonoBehaviour
{
	public TextMesh text;

	public OkoshkoScript okno1;

	public int num;

	public Sprite on;

	public Sprite off;

	public SpriteRenderer focus_sprite;

	public GameObject left_arrow;

	public GameObject right_arrow;

	public void ChangeText(int num, List<Focus> foc1)
	{
		text.text = foc1[num].desc.title;
		okno1.needAutoText = true;
		okno1.text = (okno1.text_en = $"{foc1[num].req}|{GlobalScript.inst.new_texts[38]} {foc1[num].desc.desc}|{foc1[num].result}");
	}

	public void ChangeIcon(int num, int country)
	{
		this.num = num;
		focus_sprite.sprite = Resources.Load<Sprite>(string.Format("focusscene_sp\\{1}_{0}", num, country));
	}

	public void ChangeCondition(int country, Focus foc)
	{
		if (foc.blocked)
		{
			GetComponent<SpriteRenderer>().color = new Color(0.4150943f, 0.4150943f, 0.4150943f);
			focus_sprite.color = new Color(0.4150943f, 0.4150943f, 0.4150943f);
		}
		else if (foc.overtime >= foc.time)
		{
			switch (country)
			{
			case 1:
				GetComponent<SpriteRenderer>().color = new Color(1f, 0.514151f, 0.514151f);
				focus_sprite.color = new Color(1f, 0.514151f, 0.514151f);
				break;
			case 0:
				GetComponent<SpriteRenderer>().color = new Color(0.5137255f, 0.9228913f, 1f);
				focus_sprite.color = new Color(0.4292453f, 1f, 0.976189f);
				break;
			}
		}
		else if (foc.overtime > 0)
		{
			GetComponent<SpriteRenderer>().color = new Color(0.9533033f, 1f, 0.4103774f);
			focus_sprite.color = new Color(0.9533033f, 1f, 0.4103774f);
		}
	}

	public void AddArrows(int num, List<Focus> foc1)
	{
		if (num < foc1.Count - 1)
		{
			right_arrow.SetActive(value: true);
		}
		else
		{
			right_arrow.SetActive(value: false);
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
		if (num < 0)
		{
			GameObject.Find("Back").GetComponent<FocusesScript>().Repaint(num * -1 - 1);
		}
	}

	private string Text(string text, int col)
	{
		return Utils.Text(text, col);
	}
}
