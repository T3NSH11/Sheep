using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPen : MonoBehaviour
{
    public LayerMask Inpen;
    public GameObject QuestSystem;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sheep")
        {
            other.gameObject.layer = LayerMask.NameToLayer("InPen"); 
            QuestSystem.GetComponent<Quest>().SheepLeft--;
        }
    }
}
