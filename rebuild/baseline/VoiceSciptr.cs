using UnityEngine;

public class VoiceSciptr : MonoBehaviour
{
	public bool is_right;

	public TextMesh text;

	public bool ten;

	public AudioScript Audio1;

	private void Awake()
	{
		text.text = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice.ToString();
	}

	private void OnMouseDown()
	{
		if (!is_right)
		{
			if (GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice == 0)
			{
				GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice = 100;
			}
			else if (ten)
			{
				if (GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice >= 10)
				{
					GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice -= 10;
				}
				else
				{
					GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice = 0;
				}
			}
			else
			{
				GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice--;
			}
		}
		else if (GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice == 100)
		{
			GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice = 0;
		}
		else if (ten)
		{
			if (GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice <= 90)
			{
				GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice += 10;
			}
			else
			{
				GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice = 100;
			}
		}
		else
		{
			GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice++;
		}
		Audio1.NotButUpdate((float)GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice / 100f);
		text.text = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice.ToString();
		PlayerPrefs.SetInt("voice_china", GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice);
	}
}
