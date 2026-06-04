using System.Linq;
using UnityEngine;

public class ChangeCountryScript : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _background;

	[SerializeField]
	private Sprite[] _backs = new Sprite[2];

	[SerializeField]
	private GameStartScript _game1;

	[SerializeField]
	private TextMesh _country;

	[SerializeField]
	private bool _right;

	[SerializeField]
	private int _lng;

	private GlobalScript global1;

	[SerializeField]
	private int[] playableCountries;

	private void Start()
	{
		global1 = GlobalScript.inst;
		_lng = PlayerPrefs.GetInt("language");
		if (!_right)
		{
			global1.gameState.PlayerCountry = playableCountries[playableCountries.Length - 1];
			ChangeCountry();
		}
	}

	private void OnMouseDown()
	{
		ChangeCountry();
	}

	private void OnMouseEnter()
	{
		GetComponent<SpriteRenderer>().color = Color.grey;
	}

	private void OnMouseExit()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	private void ChangeCountry()
	{
		int num = playableCountries.ToList().IndexOf(global1.gameState.PlayerCountry);
		if (_right)
		{
			global1.gameState.PlayerCountry = ((num != 0) ? playableCountries[num - 1] : playableCountries[playableCountries.Length - 1]);
			num = playableCountries.ToList().IndexOf(global1.gameState.PlayerCountry);
		}
		else
		{
			global1.gameState.PlayerCountry = ((num != playableCountries.Length - 1) ? playableCountries[num + 1] : playableCountries[0]);
			num = playableCountries.ToList().IndexOf(global1.gameState.PlayerCountry);
		}
		_background.sprite = _backs[num];
		if (global1.gameState.PlayerCountry == 21)
		{
			if (_lng == 0)
			{
				_country.text = "France";
			}
			else
			{
				_country.text = "Франция";
			}
		}
		else if (global1.gameState.PlayerCountry == 1)
		{
			if (_lng == 0)
			{
				_country.text = "China";
			}
			else
			{
				_country.text = "Китай";
			}
		}
		else if (_lng == 0)
		{
			_country.text = "USSR";
		}
		else
		{
			_country.text = "СССР";
		}
	}
}
