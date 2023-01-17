using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroManager : MonoBehaviour
{
    [SerializeField] GameObject sewerLid;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;

    [SerializeField] Camera mainCam;
    [SerializeField] Transform posCamCutscene;
    [SerializeField] Transform cameraLookat;


    [SerializeField] Transform endPosCamCutscene;
    [SerializeField] Transform endCameraLookat;

    [SerializeField] Transform endPosCamCutscene1;
    [SerializeField] Transform endCameraLookat1;
    [SerializeField] float lerpSpeed = 10;
    [SerializeField] float timeBetweenFazes = 10;
    [Range(0, 1)]
    [SerializeField] float speed;

    [SerializeField] bool trigger;
    [SerializeField] bool trigger1;

   public UnityEvent function;
    // Start is called before the first frame update
    void Start()
    {
        sewerLid.transform.position = startPos.position;

        mainCam.transform.position = posCamCutscene.transform.position;

        Quaternion targetRotationBegin = Quaternion.LookRotation(cameraLookat.transform.position - mainCam.transform.position);
        mainCam.transform.rotation = targetRotationBegin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            trigger = true;
        }
        if (trigger)
        {
            sewerLid.transform.localPosition = Vector3.Lerp(sewerLid.transform.localPosition, endPos.position, speed * Time.deltaTime);
            if (!trigger1)
            {
                StartCoroutine(PanCamera());
            }
            trigger1 = true;
        }
    }

    IEnumerator PanCamera()
    { 
        yield return new WaitForSeconds(3f);

        float elapsedTime = 0;
        float waitTime = timeBetweenFazes;
        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            float percent = Mathf.Clamp01(elapsedTime / waitTime);
            mainCam.transform.position = Vector3.LerpUnclamped(mainCam.transform.position, endPosCamCutscene.transform.position, percent * lerpSpeed);

            Quaternion targetRotation = Quaternion.LookRotation(endCameraLookat.transform.position - mainCam.transform.position);
            mainCam.transform.rotation = Quaternion.SlerpUnclamped(mainCam.transform.rotation, targetRotation, percent * lerpSpeed);

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        float elapsedTime1 = 0;
        float waitTime1 = timeBetweenFazes;
        while (elapsedTime1 < waitTime1)
        {
            elapsedTime1 += Time.deltaTime;
            float percent = Mathf.Clamp01(elapsedTime1 / waitTime1);
            mainCam.transform.position = Vector3.LerpUnclamped(mainCam.transform.position, endPosCamCutscene1.transform.position, percent * lerpSpeed);

            Quaternion targetRotation = Quaternion.LookRotation(endCameraLookat1.transform.position - mainCam.transform.position);
            mainCam.transform.rotation = Quaternion.SlerpUnclamped(mainCam.transform.rotation, targetRotation, percent * lerpSpeed);

            elapsedTime1 += Time.deltaTime;

            // Yield here
            yield return null;
        }

        function.Invoke();
        yield return null;
    }
}
