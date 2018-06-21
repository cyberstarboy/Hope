using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScripts : MonoBehaviour {
    public int triggerVal = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (triggerVal > 0)
        {

        }
	}

     private void OnTriggerEnter(Collider other)
     {
        Debug.Log("OnTriggerEnter");
        Debug.Log(other.gameObject.name);
        triggerVal = 6;
        Debug.Log("trigger Val = ");
        Debug.Log(triggerVal);
     }

     private void OnTriggerExit(Collider other)
     {
        Debug.Log("OnTriggerEnter");
        Debug.Log(other.gameObject.name);
        triggerVal = 0;
        Debug.Log("trigger Val = ");
        Debug.Log(triggerVal);
    }
 
}
