using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayQuit : MonoBehaviour
{
    public void StartRun()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitRun()
    {
        Application.Quit();
    }
}
