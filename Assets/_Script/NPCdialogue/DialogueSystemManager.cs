using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystemManager : MonoBehaviour
{
    public Queue<string> sentences;
    
    
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
        sentences = new Queue<string>();
    }
    public void StartDialogue (Dialogue dialogue)
    {
        InDialogue = true;
        dialoguePanel.SetActive(true);
  
         nameText.text = dialogue.name;

         sentences.Clear();

            foreach (string String in dialogue.sentences)
            {
                sentences.Enqueue(String);
            }
        dialogueText.text = sentences.Peek();
        sentences.Dequeue();
        
    }
   
    public void ShowNextSentence()
  {
        string sentance = sentences.Dequeue();
        dialogueText.text = sentance;

    }

    public void EndDialogue()
    {
        InDialogue = false;
        dialoguePanel.SetActive(false);
        
    }

    
    

}
