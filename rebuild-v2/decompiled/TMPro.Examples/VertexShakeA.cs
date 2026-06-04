using System.Collections;
using UnityEngine;

namespace TMPro.Examples;

public class VertexShakeA : MonoBehaviour
{
	public float AngleMultiplier = 1f;

	public float SpeedMultiplier = 1f;

	public float ScaleMultiplier = 1f;

	public float RotationMultiplier = 1f;

	private TMP_Text m_TextComponent;

	private bool hasTextChanged;

	private void Awake()
	{
		m_TextComponent = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
	}

	private void OnDisable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
	}

	private void Start()
	{
		StartCoroutine(AnimateVertexColors());
	}

	private void ON_TEXT_CHANGED(Object obj)
	{
		if ((bool)(obj = m_TextComponent))
		{
			hasTextChanged = true;
		}
	}

	private IEnumerator AnimateVertexColors()
	{
		m_TextComponent.ForceMeshUpdate();
		TMP_TextInfo textInfo = m_TextComponent.textInfo;
		Vector3[][] copyOfVertices = new Vector3[0][];
		hasTextChanged = true;
		while (true)
		{
			if (hasTextChanged)
			{
				if (copyOfVertices.Length < textInfo.meshInfo.Length)
				{
					copyOfVertices = new Vector3[textInfo.meshInfo.Length][];
				}
				for (int i = 0; i < textInfo.meshInfo.Length; i++)
				{
					int num = textInfo.meshInfo[i].vertices.Length;
					copyOfVertices[i] = new Vector3[num];
				}
				hasTextChanged = false;
			}
			if (textInfo.characterCount == 0)
			{
				yield return new WaitForSeconds(0.25f);
				continue;
			}
			int lineCount = textInfo.lineCount;
			for (int j = 0; j < lineCount; j++)
			{
				int firstCharacterIndex = textInfo.lineInfo[j].firstCharacterIndex;
				int lastCharacterIndex = textInfo.lineInfo[j].lastCharacterIndex;
				Vector3 vector = (textInfo.characterInfo[firstCharacterIndex].bottomLeft + textInfo.characterInfo[lastCharacterIndex].topRight) / 2f;
				Quaternion q = Quaternion.Euler(0f, 0f, Random.Range(-0.25f, 0.25f) * RotationMultiplier);
				for (int k = firstCharacterIndex; k <= lastCharacterIndex; k++)
				{
					if (textInfo.characterInfo[k].isVisible)
					{
						int materialReferenceIndex = textInfo.characterInfo[k].materialReferenceIndex;
						int vertexIndex = textInfo.characterInfo[k].vertexIndex;
						Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
						copyOfVertices[materialReferenceIndex][vertexIndex] = vertices[vertexIndex] - vector;
						copyOfVertices[materialReferenceIndex][vertexIndex + 1] = vertices[vertexIndex + 1] - vector;
						copyOfVertices[materialReferenceIndex][vertexIndex + 2] = vertices[vertexIndex + 2] - vector;
						copyOfVertices[materialReferenceIndex][vertexIndex + 3] = vertices[vertexIndex + 3] - vector;
						float num2 = Random.Range(0.995f - 0.001f * ScaleMultiplier, 1.005f + 0.001f * ScaleMultiplier);
						Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.one, q, Vector3.one * num2);
						copyOfVertices[materialReferenceIndex][vertexIndex] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex]);
						copyOfVertices[materialReferenceIndex][vertexIndex + 1] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 1]);
						copyOfVertices[materialReferenceIndex][vertexIndex + 2] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 2]);
						copyOfVertices[materialReferenceIndex][vertexIndex + 3] = matrix4x.MultiplyPoint3x4(copyOfVertices[materialReferenceIndex][vertexIndex + 3]);
						copyOfVertices[materialReferenceIndex][vertexIndex] += vector;
						copyOfVertices[materialReferenceIndex][vertexIndex + 1] += vector;
						copyOfVertices[materialReferenceIndex][vertexIndex + 2] += vector;
						copyOfVertices[materialReferenceIndex][vertexIndex + 3] += vector;
					}
				}
			}
			for (int l = 0; l < textInfo.meshInfo.Length; l++)
			{
				textInfo.meshInfo[l].mesh.vertices = copyOfVertices[l];
				m_TextComponent.UpdateGeometry(textInfo.meshInfo[l].mesh, l);
			}
			yield return new WaitForSeconds(0.1f);
		}
	}
}
