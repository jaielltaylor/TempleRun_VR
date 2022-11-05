using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fell : MonoBehaviour
{
    public GameObject gameTimer;
    public float waitTime = 5.0f;

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            StartCoroutine(fail());
            gameTimer.gameObject.GetComponent<GameTimer>().enabled = false;
        }
    }

    IEnumerator fail()
    {
        yield return new WaitForSeconds(3);
        GameControl.control.resultTime = gameTimer.gameObject.GetComponent<GameTimer>().timer;
        GameControl.control.condition = "LOSE";
        SceneManager.LoadScene(2);
    }
}
