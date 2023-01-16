using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    public bool hitCheckpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DeathManager.resetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            hitCheckpoint = true;
        }
    }
}
