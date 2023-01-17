using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformHandler : MonoBehaviour
{
    public GameObject[] redPlattforms;
    public GameObject[] bluePlattforms;

    public MovementController movementPlayer;
    public Mover player;

    public WaterCollision[] water;

    public CheckpointHandler[] checkpoints;

    public bool red;
    public bool blue;
    public bool isJumping;

    public int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int b = 0; b < bluePlattforms.Length; b++)
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

        //Debug.Log(jumpCount);
    }

    private void HandlePlattforms()
    {
        //Checks if player is jumping
        if (movementPlayer.jumpKeyIsPressed)
        {
            isJumping = true;
        }
        else if (player.isGrounded)
        {
            isJumping = false;
        }

        //Blue on
        if ((jumpCount == 0 && isJumping && player.isGrounded) || (checkpoints[1].hitCheckpoint && water[1].hitWater))
        {
            Invoke("BlueActive", 0.3f);

            SetHitChecksFalse();
        }

        //Red on
        if ((jumpCount == 1 && isJumping && player.isGrounded) || ((checkpoints[0].hitCheckpoint && water[0].hitWater) ||
            (checkpoints[2].hitCheckpoint && water[2].hitWater) || (checkpoints[3].hitCheckpoint && water[3].hitWater)))
        {
            Invoke("RedActive", 0.3f);

            SetHitChecksFalse();
        }

        //Reset
        if ((red && blue) || (jumpCount == 2))
        {
            ResetCounter();

            SetHitChecksFalse();
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

    private void ResetCounter()
    {
        jumpCount = 0;

        red = false;
        blue = false;
    }

    private void SetHitChecksFalse()
    {
        water[0].hitWater = false;
        water[1].hitWater = false;
        water[2].hitWater = false;
        water[3].hitWater = false;

        checkpoints[0].hitCheckpoint = false;
        checkpoints[1].hitCheckpoint = false;
        checkpoints[2].hitCheckpoint = false;
        checkpoints[3].hitCheckpoint = false;
    }
}

