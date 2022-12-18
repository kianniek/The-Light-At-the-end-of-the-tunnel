using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformHandler : MonoBehaviour
{
    public GameObject[] redPlattforms;
    public GameObject[] bluePlattforms;

    public MovementController movementPlayer;
    public Mover player;

    private bool red;
    private bool blue;

    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int b = 0; b < bluePlattforms.Length; b++)
        {
            bluePlattforms[b].SetActive(false);
        }

        for (int r = 0; r < redPlattforms.Length; r++)
        {
            redPlattforms[r].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlattforms();
    }

    private void HandlePlattforms()
    {
        //Blue on
        if (jumpCount == 0 && movementPlayer.jumpKeyWasPressed && player.isGrounded)
        {
            Invoke("BlueActive", 0.5f);
        }
        //Red on
        else if (jumpCount == 1 && movementPlayer.jumpKeyWasPressed && player.isGrounded)
        {
            Invoke("RedActive", 0.5f);
        }
        //Reset
        else if (red && blue)
        {
            jumpCount = 0;

            red = false;
            blue = false;
        }
    }

    private void BlueActive()
    {
        blue = true;

        jumpCount = 1;

        for (int b = 0; b < bluePlattforms.Length; b++)
        {
            bluePlattforms[b].SetActive(true);
        }

        for (int r = 0; r < redPlattforms.Length; r++)
        {
            redPlattforms[r].SetActive(false);
        }
    }

    private void RedActive()
    {
        red = true;

        jumpCount = 2;

        for (int r = 0; r < redPlattforms.Length; r++)
        {
            redPlattforms[r].SetActive(true);
        }

        for (int b = 0; b < bluePlattforms.Length; b++)
        {
            bluePlattforms[b].SetActive(false);
        }
    }
}
