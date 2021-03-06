﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSceneAction : CutsceneAction
{
	public string NextScene;

	private UIManager uiMgr;

	protected override void ActionStart()
	{
		uiMgr = GameObject.Find("UICanvas").GetComponent<UIManager>();

		uiMgr.FadeOut();
	}

	protected override void ActionUpdate()
	{
		if (uiMgr.IsDoneFadingOut)
		{
			done = true;

			SceneManager.LoadScene(NextScene);
		}
	}
}
