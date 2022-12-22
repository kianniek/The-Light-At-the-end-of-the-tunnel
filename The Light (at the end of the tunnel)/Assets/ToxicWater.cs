using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToxicWater : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] PlatformScript[] platformScript;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = spawnPoint.transform.position;
            ResetAllPlatforms();
        }
    }
    private void ResetAllPlatforms()
    {
        for (int i = 0; i < platformScript.Length; i++)
        {
            platformScript[i].transform.position = platformScript[i].startposition;
        }
    }
}
