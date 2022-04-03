using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDialogue : MonoBehaviour
{
    public bool playerIsNear;
    public Dialogue dialogue;
    public GameObject objectWithDialogueManager;

    private void Update()
    {
       

        if (playerIsNear == true)
        {

           objectWithDialogueManager.GetComponent<DialogueSystemManager>().StartDialogue(dialogue);
            Debug.Log("trigger dialogue line");

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            objectWithDialogueManager.GetComponent<DialogueSystemManager>().ShowNextSentence();
        }

    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerDog")
        {
            playerIsNear = true;
            Debug.Log("playerisnear true enabled");
        }

        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerDog")
        {
            objectWithDialogueManager.GetComponent<DialogueSystemManager>().EndDialogue();
            playerIsNear = false;
            Debug.Log("playerisnear true disabled");
        }
    }
}
