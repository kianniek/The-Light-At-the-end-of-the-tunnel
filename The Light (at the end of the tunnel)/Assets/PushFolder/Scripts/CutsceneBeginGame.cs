using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Serializable]
    internal struct ComponentsDisable
    {
        [SerializeField] public MonoBehaviour behaviour;
        [SerializeField] public bool disableObject;
    }

    // all defined sounds
    [SerializeField] private List<CameraPlace> positions;
    [SerializeField] private SmoothPosition camSmoothPos;
    private float camSmoothPosLerpSave;
    [SerializeField] Transform[] mainCamControls;
    [SerializeField] ComponentsDisable[] componentsToDisable;
    [SerializeField] Camera mainCam;
    [SerializeField] float lerpSpeedMax = 1;
    [SerializeField] float lerpSpeed = 0.001f;

    [SerializeField] MovementController playerController;
    [SerializeField] Mover playerMover;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        camSmoothPosLerpSave = camSmoothPos.lerpSpeed;
        camSmoothPos.lerpSpeed = 0f;
        StartCoroutine(BeginCutscene());
    }

    void Update()
    {

    }
    IEnumerator BeginCutscene()
    {
        yield return new WaitForSeconds(0.01f);

        playerMover.SetVelocity(Vector3.zero);
        playerController.SetMomentum(Vector3.zero);
        playerController.enabled = false;
        //Save camera position
        startCamPos = mainCam.transform.position;
        startCamRot = mainCam.transform.rotation;

        //Unparent Camera and set all Camera contollers to unactive
        mainCam.transform.SetParent(null, true);

        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            if (componentsToDisable[i].disableObject)
            {
                componentsToDisable[i].behaviour.gameObject.SetActive(false);
            }
            else
            {
                componentsToDisable[i].behaviour.enabled = false;
            }
        }
        mainCam.transform.position = positions[0].posCamCutscene.position;
        mainCam.transform.LookAt(positions[0].cameraLookat.transform);

        yield return new WaitUntil(StartGame);

        yield return new WaitForSeconds(1f);
        float elapsedTime = 0;
        //float waitTime = 1f;
        while (Vector3.Distance(mainCam.transform.position, positions[^1].posCamCutscene.transform.position) > 0.01f)
        {
            float stepAmount = Mathf.Pow(lerpSpeed, 10f);
            lerpSpeed = Mathf.MoveTowards(lerpSpeed, lerpSpeedMax, stepAmount);
            //lerpSpeed = Mathf.Clamp(lerpSpeed, 0, lerpSpeedMax);
            mainCam.transform.SetPositionAndRotation(Vector3.Lerp(mainCam.transform.position, positions[^1].posCamCutscene.transform.position, lerpSpeed * elapsedTime), Quaternion.Slerp(mainCam.transform.rotation, startCamRot, lerpSpeed * Time.deltaTime));

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }

        mainCam.transform.SetParent(mainCamControls[^1]);
        mainCam.transform.SetPositionAndRotation(startCamPos, startCamRot);

        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            if (componentsToDisable[i].disableObject)
            {
                componentsToDisable[i].behaviour.gameObject.SetActive(true);
            }
            else
            {
                componentsToDisable[i].behaviour.enabled = true;
            }
        }

        float elapsedTime3 = 0;
        float waitTime3 = 1f;
        while (elapsedTime3 < waitTime3)
        {
            elapsedTime3 += Time.deltaTime;
            camSmoothPos.lerpSpeed = elapsedTime3 * camSmoothPosLerpSave;

            // Yield here
            yield return null;
        }
        camSmoothPos.lerpSpeed = camSmoothPosLerpSave;
        playerController.enabled = true;
        playerMover.enabled = true;
        yield return null;
    }

    bool StartGame()
    {
        return startCutscnene;
    }
}
