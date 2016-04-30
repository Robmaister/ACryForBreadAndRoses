using UnityEngine;
using System.Collections;

public class FadeInBackgroundAction : CutsceneAction
{

	private UIManager uiMgr;

	protected override void ActionStart()
	{
		uiMgr = GameObject.Find("UICanvas").GetComponent<UIManager>();
		uiMgr.FadeBackground();
	}

	protected override void ActionUpdate()
	{
		if (uiMgr.IsDoneFadingBackground)
		{
			done = true;
		}
	}
}
