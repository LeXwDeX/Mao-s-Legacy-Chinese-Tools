using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
	private static bool escapeHandled;

	public string new_scene = "Diplomacy";

	public string now_scene = "Main";

	public Sprite nenavel;

	public Sprite navel;

	public Sprite eng_nenavel;

	public Sprite eng_navel;

	public bool text_navedeniye;

	private void Awake()
	{
		string text = SceneManager.GetActiveScene().name;
		if (string.IsNullOrEmpty(now_scene) || (now_scene == "Main" && text != "Main"))
		{
			now_scene = text;
		}
	}

	public void OnMouseDown()
	{
		if (now_scene == "Load" || now_scene == "Settings")
		{
			new_scene = (GlobalScript.inst.gameState.turn_on ? "Main" : "Diplomacy");
		}
		SceneManager.LoadSceneAsync(new_scene);
	}

	private void Update()
	{
		string text = SceneManager.GetActiveScene().name;
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (escapeHandled || text != now_scene)
			{
				return;
			}
			escapeHandled = true;
			if (now_scene == "Load" || now_scene == "Settings")
			{
				new_scene = (GlobalScript.inst.gameState.turn_on ? "Main" : "Diplomacy");
			}
			else
			{
				new_scene = "Diplomacy";
			}
			SceneManager.LoadSceneAsync(new_scene);
		}
		if (escapeHandled && Input.GetKeyUp(KeyCode.Escape))
		{
			escapeHandled = false;
		}
	}

	private void OnDisable()
	{
		escapeHandled = false;
	}

	private void OnMouseEnter()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				base.gameObject.GetComponent<SpriteRenderer>().sprite = eng_navel;
			}
			else
			{
				base.gameObject.GetComponent<SpriteRenderer>().sprite = navel;
			}
		}
		else if (text_navedeniye)
		{
			GetComponent<TextMesh>().color = Color.gray;
		}
	}

	private void OnMouseExit()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				base.gameObject.GetComponent<SpriteRenderer>().sprite = eng_nenavel;
			}
			else
			{
				base.gameObject.GetComponent<SpriteRenderer>().sprite = nenavel;
			}
		}
		else if (text_navedeniye)
		{
			GetComponent<TextMesh>().color = Color.black;
		}
	}
}
