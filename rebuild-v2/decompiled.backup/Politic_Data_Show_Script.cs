using UnityEngine;

public class Politic_Data_Show_Script : MonoBehaviour
{
	private GlobalScript global1;

	public int num;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		Update_This();
	}

	public void Update_This()
	{
		GetComponent<TextMesh>().text = GlobalScript.inst.gameState.data[num] / 10 + "." + Mathf.Abs(GlobalScript.inst.gameState.data[num] % 10);
	}
}
