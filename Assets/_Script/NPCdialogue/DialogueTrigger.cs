using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    [Header("Visual Cue")] 
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerIsNear;


    private void Awake()
    {
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerIsNear && !DialogueManager.GetInstance().dialoguePlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);

            }
        }

        else
        {
            visualCue.SetActive(false);

        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerDog")
        {

            playerIsNear = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerDog")
        {

            playerIsNear = false;

        }
    }

}
