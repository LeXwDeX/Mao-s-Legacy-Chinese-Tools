using UnityEngine;

public class SaveSlotView : MonoBehaviour
{
	[SerializeField]
	private TextMesh label;

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite normalSprite;

	[SerializeField]
	private Sprite hoverSprite;

	public SaveMetadata Meta { get; private set; }

	public SaveListController Controller { get; private set; }

	public void Init(SaveMetadata meta, SaveListController controller, Sprite normal, Sprite hover)
	{
		Meta = meta;
		Controller = controller;
		normalSprite = normal;
		hoverSprite = hover;
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		if (label == null)
		{
			label = GetComponentInChildren<TextMesh>();
		}
		spriteRenderer.sprite = normalSprite;
		UpdateLabel();
	}

	public void UpdateLabel()
	{
		if (label != null && Meta != null)
		{
			label.text = Meta.name;
		}
	}

	private void OnMouseEnter()
	{
		if (spriteRenderer != null && hoverSprite != null)
		{
			spriteRenderer.sprite = hoverSprite;
		}
		Controller?.ShowDetails(Meta);
	}

	private void OnMouseExit()
	{
		if (spriteRenderer != null && normalSprite != null)
		{
			spriteRenderer.sprite = normalSprite;
		}
		Controller?.ClearDetails();
	}

	private void OnMouseDown()
	{
		if (!(Controller == null) && Meta != null)
		{
			if (Input.GetMouseButtonDown(1))
			{
				Controller.DeleteSlot(Meta);
			}
			else if (Input.GetMouseButtonDown(2) || Input.GetKey(KeyCode.R))
			{
				Controller.BeginRename(Meta);
			}
			else
			{
				Controller.SaveToSlot(Meta);
			}
		}
	}
}
