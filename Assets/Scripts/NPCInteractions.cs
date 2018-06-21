using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractions : MonoBehaviour {
    [SerializeField] GameObject dialogue = null;
    [SerializeField] GameObject tracts = null;
    [SerializeField] GameObject colorPlane = null;
    [SerializeField] int dialogueSeconds = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        dialogue.SetActive(true);
        tracts.SetActive(true);
        colorPlane.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        dialogue.SetActive(false);
        tracts.SetActive(false);
        colorPlane.SetActive(false);
    }
}
