using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{
    [SerializeField] float pushForce;
    enum direction
    {
        up,
        down,
        left,
        right
    }

    [SerializeField] direction currentdirection;

    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            if(currentdirection == direction.right)
            other.transform.position += new Vector3(0, 0, pushForce);
            if (currentdirection == direction.left)
                other.transform.position += new Vector3(0, 0, -pushForce);
            if (currentdirection == direction.up)
                other.transform.position += new Vector3(0, pushForce, 0);
            if (currentdirection == direction.down)
                other.transform.position += new Vector3(0, -pushForce, 0);
        } 
    }

}
