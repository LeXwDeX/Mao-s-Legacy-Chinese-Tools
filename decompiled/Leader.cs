using System;

[Serializable]
public class Leader
{
	public string leader_name;

	public int support;

	public Leader(string name, int sup)
	{
		leader_name = name;
		support = sup;
	}
}
