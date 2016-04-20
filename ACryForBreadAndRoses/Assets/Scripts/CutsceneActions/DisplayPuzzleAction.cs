using UnityEngine;
using System.Collections;

public class DisplayPuzzleAction : CutsceneAction
{

	public string PuzzleName;

	private PuzzleBase puzzleMgr;

	protected override void ActionStart()
	{
		puzzleMgr = GameObject.Find("UICanvas").GetComponent<UIManager>().Puzzle;

		puzzleMgr.LoadPuzzle(PuzzleName);
	}

	protected override void ActionUpdate()
	{
		if (puzzleMgr.IsPuzzleFinished())
		{
			done = true;
		}
	}
}
