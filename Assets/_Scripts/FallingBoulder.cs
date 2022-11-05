using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingBoulder : MonoBehaviour
{
    public GameObject boulder;
    public float fallSpeed = 8.0f;

    private float spawnTime;
    private float boulderTime;

    void Start()
    {
        boulderTime = Mathf.RoundToInt(Random.Range(400.0f, 800.0f));
    }
    void Update()
    {
        spawnTime += 1;
        if (spawnTime == boulderTime)
        {
            SpawnBoulder();
            spawnTime = 0.0f;
            boulderTime = Mathf.RoundToInt(Random.Range(400.0f, 800.0f));
        }
    }

    void SpawnBoulder()
    {
        Instantiate(boulder, this.transform.position, new Quaternion(0, 0, 0, 0));
        boulder.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
    }
}
