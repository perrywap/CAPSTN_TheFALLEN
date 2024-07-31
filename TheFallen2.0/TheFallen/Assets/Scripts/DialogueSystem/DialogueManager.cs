using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogueTrigger;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public GameObject dialogueOpener;
    public GameObject enablePlayer;

    public int triggerChecker = 0; //It is the checkpoint whose value changes manually on each inspector(ex: first cutscene it has a value of 0, 2nd cutscene it has a value of 1, 3rd cutscene it has a value of 2 and so on and so forth)
    //public int secondtriggerChecker = 0;
    public int checkpointValue = 0; //checks to see which checkpoint I can access
    public int convoChecker = 0; //check if the convo is happening or not ; this so that I can disable movement when 

    //public PlayerController pController;

    DialogueManager useless;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        convoChecker = 1;
        
        //pController.CPValue = 1;

        //if (checkpointValue == triggerChecker)
        //{
        //    gameObject.SetActive(true);
        //    currentMessages = messages;
        //    currentActors = actors;
        //    activeMessage = 0;

        //    isActive = true;
        //    Debug.Log("Started conversation! Loaded messages: : " + messages.Length);

        //    Debug.Log("checker: " + triggerChecker);
        //    displayMessage();
        //}


        //if(triggerChecker == 1 && secondtriggerChecker == 1)
        //{
        //    dialogueOpener.SetActive(false);
        //}

        gameObject.SetActive(true);
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;
        Debug.Log("Started conversation! Loaded messages: : " + messages.Length);

        Debug.Log("checker: " + triggerChecker);
        displayMessage();
    }

    void displayMessage()
    {
        //triggerChecker = 1;
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        //enablePlayer.SetActive(false);
    }

    public void nextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            //enablePlayer.SetActive(false);
            displayMessage();
        }
        else
        {
            Debug.Log("Conversation ended");
            isActive = false;
            //gameObject.SetActive(false);
            enablePlayer.SetActive(true);
            dialogueOpener.SetActive(false);

            //triggerChecker = 1;
            Debug.Log("trigger checker: " + triggerChecker);
            //secondtriggerChecker = 1;
            checkpointValue++;
            Debug.Log("checkpoint value: " + checkpointValue);

            if (checkpointValue >= 1)
            {
                useless.enabled = true;
            }
            else if (checkpointValue == 0)
            {
                useless.enabled = false;
            }
            

            //pController.CPValue = 0;
            //Debug.Log("CPValue: " + pController.CPValue);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        useless = gameObject.GetComponent<DialogueManager>();

        //gameObject.SetActive(false);
        dialogueOpener.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && isActive == true)
        {
            nextMessage();  
        }
    }
}
