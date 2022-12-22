using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayLevel : MonoBehaviour
{
    Vector3 startFaceingDir;
    // Start is called before the first frame update
    void Start()
    {
        startFaceingDir = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = startFaceingDir;
    }
}
