using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This script keeps track of all controllers that enter or leave the trigger collider attached to this gameobject;
//It is used by 'MovingPlatform' to detect and move controllers standing on top of it;
public class TriggerArea : MonoBehaviour, ISerializationCallbackReceiver
{
    public HashSet<Rigidbody> rigidbodiesInTriggerArea = new();

#if UNITY_EDITOR
    // private field to ensure serialization
    [SerializeField]
    private List<Rigidbody> rigidbodiesInTriggerAreaEditor = new List<Rigidbody>();

    public void OnBeforeSerialize()
    {
        // store HashSet contents in List
        rigidbodiesInTriggerAreaEditor.Clear();
        foreach (Rigidbody allowedType in rigidbodiesInTriggerArea)
        {
            rigidbodiesInTriggerAreaEditor.Add(allowedType);
        }
    }

    public void OnAfterDeserialize()
    {
        // load contents from the List into the HashSet
        rigidbodiesInTriggerArea.Clear();
        foreach (Rigidbody allowedType in rigidbodiesInTriggerAreaEditor)
        {
            rigidbodiesInTriggerArea.Add(allowedType);
        }
    }
    //Check
#endif

    //Check if the collider that just entered the trigger has a rigidbody (and a mover) attached and add it to the list;
    void OnTriggerEnter(Collider col)
    {
        if (col.attachedRigidbody != null)
        {
            rigidbodiesInTriggerArea.Add(col.attachedRigidbody);
        }
    }

    //Check if the collider that just left the trigger has a rigidbody (and a mover) attached and remove it from the list;
    void OnTriggerExit(Collider col)
    {
        if (col.attachedRigidbody != null)
        {
            rigidbodiesInTriggerArea.Remove(col.attachedRigidbody);
        }
    }
}
