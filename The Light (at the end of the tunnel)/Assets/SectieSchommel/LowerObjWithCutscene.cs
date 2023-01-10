using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerObjWithCutscene : MonoBehaviour
{
    Vector3 downPos;
    public float amountDown;
    [SerializeField] Transform[] mainCamControls;
    [SerializeField] Camera mainCam;
    [SerializeField] Transform posCamCutscene;
    [SerializeField] Transform cameraLookat;

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
        //if(Vector3.Distance(transform.localPosition, downPos))
        StartCoroutine(SinkCutscene());
    }

    IEnumerator SinkCutscene()
    {
        yield return new WaitForSeconds(1f);

        mainCam.transform.SetParent(null);
        for (int i = 0; i < mainCamControls.Length; i++)
        {
            mainCamControls[i].gameObject.SetActive(false);
        }

        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, posCamCutscene.transform.position, 0.5f);

        mainCam.transform.LookAt(cameraLookat);

        transform.localPosition = Vector3.Lerp(transform.localPosition, downPos, 0.01f);
        Debug.Log(transform.localPosition);

        yield return new WaitForSeconds(4f);

        for (int i = 0; i < mainCamControls.Length; i++)
        {
            mainCamControls[i].gameObject.SetActive(true);
        }
        mainCam.transform.SetParent(mainCamControls[^1]);


        

        StopAllCoroutines();
    }
}
