using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClickObjectRemove : MonoBehaviour {

    public AudioClip impact;
    AudioSource audioSource;

    [HideInInspector]
    public Shader shader1;
    [HideInInspector]
    public Shader shader2;
    [HideInInspector]
    public Renderer rend;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Diffuse");
        shader2 = Shader.Find("Transparent/Diffuse");
    }

    void OnMouseDown()
    {
        audioSource.PlayOneShot(impact, 0.7F);
    }

    void OnMouseUpAsButton()
    {
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        rend.material.shader = shader2;
    }

    void OnMouseExit()
    {
        rend.material.shader = shader1;
    }

}