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
            QuestSystem.GetComponent<Quest>().SheepLeft = QuestSystem.GetComponent<Quest>().SheepLeft - 1;
            other.gameObject.layer = LayerMask.NameToLayer("InPen"); 
        }
    }
}
