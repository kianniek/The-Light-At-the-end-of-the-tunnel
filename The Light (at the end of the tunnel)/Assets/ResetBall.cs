using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    public Vector3 resetPosition;

    public PathFollow path;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            path.current = 0;

            transform.position = resetPosition;
        }
    }
}
