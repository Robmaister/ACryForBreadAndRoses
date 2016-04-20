using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public DialogManager Dialog;
	public PuzzleBase Puzzle;

	private Transform puzzleBase;

	// Use this for initialization
	void Start () {
		Dialog = transform.Find("DialogBase").GetComponent<DialogManager>();
		puzzleBase = transform.Find("PuzzleBase");
		Puzzle = puzzleBase.GetComponent<PuzzleBase>();
	}
}
