using UnityEngine;

public class Politic_Data_Show_cel : MonoBehaviour
{
	private GlobalScript global1;

	public int num;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		Update_This();
	}

	private void Update_This()
	{
		GetComponent<TextMesh>().text = GlobalScript.inst.gameState.data[num].ToString();
	}
}
