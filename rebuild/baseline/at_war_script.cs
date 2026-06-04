using UnityEngine;

public class at_war_script : MonoBehaviour
{
	private GlobalScript global1;

	public Sprite war;

	public bool special;

	public int this_num;

	public void Repaint()
	{
		if (global1 == null)
		{
			global1 = GlobalScript.inst;
		}
		if (!special)
		{
			if (GlobalScript.inst.gameState.ingamewars[this_num].is_going)
			{
				GetComponent<SpriteRenderer>().sprite = war;
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = null;
			}
		}
		else if ((this_num == -1 && GlobalScript.inst.gameState.iranrev) || (this_num == -2 && GlobalScript.inst.gameState.war == 2) || (this_num == -3 && GlobalScript.inst.gameState.war == 1) || (this_num == -4 && GlobalScript.inst.gameState.data[37] > 0 && GlobalScript.inst.gameState.data[37] < 1000))
		{
			GetComponent<SpriteRenderer>().sprite = war;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = null;
		}
	}
}
