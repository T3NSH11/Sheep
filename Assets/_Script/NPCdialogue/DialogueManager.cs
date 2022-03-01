using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;

    private static DialogueManager instance;

    public bool dialoguePlaying { get; private set; } //makes it so only the other scripts can fetch values

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one dlg mng in scene"); //should not be more than one in a scene since its a singleton
        }
        instance = this;

    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }



    private void Start()
    {
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        //reutnrs if there is no dialogue playing
        if (!dialoguePlaying)
        {

            return;
        }
        //continues next line of dialogue
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ContinueStory();
        }


    }

    public void EnterDialogueMode (TextAsset InkJSON)
    {
        currentStory = new Story(InkJSON.text); //initializes the json file 
        dialoguePlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();

       
    }

    private void ExitDialogueMode()
    {

        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {

        if (currentStory.canContinue) // checks if theres more lines to progress
        {

            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();

        }

    }

}
