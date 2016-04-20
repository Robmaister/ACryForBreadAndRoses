using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PuzzleBase : MonoBehaviour
{
	private bool done;
	private GameObject currentPuzzle;

	public void FinishPuzzle()
	{
		GetComponent<Image>().enabled = false;
		done = true;
		Destroy(currentPuzzle);
	}

	public bool IsPuzzleFinished()
	{
		return done;
	}

	public void LoadPuzzle(string prefab)
	{
		GetComponent<Image>().enabled = true;

		done = false;
		currentPuzzle = Instantiate(Resources.Load<GameObject>(prefab));
		currentPuzzle.transform.SetParent(this.transform);
		RectTransform trans = currentPuzzle.GetComponent<RectTransform>();
		trans.offsetMax = Vector2.zero;
		trans.offsetMin = Vector2.zero;
	}
}
