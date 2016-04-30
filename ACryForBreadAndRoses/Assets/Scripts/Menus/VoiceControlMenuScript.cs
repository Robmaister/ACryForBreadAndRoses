using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class VoiceControlMenuScript : MonoBehaviour {

	public Text textBox;
	public VoiceControl ctrl;

	private List<KeyValuePair<float, string>> freqToNote;

	void Start()
	{
		freqToNote = new List<KeyValuePair<float, string>>();
		freqToNote.Add(new KeyValuePair<float, string>(16.35f, "C0"));
		freqToNote.Add(new KeyValuePair<float, string>(17.32f, "C#0/Db0"));
		freqToNote.Add(new KeyValuePair<float, string>(18.35f, "D0"));
		freqToNote.Add(new KeyValuePair<float, string>(19.45f, "D#0/Eb0"));
		freqToNote.Add(new KeyValuePair<float, string>(20.60f, "E0"));
		freqToNote.Add(new KeyValuePair<float, string>(21.83f, "F0"));
		freqToNote.Add(new KeyValuePair<float, string>(23.12f, "F#0/Gb0"));
		freqToNote.Add(new KeyValuePair<float, string>(24.50f, "G0"));
		freqToNote.Add(new KeyValuePair<float, string>(25.96f, "G#0/Ab0"));
		freqToNote.Add(new KeyValuePair<float, string>(27.50f, "A0"));
		freqToNote.Add(new KeyValuePair<float, string>(29.14f, "A#0/Bb0"));
		freqToNote.Add(new KeyValuePair<float, string>(30.87f, "B0"));
		freqToNote.Add(new KeyValuePair<float, string>(32.70f, "C1"));
		freqToNote.Add(new KeyValuePair<float, string>(34.65f, "C#1/Db1"));
		freqToNote.Add(new KeyValuePair<float, string>(36.71f, "D1"));
		freqToNote.Add(new KeyValuePair<float, string>(38.89f, "D#1/Eb1"));
		freqToNote.Add(new KeyValuePair<float, string>(41.20f, "E1"));
		freqToNote.Add(new KeyValuePair<float, string>(43.65f, "F1"));
		freqToNote.Add(new KeyValuePair<float, string>(46.25f, "F#1/Gb1"));
		freqToNote.Add(new KeyValuePair<float, string>(49.00f, "G1"));
		freqToNote.Add(new KeyValuePair<float, string>(51.91f, "G#1/Ab1"));
		freqToNote.Add(new KeyValuePair<float, string>(55.00f, "A1"));
		freqToNote.Add(new KeyValuePair<float, string>(58.27f, "A#1/Bb1"));
		freqToNote.Add(new KeyValuePair<float, string>(61.74f, "B1"));
		freqToNote.Add(new KeyValuePair<float, string>(65.41f, "C2"));
		freqToNote.Add(new KeyValuePair<float, string>(69.30f, "C#2/Db2"));
		freqToNote.Add(new KeyValuePair<float, string>(73.42f, "D2"));
		freqToNote.Add(new KeyValuePair<float, string>(77.78f, "D#2/Eb2"));
		freqToNote.Add(new KeyValuePair<float, string>(82.41f, "E2"));
		freqToNote.Add(new KeyValuePair<float, string>(87.31f, "F2"));
		freqToNote.Add(new KeyValuePair<float, string>(92.50f, "F#2/Gb2"));
		freqToNote.Add(new KeyValuePair<float, string>(98.00f, "G2"));
		freqToNote.Add(new KeyValuePair<float, string>(103.83f, "G#2/Ab2"));
		freqToNote.Add(new KeyValuePair<float, string>(110.00f, "A2"));
		freqToNote.Add(new KeyValuePair<float, string>(116.54f, "A#2/Bb2"));
		freqToNote.Add(new KeyValuePair<float, string>(123.47f, "B2"));
		freqToNote.Add(new KeyValuePair<float, string>(130.81f, "C3"));
		freqToNote.Add(new KeyValuePair<float, string>(138.59f, "C#3/Db3"));
		freqToNote.Add(new KeyValuePair<float, string>(146.83f, "D3"));
		freqToNote.Add(new KeyValuePair<float, string>(155.56f, "D#3/Eb3"));
		freqToNote.Add(new KeyValuePair<float, string>(164.81f, "E3"));
		freqToNote.Add(new KeyValuePair<float, string>(174.61f, "F3"));
		freqToNote.Add(new KeyValuePair<float, string>(185.00f, "F#3/Gb3"));
		freqToNote.Add(new KeyValuePair<float, string>(196.00f, "G3"));
		freqToNote.Add(new KeyValuePair<float, string>(207.65f, "G#3/Ab3"));
		freqToNote.Add(new KeyValuePair<float, string>(220.00f, "A3"));
		freqToNote.Add(new KeyValuePair<float, string>(233.08f, "A#3/Bb3"));
		freqToNote.Add(new KeyValuePair<float, string>(246.94f, "B3"));
		freqToNote.Add(new KeyValuePair<float, string>(261.63f, "C4"));
		freqToNote.Add(new KeyValuePair<float, string>(277.18f, "C#4/Db4"));
		freqToNote.Add(new KeyValuePair<float, string>(293.66f, "D4"));
		freqToNote.Add(new KeyValuePair<float, string>(311.13f, "D#4/Eb4"));
		freqToNote.Add(new KeyValuePair<float, string>(329.63f, "E4"));
		freqToNote.Add(new KeyValuePair<float, string>(349.23f, "F4"));
		freqToNote.Add(new KeyValuePair<float, string>(369.99f, "F#4/Gb4"));
		freqToNote.Add(new KeyValuePair<float, string>(392.00f, "G4"));
		freqToNote.Add(new KeyValuePair<float, string>(415.30f, "G#4/Ab4"));
		freqToNote.Add(new KeyValuePair<float, string>(440.00f, "A4"));
		freqToNote.Add(new KeyValuePair<float, string>(466.16f, "A#4/Bb4"));
		freqToNote.Add(new KeyValuePair<float, string>(493.88f, "B4"));
		freqToNote.Add(new KeyValuePair<float, string>(523.25f, "C5"));
		freqToNote.Add(new KeyValuePair<float, string>(554.37f, "C#5/Db5"));
		freqToNote.Add(new KeyValuePair<float, string>(587.33f, "D5"));
		freqToNote.Add(new KeyValuePair<float, string>(622.25f, "D#5/Eb5"));
		freqToNote.Add(new KeyValuePair<float, string>(659.25f, "E5"));
		freqToNote.Add(new KeyValuePair<float, string>(698.46f, "F5"));
		freqToNote.Add(new KeyValuePair<float, string>(739.99f, "F#5/Gb5"));
		freqToNote.Add(new KeyValuePair<float, string>(783.99f, "G5"));
		freqToNote.Add(new KeyValuePair<float, string>(830.61f, "G#5/Ab5"));
		freqToNote.Add(new KeyValuePair<float, string>(880.00f, "A5"));
		freqToNote.Add(new KeyValuePair<float, string>(932.33f, "A#5/Bb5"));
		freqToNote.Add(new KeyValuePair<float, string>(987.77f, "B5"));
		freqToNote.Add(new KeyValuePair<float, string>(1046.50f, "C6"));
		freqToNote.Add(new KeyValuePair<float, string>(1108.73f, "C#6/Db6"));
		freqToNote.Add(new KeyValuePair<float, string>(1174.66f, "D6"));
		freqToNote.Add(new KeyValuePair<float, string>(1244.51f, "D#6/Eb6"));
		freqToNote.Add(new KeyValuePair<float, string>(1318.51f, "E6"));
		freqToNote.Add(new KeyValuePair<float, string>(1396.91f, "F6"));
		freqToNote.Add(new KeyValuePair<float, string>(1479.98f, "F#6/Gb6"));
		freqToNote.Add(new KeyValuePair<float, string>(1567.98f, "G6"));
		freqToNote.Add(new KeyValuePair<float, string>(1661.22f, "G#6/Ab6"));
		freqToNote.Add(new KeyValuePair<float, string>(1760.00f, "A6"));
		freqToNote.Add(new KeyValuePair<float, string>(1864.66f, "A#6/Bb6"));
		freqToNote.Add(new KeyValuePair<float, string>(1975.53f, "B6"));
		freqToNote.Add(new KeyValuePair<float, string>(2093.00f, "C7"));
		freqToNote.Add(new KeyValuePair<float, string>(2217.46f, "C#7/Db7"));
		freqToNote.Add(new KeyValuePair<float, string>(2349.32f, "D7"));
		freqToNote.Add(new KeyValuePair<float, string>(2489.02f, "D#7/Eb7"));
		freqToNote.Add(new KeyValuePair<float, string>(2637.02f, "E7"));
		freqToNote.Add(new KeyValuePair<float, string>(2793.83f, "F7"));
		freqToNote.Add(new KeyValuePair<float, string>(2959.96f, "F#7/Gb7"));
		freqToNote.Add(new KeyValuePair<float, string>(3135.96f, "G7"));
		freqToNote.Add(new KeyValuePair<float, string>(3322.44f, "G#7/Ab7"));
		freqToNote.Add(new KeyValuePair<float, string>(3520.00f, "A7"));
		freqToNote.Add(new KeyValuePair<float, string>(3729.31f, "A#7/Bb7"));
		freqToNote.Add(new KeyValuePair<float, string>(3951.07f, "B7"));
		freqToNote.Add(new KeyValuePair<float, string>(4186.01f, "C8"));
		freqToNote.Add(new KeyValuePair<float, string>(4434.92f, "C#8/Db8"));
		freqToNote.Add(new KeyValuePair<float, string>(4698.63f, "D8"));
		freqToNote.Add(new KeyValuePair<float, string>(4978.03f, "D#8/Eb8"));
		freqToNote.Add(new KeyValuePair<float, string>(5274.04f, "E8"));
		freqToNote.Add(new KeyValuePair<float, string>(5587.65f, "F8"));
		freqToNote.Add(new KeyValuePair<float, string>(5919.91f, "F#8/Gb8"));
		freqToNote.Add(new KeyValuePair<float, string>(6271.93f, "G8"));
		freqToNote.Add(new KeyValuePair<float, string>(6644.88f, "G#8/Ab8"));
		freqToNote.Add(new KeyValuePair<float, string>(7040.00f, "A8"));
		freqToNote.Add(new KeyValuePair<float, string>(7458.62f, "A#8/Bb8"));
		freqToNote.Add(new KeyValuePair<float, string>(7902.13f, "B8"));
	}

	void Update()
	{
		if (ctrl != null && textBox != null)
		{
			float pitch = ctrl.PitchValue;

			string note = "null";
			if (pitch != 0)
			{
				if (ctrl.PitchValue < freqToNote[0].Key)
					note = freqToNote[0].Value;
				else if (ctrl.PitchValue > freqToNote[freqToNote.Count - 1].Key)
					note = freqToNote[freqToNote.Count - 1].Value;
				else
				{
					for (int i = 1; i < freqToNote.Count; i++)
					{
						float distPrev = pitch - freqToNote[i - 1].Key;
						if (distPrev > 0)
							continue;

						float distCur = pitch - freqToNote[i].Key;

						if (Mathf.Abs(distPrev) < Mathf.Abs(distCur))
							note = freqToNote[i - 1].Value;
						else
							note = freqToNote[i].Value;

						break;
					}
				}
			}

			textBox.text = "Pitch: " + pitch + "Hz\nVolume: " + ctrl.DbValue + "dB\nRMS: " + ctrl.RmsValue + "\n\nNote: " + note;
		}
	}

	public void ReturnToMainMenuButton()
	{
		SceneManager.LoadScene(0);
	}
}
