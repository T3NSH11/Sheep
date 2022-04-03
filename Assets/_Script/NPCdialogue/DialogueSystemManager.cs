using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystemManager : MonoBehaviour
{
    private Queue<string> sentences;
    
    [SerializeField]
    public TextMeshProUGUI nameText;

    [SerializeField]
    public TextMeshProUGUI dialogueText;

    //[SerializeField]
   // public Animator dialogueanimator;

    [SerializeField] private GameObject dialoguePanel;

    private float nextCharTimer;



    void Start()
    {
        dialoguePanel.SetActive(false);
        sentences = new Queue<string>();
    }
    public void StartDialogue (Dialogue dialogue)
    {
        dialoguePanel.SetActive(true);
        //dialogueanimator.SetBool("IsOpen", true);

         nameText.text = dialogue.name;

         sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }


       

    }
   
    public void ShowNextSentence()
  {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
            
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;


      //  StopAllCoroutines();
      //  StartCoroutine(SentenceTypingAnimation(sentence));
      //
      // 
      //
      //  IEnumerator SentenceTypingAnimation (string sentence)
      //  {
      //
      //      dialogueText.text = "";
      //      foreach (char letter in sentence.ToCharArray())
      //      {
      //          dialogueText.text += letter;
      //         
      //      } 
      //
      //       yield return null;
      //  }

    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        //dialogueanimator.SetBool("IsOpen", false);
    }

    
    

}
