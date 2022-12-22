using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObjectBehaviour : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationDirection;
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();
    }

    private void Rotation()
    {
        transform.Rotate(rotationSpeed * rotationDirection, transform.rotation.y, transform.rotation.z);
    }
}
