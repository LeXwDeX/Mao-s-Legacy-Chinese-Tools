using UnityEngine;

public class Stasi_script : MonoBehaviour
{
	private GameObject pidor;

	private GlobalScript global1;

	public string text;

	public string text_en;

	public GameObject okno;

	public Camera Cam;

	private void Start()
	{
		Cam = GameObject.Find("主摄像机").GetComponent<Camera>();
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	private void OnMouseEnter()
	{
		if (Cam == null)
		{
			Cam = GameObject.Find("主摄像机").GetComponent<Camera>();
		}
		pidor = Object.Instantiate(okno, new Vector3(Cam.ScreenToWorldPoint(Input.mousePosition).x, Cam.ScreenToWorldPoint(Input.mousePosition).y, -9.6f), new Quaternion(0f, 0f, 0f, 0f));
		if (PlayerPrefs.GetInt("language") == 0)
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text = text_en + ": " + (((GlobalScript.inst.gameState.data[9] < 0) ? "-" : "") + GlobalScript.inst.gameState.data[9] / 10).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.data[9] % 10);
		}
		else
		{
			pidor.transform.Find("Text").GetComponent<TextMesh>().text = text + ": " + (((GlobalScript.inst.gameState.data[9] < 0) ? "-" : "") + GlobalScript.inst.gameState.data[9] / 10).ToString() + "." + Mathf.Abs(GlobalScript.inst.gameState.data[9] % 10);
		}
	}

	public void OnMouseExit()
	{
		Object.Destroy(pidor);
	}
}
