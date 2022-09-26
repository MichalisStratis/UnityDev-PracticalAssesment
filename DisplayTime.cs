using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    public SaveObject saveObj;
    public TextMeshProUGUI textMeshProUGUI;

    private void Update()
    {
        saveObj.TimeOfAttempt = Time.time;
        textMeshProUGUI.text = Time.time.ToString("F0");
    }
    public void GameOver()
    {
        SaveManager.Save(saveObj);
        SceneManager.LoadScene(3);
    }
    
}
