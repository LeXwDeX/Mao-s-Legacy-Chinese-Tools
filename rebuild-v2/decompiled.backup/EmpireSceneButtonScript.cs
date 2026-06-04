using UnityEngine;

public class EmpireSceneButtonScript : MonoBehaviour
{
	public TextMesh text;

	public OkoshkoScript okno1;

	public int num;

	public Sprite on;

	public Sprite off;

	public void ChangeText(string text, string okno_text)
	{
		this.text.text = text;
		okno1.needAutoText = true;
		okno1.text = (okno1.text_en = okno_text);
	}

	public void OnMouseDown()
	{
		if (num < 0)
		{
			GameObject.Find("Back").GetComponent<EmpireSceneScript>().Repaint(num * -1 - 1);
		}
	}

	public void OnMouseEnter()
	{
		if (num < 0)
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
	}

	public void OnMouseExit()
	{
		if (num < 0)
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}
}
