using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    private Image fadeImage;
    private bool startFading, doneFading;

    void Update()
    {
        if (startFading)
        {
            Color c = fadeImage.color;
            c.a += 0.01f;
            fadeImage.color = c;

            if (c.a >= 1.0f)
            {
                SceneManager.LoadSceneAsync(1);
            }
        }
    }

    public void StartButton()
    {
        startFading = true;

        if (fadeImage == null)
        {
            GameObject obj = new GameObject("fadeImage");
            obj = Instantiate(obj) as GameObject;
            fadeImage = obj.AddComponent<Image>();
            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(5000, 5000);
            obj.transform.SetParent(GameObject.Find("Canvas").transform);
            //fadeImage = GameObject.Find("Canvas")AddComponent<Image>();
        }

        fadeImage.color = Color.clear;
    }

    public void ExitButton()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
