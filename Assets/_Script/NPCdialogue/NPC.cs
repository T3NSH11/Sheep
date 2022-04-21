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
    public GameObject QuestInfo;
    public GameObject Sheep1;
    public GameObject Sheep2;
    public GameObject Sheep3;
    public GameObject Sheep4;

    public bool NPCisActive = false;
    public bool Talkedto = false;
    public int sheepRequired;
    public float timeLimit;
    public bool completed = false;
    public int LevelNum;
    public PathMaker pathMaker;


    private void Update()
    {
        if (objectWithDialogueManager.GetComponent<DialogueSystemManager>().sentenceQueue.Count == 0 && objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue == true && Talkedto == true)
        {
            objectWithDialogueManager.GetComponent<DialogueSystemManager>().EndDialogue();
            Time.timeScale = 1;

            if (!NPCisActive && QuestSystem.GetComponent<Quest>().ActiveQuest == null && sheepRequired != 0 && timeLimit != 0)
            {
                NPCisActive = true;
                QuestInfo.SetActive(true);

                if(LevelNum == 1)
                {
                    Sheep1.SetActive(true);
                }

                if (LevelNum == 2)
                {
                    Sheep2.SetActive(true);
                }

                if (LevelNum == 3)
                {
                    Sheep3.SetActive(true);
                }

                if (LevelNum == 4)
                {
                    Sheep4.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue == true && playerIsNear == true)
        {
            Debug.Log(objectWithDialogueManager.GetComponent<DialogueSystemManager>().sentenceQueue.Peek());    
            objectWithDialogueManager.GetComponent<DialogueSystemManager>().ShowNextSentence();
        }

        if (playerIsNear == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue == false && !completed && QuestSystem.GetComponent<Quest>().CurrentLevel + 1 == LevelNum || !completed && Talkedto == false && Input.GetKeyDown(KeyCode.E) && objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue == false)
            {
                objectWithDialogueManager.GetComponent<DialogueSystemManager>().StartDialogue(dialogue);
                Talkedto = true;
                Time.timeScale = 0;
            }
        }

        if (completed)
        {
            NPCisActive = false;
            QuestInfo.SetActive(false);
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
        
        if (other.tag == "Player")
        {
            objectWithDialogueManager.GetComponent<DialogueSystemManager>().EndDialogue();
            playerIsNear = false;
            objectWithDialogueManager.GetComponent<DialogueSystemManager>().InDialogue = false;
        }
    }

    void StopMovement()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.LookAt(transform.position);
    }
}
