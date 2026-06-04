using System;

[Serializable]
public class Modifiers
{
	public bool active;

	public bool turned;

	public int level;

	public Modifiers(bool turned = true, bool active = false, int row = 0)
	{
		this.turned = turned;
		level = row;
		this.active = active;
	}
}
