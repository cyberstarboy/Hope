using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class EnterChurch : MonoBehaviour {

    public AudioClip click;
    AudioSource audioSource;

    public string scene;

    [HideInInspector]
    public Shader shader1;
    [HideInInspector]
    public Shader shader2;
    [HideInInspector]
    public Renderer rend;

	void Start () 
    {
        audioSource = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("Legacy Shaders/VertexLit");
	}

    void OnMouseDown()
    {
        if (Globals.FinishedInteractions == true)
        {
            audioSource.PlayOneShot(click, 0.7F);
        }
    }

    void OnMouseUpAsButton()
    {
        if (Globals.FinishedInteractions == true)
        {
            Globals.IsEndGame = true;
            SceneManager.LoadScene(scene);
        }
    }

    void OnMouseOver()
    {
        if (Globals.FinishedInteractions == true)
        {
            rend.material.shader = shader2;
        }
    }

    void OnMouseExit()
    {
        if (Globals.FinishedInteractions == true)
        {
            rend.material.shader = shader1;
        }
    }
}