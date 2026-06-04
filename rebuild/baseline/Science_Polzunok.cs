using UnityEngine;

public class Science_Polzunok : MonoBehaviour
{
	public GameObject movable;

	public GameObject movable_Min;

	public GameObject movable_Max;

	public GameObject this_min;

	public GameObject this_max;

	private float fl1;

	private float fl2;

	private new bool enabled;

	private void Start()
	{
		fl1 = movable_Max.transform.position.y - movable_Min.transform.position.y;
		fl2 = this_max.transform.position.y - this_min.transform.position.y;
		enabled = true;
	}

	private void OnMouseDrag()
	{
		if (enabled)
		{
			Vector2 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (vector.y <= this_min.transform.position.y)
			{
				base.transform.position = new Vector3(base.transform.position.x, this_min.transform.position.y, base.transform.position.z);
				movable.transform.position = new Vector3(movable.transform.position.x, movable_Max.transform.position.y, movable.transform.position.z);
			}
			else if (vector.y >= this_max.transform.position.y)
			{
				base.transform.position = new Vector3(base.transform.position.x, this_max.transform.position.y, base.transform.position.z);
				movable.transform.position = new Vector3(movable.transform.position.x, movable_Min.transform.position.y, movable.transform.position.z);
			}
			else
			{
				base.transform.position = new Vector3(base.transform.position.x, vector.y, base.transform.position.z);
				movable.transform.position = new Vector3(movable.transform.position.x, movable_Min.transform.position.y + fl1 * (1f - (vector.y - this_min.transform.position.y) / fl2), movable.transform.position.z);
			}
		}
	}

	private void Update()
	{
		if (enabled && Input.GetAxis("鼠标滚轮") != 0f)
		{
			Vector2 vector = new Vector2(0f, base.transform.position.y + Input.GetAxis("鼠标滚轮") * Time.deltaTime * 160f);
			if (vector.y <= this_min.transform.position.y)
			{
				base.transform.position = new Vector3(base.transform.position.x, this_min.transform.position.y, base.transform.position.z);
				movable.transform.position = new Vector3(movable.transform.position.x, movable_Max.transform.position.y, movable.transform.position.z);
			}
			else if (vector.y >= this_max.transform.position.y)
			{
				base.transform.position = new Vector3(base.transform.position.x, this_max.transform.position.y, base.transform.position.z);
				movable.transform.position = new Vector3(movable.transform.position.x, movable_Min.transform.position.y, movable.transform.position.z);
			}
			else
			{
				base.transform.position = new Vector3(base.transform.position.x, vector.y, base.transform.position.z);
				movable.transform.position = new Vector3(movable.transform.position.x, movable_Min.transform.position.y + fl1 * (1f - (vector.y - this_min.transform.position.y) / fl2), movable.transform.position.z);
			}
		}
	}
}
