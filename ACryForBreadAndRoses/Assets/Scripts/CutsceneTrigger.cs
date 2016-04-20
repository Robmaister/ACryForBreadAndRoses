using UnityEngine;
using System.Collections;

public class CutsceneTrigger : MonoBehaviour {

	public Cutscene cutscene;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			cutscene.gameObject.SetActive(true);
		}
	}
}
