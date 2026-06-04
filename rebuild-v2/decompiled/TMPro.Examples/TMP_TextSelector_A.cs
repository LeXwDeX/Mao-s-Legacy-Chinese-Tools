using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples;

public class TMP_TextSelector_A : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private TextMeshPro m_TextMeshPro;

	private Camera m_Camera;

	private bool m_isHoveringObject;

	private int m_selectedLink = -1;

	private int m_lastCharIndex = -1;

	private int m_lastWordIndex = -1;

	private void Awake()
	{
		m_TextMeshPro = base.gameObject.GetComponent<TextMeshPro>();
		m_Camera = Camera.main;
		m_TextMeshPro.ForceMeshUpdate();
	}

	private void LateUpdate()
	{
		m_isHoveringObject = false;
		if (TMP_TextUtilities.IsIntersectingRectTransform(m_TextMeshPro.rectTransform, Input.mousePosition, Camera.main))
		{
			m_isHoveringObject = true;
		}
		if (!m_isHoveringObject)
		{
			return;
		}
		int num = TMP_TextUtilities.FindIntersectingCharacter(m_TextMeshPro, Input.mousePosition, Camera.main, visibleOnly: true);
		if (num != -1 && num != m_lastCharIndex && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			m_lastCharIndex = num;
			int materialReferenceIndex = m_TextMeshPro.textInfo.characterInfo[num].materialReferenceIndex;
			int vertexIndex = m_TextMeshPro.textInfo.characterInfo[num].vertexIndex;
			Color32 color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
			Color32[] colors = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
			colors[vertexIndex] = color;
			colors[vertexIndex + 1] = color;
			colors[vertexIndex + 2] = color;
			colors[vertexIndex + 3] = color;
			m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].mesh.colors32 = colors;
		}
		int num2 = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);
		if ((num2 == -1 && m_selectedLink != -1) || num2 != m_selectedLink)
		{
			m_selectedLink = -1;
		}
		if (num2 != -1 && num2 != m_selectedLink)
		{
			m_selectedLink = num2;
			TMP_LinkInfo tMP_LinkInfo = m_TextMeshPro.textInfo.linkInfo[num2];
			RectTransformUtility.ScreenPointToWorldPointInRectangle(m_TextMeshPro.rectTransform, Input.mousePosition, m_Camera, out var _);
			string linkID = tMP_LinkInfo.GetLinkID();
			if (!(linkID == "id_01"))
			{
				_ = linkID == "id_02";
			}
		}
		int num3 = TMP_TextUtilities.FindIntersectingWord(m_TextMeshPro, Input.mousePosition, Camera.main);
		if (num3 != -1 && num3 != m_lastWordIndex)
		{
			m_lastWordIndex = num3;
			TMP_WordInfo tMP_WordInfo = m_TextMeshPro.textInfo.wordInfo[num3];
			Vector3 position = m_TextMeshPro.transform.TransformPoint(m_TextMeshPro.textInfo.characterInfo[tMP_WordInfo.firstCharacterIndex].bottomLeft);
			position = Camera.main.WorldToScreenPoint(position);
			Color32[] colors2 = m_TextMeshPro.textInfo.meshInfo[0].colors32;
			Color32 color2 = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
			for (int i = 0; i < tMP_WordInfo.characterCount; i++)
			{
				int vertexIndex2 = m_TextMeshPro.textInfo.characterInfo[tMP_WordInfo.firstCharacterIndex + i].vertexIndex;
				colors2[vertexIndex2] = color2;
				colors2[vertexIndex2 + 1] = color2;
				colors2[vertexIndex2 + 2] = color2;
				colors2[vertexIndex2 + 3] = color2;
			}
			m_TextMeshPro.mesh.colors32 = colors2;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnPointerEnter()");
		m_isHoveringObject = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnPointerExit()");
		m_isHoveringObject = false;
	}
}
