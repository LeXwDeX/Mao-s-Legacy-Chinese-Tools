using System;

[Serializable]
public class SaveMetadata
{
	public int id;

	public string name = "Save";

	public string fileBase = string.Empty;

	public int day;

	public int month;

	public int year;

	public int diff;

	public bool iron;

	public int data14;

	public string runHash = string.Empty;

	public string createdUtc;

	public string updatedUtc;
}
