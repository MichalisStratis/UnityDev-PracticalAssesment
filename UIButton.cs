using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    // Update is called once per frame
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
