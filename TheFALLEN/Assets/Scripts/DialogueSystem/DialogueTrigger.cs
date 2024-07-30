using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public GameObject dialogueOpener;

    [SerializeField] 
    public DialogueManager dialogueManager;
    //public PlayerController playerController;

    public void StartDialogue()
    {
        if(dialogueManager.triggerChecker == dialogueManager.checkpointValue)
        {
            dialogueOpener.SetActive(true);
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
            Debug.Log("debugging" + dialogueManager.checkpointValue);
        }

    }
    [System.Serializable]
    public class Message
    {
        public int actorId;
        public string message;
    }

    [System.Serializable]
    public class Actor
    {
        public string name;
        public Sprite sprite;
    }
}
