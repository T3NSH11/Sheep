using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorialtext : MonoBehaviour
{
    public GameObject guideText;
    
    void Start()
    {
        guideText.SetActive(false);

       
        
    }
       
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            guideText.SetActive(true);
        }
    }
}
