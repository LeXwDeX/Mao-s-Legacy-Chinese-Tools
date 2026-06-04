using UnityEngine;
using UnityEngine.UI;

public class ConfirmButtonTooltip : MonoBehaviour
{
	[SerializeField]
	private InputField nameInput;

	[SerializeField]
	private InputField surnameInput;

	private OkoshkoScriptDLC okoshkoScript;

	private void Start()
	{
		okoshkoScript = GetComponent<OkoshkoScriptDLC>();
		if (okoshkoScript == null)
		{
			Debug.LogWarning("未在 发现 OkoshkoScriptDLC" + base.gameObject.name);
		}
		if (nameInput != null)
		{
			nameInput.onValueChanged.AddListener(UpdateTooltipState);
		}
		if (surnameInput != null)
		{
			surnameInput.onValueChanged.AddListener(UpdateTooltipState);
		}
		UpdateTooltipState("");
	}

	private void UpdateTooltipState(string _)
	{
		if (!(okoshkoScript == null))
		{
			bool flag = string.IsNullOrEmpty(nameInput.text) || string.IsNullOrEmpty(surnameInput.text);
			okoshkoScript.nonono = !flag;
			if (!flag)
			{
				okoshkoScript.ForceDestroyWindow();
			}
		}
	}

	private void OnDestroy()
	{
		if (nameInput != null)
		{
			nameInput.onValueChanged.RemoveListener(UpdateTooltipState);
		}
		if (surnameInput != null)
		{
			surnameInput.onValueChanged.RemoveListener(UpdateTooltipState);
		}
	}
}
