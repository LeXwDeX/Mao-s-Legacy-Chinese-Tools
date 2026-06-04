using System.Collections;
using UnityEngine;

namespace TMPro.Examples;

public class TextMeshProFloatingText : MonoBehaviour
{
	public Font TheFont;

	private GameObject m_floatingText;

	private TextMeshPro m_textMeshPro;

	private TextMesh m_textMesh;

	private Transform m_transform;

	private Transform m_floatingText_Transform;

	private Transform m_cameraTransform;

	private Vector3 lastPOS = Vector3.zero;

	private Quaternion lastRotation = Quaternion.identity;

	public int SpawnType;

	private void Awake()
	{
		m_transform = base.transform;
		m_floatingText = new GameObject(base.name + " floating text");
		m_cameraTransform = Camera.main.transform;
	}

	private void Start()
	{
		if (SpawnType == 0)
		{
			m_textMeshPro = m_floatingText.AddComponent<TextMeshPro>();
			m_textMeshPro.rectTransform.sizeDelta = new Vector2(3f, 3f);
			m_floatingText_Transform = m_floatingText.transform;
			m_floatingText_Transform.position = m_transform.position + new Vector3(0f, 15f, 0f);
			m_textMeshPro.alignment = TextAlignmentOptions.Center;
			m_textMeshPro.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
			m_textMeshPro.fontSize = 24f;
			m_textMeshPro.enableKerning = false;
			m_textMeshPro.text = string.Empty;
			StartCoroutine(DisplayTextMeshProFloatingText());
		}
		else if (SpawnType == 1)
		{
			m_floatingText_Transform = m_floatingText.transform;
			m_floatingText_Transform.position = m_transform.position + new Vector3(0f, 15f, 0f);
			m_textMesh = m_floatingText.AddComponent<TextMesh>();
			m_textMesh.font = Resources.Load<Font>("Fonts/ARIAL");
			m_textMesh.GetComponent<Renderer>().sharedMaterial = m_textMesh.font.material;
			m_textMesh.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
			m_textMesh.anchor = TextAnchor.LowerCenter;
			m_textMesh.fontSize = 24;
			StartCoroutine(DisplayTextMeshFloatingText());
		}
		else
		{
			_ = SpawnType;
			_ = 2;
		}
	}

	public IEnumerator DisplayTextMeshProFloatingText()
	{
		float CountDuration = 2f;
		float starting_Count = Random.Range(5f, 20f);
		float current_Count = starting_Count;
		Vector3 start_pos = m_floatingText_Transform.position;
		Color32 start_color = m_textMeshPro.color;
		float alpha = 255f;
		float fadeDuration = 3f / starting_Count * CountDuration;
		while (current_Count > 0f)
		{
			current_Count -= Time.deltaTime / CountDuration * starting_Count;
			if (current_Count <= 3f)
			{
				alpha = Mathf.Clamp(alpha - Time.deltaTime / fadeDuration * 255f, 0f, 255f);
			}
			m_textMeshPro.text = ((int)current_Count).ToString();
			m_textMeshPro.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);
			m_floatingText_Transform.position += new Vector3(0f, starting_Count * Time.deltaTime, 0f);
			if (!lastPOS.Compare(m_cameraTransform.position, 1000) || !lastRotation.Compare(m_cameraTransform.rotation, 1000))
			{
				lastPOS = m_cameraTransform.position;
				lastRotation = m_cameraTransform.rotation;
				m_floatingText_Transform.rotation = lastRotation;
				Vector3 vector = m_transform.position - lastPOS;
				m_transform.forward = new Vector3(vector.x, 0f, vector.z);
			}
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(Random.Range(0.1f, 1f));
		m_floatingText_Transform.position = start_pos;
		StartCoroutine(DisplayTextMeshProFloatingText());
	}

	public IEnumerator DisplayTextMeshFloatingText()
	{
		float CountDuration = 2f;
		float starting_Count = Random.Range(5f, 20f);
		float current_Count = starting_Count;
		Vector3 start_pos = m_floatingText_Transform.position;
		Color32 start_color = m_textMesh.color;
		float alpha = 255f;
		float fadeDuration = 3f / starting_Count * CountDuration;
		while (current_Count > 0f)
		{
			current_Count -= Time.deltaTime / CountDuration * starting_Count;
			if (current_Count <= 3f)
			{
				alpha = Mathf.Clamp(alpha - Time.deltaTime / fadeDuration * 255f, 0f, 255f);
			}
			m_textMesh.text = ((int)current_Count).ToString();
			m_textMesh.color = new Color32(start_color.r, start_color.g, start_color.b, (byte)alpha);
			m_floatingText_Transform.position += new Vector3(0f, starting_Count * Time.deltaTime, 0f);
			if (!lastPOS.Compare(m_cameraTransform.position, 1000) || !lastRotation.Compare(m_cameraTransform.rotation, 1000))
			{
				lastPOS = m_cameraTransform.position;
				lastRotation = m_cameraTransform.rotation;
				m_floatingText_Transform.rotation = lastRotation;
				Vector3 vector = m_transform.position - lastPOS;
				m_transform.forward = new Vector3(vector.x, 0f, vector.z);
			}
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForSeconds(Random.Range(0.1f, 1f));
		m_floatingText_Transform.position = start_pos;
		StartCoroutine(DisplayTextMeshFloatingText());
	}
}
