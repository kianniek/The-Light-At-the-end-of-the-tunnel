using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] Transform resetPosition;
    [SerializeField] PlatformBehaviour[] allPlatforms;
    [SerializeField] SoundManager[] allSounds;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetAllPlatforms();
            //other.transform.position = resetPosition.position;
        }
    }
    void ResetAllPlatforms()
    {
        for (int i = 0; i < allPlatforms.Length; i++)
        {
            allPlatforms[i].Reset();
        }
        for (int i = 0; i < allSounds.Length; i++)
        {
            allSounds[i].Reset();
        }
        for 
    }
}
