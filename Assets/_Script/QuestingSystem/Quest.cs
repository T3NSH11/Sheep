using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject[] NPCs;
    public GameObject ActiveQuest;
    public int SheepLeft;
    public float TimeLeft;
    bool VariablesSet;
    
    void Start()
    {
        NPCs = GameObject.FindGameObjectsWithTag("NPC");
    }

   
    void Update()
    {
        if (VariablesSet == false)
        {
            TimeLeft = ActiveQuest.GetComponent<NPC>().timeLimit;
            SheepLeft = ActiveQuest.GetComponent<NPC>().sheepRequired;
        }

        if(SheepLeft <= 0)
        {
            ActiveQuest.GetComponent<NPC>().completed = true;
            ActiveQuest = null;
        }
    }

    void CheckActive()
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            if (NPCs[i].GetComponent<NPC>().NPCisActive)
            {
                ActiveQuest = NPCs[i];
            }
        }
    }
}
