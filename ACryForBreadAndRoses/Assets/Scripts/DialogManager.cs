using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	private Text DialogPanel;
	private Text LeftNameTag;
	private Text RightNameTag;

	// Use this for initialization
	void Start () {
		DialogPanel = transform.Find("DialogPanel/Text").GetComponent<Text>();
		LeftNameTag = transform.Find("LeftNameTag/Text").GetComponent<Text>();
		RightNameTag = transform.Find("RightNameTag/Text").GetComponent<Text>();

		HideDialog();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DisplayDialog(string dialog, string leftName, string rightName)
	{
		DialogPanel.rectTransform.parent.gameObject.SetActive(true);
		DialogPanel.text = dialog;

		if (!string.IsNullOrEmpty(leftName))
		{
			LeftNameTag.rectTransform.parent.gameObject.SetActive(true);
			LeftNameTag.text = leftName;
		}

		if (!string.IsNullOrEmpty(rightName))
		{
			RightNameTag.rectTransform.parent.gameObject.SetActive(true);
			RightNameTag.text = rightName;
		}
	}

	public void HideDialog()
	{
		DialogPanel.rectTransform.parent.gameObject.SetActive(false);
		LeftNameTag.rectTransform.parent.gameObject.SetActive(false);
		RightNameTag.rectTransform.parent.gameObject.SetActive(false);
	}
}
