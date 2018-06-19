using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClickObjectRemove : MonoBehaviour {

    static public int TriggerCnt1 = 00;

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
          if (TriggerCnt1 == 11)
          {
            Debug.Log("Exit Church");
          }
        TriggerCnt1++;
        Debug.Log(TriggerCnt1);

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