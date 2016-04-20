using UnityEngine;
using System.Collections;

using UnityStandardAssets._2D;

public class JumpNPCAction : CutsceneAction
{
	public PlatformerCharacter2D NPC;

	protected override void ActionStart()
	{
		NPC.Move(0, false, true);
	}

	protected override void ActionUpdate()
	{
		if (NPC.IsGrounded)
		{
			done = true;
		}
	}
}
