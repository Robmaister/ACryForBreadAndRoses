using UnityEngine;
using System.Collections;

public class WaitAction : CutsceneAction
{
	public float waitTime = 1f;

	// Update is called once per frame
	protected override void ActionStart()
	{
		base.ActionStart();

		StartCoroutine(DoWait());
	}

	IEnumerator DoWait()
	{
		yield return new WaitForSeconds(waitTime);
		done = true;
		yield return null;
	}
}
