using UnityEngine;
using System.Collections;

public class CutsceneAction : MonoBehaviour {

	[HideInInspector]
	public Cutscene parentCutscene;

	protected bool done;

	protected virtual void ActionStart()
	{
	}

	protected virtual void ActionUpdate()
	{
	}


	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		done = false;
		ActionStart();
	}

	void Update ()
	{
		ActionUpdate();

		if (done)
		{
			parentCutscene.CompleteAction();
			return;
		}
	}
}
