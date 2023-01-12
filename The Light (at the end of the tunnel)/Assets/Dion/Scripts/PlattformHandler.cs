using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformHandler : MonoBehaviour
{
    public GameObject[] redPlattforms;
    public GameObject[] bluePlattforms;

    public MovementController movementPlayer;
    public Mover player;

    public WaterCollision water;

    public CheckpointHandler[] checkpoints;

    private bool red;
    private bool blue;
    public bool isJumping;

    private int jumpCount = 0;

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

        //Debug.Log(water.hitWater);
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
        if ((jumpCount == 0 && isJumping && player.isGrounded))
        {
            Invoke("BlueActive", 0.4f);
        }
        //Red on
        else if ((jumpCount == 1 && isJumping && player.isGrounded))
        {
            Invoke("RedActive", 0.4f);
        }
        //Sets the red active if the player dies at the first part
        else if ((checkpoints[0].hitCheckpoint || checkpoints[2].hitCheckpoint || checkpoints[3].hitCheckpoint) && water.hitWater)
        {
            water.hitWater = false;

            RedActive();
        }
        //Sets the blue active if the player dies at the second part
        else if (checkpoints[1].hitCheckpoint && water.hitWater)
        {
            BlueActive();
        }

        //Reset
        if ((red && blue) || jumpCount == 2)
        {
            ResetCounter();
        }

        CheckCurrentCheckpoint();
    }

    private void BlueActive()
    {
        blue = true;

        jumpCount = 1;

        water.hitWater = false;

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

        water.hitWater = false;

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

    private void CheckCurrentCheckpoint()
    {
        //Set previous boolean hitCheckpoint to false if the player hits
        //The next checkpoint
        if (checkpoints[1].hitCheckpoint)
        {
            checkpoints[0].hitCheckpoint = false;
        }
        else if (checkpoints[2].hitCheckpoint)
        {
            checkpoints[1].hitCheckpoint = false;
        }
        else if (checkpoints[3].hitCheckpoint)
        {
            checkpoints[2].hitCheckpoint = false;
        }
    }
}
