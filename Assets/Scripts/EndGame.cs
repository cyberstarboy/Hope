using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EndGame : MonoBehaviour {
    
    public AudioClip music;
    public Transform playerBody;

    void Start()
    {
        Vector3 tempPos;
        GameObject playerObj;

        if (Globals.IsEndGame == true)
        {
            AudioSource audio1 = GetComponent<AudioSource>();
            audio1.clip = music;
            audio1.Play();

            //Show people sittig down

            GameObject.Find("Andromeda@sitting").SetActive(true);
            GameObject.Find("jasper@sitting").SetActive(true);
            GameObject.Find("liam@sitting").SetActive(true);
            GameObject.Find("malcolm@sitting").SetActive(true);
            GameObject.Find("pearl@sitting").SetActive(true);
            GameObject.Find("regina@sitting").SetActive(true);
            GameObject.Find("remy@sitting").SetActive(true);
            GameObject.Find("shae@sitting").SetActive(true);
            GameObject.Find("stefani@sitting").SetActive(true);
            GameObject.Find("theboss@sitting").SetActive(true);

            //Remove clickable objects

            GameObject.Find("book").SetActive(false);
            GameObject.Find("Tract0").SetActive(false);
            GameObject.Find("Tract1").SetActive(false);
            GameObject.Find("Tract2").SetActive(false);
            GameObject.Find("Tract3").SetActive(false);
            GameObject.Find("Tract4").SetActive(false);
            GameObject.Find("Tract5").SetActive(false);
            GameObject.Find("Tract6").SetActive(false);
            GameObject.Find("Tract7").SetActive(false);
            GameObject.Find("Tract8").SetActive(false);
            GameObject.Find("Tract9").SetActive(false);

            //Move player to door

            playerObj = GameObject.FindGameObjectWithTag("Player");
            tempPos = transform.position;
            tempPos.z += 14f;
            playerObj.transform.position = tempPos;
            Vector3 targetRotBody = playerBody.rotation.eulerAngles;
            targetRotBody.y += 180;
            playerBody.rotation = Quaternion.Euler(targetRotBody);
        }
        else
        {
            //Remove people sitting in chairs

            GameObject.Find("Andromeda@sitting").SetActive(false);
            GameObject.Find("jasper@sitting").SetActive(false);
            GameObject.Find("liam@sitting").SetActive(false);
            GameObject.Find("malcolm@sitting").SetActive(false);
            GameObject.Find("pearl@sitting").SetActive(false);
            GameObject.Find("regina@sitting").SetActive(false);
            GameObject.Find("remy@sitting").SetActive(false);
            GameObject.Find("shae@sitting").SetActive(false);
            GameObject.Find("stefani@sitting").SetActive(false);
            GameObject.Find("theboss@sitting").SetActive(false);
        }
    }
}