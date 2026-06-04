namespace Reader;

internal class Lexem
{
	public string text;

	public string lexem_type;

	public int line;

	public Lexem(string text, string lexem_type, int line)
	{
		this.text = text;
		this.lexem_type = lexem_type;
		this.line = line;
	}
}
