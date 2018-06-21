using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractions : MonoBehaviour {
    [SerializeField] GameObject cameraCanvas = null;
    [SerializeField] GameObject dialogue = null;
    [SerializeField] GameObject tract = null;
    [SerializeField] GameObject colorPlane = null;
    [SerializeField] int scoreVal = 0;
    [SerializeField] int dialogueSeconds = 0;
    public int currentScore = 0;
    public int maxScore = 0;
    public int triggerVal;

    // Use this for initialization
    void Start () {
        maxScore = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.Space)) && 
            (triggerVal == scoreVal))
        {
            StartCoroutine(ShowDialogue());
        }
	}

    private IEnumerator ShowDialogue()
    {
        Debug.Log("ShowDialogue; about to Activate Interactions for: ");
        Debug.Log(scoreVal);
        dialogue.SetActive(true);
        yield return new WaitForSecondsRealtime(dialogueSeconds);
        dialogue.SetActive(false);
        StartCoroutine(ActivateInteractions());
    }

    private IEnumerator ActivateInteractions()
    {
        Debug.Log("Activating Interactions for: ");
        Debug.Log(scoreVal);
        tract.SetActive(true);
        yield return new WaitForSecondsRealtime(dialogueSeconds);
        currentScore = currentScore + scoreVal;
        if (currentScore >= maxScore)
        {
            //Show score and head to church to end the game
            Debug.Log("Go back to church and end the game");
        }
        else
        {
            Debug.Log(currentScore);
        }

        DeactivateInteractions();
    }

    private void DeactivateInteractions()
    {
        Debug.Log("Dectivating Interactions for: ");
        Debug.Log(scoreVal);
        dialogue.SetActive(false);
        tract.SetActive(false);
        colorPlane.SetActive(false);
        cameraCanvas.SetActive(false);
    }
}
