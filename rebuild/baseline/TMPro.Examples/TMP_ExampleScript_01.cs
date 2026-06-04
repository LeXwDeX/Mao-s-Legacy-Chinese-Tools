using UnityEngine;

namespace TMPro.Examples;

public class TMP_ExampleScript_01 : MonoBehaviour
{
	public enum objectType
	{
		TextMeshPro,
		TextMeshProUGUI
	}

	public objectType ObjectType;

	public bool isStatic;

	private TMP_Text m_text;

	private const string k_label = "计数为<#0080ff>{0}</color>";

	private int count;

	private void Awake()
	{
		if (ObjectType == objectType.TextMeshPro)
		{
			m_text = GetComponent<TextMeshPro>() ?? base.gameObject.AddComponent<TextMeshPro>();
		}
		else
		{
			m_text = GetComponent<TextMeshProUGUI>() ?? base.gameObject.AddComponent<TextMeshProUGUI>();
		}
		m_text.font = Resources.Load<TMP_FontAsset>("字体与材质/Anton SDF");
		m_text.fontSharedMaterial = Resources.Load<Material>("字体与材质/Anton SDF - Drop Shadow");
		m_text.fontSize = 120f;
		m_text.text = "一行<#0080ff>简单</color>的文字。";
		Vector2 preferredValues = m_text.GetPreferredValues(float.PositiveInfinity, float.PositiveInfinity);
		m_text.rectTransform.sizeDelta = new Vector2(preferredValues.x, preferredValues.y);
	}

	private void Update()
	{
		if (!isStatic)
		{
			m_text.SetText("计数为<#0080ff>{0}</color>", count % 1000);
			count++;
		}
	}
}
