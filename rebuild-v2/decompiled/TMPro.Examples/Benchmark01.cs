using System.Collections;
using UnityEngine;

namespace TMPro.Examples;

public class Benchmark01 : MonoBehaviour
{
	public int BenchmarkType;

	public TMP_FontAsset TMProFont;

	public Font TextMeshFont;

	private TextMeshPro m_textMeshPro;

	private TextContainer m_textContainer;

	private TextMesh m_textMesh;

	private const string label01 = "The <#0050FF>count is: </color>{0}";

	private const string label02 = "The <color=#0050FF>count is: </color>";

	private Material m_material01;

	private Material m_material02;

	private IEnumerator Start()
	{
		if (BenchmarkType == 0)
		{
			m_textMeshPro = base.gameObject.AddComponent<TextMeshPro>();
			m_textMeshPro.autoSizeTextContainer = true;
			if (TMProFont != null)
			{
				m_textMeshPro.font = TMProFont;
			}
			m_textMeshPro.fontSize = 48f;
			m_textMeshPro.alignment = TextAlignmentOptions.Center;
			m_textMeshPro.extraPadding = true;
			m_textMeshPro.enableWordWrapping = false;
			m_material01 = m_textMeshPro.font.material;
			m_material02 = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Drop Shadow");
		}
		else if (BenchmarkType == 1)
		{
			m_textMesh = base.gameObject.AddComponent<TextMesh>();
			if (TextMeshFont != null)
			{
				m_textMesh.font = TextMeshFont;
				m_textMesh.GetComponent<Renderer>().sharedMaterial = m_textMesh.font.material;
			}
			else
			{
				m_textMesh.font = Resources.Load("Fonts/ARIAL", typeof(Font)) as Font;
				m_textMesh.GetComponent<Renderer>().sharedMaterial = m_textMesh.font.material;
			}
			m_textMesh.fontSize = 48;
			m_textMesh.anchor = TextAnchor.MiddleCenter;
		}
		for (int i = 0; i <= 1000000; i++)
		{
			if (BenchmarkType == 0)
			{
				m_textMeshPro.SetText("The <#0050FF>count is: </color>{0}", i % 1000);
				if (i % 1000 == 999)
				{
					TextMeshPro textMeshPro = m_textMeshPro;
					Material fontSharedMaterial;
					if (!(m_textMeshPro.fontSharedMaterial == m_material01))
					{
						Material material = (m_textMeshPro.fontSharedMaterial = m_material01);
						fontSharedMaterial = material;
					}
					else
					{
						Material material = (m_textMeshPro.fontSharedMaterial = m_material02);
						fontSharedMaterial = material;
					}
					textMeshPro.fontSharedMaterial = fontSharedMaterial;
				}
			}
			else if (BenchmarkType == 1)
			{
				m_textMesh.text = "The <color=#0050FF>count is: </color>" + i % 1000;
			}
			yield return null;
		}
		yield return null;
	}
}
