using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EndGame : MonoBehaviour {
    
    public AudioClip music;

    void Start()
    {
        if (Globals.IsEndGame == true)
        {
            AudioSource audio1 = GetComponent<AudioSource>();
            audio1.clip = music;
            audio1.Play();
        }
	}
}
