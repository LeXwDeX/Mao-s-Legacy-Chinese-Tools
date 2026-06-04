using System.Collections;
using TMPro;
using UnityEngine;

public class EnvMapAnimator : MonoBehaviour
{
	public Vector3 RotationSpeeds;

	private TMP_Text m_textMeshPro;

	private Material m_material;

	private void Awake()
	{
		m_textMeshPro = GetComponent<TMP_Text>();
		m_material = m_textMeshPro.fontSharedMaterial;
	}

	private IEnumerator Start()
	{
		Matrix4x4 matrix = default(Matrix4x4);
		while (true)
		{
			matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * RotationSpeeds.x, Time.time * RotationSpeeds.y, Time.time * RotationSpeeds.z), Vector3.one);
			m_material.SetMatrix("_EnvMatrix", matrix);
			yield return null;
		}
	}
}
