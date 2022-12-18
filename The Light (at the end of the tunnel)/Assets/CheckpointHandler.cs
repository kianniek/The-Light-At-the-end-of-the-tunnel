using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WaterCollision.resetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
