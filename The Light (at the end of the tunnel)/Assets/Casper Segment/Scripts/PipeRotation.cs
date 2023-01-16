using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PipeRotation : MonoBehaviour
{
    public LevelTrigger trigger;
    public bool playerDead = false;
    public bool reverseSegmentActive = false;

    public float rpm;
    [SerializeField] float accelerationTime;
    [SerializeField] Vector3 offsetRotation;

    private float rotationSpeed;
    private float currentAcceleration;
    private Vector3 currentRotation;
    private bool reachedZero = false;


    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = rpm * 6;
        currentRotation = offsetRotation;
        transform.rotation = Quaternion.Euler(offsetRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!reverseSegmentActive)
            RotatePipe();
        else
            ReverseRotatePipe();
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

    public void ReverseRotatePipe()
    {
        accelerationTime = 1;
        if (trigger.levelActive)
        {
            if (!playerDead && reachedZero)
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
                    reachedZero = true;
                }
            }

            if (reachedZero)
                currentRotation = new Vector3(currentRotation.x - (Time.deltaTime * rotationSpeed * currentAcceleration), currentRotation.y, currentRotation.z);
            else
                currentRotation = new Vector3(currentRotation.x + (Time.deltaTime * rotationSpeed * currentAcceleration), currentRotation.y, currentRotation.z);
            transform.rotation = Quaternion.Euler(currentRotation);
        }
    }

    public void Reset()
    {
        playerDead = false;
        reverseSegmentActive = false;
        reachedZero = false;
        currentAcceleration = 0;
        Start();
    }
}
