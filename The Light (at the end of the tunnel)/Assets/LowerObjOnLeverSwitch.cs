using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerObjOnLeverSwitch : MonoBehaviour
{
    Vector3 downPos;
    public float amountDown;
    // Start is called before the first frame update
    void Start()
    {
        downPos = transform.position - transform.up * amountDown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sink()
    {
        transform.position = Vector3.Lerp(transform.position, downPos, 0.1f);
        Debug.Log(transform.position);
    }
}
