using UnityEngine;
using System.Collections.Generic;

public class LogicalAndAction : CutsceneAction
{
	private List<CutsceneAction> subActions;

	protected override void ActionStart()
	{
		subActions = new List<CutsceneAction>();

		for (int i = 0; i < transform.childCount; i++)
		{
			Transform t = transform.GetChild(i);
			t.gameObject.SetActive(true);

			CutsceneAction act = t.GetComponent<CutsceneAction>();
			if (act != null)
			{
				act.OnActionInit();
				subActions.Add(act);
			}
		}
	}

	protected override void ActionUpdate()
	{
		bool subDone = true;
		foreach (var action in subActions)
		{
			if (!action.IsDone)
			{
				subDone = false;
				break;
			}
		}

		if (subDone)
		{
			done = true;
		}
	}
}
