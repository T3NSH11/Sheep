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
    //public GameObject Level1Sheep;
    //public GameObject Level2Sheep;
    //public GameObject Level3Sheep;
    //public GameObject Level4Sheep;
    //public List<Transform> level1Sheep = new List<Transform>();
    //public List<Transform> level2Sheep = new List<Transform>();
    //public List<Transform> level3Sheep = new List<Transform>();
    //public List<Transform> level4Sheep = new List<Transform>();

    private void Awake()
    {
        LoadGame();
        //ResetSaveFile();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerSpawns.Add (Level1Spawn);
        //PlayerSpawns.Add (Level2Spawn);
        //PlayerSpawns.Add (Level3Spawn);
        //PlayerSpawns.Add (Level4Spawn);

        

        if(CurrentSpawn != null)
        {
            player.transform.position = CurrentSpawn.transform.position;
        }

        //foreach (Transform child in Level1Sheep.transform)
        //    level1Sheep.Add(child);
        //
        //foreach (Transform child in Level2Sheep.transform)
        //    level2Sheep.Add(child);
        //
        //foreach (Transform child in Level3Sheep.transform)
        //    level3Sheep.Add(child);

        //foreach (Transform child in Level4Sheep.transform)
            //level4Sheep.Add(child);
    }

    void Update()
    {
        if (QuestSystem.GetComponent<Quest>().CurrentLevel != 0)
        {
            CurrentSpawn = PlayerSpawns[(QuestSystem.GetComponent<Quest>().CurrentLevel) - 1];
        }
    }

    public void RestartLevel()
    {
        Restarted = true;
        QuestSystem.GetComponent<Quest>().CurrentLevel--;
        SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //QuestSystem.GetComponent<Quest>().LevelCompleteScreen.SetActive(false);
        //QuestSystem.GetComponent<Quest>().LevelFailedScreen.SetActive(false);
        //
        //if(QuestSystem.GetComponent<Quest>().CurrentLevel == 1)
        //{
        //    foreach (Transform Sheep in level1Sheep)
        //    {
        //        Sheep.transform.position = Sheep.GetComponent<SheepManager>().StartPos;
        //        Sheep.gameObject.layer = LayerMask.NameToLayer("Sheep");
        //    }
        //}
        //
        //if (QuestSystem.GetComponent<Quest>().CurrentLevel == 2)
        //{
        //    foreach (Transform Sheep in level2Sheep)
        //    {
        //        Sheep.transform.position = Sheep.GetComponent<SheepManager>().StartPos;
        //        Sheep.gameObject.layer = LayerMask.NameToLayer("Sheep");
        //    }
        //}
        //
        //if (QuestSystem.GetComponent<Quest>().CurrentLevel == 3)
        //{
        //    foreach (Transform Sheep in level3Sheep)
        //    {
        //        Sheep.transform.position = Sheep.GetComponent<SheepManager>().StartPos;
        //        Sheep.gameObject.layer = LayerMask.NameToLayer("Sheep");
        //    }
        //}
        //
        //if (QuestSystem.GetComponent<Quest>().CurrentLevel == 4)
        //{
        //    foreach (Transform Sheep in level4Sheep)
        //    {
        //        Sheep.transform.position = Sheep.GetComponent<SheepManager>().StartPos;
        //        Sheep.gameObject.layer = LayerMask.NameToLayer("Sheep");
        //    }
        //}
    }

    public void ContinueLevel()
    {
        QuestSystem.GetComponent<Quest>().LevelCompleteScreen.SetActive(false);
        player.GetComponent<PlayerBehavior>().goToLevel2 = true;
    }

    void SaveGame()
    {
        int playerLevel = QuestSystem.GetComponent<Quest>().CurrentLevel;
        bool restarted = Restarted;

        FileStream Sf = new FileStream("SaveFile.dat", FileMode.Create);
        FileStream Rs = new FileStream("Restarted.dat", FileMode.Create);

        BinaryFormatter formatter = new BinaryFormatter();
        Restarted = false;

        try
        {
            formatter.Serialize(Sf, playerLevel);
            formatter.Serialize(Rs, restarted);
        }
        catch(SerializationException e)
        {
            Debug.LogError("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            Sf.Close();
            Rs.Close();
        }
    }

    void LoadGame()
    {
        FileStream Sf = new FileStream("SaveFile.dat", FileMode.Open);
        FileStream Rs = new FileStream("Restarted.dat", FileMode.Open);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            QuestSystem.GetComponent<Quest>().CurrentLevel = (int)formatter.Deserialize(Sf);
            Restarted = (bool)formatter.Deserialize(Rs);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            Sf.Close();
            Rs.Close();
        }

        Debug.Log(QuestSystem.GetComponent<Quest>().CurrentLevel);
        Debug.Log(Restarted);
    }

    void ResetSaveFile()
    {
        int playerLevel = 0;
        bool restarted = false;

        FileStream Sf = new FileStream("SaveFile.dat", FileMode.Create);
        FileStream Rs = new FileStream("Restarted.dat", FileMode.Create);

        BinaryFormatter formatter = new BinaryFormatter();
        Restarted = false;

        try
        {
            formatter.Serialize(Sf, playerLevel);
            formatter.Serialize(Rs, restarted);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            Sf.Close();
            Rs.Close();
        }
    }
}
