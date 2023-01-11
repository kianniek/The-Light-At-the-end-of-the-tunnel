using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveWithPlatform : MonoBehaviour
{
    //References to attached components;
    Rigidbody r;
    TriggerArea triggerArea;
    int count;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        //Get references to components;
        r = GetComponent<Rigidbody>();
        triggerArea = GetComponentInChildren<TriggerArea>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Get normalized movement direction;
        Vector3 _movement = transform.position - startPos;
        //_movement.Normalize();
        
        //Debug.DrawRay(transform.position, _movement, Color.red);
        if (triggerArea == null)
            return;

        //Move all controllrs on top of the platform the same distance;
        foreach (Rigidbody rb in triggerArea.rigidbodiesInTriggerArea)
        {
            rb.MovePosition(rb.position + _movement);
        }
        //for (int i = 0; i < triggerArea.rigidbodiesInTriggerArea.Count; i++)
        //{
            //triggerArea.rigidbodiesInTriggerArea[i].MovePosition(triggerArea.rigidbodiesInTriggerArea[i].position + _movement);
        //}
        startPos = transform.position;
    }
}
