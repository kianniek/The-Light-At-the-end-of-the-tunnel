using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPipe : MonoBehaviour
{
    [SerializeField] bool constantRotation = false;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float waitTime = 3;
    [SerializeField] float Smoothness = 3;

    [SerializeField] Vector3[] rotationCheckpoints;
    int iteration = 0;
    int angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!constantRotation)
        {
            transform.rotation = Quaternion.Euler(rotationCheckpoints[0]);
            StartCoroutine(RotateUsingCheckpoints());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    IEnumerator RotateUsingCheckpoints(bool constant = false)
    {
        {
            while (true)
            {
                //Rotate 90
                yield return RotateObject(gameObject, rotationCheckpoints[0], Smoothness);

                //Wait?
                yield return new WaitForSeconds(waitTime);
                //Rotate -90
                yield return RotateObject(gameObject, rotationCheckpoints[1], Smoothness);

                //Wait?
                yield return new WaitForSeconds(waitTime);
            }
        }
    }

    bool rotating = false;
    IEnumerator RotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        Quaternion newRot = Quaternion.Euler(eulerAngles);
        Quaternion currentRot = gameObjectToMove.transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }
}
