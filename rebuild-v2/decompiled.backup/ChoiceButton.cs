using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
	public enum ChoiceButtonState
	{
		Idle,
		Selected,
		MouseEntered
	}

	public int num;

	public ChoiceSystemController controller;

	[SerializeField]
	private TextMesh textMesh;

	public Color defaultColor;

	public Color selectedColor;

	private ChoiceButtonState state;

	public void ChangeSelected(bool isSelected)
	{
		if (isSelected)
		{
			state = ChoiceButtonState.Selected;
		}
		else if (state == ChoiceButtonState.Selected)
		{
			state = ChoiceButtonState.Idle;
		}
		Repaint();
	}

	private void OnMouseEnter()
	{
		if (state == ChoiceButtonState.Idle)
		{
			state = ChoiceButtonState.MouseEntered;
		}
		Repaint();
	}

	private void OnMouseExit()
	{
		if (state == ChoiceButtonState.MouseEntered)
		{
			state = ChoiceButtonState.Idle;
		}
		Repaint();
	}

	public void ChangeText(string text, string desc = null)
	{
		textMesh.text = text;
		if (GetComponent<OkoshkoScript>() != null)
		{
			GetComponent<OkoshkoScript>().text = (GetComponent<OkoshkoScript>().text_en = desc);
		}
	}

	private void Repaint()
	{
		textMesh.color = ((state == ChoiceButtonState.Idle) ? defaultColor : selectedColor);
	}

	private void OnMouseDown()
	{
		controller.ReceiveButtonPress(num);
	}
}
