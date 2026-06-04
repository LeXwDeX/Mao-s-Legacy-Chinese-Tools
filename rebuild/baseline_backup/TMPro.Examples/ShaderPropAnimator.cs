using System.Collections;
using UnityEngine;

namespace TMPro.Examples;

public class ShaderPropAnimator : MonoBehaviour
{
	private Renderer m_Renderer;

	private Material m_Material;

	public AnimationCurve GlowCurve;

	public float m_frame;

	private void Awake()
	{
		m_Renderer = GetComponent<Renderer>();
		m_Material = m_Renderer.material;
	}

	private void Start()
	{
		StartCoroutine(AnimateProperties());
	}

	private IEnumerator AnimateProperties()
	{
		m_frame = Random.Range(0f, 1f);
		while (true)
		{
			float value = GlowCurve.Evaluate(m_frame);
			m_Material.SetFloat(ShaderUtilities.ID_GlowPower, value);
			m_frame += Time.deltaTime * Random.Range(0.2f, 0.3f);
			yield return new WaitForEndOfFrame();
		}
	}
}
