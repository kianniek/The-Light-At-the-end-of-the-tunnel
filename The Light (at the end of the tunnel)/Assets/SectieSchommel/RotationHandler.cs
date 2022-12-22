using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    public float rotationSpeed;
    Rigidbody rb;
    [HideInInspector] public float rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        rotation++;
        if (rotation > 360 / rotationSpeed) { rotation = 0; }
        rb.MoveRotation(Quaternion.Euler(0, rotation * rotationSpeed, 0));
    }
}

