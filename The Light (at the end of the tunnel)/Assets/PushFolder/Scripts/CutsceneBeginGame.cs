using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBeginGame : MonoBehaviour
{
    public bool startCutscnene;

    Vector3 startCamPos;
    Quaternion startCamRot;

    [Serializable]
    internal struct CameraPlace
    {
        [SerializeField] public Transform posCamCutscene;
        [SerializeField] public Transform cameraLookat;
    }

    // all defined sounds
    [SerializeField] private List<CameraPlace> positions;

    [SerializeField] Transform[] mainCamControls;
    [SerializeField] Transform[] componentsToDisable;
    [SerializeField] Camera mainCam;
    [SerializeField] float lerpSpeedMax = 1;
    private float lerpSpeed;

    [SerializeField] MovementController playerController;
    [SerializeField] Mover playerMover;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
            StartCoroutine(SinkCutscene());
    }

    void Update()
    {

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

        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].gameObject.SetActive(false);
        }
        mainCam.transform.position = positions[0].posCamCutscene.position;
        mainCam.transform.LookAt(positions[0].cameraLookat.transform);

        //play music
        //if (audioSource != null)
        //{
        //    audioSource.Play();
        //}

        yield return new WaitUntil(StartGame);

        yield return new WaitForSeconds(1f);
        float elapsedTime = 0;
        float waitTime = 1f;
        while (elapsedTime < waitTime)
        {
            float stepAmount = Mathf.Pow(elapsedTime, 10f);
            lerpSpeed = Mathf.MoveTowards(0f, lerpSpeedMax, stepAmount);
            //lerpSpeed = Mathf.Clamp(lerpSpeed, 0, lerpSpeedMax);
            mainCam.transform.SetPositionAndRotation(Vector3.Lerp(mainCam.transform.position, positions[^1].posCamCutscene.transform.position, lerpSpeed * Time.deltaTime), Quaternion.Slerp(mainCam.transform.rotation, startCamRot, lerpSpeed * Time.deltaTime));

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }

        mainCam.transform.SetParent(mainCamControls[^1]);
        mainCam.transform.SetPositionAndRotation(startCamPos, startCamRot);

        for (int i = 0; i < mainCamControls.Length; i++)
        {
            mainCamControls[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].gameObject.SetActive(true);
        }
        playerController.enabled = true;
        playerMover.enabled = true;
        yield return null;
    }

    bool StartGame()
    {
        return startCutscnene;
    }
}
