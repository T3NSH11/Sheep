using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    public bool playerIsNear;
    public Dialogue dialogue;
    public GameObject objectWithDialogueManager;
    public GameObject player;
    public GameObject QuestSystem;

    public bool NPCisActive = false;
    public int sheepRequired;
    public float timeLimit;
    public bool completed = false;


    private void Awake()
    {
        
    }

    private void Update()
    {
        if (objectWithDialogueManager.GetComponent<DialogueSystemManager>().sentenceQueue.Count == 0 && objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue == true)
        {
            objectWithDialogueManager.GetComponent<DialogueSystemManager>().EndDialogue();
            player.GetComponent<ClickToMove>().enabled = true;

            if (!NPCisActive && QuestSystem.GetComponent<Quest>().ActiveQuest == null)
            {
                NPCisActive = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue == true && playerIsNear == true)
        {
            Debug.Log(objectWithDialogueManager.GetComponent<DialogueSystemManager>().sentenceQueue.Peek());    
            objectWithDialogueManager.GetComponent<DialogueSystemManager>().ShowNextSentence();
        }

        if (playerIsNear == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue == false && !completed)
            {
                objectWithDialogueManager.GetComponent<DialogueSystemManager>().StartDialogue(dialogue);
            }
        }

        if (completed)
        {
            NPCisActive = false;
        }

        if(objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue)
        {
            StopMovement();
        }

        Debug.Log(objectWithDialogueManager.GetComponent<DialogueSystemManager>().sentenceQueue.Count);
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsNear = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue = false;
        if (other.tag == "Player")
        {
            objectWithDialogueManager.GetComponent<DialogueSystemManager>().EndDialogue();
            playerIsNear = false;
        }
    }

    void StopMovement()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.LookAt(transform.position);
    }
}
