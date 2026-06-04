using System;

[Serializable]
public class Empire
{
	public string active_tree;

	public Leader[] leaders;

	public int[] modifies;

	public Insider[] insiders;

	public int money;

	public int power;

	public int relations;

	public int now_leader;

	public bool historical = true;

	public bool agressive;

	public bool reformist;

	public int now_focus = -1;

	public int now_layer;

	public void MakeHistorical()
	{
		historical = true;
		agressive = false;
		reformist = false;
	}

	public void MakeAgressive()
	{
		historical = false;
		agressive = true;
	}

	public void MakePeaceful()
	{
		historical = false;
		agressive = false;
	}

	public void MakeReformist()
	{
		historical = false;
		reformist = true;
	}

	public void MakeConservative()
	{
		historical = false;
		reformist = false;
	}
}
