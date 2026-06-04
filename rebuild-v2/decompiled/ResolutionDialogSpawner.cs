using UnityEngine;

public class ResolutionDialogSpawner : MonoBehaviour
{
	public enum LanguageMode
	{
		AutoBySystemLanguage,
		ForceEnglish,
		ForceRussian
	}

	[Header("Prefabs")]
	public GameObject dialogPrefabEN;

	public GameObject dialogPrefabRU;

	[Header("Language")]
	public LanguageMode languageMode;

	[Header("Spawn")]
	public bool spawnOnStart = true;

	public Transform parent;

	public bool destroyExistingInstances = true;

	[Tooltip("Optional. If set, tries to destroy objects with this root name before spawning.")]
	public string dialogRootName = "NewResolutionDialog";

	private GameObject _instance;

	private void Start()
	{
		if (spawnOnStart)
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		if (destroyExistingInstances)
		{
			CleanupExisting();
		}
		GameObject gameObject = PickPrefab();
		if (gameObject == null)
		{
			Debug.LogError("[ResolutionDialogSpawner] Missing prefab reference (EN/RU).");
			return;
		}
		_instance = Object.Instantiate(gameObject, parent);
		_instance.SetActive(value: true);
	}

	public void Despawn()
	{
		if (_instance != null)
		{
			Object.Destroy(_instance);
			_instance = null;
		}
	}

	private GameObject PickPrefab()
	{
		bool flag = !PlayerPrefs.HasKey("language") || PlayerPrefs.GetInt("language") == 0;
		if (languageMode != LanguageMode.ForceRussian && (languageMode == LanguageMode.ForceEnglish || flag))
		{
			return dialogPrefabEN;
		}
		return dialogPrefabRU;
	}

	private void CleanupExisting()
	{
		if (_instance != null)
		{
			Object.Destroy(_instance);
			_instance = null;
		}
		if (string.IsNullOrEmpty(dialogRootName))
		{
			return;
		}
		Transform[] array = Resources.FindObjectsOfTypeAll<Transform>();
		foreach (Transform transform in array)
		{
			if (!(transform == null))
			{
				_ = transform.gameObject.hideFlags;
				if (transform.name == dialogRootName && transform.gameObject.scene.IsValid())
				{
					Object.Destroy(transform.gameObject);
				}
			}
		}
	}
}
