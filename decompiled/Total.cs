using System.Collections.Generic;
using UnityEngine;

public class Total : MonoBehaviour
{
	public AudioClip[] all = new AudioClip[10];

	private List<int> toPlay = new List<int>();

	private AudioSource audio_now;

	private void Awake()
	{
		audio_now = GetComponent<AudioSource>();
	}

	private bool isInQue(int number)
	{
		for (int i = 0; i < toPlay.Count; i++)
		{
			if (number == toPlay[i])
			{
				return true;
			}
		}
		return false;
	}

	public void Play(int number)
	{
		if (!isInQue(number))
		{
			toPlay.Add(number);
		}
	}

	private void Update()
	{
		if (!audio_now.isPlaying && toPlay.Count > 0)
		{
			audio_now.PlayOneShot(all[toPlay[0]]);
			toPlay.RemoveAt(0);
		}
	}
}
