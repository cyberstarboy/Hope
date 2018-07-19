using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteractions : MonoBehaviour {
    [SerializeField] Text scoreText = null;
    [SerializeField] Text timeText = null;
    [SerializeField] Text objectsRemainText = null;
    [SerializeField] Text endGameText = null;
    [SerializeField] GameObject cameraCanvas = null;
    [SerializeField] GameObject activationText = null;
    [SerializeField] DialogueManager currentDM = null;
    [SerializeField] GameObject currentDialogue = null;
    [SerializeField] GameObject dialogue1 = null;
    [SerializeField] GameObject dialogue2 = null;
    [SerializeField] GameObject dialogue3 = null;
    [SerializeField] GameObject dialogue4 = null;
    [SerializeField] GameObject tract = null;
    [SerializeField] GameObject colorPlane = null;
    [SerializeField] GameObject triggerBox = null;
    [SerializeField] GameObject NPCObject = null;
    [SerializeField] int currentTriggerVal = 0;
    [SerializeField] int triggerVal = 0;
    [SerializeField] int scoreVal = 0;
    [SerializeField] int dialogueSeconds = 0;
    [SerializeField] int currentScore = 0;
    [SerializeField] int maxScore = 0;
    Dialogue currentDialogueObject = null;
    public int objectsRemaining = 0;
    public int timeVal = 0;
    public int timeUsed;

    // Use this for initialization
    void Start () {
        maxScore = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10;
        objectsRemaining = 10;
        Globals.InteractionsRemaining = 10;
        timeVal = 0;
        scoreText.text = "Score: " + Globals.TotalScore.ToString();
        objectsRemainText.text = "Interactions Remaining: " + Globals.InteractionsRemaining.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.Space)) &&
            (Globals.DialogueOn == 0) &&
            (currentTriggerVal == triggerVal))
        {
            // Show activation text
            Debug.Log("Deactivating SPACE BAR text");
            activationText.SetActive(false);

            Debug.Log("DialogueOn = " + Globals.DialogueOn);
            StartCoroutine(ShowDialogue());

            //if (Globals.DialogueOn == 0)
            //{
            //    Globals.DialogueOn = scoreVal;
            //    StartCoroutine(ShowDialogue());
            //}
            //else
            //{
                Debug.Log("Update: " + Globals.DialogueOn);
            //}
        }

        timeUsed = (int)(Time.time);
        timeText.text = "Seconds played:  " + timeUsed.ToString();
	}


    private IEnumerator ShowDialogue()
    {
        Debug.Log("ShowDialogue; about to Activate Interactions for: " + scoreVal);

        int shortDialogueSeconds = dialogueSeconds / 2;
        // show the NPC Intro dialogue
        currentDialogue = dialogue1;
        currentDialogue.SetActive(true);
        yield return new WaitForSecondsRealtime(shortDialogueSeconds);

        // show the Player Intro dialogue
        currentDialogue.SetActive(false);
        currentDialogue = dialogue2;
        currentDialogue.SetActive(true);
        yield return new WaitForSecondsRealtime(shortDialogueSeconds);

        // show the NPC Problem dialogue
        currentDialogue.SetActive(false);
        currentDialogue = dialogue3;
        currentDialogue.SetActive(true);
        //currentDialogueObject = dialogue3.GetComponent<Dialogue>
        //currentDM.StartDialogue(currentDialogueObject);
        yield return new WaitForSecondsRealtime(dialogueSeconds);

        // show the Player Solution dialogue
        currentDialogue.SetActive(false);
        currentDialogue = dialogue4;
        currentDialogue.SetActive(true);
        //currentDialogueObject = currentDialogue.
        //currentDM.StartDialogue(currentDialogueObject);
        yield return new WaitForSecondsRealtime(dialogueSeconds);
        currentDialogue.SetActive(false);

        // Deliver the Tract
        StartCoroutine(ActivateInteractions());
    }

    private IEnumerator ActivateInteractions()
    {
        Debug.Log("Activating Interactions for: " + scoreVal);

        tract.SetActive(true);
        yield return new WaitForSecondsRealtime(dialogueSeconds + 2);

        Debug.Log("DialogueOn = " + Globals.DialogueOn);
        Globals.DialogueOn = 0;
        currentScore = currentScore + scoreVal;
        Debug.Log("currentScore = " + currentScore);
        Globals.TotalScore = Globals.TotalScore + scoreVal;
        Debug.Log("TotalScore = " + Globals.TotalScore);

        if (Globals.TotalScore >= maxScore)
        {
            //Show score and head to church to end the game
            Debug.Log("Go back to church and end the game");
            Globals.FinishedInteractions = true;
            //Globals.TotalScore = currentScore;
            Debug.Log("TotalScore = " + Globals.TotalScore);
            Debug.Log("Finished Interactions = " + Globals.FinishedInteractions);

            //fill up the scoring UI
            objectsRemainText.text = "0";
            endGameText.text = "Mission Accomplished!!!";
        }
        else
        {
            Debug.Log("Current score = " + currentScore);
        }

        DeactivateInteractions();
    }

    private void DeactivateInteractions()
    {
        Debug.Log("Dectivating Interactions for: " + scoreVal);
        //NPCObject.SetActive(false);
        triggerBox.SetActive(false);
        tract.SetActive(false);
        colorPlane.SetActive(false);
        cameraCanvas.SetActive(false);
        activationText.SetActive(false);
        scoreText.text = "Score: " + Globals.TotalScore.ToString();
        Globals.InteractionsRemaining = Globals.InteractionsRemaining - 1;
        objectsRemaining = objectsRemaining - 1;
        objectsRemainText.text = "Interactions Remaining: " + Globals.InteractionsRemaining.ToString();

        //Since finished -- let the game interact again
        Debug.Log("DialogueOn was " + Globals.DialogueOn);
        Globals.DialogueOn = 0;
        Debug.Log("DialogueOn is now " + Globals.DialogueOn);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Debug.Log(other.gameObject.name);
        triggerVal = scoreVal;
        Debug.Log("triggerVal = " + triggerVal);

        // Show activation text
        Debug.Log("In OnTriggerEnter DialogueOn = " + Globals.DialogueOn);
        if (Globals.DialogueOn == 0)
        {
            currentTriggerVal = triggerVal;
            Debug.Log("currentTriggerVal = " + currentTriggerVal);
            Debug.Log("Activating SPACE BAR text");
            activationText.SetActive(true);
        }
        else
        {
            currentTriggerVal = Globals.DialogueOn;
            Debug.Log("currentTriggerVal = " + currentTriggerVal);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Debug.Log(other.gameObject.name);

        Debug.Log("In OnTriggerExit, DialogueOn = " + Globals.DialogueOn);
 
        triggerVal = 0;
        Debug.Log("triggerVal = " + triggerVal);
        Debug.Log("currentTriggerVal = " + currentTriggerVal);
        Debug.Log("Deactivate character and collider later");
        //    NPCObject.SetActive(false);
     //    triggerBox.SetActive(false);
       //activationText.SetActive(false);

    }

}
