using UnityEngine;

public class DLCshowScript : MonoBehaviour
{
	public GameObject[] dlcs = new GameObject[2];

	public Sprite[] dlc_sprites = new Sprite[2];

	private void Start()
	{
		UpdateDLCDisplay();
	}

	private void UpdateDLCDisplay()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			if (GlobalScript.inst.dlc[0])
			{
				dlcs[3].GetComponent<SpriteRenderer>().sprite = dlc_sprites[3];
				dlcs[3].GetComponent<OkoshkoScript>().text_en = "\"Ways of Life\" activated";
				dlcs[3].GetComponent<OkoshkoScript>().text = "\"Ways of Life\" включен";
			}
			else
			{
				dlcs[3].GetComponent<OkoshkoScript>().text_en = "\"Ways of Life\" is needed";
				dlcs[3].GetComponent<OkoshkoScript>().text = "\"Ways of Life\" не куплен";
			}
			if (GlobalScript.inst.dlc[1])
			{
				dlcs[0].GetComponent<SpriteRenderer>().sprite = dlc_sprites[0];
				dlcs[0].GetComponent<OkoshkoScript>().text_en = "\"Homeland or Death\" activated";
				dlcs[0].GetComponent<OkoshkoScript>().text = "\"Родина или Смерть\" включен";
			}
			else
			{
				dlcs[0].GetComponent<OkoshkoScript>().text_en = "\"Homeland or Death\" is needed";
				dlcs[0].GetComponent<OkoshkoScript>().text = "\"Родина или Смерть\" не куплен";
			}
			if (GlobalScript.inst.dlc[2])
			{
				dlcs[1].GetComponent<SpriteRenderer>().sprite = dlc_sprites[1];
				dlcs[1].GetComponent<OkoshkoScript>().text_en = "\"Bombard The Headquarters\" activated";
				dlcs[1].GetComponent<OkoshkoScript>().text = "\"Огонь по штабам\" включен";
			}
			else
			{
				dlcs[1].GetComponent<OkoshkoScript>().text_en = "\"Bombard The Headquarters\" is needed";
				dlcs[1].GetComponent<OkoshkoScript>().text = "\"Огонь по штабам\" не куплен";
			}
			if (GlobalScript.inst.dlc[3])
			{
				dlcs[2].GetComponent<SpriteRenderer>().sprite = dlc_sprites[2];
				dlcs[2].GetComponent<OkoshkoScript>().text_en = "\"The Fallen Eagle\" activated";
				dlcs[2].GetComponent<OkoshkoScript>().text = "\"Падший Орёл\" включен";
			}
			else
			{
				dlcs[2].GetComponent<OkoshkoScript>().text_en = "\"The Fallen Eagle\" is needed";
				dlcs[2].GetComponent<OkoshkoScript>().text = "\"Падший Орёл\" не куплен";
			}
			if (GlobalScript.inst.dlc[5])
			{
				dlcs[4].GetComponent<SpriteRenderer>().sprite = dlc_sprites[4];
				dlcs[4].GetComponent<OkoshkoScript>().text_en = "\"Heroes of War & Money\" activated";
				dlcs[4].GetComponent<OkoshkoScript>().text = "\"Герои Войны и Денег\" включен";
			}
			else
			{
				dlcs[4].GetComponent<OkoshkoScript>().text_en = "\"Heroes of War & Money\" is needed";
				dlcs[4].GetComponent<OkoshkoScript>().text = "\"Герои Войны и Денег\" не куплен";
			}
			if (GlobalScript.inst.dlc[6])
			{
				dlcs[5].GetComponent<SpriteRenderer>().sprite = dlc_sprites[5];
				dlcs[5].GetComponent<OkoshkoScript>().text_en = "\"Red Genes\" activated";
				dlcs[5].GetComponent<OkoshkoScript>().text = "\"Красные гены\" включен";
			}
			else
			{
				dlcs[5].GetComponent<OkoshkoScript>().text_en = "\"Red Genes\" is needed";
				dlcs[5].GetComponent<OkoshkoScript>().text = "\"Красные гены\" не куплен";
			}
			if (GlobalScript.inst.dlc[8])
			{
				dlcs[6].GetComponent<SpriteRenderer>().sprite = dlc_sprites[6];
				dlcs[6].GetComponent<OkoshkoScript>().text_en = "\"Lei Feng's Legacy\" activated";
				dlcs[6].GetComponent<OkoshkoScript>().text = "\"Наследие Ли Фенга\" включен";
			}
			else
			{
				dlcs[6].GetComponent<OkoshkoScript>().text_en = "\"Lei Feng's Legacy\" is needed";
				dlcs[6].GetComponent<OkoshkoScript>().text = "\"Наследие Ли Фенга\" не куплен";
			}
		}
		else
		{
			if (GlobalScript.inst.dlc[0])
			{
				dlcs[3].GetComponent<SpriteRenderer>().sprite = dlc_sprites[3];
				dlcs[3].GetComponent<OkoshkoScript>().text_en = "\"Ways of Life\" activated";
				dlcs[3].GetComponent<OkoshkoScript>().text = "\"Ways of Life\" включен";
			}
			else
			{
				dlcs[3].GetComponent<OkoshkoScript>().text_en = "\"Ways of Life\" is needed";
				dlcs[3].GetComponent<OkoshkoScript>().text = "\"Ways of Life\" не куплен";
			}
			if (GlobalScript.inst.dlc[1])
			{
				dlcs[0].GetComponent<SpriteRenderer>().sprite = dlc_sprites[0];
				dlcs[0].GetComponent<OkoshkoScript>().text_en = "\"Homeland or Death\" activated";
				dlcs[0].GetComponent<OkoshkoScript>().text = "\"Родина или Смерть\" включен";
			}
			else
			{
				dlcs[0].GetComponent<OkoshkoScript>().text_en = "\"Homeland or Death\" is needed";
				dlcs[0].GetComponent<OkoshkoScript>().text = "\"Родина или Смерть\" не куплен";
			}
			if (GlobalScript.inst.dlc[2])
			{
				dlcs[1].GetComponent<SpriteRenderer>().sprite = dlc_sprites[1];
				dlcs[1].GetComponent<OkoshkoScript>().text_en = "\"Bombard The Headquarters\" is activated";
				dlcs[1].GetComponent<OkoshkoScript>().text = "\"Огонь по штабам\" включен";
			}
			else
			{
				dlcs[1].GetComponent<OkoshkoScript>().text_en = "\"Bombard The Headquarters\" is needed";
				dlcs[1].GetComponent<OkoshkoScript>().text = "\"Огонь по штабам\" не куплен";
			}
			if (GlobalScript.inst.dlc[3])
			{
				dlcs[2].GetComponent<SpriteRenderer>().sprite = dlc_sprites[2];
				dlcs[2].GetComponent<OkoshkoScript>().text_en = "\"The Fallen Eagle\" activated";
				dlcs[2].GetComponent<OkoshkoScript>().text = "\"Падший Орёл\" включен";
			}
			else
			{
				dlcs[2].GetComponent<OkoshkoScript>().text_en = "\"The Fallen Eagle\" is needed";
				dlcs[2].GetComponent<OkoshkoScript>().text = "\"Падший Орёл\" не куплен";
			}
			if (GlobalScript.inst.dlc[5])
			{
				dlcs[4].GetComponent<SpriteRenderer>().sprite = dlc_sprites[4];
				dlcs[4].GetComponent<OkoshkoScript>().text_en = "\"Heroes of War & Money\" activated";
				dlcs[4].GetComponent<OkoshkoScript>().text = "\"Герои Войны и Денег\" включен";
			}
			else
			{
				dlcs[4].GetComponent<OkoshkoScript>().text_en = "\"Heroes of War & Money\" is needed";
				dlcs[4].GetComponent<OkoshkoScript>().text = "\"Герои Войны и Денег\" не куплен";
			}
			if (GlobalScript.inst.dlc[6])
			{
				dlcs[5].GetComponent<SpriteRenderer>().sprite = dlc_sprites[5];
				dlcs[5].GetComponent<OkoshkoScript>().text_en = "\"Red Genes\" activated";
				dlcs[5].GetComponent<OkoshkoScript>().text = "\"Красные гены\" включен";
			}
			else
			{
				dlcs[5].GetComponent<OkoshkoScript>().text_en = "\"Red Genes\" is needed";
				dlcs[5].GetComponent<OkoshkoScript>().text = "\"Красные гены\" не куплен";
			}
			if (GlobalScript.inst.dlc[8])
			{
				dlcs[6].GetComponent<SpriteRenderer>().sprite = dlc_sprites[6];
				dlcs[6].GetComponent<OkoshkoScript>().text_en = "\"Lei Feng's Legacy\" activated";
				dlcs[6].GetComponent<OkoshkoScript>().text = "\"Наследие Лей Фэна\" включен";
			}
			else
			{
				dlcs[6].GetComponent<OkoshkoScript>().text_en = "\"Lei Feng's Legacy\" is needed";
				dlcs[6].GetComponent<OkoshkoScript>().text = "\"Наследие Лей Фэна\" не куплен";
			}
		}
	}
}
