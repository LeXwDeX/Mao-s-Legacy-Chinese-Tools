using System.Collections;
using UnityEngine;

namespace TMPro.Examples;

public class VertexJitter : MonoBehaviour
{
	private struct VertexAnim
	{
		public float angleRange;

		public float angle;

		public float speed;
	}

	public float AngleMultiplier = 1f;

	public float SpeedMultiplier = 1f;

	public float CurveScale = 1f;

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
		if (obj == m_TextComponent)
		{
			hasTextChanged = true;
		}
	}

	private IEnumerator AnimateVertexColors()
	{
		m_TextComponent.ForceMeshUpdate();
		TMP_TextInfo textInfo = m_TextComponent.textInfo;
		int loopCount = 0;
		hasTextChanged = true;
		VertexAnim[] vertexAnim = new VertexAnim[1024];
		for (int i = 0; i < 1024; i++)
		{
			vertexAnim[i].angleRange = Random.Range(10f, 25f);
			vertexAnim[i].speed = Random.Range(1f, 3f);
		}
		TMP_MeshInfo[] cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
		while (true)
		{
			if (hasTextChanged)
			{
				cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
				hasTextChanged = false;
			}
			int characterCount = textInfo.characterCount;
			if (characterCount == 0)
			{
				yield return new WaitForSeconds(0.25f);
				continue;
			}
			for (int j = 0; j < characterCount; j++)
			{
				if (textInfo.characterInfo[j].isVisible)
				{
					VertexAnim vertexAnim2 = vertexAnim[j];
					int materialReferenceIndex = textInfo.characterInfo[j].materialReferenceIndex;
					int vertexIndex = textInfo.characterInfo[j].vertexIndex;
					Vector3[] vertices = cachedMeshInfo[materialReferenceIndex].vertices;
					Vector3 vector = (Vector2)((vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f);
					Vector3[] vertices2 = textInfo.meshInfo[materialReferenceIndex].vertices;
					vertices2[vertexIndex] = vertices[vertexIndex] - vector;
					vertices2[vertexIndex + 1] = vertices[vertexIndex + 1] - vector;
					vertices2[vertexIndex + 2] = vertices[vertexIndex + 2] - vector;
					vertices2[vertexIndex + 3] = vertices[vertexIndex + 3] - vector;
					vertexAnim2.angle = Mathf.SmoothStep(0f - vertexAnim2.angleRange, vertexAnim2.angleRange, Mathf.PingPong((float)loopCount / 25f * vertexAnim2.speed, 1f));
					Matrix4x4 matrix4x = Matrix4x4.TRS(new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f), 0f) * CurveScale, Quaternion.Euler(0f, 0f, Random.Range(-5f, 5f) * AngleMultiplier), Vector3.one);
					vertices2[vertexIndex] = matrix4x.MultiplyPoint3x4(vertices2[vertexIndex]);
					vertices2[vertexIndex + 1] = matrix4x.MultiplyPoint3x4(vertices2[vertexIndex + 1]);
					vertices2[vertexIndex + 2] = matrix4x.MultiplyPoint3x4(vertices2[vertexIndex + 2]);
					vertices2[vertexIndex + 3] = matrix4x.MultiplyPoint3x4(vertices2[vertexIndex + 3]);
					vertices2[vertexIndex] += vector;
					vertices2[vertexIndex + 1] += vector;
					vertices2[vertexIndex + 2] += vector;
					vertices2[vertexIndex + 3] += vector;
					vertexAnim[j] = vertexAnim2;
				}
			}
			for (int k = 0; k < textInfo.meshInfo.Length; k++)
			{
				textInfo.meshInfo[k].mesh.vertices = textInfo.meshInfo[k].vertices;
				m_TextComponent.UpdateGeometry(textInfo.meshInfo[k].mesh, k);
			}
			loopCount++;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
