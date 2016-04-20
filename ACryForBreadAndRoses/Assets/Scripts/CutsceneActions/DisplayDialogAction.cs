using UnityEngine;
using System.Collections;

public class DisplayDialogAction : CutsceneAction
{

	[TextArea(3, 10)]
	public string Dialog;
	public string LeftName;
	public string RightName;

	private DialogManager dialogMgr;

	protected override void ActionStart()
	{
		base.ActionStart();

		dialogMgr = GameObject.Find("UICanvas").GetComponent<UIManager>().Dialog;

		dialogMgr.DisplayDialog(Dialog, LeftName, RightName);
	}

	protected override void ActionUpdate()
	{
		base.ActionUpdate();

		if (Input.GetMouseButtonUp(0))
		{
			done = true;
			dialogMgr.HideDialog();
		}
	}
}
