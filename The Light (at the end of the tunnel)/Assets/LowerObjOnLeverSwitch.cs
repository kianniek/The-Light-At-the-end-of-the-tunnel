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
        downPos = transform.localPosition - (transform.up * amountDown);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sink()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, downPos, 0.01f);
        Debug.Log(transform.localPosition);
    }
}
