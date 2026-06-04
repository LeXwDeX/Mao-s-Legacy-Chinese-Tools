using System;
using System.Collections.Generic;
using Reader;

namespace LFKG;

internal class FocusReader
{
	public static Dictionary<string, FocusDesc> focuses;

	private static string[] dictionary = new string[6] { "newway", "endway", "desc", "icon", "name", "title" };

	public static Lexem CreateLexem(string text, int line)
	{
		string[] array = dictionary;
		foreach (string text2 in array)
		{
			if (text2 == text)
			{
				return new Lexem(text, text2, line);
			}
		}
		return new Lexem("", "", 0);
	}

	public static void CreateDictionary()
	{
		focuses = new Dictionary<string, FocusDesc>();
	}

	public static void ReadFocuses(string text)
	{
		List<Lexem> list = new List<Lexem>();
		string text2 = "";
		int num = 0;
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == '<')
			{
				if (!string.IsNullOrWhiteSpace(text2))
				{
					list.Add(new Lexem(text2, "text", num));
				}
				text2 = "";
				for (i++; i < text.Length && text[i] != '>'; i++)
				{
					if (text[i] == '\n')
					{
						num++;
					}
					if (text[i] != ' ')
					{
						text2 += text[i];
					}
				}
				list.Add(CreateLexem(text2, num));
				text2 = "";
			}
			else
			{
				if (text[i] == '\n')
				{
					num++;
				}
				text2 += text[i];
			}
		}
		CreateFocuses(list);
	}

	private static string NameProcessing(string text)
	{
		return text.Trim();
	}

	private static string WordProcessing(string text)
	{
		List<string> list = new List<string>();
		string[] array = text.Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			if (!string.IsNullOrWhiteSpace(array[i]))
			{
				list.Add(array[i].Trim());
			}
		}
		return string.Join(" ", list.ToArray());
	}

	public static void CreateFocuses(List<Lexem> list_lexems)
	{
		Lexem[] array = list_lexems.ToArray();
		string key = "";
		string title = "";
		string desc = "";
		string icon = "";
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i].lexem_type)
			{
			case "newway":
				_ = array[i].line;
				break;
			case "name":
				key = NameProcessing(array[i + 1].text);
				i++;
				break;
			case "title":
				title = WordProcessing(array[i + 1].text);
				i++;
				break;
			case "desc":
				desc = WordProcessing(array[i + 1].text);
				i++;
				break;
			case "icon":
				icon = WordProcessing(array[i + 1].text);
				i++;
				break;
			case "endway":
				focuses.Add(key, new FocusDesc(title, desc, icon));
				key = "";
				desc = "";
				title = "";
				icon = "";
				break;
			default:
				throw new Exception($"Неизвестный тип команды! Текст: {array[i].text}. Строка: {array[i].line}");
			}
		}
	}
}
