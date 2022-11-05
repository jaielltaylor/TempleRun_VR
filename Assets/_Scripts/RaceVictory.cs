using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceVictory : MonoBehaviour
{
    public GameObject gametimer;
    
    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            GameControl.control.resultTime = gametimer.gameObject.GetComponent<GameTimer>().timer;
            GameControl.control.condition = "WIN";
            gametimer.gameObject.GetComponent<GameTimer>().enabled = false;
            SceneManager.LoadScene(2);
        }
    }
}
