using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public GameObject TimeObject;
    protected int PointsToAdd;
    public int NumToSpawn;
    public int requiredPoints;
    public float RedSpawnTime;
    public float MaxTime;
    public TextMeshProUGUI textMeshProUGUI;
    public DisplayTime TimeUI;
    public SaveObject saveObj;

    void Start()
    {
        TimeUI=TimeObject.GetComponent<DisplayTime>();
        if (SceneManager.GetActiveScene().buildIndex==0)
        {
            saveObj.score = 0;
            saveObj.PushedObjects = 0;
            PlayerPrefs.SetInt("Score", saveObj.score);
            PlayerPrefs.SetInt("ThrownObjects", saveObj.PushedObjects);
        }
        else
        {
            saveObj.score = PlayerPrefs.GetInt("Score");
            saveObj.PushedObjects = PlayerPrefs.GetInt("ThrownObjects");
        }

        
    }

    private void Update()
    {
        textMeshProUGUI.text = saveObj.score.ToString("F0");
        if (Time.time > MaxTime)
        {
            TimeUI.GameOver();
        }
    }

    public int GetNumToSpawn()
    {
        return NumToSpawn;
    }

    public int GetNeededScore()
    {
        return requiredPoints;
    }

    public float GetTimerCount()
    {
        return MaxTime;
    }

    public float RedSpawningTime()
    {
        return RedSpawnTime;
    }

    public int GetPoints(int layer)
    {
        int Level = SceneManager.GetActiveScene().buildIndex;
        if (Level == 0)
        {
            if (layer == 6)
            {
                PointsToAdd = 1;
            }
            else if (layer == 7)
            {
                PointsToAdd = 2;
            }
        }
        else if (Level == 1)
        {
            if (layer == 6)
            {
                PointsToAdd = 10;
            }
            else if (layer == 7)
            {
                PointsToAdd = 12;
            }
        }
        else if (Level == 2)
        {
            if (layer == 6)
            {
                PointsToAdd = 20;
            }
            else if (layer == 7)
            {
                PointsToAdd = 22;
            }
        }
        return PointsToAdd;
    }
    // Update is called once per frame
    public void AddScore( int layer )
    {
        saveObj.score += GetPoints(layer);
        PlayerPrefs.SetInt("Score", saveObj.score);
    }

    public void AddThrownObject()
    {
        saveObj.PushedObjects+=1;
        PlayerPrefs.SetInt("ThrownObjects", saveObj.PushedObjects);
    }
    public void DeductScore(int layer)
    {
        saveObj.score -= GetPoints(layer)*2;
        PlayerPrefs.SetInt("Score", saveObj.score);
    }

    public void CheckForWinner()
    {
        if (saveObj.score > GetNeededScore() && SceneManager.GetActiveScene().buildIndex < 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (saveObj.score > GetNeededScore() && SceneManager.GetActiveScene().buildIndex >= 2)
        {
            SaveManager.Save(saveObj);
            SceneManager.LoadScene(4);
        }
    }
}
