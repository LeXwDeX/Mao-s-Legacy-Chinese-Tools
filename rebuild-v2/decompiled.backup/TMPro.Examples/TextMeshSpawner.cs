using UnityEngine;

namespace TMPro.Examples;

public class TextMeshSpawner : MonoBehaviour
{
	public int SpawnType;

	public int NumberOfNPC = 12;

	public Font TheFont;

	private TextMeshProFloatingText floatingText_Script;

	private void Awake()
	{
	}

	private void Start()
	{
		for (int i = 0; i < NumberOfNPC; i++)
		{
			if (SpawnType == 0)
			{
				GameObject gameObject = new GameObject();
				gameObject.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));
				TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
				textMeshPro.fontSize = 96f;
				textMeshPro.text = "!";
				textMeshPro.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
				floatingText_Script = gameObject.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 0;
			}
			else
			{
				GameObject gameObject2 = new GameObject();
				gameObject2.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));
				TextMesh textMesh = gameObject2.AddComponent<TextMesh>();
				textMesh.GetComponent<Renderer>().sharedMaterial = TheFont.material;
				textMesh.font = TheFont;
				textMesh.anchor = TextAnchor.LowerCenter;
				textMesh.fontSize = 96;
				textMesh.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
				textMesh.text = "!";
				floatingText_Script = gameObject2.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 1;
			}
		}
	}
}
