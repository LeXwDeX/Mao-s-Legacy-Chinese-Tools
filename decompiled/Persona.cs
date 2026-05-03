using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Persona
{
	public string name;

	public string surname;

	public int age;

	private int _children;

	private int _wealth;

	private int _charisma;

	private int _intrigue;

	public Job status;

	public CitizenManager.PrimaryTrait primaryTrait;

	public CitizenManager.SecondaryTrait secondaryTrait;

	public List<CitizenManager.TertiaryTrait> tertiaryTraits = new List<CitizenManager.TertiaryTrait>();

	public List<Job> jobHistory = new List<Job>();

	public int[] birthDate = new int[3];

	public byte face_type;

	public byte[] face_parts = new byte[8];

	public byte jacket;

	public bool isPolitic;

	public bool isDead;

	public bool hasBeenPursued;

	public bool isLead;

	public int[] lastDeathCheck = new int[3];

	public int[] lastFinanceSupport = new int[3];

	public List<string> changeLog = new List<string>();

	public int Children
	{
		get
		{
			return _children;
		}
		set
		{
			_children = Mathf.Clamp(value, 0, 5);
		}
	}

	public int Wealth
	{
		get
		{
			return _wealth;
		}
		set
		{
			_wealth = Mathf.Clamp(value, 0, 15);
		}
	}

	public int Charisma
	{
		get
		{
			return _charisma;
		}
		set
		{
			_charisma = Mathf.Clamp(value, 0, 15);
		}
	}

	public int Intrigue
	{
		get
		{
			return _intrigue;
		}
		set
		{
			_intrigue = Mathf.Clamp(value, 0, 15);
		}
	}
}
