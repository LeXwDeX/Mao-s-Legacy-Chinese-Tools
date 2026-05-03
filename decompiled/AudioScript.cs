using UnityEngine;

public class AudioScript : MonoBehaviour
{
	public GameObject polzunok;

	public GameObject l;

	public GameObject r;

	private GlobalScript data;

	private bool a;

	private float number;

	public TextMesh text;

	private void Start()
	{
		data = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		polzunok.transform.position = new Vector3(l.transform.position.x + (r.transform.position.x - l.transform.position.x) * data.GetComponent<AudioSource>().volume, polzunok.transform.position.y, polzunok.transform.position.z);
	}

	private void OnMouseDown()
	{
		a = true;
	}

	private void Update()
	{
		if (a)
		{
			if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > r.transform.position.x)
			{
				number = 1f;
				polzunok.transform.position = new Vector3(r.transform.position.x, polzunok.transform.position.y, polzunok.transform.position.z);
			}
			else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < l.transform.position.x)
			{
				polzunok.transform.position = new Vector3(l.transform.position.x, polzunok.transform.position.y, polzunok.transform.position.z);
				number = 0f;
			}
			else
			{
				polzunok.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, polzunok.transform.position.y, polzunok.transform.position.z);
				number = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - l.transform.position.x) / (r.transform.position.x - l.transform.position.x);
			}
			data.voice = (int)(number * 100f);
			PlayerPrefs.SetFloat("voice_china", number * 100f);
			text.text = data.voice.ToString();
			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				a = false;
			}
		}
	}

	public void NotButUpdate(float voice)
	{
		polzunok.transform.position = new Vector3(l.transform.position.x + (r.transform.position.x - l.transform.position.x) * voice, polzunok.transform.position.y, polzunok.transform.position.z);
	}
}
