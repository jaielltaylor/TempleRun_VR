using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timer = 0.0f;
    public float waitTime;
    public Text timerText;
    private float scoreDown = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        scoreDown += Time.deltaTime;
        if (scoreDown == 20.0f)
        {
            GameControl.control.scoreMultiplier -= 75;
            GameControl.control.scoreDump += 200;
            scoreDown = 0.0f;
        }
        timerText.text = ((int)timer).ToString() + "s";
        if (timer >= waitTime)
        {
            GameControl.control.resultTime = this.gameObject.GetComponent<GameTimer>().timer;
            GameControl.control.condition = "LOSE";
            this.gameObject.GetComponent<GameTimer>().enabled = false;
            SceneManager.LoadScene(2);
        }
        
    }
}
