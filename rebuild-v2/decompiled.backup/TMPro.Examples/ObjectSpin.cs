using UnityEngine;

namespace TMPro.Examples;

public class ObjectSpin : MonoBehaviour
{
	public enum MotionType
	{
		Rotation,
		BackAndForth,
		Translation
	}

	public float SpinSpeed = 5f;

	public int RotationRange = 15;

	private Transform m_transform;

	private float m_time;

	private Vector3 m_prevPOS;

	private Vector3 m_initial_Rotation;

	private Vector3 m_initial_Position;

	private Color32 m_lightColor;

	private int frames;

	public MotionType Motion;

	private void Awake()
	{
		m_transform = base.transform;
		m_initial_Rotation = m_transform.rotation.eulerAngles;
		m_initial_Position = m_transform.position;
		Light component = GetComponent<Light>();
		m_lightColor = ((component != null) ? component.color : Color.black);
	}

	private void Update()
	{
		if (Motion == MotionType.Rotation)
		{
			m_transform.Rotate(0f, SpinSpeed * Time.deltaTime, 0f);
			return;
		}
		if (Motion == MotionType.BackAndForth)
		{
			m_time += SpinSpeed * Time.deltaTime;
			m_transform.rotation = Quaternion.Euler(m_initial_Rotation.x, Mathf.Sin(m_time) * (float)RotationRange + m_initial_Rotation.y, m_initial_Rotation.z);
			return;
		}
		m_time += SpinSpeed * Time.deltaTime;
		float x = 15f * Mathf.Cos(m_time * 0.95f);
		float z = 10f;
		float y = 0f;
		m_transform.position = m_initial_Position + new Vector3(x, y, z);
		m_prevPOS = m_transform.position;
		frames++;
	}
}
