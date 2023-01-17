using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.WSA;

public class OppositeRotator : MonoBehaviour
{
    public PipeRotation pipe;
    public LevelTrigger trigger;

    public bool activated = false;
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
        if (other.CompareTag("Player") && !activated)
        {
            trigger.levelActive = true;
            pipe.reverseSegmentActive = true;
            pipe.rpm *= -1;
            activated = true;
            pipe.playerDead = false;
        }
    }
}
