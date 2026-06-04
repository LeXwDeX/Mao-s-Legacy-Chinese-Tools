using UnityEngine;

public class englishimages : MonoBehaviour
{
	public string this_scene;

	public Sprite new_game_nenavel;

	public Sprite load_nenavel;

	public Sprite exit_nenavel;

	public Sprite authores_nenavel;

	private GlobalScript global1;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		GlobalScript.inst.gameState.turn_on = true;
		if (!PlayerPrefs.HasKey("language"))
		{
			PlayerPrefs.SetInt("language", 0);
		}
		if (PlayerPrefs.HasKey("language") && PlayerPrefs.GetInt("language") == 0)
		{
			GameObject.Find("NG1").GetComponent<SpriteRenderer>().sprite = new_game_nenavel;
			GameObject.Find("ZAG1").GetComponent<SpriteRenderer>().sprite = load_nenavel;
			GameObject.Find("VYH1").GetComponent<SpriteRenderer>().sprite = exit_nenavel;
			GameObject.Find("AVT1").GetComponent<SpriteRenderer>().sprite = authores_nenavel;
		}
	}
}
