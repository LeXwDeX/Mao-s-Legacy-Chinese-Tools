using UnityEngine;

public class ScrollScript : MonoBehaviour
{
	public GameObject up;

	public GameObject down;

	public double position;

	public double one_point_f;

	public double one_point_s;

	public GameObject moveable;

	public void MakeThings(float focus_top, float focus_down)
	{
		one_point_s = up.transform.position.y - down.transform.position.y;
		one_point_f = (double)(focus_top - focus_down) / one_point_s;
		base.transform.position = new Vector3(base.transform.position.x, up.transform.position.y, base.transform.position.z);
	}

	public void OnMouseDrag()
	{
		float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
		y = y.Clamp(down.transform.position.y, up.transform.position.y);
		double num = (double)moveable.transform.position.y - (double)(y - base.transform.position.y) * one_point_f;
		moveable.transform.position = new Vector3(moveable.transform.position.x, (float)num, moveable.transform.position.z);
		base.transform.position = new Vector3(base.transform.position.x, y, base.transform.position.z);
	}

	private void Update()
	{
		float axis = Input.GetAxis("鼠标滚轮");
		if (axis != 0f)
		{
			double value = (double)base.transform.position.y + (double)(axis * Time.deltaTime * 12f) * one_point_s;
			value = Clamp(value, down.transform.position.y, up.transform.position.y);
			double num = (double)moveable.transform.position.y - (value - (double)base.transform.position.y) * one_point_f;
			moveable.transform.position = new Vector3(moveable.transform.position.x, (float)num, moveable.transform.position.z);
			base.transform.position = new Vector3(base.transform.position.x, (float)value, base.transform.position.z);
		}
	}

	private double Clamp(double value, double min, double max)
	{
		if (value < min)
		{
			value = min;
		}
		else if (value > max)
		{
			value = max;
		}
		return value;
	}
}
