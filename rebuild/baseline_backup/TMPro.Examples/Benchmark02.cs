using UnityEngine;

namespace TMPro.Examples;

public class Benchmark02 : MonoBehaviour
{
	public int SpawnType;

	public int NumberOfNPC = 12;

	private TextMeshProFloatingText floatingText_Script;

	private void Start()
	{
		for (int i = 0; i < NumberOfNPC; i++)
		{
			if (SpawnType == 0)
			{
				GameObject gameObject = new GameObject();
				gameObject.transform.position = new Vector3(Random.Range(-95f, 95f), 0.25f, Random.Range(-95f, 95f));
				TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
				textMeshPro.autoSizeTextContainer = true;
				textMeshPro.rectTransform.pivot = new Vector2(0.5f, 0f);
				textMeshPro.alignment = TextAlignmentOptions.Bottom;
				textMeshPro.fontSize = 96f;
				textMeshPro.enableKerning = false;
				textMeshPro.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
				textMeshPro.text = "!";
				floatingText_Script = gameObject.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 0;
			}
			else if (SpawnType == 1)
			{
				GameObject gameObject2 = new GameObject();
				gameObject2.transform.position = new Vector3(Random.Range(-95f, 95f), 0.25f, Random.Range(-95f, 95f));
				TextMesh textMesh = gameObject2.AddComponent<TextMesh>();
				textMesh.font = Resources.Load<Font>("Fonts/ARIAL");
				textMesh.GetComponent<Renderer>().sharedMaterial = textMesh.font.material;
				textMesh.anchor = TextAnchor.LowerCenter;
				textMesh.fontSize = 96;
				textMesh.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
				textMesh.text = "!";
				floatingText_Script = gameObject2.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 1;
			}
			else if (SpawnType == 2)
			{
				GameObject gameObject3 = new GameObject();
				gameObject3.AddComponent<Canvas>().worldCamera = Camera.main;
				gameObject3.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				gameObject3.transform.position = new Vector3(Random.Range(-95f, 95f), 5f, Random.Range(-95f, 95f));
				TextMeshProUGUI textMeshProUGUI = new GameObject().AddComponent<TextMeshProUGUI>();
				textMeshProUGUI.rectTransform.SetParent(gameObject3.transform, worldPositionStays: false);
				textMeshProUGUI.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
				textMeshProUGUI.alignment = TextAlignmentOptions.Bottom;
				textMeshProUGUI.fontSize = 96f;
				textMeshProUGUI.text = "!";
				floatingText_Script = gameObject3.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 0;
			}
		}
	}
}
