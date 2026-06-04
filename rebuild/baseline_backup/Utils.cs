using UnityEngine;

public static class Utils
{
	public static int Clamp(this int a, int min, int max)
	{
		if (a < min)
		{
			return min;
		}
		if (a > max)
		{
			return max;
		}
		return a;
	}

	public static float Clamp(this float a, float min, float max)
	{
		if (a < min)
		{
			return min;
		}
		if (a > max)
		{
			return max;
		}
		return a;
	}

	public static int Lerp(int a, int b, float t)
	{
		return Mathf.RoundToInt((float)a * (1f - t) + (float)b * t);
	}

	public static float Lerp(float a, float b, float t)
	{
		return a * (1f - t) + b * t;
	}

	public static int RandomRangeFromTwoGroups(int[] minmaxes)
	{
		int num = -1;
		if (minmaxes.Length > 1)
		{
			while ((num < minmaxes[0] || num >= minmaxes[1]) && (num < minmaxes[2] || num >= minmaxes[3]))
			{
				num = Random.Range(minmaxes[0], minmaxes[3]);
			}
		}
		return num;
	}

	public static string Text(string text, int col)
	{
		int num = 0;
		string text2 = "";
		bool flag = false;
		text = text.Replace('\n', '|');
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == char.Parse("<"))
			{
				flag = true;
			}
			if (text[i] == char.Parse("|"))
			{
				num = 0;
				text2 += "\n";
			}
			else if (num >= col)
			{
				if (text[i] == char.Parse(" "))
				{
					num = 0;
					text2 += "\n";
				}
				else
				{
					text2 += text[i];
					for (int num2 = i; num2 >= 0; num2--)
					{
						if (text2[num2] == char.Parse(" "))
						{
							text2 = text2.Substring(0, num2) + "\n" + text2.Substring(num2 + 1, text2.Length - 1 - (num2 + 1) + 1);
							num = text2.Length - 1 - (num2 + 1) + 1;
							break;
						}
					}
				}
			}
			else
			{
				text2 += text[i];
				if (!flag)
				{
					num++;
				}
			}
			if (text[i] == char.Parse(">"))
			{
				flag = false;
			}
		}
		return text2;
	}
}
