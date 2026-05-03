using UnityEngine;

public class SizeScript_PopUp : MonoBehaviour
{
	public void SizeSc()
	{
		base.transform.localScale = new Vector3(base.transform.localScale.x * (Camera.main.aspect / 1.7777778f), base.transform.localScale.y, 1f);
		Object.Destroy(this);
	}
}
