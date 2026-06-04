using System;

[Serializable]
public class LeftComposition
{
	private int _Maoist;

	private int _Leninists;

	private int _Reformers;

	private int _SocDem;

	public float Maoist => (float)_Maoist / (float)Popularity;

	public float Leninists => (float)_Leninists / (float)Popularity;

	public float SocDem => (float)_Maoist / (float)Popularity;

	public float Reformers => (float)_Maoist / (float)Popularity;

	public int Popularity => _Maoist + _Leninists + _Reformers + _SocDem;

	public LeftComposition(int value)
	{
		value /= 4;
		_Maoist += value;
		_Leninists += value;
		_Reformers += value;
		_SocDem += value;
	}

	public void AddMaoist(int value)
	{
		_Maoist += value;
	}

	public void DecreaseMaoist(int value)
	{
		if (_Maoist - value > 0)
		{
			_Maoist -= value;
		}
	}

	public void AddLeninists(int value)
	{
		_Leninists += value;
	}

	public void DecreaseLeninists(int value)
	{
		if (_Leninists - value > 0)
		{
			_Leninists -= value;
		}
	}

	public void AddSocDem(int value)
	{
		_SocDem += value;
	}

	public void DecreaseSocDem(int value)
	{
		if (_SocDem - value > 0)
		{
			_SocDem -= value;
		}
	}

	public void AddReformers(int value)
	{
		_Reformers += value;
	}

	public void DecreaseReformers(int value)
	{
		if (_Reformers - value > 0)
		{
			_Reformers -= value;
		}
	}

	public void AddPopularity(int value)
	{
		value /= 4;
		_Maoist += value;
		_Leninists += value;
		_Reformers += value;
		_SocDem += value;
	}

	public void DecreasePopularity(int value)
	{
		value /= 4;
		if (_Leninists - value > 0)
		{
			_Leninists -= value;
		}
		if (_Maoist - value > 0)
		{
			_Maoist -= value;
		}
		if (_Reformers - value > 0)
		{
			_Reformers -= value;
		}
		if (_SocDem - value > 0)
		{
			_SocDem -= value;
		}
	}
}
