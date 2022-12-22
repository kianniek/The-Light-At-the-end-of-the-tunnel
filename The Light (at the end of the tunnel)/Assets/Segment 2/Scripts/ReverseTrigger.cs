using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTrigger : MonoBehaviour
{
    [SerializeField] PipeRotation pipe;
    [SerializeField] bool manualActivation;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            pipe.reverseSegmentActive = true;
            activated = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (manualActivation && !activated)
        {
            pipe.reverseSegmentActive = true;
            activated = true;
        }
    }

    public void Reset()
    {
        manualActivation = false;
        activated = false;
    }
}
