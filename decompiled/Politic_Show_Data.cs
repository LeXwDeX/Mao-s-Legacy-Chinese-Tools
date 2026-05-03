using UnityEngine;

public class Politic_Show_Data : MonoBehaviour
{
	private TextMesh text;

	private GlobalScript global1;

	public int num;

	public void Repaint()
	{
		text.text = $"{(float)GlobalScript.inst.gameState.data[num] / 10f:F1}";
	}

	private void Start()
	{
		global1 = GlobalScript.inst;
		text = GetComponent<TextMesh>();
		Repaint();
	}
}
