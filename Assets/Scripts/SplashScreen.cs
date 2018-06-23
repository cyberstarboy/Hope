using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    public Image splashImage;
    public string loadLevel;

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene(loadLevel);
    }
}