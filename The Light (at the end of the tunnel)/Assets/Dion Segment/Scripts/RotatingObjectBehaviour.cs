using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObjectBehaviour : MonoBehaviour
{
    enum Direction
    {
        Forward,
        Right,
        Up,

        BackWards,
        Left,
        Down,
    }
    public float rotationSpeed;
    [SerializeField] Direction rotationDirection = Direction.Forward;

    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();
    }

    private void Rotation()
    {
        switch (rotationDirection)
        {
            case Direction.Forward:
                transform.Rotate(transform.forward * rotationSpeed);
                break;
            case Direction.Right:
                transform.Rotate(transform.right * rotationSpeed);
                break;
            case Direction.Left:
                transform.Rotate(-transform.right * rotationSpeed);
                break;
            case Direction.Down:
                transform.Rotate(-transform.up * rotationSpeed);
                break;
            case Direction.BackWards:
                transform.Rotate(-transform.forward * rotationSpeed);
                break;
            case Direction.Up:
                transform.Rotate(transform.up * rotationSpeed);
                break;
            default:
                transform.Rotate(transform.right * rotationSpeed);
                break;
        }
    }
}
