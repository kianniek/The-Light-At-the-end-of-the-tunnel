using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] Image image;
    float fadetimer;
    [SerializeField] float fadeinMultiplier = 0.05f;
    [SerializeField] float fadeoutMultiplier = 0.1f;
    [SerializeField] MovementController playerMovement;

    private void Update()
    {
        if (playerMovement.GetVelocity() == Vector3.zero)
        {
            StartCoroutine(FadeControls());
        }
        else
        {
            fadetimer -= fadeoutMultiplier * Time.deltaTime;
        }
        if (fadetimer < 0)
        {
            fadetimer = 0;
            StopCoroutine(FadeControls());
        }
        if (fadetimer > 1)
        {
            fadetimer = 1;
        }
        FadeImageIn();
    }
    IEnumerator FadeControls()
    {
        yield return new WaitForSeconds(10f);
        fadetimer += fadeinMultiplier * Time.deltaTime;
        yield return null;
    }
    public void FadeImageIn()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, fadetimer);
    }

}
