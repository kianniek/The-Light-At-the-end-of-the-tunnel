using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartColorPlatforms : MonoBehaviour
{
    public GameObject platformHandler;
    public CheckpointHandler checkpoint;

    // Update is called once per frame
    void Update()
    {
        SetPlatformHandlerOn();
    }

    private void SetPlatformHandlerOn()
    {
        if (checkpoint.hitCheckpoint)
        {
            platformHandler.SetActive(true);
        }
    }
}
