using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerStayEvent : MonoBehaviour
{
    //This creates an interface in the inspector to assign functions
    public UnityEvent OtherFunctions;
    [SerializeField] string CheckForTag = "Player";
    public bool isSwitched;

    void Start()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(CheckForTag))
        {
            isSwitched = true;
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
