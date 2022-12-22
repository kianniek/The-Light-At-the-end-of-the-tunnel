using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    public static Vector3 resetPosition;

    public bool hitWater;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = resetPosition;

            hitWater = true;
        }
        else
        {
            hitWater = false;
        }
    }
}
