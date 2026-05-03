using System;

[Serializable]
public class RightComposition
{
	private int _Conservatives;

	private int _Liberals;

	private int _Centrists;

	public float Liberals => (float)_Liberals / (float)Popularity;

	public float Conservatives => (float)_Conservatives / (float)Popularity;

	public float Centrists => (float)_Centrists / (float)Popularity;

	public int Popularity => _Centrists + _Conservatives + _Liberals;

	public RightComposition(int value)
	{
		value /= 3;
		_Conservatives += value;
		_Liberals += value;
		_Centrists += value;
	}

	public void AddLiberals(int value)
	{
		_Liberals += value;
	}

	public void DecreaseLiberals(int value)
	{
		if (_Liberals - value > 0)
		{
			_Liberals -= value;
		}
	}

	public void AddConservatives(int value)
	{
		_Conservatives += value;
	}

	public void DecreaseConservatives(int value)
	{
		if (_Conservatives - value > 0)
		{
			_Conservatives -= value;
		}
	}

	public void AddCentrists(int value)
	{
		_Centrists += value;
	}

	public void DecreaseCentrists(int value)
	{
		if (_Centrists - value > 0)
		{
			_Centrists -= value;
		}
	}

	public void AddPopularity(int value)
	{
		value /= 3;
		_Conservatives += value;
		_Liberals += value;
		_Centrists += value;
	}

	public void DecreasePopularity(int value)
	{
		value /= 3;
		if (_Conservatives - value > 0)
		{
			_Conservatives -= value;
		}
		if (_Centrists - value > 0)
		{
			_Centrists -= value;
		}
		if (_Liberals - value > 0)
		{
			_Liberals -= value;
		}
	}
}
