using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class QuestFinishButtons : MonoBehaviour
{
    GameObject player;
    List<GameObject> PlayerSpawns = new List<GameObject>();
    public GameObject Level1Spawn;
    public GameObject Level2Spawn;
    public GameObject Level3Spawn;
    public GameObject Level4Spawn;
    GameObject CurrentSpawn;
    bool Restarted = false;
    public GameObject QuestSystem;
   
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerSpawns.Add (Level1Spawn);
       

        

        if(CurrentSpawn != null)
        {
            player.transform.position = CurrentSpawn.transform.position;
        }

       
    }

    void Update()
    {
        if (QuestSystem.GetComponent<Quest>().CurrentLevel != 0)
        {
            CurrentSpawn = PlayerSpawns[(QuestSystem.GetComponent<Quest>().CurrentLevel) - 1];
        }
    }

    
}
