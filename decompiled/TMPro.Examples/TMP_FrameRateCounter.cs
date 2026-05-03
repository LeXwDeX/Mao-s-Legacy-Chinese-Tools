using UnityEngine;

namespace TMPro.Examples;

public class TMP_FrameRateCounter : MonoBehaviour
{
	public enum FpsCounterAnchorPositions
	{
		TopLeft,
		BottomLeft,
		TopRight,
		BottomRight
	}

	public float UpdateInterval = 5f;

	private float m_LastInterval;

	private int m_Frames;

	public FpsCounterAnchorPositions AnchorPosition = FpsCounterAnchorPositions.TopRight;

	private string htmlColorTag;

	private const string fpsLabel = "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS";

	private TextMeshPro m_TextMeshPro;

	private Transform m_frameCounter_transform;

	private Camera m_camera;

	private FpsCounterAnchorPositions last_AnchorPosition;

	private void Awake()
	{
		if (base.enabled)
		{
			m_camera = Camera.main;
			Application.targetFrameRate = -1;
			GameObject gameObject = new GameObject("Frame Counter");
			m_TextMeshPro = gameObject.AddComponent<TextMeshPro>();
			m_TextMeshPro.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
			m_TextMeshPro.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/LiberationSans SDF - Overlay");
			m_frameCounter_transform = gameObject.transform;
			m_frameCounter_transform.SetParent(m_camera.transform);
			m_frameCounter_transform.localRotation = Quaternion.identity;
			m_TextMeshPro.enableWordWrapping = false;
			m_TextMeshPro.fontSize = 24f;
			m_TextMeshPro.isOverlay = true;
			Set_FrameCounter_Position(AnchorPosition);
			last_AnchorPosition = AnchorPosition;
		}
	}

	private void Start()
	{
		m_LastInterval = Time.realtimeSinceStartup;
		m_Frames = 0;
	}

	private void Update()
	{
		if (AnchorPosition != last_AnchorPosition)
		{
			Set_FrameCounter_Position(AnchorPosition);
		}
		last_AnchorPosition = AnchorPosition;
		m_Frames++;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (realtimeSinceStartup > m_LastInterval + UpdateInterval)
		{
			float num = (float)m_Frames / (realtimeSinceStartup - m_LastInterval);
			float arg = 1000f / Mathf.Max(num, 1E-05f);
			if (num < 30f)
			{
				htmlColorTag = "<color=yellow>";
			}
			else if (num < 10f)
			{
				htmlColorTag = "<color=red>";
			}
			else
			{
				htmlColorTag = "<color=green>";
			}
			m_TextMeshPro.SetText(htmlColorTag + "{0:2}</color> <#8080ff>FPS \n<#FF8000>{1:2} <#8080ff>MS", num, arg);
			m_Frames = 0;
			m_LastInterval = realtimeSinceStartup;
		}
	}

	private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position)
	{
		m_TextMeshPro.margin = new Vector4(1f, 1f, 1f, 1f);
		switch (anchor_position)
		{
		case FpsCounterAnchorPositions.TopLeft:
			m_TextMeshPro.alignment = TextAlignmentOptions.TopLeft;
			m_TextMeshPro.rectTransform.pivot = new Vector2(0f, 1f);
			m_frameCounter_transform.position = m_camera.ViewportToWorldPoint(new Vector3(0f, 1f, 100f));
			break;
		case FpsCounterAnchorPositions.BottomLeft:
			m_TextMeshPro.alignment = TextAlignmentOptions.BottomLeft;
			m_TextMeshPro.rectTransform.pivot = new Vector2(0f, 0f);
			m_frameCounter_transform.position = m_camera.ViewportToWorldPoint(new Vector3(0f, 0f, 100f));
			break;
		case FpsCounterAnchorPositions.TopRight:
			m_TextMeshPro.alignment = TextAlignmentOptions.TopRight;
			m_TextMeshPro.rectTransform.pivot = new Vector2(1f, 1f);
			m_frameCounter_transform.position = m_camera.ViewportToWorldPoint(new Vector3(1f, 1f, 100f));
			break;
		case FpsCounterAnchorPositions.BottomRight:
			m_TextMeshPro.alignment = TextAlignmentOptions.BottomRight;
			m_TextMeshPro.rectTransform.pivot = new Vector2(1f, 0f);
			m_frameCounter_transform.position = m_camera.ViewportToWorldPoint(new Vector3(1f, 0f, 100f));
			break;
		}
	}
}
