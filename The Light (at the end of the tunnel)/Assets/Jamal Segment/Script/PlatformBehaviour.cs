using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using static RotateObject;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] bool constantRotation = false;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float waitTime = 3;
    [SerializeField] float duration = 3;

    [SerializeField] AnimationCurve curve;
    [SerializeField] GameObject platform;
    [SerializeField] float lerpspeed;
    private Vector3 startposition;
    public bool isLowering = false;

    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        /*if (!isLowering)
        {
            StartCoroutine(LowerPlatform());
            isLowering = true;
        }*/
        isLowering = true;

    }
    private void FixedUpdate()
    {
        if (isLowering)
        {
            LowerPlatform();
        }
    }

    void LowerPlatform()
    {
        platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x, platform.transform.position.y - 2, platform.transform.position.z), lerpspeed / 100);
    }
    /*  public IEnumerator LowerPlatform()
      {
          if (isLowering)
          {
              yield break;
          }

          float counter = 0;

          while (counter < duration)
          {
              counter = counter + Time.deltaTime;
              float percent = Mathf.Clamp01(counter / duration);
              float curvePercent = curve.Evaluate(percent);
              counter += Time.deltaTime;
              platform.transform.position = Vector3.LerpUnclamped(platform.transform.position, new Vector3(platform.transform.position.x, platform.transform.position.y - 2, platform.transform.position.z), curvePercent);
          }
          yield return null;
          isLowering = false;
      }*/

    public void Reset()
    {
        isLowering = false;
        platform.transform.position = startposition;
    }
}
