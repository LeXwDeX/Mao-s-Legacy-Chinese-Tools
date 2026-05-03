using System;
using System.Collections.Generic;
using Reader;

namespace LEGK;

internal static class EventReader
{
	public static Dictionary<string, EventDesc> events;

	private static string[] dictionary = new string[10] { "newevent", "endevent", "name", "title", "desc", "icon", "option", "result", "locked", "titleresult" };

	public static void CreateDictionary()
	{
		events = new Dictionary<string, EventDesc>();
	}

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

	public static void ReadEvents(string text)
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
		CreateEvents(list);
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

	public static void CreateEvents(List<Lexem> list_lexems)
	{
		Lexem[] array = list_lexems.ToArray();
		string text = "";
		string desc = "";
		string title = "";
		string icon = "";
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i].lexem_type)
			{
			case "newevent":
				_ = array[i].line;
				break;
			case "name":
				text = NameProcessing(array[i + 1].text);
				i++;
				break;
			case "title":
				desc = WordProcessing(array[i + 1].text);
				i++;
				break;
			case "desc":
				title = WordProcessing(array[i + 1].text);
				i++;
				break;
			case "icon":
				icon = WordProcessing(array[i + 1].text);
				i++;
				break;
			case "option":
				list.Add(WordProcessing(array[i + 1].text));
				i++;
				break;
			case "result":
				list3.Add(WordProcessing(array[i + 1].text));
				i++;
				break;
			case "titleresult":
				list4.Add(WordProcessing(array[i + 1].text));
				i++;
				break;
			case "locked":
				list2.Add(WordProcessing(array[i + 1].text));
				i++;
				break;
			case "endevent":
				events.Add(text, new EventDesc(text, desc, title, icon, list.ToArray(), list3.ToArray(), list4.ToArray(), list2.ToArray()));
				text = "";
				title = "";
				desc = "";
				icon = "";
				list = new List<string>();
				list2 = new List<string>();
				list3 = new List<string>();
				list4 = new List<string>();
				break;
			default:
				throw new Exception($"Неизвестный тип команды! Текст: {array[i].text}. Строка: {array[i].line}");
			}
		}
	}
}
