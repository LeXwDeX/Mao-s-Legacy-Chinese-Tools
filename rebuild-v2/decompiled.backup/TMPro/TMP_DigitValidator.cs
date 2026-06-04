using System;

namespace TMPro;

[Serializable]
public class TMP_DigitValidator : TMP_InputValidator
{
	public override char Validate(ref string text, ref int pos, char ch)
	{
		if (ch >= '0' && ch <= '9')
		{
			pos++;
			return ch;
		}
		return '\0';
	}
}
