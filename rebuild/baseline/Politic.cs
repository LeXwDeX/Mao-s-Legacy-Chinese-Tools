using System;

[Serializable]
public class Politic
{
	public bool is_sagovor;

	public bool is_sleshka;

	public bool is_sledstvie;

	public bool you_fall;

	public int days_sleshka;

	public int sled_slej;

	public int wantedDolzh = 3;

	public byte[] traits = new byte[3];

	public int loyality;

	public int[] loyality_to_other = new int[18];

	public int power;

	public byte name_1;

	public byte name_2;

	public byte face_type;

	public byte[] face_parts = new byte[8];

	public byte jacket;

	public byte age;

	public byte in_power;

	public int autosupport;

	public int autohound;

	public bool isCitizen;
}
