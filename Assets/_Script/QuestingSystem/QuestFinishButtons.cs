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

    public void RestartLevel()
    {
        Restarted = true;
        QuestSystem.GetComponent<Quest>().CurrentLevel--;
        SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
        
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

    public void ResetSaveFile()
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
