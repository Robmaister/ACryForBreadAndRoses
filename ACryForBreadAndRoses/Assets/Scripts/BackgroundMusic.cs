using UnityEngine;
using System.Collections.Generic;

public class BackgroundMusic : MonoBehaviour
{
	private static BackgroundMusic instance = null;
	public static BackgroundMusic Instance { get { return instance; } }

	public List<AudioClip> MusicClips;
	private int clipIndex = 0;
	private bool startedPlaying = false;

	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
			instance = this;

		DontDestroyOnLoad(this.gameObject);
	}

	public void Update()
	{
		if (startedPlaying)
		{
			if (!GetComponent<AudioSource>().isPlaying)
			{
				clipIndex++;
				if (clipIndex < MusicClips.Count)
				{
					GetComponent<AudioSource>().clip = MusicClips[clipIndex];
					GetComponent<AudioSource>().Play();
				}
				else
				{
					GetComponent<AudioSource>().clip = null;
					startedPlaying = false;
				}
			}
		}
	}

	public void StartPlaying()
	{
		clipIndex = 0;
		startedPlaying = true;
		GetComponent<AudioSource>().clip = MusicClips[0];
		GetComponent<AudioSource>().Play();
	}
}
