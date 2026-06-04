using UnityEngine;

public class Crushko : MonoBehaviour
{
	public float[] _DegEnd;

	public float _RStart;

	public float _REnd;

	public Color[] _Col;

	public float _OutLineFallDeg;

	public float _DegOutLine;

	public float _ROutLine;

	public float _OutLineFall = 0.5f;

	private GlobalScript global1;

	private void Awake()
	{
		global1 = GlobalScript.inst;
		Repaint();
	}

	public void Repaint()
	{
		float[] array = new float[6];
		float num = GlobalScript.inst.gameState.party_number[0] + GlobalScript.inst.gameState.party_number[1] + GlobalScript.inst.gameState.party_number[2] + GlobalScript.inst.gameState.party_number[3] + GlobalScript.inst.gameState.party_number[4] + GlobalScript.inst.gameState.data[106];
		for (int i = 0; i < 5; i++)
		{
			array[i] = 360f * (float)GlobalScript.inst.gameState.party_number[i] / num;
		}
		array[5] = 360f * (float)GlobalScript.inst.gameState.data[106] / num;
		_DegEnd[0] = array[0];
		_DegEnd[1] = array[0] + array[1];
		_DegEnd[2] = array[0] + array[1] + array[2];
		_DegEnd[3] = array[0] + array[1] + array[2] + array[3];
		_DegEnd[4] = array[0] + array[1] + array[2] + array[3] + array[4];
		_DegEnd[5] = array[0] + array[1] + array[2] + array[3] + array[4] + array[5];
		for (int j = 0; j < GlobalScript.inst.gameState.is_party_enabled.Length; j++)
		{
			if (!GlobalScript.inst.gameState.is_party_enabled[j])
			{
				_DegEnd[j] = -1f;
			}
		}
		if (GlobalScript.inst.gameState.data[106] <= 0)
		{
			_DegEnd[5] = -1f;
		}
		for (int k = 0; k < 6; k++)
		{
			GetComponent<SpriteRenderer>().sharedMaterial.SetColor($"_Color{k}", _Col[k]);
			GetComponent<SpriteRenderer>().sharedMaterial.SetFloat($"_DegColor{k}", _DegEnd[k]);
			if (GlobalScript.inst.gameState.data[53] >= 4)
			{
				_DegEnd[k] = -1f;
			}
			GetComponent<SpriteRenderer>().sharedMaterial.SetFloat($"_DegBorder{k}", _DegEnd[k]);
		}
		GetComponent<SpriteRenderer>().sharedMaterial.SetFloat("_RadiusMin", _RStart);
		GetComponent<SpriteRenderer>().sharedMaterial.SetFloat("_RadiusMax", _REnd);
		GetComponent<SpriteRenderer>().sharedMaterial.SetFloat("_BorderWidthDeg", _OutLineFallDeg);
		GetComponent<SpriteRenderer>().sharedMaterial.SetFloat("_RadiusBorderWidth", _ROutLine);
	}
}
