using UnityEngine;

namespace TMPro.Examples;

public class TMP_TextEventCheck : MonoBehaviour
{
	public TMP_TextEventHandler TextEventHandler;

	private void OnEnable()
	{
		if (TextEventHandler != null)
		{
			TextEventHandler.onCharacterSelection.AddListener(OnCharacterSelection);
			TextEventHandler.onSpriteSelection.AddListener(OnSpriteSelection);
			TextEventHandler.onWordSelection.AddListener(OnWordSelection);
			TextEventHandler.onLineSelection.AddListener(OnLineSelection);
			TextEventHandler.onLinkSelection.AddListener(OnLinkSelection);
		}
	}

	private void OnDisable()
	{
		if (TextEventHandler != null)
		{
			TextEventHandler.onCharacterSelection.RemoveListener(OnCharacterSelection);
			TextEventHandler.onSpriteSelection.RemoveListener(OnSpriteSelection);
			TextEventHandler.onWordSelection.RemoveListener(OnWordSelection);
			TextEventHandler.onLineSelection.RemoveListener(OnLineSelection);
			TextEventHandler.onLinkSelection.RemoveListener(OnLinkSelection);
		}
	}

	private void OnCharacterSelection(char c, int index)
	{
		Debug.Log("字符 [" + c.ToString() + "] at Index: " + index + " 已被选中。");
	}

	private void OnSpriteSelection(char c, int index)
	{
		Debug.Log("精灵 [" + c.ToString() + "] at Index: " + index + " 已被选中。");
	}

	private void OnWordSelection(string word, int firstCharacterIndex, int length)
	{
		Debug.Log("Word [" + word + "]，首字符索引为 " + firstCharacterIndex + "，长度为 " + length + " 已被选中。");
	}

	private void OnLineSelection(string lineText, int firstCharacterIndex, int length)
	{
		Debug.Log("Line [" + lineText + "]，首字符索引为 " + firstCharacterIndex + "，长度为 " + length + " 已被选中。");
	}

	private void OnLinkSelection(string linkID, string linkText, int linkIndex)
	{
		Debug.Log("Link Index: " + linkIndex + "，ID 为 [" + linkID + "] and Text \"" + linkText + "\" 已被选中。");
	}
}
