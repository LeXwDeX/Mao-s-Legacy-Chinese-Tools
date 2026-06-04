using UnityEngine;

public class OkoshkoScript : MonoBehaviour
{
	private GameObject pidor;

	private GameObject t;

	public string text;

	public string text_en;

	public int numString = -1;

	public GameObject okno;

	public Camera Cam;

	public bool nonono;

	public bool needAutoText;

	private void Start()
	{
		Cam = GameObject.Find("主摄像机").GetComponent<Camera>();
	}

	private void OnMouseEnter()
	{
		if (nonono)
		{
			return;
		}
		if (Cam == null)
		{
			Cam = GameObject.Find("主摄像机").GetComponent<Camera>();
		}
		pidor = Object.Instantiate(okno, new Vector3(Cam.ScreenToWorldPoint(Input.mousePosition).x, Cam.ScreenToWorldPoint(Input.mousePosition).y, -9.3f), new Quaternion(0f, 0f, 0f, 0f));
		Vector2 vector = Camera.main.transform.position;
		Vector2 vector2 = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
		Vector2 vector3 = vector + vector2;
		Vector2 vector4 = vector - vector2;
		Vector2 vector5 = pidor.GetComponent<Renderer>().bounds.max;
		Vector2 vector6 = pidor.GetComponent<Renderer>().bounds.min;
		Vector3 position = pidor.transform.position;
		if (vector5.x > vector3.x)
		{
			position.x -= vector5.x - vector3.x;
		}
		if (vector5.y > vector3.y)
		{
			position.y -= vector5.y - vector3.y;
		}
		if (vector6.x < vector4.x)
		{
			position.x += vector4.x - vector6.x;
		}
		if (vector6.y < vector4.y)
		{
			position.y += vector4.y - vector6.y;
		}
		position.z = -9.3f;
		pidor.transform.position = position;
		if (!needAutoText)
		{
			if (numString > 0)
			{
				pidor.transform.Find("Text").GetComponent<TextMesh>().text = GlobalScript.inst.other_text[numString].Replace("{0}", "\n");
			}
			else if (PlayerPrefs.GetInt("language") == 0)
			{
				text_en = text_en.Replace("|", "\n");
				pidor.transform.Find("Text").GetComponent<TextMesh>().text = text_en;
			}
			else
			{
				this.text = this.text.Replace("|", "\n");
				pidor.transform.Find("Text").GetComponent<TextMesh>().text = this.text;
			}
		}
		else if (numString > 0)
		{
			float num = pidor.transform.transform.GetChild(0).localScale.x / 0.3689629f;
			int stroki = 0;
			string text = Text(GlobalScript.inst.other_text[numString].Replace("{0}", "|"), 41f * num, out stroki);
			pidor.transform.GetChild(0).GetComponent<TextMesh>().text = text;
			t = pidor.transform.GetChild(0).gameObject;
			float y = pidor.transform.localScale.y;
			pidor.transform.localScale = new Vector3(pidor.transform.localScale.x, 0.35f * (float)stroki, pidor.transform.localScale.z);
			y /= pidor.transform.localScale.y;
			t.transform.localScale = new Vector3(t.transform.localScale.x, t.transform.localScale.y * y, t.transform.localScale.z);
		}
		else if (PlayerPrefs.GetInt("language") == 0)
		{
			float num2 = pidor.transform.transform.GetChild(0).localScale.x / 0.3689629f;
			int stroki2 = 0;
			string text2 = Text(text_en, 41f * num2, out stroki2);
			pidor.transform.GetChild(0).GetComponent<TextMesh>().text = text2;
			t = pidor.transform.GetChild(0).gameObject;
			float y2 = pidor.transform.localScale.y;
			pidor.transform.localScale = new Vector3(pidor.transform.localScale.x, 0.35f * (float)stroki2, pidor.transform.localScale.z);
			y2 /= pidor.transform.localScale.y;
			t.transform.localScale = new Vector3(t.transform.localScale.x, t.transform.localScale.y * y2, t.transform.localScale.z);
		}
		else
		{
			float num3 = pidor.transform.transform.GetChild(0).localScale.x / 0.3689629f;
			int stroki3 = 0;
			string text3 = Text(this.text, 41f * num3, out stroki3);
			pidor.transform.GetChild(0).GetComponent<TextMesh>().text = text3;
			t = pidor.transform.GetChild(0).gameObject;
			float y3 = pidor.transform.localScale.y;
			pidor.transform.localScale = new Vector3(pidor.transform.localScale.x, 0.35f * (float)stroki3, pidor.transform.localScale.z);
			y3 /= pidor.transform.localScale.y;
			t.transform.localScale = new Vector3(t.transform.localScale.x, t.transform.localScale.y * y3, t.transform.localScale.z);
		}
		pidor.GetComponent<SizeScript_PopUp>().SizeSc();
	}

	private string Text(string text, float col, out int stroki)
	{
		int num = 0;
		stroki = 1;
		string text2 = "";
		text = text.Replace("<color=green>", "♔");
		text = text.Replace("<color=red>", "♕");
		text = text.Replace("<color=yellow>", "♖");
		text = text.Replace("<color=brown>", "♗");
		text = text.Replace("<color=fuchsia>", "♘");
		text = text.Replace("<color=lime>", "♙");
		text = text.Replace("<color=cyan>", "♚");
		text = text.Replace("<color=orange>", "♛");
		text = text.Replace("</color>", "♜");
		text = text.Replace('\n', '|');
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == char.Parse("|"))
			{
				num = 0;
				text2 += "\n";
				stroki++;
			}
			else if ((float)num >= col)
			{
				if (text[i] == char.Parse(" "))
				{
					num = 0;
					text2 += "\n";
					stroki++;
					continue;
				}
				text2 += text[i];
				for (int num2 = i; num2 >= 0; num2--)
				{
					if (text2[num2] == char.Parse(" "))
					{
						text2 = text2.Substring(0, num2) + "\n" + text2.Substring(num2 + 1, text2.Length - 1 - (num2 + 1) + 1);
						stroki++;
						num = text2.Length - 1 - (num2 + 1) + 1;
						break;
					}
				}
			}
			else
			{
				text2 += text[i];
				num++;
			}
		}
		text2 = text2.Replace("♔", "<color=green>");
		text2 = text2.Replace("♕", "<color=red>");
		text2 = text2.Replace("♖", "<color=yellow>");
		text2 = text2.Replace("♗", "<color=brown>");
		text2 = text2.Replace("♘", "<color=fuchsia>");
		text2 = text2.Replace("♙", "<color=lime>");
		text2 = text2.Replace("♚", "<color=cyan>");
		text2 = text2.Replace("♛", "<color=orange>");
		return text2.Replace("♜", "</color>");
	}

	public void OnMouseExit()
	{
		if (!nonono)
		{
			Object.Destroy(pidor);
		}
		if (needAutoText)
		{
			Object.Destroy(t);
		}
	}
}
