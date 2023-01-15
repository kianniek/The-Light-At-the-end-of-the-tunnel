using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] Vector3 respawnPosition;
    [SerializeField] Vector3 respawnRotation;
    [SerializeField] WaterBehaviour water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            water.allowRespawn = false;
            //water.spawnPosition = respawnPosition;
            //water.spawnRotation = Quaternion.Euler(respawnRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
