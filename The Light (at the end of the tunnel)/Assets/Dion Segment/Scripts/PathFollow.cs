using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    public GameObject obj;
    public GameObject[] wayPoints;

    public int numberOfPoints;
    public int current;

    public float speed;
    public float rotationSpeed;

    private Vector3 actualPosition;

    private void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPath();

        //Debug.Log(current);
    }

    private void FollowPath()
    {
        actualPosition = obj.transform.position;

        //Object moves to way point 
        obj.transform.position = Vector3.MoveTowards(actualPosition, wayPoints[current].transform.position, speed * Time.deltaTime);

        obj.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));

        //Checking for new way point
        if ((actualPosition.x <= wayPoints[current].transform.position.x && actualPosition.y <= wayPoints[current].transform.position.y &&
            actualPosition.z <= wayPoints[current].transform.position.z) && current != numberOfPoints - 1)
        {
            current++;
        }
    }
}
