using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class WaterResetHandler : MonoBehaviour
{
    public static Vector3 resetPosition = new Vector3(0, 0, 0);

    [SerializeField] GameObject player;

    [SerializeField] WaterManager water;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            ResetPlayerPosition();
        }
    }

    public void ResetPlayerPosition()
    {
        player.transform.position = resetPosition;
    }


}
