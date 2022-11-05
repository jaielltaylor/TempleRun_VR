using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int artifactsGathered;
    public float resultTime;
    public int scoreMultiplier = 1000;
    public int scoreDump;
    public string condition;

    public static GameControl control;
    void Awake()
    {
        if (control == null)        // If this is the first scene...
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)   // For any subsequent scene that uses GameControl...
        {       // If I am the new instance of the GameControl script...
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }

}
