using System;

[Serializable]
public class Insider
{
	public string name;

	public int influence;

	public Insider(string name, int sup)
	{
		this.name = name;
		influence = sup;
	}
}
