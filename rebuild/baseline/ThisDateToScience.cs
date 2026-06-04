using UnityEngine;

public class ThisDateToScience : MonoBehaviour
{
	private GlobalScript global1;

	public int this_year = 1989;

	private void Awake()
	{
		global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (GlobalScript.inst.gameState.data[21] < this_year)
		{
			GetComponent<OkoshkoScript>().text = "Стоимость возрастёт\nиз-за несоответствия времени:\n" + (this_year - GlobalScript.inst.gameState.data[21]) * 2 + " из бюджета";
			GetComponent<OkoshkoScript>().text_en = "The price will be raised\ndue to the year mismatch:\n" + (this_year - GlobalScript.inst.gameState.data[21]) * 2 + " 来自预算";
		}
		else
		{
			GetComponent<OkoshkoScript>().text = "Стоимость:\n1 из бюджета";
			GetComponent<OkoshkoScript>().text_en = "The price:\n1 来自预算";
		}
	}
}
