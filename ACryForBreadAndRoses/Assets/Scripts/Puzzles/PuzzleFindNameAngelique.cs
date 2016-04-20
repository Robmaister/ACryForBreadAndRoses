using UnityEngine;
using System.Collections;

public class PuzzleFindNameAngelique : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnAngeliqueButtonPress()
	{
		GetComponentInParent<PuzzleBase>().FinishPuzzle();
	}
}
