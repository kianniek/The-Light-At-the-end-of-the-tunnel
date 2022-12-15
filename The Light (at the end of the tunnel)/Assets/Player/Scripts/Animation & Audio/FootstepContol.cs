using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class FootstepContol : MonoBehaviour
{
    public bool footOnGround;
    public float footGroundedTreshholdHeight = 0.2f;
    public GameObject modelRoot;
    public List<GameObject> footBones = new();
    float currentFootStepValue = 0;
    // Update is called once per frame
    void LateUpdate()
    {
        foreach (GameObject foot in footBones)
        {
            float _newFootStepValue = (float)Math.Round(foot.transform.position.y - modelRoot.transform.position.y, 2);
            Debug.Log(foot.name + ": " + Math.Round(foot.transform.position.y - modelRoot.transform.position.y, 2));
            if ((currentFootStepValue <= footGroundedTreshholdHeight && _newFootStepValue > footGroundedTreshholdHeight) || (currentFootStepValue >= footGroundedTreshholdHeight && _newFootStepValue < footGroundedTreshholdHeight))
            {
                footOnGround = true;
            }
        }
    }
}
