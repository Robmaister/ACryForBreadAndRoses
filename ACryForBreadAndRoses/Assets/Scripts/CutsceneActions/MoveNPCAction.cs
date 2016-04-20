using UnityEngine;
using System.Collections;

using UnityStandardAssets._2D;

public class MoveNPCAction : CutsceneAction
{
	public PlatformerCharacter2D NPC;
	public float Distance;
	public float Speed;

	private float startPos;
	private float endPos;

	protected override void ActionStart()
	{
		startPos = NPC.transform.position.x;
		endPos = NPC.transform.position.x + Distance;

		//make sure the player doesn't move the wrong way
		if (Mathf.Sign(Distance) != Mathf.Sign(Speed))
			Speed = -Speed;
	}

	protected override void ActionUpdate()
	{
		NPC.Move(Speed, false, false);

		if (endPos < startPos && NPC.transform.position.x <= endPos)
		{
			done = true;
		}
		else if (endPos > startPos && NPC.transform.position.x >= endPos)
		{
			done = true;
		}
		else if (endPos == startPos)
		{
			done = true;
		}
	}
}
