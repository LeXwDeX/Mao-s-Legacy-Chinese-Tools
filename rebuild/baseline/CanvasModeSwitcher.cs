using UnityEngine;

public class CanvasModeSwitcher : MonoBehaviour
{
	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private Camera mainCamera;

	private void Start()
	{
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		canvas.worldCamera = mainCamera;
		canvas.renderMode = RenderMode.WorldSpace;
	}
}
