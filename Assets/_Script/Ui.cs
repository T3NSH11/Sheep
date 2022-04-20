using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
public class Ui : MonoBehaviour
{

    public GameObject PauseScreen;
    public GameObject QuestSystem;
    GameObject player;
    bool Restarted = false;


    public void Awake()
    {
        ResetSaveFile();
    }
    public void StartGame()
    {
        ResetSaveFile();
        SceneManager.LoadScene("Main Scene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ContinueButton()
    {
        LoadGame();
        SceneManager.LoadScene("Main Scene");
    }

   

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ReturntoGame()
    {
        PauseScreen.SetActive(false);
    }
    public void RestartLevel()
    {
        Restarted = true;
        QuestSystem.GetComponent<Quest>().CurrentLevel--;
        SaveGame();
        SceneManager.LoadScene("Main Scene");

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

