using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchLever : MonoBehaviour
{
    //This creates an interface in the inspector to assign functions
    public UnityEvent OtherFunctions;

    public bool isSwitched;

    void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isSwitched = true;
            }
        }
    }

    void Update()
    {
        if (isSwitched)
        {
            CallOtherFunctions();
        }
    }

    //This is the function that will be called and will trigger another function
    void CallOtherFunctions()
    {
        OtherFunctions.Invoke();
    }
}
