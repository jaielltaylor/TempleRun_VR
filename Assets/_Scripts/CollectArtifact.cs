using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectArtifact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (this.transform.GetChild(0).gameObject.activeSelf == true)
            {
                GameControl.control.artifactsGathered += 1;
                this.transform.GetChild(0).gameObject.SetActive(false);
            }         
        }
    }
}
