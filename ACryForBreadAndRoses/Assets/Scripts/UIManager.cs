using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public bool FadeInScene = true;

	[HideInInspector]
	public DialogManager Dialog;

	[HideInInspector]
	public PuzzleBase Puzzle;

	private Image fadeImage;
	private Image backgroundImage;

	private bool startFadingIn;
	private bool doneFadingIn;

	private bool startFadingOut;
	private bool doneFadingOut;

	private bool startFadingBg;
	private bool doneFadingBg;

	public bool IsDoneFadingOut { get { return doneFadingOut; } }

	public bool IsDoneFadingBackground { get { return doneFadingBg; } }

	// Use this for initialization
	void Start ()
	{
		Dialog = transform.Find("DialogBase").GetComponent<DialogManager>();
		Puzzle = transform.Find("PuzzleBase").GetComponent<PuzzleBase>();

		if (FadeInScene)
		{
			if (fadeImage == null)
				fadeImage = gameObject.AddComponent<Image>();

			fadeImage.color = Color.black;
			startFadingIn = true;
		}
	}

	void Update()
	{
		if (startFadingIn)
		{
			Color c = fadeImage.color;
			c.a -= 0.01f;
			fadeImage.color = c;

			if (c.a <= 0.0f)
			{
				startFadingIn = false;
				doneFadingIn = true;
			}
		}

		if (startFadingOut)
		{
			if (backgroundImage != null)
			{
				Color c = fadeImage.color;
				c.a = 1;
				fadeImage.color = c;

				c = backgroundImage.color;
				c.a -= 0.01f;
				backgroundImage.color = c;

				if (c.a <= 0.0f)
				{
					startFadingOut = false;
					doneFadingOut = true;
				}
			}
			else
			{
				Color c = fadeImage.color;
				c.a += 0.01f;
				fadeImage.color = c;

				if (c.a >= 1.0f)
				{
					startFadingOut = false;
					doneFadingOut = true;
				}
			}
		}

		if (startFadingBg)
		{
			Color c = backgroundImage.color;
			c.a += 0.01f;
			backgroundImage.color = c;

			if (c.a >= 1.0f)
			{
				startFadingBg = false;
				doneFadingBg = true;
			}
		}
	}

	public void FadeOut()
	{
		startFadingOut = true;

		if (fadeImage == null)
			fadeImage = gameObject.AddComponent<Image>();

		fadeImage.color = Color.clear;
	}

	public void FadeBackground()
	{
		if (backgroundImage == null)
		{
			backgroundImage = transform.Find("BackgroundImage").GetComponent<Image>();
		}

		Color bgColor = new Color(1, 1, 1, 0);
		backgroundImage.color = bgColor;
		backgroundImage.enabled = true;
		startFadingBg = true;
	}
}
