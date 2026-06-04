using System;

[Serializable]
public class PoliticalComposition
{
	public LeftComposition Left;

	public RightComposition Right;

	public PoliticalComposition(int popular_left, int popular_right)
	{
		Left = new LeftComposition(popular_left);
		Right = new RightComposition(popular_right);
	}
}
