using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    public GameObject[] NPCs;
    public GameObject ActiveQuest;
    public GameObject LevelCompleteScreen;
    public GameObject LevelFailedScreen;
    public GameObject SheepLeftText;
    public GameObject TimeLeftText;
    public int CurrentLevel;
    public int SheepLeft;
    public float TimeLeft = 100;
    public float totalScore;
    bool VariablesSet = false;
    bool UIOpen;
    
    void Start()
    {
        NPCs = GameObject.FindGameObjectsWithTag("NPC");
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
            totalScore += gameObject.GetComponent<ScoringSytem>().currentScore;
            gameObject.GetComponent<ScoringSytem>().saveHighScores();
            ActiveQuest.GetComponent<NPC>().completed = true;
            ActiveQuest = null;
            LevelCompleteScreen.SetActive(true);
            CurrentLevel++;
            gameObject.GetComponent<NPC>().LevelNum++;
            Debug.Log(gameObject.GetComponent<NPC>().LevelNum++);
            Time.timeScale = 0;
            SheepLeft = 1000;
        }

        if (TimeLeft <= 0)
        {
            LevelFailedScreen.SetActive(true);
        }

        if(LevelCompleteScreen.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void CheckActive()
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            if (NPCs[i].GetComponent<NPC>().NPCisActive)
            {
                ActiveQuest = NPCs[i];
                //update check
            }
        }
    }
}
