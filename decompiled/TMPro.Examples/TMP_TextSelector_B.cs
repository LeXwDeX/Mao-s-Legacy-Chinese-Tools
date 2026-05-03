using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples;

public class TMP_TextSelector_B : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
{
	public RectTransform TextPopup_Prefab_01;

	private RectTransform m_TextPopup_RectTransform;

	private TextMeshProUGUI m_TextPopup_TMPComponent;

	private const string k_LinkText = "You have selected link <#ffff00>";

	private const string k_WordText = "Word Index: <#ffff00>";

	private TextMeshProUGUI m_TextMeshPro;

	private Canvas m_Canvas;

	private Camera m_Camera;

	private bool isHoveringObject;

	private int m_selectedWord = -1;

	private int m_selectedLink = -1;

	private int m_lastIndex = -1;

	private Matrix4x4 m_matrix;

	private TMP_MeshInfo[] m_cachedMeshInfoVertexData;

	private void Awake()
	{
		m_TextMeshPro = base.gameObject.GetComponent<TextMeshProUGUI>();
		m_Canvas = base.gameObject.GetComponentInParent<Canvas>();
		if (m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
		{
			m_Camera = null;
		}
		else
		{
			m_Camera = m_Canvas.worldCamera;
		}
		m_TextPopup_RectTransform = Object.Instantiate(TextPopup_Prefab_01);
		m_TextPopup_RectTransform.SetParent(m_Canvas.transform, worldPositionStays: false);
		m_TextPopup_TMPComponent = m_TextPopup_RectTransform.GetComponentInChildren<TextMeshProUGUI>();
		m_TextPopup_RectTransform.gameObject.SetActive(value: false);
	}

	private void OnEnable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
	}

	private void OnDisable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
	}

	private void ON_TEXT_CHANGED(Object obj)
	{
		if (obj == m_TextMeshPro)
		{
			m_cachedMeshInfoVertexData = m_TextMeshPro.textInfo.CopyMeshInfoVertexData();
		}
	}

	private void LateUpdate()
	{
		if (isHoveringObject)
		{
			int num = TMP_TextUtilities.FindIntersectingCharacter(m_TextMeshPro, Input.mousePosition, m_Camera, visibleOnly: true);
			if (num == -1 || num != m_lastIndex)
			{
				RestoreCachedVertexAttributes(m_lastIndex);
				m_lastIndex = -1;
			}
			if (num != -1 && num != m_lastIndex && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
			{
				m_lastIndex = num;
				int materialReferenceIndex = m_TextMeshPro.textInfo.characterInfo[num].materialReferenceIndex;
				int vertexIndex = m_TextMeshPro.textInfo.characterInfo[num].vertexIndex;
				Vector3[] vertices = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].vertices;
				Vector3 vector = (Vector2)((vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f);
				vertices[vertexIndex] -= vector;
				vertices[vertexIndex + 1] -= vector;
				vertices[vertexIndex + 2] -= vector;
				vertices[vertexIndex + 3] -= vector;
				float num2 = 1.5f;
				m_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * num2);
				vertices[vertexIndex] = m_matrix.MultiplyPoint3x4(vertices[vertexIndex]);
				vertices[vertexIndex + 1] = m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
				vertices[vertexIndex + 2] = m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
				vertices[vertexIndex + 3] = m_matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);
				vertices[vertexIndex] += vector;
				vertices[vertexIndex + 1] += vector;
				vertices[vertexIndex + 2] += vector;
				vertices[vertexIndex + 3] += vector;
				Color32 color = new Color32(byte.MaxValue, byte.MaxValue, 192, byte.MaxValue);
				Color32[] colors = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
				colors[vertexIndex] = color;
				colors[vertexIndex + 1] = color;
				colors[vertexIndex + 2] = color;
				colors[vertexIndex + 3] = color;
				TMP_MeshInfo tMP_MeshInfo = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex];
				int dst = vertices.Length - 4;
				tMP_MeshInfo.SwapVertexData(vertexIndex, dst);
				m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
			}
			int num3 = TMP_TextUtilities.FindIntersectingWord(m_TextMeshPro, Input.mousePosition, m_Camera);
			if (m_TextPopup_RectTransform != null && m_selectedWord != -1 && (num3 == -1 || num3 != m_selectedWord))
			{
				TMP_WordInfo tMP_WordInfo = m_TextMeshPro.textInfo.wordInfo[m_selectedWord];
				for (int i = 0; i < tMP_WordInfo.characterCount; i++)
				{
					int num4 = tMP_WordInfo.firstCharacterIndex + i;
					int materialReferenceIndex2 = m_TextMeshPro.textInfo.characterInfo[num4].materialReferenceIndex;
					int vertexIndex2 = m_TextMeshPro.textInfo.characterInfo[num4].vertexIndex;
					Color32[] colors2 = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex2].colors32;
					colors2[vertexIndex2 + 3] = (colors2[vertexIndex2 + 2] = (colors2[vertexIndex2 + 1] = (colors2[vertexIndex2] = colors2[vertexIndex2].Tint(1.33333f))));
				}
				m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
				m_selectedWord = -1;
			}
			if (num3 != -1 && num3 != m_selectedWord && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
			{
				m_selectedWord = num3;
				TMP_WordInfo tMP_WordInfo2 = m_TextMeshPro.textInfo.wordInfo[num3];
				for (int j = 0; j < tMP_WordInfo2.characterCount; j++)
				{
					int num5 = tMP_WordInfo2.firstCharacterIndex + j;
					int materialReferenceIndex3 = m_TextMeshPro.textInfo.characterInfo[num5].materialReferenceIndex;
					int vertexIndex3 = m_TextMeshPro.textInfo.characterInfo[num5].vertexIndex;
					Color32[] colors3 = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex3].colors32;
					colors3[vertexIndex3 + 3] = (colors3[vertexIndex3 + 2] = (colors3[vertexIndex3 + 1] = (colors3[vertexIndex3] = colors3[vertexIndex3].Tint(0.75f))));
				}
				m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
			}
			int num6 = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);
			if ((num6 == -1 && m_selectedLink != -1) || num6 != m_selectedLink)
			{
				m_TextPopup_RectTransform.gameObject.SetActive(value: false);
				m_selectedLink = -1;
			}
			if (num6 == -1 || num6 == m_selectedLink)
			{
				return;
			}
			m_selectedLink = num6;
			TMP_LinkInfo tMP_LinkInfo = m_TextMeshPro.textInfo.linkInfo[num6];
			RectTransformUtility.ScreenPointToWorldPointInRectangle(m_TextMeshPro.rectTransform, Input.mousePosition, m_Camera, out var worldPoint);
			string linkID = tMP_LinkInfo.GetLinkID();
			if (!(linkID == "id_01"))
			{
				if (linkID == "id_02")
				{
					m_TextPopup_RectTransform.position = worldPoint;
					m_TextPopup_RectTransform.gameObject.SetActive(value: true);
					m_TextPopup_TMPComponent.text = "You have selected link <#ffff00> ID 02";
				}
			}
			else
			{
				m_TextPopup_RectTransform.position = worldPoint;
				m_TextPopup_RectTransform.gameObject.SetActive(value: true);
				m_TextPopup_TMPComponent.text = "You have selected link <#ffff00> ID 01";
			}
		}
		else if (m_lastIndex != -1)
		{
			RestoreCachedVertexAttributes(m_lastIndex);
			m_lastIndex = -1;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHoveringObject = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHoveringObject = false;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void RestoreCachedVertexAttributes(int index)
	{
		if (index != -1 && index <= m_TextMeshPro.textInfo.characterCount - 1)
		{
			int materialReferenceIndex = m_TextMeshPro.textInfo.characterInfo[index].materialReferenceIndex;
			int vertexIndex = m_TextMeshPro.textInfo.characterInfo[index].vertexIndex;
			Vector3[] vertices = m_cachedMeshInfoVertexData[materialReferenceIndex].vertices;
			Vector3[] vertices2 = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].vertices;
			vertices2[vertexIndex] = vertices[vertexIndex];
			vertices2[vertexIndex + 1] = vertices[vertexIndex + 1];
			vertices2[vertexIndex + 2] = vertices[vertexIndex + 2];
			vertices2[vertexIndex + 3] = vertices[vertexIndex + 3];
			Color32[] colors = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
			Color32[] colors2 = m_cachedMeshInfoVertexData[materialReferenceIndex].colors32;
			colors[vertexIndex] = colors2[vertexIndex];
			colors[vertexIndex + 1] = colors2[vertexIndex + 1];
			colors[vertexIndex + 2] = colors2[vertexIndex + 2];
			colors[vertexIndex + 3] = colors2[vertexIndex + 3];
			Vector2[] uvs = m_cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
			Vector2[] uvs2 = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs0;
			uvs2[vertexIndex] = uvs[vertexIndex];
			uvs2[vertexIndex + 1] = uvs[vertexIndex + 1];
			uvs2[vertexIndex + 2] = uvs[vertexIndex + 2];
			uvs2[vertexIndex + 3] = uvs[vertexIndex + 3];
			Vector2[] uvs3 = m_cachedMeshInfoVertexData[materialReferenceIndex].uvs2;
			Vector2[] uvs4 = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs2;
			uvs4[vertexIndex] = uvs3[vertexIndex];
			uvs4[vertexIndex + 1] = uvs3[vertexIndex + 1];
			uvs4[vertexIndex + 2] = uvs3[vertexIndex + 2];
			uvs4[vertexIndex + 3] = uvs3[vertexIndex + 3];
			int num = (vertices.Length / 4 - 1) * 4;
			vertices2[num] = vertices[num];
			vertices2[num + 1] = vertices[num + 1];
			vertices2[num + 2] = vertices[num + 2];
			vertices2[num + 3] = vertices[num + 3];
			colors2 = m_cachedMeshInfoVertexData[materialReferenceIndex].colors32;
			Color32[] colors3 = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
			colors3[num] = colors2[num];
			colors3[num + 1] = colors2[num + 1];
			colors3[num + 2] = colors2[num + 2];
			colors3[num + 3] = colors2[num + 3];
			uvs = m_cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
			Vector2[] uvs5 = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs0;
			uvs5[num] = uvs[num];
			uvs5[num + 1] = uvs[num + 1];
			uvs5[num + 2] = uvs[num + 2];
			uvs5[num + 3] = uvs[num + 3];
			uvs3 = m_cachedMeshInfoVertexData[materialReferenceIndex].uvs2;
			Vector2[] uvs6 = m_TextMeshPro.textInfo.meshInfo[materialReferenceIndex].uvs2;
			uvs6[num] = uvs3[num];
			uvs6[num + 1] = uvs3[num + 1];
			uvs6[num + 2] = uvs3[num + 2];
			uvs6[num + 3] = uvs3[num + 3];
			m_TextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
		}
	}
}
