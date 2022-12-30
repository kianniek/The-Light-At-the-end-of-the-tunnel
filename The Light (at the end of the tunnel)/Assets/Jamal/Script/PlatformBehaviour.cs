using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] Transform Platformheight;
    [SerializeField] float lerpspeed;
    [SerializeField] Transform waterTransform;
    [SerializeField] Material safe, sinking;
    private Vector3 startposition;
    public bool isLowering = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = safe;
        startposition = transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        isLowering = true;
    }
    private void FixedUpdate()
    {
        if (isLowering)
        {
            gameObject.GetComponent<MeshRenderer>().material = sinking;
            LowerPlatform();
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = safe;
        }
    }
    public void LowerPlatform()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, waterTransform.position.y, transform.position.z), lerpspeed / 100);
    }
    public void RisingPlatform()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Platformheight.transform.position.y, transform.position.z), lerpspeed / 100);
    }
    public void Reset()
    {
        gameObject.GetComponent<MeshRenderer>().material = safe;
        isLowering = false;
        transform.position = startposition;
    }
}
