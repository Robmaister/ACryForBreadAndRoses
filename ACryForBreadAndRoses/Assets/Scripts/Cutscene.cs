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

		for (int i = 0; i < transform.childCount; i++)
		{
			Transform t = transform.GetChild(i);

			CutsceneAction act = t.GetComponent<CutsceneAction>();
			if (act != null)
				actions.Add(act);
		}

		if (actions.Count == 0)
			return;

		if (LockPlayer)
		{
			playerControl = GameObject.Find("PlayerCharacter").GetComponent<Platformer2DUserControl>();
			playerControl.enabled = false;
		}

		foreach (var action in actions)
		{
			action.parentCutscene = this;
			action.gameObject.SetActive(false);
		}

		actions[0].gameObject.SetActive(true);
		actions[0].OnActionInit();
	}

	public void CompleteAction()
	{
		actions[currentAction].gameObject.SetActive(false);
		currentAction++;

		if (currentAction < actions.Count)
		{
			actions[currentAction].gameObject.SetActive(true);
			actions[currentAction].OnActionInit();
		}
		else
		{
			gameObject.SetActive(false);

			if (playerControl != null)
				playerControl.enabled = true;

			//TODO fire off event?
		}
	}
}
