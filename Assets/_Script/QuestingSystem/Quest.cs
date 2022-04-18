using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject[] NPCs;
    public GameObject ActiveQuest;
    public GameObject LevelCompleteScreen;
    public GameObject LevelFailedScreen;
    public GameObject SheepLeftText;
    public GameObject TimeLeftText;
    public int SheepLeft;
    public float TimeLeft = 100;
    bool VariablesSet = false;
    
    void Start()
    {
        NPCs = GameObject.FindGameObjectsWithTag("NPC");
        TimeLeftText.SetActive(false);
        SheepLeftText.SetActive(false);
    }

   
    void Update()
    {
        CheckActive();
        if (ActiveQuest != null)
        {
            TimeLeftText.SetActive(true);
            SheepLeftText.SetActive(true);
            TimeLeftText.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = TimeLeft.ToString("0.0");
            SheepLeftText.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = SheepLeft.ToString();
            if (ActiveQuest.GetComponent<NPC>().completed == false)
            {
                TimeLeft -= Time.deltaTime;
            }
        }

        if (VariablesSet == false && ActiveQuest != null)
        {
            TimeLeft = ActiveQuest.GetComponent<NPC>().timeLimit;
            SheepLeft = ActiveQuest.GetComponent<NPC>().sheepRequired;
            VariablesSet = true;
        }

        if(SheepLeft <= 0 && ActiveQuest != null)
        {
            ActiveQuest.GetComponent<NPC>().completed = true;
            ActiveQuest = null;
            LevelCompleteScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (TimeLeft <= 0)
        {
            LevelFailedScreen.SetActive(true);
            Time.timeScale = 0;
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
