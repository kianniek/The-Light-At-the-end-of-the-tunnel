using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterCollision : MonoBehaviour
{
    public bool hitWater;

    public UnityEvent executeFunction;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            executeFunction.Invoke();

            hitWater = true;
        }
        else
        {
            hitWater = false;
        }
    }
}
