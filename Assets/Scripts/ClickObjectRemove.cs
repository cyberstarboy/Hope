using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class ClickObjectRemove : MonoBehaviour {

    static public int TriggerCnt1 = 0;

    public AudioClip impact;
    public AudioClip open;
    AudioSource audioSource;

    public string scene;

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
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("Legacy Shaders/VertexLit");
    }

    void OnMouseDown()
    {
        if (gameObject.name == "DoorTrigger")
        {
            if (TriggerCnt1 == 11)
            {
                audioSource.PlayOneShot(open, 0.7F);
            }
        }
        else
        {
            audioSource.PlayOneShot(impact, 0.7F);
        }
    }

    void OnMouseUpAsButton()
    {
        if (gameObject.name == "DoorTrigger")
        {
            if (TriggerCnt1 == 11)
            {
                Globals.IsEndGame = true;
                SceneManager.LoadScene(scene);
            }
        }
        else
        {
            TriggerCnt1++;
            Destroy(gameObject);
        }
    }

    void OnMouseOver()
    {
        if (gameObject.name == "DoorTrigger")
        {
            if (TriggerCnt1 == 11)
            {
                rend.material.shader = shader2;
            }
        }
        else
        {
            rend.material.shader = shader2;
        }
    }

    void OnMouseExit()
    {
        rend.material.shader = shader1;
    }

}