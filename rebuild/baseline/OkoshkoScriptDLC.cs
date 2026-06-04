using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OkoshkoScriptDLC : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject okno;

	public string text;

	public string text_en;

	public int numString = -1;

	public int pixel = 140;

	public float padding = 20f;

	public bool nonono;

	public bool needAutoText;

	public GameObject pidor;

	public Canvas canvas;

	public Camera cam;

	private void Start()
	{
		cam = Camera.main;
		canvas = Object.FindObjectOfType<Canvas>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log($"OnPointerEnter called on {base.gameObject.name}, nonono={nonono}");
		if (nonono || canvas == null || pidor != null)
		{
			return;
		}
		pidor = Object.Instantiate(okno, canvas.transform);
		RectTransform component = pidor.GetComponent<RectTransform>();
		DisableRaycastTarget(pidor);
		Vector2 screenPoint = Input.mousePosition;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), screenPoint, canvas.worldCamera, out var localPoint);
		localPoint.x += pixel;
		component.anchoredPosition = localPoint;
		Vector2 sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
		Vector2 sizeDelta2 = component.sizeDelta;
		localPoint.x = Mathf.Clamp(localPoint.x, (0f - sizeDelta.x) / 2f + sizeDelta2.x / 2f, sizeDelta.x / 2f - sizeDelta2.x / 2f);
		localPoint.y = Mathf.Clamp(localPoint.y, (0f - sizeDelta.y) / 2f + sizeDelta2.y / 2f, sizeDelta.y / 2f - sizeDelta2.y / 2f);
		component.anchoredPosition = localPoint;
		Text componentInChildren = pidor.GetComponentInChildren<Text>();
		if (componentInChildren == null)
		{
			Debug.LogWarning("在 okno 预制体中未找到 Text 组件！");
			Object.Destroy(pidor);
		}
		else if (!needAutoText)
		{
			if (numString > 0)
			{
				componentInChildren.text = GlobalScript.inst.other_text[numString].Replace("{0}", "\n");
			}
			else if (PlayerPrefs.GetInt("language") == 0)
			{
				componentInChildren.text = text_en.Replace("|", "\n");
			}
			else
			{
				componentInChildren.text = this.text.Replace("|", "\n");
			}
		}
		else
		{
			int stroki = 0;
			float x = componentInChildren.GetComponent<RectTransform>().sizeDelta.x;
			string text = ((numString <= 0) ? ((PlayerPrefs.GetInt("language") == 0) ? ProcessText(text_en, x, out stroki) : ProcessText(this.text, x, out stroki)) : ProcessText(GlobalScript.inst.other_text[numString].Replace("{0}", "|"), x, out stroki));
			componentInChildren.text = text;
			Vector2 sizeDelta3 = component.sizeDelta;
			sizeDelta3.y = (float)stroki - padding;
			component.sizeDelta = sizeDelta3;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("在 上调用 OnPointerExit" + base.gameObject.name);
		if (!nonono && pidor != null)
		{
			Object.Destroy(pidor);
			pidor = null;
		}
	}

	public void ForceDestroyWindow()
	{
		if (pidor != null)
		{
			Object.Destroy(pidor);
		}
	}

	private void OnDisable()
	{
		if (pidor != null)
		{
			Object.Destroy(pidor);
			pidor = null;
		}
	}

	private void DisableRaycastTarget(GameObject obj)
	{
		Graphic[] componentsInChildren = obj.GetComponentsInChildren<Graphic>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].raycastTarget = false;
		}
	}

	private string ProcessText(string text, float maxWidth, out int stroki)
	{
		stroki = 1;
		string text2 = "";
		int num = 0;
		text = text.Replace("<color=green>", "♔").Replace("<color=red>", "♕").Replace("<color=yellow>", "♖")
			.Replace("<color=brown>", "♗")
			.Replace("<color=fuchsia>", "♘")
			.Replace("<color=lime>", "♙")
			.Replace("<color=cyan>", "♚")
			.Replace("<color=orange>", "♛")
			.Replace("</color>", "♜");
		string text3 = text;
		for (int i = 0; i < text3.Length; i++)
		{
			char c = text3[i];
			if (c == '|')
			{
				num = 0;
				text2 += "\n";
				stroki++;
			}
			else if ((float)num >= maxWidth / 10f)
			{
				if (c == ' ')
				{
					num = 0;
					text2 += "\n";
					stroki++;
					continue;
				}
				text2 += c;
				for (int num2 = text2.Length - 1; num2 >= 0; num2--)
				{
					if (text2[num2] == ' ')
					{
						text2 = text2.Substring(0, num2) + "\n" + text2.Substring(num2 + 1);
						stroki++;
						num = text2.Length - num2 - 1;
						break;
					}
				}
			}
			else
			{
				text2 += c;
				num++;
			}
		}
		return text2.Replace("♔", "<color=green>").Replace("♕", "<color=red>").Replace("♖", "<color=yellow>")
			.Replace("♗", "<color=brown>")
			.Replace("♘", "<color=fuchsia>")
			.Replace("♙", "<color=lime>")
			.Replace("♚", "<color=cyan>")
			.Replace("♛", "<color=orange>")
			.Replace("♜", "</color>");
	}
}
