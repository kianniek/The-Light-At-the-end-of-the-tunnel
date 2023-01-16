using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{
    [SerializeField] float pushForce;
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            MovementController mover = other.gameObject.GetComponent<MovementController>();
            mover.AddMomentum(transform.up * pushForce);
        }
    }

}
