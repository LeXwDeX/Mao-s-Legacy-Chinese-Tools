using UnityEngine;

public class BeurocratsScript : MonoBehaviour
{
	public Politic_Manager manager;

	public GlobalScript global1;

	public TextMesh this_text;

	public bool small;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		Repaint();
	}

	public void Repaint()
	{
		if (small)
		{
			int[] array = new int[3];
			for (int i = 0; i < GlobalScript.inst.gameState.politics.Length; i++)
			{
				if (GlobalScript.inst.gameState.politics_dolshnost[0] == i)
				{
					array[0] = i;
				}
				if (GlobalScript.inst.gameState.politics_dolshnost[1] == i)
				{
					array[1] = i;
				}
				if (GlobalScript.inst.gameState.politics_dolshnost[2] == i)
				{
					array[2] = i;
				}
			}
			if (GlobalScript.inst.gameState.politics_dolshnost[0] == 150)
			{
				this_text.text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2];
			}
			else if (GlobalScript.inst.gameState.politics_dolshnost[0] == 200)
			{
				this_text.text = "-";
			}
			else
			{
				this_text.text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[array[0]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[array[0]].name_2];
			}
			if (GlobalScript.inst.gameState.politics_dolshnost[1] == 150)
			{
				TextMesh textMesh = this_text;
				textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2];
			}
			else if (GlobalScript.inst.gameState.politics_dolshnost[1] == 200)
			{
				this_text.text += "\n-";
			}
			else
			{
				TextMesh textMesh = this_text;
				textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[array[1]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[array[1]].name_2];
			}
			if (GlobalScript.inst.gameState.politics_dolshnost[2] == 150)
			{
				TextMesh textMesh = this_text;
				textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2];
			}
			else if (GlobalScript.inst.gameState.politics_dolshnost[2] == 200)
			{
				this_text.text += "\n-";
			}
			else
			{
				TextMesh textMesh = this_text;
				textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[array[2]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[array[2]].name_2];
			}
			return;
		}
		int[] array2 = new int[5];
		for (int j = 0; j < GlobalScript.inst.gameState.politics.Length; j++)
		{
			if (GlobalScript.inst.gameState.politics_dolshnost[3] == j)
			{
				array2[0] = j;
			}
			if (GlobalScript.inst.gameState.politics_dolshnost[4] == j)
			{
				array2[1] = j;
			}
			if (GlobalScript.inst.gameState.politics_dolshnost[5] == j)
			{
				array2[2] = j;
			}
			if (GlobalScript.inst.gameState.politics_dolshnost[6] == j)
			{
				array2[3] = j;
			}
			if (GlobalScript.inst.gameState.politics_dolshnost[7] == j)
			{
				array2[4] = j;
			}
		}
		if (GlobalScript.inst.gameState.politics_dolshnost[3] == 150)
		{
			this_text.text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2];
		}
		else if (GlobalScript.inst.gameState.politics_dolshnost[3] == 200)
		{
			this_text.text = "-";
		}
		else
		{
			this_text.text = GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[array2[0]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[array2[0]].name_2];
		}
		if (GlobalScript.inst.gameState.politics_dolshnost[4] == 150)
		{
			TextMesh textMesh = this_text;
			textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2];
		}
		else if (GlobalScript.inst.gameState.politics_dolshnost[4] == 200)
		{
			this_text.text += "\n-";
		}
		else
		{
			TextMesh textMesh = this_text;
			textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[array2[1]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[array2[1]].name_2];
		}
		if (GlobalScript.inst.gameState.politics_dolshnost[5] == 150)
		{
			TextMesh textMesh = this_text;
			textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2];
		}
		else if (GlobalScript.inst.gameState.politics_dolshnost[5] == 200)
		{
			this_text.text += "\n-";
		}
		else
		{
			TextMesh textMesh = this_text;
			textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[array2[2]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[array2[2]].name_2];
		}
		if (GlobalScript.inst.gameState.politics_dolshnost[6] == 150)
		{
			TextMesh textMesh = this_text;
			textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2];
		}
		else if (GlobalScript.inst.gameState.politics_dolshnost[6] == 200)
		{
			this_text.text += "\n-";
		}
		else
		{
			TextMesh textMesh = this_text;
			textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[array2[3]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[array2[3]].name_2];
		}
		if (GlobalScript.inst.gameState.politics_dolshnost[7] == 150)
		{
			TextMesh textMesh = this_text;
			textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.leader.name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.leader.name_2];
		}
		else if (GlobalScript.inst.gameState.politics_dolshnost[7] == 200)
		{
			this_text.text += "\n-";
		}
		else
		{
			TextMesh textMesh = this_text;
			textMesh.text = textMesh.text + "\n" + GlobalScript.inst.gameState.names1[GlobalScript.inst.gameState.politics[array2[4]].name_1] + " " + GlobalScript.inst.gameState.names2[GlobalScript.inst.gameState.politics[array2[4]].name_2];
		}
	}
}
