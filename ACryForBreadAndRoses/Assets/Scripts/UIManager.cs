using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public DialogManager Dialog;
	public PuzzleBase Puzzle;

	private Image fadeImage;

	private bool startFading;
	private bool doneFading;

	public bool IsDoneFading { get { return doneFading; } }

	// Use this for initialization
	void Start ()
	{
		Dialog = transform.Find("DialogBase").GetComponent<DialogManager>();
		Puzzle = transform.Find("PuzzleBase").GetComponent<PuzzleBase>();
	}

	void Update()
	{
		if (startFading)
		{
			Color c = fadeImage.color;
			c.a += 0.01f;
			fadeImage.color = c;

			if (c.a >= 1.0f)
			{
				startFading = false;
				doneFading = true;
			}
		}
	}

	public void FadeOut()
	{
		startFading = true;

		if (fadeImage == null)
			fadeImage = gameObject.AddComponent<Image>();

		fadeImage.color = Color.clear;
	}
}
