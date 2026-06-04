using System;

[Serializable]
public class IntArray
{
	public int[] array;

	public int min;

	public int max;

	public int this[int index]
	{
		get
		{
			return array[index];
		}
		set
		{
			if (value > max)
			{
				array[index] = max;
			}
			else if (value < min)
			{
				array[index] = min;
			}
			else
			{
				array[index] = value;
			}
		}
	}

	public IntArray(int min, int max, int length)
	{
		this.max = max;
		this.min = min;
		array = new int[length];
	}

	public IntArray(int min, int max, int[] array)
	{
		this.max = max;
		this.min = min;
		this.array = array.Clone() as int[];
	}
}
