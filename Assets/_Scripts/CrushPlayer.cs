using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushPlayer : MonoBehaviour
{
    private GameObject gameTimer;
    private AudioSource audio;

    private float randX, randY, randZ;

    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        gameTimer = GameObject.Find("GameTimer");
        StartCoroutine(selfDestruct());

        randX = Mathf.Round(Random.Range(-100.0f, 100.0f));
        randY = Mathf.Round(Random.Range(-100.0f, 100.0f));
        randZ = Mathf.Round(Random.Range(-100.0f, 100.0f));
    }

    void Update()
    {
        this.transform.Rotate(randX * Time.deltaTime, randY * Time.deltaTime, randZ * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameControl.control.resultTime = gameTimer.gameObject.GetComponent<GameTimer>().timer;
            GameControl.control.condition = "LOSE";
            gameTimer.gameObject.GetComponent<GameTimer>().enabled = false;
            SceneManager.LoadScene(2);
        }
        else
        {
            StartCoroutine(crash());
        }
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    IEnumerator crash()
    {
        audio.Play();
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
