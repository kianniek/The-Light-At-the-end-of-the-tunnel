using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] Image image;
    public float fadetimer;
    [SerializeField] MovementController playerMovement;

    private void Update()
    {
        if(playerMovement.GetVelocity()== Vector3.zero)
        {
            fadetimer+= 0.01f;
        }
        else
        {
            fadetimer -= 0.1f;
        }
        if(fadetimer < 0)
        {
            fadetimer = 0;
        }
        FadeImageIn();
    }
    public void FadeImageIn()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, fadetimer);
    }

}
