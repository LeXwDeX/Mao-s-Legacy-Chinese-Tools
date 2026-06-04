using UnityEngine;

namespace TMPro.Examples;

public class SimpleScript : MonoBehaviour
{
	private TextMeshPro m_textMeshPro;

	private const string label = "The <#0050FF>count is: </color>{0:2}";

	private float m_frame;

	private void Start()
	{
		m_textMeshPro = base.gameObject.AddComponent<TextMeshPro>();
		m_textMeshPro.autoSizeTextContainer = true;
		m_textMeshPro.fontSize = 48f;
		m_textMeshPro.alignment = TextAlignmentOptions.Center;
		m_textMeshPro.enableWordWrapping = false;
	}

	private void Update()
	{
		m_textMeshPro.SetText("The <#0050FF>count is: </color>{0:2}", m_frame % 1000f);
		m_frame += 1f * Time.deltaTime;
	}
}
