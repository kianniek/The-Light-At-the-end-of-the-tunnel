using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushActivator : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] GameObject collider;
    [SerializeField] bool Active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Active)
        {
            particles.SetActive(true);
            collider.SetActive(true);
        }else if (!Active)
        {
            particles.SetActive(true);
            collider.SetActive(true);
        }
    }

    //IEnumerator ActiveOverTime()
    //{
    //    return WaitForSeconds(10)
    //}
}
