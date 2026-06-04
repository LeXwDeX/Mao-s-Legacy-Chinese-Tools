using UnityEngine;

public class sizescript : MonoBehaviour
{
	private void Start()
	{
		base.transform.localScale = new Vector3(base.transform.localScale.x * (Camera.main.aspect / 1.7777778f), base.transform.localScale.y, 1f);
		Object.Destroy(this);
	}
}
