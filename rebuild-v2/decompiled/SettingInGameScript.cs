using UnityEngine;

public class SettingInGameScript : MonoBehaviour
{
	private GlobalScript global1;

	public GameObject Exit;

	public GameObject NeedToDestroy1;

	public GameObject NeedToDestroy2;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (!GlobalScript.inst.gameState.turn_on)
		{
			Exit.GetComponent<LoadScript>().new_scene = "Diplomacy";
			Object.Destroy(NeedToDestroy1);
			Object.Destroy(NeedToDestroy2);
		}
	}
}
