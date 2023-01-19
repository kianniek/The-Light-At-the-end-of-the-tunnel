using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerObjWithCutscene : MonoBehaviour
{
    Vector3 downPos;
    public float amountDown;
    private bool sunk;

    Vector3 startCamPos;
    Quaternion startCamRot;

    [SerializeField] Transform[] mainCamControls;
    [SerializeField] Camera mainCam;
    [SerializeField] Transform posCamCutscene;
    [SerializeField] Transform cameraLookat;
    [SerializeField] float lerpSpeed = 10;

    [SerializeField] MovementController playerController;
    [SerializeField] Mover playerMover;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        downPos = transform.localPosition - (transform.up * amountDown);
    }

    public void Sink()
    {
        if (!sunk)
        {
            StartCoroutine(SinkCutscene());
            sunk = true;
        }
    }
    IEnumerator SinkCutscene()
    {
        yield return new WaitForSeconds(0.5f);

        playerMover.SetVelocity(Vector3.zero);
        playerController.SetMomentum(Vector3.zero);
        playerController.enabled = false;
        //Save camera position
        startCamPos = mainCam.transform.position;
        startCamRot = mainCam.transform.rotation;

        //Unparent Camera and set all Camera contollers to unactive
        mainCam.transform.SetParent(null, true);
        for (int i = 0; i < mainCamControls.Length; i++)
        {
            mainCamControls[i].gameObject.SetActive(false);
        }

        //move Camera to {posCamCutscene} and rotate it accordingly
        float elapsedTime = 0;
        float waitTime = 1f;
        while (elapsedTime < waitTime)
        {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, posCamCutscene.transform.position, lerpSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(cameraLookat.transform.position - mainCam.transform.position);
            mainCam.transform.rotation = Quaternion.Slerp(mainCam.transform.rotation, targetRotation, lerpSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        mainCam.transform.position = posCamCutscene.transform.position;
        //play music
        if (audioSource != null)
        {
            audioSource.Play();
        }

        //Move the level of the water down
        float elapsedTime1 = 0;
        float waitTime1 = 1f;
        while (elapsedTime1 < waitTime1)
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, downPos, lerpSpeed * Time.deltaTime);
            elapsedTime1 += Time.deltaTime;
            // Yield here
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        float elapsedTime2 = 0;
        float waitTime2 = 1f;
        while (elapsedTime2 < waitTime2)
        {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, startCamPos, lerpSpeed * Time.deltaTime);
            mainCam.transform.rotation = Quaternion.Slerp(mainCam.transform.rotation, startCamRot, lerpSpeed * Time.deltaTime);

            elapsedTime2 += Time.deltaTime;

            // Yield here
            yield return null;
        }

        mainCam.transform.SetParent(mainCamControls[^1]);
        mainCam.transform.SetPositionAndRotation(startCamPos, startCamRot);
        for (int i = 0; i < mainCamControls.Length; i++)
        {
            mainCamControls[i].gameObject.SetActive(true);
        }
        playerController.enabled = true;
        playerMover.enabled = true;
        yield return null;
    }
}
