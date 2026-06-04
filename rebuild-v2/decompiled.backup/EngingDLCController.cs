using System;
using System.IO;
using EndingsDLCDraft;
using UnityEngine;

public class EngingDLCController : MonoBehaviour
{
	public string folder_name;

	public new TextMesh name;

	public TextMesh text_t;

	public Sprite on_1;

	public Sprite off_1;

	public int numberOfPage;

	public int max_pages;

	public int fromStart;

	public string fake_name;

	public string fake_text;

	public Type MyScriptType;

	public EndingsSecond[] end1;

	private float startTextPosition;

	private float startNamePosition;

	public GameObject scrollComponent;

	private void Awake()
	{
		numberOfPage = max_pages;
		startTextPosition = text_t.transform.position.y;
		startNamePosition = name.transform.position.y;
	}

	private void OnMouseDown()
	{
		numberOfPage++;
		if (numberOfPage >= max_pages)
		{
			numberOfPage = 0;
		}
		Debug.Log(numberOfPage);
		end1[numberOfPage].TextOfEnding(ref fake_name, ref fake_text);
		name.text = fake_name;
		text_t.text = Text(fake_text, 83);
	}

	private void MakeScrollable(ref int stroki)
	{
		float focus_down = text_t.characterSize * -1f * (float)stroki + startTextPosition;
		text_t.transform.position = new Vector3(text_t.transform.position.x, startTextPosition, text_t.transform.position.z);
		name.transform.position = new Vector3(name.transform.position.x, startNamePosition, name.transform.position.z);
		scrollComponent.GetComponent<ScrollScript>().MakeThings(name.transform.position.y, focus_down);
	}

	public int DirCount(DirectoryInfo d)
	{
		int num = 0;
		FileInfo[] files = d.GetFiles();
		for (int i = 0; i < files.Length; i++)
		{
			if (files[i].Extension.Contains(".cs"))
			{
				num++;
			}
		}
		return num;
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().sprite = on_1;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().sprite = off_1;
	}

	private string Text(string text, int col)
	{
		int num = 0;
		int stroki = 2;
		string text2 = "";
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == char.Parse("|"))
			{
				num = 0;
				text2 += "\n";
				stroki++;
			}
			else if (num >= col)
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
		MakeScrollable(ref stroki);
		return text2;
	}
}
