using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformRaycast : MonoBehaviour
{
    [SerializeField] LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //     CheckForPlatform();
    }
    private void FixedUpdate()
    {
        CheckForPlatform();
    }
    private void CheckForPlatform()
    {
        GameObject platform;
        RaycastHit hit;
        //checkt of de speler boven een platform is
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Vector3.down * 10, Color.magenta);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Vector3.down, out hit, Mathf.Infinity, mask))
        {
            Debug.Log(hit.collider.gameObject.tag);

          //  platform = hit.collider.gameObject;
         //   platform.GetComponent<PlatformBehaviour>().isLowering = true;

        }


    }

}
