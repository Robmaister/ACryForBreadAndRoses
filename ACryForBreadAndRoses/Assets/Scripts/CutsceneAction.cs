using UnityEngine;
using System.Collections;

public class CutsceneAction : MonoBehaviour {

	[HideInInspector]
	public Cutscene parentCutscene;

	protected bool done;
	private bool started = false;

	public bool IsDone { get { return done; } }

	protected virtual void ActionStart()
	{
	}

	protected virtual void ActionUpdate()
	{
	}

	public void OnActionInit()
	{
		done = false;
		ActionStart();

		started = true;
	}

	void Update ()
	{
		if (!started)
			return;

		ActionUpdate();

		if (done)
		{
			if (parentCutscene)
				parentCutscene.CompleteAction();
			else
				gameObject.SetActive(false);

			return;
		}
	}
}
