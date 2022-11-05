using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Executioner : MonoBehaviour
{
    public Transform Player;
    public GameObject gameTimer;
    private Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetTrigger("Run");
        this.GetComponent<NavMeshAgent>().destination = Player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameControl.control.resultTime = gameTimer.gameObject.GetComponent<GameTimer>().timer;
            GameControl.control.condition = "LOSE";
            gameTimer.gameObject.GetComponent<GameTimer>().enabled = false;
            SceneManager.LoadScene(2);
        }
    }
}
