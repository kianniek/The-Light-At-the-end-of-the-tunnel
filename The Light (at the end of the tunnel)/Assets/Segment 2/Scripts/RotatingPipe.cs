using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RotatingPipe : MonoBehaviour
{
    public LevelTrigger trigger;
    public bool playerDead = false;

    [SerializeField] float rpm;
    [SerializeField] float accelerationTime;
    [SerializeField] Vector3 offsetRotation;

    private float rotationSpeed;
    private float currentAcceleration;
    private Vector3 currentRotation;


    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = rpm * 6;
        currentRotation = offsetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePipe();
    }

    public void RotatePipe()
    {
        if (trigger.levelActive)
        {
            if (!playerDead)
            {
                if (currentAcceleration < 1)
                {
                    currentAcceleration += Time.deltaTime / accelerationTime;
                }
                if (currentAcceleration > 1)
                {
                    currentAcceleration = 1;
                }
            }
            else
            {
                if (currentAcceleration > 0)
                {
                    currentAcceleration -= Time.deltaTime / accelerationTime;
                }
                if (currentAcceleration < 0)
                {
                    currentAcceleration = 0;
                }
            }

            currentRotation = new Vector3(currentRotation.x + (Time.deltaTime * rotationSpeed * currentAcceleration), currentRotation.y, currentRotation.z);
            transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
}
