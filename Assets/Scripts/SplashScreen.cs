using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SplashScreen : MonoBehaviour
{
    public AudioClip audio1;
    AudioSource audioSource;

    public Image splashImage;
    public string loadLevel;

    IEnumerator Start()
    {
        audioSource = GetComponent<AudioSource>();
        Globals.IsEndGame = true;
        splashImage.canvasRenderer.SetAlpha(0.0f);
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene(loadLevel);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(audio1, 0.7F);
            SceneManager.LoadScene(loadLevel);
        }
    }
}