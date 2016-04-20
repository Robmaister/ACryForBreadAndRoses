using UnityEngine;
using System.Collections.Generic;

using UnityStandardAssets._2D;

public class Cutscene : MonoBehaviour {

	public bool LockPlayer = true;

	private List<CutsceneAction> actions;
	private int currentAction = 0;

	private Platformer2DUserControl playerControl;

	void OnEnable()
	{
		actions = new List<CutsceneAction>();
		foreach (CutsceneAction action in GetComponentsInChildren<CutsceneAction>())
			actions.Add(action);

		if (actions.Count == 0)
			return;

		if (LockPlayer)
		{
			playerControl = GameObject.Find("PlayerCharacter").GetComponent<Platformer2DUserControl>();
			playerControl.enabled = false;
		}

		foreach (var action in actions)
		{
			action.enabled = false;
			action.parentCutscene = this;
		}

		actions[0].enabled = true;
	}

	public void CompleteAction()
	{
		actions[currentAction].enabled = false;
		currentAction++;

		if (currentAction < actions.Count)
			actions[currentAction].enabled = true;
		else
		{
			enabled = false;

			if (playerControl != null)
				playerControl.enabled = true;

			//TODO fire off event?
		}
	}
}
