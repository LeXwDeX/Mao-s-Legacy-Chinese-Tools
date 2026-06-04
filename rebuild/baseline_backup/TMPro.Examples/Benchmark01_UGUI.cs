using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples;

public class Benchmark01_UGUI : MonoBehaviour
{
	public int BenchmarkType;

	public Canvas canvas;

	public TMP_FontAsset TMProFont;

	public Font TextMeshFont;

	private TextMeshProUGUI m_textMeshPro;

	private Text m_textMesh;

	private const string label01 = "The <#0050FF>count is: </color>";

	private const string label02 = "The <color=#0050FF>count is: </color>";

	private Material m_material01;

	private Material m_material02;

	private IEnumerator Start()
	{
		if (BenchmarkType == 0)
		{
			m_textMeshPro = base.gameObject.AddComponent<TextMeshProUGUI>();
			if (TMProFont != null)
			{
				m_textMeshPro.font = TMProFont;
			}
			m_textMeshPro.fontSize = 48f;
			m_textMeshPro.alignment = TextAlignmentOptions.Center;
			m_textMeshPro.extraPadding = true;
			m_material01 = m_textMeshPro.font.material;
			m_material02 = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - BEVEL");
		}
		else if (BenchmarkType == 1)
		{
			m_textMesh = base.gameObject.AddComponent<Text>();
			if (TextMeshFont != null)
			{
				m_textMesh.font = TextMeshFont;
			}
			m_textMesh.fontSize = 48;
			m_textMesh.alignment = TextAnchor.MiddleCenter;
		}
		for (int i = 0; i <= 1000000; i++)
		{
			if (BenchmarkType == 0)
			{
				m_textMeshPro.text = "The <#0050FF>count is: </color>" + i % 1000;
				if (i % 1000 == 999)
				{
					TextMeshProUGUI textMeshPro = m_textMeshPro;
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
