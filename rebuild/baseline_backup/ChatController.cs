using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{
	public TMP_InputField TMP_ChatInput;

	public TMP_Text TMP_ChatOutput;

	public Scrollbar ChatScrollbar;

	private void OnEnable()
	{
		TMP_ChatInput.onSubmit.AddListener(AddToChatOutput);
	}

	private void OnDisable()
	{
		TMP_ChatInput.onSubmit.RemoveListener(AddToChatOutput);
	}

	private void AddToChatOutput(string newText)
	{
		TMP_ChatInput.text = string.Empty;
		DateTime now = DateTime.Now;
		TMP_Text tMP_ChatOutput = TMP_ChatOutput;
		tMP_ChatOutput.text = tMP_ChatOutput.text + "[<#FFFF80>" + now.Hour.ToString("d2") + ":" + now.Minute.ToString("d2") + ":" + now.Second.ToString("d2") + "</color>] " + newText + "\n";
		TMP_ChatInput.ActivateInputField();
		ChatScrollbar.value = 0f;
	}
}
