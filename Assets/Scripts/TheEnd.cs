using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TheEnd : MonoBehaviour {

    public AudioClip clapping;
    public AudioClip click;
    public CanvasGroup uiElement;

    [HideInInspector]
    public Shader shader1;
    [HideInInspector]
    public Shader shader2;
    [HideInInspector]
    public Renderer rend;

    void Start()
    {
        if (Globals.IsEndGame == true)
        {
            rend = GetComponent<Renderer>();
            shader1 = Shader.Find("Standard");
            shader2 = Shader.Find("Legacy Shaders/VertexLit");
        }
    }

    void OnMouseDown()
    {
        if (Globals.IsEndGame == true)
        {
            AudioSource audio1 = GetComponent<AudioSource>();
            audio1.PlayOneShot(clapping, 0.7F);
            AudioSource audio2 = GetComponent<AudioSource>();
            audio2.PlayOneShot(click, 0.7F);

            FadeOut();

            StartCoroutine(CloseGame());
        }
    }

    IEnumerator CloseGame()
    {
        if (Globals.IsEndGame == true)
        {
            yield return new WaitForSeconds(12.0f);
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    void OnMouseOver()
    {
        if (Globals.IsEndGame == true)
        {
            rend.material.shader = shader2;
        }
    }

    void OnMouseExit()
    {
        if (Globals.IsEndGame == true)
        {
            rend.material.shader = shader1;
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, 5f));
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, .5f));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }
    }
}