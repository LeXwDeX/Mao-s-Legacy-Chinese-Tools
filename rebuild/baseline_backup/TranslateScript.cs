using UnityEngine;
using UnityEngine.SceneManagement;

public class TranslateScript : MonoBehaviour
{
	public string[] english_text = new string[20];

	public string[] russian_text = new string[20];

	public TextMesh[] meshes = new TextMesh[20];

	public bool no_need_russian;

	public bool needEsc;

	private void Start()
	{
		Repaint();
	}

	private void Update()
	{
		if (needEsc && Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadSceneAsync("Diplomacy");
		}
	}

	public void Repaint()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			for (int i = 0; i < meshes.Length; i++)
			{
				meshes[i].text = english_text[i].Replace('|', '\n');
			}
		}
		else if (!no_need_russian)
		{
			for (int j = 0; j < meshes.Length; j++)
			{
				meshes[j].text = russian_text[j].Replace('|', '\n');
			}
		}
	}
}
