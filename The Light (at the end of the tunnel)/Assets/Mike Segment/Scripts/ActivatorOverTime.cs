using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorOverTime : MonoBehaviour
{
    public PushActivator[] pushingpipes;
    int timer;
    public int Switchtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer < Switchtime)
        {
            timer++;
        }
        if (timer == Switchtime)
        {
            foreach (var pipe in pushingpipes)
            {
                pipe.Active = pipe.Active ? false : true;
            }
            timer = 0;
        }
    }
}
