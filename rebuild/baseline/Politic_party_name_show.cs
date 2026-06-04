using UnityEngine;

public class Politic_party_name_show : MonoBehaviour
{
	private GlobalScript global1;

	public int this_number;

	public void Repaint()
	{
		if (GlobalScript.inst.gameState.data[15] <= 7)
		{
			GetComponent<TextMesh>().text = GlobalScript.inst.gameState.party_name[this_number];
			GetComponent<OkoshkoScript>().text = GlobalScript.inst.gameState.party_name[this_number];
			GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.gameState.party_name[this_number];
		}
		else
		{
			GetComponent<TextMesh>().text = GlobalScript.inst.gameState.party_name[this_number + 5];
			GetComponent<OkoshkoScript>().text = GlobalScript.inst.gameState.party_name[this_number + 10];
			GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.gameState.party_name[this_number + 10];
		}
	}

	private void Awake()
	{
		global1 = GlobalScript.inst;
		if (GlobalScript.inst.gameState.data[15] <= 7)
		{
			GetComponent<TextMesh>().text = GlobalScript.inst.gameState.party_name[this_number];
			GetComponent<OkoshkoScript>().text = GlobalScript.inst.gameState.party_name[this_number];
			GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.gameState.party_name[this_number];
		}
		else
		{
			GetComponent<TextMesh>().text = GlobalScript.inst.gameState.party_name[this_number + 5];
			GetComponent<OkoshkoScript>().text = GlobalScript.inst.gameState.party_name[this_number + 10];
			GetComponent<OkoshkoScript>().text_en = GlobalScript.inst.gameState.party_name[this_number + 10];
		}
	}
}
