using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystemManager : MonoBehaviour
{
    public Queue<string> sentenceQueue;
    
    
    [SerializeField]
    public TextMeshProUGUI nameText;

    [SerializeField]
    public TextMeshProUGUI dialogueText;

    [SerializeField] private GameObject dialoguePanel;

    private float nextCharTimer;
    public bool InDialogue;



    void Start()
    {
        dialoguePanel.SetActive(false);
        sentenceQueue = new Queue<string>();
    }

    private void Update()
    {
        if (InDialogue)
            dialogueText.text = sentenceQueue.Peek();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        InDialogue = true;
        dialoguePanel.SetActive(true);
  
         nameText.text = dialogue.name;

         //sentences.Clear();

            foreach (string String in dialogue.sentences)
            {
                sentenceQueue.Enqueue(String);
            }

        //sentenceQueue.Dequeue();
        
    }
   
    public void ShowNextSentence()
    {
        sentenceQueue.Dequeue();
        //dialogueText.text = sentance;

    }

    public void EndDialogue()
    {
        InDialogue = false;
        dialoguePanel.SetActive(false);
        sentenceQueue.Clear();
    }

    
    

}
