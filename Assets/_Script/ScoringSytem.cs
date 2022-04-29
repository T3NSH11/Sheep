using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


public class ScoringSytem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject currentText;
    public GameObject QuestSystem;

    public float currentScore;
    public Quest currentQuest;
    public float scoreMultiplier = 5f;
    public float highScore;

    public GameObject levelCompleteScreen;

    public bool saveExists;
   

    private void Awake()
    {
        if(File.Exists("highscores.dat"))
        {
            LoadScores();
        }
    }


    private void Start()
    {
        currentQuest = QuestSystem.GetComponent<Quest>();
    }


    void Update()
    {
        if (gameObject.GetComponent<Quest>().totalScore > highScore)
        {
            highScore = GetComponent<Quest>().totalScore;
        }

        if (currentQuest.ActiveQuest != null)
        {
            currentScore = currentQuest.TimeLeft * scoreMultiplier;
        }
        else
        {
            currentScore = 0;
        }

        //currentText.GetComponent<TMPro.TextMeshPro>().text = currentScore.ToString();
        //currentText.GetComponent<TMPro.TextMeshProUGUI>().text = currentScore.ToString();
        currentText.GetComponent<TMPro.TextMeshProUGUI>().text = currentScore.ToString();

    }

    public void saveHighScores()
    {
      
            float HighScore = highScore;
        FileStream highscores = new FileStream("highscores.dat", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            formatter.Serialize(highscores, HighScore);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            highscores.Close();
        }

    }

    public void LoadScores()
    {
        
        FileStream highscores = new FileStream("highscores.dat", FileMode.Open);
        

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            highScore = (float)formatter.Deserialize(highscores);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            highscores.Close();
        }

        Debug.Log(highScore);

    }
}
