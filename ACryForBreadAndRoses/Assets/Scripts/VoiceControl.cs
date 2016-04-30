using UnityEngine;
using System.Collections;

public class VoiceControl : MonoBehaviour {

	#region vars
	public string CurrentAudioInput;

	private AudioObj[] audioObj = new AudioObj[2];

	public string[] inputDevices;

	private const int QSamples = 8192;
	private const float RefValue = 0.1f;
	private const float Threshold = 0.002f;

	private float[] outData = new float[QSamples];
	private float[] freqData = new float[QSamples];
	private float fSample = 48000;

	public float RmsValue;
	public float DbValue;
	public float PitchValue;

	public GameObject playerPrefab;
	private int index = 0;

	public static VoiceControl Instance;
	private int deviceNum;

	private struct AudioObj
	{
		public GameObject player;
		public AudioClip clip;
		public void SetClip(AudioClip c)
		{
			clip = c;
			player.GetComponent<AudioSource>().clip = c;
			/*
	slowing the playback down a small amount allows enough space between
	recording and output so that analysis does not overtake the recording.
	this helps with stutter and distortion, but doesn't solve it completely
	*/
			player.GetComponent<AudioSource>().pitch = .95f;
		}
	}
	#endregion

	#region Unity Methods
	void Start()
	{
		Instance = this;

		for (int i = 0; i < audioObj.Length; i++)
		{
			audioObj[i].player = (GameObject)Instantiate(playerPrefab);
			audioObj[i].player.transform.parent = transform;
			audioObj[i].player.transform.position = Vector3.zero;
			audioObj[i].clip = new AudioClip();
		}

		inputDevices = new string[Microphone.devices.Length];
		deviceNum = Microphone.devices.Length - 1;

		for (int i = 0; i < Microphone.devices.Length; i++)
			inputDevices[i] = Microphone.devices[i].ToString();

		CurrentAudioInput = Microphone.devices[deviceNum].ToString();

		InvokeRepeating("Check", 0, 1.0f / 15.0f);
		StartCoroutine(StartRecord());

	}
	#endregion

	#region Actions

	private void Check()
	{
		AudioSource source = audioObj[Mathf.Abs((index % 2) - 1)].player.GetComponent<AudioSource>();

		source.GetOutputData(outData, 0);

		int i;
		float sum = 0;
		for (i = 0; i < QSamples; i++)
		{
			sum += outData[i] * outData[i]; // sum squared samples
		}
		RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average
		DbValue = 20 * Mathf.Log10(RmsValue / RefValue); // calculate dB
		if (DbValue < -160) DbValue = -160; // clamp it to -160dB min
											// get sound spectrum

		source.GetSpectrumData(freqData, 0, FFTWindow.BlackmanHarris);
		float maxV = 0;
		var maxN = 0;
		for (i = 0; i < QSamples; i++)
		{ // find max 
			if (!(freqData[i] > maxV) || !(freqData[i] > Threshold))
				continue;

			maxV = freqData[i];
			maxN = i; // maxN is the index of max
		}
		float freqN = maxN; // pass the index to a float variable
		if (maxN > 0 && maxN < QSamples - 1)
		{ // interpolate index using neighbours
			var dL = freqData[maxN - 1] / freqData[maxN];
			var dR = freqData[maxN + 1] / freqData[maxN];
			freqN += 0.5f * (dR * dR - dL * dL);
		}
		PitchValue = freqN * (fSample / 2) / QSamples; // convert index to frequency
	}

	private IEnumerator StartRecord()
	{

		audioObj[index].clip = Microphone.Start(Microphone.devices[deviceNum], true, 5, 48000);
		/*
	the longer the mic recording time, the less often there are "hiccups" in game performance
	but also due to being pitched down, the playback gradually falls farther behind the recording
	*/

		print("recording to audioObj " + index);
		StartCoroutine(StartPlay(audioObj[index].clip));
		yield return new WaitForSeconds(5);
		StartCoroutine(StartRecord()); //swaps audio buffers, begins recording and playback of new buffer
									   /* it is necessary to swap buffers, otherwise the audioclip quickly becomes too large and begins to slow down the system */

	}

	private IEnumerator StartPlay(AudioClip buffer)
	{
		audioObj[index].SetClip(buffer);
		yield return new WaitForSeconds(.01f);
		audioObj[index].player.SetActive(true);
		audioObj[index].player.GetComponent<AudioSource>().Play();

		audioObj[Mathf.Abs((index % 2) - 1)].player.GetComponent<AudioSource>().Stop();

		index++;
		if (index > 1)
			index = 0;


	}

	#endregion


}
