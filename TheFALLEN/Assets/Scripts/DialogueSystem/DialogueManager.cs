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

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        gameObject.SetActive(true);
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;
        Debug.Log("Started conversation! Loaded messages: : " + messages.Length);
        
        displayMessage();
    }

    void displayMessage()
    {
        
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
            enablePlayer.SetActive(false);
            displayMessage();
        }
        else
        {
            Debug.Log("Conversation ended");
            isActive = false;
            //gameObject.SetActive(false);
            enablePlayer.SetActive(true);
            dialogueOpener.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
