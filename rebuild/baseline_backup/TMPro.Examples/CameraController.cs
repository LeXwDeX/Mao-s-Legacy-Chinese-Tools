using UnityEngine;

namespace TMPro.Examples;

public class CameraController : MonoBehaviour
{
	public enum CameraModes
	{
		Follow,
		Isometric,
		Free
	}

	private Transform cameraTransform;

	private Transform dummyTarget;

	public Transform CameraTarget;

	public float FollowDistance = 30f;

	public float MaxFollowDistance = 100f;

	public float MinFollowDistance = 2f;

	public float ElevationAngle = 30f;

	public float MaxElevationAngle = 85f;

	public float MinElevationAngle;

	public float OrbitalAngle;

	public CameraModes CameraMode;

	public bool MovementSmoothing = true;

	public bool RotationSmoothing;

	private bool previousSmoothing;

	public float MovementSmoothingValue = 25f;

	public float RotationSmoothingValue = 5f;

	public float MoveSensitivity = 2f;

	private Vector3 currentVelocity = Vector3.zero;

	private Vector3 desiredPosition;

	private float mouseX;

	private float mouseY;

	private Vector3 moveVector;

	private float mouseWheel;

	private const string event_SmoothingValue = "Slider - Smoothing Value";

	private const string event_FollowDistance = "Slider - Camera Zoom";

	private void Awake()
	{
		if (QualitySettings.vSyncCount > 0)
		{
			Application.targetFrameRate = 60;
		}
		else
		{
			Application.targetFrameRate = -1;
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			Input.simulateMouseWithTouches = false;
		}
		cameraTransform = base.transform;
		previousSmoothing = MovementSmoothing;
	}

	private void Start()
	{
		if (CameraTarget == null)
		{
			dummyTarget = new GameObject("Camera Target").transform;
			CameraTarget = dummyTarget;
		}
	}

	private void LateUpdate()
	{
		GetPlayerInput();
		if (CameraTarget != null)
		{
			if (CameraMode == CameraModes.Isometric)
			{
				desiredPosition = CameraTarget.position + Quaternion.Euler(ElevationAngle, OrbitalAngle, 0f) * new Vector3(0f, 0f, 0f - FollowDistance);
			}
			else if (CameraMode == CameraModes.Follow)
			{
				desiredPosition = CameraTarget.position + CameraTarget.TransformDirection(Quaternion.Euler(ElevationAngle, OrbitalAngle, 0f) * new Vector3(0f, 0f, 0f - FollowDistance));
			}
			if (MovementSmoothing)
			{
				cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, desiredPosition, ref currentVelocity, MovementSmoothingValue * Time.fixedDeltaTime);
			}
			else
			{
				cameraTransform.position = desiredPosition;
			}
			if (RotationSmoothing)
			{
				cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.LookRotation(CameraTarget.position - cameraTransform.position), RotationSmoothingValue * Time.deltaTime);
			}
			else
			{
				cameraTransform.LookAt(CameraTarget);
			}
		}
	}

	private void GetPlayerInput()
	{
		moveVector = Vector3.zero;
		mouseWheel = Input.GetAxis("Mouse ScrollWheel");
		float num = Input.touchCount;
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || num > 0f)
		{
			mouseWheel *= 10f;
			if (Input.GetKeyDown(KeyCode.I))
			{
				CameraMode = CameraModes.Isometric;
			}
			if (Input.GetKeyDown(KeyCode.F))
			{
				CameraMode = CameraModes.Follow;
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				MovementSmoothing = !MovementSmoothing;
			}
			if (Input.GetMouseButton(1))
			{
				mouseY = Input.GetAxis("Mouse Y");
				mouseX = Input.GetAxis("Mouse X");
				if (mouseY > 0.01f || mouseY < -0.01f)
				{
					ElevationAngle -= mouseY * MoveSensitivity;
					ElevationAngle = Mathf.Clamp(ElevationAngle, MinElevationAngle, MaxElevationAngle);
				}
				if (mouseX > 0.01f || mouseX < -0.01f)
				{
					OrbitalAngle += mouseX * MoveSensitivity;
					if (OrbitalAngle > 360f)
					{
						OrbitalAngle -= 360f;
					}
					if (OrbitalAngle < 0f)
					{
						OrbitalAngle += 360f;
					}
				}
			}
			if (num == 1f && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector2 deltaPosition = Input.GetTouch(0).deltaPosition;
				if (deltaPosition.y > 0.01f || deltaPosition.y < -0.01f)
				{
					ElevationAngle -= deltaPosition.y * 0.1f;
					ElevationAngle = Mathf.Clamp(ElevationAngle, MinElevationAngle, MaxElevationAngle);
				}
				if (deltaPosition.x > 0.01f || deltaPosition.x < -0.01f)
				{
					OrbitalAngle += deltaPosition.x * 0.1f;
					if (OrbitalAngle > 360f)
					{
						OrbitalAngle -= 360f;
					}
					if (OrbitalAngle < 0f)
					{
						OrbitalAngle += 360f;
					}
				}
			}
			if (Input.GetMouseButton(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 300f, 23552))
			{
				if (hitInfo.transform == CameraTarget)
				{
					OrbitalAngle = 0f;
				}
				else
				{
					CameraTarget = hitInfo.transform;
					OrbitalAngle = 0f;
					MovementSmoothing = previousSmoothing;
				}
			}
			if (Input.GetMouseButton(2))
			{
				if (dummyTarget == null)
				{
					dummyTarget = new GameObject("Camera Target").transform;
					dummyTarget.position = CameraTarget.position;
					dummyTarget.rotation = CameraTarget.rotation;
					CameraTarget = dummyTarget;
					previousSmoothing = MovementSmoothing;
					MovementSmoothing = false;
				}
				else if (dummyTarget != CameraTarget)
				{
					dummyTarget.position = CameraTarget.position;
					dummyTarget.rotation = CameraTarget.rotation;
					CameraTarget = dummyTarget;
					previousSmoothing = MovementSmoothing;
					MovementSmoothing = false;
				}
				mouseY = Input.GetAxis("Mouse Y");
				mouseX = Input.GetAxis("Mouse X");
				moveVector = cameraTransform.TransformDirection(mouseX, mouseY, 0f);
				dummyTarget.Translate(-moveVector, Space.World);
			}
		}
		if (num == 2f)
		{
			Touch touch = Input.GetTouch(0);
			Touch touch2 = Input.GetTouch(1);
			Vector2 vector = touch.position - touch.deltaPosition;
			Vector2 vector2 = touch2.position - touch2.deltaPosition;
			float magnitude = (vector - vector2).magnitude;
			float magnitude2 = (touch.position - touch2.position).magnitude;
			float num2 = magnitude - magnitude2;
			if (num2 > 0.01f || num2 < -0.01f)
			{
				FollowDistance += num2 * 0.25f;
				FollowDistance = Mathf.Clamp(FollowDistance, MinFollowDistance, MaxFollowDistance);
			}
		}
		if (mouseWheel < -0.01f || mouseWheel > 0.01f)
		{
			FollowDistance -= mouseWheel * 5f;
			FollowDistance = Mathf.Clamp(FollowDistance, MinFollowDistance, MaxFollowDistance);
		}
	}
}
