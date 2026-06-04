using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
	private void Start()
	{
		SceneManager.LoadScene("Main");
	}
}
