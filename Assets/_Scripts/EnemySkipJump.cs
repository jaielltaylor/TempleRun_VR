using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySkipJump : MonoBehaviour
{
    public Transform destination;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
            StartCoroutine(transport(other));
        }
    }

    IEnumerator transport(Collider other)
    {
        yield return new WaitForSeconds(1);
        other.transform.position = destination.position;
        other.GetComponent<NavMeshAgent>().enabled = true;

    }
}
