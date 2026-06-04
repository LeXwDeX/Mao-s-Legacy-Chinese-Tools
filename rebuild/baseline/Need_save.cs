using UnityEngine;

public class Need_save : MonoBehaviour
{
	public bool is_right;

	public bool slotPlace;

	public TextMesh text;

	private GlobalScript global1;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (!slotPlace)
		{
			Textotext();
		}
		else
		{
			TextToText();
		}
	}

	private void TextToText()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (global1.savePlace == 5)
			{
				text.text = "成就之一";
			}
			else if (global1.savePlace == 1)
			{
				text.text = "无A的第一条";
			}
			else if (global1.savePlace == 2)
			{
				text.text = "无A的第二条";
			}
			else if (global1.savePlace == 3)
			{
				text.text = "无A的第三条";
			}
			else if (global1.savePlace == 4)
			{
				text.text = "无A的第四条";
			}
		}
		else if (global1.savePlace == 5)
		{
			text.text = "С достижениями";
		}
		else if (global1.savePlace == 1)
		{
			text.text = "Первый без Д";
		}
		else if (global1.savePlace == 2)
		{
			text.text = "Второй без Д";
		}
		else if (global1.savePlace == 3)
		{
			text.text = "Третий без Д";
		}
		else if (global1.savePlace == 4)
		{
			text.text = "Четвёртый без Д";
		}
	}

	private void Textotext()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (global1.autosavej == 0)
			{
				text.text = "No";
			}
			else if (global1.autosavej == 1)
			{
				text.text = "Monthly";
			}
			else if (global1.autosavej == 2)
			{
				text.text = "半年";
			}
		}
		else if (global1.autosavej == 0)
		{
			text.text = "Нет";
		}
		else if (global1.autosavej == 1)
		{
			text.text = "Ежемес.";
		}
		else if (global1.autosavej == 2)
		{
			text.text = "Полгода";
		}
	}

	private void OnMouseDown()
	{
		if (!slotPlace)
		{
			DownToAutoSave();
		}
		else
		{
			DownToSaveSlot();
		}
	}

	private void DownToSaveSlot()
	{
		if (is_right)
		{
			if (global1.savePlace < 5)
			{
				global1.savePlace++;
			}
			else
			{
				global1.savePlace = 1;
			}
		}
		else if (global1.savePlace > 1)
		{
			global1.savePlace--;
		}
		else
		{
			global1.savePlace = 5;
		}
		PlayerPrefs.SetInt("SavePlaceNum", global1.savePlace);
		TextToText();
	}

	private void DownToAutoSave()
	{
		if (is_right)
		{
			if (global1.autosavej < 2)
			{
				global1.autosavej++;
			}
			else
			{
				global1.autosavej = 0;
			}
		}
		else if (global1.autosavej > 0)
		{
			global1.autosavej--;
		}
		else
		{
			global1.autosavej = 2;
		}
		PlayerPrefs.SetInt("SavePosition", global1.autosavej);
		Textotext();
	}
}
