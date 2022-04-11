using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject[] NPCs;
    
    void Start()
    {
        NPCs = GameObject.FindGameObjectsWithTag("NPC");
    }

   
    void Update()
    {
       for (int i = 0, i < NPCs.Length i++)
        {

        }
    }
}
