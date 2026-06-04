using UnityEngine;

public class CompassScript : MonoBehaviour
{
	private void Awake()
	{
		if (!GlobalScript.inst.dlc[0] || GlobalScript.inst.gameState.gamerules[1] < 1)
		{
			base.gameObject.SetActive(value: false);
		}
		else if (GlobalScript.inst.dlc[0] && GlobalScript.inst.gameState.gamerules[1] > 0)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				base.gameObject.GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.gameState.GetCompassText();
			}
			else
			{
				base.gameObject.GetComponent<OkoshkoScript>().text = GlobalScript.inst.gameState.GetCompassText();
			}
		}
	}
}
