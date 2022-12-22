using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    public Vector3 resetPosition;

    public PathFollow path;

    private bool hitWater;

    //Resetting ball
    private void OnTriggerEnter(Collider other)
    {
        if (!hitWater)
        {
            if (other.gameObject.CompareTag("Water"))
            {
                Invoke("BallResetter", 3f);

                hitWater = true;
            }
        }
    }

    //Reset player position
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = WaterCollision.resetPosition;
        }
    }

    private void BallResetter()
    {
        hitWater = false;

        path.current = 0;

        transform.position = resetPosition;
    }
}
