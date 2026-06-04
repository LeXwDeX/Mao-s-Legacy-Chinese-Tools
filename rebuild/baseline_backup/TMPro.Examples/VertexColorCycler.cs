using System.Collections;
using UnityEngine;

namespace TMPro.Examples;

public class VertexColorCycler : MonoBehaviour
{
	private TMP_Text m_TextComponent;

	private void Awake()
	{
		m_TextComponent = GetComponent<TMP_Text>();
	}

	private void Start()
	{
		StartCoroutine(AnimateVertexColors());
	}

	private IEnumerator AnimateVertexColors()
	{
		m_TextComponent.ForceMeshUpdate();
		TMP_TextInfo textInfo = m_TextComponent.textInfo;
		int currentCharacter = 0;
		_ = (Color32)m_TextComponent.color;
		while (true)
		{
			int characterCount = textInfo.characterCount;
			if (characterCount == 0)
			{
				yield return new WaitForSeconds(0.25f);
				continue;
			}
			int materialReferenceIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
			Color32[] colors = textInfo.meshInfo[materialReferenceIndex].colors32;
			int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;
			if (textInfo.characterInfo[currentCharacter].isVisible)
			{
				colors[vertexIndex + 3] = (colors[vertexIndex + 2] = (colors[vertexIndex + 1] = (colors[vertexIndex] = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue))));
				m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
			}
			currentCharacter = (currentCharacter + 1) % characterCount;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
