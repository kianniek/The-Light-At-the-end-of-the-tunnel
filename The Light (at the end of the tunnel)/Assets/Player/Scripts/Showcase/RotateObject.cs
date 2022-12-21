using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    Transform tr;
    //Speed of rotation;
    public float rotationSpeed = 20f;
    //Axis used for rotation;
    public Rotation rotationAxis;
    public RotationType rotationType;

    public enum Rotation
    {
        Up,
        Right,
        Forward
    }
    public enum RotationType
    {
        Local,
        World
    }
    //Start;
    void Start()
    {
        //Get transform component reference;
        tr = transform;
    }

    //Update;
    void Update()
    {
        switch (rotationType)
        {
            case RotationType.Local:
                switch (rotationAxis)
                {
                    case Rotation.Up:
                        tr.Rotate(rotationSpeed * tr.up);
                        break;
                    case Rotation.Right:
                        tr.Rotate(rotationSpeed * tr.right);
                        break;
                    case Rotation.Forward:
                        tr.Rotate(rotationSpeed * tr.forward);
                        break;
                    default:
                        break;
                }
                break;
            case RotationType.World:
                switch (rotationAxis)
                {
                    case Rotation.Up:
                        tr.Rotate(rotationSpeed * Vector3.up);
                        break;
                    case Rotation.Right:
                        tr.Rotate(rotationSpeed * Vector3.right);

                        break;
                    case Rotation.Forward:
                        
                        tr.Rotate(rotationSpeed * Vector3.forward);

                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        
    }
}
